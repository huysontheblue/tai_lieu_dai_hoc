Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Reflection
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmQueryProductionInfo
    Private PPID As String = ""

    Private Sub FrmQueryProductionInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim strSQL As String
        Dim Moid As String = "%"
        Dim PartID As String = "%"
        Dim LineID As String = "%"
        Dim StationID As String = "%"
        Dim Table As New DataTable
        Try
            If Not CheckDate(DtStar, DtEnd) Then Exit Sub

            If CobMo.Text = "" And TxtPPID.Text = "" And CobLine.Text = "" And CobPart.Text = "" And CobStation.Text = "" Then
                MessageUtils.ShowError("请至少输入一个查询条件！")
                Exit Sub
            End If

            If CobMo.Text <> "" AndAlso CobMo.Text <> "ALL" Then
                Moid = CobMo.Text & "%"
            End If
            If Me.CobPart.Text <> "" AndAlso CobPart.Text <> "ALL" Then
                PartID = CobPart.Text & "%"
            End If
            PPID = ""
            If TxtPPID.Text.Trim <> "" Then
                If TxtPPID.Lines.Length > 0 Then
                    For i = 0 To TxtPPID.Lines.Length - 1
                        If Not TxtPPID.Lines(i).ToString.Trim = "" Then
                            PPID = PPID + TxtPPID.Lines(i).ToString.Trim + ","
                        End If
                    Next
                End If
                If PPID.Length > 0 Then PPID = PPID.Substring(0, PPID.Length - 1)
            Else
            End If
            If Me.CobLine.Text <> "" AndAlso CobLine.Text <> "ALL" Then
                LineID = CobLine.Text.Trim()
            End If
            If Me.CobStation.Text <> "" AndAlso CobStation.Text <> "ALL" Then
                StationID = CobStation.Text.Trim()
            End If
            strSQL = "exec m_QueryProductionInfo_p '" & StartDT & "','" & EndDT & "','" & Moid & "','" & PartID & "','" & PPID & "','" & LineID & "','" & StationID & "'"
            Table = DbOperateReportUtils.GetDataTable(strSQL)
            DgProduction.DataSource = Table
            ToolStripStatusLabel1.Text = "查询符合条件记录：" + DgProduction.RowCount.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Table.Dispose()
        End Try
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(DgProduction, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Sub DgProduction_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProduction.CellDoubleClick
        Dim strMO, strPartid, strStation, strLine As String
        If e.RowIndex = -1 Then Exit Sub
        With DgProduction
            strMO = .Rows(e.RowIndex).Cells(0).Value.ToString()
            strPartid = .Rows(e.RowIndex).Cells(1).Value.ToString()
            strStation = .Rows(e.RowIndex).Cells(2).Value.ToString()
            strLine = .Rows(e.RowIndex).Cells(4).Value.ToString()
        End With
        ShowDetail(strMO, strPartid, strStation, strLine)
    End Sub

    Private Sub ShowDetail(ByVal strMo As String, ByVal strPartid As String, ByVal strStation As String, ByVal strLine As String)
        Dim FrmQueryProductionDetail As New FrmQueryProductionDetail
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim sqlparam(6) As SqlParameter

        sqlparam = SetSqlparameter(strMo, strPartid, strStation, strLine)
        With FrmQueryProductionDetail
            .strSQL = "execute m_QueryProductionDetail_p @begintime,@endtime,@moid ,@partid,@ppid,@stationid,@lineid"
            .Sqlparam = sqlparam
            .ShowDialog()
        End With
    End Sub

    Private Function SetSqlparameter(ByVal moid As String, ByVal partid As String, ByVal stationid As String, ByVal lineid As String) As SqlParameter()
        Dim StartDT, EndDT As String
        Dim param(6) As SqlParameter

        StartDT = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        EndDT = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")

        param(0) = New SqlParameter("@begintime", SqlDbType.Char)
        param(0).Value = StartDT
        param(1) = New SqlParameter("@endtime", SqlDbType.NChar)
        param(1).Value = EndDT
        param(2) = New SqlParameter("@moid", SqlDbType.Char)
        param(2).Value = moid
        param(3) = New SqlParameter("@partid", SqlDbType.NChar)
        param(3).Value = partid
        param(4) = New SqlParameter("@ppid", SqlDbType.NChar)
        param(4).Value = PPID
        param(5) = New SqlParameter("@stationid", SqlDbType.NChar)
        param(5).Value = stationid
        param(6) = New SqlParameter("@lineid", SqlDbType.Char)
        param(6).Value = lineid

        Return param
    End Function

End Class