Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle

Public Class FrmDept

    Private Sub FrmDept_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DeptPagerPaging.PagerGrid.DataGrid = Me.dgvDept
        LoadFactory()
        operatorType = ActionType.Load
        sConn.GetControlright(Me)
        SetControlStatus()
        DeptPagerPaging.LoadData()
    End Sub

    Private Sub LoadFactory()
        cboFactory.Items.Clear()
        Dim sql As String = "SELECT FACTORYID,SHORTNAME FROM M_DCOMPANY_T WHERE 1=1"
        Using dt As DataTable = sConn.GetDataTable(sql)
            dt.Rows.InsertAt(dt.NewRow, 0)
            cboFactory.DataSource = dt.DefaultView
            cboFactory.ValueMember = "FACTORYID"
            cboFactory.DisplayMember = "SHORTNAME"
        End Using
    End Sub

    Private sqlPars() As SqlParameter
    Private Enum ActionType
        Add = 0
        Modify
        Delete
        Query
        Save
        RollBack
        Refresh
        Load
    End Enum
    Private operatorType As ActionType

    Private Sub LoadDeptData() Handles DeptPagerPaging.Paging
        Try
            Dim sql As String = String.Empty
            Dim outSql As String = String.Empty
            sql = "SELECT DEPTID 部门编号,DQC 部门描述,FACTORYID 厂别,CASE USEY WHEN 'Y' THEN 'Y.有效' ELSE 'N.无效' END 状态 FROM M_DEPT_T WHERE 1=1"
            If operatorType = ActionType.Refresh Then
                sql &= GetSqlWhere()
            End If
            LoadDeptData(sql, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function GetSqlWhere()
        Dim sql As String = String.Empty
        If Not cboFactory.SelectedValue Is Nothing AndAlso cboFactory.SelectedValue.ToString <> "" Then
            sql &= " AND FACTORYID=N'" & cboFactory.SelectedValue.ToString & "'" & vbNewLine
        End If
        If txtDeptNo.Text.Trim <> "" Then
            sql &= " AND DEPTID=N'" & txtDeptNo.Text.Trim & "'" & vbNewLine
        End If
        If txtDeptDesc.Text.Trim <> "" Then
            sql &= " AND DQC=N'" & txtDeptDesc.Text.Trim & "'" & vbNewLine
        End If
        If Not cboStatus.SelectedValue Is Nothing AndAlso Not cboStatus.SelectedValue.ToString <> "" Then
            sql &= " AND USEY='" & cboStatus.SelectedValue.ToString.Substring(0, 1) & "'" & vbNewLine
        End If
        Return sql
    End Function

    Private detpDataTable As DataTable
    Private sConn As New SysDataBaseClass
    Private col As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn

    Private Sub LoadDeptData(ByVal sql As String, ByVal sort As String)
        detpDataTable = DeptPagerPaging.GetPagingDataTable(sql, sConn.GetConnectionString(), True) 'sConn.GetPagingDataTable(sql, DeptPagerPaging.PagerGrid.PageNumber, DeptPagerPaging.PagerGrid.RecordCount, sqlPars)
        dgvDept.Columns.Clear()
        dgvDept.Columns.Insert(0, col)
        col.HeaderText = "选择"
        dgvDept.DataSource = detpDataTable
        dgvDept.ReadOnly = False
        For i As Integer = 0 To dgvDept.Columns.Count - 1
            dgvDept.Columns(i).ReadOnly = True
            dgvDept.Columns(i).SortMode = DataGridViewColumnSortMode.Programmatic
            'If i = 0 OrElse i = 1 Then dgvDept.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        dgvDept.Columns(0).ReadOnly = False
        dgvDept.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvDept.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvDept.Columns(1).HeaderText = "序号"
    End Sub

    Private Sub SetControlStatus()

        If btnNew.Tag Is Nothing Then btnNew.Tag = ""
        If btnDelete.Tag Is Nothing Then btnDelete.Tag = ""
        If btnModify.Tag Is Nothing Then btnModify.Tag = ""

        Select Case operatorType
            Case ActionType.Add
                cboFactory.SelectedIndex = -1
                cboStatus.SelectedIndex = -1
                txtDeptDesc.Text = ""
                txtDeptNo.Text = ""
                txtDeptNo.Enabled = True
                txtDeptDesc.Enabled = True
                cboFactory.Enabled = True
                cboStatus.Enabled = True
                btnUndo.Enabled = True
                btnSave.Enabled = True
            Case ActionType.Delete
            Case ActionType.Modify
                btnNew.Enabled = False
                btnDelete.Enabled = False
                btnSearch.Enabled = False
                btnRefresh.Enabled = False
                btnSave.Enabled = True
                txtDeptNo.Enabled = False
                cboFactory.Enabled = False
                cboStatus.Enabled = True
                txtDeptDesc.Enabled = True
                btnUndo.Enabled = True
            Case ActionType.Query
                btnRefresh.Enabled = True
                btnNew.Enabled = False
                btnModify.Enabled = False
                btnDelete.Enabled = False
                btnSave.Enabled = False
                txtDeptNo.Enabled = True
                txtDeptDesc.Enabled = True
                cboFactory.Enabled = True
                cboStatus.Enabled = True
                btnUndo.Enabled = True
            Case ActionType.Save
                btnNew.Enabled = IIf(btnNew.Tag = "YES", True, False)
                btnDelete.Enabled = IIf(btnDelete.Tag = "YES", True, False)
                btnModify.Enabled = IIf(btnModify.Tag = "YES", True, False)
                btnSave.Enabled = False
                btnSearch.Enabled = True
                btnRefresh.Enabled = False
                txtDeptNo.Enabled = False
                cboFactory.Enabled = False
                txtDeptDesc.Enabled = False
                cboStatus.Enabled = False
                btnUndo.Enabled = True
            Case ActionType.Refresh
            Case ActionType.RollBack
                btnNew.Enabled = IIf(btnNew.Tag = "YES", True, False)
                btnDelete.Enabled = IIf(btnDelete.Tag = "YES", True, False)
                btnSearch.Enabled = True
                btnModify.Enabled = IIf(btnModify.Tag = "YES", True, False)
                btnRefresh.Enabled = False
                btnSave.Enabled = False
                txtDeptNo.Enabled = False
                cboFactory.Enabled = False
                cboStatus.Enabled = False
                txtDeptDesc.Enabled = False
            Case ActionType.Load
                cboFactory.SelectedIndex = -1
                cboStatus.SelectedIndex = -1
                txtDeptDesc.Text = ""
                txtDeptNo.Text = ""
                txtDeptNo.Enabled = False
                txtDeptDesc.Enabled = False
                cboFactory.Enabled = False
                cboStatus.Enabled = False
                btnUndo.Enabled = False
        End Select
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        operatorType = ActionType.Add
        SetControlStatus()
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        operatorType = ActionType.Modify
        SetControlStatus()
    End Sub

    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        operatorType = ActionType.RollBack
        SetControlStatus()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        operatorType = ActionType.Query
        SetControlStatus()
    End Sub

    Private Enum DeptGrid
        Seq = 0
        CheckBox
        DeptId
        DeptDesc
        FactoryId
        Status
    End Enum

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            Dim sql As String = String.Empty
            If dgvDept.Rows.Count <= 0 Then
                MessageBox.Show("没有可删除的信息")
                Exit Sub
            End If
            For Each row As DataGridViewRow In dgvDept.Rows
                If Not row.Cells(DeptGrid.CheckBox).Value Is Nothing AndAlso row.Cells(DeptGrid.CheckBox).Value.ToString = "True" Then
                    sql &= " DELETE FROM M_DEPT_T WHERE DEPTID='" & row.Cells(DeptGrid.DeptId).Value.ToString & "' AND FACTORYID='" & row.Cells(DeptGrid.FactoryId).Value.ToString & "'" & vbNewLine
                End If
            Next
            If String.IsNullOrEmpty(sql) Or sql Is Nothing Then
                MessageBox.Show("请选择需要删除的信息")
                Exit Sub
            End If
            sConn.ExecSql(sql)
            MessageBox.Show("删除成功")
            operatorType = ActionType.Delete
            DeptPagerPaging.LoadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        operatorType = ActionType.Refresh
        DeptPagerPaging.LoadData()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim sql As String = String.Empty
            If Not BasicCheck() Then
                Exit Sub
            End If
            Select Case operatorType
                Case ActionType.Add
                    sql = "SELECT DEPTID FROM M_DEPT_T WHERE FACTORYID='" & cboFactory.SelectedValue.ToString & "'AND DEPTID='" & txtDeptNo.Text.Trim & "'"
                    If sConn.GetRowsCount(sql) > 0 Then
                        MessageBox.Show("该部门信息已经存在,请确认！！！")
                        Exit Sub
                    Else
                        sql = "INSERT INTO M_DEPT_T(DEPTID,DQC,USEY,FACTORYID) VALUES('" & txtDeptNo.Text.Trim & "','" & txtDeptDesc.Text.Trim & "'" & _
                        ",'" & cboStatus.SelectedItem.ToString.Substring(0, 1) & "','" & cboFactory.SelectedValue.ToString & "')"
                    End If
                Case ActionType.Modify
                    sql = "UPDATE M_DEPT_T SET DQC='" & txtDeptDesc.Text.Trim & "',USEY='" & cboStatus.SelectedItem.ToString.Substring(0, 1) & "'" & _
                    " WHERE FACTORYID='" & cboFactory.SelectedValue.ToString & "'AND DEPTID='" & txtDeptNo.Text.Trim & "' "
            End Select
            sConn.ExecSql(sql)
            MessageBox.Show("保存成功")
            operatorType = ActionType.Save
            SetControlStatus()
            DeptPagerPaging.LoadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function BasicCheck() As Boolean
        If cboFactory.SelectedIndex = -1 Then
            MessageBox.Show("请选择厂别")
            cboFactory.SelectAll()
            Return False
        End If
        If txtDeptNo.Text.Trim = "" Then
            MessageBox.Show("请输入部门编号")
            txtDeptNo.Select()
            Return False
        End If
        If txtDeptDesc.Text = "" Then
            MessageBox.Show("请输入部门描述")
            txtDeptDesc.Select()
            Return False
        End If
        If cboStatus.SelectedIndex = -1 Then
            MessageBox.Show("请选择状态")
            cboStatus.SelectAll()
            Return False
        End If
        Return True
    End Function

    Private Sub dgvDept_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDept.CellContentClick
        Try
            If dgvDept.Rows.Count <= 0 Then
                MessageBox.Show("没有可选择的信息")
                Exit Sub
            End If
            cboFactory.SelectedValue = dgvDept.CurrentRow.Cells(DeptGrid.FactoryId).Value.ToString
            txtDeptNo.Text = dgvDept.CurrentRow.Cells(DeptGrid.DeptId).Value.ToString
            txtDeptDesc.Text = dgvDept.CurrentRow.Cells(DeptGrid.DeptDesc).Value.ToString
            cboStatus.SelectedIndex = cboStatus.FindString(dgvDept.CurrentRow.Cells(DeptGrid.Status).Value.ToString)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class