
'--产线选择
'--Create by :　马锋
'--Create date :　2016/10/25
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

Public Class FrmLineQuery


#Region "变量声明"

    Dim _txtLineIdContral As MaskedTextBoxAdv

    Private _DialogDeptID As TextBoxX
    'Public Property DialogDeptID() As String
    '    Get
    '        Return _DialogDeptID
    '    End Get

    '    Set(ByVal Value As String)
    '        _DialogDeptID = Value
    '    End Set
    'End Property

#End Region

#Region "构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal txtLineIdContral As MaskedTextBoxAdv, ByVal deptid As TextBoxX)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _txtLineIdContral = txtLineIdContral
        _DialogDeptID = deptid
    End Sub
#End Region

#Region "加载事件"

    Private Sub FrmWarehouseLoactionQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadContralData()
            LoadQuery()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region


#Region "控件事件"

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        LoadQuery()
    End Sub

    Private Sub btnDetermine_Click(sender As Object, e As EventArgs) Handles btnDetermine.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                GetMesData.SetMessage(Me.lblMessage, "请选择产线", False)
                Exit Sub
            End If
            _txtLineIdContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("LineId").Value.ToString()
            _DialogDeptID.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("DeptId").Value.ToString()

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
            _txtLineIdContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("LineId").Value.ToString()
            _DialogDeptID.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("DeptId").Value.ToString()
         
            Me.DialogResult = Windows.Forms.DialogResult.Yes
            Me.Close()

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadContralData()
        Try
            Me.dgvQuery.AutoGenerateColumns = False
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub LoadQuery()
        Try
            Me.dgvQuery.DataSource = GetMesData.GetLineList(Me.txtLineId.Text.Trim)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try

    End Sub
#End Region

End Class