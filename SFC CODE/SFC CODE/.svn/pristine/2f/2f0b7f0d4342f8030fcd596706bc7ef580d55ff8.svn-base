

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Public Class FrmFixedCodeScan
    ''' <summary>
    ''' 修改者： 黄广都
    ''' 修改日： 2019/11/29
    ''' 修改内容：
    ''' -------------------修改记录---------------------
    ''' 
    ''' </summary>
    ''' <remarks>g固定码校验</remarks>
    Dim list As List(Of String)
    Dim iNx As Integer = 0
    Dim IsMore As Boolean = False
    Dim box As Boolean = False
    '定义样式数组
    Dim style(5) As String

    Private Sub FrmFixedCodeScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsMore = False
        iNx = 0
        list = New List(Of String)
       

    End Sub


    Private Function SetCheckData() As Boolean
        If String.IsNullOrEmpty(txtScanOne.Text) AndAlso String.IsNullOrEmpty(txtScanTwo.Text) AndAlso String.IsNullOrEmpty(txtScanTree.Text) AndAlso String.IsNullOrEmpty(txtScanFour.Text) Then

            ShowInfoMsg(False, "请至少配置一个固定码!")
            Return False
        End If
        If String.IsNullOrEmpty(txtScanOne.Text) Then
            ShowInfoMsg(False, "请先配置固定条码一!")
            Return False
        End If
    
        If Not String.IsNullOrEmpty(txtScanTree.Text) AndAlso String.IsNullOrEmpty(txtScanTwo.Text) Then

            ShowInfoMsg(False, "请先配置固定条码二!")
            Return False
        End If
        If Not String.IsNullOrEmpty(txtScanFour.Text) AndAlso String.IsNullOrEmpty(txtScanTree.Text) Then
            ShowInfoMsg(False, "请先配置固定条码三!")
            Return False
        End If
        Return True
    End Function


    Public Function funCheckRegular(ByVal strPattern As String, TextReg As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(TextReg, strPattern)
    End Function

    Private Sub txtBarcode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtBarcode.PreviewKeyDown
        If e.KeyValue = 13 Then
            If Not String.IsNullOrEmpty(txtBarcode.Text) Then
                ScanData()
            End If
        End If
    End Sub

    Private Sub ScanData()

        If list.Count = 0 Then
            ShowInfoMsg(False, "FAIL,请先配置固定条码!")
            txtBarcode.Text = ""
            Return
        End If
        Dim iScanAcout As Integer = 0
        Dim sBarCode As String
        Dim sTitle As String = "一,二,三,四,五,六,七,八,九,十"
        sBarCode = txtBarcode.Text
        If sBarCode <> list(iNx) Then
            ShowMsg(False, sBarCode)

            Return
        End If
        iNx = iNx + 1
        TextBoxUL1.Text = style(iNx + 1)
        If iNx = list.Count Then
            iScanAcout = CInt(labScanAcount.Text) + 1
            labScanAcount.Text = iScanAcout
            '保存扫描数据
            TextBoxUL1.Text = style(0 + 1)
            SaveScanData()
            iNx = 0

        End If
        Me.DGridBarCode.Rows.Insert(0, sBarCode, SysMessageClass.UseId, Now())

        DGridBarCode.ClearSelection()
        DGridBarCode.Rows(0).Cells(0).Selected = True
        If DGridBarCode.Rows.Count > 10 Then
            DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
        End If
        txtBarcode.Text = ""
        lbBarcode.Text = "固定条码" & sTitle.Split(",")(iNx)
        ShowMsg(True, sBarCode)
    End Sub

    Private Sub ShowMsg(ByVal b As Boolean, ByVal barcode As String)
        If b Then
            lbMsg.ForeColor = Color.Green
            lbMsg.Text = "PASS," & barcode & "扫描成功!"
        Else
            lbMsg.ForeColor = Color.Red
            lbMsg.Text = "FAIL," & barcode & "扫描失败,请扫描条码" & TextBoxUL1.Text & "！"
            WorkStantOption.ErrorStr = lbMsg.Text
            WorkStantOption.BarCodeStr = barcode
            lbMsg.Text = WorkStantOption.ErrorStr
            WorkStantOption.vMainBarCode = Me.txtBarcode.Text
            Dim FrmError As New FrmScanErrPrompt
            FrmError.ShowDialog() '' WorkStantOption.vPreStation
            If WorkStantOption.vDeserTionFlag = True Then
                txtBarcode.Clear()
                WorkStantOption.vCurrentStandIndex = 1
                'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
                'LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
            End If
            txtBarcode.Text = ""
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        txtBarcode.Text = ""
    End Sub

    Private Sub ShowInfoMsg(ByVal b As Boolean, ByVal msg As String)
        If b Then
            lbMsg.ForeColor = Color.Green
        Else
            lbMsg.ForeColor = Color.Red

        End If
        lbMsg.Text = msg
    End Sub


    Private Sub SetScanList()
        list = New List(Of String)
        If Not String.IsNullOrEmpty(txtScanOne.Text.Trim) Then
            list.Add(txtScanOne.Text)
        End If
        If Not String.IsNullOrEmpty(txtScanTwo.Text.Trim) Then
            list.Add(txtScanTwo.Text)
        End If

        If Not String.IsNullOrEmpty(txtScanTree.Text.Trim) Then
            list.Add(txtScanTree.Text)
        End If

        If Not String.IsNullOrEmpty(txtScanFour.Text.Trim) Then
            list.Add(txtScanFour.Text)
        End If
        If list.Count > 1 Then
            IsMore = True
        End If

    End Sub


    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click
        Dim FrmOpenLock As New FrmSetLock
        FrmOpenLock.ShowDialog()
        If CartonScanOption.CheckStr = True Then

            Dim FrmSet As New FrmFixedCodeSet

            If FrmSet.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtScanOne.Text = FrmSet.FixOne
                txtScanTwo.Text = FrmSet.FixTwo
                txtScanTree.Text = FrmSet.FixThr
                txtScanFour.Text = FrmSet.FixFour
                SetScanList()
                GetMoidData(FrmSet.MoId)

                DGridBarCode.Rows.Clear()

                ShowInfoMsg(True, "配置成功,请扫描......")
            End If

        End If
    End Sub

    Private Sub GetMoidData(ByVal moid As String)
        Dim strSql As String = "select a.PartID,a.Lineid,ISNULL(a.Moqty,0) Moqty,isnull(b.ScanQty,0) ScanQty,boxeffective,BoxQty,box,FixedCodeOne,FixedCodeTwo,FixedCodeThr,FixedCodeFou from m_Mainmo_t a  inner join " & _
            " m_FixedCodeSet_t b on b.Moid=a.Moid  where  a.MOID='" & moid & "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
        If dt.Rows.Count > 0 Then
            Me.lbMoid.Text = moid
            Me.lbPartNo.Text = dt.Rows(0)!PartID.ToString
            Me.lbLineId.Text = dt.Rows(0)!Lineid.ToString
            Me.lbMoQty.Text = dt.Rows(0)!Moqty.ToString
            Me.labScanAcount.Text = dt.Rows(0)!scanqty.ToString
            iNx = 0
            style(0) = dt.Rows(0)!box.ToString
            style(1) = dt.Rows(0)!FixedCodeOne.ToString
            style(2) = dt.Rows(0)!FixedCodeTwo.ToString
            style(3) = dt.Rows(0)!FixedCodeThr.ToString
            style(4) = dt.Rows(0)!FixedCodeFou.ToString
            box = False
            '勾选扫描箱条码
            If dt.Rows(0)!boxeffective.ToString = "Y" Then
                box = True
                boxqty.Text = dt.Rows(0)!BoxQty.ToString
                TextBoxUL1.Text = dt.Rows(0)!box.ToString
                Dim sql As String = "SELECT COUNT(box) FROM  m_FixedBox_t WHERE Moid ='" & lbMoid.Text.Trim() & "' AND Closethebox ='N'"
                Dim dtv As DataTable = DbOperateUtils.GetDataTable(sql)
                Number.Text = dtv.Rows(0)(0).ToString
                sql = "SELECT box,BoxanswerQty,BoxalreadyQty FROM  m_FixedBox_t WHERE Moid ='" & lbMoid.Text.Trim() & "' AND Closethebox ='Y'"
                dtv = DbOperateUtils.GetDataTable(sql)
                If dtv.Rows.Count > 0 Then
                    txtStyle.Text = dt.Rows(0)!box.ToString
                    boxqty.Text = dtv.Rows(0)!BoxanswerQty.ToString
                    Boxpretend.Text = dtv.Rows(0)!BoxalreadyQty.ToString
                    txtStyle.Enabled = False
                    txtStyle.ReadOnly = True
                    txtBarcode.Enabled = True
                    txtBarcode.ReadOnly = False
                    TextBoxUL1.Text = style(1)
                    txtBarcode.Focus()
                Else
                    txtBarcode.Enabled = False
                    txtBarcode.ReadOnly = True
                    txtStyle.Enabled = True
                    txtStyle.ReadOnly = False
                    Boxpretend.Text = "0"
                    txtStyle.Text = ""
                    txtStyle.Focus()
                End If

            Else
                TextBoxUL1.Text = style(1)
                txtStyle.Enabled = False
                txtStyle.ReadOnly = True
                txtBarcode.Enabled = True
                txtBarcode.ReadOnly = False
                txtStyle.Enabled = False
                txtStyle.ReadOnly = True
                txtBarcode.Focus()
            End If

        End If

    End Sub

    Private Sub SaveScanData()
        Try
            Dim strSql As String
            strSql = "update m_FixedCodeSet_t set scanqty=isnull(scanqty,0)+1 WHERE MOID='" & lbMoid.Text & "' "
            DbOperateUtils.ExecSQL(strSql)
            If box Then
                strSql = "SELECT BoxanswerQty,BoxalreadyQty FROM  m_FixedBox_t WHERE MOID='" & lbMoid.Text.Trim & "'AND box='" & txtStyle.Text.Trim & "' AND Closethebox='Y'"
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Return
                End If
                strSql = "update m_FixedBox_t set BoxalreadyQty=isnull(BoxalreadyQty,0)+1 WHERE MOID= '" & lbMoid.Text & "'   AND box='" & txtStyle.Text.Trim() & "' AND Closethebox='Y' "
                DbOperateUtils.ExecSQL(strSql)
                Boxpretend.Text = dt.Rows(0)(1).ToString
                If Int(Val(dt.Rows(0)(0))) - Int(Val(dt.Rows(0)(1))) = 0 Then
                    strSql = " update m_FixedBox_t set Closethebox='N'  WHERE MOID='" & lbMoid.Text.Trim & "'AND box='" & txtStyle.Text.Trim & "' AND Closethebox='Y'"
                    DbOperateUtils.ExecSQL(strSql)
                    strSql = "SELECT  boxeffective  FROM  m_FixedCodeSet_t WHERE Moid ='" & lbMoid.Text.Trim & "'"
                    dt = DbOperateUtils.GetDataTable(strSql)
                    Dim sql As String = "SELECT COUNT(box) FROM  m_FixedBox_t WHERE Moid ='" & lbMoid.Text.Trim() & "' AND Closethebox ='N'"
                    Dim dtv As DataTable = DbOperateUtils.GetDataTable(sql)
                    Number.Text = dtv.Rows(0)(0).ToString
                    Boxpretend.Text = "0"
                    If dt.Rows(0)(0) = "Y" Then
                        txtBarcode.Enabled = False
                        txtBarcode.ReadOnly = True
                        TextBoxUL1.Text = style(0)
                        txtStyle.Text = ""
                        txtStyle.Enabled = True
                        txtStyle.ReadOnly = False
                        txtStyle.Focus()
                    Else
                        txtStyle.Enabled = False
                        txtStyle.ReadOnly = True
                        txtStyle.Text = ""
                        txtBarcode.Enabled = False
                        txtBarcode.ReadOnly = True
                        TextBoxUL1.Focus()
                    End If

                End If
            End If


        Catch ex As Exception
            Throw ex
        End Try
      
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub txtStyle_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtStyle.PreviewKeyDown
        If e.KeyValue = 13 Then
            If TextBoxUL1.Text.Trim() = txtStyle.Text.Trim() Then
                Dim SQL = "SELECT MoQty-ScanQty-BoxQty,BoxQty FROM  m_FixedCodeSet_t WHERE Moid ='" & lbMoid.Text & "'"
                Dim DAT As DataTable = DbOperateUtils.GetDataTable(SQL)
                If Int(Val(DAT.Rows(0)(0))) >= 0 Then
                    SQL = "INSERT INTO m_FixedBox_t(MOID,box,BoxanswerQty,BoxalreadyQty,Closethebox,USID) VALUES('" & lbMoid.Text.Trim() & "','" & txtStyle.Text.Trim() & "','" & DAT.Rows(0)(1) & "','0','Y','" & SysMessageClass.UseId & "' )"
                    DbOperateUtils.ExecSQL(SQL)
                    TextBoxUL1.Text = style(1)
                    txtBarcode.Enabled = True
                    txtBarcode.ReadOnly = False
                    txtStyle.Enabled = False
                    txtStyle.ReadOnly = True
                    txtBarcode.Focus()
                    ShowInfoMsg(True, "PASS,请扫描产品条码")
                Else
                    ShowInfoMsg(False, "FAIL,装箱数量大于工单量!")
                    ShowMsg(False, txtStyle.Text)
                    txtStyle.Text = ""
                    Return
                End If
               
            Else
                ShowInfoMsg(False, "FAIL,扫描样式不符!")
                ShowMsg(False, txtStyle.Text)
                txtStyle.Text = ""
                Return
            End If

        End If

    End Sub
End Class