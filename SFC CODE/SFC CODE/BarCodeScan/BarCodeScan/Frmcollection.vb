Imports MainFrame

Public Class Frmcollection
    Dim tt As DataTable
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        VbCommClass.VbCommClass.PPartid = ""
        Dim pprtaid As New FrmPpartid()
        pprtaid.ShowDialog()
        If VbCommClass.VbCommClass.PPartid <> "" Then
            ppartid.Text = VbCommClass.VbCommClass.PPartid
            query()
        End If
    End Sub
    Private Sub query()
        dgvPackingCheckSetting.DataSource = DbOperateUtils.GetDataTable("SELECT ppid,[type],number,ppartid,Operator,[state],[tiem] FROM M_collection WHERE ppartid='" & ppartid.Text.Trim & "'")
    End Sub
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyValue = 13 Then
            tt = DbOperateUtils.GetDataTable("SELECT number FROM m_Inspection where ppid='" & TextBox1.Text.Trim & "'")
            If tt.Rows.Count > 0 Then
                If DbOperateUtils.GetDataTable("SELECT ppid FROM m_Inspection where ppid='" & TextBox1.Text.Trim & "'").Rows.Count > 0 And DbOperateUtils.GetDataTable("SELECT * FROM M_collection where ppid='" & TextBox1.Text.Trim & "'").Rows.Count = 0 Then
                    DbOperateUtils.ExecSQL("INSERT INTO M_collection(ppid,[type],number,ppartid,Operator) " & _
                                          " VALUES('" & TextBox1.Text.Trim & "','" & IIf(RadioButton1.Checked = True, "FQC", "OBA") & "','" & tt.Rows(0)(0) & "','" & ppartid.Text.Trim & "','" & VbCommClass.VbCommClass.UseId & "')")
                    query()
                Else
                    MessageBox.Show("条码已抽检")
                End If
            Else
                MessageBox.Show("抽检条码未通过送检")
            End If

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DbOperateUtils.ExecSQL("UPDATE M_collection SET [state]='Y' where ppartid='" & ppartid.Text.Trim & "'")
        query()
    End Sub
End Class