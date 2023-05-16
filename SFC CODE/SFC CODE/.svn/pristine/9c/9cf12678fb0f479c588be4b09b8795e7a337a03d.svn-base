
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
Imports SysBasicClass

#End Region

Public Class FrmLineMOQuery

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
            FillCombox(CboLine)
            CboLine.SelectedIndex = -1
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

#Region "控件事件"

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        LoadContralData()
    End Sub

    Private Sub btnDetermine_Click(sender As Object, e As EventArgs) Handles btnDetermine.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                SetMessage(Me.lblMessage, "请选择工单", False)
                Exit Sub
            End If
            _txtMOContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("MOId").Value.ToString()
            Me.DialogResult = Windows.Forms.DialogResult.OK
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
            _txtMOContral.Text = Me.dgvQuery.Rows(Me.dgvQuery.CurrentRow.Index).Cells("MOId").Value.ToString()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

#End Region

    Shared factory As String = "LX53,WANXUN,M02600,JIZHOU,XINYU,LX21,COCRXIN,BZLANTO,CHUZHOU"

    Private Sub LoadContralData()
        Try
            SetMessage(Me.lblMessage, "", False)
            Dim o_dtPartCount As New DataTable
            Dim strSQL As String = ""
            'Dim dtTemp As DataTable = Nothing
            If (Me.CboLine.Text.Trim <> "" Or Me.txtmoid.Text.Trim <> "") Then
                dgvQuery.Rows.Clear()
                'Dim Lineid As String = Me.txtLine.Text.Trim()
                'If CheckHaveData(Lineid) = False Then
                '    Exit Sub
                'Else
                o_dtPartCount = OracleOperateUtils.GetDataTableSap(SapCommon.GetCheckTiptopLineLotSQLSAP(Me.CboLine.Text.Trim(), Me.txtmoid.Text.Trim()))
                If o_dtPartCount.Rows.Count > 0 Then
                    For i As Byte = 0 To o_dtPartCount.Rows.Count - 1
                        Me.dgvQuery.Rows.Add(o_dtPartCount.Rows.Item(i)("sfb01").ToString, o_dtPartCount.Rows.Item(i)("sfb05").ToString,
                                              o_dtPartCount.Rows.Item(i)("sfb08").ToString, o_dtPartCount.Rows.Item(i)("AEDAT").ToString)
                    Next
                Else
                    SetMessage(Me.lblMessage, "ERP中没有数据，请检查查询条件是否有误！", False)
                End If
            Else
                SetMessage(Me.lblMessage, "请输入查询条件！", False)

            End If


            'If factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
            '    If dgvQuery.Rows.Count <= 0 Then
            '        Label1.Text = GetMesData.GetMoInfo(Me.txtSupplierCode.Text.Trim)
            '        Me.dgvQuery.DataSource = GetMesData.GetMOList(Me.txtSupplierCode.Text.Trim, _strSupportId)
            '    End If
            'End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub
    Private Sub CboLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLine.SelectedIndexChanged
        CboLine.Text.Trim()
    End Sub
#Region "Bind"
    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim UserDg As DataTable
        If ColComboBox.Name = "CboLine" Then
            Dim lineid As String = ""
            UserDg = DbOperateUtils.GetDataTable("select DISTINCT lineid from   deptline_t where  lineid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='z09_' and userid='" & VbCommClass.VbCommClass.UseId & "')")

            If CboLine.SelectedValue IsNot Nothing Then
                lineid = CboLine.SelectedValue.ToString()
            End If
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "lineid"
            ColComboBox.ValueMember = "lineid"
            UserDg = Nothing
        End If
    End Sub
#End Region
    Private Function CheckHaveData(Lineid As String) As Boolean
        '检查是否已经打印
        Dim strSQL As String
        strSQL = "SELECT moid FROM m_Mainmo_t INNER JOIN m_SnAssign_t ON m_SnAssign_t.MOID=m_Mainmo_t.MOID WHERE m_Mainmo_t.Lineid='" &
                 Lineid & "' AND FinishPrintQty>0"
        Dim dtPrintStatus As DataTable = DbOperateUtils.GetDataTable(strSQL)

        'strSQL = "SELECT TOP 1 Ppid from m_AssysnD_t WHERE Moid = '" & strMOid & "'"
        'Dim dtScanStatus As DataTable = DbOperateUtils.GetDataTable(strSQL)
        'If (Not dtScanStatus Is Nothing And dtScanStatus.Rows.Count > 0) Then
        '    'SetMessage("工单" & strMOid & "已经扫描记录，不允许重新下载或删除!")
        '    Return False
        'End If

        Return True
    End Function


End Class