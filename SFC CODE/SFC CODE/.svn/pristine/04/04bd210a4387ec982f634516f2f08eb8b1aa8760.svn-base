
'--数据库表查询
'--Create by :　马锋
'--Create date :　2015/09/18
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

Public Class FrmTableQuery

#Region "变量声明"

    Dim _txtTableContral As MaskedTextBoxAdv
    Dim _strLinkServer As String
    Dim _strTargetDataBase As String
    Dim _strServerType As String
#End Region

#Region "构造函数"
    Private _maskedTextBoxAdv As MaskedTextBoxAdv
    Private _p2 As String
    Private _p3 As String

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal txtTableContral As MaskedTextBoxAdv, ByVal strLinkServer As String, ByVal strTargetDataBase As String, ByVal strServerType As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _txtTableContral = txtTableContral
        _strLinkServer = strLinkServer
        _strTargetDataBase = strTargetDataBase
        _strServerType = strServerType
    End Sub
#End Region

    Sub New(maskedTextBoxAdv As MaskedTextBoxAdv, p2 As String, p3 As String)
        ' TODO: Complete member initialization 
        _maskedTextBoxAdv = maskedTextBoxAdv
        _p2 = p2
        _p3 = p3
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            Me.dgvQuery.DataSource = GetMesData.GetTableName(Me.txtTableName.Text.Trim(), _strLinkServer, _strTargetDataBase, _strServerType)
        Catch ex As Exception
            Me.dgvQuery.Rows.Clear()
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub FrmTableQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False
            Me.dgvQuery.DataSource = GetMesData.GetTableName(Me.txtTableName.Text.Trim(), _strLinkServer, _strTargetDataBase, _strServerType)

        Catch ex As Exception
            Me.dgvQuery.Rows.Clear()
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub dgvQuery_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQuery.CellDoubleClick
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                Exit Sub
            End If
            _txtTableContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("TableName").Value.ToString()
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

    Private Sub btnDetermine_Click(sender As Object, e As EventArgs) Handles btnDetermine.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                Exit Sub
            End If
            _txtTableContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("TableName").Value.ToString()
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class