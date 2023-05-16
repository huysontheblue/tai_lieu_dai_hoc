
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

Public Class FrmQuery

#Region "变量声明"

    Dim _ReturnFiled As String
    Public ReturnValue As String = ""
    Dim _SQL As String
    Dim _KeyIndex As Integer
#End Region

#Region "构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="SQL">查询SQL</param>
    ''' <param name="KeyIndex">查询条件栏位</param>
    ''' <param name="ReturnFiled">返回值栏位，用逗号隔开</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal SQL As String, ByVal KeyIndex As Integer, ByVal ReturnFiled As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _ReturnFiled = ReturnFiled
        _SQL = SQL
        _KeyIndex = KeyIndex
    End Sub
#End Region

#Region "加载事件"

    Private Sub FrmMOQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Me.dgvQuery.AutoGenerateColumns = False

            LoadContralData()
        Catch ex As Exception
            'GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
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
                SetMessage(Me.lblMessage, "请选择记录", False)
                Exit Sub
            End If
            If _ReturnFiled.Split(",").Length > 0 Then
                Dim i As Integer = 0

                For i = 0 To _ReturnFiled.Split(",").Length - 1
                    ReturnValue = ReturnValue + Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells(_ReturnFiled.Split(",")(i).ToString).Value.ToString() + ","
                Next
            End If
            If ReturnValue.IndexOf(",") > 0 Then
                ReturnValue = ReturnValue.Substring(0, ReturnValue.Length - 1)
            End If
            ' _txtReturn.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells(_KeyIndex).Value.ToString()
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
            '_txtReturn.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells(_KeyIndex).Value.ToString()
            If _ReturnFiled.Split(",").Length > 0 Then
                Dim i As Integer = 0

                For i = 0 To _ReturnFiled.Split(",").Length - 1
                    ReturnValue = ReturnValue + Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells(_ReturnFiled.Split(",")(i).ToString).Value.ToString() + ","
                Next
            End If
            If ReturnValue.IndexOf(",") > 0 Then
                ReturnValue = ReturnValue.Substring(0, ReturnValue.Length - 1)
            End If
            Me.Close()
        Catch ex As Exception
            'GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub LoadContralData()
        Try
            Dim qsql As String = _SQL
            If txtCode.Text <> "" Then
                qsql = " select * from (" + _SQL + ") AA where (1=1)"
                Dim keyfield As String = _SQL.Split(",")(_KeyIndex).Replace("select ", "").Trim
                'If keyfield.Split(".").Length > 0 Then
                '    keyfield = Split(".")(1)
                'End If
                qsql = qsql + " and " + keyfield + " like '%" + txtCode.Text.Trim + "%'"
            End If
            dgvQuery.DataSource = GetQueryList(qsql) ' GetMesData.GetMOList(Me.txtCode.Text.Trim, _strSupportId)
            dgvQuery.Refresh()
        Catch ex As Exception
            'GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region
    Public Function GetQueryList(ByVal sql As String) As DataTable
        Dim dtTemp As DataTable = New DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            'Dim strSQL As String
            'Dim strWhere As String = ""


            'strSQL = "SELECT TOP 100 Moid, PartID, Moqty, Remark FROM m_Mainmo_t WHERE FinalY='N' AND cusid='" & strSupportId & "' " & strWhere & " ORDER BY Createtime DESC"

            dtTemp = Conn.GetDataTable(sql)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function
    Public Shared Sub SetMessage(ByVal lblMessage As LabelX, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As Label, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As LabelItem, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

End Class