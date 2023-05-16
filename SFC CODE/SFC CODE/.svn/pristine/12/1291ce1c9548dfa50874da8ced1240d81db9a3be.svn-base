Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports LXWarehouseManage
Imports System.Drawing

Public Class FrmStation
    '变量定义
    Dim OperateFlag As EditMode '操作模式
    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum

    Private Sub FrmPartNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.PagerPaging.PagerGrid.DataGrid = Me.dgvStation
            Me.PagerPaging.PagerGrid.Sort = "修改时间 DESC,工站名称 ASC"
            AddHandler Me.dgvStation.ColumnHeaderMouseClick, AddressOf Me.PagerPaging.OnSortCommand
            Me.PagerPaging.PagerGrid.PageSize = 100
            '设定用戶权限
            Dim ERigth As New SysDataBaseClass
            ERigth.GetControlright(Me)
            '设置右健菜单权限
            ERigth.GetContextMenuRight(Me, Me.ContextMenuStrip1)
            '设置当前操作模式
            Me.OperateFlag = EditMode.UNDO
            '绑定工站类别
            BindCombox(cboStationType)
            '绑定工段类别
            BindCombox(cboSection)
            '绑定岗位技术代码
            BindCombox(cboSkillCode)
            '绑定品质报表
            BindCombox(cboReportType)
            '设置工具栏按钮状态
            SetControlStatus(Me.OperateFlag)
            '设置面板组控件状态
            ToogleGroupBox(0)
            '绑定数据
            PagerPaging.LoadData()
            '
            'SetRowBgColor()
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & "错误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub


#Region "设置工具栏控件状态"

    Private Sub SetControlStatus(ByVal flag As EditMode)
        If btnDelete.Tag Is Nothing Then
            btnDelete.Enabled = False
        Else
            If btnDelete.Tag = "YES" Then
                btnDelete.Enabled = True
            Else
                btnDelete.Enabled = False
            End If
        End If
        Select Case UCase(flag)
            Case EditMode.ADD '新增

                Me.btnModify.Enabled = False

                Me.btnSave.Enabled = True
                Me.btnUndo.Enabled = True

                Me.btnSearch.Enabled = False
                Me.btnRefresh.Enabled = False
                Me.btnDelete.Enabled = False


            Case EditMode.EDIT '修改

                Me.btnNew.Enabled = False

                Me.btnSave.Enabled = True
                Me.btnUndo.Enabled = True

                Me.btnSearch.Enabled = False
                Me.btnRefresh.Enabled = False
                btnDelete.Enabled = False


            Case EditMode.UNDO '初始化

                Me.btnNew.Enabled = IIf(btnNew.Tag.ToString = "YES", True, False)
                Me.btnModify.Enabled = IIf(btnModify.Tag.ToString = "YES", True, False)
                Me.tsmiCopyRecord.Enabled = IIf(tsmiCopyRecord.Tag.ToString = "YES", True, False)

                Me.btnSave.Enabled = False
                Me.btnUndo.Enabled = False

                Me.btnSearch.Enabled = True
                Me.btnRefresh.Enabled = False


            Case EditMode.SEARCH '搜索

                Me.btnNew.Enabled = False
                Me.btnModify.Enabled = False
                Me.tsmiCopyRecord.Enabled = False

                Me.btnUndo.Enabled = True
                Me.btnSave.Enabled = False

                Me.btnSearch.Enabled = True
                Me.btnRefresh.Enabled = True
                btnDelete.Enabled = False
        End Select
    End Sub
#End Region

#Region "加载数据"
    Private Sub LoadData(ByVal sql As String)
        Dim DtPartNuber As DataTable
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        DtPartNuber = PagerPaging.GetPagingDataTable(sql, DAL.GetConnectionString(), True)
        DAL = Nothing
        dgvStation.DataSource = Nothing
        dgvStation.DataSource = DtPartNuber
        '"备注"列全屏显示
        'dgvStation.Columns("描述").AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        '
        For Each col As DataGridViewColumn In dgvStation.Columns
            col.Width = 105
            col.SortMode = DataGridViewColumnSortMode.Programmatic
        Next
        Me.dgvStation.Columns(0).HeaderText = "序号"
        Me.dgvStation.Columns(0).ReadOnly = True
        Me.dgvStation.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvStation.Columns("ID").Visible = False
        dgvStation.Columns(StationGrid.ReportTypeCode).Visible = False
        dgvStation.Columns(StationGrid.StationName).DefaultCellStyle.ForeColor = Color.Blue
    End Sub
#End Region

#Region "检查输入"
    Private sConn As New SysDataBaseClass
    Private Function CheckInput() As Boolean
        If Me.txtStationName.Text.Trim = "" Then
            MessageBox.Show("工站名称不能为空!")
            Return False
        End If
        If Me.cboStationType.SelectedIndex = -1 Then
            MessageBox.Show("请选择工站类型")
            Return False
        End If
        If Me.cboStatus.SelectedIndex = -1 Then
            MessageBox.Show("请选择状态")
            Return False
        End If
        If OperateFlag = EditMode.ADD Then
            Dim sql As String = "SELECT STATIONNAME FROM M_RUNCARDSTATION_T WHERE STATIONNAME=N'" & txtStationName.Text.Trim & "'"
            If sConn.GetRowsCount(sql) > 0 Then
                MessageBox.Show("工站名称已存在")
                Return False
            End If
        End If
        Return True
    End Function
#End Region

#Region "保存数据"
    Private Sub SaveData()
        Dim StrSql As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            Dim StationNo As String = Me.txtStationNo.Text.Trim
            Dim StationName As String = Me.txtStationName.Text.Trim
            Dim Desc As String = Me.txtDescription.Text.Trim
            Dim SectionID As Integer = CInt(Me.cboSection.SelectedValue.ToString)
            Dim StationTypeID As Integer = CInt(Me.cboStationType.SelectedValue.ToString)
            Dim Status As Integer = Convert.ToInt16(cboStatus.SelectedItem.ToString().Substring(0, 1))
            Dim SkillCode As String = Nothing
            If Not cboSkillCode.SelectedValue Is Nothing Then
                SkillCode = cboSkillCode.SelectedValue.ToString
            End If
            Dim reportTypeCode As String = Nothing
            If Not cboReportType.SelectedValue Is Nothing Then
                reportTypeCode = cboReportType.SelectedValue.ToString
            End If
            '
            If OperateFlag = EditMode.ADD Then     '新增
                StrSql = "declare @StationNo varchar(6);select @StationNo=max(StationNo) from M_RUNCARDSTATION_T(nolock);if @StationNo IS NULL begin set @StationNo='A0001' end; " & _
                         "set @StationNo='A' + right(Replicate('0',4) + cast(cast(right(@StationNo,4) as int)+1 as varchar),4) " & _
                         "insert into M_RUNCARDSTATION_T(StationNo,StationName,StationTypeID,SectionID,Description,Status,UserID,InTime,skillcode,reportTypeCode) values (" & _
                         "@StationNo,N'" & StationName & "'," & StationTypeID & "," & SectionID & ",N'" & Desc & "'," & Status & ",'" & SysMessageClass.UseId & "',getdate(),'" & SkillCode & "','" & reportTypeCode & "' )"
            Else 'If EditFlag = EditMode.MODIFY Then     '修改
                StrSql = "update M_RUNCARDSTATION_T set StationName=N'" & StationName & "',Description=N'" & Desc & "',StationTypeID=" & StationTypeID & ",SectionID=" & SectionID & "," & _
                         "Status=" & Status & ",UserID='" & SysMessageClass.UseId & "',InTime=getdate(),skillcode='" & SkillCode & "',reportTypeCode='" & reportTypeCode & "' where ID=" & CInt(Me.lblId.Text.Trim) & " and StationNo=N'" & StationNo & "' "
            End If
            '执行SQL
            DAL.ExecuteNonQuery(StrSql)
            MessageBox.Show("保存成功")
        Catch ex As Exception
            Throw ex
        Finally
            DAL = Nothing
        End Try
    End Sub
#End Region

#Region "开关 GroupBox 面板控件状态"
    Private Sub ToogleGroupBox(ByVal flag As Integer)
        Select Case flag
            Case 0
                Me.txtStationNo.Enabled = False
                Me.txtStationName.Enabled = False
                Me.txtDescription.Enabled = False
                Me.cboSection.Enabled = False
                Me.cboStationType.Enabled = False
                Me.cboStatus.Enabled = False
                Me.cboSkillCode.Enabled = False
                Me.cboReportType.Enabled = False

                Me.cboSkillCode.SelectedIndex = -1
                Me.cboSection.SelectedIndex = -1
                Me.cboStationType.SelectedIndex = -1
                Me.cboStatus.SelectedIndex = -1
                Me.cboReportType.SelectedIndex = -1

            Case 1
                Me.txtStationNo.Enabled = False
                Me.txtStationName.Enabled = True
                Me.txtDescription.Enabled = True
                Me.cboSection.Enabled = True
                Me.cboStationType.Enabled = True
                Me.cboStatus.Enabled = True
                Me.cboSkillCode.Enabled = True
                Me.cboReportType.Enabled = True

                Me.cboSkillCode.SelectedIndex = -1
                Me.cboSection.SelectedIndex = -1
                Me.cboStationType.SelectedIndex = -1
                Me.cboStatus.SelectedIndex = -1
        End Select
    End Sub
#End Region

#Region "清除 GroupBox 面板控件值"
    Private Sub ClearGroupBox()
        Me.lblId.Text = ""
        Me.txtStationNo.Text = ""
        Me.txtStationName.Text = ""
        Me.txtDescription.Text = ""

        Me.cboStationType.SelectedText = ""
        Me.cboStatus.SelectedText = ""
        Me.cboStationType.SelectedIndex = -1
        Me.cboStatus.SelectedIndex = -1
        cboReportType.SelectedIndex = -1

    End Sub
#End Region

#Region "BindComBox"

    Private Sub BindCombox(ByVal ColComboBox As ComboBox)
        Dim UserDg As DataTable
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            If ColComboBox.Name = "cboStationType" Then
                UserDg = DAL.GetDataTable("select ID,StationTypeName from M_RUNCARDSTATIONTYPE_T(nolock) where Status=1 ")
                ColComboBox.DataSource = UserDg
                ColComboBox.DisplayMember = "StationTypeName"
                ColComboBox.ValueMember = "ID"
            End If
            If ColComboBox.Name = "cboSection" Then
                UserDg = DAL.GetDataTable("select ID,SectionName from m_RunCardStationSection_t(nolock) where Status=1 ")
                ColComboBox.DataSource = UserDg
                ColComboBox.DisplayMember = "SectionName"
                ColComboBox.ValueMember = "ID"
            End If
            If ColComboBox.Name = "cboSkillCode" Then
                UserDg = DAL.GetDataTable("SELECT SKILLCODE,DESCRIPTION FROM M_RUNCARDJOBSKILLCODE_T(NOLOCK) WHERE STATUS=1 ")
                UserDg.Rows.InsertAt(UserDg.NewRow, 0)
                ColComboBox.DataSource = UserDg
                ColComboBox.DisplayMember = "DESCRIPTION"
                ColComboBox.ValueMember = "SKILLCODE"
            End If
            If ColComboBox.Name = "cboReportType" Then
                UserDg = DAL.GetDataTable("SELECT REPORTTYPECODE,REPORTTYPEDESCRIPTION FROM M_RUNCARDIPQCREPORTTYPE_T WHERE STATUS=1")
                UserDg.Rows.InsertAt(UserDg.NewRow, 0)
                ColComboBox.DataSource = UserDg
                ColComboBox.DisplayMember = "REPORTTYPEDESCRIPTION"
                ColComboBox.ValueMember = "REPORTTYPECODE"
            End If
        Catch ex As Exception
            Throw ex
        Finally
            DAL = Nothing
        End Try
    End Sub
#End Region


#Region "给 GroupBox 面板控件赋值"
    Public Enum StationGrid
        Seq = 0
        Id
        StationNo
        StationName
        StationType
        SkillCode
        SkillCodeDesc
        ReportTypeCode
        ReportTypeDesc
        Section
        Status
        UserId
        InTime
        Remark
    End Enum
    Private Sub SetGroupBox()
        If Me.dgvStation.RowCount < 1 Then Exit Sub

        Me.lblId.Text = Me.dgvStation.Item(StationGrid.Id, dgvStation.CurrentRow.Index).Value.ToString()
        Me.txtStationNo.Text = Me.dgvStation.Item(StationGrid.StationNo, dgvStation.CurrentRow.Index).Value.ToString()
        Me.txtStationName.Text = Me.dgvStation.Item(StationGrid.StationName, dgvStation.CurrentRow.Index).Value.ToString()
        Me.cboStationType.SelectedIndex = Me.cboStationType.FindString(Me.dgvStation.Item(StationGrid.StationType, dgvStation.CurrentRow.Index).Value.ToString())
        Me.cboSection.SelectedIndex = Me.cboSection.FindString(Me.dgvStation.Item(StationGrid.Section, dgvStation.CurrentRow.Index).Value.ToString())
        Me.cboStatus.SelectedIndex = CInt(Me.dgvStation.Item(StationGrid.Status, dgvStation.CurrentRow.Index).Value.ToString.Substring(0, 1))
        Me.txtDescription.Text = Me.dgvStation.Item(StationGrid.Remark, dgvStation.CurrentRow.Index).Value.ToString()
        Me.cboSkillCode.SelectedIndex = Me.cboSkillCode.FindString(Me.dgvStation.Item(StationGrid.SkillCodeDesc, dgvStation.CurrentRow.Index).Value.ToString())
        Me.cboReportType.SelectedValue = Me.dgvStation.Item(StationGrid.ReportTypeCode, dgvStation.CurrentRow.Index).Value.ToString
    End Sub
#End Region

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        '设置操作模式
        OperateFlag = EditMode.ADD
        '工具栏控件状态
        SetControlStatus(EditMode.ADD)
        '清除面板控件值
        ClearGroupBox()
        '面板控件可写
        ToogleGroupBox(1)
        '
        Me.cboStatus.SelectedIndex = 1
        Me.txtStationName.Focus()
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        '设置操作模式
        OperateFlag = EditMode.EDIT
        '工具栏控件状态
        SetControlStatus(EditMode.EDIT)
        '面板控件可写
        ToogleGroupBox(1)
        '面板控件赋值
        SetGroupBox()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Me.OperateFlag = EditMode.ADD Or Me.OperateFlag = EditMode.EDIT Then
                '检查输入
                If CheckInput() = False Then
                    Exit Sub
                End If
                '保存
                SaveData()
                '清除面板控件值
                ClearGroupBox()
                '设置当前操作模式
                OperateFlag = EditMode.UNDO
                '设置工具栏按钮状态
                SetControlStatus(OperateFlag)
                '设置面板组控件状态
                ToogleGroupBox(0)
                '刷新
                PagerPaging.LoadData()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmStation", "btnSave_Click", "sys")
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        '设置操作模式
        OperateFlag = EditMode.SEARCH
        '工具栏控件状态
        SetControlStatus(OperateFlag)
        '清除面板控件值
        ClearGroupBox()
        '面板控件可写
        ToogleGroupBox(1)
        '
        Me.txtStationName.Focus()
    End Sub

    '#Region "清除控件值"
    '    Private Sub ClearControl()
    '        Dim ClearCon As Control
    '        For Each ClearCon In Me.Controls
    '            If TypeOf ClearCon Is System.Windows.Forms.TextBox Then
    '                ClearCon.Text = ""
    '                'ElseIf TypeOf ClearCon Is ComboBox Then
    '                '    ClearCon.Text = ""
    '            End If
    '        Next
    '    End Sub
    '#End Region

    '#Region "控件有效性设置"

    '    Private Sub EnableControl(ByVal Flag As Integer)

    '        Dim EmsCon As Control
    '        Select Case Flag
    '            Case 1
    '                Me.dgvPartNumber.Enabled = True
    '                For Each EmsCon In Me.Controls
    '                    If TypeOf EmsCon Is System.Windows.Forms.TextBox Then
    '                        EmsCon.Enabled = True
    '                    ElseIf TypeOf EmsCon Is System.Windows.Forms.CheckBox Then
    '                        EmsCon.Enabled = True
    '                    ElseIf TypeOf EmsCon Is ComboBox Then
    '                        EmsCon.Enabled = True
    '                    End If

    '                Next
    '                'dgvPartNumber.Enabled = False
    '            Case 0
    '                For Each EmsCon In Me.Controls
    '                    If TypeOf EmsCon Is System.Windows.Forms.TextBox Then
    '                        EmsCon.Enabled = False
    '                    ElseIf TypeOf EmsCon Is System.Windows.Forms.CheckBox Then
    '                        EmsCon.Enabled = False
    '                    ElseIf TypeOf EmsCon Is ComboBox Then
    '                        EmsCon.Enabled = False
    '                    End If

    '                Next
    '                dgvPartNumber.Enabled = True
    '        End Select
    '    End Sub

    '#End Region


    '#Region "控件赋值"
    '    Private Sub SetValueToControl()

    '        If Me.dgvPartNumber.RowCount < 1 Then Exit Sub
    '        If Me.dgvPartNumber.CurrentRow.Index < 0 Then Exit Sub
    '        Me.txtId.Text = Me.dgvPartNumber.Item(0, dgvPartNumber.CurrentRow.Index).Value.ToString()
    '        Me.txtPartNumber.Text = Me.dgvPartNumber.Item(1, dgvPartNumber.CurrentRow.Index).Value.ToString()
    '        Me.txtDescription.Text = Me.dgvPartNumber.Item(2, dgvPartNumber.CurrentRow.Index).Value.ToString()
    '        Me.cboStatus.SelectedIndex = IIf(Me.dgvPartNumber.Item(3, dgvPartNumber.CurrentRow.Index).Value.ToString.ToUpper = "YES", 0, 1)
    '    End Sub
    '#End Region

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        If OperateFlag <> EditMode.SEARCH Then
            Exit Sub
        End If
        Try
            PagerPaging.LoadData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmStation", "btnRefresh_Click", "sys")
        End Try

    End Sub

    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        '设置操作模式
        OperateFlag = EditMode.UNDO
        '工具栏控件状态
        SetControlStatus(EditMode.UNDO)
        '清除面板控件值
        ClearGroupBox()
        '面板控件只读
        ToogleGroupBox(0)
        ''
    End Sub

    Private Sub dgvPartNumber_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStation.CellClick
        If dgvStation.RowCount < 1 Then Exit Sub
        '新增、查询 模式下不可操作
        If OperateFlag = EditMode.ADD Or OperateFlag = EditMode.SEARCH Then
            Exit Sub
        End If
        '面板控件赋值
        SetGroupBox()
        '
        'dgvStation.Rows(1).Cells[]



    End Sub

#Region "复制记录"
    Private Sub tsmiCopyRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiCopyRecord.Click
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            '
            Dim StationName As String = dgvStation.Rows(dgvStation.CurrentRow.Index).Cells("工站名称").Value.ToString
            If MessageBox.Show("确认复制工站""" & StationName & """?", "复制确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            '参数定义
            Dim p As New SqlClient.SqlParameter
            Dim param1 As New SqlParameter("@OldStationID", SqlDbType.Int, ParameterDirection.Input)
            Dim param2 As New SqlParameter("@OldStationName", SqlDbType.NVarChar, 50, ParameterDirection.Input)
            Dim param3 As New SqlParameter("@UserID", SqlDbType.NVarChar, 50, ParameterDirection.Input)
            Dim param4 As New SqlParameter("@ErrMsg", SqlDbType.NVarChar, 200)
            '参数赋值
            param1.Value = CInt(dgvStation.Rows(dgvStation.CurrentRow.Index).Cells("ID").Value.ToString)
            param2.Value = StationName
            param3.Value = SysMessageClass.UseId
            param4.Direction = ParameterDirection.Output '?指定
            param4.Value = ""
            Dim Paramters As SqlParameter() = Nothing
            Paramters = New SqlParameter() {param1, param2, param3, param4}
            '执行SP
            DAL.ExecuteNonQureyByProc("udpCopyStation", Paramters)
            If Not String.IsNullOrEmpty(param4.Value.ToString()) Then
                MessageBox.Show(param4.Value.ToString())
                Exit Sub
            End If
            MessageBox.Show("复制成功^_^ ")
            '刷新
            OperateFlag = EditMode.ADD
            PagerPaging.LoadData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmStation", "tsmiCopy_Click", "sys")
        Finally
            DAL = Nothing
        End Try
    End Sub
#End Region

#Region "绑定右健菜单"
    Private Sub dgvStation_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvStation.CellContextMenuStripNeeded
        'Dim dgv As DataGridView = CType(sender, DataGridView)
        If e.RowIndex >= 0 Then
            e.ContextMenuStrip = Me.ContextMenuStrip1
        End If
    End Sub
#End Region

#Region "右健改变当前行号"
    Private Sub dgvStation_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvStation.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.RowIndex >= 0 Then
                dgvStation.ClearSelection()
                dgvStation.Rows(e.RowIndex).Selected = True
                dgvStation.CurrentCell = dgvStation.Rows(e.RowIndex).Cells(e.ColumnIndex)
            End If
        End If

    End Sub
#End Region

#Region "复制单元格"
    Private Sub tsmiCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiCopy.Click

        If Not dgvStation.CurrentCell Is Nothing Then
            Dim Selected As String = dgvStation.CurrentCell.Value.ToString()
            Clipboard.SetDataObject(Selected)
        End If
    End Sub
#End Region

#Region "背景色"
    Private Sub dgvStation_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvStation.DataBindingComplete
        For Each item As DataGridViewRow In dgvStation.Rows

            If item.Cells("状态").Value.ToString() = "0" Then
                item.DefaultCellStyle.ForeColor = Color.Red
            End If

            If item.Index Mod 2 = 0 Then
                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub
#End Region

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If txtStationNo.Text = "" Then
                MessageBox.Show("请选择要删除的工站")
                Exit Sub
            End If
            If MessageBox.Show("确定要删除 {" & txtStationName.Text & "} 工站信息", "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) <> Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If
            Dim sql = " INSERT INTO M_STATIONLOG_T(StationNo,StationName,StationTypeID,Status,UserID,InTime,Description,SectionID) " & _
            "SELECT StationNo,StationName,StationTypeID,Status,UserID,GETDATE(),Description,SectionID FROM M_RUNCARDSTATION_T WHERE STATIONNO='" & txtStationNo.Text & "'"
            sql += " DELETE FROM M_RUNCARDSTATION_T WHERE STATIONNO='" & txtStationNo.Text & "'"
            sConn.ExecSql(sql)
            MessageBox.Show("工站删除成功")
            SetControlStatus(EditMode.UNDO)
            txtDescription.Text = ""
            txtStationName.Text = ""
            txtStationNo.Text = ""
            cboSection.SelectedIndex = -1
            cboStatus.SelectedIndex = -1
            cboStationType.SelectedIndex = -1
            PagerPaging.LoadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadStationData() Handles PagerPaging.Paging
        Try
            Dim sql As String = "SELECT A.ID ID,A.STATIONNO 工站编号,A.STATIONNAME 工站名称,B.STATIONTYPENAME 工站类型,A.SKILLCODE 岗位技能代码," & vbNewLine & _
                " D.DESCRIPTION 岗位技能描述 ,A.REPORTTYPECODE 品质报表代码,E.REPORTTYPEDESCRIPTION 品质报表类型, " & vbNewLine & _
                " C.SECTIONNAME 工段类型,CASE A.STATUS WHEN 1 THEN '1.有效' ELSE '0.无效' END 状态," & vbNewLine & _
                " A.USERID 修改人,A.INTIME 修改时间,A.DESCRIPTION 描述 " & vbNewLine & _
                " FROM M_RUNCARDSTATION_T(NOLOCK) A JOIN M_RUNCARDSTATIONTYPE_T(NOLOCK) B ON A.STATIONTYPEID=B.ID " & vbNewLine & _
                " JOIN m_RunCardStationSection_t(NOLOCK) C ON A.SECTIONID=C.ID LEFT JOIN M_RUNCARDJOBSKILLCODE_T D ON A.SKILLCODE=D.SKILLCODE " & vbNewLine & _
                " LEFT JOIN M_RUNCARDIPQCREPORTTYPE_T E ON A.REPORTTYPECODE=E.REPORTTYPECODE " & vbNewLine & _
                " WHERE 1=1 "
            If OperateFlag = EditMode.SEARCH Then
                sql = sql & GetSqlWhere()
            End If
            LoadData(sql)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Dim sbSqlWhere As New StringBuilder
    Private Function GetSqlWhere() As String
        sbSqlWhere.Remove(0, sbSqlWhere.Length)
        If Me.txtStationNo.Text.Trim() <> "" Then
            sbSqlWhere.Append(" and A.StationNo like N'%" & txtStationNo.Text.Trim() & "%' ")
        End If
        If Me.txtStationName.Text.Trim() <> "" Then
            sbSqlWhere.Append(" and  A.StationName like N'%" & txtStationName.Text.Trim() & "%' ")
        End If
        If Me.txtDescription.Text.Trim() <> "" Then
            sbSqlWhere.Append(" and A.Description like N'%" & txtDescription.Text.Trim() & "%' ")
        End If

        If Me.cboStationType.SelectedIndex <> -1 Then
            sbSqlWhere.Append(" and B.ID=" & cboStationType.SelectedValue.ToString() & " ")
        End If
        If Me.cboSection.SelectedIndex <> -1 Then
            sbSqlWhere.Append(" and C.ID=" & cboSection.SelectedValue.ToString() & " ")
        End If
        If Me.cboStatus.SelectedIndex <> -1 Then
            sbSqlWhere.Append(" and  A.[Status] = " & cboStatus.SelectedItem.ToString().Substring(0, 1) & " ")
        End If
        If Me.cboSkillCode.SelectedIndex <> -1 Then
            sbSqlWhere.Append(" and  A.[SKILLCODE] = '" & cboSkillCode.SelectedValue.ToString & "' ")
        End If
        Return sbSqlWhere.ToString()
    End Function

    Private Sub dgvStation_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStation.CellDoubleClick
        Dim isAdd As Boolean
        Dim isDelete As Boolean
        Try
            If btnNew.Tag Is Nothing Then btnNew.Tag = "NO"
            If btnDelete.Tag Is Nothing Then btnDelete.Tag = "NO"
            isAdd = btnNew.Tag.ToString = "YES"
            isDelete = btnDelete.Tag.ToString = "YES"
            If e.ColumnIndex = StationGrid.StationName Then
                Using frm As New FrmStationCheckItemMaintaince(CInt(dgvStation.Item(StationGrid.Id, dgvStation.CurrentRow.Index).Value.ToString()), Me.dgvStation.Item(StationGrid.StationNo, dgvStation.CurrentRow.Index).Value.ToString(), Me.dgvStation.Item(StationGrid.StationName, dgvStation.CurrentRow.Index).Value.ToString(), isAdd, isDelete)
                    frm.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class