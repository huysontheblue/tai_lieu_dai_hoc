
'--目标数据库选择
'--Create by :　马锋
'--Create date :　2015/09/28
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

Public Class FrmTargetDataBaseQuery

#Region "变量声明"

    Dim _txtTargetDataBaseContral As MaskedTextBoxAdv
    Dim _strLinkServerName As String
    Dim _strServerType As String
#End Region

#Region "构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal txtTargetDataBaseContral As MaskedTextBoxAdv, ByVal strLinkServerName As String, ByVal strServerType As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _txtTargetDataBaseContral = txtTargetDataBaseContral
        _strLinkServerName = strLinkServerName
        _strServerType = strServerType
    End Sub
#End Region

#Region "控件事件"

    Private Sub FrmTargetDataBaseQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False
            Me.dgvQuery.DataSource = GetMesData.GetTargetDataBase(Me.txtTargetDataBase.Text.Trim(), _strLinkServerName, _strServerType)
        Catch ex As Exception
            Me.dgvQuery.Rows.Clear()
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            Me.dgvQuery.DataSource = GetMesData.GetTargetDataBase(Me.txtTargetDataBase.Text.Trim(), _strLinkServerName, _strServerType)
        Catch ex As Exception
            Me.dgvQuery.Rows.Clear()
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub dgvQuery_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQuery.CellDoubleClick
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                Exit Sub
            End If
            _txtTargetDataBaseContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("TargetDataBaseName").Value.ToString()
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
            _txtTargetDataBaseContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("TargetDataBaseName").Value.ToString()
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#End Region

End Class