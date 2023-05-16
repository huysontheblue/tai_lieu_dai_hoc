

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

    Dim _txtMOContral As TextBox
#End Region

#Region "构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal txtMOContral As TextBox)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _txtMOContral = txtMOContral
    End Sub
#End Region

#Region "加载事件"

    Private Sub FrmMOQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False

            MainTainCommon.BindComboxCustomer(cmbCustomer)
            MainTainCommon.BindComboxLineAll(cboQueryLine)
            LoadContralData()
        Catch ex As Exception
            MainTainCommon.SetMessage(Me.lblMessage, "加载异常", False)
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
                MainTainCommon.SetMessage(Me.lblMessage, "请选择工单", False)
                Exit Sub
            End If
            _txtMOContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("MOId").Value.ToString()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MainTainCommon.SetMessage(Me.lblMessage, "选择异常", False)
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
            MainTainCommon.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadContralData()
        Try
            Me.dgvQuery.DataSource = MainTainCommon.GetMOList(Me.txtSupplierCode.Text.Trim, cmbCustomer.SelectedValue.ToString, cboQueryLine.Text.Trim)

        Catch ex As Exception
            MainTainCommon.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region

    
End Class