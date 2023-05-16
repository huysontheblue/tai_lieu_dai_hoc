Imports System.Text
Imports MainFrame

Public Class FrmStopDate

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Try
            GetProductionTime()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub
    Private Sub GetProductionTime()
        Try
            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine("SELECT ID, StopLineDate,  REMARK,  CASE TYPES  WHEN '1' THEN N'正常班'  WHEN '2'  THEN N'假期'   END TYPES " +
                       " FROM  m_tiptopplanstoplinedate_t WHERE 1=1 AND DATEPART(yyyy, GETDATE()) = DATEPART(yyyy, StopLineDate) ORDER BY StopLineDate")

            'If Not String.IsNullOrEmpty(Me.dtpStart.Text.Trim()) Then
            '    strSQL.AppendLine(" AND StopLineDate LIKE '%" & Me.mtxtLine.Text.Trim & "%' ")
            'End If

            Me.dgvQuery.DataSource = DbOperateUtils.GetDataTable(strSQL.ToString)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub ToolCommit_Click(sender As Object, e As EventArgs) Handles ToolCommit.Click
        Dim strSQL As New StringBuilder
        GetMesData.SetMessage(Me.lblMessage, "", True)
        Try
            If Not String.IsNullOrEmpty(Me.dtpStart.Text.Trim) Then
                If String.IsNullOrEmpty(Me.cboTypes.Text.Trim) Then
                    GetMesData.SetMessage(Me.lblMessage, "请选择类别", False)
                    Return
                End If
                Me.dtpStart.Text = Convert.ToDateTime(Me.dtpStart.Text.Trim).ToString("yyyy-MM-dd")
                strSQL.AppendLine("SELECT ID, StopLineDate " +
                           " FROM  m_tiptopplanstoplinedate_t WHERE  StopLineDate='" & Me.dtpStart.Text & "' ")
                If (DbOperateUtils.GetDataTable(strSQL.ToString).Rows.Count > 0) Then
                    GetMesData.SetMessage(Me.lblMessage, "已经存在此日期", False)
                    Return
                Else
                    strSQL = New StringBuilder
                    strSQL.AppendLine(" INSERT INTO m_tiptopplanstoplinedate_t( StopLineDate ,REMARK,TYPES, CreateUserId)" +
                                      " VALUES( '" & Me.dtpStart.Text & "',N'" & Me.txtRemark.Text.Trim & "','" & Me.cboTypes.SelectedIndex & "','" & VbCommClass.VbCommClass.UseId & "' )  ")
                    DbOperateUtils.ExecSQL(strSQL.ToString)
                    GetProductionTime()
                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                GetMesData.SetMessage(lblMessage, "请选择要删除的数据", False)
                Exit Sub
            End If
            Dim strSQL As New StringBuilder
            Dim id As String = Me.dgvQuery.CurrentRow.Cells("ID").Value
            strSQL.AppendLine(" DELETE FROM m_tiptopplanstoplinedate_t  WHERE  ID='" & id & "'")
            DbOperateUtils.ExecSQL(strSQL.ToString)
            GetProductionTime()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        Me.dtpStart.Text = Date.Now.Date
        Me.txtRemark.Text = ""
        Me.cboTypes.Text = ""
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub
End Class