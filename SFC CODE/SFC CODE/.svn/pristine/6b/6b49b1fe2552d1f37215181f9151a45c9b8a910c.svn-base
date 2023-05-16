
'--列显示设置
'--Create by :　马锋
'--Create date :　2015/12/11
'--Ver : V01
'--Update date :  
'--

#Region "Imports"

Imports System.Windows.Forms
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

Public Class FrmColumnVisiableSetting

    Dim dtVisiableColumn As DataTable

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _dtVisiableColumn As DataTable)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        dtVisiableColumn = _dtVisiableColumn
    End Sub

#End Region

    Private Sub FrmColumnVisiableSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvColumn.DataSource = dtVisiableColumn
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "填充行异常", False)
        End Try
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Try
            dtVisiableColumn.AcceptChanges()
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "设置异常", False)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class