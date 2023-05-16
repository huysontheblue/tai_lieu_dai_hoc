Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Text.RegularExpressions
Imports System.Drawing
Imports MainFrame

Public Class EquipmentInfo

    '变量定义
    Dim OperateFlag As EditMode '操作模式

    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum

#Region "事件"

    '初始化
    Private Sub EquipmentInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '设置当前操作模式
            Me.OperateFlag = EditMode.UNDO
            SetStatus(OperateFlag)
            InitStatus()
            InitDropDownList()
            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "Equipment.EquipmentInfo", "EquipmentInfo_Load", "sys")
        End Try
    End Sub

    '新增
    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click
        '设置操作模式
        OperateFlag = EditMode.ADD
        '工具栏控件状态
        SetStatus(EditMode.ADD)

        Me.txtCreateUser.Text = VbCommClass.VbCommClass.UseId
        dtpCheckDate.Value = Date.Now
        Me.ComType.SelectedIndex = -1
    End Sub

    '编辑
    Private Sub ToolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEdit.Click
        If Me.GridList.Rows.Count = 0 OrElse Me.GridList.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择需要修改的设备!")
            Exit Sub
        End If
        '设置操作模式
        OperateFlag = EditMode.EDIT
        '工具栏控件状态
        SetStatus(EditMode.EDIT)
    End Sub

    '报废
    Private Sub ToolDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDelete.Click
        If Me.GridList.Rows.Count = 0 OrElse Me.GridList.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择需要报废的设备!")
            Exit Sub
        End If
        Dim strSatatus As String = Me.GridList.Item("Status", Me.GridList.CurrentRow.Index).Value.ToString.Trim()
        If (strSatatus.Contains(2)) Then
            MessageUtils.ShowError("对不起该设备已停用！！！")
            Return
        ElseIf (strSatatus.Contains(3)) Then
            MessageUtils.ShowError("对不起该设备退修中！！！")
            Return
        ElseIf (strSatatus.Contains(4)) Then
            MessageUtils.ShowError("对不起该设备已报废！！！")
            Return
        End If
        Try
            If MessageUtils.ShowConfirm("确定要报废吗？", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim strcode As String = Me.GridList.Item("Machine_Code", Me.GridList.CurrentRow.Index).Value.ToString.Trim()

                DbOperateUtils.ExecSQL(" UPDATE  m_Equ_MachineM_t  set Status=4 where Machine_Code=N'" + strcode + "' ")
                MessageUtils.ShowInformation("设备已报废!")
                BindData()
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '保存
    Private Sub ToolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSave.Click
        Try
            If CheckInput() = False Then
                Exit Sub
            End If
            Dim StrSql As String = ""
            Dim EquCode As String = Me.txtEquCode.Text.Trim
            Dim JsNo As String = Me.txtJsNo.Text.Trim
            Dim ZcNo As String = Me.txtZcNo.Text.Trim
            Dim Machine_Type As String = Me.ComType.Text

            Dim ResponUser As String = Me.txtResponUser.Text.Trim
            Dim VendCode As String = Me.TxtVendCode.Text.Trim
            Dim CheckTime As Date = DateTime.Parse(Me.dtpCheckDate.Text)
            Dim CheckInterval As String = Me.ComCheckInterval.Text
            Dim NextCheckTime As Date
            If (Me.ComCheckInterval.SelectedIndex = 0) Then
                NextCheckTime = DateAdd("m", 6, Me.dtpCheckDate.Value)
            Else
                NextCheckTime = DateAdd("m", 12, Me.dtpCheckDate.Value)
            End If

            Dim Remark As String = Me.txtRemark.Text.Trim
            Dim Storage As String = Me.txtStorage.Text.Trim
            Dim Status As String = 1

            Dim CREATEUSERNAME As String = VbCommClass.VbCommClass.UseId
            If (OperateFlag = EditMode.ADD) Then
                Dim cnt As Integer = DbOperateUtils.GetRowsCount(" SELECT distinct(Machine_Code) from m_Equ_MachineM_t where Machine_Code=N'" & EquCode & "'")
                If cnt > 0 Then
                    MessageUtils.ShowInformation("设备编号：" + EquCode + "已存在!")
                    Return
                End If

                StrSql = " INSERT into m_Equ_MachineM_t(" &
                    "Machine_Code, Machine_Title, Machine_Type, Machine_Format, AreaType, VendCode, ResponPhone, ResponUser, Phone, TouchUser, " &
                    "CheckTime, CheckInterval, NextCheckTime, Remark, Status, JsNo, CREATEUSERNAME, CREATEDATETIME, ZcNo," &
                    "Storage, LineName, FactoryName, Profitcenter) values (" &
                    "N'" & EquCode & "','',N'" & ComType.Text & "',N'" & txtMachine_Format.Text & "',0,N'" & VendCode & "','',N'" + ResponUser +
                    "','','','" & CheckTime & "',N'" & CheckInterval & "','" & NextCheckTime & "',N'" & Remark & "'," & Status &
                    ",N'" & JsNo & "',N'" & CREATEUSERNAME & "',getdate(),N'" & ZcNo & "',N'" & Storage & "','','" +
                    VbCommClass.VbCommClass.Factory + "','" + VbCommClass.VbCommClass.profitcenter + "')"
                DbOperateUtils.ExecSQL(StrSql)
            Else
                StrSql = String.Format(
                    " update  m_Equ_MachineM_t set Machine_Format = N'{0}',Machine_Type=N'{1}',VendCode=N'{2}',ResponUser=N'{3}', " &
                    "CheckTime='{4}',CheckInterval=N'{5}',NextCheckTime='{6}',Remark=N'{7}',[Status]={8},JsNo=N'{9}',ZcNo=N'{10}', " &
                    "Storage=N'{11}',FactoryName='{12}',Profitcenter='{13}' where Machine_Code=N'{14}'",
                    txtMachine_Format.Text.Trim, Machine_Type, VendCode, ResponUser, CheckTime, CheckInterval, NextCheckTime, Remark,
                    Status, JsNo, ZcNo, Storage, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, txtEquCode.Text.Trim)
                DbOperateUtils.ExecSQL(StrSql)

            End If
            MessageUtils.ShowInformation("设备基础信息保存成功!")
            '设置操作模式
            OperateFlag = EditMode.UNDO
            '工具栏控件状态
            SetStatus(EditMode.UNDO)
            BindData()
        Catch ex As Exception
            MessageUtils.ShowError("输入有误!")
        End Try

    End Sub

    '取消
    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancel.Click
        '设置操作模式
        OperateFlag = EditMode.UNDO
        '工具栏控件状态
        SetStatus(EditMode.UNDO)
    End Sub

    '查询
    Private Sub ToolQueryMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQueryMO.Click
        '设置操作模式
        OperateFlag = EditMode.SEARCH
        '工具栏控件状态
        SetStatus(EditMode.SEARCH)
        dtpCheckDate.Checked = False
    End Sub

    '刷新
    Private Sub toolRefresh_Click(sender As Object, e As EventArgs) Handles toolRefresh.Click
        If OperateFlag <> EditMode.SEARCH Then
            Exit Sub
        End If
        Try
            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "Equipment.EquipmentInfo", "btnRefresh_Click", "sys")
        End Try
    End Sub

    'ERP检查
    Private Sub ToolErpCheck_Click(sender As Object, e As EventArgs) Handles ToolErpCheck.Click
        Try
            Dim strSQL As String =
                " DECLARE @strmsgid varchar(1), @strmsgText nvarchar(150) " &
                " EXEC [GetTiptopAssetCheck] @strmsgid output,@strmsgText output, '{0}','{1}','{2}' " &
                " SELECT @strmsgid,@strmsgText"

            strSQL = String.Format(strSQL, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, VbCommClass.VbCommClass.UseId)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        MessageUtils.ShowError(dt.Rows(0)(1).ToString)
                        Exit Select
                    Case "1"
                        MessageUtils.ShowInformation("成功下载！")
                        Exit Select
                End Select
            End If
            dtpCheckDate.Checked = False
            ClearControl()
            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "Equipment.EquipmentInfo", "ToolErpCheck_Click", "sys")
        End Try
    End Sub

    '退出 
    Private Sub ExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    '借出归还
    Private Sub ToolLend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLend.Click
        If Me.GridList.Rows.Count = 0 OrElse Me.GridList.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择需要借出的设备!")
            Exit Sub
        End If
        Dim strSatatus As String = Me.GridList.Item("Status", Me.GridList.CurrentRow.Index).Value.ToString.Trim()
        If (strSatatus.Contains(2)) Then
            MessageUtils.ShowError("对不起该设备已停用！！！")
            Return
        ElseIf (strSatatus.Contains(3)) Then
            MessageUtils.ShowError("对不起该设备退修中！！！")
            Return
        ElseIf (strSatatus.Contains(4)) Then
            MessageUtils.ShowError("对不起该设备已报废！！！")
            Return
        End If

        Dim strcode As String = Me.GridList.Item("Machine_Code", Me.GridList.CurrentRow.Index).Value.ToString.Trim()

        '----------------------------------------------------------------------
        Dim formLend As New Lend
        formLend.hidEquID.Text = strcode
        formLend.Owner = Me
        formLend.ShowDialog()

        If (formLend.DialogResult = Windows.Forms.DialogResult.OK) Then
            Me.ComCheckInterval.SelectedIndex = -1

            Me.ComType.SelectedIndex = -1
            Me.dtpCheckDate.Checked = False
            SetStatus(EditMode.UNDO)
            BindData()
        End If
    End Sub

    '设备编号
    Private Sub txtEquCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEquCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            BindData()
        End If
    End Sub

    'GRID双击
    Private Sub GridList_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridList.CellDoubleClick
        Dim strcode As String = Me.GridList.Item("Machine_Code", Me.GridList.CurrentRow.Index).Value.ToString.Trim()
        Dim formLend As New EquipDetailInfo
        formLend.hidEquID.Text = strcode
        formLend.StartPosition = FormStartPosition.CenterScreen
        formLend.Owner = Me
        formLend.ShowDialog()
    End Sub

    'GRID单击
    Private Sub GridList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridList.CellClick
        If OperateFlag = EditMode.SEARCH Then Exit Sub

        Me.txtEquCode.Text = Me.GridList.Item("Machine_Code", Me.GridList.CurrentRow.Index).Value.ToString.Trim()
        Me.txtZcNo.Text = Me.GridList.Item("ZcNo", Me.GridList.CurrentRow.Index).Value.ToString.Trim()
        Me.txtJsNo.Text = Me.GridList.Item("JsNo", Me.GridList.CurrentRow.Index).Value.ToString.Trim()

        Me.ComType.SelectedIndex = ComType.FindStringExact(Me.GridList.Item("Machine_Type", Me.GridList.CurrentRow.Index).Value.ToString.Trim())
        Me.txtCreateUser.Text = VbCommClass.VbCommClass.UseId
        Me.txtResponUser.Text = Me.GridList.Item("ResponUser", Me.GridList.CurrentRow.Index).Value.ToString.Trim()
        Me.txtStorage.Text = Me.GridList.Item("Storage", Me.GridList.CurrentRow.Index).Value.ToString.Trim()
        Me.TxtVendCode.Text = Me.GridList.Item("VendCode", Me.GridList.CurrentRow.Index).Value.ToString.Trim()
        Me.txtRemark.Text = Me.GridList.Item("Remark", Me.GridList.CurrentRow.Index).Value.ToString.Trim()
        Me.txtMachine_Format.Text = Me.GridList.Item("Machine_Format", Me.GridList.CurrentRow.Index).Value.ToString.Trim()
        Me.ComCheckInterval.SelectedIndex = ComCheckInterval.FindStringExact(Me.GridList.Item("CheckInterval", Me.GridList.CurrentRow.Index).Value.ToString.Trim())
        Me.dtpCheckDate.Text = Me.GridList.Item("CheckTime", Me.GridList.CurrentRow.Index).Value.ToString.Trim()
    End Sub

#End Region

    '初始化
    Private Sub InitStatus()
        'ComTitle.Items.Add("测试仪")
        'ComTitle.Items.Add("电子称")
        'ComTitle.Items.Add("卡尺")
        ComCheckInterval.Items.Add("半年")
        ComCheckInterval.Items.Add("一年")
    End Sub

    '更新状态
    Private Sub UpdateStatus()
        Dim sql As String = ""
        sql = " SELECT Machine_Code,convert(varchar(100),CheckTime,23) CheckTime,CheckInterval, convert(varchar(100),NextCheckTime,23) NextCheckTime from m_Equ_MachineM_t where 1=1  "
        Dim dtStatus As DataTable
        dtStatus = DbOperateUtils.GetDataTable(sql)
        For Each row As DataRow In dtStatus.Rows
            If (Date.Parse(row("NextCheckTime").ToString()).ToString("yyyy-MM-dd") <= Now.ToString("yyyy-MM-dd")) Then
                DbOperateUtils.ExecSQL(" UPDATE m_Equ_MachineM_t set [Status]=1 where Machine_Code=N'" + row("Machine_Code").ToString() + "' ")
            End If
        Next
    End Sub

    '邦定数据
    Private Sub BindData()
        Dim sql As String = ""
        sql = " SELECT Machine_Code,JsNo,ZcNo,Machine_Type,Machine_Format,Storage," & _
              " Status ,convert(varchar(100),CheckTime,23) CheckTime," & _
              " CheckInterval, convert(varchar(100),NextCheckTime,23) NextCheckTime," & _
              " CASE WHEN b.username IS NULL THEN ResponUser ELSE b.username END as ResponUser, " & _
              " CASE WHEN C.username IS NULL THEN TouchUser ELSE C.username END AS TouchUser, LineName, VendCode, Remark, " & _
              " convert(varchar(100),CREATEDATETIME,23) CREATEDATETIME,FactoryName,Profitcenter, " & _
              " case Status when 0 then N'0:未校' when 1 then N'1:正常' when 2 then N'2:停用' when 3 then N'3.退修' when 4 then N'4.报废' end StatusName " & _
              " FROM m_Equ_MachineM_t a LEFT JOIN m_Users_t b ON a.responuser = b.userid" & _
              " Left join m_Users_t C on a.TouchUser = C.userid " & _
              " WHERE  factoryname='" + VbCommClass.VbCommClass.Factory + "' and profitcenter='" + VbCommClass.VbCommClass.profitcenter + "' "
        If (Me.txtEquCode.Text.Trim <> "") Then
            sql += " AND Machine_Code like '%" + Me.txtEquCode.Text.Trim + "%'"
        End If
        If (Me.txtJsNo.Text.Trim <> "") Then
            sql += " AND JsNo like '%" + Me.txtJsNo.Text.Trim + "%'"
        End If
        If (Me.ComType.Text <> "") Then
            sql += " and Machine_Type= N'" & Me.ComType.Text + "'"
        End If
        If (Me.ComCheckInterval.Text <> "") Then
            sql += " and CheckInterval = N'" + Me.ComCheckInterval.Text + "'"
        End If
        If (Me.txtResponUser.Text <> "") Then
            sql += " and ResponUser like '%" + Me.txtResponUser.Text + "%'"
        End If
        If (Me.dtpCheckDate.Checked) Then
            sql += " and   CheckTime='" + Me.dtpCheckDate.Text + "'"
        End If
        If (Me.cmbStatus.Text <> "") Then
            sql += " and   Status='" + Me.cmbStatus.SelectedValue.ToString + "'"
        End If
        sql += " order by  Status, NextCheckTime"
        GridList.Rows.Clear()
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            For Each row As DataRow In dt.Rows
                GridList.Rows.Add(row("Machine_Code").ToString(), row("JsNo").ToString(), row("ZcNo").ToString(),
                                  row("Machine_Type").ToString(), row("Machine_Format").ToString(),
                                  row("Storage").ToString(), row("StatusName").ToString(), row("CheckTime").ToString(), row("CheckInterval").ToString(),
                                  row("NextCheckTime").ToString(), row("ResponUser").ToString(), row("TouchUser").ToString(),
                                  row("LineName").ToString(), row("VendCode").ToString(), row("Remark").ToString(),
                                  row("CREATEDATETIME").ToString(), row("FactoryName").ToString(), row("Profitcenter").ToString)

            Next

            TlelCount.Text = dt.Rows.Count
        End Using
        '设置颜色
        For rowIndex As Integer = 0 To GridList.Rows.Count - 1
            If GridList.Item("Status", rowIndex).Value.ToString.Contains(2) Then '2:停用
                GridList.Rows(rowIndex).DefaultCellStyle.BackColor = Color.DarkCyan
            ElseIf GridList.Item("Status", rowIndex).Value.ToString.Contains(3) Then '3.退修
                GridList.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Pink
            ElseIf GridList.Item("Status", rowIndex).Value.ToString.Contains(4) Then '4.报废
                GridList.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    '设置状态
    Private Sub SetStatus(ByVal flag As EditMode)
        SetButtonEnable(False)
        Select Case UCase(flag)
            Case EditMode.UNDO '初始化
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.ToolDelete.Enabled = True
                Me.ToolQueryMO.Enabled = True
                Me.ToolLend.Enabled = True
                Me.ToolErpCheck.Enabled = True

                ClearControl()
                SetControlEnable(False)
                dtpCheckDate.Checked = False
            Case EditMode.ADD '新增
                Me.ToolSave.Enabled = True
                Me.ToolCancel.Enabled = True

                ClearControl()
                SetControlEnable(True)
            Case EditMode.EDIT '修改
                Me.ToolSave.Enabled = True
                Me.ToolCancel.Enabled = True

                SetControlEnable(True)
                txtEquCode.Enabled = False
            Case EditMode.SEARCH '搜索
                Me.toolRefresh.Enabled = True
                Me.ToolCancel.Enabled = True

                ClearControl()
                SetControlEnable(True)
                Me.txtCreateUser.Enabled = False
        End Select
    End Sub

    '禁用所有按钮
    Private Sub SetButtonEnable(bFlag As Boolean)
        toolNew.Enabled = bFlag
        ToolEdit.Enabled = bFlag
        toolSave.Enabled = bFlag
        ToolCancel.Enabled = bFlag
        toolDelete.Enabled = bFlag
        ToolQueryMO.Enabled = bFlag
        toolRefresh.Enabled = bFlag
        ToolLend.Enabled = bFlag
        ToolErpCheck.Enabled = bFlag
    End Sub

#Region "清空控件"
    Private Sub ClearControl()
        Dim ClearCon As Control

        For Each ClearCon In Me.Panel1.Controls
            If TypeOf ClearCon Is System.Windows.Forms.TextBox Then
                ClearCon.Text = ""
            ElseIf TypeOf ClearCon Is ComboBox Then
                ClearCon.Text = ""
            End If
        Next
    End Sub
#End Region

#Region "设置控件可用性"
    Private Sub SetControlEnable(bFlag As Boolean)
        Dim ClearCon As Control

        For Each ClearCon In Me.Panel1.Controls
            If TypeOf ClearCon Is System.Windows.Forms.TextBox Then
                ClearCon.Enabled = bFlag
            ElseIf TypeOf ClearCon Is ComboBox Then
                ClearCon.Enabled = bFlag
            End If
        Next
    End Sub
#End Region

    '初始化下拉框
    Private Sub InitDropDownList()
        EquMachineCommon.BindComboxMachineType(ComType)
        EquMachineCommon.BindComboxStatus(cmbStatus)
    End Sub

    '检查
    Private Function CheckInput() As Boolean
        If Me.txtEquCode.Text = "" Then
            MessageUtils.ShowError("请输入设备编号！！！")
            txtEquCode.Select()
            Return False
        End If
        If Me.txtJsNo.Text = "" Then
            MessageUtils.ShowError("请输入机身编号！！！")
            txtJsNo.Select()
            Return False
        End If
        If Me.txtZcNo.Text = "" Then
            MessageUtils.ShowError("请输入资产编号！！！")
            txtZcNo.Select()
            Return False
        End If
        If Me.txtResponUser.Text = "" Then
            MessageUtils.ShowError("请输入主要负责人！！！")
            txtResponUser.Select()
            Return False
        End If
        'If Me.ComTitle.SelectedIndex = -1 Then
        '    MessageUtils.ShowError("请选择设备名称！！！")
        '    Return False
        'End If
        If Me.ComCheckInterval.SelectedIndex = -1 Then
            MessageUtils.ShowError("请选择校验间隔！！！")
            Return False
        End If
        If Me.ComType.SelectedIndex = -1 Then
            MessageUtils.ShowError("请选择设备类型！！！")
            Return False
        End If

        Return True
    End Function


End Class