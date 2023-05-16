Imports MainFrame

Public Class Frmprocess
    Dim tt As DataTable
    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        VbCommClass.VbCommClass.PPartid = ""
        Dim pprtaid As New FrmPpartid()
        pprtaid.ShowDialog()
        If VbCommClass.VbCommClass.PPartid <> "" Then
            txtPartId.Text = VbCommClass.VbCommClass.PPartid
            If (DbOperateUtils.GetDataTable(" SELECT*FROM m_process WHERE Ppartid='" & txtPartId.Text.Trim & "'").Rows.Count < 4) Then
                txtPartId.Text = VbCommClass.VbCommClass.PPartid
            Else
                tt = DbOperateUtils.GetDataTable("SELECT Ppartid,inspection1,inspection2,Operator,tiem FROM m_process where Ppartid='" & txtPartId.Text & "'")
                dgvPackingCheckSetting.DataSource = tt
                MessageBox.Show("料号已存在")
            End If

        End If

    End Sub

    Private Sub ToolCommit_Click(sender As Object, e As EventArgs) Handles ToolCommit.Click
        If txtPartId.Text.Trim <> "" Then
            If (DbOperateUtils.GetDataTable(" SELECT*FROM m_process WHERE Ppartid='" & txtPartId.Text.Trim & "'and [type]='" & (IIf(RadioButton1.Checked = True, "FQC", "OBA")) & "'").Rows.Count < 2) Then
                If txtAffiliatedBarCode.Text <> "" And txtNumberDdivisions.Text <> "" Then
                    DbOperateUtils.ExecSQL("INSERT INTO m_process(Ppartid,inspection1,inspection2,Operator,[type]) VALUES ('" & txtPartId.Text & "',N'" & txtAffiliatedBarCode.Text & "',N'" & txtNumberDdivisions.Text & "','" & VbCommClass.VbCommClass.UseId & "','" & IIf(RadioButton1.Checked = True, "FQC", "OBA") & "')")
                    tt = DbOperateUtils.GetDataTable("SELECT Ppartid,inspection1,inspection2,Operator,tiem,[type] FROM m_process where Ppartid='" & txtPartId.Text & "'")
                    dgvPackingCheckSetting.DataSource = tt
                Else
                    MessageBox.Show("抽检项目不能为空")
                End If
            Else
                MessageBox.Show("该料号已存在")
            End If
        Else
            MessageBox.Show("料号不能为空")
        End If


    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub
End Class