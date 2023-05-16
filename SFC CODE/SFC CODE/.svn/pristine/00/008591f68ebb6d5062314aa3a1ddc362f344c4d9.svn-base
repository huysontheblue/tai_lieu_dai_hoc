
'--合约订单维护
'--Create by :　马锋
'--Create date :　2016/06/29
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
Imports MainFrame
#End Region

Public Class FrmCustomerOrderMaster

#Region "变量声明"

    Dim dvTiptopOrder As New DataView
    Dim dvTiptopOrderItem As New DataView
    Dim opFlag As Int16 = 0
    Dim DataType As String
    Dim CustomerOrderItem As DataTable
    Dim _SKUList As DataTable
    
    Public Property SKUList() As DataTable
        Get
            If (_SKUList Is Nothing) Then
                _SKUList = New DataTable()
                _SKUList.Columns.Add("CustomerOrderDetailID", Type.GetType("System.String"))
                _SKUList.Columns.Add("FNSKU", Type.GetType("System.String"))
                _SKUList.Columns.Add("ExportingCountries", Type.GetType("System.String"))
                _SKUList.Columns.Add("ShippingMethod", Type.GetType("System.String"))
                _SKUList.Columns.Add("PRDimensions", Type.GetType("System.String"))
                _SKUList.Columns.Add("CustomerDelivery", Type.GetType("System.String"))
                _SKUList.Columns.Add("ExportQuantity", Type.GetType("System.String"))
                _SKUList.Columns.Add("PrinteQuantity", Type.GetType("System.String"))
                _SKUList.Columns.Add("PackingQuantity", Type.GetType("System.String"))
                _SKUList.Columns.Add("StorageQuantity", Type.GetType("System.String"))
                _SKUList.Columns.Add("ShipmentsQuantity", Type.GetType("System.String"))
                _SKUList.Columns.Add("StatusFlagText", Type.GetType("System.String"))
                _SKUList.Columns.Add("CreateUserId", Type.GetType("System.String"))
                _SKUList.Columns.Add("CreateTime", Type.GetType("System.String"))
                _SKUList.Columns.Add("ModifyUserId", Type.GetType("System.String"))
                _SKUList.Columns.Add("ModifyTime", Type.GetType("System.String"))
            End If
            Return _SKUList
        End Get

        Set(ByVal Value As DataTable)
            _SKUList = Value
        End Set
    End Property

#End Region

#Region "加载事件"

    Private Sub FrmCustomerOrderMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvCustomerOrder.AutoGenerateColumns = False
            Me.dgvCustomerOrderItem.AutoGenerateColumns = False
            Me.dgvCustomerOrderDetail.AutoGenerateColumns = False

            Me.dtpStartTime.Value = Now.AddDays(-1)
            Me.dtpEndTime.Value = Now.AddDays(1)

            SetStatus(opFlag)
        Catch ex As Exception
            SetMessage(lblMessage, "加载合约订单功能异常!", False)
        End Try
    End Sub

#End Region

#Region "工具事件"

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            DataType = "NEW"
            opFlag = 1
            SetStatus(opFlag)
        Catch ex As Exception
            SetMessage(lblMessage, "新增异常!", False)
        End Try
    End Sub

    Private Sub ToolAgain_Click(sender As Object, e As EventArgs) Handles btnAgain.Click
        Try
            DataType = "AGAIN"
            opFlag = 1
            SetStatus(opFlag)
        Catch ex As Exception
            SetMessage(lblMessage, "修改异常!", False)
        End Try
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        SetMessage(lblMessage, "", False)
        Try
            If Me.dgvCustomerOrder.Rows.Count = 0 OrElse Me.dgvCustomerOrder.CurrentRow Is Nothing Then
                SetMessage(lblMessage, "请选择要修改数据", False)
                Exit Sub
            End If
            DataType = "MODIFY"
            opFlag = 2
            SetStatus(opFlag)
        Catch ex As Exception
            SetMessage(lblMessage, "修改异常!", False)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            DataType = "SAVE"
        Catch ex As Exception
            SetMessage(lblMessage, "保存异常!", False)
        End Try
    End Sub

    Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        Try
            DataType = ""
            opFlag = 0
            SetStatus(opFlag)
            getCustomerOrder(Me.txtContractOrder.Text.Trim(), Me.dtpStartTime.Text.Trim, Me.dtpEndTime.Text.Trim)
        Catch ex As Exception
            SetMessage(lblMessage, "返回异常!", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If Me.dgvCustomerOrder.Rows.Count = 0 OrElse Me.dgvCustomerOrder.CurrentRow Is Nothing Then
                SetMessage(lblMessage, "请选择要删除合约订单!", False)
                Exit Sub
            End If
            Dim strCustomerOrder As String = IIf(IsDBNull(Me.dgvCustomerOrder.Rows(Me.dgvCustomerOrder.CurrentRow.Index).Cells("OrderNO").Value), "", Me.dgvCustomerOrder.Rows(Me.dgvCustomerOrder.CurrentRow.Index).Cells("OrderNO").Value)
            Dim strCustomerOrderID As String = IIf(IsDBNull(Me.dgvCustomerOrder.Rows(Me.dgvCustomerOrder.CurrentRow.Index).Cells("CustomerOrderID").Value), "", Me.dgvCustomerOrder.Rows(Me.dgvCustomerOrder.CurrentRow.Index).Cells("CustomerOrderID").Value)

            If (String.IsNullOrEmpty(strCustomerOrder)) Then
                SetMessage(lblMessage, "请选择要删除合约订单号不能为空!", False)
                Exit Sub
            Else
                If (Not CheckDelete(strCustomerOrder)) Then
                    Exit Sub
                End If

                Dim strSQL As String
                strSQL = " UPDATE m_CustomerOrder_t SET DeleteFlag='1' WHERE CustomerOrderID = '" & strCustomerOrderID & "' " & _
                        " UPDATE m_CustomerOrderItem_t SET DeleteFlag='1' WHERE CustomerOrderID = '" & strCustomerOrderID & "' " & _
                        " UPDATE m_CustomerOrderDetail_t SET DeleteFlag='1' WHERE CustomerOrderItemID IN (SELECT CustomerOrderItemID FROM m_CustomerOrderItem_t WHERE  CustomerOrderID = '" & strCustomerOrderID & "')"
                DbOperateUtils.ExecSQL(strSQL)
                getCustomerOrder(Me.txtContractOrder.Text.Trim(), Me.dtpStartTime.Text.Trim, Me.dtpEndTime.Text.Trim)
            End If

        Catch ex As Exception
            SetMessage(lblMessage, "删除异常!", False)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        SetMessage(lblMessage, "", False)
        Try
            If CheckQueryParameter(True) Then
                Return
            End If
            getCustomerOrder(Me.txtContractOrder.Text.Trim(), Me.dtpStartTime.Text.Trim, Me.dtpEndTime.Text.Trim)
        Catch ex As Exception
            SetMessage(lblMessage, "更新异常!", False)
        End Try
    End Sub

    Private Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        Try
            Me.dgvCustomerOrderItem.Enabled = False
            If Me.dgvCustomerOrderItem.Rows.Count = 0 OrElse Me.dgvCustomerOrderItem.CurrentRow Is Nothing Then
                SetMessage(Me.lblMessage, "请选择合约订单项目!", False)
                Exit Sub
            End If

            Dim drTemp As DataRow
            drTemp = SKUList.NewRow

            drTemp("CustomerOrderDetailID") = ""
            drTemp("PrinteQuantity") = "0"
            drTemp("PackingQuantity") = "0"
            drTemp("StorageQuantity") = "0"
            drTemp("ShipmentsQuantity") = "0"

            SKUList.Rows.Add(drTemp)
            SKUList.AcceptChanges()

            Me.dgvCustomerOrderDetail.DataSource = SKUList
        Catch ex As Exception
            SetMessage(lblMessage, "新增行异常!", False)
        End Try
    End Sub

    Private Sub btnSaveRow_Click(sender As Object, e As EventArgs) Handles btnSaveRow.Click
        SetMessage(Me.lblMessage, "", False)
        Try
            Me.dgvCustomerOrderDetail.CommitEdit(DataGridViewDataErrorContexts.Commit)
            Me.dgvCustomerOrderDetail.EndEdit()
            If Not (CheckRowSave()) Then
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            Dim strCustomerOrderDetailId, strCustomerOrderItemID, strPartId, strFNSKU, strExportingCountries, strShippingMethod, strPRDimensions, strCustomerDelivery, strExportQuantity As String

            strCustomerOrderItemID = Me.dgvCustomerOrderItem.Rows(Me.dgvCustomerOrderItem.CurrentRow.Index).Cells("CustomerOrderItemID").Value
            strPartId = Me.dgvCustomerOrderItem.Rows(Me.dgvCustomerOrderItem.CurrentRow.Index).Cells("PartId").Value

            For i As Int16 = 0 To Me.dgvCustomerOrderDetail.Rows.Count - 1
                strCustomerOrderDetailId = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(i).Cells("CustomerOrderDetailID").Value), "", Me.dgvCustomerOrderDetail.Rows(i).Cells("CustomerOrderDetailID").Value)
                strFNSKU = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(i).Cells("FNSKU").Value), "", Me.dgvCustomerOrderDetail.Rows(i).Cells("FNSKU").Value)
                strExportingCountries = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(i).Cells("ExportingCountries").Value), "", Me.dgvCustomerOrderDetail.Rows(i).Cells("ExportingCountries").Value)
                strShippingMethod = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(i).Cells("ShippingMethod").Value), "", Me.dgvCustomerOrderDetail.Rows(i).Cells("ShippingMethod").Value)
                strPRDimensions = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(i).Cells("PRDimensions").Value), "", Me.dgvCustomerOrderDetail.Rows(i).Cells("PRDimensions").Value)
                strCustomerDelivery = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(i).Cells("CustomerDelivery").Value), "", Me.dgvCustomerOrderDetail.Rows(i).Cells("CustomerDelivery").Value)
                strExportQuantity = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(i).Cells("ExportQuantity").Value), "", Me.dgvCustomerOrderDetail.Rows(i).Cells("ExportQuantity").Value)

                If (String.IsNullOrEmpty(strCustomerOrderDetailId)) Then

                    strSQL.AppendLine(" INSERT INTO m_CustomerOrderDetail_t(CustomerOrderItemID, PartId, FNSKU, ExportingCountries, ShippingMethod, PRDimensions, CustomerDelivery, ExportQuantity, CreateUserId, CreateTime)VALUES( ")
                    strSQL.AppendLine(" '" & strCustomerOrderItemID & "', '" & strPartId & "', '" & strFNSKU & "', '" & strExportingCountries & "', '" & strShippingMethod & "', '" & strPRDimensions & "', '" & strCustomerDelivery & "', '" & strExportQuantity & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE())")
                Else

                    strSQL.AppendLine(" UPDATE m_CustomerOrderDetail_t SET FNSKU = '" & strFNSKU & "', ExportingCountries= '" & strExportingCountries & "', ShippingMethod= '" & strShippingMethod & "', PRDimensions= '" & strPRDimensions & "', CustomerDelivery= '" & strCustomerDelivery & "', ExportQuantity= '" & strExportQuantity & "', ")
                    strSQL.AppendLine(" ModifyUserId = '" & VbCommClass.VbCommClass.UseId & "', ModifyTime = GetDate() ")
                    strSQL.AppendLine(" WHERE CustomerOrderDetailID = '" & strCustomerOrderDetailId & "' AND CustomerOrderItemID = '" & strCustomerOrderItemID & "' ")
                End If
            Next

            strSQL.AppendLine(" UPDATE m_CustomerOrderItem_t SET SKUQuantity = (SELECT SUM(ExportQuantity) FROM m_CustomerOrderDetail_t WHERE CustomerOrderItemID = '" & strCustomerOrderItemID & "' AND PartId = '" & strPartId & "' ) WHERE CustomerOrderItemID = '" & strCustomerOrderItemID & "' AND PartId = '" & strPartId & "' ")

            If Not (String.IsNullOrEmpty(strSQL.ToString)) Then
                DbOperateUtils.ExecSQL(strSQL.ToString)
            End If

            opFlag = 0
            SetStatus(opFlag)
            SetMessage(lblMessage, "保存行成功!", False)
        Catch ex As Exception
            SetMessage(lblMessage, "保存行异常!", False)
        End Try
        Me.dgvCustomerOrderItem.Enabled = True
    End Sub

    Private Sub btnDeleteRow_Click(sender As Object, e As EventArgs) Handles btnDeleteRow.Click
        SetMessage(Me.lblMessage, "", False)
        Try
            If Me.dgvCustomerOrderDetail.Rows.Count = 0 OrElse Me.dgvCustomerOrderDetail.CurrentRow Is Nothing Then
                SetMessage(Me.lblMessage, "请选择要删除的行!", False)
                Exit Sub
            End If
            Dim strCustomerOrderDetailID As String = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(Me.dgvCustomerOrderDetail.CurrentRow.Index).Cells("CustomerOrderDetailID").Value), "", Me.dgvCustomerOrderDetail.Rows(Me.dgvCustomerOrderDetail.CurrentRow.Index).Cells("CustomerOrderDetailID").Value)
            If (String.IsNullOrEmpty(strCustomerOrderDetailID)) Then
                Me.dgvCustomerOrderDetail.Rows.RemoveAt(Me.dgvCustomerOrderDetail.CurrentRow.Index)
            Else
                If (Not CheckRowDelete(strCustomerOrderDetailID)) Then
                    Exit Sub
                End If

                Dim strSQL As String
                strSQL = " UPDATE m_CustomerOrderItem_t SET SKUQuantity= SKUQuantity - '" & Me.dgvCustomerOrderDetail.Rows(Me.dgvCustomerOrderDetail.CurrentRow.Index).Cells("ExportQuantity").Value & "' WHERE CustomerOrderItemID = '" & Me.dgvCustomerOrderItem.Rows(Me.dgvCustomerOrderItem.CurrentRow.Index).Cells("CustomerOrderItemID").Value & "' " & _
                        " UPDATE m_CustomerOrderDetail_t SET DeleteFlag='1' WHERE CustomerOrderDetailID = '" & strCustomerOrderDetailID & "' "
                DbOperateUtils.ExecSQL(strSQL)
                Me.dgvCustomerOrderDetail.Rows.RemoveAt(Me.dgvCustomerOrderDetail.CurrentRow.Index)
            End If
            dgvCustomerOrderDetail_CellValueChanged(Nothing, Nothing)
        Catch ex As Exception
            SetMessage(lblMessage, "删除行异常!", False)
        End Try
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Try
            If Me.dgvCustomerOrder.Rows.Count = 0 OrElse Me.dgvCustomerOrder.CurrentRow Is Nothing Then
                SetMessage(lblMessage, "请选择要导入合约订单!", False)
                Exit Sub
            End If

            Dim strOrderNO As String = IIf(IsDBNull(Me.dgvCustomerOrder.Rows(Me.dgvCustomerOrder.CurrentRow.Index).Cells("OrderNO").Value), "", Me.dgvCustomerOrder.Rows(Me.dgvCustomerOrder.CurrentRow.Index).Cells("OrderNO").Value)

            If (String.IsNullOrEmpty(strOrderNO)) Then
                SetMessage(lblMessage, "合约订单不能为空!", False)
                Exit Sub
            End If

            Dim customerOrderImport As FrmCustomerOrderImport = New FrmCustomerOrderImport(strOrderNO)
            customerOrderImport.ShowDialog()

            dgvCustomerOrderItem_CellEnter(Nothing, Nothing)
        Catch ex As Exception
            SetMessage(lblMessage, "导入异常!", False)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            SetMessage(lblMessage, "关闭异常!", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub txtContractOrder_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContractOrder.KeyDown
        SetMessage(lblMessage, "", False)
        Try
            If (e.KeyCode = Keys.Enter) Then

                Me.txtContractOrder.Enabled = False

                If (DataType <> "NEW" And DataType <> "AGAIN") Then
                    Me.txtContractOrder.Enabled = True
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtContractOrder.Text.Trim())) Then
                    Me.txtContractOrder.Enabled = True
                    Me.txtContractOrder.Focus()
                    SetMessage(lblMessage, "下载合约订单不能为空!", False)
                    Exit Sub
                End If

                If (DataType = "AGAIN") Then

                End If

                ClearData()

                If (CheckOrderExist(Me.txtContractOrder.Text.Trim)) Then
                    Me.txtContractOrder.Enabled = True
                Else
                    Dim TiptopConn As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
                    dvTiptopOrder = Nothing
                    dvTiptopOrder = TiptopConn.getDataView(SapCommon.GetCheckTiptopOrderSQL(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, Me.txtContractOrder.Text.Trim()))

                    If Not dvTiptopOrder Is Nothing Then

                        If dvTiptopOrder.Count > 0 Then
                            'Me.dgvCustomerOrder.DataSource = dvTiptopOrder
                            dvTiptopOrderItem = TiptopConn.getDataView(SapCommon.GetCheckTiptopOrderItemSQL(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, Me.txtContractOrder.Text.Trim()))
                            'Me.dgvCustomerOrderItem.DataSource = dvTiptopOrderItem

                            If Not (dvTiptopOrderItem Is Nothing) Then
                                If dvTiptopOrder.Count > 0 Then
                                    Dim strSQL As New StringBuilder
                                    strSQL.AppendLine("INSERT INTO m_CustomerOrder_t(FactoryId, Profitcenter, OrderNO, DeliveryCustomerId, DeliveryCustomerName, ModifiedVersion, ContractDate, CustomerOrderNO, TerminalCustomerOrderNO, CreateUserId, CreateTime) VALUES(")
                                    strSQL.AppendLine(" '" & VbCommClass.VbCommClass.Factory & "', '" & VbCommClass.VbCommClass.profitcenter & "', '" & dvTiptopOrder.Table.Rows(0).Item("OrderNO").ToString & "', '" & dvTiptopOrder.Table.Rows(0).Item("DeliveryCustomerId").ToString & "', N'" & dvTiptopOrder.Table.Rows(0).Item("DeliveryCustomerName").ToString & "', N'" & dvTiptopOrder.Table.Rows(0).Item("ModifiedVersion").ToString & "', '" & dvTiptopOrder.Table.Rows(0).Item("ContractDate").ToString & "', ")
                                    strSQL.AppendLine(" '" & dvTiptopOrder.Table.Rows(0).Item("CustomerOrderNO").ToString & "', '" & dvTiptopOrder.Table.Rows(0).Item("TerminalCustomerOrderNO").ToString & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE() )")
                                    strSQL.AppendLine(" DECLARE @CustomerOrderID VARCHAR(32) SELECT @CustomerOrderID = CustomerOrderID FROM m_CustomerOrder_t WHERE ORDERNO = '" & Me.txtContractOrder.Text.Trim() & "' ")

                                    For i As Int16 = 0 To dvTiptopOrderItem.Count - 1
                                        strSQL.AppendLine("INSERT INTO m_CustomerOrderItem_t(CustomerOrderID, ItemNO, PartId, CustomerPartId, ProductSpecifications, Quantity, Unit, TitleMini, CreateUserId, CreateTime) VALUES(")
                                        strSQL.AppendLine(" @CustomerOrderID, '" & dvTiptopOrderItem.Table.Rows(i).Item("ItemNO").ToString & "', '" & dvTiptopOrderItem.Table.Rows(i).Item("PartId").ToString & "', '" & dvTiptopOrderItem.Table.Rows(i).Item("CustomerPartId").ToString & "', N'" & dvTiptopOrderItem.Table.Rows(i).Item("ProductSpecifications").ToString & "', '" & dvTiptopOrderItem.Table.Rows(i).Item("Quantity").ToString & "', ")
                                        strSQL.AppendLine(" N'" & dvTiptopOrderItem.Table.Rows(i).Item("Unit").ToString & "', N'" & dvTiptopOrderItem.Table.Rows(i).Item("TitleMini").ToString & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE())")
                                    Next

                                    If Not (String.IsNullOrEmpty(strSQL.ToString())) Then
                                        DbOperateUtils.ExecSQL(strSQL.ToString)
                                        getCustomerOrder(Me.txtContractOrder.Text.Trim(), Me.dtpStartTime.Text.Trim, Me.dtpEndTime.Text.Trim)
                                    End If

                                Else
                                    Me.txtContractOrder.Enabled = True
                                    SetMessage(lblMessage, "下载合约订单[" & Me.txtContractOrder.Text.Trim & "]单身不存在!", False)
                                    Me.txtContractOrder.Text = ""
                                End If
                            End If
                        Else
                            Me.txtContractOrder.Enabled = True
                            SetMessage(lblMessage, "下载合约订单[" & Me.txtContractOrder.Text.Trim & "]不存在!", False)
                            Me.txtContractOrder.Text = ""
                        End If
                    End If
                    Me.txtContractOrder.Enabled = True
                End If
            End If
        Catch ex As Exception
            Me.txtContractOrder.Enabled = True
            SetMessage(lblMessage, "加载合约订单信息异常!", False)
        End Try
    End Sub

    Private Sub dgvCustomerOrder_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomerOrder.CellEnter
        Try
            If Me.dgvCustomerOrder.Rows.Count = 0 OrElse Me.dgvCustomerOrder.CurrentRow Is Nothing Then
                Exit Sub
            End If

            getCustomerOrderItem(Me.dgvCustomerOrder.Rows(Me.dgvCustomerOrder.CurrentRow.Index).Cells("CustomerOrderID").Value.ToString())
        Catch ex As Exception
            SetMessage(lblMessage, "获取合约订单单身异常!", False)
        End Try
    End Sub

    Private Sub dgvCustomerOrderItem_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomerOrderItem.CellEnter
        Try
            If Me.dgvCustomerOrderItem.Rows.Count = 0 OrElse Me.dgvCustomerOrderItem.CurrentRow Is Nothing Then
                Exit Sub
            End If

            getCustomerOrderDetail(Me.dgvCustomerOrderItem.Rows(Me.dgvCustomerOrderItem.CurrentRow.Index).Cells("CustomerOrderItemID").Value.ToString)
        Catch ex As Exception
            SetMessage(lblMessage, "获取出货信息异常!", False)
        End Try
    End Sub

    Private Sub dgvCustomerOrderDetail_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomerOrderDetail.CellValueChanged
        Try
            If Me.dgvCustomerOrderItem.Rows.Count = 0 OrElse Me.dgvCustomerOrderItem.CurrentRow Is Nothing Then
                Exit Sub
            End If

            If Me.dgvCustomerOrderDetail.Rows.Count = 0 Then
                Exit Sub
            End If

            Me.dgvCustomerOrderDetail.CommitEdit(DataGridViewDataErrorContexts.Commit)

            Dim iSKUQuantity As Int64 = 0
            For i As Int16 = 0 To Me.dgvCustomerOrderDetail.Rows.Count - 1
                iSKUQuantity = iSKUQuantity + Me.dgvCustomerOrderDetail.Rows(i).Cells("ExportQuantity").FormattedValue
            Next
            Me.dgvCustomerOrderItem.Rows(Me.dgvCustomerOrderItem.CurrentRow.Index).Cells("SKUQuantity").Value = iSKUQuantity
        Catch ex As Exception
            SetMessage(lblMessage, "计算SKU数量异常,请确认输入出货数据是否为数字!", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Function CheckQueryParameter(ByVal MessageFlag As Boolean) As Boolean
        If (dtpEndTime.Value < dtpStartTime.Value) Then
            If (MessageFlag) Then
                MsgBox("查询结束时间不能大于开始时间！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
            End If
            Return True
        End If

        Return False
    End Function

    Private Sub getCustomerOrder(ByVal strContractOrder As String, ByVal strStartTime As String, ByVal strEndTime As String)
        Try
            Dim strSQL As String
            strSQL = "SELECT   CustomerOrderID, FactoryId, Profitcenter, OrderNO, DeliveryCustomerId, DeliveryCustomerName, ModifiedVersion, " & _
                    " ContractDate, CustomerOrderNO, TerminalCustomerOrderNO, CreateUserId, CreateTime, ModifyUserId,ModifyTime " & _
                    " FROM m_CustomerOrder_t WHERE DeleteFlag = '0' AND CreateTime BETWEEN '" & strStartTime & "' AND '" & strEndTime & "' "

            If Not (String.IsNullOrEmpty(strContractOrder)) Then
                strSQL = strSQL + " AND OrderNO='" & strContractOrder & "' "
            End If
            Me.dgvCustomerOrder.DataSource = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
            SetMessage(lblMessage, "获取合约订单单头异常!", False)
        End Try
    End Sub

    Private Sub getCustomerOrderItem(ByVal strCustomerOrderID As String)
        Try
            Dim strSQL As String
            strSQL = "SELECT   CustomerOrderItemID, ItemNO, PartId, CustomerPartId, ProductSpecifications, Quantity, SKUQuantity, Unit, TitleMini, CreateUserId, CreateTime " & _
                    " FROM  m_CustomerOrderItem_t WHERE CustomerOrderID = '" & strCustomerOrderID & "' AND DeleteFlag = '0'"
            Me.dgvCustomerOrderItem.DataSource = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
            SetMessage(lblMessage, "获取合约订单单身异常!", False)
        End Try
    End Sub

    Private Sub getCustomerOrderDetail(ByVal strCustomerOrderItemID As String)
        Try
            Dim strSQL As String
            strSQL = "SELECT   CONVERT(VARCHAR(16), CustomerOrderDetailID) AS CustomerOrderDetailID, PartId, FNSKU, ExportingCountries, ShippingMethod, PRDimensions, CustomerDelivery, " & _
                    " ExportQuantity, PrinteQuantity, PackingQuantity, StorageQuantity, ShipmentsQuantity, StatusFlag, CreateUserId, m_CustomerOrderDetail_t.CreateTime, ModifyUserId, ModifyTime, m_SettingParameter_t.PARAMETER_NAME AS StatusFlagText  " & _
                    " FROM  m_CustomerOrderDetail_t INNER JOIN m_SettingParameter_t ON m_SettingParameter_t.PARAMETER_VALUE = m_CustomerOrderDetail_t.StatusFlag AND PARAMETER_MODE ='SKUStatusFlagText' " & _
                    " WHERE CustomerOrderItemID = '" & strCustomerOrderItemID & "' AND DeleteFlag = '0' "
            SKUList = DbOperateUtils.GetDataTable(strSQL)
            Me.dgvCustomerOrderDetail.DataSource = SKUList   'DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
            SetMessage(lblMessage, "获取合约订单SKU信息异常!", False)
        End Try
    End Sub

    Private Function CheckOrderExist(ByVal strContractOrder As String) As Boolean
        Try
            Dim dtTemp As DataTable
            dtTemp = DbOperateUtils.GetDataTable("SELECT CustomerOrderID FROM m_CustomerOrder_t WHERE ORDERNO = '" & strContractOrder & "' AND DeleteFlag = '0' ")
            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                SetMessage(lblMessage, "下载合约订单[" & Me.txtContractOrder.Text.Trim & "]已经下载!", False)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            SetMessage(lblMessage, "检查合约订单信息异常!", False)
            Return True
        End Try
    End Function


    Private Function CheckRowSave() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (Me.dgvCustomerOrderDetail.Rows.Count = 0) Then
                SetMessage(lblMessage, "没有任何保存数据!", False)
                rtValue = False
            Else
                Dim strFNSKU, strExportingCountries, strShippingMethod, strPRDimensions, strCustomerDelivery, strExportQuantity As String
                Dim CheckFor As Boolean = True
                Dim dQuantity As Double = 0
                Dim dCheckQuantity As Double = 0

                For i As Int16 = 0 To Me.dgvCustomerOrderDetail.Rows.Count - 1
                    strFNSKU = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(i).Cells("FNSKU").Value), "", Me.dgvCustomerOrderDetail.Rows(i).Cells("FNSKU").Value)
                    strExportingCountries = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(i).Cells("ExportingCountries").Value), "", Me.dgvCustomerOrderDetail.Rows(i).Cells("ExportingCountries").Value)
                    strShippingMethod = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(i).Cells("ShippingMethod").Value), "", Me.dgvCustomerOrderDetail.Rows(i).Cells("ShippingMethod").Value)
                    strPRDimensions = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(i).Cells("PRDimensions").Value), "", Me.dgvCustomerOrderDetail.Rows(i).Cells("PRDimensions").Value)
                    strCustomerDelivery = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(i).Cells("CustomerDelivery").Value), "", Me.dgvCustomerOrderDetail.Rows(i).Cells("CustomerDelivery").Value)
                    strExportQuantity = IIf(IsDBNull(Me.dgvCustomerOrderDetail.Rows(i).Cells("ExportQuantity").Value), "", Me.dgvCustomerOrderDetail.Rows(i).Cells("ExportQuantity").Value)

                    'If (String.IsNullOrEmpty(strFNSKU)) Then
                    '    rtValue = False
                    '    CheckFor = False
                    '    SetMessage(Me.lblMessage, "第" & i + 1 & "行输入FNSKU不能为空", False)
                    '    Exit For
                    'End If

                    If (String.IsNullOrEmpty(strExportingCountries)) Then
                        rtValue = False
                        CheckFor = False
                        SetMessage(Me.lblMessage, "第" & i + 1 & "行输入出口国家不能为空", False)
                        Exit For
                    End If

                    If (String.IsNullOrEmpty(strShippingMethod)) Then
                        rtValue = False
                        CheckFor = False
                        SetMessage(Me.lblMessage, "第" & i + 1 & "行输入出货方式不能为空", False)
                        Exit For
                    End If

                    If (String.IsNullOrEmpty(strCustomerDelivery)) Then
                        rtValue = False
                        CheckFor = False
                        SetMessage(Me.lblMessage, "第" & i + 1 & "行输入客户交期不能为空", False)
                        Exit For
                    End If

                    If (String.IsNullOrEmpty(strPRDimensions)) Then
                        rtValue = False
                        CheckFor = False
                        SetMessage(Me.lblMessage, "第" & i + 1 & "行输入PR维度不能为空", False)
                        Exit For
                    End If

                    If Not IsNumeric(strExportQuantity) Then
                        rtValue = False
                        CheckFor = False
                        SetMessage(Me.lblMessage, "第" & i + 1 & "行输入交货数量格式错误", False)
                        Exit For
                    End If
                    If (CDbl(strExportQuantity) <= 0) Then
                        rtValue = False
                        CheckFor = False
                        SetMessage(Me.lblMessage, "第" & i + 1 & "行输入交货数量不能小于0", False)
                        Exit For
                    End If
                    dQuantity = dQuantity + strExportQuantity
                Next

                If (dQuantity > CDbl(Me.dgvCustomerOrderItem.Rows(Me.dgvCustomerOrderItem.CurrentRow.Index).Cells("Quantity").Value.ToString)) Then
                    SetMessage(lblMessage, "出货数量不能大于,合约订单数量!", False)
                    rtValue = False
                Else
                    If (CheckFor) Then
                        Dim dtTemp As DataTable
                        dtTemp = DbOperateUtils.GetDataTable("SELECT ISNULL(SUM(ExportQuantity),0) FROM m_CustomerOrderDetail_t WHERE CustomerOrderItemID = '" & Me.dgvCustomerOrderItem.Rows(Me.dgvCustomerOrderItem.CurrentRow.Index).Cells("CustomerOrderItemID").Value & "' AND DeleteFlag = '0' ")

                        If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                            dCheckQuantity = dtTemp.Rows(0).Item(0).ToString
                        End If

                        If (dQuantity > dCheckQuantity) Then
                            SetMessage(lblMessage, "出货数量不能大于,合约订单数量!", False)
                            rtValue = False
                        Else
                            rtValue = True
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            SetMessage(lblMessage, "执行保存检查异常!", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

    Private Function CheckDelete(ByVal strOrderNO As String) As Boolean
        Try
            Dim dtTemp As DataTable
            Dim strSQL As String = " SELECT ISNULL(SUM(PrinteQuantity),0) FROM  m_CustomerOrder_t " & _
                                " INNER JOIN m_CustomerOrderItem_t ON m_CustomerOrderItem_t.CustomerOrderID=m_CustomerOrder_t.CustomerOrderID " & _
                                " INNER JOIN m_CustomerOrderDetail_t ON m_CustomerOrderDetail_t.CustomerOrderItemID=m_CustomerOrderItem_t.CustomerOrderItemID " & _
                                " WHERE m_CustomerOrder_t.OrderNO='" & strOrderNO & "' AND m_CustomerOrder_t.DeleteFlag='0' AND m_CustomerOrderItem_t.DeleteFlag='0' AND m_CustomerOrderDetail_t.DeleteFlag='0' "

            dtTemp = DbOperateUtils.GetDataTable(strSQL)
            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                If (CInt(dtTemp.Rows(0).Item(0)) > 0) Then

                    SetMessage(lblMessage, "删除合约订单[" & strOrderNO & "]失败,已经分配打印SKU!", False)
                    Return False
                Else
                    Return True
                End If
            Else
                SetMessage(lblMessage, "删除合约订单" & strOrderNO & "不存在!", False)
                Return False
            End If
        Catch ex As Exception
            SetMessage(lblMessage, "检查合约订单信息异常!", False)
            Return True
        End Try
    End Function

    Private Function CheckRowDelete(ByVal strCustomerOrderDetailID As String) As Boolean
        Try
            Dim dtTemp As DataTable
            dtTemp = DbOperateUtils.GetDataTable("SELECT ISNULL(PrinteQuantity,0) FROM m_CustomerOrderDetail_t WHERE CustomerOrderDetailID = '" & strCustomerOrderDetailID & "' AND DeleteFlag = '0' ")
            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                If (CInt(dtTemp.Rows(0).Item(0)) > 0) Then

                    SetMessage(lblMessage, "删除合约订单SKU项次失败,已经分配打印SKU!", False)
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            SetMessage(lblMessage, "检查合约订单信息异常!", False)
            Return True
        End Try
    End Function


    Private Sub ClearData()
        Try
            Me.dgvCustomerOrder.DataSource = Nothing
            Me.dgvCustomerOrderItem.DataSource = Nothing
            Me.dgvCustomerOrderDetail.DataSource = Nothing

            Me.dgvCustomerOrder.Rows.Clear()
            Me.dgvCustomerOrderItem.Rows.Clear()
            Me.dgvCustomerOrderDetail.Rows.Clear()
        Catch ex As Exception
            SetMessage(lblMessage, "清除数据异常!", False)
        End Try
    End Sub

    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始
                Me.btnNew.Enabled = True
                Me.btnAgain.Enabled = True
                Me.btnModify.Enabled = True
                Me.btnSave.Enabled = False
                Me.btnUndo.Enabled = False
                Me.btnDelete.Enabled = True
                Me.btnRefresh.Enabled = True
                Me.btnAddRow.Enabled = False
                Me.btnSaveRow.Enabled = False
                Me.btnDeleteRow.Enabled = False
                Me.btnImport.Enabled = False

                Me.txtContractOrder.Text = ""
                Me.txtContractOrder.Focus()
                Me.dgvCustomerOrder.Enabled = True
                Me.dgvCustomerOrderItem.Enabled = True
                Me.dgvCustomerOrderDetail.ReadOnly = True
            Case 1    '新增
                Me.btnNew.Enabled = False
                Me.btnAgain.Enabled = False
                Me.btnModify.Enabled = False
                Me.btnSave.Enabled = False
                Me.btnUndo.Enabled = True
                Me.btnDelete.Enabled = False
                Me.btnRefresh.Enabled = False
                Me.btnAddRow.Enabled = True
                Me.btnSaveRow.Enabled = True
                Me.btnDeleteRow.Enabled = True
                Me.btnImport.Enabled = True

                Me.txtContractOrder.Text = ""
                Me.txtContractOrder.Focus()
                Me.dgvCustomerOrder.Enabled = True
                Me.dgvCustomerOrderItem.Enabled = True
                Me.dgvCustomerOrderDetail.ReadOnly = False
                For i As Int16 = 0 To Me.dgvCustomerOrderDetail.ColumnCount - 1
                    If (i < 7) Then
                        Me.dgvCustomerOrderDetail.Columns(i).ReadOnly = False
                    Else
                        Me.dgvCustomerOrderDetail.Columns(i).ReadOnly = True
                    End If
                Next
            Case 2  '修改
                Me.btnNew.Enabled = False
                Me.btnAgain.Enabled = False
                Me.btnModify.Enabled = False
                Me.btnSave.Enabled = False
                Me.btnUndo.Enabled = True
                Me.btnDelete.Enabled = False
                Me.btnRefresh.Enabled = False
                Me.btnAddRow.Enabled = True
                Me.btnSaveRow.Enabled = True
                Me.btnDeleteRow.Enabled = True
                Me.btnImport.Enabled = True

                Me.txtContractOrder.Text = ""
                Me.txtContractOrder.Focus()
                Me.dgvCustomerOrder.Enabled = False
                Me.dgvCustomerOrderItem.Enabled = False

                Me.dgvCustomerOrderDetail.ReadOnly = False
                For i As Int16 = 0 To Me.dgvCustomerOrderDetail.ColumnCount - 1
                    If (i < 7) Then
                        Me.dgvCustomerOrderDetail.Columns(i).ReadOnly = False
                    Else
                        Me.dgvCustomerOrderDetail.Columns(i).ReadOnly = True
                    End If
                Next

        End Select
    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As LabelX, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

#End Region

End Class