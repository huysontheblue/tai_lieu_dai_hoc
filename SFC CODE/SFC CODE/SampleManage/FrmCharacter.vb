Imports MainFrame

Public Class FrmCharacter

    Dim opflag As Integer = 0
#Region "菜单点击事件"
    '新增
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        'Dim sql As String
        'sql = "select Partid from m_SnCharChk_t"
        'Dim h As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql)
        'For index = 1 To h.Rows.Count
        'Next
        opflag = 1
        toolEdit.Enabled = False
        toolAbandon.Enabled = False
        toolQuery.Enabled = False
        CheckBox1.Checked = True
        toolSave.Enabled = True
        toolAdd.Enabled = False
        Me.ComMaterial.Enabled = True
    End Sub
    '修改
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
            ComMaterial.Text = DataGridView1.CurrentRow.Cells("Column1").Value
            TextStyle.Text = DataGridView1.CurrentRow.Cells("Column2").Value
            Length.Text = DataGridView1.CurrentRow.Cells("Column3").Value
            TextCharacter.Text = Replace(DataGridView1.CurrentRow.Cells("Column4").Value, ",", "")
            CheckBox1.Checked = IIf(DataGridView1.CurrentRow.Cells("Column5").Value = "Y", True, False)
            '关晓艳 2018/09/03 增加id显示
            txtId.Text = Me.DataGridView1.CurrentRow.Cells("id").Value
        End If
        Exit Sub
    End Sub
    '作废
    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        If Me.DataGridView1.Rows.Count = 0 OrElse Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
        Try
            If Me.DataGridView1.Item(5, Me.DataGridView1.CurrentRow.Index).Value.ToString.Trim <> "Y" Then
                MessageBox.Show("该料号字符卡控已被作废，不允许再作废！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If MessageBox.Show("确定要作废料号：[" + Me.DataGridView1.Item(1, Me.DataGridView1.CurrentRow.Index).Value.ToString.Trim + "]的字符卡控吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
            Dim sql As String = "UPDATE m_SnCharsChk_t SET Usey='N' WHERE Partid='" & DataGridView1.CurrentRow.Cells("Column1").Value & "' and ID=" & Me.txtId.Text.Trim.ToString
            MainFrame.DbOperateUtils.ExecSQL(sql)
            toolQuery_Click(sql, e)
        Catch ex As Exception
            'MessageBox.Show("请选择需要作废的行")
            MessageBox.Show("请选择需要作废的行！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim sql As String
        Dim zifu As String = ""
        If ComMaterial.Text = "" Then
            Prompt.Text = "料号不能为空"
            Return
        ElseIf TextStyle.Text = "" Then
            Prompt.Text = "样式不能为空"
            Return
        ElseIf TextCharacter.Text = "" Then
            Prompt.Text = "字符不能为空"
            Return
        End If
        For index = 1 To TextCharacter.Text.Trim().Length
            Dim lngA As Long
            Dim lngB As Long
            Dim lngC As Long
            Dim strCount As Integer
            lngA = Len(UCase(TextCharacter.Text.Trim()))
            lngB = Len(Mid(UCase(TextCharacter.Text.Trim()), index, 1))
            lngC = Len(Replace(UCase(TextCharacter.Text.Trim()), Mid(UCase(TextCharacter.Text.Trim()), index, 1), ""))
            strCount = (lngA - lngC) / lngB
            If strCount > 1 Then
                MessageBox.Show("卡控样式中存在重复字符" + "‘" + Mid(TextCharacter.Text.Trim(), index, 1) + "’")
                Return
            End If
        Next

        '关晓艳 2018/09/04 判断卡控字符中是否有间断*
        Dim first As Integer = InStr(1, Me.TextStyle.Text.Trim.ToString, "*")
        Dim last As Integer = InStrRev(Me.TextStyle.Text.Trim.ToString, "*")
        Dim count As String = (Len(Me.TextStyle.Text.Trim.ToString) - Len(Replace(Me.TextStyle.Text.Trim.ToString, "*", ""))) / Len("*")
        If last - first + 1 <> count Then
            MessageBox.Show("条码样式中有间断 * 出现！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If InStr(1, TextStyle.Text, "*") = 0 Then
            'MessageBox.Show("请标记需要检查的部分用 * 表示")
            MessageBox.Show("请标记需要检查的部分用 * 表示", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        For i = 1 To TextCharacter.Text.Trim().Length
            If i <> TextCharacter.Text.Trim().Length Then
                zifu += Mid(TextCharacter.Text.Trim(), i, 1) + ","
            Else
                zifu += Mid(TextCharacter.Text.Trim(), i, i)
            End If
        Next
        If opflag = 2 Then
            'Dim sql1 As String = String.Format("UPDATE m_SnCharsChk_t SET SnStyle='{0}',SnLen='{1}',SerialSpeStr='{2}',Usey='{4}'WHERE Partid='{3}'", UCase(TextStyle.Text.Trim()), UCase(Length.Text.Trim()), UCase(zifu), UCase(ComMaterial.Text.Trim()), IIf(Me.CheckBox1.Checked, "Y", "N"))
            Dim sql1 As String = String.Format("UPDATE m_SnCharsChk_t SET SnStyle='{0}',SnLen='{1}',SerialSpeStr='{2}',Usey='{4}'WHERE Partid='{3}' and ID={5}", UCase(TextStyle.Text.Trim()), UCase(Length.Text.Trim()), UCase(zifu), UCase(ComMaterial.Text.Trim()), IIf(Me.CheckBox1.Checked, "Y", "N"), Me.txtId.Text.Trim.ToString)
            MainFrame.DbOperateUtils.ExecSQL(sql1)
            'MessageBox.Show("修改成功", "操作提示")
            MessageBox.Show("修改成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Prompt.Text = ""
            toolBack_Click(sql1, e)
            ComMaterial.Enabled = False
            toolQuery_Click(zifu, e)
        Else
            'Dim sqlv As String = " select*FROM  m_SnCharChk_t where Partid LIKE '" & ComMaterial.Text.Trim() & "'"
            'If Int(MainFrame.DbOperateUtils.GetRowsCount(sqlv)) = 1 Then
            '    Prompt.Text = "该料号已存在"
            '    Return
            'End If
            '关晓艳 2018/09/04 判断料号是否存在
            Dim strSQL As String = "select 1 from m_PartContrast_t where TAvcPart ='" & Me.ComMaterial.Text.Trim.ToString & "'"
            If DbOperateUtils.GetDataTable(strSQL).Rows.Count <= 0 Then
                MessageBox.Show("该料号在系统中不存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            sql = String.Format("INSERT INTO m_SnCharsChk_t(Partid,SnStyle,SnLen,SerialStart,SerialEnd,SerialSpeStr,Usey) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", UCase(ComMaterial.Text.Trim()), UCase(TextStyle.Text.Trim()), UCase(Length.Text.Trim()), "0", "0", UCase(zifu), IIf(Me.CheckBox1.Checked, "Y", "N"))
            MainFrame.DbOperateUtils.ExecSQL(sql)
            'MessageBox.Show("保存成功", "操作提示")
            MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Prompt.Text = ""
            ComMaterial.Enabled = False
            toolBack_Click(sql, e)
            toolQuery_Click(zifu, e)
        End If
    End Sub
    '返回
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
    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim sql As String
        If ComMaterial.Text <> "" Then
            sql = "select ID,Partid , SnStyle , SnLen , SerialSpeStr , Usey  from m_SnCharsChk_t where Usey = '" & IIf(Me.CheckBox1.Checked, "Y", "N") & "' and Partid LIKE '" & ComMaterial.Text & "%' "
            Dim h As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql)
            DataGridView1.DataSource = h
        Else
            sql = "select ID,Partid , SnStyle , SnLen , SerialSpeStr , Usey  from m_SnCharsChk_t where Usey = '" & IIf(Me.CheckBox1.Checked, "Y", "N") & "' "
            Dim h As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql)
            DataGridView1.DataSource = h
        End If
    End Sub
    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
    '条码样式文本框改变
    Private Sub TextStyle_TextChanged(sender As Object, e As EventArgs) Handles TextStyle.TextChanged
        Length.Text = TextStyle.Text.Length
    End Sub
    'datagridview 选中事件
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Me.txtId.Text = Me.DataGridView1.CurrentRow.Cells("id").Value
    End Sub
#End Region
End Class