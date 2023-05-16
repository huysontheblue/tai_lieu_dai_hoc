'--产品条码和不良条码关联异常作业
'--Create by :　凃美超
'--Create date :　2020/02/21
'--Update date :  
'--
'--Ver : V01

Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports MainFrame
Public Class FrmPpidExceptionHandle
    Private dataSet As New DataSet("dataSet")
    Private strCondition As String
    Private strSaveSql As String
    Private g_Factory As String
    Public strWhere As String = ""
    Private Sub FrmScanQuery_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '设定用戶權限
        Dim sysDB As New SysDataBaseClass
        '权限 
        sysDB.GetControlright(Me)
        DgScanData.AutoGenerateColumns = False
        toolsProductDelete.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolsProductDelete.Tag) = "YES", True, False))
        toolsMODelete.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolsMODelete.Tag) = "YES", True, False))

        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")

        'FillComboLine(CobMo)
        FillFactory(CobFactory, MainFrame.SysCheckData.SysMessageClass.UseId)
        Me.DgScanData.AutoGenerateColumns = False
        Me.ActiveControl = Me.CobMo
    End Sub

#Region "菜单事件"
    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        SetMessage("", False)
        Try
            If CobFactory.Text <> "" Then
                g_Factory = GetFactoryCode(CobFactory.Text)
            Else
                g_Factory = ""
            End If

            If Not CheckDate() Then
                Exit Sub
            End If
            SelectQuery()
        Catch
            SetMessage("查询异常", False)
        End Try
    End Sub
    '定义导出Excel数据源
    Dim dtOutPut As DataTable = New DataTable()
    Private Sub SearchRecord(ByVal Sqlstring As String)
        Dim SqlSearch As String = String.Format("select A.moid,A.partid,A.ppid,A.Ngppid,A.stationid,B.stationname,A.Usey,A.Userid,A.Intime from m_ppidLinkNg_t A " &
                                                "left join m_Rstation_t B on A.stationid=B.stationid where 1=1 {0}", Sqlstring)
        Dim DtContrast As DataTable = DbOperateUtils.GetDataTable(SqlSearch)
        DgScanData.DataSource = DtContrast
        DgScanData.Refresh()
        ToolCount.Text = DgScanData.RowCount.ToString()
    End Sub
    Private Sub SelectQuery()
        strWhere = ""
        If String.IsNullOrEmpty(DtStar.Text.Trim) = False Then
            strWhere = strWhere & " and A.Intime >= N'" & Me.DtStar.Text.Trim & "' "
        End If

        If String.IsNullOrEmpty(DtEnd.Text.Trim) = False Then
            strWhere = strWhere & " and A.Intime <= N'" & Me.DtEnd.Text.Trim & "' "
        End If
        If String.IsNullOrEmpty(CobMo.Text.Trim) = False Then
            strWhere = strWhere & " and A.moid = N'" & Me.CobMo.Text.Trim & "' "
        End If

        If String.IsNullOrEmpty(CobPPID.Text.Trim) = False Then
            strWhere = strWhere & " and A.PPID =N'" & Me.CobPPID.Text.Trim & "' "
        End If
        SearchRecord(strWhere)

        'If String.IsNullOrEmpty(txtuserid.Text.Trim) = False Then
        '    strWhere = strWhere & " and userid like N'%" & Me.txtuserid.Text.Trim & "%' "
        'End If

        'If String.IsNullOrEmpty(txtIntime.Text.Trim) = False Then
        '    strWhere = strWhere & " and CONVERT(varchar(10), Intime,121) like N'%" & Me.txtIntime.Text.Trim & "%'"
        'End If
    End Sub
    Public Function CheckDate()
        If DtStar.Value > Me.DtEnd.Value Then
            MsgBox("起始時間不能大於結束時間!", 48, "提示")
            DtStar.Value = DateAdd(DateInterval.Day, -1, Now())
            DtEnd.Value = Now()
            Return False
        End If

        If DtStar.Value < "2020-01-01" Then
            MsgBox("起始時間不能小於2020-01-01!", 48, "提示")
            DtStar.Value = DateAdd(DateInterval.Day, -1, Now())
            Return False
        End If

        Dim startDate As DateTime = DateTime.Parse(DtStar.Text)
        Dim endDate As DateTime = DateTime.Parse(DtEnd.Text)
        If startDate.AddMonths(2) < endDate Then
            MsgBox("查询时间相隔最多请不要超过2天", 48, "提示")
            Me.DtStar.Value = DateAdd(DateInterval.Month, -1, endDate)
            Return False
        End If

        If (String.IsNullOrEmpty(Me.CobFactory.Text.Trim())) Then
            MsgBox("请选择工厂", 48, "提示")
            Return False
        End If

        'If (String.IsNullOrEmpty(Me.CobMo.Text.Trim()) And String.IsNullOrEmpty(Me.CobPPID.Text.Trim())) Then
        '    MsgBox("请输入查询条件", 48, "提示")
        '    Return False
        'End If

        Return True
    End Function

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        ExcelUtils.LoadDataToExcel(Me.DgScanData, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub
    '产品清除
    Private Sub toolsProductDelete_Click(sender As Object, e As EventArgs) Handles toolsProductDelete.Click
        '按选择产品删除
        SetMessage("", False)
        If (Me.DgScanData.SelectedRows.Count = 0) Then
            SetMessage("请选择要删除数据", False)
            Return
        End If

        If (String.IsNullOrEmpty(Me.DgScanData.CurrentRow.Cells("ppid").Value.ToString.Trim)) Then
            SetMessage("选择删除产品条码不能为空！", False)
            Return
        End If

        If (MsgBox("你确定删除该产品选择工站扫描记录（该功能只适合删除非装配工站扫描记录删除）!", 4 + 32) = MsgBoxResult.No) Then
            Return
        End If
        Dim drGetResult As SqlDataReader = Nothing
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

        Try

            Dim strSQL As String
            Dim strMOId As String
            Dim strBarCode As String
            Dim strStationId As String
            Dim strStationName As String
            Dim strHandleType As String

            strMOId = Me.DgScanData.CurrentRow.Cells("moid").Value.ToString().ToUpper().Replace("'", "''")
            strBarCode = Me.DgScanData.CurrentRow.Cells("ppid").Value.ToString().ToUpper().Replace("'", "''")
            strStationId = Me.DgScanData.CurrentRow.Cells("Stationid").Value.ToString().ToUpper().Replace("'", "''")
            strStationName = Me.DgScanData.CurrentRow.Cells("Stationname").Value.ToString().ToUpper().Replace("'", "''")
            strHandleType = "0"
            Dim h As DataTable = Conn.GetDataTable("select *FROM m_Cartonsn_t  WHERE ppid='" + strBarCode + "'")
            If (h.Rows.Count >= 1) Then
                MessageBox.Show("你要删除的产品在包装已经扫描，请先删除包装记录", "请核实", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                     " EXECUTE Exec_PpidExceptionHandle @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'," & _
                     "'" & SysMessageClass.UseId & "','" & strMOId & "','" & strStationId & "','" & strStationName & "','" & strBarCode & "','" & strHandleType.Replace("'", "''") & "'" & _
                     " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "

            Dim drGetSQLRecor As SqlDataReader = Conn.GetDataReader(strSQL)

            If drGetSQLRecor.HasRows Then
                drGetSQLRecor.Read()
                Select Case drGetSQLRecor(0).ToString()
                    Case "0"
                        SetMessage(drGetSQLRecor(1).ToString(), False)
                    Case "1"
                        SetMessage("删除成功!", True)
                End Select
            End If

            drGetResult = Nothing
            Conn.PubConnection.Close()

            ToolReflsh_Click(Nothing, Nothing)
        Catch ex As Exception
            drGetResult.Close()
            Conn.PubConnection.Close()
            SetMessage("删除异常", False)
        End Try
    End Sub

    Private Sub toolsMODelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolsMODelete.Click
        '按工单删除
        SetMessage("", False)
        If (Me.DgScanData.SelectedRows.Count = 0) Then
            SetMessage("请选择要删除数据", False)
            Return
        End If

        If (String.IsNullOrEmpty(Me.DgScanData.CurrentRow.Cells("moid").Value.ToString.Trim)) Then
            SetMessage("选择删除工单不能为空!", False)
            Return
        End If

        If (MsgBox("你确定删除该工单成品扫描记录（该功能只适合删除非装配工站扫描记录删除）!", 4 + 32) = MsgBoxResult.No) Then
            Return
        End If

        Dim drGetResult As SqlDataReader = Nothing
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strMOId As String
            Dim strBarCode As String
            Dim strStationId As String
            Dim strStationName As String
            Dim strHandleType As String

            strMOId = Me.DgScanData.CurrentRow.Cells("moid").Value.ToString().ToUpper().Replace("'", "''")
            strBarCode = Me.DgScanData.CurrentRow.Cells("ppid").Value.ToString().ToUpper().Replace("'", "''")
            strStationId = Me.DgScanData.CurrentRow.Cells("Stationid").Value.ToString().ToUpper().Replace("'", "''")
            strStationName = Me.DgScanData.CurrentRow.Cells("Stationname").Value.ToString().ToUpper().Replace("'", "''")
            strHandleType = "1"
            strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                     " EXECUTE Exec_PpidExceptionHandle @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'," & _
                     "'" & SysMessageClass.UseId & "','" & strMOId & "','" & strStationId & "','" & strStationName & "','" & strBarCode & "','" & strHandleType.Replace("'", "''") & "'" & _
                     " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "
            Dim drGetSQLRecor As SqlDataReader = Conn.GetDataReader(strSQL)
            If drGetSQLRecor.HasRows Then
                drGetSQLRecor.Read()
                Select Case drGetSQLRecor(0).ToString()
                    Case "0"
                        SetMessage(drGetSQLRecor(1).ToString(), False)
                    Case "1"
                        SetMessage("删除成功!", True)
                End Select
            End If

            drGetResult = Nothing
            Conn.PubConnection.Close()

            ToolReflsh_Click(Nothing, Nothing)
        Catch ex As Exception
            drGetResult.Close()
            Conn.PubConnection.Close()
            SetMessage("删除异常", False)
        End Try
    End Sub
    Private Sub SetMessage(ByVal Message As String, ByVal Type As Boolean)
        If (Type) Then
            Me.lblMessage.ForeColor = Color.Green
        Else
            Me.lblMessage.ForeColor = Color.Red
        End If
        Me.lblMessage.Text = Message
    End Sub
#End Region

End Class