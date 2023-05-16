#Region "Imports"
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports MainFrame

#End Region

Public Class FrmRStationSet

    Public opflag As Int16 = 0  '
    Public frmRstationid As String = "" '
    Public frmRstationname As String = ""
    Public frmStationtype As String = ""
    Public frmStationCableType As String = ""

    Private Enum enumdgvRstation
        Stationtype     '工站类别
        Stationid       '工站编号
        Stationname     '工站名称
        Stationdest     '工站描述
        SectionID       '工段类型
        Equipment       '设备治具
        PartID          '料号
        CableType       '产品类型
        SkillCode       '岗位技能代码
        description     '岗位技能描述
        reportTypecode  '品质报表类型
        SopFilePath     '操作SOP
        usey            '有效否
        RState          '状态
        UserID          '用户ID
        Intime          '维护时间
        HandNum         '配置数
    End Enum

#Region "SopFileName"
    Private _sopFileName As String
    Public Property SopFileName() As String
        Get
            Return _sopFileName
        End Get

        Set(ByVal Value As String)
            _sopFileName = Value
        End Set
    End Property
#End Region

#Region "事件"

    '初期化
    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Erightbutton() '

        BindCombox(cboType)        '工站类别下拉框
        BindCombox(CboCableType)   '品质下拉框
        BindCombox(CboSectionID)   '工段类型下拉框
        BindCombox(cboSkillCode)   '岗位技能代码下拉框
        BindCombox(cboReportType)  '绑定品质报表

        LoadDataToDatagridview(" WHERE a.usey='Y'")
        ToolbtnState(opflag)

        Me.CboSectionID.SelectedIndex = -1
    End Sub

    '取消加載datagridview單元格有焦點
    Private Sub dgvRstation_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvRstation.RowPrePaint
        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts
    End Sub

    '整个画面处理
    Private Sub FrmRstationSet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                SendKeys.Send("{+Tab}")  'Shift + Tab  
            Case 13 '回车键
                SendKeys.Send("{Tab}")
            Case 38
            Case 39
                'SendKeys.Send("{+Tab}")
            Case 40
                'SendKeys.Send("{+Tab}")
            Case 27 'Esc
                Me.Close()
        End Select
    End Sub

    '新增
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click
        Me.txtStationName.Text = ""
        txtStationdest.Text = ""
        txtStationid.Text = ""
        Me.CboSectionID.Text = ""
        opflag = 1
        ToolbtnState(1)
    End Sub

    '编辑
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click

        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        cboType.SelectedIndex = Me.cboType.FindString(dgvRstation.Item(enumdgvRstation.Stationtype.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim)

        'start cq 20150915,SectionID, SkillCode, ReportTypeCode,SopFilePath, cableType
        Me.CboSectionID.SelectedIndex = Me.CboSectionID.FindString(dgvRstation.Item(enumdgvRstation.SectionID.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim)
        If Not IsNothing(dgvRstation.Item(enumdgvRstation.SkillCode.ToString, Me.dgvRstation.CurrentRow.Index).Value) Then
            Me.cboSkillCode.SelectedIndex = Me.cboSkillCode.FindString(dgvRstation.Item(enumdgvRstation.SkillCode.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim)
        End If

        If Not IsNothing(dgvRstation.Item(enumdgvRstation.reportTypecode.ToString, Me.dgvRstation.CurrentRow.Index).Value) Then
            Me.cboReportType.SelectedIndex = Me.cboReportType.FindString(dgvRstation.Item(enumdgvRstation.reportTypecode.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim)
        End If

        If Not IsNothing(dgvRstation.Item(enumdgvRstation.Equipment.ToString, Me.dgvRstation.CurrentRow.Index).Value) Then
            Me.txtEquipment.Text = dgvRstation.Item(enumdgvRstation.Equipment.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        End If

        If Not IsNothing(dgvRstation.Item(enumdgvRstation.PartID.ToString, Me.dgvRstation.CurrentRow.Index).Value) Then
            Me.txtPartID.Text = dgvRstation.Item(enumdgvRstation.PartID.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        End If

        If Not IsNothing(dgvRstation.Item(enumdgvRstation.SopFilePath.ToString, Me.dgvRstation.CurrentRow.Index).Value) Then
            Me.txtSopFilePath.Text = dgvRstation.Item(enumdgvRstation.SopFilePath.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        End If

        If Not IsNothing(dgvRstation.Item(enumdgvRstation.CableType.ToString, Me.dgvRstation.CurrentRow.Index).Value) Then
            'System.Data.DataRowView
            If dgvRstation.Item(enumdgvRstation.CableType.ToString, Me.dgvRstation.CurrentRow.Index).Value = "System.Data.DataRowView" Then
                 Me.CboCableType.Text =""
            Else
                Me.CboCableType.Text = dgvRstation.Item(enumdgvRstation.CableType.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
            End If
        End If
        'end 
        txtStationid.Text = dgvRstation.Item(enumdgvRstation.Stationid.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtStationName.Text = dgvRstation.Item(enumdgvRstation.Stationname.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtStationdest.Text = dgvRstation.Item(enumdgvRstation.Stationdest.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtHandNum.Text = dgvRstation.Item(enumdgvRstation.HandNum.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        opflag = 2
        ToolbtnState(2)
    End Sub

    '作废
    Private Sub toolAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        Dim lsSQL As String = ""
        Try
            lsSQL = " Update m_Rstation_t set usey='N',userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() " & _
                    " WHERE Stationid = '" & Me.dgvRstation.Item(enumdgvRstation.Stationid.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'"  '1

            DbOperateUtils.ExecSQL(lsSQL)
            LoadDataToDatagridview(" WHERE Stationid='" & Me.dgvRstation.Item(enumdgvRstation.Stationid.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'") '1
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "toolAbandon_Click", "sys")
        End Try
    End Sub

    '保存
    Private Sub toolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        Dim SqlStr As New StringBuilder
        Dim SkillCode As String = ""
        Dim o_strStationID As String = "", o_strScan As String = ""
        If Not cboSkillCode.SelectedValue Is Nothing Then
            SkillCode = cboSkillCode.SelectedValue.ToString
        End If
        Dim reportTypeCode As String = Nothing
        If Not cboReportType.SelectedValue Is Nothing Then
            reportTypeCode = cboReportType.SelectedValue.ToString
        End If
        Try
            If Checkdata() = False Then Exit Sub
            Dim SopFilePath As String = Me.txtSopFilePath.Text.Trim
            Dim ServerFile As String = ""

            If Not String.IsNullOrEmpty(Me.SopFileName) Then
                Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.SopFilePath, txtStationName.Text.Trim) 'Path.Combine(VbCommClass.VbCommClass.SopFilePath + _runCardPn + "\\", _gridViewRow.Cells("工站名称").Value.ToString)
                If System.IO.Directory.Exists(destFilePath) = False Then
                    Directory.CreateDirectory(destFilePath)
                End If
                ServerFile = Path.Combine(destFilePath, Me.SopFileName)
                If ServerFile <> Me.dgvRstation.CurrentRow.Cells(enumdgvRstation.SopFilePath.ToString).Value Then
                    File.Copy(SopFilePath, ServerFile, True)
                End If
            Else '未选择上传
                ServerFile = SopFilePath
            End If

            'add by cq 20180426
            If Me.CboCableType.Text.Trim = "System.Data.DataRowView" Then
               Me.CboCableType.Text=""
            End If

            If opflag = 1 Then
                If Me.cboType.Text.Trim.Split("-")(0) <> "U" Then
                    o_strScan = "Y"
                Else
                    o_strScan = "N"
                End If
                'Add by cq 20160119, add SUBSTRING(STATIONID,1,1)='" & Me.cboType.Text.Trim.Split("-")(0) & "'
                SqlStr.Append(" INSERT INTO m_Rstation_t(Stationid, Stationname, Stationtype, Stationdest,HandNum, AsseY, WardY, NGY, usey, userid, intime,")
                SqlStr.Append(" SectionID, SkillCode, ReportTypeCode, SopFilePath, CableType,Equipment, PartID, Factoryid, Profitcenter,ScanY) OUTPUT inserted.Stationid")
                SqlStr.Append(" SELECT ISNULL('" & Me.cboType.Text.Trim.Split("-")(0) & "' + right(Replicate('0',5) + cast(cast(right(max(Stationid),5) as int)+1 as varchar),5),'" & Me.cboType.Text.Trim.Split("-")(0) & "'+'00001') Stationid,")
                SqlStr.Append(" N'" & txtStationName.Text.Trim & "','" & cboType.Text.ToString.Trim.Split("-")(0) & "',")
                SqlStr.Append(" N'" & txtStationdest.Text.Trim & "','" & txtHandNum.Text.Trim & "','Y','Y',")
                SqlStr.Append(" N'" & IIf(chkIsNgStation.Checked, "Y", "N") & "',")
                SqlStr.Append(" 'Y','" & SysMessageClass.UseId.ToLower.Trim & "',getdate(),")
                SqlStr.Append(" '" & Me.CboSectionID.Text.Split("-")(0) & "','" & Me.cboSkillCode.Text.Trim().Split("-")(0) & "','" & reportTypeCode & "',")
                SqlStr.Append(" N'" & ServerFile & "', N'" & Me.CboCableType.Text.Trim() & "', N'" & Me.txtEquipment.Text.Trim() & "', ")
                SqlStr.Append(" N'" & Me.txtPartID.Text.Trim() & "', ")
                SqlStr.Append(" '" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "', '" & o_strScan & "' ")
                SqlStr.Append(" FROM m_Rstation_t WHERE stationtype='" & Me.cboType.Text.Trim.Split("-")(0) & "'")
                SqlStr.Append(" AND SUBSTRING(STATIONID,1,1)='" & Me.cboType.Text.Trim.Split("-")(0) & "'")
            ElseIf opflag = 2 Then
                SqlStr.Append(" UPDATE m_Rstation_t SET Stationname =N'" & txtStationName.Text.Trim & "',Stationdest =N'" & txtStationdest.Text.Trim & "',")
                SqlStr.Append(" NGY='" & IIf(chkIsNgStation.Checked, "Y", "N") & "', ")
                SqlStr.Append(" userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate(), ")
                SqlStr.Append(" Equipment=N'" & Me.txtEquipment.Text.Trim & "', ")
                SqlStr.Append(" HandNum=N'" & Me.txtHandNum.Text.Trim & "', ")
                SqlStr.Append(" PartID=N'" & Me.txtPartID.Text.Trim & "', ")
                SqlStr.Append(" SectionID='" & Me.CboSectionID.Text.Trim.Split("-")(0) & "', ")
                SqlStr.Append(" skillcode='" & SkillCode & "',reportTypeCode='" & reportTypeCode & "',")
                SqlStr.Append(" CableType=N'" & Me.CboCableType.Text.Trim() & "',")
                SqlStr.Append(" SopFilePath=N'" & ServerFile & "'")
                SqlStr.Append(" WHERE Stationid = '" & txtStationid.Text.Trim() & "' and usey='Y'")
            End If
            Try
                If opflag = 2 Then
                    DbOperateUtils.ExecSQL(SqlStr.ToString)
                Else
                    Using dt As DataTable = DbOperateUtils.GetDataTable(SqlStr.ToString)
                        If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                            Me.txtStationid.Text = CStr(dt.Rows(0).Item(0)).Trim()
                        End If
                    End Using
                End If

                LoadDataToDatagridview("  WHERE Stationid='" & txtStationid.Text.Trim & "'")

                cboType.SelectedIndex = -1 : Me.CboSectionID.SelectedIndex = -1 : Me.cboSkillCode.SelectedIndex = -1 : Me.cboReportType.SelectedIndex = -1
                txtStationid.Text = "" : txtStationName.Text = "" : txtStationdest.Text = ""
                Me.txtEquipment.Text = "" : Me.txtSopFilePath.Text = "" : Me.CboCableType.Text = "" : Me.txtPartID.Text = ""

                opflag = 0
                ToolbtnState(0)
                MessageUtils.ShowInformation("保存成功！")
            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbSave_Click", "sys")
                Exit Sub
            End Try
        Catch ex As Exception
            Throw ex
        Finally
            Me.SopFileName = ""
        End Try
    End Sub

    '导出
    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        ExcelUtils.LoadDataToExcel(Me.dgvRstation, Me.Text)
    End Sub

    '返回
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        cboType.SelectedIndex = -1
        txtStationid.Text = ""
        txtStationName.Text = ""
        txtStationdest.Text = ""

        Me.CboCableType.Text = ""
        Me.txtEquipment.Text = ""
        Me.txtSopFilePath.Text = ""
        Me.CboSectionID.Text = ""
        Me.CboSectionID.SelectedIndex = -1
        Me.cboSkillCode.Text = ""
        Me.cboReportType.Text = ""

        opflag = 0
        ToolbtnState(0)
    End Sub

    '查询
    Private Sub tsbQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click

        Dim flag As Boolean = False
        Dim Sql As String = " WHERE 1=1"

        If Me.cboType.Text.Trim <> "" Then
            Sql = Sql & " AND Stationtype='" & Me.cboType.Text.Trim.Split("-")(0) & "'"
        End If
        If Me.txtStationid.Text.Trim <> "" Then
            Sql = Sql & " AND Stationid like '" & Me.txtStationid.Text.Trim & "%'"
        End If
        If Me.txtStationName.Text.Trim <> "" Then
            Sql = Sql & " AND Stationname like N'%" & Me.txtStationName.Text.Trim & "%'"
        End If

        If Not String.IsNullOrEmpty(Me.CboSectionID.Text.Trim()) Then
            Sql = Sql & " AND SectionID LIKE '" & Me.CboSectionID.Text.Trim.Split("-")(0) & "%'"
        End If

        If Me.chkUsey.Checked = True Then
            Sql = Sql & " AND a.usey = 'Y'"
        End If

        '关晓艳 add 查询时添加工单和产品料号查询
        If (Not String.IsNullOrEmpty(Me.txtMoid.Text.Trim())) Or (Not String.IsNullOrEmpty(Me.txtProPartid.Text.Trim())) Then
            If DataToStation() <> "" Then
                Sql = Sql & ") BB  on AA .Stati =BB.Stationid   "
            End If
        End If

        LoadDataToDatagridview(Sql)
    End Sub

    '退出 
    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '冻结
    Private Sub ToolBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBlock.Click
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        Dim lsSQL As String = String.Empty
        Try
            lsSQL = " UPDATE m_Rstation_t SET Rstate='N',userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() " & _
                    " WHERE Stationid = '" & Me.dgvRstation.Item(enumdgvRstation.Stationid.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'"
            DbOperateUtils.ExecSQL(lsSQL)
            LoadDataToDatagridview(" WHERE Stationid='" & Me.dgvRstation.Item(enumdgvRstation.Stationid.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
            MessageBox.Show("该站点已经进行冻结,不允许扫描...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "ToolBlock_Click", "sys")
        End Try
    End Sub

    '解除冻结
    Private Sub toolCancelLock_Click(sender As Object, e As EventArgs) Handles toolCancelLock.Click
        Dim lsSQL As String = ""
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        Try
            lsSQL = " UPDATE m_Rstation_t set Rstate='Y',userid='" & SysMessageClass.UseId.ToLower.Trim & "', intime=getdate() " & _
                    " WHERE Stationid = '" & Me.dgvRstation.Item(enumdgvRstation.Stationid.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'"
            DbOperateUtils.ExecSQL(lsSQL)
            LoadDataToDatagridview(" WHERE Stationid='" & Me.dgvRstation.Item(enumdgvRstation.Stationid.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
            MessageBox.Show("该站点已经解除冻结,允许扫描...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "toolCancelLock_Click", "sys")
        End Try
    End Sub

    '检查项次
    Private Sub toolCheckItem_Click(sender As Object, e As EventArgs) Handles toolCheckItem.Click
        Dim isAdd As Boolean
        Dim isDelete As Boolean
        Try
            If toolAdd.Tag Is Nothing Then toolAdd.Tag = "NO"
            isAdd = (toolAdd.Tag.ToString.ToUpper() = "YES")
            isDelete = (toolAbandon.Tag.ToString.ToUpper() = "YES")

            Dim selectValue = dgvRstation.Item(enumdgvRstation.Stationtype.ToString, dgvRstation.CurrentRow.Index).Value.ToString().Trim().Split("-")(0).ToUpper

            If "R,H".Contains(selectValue) = False Then
                MessageBox.Show("非流程卡工站，不需要维护校验项次!")
                Exit Sub
            End If

            'Id/StationNo/StationName
            Using frm As New FrmStationCheckItemMaintaince(dgvRstation.Item(enumdgvRstation.Stationid.ToString, dgvRstation.CurrentRow.Index).Value.ToString(),
                                                           Me.dgvRstation.Item(enumdgvRstation.Stationname.ToString, dgvRstation.CurrentRow.Index).Value.ToString(),
                                                           Me.dgvRstation.Item(enumdgvRstation.Stationname.ToString, dgvRstation.CurrentRow.Index).Value.ToString(),
                                                           isAdd, isDelete)
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '设置SOP
    Private Sub btnUploadSOP_Click(sender As Object, e As EventArgs) Handles btnUploadSOP.Click
        btnUploadSOP.Enabled = False
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            ' Me.SopFileName = OpenFileDialog1.FileName
            txtSopFilePath.Text = OpenFileDialog1.FileName
            Me.SopFileName = OpenFileDialog1.SafeFileName
            ' Me.DrawingFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnUploadSOP.Enabled = True
    End Sub

    '标准工时
    Private Sub ToolStdTime_Click(sender As Object, e As EventArgs) Handles ToolStdTime.Click
        Dim isAdd As Boolean = False
        Dim isDelete As Boolean
        Dim o_strStationID_Des As String = ""
        Try
            If toolAdd.Tag Is Nothing Then toolAdd.Tag = "NO"
            isAdd = (toolAdd.Tag.ToString.ToUpper() = "YES")
            isDelete = (toolAbandon.Tag.ToString.ToUpper() = "YES")


            'If dgvRstation.Item(enumdgvRstation.Stationtype.ToString, dgvRstation.CurrentRow.Index).Value.ToString().Trim().Split("-")(0).ToUpper <> "R" Then
            '    MessageBox.Show("非流程卡工站，不需要维护工时标准!")
            '    Exit Sub
            'End If

            'StationID/StationName
            o_strStationID_Des = dgvRstation.Item(enumdgvRstation.Stationid.ToString, dgvRstation.CurrentRow.Index).Value.ToString() + "-" +
                                 dgvRstation.Item(enumdgvRstation.Stationname.ToString, dgvRstation.CurrentRow.Index).Value.ToString()
            Dim StationID As String = dgvRstation.Item(enumdgvRstation.Stationid.ToString, dgvRstation.CurrentRow.Index).Value.ToString()
            Dim StationName As String = dgvRstation.Item(enumdgvRstation.Stationname.ToString, dgvRstation.CurrentRow.Index).Value.ToString()
            'Using frm As New FrmStdTime(o_strStationID_Des)
            Using frm As New FrmStdTime(StationID, StationName)
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '选择
    Private Sub toolCheck_Click(sender As Object, e As EventArgs) Handles toolCheck.Click
        SetSelectedData()
    End Sub

    '工站GRID双击时，选择数据到前一个页面
    Private Sub dgvRstation_DoubleClick(sender As Object, e As EventArgs) Handles dgvRstation.DoubleClick
        SetSelectedData()
    End Sub

    '工站类型选择时，清除工站ID和工站名称
    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        txtStationid.Width = 97
        BnSelectSta.Visible = False
        txtStationid.ReadOnly = False
        txtStationName.ReadOnly = False
        txtStationid.Text = ""
        txtStationName.Text = ""
    End Sub

    '没有用到
    Private Sub BnSelectSta_Click(sender As Object, e As EventArgs) Handles BnSelectSta.Click
        Try
            Dim frmQuery As New FrmQuery("select TestTypeID,TestTypeName from m_TestType_v", 0, "TestTypeID,TestTypeName")
            frmQuery.ShowDialog()
            If frmQuery.ReturnValue.Split(",").Length > 1 Then
                txtStationid.Text = frmQuery.ReturnValue.Split(",")(0)
                txtStationName.Text = frmQuery.ReturnValue.Split(",")(1)
            End If

        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub

    '查看流程卡
    Private Sub ToolFindRCard_Click(sender As Object, e As EventArgs) Handles ToolFindRCard.Click
        If IsNothing(Me.dgvRstation.CurrentRow) Then Exit Sub
        Dim o_strStationID As String = String.Empty
        o_strStationID = Me.dgvRstation.CurrentRow.Cells(enumdgvRstation.Stationid.ToString).Value.ToString
        If String.IsNullOrEmpty(o_strStationID) Then Exit Sub
        Using o_FrmPNList As FrmPNList = New FrmPNList(o_strStationID)
            o_FrmPNList.ShowDialog()
        End Using
    End Sub


    '站点关联不良代码  关晓艳 2017-04-12
    Private Sub toolAssocno_Click(sender As Object, e As EventArgs) Handles toolAssocno.Click
        If Me.dgvRstation.Rows.Count = 0 Then Exit Sub
        If Me.dgvRstation.CurrentRow Is Nothing Then
            MessageBox.Show("请选择要关联不良代码的工站", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim fr As FrmRStationNg = New FrmRStationNg()
        fr.station = dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        fr.stationName = dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        fr.ShowDialog()
    End Sub
#End Region

#Region "方法"

    'GRID数据选择
    Private Sub SetSelectedData()
        If Me.toolCheck.Enabled = False Then Exit Sub
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        If Me.dgvRstation.Item(enumdgvRstation.usey.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "Y" Then 'Me.dgvRstation.Item(4, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "Y" Then
            MessageBox.Show("该笔资料已作废", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        frmRstationid = Me.dgvRstation.Item(enumdgvRstation.Stationid.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        frmRstationname = Me.dgvRstation.Item(enumdgvRstation.Stationname.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim '2
        frmStationtype = Me.dgvRstation.Item(enumdgvRstation.Stationtype.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        If Not IsNothing(Me.dgvRstation.Item(enumdgvRstation.CableType.ToString, Me.dgvRstation.CurrentRow.Index).Value) Then
            frmStationCableType = Me.dgvRstation.Item(enumdgvRstation.CableType.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        Else
            frmStationCableType = ""
        End If

        Me.Close()
    End Sub

    '绑定GRIDVIEW
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim strSQL As String = ""

        '关晓艳 add 根据工单、产品料号查询
        If (Not String.IsNullOrEmpty(Me.txtMoid.Text.Trim())) Or (Not String.IsNullOrEmpty(Me.txtProPartid.Text.Trim())) Then
            If DataToStation() <> "" Then
                strSQL = DataToStation()
            End If
        End If

        strSQL = strSQL & _
                "SELECT c.Sortid + '-' + c.SortName AS StationType," + vbCrLf + _
                "       Stationid," + vbCrLf + _
                "       Stationname," + vbCrLf + _
                "       HandNum," + vbCrLf + _
                "       Stationdest,cast(sectionid as varchar(3)) + '-' + e.SectionName as sectionid," + vbCrLf + _
                "       equipment," + vbCrLf + _
                "       partID," + vbCrLf + _
                "       cabletype," + vbCrLf + _
                "       a.skillcode," + vbCrLf + _
                "       d.description," + vbCrLf + _
                "       a.reportTypeCode," + vbCrLf + _
                "       a.sopfilepath," + vbCrLf + _
                "       CASE a.usey WHEN 'Y' THEN 'Y-有效' WHEN 'N' THEN 'N-作廢' END" + vbCrLf + _
                "          AS Usey," + vbCrLf + _
                "       Case Rstate when 'Y' then 'Y' when 'N' then 'N-凍結' end as Rstate  ," + vbCrLf + _
                "       b.username," + vbCrLf + _
                "       CONVERT (VARCHAR (19), a.intime, 21) AS intime" + vbCrLf + _
                "  FROM m_RStation_t a" + vbCrLf + _
                "       LEFT JOIN dbo.m_Sortset_t c" + vbCrLf + _
                "          ON a.Stationtype = c.SortID AND c.SortType = 'StationType'" + vbCrLf + _
                "       LEFT JOIN m_users_t b ON a.userid = b.userid" + vbCrLf + _
                "       LEFT JOIN m_JobSkill_t d ON a.SkillCode = d.skillcode" + vbCrLf + _
                "       LEFT JOIN m_RstationSection_t  e ON a.SectionID= e.ID  " & SqlWhere

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        dgvRstation.DataSource = dt

        toolStripStatusLabel3.Text = Me.dgvRstation.Rows.Count
    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0
                Me.toolAdd.Enabled = IIf(Me.toolAdd.Tag.ToString <> "Yes", False, True)
                Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                Me.toolAbandon.Enabled = IIf(Me.toolAbandon.Tag.ToString <> "Yes", False, True)
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                Me.toolCheck.Enabled = False
                'GroupBox
                Me.cboType.Enabled = True
                Me.txtStationdest.Enabled = False
                Me.txtStationid.Enabled = True
                Me.txtStationName.Enabled = True
                Me.dgvRstation.Enabled = True
                Me.ActiveControl = Me.txtStationid

                '关晓艳 add “返回”工单、产品料号可用
                Me.txtMoid.Enabled = True
                Me.txtProPartid.Enabled = True
                Me.txtMoid.Text = ""
                Me.txtProPartid.Text = ""
            Case 1, 2
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                Me.toolCheck.Enabled = False
                'GroupBox
                Me.txtStationdest.Enabled = True
                Me.txtStationName.Enabled = True
                Me.cboType.Enabled = IIf(opflag = 1, True, False)
                Me.txtStationid.Enabled = False
                Me.dgvRstation.Enabled = False
                Me.ActiveControl = IIf(opflag = 1, Me.cboType, Me.txtStationName)

                'gxy add 新增修改 “返回”工单、产品料号不可用
                Me.txtMoid.Enabled = False
                Me.txtProPartid.Enabled = False
                Me.txtMoid.Text = ""
                Me.txtProPartid.Text = ""
            Case 3 '
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                Me.toolCheck.Enabled = True
                'GroupBox
                Me.cboType.Enabled = True
                Me.txtStationdest.Enabled = False
                Me.txtStationid.Enabled = True
                Me.txtStationName.Enabled = True
                Me.dgvRstation.Enabled = True
                Me.ActiveControl = Me.txtStationid
        End Select
    End Sub

    Private Function Checkdata() As Boolean
        If Me.cboType.Text.Trim = "" Then
            Me.ActiveControl = Me.cboType
            Return False
        End If
        If Me.txtStationName.Text.Trim = "" Then
            Me.ActiveControl = Me.txtStationName
            Return False
        End If

        If Me.cboType.Text.Split("-")(0) = "R" Then
            If String.IsNullOrEmpty(Me.CboSectionID.Text) Then
                MessageBox.Show("流程卡工站，必须选择工段类型！")
                Me.ActiveControl = Me.CboSectionID
                Return False
            End If
        End If

        If txtPartID.Text.Trim <> "" Then
            If CheckIsEquPartId() = False Then
                MessageUtils.ShowError("料号没有在料件基础资料中,请修改！")
                Me.ActiveControl = Me.txtPartID
                Return False
            End If
        End If

        If txtHandNum.Text.Trim <> "" Then
            If CheckUtils.HalfWidthNumChecker(txtHandNum.Text.Trim) = False And txtHandNum.Text.Trim <> "0" Then
                MessageUtils.ShowError("请输入正确配置数,请修改！")
                Me.ActiveControl = Me.txtHandNum
                Return False
            End If
        End If

        'If Me.cboType.Text.Split("-")(0) = "U" Then
        '    If opflag = 1 Then
        '        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        '        Dim sql As String = String.Format("select top 1 Stationid from m_Rstation_t where Stationid='{0}'", Me.txtStationid.Text)
        '        If Conn.CheckDataExistsBySql(sql) Then
        '            MessageBox.Show("线外工站已存在，不允许重复添加！")
        '            Me.ActiveControl = Me.txtStationid
        '            Return False
        '        End If

        '    End If   
        'End If

        '关晓艳  add 新增时工站名称不同类型不允许重复    2018-7-4  
        Dim stationName As String = Me.dgvRstation.Item(enumdgvRstation.Stationname.ToString, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim '2 
        Dim strSQL As String = " select  top 1  Stationname  from    m_RStation_t   WHERE usey='Y'   and Stationname=N'" + txtStationName.Text.Trim + "'   and Stationtype=N'" + Me.cboType.Text.Trim.Split("-")(0) + "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            If opflag = 1 Then
                MessageUtils.ShowError("此工站类型下工站名称已存在,请修改！")
                Me.ActiveControl = Me.txtStationName
                Return False
            ElseIf opflag = 2 Then
                If stationName <> txtStationName.Text.Trim And dt.Rows.Count > 0 Then
                    MessageUtils.ShowError("修改之后的工站名称已有存在，请另修改！")
                    Me.ActiveControl = Me.txtStationName
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    '取得设备料件资料
    Private Function CheckIsEquPartId() As Boolean
        If txtPartID.Text.Trim = "" Then Return True
        Dim strSQL As String = " select distinct 1 from m_PartContrast_t where TAvcPart = '{0}' and TYPE = 'E' "
        strSQL = String.Format(strSQL, txtPartID.Text.Trim)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count = 0) Then
            Return False
        End If
        Return True
    End Function

    '查询工站关联sql语句 关晓艳 2017-04-12
    Private Function DataToStation() As String
        Dim sql As String = " select distinct  Stationid Stati from  m_Mainmo_t a join m_RpartstationD_T b on a.PartID=b.ppartid where state=1 "
        If Not String.IsNullOrEmpty(Me.txtMoid.Text.Trim()) Then
            sql = sql & " and Moid like '" & Me.txtMoid.Text.Trim() & "%'"
        End If
        If Not String.IsNullOrEmpty(Me.txtProPartid.Text.Trim()) Then
            sql = sql & " and partid like '" & Me.txtProPartid.Text.Trim & "%' "
        End If
        sql = "select BB.* from ( " + sql + " ) AA join ("
        Return sql
    End Function
#End Region

#Region "共通"

    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02003' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        Dim Obj As Object
        While Reader.Read
            '
            Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
            Obj.Tag = "Yes"
        End While
        Reader.Close()
        Conn.PubConnection.Close()
        Conn = Nothing
    End Sub

#Region "BindComBox"
    Private Sub BindCombox(ByVal ColComboBox As ComboBox)
        Try
            Dim strSQL As String
            If ColComboBox.Name = "CboSectionID" Then
                strSQL = "SELECT  ID, (REPLACE(Id,' ','') + '-' + SectionName) as SectionName from m_RStationSection_t(nolock) where usey=1 "
                BindCombox(strSQL, ColComboBox, "SectionName", "ID")
            End If
            If ColComboBox.Name = "cboSkillCode" Then
                strSQL = "SELECT SKILLCODE,skillcode+ '-' + DESCRIPTION as DESCRIPTION FROM m_JobSkill_t(NOLOCK) WHERE usey=1 "
                BindCombox(strSQL, ColComboBox, "DESCRIPTION", "SKILLCODE")
            End If
            If ColComboBox.Name = "cboReportType" Then
                strSQL = "SELECT REPORTTYPECODE,REPORTTYPECODE+ '-' + REPORTTYPEDESCRIPTION as REPORTTYPEDESCRIPTION FROM M_IPQCREPORT_T WHERE usey=1"
                BindCombox(strSQL, ColComboBox, "REPORTTYPEDESCRIPTION", "REPORTTYPECODE")
            End If
            If ColComboBox.Name = "cboType" Then
                strSQL = "SELECT SortID+ '-' + SortName as  SortID,SortName from m_Sortset_t where SortType = 'StationType' and Usey='Y' order by Orderid"
                BindCombox(strSQL, ColComboBox, "SortID", "SortName")
            End If
            If ColComboBox.Name = "CboCableType" Then
                strSQL = "select distinct CableType from m_Rstation_t where  usey ='Y' and  isnull(CableType,'')<> ''"
                BindCombox(strSQL, ColComboBox, "CableType", "CableType")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub BindCombox(ByVal SQL As String, ByVal ColComboBox As ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)

        Dim dr As DataRow = dt.NewRow

        dr(Text) = ""
        dr(value) = ""
        dt.Rows.InsertAt(dr, 0)

        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value
    End Sub
#End Region

#End Region

End Class