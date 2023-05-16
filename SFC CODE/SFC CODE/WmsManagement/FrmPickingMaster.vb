
'--捡料生成
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

Public Class FrmPickingMaster

#Region "变量声明"

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

    Private Sub FrmPickingMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvPickingItem.AutoGenerateColumns = False
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
                Me.dgvPickingItem.DataSource = MaterialList
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
                Me.dgvPickingItem.DataSource = MaterialList
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
                strSQL.AppendLine(" SELECT @InvoicePrefix = InvoicePrefix FROM m_InvoiceDefinitions_t WHERE InvoiceDefinitionsID='" & "" & "' ")
                strSQL.AppendLine(" SELECT @RuleDateTime = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'RuleDateTime' ")
                strSQL.AppendLine(" SELECT @RuleCode = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'RuleCode' ")
                strSQL.AppendLine(" SELECT @StatusFlag = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'InventoryChecking' ")
                strSQL.AppendLine(" SET @DateCode = FORMAT(GETDATE(), @RuleDateTime) ")
                strSQL.AppendLine(" SELECT @CurrentCount = ISNULL(CurrentCount, 0) FROM m_InvoiceDefinitionsCode_t WHERE DateCode = @DateCode AND InvoicePrefix = @InvoicePrefix ")
                strSQL.AppendLine(" IF (ISNULL(@CurrentCount, 0) = 0) BEGIN ")
                strSQL.AppendLine(" SET @CurrentCount = 1 ")
                strSQL.AppendLine(" SET @CodeFormatDefinitions = @InvoicePrefix + @RuleDateTime + @RuleCode ")
                strSQL.AppendLine(" INSERT INTO m_InvoiceDefinitionsCode_t(InvoicePrefix, CurrentCount, DateCode, CodeFormatDefinitions, CreateUser, CreateTime) VALUES(@InvoicePrefix, @CurrentCount, @DateCode, @CodeFormatDefinitions, @UserID, GETDATE()) End ")
                strSQL.AppendLine(" SET @TransactionID = @InvoicePrefix + @DateCode + RIGHT(@RuleCode + ltrim(@CurrentCount), LEN(@RuleCode))  ")
                strSQL.AppendLine(" IF(ISNULL(@StatusFlag, 'N')='N') BEGIN SET @StatusFlag = '1' End ")
                strSQL.AppendLine(" ELSE BEGIN SET @StatusFlag = '0' End ")
                strSQL.AppendLine(" SELECT @InventoryCheckQuantity = PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='WMS' AND PARAMETER_CODE = 'InventoryCheckQuantity' ")

                '单头
                strSQL.AppendLine(" INSERT INTO m_InventoryChecking_t(FactoryId, Profitcenter, InvoiceTransactionType, TransactionId, WharehouseId, WharehouseName, AttentionName, Remark, StatusFlag, DeleteFlag, CreateTime, CreateUser ")
                strSQL.AppendLine(" )VALUES('" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "', '" & "" & "', @TransactionID,'" & Me.cboWarehouse.SelectedValue & "', N'" & Me.cboWarehouse.SelectedText.Trim & "',")
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

                For I As Int16 = 0 To Me.dgvPickingItem.Rows.Count - 1
                    strMaterialNO = IIf(IsDBNull(Me.dgvPickingItem.Rows(I).Cells("MATERIALNO").Value), "", Me.dgvPickingItem.Rows(I).Cells("MATERIALNO").Value.ToString())
                    strDescription = IIf(IsDBNull(Me.dgvPickingItem.Rows(I).Cells("DESCRIPTION").Value), "", Me.dgvPickingItem.Rows(I).Cells("DESCRIPTION").Value.ToString())
                    strSpecification = IIf(IsDBNull(Me.dgvPickingItem.Rows(I).Cells("SPECIFICATION").Value), "", Me.dgvPickingItem.Rows(I).Cells("SPECIFICATION").Value.ToString())
                    strUint = IIf(IsDBNull(Me.dgvPickingItem.Rows(I).Cells("UOM_NAME").Value), "", Me.dgvPickingItem.Rows(I).Cells("UOM_NAME").Value.ToString())
                    strBookQuantity = IIf(IsDBNull(Me.dgvPickingItem.Rows(I).Cells("BookQuantity").Value), "0", Me.dgvPickingItem.Rows(I).Cells("BookQuantity").Value.ToString())
                    strCheckQuantity = IIf(IsDBNull(Me.dgvPickingItem.Rows(I).Cells("CheckQuantity").Value), "0", Me.dgvPickingItem.Rows(I).Cells("CheckQuantity").Value.ToString())
                    strProfitQuantity = IIf(IsDBNull(Me.dgvPickingItem.Rows(I).Cells("ProfitQuantity").Value), "0", Me.dgvPickingItem.Rows(I).Cells("ProfitQuantity").Value.ToString())
                    strLossQuantity = IIf(IsDBNull(Me.dgvPickingItem.Rows(I).Cells("LossQuantity").Value), "0", Me.dgvPickingItem.Rows(I).Cells("LossQuantity").Value.ToString())
                    strUnitPrice = IIf(IsDBNull(Me.dgvPickingItem.Rows(I).Cells("UNITPRICE").Value), "0", Me.dgvPickingItem.Rows(I).Cells("UNITPRICE").Value.ToString())
                    strTotalAmount = IIf(IsDBNull(Me.dgvPickingItem.Rows(I).Cells("TotalAmount").Value), "0", Me.dgvPickingItem.Rows(I).Cells("TotalAmount").Value.ToString())
                    strRemark = IIf(IsDBNull(Me.dgvPickingItem.Rows(I).Cells("Remark").Value), "", Me.dgvPickingItem.Rows(I).Cells("Remark").Value.ToString())
                    strTransactionType = IIf(IsDBNull(Me.dgvPickingItem.Rows(I).Cells("TransactionType").Value), "", Me.dgvPickingItem.Rows(I).Cells("TransactionType").Value.ToString())
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
                    strSQL.AppendLine(" VALUES( @TransactionID, '" & strMaterialNO & "', N'" & strDescription & "', N'" & strSpecification & "', '" & strUint & "', '" & strBookQuantity & "', '" & strCheckQuantity & "', '" & strQuantity & "',")
                    strSQL.AppendLine(" '" & strUnitPrice & "', '" & strUnitPrice & "', 0, '" & strCheckStatus & "', N'" & strRemark & "', '" & strTransactionType & "', 0, @UserID, GETDATE()) ")
                    strSQL.AppendLine(" IF(ISNULL(@StatusFlag,'1')='1' AND ISNULL(@InventoryCheckQuantity,'N')='Y' ) BEGIN  ")
                    strSQL.AppendLine(" UPDATE W_MATERIALS SET QUANTITY = " & strCheckQuantity & " WHERE MATERIAL_NO='" & strMaterialNO & "' End ")
                Next
            Else
                '编辑
                strSQL.AppendLine(" UPDATE m_InvoiceTransaction_t SET ")
                strSQL.AppendLine(" InvoiceTransactionType ='" & "" & "', WarehouseId='" & Me.cboWarehouse.SelectedValue & "', WarehouseName=N'" & Me.cboWarehouse.SelectedText.Trim & "',")
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


#End Region

#Region "函数"

    Private Sub LoadControlData()
        Dim strSQL As String
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            Me.dtpInvoiceDate.Value = Now

            Me.cboWarehouse.DisplayMember = "WarehouseName"
            Me.cboWarehouse.ValueMember = "WarehouseCode"
            Me.cboWarehouse.DataSource = GetMesData.GetWarehouse(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "")

            If (String.IsNullOrEmpty(_strTransactionId)) Then
                Me.dgvPickingItem.Rows.Add(7)

                Me.cboWarehouse.SelectedIndex = 0
                Me.txtTransactionId.Text = "<自动编号>"
                Me.dtpInvoiceDate.Value = Now
            Else
                Dim dtInvoice As DataTable
                dtInvoice = GetMesData.GetInventoryChecking(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, TransactionId)

                If (Not dtInvoice Is Nothing And dtInvoice.Rows.Count > 0) Then
                    Me.dtpInvoiceDate.Text = dtInvoice.Rows(0).Item("CreateTime").ToString
                    Me.txtTransactionId.Text = dtInvoice.Rows(0).Item("TransactionId").ToString
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
                    Me.dgvPickingItem.DataSource = dtInventoryCheckingItem
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

            If (Me.dgvPickingItem.Rows.Count <= 0) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
            Else
                Dim CheckQuantity As String
                Dim strMaterialNO As String
                Dim SelectMaterialNO As Boolean = False
                Dim strProfitQuantity As String
                Dim strLossQuantity As String
                Dim CheckFor As Boolean = True
                If (IsDBNull(Me.dgvPickingItem.Rows(0).Cells("MaterialNO").Value) Or Me.dgvPickingItem.Rows(0).Cells("MaterialNO").Value Is Nothing) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
                Else
                    For i As Int16 = 0 To Me.dgvPickingItem.Rows.Count - 1
                        strMaterialNO = IIf(IsDBNull(Me.dgvPickingItem.Rows(i).Cells("MaterialNO").Value), "", Me.dgvPickingItem.Rows(i).Cells("MaterialNO").Value)
                        CheckQuantity = IIf(IsDBNull(Me.dgvPickingItem.Rows(i).Cells("CheckQuantity").Value), "", Me.dgvPickingItem.Rows(i).Cells("CheckQuantity").Value)
                        strProfitQuantity = IIf(IsDBNull(Me.dgvPickingItem.Rows(i).Cells("ProfitQuantity").Value), "", Me.dgvPickingItem.Rows(i).Cells("ProfitQuantity").Value)
                        strLossQuantity = IIf(IsDBNull(Me.dgvPickingItem.Rows(i).Cells("LossQuantity").Value), "", Me.dgvPickingItem.Rows(i).Cells("LossQuantity").Value)
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
        If Me.dgvPickingItem.RowCount <= 0 Then Return
        For i As Integer = 0 To Me.dgvPickingItem.RowCount - 1
            If (String.IsNullOrEmpty(Me.dgvPickingItem.Rows(i).Cells("TransactionType").Value) Or Me.dgvPickingItem.Rows(i).Cells("TransactionType").Value = "1") Then
                Me.dgvPickingItem.Rows(i).Cells("CheckQuantity").ReadOnly = True                               '设置行只读 
                Me.dgvPickingItem.Rows(i).Cells("CheckQuantity").Style.BackColor = Color.Lavender             '背景设置灰色只读  
            End If
        Next
    End Sub
#End Region

End Class