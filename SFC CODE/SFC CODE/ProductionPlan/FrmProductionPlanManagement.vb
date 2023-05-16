
'--生产派工管理
'--Create by :　马锋
'--Create date :　2015/12/10
'--Ver : V01
'--Update date :  
'--

#Region "Imports"

Imports System.Windows.Forms
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
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.io
#End Region

Public Class FrmProductionPlanManagement

#Region "变量声明"
    Dim nodeTag As String
    Dim nodeText As String
    Dim path As String = AppDomain.CurrentDomain.BaseDirectory
    Dim file As String = ""
    Dim content As String = ""

    Shared _dtVisiableColumn As DataTable
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

#Region "加载事件"

    Private Sub FrmProductionPlanManagementt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvProductionPlan.AutoGenerateColumns = False
            Me.dgvProductionPlanItem.AutoGenerateColumns = False
            Me.tvProductionPlan.ExpandAll()
            Me.dtpStartDate.Value = Now().AddDays(-1)
            Me.dtpEndDate.Value = Now().AddDays(1)
            Dim dateTimeTemp As DateTime
            dateTimeTemp = DateTime.Now
            GetMesData.GetPlanMonthDayColumnName(dateTimeTemp.Year, dateTimeTemp.Month, dgvProductionPlanItem, 22, lblMessage)
            GetProductionPlan()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常!", False)
        End Try
    End Sub

#End Region

#Region "工具事件"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim ProductionPlanMaster As New FrmProductionPlanMaster("")
            ProductionPlanMaster.ShowDialog()
            GetProductionPlan()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Me.dgvProductionPlan.Rows.Count = 0 OrElse Me.dgvProductionPlan.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要删除单据", False)
            Exit Sub
        End If
        Dim strSQL As New StringBuilder
        Dim strTransactionId As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            strTransactionId = Me.dgvProductionPlan.Rows(Me.dgvProductionPlan.CurrentRow.Index).Cells("TransactionId").Value.ToString
            strSQL.AppendLine(" UPDATE m_ProductionPlan_t SET DeleteFlag='1' WHERE TransactionId='" & strTransactionId & "' ")
            strSQL.AppendLine(" UPDATE m_ProductionPlanItem_t SET DeleteFlag='1' WHERE TransactionId='" & strTransactionId & "' ")

            Conn.ExecSql(strSQL.ToString())
            GetProductionPlan()
            GetMesData.SetMessage(Me.lblMessage, "删除成功", True)
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Me.dgvProductionPlan.Rows.Count = 0 OrElse Me.dgvProductionPlan.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要修改单据", False)
            Exit Sub
        End If

        Try
            Dim TransactionId As String
            TransactionId = Me.dgvProductionPlan.Rows(Me.dgvProductionPlan.CurrentRow.Index).Cells("TransactionId").Value.ToString
            Dim ProductionPlanMaster As New FrmProductionPlanMaster(TransactionId)
            ProductionPlanMaster.ShowDialog()

            GetProductionPlan()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        GetProductionPlan()
    End Sub

    Private Sub btnPrinter_Click(sender As Object, e As EventArgs) Handles btnPrinter.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)

        If Me.dgvProductionPlan.Rows.Count = 0 OrElse Me.dgvProductionPlan.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择打印单据", False)
            Me.dgvProductionPlan.Rows.Clear()
            Exit Sub
        End If

        Dim TransactionId As String = Me.dgvProductionPlan.Rows(Me.dgvProductionPlan.CurrentRow.Index).Cells("TransactionId").Value.ToString
        file = "PrintTemplate\" & TransactionId + ".pdf"
        Dim document As Document = New Document()
        Dim writer As pdf.PdfWriter = PdfWriter.GetInstance(document, New FileStream(path + file, FileMode.Create))
        document.Open()

        Try

            Dim fontHeader As iTextSharp.text.Font = iTextSharpHelp.CreateChineseFont(24)
            Dim font As iTextSharp.text.Font = iTextSharpHelp.CreateChineseFont(10)

            Dim tableHeader As PdfPTable = New PdfPTable(8)
            tableHeader.WidthPercentage = 95
            Dim cellCompany As New PdfPCell(New Phrase("LUXSHARE-ICT", font))
            cellCompany.Colspan = 2
            cellCompany.HorizontalAlignment = 1
            cellCompany.VerticalAlignment = Element.ALIGN_MIDDLE
            tableHeader.AddCell(cellCompany)
            Dim CurrIndex As Int16 = Me.dgvProductionPlan.CurrentRow.Index
            Dim TransactionTypeName As String = "成品入库单"
            Dim CreateTime As String = IIf(IsDBNull(Me.dgvProductionPlan.Rows(CurrIndex).Cells("CreateTime1").Value), "", Microsoft.VisualBasic.Left(Me.dgvProductionPlan.Rows(CurrIndex).Cells("CreateTime1").Value.ToString, 10))
            Dim AttentionName As String = IIf(IsDBNull(Me.dgvProductionPlan.Rows(CurrIndex).Cells("AttentionName").Value), "", Me.dgvProductionPlan.Rows(CurrIndex).Cells("AttentionName").Value)
            Dim SupplierName As String = "" 'IIf(IsDBNull(Me.dgvProductionPlan.Rows(CurrIndex).Cells("SupplierName").Value), "", Me.dgvProductionPlan.Rows(CurrIndex).Cells("SupplierName").Value)
            Dim DeliveryName As String = IIf(IsDBNull(Me.dgvProductionPlan.Rows(CurrIndex).Cells("DeliveryName").Value), "", Me.dgvProductionPlan.Rows(CurrIndex).Cells("DeliveryName").Value)
            Dim Remark As String = IIf(IsDBNull(Me.dgvProductionPlan.Rows(CurrIndex).Cells("Remark").Value), "", Me.dgvProductionPlan.Rows(CurrIndex).Cells("Remark").Value)

            Dim cell As New PdfPCell(New Phrase("成品入库单", fontHeader))
            cell.Colspan = 6
            cell.HorizontalAlignment = 1
            cell.VerticalAlignment = Element.ALIGN_MIDDLE
            tableHeader.AddCell(cell)
            tableHeader.AddCell(New Phrase("单据名称", font))
            tableHeader.AddCell(New Phrase(TransactionTypeName, font))
            tableHeader.AddCell(New Phrase("日期", font))
            tableHeader.AddCell(New Phrase(CreateTime, font))
            tableHeader.AddCell(New Phrase("单号", font))

            Dim cd As PdfContentByte = writer.DirectContent
            Dim code128 As Barcode128 = New Barcode128
            code128.X = 0.62F
            code128.N = 0.5F
            code128.Size = 10.0F
            code128.Baseline = 12
            code128.BarHeight = 12.0F
            code128.Code = TransactionId    '"CK201508190001"
            Dim image128 As iTextSharp.text.Image = code128.CreateImageWithBarcode(cd, Nothing, Nothing)
            Dim cell128 As New PdfPCell(image128, False)
            cell128.FixedHeight = 30
            cell128.VerticalAlignment = Element.ALIGN_MIDDLE
            cell128.HorizontalAlignment = 1
            cell128.Colspan = 3
            tableHeader.AddCell(cell128)
            tableHeader.AddCell(New Phrase("经办人", font))
            tableHeader.AddCell(New Phrase(AttentionName, font))

            tableHeader.AddCell(New Phrase("供应商", font))
            tableHeader.AddCell(New Phrase(SupplierName, font))
            tableHeader.AddCell(New Phrase("交货人", font))
            tableHeader.AddCell(New Phrase(DeliveryName, font))
            tableHeader.AddCell(New Phrase("备注", font))
            tableHeader.AddCell(New Phrase(Remark, font))

            tableHeader.AddCell(New Phrase("料号", font))
            tableHeader.AddCell(New Phrase("品名", font))
            tableHeader.AddCell(New Phrase("规格", font))
            tableHeader.AddCell(New Phrase("单位", font))
            tableHeader.AddCell(New Phrase("储位", font))
            tableHeader.AddCell(New Phrase("数量", font))
            tableHeader.AddCell(New Phrase("订单号", font))
            tableHeader.AddCell(New Phrase("备注", font))

            Dim MaterialNO As String
            Dim Description As String
            Dim Specification As String
            Dim Uint As String
            Dim WarehouseLocationId As String
            Dim Quantity As String
            Dim OrderNumber As String
            Dim ItemRemark As String
            For i As Int16 = 0 To Me.dgvProductionPlanItem.RowCount - 1
                MaterialNO = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("MaterialNO").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("MaterialNO").Value)
                Description = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("Description").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("Description").Value)
                Specification = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("Specification").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("Specification").Value)
                Uint = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("Uint").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("Uint").Value)
                WarehouseLocationId = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("WarehouseLocationId").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("WarehouseLocationId").Value)
                Quantity = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("Quantity").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("Quantity").Value)
                OrderNumber = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("OrderNumber").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("OrderNumber").Value)
                ItemRemark = IIf(IsDBNull(Me.dgvProductionPlanItem.Rows(i).Cells("ItemRemark").Value), "", Me.dgvProductionPlanItem.Rows(i).Cells("ItemRemark").Value)

                tableHeader.AddCell(New Phrase(MaterialNO, font))
                tableHeader.AddCell(New Phrase(Description, font))
                tableHeader.AddCell(New Phrase(Specification, font))
                tableHeader.AddCell(New Phrase(Uint, font))
                tableHeader.AddCell(New Phrase(WarehouseLocationId, font))
                tableHeader.AddCell(New Phrase(Quantity, font))
                tableHeader.AddCell(New Phrase(OrderNumber, font))
                tableHeader.AddCell(New Phrase(ItemRemark, font))
            Next
            tableHeader.AddCell(New Phrase("说明", font))
            Dim cellDesc As New PdfPCell(New Phrase("", font))
            cellDesc.Colspan = 5
            tableHeader.AddCell(cellDesc)
            tableHeader.AddCell(New Phrase("打印人", font))
            tableHeader.AddCell(New Phrase(VbCommClass.VbCommClass.UseId, font))

            document.Add(tableHeader)
            document.Close()

            Process.Start(path + file)
        Catch ex As Exception
            document.Close()
            GetMesData.SetMessage(Me.lblMessage, "打印异常,请确认本机已经安装PDF软件", False)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim ProductionPlanUpdate As New FrmProductionPlanUpdate("")
            ProductionPlanUpdate.ShowDialog()
            GetProductionPlan()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click

    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click

    End Sub

#End Region

#Region "控件事件"

    Private Sub dgvProductionPlan_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductionPlan.CellEnter
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvProductionPlan.Rows.Count = 0 OrElse Me.dgvProductionPlan.CurrentRow Is Nothing Then
            Me.dgvProductionPlanItem.Rows.Clear()
            Exit Sub
        End If

        Try
            Dim dateTimeTemp As DateTime
            dateTimeTemp = Me.dgvProductionPlan.Rows(Me.dgvProductionPlan.CurrentRow.Index).Cells("TransactionId").Value.ToString()
            GetMesData.GetPlanMonthDayColumnName(dateTimeTemp.Year, dateTimeTemp.Month, dgvProductionPlanItem, 22, lblMessage)
            GetProductionPlanItem(Me.dgvProductionPlan.Rows(Me.dgvProductionPlan.CurrentRow.Index).Cells("TransactionId").Value.ToString())
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常!", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub GetProductionPlan()
        Dim strSQL As String
        Dim strWhere As String = ""

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader

        Try

            If Not (String.IsNullOrEmpty(Me.dtpStartDate.Text.Trim)) Then
                strWhere = strWhere & " AND CONVERT(VARCHAR(10), CreateTime, 23) >= '" & Me.dtpStartDate.Text.Trim & "' "
            End If

            If Not (String.IsNullOrEmpty(Me.dtpEndDate.Text.Trim)) Then
                strWhere = strWhere & " AND CONVERT(VARCHAR(10), CreateTime, 23) <= '" & Me.dtpEndDate.Text.Trim & "' "
            End If

            If Not (String.IsNullOrEmpty(Me.txtMOId.Text.Trim)) Then
                strWhere = strWhere & " AND TransactionId IN (SELECT TransactionId FROM m_ProductionPlanItem_t WHERE MOID='" & Me.txtMOId.Text.Trim.Replace("'", "''") & "') "
            End If

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY ProductionPlanId )as RowNum, ProductionPlanId, FactoryId, Profitcenter, TransactionId, PlanMonth, OrderNumber, DeptId, DeptName, Remark, CheckUser, " & _
                     " CheckTime, StatusFlag, DeleteFlag, CreateTime, CreateUser, UpdateUser, UpdateTime, CASE StatusFlag WHEN '1' THEN N'有效' ELSE N'无效'  END AS StatusFlagName FROM m_ProductionPlan_t WHERE FactoryId='" & VbCommClass.VbCommClass.Factory & "' AND Profitcenter='" & VbCommClass.VbCommClass.profitcenter & "' AND DeleteFlag='0' " & strWhere & " ORDER BY CreateTime DESC "

            Me.dgvProductionPlan.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)
            If Not (DReader.HasRows) Then
                Me.dgvProductionPlanItem.DataSource = Nothing
                Me.dgvProductionPlanItem.Rows.Clear()
            End If
            Do While DReader.Read()
                Me.dgvProductionPlan.Rows.Add(DReader.Item("ProductionPlanId").ToString, DReader.Item("RowNum").ToString, DReader.Item("TransactionId").ToString, DReader.Item("PlanMonth").ToString, DReader.Item("OrderNumber").ToString, DReader.Item("DeptName").ToString, DReader.Item("Remark").ToString, DReader.Item("CheckUser").ToString, DReader.Item("CheckTime").ToString, DReader.Item("StatusFlag").ToString, _
                                                 DReader.Item("UpdateUser").ToString, DReader.Item("UpdateTime").ToString, DReader.Item("CreateUser").ToString, DReader.Item("CreateTime").ToString)
            Loop

            DReader.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Not DReader Is Nothing And Not DReader.IsClosed) Then
                DReader.Close()
            End If

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常!", False)
        End Try
    End Sub

    Private Sub GetProductionPlanItem(ByVal TransactionId As String)
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try

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
            " m_ProductionPlanItem_t.MOID = m_PlanDailyWork_t.MOID And m_ProductionPlanItem_t.LineName = m_PlanDailyWork_t.LineName WHERE m_ProductionPlanItem_t.TransactionId='" & TransactionId & "'"

            'Me.dgvProductionPlanItem.Rows.Clear()
            Me.dgvProductionPlanItem.DataSource = Conn.GetDataTable(strSQL)

            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常!", False)
        End Try
    End Sub

#End Region

    
End Class