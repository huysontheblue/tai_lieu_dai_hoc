Imports MainFrame.SysCheckData
Imports MainFrame
Imports MainFrame.SysDataHandle

Public Class FrmParetoPartId

    '变量定义
    Dim OperateFlag As EditMode '操作模式

    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum


#Region "初期化"
    '初期化
    Private Sub FrmParetoPartId_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            '设定用戶權限
            Dim sysDB As New SysDataBaseClass
            '权限 
            sysDB.GetControlright(Me)
            '设置操作模式
            OperateFlag = EditMode.UNDO
            '工具栏控件状态
            SetControlStatus(EditMode.UNDO)
            ''
            '类别
            KBCom.BindComboxDateIfHaveBlank(cmbType)
            BindData()
        End If
    End Sub
#End Region

#Region "事件"

    '退出 
    Private Sub ExitFrom_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '导入
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click

    End Sub

    '刷新
    Private Sub FileRefresh_Click(sender As Object, e As EventArgs) Handles toolRefresh.Click
        Try
            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmParetoPartId", "toolRefresh_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '查找
    Private Sub Search_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        '设置操作模式
        OperateFlag = EditMode.SEARCH
        '工具栏控件状态
        SetControlStatus(EditMode.SEARCH)
    End Sub

    '撤销
    Private Sub UnDo_Click(sender As Object, e As EventArgs) Handles toolUndo.Click
        '设置操作模式
        OperateFlag = EditMode.UNDO
        '工具栏控件状态
        SetControlStatus(EditMode.UNDO)
    End Sub

    '保存
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            Dim strSQL As String = String.Empty
            Dim insertSql As New System.Text.StringBuilder

            If OperateFlag = EditMode.EDIT Then
                If String.IsNullOrEmpty(cmbType.Text) = True Then
                    MessageUtils.ShowError("请选择要修改的数据!")
                    cmbType.Focus()
                    Exit Sub
                End If
            Else
                If String.IsNullOrEmpty(cmbType.Text) = True Then
                    MessageUtils.ShowError("请选择类别!")
                    cmbType.Focus()
                    Exit Sub
                End If
            End If

            If String.IsNullOrEmpty(cboPartID.Text.ToString) = True Then
                MessageUtils.ShowError("请输入料号!")
                cboPartID.Focus()
                Exit Sub
            End If

            If dtpDateFrom.Value.ToString("yyyy/MM/dd") > dtpDateTo.Value.ToString("yyyy/MM/dd") Then
                MessageUtils.ShowError("请输入有效开始日期小于有效结束日期!")
                dtpDateFrom.Focus()
                Exit Sub
            End If

            If OperateFlag = EditMode.ADD Then

                strSQL = " select * from m_PartContrast_t where TAvcPart  = '{0}' "
                strSQL = String.Format(strSQL, cboPartID.Text.Trim)
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

                If dt.Rows.Count = 0 Then
                    MessageUtils.ShowError(String.Format("料号在基础资料中不存在!", cmbType.Text, cboPartID.Text.Trim))
                    cboPartID.Focus()
                    Exit Sub
                End If

                strSQL = "select 1 from m_AssyTsProcssCheckPartId where TYPE = N'{0}' AND PartID = '{1}'"
                strSQL = String.Format(strSQL, cmbType.SelectedValue.ToString, cboPartID.Text.Trim)

                dt = DbOperateUtils.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowError(String.Format("类型{0}料号{1}已存在!", cmbType.Text, cboPartID.Text.Trim))
                    Exit Sub
                End If

                strSQL = " INSERT INTO m_AssyTsProcssCheckPartId " &
                         " (PartId,TYPE,ValidStartDate,ValidEndDate,IsValid,Remark,UserId,InTime)"
                '" VALUES (@PartId,@TYPE,@ValidStartDate,@ValidEndDate,@IsValid,@Remark,@UserId,getdate())"
                insertSql.Append(strSQL)
                insertSql.Append(" VALUES(")
                insertSql.AppendFormat("N'{0}',", cboPartID.Text.Trim)
                insertSql.AppendFormat("N'{0}',", cmbType.SelectedValue.ToString)
                insertSql.AppendFormat("N'{0}',", dtpDateFrom.Value.ToString("yyyy/MM/dd"))
                insertSql.AppendFormat("N'{0}',", dtpDateTo.Value.ToString("yyyy/MM/dd"))
                insertSql.AppendFormat("'Y',")
                insertSql.AppendFormat("N'{0}',", txtRemark.Text.Trim)
                insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.UseId)
                insertSql.AppendFormat("getdate()")
                insertSql.Append(");")

                DbOperateUtils.ExecSQL(insertSql.ToString)
            ElseIf OperateFlag = EditMode.EDIT Then
                strSQL = "UPDATE [m_AssyTsProcssCheckPartId] "
                insertSql.Append(strSQL)

                insertSql.AppendFormat("SET Remark = N'{0}' ", txtRemark.Text.Trim)
                insertSql.AppendFormat(",ValidStartDate = N'{0}'", dtpDateFrom.Value.ToString("yyyy/MM/dd"))
                insertSql.AppendFormat(",ValidEndDate = N'{0}'", dtpDateTo.Value.ToString("yyyy/MM/dd"))
                insertSql.AppendFormat(",UserID = N'{0}'", VbCommClass.VbCommClass.UseId)
                insertSql.AppendFormat(",IsValid = N'{0}'", IIf(chkIsValid.Checked = True, "Y", "N"))
                insertSql.AppendFormat(",InTime = getdate()")
                insertSql.AppendFormat(" WHERE PartId = '{0}'", cboPartID.Text)
                insertSql.AppendFormat(" AND TYPE = '{0}'", cmbType.SelectedValue.ToString)

                DbOperateUtils.ExecSQL(insertSql.ToString)
            End If

            '设置操作模式
            OperateFlag = EditMode.UNDO
            '工具栏控件状态
            SetControlStatus(EditMode.UNDO)

            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmParetoPartId", "Save_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '删除
    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        Try
            If MessageUtils.ShowConfirm("你确定删除吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            DeleteData()

            '设置操作模式
            OperateFlag = EditMode.UNDO
            '工具栏控件状态
            SetControlStatus(EditMode.UNDO)
            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmParetoPartId", "toolDelete_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '编辑
    Private Sub EditFile_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        '设置操作模式
        OperateFlag = EditMode.EDIT
        '工具栏控件状态
        SetControlStatus(EditMode.EDIT)
    End Sub

    '新增
    Private Sub NewFile_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        '设置操作模式
        OperateFlag = EditMode.ADD
        '工具栏控件状态
        SetControlStatus(EditMode.ADD)
    End Sub

    '点击事件
    Private Sub dgGrid_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgGrid.CellClick
        If Me.dgGrid.RowCount < 1 Then Exit Sub
        '新增、查询 模式下不可操作
        If OperateFlag = EditMode.ADD Or OperateFlag = EditMode.EDIT Or OperateFlag = EditMode.SEARCH Then
            Exit Sub
        End If

        Me.cmbType.Text = Me.dgGrid.Item("colType", Me.dgGrid.CurrentRow.Index).Value.ToString.Trim()
        Me.dtpDateFrom.Text = Me.dgGrid.Item("colStartDate", Me.dgGrid.CurrentRow.Index).Value.ToString.Trim()
        Me.dtpDateTo.Text = Me.dgGrid.Item("colEndDate", Me.dgGrid.CurrentRow.Index).Value.ToString.Trim()
        Me.txtRemark.Text = Me.dgGrid.Item("colRemark", Me.dgGrid.CurrentRow.Index).Value.ToString.Trim()
        Me.cboPartID.Text = Me.dgGrid.Item("colPartId", Me.dgGrid.CurrentRow.Index).Value.ToString.Trim()
        Me.chkIsValid.Checked = IIf(Me.dgGrid.Item("colUsy", Me.dgGrid.CurrentRow.Index).Value.ToString.Trim() = "Y", True, False)
    End Sub

    Private Sub dgGrid_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgGrid.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

    Private Sub DeleteData()
        Dim strSQL As String = " DELETE m_AssyTsProcssCheckPartId where type = '{0}' and PartId = '{1}'"
        strSQL = String.Format(strSQL, cmbType.SelectedValue.ToString, cboPartID.Text.Trim)

        DbOperateUtils.ExecSQL(strSQL)
    End Sub

    '邦定数据
    Private Sub BindData()

        Dim dt As DataTable = KBCom.GetCheckPartIdData(cboPartID.Text, dtpDateFrom.Value.ToString("yyyy/MM/dd"), dtpDateTo.Value.ToString("yyyy/MM/dd"))

        If cmbType.SelectedValue.ToString = "D" Then
            dt.DefaultView.RowFilter = "type = '日' "
        ElseIf cmbType.SelectedValue.ToString = "W" Then
            dt.DefaultView.RowFilter = "type = '周' "
        Else
            dt.DefaultView.RowFilter = ""
        End If

        dgGrid.DataSource = dt
    End Sub

    Private Sub SetControlStatus(ByVal flag As EditMode)

        SetButtonEnable(False)

        Select Case UCase(flag)
            Case EditMode.ADD '新增   
                toolSave.Enabled = True
                toolUndo.Enabled = True
            Case EditMode.EDIT '修改
                toolSave.Enabled = True
                toolUndo.Enabled = True
                cmbType.Enabled = False
                cboPartID.Enabled = False
            Case EditMode.UNDO '初始化
                toolNew.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolNew.Tag) = "YES", True, False))
                toolEdit.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolEdit.Tag) = "YES", True, False))
                toolDelete.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolDelete.Tag) = "YES", True, False))
                toolSearch.Enabled = True
                cmbType.Enabled = True
                cboPartID.Enabled = True
                ClearText()
            Case EditMode.SEARCH '搜索
                toolUndo.Enabled = True
                toolRefresh.Enabled = True
        End Select
    End Sub

    Private Sub SetButtonEnable(bFlag As Boolean)
        toolNew.Enabled = bFlag
        toolEdit.Enabled = bFlag
        toolDelete.Enabled = bFlag
        toolSave.Enabled = bFlag
        toolUndo.Enabled = bFlag
        toolSearch.Enabled = bFlag
        toolRefresh.Enabled = bFlag
    End Sub

    Private Sub ClearText()
        cboPartID.Text = ""
        cmbType.Text = ""
        dtpDateFrom.Text = DateTime.Now.AddDays(-3)
        dtpDateTo.Text = DateTime.Now.AddDays(3)
    End Sub


End Class