Imports MainFrame

Public Class FrmWarehousing
    Dim tt As DataTable
    Private Sub txtBarCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarCode.KeyDown
        If e.KeyValue <> 13 Then
            ''禁止用键盘手动输入
            Dim tempDt As DateTime = DateTime.Now
            Dim ts As TimeSpan = tempDt.Subtract(_dt)
            If (ts.Milliseconds > 50) Then
                txtBarCode.Text = ""
            End If
            _dt = tempDt
        Else
        End If
        If e.KeyValue = 13 Then
            If txtBarCode.Text <> "" Then
                If DbOperateUtils.GetDataTable("select*FROM M_Warehousing WHERE ppid='" & txtCartonID.Text.Trim & "'").Rows.Count = 0 Then
                Else
                    lblMessage.Text = "送检编号已入库"
                    lblMessage.Text = "送检编号已入库"
                    WorkStantOption.ErrorStr = "送检编号已入库"
                    SetMessage("Fail", "送检编号已入库")
                    WorkStantOption.BarCodeStr = txtBarCode.Text
                    WorkStantOption.vMainBarCode = txtBarCode.Text
                    ShowFrmScanErrPrompt()
                    lblMessage.ForeColor = Color.Red
                    Return
                End If

                tt = DbOperateUtils.GetDataTable("SELECT * FROM m_Inspection where number='" & txtBarCode.Text.Trim & "'AND PPartid='" & TxtPartid.Text.Trim & "'")
                If tt.Rows.Count > 0 Then
                    txtCartonID.Focus()
                    txtBarCode.Enabled = False
                    LblPackQty.Text = tt.Rows.Count
                    lblMessage.Text = "PASS"
                    lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
                Else
                    lblMessage.Text = "送检编号未通过送检"
                    lblMessage.Text = "送检编号未通过送检"
                    WorkStantOption.ErrorStr = "送检编号未通过送检"
                    SetMessage("Fail", "送检编号未通过送检")
                    WorkStantOption.BarCodeStr = txtBarCode.Text
                    WorkStantOption.vMainBarCode = txtBarCode.Text
                    ShowFrmScanErrPrompt()
                    lblMessage.ForeColor = Color.Red
                End If
            Else
                lblMessage.Text = "扫描条码不能为空"
                lblMessage.ForeColor = Color.Red
            End If
        End If

    End Sub

    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click
        VbCommClass.VbCommClass.PPartid = ""
        Dim pprtaid As New FrmPpartid()
        pprtaid.ShowDialog()
        If VbCommClass.VbCommClass.PPartid <> "" Then
            TxtPartid.Text = VbCommClass.VbCommClass.PPartid
            If (DbOperateUtils.GetDataTable(" SELECT*FROM m_process WHERE Ppartid='" & TxtPartid.Text.Trim & "'").Rows.Count > 0) Then
                TxtPartid.Text = VbCommClass.VbCommClass.PPartid
                txtCartonID.Enabled = True
                txtBarCode.Enabled = True
                txtBarCode.Focus()
                tt = DbOperateUtils.GetDataTable("select number  FROM M_Warehousing where ppartid='" & TxtPartid.Text.Trim & "'AND [state]='N'")
                If tt.Rows.Count > 0 Then
                    LblCurrQty.Text = tt.Rows.Count
                    txtBarCode.Text = tt.Rows(0)(0)
                    txtCartonID.Focus()
                    LblPackQty.Text = DbOperateUtils.GetDataTable("SELECT * FROM m_Inspection where number='" & tt.Rows(0)(0) & "'AND PPartid='" & TxtPartid.Text.Trim & "'").Rows.Count
                    txtBarCode.Enabled = False
                End If
            Else
                MessageBox.Show("该料号没有送检条码")
            End If
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
    Private Sub ShowFrmScanErrPrompt()
        Dim FrmError As New FrmScanErrPrompt
        FrmError.ShowDialog()
    End Sub
    Private _dt As DateTime = DateTime.Now
    Private Sub txtCartonID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCartonID.KeyDown
        If e.KeyValue <> 13 Then
            ''禁止用键盘手动输入
            Dim tempDt As DateTime = DateTime.Now
            Dim ts As TimeSpan = tempDt.Subtract(_dt)
            If (ts.Milliseconds > 50) Then
                txtCartonID.Text = ""
            End If
            _dt = tempDt
        Else
        End If

        If e.KeyValue = 13 Then
            If txtCartonID.Text.Trim <> "" Then
                tt = DbOperateUtils.GetDataTable("SELECT * FROM m_Inspection where ppid='" & txtCartonID.Text.Trim & "'AND PPartid='" & TxtPartid.Text.Trim & "'")
                If tt.Rows.Count > 0 Then
                    If DbOperateUtils.GetDataTable("SELECT * FROM m_Inspection where ppid='" & txtCartonID.Text.Trim & "'AND PPartid='" & TxtPartid.Text.Trim & "' and number='" & txtBarCode.Text.Trim & "'").Rows.Count > 0 Then
                        If DbOperateUtils.GetDataTable("select*FROM M_Warehousing WHERE ppid='" & txtCartonID.Text.Trim & "'").Rows.Count = 0 Then
                            DbOperateUtils.ExecSQL("INSERT INTO M_Warehousing(ppid,number,ppartid,Operator)VALUES('" & txtCartonID.Text.Trim & "','" & txtBarCode.Text.Trim & "','" & TxtPartid.Text.Trim & "','" & VbCommClass.VbCommClass.UseId & "')")
                            Me.DGridBarCode.Rows.Insert(0, TxtPartid.Text.Trim, txtBarCode.Text.Trim, txtCartonID.Text.Trim, VbCommClass.VbCommClass.UseId, Date.Now)
                            lblMessage.Text = "PASS"
                            lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
                            LblCurrQty.Text = Convert.ToInt16(LblCurrQty.Text) + 1
                            txtCartonID.Text = ""
                            If LblPackQty.Text = LblCurrQty.Text Then
                                DbOperateUtils.ExecSQL("UPDATE M_Warehousing SET [state]='Y'WHERE number='" & txtBarCode.Text.Trim & "'")
                                LblPackQty.Text = 0
                                LblCurrQty.Text = 0
                                txtBarCode.Text = ""
                                txtBarCode.Enabled = True
                                txtBarCode.Focus()
                            End If
                        Else
                            lblMessage.Text = "产品条码已入库"
                            lblMessage.Text = "产品条码已入库"
                            WorkStantOption.ErrorStr = "产品条码已入库"
                            SetMessage("Fail", "产品条码已入库")
                            WorkStantOption.BarCodeStr = txtBarCode.Text
                            WorkStantOption.vMainBarCode = txtBarCode.Text
                            ShowFrmScanErrPrompt()
                            lblMessage.ForeColor = Color.Red
                        End If
                    Else
                        lblMessage.Text = "产品条码不是该送检编号中的条码"
                        lblMessage.Text = "产品条码不是该送检编号中的条码"
                        WorkStantOption.ErrorStr = "产品条码不是该送检编号中的条码"
                        SetMessage("Fail", "产品条码不是该送检编号中的条码")
                        WorkStantOption.BarCodeStr = txtBarCode.Text
                        WorkStantOption.vMainBarCode = txtBarCode.Text
                        ShowFrmScanErrPrompt()
                        lblMessage.ForeColor = Color.Red
                    End If

                Else
                    lblMessage.Text = "产品条码没有通过送检"
                    lblMessage.Text = "产品条码没有通过送检"
                    WorkStantOption.ErrorStr = "产品条码没有通过送检"
                    SetMessage("Fail", "产品条码没有通过送检")
                    WorkStantOption.BarCodeStr = txtBarCode.Text
                    WorkStantOption.vMainBarCode = txtBarCode.Text
                    ShowFrmScanErrPrompt()
                    lblMessage.ForeColor = Color.Red
                End If
            Else
                lblMessage.Text = "产品条码不能为空"
                lblMessage.ForeColor = Color.Red
            End If
        Else
        End If

    End Sub
End Class