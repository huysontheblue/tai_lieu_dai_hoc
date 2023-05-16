Imports MainFrame
Imports MainFrame.SysCheckData
Imports SysBasicClass
Imports DBUtility
Imports System.IO

Public Class FrmAddBOFToolListMain

    Private _PartID As String
    ''' <summary>
    ''' 料号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PartID() As String
        Get
            Return _PartID
        End Get
        Set(ByVal value As String)
            _PartID = value
        End Set
    End Property

    ''' <summary>
    ''' 版本
    ''' </summary>
    ''' <remarks></remarks>
    Private _Verson As String
    Public Property Version() As String
        Get
            Return _Verson
        End Get
        Set(ByVal value As String)
            _Verson = value
        End Set
    End Property

    Private _FilePathName As String  '开具工治具文件名
    Public Property FilePathName() As String
        Get
            Return _FilePathName
        End Get
        Set(ByVal value As String)
            _FilePathName = value
        End Set
    End Property

    Private _OP As String = "Add"
    Public Property OP() As String
        Get
            Return _OP
        End Get
        Set(ByVal value As String)
            _OP = value
        End Set
    End Property


    Private _FEDutyEmail As String = ""
    ''' <summary>
    ''' 责任人邮箱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FEDutyEmail() As String
        Get
            Return _FEDutyEmail
        End Get

        Set(ByVal Value As String)
            _FEDutyEmail = Value
        End Set
    End Property

    Private _EquDutyEmail As String = ""
    Public Property EquDutyEmail() As String
        Get
            Return _EquDutyEmail
        End Get

        Set(ByVal Value As String)
            _EquDutyEmail = Value
        End Set
    End Property

    Private _PDDutyEmail As String = ""
    Public Property PDDutyEmail() As String
        Get
            Return _PDDutyEmail
        End Get

        Set(ByVal Value As String)
            _PDDutyEmail = Value
        End Set
    End Property

    Private DrawingPath As String = "\\192.168.20.123\SFCShare\BOFPicture"

    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub
    Dim ModelMain As BOFToolListMainModel = New BOFToolListMainModel()

    Private Sub FrmAddBOFToolListMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If OP = "Modify" Then
            Dim dt As DataTable = DbOperateUtils.GetDataTable("select * from   m_BOFToolList_t where partid=N'" & PartID & "' AND Version='" & Version & "' ")
            txtPartID.Text = dt.Rows(0)("partid").ToString()
            ModelMain.PartID = txtPartID.Text.Trim()
            txtCustName.Text = dt.Rows(0)("CustName").ToString()
            ModelMain.CustName = txtCustName.Text.Trim()
            txtProductName.Text = dt.Rows(0)("ProductName").ToString()
            ModelMain.ProductName = txtProductName.Text.Trim()
            txtShape.Text = dt.Rows(0)("Shape").ToString()
            ModelMain.Shape = txtShape.Text.Trim()
            txtPIEName.Text = dt.Rows(0)("PIEName").ToString()
            ModelMain.PIEName = txtPIEName.Text.Trim()
            txtFEName.Text = dt.Rows(0)("FEName").ToString()
            ModelMain.FEName = txtFEName.Text.Trim()

            txtEquName.Text = dt.Rows(0)("EquName").ToString()
            ModelMain.EquName = txtEquName.Text.Trim()

            txtPDName.Text = dt.Rows(0)("PDName").ToString()
            ModelMain.PDName = txtPDName.Text.Trim()

            txtVersion.Text = dt.Rows(0)("Version").ToString()
            ModelMain.Version = txtVersion.Text.Trim()
            txtDescription.Text = dt.Rows(0)("Description").ToString()
            ModelMain.Description = txtDescription.Text.Trim()
            txtDocID.Text = dt.Rows(0)("DocID").ToString()
            ModelMain.InTime = Date.Parse(dt.Rows(0)("InTime"))
            dtpFETargetDate.Text = dt.Rows(0)("FETargetDate").ToString()
            Me.FE_EmpNo = dt.Rows(0)("FEEmpNo").ToString()
            Dim UrgentState = dt.Rows(0)("UrgentState").ToString()
            Me.FEDutyEmail = dt.Rows(0)("FEDutyEmail").ToString()
            Me.FEDutyBossEmail = dt.Rows(0)("FEDutyBossEmail").ToString()
            Me.BossEmailDept = dt.Rows(0)("BossEmailDept").ToString()
            Me.BossEmailDeptChief = dt.Rows(0)("BossEmailDeptChief").ToString()
            Me.EquDutyEmail = dt.Rows(0)("EquDutyEmail").ToString()
            Me.EquDutyBossEmail = dt.Rows(0)("EquDutyBossEmail").ToString()
            Me.PDDutyEmail = dt.Rows(0)("PDDutyEmail").ToString()
            Me.PDDutyBossEmail = dt.Rows(0)("PDDutyBossEmail").ToString()
            txtFIlePath.Text = DbOperateUtils.DBNullToStr(dt.Rows(0)("BOFFile").ToString())
            If UrgentState = "Y" Then
                rdoBtnY.Checked = True
            Else
                rdoBtnN.Checked = True
            End If

        Else
            txtPIEName.Text = VbCommClass.VbCommClass.UseName
            Me.Text = "新增BOF清单主档"
            Me.txtDocID.Text = getFileNO()
        End If
    End Sub

#Region "非法数据提交验证"
    ''' <summary>
    ''' 非法数据提交验证
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckData() As Boolean
        Dim yy = True
        Dim dt = DbOperateUtils.GetDataTable("select PartID,Version from m_BOFToolList_t where PartID='" & txtPartID.Text.Trim() & "' and Version='" & txtVersion.Text.Trim() & "'")
        Try
            If String.IsNullOrEmpty(txtPartID.Text.Trim()) Then
                MessageUtils.ShowError("料号不能为空!")
                yy = False
            ElseIf String.IsNullOrEmpty(txtCustName.Text.Trim()) Then
                MessageUtils.ShowError("客户不能为空!")
                yy = False
            ElseIf String.IsNullOrEmpty(txtVersion.Text.Trim()) Then
                MessageUtils.ShowError("版本不能为空!")
                yy = False
            ElseIf String.IsNullOrEmpty(txtPIEName.Text.Trim()) Then
                MessageUtils.ShowError("PIE不能为空!")
                yy = False
            ElseIf String.IsNullOrEmpty(txtFEName.Text.Trim()) Then
                MessageUtils.ShowError("FE不能为空!")
                yy = False
            ElseIf String.IsNullOrEmpty(txtShape.Text.Trim()) Then
                MessageUtils.ShowError("形态不能为空!")
                yy = False
            ElseIf String.IsNullOrEmpty(dtpFETargetDate.Text.Trim()) Then
                MessageUtils.ShowError("FE完成日期不能为空!")
                yy = False
                'ElseIf DbOracleForSpcHelperSQL.GetSingle("SELECT email FROM v_employeeonjob   where name='" & txtPIEName.Text.Trim() & "'  and email is not null") Is Nothing Then
                '    MessageUtils.ShowError("立讯不存在PIE用户:" + txtPIEName.Text.Trim())
                '    yy = False
                'ElseIf DbOracleForSpcHelperSQL.GetSingle("SELECT email FROM v_employeeonjob   where name='" & txtFEName.Text.Trim() & "'  and email is not null") Is Nothing Then
                '    MessageUtils.ShowError("立讯不存在FE用户:" + txtFEName.Text.Trim())
                '    yy = False
            ElseIf (dt.Rows.Count > 0 And OP = "Add") Then
                MessageUtils.ShowError("BOF治具清单中,料号:" + txtPartID.Text.Trim() + ",已经存在版本:" + txtVersion.Text.Trim())
                yy = False
            End If
        Catch ex As Exception
            MessageUtils.ShowError("Check数据出现异常:" & vbCrLf & "" + ex.Message)
            yy = False
        End Try
        Return yy
    End Function
#End Region

#Region "自动生成文件编号"
    '''<summary>
    ''' 自动生成文件编号
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getFileNO() As String
        Dim FileNO = ""
        Dim sb = New System.Text.StringBuilder()
        '获取最新文件编码:DOC+yy+10位流水码
        'sb.Append(" declare @No nvarchar(20);declare @prevNo nvarchar(20);declare @prefix nvarchar(20);")
        'sb.Append(" set @No=right(DATEPART(YEAR,getdate()),2);set @prefix='BOF' ;")
        'sb.Append(" select top 1 @prevNo=DocID from m_BOFToolList_t where  right(DATEPART(YEAR,InTime),2) =right(DATEPART(YEAR,getdate()),2)   and isnull(DocID,'')<>'' order by InTime desc; ")
        'sb.Append(" if(@prevNo is null) begin  set @No=@prefix+@No+'-00000001'; End")
        'sb.Append(" else begin set @prevNo = cast((cast(right(@prevNo,8) as int) + 1) AS varchar(10));")
        'sb.Append("  set @prevNo='-'+replicate('0',8-len(@prevNo))+ @prevNo;  ")
        'sb.Append(" set @No=@prefix+@No+@prevNo; End select @No")
        sb.AppendLine("exec Proc_getNO 'm_BOFToolList_t','BOF','DocID'")
        FileNO = MainFrame.DbOperateUtils.GetDataTable(sb.ToString()).Rows(0)(0).ToString
        Return FileNO
    End Function
#End Region

    Private _FE_EmpNo As String = ""
    ''' <summary>
    ''' FE负责人工号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FE_EmpNo() As String
        Get
            Return Me._FE_EmpNo
        End Get
        Set(value As String)
            Me._FE_EmpNo = value
        End Set
    End Property

    Private _FEDutyBossEmail As String
    ''' <summary>
    ''' FE负责人课长邮箱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FEDutyBossEmail() As String
        Get
            Return _FEDutyBossEmail
        End Get
        Set(value As String)
            _FEDutyBossEmail = value
        End Set
    End Property

    Private _BossEmailDept As String
    ''' <summary>
    ''' FE负责人部级邮箱
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

    Private _BossEmailDeptChief As String

    ''' <summary>
    ''' FE处级主管邮箱
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

    Private _Equ_EmpNo As String = ""
    ''' <summary>
    ''' 生技负责人工号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Equ_EmpNo() As String
        Get
            Return Me._Equ_EmpNo
        End Get
        Set(value As String)
            Me._Equ_EmpNo = value
        End Set
    End Property

    Private _EquDutyBossEmail As String
    ''' <summary>
    ''' 生技负责人课长邮箱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EquDutyBossEmail() As String
        Get
            Return _EquDutyBossEmail
        End Get
        Set(value As String)
            _EquDutyBossEmail = value
        End Set
    End Property

    Private _PD_EmpNo As String = ""
    ''' <summary>
    ''' 生产负责人工号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PD_EmpNo() As String
        Get
            Return Me._PD_EmpNo
        End Get
        Set(value As String)
            Me._PD_EmpNo = value
        End Set
    End Property

    Private _PDDutyBossEmail As String
    ''' <summary>
    ''' 生产负责人课长邮箱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PDDutyBossEmail() As String
        Get
            Return _PDDutyBossEmail
        End Get
        Set(value As String)
            _PDDutyBossEmail = value
        End Set
    End Property

    Private _FIlePath As String
    Public Property FIlePath() As String
        Get
            Return _FIlePath
        End Get
        Set(value As String)
            _FIlePath = value
        End Set
    End Property

    ''' <summary>
    ''' 提交
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        Dim o_strEqu As String = String.Empty
        Dim ServerFilePath As String = ""
        Try
            If CheckData() = False Then
                Exit Sub
            End If
            ''FE负责人邮箱
            'Dim FEDutyEmail = DbOracleForSpcHelperSQL.GetSingle("SELECT email FROM v_employeeonjob   where code='" & Me.FE_EmpNo & "'  and email is not null").ToString()
            ''FE负责人课长邮箱
            'Dim FEDutyBossEmail = ""
            'Dim directbossempcode = DbOracleForSpcHelperSQL.GetSingle("SELECT directbossempcode FROM v_employeeonjob where code='" & Me.FE_EmpNo & "'  and email is not null ").ToString()
            'FEDutyBossEmail = DbOracleForSpcHelperSQL.GetSingle("SELECT email FROM v_employeeonjob where code='" & directbossempcode & "'").ToString()

            ''FE负责人部级邮箱
            'Dim BossEmailDept = ""
            'directbossempcode = DbOracleForSpcHelperSQL.GetSingle(" SELECT directbossempcode FROM v_employeeonjob   where code='" & directbossempcode & "'")
            'BossEmailDept = DbOracleForSpcHelperSQL.GetSingle("SELECT email FROM v_employeeonjob where code='" & directbossempcode & "'")

            ''FE负责人处级邮箱
            'Dim BossEmailDeptChief = ""
            'directbossempcode = DbOracleForSpcHelperSQL.GetSingle("SELECT directbossempcode FROM v_employeeonjob   where code='" & directbossempcode & "'").ToString()
            'BossEmailDeptChief = DbOracleForSpcHelperSQL.GetSingle("SELECT email FROM v_employeeonjob where code='" & directbossempcode & "'")

            'Modify by cq 20190523
            Dim UserID As String = GetUserID(Me.txtPIEName.Text.Trim)   ''VbCommClass.VbCommClass.UseId.ToUpper()

            If String.IsNullOrEmpty(UserID) Then
                UserID = VbCommClass.VbCommClass.UseId.ToUpper()
            End If
            'PIE负责人邮箱
            Dim PIEMail = DbOperateUtils.GetDataTable("select Email from m_employeeonjob_t where EmpCode='" + UserID + "' and email is not null").Rows(0)(0).ToString()

            Dim UrgentState = "N"
            If rdoBtnY.Checked = True Then
                UrgentState = "Y"
            ElseIf rdoBtnN.Checked = True Then
                UrgentState = "N"
            End If


            Dim destFilePath As String = Path.Combine(DrawingPath, txtDocID.Text.Trim)
            If Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If

            If Not String.IsNullOrEmpty(FilePathName) Then
                ServerFilePath = Path.Combine(destFilePath, FilePathName)
                File.Copy(txtFIlePath.Text.Trim, ServerFilePath, True)
            End If


            Dim sql = New System.Text.StringBuilder()
            If OP = "Add" Then
                '备份以前的版本
                sql.AppendLine(" insert into m_BOFToolListDEquimentBack_t([PartID],[StationOrderBy]")
                sql.AppendLine(" ,[StationID],[StationName],[EquimentType],[EquimentName],[DemandQty]")
                sql.AppendLine(" ,[Price],[Total],[Capacity],[FixtureNumber]")
                sql.AppendLine(",[Remark],[UserID],[UserName],[InTime],[EquimentNameZhiJu]")
                sql.AppendLine(" ,DemandQtyZhiJu,[PriceZhiJu],[TotalZhiJu]")
                sql.AppendLine(",[FESchedule],[BOFVersion],[backUserID],backTime) select [PartID],[StationOrderBy]")
                sql.AppendLine("  ,[StationID],[StationName],[EquimentType],[EquimentName]")
                sql.AppendLine(" ,[DemandQty],[Price],[Total],[Capacity],[FixtureNumber],[Remark],[UserID]")
                sql.AppendLine(" ,UserName,[InTime],[EquimentNameZhiJu],[DemandQtyZhiJu],[PriceZhiJu]")
                sql.AppendLine(" ,[TotalZhiJu],[FESchedule],[BOFVersion], '" & VbCommClass.VbCommClass.UseId & "',getdate() ")
                sql.AppendLine(" from m_BOFToolListDEquiment_t where partid=N'" & txtPartID.Text.Trim().ToUpper() & "' ")

                sql.AppendLine(" Insert into m_BOFToolListDBack_t(partID,[OrderBy],[Stationid],[StationName],[InTime],[UserID],[UserName],[Equipment],[BOFVersion],BackTime) select [partID]")
                sql.AppendLine(" ,[OrderBy],[Stationid],[StationName],[InTime],[UserID],[UserName],[Equipment],[BOFVersion],GETDATE() ")
                sql.AppendLine(" from m_BOFToolListD_t  where partid=N'" & txtPartID.Text.Trim().ToUpper() & "'")


                sql.AppendLine(String.Format(" Insert into m_BOFToolList_t " & vbCrLf &
                     "(PartID,CustName,Version,ProductName," & vbCrLf &
                          "Shape,PIEName,FEName,Description,DocID,FETargetDate,FEDutyEmail,FEDutyBossEmail,BossEmailDept,BossEmailDeptChief,PIEMail,FEEmpNo,UrgentState,BOFFile,EquDutyEmail,EquDutyBossEmail,PDDutyEmail,PDDutyBossEmail,EquName,PDName) values (N'{0}',N'{1}','{2}',N'{3}',N'{4}'," & vbCrLf &
                    "N'{5}',N'{6}',N'{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}',N'{17}','{18}','{19}','{20}','{21}',N'{22}',N'{23}')",
                     txtPartID.Text.Trim().ToUpper(), txtCustName.Text, txtVersion.Text.Trim().ToUpper(), txtProductName.Text.Trim().Replace("'", "" & Chr(34) & ""),
                     txtShape.Text.Replace("'", "" & Chr(34) & ""), txtPIEName.Text, txtFEName.Text.Trim(), txtDescription.Text.Trim().Replace("'", "" & Chr(34) & ""), getFileNO(),
                     dtpFETargetDate.Text, FEDutyEmail, FEDutyBossEmail, BossEmailDept, BossEmailDeptChief,
                     PIEMail, Me.FE_EmpNo, UrgentState, ServerFilePath, EquDutyEmail, EquDutyBossEmail,
                     PDDutyEmail, PDDutyBossEmail, txtEquName.Text.Trim(), txtPDName.Text.Trim()))

                Dim dtS = DbOperateUtils.GetDataTable("select a.*, b.Stationname from" & vbCrLf &
                "m_RCardD_t a join m_Rstation_t b on b.Stationid=a.StationID" & vbCrLf &
                "where a.PartID=N'" & txtPartID.Text.Trim() & "' order by StationSQ")
                For Each dr As DataRow In dtS.Rows
                    Dim PartID = dr("PartID").ToString()
                    Dim OrderBy = dr("StationSQ").ToString()
                    Dim Stationid = dr("Stationid").ToString()
                    Dim Stationname = dr("Stationname").ToString()
                    o_strEqu = dr("Equipment").ToString()
                    sql.AppendLine(String.Format("Insert into m_BOFToolListD_t(PartID,OrderBy,Stationid,StationName,InTime,UserID,UserName, Equipment,BOFVersion) VALUES (  N'{0}',{1},'{2}',N'{3}',getdate(),'{4}',N'{5}',N'{6}','{7}')",
                                                    PartID, OrderBy, Stationid, Stationname, VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.UseName, o_strEqu, Me.txtVersion.Text.Trim().ToUpper()))

                Next
            Else
                'add by cq 20200415,when edit, the txtfilepath is serverPath.
                If String.IsNullOrEmpty(ServerFilePath) Then
                    ServerFilePath = txtFIlePath.Text.Trim
                End If
                sql.AppendLine(String.Format("update m_BOFToolList_t " & vbCrLf &
                "set CustName=N'{1}',Version='{2}',ProductName=N'{3}'," & vbCrLf &
                "Shape=N'{4}',PIEName=N'{5}',FEName=N'{6}',InTime=getdate(),Description=N'{7}',FETargetDate='{8}',FEDutyEmail='{9}',FEDutyBossEmail='{10}', " & _
                " BossEmailDept='{11}',BossEmailDeptChief='{12}',PIEMail='{13}',FEEmpNo='{14}',UrgentState='{15}', " & _
                "BOFFile = N'" & ServerFilePath & "',EquDutyEmail='{16}',EquDutyBossEmail='{17}',PDDutyEmail='{18}',PDDutyBossEmail='{19}',EquName=N'{20}',PDName=N'{21}' " & _
                " where PartID=N'{0}' AND Version='" & Version & "' ",
                    txtPartID.Text.Trim().ToUpper(), txtCustName.Text, txtVersion.Text.Trim().ToUpper(), txtProductName.Text.Trim().Replace("'", "" & Chr(34) & ""), txtShape.Text.Replace("'", "" & Chr(34) & ""), txtPIEName.Text, txtFEName.Text.Trim(), txtDescription.Text.Trim().Replace("'", "" & Chr(34) & ""), dtpFETargetDate.Text, FEDutyEmail, FEDutyBossEmail, BossEmailDept, BossEmailDeptChief, PIEMail, Me.FE_EmpNo, UrgentState, EquDutyEmail, EquDutyBossEmail, PDDutyEmail, PDDutyBossEmail, txtEquName.Text.Trim(), txtPDName.Text.Trim()))
                If ModelMain.Version <> txtVersion.Text.Trim() Then
                    sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
                    "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue) " & vbCrLf &
                    "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}',getdate(),N'{6}')", ModelMain.PartID, "版本", ModelMain.PIEName, ModelMain.InTime, ModelMain.Version, VbCommClass.VbCommClass.UseName, txtVersion.Text.Trim()))
                End If
            End If
            DbOperateUtils.ExecSQL(sql.ToString())
            MessageUtils.ShowInformation("提交成功!")
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageUtils.ShowError("提交失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub

    Public Function GetUserID(ByVal UserName As String) As String
        Dim dt As DataTable = DbOperateUtils.GetDataTable("select UserID from m_Users_t where UserName=N'" & UserName & "'")
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0).ToString()
        Else
            Return Nothing
        End If
    End Function

    Private Sub txtPartID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPartID.KeyPress
        If e.KeyChar = Chr(13) Then
            If String.IsNullOrEmpty(txtPartID.Text.Trim()) = False Then
                Dim sql = "select * from  m_RCardM_t where PartID=N'" & txtPartID.Text & "'"
                Dim dt = DbOperateUtils.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    txtVersion.Text = dt.Rows(0)("DrawingVer").ToString()
                End If
                txtCustName.Text = getCustName(txtPartID.Text.Trim())
                sql = "select * from m_PartContrast_t" & vbCrLf &
                "where TAvcPart='" & txtPartID.Text.Trim() & "'order by Intime desc"
                dt = DbOperateUtils.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    txtProductName.Text = dt.Rows(0)("TypeDest").ToString()
                    txtDescription.Text = dt.Rows(0)("DESCRIPTION").ToString()
                    If String.IsNullOrEmpty(txtCustName.Text.Trim()) Then
                        sql = "select * from m_Customer_t" & vbCrLf &
                        "where CusID in " & vbCrLf &
                        "(" & vbCrLf &
                        "select CusID from m_PartContrast_t" & vbCrLf &
                        "where TAvcPart=N'" & txtPartID.Text.Trim() & "')"
                        dt = DbOperateUtils.GetDataTable(sql)
                        If dt.Rows.Count > 0 Then
                            txtCustName.Text = dt.Rows(0)("CusName").ToString()
                        End If

                    End If
                End If
            End If
        End If
    End Sub

#Region "获取客户名称"
    ''' <summary>
    ''' 获取客户名称
    ''' </summary>
    ''' <param name="PartID">料号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getCustName(ByVal PartID As String) As String
        Dim sql = "select customercategegory from  s2_MESMaterialsItemSet" & vbCrLf &
        "where 1=1 and materialnumber=N'" & PartID & "' order by modifytime desc "
        Dim ds = DBUtility.DbOracleForSpcHelperSQL.Query(sql)
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0)(0).ToString()
        End If
        Return ""
    End Function
#End Region

    Private Sub dtpFETargetDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpFETargetDate.ValueChanged
        dtpFETargetDate.CustomFormat = "yyyy-MM-dd"
    End Sub

    ''' <summary>
    ''' 选择FE
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSelectFE_Click(sender As Object, e As EventArgs) Handles BtnSelectFE.Click
        Dim frmPic As New FrmSelectPICNew()
        frmPic.DutyEmail = Me.FEDutyEmail

        If frmPic.ShowDialog() = Windows.Forms.DialogResult.Yes Then
            Me.txtFEName.Text = Nothing
            Me.FE_EmpNo = Nothing
            Me.FEDutyEmail = Nothing
            Me.FEDutyBossEmail = Nothing
            Me.BossEmailDept = Nothing
            Me.BossEmailDeptChief = Nothing
            'If frmPic.dgvSelect.Rows.Count > 1 Then
            '    MessageUtils.ShowError("BOF治具清单FE负责人只能选择一个人")
            '    Exit Sub
            'End If
            For Each dgvr As DataGridViewRow In frmPic.dgvSelect.Rows
                Me.txtFEName.Text += dgvr.Cells("colSname").Value + ","
                Me.FE_EmpNo += dgvr.Cells("colScode").Value + ","
            Next
            If Me.FE_EmpNo.Contains(",") Then
                Me.txtFEName.Text = Me.txtFEName.Text.Trim(",")
                Me.FE_EmpNo = Me.FE_EmpNo.Trim(",")
            End If
            Dim Temp_FE_EmpNo = Me.FE_EmpNo
            Temp_FE_EmpNo = Temp_FE_EmpNo.Replace(",", "','")
            Temp_FE_EmpNo = "'" & Temp_FE_EmpNo & "'"
            Dim sql = "select * from m_employeeonjob_t where EmpCode in (" & Temp_FE_EmpNo & ")"
            Dim dt = DbOperateUtils.GetDataTable(sql)
            For Each dr As DataRow In dt.Rows
                Me.FEDutyEmail += dr("Email").ToString() + ";"
                Dim _BossEmpCode As String = dr("BossEmpCode").ToString()
                sql = "select * from m_employeeonjob_t where EmpCode='" & _BossEmpCode & "'"
                Dim dtBoss = DbOperateUtils.GetDataTable(sql)
                Dim _BossDeptEmpCode = dtBoss.Rows(0)("BossEmpCode").ToString()
                Me.FEDutyBossEmail += dtBoss.Rows(0)("Email").ToString() + ";"
                sql = "select * from m_employeeonjob_t where EmpCode='" & _BossDeptEmpCode & "'"
                Dim dtDeptBoss = DbOperateUtils.GetDataTable(sql)
                Me.BossEmailDept += dtDeptBoss.Rows(0)("Email").ToString() + ";"

                Dim _BossDeptChiefEmpCode = dtDeptBoss.Rows(0)("BossEmpCode").ToString()
                sql = "select * from m_employeeonjob_t where EmpCode='" & _BossDeptChiefEmpCode & "'"
                Dim dtBossDeptChief = DbOperateUtils.GetDataTable(sql)
                Me.BossEmailDeptChief += dtBossDeptChief.Rows(0)("Email").ToString() + ";"
            Next
            Me.FEDutyEmail = Me.FEDutyEmail.Trim(";")
            Me.FEDutyBossEmail = Me.FEDutyBossEmail.Trim(";")
            Me.BossEmailDept = Me.BossEmailDept.Trim(";")
            Me.BossEmailDeptChief = Me.BossEmailDeptChief.Trim(";")
            'Me.FE_EmpNo = frmPic.dgvSelect.Rows(0).Cells("colScode").Value
            'Me.txtFEName.Text = frmPic.dgvSelect.Rows(0).Cells("colSname").Value
        End If
    End Sub


    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        btnFile.Enabled = False

        Dim result As DialogResult = OpenFileDialog3.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtFIlePath.Text = OpenFileDialog3.FileName
            FilePathName = OpenFileDialog3.SafeFileName
            Cursor.Current = Cursors.Default
        End If

        btnFile.Enabled = True

    End Sub

    Private Sub btnSelectEquDuty_Click(sender As Object, e As EventArgs) Handles btnSelectEquDuty.Click
        Dim frmPic As New FrmSelectPICNew()
        frmPic.DutyEmail = Me.EquDutyEmail

        If frmPic.ShowDialog() = Windows.Forms.DialogResult.Yes Then
            Me.txtEquName.Text = Nothing
            Me.Equ_EmpNo = Nothing
            Me.EquDutyEmail = Nothing
            Me.EquDutyBossEmail = Nothing
            Me.BossEmailDept = Nothing
            Me.BossEmailDeptChief = Nothing
            For Each dgvr As DataGridViewRow In frmPic.dgvSelect.Rows
                Me.txtEquName.Text += dgvr.Cells("colSname").Value + ","
                Me.Equ_EmpNo += dgvr.Cells("colScode").Value + ","
            Next
            If Me.Equ_EmpNo.Contains(",") Then
                Me.txtEquName.Text = Me.txtEquName.Text.Trim(",")
                Me.Equ_EmpNo = Me.Equ_EmpNo.Trim(",")
            End If
            Dim Temp_Equ_EmpNo = Me.Equ_EmpNo
            Temp_Equ_EmpNo = Temp_Equ_EmpNo.Replace(",", "','")
            Temp_Equ_EmpNo = "'" & Temp_Equ_EmpNo & "'"
            Dim sql = "select * from m_employeeonjob_t where EmpCode in (" & Temp_Equ_EmpNo & ")"
            Dim dt = DbOperateUtils.GetDataTable(sql)
            For Each dr As DataRow In dt.Rows
                Me.EquDutyEmail += dr("Email").ToString() + ";"
                Dim _BossEmpCode As String = dr("BossEmpCode").ToString()
                sql = "select * from m_employeeonjob_t where EmpCode='" & _BossEmpCode & "'"
                Dim dtBoss = DbOperateUtils.GetDataTable(sql)
                Dim _BossDeptEmpCode = dtBoss.Rows(0)("BossEmpCode").ToString()
                Me.EquDutyBossEmail += dtBoss.Rows(0)("Email").ToString() + ";"
                sql = "select * from m_employeeonjob_t where EmpCode='" & _BossDeptEmpCode & "'"
                Dim dtDeptBoss = DbOperateUtils.GetDataTable(sql)
                Me.BossEmailDept += dtDeptBoss.Rows(0)("Email").ToString() + ";"

                Dim _BossDeptChiefEmpCode = dtDeptBoss.Rows(0)("BossEmpCode").ToString()
                sql = "select * from m_employeeonjob_t where EmpCode='" & _BossDeptChiefEmpCode & "'"
                Dim dtBossDeptChief = DbOperateUtils.GetDataTable(sql)
                Me.BossEmailDeptChief += dtBossDeptChief.Rows(0)("Email").ToString() + ";"
            Next
            Me.EquDutyEmail = Me.EquDutyEmail.Trim(";")
            Me.EquDutyBossEmail = Me.EquDutyBossEmail.Trim(";")
            Me.BossEmailDept = Me.BossEmailDept.Trim(";")
            Me.BossEmailDeptChief = Me.BossEmailDeptChief.Trim(";")
        End If
    End Sub

    Private Sub btnSelectPDDuty_Click(sender As Object, e As EventArgs) Handles btnSelectPDDuty.Click
        Dim frmPic As New FrmSelectPICNew()
        frmPic.DutyEmail = Me.PDDutyEmail

        If frmPic.ShowDialog() = Windows.Forms.DialogResult.Yes Then
            Me.txtPDName.Text = Nothing
            Me.PD_EmpNo = Nothing
            Me.PDDutyEmail = Nothing
            Me.PDDutyBossEmail = Nothing
            Me.BossEmailDept = Nothing
            Me.BossEmailDeptChief = Nothing
            For Each dgvr As DataGridViewRow In frmPic.dgvSelect.Rows
                Me.txtPDName.Text += dgvr.Cells("colSname").Value + ","
                Me.PD_EmpNo += dgvr.Cells("colScode").Value + ","
            Next
            If Me.PD_EmpNo.Contains(",") Then
                Me.txtPDName.Text = Me.txtPDName.Text.Trim(",")
                Me.PD_EmpNo = Me.PD_EmpNo.Trim(",")
            End If
            Dim Temp_PD_EmpNo = Me.PD_EmpNo
            Temp_PD_EmpNo = Temp_PD_EmpNo.Replace(",", "','")
            Temp_PD_EmpNo = "'" & Temp_PD_EmpNo & "'"
            Dim sql = "select * from m_employeeonjob_t where EmpCode in (" & Temp_PD_EmpNo & ")"
            Dim dt = DbOperateUtils.GetDataTable(sql)
            For Each dr As DataRow In dt.Rows
                Me.PDDutyEmail += dr("Email").ToString() + ";"
                Dim _BossEmpCode As String = dr("BossEmpCode").ToString()
                sql = "select * from m_employeeonjob_t where EmpCode='" & _BossEmpCode & "'"
                Dim dtBoss = DbOperateUtils.GetDataTable(sql)
                Dim _BossDeptEmpCode = dtBoss.Rows(0)("BossEmpCode").ToString()
                Me.PDDutyBossEmail += dtBoss.Rows(0)("Email").ToString() + ";"
                sql = "select * from m_employeeonjob_t where EmpCode='" & _BossDeptEmpCode & "'"
                Dim dtDeptBoss = DbOperateUtils.GetDataTable(sql)
                Me.BossEmailDept += dtDeptBoss.Rows(0)("Email").ToString() + ";"

                Dim _BossDeptChiefEmpCode = dtDeptBoss.Rows(0)("BossEmpCode").ToString()
                sql = "select * from m_employeeonjob_t where EmpCode='" & _BossDeptChiefEmpCode & "'"
                Dim dtBossDeptChief = DbOperateUtils.GetDataTable(sql)
                Me.BossEmailDeptChief += dtBossDeptChief.Rows(0)("Email").ToString() + ";"
            Next
            Me.PDDutyEmail = Me.PDDutyEmail.Trim(";")
            Me.PDDutyBossEmail = Me.PDDutyBossEmail.Trim(";")
            Me.BossEmailDept = Me.BossEmailDept.Trim(";")
            Me.BossEmailDeptChief = Me.BossEmailDeptChief.Trim(";")
        End If
    End Sub
End Class

Public Class BOFToolListMainModel
    Private _PartID As String
    Public Property PartID() As String
        Get
            Return _PartID
        End Get
        Set(ByVal value As String)
            _PartID = value
        End Set
    End Property

    Private _CustName As String
    Public Property CustName() As String
        Get
            Return _CustName
        End Get
        Set(ByVal value As String)
            _CustName = value
        End Set
    End Property

    Private _ProductName As String
    Public Property ProductName() As String
        Get
            Return _ProductName
        End Get
        Set(ByVal value As String)
            _ProductName = value
        End Set
    End Property

    Private _Shape As String
    Public Property Shape() As String
        Get
            Return _Shape
        End Get
        Set(ByVal value As String)
            _Shape = value
        End Set
    End Property

    Private _PIEName As String
    Public Property PIEName() As String
        Get
            Return _PIEName
        End Get
        Set(ByVal value As String)
            _PIEName = value
        End Set
    End Property

    Private _FEName As String
    Public Property FEName() As String
        Get
            Return _FEName
        End Get
        Set(ByVal value As String)
            _FEName = value
        End Set
    End Property

    Private _Version As String
    Public Property Version() As String
        Get
            Return _Version
        End Get
        Set(ByVal value As String)
            _Version = value
        End Set
    End Property

    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Private _InTime As Date
    Public Property InTime() As Date
        Get
            Return _InTime
        End Get
        Set(ByVal value As Date)
            _InTime = value
        End Set
    End Property

    Private _EquName As String
    Public Property EquName() As String
        Get
            Return _EquName
        End Get
        Set(ByVal value As String)
            _EquName = value
        End Set
    End Property

    Private _PDName As String
    Public Property PDName() As String
        Get
            Return _PDName
        End Get
        Set(ByVal value As String)
            _PDName = value
        End Set
    End Property

End Class