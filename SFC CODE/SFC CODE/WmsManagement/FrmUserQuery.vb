
'--用户选择
'--Create by :　马锋
'--Create date :　2015/07/22
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

Public Class FrmUserQuery

#Region "变量声明"

    Dim _txtUserContral As MaskedTextBoxAdv

#End Region

#Region "构造函数"
    Private _p1 As Object

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal txtUserContral As MaskedTextBoxAdv)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _txtUserContral = txtUserContral
    End Sub
#End Region

#Region "加载事件"

    Sub New(p1 As Object)
        ' TODO: Complete member initialization 
        _p1 = p1
    End Sub

    Private Sub FrmUserQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                GetMesData.SetMessage(Me.lblMessage, "请选择用户", False)
                Exit Sub
            End If
            _txtUserContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("UserID").Value.ToString()
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub dgvQuery_CellDoubleClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgvQuery.CellDoubleClick
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                Exit Sub
            End If
            _txtUserContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("UserID").Value.ToString()
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadContralData()
        Try
            Me.dgvQuery.DataSource = GetMesData.GetUserList(Me.txtUser.Text.Trim)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

End Class