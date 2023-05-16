Imports System.IO
Imports DevComponents.DotNetBar
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Text
Imports System.Net.Mail
Imports System.Data.SqlClient
Imports MainFrame
Imports SysBasicClass

Public Class FrmSampleProblem

    '--样品制样问题追踪
    '--Create by :　黄广都
    '--Create date :　2017/02/6
    '--Update date :  
    '--Ver : V01
    Dim ServerFilePath As String = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\SampleProblem\"

#Region "窗体事件"
    Private Sub FrmSampleProblem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '设定用戶權限
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        '控制菜单权限
        SetMenuRight()
        cmbSatus.SelectedIndex = 0
        'Me.txtS_SampleTime.Value = Now().AddMonths(-1).ToString("yyyy/MM/dd")
        'Me.txtStartTime.Value = Now().AddMonths(-1).ToString("yyyy/MM/dd")

        'Me.txtS_SampleTime.Value = "2017/01/01"
        'Me.txtStartTime.Value = "2017/01/01"

        Me.txtS_SampleTime.Value = Date.Now.AddDays(-1).ToString("yyyy/MM/dd")
        Me.txtStartTime.Value = Date.Now.AddDays(-1).ToString("yyyy/MM/dd")

        Me.txtEndTime.Value = Now().ToString("yyyy/MM/dd")
        SampleManage.SampleBusiness.BindComboxStatus(Me.selStatus)
        SampleManage.SampleBusiness.BindComboxStage(Me.selStage)
        LoadSampleProblem()
        '预计完成日期已过，但未完成的邮件提醒责任人，仅提醒一次
        'SeedMailToDutyList()
    End Sub
#End Region

#Region "菜单事件"

    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Try
            Dim frmSampleEdit As New FrmSampleProblemEdit("New", Nothing)
            If frmSampleEdit.ShowDialog() = Windows.Forms.DialogResult.Yes Then

                LoadSampleProblem()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleProblem", "toolAdd_Click", "sys")
        End Try
       
    End Sub
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        Try
            If Not Me.dgvSampleProblem.CurrentCell Is Nothing Then
                Dim frmSampleEdit As New FrmSampleProblemEdit("Edit", Me.dgvSampleProblem.CurrentRow)
                If frmSampleEdit.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                    LoadSampleProblem()
                End If
            End If
          
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleProblem", "toolEdit_Click", "sys")
        End Try
    End Sub
    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        If Not Me.dgvSampleProblem.CurrentCell Is Nothing Then
            If (MessageUtils.ShowConfirm("确定要作废吗?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                If DeleteSampleProblem() = True Then
                    MessageUtils.ShowInformation("作废成功！")
                    LoadSampleProblem()
                End If
            End If

        End If
    End Sub

    Private Sub toolExprot_Click(sender As Object, e As EventArgs) Handles toolExprot.Click
        Try
            'Cursor.Current = Cursors.WaitCursor
            'If Not Me.dgvSampleProblem Is Nothing AndAlso Me.dgvSampleProblem.RowCount > 0 Then

            '    SysBasicClass.Export.OutToExcelFromDataGridView("制样解析备忘库", Me.dgvSampleProblem, False)
            'End If
            'Cursor.Current = Cursors.Default

            '由于何建邦2018-07-22提出制程解析导出数据异常,特此修复
            'add by马跃平 2018-07-23 
            Dim o_strSql As New StringBuilder
            Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim dt As New DataTable
            Dim sql = "select  ProblemName 'RDN/品名',RDEngineer '研发工程师'," & vbCrLf &
            "Convert(nvarchar(10), a.SampleTime, 121) '制样日期'," & vbCrLf &
            "SampleQty '制样数量',NGQty '不良数量',NGRate '不良率(%)'," & vbCrLf &
            "case when c.TEXT=N'进行中'" & vbCrLf &
            "AND ExpFinishTime<CONVERT(DATETIME,CONVERT(VARCHAR(10),GETDATE(),120))" & vbCrLf &
            "then N'延期' else c.TEXT end '追踪状态',ProblemDesc '问题描述'," & vbCrLf &
            "case when IsDrawingNG=1 then N'√' else '' end '设计/图纸问题' , " & vbCrLf &
            "case when IsMaterialNG=1 then N'√'  else ''  end '物料问题', " & vbCrLf &
            "case when IsCraftNG=1 then N'√'  else ''  end  '工艺问题', " & vbCrLf &
            "case when IsMouldNG =1 then N'√'  else ''  end '模治具问题', " & vbCrLf &
            "case when IsOtherNG=1 then  N'√'  else '' end '其它问题'  ," & vbCrLf &
            "PersonLiable '责任人',TempCountermeasure '临时对策'," & vbCrLf &
            "LongCountermeasure '长期对策',TrackingSummary '追踪结论' " & vbCrLf &
            ",CONVERT(nvarchar(10), a.StartTime,121) '开始日期'," & vbCrLf &
            "CONVERT(nvarchar(10), a.ExpFinishTime,121) as '预计完成日期'," & vbCrLf &
            "CONVERT(nvarchar(10), a.ActFinishTime,121) as '实际完成日期'  " & vbCrLf &
            ",case when UrgentState='Y' then '加急件'else '一般件'end '加急状态'" & vbCrLf &
            ",FilePath '附件',b.UserName '创建人'," & vbCrLf &
            "Convert(nvarchar(10), a.CreateTime, 121)  '创建日期' ,a.BeOverdueNum '延期次数' " & vbCrLf &
            "from m_SampleProblem_t a left join   " & vbCrLf &
            "m_Users_t b on b.UserID=a.CreateUser " & vbCrLf &
            "left join m_BaseData_t c on  " & vbCrLf &
            "c.ITEMKEY='SampleProblemStatus' and c.VALUE=a.Status   " & vbCrLf &
            "where a.Status<>'D'   "
            o_strSql.AppendLine(sql)

            'If Not String.IsNullOrEmpty(Me.txtProblemName.Text.Trim) Then
            '    o_strSql.Append(" and  a.ProblemName like N'%" & Me.txtProblemName.Text.Trim & "%'")
            'End If
            'If Not String.IsNullOrEmpty(Me.txtRDEngineer.Text.Trim) Then
            '    o_strSql.Append(" and a.RDEngineer like N'%" & Me.txtRDEngineer.Text.Trim & "%'")
            'End If
            'If Not String.IsNullOrEmpty(Me.txtS_SampleTime.Text.Trim) AndAlso Not String.IsNullOrEmpty(Me.txtE_SampleTime.Text.Trim) AndAlso ChkZhiYang.Checked = True Then
            '    o_strSql.Append(" and a.SampleTime between '" & Me.txtS_SampleTime.Text.Trim & "' and  '" & Me.txtE_SampleTime.Text.Trim & "'")
            'End If
            'If Not String.IsNullOrEmpty(Me.txtPersonLiable.Text.Trim) Then
            '    o_strSql.Append(" and a.PersonLiable  like N'%" & Me.txtPersonLiable.Text.Trim & "%'")
            'End If
            'If Not String.IsNullOrEmpty(Me.txtProblemDesc.Text.Trim) Then
            '    o_strSql.Append(" and a.ProblemDesc  like N'%" & Me.txtProblemDesc.Text.Trim & "%'")
            'End If
            'If Not String.IsNullOrEmpty(Me.txtStartTime.Text.Trim) AndAlso Not String.IsNullOrEmpty(Me.txtEndTime.Text.Trim) AndAlso ChkKaiShi.Checked = True Then
            '    o_strSql.Append(" and a.CreateTime between '" & Me.txtStartTime.Text.Trim & "' and  '" & Me.txtEndTime.Text.Trim & "'")
            'End If
            'If Not String.IsNullOrEmpty(Me.txtTempCountermeasure.Text.Trim) Then
            '    o_strSql.Append(" and a.TempCountermeasure  like N'%" & Me.txtTempCountermeasure.Text.Trim & "%'")
            'End If

            'If Not String.IsNullOrEmpty(Me.txtLongCountermeasure.Text.Trim) Then
            '    o_strSql.Append(" and a.LongCountermeasure  like N'%" & Me.txtLongCountermeasure.Text.Trim & "%'")
            'End If

            'If Not String.IsNullOrEmpty(Me.selStatus.SelectedValue.ToString) Then
            '    If Me.selStatus.SelectedValue.ToString <> "P" Then
            '        o_strSql.Append(" and a.Status ='" & Me.selStatus.SelectedValue.ToString & "'")
            '    Else
            '        o_strSql.Append(" and a.Status ='I'   AND ExpFinishTime<CONVERT(DATETIME,CONVERT(VARCHAR(10),GETDATE(),120))")
            '    End If

            'End If
            'If Not String.IsNullOrEmpty(Me.txtTrackingSummary.Text.Trim) Then
            '    o_strSql.Append(" and a.TrackingSummary  like N'%" & Me.txtTrackingSummary.Text.Trim & "%'")
            'End If
            'If Not String.IsNullOrEmpty(Me.txtUserName.Text.Trim) Then
            '    o_strSql.Append(" and b.UserName  like N'%" & Me.txtUserName.Text.Trim & "%'")
            'End If

            'If Me.cbIsDrawingNG.Checked = True Then
            '    o_strSql.Append(" and a.IsDrawingNG=1 ")
            'End If
            'If Me.cbIsMaterialNG.Checked = True Then
            '    o_strSql.Append(" and a.IsMaterialNG=1 ")
            'End If
            'If Me.cbIsCraftNG.Checked = True Then
            '    o_strSql.Append(" and a.IsCraftNG=1 ")
            'End If
            'If Me.cbIsMouldNG.Checked = True Then
            '    o_strSql.Append(" and a.IsMouldNG=1 ")
            'End If
            'If Me.cbIsOtherNG.Checked = True Then
            '    o_strSql.Append(" and a.IsOtherNG=1 ")
            'End If
            'If cmbSatus.Text = "一般件" Then
            '    o_strSql.Append(" and UrgentState='N'")
            'ElseIf cmbSatus.Text = "加急件" Then
            '    o_strSql.Append(" and UrgentState='Y'")
            'End If
            

            o_strSql.Append(" order by a.CreateTime desc ")

            dt = DAL.GetDataTable(o_strSql.ToString)
            VbCommClass.NPOIExcle.DataTableExportToExcle(dt, Nothing, "制样解析备忘库.xls")
        Catch ex As Exception
            MessageUtils.ShowError("导出出错:" & vbCrLf & "" + ex.Message)
        End Try
     
    End Sub
    ''' <summary>
    ''' 查询
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        LoadSampleProblem(1)
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
#End Region
#Region "DataGridView 事件"
    Private Sub dgvSampleProblem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSampleProblem.CellDoubleClick
        If Not Me.dgvSampleProblem.CurrentCell Is Nothing Then
            '双击附件栏，打开附件
            If e.ColumnIndex = CInt(SampleBusiness.SampleProblemGrid.FilePath) Then
                Dim FilePath As String = Nothing
                FilePath = Me.dgvSampleProblem.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
                If Not String.IsNullOrEmpty(FilePath) Then

                    Dim OpenFilePath As String = Path.Combine(ServerFilePath, System.IO.Path.GetFileName(FilePath))

                    If System.IO.File.Exists(OpenFilePath) = True Then
                        System.Diagnostics.Process.Start(OpenFilePath)
                    End If

                End If

            Else
                Dim frmSampleEdit As New FrmSampleProblemEdit("View", Me.dgvSampleProblem.CurrentRow)
                frmSampleEdit.ShowDialog()
            End If
        End If
    End Sub

    Private Sub dgvSampleProblem_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvSampleProblem.CellFormatting
        If e.RowIndex > -1 AndAlso e.ColumnIndex = CInt(SampleBusiness.SampleProblemGrid.StatusName) AndAlso Me.dgvSampleProblem.RowCount > 0 Then
          

            '设置状态字体颜色
            Dim _Status As String
            'e.ColumnIndex = CInt(SampleBusiness.SampleProblemGrid.StatusName)

            If dgvSampleProblem.Columns(e.ColumnIndex).Name = "StatusName" Then
                _Status = Me.dgvSampleProblem.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString


                If _Status = "已完成" Then
                    e.CellStyle.ForeColor = Color.Blue
                ElseIf _Status = "进行中" Then
                    e.CellStyle.ForeColor = Color.Orange
                    '--------- add by 马跃平2018-03-23
                    Dim dgr As DataGridViewRow = dgvSampleProblem.Rows(e.RowIndex)
                    Dim obj As Object = dgr.Cells("ColExpFinishTime").Value
                    If Not obj Is Nothing Then
                        Dim ExpFinishTime As Date = Convert.ToDateTime(obj)
                        If ExpFinishTime < Convert.ToDateTime(Date.Now.ToString("yyyy-MM-dd")) Then
                            Me.dgvSampleProblem.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "延期"
                            dgr.DefaultCellStyle.BackColor = Color.Red
                            dgr.DefaultCellStyle.ForeColor = Color.White
                        End If
                    End If
                    '-----------------
                ElseIf _Status = "延期" Then
                    dgvSampleProblem.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
                    dgvSampleProblem.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                Else
                    e.CellStyle.ForeColor = Color.Black
                End If

            End If

        End If

    End Sub
#End Region
#Region "方法"
    ''' <summary>
    ''' 加载数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadSampleProblem(Optional ByVal type As Int16 = 0)
        Try
            Dim o_strSql As New StringBuilder
            Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim dt As New DataTable
            o_strSql.Append("select top 500 ProblemName,RDEngineer,CONVERT(nvarchar(10), a.SampleTime,121) SampleTime,SampleQty,NGQty,NGRate,c.TEXT as StatusName,ProblemDesc ")
            o_strSql.Append(",case when stage='1' then N'报价' when stage='2' then N'样品' when stage='3' then N'量产' else '' end stage")
            o_strSql.Append(",case when IsDrawingNG=1 then N'√' else '' end IsDrawingNG ,")
            o_strSql.Append(" case when IsMaterialNG=1 then N'√'  else ''  end IsMaterialNG,")
            o_strSql.Append(" case when IsCraftNG=1 then N'√'  else ''  end  IsCraftNG,")
            o_strSql.Append(" case when IsMouldNG =1 then N'√'  else ''  end IsMouldNG,")
            o_strSql.Append(" case when IsOtherNG=1 then  N'√'  else '' end IsOtherNG ")
            o_strSql.Append(" ,PersonLiable,TempCountermeasure,LongCountermeasure,TrackingSummary ")
            o_strSql.Append(" ,CONVERT(nvarchar(10), a.StartTime,121) StartTime,CONVERT(nvarchar(10), a.ExpFinishTime,121) as ExpFinishTime,CONVERT(nvarchar(10), a.ActFinishTime,121) as ActFinishTime ")
            o_strSql.Append(" ,case when UrgentState='Y' then '加急件'else '一般件'end UrgentState,FilePath,b.UserName,CONVERT(nvarchar(10), a.CreateTime,121) CreateTime, a.ProblemNo,a.Status,a.DutyEmail,isnull(a.BossEmail,'') BossEmail,isnull(a.BossEmailDept,'') BossEmailDept,isnull(a.BossEmailDeptChief,'') BossEmailDeptChief,a.BeOverdueNum  from m_SampleProblem_t a left join  ")
            o_strSql.Append(" m_Users_t b on b.UserID=a.CreateUser left join m_BaseData_t c on  c.ITEMKEY='SampleProblemStatus' and c.VALUE=a.Status   where a.Status<>'D' ")
            If type = 1 Then
                If Not String.IsNullOrEmpty(Me.txtProblemName.Text.Trim) Then
                    o_strSql.Append(" and  a.ProblemName like N'%" & Me.txtProblemName.Text.Trim & "%'")
                End If
                If Not String.IsNullOrEmpty(Me.txtRDEngineer.Text.Trim) Then
                    o_strSql.Append(" and a.RDEngineer like N'%" & Me.txtRDEngineer.Text.Trim & "%'")
                End If
                If Not String.IsNullOrEmpty(Me.txtS_SampleTime.Text.Trim) AndAlso Not String.IsNullOrEmpty(Me.txtE_SampleTime.Text.Trim) AndAlso ChkZhiYang.Checked = True Then
                    o_strSql.Append(" and a.SampleTime between '" & Me.txtS_SampleTime.Text.Trim & "' and  '" & Me.txtE_SampleTime.Text.Trim & "'")
                End If
                If Not String.IsNullOrEmpty(Me.txtPersonLiable.Text.Trim) Then
                    o_strSql.Append(" and a.PersonLiable  like N'%" & Me.txtPersonLiable.Text.Trim & "%'")
                End If
                If Not String.IsNullOrEmpty(Me.txtProblemDesc.Text.Trim) Then
                    o_strSql.Append(" and a.ProblemDesc  like N'%" & Me.txtProblemDesc.Text.Trim & "%'")
                End If
                If Not String.IsNullOrEmpty(Me.txtStartTime.Text.Trim) AndAlso Not String.IsNullOrEmpty(Me.txtEndTime.Text.Trim) AndAlso ChkKaiShi.Checked = True Then
                    o_strSql.Append(" and a.CreateTime between '" & Me.txtStartTime.Text.Trim & "' and  '" & Me.txtEndTime.Text.Trim & "'")
                End If
                If Not String.IsNullOrEmpty(Me.txtTempCountermeasure.Text.Trim) Then
                    o_strSql.Append(" and a.TempCountermeasure  like N'%" & Me.txtTempCountermeasure.Text.Trim & "%'")
                End If

                If Not String.IsNullOrEmpty(Me.txtLongCountermeasure.Text.Trim) Then
                    o_strSql.Append(" and a.LongCountermeasure  like N'%" & Me.txtLongCountermeasure.Text.Trim & "%'")
                End If

                If Not String.IsNullOrEmpty(Me.selStatus.SelectedValue.ToString) Then
                    If Me.selStatus.SelectedValue.ToString <> "P" Then
                        o_strSql.Append(" and a.Status ='" & Me.selStatus.SelectedValue.ToString & "'")
                        If Me.selStatus.SelectedValue.ToString = "I" Then
                            o_strSql.Append(" AND ExpFinishTime>=CONVERT(DATETIME,CONVERT(VARCHAR(10),GETDATE(),120))")
                        End If

                    Else
                        o_strSql.Append(" and a.Status ='I'   AND ExpFinishTime<CONVERT(DATETIME,CONVERT(VARCHAR(10),GETDATE(),120))")
                    End If

                End If
                If Not String.IsNullOrEmpty(Me.selStage.SelectedValue.ToString) Then
                    o_strSql.Append(" and a.stage ='" & Me.selStage.SelectedValue.ToString & "'")
                End If
                If Not String.IsNullOrEmpty(Me.txtTrackingSummary.Text.Trim) Then
                    o_strSql.Append(" and a.TrackingSummary  like N'%" & Me.txtTrackingSummary.Text.Trim & "%'")
                End If
                If Not String.IsNullOrEmpty(Me.txtUserName.Text.Trim) Then
                    o_strSql.Append(" and b.UserName  like N'%" & Me.txtUserName.Text.Trim & "%'")
                End If

                If Me.cbIsDrawingNG.Checked = True Then
                    o_strSql.Append(" and a.IsDrawingNG=1 ")
                End If
                If Me.cbIsMaterialNG.Checked = True Then
                    o_strSql.Append(" and a.IsMaterialNG=1 ")
                End If
                If Me.cbIsCraftNG.Checked = True Then
                    o_strSql.Append(" and a.IsCraftNG=1 ")
                End If
                If Me.cbIsMouldNG.Checked = True Then
                    o_strSql.Append(" and a.IsMouldNG=1 ")
                End If
                If Me.cbIsOtherNG.Checked = True Then
                    o_strSql.Append(" and a.IsOtherNG=1 ")
                End If
                If cmbSatus.Text = "一般件" Then
                    o_strSql.Append(" and UrgentState='N'")
                ElseIf cmbSatus.Text = "加急件" Then
                    o_strSql.Append(" and UrgentState='Y'")
                End If
            Else
                If Not String.IsNullOrEmpty(Me.txtStartTime.Text.Trim) AndAlso Not String.IsNullOrEmpty(Me.txtEndTime.Text.Trim) AndAlso ChkKaiShi.Checked = True Then
                    o_strSql.Append(" and a.CreateTime between '" & Me.txtStartTime.Text.Trim & "' and  '" & Me.txtEndTime.Text.Trim & "'")
                End If
            End If

            o_strSql.Append(" order by a.CreateTime desc ")

            dt = DAL.GetDataTable(o_strSql.ToString)
            Me.dgvSampleProblem.DataSource = dt
            Me.lbAcount.Text = dt.Rows.Count
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleProblem", "LoadSampleProblem()", "sys")
        End Try


    End Sub


    ''' <summary>
    ''' 预计完成日期已过，但未完成的邮件提醒责任人
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SeedMailToDutyList()
        Try
            Dim o_strSql As New StringBuilder
            Dim strSql As String = Nothing
            Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim dt As New DataTable
            Dim EmailTo As String = Nothing
            Dim EmailTile As String = Nothing
            Dim EmailBody As String = Nothing

            o_strSql.Append("select DutyEmail,ProblemName,CONVERT(nvarchar(10),ExpFinishTime,121)as ExpFinishTime,ProblemNo  from m_SampleProblem_t where Status<>'Y' and IsSeed=0 ")
            o_strSql.Append(" and CONVERT(nvarchar(10), ExpFinishTime,121)< CONVERT(nvarchar(10), getdate(),121) ")
            dt = DAL.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    If Not String.IsNullOrEmpty(dr(0).ToString) AndAlso dr(0).ToString.Length > 0 Then
                        EmailTo = dr(0).ToString
                        EmailTile = "RDN/品名：" & dr(1).ToString & ",制样解析备忘库过期提醒!"

                        EmailBody = "MES系统[制样解析备忘库]模块中，RDN/品名：" & dr(1).ToString & ",预计完成日期为" & dr(2).ToString & ",时间已过但仍然未完成,请于MES系统中[制样解析备忘库]模块中更新进度!"
                        SampleBusiness.SeedMail(EmailTo, EmailTile, EmailBody)
                        '更新邮件发送标识
                        strSql = "update m_SampleProblem_t set  IsSeed=1 where ProblemNo='" & dr(3).ToString & "'"
                        DAL.ExecSql(strSql)

                    End If
                Next
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleProblem", "SeedMailToDuty()", "sys")
        End Try
    End Sub


    ''' <summary>
    ''' 删除记录
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DeleteSampleProblem() As Boolean
        Dim o_strSql As New StringBuilder
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim ProblemNo As String = Nothing
        Try
            ProblemNo = Me.dgvSampleProblem.CurrentRow.Cells("ProblemNo").Value.ToString
            o_strSql.Append("UPDATE m_SampleProblem_t SET Status='D' WHERE ProblemNo='" & ProblemNo & "'")
            DAL.ExecSql(o_strSql.ToString)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleProblem", "DeleteSampleProblem()", "sys")
        End Try
    

        Return True
    End Function



    ''' <summary>
    ''' 设置菜单权限-用户权限设定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMenuRight()
        Me.toolAdd.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolAdd.Tag) = "YES", True, False)
        Me.toolEdit.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolEdit.Tag) = "YES", True, False)
        Me.toolDelete.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolDelete.Tag) = "YES", True, False)
    End Sub
#End Region
End Class