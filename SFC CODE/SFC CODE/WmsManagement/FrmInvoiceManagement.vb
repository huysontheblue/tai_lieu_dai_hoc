
'--仓储单据管理
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
#End Region

Public Class FrmInvoiceManagement

#Region "变量声明"
    Dim nodeTag As String
    Dim nodeText As String
#End Region

#Region "加载事件"

    Private Sub FrmInvoiceManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '加载菜单
            LoadTree()
            LoadControlStatus()
            Me.dtpDate.Value = Now
            Me.dgvInvoiceTransaction.AutoGenerateColumns = False
            Me.dgvInvoiceTransactionItem.AutoGenerateColumns = False
            Me.dgvBarcode.AutoGenerateColumns = False
            Me.SuperTabControl1.SelectedTabIndex = 0
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvInvoiceTransaction.Rows.Count = 0 OrElse Me.dgvInvoiceTransaction.CurrentRow Is Nothing Then
            Exit Sub
        End If

        If (Not String.IsNullOrEmpty(Me.dgvInvoiceTransaction.Rows(Me.dgvInvoiceTransaction.CurrentRow.Index).Cells("CheckUser").Value.ToString)) Then
            GetMesData.SetMessage(Me.lblMessage, "单据已经审核", False)
            Exit Sub
        End If
        Dim strTransactionId As String
        strTransactionId = Me.dgvInvoiceTransaction.Rows(Me.dgvInvoiceTransaction.CurrentRow.Index).Cells("TransactionID").Value.ToString

        If (String.IsNullOrEmpty(strTransactionId)) Then
            GetMesData.SetMessage(Me.lblMessage, "获取单据ID错误", False)
            Exit Sub
        End If

        If (Not CheckStatus()) Then
            Exit Sub
        End If

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
           
            strSQL.AppendLine(" UPDATE m_InvoiceTransaction_t SET StatusFlag='1', CheckUser='" & VbCommClass.VbCommClass.UseId.ToUpper & "', CheckTime=GetDate() WHERE TransactionID='" & strTransactionId & "'")
            strSQL.AppendLine(" UPDATE W_MATERIALS SET W_MATERIALS.QUANTITY = W_MATERIALS.QUANTITY + ISNULL(m_InvoiceTransactionItem_t.Quantity,0) FROM W_MATERIALS, m_InvoiceTransactionItem_t WHERE W_MATERIALS.MATERIAL_ID=m_InvoiceTransactionItem_t.MaterialNO AND m_InvoiceTransactionItem_t.InvoiceTransactionId='" & strTransactionId & "' ")
            strSQL.AppendLine(" IF EXISTS(SELECT TransactionType FROM m_InvoiceTransaction_t WHERE TransactionID='" & strTransactionId & "' AND TransactionType='1') BEGIN ")
            strSQL.AppendLine(" UPDATE W_REELS_T SET STATUS='1' WHERE RECEIVENO='" & strTransactionId & "'  END")

            If (Not String.IsNullOrEmpty(strSQL.ToString)) Then
                Conn.ExecSql(strSQL.ToString())
            End If
            Conn.PubConnection.Close()
            GetMesData.SetMessage(Me.lblMessage, "单据审核成功", True)
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "审核异常", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If (String.IsNullOrEmpty(nodeTag)) Then
            GetMesData.SetMessage(Me.lblMessage, "请选择查询单据!", False)
        End If
        GetTransaction(nodeTag, nodeText)
    End Sub

    Private Sub tvInvoice_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvInvoice.NodeMouseClick
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
            Me.dgvBarcode.DataSource = GetMesData.GetScanBarcode(Me.dgvInvoiceTransaction.Rows(Me.dgvInvoiceTransaction.CurrentRow.Index).Cells("InvoiceTransactionId").Value.ToString(), Me.dgvInvoiceTransactionItem.Rows(Me.dgvInvoiceTransactionItem.CurrentRow.Index).Cells("MaterialNO").Value.ToString())
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常!", False)
        End Try
    End Sub
#End Region

#Region "函数"

    Private Sub LoadControlStatus()
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            strSQL = "SELECT PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'OutStorageCheck'"
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

    Private Sub LoadTree()
        Dim strSQL As String
        Dim dtTemp As DataTable
        Dim dtChildTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try

            strSQL = "SELECT PARAMETER_NAME, PARAMETER_VALUE FROM m_SettingParameter_t WHERE PARAMETER_MODE='OutStorageDirection' AND PARAMETER_VALUE IN ('1', '2') ORDER BY ORDERID ASC"

            dtTemp = Conn.GetDataTable(strSQL)

            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                Dim node As TreeNode
                For I As Int16 = 0 To dtTemp.Rows.Count - 1
                    node = New TreeNode
                    node.Tag = ""
                    node.Text = dtTemp.Rows(I).Item("PARAMETER_NAME").ToString

                    Me.tvInvoice.Nodes.Add(node)

                    strSQL = "SELECT InvoiceDefinitionsId, InvoiceDefinitionsName FROM m_InvoiceDefinitions_t WHERE InvoiceDefinitionsType='" & dtTemp.Rows(I).Item("PARAMETER_VALUE").ToString & "'"
                    dtChildTemp = Conn.GetDataTable(strSQL)
                    Conn.PubConnection.Close()

                    If (Not dtChildTemp Is Nothing) Then
                        For j As Int16 = 0 To dtChildTemp.Rows.Count - 1
                            Dim nodeChild As TreeNode = New TreeNode
                            nodeChild.Tag = dtChildTemp.Rows(j).Item("InvoiceDefinitionsId").ToString
                            nodeChild.Text = dtChildTemp.Rows(j).Item("InvoiceDefinitionsName").ToString
                            node.Nodes.Add(nodeChild)
                        Next
                    End If
                Next

                Me.tvInvoice.ExpandAll()
            End If

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
                strWhere = strWhere & " AND CONVERT(VARCHAR(10), m_InvoiceTransaction_t.CreateTime, 23) = '" & Me.dtpDate.Text.ToString.Trim & "' "
            End If

            If Not (String.IsNullOrEmpty(Me.txtTransactionId.Text.Trim)) Then
                strWhere = strWhere & " AND TransactionId='" & Me.txtTransactionId.Text.Trim.Replace("'", "''") & "'"
            End If

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY TransactionId )as RowNum, InvoiceTransactionId, m_InvoiceDefinitions_t.InvoiceDefinitionsName, TransactionId, WarehouseId, WarehouseName, DeptId, DeptName, " & _
                     " SupplierId, SupplierName, TotalAmount, DeliveryId, DeliveryName, AttentionName, TotalNumber, TotalConversionUnits, OrderNumber, CheckUser, CheckTime, Remark, m_InvoiceTransaction_t.UpdateTime, " & _
                     " m_InvoiceTransaction_t.UpdateUser, m_InvoiceTransaction_t.CreateTime, m_InvoiceTransaction_t.CreateUser, CASE m_InvoiceTransaction_t.StatusFlag WHEN '1' THEN N'已审核' ELSE N'未审核'  END AS StatusFlag " & _
                     " FROM  m_InvoiceTransaction_t " & _
                     "     INNER JOIN m_InvoiceDefinitions_t ON m_InvoiceDefinitions_t.InvoiceDefinitionsId=m_InvoiceTransaction_t.InvoiceTransactionType " & _
                     " WHERE 1=1 AND m_InvoiceTransaction_t.FactoryId='" & VbCommClass.VbCommClass.Factory & "' AND m_InvoiceTransaction_t.Profitcenter='" & VbCommClass.VbCommClass.profitcenter & "' AND DeleteFlag='0' " & strWhere & " ORDER BY  m_InvoiceTransaction_t.CreateTime DESC"

            Me.dgvInvoiceTransaction.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)

            Do While DReader.Read()
                Me.dgvInvoiceTransaction.Rows.Add(DReader.Item("InvoiceTransactionId").ToString, DReader.Item("RowNum").ToString, DReader.Item("InvoiceDefinitionsName").ToString, DReader.Item("TransactionId").ToString, DReader.Item("CreateTime").ToString, DReader.Item("WarehouseName").ToString, DReader.Item("DeptName").ToString, DReader.Item("SupplierName").ToString, DReader.Item("TotalAmount").ToString, DReader.Item("DeliveryName").ToString, DReader.Item("AttentionName").ToString, "", DReader.Item("TotalNumber").ToString, _
                                                  DReader.Item("TotalConversionUnits").ToString, DReader.Item("Remark").ToString, DReader.Item("CheckUser").ToString, DReader.Item("CheckTime").ToString, DReader.Item("CreateUser").ToString, DReader.Item("CreateTime").ToString, DReader.Item("UpdateUser").ToString, DReader.Item("UpdateTime").ToString, DReader.Item("StatusFlag").ToString)
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

    Private Sub GetTransactionItem(ByVal TransactionId As String)
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try

            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY InvoiceTransactionId )as RowNum, InvoiceTransactionItemId, InvoiceTransactionId, MaterialNO, Description, Specification, Uint, Quantity, UnitPrice, " & _
                     " TotalAmount, OrderNumber, Remark, CreateUser, CreateTime, UpdateUser, UpdateTime " & _
                     " FROM  m_InvoiceTransactionItem_t " & _
                     " WHERE InvoiceTransactionId = '" & TransactionId & "'"

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

    Private Function CheckStatus() As Boolean
        Dim strSQL As String
        Dim rtValue As Boolean = False
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            strSQL = "SELECT StatusFlag FROM m_InvoiceTransaction_t WHERE TransactionID='" & Me.dgvInvoiceTransaction.Rows(Me.dgvInvoiceTransaction.CurrentRow.Index).Cells("TransactionID").Value.ToString & "' AND StatusFlag='1'"
            DReader = Conn.GetDataReader(strSQL)

            If (DReader.HasRows) Then
                rtValue = True
            Else
                GetMesData.SetMessage(Me.lblMessage, "单据已经审核", False)
                rtValue = False
            End If
            DReader.Close()
            Conn.PubConnection.Close()
            Return rtValue
        Catch ex As Exception
            If (Not DReader Is Nothing And Not DReader.IsClosed) Then
                DReader.Close()
            End If

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "检查数据异常", False)
            Return False
        End Try
    End Function

#End Region

End Class