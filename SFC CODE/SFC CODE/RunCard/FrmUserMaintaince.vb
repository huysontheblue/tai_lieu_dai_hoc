Imports MainFrame.SysDataHandle
Imports LXWarehouseManage
Imports System.Windows.Forms

Public Class FrmUserMaintaince


    Private Sub FrmUserMaintaince_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not sConn Is Nothing Then
            sConn = Nothing
        End If
    End Sub

    Private Sub FrmUserMaintaince_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            LoadDept(MaintainType.DownLoad)
            LoadDept(MaintainType.Manual)
            SetControlStatus(ActionEnum.Load)
            PagerPaging.PagerGrid.DataGrid = Me.dgvUserInfo
            PagerPaging.LoadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private sConn As New SysDataBaseClass

    Public Enum ActionEnum
        Load
        Add
        Eidt
        DownLoad
        Query
        Refresh
        Rollback
        Save
    End Enum

    Public Enum MaintainType
        Manual
        DownLoad
    End Enum

    Private Sub LoadDept(ByVal type As MaintainType)
        Dim sql As String = "SELECT  DEPTID VALUE, DQC TEXT FROM M_RUNCARDDEPARTMENT_T WHERE  LISTALLY='Y' AND USEY='Y' AND DTYPE='R'"
        Dim dt As DataTable = sConn.GetDataTable(sql)
        dt.Rows.InsertAt(dt.NewRow, 0)
        Select Case type
            Case MaintainType.Manual
                cboDept.DisplayMember = "TEXT"
                cboDept.ValueMember = "VALUE"
                cboDept.DataSource = dt
            Case MaintainType.DownLoad
                cboDeptLoad.DisplayMember = "TEXT"
                cboDeptLoad.ValueMember = "VALUE"
                cboDeptLoad.DataSource = dt
        End Select
    End Sub

    Private Sub LoadLine(ByVal type As MaintainType, ByVal dept As String)
        Dim sql As String = "SELECT LINEID VALUE ,LINEID TEXT FROM M_RUNCARDDEPARTMENTLINE_T WHERE DEPTID='" & dept & "'"
        Dim dt As DataTable = sConn.GetDataTable(sql)
        dt.Rows.InsertAt(dt.NewRow, 0)

        Select Case type
            Case MaintainType.Manual
                cboLine.DisplayMember = "TEXT"
                cboLine.ValueMember = "VALUE"
                cboLine.DataSource = dt
            Case MaintainType.DownLoad
                cboLineLoad.DisplayMember = "TEXT"
                cboLineLoad.ValueMember = "VALUE"
                cboLineLoad.DataSource = dt
        End Select
    End Sub

    Private Sub cboDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDept.SelectedIndexChanged
        Try
            If Not cboDept.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboDept.SelectedValue.ToString) Then
                LoadLine(MaintainType.Manual, cboDept.SelectedValue.ToString)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboDeptLoad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDeptLoad.SelectedIndexChanged
        Try
            If Not cboDeptLoad.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboDeptLoad.SelectedValue.ToString) Then
                LoadLine(MaintainType.DownLoad, cboDeptLoad.SelectedValue.ToString)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private operation As ActionEnum = ActionEnum.DownLoad
    Private Sub SetControlStatus(ByVal action As ActionEnum)
        Select Case action
            Case ActionEnum.Load
                ToolDownLoad.Enabled = True
                ToolNew.Enabled = False
                ToolEdit.Enabled = False
                ToolRefresh.Enabled = False
                ToolQuery.Enabled = False
                ToolSave.Enabled = False
                ToolRollback.Enabled = True
                operation = ActionEnum.Load
            Case ActionEnum.DownLoad
                ToolDownLoad.Enabled = True
                ToolNew.Enabled = False
                ToolEdit.Enabled = False
                ToolRefresh.Enabled = False
                ToolQuery.Enabled = False
                'ToolSave.Enabled = True
                ToolRollback.Enabled = True
                PagerPaging.Visible = False
                operation = ActionEnum.DownLoad
            Case ActionEnum.Rollback
                ToolDownLoad.Enabled = Not ToolDownLoad.Enabled
                ToolNew.Enabled = Not ToolDownLoad.Enabled
                ToolEdit.Enabled = Not ToolDownLoad.Enabled
                ToolQuery.Enabled = Not ToolDownLoad.Enabled
                ToolRefresh.Enabled = False
                ToolRollback.Enabled = True
                ToolSave.Enabled = False
                lblRecord.Visible = False
                Me.PagerPaging.Visible = True
                operation = ActionEnum.Rollback
            Case ActionEnum.Add
                ToolEdit.Enabled = False
                ToolDownLoad.Enabled = False
                ToolQuery.Enabled = False
                ToolRefresh.Enabled = False
                ToolRollback.Enabled = True
                ToolSave.Enabled = True
                operation = ActionEnum.Add
            Case ActionEnum.Eidt
                ToolNew.Enabled = False
                ToolDownLoad.Enabled = False
                ToolQuery.Enabled = False
                ToolRefresh.Enabled = False
                ToolRollback.Enabled = True
                ToolSave.Enabled = True
            Case ActionEnum.Query
                ToolNew.Enabled = False
                ToolDownLoad.Enabled = False
                ToolEdit.Enabled = False
                ToolRefresh.Enabled = True
                ToolRollback.Enabled = True
                ToolSave.Enabled = False
                operation = ActionEnum.Query
            Case ActionEnum.Save
                ToolSave.Enabled = False
                ToolRollback.Enabled = True
                Me.PagerPaging.Visible = True
                operation = ActionEnum.Save
                'Case ActionEnum.Query
                '    operation = ActionEnum.Query
                'Case ActionEnum.Add, ActionEnum.Eidt, ActionEnum.Rollback, ActionEnum.Save, ActionEnum.DownLoad
                '    operation = ActionEnum.DownLoad
        End Select
        SetUiEditControlStatus(action)
    End Sub

    Private Sub SetUiEditControlStatus(ByVal action As ActionEnum)
        Select Case action
            Case ActionEnum.DownLoad, ActionEnum.Load
                txtUserId.Enabled = False
                txtUserName.Enabled = False
                cboDept.Enabled = False
                cboLine.Enabled = False
                cboDeptLoad.Enabled = True
                cboLineLoad.Enabled = True
            Case ActionEnum.Rollback
                txtUserId.Enabled = False
                txtUserName.Enabled = False
                cboDept.Enabled = False
                cboLine.Enabled = False
                cboDeptLoad.Enabled = ToolDownLoad.Enabled
                cboLineLoad.Enabled = ToolDownLoad.Enabled
            Case ActionEnum.Add, ActionEnum.Eidt, ActionEnum.Query
                txtUserId.Enabled = True
                txtUserName.Enabled = True
                cboDept.Enabled = True
                cboLine.Enabled = True
                cboDeptLoad.Enabled = False
                cboLineLoad.Enabled = False
            Case ActionEnum.Save
                cboDept.SelectedIndex = -1
                cboDeptLoad.SelectedIndex = -1
                cboLine.SelectedIndex = -1
                cboLineLoad.SelectedIndex = -1
                txtUserId.Text = String.Empty
                txtUserName.Text = String.Empty
        End Select
    End Sub

    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click
        Try
            SetControlStatus(ActionEnum.Add)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEdit.Click
        Try
            SetControlStatus(ActionEnum.Eidt)
            txtUserId.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolDownLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDownLoad.Click
        Try
            Me.PagerPaging.Visible = False
            SetControlStatus(ActionEnum.DownLoad)
            If Not CheckBasicInput(ActionEnum.DownLoad) Then Exit Sub
            QueryDataFromErp()
            PagerPaging.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function CheckBasicInput(ByVal action As ActionEnum) As Boolean
        Select Case action
            Case ActionEnum.DownLoad
                If Not String.IsNullOrEmpty(txtUserIdLoad.Text) Then Return True
                If Not cboDeptLoad.Text Is Nothing AndAlso Not String.IsNullOrEmpty(cboDeptLoad.Text.ToString) Then
                Else
                    MessageBox.Show("请选择部门编号")
                    cboDeptLoad.Select()
                    Return False
                End If
                If Not cboLineLoad.Text Is Nothing AndAlso Not String.IsNullOrEmpty(cboLineLoad.Text.ToString) Then
                Else
                    MessageBox.Show("请选择线别")
                    cboLineLoad.Select()
                    Return False
                End If
                Return True
            Case ActionEnum.Add, ActionEnum.Eidt
                If String.IsNullOrEmpty(txtUserId.Text) Then
                    MessageBox.Show("请输入员工编号")
                    txtUserId.Select()
                    Return False
                End If
                If String.IsNullOrEmpty(txtUserName.Text) Then
                    MessageBox.Show("请输入员工姓名")
                    txtUserName.Select()
                    Return False
                End If
                If Not cboDept.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboDept.SelectedValue.ToString) Then
                Else
                    MessageBox.Show("请选择部门编号")
                    cboDept.Select()
                    Return False
                End If
                If Not cboLine.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboLine.SelectedValue.ToString) Then
                Else
                    MessageBox.Show("请选择线别")
                    cboLine.Select()
                    Return False
                End If
                Return True
        End Select
    End Function

    Public oConn As New OracleDb("")
    Private Sub QueryDataFromErp()
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtUserIdLoad.Text.Trim) Then
            sql = "SELECT DISTINCT '',CPF29 部门编号,GEM03 部门描述,CPF01 员工工号 ,CPF02 员工姓名," & vbNewLine & _
                          " CPF37 线别 FROM " & VbCommClass.VbCommClass.Factory & ".CPF_FILE A," & VbCommClass.VbCommClass.Factory & ".GEM_FILE B," & VbCommClass.VbCommClass.Factory & ".TC_IMC_FILE C" & vbNewLine & _
                          " WHERE A.CPF29=B.GEM01 AND A.CPF37=C.TC_IMC01 AND CPF35 IS NULL"
            If Not String.IsNullOrEmpty(txtUserIdLoad.Text.Trim) Then
                sql += " AND CPF01='" & txtUserIdLoad.Text.Trim & "'"
            End If
        Else
            sql = "SELECT DISTINCT '',CPF29 部门编号,GEM03 部门描述,CPF01 员工工号 ,CPF02 员工姓名," & vbNewLine & _
                           " CPF37 线别 FROM " & VbCommClass.VbCommClass.Factory & ".CPF_FILE A," & VbCommClass.VbCommClass.Factory & ".GEM_FILE B," & VbCommClass.VbCommClass.Factory & ".TC_IMC_FILE C" & vbNewLine & _
                           " WHERE A.CPF29=B.GEM01 AND A.CPF37=C.TC_IMC01 AND CPF35 IS NULL"
            If Not cboDeptLoad.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboDeptLoad.SelectedValue.ToString) Then
                sql += " AND UPPER(A.CPF29)='" & cboDeptLoad.SelectedValue.ToString.ToUpper & "'"
            ElseIf Not cboDeptLoad.Text Is Nothing AndAlso Not String.IsNullOrEmpty(cboDeptLoad.Text.ToString) Then
                sql += " AND UPPER(A.CPF29)='" & cboDeptLoad.Text.ToString.ToUpper & "'"
            End If
            If Not cboLineLoad.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboLineLoad.SelectedValue.ToString) Then
                sql += " AND UPPER(A.CPF37)='" & cboLineLoad.SelectedValue.ToString.ToUpper & "'"
            ElseIf Not cboLineLoad.Text Is Nothing AndAlso Not String.IsNullOrEmpty(cboLineLoad.Text.ToString) Then
                sql += " AND UPPER(A.CPF37)='" & cboLineLoad.Text.ToString.ToUpper & "'"
            End If
        End If
        If Not String.IsNullOrEmpty(sql) Then
            Using dv As DataView = oConn.getDataView(sql)
                If Not dv Is Nothing Then
                    lblMsg.Text = "查找信息如下"
                    dgvUserInfo.DataSource = dv.Table
                    dgvUserInfo.Columns(0).Visible = False
                    lblRecord.Text = "共" & dv.Table.Rows.Count & "笔"
                    lblRecord.Visible = True
                    RemoveHandler Me.dgvUserInfo.ColumnHeaderMouseClick, AddressOf PagerPaging.OnSortCommand
                    ToolSave.Enabled = True
                Else
                    dgvUserInfo.DataSource = Nothing
                    lblMsg.Text = "无记录，请确认是直接人员或在职!!"
                    ToolSave.Enabled = False
                End If
            End Using
        End If
    End Sub

    Private sqlS As New System.Text.StringBuilder
    Private tool As New MainFrame.SysCheckData.TextHandle
    Private Sub ToolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSave.Click
        Try
            Dim sql As String = Nothing
            If ToolDownLoad.Enabled = True Then
                If sqlS.Length > 0 Then sqlS.Remove(0, sqlS.Length)
                For Each row As DataGridViewRow In dgvUserInfo.Rows
                    sqlS.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM M_USERS_T WHERE USERID='" & row.Cells(UserGrid.UserId).Value.ToString & "')").Append(vbNewLine)
                    sqlS.Append(" BEGIN ").Append(vbNewLine)
                    sqlS.Append(" INSERT INTO M_USERS_T(USERID,USERNAME,PASSWORD,DEPT,GROUPID,AUTOID,FACTORYID,USEY,CREATER,INTIME,LINEID)").Append(vbNewLine)
                    sqlS.Append(" VALUES('" & row.Cells(UserGrid.UserId).Value.ToString & "',N'" & row.Cells(UserGrid.UserName).Value.ToString & "',").Append(vbNewLine)
                    sqlS.Append("'" & tool.EnCryptPassword(123) & "','" & row.Cells(UserGrid.Dept).Value.ToString & "',N'操作员','" & tool.EnCryptPassword(123) & "',").Append(vbNewLine)
                    sqlS.Append("(SELECT TOP 1 FACTORYID FROM M_RUNCARDDEPARTMENT_T WHERE DEPTID='" & row.Cells(UserGrid.Dept).Value.ToString & "'),").Append(vbNewLine)
                    sqlS.Append("1,'" & VbCommClass.VbCommClass.UseId & "',GETDATE(),'" & row.Cells(UserGrid.LineId).Value.ToString & "')").Append(vbNewLine)
                    sqlS.Append(" END").Append(vbNewLine)
                Next
                'If Not sqlS Is Nothing AndAlso Not String.IsNullOrEmpty(sqlS.ToString) Then sConn.ExecSql(sqlS.ToString)
                'SetControlStatus(ActionEnum.Save)
            ElseIf ToolNew.Enabled = True Then
                If Not BasicInputCheck() Then Exit Sub
                If sqlS.Length > 0 Then sqlS.Remove(0, sqlS.Length)
                sqlS.Append("INSERT INTO M_USERS_T(USERID,USERNAME,PASSWORD,DEPT,GROUPID,AUTOID,USEY,INTIME,CREATER,LINEID,FACTORYID)").Append(vbNewLine)
                sqlS.Append(" VALUES('" & txtUserId.Text.Trim & "',N'" & txtUserName.Text.Trim & "','" & tool.EnCryptPassword(123) & "',").Append(vbNewLine)
                sqlS.Append(" '" & cboDept.SelectedValue.ToString & "',N'操作员','" & tool.EnCryptPassword(123) & "',1,GETDATE(),").Append(vbNewLine)
                sqlS.Append("'" & VbCommClass.VbCommClass.UseId & "','" & cboLine.SelectedValue.ToString & "',(SELECT TOP 1 FACTORYID FROM M_RUNCARDDEPARTMENT_T WHERE DEPTID='" & cboDept.SelectedValue.ToString & "'))")
            ElseIf ToolEdit.Enabled = True Then
                If Not BasicInputCheck() Then Exit Sub
                If sqlS.Length > 0 Then sqlS.Remove(0, sqlS.Length)
                sqlS.Append("UPDATE M_USERS_T SET USERNAME=N'" & txtUserName.Text.Trim & "',LINEID='" & cboLine.SelectedValue.ToString & "',").Append(vbNewLine)
                sqlS.Append(" DEPT='" & cboDept.SelectedValue.ToString & "' WHERE USERID='" & txtUserId.Text.Trim & "'")
            End If
            If Not sqlS Is Nothing AndAlso Not String.IsNullOrEmpty(sqlS.ToString) Then sConn.ExecSql(sqlS.ToString)
            MessageBox.Show("保存成功")
            lblRecord.Visible = False
            SetControlStatus(ActionEnum.Save)
            PagerPaging.LoadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If sqlS.Length > 0 Then sqlS.Remove(0, sqlS.Length)
        End Try
    End Sub

    Private Function BasicInputCheck() As Boolean
        If String.IsNullOrEmpty(txtUserId.Text) Then
            MessageBox.Show("员工工号不能为空")
            Return False
        End If
        If String.IsNullOrEmpty(txtUserName.Text) Then
            MessageBox.Show("员工姓名不能为空")
            Return False
        End If
        If Not cboDept.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboDept.SelectedValue.ToString) Then
        Else
            MessageBox.Show("请选择部门")
            Return False
        End If
        If Not cboLine.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboLine.SelectedValue.ToString) Then
        Else
            MessageBox.Show("请选择线别")
            Return False
        End If
        If ToolNew.Enabled = True Then
            Dim sql As String = "SELECT USERID FROM M_USERS_T WHERE USERID='" & txtUserId.Text.Trim & "'"
            If sConn.GetRowsCount(sql) > 0 Then
                MessageBox.Show("该员工工号已存在，请确认")
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        Try
            SetControlStatus(ActionEnum.Query)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRefresh.Click
        Try
            SetControlStatus(ActionEnum.Refresh)
            PagerPaging.LoadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TollExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TollExit.Click
        Me.Close()
    End Sub

    Private Sub LoadUserData() Handles PagerPaging.Paging
        Dim sql As String = "SELECT A.DEPT 部门编号,B.DQC 部门描述, USERID 员工工号,USERNAME 员工姓名,LINEID 线别,INTIME 创建时间 " & vbNewLine & _
        " FROM M_USERS_T A LEFT JOIN M_RUNCARDDEPARTMENT_T B ON A.DEPT=B.DEPTID WHERE 1=1 AND LINEID IS NOT NULL"
        If operation = ActionEnum.Query Then
            sql += GetSqlWhere()
        End If
        LoadData(sql)
    End Sub

    Private Function GetSqlWhere() As String
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtUserId.Text) Then
            sql += " AND A.USERID='" & txtUserId.Text.Trim & "'"
        End If
        If Not String.IsNullOrEmpty(txtUserName.Text) Then
            sql += " AND A.USERNAME=N'" & txtUserName.Text.Trim & "'"
        End If
        If Not cboDept.Text Is Nothing AndAlso Not String.IsNullOrEmpty(cboDept.Text.ToString) Then
            sql += " AND A.DEPT=N'" & cboDept.Text.ToString & "'"
        End If
        If Not cboLine.Text Is Nothing AndAlso Not String.IsNullOrEmpty(cboLine.Text.ToString) Then
            sql += " AND A.LINEID=N'" & cboLine.Text.ToString & "'"
        End If
        Return IIf(String.IsNullOrEmpty(sql), "", sql)
    End Function

    Private Sub LoadData(ByVal sql As String)
        Using dt As DataTable = PagerPaging.GetPagingDataTable(sql, sConn.GetConnectionString, True)
            dgvUserInfo.DataSource = dt
            dgvUserInfo.Columns(0).HeaderText = "序号"
            For Each col As DataGridViewColumn In dgvUserInfo.Columns
                col.SortMode = DataGridViewColumnSortMode.Programmatic
            Next
            dgvUserInfo.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvUserInfo.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        End Using
        RemoveHandler Me.dgvUserInfo.ColumnHeaderMouseClick, AddressOf PagerPaging.OnSortCommand
        AddHandler Me.dgvUserInfo.ColumnHeaderMouseClick, AddressOf PagerPaging.OnSortCommand
    End Sub

    Private Enum UserGrid
        Seq = 0
        Dept
        DeptDesc
        UserId
        UserName
        LineId
        InTime
    End Enum

    Private Sub ToolRollback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRollback.Click
        Try
            SetControlStatus(ActionEnum.Rollback)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvUserInfo_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUserInfo.CellClick
        Try
            If Not operation = ActionEnum.Query Then
                If dgvUserInfo.Rows.Count <= 0 Then
                    MessageBox.Show("没有可选择的信息")
                    Exit Sub
                End If
                txtUserId.Text = dgvUserInfo.CurrentRow.Cells(UserGrid.UserId).Value.ToString
                txtUserName.Text = dgvUserInfo.CurrentRow.Cells(UserGrid.UserName).Value.ToString
                cboDept.SelectedValue = dgvUserInfo.CurrentRow.Cells(UserGrid.Dept).Value.ToString
                cboLine.SelectedValue = dgvUserInfo.CurrentRow.Cells(UserGrid.LineId).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


End Class