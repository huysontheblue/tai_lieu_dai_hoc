
'--包装检查
'--Create by :　马锋
'--Create date :　2016/08/29
'--更新者：田玉琳
'--更新日期：2017/05/05
'--更新内容：1：可以设置工单，不用手敲;2：箱包装扫描可以检查
'--Update date :  
'--Ver : V01

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Drawing.Printing
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD
Imports MainFrame

#End Region

Public Class FrmPackingCheck

#Region "窗體變量"

    Public scanSetting As New ScanSetting
#End Region

#Region "窗体事件"

    Private Sub FrmPackingCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.ActiveControl = Me.txtCartonID
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常!", False)
        End Try
    End Sub

#End Region

#Region "菜单事件"

    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click
        Try
            Dim strSQL As String = ""
            scanSetting.FormName = Me.Name

            Dim FrmOpenLock As New FrmSetLock
            FrmNewShareSetForm.vStationType = "P"
            FrmOpenLock.ShowDialog()

            If CartonScanOption.CheckStr = True Then
                Dim FrmScanSet As New FrmNewShareSetForm(scanSetting)
                FrmScanSet.Owner = Me
                FrmScanSet.ShowDialog()

                If scanSetting.IsExitFlag = True Then
                    scanSetting.MoidStr = ""
                    txtMoId.Text = String.Empty
                    TxtLineId.Text = String.Empty
                    lblMessage.ForeColor = Color.Red
                    lblMessage.Text = "请设置扫描参数"
                    Exit Sub
                End If

                Me.lblMoId.Text = scanSetting.MoidStr           ''工單
                Me.txtMoId.Text = scanSetting.MoidStr           ''工單
                Me.lblPartid.Text = scanSetting.PartidStr ''料件編號
            End If

        Catch ex As Exception
            SetMessage(Me.lblMessage, "设置异常!", False)
        End Try
    End Sub

    Private Sub toolRemove_Click(sender As Object, e As EventArgs) Handles toolRemove.Click
        SetMessage(Me.lblMessage, "", False)
        Try
            Me.LblPackQty.Text = "0"
            Me.LblCurrQty.Text = "0"
            Me.txtBarCode.Text = ""
            Me.txtCartonID.Text = ""
            Me.txtPalletID.Text = ""
            Me.lblCartonQty.Text = "0"
            Me.LblCurrCarQty.Text = "0"
            Me.lblMoId.Text = ""
            Me.lblPartid.Text = ""
            Me.dgvBarcode.DataSource = Nothing
            Me.dgvBarcode.Rows.Clear()
            chkDisplay_CheckedChanged(Nothing, Nothing)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "清空异常!", False)
        End Try
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#End Region

#Region "控件事件"

    Private Sub chkDisplay_CheckedChanged(sender As Object, e As EventArgs) Handles chkCartonDisplay.CheckedChanged, chkPallet.CheckedChanged
        Try
            If (Me.chkPallet.Checked) Then
                Me.txtPalletID.Enabled = True
                Me.txtPalletID.Text = ""
                Me.chkCartonDisplay.Checked = True
                Me.chkCartonDisplay.Enabled = False

                If (String.IsNullOrEmpty(Me.txtMoId.Text.Trim)) Then
                    Me.ActiveControl = Me.txtMoId
                Else
                    Me.ActiveControl = Me.txtPalletID
                End If
            Else
                Me.txtPalletID.Enabled = False
                Me.txtPalletID.Text = ""
                Me.chkCartonDisplay.Enabled = True
                If (Me.chkCartonDisplay.Checked) Then
                    Me.txtCartonID.Enabled = True
                    Me.txtCartonID.Text = ""
                    Me.txtBarCode.Text = ""
                    Me.ActiveControl = Me.txtCartonID
                Else
                    Me.txtCartonID.Enabled = False
                    Me.txtCartonID.Text = ""
                    Me.txtBarCode.Text = ""
                    Me.ActiveControl = Me.txtBarCode
                End If
            End If

        Catch ex As Exception
            SetMessage(Me.lblMessage, "设置异常!", False)
        End Try
    End Sub

    Private Sub txtMoId_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtMoId.PreviewKeyDown

        Try
            If e.KeyValue = 13 Then
                SetMessage(Me.lblMessage, "", False)
                If (String.IsNullOrEmpty(Me.txtMoId.Text.Trim)) Then
                    SetMessage(Me.lblMessage, "输入工单不能为空!", False)
                    Me.ActiveControl = Me.txtMoId
                End If
                Dim dt As DataTable = DbOperateUtils.GetDataTable("SELECT MOID FROM m_MAINMO_t WHERE MOID='" & Me.txtMoId.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    SetMessage(Me.lblMessage, "输入工单不存在!", False)
                    Me.txtMoId.Text = ""
                    Me.ActiveControl = Me.txtMoId
                Else
                    SetMessage(Me.lblMessage, "输入工单成功!", True)
                    chkDisplay_CheckedChanged(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "输入工单" & Me.txtMoId.Text.Trim & "异常!", False)
            Me.txtMoId.Text = ""
            Me.ActiveControl = Me.txtMoId
        End Try
    End Sub

    Private Sub txtBarCode_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtBarCode.PreviewKeyDown
        Try
            If e.KeyValue = 13 Then
                SetMessage(Me.lblMessage, "", False)
                If (String.IsNullOrEmpty(Me.txtBarCode.Text.Trim)) Then
                    SetMessage(Me.lblMessage, "FAIL:扫描包装条码不能为空!", False)
                    Me.txtBarCode.Text = ""
                    Me.ActiveControl = Me.txtBarCode
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtMoId.Text.Trim)) Then
                    SetMessage(Me.lblMessage, "FAIL:工单不能为空!", False)
                    Me.txtBarCode.Text = ""
                    Me.ActiveControl = Me.txtMoId
                    Exit Sub
                End If

                If (Me.chkCartonDisplay.Checked) Then
                    If (String.IsNullOrEmpty(Me.txtCartonID.Text.Trim)) Then
                        SetMessage(Me.lblMessage, "FAIL:扫描箱条码不能为空!", False)
                        Me.txtBarCode.Text = ""
                        Me.ActiveControl = Me.txtCartonID
                        Exit Sub
                    End If
                End If

                If (Me.dgvBarcode.Rows.Count > 0) Then
                    Dim strBarcodeTemp As String

                    For i As Int16 = 0 To Me.dgvBarcode.Rows.Count - 1
                        strBarcodeTemp = Me.dgvBarcode.Rows(i).Cells("Barcode").Value
                        If (strBarcodeTemp = Me.txtBarCode.Text.Trim) Then
                            If (Me.chkBarcodeSame.Checked) Then
                                SetMessage(Me.lblMessage, "PASS:扫描" & Me.txtBarCode.Text.Trim & "成功...!", False)
                                Me.txtBarCode.Text = ""
                                Exit Sub
                            Else
                                SetMessage(Me.lblMessage, "FAIL:包装条码" & Me.txtBarCode.Text.Trim & "已经扫描!", False)
                                scanSetting.BarCodeStr = Me.txtBarCode.Text.Trim
                                scanSetting.vMainBarCode = Me.txtBarCode.Text.Trim
                                scanSetting.ErrorStr = "FAIL:包装条码" & Me.txtBarCode.Text.Trim & "已经扫描!"
                                Dim FrmError As New FrmScanErrPrompt(scanSetting)
                                FrmError.ShowDialog()

                                Me.txtBarCode.Text = ""
                                Exit Sub
                            End If
                        End If
                    Next
                End If

                Dim strScanType, strCartonDisplay, strPalletSame, strCartonSame, strBarcodeSame As String
                strScanType = "1"
                strCartonDisplay = IIf(Me.chkCartonDisplay.Checked, "1", "0")
                strPalletSame = IIf(Me.chkPalletSame.Checked, "1", "0")
                strCartonSame = IIf(Me.chkCartonSame.Checked, "1", "0")
                strBarcodeSame = IIf(Me.chkBarcodeSame.Checked, "1", "0")

                Dim strSQL As StringBuilder = New StringBuilder
                strSQL.AppendLine(" DECLARE @RTVALUE VARCHAR(8), @RTMSG NVARCHAR(150), @OUTMOID VARCHAR(128), @OUTPARTID VARCHAR(128), @OUTCARTONID VARCHAR(32), @OUTQUANTITY VARCHAR(32), @OUTBARCODEQUANTITY VARCHAR(32) ")
                strSQL.AppendLine(" EXECUTE Exec_PackingCheck @RTVALUE OUT, @RTMSG OUT, @OUTMOID OUT, @OUTPARTID OUT, @OUTCARTONID OUT, @OUTQUANTITY OUT, @OUTBARCODEQUANTITY OUT, '" & VbCommClass.VbCommClass.UseId & "', '" & strScanType & "', '" & strCartonDisplay & "', '" & strPalletSame & "', '" & strCartonSame & "', '" & strBarcodeSame & "', '" & Me.txtMoId.Text.Trim & "', '" & Me.txtPalletID.Text.Trim & "', '" & Me.txtCartonID.Text.Trim & "', '" & Me.txtBarCode.Text.Trim & "'")
                strSQL.AppendLine(" SELECT @RTVALUE, @RTMSG, @OUTCARTONID, @OUTQUANTITY, @OUTMOID, @OUTPARTID, @OUTBARCODEQUANTITY ")

                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
                If dt.Rows.Count > 0 Then
                    Select Case dt.Rows(0)(0)
                        Case "0"
                            SetMessage(Me.lblMessage, dt.Rows(0)(1), False)
                            scanSetting.BarCodeStr = Me.txtBarCode.Text.Trim
                            scanSetting.vMainBarCode = Me.txtBarCode.Text.Trim
                            scanSetting.ErrorStr = dt.Rows(0)(1)
                            Dim FrmError As New FrmScanErrPrompt(scanSetting)
                            FrmError.ShowDialog()

                            Me.txtBarCode.Text = ""
                            Me.ActiveControl = Me.txtBarCode
                        Case "1"
                            Me.dgvBarcode.Rows.Insert(0, Me.txtPalletID.Text.Trim, Me.txtCartonID.Text.Trim, Me.txtBarCode.Text.Trim, SysMessageClass.UseId, Now())
                            Me.txtCartonID.Text = dt.Rows(0)(2)
                            Me.LblPackQty.Text = dt.Rows(0)(3)
                            Me.lblMoId.Text = dt.Rows(0)(4)
                            Me.lblPartid.Text = dt.Rows(0)(5)
                            SetMessage(Me.lblMessage, "PASS:扫描" & Me.txtBarCode.Text.Trim & "成功...", True)
                            Dim curQty As Integer = 1
                            If String.IsNullOrEmpty(dt.Rows(0)(6).ToString) = True Then
                                curQty = 1
                            Else
                                curQty = CInt(dt.Rows(0)(6).ToString)
                            End If
                            Me.LblCurrQty.Text = CInt(Me.LblCurrQty.Text.Trim) + curQty

                            If (CInt(Me.LblPackQty.Text.Trim) = CInt(Me.LblCurrQty.Text.Trim)) Then
                                Me.LblPackQty.Text = "0"
                                Me.LblCurrQty.Text = "0"
                                Me.txtBarCode.Text = ""
                                Me.txtCartonID.Text = ""
                                Me.lblMoId.Text = ""
                                Me.lblPartid.Text = ""
                                If (Not String.IsNullOrEmpty(Me.txtPalletID.Text.Trim)) Then
                                    Me.LblCurrCarQty.Text = CInt(Me.LblCurrCarQty.Text.Trim) + curQty
                                End If

                                If (CInt(Me.lblCartonQty.Text.Trim) = CInt(Me.LblCurrCarQty.Text.Trim)) Then
                                    Me.dgvBarcode.DataSource = Nothing
                                    Me.dgvBarcode.Rows.Clear()
                                    If (Me.chkPallet.Checked) Then
                                        Me.ActiveControl = Me.txtPalletID
                                    Else
                                        If (Me.chkCartonDisplay.Checked) Then
                                            Me.ActiveControl = Me.txtCartonID
                                        Else
                                            Me.ActiveControl = Me.txtBarCode
                                        End If
                                    End If
                                Else
                                    Me.ActiveControl = Me.txtCartonID
                                End If
                            Else
                                Me.txtBarCode.Text = ""
                                Me.ActiveControl = Me.txtBarCode
                            End If
                    End Select
                Else
                    SetMessage(Me.lblMessage, "FAIL:获取扫描" & Me.txtBarCode.Text.Trim & "执行结果异常!", False)
                    Me.txtBarCode.Text = ""
                End If
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "FAIL:扫描包装" & Me.txtBarCode.Text.Trim & "异常!", False)
            Dim errMsg As Exception = New Exception(String.Format("txtBarCode:{0}#{1}", Me.txtBarCode.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmPackingCheck", "txtBarCode", "sys")
            Me.txtBarCode.Text = ""
            Me.ActiveControl = Me.txtBarCode
        End Try
    End Sub

    Private Sub txtCartonID_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtCartonID.PreviewKeyDown
        Try
            If e.KeyValue = 13 Then
                SetMessage(Me.lblMessage, "", False)
                If (String.IsNullOrEmpty(Me.txtCartonID.Text.Trim)) Then
                    SetMessage(Me.lblMessage, "FAIL:扫描箱条码不能为空!", False)
                    Me.ActiveControl = Me.txtCartonID
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtMoId.Text.Trim)) Then
                    SetMessage(Me.lblMessage, "FAIL:工单不能为空!", False)
                    Me.txtCartonID.Text = ""
                    Me.ActiveControl = Me.txtMoId
                    Exit Sub
                End If

                Dim strScanType, strCartonDisplay, strPalletSame, strCartonSame, strBarcodeSame As String
                strScanType = "0"
                strCartonDisplay = IIf(Me.chkCartonDisplay.Checked, "1", "0")
                strPalletSame = IIf(Me.chkPalletSame.Checked, "1", "0")
                strCartonSame = IIf(Me.chkCartonSame.Checked, "1", "0")
                strBarcodeSame = IIf(Me.chkBarcodeSame.Checked, "1", "0")

                Dim strSQL As StringBuilder = New StringBuilder
                strSQL.AppendLine(" DECLARE @RTVALUE VARCHAR(8), @RTMSG NVARCHAR(150), @OUTMOID VARCHAR(128), @OUTPARTID VARCHAR(128), @OUTCARTONID VARCHAR(32), @OUTQUANTITY VARCHAR(32), @OUTBARCODEQUANTITY VARCHAR(32) ")
                strSQL.AppendLine(" EXECUTE Exec_PackingCheck @RTVALUE OUT, @RTMSG OUT, @OUTMOID OUT, @OUTPARTID OUT, @OUTCARTONID OUT, @OUTQUANTITY OUT, @OUTBARCODEQUANTITY OUT, '" & VbCommClass.VbCommClass.UseId & "', '" & strScanType & "', '" & strCartonDisplay & "', '" & strPalletSame & "', '" & strCartonSame & "', '" & strBarcodeSame & "', '" & Me.txtMoId.Text.Trim & "', '" & Me.txtPalletID.Text.Trim & "', '" & Me.txtCartonID.Text.Trim & "', '" & Me.txtBarCode.Text.Trim & "'")
                strSQL.AppendLine(" SELECT @RTVALUE, @RTMSG, @OUTCARTONID, @OUTQUANTITY, @OUTMOID, @OUTPARTID, @OUTBARCODEQUANTITY ")

                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
                If dt.Rows.Count > 0 Then
                    Select Case dt.Rows(0)(0)
                        Case "0"
                            SetMessage(Me.lblMessage, dt.Rows(0)(1), False)
                            Me.txtCartonID.Text = ""
                            Me.ActiveControl = Me.txtCartonID
                        Case "1"
                            Me.txtCartonID.Text = dt.Rows(0)(2)
                            Me.LblPackQty.Text = dt.Rows(0)(3)
                            Me.lblMoId.Text = dt.Rows(0)(4)
                            Me.lblPartid.Text = dt.Rows(0)(5)
                            Me.LblCurrQty.Text = "0"
                            SetMessage(Me.lblMessage, "PASS:扫描" & Me.txtCartonID.Text.Trim & "成功...", True)
                            Me.ActiveControl = Me.txtBarCode
                            If (Not String.IsNullOrEmpty(Me.txtPalletID.Text.Trim) And CInt(Me.LblCurrQty.Text.Trim) = 0) Then
                                Me.LblCurrCarQty.Text = CInt(Me.LblCurrCarQty.Text.Trim) + dt.Rows(0)(3)
                            End If
                    End Select
                Else
                    SetMessage(Me.lblMessage, "FAIL:获取扫描" & Me.txtCartonID.Text.Trim & "执行结果异常!", False)
                    Me.txtCartonID.Text = ""
                    Me.ActiveControl = Me.txtCartonID
                End If
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "FAIL:扫描箱" & Me.txtCartonID.Text.Trim & "异常!", False)
            Dim errMsg As Exception = New Exception(String.Format("txtCarton:{0}#{1}", Me.txtCartonID.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmPackingCheck", "txtCartonID", "sys")
            Me.txtCartonID.Text = ""
            Me.ActiveControl = Me.txtCartonID
        End Try

    End Sub

    Private Sub txtPalletID_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtPalletID.PreviewKeyDown

        Try
            If e.KeyValue = 13 Then
                SetMessage(Me.lblMessage, "", False)
                If (String.IsNullOrEmpty(Me.txtPalletID.Text.Trim)) Then
                    SetMessage(Me.lblMessage, "FAIL:扫描栈板条码不能为空!", False)
                    Me.ActiveControl = Me.txtPalletID
                    Exit Sub
                End If
                If (String.IsNullOrEmpty(Me.txtMoId.Text.Trim)) Then
                    SetMessage(Me.lblMessage, "FAIL:工单不能为空!", False)
                    Me.txtPalletID.Text = ""
                    Me.ActiveControl = Me.txtMoId
                    Exit Sub
                End If

                Dim strScanType, strCartonDisplay, strPalletSame, strCartonSame, strBarcodeSame As String
                strScanType = "2"
                strCartonDisplay = IIf(Me.chkCartonDisplay.Checked, "1", "0")
                strPalletSame = IIf(Me.chkPalletSame.Checked, "1", "0")
                strCartonSame = IIf(Me.chkCartonSame.Checked, "1", "0")
                strBarcodeSame = IIf(Me.chkBarcodeSame.Checked, "1", "0")

                Dim strSQL As StringBuilder = New StringBuilder
                strSQL.AppendLine(" DECLARE @RTVALUE VARCHAR(8), @RTMSG NVARCHAR(150), @OUTMOID VARCHAR(128), @OUTPARTID VARCHAR(128), @OUTCARTONID VARCHAR(32), @OUTQUANTITY VARCHAR(32), @OUTBARCODEQUANTITY VARCHAR(32) ")
                strSQL.AppendLine(" EXECUTE Exec_PackingCheck @RTVALUE OUT, @RTMSG OUT, @OUTMOID OUT, @OUTPARTID OUT, @OUTCARTONID OUT, @OUTQUANTITY OUT, @OUTBARCODEQUANTITY OUT, '" & VbCommClass.VbCommClass.UseId & "', '" & strScanType & "', '" & strCartonDisplay & "', '" & strPalletSame & "', '" & strCartonSame & "', '" & strBarcodeSame & "', '" & Me.txtMoId.Text.Trim & "', '" & Me.txtPalletID.Text.Trim & "', '" & Me.txtCartonID.Text.Trim & "', '" & Me.txtBarCode.Text.Trim & "'")
                strSQL.AppendLine(" SELECT @RTVALUE, @RTMSG, @OUTCARTONID, @OUTQUANTITY, @OUTMOID, @OUTPARTID, @OUTBARCODEQUANTITY ")

                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
                If dt.Rows.Count > 0 Then
                    Select Case dt.Rows(0)(0)
                        Case "0"
                            SetMessage(Me.lblMessage, dt.Rows(0)(1), False)
                            Me.txtPalletID.Text = ""
                            Me.ActiveControl = Me.txtPalletID
                        Case "1"
                            Me.lblCartonQty.Text = dt.Rows(0)(3)
                            Me.lblMoId.Text = dt.Rows(0)(4)
                            Me.lblPartid.Text = dt.Rows(0)(5)
                            Me.LblCurrCarQty.Text = "0"
                            SetMessage(Me.lblMessage, "PASS:扫描" & Me.txtPalletID.Text.Trim & "成功...", True)
                            Me.ActiveControl = Me.txtCartonID
                    End Select
                Else
                    SetMessage(Me.lblMessage, "FAIL:获取扫描" & Me.txtPalletID.Text.Trim & "执行结果异常!", False)
                    Me.txtPalletID.Text = ""
                    Me.ActiveControl = Me.txtPalletID
                End If
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "FAIL:扫描箱" & Me.txtPalletID.Text.Trim & "异常!", False)
            Dim errMsg As Exception = New Exception(String.Format("txtCarton:{0}#{1}", Me.txtPalletID.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmPackingCheck", "txtPalletID", "sys")
            Me.txtPalletID.Text = ""
            Me.ActiveControl = Me.txtPalletID
        End Try

    End Sub

#End Region

#Region "函数"

    Public Shared Sub SetMessage(ByVal lblMessage As Label, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

#End Region

End Class