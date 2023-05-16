Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Threading
Imports System.Drawing
Public Class Checks
    Dim ExecuteCmd As New SysDataBaseClass
    Dim opFlag As Integer
    Dim ID As Integer
    Private Sub Checks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitStatus()
        Me.txtEquCode.Text = Me.hidChecksEquID.Text
        Me.txtEquCode.Enabled = False
        Me.txtCreaterUser.Text = VbCommClass.VbCommClass.UseId
        Me.txtCreaterUser.Enabled = False
        GetCheckTime()
        getDataInfo()
        SetStatus(opFlag)
    End Sub
    Private Sub getDataInfo()
        Dim dtReturn As DataTable
        dtReturn = ExecuteCmd.GetDataTable("select top 1 *  from m_Equ_MachineChecks_t where  Machine_Code=N'" + Me.txtEquCode.Text + "' order by CREATEDATETIME desc")
        If (dtReturn.Rows.Count > 0) Then
            Me.txtCheckUser.Text = dtReturn.Rows(0).Item("CheckUser").ToString
            If (dtReturn.Rows(0).Item("CheckStatus").ToString = "正常") Then
                Me.ComCheckStatus.SelectedIndex = 0
            Else
                Me.ComCheckStatus.SelectedIndex = 1
            End If
            Me.txtRemark.Text = dtReturn.Rows(0).Item("Remark").ToString
            Me.DateTimePicker1.Text = dtReturn.Rows(0).Item("CREATEDATETIME").ToString
            opFlag = 2
            ID = CInt(dtReturn.Rows(0).Item("id").ToString)

        Else

        End If
    End Sub
    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始状态

                Me.txtCheckTime.Enabled = False
                Me.txtNextCheckTime.Enabled = False
                Me.txtCheckUser.Enabled = True
                Me.ComCheckStatus.Enabled = True
                Me.DateTimePicker1.Enabled = False
                Me.txtRemark.Enabled = True
            Case 1      '新增
                Me.txtCheckTime.Enabled = False
                Me.txtNextCheckTime.Enabled = False
                Me.txtCheckUser.Enabled = True
                Me.ComCheckStatus.Enabled = True
                Me.DateTimePicker1.Enabled = True
                Me.txtRemark.Enabled = True
            Case 2      '修改
                Me.txtCheckTime.Enabled = False
                Me.txtNextCheckTime.Enabled = False
                Me.txtCheckUser.Enabled = True
                Me.ComCheckStatus.Enabled = True
                Me.DateTimePicker1.Enabled = True
                Me.txtRemark.Enabled = True
        End Select
    End Sub
    Private Sub InitStatus()
        ComCheckStatus.Items.Add("有效")
        ComCheckStatus.Items.Add("无效")
        ComCheckStatus.SelectedIndex = 0
    End Sub
    Private Sub GetCheckTime()
        Dim dtCheckTime As DataTable
        dtCheckTime = ExecuteCmd.GetDataTable(" select CheckTime,case CheckInterval when '一年' then 12 else 6 end CheckInterval,NextCheckTime from m_Equ_MachineM_t where Machine_Code=N'" + Me.txtEquCode.Text.Trim + "'")
        If (dtCheckTime.Rows.Count > 0) Then
            'If getdatediff(dtCheckTime.Rows(0).Item("CheckTime").ToString) = 0 Then
            '    Me.txtCheckTime.Text = dtCheckTime.Rows(0).Item("CheckTime").ToString
            '    Me.txtNextCheckTime.Text = dtCheckTime.Rows(0).Item("NextCheckTime").ToString

            'Else
            '    Me.txtCheckTime.Text = dtCheckTime.Rows(0).Item("NextCheckTime").ToString
            '    Dim CheckInterval As Integer = CInt(dtCheckTime.Rows(0).Item("CheckInterval").ToString)
            '    Me.txtNextCheckTime.Text = DateAdd("m", CheckInterval, Date.Parse(Me.txtCheckTime.Text))
            'End If
            Me.txtCheckTime.Text = dtCheckTime.Rows(0).Item("NextCheckTime").ToString
            Dim CheckInterval As Integer = CInt(dtCheckTime.Rows(0).Item("CheckInterval").ToString)
            Me.txtNextCheckTime.Text = DateAdd("m", CheckInterval, Date.Parse(Me.txtCheckTime.Text))
        End If
    End Sub

    'Private Function getdatediff(ByVal strTime As String) As Integer
    '    Dim internal As Integer = 0
    '    Dim strDate = Date.Parse(strTime).ToString("yyyy-MM-dd")
    '    Dim dtinternal As DataTable = ExecuteCmd.GetDataTable(" SELECT DATEDIFF(MONTH,'" + strDate + "',getdate()) as interval  ")
    '    If (0 <= (dtinternal.Rows(0)("interval")) < 2) Then
    '        Return internal = Math.Abs(dtinternal.Rows(0)("interval"))
    '    Else
    '        Return internal
    '    End If
    'End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If CheckInput() = False Then
                Exit Sub
            End If
            Dim StrSql As String = ""
            Dim EquCode As String = Me.txtEquCode.Text.Trim
            Dim CheckUser As String = Me.txtCheckUser.Text.Trim
            Dim CheckStatus As String = Me.ComCheckStatus.Text
            Dim CreateTime As Date = Date.Parse(Me.DateTimePicker1.Text)
            Dim strRemark As String = Me.txtRemark.Text

            'If (opFlag = 1) Then  'ADD
            '    If SaveData() = "" Then
            '        MessageBox.Show("信息保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If
            'Else
            '    'StrSql = String.Format(" update  m_Equ_MachineChecks_t set CheckUser=N'{0}',Remark=N'{1}',CheckStatus=N'{2}',CREATEUSERNAME=N'{3}',CREATEDATETIME='{4}'  where id={5}", CheckUser, strRemark, CheckStatus, Me.txtCreaterUser.Text.Trim, CreateTime, ID)
            '    'ExecuteCmd.ExecSql(StrSql)
            '    'Dim ckStatus As Integer = Me.ComCheckStatus.SelectedIndex
            '    'StrSql = String.Format(" update  m_Equ_MachineM_t set Status={0},RunStatus={1}  where Machine_Code=N'{2}'", 1, ckStatus, Me.txtEquCode.Text.Trim)
            '    'ExecuteCmd.ExecSql(StrSql)
            '    MessageBox.Show("信息保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If

            If SaveData() = "" Then
                MessageBox.Show("信息保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("输入有误")
        End Try
    End Sub
    Private Function SaveData() As String
        Dim EquCode As String = Me.txtEquCode.Text.Trim
        Dim CheckUser As String = Me.txtCheckUser.Text.Trim
        Dim CheckStatus As String = Me.ComCheckStatus.Text
        Dim Remark As String = Me.txtRemark.Text.Trim
        Dim CreateTime As Date = Date.Parse(Me.DateTimePicker1.Text)

        Dim CheckTime As Date = Date.Parse(txtCheckTime.Text)
        Dim NextCheckTime As Date = Date.Parse(txtNextCheckTime.Text)
        Dim param1 As New SqlParameter("@Machine_Code ", SqlDbType.VarChar, 10, ParameterDirection.Input)
        Dim param2 As New SqlParameter("@CheckUser", SqlDbType.VarChar, 30, ParameterDirection.Input)
        Dim param3 As New SqlParameter("@CheckStatus", SqlDbType.NVarChar, 20, ParameterDirection.Input)
        Dim param4 As New SqlParameter("@Remark", SqlDbType.NVarChar, 200, ParameterDirection.Input)

        Dim param5 As New SqlParameter("@CREATEUSERNAME", SqlDbType.VarChar, 30, ParameterDirection.Input)
        Dim param6 As New SqlParameter("@CreateTime", SqlDbType.DateTime, ParameterDirection.Input)
        Dim param7 As New SqlParameter("@CheckTime", SqlDbType.DateTime, ParameterDirection.Input)
        Dim param8 As New SqlParameter("@NextCheckTime", SqlDbType.DateTime, ParameterDirection.Input)
        Dim param9 As New SqlParameter("@FactoryName", SqlDbType.VarChar, 60, ParameterDirection.Input)
        Dim param10 As New SqlParameter("@Profitcenter", SqlDbType.VarChar, 60, ParameterDirection.Input)
        Dim param11 As New SqlParameter("@RTMSG", SqlDbType.NVarChar, 200)
        '参数赋值
        param1.Value = EquCode
        param2.Value = CheckUser
        param3.Value = CheckStatus
        param4.Value = Remark
        param5.Value = VbCommClass.VbCommClass.UseId
        param6.Value = Now
        param7.Value = CheckTime
        param8.Value = NextCheckTime
        param9.Value = VbCommClass.VbCommClass.Factory
        param10.Value = VbCommClass.VbCommClass.profitcenter
        param11.Direction = ParameterDirection.Output '?指定

        Dim Paramters As SqlParameter() = Nothing
        Paramters = New SqlParameter() {param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11}
        '执行SP
        Dim err As String = ExecuteCmd.ExecuteNonQureyByProc("Exec_InsertMachineChecks", Paramters)
        If err <> "" Then
            Return err
        Else
            If TypeOf param11.Value Is DBNull Then
                Return ""
            Else
                Return param11.Value.ToString()
            End If
        End If
    End Function

    Private Function CheckInput() As Boolean
        If Me.txtEquCode.Text = "" Then
            MessageBox.Show("请输入设备编号！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEquCode.Select()
            Return False
        End If
        If Me.txtCheckUser.Text = "" Then
            MessageBox.Show("请输入校验人！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCheckUser.Select()
            Return False
        End If
        If Me.txtCheckTime.Text = "" Then
            MessageBox.Show("本次校验时间不对！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCheckUser.Select()
            Return False
        End If
        If Me.txtCheckUser.Text = "" Then
            MessageBox.Show("下次校验时间不对！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCheckUser.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtCheckUser_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCheckUser.KeyPress
        If Asc(e.KeyChar) = 13 Then
            GetUserID(txtCheckUser)
        End If
    End Sub
    Private Sub GetUserID(ByVal text As TextBox)
        Dim reader As SqlDataReader
        reader = ExecuteCmd.GetDataReader(" select *  from m_Users_t where UserID =N'" + text.Text.Trim + "' ")
        If (reader.HasRows = False) Then
            reader.Close()
            MessageBox.Show("您输入的用户不存在,请核查后重新再输入！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            reader.Close()
        End If
    End Sub
End Class