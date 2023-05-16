Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports LXWarehouseManage


Public Class FrmUserMaintaince

#Region "变量"

    Private tool As New MainFrame.SysCheckData.TextHandle

    Private operation As ActionEnum = ActionEnum.DownLoad

    Private Enum UserGrid
        Seq = 0
        Dept
        DeptDesc
        UserId
        UserName
        LineId
        InTime
    End Enum

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

#End Region

#Region "事件"


    Private Sub FrmUserMaintaince_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            LoadDept(MaintainType.DownLoad)
            LoadDept(MaintainType.Manual)
            SetControlStatus(ActionEnum.Load)
            PagerPaging.PagerGrid.DataGrid = Me.dgvUserInfo
            PagerPaging.LoadData()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmUserMaintaince", "FrmUserMaintaince_Load", "sys")
        End Try
    End Sub

    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click
        SetControlStatus(ActionEnum.Add)
    End Sub

    Private Sub ToolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEdit.Click
        SetControlStatus(ActionEnum.Eidt)
        txtUserId.Enabled = False
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
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmUserMaintaince", "ToolDownLoad_Click", "sys")
        End Try
    End Sub

    Private Sub cboDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDept.SelectedIndexChanged
        Try
            If Not cboDept.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboDept.SelectedValue.ToString) Then
                LoadLine(MaintainType.Manual, cboDept.SelectedValue.ToString)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmUserMaintaince", "cboDept_SelectedIndexChanged", "sys")
        End Try
    End Sub

    Private Sub cboDeptLoad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDeptLoad.SelectedIndexChanged
        Try
            If Not cboDeptLoad.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboDeptLoad.SelectedValue.ToString) Then
                LoadLine(MaintainType.DownLoad, cboDeptLoad.SelectedValue.ToString)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmUserMaintaince", "cboDeptLoad_SelectedIndexChanged", "sys")
        End Try
    End Sub


    Private Sub ToolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSave.Click
        Try
            Dim sqlS As New System.Text.StringBuilder
            Dim sConn As New SysDataBaseClass
            Dim sql As String = Nothing

            If sqlS.Length > 0 Then sqlS.Remove(0, sqlS.Length)
            If ToolDownLoad.Enabled = True Then

                For Each row As DataGridViewRow In dgvUserInfo.Rows
                    sqlS.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM M_USERS_T WHERE USERID='" & row.Cells(UserGrid.UserId).Value.ToString & "')")
                    sqlS.Append(" BEGIN ")
                    sqlS.Append(" INSERT INTO M_USERS_T(USERID,USERNAME,PASSWORD,DEPT,GROUPID,AUTOID,FACTORYID,USEY,CREATER,INTIME,LINEID)")
                    sqlS.Append(" VALUES('" & row.Cells(UserGrid.UserId.ToString).Value.ToString & "',N'" & row.Cells(UserGrid.UserName.ToString).Value.ToString & "',")
                    sqlS.Append("'" & tool.EnCryptPassword(123) & "','" & row.Cells(UserGrid.Dept.ToString).Value.ToString & "',N'操作员','" & tool.EnCryptPassword(123) & "',")
                    sqlS.Append("(SELECT TOP 1 FACTORYID FROM M_DEPT_T WHERE DEPTID='" & row.Cells(UserGrid.Dept.ToString).Value.ToString & "'),")
                    sqlS.Append("1,'" & VbCommClass.VbCommClass.UseId & "',GETDATE(),'" & row.Cells(UserGrid.LineId.ToString).Value.ToString & "')")
                    sqlS.Append(" END")
                Next
            ElseIf ToolNew.Enabled = True Then
                If Not BasicInputCheck() Then Exit Sub
                sqlS.Append("INSERT INTO M_USERS_T(USERID,USERNAME,PASSWORD,DEPT,GROUPID,AUTOID,USEY,INTIME,CREATER,LINEID,FACTORYID)")
                sqlS.Append(" VALUES('" & txtUserId.Text.Trim & "',N'" & txtUserName.Text.Trim & "','" & tool.EnCryptPassword(123) & "',")
                sqlS.Append(" '" & cboDept.SelectedValue.ToString & "',N'操作员','" & tool.EnCryptPassword(123) & "',1,GETDATE(),")
                sqlS.Append("'" & VbCommClass.VbCommClass.UseId & "','" & cboLine.SelectedValue.ToString & "',(SELECT TOP 1 FACTORYID FROM M_DEPT_T WHERE DEPTID='" & cboDept.SelectedValue.ToString & "'))")
            ElseIf ToolEdit.Enabled = True Then
                If Not BasicInputCheck() Then Exit Sub
                sqlS.Append("UPDATE M_USERS_T SET USERNAME=N'" & txtUserName.Text.Trim & "',LINEID='" & cboLine.SelectedValue.ToString & "',")
                sqlS.Append(" DEPT='" & cboDept.SelectedValue.ToString & "' WHERE USERID='" & txtUserId.Text.Trim & "'")
            End If
            If Not sqlS Is Nothing AndAlso Not String.IsNullOrEmpty(sqlS.ToString) Then sConn.ExecSql(sqlS.ToString)
            MessageUtils.ShowInformation("保存成功")

            lblRecord.Visible = False
            SetControlStatus(ActionEnum.Save)
            PagerPaging.LoadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmUserMaintaince", "ToolSave_Click", "sys")
        End Try
    End Sub

    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        SetControlStatus(ActionEnum.Query)
    End Sub

    Private Sub ToolRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRefresh.Click
        Try
            SetControlStatus(ActionEnum.Refresh)
            PagerPaging.LoadData()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmUserMaintaince", "ToolRefresh_Click", "sys")
        End Try
    End Sub

    Private Sub TollExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TollExit.Click
        Me.Close()
    End Sub

    Private Sub ToolRollback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRollback.Click
         SetControlStatus(ActionEnum.Rollback)
    End Sub

    Private Sub dgvUserInfo_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUserInfo.CellClick
        Try
            If Not operation = ActionEnum.Query Then
                If dgvUserInfo.Rows.Count <= 0 Then
                    MessageUtils.ShowError("没有可选择的信息")
                    Exit Sub
                End If
                txtUserId.Text = dgvUserInfo.CurrentRow.Cells(UserGrid.UserId.ToString).Value.ToString
                txtUserName.Text = dgvUserInfo.CurrentRow.Cells(UserGrid.UserName.ToString).Value.ToString
                cboDept.SelectedValue = dgvUserInfo.CurrentRow.Cells(UserGrid.Dept.ToString).Value.ToString
                cboLine.SelectedValue = dgvUserInfo.CurrentRow.Cells(UserGrid.LineId.ToString).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "方法"
    Private Sub LoadDept(ByVal type As MaintainType)
        Dim sql As String = "SELECT  DEPTID VALUE, DQC TEXT FROM M_DEPT_T WHERE  LISTALLY='Y' AND USEY='Y' AND DTYPE='R'" & GetFatory()
        Dim dt As DataTable = GetDbDataTable(sql)
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

        Dim sql As String = "SELECT LINEID VALUE ,LINEID TEXT FROM DEPTLINE_T WHERE DEPTID='" & dept & "'" & GetFatory()
        Dim dt As DataTable = GetDbDataTable(sql)

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

    Private Function BasicInputCheck() As Boolean
        If String.IsNullOrEmpty(txtUserId.Text) Then
            MessageUtils.ShowError("员工工号不能为空")
            Return False
        End If
        If String.IsNullOrEmpty(txtUserName.Text) Then
            MessageUtils.ShowError("员工姓名不能为空")
            Return False
        End If
        If Not cboDept.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboDept.SelectedValue.ToString) Then
        Else
            MessageUtils.ShowError("请选择部门")
            Return False
        End If
        If Not cboLine.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboLine.SelectedValue.ToString) Then
        Else
            MessageUtils.ShowError("请选择线别")
            Return False
        End If
        If ToolNew.Enabled = True Then
            Dim sql As String = "SELECT USERID FROM M_USERS_T WHERE USERID='" & txtUserId.Text.Trim & "'" & GetFatory()
            Dim dt As DataTable = GetDbDataTable(sql)
            If dt.Rows.Count > 0 Then
                MessageUtils.ShowError("该员工工号已存在，请确认")
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub LoadUserData() Handles PagerPaging.Paging
        Dim sql As String = "SELECT row_number() over (order by USERID) as Seq, A.DEPT ,B.DQC , USERID ,USERNAME ,LINEID ,INTIME  " & _
        " FROM M_USERS_T A LEFT JOIN M_DEPT_T B ON A.DEPT=B.DEPTID WHERE 1=1 AND LINEID IS NOT NULL" & GetFatory("A")
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
            sql += " AND A.DEPT=N'" & cboDept.SelectedValue.ToString & "'"
        End If
        If Not cboLine.Text Is Nothing AndAlso Not String.IsNullOrEmpty(cboLine.Text.ToString) Then
            sql += " AND A.LINEID=N'" & cboLine.SelectedValue.ToString & "'"
        End If
        Return IIf(String.IsNullOrEmpty(sql), "", sql)
    End Function

    Private Sub LoadData(ByVal sql As String)

        Dim dt As DataTable = GetDbDataTable(sql)
        dgvUserInfo.DataSource = dt
        dgvUserInfo.Columns(0).HeaderText = "序号"
        Dim ChColsText As String = "序号|部门编号|部门描述|员工工号|员工姓名|线别|创建时间"
        Dim ChColsName As String = "Seq|Dept|DeptDesc|UserId|UserName|LineId|INTIME"
        Dim colColsText As String() = ChColsText.Split("|")
        Dim colColsName As String() = ChColsName.Split("|")
        For i As Integer = 0 To dgvUserInfo.Columns.Count - 1
            dgvUserInfo.Columns(i).HeaderText = colColsText(i)
            dgvUserInfo.Columns(i).Name = colColsName(i)
        Next
        For Each col As DataGridViewColumn In dgvUserInfo.Columns
            col.SortMode = DataGridViewColumnSortMode.Programmatic
        Next

        dgvUserInfo.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvUserInfo.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable

        RemoveHandler Me.dgvUserInfo.ColumnHeaderMouseClick, AddressOf PagerPaging.OnSortCommand
        AddHandler Me.dgvUserInfo.ColumnHeaderMouseClick, AddressOf PagerPaging.OnSortCommand
    End Sub

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

    Private Function CheckBasicInput(ByVal action As ActionEnum) As Boolean
        Select Case action
            Case ActionEnum.DownLoad
                If Not String.IsNullOrEmpty(txtUserIdLoad.Text) Then Return True
                If Not cboDeptLoad.Text Is Nothing AndAlso Not String.IsNullOrEmpty(cboDeptLoad.Text.ToString) Then
                Else
                    MessageUtils.ShowError("请选择部门编号")
                    cboDeptLoad.Select()
                    Return False
                End If
                If Not cboLineLoad.Text Is Nothing AndAlso Not String.IsNullOrEmpty(cboLineLoad.Text.ToString) Then
                Else
                    MessageUtils.ShowError("请选择线别")
                    cboLineLoad.Select()
                    Return False
                End If
                Return True
            Case ActionEnum.Add, ActionEnum.Eidt
                If String.IsNullOrEmpty(txtUserId.Text) Then
                    MessageUtils.ShowError("请输入员工编号")
                    txtUserId.Select()
                    Return False
                End If
                If String.IsNullOrEmpty(txtUserName.Text) Then
                    MessageUtils.ShowError("请输入员工姓名")
                    txtUserName.Select()
                    Return False
                End If
                If Not cboDept.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboDept.SelectedValue.ToString) Then
                Else
                    MessageUtils.ShowError("请选择部门编号")
                    cboDept.Select()
                    Return False
                End If
                If Not cboLine.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(cboLine.SelectedValue.ToString) Then
                Else
                    MessageUtils.ShowError("请选择线别")
                    cboLine.Select()
                    Return False
                End If
                Return True
        End Select
    End Function

#End Region

    Private Function GetFatory() As String
        Dim strValue As String = String.Empty
        strValue = " AND Factoryid='" & VbCommClass.VbCommClass.Factory & "'"
       
        Return strValue
    End Function

    Private Function GetFatory(table As String) As String
        Dim strValue As String = String.Empty
        strValue = String.Format(" AND {0}.Factoryid='" & VbCommClass.VbCommClass.Factory & "'", table)

        Return strValue
    End Function

    Private Sub QueryDataFromErp()

        Dim strSQL = GetErpSQL(cboDeptLoad.SelectedValue, cboDeptLoad.SelectedText.Trim,
                               cboLineLoad.SelectedValue, cboLineLoad.Text, txtUserIdLoad.Text)

        Dim dt As DataTable = GetErpData(strSQL)

        If dt.Rows.Count > 0 Then
            lblMsg.Text = "查找信息如下"
            dgvUserInfo.DataSource = dt

            Dim ChColsText As String = "序号|部门编号|部门描述|员工工号|员工姓名|线别"
            Dim ChColsName As String = "Seq|Dept|DeptDesc|UserId|UserName|LineId"
            Dim colColsText As String() = ChColsText.Split("|")
            Dim colColsName As String() = ChColsName.Split("|")
            If dt IsNot Nothing Then
                For i As Integer = 0 To dgvUserInfo.Columns.Count - 1
                    dgvUserInfo.Columns(i).HeaderText = colColsText(i)
                    dgvUserInfo.Columns(i).Name = colColsName(i)
                Next
                For i As Integer = 0 To dgvUserInfo.Rows.Count - 1
                    dgvUserInfo.Rows(i).Cells(0).Value = (i + 1).ToString
                Next
            End If
            lblRecord.Text = "共" & dt.Rows.Count & "笔"
            lblRecord.Visible = True
            RemoveHandler Me.dgvUserInfo.ColumnHeaderMouseClick, AddressOf PagerPaging.OnSortCommand
            ToolSave.Enabled = True
        Else
            dgvUserInfo.DataSource = Nothing
            lblMsg.Text = "无记录，请确认是直接人员或在职!!"
            ToolSave.Enabled = False
        End If
    End Sub

    Private Function GetErpSQL(depId As String, depText As String, lineId As String, lineText As String, UserId As String) As String
        Dim sql As String = "SELECT DISTINCT '', CPF29 DepNo,GEM03 DepDes,CPF01 UserId ,CPF02 UserName," & _
                        " CPF37 Line FROM " & VbCommClass.VbCommClass.Factory & ".CPF_FILE A," & VbCommClass.VbCommClass.Factory & ".GEM_FILE B," & _
                        VbCommClass.VbCommClass.Factory & ".TC_IMC_FILE C" & _
                        " WHERE A.CPF29=B.GEM01 AND A.CPF37=C.TC_IMC01 "
        '--AND A.CPF35 IS NOT NULL
        If Not String.IsNullOrEmpty(UserId) Then
            sql += " AND A.CPF01='" & txtUserIdLoad.Text.Trim & "'"
        Else
            If Not depId Is Nothing AndAlso Not String.IsNullOrEmpty(depId) Then
                sql += " AND UPPER(A.CPF29)='" & depId.ToUpper & "'"
            ElseIf Not depText Is Nothing AndAlso Not String.IsNullOrEmpty(depText) Then
                sql += " AND UPPER(A.CPF29)='" & cboDeptLoad.Text.ToString.ToUpper & "'"
            End If
            If Not lineId Is Nothing AndAlso Not String.IsNullOrEmpty(lineId) Then
                sql += " AND UPPER(A.CPF37)='" & cboLineLoad.SelectedValue.ToString.ToUpper & "'"
            ElseIf Not lineText Is Nothing AndAlso Not String.IsNullOrEmpty(lineText) Then
                sql += " AND UPPER(A.CPF37)='" & lineText.ToUpper & "'"
            End If
        End If
        Return sql
    End Function

    Private Function GetDbDataTable(sql As String) As DataTable
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dt As DataTable
        Try

            dt = sConn.GetDataTable(sql)
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

        Return dt
    End Function

    Private Function GetErpData(strSQL As String) As DataTable
        Dim dt As DataTable

        Dim oracleConn As New OracleDb("")

        Try

            dt = oracleConn.ExecuteQuery(strSQL).Tables(0)

        Catch ex As Exception
            Throw ex
        Finally
            If Not oracleConn Is Nothing Then
                oracleConn = Nothing
            End If
        End Try

        Return dt
    End Function

 
End Class