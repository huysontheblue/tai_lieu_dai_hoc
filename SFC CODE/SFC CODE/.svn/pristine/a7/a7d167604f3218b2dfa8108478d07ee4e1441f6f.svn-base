'--仓储订单管理
'--Create by :　马锋
'--Create date :　2015/07/31
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
#End Region

Public Class FrmOrderManagement

#Region "变量声明"
    Dim nodeTag As String
    Dim nodeText As String
#End Region

#Region "加载事件"

    Private Sub FrmOrderManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '加载菜单
            LoadTree()
            Me.dgvOrderTranscation.AutoGenerateColumns = False
            Me.dgvOrderTranscationItem.AutoGenerateColumns = False
            Me.dtpDate.Value = Now
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

#Region "工具事件"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
           Dim strInvoiceDefinitionsTypeName As String
            Try
                If (String.IsNullOrEmpty(nodeTag)) Then
                    strInvoiceDefinitionsTypeName = ""
                Else
                    strInvoiceDefinitionsTypeName = nodeText
                End If
                Dim OrderMaster As New FrmOrderMaster(strInvoiceDefinitionsTypeName, "")
                OrderMaster.ShowDialog()
                GetTransaction(nodeTag, nodeText)
            Catch ex As Exception
                GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
            End Try
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try
            Dim checkTranaction As New FrmCheckTranaction()
            checkTranaction.ShowDialog()

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub btnExec_Click(sender As Object, e As EventArgs) Handles btnExec.Click
        Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub tvWarehousing_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvOrder.NodeMouseClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        nodeTag = e.Node.Tag
        nodeText = e.Node.Text
        If (String.IsNullOrEmpty(e.Node.Tag)) Then
            Me.dgvOrderTranscation.Rows.Clear()
            Me.dgvOrderTranscationItem.Rows.Clear()
            Exit Sub
        End If
        GetTransaction(nodeTag, nodeText)

    End Sub

    Private Sub dgvOrderTranscation_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrderTranscation.CellEnter
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvOrderTranscation.Rows.Count = 0 OrElse Me.dgvOrderTranscation.CurrentRow Is Nothing Then
            Exit Sub
        End If

        Try
            GetTransactionItem(Me.dgvOrderTranscation.Rows(Me.dgvOrderTranscation.CurrentRow.Index).Cells("OrderTransactionId").Value.ToString())
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
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
        node.Text = "订单管理"

        Me.tvOrder.Nodes.Add(node)

        Try
            strSQL = "SELECT InvoiceDefinitionsId, InvoiceDefinitionsName FROM m_InvoiceDefinitions_t WHERE InvoiceDefinitionsType='3'"
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
            Me.tvOrder.ExpandAll()
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

            If Not (String.IsNullOrEmpty(Me.dtpDate.Value.ToString.Trim)) Then
                strWhere = strWhere & " AND CONVERT(VARCHAR(10), m_InvoiceTransaction_t.CreateTime, 23) = '" & Me.dtpDate.Value.ToString.Trim & "' "
            End If

            If Not (String.IsNullOrEmpty(Me.txtOrderTransactionId.Text.Trim)) Then
                strWhere = strWhere & " AND TransactionId='" & Me.txtOrderTransactionId.Text.Trim.Replace("'", "''") & "'"
            End If

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY TransactionId )as RowNum, InvoiceTransactionId, m_InvoiceDefinitions_t.InvoiceDefinitionsName, TransactionId, WarehouseId, WarehouseName, DeptId, DeptName, " & _
                     " SupplierId, SupplierName, TotalAmount, DeliveryId, DeliveryName, AttentionName, TotalNumber, TotalConversionUnits, OrderNumber, CheckUser, Remark, m_InvoiceTransaction_t.UpdateTime, " & _
                     " m_InvoiceTransaction_t.UpdateUser, m_InvoiceTransaction_t.CreateTime, m_InvoiceTransaction_t.CreateUser " & _
                     " FROM  m_InvoiceTransaction_t " & _
                     "     INNER JOIN m_InvoiceDefinitions_t ON m_InvoiceDefinitions_t.InvoiceDefinitionsId=m_InvoiceTransaction_t.InvoiceTransactionType " & _
                     " WHERE 1=1 AND m_InvoiceTransaction_t.FactoryId='" & VbCommClass.VbCommClass.Factory & "' AND m_InvoiceTransaction_t.Profitcenter='" & VbCommClass.VbCommClass.profitcenter & "' AND DeleteFlag='0' " & strWhere & " ORDER BY  m_InvoiceTransaction_t.CreateTime DESC"

            Me.dgvOrderTranscation.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)

            Do While DReader.Read()
                Me.dgvOrderTranscation.Rows.Add(DReader.Item("InvoiceTransactionId").ToString, DReader.Item("RowNum").ToString, DReader.Item("InvoiceDefinitionsName").ToString, DReader.Item("TransactionId").ToString, DReader.Item("CreateTime").ToString, DReader.Item("WarehouseName").ToString, DReader.Item("DeptName").ToString, DReader.Item("SupplierName").ToString, DReader.Item("TotalAmount").ToString, DReader.Item("DeliveryName").ToString, DReader.Item("AttentionName").ToString, "", DReader.Item("TotalNumber").ToString, _
                                                  DReader.Item("TotalConversionUnits").ToString, DReader.Item("Remark").ToString, DReader.Item("CreateUser").ToString, DReader.Item("CreateTime").ToString, DReader.Item("UpdateUser").ToString, DReader.Item("UpdateTime").ToString)
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

            Me.dgvOrderTranscationItem.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)

            Do While DReader.Read()
                Me.dgvOrderTranscationItem.Rows.Add(DReader.Item("RowNum").ToString, DReader.Item("MaterialNO").ToString, DReader.Item("Description").ToString, DReader.Item("Specification").ToString, DReader.Item("Uint").ToString, DReader.Item("Quantity").ToString, DReader.Item("UnitPrice").ToString, DReader.Item("TotalAmount").ToString, DReader.Item("OrderNumber").ToString, DReader.Item("Remark").ToString)
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