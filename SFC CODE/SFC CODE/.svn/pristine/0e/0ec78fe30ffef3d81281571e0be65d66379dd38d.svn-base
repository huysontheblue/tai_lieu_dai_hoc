Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Reflection
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmQueryProductionRecordIBU

    Private Sub FrmQueryProductionRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
        DataGridViewX1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewX1.ColumnHeadersHeight = 30
        DataGridViewX1.RowHeadersWidth = 30
        dgQueryMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgQueryMain.ColumnHeadersHeight = 30
        dgQueryMain.AutoGenerateColumns = False
        DataGridViewX3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewX3.ColumnHeadersHeight = 30
        DataGridViewX3.RowHeadersWidth = 30
    End Sub
    Public Sub LoadMoDataToCombo(ByVal PartIDStr As String)
        Dim strSql As String
        Dim strUser As String
        Dim intDeptCount As Integer

        strSql = ""
        strUser = MainFrame.SysCheckData.SysMessageClass.UseId
        strSql = "select moid from m_Mainmo_t a join SplitToTable('" & PartIDStr & "',';') c on a.PartID=c.col where  left(moid ,2)='00' order by moid"

        Try
            Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSql)
            CobMo.Tokens.Clear()

            intDeptCount = 0
            For index As Integer = 0 To dt.Rows.Count - 1
                CobMo.Tokens.Add(New DevComponents.DotNetBar.Controls.EditToken(dt.Rows(index)(0).ToString, dt.Rows(index)(0).ToString))
            Next
        Catch ex As Exception
        End Try

    End Sub
    Public Sub LoadStationDataToCombo(ByVal PartIDStr As String)
        Dim strSql As String
        Dim strUser As String

        strSql = ""
        strUser = MainFrame.SysCheckData.SysMessageClass.UseId
        Dim sql As String = " select a.Stationid+'-'+cast(StaOrderid as varchar(3))+'-'+b.Stationname,a.Stationid from  m_RPartStationD_t a  join m_Rstation_t b on a.Stationid=b.Stationid join SplitToTable('" & PartIDStr & "',';') c on a.PPartid=c.col where  state=1 and ScanOrderid=1  order by PPartid asc,StaOrderid"

        Try

            Dim dt As DataTable = DbOperateReportUtils.GetDataTable(sql)
            TokenEditor1.Tokens.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                TokenEditor1.Tokens.Add(New DevComponents.DotNetBar.Controls.EditToken(dt.Rows(i)(1).ToString, dt.Rows(i)(0).ToString))
            Next

        Catch ex As Exception
        End Try

    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim strSQL As String
        Dim Moid As String = ""
        Dim PartID As String = ""
        Dim LineID As String = ""
        Dim StationID As String = ""
        Dim Table As New DataTable
        Try
            If Not CheckDate(DtStar, DtEnd, True, 6) Then Exit Sub

            If CobMo.Text = "" And CobPart.Text = "" And TokenEditor1.Text = "" Then
                MessageUtils.ShowError("请至少输入一个查询条件！")
                Exit Sub
            End If

            'If CobMo.Text <> "" AndAlso CobMo.Text <> "ALL" Then
            '    Moid = CobMo.Text & ""
            'End If
            Dim mostr As String = ""
            If (CobMo.SelectedTokens.Count > 0) Then
                For i = 0 To CobMo.SelectedTokens.Count - 1
                    mostr = mostr + ";" + CobMo.SelectedTokens(i).Value
                Next
                Moid = mostr.Substring(1)
            End If
            If Me.CobPart.Text <> "" AndAlso CobPart.Text <> "ALL" Then
                PartID = CobPart.Text & ""
            End If

            Dim str As String = ""
            If (TokenEditor1.SelectedTokens.Count > 0) Then
                For i = 0 To TokenEditor1.SelectedTokens.Count - 1
                    str = str + ";" + TokenEditor1.SelectedTokens(i).Value
                Next
                StationID = str.Substring(1)
            End If
            strSQL = "exec GetProductionRecordsIBU '" & StartDT & "','" & EndDT & "','" & PartID & "','" & Moid & "','" & StationID & "'" ','" & LineID & "','" & PPID & "'"
            Table = DbOperateReportUtils.GetDataTable(strSQL)
            DataGridViewX1.DataSource = Table
            ' SetGridColorByFPY(DataGridViewX1, "良率")
            DataGridViewX1.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridViewX1.Columns(0).HeaderText = "序号"
            DataGridViewX1.Columns(0).Width = 60
            ' DataGridViewX1.
            ToolStripStatusLabel1.Text = "查询符合条件记录：" + DataGridViewX1.RowCount.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Table.Dispose()
        End Try
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(DataGridViewX1, Me.Text)
    End Sub
    Private Sub ToolExcelNG_Click(sender As Object, e As EventArgs) Handles ToolExcelNG.Click
        LoadDataToExcel(dgQueryMain, "不良明细数据")
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Sub ShowDetail(ByVal strPartid As String, ByVal strStation As String)
        Dim FrmQueryProductionDetail As New FrmQueryProductionDetail
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim moid As String = CobMo.Text.Trim()
        Dim sql As String = "select distinct 条码=a.Ppid,工单=a.Moid,工站=a.stationid,工站名称=b.Stationname,线别=a.LineId,作业员=a.Userid+'/'+c.UserName,作业时间=a.Intime,状态=a.Estateid,isnull(e.Estateid,'') ReWorkState from m_AssysnDInput_t a "
        sql = sql + " join m_Rstation_t b on a.stationid=b.stationid"
        If (strStation <> "") Then
            sql = sql + " join SplitToTable('" & strStation & "',';') d on a.stationid=d.col"
        End If
        sql = sql + " left join m_users_t c on a.Userid=c.UserID "
        sql = sql + " left join m_assysnddelete_t e on a.ppid=e.ppid and a.stationid=e.stationid  "
        sql = sql + " where  (a.intime between '" & StartDT & "' and '" & EndDT & "') and a.PartID='" & strPartid & "' "

        If (moid <> "") Then
            sql = sql + " and a.moid='" & moid & "'"
        End If
        sql = sql + " order by a.Stationid"

        With FrmQueryProductionDetail
            .strSQL = sql
            .type = "product"
            ' .Sqlparam = sqlparam
            .ShowDialog()
        End With
    End Sub
    Private Sub ShowNGDetail(ByVal strPartid As String, ByVal strStation As String)
        ' Dim FrmQueryProductionDetail As New FrmQueryProductionDetail
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim moid As String = CobMo.Text.Trim()

        Dim sqlstr As String = " EXEC m_SearchNgDataReportTotal_IBU_p '" & moid & "','" & strPartid & "','','','','','" &
                                StartDT & "','" & EndDT & "','','','3','" & strStation & "' "

        Dim ds As DataSet = DbOperateUtils.GetDataSet(sqlstr)
        Dim dt As DataTable = ds.Tables(0) ' DbOperateReportUtils.GetDataTable(sql)
        Dim dt_report As DataTable = ds.Tables(1)
        dgQueryMain.DataSource = dt

        '设置颜色
        SetGridColor(dgQueryMain, "StateStr")
        dgQueryMain.MergeColumnNames.Add("colQueryPpid")
        dgQueryMain.AutoResizeColumns()
        SuperTabItem2.Text = strStation + "工站不良数据明细" + "-" + dt.Rows.Count.ToString
        DataGridViewX3.DataSource = dt_report
    End Sub

    Private Sub DataGridViewX1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridViewX1.CellMouseDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        If e.RowIndex >= 0 Then
            Dim strPartid, strStation As String
            With DataGridViewX1
                'strMO = .Rows(e.RowIndex).Cells(0).Value.ToString()
                strPartid = .Rows(e.RowIndex).Cells(1).Value.ToString()
                strStation = .Rows(e.RowIndex).Cells(3).Value.ToString()
                'strLine = .Rows(e.RowIndex).Cells(4).Value.ToString()
            End With
            ShowDetail(strPartid, strStation)
        End If
    End Sub

    Private Sub DataGridViewX1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            btnView.Enabled = True
            Dim strPartid, strStation As String
            With DataGridViewX1
                'strMO = .Rows(e.RowIndex).Cells(0).Value.ToString()
                strPartid = .Rows(e.RowIndex).Cells(1).Value.ToString()
                strStation = .Rows(e.RowIndex).Cells(3).Value.ToString()
                'strLine = .Rows(e.RowIndex).Cells(4).Value.ToString()
            End With
            SuperTabItem2.Text = strStation + "工站不良数据明细"
            'ShowNGDetail(strPartid, strStation)
        End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")

        Dim Moid As String = ""
        Dim PartID As String = ""
        Dim LineID As String = ""
        Dim StationID As String = ""
        Dim Table As New DataTable
        Try

            If Not CheckDate(DtStar, DtEnd, True, 6) Then
                Exit Sub
            End If

            If CobMo.Text = "" And CobPart.Text = "" And TokenEditor1.Text = "" Then
                MessageUtils.ShowError("请至少输入一个查询条件！")
                Exit Sub
            End If

            If Me.CobPart.Text <> "" AndAlso CobPart.Text <> "ALL" Then
                PartID = CobPart.Text & ""
            End If
            Dim mostr As String = ""
            If (CobMo.SelectedTokens.Count > 0) Then
                For i = 0 To CobMo.SelectedTokens.Count - 1
                    mostr = mostr + ";" + CobMo.SelectedTokens(i).Value
                Next
                Moid = mostr.Substring(1)
            End If
            If Me.CobPart.Text <> "" AndAlso CobPart.Text <> "ALL" Then
                PartID = CobPart.Text & ""
            End If

            Dim str As String = ""
            If (TokenEditor1.SelectedTokens.Count > 0) Then

                For i = 0 To TokenEditor1.SelectedTokens.Count - 1
                    str = str + ";" + TokenEditor1.SelectedTokens(i).Value
                Next
                StationID = str.Substring(1)
            End If
            ShowDetail(PartID, StationID)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetGridColor(gridView As DataGridView, colName As String)
        For rowIndex As Integer = 0 To gridView.Rows.Count - 1
            If gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("D") Then
                gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.LightGray
            ElseIf gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("B") Then
                gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.Yellow
            ElseIf gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("G") Then
                gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.Pink
            ElseIf gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("E") Then
                gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.Red
            ElseIf gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("P") Then
                gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.Green
            End If
        Next
    End Sub

    Private Sub btnViewNG_Click(sender As Object, e As EventArgs) Handles btnViewNG.Click
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        '  Dim strSQL As String
        Dim Moid As String = ""
        Dim PartID As String = ""
        Dim LineID As String = ""
        Dim StationID As String = ""
        Dim Table As New DataTable
        Try
            If Not CheckDate(DtStar, DtEnd, True, 6) Then Exit Sub

            If CobMo.Text = "" And CobPart.Text = "" And TokenEditor1.Text = "" Then
                MessageUtils.ShowError("请至少输入一个查询条件！")
                Exit Sub
            End If

            If CobMo.Text <> "" AndAlso CobMo.Text <> "ALL" Then
                Moid = CobMo.Text & ""
            End If
            If Me.CobPart.Text <> "" AndAlso CobPart.Text <> "ALL" Then
                PartID = CobPart.Text & ""
            End If
            'If Me.CobStation.Text <> "" AndAlso CobStation.Text <> "ALL" Then
            '    StationID = CobStation.Text & ""
            'End If
            Dim str As String = ""
            If (TokenEditor1.SelectedTokens.Count > 0) Then
                For i = 0 To TokenEditor1.SelectedTokens.Count - 1
                    str = str + ";" + TokenEditor1.SelectedTokens(i).Value
                Next
                StationID = str.Substring(1)
            End If
            ShowALLNgDetail(PartID, StationID)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ShowALLNgDetail(ByVal strPartid As String, ByVal strStation As String)
        Dim FrmQueryProductionNGDetail As New FrmQueryProductionNGDetail
        Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim moid As String = CobMo.Text.Trim()
        Dim str As String = "exec GetProductionNgRecords '" & StartDT & "' , '" & EndDT & "','" & strPartid & "','" & moid & "','" & strStation & "'"

        With FrmQueryProductionNGDetail
            .strSQL = str
            ' .Sqlparam = sqlparam
            .ShowDialog()
        End With
    End Sub

    Private Sub CobPart_Leave(sender As Object, e As EventArgs) Handles CobPart.Leave
        Dim str As String = CobPart.Text.Trim()
        If str <> "" Then
            LoadMoDataToCombo(str)
            LoadStationDataToCombo(str)
        End If

    End Sub

    Private Sub SuperTabItem2_Click(sender As Object, e As EventArgs) Handles SuperTabItem2.Click

        If DataGridViewX1.CurrentRow.Index >= 0 Then
            btnView.Enabled = True
            Dim strPartid, strStation As String
            With DataGridViewX1
                'strMO = .Rows(e.RowIndex).Cells(0).Value.ToString()
                strPartid = .Rows(DataGridViewX1.CurrentRow.Index).Cells(1).Value.ToString()
                strStation = .Rows(DataGridViewX1.CurrentRow.Index).Cells(3).Value.ToString()
                'strLine = .Rows(e.RowIndex).Cells(4).Value.ToString()
            End With

            ShowNGDetail(strPartid, strStation)
        End If
    End Sub

    Private Sub DataGridViewX1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles DataGridViewX1.RowPrePaint

        If e.RowIndex < DataGridViewX1.Rows.Count Then
            Dim dgrSingle As DataGridViewRow = DataGridViewX1.Rows(e.RowIndex)
            Dim rate As Decimal = 0
            Dim str As String = dgrSingle.Cells("良率").Value.ToString()
            Dim YieldLine As String = dgrSingle.Cells("YieldLine").Value.ToString()
            rate = Decimal.Parse(str.Substring(0, str.Length - 1))
            If YieldLine <> "0" Then
                Try
                    If rate < Decimal.Parse(YieldLine) Then
                        dgrSingle.DefaultCellStyle.ForeColor = System.Drawing.Color.Red
                    Else
                        dgrSingle.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
                    End If
                Catch ex As Exception

                End Try
            Else
                dgrSingle.Cells("YieldLine").Value = "-"
            End If
        End If
    End Sub

    Private Sub DataGridViewX2_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs)
        If e.RowIndex < dgQueryMain.Rows.Count Then
            Dim dgrSingle As DataGridViewRow = dgQueryMain.Rows(e.RowIndex)
            Dim str As String = dgrSingle.Cells("state").Value.ToString()
            If str.Contains("D") Then
                dgrSingle.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray
            ElseIf str.Contains("B") Then
                dgrSingle.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow
            ElseIf str.Contains("G") Then
                dgrSingle.DefaultCellStyle.BackColor = System.Drawing.Color.Pink
            ElseIf str.ToString.Contains("E") Then
                dgrSingle.DefaultCellStyle.BackColor = System.Drawing.Color.Red
            ElseIf str.Contains("P") Then
                dgrSingle.DefaultCellStyle.BackColor = System.Drawing.Color.Green
            End If
        End If

    End Sub

#Region "Grid行数"
    Private Sub dgQueryMain_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgQueryMain.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

End Class