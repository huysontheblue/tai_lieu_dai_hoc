Public Class FrmSelectMenu
    '窗体关闭事件
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    '窗体加载事件
    Private Sub FrmSelectMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataLoad()
    End Sub

    '数据加载事件
    Private Sub dataLoad()
        Dim strWhere As String = "and  1=1"
        If String.IsNullOrEmpty(TxtMenuKey.Text.Trim()) = False Then
            strWhere += " and (Treeid like '%" + TxtMenuKey.Text.Trim() + "%' or TKey like '%" + TxtMenuKey.Text.Trim() + "%')"
        End If
        If String.IsNullOrEmpty(TxtMenuName.Text.Trim()) = False Then
            strWhere += " and Ttext like N'%" + TxtMenuName.Text.Trim() + "%'"
        End If
        If String.IsNullOrEmpty(TxtParentMenuKey.Text.Trim()) = False Then
            strWhere += " and Tparent like '%" + TxtParentMenuKey.Text.Trim() + "%'"
        End If
        dgvData.AutoGenerateColumns = False
        dgvData.DataSource = FrmSysMenu.getAllMenu(strWhere)
    End Sub

    Private Sub TxtMenuKey_TextChanged(sender As Object, e As EventArgs) Handles TxtMenuKey.TextChanged
        dataLoad()
    End Sub

    Private Sub TxtMenuName_TextChanged(sender As Object, e As EventArgs) Handles TxtMenuName.TextChanged
        dataLoad()
    End Sub

    Private Sub TxtParentMenuKey_TextChanged(sender As Object, e As EventArgs) Handles TxtParentMenuKey.TextChanged
        dataLoad()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If dgvData.SelectedCells.Count = 0 Then
            MainFrame.SysCheckData.MessageUtils.ShowError("请选择一项数据!")
            Return
        End If
        Dim dgvRow As DataGridViewRow = dgvData.SelectedRows(0)

        Dim FrmOjb As FrmSysMenu = Me.Owner
        FrmOjb.Tparent = dgvRow.Cells("Tkey").Value.ToString()
        FrmOjb.TxtParentName.Text = dgvRow.Cells("Ttext").Value.ToString()
        Me.Close()
    End Sub
End Class