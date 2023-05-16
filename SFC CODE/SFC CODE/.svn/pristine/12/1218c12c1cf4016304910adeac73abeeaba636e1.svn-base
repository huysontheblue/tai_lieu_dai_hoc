Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmLeanProCD
    Dim ButtonPermission As Dictionary(Of String, Boolean) = New Dictionary(Of String, Boolean)
    Public opFlag As Int16 = 0   '判断是新增还是修改
    Private Sub FrmLeanProCD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolbtnState(opFlag) '设置按钮状态
        InitButtonPermission() '设置按钮权限 
        CheckUserPanelRight() '检查面板权限 
        LoadDataToDgvLeanLineTT(" ") '加载维护工时
        LoadDataToDgvLeanType(" ") '加载维护工序
        FillCombox(cboLined) '更具厂区和线别权限填充线别
        cboLined.SelectedIndex = -1
        Me.dtBegin.Value = Date.Now.AddDays(-7)
        Me.dtEnd.Value = Date.Now
        txtUserId.Text = VbCommClass.VbCommClass.UseId
        txtCreateUser.Text = VbCommClass.VbCommClass.UseId
        dgvLeanLineTT.CurrentCell = Nothing  '取消默认选中行
    End Sub
    '填充线别
    Private Sub FillCombox(ByVal colCombox As ComboBox)
        Dim lsSQL As String = String.Empty
        Dim userDg As DataTable
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass
        If colCombox.Name = "cboLined" Then
            'lsSQL = "SELECT lineid as value, lineid as text  FROM deptline_t " & _
            '" WHERE factoryid ='" & VbCommClass.VbCommClass.Factory & "'"
            lsSQL = "select distinct c.lineid as value,c.lineid as text from m_UserRight_t a left join m_Logtree_t b on a.Tkey=b.Tkey " _
                    & " left join deptline_t c on b.Ttext =c.lineid " _
                    & " where b.Tparent='z09_' and a.UserID='" & VbCommClass.VbCommClass.UseId & "' and factoryid ='" & VbCommClass.VbCommClass.Factory & "'"
            userDg = DataHand.GetDataTable(lsSQL)
            colCombox.DataSource = userDg
            colCombox.DisplayMember = "value"
            colCombox.ValueMember = "text"
        End If
        userDg = Nothing
    End Sub
    '加载维护工艺  精益生产生产项目类别
    Private Sub LoadDataToDgvLeanType(ByVal sqlWhere As String)
        Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dReader As SqlDataReader
        Dim sqlStr As String = ""
        dgvLeanType.Rows.Clear()
        sqlStr = "select LeanType ,LeanTypeName ,Usey ,UpdateUserId ,UpdateTime ,CreateUserId ,CreateTime  from m_LeanType_t where 1=1  "
        dReader = conn.GetDataReader(sqlStr & sqlWhere & " order by LeanType")
        Do While dReader.Read()
            dgvLeanType.Rows.Add(dReader.Item(0).ToString, dReader.Item(1).ToString, dReader.Item(2).ToString, dReader.Item(3).ToString, _
                dReader.Item(4).ToString, dReader.Item(5).ToString, dReader.Item(6).ToString)
        Loop
        dReader.Close()
        conn = Nothing
    End Sub
    '加载维护数值 产线TT值
    Private Sub LoadDataToDgvLeanLineTT(ByVal sqlWhere As String)
        Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dReader As SqlDataReader
        Dim sqlStr As String = ""
        dgvLeanLineTT.Rows.Clear()
        sqlStr = "select LineId ,LeanTTValue ,UpdateUserId ,UpdateTime  from m_LeanLineTTVals_t where lineid in (" _
               & "select distinct c.lineid  from m_UserRight_t a left join m_Logtree_t b on a.Tkey=b.Tkey " _
                    & " left join deptline_t c on b.Ttext =c.lineid " _
                    & " where b.Tparent='z09_' and a.UserID='" & VbCommClass.VbCommClass.UseId & "' and factoryid ='" & VbCommClass.VbCommClass.Factory & "')"
        dReader = conn.GetDataReader(sqlStr & sqlWhere & " order by LineId ")
        Do While dReader.Read
            dgvLeanLineTT.Rows.Add(dReader.Item(0).ToString, dReader.Item(1).ToString, _
                                    dReader.Item(2).ToString, dReader.Item(3).ToString)
        Loop
        dReader.Close()
        conn = Nothing
    End Sub
    '设置按钮及textbox状态
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '初始查询状态
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True

                Me.txtUserId.Enabled = True
                Me.txtCreateUser.Enabled = True
            Case 1, 2 '新增，修改
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
        End Select
    End Sub
    '切换面板
    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        opFlag = 0
        ToolbtnState(opFlag)
        If SuperTabControl1.SelectedTabIndex = 0 Then
            toolAbandon.Enabled = True
            txtTypeName.Text = ""
            chkUsey.Checked = False
            dgvLeanLineTT.CurrentCell = Nothing  '取消默认选中行
            toolNew.Enabled = False
            InitButtonPermission() '设置按钮权限
        Else
            InitButtonPermission() '设置按钮权限
            toolAbandon.Enabled = False
            txtTTvalue.Text = ""
            cboLined.Text = ""
            toolNew.Enabled = True
        End If
    End Sub
    '新增
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            Me.txtTypeName.Text = ""
            Me.txtUserId.Text = VbCommClass.VbCommClass.UseId
            Me.txtUserId.Enabled = False
            Me.chkUsey.Checked = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Me.txtTTvalue.Text = ""
            Me.cboLined.Text = ""
            Me.txtCreateUser.Text = VbCommClass.VbCommClass.UseId
            Me.txtCreateUser.Enabled = False
        End If
        opFlag = 1
        ToolbtnState(opFlag)
        InitButtonPermission() '设置按钮权限
        Me.toolAdd.Enabled = False
        Me.toolEdit.Enabled = False
        Me.toolAbandon.Enabled = False
        Me.toolQuery.Enabled = False
    End Sub
    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            '检查数据
            If CheckData() = False Then Exit Sub

            If SuperTabControl1.SelectedTabIndex = 0 Then
                InsertLeanType()
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                InsertLeanLineTT()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "ProductionPlan.FrmLeanProCD", "toolSave", "sys")
        End Try
    End Sub
    '保存时判断文本是否为空
    Private Function CheckData() As Boolean
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If Me.txtTypeName.Text.Trim = "" Then
                MessageBox.Show("请输入工序名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtTypeName.Focus()
                Return False
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If Me.cboLined.Text = "" Then
                MessageBox.Show("请选择线别!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.cboLined
                Return False
            End If
            If Me.txtTTvalue.Text = "" Then
                MessageBox.Show("请输入标准工时！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtTTvalue.Focus()
                Return False
            End If
            Dim index As Integer
            index = Me.cboLined.FindString(Me.cboLined.Text)
            If index <= -1 Then
                MessageBox.Show("请从下拉列表中选择线别")
                Return False
            End If
            If IsNumeric(Me.txtTTvalue.Text.Trim) = False Then
                MessageBox.Show("标准工时应为数值类型！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtTTvalue.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    '面板1 插入类型
    Private Sub InsertLeanType()
        Dim leanCount As String = ""
        Dim leanType As String
        Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim sqlStr As String
        Dim useY As String
        useY = IIf(Me.chkUsey.Checked, "Y", "N")

        If opFlag = 1 Then '新增后执行插入操作
            Dim mCheckname As SqlDataReader = conn.GetDataReader("select LeanType from m_LeanType_t where LeanTypeName=N'" & Me.txtTypeName.Text.Trim & "'")
            If mCheckname.HasRows Then
                mCheckname.Close()
                MessageBox.Show("该工序名称已经存在!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            mCheckname.Close()

            Dim mRead As SqlDataReader = conn.GetDataReader("select count(LeanType) as countLeanType from m_LeanType_t")
            If mRead.HasRows Then
                While mRead.Read
                    leanCount = Convert.ToInt16(mRead!countLeanType) + 1
                End While
            Else
                leanCount = "1"
            End If
            mRead.Close()

            leanType = "L" + leanCount.PadLeft(3, "0")
            sqlStr = String.Format("insert into m_LeanType_t(LeanType,LeanTypeName,Usey,UpdateUserId ,UpdateTime ,CreateUserId ,CreateTime) " _
                     & "values(N'{0}',N'{1}',N'{2}',N'{3}',getdate(),N'{4}',getdate())", leanType, Me.txtTypeName.Text.Trim, useY, VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.UseId)

        ElseIf opFlag = 2 Then
            Dim mCheckname As SqlDataReader = conn.GetDataReader("select LeanType from m_LeanType_t where LeanTypeName=N'" & Me.txtTypeName.Text.Trim & "' and LeanType <> N'" & Me.dgvLeanType.Item(0, Me.dgvLeanType.CurrentRow.Index).Value.ToString.Trim & "'")
            If mCheckname.HasRows Then
                mCheckname.Close()
                MessageBox.Show("该工序名称已经存在!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            mCheckname.Close()

            sqlStr = "update m_LeanType_t set " _
                        & "Usey = N'" & useY & "',LeanTypeName = N'" & Me.txtTypeName.Text.Trim & "',UpdateUserId ='" & VbCommClass.VbCommClass.UseId & "',UpdateTime =getdate() " _
                         & "where LeanType  =N'" & Me.dgvLeanType.Item(0, Me.dgvLeanType.CurrentRow.Index).Value.ToString.Trim & "'"
        End If

        Try
            conn.ExecSql(sqlStr.ToString)
            MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataToDgvLeanType(" ")
            txtTypeName.Text = ""
            chkUsey.Checked = False

            opFlag = 0
            ToolbtnState(opFlag)
            toolAbandon.Enabled = True
            InitButtonPermission() '设置按钮权限
            Me.toolBack.Enabled = False
            Me.toolSave.Enabled = False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "ProductionPlan.FrmLeanProCD", "InsertLeanType", "sys")
            Exit Sub
        End Try
    End Sub
    '面板2 插入标准值
    Private Sub InsertLeanLineTT()
        Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim sqlStr As String
        If opFlag = 1 Then '新增后执行插入操作
            Dim mCheckname As SqlDataReader = conn.GetDataReader("select LineId  from m_LeanLineTTVals_t where LineId=N'" & Me.cboLined.Text.Trim() & "'")
            If mCheckname.HasRows Then
                mCheckname.Close()
                MessageBox.Show("该线别已经存在!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            mCheckname.Close()


            sqlStr = String.Format("insert into m_LeanLineTTVals_t (LineId,LeanTTValue ,UpdateUserId ,UpdateTime ) " _
                     & "values(N'{0}',N'{1}',N'{2}',getdate())", Me.cboLined.Text.Trim, Me.txtTTvalue.Text.Trim, VbCommClass.VbCommClass.UseId)

        ElseIf opFlag = 2 Then
            sqlStr = "update m_LeanLineTTVals_t set " _
                        & "LeanTTValue = N'" & Me.txtTTvalue.Text.Trim & "',UpdateUserId ='" & VbCommClass.VbCommClass.UseId & "',UpdateTime =getdate() " _
                         & "where LineId  =N'" & Me.dgvLeanLineTT.Item(0, Me.dgvLeanLineTT.CurrentRow.Index).Value.ToString.Trim & "'"
        End If

        Try
            conn.ExecSql(sqlStr.ToString)
            MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataToDgvLeanLineTT(" ")
            txtTTvalue.Text = ""
            cboLined.SelectedIndex = -1


            opFlag = 0
            ToolbtnState(0)
            cboLined.Enabled = True
            InitButtonPermission() '设置按钮权限
            Me.toolAbandon.Enabled = False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "ProductionPlan.FrmLeanProCD", "InsertLeanLineTT", "sys")
            Exit Sub
        End Try
    End Sub
    '修改
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If Me.dgvLeanType.Rows.Count = 0 OrElse Me.dgvLeanType.CurrentRow Is Nothing Then Exit Sub
            Me.txtTypeName.Text = dgvLeanType.Item(1, Me.dgvLeanType.CurrentRow.Index).Value.ToString.Trim
            Me.chkUsey.Checked = IIf(dgvLeanType.Item(2, Me.dgvLeanType.CurrentRow.Index).Value.ToString.Trim = "Y", True, False)
            Me.txtUserId.Text = VbCommClass.VbCommClass.UseId
            Me.txtUserId.Enabled = False
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If Me.dgvLeanLineTT.Rows.Count = 0 Then Exit Sub
            If Me.dgvLeanLineTT.CurrentRow Is Nothing Then
                MessageBox.Show("请选择要修改的行!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.txtCreateUser.Text = VbCommClass.VbCommClass.UseId
            Me.txtCreateUser.Enabled = False
            'Dim index As Integer
            'index = Me.cboLined.FindString(Me.dgvLeanLineTT.Item(0, Me.dgvLeanLineTT.CurrentRow.Index).Value.ToString.Trim)
            'If index <= -1 Then
            '    MessageBox.Show("没有该线别的修改权限")
            '    Exit Sub
            'End If
            Me.cboLined.SelectedIndex = Me.cboLined.FindString(Me.dgvLeanLineTT.Item(0, Me.dgvLeanLineTT.CurrentRow.Index).Value.ToString.Trim)
            Me.txtTTvalue.Text = dgvLeanLineTT.Item(1, Me.dgvLeanLineTT.CurrentRow.Index).Value.ToString.Trim
            cboLined.Enabled = False
        End If

        opFlag = 2
        ToolbtnState(opFlag)
        InitButtonPermission() '设置按钮权限
        Me.toolAdd.Enabled = False
        Me.toolEdit.Enabled = False
        Me.toolAbandon.Enabled = False
        Me.toolQuery.Enabled = False
    End Sub
    '返回
    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        opFlag = 0
        ToolbtnState(opFlag)
        InitButtonPermission() '设置按钮权限
        Me.toolBack.Enabled = False
        If SuperTabControl1.SelectedTabIndex = 0 Then
            txtTypeName.Text = ""
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            cboLined.SelectedIndex = -1
            txtTTvalue.Text = ""
            cboLined.Enabled = True
            Me.toolAbandon.Enabled = False
        End If
    End Sub
    '作废
    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
        If SuperTabControl1.SelectedTabIndex = 0 Then
            '判断记录是否可以被修改
            If Me.dgvLeanType.Rows.Count = 0 OrElse Me.dgvLeanType.CurrentRow Is Nothing Then Exit Sub
            If Me.dgvLeanType.Item(2, Me.dgvLeanType.CurrentRow.Index).Value.ToString.Trim <> "Y" Then
                MessageBox.Show("该工序类型已经作废，不允许再作废!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim leanType As String = Me.dgvLeanType.Item(0, Me.dgvLeanType.CurrentRow.Index).Value.ToString.Trim
            Dim leanTypeName As String = Me.dgvLeanType.Item(1, Me.dgvLeanType.CurrentRow.Index).Value.ToString.Trim
            If MessageBox.Show("确定要作废工序类型：[" + leanType + "]-[" + leanTypeName + "]吗", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
            Try
                conn.ExecSql("update m_LeanType_t set Usey ='N' ,UpdateUserId ='" & VbCommClass.VbCommClass.UseId & "',UpdateTime=getdate() where LeanType ='" & Me.dgvLeanType.Item(0, Me.dgvLeanType.CurrentRow.Index).Value.ToString.Trim & "'")
                MessageBox.Show("成功作废工序类型：[" + leanType + "]-[" + leanTypeName + "]", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataToDgvLeanType(" ")
            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, "ProductionPlan.FrmLeanProCD", "toolAbandon", "sys")
            End Try
        End If
    End Sub
    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim sql As String = " "
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If Me.txtTypeName.Text.Trim <> "" Then
                sql = sql & " and LeanTypeName like N'%" & Me.txtTypeName.Text.Trim & "%' "
            End If
            If Me.txtUserId.Text.Trim <> "" Then
                sql = sql & " and UpdateUserId like N'%" & txtUserId.Text.Trim & "%' "
            End If

            LoadDataToDgvLeanType(sql)

        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Dim lineId As String = IIf(cboLined.SelectedValue Is DBNull.Value, "", cboLined.SelectedValue)
            Dim ttValue As String = txtTTvalue.Text.Trim
            Dim createUser As String = txtCreateUser.Text.Trim
            Dim dt1 As Date = Convert.ToDateTime(dtBegin.Value)
            Dim dt2 As Date = Convert.ToDateTime(dtEnd.Value)
            If Date.Compare(dt1, dt2) > 0 Then
                MessageUtils.ShowWarning("开始时间不能大于结束时间")
                Exit Sub
            End If

            If lineId <> "" Then
                sql = sql & " and LineId =N'" & lineId & "' "
            End If
            If ttValue <> "" Then
                sql = sql & " and LeanTTValue like N'%" & ttValue & "%'"
            End If
            If createUser <> "" Then
                sql = sql & " and UpdateUserId like '%" & createUser & "%'"
            End If

            sql = sql & " and UpdateTime between '" & dt1.ToString("yyyy-MM-dd 00:00:00") & "' and  '" & dt2.ToString("yyyy-MM-dd 23:59:59") + "'"
            LoadDataToDgvLeanLineTT(sql)
        End If
    End Sub
    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles tooExit.Click
        Me.Close()
    End Sub
    '检查用户权限
    Private Sub CheckUserPanelRight()
        SuperTabItem1.Visible = False
        SuperTabItem2.Visible = False
        Dim strSql As String = "select userid,Ttext,Usey from dbo.m_UserRight_t a join m_logtree_t b on a.tkey=b.tkey " _
                               & "where UserID ='" & SysMessageClass.UseId & "' and Usey ='Y' and Ttext =N'维护工序'"

        If DbOperateUtils.GetRowsCount(strSql) > 0 Then
            SuperTabItem1.Visible = True
        End If

        Dim strSql2 As String = "select userid,Ttext,Usey from dbo.m_UserRight_t a join m_logtree_t b on a.tkey=b.tkey " _
                              & "where UserID ='" & SysMessageClass.UseId & "' and Usey ='Y' and Ttext =N'维护工时'"

        If DbOperateUtils.GetRowsCount(strSql2) > 0 Then
            SuperTabItem2.Visible = True
            toolAbandon.Enabled = False
        End If

        ' If SuperTabItem1.Visible = True And SuperTabItem2.Visible = True Then
        SuperTabControl1.SelectedTabIndex = 1
        'End If

    End Sub
    '按钮权限
    Private Sub InitButtonPermission()
        ButtonPermission = SysMessageClass.GetUserFormButtonPermission(SysMessageClass.UseId, "ProductionPlan.FrmLeanProCD")
        Me.toolAdd.Enabled = ButtonPermission("toolAdd")
        Me.toolEdit.Enabled = ButtonPermission("toolEdit")
        Me.toolAbandon.Enabled = ButtonPermission("toolAbandon")
        Me.toolQuery.Enabled = ButtonPermission("toolQuery")
    End Sub
    '实测工时
    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        If Me.dgvLeanLineTT.Rows.Count = 0 Then Exit Sub
        If Me.dgvLeanLineTT.CurrentRow Is Nothing Then
            MessageBox.Show("请选择要增加实测工时的行", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim fr As FrmLeanProCDInfo = New FrmLeanProCDInfo()
        fr.lineId = dgvLeanLineTT.Item(0, Me.dgvLeanLineTT.CurrentRow.Index).Value.ToString.Trim
        fr.ShowDialog()
    End Sub
End Class