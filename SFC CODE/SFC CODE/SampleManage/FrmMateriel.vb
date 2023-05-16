Public Class FrmMateriel
    Dim opflag As Integer
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        opflag = 1
        toolEdit.Enabled = False
        toolAbandon.Enabled = False
        toolQuery.Enabled = False
        CheckBox1.Checked = True
        toolSave.Enabled = True
        toolAdd.Enabled = False
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim sql As String
        Dim zifu As String = ""
        If ComMaterial.Text = "" Then
            Prompt.Text = "订单号不能为空"
            Return
        ElseIf TextStyle.Text = "" Then
            Prompt.Text = "物料不能为空"
            Return
        ElseIf TextCharacter.Text = "" Then
            Prompt.Text = "数量不能为空"
            Return
        ElseIf Not IsNumeric(TextCharacter.Text) Then
            Prompt.Text = "数量必须为纯数字"
            Return
        End If
        If opflag = 2 Then
            Dim sql1 As String = String.Format("UPDATE m_WhPOPartSpec_t SET PartID='{0}',Qty='{1}',UserID='{2}',Usey='{3}'WHERE ID='{4}'", TextStyle.Text.Trim(), TextCharacter.Text.Trim(), VbCommClass.VbCommClass.UseId, IIf(Me.CheckBox1.Checked, "Y", "N"), Label6.Text)
            MainFrame.DbOperateUtils.ExecSQL(sql1)
            MessageBox.Show("修改成功", "操作提示")
            Prompt.Text = ""
            toolBack_Click(sql1, e)
            ComMaterial.Enabled = False
            toolQuery_Click(zifu, e)
        Else
            sql = String.Format("INSERT INTO m_WhPOPartSpec_t(PONumber,PartID,Qty,UserID,Usey) VALUES('{0}','{1}','{2}','{3}','{4}')", ComMaterial.Text.Trim(), TextStyle.Text.Trim(), TextCharacter.Text.Trim(), VbCommClass.VbCommClass.UseId, "Y")
            MainFrame.DbOperateUtils.ExecSQL(sql)
            MessageBox.Show("保存成功", "操作提示")
            Prompt.Text = ""
            ComMaterial.Enabled = False
            toolBack_Click(sql, e)
            toolQuery_Click(zifu, e)
        End If
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        ComMaterial.Enabled = False
        toolSave.Enabled = True
        toolAdd.Enabled = False
        toolAbandon.Enabled = False
        toolQuery.Enabled = False
        toolEdit.Enabled = False
        opflag = 2
        If Me.DataGridView1.Rows.Count = 0 OrElse Me.DataGridView1.CurrentRow Is Nothing Then
            MessageBox.Show("请选择需要修改的数据")
            toolBack_Click("", e)
        Else
            Label6.Text = DataGridView1.CurrentRow.Cells("ID").Value
            ComMaterial.Text = DataGridView1.CurrentRow.Cells("Column1").Value
            TextStyle.Text = DataGridView1.CurrentRow.Cells("Column2").Value
            TextCharacter.Text = Replace(DataGridView1.CurrentRow.Cells("Column3").Value, ",", "")
            CheckBox1.Checked = IIf(DataGridView1.CurrentRow.Cells("Column5").Value = "Y", True, False)
        End If
        Exit Sub
    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        If Me.DataGridView1.Rows.Count = 0 OrElse Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
        Try
            Dim sql As String = "UPDATE m_WhPOPartSpec_t SET Usey='N' WHERE PONumber='" & DataGridView1.CurrentRow.Cells("Column1").Value & "'"
            MainFrame.DbOperateUtils.ExecSQL(sql)
            toolQuery_Click(sql, e)
        Catch ex As Exception
            MessageBox.Show("请选择需要作废的行")
        End Try
    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        Prompt.Text = ""
        toolSave.Enabled = False
        ComMaterial.Enabled = True
        toolAdd.Enabled = True
        toolAbandon.Enabled = True
        toolQuery.Enabled = True
        toolEdit.Enabled = True
        ComMaterial.Text = ""
        TextStyle.Text = ""
        TextCharacter.Text = ""
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim sql As String = "SELECT*FROM m_WhPOPartSpec_t WHERE Usey='" & IIf(CheckBox1.Checked, "Y", "N") & "'"
        If ComMaterial.Text <> "" Then
            sql += "and PONumber='" & ComMaterial.Text & "'"
        End If
        If TextStyle.Text <> "" Then
            sql += "and PartID='" & TextStyle.Text & "'"
        End If
        If TextCharacter.Text <> "" Then
            sql += "and Qty='" & TextCharacter.Text & "'"
        End If
        sql += "and Intime BETWEEN '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:00.000" & "'"
        Dim h As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql)
        DataGridView1.DataSource = h
 
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub FrmMateriel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim a As DateTime = Convert.ToDateTime(DateTimePicker1.Value.ToString("yyyy-MM-dd"))
        Dim s As String = a.AddDays(-60).ToString("yyyy-MM-dd")
        DateTimePicker1.Value = s
    End Sub
End Class