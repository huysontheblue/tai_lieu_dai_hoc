
'--生产排程查询
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

Public Class FrmProductionPlanQuery

    Dim dateTimeTemp As DateTime
    Dim _dtVisiableColumn As DataTable
    Dim _dtDept As DataTable
    Dim _dtLine As DataTable

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

#Region "加载事件"

    Private Sub FrmProductionPlanQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvProductionPlanItem.AutoGenerateColumns = False
            Dim dateTimeTemp As DateTime
            dateTimeTemp = DateTime.Now
            Me.dtpInvoiceDate.Text = dateTimeTemp
            Me.itxtRefreshInterval.Value = 0
            LoadControlsData()
            GetMesData.GetPlanMonthDayColumnName(dateTimeTemp.Year, dateTimeTemp.Month, dgvProductionPlanItem, 22, lblMessage)
            GetMesData.GetDataGridXColumn(dgvProductionPlanItem, dtVisiableColumn, lblMessage)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
        
    End Sub

#End Region

#Region "控件事件"

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(Me.dtpInvoiceDate.Text)) Then
                strWhere = " AND m_ProductionPlanItem_t.PlanMonth='" & Me.dtpInvoiceDate.Text & "'"
            End If

            If (Not String.IsNullOrEmpty(Me.cboDept.Text) And Me.cboDept.Text.ToUpper <> "ALL".ToUpper) Then
                strWhere = strWhere & " AND m_ProductionPlanItem_t.DeptName like '%" & Me.cboDept.Text & "%'"
            End If

            If (Not String.IsNullOrEmpty(Me.cboLine.Text) And Me.cboLine.Text.ToUpper <> "ALL".ToUpper) Then
                strWhere = strWhere & " AND m_ProductionPlanItem_t.LineName like '" & Me.cboLine.Text & "'"
            End If

            If Not (String.IsNullOrEmpty(Me.txtMOId.Text)) Then
                strWhere = strWhere & " AND m_ProductionPlanItem_t.MOID='" & Me.dtpInvoiceDate.Text & "'"
            End If

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY ProductionPlanItemId )as RowNum, m_ProductionPlanItem_t.ProductionPlanItemId, m_ProductionPlanItem_t.TransactionId, m_ProductionPlanItem_t.PlanMonth, m_ProductionPlanItem_t.MaterialNO, m_ProductionPlanItem_t.MOID, m_ProductionPlanItem_t.LineId, m_ProductionPlanItem_t.LineName, m_ProductionPlanItem_t.DeptId, m_ProductionPlanItem_t.DeptName, m_ProductionPlanItem_t.ProductionQuantity, " & _
            " m_ProductionPlanItem_t.CustomerId, m_ProductionPlanItem_t.CustomerName, m_ProductionPlanItem_t.UnfinishedQuantity, m_ProductionPlanItem_t.ExpectedDate, m_ProductionPlanItem_t.SingleDay, m_ProductionPlanItem_t.StandardWorkingHours, m_ProductionPlanItem_t.ManpowerNumber, m_ProductionPlanItem_t.Effectiveness," & _
            " m_ProductionPlanItem_t.EstimatedDays, m_ProductionPlanItem_t.ExpectedCapacity, m_ProductionPlanItem_t.ProductionDays, m_ProductionPlanItem_t.WKone, m_ProductionPlanItem_t.WKtwo, m_ProductionPlanItem_t.NOYieldQuantity, m_ProductionPlanItem_t.Remark, m_ProductionPlanItem_t.LineUserName, CASE StatusFlag WHEN '1' THEN N'有效' ELSE N'无效'  END AS StatusFlagName, " & _
            " m_ProductionPlanItem_t.StatusFlag, m_ProductionPlanItem_t.DeleteFlag, m_ProductionPlanItem_t.UpdateTime, m_ProductionPlanItem_t.UpdateUser, m_ProductionPlanItem_t.CreateTime, m_PlanDailyWork_t.DailyWorkOne, m_PlanDailyWork_t.DailyWorkTwo, m_PlanDailyWork_t.DailyWorkThree," & _
            " m_PlanDailyWork_t.DailyWorkFour, m_PlanDailyWork_t.DailyWorkFive, m_PlanDailyWork_t.DailyWorkSix, m_PlanDailyWork_t.DailyWorkSeven, m_PlanDailyWork_t.DailyWorkEight, m_PlanDailyWork_t.DailyWorkNine, m_PlanDailyWork_t.DailyWorkTen, m_PlanDailyWork_t.DailyWorkEleven," & _
            " m_PlanDailyWork_t.DailyWorkTwelve, m_PlanDailyWork_t.DailyWorkThirteen, m_PlanDailyWork_t.DailyWorkFourteen, m_PlanDailyWork_t.DailyWorkFifteen, m_PlanDailyWork_t.DailyWorkSixteen, m_PlanDailyWork_t.DailyWorkSeveteen, m_PlanDailyWork_t.DailyWorkEighteen, m_PlanDailyWork_t.DailyWorkNineteen," & _
            " m_PlanDailyWork_t.DailyWorkTwenty, m_PlanDailyWork_t.DailyWorkTwentyone, m_PlanDailyWork_t.DailyWorkTwentytwo, m_PlanDailyWork_t.DailyWorkTwentythree, m_PlanDailyWork_t.DailyWorkTwentyfour, m_PlanDailyWork_t.DailyWorkTwentyfive, m_PlanDailyWork_t.DailyWorkTwentysix, m_PlanDailyWork_t.DailyWorkTwentyseven," & _
            " m_PlanDailyWork_t.DailyWorkTwentyeight, m_PlanDailyWork_t.DailyWorkTwentynine, m_PlanDailyWork_t.DailyWorkThirty, m_PlanDailyWork_t.DailyWorkThirtyone" & _
            " FROM m_ProductionPlanItem_t INNER JOIN m_PlanDailyWork_t ON m_ProductionPlanItem_t.TransactionId = m_PlanDailyWork_t.TransactionId AND " & _
            " m_ProductionPlanItem_t.PlanMonth = m_PlanDailyWork_t.PlanMonth And m_ProductionPlanItem_t.MaterialNO = m_PlanDailyWork_t.MaterialNO And" & _
            " m_ProductionPlanItem_t.MOID = m_PlanDailyWork_t.MOID And m_ProductionPlanItem_t.LineName = m_PlanDailyWork_t.LineName WHERE 1=1 " & strWhere

            Me.dgvProductionPlanItem.DataSource = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "执行查询异常", False)
        End Try
    End Sub

    Private Sub TimerRefreshQuery_Tick(sender As Object, e As EventArgs) Handles TimerRefreshQuery.Tick
        Try
            If (Me.itxtRefreshInterval.Value > 0) Then
                btnQuery_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "执行自动刷新异常", False)
        End Try
    End Sub

    Private Sub itxtRefreshInterval_ValueChanged(sender As Object, e As EventArgs) Handles itxtRefreshInterval.ValueChanged
        Try
            If (Me.itxtRefreshInterval.Value = 0) Then
                Me.TimerRefreshQuery.Enabled = False
            Else
                Me.TimerRefreshQuery.Enabled = True
                Me.TimerRefreshQuery.Interval = 1000 * 60 * Convert.ToInt16(Me.itxtRefreshInterval.Value)
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "设置时间异常", False)
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

    Private Sub btnVisibleColumn_Click(sender As Object, e As EventArgs) Handles btnVisibleColumn.Click
        Try
            Dim ColumnVisiableSetting As New FrmColumnVisiableSetting(dtVisiableColumn)
            ColumnVisiableSetting.ShowDialog()
            GetMesData.GetColumnVisiable(dgvProductionPlanItem, dtVisiableColumn, lblMessage)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub cboDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDept.SelectedIndexChanged
        If (cboDept.Text = "ALL") Then
            Me.cboLine.DataSource = Nothing
            Me.cboLine.Items.Clear()
            Exit Sub
        End If

        Dim UserDg As DataTable
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            Me.cboLine.DataSource = Nothing
            Me.cboLine.Items.Clear()

            UserDg = DataHand.GetDataTable("select djc as djc,deptid from   m_Dept_t where factoryid='" & VbCommClass.VbCommClass.Factory & "' and deptid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='10109_' and userid='" & SysMessageClass.UseId & "')")
            cboLine.DisplayMember = "djc"
            cboLine.ValueMember = "deptid"
            Me.cboLine.DataSource = UserDg

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载产线异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadControlsData()
        Try
            Me.cboDept.DisplayMember = "DeptName"
            Me.cboDept.ValueMember = "DeptCode"
            _dtDept = GetMesData.GetDeptList(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "")

            Me.cboDept.DataSource = GetMesData.GetDateTableALL(_dtDept, lblMessage)
            Me.cboDept.SelectedIndex = Me.cboDept.FindString("ALL")

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载控件数据异常", False)
        End Try
    End Sub

#End Region

End Class