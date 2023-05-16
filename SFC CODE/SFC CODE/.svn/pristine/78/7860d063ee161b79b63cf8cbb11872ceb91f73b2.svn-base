
'--数据库表列选择
'--Create by :　马锋
'--Create date :　2015/10/16
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

Public Class FrmColumnQuery

#Region "变量声明"

    Dim _txtColumnContral As MaskedTextBoxAdv
    Dim _strLinkServer As String
    Dim _strDataBase As String
    Dim _strTableName As String
    Dim _strLinkServerType As String
#End Region

#Region "构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal txtColumnContral As MaskedTextBoxAdv, ByVal strLinkServer As String, ByVal strDataBase As String, ByVal strTableName As String, ByVal strLinkServerType As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _txtColumnContral = txtColumnContral
        _strLinkServer = strLinkServer
        _strDataBase = strDataBase
        _strTableName = strTableName
        _strLinkServerType = strLinkServerType
    End Sub
#End Region

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            Me.dgvQuery.DataSource = GetMesData.GetColumnQuery(_strLinkServer, _strDataBase, _strTableName, _strLinkServerType)
        Catch ex As Exception
            Me.dgvQuery.Rows.Clear()
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub FrmColumnQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False
            Me.dgvQuery.DataSource = GetMesData.GetColumnQuery(_strLinkServer, _strDataBase, _strTableName, _strLinkServerType)
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

            _txtColumnContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("COLUMNNAME").Value.ToString()
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

            _txtColumnContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("COLUMNNAME").Value.ToString()
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class