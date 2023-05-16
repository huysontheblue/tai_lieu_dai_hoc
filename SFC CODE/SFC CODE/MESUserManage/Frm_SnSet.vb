Public Class Frm_SnSet

    Dim Status As String = ""

    Private Sub NewFile_Click(sender As Object, e As EventArgs) Handles NewFile.Click
        ToolbtnState("N")
        TextBox_PartId.Focus()
        Status = "N"
    End Sub

    Private Sub EditFile_Click(sender As Object, e As EventArgs) Handles EditFile.Click
        ToolbtnState("M")
        Status = "M"
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        If Not CheckData() Then
            MessageBox.Show("数据填写不完全,请检查!")
            Return
        End If

        If Status = "N" Then
            If AddData() Then
                LoadData("select * from m_part_sn_t")
            End If
        ElseIf Status = "M" Then
            If ModifyData() Then
                LoadData("select * from m_part_sn_t")
            End If
        End If
        ToolbtnState("S")
        Status = ""
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        If (MessageBox.Show("您确定要删除当前记录？", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes) Then
            If DeleteData() Then
                ToolbtnState("D")
                Status = ""
                LoadData("select * from m_part_sn_t")
            End If
        End If
    End Sub

    Private Sub ExitFrom_Click(sender As Object, e As EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        UpdateText()
    End Sub

    Private Function CheckData() As Boolean
        Dim result As Boolean = True
        If TextBox_PartId.Text.Trim = "" Then
            result = False
        ElseIf ComboBox_PackedId.SelectedIndex = -1 Then
            result = False
        ElseIf TextBox_MinNum.Text.Trim = "" Then
            result = False
        End If
        Return result
    End Function

    Private Sub UpdateText()
        Dim row As DataGridViewRow
        If DataGridView1.CurrentRow Is Nothing Then
            Return
        End If
        row = DataGridView1.CurrentRow
        TextBox_PartId.Text = row.Cells(0).Value.ToString
        If row.Cells(1).Value.ToString.Substring(0, 1) = "S" Then
            ComboBox_PackedId.SelectedIndex = 0
        ElseIf row.Cells(1).Value.ToString.Substring(0, 1) = "C" Then
            ComboBox_PackedId.SelectedIndex = 1
        ElseIf row.Cells(1).Value.ToString.Substring(0, 1) = "P" Then
            ComboBox_PackedId.SelectedIndex = 2
        End If
        TextBox_MinNum.Text = row.Cells(2).Value.ToString
    End Sub

    Private Function LoadData(ByVal sql As String) As Boolean
        Try
            Dim dt As DataTable
            Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
            dt = Sdbc.GetDataTable(sql)
            DataGridView1.DataSource = dt
            DataGridView1.ScrollBars = ScrollBars.Both
            ToolbtnState("")
            UpdateText()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function AddData() As Boolean
        Try
            Dim str As String = ""
            str = String.Format("insert into m_part_sn_t values('{0}','{1}','{2}')", TextBox_PartId.Text.Trim, ComboBox_PackedId.Text.Trim.Substring(0, 1), TextBox_MinNum.Text.Trim)
            Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
            Sdbc.ExecSql(str)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function ModifyData() As Boolean
        Try
            Dim str As String = ""
            str = String.Format("update m_part_sn_t set Min_Num='{0}' where PartId='{1}' and PackId='{2}'", TextBox_MinNum.Text.Trim, TextBox_PartId.Text.Trim, ComboBox_PackedId.Text.Trim.Substring(0, 1))
            Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
            Sdbc.ExecSql(str)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function DeleteData() As Boolean
        Try
            Dim str As String = ""
            str = String.Format("delete from m_part_sn_t where PartId='{0}' and PackId='{1}'", TextBox_PartId.Text.Trim, ComboBox_PackedId.Text.Trim.Substring(0, 1))
            Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
            Sdbc.ExecSql(str)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    '設置按鈕按鈕及TextBox狀態
    Private Sub ToolbtnState(ByVal flag As String)
        Select Case flag
            Case "" '无状态
                NewFile.Enabled = True
                EditFile.Enabled = True
                Delete.Enabled = True
                Save.Enabled = False
                toolBack.Enabled = True
                toolQuery.Enabled = True
                TextBox_MinNum.Enabled = True
                TextBox_PartId.Clear()
                ComboBox_PackedId.SelectedIndex = 0
                TextBox_MinNum.Clear()
            Case "N" '新增
                NewFile.Enabled = False
                EditFile.Enabled = False
                Delete.Enabled = False
                Save.Enabled = True
                toolBack.Enabled = True
                toolQuery.Enabled = False
                TextBox_PartId.Enabled = True
                ComboBox_PackedId.Enabled = True
                TextBox_MinNum.Enabled = True
                TextBox_PartId.Clear()
                ComboBox_PackedId.SelectedIndex = 0
                TextBox_MinNum.Clear()
            Case "M" '修改
                NewFile.Enabled = False
                EditFile.Enabled = False
                Delete.Enabled = False
                Save.Enabled = True
                toolBack.Enabled = True
                toolQuery.Enabled = False
                TextBox_PartId.Enabled = False
                ComboBox_PackedId.Enabled = False
                TextBox_MinNum.Enabled = True
            Case "D" '删除
                NewFile.Enabled = True
                EditFile.Enabled = True
                Delete.Enabled = True
                Save.Enabled = False
                toolBack.Enabled = True
                toolQuery.Enabled = True
                TextBox_PartId.Enabled = False
                ComboBox_PackedId.Enabled = False
                TextBox_MinNum.Enabled = False
            Case "S" '存盘
                NewFile.Enabled = True
                EditFile.Enabled = True
                Delete.Enabled = True
                Save.Enabled = False
                toolBack.Enabled = True
                toolQuery.Enabled = True
                TextBox_PartId.Enabled = True
                ComboBox_PackedId.Enabled = True
                TextBox_MinNum.Enabled = True
            Case "Q" '查询
                NewFile.Enabled = False
                EditFile.Enabled = False
                Delete.Enabled = False
                Save.Enabled = False
                toolBack.Enabled = True
                toolQuery.Enabled = False
                TextBox_PartId.Enabled = True
                ComboBox_PackedId.Enabled = True
                TextBox_MinNum.Enabled = True
                DataRefresh.Visible = True
            Case "R" '更新
                NewFile.Enabled = True
                EditFile.Enabled = True
                Delete.Enabled = True
                Save.Enabled = False
                toolBack.Enabled = True
                toolQuery.Enabled = True
                TextBox_MinNum.Enabled = True
                TextBox_PartId.Clear()
                ComboBox_PackedId.SelectedIndex = 0
                TextBox_MinNum.Clear()
                DataRefresh.Visible = False
        End Select
    End Sub

    Private Sub Frm_SnSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData("select * from m_part_sn_t")
        ComboBox_PackedId.SelectedIndex = 0
    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        ToolbtnState("")
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        TextBox_PartId.Clear()
        TextBox_MinNum.Clear()
        TextBox_PartId.Focus()
        ToolbtnState("Q")
    End Sub

    Private Sub DataRefresh_Click(sender As Object, e As EventArgs) Handles DataRefresh.Click
        Dim str As String = "select * from m_part_sn_t where 1=1"
        If TextBox_PartId.Text.Trim <> "" Then
            str += String.Format(" and PartId like '%{0}%'", TextBox_PartId.Text.Trim)
        ElseIf ComboBox_PackedId.SelectedIndex <> -1 Then
            str += String.Format(" and PackId like '%{0}%'", ComboBox_PackedId.Text.Trim.Substring(0, 1))
        End If
        If LoadData(Str) Then
            ToolbtnState("R")
            UpdateText()
        End If
    End Sub
End Class