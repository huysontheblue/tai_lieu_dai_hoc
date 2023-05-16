
'--生产排程维护
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
Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports Aspose.Cells
#End Region

Public Class FrmProductionPlanMaster

#Region "变量声明"

    Dim _strTransactionTypeName As String
    Dim _strSavaType As String              '保存类型，暂取消
    Dim dateTimeTemp As DateTime
    Dim SaveFlag As Boolean = False
    Dim _strTransactionId As String
    Dim _ProductionPlanList As DataTable
    Dim _StatusFlag As String            '单据审核状态
    Dim _ScanTransactionId As String     '新增临时扫描物料条码
    Shared _dtVisiableColumn As DataTable

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
                _ProductionPlanList.Columns.Add("StatusFlag", Type.GetType("System.String"))
            End If
            Return _ProductionPlanList
        End Get

        Set(ByVal Value As DataTable)
            _ProductionPlanList = Value
        End Set
    End Property

    Public Property TransactionId() As String
        Get
            Return _strTransactionId
        End Get

        Set(value As String)
            _strTransactionId = value
        End Set
    End Property

    Public Property StatusFlag() As String
        Get
            Return _StatusFlag
        End Get

        Set(value As String)
            _StatusFlag = value
        End Set
    End Property

    Public Property ScanTransactionId() As String
        Get
            Return _ScanTransactionId
        End Get

        Set(value As String)
            _ScanTransactionId = value
        End Set
    End Property

    Public Shared Property dtVisiableColumn() As DataTable
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

#Region "加载事件"

    Private Sub FrmProductionPlanMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvProductionPlanItem.AutoGenerateColumns = False
            LoadControlData()
            GetMesData.GetPlanMonthDayColumnName(dateTimeTemp.Year, dateTimeTemp.Month, Me.dgvProductionPlanItem, 22, lblMessage)
            GetMesData.GetDataGridXColumn(dgvProductionPlanItem, dtVisiableColumn, lblMessage)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub btnInsertRow_Click(sender As Object, e As EventArgs) Handles btnInsertRow.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            Dim drAdd As DataRow = ProductionPlanList.NewRow()
            ProductionPlanList.Rows.Add(drAdd)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增行异常", False)
        End Try
    End Sub

    Private Sub btnDeleteRow_Click(sender As Object, e As EventArgs) Handles btnDeleteRow.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If (StatusFlag = "1") Then
            GetMesData.SetMessage(Me.lblMessage, "已审核数据不允许编辑", False)
            Exit Sub
        End If

        If Me.dgvProductionPlanItem.Rows.Count = 0 OrElse Me.dgvProductionPlanItem.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要删除行", False)
            Exit Sub
        End If
        Try
            Dim strMaterialNO As String

            strMaterialNO = Me.dgvProductionPlanItem.Rows(Me.dgvProductionPlanItem.CurrentRow.Index).Cells("MATERIALNO").Value.ToString

            If (String.IsNullOrEmpty(TransactionId)) Then
                If (String.IsNullOrEmpty(strMaterialNO)) Then
                    GetMesData.SetMessage(Me.lblMessage, "获取删除行料号失败", False)
                    Exit Sub
                End If
                ProductionPlanList.Rows.RemoveAt(Me.dgvProductionPlanItem.CurrentRow.Index)
                ProductionPlanList.AcceptChanges()
                Me.dgvProductionPlanItem.Update()
            Else
                'If (Not CheckDelete(strMaterialNO)) Then
                '    Exit Sub
                'End If

                Dim strSQL As New StringBuilder
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
                Try
                    strSQL.AppendLine(" UPDATE m_ProductionPlanItem_t SET DeleteFlag='1' WHERE TransactionId = '" & TransactionId & "' AND MaterialNO='" & strMaterialNO & "' ")

                    Conn.ExecSql(strSQL.ToString)
                    Conn.PubConnection.Close()

                    Me.dgvProductionPlanItem.DataSource = GetMesData.GetProductionPlanItem(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)
                Catch ex As Exception
                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If
                    GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
                End Try
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub btnImportRow_Click(sender As Object, e As EventArgs) Handles btnImportRow.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            Dim strFilePath As String
            Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
            openFileDialog.Filter = "Execl文件|*.xls;*.xlsx"
            openFileDialog.Multiselect = False
            openFileDialog.Title = "选择计划导入Execl文件"
            If (openFileDialog.ShowDialog() = DialogResult.OK) Then
                strFilePath = openFileDialog.FileName
                Dim strMsg As String = ""
                If (Not String.IsNullOrEmpty(strFilePath)) Then
                    'dt.Columns.Add("column1", typeof(string));
                    'aCell.ExportDataTable(dt, 0, 0, 1000, True)
                    Dim dtLoadData As DataTable = GetMesData.ExportFromExcelByAs(strFilePath, 0, 0, 0, strMsg)

                    If (Not String.IsNullOrEmpty(strMsg)) Then
                        GetMesData.SetMessage(lblMessage, strMsg, False)
                        Exit Sub
                    End If

                    GetFormatLoadData(dtLoadData, ProductionPlanList)
                    Me.dgvProductionPlanItem.DataSource = ProductionPlanList
                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "导入异常，请确认导入格式", False)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)

        'If (StatusFlag = "1") Then
        '    GetMesData.SetMessage(Me.lblMessage, "已审核数据不允许编辑", False)
        '    Exit Sub
        'End If

        Try
            If Not (CheckSave()) Then
                Exit Sub
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查异常", False)
            Exit Sub
        End Try

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            If (String.IsNullOrEmpty(TransactionId)) Then
                TransactionId = ""
            End If

            strSQL.AppendLine(" DECLARE @InvoiceNO AS VARCHAR(32) SET @InvoiceNO = CONVERT(VARCHAR, GETDATE(), 120) ")
            If (String.IsNullOrEmpty(TransactionId)) Then
                strSQL.AppendLine(" INSERT INTO m_ProductionPlan_t(FactoryId, Profitcenter, TransactionId, PlanMonth, OrderNumber, DeptId, DeptName, Remark, StatusFlag, DeleteFlag, CreateTime, CreateUser) VALUES(")
                strSQL.AppendLine(" '" & VbCommClass.VbCommClass.Factory & "', '" & VbCommClass.VbCommClass.profitcenter & "',  @InvoiceNO, '" & Me.dtpInvoiceDate.Text.Trim & "', '" & Me.mtxtOrderNumber.Text.Trim & "', '" & Me.cboDept.SelectedValue & "', N'" & Me.cboDept.Text.Trim & "', N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "', '1', '0', getdate(), '" & VbCommClass.VbCommClass.UseId & "')")
            Else
                strSQL.AppendLine(" UPDATE m_ProductionPlan_t SET OrderNumber = '" & Me.mtxtOrderNumber.Text.Trim & "', DeptId = '" & Me.cboDept.SelectedValue & "', DeptName = N'" & Me.cboDept.Text.Trim & "', Remark = N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "' ")
                strSQL.AppendLine(" WHERE TransactionId = '" & TransactionId & "' AND FactoryId = '" & VbCommClass.VbCommClass.Factory & "' AND Profitcenter = '" & VbCommClass.VbCommClass.profitcenter & "' ")
            End If

            Dim strMaterialNO As String
            Dim strMOId As String
            Dim strLineName As String
            Dim strDeptName As String
            Dim strProductionQuantity As String
            Dim strCustomerName As String
            Dim strUnfinishedQuantity As String
            Dim strExpectedDate As String
            Dim strSingleDay As String
            Dim strStandardWorkingHours As String
            Dim strManpowerNumber As String
            Dim strEffectiveness As String
            Dim strEstimatedDays As String
            Dim strExpectedCapacity As String
            Dim strProductionDays As String
            Dim strWKone As String
            Dim strWKtwo As String
            Dim strNOYieldQuantity As String
            Dim strRemark As String
            Dim strLineUserName As String
            Dim strDailyWorkOne As String
            Dim strDailyWorkTwo As String
            Dim strDailyWorkThree As String
            Dim strDailyWorkFour As String
            Dim strDailyWorkFive As String
            Dim strDailyWorkSix As String
            Dim strDailyWorkSeven As String
            Dim strDailyWorkEight As String
            Dim strDailyWorkNine As String
            Dim strDailyWorkTen As String
            Dim strDailyWorkEleven As String
            Dim strDailyWorkTwelve As String
            Dim strDailyWorkThirteen As String
            Dim strDailyWorkFourteen As String
            Dim strDailyWorkFifteen As String
            Dim strDailyWorkSixteen As String
            Dim strDailyWorkSeveteen As String
            Dim strDailyWorkEighteen As String
            Dim strDailyWorkNineteen As String
            Dim strDailyWorkTwenty As String
            Dim strDailyWorkTwentyone As String
            Dim strDailyWorkTwentytwo As String
            Dim strDailyWorkTwentythree As String
            Dim strDailyWorkTwentyfour As String
            Dim strDailyWorkTwentyfive As String
            Dim strDailyWorkTwentysix As String
            Dim strDailyWorkTwentyseven As String
            Dim strDailyWorkTwentyeight As String
            Dim strDailyWorkTwentynine As String
            Dim strDailyWorkThirty As String
            Dim strDailyWorkThirtyone As String

            For i As Int16 = 0 To Me.dgvProductionPlanItem.RowCount - 1
                strMaterialNO = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("MaterialNO").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("MaterialNO").Value.ToString.Trim)
                strMOId = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("MOId").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("MOId").Value.ToString.Trim)
                strLineName = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("LineName").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("LineName").Value.ToString.Trim)
                strDeptName = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DeptName").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("DeptName").Value.ToString.Trim)
                strProductionQuantity = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("ProductionQuantity").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("ProductionQuantity").Value.ToString.Trim))
                strCustomerName = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("CustomerName").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("CustomerName").Value.ToString.Trim)
                strUnfinishedQuantity = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("UnfinishedQuantity").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("UnfinishedQuantity").Value.ToString.Trim))
                strExpectedDate = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("ExpectedDate").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("ExpectedDate").Value.ToString.Trim)
                strSingleDay = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("SingleDay").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("SingleDay").Value.ToString.Trim))
                strStandardWorkingHours = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("StandardWorkingHours").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("StandardWorkingHours").Value.ToString.Trim))
                strManpowerNumber = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("ManpowerNumber").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("ManpowerNumber").Value.ToString.Trim))
                strEffectiveness = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("Effectiveness").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("Effectiveness").Value.ToString.Trim))
                strEstimatedDays = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("EstimatedDays").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("EstimatedDays").Value.ToString.Trim))
                strExpectedCapacity = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("ExpectedCapacity").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("ExpectedCapacity").Value.ToString.Trim))
                strProductionDays = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("ProductionDays").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("ProductionDays").Value.ToString.Trim))
                strWKone = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("WKone").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("WKone").Value.ToString.Trim))
                strWKtwo = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("WKtwo").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("WKtwo").Value.ToString.Trim))
                strNOYieldQuantity = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("NOYieldQuantity").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("NOYieldQuantity").Value.ToString.Trim))
                strRemark = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("Remark").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("Remark").Value.ToString.Trim)
                strLineUserName = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("LineUserName").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("LineUserName").Value.ToString.Trim)

                strDailyWorkOne = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkOne").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkOne").Value.ToString.Trim))
                strDailyWorkTwo = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwo").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwo").Value.ToString.Trim))
                strDailyWorkThree = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkThree").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkThree").Value.ToString.Trim))
                strDailyWorkFour = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkFour").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkFour").Value.ToString.Trim))
                strDailyWorkFive = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkFive").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkFive").Value.ToString.Trim))
                strDailyWorkSix = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkSix").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkSix").Value.ToString.Trim))
                strDailyWorkSeven = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkSeven").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkSeven").Value.ToString.Trim))
                strDailyWorkEight = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkEight").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkEight").Value.ToString.Trim))
                strDailyWorkNine = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkNine").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkNine").Value.ToString.Trim))
                strDailyWorkTen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTen").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTen").Value.ToString.Trim))
                strDailyWorkEleven = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkEleven").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkEleven").Value.ToString.Trim))
                strDailyWorkTwelve = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwelve").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwelve").Value.ToString.Trim))
                strDailyWorkThirteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkThirteen").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkThirteen").Value.ToString.Trim))
                strDailyWorkFourteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkFourteen").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkFourteen").Value.ToString.Trim))
                strDailyWorkFifteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkFifteen").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkFifteen").Value.ToString.Trim))
                strDailyWorkSixteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkSixteen").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkSixteen").Value.ToString.Trim))
                strDailyWorkSeveteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkSeveteen").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkSeveteen").Value.ToString.Trim))
                strDailyWorkEighteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkEighteen").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkEighteen").Value.ToString.Trim))
                strDailyWorkNineteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkNineteen").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkNineteen").Value.ToString.Trim))
                strDailyWorkTwenty = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwenty").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwenty").Value.ToString.Trim))
                strDailyWorkTwentyone = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentyone").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentyone").Value.ToString.Trim))
                strDailyWorkTwentytwo = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentytwo").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentytwo").Value.ToString.Trim))
                strDailyWorkTwentythree = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentythree").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentythree").Value.ToString.Trim))
                strDailyWorkTwentyfour = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentyfour").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentyfour").Value.ToString.Trim))
                strDailyWorkTwentyfive = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentyfive").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentyfive").Value.ToString.Trim))
                strDailyWorkTwentysix = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentysix").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentysix").Value.ToString.Trim))
                strDailyWorkTwentyseven = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentyseven").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentyseven").Value.ToString.Trim))
                strDailyWorkTwentyeight = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentyeight").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentyeight").Value.ToString.Trim))
                strDailyWorkTwentynine = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentynine").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkTwentynine").Value.ToString.Trim))
                strDailyWorkThirty = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkThirty").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkThirty").Value.ToString.Trim))
                strDailyWorkThirtyone = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkThirtyone").Value), "0", Me.dgvProductionPlanItem.Rows(i).Cells("DailyWorkThirtyone").Value.ToString.Trim))

                strSQL.AppendLine(" IF NOT EXISTS(SELECT 1 FROM m_ProductionPlanItem_t WHERE TransactionId = '" & TransactionId & "' AND PlanMonth = '" & Me.dtpInvoiceDate.Text.Trim & "' AND MOID = '" & strMOId & "' AND LineName = '" & strLineName & "')  BEGIN")
                strSQL.AppendLine(" INSERT INTO m_ProductionPlanItem_t(TransactionId, PlanMonth, MaterialNO, MOID, LineName, DeptName, ProductionQuantity, CustomerName, UnfinishedQuantity, ExpectedDate, SingleDay, StandardWorkingHours, ManpowerNumber, Effectiveness, ")
                strSQL.AppendLine(" EstimatedDays, ExpectedCapacity, ProductionDays, WKone, WKtwo, NOYieldQuantity, Remark, LineUserName, StatusFlag, DeleteFlag, CreateTime, CreateUser) VALUES(")
                strSQL.AppendLine(" @InvoiceNO, '" & Me.dtpInvoiceDate.Text.Trim & "', '" & strMaterialNO & "', '" & strMOId & "', N'" & strLineName & "', N'" & strDeptName & "', '" & strProductionQuantity & "', N'" & strCustomerName & "', '" & strUnfinishedQuantity & "', '" & strExpectedDate & "', '" & strSingleDay & "', '" & strStandardWorkingHours & "', '" & strManpowerNumber & "', '" & strEffectiveness & "', ")
                strSQL.AppendLine(" '" & strEstimatedDays & "', '" & strExpectedCapacity & "', '" & strProductionDays & "', '" & strWKone & "', '" & strWKtwo & "', '" & strNOYieldQuantity & "', N'" & strRemark & "', N'" & strLineUserName & "', '1', '0', getdate(), '" & VbCommClass.VbCommClass.UseId & "') ")
                strSQL.AppendLine(" END ELSE BEGIN ")
                strSQL.AppendLine(" UPDATE m_ProductionPlanItem_t SET ProductionQuantity='" & strProductionQuantity & "', CustomerName=N'" & strCustomerName & "', UnfinishedQuantity='" & strUnfinishedQuantity & "', ExpectedDate='" & strExpectedDate & "', SingleDay='" & strSingleDay & "', StandardWorkingHours='" & strStandardWorkingHours & "', ManpowerNumber='" & strManpowerNumber & "', Effectiveness='" & strEffectiveness & "', ")
                strSQL.AppendLine(" EstimatedDays='" & strEstimatedDays & "', ExpectedCapacity='" & strExpectedCapacity & "', ProductionDays='" & strProductionDays & "', WKone='" & strWKone & "', WKtwo ='" & strWKtwo & "', NOYieldQuantity='" & strNOYieldQuantity & "', Remark=N'" & strRemark & "', LineUserName=N'" & strLineUserName & "', UpdateTime=GETDATE(), UpdateUser='" & VbCommClass.VbCommClass.UseId & "' ")
                strSQL.AppendLine(" WHERE TransactionId = '" & TransactionId & "' AND PlanMonth = '" & Me.dtpInvoiceDate.Text.Trim & "' AND MOID = '" & strMOId & "' AND LineName = '" & strLineName & "' ")
                strSQL.AppendLine(" END ")

                strSQL.AppendLine(" IF NOT EXISTS(SELECT 1 FROM m_PlanDailyWork_t WHERE TransactionId = '" & TransactionId & "' AND PlanMonth = '" & Me.dtpInvoiceDate.Text.Trim & "' AND MOID = '" & strMOId & "' AND LineName = '" & strLineName & "')  BEGIN ")
                strSQL.AppendLine(" INSERT INTO m_PlanDailyWork_t(TransactionId, PlanMonth, MaterialNO, MOID, LineName, DailyWorkOne, DailyWorkTwo, DailyWorkThree, DailyWorkFour, DailyWorkFive, DailyWorkSix, DailyWorkSeven, DailyWorkEight, DailyWorkNine, DailyWorkTen, ")
                strSQL.AppendLine(" DailyWorkEleven, DailyWorkTwelve, DailyWorkThirteen, DailyWorkFourteen, DailyWorkFifteen, DailyWorkSixteen, DailyWorkSeveteen, DailyWorkEighteen, DailyWorkNineteen, DailyWorkTwenty, DailyWorkTwentyone, ")
                strSQL.AppendLine(" DailyWorkTwentytwo, DailyWorkTwentythree, DailyWorkTwentyfour, DailyWorkTwentyfive, DailyWorkTwentysix, DailyWorkTwentyseven, DailyWorkTwentyeight, DailyWorkTwentynine, DailyWorkThirty, DailyWorkThirtyone) VALUES(")
                strSQL.AppendLine(" @InvoiceNO, '" & Me.dtpInvoiceDate.Text.Trim & "', '" & strMaterialNO & "', '" & strMOId & "', N'" & strLineName & "', '" & strDailyWorkOne & "', '" & strDailyWorkTwo & "', '" & strDailyWorkThree & "', '" & strDailyWorkFour & "', '" & strDailyWorkFive & "', '" & strDailyWorkSix & "', '" & strDailyWorkSeven & "', '" & strDailyWorkEight & "', '" & strDailyWorkNine & "', '" & strDailyWorkTen & "', ")
                strSQL.AppendLine(" '" & strDailyWorkEleven & "', '" & strDailyWorkTwelve & "', '" & strDailyWorkThirteen & "', '" & strDailyWorkFourteen & "', '" & strDailyWorkFifteen & "', '" & strDailyWorkSixteen & "', '" & strDailyWorkSeveteen & "', '" & strDailyWorkEighteen & "', '" & strDailyWorkNineteen & "', '" & strDailyWorkTwenty & "', '" & strDailyWorkTwentyone & "', ")
                strSQL.AppendLine(" '" & strDailyWorkTwentytwo & "', '" & strDailyWorkTwentythree & "', '" & strDailyWorkTwentyfour & "', '" & strDailyWorkTwentyfive & "', '" & strDailyWorkTwentysix & "', '" & strDailyWorkTwentyseven & "', '" & strDailyWorkTwentyeight & "', '" & strDailyWorkTwentynine & "', '" & strDailyWorkThirty & "', '" & strDailyWorkThirtyone & "') ")
                strSQL.AppendLine(" END ELSE BEGIN ")
                strSQL.AppendLine(" UPDATE m_PlanDailyWork_t SET DailyWorkOne='" & strDailyWorkOne & "', DailyWorkTwo='" & strDailyWorkTwo & "', DailyWorkThree='" & strDailyWorkThree & "', DailyWorkFour='" & strDailyWorkFour & "', DailyWorkFive='" & strDailyWorkFive & "', DailyWorkSix='" & strDailyWorkSix & "', ")
                strSQL.AppendLine(" DailyWorkSeven='" & strDailyWorkSeven & "', DailyWorkEight='" & strDailyWorkEight & "', DailyWorkNine='" & strDailyWorkNine & "', DailyWorkTen='" & strDailyWorkTen & "',")
                strSQL.AppendLine(" DailyWorkEleven='" & strDailyWorkEleven & "', DailyWorkTwelve='" & strDailyWorkTwelve & "', DailyWorkThirteen='" & strDailyWorkThirteen & "', DailyWorkFourteen='" & strDailyWorkFourteen & "', DailyWorkFifteen='" & strDailyWorkFifteen & "', DailyWorkSixteen='" & strDailyWorkSixteen & "', DailyWorkSeveteen='" & strDailyWorkSeveteen & "', DailyWorkEighteen='" & strDailyWorkEighteen & "', DailyWorkNineteen='" & strDailyWorkNineteen & "', DailyWorkTwenty='" & strDailyWorkTwenty & "', DailyWorkTwentyone='" & strDailyWorkTwentyone & "', ")
                strSQL.AppendLine(" DailyWorkTwentytwo='" & strDailyWorkTwentytwo & "', DailyWorkTwentythree='" & strDailyWorkTwentythree & "', DailyWorkTwentyfour='" & strDailyWorkTwentyfour & "', DailyWorkTwentyfive='" & strDailyWorkTwentyfive & "', DailyWorkTwentysix='" & strDailyWorkTwentysix & "', DailyWorkTwentyseven='" & strDailyWorkTwentyseven & "', DailyWorkTwentyeight='" & strDailyWorkTwentyeight & "', DailyWorkTwentynine='" & strDailyWorkTwentynine & "', DailyWorkThirty='" & strDailyWorkThirty & "', DailyWorkThirtyone='" & strDailyWorkThirtyone & "' ")
                strSQL.AppendLine(" WHERE TransactionId = '" & TransactionId & "' AND PlanMonth = '" & Me.dtpInvoiceDate.Text.Trim & "' AND MOID = '" & strMOId & "' AND LineName = '" & strLineName & "' ")
                strSQL.AppendLine(" END ")
            Next
            'Else
            '    strSQL.AppendLine(" ")


            If Not (String.IsNullOrEmpty(strSQL.ToString)) Then
                Conn.ExecSql(strSQL.ToString())
            End If

            Conn.PubConnection.Close()
            Me.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "保存异常", False)
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LinkLabelImportFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelImportFile.LinkClicked
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try

            If (Not File.Exists(Application.StartupPath() + "\ProductionPlanTemplate.xlsx")) Then

                Dim template As Byte() = My.Resources.ProductionPlanTemplate
                File.WriteAllBytes(Application.StartupPath() + "\ProductionPlanTemplate.xlsx", template)
            End If
            Process.Start(Application.StartupPath() + "\ProductionPlanTemplate.xlsx")

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "打开模版本文件异常,请确认模文件是否存在！", False)
        End Try
    End Sub

    Private Sub LinklblVisibleColumn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinklblVisibleColumn.LinkClicked
        Try
            Dim ColumnVisiableSetting As New FrmColumnVisiableSetting(dtVisiableColumn)
            ColumnVisiableSetting.ShowDialog()
            GetMesData.GetColumnVisiable(Me.dgvProductionPlanItem, dtVisiableColumn, lblMessage)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If (Me.dgvProductionPlanItem.RowCount > 0) Then
                If (File.Exists(Application.StartupPath() + "\PlanExportTemplate.xlsx")) Then
                    File.Delete(Application.StartupPath() + "\PlanExportTemplate.xlsx")
                End If
                Dim template As Byte() = My.Resources.ProductionPlanTemplate
                File.WriteAllBytes(Application.StartupPath() + "\PlanExportTemplate.xlsx", template)

                Dim workbook As Workbook = New Workbook()
                Dim sheet As Worksheet = workbook.Worksheets(0)
                Dim cells As Cells = sheet.Cells

                Dim styleTitle As Style = workbook.Styles(workbook.Styles.Add())
                styleTitle.HorizontalAlignment = TextAlignmentType.Center
                styleTitle.Font.Name = "Arial"
                styleTitle.Font.Size = 10
                styleTitle.Font.IsBold = True
                styleTitle.VerticalAlignment = TextAlignmentType.Center
                styleTitle.HorizontalAlignment = TextAlignmentType.Center
                styleTitle.BackgroundColor = Color.DodgerBlue
                styleTitle.Borders(BorderType.LeftBorder).LineStyle = CellBorderType.Thin
                styleTitle.Borders(BorderType.RightBorder).LineStyle = CellBorderType.Thin
                styleTitle.Borders(BorderType.TopBorder).LineStyle = CellBorderType.Thin
                styleTitle.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Thin


                Dim styleRow As Style = workbook.Styles(workbook.Styles.Add())
                styleRow.Font.Name = "Arial"
                styleRow.Font.Size = 9
                styleRow.Font.IsBold = False
                styleRow.IsTextWrapped = True
                styleRow.Borders(BorderType.LeftBorder).LineStyle = CellBorderType.Thin
                styleRow.Borders(BorderType.RightBorder).LineStyle = CellBorderType.Thin
                styleRow.Borders(BorderType.TopBorder).LineStyle = CellBorderType.Thin
                styleRow.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Thin

                Dim iColumn As Int16 = 0
                For i As Int16 = 0 To Me.dgvProductionPlanItem.Columns.Count - 1
                    If (Me.dgvProductionPlanItem.Columns(i).Visible = True) Then
                        cells(0, i - iColumn).PutValue(Me.dgvProductionPlanItem.Columns(i).HeaderText)
                        cells(0, i - iColumn).SetStyle(styleTitle)
                        cells.SetRowHeight(0, 25)
                    Else
                        iColumn = iColumn + 1
                    End If
                Next

                Dim cellsValue As String
                For i As Int16 = 0 To Me.dgvProductionPlanItem.RowCount - 1
                    iColumn = 0
                    For k As Int16 = 0 To Me.dgvProductionPlanItem.Columns.Count - 1
                        If (Me.dgvProductionPlanItem.Columns(k).Visible = True) Then
                            cellsValue = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells(k).Value), "", Me.dgvProductionPlanItem.Rows(i).Cells(k).Value.ToString)
                            cells(i + 1, k - iColumn).PutValue(cellsValue)
                            cells(i + 1, k - iColumn).SetStyle(styleRow)
                        Else
                            iColumn = iColumn + 1
                        End If
                    Next
                    'cells.SetRowHeight(2 + i, 24)
                Next

                workbook.Save(Application.StartupPath() + "\PlanExportTemplate.xlsx")
                Process.Start(Application.StartupPath() + "\PlanExportTemplate.xlsx")
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "导出异常", False)
        End Try
    End Sub

    Private Sub dtpInvoiceDate_TextChanged(sender As Object, e As EventArgs) Handles dtpInvoiceDate.TextChanged
        Try
            Dim dateTimeTemp As DateTime
            dateTimeTemp = Convert.ToDateTime(Me.dtpInvoiceDate.Text)
            GetMesData.GetPlanMonthDayColumnName(dateTimeTemp.Year, dateTimeTemp.Month, dgvProductionPlanItem, 22, lblMessage)
            GetMesData.GetDataGridXColumn(dgvProductionPlanItem, dtVisiableColumn, lblMessage)
        Catch ex As Exception
            GetMesData.SetMessage(lblMessage, "加载日期数据异常", False)
        End Try
    End Sub
#End Region

#Region "函数"

    Private Sub LoadControlData()
        Try
            Me.dtpInvoiceDate.Value = Now
            Me.cboDept.DisplayMember = "DeptName"
            Me.cboDept.ValueMember = "DeptCode"
            Me.cboDept.DataSource = GetMesData.GetDeptList(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "")

            If (String.IsNullOrEmpty(_strTransactionId)) Then

                Me.dtpInvoiceDate.Enabled = True
                Me.txtTransactionId.Enabled = True
                Me.cboDept.Enabled = True

                dateTimeTemp = GetMesData.GetDateTime()
                Me.dtpInvoiceDate.Value = dateTimeTemp
                Me.dgvProductionPlanItem.DataSource = ProductionPlanList
                Me.txtTransactionId.Text = "<自动编号>"
            Else
                Me.dtpInvoiceDate.Enabled = False
                Me.txtTransactionId.Enabled = False
                Me.cboDept.Enabled = False

                Dim dtProductionPlan As DataTable
                dtProductionPlan = GetMesData.GetProductionPlan(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)

                If (Not dtProductionPlan Is Nothing And dtProductionPlan.Rows.Count > 0) Then
                    Me.dtpInvoiceDate.Text = dtProductionPlan.Rows(0).Item("TransactionId").ToString
                    Me.txtTransactionId.Text = dtProductionPlan.Rows(0).Item("TransactionId").ToString
                    dateTimeTemp = Convert.ToDateTime(dtProductionPlan.Rows(0).Item("PlanMonth").ToString)
                    Me.mtxtOrderNumber.Text = dtProductionPlan.Rows(0).Item("OrderNumber").ToString
                    Me.cboDept.SelectedIndex = Me.cboDept.FindString(dtProductionPlan.Rows(0).Item("DeptName").ToString)
                    Me.txtRemark.Text = dtProductionPlan.Rows(0).Item("Remark").ToString
                    Me.mtxtCreateUser.Text = dtProductionPlan.Rows(0).Item("CreateUser").ToString
                    Me.mtxtCheckUser.Text = dtProductionPlan.Rows(0).Item("CheckUser").ToString
                    Me.mtxtCheckTime.Text = dtProductionPlan.Rows(0).Item("CheckTime").ToString

                    StatusFlag = dtProductionPlan.Rows(0).Item("StatusFlag").ToString
                End If

                Dim dtProductionPlanItem As DataTable
                dtProductionPlanItem = GetMesData.GetProductionPlanItem(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)

                If (Not dtProductionPlanItem Is Nothing And dtProductionPlanItem.Rows.Count > 0) Then
                    Me.dgvProductionPlanItem.DataSource = dtProductionPlanItem
                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Function CheckDelete(ByVal strMaterialNO As String) As Boolean
        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DrRead As SqlClient.SqlDataReader
        Try

            strSQL.AppendLine("SELECT StatusFlag FROM m_ProductionPlanItem_t WHERE TransactionId='" & TransactionId & "' AND MaterialNO='" & strMaterialNO & "' ")

            DrRead = Conn.GetDataReader(strSQL.ToString)

            If DrRead.HasRows Then
                DrRead.Read()
                If DrRead(0).ToString() = "Y" Then
                    GetMesData.SetMessage(Me.lblMessage, "已经审核数据,不允许删除!", False)
                    Return False
                Else
                    Return True
                End If
            End If
            DrRead.Close()
            Conn.PubConnection.Close()
            GetMesData.SetMessage(Me.lblMessage, "删除检查异常!", False)
            Return False
        Catch ex As Exception
            If (DrRead.IsClosed = False) Then
                DrRead.Close()
            End If
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "删除检查异常!", False)
            Return False
        End Try
    End Function

    Private Function CheckSave() As Boolean
        Dim rtValue As Boolean = False
        Try

            If (String.IsNullOrEmpty(Me.cboDept.Text)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择部门", False)
                Return rtValue
                Exit Function
            End If

            If (Me.dgvProductionPlanItem.Rows.Count <= 0) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
            Else
                Dim Qty As String
                Dim strMaterialNO As String
                Dim strMOid As String
                Dim strLineName As String
                Dim strDeptName As String

                For i As Int16 = 0 To Me.dgvProductionPlanItem.RowCount - 1
                    strMaterialNO = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("MaterialNO").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("MaterialNO").Value)
                    strMOid = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("MOid").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("MOid").Value)
                    strLineName = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("LineName").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("LineName").Value)
                    strDeptName = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DeptName").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("DeptName").Value)
                    'Qty = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("ProductionQuantity").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("ProductionQuantity").Value)
                    'If (Not String.IsNullOrEmpty(strMaterialNO)) Then
                    '    If Not IsNumeric(Qty) Then
                    '        rtValue = False
                    '        GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入数量格式错误", False)
                    '        Exit For
                    '    End If
                    '    If (CDbl(Qty) <= 0) Then
                    '        rtValue = False
                    '        GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入数量不能小于0", False)
                    '        Exit For
                    '    End If
                    'End If

                    If (String.IsNullOrEmpty(strMaterialNO)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行料号不能为空", False)
                        Exit For
                    End If

                    If (String.IsNullOrEmpty(strMOid)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行工单不能为空", False)
                        Exit For
                    End If

                    If (String.IsNullOrEmpty(strLineName)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行产线不能为空", False)
                        Exit For
                    End If

                    If (String.IsNullOrEmpty(strDeptName)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行部门不能为空", False)
                        Exit For
                    End If

                    If (Not CheckPlanUniqueness(i, strMaterialNO, strMOid, strLineName, Me.dgvProductionPlanItem)) Then
                        rtValue = False
                        Exit For
                    End If

                    'If (Not CheckExistPlan(i, Me.dtpInvoiceDate.Text, strMaterialNO, strMOid, strLineName)) Then
                    '    rtValue = False
                    '    Exit For
                    'End If

                    If (Not CheckQuantityFormat(i)) Then
                        rtValue = False
                        Exit For
                    End If

                    If (i = Me.dgvProductionPlanItem.RowCount - 1) Then
                        rtValue = True
                    End If
                Next
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

    Private Sub GetFormatLoadData(ByVal dtLoadData As DataTable, ByVal dtProductionPlanList As DataTable)
        Try
            For i As Int16 = 0 To dtLoadData.Rows.Count - 1
                Dim drData As DataRow
                drData = dtProductionPlanList.NewRow()
                drData("TransactionId") = ""
                'drData("RowNum") = dtLoadData.Rows(i).Item("").ToString
                drData("MaterialNO") = dtLoadData.Rows(i).Item(7).ToString
                drData("MOId") = dtLoadData.Rows(i).Item(8).ToString
                drData("DeptName") = dtLoadData.Rows(i).Item(3).ToString
                drData("LineName") = dtLoadData.Rows(i).Item(5).ToString
                drData("ProductionQuantity") = dtLoadData.Rows(i).Item(9).ToString
                drData("CustomerName") = dtLoadData.Rows(i).Item(0).ToString
                drData("UnfinishedQuantity") = dtLoadData.Rows(i).Item(10).ToString
                drData("ExpectedDate") = dtLoadData.Rows(i).Item(1).ToString
                drData("SingleDay") = dtLoadData.Rows(i).Item(2).ToString
                drData("StandardWorkingHours") = dtLoadData.Rows(i).Item(11).ToString
                drData("ManpowerNumber") = dtLoadData.Rows(i).Item(12).ToString
                drData("Effectiveness") = dtLoadData.Rows(i).Item(13).ToString
                drData("EstimatedDays") = dtLoadData.Rows(i).Item(14).ToString
                drData("ExpectedCapacity") = dtLoadData.Rows(i).Item(15).ToString
                drData("ProductionDays") = dtLoadData.Rows(i).Item(16).ToString

                drData("WKone") = dtLoadData.Rows(i).Item(17).ToString
                drData("WKtwo") = dtLoadData.Rows(i).Item(18).ToString
                drData("NOYieldQuantity") = dtLoadData.Rows(i).Item(19).ToString
                drData("LineUserName") = dtLoadData.Rows(i).Item(6).ToString
                drData("Remark") = ""
                drData("DailyWorkOne") = dtLoadData.Rows(i).Item(20).ToString
                drData("DailyWorkTwo") = dtLoadData.Rows(i).Item(21).ToString
                drData("DailyWorkThree") = dtLoadData.Rows(i).Item(22).ToString
                drData("DailyWorkFour") = dtLoadData.Rows(i).Item(23).ToString
                drData("DailyWorkFive") = dtLoadData.Rows(i).Item(24).ToString
                drData("DailyWorkSix") = dtLoadData.Rows(i).Item(25).ToString
                drData("DailyWorkSeven") = dtLoadData.Rows(i).Item(26).ToString
                drData("DailyWorkEight") = dtLoadData.Rows(i).Item(27).ToString
                drData("DailyWorkNine") = dtLoadData.Rows(i).Item(28).ToString
                drData("DailyWorkTen") = dtLoadData.Rows(i).Item(29).ToString
                drData("DailyWorkEleven") = dtLoadData.Rows(i).Item(30).ToString
                drData("DailyWorkTwelve") = dtLoadData.Rows(i).Item(31).ToString
                drData("DailyWorkThirteen") = dtLoadData.Rows(i).Item(32).ToString
                drData("DailyWorkFourteen") = dtLoadData.Rows(i).Item(33).ToString
                drData("DailyWorkFifteen") = dtLoadData.Rows(i).Item(34).ToString
                drData("DailyWorkSixteen") = dtLoadData.Rows(i).Item(35).ToString
                drData("DailyWorkSeveteen") = dtLoadData.Rows(i).Item(36).ToString
                drData("DailyWorkEighteen") = dtLoadData.Rows(i).Item(37).ToString
                drData("DailyWorkNineteen") = dtLoadData.Rows(i).Item(38).ToString
                drData("DailyWorkTwenty") = dtLoadData.Rows(i).Item(39).ToString
                drData("DailyWorkTwentyone") = dtLoadData.Rows(i).Item(40).ToString
                drData("DailyWorkTwentytwo") = dtLoadData.Rows(i).Item(41).ToString
                drData("DailyWorkTwentythree") = dtLoadData.Rows(i).Item(42).ToString
                drData("DailyWorkTwentyfour") = dtLoadData.Rows(i).Item(43).ToString
                drData("DailyWorkTwentyfive") = dtLoadData.Rows(i).Item(44).ToString
                drData("DailyWorkTwentysix") = dtLoadData.Rows(i).Item(45).ToString
                drData("DailyWorkTwentyseven") = dtLoadData.Rows(i).Item(46).ToString
                drData("DailyWorkTwentyeight") = dtLoadData.Rows(i).Item(47).ToString
                drData("DailyWorkTwentynine") = dtLoadData.Rows(i).Item(48).ToString
                drData("DailyWorkThirty") = dtLoadData.Rows(i).Item(49).ToString
                drData("DailyWorkThirtyone") = dtLoadData.Rows(i).Item(50).ToString
                dtProductionPlanList.Rows.Add(drData)
            Next
            dtProductionPlanList.AcceptChanges()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "导入格式转换异常,请确认导入格式是否正确.", False)
        End Try
    End Sub

    Private Function CheckPlanUniqueness(ByVal iRowNum As Int16, ByVal strMaterialNO As String, ByVal strMOid As String, ByVal strLineName As String, ByVal dgvGridView As DataGridViewX) As Boolean
        Dim rtValue As Boolean = False
        Dim strMaterialNOTemp As String
        Dim strMOidTemp As String
        Dim strLineNameTemp As String
        Dim strDeptNameTemp As String
        Try
            For i As Int16 = 0 To dgvGridView.RowCount - 1
                strMaterialNOTemp = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("MaterialNO").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("MaterialNO").Value)
                strMOidTemp = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("MOid").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("MOid").Value)
                strLineNameTemp = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("LineName").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("LineName").Value)
                strDeptNameTemp = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("DeptName").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("DeptName").Value)

                If (i <> iRowNum) Then
                    If (strMaterialNOTemp.ToUpper = strMaterialNO.ToUpper And strMOidTemp.ToUpper = strMOid.ToUpper And strLineNameTemp.ToUpper = strLineName.ToUpper) Then
                        GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "和第" & i + 1 & "行料号工单产线重复", False)
                        rtValue = False
                        Exit For
                    End If
                End If

                If (i = dgvGridView.RowCount - 1) Then
                    rtValue = True
                End If
            Next
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查第" & iRowNum + 1 & "行导入数据唯一性异常", False)
            rtValue = False
        End Try
        Return rtValue
    End Function

    Private Function CheckExistPlan(ByVal iRowNum As Int16, ByVal strInvoiceDate As String, ByVal strMaterialNO As String, ByVal strMOid As String, ByVal strLineName As String) As Boolean
        Dim rtValue As Boolean = False
        Dim strSQL As String = ""
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader

        Try
            strSQL = "SELECT TOP 1 ProductionPlanItemId FROM m_ProductionPlanItem_t WHERE PlanMonth='" & strInvoiceDate & "' AND MaterialNO='" & strMaterialNO & "' AND MOID='" & strMOid & "' AND LineName='" & strLineName & "' "
            DReader = Conn.GetDataReader(strSQL)

            If (DReader.HasRows) Then
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行导入数据已经存在", False)
                rtValue = False
            Else
                rtValue = True
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查第" & iRowNum + 1 & "行导入数据是否存在异常", False)
            rtValue = False
        End Try
        Return rtValue
    End Function

    Private Function CheckQuantityFormat(ByVal iRowNum As Int16) As Boolean
        Dim rtValue As Boolean = False
        Try

            Dim strProductionQuantity As String
            Dim strUnfinishedQuantity As String
            Dim strSingleDay As String
            Dim strStandardWorkingHours As String
            Dim strManpowerNumber As String
            Dim strEffectiveness As String
            Dim strEstimatedDays As String
            Dim strExpectedCapacity As String
            Dim strProductionDays As String
            Dim strWKone As String
            Dim strWKtwo As String
            Dim strNOYieldQuantity As String

            Dim strDailyWorkOne As String
            Dim strDailyWorkTwo As String
            Dim strDailyWorkThree As String
            Dim strDailyWorkFour As String
            Dim strDailyWorkFive As String
            Dim strDailyWorkSix As String
            Dim strDailyWorkSeven As String
            Dim strDailyWorkEight As String
            Dim strDailyWorkNine As String
            Dim strDailyWorkTen As String
            Dim strDailyWorkEleven As String
            Dim strDailyWorkTwelve As String
            Dim strDailyWorkThirteen As String
            Dim strDailyWorkFourteen As String
            Dim strDailyWorkFifteen As String
            Dim strDailyWorkSixteen As String
            Dim strDailyWorkSeveteen As String
            Dim strDailyWorkEighteen As String
            Dim strDailyWorkNineteen As String
            Dim strDailyWorkTwenty As String
            Dim strDailyWorkTwentyone As String
            Dim strDailyWorkTwentytwo As String
            Dim strDailyWorkTwentythree As String
            Dim strDailyWorkTwentyfour As String
            Dim strDailyWorkTwentyfive As String
            Dim strDailyWorkTwentysix As String
            Dim strDailyWorkTwentyseven As String
            Dim strDailyWorkTwentyeight As String
            Dim strDailyWorkTwentynine As String
            Dim strDailyWorkThirty As String
            Dim strDailyWorkThirtyone As String

            strProductionQuantity = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("ProductionQuantity").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("ProductionQuantity").Value.ToString.Trim))
            strUnfinishedQuantity = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("UnfinishedQuantity").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("UnfinishedQuantity").Value.ToString.Trim))
            strSingleDay = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("SingleDay").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("SingleDay").Value.ToString.Trim))
            strStandardWorkingHours = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("StandardWorkingHours").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("StandardWorkingHours").Value.ToString.Trim))
            strManpowerNumber = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("ManpowerNumber").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("ManpowerNumber").Value.ToString.Trim))
            strEffectiveness = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("Effectiveness").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("Effectiveness").Value.ToString.Trim))
            strEstimatedDays = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("EstimatedDays").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("EstimatedDays").Value.ToString.Trim))
            strExpectedCapacity = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("ExpectedCapacity").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("ExpectedCapacity").Value.ToString.Trim))
            strProductionDays = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("ProductionDays").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("ProductionDays").Value.ToString.Trim))
            strWKone = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("WKone").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("WKone").Value.ToString.Trim))
            strWKtwo = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("WKtwo").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("WKtwo").Value.ToString.Trim))
            strNOYieldQuantity = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("NOYieldQuantity").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("NOYieldQuantity").Value.ToString.Trim))

            strDailyWorkOne = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkOne").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkOne").Value.ToString.Trim))
            strDailyWorkTwo = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwo").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwo").Value.ToString.Trim))
            strDailyWorkThree = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkThree").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkThree").Value.ToString.Trim))
            strDailyWorkFour = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkFour").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkFour").Value.ToString.Trim))
            strDailyWorkFive = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkFive").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkFive").Value.ToString.Trim))
            strDailyWorkSix = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkSix").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkSix").Value.ToString.Trim))
            strDailyWorkSeven = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkSeven").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkSeven").Value.ToString.Trim))
            strDailyWorkEight = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkEight").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkEight").Value.ToString.Trim))
            strDailyWorkNine = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkNine").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkNine").Value.ToString.Trim))
            strDailyWorkTen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTen").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTen").Value.ToString.Trim))

            strDailyWorkEleven = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkEleven").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkEleven").Value.ToString.Trim))
            strDailyWorkTwelve = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwelve").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwelve").Value.ToString.Trim))
            strDailyWorkThirteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkThirteen").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkThirteen").Value.ToString.Trim))
            strDailyWorkFourteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkFourteen").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkFourteen").Value.ToString.Trim))
            strDailyWorkFifteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkFifteen").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkFifteen").Value.ToString.Trim))
            strDailyWorkSixteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkSixteen").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkSixteen").Value.ToString.Trim))
            strDailyWorkSeveteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkSeveteen").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkSeveteen").Value.ToString.Trim))
            strDailyWorkEighteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkEighteen").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkEighteen").Value.ToString.Trim))
            strDailyWorkNineteen = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkNineteen").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkNineteen").Value.ToString.Trim))

            strDailyWorkTwenty = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwenty").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwenty").Value.ToString.Trim))
            strDailyWorkTwentyone = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentyone").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentyone").Value.ToString.Trim))
            strDailyWorkTwentytwo = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentytwo").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentytwo").Value.ToString.Trim))
            strDailyWorkTwentythree = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentythree").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentythree").Value.ToString.Trim))
            strDailyWorkTwentyfour = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentyfour").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentyfour").Value.ToString.Trim))
            strDailyWorkTwentyfive = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentyfive").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentyfive").Value.ToString.Trim))
            strDailyWorkTwentysix = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentysix").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentysix").Value.ToString.Trim))
            strDailyWorkTwentyseven = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentyseven").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentyseven").Value.ToString.Trim))
            strDailyWorkTwentyeight = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentyeight").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentyeight").Value.ToString.Trim))
            strDailyWorkTwentynine = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentynine").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkTwentynine").Value.ToString.Trim))
            strDailyWorkThirty = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkThirty").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkThirty").Value.ToString.Trim))
            strDailyWorkThirtyone = GetEmptyConversion(IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkThirtyone").Value), "0", Me.dgvProductionPlanItem.Rows(iRowNum).Cells("DailyWorkThirtyone").Value.ToString.Trim))

            If (Not IsNumeric(strProductionQuantity)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行生产数量数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strUnfinishedQuantity)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行未完成数量数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strSingleDay)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行下单天数数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strStandardWorkingHours)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行标准工时数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strManpowerNumber)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行人力数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strEffectiveness)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行效率数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strEstimatedDays)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行预计天数数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strExpectedCapacity)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行预计产能数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strProductionDays)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行生产天数数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strWKone)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行WK1欠数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strWKtwo)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行WK2欠数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strNOYieldQuantity)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行未排量数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkOne)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行1号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkTwo)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行2号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkThree)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行3号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkFour)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行4号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkFive)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行5号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkSix)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行6号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkSeven)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行7号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkEight)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行8号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkNine)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行9号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkTen)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行10号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkEleven)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行11号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkTwelve)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行12号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkThirteen)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行13号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkFourteen)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行14号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkFifteen)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行15号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkSixteen)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行16号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkSeveteen)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行17号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkEighteen)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行18号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkNineteen)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行19号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkTwenty)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行20号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkTwentyone)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行21号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkTwentytwo)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行22号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkTwentythree)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行23号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkTwentyfour)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行24号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkTwentyfive)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行25号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkTwentysix)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行26号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkTwentyseven)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行27号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkTwentyeight)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行28号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkTwentynine)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行29号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkThirty)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行30号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            If (Not IsNumeric(strDailyWorkThirtyone)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "第" & iRowNum + 1 & "行31号导入数字类型错误", False)
                Return rtValue
                Exit Function
            End If

            rtValue = True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查第" & iRowNum + 1 & "行导入数字类型异常", False)
            rtValue = False
        End Try
        Return rtValue
    End Function

    Private Function GetEmptyConversion(ByVal strValue As String) As String
        Try
            If (String.IsNullOrEmpty(strValue.Trim)) Then
                strValue = "0"
            End If
            Return strValue
        Catch ex As Exception
            Return strValue
        End Try
    End Function

#End Region

End Class
