
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

Public Class FrmInventoryCheckingMaster

#Region "变量声明"
    Dim _strInvoiceTransactionTypeName As String
    Dim _strSavaType As String
    Shared _strTransactionId As String
    Shared _MaterialList As DataTable
    Shared _StatusFlag As String
    Shared _ScanTransactionId As String

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
                _MaterialList.Columns.Add("UOM_NAME", Type.GetType("System.String"))    'Uint
                _MaterialList.Columns.Add("QUANTITY", Type.GetType("System.String"))    'BookQuantity
                _MaterialList.Columns.Add("STOCKQUANTITY", Type.GetType("System.String"))
                _MaterialList.Columns.Add("CheckQuantity", Type.GetType("System.String"))
                _MaterialList.Columns.Add("ProfitQuantity", Type.GetType("System.String"))
                _MaterialList.Columns.Add("LossQuantity", Type.GetType("System.String"))
                _MaterialList.Columns.Add("BookPrice", Type.GetType("System.String"))
                _MaterialList.Columns.Add("UnitPrice", Type.GetType("System.String"))
                _MaterialList.Columns.Add("TotalAmount", Type.GetType("System.String"))
                _MaterialList.Columns.Add("Remark", Type.GetType("System.String"))
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

    Private Sub FrmInventoryCheckingMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvInventroyCheckingItem.AutoGenerateColumns = False
            '基础数据加载
            LoadControlData()
            Me.ScanTransactionId = ""
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
                Me.dgvInventroyCheckingItem.DataSource = MaterialList
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

        If Me.dgvInventroyCheckingItem.Rows.Count = 0 OrElse Me.dgvInventroyCheckingItem.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要删除行", False)
            Exit Sub
        End If
        Try
            Dim strMaterialNO As String
            Dim strTransactionType As String

            strMaterialNO = Me.dgvInventroyCheckingItem.Rows(Me.dgvInventroyCheckingItem.CurrentRow.Index).Cells("MATERIALNO").Value.ToString
            strTransactionType = Me.dgvInventroyCheckingItem.Rows(Me.dgvInventroyCheckingItem.CurrentRow.Index).Cells("TransactionType").Value.ToString

            If (String.IsNullOrEmpty(TransactionId)) Then
                If (String.IsNullOrEmpty(strMaterialNO)) Then
                    GetMesData.SetMessage(Me.lblMessage, "删除行料号不能为空", False)
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

                Me.dgvInventroyCheckingItem.Update()
            Else
                If (Not CheckDelete()) Then
                    Exit Sub
                End If

                Dim strSQL As New StringBuilder
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
                Try
                    strSQL.AppendLine("UPDATE m_InventoryCheckingItem_t SET DeleteFlag='1' WHERE TransactionId = '" & TransactionId & "' AND MaterialNO='" & strMaterialNO & "' END ")
                    If (strTransactionType = "1") Then
                        strSQL.AppendLine("UPDATE m_InventoryCheckingBarcode_t SET DeleteFlag='1' WHERE TransactionId = '" & ScanTransactionId & "' AND MaterialNO='" & strMaterialNO & "' ")
                    End If

                    Conn.ExecSql(strSQL.ToString)
                    Conn.PubConnection.Close()

                    Me.dgvInventroyCheckingItem.DataSource = GetMesData.GetInvoiceTransactionItem(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)
                Catch ex As Exception
                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If
                    GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
                End Try
            End If

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
            If Not Me.dgvInventroyCheckingItem.CurrentRow Is Nothing Then
                strMaterialNo = Me.dgvInventroyCheckingItem.Rows(Me.dgvInventroyCheckingItem.CurrentRow.Index).Cells("MATERIALNO").Value
            End If

            Dim frmBarcode As New FrmWarehouseingBarCode(strTransactionId, StatusFlag, strScanType, "4", strMaterialNo, MaterialList, "盘点条码扫描")
            frmBarcode.ShowDialog()

            If (MaterialList.Rows.Count > 0) Then
                Me.dgvInventroyCheckingItem.DataSource = MaterialList
            End If
            InitDataGrid_afterBindData()

            'If (String.IsNullOrEmpty(ScanTransactionId)) Then

            'End If

            'Dim frmBarcode As New FrmWarehouseingBarCode(TransactionId, StatusFlag, "2", ScanTransactionId, BarCodeList, MaterialList)
            'frmBarcode.ShowDialog()

            'If (MaterialList.Rows.Count > 0) Then
            '    Me.dgvInventroyCheckingItem.DataSource = MaterialList
            'End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnStick_Click(sender As Object, e As EventArgs) Handles btnStick.Click
        Try
            Dim frmBulkPasteMaterial As New FrmBulkPasteMaterialQuery(MaterialList)
            frmBulkPasteMaterial.ShowDialog()
            If (MaterialList.Rows.Count > 0) Then
                Me.dgvInventroyCheckingItem.DataSource = MaterialList
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

                strSQL.AppendLine(" DECLARE @TransactionID VARCHAR(32),@InvoicePrefix VARCHAR(16), @RuleDateTime VARCHAR(16), @RuleCode VARCHAR(16), @InventoryCheckQuantity VARCHAR(16) ")
                strSQL.AppendLine(" DECLARE @DateCode VARCHAR(16), @CurrentCount VARCHAR(16), @CodeFormatDefinitions VARCHAR(64), @StatusFlag VARCHAR(8) ")
                strSQL.AppendLine(" DECLARE @UserID VARCHAR(32) ")
                strSQL.AppendLine(" SET @UserID='" & VbCommClass.VbCommClass.UseId & "' ")
                strSQL.AppendLine(" SELECT @InvoicePrefix = InvoicePrefix FROM m_InvoiceDefinitions_t WHERE InvoiceDefinitionsID='" & Me.cboInvoiceTransactionType.SelectedValue.ToString.Trim & "' ")
                strSQL.AppendLine(" SELECT @RuleDateTime = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'RuleDateTime' ")
                strSQL.AppendLine(" SELECT @RuleCode = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'RuleCode' ")
                strSQL.AppendLine(" SELECT @StatusFlag = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'InventoryChecking' ")
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
                strSQL.AppendLine(" IF(ISNULL(@StatusFlag, 'N')='N') BEGIN SET @StatusFlag = '1' End ")
                strSQL.AppendLine(" ELSE BEGIN SET @StatusFlag = '0' End ")
                strSQL.AppendLine(" SELECT @InventoryCheckQuantity = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'InventoryCheckQuantity' ")

                '单头
                strSQL.AppendLine(" INSERT INTO m_InventoryChecking_t(FactoryId, Profitcenter, InvoiceTransactionType, TransactionId, InventoryCheckMonth, WharehouseId, WharehouseName, AttentionName, Remark, StatusFlag, DeleteFlag, CreateTime, CreateUser ")
                strSQL.AppendLine(" )VALUES('" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "', '" & Me.cboInvoiceTransactionType.SelectedValue & "', @TransactionID, '" & Me.dtpInvoiceDate.Text.Trim & "','" & Me.cboWarehouse.SelectedValue & "', N'" & Me.cboWarehouse.SelectedText.Trim & "',")
                strSQL.AppendLine(" '" & Me.mtxtAttentionName.Text.Trim & "', N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "', @StatusFlag, 0, GETDATE(), @UserID) ")

                '单身
                Dim strMaterialNO As String
                Dim strDescription As String
                Dim strSpecification As String
                Dim strUint As String
                Dim strQuantity As String
                Dim strBookQuantity As String
                Dim strCheckQuantity As String
                Dim strProfitQuantity As String
                Dim strLossQuantity As String
                Dim strUnitPrice As String
                Dim strTotalAmount As String
                Dim strRemark As String
                Dim strCheckStatus As String
                Dim strTransactionType As String
                Dim ScanBarcode As Boolean = False

                For I As Int16 = 0 To Me.dgvInventroyCheckingItem.Rows.Count - 1
                    strMaterialNO = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(I).Cells("MATERIALNO").Value), "", Me.dgvInventroyCheckingItem.Rows(I).Cells("MATERIALNO").Value.ToString())
                    strDescription = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(I).Cells("DESCRIPTION").Value), "", Me.dgvInventroyCheckingItem.Rows(I).Cells("DESCRIPTION").Value.ToString())
                    strSpecification = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(I).Cells("SPECIFICATION").Value), "", Me.dgvInventroyCheckingItem.Rows(I).Cells("SPECIFICATION").Value.ToString())
                    strUint = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(I).Cells("UOM_NAME").Value), "", Me.dgvInventroyCheckingItem.Rows(I).Cells("UOM_NAME").Value.ToString())
                    strBookQuantity = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(I).Cells("BookQuantity").Value), "0", Me.dgvInventroyCheckingItem.Rows(I).Cells("BookQuantity").Value.ToString())
                    strCheckQuantity = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(I).Cells("CheckQuantity").Value), "0", Me.dgvInventroyCheckingItem.Rows(I).Cells("CheckQuantity").Value.ToString())
                    strProfitQuantity = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(I).Cells("ProfitQuantity").Value), "0", Me.dgvInventroyCheckingItem.Rows(I).Cells("ProfitQuantity").Value.ToString())
                    strLossQuantity = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(I).Cells("LossQuantity").Value), "0", Me.dgvInventroyCheckingItem.Rows(I).Cells("LossQuantity").Value.ToString())
                    strUnitPrice = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(I).Cells("UNITPRICE").Value), "0", Me.dgvInventroyCheckingItem.Rows(I).Cells("UNITPRICE").Value.ToString())
                    strTotalAmount = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(I).Cells("TotalAmount").Value), "0", Me.dgvInventroyCheckingItem.Rows(I).Cells("TotalAmount").Value.ToString())
                    strRemark = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(I).Cells("Remark").Value), "", Me.dgvInventroyCheckingItem.Rows(I).Cells("Remark").Value.ToString())
                    strTransactionType = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(I).Cells("TransactionType").Value), "", Me.dgvInventroyCheckingItem.Rows(I).Cells("TransactionType").Value.ToString())
                    'strType:0->数量新增,1->条码新增(TransactionType通过盘点条码Temp决定)

                    'CheckStatus:0:盘亏,1:盘盈
                    If (Not String.IsNullOrEmpty(strProfitQuantity)) Then
                        If (CInt(strProfitQuantity) > 0) Then
                            strQuantity = strProfitQuantity
                            strCheckStatus = "1"
                        Else
                            strQuantity = strLossQuantity
                            strCheckStatus = "0"
                        End If
                    Else
                        strQuantity = strLossQuantity
                        strCheckStatus = "0"
                    End If

                    If (strTransactionType = "1") Then
                        ScanBarcode = True
                    End If

                    If (String.IsNullOrEmpty(strMaterialNO)) Then
                        Continue For
                    End If
                    ', Quantity
                    strSQL.AppendLine(" INSERT INTO m_InventoryCheckingItem_t( TransactionId, MaterialNO, Description, Specification, Uint, BookQuantity, CheckQuantity, Quantity, BookPrice, UnitPrice, ")
                    strSQL.AppendLine(" TotalAmount, CheckStatus, Remark, TransactionType, DeleteFlag, CreateUser, CreateTime) ")
                    strSQL.AppendLine(" VALUES( @TransactionID, '" & strMaterialNO & "', N'" & strDescription.Replace("'", "''") & "', N'" & strSpecification.Replace("'", "''") & "', N'" & strUint & "', '" & strBookQuantity & "', '" & strCheckQuantity & "', '" & strQuantity & "',")
                    strSQL.AppendLine(" '" & strUnitPrice & "', '" & strUnitPrice & "', 0, '" & strCheckStatus & "', N'" & strRemark & "', '" & strTransactionType & "', 0, @UserID, GETDATE()) ")
                    strSQL.AppendLine(" IF(ISNULL(@StatusFlag,'1')='1' AND ISNULL(@InventoryCheckQuantity,'N')='Y' ) BEGIN  ")
                    strSQL.AppendLine(" UPDATE W_MATERIALS SET QUANTITY = " & strCheckQuantity & " WHERE MATERIAL_NO='" & strMaterialNO & "' End ")
                Next

               If (ScanBarcode) Then
                    ''" & strBarCode & "', '" & strMaterialNO & "', '" & strMaterialNO & "', '" & strSpecification & "', '" & strDescription & "''" & strUint & "', '" & strUint & "', '" & strVendorId & "', '" & strVendorId & "''" & strQuantity & "', '" & strQuantity & "''" & strDateCode & "', '" & strVersion & "'

                    strSQL.AppendLine(" INSERT INTO m_InventoryCheckingBarcode_t(TransactionId, BarCode, MaterialNO, Description, Specification, Uint, Quantity, WarehouseId, WareHouseName, WarehouseLocationId, Remark, DeleteFlag, CreateUser, CreateTime ")
                    strSQL.AppendLine(" ) ")
                    strSQL.AppendLine(" SELECT @TransactionID, BarCode, MaterialNO, Specification, Description, Uint, Quantity, ")
                    strSQL.AppendLine(" NULL, NULL, NULL, NULL, '0', @UserID, GETDATE() FROM m_ScanBacodeTransaction_t WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND DeleteFlag='0' AND StatusFlag='0'")
                    strSQL.AppendLine(" UPDATE m_ScanBacodeTransaction_t SET StatusFlag='1', TransactionId = @TransactionId WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND DeleteFlag='0' AND StatusFlag='0'")
                End If
            Else
                '编辑
                strSQL.AppendLine(" UPDATE m_InvoiceTransaction_t SET ")
                strSQL.AppendLine(" InvoiceTransactionType ='" & Me.cboInvoiceTransactionType.SelectedValue & "', WarehouseId='" & Me.cboWarehouse.SelectedValue & "', WarehouseName=N'" & Me.cboWarehouse.SelectedText.Trim & "',")
                strSQL.AppendLine(" AttentionName='" & Me.mtxtAttentionName.Text.Trim & "', Remark=N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "',UpdateUser='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=Getdate() ")
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

#End Region

#Region "函数"

    Private Sub LoadControlData()
        Dim strSQL As String
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            Me.dtpInvoiceDate.Value = Now
            'InvoiceDefinitionsType
            strSQL = "SELECT InvoiceDefinitionsId, InvoiceDefinitionsName FROM m_InvoiceDefinitions_t WHERE InvoiceDefinitionsType='4'"
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

                Me.dgvInventroyCheckingItem.Rows.Add(7)
                If (Me.cboWarehouse.Items.Count > 0) Then
                    Me.cboWarehouse.SelectedIndex = 0
                End If
                Me.txtTransactionId.Text = "<自动编号>"
                Me.dtpInvoiceDate.Value = Now
            Else
                Dim dtInvoice As DataTable
                dtInvoice = GetMesData.GetInventoryChecking(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)

                If (Not dtInvoice Is Nothing And dtInvoice.Rows.Count > 0) Then
                    Me.dtpInvoiceDate.Text = dtInvoice.Rows(0).Item("CreateTime").ToString
                    Me.txtTransactionId.Text = dtInvoice.Rows(0).Item("TransactionId").ToString
                    Me.cboInvoiceTransactionType.SelectedIndex = cboInvoiceTransactionType.FindString(dtInvoice.Rows(0).Item("InvoiceDefinitionsName").ToString)
                    'txtERPTranscationID.Text = dtInvoice.Rows(0).Item("OrderNumber").ToString
                    Me.cboWarehouse.SelectedIndex = cboWarehouse.FindString(dtInvoice.Rows(0).Item("WarehouseName").ToString)
                    Me.mtxtAttentionName.Text = dtInvoice.Rows(0).Item("AttentionName").ToString
                    Me.txtRemark.Text = dtInvoice.Rows(0).Item("Remark").ToString

                    StatusFlag = dtInvoice.Rows(0).Item("StatusFlag").ToString

                    'If (dtInvoice.Rows(0).Item("TransactionType").ToString = "1") Then
                    '    BarCodeList = GetMesData.GetTransactionBarCode(TransactionId, "")
                    'End If
                End If

                Dim dtInventoryCheckingItem As DataTable
                dtInventoryCheckingItem = GetMesData.GetInventoryCheckingItem(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)

                If (Not dtInventoryCheckingItem Is Nothing And dtInventoryCheckingItem.Rows.Count > 0) Then
                    Me.dgvInventroyCheckingItem.DataSource = dtInventoryCheckingItem
                End If
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
            strSQL.AppendLine("SELECT @OutStorageCheck= ISNULL(PARAMETER_VALUES,'N') FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'InventoryChecking' ")
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

            If (String.IsNullOrEmpty(Me.mtxtAttentionName.Text.Trim)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择经办人", False)
                Exit Function
            End If

            If (Me.dgvInventroyCheckingItem.Rows.Count <= 0) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
            Else
                Dim CheckQuantity As String
                Dim strMaterialNO As String
                Dim SelectMaterialNO As Boolean = False
                Dim strProfitQuantity As String
                Dim strLossQuantity As String
                Dim CheckFor As Boolean = True
                If (IsDBNull(Me.dgvInventroyCheckingItem.Rows(0).Cells("MaterialNO").Value) Or Me.dgvInventroyCheckingItem.Rows(0).Cells("MaterialNO").Value Is Nothing) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
                Else
                    For i As Int16 = 0 To Me.dgvInventroyCheckingItem.Rows.Count - 1
                        strMaterialNO = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(i).Cells("MaterialNO").Value), "", Me.dgvInventroyCheckingItem.Rows(i).Cells("MaterialNO").Value)
                        CheckQuantity = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(i).Cells("CheckQuantity").Value), "", Me.dgvInventroyCheckingItem.Rows(i).Cells("CheckQuantity").Value)
                        strProfitQuantity = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(i).Cells("ProfitQuantity").Value), "", Me.dgvInventroyCheckingItem.Rows(i).Cells("ProfitQuantity").Value)
                        strLossQuantity = IIf(IsDBNull(Me.dgvInventroyCheckingItem.Rows(i).Cells("LossQuantity").Value), "", Me.dgvInventroyCheckingItem.Rows(i).Cells("LossQuantity").Value)
                        If (Not String.IsNullOrEmpty(strMaterialNO)) Then
                            SelectMaterialNO = True

                            If (String.IsNullOrEmpty(CheckQuantity)) Then
                                rtValue = False
                                CheckFor = False
                                GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入盘点数量不能为空", False)
                                Exit For
                            Else
                                If (Not IsNumeric(CheckQuantity)) Then
                                    rtValue = False
                                    CheckFor = False
                                    GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入盘点数量格式错误", False)
                                    Exit For
                                End If
                                If (CDbl(CheckQuantity) <= 0) Then
                                    rtValue = False
                                    CheckFor = False
                                    GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入盘点数量不能小于0", False)
                                    Exit For
                                End If
                            End If

                            If (Not String.IsNullOrEmpty(strProfitQuantity)) Then
                                If Not IsNumeric(strProfitQuantity) Then
                                    rtValue = False
                                    CheckFor = False
                                    GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入盘盈数量格式错误", False)
                                    Exit For
                                End If
                                If (CDbl(strProfitQuantity) < 0) Then
                                    rtValue = False
                                    CheckFor = False
                                    GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入盘盈数量不能小于0", False)
                                    Exit For
                                End If
                            Else
                                strProfitQuantity = "0"
                            End If

                            If (Not String.IsNullOrEmpty(strLossQuantity)) Then
                                If Not IsNumeric(strLossQuantity) Then
                                    rtValue = False
                                    CheckFor = False
                                    GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入盘亏数量格式错误", False)
                                    Exit For
                                End If
                                If (CDbl(strLossQuantity) < 0) Then
                                    rtValue = False
                                    CheckFor = False
                                    GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入盘亏数量不能小于0", False)
                                    Exit For
                                End If
                            Else
                                strLossQuantity = "0"
                            End If

                            If (CInt(strProfitQuantity) <= 0 And CInt(strLossQuantity) <= 0) Then
                                rtValue = False
                                CheckFor = False
                                GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行输入盘盈亏数量不能同时小于非零", False)
                                Exit For
                            End If
                        End If
                    Next
                    If (SelectMaterialNO) Then
                        If (CheckFor) Then
                            rtValue = True
                        End If
                    Else
                        GetMesData.SetMessage(Me.lblMessage, "请选择盘点物料", False)
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
        If Me.dgvInventroyCheckingItem.RowCount <= 0 Then Return
        For i As Integer = 0 To Me.dgvInventroyCheckingItem.RowCount - 1
            If (String.IsNullOrEmpty(Me.dgvInventroyCheckingItem.Rows(i).Cells("TransactionType").Value) Or Me.dgvInventroyCheckingItem.Rows(i).Cells("TransactionType").Value = "1") Then
                Me.dgvInventroyCheckingItem.Rows(i).Cells("CheckQuantity").ReadOnly = True                               '设置行只读 
                Me.dgvInventroyCheckingItem.Rows(i).Cells("CheckQuantity").Style.BackColor = Color.Lavender             '背景设置灰色只读  
            End If
        Next
    End Sub
#End Region

End Class