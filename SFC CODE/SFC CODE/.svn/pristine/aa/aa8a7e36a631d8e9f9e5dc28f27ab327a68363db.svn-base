
'--仓库物料选择
'--Create by :　马锋
'--Create date :　2015/07/23
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

Public Class FrmMaterialQuery

#Region "变量声明"

    Dim _MaterialList As DataTable
    Dim _MaterialType As String
#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal dtSelectMaterial As DataTable, ByVal MaterialType As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _MaterialList = dtSelectMaterial
        '0:非成品，1：成品
        _MaterialType = MaterialType
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmMaterialQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvSelectMaterial.AutoGenerateColumns = False
            Me.dgvMaterial.AutoGenerateColumns = False
            Me.dgvMaterial.DataSource = GetMesData.GetMaterialList(Me.txtMaterialNO.Text.Trim, _MaterialType)
            Me.dgvSelectMaterial.DataSource = _MaterialList
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            Me.dgvMaterial.DataSource = GetMesData.GetMaterialList(Me.txtMaterialNO.Text.Trim, _MaterialType)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim strMaterialNo As String
            Dim strMaterialNoTemp As String

            If Me.dgvMaterial.Rows.Count = 0 OrElse Me.dgvMaterial.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要加入的行!", False)
                Exit Sub
            End If

            strMaterialNo = Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("MATERIALNO").Value.ToString

            If (_MaterialList.Rows.Count > 0) Then
                For I As Int16 = 0 To Me.dgvSelectMaterial.RowCount - 1
                    strMaterialNoTemp = Me.dgvSelectMaterial.Rows(I).Cells("SELECTMATERIALNO").Value.ToString
                    If (strMaterialNo = strMaterialNoTemp) Then
                        Exit Sub
                    End If
                Next
            End If

            Dim drTemp As DataRow
            drTemp = _MaterialList.NewRow
            drTemp("MATERIALNO") = Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("MATERIALNO").Value.ToString
            drTemp("DESCRIPTION") = Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("DESCRIPTION").Value.ToString
            drTemp("SPECIFICATION") = Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("SPECIFICATION").Value.ToString
            drTemp("UOM_NAME") = Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("UOM_NAME").Value.ToString
            drTemp("QUANTITY") = Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("QUANTITY").Value.ToString
            drTemp("WAREHOUSELOCATIONID") = Me.dgvMaterial.Rows(Me.dgvMaterial.CurrentRow.Index).Cells("WAREHOUSELOCATIONID").Value.ToString
            _MaterialList.Rows.Add(drTemp)
            _MaterialList.AcceptChanges()

            Me.dgvSelectMaterial.DataSource = _MaterialList
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try

            If Me.dgvSelectMaterial.Rows.Count = 0 OrElse Me.dgvSelectMaterial.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要删除的行!", False)
                Exit Sub
            End If

            Me.dgvSelectMaterial.Rows.RemoveAt(Me.dgvSelectMaterial.CurrentRow.Index)

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
            _MaterialList.Rows.Clear()
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "取消异常", False)
        End Try
    End Sub

    Private Sub dgvMaterial_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMaterial.CellDoubleClick
        Try
            Dim strMaterialNo As String
            Dim strMaterialNoTemp As String

            If Me.dgvMaterial.Rows.Count = 0 OrElse Me.dgvMaterial.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要加入的行!", False)
                Exit Sub
            End If

            strMaterialNo = Me.dgvMaterial.Rows(e.RowIndex).Cells("MATERIALNO").Value.ToString

            If (_MaterialList.Rows.Count > 0) Then
                For I As Int16 = 0 To Me.dgvSelectMaterial.RowCount - 1
                    strMaterialNoTemp = Me.dgvSelectMaterial.Rows(I).Cells("SELECTMATERIALNO").Value.ToString
                    If (strMaterialNo = strMaterialNoTemp) Then
                        Exit Sub
                    End If
                Next
            End If

            Dim drTemp As DataRow
            Dim CheckColumn As Boolean
            drTemp = _MaterialList.NewRow
            drTemp("MATERIALNO") = Me.dgvMaterial.Rows(e.RowIndex).Cells("MATERIALNO").Value.ToString
            drTemp("DESCRIPTION") = Me.dgvMaterial.Rows(e.RowIndex).Cells("DESCRIPTION").Value.ToString
            drTemp("SPECIFICATION") = Me.dgvMaterial.Rows(e.RowIndex).Cells("SPECIFICATION").Value.ToString
            drTemp("UOM_NAME") = Me.dgvMaterial.Rows(e.RowIndex).Cells("UOM_NAME").Value.ToString
            'QUANTITY
            drTemp("STOCKQUANTITY") = Me.dgvMaterial.Rows(e.RowIndex).Cells("QUANTITY").Value.ToString
            drTemp("UNITPRICE") = Me.dgvMaterial.Rows(e.RowIndex).Cells("UNITPRICE").Value.ToString

            drTemp("TransactionType") = "0"

            If (_MaterialList.Columns.Contains("ProfitQuantity")) Then
                drTemp("ProfitQuantity") = 0
            End If
            If (_MaterialList.Columns.Contains("LossQuantity")) Then
                drTemp("LossQuantity") = 0
            End If
            _MaterialList.Rows.Add(drTemp)
            _MaterialList.AcceptChanges()

            Me.dgvSelectMaterial.DataSource = _MaterialList
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

#End Region

#Region "函数"


#End Region

   
    
End Class