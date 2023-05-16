
'--成品退货重工维护
'--Create by :　马锋
'--Create date :　2015/11/17
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

Public Class FrmReworkMaster

#Region "变量声明"

    Dim _strSavaType As String              '保存类型，暂取消
    Shared _strTransactionId As String
    Shared _MaterialList As DataTable
    Shared _BarCodeList As DataTable
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
                _MaterialList.Columns.Add("QUANTITY", Type.GetType("System.String"))
                _MaterialList.Columns.Add("TotalAmount", Type.GetType("System.String"))
                _MaterialList.Columns.Add("PackingSame", Type.GetType("System.String"))
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

    Public Sub New(ByVal _TransactionId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        TransactionId = _TransactionId
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmReworkMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvReworkItem.AutoGenerateColumns = False
            MaterialList.Rows.Clear()
            '基础数据加载
            LoadControlData()
            ScanTransactionId = ""
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub btnSelectmaterial_Click(sender As Object, e As EventArgs) Handles btnSelectmaterial.Click
        Try
            Dim frmMaterial As New FrmMaterialQuery(MaterialList, "1")
            frmMaterial.ShowDialog()
            If (MaterialList.Rows.Count > 0) Then
                Me.dgvReworkItem.DataSource = MaterialList
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

        If Me.dgvReworkItem.Rows.Count = 0 OrElse Me.dgvReworkItem.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要删除行", False)
            Exit Sub
        End If
        Try
            Dim strMaterialNO As String
            Dim strTransactionType As String

            strMaterialNO = Me.dgvReworkItem.Rows(Me.dgvReworkItem.CurrentRow.Index).Cells("MATERIALNO").Value.ToString
            strTransactionType = Me.dgvReworkItem.Rows(Me.dgvReworkItem.CurrentRow.Index).Cells("TransactionType").Value.ToString

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

                Me.dgvReworkItem.Update()
            Else
                If (Not CheckDelete()) Then
                    Exit Sub
                End If

                Dim strSQL As New StringBuilder
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
                Try
                    strSQL.AppendLine("DECLARE @QUANTITY FLOAT ")
                    strSQL.AppendLine("SELECT @QUANTITY=ISNULL(Quantity,0) FROM m_FinishedProductItem_t WHERE TransactionId = '" & TransactionId & "' AND MATERIAL_NO='" & strMaterialNO & "' ")
                    strSQL.AppendLine("UPDATE W_MATERIALS SET QUANTITY= QUANTITY - @QUANTITY WHERE MATERIAL_NO='" & strMaterialNO & "' ")
                    strSQL.AppendLine("IF EXISTS(SELECT TransactionId FROM m_FinishedProductItem_t WHERE TransactionId = '" & TransactionId & "' AND MATERIAL_NO='" & strMaterialNO & "' AND TransactionType='0' ")
                    strSQL.AppendLine("BEGIN UPDATE m_FinishedProductItem_t SET DeleteFlag='1' WHERE TransactionId = '" & TransactionId & "' AND MATERIAL_NO='" & strMaterialNO & "' END ELSE BEGIN ")
                    strSQL.AppendLine("UPDATE m_FinishedProductItem_t SET DeleteFlag='1' WHERE TransactionId = '" & TransactionId & "' AND MATERIAL_NO='" & strMaterialNO & "' ")
                    strSQL.AppendLine("UPDATE W_REELS_T SET DeleteFlag='1' WHERE RECEIVENO = '" & TransactionId & "' AND MATERIAL_NO='" & strMaterialNO & "' END")

                    Conn.ExecSql(strSQL.ToString)
                    Conn.PubConnection.Close()

                    Me.dgvReworkItem.DataSource = GetMesData.GetInvoiceTransactionItem(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)
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
            Dim strScanTypeName As String

            If (String.IsNullOrEmpty(TransactionId)) Then
                If (String.IsNullOrEmpty(ScanTransactionId)) Then
                    ScanTransactionId = GetMesData.GetScanBarcodeId()
                End If

                strTransactionId = ScanTransactionId
                strScanType = "0"
            Else
                strTransactionId = TransactionId
                strScanType = "2"
            End If
            Dim strMaterialNo As String = ""

            If (Me.cboTransactionType.SelectedValue = "1") Then
                strScanTypeName = "退货扫描"
            Else
                strScanTypeName = "重工扫描"
            End If

            If Not Me.dgvReworkItem.CurrentRow Is Nothing Then
                strMaterialNo = Me.dgvReworkItem.Rows(Me.dgvReworkItem.CurrentRow.Index).Cells("MATERIALNO").Value
            End If

            Dim frmBarcode As New FrmReworkBarCode(strTransactionId, StatusFlag, strScanType, Me.cboTransactionType.SelectedValue.ToString, strMaterialNo, MaterialList, strScanTypeName)
            frmBarcode.ShowDialog()

            If (MaterialList.Rows.Count > 0) Then
                Me.dgvReworkItem.DataSource = MaterialList
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
                Me.dgvReworkItem.DataSource = MaterialList
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
                strSQL.AppendLine(" SELECT @InvoicePrefix = InvoicePrefix FROM m_InvoiceDefinitions_t WHERE InvoiceDefinitionsID='11' ")
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
                strSQL.AppendLine(" IF(ISNULL(@StatusFlag, 'N')='N') BEGIN SET @StatusFlag = '1' End ")
                strSQL.AppendLine(" ELSE BEGIN SET @StatusFlag = '0' End ")

                '单头
                strSQL.AppendLine(" INSERT INTO m_Rework_t(FactoryId, Profitcenter, TransactionType, TransactionId, DeptId, DeptName, TotalAmount, DeliveryName, AttentionName, OrderNumber, ")
                strSQL.AppendLine(" Remark, StatusFlag, DeleteFlag, CreateTime, CreateUser) ")
                strSQL.AppendLine(" VALUES( '" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','" & Me.cboTransactionType.SelectedValue.ToString & "', @TransactionID, N'" & Me.cboDept.SelectedValue & "', N'" & Me.cboDept.Text.Trim.Replace("'", "''") & "', ")
                strSQL.AppendLine(" 0, N'" & Me.mtxtDelivery.Text.Trim & "', N'" & Me.mtxtAttentionName.Text.Trim & "','" & Me.mtxtOrderNumber.Text.Trim & "', N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "',")
                strSQL.AppendLine(" @StatusFlag, 0, GETDATE(), @UserID) ")

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
                Dim strPackingSame As String
                Dim ScanBarcode As Boolean = False
                Dim strOrderNumber As String

                For I As Int16 = 0 To Me.dgvReworkItem.Rows.Count - 1
                    strMaterialNO = IIf(IsDBNull(Me.dgvReworkItem.Rows(I).Cells("MATERIALNO").Value), "", Me.dgvReworkItem.Rows(I).Cells("MATERIALNO").Value.ToString())
                    strDescription = IIf(IsDBNull(Me.dgvReworkItem.Rows(I).Cells("DESCRIPTION").Value), "", Me.dgvReworkItem.Rows(I).Cells("DESCRIPTION").Value.ToString())
                    strSpecification = IIf(IsDBNull(Me.dgvReworkItem.Rows(I).Cells("SPECIFICATION").Value), "", Me.dgvReworkItem.Rows(I).Cells("SPECIFICATION").Value.ToString())
                    strUint = IIf(IsDBNull(Me.dgvReworkItem.Rows(I).Cells("UOM_NAME").Value), "", Me.dgvReworkItem.Rows(I).Cells("UOM_NAME").Value.ToString())
                    strQuantity = IIf(IsDBNull(Me.dgvReworkItem.Rows(I).Cells("QUANTITY").Value), "0", Me.dgvReworkItem.Rows(I).Cells("QUANTITY").Value.ToString())
                    strUnitPrice = IIf(IsDBNull(Me.dgvReworkItem.Rows(I).Cells("UNITPRICE").Value), "", Me.dgvReworkItem.Rows(I).Cells("UNITPRICE").Value.ToString())
                    strTotalAmount = IIf(IsDBNull(Me.dgvReworkItem.Rows(I).Cells("TotalAmount").Value), "0", Me.dgvReworkItem.Rows(I).Cells("TotalAmount").Value.ToString())
                    strRemark = IIf(IsDBNull(Me.dgvReworkItem.Rows(I).Cells("REMARK").Value), "", Me.dgvReworkItem.Rows(I).Cells("REMARK").Value.ToString())
                    strTransactionType = IIf(IsDBNull(Me.dgvReworkItem.Rows(I).Cells("TransactionType").Value), "", Me.dgvReworkItem.Rows(I).Cells("TransactionType").Value.ToString())
                    strPackingSame = IIf(IsDBNull(Me.dgvReworkItem.Rows(I).Cells("PackingSame").Value), "0", Me.dgvReworkItem.Rows(I).Cells("PackingSame").Value.ToString())
                    strOrderNumber = IIf(IsDBNull(Me.dgvReworkItem.Rows(I).Cells("OrderNumber").Value), "", Me.dgvReworkItem.Rows(I).Cells("OrderNumber").Value.ToString())

                    If (String.IsNullOrEmpty(strTransactionType)) Then
                        strTransactionType = "0"
                    End If

                    If (strTransactionType = "1") Then
                        ScanBarcode = True
                    End If
                    strSQL.AppendLine(" INSERT INTO m_ReworkItem_t(TransactionId, MaterialNO, Description, Specification, Uint, Quantity, UnitPrice, totalAmount, OrderNumber, ")
                    strSQL.AppendLine(" TransactionType, Remark, DeleteFlag, CreateUser, CreateTime, WarehouseLocationId, PackingSame) ")
                    strSQL.AppendLine(" VALUES( @TransactionID, '" & strMaterialNO & "', N'" & strDescription.Replace("'", "''") & "', N'" & strSpecification.Replace("'", "''") & "', N'" & strUint & "', '" & strQuantity & "', '" & strUnitPrice & "', '" & strTotalAmount & "', '" & strOrderNumber & "',")
                    strSQL.AppendLine("  '" & strTransactionType & "', N'" & strRemark & "', 0, @UserID, GETDATE(), NULL, '" & strPackingSame & "') ")

                    '更新库存数量（重工才执行) '1-退货扫描，2-重工扫描
                    If (Me.cboTransactionType.SelectedValue = "2") Then
                        strSQL.AppendLine(" IF(ISNULL(@StatusFlag,'1')='1') BEGIN  ")
                        strSQL.AppendLine(" UPDATE W_MATERIALS SET QUANTITY = QUANTITY - " & strQuantity & " WHERE MATERIAL_NO='" & strMaterialNO & "' End ")
                    End If
                Next

                If (ScanBarcode) Then

                    '删除条码记录 ProductType: 0产品,1箱
                    strSQL.AppendLine(" INSERT INTO W_REELSREWORK_T SELECT W_REELS_T.*, '" & VbCommClass.VbCommClass.UseId & "', getdate() FROM W_REELS_T INNER JOIN m_ScanBacodeTransaction_t ON W_REELS_T.REEL_BARCODE=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='1' ")
                    strSQL.AppendLine(" DELETE W_REELS_T FROM m_ScanBacodeTransaction_t ")
                    strSQL.AppendLine(" WHERE W_REELS_T.REEL_BARCODE =m_ScanBacodeTransaction_t.BarCode AND ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='1' ")

                    '更新Sbarcode状态
                    strSQL.AppendLine(" UPDATE m_SnSBarCode_t SET UseY='Y' FROM m_Cartonsn_t INNER JOIN m_ScanBacodeTransaction_t ON m_Cartonsn_t.Cartonid=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE m_SnSBarCode_t.SBarCode=m_Cartonsn_t.ppid AND ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='1' ")

                    strSQL.AppendLine(" UPDATE m_SnSBarCode_t SET UseY='Y' FROM m_Cartonsn_t INNER JOIN m_ScanBacodeTransaction_t ON m_Cartonsn_t.PPID=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE m_SnSBarCode_t.SBarCode=m_ScanBacodeTransaction_t.BarCode AND ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' ")   ' AND m_ScanBacodeTransaction_t.ProductType='0'

                    '删除包装箱记录
                    strSQL.AppendLine(" INSERT INTO m_CartonDelete_t SELECT m_Carton_t.*, '" & VbCommClass.VbCommClass.UseId & "', getdate() FROM m_Carton_t INNER JOIN m_ScanBacodeTransaction_t ON m_Carton_t.CartonId=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='1' ")

                    strSQL.AppendLine(" INSERT INTO m_CartonSNDelete_t SELECT m_Cartonsn_t.*, '" & VbCommClass.VbCommClass.UseId & "', getdate() FROM m_Cartonsn_t INNER JOIN m_ScanBacodeTransaction_t ON m_Cartonsn_t.CartonId=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='1' ")

                    strSQL.AppendLine(" INSERT INTO m_AssySNDelete_t SELECT m_Assysn_t.*, '" & VbCommClass.VbCommClass.UseId & "', getdate() FROM m_Assysn_t INNER JOIN m_Cartonsn_t ON m_Assysn_t.Ppid=m_Cartonsn_t.ppid ")
                    strSQL.AppendLine(" INNER JOIN m_ScanBacodeTransaction_t ON m_Cartonsn_t.CartonId=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='1' ")

                    strSQL.AppendLine(" INSERT INTO m_AssySNDDelete_t SELECT m_AssysnD_t.*, '" & VbCommClass.VbCommClass.UseId & "', getdate() FROM m_AssysnD_t INNER JOIN m_Cartonsn_t ON m_AssysnD_t.Ppid=m_Cartonsn_t.ppid ")
                    strSQL.AppendLine(" INNER JOIN m_ScanBacodeTransaction_t ON m_Cartonsn_t.CartonId=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='1' ")

                    strSQL.AppendLine(" INSERT INTO m_PpidlinkDelete_t SELECT m_Ppidlink_t.*, '" & VbCommClass.VbCommClass.UseId & "', getdate() FROM m_Ppidlink_t INNER JOIN m_Cartonsn_t ON m_Ppidlink_t.Ppid=m_Cartonsn_t.ppid ")
                    strSQL.AppendLine(" INNER JOIN m_ScanBacodeTransaction_t ON m_Cartonsn_t.CartonId=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='1' ")

                    strSQL.AppendLine(" DELETE m_Assysn_t FROM m_Cartonsn_t ")
                    strSQL.AppendLine(" INNER JOIN m_ScanBacodeTransaction_t ON m_Cartonsn_t.CartonId=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE m_Assysn_t.Ppid=m_Cartonsn_t.ppid AND ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='1' ")

                    strSQL.AppendLine(" DELETE m_AssysnD_t FROM m_Cartonsn_t ")
                    strSQL.AppendLine(" INNER JOIN m_ScanBacodeTransaction_t ON m_Cartonsn_t.CartonId=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE  m_AssysnD_t.Ppid=m_Cartonsn_t.ppid AND ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='1' ")

                    strSQL.AppendLine(" DELETE m_Ppidlink_t FROM m_Cartonsn_t ")
                    strSQL.AppendLine(" INNER JOIN m_ScanBacodeTransaction_t ON m_Cartonsn_t.CartonId=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE m_Ppidlink_t.Ppid=m_Cartonsn_t.ppid AND ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='1' ")

                    '删除包装产品记录
                    strSQL.AppendLine(" INSERT INTO m_CartonSNDelete_t SELECT m_Cartonsn_t.*, '" & VbCommClass.VbCommClass.UseId & "', getdate() FROM m_Cartonsn_t INNER JOIN m_ScanBacodeTransaction_t ON m_Cartonsn_t.PPID=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='0' ")

                    '更新包装产品箱/库存条码数量
                    strSQL.AppendLine(" UPDATE m_Carton_t SET PackingQuantity=PackingQuantity-m_ScanBacodeTransaction_t.Quantity FROM m_Cartonsn_t ")
                    strSQL.AppendLine(" INNER JOIN m_ScanBacodeTransaction_t ON m_Cartonsn_t.PPID=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE m_Carton_t.CartonId=m_Cartonsn_t.CartonId AND ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='0' ")

                    strSQL.AppendLine(" UPDATE W_REELS_T SET REMAINING_QUANTITY = REMAINING_QUANTITY - m_ScanBacodeTransaction_t.Quantity ")
                    strSQL.AppendLine(" FROM m_Cartonsn_t INNER JOIN m_ScanBacodeTransaction_t ON m_Cartonsn_t.PPID=m_ScanBacodeTransaction_t.BarCode ")
                    strSQL.AppendLine(" WHERE W_REELS_T.REEL_BARCODE=m_Cartonsn_t.CartonId AND ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='1' AND m_ScanBacodeTransaction_t.ProductType='0'  ")

                    strSQL.AppendLine(" DELETE m_Carton_t FROM m_ScanBacodeTransaction_t ")
                    strSQL.AppendLine(" WHERE m_Carton_t.CartonId =m_ScanBacodeTransaction_t.BarCode AND ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='1' ")

                    strSQL.AppendLine(" DELETE m_Cartonsn_t FROM m_ScanBacodeTransaction_t ")
                    strSQL.AppendLine(" WHERE m_Cartonsn_t.CartonId =m_ScanBacodeTransaction_t.BarCode AND ScanBarcodeTransactionId='" & ScanTransactionId & "' AND m_ScanBacodeTransaction_t.DeleteFlag='0' AND m_ScanBacodeTransaction_t.PackingSame='0' AND m_ScanBacodeTransaction_t.ProductType='1' ")

                    strSQL.AppendLine(" UPDATE m_ScanBacodeTransaction_t SET StatusFlag='1', TransactionId = @TransactionId WHERE ScanBarcodeTransactionId='" & ScanTransactionId & "' AND DeleteFlag='0' AND StatusFlag='0' ")
                End If
            Else
                '编辑
                strSQL.AppendLine(" UPDATE m_Rework_t SET ")
                strSQL.AppendLine(" DeliveryId='" & Me.mtxtDelivery.Text.Trim & "',AttentionName='" & Me.mtxtAttentionName.Text.Trim & "',OrderNumber='" & Me.mtxtOrderNumber.Text.Trim & "', Remark=N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "',UpdateUser='" & VbCommClass.VbCommClass.UseId & "', UpdateTime=Getdate() ")
                strSQL.AppendLine(" WHERE TransactionId='" & TransactionId & "' ")
            End If

            If Not (String.IsNullOrEmpty(strSQL.ToString)) Then
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

    Private Sub txtERPTranscationID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If (e.KeyCode = Keys.Enter) Then
                'If (String.IsNullOrEmpty(Me.txtERPTranscationID.Text.Trim())) Then
                '    GetMesData.SetMessage(Me.lblMessage, "请输入下载单号", False)
                '    Exit Sub
                'End If

                'Dim TiptopConn As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
                'Dim dvTiptopFinishedProduct As DataView
                'dvTiptopFinishedProduct = GetTiptopDate.GetFinishedProduct(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, Me.txtERPTranscationID.Text.Trim)
                ''获取Tiptop入库单信息 OGB04, OGB12, IMA02, IMA021, IMA25
                'If Not dvTiptopFinishedProduct Is Nothing Then
                '    If dvTiptopFinishedProduct.Count > 0 Then
                '        If (MaterialList.Rows.Count > 0) Then
                '            MaterialList.Rows.Clear()
                '        End If

                '        For i As Int16 = 0 To dvTiptopFinishedProduct.Count - 1

                '            Dim drTemp As DataRow
                '            drTemp = MaterialList.NewRow
                '            drTemp("MATERIALNO") = dvTiptopFinishedProduct.Item(i).Item("OGB04").ToString
                '            drTemp("DESCRIPTION") = dvTiptopFinishedProduct.Item(i).Item("IMA02").ToString
                '            drTemp("SPECIFICATION") = dvTiptopFinishedProduct.Item(i).Item("IMA021").ToString
                '            drTemp("UOM_NAME") = dvTiptopFinishedProduct.Item(i).Item("IMA25").ToString
                '            drTemp("STOCKQUANTITY") = "0"
                '            drTemp("UNITPRICE") = "0"
                '            drTemp("QUANTITY") = "0"
                '            drTemp("PlanQuantity") = dvTiptopFinishedProduct.Item(i).Item("OGB12").ToString
                '            drTemp("TransactionType") = ""
                '            MaterialList.Rows.Add(drTemp)
                '            MaterialList.AcceptChanges()
                '        Next
                '    End If
                '    Me.dgvFinishedProductItem.DataSource = MaterialList
                'Else
                '    GetMesData.SetMessage(Me.lblMessage, "单号不存在", False)
                'End If
            End If
        Catch
            GetMesData.SetMessage(Me.lblMessage, "下载异常", False)
        End Try
    End Sub

    Private Sub cboTransactionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTransactionType.SelectedIndexChanged
        Try
            MaterialList.Rows.Clear()
            Me.mtxtOrderNumber.Text = ""
            ScanTransactionId = ""
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更改类型异常!", False)
        End Try
    End Sub

    Private Sub mtxtOrderNumber_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtOrderNumber.ButtonCustomClick
        Try
            Dim finishedProductQuery As New FrmFinishedProductQuery(Me.mtxtOrderNumber, Me.cboTransactionType.SelectedValue.ToString)
            finishedProductQuery.ShowDialog()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub mtxtOrderNumber_TextChanged(sender As Object, e As EventArgs) Handles mtxtOrderNumber.TextChanged

        If (String.IsNullOrEmpty(Me.mtxtOrderNumber.Text.Trim)) Then
            Exit Sub
        End If

        If (Not CheckOrderNumber(Me.mtxtOrderNumber.Text.Trim)) Then
            Me.mtxtOrderNumber.Text = ""
            Exit Sub
        End If

        Dim strTransactionId As String

        If (String.IsNullOrEmpty(TransactionId)) Then
            If (String.IsNullOrEmpty(ScanTransactionId)) Then
                ScanTransactionId = GetMesData.GetScanBarcodeId()
            End If

            strTransactionId = ScanTransactionId
        Else
            strTransactionId = TransactionId
        End If

        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try

            strSQL.AppendLine(" DECLARE @TransactionId VARCHAR(64), @ScanBarcodeTransactionId VARCHAR(64), @UserID NVARCHAR(32) ")
            strSQL.AppendLine(" SET @TransactionId='" & Me.mtxtOrderNumber.Text.Trim & "' SET @ScanBarcodeTransactionId='" & ScanTransactionId & "' SET @UserID='" & VbCommClass.VbCommClass.UseId & "' ")
            'strSQL.AppendLine(" SELECT ScanBarcodeId FROM m_ScanBacodeTransaction_t WHERE TransactionId=@TransactionId AND ReworkFlag='0' ")
            strSQL.AppendLine(" INSERT INTO m_ScanBacodeTransaction_t(ScanBarcodeTransactionId, TransactionId, BarCode, MaterialNO, Description, Specification, Uint, Quantity, VenderId, ")
            strSQL.AppendLine(" DateCode, Versions, HistoryWarehouseId, HistoryWarehouseLocationId, ReworkTransactionId, PackingSame, ")
            strSQL.AppendLine(" DeleteFlag, StatusFlag, ReworkFlag, ProductType, PackingCartonId, CreateUser, CreateTime) ")
            strSQL.AppendLine(" SELECT @ScanBarcodeTransactionId, NULL, BarCode, MaterialNO, Description, Specification, Uint, Quantity, VenderId, ")
            strSQL.AppendLine(" DateCode, Versions, HistoryWarehouseId, HistoryWarehouseLocationId, NULL, PackingSame, ")
            strSQL.AppendLine(" '0', '0', '0', ProductType, PackingCartonId, @UserID, GETDATE() ")
            strSQL.AppendLine(" FROM m_ScanBacodeTransaction_t WHERE TransactionId=@TransactionId AND ReworkFlag='0' ")
            strSQL.AppendLine(" SELECT '0' AS ItemId ,'1' AS TransactionType, MaterialNO, Description, Specification, Uint AS UOM_NAME, SUM(ISNULL(Quantity,0)) AS Quantity, '0' AS STOCKQUANTITY, '0' AS UNITPRICE, ")
            strSQL.AppendLine(" '' AS WAREHOUSEID, '' AS WAREHOUSELOCATIONID, '0' AS TotalAmount, '0' AS PackingSame, '' AS REMARK, '' AS OrderNumber ")
            strSQL.AppendLine(" FROM m_ScanBacodeTransaction_t WHERE TransactionId=@TransactionId AND ReworkFlag='0' GROUP BY  MaterialNO, Description, Specification, Uint ")

            MaterialList = Conn.GetDataTable(strSQL.ToString)

            If (Not MaterialList Is Nothing) Then
                If (MaterialList.Rows.Count > 0) Then
                    Me.dgvReworkItem.DataSource = MaterialList
                End If
            End If

            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            MaterialList.Rows.Clear()
            GetMesData.SetMessage(Me.lblMessage, "生成成品出货退货重工异常", False)
            Me.mtxtOrderNumber.Text = ""
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

            Me.cboTransactionType.DisplayMember = "PARAMETER_NAME"
            Me.cboTransactionType.ValueMember = "PARAMETER_VALUE"
            Me.cboTransactionType.DataSource = Conn.GetDataTable(GetMesData.GetSettingParameterSQL("ReworkTransactionType"))
            Conn.PubConnection.Close()

            Me.cboDept.DisplayMember = "DeptName"
            Me.cboDept.ValueMember = "DeptCode"
            Me.cboDept.DataSource = GetMesData.GetDeptList(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "")

            If (String.IsNullOrEmpty(_strTransactionId)) Then

                Me.dgvReworkItem.Rows.Add(7)
                Me.dtpInvoiceDate.Value = Now
                Me.txtTransactionId.Text = "<自动编号>"
            Else
                Dim dtInvoice As DataTable
                dtInvoice = GetMesData.GetInvoiceTransaction(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)

                If (Not dtInvoice Is Nothing And dtInvoice.Rows.Count > 0) Then
                    Me.dtpInvoiceDate.Text = dtInvoice.Rows(0).Item("CreateTime").ToString
                    Me.txtTransactionId.Text = dtInvoice.Rows(0).Item("TransactionId").ToString
                    Me.mtxtOrderNumber.Text = dtInvoice.Rows(0).Item("OrderNumber").ToString
                    Me.mtxtAttentionName.Text = dtInvoice.Rows(0).Item("AttentionName").ToString
                    Me.cboDept.SelectedIndex = Me.cboDept.FindString(dtInvoice.Rows(0).Item("DeptId").ToString)
                    Me.mtxtDelivery.Text = dtInvoice.Rows(0).Item("DeliveryName").ToString
                    Me.txtRemark.Text = dtInvoice.Rows(0).Item("Remark").ToString

                    StatusFlag = dtInvoice.Rows(0).Item("StatusFlag").ToString

                    'If (dtInvoice.Rows(0).Item("TransactionType").ToString = "1") Then
                    '    BarCodeList = GetMesData.GetTransactionBarCode(TransactionId, "")
                    'End If
                End If

                Dim dtInvoiceItem As DataTable
                dtInvoiceItem = GetMesData.GetInvoiceTransactionItem(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)

                If (Not dtInvoiceItem Is Nothing And dtInvoiceItem.Rows.Count > 0) Then
                    Me.dgvReworkItem.DataSource = dtInvoiceItem
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
            If (String.IsNullOrEmpty(mtxtAttentionName.Text.Trim())) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择经办人", False)
                Exit Function
            End If

            If (String.IsNullOrEmpty(cboDept.SelectedValue)) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择部门", False)
                Exit Function
            End If

            If (String.IsNullOrEmpty(mtxtDelivery.Text.Trim())) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "请选择交货人", False)
                Exit Function
            End If

            If (Me.dgvReworkItem.Rows.Count <= 0) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
            Else
                Dim Qty As String
                Dim strMaterialNO As String
                Dim SelectMaterialNO As Boolean = False
                Dim CheckFor As Boolean = True
                For i As Int16 = 0 To Me.dgvReworkItem.Rows.Count - 1
                    strMaterialNO = IIf(IsDBNull(Me.dgvReworkItem.Rows(i).Cells("MaterialNO").Value), "", Me.dgvReworkItem.Rows(i).Cells("MaterialNO").Value)
                    Qty = IIf(IsDBNull(Me.dgvReworkItem.Rows(i).Cells("QUANTITY").Value), "", Me.dgvReworkItem.Rows(i).Cells("QUANTITY").Value)
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
                    End If
                Next
                If (SelectMaterialNO) Then
                    If (CheckFor) Then
                        rtValue = True
                    End If
                Else
                    GetMesData.SetMessage(Me.lblMessage, "请选择出库物料", False)
                    rtValue = False
                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

    Private Sub InitDataGrid_afterBindData()
        If Me.dgvReworkItem.RowCount <= 0 Then Return
        For i As Integer = 0 To Me.dgvReworkItem.RowCount - 1
            If (String.IsNullOrEmpty(Me.dgvReworkItem.Rows(i).Cells("TransactionType").Value) Or Me.dgvReworkItem.Rows(i).Cells("TransactionType").Value = "1") Then
                Me.dgvReworkItem.Rows(i).Cells("QUANTITY").ReadOnly = True                               '设置行只读  
                Me.dgvReworkItem.Rows(i).Cells("QUANTITY").Style.BackColor = Color.Lavender              '背景设置灰色只读  
            Else
                Me.dgvReworkItem.Rows(i).Cells("QUANTITY").ReadOnly = False                               '设置行只读  
                Me.dgvReworkItem.Rows(i).Cells("QUANTITY").Style.BackColor = Color.White              '背景设置灰色只读
            End If
        Next
    End Sub

    Private Function CheckOrderNumber(ByVal strOrderNumber As String) As Boolean
        Dim rtValue As Boolean = False
        Dim strSQL As New StringBuilder
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DrRead As SqlClient.SqlDataReader
        Try
            strSQL.AppendLine(" DECLARE @rtValue NVARCHAR(1),@rtMsg NVARCHAR(64), @TransactionId VARCHAR(64) ")
            strSQL.AppendLine(" SET @rtValue='1' SET @rtMsg='' SET @TransactionId='" & strOrderNumber & "' ")
            strSQL.AppendLine(" IF NOT EXISTS(SELECT TransactionId FROM m_FinishedProduct_t WHERE TransactionId=  @TransactionId AND FinishedProductType='1' AND DeleteFlag='0') ")
            strSQL.AppendLine(" BEGIN SET @rtValue='0' SET @rtMsg=N'成品出库单号不存在!' End Else BEGIN ")
            strSQL.AppendLine(" IF EXISTS(SELECT TransactionId FROM m_Rework_t WHERE OrderNumber=@TransactionId AND DeleteFlag='0') ")
            strSQL.AppendLine(" BEGIN SET @rtValue='0' SET @rtMsg=N'成品出库单号已经做退货重工!' End ")
            strSQL.AppendLine(" IF NOT EXISTS(SELECT ScanBarcodeId FROM m_ScanBacodeTransaction_t WHERE TransactionId=@TransactionId AND ReworkFlag='0') ")
            strSQL.AppendLine(" BEGIN SET @rtValue='0' SET @rtMsg=N'成品出库单号已经全部退货重工!' End End ")
            strSQL.AppendLine(" SELECT @rtValue, @rtMsg ")

            DrRead = Conn.GetDataReader(strSQL.ToString)

            If DrRead.HasRows Then
                DrRead.Read()
                If DrRead(0).ToString() = "0" Then
                    GetMesData.SetMessage(Me.lblMessage, DrRead(1).ToString(), False)
                    Return False
                Else
                    Return True
                End If
            End If

            DrRead.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (DrRead.IsClosed = False) Then
                DrRead.Close()
            End If
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            rtValue = False
            GetMesData.SetMessage(Me.lblMessage, "检查订单信息异常!", False)
        End Try
        Return rtValue
    End Function

#End Region

End Class