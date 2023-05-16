'--仓储入库单新增
'--Create by :　马锋
'--Create date :　2015/07/15
'--Update date :  
'--
'--Ver : V01

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

Public Class FrmWarehouseingMaster

#Region "变量声明"
    Dim _strInvoiceTransactionTypeName As String
    Dim _strSavaType As String              '保存类型，暂取消
    Shared _strTransactionId As String
    Shared _MaterialList As DataTable
    Shared _StatusFlag As String            '单据审核状态
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
                _MaterialList.Columns.Add("WAREHOUSEID", Type.GetType("System.String"))
                _MaterialList.Columns.Add("WAREHOUSELOCATIONID", Type.GetType("System.String"))
                _MaterialList.Columns.Add("PlanQuantity", Type.GetType("System.String"))
                _MaterialList.Columns.Add("QUANTITY", Type.GetType("System.String"))
                _MaterialList.Columns.Add("TotalAmount", Type.GetType("System.String"))
                _MaterialList.Columns.Add("REMARK", Type.GetType("System.String"))
                _MaterialList.Columns.Add("OrderNumber", Type.GetType("System.String"))
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

    Private Sub FrmWarehouseingMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.MaterialList.Rows.Clear()
            Me.ScanTransactionId = ""
            Me.dgvInvoiceTransactionItem.AutoGenerateColumns = False

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
            Dim frmMaterial As New FrmMaterialQuery(MaterialList, "0")
            frmMaterial.ShowDialog()
            If (MaterialList.Rows.Count > 0) Then
                Me.dgvInvoiceTransactionItem.DataSource = MaterialList
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

        If Me.dgvInvoiceTransactionItem.Rows.Count = 0 OrElse Me.dgvInvoiceTransactionItem.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要删除行", False)
            Exit Sub
        End If
        Try
            Dim strMaterialNO As String
            Dim strTransactionType As String

            strMaterialNO = Me.dgvInvoiceTransactionItem.Rows(Me.dgvInvoiceTransactionItem.CurrentRow.Index).Cells("MATERIALNO").Value.ToString
            strTransactionType = Me.dgvInvoiceTransactionItem.Rows(Me.dgvInvoiceTransactionItem.CurrentRow.Index).Cells("TransactionType").Value.ToString

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
                                If (Conn.PubConnection.State = ConnectionState.Open) Then
                                    Conn.PubConnection.Close()
                                End If
                                GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
                                Exit Sub
                            End Try
                        End If
                        _MaterialList.Rows.RemoveAt(I)
                        _MaterialList.AcceptChanges()
                        Exit For
                    End If
                Next

                Me.dgvInvoiceTransactionItem.Update()
            Else
                If (Not CheckDelete()) Then
                    Exit Sub
                End If

                Dim strSQL As New StringBuilder
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
                Try
                    strSQL.AppendLine("DECLARE @QUANTITY FLOAT ")
                    strSQL.AppendLine("SELECT @QUANTITY=ISNULL(Quantity,0) FROM m_InvoiceTransactionItem_t WHERE InvoiceTransactionId = '" & TransactionId & "' AND MaterialNO='" & strMaterialNO & "' ")
                    strSQL.AppendLine("UPDATE W_MATERIALS SET QUANTITY= QUANTITY - @QUANTITY WHERE MATERIAL_NO='" & strMaterialNO & "' ")
                    strSQL.AppendLine("IF EXISTS(SELECT InvoiceTransactionId FROM m_InvoiceTransactionItem_t WHERE InvoiceTransactionId = '" & TransactionId & "' AND MaterialNO='" & strMaterialNO & "' AND TransactionType='0' ")
                    strSQL.AppendLine("BEGIN UPDATE m_InvoiceTransactionItem_t SET DeleteFlag='1' WHERE InvoiceTransactionId = '" & TransactionId & "' AND MaterialNO='" & strMaterialNO & "' END ELSE BEGIN ")
                    strSQL.AppendLine("UPDATE m_InvoiceTransactionItem_t SET DeleteFlag='1' WHERE InvoiceTransactionId = '" & TransactionId & "' AND MaterialNO='" & strMaterialNO & "' ")
                    strSQL.AppendLine("UPDATE W_REELS_T SET DeleteFlag='1' WHERE RECEIVENO = '" & TransactionId & "' AND MATERIAL_NO='" & strMaterialNO & "' END")

                    Conn.ExecSql(strSQL.ToString)
                    Conn.PubConnection.Close()

                    Me.dgvInvoiceTransactionItem.DataSource = GetMesData.GetInvoiceTransactionItem(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)
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
                If (String.IsNullOrEmpty(ScanTransactionId)) Then
                    ScanTransactionId = GetMesData.GetScanBarcodeId()
                End If
                strTransactionId = ScanTransactionId
                strScanType = "0"
            Else
                strTransactionId = TransactionId
                strScanType = "1"
            End If
            Dim strMaterialNo As String = ""
            If Not Me.dgvInvoiceTransactionItem.CurrentRow Is Nothing Then
                strMaterialNo = Me.dgvInvoiceTransactionItem.Rows(Me.dgvInvoiceTransactionItem.CurrentRow.Index).Cells("MATERIALNO").Value
            End If

            Dim frmBarcode As New FrmWarehouseingBarCode(strTransactionId, StatusFlag, strScanType, "1", strMaterialNo, MaterialList, "入库条码扫描")
            frmBarcode.ShowDialog()

            If (MaterialList.Rows.Count > 0) Then
                Me.dgvInvoiceTransactionItem.DataSource = MaterialList
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
                Me.dgvInvoiceTransactionItem.DataSource = MaterialList
            End If
            InitDataGrid_afterBindData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnPrinter_Click(sender As Object, e As EventArgs)

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
                strSQL.AppendLine(" DECLARE @DateCode VARCHAR(16), @CurrentCount VARCHAR(16), @CodeFormatDefinitions VARCHAR(64), @StatusFlag VARCHAR(8) ")
                strSQL.AppendLine(" DECLARE @UserID VARCHAR(32) ")
                strSQL.AppendLine(" SET @UserID='" & VbCommClass.VbCommClass.UseId & "' ")
                strSQL.AppendLine(" SELECT @InvoicePrefix = InvoicePrefix FROM m_InvoiceDefinitions_t WHERE InvoiceDefinitionsID='" & Me.cboInvoiceTransactionType.SelectedValue.ToString.Trim & "' ")
                strSQL.AppendLine(" SELECT @RuleDateTime = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'RuleDateTime' ")
                strSQL.AppendLine(" SELECT @RuleCode = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'RuleCode' ")
                strSQL.AppendLine(" SELECT @StatusFlag = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'OutStorageCheck' ")
                strSQL.AppendLine(" SET @DateCode = FORMAT(GETDATE(), @RuleDateTime) ")
                strSQL.AppendLine(" SELECT @CurrentCount = ISNULL(CurrentCount, 0) FROM m_InvoiceDefinitionsCode_t WHERE DateCode = @DateCode AND InvoicePrefix = @InvoicePrefix ")
                strSQL.AppendLine(" IF (ISNULL(@CurrentCount, 0) = 0) BEGIN ")
                strSQL.AppendLine(" SET @CurrentCount = 1 ")
                strSQL.AppendLine(" SET @CodeFormatDefinitions = @InvoicePrefix + @RuleDateTime + @RuleCode ")
                strSQL.AppendLine(" INSERT INTO m_InvoiceDefinitionsCode_t(InvoicePrefix, CurrentCount, DateCode, CodeFormatDefinitions, CreateUser, CreateTime) VALUES(@InvoicePrefix, @CurrentCount, @DateCode, @CodeFormatDefinitions, @UserID, GETDATE()) End ")
                strSQL.AppendLine(" Else BEGIN ")
                strSQL.AppendLine(" UPDATE m_InvoiceDefinitionsCode_t SET CurrentCount = CurrentCount + 1  WHERE DateCode = @DateCode AND InvoicePrefix = @InvoicePrefix ")
                strSQL.AppendLine(" SET @CurrentCount = @CurrentCount + 1 End ")
                strSQL.AppendLine(" SET @TransactionID = @InvoicePrefix + @DateCode + RIGHT(@RuleCode + ltrim(@CurrentCount), LEN(@RuleCode))  ")
                strSQL.AppendLine(" IF(ISNULL(@StatusFlag, 'N'))='N' BEGIN SET @StatusFlag = '1' End ")
                strSQL.AppendLine(" ELSE BEGIN SET @StatusFlag = '0' End ")

                '单头
                strSQL.AppendLine(" INSERT INTO m_InvoiceTransaction_t(InvoiceTransactionType, FactoryId, Profitcenter, TransactionId, WarehouseId, WarehouseName, DeptId, DeptName, ")
                strSQL.AppendLine(" SupplierId, SupplierName, DeliveryId, DeliveryName, AttentionName, OrderNumber, Remark, StatusFlag, DeleteFlag, CreateTime, CreateUser, TransactionType) ")
                strSQL.AppendLine(" VALUES( '" & Me.cboInvoiceTransactionType.SelectedValue & "','" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "', @TransactionID,'" & Me.cboWarehouse.SelectedValue & "', N'" & Me.cboWarehouse.Text.Trim & "', NULL, NULL,")
                strSQL.AppendLine(" N'" & Me.mtxtSupplier.Text.Trim & "', NULL,N'" & Me.mtxtDelivery.Text.Trim & "', NULL, N'" & Me.mtxtAttentionName.Text.Trim & "','" & Me.txtERPTranscationID.Text.Trim & "', N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "',")
                strSQL.AppendLine(" @StatusFlag, 0, GETDATE(), @UserID, 0) ")

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
                Dim strOrderNumber As String

                For I As Int16 = 0 To Me.dgvInvoiceTransactionItem.Rows.Count - 1
                    strMaterialNO = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(I).Cells("MATERIALNO").Value), "", Me.dgvInvoiceTransactionItem.Rows(I).Cells("MATERIALNO").Value.ToString())
                    strDescription = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(I).Cells("DESCRIPTION").Value), "", Me.dgvInvoiceTransactionItem.Rows(I).Cells("DESCRIPTION").Value.ToString())
                    strSpecification = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(I).Cells("SPECIFICATION").Value), "", Me.dgvInvoiceTransactionItem.Rows(I).Cells("SPECIFICATION").Value.ToString())
                    strUint = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(I).Cells("UOM_NAME").Value), "", Me.dgvInvoiceTransactionItem.Rows(I).Cells("UOM_NAME").Value.ToString())
                    strQuantity = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(I).Cells("QUANTITY").Value), "0", Me.dgvInvoiceTransactionItem.Rows(I).Cells("QUANTITY").Value.ToString())
                    strUnitPrice = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(I).Cells("UNITPRICE").Value), "0", Me.dgvInvoiceTransactionItem.Rows(I).Cells("UNITPRICE").Value.ToString())
                    strTotalAmount = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(I).Cells("TotalAmount").Value), "0", Me.dgvInvoiceTransactionItem.Rows(I).Cells("TotalAmount").Value.ToString())
                    strRemark = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(I).Cells("REMARK").Value), "", Me.dgvInvoiceTransactionItem.Rows(I).Cells("REMARK").Value.ToString())
                    strTransactionType = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(I).Cells("TransactionType").Value), "", Me.dgvInvoiceTransactionItem.Rows(I).Cells("TransactionType").Value.ToString())
                    strWarehouseLocationId = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(I).Cells("mtxtWarehouseLocationId").Value), "", Me.dgvInvoiceTransactionItem.Rows(I).Cells("mtxtWarehouseLocationId").Value.ToString())
                    strOrderNumber = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(I).Cells("OrderNumber").Value), "", Me.dgvInvoiceTransactionItem.Rows(I).Cells("OrderNumber").Value.ToString())

                    If (String.IsNullOrEmpty(strTransactionType)) Then
                        strTransactionType = "0"
                    End If

                    If (strTransactionType = "1") Then
                        ScanBarcode = True
                    End If

                    strSQL.AppendLine(" INSERT INTO m_InvoiceTransactionItem_t(InvoiceTransactionId, MaterialNO, Description, Specification, Uint, Quantity, UnitPrice, totalAmount, OrderNumber, ")
                    strSQL.AppendLine(" TransactionType, Remark, DeleteFlag, CreateUser, CreateTime, WarehouseLocationId) ")
                    strSQL.AppendLine(" VALUES( @TransactionID, '" & strMaterialNO & "', N'" & strDescription.Replace("'", "''") & "', N'" & strSpecification.Replace("'", "''") & "', N'" & strUint & "', '" & strQuantity & "', '" & strUnitPrice & "', '" & strTotalAmount & "', '" & strOrderNumber & "',")
                    strSQL.AppendLine("  '" & strTransactionType & "', N'" & strRemark & "', 0, @UserID, GETDATE(), '" & strWarehouseLocationId & "') ")
                    strSQL.AppendLine(" IF(ISNULL(@StatusFlag,'1')='1') BEGIN  ")
                    strSQL.AppendLine(" UPDATE W_MATERIALS SET QUANTITY = QUANTITY + " & strQuantity & " WHERE MATERIAL_NO='" & strMaterialNO & "' End ")
                Next

                If (ScanBarcode) Then
                    ''" & strBarCode & "', '" & strMaterialNO & "', '" & strMaterialNO & "', '" & strSpecification & "', '" & strDescription & "''" & strUint & "', '" & strUint & "', '" & strVendorId & "', '" & strVendorId & "''" & strQuantity & "', '" & strQuantity & "''" & strDateCode & "', '" & strVersion & "'

                    strSQL.AppendLine(" INSERT INTO W_REELS_T( FACTORY_ID, PROFITCENTER, REEL_BARCODE, MATERIAL_ID, MATERIAL_NO, SPECIFICATION, DESCRIPTION, ")
                    strSQL.AppendLine(" UNIT_MEASURE_ID, UOM_NAME, VENDOR_ID, VENDOR_NAME, RECEIVENO, QUANTITY, REMAINING_QUANTITY,  ")
                    strSQL.AppendLine(" WAREHOUSE, LOCATION, DATECODE, VERSIONS, CREATE_USERID, CREATE_TIME, STATUS, CREATE_DATECODE, TYPEFLAG, DELETEFLAG, WarehouseLot, PARENT_REEL_ID) ")
                    strSQL.AppendLine(" SELECT '" & VbCommClass.VbCommClass.Factory & "', '" & VbCommClass.VbCommClass.profitcenter & "', BarCode, m_ScanBacodeTransaction_t.MaterialNO, m_ScanBacodeTransaction_t.MaterialNO, m_ScanBacodeTransaction_t.Specification, m_ScanBacodeTransaction_t.Description, m_ScanBacodeTransaction_t.Uint , m_ScanBacodeTransaction_t.Uint, ")
                    strSQL.AppendLine(" m_ScanBacodeTransaction_t.VenderId, m_ScanBacodeTransaction_t.VenderId, @TransactionID, m_ScanBacodeTransaction_t.Quantity, m_ScanBacodeTransaction_t.Quantity, ")
                    strSQL.AppendLine(" '" & Me.cboWarehouse.SelectedValue & "', m_InvoiceTransactionItem_t.WarehouseLocationId, m_ScanBacodeTransaction_t.DateCode, m_ScanBacodeTransaction_t.Versions, '" & VbCommClass.VbCommClass.UseId & "', GETDATE(), @StatusFlag, CONVERT(VARCHAR(100), GETDATE(), 120), '0', '0', CONVERT(VARCHAR(100), GETDATE(), 120), BarCode ")
                    strSQL.AppendLine(" FROM m_ScanBacodeTransaction_t INNER JOIN m_InvoiceTransactionItem_t ON m_InvoiceTransactionItem_t.MaterialNO=m_ScanBacodeTransaction_t.MaterialNO WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_InvoiceTransactionItem_t.InvoiceTransactionId=@TransactionId ")
                    strSQL.AppendLine(" UPDATE m_ScanBacodeTransaction_t SET StatusFlag='1', TransactionId = @TransactionId WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND DeleteFlag='0' AND StatusFlag='0'")
                End If

                'If (_strSavaType = "2") Then
                '    Dim strBarCode As String
                '    Dim strVendorId As String
                '    Dim strDateCode As String
                '    Dim strVersion As String

                'For I As Int16 = 0 To BarCodeList.Rows.Count - 1
                '    strBarCode = BarCodeList.Rows(I).Item("BARCODE").ToString
                '    strMaterialNO = BarCodeList.Rows(I).Item("MATERIAL_NO").Value.ToString
                '    strDescription = BarCodeList.Rows(I).Item("DESCRIPTION").Value.ToString
                '    strSpecification = BarCodeList.Rows(I).Item("SPECIFICATION").Value.ToString
                '    strUint = BarCodeList.Rows(I).Item("UOM_NAME").Value.ToString
                '    strVendorId = BarCodeList.Rows(I).Item("VendorCode").Value.ToString
                '    strQuantity = BarCodeList.Rows(I).Item("QUANTITY").Value.ToString
                '    strDateCode = BarCodeList.Rows(I).Item("DateCode").Value.ToString
                '    strVersion = BarCodeList.Rows(I).Item("Versions").Value.ToString

                '    strSQL.AppendLine(" INSERT INTO W_REELS_T( FACTORY_ID, PROFITCENTER, REEL_BARCODE, MATERIAL_ID, MATERIAL_NO, SPECIFICATION, DESCRIPTION, ")
                '    strSQL.AppendLine(" UNIT_MEASURE_ID, UOM_NAME, VENDOR_ID, VENDOR_NAME, RECEIVENO, QUANTITY, REMAINING_QUANTITY,  ")
                '    strSQL.AppendLine(" WAREHOUSE, DATECODE, VERSIONS, CREATE_USERID, CREATE_TIME, STATUS, CREATE_DATECODE, TYPEFLAG, DELETEFLAG) ")
                '    strSQL.AppendLine(" VALUES(  ")
                '    strSQL.AppendLine(" '" & VbCommClass.VbCommClass.Factory & "', '" & VbCommClass.VbCommClass.profitcenter & "', '" & strBarCode & "', '" & strMaterialNO & "', '" & strMaterialNO & "', '" & strSpecification & "', '" & strDescription & "',")
                '    strSQL.AppendLine(" '" & strUint & "', '" & strUint & "', '" & strVendorId & "', '" & strVendorId & "', @TransactionID, '" & strQuantity & "', '" & strQuantity & "', ")
                '    strSQL.AppendLine(" '" & Me.cboWarehouse.SelectedText.Trim & "', '" & strDateCode & "', '" & strVersion & "', '" & VbCommClass.VbCommClass.UseId & "',, GETDATE(), @StatusFlag, CONVERT(VARCHAR(100), GETDATE(), 12), '0', '0') ")
                'Next
                'End If
            Else
                '编辑
                strSQL.AppendLine(" UPDATE m_InvoiceTransaction_t SET ")
                strSQL.AppendLine(" InvoiceTransactionType ='" & Me.cboInvoiceTransactionType.SelectedValue & "', WarehouseId='" & Me.cboWarehouse.SelectedValue & "', WarehouseName=N'" & Me.cboWarehouse.SelectedText.Trim & "',")
                strSQL.AppendLine(" SupplierId='" & Me.mtxtSupplier.Text.Trim & "',DeliveryId='" & Me.mtxtDelivery.Text.Trim & "',AttentionName='" & Me.mtxtAttentionName.Text.Trim & "',OrderNumber='" & Me.txtERPTranscationID.Text.Trim & "', Remark=N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "',UpdateUser='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=Getdate() ")
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

    Private Sub mtxtSupplier_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtSupplier.ButtonCustomClick
        Try
            Dim frmSupplier As New FrmSupplierQuery(Me.mtxtSupplier)
            frmSupplier.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub mtxtDelivery_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtDelivery.ButtonCustomClick
        Try
            Dim frmuser As New FrmUserQuery(Me.mtxtDelivery)
            frmuser.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
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
        Try
            'Handles mtxtWarehouseLocationId.ButtonCustomClick
            'If (String.IsNullOrEmpty(Me.dgvInvoiceTransactionItem.Rows(Me.dgvInvoiceTransactionItem.CurrentRow.Index).Cells("MATERIALNO").Value)) Then
            '    GetMesData.SetMessage(Me.lblMessage, "请选择物料", False)
            '    Exit Sub
            'End If

            Dim strWarehouseName As String
            strWarehouseName = Me.cboWarehouse.Text
            If (String.IsNullOrEmpty(strWarehouseName)) Then
                GetMesData.SetMessage(Me.lblMessage, "请选择仓库", False)
                Exit Sub
            End If

            Dim cell As DataGridViewMaskedTextBoxAdvCell = TryCast(Me.dgvInvoiceTransactionItem.CurrentCell, DataGridViewMaskedTextBoxAdvCell)

            If cell IsNot Nothing Then
                Dim ec As DataGridViewMaskedTextBoxAdvEditingControl = TryCast(cell.DataGridView.EditingControl, DataGridViewMaskedTextBoxAdvEditingControl)

                If ec IsNot Nothing Then
                    Dim frmWarehouseLocationQuery As New FrmWarehouseLocationQuery(strWarehouseName, ec)
                    frmWarehouseLocationQuery.ShowDialog()
                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub txtERPTranscationID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtERPTranscationID.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                If (String.IsNullOrEmpty(Me.txtERPTranscationID.Text.Trim())) Then
                    GetMesData.SetMessage(Me.lblMessage, "请输入下载单号", False)
                    Exit Sub
                End If

                Dim TiptopConn As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
                Dim dvTiptopWarehouseing As DataView
                dvTiptopWarehouseing = GetTiptopDate.GetWarehouseing(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, Me.txtERPTranscationID.Text.Trim)
                '获取Tiptop入库单信息 RVV02, RVV31, RVV17, IMA02, IMA021, IMA25
                If Not dvTiptopWarehouseing Is Nothing Then
                    If dvTiptopWarehouseing.Count > 0 Then
                        If (MaterialList.Rows.Count > 0) Then
                            MaterialList.Rows.Clear()
                        End If

                        For i As Int16 = 0 To dvTiptopWarehouseing.Count - 1

                            Dim drTemp As DataRow
                            drTemp = MaterialList.NewRow
                            drTemp("MATERIALNO") = dvTiptopWarehouseing.Item(i).Item("RVV31").ToString
                            drTemp("DESCRIPTION") = dvTiptopWarehouseing.Item(i).Item("IMA02").ToString
                            drTemp("SPECIFICATION") = dvTiptopWarehouseing.Item(i).Item("IMA021").ToString
                            drTemp("UOM_NAME") = dvTiptopWarehouseing.Item(i).Item("IMA25").ToString
                            drTemp("STOCKQUANTITY") = "0"
                            drTemp("UNITPRICE") = "0"
                            drTemp("QUANTITY") = "0"
                            drTemp("PlanQuantity") = dvTiptopWarehouseing.Item(i).Item("RVV17").ToString
                            drTemp("TransactionType") = ""
                            MaterialList.Rows.Add(drTemp)
                            MaterialList.AcceptChanges()
                        Next
                    End If
                    Me.dgvInvoiceTransactionItem.DataSource = MaterialList
                Else
                    GetMesData.SetMessage(Me.lblMessage, "单号不存在", False)
                End If
            End If
        Catch
            GetMesData.SetMessage(Me.lblMessage, "下载异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadControlData()
        Dim strSQL As String
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            Me.dtpInvoiceDate.Value = Now
            'InvoiceDefinitionsType
            strSQL = "SELECT InvoiceDefinitionsId, InvoiceDefinitionsName FROM m_InvoiceDefinitions_t WHERE InvoiceDefinitionsType='1'"
            dtTemp = Conn.GetDataTable(strSQL)

            Me.cboInvoiceTransactionType.DisplayMember = "InvoiceDefinitionsName"
            Me.cboInvoiceTransactionType.ValueMember = "InvoiceDefinitionsId"
            Me.cboInvoiceTransactionType.DataSource = dtTemp

            Conn.PubConnection.Close()

            Me.cboWarehouse.DisplayMember = "WarehouseName"
            Me.cboWarehouse.ValueMember = "WarehouseCode"
            Me.cboWarehouse.DataSource = GetMesData.GetWarehouse(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "")

            If (String.IsNullOrEmpty(_strTransactionId)) Then
                If Not (String.IsNullOrEmpty(_strInvoiceTransactionTypeName)) Then
                    Me.cboInvoiceTransactionType.SelectedIndex = Me.cboInvoiceTransactionType.FindString(_strInvoiceTransactionTypeName)
                Else
                    Me.cboInvoiceTransactionType.SelectedIndex = 0
                End If

                Me.dgvInvoiceTransactionItem.Rows.Add(7)

                Me.cboWarehouse.SelectedIndex = 0
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
                    Me.cboWarehouse.SelectedIndex = cboWarehouse.FindString(dtInvoice.Rows(0).Item("WarehouseName").ToString)
                    Me.txtOrderNumber.Text = dtInvoice.Rows(0).Item("OrderNumber").ToString
                    Me.mtxtAttentionName.Text = dtInvoice.Rows(0).Item("AttentionName").ToString
                    Me.mtxtSupplier.Text = dtInvoice.Rows(0).Item("SupplierName").ToString
                    Me.mtxtDelivery.Text = dtInvoice.Rows(0).Item("DeliveryName").ToString
                    Me.txtRemark.Text = dtInvoice.Rows(0).Item("Remark").ToString

                    StatusFlag = dtInvoice.Rows(0).Item("StatusFlag").ToString
                End If

                MaterialList = GetMesData.GetInvoiceTransactionItem(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)
                Me.dgvInvoiceTransactionItem.DataSource = MaterialList
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

            If (String.IsNullOrEmpty(cboWarehouse.SelectedValue)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择仓库", False)
                Exit Function
            End If

            If (String.IsNullOrEmpty(mtxtAttentionName.Text.Trim())) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择经办人", False)
                Exit Function
            End If

            If (String.IsNullOrEmpty(mtxtSupplier.Text.Trim())) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择供应商", False)
                Exit Function
            End If

            If (String.IsNullOrEmpty(mtxtDelivery.Text.Trim())) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择交货人", False)
                Exit Function
            End If

            If (Me.dgvInvoiceTransactionItem.Rows.Count <= 0) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
            Else
                Dim Qty As String
                Dim strMaterialNO As String
                Dim strWarehouseLocationId As String
                Dim SelectMaterialNO As Boolean = False
                Dim CheckFor As Boolean = True
                If (IsDBNull(Me.dgvInvoiceTransactionItem.Rows(0).Cells("MaterialNO").Value) Or Me.dgvInvoiceTransactionItem.Rows(0).Cells("MaterialNO").Value Is Nothing) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
                Else
                    For i As Int16 = 0 To Me.dgvInvoiceTransactionItem.Rows.Count - 1
                        strMaterialNO = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(i).Cells("MaterialNO").Value), "", Me.dgvInvoiceTransactionItem.Rows(i).Cells("MaterialNO").Value.ToString())
                        Qty = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(i).Cells("QUANTITY").Value), "", Me.dgvInvoiceTransactionItem.Rows(i).Cells("QUANTITY").Value.ToString())
                        strWarehouseLocationId = IIf(IsDBNull(Me.dgvInvoiceTransactionItem.Rows(i).Cells("mtxtWarehouseLocationId").Value), "", Me.dgvInvoiceTransactionItem.Rows(i).Cells("mtxtWarehouseLocationId").Value.ToString())
                        If (Not String.IsNullOrEmpty(strMaterialNO)) Then
                            SelectMaterialNO = True
                            If Not IsNumeric(Qty) Then
                                rtValue = False
                                CheckFor = False
                                GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入数量格式错误", False)
                                Exit For
                            End If
                            If (CDbl(Qty) <= 0) Then
                                rtValue = False
                                CheckFor = False
                                GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入数量不能小于0", False)
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
                        End If
                    Next
                    If (SelectMaterialNO) Then
                        If (CheckFor) Then
                            rtValue = True
                        End If
                    Else
                        GetMesData.SetMessage(Me.lblMessage, "请选择入库物料", False)
                        rtValue = False
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
        If Me.dgvInvoiceTransactionItem.RowCount <= 0 Then Return
        For i As Integer = 0 To Me.dgvInvoiceTransactionItem.RowCount - 1
            If (String.IsNullOrEmpty(Me.dgvInvoiceTransactionItem.Rows(i).Cells("TransactionType").Value) Or Me.dgvInvoiceTransactionItem.Rows(i).Cells("TransactionType").Value = "1") Then
                Me.dgvInvoiceTransactionItem.Rows(i).Cells("QUANTITY").ReadOnly = True                               '设置行只读  
                Me.dgvInvoiceTransactionItem.Rows(i).Cells("QUANTITY").Style.BackColor = Color.Lavender             '背景设置灰色只读  
            End If
        Next
    End Sub
#End Region

End Class