Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Text.RegularExpressions
Imports System.Drawing
Imports MainFrame

Public Class Lend

    Dim ID As Integer
    Dim opFlag As Integer
    Dim TouchUser As String

#Region "事件"
    '初期化
    Private Sub Lend_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpOperateTime.Text = Date.Now
        Me.txtFinishTime.Text = Date.Now
        Me.dtpOperateTime.Enabled = False
        Me.LblMsg.Visible = False
        Me.btnSave.Visible = False
        Me.btnCancal.Visible = False
        InitStatus()
        GetData()
    End Sub

    '取消
    Private Sub btnCancal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancal.Click
        Me.Close()
    End Sub

    '借出
    Private Sub ToolLend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLend.Click
        Me.btnSave.Visible = True
        Me.btnCancal.Visible = True
        Me.ToolReturn.Enabled = False
        Me.Panel2.Visible = True
        If TouchUser <> "" Then
            Dim dtReturn As DataTable
            dtReturn = DbOperateUtils.GetDataTable("select top 1 *  from m_Equ_MachineShift_t where  Machine_Code=N'" + Me.hidEquID.Text.Trim + "' order by CREATEDATETIME desc")
            If (dtReturn.Rows.Count > 0) Then
                Me.LblMsg.Visible = True
                Me.txtLineName.Text = dtReturn.Rows(0).Item("LineName").ToString
                Me.txtTouchUser.Text = dtReturn.Rows(0).Item("TouchUser").ToString
                Me.txtRemark.Text = dtReturn.Rows(0).Item("Remark").ToString
                Me.ComStatus.SelectedIndex = ComStatus.FindStringExact(dtReturn.Rows(0).Item("Usey").ToString)

                Me.ComStatus.Enabled = False
                Me.txtTouchUser.Enabled = False
                Me.txtRemark.Enabled = False
                ID = CInt(dtReturn.Rows(0).Item("id").ToString)
            End If
        End If
    End Sub

    '归还
    Private Sub ToolReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReturn.Click
        Me.btnSave.Visible = True
        Me.btnCancal.Visible = True
        Me.ToolLend.Enabled = False
        Me.Panel3.Visible = True
        Me.ComStatus.Enabled = False
        Me.dtpOperateTime.Enabled = False
        opFlag = 2
    End Sub

    '保存
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim StrSql As String
            Dim EquCode As String = Me.txtEquCode.Text.Trim
            If (opFlag = 0) Then
                If CheckInput() = False Then
                    Exit Sub
                End If
                If SaveData() = "" Then
                    MessageBox.Show("信息保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            ElseIf (opFlag = 2) Then

                If (ID = 0) Then
                    MessageBox.Show("请先借出该设备才能进行归还！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If Me.txtFinishUser.Text = "" Then
                        MessageBox.Show("请输入归还人！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtFinishUser.Select()
                        Return
                    End If

                    If Me.txtFinishTime.Text = "" Then
                        MessageBox.Show("请输入归还时间！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtFinishTime.Select()
                        Return
                    End If

                    StrSql = String.Format(" update m_Equ_MachineShift_t set FinishUser=N'{0}',FinishTime='{1}' where id={2}", Me.txtFinishUser.Text.Trim, Me.txtFinishTime.Text, ID)
                    StrSql = StrSql & " update  m_Equ_MachineM_t set TouchUser=null,LineName=null where Machine_Code=N'" + Me.txtEquCode.Text + "' "
                    DbOperateUtils.ExecSQL(StrSql)
                    MessageBox.Show("信息保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            '---------------------------------------------
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        Catch ex As Exception
        End Try
    End Sub

    '线别判断
    Private Sub txtLineName_Leave(sender As Object, e As EventArgs) Handles txtLineName.Leave
        Dim cnt As Integer = DbOperateUtils.GetRowsCount(" Select lineid from Deptline_t where lineid=N'" + Me.txtLineName.Text.Trim + "' ")
        If cnt = 0 Then
            MessageBox.Show("您输入的线别有误,请核查后重新再输入！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLineName.Focus()
            Return
        End If
    End Sub

    '借出人
    Private Sub txtTouchUser_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTouchUser.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'GetUserID(txtTouchUser)
            Dim EmployeeID As String
            EmployeeID = txtTouchUser.Text.ToUpper.ToString '刷工牌
            ' BindLineName()
        End If
    End Sub

    '归还人
    Private Sub txtFinishUser_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFinishUser.KeyPress
        If Asc(e.KeyChar) = 13 Then
            GetUserID(txtFinishUser)
        End If
    End Sub

#End Region

    Private Sub GetData()
        Dim dt As DataTable
        dt = DbOperateUtils.GetDataTable(" select * from m_Equ_MachineM_t where Machine_Code=N'" + Me.hidEquID.Text.Trim + "'")
        If (dt.Rows.Count > 0) Then
            Me.txtEquCode.Text = dt.Rows(0).Item("Machine_Code").ToString
            Me.txtJsNo.Text = dt.Rows(0).Item("JsNo").ToString
            Me.txtZcNo.Text = dt.Rows(0).Item("ZcNo").ToString
            Me.txtTitle.Text = dt.Rows(0).Item("Machine_Title").ToString
            Me.txtStatus.Text = IIf(dt.Rows(0).Item("Status").ToString = "0", "有效", "无效")
            Me.txtType.Text = dt.Rows(0).Item("Machine_Type").ToString
            Me.txtStorage.Text = dt.Rows(0).Item("Storage").ToString
            'Me.txtStatus.Text = [Enum].Parse(GetType(AppSettings.Status), dt.Rows(0).Item("Status").ToString).ToString
            Me.txtResponUser.Text = dt.Rows(0).Item("ResponUser").ToString
            Me.txtVendCode.Text = dt.Rows(0).Item("VendCode").ToString
            Me.lbResponUser.Text = getUserName(Me.txtResponUser.Text)
            TouchUser = dt.Rows(0).Item("TouchUser").ToString
            Me.txtEquCode.Enabled = False
            Me.txtTitle.Enabled = False
            Me.txtType.Enabled = False
            Me.txtJsNo.Enabled = False
            Me.txtZcNo.Enabled = False
            Me.txtStorage.Enabled = False
            Me.txtStatus.Enabled = False
            Me.txtResponUser.Enabled = False
            Me.txtVendCode.Enabled = False
            If TouchUser <> "" Then
                Me.ToolLend.Enabled = False
                Dim dtReturn As DataTable
                dtReturn = DbOperateUtils.GetDataTable("select top 1 *  from m_Equ_MachineShift_t where  Machine_Code=N'" + Me.hidEquID.Text.Trim + "' order by CREATEDATETIME desc")
                If (dtReturn.Rows.Count > 0) Then
                    Me.LblMsg.Visible = True
                    Me.txtTouchUser.Text = dtReturn.Rows(0).Item("TouchUser").ToString
                    Me.txtLineName.Text = dtReturn.Rows(0).Item("LineName").ToString
                    Me.ComStatus.SelectedIndex = ComStatus.FindStringExact(dtReturn.Rows(0).Item("Usey").ToString)
                    Me.txtRemark.Text = dtReturn.Rows(0).Item("Remark").ToString
                    Me.lbLendFullName.Text = getUserName(Me.txtTouchUser.Text)
                    Me.dtpOperateTime.Text = dtReturn.Rows(0).Item("CREATEDATETIME").ToString
                    Me.ComStatus.Enabled = False
                    Me.txtTouchUser.Enabled = False
                    Me.txtRemark.Enabled = False
                    Me.dtpOperateTime.Enabled = False
                    Me.txtLineName.Enabled = False
                    opFlag = 1
                    ID = CInt(dtReturn.Rows(0).Item("id").ToString)
                    If (dtReturn.Rows(0).Item("FinishUser").ToString <> "") Then   '有归还信息

                        Me.ToolReturn.Enabled = True
                        Panel3.Visible = True
                        Me.txtFinishUser.Text = dtReturn.Rows(0).Item("FinishUser").ToString
                        Me.txtFinishTime.Text = dtReturn.Rows(0).Item("FinishTime").ToString
                    End If
                End If
            Else
                Me.ToolLend.Enabled = True
                Me.Panel2.Visible = False
                Me.ToolReturn.Enabled = False
            End If
        End If
    End Sub

    Private Sub InitStatus()
        ComStatus.Items.Add("有效")
        ComStatus.Items.Add("无效")
        ComStatus.SelectedIndex = 0
    End Sub

    Private Function SaveData() As String
        Dim EquCode As String = Me.txtEquCode.Text.Trim
        Dim TouchUser As String = Me.txtTouchUser.Text.Trim
        Dim Remark As String = Me.txtRemark.Text.Trim
        Dim Usey As String = Me.ComStatus.Text
        Dim LineName As String = txtLineName.Text
        ''参数赋值
        Dim strSQL As String =
        " DECLARE @strmsgText nvarchar(150) " &
        " EXEC Exec_InsertMachineShift @strmsgText output, '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}' " &
        " SELECT @strmsgText"

        strSQL = String.Format(strSQL, EquCode, TouchUser, LineName, Remark, Usey, VbCommClass.VbCommClass.UseId,
                               VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0).ToString
        End If
        Return ""
    End Function

    Private Function CheckInput() As Boolean
        If Me.txtTouchUser.Text = "" Then
            MessageBox.Show("请输入借出人！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTouchUser.Select()
            Return False
        End If
        If Me.txtLineName.Text = "" Then
            MessageBox.Show("借出位置有误！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLineName.Select()
            Return False
        End If
        Return True
    End Function

    Private Function getUserName(ByVal userid As String) As String
        Dim dtUserName As DataTable
        dtUserName = DbOperateUtils.GetDataTable(" select *  from m_Users_t where UserID =N'" + userid + "' ")
        If (dtUserName.Rows.Count > 0) Then
            Return dtUserName.Rows(0).Item("username").ToString
        Else
            Return ""
        End If
    End Function

    Private Sub GetUserID(ByVal text As TextBox)
        Dim dtReader As DataTable
        dtReader = DbOperateUtils.GetDataTable(" select *  from m_Users_t where UserID =N'" + text.Text.Trim + "' ")
        If (dtReader.Rows.Count > 0) Then
            If (text.Name = "txtFinishUser") Then
                Me.lbFullName.Text = dtReader.Rows(0).Item("username").ToString
            ElseIf (text.Name = "txtTouchUser") Then
                Me.lbLendFullName.Text = dtReader.Rows(0).Item("username").ToString
            End If
        Else
            MessageBox.Show("您输入的用户不存在,请核查后重新再输入！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

End Class