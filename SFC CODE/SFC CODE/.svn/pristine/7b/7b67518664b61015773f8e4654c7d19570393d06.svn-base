
'--海翼工单样式对话框
'--Create by :　马锋
'--Create date :　2016/09/02
'--Update date :  
'--Ver : V01

#Region "类库导入"
Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
#End Region

Public Class FrmHWITMoStyleQuery

#Region "变量声明"

    Dim _txtBarCodeStyle As MaskedTextBoxAdv
    Dim _strMOId As String
#End Region

#Region "构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal txtBarCodeStyle As MaskedTextBoxAdv, ByVal strMOId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _txtBarCodeStyle = txtBarCodeStyle
        _strMOId = strMOId
    End Sub
#End Region

#Region "加载事件"

    Private Sub FrmHWITMoStyleQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False

            LoadContralData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

#Region "控件事件"

    Private Sub btnQuery_Click(sender As Object, e As EventArgs)
        LoadContralData()
    End Sub

    Private Sub btnDetermine_Click(sender As Object, e As EventArgs) Handles btnDetermine.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择FNSKU", False)
                Exit Sub
            End If
            _txtBarCodeStyle.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("SBarCode").Value.ToString()
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
            _txtBarCodeStyle.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("SBarCode").Value.ToString()
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadContralData()
        Try
            Me.dgvQuery.DataSource = GetMesData.GetMOSKUStyleList(_strMOId)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

End Class