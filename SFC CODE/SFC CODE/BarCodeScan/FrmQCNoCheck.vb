Imports MainFrame
Imports System.Text
Imports MainFrame.SysCheckData
Public Class FrmQCNoCheck

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        GetData()
    End Sub

    Private Sub GetData()
        Dim strSql As New StringBuilder
        strSql.Append("SELECT a.Moid,a.PartNo ,a.Ppid ,b.Stationname,a.FunctionRatio,a.Status,a.CreateUserId,a.CreateTime ")
        strSql.Append(" FROM dbo.m_QCCheckInSnList_t  a inner join m_Rstation_t b on b.Stationid=a.CheckInStationId ")
        strSql.Append(" WHERE a.Status='N' ")

        If Not String.IsNullOrEmpty(Me.txtMoid.Text) Then
            strSql.Append(" and a.moid='" & Me.txtMoid.Text & "'")
        End If
        If Not String.IsNullOrEmpty(Me.txtPartNo.Text) Then
            strSql.Append(" and a.PartNo='" & Me.txtPartNo.Text & "'")
        End If
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql.ToString)
        dgvData.DataSource = dt
        lbCount.Text = dt.Rows.Count
    End Sub

    Private Sub FrmQCNoCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
    End Sub
End Class