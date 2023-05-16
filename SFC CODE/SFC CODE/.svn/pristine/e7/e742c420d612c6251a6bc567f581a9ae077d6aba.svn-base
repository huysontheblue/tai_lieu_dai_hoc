Imports MainFrame
Imports System.Text
Imports MainFrame.SysCheckData

Public Class FrmReject

    Public type As String
    Public SelectType As String
    Public partId As String
    Public ngDate As String
    Public lineid As String

    '初期化
    Private Sub FrmReject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If type = "2" Then
            btnOK.Visible = False
        End If
        SetRejectText()
    End Sub

    'OK
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try

            If txtRejectText.Text.Trim = "" Then
                MessageUtils.ShowError("驳回原因不能为空！")
                Exit Sub
            End If

            Dim TableName As String = ""

            If SelectType = "日" Then
                TableName = "m_AssyTsProcss_t"
            ElseIf SelectType = "周" Then
                TableName = "m_AssyTsProcssWeek_t"
            ElseIf SelectType = "月" Then
                TableName = "m_AssyTsProcssMonth_t"
            End If

            Dim strUpdateSQL As StringBuilder = New StringBuilder
            strUpdateSQL.AppendFormat(" UPDATE {0} ", TableName)
            strUpdateSQL.AppendFormat("     SET RejectReason = N'{0}', ", txtRejectText.Text)
            strUpdateSQL.AppendFormat("         UserId = N'' ")
            strUpdateSQL.AppendFormat(" WHERE PartID ='{0}'", partId)
            strUpdateSQL.AppendFormat(" AND LineId = '{0}'", lineid)
            strUpdateSQL.AppendFormat(" AND CONVERT(VARCHAR(10),NgDate,111) = CONVERT(VARCHAR(10),CAST(REPLACE(REPLACE(REPLACE('{0}','年','-'), '月','-'),'日','') AS DATETIME),111)", ngDate)

            DbOperateUtils.ExecSQL(strUpdateSQL.ToString)
            MessageUtils.ShowInformation("保存数据成功！")

            Me.Close()

        Catch ex As Exception
            MessageUtils.ShowError("保存数据失败！")
        End Try
    End Sub

    '取消
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub SetRejectText()
        Try
            txtRejectText.Text = KBCom.GetRejectText(SelectType, partId, lineid, ngDate)
        Catch ex As Exception

        End Try
    End Sub

End Class