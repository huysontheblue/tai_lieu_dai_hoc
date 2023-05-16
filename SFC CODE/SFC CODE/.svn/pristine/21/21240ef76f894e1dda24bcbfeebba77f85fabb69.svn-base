
'--仓储调拨单新增
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

Public Class FrmStoreRequisitionMaster

#Region "变量声明"
    Dim _strInvoiceTransactionTypeName As String
    Dim _strSavaType As String
    Shared _strTransactionId As String
    Shared _MaterialList As DataTable
    Shared _StatusFlag As String
    Shared _ScanTransactionId As String     '新增临时扫描物料条码

    Public Shared Property MaterialList() As DataTable
        Get
            If (_MaterialList Is Nothing) Then
                _MaterialList = New DataTable()
                Dim dc As DataColumn
                dc = _MaterialList.Columns.Add("Id", Type.GetType("System.Int32"))
                dc.AutoIncrement = True
                dc.AutoIncrementSeed = 1
                dc.AutoIncrementStep = 1
                dc.AllowDBNull = False
                _MaterialList.Columns.Add("ItemId", Type.GetType("System.String"))
                _MaterialList.Columns.Add("TransactionType", Type.GetType("System.String"))
                _MaterialList.Columns.Add("MATERIALNO", Type.GetType("System.String"))
                _MaterialList.Columns.Add("DESCRIPTION", Type.GetType("System.String"))
                _MaterialList.Columns.Add("SPECIFICATION", Type.GetType("System.String"))
                _MaterialList.Columns.Add("UOM_NAME", Type.GetType("System.String"))
                _MaterialList.Columns.Add("STOCKQUANTITY", Type.GetType("System.String"))
                _MaterialList.Columns.Add("UNITPRICE", Type.GetType("System.String"))
                _MaterialList.Columns.Add("QUANTITY", Type.GetType("System.String"))
                _MaterialList.Columns.Add("WAREHOUSEID", Type.GetType("System.String"))
                _MaterialList.Columns.Add("WAREHOUSELOCATIONID", Type.GetType("System.String"))
                _MaterialList.Columns.Add("TotalAmount", Type.GetType("System.String"))
                _MaterialList.Columns.Add("REMARK", Type.GetType("System.String"))
            End If
            Return _MaterialList
        End Get

        Set(ByVal Value As DataTable)
            _MaterialList = Value
        End Set
    End Property

    Public Shared Property TransactionId() As String
        Get
            Return _strTransactionId
        End Get

        Set(value As String)
            _strTransactionId = value
        End Set
    End Property

    Public Shared Property StatusFlag() As String
        Get
            Return _StatusFlag
        End Get

        Set(value As String)
            _StatusFlag = value
        End Set
    End Property

    Public Shared Property ScanTransactionId() As String
        Get
            Return _ScanTransactionId
        End Get

        Set(value As String)
            _ScanTransactionId = value
        End Set
    End Property
#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal strInvoiceTransactionTypeName As String, ByVal _TransactionId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _strInvoiceTransactionTypeName = strInvoiceTransactionTypeName
        TransactionId = _TransactionId
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmStoreRequisitionMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvStoreRequisitionItem.AutoGenerateColumns = False
            ScanTransactionId = String.Empty
            '基础数据加载
            LoadControlData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub btnSelectmaterial_Click(sender As Object, e As EventArgs) Handles btnSelectmaterial.Click
        Try
            Dim frmMaterial As New FrmMaterialQuery(MaterialList, "")
            frmMaterial.ShowDialog()
            If (MaterialList.Rows.Count > 0) Then
                Me.dgvStoreRequisitionItem.DataSource = MaterialList
            End If
            InitDataGrid_afterBindData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnInsertRow_Click(sender As Object, e As EventArgs) Handles btnInsertRow.Click

    End Sub

    Private Sub btnDeleteRow_Click(sender As Object, e As EventArgs) Handles btnDeleteRow.Click

        If (StatusFlag = "1") Then
            GetMesData.SetMessage(Me.lblMessage, "已审核数据不允许编辑", False)
            Exit Sub
        End If

        If Me.dgvStoreRequisitionItem.Rows.Count = 0 OrElse Me.dgvStoreRequisitionItem.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要删除行", False)
            Exit Sub
        End If
        Try
            Dim strMaterialNO As String
            Dim strTransactionType As String
            strMaterialNO = Me.dgvStoreRequisitionItem.Rows(Me.dgvStoreRequisitionItem.CurrentRow.Index).Cells("MATERIALNO").Value.ToString
            strTransactionType = Me.dgvStoreRequisitionItem.Rows(Me.dgvStoreRequisitionItem.CurrentRow.Index).Cells("TransactionType").Value.ToString

            If (String.IsNullOrEmpty(TransactionId)) Then
                If (String.IsNullOrEmpty(strMaterialNO)) Then
                    GetMesData.SetMessage(Me.lblMessage, "获取删除行料号失败", False)
                    Exit Sub
                End If

                For I As Integer = 0 To _MaterialList.Rows.Count - 1
                    If (_MaterialList.Rows(I).Item("MATERIALNO").ToString = strMaterialNO) Then
                        If (strTransactionType = "1") Then

                            Dim strSQL As New StringBuilder
                            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
                            Try
                                strSQL.AppendLine("UPDATE m_ScanBacodeTransaction_t SET DeleteFlag='1' WHERE ScanBarcodeTransactionId = '" & ScanTransactionId & "' AND MaterialNO='" & strMaterialNO & "' ")
                                Conn.ExecSql(strSQL.ToString)
                                Conn.PubConnection.Close()
                            Catch ex As Exception
                                GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
                                If (Conn.PubConnection.State = ConnectionState.Open) Then
                                    Conn.PubConnection.Close()
                                End If
                                Exit Sub
                            End Try
                        End If

                        _MaterialList.Rows.RemoveAt(I)
                        _MaterialList.AcceptChanges()
                        Exit For
                    End If
                Next

                Me.dgvStoreRequisitionItem.Update()
            Else
                If (Not CheckDelete()) Then
                    Exit Sub
                End If

                Dim strSQL As New StringBuilder
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
                Try
                    'strSQL.AppendLine("DECLARE @QUANTITY FLOAT ")
                    'strSQL.AppendLine("SELECT @QUANTITY=ISNULL(Quantity,0) FROM m_InvoiceTransactionItem_t WHERE InvoiceTransactionId = '" & TransactionId & "' AND MATERIAL_NO='" & strMaterialNO & "' ")
                    'strSQL.AppendLine("UPDATE W_MATERIALS SET QUANTITY= QUANTITY - @QUANTITY WHERE MATERIAL_NO='" & strMaterialNO & "' ")
                    'strSQL.AppendLine("IF EXISTS(SELECT InvoiceTransactionId FROM m_InvoiceTransactionItem_t WHERE InvoiceTransactionId = '" & TransactionId & "' AND MATERIAL_NO='" & strMaterialNO & "' AND TransactionType='0' ")
                    'strSQL.AppendLine("BEGIN UPDATE m_InvoiceTransactionItem_t SET DeleteFlag='1' WHERE InvoiceTransactionId = '" & TransactionId & "' AND MATERIAL_NO='" & strMaterialNO & "' END ELSE BEGIN ")
                    strSQL.AppendLine("UPDATE m_StoreRequisitionItem_t SET DeleteFlag='1' WHERE TransactionId = '" & TransactionId & "' AND MATERIAL_NO='" & strMaterialNO & "' ")
                    'strSQL.AppendLine("UPDATE W_REELS_T SET DeleteFlag='1' WHERE InvoiceTransactionId = '" & TransactionId & "' AND MATERIAL_NO='" & strMaterialNO & "' END")
                    '更改m_StoreRequisitionBarcode_t
                    If (strTransactionType = "1") Then
                        strSQL.AppendLine("UPDATE m_ScanBacodeTransaction_t SET DeleteFlag='1' WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND MATERIAL_NO='" & strMaterialNO & "' ")
                    End If
                    Conn.ExecSql(strSQL.ToString)
                    Conn.PubConnection.Close()

                    Me.dgvStoreRequisitionItem.DataSource = GetMesData.GetInvoiceTransactionItem(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)
                Catch ex As Exception
                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If
                    GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
                End Try
            End If
            InitDataGrid_afterBindData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub btnBarcodeInput_Click(sender As Object, e As EventArgs) Handles btnBarcodeInput.Click

        Try
            Dim strScanType As String = ""
            Dim strTransactionId As String

            If (String.IsNullOrEmpty(TransactionId)) Then
                ScanTransactionId = GetMesData.GetScanBarcodeId()
                strTransactionId = ScanTransactionId
                strScanType = "0"
            Else
                strTransactionId = TransactionId
                strScanType = "1"
            End If
            Dim strMaterialNo As String = ""
            If Not Me.dgvStoreRequisitionItem.CurrentRow Is Nothing Then
                strMaterialNo = Me.dgvStoreRequisitionItem.Rows(Me.dgvStoreRequisitionItem.CurrentRow.Index).Cells("MATERIALNO").Value
            End If

            If (Me.chkStoreRequisitionType.Checked) Then
                Dim frmBarcode As New FrmFinishedProductBarCode(strTransactionId, StatusFlag, strScanType, "2", strMaterialNo, MaterialList, "成品出库条码扫描")
                frmBarcode.ShowDialog()
            Else
                Dim frmBarcode As New FrmWarehouseingBarCode(strTransactionId, StatusFlag, strScanType, "3", strMaterialNo, MaterialList, "物料调拨条码扫描")
                frmBarcode.ShowDialog()
            End If

            'Dim frmBarcode As New FrmWarehouseingBarCode(TransactionId, StatusFlag, BarCodeList, MaterialList)
            'frmBarcode.ShowDialog()

            If (MaterialList.Rows.Count > 0) Then
                Me.dgvStoreRequisitionItem.DataSource = MaterialList
            End If
            InitDataGrid_afterBindData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnStick_Click(sender As Object, e As EventArgs) Handles btnStick.Click
        Try
            Dim frmBulkPasteMaterial As New FrmBulkPasteMaterialQuery(MaterialList)
            frmBulkPasteMaterial.ShowDialog()
            If (MaterialList.Rows.Count > 0) Then
                Me.dgvStoreRequisitionItem.DataSource = MaterialList
            End If
            InitDataGrid_afterBindData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If (StatusFlag = "1") Then
            GetMesData.SetMessage(Me.lblMessage, "已审核数据不允许编辑", False)
            Exit Sub
        End If

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

                strSQL.AppendLine(" DECLARE @TransactionID VARCHAR(32),@InvoicePrefix VARCHAR(16), @RuleDateTime VARCHAR(16), @RuleCode VARCHAR(16) ")
                strSQL.AppendLine(" DECLARE @DateCode VARCHAR(16), @CurrentCount VARCHAR(16), @CodeFormatDefinitions VARCHAR(64), @StatusFlag VARCHAR(1) ")
                strSQL.AppendLine(" DECLARE @UserID VARCHAR(32) ")
                strSQL.AppendLine(" SET @UserID='" & VbCommClass.VbCommClass.UseId & "' ")
                strSQL.AppendLine(" SELECT @InvoicePrefix = InvoicePrefix FROM m_InvoiceDefinitions_t WHERE InvoiceDefinitionsID='" & Me.cboInvoiceTransactionType.SelectedValue.ToString.Trim & "' ")
                strSQL.AppendLine(" SELECT @RuleDateTime = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'RuleDateTime' ")
                strSQL.AppendLine(" SELECT @RuleCode = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'RuleCode' ")
                strSQL.AppendLine(" SELECT @StatusFlag = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'AllocationCheck' ")
                strSQL.AppendLine(" SET @DateCode = FORMAT(GETDATE(), @RuleDateTime) ")
                strSQL.AppendLine(" SELECT @CurrentCount = ISNULL(CurrentCount, 0) FROM m_InvoiceDefinitionsCode_t WHERE DateCode = @DateCode AND InvoicePrefix = @InvoicePrefix ")
                strSQL.AppendLine(" IF (ISNULL(@CurrentCount, 0) = 0) BEGIN ")
                strSQL.AppendLine(" SET @CurrentCount = 1 ")
                strSQL.AppendLine(" SET @CodeFormatDefinitions = @InvoicePrefix + @RuleDateTime + @RuleCode ")
                strSQL.AppendLine(" INSERT INTO m_InvoiceDefinitionsCode_t(InvoicePrefix, CurrentCount, DateCode, CodeFormatDefinitions, CreateUser, CreateTime) VALUES(@InvoicePrefix, @CurrentCount, @DateCode, @CodeFormatDefinitions, @UserID, GETDATE()) End ")
                strSQL.AppendLine(" ELSE BEGIN ")
                strSQL.AppendLine(" UPDATE m_InvoiceDefinitionsCode_t SET CurrentCount = CurrentCount + 1  WHERE DateCode = @DateCode AND InvoicePrefix = @InvoicePrefix ")
                strSQL.AppendLine(" SET @CurrentCount = @CurrentCount + 1 End ")
                strSQL.AppendLine(" SET @TransactionID = @InvoicePrefix + @DateCode + RIGHT(@RuleCode + ltrim(@CurrentCount), LEN(@RuleCode))  ")
                strSQL.AppendLine(" IF(ISNULL(@StatusFlag, 'N')='N') BEGIN SET @StatusFlag = '1' End ")
                strSQL.AppendLine(" ELSE BEGIN SET @StatusFlag = '0' End ")

                '单头
                strSQL.AppendLine(" INSERT INTO m_StoreRequisition_t(FactoryId, Profitcenter, InvoiceTransactionType, TransactionId, CallInWarehouseId, CallInWarehouseName, ")
                strSQL.AppendLine("  CallOutWarehouseId, CallOutWarehouseName, AttentionName, Remark, StatusFlag, DeleteFlag, CreateTime, CreateUser) ")
                strSQL.AppendLine(" VALUES( '" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','" & Me.cboInvoiceTransactionType.SelectedValue & "', @TransactionID,'" & Me.cboCallInWarehouse.SelectedValue & "', N'" & Me.cboCallInWarehouse.Text.Trim & "', ")
                strSQL.AppendLine(" '" & Me.cboCallOutWarehouse.SelectedValue.Trim & "', N'" & Me.cboCallOutWarehouse.Text.Trim & "', N'" & Me.mtxtAttentionName.Text.Trim & "', N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "', @StatusFlag, 0, GETDATE(), @UserID ) ")

                '单身
                Dim strMaterialNO As String
                Dim strDescription As String
                Dim strSpecification As String
                Dim strUint As String
                Dim strQuantity As String
                Dim strUnitPrice As String
                Dim strTotalAmount As String
                Dim strRemark As String
                Dim strTransactionType As String
                Dim strWarehouseLocationId As String
                Dim ScanBarcode As Boolean = False

                For I As Int16 = 0 To Me.dgvStoreRequisitionItem.Rows.Count - 1
                    strMaterialNO = IIf(IsDBNull(Me.dgvStoreRequisitionItem.Rows(I).Cells("MATERIALNO").Value), "", Me.dgvStoreRequisitionItem.Rows(I).Cells("MATERIALNO").Value.ToString())
                    strDescription = IIf(IsDBNull(Me.dgvStoreRequisitionItem.Rows(I).Cells("DESCRIPTION").Value), "", Me.dgvStoreRequisitionItem.Rows(I).Cells("DESCRIPTION").Value.ToString())
                    strSpecification = IIf(IsDBNull(Me.dgvStoreRequisitionItem.Rows(I).Cells("SPECIFICATION").Value), "", Me.dgvStoreRequisitionItem.Rows(I).Cells("SPECIFICATION").Value.ToString())
                    strUint = IIf(IsDBNull(Me.dgvStoreRequisitionItem.Rows(I).Cells("Uint").Value), "", Me.dgvStoreRequisitionItem.Rows(I).Cells("Uint").Value.ToString())
                    strQuantity = IIf(IsDBNull(Me.dgvStoreRequisitionItem.Rows(I).Cells("QUANTITY").Value), "", Me.dgvStoreRequisitionItem.Rows(I).Cells("QUANTITY").Value.ToString())
                    strUnitPrice = IIf(IsDBNull(Me.dgvStoreRequisitionItem.Rows(I).Cells("UNITPRICE").Value), "", Me.dgvStoreRequisitionItem.Rows(I).Cells("UNITPRICE").Value.ToString())
                    strTotalAmount = IIf(IsDBNull(Me.dgvStoreRequisitionItem.Rows(I).Cells("TotalAmount").Value), "", Me.dgvStoreRequisitionItem.Rows(I).Cells("TotalAmount").Value.ToString())
                    strRemark = IIf(IsDBNull(Me.dgvStoreRequisitionItem.Rows(I).Cells("REMARK").Value), "", Me.dgvStoreRequisitionItem.Rows(I).Cells("REMARK").Value.ToString())
                    strTransactionType = IIf(IsDBNull(Me.dgvStoreRequisitionItem.Rows(I).Cells("TransactionType").Value), "", Me.dgvStoreRequisitionItem.Rows(I).Cells("TransactionType").Value.ToString())
                    strWarehouseLocationId = IIf(IsDBNull(Me.dgvStoreRequisitionItem.Rows(I).Cells("mtxtWarehouseLocationId").Value), "", Me.dgvStoreRequisitionItem.Rows(I).Cells("mtxtWarehouseLocationId").Value.ToString())

                    If (strTransactionType = "1") Then
                        ScanBarcode = True
                    End If

                    strSQL.AppendLine(" INSERT INTO m_StoreRequisitionItem_t(TransactionId, MaterialNO, Description, Specification, WarehouseId, WarehouseLocationId, Uint, UnitPrice, Quantity, ")
                    strSQL.AppendLine(" TransactionType, Remark, CheckStatus, DeleteFlag, CreateUser, CreateTime) ")
                    strSQL.AppendLine(" VALUES( @TransactionID, '" & strMaterialNO & "', N'" & strDescription.Replace("'", "''") & "', N'" & strSpecification.Replace("'", "''") & "',NULL, '" & strWarehouseLocationId & "', N'" & strUint & "', '" & strUnitPrice & "', '" & strQuantity & "', ")
                    strSQL.AppendLine("  '" & strTransactionType & "', N'" & strRemark & "', @StatusFlag, '0', @UserID, GETDATE()) ")

                    'strSQL.AppendLine(" IF(ISNULL(@StatusFlag,'1')='1') BEGIN  ")
                    'strSQL.AppendLine(" UPDATE W_MATERIALS SET QUANTITY = QUANTITY + " & strQuantity & " WHERE MATERIAL_NO='" & strMaterialNO & "' End ")
                Next

                If (ScanBarcode) Then
                    ''" & VbCommClass.VbCommClass.Factory & "', '" & VbCommClass.VbCommClass.profitcenter & "''" & strBarCode & "', '" & strMaterialNO & "', '" & strMaterialNO & "', '" & strSpecification & "', '" & strDescription & "''" & strUint & "', '" & strUint & "', '" & strVendorId & "', '" & strVendorId & "''" & strQuantity & "', '" & strQuantity & "''" & strDateCode & "', '" & strVersion & "'

                    strSQL.AppendLine(" INSERT INTO m_StoreRequisitionBarcode_t(TransactionId, BarCode, MaterialNO, Description, Specification, Uint, Quantity, WarehouseId, WarehouseLocationId, HistoryWarehouseId, HistoryWarehouseLocationId, Remark, DeleteFlag, CreateUser, CreateTime) ")
                    'strSQL.AppendLine(" )VALUES( ")
                    strSQL.AppendLine(" SELECT @TransactionID, BarCode, m_ScanBacodeTransaction_t.MaterialNO, m_ScanBacodeTransaction_t.Specification, m_ScanBacodeTransaction_t.Description, m_ScanBacodeTransaction_t.Uint, m_ScanBacodeTransaction_t.Quantity, m_WarehouseLocation_t.WarehouseId, m_StoreRequisitionItem_t.WarehouseLocationId, HistoryWarehouseId, HistoryWarehouseLocationId, NULL, 0, @UserID, GETDATE()  FROM m_ScanBacodeTransaction_t ")
                    strSQL.AppendLine(" INNER JOIN m_StoreRequisitionItem_t ON m_StoreRequisitionItem_t.MaterialNO=m_ScanBacodeTransaction_t.MaterialNO ")
                    strSQL.AppendLine(" INNER JOIN m_WarehouseLocation_t ON m_WarehouseLocation_t.WarehouseLocationCode=m_StoreRequisitionItem_t.WarehouseLocationId ")
                    strSQL.AppendLine(" WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_StoreRequisitionItem_t.TransactionId=@TransactionID ")
                    strSQL.AppendLine(" UPDATE W_REELS_T SET WAREHOUSE = m_StoreRequisitionBarcode_t.WarehouseId, LOCATION = m_StoreRequisitionBarcode_t.WarehouseLocationId FROM m_StoreRequisitionBarcode_t WHERE m_StoreRequisitionBarcode_t.BarCode=W_REELS_T.REEL_BARCODE AND m_StoreRequisitionBarcode_t.TransactionId=@TransactionID ")
                    strSQL.AppendLine(" UPDATE m_ScanBacodeTransaction_t SET StatusFlag='1', TransactionId = @TransactionId WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND DeleteFlag='0' AND StatusFlag='0'")
                End If
            Else
                '编辑
                strSQL.AppendLine(" UPDATE m_StoreRequisition_t SET ")
                strSQL.AppendLine(" InvoiceTransactionType ='" & Me.cboInvoiceTransactionType.SelectedValue & "', CallOutWarehouseId='" & Me.cboCallOutWarehouse.SelectedValue & "', CallOutWarehouseName=N'" & Me.cboCallOutWarehouse.SelectedText.Trim & "', CallInWarehouseId='" & Me.cboCallInWarehouse.SelectedValue & "', CallInWarehouseName=N'" & Me.cboCallInWarehouse.SelectedText.Trim & "', Remark=N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "',UpdateUser='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=Getdate() ")
                strSQL.AppendLine(" WHERE TransactionId='" & TransactionId & "' ")
            End If

            If (Not String.IsNullOrEmpty(strSQL.ToString)) Then
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

    Private Sub mtxtAttentionName_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtAttentionName.ButtonCustomClick
        Try
            Dim frmuser As New FrmUserQuery(Me.mtxtAttentionName)
            frmuser.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub mtxtWarehouseLocationId_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtWarehouseLocationId.ButtonCustomClick
        'Handles mtxtWarehouseLocationId.ButtonCustomClick
        Try
            Dim strWarehouseId As String
            strWarehouseId = Me.cboCallOutWarehouse.Text.Trim
            If (String.IsNullOrEmpty(strWarehouseId)) Then
                GetMesData.SetMessage(Me.lblMessage, "请选择仓库", False)
                Exit Sub
            End If

            Dim cell As DataGridViewMaskedTextBoxAdvCell = TryCast(Me.dgvStoreRequisitionItem.CurrentCell, DataGridViewMaskedTextBoxAdvCell)

            If cell IsNot Nothing Then
                Dim ec As DataGridViewMaskedTextBoxAdvEditingControl = TryCast(cell.DataGridView.EditingControl, DataGridViewMaskedTextBoxAdvEditingControl)

                If ec IsNot Nothing Then
                    Dim frmWarehouseLocationQuery As New FrmWarehouseLocationQuery(strWarehouseId, ec)
                    frmWarehouseLocationQuery.ShowDialog()
                End If
            End If

            'Dim frmWarehouseLocationQuery As New FrmWarehouseLocationQuery(strWarehouseId, Me.mtxtWarehouseLocationId)
            'frmWarehouseLocationQuery.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadControlData()
        Dim strSQL As String
        Dim dtTemp As DataTable
        Dim dtWharehouse As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            Me.dtpInvoiceDate.Value = Now
            'InvoiceDefinitionsType
            strSQL = "SELECT InvoiceDefinitionsId, InvoiceDefinitionsName FROM m_InvoiceDefinitions_t WHERE InvoiceDefinitionsType='5'"
            dtTemp = Conn.GetDataTable(strSQL)

            Me.cboInvoiceTransactionType.DisplayMember = "InvoiceDefinitionsName"
            Me.cboInvoiceTransactionType.ValueMember = "InvoiceDefinitionsId"
            Me.cboInvoiceTransactionType.DataSource = dtTemp

            Conn.PubConnection.Close()
            dtWharehouse = GetMesData.GetWarehouse(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "")
            Me.cboCallInWarehouse.DisplayMember = "WarehouseName"
            Me.cboCallInWarehouse.ValueMember = "WarehouseCode"
            Me.cboCallInWarehouse.DataSource = dtWharehouse

            Me.cboCallOutWarehouse.DisplayMember = "WarehouseName"
            Me.cboCallOutWarehouse.ValueMember = "WarehouseCode"
            Me.cboCallOutWarehouse.DataSource = dtWharehouse.Copy()

            If (String.IsNullOrEmpty(_strTransactionId)) Then
                If Not (String.IsNullOrEmpty(_strInvoiceTransactionTypeName)) Then
                    Me.cboInvoiceTransactionType.SelectedIndex = Me.cboInvoiceTransactionType.FindString(_strInvoiceTransactionTypeName)
                Else
                    Me.cboInvoiceTransactionType.SelectedIndex = 0
                End If

                Me.dgvStoreRequisitionItem.Rows.Add(7)

                Me.cboCallInWarehouse.SelectedIndex = -1
                Me.cboCallOutWarehouse.SelectedIndex = -1
                Me.dtpInvoiceDate.Value = Now
                Me.txtTransactionId.Text = "<自动编号>"
            Else
                Dim dtInvoice As DataTable
                dtInvoice = GetMesData.GetInvoiceTransaction(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)

                If (Not dtInvoice Is Nothing And dtInvoice.Rows.Count > 0) Then
                    Me.dtpInvoiceDate.Text = dtInvoice.Rows(0).Item("CreateTime").ToString
                    Me.txtTransactionId.Text = dtInvoice.Rows(0).Item("TransactionId").ToString
                    Me.cboInvoiceTransactionType.SelectedIndex = cboInvoiceTransactionType.FindString(dtInvoice.Rows(0).Item("InvoiceDefinitionsName").ToString)
                    'txtERPTranscationID.Text = dtInvoice.Rows(0).Item("OrderNumber").ToString
                    Me.cboCallInWarehouse.SelectedIndex = cboCallInWarehouse.FindString(dtInvoice.Rows(0).Item("WarehouseName").ToString)
                    Me.mtxtAttentionName.Text = dtInvoice.Rows(0).Item("AttentionName").ToString
                    Me.txtRemark.Text = dtInvoice.Rows(0).Item("Remark").ToString
                    StatusFlag = dtInvoice.Rows(0).Item("StatusFlag").ToString

                    'If (dtInvoice.Rows(0).Item("TransactionType").ToString = "1") Then
                    '    BarCodeList = GetMesData.GetTransactionBarCode(TransactionId, "")
                    'End If
                End If

                Dim dtInvoiceItem As DataTable
                dtInvoiceItem = GetMesData.GetInvoiceTransactionItem(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)
                Me.dgvStoreRequisitionItem.DataSource = dtInvoiceItem

            End If
            InitDataGrid_afterBindData()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Function CheckDelete() As Boolean
        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DrRead As SqlClient.SqlDataReader
        Try
            strSQL.AppendLine("DECLARE @OutStorageCheck VARCHAR(1), @OutCheckValue VARCHAR(1) ")
            strSQL.AppendLine("SELECT @OutStorageCheck= ISNULL(PARAMETER_VALUES,'N') FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'OutStorageCheck' ")
            strSQL.AppendLine("IF (ISNULL(@OutStorageCheck,'N')='N') BEGIN ")
            strSQL.AppendLine("SET @OutCheckValue='N' END ELSE BEGIN ")
            strSQL.AppendLine("IF EXISTS(SELECT InvoiceTransactionId FROM m_InvoiceTransaction_t WHERE InvoiceTransactionId='" & TransactionId & "' StatusFlag='1' ) BEGIN SET @OutCheckValue='Y' END ELSE BEGIN ")
            strSQL.AppendLine("SET @OutCheckValue='N' END SELECT @OutCheckValue ")

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
            If (String.IsNullOrEmpty(cboInvoiceTransactionType.SelectedValue)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择单据类型", False)
                Exit Function
            End If

            If (String.IsNullOrEmpty(Me.cboCallOutWarehouse.SelectedValue)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择调出仓库", False)
                Exit Function
            End If

            If (String.IsNullOrEmpty(cboCallInWarehouse.SelectedValue)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择调入仓库", False)
                Exit Function
            End If

            If (String.IsNullOrEmpty(mtxtAttentionName.Text.Trim())) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择经办人", False)
                Exit Function
            End If

            If (Me.dgvStoreRequisitionItem.Rows.Count <= 0) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
            Else
                Dim Qty As String
                Dim strWarehouseLocationId As String
                Dim CheckFor As Boolean = True
                If (IsDBNull(Me.dgvStoreRequisitionItem.Rows(0).Cells("MaterialNO").Value) Or Me.dgvStoreRequisitionItem.Rows(0).Cells("MaterialNO").Value Is Nothing) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
                Else
                    For i As Int16 = 0 To Me.dgvStoreRequisitionItem.Rows.Count - 1
                        Qty = IIf(IsDBNull(Me.dgvStoreRequisitionItem.Rows(i).Cells("QUANTITY").Value), "", Me.dgvStoreRequisitionItem.Rows(i).Cells("QUANTITY").Value.ToString)
                        strWarehouseLocationId = IIf(IsDBNull(Me.dgvStoreRequisitionItem.Rows(i).Cells("mtxtWarehouseLocationId").Value), "", Me.dgvStoreRequisitionItem.Rows(i).Cells("mtxtWarehouseLocationId").Value)
                        If Not IsNumeric(Qty) Then
                            rtValue = False
                            CheckFor = False
                            GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入数量格式错误", False)
                            Exit For
                        End If
                        If (CDbl(Qty) <= 0) Then
                            rtValue = False
                            CheckFor = False
                            GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入数量必须大于0", False)
                            Exit For
                        End If

                        If (String.IsNullOrEmpty(strWarehouseLocationId)) Then
                            rtValue = False
                            CheckFor = False
                            GetMesData.SetMessage(Me.lblMessage, "请选择第" & i + 1 & "行库位", False)
                            Exit For
                        End If

                        If Not (GetMesData.CheckWarehouseLocation(strWarehouseLocationId, lblMessage)) Then
                            rtValue = False
                            CheckFor = False
                            GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行库位不是有效库位", False)
                            Exit For
                        End If
                    Next
                    If (CheckFor) Then
                        rtValue = True
                    End If
                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

    Private Sub InitDataGrid_afterBindData()
        If Me.dgvStoreRequisitionItem.RowCount <= 0 Then Return
        For i As Integer = 0 To Me.dgvStoreRequisitionItem.RowCount - 1
            If (Me.dgvStoreRequisitionItem.Rows(i).Cells("TransactionType").Value = "1") Or String.IsNullOrEmpty(Me.dgvStoreRequisitionItem.Rows(i).Cells("TransactionType").Value) Then
                Me.dgvStoreRequisitionItem.Rows(i).Cells("QUANTITY").ReadOnly = True                              '设置行只读  
                Me.dgvStoreRequisitionItem.Rows(i).Cells("QUANTITY").Style.BackColor = Color.Lavender             '背景设置灰色只读  
            End If
        Next
    End Sub
#End Region

End Class