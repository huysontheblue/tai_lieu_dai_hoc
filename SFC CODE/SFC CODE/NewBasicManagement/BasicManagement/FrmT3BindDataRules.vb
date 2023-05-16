Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Text.RegularExpressions

Public Class FrmT3BindDataRules
    Private toolStatus As EnumTools = EnumTools.Initial
    Private blnEdit As Boolean = False

#Region "枚举类型"

    '枚举：操作状态（新增、修改、修改客户料号、初始）
    Private Enum EnumTools
        Initial
        Add
        Edit
    End Enum

    ''' <summary>
    ''' 设置方式及其有效程度的优先级
    ''' </summary>
    Private Enum enumPriority
        ''' <summary>
        ''' 未设置
        ''' </summary>
        NotSet
        MoLine
        Mo
        PartLine
        Part
        Line
    End Enum

    Private Enum enumQueryResult
        Items
        Priority
        PartID
        RealMoid
        ReallineID
        NeedSend
        DelaySend
        DelaySendNum
        DelaySendUnit
        DelaySendDes
        SendMoid
        SendlineID
        Remark
        ModifyBy
        ModifyTime
        UpdateSQL
        UpdateSQLD
    End Enum

#End Region

#Region "触发事件"
    '

    Private Sub FrmT3BindDataRules_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim intRight As Integer = CInt(DbOperateUtils.GetDataTable("select ISNULL(sum(case b.tkey when 'M02023002_' then 1 when 'M02023004_' then 2 else 0 end),0) from m_Users_t a  join m_userright_t b on a.userid=b.userid where b.tkey in('M02023002_','M02023004_') and a.userid='" & SysMessageClass.UseId & "'").Rows(0)(0).ToString())
            ToolChangeData.Enabled = intRight >= 2
            blnEdit = intRight Mod 2 = 1
            Initialization()
            EnableControls()
            LoadDataToDatagridview("", 100)
        Catch ex As Exception
            MessageUtils.ShowInformation("系统异常，请联系值班人员处理！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmT3BindDataRules", "FrmT3BindDataRules_Load", "sys")
        End Try
    End Sub

    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        toolStatus = EnumTools.Add
        EnableControls()
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If dgvT3BindDataRules.RowCount < 1 OrElse dgvT3BindDataRules.CurrentRow.Index = -1 Then Exit Sub
        If dgvT3BindDataRules.CurrentRow.Cells(enumQueryResult.Priority).Value.ToString().Split(".")(0) = 99 Then
            MessageUtils.ShowInformation("通用配置，不允许编辑！")
            Exit Sub
        End If
        Try
            toolStatus = EnumTools.Edit
            EnableControls()
            With dgvT3BindDataRules.CurrentRow.Cells
                txtItems.Text = .Item(enumQueryResult.Items).Value
                cboPriority.Text = .Item(enumQueryResult.Priority).Value
                PriorityChange()
                txtPartID.Text = .Item(enumQueryResult.PartID).Value
                txtRealMoid.Text = .Item(enumQueryResult.RealMoid).Value
                txtSendMoid.Text = .Item(enumQueryResult.SendMoid).Value
                txtRealLineID.Text = .Item(enumQueryResult.ReallineID).Value
                txtSendLineID.Text = .Item(enumQueryResult.SendlineID).Value
                chkNeedSend.Checked = (.Item(enumQueryResult.NeedSend).Value.ToString().Split(".")(0) = 1)
                NeedSendChange()
                chkDelaySend.Checked = (.Item(enumQueryResult.DelaySend).Value.ToString().Split(".")(0) = 1)
                EnableControl("DelaySend", chkDelaySend.Checked)
                txtDelayTestTimeNum.Text = .Item(enumQueryResult.DelaySendNum).Value
                cboDelayTestTimeUnit.Text = .Item(enumQueryResult.DelaySendUnit).Value
                txtRemark.Text = .Item(enumQueryResult.Remark).Value
            End With
        Catch ex As Exception
            MessageUtils.ShowInformation("系统异常，请联系值班人员处理！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmT3BindDataRules", "Edit_Click", "sys")
        End Try
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim ds As DataSet
        Try
            Dim ePriority As enumPriority = cboPriority.SelectedIndex
            Dim strPartID As String = txtPartID.Text.Trim()
            Dim strRealMoid As String = txtRealMoid.Text.Trim()
            Dim strRealLineID As String = txtRealLineID.Text.Trim()
            Dim strSendMoid As String = IIf(txtSendMoid.Text.Trim() = "", txtRealMoid.Text.Trim(), txtSendMoid.Text.Trim())
            Dim strSendLineID As String = IIf(txtSendLineID.Text.Trim() = "", txtRealLineID.Text.Trim(), txtSendLineID.Text.Trim())
            Dim strDelayTestTimeNum As String = txtDelayTestTimeNum.Text.Trim()
            Dim strDelayTestTimeUnit As String = cboDelayTestTimeUnit.Text.Trim()
            Dim strRemark As String = txtRemark.Text.Trim()
            Dim strUpdateSQL As String = ""
            Dim strUpdateSQLD As String = ""

            If cboPriority.SelectedIndex = 0 Then
                MessageUtils.ShowInformation("请先选择优先级！") : Exit Sub
            ElseIf ePriority = enumPriority.MoLine AndAlso (strRealMoid = "" OrElse strRealLineID = "") Then
                MessageUtils.ShowInformation("生产工单和生产线别不能为空！") : Exit Sub
            ElseIf ePriority = enumPriority.Mo AndAlso strRealMoid = "" Then
                MessageUtils.ShowInformation("生产工单不能为空！") : Exit Sub
            ElseIf ePriority = enumPriority.PartLine AndAlso (strPartID = "" OrElse strRealLineID = "") Then
                MessageUtils.ShowInformation("生产料号和生产线别不能为空！") : Exit Sub
            ElseIf ePriority = enumPriority.Part AndAlso strPartID = "" Then
                MessageUtils.ShowInformation("生产料号不能为空！") : Exit Sub
            ElseIf ePriority = enumPriority.Line AndAlso strRealLineID = "" Then
                MessageUtils.ShowInformation("生产线别不能为空！") : Exit Sub
            ElseIf chkDelaySend.Checked Then
                If strDelayTestTimeNum = "" Then
                    MessageUtils.ShowInformation("延迟发送的时间不能为空，且必须为数值！") : Exit Sub
                ElseIf strDelayTestTimeUnit = "" Then
                    MessageUtils.ShowInformation("延迟发送时间的单位不能为空！") : Exit Sub
                End If
            End If

            Dim strPriority As String = cboPriority.SelectedIndex
            Dim strSql As String = "SELECT TOP 1 items FROM m_CableInfoBindConfig_t WHERE Priority=" + strPriority + " AND RealMoid='" + strRealMoid + "' AND PartID='" + strPartID + "' AND RealLineID='" + strRealLineID + "'"
            ds = New DataSet
            ds = DbOperateUtils.GetDataSet(strSql)
            If ds.Tables(0).Rows.Count >= 1 AndAlso (toolStatus = EnumTools.Add OrElse ds.Tables(0).Rows(0)(0) <> txtItems.Text) Then
                MessageUtils.ShowInformation("相同优先级、料号、工单、线别的配置已存在，请确认！") : Exit Sub
            End If

            If SysMessageClass.UseName = "" Then GetUserName()
            If (ePriority = enumPriority.Mo OrElse ePriority = enumPriority.MoLine) AndAlso strRealMoid <> strSendMoid AndAlso strSendMoid <> "" Then
                strUpdateSQL += ",MOID=''" + strSendMoid + "''"
            End If
            If ePriority <> enumPriority.Mo AndAlso ePriority <> enumPriority.Part AndAlso strRealLineID <> strSendLineID AndAlso strSendLineID <> "" Then
                strUpdateSQL += ",LineID=''" + strSendLineID + "''"
            End If
            If chkNeedSend.Checked Then
                strUpdateSQL += ",state=''C''"
                If chkDelaySend.Checked Then
                    strUpdateSQL += ",TestTime=DATEADD(" + strDelayTestTimeUnit + "," + strDelayTestTimeNum + ",RealTestTime)"
                End If
            Else
                strUpdateSQL += ",state=''D''"
            End If
            strUpdateSQLD += strUpdateSQL

            Select Case toolStatus
                Case EnumTools.Add
                    strSql = "INSERT INTO m_CableInfoBindConfig_t(Priority,RealMoid,SendMoid,PartID,RealLineID," _
                        & "SendLineID,NeedSend,DelaySend,DelayTestTimeNum,DelayTestTimeUnit,Remark,UpdateSQL,UpdateSQLD,ModifyBy,ModifyByName,ModifyTime) " _
                        & "VALUES(" + strPriority + ",'" + strRealMoid + "','" + strSendMoid + "','" + strPartID + "','" + strRealLineID + "','" _
                        & strSendLineID + "'," + IIf(chkNeedSend.Checked, "1", "0") + "," + IIf(chkDelaySend.Checked, "1," + strDelayTestTimeNum + ",'" _
                        & strDelayTestTimeUnit + "'", "0,NULL,NULL") + ",N'" + strRemark + "',N'" + strUpdateSQL + "',N'" + strUpdateSQLD + "','" _
                        & SysMessageClass.UseId + "',N'" & SysMessageClass.UseName & "',GETDATE())"

                Case EnumTools.Edit
                    strSql = "UPDATE m_CableInfoBindConfig_t SET Priority=" + strPriority + ",RealMoid='" + strRealMoid + "'," _
                        & "SendMoid='" + strSendMoid + "',PartID='" + strPartID + "',RealLineID='" + strRealLineID + "',SendLineID='" + strSendLineID + "'," _
                        & "NeedSend=" + IIf(chkNeedSend.Checked, "1", "0") + ",DelaySend=" + IIf(chkDelaySend.Checked,
                         "1,DelayTestTimeNum=" + strDelayTestTimeNum + ",DelayTestTimeUnit='" + strDelayTestTimeUnit + "'",
                         "0,DelayTestTimeNum=NULL,DelayTestTimeUnit=NULL") + ",Remark=N'" + strRemark + "',UpdateSQL=N'" + strUpdateSQL + "'," _
                        & "UpdateSQLD=N'" + strUpdateSQLD + "',ModifyBy='" + SysMessageClass.UseId + "',ModifyByName=N'" & SysMessageClass.UseName & "'," _
                        & "ModifyTime=GETDATE() WHERE items=" + txtItems.Text
            End Select
            DbOperateUtils.ExecSQL(strSql)
            MessageUtils.ShowInformation("保存成功！")
            toolStatus = EnumTools.Initial
            Initialization()
            EnableControls()
            LoadDataToDatagridview("", 100)
        Catch ex As Exception
            MessageUtils.ShowInformation("保存失败！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmT3BindDataRules", "Save_Click", "sys")
        Finally
            If Not ds Is Nothing Then ds.Clear() : ds.Dispose()
        End Try

    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        toolStatus = EnumTools.Initial
        Initialization()
        EnableControls()
    End Sub

    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        If dgvT3BindDataRules.RowCount < 1 OrElse dgvT3BindDataRules.CurrentRow.Index = -1 Then Exit Sub
        If dgvT3BindDataRules.CurrentRow.Cells(enumQueryResult.Priority).Value.ToString().Split(".")(0) = 99 Then
            MessageUtils.ShowInformation("通用配置，不允许删除！")
            Exit Sub
        End If
        If MessageUtils.ShowConfirm("你确定要删除该配置信息吗？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            Try
                Dim strSql As String = "DELETE FROM m_CableInfoBindConfig_t WHERE items=" & dgvT3BindDataRules.CurrentRow.Cells(enumQueryResult.Items).Value
                DbOperateUtils.ExecSQL(strSql)
                MessageUtils.ShowInformation("删除成功！")
                LoadDataToDatagridview(GetSqlWhere, 100)
            Catch ex As Exception
                MessageUtils.ShowInformation("删除失败！")
                SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmT3BindDataRules", "Delete_Click", "sys")
            End Try
        End If
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            LoadDataToDatagridview(GetSqlWhere, 1000)
        Catch ex As Exception
            MessageUtils.ShowInformation("系统异常，请联系值班人员处理！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmT3BindDataRules", "Query_Click", "sys")
        End Try
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub cboPriority_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPriority.SelectedIndexChanged
        PriorityChange()
    End Sub

    Private Sub chkNeedSend_CheckedChanged(sender As Object, e As EventArgs) Handles chkNeedSend.CheckedChanged
        NeedSendChange()
    End Sub

    Private Sub chkDelaySend_CheckedChanged(sender As Object, e As EventArgs) Handles chkDelaySend.CheckedChanged
        EnableControl("DelaySend", chkDelaySend.Checked)
    End Sub

    Private Sub txtDelayTestTimeNum_TextChanged(sender As Object, e As EventArgs) Handles txtDelayTestTimeNum.TextChanged
        txtDelayTestTimeNum.Text = Regex.Replace(txtDelayTestTimeNum.Text, "[^0-9]", "")
    End Sub

    Private Sub txtRealMoid_KeyPress(sender As Object, e As KeyEventArgs) Handles txtRealMoid.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRealMoid_Leave(sender, New EventArgs)
        End If
    End Sub

    Private Sub txtRealMoid_Leave(sender As Object, e As EventArgs) Handles txtRealMoid.Leave
        Try
            Dim dt As DataTable = DbOperateUtils.GetDataTable("SELECT TOP 1 PartID FROM m_Mainmo_t WHERE MOID='" & txtRealMoid.Text & "'")
            If dt.Rows.Count > 0 Then
                txtPartID.Text = dt.Rows(0)(0).ToString
            Else
                txtPartID.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtRealMoid_TextChanged(sender As Object, e As EventArgs) Handles txtRealMoid.TextChanged
        txtRealMoid.Text = txtRealMoid.Text.Trim
        If txtRealMoid.Text = "" Then Exit Sub
        txtSendMoid.Text = txtRealMoid.Text
    End Sub

    Private Sub txtRealLineID_TextChanged(sender As Object, e As EventArgs) Handles txtRealLineID.TextChanged
        txtRealLineID.Text = txtRealLineID.Text.Trim
        If txtRealLineID.Text = "" Then Exit Sub
        txtSendLineID.Text = txtRealLineID.Text
    End Sub

    Private Sub ToolChangeData_Click(sender As Object, e As EventArgs) Handles ToolChangeData.Click
        Dim fr As FrmT3BindDataRemedy = New FrmT3BindDataRemedy
        fr.ShowDialog()
    End Sub

#End Region

#Region "函数、方法"
    '控件值初始化
    Private Sub Initialization()
        cboPriority.SelectedIndex = 0
        PriorityChange()
        chkNeedSend.Checked = True
        NeedSendChange()
        txtPartID.Text = ""
        txtRemark.Text = ""
    End Sub

    '控件可编辑性初始化
    Private Sub EnableControls()
        Select Case toolStatus
            Case EnumTools.Initial
                toolAdd.Enabled = blnEdit
                toolEdit.Enabled = blnEdit
                toolDelete.Enabled = True
                toolSave.Enabled = False
                toolBack.Enabled = False
                toolQuery.Enabled = True
                dgvT3BindDataRules.Enabled = True
            Case EnumTools.Add, EnumTools.Edit
                toolAdd.Enabled = False
                toolEdit.Enabled = False
                toolDelete.Enabled = False
                toolSave.Enabled = True
                toolBack.Enabled = True
                toolQuery.Enabled = False
                dgvT3BindDataRules.Enabled = False
        End Select
    End Sub

    '查询条件
    Private Function GetSqlWhere() As String
        Dim strSql As String = ""
        If cboPriority.Text.Trim <> "" Then
            strSql = strSql & " and Priority IN(" & cboPriority.Text.Split(".")(0) + ",99)"
        End If
        If txtPartID.Text.Trim <> "" Then
            strSql = strSql & " and PartID like '%" & txtPartID.Text.Trim & "%'"
        End If
        If txtRealMoid.Text.Trim <> "" Then
            strSql = strSql & " and RealMoid like '%" & txtRealMoid.Text.Split(".")(0) & "%'"
        End If
        If txtRealLineID.Text.Trim <> "" Then
            strSql = strSql & " and RealLineID like '%" & txtRealLineID.Text.Split(".")(0) & "%'"
        End If
        Return strSql
    End Function

    ''' <summary>
    ''' 查询结果绑定
    ''' </summary>
    ''' <param name="SqlWhere">查询条件</param>
    ''' <param name="RowNum">查询笔数</param>
    ''' <remarks></remarks>
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String, ByVal RowNum As Integer)
        Try
            Dim strSql As String = "SELECT TOP " + RowNum.ToString + " Items,CASE Priority "
            For Each item As String In cboPriority.Items
                item = item.Trim
                If item <> "" AndAlso item.Split(".").Length > 1 Then
                    strSql += "WHEN " + item.Split(".")(0) + " THEN N'" + item + "' "
                End If
            Next
            strSql += "WHEN 99 THEN N'99.默认' ELSE '' END  Priority," _
                                   & "ISNULL(PartID,'ALL') PartID,ISNULL(RealMoid,'ALL') RealMoid," _
                                   & "ISNULL(ReallineID,'ALL')ReallineID,CASE NeedSend WHEN 0 THEN '0.NO' ELSE '1.YES' END NeedSend," _
                                   & "CASE DelaySend WHEN 0 THEN '0.NO' ELSE '1.YES' END DelaySend,DelayTestTimeNum DelaySendNum," _
                                   & "DelayTestTimeUnit DelaySendUnit,CAST(DelayTestTimeNum AS VARCHAR(10))+' '+ DelayTestTimeUnit DelaySendDes," _
                                   & "ISNULL(SendMoid,'ALL') SendMoid,ISNULL(SendlineID,'ALL')SendlineID,Remark," _
                                   & "CAST(ModifyBy AS NVARCHAR(100))+'/'+CAST(ModifyByName AS NVARCHAR(100)) AS ModifyBy," _
                                   & "CONVERT(VARCHAR(16),ModifyTime,21) AS ModifyTime,UpdateSQL,UpdateSQLD" _
                                   & " FROM m_CableInfoBindConfig_t WHERE 1=1 " & SqlWhere & " ORDER BY ModifyTime DESC"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

            dgvT3BindDataRules.Rows.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim row As DataRow = dt.Rows(i)
                dgvT3BindDataRules.Rows.Add(row.Item(enumQueryResult.Items).ToString, row.Item(enumQueryResult.Priority).ToString,
                                            row.Item(enumQueryResult.PartID).ToString, row.Item(enumQueryResult.RealMoid).ToString,
                                            row.Item(enumQueryResult.ReallineID).ToString, row.Item(enumQueryResult.NeedSend).ToString,
                                            row.Item(enumQueryResult.DelaySend).ToString, row.Item(enumQueryResult.DelaySendNum).ToString,
                                            row.Item(enumQueryResult.DelaySendUnit).ToString, row.Item(enumQueryResult.DelaySendDes).ToString,
                                            row.Item(enumQueryResult.SendMoid).ToString, row.Item(enumQueryResult.SendlineID).ToString,
                                            row.Item(enumQueryResult.Remark).ToString, row.Item(enumQueryResult.ModifyBy).ToString,
                                            row.Item(enumQueryResult.ModifyTime).ToString, row.Item(enumQueryResult.UpdateSQL).ToString,
                                            row.Item(enumQueryResult.UpdateSQLD).ToString)
            Next

            toolStripStatusLabel3.Text = Me.dgvT3BindDataRules.Rows.Count
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

    Private Sub PriorityChange()
        Dim priority As enumPriority = cboPriority.SelectedIndex
        Select Case priority
            Case enumPriority.MoLine
                EnableControl("PART", False)
                EnableControl("MO", True)
                EnableControl("LINE", True)
            Case enumPriority.Mo
                EnableControl("PART", False)
                EnableControl("MO", True)
                EnableControl("LINE", False)
            Case enumPriority.PartLine
                EnableControl("PART", True)
                EnableControl("MO", False)
                EnableControl("LINE", True)
            Case enumPriority.Part
                EnableControl("PART", True)
                EnableControl("MO", False)
                EnableControl("LINE", False)
            Case enumPriority.Line
                EnableControl("PART", False)
                EnableControl("MO", False)
                EnableControl("LINE", True)
            Case Else
                EnableControl("PART", True)
                EnableControl("MO", True)
                EnableControl("LINE", True)
        End Select
    End Sub

    Private Sub NeedSendChange()
        chkDelaySend.Checked = False
        chkDelaySend.Enabled = chkNeedSend.Checked
        EnableControl("DelaySend", chkDelaySend.Checked)
    End Sub

    Private Sub EnableControl(ByVal strName As String, Optional ByVal blnEnable As Boolean = True)
        Select Case strName.ToUpper()
            Case "PART"
                txtPartID.ReadOnly = Not blnEnable
                txtPartID.Text = IIf(blnEnable, txtPartID.Text, "")
            Case "MO"
                txtRealMoid.ReadOnly = Not blnEnable
                txtRealMoid.Text = ""
                txtSendMoid.ReadOnly = Not blnEnable
                txtSendMoid.Text = ""
            Case "LINE"
                txtRealLineID.ReadOnly = Not blnEnable
                txtRealLineID.Text = ""
                txtSendLineID.ReadOnly = Not blnEnable
                txtSendLineID.Text = ""
            Case "DELAYSEND"
                txtDelayTestTimeNum.ReadOnly = Not blnEnable
                txtDelayTestTimeNum.Text = ""
                cboDelayTestTimeUnit.Enabled = blnEnable
                cboDelayTestTimeUnit.SelectedIndex = IIf(blnEnable, 1, 0)
        End Select
    End Sub
#End Region

End Class