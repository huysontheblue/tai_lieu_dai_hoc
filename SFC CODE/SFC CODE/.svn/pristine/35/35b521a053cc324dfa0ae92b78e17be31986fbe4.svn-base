Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmBuyList

    '变量定义
    Dim OperateFlag As EditMode '操作模式
    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum

    Public Enum enumdgvBuyList
        ApplyUserID


    End Enum

    Private Sub Panel1_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        '设置操作模式
        OperateFlag = EditMode.ADD
        '工具栏控件状态
        SetControlStatus(EditMode.ADD)
    End Sub

    Private Sub SetControlStatus(ByVal flag As EditMode)

        SetButtonEnable(False)

        Select Case UCase(flag)
            Case EditMode.ADD '新增   
                toolSave.Enabled = True
                toolUndo.Enabled = True
                ' cboCategory.Enabled = False
                SetControlEnable(True)
            Case EditMode.EDIT '修改
                toolSave.Enabled = True
                toolUndo.Enabled = True
                ' cboCategory.Enabled = False
                SetControlEnable(True)
            Case EditMode.UNDO '初始化
                toolNew.Enabled = True
                ' toolEdit.Enabled = True
                toolSearch.Enabled = True
                SetControlEnable(False)
                ClearText()
            Case EditMode.SEARCH '搜索
                toolUndo.Enabled = True
                toolRefresh.Enabled = True
                'cboCategory.Enabled = True
                'GridList.Enabled = True
                SetControlEnable(True)
        End Select
    End Sub

    Private Sub ClearText()
        '  cboCategory.SelectedValue = ""
        ' txtType.Text = ""
        ' txtCategoryName.Text = ""
        'txtDescription.Text = ""
        txtUserID.Text = ""
        ' txtAlertCount.Text = ""
    End Sub

    Private Sub SetControlEnable(bFlag As Boolean)
        'Me.txtPartNumber.Enabled = bFlag
        'Me.txtHardWareFormat.Enabled = bFlag
        'Me.txtHardWarePartNumber.Enabled = bFlag
    End Sub

    Private Sub SetButtonEnable(bFlag As Boolean)
        toolNew.Enabled = bFlag
        '  toolEdit.Enabled = bFlag
        toolSave.Enabled = bFlag
        toolUndo.Enabled = bFlag
        toolSearch.Enabled = bFlag
        toolRefresh.Enabled = bFlag
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            Dim strSQL As String = String.Empty
            Dim insertSql As New System.Text.StringBuilder
            Dim o_ApplyUserID As String = txtUserID.Text.Trim

            'If String.IsNullOrEmpty(cboCategory.SelectedValue.ToString) = True Then
            '    MessageUtils.ShowError("请选择工治具分类!")
            '    Exit Sub
            'End If

            If OperateFlag = EditMode.ADD Then
                strSQL = "SELECT 1 FROM m_EquBuyList_t WHERE ApplyUserID = N'{0}' and usey='1' "
                strSQL = String.Format(strSQL, o_ApplyUserID)

                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowError("工号" + o_ApplyUserID + "已存在!")
                    Exit Sub
                End If

                'UserID  varchar(20),
                'UserName nvarchar(20),
                'UserID varchar(20),
                'Intime varchar(20),
                'UseY varchar(10)

                strSQL = "INSERT INTO [m_EquBuyList_t] " &
                        "([ApplyUserID], UserID,[InTime],UseY) "
                insertSql.Append(strSQL)
                insertSql.Append(" VALUES(")
                insertSql.AppendFormat("N'{0}',", o_ApplyUserID)
                insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.UseId)
                insertSql.AppendFormat("getdate(),")
                insertSql.AppendFormat("N'{0}'", "1")
                insertSql.Append(");")

                DbOperateUtils.ExecSQL(insertSql.ToString)
            ElseIf OperateFlag = EditMode.EDIT Then
                'strSQL = "UPDATE [m_EquBuyList_t] "
                'insertSql.Append(strSQL)
                'insertSql.AppendFormat("SET NAME = N'{0}' ", categoryName)
                'insertSql.AppendFormat(",Description = N'{0}'", txtDescription.Text.Trim)
                'insertSql.AppendFormat(",UserID = N'{0}'", VbCommClass.VbCommClass.UseId)
                'insertSql.AppendFormat(",InTime = getdate()")
                'insertSql.AppendFormat(",ServiceCount = '{0}'", txtUserID.Text.Trim)
                'insertSql.AppendFormat(",RemainCount = '{0}'", txtUserID.Text.Trim)
                'insertSql.AppendFormat(",FactoryName = '{0}'", VbCommClass.VbCommClass.Factory)
                'insertSql.AppendFormat(",Profitcenter = '{0}'", VbCommClass.VbCommClass.profitcenter)
                'insertSql.AppendFormat(" WHERE ApplyUserID = '{0}'", lblId.Text)

                'DbOperateUtils.ExecSQL(insertSql.ToString)
            End If

            '设置操作模式
            OperateFlag = EditMode.UNDO
            '工具栏控件状态
            SetControlStatus(EditMode.UNDO)

            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmBuyList", "toolRefresh_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub BindData()
        Dim strSql As String =
            " SELECT (ApplyUserID + '/' +  b.UserName) ApplyUserID , (a.UserID +'/' + c.UserName) as UserID , a.Intime " & _
            " From  m_EquBuyList_t a Left Join m_Users_t b on a.ApplyUserID = b.UserID " & _
            " Left Join m_Users_t c on a.UserID = c.UserID " & _
            " WHERE 1=1  "

        Dim strWhere As New System.Text.StringBuilder

        'If String.IsNullOrEmpty(txtCategoryName.Text) = False Then
        '    strWhere.AppendFormat(" and A.NAME like N'%{0}%' ", txtCategoryName.Text.Trim)
        'End If

        'If String.IsNullOrEmpty(txtDescription.Text) = False Then
        '    strWhere.AppendFormat(" and A.Description like '%{0}%' ", txtDescription.Text.Trim)
        'End If

        strWhere.Append(" and a.usey='1'")

        strSql = strSql + strWhere.ToString

        strSql += " ORDER BY a.intime "

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

        dgvBuyList.DataSource = dt
        Me.dgvBuyList.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    End Sub


    Private Function GetUserName(ByVal strUserID As String)
        Dim lsSQL As String = ""
        lsSQL = " SELECT UserName from m_Users_t where UserID='" & strUserID & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetUserName = o_dt.Rows(0).Item(0)
            Else
                GetUserName = ""
            End If
        End Using
    End Function

    Private Sub toolEdit_Click(sender As Object, e As EventArgs)
        '设置操作模式
        OperateFlag = EditMode.EDIT
        '工具栏控件状态
        SetControlStatus(EditMode.EDIT)
    End Sub

    Private Sub FrmBuyList_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.DesignMode = False Then
            '设置操作模式
            OperateFlag = EditMode.UNDO
            '工具栏控件状态
            SetControlStatus(EditMode.UNDO)
            '
            BindData()
        End If
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click

        Dim lsSQL As String = "", o_strApplyUserID As String = ""
        If Me.dgvBuyList.Rows.Count = 0 OrElse Me.dgvBuyList.CurrentRow Is Nothing Then Exit Sub

        o_strApplyUserID = dgvBuyList.CurrentRow.Cells(enumdgvBuyList.ApplyUserID).Value.ToString.Split("/")(0)
        Try
            lsSQL = " UPDATE m_EquBuyList_t SET usey='0' " & _
                    " WHERE  applyUserID = '" & o_strApplyUserID & "'"

            DbOperateUtils.ExecSQL(lsSQL)
            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmBuyList", "toolAbandon_Click", "Equ")
        End Try

    End Sub

    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click

    End Sub
End Class