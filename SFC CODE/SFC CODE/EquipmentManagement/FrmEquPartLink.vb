Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Text
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle

Public Class FrmEquPartLink
    Public opflag As Int16 = 0
    Public EquNo As String
    Public PartNumber As String
#Region "初期化"

    Private Sub FrmEquPartLink_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '设定用戶權限
            Dim sysDB As New SysDataBaseClass
            '权限 
            sysDB.GetControlright(Me)
            ToolNew.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(ToolNew.Tag) = "YES", True, False))
            ToolEdit.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(ToolEdit.Tag) = "YES", True, False))
            toolAbandon.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(ToolEdit.Tag) = "YES", True, False))
            Me.StartPosition = FormStartPosition.CenterScreen
            '  Dim StrSql As String = "select PartID from m_EquPartLink_t where EquNo='" & EquNo & "'"
            ToolbtnState(0)
            Me.LblMsg.Text = ""
            LoadEquPartLink()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try

    End Sub
#End Region

    Private Sub LoadEquPartLink()
        Dim sql As String = "SELECT a.PARTID,B.UserName,A.UPDATETIME from m_EquPartLink_t a LEFT JOIN m_Users_t B ON A.UpdateUserId=B.UserID where A.EquNo='" & EquNo & "'"
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            dgvEquPartLink.DataSource = dt
        End Using
    End Sub

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        Me.txtPartid.Enabled = True
        opflag = 1
        ToolbtnState(1)
        'ClearControl()
        txtPartid.Clear()
        txtPartid.Focus()

    End Sub
    '修改，改变按钮状态
    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        If Me.dgvEquPartLink.Rows.Count = 0 OrElse Me.dgvEquPartLink.CurrentRow Is Nothing Then Exit Sub
        txtPartid.Text = DbOperateUtils.DBNullToStr(dgvEquPartLink.CurrentRow.Cells("Partid").Value)
        opflag = 2
        ToolbtnState(2)
    End Sub
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.ToolBack.Enabled = False
                Me.toolSave.Enabled = False
                'GroupBox
                Me.txtPartid.Enabled = True
                Me.txtPartid.Clear()
                'Me.ActiveControl = Me.txtPartID
            Case 1 'New
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.ToolBack.Enabled = True
                Me.toolSave.Enabled = True
                'GroupBox
                Me.txtPartid.Enabled = True
                'Me.ActiveControl = IIf(opflag = 1, Me.txtPartID, Me.txtTestTypeID)
            Case 2 'Edit
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.ToolBack.Enabled = True
                Me.toolSave.Enabled = True
                'GroupBox
                Me.txtPartid.Enabled = True
            Case 3 '
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.ToolBack.Enabled = False
                Me.toolSave.Enabled = False
                'GroupBox
                Me.txtPartid.Enabled = True
                'Me.ActiveControl = Me.txtPartID
        End Select
    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        Dim SqlStr As New StringBuilder
        If Me.dgvEquPartLink.Rows.Count = 0 OrElse Me.dgvEquPartLink.CurrentRow Is Nothing Then Exit Sub
        Try
            SqlStr.Append(" delete from  m_EquPartLink_t ")
            SqlStr.Append(" WHERE PARTID= '" & dgvEquPartLink.CurrentRow.Cells("Partid").Value & "' AND EquNo='" & EquNo & "'")
            If MessageUtils.ShowConfirm("确定要删除吗？", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                DbOperateUtils.ExecSQL(SqlStr.ToString)
                MessageUtils.ShowInformation("删除成功！")
            End If
            LoadEquPartLink()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmTestSFCStaion", "toolAbandon_Click", "sys")
        End Try
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Me.LblMsg.Text = String.Empty
        '检查输入
        If CheckInput() = False Then
            Exit Sub
        End If
        If SaveData() = False Then Exit Sub
        MessageUtils.ShowInformation("保存成功")
        LoadEquPartLink()
    End Sub

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        opflag = 0
        ToolbtnState(0)
    End Sub

    Private Function SaveData() As Boolean
        Dim SqlStr As New StringBuilder
        Dim mCheckCodeRead As DataTable = Nothing
        '新增保存
        If opflag = 1 Then
            Dim info() As String = Split(Me.txtPartid.Text, ",")
            For index = 0 To info.Length - 1
                If Not String.IsNullOrEmpty(info(index)) Then
                    Dim strSql = "SELECT 1 FROM m_PartContrast_t(nolock) where TAvcPart=N'" & info(index) & "'"
                    Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
                    If dt.Rows.Count > 0 Then
                        mCheckCodeRead = DbOperateUtils.GetDataTable("SELECT PARTID FROM m_EquPartLink_t WHERE EquNo='" & EquNo & "' AND PARTID='" & info(index) & "' ")
                        If mCheckCodeRead.Rows.Count > 0 Then
                            MessageUtils.ShowInformation("该笔资料已存在，请修改！")
                            Exit Function
                        End If
                        SqlStr.AppendFormat(" IF NOT EXISTS(SELECT 1 FROM m_EquPartLink_t WHERE PARTID = '{0}' AND EquNo='{1}') ",
                                            info(index), EquNo)
                        SqlStr.Append(" BEGIN")
                        SqlStr.Append("     INSERT INTO m_EquPartLink_t(EquNo,PartId,UpdateUserId,UpdateTime)")
                        SqlStr.AppendFormat(" VALUES ( N'{0}','{1}','{2}',getdate()", EquNo, info(index), SysCheckData.SysMessageClass.UseId)
                        SqlStr.Append(") END")
                    Else
                        Return False
                    End If
                End If
            Next
            '修改保存
        ElseIf opflag = 2 Then
            Dim partid As String = dgvEquPartLink.CurrentRow.Cells("Partid").Value.ToString.Trim
            SqlStr.Append(" UPDATE m_EquPartLink_t ")
            SqlStr.AppendFormat(" SET PartId = N'{0}',", txtPartid.Text.Trim)
            SqlStr.AppendFormat("UpdateUserId = N'{0}',", SysCheckData.SysMessageClass.UseId)
            SqlStr.Append("UpdateTime =getdate()")
            SqlStr.Append(" WHERE EquNo = '" & EquNo & "' and PartId='" & partid & "' ")
        End If
        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            opflag = 0
            ToolbtnState(0)
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquPartLink", "toolSave_Click", "EquipmentManagement")
            Exit Function
            Return False
        End Try
    End Function

    Private Function CheckInput() As Boolean
        Try
            If String.IsNullOrEmpty(Me.txtPartid.Text) AndAlso Not Me.txtPartid.Text Is Nothing Then
                LblMsg.Text = "产品料号不能为空..."
                Exit Function
                Me.txtPartid.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub
End Class