
'--仓储出库显示
'--Create by :　马锋
'--Create date :　2015/07/30
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
Imports LXWarehouseManage
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.io
#End Region

Public Class FrmOutStorehouseQuery

#Region "变量声明"
    Dim nodeTag As String
    Dim nodeText As String
    Dim path As String = AppDomain.CurrentDomain.BaseDirectory
    Dim file As String = ""
    Dim content As String = ""
#End Region

#Region "加载事件"

    Private Sub FrmOutStorehouseQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvInvoiceTransaction.AutoGenerateColumns = False
            Me.dgvInvoiceTransactionItem.AutoGenerateColumns = False
            Me.dgvBarcode.AutoGenerateColumns = False
            Me.SuperTabControl1.SelectedTabIndex = 0
            '加载菜单
            LoadTree()
            Me.dtpDate.Value = Now
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "工具事件"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim strInvoiceDefinitionsTypeName As String
        Try
            If (String.IsNullOrEmpty(nodeTag)) Then
                strInvoiceDefinitionsTypeName = ""
            Else
                strInvoiceDefinitionsTypeName = nodeText
            End If
            Dim outStorehouseMaster As New FrmOutStorehouseMaster(strInvoiceDefinitionsTypeName, "")
            outStorehouseMaster.ShowDialog()
            GetTransaction(nodeTag, nodeText)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Me.dgvInvoiceTransaction.Rows.Count = 0 OrElse Me.dgvInvoiceTransaction.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要删除单据", False)
            Exit Sub
        End If
        Dim strSQL As New StringBuilder
        Dim strTransactionId As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            strTransactionId = Me.dgvInvoiceTransaction.Rows(Me.dgvInvoiceTransaction.CurrentRow.Index).Cells("TransactionId").Value.ToString
            strSQL.AppendLine(" UPDATE m_InvoiceTransaction_t SET DeleteFlag='1' WHERE TransactionId='" & strTransactionId & "' ")
            strSQL.AppendLine(" UPDATE m_InvoiceTransactionItem_t SET DeleteFlag='1' WHERE TransactionId='" & strTransactionId & "' ")

            strSQL.AppendLine(" UPDATE W_MATERIALS SET QUANTITY = W_MATERIALS.QUANTITY + m_InvoiceTransactionItem_t.Quantity ")
            strSQL.AppendLine(" FROM m_InvoiceTransactionItem_t WHERE W_MATERIALS.MATERIAL_NO=m_InvoiceTransactionItem_t.MaterialNO AND m_InvoiceTransactionItem_t.InvoiceTransactionId='" & strTransactionId & "' ")
            strSQL.AppendLine(" UPDATE W_REELS_T SET DELETEFLAG='1' FROM m_InvoiceTransactionItem_t ")
            strSQL.AppendLine(" WHERE W_REELS_T.RECEIVENO=m_InvoiceTransactionItem_t.InvoiceTransactionId AND m_InvoiceTransactionItem_t.InvoiceTransactionId='" & strTransactionId & "' ")

            Conn.ExecSql(strSQL.ToString())
            GetTransaction(nodeTag, nodeText)
            GetMesData.SetMessage(Me.lblMessage, "删除成功", True)
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Me.dgvInvoiceTransaction.Rows.Count = 0 OrElse Me.dgvInvoiceTransaction.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要修改单据", False)
            Exit Sub
        End If

        Dim strInvoiceDefinitionsTypeName As String
        Try
            Dim TransactionId As String
            TransactionId = Me.dgvInvoiceTransaction.Rows(Me.dgvInvoiceTransaction.CurrentRow.Index).Cells("TransactionId").Value.ToString
            If (String.IsNullOrEmpty(nodeTag)) Then
                strInvoiceDefinitionsTypeName = ""
            Else
                strInvoiceDefinitionsTypeName = nodeText
            End If
            Dim warehouseingMaster As New FrmWarehouseingMaster(strInvoiceDefinitionsTypeName, TransactionId)
            warehouseingMaster.ShowDialog()

            GetTransaction(nodeTag, nodeText)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        GetTransaction(nodeTag, nodeText)
    End Sub

    Private Sub btnPrinter_Click(sender As Object, e As EventArgs) Handles btnPrinter.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)

        If Me.dgvInvoiceTransaction.Rows.Count = 0 OrElse Me.dgvInvoiceTransaction.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择打印单据", False)
            Me.dgvInvoiceTransactionItem.Rows.Clear()
            Exit Sub
        End If

        Dim TransactionId As String = Me.dgvInvoiceTransaction.Rows(Me.dgvInvoiceTransaction.CurrentRow.Index).Cells("TransactionId").Value.ToString
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
            Dim CurrIndex As Int16 = Me.dgvInvoiceTransaction.CurrentRow.Index
            Dim TransactionTypeName As String = IIf(IsDBNull(Me.dgvInvoiceTransaction.Rows(CurrIndex).Cells("InvoiceTransactionTypeName").Value), "", Me.dgvInvoiceTransaction.Rows(CurrIndex).Cells("InvoiceTransactionTypeName").Value)
            Dim CreateTime As String = IIf(IsDBNull(Me.dgvInvoiceTransaction.Rows(CurrIndex).Cells("CreateTime1").Value), "", Microsoft.VisualBasic.Left(Me.dgvInvoiceTransaction.Rows(CurrIndex).Cells("CreateTime1").Value.ToString, 10))
            Dim AttentionName As String = IIf(IsDBNull(Me.dgvInvoiceTransaction.Rows(CurrIndex).Cells("AttentionName").Value), "", Me.dgvInvoiceTransaction.Rows(CurrIndex).Cells("AttentionName").Value)
            Dim SupplierName As String = IIf(IsDBNull(Me.dgvInvoiceTransaction.Rows(CurrIndex).Cells("SupplierName").Value), "", Me.dgvInvoiceTransaction.Rows(CurrIndex).Cells("SupplierName").Value)
            Dim DeliveryName As String = IIf(IsDBNull(Me.dgvInvoiceTransaction.Rows(CurrIndex).Cells("DeliveryName").Value), "", Me.dgvInvoiceTransaction.Rows(CurrIndex).Cells("DeliveryName").Value)
            Dim Remark As String = IIf(IsDBNull(Me.dgvInvoiceTransaction.Rows(CurrIndex).Cells("Remark").Value), "", Me.dgvInvoiceTransaction.Rows(CurrIndex).Cells("Remark").Value)

            Dim cell As New PdfPCell(New Phrase("出库单", fontHeader))
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
            For i As Int16 = 0 To Me.dgvInvoiceTransactionItem.RowCount - 1
                MaterialNO = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(i).Cells("MaterialNO").Value), "", Me.dgvInvoiceTransactionItem.Rows(i).Cells("MaterialNO").Value)
                Description = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(i).Cells("Description").Value), "", Me.dgvInvoiceTransactionItem.Rows(i).Cells("Description").Value)
                Specification = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(i).Cells("Specification").Value), "", Me.dgvInvoiceTransactionItem.Rows(i).Cells("Specification").Value)
                Uint = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(i).Cells("Uint").Value), "", Me.dgvInvoiceTransactionItem.Rows(i).Cells("Uint").Value)
                WarehouseLocationId = ""
                Quantity = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(i).Cells("Quantity").Value), "", Me.dgvInvoiceTransactionItem.Rows(i).Cells("Quantity").Value)
                OrderNumber = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(i).Cells("OrderNumber").Value), "", Me.dgvInvoiceTransactionItem.Rows(i).Cells("OrderNumber").Value)
                ItemRemark = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(i).Cells("ItemRemark").Value), "", Me.dgvInvoiceTransactionItem.Rows(i).Cells("ItemRemark").Value)

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
#End Region

#Region "控件事件"

    Private Sub tvWarehousing_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvWarehousing.NodeMouseClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        nodeTag = e.Node.Tag
        nodeText = e.Node.Text
        If (String.IsNullOrEmpty(e.Node.Tag)) Then
            Me.dgvInvoiceTransaction.Rows.Clear()
            Me.dgvInvoiceTransactionItem.Rows.Clear()
            Exit Sub
        End If
        GetTransaction(nodeTag, nodeText)

    End Sub

    Private Sub dgvInvoiceTransaction_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoiceTransaction.CellEnter
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvInvoiceTransaction.Rows.Count = 0 OrElse Me.dgvInvoiceTransaction.CurrentRow Is Nothing Then
            Me.dgvInvoiceTransactionItem.Rows.Clear()
            Exit Sub
        End If

        Try
            GetTransactionItem(Me.dgvInvoiceTransaction.Rows(Me.dgvInvoiceTransaction.CurrentRow.Index).Cells("TransactionId").Value.ToString())
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub dgvInvoiceTransactionItem_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoiceTransactionItem.CellEnter
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvInvoiceTransactionItem.Rows.Count = 0 OrElse Me.dgvInvoiceTransactionItem.CurrentRow Is Nothing Then
            Me.dgvBarcode.Rows.Clear()
            Exit Sub
        End If

        Try
            Me.dgvBarcode.DataSource = GetMesData.GetScanBarcode(Me.dgvInvoiceTransaction.Rows(Me.dgvInvoiceTransaction.CurrentRow.Index).Cells("TransactionId").Value.ToString(), Me.dgvInvoiceTransactionItem.Rows(Me.dgvInvoiceTransactionItem.CurrentRow.Index).Cells("MaterialNO").Value.ToString())
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常!", False)
        End Try
    End Sub
#End Region

#Region "函数"

    Private Sub LoadTree()
        Dim strSQL As String
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象

        Dim node As TreeNode = New TreeNode
        node.Tag = ""
        node.Text = "出库库单"

        Me.tvWarehousing.Nodes.Add(node)

        Try
            strSQL = "SELECT InvoiceDefinitionsId, InvoiceDefinitionsName FROM m_InvoiceDefinitions_t WHERE InvoiceDefinitionsType='2'"
            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()

            If (Not dtTemp Is Nothing) Then
                For I As Int16 = 0 To dtTemp.Rows.Count - 1
                    Dim nodeChild As TreeNode = New TreeNode
                    nodeChild.Tag = dtTemp.Rows(I).Item("InvoiceDefinitionsId").ToString
                    nodeChild.Text = dtTemp.Rows(I).Item("InvoiceDefinitionsName").ToString
                    node.Nodes.Add(nodeChild)
                Next
            End If
            Me.tvWarehousing.ExpandAll()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub GetTransaction(ByVal nodeTag As String, ByVal nodeText As String)
        Dim strSQL As String
        Dim strWhere As String = ""

        If Not (String.IsNullOrEmpty(nodeTag)) Then
            strWhere = " AND InvoiceTransactionType='" & nodeTag & "' "
        Else
            Exit Sub
        End If

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader

        Try

            If Not (String.IsNullOrEmpty(Me.dtpDate.Text.Trim)) Then
                strWhere = strWhere & " AND CONVERT(VARCHAR(10), m_InvoiceTransaction_t.CreateTime, 23) = '" & Me.dtpDate.Text.Trim & "' "
            End If

            If Not (String.IsNullOrEmpty(Me.txtTransactionId.Text.Trim)) Then
                strWhere = strWhere & " AND TransactionId='" & Me.txtTransactionId.Text.Trim.Replace("'", "''") & "'"
            End If

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY TransactionId )as RowNum, InvoiceTransactionId, m_InvoiceDefinitions_t.InvoiceDefinitionsName, TransactionId, WarehouseId, WarehouseName, DeptId, DeptName, " & _
                     " SupplierId, SupplierName, TotalAmount, DeliveryId, DeliveryName, AttentionName, TotalNumber, TotalConversionUnits, OrderNumber, CheckUser, Remark, m_InvoiceTransaction_t.UpdateTime, " & _
                     " m_InvoiceTransaction_t.UpdateUser, m_InvoiceTransaction_t.CreateTime, m_InvoiceTransaction_t.CreateUser, CASE StatusFlag WHEN '1' THEN N'已审核' ELSE N'未审核'  END AS StatusFlag " & _
                     " FROM  m_InvoiceTransaction_t " & _
                     "     INNER JOIN m_InvoiceDefinitions_t ON m_InvoiceDefinitions_t.InvoiceDefinitionsId=m_InvoiceTransaction_t.InvoiceTransactionType " & _
                     " WHERE 1=1 AND m_InvoiceTransaction_t.FactoryId='" & VbCommClass.VbCommClass.Factory & "' AND m_InvoiceTransaction_t.Profitcenter='" & VbCommClass.VbCommClass.profitcenter & "' AND DeleteFlag='0' " & strWhere & " ORDER BY  m_InvoiceTransaction_t.CreateTime DESC"

            Me.dgvInvoiceTransaction.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)
            If Not (DReader.HasRows) Then
                Me.dgvInvoiceTransactionItem.Rows.Clear()
            End If
            Do While DReader.Read()
                Me.dgvInvoiceTransaction.Rows.Add(DReader.Item("InvoiceTransactionId").ToString, DReader.Item("RowNum").ToString, DReader.Item("InvoiceDefinitionsName").ToString, DReader.Item("TransactionId").ToString, DReader.Item("CreateTime").ToString, DReader.Item("WarehouseName").ToString, DReader.Item("DeptName").ToString, DReader.Item("SupplierName").ToString, DReader.Item("TotalAmount").ToString, DReader.Item("DeliveryName").ToString, DReader.Item("AttentionName").ToString, "", DReader.Item("TotalNumber").ToString, _
                                                  DReader.Item("TotalConversionUnits").ToString, DReader.Item("Remark").ToString, DReader.Item("CreateUser").ToString, DReader.Item("CreateTime").ToString, DReader.Item("UpdateUser").ToString, DReader.Item("UpdateTime").ToString, DReader.Item("StatusFlag").ToString)
            Loop

            DReader.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception
            If Not (DReader.IsClosed) Then
                DReader.Close()
            End If

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub GetTransactionItem(ByVal InvoiceTransactionId As String)
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY InvoiceTransactionId )as RowNum, InvoiceTransactionItemId, InvoiceTransactionId, MaterialNO, Description, Specification, Uint, Quantity, UnitPrice, " & _
                     " TotalAmount, OrderNumber, Remark, CreateUser, CreateTime, UpdateUser, UpdateTime " & _
                     " FROM  m_InvoiceTransactionItem_t " & _
                     " WHERE InvoiceTransactionId = '" & InvoiceTransactionId & "'"

            Me.dgvInvoiceTransactionItem.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)
           
            Do While DReader.Read()
                Me.dgvInvoiceTransactionItem.Rows.Add(DReader.Item("RowNum").ToString, DReader.Item("MaterialNO").ToString, DReader.Item("Description").ToString, DReader.Item("Specification").ToString, DReader.Item("Uint").ToString, DReader.Item("Quantity").ToString, DReader.Item("UnitPrice").ToString, DReader.Item("TotalAmount").ToString, DReader.Item("OrderNumber").ToString, DReader.Item("Remark").ToString)
            Loop

            DReader.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception
            If Not (DReader.IsClosed) Then
                DReader.Close()
            End If

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

    
End Class