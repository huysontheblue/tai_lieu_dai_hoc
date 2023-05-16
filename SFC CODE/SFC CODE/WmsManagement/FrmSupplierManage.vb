'--供应商管理
'--Create by :　马锋
'--Create date :　2015/07/27
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

Public Class FrmSupplierManage

#Region "加载事件"

    Private Sub FrmSupplierManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvSupplier.AutoGenerateColumns = False
            Me.dgvSupplier.DataSource = GetMesData.GetSupplierList(Me.txtSupplierCode.Text.Trim())
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim frmSupplierMaster As New FrmSupplierMaster
            frmSupplierMaster.ShowDialog()
            Me.dgvSupplier.DataSource = GetMesData.GetSupplierList(Me.txtSupplierCode.Text.Trim())
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
            If Me.dgvSupplier.Rows.Count = 0 OrElse Me.dgvSupplier.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择要修改的供应商", False)
                Exit Sub
            End If
            Dim strSupplierCode As String = Me.dgvSupplier.Rows(Me.dgvSupplier.CurrentRow.Index).Cells("SupplierCode").Value.ToString
            If (String.IsNullOrEmpty(strSupplierCode)) Then
                GetMesData.SetMessage(Me.lblMessage, "请选择的供应商代码不能为空", False)
                Exit Sub
            End If

            Dim frmSupplierMaster As New FrmSupplierMaster(strSupplierCode)
            frmSupplierMaster.ShowDialog()

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "编辑异常", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            Me.dgvSupplier.DataSource = GetMesData.GetSupplierList(Me.txtSupplierCode.Text.Trim())
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub
#End Region

#Region "函数"


#End Region

   
End Class