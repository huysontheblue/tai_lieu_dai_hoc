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
Public Class FrmQueryInfo
#Region "变量声明"

    'Dim Conn As New SysDataHandle.SysDataBaseClass
    Dim _KeyValue As String
    Public _INFO As INFO
#End Region
    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub
    'Public Sub New()
    '    MyBase.New()
    '    '该调用是 Windows 窗体设计器所必需的。
    '    InitializeComponent()
    '    '_KeyValue = PO
    'End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        If ComboBox1.SelectedIndex = 0 Then
            LoadContralData()
        Else
            AddContralData()
        End If

    End Sub
    Private Sub AddContralData()
        Try
            Dim sqlstr As String = txtSQL.Text.ToString.Replace("'", "''")
            Dim sql As String = ""
            sql = sql + String.Format(" declare @SortID int  select @SortID=isnull(max(SortID),0)+1 from m_Sortset_t where SortType='QrySQL' ")
            sql = sql + String.Format("insert m_Sortset_t(SortID,SortName,SortNameEn,SortDesc,Orderid,SortType,SortTypeName,IsAlert,AlertTime,Usey,Userid,Intime,terminal) values(	@SortID	,	N'" & txtCode.Text.Trim & "'	,	N'" & txtCode.Text.Trim & "',	N'" & sqlstr & "'	,	@SortID	,	'QrySQL'	,	N'通用查询语句'	,	NULL	,	NULL	,	'Y'	,	'" & SysMessageClass.UseId & "'	,	getdate()	,	0	)")
            DbOperateUtils.ExecSQL(sql.ToString)
            ComboBox1.SelectedIndex = 0
            LoadContralData()
        Catch ex As Exception
            'GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
    Private Sub LoadContralData()
        Try
            dgvQuery.DataSource = GetQueryList(txtCode.Text)
            dgvQuery.Refresh()
        Catch ex As Exception
            'GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
    Public Function GetQueryList(ByVal code As String) As DataTable
        Dim dtTemp As DataTable = New DataTable
        Try
            Dim strSQL As String = "select SortName,SortDesc from m_Sortset_t where SortType='QrySQL' order by Orderid "
            If code <> "" Then
                strSQL = "select SortName,SortDesc from m_Sortset_t where SortType='QrySQL' and SortName like N'%" & code & "%' order by Orderid "
            End If

            dtTemp = DbOperateReportUtils.GetDataTable(strSQL)
        Catch ex As Exception
            MessageBox.Show("获取信息出错：" + ex.ToString)
        End Try
        Return dtTemp
    End Function
    Private Sub btnDetermine_Click(sender As Object, e As EventArgs) Handles btnDetermine.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.SelectedRows.Count = 0 Then
                SetMessage(Me.lblMessage, "请选择记录", False)
                Exit Sub
            End If
            _INFO.returnValue = dgvQuery.CurrentRow.Cells(1).Value.ToString()
            'Dim chkTemp As DataGridViewCheckBoxCell
            'Dim selcount As String = 0
            'For i As Int16 = 0 To Me.dgvQuery.RowCount - 1
            '    chkTemp = dgvQuery.Rows(i).Cells("ChkSelect")
            '    If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then
            '        'POINFO.PO = txtCode.Text.ToString
            '        'If selcount = 0 Then
            '        '    POINFO.POITEM1 = dgvQuery.Rows(i).Cells(1).Value
            '        '    POINFO.POPART1 = dgvQuery.Rows(i).Cells(2).Value
            '        '    POINFO.POQTY1 = dgvQuery.Rows(i).Cells(3).Value
            '        'End If
            '        'If selcount = 1 Then
            '        '    POINFO.POITEM2 = dgvQuery.Rows(i).Cells(1).Value
            '        '    POINFO.POPART2 = dgvQuery.Rows(i).Cells(2).Value
            '        '    POINFO.POQTY2 = dgvQuery.Rows(i).Cells(3).Value
            '        'End If
            '        'If selcount = 2 Then
            '        '    POINFO.POITEM3 = dgvQuery.Rows(i).Cells(1).Value
            '        '    POINFO.POPART3 = dgvQuery.Rows(i).Cells(2).Value
            '        '    POINFO.POQTY3 = dgvQuery.Rows(i).Cells(3).Value
            '        'End If
            '        selcount = selcount + 1
            '    End If
            'Next

            Me.Close()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "选择异常", False)
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

    Private Sub FrmQueryInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim key As String = _KeyValue
        'If key <> "" Then
        '    txtCode.Text = key
        '    LoadContralData()
        'End If
        LoadContralData()
    End Sub

    Private Sub dgvQuery_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQuery.CellDoubleClick
        btnDetermine_Click(Nothing, Nothing)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            btnQuery.Text = "查询"
            txtSQL.Text = ""
            txtSQL.Enabled = False
        Else
            btnQuery.Text = "添加"
            txtSQL.Text = ""
            txtSQL.Enabled = True
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.SelectedRows.Count = 0 Then
            Exit Sub
        Else
            'Dim key As String = dgvQuery.CurrentRow.Cells(0).Value.ToString()
            DeleteContralData()
            txtSQL.Text = ""
            txtCode.Text = ""
        End If

    End Sub
    Private Sub DeleteContralData()
        Try
            Dim sql As String = ""
            sql = sql + String.Format("delete from m_Sortset_t where SortType='QrySQL'  and  SortName=N'" & txtCode.Text.Trim & "'	")
            DbOperateUtils.ExecSQL(sql.ToString)
            ComboBox1.SelectedIndex = 0
            LoadContralData()
        Catch ex As Exception
            'GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub dgvQuery_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQuery.CellClick
        If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.SelectedRows.Count = 0 Then
            Exit Sub
        Else
            txtCode.Text = dgvQuery.CurrentRow.Cells(0).Value.ToString()
            txtSQL.Text = dgvQuery.CurrentRow.Cells(1).Value.ToString()
        End If
    End Sub
End Class
#Region "单变量参数"
''增加動態數據d。
Public Structure INFO
    Public returnValue As String
    Public Function ToArray() As Array
        Dim ReTurnArray(1) As String
        ReTurnArray(1) = returnValue
        Return ReTurnArray
    End Function
End Structure

#End Region