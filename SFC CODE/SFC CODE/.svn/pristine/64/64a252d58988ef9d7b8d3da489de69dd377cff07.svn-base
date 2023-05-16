Option Explicit On
Option Strict On
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

''' 修改者： 田玉琳
''' 修改日： 2016/04/05
''' 修改内容：自动生成班别资料
Public Class FrmPartTime

#Region "常变量定义"
   
    Private Enum enumdgvMOInfo
        moid
        motype
        partid
        moqty
        deptid
        lineid
        status
        ParentMo
    End Enum

    Private Enum enumdgvMOShift
        moid
        lineid
        WorkShift
        starttime
        endtime
        Quorum
        RealNum
        UserID
        intime
    End Enum
    ' Status  0.新建(default) 1.在制过程中 2.结案 3.冻结
    Private Enum enumMOStatus
        iNew = 0
        WIP
        Close
        Lock
    End Enum
#End Region

#Region "初期化"

    '页面初期化
    Private Sub FrmPartTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Call BindLine()
            LoadDataToDatagridview()
            FillCombox(CboDept)
            CboDept.SelectedIndex = -1
            CboLine.SelectedIndex = -1
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmPartTime", "FrmPartTime_Load", "sys")
        End Try
    End Sub

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim UserDg As DataTable
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim lsSQL As String = String.Empty
        'dqc+'--'+deptid
        If ColComboBox.Name = "CboDept" Then
            lsSQL = " SELECT deptid, deptid+'--'+dqc as dqc FROM  m_Dept_t WHERE factoryid='" & VbCommClass.VbCommClass.Factory & "'"
            UserDg = DataHand.GetDataTable(lsSQL)
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "dqc"
            ColComboBox.ValueMember = "deptid"
        ElseIf ColComboBox.Name = "ComMoType" Then
            UserDg = DataHand.GetDataTable("SELECT motype,typeid FROM motype_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "motype"
            ColComboBox.ValueMember = "typeid"
        End If
        UserDg = Nothing
    End Sub

    Private Sub SetUIValueByState()
        Me.CboDept.Text = ""
        Me.TxtMoNo.Text = ""
        Me.CboLine.Text = ""
        Me.txtPartID.Text = ""
        Me.txtParentMO.Text = ""
        Me.txtQuorum.Text = ""
        Me.txtRealNum.Text = ""
    End Sub

    '工单信息初始化
    Private Sub LoadDataToDatagridview()
        Dim strSQL As String = _
                "SELECT TOP 1000 " + vbCrLf + _
                "       MOID," + vbCrLf + _
                "       a.typeid + '-' + b.motype AS motype," + vbCrLf + _
                "       partid," + vbCrLf + _
                "       moqty," + vbCrLf + _
                "       (a.deptid+'-'+dept.dqc)deptid," + vbCrLf + _
                "       lineid," + vbCrLf + _
                "       CASE status" + vbCrLf + _
                "          WHEN 0 THEN N'0-新建'" + vbCrLf + _
                "          WHEN 1 THEN N'1-在制过程中'" + vbCrLf + _
                "          WHEN 2 THEN N'2-结案'" + vbCrLf + _
                "          WHEN 3 THEN N'3-冻结'" + vbCrLf + _
                "       END" + vbCrLf + _
                "          AS status," + vbCrLf + _
                "       ParentMo" + vbCrLf + _
                "  FROM m_mainmo_t a LEFT JOIN motype_t b ON a.typeid = b.typeid" + vbCrLf + _
                "  LEFT JOIN m_Dept_t  dept ON dept.deptid = a.Deptid" + vbCrLf + _
                " WHERE Factory = '" & VbCommClass.VbCommClass.Factory & "' AND a.profitcenter = '" & VbCommClass.VbCommClass.profitcenter & "' "

        strSQL = strSQL + GetDTbyWhere() + "ORDER BY a.Createtime DESC "
        dgvMOInfo.DataSource = DbOperateUtils.GetDataTable(strSQL)
    End Sub


    Private Function GetDTbyWhere() As String
        Dim strWhere As New System.Text.StringBuilder
      
        If String.IsNullOrEmpty(TxtMoNo.Text.Trim) = False Then
            strWhere.Append(" AND a.Moid like '%" & Me.TxtMoNo.Text.Trim() & "%'")
        End If

        If String.IsNullOrEmpty(CboDept.Text) = False Then
            strWhere.Append(" AND a.deptid LIKE '%" & CobTextInstr(CboDept) & "%'")
        End If

        If String.IsNullOrEmpty(CboLine.Text) = False Then
            strWhere.Append(" AND a.lineid LIKE '%" & CboLine.Text & "%'")
        End If

        If UCase(CboMOStatus.Text.Trim) <> "ALL" And String.IsNullOrEmpty(CboMOStatus.Text) = False Then
            strWhere.Append(" AND a.Status='" & CobTextInstr(CboMOStatus) & "'")
        End If

        Return strWhere.ToString
    End Function

    '绑定班别
    Private Sub BindMOShift(ByVal moid As String)
        Dim Sqlstr As String = _
                "SELECT moid," + vbCrLf + _
                "       lineid," + vbCrLf + _
                "       N'第' + cast (workshift AS VARCHAR (4)) + N'节' AS workshift," + vbCrLf + _
                "       starttime," + vbCrLf + _
                "       endtime," + vbCrLf + _
                "       Quorum," + vbCrLf + _
                "       RealNum," + vbCrLf + _
                "       userid," + vbCrLf + _
                "       Intime" + vbCrLf + _
                "  FROM m_MoWorkShift_t "
        Dim strWhere As String = " WHERE moid ='" & moid & "'"
        Dim strOrder As String = " ORDER BY starttime ASC "

        Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr & strWhere & strOrder)
        dgvMOShift.DataSource = dt
    End Sub

#End Region

#Region "工具条"
    '查询
    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Try
            LoadDataToDatagridview()
        Catch ex As Exception
            MessageBox.Show("查询工单异常，请联系开发人员 + " & ex.Message & "")
        End Try
    End Sub

    '签到
    Private Sub tsbAssign_Click(sender As Object, e As EventArgs) Handles ToolSign.Click
        Dim frm As FrmMoWorkShift = New FrmMoWorkShift()

        '反填
        frm.Moid = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.moid.ToString).Value.ToString
        frm.DeptId = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.deptid.ToString).Value.ToString
        frm.LineId = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.lineid.ToString).Value.ToString

        Dim result As DialogResult = frm.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            dgvMOInfo_CellClick(Nothing, Nothing)
        End If
    End Sub

    '返回
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SetUIValueByState()
    End Sub

    '生产
    Private Sub ToolProduction_Click(sender As Object, e As EventArgs) Handles ToolProduction.Click
        '生产：选中要维护的工单，点击生产。Insert into m_MoProductTime_t
        '①同一生产日期，同一生产班别，允许有多个工单正在生产(有可能前后段生产不同的工单)。
        '②只有新建状态的工单可点击进行生产。
        'StartReason: 生产/取消结案/取消冻结
        Dim lsSQL As String = ""
        Try

            If Me.dgvMOInfo.Rows.Count = 0 OrElse Me.dgvMOInfo.CurrentRow Is Nothing Then Exit Sub
            'Check Status
            If Not (Val(dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.status.ToString).Value.ToString.Split(CChar("-"))(0)) = enumMOStatus.iNew) Then
                MessageUtils.ShowError("只有工单状态为:{0.新建}的才允许!")
                Exit Sub
            End If

            Dim moid As String = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.moid.ToString).Value.ToString
            Dim lineid As String = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.lineid.ToString).Value.ToString

            lsSQL = " INSERT INTO m_MoProductTime_t(MOID,LINEID,STARTTIME,StartUser,StartReason) " & _
                    " VALUES('" & moid & "','" & lineid & "' ,getDate(),'" & SysMessageClass.UseId & "' ,N'生产')"

            lsSQL = lsSQL + String.Format(" update m_MainMO_t set status ='{0}' where moid ='{1}'", Convert.ToInt16(enumMOStatus.WIP), moid)

            DbOperateUtils.ExecSQL(lsSQL)
            MessageUtils.ShowInformation("开始生产成功!")
            'Refresh Data
            LoadDataToDatagridview()
            SetUIValueByState()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '结案
    Private Sub ToolClose_Click(sender As Object, e As EventArgs) Handles ToolClose.Click
        '结案/冻结：选中要维护的工单，点击结案/冻结。Update m_MoProductTime_t where EndUser is null
        '①只有生产中的工单可点击结案或冻结。
        '②停止生产时，要先冻结，以便更准确地计算真正的生产时间。
        Dim lsSQL As String = ""
        Try

            If Me.dgvMOInfo.Rows.Count = 0 OrElse Me.dgvMOInfo.CurrentRow Is Nothing Then Exit Sub
            'Check Status
            If Not (Val(dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.status.ToString).Value.ToString.Split(CChar("-"))(0)) = enumMOStatus.WIP) Then
                MessageUtils.ShowError("只有工单状态为[1-在制过程中]才允许结案!")
                Exit Sub
            End If

            Dim moid As String = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.moid.ToString).Value.ToString
            Dim lineid As String = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.lineid.ToString).Value.ToString

            lsSQL = _
                "UPDATE m_MoProductTime_t" &
                "   SET endtime = getdate (), endreason = N'结案',enduser='" & SysMessageClass.UseId & "'" &
                " WHERE moid = '" & moid &
                "' AND lineid = '" & lineid & "' AND endtime IS NULL"

            lsSQL = lsSQL + String.Format(" update m_MainMO_t set status ='{0}' where moid ='{1}'", Convert.ToInt16(enumMOStatus.Close), moid)

            DbOperateUtils.ExecSQL(lsSQL)
            MessageUtils.ShowInformation("结案成功!")
            'Refresh Data
            LoadDataToDatagridview()
            SetUIValueByState()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '取消结案
    Private Sub ToolCancelClose_Click(sender As Object, e As EventArgs) Handles ToolCancelClose.Click
        ' 取消结案/冻结：选中要维护的工单，取消结案/取消冻结。Insert into m_MoProductTime_t
        '①只有结案/冻结的工单，可以取消结案/冻结，恢复生产。
        Dim lsSQL As String = ""
        Try

            If Me.dgvMOInfo.Rows.Count = 0 OrElse Me.dgvMOInfo.CurrentRow Is Nothing Then Exit Sub
            'Check Status
            If Not (Val(dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.status.ToString).Value.ToString.Split(CChar("-"))(0)) = enumMOStatus.Close) Then
                MessageUtils.ShowError("只有工单状态为结案的才允许!")
                Exit Sub
            End If
            Dim moid As String = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.moid.ToString).Value.ToString
            Dim lineid As String = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.lineid.ToString).Value.ToString

            lsSQL = " INSERT INTO m_MoProductTime_t(MOID,LINEID,STARTTIME,StartUser,StartReason) " & _
                    " VALUES('" & moid & "','" & lineid & "' , getDate(),'" & SysMessageClass.UseId & "' ,N'取消结案')  "
            lsSQL = lsSQL + String.Format(" update m_MainMO_t set status ='{0}' where moid ='{1}'", Convert.ToInt16(enumMOStatus.WIP), moid)

            DbOperateUtils.ExecSQL(lsSQL)
            MessageUtils.ShowInformation("取消结案成功!")
            'Refresh Data
            LoadDataToDatagridview()
            SetUIValueByState()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '冻结
    Private Sub ToolLock_Click(sender As Object, e As EventArgs) Handles ToolLock.Click
        '结案/冻结：选中要维护的工单，点击结案/冻结。Update m_MoProductTime_t where EndUser is null
        '①只有生产中的工单可点击结案或冻结。
        '②停止生产时，要先冻结，以便更准确地计算真正的生产时间。
        Dim lsSQL As String = ""
        Try

            If Me.dgvMOInfo.Rows.Count = 0 OrElse Me.dgvMOInfo.CurrentRow Is Nothing Then Exit Sub
            'Check Status
            If Not (Val(dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.status.ToString).Value.ToString().Split(CChar("-"))(0)) = enumMOStatus.WIP) Then
                MessageUtils.ShowError("只有工单状态为：[1-在制过程中] 才允许冻结!")
                Exit Sub
            End If
            Dim moid As String = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.moid.ToString).Value.ToString
            Dim lineid As String = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.lineid.ToString).Value.ToString
            lsSQL = _
                "UPDATE m_MoProductTime_t" &
                "   SET endtime = getdate (), endreason = N'冻结',enduser='" & SysMessageClass.UseId & "'" &
                " WHERE moid = '" & moid & "' AND lineid = '" & lineid & "' AND endtime IS NULL"
            lsSQL = lsSQL + String.Format(" update m_MainMO_t set status ='{0}' where moid ='{1}'", Convert.ToInt16(enumMOStatus.Lock), moid)

            DbOperateUtils.ExecSQL(lsSQL)
            MessageUtils.ShowInformation("冻结成功!")
            'Refresh Data
            LoadDataToDatagridview()
            SetUIValueByState()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '取消冻结
    Private Sub ToolCancelLock_Click(sender As Object, e As EventArgs) Handles ToolCancelLock.Click
        ' 取消结案/冻结：选中要维护的工单，取消结案/取消冻结。Insert into m_MoProductTime_t
        '①只有结案/冻结的工单，可以取消结案/冻结，恢复生产。
        Dim lsSQL As String = ""
        Try
            If Me.dgvMOInfo.Rows.Count = 0 OrElse Me.dgvMOInfo.CurrentRow Is Nothing Then Exit Sub
            'Check Status
            If Not (Val(dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.status.ToString).Value.ToString.Split(CChar("-"))(0)) = enumMOStatus.Lock) Then
                MessageUtils.ShowError("只允许操作工单状态为冻结的!")
                Exit Sub
            End If
            Dim moid As String = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.moid.ToString).Value.ToString
            Dim lineid As String = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.lineid.ToString).Value.ToString

            lsSQL = " INSERT INTO m_MoProductTime_t(MOID,LINEID,STARTTIME,StartUser,StartReason) " & _
                     " values('" & moid & "','" & lineid & "' , getDate(),'" & SysMessageClass.UseId & "' ,N'取消冻结')  "
            lsSQL = lsSQL + String.Format(" update m_MainMO_t set status ='{0}' where moid ='{1}'", Convert.ToInt16(enumMOStatus.WIP), moid)

            DbOperateUtils.ExecSQL(lsSQL)
            MessageUtils.ShowInformation("取消冻结成功!")
            'Refresh Data
            LoadDataToDatagridview()
            SetUIValueByState()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmPartTime", "ToolCancelLock_Click", "sys")
            Throw ex
        End Try
    End Sub

    '退出
    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

#End Region

#Region "Grid事件"
    '工单GRID点击事件
    Private Sub dgvMOInfo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMOInfo.CellClick
        If dgvMOInfo.CurrentCell Is Nothing Then Exit Sub
        If dgvMOInfo.CurrentCell.RowIndex = dgvMOInfo.Rows.Count Then Exit Sub

        '反填
        Me.TxtMoNo.Text = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.moid.ToString).Value.ToString
        Me.CboDept.Text = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.deptid.ToString).Value.ToString
        Me.CboLine.Text = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.lineid.ToString).Value.ToString
        Me.txtParentMO.Text = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.ParentMo.ToString).Value.ToString
        Me.txtPartID.Text = dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.partid.ToString).Value.ToString
        Call BindMOShift(dgvMOInfo.CurrentRow.Cells(enumdgvMOInfo.moid.ToString).Value.ToString)
    End Sub

    '班别GRID点击事件
    Private Sub dgvMOShift_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMOShift.CellClick
        If dgvMOInfo.CurrentCell Is Nothing Then Exit Sub
        If dgvMOInfo.CurrentCell.RowIndex = dgvMOInfo.Rows.Count Then Exit Sub
        '反填
        Me.DateTimePickerStart.Text = Me.dgvMOShift.CurrentRow.Cells(enumdgvMOShift.starttime).Value.ToString
        Me.DateTimePickerEnd.Text = Me.dgvMOShift.CurrentRow.Cells(enumdgvMOShift.endtime).Value.ToString
        Me.txtQuorum.Text = Me.dgvMOShift.CurrentRow.Cells(enumdgvMOShift.Quorum).Value.ToString
        Me.txtRealNum.Text = Me.dgvMOShift.CurrentRow.Cells(enumdgvMOShift.RealNum).Value.ToString
    End Sub
#End Region

#Region "其他事件"
    '部门选择
    Private Sub CboDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboDept.SelectedIndexChanged
        If Not CboDept.SelectedValue Is Nothing AndAlso CboDept.SelectedValue.ToString <> "" Then
            Dim sql As String = " SELECT lineid as value, lineid as text  FROM deptline_t " & _
                                " WHERE factoryid ='" & VbCommClass.VbCommClass.Factory & "' " & _
                                " AND deptid='" & Me.CboDept.SelectedValue.ToString() & "' "
            Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
                dt.Rows.InsertAt(dt.NewRow, 0)
                CboLine.ValueMember = "value"
                CboLine.DisplayMember = "text"
                CboLine.DataSource = dt.DefaultView
            End Using
        End If
    End Sub

#End Region

    'For Find the ComboBox text
    Private Function CobTextInstr(ByVal MoComBox As ComboBox) As String
        If MoComBox.Text = "" Then
            CobTextInstr = ""
            Exit Function
        End If

        Dim I As Integer = InStr(MoComBox.Text.Trim, "-")
        Dim LineStr As String = MoComBox.Text.Substring(0, I - 1)
        CobTextInstr = LineStr
    End Function


End Class