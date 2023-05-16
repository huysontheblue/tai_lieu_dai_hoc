'--单据审核
'--Create by :　马锋
'--Create date :　2015/08/13
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

Public Class FrmCheckTranaction

#Region "变量声明"

    Dim TransactionType As String
    Dim TransactionId As String              '保存类型，暂取消
#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _strTransactionType As String, ByVal _TransactionId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        TransactionType = _strTransactionType
        TransactionId = _TransactionId
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmCheckTranaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If (String.IsNullOrEmpty(TransactionId)) Then
                GetMesData.SetMessage(Me.lblMessage, "请选择单据", False)
                Me.rbtnPass.Enabled = False
                Me.rbtnFail.Enabled = False
                Me.txtRemark.Enabled = False
                Me.btnDefine.Enabled = False
                Me.btnCancel.Enabled = False
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub btnDefine_Click(sender As Object, e As EventArgs) Handles btnDefine.Click

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub
#End Region


End Class