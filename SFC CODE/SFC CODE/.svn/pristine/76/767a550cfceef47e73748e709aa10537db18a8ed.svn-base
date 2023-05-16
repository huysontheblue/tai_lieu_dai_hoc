Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports Owc = Microsoft.Office.Interop.Excel
Imports MainFrame

Public Class FrmQueryProductionDetail
    Public strSQL As String
    Public Sqlparam As SqlParameter()
    'Private ObjDB As SysDataBaseClass
    Private MyTable As DataTable

    Private Sub FrmShowDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SplitContainer1.Panel2Collapsed = True
        ShowDetailData()
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(Me.DgProductDetail, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

    Private Sub DgProductDetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProductDetail.CellContentClick
        Dim EXPPID As String = Me.DgProductDetail.CurrentRow.Cells(0).Value.ToString.Trim
        'ObjDB = New SysDataBaseClass()
        MyTable = New DataTable
        Try
            Dim SqlString As String = "select exppid 成品条码,ppid 部件条码,stationid 站点编号,partid 成品料号  from dbo.m_ppidlink_t where exppid='" & EXPPID & "'" & _
            " union all select a.ppid 成品条码,ppid 部件条码,stationid 站点编号,c.partid 成品料号  from m_TestResult_t a inner join  m_SnSBarCode_t b ON a.ppid=b.SBarCode" & _
            " inner join  m_Mainmo_t c on b.Moid=c.Moid  where a.ppid='" & EXPPID & "'"
            MyTable = DbOperateReportUtils.GetDataTable(SqlString)
            Me.DgLinkDetail.DataSource = MyTable
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MyTable.Dispose()
        End Try
    End Sub

    Private Sub ToolDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDetail.Click
        Me.SplitContainer1.Panel2Collapsed = Not Me.SplitContainer1.Panel2Collapsed
    End Sub

    Private Sub ShowDetailData()
        Dim DtDetail As New DataTable
        Try
            DtDetail = DbOperateReportUtils.GetDataTable(strSQL, Sqlparam)
            ToolCount.Text = DtDetail.Rows.Count.ToString()
            With Me.DgProductDetail
                .DataSource = DtDetail
                .AutoResizeColumns()
                .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
                .ScrollBars = ScrollBars.Both
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            DtDetail.Dispose()
        End Try
    End Sub
End Class