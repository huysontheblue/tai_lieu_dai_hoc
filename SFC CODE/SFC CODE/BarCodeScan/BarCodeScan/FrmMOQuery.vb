
'--工单查询对话框
'--Create by :　马锋
'--Create date :　2015/10/08
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

Public Class FrmMOQuery

#Region "变量声明"

    Dim _txtMOContral As MaskedTextBoxAdv
    Dim _strSupportId As String
#End Region

#Region "构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal txtMOContral As MaskedTextBoxAdv, ByVal strSupportId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _txtMOContral = txtMOContral
        _strSupportId = strSupportId
    End Sub
#End Region

#Region "加载事件"

    Private Sub FrmMOQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                GetMesData.SetMessage(Me.lblMessage, "请选择工单", False)
                Exit Sub
            End If
            _txtMOContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("MOId").Value.ToString()
            Me.DialogResult = Windows.Forms.DialogResult.OK
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
            _txtMOContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("MOId").Value.ToString()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

#End Region

#Region "函数"
    Shared factory As String = "LX53,WANXUN,M02600,JIZHOU,XINYU,LX21,COCRXIN,BZLANTO,CHUZHOU"

    Private Sub LoadContralData()
        Try
            Me.dgvQuery.DataSource = GetMesData.GetMOList(Me.txtSupplierCode.Text.Trim, _strSupportId)
            If factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
                If dgvQuery.Rows.Count <= 0 Then
                    Label1.Text = GetMesData.GetMoInfo(Me.txtSupplierCode.Text.Trim)
                    Me.dgvQuery.DataSource = GetMesData.GetMOList(Me.txtSupplierCode.Text.Trim, _strSupportId)
                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region


End Class