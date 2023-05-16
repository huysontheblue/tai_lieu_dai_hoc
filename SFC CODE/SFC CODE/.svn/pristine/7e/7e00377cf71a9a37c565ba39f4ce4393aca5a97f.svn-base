Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports System.Xml
Imports System.IO

Public Class FrmWorkDayPlanInfo
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal flag As String, Optional ByVal id As String = "")
        Me.NewFlag = flag
        Me.GETID = id

        InitializeComponent()
    End Sub

    Public GETID As String

    Private _id As String
    Private _PlanDay As String
    Private _PlanPart As String
    Private _Moid As String
    Private _Deptid As String
    Private _Lineid As String
    Private _PlanQty1 As Integer
    Private _PlanQty2 As Integer
    Private _PlanQty3 As Integer
    Private _PlanQty4 As Integer
    Private _PlanQty5 As Integer
    Private _Quorum As Integer
    Private _Intime As DateTime = DateTime.Now
    Private _UserID As String
    Private _Usey As String

    'Private _updatedt As DateTime = DateTime.Now
    'Private _updateuserid As String
    'Private _lev As Integer = 0
    '/ <summary>
    '/ id
    '/ </summary>
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal Value As String)
            _id = Value
        End Set
    End Property
    '/ <summary>
    '/ 计划日期
    '/ </summary>
    Public Property PlanDay() As String
        Get
            Return _PlanDay
        End Get
        Set(ByVal Value As String)
            _PlanDay = Value
        End Set
    End Property
    '/ <summary>
    '/ 计划节次，1~5节
    '/ </summary>
    Public Property PlanPart() As String
        Get
            Return _PlanPart
        End Get
        Set(ByVal Value As String)
            _PlanPart = Value
        End Set
    End Property
    '/ <summary>
    '/ 工单
    '/ </summary>
    Public Property Moid() As String
        Get
            Return _Moid
        End Get
        Set(ByVal Value As String)
            _Moid = Value
        End Set
    End Property
    '/ <summary>
    '/ 部门
    '/ </summary>
    Public Property DeptID() As String
        Get
            Return _Deptid
        End Get
        Set(ByVal Value As String)
            _Deptid = Value
        End Set
    End Property

    '/ <summary>
    '/ 线别
    '/ </summary>
    Public Property LineID() As String
        Get
            Return _Lineid
        End Get
        Set(ByVal Value As String)
            _Lineid = Value
        End Set
    End Property
    '/ <summary>
    '/ 计划数量1
    '/ </summary>
    Public Property PlanQty1() As Integer
        Get
            Return _PlanQty1
        End Get
        Set(ByVal Value As Integer)
            _PlanQty1 = Value
        End Set
    End Property
    '/ <summary>
    '/ 计划数量1
    '/ </summary>
    Public Property PlanQty2() As Integer
        Get
            Return _PlanQty2
        End Get
        Set(ByVal Value As Integer)
            _PlanQty2 = Value
        End Set
    End Property
    '/ <summary>
    '/ 计划数量3
    '/ </summary>
    Public Property PlanQty3() As Integer
        Get
            Return _PlanQty3
        End Get
        Set(ByVal Value As Integer)
            _PlanQty3 = Value
        End Set
    End Property
    '/ <summary>
    '/ 计划数量4
    '/ </summary>
    Public Property PlanQty4() As Integer
        Get
            Return _PlanQty4
        End Get
        Set(ByVal Value As Integer)
            _PlanQty4 = Value
        End Set
    End Property
    '/ <summary>
    '/ 计划数量5
    '/ </summary>
    Public Property PlanQty5() As Integer
        Get
            Return _PlanQty5
        End Get
        Set(ByVal Value As Integer)
            _PlanQty5 = Value
        End Set
    End Property

    '/ <summary>
    '/ 出勤人数
    '/ </summary>
    Public Property Quorum() As Integer
        Get
            Return _Quorum
        End Get
        Set(ByVal Value As Integer)
            _Quorum = Value
        End Set
    End Property
    '/ <summary>
    '/ 创建时间
    '/ </summary>
    Public Property Intime() As DateTime
        Get
            Return _Intime
        End Get
        Set(ByVal Value As DateTime)
            _Intime = Value
        End Set
    End Property
    '/ <summary>
    '/ 创建人
    '/ </summary>
    Public Property UserId() As String
        Get
            Return _UserID
        End Get
        Set(ByVal Value As String)
            _UserID = Value
        End Set
    End Property
    '/ <summary>
    '/ 状态
    '/ </summary>
    Public Property Usey() As String
        Get
            Return _Usey
        End Get
        Set(ByVal Value As String)
            _Usey = Value
        End Set
    End Property

    Private _newflag As String = "0"
    Public Property NewFlag() As String
        Get
            Return _newflag
        End Get
        Set(ByVal value As String)
            _newflag = value
        End Set
    End Property

    ''' <summary>
    ''' 立讯料号
    ''' </summary>
    ''' <remarks></remarks>
    Public PartID As String

    ''' <summary>
    ''' 标准工时
    ''' </summary>
    ''' <remarks></remarks>
    Public SWorkHours As String

    ''' <summary>
    ''' 客户料号
    ''' </summary>
    ''' <remarks></remarks>
    Public CustPartID As String

    '是否刷新主界面
    Private _IsRefresh As Boolean = False
    Public ReadOnly Property IsRefresh() As Boolean
        Get
            Return _IsRefresh
        End Get
    End Property

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub FrmWorkOrdInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'FillCombox(cboPlanPart)
        FillCombox(CboDept)


        Select Case NewFlag
            Case "0" '新增

                txtIntime.Text = Now.ToString("yyyy-MM-dd HH:mm:ss")
                txtUserid.Text = VbCommClass.VbCommClass.UseId
                txtPlanDay.Value = Now.ToString("yyyy-MM-dd")
                TxtMoid.Text = ""
                txtPlanQty1.Text = "0"
                txtPlanQty2.Text = "0"
                txtPlanQty3.Text = "0"
                txtPlanQty4.Text = "0"
                txtPlanQty5.Text = "0"
                txtQuorum.Text = 0
                'Me.CboDept.SelectedIndex = -1
                'Me.CboLine.SelectedIndex = -1
                '  cboPlanPart.SelectedIndex = 1
                '  chkusey.Checked = False
                Button1.Text = "保存提交"
                chkEdit.Enabled = True
                Dim DeptID As String = GetXMLNodeData("deptid")
                Dim LineID As String = GetXMLNodeData("lineid")
              
                Try
                    CboDept.SelectedValue = DeptID
                    CboDept_SelectedIndexChanged(Nothing, Nothing)
                    CboLine.SelectedValue = LineID
                Catch ex As Exception

                End Try

            Case "1" '修改               
                ShowInfo()
                Button1.Text = "修改提交"
        End Select
        Me.GroupBox1.Enabled = False
       
    End Sub

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim UserDg As DataTable
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim lsSQL As String = String.Empty

        If ColComboBox.Name = "CboDept" Then
            'lsSQL = " SELECT deptid, deptid+'--'+dqc as dqc FROM  m_Dept_t WHERE factoryid='" & VbCommClass.VbCommClass.Factory & "'"
            UserDg = VbCommClass.CommClass.GetUserDeptDt() ' DataHand.GetDataTable(lsSQL)
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "djc"
            ColComboBox.ValueMember = "deptid"
        ElseIf ColComboBox.Name = "cboPlanPart" Then
            UserDg = DataHand.GetDataTable("select OrderIndex,ClassName from m_KanbanClass_t where ClassType='C002' order by OrderIndex")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "ClassName"
            ColComboBox.ValueMember = "OrderIndex"
        End If
        UserDg = Nothing
    End Sub
    Private Sub ShowInfo()
        Dim sql As String = ""

        Dim strSql As StringBuilder = New StringBuilder()
        strSql.Append(" select ID,PlanDay,Moid,Deptid,Lineid,PlanQty1,PlanQty2,PlanQty3,PlanQty4,PlanQty5,Quorum,UserID,Intime,Usey,PartID,SWorkHours,CustPartID ")
        strSql.Append(" FROM [m_WorkDayPlan_t] a ")
        strSql.Append(" where a.id=@id ")
        Dim parameters() As SqlParameter = {New SqlParameter("@id", SqlDbType.Int)}
        parameters(0).Value = GETID


        Dim dt As DataTable = New MainFrame.SysDataHandle.SysDataBaseClass().GetDataTable(strSql.ToString(), parameters)
        If dt.Rows.Count > 0 Then
            txtPlanDay.Value = DateTime.Parse(dt.Rows(0)("PlanDay").ToString.Trim)
            'cboPlanPart.SelectedValue = dt.Rows(0)("PlanPart").ToString.Trim
            CboDept.SelectedValue = dt.Rows(0)("Deptid").ToString.Trim
            CboDept_SelectedIndexChanged(Nothing, Nothing)
            CboLine.SelectedValue = dt.Rows(0)("Lineid").ToString.Trim
            TxtMoid.Text = dt.Rows(0)("Moid").ToString.Trim
            txtPlanQty1.Text = dt.Rows(0)("PlanQty1").ToString.Trim
            txtPlanQty2.Text = dt.Rows(0)("PlanQty2").ToString.Trim
            txtPlanQty3.Text = dt.Rows(0)("PlanQty3").ToString.Trim
            txtPlanQty4.Text = dt.Rows(0)("PlanQty4").ToString.Trim
            txtPlanQty5.Text = dt.Rows(0)("PlanQty5").ToString.Trim
            txtQuorum.Text = dt.Rows(0)("Quorum").ToString.Trim
            txtUserid.Text = dt.Rows(0)("userid").ToString.Trim
            chkusey.Checked = IIf(dt.Rows(0)("Usey").ToString().Trim = "Y", True, False)
            txtIntime.Text = dt.Rows(0)("Intime").ToString.Trim
            txtPartNO.Text = dt.Rows(0)("PartID").ToString.Trim
            txtSworkhours.Text = dt.Rows(0)("SWorkHours").ToString.Trim
            txtCustPartID.Text = dt.Rows(0)("CustPartID").ToString().Trim()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim checkstr As String = CheckData()
        If checkstr <> "" Then
            MessageUtils.ShowInformation(checkstr)
            Exit Sub
        End If
        If chkEdit.Checked Then
            UpdateLineInfoData()
        End If
        Select Case NewFlag
            Case "0" '新增
                If (Adddata()) Then
                    MessageUtils.ShowInformation("新增操作成功,可以继续添加下一条记录")
                    ClearData()
                    _IsRefresh = True
                    Exit Sub
                End If
            Case "1"
                If UpdateData() Then
                    MessageUtils.ShowInformation("修改操作成功")
                    DialogResult = Windows.Forms.DialogResult.OK
                End If
        End Select
        SetXMLNodeData("deptid", CboDept.SelectedValue.ToString)
        SetXMLNodeData("lineid", CboLine.SelectedValue.ToString)
    End Sub
    Public Function CheckData() As String
        Dim Checkstr As String = ""

        If (CboDept.Text.Trim = "") Then
            Checkstr = Checkstr + "部门不能为空"
            CboDept.Focus()
            Return Checkstr
        End If
        If (CboLine.Text.Trim = "") Then
            Checkstr = Checkstr + "线别不能为空"
            CboLine.Focus()
            Return Checkstr
        End If
        If (TxtMoid.Text.Trim = "") Then
            Checkstr = Checkstr + "工单不能为空"
            TxtMoid.Focus()
            Return Checkstr
        End If

        If (txtPlanQty1.Text.Trim = "" Or txtPlanQty1.Text.Trim = "0") Then
            txtPlanQty1.Text = "0"
            'Checkstr = Checkstr + "计划数量不能为空"
            'txtPlanQty1.Focus()
            'Return Checkstr
        Else
            Try
                Dim IntOrdCount As Integer = Convert.ToInt32(txtPlanQty1.Text.Trim)
                If IntOrdCount <= 0 Then
                    Checkstr = Checkstr + "计划数量1必须为正整数"
                    txtPlanQty1.Focus()
                    Return Checkstr
                End If
            Catch ex As Exception
                Checkstr = Checkstr + "计划数量1必须为正整数"
                txtPlanQty1.Focus()
                Return Checkstr
            End Try
        End If
        If (txtPlanQty2.Text.Trim = "" Or txtPlanQty2.Text.Trim = "0") Then
            txtPlanQty2.Text = "0"
            'Checkstr = Checkstr + "计划数量不能为空"
            'txtPlanQty1.Focus()
            'Return Checkstr
        Else
            Try
                Dim IntOrdCount As Integer = Convert.ToInt32(txtPlanQty2.Text.Trim)
                If IntOrdCount <= 0 Then
                    Checkstr = Checkstr + "计划数量2必须为正整数"
                    txtPlanQty2.Focus()
                    Return Checkstr
                End If
            Catch ex As Exception
                Checkstr = Checkstr + "计划数量2必须为正整数"
                txtPlanQty2.Focus()
                Return Checkstr
            End Try
        End If
        If (txtPlanQty3.Text.Trim = "" Or txtPlanQty3.Text.Trim = "0") Then
            txtPlanQty3.Text = "0"
            'Checkstr = Checkstr + "计划数量不能为空"
            'txtPlanQty1.Focus()
            'Return Checkstr
        Else
            Try
                Dim IntOrdCount As Integer = Convert.ToInt32(txtPlanQty3.Text.Trim)
                If IntOrdCount <= 0 Then
                    Checkstr = Checkstr + "计划数量3必须为正整数"
                    txtPlanQty3.Focus()
                    Return Checkstr
                End If
            Catch ex As Exception
                Checkstr = Checkstr + "计划数量3必须为正整数"
                txtPlanQty3.Focus()
                Return Checkstr
            End Try
        End If
        If (txtPlanQty4.Text.Trim = "" Or txtPlanQty4.Text.Trim = "0") Then
            txtPlanQty4.Text = "0"
            'Checkstr = Checkstr + "计划数量不能为空"
            'txtPlanQty1.Focus()
            'Return Checkstr
        Else
            Try
                Dim IntOrdCount As Integer = Convert.ToInt32(txtPlanQty4.Text.Trim)
                If IntOrdCount <= 0 Then
                    Checkstr = Checkstr + "计划数量4必须为正整数"
                    txtPlanQty4.Focus()
                    Return Checkstr
                End If
            Catch ex As Exception
                Checkstr = Checkstr + "计划数量4必须为正整数"
                txtPlanQty4.Focus()
                Return Checkstr
            End Try
        End If

        If (txtPlanQty5.Text.Trim = "" Or txtPlanQty5.Text.Trim = "0") Then
            txtPlanQty5.Text = "0"
            'Checkstr = Checkstr + "计划数量不能为空"
            'txtPlanQty1.Focus()
            'Return Checkstr
        Else
            Try
                Dim IntOrdCount As Integer = Convert.ToInt32(txtPlanQty5.Text.Trim)
                If IntOrdCount <= 0 Then
                    Checkstr = Checkstr + "计划数量5必须为正整数"
                    txtPlanQty5.Focus()
                    Return Checkstr
                End If
            Catch ex As Exception
                Checkstr = Checkstr + "计划数量5必须为正整数"
                txtPlanQty5.Focus()
                Return Checkstr
            End Try
        End If
        If (txtPlanQty1.Text.Trim = "" AndAlso txtPlanQty2.Text.Trim = "" AndAlso txtPlanQty3.Text.Trim = "" AndAlso txtPlanQty4.Text.Trim = "" AndAlso txtPlanQty5.Text.Trim = "") Then
            Checkstr = Checkstr + "计划数量不能全为空"
            txtPlanQty1.Focus()
            Return Checkstr
        Else
            If (txtPlanQty1.Text.Trim = "0" AndAlso txtPlanQty2.Text.Trim = "0" AndAlso txtPlanQty3.Text.Trim = "0" AndAlso txtPlanQty4.Text.Trim = "0" AndAlso txtPlanQty5.Text.Trim = "0") Then
                Checkstr = Checkstr + "计划数量不能全为0"
                txtPlanQty1.Focus()
                Return Checkstr
            End If

        End If
        If (txtQuorum.Text.Trim = "") Then
            Checkstr = Checkstr + "出勤人数不能为空"
            txtQuorum.Focus()
            Return Checkstr
        Else
            Try
                Dim IntOrdCount As Integer = Convert.ToInt32(txtQuorum.Text.Trim)
                If IntOrdCount <= 0 Then
                    Checkstr = Checkstr + "出勤数量必须为正整数"
                    txtQuorum.Focus()
                    Return Checkstr
                End If
            Catch ex As Exception
                Checkstr = Checkstr + "出勤数量必须为正整数"
                txtQuorum.Focus()
                Return Checkstr
            End Try
        End If


        Return Checkstr
    End Function



    Public Sub ClearData()
        txtIntime.Text = Now.ToString("yyyy-MM-dd HH:mm:ss")
        txtUserid.Text = VbCommClass.VbCommClass.UseId
        txtPlanDay.Value = Now.ToString("yyyy-MM-dd")
        TxtMoid.Text = ""
        txtPlanQty1.Text = "0"
        txtPlanQty2.Text = "0"
        txtPlanQty3.Text = "0"
        txtPlanQty4.Text = "0"
        txtPlanQty5.Text = "0"
        txtQuorum.Text = 0
        Me.CboDept.SelectedIndex = -1
        Me.CboLine.SelectedIndex = -1
        '   cboPlanPart.SelectedIndex = 1
        chkusey.Checked = True
    End Sub

    Public Function Adddata() As Boolean

        PlanDay = txtPlanDay.Value.ToString("yyyy-MM-dd").ToString
        'PlanPart = cboPlanPart.SelectedValue
        Moid = TxtMoid.Text
        DeptID = CboDept.SelectedValue
        LineID = CboLine.SelectedValue

        PlanQty1 = Integer.Parse(txtPlanQty1.Text)
        PlanQty2 = Integer.Parse(txtPlanQty2.Text)
        PlanQty3 = Integer.Parse(txtPlanQty3.Text)
        PlanQty4 = Integer.Parse(txtPlanQty4.Text)
        PlanQty5 = Integer.Parse(txtPlanQty5.Text)
        Quorum = Integer.Parse(txtQuorum.Text)
        UserId = txtUserid.Text
        Intime = Now
        Usey = "Y"

        PartID = txtPartNO.Text.Trim()
        SWorkHours = txtSworkhours.Text.Trim()
        Me.CustPartID = txtCustPartID.Text.Trim()

        Dim strSql As StringBuilder = New StringBuilder()
        strSql.Append("insert into m_WorkDayPlan_t(")
        strSql.Append("PlanDay,Moid,Deptid,Lineid,PlanQty1,PlanQty2,PlanQty3,PlanQty4,PlanQty5,Quorum,UserID,Intime,Usey,PartID,SWorkHours,CustPartID)")
        strSql.Append(" values (")
        strSql.Append("@PlanDay,@Moid,@Deptid,@Lineid,@PlanQty1,@PlanQty2,@PlanQty3,@PlanQty4,@PlanQty5,@Quorum,@UserID,@Intime,@Usey,@PartID,@SWorkHours,@CustPartID) ")
        strSql.Append(";select @@IDENTITY")
        Dim parameters() As SqlParameter = {New SqlParameter("@PlanDay", SqlDbType.VarChar, 10), New SqlParameter("@Moid", SqlDbType.VarChar, 64), New SqlParameter("@Deptid", SqlDbType.VarChar, 10), New SqlParameter("@Lineid", SqlDbType.VarChar, 10), New SqlParameter("@PlanQty1", SqlDbType.Int, 4), New SqlParameter("@PlanQty2", SqlDbType.Int, 4), New SqlParameter("@PlanQty3", SqlDbType.Int, 4), New SqlParameter("@PlanQty4", SqlDbType.Int, 4), New SqlParameter("@PlanQty5", SqlDbType.Int, 4), New SqlParameter("@Quorum", SqlDbType.Int, 4), New SqlParameter("@UserID", SqlDbType.VarChar, 8), New SqlParameter("@Intime", SqlDbType.DateTime), New SqlParameter("@Usey", SqlDbType.VarChar, 1), New SqlParameter("@PartID", SqlDbType.VarChar, 50), New SqlParameter("@SWorkHours", SqlDbType.VarChar, 10), New SqlParameter("@CustPartID", SqlDbType.VarChar, 50)}

        parameters(0).Value = PlanDay
        parameters(1).Value = Moid
        parameters(2).Value = DeptID
        parameters(3).Value = LineID
        parameters(4).Value = PlanQty1
        parameters(5).Value = PlanQty2
        parameters(6).Value = PlanQty3
        parameters(7).Value = PlanQty4
        parameters(8).Value = PlanQty5
        parameters(9).Value = Quorum
        parameters(10).Value = UserId
        parameters(11).Value = Intime
        parameters(12).Value = Usey
        parameters(13).Value = PartID
        parameters(14).Value = SWorkHours
        parameters(15).Value = Me.CustPartID
        Try
            Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim ref As String = conn.ExecuteNonQuery(strSql.ToString(), parameters)
            If ref = "" Then
                SysMessageClass.SaveUserOpLog(Me, "新增计划日期：" + PlanDay + "节次：" + PlanPart)
                Return True
            Else
                MessageBox.Show("新增失败:" & ref)
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UpdateData() As Boolean
        PlanDay = txtPlanDay.Value.ToString("yyyy-MM-dd").ToString
        '  PlanPart = cboPlanPart.SelectedValue
        Moid = TxtMoid.Text
        DeptID = CboDept.SelectedValue
        LineID = CboLine.SelectedValue
        PlanQty1 = Integer.Parse(txtPlanQty1.Text)
        PlanQty2 = Integer.Parse(txtPlanQty2.Text)
        PlanQty3 = Integer.Parse(txtPlanQty3.Text)
        PlanQty4 = Integer.Parse(txtPlanQty4.Text)
        PlanQty5 = Integer.Parse(txtPlanQty5.Text)
        Quorum = Integer.Parse(txtQuorum.Text)
        UserId = txtUserid.Text
        Intime = Now
        Usey = "Y"

        PartID = txtPartNO.Text.Trim()
        SWorkHours = txtSworkhours.Text.Trim()
        Me.CustPartID = txtCustPartID.Text.Trim()

        Dim strSql As StringBuilder = New StringBuilder()
        strSql.Append("update m_WorkDayPlan_t set ")
        strSql.Append("PlanDay=@PlanDay,")
        strSql.Append("Moid=@Moid,")
        strSql.Append("Deptid=@Deptid,")
        strSql.Append("Lineid=@Lineid,")
        strSql.Append("PlanQty1=@PlanQty1,")
        strSql.Append("PlanQty2=@PlanQty2,")
        strSql.Append("PlanQty3=@PlanQty3,")
        strSql.Append("PlanQty4=@PlanQty4,")
        strSql.Append("PlanQty5=@PlanQty5,")
        strSql.Append("Quorum=@Quorum,")
        strSql.Append("UserID=@UserID,")
        strSql.Append("Intime=@Intime,")
        strSql.Append("Usey=@Usey")
        strSql.Append(",PartID=@PartID")
        strSql.Append(",SWorkHours=@SWorkHours ")
        strSql.Append(",CustPartID=@CustPartID ")
        strSql.Append(" where id=@id")
        Dim parameters() As SqlParameter = {New SqlParameter("@PlanDay", SqlDbType.VarChar, 10), New SqlParameter("@Moid", SqlDbType.VarChar, 64), New SqlParameter("@Deptid", SqlDbType.VarChar, 10), New SqlParameter("@Lineid", SqlDbType.VarChar, 10), New SqlParameter("@PlanQty1", SqlDbType.Int, 4), New SqlParameter("@PlanQty2", SqlDbType.Int, 4), New SqlParameter("@PlanQty3", SqlDbType.Int, 4), New SqlParameter("@PlanQty4", SqlDbType.Int, 4), New SqlParameter("@PlanQty5", SqlDbType.Int, 4), New SqlParameter("@Quorum", SqlDbType.Int, 4), New SqlParameter("@UserID", SqlDbType.VarChar, 8), New SqlParameter("@Intime", SqlDbType.DateTime), New SqlParameter("@Usey", SqlDbType.VarChar, 1), New SqlParameter("@id", SqlDbType.Int, 4), New SqlParameter("@PartID", SqlDbType.VarChar, 50), New SqlParameter("@SWorkHours", SqlDbType.VarChar, 10), New SqlParameter("@CustPartID", SqlDbType.VarChar, 50)}

        parameters(0).Value = Me.PlanDay
        parameters(1).Value = Me.Moid
        parameters(2).Value = Me.DeptID
        parameters(3).Value = Me.LineID
        parameters(4).Value = Me.PlanQty1
        parameters(5).Value = Me.PlanQty2
        parameters(6).Value = Me.PlanQty3
        parameters(7).Value = Me.PlanQty4
        parameters(8).Value = Me.PlanQty5
        parameters(9).Value = Me.Quorum
        parameters(10).Value = Me.UserId
        parameters(11).Value = Me.Intime
        parameters(12).Value = Me.Usey
        parameters(13).Value = Integer.Parse(GETID)

        parameters(14).Value = PartID
        parameters(15).Value = SWorkHours
        parameters(16).Value = CustPartID
        Try
            Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim ref As String = conn.ExecuteNonQuery(strSql.ToString(), parameters)
            If ref = "" Then
                SysMessageClass.SaveUserOpLog(Me, "新增计划ID：" + GETID)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function UpdateLineInfoData() As Boolean

        Dim leaderid As String = txtleaderid.Text.Trim
        Dim leadername As String = txtleadername.Text.Trim
        Dim PieCode As String = txtPieCode.Text.Trim
        Dim PieName As String = txtPieName.Text.Trim
        Dim PqeCode As String = txtPqeCode.Text.Trim
        Dim PqeName As String = txtPqeName.Text.Trim
        Dim SjCode As String = txtSjCode.Text.Trim
        Dim SjName As String = txtSjName.Text.Trim
        Dim Lineid As String = CboLine.SelectedValue
        ' Dim sql As String = "update deptlineD_t set leaderid='" & leaderid & "',leadername=N'" & leadername & "',PieCode='" & PieCode & "',PieName=N'" & PieName & "',PqeCode='" & PqeCode & "',PqeName=N'" & PqeName & "',SjCode='" & SjCode & "',SjName=N'" & SjName & "' where Lineid='" & Lineid & "' and usey='Y' "
        Dim strSql As StringBuilder = New StringBuilder()
        strSql.Append(" if not exists(select * from deptlineD_t where Lineid=@Lineid and usey='Y') ")
        strSql.Append(" begin ")
        strSql.Append(" insert deptlineD_t(deptid,lineid,leaderid,leadername,lineman,usey,userid,intime,PieCode,PieName,PqeCode,PqeName,SjCode,SjName)")
        strSql.Append(" select deptid,lineid,leaderid='" & leaderid & "',leadername=N'" & leadername & "',lineman,usey,userid='" & VbCommClass.VbCommClass.UseId & "',intime=getdate(),PieCode='" & PieCode & "',PieName=N'" & PieName & "',PqeCode='" & PqeCode & "',PqeName=N'" & PqeName & "',SjCode='" & SjCode & "',SjName=N'" & SjName & "'	from deptline_t where Lineid=@Lineid and usey='Y' ")
        strSql.Append(" end ")
        strSql.Append(" else ")
        strSql.Append(" begin ")
        strSql.Append(" update deptlineD_t set leaderid='" & leaderid & "',leadername=N'" & leadername & "',PieCode='" & PieCode & "',PieName=N'" & PieName & "',PqeCode='" & PqeCode & "',PqeName=N'" & PqeName & "',SjCode='" & SjCode & "',SjName=N'" & SjName & "' where Lineid=@Lineid and usey='Y' ")
        strSql.Append(" end ")
        Dim parameters() As SqlParameter = {New SqlParameter("@Lineid", SqlDbType.VarChar, 10)}

        parameters(0).Value = Lineid
        Try
            Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim ref As String = conn.ExecuteNonQuery(strSql.ToString(), parameters)
            If ref = "" Then
                SysMessageClass.SaveUserOpLog(Me, "新增线别责任人：" + Lineid)
                Return True
            Else
                MessageBox.Show("新增失败:" & ref)
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub CboDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboDept.SelectedIndexChanged
        If Not CboDept.SelectedValue Is Nothing AndAlso CboDept.SelectedValue.ToString <> "" Then
            Dim sql As String = " SELECT lineid as value, lineid as text  FROM deptline_t " & _
                                " WHERE factoryid ='" & VbCommClass.VbCommClass.Factory & "' " & _
                                " AND deptid='" & Me.CboDept.SelectedValue.ToString() & "' "
            Using dt As DataTable = VbCommClass.CommClass.GetDeptLineDt(Me.CboDept.SelectedValue.ToString()) 'DbOperateUtils.GetDataTable(sql)
                dt.Rows.InsertAt(dt.NewRow, 0)
                CboLine.ValueMember = "lineid"
                CboLine.DisplayMember = "lineid"
                CboLine.DataSource = dt.DefaultView
            End Using
        End If
    End Sub

    Private Sub CboLine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboLine.SelectedIndexChanged
        If Not CboLine.SelectedValue Is Nothing AndAlso CboLine.SelectedValue.ToString <> "" Then
            Dim sql As String = "select lineid,XzCode=leaderid,XzName=leadername,PieCode,PieName,PqeCode,PqeName,SjCode,SjName from deptlineD_t where Lineid='" & CboLine.SelectedValue.ToString() & "' and usey='Y'"

            Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                txtleaderid.Text = dr("XzCode").ToString
                txtleadername.Text = dr("XzName").ToString
                txtPieCode.Text = dr("PieCode").ToString
                txtPieName.Text = dr("PieName").ToString
                txtPqeCode.Text = dr("PqeCode").ToString
                txtPqeName.Text = dr("PqeName").ToString
                txtSjCode.Text = dr("SjCode").ToString
                txtSjName.Text = dr("SjName").ToString
            End If



        End If
    End Sub

    Private Sub chkEdit_CheckedChanged(sender As Object, e As EventArgs) Handles chkEdit.CheckedChanged
        If chkEdit.Checked Then
            Me.GroupBox1.Enabled = True

        Else
            Me.GroupBox1.Enabled = False
        End If
        chkEdit.Enabled = True
    End Sub
    Private Sub SetXMLNodeData(ByVal XmlNodeName As String, ByVal XmlNodeValue As String)
        Dim strAssemblyFilePath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim strAssemblyDirPath As String = System.IO.Path.GetDirectoryName(strAssemblyFilePath)
        Dim FilePath As String = strAssemblyDirPath + "\\config.xml"
        Dim lXmlDocument As XmlDocument = New XmlDocument()
        If File.Exists(FilePath) Then
            Dim IsExistsNode As Boolean = False
            lXmlDocument.Load(FilePath)
            Dim lXmlNodeList As XmlNodeList = lXmlDocument.SelectSingleNode("Info").ChildNodes
            Dim xn As XmlNode
            For Each xn In lXmlNodeList
                If xn.Name.ToUpper().Equals(XmlNodeName.ToUpper()) Then
                    xn.InnerText = XmlNodeValue
                    IsExistsNode = True
                    Continue For
                End If
            Next
            If Not IsExistsNode Then
                Dim lChildXmlElement As XmlElement = lXmlDocument.CreateElement(XmlNodeName)
                lChildXmlElement.InnerText = XmlNodeValue
                lXmlDocument.SelectSingleNode("Info").AppendChild(lChildXmlElement)
            End If
            lXmlDocument.Save(FilePath)
        Else
            Dim lXmlNode As XmlElement = lXmlDocument.CreateElement("Info")
            Dim lChildXmlElement As XmlElement = Nothing
            lChildXmlElement = lXmlDocument.CreateElement(XmlNodeName)
            lChildXmlElement.InnerText = XmlNodeValue
            lXmlNode.AppendChild(lChildXmlElement)
            lXmlDocument.AppendChild(lXmlNode)
            lXmlDocument.Save(FilePath)
        End If
    End Sub

    Private Function GetXMLNodeData(ByVal XmlNodeName As String) As String
        Dim XmlNodeValue As String = ""
        Dim strAssemblyFilePath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim strAssemblyDirPath As String = System.IO.Path.GetDirectoryName(strAssemblyFilePath)
        Dim FilePath As String = strAssemblyDirPath + "\\config.xml"
        Dim lXmlDocument As XmlDocument = New XmlDocument()
        Try
            If File.Exists(FilePath) Then
                lXmlDocument.Load(FilePath)
                Dim lXmlNodeList As XmlNodeList = lXmlDocument.SelectSingleNode("Info").ChildNodes
                Dim xn As XmlNode
                For Each xn In lXmlNodeList
                    If xn.Name.ToUpper().Equals(XmlNodeName.ToUpper()) Then
                        XmlNodeValue = xn.InnerText
                    End If
                Next
            Else
                Dim lXmlNode As XmlElement = lXmlDocument.CreateElement("Info")
                Dim lChildXmlElement As XmlElement = Nothing
                lChildXmlElement = lXmlDocument.CreateElement(XmlNodeName)
                lChildXmlElement.InnerText = XmlNodeValue
                lXmlNode.AppendChild(lChildXmlElement)
                lXmlDocument.AppendChild(lXmlNode)
                lXmlDocument.Save(FilePath)
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return XmlNodeValue
    End Function

    ''' <summary>
    ''' 选择工单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_Click(sender As Object, e As EventArgs) Handles Btn.Click
        Dim frm = New FrmWorkOrder()
        Dim dr = frm.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            TxtMoid.Text = frm._MoNO
            txtPartNO.Text = frm._PartNO
            txtCustPartID.Text = frm._CustPartID
        End If
    End Sub
End Class