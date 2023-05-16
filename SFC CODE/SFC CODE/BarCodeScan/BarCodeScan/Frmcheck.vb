Imports MainFrame

Public Class Frmcheck
    Dim tt As DataTable
    Dim style() As String
    Dim i As Integer = 0
    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click
        VbCommClass.VbCommClass.PPartid = ""
        Dim pprtaid As New FrmPpartid()
        pprtaid.ShowDialog()
        If VbCommClass.VbCommClass.PPartid <> "" Then
            TxtPartid.Text = VbCommClass.VbCommClass.PPartid
            If (DbOperateUtils.GetDataTable(" SELECT*FROM m_Inspection WHERE Ppartid='" & TxtPartid.Text.Trim & "'").Rows.Count > 0) Then
                TxtPartid.Text = VbCommClass.VbCommClass.PPartid
                txtCartonID.Enabled = True
                txtBarCode.Enabled = True
                txtBarCode.Focus()
            Else
                MessageBox.Show("该料号没有送检条码")
            End If

        End If
    End Sub

    Private Sub txtBarCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarCode.KeyDown
        If e.KeyValue = 13 Then
            If DbOperateUtils.GetDataTable("SELECT ppid FROM m_Inspection where ppid='" & txtBarCode.Text.Trim & "'AND PPartid='" & TxtPartid.Text.Trim & "'").Rows.Count > 0 Then
                txtCartonID.Focus()
            Else
                check("条码未通过送检无法不对请核实")
                txtBarCode.Text = ""
                lblMessage.ForeColor = Color.Red
                txtBarCode.Text = ""
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
    Private Sub txtCartonID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCartonID.KeyDown
        If e.KeyValue = 13 Then
            If txtBarCode.Text.Trim = txtCartonID.Text.Trim Then
                lblMessage.Text = "PASS"
                lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
                Me.DGridBarCode.Rows.Insert(0, TxtPartid.Text, txtCartonID.Text, txtBarCode.Text, VbCommClass.VbCommClass.UseId, Date.Now)
                If DbOperateUtils.GetDataTable("select RepeatPara FROM m_RPartStationD_t where PPartid='" & TxtPartid.Text.Trim & "' AND State=1").Rows(0)(0).ToString.Trim <> "" Then
                    Dim sta As String = DbOperateUtils.GetDataTable("select RepeatPara FROM m_RPartStationD_t where PPartid='" & TxtPartid.Text.Trim & "' AND State=1").Rows(0)(0).ToString
                    style = sta.Split(",")
                    TextBoxUL2.Text = Mid(style(i), 2, InStr(1, style(i), "|") - 2)
                    TextBoxUL1.Enabled = True
                    TextBoxUL1.Focus()
                Else
                    txtCartonID.Enabled = False
                    txtBarCode.Enabled = True
                    txtBarCode.Text = ""
                    txtBarCode.Focus()
                End If
            Else
                check("校验失败箱与产品条码不一致")
                txtCartonID.Text = ""
            End If

        End If

    End Sub

    Private Sub toolMOStatusSetting_Click(sender As Object, e As EventArgs) Handles toolMOStatusSetting.Click

    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click

    End Sub
    Private Sub check(a As String)
        lblMessage.Text = a
        WorkStantOption.ErrorStr = a
        WorkStantOption.BarCodeStr = txtBarCode.Text
        WorkStantOption.vMainBarCode = txtBarCode.Text
        lblMessage.ForeColor = Color.Red
        ShowFrmScanErrPrompt()
    End Sub
    Private Sub TextBoxUL1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxUL1.KeyDown
        If e.KeyValue = 13 Then
            If TextBoxUL1.Text.Trim.Length = TextBoxUL2.Text.Length Then
                If InStr(1, TextBoxUL2.Text, "*") > 0 Then
                    If DbOperateUtils.GetDataTable("select PPID FROM m_AssysnCheck_t where EXPPID='" & txtCartonID.Text.Trim & "'AND PPID='" & TextBoxUL1.Text.Trim & "'").Rows.Count > 0 Then
                        TextBoxUL2.Text = Mid(style(i), 2, InStr(1, style(i), "|") - 2)
                        lblMessage.Text = "PASS"
                        lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
                        Me.DGridBarCode.Rows.Insert(0, TxtPartid.Text, txtCartonID.Text, TextBoxUL1.Text, VbCommClass.VbCommClass.UseId, Date.Now)
                        TextBoxUL1.Text = ""
                        i = i + 1
                        If style.Length >= i Then
                        Else
                            i = 0
                            TextBoxUL1.Enabled = False
                            TextBoxUL1.Text = ""
                            TextBoxUL2.Text = ""
                            txtCartonID.Text = ""
                            txtBarCode.Text = ""
                            txtBarCode.Focus()
                        End If
                    Else
                        check("校验条码与绑定条码不一致请核实")
                        TextBoxUL1.Text = ""
                    End If
                Else
                    If DbOperateUtils.GetDataTable("select PPID FROM m_AssysnCheckFix_t where EXPPID='" & txtCartonID.Text.Trim & "'AND PPID='" & TextBoxUL1.Text.Trim & "'").Rows.Count > 0 Then
                        TextBoxUL2.Text = Mid(style(i), 2, InStr(1, style(i), "|") - 2)
                        lblMessage.Text = "PASS"
                        lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
                        Me.DGridBarCode.Rows.Insert(0, TxtPartid.Text, txtCartonID.Text, TextBoxUL1.Text, VbCommClass.VbCommClass.UseId, Date.Now)
                        TextBoxUL1.Text = ""
                        i = i + 1
                        If style.Length > i Then
                        Else
                            i = 0
                            TextBoxUL1.Enabled = False
                            TextBoxUL1.Text = ""
                            TextBoxUL2.Text = ""
                            txtCartonID.Text = ""
                            txtBarCode.Text = ""
                            txtBarCode.Focus()
                        End If
                    Else
                        check("校验条码与绑定条码不一致请核实")
                        TextBoxUL1.Text = ""
                    End If
                End If
            Else
                check("校验附件长度不符")
                TextBoxUL1.Text = ""
            End If



            TextBoxUL2.Text = Mid(style(i), 2, InStr(1, style(i), "|") - 2)

        End If
    End Sub
End Class