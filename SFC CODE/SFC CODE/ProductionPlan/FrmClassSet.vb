Imports MainFrame
Imports System.Text
Imports MainFrame.SysCheckData

Public Class FrmClassSet

    '初期化
    Private Sub FrmClassSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSQL As String = " SELECT * FROM APS_Shift "

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        For rowIndex As Integer = 0 To dt.Rows.Count
            gridView.Rows.Add(dt.Rows(rowIndex)(0).ToString, dt.Rows(rowIndex)(1).ToString)
        Next

    End Sub

    '关闭
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    '保存
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim strSQL As New StringBuilder

            strSQL.Append(" DELETE APS_Shift ;")
            For rowIndex As Integer = 0 To gridView.Rows.Count - 1
                strSQL.AppendFormat(" INSERT INTO APS_Shift SELECT N'{0}',N'{1}'  ",
                                     gridView.Rows(rowIndex).Cells(0).Value.ToString, gridView.Rows(rowIndex).Cells(1).Value)
            Next
            DbOperateUtils.ExecSQL(strSQL.ToString)
            MessageUtils.ShowInformation("更新成功")
        Catch ex As Exception
            MessageUtils.ShowInformation("更新失败")
        End Try
    End Sub

    '行删除
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If gridView.CurrentCell Is Nothing Then Exit Sub
        If gridView.CurrentCell.RowIndex = -1 Then Exit Sub

        gridView.Rows.RemoveAt(gridView.CurrentCell.RowIndex)

    End Sub

    '行新增
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        gridView.Rows.Add("", "")
    End Sub
End Class