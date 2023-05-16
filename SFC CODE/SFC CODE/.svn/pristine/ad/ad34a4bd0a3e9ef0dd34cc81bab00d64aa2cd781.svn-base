
'--产线优先级
'--Create by :　马锋
'--Create date :　2017/03/17
'--Update date :  
'--Ver : V01

Imports MainFrame.SysDataHandle
Imports System.Windows.Forms
Imports System.Text
Imports MainFrame

Public Class FrmLineSeriesPriority

    Public opflag As Int16 = 0

#Region "窗体事件"

    Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Sub New(ByVal SericesCode As String, ByVal SericesName As String, ByVal isAdd As Boolean, ByVal isDelete As Boolean)
        _SericesCode = SericesCode
        _SericesName = SericesName
        _isAdd = isAdd
        _isDelete = isDelete
        InitializeComponent()
    End Sub

    Private _SericesCode As String 'Integer
    Private _SericesName As String
    Private _isAdd As Boolean
    Private _isDelete As Boolean
    Private sConn As New SysDataBaseClass

    Private Sub FrmLineSeriesPriority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False
            Me.txtSeriesName.Text = _SericesName
            LoadData()
            ToolbtnState(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadData()
        Try
            Me.dgvQuery.DataSource = DbOperateUtils.GetDataTable("SELECT * FROM m_LineSericesPriority_t WHERE SericesCode='" & _SericesCode & "' ")

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        ToolbtnState(1)
        Me.ActiveControl = Me.txtLineId

    End Sub

    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click

        If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then Exit Sub

        Me.txtLineId.Text = dgvQuery.CurrentRow.Cells("LineId").Value
        Me.txtPriority.Text = dgvQuery.CurrentRow.Cells("PriorityFlag").Value
        Dim usey As String = dgvQuery.CurrentRow.Cells("StatusFlag").Value
        If usey = "Y" Then
            chkUsey.Checked = True
        Else
            chkUsey.Checked = False
        End If

        ToolbtnState(2)
    End Sub

    Private Sub ToolCommit_Click(sender As Object, e As EventArgs) Handles ToolCommit.Click
        Try
            If String.IsNullOrEmpty(Me.txtLineId.Text) Then
                GetMesData.SetMessage(Me.lblMessage, "产线不能为空", True)
                Me.ActiveControl = Me.txtLineId
                Exit Sub
            End If

            If String.IsNullOrEmpty(Me.txtPriority.Text) Then
                GetMesData.SetMessage(Me.lblMessage, "优先级不能为空", True)
                Me.ActiveControl = Me.txtPriority
                Exit Sub
             Else
                If Not IsNumeric(Me.txtPriority.Text.Trim) Then
                    GetMesData.SetMessage(Me.lblMessage, "人力必须为数字", False)
                    Exit Sub
                Else
                    If (CDbl(Me.txtPriority.Text.Trim) <= 0) Then
                        GetMesData.SetMessage(Me.lblMessage, "人力必须大于0", False)
                        Exit Sub
                    End If
                End If
            End If

            Dim strSQL As New StringBuilder

            Dim usey As String = "N"
            If chkUsey.Checked Then
                usey = "Y"
            End If

            strSQL.AppendLine(" IF EXISTS(SELECT LineId FROM m_LineSericesPriority_t WHERE SericesCode = '" & _SericesCode & "' AND LineId = '" & Me.txtLineId.Text.Trim & "') ")
            strSQL.AppendLine(" BEGIN UPDATE m_LineSericesPriority_t SET PriorityFlag='" & Me.txtPriority.Text.Trim & "', StatusFlag='" & usey & "' WHERE SericesCode = '" & _SericesCode & "' AND LineId = '" & Me.txtLineId.Text.Trim & "' End ")
            strSQL.AppendLine(" ELSE  BEGIN INSERT INTO m_LineSericesPriority_t(LineId, SericesCode, SericesName, PriorityFlag, StatusFlag, CreateUserId)VALUES( ")
            strSQL.AppendLine(" '" & Me.txtLineId.Text.Trim & "', '" & _SericesCode & "', N'" & _SericesName & "', '" & Me.txtPriority.Text.Trim & "', '" & usey & "', '" & VbCommClass.VbCommClass.UseId & "') END ")

            DbOperateUtils.ExecSQL(strSQL.ToString)

            Me.txtLineId.Text = ""
            Me.txtPriority.Text = ""
            Me.chkUsey.Checked = False

            LoadData()
            opflag = 0
            ToolbtnState(0)
            GetMesData.SetMessage(Me.lblMessage, "保存成功", True)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存异常", False)
        End Try
    End Sub

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        txtPriority.Text = ""
        chkUsey.Checked = False
        ToolbtnState(0)
    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Try
            LoadData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

#End Region

#Region "方法"

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.toolAbandon.Enabled = False
                Me.ToolBack.Enabled = False
                Me.ToolCommit.Enabled = False
                Me.ToolQuery.Enabled = True

            Case 1, 2
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.ToolBack.Enabled = True
                Me.ToolCommit.Enabled = True
                Me.ToolQuery.Enabled = False

            Case 3
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.ToolBack.Enabled = False
                Me.ToolCommit.Enabled = False
                Me.ToolQuery.Enabled = True

        End Select
    End Sub



#End Region


End Class