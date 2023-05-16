Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Reflection
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmQueryProductionWIP
    Private PPID As String = ""
    Private ObjDB As New MainFrame.SysDataHandle.SysDataBaseClassReport()
    Private rs As SqlDataReader
    Private Sub FrmQueryProductionWIP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'DtStar.Value = Now().ToString("yyyy-MM-dd")
        'DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
        DataGridViewX1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewX1.ColumnHeadersHeight = 30
        DataGridViewX1.RowHeadersWidth = 30
       

    End Sub
    'Public Sub LoadMoDataToCombo(ByVal PartIDStr As String)
    '    Dim strSql As String
    '    Dim strUser As String
    '    Dim intDeptCount As Integer

    '    strSql = ""
    '    strUser = MainFrame.SysCheckData.SysMessageClass.UseId
    '    strSql = "select moid from m_Mainmo_t a join SplitToTable('" & PartIDStr & "',';') c on a.PartID=c.col where  left(moid ,2)='00' order by moid"

    '    Try
    '        rs = ObjDB.GetDataReader(strSql)
    '        CobMo.Tokens.Clear()
    '        'ComBox.Items.Add("")

    '        intDeptCount = 0
    '        Do While rs.Read
    '            'ComBox.Items.Add(rs(0))
    '            CobMo.Tokens.Add(New DevComponents.DotNetBar.Controls.EditToken(rs(0).ToString, rs(0).ToString))
    '            intDeptCount += 1
    '        Loop

    '    Catch ex As Exception

    '    Finally
    '        rs.Close()
    '    End Try

    'End Sub
    'Public Sub LoadStationDataToCombo(ByVal PartIDStr As String)
    '    Dim strSql As String
    '    Dim strUser As String

    '    strSql = ""
    '    strUser = MainFrame.SysCheckData.SysMessageClass.UseId
    '     Dim sql As String = " select a.Stationid+'-'+cast(StaOrderid as varchar(3))+'-'+b.Stationname,a.Stationid from  m_RPartStationD_t a  join m_Rstation_t b on a.Stationid=b.Stationid join SplitToTable('" & PartIDStr & "',';') c on a.PPartid=c.col where  state=1 and ScanOrderid=1  order by PPartid asc,StaOrderid"

    '    Try

    '        Dim dt As DataTable = ObjDB.GetDataTable(sql)
    '        TokenEditor1.Tokens.Clear()
    '           For i As Integer = 0 To dt.Rows.Count - 1
    '            'ComBox.Items.Add(dt.Rows(i)(0).ToString)

    '            TokenEditor1.Tokens.Add(New DevComponents.DotNetBar.Controls.EditToken(dt.Rows(i)(1).ToString, dt.Rows(i)(0).ToString))
    '        Next


    '    Catch ex As Exception

    '    End Try

    ' End Sub
    'Public Sub LoadStationDataToComboByMO(ByVal MoStr As String)
    '    Dim strSql As String
    '    Dim strUser As String

    '    strSql = ""
    '    strUser = MainFrame.SysCheckData.SysMessageClass.UseId
    '    Dim sql As String = " select a.Stationid+'-'+cast(StaOrderid as varchar(3))+'-'+b.Stationname,a.Stationid from  m_RPartStationD_t a  join m_Rstation_t b on a.Stationid=b.Stationid join (select partid from m_mainmo_t where moid='" & MoStr & "') c on a.PPartid=c.partid where  state=1 and ScanOrderid=1  order by PPartid asc,StaOrderid"

    '    Try

    '        Dim dt As DataTable = ObjDB.GetDataTable(sql)
    '        'TokenEditor1.Tokens.Clear()
    '        'For i As Integer = 0 To dt.Rows.Count - 1
    '        '    TokenEditor1.Tokens.Add(New DevComponents.DotNetBar.Controls.EditToken(dt.Rows(i)(1).ToString, dt.Rows(i)(0).ToString))
    '        'Next


    '    Catch ex As Exception

    '    End Try

    'End Sub
    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        Dim StartDT As String = "" ' DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim EndDT As String = "" ' DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim strSQL As String
        Dim Moid As String = ""
        Dim PartID As String = ""
        Dim LineID As String = ""
        Dim StationID As String = ""
        Dim Table As New DataTable
        Try
            'If Not CheckDate(DtStar, DtEnd, True, 6) Then Exit Sub

            If mtxtMOid.Text = "" And CobPart.Text = "" Then
                MessageUtils.ShowError("物料,工单,工站 请至少输入一个查询条件！")
                Exit Sub
            End If

            'Dim mostr As String = ""
            'If (CobMo.SelectedTokens.Count > 0) Then
            '    For i = 0 To CobMo.SelectedTokens.Count - 1
            '        mostr = mostr + ";" + CobMo.SelectedTokens(i).Value
            '    Next
            '    Moid = mostr.Substring(1)
            'End If
            Moid = mtxtMOid.Text.Trim
            If Me.CobPart.Text <> "" AndAlso CobPart.Text <> "ALL" Then
                PartID = CobPart.Text & ""
            End If

            'Dim str As String = ""
            'If (TokenEditor1.SelectedTokens.Count > 0) Then
            '    For i = 0 To TokenEditor1.SelectedTokens.Count - 1
            '        str = str + ";" + TokenEditor1.SelectedTokens(i).Value
            '    Next
            '    StationID = str.Substring(1)
            'End If
            strSQL = "exec GetProductionWIP '" & PartID & "','" & Moid & "'" ','" & StationID & "'" ','" & LineID & "','" & PPID & "'"
            Table = DbOperateReportUtils.GetDataTable(strSQL)
            DataGridViewX1.DataSource = Table
            DataGridViewX1.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridViewX1.Columns(0).HeaderText = "序号"
            DataGridViewX1.Columns(0).Width = 60
            ' DataGridViewX1.
            ' SetGridColorByQC(DataGridViewX1)
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

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub


    'Private Sub ShowDetail(ByVal strPartid As String, ByVal strStation As String)
    '    Dim FrmQueryProductionDetail As New FrmQueryProductionDetail
    '    Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
    '    Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
    '    Dim moid As String = CobMo.Text.Trim()
    '    Dim sql As String = "select 条码=Ppid,工单=a.Moid,工站=a.stationid,工站名称=b.Stationname,线别=a.LineId,作业员=a.Userid+'/'+c.UserName,作业时间=a.Intime,状态=Estateid from m_AssysnDInput_t a "
    '    sql = sql + " join m_Rstation_t b on a.stationid=b.stationid"
    '    If (strStation <> "") Then
    '        sql = sql + " join SplitToTable('" & strStation & "',';') d on a.stationid=d.col"
    '    End If
    '    sql = sql + " left join m_users_t c on a.Userid=c.UserID "
    '    sql = sql + " where  (a.intime between '" & StartDT & "' and '" & EndDT & "') and a.PartID='" & strPartid & "' "

    '    If (moid <> "") Then
    '        sql = sql + " and a.moid='" & moid & "'"
    '    End If
    '    sql = sql + " order by a.Stationid"

    '    'Dim sqlparam(6) As SqlParameter

    '    'sqlparam = SetSqlparameter(strPartid, strStation)
    '    With FrmQueryProductionDetail
    '        .strSQL = sql
    '        .type = "product"
    '        ' .Sqlparam = sqlparam
    '        .ShowDialog()
    '    End With
    'End Sub



    Private Sub CobPart_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CobPart.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim str As String = CobPart.Text.Trim()
            'LoadMoDataToCombo(str)
            'LoadStationDataToCombo(str)
        End If

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
            ' ShowDetail(strPartid, strStation)
        End If
    End Sub

    'Private Sub DataGridViewX1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick

    '    'If e.RowIndex = -1 Then Exit Sub
    '    'If e.RowIndex >= 0 Then

    '    'End If
    'End Sub

    Private Sub DataGridViewX1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            'btnView.Enabled = True
            'Dim strPartid, strStation As String
            'With DataGridViewX1
            '    'strMO = .Rows(e.RowIndex).Cells(0).Value.ToString()
            '    strPartid = .Rows(e.RowIndex).Cells(1).Value.ToString()
            '    strStation = .Rows(e.RowIndex).Cells(3).Value.ToString()
            '    'strLine = .Rows(e.RowIndex).Cells(4).Value.ToString()
            'End With

            'ShowNGDetail(strPartid, strStation)
        End If
    End Sub

    'Private Sub btnView_Click(sender As Object, e As EventArgs)
    '    'If DataGridViewX1.CurrentRow.Index >= 0 Then
    '    '    Dim strPartid, strStation As String
    '    '    With DataGridViewX1
    '    '        'strMO = .Rows(e.RowIndex).Cells(0).Value.ToString()
    '    '        strPartid = .Rows(DataGridViewX1.CurrentRow.Index).Cells(1).Value.ToString()
    '    '        strStation = .Rows(DataGridViewX1.CurrentRow.Index).Cells(3).Value.ToString()
    '    '        'strLine = .Rows(e.RowIndex).Cells(4).Value.ToString()
    '    '    End With
    '    '    ShowDetail(strPartid, strStation)
    '    'End If
    '    Dim StartDT As String = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
    '    Dim EndDT As String = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")

    '    Dim Moid As String = ""
    '    Dim PartID As String = ""
    '    Dim LineID As String = ""
    '    Dim StationID As String = ""
    '    Dim Table As New DataTable
    '    Try


    '        If Not CheckDate(DtStar, DtEnd, True, 6) Then
    '            Exit Sub
    '        End If


    '        If mtxtMOid.Text = "" And CobPart.Text = "" And TokenEditor1.SelectedTokens.Count > 0 Then
    '            MessageUtils.ShowError("请至少输入一个查询条件！")
    '            Exit Sub
    '        End If


    '        'If CobMo.Text <> "" AndAlso CobMo.Text <> "ALL" Then
    '        '    Moid = CobMo.Text & ""
    '        '    End If

    '        If Me.CobPart.Text <> "" AndAlso CobPart.Text <> "ALL" Then
    '            PartID = CobPart.Text & ""
    '        End If
    '        Dim mostr As String = mtxtMOid.Text.Trim
    '        'If (CobMo.SelectedTokens.Count > 0) Then
    '        '    For i = 0 To CobMo.SelectedTokens.Count - 1
    '        '        mostr = mostr + ";" + CobMo.SelectedTokens(i).Value
    '        '    Next
    '        '    Moid = mostr.Substring(1)
    '        'End If
    '        If Me.CobPart.Text <> "" AndAlso CobPart.Text <> "ALL" Then
    '            PartID = CobPart.Text & ""
    '        End If
    '        'PPID = ""
    '        'If TxtPPID.Text.Trim <> "" Then
    '        '    If TxtPPID.Lines.Length > 0 Then
    '        '        For i = 0 To TxtPPID.Lines.Length - 1
    '        '            If Not TxtPPID.Lines(i).ToString.Trim = "" Then
    '        '                PPID = PPID + TxtPPID.Lines(i).ToString.Trim + ","
    '        '            End If
    '        '        Next
    '        '    End If
    '        '    If PPID.Length > 0 Then PPID = PPID.Substring(0, PPID.Length - 1)
    '        'Else
    '        'End If
    '        'If Me.CobLine.Text <> "" AndAlso CobLine.Text <> "ALL" Then
    '        '    LineID = CobLine.Text.Trim()
    '        'End If
    '        'If Me.CobStation.Text <> "" AndAlso CobStation.Text <> "ALL" Then
    '        '    StationID = CobStation.Text.Trim().Split("-")(0)

    '        'End If
    '        Dim str As String = ""
    '        If (TokenEditor1.SelectedTokens.Count > 0) Then

    '            For i = 0 To TokenEditor1.SelectedTokens.Count - 1
    '                str = str + ";" + TokenEditor1.SelectedTokens(i).Value
    '            Next
    '            StationID = str.Substring(1)
    '        End If
    '        'ShowDetail(PartID, StationID)

    '    Catch ex As Exception


    '    End Try


    'End Sub


    Private Sub SetNgDetail(ppid As String, itemid As String, dgDetail As DataGridView)
        Dim strSQL As String = " exec m_SearchNgData_p '{0}','{1}','{2}','{3}','{4}','{5}','{6}'"

        strSQL = String.Format(strSQL, "", ppid, itemid, "", "", "3", "")

        Try
            Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSQL)
            dgDetail.DataSource = dt
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
    Private Sub SetGridColor(gridView As DataGridView, colName As String)
        For rowIndex As Integer = 0 To gridView.Rows.Count - 1
            If gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("D") Then
                gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.White
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
    'Private Sub SetGridColorByQC(gridView As DataGridView)
    '    For rowIndex As Integer = 0 To gridView.Rows.Count - 1
    '        Dim rate As Decimal = 0
    '        Dim str As String = gridView.Rows(rowIndex).Cells("IsQCCheckOut").Value.ToString()
    '        'Dim IsQCCheckOut As String = gridView.Rows(rowIndex).Cells("IsQCCheckOut").Value.ToString()
    '        ' rate = Decimal.Parse(str.Substring(0, str.Length - 1))
    '        If str = "Y" Then
    '            gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow
    '            gridView.Rows(rowIndex).Cells("Column23").ToolTipText = "OQC检验工站不统计"
    '            gridView.Rows(rowIndex).Cells("Column23").Style.ForeColor = Color.Green

    '        Else
    '            gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.White
    '            If rowIndex = 0 Then
    '                gridView.Rows(rowIndex).Cells("Column23").ToolTipText = "投入工站WIP = 不良数量"
    '            Else
    '                gridView.Rows(rowIndex).Cells("Column23").ToolTipText = "工站WIP数=上一工站产出数-当前工站产出数"
    '            End If

    '            gridView.Rows(rowIndex).Cells("Column23").Style.ForeColor = Color.Black
    '        End If



    '    Next
    'End Sub




    Private Sub mtxtMOid_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMOid.ButtonCustomClick
        Try

            Dim frmMOQuery As New FrmMOQuery(mtxtMOid, "", CobPart.Text)
            frmMOQuery.ShowDialog()
            'If frmMOQuery.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    CobMo.Text = frmMOQuery.NewMo
            'End If

        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub

    'Private Sub mtxtMOid_TextChanged(sender As Object, e As EventArgs)
    '    'If mtxtMOid.Text.Trim <> "" Then
    '    '    LoadStationDataToComboByMO(mtxtMOid.Text.Trim)
    '    'End If

    'End Sub

    Private Sub CobPart_Leave(sender As Object, e As EventArgs) Handles CobPart.Leave
        Dim str As String = CobPart.Text.Trim()
        'If (str <> "") Then
        '    LoadStationDataToCombo(str)
        'End If
        'LoadMoDataToCombo(str)

    End Sub

    Private Sub mtxtMOid_Leave(sender As Object, e As EventArgs) Handles mtxtMOid.Leave
        If mtxtMOid.Text.Trim <> "" Then
            '   LoadStationDataToComboByMO(mtxtMOid.Text.Trim)
        End If

    End Sub

    Private Sub DataGridViewX1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles DataGridViewX1.RowPrePaint
        If e.RowIndex < DataGridViewX1.Rows.Count Then
            'Dim dgrSingle As DataGridViewRow = DataGridViewX1.Rows(e.RowIndex)
            'Dim rate As Decimal = 0
            'Dim str As String = dgrSingle.Cells("良率").Value.ToString()
            'Dim YieldLine As String = dgrSingle.Cells("YieldLine").Value.ToString()
            'rate = Decimal.Parse(str.Substring(0, str.Length - 1))
            'If YieldLine <> "0" Then
            '    Try
            '        If rate < Decimal.Parse(YieldLine) Then
            '            dgrSingle.DefaultCellStyle.ForeColor = System.Drawing.Color.Red
            '        Else
            '            dgrSingle.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
            '        End If
            '    Catch ex As Exception

            '    End Try
            'Else
            '    dgrSingle.Cells("YieldLine").Value = "-"
            'End If
            Dim rate As Decimal = 0
            Dim str As String = DataGridViewX1.Rows(e.RowIndex).Cells("IsQCCheckOut").Value.ToString()
            'Dim IsQCCheckOut As String = gridView.Rows(rowIndex).Cells("IsQCCheckOut").Value.ToString()
            ' rate = Decimal.Parse(str.Substring(0, str.Length - 1))
            If str = "Y" Then
                DataGridViewX1.Rows(e.RowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow
                DataGridViewX1.Rows(e.RowIndex).Cells("Column23").ToolTipText = "OQC检验工站不统计"
                DataGridViewX1.Rows(e.RowIndex).Cells("Column23").Style.ForeColor = Color.Green

            Else
                DataGridViewX1.Rows(e.RowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.White
                If e.RowIndex = 0 Then
                    DataGridViewX1.Rows(e.RowIndex).Cells("Column23").ToolTipText = "投入工站WIP = 不良数量"
                Else
                    DataGridViewX1.Rows(e.RowIndex).Cells("Column23").ToolTipText = "工站WIP数=上一工站产出数-当前工站产出数"
                End If

                DataGridViewX1.Rows(e.RowIndex).Cells("Column23").Style.ForeColor = Color.Black
            End If
        End If
    End Sub
End Class