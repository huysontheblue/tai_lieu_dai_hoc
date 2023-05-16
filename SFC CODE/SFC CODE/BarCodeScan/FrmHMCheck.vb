Imports MainFrame

Public Class FrmHMCheck

    Private Sub rbtnSelected_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSelected.CheckedChanged
        If rbtnSelected.Checked = True Then
            txtPackingBoxCartonCode.Enabled = True
            txtPackingBoxBarcode.Enabled = False
            Label2.Text = ""
        End If
    End Sub

    Private Sub rbtnSelecte_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSelecte.CheckedChanged
        If rbtnSelecte.Checked = True Then
            txtPackingBoxCartonCode.Enabled = False
            txtPackingBoxBarcode.Enabled = True
            Label2.Text = "检验产品条码外箱记录不会保存"
            Label2.ForeColor = Color.Red
        End If
    End Sub
    Private _dt As DateTime = DateTime.Now

    Private Sub txtPackingBoxCartonCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPackingBoxCartonCode.KeyPress
        If e.KeyChar <> Chr(13) Then
            ''禁止用键盘手动输入
            Dim tempDt As DateTime = DateTime.Now
            Dim ts As TimeSpan = tempDt.Subtract(_dt)
            If (ts.Milliseconds > 50) Then
                txtPackingBoxBarcode.Text = ""
            End If
            _dt = tempDt
        Else
            Dim strSQL As String
            Dim SQL As String
            Dim dt As DataTable
            strSQL = "SELECT * FROM  m_H01chekcartonsn_t WHERE Cartonid =N'" + txtPackingBoxCartonCode.Text.Trim() + "'"
            dt = DbOperateReportUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                LabResult.Text = "FAIL"
                lblMessage.Text = txtPackingBoxCartonCode.Text + "箱条码已存在检验记录不允许继续校验"
                Dim Err As String = lblMessage.Text
                strSQL = "INSERT INTO m_Errinfo_t(Userid ,Pcname ,NTUser , ErrNum ,ErrDest ,ErrForm ,Errformprg ,Errtype ,EXESQL) VALUES (N'" + VbCommClass.VbCommClass.UseId + "',N'" + My.Computer.Name + "',N'" + VbCommClass.VbCommClass.UseId + "','1',N'" + lblMessage.Text.ToString() + "','FrmHMCheck',N'" + txtPackingBoxCartonCode.Text + "','sys','')"
                dt = DbOperateUtils.GetDataTable(strSQL)
                DataERR.Rows.Insert(0, Err)
                LabResult.ForeColor = Color.Red
                lblMessage.ForeColor = Color.Red
                txtPackingBoxCartonCode.SelectAll()
                txtPackingBoxCartonCode.Focus()
                Return
            End If
            strSQL = "SELECT * FROM  m_Carton_t WHERE Cartonid =N'" + txtPackingBoxCartonCode.Text.Trim() + "'"
            dt = DbOperateReportUtils.GetDataTable(strSQL)
            If dt.Rows.Count = 0 Then
                LabResult.Text = "FAIL"
                lblMessage.Text = txtPackingBoxCartonCode.Text + "箱条码不存在"
                Dim Err As String = lblMessage.Text
                strSQL = "INSERT INTO m_Errinfo_t(Userid ,Pcname ,NTUser , ErrNum ,ErrDest ,ErrForm ,Errformprg ,Errtype ,EXESQL) VALUES (N'" + VbCommClass.VbCommClass.UseId + "',N'" + My.Computer.Name + "',N'" + VbCommClass.VbCommClass.UseId + "','1',N'" + lblMessage.Text.ToString() + "','FrmHMCheck',N'" + txtPackingBoxCartonCode.Text + "','sys','')"
                dt = DbOperateUtils.GetDataTable(strSQL)
                DataERR.Rows.Insert(0, Err)
                LabResult.ForeColor = Color.Red
                lblMessage.ForeColor = Color.Red
                txtPackingBoxCartonCode.SelectAll()
                txtPackingBoxCartonCode.Focus()
                Return
            Else
                strSQL = "EXEC GetH01andH02WhsOutDataChek '" + txtPackingBoxCartonCode.Text.Trim() + "'"
                dt = DbOperateReportUtils.GetDataTable(strSQL)
                If dt.Rows(0).Item(0) <> "OK" Then
                    LabResult.Text = "FAIL"
                    lblMessage.Text = dt.Rows(0).Item(0)
                    Dim Err As String = lblMessage.Text
                    strSQL = "INSERT INTO m_Errinfo_t(Userid ,Pcname ,NTUser , ErrNum ,ErrDest ,ErrForm ,Errformprg ,Errtype ,EXESQL) VALUES (N'" + VbCommClass.VbCommClass.UseId + "',N'" + My.Computer.Name + "',N'" + VbCommClass.VbCommClass.UseId + "','1',N'" + dt.Rows(0).Item(0) + "','FrmHMCheck',N'" + txtPackingBoxCartonCode.Text + "','sys','')"
                    dt = DbOperateUtils.GetDataTable(strSQL)
                    DataERR.Rows.Insert(0, Err)
                    LabResult.ForeColor = Color.Red
                    lblMessage.ForeColor = Color.Red
                    Return
                Else
                    strSQL = " DECLARE @Msg VARCHAR(150) exec checkH01ByPpidORCarton '" + txtPackingBoxCartonCode.Text.Trim() + "','C',@Msg out select @Msg"
                    dt = DbOperateReportUtils.GetDataTable(strSQL)
                    If dt.Rows(0).Item(0) <> "OK" Then
                        LabResult.Text = "FAIL"
                        lblMessage.Text = dt.Rows(0).Item(0)
                        Dim Err As String = lblMessage.Text
                        strSQL = "INSERT INTO m_Errinfo_t(Userid ,Pcname ,NTUser , ErrNum ,ErrDest ,ErrForm ,Errformprg ,Errtype ,EXESQL) VALUES (N'" + VbCommClass.VbCommClass.UseId + "',N'" + My.Computer.Name + "',N'" + VbCommClass.VbCommClass.UseId + "','1',N'" + dt.Rows(0).Item(0) + "','FrmHMCheck',N'" + txtPackingBoxCartonCode.Text + "','sys','')"
                        dt = DbOperateUtils.GetDataTable(strSQL)
                        DataERR.Rows.Insert(0, Err)
                        LabResult.ForeColor = Color.Red
                        lblMessage.ForeColor = Color.Red
                        Return
                    Else
                        strSQL = "SELECT ID FROM  m_H01chekcartonsn_t WHERE Cartonid =N'" + txtPackingBoxCartonCode.Text.Trim() + "'"
                        dt = DbOperateUtils.GetDataTable(strSQL)
                        If dt.Rows.Count = 0 Then
                            SQL = " INSERT INTO m_H01chekcartonsn_t (cartonid,cout,userid,intime) VALUES ('" + txtPackingBoxCartonCode.Text.Trim() + "','1','" + VbCommClass.VbCommClass.UseId + "',getdate())"
                        Else
                            SQL = "  UPDATE m_H01chekcartonsn_t SET cout = cout + 1 ,uptime = getdate(),upuserid = '" + VbCommClass.VbCommClass.UseId + "' WHERE ID = '" + dt.Rows(0).Item(0).ToString + "'"
                        End If
                        Dim dr As DataTable = DbOperateUtils.GetDataTable(SQL)
                        LabResult.Text = "PASS"
                        lblMessage.Text = txtPackingBoxCartonCode.Text
                        LabResult.ForeColor = Color.FromArgb(0, 192, 0)
                        lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
                        Dim Cartonid As String = txtPackingBoxCartonCode.Text.Trim()
                        Dim UseId As String = VbCommClass.VbCommClass.UseId
                        Dim SN As String = ""
                        dgvUnPackBox.Rows.Insert(0, Cartonid, SN, UseId, DateTime.Now.ToString())
                        txtPackingBoxCartonCode.SelectAll()
                        txtPackingBoxCartonCode.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtPackingBoxBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPackingBoxBarcode.KeyPress
        If e.KeyChar <> Chr(13) Then
            '禁止用键盘手动输入()
            'Dim tempDt As DateTime = DateTime.Now
            'Dim ts As TimeSpan = tempDt.Subtract(_dt)
            'If (ts.Milliseconds > 50) Then
            '    txtPackingBoxBarcode.Text = ""
            'End If
            '_dt = tempDt
            Return
        Else
            Dim strSQL As String
            Dim dt As DataTable
            strSQL = " DECLARE @Msg VARCHAR(150) exec checkH01ByPpidORCarton '" + txtPackingBoxBarcode.Text.Trim() + "','S',@Msg out select @Msg"
            dt = DbOperateReportUtils.GetDataTable(strSQL)
            If dt.Rows(0).Item(0) <> "OK" Then
                LabResult.Text = "FAIL"
                lblMessage.Text = dt.Rows(0).Item(0)
                Dim Err As String = lblMessage.Text
                strSQL = "INSERT INTO m_Errinfo_t(Userid ,Pcname ,NTUser , ErrNum ,ErrDest ,ErrForm ,Errformprg ,Errtype ,EXESQL) VALUES (N'" + VbCommClass.VbCommClass.UseId + "',N'" + My.Computer.Name + "',N'" + VbCommClass.VbCommClass.UseId + "','1',N'" + dt.Rows(0).Item(0) + "','FrmHMCheck',N'" + txtPackingBoxBarcode.Text + "','sys','')"
                dt = DbOperateUtils.GetDataTable(strSQL)
                DataERR.Rows.Insert(0, Err)
                LabResult.ForeColor = Color.Red
                lblMessage.ForeColor = Color.Red
            Else
                LabResult.Text = "PASS"
                lblMessage.Text = txtPackingBoxBarcode.Text
                LabResult.ForeColor = Color.FromArgb(0, 192, 0)
                lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
                Dim Cartonid As String = ""
                Dim UseId As String = VbCommClass.VbCommClass.UseId
                Dim SN As String = txtPackingBoxBarcode.Text.Trim()
                dgvUnPackBox.Rows.Insert(0, Cartonid, SN, UseId, DateTime.Now.ToString())
                txtPackingBoxBarcode.SelectAll()
                txtPackingBoxBarcode.Focus()
            End If
        End If
    End Sub
End Class