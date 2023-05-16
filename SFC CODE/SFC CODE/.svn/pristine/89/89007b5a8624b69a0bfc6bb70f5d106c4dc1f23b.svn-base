
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame


Public Class FrmQueryLotInfo_KS
    'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Private Sub FrmQueryLotInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        If TxtPpid.Text = "" Then
            MsgBox("请输入产品条码后再刷新！", MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton1, "提示信息")
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
                    MsgBox("查无记录，请重设查询条件！", MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton1, "提示信息")
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