Imports MainFrame
Imports MainFrame.SysCheckData
Public Class FrmT3BindDataRemedy
    Dim SqlserverName As String = ""

#Region "枚举类型"
    Private Enum enumQueryResult
        Items
        PartID
        RealMoid
        ReallineID
        PPID
        SendMoid
        SendLineID
        RealTestTime
        TestTime
        DelayInterval
        State
        IsCheck
        Remark
        ModifyBy
        ModifyTime
    End Enum
#End Region

#Region "触发事件"

    Private Sub FrmT3BindDataRemedy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim intRight As Integer = CInt(DbOperateUtils.GetDataTable("select ISNULL(sum(case b.tkey when 'M02023001_' then 1 when 'M02023003_' then 2 else 0 end),0) from m_Users_t a  join m_userright_t b on a.userid=b.userid where b.tkey in('M02023001_','M02023003_') and a.userid='" & SysMessageClass.UseId & "'").Rows(0)(0).ToString())
        Dim blnSendOrNot As Boolean = intRight Mod 2 = 1
        Dim blnIsCheckOrNot As Boolean = intRight >= 2

        chkChangeToNoSend.Enabled = blnSendOrNot
        chkChangeToSend.Enabled = blnSendOrNot
        chkChangeToIsCheck.Enabled = blnIsCheckOrNot
        chkChangeToNoCheck.Enabled = blnIsCheckOrNot
        Initialization()
        SqlserverName = MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            If chkQueryByRealTime.Checked OrElse chkQueryBySendTime.Checked OrElse txtRealMoid.Text.Trim <> "" OrElse txtSendMoid.Text.Trim <> "" OrElse txtPPID.Text.Replace("\r", "").Replace("\n", "").Replace(" ", "") <> "" Then
                LoadDataToDatagridview(GetSqlWhere())
            Else
                MessageUtils.ShowInformation("请 至少选择一组时间段 或 输入工单 或 输入条码 作为查询条件！")
            End If
        Catch ex As Exception
            MessageUtils.ShowInformation("系统异常，请联系值班人员处理！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmT3BindDataRemedy", "toolQuery_Click", "sys")
        End Try
    End Sub

    Private Sub ToolChangeBindData_Click(sender As Object, e As EventArgs) Handles ToolChangeBindData.Click
        Try
            If Not (chkChangeMO.Checked OrElse chkChangeLine.Checked OrElse chkChangeDelayInterval.Checked OrElse chkChangeToNoSend.Checked OrElse chkChangeToSend.Checked) Then
                MessageUtils.ShowInformation("请至少勾选一项需要变更的信息！") : Exit Sub
            ElseIf chkChangeMO.Checked AndAlso txtChangeMO.Text.Trim = "" Then
                MessageUtils.ShowInformation("请填写要变更的发送的工单！") : Exit Sub
            ElseIf chkChangeLine.Checked AndAlso txtChangeLine.Text.Trim = "" Then
                MessageUtils.ShowInformation("请填写要变更的发送的线别！") : Exit Sub
            ElseIf chkChangeDelayInterval.Checked AndAlso (txtChangeDelayNum.Text = "" OrElse cboChangeDelayUnit.SelectedIndex <= 0) Then
                MessageUtils.ShowInformation("请将要变更的延后时间的信息补充完整！") : Exit Sub
            ElseIf chkChangeToNoSend.Checked AndAlso chkChangeToSend.Checked Then
                MessageUtils.ShowInformation("变更为不发送和变更为需发送，最多只能勾选一项！") : Exit Sub
            ElseIf chkChangeToIsCheck.Checked AndAlso chkChangeToNoCheck.Checked Then
                MessageUtils.ShowInformation("变更为点检模式和变更为正常生产模式，最多只能勾选一项！") : Exit Sub
            ElseIf txtReason.Text.Trim = "" Then
                MessageUtils.ShowInformation("请填写原因说明！") : Exit Sub
            ElseIf txtPPID.Text.Replace(Chr(13) + Chr(10), "").Replace(" ", "") = "" AndAlso Not ((chkQueryByRealTime.Checked OrElse chkQueryBySendTime.Checked) AndAlso (txtRealMoid.Text.Trim <> "" OrElse txtSendMoid.Text.Trim <> "")) Then
                MessageUtils.ShowInformation("请 至少选择一组时间段并输入工单 或 输入条码 作为查询条件！") : Exit Sub
            ElseIf MessageUtils.ShowConfirm("您确定要变更数据吗？确定=>将根据当前界面上的查询条件，对查询结果数据进行变更！！！", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            ElseIf SysMessageClass.UseName = "" Then
                GetUserName()
            End If

            Dim strWhere As String = GetSqlWhere()
            Dim strUpdate As String = "ChangeBy='" + SysMessageClass.UseId + "',ChangeByName=N'" + SysMessageClass.UseName + "',ChangeTime=GETDATE()" +
                IIf(chkChangeMO.Checked, ",Moid = '" + txtChangeMO.Text.Trim() + "'", "") +
                IIf(chkChangeLine.Checked, ",LineID = '" + txtChangeLine.Text.Trim() + "'", "") +
                IIf(chkChangeDelayInterval.Checked, ",TestTime=DATEADD(" + cboChangeDelayUnit.Text + "," + txtChangeDelayNum.Text + ",RealTestTime)", "") +
                IIf(chkChangeToNoSend.Checked, ",state='D'", "") +
                IIf(chkChangeToSend.Checked, ",state='C'", "") +
                IIf(chkChangeToIsCheck.Checked, ",IsCheck='Y'", "") +
                IIf(chkChangeToNoCheck.Checked, ",IsCheck='N'", "") +
                IIf(chkRecyclePPID.Checked, ",PPID=PPID+'(del)'", "")
            Dim strSql = "UPDATE m_CableInfo_t SET " + strUpdate + strWhere + " SELECT @@ROWCOUNT " +
            "UPDATE m_CableInfoD_t SET NotSendReason=N'" + txtReason.Text.Trim + "'," + strUpdate + strWhere + " SELECT @@ROWCOUNT "

            Try
                '链接数据库速度很慢，需直连变更数据
                MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = "data source=172.20.23.107;initial catalog=MESDataCenter;uid=collect_user;pwd=023010015004072016029073020007027006087000"
                Dim ds As DataSet = DbOperateUtils.GetDataSet(strSql)
                MessageUtils.ShowInformation("数据变更成功！共影响 " + ds.Tables(0).Rows(0)(0).ToString + " PCS产品 " + ds.Tables(1).Rows(0)(0).ToString + " 笔测试数据")
            Catch ex As Exception
                Throw ex
            Finally
                MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = SqlserverName
            End Try

            LoadDataToDatagridview(strWhere)
            Initialization("Change")
        Catch ex As Exception
            MessageUtils.ShowInformation("数据变更失败！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmT3BindDataRemedy", "ToolChangeBindData_Click", "sys")
        End Try
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub chkChangeDelayInterval_CheckedChanged(sender As Object, e As EventArgs) Handles chkChangeDelayInterval.CheckedChanged
        EnableControl("DELAY", chkChangeDelayInterval.Checked)
    End Sub

    Private Sub chkChangeToNoSend_CheckedChanged(sender As Object, e As EventArgs) Handles chkChangeToNoSend.CheckedChanged, chkChangeToIsCheck.CheckedChanged
        If chkChangeToNoSend.Checked OrElse chkChangeToIsCheck.Checked Then
            chkRecyclePPID.Visible = True
        Else
            chkRecyclePPID.Checked = False
            chkRecyclePPID.Visible = False
        End If
    End Sub

    Private Sub txtChangeDelayNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChangeDelayNum.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        ElseIf e.KeyChar = "-" AndAlso txtChangeDelayNum.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub toolClear_Click(sender As Object, e As EventArgs) Handles toolClear.Click
        Initialization()
    End Sub

#End Region

#Region "函数、方法"
    '控件值初始化
    Private Sub Initialization(Optional ByVal type As String = "Query")
        Select Case type
            Case "Query"
                chkQueryByRealTime.Checked = True
                chkQueryBySendTime.Checked = False
                dtRealTestTimeFm.Value = DateTime.Now.Date
                dtRealTestTimeTo.Value = DateTime.Now.AddDays(1).Date
                dtTestTimeFm.Value = DateTime.Now.Date
                dtTestTimeTo.Value = DateTime.Now.AddDays(1).Date
                cboState.SelectedIndex = 0
                cboIsCheck.SelectedIndex = 0
                txtRealMoid.Text = ""
                txtRealLineID.Text = ""
                txtSendMoid.Text = ""
                txtSendLineID.Text = ""
                txtPartID.Text = ""
                txtPPID.Text = ""
            Case "Change"
                chkChangeMO.Checked = False
                chkChangeLine.Checked = False
                chkChangeToNoSend.Checked = False
                chkChangeToSend.Checked = False
                chkChangeToIsCheck.Checked = False
                chkChangeToNoCheck.Checked = False
                chkRecyclePPID.Checked = False
                chkRecyclePPID.Visible = False
                txtChangeMO.Text = ""
                txtChangeLine.Text = ""
                txtReason.Text = ""
                chkChangeDelayInterval.Checked = False
                EnableControl("DELAY", chkChangeDelayInterval.Checked)
        End Select
    End Sub

    Private Function GetSqlWhere() As String
        Dim strWhere As String = " WHERE State='" + cboState.Text.Split(".")(0) + "' AND IsCheck='" + cboIsCheck.Text.Split(".")(0) + "'" +
            IIf(chkQueryByRealTime.Checked, " AND RealTestTime BETWEEN '" + dtRealTestTimeFm.Value.ToString() + "' AND '" + dtRealTestTimeTo.Value.ToString() + "'", "") +
            IIf(chkQueryBySendTime.Checked, " AND TestTime BETWEEN '" + dtTestTimeFm.Value.ToString() + "' AND '" + dtTestTimeTo.Value.ToString() + "'", "") +
            IIf(String.IsNullOrEmpty(txtRealMoid.Text.Trim()), "", " AND RealMoid = '" + txtRealMoid.Text.Trim() + "'") +
            IIf(String.IsNullOrEmpty(txtRealLineID.Text.Trim()), "", " AND RealLineID = '" + txtRealLineID.Text.Trim() + "'") +
            IIf(String.IsNullOrEmpty(txtSendMoid.Text.Trim()), "", " AND Moid = '" + txtSendMoid.Text.Trim() + "'") +
            IIf(String.IsNullOrEmpty(txtSendLineID.Text.Trim()), "", " AND LineID = '" + txtSendLineID.Text.Trim() + "'") +
            IIf(String.IsNullOrEmpty(txtPartID.Text.Trim()), "", " AND PartID = '" + txtPartID.Text.Trim() + "'")

        Dim strPPID As String = txtPPID.Text.Replace(Chr(13) + Chr(10), "','").Replace(" ", "")
        strWhere += IIf(strPPID = "", "", " AND PPID IN('" + strPPID + "')")

        Return strWhere
    End Function

    ''' <summary>
    ''' 查询结果绑定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadDataToDatagridview(ByVal strSqlWhere As String)
        Try
            Dim strSql As String = "SELECT Items,PartID,RealMoid,ReallineID,PPID,Moid SendMoid,LineID SendLineID,RealTestTime,TestTime,CAST(DATEDIFF(HOUR,RealTestTime,TestTime) AS VARCHAR)+' Hour('+CAST(DATEDIFF(MINUTE,RealTestTime,TestTime) AS VARCHAR)+' Minute)'DelayInterval,CASE STATE WHEN 'N' THEN N'N.还未处理' WHEN 'C' THEN N'C.换算完成待发送' WHEN 'D' THEN N'D.换算完成不需要发送'WHEN 'S' THEN N'S.已发送' WHEN 'E' THEN N'E.发送失败-数据错误' WHEN 'W' THEN N'W.发送失败-华为接口异常' WHEN 'R' THEN N'R.多余数据' END State,CASE IsCheck WHEN 'N' THEN N'N.正常生产模式' WHEN 'Y' THEN N'Y.点检模式' ELSE '' END IsCheck,NotSendReason Remark,CAST(ChangeBy AS NVARCHAR)+'/'+CAST(ChangeByName AS NVARCHAR) ChangeBy,CONVERT(VARCHAR(16),ChangeTime,21) ChangeTime FROM [172.20.23.107].MESDataCenter.dbo.m_CableInfoD_v" + strSqlWhere + " ORDER BY TestTime"

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            dgvT3BindData.Rows.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim row As DataRow = dt.Rows(i)
                dgvT3BindData.Rows.Add(row.Item(enumQueryResult.Items).ToString, row.Item(enumQueryResult.PartID).ToString,
                                       row.Item(enumQueryResult.RealMoid).ToString, row.Item(enumQueryResult.ReallineID).ToString,
                                       row.Item(enumQueryResult.PPID).ToString, row.Item(enumQueryResult.SendMoid).ToString,
                                       row.Item(enumQueryResult.SendLineID).ToString, row.Item(enumQueryResult.RealTestTime).ToString,
                                       row.Item(enumQueryResult.TestTime).ToString, row.Item(enumQueryResult.DelayInterval).ToString,
                                       row.Item(enumQueryResult.State).ToString, row.Item(enumQueryResult.IsCheck).ToString,
                                       row.Item(enumQueryResult.Remark).ToString, row.Item(enumQueryResult.ModifyBy).ToString,
                                       row.Item(enumQueryResult.ModifyTime).ToString)
            Next

            toolStripStatusLabel3.Text = Me.dgvT3BindData.Rows.Count
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '查找当前用户名
    Private Sub GetUserName()
        Try
            Dim dt As DataTable = DbOperateUtils.GetDataTable("SELECT TOP 1 UserName FROM m_Users_t WHERE UserID='" & SysMessageClass.UseId & "'")
            If dt.Rows.Count > 0 Then
                SysMessageClass.UseName = dt.Rows(0)(0).ToString
            Else
                SysMessageClass.UseName = SysMessageClass.UseId
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EnableControl(ByVal strName As String, Optional ByVal blnEnable As Boolean = True)
        Select Case strName.ToUpper()
            Case "MO"
                txtChangeMO.ReadOnly = Not blnEnable
                txtChangeMO.Text = ""
            Case "LINE"
                txtChangeLine.ReadOnly = Not blnEnable
                txtChangeLine.Text = ""
            Case "DELAY"
                txtChangeDelayNum.ReadOnly = Not blnEnable
                txtChangeDelayNum.Text = ""
                cboChangeDelayUnit.Enabled = blnEnable
                cboChangeDelayUnit.SelectedIndex = IIf(blnEnable, 2, 0)
        End Select
    End Sub
#End Region

End Class