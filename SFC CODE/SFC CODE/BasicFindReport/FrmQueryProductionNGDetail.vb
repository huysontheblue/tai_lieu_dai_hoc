Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports Owc = Microsoft.Office.Interop.Excel
Imports MainFrame

Public Class FrmQueryProductionNGDetail
    Public strSQL As String
    Public Sqlparam As SqlParameter()
    'Private ObjDB As SysDataBaseClass
    Private MyTable As DataTable

    Private Sub FrmShowDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight = 30
        DataGridView1.RowHeadersWidth = 30
        DgLinkDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DgLinkDetail.ColumnHeadersHeight = 30
        DgLinkDetail.RowHeadersWidth = 30
        Me.SplitContainer1.Panel2Collapsed = True
        ShowDetailData()
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(Me.DataGridView1, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub



    Private Sub ToolDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDetail.Click
        Me.SplitContainer1.Panel2Collapsed = Not Me.SplitContainer1.Panel2Collapsed
    End Sub

    Private Sub ShowDetailData()
        Dim DtDetail As New DataTable
        Try
            Dim ds As DataSet = DbOperateReportUtils.GetDataSet(strSQL)
            DtDetail = ds.Tables(0)
            'DtDetail = ds.Tables(0)
            'DtDetail = ds.Tables(0)
            'DtDetail = ds.Tables(0)
            ToolCount.Text = DtDetail.Rows.Count.ToString()
            With Me.DataGridView1
                .DataSource = DtDetail
                .MergeColumnNames.Add("partid")
                .MergeColumnNames.Add("orderb")
                .MergeColumnNames.Add("stationid")
                .MergeColumnNames.Add("stationname")
                '.AutoResizeColumns()
                '.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
                '.ScrollBars = ScrollBars.Both
            End With
            SetGridColor(DataGridView1, "项次")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            DtDetail.Dispose()
        End Try
    End Sub

   

    Private Sub DgProductNGDetail_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim EXPPID As String = Me.DataGridView1.CurrentRow.Cells(0).Value.ToString.Trim
        'ObjDB = New SysDataBaseClass()
        MyTable = New DataTable
        Try
            Dim SqlString As String = "select exppid 成品条码,ppid 部件条码,a.stationid 站点编号,stationname 站点名称,a.partid 成品料号  from dbo.m_ppidlink_t a left join m_Rstation_t b on a.stationid=b.stationid  where exppid='" & EXPPID & "' and exppid<>ppid "
            '" union all select a.ppid 成品条码,ppid 部件条码,stationid 站点编号,c.partid 成品料号  from m_TestResult_t a inner join  m_SnSBarCode_t b ON a.ppid=b.SBarCode" & _
            '" inner join  m_Mainmo_t c on b.Moid=c.Moid  where a.ppid='" & EXPPID & "'"
            MyTable = DbOperateReportUtils.GetDataTable(SqlString)
            Me.DgLinkDetail.DataSource = MyTable
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MyTable.Dispose()
        End Try
    End Sub
    '设置Grid颜色
    Private Sub SetGridColor(gridView As DataGridView, colName As String)
        For rowIndex As Integer = 0 To gridView.Rows.Count - 1
            If gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("总投入数") Then
                gridView.Rows(rowIndex).Cells(colName).Style.BackColor = System.Drawing.Color.Green
            ElseIf gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("总不良数") Then
                gridView.Rows(rowIndex).Cells(colName).Style.BackColor = System.Drawing.Color.Yellow
            Else
                gridView.Rows(rowIndex).Cells(colName).Style.BackColor = System.Drawing.Color.White
            End If
        Next
    End Sub
End Class