Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports MainFrame.SysCheckData
Imports MainFrame

''' <summary>
''' 修改者： 黄广都
''' 修改日： 2020/03/02
''' 修改内容：
''' -------------------修改记录---------------------
''' 
''' </summary>
''' <remarks>品质抽检-批量检验</remarks>
''' 
''' 
Public Class FrmQCCheckList


#Region "属性"

    Private _PicDirector As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\RunCard\QCCheckFile\" & VbCommClass.VbCommClass.Factory
    '是否已显示测试项
    Private IsControlShow As Boolean = False
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
    Private m_ItemPpid As String
    Public Property ItemPpid() As String
        Get
            Return m_ItemPpid
        End Get

        Set(ByVal Value As String)
            m_ItemPpid = Value
        End Set
    End Property


    Private m_QCCheckList As List(Of QCCheckListModle)
    Public Property QCCheckList() As List(Of QCCheckListModle)
        Get
            Return m_QCCheckList
        End Get

        Set(ByVal Value As List(Of QCCheckListModle))
            m_QCCheckList = Value
        End Set
    End Property
#End Region

#Region "事件"
    Private Sub FrmQCCheckList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.m_QCCheckList = New List(Of QCCheckListModle)
        Me.IsControlShow = False
        Me.lbMsg.Text = ""
        GetCheckSn()
    End Sub
    ''' <summary>
    ''' 获取已检验的SN
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetCheckSn()
        Try
            Dim strSql As New StringBuilder
            strSql.Append(" EXEC GetQCCheckSnJudgeList  '" & lbCID.Text & "','" & lbPartNo.Text & "'")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql.ToString)
            Me.dgvCheckSN.ClearSelection()
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                Me.dgvCheckSN.Rows.Add((i + 1).ToString, dt.Rows(i)("ppid").ToString(), dt.Rows(i)("JudgeStatus").ToString())
            Next


            'dgvCheckSN.DataSource = dt
            'dgvCheckSN.DataSource = dt
            'lbCheckCount.Text = dt.Rows.Count
            'Dim dvQC As DataView = New DataView(dt.Copy)

            'dvQC.RowFilter = "JudgeStatus='未判定'"
            'lbNoJudge.Text = dvQC.Count
            'dvQC.RowFilter = "GN='是'"
            'lbFuncQty.Text = CInt(txtMinFunQty.Text) - dvQC.Count
            'If Me.lbStatus.Text = "Y" Then
            '    dgvCheckSN.Columns("clear").Visible = False
            'Else
            '    dgvCheckSN.Columns("clear").Visible = True
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtBarCode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtBarCode.PreviewKeyDown
        If e.KeyValue = 13 Then
            If Not String.IsNullOrEmpty(txtBarCode.Text) Then
                Me.lbMsg.Text = ""
                If CheckScanData() = True Then
                    '保存扫一个SN的记录
                    If Not String.IsNullOrEmpty(Me.m_ItemPpid) Then
                        SaveItemPpidResultData()
                    End If
                    Me.m_ItemPpid = txtBarCode.Text
                    ScanData()
                    txtBarCode.Text = ""
                End If
            End If
        End If
    End Sub
    Private Sub dgvList_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvList.CellFormatting
        If e.RowIndex > -1 AndAlso Me.dgvList.RowCount > 0 Then
            If e.ColumnIndex = 1 Then
                Dim _Result As String
                _Result = Me.dgvList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
                If _Result = "PASS" Then
                    e.CellStyle.ForeColor = Color.Green
                Else
                    e.CellStyle.ForeColor = Color.Red
                End If
            End If
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
      
        Try
            '保存扫一个SN的记录
            If Not String.IsNullOrEmpty(Me.m_ItemPpid) Then
                SaveItemPpidResultData()
            End If
            If Me.m_QCCheckList.Count > 0 Then


                If CheckListData() = True Then
                    Me.tslMsg.Text = "正在保存结果,请勿关闭窗口..."
                    Me.Cursor = Cursors.WaitCursor
                    For Each qcModle As QCCheckListModle In Me.m_QCCheckList
                        InertDataRow(qcModle.Cid, qcModle.Ppid, qcModle.TestBigId, qcModle.TestSmallId, qcModle.TestValue, qcModle.NgCodeId, qcModle.ImgPath, qcModle.Result)
                    Next
                    Me.tslMsg.Text = ""
                    Me.Cursor = Cursors.Default
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If

            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmQCCheckList", "btnSave_Click", "sys")
        End Try
       
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick
        If Not Me.dgvList.CurrentRow Is Nothing AndAlso Me.dgvList.RowCount > 0 Then
            '保存扫一个SN的记录
            If Not String.IsNullOrEmpty(Me.m_ItemPpid) Then
                SaveItemPpidResultData()
            End If
            Me.lbMsg.Text = ""
            Dim Ppid As String
            Ppid = Me.dgvList.CurrentRow.Cells("colPpid").Value.ToString
            Me.m_ItemPpid = Ppid

            If Not String.IsNullOrEmpty(Ppid) Then
                SetInitialControlEventPpid(Ppid)
            End If


        End If
    End Sub
    Private Sub dgvList_SelectionChanged(sender As Object, e As EventArgs) Handles dgvList.SelectionChanged
     
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
#End Region


#Region "函数"

    Private Sub ScanData()
        Dim sResult As String
        If Me.IsControlShow = False Then
            GetTestItemData()
            Me.IsControlShow = True
        End If
        sResult = IIf(rbPass.Checked, "PASS", "FAIL")
        Dim rows As Integer = Me.dgvList.Rows.Count
        Me.dgvList.ClearSelection()
        Me.dgvList.Rows.Add((rows + 1).ToString(), txtBarCode.Text, sResult)
        Me.dgvList.Rows(Me.dgvList.Rows.Count - 1).Cells(0).Selected = True

        'Me.dgvList.Rows.Insert(0, txtBarCode.Text, sResult)

        ''初始加载
        'SetInitialControlEvent()
    End Sub
    Private Sub SaveItemPpidResultData()
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
    End Sub

    Private Sub LoadTestItemData()
        Dim item As Integer
        '行高
        Dim iRowHeight As Integer = 27
        '起始位置Y
        Dim iStartLocationY As Integer = 37

        Dim iTabIndex As Integer = 100

        Dim itemCount As Integer = Me.m_itemCount

        For item = 1 To itemCount
            Dim txtN1 = New System.Windows.Forms.TextBox()
            Dim cbN2 = New System.Windows.Forms.ComboBox()
            'Dim txtN2 = New System.Windows.Forms.TextBox()
            Dim txtN3 = New System.Windows.Forms.TextBox()
            Dim txtN4 = New System.Windows.Forms.TextBox()
            Dim btnUploadN = New System.Windows.Forms.Button()
            Dim cbN5 = New System.Windows.Forms.ComboBox()

            'TextBox1
            txtN1.Location = New System.Drawing.Point(5, iStartLocationY)
            txtN1.Name = "txtN1_" & item
            'txtN1.Size = New System.Drawing.Size(177, 21)
            txtN1.Size = New System.Drawing.Size(139, 21)

            'ComboBox1
            '
            'txtN2.Location = New System.Drawing.Point(195, iStartLocationY)
            'txtN2.Name = "txtN2_" & item

            'txtN2.Size = New System.Drawing.Size(86, 21)

            Dim strSql As String
            strSql = "SELECT CodeID,(CCName+'--'+CodeID+'('+CLevel+')') as CodeName FROM  m_Code_t  WHERE CLevel IN(N'主缺',N'次缺')"
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
            txtN3.Location = New System.Drawing.Point(378, iStartLocationY)
            txtN3.Name = "txtN3_" & item
            txtN3.Size = New System.Drawing.Size(86, 21)

            '
            'TextBox4
            '
            txtN4.Location = New System.Drawing.Point(526, iStartLocationY)
            txtN4.Name = "txtN4_" & item
            txtN4.Size = New System.Drawing.Size(73, 21)

            '
            'Button3
            '
            btnUploadN.Location = New System.Drawing.Point(605, iStartLocationY)
            btnUploadN.Name = "btnUploadN_" & item
            btnUploadN.Size = New System.Drawing.Size(57, 23)
            btnUploadN.Text = "上传"
            btnUploadN.UseVisualStyleBackColor = True

            '
            'ComboBox2
            '
            cbN5.FormattingEnabled = True
          
            cbN5.Items.AddRange(New Object() {"PASS", "FAIL"})
            cbN5.Location = New System.Drawing.Point(708, iStartLocationY)
            cbN5.Name = "cbN5_" & item
            cbN5.Size = New System.Drawing.Size(70, 20)

            Me.panTestItem.Controls.Add(txtN1)
            Me.panTestItem.Controls.Add(cbN2)
            'Me.panTestItem.Controls.Add(txtN2)
            Me.panTestItem.Controls.Add(txtN3)
            Me.panTestItem.Controls.Add(txtN4)
            Me.panTestItem.Controls.Add(btnUploadN)
            Me.panTestItem.Controls.Add(cbN5)

            iStartLocationY = iStartLocationY + iRowHeight


        Next

        SetInitialControlEvent()
    End Sub

    Private Sub SetInitialControlEvent()
        Dim iRe As Integer
        Dim item As Integer
        For Each contr As Control In Me.panTestItem.Controls
            For item = 1 To Me.m_itemCount
                If (TypeOf contr Is System.Windows.Forms.Button) Then

                    If CType(contr, System.Windows.Forms.Button).Name = "btnUploadN_" & item Then
                        If rbFail.Checked Then
                            CType(contr, System.Windows.Forms.Button).Enabled = True
                        Else
                            CType(contr, System.Windows.Forms.Button).Enabled = False
                        End If


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
                    '    If rbFail.Checked Then
                    '        CType(contr, System.Windows.Forms.TextBox).Enabled = True
                    '    Else
                    '        CType(contr, System.Windows.Forms.TextBox).Enabled = False
                    '    End If
                    'End If

                    If CType(contr, System.Windows.Forms.TextBox).Name = "txtN3_" & item Then
                        'CType(contr, System.Windows.Forms.TextBox).Enabled = False
                        CType(contr, System.Windows.Forms.TextBox).Text = "N/A"
                    End If
                    If CType(contr, System.Windows.Forms.TextBox).Name = "txtN4_" & item Then
                        If rbFail.Checked Then
                            CType(contr, System.Windows.Forms.TextBox).Enabled = True
                        Else
                            CType(contr, System.Windows.Forms.TextBox).Enabled = False
                        End If

                    End If
                End If

                If (TypeOf contr Is System.Windows.Forms.ComboBox) Then
                    If CType(contr, System.Windows.Forms.ComboBox).Name = "cbN2_" & item Then
                        'CType(contr, System.Windows.Forms.ComboBox).SelectedItem = "N/A"
                        CType(contr, System.Windows.Forms.ComboBox).SelectedIndex = 0
                        'CType(CType(contr, System.Windows.Forms.ComboBox).SelectedItem, DictionaryEntry).Value = ""
                        If rbFail.Checked Then
                            CType(contr, System.Windows.Forms.ComboBox).Enabled = True

                        Else
                            CType(contr, System.Windows.Forms.ComboBox).Enabled = False
                        End If

                    End If
                    If CType(contr, System.Windows.Forms.ComboBox).Name = "cbN5_" & item Then

                        CType(contr, System.Windows.Forms.ComboBox).DropDownStyle = ComboBoxStyle.DropDownList

                        AddHandler CType(contr, System.Windows.Forms.ComboBox).SelectedValueChanged, AddressOf CobSelectedValueChanged
                        iRe = IIf(rbPass.Checked, 0, 1)
                        CType(contr, System.Windows.Forms.ComboBox).SelectedIndex = iRe
                    End If
                End If

            Next


        Next
    End Sub

    Private Sub SetInitialControlEventPpid(ByVal Ppid As String)
        Dim iRe As Integer
        Dim item As Integer

        For Each contr As Control In Me.panTestItem.Controls
            For item = 1 To Me.m_itemCount

                Dim model As QCCheckListModle = Me.m_QCCheckList.Find(Function(n) n.Ppid = Ppid AndAlso n.TestSmallId = Me.m_ItemDt.Rows(item - 1)!SmallID.ToString)
                If IsNothing(model) Then
                    Exit For
                End If

                If (TypeOf contr Is System.Windows.Forms.Button) Then

                    If CType(contr, System.Windows.Forms.Button).Name = "btnUploadN_" & item Then
                        If model.Result = "FAIL" Then
                            CType(contr, System.Windows.Forms.Button).Enabled = True
                        Else

                            CType(contr, System.Windows.Forms.Button).Enabled = False
                        End If


                        'AddHandler CType(contr, System.Windows.Forms.Button).Click, AddressOf btnUploadClick
                    End If
                End If
                If (TypeOf contr Is System.Windows.Forms.TextBox) Then
 
                    '不良现象代码
                    'If CType(contr, System.Windows.Forms.TextBox).Name = "txtN2_" & item Then
                    '    If model.Result = "FAIL" Then
                    '        CType(contr, System.Windows.Forms.TextBox).Enabled = True
                    '    Else
                    '        CType(contr, System.Windows.Forms.TextBox).Enabled = False
                    '    End If
                    '    If model.NgCodeId = "N/A" Then
                    '        CType(contr, System.Windows.Forms.TextBox).Text = ""
                    '    Else
                    '        CType(contr, System.Windows.Forms.TextBox).Text = model.NgCodeId
                    '    End If
                    'End If



                    If CType(contr, System.Windows.Forms.TextBox).Name = "txtN3_" & item Then
                        'CType(contr, System.Windows.Forms.TextBox).Enabled = False
                        CType(contr, System.Windows.Forms.TextBox).Text = model.TestValue
                    End If
                    If CType(contr, System.Windows.Forms.TextBox).Name = "txtN4_" & item Then
                        CType(contr, System.Windows.Forms.TextBox).Enabled = False
                    End If
                End If

                If (TypeOf contr Is System.Windows.Forms.ComboBox) Then
                    If CType(contr, System.Windows.Forms.ComboBox).Name = "cbN2_" & item Then
                        If model.Result = "FAIL" Then
                            CType(contr, System.Windows.Forms.ComboBox).Enabled = True
                        Else
                            CType(contr, System.Windows.Forms.ComboBox).Enabled = False
                        End If
                        If model.NgCodeId = "N/A" Then
                            CType(contr, System.Windows.Forms.ComboBox).SelectedIndex = 0
                        Else
                            'CType(contr, System.Windows.Forms.ComboBox).SelectedValue = model.NgCodeId
                            CType(contr, System.Windows.Forms.ComboBox).SelectedValue = model.NgCodeId
                            'CType(contr, System.Windows.Forms.ComboBox).SelectedItem
                            'CType(CType(contr, System.Windows.Forms.ComboBox).SelectedItem, DictionaryEntry).Value
                            'CType(CType(contr, System.Windows.Forms.ComboBox).SelectedItem, DictionaryEntry).Value = model.NgCodeId
                        End If


                        'CType(contr, System.Windows.Forms.ComboBox).DropDownStyle = ComboBoxStyle.DropDownList
                        'iRe = IIf(model.Result = "PASS", 0, 1)
                        'CType(contr, System.Windows.Forms.ComboBox).SelectedIndex = iRe
                    End If
                    If CType(contr, System.Windows.Forms.ComboBox).Name = "cbN5_" & item Then

                        CType(contr, System.Windows.Forms.ComboBox).DropDownStyle = ComboBoxStyle.DropDownList
                        iRe = IIf(model.Result = "PASS", 0, 1)
                        CType(contr, System.Windows.Forms.ComboBox).SelectedIndex = iRe
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
            Throw ex
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
                    'CType(contr, System.Windows.Forms.ComboBox).SelectedValue

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

    Private Function CheckListData() As Boolean
        Dim re As Boolean = True
        Try
            For Each qcModle As QCCheckListModle In Me.m_QCCheckList
                If qcModle.Result = "FAIL" Then
                    If String.IsNullOrEmpty(qcModle.NgCodeId) OrElse qcModle.NgCodeId = "N/A" Then
                        lbMsg.Text = qcModle.Ppid & ",不良现象未填写，请检查!"
                        re = False
                        Exit For
                    End If
                    'If CheckNgCodeExists(qcModle.NgCodeId) = False Then
                    '    lbMsg.Text = qcModle.Ppid & ",不良现象代码不存在，请检查!"
                    '    re = False
                    '    Exit For
                    'End If
            
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return re
    End Function

    Private Sub GetRowData(ByVal iRow As Integer, ByVal sResult As String)
        Dim strNgCode As String = String.Empty
        Dim strCheckValue As String = String.Empty
        Dim strPic As String = String.Empty
        'Dim strResult As String = String.Empty
        Dim strCid As String = lbCid.Text
        Dim strSn As String = ""
        'Dim strSn As String = lbBarCode.Text
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
                        Me.m_QCCheckList.Remove(Me.m_QCCheckList.Find(Function(n) n.Ppid = Me.m_ItemPpid AndAlso n.TestSmallId = strTestSmallId))

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

                        Dim qcCheck As New QCCheckListModle
                        qcCheck.Cid = lbCID.Text
                        qcCheck.Ppid = Me.m_ItemPpid
                        qcCheck.TestBigId = strTestBigId
                        qcCheck.TestSmallId = strTestSmallId
                        qcCheck.NgCodeId = strNgCode
                        qcCheck.ImgPath = strPic
                        qcCheck.Result = sResult
                        Me.m_QCCheckList.Add(qcCheck)

                    End If
                End If


            End If
        Next
    End Sub

    Private Sub InertDataRow(ByVal strCid As String, ByVal Ppid As String, ByVal strTestBigId As String, ByVal strTestSmallId As String, ByVal strCheckValue As String, ByVal strNgCode As String,
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
            parameters(1).Value = Ppid
            parameters(2).Value = strTestBigId
            parameters(3).Value = strTestSmallId
            parameters(4).Value = strCheckValue
            parameters(5).Value = strNgCode
            parameters(6).Value = strPicPath
            parameters(7).Value = strResult
            parameters(8).Value = sCheckType
            parameters(9).Value = "Y"
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
            strSql = "select CodeID from m_Code_t where CodeID='" & NgCode & "' and usey='Y' AND  CLevel IN(N'主缺',N'次缺',N'重缺')"
            Dim i As Integer = DbOperateUtils.GetRowsCount(strSql)
            If i > 0 Then
                Return True
            End If
        Catch ex As Exception
            Throw
        End Try
        Return False
    End Function
    ''' <summary>
    ''' 扫描验证
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckScanData() As Boolean

        Dim iQcqty As Integer
        Dim iCheckedQty As Integer
        Dim iItemQty As Integer
        If String.IsNullOrEmpty(txtBarCode.Text) Then
            lbMsg.Text = txtBarCode.Text & ",扫描的SN错误,请检查！"
            txtBarCode.SelectAll()
            Return False
        End If


        If SnCheckInput() = False Then
            txtBarCode.SelectAll()
            Return False
        End If
        iQcqty = CInt(Me.lbQCqty.Text)
        iCheckedQty = CInt(Me.lbCheckedQty.Text)
        If iCheckedQty >= iQcqty Then
            lbMsg.Text = txtBarCode.Text & ",本批次数量已检验满,请检查！"
            txtBarCode.SelectAll()

            Return False
        End If

        If Me.dgvList.RowCount > 0 Then
            iItemQty = iQcqty - iCheckedQty
            If Me.dgvList.RowCount + 1 > iItemQty Then
                lbMsg.Text = txtBarCode.Text & ",检验数不能大于批次数量,请检查！"
                txtBarCode.SelectAll()
                Return False
            End If

        End If
        If Me.dgvList.RowCount > 0 Then
            Dim sPpid = String.Empty
            For Each Row As DataGridViewRow In Me.dgvList.Rows
                If Not Row.Cells("colPpid").Value Is Nothing Then
                    sPpid = Row.Cells("colPpid").Value.ToString
                    If txtBarCode.Text = sPpid Then
                        lbMsg.Text = txtBarCode.Text & ",已在检验列表,请勿重复检验！"
                        txtBarCode.SelectAll()
                        Return False
                    End If
                End If
            Next
          
        End If
        Return True
    End Function


    ''' <summary>
    ''' 检查产品是否已进入维修
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SnCheckInput() As Boolean
        Try

            Dim rMsg As String = String.Empty
            Dim rFalg As Integer = 0
            Dim para(7) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@CID", SqlDbType.VarChar, 50),
                New SqlParameter("@Ppid", SqlDbType.VarChar, 50),
                 New SqlParameter("@Moid", SqlDbType.VarChar, 50),
                New SqlParameter("@PartNo", SqlDbType.VarChar, 50),
                 New SqlParameter("@TestBigType", SqlDbType.VarChar, 50),
                New SqlParameter("@Msg", SqlDbType.NVarChar, 150),
                New SqlParameter("@RTVALUE", SqlDbType.VarChar, 1)
            }
            parameters(0).Value = Me.lbCID.Text
            parameters(1).Value = Me.txtBarCode.Text
            parameters(2).Value = Me.lbMoid.Text
            parameters(3).Value = Me.lbPartNo.Text
            parameters(4).Value = Me.lbBigTypeId.Text
            parameters(5).Direction = ParameterDirection.Output
            parameters(6).Direction = ParameterDirection.Output
            DbOperateUtils.ExecuteNonQureyByProc("m_QCCheckPcsCheckInput", parameters)
            If parameters(6).Value.ToString = "1" Then
                lbMsg.Text = txtBarCode.Text & "," & parameters(5).Value.ToString

                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 上传图片
    ''' </summary>
    ''' <param name="irow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UploadNgPicture(ByVal irow As String) As Boolean
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

                        picDirector = _PicDirector & "\" & Me.lbCID.Text & "\" & irow
                        If System.IO.Directory.Exists(picDirector) = False Then
                            Directory.CreateDirectory(picDirector)
                        End If
                        picPath = picDirector & "\" & picFileName

                        bmp.Save(picPath)

                        For Each contr As Control In Me.panTestItem.Controls
                            If (TypeOf contr Is System.Windows.Forms.TextBox) Then
                                If CType(contr, System.Windows.Forms.TextBox).Name = "txtN4_" & irow Then
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
#End Region



  
End Class

Public Class QCCheckListModle
    '批次号
    Public Cid As String
    '条码
    Public Ppid As String

    '不良大类
    Public TestBigId As String
    '测试小项
    Public TestSmallId As String

    '不良代码
    Public NgCodeId As String
    '测试值
    Public TestValue As String
    '上传图片
    Public ImgPath As String
    '结果
    Public Result As String
End Class