Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Text.RegularExpressions
Imports System.Drawing
Imports MainFrame

Public Class EquipDetailInfo

    Dim strTouchUser As String
    Private Sub EquipDetailInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetDataInfo()
    End Sub
    Private Sub GetDataInfo()
        Dim strSql As String = ""
        Dim dt As DataTable
        dt = DbOperateUtils.GetDataTable(" select * ,case Status when 0 then N'0:未校' when 1 then N'1:正常' when 2 then N'2:停用' when 3 then N'3.退修' when 4 then N'4.报废' end StatusName " &
                                         " from m_Equ_MachineM_t where Machine_Code=N'" + Me.hidEquID.Text.Trim + "'")
        If (dt.Rows.Count > 0) Then
            Me.txtEquCode.Text = dt.Rows(0).Item("Machine_Code").ToString
            Me.txtJsNo.Text = dt.Rows(0).Item("JsNo").ToString
            Me.txtZcNo.Text = dt.Rows(0).Item("ZcNo").ToString
            Me.txtTitle.Text = dt.Rows(0).Item("Machine_Title").ToString
            'Me.txtType.Text = getTitleById(CInt(dt.Rows(0).Item("Machine_Type").ToString))
            'Me.txtLocation.Text = getTitleById(CInt(dt.Rows(0).Item("AreaType").ToString))
            Me.txtType.Text = (dt.Rows(0).Item("Machine_Type").ToString)
            Me.txtLocation.Text = (dt.Rows(0).Item("AreaType").ToString)
            Me.txtStorage.Text = dt.Rows(0).Item("Storage").ToString
            Me.txtLocation.Text = dt.Rows(0).Item("LineName").ToString
            Me.txtCheckTime.Text = dt.Rows(0).Item("CheckTime").ToString
            Me.txtNextCheckTime.Text = dt.Rows(0).Item("NextCheckTime").ToString
            Me.txtCheckInterval.Text = dt.Rows(0).Item("CheckInterval").ToString
            Me.txtStatus.Text = dt.Rows(0).Item("StatusName").ToString
            Me.txtVendCode.Text = dt.Rows(0).Item("VendCode").ToString
            Me.txtCreateUser.Text = dt.Rows(0).Item("CREATEUSERNAME").ToString
            Me.txtResponUser.Text = dt.Rows(0).Item("ResponUser").ToString
            Me.txtTouchUserS.Text = dt.Rows(0).Item("TouchUser").ToString
            Me.txtCreateTime.Text = dt.Rows(0).Item("CREATEDATETIME").ToString()
            Me.txtRemark.Text = dt.Rows(0).Item("Remark").ToString
            strTouchUser = dt.Rows(0).Item("TouchUser").ToString
            lbCreateUser.Text = EquMachineCommon.getUserName(Me.txtCreateUser)
            lbUser.Text = EquMachineCommon.getUserName(Me.txtResponUser)
            lbLend.Text = EquMachineCommon.getUserName(Me.txtTouchUserS)
        End If
        Me.txtEquCode.Enabled = False
        Me.txtZcNo.Enabled = False
        Me.txtJsNo.Enabled = False
        Me.txtStorage.Enabled = False
        Me.txtTitle.Enabled = False
        Me.txtType.Enabled = False
        Me.txtLocation.Enabled = False
        Me.txtStatus.Enabled = False
        Me.txtCreateUser.Enabled = False
        Me.txtResponUser.Enabled = False
        Me.txtTouchUserS.Enabled = False
        Me.txtCheckTime.Enabled = False
        Me.txtNextCheckTime.Enabled = False
        Me.txtCheckInterval.Enabled = False
        Me.txtRemark.Enabled = False
        Me.txtVendCode.Enabled = False
        Me.txtCreateTime.Enabled = False

        dt.Rows.Clear()
        If (strTouchUser <> "") Then   '不在库
            dt = DbOperateUtils.GetDataTable(" select top 1 * from m_Equ_MachineShift_t where Machine_Code=N'" + Me.hidEquID.Text.Trim + "' order by CREATEDATETIME desc ")
            If (dt.Rows.Count > 0) Then
                Me.txtTouchUser.Text = dt.Rows(0).Item("TouchUser").ToString
                Me.txtLocationNow.Text = dt.Rows(0).Item("LineName").ToString
                Me.txtLendStatus.Text = dt.Rows(0).Item("Usey").ToString
                Me.txtFinishTime.Text = dt.Rows(0).Item("FinishTime").ToString
                Me.txtCreaterUser.Text = dt.Rows(0).Item("CREATEUSERNAME").ToString
                Me.txtFinishUser.Text = dt.Rows(0).Item("FinishUser").ToString
                Me.txtLendRemark.Text = dt.Rows(0).Item("Remark").ToString

                lbTouchUser.Text = EquMachineCommon.getUserName(Me.txtTouchUser)
                lbCreaterUser.Text = EquMachineCommon.getUserName(Me.txtCreaterUser)
                lbReturnUser.Text = EquMachineCommon.getUserName(Me.txtFinishUser)
            End If
        End If
        Me.txtTouchUser.Enabled = False
        Me.txtLocationNow.Enabled = False
        Me.txtLendStatus.Enabled = False
        Me.txtFinishTime.Enabled = False
        Me.txtCreaterUser.Enabled = False
        Me.txtFinishUser.Enabled = False
        Me.txtLendRemark.Enabled = False
        dt.Rows.Clear()
        dt = DbOperateUtils.GetDataTable("  select top 1 * from m_Equ_MachineChecks_t where Machine_Code=N'" + Me.hidEquID.Text.Trim + "' order by CREATEDATETIME desc ")
        If (dt.Rows.Count > 0) Then
            Me.txtCheckUser.Text = dt.Rows(0).Item("CheckUser").ToString
            Me.txtCheckStatus.Text = dt.Rows(0).Item("CheckStatus").ToString
            Me.txtCheckCreateUser.Text = dt.Rows(0).Item("CREATEUSERNAME").ToString
            Me.txtCheckCreateTime.Text = dt.Rows(0).Item("CREATEDATETIME").ToString
            Me.txtCheckRemark.Text = dt.Rows(0).Item("Remark").ToString

            lbCheck.Text = EquMachineCommon.getUserName(Me.txtCheckUser)
            lbCUser.Text = EquMachineCommon.getUserName(Me.txtCheckCreateUser)
        End If
        Me.txtCheckUser.Enabled = False
        Me.txtCheckStatus.Enabled = False
        Me.txtCheckCreateUser.Enabled = False
        Me.txtCheckCreateTime.Enabled = False
        Me.txtCheckRemark.Enabled = False

    End Sub

End Class