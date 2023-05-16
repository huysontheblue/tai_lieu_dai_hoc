
'--盘点查询
'--Create by :　马锋
'--Create date :　2015/08/05
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

Public Class FrmStoreRequisitionQuery

#Region "变量声明"
    Dim nodeTag As String
    Dim nodeText As String
#End Region

#Region "加载事件"

    Private Sub FrmStoreRequisitionQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.dgvStoreRequisition.AutoGenerateColumns = False
            Me.dgvStoreRequisitionItem.AutoGenerateColumns = False
            Me.dgvBarcode.AutoGenerateColumns = False
            '加载菜单
            LoadTree()
            LoadControlStatus()
            Me.dtpDate.Value = Now
            Me.SuperTabControl1.SelectedTabIndex = 0
            GetStoreRequisition(nodeTag, nodeText)
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
            Dim storeRequisitionMaster As New FrmStoreRequisitionMaster(strInvoiceDefinitionsTypeName, "")
            storeRequisitionMaster.ShowDialog()
            GetStoreRequisition(nodeTag, nodeText)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Me.dgvStoreRequisition.Rows.Count = 0 OrElse Me.dgvStoreRequisition.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要删除单据", False)
            Exit Sub
        End If
        Dim strSQL As New StringBuilder
        Dim strTransactionId As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            strTransactionId = Me.dgvStoreRequisition.Rows(Me.dgvStoreRequisition.CurrentRow.Index).Cells("TransactionId").Value.ToString
            strSQL.AppendLine(" UPDATE m_StoreRequisition_t SET DeleteFlag='1' WHERE TransactionId='" & strTransactionId & "' ")
            strSQL.AppendLine(" UPDATE m_StoreRequisitionItem_t SET DeleteFlag='1' WHERE TransactionId='" & strTransactionId & "' ")

            Conn.ExecSql(strSQL.ToString())
            GetStoreRequisition(nodeTag, nodeText)
            GetMesData.SetMessage(Me.lblMessage, "删除成功", True)
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Me.dgvStoreRequisition.Rows.Count = 0 OrElse Me.dgvStoreRequisition.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要修改单据", False)
            Exit Sub
        End If

        Dim strInvoiceDefinitionsTypeName As String
        Try
            Dim TransactionId As String
            TransactionId = Me.dgvStoreRequisition.Rows(Me.dgvStoreRequisition.CurrentRow.Index).Cells("TransactionId").Value.ToString
            If (String.IsNullOrEmpty(nodeTag)) Then
                strInvoiceDefinitionsTypeName = ""
            Else
                strInvoiceDefinitionsTypeName = nodeText
            End If
            Dim warehouseingMaster As New FrmWarehouseingMaster(strInvoiceDefinitionsTypeName, TransactionId)
            warehouseingMaster.ShowDialog()

            GetStoreRequisition(nodeTag, nodeText)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        GetStoreRequisition(nodeTag, nodeText)
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click

    End Sub

#End Region

#Region "控件事件"

    Private Sub tvStoreRequisition_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvStoreRequisition.NodeMouseClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        nodeTag = e.Node.Tag
        nodeText = e.Node.Text
        If (String.IsNullOrEmpty(e.Node.Tag)) Then
            Me.dgvStoreRequisition.Rows.Clear()
            Me.dgvStoreRequisitionItem.Rows.Clear()
            Exit Sub
        End If
        GetStoreRequisition(nodeTag, nodeText)

    End Sub

    Private Sub dgvStoreRequisition_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStoreRequisition.CellEnter
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvStoreRequisition.Rows.Count = 0 OrElse Me.dgvStoreRequisition.CurrentRow Is Nothing Then
            Me.dgvStoreRequisitionItem.Rows.Clear()
            Exit Sub
        End If

        Try
            GetStoreRequisitionItem(Me.dgvStoreRequisition.Rows(Me.dgvStoreRequisition.CurrentRow.Index).Cells("TransactionId").Value.ToString())
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "", False)
        End Try
    End Sub

    Private Sub dgvStoreRequisitionItem_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStoreRequisitionItem.CellEnter
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvStoreRequisitionItem.Rows.Count = 0 OrElse Me.dgvStoreRequisitionItem.CurrentRow Is Nothing Then
            Me.dgvBarcode.Rows.Clear()
            Exit Sub
        End If

        Try
            Me.dgvBarcode.DataSource = GetMesData.GetScanBarcode(Me.dgvStoreRequisition.Rows(Me.dgvStoreRequisition.CurrentRow.Index).Cells("TransactionId").Value.ToString(), Me.dgvStoreRequisitionItem.Rows(Me.dgvStoreRequisitionItem.CurrentRow.Index).Cells("MaterialNO").Value.ToString())
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
        Me.ActiveControl = Me.tvStoreRequisition
        Dim node As TreeNode = New TreeNode
        node.Tag = ""
        node.Text = "调拨管理"

        Me.tvStoreRequisition.Nodes.Add(node)

        Try
            strSQL = "SELECT InvoiceDefinitionsId, InvoiceDefinitionsName FROM m_InvoiceDefinitions_t WHERE InvoiceDefinitionsType='5'"
            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()

            If (Not dtTemp Is Nothing) Then
                For I As Int16 = 0 To dtTemp.Rows.Count - 1
                    Dim nodeChild As TreeNode = New TreeNode
                    nodeChild.Tag = dtTemp.Rows(I).Item("InvoiceDefinitionsId").ToString
                    nodeChild.Text = dtTemp.Rows(I).Item("InvoiceDefinitionsName").ToString
                    node.Nodes.Add(nodeChild)
                    'If (I = 0) Then
                    '    Me.tvStoreRequisition.SelectedNode = nodeChild
                    'End If
                Next
            End If
            Me.tvStoreRequisition.ExpandAll()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub LoadControlStatus()
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            strSQL = "SELECT PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'AllocationCheck'"
            DReader = Conn.GetDataReader(strSQL)

            If (DReader.HasRows) Then
                DReader.Read()
                If (DReader.Item(0).ToString = "Y") Then
                    Me.btnCheck.Enabled = True
                Else
                    Me.btnCheck.Enabled = False
                End If
            Else
                Me.btnCheck.Enabled = False
            End If
            DReader.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Not DReader Is Nothing And Not DReader.IsClosed) Then
                DReader.Close()
            End If

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub GetStoreRequisition(ByVal nodeTag As String, ByVal nodeText As String)
        Dim strSQL As String
        Dim strWhere As String = ""

        If Not (String.IsNullOrEmpty(nodeTag)) Then
            strWhere = " AND InvoiceTransactionType='" & nodeTag & "' "
            'Else
            '    Exit Sub
        End If

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader

        Try

            If Not (String.IsNullOrEmpty(Me.dtpDate.Text.Trim)) Then
                strWhere = strWhere & " AND CONVERT(VARCHAR(10), m_StoreRequisition_t.CreateTime, 23) = '" & Me.dtpDate.Text.Trim & "' "
            End If

            If Not (String.IsNullOrEmpty(Me.txtTransactionId.Text.Trim)) Then
                strWhere = strWhere & " AND TransactionId='" & Me.txtTransactionId.Text.Trim.Replace("'", "''") & "'"
            End If

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY StoreRequisitionId )as RowNum, StoreRequisitionId, InvoiceTransactionType, m_InvoiceDefinitions_t.InvoiceDefinitionsName, TransactionId, CallInWarehouseId, CallInWarehouseName, " & _
                     " CallOutWarehouseId, CallOutWarehouseName, AttentionName, Remark, CASE m_StoreRequisition_t.StatusFlag WHEN '1' THEN N'已审核' ELSE N'未审核'  END AS StatusFlag, m_StoreRequisition_t.UpdateTime, " & _
                     " m_StoreRequisition_t.UpdateUser, m_StoreRequisition_t.CreateTime, m_StoreRequisition_t.CreateUser " & _
                     " FROM  m_StoreRequisition_t " & _
                     "     INNER JOIN m_InvoiceDefinitions_t ON m_InvoiceDefinitions_t.InvoiceDefinitionsId=m_StoreRequisition_t.InvoiceTransactionType " & _
                     " WHERE 1=1 AND m_StoreRequisition_t.FactoryId='" & VbCommClass.VbCommClass.Factory & "' AND m_StoreRequisition_t.Profitcenter='" & VbCommClass.VbCommClass.profitcenter & "' AND DeleteFlag='0' " & strWhere & " ORDER BY  m_StoreRequisition_t.CreateTime DESC"

            Me.dgvStoreRequisition.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)
            If Not (DReader.HasRows) Then
                Me.dgvStoreRequisitionItem.Rows.Clear()
            End If
            Do While DReader.Read()
                Me.dgvStoreRequisition.Rows.Add(DReader.Item("StoreRequisitionId").ToString, DReader.Item("RowNum").ToString, DReader.Item("InvoiceDefinitionsName").ToString, DReader.Item("TransactionId").ToString, DReader.Item("CallInWarehouseName").ToString, DReader.Item("CallOutWarehouseName").ToString, DReader.Item("AttentionName").ToString, _
                                                DReader.Item("Remark").ToString, DReader.Item("CreateUser").ToString, DReader.Item("CreateTime").ToString, DReader.Item("UpdateUser").ToString, DReader.Item("UpdateTime").ToString, DReader.Item("StatusFlag").ToString)
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
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub GetStoreRequisitionItem(ByVal InvoiceTransactionId As String)
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY StoreRequisitionItemId )as RowNum, StoreRequisitionItemId, TransactionId, MaterialNO, Description, Specification, WarehouseId, WarehouseLocationId, Uint, " & _
                     " UnitPrice, Quantity, CheckQuantity, BarcodeQuantity, TransactionType, OrderNumber, Remark, CreateUser, CreateTime, UpdateUser, UpdateTime, CheckStatus, TotalAmount " & _
                     " FROM  m_StoreRequisitionItem_t " & _
                     " WHERE TransactionId = '" & InvoiceTransactionId & "'"

            Me.dgvStoreRequisitionItem.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)
            
            Do While DReader.Read()
                Me.dgvStoreRequisitionItem.Rows.Add(DReader.Item("RowNum").ToString, DReader.Item("MaterialNO").ToString, DReader.Item("Description").ToString, DReader.Item("Specification").ToString, DReader.Item("Uint").ToString, DReader.Item("Quantity").ToString, DReader.Item("UnitPrice").ToString, DReader.Item("TotalAmount").ToString, DReader.Item("Remark").ToString)
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