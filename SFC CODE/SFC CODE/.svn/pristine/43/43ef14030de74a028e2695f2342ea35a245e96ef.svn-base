
'--仓储成品条码扫描
'--Create by :　马锋
'--Create date :　2015/08/27
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

Public Class FrmFinishedProductBarCode

#Region "变量声明"

    Shared _TransactionId As String
    Shared _StatusFlag As String
    Shared _ScanType As String              '0-入库扫描临时，1-入库扫描实际，2-出库扫描，3-盘点扫描，4-调拨扫描
    Shared _ScanCheckType As String         '0:收料扫描，1：发料审核
    Shared _MaterialNO As String            '选择料号
    Shared _BarCodeList As DataTable
    Shared _MaterialList As DataTable
    Dim strMaterialType As String
    Dim strMaterialNO As String
    Dim strDescription As String
    Dim strSpecification As String
    Dim strUnit As String
    Dim strUnitPrice As String
    Dim strStockQuantity As String
    Dim strVendorCode As String
    Dim strDateCode As String
    Dim strConvertDataCode As String
    Dim strVersions As String
    Dim strQty As Double
    Dim strWarehouseId As String
    Dim strWarehouseLocationId As String
    Dim strPackingCartonId As String

#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal TransactionId As String, ByVal StatusFlag As String, ByVal ScanType As String, ByVal ScanCheckType As String, ByVal MaterialNO As String, ByVal dtMaterialList As DataTable, ByVal ScanTypeName As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _TransactionId = TransactionId
        _StatusFlag = StatusFlag
        '_BarCodeList = dtSelectBarCode
        _MaterialList = dtMaterialList
        _MaterialNO = MaterialNO
        '0-入库扫描临时，1-入库扫描实际，2-出库扫描，3-盘点扫描，4-调拨扫描
        _ScanType = ScanType
        '扫描检查类型: 1->入库扫描, 2->出库扫描，3->调拨
        _ScanCheckType = ScanCheckType
        '扫描类型名称
        Me.Text = ScanTypeName
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmFinishedProductBarCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvBarcode.AutoGenerateColumns = False
            If (_StatusFlag = "1") Then
                Me.btnDelete.Enabled = False
                Me.txtBarCode.Enabled = False
            End If

            _BarCodeList = GetMesData.GetScanBarcode(_TransactionId, _ScanType, _MaterialNO)
            Me.dgvBarcode.DataSource = _BarCodeList

        Catch ex As Exception
            Me.txtBarCode.Enabled = False
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvBarcode.Rows.Count = 0 OrElse Me.dgvBarcode.CurrentRow Is Nothing Then
            GetMesData.SetMessage(Me.lblMessage, "请选择要删除的条码", False)
            Exit Sub
        End If
        Try
            Dim MaterialNO As String
            Dim Quantity As Int16
            Dim strBarCode As String

            If Not (String.IsNullOrEmpty(Me.dgvBarcode.Rows(Me.dgvBarcode.CurrentRow.Index).Cells("BARCODE").Value.ToString())) Then
                MaterialNO = Me.dgvBarcode.Rows(Me.dgvBarcode.CurrentRow.Index).Cells("MATERIAL_NO").Value.ToString.ToUpper()
                strBarCode = Me.dgvBarcode.Rows(Me.dgvBarcode.CurrentRow.Index).Cells("BARCODE").Value.ToString()
                Quantity = Me.dgvBarcode.Rows(Me.dgvBarcode.CurrentRow.Index).Cells("QUANTITY").Value

                If (Not String.IsNullOrEmpty(_TransactionId)) Then
                    Dim strSQL As New StringBuilder
                    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
                    Try
                        'strSQL.AppendLine(" UPDATE W_REELS_T SET DeleteFlag='1' WHERE REEL_BARCODE='" & strBarCode & "' ")
                        'strSQL.AppendLine(" UPDATE W_MATERIALS SET QUANTITY= QUANTITY - " & Quantity & " WHERE MATERIAL_NO='" & strMaterialNO & "' ")
                        'strSQL.AppendLine(" UPDATE m_InvoiceTransactionItem_t SET QUANTITY= QUANTITY - " & Quantity & " WHERE InvoiceTransactionId = '" & _TransactionId & "' AND MATERIALNO='" & strMaterialNO & "' ")
                        strSQL.AppendLine(" UPDATE m_ScanBacodeTransaction_t SET DeleteFlag='1' WHERE BarCode='" & strBarCode & "' AND ScanBarcodeTransactionId='" & _TransactionId & "' ")
                        Conn.ExecSql(strSQL.ToString())
                        Conn.PubConnection.Close()
                    Catch ex As Exception
                        If (Conn.PubConnection.State = ConnectionState.Open) Then
                            Conn.PubConnection.Close()
                        End If
                        GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
                        Exit Sub
                    End Try
                End If

                _BarCodeList.Rows.RemoveAt(Me.dgvBarcode.CurrentRow.Index)
            End If

            For i As Int16 = 0 To _MaterialList.Rows.Count - 1
                If (_MaterialList.Rows(i).Item("MATERIALNO").ToString.ToUpper = MaterialNO) Then
                    _MaterialList.Rows(i).Item("QUANTITY") = _MaterialList.Rows(i).Item("QUANTITY") - Quantity
                    Exit For
                End If
            Next
            Me.dgvBarcode.Update()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub btnDefine_Click(sender As Object, e As EventArgs) Handles btnDefine.Click
        Try
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "确定异常", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            '_BarCodeList.Rows.Clear()
            '_MaterialList.Rows.Clear()
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "取消异常", False)
        End Try
    End Sub

    Private Sub txtBarCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarCode.KeyDown
        GetMesData.SetMessage(Me.lblMessage, "", False)
        Try
            If (e.KeyCode = Keys.Enter) Then
                If (String.IsNullOrEmpty(_TransactionId)) Then
                    GetMesData.SetMessage(Me.lblMessage, "单据号不能为空!", False)
                    Me.txtBarCode.Text = ""
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtBarCode.Text.Trim)) Then
                    GetMesData.SetMessage(Me.lblMessage, "扫描条码不能为空!", False)
                    Me.txtBarCode.Text = ""
                    Me.ActiveControl = Me.txtBarCode
                    Exit Sub
                End If

                If (Me.chkQuantity.Checked) Then
                    If (String.IsNullOrEmpty(Me.txtQuantity.Text.Trim)) Then
                        GetMesData.SetMessage(Me.lblMessage, "请输入条码数量!", False)
                        Me.txtBarCode.Text = ""
                        Me.ActiveControl = Me.txtQuantity
                        Exit Sub
                    End If
                    If (Not IsNumeric(Me.txtQuantity.Text.Trim())) Then
                        GetMesData.SetMessage(Me.lblMessage, "请输入条码数量格式错误!", False)
                        Me.txtBarCode.Text = ""
                        Me.ActiveControl = Me.txtQuantity
                        Exit Sub
                    End If
                    If (CDbl(Me.txtQuantity.Text.Trim()) <= 0) Then
                        GetMesData.SetMessage(Me.lblMessage, "请输入条码数量必须大于0!", False)
                        Me.txtBarCode.Text = ""
                        Me.ActiveControl = Me.txtQuantity
                        Exit Sub
                    End If
                End If

                'If (Me.chkQuantity.Checked) Then

                'Else

                'End If

                If (Not CheckFormat()) Then
                    Me.txtBarCode.Text = ""
                    Exit Sub
                End If


                ' If GetMesData .CheckStoreMaterialLotNO 



                Dim MaterialInfoStatus As Boolean

                For I As Int16 = 0 To _MaterialList.Rows.Count - 1
                    If (_MaterialList.Rows(I).Item("MATERIALNO") = strMaterialNO) Then
                        strDescription = _MaterialList.Rows(I).Item("DESCRIPTION")
                        strSpecification = _MaterialList.Rows(I).Item("SPECIFICATION")
                        strUnitPrice = _MaterialList.Rows(I).Item("UNITPRICE")
                        strStockQuantity = _MaterialList.Rows(0).Item("QUANTITY")
                        strUnit = _MaterialList.Rows(0).Item("UOM_NAME")

                        If (_MaterialList.Rows(I).Item("TransactionType") = "0") Then
                            GetMesData.SetMessage(Me.lblMessage, "扫描条码错误，料号为数量，不能执行条码扫描!", False)
                            Me.txtBarCode.Text = String.Empty
                            Me.ActiveControl = Me.txtBarCode
                            Exit Sub
                        ElseIf (_MaterialList.Rows(I).Item("QUANTITY") = "") Then
                            If (Not IsNumeric(_MaterialList.Rows(I).Item("QUANTITY"))) Then
                                _MaterialList.Rows(I).Item("QUANTITY") = "0"
                                _MaterialList.Rows(I).Item("TransactionType") = "1"
                            Else
                                If (CInt(_MaterialList.Rows(I).Item("QUANTITY")) > 0) Then
                                    GetMesData.SetMessage(Me.lblMessage, "扫描条码错误，料号为数量，不能执行条码扫描!", False)
                                    _MaterialList.Rows(I).Item("TransactionType") = "0"
                                    Me.txtBarCode.Text = String.Empty
                                    Me.ActiveControl = Me.txtBarCode
                                    Exit Sub
                                End If
                            End If
                        End If
                        MaterialInfoStatus = True
                        Exit For
                    End If
                Next

                If (Not CheckScan(Me.chkPackingSame.Checked, MaterialInfoStatus)) Then
                    Me.txtBarCode.Text = String.Empty
                    Me.ActiveControl = Me.txtBarCode
                    Exit Sub
                End If

                If (Not GetMesData.CheckStoreMaterialLotNO(Me.txtBarCode.Text.Trim())) Then 'luxl 20160109
                    GetMesData.SetMessage(Me.lblMessage, "當前入庫批次比上次入庫批次小，不能入庫", False)
                    Me.txtBarCode.Text = String.Empty
                    Me.ActiveControl = Me.txtBarCode
                    Exit Sub
                End If

                'If (Not MaterialInfoStatus) Then
                '    Dim dtMaterial As DataTable = GetMesData.GetMaterialList(strMaterialNO, "1")
                '    If (Not dtMaterial Is Nothing And dtMaterial.Rows.Count > 0) Then
                '        strDescription = dtMaterial.Rows(0).Item("DESCRIPTION")
                '        strSpecification = dtMaterial.Rows(0).Item("SPECIFICATION")
                '        strUnitPrice = dtMaterial.Rows(0).Item("UNITPRICE")
                '        strMaterialType = dtMaterial.Rows(0).Item("TYPEFLAG")
                '        strStockQuantity = dtMaterial.Rows(0).Item("QUANTITY")
                '        strUnit = dtMaterial.Rows(0).Item("UOM_NAME")
                '    Else
                '        GetMesData.SetMessage(Me.lblMessage, "扫描条码料号系统不存在或非成品产品", False)
                '        Me.txtBarCode.Text = String.Empty
                '        Me.ActiveControl = Me.txtBarCode
                '        Exit Sub
                '    End If
                'End If

                Dim strSQL As New StringBuilder
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
                Try
                    strSQL.AppendLine(" INSERT INTO m_ScanBacodeTransaction_t(ScanBarcodeTransactionId, TransactionId, BarCode, MaterialNO, Description, Specification, Uint, Quantity, VenderId, ")
                    strSQL.AppendLine(" DateCode, Versions, HistoryWarehouseId, HistoryWarehouseLocationId, DeleteFlag, StatusFlag, CreateUser, CreateTime, PackingSame, ProductType, PackingCartonId ")
                    strSQL.AppendLine(" )VALUES( '" & _TransactionId & "', NULL, '" & Me.txtBarCode.Text.Trim.ToUpper() & "', '" & strMaterialNO & "', N'" & strDescription.Replace("'", "''") & "', N'" & strSpecification.Replace("'", "''") & "', N'" & strUnit & "', '" & strQty & "', '" & VbCommClass.VbCommClass.Factory & "', ")
                    strSQL.AppendLine(" NULL, NULL, '" & strWarehouseId & "', '" & strWarehouseLocationId & "', 0, 0,  '" & VbCommClass.VbCommClass.UseId & "', GetDate(), '" & IIf(Me.chkPackingSame.Checked, "1", "0") & "', '" & IIf(Me.chkScanProduct.Checked, "0", "1") & "', '" & strPackingCartonId & "')")

                    If (Not String.IsNullOrEmpty(strSQL.ToString)) Then
                        Conn.ExecSql(strSQL.ToString())
                    End If
                    Conn.PubConnection.Close()
                Catch ex As Exception
                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If
                    GetMesData.SetMessage(Me.lblMessage, "执行扫描异常!", False)
                    Me.txtBarCode.Text = String.Empty
                    Me.ActiveControl = Me.txtBarCode
                    Exit Sub
                End Try

                If (Me.chkQuantity.Checked) Then
                    Dim BarcodeListStatus As Boolean = False
                    For i As Int16 = 0 To _BarCodeList.Rows.Count - 1
                        If (_BarCodeList.Rows(i).Item("MATERIALNO").ToString.ToUpper = strMaterialNO) Then
                            _BarCodeList.Rows(i).Item("QUANTITY") = _BarCodeList.Rows(i).Item("QUANTITY") + strQty
                            BarcodeListStatus = True
                            Exit For
                        End If
                    Next
                    If (Not BarcodeListStatus) Then
                        Dim drData As DataRow
                        drData = _BarCodeList.NewRow()
                        drData("BARCODE") = Me.txtBarCode.Text.Trim.ToUpper()
                        drData("MATERIALNO") = strMaterialNO
                        drData("DESCRIPTION") = strDescription
                        drData("SPECIFICATION") = strSpecification
                        drData("QUANTITY") = strQty
                        drData("UOM_NAME") = strUnit
                        drData("VenderId") = ""
                        drData("DateCode") = ""
                        drData("Versions") = ""
                        drData("PackingSame") = "1"
                        _BarCodeList.Rows.Add(drData)
                        Me.dgvBarcode.Update()
                    End If
                    strQty = Me.txtQuantity.Text.Trim
                Else
                    Dim drData As DataRow
                    drData = _BarCodeList.NewRow()
                    drData("BARCODE") = Me.txtBarCode.Text.Trim.ToUpper()
                    drData("MATERIALNO") = strMaterialNO
                    drData("DESCRIPTION") = strDescription
                    drData("SPECIFICATION") = strSpecification
                    drData("QUANTITY") = strQty
                    drData("UOM_NAME") = strUnit
                    drData("VenderId") = ""
                    drData("DateCode") = ""
                    drData("Versions") = ""
                    drData("PackingSame") = "0"
                    _BarCodeList.Rows.Add(drData)
                    Me.dgvBarcode.Update()
                End If

                Dim MaterialListStatus As Boolean = False
                For i As Int16 = 0 To _MaterialList.Rows.Count - 1
                    If (_MaterialList.Rows(i).Item("MATERIALNO").ToString.ToUpper = strMaterialNO) Then
                        _MaterialList.Rows(i).Item("QUANTITY") = _MaterialList.Rows(i).Item("QUANTITY") + strQty
                        MaterialListStatus = True
                        Exit For
                    End If
                Next

                If (Not MaterialListStatus) Then
                    Dim drMaterialData As DataRow

                    drMaterialData = _MaterialList.NewRow()
                    drMaterialData("MATERIALNO") = strMaterialNO
                    drMaterialData("DESCRIPTION") = strDescription
                    drMaterialData("SPECIFICATION") = strSpecification
                    drMaterialData("QUANTITY") = strQty
                    drMaterialData("UNITPRICE") = strUnitPrice
                    drMaterialData("STOCKQUANTITY") = strStockQuantity
                    drMaterialData("UOM_NAME") = strUnit
                    drMaterialData("TransactionType") = "1"
                    _MaterialList.Rows.Add(drMaterialData)
                    _MaterialList.AcceptChanges()
                End If

                Me.txtBarCode.Text = ""
                Me.ActiveControl = Me.txtBarCode
            End If
        Catch
            Me.txtBarCode.Text = String.Empty
            Me.ActiveControl = Me.txtBarCode
            GetMesData.SetMessage(Me.lblMessage, "扫描异常", False)
        End Try
    End Sub

    Private Sub chkQuantity_CheckedChanged(sender As Object, e As EventArgs) Handles chkQuantity.CheckedChanged
        Try
            If (Me.chkQuantity.Checked) Then
                Me.txtQuantity.Enabled = True
            Else
                Me.txtQuantity.Enabled = False
                Me.txtQuantity.Text = String.Empty
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更改异常!", False)
        End Try
    End Sub

    Private Sub chkRule_CheckedChanged(sender As Object, e As EventArgs) Handles chkRule.CheckedChanged
        Try
            If (Me.chkRule.Checked) Then
                Me.txtRule.Enabled = True
            Else
                Me.txtRule.Enabled = False
                Me.txtRule.Text = String.Empty
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更改异常!", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Function CheckFormat() As Boolean
        Dim rtValue As Boolean = True
        Try

            If (Me.chkRule.Checked) Then
                If (String.IsNullOrEmpty(Me.txtRule.Text.Trim)) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "请输入条码格式错误", False)
                End If

                If (Len(Me.txtBarCode.Text.Trim) <> Len(Me.txtRule.Text.Trim)) Then
                    rtValue = False
                    GetMesData.SetMessage(Me.lblMessage, "请扫描条码格式长度不一致", False)
                Else
                    For i As Int16 = 0 To Len(Me.txtRule.Text.Trim()) - 1
                        If (Me.txtRule.Text.Trim.Substring(i, 1).Trim <> "*") Then
                            If (Me.txtRule.Text.Trim.Substring(i, 1) <> Me.txtBarCode.Text.Trim.Substring(i, 1)) Then
                                rtValue = False
                                GetMesData.SetMessage(Me.lblMessage, "请扫描条码格式不一致", False)
                                Exit For
                            End If
                        Else
                            Continue For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            rtValue = False
            GetMesData.SetMessage(Me.lblMessage, "扫描异常", False)
        End Try
        Return rtValue
    End Function

    Private Function CheckScan(ByVal PackingSame As String, ByVal MaterialInfoStatus As Boolean) As Boolean
        Dim rtValue As Boolean = False
        Dim CheckRepeat As Boolean = False
        Dim strSQL As New StringBuilder

        If (Not Me.chkQuantity.Checked) Then
            Try
                For i As Int16 = 0 To Me.dgvBarcode.Rows.Count - 1
                    If (Me.dgvBarcode.Rows(i).Cells("BARCODE").Value.ToString.ToUpper = Me.txtBarCode.Text.Trim.ToUpper) Then
                        rtValue = False
                        CheckRepeat = True
                        GetMesData.SetMessage(Me.lblMessage, "条码已经扫描", False)
                        Exit For
                    End If
                Next
            Catch ex As Exception
                GetMesData.SetMessage(Me.lblMessage, "扫描异常", False)
                rtValue = False
            End Try
        End If

        If (Not CheckRepeat) Then
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
            Dim DReader As SqlClient.SqlDataReader
            Try
                '扫描检查类型：1->入库扫描,2->出库扫描， 3->调拨
                Select Case (_ScanCheckType)

                    Case "1"
                        '物料类型0:原物料，1：半成品，2：成品   m_MOPackingLevel
                        'strSQL.AppendLine(" SELECT REEL_BARCODE FROM W_REELS_T WHERE REEL_BARCODE='" & Me.txtBarCode.Text.Trim & "' AND DeleteFlag='0' ")

                        strSQL.AppendLine(" DECLARE @rtValue NVARCHAR(1),@rtMsg NVARCHAR(64),@MaterialNO VARCHAR(64), @QUANTITY VARCHAR(16), @Description NVARCHAR(256), @Specification NVARCHAR(256), @UnitPrice VARCHAR(16), @MaterialType VARCHAR(8), @StockQuantity VARCHAR(16), @Unit NVARCHAR(8) ")
                        strSQL.AppendLine(" SET @rtValue='1' SET @rtMsg='' ")
                        strSQL.AppendLine(" IF (ISNULL('N','N')='N') BEGIN ")
                        strSQL.AppendLine(" IF EXISTS(SELECT REEL_BARCODE FROM W_REELS_T WHERE REEL_BARCODE='" & Me.txtBarCode.Text.Trim & "' AND DeleteFlag='0' AND PackingSame='0') ")
                        strSQL.AppendLine(" BEGIN SET @rtValue = '0' SET @rtMsg = N'扫描条码已经入库' End Else BEGIN ")
                        strSQL.AppendLine(" SELECT @MaterialNO = ISNULL(m_Mainmo_t.PartID,''), @QUANTITY = ISNULL(m_SnSBarCode_t.Qty,1) FROM m_SnSBarCode_t INNER JOIN m_Mainmo_t ON m_Mainmo_t.Moid=m_SnSBarCode_t.Moid WHERE m_SnSBarCode_t.SBarCode='" & Me.txtBarCode.Text.Trim & "' ")
                        strSQL.AppendLine(" IF(ISNULL(@MaterialNO,'')='') BEGIN ")
                        strSQL.AppendLine(" SET @rtValue = '0' SET @rtMsg = N'扫描条码/料号不存在' End Else BEGIN ")
                        strSQL.AppendLine(" IF NOT EXISTS(SELECT MATERIAL_NO FROM W_MATERIALS WHERE MATERIAL_NO=@MaterialNO) BEGIN ")
                        strSQL.AppendLine(" SET @rtValue = '0' SET @rtMsg = N'扫描条码/料号不存在' End Else BEGIN ")
                        strSQL.AppendLine(" SELECT @Description=DESCRIPTION, @Specification=SPECIFICATION, @UnitPrice=UNITPRICE, @MaterialType=TYPEFLAG, @StockQuantity=QUANTITY, @Unit=UOM_NAME FROM W_MATERIALS WHERE MATERIAL_NO=@MaterialNO End End End End ")
                        strSQL.AppendLine(" SELECT @rtValue, @rtMsg, @MaterialNO, ISNULL(@QUANTITY,'0'), ISNULL(@Description,''), ISNULL(@Specification,''), ISNULL(@UnitPrice,'0'), ISNULL(@MaterialType,'1'), ISNULL(@StockQuantity,'0'), ISNULL(@Unit,'') ")

                    Case "2"
                        'strSQL = "SELECT REEL_BARCODE, WAREHOUSE, LOCATION, REMAINING_QUANTITY FROM W_REELS_T WHERE REEL_BARCODE='" & Me.txtBarCode.Text.Trim & "' AND  DeleteFlag='0' AND STATUS='2' "
                        strSQL.AppendLine(" DECLARE @rtValue NVARCHAR(1),@rtMsg NVARCHAR(64),@MaterialNO VARCHAR(64), @REMAINING_QUANTITY FLOAT,@WarehouseId VARCHAR(64), @WarehouseLoactionId VARCHAR(64), @FIFO VARCHAR(8), @DATECODE DATETIME, @FIFOBARCODE VARCHAR(64) ")
                        strSQL.AppendLine(" , @Description NVARCHAR(256), @Specification NVARCHAR(256), @UnitPrice VARCHAR(16), @MaterialType VARCHAR(8), @StockQuantity VARCHAR(16), @Unit NVARCHAR(8), @TypeFlag AS VARCHAR(1), @ScanProductFlag VARCHAR(1), @PackingCartonId VARCHAR(64), @ScanBarcode VARCHAR(64) ")
                        strSQL.AppendLine(" SET @ScanBarcode='" & Me.txtBarCode.Text.Trim & "' SET @ScanProductFlag = '" & IIf(Me.chkScanProduct.Checked, "Y", "N") & "' SET @rtValue='1' SET @rtMsg='' ")
                        strSQL.AppendLine(" IF(ISNULL(@ScanProductFlag,'N')='Y') BEGIN ")
                        strSQL.AppendLine(" SELECT @PackingCartonId = Cartonid, @REMAINING_QUANTITY= ISNULL(m_SnSBarCode_t.Qty,0) FROM m_Cartonsn_t INNER JOIN m_SnSBarCode_t ON m_SnSBarCode_t.SBarCode=m_Cartonsn_t.ppid WHERE ppid = @ScanBarcode AND Status=0 ")
                        strSQL.AppendLine(" IF(ISNULL(@PackingCartonId,'')='') BEGIN ")
                        strSQL.AppendLine(" SET @rtValue='0' SET @rtMsg=N'扫描条码不存在或已经出库'  End ELSE BEGIN ")     'CREATE_TIME变更为 CREATE_DATECODE  
                        strSQL.AppendLine(" SELECT @MaterialNO = MATERIAL_NO, @WarehouseId = ISNULL(WAREHOUSE,''), @WarehouseLoactionId = ISNULL(LOCATION,''), @DATECODE = CREATE_DATECODE FROM W_REELS_T WHERE REEL_BARCODE=@PackingCartonId AND STATUS='1' End End ELSE BEGIN ")
                        strSQL.AppendLine(" SELECT @MaterialNO = MATERIAL_NO, @REMAINING_QUANTITY= ISNULL(REMAINING_QUANTITY,0), @WarehouseId = ISNULL(WAREHOUSE,''), @WarehouseLoactionId = ISNULL(LOCATION,''), @DATECODE = CREATE_DATECODE FROM W_REELS_T WHERE REEL_BARCODE=@ScanBarcode AND STATUS='1' END ")
                        strSQL.AppendLine(" IF(ISNULL(@MaterialNO,'')='') ")
                        strSQL.AppendLine(" BEGIN SET @rtValue='0' SET @rtMsg=N'扫描条码不存在或已经出库' End Else BEGIN ")
                        strSQL.AppendLine(" SELECT @Description=DESCRIPTION, @Specification=SPECIFICATION, @UnitPrice=UNITPRICE, @MaterialType=TYPEFLAG, @StockQuantity=QUANTITY, @Unit=UOM_NAME, @TypeFlag=ISNULL(TYPEFLAG,'0')  FROM W_MATERIALS WHERE MATERIAL_NO=@MaterialNO ")
                        strSQL.AppendLine(" IF(@TypeFlag<>'3') BEGIN SET @rtValue='0' SET @rtMsg=N'扫描条码非成品' End ELSE BEGIN ")
                        strSQL.AppendLine(" SELECT @FIFO = ISNULL(FIFO_TYPE, 'N') FROM W_MATERIALS WHERE MATERIAL_NO = @MaterialNO ")
                        strSQL.AppendLine(" IF(ISNULL(@FIFO,'N')='Y') BEGIN ")
                        strSQL.AppendLine(" SELECT TOP 1 @FIFOBARCODE = REEL_BARCODE FROM W_REELS_T WHERE MATERIAL_NO=@MaterialNO AND CREATE_DATECODE < @DATECODE AND STATUS='1' AND DELETEFLAG='0' AND REMAINING_QUANTITY>0 ORDER BY CREATE_TIME DESC ")
                        strSQL.AppendLine(" IF(ISNULL(@FIFOBARCODE,'')!='') ")
                        strSQL.AppendLine(" BEGIN SET @rtValue = '0' SET @rtMsg = N'扫描条码不满足先进先出,存在更早条码' + @FIFOBARCODE End End End END ")
                        'strSQL.AppendLine(" SELECT @rtValue, @rtMsg, @REMAINING_QUANTITY, @WarehouseId, @WarehouseLoactionId ")
                        strSQL.AppendLine(" SELECT @rtValue, @rtMsg, @MaterialNO, ISNULL(@REMAINING_QUANTITY,'0'), @WarehouseId, @WarehouseLoactionId, ISNULL(@Description,''), ISNULL(@Specification,''), ISNULL(@UnitPrice,'0'), ISNULL(@MaterialType,'1'), ISNULL(@StockQuantity,'0'), ISNULL(@Unit,''), ISNULL(@PackingCartonId,'')  ")
                    Case "3"
                        strSQL.AppendLine(" DECLARE @rtValue NVARCHAR(1),@rtMsg NVARCHAR(64),@MaterialNO VARCHAR(64), @REMAINING_QUANTITY FLOAT,@WarehouseId VARCHAR(64), @WarehouseLoactionId VARCHAR(64), @FIFO VARCHAR(8), @DATECODE DATETIME, @FIFOBARCODE VARCHAR(64) ")
                        strSQL.AppendLine(" , @Description NVARCHAR(256), @Specification NVARCHAR(256), @UnitPrice VARCHAR(16), @MaterialType VARCHAR(8), @StockQuantity VARCHAR(16), @Unit NVARCHAR(8), @TypeFlag AS VARCHAR(1) ")
                        strSQL.AppendLine(" SELECT @MaterialNO = MATERIAL_NO, @REMAINING_QUANTITY= ISNULL(REMAINING_QUANTITY,0), @WarehouseId = ISNULL(WAREHOUSE,''), @WarehouseLoactionId = ISNULL(LOCATION,''), @DATECODE = CREATE_TIME FROM W_REELS_T WHERE REEL_BARCODE='" & Me.txtBarCode.Text.Trim & "' AND STATUS='1' ")
                        strSQL.AppendLine(" SET @rtValue='1' SET @rtMsg='' ")
                        strSQL.AppendLine(" IF(ISNULL(@MaterialNO,'')='') ")
                        strSQL.AppendLine(" BEGIN SET @rtValue='0' SET @rtMsg=N'扫描条码不存在或已经出库' End Else BEGIN ")
                        strSQL.AppendLine(" SELECT @Description=DESCRIPTION, @Specification=SPECIFICATION, @UnitPrice=UNITPRICE, @MaterialType=TYPEFLAG, @StockQuantity=QUANTITY, @Unit=UOM_NAME, @TypeFlag=ISNULL(TYPEFLAG,'0')  FROM W_MATERIALS WHERE MATERIAL_NO=@MaterialNO ")
                        strSQL.AppendLine(" IF(@TypeFlag<>'3') BEGIN SET @rtValue='0' SET @rtMsg=N'扫描条码非成品' End END ")
                        'strSQL.AppendLine(" SELECT @rtValue, @rtMsg, @REMAINING_QUANTITY, @WarehouseId, @WarehouseLoactionId ")
                        strSQL.AppendLine(" SELECT @rtValue, @rtMsg, @MaterialNO, ISNULL(@REMAINING_QUANTITY,'0'), @WarehouseId, @WarehouseLoactionId, ISNULL(@Description,''), ISNULL(@Specification,''), ISNULL(@UnitPrice,'0'), ISNULL(@MaterialType,'1'), ISNULL(@StockQuantity,'0'), ISNULL(@Unit,'') ")
                End Select

                DReader = Conn.GetDataReader(strSQL.ToString)

                Select Case (_ScanCheckType)

                    Case "1"
                        '物料类型0:原物料，1：半成品，2：成品
                        If (DReader.HasRows) Then

                            DReader.Read()
                            If (DReader.GetString(0) = "0") Then
                                GetMesData.SetMessage(Me.lblMessage, DReader.GetString(1), False)
                                rtValue = False
                            Else
                                strMaterialNO = DReader.GetString(2)
                                strQty = DReader.GetString(3)
                                strDescription = DReader.GetString(4)
                                strSpecification = DReader.GetString(5)
                                strUnitPrice = DReader.GetString(6)
                                strMaterialType = DReader.GetString(7)
                                strStockQuantity = DReader.GetString(8)
                                strUnit = DReader.GetString(9)
                                rtValue = True
                            End If
                        Else
                            rtValue = False
                            GetMesData.SetMessage(Me.lblMessage, "条码检查异常", False)
                        End If
                        strWarehouseId = ""
                        strWarehouseLocationId = ""
                    Case "2"
                        If (DReader.HasRows) Then
                            DReader.Read()

                            'strWarehouseId = DReader.GetString(1)
                            'strWarehouseLocationId = DReader.GetString(2)
                            'strQty = DReader.GetString(3)
                            'rtValue = True

                            If (DReader.GetString(0) = "0") Then
                                GetMesData.SetMessage(Me.lblMessage, DReader.GetString(1), False)
                                rtValue = False
                            Else
                                strMaterialNO = DReader.GetString(2)
                                strQty = Convert.ToString(DReader.GetDouble(3))
                                strWarehouseId = DReader.GetString(4)
                                strWarehouseLocationId = DReader.GetString(5)
                                strDescription = DReader.GetString(6)
                                strSpecification = DReader.GetString(7)
                                strUnitPrice = DReader.GetString(8)
                                strMaterialType = DReader.GetString(9)
                                strStockQuantity = DReader.GetString(10)
                                strUnit = DReader.GetString(11)
                                strPackingCartonId = DReader.GetString(12)
                                rtValue = True
                            End If
                        Else
                            rtValue = False
                            GetMesData.SetMessage(Me.lblMessage, "扫描条码不存在或已经出库", False)
                        End If
                    Case "3"
                        If (DReader.HasRows) Then
                            DReader.Read()
                            If (DReader.GetString(0) = "0") Then
                                GetMesData.SetMessage(Me.lblMessage, DReader.GetString(1), False)
                                rtValue = False
                            Else
                                strMaterialNO = DReader.GetString(2)
                                strQty = Convert.ToString(DReader.GetDouble(3))
                                strWarehouseId = DReader.GetString(4)
                                strWarehouseLocationId = DReader.GetString(5)
                                strDescription = DReader.GetString(6)
                                strSpecification = DReader.GetString(7)
                                strUnitPrice = DReader.GetString(8)
                                strMaterialType = DReader.GetString(9)
                                strStockQuantity = DReader.GetString(10)
                                strUnit = DReader.GetString(11)
                                rtValue = True
                            End If
                        Else
                            rtValue = False
                            GetMesData.SetMessage(Me.lblMessage, "扫描条码不存在或已经出库", False)
                        End If
                End Select

                DReader.Close()
                Conn.PubConnection.Close()
            Catch ex As Exception
                If (DReader.IsClosed = False) Then
                    DReader.Close()
                End If
                If (Conn.PubConnection.State = ConnectionState.Open) Then
                    Conn.PubConnection.Close()
                End If
                GetMesData.SetMessage(Me.lblMessage, "扫描异常", False)
                rtValue = False
            End Try
        End If
        Return rtValue
    End Function
#End Region

End Class