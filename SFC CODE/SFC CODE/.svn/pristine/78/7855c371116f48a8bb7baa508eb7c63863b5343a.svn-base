Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmSetMO

    Private m_ActionFlag As Integer = 0
    Private m_blnProductiveEditSave As Boolean = False
    Private m_blnSupportEditSave As Boolean = False
    Private m_blnLossEditSave As Boolean = False

    Private Enum enumdgvMOSumInfo
        MOID '  工单编号
        LineID '        生产线别
        WorkShift '        班别
        StartTime '        开始日期
        EndTime '        结束时间
        MOQty '        工单数量
        TotalOutPut '        总产出
        CurrentShiftOutPut '        当前班别产出
        TotalNGQty '        总不良
        CurrentShiftNGQty '        当前班别不良
        TotalLossHours '总损失工时(h)
        CurrentShiftLossHours '        当前班别损失工时
        TotalSupportHours '总支援工时(h)
        CurrentShiftSupportHours '当前班别支援工时(h)
    End Enum

    Private Enum enumdgvProductiveDetail
        MOID = 0 '工单编号
        LineID '生产线别
        WorkShift '班别
        OutQty '生产数量
        NGQty '不良数量
        ProductTime '生产时间
        UserID '维护人员
        CreateTime '维护时间
        UpdatedTime '修改时间
    End Enum

    Private Enum enumdgvSupport
        MOID '工单编号
        LineID '生产线别
        WorkShift '班别
        Status '状态0-待审核 ,1-已审核
        ChangedHours '支援工时
        ChangedReason '原因
        RelatedDeptid '支援部门
        UserID '维护人员
        AuditUserID '审核人员
        CreateTime '维护时间
        UpdatedTime '修改时间
        AuditTime '审核时间
    End Enum

    Private Enum enumdgvLoss
        moid  '工单编号
        lineid '生产线别
        workshift '班别
        Status '状态
        ChangedHours '损失工时
        ChangedReason '原因
        RelatedDeptid
        UserID '维护人员
        AuditUserID '审核人员
        CreateTime '维护时间
        UpdatedTime '修改时间
        AuditTime '审核时间
    End Enum

    Private Enum enumActionFlag
        Load = 0
        NewAdd = 1
        ClickedEdit = 2
        ProductiveSave = 3
        LossAudit = 4
        SupportAudit = 5
        ClickedToolProductive = 6
        ClickedToolLoss = 7
        ClickedToolSupport = 8
    End Enum

    Private Enum enumSumStatus
        WaitAudit '0-待审核
        AlreadyAudit '1-已审核
    End Enum

    Private Enum enumMOSumType
        Productive = 0 ' 产能维护
        LossTime  '1 
        SupportTime '2-支援工时
    End Enum

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim UserDg As DataTable
        If ColComboBox.Name = "CboLossDept" OrElse ColComboBox.Name = "CboSupportDept" Then
            UserDg = DbOperateUtils.GetDataTable("SELECT deptid,dqc from  m_Dept_t where factoryid='" & VbCommClass.VbCommClass.Factory & "' ")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "dqc"
            ColComboBox.ValueMember = "deptid"
        ElseIf ColComboBox.Name = "CobFactory" Then
            UserDg = DbOperateUtils.GetDataTable("Select factoryid,shortname from m_Dcompany_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "shortname"
            ColComboBox.ValueMember = "factoryid"
        End If
    End Sub

    Private Sub ToolCheck_Click(sender As Object, e As EventArgs) Handles ToolCheck.Click
        Dim lsSQL As String = String.Empty
        Try
            Select Case m_ActionFlag
                Case enumActionFlag.LossAudit, enumActionFlag.ClickedToolLoss
                    If Me.dgvLoss.CurrentRow Is Nothing Then Exit Sub
                    lsSQL = " UPDATE m_MoProductDetail_t  SET status='" & enumSumStatus.AlreadyAudit & "'" & _
                            ", AuditUserID='" & SysMessageClass.UseId.ToLower & "',AuditTime=getdate()" & _
                            " WHERE moid ='" & Me.TxtMoNo.Text.Trim() & "' AND " & _
                            " lineid='" & Me.txtLineID.Text.Trim() & "' AND workshift='" & Me.CboWorkShift.Text & "' " & _
                            " AND type ='" & enumMOSumType.LossTime & "'" & _
                            " AND status='" & enumSumStatus.WaitAudit & "'" & _
                            " AND ChangedHours='" & Me.dgvLoss.CurrentRow.Cells(enumdgvLoss.ChangedHours).Value & "'"

                Case enumActionFlag.SupportAudit, enumActionFlag.ClickedToolSupport
                    If Me.dgvSupport.CurrentRow Is Nothing Then Exit Sub
                    lsSQL = " UPDATE m_MoProductDetail_t  SET status='" & enumSumStatus.AlreadyAudit & "'" & _
                             ", AuditUserID='" & SysMessageClass.UseId.ToLower & "',AuditTime=getdate()" & _
                             " WHERE moid ='" & Me.TxtMoNo.Text.Trim() & "' AND " & _
                             " lineid='" & Me.txtLineID.Text.Trim() & "' AND workshift='" & Me.CboWorkShift.Text & "' " & _
                             " AND type ='" & enumMOSumType.SupportTime & "'" & _
                             " AND status='" & enumSumStatus.WaitAudit & "'" & _
                             " AND ChangedHours='" & Me.dgvSupport.CurrentRow.Cells(enumdgvSupport.ChangedHours).Value & "'"
                Case Else
                    'do nothing
            End Select

            If lsSQL <> String.Empty Then
                DbOperateUtils.ExecSQL(lsSQL)
                MessageUtils.ShowInformation("审核成功!")
            End If

            'Refesh Data
            LoadDataToDatagridview(" WHERE 1=1")
            Select Case m_ActionFlag
                Case enumActionFlag.LossAudit, enumActionFlag.ClickedToolLoss
                    Call BindLoss(" AND a.moid ='" & Me.TxtMoNo.Text.Trim() & "'")
                Case enumActionFlag.SupportAudit
                    Call BindSupport(" AND a.moid ='" & Me.TxtMoNo.Text.Trim() & "'")
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FrmSetMO_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TabControlD.Visible = False
        ''设定用戶權限
        'Dim ERigth As New SysDataBaseClass
        'ERigth.GetControlright(Me)
        LoadDataToDatagridview(" WHERE 1=1")
    End Sub

    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim SqlStr As String = "", strGroupBySQL As String = ""
        Dim strMOID As String = "", strLineID As String = "", strWorkShift As String = ""

        Try
            Me.dgvMOSumInfo.Rows.Clear()
            If Me.TxtMoNo.Text <> "" Then
                strMOID = Me.TxtMoNo.Text
            Else
                strMOID = "%"
            End If

            If Me.txtLineID.Text <> "" Then
                strLineID = Me.txtLineID.Text
            Else
                strLineID = "%"
            End If

            If Me.CboWorkShift.Text <> "" Then
                strWorkShift = Me.CboWorkShift.Text
            Else
                strWorkShift = "%"
            End If

            SqlStr = String.Format(" EXEC m_Query_KanBanSumInfo_p '{0}','{1}','{2}'", strMOID, strLineID, strWorkShift)
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)

                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    For Each dr As DataRow In o_dt.Rows
                        dgvMOSumInfo.Rows.Add(dr.Item(enumdgvMOSumInfo.MOID).ToString, dr.Item(enumdgvMOSumInfo.LineID).ToString, _
                             dr.Item(enumdgvMOSumInfo.WorkShift).ToString, dr.Item(enumdgvMOSumInfo.StartTime).ToString, dr.Item(enumdgvMOSumInfo.EndTime).ToString, _
                             dr.Item(enumdgvMOSumInfo.MOQty).ToString, dr.Item(enumdgvMOSumInfo.TotalOutPut).ToString, _
                             dr.Item(enumdgvMOSumInfo.CurrentShiftOutPut).ToString, dr.Item(enumdgvMOSumInfo.TotalNGQty).ToString, _
                             dr.Item(enumdgvMOSumInfo.CurrentShiftNGQty).ToString, dr.Item(enumdgvMOSumInfo.TotalLossHours).ToString, _
                             dr.Item(enumdgvMOSumInfo.CurrentShiftLossHours).ToString, dr.Item(enumdgvMOSumInfo.TotalSupportHours).ToString, _
                             dr.Item(enumdgvMOSumInfo.CurrentShiftSupportHours).ToString)
                    Next
                End If
            End Using
            Me.dgvMOSumInfo.ScrollBars = ScrollBars.Both
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolQueryMO_Click(sender As Object, e As EventArgs) Handles ToolQueryMO.Click
        Call LoadDataToDatagridview("")
    End Sub

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click

        Me.ToolSave.Enabled = True
        Me.ToolEdit.Enabled = False

        Select Case m_ActionFlag
            Case enumActionFlag.ClickedToolProductive
                Me.txtOutPutQty.Text = ""
                Me.txtNGQty.Text = ""
            Case enumActionFlag.ClickedToolLoss
                Me.txtLossHours.Text = ""
                Me.txtLossReason.Text = ""
                Me.CboLossDept.Text = ""
            Case enumActionFlag.ClickedToolSupport
                Me.txtSupportHours.Text = ""
                Me.txtSupportReason.Text = ""
                Me.CboSupportDept.Text = ""
            Case Else
                If Me.TabPageLoss.Visible = True Then 'Me.GrbLossTime.Visible = True Then
                    m_ActionFlag = enumActionFlag.ClickedToolLoss
                ElseIf Me.TabPageP.Visible = True Then
                    m_ActionFlag = enumActionFlag.ClickedToolProductive
                ElseIf Me.TabPageSupport.Visible = True Then
                    m_ActionFlag = enumActionFlag.ClickedToolSupport
                End If
        End Select
        ToolbtnState(enumActionFlag.NewAdd)

        'Set 
        m_blnLossEditSave = False
        m_blnSupportEditSave = False
        m_blnSupportEditSave = False
    End Sub

    Private Sub ExitFrom_Click(sender As Object, e As EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    '点击产能维护，可查看产能维护明细，增删改生产数量。
    '①增删改完成时刷新统计。
    '②生产时间为此次生产产品的时间，用于计算某一时间段的产出。要求生产时间必须在此班别的生产时间区段内（[m_MoWorkShift_t].StartTime & EndTime）。
    '③可维护多笔。比如可能一个班别只在下班时维护一笔，也可能期间每小时都维护一次。
    Private Sub ToolProductive_Click(sender As Object, e As EventArgs) Handles ToolProductive.Click
        Me.TabControlD.Visible = True
        Me.TabControlD.SelectedTab = Me.TabPageP
        Me.TabPageLoss.Parent = Nothing
        Me.TabPageSupport.Parent = Nothing
        Me.TabPageP.Parent = Me.TabControlD
        m_ActionFlag = enumActionFlag.ProductiveSave
        ToolbtnState(enumActionFlag.ProductiveSave)
    End Sub

    '损失工时：点击损失工时，可查看损失工时明细，增删改审核损失工时。
    '损失工时=直接人员借调至其他生产单位之时数×总借调人数
    '①审核完成时刷新统计，审核完成不可删改。
    '②允许维护多笔。比如可能在不同时间因为不同原因将人员借调到其他线别。
    '③只有审核完成，才算生效。审核完成不允许再进行修改，只可删除。
    Private Sub ToolLoss_Click(sender As Object, e As EventArgs) Handles ToolLoss.Click
        Me.TabControlD.Visible = True
        Me.TabControlD.SelectedTab = Me.TabPageLoss
        Me.TabPageP.Parent = Nothing
        Me.TabPageSupport.Parent = Nothing
        Me.TabPageLoss.Parent = Me.TabControlD
        m_ActionFlag = enumActionFlag.ClickedToolLoss
        Call FillCombox(CboLossDept)
        Me.CboLossDept.SelectedIndex = -1
        ToolbtnState(enumActionFlag.ClickedToolLoss)
    End Sub

    Private Sub ToolSupport_Click(sender As Object, e As EventArgs) Handles ToolSupport.Click
        'First control UI
        Me.TabControlD.Visible = True
        Me.TabControlD.SelectedTab = Me.TabPageSupport
        Me.TabPageP.Parent = Nothing
        Me.TabPageLoss.Parent = Nothing
        Me.TabPageSupport.Parent = Me.TabControlD
        m_ActionFlag = enumActionFlag.ClickedToolSupport
        Call FillCombox(CboSupportDept)
        Me.CboSupportDept.SelectedIndex = -1
        ToolbtnState(enumActionFlag.ClickedToolSupport)
    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case enumActionFlag.Load, enumActionFlag.ClickedToolLoss, enumActionFlag.ClickedToolProductive, enumActionFlag.ClickedToolSupport
                Me.ToolNew.Enabled = True  'IIf(Me.toolAdd.Tag.ToString <> "Yes", False, True)
                Me.ToolEdit.Enabled = True 'IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                Me.ToolCancel.Enabled = False
                Me.ToolSave.Enabled = False
            Case enumActionFlag.NewAdd, enumActionFlag.ClickedEdit
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolCancel.Enabled = True
                Me.ToolSave.Enabled = True
            Case Else
                'do nothing
        End Select
    End Sub

    Private Sub ToolSave_Click(sender As Object, e As EventArgs) Handles ToolSave.Click
        Dim lsSQL As String = "", strDept As String = ""
        Dim o_iMOAlreadyOutPutQty As Integer = 0

        Try
            If Not CheckBaseData(m_ActionFlag) Then
                Exit Sub
            End If
            Select Case m_ActionFlag
                Case enumActionFlag.ProductiveSave, enumActionFlag.ClickedToolProductive
                    'check Base Data
                    '生产时间为此次生产产品的时间，用于计算某一时间段的产出。要求生产时间必须在此班别的生产时间区段内（[m_MoWorkShift_t].StartTime & EndTime）
                    If Date.Compare(DateTimePickerProductive.Value, Me.dgvMOSumInfo.CurrentRow.Cells(enumdgvMOSumInfo.StartTime).Value) < 0 OrElse Date.Compare(DateTimePickerProductive.Value, Me.dgvMOSumInfo.CurrentRow.Cells(enumdgvMOSumInfo.EndTime).Value) > 0 Then
                        MessageUtils.ShowError("生产时间必须在此班别的生产时间区段内!")
                        Me.DateTimePickerProductive.Focus()
                        Exit Sub
                    End If
                    'First get this MO's  output 
                    o_iMOAlreadyOutPutQty = GetMOOutPutQty(Me.TxtMoNo.Text.Trim())
                    If (Val(Me.txtOutPutQty.Text) + o_iMOAlreadyOutPutQty) > Val(Me.dgvMOSumInfo.CurrentRow.Cells(enumdgvMOSumInfo.MOQty).Value) Then
                        MessageUtils.ShowError("输入的产出数量错误，超过了工单的总数量!")
                        Me.txtOutPutQty.Focus()
                        Exit Sub
                    End If

                    If (Not m_blnProductiveEditSave) Then
                        lsSQL = " INSERT INTO m_MoProductDetail_t(MOid, lineid, workshift,type, outqty, ngqty,productTime,ChangedHours,Userid, CreateTime) " & _
                              " values('" & Me.TxtMoNo.Text.Trim() & "','" & Me.txtLineID.Text.Trim() & "','" & Me.CboWorkShift.Text & "'," & _
                              " " & enumMOSumType.Productive & ", '" & Me.txtOutPutQty.Text & "','" & Me.txtNGQty.Text & "', " & _
                              " '" & Me.DateTimePickerProductive.Value & "',0, '" & SysMessageClass.UseId.ToLower & "', getDate())"
                    Else
                        lsSQL = " UPDATE m_MoProductDetail_t set outqty='" & Me.txtOutPutQty.Text & "', ngqty='" & Me.txtNGQty.Text.Trim() & "',productTime='" & Me.DateTimePickerProductive.Value & "' ,updatedtime=getdate() " & _
                                " where moid='" & Me.TxtMoNo.Text.Trim() & "' and type='" & enumMOSumType.Productive & "' and convert(varchar,createtime,120)='" & Convert.ToDateTime(Me.dgvProductiveDetail.CurrentRow.Cells(enumdgvProductiveDetail.CreateTime).Value).ToString("yyyy-MM-dd HH:mm:ss") & "'"
                    End If

                    If lsSQL <> String.Empty Then
                        DbOperateUtils.ExecSQL(lsSQL)
                        MessageUtils.ShowInformation("保存成功!")
                    End If

                    Call BindProductive("and a.moid ='" & Me.TxtMoNo.Text.Trim() & "'")
                    Me.txtOutPutQty.Text = "" : Me.txtNGQty.Text = ""
                Case enumActionFlag.ClickedToolLoss
                    If IsNothing(Me.CboLossDept.SelectedValue) Then
                        strDept = Me.CboLossDept.Text
                    Else
                        strDept = Me.CboLossDept.SelectedValue
                    End If

                    If (Not m_blnLossEditSave) Then
                        lsSQL = " INSERT INTO m_MoProductDetail_t(MOid, lineid, workshift,type,status, ChangedHours,ChangedReason,RelatedDeptid,Userid, CreateTime) " & _
                             " values('" & Me.TxtMoNo.Text.Trim() & "','" & Me.txtLineID.Text.Trim() & "','" & Me.CboWorkShift.Text & "'," & _
                             " " & enumMOSumType.LossTime & ",'" & enumSumStatus.WaitAudit & "','" & Val(Me.txtLossHours.Text) & "', " & _
                             " N'" & Me.txtLossReason.Text.Trim.Replace("'", "''") & "', N'" & strDept & "', '" & SysMessageClass.UseId.ToLower & "', getDate())"
                    Else
                        If Val(Me.dgvLoss.CurrentRow.Cells(enumdgvLoss.Status).Value.ToString.Split("-")(0)) = enumSumStatus.AlreadyAudit Then
                            MessageUtils.ShowError("已审核,不能编辑！")
                            Exit Sub
                        End If

                        lsSQL = " UPDATE m_MoProductDetail_t SET ChangedHours='" & Val(Me.txtLossHours.Text.Trim()) & "' , ChangedReason=N'" & Me.txtLossReason.Text.Trim().Replace("'", "''") & "', " & _
                                " RelatedDeptid='" & strDept & "',updatedtime=getdate() " & _
                                " WHERE moid='" & Me.TxtMoNo.Text.Trim() & "' and type='" & enumMOSumType.LossTime & "'" & _
                                " AND CONVERT(varchar,createtime,120)='" & Convert.ToDateTime(Me.dgvLoss.CurrentRow.Cells(enumdgvLoss.CreateTime).Value).ToString("yyyy-MM-dd HH:mm:ss") & "' "
                    End If

                    If lsSQL <> String.Empty Then
                        DbOperateUtils.ExecSQL(lsSQL)
                        MessageUtils.ShowInformation("保存成功!")
                    End If

                    Call BindLoss(" AND a.moid ='" & Me.TxtMoNo.Text.Trim() & "'")
                    Me.txtLossHours.Text = "" : Me.txtLossReason.Text = ""
                Case enumActionFlag.ClickedToolSupport
                    If IsNothing(Me.CboSupportDept.SelectedValue) Then
                        strDept = Me.CboSupportDept.Text
                    Else
                        strDept = Me.CboSupportDept.SelectedValue
                    End If

                    If (Not m_blnSupportEditSave) Then
                        lsSQL = " INSERT INTO m_MoProductDetail_t(MOid, lineid, workshift,type,status,ChangedHours,ChangedReason,RelatedDeptid,Userid, CreateTime) " & _
                               " values('" & Me.TxtMoNo.Text.Trim() & "','" & Me.txtLineID.Text.Trim() & "','" & Me.CboWorkShift.Text & "'," & _
                               " " & enumMOSumType.SupportTime & ", '" & enumSumStatus.WaitAudit & "','" & Val(Me.txtSupportHours.Text) & "',N'" & Me.txtSupportReason.Text.Trim() & "', " & _
                               " '" & strDept & "', '" & SysMessageClass.UseId.ToLower & "', getDate())"
                    Else

                        If Val(Me.dgvSupport.CurrentRow.Cells(enumdgvSupport.Status).Value.ToString.Split("-")(0)) = enumSumStatus.AlreadyAudit Then
                            MessageUtils.ShowInformation("已审核,不能编辑！")
                            Exit Sub
                        End If

                        lsSQL = " UPDATE m_MoProductDetail_t SET ChangedHours='" & Val(Me.txtSupportHours.Text.Trim()) & "' , ChangedReason=N'" & Me.txtSupportReason.Text.Trim().Replace("'", "''") & "'," & _
                                " RelatedDeptid = N '" & strDept & "', updatedtime=getdate() " & _
                                " WHERE moid='" & Me.TxtMoNo.Text.Trim() & "' and type='" & enumMOSumType.SupportTime & "'" & _
                                " AND CONVERT(varchar,createtime,120)='" & Convert.ToDateTime(Me.dgvSupport.CurrentRow.Cells(enumdgvSupport.CreateTime).Value).ToString("yyyy-MM-dd HH:mm:ss") & "'"
                    End If

                    If lsSQL <> String.Empty Then
                        DbOperateUtils.ExecSQL(lsSQL)
                        MessageUtils.ShowInformation("保存成功!")
                    End If

                    Call BindSupport(" AND a.moid ='" & Me.TxtMoNo.Text.Trim() & "'")
                    Me.CboSupportDept.SelectedIndex = -1
                    Me.txtSupportHours.Text = ""
                    Me.txtSupportReason.Text = ""
                Case Else
                    'do nothing
            End Select
            '
            ToolbtnState(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetMOOutPutQty(ByVal parMO As String) As Integer
        Dim lsSQL As String = ""
        Try
            lsSQL = "SELECT MOID, isnull(SUM(OutQty),0) as MOOutPutQty FROM [dbo].[m_MoProductDetail_t] " & _
                    " WHERE Type='" & enumMOSumType.Productive & "' AND MOID='" & parMO & "' GROUP BY MOID "
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    GetMOOutPutQty = o_dt.Rows(0).Item("MOOutPutQty")
                Else
                    GetMOOutPutQty = 0
                End If
            End Using
            Return GetMOOutPutQty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function CheckBaseData(ByVal flag As Integer) As Boolean
        CheckBaseData = True

        Select Case flag
            Case enumActionFlag.ClickedToolLoss
                If Val(Me.txtLossHours.Text.Trim) <= 0 Then
                    CheckBaseData = False
                    MessageUtils.ShowError("损失工时输入不正确，请检查！")
                End If
            Case enumActionFlag.ClickedToolSupport
                If Val(Me.txtSupportHours.Text.Trim) <= 0 Then
                    CheckBaseData = False
                    MessageUtils.ShowError("支援工时输入不正确，请检查！")
                End If
            Case enumActionFlag.ClickedToolProductive
                If Val(Me.txtOutPutQty.Text.Trim) <= 0 Then
                    CheckBaseData = False
                    MessageUtils.ShowError("生产数量输入不正确，请检查！")
                End If

                If Me.txtNGQty.Text.Trim() = "0" Then
                    'bypass 
                Else
                    If Val(Me.txtNGQty.Text.Trim()) <= 0 Then
                        CheckBaseData = False
                        MessageUtils.ShowError("不良数量输入不正确，请检查！")
                    End If
                End If
        End Select
        Return CheckBaseData
    End Function

    Private Sub BindProductive(ByVal FiterSqlStr As String)
        Dim i As Integer = 0
        Dim UserDg As DataTable
        Dim Sqlstr As String = ""

        dgvProductiveDetail.Rows.Clear()
        dgvProductiveDetail.ScrollBars = ScrollBars.None
        Sqlstr = _
               "SELECT moid," + vbCrLf + _
               "       lineid," + vbCrLf + _
               "       N'第' + cast (workshift AS VARCHAR (4)) + N'节' AS workshift," + vbCrLf + _
               "       OutQty," + vbCrLf + _
               "       ngqty," + vbCrLf + _
               "       ProductTime," + vbCrLf + _
               "       userid," + vbCrLf + _
               "       CreateTime," + vbCrLf + _
               "       UpdatedTime" + vbCrLf + _
               "  FROM m_MoProductDetail_t a where type ='" & enumMOSumType.Productive & "'"
        UserDg = DbOperateUtils.GetDataTable(Sqlstr & FiterSqlStr) 'FiterSqlStr

        For i = 0 To UserDg.Rows.Count - 1
            Try
                dgvProductiveDetail.Rows.Add(UserDg.Rows(i)(enumdgvProductiveDetail.MOID),
                                             UserDg.Rows(i)(enumdgvProductiveDetail.LineID),
                                             UserDg.Rows(i)(enumdgvProductiveDetail.WorkShift),
                                            UserDg.Rows(i)(enumdgvProductiveDetail.OutQty),
                                            UserDg.Rows(i)(enumdgvProductiveDetail.NGQty),
                                            UserDg.Rows(i)(enumdgvProductiveDetail.ProductTime),
                                            UserDg.Rows(i)(enumdgvProductiveDetail.UserID),
                                            UserDg.Rows(i)(enumdgvProductiveDetail.CreateTime),
                                            UserDg.Rows(i)(enumdgvProductiveDetail.UpdatedTime))

            Catch ex As Exception
                Continue For
            End Try
        Next
        dgvProductiveDetail.ScrollBars = ScrollBars.Both
    End Sub

    Private Sub BindLoss(ByVal FiterSqlStr As String)
        Dim i As Integer = 0
        Dim UserDg As DataTable
        Dim Sqlstr As String = ""

        dgvLoss.Rows.Clear()
        dgvLoss.ScrollBars = ScrollBars.None
        Sqlstr = _
               "SELECT moid," + vbCrLf + _
               "       lineid," + vbCrLf + _
               "       N'第' + cast (workshift AS VARCHAR (4)) + N'节' AS workshift," + vbCrLf + _
               "       CASE status WHEN 0 THEN N'0-待审核' WHEN 1 THEN N'1-已审核' END AS status," + vbCrLf + _
               "       changedHours," + vbCrLf + _
               "       changedReason," + vbCrLf + _
               "       RelatedDeptid," + vbCrLf + _
               "       userid," + vbCrLf + _
               "       AuditUserID," + vbCrLf + _
               "       CreateTime," + vbCrLf + _
               "       UpdatedTime," + vbCrLf + _
               "       AuditTime" + vbCrLf + _
               "  FROM m_MoProductDetail_t a where type ='" & enumMOSumType.LossTime & "'"
        UserDg = DbOperateUtils.GetDataTable(Sqlstr & FiterSqlStr) 'FiterSqlStr

        For i = 0 To UserDg.Rows.Count - 1
            Try

                dgvLoss.Rows.Add(UserDg.Rows(i)(enumdgvLoss.moid), UserDg.Rows(i)(enumdgvLoss.lineid), UserDg.Rows(i)(enumdgvLoss.workshift), _
                                   UserDg.Rows(i)(enumdgvLoss.Status), UserDg.Rows(i)(enumdgvLoss.ChangedHours), _
                                   UserDg.Rows(i)(enumdgvLoss.ChangedReason), UserDg.Rows(i)(enumdgvLoss.RelatedDeptid), UserDg.Rows(i)(enumdgvLoss.UserID), _
                                   UserDg.Rows(i)(enumdgvLoss.AuditUserID), UserDg.Rows(i)(enumdgvLoss.CreateTime), _
                                   UserDg.Rows(i)(enumdgvLoss.UpdatedTime), UserDg.Rows(i)(enumdgvLoss.AuditTime))

            Catch ex As Exception
                Continue For
            End Try
        Next
        dgvLoss.ScrollBars = ScrollBars.Both
    End Sub

    Private Sub BindSupport(ByVal FiterSqlStr As String)
        Dim i As Integer = 0
        Dim UserDg As DataTable
        Dim Sqlstr As String = ""

        dgvSupport.Rows.Clear()
        dgvSupport.ScrollBars = ScrollBars.None
        Sqlstr = _
               "SELECT moid," + vbCrLf + _
               "       lineid," + vbCrLf + _
               "       N'第' + cast (workshift AS VARCHAR (4)) + N'节' AS workshift," + vbCrLf + _
               "       CASE status WHEN 0 THEN N'0-待审核' WHEN 1 THEN N'1-已审核' END AS status," + vbCrLf + _
               "       ChangedHours," + vbCrLf + _
               "       ChangedReason," + vbCrLf + _
               "       RelatedDeptid," + vbCrLf + _
               "       userid," + vbCrLf + _
               "       AuditUserID," + vbCrLf + _
               "       CreateTime," + vbCrLf + _
               "       UpdatedTime," + vbCrLf + _
               "       AuditTime" + vbCrLf + _
               "  FROM m_MoProductDetail_t a where  type ='" & enumMOSumType.SupportTime & "'"
        UserDg = DbOperateUtils.GetDataTable(Sqlstr & FiterSqlStr) 'FiterSqlStr

        For i = 0 To UserDg.Rows.Count - 1
            Try

                dgvSupport.Rows.Add(UserDg.Rows(i)(enumdgvSupport.MOID), UserDg.Rows(i)(enumdgvSupport.LineID), UserDg.Rows(i)(enumdgvSupport.WorkShift), _
                                   UserDg.Rows(i)(enumdgvSupport.Status), UserDg.Rows(i)(enumdgvSupport.ChangedHours), _
                                   UserDg.Rows(i)(enumdgvSupport.ChangedReason), UserDg.Rows(i)(enumdgvSupport.RelatedDeptid), UserDg.Rows(i)(enumdgvSupport.UserID), _
                                   UserDg.Rows(i)(enumdgvSupport.AuditUserID), UserDg.Rows(i)(enumdgvSupport.CreateTime), _
                                   UserDg.Rows(i)(enumdgvSupport.UpdatedTime), UserDg.Rows(i)(enumdgvSupport.AuditTime))

            Catch ex As Exception
                Continue For
            End Try
        Next
        dgvSupport.ScrollBars = ScrollBars.Both
    End Sub

    Private Sub dgvSupport_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSupport.CellClick
        If Me.dgvSupport.Rows.Count = 0 OrElse Me.dgvSupport.CurrentRow Is Nothing Then Exit Sub
        m_ActionFlag = enumActionFlag.SupportAudit

        '反填
        Me.txtSupportHours.Text = KBCom.DBNullToStr(Me.dgvSupport.CurrentRow.Cells(enumdgvSupport.ChangedHours).Value)
        Me.txtSupportReason.Text = KBCom.DBNullToStr(Me.dgvSupport.CurrentRow.Cells(enumdgvSupport.ChangedReason).Value)
        If IsDBNull(Me.dgvSupport.CurrentRow.Cells(enumdgvSupport.RelatedDeptid).Value) Then
            Me.CboSupportDept.Text = ""
        Else
            Me.CboSupportDept.Text = Me.dgvSupport.CurrentRow.Cells(enumdgvSupport.RelatedDeptid).Value.ToString()
        End If
    End Sub

    Private Sub dgvProductiveDetail_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductiveDetail.CellClick
        If Me.dgvProductiveDetail.Rows.Count = 0 OrElse Me.dgvProductiveDetail.CurrentRow Is Nothing Then Exit Sub
        '反填
        With Me.dgvProductiveDetail.CurrentRow
            Me.DateTimePickerProductive.Text = KBCom.DBNullToStr(.Cells(enumdgvProductiveDetail.ProductTime).Value)
            Me.TxtMoNo.Text = KBCom.DBNullToStr(.Cells(enumdgvProductiveDetail.MOID).Value)
            Me.txtLineID.Text = KBCom.DBNullToStr(.Cells(enumdgvProductiveDetail.LineID).Value)
            Me.txtOutPutQty.Text = KBCom.DBNullToStr(.Cells(enumdgvProductiveDetail.OutQty).Value)
            Me.txtNGQty.Text = KBCom.DBNullToStr(.Cells(enumdgvProductiveDetail.NGQty).Value)
        End With
    End Sub

    Private Sub dgvMOSumInfo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMOSumInfo.CellClick
        If Me.dgvMOSumInfo.Rows.Count = 0 OrElse Me.dgvMOSumInfo.CurrentRow Is Nothing Then Exit Sub
        '反填
        Me.TxtMoNo.Text = Me.dgvMOSumInfo.CurrentRow.Cells(enumdgvMOSumInfo.MOID).Value
        Me.txtLineID.Text = Me.dgvMOSumInfo.CurrentRow.Cells(enumdgvMOSumInfo.LineID).Value
        Me.CboWorkShift.Text = Me.dgvMOSumInfo.CurrentRow.Cells(enumdgvMOSumInfo.WorkShift).Value

        Select Case m_ActionFlag
            Case enumActionFlag.ClickedToolProductive, 3
                Call BindProductive(" and a.moid like '%" & Me.TxtMoNo.Text.Trim() & "%'and a.workshift like '%" & Me.CboWorkShift.Text.Trim() & "%'")
            Case enumActionFlag.ClickedToolLoss
                Call BindLoss(" and a.moid like '%" & Me.TxtMoNo.Text.Trim() & "%' and a.workshift like '%" & Me.CboWorkShift.Text.Trim() & "%'")
            Case enumActionFlag.ClickedToolSupport
                Call BindSupport(" and a.moid like '%" & Me.TxtMoNo.Text.Trim() & "%' and a.workshift like '%" & Me.CboWorkShift.Text.Trim() & "%'")
            Case Else
                'do nothing
        End Select

    End Sub

    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click

        If Me.TabPageLoss.Visible = True Then
            m_ActionFlag = enumActionFlag.ClickedToolLoss
        ElseIf Me.TabPageP.Visible = True Then
            m_ActionFlag = enumActionFlag.ClickedToolProductive
        ElseIf Me.SplitContainerSupport.Visible = True Then
            m_ActionFlag = enumActionFlag.ClickedToolSupport
        End If

        Select Case m_ActionFlag
            Case enumActionFlag.ClickedToolProductive
                m_blnProductiveEditSave = True
            Case enumActionFlag.ClickedToolLoss
                m_blnLossEditSave = True
            Case enumActionFlag.ClickedToolSupport
                m_blnSupportEditSave = True
            Case Else

        End Select

        Call ToolbtnState(enumActionFlag.ClickedEdit)

    End Sub

    Private Sub ToolCancel_Click(sender As Object, e As EventArgs) Handles ToolCancel.Click
        Me.txtLossHours.Text = ""
        Me.txtLossReason.Text = ""
        ToolbtnState(0)
    End Sub

    Private Sub dgvLoss_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLoss.CellClick
        If Me.dgvLoss.Rows.Count = 0 OrElse Me.dgvLoss.CurrentRow Is Nothing Then Exit Sub

        '反填
        With Me.dgvLoss.CurrentRow
            Me.txtLossHours.Text = KBCom.DBNullToStr(.Cells(enumdgvLoss.ChangedHours).Value)
            Me.txtLossReason.Text = KBCom.DBNullToStr(.Cells(enumdgvLoss.ChangedReason).Value)
            Me.CboLossDept.Text = KBCom.DBNullToStr(Me.dgvLoss.CurrentRow.Cells(enumdgvLoss.RelatedDeptid).Value)
        End With
    End Sub

    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        Dim lsSQL As String = ""

        If ("6,7,8").IndexOf(m_ActionFlag) < 0 Then
            If Me.dgvProductiveDetail.Visible = True Then
                m_ActionFlag = enumActionFlag.ClickedToolProductive
            ElseIf Me.dgvSupport.Visible = True Then
                m_ActionFlag = enumActionFlag.ClickedToolSupport
            ElseIf Me.dgvLoss.Visible = True Then
                m_ActionFlag = enumActionFlag.ClickedToolLoss
            End If
        End If

        Select Case m_ActionFlag
            Case enumActionFlag.ClickedToolProductive
                If Me.dgvProductiveDetail.Rows.Count = 0 OrElse Me.dgvProductiveDetail.CurrentRow Is Nothing Then Exit Sub

                lsSQL = _
              " DELETE FROM m_MoProductDetail_t " + vbCrLf + _
              " WHERE moid = '" & Me.TxtMoNo.Text.Trim() & "' and LINEID ='" & Me.txtLineID.Text & "'" + vbCrLf + _
              " and type ='" & enumMOSumType.Productive & "'" + vbCrLf + _
              " and CONVERT(varchar,createtime,120)='" & Convert.ToDateTime(Me.dgvProductiveDetail.CurrentRow.Cells(enumdgvProductiveDetail.CreateTime).Value).ToString("yyyy-MM-dd HH:mm:ss") & "'"

                DbOperateUtils.ExecSQL(lsSQL)
                MessageBox.Show("删除成功!")
                'Refesh Data
                LoadDataToDatagridview(" ")
                Call BindProductive(" AND a.moid like '%" & Me.TxtMoNo.Text.Trim() & "%'")

            Case enumActionFlag.ClickedToolLoss
                If Me.dgvLoss.Rows.Count = 0 OrElse Me.dgvLoss.CurrentRow Is Nothing Then Exit Sub
                lsSQL = _
              " DELETE FROM m_MoProductDetail_t " + vbCrLf + _
              " WHERE moid = '" & Me.TxtMoNo.Text.Trim() & "' and lineid ='" & Me.txtLineID.Text & "'" + vbCrLf + _
              " AND type ='" & enumMOSumType.LossTime & "'" + vbCrLf + _
              " AND convert(varchar,createtime,120)='" & Convert.ToDateTime(Me.dgvLoss.CurrentRow.Cells(enumdgvLoss.CreateTime).Value).ToString("yyyy-MM-dd HH:mm:ss") & "'"

                DbOperateUtils.ExecSQL(lsSQL)
                LoadDataToDatagridview(" ")
                Call BindLoss(" AND a.moid like '%" & Me.TxtMoNo.Text.Trim() & "%'")

            Case enumActionFlag.ClickedToolSupport
                If Me.dgvSupport.Rows.Count = 0 OrElse Me.dgvSupport.CurrentRow Is Nothing Then Exit Sub
                lsSQL = _
              " DELETE FROM m_MoProductDetail_t " + vbCrLf + _
              " WHERE moid = '" & Me.TxtMoNo.Text.Trim() & "' and lineid ='" & Me.txtLineID.Text & "'" + vbCrLf + _
              " and type ='" & enumMOSumType.SupportTime & "'" + vbCrLf + _
              " and convert(varchar,createtime,120)='" & Convert.ToDateTime(Me.dgvSupport.CurrentRow.Cells(enumdgvLoss.CreateTime).Value).ToString("yyyy-MM-dd HH:mm:ss") & "'"

                DbOperateUtils.ExecSQL(lsSQL)
                LoadDataToDatagridview(" ")
                Call BindSupport(" AND a.moid like '%" & Me.TxtMoNo.Text.Trim() & "%'")
        End Select
    End Sub


End Class