
'--产线选择
'--Create by :　马锋
'--Create date :　2016/11/30
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
Imports MainFrame

#End Region

Public Class FrmLineQuery

#Region "变量声明"

    Dim _strDeptId As String
    Dim _txtLineContral As MaskedTextBoxAdv

#End Region

#Region "构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal strDeptId As String, ByVal txtLineContral As MaskedTextBoxAdv)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _strDeptId = strDeptId
        _txtLineContral = txtLineContral
    End Sub
#End Region

#Region "加载事件"

    Private Sub FrmLineQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False

            LoadContralData()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
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
                SetMessage(Me.lblMessage, "请选择设备", False)
                Exit Sub
            End If

            Dim strLineId As String = IIf(IsDBNull(Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("LineId").Value), "", Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("LineId").Value.ToString)

            _txtLineContral.Text = strLineId
            Me.Close()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "选择异常", False)
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
            Dim strLineId As String = IIf(IsDBNull(Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("LineId").Value), "", Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("LineId").Value.ToString)

            _txtLineContral.Text = strLineId
            Me.Close()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadContralData()
        Try
            Dim strSQL As String
            strSQL = "SELECT lineid, deptid FROM deptline_t WHERE usey = 'Y' AND deptid = '" & _strDeptId & "' "

            If Not (String.IsNullOrEmpty(Me.txtLineId.Text.Trim)) Then
                strSQL = strSQL & " AND lineId LIKE '%" & Me.txtLineId.Text.Trim.Replace("'", "''") & "%'"
            End If

            Me.dgvQuery.DataSource = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub


    Public Shared Sub SetMessage(ByVal lblMessage As LabelX, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub



#End Region

End Class