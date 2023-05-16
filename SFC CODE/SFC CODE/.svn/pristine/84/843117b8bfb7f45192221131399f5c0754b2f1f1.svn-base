
'--物料管理
'--Create by :　马锋
'--Create date :　2015/08/07
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

Public Class FrmMaterialManagement

#Region "变量声明"

    Dim dtMaterialType As DataTable
    Dim dtTransactionType As DataTable
    Dim dtFIFOType As DataTable

#End Region

#Region "加载事件"

    Private Sub FrmMaterialManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadData()
            Me.dgvMaterial.AutoGenerateColumns = False
            Me.dgvBarcode.AutoGenerateColumns = False
            Me.dgvTransactionItem.AutoGenerateColumns = False
            Me.dgvBarcodeQuery.AutoGenerateColumns = False
            Me.SuperTabControl1.SelectedTabIndex = 0
            Me.dgvMaterial.DataSource = GetMesData.GetMaterialList(Me.txtMaterialNO.Text.Trim(), "")
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim materialMaster As New FrmMaterialMaster()
            materialMaster.ShowDialog()

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If Me.dgvMaterial.Rows.Count = 0 OrElse Me.dgvMaterial.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要修改的料件代码", False)
                Exit Sub
            End If

            Me.chkFIFO.Enabled = True
            Me.cboFIFOType.Enabled = True
            Me.cboMaterialType.Enabled = True
            Me.cboTransactionType.Enabled = True
            Me.btnEdit.Enabled = False
            Me.btnSave.Enabled = True
            Me.btnBack.Enabled = True
            Me.dgvMaterial.Enabled = False
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "编辑异常", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            Me.dgvMaterial.DataSource = GetMesData.GetMaterialList(Me.txtMaterialNO.Text.Trim(), "")
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub dgvMaterial_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMaterial.CellEnter
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvMaterial.Rows.Count = 0 OrElse Me.dgvMaterial.CurrentRow Is Nothing Then
            Me.chkFIFO.Checked = False
            Me.cboFIFOType.SelectedIndex = -1
            Me.dgvBarcode.Rows.Clear()
            Me.dgvTransactionItem.Rows.Clear()
            Exit Sub
        End If

        Try
            Me.chkFIFO.Checked = IIf(Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("FIFO_TYPE").Value = "Y", True, False)
            If (Me.chkFIFO.Checked = True) Then
                Me.cboFIFOType.SelectedIndex = Me.cboFIFOType.FindString(Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("FIFO_RULEName").Value)
            Else
                Me.cboFIFOType.SelectedIndex = -1
            End If

            Me.cboMaterialType.SelectedIndex = Me.cboMaterialType.FindString(Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("TypeFlagName").Value)
            Me.cboTransactionType.SelectedIndex = Me.cboTransactionType.FindString(Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("TransactionTypeName").Value)
            Me.chkPackingSame.Checked = IIf(Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("PackingSame").Value = "1", True, False)

            Me.dgvBarcode.DataSource = GetMesData.GetMaterialManagementBarcode(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("MATERIAL_NO").Value)
            Me.dgvTransactionItem.DataSource = GetMesData.GetMaterialManagementTransaction(VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("MATERIAL_NO").Value, Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("TYPEFLAG").Value)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载明细异常", False)
        End Try
    End Sub

    Private Sub chkFIFO_CheckedChanged(sender As Object, e As EventArgs) Handles chkFIFO.CheckedChanged
        Try
            If (Me.chkFIFO.Checked) Then
                Me.cboFIFOType.Enabled = True
            Else
                Me.cboFIFOType.Enabled = False
                Me.cboFIFOType.SelectedIndex = -1
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更改异常", False)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try

            strSQL = "UPDATE W_MATERIALS SET FIFO_TYPE='" & IIf(Me.chkFIFO.Checked, "Y", "N") & "', FIFO_RULE='" & IIf(IsDBNull(Me.cboFIFOType.SelectedValue), "NULL", Me.cboFIFOType.SelectedValue) & "', TYPEFLAG='" & Me.cboMaterialType.SelectedValue & "', TransactionType='" & Me.cboTransactionType.SelectedValue & "' WHERE MATERIAL_NO='" & Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("MATERIAL_NO").Value & "'"
            Conn.ExecSql(strSQL)
            Conn.PubConnection.Close()

            Me.chkFIFO.Enabled = False
            Me.cboFIFOType.Enabled = False
            Me.cboMaterialType.Enabled = False
            Me.cboTransactionType.Enabled = False
            Me.btnEdit.Enabled = True
            Me.btnSave.Enabled = False
            Me.btnBack.Enabled = False
            Me.dgvMaterial.Enabled = True
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "保存异常", False)
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Try

            Me.chkFIFO.Enabled = False
            Me.cboFIFOType.Enabled = False
            Me.cboMaterialType.Enabled = False
            Me.cboTransactionType.Enabled = False
            Me.btnEdit.Enabled = True
            Me.btnSave.Enabled = False
            Me.btnBack.Enabled = False
            Me.dgvMaterial.Enabled = True

            If Me.dgvMaterial.Rows.Count = 0 OrElse Me.dgvMaterial.CurrentRow Is Nothing Then
                Me.chkFIFO.Checked = False
                Me.cboFIFOType.SelectedIndex = -1
                Exit Sub
            End If

            Me.chkFIFO.Checked = IIf(Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("FIFO_TYPE").Value = "Y", True, False)
            If (Me.chkFIFO.Checked = True) Then
                Me.cboFIFOType.SelectedIndex = Me.cboFIFOType.FindString(Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("FIFO_RULE").Value)
            Else
                Me.cboFIFOType.SelectedIndex = -1
            End If
            Me.cboMaterialType.SelectedIndex = Me.cboMaterialType.FindString(Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("TypeFlagName").Value)
            Me.cboTransactionType.SelectedIndex = Me.cboTransactionType.FindString(Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("TransactionTypeName").Value)

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "返回异常", False)
        End Try
    End Sub

    Private Sub dgvTransactionItem_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTransactionItem.CellEnter
        GetMesData.SetMessage(Me.lblMessage, "", False)
        If Me.dgvTransactionItem.Rows.Count = 0 OrElse Me.dgvTransactionItem.CurrentRow Is Nothing Then
            Me.dgvBarcode.Rows.Clear()
            Exit Sub
        End If

        Try
            Me.dgvBarcodeQuery.DataSource = GetMesData.GetScanBarcode(Me.dgvTransactionItem.Rows(Me.dgvTransactionItem.CurrentRow.Index).Cells("TransactionId").Value.ToString(), Me.dgvTransactionItem.Rows(Me.dgvTransactionItem.CurrentRow.Index).Cells("MaterialNO").Value.ToString())
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常!", False)
        End Try
    End Sub
#End Region

#Region "函数"

    Private Sub LoadData()
        Dim strSQL As String
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Try
            strSQL = SQLStringHelper.GetSettingParameterSQL("MaterialType")
            dtMaterialType = Conn.GetDataTable(strSQL)

            strSQL = SQLStringHelper.GetSettingParameterSQL("TransactionType")
            dtTransactionType = Conn.GetDataTable(strSQL)

            strSQL = SQLStringHelper.GetSettingParameterSQL("FIFOType")
            dtFIFOType = Conn.GetDataTable(strSQL)

            Conn.PubConnection.Close()

            Me.cboFIFOType.DisplayMember = "PARAMETER_NAME"
            Me.cboFIFOType.ValueMember = "PARAMETER_VALUE"
            Me.cboFIFOType.DataSource = dtFIFOType

            Me.cboMaterialType.DisplayMember = "PARAMETER_NAME"
            Me.cboMaterialType.ValueMember = "PARAMETER_VALUE"
            Me.cboMaterialType.DataSource = dtMaterialType

            Me.cboTransactionType.DisplayMember = "PARAMETER_NAME"
            Me.cboTransactionType.ValueMember = "PARAMETER_VALUE"
            Me.cboTransactionType.DataSource = dtTransactionType


        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
    End Sub

#End Region

   
   
End Class