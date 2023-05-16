Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmMoFirmwareVersion
    Public opflag As Int16 = 0  '
    Private Sub FrmTestSFCStaion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataInGrid()
        opflag = 0
        ToolbtnState(opflag)
    End Sub
    Private Function GetSqlWhere() As String
        Dim sbSqlWhere As New StringBuilder

        If String.IsNullOrEmpty(txtMoId.Text.Trim) = False Then
            sbSqlWhere.Append(" and MOID = N'" & Me.txtMoId.Text.Trim.ToString & "' ")
        End If
        Return sbSqlWhere.ToString
    End Function

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        opflag = 0
        ToolbtnState(0)
    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.ToolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.ToolQuery.Enabled = True
                'GroupBox
                Me.txtMoId.Enabled = False
                Me.txtPartId.Enabled = False
                Me.txtFirmwareVersion.Enabled = True
                Me.txtHardwareVersion.Enabled = True
                Me.txtFirmwareVersion.Text = ""
                Me.txtHardwareVersion.Text = ""
                'Me.ActiveControl = Me.txtPartID
            Case 1 'New
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.ToolQuery.Enabled = False
                'GroupBox
                Me.txtMoId.Enabled = False
                Me.txtPartId.Enabled = False
                Me.txtFirmwareVersion.Enabled = True
                Me.txtHardwareVersion.Enabled = True
                'Me.ActiveControl = IIf(opflag = 1, Me.txtPartID, Me.txtTestTypeID)
            Case 2 'Edit
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.ToolQuery.Enabled = False
                'GroupBox
                Me.txtPartId.Enabled = False
                Me.txtFirmwareVersion.Enabled = True
                Me.txtHardwareVersion.Enabled = True
            Case 3 '
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.ToolQuery.Enabled = True
                'GroupBox
                Me.txtMoId.Enabled = False
                'Me.ActiveControl = Me.txtPartID
            Case 4 '
                Me.txtMoId.Enabled = True
                Me.txtPartId.Enabled = True
        End Select
    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        opflag = 4
        ToolbtnState(4)
        LoadDataInGrid()
    End Sub

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        SysMessageClass.EditFlag = True
        'ChgRecord(0)
        opflag = 1
        ToolbtnState(1)
        'ClearControl()
        txtFirmwareVersion.Focus()
    End Sub
    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            Dim SqlStr As New StringBuilder
            Dim mCheckCodeRead As DataTable = Nothing
            '新增保存

            '检查输入
            If CheckInput() = False Then
                Exit Sub
            End If
            '确认信息
            If MessageUtils.ShowConfirm("你确定保存吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            '保存
            If SaveData() = False Then Exit Sub

            MessageUtils.ShowInformation("保存成功")
            opflag = 0
            ToolbtnState(0)
            LoadDataInGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MoManage.FrmMoFirmwareVersion", "toolSave_Click", "MoManages")
            Exit Sub
        End Try

    End Sub
    '修改，改变按钮状态
    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then Exit Sub
        Me.txtMoId.Text = DbOperateUtils.DBNullToStr(dgvQuery.CurrentRow.Cells("moid").Value)
        Me.txtPartId.Text = DbOperateUtils.DBNullToStr(dgvQuery.CurrentRow.Cells("ppartid").Value)
        Me.txtFirmwareVersion.Text = DbOperateUtils.DBNullToStr(dgvQuery.CurrentRow.Cells("FirmwareVersion").Value)
        Me.txtHardwareVersion.Text = DbOperateUtils.DBNullToStr(dgvQuery.CurrentRow.Cells("HardwareVersion").Value)
        opflag = 2
        ToolbtnState(2)
    End Sub


#Region "Grid行数"

    Private Sub dgvEquipment_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvQuery.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

#End Region

    Private Sub LoadDataInGrid()

        Dim dt As DataTable
        dgvQuery.Rows.Clear()
        dgvQuery.ScrollBars = ScrollBars.None
        Dim Sqlstr As String = "select moid,partid,FirmwareVersion,HardwareVersion,Userid,UpdateTime from m_moidFirmwareVersion_t where 1=1" + GetSqlWhere()
        dt = DbOperateUtils.GetDataTable(Sqlstr)
        For Each row As DataRow In dt.Rows
            dgvQuery.Rows.Add(row("moid").ToString(), row("partid").ToString(), row("FirmwareVersion").ToString(), row("HardwareVersion").ToString(), row("Userid").ToString(), row("UpdateTime").ToString())
        Next
    End Sub

    Private Function CheckInput() As Boolean
        Try
            If Me.txtFirmwareVersion.Text = "" Then
                MessageUtils.ShowError("请输入固件版本！")
                txtFirmwareVersion.Select()
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return True
    End Function

    Private Function SaveData() As Boolean
        Dim strSql As String = ""
        Dim strBSQL As New System.Text.StringBuilder
        Try
            If opflag = 1 Then

                '工单是否已维护固件版本
                strSql = "SELECT 1 FROM m_moidFirmwareVersion_t(nolock) where moid=N'" & Me.txtMoId.Text & "'"
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowError("工单:" + Me.txtMoId.Text + " 已维护固件版本!")
                    Return False
                End If
                strSql = " INSERT INTO m_moidFirmwareVersion_t(moid,partid,FirmwareVersion,HardwareVersion,Userid,UpdateTime)"
                strBSQL.Append(strSql)
                strBSQL.Append(" VALUES(")
                strBSQL.AppendFormat("'{0}',", Me.txtMoId.Text)
                strBSQL.AppendFormat("'{0}',", Me.txtPartId.Text)
                strBSQL.AppendFormat("'{0}',", Me.txtFirmwareVersion.Text)
                strBSQL.AppendFormat("'{0}',", Me.txtHardwareVersion.Text)
                strBSQL.AppendFormat("'{0}',", VbCommClass.VbCommClass.UseId)
                strBSQL.AppendFormat("getdate()")
                strBSQL.Append(");")

            ElseIf opflag = 2 Then
                strSql = "UPDATE m_moidFirmwareVersion_t "
                strBSQL.Append(strSql)
                strBSQL.AppendFormat(" set FirmwareVersion='{0}',", Me.txtFirmwareVersion.Text)
                strBSQL.AppendFormat("  HardwareVersion = '{0}' ,", Me.txtHardwareVersion.Text)
                strBSQL.AppendFormat("  Userid = '{0}', ", VbCommClass.VbCommClass.UseId)
                strBSQL.AppendFormat("  UpdateTime = getdate()")
                strBSQL.AppendFormat(" WHERE moid = '{0}'", Me.txtMoId.Text)
            End If
            DbOperateUtils.ExecSQL(strBSQL.ToString)
            Return True
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            Return False
        End Try
    End Function

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub
End Class