Imports System.Text
Imports MainFrame
Imports DevComponents.DotNetBar.Controls

Public Class FrmMOOutDate

    Private Sub FrmMOOutDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dtpOutDate.Text = Date.Now.Date
        GetMOPlan()
    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        GetMesData.SetMessage(Me.lblMessage, "", True)
        GetMOPlan()
    End Sub

    Private Sub ToolCommit_Click(sender As Object, e As EventArgs) Handles ToolCommit.Click
        Dim sql As String = "UPDATE [m_TiptopPlanMO_t] set [OutDate]=@OutDate,[UpdateUser]=@UpdateUser,[UpdateDate]=getdate() where [Moid]=@Moid "
        Me.dgvMoList.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Try
            For Each rows As DataGridViewRow In dgvMoList.Rows
                Dim ot = IIf(rows.Cells("OutDate").Value Is DBNull.Value, "", rows.Cells("OutDate").Value)
                If Not String.IsNullOrEmpty(ot) Then
                    Dim moid As String = "Moid|" & rows.Cells("MOID").Value
                    Dim outdate As String = "OutDate|" & rows.Cells("OutDate").Value
                    Dim user As String = "UpdateUser|" & VbCommClass.VbCommClass.UseId
                    Dim array As New ArrayList
                    array.Add(outdate)
                    array.Add(moid)
                    array.Add(user)
                    DbOperateUtils.ExecSQL(sql, array)
                End If
            Next
            GetMesData.SetMessage(Me.lblMessage, "更新成功", True)
            GetMOPlan()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更新异常", False)
        End Try
    End Sub


    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        Me.txtMO.Text = ""
        Me.txtLineId.Text = ""
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    Private Sub ToolAgain_Click(sender As Object, e As EventArgs) Handles ToolAgain.Click
        Try
            Dim strSQL As StringBuilder = New StringBuilder

            strSQL.AppendLine(" DECLARE @RTVALUE VARCHAR(8), @RTMSG NVARCHAR(128) ")
            strSQL.AppendLine(" EXEC GetTiptopMO @RTVALUE OUTPUT, @RTMSG OUTPUT ")
            strSQL.AppendLine(" SELECT @RTVALUE, @RTMSG  ")

            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)

            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then

                If (dtTemp.Rows(0).Item(0).ToString = "1") Then
                    GetMesData.SetMessage(Me.lblMessage, "下载成功", True)
                Else
                    GetMesData.SetMessage(Me.lblMessage, dtTemp.Rows(0).Item(1).ToString, False)
                End If
            End If

            GetMOPlan()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "下载异常", False)
        End Try
    End Sub

    Private Sub GetMOPlan()
        Try
            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine("Select [ActualStartDate],[PartId],[Moid],[LINEID],[Quantity],OutDate,[Specification],case planstatus when 'N' then N'未派工' when'Y'then N'已派工'END AS Planstatus ")
            strSQL.AppendLine(" from m_TiptopPlanMO_t where 1=1 AND PlanStatus='N' ")

            Dim lines As String = Nothing
            For Each sLine As String In txtLineId.Text.Trim.Split(CChar(vbNewLine))
                If Not String.IsNullOrEmpty(sLine) Then
                    lines &= "'" & sLine.ToUpper.Trim & "'" & ","
                End If
            Next
            If Not String.IsNullOrEmpty(lines) Then
                lines = lines.Trim(CChar(","))
                strSQL.AppendLine(" AND LineId in (" & lines & ")")
            End If
            If Not String.IsNullOrEmpty(Me.txtMO.Text.Trim) Then
                strSQL.AppendLine(" AND MOID like ('" & Me.txtMO.Text.Trim & "%')")
            End If
            Me.dgvMoList.DataSource = DbOperateUtils.GetDataTable(strSQL.ToString)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub dgvMoList_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvMoList.EditingControlShowing
        Try
            If Me.dgvMoList.CurrentCellAddress.X = 7 Then
                Dim ec As DataGridViewMaskedTextBoxAdvEditingControl = TryCast(e.Control, DataGridViewMaskedTextBoxAdvEditingControl)
                ec.MaskedTextBox.ReadOnly = True
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub dgvMoList_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMoList.CellEnter
        Try

            GetMesData.SetMessage(Me.lblMessage, "", False)
            If Me.dgvMoList.Rows.Count = 0 OrElse Me.dgvMoList.CurrentRow Is Nothing Then
                Me.dgvMoList.DataSource = Nothing
                Me.dgvMoList.Rows.Clear()
                Exit Sub
            End If

            'GetMOItemPlanWorkingHours(Me.dgvMoItemList.Rows(Me.dgvMoItemList.CurrentRow.Index).Cells("CMOid").Value.ToString)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询子工单异常", False)
        End Try
    End Sub
End Class