
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
Imports MainFrame
#End Region

Public Class FrmMOQuery

#Region "变量声明"

    Dim _txtMOContral As MaskedTextBoxAdv
    Dim _strSupportId As String
    Dim _strpartid As String
    Private _NewMo As String
    Public Property NewMo() As String
        Get
            Return _NewMo
        End Get
        Set(ByVal value As String)
            _NewMo = value
        End Set
    End Property

#End Region

#Region "构造函数"

   

    Public Sub New(ByVal txtMOContral As MaskedTextBoxAdv, ByVal strSupportId As String, Optional partid As String = "")
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _txtMOContral = txtMOContral
        _strSupportId = strSupportId
        _strpartid = partid
    End Sub
    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _txtMOContral = New MaskedTextBoxAdv


    End Sub
#End Region

#Region "加载事件"

    Private Sub FrmMOQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub dgvQuery_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQuery.CellDoubleClick
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                Exit Sub
            End If
            NewMo = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("MOId").Value.ToString()
            _txtMOContral.Text = NewMo
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

#End Region

#Region "函数"
    Shared factory As String = "LX53,WANXUN,M02600,JIZHOU,XINYU,LX21,COCRXIN,BZLANTO,CHUZHOU"

    Private Sub LoadContralData()
        Try
            Me.dgvQuery.DataSource = GetMOList(Me.txtSupplierCode.Text.Trim, _strSupportId, _strpartid)
            If factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
                If dgvQuery.Rows.Count <= 0 Then
                    'Label1.Text = GetMoInfo(Me.txtSupplierCode.Text.Trim)
                    'Me.dgvQuery.DataSource = GetMOList(Me.txtSupplierCode.Text.Trim, _strSupportId)
                End If
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
#End Region
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
    Public Shared Function GetMOList(ByVal MoId As String, ByVal strSupportId As String, Optional partid As String = "") As DataTable
        Dim dtTemp As DataTable = Nothing
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(MoId)) Then
                strWhere = " AND Moid LIKE '%" & MoId & "%'"
            End If
            If (Not String.IsNullOrEmpty(partid)) And partid <> "" Then
                strWhere = " AND partid LIKE '%" & partid & "%'"
            End If
            If (Not String.IsNullOrEmpty(strSupportId)) AndAlso Not factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
                strWhere = strWhere + " AND cusid='" & strSupportId & "' "
            End If

            strWhere = strWhere + " AND Factory = '" & VbCommClass.VbCommClass.Factory & "'"
            If Not String.IsNullOrEmpty(VbCommClass.VbCommClass.profitcenter) Then
                strWhere = strWhere + " AND profitcenter = '" & VbCommClass.VbCommClass.profitcenter & "'"
            End If

            strSQL = "SELECT TOP 100 Moid, PartID, Moqty, Remark FROM m_Mainmo_t WHERE FinalY='N' " & strWhere & " ORDER BY Createtime DESC"

            dtTemp = DbOperateReportUtils.GetDataTable(strSQL)
        Catch ex As Exception
        End Try
        Return dtTemp
    End Function

    Private Sub btnDetermine_Click(sender As Object, e As EventArgs) Handles btnDetermine.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                SetMessage(Me.lblMessage, "请选择工单", False)
                Exit Sub
            End If
            '_txtMOContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("MOId").Value.ToString()
            NewMo = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("MOId").Value.ToString()
            _txtMOContral.Text = NewMo
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub
End Class