
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports MainFrame.SysCheckData


Public Class FrmQueryLotInfo
    'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Private Sub FrmQueryLotInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        If TxtPpid.Text = "" Then
            MessageUtils.ShowInformation("请输入产品条码后再刷新！")
            Exit Sub
        Else

            Dim strSql As String
            Dim dt As DataTable
            Dim ppid As String = ""
            If TxtPpid.Lines.Length > 0 Then
                Dim ii As Integer = 0
                For ii = 0 To TxtPpid.Lines.Length - 1
                    If TxtPpid.Lines(ii).ToString.Trim = "" Then
                        Continue For
                    Else
                        ppid = ppid + TxtPpid.Lines(ii).ToString.Trim + ","
                    End If
                Next
                ppid = ppid.Substring(0, ppid.Length - 1)
            End If
            strSql = String.Format(" exec m_QueryLotInfo_p '{0}'", ppid)

            Try
                dt = DbOperateReportUtils.GetDataTable(strSql)
                DgMoData.DataSource = dt
                If DgMoData.Rows.Count > 0 Then
                    ToolCount.Text = DgMoData.Rows.Count
                Else
                    MessageUtils.ShowInformation("查无记录，请重设查询条件！")
                    DgMoData.Rows.Clear()
                End If
                dt.Dispose()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(DgMoData, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub
End Class