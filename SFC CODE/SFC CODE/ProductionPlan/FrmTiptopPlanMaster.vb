
'--生产计划派单
'--Create by :　马锋
'--Create date :　2016/10/13
'--Update date :  
'--Ver : V01

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports MainFrame

#End Region

Public Class FrmTiptopPlanMaster

#Region "字段"
    Dim _TempDeptID As String

#End Region


#Region "窗体事件"

    Private Sub FrmTiptopPlanMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvMoList.AutoGenerateColumns = False
            Me.dgvMoItemList.AutoGenerateColumns = False
            Me.dgvPlanWorkingHours.Visible = False
            Me.dgvPlanWorkingHours.AutoGenerateColumns = False
            Me.dtpEndDate.Value = Now.AddDays(-1)
            Me.dtpStartDate.Value = Now.AddDays(1)

            LoadDate()
            SetStatus(0)
            Me.cboDept.Text = "ALL"
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub ToolAgain_Click(sender As Object, e As EventArgs) Handles ToolAgain.Click
        Try
            'If (String.IsNullOrEmpty(Me.txtMOId.Text.Trim())) Then
            '    GetMesData.SetMessage(Me.lblMessage, "重新下载工单不能为空", False)
            '    Me.ActiveControl = Me.txtMOId
            '    Return
            'End If

            Dim strSQL As StringBuilder = New StringBuilder
            If txtMOId.Text.Trim <> "" Then
                strSQL.Append(" BEGIN  UPDATE m_TiptopPlanMO_t SET PlanStatus='N' WHERE MOID='" & txtMOId.Text.Trim.ToUpper & "';")
                strSQL.Append(" DELETE FROM m_PlanWorkingHours_t WHERE  ParentMOId='" & txtMOId.Text.Trim.ToUpper & "';")
                strSQL.Append(" DELETE FROM m_TiptopPlan_t WHERE  MOID='" & txtMOId.Text.Trim.ToUpper & "';")
                strSQL.Append(" DELETE FROM m_TiptopPlanItem_t WHERE ParentMOId='" & txtMOId.Text.Trim.ToUpper & "'; END")
                DbOperateUtils.ExecSQL(strSQL.ToString)
                strSQL = New StringBuilder
            End If
            strSQL.AppendLine(" DECLARE @RTVALUE VARCHAR(8), @RTMSG NVARCHAR(128) ")
            strSQL.AppendLine(" EXEC GetAgainTiptopMOPlan @RTVALUE OUTPUT, @RTMSG OUTPUT, '', '', '" & VbCommClass.VbCommClass.UseId & "', '" & Me.txtMOId.Text.Trim.ToUpper & "' ")
            strSQL.AppendLine(" SELECT @RTVALUE, @RTMSG  ")

            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)

            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then

                If (dtTemp.Rows(0).Item(0).ToString = "1") Then
                    GetMesData.SetMessage(Me.lblMessage, "重新下载工单成功", True)
                Else
                    GetMesData.SetMessage(Me.lblMessage, dtTemp.Rows(0).Item(1).ToString, False)
                End If
            End If

            GetMOPlan()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "下载异常", False)
        End Try
    End Sub

    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        Try

            SetStatus(1)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "修改异常", False)
        End Try
    End Sub

    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub ToolCommit_Click(sender As Object, e As EventArgs) Handles ToolCommit.Click
        Try
            Me.dgvMoItemList.CommitEdit(DataGridViewDataErrorContexts.Commit)

            If (MessageBox.Show("你确定修改？", "提示", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then

                If Not (CheckSave()) Then
                    Return
                End If

                Dim strSQL As StringBuilder = New StringBuilder

                Dim strMOID, strDeptId, strLineId, strActualStartDate, strEstimatedDate, strEndTime, strStartTime As String

                strMOID = Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("MOID").Value
                strDeptId = IIf(IsDBNull(Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("DeptId").Value), "", Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("DeptId").Value.ToString)
                strLineId = IIf(IsDBNull(Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("LineId").Value), "", Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("LineId").Value.ToString)
                'strActualStartDate = IIf(IsDBNull(Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("ActualStartDate").Value), "", Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("ActualStartDate").Value.ToString)
                strEstimatedDate = IIf(IsDBNull(Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("EstimatedDate").Value), "", Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("EstimatedDate").Value.ToString)
                strStartTime = IIf(IsDBNull(Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("PlanStartTime").Value), "", Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("PlanStartTime").Value.ToString)
                strEndTime = IIf(IsDBNull(Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("PlanEndTime").Value), "", Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("PlanEndTime").Value.ToString)
                'If String.IsNullOrEmpty(strActualStartDate) Then
                '    strActualStartDate = "NULL"
                'Else
                '    strActualStartDate = "'" + strActualStartDate + "'"
                'End If

                If String.IsNullOrEmpty(strEstimatedDate) Then
                    strEstimatedDate = "NULL"
                Else
                    strEstimatedDate = "'" + strEstimatedDate + "'"
                End If
                'ActualStartDate = " & strActualStartDate & ",
                strSQL.AppendLine(" UPDATE m_TiptopPlan_t SET DeptId = '" & strDeptId & "', LineId = '" & strLineId & "', ")
                strSQL.AppendLine(" EstimatedDate = " & strEstimatedDate & ",PlanEndTime='" & strStartTime & "',PlanStartTime='" & strEndTime & "', UpdateUserId = '" & VbCommClass.VbCommClass.UseId & "', UpdateTime = getdate() WHERE MOID = '" & strMOID & "'")
                DbOperateUtils.ExecSQL(strSQL.ToString)
                Dim strChildMOID, strChildDeptId, strChildLineId, strChildActualStartDate, strChildEstimatedDate, strChildPlanStartime, strChildPlanEndTime As String

                For i As Int16 = 0 To Me.dgvMoItemList.Rows.Count - 1
                    strSQL = New StringBuilder
                    strChildMOID = Me.dgvMoItemList.Rows(i).Cells("CMoId").Value
                    strChildDeptId = IIf(IsDBNull(Me.dgvMoItemList.Rows(i).Cells("CDeptId").Value), "", Me.dgvMoItemList.Rows(i).Cells("CDeptId").Value.ToString)
                    strChildLineId = IIf(IsDBNull(Me.dgvMoItemList.Rows(i).Cells("mtxtLineId").Value), "", Me.dgvMoItemList.Rows(i).Cells("mtxtLineId").Value.ToString)
                    strChildActualStartDate = IIf(IsDBNull(Me.dgvMoItemList.Rows(i).Cells("CActualStartDate").Value), "", Me.dgvMoItemList.Rows(i).Cells("CActualStartDate").Value.ToString)
                    'strChildEstimatedDate = IIf(IsDBNull(Me.dgvMoItemList.Rows(i).Cells("CEstimatedDate").Value), "", Me.dgvMoItemList.Rows(i).Cells("CEstimatedDate").Value.ToString)
                    strChildPlanStartime = IIf(IsDBNull(Me.dgvMoItemList.Rows(i).Cells("ItemPlanStartTime").Value), "", Me.dgvMoItemList.Rows(i).Cells("ItemPlanStartTime").Value.ToString)
                    strChildPlanEndTime = IIf(IsDBNull(Me.dgvMoItemList.Rows(i).Cells("ItemPlanEndTime").Value), "", Me.dgvMoItemList.Rows(i).Cells("ItemPlanEndTime").Value.ToString)

                    If String.IsNullOrEmpty(strChildActualStartDate) Then
                        strChildActualStartDate = "NULL"
                    Else
                        strChildActualStartDate = "'" + strChildActualStartDate + "'"
                    End If

                    'If String.IsNullOrEmpty(strChildEstimatedDate) Then
                    '    strChildEstimatedDate = "NULL"
                    'Else
                    '    strChildEstimatedDate = "'" + strChildEstimatedDate + "'"
                    'End If
                    ', EstimatedDate = " & strChildEstimatedDate & "
                    strSQL.AppendLine(" UPDATE m_TiptopPlanItem_t SET DeptId = '" & strChildDeptId & "', LineId = '" & strChildLineId & "', ")
                    strSQL.AppendLine(" ActualStartDate = " & strChildActualStartDate & ",PlanEndTime='" & strChildPlanEndTime & "',PlanStartTime='" & strChildPlanStartime & "', UpdateUserId = '" & VbCommClass.VbCommClass.UseId & "', UpdateTime = getdate() WHERE MOID = '" & strChildMOID & "'")
                    DbOperateUtils.ExecSQL(strSQL.ToString)
                Next
                SetStatus(0)
                GetMOPlan()
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存异常", False)
        End Try
    End Sub

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        Try
            SetStatus(0)
            GetMOPlan()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "返回异常", False)
        End Try
    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Try
            If CheckQueryParameter(True) Then
                Return
            End If

            GetMOPlan()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub toolCheck_Click(sender As Object, e As EventArgs) Handles toolCheck.Click
        Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "审核异常", False)
        End Try
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Try
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "退出异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub dgvMoList_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMoList.CellEnter
        Try

            GetMesData.SetMessage(Me.lblMessage, "", False)
            If Me.dgvMoList.Rows.Count = 0 OrElse Me.dgvMoList.CurrentRow Is Nothing Then
                Me.dgvMoItemList.DataSource = Nothing
                Me.dgvMoItemList.Rows.Clear()
                Exit Sub
            End If

            GetMOItemPlan(Me.dgvMoList.Rows(Me.dgvMoList.CurrentRow.Index).Cells("MOid").Value.ToString)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询子工单异常", False)
        End Try

    End Sub

    Private Sub mtxtLineId_ButtonCustomClick(sender As Object, e As EventArgs)
        Try

            Dim cell As DataGridViewMaskedTextBoxAdvCell = TryCast(Me.dgvMoItemList.CurrentCell, DataGridViewMaskedTextBoxAdvCell)

            If cell IsNot Nothing Then
                Dim ec As DataGridViewMaskedTextBoxAdvEditingControl = TryCast(cell.DataGridView.EditingControl, DataGridViewMaskedTextBoxAdvEditingControl)

                If ec IsNot Nothing Then
                    'Dim frmLineQuery As New FrmLineQuery(ec)
                    ''frmLineQuery.ShowDialog()
                    ''update by hgd 2017-03-31  返回部门代码
                    'If frmLineQuery.ShowDialog() = Windows.Forms.DialogResult.Yes Then

                    '    _TempDeptID = frmLineQuery.DialogDeptID

                    'End If
                End If

                Me.dgvMoItemList.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub dgvMoItemList_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMoItemList.CellValueChanged
        Try
            If (Me.dgvMoItemList.RowCount = 0) Then
                If (Me.dgvMoItemList.CurrentRow Is Nothing Or Me.dgvMoItemList.CurrentCell Is Nothing) Then
                    Return
                End If
            End If

            If (e.ColumnIndex = 7) Then
                Dim strLineId, strSQL As String

                strLineId = Me.dgvMoItemList.Rows(e.RowIndex).Cells("mtxtLineId").Value

                If (String.IsNullOrEmpty(strLineId)) Then
                    Me.dgvMoItemList.Rows(e.RowIndex).Cells("CDeptId").Value = ""
                Else
                    If Not _TempDeptID Is Nothing Then
                        Me.dgvMoItemList.Rows(e.RowIndex).Cells("CDeptId").Value = _TempDeptID
                        _TempDeptID = Nothing
                    End If
                  


                    'strSQL = "SELECT deptid FROM deptline_t WHERE lineid = '" & strLineId & "'"

                    'Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(strSQL)

                    'If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                    '    Me.dgvMoItemList.Rows(e.RowIndex).Cells("CDeptId").Value = dtTemp.Rows(0).Item(0).ToString
                    'Else
                    '    Me.dgvMoItemList.Rows(e.RowIndex).Cells("mtxtLineId").Value = ""
                    'End If
                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "获取产线对应部门失败", False)
        End Try
    End Sub

#End Region

#Region "方法"

    Private Sub LoadDate()
        Try
            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT djc, dqc FROM m_dept_t WHERE Factoryid='" & VbCommClass.VbCommClass.Factory & "' AND Profitcenter = '" & VbCommClass.VbCommClass.profitcenter & "' AND usey = 'Y'")

            If Not dtTemp Is Nothing And dtTemp.Rows.Count > 0 Then
                Dim drTemp As DataRow
                drTemp = dtTemp.NewRow
                drTemp(0) = "ALL"
                drTemp(1) = "ALL"
                dtTemp.Rows.Add(drTemp)
            End If

            Me.cboDept.DisplayMember = "dqc"
            Me.cboDept.ValueMember = "djc"
            Me.cboDept.DataSource = dtTemp

            Dim dt As DataTable = New DataTable("dt")
            dt.Columns.Add("dtText")
            dt.Columns.Add("dtValue")

            Dim drTypeTemp As DataRow
            drTypeTemp = dt.NewRow
            drTypeTemp(0) = "单根"
            drTypeTemp(1) = "0"
            dt.Rows.Add(drTypeTemp)

            drTypeTemp = dt.NewRow
            drTypeTemp(0) = "成套"
            drTypeTemp(1) = "1"
            dt.Rows.Add(drTypeTemp)

            drTypeTemp = dt.NewRow
            drTypeTemp(0) = "ALL"
            drTypeTemp(1) = "2"
            dt.Rows.Add(drTypeTemp)

            cboQueryType.DataSource = dt
            cboQueryType.DisplayMember = "dtText"
            cboQueryType.ValueMember = "dtValue"

            cboQueryType.SelectedValue = "2"

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub SetStatus(ByVal statusFlag As Int16)
        Select Case (statusFlag)
            Case 0
                Me.ToolAgain.Enabled = True
                Me.ToolCommit.Enabled = True
                Me.ToolBack.Enabled = False
                Me.ToolQuery.Enabled = True
                Me.toolCheck.Enabled = True

            Case 1
                Me.ToolAgain.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolBack.Enabled = False
                Me.ToolQuery.Enabled = True
                Me.toolCheck.Enabled = True

                'Me.dgvMoList.DataSource = Nothing
                'Me.dgvMoItemList.DataSource = Nothing

                'Me.dgvMoList.Rows.Clear()
                'Me.dgvMoItemList.Rows.Clear()
        End Select
    End Sub

    Private Function CheckQueryParameter(ByVal MessageFlag As Boolean) As Boolean
        If (dtpStartDate.Value < dtpEndDate.Value) Then
            If (MessageFlag) Then
                MsgBox("查询结束时间不能大于开始时间！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
            End If
            Return True
        End If

        Return False
    End Function

    Private Sub GetMOPlan()
        Try
            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine(" SELECT   TiptopPlanId, MOid, PartId, m_TiptopPlan_t.Description, Specification, Quantity, CustId, Remark, DeptId, LineId, LeaderId, ")
            strSQL.AppendLine(" ActualStartDate, EstimatedDate, ReleaseDay, InNumberDays, BelongsDeptId, StorageQuantity, LocationId, ")
            strSQL.AppendLine(" StandardWorkingHours, UpdateUserId, UpdateTime, PlanStartTime, PlanEndTime, PlanRework, PARAMETER_NAME AS PlanStatusFlagText  ")
            strSQL.AppendLine(" FROM m_TiptopPlan_t LEFT JOIN m_SettingParameter_t ON m_SettingParameter_t.PARAMETER_VALUE=m_TiptopPlan_t.StatusFlag AND m_SettingParameter_t.PARAMETER_CODE = 'PlanStatusFlag' ")
            strSQL.AppendLine(" WHERE Factoryid = '" & VbCommClass.VbCommClass.Factory & "' AND ISNULL(Profitcenter, '') = '" & VbCommClass.VbCommClass.profitcenter & "' ")

            If Not String.IsNullOrEmpty(Me.txtMOId.Text.Trim()) Then
                strSQL.AppendLine(" AND MOID LIKE '%" & Me.txtMOId.Text.Trim & "%' ")
            End If

            If Not String.IsNullOrEmpty(Me.txtPartId.Text.Trim()) Then
                strSQL.AppendLine(" AND PartId LIKE '%" & Me.txtPartId.Text.Trim & "%' ")
            End If
            Dim lines As String = Nothing

            For Each sLine As String In txtLineId.Text.Trim.Split(CChar(vbNewLine))
                If Not String.IsNullOrEmpty(sLine) Then

                    lines &= "'" & sLine.ToUpper.Trim & "'" & ","

                End If
            Next
            If Not String.IsNullOrEmpty(Me.txtLineId.Text.Trim()) Then
                lines = lines.Trim(CChar(","))
                strSQL.AppendLine(" AND LineId in (" & lines & ")")
            End If

            If (Me.cboDept.SelectedValue <> "ALL") Then
                strSQL.AppendLine(" AND LineId IN (SELECT lineid FROM DEPTLINE_T WHERE usey='Y' AND deptid ='" & Me.cboDept.SelectedValue & "' )")
            End If

            If Me.cboQueryType.SelectedValue = "0" Then
                strSQL.AppendLine(" AND m_TiptopPlan_t.MOID NOT IN (SELECT ParentMOId FROM m_TiptopPlanItem_t) ")
            ElseIf Me.cboQueryType.SelectedValue = "1" Then
                strSQL.AppendLine(" AND m_TiptopPlan_t.MOID IN (SELECT ParentMOId FROM m_TiptopPlanItem_t) ")
            End If

            strSQL.AppendLine(" AND m_TiptopPlan_t.CreateTime between cast('" & Me.dtpEndDate.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime) and cast('" & Me.dtpStartDate.Value.ToString("yyyy/MM/dd") + " 23:59:59" & "' as datetime) ")
            Me.dgvMoItemList.DataSource = Nothing
            Me.dgvPlanWorkingHours.DataSource = Nothing
            Me.dgvMoList.DataSource = DbOperateUtils.GetDataTable(strSQL.ToString)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub GetMOItemPlan(ByVal strMOId As String)
        Try
            Dim strSQL As StringBuilder = New StringBuilder

            strSQL.AppendLine(" SELECT   TiptopPlanItemId, Moid, PartId, m_TiptopPlanItem_t.Description, Specification, Quantity, CustId, Remark, DeptId, LineId, LeaderId, ")
            strSQL.AppendLine(" ActualStartDate, EstimatedDate, ReleaseDay, InNumberDays, StorageQuantity, LocationId, StandardWorkingHours, ")
            strSQL.AppendLine(" UpdateUserId, UpdateTime, PlanStartTime, PlanEndTime, PlanRework, PARAMETER_NAME AS PlanStatusFlagText ")
            strSQL.AppendLine(" FROM m_TiptopPlanItem_t LEFT JOIN m_SettingParameter_t ON m_SettingParameter_t.PARAMETER_VALUE=m_TiptopPlanItem_t.StatusFlag AND m_SettingParameter_t.PARAMETER_CODE = 'PlanStatusFlag' ")
            strSQL.AppendLine(" WHERE ParentMoid = '" & strMOId & "' ")

            If Not String.IsNullOrEmpty(Me.txtChildLineId.Text.Trim()) Then
                strSQL.AppendLine(" AND LineId LIKE '%" & Me.txtChildLineId.Text.Trim & "%' ")
            End If

            strSQL.AppendLine(" ORDER BY Moid ASC ")

            Me.dgvMoItemList.DataSource = DbOperateUtils.GetDataTable(strSQL.ToString)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub GetMOItemPlanWorkingHours(ByVal strMOId As String)
        Try
            Dim strSQL As StringBuilder = New StringBuilder

            strSQL.AppendLine(" SELECT   PlanWorkingHoursId, WorkingHours, SWorkingHours, DeptId, LineId, PlanStartTime, PlanEndTime, CASE WHEN StatusFlag='0' THEN N'生产中' ELSE N'完成' END StatusFlagText, CreateTime ")
            strSQL.AppendLine(" FROM   m_PlanWorkingHours_t ")
            strSQL.AppendLine(" WHERE Moid = '" & strMOId & "' ORDER BY CreateTime DESC ")

            Me.dgvPlanWorkingHours.DataSource = DbOperateUtils.GetDataTable(strSQL.ToString)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Function CheckSave() As Boolean
        Try

            If (Me.dgvMoItemList.RowCount > 0) Then
                Dim strLineId, strDeptId As String

                For i As Integer = 0 To Me.dgvMoItemList.RowCount - 1
                    strLineId = IIf(IsDBNull(Me.dgvMoItemList.Rows(i).Cells("mtxtLineId").Value), "", Me.dgvMoItemList.Rows(i).Cells("mtxtLineId").Value)
                    strDeptId = IIf(IsDBNull(Me.dgvMoItemList.Rows(i).Cells("CDeptId").Value), "", Me.dgvMoItemList.Rows(i).Cells("CDeptId").Value)

                    If (Not String.IsNullOrEmpty(strLineId)) Then
                        If (String.IsNullOrEmpty(strDeptId)) Then
                            Return False
                            Exit For
                        End If
                    End If
                Next

            End If

            Return True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常", False)
            Return False
        End Try
    End Function

#End Region

    Private Sub dgvMoItemList_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvMoItemList.EditingControlShowing
        Try
            If Me.dgvMoItemList.CurrentCellAddress.X = 7 Then
                Dim ec As DataGridViewMaskedTextBoxAdvEditingControl = TryCast(e.Control, DataGridViewMaskedTextBoxAdvEditingControl)
                ec.MaskedTextBox.ReadOnly = True
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

    Private Sub dgvMoItemList_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMoItemList.CellEnter
        Try

            GetMesData.SetMessage(Me.lblMessage, "", False)
            If Me.dgvMoItemList.Rows.Count = 0 OrElse Me.dgvMoItemList.CurrentRow Is Nothing Then
                Me.dgvPlanWorkingHours.DataSource = Nothing
                Me.dgvPlanWorkingHours.Rows.Clear()
                Exit Sub
            End If

            GetMOItemPlanWorkingHours(Me.dgvMoItemList.Rows(Me.dgvMoItemList.CurrentRow.Index).Cells("CMOid").Value.ToString)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询子工单异常", False)
        End Try
    End Sub
End Class