Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports MainFrame


''' <summary>
''' 修改者： 田玉琳
''' 修改日： 2015/11/11
''' 修改内容：表和设计变更
''' </summary>
''' <remarks>重新改版</remarks>
Public Class FrmEquipmentRepair

#Region "事件"

    '变量定义
    Dim OperateFlag As EditMode '操作模式

    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum

    Private Sub FrmEquipmentRepair_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Me.DesignMode = False Then
                '绑定设备分类
                EquManageCommon.BindComboxCategory(cboBigCategory, "BIG")
                EquManageCommon.BindComboxCategory(cboMiddleCategory, "MID")
                EquManageCommon.BindComboxMR(cboMaintenanceType)
                'EquManageCommon.BindComboxCommonStatus(cboStatus)
                'EquManageCommon.BindComboxEqpStatus(cboInOut)

                '设置操作模式
                OperateFlag = EditMode.UNDO
                '工具栏控件状态
                SetControlStatus(EditMode.UNDO)
                rdoRight.Checked = True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentRepair", "FrmEquipmentRepair_Load", "sys")
        End Try
    End Sub

    Private Sub txtEquipmentNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEquipmentNO.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If CheckEquExists() = True Then
                    initData()
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentRepair", "txtEquipmentNO_KeyPress", "sys")
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        '设置操作模式
        OperateFlag = EditMode.ADD
        '工具栏控件状态
        SetControlStatus(EditMode.ADD)
        txtEquipmentNO.Focus()
    End Sub

    Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles toolUndo.Click
        '设置操作模式
        OperateFlag = EditMode.UNDO
        '工具栏控件状态
        SetControlStatus(EditMode.UNDO)
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        Try
            Search()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentRepair", "toolQuery_Click", "sys")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            If CheckData() = False Then Exit Sub
            SaveData()
            Search()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentRepair", "btnSave_Click", "sys")
        End Try
    End Sub

    Private Function CheckData() As Boolean
        If String.IsNullOrEmpty(txtEquipmentNO.Text.Trim) Then
            MessageUtils.ShowError("请输入工治具编号！")
            Return False
        End If
        'If CheckIsRepeat() = False Then
        '    Return False
        'End If
        If CheckEquExists() = False Then
            Return False
        End If
        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboMaintenanceType.SelectedValue)) = True Then
            MessageUtils.ShowError("请选择处理方式！")
            Me.cboMaintenanceType.Select()
            Return False
        End If

        Return True
    End Function

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        Try
            Dim strSQL As String =
             "select A.EquipmentNO 设备号,EquipmentPart 设备料号,B.ProcessParameters 加工参数, " &
             "(SELECT TEXT FROM m_BaseData_t WHERE ITEMKEY ='EqpMaintenanceStatus' AND VALUE= MaintenanceType) 维护类型, " &
             "(CASE MaintenanceResult WHEN 'Y' THEN '正常' ELSE '报废' END) 维护结果 ," &
             "A.Remark 原因,MaintenanceUserID 维护用户,MaintenanceTime 维护时间 " &
             "from m_EquipmentMaintenanceRecord_t A  " &
             "inner join m_Equipment_t B on  A.EquipmentNO = B.EquipmentNo  " &
             "where 1=1 " & EquManageCommon.GetFatoryProfitcenter()

            Dim dt As DataTable = GetDTbyWhere(strSQL)

            ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquipmentRepair", "ToolExcel_Click", "sys")
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '中分类选择改变事件
    Private Sub cboMiddleCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMiddleCategory.SelectedIndexChanged
        If String.IsNullOrEmpty(cboMiddleCategory.SelectedValue.ToString) = False Then
            EquManageCommon.BindComboxCategory(cboSmallCategory, cboMiddleCategory.SelectedValue.ToString)
        End If
    End Sub
#End Region

#Region "方法"

    Private Function CheckIsRepeat() As Boolean
        Dim strSQL As String = " select * from m_EquipmentMaintenanceRecord_t where EquipmentNo = '{0}' " &
            EquManageCommon.GetFatoryProfitcenter()

        strSQL = String.Format(strSQL, txtEquipmentNO.Text.Trim)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count > 0) Then
            MessageUtils.ShowError(String.Format("治具{0}已经存在！", txtEquipmentNO.Text.Trim))
            Return False
        End If
        Return True
    End Function

    Private Sub initData()
        Dim strSQL As String = " select * from m_Equipment_t where EquipmentNo = '{0}' and Status = 1 " &
           EquManageCommon.GetFatoryProfitcenter()

        strSQL = String.Format(strSQL, txtEquipmentNO.Text.Trim)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            txtEquipmentPart.Text = dt.Rows(0)("PartNumber").ToString
            txtProcessParameters.Text = dt.Rows(0)("ProcessParameters").ToString
            cboBigCategory.SelectedValue = dt.Rows(0)("BigCategory").ToString
            cboMiddleCategory.SelectedValue = dt.Rows(0)("MiddleCategory").ToString
            cboSmallCategory.SelectedValue = dt.Rows(0)("SmallCategory").ToString
            cboStatus.SelectedValue = dt.Rows(0)("Status").ToString
            cboInOut.SelectedValue = dt.Rows(0)("InOut").ToString
            txtServiceCount.Text = dt.Rows(0)("ServiceCount").ToString
            txtAlertCount.Text = dt.Rows(0)("AlertCount").ToString
            txtRemainCount.Text = dt.Rows(0)("RemainCount").ToString
        End If
    End Sub


    Private Function CheckEquExists() As Boolean
        Dim strSQL As String = " select * from m_Equipment_t where EquipmentNo = '{0}' and Status = 1 " &
            EquManageCommon.GetFatoryProfitcenter()

        strSQL = String.Format(strSQL, txtEquipmentNO.Text.Trim)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count = 0) Then
            MessageUtils.ShowError(String.Format("治具{0}不可用/不存在！", txtEquipmentNO.Text.Trim))
            Return False
        End If
        Return True
    End Function

    Private Function GetDTbyWhere(strSQL As String) As DataTable
        Dim strWhere As New System.Text.StringBuilder

        If String.IsNullOrEmpty(txtEquipmentNO.Text) = False Then
            strWhere.AppendFormat(" and A.EquipmentNO LIKE '{0}%' ", txtEquipmentNO.Text.Trim)
        End If

        If String.IsNullOrEmpty(txtEquipmentPart.Text.Trim) = False Then
            strWhere.AppendFormat(" and A.EquipmentPart LIKE '{0}%' ", txtEquipmentPart.Text.Trim)
        End If

        If String.IsNullOrEmpty(txtProcessParameters.Text.Trim) = False Then
            strWhere.AppendFormat(" and B.ProcessParameters LIKE N'%{0}%' ", txtProcessParameters.Text.Trim)
        End If

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboMaintenanceType.SelectedValue)) = False Then
            strWhere.AppendFormat(" and MaintenanceType = '{0}' ", cboMaintenanceType.SelectedValue.ToString)
        End If

        If rdoRight.Checked Then
            strWhere.AppendFormat(" and MaintenanceResult = 'Y' ")
        Else
            strWhere.AppendFormat(" and MaintenanceResult = 'N' ")
        End If

        If String.IsNullOrEmpty(txtRemark.Text.Trim) = False Then
            strWhere.AppendFormat(" and A.Remark = '{0}' ", txtRemark.Text.Trim)
        End If

        strWhere.AppendFormat(" and CONVERT(NVARCHAR(10), MaintenanceTime ,111) >= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", txtTimeStart.Value)
        strWhere.AppendFormat(" and CONVERT(NVARCHAR(10), MaintenanceTime ,111) <= CONVERT(NVARCHAR(10),CAST('{0}' AS DATE),111)  ", txtTimeEnd.Value)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString)
        Return dt
    End Function

    Private Sub Search()
        Dim strSQL As String =
                "select A.EquipmentNO,EquipmentPart,B.ProcessParameters, B.BigCategory,B.MiddleCategory,B.SmallCategory, " &
                "(SELECT TEXT FROM m_BaseData_t WHERE ITEMKEY ='EqpMaintenanceStatus' AND VALUE= MaintenanceType) MaintenanceType, " &
                "(CASE MaintenanceResult WHEN 'Y' THEN '正常' ELSE '报废' END) MaintenanceResult ," &
                "A.Remark,MaintenanceUserID,MaintenanceTime " &
                "from m_EquipmentMaintenanceRecord_t A  " &
                "inner join m_Equipment_t B on  A.EquipmentNO = B.EquipmentNo  " &
                "where 1=1 " & EquManageCommon.GetFatoryProfitcenter("B")

        dgvResult.DataSource = GetDTbyWhere(strSQL)
    End Sub

    Private Sub SaveData()
        Dim insertSql As New System.Text.StringBuilder
        Dim strSQL As String =
            "INSERT INTO m_EquipmentMaintenanceRecord_t " &
            "(EquipmentNO,EquipmentPart ,BigCategory ,MiddleCategory,SmallCategory ,MaintenanceType ,MaintenanceResult " &
            ",Remark  ,MaintenanceUserID ,MaintenanceTime  ,FactoryName,Profitcenter) "

        insertSql.Append(strSQL)
        insertSql.Append(" VALUES(")
        insertSql.AppendFormat("N'{0}',", txtEquipmentNO.Text.Trim)
        insertSql.AppendFormat("N'{0}',", txtEquipmentPart.Text.Trim)
        insertSql.AppendFormat("N'{0}',", cboBigCategory.SelectedValue.ToString)
        insertSql.AppendFormat("N'{0}',", cboMiddleCategory.SelectedValue.ToString)
        insertSql.AppendFormat("N'{0}',", cboSmallCategory.SelectedValue.ToString)
        insertSql.AppendFormat("N'{0}',", cboMaintenanceType.SelectedValue.ToString)
        insertSql.AppendFormat("N'{0}',", IIf(rdoRight.Checked = True, "Y", "N"))
        insertSql.AppendFormat("N'{0}',", txtRemark.Text.Trim)
        insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.UseId)
        insertSql.AppendFormat("getdate(),")
        insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.Factory)
        insertSql.AppendFormat("N'{0}'", VbCommClass.VbCommClass.profitcenter)
        insertSql.Append(");")


        Dim ServiceCount = Convert.ToInt32(txtServiceCount.Text.Trim())
        Dim AlertCount = Convert.ToInt32(txtAlertCount.Text.Trim())
        Dim RemainCount = Convert.ToInt32(txtRemainCount.Text.Trim())
        Dim result = IIf(ServiceCount - RemainCount < AlertCount, "N", "Y")
        insertSql.AppendLine(" update m_Equipment_t set EmailWarningLock='" & result & "',RemainCount=" & RemainCount & " where EquipmentNo='" & txtEquipmentNO.Text.Trim() & "'")

        DbOperateUtils.ExecSQL(insertSql.ToString())

        MessageUtils.ShowInformation("保存成功！")
    End Sub

#End Region

#Region "设置工具栏控件状态"

    Private Sub SetControlStatus(ByVal flag As EditMode)
        SetButtonEnable(False)
        Select Case UCase(flag)
            Case EditMode.ADD '新增
                toolSave.Enabled = True
                toolUndo.Enabled = True
            Case EditMode.EDIT '修改
                'toolSave.Enabled = True
                'toolUndo.Enabled = True
            Case EditMode.UNDO '初始化
                'Me.toolNew.Enabled = IIf(toolNew.Tag.ToString = "YES", True, False)
                toolNew.Enabled = True
            Case EditMode.SEARCH '搜索

        End Select
    End Sub

    Private Sub SetButtonEnable(bFlag As Boolean)
        toolNew.Enabled = bFlag
        toolSave.Enabled = bFlag
        toolUndo.Enabled = bFlag
    End Sub

#End Region

End Class