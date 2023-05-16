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
Imports System.Text.RegularExpressions

'--样品制样问题追踪明细
'--Create by :　黄广都
'--Create date :　2017/02/6
'--Update date :  
'--Ver : V01
Public Class FrmSampleProblemEdit

#Region "字段、属性"
    Private IsUpload As Boolean = False ''是否有上传
    Private FileNameStr As String = "" ''上传的文件名
    '服务器附件地址
    Dim ServerFilePath As String = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "Sample\SampleProblem\"
    '事件类型
    Private _ActionType As String
    Public Property ActionType() As String
        Get
            Return _ActionType
        End Get

        Set(ByVal Value As String)
            _ActionType = Value
        End Set
    End Property
    '责任人邮箱
    Private _DutyEmail As String = ""
    Public Property DutyEmail() As String
        Get
            Return _DutyEmail
        End Get

        Set(ByVal Value As String)
            _DutyEmail = Value
        End Set
    End Property

    '直属负责人邮箱
    Private _BossEmail As String = ""

    Public Property BossEmail() As String
        Get
            Return _BossEmail
        End Get
        Set(value As String)
            _BossEmail = value
        End Set
    End Property

    Private _BossEmailDept As String = ""

    ''' <summary>
    ''' 部级主管邮箱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BossEmailDept() As String
        Get
            Return _BossEmailDept
        End Get
        Set(value As String)
            _BossEmailDept = value
        End Set
    End Property

    Private _BossEmailDeptChief As String = ""

    ''' <summary>
    ''' 部级主管的直属主管
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BossEmailDeptChief() As String
        Get
            Return _BossEmailDeptChief
        End Get
        Set(value As String)
            _BossEmailDeptChief = value
        End Set
    End Property

    '网格dataGridViewRow
    Private _gridViewRow As DataGridViewRow
    Public Property GridViewRow() As DataGridViewRow
        Get
            Return _gridViewRow
        End Get

        Set(ByVal Value As DataGridViewRow)
            _gridViewRow = Value
        End Set
    End Property
#End Region
#Region "构造函数"

    Sub New(ByVal actionType As String, ByVal dataGridViewRow As DataGridViewRow)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me._ActionType = actionType
        Me._gridViewRow = dataGridViewRow
    End Sub
#End Region

#Region "窗体事件"
    Private Sub FrmSampleProblemEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SetControlsEnable()
        SampleManage.SampleBusiness.BindComboxStatus(Me.selStatus)
        SampleManage.SampleBusiness.BindComboxStage(Me.selStage)
        Me.txtProblemName.Focus()
        If Not Me._gridViewRow Is Nothing Then
            Me.txtProblemName.Text = Me._gridViewRow.Cells("ProblemName").Value.ToString
            Me.txtProblemNo.Text = Me._gridViewRow.Cells("ProblemNo").Value.ToString
            Me.txtRDEngineer.Text = Me._gridViewRow.Cells("RDEngineer").Value.ToString
            Me.txtSampleTime.Text = Me._gridViewRow.Cells("SampleTime").Value.ToString
            Me.txtSampleQty.Text = Me._gridViewRow.Cells("SampleQty").Value.ToString
            Me.txtNGQty.Text = Me._gridViewRow.Cells("NGQty").Value.ToString
            Me.txtNGRate.Text = Me._gridViewRow.Cells("NGRate").Value.ToString
            Me.txtProblemDesc.Text = Me._gridViewRow.Cells("ProblemDesc").Value.ToString
            Me.cbIsDrawingNG.Checked = IIf(Me._gridViewRow.Cells("IsDrawingNG").Value.ToString = "√", True, False)
            Me.cbIsMaterialNG.Checked = IIf(Me._gridViewRow.Cells("IsMaterialNG").Value.ToString = "√", True, False)
            Me.cbIsCraftNG.Checked = IIf(Me._gridViewRow.Cells("IsCraftNG").Value.ToString = "√", True, False)
            Me.cbIsMouldNG.Checked = IIf(Me._gridViewRow.Cells("IsMouldNG").Value.ToString = "√", True, False)
            Me.cbIsOtherNG.Checked = IIf(Me._gridViewRow.Cells("IsOtherNG").Value.ToString = "√", True, False)

            Me.txtPersonLiable.Text = Me._gridViewRow.Cells("PersonLiable").Value.ToString
            Me.txtTempCountermeasure.Text = Me._gridViewRow.Cells("TempCountermeasure").Value.ToString

            Me.txtLongCountermeasure.Text = Me._gridViewRow.Cells("LongCountermeasure").Value.ToString
            Me.txtTrackingSummary.Text = Me._gridViewRow.Cells("TrackingSummary").Value.ToString

            Me.txtStartTime.Text = Me._gridViewRow.Cells("StartTime").Value.ToString
            Me.txtExpFinishTime.Text = Me._gridViewRow.Cells("ColExpFinishTime").Value.ToString
            Me.txtActFinishTime.Text = Me._gridViewRow.Cells("ActFinishTime").Value.ToString

            Me.txtFilePath.Text = Me._gridViewRow.Cells("FilePath").Value.ToString
            Dim StatusName = Me._gridViewRow.Cells("StatusName").Value.ToString
            StatusName = IIf(StatusName = "延期", "进行中", StatusName)
            Me.selStatus.Text = StatusName
            Dim StageName = Me._gridViewRow.Cells("stage").Value.ToString
            Me.selStage.Text = StageName
            Me.DutyEmail = Me._gridViewRow.Cells("ColDutyEmail").Value
            Me.BossEmail = Me._gridViewRow.Cells("ColBossEmail").Value
            Me.BossEmailDept = Me._gridViewRow.Cells("ColBossEmailDept").Value
            Me.BossEmailDeptChief = Me._gridViewRow.Cells("ColBossEmailDeptChief").Value
            Dim UrgentState = Me._gridViewRow.Cells("UrgentState").Value
            If UrgentState = "加急件" Then
                rdoBtnY.Checked = True
            Else
                rdoBtnN.Checked = True
            End If
        End If

        'add by马跃平 2018-04-28 有一部分直属主管邮箱获取异常,在这里补上
        '        Dim sql = "SELECT * FROM dbo.m_SampleProblem_t" & vbCrLf &
        '        "WHERE Status='I' AND DutyEmail IS NOT NULL  AND ISNULL(BossEmail,'')='' "
        '        Dim dt = DbOperateReportUtils.GetDataTable(sql)
        '        For Each dr As DataRow In dt.Rows
        '            Dim DutyEmail = dr("DutyEmail").ToString.TrimEnd(";")
        '            Dim ProblemName = dr("ProblemName").ToString()
        '            Dim DutyEmailStr() = DutyEmail.Split(";")
        '            Dim BossEmail = "" '直属主管邮箱
        '            Dim BossEmailDept = "" '部级主管邮箱
        '            Dim BossEmailDeptChief = "" '处级主管邮箱
        '            For Each Str As String In DutyEmailStr
        '                sql = "SELECT distinct email  from V_EMPLOYEEONJOB where code in(" & vbCrLf &
        '"select directbossempcode from V_EMPLOYEEONJOB where  email='" & Str & "')"
        '                Dim obj = DBUtility.DbOracleForSpcHelperSQL.GetSingle(sql)
        '                If Not obj Is Nothing Then
        '                    BossEmail += obj.ToString() + ";"
        '                    sql = "SELECT distinct email  from V_EMPLOYEEONJOB where code in(" & vbCrLf &
        '"select directbossempcode from V_EMPLOYEEONJOB where  email='" & obj.ToString() & "') AND email is not null"
        '                    Dim obj1 = DBUtility.DbOracleForSpcHelperSQL.GetSingle(sql)
        '                    If Not obj1 Is Nothing Then
        '                        BossEmailDept += obj1.ToString() + ";"
        '                        sql = "SELECT distinct email  from V_EMPLOYEEONJOB where code in(" & vbCrLf &
        '"select directbossempcode from V_EMPLOYEEONJOB where  email='" & obj1.ToString() & "') AND email is not null"
        '                        Dim obj2 = DBUtility.DbOracleForSpcHelperSQL.GetSingle(sql)
        '                        If Not obj2 Is Nothing Then
        '                            BossEmailDeptChief += obj2.ToString() + ";"
        '                        End If
        '                    End If
        '                End If
        '            Next
        '            DbOperateUtils.ExecSQL("update m_SampleProblem_t set BossEmail='" & BossEmail & "',BossEmailDept='" & BossEmailDept & "',BossEmailDeptChief='" & BossEmailDeptChief & "' where ProblemName=N'" & ProblemName & "'")
        '        Next
    End Sub


    '上传附件
    Private Sub btnUpdata_Click(sender As Object, e As EventArgs) Handles btnUpdata.Click
        btnUpdata.Enabled = False
        Dim ServerFile As String = ""
        Dim FileName As String = ""
        Dim FileDirectory As String = ""
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            FileName = Now.ToString("yyyyMMddHHmmss") & "_" & System.IO.Path.GetFileName(OpenFileDialog1.SafeFileNames(0).ToString)
            FileDirectory = Path.Combine(System.IO.Path.GetDirectoryName(OpenFileDialog1.FileName), FileName)

            Me.txtFilePath.Text = FileDirectory

            IsUpload = True
            Try
                Dim uploadFilePath As String = Me.txtFilePath.Text.Trim
                If System.IO.Directory.Exists(ServerFilePath) = False Then
                    Directory.CreateDirectory(ServerFilePath)
                End If
                FileNameStr = FileName
                ServerFile = Path.Combine(ServerFilePath, FileNameStr)
                ServerFile = Replace(ServerFile, " ", "") 'add by 马跃平 2018-05-07
                File.Copy(OpenFileDialog1.FileName, ServerFile, True)
            Catch comException As System.Runtime.InteropServices.COMException
                MessageBox.Show(comException.Message)
            End Try
            Cursor.Current = Cursors.Default
        End If
        btnUpdata.Enabled = True
    End Sub
    '预览附件
    Private Sub btnViewFile_Click(sender As Object, e As EventArgs) Handles btnViewFile.Click
        If Me.txtFilePath.Text = "" Then
            Me.lblMsg.Text = "暂无附件可预览!"
            Exit Sub
        End If
        Try
            Dim OpenFilePath As String = Path.Combine(ServerFilePath, System.IO.Path.GetFileName(Me.txtFilePath.Text.Trim))
            OpenFilePath = Replace(OpenFilePath, " ", "")
            System.Diagnostics.Process.Start(OpenFilePath)
        Catch ex As Exception
            MessageBox.Show("预览附件发生异常!")
        End Try

    End Sub
    '清空附件
    Private Sub txtFilePath_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtFilePath.MouseDoubleClick
        Me.txtFilePath.Text = ""
    End Sub


    Private Sub txtSampleQty_TextChanged(sender As Object, e As EventArgs) Handles txtSampleQty.TextChanged

        If Not String.IsNullOrEmpty(Me.txtSampleQty.Text.Trim) Then
            SetNgRate()
        End If

    End Sub

    Private Sub txtNGQty_TextChanged(sender As Object, e As EventArgs) Handles txtNGQty.TextChanged
        If Not String.IsNullOrEmpty(Me.txtNGQty.Text.Trim) Then
            SetNgRate()
        End If
    End Sub
    Private Sub selStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles selStatus.SelectedIndexChanged
        If Not Me.selStatus.SelectedValue Is Nothing Then
            If Me.selStatus.SelectedValue.ToString = "Y" Then
                Me.txtActFinishTime.Text = Now.ToShortDateString
            Else
                Me.txtActFinishTime.Text = ""
            End If
        End If
    End Sub
    ''' <summary>
    ''' 选择责任人
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSelDuty_Click(sender As Object, e As EventArgs) Handles btnSelDuty.Click
        'Dim frmPic As New FrmSelectPIC()
        Dim frmPic As New FrmSelectPICNew()
        Dim _DutyUser As New StringBuilder
        Dim _Email As New StringBuilder
        frmPic.DutyEmail = Me.DutyEmail
        If frmPic.ShowDialog() = Windows.Forms.DialogResult.Yes Then
            Me.lblMsg.Text = "加载负责人直属主管,部级主管,处级主管邮箱,请稍后...."
            Me.Cursor = Cursors.WaitCursor
            'For Each row As DataGridViewRow In frmPic.dgvPIC.Rows
            '    If Not row.Cells(0).Value Is Nothing Then
            '        If row.Cells(0).Value.ToString = "Y" Then
            '            _DutyUser.Append(row.Cells(1).Value.ToString() & ";")
            '            _Email.Append(row.Cells(4).Value.ToString() & ";")
            '        End If
            '    End If
            'Next
            'add by 马跃平 2018-03-26
            Me.BossEmail = ""
            Me.BossEmailDept = ""
            Me.BossEmailDeptChief = ""
            For Each row As DataGridViewRow In frmPic.dgvSelect.Rows
                _DutyUser.Append(row.Cells(2).Value.ToString() & ";")
                _Email.Append(row.Cells(3).Value.ToString() & ";")
                Dim BossEmpNO As String = row.Cells(4).Value.ToString
                'add by 马跃平 2018-03-27
                Dim ds As DataSet = DBUtility.DbOracleForSpcHelperSQL.Query("select email,code from V_EMPLOYEEONJOB where  code=UPPER('" & BossEmpNO & "')")
                If ds.Tables.Count > 0 Then
                    Me.BossEmail = Me.BossEmail + ds.Tables(0).Rows(0)(0).ToString() + ";"

                    Dim code = DBUtility.DbOracleForSpcHelperSQL.Query("select directbossempcode from V_EMPLOYEEONJOB where  code='" & ds.Tables(0).Rows(0)(1).ToString() & "'").Tables(0).Rows(0)(0)
                    Dim sql = "SELECT distinct email,code  from V_EMPLOYEEONJOB where code='" & code & "'"
                    Dim dt = DBUtility.DbOracleForSpcHelperSQL.Query(sql).Tables(0)
                    If dt.Rows.Count > 0 Then
                        Me.BossEmailDept = Me.BossEmailDept + dt.Rows(0)(0).ToString() + ";"

                        code = DBUtility.DbOracleForSpcHelperSQL.Query("select directbossempcode from V_EMPLOYEEONJOB where  code='" & dt.Rows(0)(1).ToString() & "'").Tables(0).Rows(0)(0)

                        sql = "SELECT distinct email  from V_EMPLOYEEONJOB where code='" & code & "'"
                        Dim obj1 As Object = DBUtility.DbOracleForSpcHelperSQL.GetSingle(sql)
                        If Not obj1 Is Nothing Then
                            Me.BossEmailDeptChief = Me.BossEmailDeptChief + obj1.ToString() + ";"
                        End If
                    End If
                End If
                '----end 
                Me.Cursor = Cursors.Default
                Me.lblMsg.Text = "加载邮箱OK!"
            Next
            Me.txtPersonLiable.Text = _DutyUser.ToString.Substring(0, _DutyUser.ToString.Length - 1)
            If Not _Email Is Nothing Then
                Me._DutyEmail = _Email.ToString

            End If
        End If
    End Sub
#End Region

#Region "菜单事件"
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If CheckInput() = True Then
                If SaveData() = True Then
                    '提示
                    MessageUtils.ShowInformation("保存成功！")
                    ' ''邮件提醒
                    If Me.ActionType = "New" Then
                        SeedEmailToDuty()
                    End If


                    '退出
                    Me.DialogResult = Windows.Forms.DialogResult.Yes
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            Me.lblMsg.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleProblemEdit", "btnSave_Click()", "sys")
        End Try
        
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
#End Region

#Region "方法"

    ''' <summary>
    ''' 保存数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveData() As Boolean
        Dim o_strSql As New StringBuilder()
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        Dim IsDrawingNG As Integer = 0
        Dim IsMaterialNG As Integer = 0
        Dim IsCraftNG As Integer = 0
        Dim IsMouldNG As Integer = 0
        Dim IsOtherNG As Integer = 0
        Dim SampleQty As Integer = 0
        Dim NGQty As Integer = 0
        Dim NGRate As Double = 0.0
        Dim ActFinishDate As String = Nothing
        Dim ProblemNo As String = Nothing
        Dim FilePath As String = ""

        IsDrawingNG = IIf(Me.cbIsDrawingNG.Checked = True, 1, 0)
        IsMaterialNG = IIf(Me.cbIsMaterialNG.Checked = True, 1, 0)
        IsCraftNG = IIf(Me.cbIsCraftNG.Checked = True, 1, 0)
        IsMouldNG = IIf(Me.cbIsMouldNG.Checked = True, 1, 0)
        IsOtherNG = IIf(Me.cbIsOtherNG.Checked = True, 1, 0)

        Dim UrgentState = ""
        If rdoBtnY.Checked = True Then
            UrgentState = "Y"
        Else
            UrgentState = "N"
        End If

        Try
            If Not String.IsNullOrEmpty(Me.txtSampleQty.Text.Trim) Then
                SampleQty = CInt(Me.txtSampleQty.Text.Trim)
            End If
            If Not String.IsNullOrEmpty(Me.txtNGQty.Text.Trim) Then
                NGQty = CInt(Me.txtNGQty.Text.Trim)
            End If
            If Not String.IsNullOrEmpty(Me.txtNGRate.Text.Trim) Then
                NGRate = CDbl(Me.txtNGRate.Text.Trim)
            End If

            'add by 马跃平 2018-03-26
            Dim CreateUserEmail As String = "" '建立人邮箱
            Dim ds As DataSet = DBUtility.DbOracleForSpcHelperSQL.Query("select email from V_EMPLOYEEONJOB where  code=UPPER('" & UserID & "')")
            If ds.Tables.Count > 0 Then
                CreateUserEmail = ds.Tables(0).Rows(0)(0).ToString()
            End If
            '----end 

            Dim Factory = VbCommClass.VbCommClass.Factory
            Dim Profitcenter = VbCommClass.VbCommClass.profitcenter

            If Me.ActionType = "New" Then
                If Me.selStatus.SelectedValue.ToString = "Y" Then
                    ActFinishDate = Me.txtActFinishTime.Text.Trim
                End If
                '获取最新单号
                o_strSql.Append(" declare @No nvarchar(20);declare @prevNo nvarchar(20);set @No=convert(varchar(6), getdate(),112); ")
                o_strSql.Append(" select top 1 @prevNo=ProblemNo from m_SampleProblem_t where convert(varchar(6),CreateTime,112)=convert(varchar(6), getdate(),112) order by CreateTime desc;")
                o_strSql.Append(" if(@prevNo is null) begin set @No=@No+'00001'; end   ")
                o_strSql.Append("  else  begin   set @prevNo = cast((cast(right(@prevNo,5) as int) + 1) AS varchar(5));  set @prevNo=replicate('0',5-len(@prevNo))+ @prevNo;  set @No=@No+@prevNo; end ")

                '样品制样新增
                o_strSql.Append("INSERT INTO dbo.m_SampleProblem_t ")
                o_strSql.Append(" (ProblemNo ,ProblemName,RDEngineer,SampleTime,SampleQty,NGQty,NGRate ")
                o_strSql.Append("  ,IsDrawingNG,IsMaterialNG,IsCraftNG,IsMouldNG,IsOtherNG,ProblemDesc")
                o_strSql.Append(" ,PersonLiable,StartTime,ExpFinishTime,TempCountermeasure,LongCountermeasure,TrackingSummary")
                o_strSql.Append("  ,FilePath,Status,CreateTime,CreateUser,DutyEmail,CreateUserEmail,BossEmail,BossEmailDept,BossEmailDeptChief,UrgentState,Factory,Profitcenter,stage)")
                o_strSql.Append(String.Format(" VALUES(@No,N'{0}',N'{1}','{2}','{3}','{4}','{5}'",
                                              Me.txtProblemName.Text.Trim(), txtRDEngineer.Text.Trim, Me.txtSampleTime.Text.Trim, SampleQty, NGQty, NGRate))

                o_strSql.Append(String.Format(",'{0}','{1}','{2}','{3}','{4}',N'{5}'", IsDrawingNG, IsMaterialNG, IsCraftNG, IsMouldNG, IsOtherNG, txtProblemDesc.Text.Trim))

                o_strSql.Append(String.Format(" ,N'{0}','{1}','{2}',N'{3}',N'{4}',N'{5}'", txtPersonLiable.Text.Trim, txtStartTime.Text.Trim, txtExpFinishTime.Text.Trim,
                                               txtTempCountermeasure.Text.Trim, txtLongCountermeasure.Text.Trim, txtTrackingSummary.Text.Trim))

                o_strSql.Append(String.Format(" ,N'{0}','{1}',getdate(),'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", FileNameStr, Me.selStatus.SelectedValue.ToString, UserID, Me.DutyEmail, CreateUserEmail, BossEmail, BossEmailDept, BossEmailDeptChief, UrgentState, Factory, Profitcenter, Me.selStage.SelectedValue.ToString))

                If Not String.IsNullOrEmpty(Me.txtActFinishTime.Text.Trim) Then
                    o_strSql.Append("  update  m_SampleProblem_t set ActFinishTime='" & Me.txtActFinishTime.Text.Trim & "' where ProblemNo=@No")
                End If

            Else
                Dim tempTime As String = Me.GridViewRow.Cells("ActFinishTime").Value.ToString

                If tempTime <> Me.txtActFinishTime.Text.Trim AndAlso Me.selStatus.SelectedValue.ToString = "Y" Then
                    ActFinishDate = Now.ToShortDateString
                End If
                FilePath = IIf(IsUpload = True, FileNameStr, Me.txtFilePath.Text.Trim)

                ProblemNo = txtProblemNo.Text.Trim
                o_strSql.Append(String.Format(" update m_SampleProblem_t set ProblemName=N'{0}',RDEngineer=N'{1}',SampleTime='{2}',SampleQty='{3}',NGQty='{4}',NGRate='{5}'",
                                              Me.txtProblemName.Text.Trim, Me.txtRDEngineer.Text.Trim, Me.txtSampleTime.Text.Trim, SampleQty, NGQty, NGRate))
                o_strSql.Append(String.Format(",IsDrawingNG='{0}',IsMaterialNG='{1}',IsCraftNG='{2}',IsMouldNG='{3}',IsOtherNG='{4}',ProblemDesc=N'{5}'", IsDrawingNG, IsMaterialNG, IsCraftNG, IsMouldNG, IsOtherNG, Me.txtProblemDesc.Text.Trim))
                o_strSql.Append(String.Format(",PersonLiable=N'{0}',StartTime='{1}',ExpFinishTime='{2}',TempCountermeasure=N'{3}',LongCountermeasure=N'{4}',TrackingSummary=N'{5}' ", Me.txtPersonLiable.Text.Trim,
                                             Me.txtStartTime.Text.Trim, Me.txtExpFinishTime.Text.Trim, Me.txtTempCountermeasure.Text.Trim, Me.txtLongCountermeasure.Text.Trim, Me.txtTrackingSummary.Text.Trim))
                o_strSql.Append(String.Format(" ,FilePath=N'{0}',Status='{1}',ModifyUserId='{2}',ModifyTime=GETDATE(),BossEmail='{4}',BossEmailDept='{5}',BossEmailDeptChief='{6}',UrgentState='{7}',stage='{8}' WHERE ProblemNo='{3}'", FilePath, Me.selStatus.SelectedValue.ToString, UserID, ProblemNo, BossEmail, BossEmailDept, BossEmailDeptChief, UrgentState, Me.selStage.SelectedValue.ToString))

                If Not String.IsNullOrEmpty(Me.txtActFinishTime.Text.Trim) Then
                    o_strSql.Append("  update  m_SampleProblem_t set ActFinishTime='" & Me.txtActFinishTime.Text.Trim & "' where ProblemNo='" & ProblemNo & "'")
                End If

                If Not String.IsNullOrEmpty(Me.DutyEmail) Then
                    o_strSql.Append(String.Format(" update m_SampleProblem_t set DutyEmail=N'{0}' where  ProblemNo='{1}'", Me.DutyEmail, ProblemNo))
                End If
            End If

            DbOperateUtils.ExecSQL(o_strSql.ToString)

        Catch ex As Exception

            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleProblemEdit", "SaveData()", "sys")
            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' 校验是否为正数
    ''' </summary>
    Private Function checkIsNumber(ByVal values As String) As Boolean
        Dim b As Boolean = False
        Dim reg As Regex = New Regex("^(\-|\+)?\d+(\.\d+)?$")
        If reg.IsMatch(values) = False Then
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' 校验输入项
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckInput() As Boolean
        'RDN/品名
        If String.IsNullOrEmpty(Me.txtProblemName.Text.Trim()) Then
            Me.lblMsg.Text = "请输入RDN/品名!"
            Me.txtProblemName.Focus()
            Return False
        End If
        '制样日期
        If String.IsNullOrEmpty(Me.txtSampleTime.Text.Trim()) Then
            Me.lblMsg.Text = "请输入制样日期!"
            Me.txtSampleTime.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(txtExpFinishTime.Text.Trim()) Then
            Me.lblMsg.Text = "请选择预计完成日期"
            txtExpFinishTime.Focus()
            Return False
        End If

        '研发工程师
        If String.IsNullOrEmpty(Me.txtRDEngineer.Text.Trim()) Then
            Me.lblMsg.Text = "请输入研发工程师!"
            Me.txtRDEngineer.Focus()
            Return False
        End If
        '问题描述
        If String.IsNullOrEmpty(Me.txtProblemDesc.Text.Trim()) Then
            Me.lblMsg.Text = "请输入问题描述!"
            Me.txtProblemDesc.Focus()
            Return False
        End If

        If Not String.IsNullOrEmpty(Me.txtSampleQty.Text.Trim()) AndAlso checkIsNumber(Me.txtSampleQty.Text.Trim) = False Then
            Me.lblMsg.Text = "制样数量请输入数值!"
            Me.txtSampleQty.Focus()
            Return False
        End If
        If Not String.IsNullOrEmpty(Me.txtNGQty.Text.Trim()) AndAlso checkIsNumber(Me.txtNGQty.Text.Trim) = False Then
            Me.lblMsg.Text = "不良数量请输入数值!"
            Me.txtNGQty.Focus()
            Return False
        End If
        If Not String.IsNullOrEmpty(Me.txtNGRate.Text.Trim()) AndAlso checkIsNumber(Me.txtNGRate.Text.Trim) = False Then
            Me.lblMsg.Text = "不良率请输入数值!"
            Me.txtNGRate.Focus()
            Return False
        End If

        If Not String.IsNullOrEmpty(Me.txtSampleQty.Text.Trim()) AndAlso Not String.IsNullOrEmpty(Me.txtNGQty.Text.Trim()) Then
            If CDbl(Me.txtSampleQty.Text.Trim) < CDbl(Me.txtNGQty.Text.Trim) Then
                Me.lblMsg.Text = "样品数量不能小于不良数量!"
                Me.txtSampleQty.Focus()
                Return False
            End If
        End If
        '责任人
        If String.IsNullOrEmpty(Me.txtPersonLiable.Text.Trim()) Then
            Me.lblMsg.Text = "请输入责任人!"
            Me.txtPersonLiable.Focus()
            Return False
        End If
        '追踪状态
        If String.IsNullOrEmpty(Me.selStatus.SelectedValue.Trim()) Then
            Me.lblMsg.Text = "请选择追踪状态!"
            Me.selStatus.Focus()
            Return False
        End If
        If cbIsDrawingNG.Checked Or cbIsMaterialNG.Checked Or cbIsCraftNG.Checked Or cbIsMouldNG.Checked Or cbIsOtherNG.Checked Then
            Return True
        Else
            Me.lblMsg.Text = "请勾选一个问题类型!"
            Return False
        End If

        If String.IsNullOrEmpty(Me.BossEmail.Trim) Then
            Me.lblMsg.Text = "获取负责人直属主管邮箱失败,请重新选择获取"
            Return False
        End If

        If String.IsNullOrEmpty(Me.BossEmailDept.Trim) Then
            Me.lblMsg.Text = "获取部级主管邮箱失败,请重新选择获取"
            Return False
        End If

        If String.IsNullOrEmpty(Me.BossEmailDeptChief.Trim) Then
            Me.lblMsg.Text = "获取处级主管邮箱失败,请重新选择获取"
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 设置不良率
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetNgRate()
        Dim sampleQty As Double = 0.0
        Dim ngQty As Double = 0.0

        If Not String.IsNullOrEmpty(Me.txtSampleQty.Text.Trim) AndAlso checkIsNumber(Me.txtSampleQty.Text.Trim) = True Then
            sampleQty = CDbl(Me.txtSampleQty.Text.Trim)

        End If
        If Not String.IsNullOrEmpty(Me.txtNGQty.Text.Trim) AndAlso checkIsNumber(Me.txtNGQty.Text.Trim) = True Then
            ngQty = CDbl(Me.txtNGQty.Text.Trim)
        End If
        If sampleQty > 0 Then
            Me.txtNGRate.Text = System.Math.Round(ngQty / sampleQty * 100.0, 2)
        End If

    End Sub


    ''' <summary>
    ''' 发送邮件至责任人
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SeedEmailToDuty()
        'Dim Email As String = "Byron.Huang@luxshare-ict.com;" & Me.DutyEmail
        Dim Email As String = ""
        Dim Title As String = "RDN/品名：" & Me.txtProblemName.Text.Trim & ",制样解析备忘库消息提醒!"
        Dim EmailBody As New StringBuilder

        Dim sql = "select * from m_SampleProblem_t where id=(select max(id) from m_SampleProblem_t)"
        Dim dt = DbOperateUtils.GetDataTable(sql)
        If dt.Rows.Count > 0 Then
            Email = dt.Rows(0)("DutyEmail") + dt.Rows(0)("CreateUserEmail")
            EmailBody.AppendLine("问题描述:" + dt.Rows(0)("ProblemDesc") + "<br/><br/>")
            EmailBody.AppendLine("临时对策:" + dt.Rows(0)("TempCountermeasure") + "<br/><br/>")
            EmailBody.AppendLine("长期对策:" + dt.Rows(0)("LongCountermeasure") + "<br/><br/>")
            EmailBody.AppendLine("进度追踪和结论:" + dt.Rows(0)("TrackingSummary") + "<br/><br/>")
            Dim FilePath = Replace(dt.Rows(0)("FilePath").ToString(), " ", "")
            EmailBody.AppendLine("附件:<a href='\\192.168.20.123\Sample\SampleProblem\" & FilePath & "'>" & FilePath & "</a>")
        End If

        'EmailBody.Append("当前有一笔新的制样解析备忘库记录,预计完成日期" & Me.txtExpFinishTime.Text.Trim & ",请于MES系统中[制样解析备忘库]模块中查看!")
        SampleBusiness.SeedMail(Email, Title, EmailBody.ToString)
    End Sub
   

    ''' <summary>
    ''' 设置控件状态
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetControlsEnable()
        Dim _Enable As Boolean = False
        If Me.ActionType = "View" Then
            Me.btnSave.Enabled = False
            Me.btnUpdata.Enabled = False
            'Me.btnViewFile.Enabled = True
            Me.btnSelDuty.Enabled = False
            _Enable = False

        Else
            Me.btnSave.Enabled = True
            Me.btnUpdata.Enabled = True
            'Me.btnViewFile.Enabled = True
            Me.btnSelDuty.Enabled = True
            _Enable = True
        End If
        For Each contr As Control In Me.Panel1.Controls

            If (TypeOf contr Is System.Windows.Forms.TextBox) Then

                CType(contr, System.Windows.Forms.TextBox).ReadOnly = Not _Enable

                Me.txtProblemNo.ReadOnly = True
                Me.txtActFinishTime.ReadOnly = True
                Me.txtPersonLiable.ReadOnly = True
                Me.txtFilePath.ReadOnly = True
            End If
            If (TypeOf contr Is System.Windows.Forms.RichTextBox) Then
                CType(contr, System.Windows.Forms.RichTextBox).ReadOnly = Not _Enable
            End If
            If (TypeOf contr Is System.Windows.Forms.DateTimePicker) Then
                CType(contr, System.Windows.Forms.DateTimePicker).Enabled = _Enable
            End If
            If (TypeOf contr Is System.Windows.Forms.ComboBox) Then
                CType(contr, System.Windows.Forms.ComboBox).Enabled = _Enable
            End If
            If (TypeOf contr Is System.Windows.Forms.CheckBox) Then
                CType(contr, System.Windows.Forms.CheckBox).Enabled = _Enable
            End If

            If (TypeOf contr Is System.Windows.Forms.RadioButton) Then
                CType(contr, System.Windows.Forms.RadioButton).Enabled = _Enable
            End If
        Next
    End Sub


#End Region


 

 




   
 
  
    Private Sub txtExpFinishTime_ValueChanged(sender As Object, e As EventArgs) Handles txtExpFinishTime.ValueChanged
        txtExpFinishTime.CustomFormat = "yyyy-MM-dd"
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

End Class