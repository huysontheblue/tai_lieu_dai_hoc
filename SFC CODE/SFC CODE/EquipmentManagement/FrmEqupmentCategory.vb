Imports MainFrame.SysCheckData
Imports MainFrame

''' <summary>
''' 修改者： 田玉琳
''' 修改日： 2015/11/11
''' 修改内容：表变更
''' </summary>
''' <remarks>修改流程卡后影响范围</remarks>
Public Class FrmEqupmentCategory

    '变量定义
    Dim OperateFlag As EditMode '操作模式

    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum

    Private Sub FrmEqupmentCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            '设置操作模式
            OperateFlag = EditMode.UNDO
            '工具栏控件状态
            SetControlStatus(EditMode.UNDO)
            '
            EquManageCommon.BindComboxCategory(cboCategory, "MID")

            BindData()
        End If
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
    Private Sub toolRefresh_Click(sender As Object, e As EventArgs) Handles toolRefresh.Click
        Try
            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEqupmentCategory", "toolRefresh_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
    Private Sub toolUndo_Click(sender As Object, e As EventArgs) Handles toolUndo.Click
        '设置操作模式
        OperateFlag = EditMode.UNDO
        '工具栏控件状态
        SetControlStatus(EditMode.UNDO)
    End Sub
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            Dim strSQL As String = String.Empty
            Dim insertSql As New System.Text.StringBuilder
            Dim categoryName As String = txtCategoryName.Text.Trim

            If String.IsNullOrEmpty(cboCategory.SelectedValue.ToString) = True Then
                MessageUtils.ShowError("请选择工治具分类!")
                Exit Sub
            End If

            If String.IsNullOrEmpty(txtCategoryName.Text.ToString) = True Then
                MessageUtils.ShowError("请输入类别名称!")
                Exit Sub
            End If

            If OperateFlag = EditMode.EDIT Then
                If String.IsNullOrEmpty(txtType.Text.ToString) = True Then
                    MessageUtils.ShowError("请输入选择更新数据!")
                    Exit Sub
                End If
            End If

            If OperateFlag = EditMode.ADD Then
                strSQL = "SELECT 1 from m_EquipmentCategory_t where NAME = N'{0}'"
                strSQL = String.Format(strSQL, categoryName)

                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowError("类别名称" + categoryName + "已存在!")
                    Exit Sub
                End If

                'strSQL = "INSERT INTO [m_EquipmentCategory_t] " &
                '        "([CODE] ,NAME,[Description] ,[Status] ,[UserID]  ,[InTime] ,[TYPE] , " &
                '        "[ServiceCount] ,[AlertCount] ,[RemainCount] ,[FactoryName] ,[Profitcenter]) "
                'insertSql.Append(strSQL)
                'insertSql.Append(" VALUES(")
                'insertSql.AppendFormat("N'{0}',", CODE)
                'insertSql.AppendFormat("N'{0}',", categoryName)
                'insertSql.AppendFormat("N'{0}',", txtDescription.Text.Trim)
                'insertSql.AppendFormat("'1',")
                'insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.UseId)
                'insertSql.AppendFormat("getdate(),")
                'insertSql.AppendFormat("N'{0}',", cboCategory.SelectedValue.ToString)
                'insertSql.AppendFormat("N'{0}',", txtServiceCount.Text.Trim)
                'insertSql.AppendFormat("N'{0}',", txtAlertCount.Text.Trim)
                'insertSql.AppendFormat("N'{0}',", txtServiceCount.Text.Trim)
                'insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.Factory)
                'insertSql.AppendFormat("N'{0}'", VbCommClass.VbCommClass.profitcenter)
                'insertSql.Append(");")

                'DbOperateUtils.ExecSQL(insertSql.ToString)
            ElseIf OperateFlag = EditMode.EDIT Then
                strSQL = "UPDATE [m_EquipmentCategory_t] "
                insertSql.Append(strSQL)

                insertSql.AppendFormat("SET NAME = N'{0}' ", categoryName)
                insertSql.AppendFormat(",Description = N'{0}'", txtDescription.Text.Trim)
                insertSql.AppendFormat(",UserID = N'{0}'", VbCommClass.VbCommClass.UseId)
                insertSql.AppendFormat(",InTime = getdate()")
                'insertSql.AppendFormat(",TYPE = '{0}'", cboCategory.SelectedValue.ToString)
                insertSql.AppendFormat(",ServiceCount = '{0}'", txtServiceCount.Text.Trim)
                insertSql.AppendFormat(",AlertCount = '{0}'", txtAlertCount.Text.Trim)
                insertSql.AppendFormat(",RemainCount = '{0}'", txtServiceCount.Text.Trim)
                insertSql.AppendFormat(",FactoryName = '{0}'", VbCommClass.VbCommClass.Factory)
                insertSql.AppendFormat(",Profitcenter = '{0}'", VbCommClass.VbCommClass.profitcenter)
                insertSql.AppendFormat(" WHERE ID = '{0}'", lblId.Text)

                DbOperateUtils.ExecSQL(insertSql.ToString)
            End If

            '设置操作模式
            OperateFlag = EditMode.UNDO
            '工具栏控件状态
            SetControlStatus(EditMode.UNDO)

            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEqupmentCategory", "toolSave_Click", "Equ")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub ClearText()
        cboCategory.SelectedValue = ""
        txtType.Text = ""
        txtCategoryName.Text = ""
        txtDescription.Text = ""
        txtServiceCount.Text = ""
        txtAlertCount.Text = ""
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        '设置操作模式
        OperateFlag = EditMode.EDIT
        '工具栏控件状态
        SetControlStatus(EditMode.EDIT)
    End Sub
    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        '设置操作模式
        OperateFlag = EditMode.ADD
        '工具栏控件状态
        SetControlStatus(EditMode.ADD)
    End Sub

    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        '设置操作模式
        OperateFlag = EditMode.SEARCH
        '工具栏控件状态
        SetControlStatus(EditMode.SEARCH)
    End Sub

    Private Sub SetControlStatus(ByVal flag As EditMode)

        SetButtonEnable(False)

        Select Case UCase(flag)
            Case EditMode.ADD '新增   
                toolSave.Enabled = True
                toolUndo.Enabled = True
                cboCategory.Enabled = False
                SetControlEnable(True)
            Case EditMode.EDIT '修改
                toolSave.Enabled = True
                toolUndo.Enabled = True
                cboCategory.Enabled = False
                SetControlEnable(True)
            Case EditMode.UNDO '初始化
                'toolNew.Enabled = True
                toolEdit.Enabled = True
                toolSearch.Enabled = True
                SetControlEnable(False)
                ClearText()
            Case EditMode.SEARCH '搜索
                toolUndo.Enabled = True
                toolRefresh.Enabled = True
                cboCategory.Enabled = True
                'GridList.Enabled = True
                SetControlEnable(True)
        End Select
    End Sub

    Private Sub SetButtonEnable(bFlag As Boolean)
        toolNew.Enabled = bFlag
        toolEdit.Enabled = bFlag
        toolSave.Enabled = bFlag
        toolUndo.Enabled = bFlag
        toolSearch.Enabled = bFlag
        toolRefresh.Enabled = bFlag
    End Sub

    Private Sub SetControlEnable(bFlag As Boolean)
        'Me.txtPartNumber.Enabled = bFlag
        'Me.txtHardWareFormat.Enabled = bFlag
        'Me.txtHardWarePartNumber.Enabled = bFlag
    End Sub

    Private Sub BindData()
        Dim strSql As String =
            " SELECT A.ID ,A.CODE, A.NAME ,A.Description ,CASE A.Status WHEN '1' THEN '1.有效' ELSE '0.无效' END Status, " &
            " C.NAME TYPEName, C.CODE TYPECode, A.ServiceCount ,A.AlertCount ,A.RemainCount ,ISNULL(B.UserName,'')UserName , A.InTime " &
            " FROM dbo.m_EquipmentCategory_t A LEFT JOIN m_Users_t B ON A.UserID=B.UserID " &
            " LEFT JOIN m_EquipmentCategory_t C ON A.TYPE = C.CODE " &
            " WHERE 1=1 AND A.TYPE <> 'BIG' AND A.TYPE <> 'MID' "

        Dim strWhere As New System.Text.StringBuilder

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboCategory.SelectedValue)) = False Then
            strWhere.AppendFormat(" and A.TYPE = '{0}' ", cboCategory.SelectedValue.ToString)
        End If

        If String.IsNullOrEmpty(txtCategoryName.Text) = False Then
            strWhere.AppendFormat(" and A.NAME like N'%{0}%' ", txtCategoryName.Text.Trim)
        End If

        If String.IsNullOrEmpty(txtDescription.Text) = False Then
            strWhere.AppendFormat(" and A.Description like '%{0}%' ", txtDescription.Text.Trim)
        End If
        strSql = strSql + strWhere.ToString
        strSql += " order by ID asc "

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

        dgGrid.DataSource = dt
    End Sub

    Private Sub dgGrid_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgGrid.CellClick
        If Me.dgGrid.RowCount < 1 Then Exit Sub
        '新增、查询 模式下不可操作
        If OperateFlag = EditMode.ADD Or OperateFlag = EditMode.EDIT Or OperateFlag = EditMode.SEARCH Then
            Exit Sub
        End If

        Me.cboCategory.SelectedValue = Me.dgGrid.Item("TYPECode", Me.dgGrid.CurrentRow.Index).Value.ToString.Trim()
        Me.txtType.Text = Me.dgGrid.Item("CODE", Me.dgGrid.CurrentRow.Index).Value.ToString.Trim()
        Me.txtCategoryName.Text = Me.dgGrid.Item("CategoryNAME", Me.dgGrid.CurrentRow.Index).Value.ToString.Trim()
        Me.txtServiceCount.Text = Me.dgGrid.Item("ServiceCount", Me.dgGrid.CurrentRow.Index).Value.ToString.Trim()
        Me.txtAlertCount.Text = Me.dgGrid.Item("AlertCount", Me.dgGrid.CurrentRow.Index).Value.ToString.Trim()
        Me.txtDescription.Text = Me.dgGrid.Item("Description", Me.dgGrid.CurrentRow.Index).Value.ToString.Trim()
        Me.lblId.Text = Me.dgGrid.Item("ID", Me.dgGrid.CurrentRow.Index).Value.ToString.Trim()
    End Sub

End Class