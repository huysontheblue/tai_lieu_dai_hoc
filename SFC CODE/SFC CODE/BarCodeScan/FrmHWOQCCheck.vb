Imports MainFrame
Imports System.Text
Imports MainFrame.SysCheckData

Public Class FrmHWOQCCheck
    Public scanSetting As New ScanSetting
    Private Sub FrmHWOQCCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click
        Dim strSQL As String = ""
        scanSetting.FormName = Me.Name

        Try
            Dim FrmScanSet As New FrmHWOQCSet(scanSetting)
            FrmScanSet.Owner = Me
            FrmScanSet.ShowDialog()
            If FrmScanSet.OQCSetting.CodeRuleID = "" Then
                SetMessage("FAIL", "请设置扫描参数")
                Exit Sub
            End If
            lblNo.Text = FrmScanSet.OQCSetting.CodeRuleID
            lblPartID.Text = FrmScanSet.OQCSetting.PartidStr
            lblLine.Text = FrmScanSet.OQCSetting.LineStr
            lblTotal.Text = FrmScanSet.OQCSetting.MoTotalScanQty
            lblSIQty.Text = FrmScanSet.OQCSetting.PartPackQty
            LoadItemData()
            SetMessage("PASS", "设置成功!")
        Catch ex As Exception
            ' FrmScanSet.OQCSetting.CodeRuleID = ""
            SetMessage("FAIL", "设置扫描参数异常,请重新设置")
        End Try

    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim strSQL As StringBuilder = New StringBuilder
        Dim sino As String = lblNo.Text
        Dim partid As String = lblPartID.Text
        Dim lineid As String = lblLine.Text
        Dim cartonid As String = txtPackingBoxCartonCode.Text.Trim.ToUpper
        Dim ppid As String = txtPackingBoxBarcode.Text.Trim.ToUpper
        Dim userid As String = VbCommClass.VbCommClass.UseId
        Try
            strSQL.AppendLine("DECLARE @SINO varchar(20)='" + sino + "', @ScanType varchar(5)='3',@ScanQty int =0, @Msg nvarchar(250), @RetVal varchar(5) ")
            strSQL.AppendLine("EXECUTE  [dbo].[EXEC_HWSIScan]  @SINO  ,@ScanType ,'" + partid + "' ,'" + lineid + "','" + userid + "','" + ppid + "','" + cartonid + "'" & _
              " ,@ScanQty OUTPUT,@Msg OUTPUT  ,@RetVal OUTPUT")
            strSQL.AppendLine(" SELECT @RetVal ,@Msg ,@ScanQty ")
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        txtPackingBoxBarcode.Focus()
                        SetMessage("FAIL", dt.Rows(0)(1).ToString)
                        Exit Sub
                    Case "1" 'SINO
                        Me.txtPackingBoxCartonCode.Focus()
                        Clear()
                        SetMessage("PASS", "结束批成功,设置下一批次!")
                        dgvUnPackBox.Rows.Clear()
                End Select
            End If
        Catch
            MessageUtils.ShowInformation("数据库连接异常,请检查网络后,重新确认数据扫描!")
        End Try
    End Sub
    Private Sub LoadItemData()
        Dim strSQL As String =
        "SELECT  CARTONID, PPID,CREATETIME,CreateUser FROM m_HWSIScan_t " &
        "  WHERE SINO='{0}' ORDER BY CREATETIME DESC"
        strSQL = String.Format(strSQL, lblNo.Text)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Dim orderIndex As Integer = 0
        dgvUnPackBox.Rows.Clear()
        lblScanQty.Text = dt.Rows.Count
        For iIndex As Integer = 0 To dt.Rows.Count - 1
            dgvUnPackBox.Rows.Add(dt.Rows(iIndex)!CARTONID, dt.Rows(iIndex)!PPID,
                                  dt.Rows(iIndex)!CreateUser, dt.Rows(iIndex)!CREATETIME)
        Next
        dgvUnPackBox.AutoResizeColumns()
        If dt.Rows.Count > 0 Then
            txtPackingBoxCartonCode.Text = dt.Rows(0)("CARTONID").ToString
            txtPackingBoxBarcode.Focus()
        End If
    End Sub
    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            LabResult.Text = "FAIL"
            lblMessage.Text = message
            LabResult.ForeColor = Color.Crimson
            lblMessage.ForeColor = Color.Crimson
        Else
            LabResult.Text = "PASS"
            lblMessage.Text = message
            LabResult.ForeColor = Color.FromArgb(0, 192, 0)
            lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub
    Private Sub CartonIDScanHandle()
        Dim strSQL As StringBuilder = New StringBuilder
        Dim sino As String = lblNo.Text
        Dim partid As String = lblPartID.Text
        Dim lineid As String = lblLine.Text
        Dim cartonid As String = txtPackingBoxCartonCode.Text.Trim.ToUpper
        Dim userid As String = VbCommClass.VbCommClass.UseId
        If lblNo.Text = "" Then
            SetMessage("FAIL", "请先设置批次!")
            Exit Sub
        End If
        If txtPackingBoxCartonCode.Text.Trim = "" Then
            SetMessage("FAIL", "箱号不能为空!")
            Exit Sub
        End If
        Try
            strSQL.AppendLine("DECLARE @SINO varchar(20)='" + sino + "', @ScanType varchar(5)='1',@ScanQty int =0, @Msg nvarchar(250), @RetVal varchar(5) ")
            strSQL.AppendLine("EXECUTE  [dbo].[EXEC_HWSIScan]  @SINO  ,@ScanType ,'" + partid + "' ,'" + lineid + "','" + userid + "','','" + cartonid + "'" & _
              ",@ScanQty OUTPUT,@Msg OUTPUT  ,@RetVal OUTPUT")
            strSQL.AppendLine(" SELECT @RetVal ,@Msg ,@ScanQty ")
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        'SetMessage("FAIL", dt.Rows(0)(1).ToString)
                        WorkStantOption.ErrorStr = dt.Rows(0)(1).ToString
                        SetMessage("Fail", dt.Rows(0)(1).ToString)
                        WorkStantOption.BarCodeStr = cartonid
                        WorkStantOption.vMainBarCode = cartonid
                        ShowFrmScanErrPromptLock()
                        'SetMessage("PASS", "已解锁，请继续进行作业")

                        txtPackingBoxCartonCode.Text = ""
                        Exit Sub
                    Case "1" 'SINO
                        Me.txtPackingBoxBarcode.Focus()
                        SetMessage("PASS", dt.Rows(0)(1).ToString)
                        'LoadItemData()
                End Select
            End If
        Catch
            MessageUtils.ShowInformation("数据库连接异常,请检查网络后,重新确认数据扫描!")
        End Try
    End Sub
    Private Sub ShowFrmScanErrPromptLock()
        Dim FrmError As New FrmScanErrPrompt(scanSetting)
        FrmError.ShowDialog()
    End Sub
    Private Sub BarcodeIDScanHandle()
        Dim strSQL As StringBuilder = New StringBuilder
        Dim sino As String = lblNo.Text
        Dim partid As String = lblPartID.Text
        Dim lineid As String = lblLine.Text
        Dim cartonid As String = txtPackingBoxCartonCode.Text.Trim.ToUpper
        Dim ppid As String = txtPackingBoxBarcode.Text.Trim.ToUpper
        Dim userid As String = VbCommClass.VbCommClass.UseId
        If lblNo.Text = "" Then
            SetMessage("FAIL", "请先设置批次!")
            Exit Sub
        End If
        If txtPackingBoxCartonCode.Text.Trim = "" Then
            SetMessage("FAIL", "箱号不能为空!")
            Exit Sub
        End If
        If txtPackingBoxBarcode.Text.Trim = "" Then
            SetMessage("FAIL", "条码不能为空!")
            Exit Sub
        End If
        Try
            strSQL.AppendLine("DECLARE @SINO varchar(20)='" + sino + "', @ScanType varchar(5)='2',@ScanQty int =0, @Msg nvarchar(250), @RetVal varchar(5) ")
            strSQL.AppendLine("EXECUTE  [dbo].[EXEC_HWSIScan]  @SINO  ,@ScanType ,'" + partid + "' ,'" + lineid + "','" + userid + "','" + ppid + "','" + cartonid + "'" & _
              ",@ScanQty OUTPUT,@Msg OUTPUT  ,@RetVal OUTPUT ")
            strSQL.AppendLine(" SELECT @RetVal ,@Msg ,@ScanQty ")
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        'SetMessage("FAIL", dt.Rows(0)(1).ToString)
                        WorkStantOption.ErrorStr = dt.Rows(0)(1).ToString
                        SetMessage("Fail", dt.Rows(0)(1).ToString)
                        WorkStantOption.BarCodeStr = cartonid
                        WorkStantOption.vMainBarCode = cartonid
                        ShowFrmScanErrPromptLock()
                        txtPackingBoxBarcode.Text = ""
                        Me.txtPackingBoxBarcode.Focus()
                        Exit Sub
                    Case "1" 'SINO
                        Me.txtPackingBoxBarcode.Focus()
                        LoadItemData()
                        SetMessage("PASS", dt.Rows(0)(1).ToString)
                        If lblSIQty.Text = lblScanQty.Text Then
                            SetMessage("PASS", "抽检数量已满,请结束!")
                        End If
                        txtPackingBoxCartonCode.SelectAll()
                        txtPackingBoxBarcode.Text = ""
                        txtPackingBoxBarcode.Focus()
                End Select
            End If
        Catch
            txtPackingBoxBarcode.Text = ""
            MessageUtils.ShowInformation("数据库连接异常,请检查网络后,重新确认数据扫描!")
        End Try
    End Sub
    Private Sub Clear()
        txtPackingBoxCartonCode.Text = ""
        txtPackingBoxBarcode.Text = ""
        lblNo.Text = ""
        lblSIQty.Text = "0"
        lblPartID.Text = ""
        lblLine.Text = ""
        lblTotal.Text = ""
        lblScanQty.Text = "0"
    End Sub

   

    Private Sub txtPackingBoxBarcode_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtPackingBoxBarcode.MouseDoubleClick
        txtPackingBoxBarcode.SelectAll()
    End Sub
    

    Private Sub txtPackingBoxCartonCode_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        txtPackingBoxCartonCode.SelectAll()
    End Sub

    Private Sub txtPackingBoxCartonCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPackingBoxCartonCode.KeyPress

        If e.KeyChar <> Chr(13) Then
            ''禁止用键盘手动输入
            Dim tempDt As DateTime = DateTime.Now
            Dim ts As TimeSpan = tempDt.Subtract(_dt)
            If (ts.Milliseconds > 50) Then
                txtPackingBoxCartonCode.Text = ""
            End If
            _dt = tempDt
        Else
            CartonIDScanHandle()
            Me.ActiveControl = txtPackingBoxBarcode
            Me.txtPackingBoxBarcode.Focus()
        End If

    End Sub
    Private _dt As DateTime = DateTime.Now
    Private Sub txtPackingBoxBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPackingBoxBarcode.KeyPress

        If e.KeyChar <> Chr(13) Then
            ''禁止用键盘手动输入
            Dim tempDt As DateTime = DateTime.Now
            Dim ts As TimeSpan = tempDt.Subtract(_dt)
            If (ts.Milliseconds > 50) Then
                txtPackingBoxBarcode.Text = ""
            End If
            _dt = tempDt
        Else
            BarcodeIDScanHandle()
            Me.ActiveControl = txtPackingBoxBarcode
            Me.txtPackingBoxBarcode.Focus()
        End If

    End Sub
End Class