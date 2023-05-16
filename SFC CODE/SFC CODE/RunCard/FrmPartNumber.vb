Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports LXWarehouseManage
Imports System.Xml
Imports System.Drawing

#Region "Old"
'Public Class FrmPartNumber
'    '变量定义
'    Dim OperateFlag As EditMode '操作模式
'    Dim IsSearch As Boolean = False
'    Public Enum EditMode
'        ADD
'        EDIT
'        UNDO
'        SEARCH
'        EXPORT
'        IMPORT
'    End Enum

'    Public Enum TabType
'        RAW = 0
'        Equipment
'    End Enum

'    Private Sub FrmPartNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Try
'            '设定用戶權限
'            Dim ERigth As New SysDataBaseClass
'            ERigth.GetControlright(Me)
'            '
'            ERigth.GetContextMenuRight(Me, Me.ContextMenuStrip1)
'            '设置当前操作模式
'            Me.OperateFlag = EditMode.UNDO
'            '设置工具栏按钮状态
'            SetControlStatus(Me.OperateFlag)
'            '设置面板组控件状态
'            ToogleGroupBox(0)
'            '绑定数据
'            LoadData("", TabType.RAW)
'            LoadData("", TabType.Equipment)
'        Catch ex As Exception
'            MessageBox.Show(ex.Message & vbCrLf & "错误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'        End Try

'    End Sub


'#Region "设置工具栏控件状态"

'    Private Sub SetControlStatus(ByVal flag As EditMode)

'        Select Case UCase(flag)
'            Case EditMode.ADD '新增

'                btnModify.Enabled = False

'                btnSave.Enabled = True
'                btnUndo.Enabled = True

'                btnSearch.Enabled = False
'                btnRefresh.Enabled = False
'                btnBExport.Enabled = False
'                btnScan.Enabled = False
'                btnExport.Enabled = False
'                btnDownload.Enabled = False

'            Case EditMode.EDIT '修改

'                btnNew.Enabled = False

'                btnSave.Enabled = True
'                btnUndo.Enabled = True

'                btnSearch.Enabled = False
'                btnRefresh.Enabled = False
'                btnBExport.Enabled = False
'                btnScan.Enabled = False
'                btnExport.Enabled = False
'                btnDownload.Enabled = False

'            Case EditMode.UNDO '初始化

'                Me.btnNew.Enabled = IIf(btnNew.Tag.ToString = "YES", True, False)
'                Me.btnModify.Enabled = IIf(btnModify.Tag.ToString = "YES", True, False)
'                Me.tsmiCopyRecord.Enabled = IIf(tsmiCopyRecord.Tag.ToString = "YES", True, False)

'                btnSave.Enabled = False
'                btnUndo.Enabled = False

'                btnSearch.Enabled = True
'                btnRefresh.Enabled = False
'                btnExport.Enabled = IIf(btnNew.Tag.ToString = "YES", True, False)
'                btnBExport.Enabled = False
'                btnScan.Enabled = False
'                btnDownload.Enabled = False

'            Case EditMode.SEARCH '搜索

'                Me.btnNew.Enabled = False
'                Me.btnModify.Enabled = False
'                Me.tsmiCopyRecord.Enabled = False

'                'Me.cboStatus.SelectedIndex = -1

'                btnUndo.Enabled = True
'                btnSave.Enabled = False

'                btnSearch.Enabled = True
'                btnRefresh.Enabled = True
'                btnBExport.Enabled = btnExport.Enabled
'                btnScan.Enabled = btnExport.Enabled
'                btnExport.Enabled = False
'                btnDownload.Enabled = False

'            Case EditMode.EXPORT
'                btnBExport.Enabled = True
'                btnScan.Enabled = True
'                btnUndo.Enabled = True
'                btnDownload.Enabled = False
'                txtPath.Text = ""
'            Case EditMode.IMPORT
'                txtPath.Text = ""
'                btnBExport.Enabled = False
'                btnScan.Enabled = False
'                btnUndo.Enabled = True
'                btnDownload.Enabled = True

'        End Select

'    End Sub
'#End Region

'#Region "加载数据"
'    Private Sub LoadData(ByVal SqlWhere As String, ByVal type As TabType, Optional ByVal download As Boolean = False)
'        Dim StrSql As String = Nothing
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Select Case type
'            Case TabType.RAW
'                StrSql = "SELECT " & IIf(download, "TOP 65536", " TOP 100") & " ID,PARTNUMBER 料件编号,DESCRIPTION 品名,DESCRIPTION1 规格," & vbNewLine & _
'                " CASE WHEN [STATUS]=1 THEN 'YES' ELSE 'NO' END 状态,USERID 创建人,INTIME 创建日期,'' 备注,TYPE 类别" & vbNewLine & _
'                " FROM M_RUNCARDPARTNUMBER_T(NOLOCK) A WHERE 1=1 AND (TYPE IS NULL OR TYPE='R')"
'                StrSql = StrSql + "  " & SqlWhere & " ORDER BY A.INTIME DESC"
'                Using dt As DataTable = DAL.GetDataTable(StrSql)
'                    dgvPartNumber.DataSource = dt
'                    ToolStripStatusLabel1.Text = dt.Rows.Count & "笔"
'                End Using
'                dgvPartNumber.Columns(8).Visible = False
'                dgvPartNumber.Columns("ID").Visible = False
'                dgvPartNumber.Columns("备注").Visible = False
'            Case TabType.Equipment
'                StrSql = "SELECT " & IIf(download, "TOP 65536", " TOP 100") & " ID,PARTNUMBER 料件编号,DESCRIPTION 品名,DESCRIPTION1 规格," & vbNewLine & _
'                " CASE WHEN [STATUS]=1 THEN 'YES' ELSE 'NO' END 状态,USERID 创建人,INTIME 创建日期,'' 备注,TYPE 类别" & vbNewLine & _
'                " FROM M_RUNCARDPARTNUMBER_T(NOLOCK) A WHERE 1=1 AND TYPE='E' "
'                StrSql = StrSql + "  " & SqlWhere & " ORDER BY A.INTIME DESC"
'                Using dt As DataTable = DAL.GetDataTable(StrSql)
'                    dgvEquipment.DataSource = dt
'                    ToolStripStatusLabel1.Text = dt.Rows.Count & "笔"
'                End Using
'                dgvEquipment.Columns(8).Visible = False
'                dgvEquipment.Columns("ID").Visible = False
'                dgvEquipment.Columns("备注").Visible = False
'        End Select
'        DAL = Nothing
'        '"备注"列全屏显示
'        dgvPartNumber.Columns("备注").AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
'    End Sub
'#End Region

'#Region "检查输入"
'    Private Function CheckInput()
'        Dim PartNumber As String
'        Dim Desc As String
'        PartNumber = Me.txtPartNumber.Text.Trim
'        Desc = Me.txtDescription.Text.Trim
'        If String.IsNullOrEmpty(PartNumber) Then
'            MessageBox.Show("料号不能为空!")
'            Return False
'        End If
'        If String.IsNullOrEmpty(Desc) Then
'            MessageBox.Show("品名不能为空!")
'            Return False
'        End If
'        If cboType.SelectedIndex = -1 Then
'            MessageBox.Show("类型不能为空！")
'            Return False
'        ElseIf cboType.SelectedIndex = 0 Then
'            MessageBox.Show("类型不能为空！")
'            Return False
'        End If
'        Return True
'    End Function
'#End Region

'#Region "保存数据"
'    Private Sub SaveData()
'        Dim Status As Integer
'        Dim StrSql As String
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim PartNumber As String = txtPartNumber.Text.Trim()
'        Dim Desc As String = txtDescription.Text.Trim().Replace("'", "''")
'        Dim Desc1 As String = txtDescription1.Text.Trim().Replace("'", "''")
'        Status = Convert.ToInt16(cboStatus.SelectedItem.ToString().Substring(0, 1))
'        Dim index As Integer = TabControl1.SelectedIndex
'        Dim type As String = ""
'        type = cboType.SelectedItem.ToString.Substring(0, 1)
'        'TT中是否存在
'        If VbCommClass.VbCommClass.vIslinkErp = "Y" Then
'            Dim OracleObject As New OracleDb("")
'            Dim PartCount As Integer = OracleObject.ExecuteScalar("select count(1) from " & VbCommClass.VbCommClass.Factory & ".ima_file where ima01='" & PartNumber & "'")
'            If PartCount < 1 Then
'                OracleObject = Nothing
'                MessageBox.Show("TipTop系统中不存在该料号:" + PartNumber, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                Exit Sub
'            End If
'        End If
'        '
'        If OperateFlag = EditMode.ADD Then     '新增

'            Using reader As SqlClient.SqlDataReader = DAL.GetDataReader("select 1 from M_RUNCARDPARTNUMBER_T(nolock) where PartNumber='" & PartNumber & "'")
'                If reader.HasRows Then
'                    MessageBox.Show("系统已存在该料号:" + PartNumber, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                    Exit Sub
'                Else
'                    StrSql = "insert into M_RUNCARDPARTNUMBER_T(PartNumber,Description,Description1,Status,UserID,InTime,type) values (" & _
'                             "N'" & PartNumber & "',N'" & Desc & "',N'" & Desc1 & "'," & Status & ",'" & SysMessageClass.UseId & "',getdate(),'" & type & "' )"
'                End If
'            End Using

'            '料件是否存在
'            'Dim reader As SqlDataReader = DAL.GetDataReader("select 1 from M_RUNCARDPARTNUMBER_T(nolock) where PartNumber='" & PartNumber & "'")

'        Else 'If EditFlag = EditMode.MODIFY Then     '修改
'            StrSql = "update M_RUNCARDPARTNUMBER_T set PartNumber=N'" & PartNumber & "',[Description]=N'" & Desc & "',[Description1]=N'" & Desc1 & "',Status=" & Status & ",UserID='" & SysMessageClass.UseId & "',InTime=getdate() ,type='" & type & "' where ID=" & txtId.Text.Trim() & " "
'        End If
'        '执行SQL
'        DAL.ExecuteNonQuery(StrSql)
'    End Sub
'#End Region

'#Region "开关 GroupBox 面板控件状态"
'    Private Sub ToogleGroupBox(ByVal flag As Integer)
'        Select Case flag
'            Case 0
'                Me.txtPartNumber.Enabled = False
'                Me.txtDescription.Enabled = False
'                Me.txtDescription1.Enabled = False
'                Me.cboStatus.Enabled = False
'                Me.cboType.Enabled = False
'            Case 1
'                Me.txtPartNumber.Enabled = True
'                Me.txtDescription.Enabled = True
'                Me.txtDescription1.Enabled = True
'                Me.cboStatus.Enabled = True
'                Me.cboStatus.SelectedIndex = 0
'                Me.cboType.Enabled = True
'        End Select
'    End Sub
'#End Region

'#Region "清除 GroupBox 面板控件值"
'    Private Sub ClearGroupBox()
'        Me.txtPartNumber.Text = ""
'        Me.txtDescription.Text = ""
'        Me.txtDescription1.Text = ""
'        Me.txtId.Text = ""
'        'Me.cboStatus.SelectedItem = ""
'    End Sub
'#End Region

'#Region "给 GroupBox 面板控件赋值"
'    Private Sub SetGroupBox()
'        Dim index As Integer = TabControl1.SelectedIndex
'        If index = 0 Then
'            If Me.dgvPartNumber.RowCount < 1 Or Me.dgvPartNumber.CurrentRow.Index < 0 Then
'                Exit Sub
'            End If
'            Me.txtId.Text = Me.dgvPartNumber.Item(0, dgvPartNumber.CurrentRow.Index).Value.ToString()
'            Me.txtPartNumber.Text = Me.dgvPartNumber.Item(1, dgvPartNumber.CurrentRow.Index).Value.ToString()
'            Me.txtDescription.Text = Me.dgvPartNumber.Item(2, dgvPartNumber.CurrentRow.Index).Value.ToString()
'            Me.txtDescription1.Text = Me.dgvPartNumber.Item(3, dgvPartNumber.CurrentRow.Index).Value.ToString()
'            Me.cboStatus.SelectedIndex = IIf(Me.dgvPartNumber.Item(4, dgvPartNumber.CurrentRow.Index).Value.ToString.ToUpper = "YES", 0, 1)
'            Me.cboType.SelectedIndex = IIf(Me.dgvPartNumber.Item(8, dgvPartNumber.CurrentRow.Index).Value.ToString = "R", 2, -1)
'        Else

'            If Me.dgvEquipment.RowCount < 1 Or Me.dgvEquipment.CurrentRow.Index < 0 Then
'                Exit Sub
'            End If
'            Me.txtId.Text = Me.dgvEquipment.Item(0, dgvEquipment.CurrentRow.Index).Value.ToString()
'            Me.txtPartNumber.Text = Me.dgvEquipment.Item(1, dgvEquipment.CurrentRow.Index).Value.ToString()
'            Me.txtDescription.Text = Me.dgvEquipment.Item(2, dgvEquipment.CurrentRow.Index).Value.ToString()
'            Me.txtDescription1.Text = Me.dgvEquipment.Item(3, dgvEquipment.CurrentRow.Index).Value.ToString()
'            Me.cboStatus.SelectedIndex = IIf(Me.dgvEquipment.Item(4, dgvEquipment.CurrentRow.Index).Value.ToString.ToUpper = "YES", 0, 1)
'            Me.cboType.SelectedIndex = IIf(Me.dgvEquipment.Item(8, dgvEquipment.CurrentRow.Index).Value.ToString = "E", 1, 0)
'        End If

'    End Sub
'#End Region

'    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
'        '设置操作模式
'        OperateFlag = EditMode.ADD
'        '工具栏控件状态
'        SetControlStatus(EditMode.ADD)
'        '清除面板控件值
'        ClearGroupBox()
'        '面板控件可写
'        ToogleGroupBox(1)
'        '
'        Me.txtPartNumber.Focus()
'    End Sub

'    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
'        '设置操作模式
'        OperateFlag = EditMode.EDIT
'        '工具栏控件状态
'        SetControlStatus(EditMode.EDIT)
'        '面板控件可写
'        ToogleGroupBox(1)
'        '面板控件赋值
'        SetGroupBox()
'    End Sub

'    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
'        Try
'            Dim index As Integer = TabControl1.SelectedIndex
'            If Me.OperateFlag = EditMode.ADD Or Me.OperateFlag = EditMode.EDIT Then
'                '检查输入
'                If CheckInput() = False Then
'                    Exit Sub
'                End If
'                '保存
'                SaveData()
'                '清除面板控件值
'                ClearGroupBox()
'                '
'                ToogleGroupBox(0)
'                '刷新
'                LoadData("", [Enum].Parse(GetType(TabType), index.ToString))
'            End If
'        Catch ex As Exception
'            SysMessageClass.WriteErrLog(ex, "FrmPartNumber", "btnSave_Click", "sys")
'        End Try
'    End Sub

'    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
'        Me.Close()

'    End Sub

'    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
'        '设置操作模式
'        OperateFlag = EditMode.SEARCH
'        '工具栏控件状态
'        SetControlStatus(OperateFlag)
'        '清除面板控件值
'        ClearGroupBox()
'        '面板控件可写
'        ToogleGroupBox(1)
'        '
'        Me.txtPartNumber.Focus()
'    End Sub

'    '#Region "清除控件值"
'    '    Private Sub ClearControl()
'    '        Dim ClearCon As Control
'    '        For Each ClearCon In Me.Controls
'    '            If TypeOf ClearCon Is System.Windows.Forms.TextBox Then
'    '                ClearCon.Text = ""
'    '                'ElseIf TypeOf ClearCon Is ComboBox Then
'    '                '    ClearCon.Text = ""
'    '            End If
'    '        Next
'    '    End Sub
'    '#End Region

'    '#Region "控件有效性设置"

'    '    Private Sub EnableControl(ByVal Flag As Integer)

'    '        Dim EmsCon As Control
'    '        Select Case Flag
'    '            Case 1
'    '                Me.dgvPartNumber.Enabled = True
'    '                For Each EmsCon In Me.Controls
'    '                    If TypeOf EmsCon Is System.Windows.Forms.TextBox Then
'    '                        EmsCon.Enabled = True
'    '                    ElseIf TypeOf EmsCon Is System.Windows.Forms.CheckBox Then
'    '                        EmsCon.Enabled = True
'    '                    ElseIf TypeOf EmsCon Is ComboBox Then
'    '                        EmsCon.Enabled = True
'    '                    End If

'    '                Next
'    '                'dgvPartNumber.Enabled = False
'    '            Case 0
'    '                For Each EmsCon In Me.Controls
'    '                    If TypeOf EmsCon Is System.Windows.Forms.TextBox Then
'    '                        EmsCon.Enabled = False
'    '                    ElseIf TypeOf EmsCon Is System.Windows.Forms.CheckBox Then
'    '                        EmsCon.Enabled = False
'    '                    ElseIf TypeOf EmsCon Is ComboBox Then
'    '                        EmsCon.Enabled = False
'    '                    End If

'    '                Next
'    '                dgvPartNumber.Enabled = True
'    '        End Select
'    '    End Sub

'    '#End Region


'    '#Region "控件赋值"
'    '    Private Sub SetValueToControl()

'    '        If Me.dgvPartNumber.RowCount < 1 Then Exit Sub
'    '        If Me.dgvPartNumber.CurrentRow.Index < 0 Then Exit Sub
'    '        Me.txtId.Text = Me.dgvPartNumber.Item(0, dgvPartNumber.CurrentRow.Index).Value.ToString()
'    '        Me.txtPartNumber.Text = Me.dgvPartNumber.Item(1, dgvPartNumber.CurrentRow.Index).Value.ToString()
'    '        Me.txtDescription.Text = Me.dgvPartNumber.Item(2, dgvPartNumber.CurrentRow.Index).Value.ToString()
'    '        Me.cboStatus.SelectedIndex = IIf(Me.dgvPartNumber.Item(3, dgvPartNumber.CurrentRow.Index).Value.ToString.ToUpper = "YES", 0, 1)
'    '    End Sub
'    '#End Region

'    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
'        If OperateFlag <> EditMode.SEARCH Then
'            Exit Sub
'        End If
'        Try
'            Dim index As Integer = TabControl1.SelectedIndex
'            Dim sbSqlWhere As New StringBuilder
'            If Me.txtPartNumber.Text.Trim() <> "" Then
'                sbSqlWhere.Append(" and PartNumber like N'%" & txtPartNumber.Text.Trim().Replace("'", "''") & "%' ")
'            End If
'            If Me.txtDescription.Text.Trim() <> "" Then
'                sbSqlWhere.Append(" and [Description] like N'%" & txtDescription.Text.Trim().Replace("'", "''") & "%' ")
'            End If
'            If Me.txtDescription1.Text.Trim() <> "" Then
'                sbSqlWhere.Append(" and [Description1] like N'%" & txtDescription1.Text.Trim().Replace("'", "''") & "%' ")
'            End If
'            If Me.cboStatus.SelectedItem.ToString() <> "" Then
'                sbSqlWhere.Append(" and [Status] = " & cboStatus.SelectedItem.ToString().Substring(0, 1) & " ")
'            End If
'            LoadData(sbSqlWhere.ToString(), [Enum].Parse(GetType(TabType), index.ToString))
'        Catch ex As Exception
'            SysMessageClass.WriteErrLog(ex, "FrmPartNumber", "btnRefresh_Click", "sys")
'        End Try

'    End Sub

'    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
'        '设置操作模式
'        OperateFlag = EditMode.UNDO
'        '工具栏控件状态
'        SetControlStatus(EditMode.UNDO)
'        '清除面板控件值
'        ClearGroupBox()
'        '面板控件只读
'        ToogleGroupBox(0)
'        ''
'    End Sub

'    Private Sub dgvPartNumber_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPartNumber.CellClick
'        If dgvPartNumber.RowCount < 1 Or dgvPartNumber.CurrentRow.Index < 0 Then Exit Sub
'        '新增、查询 模式下不可操作
'        If OperateFlag = EditMode.ADD Or OperateFlag = EditMode.SEARCH Then
'            Exit Sub
'        End If
'        '面板控件赋值
'        SetGroupBox()

'    End Sub

'    Private Sub dgvEquipment_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEquipment.CellClick
'        If dgvPartNumber.RowCount < 1 Or dgvPartNumber.CurrentRow.Index < 0 Then Exit Sub
'        '新增、查询 模式下不可操作
'        If OperateFlag = EditMode.ADD Or OperateFlag = EditMode.SEARCH Then
'            Exit Sub
'        End If
'        '面板控件赋值
'        SetGroupBox()

'    End Sub
'#Region "复制记录"
'    Private Sub tsmiCopyRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiCopyRecord.Click
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            '
'            Dim index As Integer = TabControl1.SelectedIndex
'            Dim PartNumber As String = Nothing '
'            Dim p As New SqlClient.SqlParameter
'            Dim param1 As New SqlParameter("@OldPartID", SqlDbType.Int, ParameterDirection.Input)
'            Dim param2 As New SqlParameter("@OldPartNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input)
'            Dim param3 As New SqlParameter("@UserID", SqlDbType.NVarChar, 50, ParameterDirection.Input)
'            Dim param4 As New SqlParameter("@ErrMsg", SqlDbType.NVarChar, 200)
'            If MessageBox.Show("确认复制工站""" & PartNumber & """?", "复制确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
'                Exit Sub
'            End If
'            '参数定义

'            '参数赋值
'            If index = 0 Then
'                param1.Value = CInt(dgvPartNumber.Rows(dgvPartNumber.CurrentRow.Index).Cells("ID").Value.ToString)
'                PartNumber = dgvPartNumber.Rows(dgvPartNumber.CurrentRow.Index).Cells("料件编号").Value.ToString
'            Else
'                param1.Value = CInt(dgvEquipment.Rows(dgvEquipment.CurrentRow.Index).Cells("ID").Value.ToString)
'                PartNumber = dgvEquipment.Rows(dgvEquipment.CurrentRow.Index).Cells("料件编号").Value.ToString
'            End If

'            param2.Value = PartNumber
'            param3.Value = SysMessageClass.UseId
'            param4.Direction = ParameterDirection.Output '?指定
'            param4.Value = ""
'            Dim Paramters As SqlParameter() = Nothing
'            Paramters = New SqlParameter() {param1, param2, param3, param4}
'            '执行SP
'            DAL.ExecuteNonQureyByProc("udpCopyPartNumber", Paramters)
'            If Not String.IsNullOrEmpty(param4.Value.ToString()) Then
'                MessageBox.Show(param4.Value.ToString())
'                Exit Sub
'            End If
'            MessageBox.Show("复制成功^_^ ")
'            '刷新
'            LoadData("", [Enum].Parse(GetType(TabType), index.ToString))
'        Catch ex As Exception
'            SysMessageClass.WriteErrLog(ex, "FrmPartNumber", "tsmiCopyRecord_Click", "sys")
'        Finally
'            DAL = Nothing
'        End Try
'    End Sub
'#End Region

'#Region "绑定右健菜单"
'    Private Sub dgvPartNumber_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvPartNumber.CellContextMenuStripNeeded, dgvPartNumber.CellContextMenuStripNeeded
'        'Dim dgv As DataGridView = CType(sender, DataGridView)
'        If e.RowIndex >= 0 Then
'            e.ContextMenuStrip = Me.ContextMenuStrip1
'        End If
'    End Sub

'    Private Sub dgvEquipment_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvEquipment.CellContextMenuStripNeeded, dgvEquipment.CellContextMenuStripNeeded
'        'Dim dgv As DataGridView = CType(sender, DataGridView)
'        If e.RowIndex >= 0 Then
'            e.ContextMenuStrip = Me.ContextMenuStrip1
'        End If
'    End Sub
'#End Region

'#Region "右健改变当前行号"
'    Private Sub dgvPartNumber_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPartNumber.CellMouseDown, dgvPartNumber.CellMouseDown
'        If e.Button = Windows.Forms.MouseButtons.Right Then
'            If e.RowIndex >= 0 Then
'                dgvPartNumber.ClearSelection()
'                dgvPartNumber.Rows(e.RowIndex).Selected = True
'                dgvPartNumber.CurrentCell = dgvPartNumber.Rows(e.RowIndex).Cells(e.ColumnIndex)
'                'dgvPartNumber.DefaultCellStyle.ForeColor = DefaultForeColor
'                'dgvPartNumber.CurrentRow.DefaultCellStyle.ForeColor = Color.Blue
'            End If
'        End If

'    End Sub

'    Private Sub dgvEquipment_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvEquipment.CellMouseDown, dgvEquipment.CellMouseDown
'        If e.Button = Windows.Forms.MouseButtons.Right Then
'            If e.RowIndex >= 0 Then
'                dgvEquipment.ClearSelection()
'                dgvEquipment.Rows(e.RowIndex).Selected = True
'                dgvEquipment.CurrentCell = dgvEquipment.Rows(e.RowIndex).Cells(e.ColumnIndex)
'                'dgvPartNumber.DefaultCellStyle.ForeColor = DefaultForeColor
'                'dgvPartNumber.CurrentRow.DefaultCellStyle.ForeColor = Color.Blue
'            End If
'        End If

'    End Sub
'#End Region

'#Region "复制单元格"
'    Private Sub tsmiCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiCopy.Click
'        Dim index As Integer = TabControl1.SelectedIndex
'        If index = 0 Then
'            If Not dgvPartNumber.CurrentCell Is Nothing Then
'                Dim Selected As String = dgvPartNumber.CurrentCell.Value.ToString()
'                Clipboard.SetDataObject(Selected)
'            End If
'        Else
'            If Not dgvEquipment.CurrentCell Is Nothing Then
'                Dim Selected As String = dgvEquipment.CurrentCell.Value.ToString()
'                Clipboard.SetDataObject(Selected)
'            End If
'        End If
'    End Sub
'#End Region

'#Region "背景色"
'    Private Sub dgvPartNumber_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvPartNumber.DataBindingComplete, dgvPartNumber.DataBindingComplete
'        For Each item As DataGridViewRow In dgvPartNumber.Rows

'            If item.Cells("状态").Value.ToString() = "No" Then
'                item.DefaultCellStyle.ForeColor = Color.Red
'            End If

'            If item.Index Mod 2 = 0 Then
'                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
'            End If
'        Next
'    End Sub

'    Private Sub dgvEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvEquipment.DataBindingComplete, dgvEquipment.DataBindingComplete
'        For Each item As DataGridViewRow In dgvEquipment.Rows

'            If item.Cells("状态").Value.ToString() = "No" Then
'                item.DefaultCellStyle.ForeColor = Color.Red
'            End If

'            If item.Index Mod 2 = 0 Then
'                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
'            End If
'        Next
'    End Sub
'#End Region



'    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
'        'If TabControl1.SelectedIndex = 0 Then
'        '    LoadData("", TabType.RAW)
'        'Else
'        '    LoadData("", TabType.Equipment)
'        'End If
'    End Sub

'    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
'        SetControlStatus(EditMode.EXPORT)
'        'Dim frm As New FrmShowRunCard
'        'frm.reportInputParametersVar.printerName = "CutePDF Writer"
'        'Using dt As New DataTable
'        '    Dim a As DataRow = dt.NewRow
'        '    Dim b As DataRow = dt.NewRow
'        '    dt.Rows.Add(a)
'        '    dt.Rows.Add(b)
'        '    dt.Columns.Add("EquipmentNo", GetType(String))
'        '    dt.Rows(0)(0) = "AAAAAAAAAAA"
'        '    dt.Rows(1)(0) = "AAAAAAAA"
'        '    'frm.PrintEquipment(FrmShowRunCard.EquipmentType.MJ, dt)
'        '    frm.PrintEquipment(FrmShowRunCard.EquipmentType.DM, dt)
'        'End Using

'    End Sub

'    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
'        OpenFileDialog.Filter = "选择文件|*.xls;*.xlsx"
'        Dim result As DialogResult = OpenFileDialog.ShowDialog()
'        If result = System.Windows.Forms.DialogResult.OK Then
'            Cursor.Current = Cursors.WaitCursor
'            txtPath.Text = OpenFileDialog.FileName
'            Cursor.Current = Cursors.Default
'        End If
'    End Sub

'    Private Sub btnBExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBExport.Click
'        Dim errorMsg As String = Nothing
'        Dim sql As String = Nothing
'        Dim index As Integer = 0
'        Try
'            index = TabControl1.SelectedIndex
'            sql = "SELECT [料件编号] AS PartNumber,[品名] AS Description,[规格] AS Description1,'" & VbCommClass.VbCommClass.UseId & "' AS UserID,'E' AS Type FROM [Sheet1$] WHERE [料件编号] IS NOT NULL"
'            Using dt As DataTable = SysDataBaseClass.ExportFromExcel(txtPath.Text, True, SysDataBaseClass.OfficeVersion.Off8Version, sql, errorMsg)
'                If dt Is Nothing Then
'                    MessageBox.Show(errorMsg, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                    Exit Sub
'                End If
'                If CheckData(dt) Then
'                    MessageBox.Show("上传成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                    txtPath.Text = ""
'                    SetControlStatus(EditMode.UNDO)
'                    LoadData("", [Enum].Parse(GetType(TabType), index.ToString))
'                End If
'            End Using
'        Catch ex As Exception
'            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'        End Try
'    End Sub

'    Private Function CheckData(ByVal dt As DataTable) As Boolean
'        Using dv As DataView = New DataView(dt)
'            If dv.Count <> dv.ToTable(True, "PartNumber").Rows.Count Then
'                MessageBox.Show("表格中存在相同的料件编号请确认！！！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                Return False
'            End If
'        End Using
'        If dt.Select("Description IS NULL").Length > 0 Then
'            MessageBox.Show("表格中品名列存在为空项请确认！！！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            Return False
'        End If
'        Dim sConn As New SysDataBaseClass
'        Dim sql As String = "SELECT A.PARTNUMBER FROM M_RUNCARDPARTNUMBER_T A WHERE A.TYPE='E'"
'        Using dtPart As DataTable = sConn.GetDataTable(sql)
'            For Each dr As DataRow In dt.Rows
'                If dtPart.Select("PARTNUMBER='" & dr(0).ToString & "'").Length > 0 Then
'                    MessageBox.Show("料件编号" & dr(0).ToString & "已存在请确认！！！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                    Return False
'                End If
'            Next
'        End Using
'        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
'        dics.Add("PartNumber", "PartNumber")
'        dics.Add("Description", "Description")
'        dics.Add("Description1", "Description1")
'        dics.Add("UserID", "UserID")
'        dics.Add("TYPE", "TYPE")
'        If Not sConn.BulkCopy(dt, "M_RUNCARDPARTNUMBER_T", dics) Then
'            Return False
'        End If
'        Return True
'    End Function

'    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
'        SetControlStatus(EditMode.SEARCH)
'        '面板控件可写
'        ToogleGroupBox(1)
'        '面板控件赋值
'        'SetGroupBox()
'        SetControlStatus(EditMode.IMPORT)

'        FolderBrowserDialog1.Description = "请选择文件存储目录"
'        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
'        FolderBrowserDialog1.ShowNewFolderButton = True
'        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
'        If result = System.Windows.Forms.DialogResult.OK Then
'            Cursor.Current = Cursors.WaitCursor
'            txtPath.Text = FolderBrowserDialog1.SelectedPath
'            Cursor.Current = Cursors.Default
'        End If

'    End Sub

'    Private Function GetSqlWhere() As String
'        Dim index As Integer = TabControl1.SelectedIndex
'        Dim sbSqlWhere As New StringBuilder
'        If Me.txtPartNumber.Text.Trim() <> "" Then
'            sbSqlWhere.Append(" and PartNumber like N'%" & txtPartNumber.Text.Trim().Replace("'", "''") & "%' ")
'        End If
'        If Me.txtDescription.Text.Trim() <> "" Then
'            sbSqlWhere.Append(" and [Description] like N'%" & txtDescription.Text.Trim().Replace("'", "''") & "%' ")
'        End If
'        If Me.txtDescription1.Text.Trim() <> "" Then
'            sbSqlWhere.Append(" and [Description1] like N'%" & txtDescription1.Text.Trim().Replace("'", "''") & "%' ")
'        End If
'        If Me.cboStatus.SelectedItem.ToString() <> "" Then
'            sbSqlWhere.Append(" and [Status] = " & cboStatus.SelectedItem.ToString().Substring(0, 1) & " ")
'        End If
'        If Me.cboType.SelectedItem.ToString() <> "" Then
'            sbSqlWhere.Append(" and [TYPE] = '" & cboType.SelectedItem.ToString().Substring(0, 1) & "' ")
'        End If
'        Return sbSqlWhere.ToString
'    End Function

'    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
'        Dim strsql As String = Nothing
'        Dim sqlWhere As String = Nothing
'        Dim sConn As New SysDataBaseClass
'        Dim strImportSql As StringBuilder
'        Dim strFields As String = Nothing
'        Dim fileName As String = ""
'        If cboType.SelectedIndex = -1 Then
'            MessageBox.Show("请选择类别", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            Exit Sub
'        End If
'        Try

'            OperateFlag = EditMode.SEARCH
'            sqlWhere = GetSqlWhere()
'            strsql = "SELECT TOP 65536 PARTNUMBER 料件编号,DESCRIPTION 品名,DESCRIPTION1 规格," & vbNewLine & _
'              " CASE WHEN [STATUS]=1 THEN '有效' ELSE '无效' END 状态,USERID 创建人,INTIME 创建日期" & vbNewLine & _
'              " FROM M_RUNCARDPARTNUMBER_T(NOLOCK) A WHERE 1=1 "
'            strsql = strsql + "  " & sqlWhere & " ORDER BY A.INTIME DESC"

'            strImportSql = New StringBuilder()
'            Using dt As DataTable = sConn.GetDataTable(strsql)
'                If dt.Rows.Count > 0 Then
'                    fileName = txtPath.Text + "\料件资料_" + Date.Now.ToString("yyyyMMddHHmmssfff") + ".xlsx"
'                    If SysDataBaseClass.Import2Excel(fileName, dt, 1, 1) Then
'                        MessageBox.Show("文件产生成功请查看", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                        txtPath.Text = ""
'                        btnDownload.Enabled = False
'                    End If
'                Else
'                    MessageBox.Show("没有资料可供下载,请确认查询条件", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                End If
'            End Using
'        Catch ex As Exception
'            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
'        End Try
'    End Sub
'End Class
#End Region


Public Class FrmPartNumber
    '变量定义
    Dim OperateFlag As EditMode '操作模式
    Dim IsSearch As Boolean = False
    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
        EXPORT
        IMPORT
    End Enum

    Public Enum TabType
        RAW = 0
        Equipment
    End Enum

    Private Sub FrmPartNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '设定用戶權限
            Dim ERigth As New SysDataBaseClass
            ERigth.GetControlright(Me)
            '
            ERigth.GetContextMenuRight(Me, Me.ContextMenuStrip1)
            '设置当前操作模式
            Me.OperateFlag = EditMode.UNDO
            '设置工具栏按钮状态
            SetControlStatus(Me.OperateFlag)
            '设置面板组控件状态
            ToogleGroupBox(0)
            '绑定数据
            LoadData("", TabType.RAW)
            LoadData("", TabType.Equipment)
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & "错误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub


#Region "设置工具栏控件状态"

    Private Sub SetControlStatus(ByVal flag As EditMode)

        Select Case UCase(flag)
            Case EditMode.ADD '新增

                btnModify.Enabled = False

                btnSave.Enabled = True
                btnUndo.Enabled = True

                btnSearch.Enabled = False
                btnRefresh.Enabled = False
                btnBExport.Enabled = False
                btnScan.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False

            Case EditMode.EDIT '修改

                btnNew.Enabled = False

                btnSave.Enabled = True
                btnUndo.Enabled = True

                btnSearch.Enabled = False
                btnRefresh.Enabled = False
                btnBExport.Enabled = False
                btnScan.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False

            Case EditMode.UNDO '初始化

                Me.btnNew.Enabled = IIf(btnNew.Tag.ToString = "YES", True, False)
                Me.btnModify.Enabled = IIf(btnModify.Tag.ToString = "YES", True, False)
                Me.tsmiCopyRecord.Enabled = IIf(tsmiCopyRecord.Tag.ToString = "YES", True, False)

                btnSave.Enabled = False
                btnUndo.Enabled = False

                btnSearch.Enabled = True
                btnRefresh.Enabled = False
                btnExport.Enabled = IIf(btnNew.Tag.ToString = "YES", True, False)
                btnBExport.Enabled = False
                btnScan.Enabled = False
                btnDownload.Enabled = False

            Case EditMode.SEARCH '搜索

                Me.btnNew.Enabled = False
                Me.btnModify.Enabled = False
                Me.tsmiCopyRecord.Enabled = False

                'Me.cboStatus.SelectedIndex = -1

                btnUndo.Enabled = True
                btnSave.Enabled = False

                btnSearch.Enabled = True
                btnRefresh.Enabled = True
                btnBExport.Enabled = btnExport.Enabled
                btnScan.Enabled = btnExport.Enabled
                btnExport.Enabled = False
                btnDownload.Enabled = False

            Case EditMode.EXPORT
                btnBExport.Enabled = True
                btnScan.Enabled = True
                btnUndo.Enabled = True
                btnDownload.Enabled = False
                txtPath.Text = ""
            Case EditMode.IMPORT
                txtPath.Text = ""
                btnBExport.Enabled = False
                btnScan.Enabled = False
                btnUndo.Enabled = True
                btnDownload.Enabled = True

        End Select

    End Sub
#End Region

#Region "加载数据"
    Private Sub LoadData(ByVal SqlWhere As String, ByVal type As TabType, Optional ByVal download As Boolean = False)
        Dim StrSql As String = Nothing
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Select Case type
            Case TabType.RAW
                StrSql = "SELECT " & IIf(download, "TOP 65536", " TOP 100") & " ID,PARTNUMBER 料件编号,DESCRIPTION 品名,DESCRIPTION1 规格," & vbNewLine & _
                " CASE WHEN [STATUS]=1 THEN 'YES' ELSE 'NO' END 状态,USERID 创建人,INTIME 创建日期,'' 备注,TYPE 类别" & vbNewLine & _
                " FROM M_RUNCARDPARTNUMBER_T(NOLOCK) A WHERE 1=1 AND (TYPE IS NULL OR TYPE='R')"
                StrSql = StrSql + "  " & SqlWhere & " ORDER BY A.INTIME DESC"
                Using dt As DataTable = DAL.GetDataTable(StrSql)
                    dgvPartNumber.DataSource = dt
                    ToolStripStatusLabel1.Text = dt.Rows.Count & "笔"
                End Using
                dgvPartNumber.Columns(8).Visible = False
                dgvPartNumber.Columns("ID").Visible = False
                dgvPartNumber.Columns("备注").Visible = False
            Case TabType.Equipment
                StrSql = "SELECT " & IIf(download, "TOP 65536", " TOP 100") & " ID,PARTNUMBER 料件编号,DESCRIPTION 品名,DESCRIPTION1 规格," & vbNewLine & _
                " CASE WHEN [STATUS]=1 THEN 'YES' ELSE 'NO' END 状态,USERID 创建人,INTIME 创建日期,'' 备注,TYPE 类别" & vbNewLine & _
                " FROM M_RUNCARDPARTNUMBER_T(NOLOCK) A WHERE 1=1 AND TYPE='E' "
                StrSql = StrSql + "  " & SqlWhere & " ORDER BY A.INTIME DESC"
                Using dt As DataTable = DAL.GetDataTable(StrSql)
                    dgvEquipment.DataSource = dt
                    ToolStripStatusLabel1.Text = dt.Rows.Count & "笔"
                End Using
                dgvEquipment.Columns(8).Visible = False
                dgvEquipment.Columns("ID").Visible = False
                dgvEquipment.Columns("备注").Visible = False
        End Select
        DAL = Nothing
        '"备注"列全屏显示
        dgvPartNumber.Columns("备注").AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    End Sub
#End Region

#Region "检查输入"
    Private Function CheckInput()
        Dim PartNumber As String
        Dim Desc As String
        PartNumber = Me.txtPartNumber.Text.Trim
        Desc = Me.txtDescription.Text.Trim
        If String.IsNullOrEmpty(PartNumber) Then
            MessageBox.Show("料号不能为空!")
            Return False
        End If
        If String.IsNullOrEmpty(Desc) Then
            MessageBox.Show("品名不能为空!")
            Return False
        End If
        If cboType.SelectedIndex = -1 Then
            MessageBox.Show("类型不能为空！")
            Return False
        ElseIf cboType.SelectedIndex = 0 Then
            MessageBox.Show("类型不能为空！")
            Return False
        End If
        Return True
    End Function
#End Region

#Region "保存数据"
    Private Sub SaveData()
        Dim Status As Integer
        Dim StrSql As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim PartNumber As String = txtPartNumber.Text.Trim()
        Dim Desc As String = txtDescription.Text.Trim().Replace("'", "''")
        Dim Desc1 As String = txtDescription1.Text.Trim().Replace("'", "''")
        Status = Convert.ToInt16(cboStatus.SelectedItem.ToString().Substring(0, 1))
        Dim index As Integer = TabControl1.SelectedIndex
        Dim type As String = ""
        type = cboType.SelectedItem.ToString.Substring(0, 1)
        'TT中是否存在
        If VbCommClass.VbCommClass.vIslinkErp = "Y" Then
            Dim OracleObject As New OracleDb("")
            Dim PartCount As Integer = OracleObject.ExecuteScalar("select count(1) from " & VbCommClass.VbCommClass.Factory & ".ima_file where ima01='" & PartNumber & "'")
            If PartCount < 1 Then
                OracleObject = Nothing
                MessageBox.Show("TipTop系统中不存在该料号:" + PartNumber, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If
        '
        If OperateFlag = EditMode.ADD Then     '新增

            Using reader As SqlClient.SqlDataReader = DAL.GetDataReader("select 1 from M_RUNCARDPARTNUMBER_T(nolock) where PartNumber='" & PartNumber & "'")
                If reader.HasRows Then
                    MessageBox.Show("系统已存在该料号:" + PartNumber, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    StrSql = "insert into M_RUNCARDPARTNUMBER_T(PartNumber,Description,Description1,Status,UserID,InTime,type) values (" & _
                             "N'" & PartNumber & "',N'" & Desc & "',N'" & Desc1 & "'," & Status & ",'" & SysMessageClass.UseId & "',getdate(),'" & type & "' )"
                End If
            End Using

            '料件是否存在
            'Dim reader As SqlDataReader = DAL.GetDataReader("select 1 from M_RUNCARDPARTNUMBER_T(nolock) where PartNumber='" & PartNumber & "'")

        Else 'If EditFlag = EditMode.MODIFY Then     '修改
            StrSql = "update M_RUNCARDPARTNUMBER_T set PartNumber=N'" & PartNumber & "',[Description]=N'" & Desc & "',[Description1]=N'" & Desc1 & "',Status=" & Status & ",UserID='" & SysMessageClass.UseId & "',InTime=getdate() ,type='" & type & "' where ID=" & txtId.Text.Trim() & " "
        End If
        '执行SQL
        DAL.ExecuteNonQuery(StrSql)
    End Sub
#End Region

#Region "开关 GroupBox 面板控件状态"
    Private Sub ToogleGroupBox(ByVal flag As Integer)
        Select Case flag
            Case 0
                Me.txtPartNumber.Enabled = False
                Me.txtDescription.Enabled = False
                Me.txtDescription1.Enabled = False
                Me.cboStatus.Enabled = False
                Me.cboType.Enabled = False
            Case 1
                Me.txtPartNumber.Enabled = True
                Me.txtDescription.Enabled = True
                Me.txtDescription1.Enabled = True
                Me.cboStatus.Enabled = True
                Me.cboStatus.SelectedIndex = 0
                Me.cboType.Enabled = True
        End Select
    End Sub
#End Region

#Region "清除 GroupBox 面板控件值"
    Private Sub ClearGroupBox()
        Me.txtPartNumber.Text = ""
        Me.txtDescription.Text = ""
        Me.txtDescription1.Text = ""
        Me.txtId.Text = ""
        'Me.cboStatus.SelectedItem = ""
    End Sub
#End Region

#Region "给 GroupBox 面板控件赋值"
    Private Sub SetGroupBox()
        Dim index As Integer = TabControl1.SelectedIndex
        If index = 0 Then
            If Me.dgvPartNumber.RowCount < 1 Or Me.dgvPartNumber.CurrentRow.Index < 0 Then
                Exit Sub
            End If
            Me.txtId.Text = Me.dgvPartNumber.Item(0, dgvPartNumber.CurrentRow.Index).Value.ToString()
            Me.txtPartNumber.Text = Me.dgvPartNumber.Item(1, dgvPartNumber.CurrentRow.Index).Value.ToString()
            Me.txtDescription.Text = Me.dgvPartNumber.Item(2, dgvPartNumber.CurrentRow.Index).Value.ToString()
            Me.txtDescription1.Text = Me.dgvPartNumber.Item(3, dgvPartNumber.CurrentRow.Index).Value.ToString()
            Me.cboStatus.SelectedIndex = IIf(Me.dgvPartNumber.Item(4, dgvPartNumber.CurrentRow.Index).Value.ToString.ToUpper = "YES", 0, 1)
            Me.cboType.SelectedIndex = IIf(Me.dgvPartNumber.Item(8, dgvPartNumber.CurrentRow.Index).Value.ToString = "R", 2, -1)
        Else

            If Me.dgvEquipment.RowCount < 1 Or Me.dgvEquipment.CurrentRow.Index < 0 Then
                Exit Sub
            End If
            Me.txtId.Text = Me.dgvEquipment.Item(0, dgvEquipment.CurrentRow.Index).Value.ToString()
            Me.txtPartNumber.Text = Me.dgvEquipment.Item(1, dgvEquipment.CurrentRow.Index).Value.ToString()
            Me.txtDescription.Text = Me.dgvEquipment.Item(2, dgvEquipment.CurrentRow.Index).Value.ToString()
            Me.txtDescription1.Text = Me.dgvEquipment.Item(3, dgvEquipment.CurrentRow.Index).Value.ToString()
            Me.cboStatus.SelectedIndex = IIf(Me.dgvEquipment.Item(4, dgvEquipment.CurrentRow.Index).Value.ToString.ToUpper = "YES", 0, 1)
            Me.cboType.SelectedIndex = IIf(Me.dgvEquipment.Item(8, dgvEquipment.CurrentRow.Index).Value.ToString = "E", 1, 0)
        End If

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
        Me.txtPartNumber.Focus()
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
            Dim index As Integer = TabControl1.SelectedIndex
            If Me.OperateFlag = EditMode.ADD Or Me.OperateFlag = EditMode.EDIT Then
                '检查输入
                If CheckInput() = False Then
                    Exit Sub
                End If
                '保存
                SaveData()
                '清除面板控件值
                ClearGroupBox()
                '
                ToogleGroupBox(0)
                '刷新
                LoadData("", [Enum].Parse(GetType(TabType), index.ToString))
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPartNumber", "btnSave_Click", "sys")
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
        Me.txtPartNumber.Focus()
    End Sub


    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        If OperateFlag <> EditMode.SEARCH Then
            Exit Sub
        End If
        Try
            Dim index As Integer = TabControl1.SelectedIndex
            Dim sbSqlWhere As New StringBuilder
            If Me.txtPartNumber.Text.Trim() <> "" Then
                sbSqlWhere.Append(" and PartNumber like N'%" & txtPartNumber.Text.Trim().Replace("'", "''") & "%' ")
            End If
            If Me.txtDescription.Text.Trim() <> "" Then
                sbSqlWhere.Append(" and [Description] like N'%" & txtDescription.Text.Trim().Replace("'", "''") & "%' ")
            End If
            If Me.txtDescription1.Text.Trim() <> "" Then
                sbSqlWhere.Append(" and [Description1] like N'%" & txtDescription1.Text.Trim().Replace("'", "''") & "%' ")
            End If
            If Me.cboStatus.SelectedItem.ToString() <> "" Then
                sbSqlWhere.Append(" and [Status] = " & cboStatus.SelectedItem.ToString().Substring(0, 1) & " ")
            End If
            LoadData(sbSqlWhere.ToString(), [Enum].Parse(GetType(TabType), index.ToString))
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPartNumber", "btnRefresh_Click", "sys")
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

    Private Sub dgvPartNumber_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPartNumber.CellClick
        If dgvPartNumber.RowCount < 1 Or dgvPartNumber.CurrentRow.Index < 0 Then Exit Sub
        '新增、查询 模式下不可操作
        If OperateFlag = EditMode.ADD Or OperateFlag = EditMode.SEARCH Then
            Exit Sub
        End If
        '面板控件赋值
        SetGroupBox()

    End Sub

    Private Sub dgvEquipment_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEquipment.CellClick
        If dgvPartNumber.RowCount < 1 Or dgvPartNumber.CurrentRow.Index < 0 Then Exit Sub
        '新增、查询 模式下不可操作
        If OperateFlag = EditMode.ADD Or OperateFlag = EditMode.SEARCH Then
            Exit Sub
        End If
        '面板控件赋值
        SetGroupBox()

    End Sub
#Region "复制记录"
    Private Sub tsmiCopyRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiCopyRecord.Click
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            '
            Dim index As Integer = TabControl1.SelectedIndex
            Dim PartNumber As String = Nothing '
            Dim p As New SqlClient.SqlParameter
            Dim param1 As New SqlParameter("@OldPartID", SqlDbType.Int, ParameterDirection.Input)
            Dim param2 As New SqlParameter("@OldPartNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input)
            Dim param3 As New SqlParameter("@UserID", SqlDbType.NVarChar, 50, ParameterDirection.Input)
            Dim param4 As New SqlParameter("@ErrMsg", SqlDbType.NVarChar, 200)
            If MessageBox.Show("确认复制工站""" & PartNumber & """?", "复制确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            '参数定义

            '参数赋值
            If index = 0 Then
                param1.Value = CInt(dgvPartNumber.Rows(dgvPartNumber.CurrentRow.Index).Cells("ID").Value.ToString)
                PartNumber = dgvPartNumber.Rows(dgvPartNumber.CurrentRow.Index).Cells("料件编号").Value.ToString
            Else
                param1.Value = CInt(dgvEquipment.Rows(dgvEquipment.CurrentRow.Index).Cells("ID").Value.ToString)
                PartNumber = dgvEquipment.Rows(dgvEquipment.CurrentRow.Index).Cells("料件编号").Value.ToString
            End If

            param2.Value = PartNumber
            param3.Value = SysMessageClass.UseId
            param4.Direction = ParameterDirection.Output '?指定
            param4.Value = ""
            Dim Paramters As SqlParameter() = Nothing
            Paramters = New SqlParameter() {param1, param2, param3, param4}
            '执行SP
            DAL.ExecuteNonQureyByProc("udpCopyPartNumber", Paramters)
            If Not String.IsNullOrEmpty(param4.Value.ToString()) Then
                MessageBox.Show(param4.Value.ToString())
                Exit Sub
            End If
            MessageBox.Show("复制成功^_^ ")
            '刷新
            LoadData("", [Enum].Parse(GetType(TabType), index.ToString))
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPartNumber", "tsmiCopyRecord_Click", "sys")
        Finally
            DAL = Nothing
        End Try
    End Sub
#End Region

#Region "绑定右健菜单"
    Private Sub dgvPartNumber_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvPartNumber.CellContextMenuStripNeeded, dgvPartNumber.CellContextMenuStripNeeded
        'Dim dgv As DataGridView = CType(sender, DataGridView)
        If e.RowIndex >= 0 Then
            e.ContextMenuStrip = Me.ContextMenuStrip1
        End If
    End Sub

    Private Sub dgvEquipment_CellContextMenuStripNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvEquipment.CellContextMenuStripNeeded, dgvEquipment.CellContextMenuStripNeeded
        'Dim dgv As DataGridView = CType(sender, DataGridView)
        If e.RowIndex >= 0 Then
            e.ContextMenuStrip = Me.ContextMenuStrip1
        End If
    End Sub
#End Region

#Region "右健改变当前行号"
    Private Sub dgvPartNumber_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPartNumber.CellMouseDown, dgvPartNumber.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.RowIndex >= 0 Then
                dgvPartNumber.ClearSelection()
                dgvPartNumber.Rows(e.RowIndex).Selected = True
                dgvPartNumber.CurrentCell = dgvPartNumber.Rows(e.RowIndex).Cells(e.ColumnIndex)
                'dgvPartNumber.DefaultCellStyle.ForeColor = DefaultForeColor
                'dgvPartNumber.CurrentRow.DefaultCellStyle.ForeColor = Color.Blue
            End If
        End If

    End Sub

    Private Sub dgvEquipment_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvEquipment.CellMouseDown, dgvEquipment.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.RowIndex >= 0 Then
                dgvEquipment.ClearSelection()
                dgvEquipment.Rows(e.RowIndex).Selected = True
                dgvEquipment.CurrentCell = dgvEquipment.Rows(e.RowIndex).Cells(e.ColumnIndex)
                'dgvPartNumber.DefaultCellStyle.ForeColor = DefaultForeColor
                'dgvPartNumber.CurrentRow.DefaultCellStyle.ForeColor = Color.Blue
            End If
        End If

    End Sub
#End Region

#Region "复制单元格"
    Private Sub tsmiCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiCopy.Click
        Dim index As Integer = TabControl1.SelectedIndex
        If index = 0 Then
            If Not dgvPartNumber.CurrentCell Is Nothing Then
                Dim Selected As String = dgvPartNumber.CurrentCell.Value.ToString()
                Clipboard.SetDataObject(Selected)
            End If
        Else
            If Not dgvEquipment.CurrentCell Is Nothing Then
                Dim Selected As String = dgvEquipment.CurrentCell.Value.ToString()
                Clipboard.SetDataObject(Selected)
            End If
        End If
    End Sub
#End Region

#Region "背景色"
    Private Sub dgvPartNumber_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvPartNumber.DataBindingComplete, dgvPartNumber.DataBindingComplete
        For Each item As DataGridViewRow In dgvPartNumber.Rows

            If item.Cells("状态").Value.ToString() = "No" Then
                item.DefaultCellStyle.ForeColor = Color.Red
            End If

            If item.Index Mod 2 = 0 Then
                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub

    Private Sub dgvEquipment_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvEquipment.DataBindingComplete, dgvEquipment.DataBindingComplete
        For Each item As DataGridViewRow In dgvEquipment.Rows

            If item.Cells("状态").Value.ToString() = "No" Then
                item.DefaultCellStyle.ForeColor = Color.Red
            End If

            If item.Index Mod 2 = 0 Then
                item.DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next
    End Sub
#End Region



    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'If TabControl1.SelectedIndex = 0 Then
        '    LoadData("", TabType.RAW)
        'Else
        '    LoadData("", TabType.Equipment)
        'End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        SetControlStatus(EditMode.EXPORT)
        'Dim frm As New FrmShowRunCard
        'frm.reportInputParametersVar.printerName = "CutePDF Writer"
        'Using dt As New DataTable
        '    Dim a As DataRow = dt.NewRow
        '    Dim b As DataRow = dt.NewRow
        '    dt.Rows.Add(a)
        '    dt.Rows.Add(b)
        '    dt.Columns.Add("EquipmentNo", GetType(String))
        '    dt.Rows(0)(0) = "AAAAAAAAAAA"
        '    dt.Rows(1)(0) = "AAAAAAAA"
        '    'frm.PrintEquipment(FrmShowRunCard.EquipmentType.MJ, dt)
        '    frm.PrintEquipment(FrmShowRunCard.EquipmentType.DM, dt)
        'End Using

    End Sub

    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
        OpenFileDialog.Filter = "选择文件|*.xls;*.xlsx"
        Dim result As DialogResult = OpenFileDialog.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtPath.Text = OpenFileDialog.FileName
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub btnBExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBExport.Click
        Dim errorMsg As String = Nothing
        Dim sql As String = Nothing
        Dim index As Integer = 0
        Try
            index = TabControl1.SelectedIndex
            sql = "SELECT [料件编号] AS PartNumber,[品名] AS Description,[规格] AS Description1,'" & VbCommClass.VbCommClass.UseId & "' AS UserID,'E' AS Type FROM [Sheet1$] WHERE [料件编号] IS NOT NULL"
            Using dt As DataTable = SysDataBaseClass.ExportFromExcel(txtPath.Text, True, SysDataBaseClass.OfficeVersion.Off8Version, sql, errorMsg)
                If dt Is Nothing Then
                    MessageBox.Show(errorMsg, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If CheckData(dt) Then
                    MessageBox.Show("上传成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtPath.Text = ""
                    SetControlStatus(EditMode.UNDO)
                    LoadData("", [Enum].Parse(GetType(TabType), index.ToString))
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function CheckData(ByVal dt As DataTable) As Boolean
        Using dv As DataView = New DataView(dt)
            If dv.Count <> dv.ToTable(True, "PartNumber").Rows.Count Then
                MessageBox.Show("表格中存在相同的料件编号请确认！！！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End Using
        If dt.Select("Description IS NULL").Length > 0 Then
            MessageBox.Show("表格中品名列存在为空项请确认！！！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Dim sConn As New SysDataBaseClass
        Dim sql As String = "SELECT A.PARTNUMBER FROM M_RUNCARDPARTNUMBER_T A WHERE A.TYPE='E'"
        Using dtPart As DataTable = sConn.GetDataTable(sql)
            For Each dr As DataRow In dt.Rows
                If dtPart.Select("PARTNUMBER='" & dr(0).ToString & "'").Length > 0 Then
                    MessageBox.Show("料件编号" & dr(0).ToString & "已存在请确认！！！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            Next
        End Using
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        dics.Add("PartNumber", "PartNumber")
        dics.Add("Description", "Description")
        dics.Add("Description1", "Description1")
        dics.Add("UserID", "UserID")
        dics.Add("TYPE", "TYPE")
        If Not sConn.BulkCopy(dt, "M_RUNCARDPARTNUMBER_T", dics) Then
            Return False
        End If
        Return True
    End Function

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        SetControlStatus(EditMode.SEARCH)
        '面板控件可写
        ToogleGroupBox(1)
        '面板控件赋值
        'SetGroupBox()
        SetControlStatus(EditMode.IMPORT)

        FolderBrowserDialog1.Description = "请选择文件存储目录"
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
        FolderBrowserDialog1.ShowNewFolderButton = True
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtPath.Text = FolderBrowserDialog1.SelectedPath
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Private Function GetSqlWhere() As String
        Dim index As Integer = TabControl1.SelectedIndex
        Dim sbSqlWhere As New StringBuilder
        If Me.txtPartNumber.Text.Trim() <> "" Then
            sbSqlWhere.Append(" and PartNumber like N'%" & txtPartNumber.Text.Trim().Replace("'", "''") & "%' ")
        End If
        If Me.txtDescription.Text.Trim() <> "" Then
            sbSqlWhere.Append(" and [Description] like N'%" & txtDescription.Text.Trim().Replace("'", "''") & "%' ")
        End If
        If Me.txtDescription1.Text.Trim() <> "" Then
            sbSqlWhere.Append(" and [Description1] like N'%" & txtDescription1.Text.Trim().Replace("'", "''") & "%' ")
        End If
        If Me.cboStatus.SelectedItem.ToString() <> "" Then
            sbSqlWhere.Append(" and [Status] = " & cboStatus.SelectedItem.ToString().Substring(0, 1) & " ")
        End If
        If Me.cboType.SelectedItem.ToString() <> "" Then
            sbSqlWhere.Append(" and [TYPE] = '" & cboType.SelectedItem.ToString().Substring(0, 1) & "' ")
        End If
        Return sbSqlWhere.ToString
    End Function

    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        Dim strsql As String = Nothing
        Dim sqlWhere As String = Nothing
        Dim sConn As New SysDataBaseClass
        Dim strImportSql As StringBuilder
        Dim strFields As String = Nothing
        Dim fileName As String = ""
        If cboType.SelectedIndex = -1 Then
            MessageBox.Show("请选择类别", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try

            OperateFlag = EditMode.SEARCH
            sqlWhere = GetSqlWhere()
            strsql = "SELECT TOP 65536 PARTNUMBER 料件编号,DESCRIPTION 品名,DESCRIPTION1 规格," & vbNewLine & _
              " CASE WHEN [STATUS]=1 THEN '有效' ELSE '无效' END 状态,USERID 创建人,INTIME 创建日期" & vbNewLine & _
              " FROM M_RUNCARDPARTNUMBER_T(NOLOCK) A WHERE 1=1 "
            strsql = strsql + "  " & sqlWhere & " ORDER BY A.INTIME DESC"

            strImportSql = New StringBuilder()
            Using dt As DataTable = sConn.GetDataTable(strsql)
                If dt.Rows.Count > 0 Then
                    fileName = txtPath.Text + "\料件资料_" + Date.Now.ToString("yyyyMMddHHmmssfff") + ".xlsx"
                    If SysDataBaseClass.Import2Excel(fileName, dt, 1, 1) Then
                        MessageBox.Show("文件产生成功请查看", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtPath.Text = ""
                        btnDownload.Enabled = False
                    End If
                Else
                    MessageBox.Show("没有资料可供下载,请确认查询条件", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class