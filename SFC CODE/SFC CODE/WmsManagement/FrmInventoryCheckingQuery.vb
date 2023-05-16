
'--盘点单
'--Create by :　马锋
'--Create date :　2015/08/04
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

Public Class FrmInventoryCheckingQuery

#Region "变量声明"
    Dim nodeTag As String
    Dim nodeText As String
#End Region

#Region "加载事件"
    Private Sub FrmInventoryCheckingQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '加载菜单
            LoadTree()
            LoadControlStatus()
            Me.dtpDate.Value = Now
            Me.dgvInventoryChecking.AutoGenerateColumns = False
            Me.dgvInventoryCheckingItem.AutoGenerateColumns = False
            Me.dgvBarcode.AutoGenerateColumns = False
            Me.SuperTabControl1.SelectedTabIndex = 0
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
            Dim InventoryCheckingMaster As New FrmInventoryCheckingMaster(strInvoiceDefinitionsTypeName, "")
            InventoryCheckingMaster.ShowDialog()
            GetInventoryChecking(nodeTag, nodeText)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Me.dgvInventoryChecking.Rows.Count = 0 OrElse Me.dgvInventoryChecking.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要删除单据", False)
            Exit Sub
        End If
        Dim strSQL As New StringBuilder
        Dim strTransactionId As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            strTransactionId = Me.dgvInventoryChecking.Rows(Me.dgvInventoryChecking.CurrentRow.Index).Cells("TransactionId").Value.ToString
            strSQL.AppendLine(" UPDATE m_InventoryChecking_t SET DeleteFlag='1' WHERE TransactionId='" & strTransactionId & "' ")
            strSQL.AppendLine(" UPDATE m_InventoryCheckingItem_t SET DeleteFlag='1' WHERE TransactionId='" & strTransactionId & "' ")

            Conn.ExecSql(strSQL.ToString())
            GetInventoryChecking(nodeTag, nodeText)
            GetMesData.SetMessage(Me.lblMessage, "删除成功", True)
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Me.dgvInventoryChecking.Rows.Count = 0 OrElse Me.dgvInventoryChecking.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要修改单据", False)
            Exit Sub
        End If

        Dim strInvoiceDefinitionsTypeName As String
        Try
            Dim TransactionId As String
            TransactionId = Me.dgvInventoryChecking.Rows(Me.dgvInventoryChecking.CurrentRow.Index).Cells("TransactionId").Value.ToString
            If (String.IsNullOrEmpty(nodeTag)) Then
                strInvoiceDefinitionsTypeName = ""
            Else
                strInvoiceDefinitionsTypeName = nodeText
            End If
            Dim warehouseingMaster As New FrmWarehouseingMaster(strInvoiceDefinitionsTypeName, TransactionId)
            warehouseingMaster.ShowDialog()

            GetInventoryChecking(nodeTag, nodeText)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        GetInventoryChecking(nodeTag, nodeText)
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "审核失败", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub tvWarehousing_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvWarehousing.NodeMouseClick
        GetMesData.SetMessage(Me.lblMessage, "", False)
        nodeTag = e.Node.Tag
        nodeText = e.Node.Text
        If (String.IsNullOrEmpty(e.Node.Tag)) Then
            Me.dgvInventoryChecking.Rows.Clear()
            Me.dgvInventoryCheckingItem.Rows.Clear()
            Exit Sub
        End If
        GetInventoryChecking(nodeTag, nodeText)

    End Sub

    Private Sub dgvInventoryChecking_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventoryChecking.CellEnter
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvInventoryChecking.Rows.Count = 0 OrElse Me.dgvInventoryChecking.CurrentRow Is Nothing Then
            Me.dgvInventoryCheckingItem.Rows.Clear()
            Exit Sub
        End If

        Try
            GetInventoryCheckingItem(Me.dgvInventoryChecking.Rows(Me.dgvInventoryChecking.CurrentRow.Index).Cells("TransactionId").Value.ToString())
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub dgvInventoryCheckingItem_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventoryCheckingItem.CellEnter
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvInventoryCheckingItem.Rows.Count = 0 OrElse Me.dgvInventoryCheckingItem.CurrentRow Is Nothing Then
            Me.dgvBarcode.Rows.Clear()
            Exit Sub
        End If

        Try
            Me.dgvBarcode.DataSource = GetMesData.GetInventoryScanBarcode(Me.dgvInventoryChecking.Rows(Me.dgvInventoryChecking.CurrentRow.Index).Cells("InvoiceTransactionId").Value.ToString(), Me.dgvInventoryCheckingItem.Rows(Me.dgvInventoryCheckingItem.CurrentRow.Index).Cells("MaterialNO").Value.ToString())
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
        node.Text = "物料盘点"

        Me.tvWarehousing.Nodes.Add(node)

        Try
            strSQL = "SELECT InvoiceDefinitionsId, InvoiceDefinitionsName FROM m_InvoiceDefinitions_t WHERE InvoiceDefinitionsType='4'"
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

    Private Sub LoadControlStatus()
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            strSQL = "SELECT PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'InventoryChecking'"
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

    Private Sub GetInventoryChecking(ByVal nodeTag As String, ByVal nodeText As String)
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
                strWhere = strWhere & " AND InventoryCheckMonth = '" & Me.dtpDate.Text.Trim & "' "
            End If

            If Not (String.IsNullOrEmpty(Me.txtTransactionId.Text.Trim)) Then
                strWhere = strWhere & " AND TransactionId='" & Me.txtTransactionId.Text.Trim.Replace("'", "''") & "'"
            End If

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY TransactionId )as RowNum, TransactionId, InventoryCheckMonth, m_InvoiceDefinitions_t.InvoiceDefinitionsName, InventoryCheckingId, WharehouseName, AttentionName, CheckUser, " & _
                     " CheckTime, Remark, CASE StatusFlag WHEN '1' THEN N'已审核' ELSE N'未审核'  END AS StatusFlag, m_InventoryChecking_t.UpdateTime, " & _
                     " m_InventoryChecking_t.UpdateUser, m_InventoryChecking_t.CreateTime, m_InventoryChecking_t.CreateUser " & _
                     " FROM  m_InventoryChecking_t " & _
                     "     INNER JOIN m_InvoiceDefinitions_t ON m_InvoiceDefinitions_t.InvoiceDefinitionsId=m_InventoryChecking_t.InvoiceTransactionType " & _
                     " WHERE 1=1 AND m_InventoryChecking_t.FactoryId='" & VbCommClass.VbCommClass.Factory & "' AND m_InventoryChecking_t.Profitcenter='" & VbCommClass.VbCommClass.profitcenter & "' AND DeleteFlag='0' " & strWhere & " ORDER BY  m_InventoryChecking_t.CreateTime DESC"

            Me.dgvInventoryChecking.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)
            If Not (DReader.HasRows) Then
                Me.dgvInventoryCheckingItem.Rows.Clear()
            End If
            Do While DReader.Read()
                Me.dgvInventoryChecking.Rows.Add(DReader.Item("InventoryCheckingId").ToString, DReader.Item("RowNum").ToString, DReader.Item("InvoiceDefinitionsName").ToString, DReader.Item("TransactionId").ToString, DReader.Item("InventoryCheckMonth").ToString, DReader.Item("WharehouseName").ToString, DReader.Item("AttentionName").ToString, DReader.Item("Remark").ToString, DReader.Item("CreateUser").ToString, DReader.Item("CreateTime").ToString, DReader.Item("UpdateUser").ToString, DReader.Item("UpdateTime").ToString, DReader.Item("StatusFlag").ToString)
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

    Private Sub GetInventoryCheckingItem(ByVal TransactionId As String)
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY InventoryCheckingItemId )as RowNum, InventoryCheckingItemId, TransactionId, MaterialNO, Description, Specification, Uint, BookQuantity, CheckQuantity, " & _
                     " TotalQuantity, CASE WHEN BookQuantity - CheckQuantity > 0  THEN BookQuantity - CheckQuantity ELSE '0'  END AS ProfitQuantity,  CASE  WHEN BookQuantity - CheckQuantity < 0 THEN CheckQuantity - BookQuantity ELSE '0'  END AS LossQuantity, BookPrice, UnitPrice, TotalAmount, CheckStatus, Remark, CreateUser, " & _
                     " CreateTime, UpdateUser, UpdateTime " & _
                     " FROM  m_InventoryCheckingItem_t " & _
                     " WHERE TransactionId = '" & TransactionId & "'"

            Me.dgvInventoryCheckingItem.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)
           
            Do While DReader.Read()
                Me.dgvInventoryCheckingItem.Rows.Add(DReader.Item("RowNum").ToString, DReader.Item("MaterialNO").ToString, DReader.Item("Description").ToString, DReader.Item("Specification").ToString, DReader.Item("BookQuantity").ToString, DReader.Item("CheckQuantity").ToString, DReader.Item("ProfitQuantity").ToString, DReader.Item("LossQuantity").ToString, DReader.Item("UnitPrice").ToString, DReader.Item("TotalAmount").ToString, DReader.Item("Remark").ToString)
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