
'--条码打印
'--Create by :　马锋
'--Create date :　2015/08/20
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

Public Class FrmBarcodePrinterMaster

#Region "变量声明"

    Shared _MaterialList As DataTable

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
                _MaterialList.Columns.Add("REMARK", Type.GetType("System.String"))
            End If
            Return _MaterialList
        End Get

        Set(ByVal Value As DataTable)
            _MaterialList = Value
        End Set
    End Property

#End Region

#Region "加载事件"

    Private Sub FrmWarehouseingMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.MaterialList.Rows.Clear()
            Me.dgvBarcodePrinterItem.AutoGenerateColumns = False
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
                Me.dgvBarcodePrinterItem.DataSource = MaterialList
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnStick_Click(sender As Object, e As EventArgs) Handles btnStick.Click
        Try
            Dim frmBulkPasteMaterial As New FrmBulkPasteMaterialQuery(MaterialList)
            frmBulkPasteMaterial.ShowDialog()
            If (MaterialList.Rows.Count > 0) Then
                Me.dgvBarcodePrinterItem.DataSource = MaterialList
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

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

            strSQL.AppendLine(" DECLARE @TransactionID VARCHAR(32)")
            strSQL.AppendLine(" DECLARE @UserID VARCHAR(32) ")
            strSQL.AppendLine(" SET @UserID='" & VbCommClass.VbCommClass.UseId & "' ")
            strSQL.AppendLine(" SET @TransactionID=CONVERT(varchar(100), GETDATE(), 25) ")

            '单头
            strSQL.AppendLine(" INSERT INTO m_BarcodePrinter_t(FactoryId, Profitcenter, TransactionId, Remark, StatusFlag, DeleteFlag, CreateTime, CreateUser) ")
            strSQL.AppendLine(" VALUES( '" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "', @TransactionID,")
            strSQL.AppendLine("  N'" & Me.txtRemark.Text.Trim.Replace("'", "''") & "',")
            strSQL.AppendLine(" '1', '0', GETDATE(), @UserID) ")

            '单身
            Dim strMaterialNO As String
            Dim strDescription As String
            Dim strSpecification As String
            Dim strUint As String
            Dim strQuantity As String
            Dim strRemark As String

            For I As Int16 = 0 To Me.dgvBarcodePrinterItem.Rows.Count - 1
                strMaterialNO = IIf(IsDBNull(Me.dgvBarcodePrinterItem.Rows(I).Cells("MATERIALNO").Value), "", Me.dgvBarcodePrinterItem.Rows(I).Cells("MATERIALNO").Value.ToString())
                strDescription = IIf(IsDBNull(Me.dgvBarcodePrinterItem.Rows(I).Cells("DESCRIPTION").Value), "", Me.dgvBarcodePrinterItem.Rows(I).Cells("DESCRIPTION").Value.ToString())
                strSpecification = IIf(IsDBNull(Me.dgvBarcodePrinterItem.Rows(I).Cells("SPECIFICATION").Value), "", Me.dgvBarcodePrinterItem.Rows(I).Cells("SPECIFICATION").Value.ToString())
                strUint = IIf(IsDBNull(Me.dgvBarcodePrinterItem.Rows(I).Cells("UOM_NAME").Value), "", Me.dgvBarcodePrinterItem.Rows(I).Cells("UOM_NAME").Value.ToString())
                strQuantity = IIf(IsDBNull(Me.dgvBarcodePrinterItem.Rows(I).Cells("QUANTITY").Value), "0", Me.dgvBarcodePrinterItem.Rows(I).Cells("QUANTITY").Value.ToString())
                strRemark = IIf(IsDBNull(Me.dgvBarcodePrinterItem.Rows(I).Cells("REMARK").Value), "", Me.dgvBarcodePrinterItem.Rows(I).Cells("REMARK").Value.ToString())

                strSQL.AppendLine(" INSERT INTO m_BarcodePrinterItem_t( TransactionId, MaterialNO, Description, Specification, Uint, Quantity, PrinterQuantity, Remark, DeleteFlag, CreateUser, CreateTime) ")
                strSQL.AppendLine(" VALUES( @TransactionID, '" & strMaterialNO & "', N'" & strDescription & "', N'" & strSpecification & "', '" & strUint & "', '" & strQuantity & "', 0, N'" & strRemark & "', 0, @UserID, GETDATE()) ")
            Next

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

        Try
            Me.dtpInvoiceDate.Value = Now

            Me.dgvBarcodePrinterItem.Rows.Add(7)
            Me.txtTransactionId.Text = "<自动编号>"
            Me.txtUserId.Text = VbCommClass.VbCommClass.UseId
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Function CheckSave() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (Me.dgvBarcodePrinterItem.Rows.Count <= 0) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
            Else
                Dim Qty As String
                Dim strMaterialNO As String
                Dim strWarehouseLocationId As String
                Dim SelectMaterialNO As Boolean = False
                Dim CheckFor As Boolean = True

                For i As Int16 = 0 To Me.dgvBarcodePrinterItem.Rows.Count - 1
                    strMaterialNO = Me.dgvBarcodePrinterItem.Rows(i).Cells("MaterialNO").Value
                    'Qty = Me.dgvBarcodePrinterItem.Rows(i).Cells("QUANTITY").Value
                    Qty = IIf(IsDBNull(Me.dgvBarcodePrinterItem.Rows(i).Cells("QUANTITY").Value), "", Me.dgvBarcodePrinterItem.Rows(i).Cells("QUANTITY").Value.ToString())
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
                        'If (String.IsNullOrEmpty(strWarehouseLocationId)) Then
                        '    rtValue = False
                        '    GetMesData.SetMessage(Me.lblMessage, "请选择第" & i + 1 & "行库位", False)
                        '    Exit For
                        'End If
                    End If
                Next
                If (SelectMaterialNO) Then
                    If (CheckFor) Then
                        rtValue = True
                    End If
                Else
                    GetMesData.SetMessage(Me.lblMessage, "请选择打印物料", False)
                    rtValue = False
                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

#End Region

End Class