
'--生产排程更新
'--Create by :　马锋
'--Create date :　2015/12/10
'--Ver : V01
'--Update date :  
'--

#Region "Imports"

Imports System.Windows.Forms
Imports System.Management
Imports System.Resources
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
'Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports Aspose.Cells
Imports MainFrame
Imports SysBasicClass

#End Region

Public Class FrmProductionPlanUpdate

#Region "变量声明"

    Dim _strTransactionId As String
    Dim _dtVisiableColumn As DataTable
    Dim _ProductionPlanList As DataTable
    Private Plantable As DataTable

    Private Shared FactoryID As String = VbCommClass.VbCommClass.Factory
    Private Shared ProfitCenter As String = VbCommClass.VbCommClass.profitcenter
    Private Shared userID As String = VbCommClass.VbCommClass.UseId
    Private Shared IsConSap As String = VbCommClass.VbCommClass.IsConSap

    Public Property TransactionId() As String
        Get
            Return _strTransactionId
        End Get

        Set(value As String)
            _strTransactionId = value
        End Set
    End Property
    Public Property dtVisiableColumn() As DataTable
        Get
            If (_dtVisiableColumn Is Nothing) Then
                _dtVisiableColumn = New DataTable()
                _dtVisiableColumn.Columns.Add("ColumnId", Type.GetType("System.String"))
                _dtVisiableColumn.Columns.Add("ColumnName", Type.GetType("System.String"))
                _dtVisiableColumn.Columns.Add("VisiableType", Type.GetType("System.String"))
                _dtVisiableColumn.Columns.Add("VisiableFlag", Type.GetType("System.Boolean"))
            End If
            Return _dtVisiableColumn
        End Get

        Set(ByVal Value As DataTable)
            _dtVisiableColumn = Value
        End Set
    End Property

    Public Property ProductionPlanList() As DataTable
        Get
            If (_ProductionPlanList Is Nothing) Then
                _ProductionPlanList = New DataTable()
                Dim dc As DataColumn
                dc = _ProductionPlanList.Columns.Add("RowNum", Type.GetType("System.Int32"))
                dc.AutoIncrement = True
                dc.AutoIncrementSeed = 1
                dc.AutoIncrementStep = 1
                dc.AllowDBNull = False
                _ProductionPlanList.Columns.Add("TransactionId", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("MaterialNO", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("MOId", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DeptName", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("LineName", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("ProductionQuantity", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("CustomerName", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("UnfinishedQuantity", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("ExpectedDate", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("SingleDay", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("StandardWorkingHours", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("ManpowerNumber", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("Effectiveness", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("EstimatedDays", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("ExpectedCapacity", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("ProductionDays", Type.GetType("System.String"))

                _ProductionPlanList.Columns.Add("WKone", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("WKtwo", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("NOYieldQuantity", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("LineUserName", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("Remark", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkOne", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkTwo", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkThree", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkFour", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkFive", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorksix", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkseven", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkEight", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkNine", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkTen", Type.GetType("System.String"))

                _ProductionPlanList.Columns.Add("DailyWorkEleven", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkTwelve", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkThirteen", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkFourteen", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkFifteen", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkSixteen", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkSeveteen", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkEighteen", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkNineteen", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkTwenty", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkTwentyone", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkTwentytwo", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkTwentythree", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkTwentyfour", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkTwentyfive", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkTwentysix", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkTwentyseven", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkTwentyeight", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkTwentynine", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkThirty", Type.GetType("System.String"))
                _ProductionPlanList.Columns.Add("DailyWorkThirtyone", Type.GetType("System.String"))
            End If
            Return _ProductionPlanList
        End Get

        Set(ByVal Value As DataTable)
            _ProductionPlanList = Value
        End Set
    End Property

#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _TransactionId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        TransactionId = _TransactionId
    End Sub

#End Region

#Region "加载"

    Private Sub FrmProductionPlanUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dateTimeTemp As DateTime
            dateTimeTemp = DateTime.Now
            Me.dtpStartDate.Text = dateTimeTemp.AddDays(-6)
            Me.dtpEndDate.Text = dateTimeTemp.AddDays(1)
            chkDate.Checked = True
            'With Me.dgvProductionPlanItem
            '    .AutoResizeColumns()
            '    .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            '    .ScrollBars = ScrollBars.Both
            'End With
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "事件"
    '查询
    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Plantable = New DataTable
        GetMesData.SetMessage(Me.lblMessage, "", False)

        LoadData()
    End Sub

    '导入
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Dim sdfimport As New OpenFileDialog
        sdfimport.Filter = "Excel文件|*.xls;*.xlsx;*.csv"
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If (sdfimport.ShowDialog() <> DialogResult.OK) Then
            Return
        End If
        Dim filename As String = ""
        Dim errorMsg As String = ""
        filename = sdfimport.FileName

        '取得用户上传表数据 (5:代表5列数据)
        Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 28, errorMsg)
        If dtUploadData.Rows.Count < 1 Then
            GetMesData.SetMessage(Me.lblMessage, "没有需要汇入的数据", False)
        Else
            If CheckData(dtUploadData) Then
                If (UploadData(dtUploadData)) Then
                    LoadData()
                    GetMesData.SetMessage(Me.lblMessage, "汇入计划成功！", True)
                End If

            End If
        End If
    End Sub

    '导出
    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Plantable Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "没有需要汇出的数据", False)
            Exit Sub
        End If

        If Plantable.Rows.Count > 0 Then
            LoadDataToExcel1(dgvProductionPlanItem, "ProductionPlan_" & Format(DateTime.Now.Date, "yyyy-MM-dd"))
        Else
            GetMesData.SetMessage(Me.lblMessage, "没有需要汇出的数据", False)
        End If

    End Sub

    '导入工单
    Private Sub toolMO_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Dim sdfimport As New OpenFileDialog
        sdfimport.Filter = "Excel文件|*.xls;*.xlsx;*.csv"
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If (sdfimport.ShowDialog() <> DialogResult.OK) Then
            Return
        End If
        Dim filename As String = ""
        Dim errorMsg As String = ""
        filename = sdfimport.FileName
        Dim strsql As StringBuilder = New StringBuilder
        Dim Arrmo As ArrayList = New ArrayList
        Try
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 2, errorMsg)

            If dtUploadData.Rows.Count > 50 Then
                GetMesData.SetMessage(Me.lblMessage, "汇入的数据不能超过50个工单！", False)
                Return

            End If
            If dtUploadData.Rows.Count < 1 Then
                GetMesData.SetMessage(Me.lblMessage, "没有需要汇入的数据", False)
            Else
                For index = 1 To dtUploadData.Rows.Count - 1
                    Dim strmoid As String = If(IsDBNull(dtUploadData.Rows(index)(0)), "", dtUploadData.Rows(index)(0).ToString)
                    Dim strpartid As String = If(IsDBNull(dtUploadData.Rows(index)(1)), "", dtUploadData.Rows(index)(1).ToString)
                    If String.IsNullOrEmpty(strmoid) Then
                        GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行工单为空", False)
                        Exit Sub
                    End If
                    If strmoid.Length < 10 Then
                        GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行工单不正确", False)
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(strpartid) Then
                        GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行主料为空", False)
                        Exit Sub
                    End If

                    If CheckSapMoidData(strmoid, strpartid) = False Then
                        Exit Sub
                    End If

                    Arrmo.Add(strmoid)
                    strsql.AppendLine("BEGIN IF NOT EXISTS (SELECT MOID FROM m_MoidAlter_t WHERE Moid='" + strmoid.Trim + "' and remark ='planmo' )")
                    strsql.AppendLine("INSERT INTO m_MoidAlter_t(MOID,PARTID,FACTORYID,PROFITCENTER,STATUS,USERID,REMARK,intime) VALUES(")
                    strsql.AppendLine("'" & strmoid.Trim & "','" & strpartid & "','" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','N','" & VbCommClass.VbCommClass.UseId & "','planmo',getdate()) end")
                Next
                DbOperateUtils.ExecSQL(strsql.ToString())

                Dim Sqlstr As String

                If IsConSap = "Y" Then
                    Sqlstr = "DECLARE  @RTVALUE varchar(1), @RTMSG nvarchar(128)"
                    Sqlstr = Sqlstr + " EXEC	 [dbo].[GetTiptopMainMoSap] @RTVALUE = @RTVALUE OUTPUT, @RTMSG = @RTMSG OUTPUT, @FACTORYID = N'" & VbCommClass.VbCommClass.Factory & "', @PROFITCENTER = N'" & VbCommClass.VbCommClass.profitcenter & "',"
                    Sqlstr = Sqlstr + "@USERID = N'" & VbCommClass.VbCommClass.UseId & "'SELECT	@RTMSG  ,@RTVALUE  "
                Else
                    Sqlstr = "DECLARE  @RTVALUE varchar(1), @RTMSG nvarchar(128)"
                    Sqlstr = Sqlstr + " EXEC	 [dbo].[GetTiptopMainMo] @RTVALUE = @RTVALUE OUTPUT, @RTMSG = @RTMSG OUTPUT, @FACTORYID = N'" & VbCommClass.VbCommClass.Factory & "', @PROFITCENTER = N'" & VbCommClass.VbCommClass.profitcenter & "',"
                    Sqlstr = Sqlstr + "@USERID = N'" & VbCommClass.VbCommClass.UseId & "'SELECT	@RTMSG  ,@RTVALUE  "
                End If

                Dim RecDr As DataTable
                RecDr = DbOperateUtils.GetDataTable(Sqlstr)
                Dim ReturnFlag As String = ""
                Dim retval As String = ""
                If RecDr.Rows.Count > 0 Then
                    ReturnFlag = RecDr.Rows(0)(0)
                    retval = RecDr.Rows(0)(1)
                    If retval <> "1" Then
                        GetMesData.SetMessage(Me.lblMessage, ReturnFlag, False)
                    Else
                        Dim strmos As StringBuilder = New StringBuilder
                        For Each mo As String In Arrmo
                            strmos.AppendLine(mo)
                        Next
                        Me.txtmo.Text = strmos.ToString
                        LoadData()
                        GetMesData.SetMessage(Me.lblMessage, "上传工单成功!", True)
                    End If
                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "导入失败!", False)
        End Try
    End Sub

    '退出 
    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    '工单全选
    Private Sub txtmo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtmo.KeyUp
        If (e.Modifiers = Keys.Control And e.KeyCode = Keys.A) Then
            txtmo.SelectAll()
        End If
    End Sub

    '重置工单按钮
    Private Function CheckSapMoidData(moid As String, strpartid As String) As Boolean
        Try

            Dim Sqlstr As String
            Sqlstr = "DECLARE  @RTVALUE varchar(1), @RTMSG nvarchar(128)"
            Sqlstr = Sqlstr + " EXEC [dbo].[GetTiptopMainMoSapCheck] @RTVALUE  OUTPUT, @RTMSG OUTPUT,N'{0}','{1}','{2}'"
            Sqlstr = String.Format(Sqlstr, moid, strpartid, VbCommClass.VbCommClass.Factory)
            Sqlstr = Sqlstr + " SELECT	@RTMSG  ,@RTVALUE  "

            Dim RecDr As DataTable = DbOperateUtils.GetDataTable(Sqlstr)

            Dim ReturnFlag As String = ""
            Dim retval As String = ""
            If RecDr.Rows.Count > 0 Then
                ReturnFlag = RecDr.Rows(0)(0)
                retval = RecDr.Rows(0)(1)
                If retval <> "1" Then
                    GetMesData.SetMessage(Me.lblMessage, ReturnFlag, False)
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查SAP中间表数据失败!", False)
        End Try
    End Function

    '重置工单按钮
    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        Try
            Dim mos As String = Nothing
            For Each sMo As String In txtmo.Text.Trim.ToUpper.Split(CChar(vbNewLine))
                If Not String.IsNullOrEmpty(sMo) Then
                    mos &= sMo.ToUpper.Trim & ","
                End If
            Next

            Dim Sqlstr As String
            Sqlstr = Sqlstr + " EXEC [dbo].[DeleteJobMoidData] @MOID = N'" & mos & "'"

            Dim RecDr As DataTable = DbOperateUtils.GetDataTable(Sqlstr)

            Dim ReturnFlag As String = ""
            Dim retval As String = ""
            If RecDr.Rows.Count > 0 Then
                ReturnFlag = RecDr.Rows(0)(0)
                retval = RecDr.Rows(0)(1)
                If retval <> "1" Then
                    GetMesData.SetMessage(Me.lblMessage, ReturnFlag, False)
                Else
                    LoadData()
                    GetMesData.SetMessage(Me.lblMessage, "重置工单成功,请重新导入!", True)
                End If
            End If

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "重置失败!", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadData()
        Try
            'Dim sql As String = String.Empty
            Dim outSql As String = String.Empty
            'sql = "SELECT   row_number() over (order by moid) as RowNum,* FROM [V_TiptopPlanItem] WHERE 1=1 "


            Dim lines As String = Nothing
            For Each sLine As String In txtLineId.Text.Trim.ToUpper.Split(CChar(vbNewLine))
                If Not String.IsNullOrEmpty(sLine) Then
                    lines &= sLine.ToUpper.Trim & ","
                    'lines &= "'" & sLine.ToUpper.Trim & "'" & ","
                End If
            Next
            'If Not String.IsNullOrEmpty(lines) Then
            '    lines = lines.Trim(CChar(","))
            '    'sql = sql + " AND (LineId in (" & lines & ") OR LINEID ='')"
            'End If

            Dim mos As String = Nothing
            For Each sMo As String In txtmo.Text.Trim.ToUpper.Split(CChar(vbNewLine))
                If Not String.IsNullOrEmpty(sMo) Then
                    'mos &= "'" & sMo.ToUpper.Trim & "'" & ","
                    mos &= sMo.ToUpper.Trim & ","
                End If
            Next
            'If Not String.IsNullOrEmpty(mos) Then
            '    mos = mos.Trim(CChar(","))
            '    'sql = sql + " AND (ParentMo in (" & mos & ") )"
            'End If

            Dim isCheckdate As String = "N"
            If chkDate.Checked Then
                isCheckdate = "Y"
                If String.IsNullOrEmpty(dtpStartDate.Text.Trim) Or String.IsNullOrEmpty(dtpEndDate.Text.Trim) Then
                    GetMesData.SetMessage(Me.lblMessage, "请选择日期范围", False)
                    'Else
                    '    sql = sql + " AND actualdate  BETWEEN ('" + dtpStartDate.Text.Trim + "') AND ('" + dtpEndDate.Text.Trim + "')"
                End If
            End If

            If String.IsNullOrEmpty(mos) And String.IsNullOrEmpty(lines) And Not chkDate.Checked Then
                GetMesData.SetMessage(Me.lblMessage, "请至少输入一个查询条件", False)
                Return
            End If

            Dim strSQL As String = " exec [GetTiptopMainMoList]'{0}','{1}','{2}','{3}','{4}','{5}'"
            strSQL = String.Format(strSQL, mos, lines, isCheckdate, dtpStartDate.Text.Trim, dtpEndDate.Text.Trim, IsConSap)
            LoadData(strSQL, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadData(ByVal sql As String, ByVal sort As String)
        Plantable = New DataTable

        Plantable = DbOperateUtils.GetDataTable(sql)
        dgvProductionPlanItem.DataSource = Plantable

        dgvProductionPlanItem.Refresh()
        lblQTY.Text = Plantable.Rows.Count
    End Sub

    Private Function CheckData(ByVal dt As DataTable) As Boolean
        For index = 1 To dt.Rows.Count - 1
            Dim strassign As String = If(IsDBNull(dt.Rows(index)(1)), "", dt.Rows(index)(1).ToString)
            Dim strpartid As String = If(IsDBNull(dt.Rows(index)(3)), "", dt.Rows(index)(3).ToString)
            Dim strmoid As String = If(IsDBNull(dt.Rows(index)(4)), "", dt.Rows(index)(4).ToString)
            Dim strchildpart As String = If(IsDBNull(dt.Rows(index)(5)), "", dt.Rows(index)(5).ToString)
            Dim strprdline As String = If(IsDBNull(dt.Rows(index)(14)), "", dt.Rows(index)(14).ToString)
            Dim strmanpower As String = If(IsDBNull(dt.Rows(index)(17)), "", dt.Rows(index)(17).ToString)
            Dim streffect As String = If(IsDBNull(dt.Rows(index)(18)), "", dt.Rows(index)(18).ToString)
            Dim strworkhour As String = If(IsDBNull(dt.Rows(index)(19)), "", dt.Rows(index)(19).ToString)
            Dim strshipdate As String = If(IsDBNull(dt.Rows(index)(20)), "", dt.Rows(index)(20).ToString)
            Dim strstatus As String = If(IsDBNull(dt.Rows(index)(26)), "", dt.Rows(index)(26).ToString)
            Dim strpmoid As String = If(IsDBNull(dt.Rows(index)(27)), "", dt.Rows(index)(27).ToString)
            If String.IsNullOrEmpty(strassign) Then
                GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行派工日期为空", False)
                Return False
            End If
            If Not IsDate(strassign) Then
                GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行派工日期必须是日期", False)
                Return False
            End If
            If String.IsNullOrEmpty(strpartid) Then
                GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行主料为空", False)
                Return False
            End If
            If String.IsNullOrEmpty(strmoid) Then
                GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行工单为空", False)
                Return False
            End If
            If String.IsNullOrEmpty(strchildpart) Then
                GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行子料为空", False)
                Return False
            End If
            If String.IsNullOrEmpty(strprdline) Then
                GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行生产线体为空", False)
                Return False
            End If
            'If String.IsNullOrEmpty(strmanpower) Then
            '    GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行人力为空", False)
            '    Return False
            'End If
            'If String.IsNullOrEmpty(streffect) Then
            '    GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行效率为空", False)
            '    Return False
            'End If
            'If String.IsNullOrEmpty(strworkhour) Then
            '    GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行所需工时为空", False)
            '    Return False
            'End If
            'If String.IsNullOrEmpty(strshipdate) Then
            '    GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行出货日期为空", False)
            '    Return False
            'End If
            'If strshipdate.Length >= 10 Then
            '    strshipdate = strshipdate.Substring(0, 9)
            'End If
            'If Not IsDate(strshipdate) Then
            '    GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行出货日期必须是日期", False)
            '    Return False
            'End If
            If String.IsNullOrEmpty(strstatus) Then
                GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行状态为空", False)
                Return False
            End If
            If String.IsNullOrEmpty(strpmoid) Then
                GetMesData.SetMessage(Me.lblMessage, "第 " + (index + 1).ToString + " 行上级工单为空", False)
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub LoadDataToExcel1(ByVal DgMoData As DataGridView, ByVal tbname As String, Optional ByVal strDirectory As String = "")
        Try

            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim wb = New Aspose.Cells.Workbook()
            Dim style = wb.Styles(wb.Styles.Add())
            style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
            style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0)
            style.Pattern = BackgroundType.Solid
            style.Font.IsBold = True

            Dim getTable As New DataTable
            getTable.TableName = tbname

            getTable = DgMoData.DataSource

            Dim strpath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            'Environment.SpecialFolder.Desktop()
            'If Not Directory.Exists("c:\MesExport") Then
            '    Directory.CreateDirectory("c:\MesExport")
            'End If
            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            '写入标题行
            For comIndex As Integer = 0 To DgMoData.ColumnCount - 1
                Dim columnName As String = DgMoData.Columns(comIndex).HeaderText
                wb.Worksheets(0).Cells(0, comIndex).PutValue(columnName)
                wb.Worksheets(0).Cells(0, comIndex).SetStyle(style)
                wb.Worksheets(0).AutoFitColumn(comIndex, 0, 150)
            Next
            nColqty = 1
            For Each r As DataRow In getTable.Rows
                For comIndex As Integer = 0 To getTable.Columns.Count - 1
                    wb.Worksheets(0).Cells(nColqty, comIndex).PutValue(r(comIndex).ToString())
                Next
                nColqty = nColqty + 1
            Next
            wb.Worksheets(0).FreezePanes(1, 0, 1, getTable.Columns.Count)
            Dim filepath As String = strpath + "\" + tbname + ".xlsx"
            wb.Save(filepath)
            MessageBox.Show("文件导出成功,导出位置：" + tbname + ".xlsx !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function UploadData(ByVal dt As DataTable) As Boolean
        Dim strsql As StringBuilder = New StringBuilder
        Dim strSqlOracle As StringBuilder = New StringBuilder

        Try

            strSqlOracle.AppendLine(" BEGIN")
            For index = 1 To dt.Rows.Count - 1
                Dim strassign As String = If(IsDBNull(dt.Rows(index)(1)), "", dt.Rows(index)(1).ToString)
                Dim strpartid As String = If(IsDBNull(dt.Rows(index)(3)), "", dt.Rows(index)(3).ToString)

                Dim strmoid As String = If(IsDBNull(dt.Rows(index)(4)), "", dt.Rows(index)(4).ToString)
                Dim strchildpart As String = If(IsDBNull(dt.Rows(index)(5)), "", dt.Rows(index)(5).ToString)
                Dim strmoqty As String = If(IsDBNull(dt.Rows(index)(8)), "", dt.Rows(index)(8).ToString)
                Dim strprdline As String = If(IsDBNull(dt.Rows(index)(14)), "", dt.Rows(index)(14).ToString)
                Dim strmanpower As String = If(IsDBNull(dt.Rows(index)(17)), "", dt.Rows(index)(17).ToString)
                Dim streffect As String = If(IsDBNull(dt.Rows(index)(18)), "", dt.Rows(index)(18).ToString)
                Dim strworkhour As String = If(IsDBNull(dt.Rows(index)(19)), "", dt.Rows(index)(19).ToString)
                Dim strshipdate As String = If(IsDBNull(dt.Rows(index)(20)), "", dt.Rows(index)(20).ToString)
                Dim stractdeldate As String = If(IsDBNull(dt.Rows(index)(21)), "", dt.Rows(index)(21).ToString)
                Dim strfinishdate As String = If(IsDBNull(dt.Rows(index)(22)), "", dt.Rows(index)(22).ToString)

                Dim strremark As String = If(IsDBNull(dt.Rows(index)(25)), "", dt.Rows(index)(25).ToString)
                Dim strstatus As String = If(IsDBNull(dt.Rows(index)(26)), "", dt.Rows(index)(26).ToString)
                Dim strpmoid As String = If(IsDBNull(dt.Rows(index)(27)), "", dt.Rows(index)(27).ToString)
                'If strshipdate.Length > 10 Then
                '    strshipdate = strshipdate.Substring(0, 9)
                'End If
                If strworkhour = "#N/A" Then
                    strworkhour = ""
                End If
                '新增
                strsql.AppendLine("BEGIN IF NOT EXISTS (SELECT MOID FROM m_TiptopPlanItemUP_t WHERE Moid='" + strmoid + "' AND PartId='" & strchildpart & "')")
                strsql.AppendLine("BEGIN INSERT INTO m_TiptopPlanItemUP_t([Moid],[PartId],[Specification],[ParentMoid],[Quantity],[SQuantity],[LineId],[ManPower],[Effectiveness],[WorkingHours],[DeliveryTime],[ActualDelivery],[FinishDate],[Remark],[CreateTime],[CreateUserId],[PlanStartTime])")
                strsql.AppendLine(" VALUES ( '" & strmoid & "','" & strchildpart & "',NULL,'" & strpmoid & "','" & strmoqty & "','" & strmoqty & "',N'" & strprdline & "',")
                strsql.AppendLine("'" & strmanpower & "','" & streffect & "','" & strworkhour & "','" & strshipdate & "',N'" & stractdeldate & "',N'" & strfinishdate & "',N'" & strremark & "',getdate(),'" & VbCommClass.VbCommClass.UseId & "','" & strassign & "')  ")
                If strmoid <> strpmoid Then '只更新子工单线体
                    strsql.AppendLine(" UPDATE m_tiptopdownmo_t SET LINEID='" & strprdline & "' WHERE Moid='" & strmoid & "'")
                End If
                strsql.AppendLine(" END ELSE BEGIN UPDATE   m_TiptopPlanItemUP_t SET LineId='" & strprdline & "',ManPower='" & strmanpower & "',Effectiveness='" & streffect & "',WorkingHours='" & strworkhour & "',DeliveryTime='" & strshipdate & "',")
                strsql.AppendLine(" ActualDelivery=N'" & stractdeldate & "',FinishDate=N'" & strfinishdate & "',Remark=N'" & strremark & "' ,UpdateTime=getdate(),UpdateUserId='" & VbCommClass.VbCommClass.UseId & "'")
                strsql.AppendLine(" WHERE MOID='" & strmoid & "' AND PartId='" & strchildpart & "'  END  END;")

                '更新ORACLE数据
                If VbCommClass.VbCommClass.IsConSap = "Y" Then
                    strSqlOracle.AppendLine("     MERGE INTO ZTMM0020 T1")
                    strSqlOracle.AppendFormat("   USING (SELECT '{0}' moid,'{1}' partid FROM DUAL) T2", strmoid, strchildpart)
                    strSqlOracle.AppendLine("     ON (T1.moid = T2.moid AND T1.partid = T2.partid)")
                    strSqlOracle.AppendLine("     WHEN MATCHED THEN")
                    strSqlOracle.AppendFormat("       UPDATE SET T1.LINEID = '{0}' WHERE moid = '{1}' and partid = '{2}'", strprdline, strmoid, strchildpart)
                    strSqlOracle.AppendLine("     WHEN NOT MATCHED THEN")
                    strSqlOracle.AppendLine("     INSERT (Moid,PartId,MOQty,LineId,Parentmo,profitcenter,Remark) ")
                    strSqlOracle.AppendFormat("   VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}'); ",
                                                  strmoid, strchildpart, strmoqty, strprdline, strpmoid, FactoryID, strremark)
                    strSqlOracle.AppendLine()
                End If
            Next

            DbOperateUtils.ExecSQL(strsql.ToString())

            '更新
            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                strSqlOracle.AppendLine(" COMMIT;")
                strSqlOracle.AppendLine(" END;")
                OracleOperateUtils.ExecuteNonQuerySap(strSqlOracle.ToString)
            End If

            Return True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更新失败!", False)
            Return False
        End Try
    End Function

    Private Sub dgvProductionPlanItem_CellEnter(sender As Object, e As DataGridViewCellEventArgs)
        Dim dgv As DataGridView = sender
        If Not (dgv Is Nothing) Then
            If (dgv.Columns(e.ColumnIndex).Name = "ActualLine") AndAlso dgv.Columns(e.ColumnIndex).CellType.Name = "DataGridViewComboBoxCell" Then
                SendKeys.Send("{F4}") '选中ComboBox列时，相当于按了键盘的F4键
            End If
        End If

    End Sub

#End Region

 
End Class