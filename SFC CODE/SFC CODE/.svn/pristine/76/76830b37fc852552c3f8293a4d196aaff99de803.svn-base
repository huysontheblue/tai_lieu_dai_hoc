
'--供应商选择
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
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
#End Region

Public Class FrmSupplierQuery

#Region "变量声明"

    Dim _txtSupplierContral As MaskedTextBoxAdv

#End Region

#Region "构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal txtSupplierContral As MaskedTextBoxAdv)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _txtSupplierContral = txtSupplierContral
    End Sub
#End Region

#Region "加载事件"

    Private Sub FrmSupplierQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False

            LoadContralData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region


#Region "控件事件"

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        LoadContralData()
    End Sub

    Private Sub btnDetermine_Click(sender As Object, e As EventArgs) Handles btnDetermine.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择供应商", False)
                Exit Sub
            End If
            _txtSupplierContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("SupplierCode").Value.ToString()
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub dgvQuery_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQuery.CellDoubleClick
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                Exit Sub
            End If
            _txtSupplierContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("SupplierCode").Value.ToString()
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadContralData()
        Try
            Me.dgvQuery.DataSource = GetMesData.GetSupplierList(Me.txtSupplierCode.Text.Trim)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

End Class