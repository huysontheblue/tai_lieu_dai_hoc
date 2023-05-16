#Region "Imports"
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text.RegularExpressions

#End Region

Public Class FrmSetScan

#Region "窗體變量"

    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim IsCustPart As Boolean
    Dim IsPrtPacking As Boolean
    Dim IsScanPallet As Boolean
    Dim PalletID As String
    Dim IsFull As Boolean = False '棧板是否裝滿
    Dim PackArray As New SysMessageClass.PrtStructure
    Public m_stdPN As DataTable
    Public scanSetting As New ScanSetting 'add by 马跃平 2018-03-20

    Private Enum BarCodeMode
        Child = 0
        Parent
    End Enum


#End Region

#Region "窗體事件"

    Private Sub FrmWorkStantScan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                ' BnScanSet_Click(sender, e)
                ''Case Keys.F2
                ''    toolCa_Click(sender, e)
            Case Keys.Alt + Keys.X
                Me.Close()
        End Select
    End Sub


    Private Sub FrmSetScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)

        TxtBarCode.Enabled = False
        LblMainBarCode.Text = ""
        LabResult.Text = ""
        lblMessage.Text = "请刷入袋子条码！"
        ToolUsename.Text = SysMessageClass.UseName
        Me.lblChildPN.Text = ""
        Me.TxtLineID.Text = ""
        Me.lblWeek.Visible = False
    End Sub

#End Region

#Region "掃描設置/返回按鈕事件"


    Private Sub BnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        ' LocalData = Nothing
        Me.Close()
    End Sub

#End Region

#Region "查看明细记录"
    Private Sub BnScanRecord_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        Dim FrmOpenLock As New FrmSetLock
        ' FrmNewShareSetForm.vStationType = "P"
        FrmOpenLock.ShowDialog()

        If CartonScanOption.CheckStr = True Then
            If String.IsNullOrEmpty(Me.txtPackBarcode.Text) Then
                MessageBox.Show("请先刷入包装袋条码!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Using frm As New FrmScanRecord(Me.txtPackBarcode.Text.Trim, Me.TxtMoId.Text.Trim)
                frm.m_strPPartID = Me.TxtPartid.Text.Trim
                frm.m_iChildPNCount = Val(Me.TxtChildPNQty.Text)
                frm.m_strPVersion = Me.txtPVersion.Text.Trim
                frm.ShowDialog()
            End Using
        End If
    End Sub
#End Region

#Region "获取子件掃描記錄"
    Private Sub GetScanItem(ByVal PPartID As String)
        Dim orderIndex As Integer = 0
        Dim Dt As SqlDataReader = Nothing
        Dim lsSQL As String = String.Empty
        'Add clear first, cq 20160608
        If Me.DGridBarCode.Rows.Count > 0 Then
            Me.DGridBarCode.Rows.Clear()
        End If
        lsSQL = " SELECT   PartID, Qty, ScanedQty,UserID, intime  FROM m_SetScanD_t " & _
                " Where PPartID='" & PPartID & "'and PackBarcode='" & Me.txtPackBarcode.Text.Trim() & "' ORDER BY PartID"
        Dt = Conn.GetDataReader(lsSQL)
        While (Dt.Read())
            DGridBarCode.Rows.Add(Dt!PartID, Dt!Qty, Dt!ScanedQty, Dt!UserID, Dt!intime)
        End While
        DGridBarCode.AutoResizeColumns()
        Dt.Close()
        Dt.Dispose()
        Conn.PubConnection.Close()
    End Sub

#End Region

#Region "子件條碼掃描"

    Private Sub StandChildScan()
        Dim Sqlstr As String = "", BarCode As String = String.Empty
        Dim blnChildBarcode As Boolean = False
        Dim strChildPN As String = String.Empty
        Dim o_blnSingleChildFinish As Boolean = False
        Dim o_blnFinishSet As Boolean = False
        Dim o_blnUniversalCode As Boolean = False
        Dim strchildPNofMO As String = String.Empty
        Dim o_blnGroup As Boolean = False
        Dim o_strGroupCPartID As String = String.Empty
        Dim o_strGroupMPartID As String = String.Empty

        If String.IsNullOrEmpty(TxtBarCode.Text) Then
            MessageBox.Show("子件條碼不能為空！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If
        BarCode = Me.TxtBarCode.Text.Replace(vbNewLine, "").Trim()

        If String.IsNullOrEmpty(Me.TxtMoId.Text) Then
            SetMessage("E", "Error, 请先刷入包装袋子的二维码！")
            Me.txtPackBarcode.Focus()
            Exit Sub
        End If

        'Add by cq 20160704
        If BarCode.IndexOf("CODE") >= 0 Then
            o_blnUniversalCode = True
        End If


        'maybe is a pack barcode, cq 20160818
        If TxtBarCode.Text.Trim.Length = Me.txtPackBarcode.Text.Trim.Length Then
            If SetScan.GetPNByBarcode(Me.TxtBarCode.Text).Length <> Me.lblChildPN.Text.Trim().Length AndAlso Me.lblChildPN.Text.Trim().Length > 0 Then
                Me.txtPackBarcode.Text = Me.TxtBarCode.Text
                Call PackBarCodeProcess(True)
                Exit Sub
            End If
        End If


        If o_blnUniversalCode = False Then
            Me.lblChildPN.Text = SetScan.GetChildPNByBarcode(BarCode, strchildPNofMO)
            'If strchildPNofMO.Substring(0, strchildPNofMO.LastIndexOf("-")) <> Me.TxtMoId.Text.Trim Then
            '    SetMessage("E", "Error, 该条码错误,属于其他工单！")
            '    Me.TxtBarCode.Clear()
            '    Me.TxtBarCode.Select()
            '    PlaySimpleSound(1)
            '    Exit Sub
            'End If
        Else
            Me.lblChildPN.Text = SetScan.GetChildPNByWNBarcode(Me.TxtPartid.Text, Me.TxtMoId.Text, Me.txtPackBarcode.Text)
        End If

 
        Me.LblChildFinishQty.Text = SetScan.GetFinishChildPNQty(Me.TxtPartid.Text, Me.txtPackBarcode.Text)

        If String.IsNullOrEmpty(Me.lblChildPN.Text) Then
            SetMessage("E", "Error, 该条码错误,不能找到子料号！")
            Me.TxtBarCode.Clear()
            Me.TxtBarCode.Select()
            PlaySimpleSound(1)
            Exit Sub
        End If

        'Check whether is the need child PN
        If m_stdPN.Select("PartID='" & Me.lblChildPN.Text & "'").Length <= 0 Then
            SetMessage("E", "Error, 刷入的正确的子料号条码！")
            PlaySimpleSound(1)
            Me.TxtBarCode.Clear()
            Me.TxtBarCode.Select()
            Exit Sub
        End If

        'Check whether is repeat scan
        If Not o_blnUniversalCode Then
            If SetScan.IsAlreadyScaned(Me.TxtBarCode.Text.Trim()) Then
                WorkStantOption.ErrorStr = "刷入的该子件已经被扫描过！"
                WorkStantOption.BarCodeStr = txtPackBarcode.Text
                WorkStantOption.vMainBarCode = TxtBarCode.Text
                SetMessage("E", "Error, 刷入的该子件已经被扫描过！")
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                PlaySimpleSound(1)
                Me.TxtBarCode.Clear()
                Me.TxtBarCode.Select()
                Exit Sub
            End If
        End If

        'Check pack barcode must have value, cq 20160706
        If String.IsNullOrEmpty(Me.txtPackBarcode.Text.Trim()) Then
            SetMessage("E", "Error, 包装袋条码不能为空！")
            PlaySimpleSound(1)
            Me.TxtBarCode.Clear()
            Me.txtPackBarcode.Select()
            Exit Sub
        End If

        'Scan is a child Barcode
        Call SetBodyValue()

        o_blnGroup = SetScan.IsGroup(Me.TxtPartid.Text, Me.lblChildPN.Text, o_strGroupCPartID)

        Try

            '周别 检查, cq 20160711
            If Not String.IsNullOrEmpty(Me.lblWeek.Text) Then
                ' Me.label1.Text = code.Substring(code.LastIndexOf("S") - 2, 2)
                If Me.lblWeek.Text.Trim() <> Me.TxtBarCode.Text.Trim().Substring(Me.TxtBarCode.Text.Trim().LastIndexOf("S") - 2, 2) Then
                    SetMessage("E", "Error, 刷入的该子件的条码周期不一致,请检查！")
                    WorkStantOption.ErrorStr = "刷入的该子件的条码周期不一致,请检查！"
                    WorkStantOption.BarCodeStr = txtPackBarcode.Text
                    WorkStantOption.vMainBarCode = TxtBarCode.Text
                    ShowFrmScanErrPrompt()
                    SetMessage("PASS", "已解锁，请继续进行作业")
                    Me.TxtBarCode.Select()
                    Me.TxtBarCode.Text = ""
                    '0.ok, 1.fail
                    PlaySimpleSound(1)
                    Exit Sub
                End If
            Else
                'Pass
            End If

            '配置数 检查
            If Val(Me.LblCurrQty.Text) + 1 > Val(Me.LblChildSetQty.Text) Then
                'SetMessage("E", "Error, 刷入的该子件数量不能超过配置数！")
                'add by 马跃平 2018-03-20
                WorkStantOption.BarCodeStr = txtPackBarcode.Text
                WorkStantOption.vMainBarCode = TxtBarCode.Text
                WorkStantOption.ErrorStr = "刷入的该子件数量不能超过配置数!"
                SetMessage("FAIL", "刷入的该子件数量不能超过配置数")
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                'end
                Me.TxtBarCode.Select()
                Me.TxtBarCode.Text = ""
                '0.ok, 1.fail
                PlaySimpleSound(1)
                Exit Sub
            Else
                Me.LblCurrQty.Text = CStr(Val(Me.LblCurrQty.Text) + 1)
            End If

            'Judge whether finished ChildPN, 该子件完成否？
            If Val(Me.LblChildSetQty.Text) = Me.LblCurrQty.Text Then
                o_blnSingleChildFinish = True
                Me.LblChildFinishQty.Text = Val(Me.LblChildFinishQty.Text) + 1
            Else
                'Add by cq 20160607
                If SetScan.IsByPassChildPN(Me.lblChildPN.Text, Me.txtPVersion.Text.Trim) Then
                    'Auto set finish
                    o_blnSingleChildFinish = True
                    Me.LblCurrQty.Text = CStr(Val(Me.LblChildSetQty.Text))
                    Me.LblChildFinishQty.Text = Val(Me.LblChildFinishQty.Text) + 1
                ElseIf o_blnUniversalCode Then
                    'Auto set finish
                    o_blnSingleChildFinish = True
                    Me.LblCurrQty.Text = CStr(Val(Me.LblChildSetQty.Text))
                    Me.LblChildFinishQty.Text = Val(Me.LblChildFinishQty.Text) + 1
                End If
            End If

            'check when is group ,cq 20160711
            If o_blnGroup Then
                o_strGroupMPartID = Me.lblChildPN.Text
                Me.LblChildFinishQty.Text = Me.LblChildFinishQty.Text + o_strGroupCPartID.Split(",").Length
            End If

            'Judge whether finished whole set scan ?
            If Val(Me.LblChildFinishQty.Text) = Val(Me.TxtChildPNQty.Text) Then
                o_blnFinishSet = True
            End If

            'Update scan data to DB
            Call UpdateScanChild(o_blnFinishSet, o_strGroupCPartID)

            'Info the next scan 
            If (Not o_blnFinishSet) Then
                SetMessage("P", " 请继续扫描下一个子件条码")
                Me.TxtBarCode.Text = ""
                Me.TxtBarCode.Select()
                'Add by cq 20160707,refesh the data
                Call GetScanItem(Me.TxtPartid.Text)
            Else
                Me.TxtBarCode.Text = ""
                SetMessage("P", " PASS, 该袋子已经完成，请继续扫描下一个包装袋条码！")
                Me.txtPackBarcode.Text = ""
                Me.txtPackBarcode.Focus()
                Me.txtPackBarcode.Select()
            End If

        Catch ex As Exception
            PlaySimpleSound(1)
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            SysMessageClass.WriteErrLog(ex, Me.Name, "StandChildScan", "sys")
            Exit Sub
        End Try
    End Sub

    Private Sub ShowFrmScanErrPrompt()
        Dim FrmError As New FrmScanErrPrompt
        FrmError.ShowDialog()
    End Sub
    Private Sub SetMessage(ByVal flag As String, ByVal msg As String)
        'Select Case flag
        '    Case "E"
        '        Me.lblMessage.ForeColor = Color.Red
        '    Case "W"
        '        Me.lblMessage.ForeColor = Color.Yellow
        '    Case Else
        '        Me.lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
        'End Select

        'Me.lblMessage.Text = msg
        'add by 马跃平 2018-03-20
        If flag.ToUpper = "FAIL" Or flag.ToUpper = "E" Then
            LabResult.Text = "FAIL"
            lblMessage.Text = msg
            LabResult.ForeColor = Color.Crimson
            lblMessage.ForeColor = Color.Crimson
        Else
            LabResult.Text = "PASS"
            lblMessage.Text = msg
            LabResult.ForeColor = Color.FromArgb(0, 192, 0)
            lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub

    Private Sub SetBodyValue()
        Dim o_dtChildInfo As DataTable
        Try
            'Alreay scan qty
            o_dtChildInfo = SetScan.GetChildPNInfo(Me.lblChildPN.Text, Me.txtPackBarcode.Text.Trim())
            If Not IsNothing(o_dtChildInfo) AndAlso o_dtChildInfo.Rows.Count > 0 Then
                Me.LblCurrQty.Text = CStr(o_dtChildInfo.Rows(0).Item("ScanedQty"))
            Else
                Me.LblCurrQty.Text = "0"  'When first scan this child PN, already scaned qty = 0
            End If
            Me.LblChildSetQty.Text = SetScan.GetChildPNSetQty(Me.lblChildPN.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub UpdateScanChild(ByVal o_blnSetFinish As Boolean, ByVal o_strGroupCPartID As String)

        Dim o_strSQL As New StringBuilder
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            o_strSQL.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_SetScanD_t WHERE PartID ='" & Me.lblChildPN.Text.Trim & "'AND PackBarCode='" & Me.txtPackBarcode.Text.Trim & "'),0)=1 ")
            o_strSQL.Append("  Begin ")
            o_strSQL.Append("  UPDATE m_SetScanD_t SET ScanedQty=ISNULL(ScanedQty,0)+1 ,")
            o_strSQL.Append("   sbarcode = sbarcode + ',' +'" & Me.TxtBarCode.Text.Trim & "' ")
            o_strSQL.Append("  Where PartID ='" & Me.lblChildPN.Text.Trim & "' AND PackBarCode='" & Me.txtPackBarcode.Text.Trim & "' ")
            o_strSQL.Append(" End")
            o_strSQL.Append(" Else ")
            o_strSQL.Append("  Begin")
            o_strSQL.Append(" Insert into m_SetScanD_t(PartID, PPartID, Qty, ScanedQty,Intime,UserID,PackBarcode,sbarcode)")
            o_strSQL.Append(" Values(")
            o_strSQL.Append(" '" & Me.lblChildPN.Text.Trim & "', '" & Me.TxtPartid.Text.Trim & "', '" & Me.LblChildSetQty.Text.Trim & "',")
            o_strSQL.Append("'" & Val(Me.LblCurrQty.Text.Trim) & "',GetDate(),'" & VbCommClass.VbCommClass.UseId & "',")
            o_strSQL.Append("'" & Me.txtPackBarcode.Text.Trim & "','" & Me.TxtBarCode.Text.Trim & "')")
            o_strSQL.Append(" End")

            If Not String.IsNullOrEmpty(o_strGroupCPartID) Then
                For Each strPN As String In o_strGroupCPartID.Split(",")
                    o_strSQL.Append(" INSERT m_SetScanD_t (PartID, PPartID, Qty, ScanedQty,Intime, UserID, Packbarcode, sbarcode)")
                    o_strSQL.Append(" SELECT '" & strPN & "' PartID, PPartID, Qty, ScanedQty,Intime, UserID, Packbarcode, sbarcode ")
                    o_strSQL.Append(" FROM m_SetScanD_t WHERE partid ='" & Me.lblChildPN.Text.Trim & "'  ")
                    o_strSQL.Append(" AND PackBarcode='" & Me.txtPackBarcode.Text.Trim & "'")
                Next
            End If

            If o_blnSetFinish Then
                o_strSQL.Append("  UPDATE m_SetScanM_t SET Status=1, FinishTime = getdate()")
                o_strSQL.Append("  WHERE PartID ='" & Me.TxtPartid.Text.Trim & "' ")
                o_strSQL.Append("  AND PackBarCode='" & Me.txtPackBarcode.Text.Trim & "' ")
            End If

            sConn.ExecSql(o_strSQL.ToString())

        Catch ex As Exception
            ' Throw ex
            SysMessageClass.WriteErrLog(ex, "FrmSetScan", "UpdateScanChild", "sys")
        Finally
            sConn = Nothing
        End Try
    End Sub

    Private Function SetHeaderValue(ByVal BarCode As String) As Boolean

        If String.IsNullOrEmpty(Me.TxtChildPNQty.Text) Then
            Me.TxtChildPNQty.Text = SetScan.GetChildPNCount(Me.TxtMoId.Text, m_stdPN)
        End If
        Return True
    End Function

#End Region

#Region "聲音播放"
    Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        If 1 = 1 Then ' (Me.chbMessage.Checked) Then
            Select Case PassOrNg
                Case 0
                    My.Computer.Audio.Play(My.Resources.ok_zhcn, AudioPlayMode.Background)
                Case 1
                    My.Computer.Audio.Play(My.Resources.fail_zhcn, AudioPlayMode.Background)
                Case 2
                    ' My.Computer.Audio.Play(My.Resources.Resource1.chimes, AudioPlayMode.Background)
            End Select
        End If
    End Sub
#End Region

    Private Sub TxtBarCode_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TxtBarCode.PreviewKeyDown
        If e.KeyValue = 13 Then
            StandChildScan()
        End If
    End Sub


#Region "包装袋处理"
    Private Sub txtPackBarcode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtPackBarcode.PreviewKeyDown
        If e.KeyValue = 13 Then
            PackBarCodeProcess()
        End If
    End Sub

    Private Sub PackBarCodeProcess(Optional ByVal o_blnAutoPackMode As Boolean = False)
        Dim o_strUnfinishPack As String = String.Empty
        'get MOId
        Me.TxtMoId.Text = SetScan.GetPMOByPackBarcode(Me.txtPackBarcode.Text.Trim, Me.TxtPartid.Text, Me.TxtMOQty.Text, Me.TxtLineID.Text)

        If String.IsNullOrEmpty(Me.TxtMoId.Text) Then
            SetMessage("E", "Error! 刷入的条码错误，找不到工单")
            Me.txtPackBarcode.Text = ""
            Me.txtPackBarcode.Focus()
            Exit Sub
        End If
        Me.TxtChildPNQty.Text = SetScan.GetChildPNCount(Me.TxtMoId.Text, m_stdPN)

        If Val(Me.TxtChildPNQty.Text) <= 0 Then
            Me.txtPackBarcode.Focus()
            SetMessage("E", "Error! 刷入的条码错误，该工单下面没有子件！")
            Me.txtPackBarcode.Text = ""
            Exit Sub
        End If

        If Me.chkUnfinish.Checked = True Then
            'check whether exist not finish pack ?
            If SetScan.IsExistUnfinshPack(Me.txtPackBarcode.Text.Trim, o_strUnfinishPack) Then
                If MessageUtils.ShowConfirm("存在未完成的包裝袋:[" & o_strUnfinishPack & "],是否先扫描其它包装袋 ?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                    'do nothing
                Else
                    SetMessage("W", "存在未完成的包裝袋:[" & o_strUnfinishPack & "]！")
                    Me.txtPackBarcode.Text = ""
                    Me.txtPackBarcode.Focus()
                    Exit Sub
                End If
            End If
        End If
        '获取该父工单的子件完成情况
        Me.LblChildFinishQty.Text = SetScan.GetFinishChildPNQty(Me.TxtPartid.Text, Me.txtPackBarcode.Text)

        'Me.txtPVersion.Text = SetScan.GetPPartIDVersion(Me.TxtPartid.Text)
        Call SetHeaderValue()

        If Val(Me.LblChildFinishQty.Text) > 0 Then
            Call GetScanItem(Me.TxtPartid.Text)
        End If

        If Val(Me.TxtChildPNQty.Text) = Val(Me.LblChildFinishQty.Text) Then
            SetMessage("P", "该包装袋的子件已经扫描完成,请更换包装袋！")
            Me.txtPackBarcode.Text = ""
            Me.ActiveControl = Me.txtPackBarcode
            Me.txtPackBarcode.Focus()
            Exit Sub
        Else
            Call InsertPackRecord()
        End If
        If o_blnAutoPackMode Then
            Me.TxtBarCode.Text = ""
        End If
        Me.TxtBarCode.Enabled = True
        Me.TxtBarCode.Focus()
        SetMessage("PASS", "请刷入子件条码！")
    End Sub

#End Region


    Private Sub SetHeaderValue()
        Dim code As String = String.Empty
        Dim strVersion As String = String.Empty
        'cq 20160711 ' GetPPartIDVersion ==> GetVerFromTiptop
        strVersion = SetScan.GetVerFromTiptop(Me.TxtPartid.Text)
        If IncludeChinese(strVersion) Then
            strVersion = "NA"
        End If
        Me.txtPVersion.Text = strVersion.Trim()

        Me.TxtFinishQty.Text = SetScan.GetMOFinishPackQty(Me.TxtMoId.Text)

        'cq 20160711,1904091308/Z00A2R1627S001196
        code = Me.txtPackBarcode.Text.Trim()
        If code.LastIndexOf("S") >= 0 Then
            Me.lblWeek.Text = code.Substring(code.LastIndexOf("S") - 2, 2)
        ElseIf code.LastIndexOf("Q") >= 0 Then
            Me.lblWeek.Text = code.Substring(code.LastIndexOf("Q") - 2, 2)
        End If

    End Sub


    Private Function IncludeChinese(ByVal str As String) As Boolean
        Dim regex As Regex = New Regex("[\u4e00-\u9fa5]")

        If regex.IsMatch(str) Then
            IncludeChinese = True
        Else
            IncludeChinese = False
        End If
        Return IncludeChinese
    End Function

    Private Sub InsertPackRecord()
        Dim o_strSQL As New StringBuilder
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            o_strSQL.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_SetScanM_t ")
            o_strSQL.Append("   WHERE PackBarCode ='" & Me.txtPackBarcode.Text.Trim & "' AND Status='0'),0)=0 ")
            o_strSQL.Append("  Begin ")
            o_strSQL.Append(" INSERT INTO m_SetScanM_t(PartID, Status,Intime,UserID,PackBarCode,MOID,LINEID)")
            o_strSQL.Append(" Values(")
            o_strSQL.Append(" '" & Me.TxtPartid.Text.Trim & "', '0', getdate(),")
            o_strSQL.Append(" '" & VbCommClass.VbCommClass.UseId & "', '" & Me.txtPackBarcode.Text.Trim() & "', ")
            o_strSQL.Append(" '" & Me.TxtMoId.Text.Trim & "','" & Me.TxtLineID.Text.Trim & "')")
            o_strSQL.Append(" End")

            sConn.ExecSql(o_strSQL.ToString())

        Catch ex As Exception
            Throw ex
        Finally
            sConn = Nothing
        End Try
    End Sub

    Private Sub ToolGroupMaintain_Click(sender As Object, e As EventArgs) Handles ToolGroupMaintain.Click

        'Dim FrmOpenLock As New FrmSetLock
        '' FrmNewShareSetForm.vStationType = "P"
        'FrmOpenLock.ShowDialog()

        ' If CartonScanOption.CheckStr = True Then
        If String.IsNullOrEmpty(Me.txtPackBarcode.Text) Then
            MessageBox.Show("请先刷入包装袋条码!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Using frm As New FrmSetPNGroup(Me.txtPackBarcode.Text, Me.TxtMoId.Text)
            frm.m_strPPartID = Me.TxtPartid.Text.Trim
            frm.m_iChildPNCount = Val(Me.TxtChildPNQty.Text)
            frm.m_strPVersion = Me.txtPVersion.Text.Trim
            frm.ShowDialog()
        End Using
        ' End If

    End Sub
End Class