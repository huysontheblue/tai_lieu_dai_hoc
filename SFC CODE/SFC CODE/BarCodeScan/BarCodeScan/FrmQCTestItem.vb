Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmQCTestItem

    ''' <summary>
    ''' 修改者： 黄广都
    ''' 修改日： 2020/01/18
    ''' 修改内容：
    ''' -------------------修改记录---------------------
    ''' 
    ''' </summary>
    ''' <remarks>检验项目</remarks>
    ''' 

    Private _PicDirector As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\RunCard\QCCheckFile\" & VbCommClass.VbCommClass.Factory

    '图片路径
    Private picPath As String = Nothing
    Dim bmp As Bitmap = Nothing
    Private m_itemCount As Integer
    Public Property itemCount() As Integer
        Get
            Return m_itemCount
        End Get

        Set(ByVal Value As Integer)
            m_itemCount = Value
        End Set
    End Property
    Private m_ItemDt As DataTable
    Public Property ItemDt() As DataTable
        Get
            Return m_ItemDt
        End Get

        Set(ByVal Value As DataTable)
            m_ItemDt = Value
        End Set
    End Property
#Region "事件"
    Private Sub FrmQCTestItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbOk.Checked = False
        rbNg.Checked = False
        If Me.lbBigTypeId.Text <> "N/A" Then
            GetTestItemData()
        End If

    End Sub
    Private Sub rbOk_CheckedChanged(sender As Object, e As EventArgs) Handles rbOk.CheckedChanged
        Dim item As Integer
        Dim sResult As String
        sResult = IIf(rbNg.Checked = True, "FAIL", "PASS")
        For item = 1 To Me.m_itemCount

            For Each contr As Control In Me.panTestItem.Controls
                If (TypeOf contr Is System.Windows.Forms.ComboBox) Then
                    If CType(contr, System.Windows.Forms.ComboBox).Name = "cbN5_" & item Then
                        CType(contr, System.Windows.Forms.ComboBox).SelectedItem = sResult
                    End If
                End If

            Next
        Next
    End Sub
    Private Sub rbNg_CheckedChanged(sender As Object, e As EventArgs) Handles rbNg.CheckedChanged
        Dim item As Integer
        Dim sResult As String
        sResult = IIf(rbOk.Checked = True, "PASS", "FAIL")
        For item = 1 To Me.m_itemCount
            For Each contr As Control In Me.panTestItem.Controls
                If (TypeOf contr Is System.Windows.Forms.ComboBox) Then
                    If CType(contr, System.Windows.Forms.ComboBox).Name = "cbN5_" & item Then
                        CType(contr, System.Windows.Forms.ComboBox).SelectedItem = sResult
                    End If
                End If

            Next
        Next
    End Sub
    Private Sub btnUploadClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button
        btn = CType(sender, Button)
        Dim iRow As Integer = CInt(btn.Name.ToString.Split("_")(1))
        If UploadNgPicture(iRow) = True Then
            MessageUtils.ShowInformation("上传成功!")
        Else

            MessageUtils.ShowError("上传失败,请检查!")
        End If

    End Sub


    Private Sub CobSelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim cb As System.Windows.Forms.ComboBox
        cb = CType(sender, System.Windows.Forms.ComboBox)

        Dim sResult As String = cb.SelectedItem.ToString
        Dim iRow As Integer = CInt(cb.Name.ToString.Split("_")(1))
        SetRowControlEvent(iRow, sResult)

    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If CheckTestItemData() = True Then
            SaveData()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region



#Region "函数"

    Private Sub LoadTestItemData()
        Dim item As Integer
        '行高
        Dim iRowHeight As Integer = 27
        '起始位置Y
        Dim iStartLocationY As Integer = 38

        Dim iTabIndex As Integer = 100

        Dim itemCount As Integer = Me.m_itemCount

        For item = 1 To itemCount
            Dim txtN1 = New System.Windows.Forms.TextBox()
            'Dim txtN2 = New System.Windows.Forms.TextBox()
            Dim cbN2 = New System.Windows.Forms.ComboBox()
            Dim txtN3 = New System.Windows.Forms.TextBox()
            Dim txtN4 = New System.Windows.Forms.TextBox()
            Dim btnUploadN = New System.Windows.Forms.Button()
            Dim cbN5 = New System.Windows.Forms.ComboBox()

            'TextBox1
            txtN1.Location = New System.Drawing.Point(3, iStartLocationY)
            txtN1.Name = "txtN1_" & item
            txtN1.Size = New System.Drawing.Size(177, 21)

            'TextBox2
            '
            'txtN2.Location = New System.Drawing.Point(216, iStartLocationY)
            'txtN2.Name = "txtN2_" & item

            'txtN2.Size = New System.Drawing.Size(100, 21)
            Dim strSql As String
            If lbBigTestItem.Text.ToString.Split("+")(0) = "外观" Then
                strSql = "SELECT CodeID,(CCName+'--'+CodeID+'('+CLevel+')') as CodeName FROM  m_Code_t  WHERE CLevel IN(N'主缺',N'次缺')"
            Else
                strSql = "SELECT CodeID,(CCName+'--'+CodeID+'('+CLevel+')') as CodeName FROM  m_Code_t  WHERE CLevel IN(N'重缺')"
            End If
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            Dim o_item As Integer
            Dim arr As New ArrayList()
            arr.Add(New DictionaryEntry("请选择", "N/A"))

            If dt.Rows.Count > 0 Then
                For o_item = 0 To dt.Rows.Count - 1
                    arr.Add(New DictionaryEntry(dt.Rows(o_item)!CodeName.ToString, dt.Rows(o_item)!CodeID.ToString))
                Next
            End If
            cbN2.DataSource = arr
            cbN2.DisplayMember = "Key"
            cbN2.ValueMember = "Value"
            cbN2.Location = New System.Drawing.Point(195, iStartLocationY)
            cbN2.Name = "cbN2_" & item
            cbN2.Size = New System.Drawing.Size(150, 21)
            cbN2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            cbN2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            '
            'TextBox3
            '
            txtN3.Location = New System.Drawing.Point(380, iStartLocationY)
            txtN3.Name = "txtN3_" & item
            txtN3.Size = New System.Drawing.Size(99, 21)

            '
            'TextBox4
            '
            txtN4.Location = New System.Drawing.Point(552, iStartLocationY)
            txtN4.Name = "txtN4_" & item
            txtN4.Size = New System.Drawing.Size(100, 21)

            '
            'Button3
            '
            btnUploadN.Location = New System.Drawing.Point(658, iStartLocationY)
            btnUploadN.Name = "btnUploadN_" & item
            btnUploadN.Size = New System.Drawing.Size(57, 23)
            btnUploadN.Text = "上传"
            btnUploadN.UseVisualStyleBackColor = True

            '
            'ComboBox1
            '
            cbN5.FormattingEnabled = True
            cbN5.Items.AddRange(New Object() {"PASS", "FAIL"})
            cbN5.Location = New System.Drawing.Point(767, iStartLocationY)
            cbN5.Name = "cbN5_" & item
            cbN5.Size = New System.Drawing.Size(90, 20)

            Me.panTestItem.Controls.Add(txtN1)
            Me.panTestItem.Controls.Add(cbN2)
            Me.panTestItem.Controls.Add(txtN3)
            Me.panTestItem.Controls.Add(txtN4)
            Me.panTestItem.Controls.Add(btnUploadN)
            Me.panTestItem.Controls.Add(cbN5)

            iStartLocationY = iStartLocationY + iRowHeight


        Next

        SetInitialControlEvent()
    End Sub

    Private Sub SetInitialControlEvent()
        Dim item As Integer
        For Each contr As Control In Me.panTestItem.Controls
            For item = 1 To Me.m_itemCount
                If (TypeOf contr Is System.Windows.Forms.Button) Then

                    If CType(contr, System.Windows.Forms.Button).Name = "btnUploadN_" & item Then
                        CType(contr, System.Windows.Forms.Button).Enabled = False

                        AddHandler CType(contr, System.Windows.Forms.Button).Click, AddressOf btnUploadClick
                    End If
                End If
                If (TypeOf contr Is System.Windows.Forms.TextBox) Then
                    If CType(contr, System.Windows.Forms.TextBox).Name = "txtN1_" & item Then
                        CType(contr, System.Windows.Forms.TextBox).Enabled = False
                        CType(contr, System.Windows.Forms.TextBox).Text = Me.m_ItemDt.Rows(item - 1)!SmallName.ToString
                        CType(contr, System.Windows.Forms.TextBox).Tag = Me.m_ItemDt.Rows(item - 1)!SmallID.ToString
                    End If
                    'If CType(contr, System.Windows.Forms.TextBox).Name = "txtN2_" & item Then
                    '    CType(contr, System.Windows.Forms.TextBox).Enabled = False

                    'End If
                    If CType(contr, System.Windows.Forms.TextBox).Name = "txtN3_" & item Then
                        'CType(contr, System.Windows.Forms.TextBox).Enabled = False
                        CType(contr, System.Windows.Forms.TextBox).Text = "N/A"
                    End If
                    If CType(contr, System.Windows.Forms.TextBox).Name = "txtN4_" & item Then
                        CType(contr, System.Windows.Forms.TextBox).Enabled = False
                    End If
                End If

                If (TypeOf contr Is System.Windows.Forms.ComboBox) Then
                    If CType(contr, System.Windows.Forms.ComboBox).Name = "cbN2_" & item Then
                        CType(contr, System.Windows.Forms.ComboBox).SelectedIndex = 0

                        CType(contr, System.Windows.Forms.ComboBox).Enabled = False
                    End If

                    If CType(contr, System.Windows.Forms.ComboBox).Name = "cbN5_" & item Then

                        CType(contr, System.Windows.Forms.ComboBox).DropDownStyle = ComboBoxStyle.DropDownList
                        AddHandler CType(contr, System.Windows.Forms.ComboBox).SelectedValueChanged, AddressOf CobSelectedValueChanged
                    End If
                End If

            Next


        Next
    End Sub

    Private Sub SetRowControlEvent(ByVal iRow As Integer, ByVal sResult As String)
        For Each contr As Control In Me.panTestItem.Controls
            If (TypeOf contr Is System.Windows.Forms.Button) Then

                If CType(contr, System.Windows.Forms.Button).Name = "btnUploadN_" & iRow Then

                    If sResult = "FAIL" Then
                        CType(contr, System.Windows.Forms.Button).Enabled = True
                    Else
                        CType(contr, System.Windows.Forms.Button).Enabled = False
                    End If

                End If
            End If
            If (TypeOf contr Is System.Windows.Forms.TextBox) Then
                'If CType(contr, System.Windows.Forms.TextBox).Name = "txtN2_" & iRow Then
                '    If sResult = "FAIL" Then
                '        CType(contr, System.Windows.Forms.TextBox).Enabled = True
                '    Else
                '        CType(contr, System.Windows.Forms.TextBox).Enabled = False
                '        CType(contr, System.Windows.Forms.TextBox).Text = ""
                '    End If
                'End If
                If CType(contr, System.Windows.Forms.TextBox).Name = "txtN3_" & iRow Then
                    'If sResult = "FAIL" Then
                    '    CType(contr, System.Windows.Forms.TextBox).Enabled = True
                    'Else
                    '    CType(contr, System.Windows.Forms.TextBox).Enabled = False
                    '    CType(contr, System.Windows.Forms.TextBox).Text = "N/A"
                    'End If
                    CType(contr, System.Windows.Forms.TextBox).Text = "N/A"
                End If
                If CType(contr, System.Windows.Forms.TextBox).Name = "txtN4_" & iRow Then
                    If sResult = "FAIL" Then
                        CType(contr, System.Windows.Forms.TextBox).Enabled = True
                    Else
                        CType(contr, System.Windows.Forms.TextBox).Enabled = False
                        CType(contr, System.Windows.Forms.TextBox).Text = ""
                    End If
                End If

            End If
            If (TypeOf contr Is System.Windows.Forms.ComboBox) Then
                If CType(contr, System.Windows.Forms.ComboBox).Name = "cbN2_" & iRow Then
                    If sResult = "FAIL" Then
                        CType(contr, System.Windows.Forms.ComboBox).Enabled = True
                    Else
                        CType(contr, System.Windows.Forms.ComboBox).Enabled = False
                        CType(contr, System.Windows.Forms.ComboBox).SelectedIndex = 0

                    End If

                End If

            End If
        Next
    End Sub

    Private Sub GetTestItemData()
        Try
            Dim strSql As String
            strSql = "select SmallID,SmallName from m_QCProducttestingMson_t where large='" & Me.lbBigTypeId.Text & "' and Effective='Y' "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then

                Me.m_itemCount = dt.Rows.Count
                Me.m_ItemDt = dt.Copy()
                LoadTestItemData()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    Private Function UploadNgPicture(ByVal iRow As Integer) As Boolean
        Try
            Dim picFileName As String

            '图片目录
            Dim picDirector As String = String.Empty
            Dim picUpPath As String = String.Empty
            Dim openDlg As OpenFileDialog = New OpenFileDialog()
            openDlg.InitialDirectory = "."
            openDlg.Filter = "JPG File(*.jpg)|*.jpg|JPEG File(*.jpeg)|*.jpeg|PNG File(*.png)|*.png|BMP File(*.bmp)|*.bmp"
            openDlg.RestoreDirectory = True
            openDlg.FileName = "sourcePic"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                picPath = openDlg.FileName
                If (Not picPath Is Nothing AndAlso System.IO.File.Exists(picPath)) Then
                    bmp = Image.FromFile(picPath)
                    If Not bmp Is Nothing Then
                        picFileName = Now.ToString("yyyyMMddHHmmssffff") & ".jpg"

                        picDirector = _PicDirector & "\" & Me.lbCid.Text & "\" & lbBarCode.Text
                        If System.IO.Directory.Exists(picDirector) = False Then
                            Directory.CreateDirectory(picDirector)
                        End If
                        picPath = picDirector & "\" & picFileName
                      
                        bmp.Save(picPath)
                        For Each contr As Control In Me.panTestItem.Controls
                            If (TypeOf contr Is System.Windows.Forms.TextBox) Then
                                If CType(contr, System.Windows.Forms.TextBox).Name = "txtN4_" & iRow Then
                                    CType(contr, System.Windows.Forms.TextBox).Text = picPath
                                End If
                            End If

                        Next
                    End If
                    bmp.Dispose()
                End If

            Else

                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return True
    End Function

    Private Function SaveData() As Boolean
        Try
             Dim strResult As String = String.Empty
            Dim item As Integer
            For Each contr As Control In Me.panTestItem.Controls
                For item = 1 To Me.m_itemCount
                  
                    If (TypeOf contr Is System.Windows.Forms.ComboBox) Then
                        If CType(contr, System.Windows.Forms.ComboBox).Name = "cbN5_" & item Then
                            strResult = CType(contr, System.Windows.Forms.ComboBox).SelectedItem.ToString
                            GetRowData(item, strResult)
                        End If
                    End If

                Next
            Next

        Catch ex As Exception
            Throw ex
        End Try
        Return True
    End Function



    Private Function CheckTestItemData() As Boolean
        Try

            Dim strResult As String = String.Empty
            Dim item As Integer
            Dim isReturn As Boolean = True
            For Each contr As Control In Me.panTestItem.Controls
                For item = 1 To Me.m_itemCount
                    If (TypeOf contr Is System.Windows.Forms.ComboBox) Then
                        If CType(contr, System.Windows.Forms.ComboBox).Name = "cbN5_" & item Then
                            strResult = CType(contr, System.Windows.Forms.ComboBox).SelectedItem.ToString
                            If String.IsNullOrEmpty(strResult) Then
                                isReturn = False

                                MessageUtils.ShowWarning("请选择检验结果,请检查第" & item & "行!")
                                Exit For
                            End If
                            If strResult = "FAIL" Then
                                If CheckRowTextBox(item) = False Then
                                    isReturn = False
                                    Exit For
                                End If
                            End If

                        End If
                    End If
                Next
            Next
            If isReturn = False Then
                Return False
            End If

        Catch ex As Exception
            Return False
            '   Throw ex
        End Try
        Return True
    End Function


    Private Function CheckRowTextBox(ByVal iRow As Integer) As Boolean

        Dim isReturn As Boolean = True
        Dim strNgCode As String = String.Empty
        For Each contr As Control In Me.panTestItem.Controls

            If (TypeOf contr Is System.Windows.Forms.ComboBox) Then
                If CType(contr, System.Windows.Forms.ComboBox).Name = "cbN2_" & iRow Then
                    strNgCode = CType(CType(contr, System.Windows.Forms.ComboBox).SelectedItem, DictionaryEntry).Value

                    If String.IsNullOrEmpty(strNgCode) OrElse strNgCode = "N/A" Then

                        MessageUtils.ShowWarning("请输入不良代码,请检查第" & iRow & "行!")

                        isReturn = False
                        Exit For
                    End If
                    'If CheckNgCodeExists(strNgCode) = False Then
                    '    MessageUtils.ShowWarning("不良现象代码不存在,请检查第" & iRow & "行!")
                    '    isReturn = False
                    '    Exit For
                    'End If
                End If

            End If
            'If (TypeOf contr Is System.Windows.Forms.TextBox) Then

            '    If CType(contr, System.Windows.Forms.TextBox).Name = "txtN2_" & iRow Then
            '        strNgCode = CType(contr, System.Windows.Forms.TextBox).Text

            '        If String.IsNullOrEmpty(strNgCode) Then

            '            MessageUtils.ShowWarning("请输入不良代码,请检查第" & iRow & "行!")

            '            isReturn = False
            '            Exit For
            '        End If
            '        If CheckNgCodeExists(strNgCode) = False Then
            '            MessageUtils.ShowWarning("不良现象代码不存在,请检查第" & iRow & "行!")
            '            isReturn = False
            '            Exit For
            '        End If


            '    End If

            'End If
        Next


        Return isReturn
    End Function


    Private Sub GetRowData(ByVal iRow As Integer, ByVal sResult As String)
        Dim strNgCode As String = String.Empty
        Dim strCheckValue As String = String.Empty
        Dim strPic As String = String.Empty
        'Dim strResult As String = String.Empty
        Dim strCid As String = lbCid.Text
        Dim strSn As String = lbBarCode.Text
        Dim strTestBigId As String = lbBigTypeId.Text
        Dim strTestSmallId As String = String.Empty
        For Each contr As Control In Me.panTestItem.Controls
            If (TypeOf contr Is System.Windows.Forms.ComboBox) Then
                If CType(contr, System.Windows.Forms.ComboBox).Name = "cbN2_" & iRow Then
                    'strNgCode = CType(contr, System.Windows.Forms.ComboBox).SelectedValue

                    strNgCode = CType(CType(contr, System.Windows.Forms.ComboBox).SelectedItem, DictionaryEntry).Value
                End If

            End If
            If (TypeOf contr Is System.Windows.Forms.TextBox) Then

                If (TypeOf contr Is System.Windows.Forms.TextBox) Then
                    If CType(contr, System.Windows.Forms.TextBox).Name = "txtN1_" & iRow Then
                        strTestSmallId = CType(contr, System.Windows.Forms.TextBox).Tag
                    End If
                    'If CType(contr, System.Windows.Forms.TextBox).Name = "txtN2_" & iRow Then
                    '    strNgCode = CType(contr, System.Windows.Forms.TextBox).Text
                    '    If String.IsNullOrEmpty(strNgCode) Then
                    '        strNgCode = "N/A"
                    '    End If

                    'End If
                    If CType(contr, System.Windows.Forms.TextBox).Name = "txtN3_" & iRow Then
                        strCheckValue = CType(contr, System.Windows.Forms.TextBox).Text
                        If String.IsNullOrEmpty(strCheckValue) Then
                            strCheckValue = "N/A"
                        End If
                    End If
                    If CType(contr, System.Windows.Forms.TextBox).Name = "txtN4_" & iRow Then
                        strPic = CType(contr, System.Windows.Forms.TextBox).Text
                        InertDataRow(strCid, strTestBigId, strTestSmallId, strCheckValue, strNgCode, strPic, sResult)
                    End If
                End If


            End If
        Next
    End Sub

    Private Sub InertDataRow(ByVal strCid As String, ByVal strTestBigId As String, ByVal strTestSmallId As String, ByVal strCheckValue As String, ByVal strNgCode As String,
                             ByVal strPicPath As String, ByVal strResult As String)
        Try
            Dim sb As New StringBuilder
            Dim strUser As String = VbCommClass.VbCommClass.UseId
            Dim sCheckType As String = String.Empty
            If lbBigTestItem.Text.Contains("外观") Then
                sCheckType = "外观"
            Else
                sCheckType = "功能"
            End If
            '插入数据明细表
            Dim Falg As Integer
            Dim para(12) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@Cid", SqlDbType.VarChar, 50),
                New SqlParameter("@Ppid", SqlDbType.VarChar, 50),
                New SqlParameter("@TestBigId", SqlDbType.NVarChar, 50),
                New SqlParameter("@TestSmallId", SqlDbType.NVarChar, 100),
                New SqlParameter("@CheckValue", SqlDbType.NVarChar, 50),
                New SqlParameter("@NgCode", SqlDbType.VarChar, 50),
                New SqlParameter("@PicPath", SqlDbType.NVarChar, 500),
                New SqlParameter("@CheckResult", SqlDbType.NVarChar, 500),
                New SqlParameter("@CheckType", SqlDbType.NVarChar, 10),
                New SqlParameter("@IsAutoJuage", SqlDbType.NVarChar, 10),
                New SqlParameter("@UserID", SqlDbType.NVarChar, 10),
                New SqlParameter("@Falg", SqlDbType.Int, 20)
            }
            parameters(0).Value = strCid
            parameters(1).Value = Me.lbBarCode.Text
            parameters(2).Value = strTestBigId
            parameters(3).Value = strTestSmallId
            parameters(4).Value = strCheckValue
            parameters(5).Value = strNgCode
            parameters(6).Value = strPicPath
            parameters(7).Value = strResult
            parameters(8).Value = sCheckType
            parameters(9).Value = "N"
            parameters(10).Value = strUser
            parameters(11).Direction = ParameterDirection.Output
            parameters(11).Value = Falg
            DbOperateUtils.ExecuteNonQureyByProc("m_QCCheckTestItemSave_P", parameters)
            If parameters(11).Value.ToString = "0" Then
                MessageUtils.ShowError("保存数据失败，请检查是否重复检验！")
                Return
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 检查不良现象是否存在
    ''' </summary>
    ''' <param name="NgCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckNgCodeExists(ByVal NgCode As String) As Boolean
        Try
            Dim strSql As String
            strSql = "select CodeID from m_Code_t where CodeID='" & NgCode & "' and usey='Y' AND CLevel IN(N'主缺',N'次缺',N'重缺')"
            Dim i As Integer = DbOperateUtils.GetRowsCount(strSql)
            If i > 0 Then
                Return True
            End If
        Catch ex As Exception
            Throw
        End Try
        Return False
    End Function

#End Region







End Class