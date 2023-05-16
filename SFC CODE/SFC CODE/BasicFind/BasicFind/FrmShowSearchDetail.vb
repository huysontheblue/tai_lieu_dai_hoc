Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports Owc = Microsoft.Office.Interop.Excel
Imports MainFrame

Public Class FrmShowSearchDetail
    Public strSQL As String
    Public TabTitle As String
    Public Sqlparam As SqlParameter()

#Region "重繪datagridview單元格,選中時去除焦點"

    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgData.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

#End Region
    Private Sub FrmShowSearchDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowDetailData()
    End Sub
    Private Sub ShowDetailData()
        'Dim i As Integer
        'Dim colNames As String() = TabTitle.Split("|")
        Dim DtCtScan1 As DataTable
        Try
            DtCtScan1 = DbOperateReportUtils.GetDataTable(strSQL, Sqlparam)
            ToolCount.Text = DtCtScan1.Rows.Count.ToString()
            DgData.DataSource = DtCtScan1
            'For i = 0 To DgData.Columns.Count - 1
            '    DgData.Columns(i).HeaderText = colNames(i)
            '    DgData.Columns(i).Name = colNames(i)
            'Next
            DgData.AutoResizeColumns()
            DgData.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            DgData.ScrollBars = ScrollBars.Both
            DtCtScan1.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.DefaultButton1, "提示信息")
        End Try

    End Sub
    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(Me.DgData, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

    Private Sub DgData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgData.CellDoubleClick
        Dim strPpid, strMO, strPartid, strStation, strLine, strsqld As String
        If e.RowIndex = -1 Then Exit Sub
        strPpid = DgData.Rows(e.RowIndex).Cells(0).Value.ToString()
        strMO = DgData.Rows(e.RowIndex).Cells(1).Value.ToString()
        strPartid = DgData.Rows(e.RowIndex).Cells(2).Value.ToString()
        strStation = DgData.Rows(e.RowIndex).Cells(3).Value.ToString()
        strLine = DgData.Rows(e.RowIndex).Cells(5).Value.ToString()
        strsqld = "exec m_QuerySearchDetailBad_p '" & strPpid & "','" & strMO & "','" & strPartid & "','" & strStation & "','" & strLine & "'"
        Try
            Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strsqld)
            If dt.Rows.Count > 0 Then
                DataGridView1.DataSource = dt
            Else
                MsgBox("未查询到相关不良明细信息！", MsgBoxStyle.DefaultButton1, "提示信息")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.DefaultButton1, "提示信息")
        End Try

    End Sub
End Class