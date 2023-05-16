Imports MainFrame.SysCheckData

Public Class FrmLeader
    Dim dt As DataTable
    Dim strSQL As String
    Dim strFactoryName As String = VbCommClass.VbCommClass.Factory
    Dim strChecker As String = VbCommClass.VbCommClass.UseId
    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        '新增
        txtuser.ReadOnly = False
        toolSave.Enabled = True
        toolUndo.Enabled = True
    End Sub

    Private Sub toolUndo_Click(sender As Object, e As EventArgs) Handles toolUndo.Click
        txtuser.ReadOnly = True
        toolSave.Enabled = False
        toolUndo.Enabled = False
        toolRefresh.Enabled = False
    End Sub

    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        txtuser.ReadOnly = False
        toolRefresh.Enabled = True
        toolUndo.Enabled = True
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        '保存
        Dim USERID As String = txtuser.Text.Trim
        strSQL = " SELECT USERID FROM m_Users_t WHERE UserID = '" + txtuser.Text.Trim + "' AND Usey = '1'"
        dt = MainFrame.DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count < 1 Then
            MessageUtils.ShowInformation("该用户不存在")
            Return
        End If
        strSQL = " SELECT * FROM m_power_t where UserID = '" + txtuser.Text.Trim + "' AND Usey = 'Y' AND FactoryID = '" + strFactoryName + "'"
        dt = MainFrame.DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count >= 1 Then
            MessageUtils.ShowInformation("该用户已存在")
            Return
        Else
            strSQL = "insert INTO m_power_t (USERID,FactoryID,Creater , Intime) VALUES ('" + txtuser.Text.Trim + "','" + strFactoryName + "','" + strChecker + "',getdate())"
            dt = MainFrame.DbOperateUtils.GetDataTable(strSQL)
            MessageUtils.ShowInformation("保存成功")
            txtuser.Text = ""
            strSQL = "SELECT A.USERID,A.FactoryID,A.Creater,A.Intime  ,(select UserName from m_users_t where UserID=A.UserID) AS UserName FROM m_power_t A  Left JOIN m_users_t B  ON A.UserID = B.USERID " &
                 " WHERE  A.USERID= '" + USERID + "'  AND A.Usey = 'Y' AND A.FactoryID = '" + strFactoryName + "' AND B.Usey = '1'"
            dt = MainFrame.DbOperateUtils.GetDataTable(strSQL)
            dgvName.DataSource = dt
        End If
    End Sub

    Private Sub toolRefresh_Click(sender As Object, e As EventArgs) Handles toolRefresh.Click
        'strSQL = " SELECT * FROM m_power_t where UserID = '" + txtuser.Text.Trim + "' AND Usey = 'Y' AND FactoryID = '" + strFactoryName + "'"
        strSQL = "SELECT A.USERID,A.FactoryID,A.Creater,A.Intime ,(select UserName from m_users_t " &
                 " where UserID=A.UserID) AS UserName FROM m_power_t A  Left JOIN m_users_t B  ON A.UserID = B.USERID " &
                 " WHERE  A.Usey = 'Y' AND A.FactoryID = '" + strFactoryName + "' AND B.Usey = '1'"
        If txtuser.Text.Trim <> "" Then
            strSQL = strSQL + "AND A.USERID= '" + txtuser.Text.Trim + "'"
        End If
        dt = MainFrame.DbOperateUtils.GetDataTable(strSQL)
        dgvName.DataSource = dt
    End Sub

    Private Sub FrmLeader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        strSQL = "SELECT A.USERID,A.FactoryID,A.Creater,A.Intime ,(select UserName from m_users_t " &
                 " where UserID=A.UserID) AS UserName FROM m_power_t A  Left JOIN m_users_t B  ON A.UserID = B.USERID " &
                 " WHERE A.Usey = 'Y' AND A.FactoryID = '" + strFactoryName + "' AND B.Usey = '1'"
        dt = MainFrame.DbOperateUtils.GetDataTable(strSQL)
        dgvName.DataSource = dt
    End Sub

    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        If dgvName.RowCount < 1 OrElse dgvName.CurrentRow Is Nothing Then Exit Sub
        Dim USERID As String = dgvName.Rows(dgvName.CurrentRow.Index).Cells(0).Value.ToString()
        Dim FactoryID As String = dgvName.Rows(dgvName.CurrentRow.Index).Cells(1).Value.ToString()
        strSQL = " UPDATE m_power_t SET Usey = 'N' where UserID = '" + USERID + "'  AND FactoryID = '" + FactoryID + "'"
        dt = MainFrame.DbOperateUtils.GetDataTable(strSQL)
        MessageUtils.ShowInformation("删除成功")
        FrmLeader_Load(sender, e)
    End Sub
End Class