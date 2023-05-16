
'--工单查询对话框
'--Create by :　cq
'--Create date :　2016/11/07
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

Public Class FrmSampleMOQuery

#Region "变量声明"

    Dim _txtMOContral As MaskedTextBoxAdv
    Dim _strSupportId As String
    Public m_strSampleNO As String
    Public m_strQty As String
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
            SampleCom.SetMessage(Me.lblMessage, "加载异常", False)
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
                SampleCom.SetMessage(Me.lblMessage, "请选择工单", False)
                Exit Sub
            End If
            _txtMOContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("MOId").Value.ToString()
            m_strSampleNO = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("SampleNO").Value.ToString()
            m_strQty = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("Qty").Value.ToString()
            Me.Close()
        Catch ex As Exception
            SampleCom.SetMessage(Me.lblMessage, "选择异常", False)
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
            m_strSampleNO = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("SampleNO").Value.ToString()
            m_strQty = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("Qty").Value.ToString()
            Me.Close()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSampleMOQuery", "dgvQuery_CellDoubleClick", "Sample")
            SampleCom.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadContralData()
        Try
            Me.dgvQuery.DataSource = SampleCom.GetMOList(Me.txtSupplierCode.Text.Trim, _strSupportId)
        Catch ex As Exception
            SampleCom.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region


End Class