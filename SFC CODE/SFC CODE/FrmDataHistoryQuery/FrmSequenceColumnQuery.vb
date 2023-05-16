
'--排序列选择
'--Create by :　马锋
'--Create date :　2015/10/10
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

Public Class FrmSequenceColumnQuery

#Region "变量声明"

    Dim _txtSequenceColumnContral As MaskedTextBoxAdv
    Dim _strLinkServer As String
    Dim _strMigrateDataBase As String
    Dim _strServerType As String
    Dim _strTableName As String
    Dim _strTypeJudgment As String
#End Region

#Region "构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal txtSequenceColumnContral As MaskedTextBoxAdv, ByVal strLinkServer As String, ByVal strMigrateDataBase As String, ByVal strServerType As String, ByVal strTableName As String, ByVal strTypeJudgment As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _txtSequenceColumnContral = txtSequenceColumnContral
        _strLinkServer = strLinkServer
        _strMigrateDataBase = strMigrateDataBase
        _strServerType = strServerType
        _strTableName = strTableName
        _strTypeJudgment = strTypeJudgment
    End Sub
#End Region

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            Me.dgvQuery.DataSource = GetMesData.GetSequenceColumnQuery(_strLinkServer, _strMigrateDataBase, _strServerType, _strTableName)
        Catch ex As Exception
            Me.dgvQuery.Rows.Clear()
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub FrmTableQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False
            Me.dgvQuery.DataSource = GetMesData.GetSequenceColumnQuery(_strLinkServer, _strMigrateDataBase, _strServerType, _strTableName)
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

            If (_strTypeJudgment = "Y") Then
                If (Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("TYPENAME").Value.ToString().ToUpper() <> "datetime".ToUpper() And Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("TYPENAME").Value.ToString().ToUpper() <> "date".ToUpper()) Then
                    GetMesData.SetMessage(Me.lblMessage, "选择排序列必须为Datetime类型", False)
                    Exit Sub
                End If
            End If


            _txtSequenceColumnContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("COLUMNNAME").Value.ToString()
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

            If (_strTypeJudgment = "Y") Then
                If (Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("TYPENAME").Value.ToString().ToUpper() <> "datetime".ToUpper() And Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("TYPENAME").Value.ToString().ToUpper() <> "date".ToUpper()) Then
                    GetMesData.SetMessage(Me.lblMessage, "选择排序列必须为Datetime类型", False)
                    Exit Sub
                End If
            End If
            _txtSequenceColumnContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("COLUMNNAME").Value.ToString()
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class