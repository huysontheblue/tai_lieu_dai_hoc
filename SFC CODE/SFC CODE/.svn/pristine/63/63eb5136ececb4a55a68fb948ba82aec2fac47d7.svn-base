Imports MainFrame.SysCheckData
Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame.SysDataHandle
Imports System.Runtime.InteropServices
Imports MainFrame
''' <summary>
''' 修改者：田玉琳
''' 修改日期：2018/11/12
''' 修改内容：优化代码，去除乱码
''' 
''' </summary>
''' <remarks></remarks>

Public Class FrmUserManage
    Dim PassWordTest As New TextHandle
    Dim SqlCheckStr As New StringBuilder
    'Dim TreeClass As New MainFrame.SysDataHandle.SysDataBaseClass
    Private WithEvents DGuserHandle As DataGridView
    Dim StrPassword As String
    Dim AutoCheck As Boolean
    Dim UserDg As DataTable
    Dim UserContrast As String

    Public Hwnd As Int32
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32

    Private Sub FrmUserManage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        Dim TabTrans As New TextHandle
        TabTrans.TabTransEnter(sender, e)
        TabTrans = Nothing

    End Sub

    Private Sub FrmUserManage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '关晓艳 隐藏掉角色管理面板 2018-4-24
        Me.TabControl1.TabPages.Remove(Me.TabPage1)

        Dim EngSetClass As New SysDataBaseClass
        '获取主窗口句柄
        '    Hwnd = Int32.Parse(Me.Text.Substring(Me.Text.IndexOf(":") + 1, Me.Text.Length - Me.Text.IndexOf(":") - 1))
        If Me.Text.IndexOf(":") > 0 Then
            Me.Text = Me.Text.Substring(0, Me.Text.IndexOf(":"))
        End If

        If LCase(SysMessageClass.Language) = "english" Then
            EngSetClass.GetControlEnglishText(Me)
        End If

        'EngSetClass.GetControlright(Me)
        Me.SplitContainer1.Panel1Collapsed = True
        Treeload()
        'UserInf()
        FillCobFactory(CboFactoryID, "select Factoryid,Shortname from m_Dcompany_t where usey='Y'")
        FillCobType(CboDept, "select Deptid,djc from m_Dept_t where usey='Y'")
        FillCobType(Me.CobDeptShow, "select Deptid,djc from m_Dept_t where usey='Y'")
        FillCobType(Me.CobDeptSearch, "select Deptid,djc from m_Dept_t where usey='Y'")
        '关晓艳 2018-05-25    取消用户工号填充
        'FillCobUser(CobUseShow, "select userid from m_Users_t where usey = '1' ")
        CobDeptSearch.Text = "ALL"
        'CobDeptShow.SelectedIndex = 0
        'If Me.UserinfDg.Rows.Count < 1 Then Exit Sub
        'CheckData(Me.UserinfDg.Rows(0).Cells(0).Value)
        ReLodaData()
        SetValueToControl()
    End Sub

#Region "初期化"
    Private Sub SetValueToControl()
        If Me.UserinfDg.Rows.Count < 1 Then Exit Sub
        Me.TxtUserID.Text = Me.UserinfDg.Item(0, UserinfDg.CurrentRow.Index).Value.ToString
        Me.TxtUserName.Text = Me.UserinfDg.Item(1, UserinfDg.CurrentRow.Index).Value.ToString
        If Me.UserinfDg.Item(2, UserinfDg.CurrentRow.Index).Value.ToString = "" Then
            Me.CboDept.Text = ""
        Else
            Me.CboDept.Text = Me.UserinfDg.Item(2, UserinfDg.CurrentRow.Index).Value.ToString & "(" & Me.UserinfDg.Item(3, UserinfDg.CurrentRow.Index).Value.ToString & ")"
        End If
        Me.CboJobs.Text = Me.UserinfDg.Item(4, UserinfDg.CurrentRow.Index).Value.ToString
        Me.CboTeam.Text = Me.UserinfDg.Item(5, UserinfDg.CurrentRow.Index).Value.ToString
        Me.CboGroupID.Text = Me.UserinfDg.Item(6, UserinfDg.CurrentRow.Index).Value.ToString
        Me.CboFactoryID.Text = Me.UserinfDg.Item(7, UserinfDg.CurrentRow.Index).Value.ToString
        Me.TxtAutoId.Text = Me.UserinfDg.Item(8, UserinfDg.CurrentRow.Index).Value.ToString
        Me.TxtDescript.Text = Me.UserinfDg.Item(9, UserinfDg.CurrentRow.Index).Value.ToString
        ChBusey.Checked = IIf(Me.UserinfDg.Item(10, UserinfDg.CurrentRow.Index).Value = "Yes", True, False)
        cboverifytype.Text = Me.UserinfDg.Item(11, UserinfDg.CurrentRow.Index).Value.ToString
        'gxy
        cbousergrade.Text = Me.UserinfDg.Item(12, UserinfDg.CurrentRow.Index).Value.ToString
        ChOutuser.Checked = IIf(Me.UserinfDg.Item(13, UserinfDg.CurrentRow.Index).Value = "Y", True, False)
    End Sub
#End Region

#Region "事件"
    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolBt.ItemClicked

        Select Case e.ClickedItem.Name
            Case "NewFile"
                SysMessageClass.EditFlag = True
                AddRecord()
                'Me.CboFactoryID.SelectedIndex = 0
                Me.TxtUserID.Focus()
                'Me.cboverifytype.SelectedIndex = 0
            Case "EditFile"

                SysMessageClass.EditFlag = False
                If Me.UserinfDg.Rows.Count < 1 Then Exit Sub
                EditRecord()
                Me.TxtUserName.Focus()
            Case "Save"
                SaveData()
            Case "Delete"
                If Me.UserinfDg.Rows.Count < 1 Then Exit Sub
                DeleteRecord()
            Case "StopFile"
                StopRecord()
            Case "UnDo"
                AutoCheck = True
                CancelChg()
                ReLodaData()
                AutoCheck = False
            Case "Export"

            Case "Search"
                If Me.SplitContainer1.Panel1Collapsed = True Then
                    Me.SplitContainer1.Panel1Collapsed = False
                Else
                    Me.SplitContainer1.Panel1Collapsed = True
                End If
                Me.TxtSearch.Focus()
            Case "ReSetPw"
                Try
                    'If MessageBox.Show(MultLanguage.MultMessage.GetMsg("M000516"), MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    If MessageBox.Show("是不要重设置密码？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        Dim StrRandomize As String
                        Randomize()
                        StrRandomize = Int(Rnd() * 10) & (Int(Rnd() * 10)) & (Int(Rnd() * 10)) & (Int(Rnd() * 10)) & (Int(Rnd() * 10)) & (Int(Rnd() * 10))
                        DbOperateUtils.ExecSQL("update m_users_t set password='" & PassWordTest.EnCryptPassword(StrRandomize) & "' where userid='" & Trim(Me.TxtUserID.Text).ToLower & "'")
                        MessageBox.Show("设置成功..." & StrRandomize & vbCrLf & "请登录后后修改密码。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'MessageBox.Show(MultLanguage.MultMessage.GetMsg("M000467") & StrRandomize, MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch ex As Exception
                    'MessageBox.Show(ex.Message & vbCrLf & MultLanguage.MultMessage.GetMsg("M000468"), MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK)
                    MessageBox.Show(ex.Message & vbCrLf & "重设置密码失败...", "提示信息", MessageBoxButtons.OK)
                    Exit Sub
                End Try
            Case "FileRefresh"
                Me.TxtSearch.Text = ""
                Me.TxtUnSearch.Text = ""
                Me.CobDeptSearch.Text = "ALL"
                ReLodaData()
            Case "ExitFrom"
                Me.Close()
                'add by song
                '2016-03-11
                '增加设置角色按钮
            Case "SetRole"
                Dim fsr As New FrmSelectRole
                fsr.UserId = TxtUserID.Text.Trim()
                fsr.ShowDialog()
        End Select

    End Sub

#End Region

    Private Sub UserinfDg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserinfDg.Click
        Try
            If Me.UserinfDg.CurrentRow.Index = -1 Then Exit Sub
            SetValueToControl()
            RightShow(sender, e)
        Catch ex As Exception
        End Try
    End Sub

#Region "设置控件状态"

    Private Sub SetControlStutas(ByVal FlagStr As String)

        'Dim EmsControl As New System.Windows.Forms.ToolStripButton
        Dim i As Integer

        Select Case UCase(FlagStr)
            Case "ADD"
                For i = 0 To Me.ToolBt.Items.Count - 1
                    If ToolBt.Items(i).Name <> "ExitFrom" Then
                        If ToolBt.Items(i).Name <> "Save" And ToolBt.Items(i).Name <> "UnDo" Then
                            ToolBt.Items(i).Enabled = False
                        Else
                            ToolBt.Items(i).Enabled = True
                        End If
                    End If
                Next
                Me.UserinfDg.Enabled = False
            Case Else
                For i = 0 To Me.ToolBt.Items.Count - 1
                    If ToolBt.Items(i).Name <> "ExitFrom" Then
                        If ToolBt.Items(i).Name <> "Save" And ToolBt.Items(i).Name <> "UnDo" Then
                            'If ToolBt.Items(i).Tag = "YES" Then
                            ToolBt.Items(i).Enabled = True
                            'End If
                        Else
                            ToolBt.Items(i).Enabled = False
                        End If
                    End If
                Next
                Me.UserinfDg.Enabled = True
        End Select

    End Sub
#End Region

#Region "设置控件可编辑性"

    Private Sub ChgRecord(ByVal Flag As Integer)

        Dim EmsCon As Control
        Select Case Flag
            Case 0
                For Each EmsCon In TabControl1.TabPages(0).Controls
                    If TypeOf EmsCon Is System.Windows.Forms.TextBox Then
                        EmsCon.Enabled = True
                    ElseIf TypeOf EmsCon Is System.Windows.Forms.CheckBox Then
                        EmsCon.Enabled = True
                    ElseIf TypeOf EmsCon Is ComboBox Then
                        EmsCon.Enabled = True
                    End If
                Next
                If SysMessageClass.EditFlag = False Then
                    Me.TxtUserID.Enabled = False
                End If
                Me.SplitContainer1.Panel1Collapsed = True
            Case 1
                For Each EmsCon In TabControl1.TabPages(0).Controls
                    If TypeOf EmsCon Is System.Windows.Forms.TextBox Then
                        EmsCon.Enabled = False
                    ElseIf TypeOf EmsCon Is System.Windows.Forms.CheckBox Then
                        EmsCon.Enabled = False
                    ElseIf TypeOf EmsCon Is ComboBox Then
                        EmsCon.Enabled = False
                    End If

                Next
        End Select
        Me.TxtAutoId.Enabled = False
    End Sub

#End Region

#Region "取消"

    Private Sub CancelChg()

        ChgRecord(1)
        SetControlStutas("")

    End Sub
#End Region

#Region "增加记录"

    Private Sub AddRecord()

        ChgRecord(0)
        SetControlStutas("ADD")
        ClearControl()

    End Sub

#End Region

#Region "编辑记录"

    Private Sub EditRecord()

        ChgRecord(0)
        SetControlStutas("ADD")

    End Sub

#End Region

#Region "清空控件内容"
    Private Sub ClearControl()
        'Dim PubClear As New MainFrame.SysCheckData.TextHandle
        'ChBusey.Checked = True
        'PubClear.ClearControl(Me.SplitContainer1.Panel1)

        Dim ClearCon As Control
        ChBusey.Checked = True
        For Each ClearCon In TabControl1.TabPages(0).Controls
            If TypeOf ClearCon Is System.Windows.Forms.TextBox Then
                ClearCon.Text = ""
            ElseIf TypeOf ClearCon Is ComboBox Then
                ClearCon.Text = ""
            End If
        Next

    End Sub
#End Region

#Region "初期化下拉列表"
    Private Sub FillCobType(ByVal CboName As ComboBox, ByVal SqlStr As String)

        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass

        Dim CboDr As SqlDataReader
        CboName.Items.Clear()
        If Not CboName Is CboDept Then
            CboName.Items.Add("ALL")
        End If
        CboDr = Sdbc.GetDataReader(SqlStr)
        If CboDr.HasRows Then
            While CboDr.Read
                CboName.Items.Add(CboDr.GetString(0) & "(" & CboDr.GetString(1) & ")")
            End While
        End If
        Sdbc = Nothing
        CboDr.Close()

    End Sub
    Private Sub FillCobUser(ByVal CboName As ComboBox, ByVal SqlStr As String)

        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass

        Dim CboDr As SqlDataReader
        CboName.Items.Clear()

        CboDr = Sdbc.GetDataReader(SqlStr)
        If CboDr.HasRows Then
            While CboDr.Read
                CboName.Items.Add(CboDr.GetString(0))
            End While
        End If
        Sdbc = Nothing
        CboDr.Close()

    End Sub
    Private Sub FillCobFactory(ByVal CboName As ComboBox, ByVal SqlStr As String)

        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass

        Dim CboDr As SqlDataReader
        CboName.Items.Clear()
        CboDr = Sdbc.GetDataReader(SqlStr)
        If CboDr.HasRows Then
            While CboDr.Read
                CboName.Items.Add(CboDr.GetString(0))
            End While
        End If
        Sdbc = Nothing
        CboDr.Close()

    End Sub
#End Region

#Region "删除记录"

    Private Sub DeleteRecord()
        If Me.UserinfDg.CurrentRow.Index = -1 Then Exit Sub
        Dim SqlString As New StringBuilder
        'If MessageBox.Show(MultLanguage.MultMessage.GetMsg("M000002"), MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
        If MessageBox.Show("你确认要删除该用户吗？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

            Try
                SqlString.Append("delete from m_UserRight_t where userid='" & Me.UserinfDg.Item(0, Me.UserinfDg.CurrentRow.Index).Value & "'")
                SqlString.Append(Environment.NewLine)
                SqlString.Append("delete from m_users_t  where userid ='" & Me.UserinfDg.Item(0, Me.UserinfDg.CurrentRow.Index).Value & "'")
                DbOperateUtils.ExecSQL(SqlString.ToString)
                ReLodaData()
                'UserInf()
            Catch Eex As Exception
                'MessageBox.Show(Eex.Message & vbNewLine & MultLanguage.MultMessage.GetMsg("M000170"), MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK)
                MessageBox.Show(Eex.Message & vbNewLine & "删除时发生错误!", "提示信息", MessageBoxButtons.OK)
            Finally
            End Try
        End If
        SetValueToControl()
    End Sub
#End Region

#Region "作废用户"
    Private Sub StopRecord()

        If Me.UserinfDg.Rows.Count < 1 Then Exit Sub
        Dim SqlString As New StringBuilder
        'If MessageBox.Show(MultLanguage.MultMessage.GetMsg("M000196"), MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
        If MessageBox.Show("你确认要作废该用户吗？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Try
                SqlString.Append("delete from m_UserRight_t where userid='" & Me.UserinfDg.Item(0, Me.UserinfDg.CurrentRow.Index).Value & "'")
                SqlString.Append(Environment.NewLine)
                SqlString.Append("update m_users_t set usey='0' where userid ='" & Me.UserinfDg.Item(0, Me.UserinfDg.CurrentRow.Index).Value & "'")
                DbOperateUtils.ExecSQL(SqlString.ToString)
                ReLodaData()
                'UserInf()
            Catch Eex As Exception
                'MessageBox.Show(Eex.Message & vbNewLine & MultLanguage.MultMessage.GetMsg("M000306"), MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK)
                MessageBox.Show(Eex.Message & vbNewLine & "作废时发生错误!", "提示信息", MessageBoxButtons.OK)
            Finally
            End Try
        End If
    End Sub
#End Region

#Region "重新加载数据"
    Private Sub ReLodaData()

        Dim ChColsText As String
        'gxy
        'UserDg = DbOperateUtils.GetDataTable("Select  a.userid,a.username,a.dept,b.djc,a.jobs,a.team,a.groupid,a.factoryid,a.autoid,a.descript,case when a.Usey='1' then 'Yes' else 'No' end,Verifytype=case Verifytype when '1' then N'1-指纹验证' when '2' then N'2-密码+指纹验证' else N'0-密码验证' end ,UserGrade=case UserGrade when '3' then N'3-IT系统管理员' when '2' then N'2-管理人员' else N'1-普通用户' end ,ISNULL(IsOutUser,'') AS IsOutUser from m_users_t a left join m_Dept_t b on a.dept=b.deptid and a.factoryid=b.factoryid order by a.intime desc")
        'ZKH优化登录人工号放在第一
        UserDg = DbOperateUtils.GetDataTable("SELECT userid,username,dept,djc,jobs,team,groupid,factoryid,autoid,descript,usey, Verifytype, UserGrade, IsOutUser FROM(SELECT a.Intime ,a.userid,a.username,a.dept,b.djc,a.jobs,a.team,a.groupid,a.factoryid,a.autoid,a.descript,(CASE when a.Usey='1' then 'Yes' else 'No' END)usey,Verifytype=case Verifytype when '1' " &
                                            " then N'1-指纹验证' when '2' then N'2-密码+指纹验证'else N'0-密码验证' end ,UserGrade=case UserGrade when '3' THEN N'3-IT系统管理员' when '2' then N'2-管理人员' else N'1-普通用户' end ,ISNULL(IsOutUser,'') AS IsOutUser ,1 AS weight " &
                                            " FROM m_users_t a left join m_Dept_t b on a.dept=b.deptid and a.factoryid=b.factoryid WHERE a.UserID='" + VbCommClass.VbCommClass.UseId + "'  UNION " &
                                            " SELECT a.Intime, a.userid,a.username,a.dept,b.djc,a.jobs,a.team,a.groupid,a.factoryid,a.autoid,a.descript,(CASE when a.Usey='1' then 'Yes' else 'No' END) usey,Verifytype=case Verifytype when '1' then N'1-指纹验证' when '2' then N'2-密码+指纹验证' " &
                                            " else N'0-密码验证' end ,UserGrade=case UserGrade when '3' THEN N'3-IT系统管理员' when '2' then N'2-管理人员' else N'1-普通用户' end , ISNULL(IsOutUser,'') AS IsOutUser, 2 AS weight from m_users_t a left join m_Dept_t b " &
                                            " on a.dept=b.deptid and a.factoryid=b.factoryid WHERE a.UserID<>'" + VbCommClass.VbCommClass.UseId + "' )A ORDER by  A.weight ,A.intime desc")
        UserinfDg.DataSource = UserDg
        'gxy
        ChColsText = "用户ID|用户名|部门编号|部门名称|职称|部门组别|群组|营运中心|自动编码|描述|有效否|验证方式|用户级别|是否厂外员工"

        Dim colNames As String() = ChColsText.Split("|")
        Dim i%
        For i = 0 To UserinfDg.Columns.Count - 1
            UserinfDg.Columns(i).HeaderText = colNames(i)
            UserinfDg.Columns(i).Name = colNames(i)
        Next
        SetValueToControl()
        If Me.UserinfDg.Rows.Count < 1 Then Exit Sub
        If Me.UserinfDg.CurrentRow.Index < 0 Then Exit Sub
        CheckData(Me.UserinfDg.CurrentRow.Cells(0).Value)
    End Sub
#End Region

#Region "保存数据"
    Private Sub SaveData()

        Dim DeptStirng As String
        Dim DrCheck As Integer
        Try
            CheckRecord()
            If InStr(Trim(Me.CboDept.Text), "(") > 0 Then
                DeptStirng = Mid(Trim(Me.CboDept.Text), 1, InStr(Trim(Me.CboDept.Text), "(") - 1)
            Else
                DeptStirng = Trim(Me.CboDept.Text)
            End If

            If SysMessageClass.EditFlag Then
                DrCheck = DbOperateUtils.GetRowsCount("select userid from m_users_t where userid='" & Trim(Me.TxtUserID.Text).ToLower & "'")
                If DrCheck > 0 Then
                    'MessageBox.Show(MultLanguage.MultMessage.GetMsg("M000517"), MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MessageBox.Show("已经存在该用户编号", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                '关晓艳修改新加栏位用户级别 2017/11/13
                If Me.cbousergrade.Text.Trim = "" Then
                    Me.cbousergrade.Text = "1-普通用户"
                End If

                DbOperateUtils.ExecSQL("insert m_users_t(UserID,UserName,PassWord,Descript,Dept,Team,Jobs,GroupID,FactoryID,Usey,autoid,Creater,Intime,Verifytype,UserGrade,IsOutUser) values(N'" & Trim(Me.TxtUserID.Text).ToUpper & "',N'" & Trim(Me.TxtUserName.Text) & "','" & PassWordTest.EnCryptPassword(Trim(StrPassword)) & "',N'" & Trim(Me.TxtDescript.Text) & "',N'" & DeptStirng & "',N'" & Trim(Me.CboTeam.Text) & "',N'" & Trim(Me.CboJobs.Text) & "',N'" & Trim(Me.CboGroupID.Text) & "',N'" & Trim(Me.CboFactoryID.Text) & "','" & IIf(ChBusey.Checked, "1", "0") & "','" & Trim(Me.TxtAutoId.Text).ToLower & "','" & SysMessageClass.UseId & "',getdate(),'" & cboverifytype.Text.Split("-")(0).ToString() & "','" & cbousergrade.Text.Split("-")(0).ToString() & "','" & IIf(ChOutuser.Checked, "Y", "N") & "')")

                'MessageBox.Show(MultLanguage.MultMessage.GetMsg("M000518"), MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                MessageBox.Show("密码： " & StrPassword, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                '关晓艳修改新加栏位用户级别 2017/11/13
                DbOperateUtils.ExecSQL("update m_users_t set username=N'" & Trim(Me.TxtUserName.Text) & "',descript=N'" & Trim(Me.TxtDescript.Text) & "',dept=N'" & DeptStirng & "',team=N'" & Trim(Me.CboTeam.Text) & "',jobs=N'" & Trim(Me.CboJobs.Text) & "',GroupID=N'" & Trim(Me.CboGroupID.Text) & "',FactoryID=N'" & Trim(Me.CboFactoryID.Text) & "',usey='" & IIf(ChBusey.Checked, "1", "0") & "',Verifytype='" & cboverifytype.Text.Split("-")(0).ToString() & "',UserGrade='" & cbousergrade.Text.Split("-")(0).ToString() & "',IsOutUser = '" & IIf(ChOutuser.Checked, "Y", "N") & "' where userid='" & Trim(Me.TxtUserID.Text).ToLower & "'")
                'Sdbc.PubConnection.Close()
            End If
            ''UserinfDg.Rows.Insert(UserinfDg.Rows.Count, Trim(TxtUserID.Text), DeptStirng, Mid(Trim(Me.CboDept.Text), InStr(Trim(Me.CboDept.Text), "(")), CboJobs.Text, CboTeam.Text, CboGroupID.Text, CboFactoryID.Text, TxtAutoId.Text, TxtDescript.Text, IIf(ChBusey.Checked, "1", "0"))
            SetControlStutas("")
            SetValueToControl()
            ChgRecord(1)
            ReLodaData()
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & "新增用户时，发生错误...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'MessageBox.Show(ex.Message, MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Finally
            StrPassword = ""
        End Try

        'UserInf()
    End Sub
#End Region

#Region "数据检查"
    Private Sub CheckRecord()

        Dim UserIDErr As New Exception("用户编号不能为空!")
        'Dim UserIDErr As New Exception(String.Format(MultLanguage.MultMessage.GetMsg("M000079"), LabUserid.Text.Trim(":")))
        UserIDErr.Source = "CheckRecord"
        If Me.TxtUserID.Text = "" Then
            Throw UserIDErr
        End If

        Dim DeptErr As New Exception("部门不能为空!")
        'Dim DeptErr As New Exception(String.Format(MultLanguage.MultMessage.GetMsg("M000079"), LabDept.Text.Trim(":")))
        DeptErr.Source = "CheckRecord"
        If Me.CboDept.Text = "" Then
            Throw DeptErr
        End If

        'Dim FactIDErr As New Exception(String.Format(MultLanguage.MultMessage.GetMsg("M000079"), LabFactory.Text.Trim(":")))
        Dim FactIDErr As New Exception("营运中心不能为空!")
        FactIDErr.Source = "CheckRecord"
        If Me.CboFactoryID.Text = "" Then
            Throw FactIDErr
        End If

    End Sub
#End Region

#Region "树AfterCheck"
    Private Sub UserTree_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles UserTree.AfterCheck

        If e.Action <> TreeViewAction.Unknown Then
            Me.UserTree.BeginUpdate()
            Try
                RightAddorDel(e.Node.Name, e.Node, Me.UserinfDg.CurrentRow.Cells(0).Value, e.Node.Nodes.Count, e.Node.Checked, True)
            Catch ex As Exception
                Throw ex
            Finally
                SqlCheckStr.Remove(0, SqlCheckStr.Length - 1)
            End Try

            Me.UserTree.EndUpdate()
        End If

    End Sub

#End Region

    Private Sub RightAddorDel(ByVal NodeName As String, ByVal Node As TreeNode, ByVal StrUserid As String, ByVal NodesCount As Integer, ByVal AddOrDel As Boolean, ByVal NodeChecky As Boolean)
        '关晓艳 add 输入三级菜单查询时 检查有兄弟节点时 父节点不取消勾选
        If i = 2 And Node.Level = 1 Then
            Dim deleSQL1 As String = "select 1 from (select Tkey  from m_userright_t where  userid='" & StrUserid & "') AA  Join " _
                                      & " (select Tkey from m_LogTree_t where Tparent ='" & Node.Name & "') BB on AA.Tkey=BB .Tkey "
            Dim deleDT1 As DataTable = DbOperateUtils.GetDataTable(deleSQL1)
            If deleDT1.Rows.Count > 0 Then
                Node.Checked = True
                SqlCheckStr.Append("  ")
                Return
            End If
        ElseIf i = 2 And Node.Level = 0 Then
            Node.Checked = True
            SqlCheckStr.Append("  ")
            Return
        End If

        SqlCheckStr = New StringBuilder
        If AddOrDel = True Then
            SqlCheckStr.Append("insert m_userright_t values('" & StrUserid & "','" & NodeName & "','" & SysMessageClass.UseId & "',getdate())")
            SqlCheckStr.Append(Environment.NewLine)
            CheckAllParentNodes(Node, StrUserid, NodeChecky)
            If NodesCount > 0 Then
                Me.CheckAllChildNodes(Node, StrUserid, AddOrDel, NodeChecky)
                Try
                    DbOperateUtils.ExecSQL(SqlCheckStr.ToString)
                Catch ex As Exception
                End Try

            Else
                Try
                    DbOperateUtils.ExecSQL(SqlCheckStr.ToString)
                Catch ex As Exception
                End Try
            End If
        Else
            SqlCheckStr.Append("delete from m_userright_t where tkey='" & NodeName & "' and userid='" & StrUserid & "'")
            SqlCheckStr.Append(Environment.NewLine)

            If NodesCount > 0 Then
                Me.CheckAllChildNodes(Node, StrUserid, AddOrDel, NodeChecky)
                ' TreeClass.ExecSql(SqlCheckStr.ToString)
            End If
            'If Not Node.Parent Is Nothing Then
            '    ' add by 马跃平 2017-12-22 当所有子节点取消勾选的时候,父节点也要取消勾选并取消权限
            '    Dim curNodeParent As TreeNode = Node.Parent
            '    Dim nodeChild As TreeNode
            '    Dim IsCheck As Boolean = False

            '    For Each nodeChild In curNodeParent.Nodes
            '        If nodeChild.Checked = True Then
            '            IsCheck = True
            '            Exit For
            '        End If
            '    Next

            '    '关晓艳 add 查询时存在子节点 不取消勾选 2018-04-24
            '    Dim deleSQL As String = "select 1 from (select Tkey  from m_userright_t where  userid='" & StrUserid & "') AA  Join " _
            '                            & " (select Tkey from m_LogTree_t where Tparent ='" & curNodeParent.Name & "') BB on AA.Tkey=BB .Tkey "
            '    Dim deleDT As DataTable = DbOperateUtils.GetDataTable(deleSQL)
            '    If deleDT.Rows.Count > 1 Then
            '        IsCheck = True
            '    End If
            '    ''end

            '    curNodeParent.Checked = IsCheck
            '    If curNodeParent.Checked = False Then
            '        SqlCheckStr.Append("delete from m_userright_t where tkey='" & curNodeParent.Name & "' and userid='" & StrUserid & "'")
            '        SqlCheckStr.Append(Environment.NewLine)
            '    End If
            '    '---end 

            'End If
            DbOperateUtils.ExecSQL(SqlCheckStr.ToString)
        End If

    End Sub

#Region "用户GRIDKeyUp"
    Private Sub RightShow(ByVal sender As Object, ByVal e As System.EventArgs)

        If Me.UserinfDg.Rows.Count < 1 Then Exit Sub
        If Me.UserinfDg.CurrentRow.Index < 0 Then Exit Sub
        CheckData(Me.UserinfDg.CurrentRow.Cells(0).Value)

    End Sub

    Private Sub UserinfDg_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UserinfDg.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Then
            RightShow(sender, e)
        End If
    End Sub
#End Region

#Region "创建树"

    Public Sub CreateTree(ByVal treeview As TreeView, ByVal ParentID As String, ByVal pNode As TreeNode, ByVal TreeDt As DataTable, ByVal LagStr As String)
        Dim tempRow As DataRow

        For Each tempRow In TreeDt.Select("tParent='" + ParentID + "'")
            Dim Node As New TreeNode
            Try
                If pNode Is Nothing Then
                    'Select Case LagStr
                    '    Case "big5"
                    Node.Text = tempRow("Ttext").ToString()

                    '    Case "english"
                    'Node.Text = tempRow("Enname").ToString()

                    'End Select
                    treeview.Nodes.Add(Node)
                    Node.ImageIndex = 0
                    Node.SelectedImageIndex = 0
                    Node.Name = tempRow("tkey").ToString()
                    Node.Tag = tempRow("TreeTag").ToString()
                Else
                    'Select Case LagStr
                    '    Case "big5"
                    Node.Text = tempRow("Ttext").ToString()
                    '    Case "english"
                    'Node.Text = tempRow("Enname").ToString()
                    'End Select
                    pNode.Nodes.Add(Node)
                    Node.Name = tempRow("tkey").ToString()
                    Node.Tag = tempRow("TreeTag").ToString()
                    If Node.Tag = "" Then
                        Node.ImageIndex = 1
                        Node.SelectedImageIndex = 1
                    Else
                        Node.ImageIndex = 2
                        Node.SelectedImageIndex = 2
                    End If
                End If

                If TreeDt.Select("tParent='" + tempRow("Tkey").ToString() + "'").Length > 0 Then
                    CreateTree(treeview, tempRow("Tkey").ToString, Node, TreeDt, LagStr)
                End If
            Catch err As Exception
                'MessageBox.Show(err.Message, MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
        'End If

    End Sub

#End Region

#Region "检查所有结点"

    Private Sub CheckAllChildNodes(ByVal treeNode As TreeNode, ByVal userid As String, ByVal nodeChecked As Boolean, ByVal NodeChecky As Boolean)

        Dim node As TreeNode
        For Each node In treeNode.Nodes
            If NodeChecky Then
                node.Checked = nodeChecked
            End If
            If nodeChecked Then
                SqlCheckStr.Append("insert m_userright_t values('" & userid & "','" & node.Name & "','" & SysMessageClass.UseId & "',getdate())")
                SqlCheckStr.Append(Environment.NewLine)
            Else
                SqlCheckStr.Append("delete from m_userright_t where userid='" & userid & "' and tkey='" & node.Name & "'")
                SqlCheckStr.Append(Environment.NewLine)
            End If
            If node.Nodes.Count > 0 Then
                ' If the current node has child nodes, call the CheckAllChildsNodes method recursively
                Me.CheckAllChildNodes(node, userid, nodeChecked, NodeChecky)
            End If
        Next node

    End Sub

#End Region

#Region "检查所有父结点"
    Private Sub CheckAllParentNodes(ByVal treeNode As TreeNode, ByVal Userid As String, ByVal NodeChecky As Boolean)

        If (treeNode Is UserTree.Nodes(0)) Then Exit Sub

        If treeNode.Parent.Checked = False Then
            If NodeChecky Then
                treeNode.Parent.Checked = True
            End If
            SqlCheckStr.Append("insert m_userright_t values('" & Userid & "','" & treeNode.Parent.Name & "','" & SysMessageClass.UseId & "',getdate())")
            SqlCheckStr.Append(Environment.NewLine)
            ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.
            treeNode = treeNode.Parent
            Me.CheckAllParentNodes(treeNode, Userid, NodeChecky)
        End If

    End Sub
#End Region

#Region "树加载"
    Private Sub Treeload()

        Dim UserTreeDt As DataTable
        Try

            UserTreeDt = DbOperateUtils.GetDataTable("select Tkey,Tparent,Ttext,TreeTag from m_LogTree_t where rightid='mes00' order by Tparent,OrderBy")
            'TreeClass.PubConnection.Close()
            CreateTree(UserTree, "0_", Nothing, UserTreeDt, SysMessageClass.Language)
            ''CreateTree(TreeViewShow, "0_", Nothing, UserTreeDt, SysMessageClass.Language)
            UserTreeDt = Nothing

        Catch ex As Exception
            Throw ex
        End Try
        If Not UserTree Is Nothing Then
            If UserTree.Nodes.Count > 0 Then
                UserTree.Nodes(0).Expand()
            End If
        End If

    End Sub
#End Region

#Region "检查"
    Private Sub CheckSet(ByVal UserNode As TreeNode, ByVal NodeString As String)

        Dim node As TreeNode
        For Each node In UserNode.Nodes

            If node.Name = NodeString Then
                node.Checked = True
            End If

            If node.Nodes.Count > 0 Then
                'If the current node has child nodes, call the CheckSet method recursively.
                Me.CheckSet(node, NodeString)
            End If
        Next node
    End Sub

    Private Sub CheckData(ByVal UserIDstring As String)

        Dim Drcheck As DataTable

        Try
            Drcheck = DbOperateUtils.GetDataTable("select tkey from m_userright_t where userid='" & UserIDstring & "' order by tkey")
            If Drcheck.Rows.Count > 0 Then
                UserTree.Nodes(0).Checked = True
                ClearAllCheck(UserTree.Nodes(0))
                'While Drcheck.Read()
                '    CheckSet(UserTree.Nodes(0), Drcheck.GetString(0))
                'End While
                For Each DataRow As DataRow In Drcheck.Rows
                    CheckSet(UserTree.Nodes(0), DataRow(0))
                Next

            Else
                UserTree.Nodes(0).Checked = False
                ClearAllCheck(UserTree.Nodes(0))
            End If
            'TreeClass.PubConnection.Close()
        Catch ex As Exception

            Throw ex

        End Try
        'Drcheck.Close()
    End Sub

    Private Sub ClearAllCheck(ByVal UserNode As TreeNode)

        Dim node As TreeNode
        For Each node In UserNode.Nodes
            node.Checked = False
            If node.Nodes.Count > 0 Then
                'If the current node has child nodes, call the CheckSet method recursively.
                Me.ClearAllCheck(node)
            End If
        Next node

    End Sub
#End Region

    Private Sub TxtUserID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUserID.LostFocus

        If AutoCheck = True Then Exit Sub
        If Me.TxtUserID.Text = "" Then Exit Sub

        Randomize()
        StrPassword = Int(Rnd() * 10) & (Int(Rnd() * 10)) & (Int(Rnd() * 10)) & (Int(Rnd() * 10)) & (Int(Rnd() * 10)) & Int(Rnd() * 10)
        Me.TxtAutoId.Text = Me.TxtUserID.Text & Int(Rnd() * 10) & (Int(Rnd() * 10)) & (Int(Rnd() * 10)) & (Int(Rnd() * 10)) & (Int(Rnd() * 10))


    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'modify by song
        '2016-03-10
        '将SelectedIndex由1改为2,同时增加了SelectedIndex=1的代码
        If TabControl1.SelectedIndex = 1 Then
            If Me.UserinfDg.RowCount < 1 Then Exit Sub
            '取消没必要每次都重新创建树菜单 by hs ke
            'UserTree.Nodes.Clear()
            'Treeload()
            '取消没必要每次都重新创建树菜单 by hs ke
            CheckData(Me.UserinfDg.CurrentRow.Cells(0).Value)
            UserContrast = Me.UserinfDg.CurrentRow.Cells(0).Value
            GpUserRight.Text = Me.UserinfDg.CurrentRow.Cells(1).Value.ToString & "  权限设置"
            Me.UserTree.Focus()
            Me.UserTree.SelectedNode = Me.UserTree.Nodes(0)
            ' RightUser(Me.UserTree.Nodes(0).Name)

            '关晓艳 add 填充用户权限管理填充二级菜单  1028-04-24
            Dim secondSQL As String = "select Tkey,Tparent,Ttext,TreeTag,rightid from m_LogTree_t where Tparent ='m0_'  and rightid='mes00' order by Tparent,OrderBy"
            LoadDataToCob(secondSQL, cboSecond)

            '关晓艳 add 隐藏掉面板角色管理后 改变面板index
        ElseIf TabControl1.SelectedIndex = 2 Then
            'ElseIf TabControl1.SelectedIndex = 1 Then
            'add by song
            '2016-03-09
            '装载角色数据
            RoleData("1=1")

            TreeView_Role.Enabled = False

            Treeload_Role(TreeView_Role)
            UpdateRoleText()
            CheckData_RoleSet(TextBox_RoleId.Text.Trim())
        Else
            Me.ToolBt.Enabled = True
        End If
    End Sub

    Private Sub UserTree_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles UserTree.AfterSelect
        'If VbCommClass.VbCommClass.Factory = "BZLANTO" Then
        '    RightUser(Me.UserTree.SelectedNode.Name)
        'End If
        RightUser(Me.UserTree.SelectedNode.Name)
    End Sub

    Private Sub RightUser(ByVal Nodekey As String)
        Dim DtRight As DataTable
        Dim K As Integer
        'Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        DtRight = DbOperateUtils.GetDataTable("Select 'true' ChooseY,a.userid,a.username,a.dept,b.djc,a.jobs,a.team,a.groupid,a.factoryid,a.autoid,a.descript,case when a.Usey='1' then 'Yes' else 'No' end from m_users_t a left join m_Dept_t b on a.dept=b.deptid where userid in (select distinct userid from m_UserRight_t where tkey='" & Nodekey & "')")
        DGriduser.Rows.Clear()
        DGriduser.ScrollBars = ScrollBars.None
        For K = 0 To DtRight.Rows.Count - 1
            DGriduser.Rows.Add(DtRight.Rows(K)("ChooseY"), DtRight.Rows(K)("userid"), DtRight.Rows(K)("username"), DtRight.Rows(K)("dept"), DtRight.Rows(K)("djc"), DtRight.Rows(K)("jobs"), DtRight.Rows(K)("team"), DtRight.Rows(K)("groupid"), DtRight.Rows(K)("factoryid"), DtRight.Rows(K)("autoid"), DtRight.Rows(K)("descript"), DtRight.Rows(K)(11))
        Next
        'Sdbc.PubConnection.Close()
        DGriduser.ScrollBars = ScrollBars.Both
        DtRight = Nothing
        DGriduser.AutoResizeColumns()
        DGriduser.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub TxtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged
        Me.UserinfDg.DataSource = Nothing
    End Sub

    Private Sub CobDeptSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CobDeptSearch.SelectedIndexChanged
        Me.UserinfDg.DataSource = Nothing
    End Sub

    Private Sub BtnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuery.Click
        If Me.TxtSearch.Text = "" AndAlso TxtUnSearch.Text = "" AndAlso Me.CobDeptSearch.Text = "ALL" Then Exit Sub
        Dim tableview As New DataView(UserDg)
        Dim ChColsText As String
        Dim RowFilterStr As String = ""
        If Me.TxtSearch.Text <> "" Then
            RowFilterStr = " userid like '" & Trim(Me.TxtSearch.Text) & "%'"
        End If
        If Me.TxtUnSearch.Text <> "" Then
            If Len(RowFilterStr) > 0 Then
                RowFilterStr = RowFilterStr + " and username like '" & Trim(Me.TxtUnSearch.Text) & "%'"
            Else
                RowFilterStr = " username like '" & Trim(Me.TxtUnSearch.Text) & "%'"
            End If
        End If
        If Me.CobDeptSearch.Text <> "ALL" Then
            If Len(RowFilterStr) > 0 Then
                RowFilterStr = RowFilterStr + " and dept='" & Mid(Trim(Me.CobDeptSearch.Text), 1, InStr(Trim(Me.CobDeptSearch.Text), "(") - 1) & "'"
            Else
                RowFilterStr = " dept='" & Mid(Trim(Me.CobDeptSearch.Text), 1, InStr(Trim(Me.CobDeptSearch.Text), "(") - 1) & "'"
            End If
        End If
        tableview.RowFilter = RowFilterStr
        If tableview.Count > 0 Then
            Me.UserinfDg.DataSource = Nothing
            Me.UserinfDg.DataSource = tableview

            'If LCase(SysMessageClass.Language) = "english" Then
            'ChColsText = "用户ID|用户名|部门编号|部门名称|职称|部门组别|群组|营运中心|自动编码|描述|有效否|验证方式"
            ChColsText = "用户ID|用户名|部门编号|部门名称|职称|部门组别|群组|营运中心|自动编码|描述|有效否|验证方式|用户级别|是否厂外员工"

            Dim colNames As String() = ChColsText.Split("|")
            Dim i%
            For i = 0 To UserinfDg.Columns.Count - 1
                UserinfDg.Columns(i).HeaderText = colNames(i)
                UserinfDg.Columns(i).Name = colNames(i)
            Next
            SetValueToControl()
            CheckData(Me.UserinfDg.CurrentRow.Cells(0).Value)
            'RightUser(Me.UserTree.Nodes(0).Name)
        End If
    End Sub

    Private Sub CobDeptShow_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobDeptShow.SelectedIndexChanged
        If Me.CobDeptShow.Text = "ALL" Then
            FillCobUser(CobUseShow, "select userid from m_Users_t where  userid<>'" & UserContrast & "'")
        Else
            FillCobUser(CobUseShow, "select userid from m_Users_t where dept='" & Mid(Trim(Me.CobDeptShow.Text), 1, InStr(Trim(Me.CobDeptShow.Text), "(") - 1) & "' and usey = 1 and userid<>'" & UserContrast & "'")
        End If

    End Sub

    Private Sub CobUseShow_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CobUseShow.LostFocus
        If Me.CobUseShow.Text = "" Then Exit Sub
        ShowCtsUserRight()
    End Sub

    Private Sub CobUseShow_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobUseShow.SelectedIndexChanged
        If Me.CobUseShow.Text = "" Then Exit Sub
        ShowCtsUserRight()
    End Sub
    Private Sub ShowCtsUserRight()
        Dim DrUserShow As DataTable = Nothing
        Dim DtrightShow As DataTable
        'Dim Sdbc As New SysDataBaseClass
        Dim userid As String
        Try
            DrUserShow = DbOperateUtils.GetDataTable("select * from m_Users_t where userid ='" & Trim(Me.CobUseShow.Text) & "' and userid<>'" & UserContrast & "'")
            If DrUserShow.Rows.Count > 0 Then
                userid = DrUserShow.Rows(0)("userid").ToString
                TxtNameShow.Text = DrUserShow.Rows(0)("username").ToString
                Me.TxtRemark.Text = DrUserShow.Rows(0)("Groupid").ToString
                TxtJob.Text = DrUserShow.Rows(0)("jobs").ToString
                '' GroupBox1.Text = TxtNameShow.Text & "   舦陪ボ"

                'DrUserShow.Close()
                'Sdbc.PubConnection.Close()
                DtrightShow = DbOperateUtils.GetDataTable("select b.* from m_userright_t a join m_LogTree_t b on a.tkey=b.tkey where  a.userid='" & Trim(userid) & "' order by b.treeid")

                ''  TreeViewShow.Nodes.RemoveAt(0)
                'CreateTree(TreeViewShow, "0_", Nothing, DtrightShow, SysMessageClass.Language)
                DtrightShow = Nothing
                'TreeViewShow.ExpandAll()
                'Me.TreeViewShow.Focus()
                'Me.TreeViewShow.SelectedNode = Me.UserTree.Nodes(0)
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            'DrUserShow.Close()
            DtrightShow = Nothing
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Btcontrast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btcontrast.Click

        'Dim Sdbc As New SysDataBaseClass
        Dim Dr As DataTable
        Dim StrSql As String
        Try
            If Me.CobUseShow.Text = "" Then
                MessageBox.Show("用户名不能为空..", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MessageBox.Show(String.Format(MultLanguage.MultMessage.GetMsg("M000079"), Label3.Text.Trim(":")), MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf Me.CobUseShow.Text = UserinfDg.CurrentRow.Cells(0).Value Then
                MessageBox.Show("比对帐号不能与当前设置帐号相同", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MessageBox.Show(MultLanguage.MultMessage.GetMsg("M000519"), MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dr = DbOperateUtils.GetDataTable("select 1 from m_Users_t where userid='" & Trim(Me.CobUseShow.Text) & "'")
            If Dr.Rows.Count = 0 Then
                MessageBox.Show("该用户帐号不存在...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MessageBox.Show(MultLanguage.MultMessage.GetMsg("M000517"), MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Dr.Close()
            'Sdbc.PubConnection.Close()
            StrSql = "delete from m_userright_t where userid='" & Trim(TxtUserID.Text) & "'" & vbNewLine
            StrSql = StrSql + "insert into m_userright_t select '" & Trim(TxtUserID.Text) & "',tkey,'" & SysMessageClass.UseId & "',getdate() from m_userright_t where userid='" & Trim(Me.CobUseShow.Text) & "'"
            DbOperateUtils.ExecSQL(StrSql)
            CheckData(Me.UserinfDg.CurrentRow.Cells(0).Value)
            ''DtrightShow = TreeClass.GetDataTable("select b.* from m_userright_t a join m_LogTree_t b on a.tkey=b.tkey where  b.listy='Y'and a.userid='" & Trim(TxtUserID.Text) & "' order by b.treeid")

            ''TreeViewShow.Nodes.RemoveAt(0)
            ''CreateTree(TreeViewShow, "0_", Nothing, DtrightShow, SysMessageClass.Language)
            ''DtrightShow = Nothing
            ''TreeViewShow.ExpandAll()
            ''Me.TreeViewShow.Focus()
            ''Me.TreeViewShow.SelectedNode = Me.UserTree.Nodes(0)

        Catch ex As Exception
            'MessageBox.Show(ex.Message, MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub DGriduser_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGriduser.CellContentClick
        If e.ColumnIndex <> 0 Then Exit Sub
        'Dim Pubclass As New SysDataBaseClass
        Me.DGriduser.EndEdit()
        Try
            RightAddorDel(Me.UserTree.SelectedNode.Name, Me.UserTree.SelectedNode, Me.DGriduser.CurrentRow.Cells(1).Value, Me.UserTree.SelectedNode.Nodes.Count, Me.DGriduser.CurrentRow.Cells(0).Value, False)
        Catch ex As Exception
            'MessageBox.Show(ex.Message, MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ToolSuperPwd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSuperPwd.Click
        Dim newMDIChild As Form
        Try
            'BasicManagement.
            Dim SpaceNameStr As String = "MESUserManage.FrmSuperPwd"
            Dim FormSpaceString As String = "MESUserManage"
            newMDIChild = CType(Activator.CreateInstance(Type.GetType(SpaceNameStr & "," & FormSpaceString)), Form) ''客戶端呼叫實例
        Catch ex As Exception
            'MessageBox.Show(ex.Message, MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        'newMDIChild.MdiParent = Me
        newMDIChild.ShowDialog()
    End Sub

    Private Sub btnSetFinger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetFinger.Click
        If Me.UserinfDg.Rows.Count < 1 Then Exit Sub
        If TxtUserID.Text <> "" Then
            'If CheckDLLExists() Then
            '    Try
            '        Dim frm As FrmRegFinger = New FrmRegFinger(TxtUserID.Text)
            '        frm.ShowDialog()
            '    Catch ex As Exception
            '        'MessageBox.Show("启动指纹仪异常,请正确安装指纹仪驱动")
            '        MessageBox.Show(MultLanguage.MultMessage.GetMsg("M000368"))
            '        Exit Sub
            '    End Try

            'Else
            '    MessageBox.Show(MultLanguage.MultMessage.GetMsg("M000368"))
            '    'MessageBox.Show("检测到没有安装指纹仪驱动,请安装指纹仪驱动")
            '    Exit Sub
            'End If
        End If

    End Sub
    <DllImport("DPFPApi.dll", CharSet:=CharSet.Auto)> _
    Friend Shared Function DPFPInit() As Integer
    End Function
    Private Shared Function CheckDLLExists() As Boolean
        Try
            DPFPInit()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        'add by song
        '发送消息刷新主窗口
        ' SendMessage(Hwnd, &HF, 100, 100)
    End Sub

    Private Sub UserTree_Leave(sender As Object, e As EventArgs) Handles UserTree.Leave
        'add by song
        '发送消息刷新主窗口
        '      SendMessage(Hwnd, &HF, 100, 100)
    End Sub

#Region "装载模块树"
    'add by song
    '装载模块树
    Private Sub Treeload_Role(ByVal treeview As TreeView)

        Dim UserTreeDt As DataTable
        'Me.ModuleTree.Nodes.Clear()
        treeview.Nodes.Clear()
        'Dim systemTreeDt As DataTable

        Try
            UserTreeDt = DbOperateUtils.GetDataTable("select * from m_LogTree_t where rightid='mes00' order by treeid")
            'TreeClass.PubConnection.Close()
            CreateTree(treeview, "0_", Nothing, UserTreeDt, SysMessageClass.Language)
            UserTreeDt = Nothing

        Catch ex As Exception
            Throw ex
        End Try

        'Me.ModuleTree.Nodes(0).Expand()
        If Not treeview Is Nothing Then
            If treeview.Nodes.Count > 0 Then
                treeview.Nodes(0).Expand()
            End If
        End If

        '' TreeViewShow.ExpandAll()
        'Me.SysTree.ExpandAll()

    End Sub
#End Region

    'add by song
    '2016-03-09
    '设置按钮状态与事件
    Private Sub ToolStrip1_ItemClicked_1(sender As Object, e As ToolStripItemClickedEventArgs) Handles RoleBt.ItemClicked
        NewRole.Enabled = True
        EditRole.Enabled = True
        DeleteRole.Enabled = True
        SaveRole.Enabled = False
        StopRole.Enabled = False
        ExitRole.Enabled = True
        Select Case e.ClickedItem.Name
            Case "NewRole"
                TreeView_Role.Enabled = True
                Treeload_Role(TreeView_Role)
                TextBox_RoleName.Enabled = True
                TextBox_RoleDesc.Enabled = True
                CheckBox_Status.Enabled = True
                TextBox_RoleId.Text = ""
                TextBox_RoleName.Text = ""
                TextBox_RoleDesc.Text = ""
                TextBox_RoleName.Focus()
                DataGridView_Role.Enabled = False
                NewRole.Enabled = False
                EditRole.Enabled = False
                DeleteRole.Enabled = False
                SaveRole.Enabled = True
                StopRole.Enabled = False
                BackRole.Enabled = True
                SearchRole.Enabled = False
                ExitRole.Enabled = True
                CheckData_RoleSet(TextBox_RoleId.Text.Trim())
            Case "EditRole"
                TreeView_Role.Enabled = True
                Treeload_Role(TreeView_Role)
                TextBox_RoleName.Enabled = True
                TextBox_RoleDesc.Enabled = True
                CheckBox_Status.Enabled = True
                TextBox_RoleName.Focus()
                DataGridView_Role.Enabled = True
                NewRole.Enabled = False
                EditRole.Enabled = False
                DeleteRole.Enabled = False
                SaveRole.Enabled = True
                StopRole.Enabled = False
                BackRole.Enabled = True
                SearchRole.Enabled = False
                ExitRole.Enabled = True
                UpdateRoleText()
                CheckData_RoleSet(TextBox_RoleId.Text.Trim())
            Case "SaveRole"
                TextBox_RoleName.Enabled = False
                TextBox_RoleDesc.Enabled = False
                CheckBox_Status.Enabled = False
                TextBox_RoleName.Focus()
                DataGridView_Role.Enabled = True
                NewRole.Enabled = True
                EditRole.Enabled = True
                DeleteRole.Enabled = True
                SaveRole.Enabled = False
                StopRole.Enabled = True
                BackRole.Enabled = False
                SearchRole.Enabled = True
                ExitRole.Enabled = True
                RoleAddOrModify(TextBox_RoleId.Text.Trim(), TextBox_RoleName.Text.Trim(), TextBox_RoleDesc.Text.Trim(), CheckBox_Status.Checked.ToString())
                If DataGridView_Role.RowCount > 0 Then
                    DeleteUserRoleRight(Me.DataGridView_Role.Item(0, DataGridView_Role.CurrentRow.Index).Value.ToString())
                End If
                SaveRoleRight(TreeView_Role.Nodes)
                SaveUserRight()
                RoleData("1=1")
            Case "ExitRole"
                Me.Close()
            Case "DeleteRole"
                'If (MessageBox.Show(MultLanguage.MultMessage.GetMsg("M000002"), MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK) Then
                If (MessageBox.Show("您确定要删除当前角色？", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK) Then
                    TreeView_Role.Nodes.Clear()
                    TextBox_RoleName.Enabled = False
                    TextBox_RoleDesc.Enabled = False
                    CheckBox_Status.Enabled = False
                    CheckBox_Status.Checked = False
                    DataGridView_Role.Enabled = False
                    NewRole.Enabled = True
                    EditRole.Enabled = True
                    DeleteRole.Enabled = True
                    SaveRole.Enabled = False
                    StopRole.Enabled = True
                    BackRole.Enabled = False
                    SearchRole.Enabled = True
                    ExitRole.Enabled = True
                    DeleteRoleData()
                    RoleData("1=1")
                End If
            Case "StopRole"
                TreeView_Role.Nodes.Clear()
                TextBox_RoleName.Enabled = False
                TextBox_RoleDesc.Enabled = False
                CheckBox_Status.Enabled = False
                CheckBox_Status.Checked = False
                DataGridView_Role.Enabled = True
                NewRole.Enabled = True
                EditRole.Enabled = True
                DeleteRole.Enabled = True
                SaveRole.Enabled = False
                StopRole.Enabled = True
                BackRole.Enabled = False
                SearchRole.Enabled = True
                ExitRole.Enabled = True
                StopRoleData()
                RoleData("1=1")
            Case Else
                TreeView_Role.Nodes.Clear()
                TextBox_RoleName.Enabled = False
                TextBox_RoleDesc.Enabled = False
                CheckBox_Status.Enabled = False
                CheckBox_Status.Checked = False
                DataGridView_Role.Enabled = True
                NewRole.Enabled = True
                EditRole.Enabled = True
                DeleteRole.Enabled = True
                SaveRole.Enabled = False
                StopRole.Enabled = True
                BackRole.Enabled = False
                SearchRole.Enabled = True
                ExitRole.Enabled = True
        End Select
    End Sub

    'add by song
    '2016-03-10
    '绑定角色数据到DataGridView
    Private Sub RoleData(ByVal Condition As String)
        Dim DtRole As DataTable
        Dim K As Integer
        'Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        DtRole = DbOperateUtils.GetDataTable("Select * from m_Role_t where " & Condition & "")
        DataGridView_Role.Rows.Clear()
        DataGridView_Role.ScrollBars = ScrollBars.None
        For K = 0 To DtRole.Rows.Count - 1
            DataGridView_Role.Rows.Add(DtRole.Rows(K)("Role_Id"), DtRole.Rows(K)("Role_Name"), DtRole.Rows(K)("Role_Desc"), DtRole.Rows(K)("Role_Acitve"))
        Next
        'Sdbc.PubConnection.Close()
        DataGridView_Role.ScrollBars = ScrollBars.Both
        DtRole = Nothing
    End Sub

    'add by song
    '2016-03-10
    '新增或修改角色
    Private Sub RoleAddOrModify(ByVal Role_Id As String, ByVal Role_Name As String, ByVal Role_Desc As String, ByVal Role_Active As Boolean)
        SqlCheckStr = New StringBuilder
        Dim Active As String
        Dim TempStr As String
        If Role_Active = True Then
            Active = "1"
        Else
            Active = "0"
        End If

        If Role_Id = "" Then
            TempStr = GetRole_Id()
            SqlCheckStr.Append("insert m_Role_t values('" & TempStr & "',N'" & Role_Name & "',N'" & Role_Desc & "','" & Active & "','" & SysMessageClass.UseId & "',getdate())")
            SqlCheckStr.Append(Environment.NewLine)
            DbOperateUtils.ExecSQL(SqlCheckStr.ToString)
            'TreeClass.PubConnection.Close()
        Else
            SqlCheckStr.Append("update m_Role_t set Role_Name=N'" & TextBox_RoleName.Text.Trim() & "',Role_Desc=N'" & TextBox_RoleDesc.Text.Trim() & "',Role_Acitve='" & Active & "' where Role_Id='" & TextBox_RoleId.Text.Trim() & "'")
            SqlCheckStr.Append(Environment.NewLine)
            DbOperateUtils.ExecSQL(SqlCheckStr.ToString)
            'TreeClass.PubConnection.Close()
        End If
    End Sub

    'add by song
    '2016-03-10
    '获取最新Role_Id
    Private Function GetRole_Id() As String
        Dim DtRole As DataTable
        Dim Role_Id As String = "R001"
        Dim TempStr As String = Nothing
        'Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        DtRole = DbOperateUtils.GetDataTable("select right(max(Role_Id),3)+1 from m_Role_t(nolock)")

        If DtRole.Rows.Count > 0 Then
            TempStr = DtRole.Rows(0)(0).ToString()
        End If

        If TempStr <> Nothing Then
            If TempStr.Length = 1 Then
                TempStr = "R00" + TempStr
            ElseIf TempStr.Length = 2 Then
                TempStr = "R0" + TempStr
            ElseIf TempStr.Length = 3 Then
                TempStr = "R" + TempStr
            End If
        End If
        'Sdbc.PubConnection.Close()
        DtRole = Nothing

        If TempStr <> Nothing Then
            Role_Id = TempStr
        End If

        Return Role_Id
    End Function

    'add by song
    '2016-03-10
    '将当前角色信息显示到文本框
    Private Sub DataGridView_Role_Click(sender As Object, e As EventArgs) Handles DataGridView_Role.Click
        TreeView_Role.Enabled = False
        Treeload_Role(TreeView_Role)
        UpdateRoleText()
        CheckData_RoleSet(TextBox_RoleId.Text.Trim())
    End Sub

    'add by song
    '2016-03-11
    '将当前角色信息显示到文本框
    Private Sub UpdateRoleText()
        If Me.DataGridView_Role.CurrentRow Is Nothing Then
            Exit Sub
        End If

        TextBox_RoleId.Text = Me.DataGridView_Role.Item(0, DataGridView_Role.CurrentRow.Index).Value.ToString
        TextBox_RoleName.Text = Me.DataGridView_Role.Item(1, DataGridView_Role.CurrentRow.Index).Value.ToString
        TextBox_RoleDesc.Text = Me.DataGridView_Role.Item(2, DataGridView_Role.CurrentRow.Index).Value.ToString
        If Me.DataGridView_Role.Item(3, DataGridView_Role.CurrentRow.Index).Value.ToString = 1 Then
            CheckBox_Status.Checked = True
        Else
            CheckBox_Status.Checked = False
        End If
    End Sub

    'add by song
    '2016-03-11
    '删除角色数据
    Private Sub DeleteRoleData()
        'Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            'DbOperateUtils.ExecSQL("delete from m_UserRight_t where Tkey in(select u.Tkey from m_UserRight_t u,m_RoleUser_T r,m_RoleRight_t t where u.UserID = r.User_Id and r.Role_Id = t.Role_Id and u.Tkey = t.TKey and r.Role_Id = '" & Me.TextBox_RoleId.Text & "' and u.UserID+u.Tkey not in (select u1.UserID+u1.Tkey from m_UserRight_t u1,m_RoleUser_T r1,m_RoleRight_t t1 where u1.UserID = r1.User_Id and r1.Role_Id = t1.Role_Id and u1.Tkey = t1.TKey and r1.Role_Id <> '" & Me.TextBox_RoleId.Text & "'))")
            'DbOperateUtils.ExecSQL("delete from m_RoleRight_t where Role_Id='" & Me.TextBox_RoleId.Text & "'")
            'DbOperateUtils.ExecSQL("delete from m_RoleUser_t where Role_Id='" & Me.TextBox_RoleId.Text & "'")
            'DbOperateUtils.ExecSQL("delete from m_Role_t where Role_Id='" & Me.TextBox_RoleId.Text & "'")
            Dim strSQL As String = "delete from m_UserRight_t where Tkey in(select u.Tkey from m_UserRight_t u,m_RoleUser_T r,m_RoleRight_t t where u.UserID = r.User_Id and r.Role_Id = t.Role_Id and u.Tkey = t.TKey and r.Role_Id = '" & Me.TextBox_RoleId.Text & "' and u.UserID+u.Tkey not in (select u1.UserID+u1.Tkey from m_UserRight_t u1,m_RoleUser_T r1,m_RoleRight_t t1 where u1.UserID = r1.User_Id and r1.Role_Id = t1.Role_Id and u1.Tkey = t1.TKey and r1.Role_Id <> '" & Me.TextBox_RoleId.Text & "'))"
            strSQL = strSQL & "delete from m_RoleRight_t where Role_Id='" & Me.TextBox_RoleId.Text & "'"
            strSQL = strSQL & "delete from m_RoleUser_t where Role_Id='" & Me.TextBox_RoleId.Text & "'"
            strSQL = strSQL & "delete from m_Role_t where Role_Id='" & Me.TextBox_RoleId.Text & "'"
            DbOperateUtils.ExecSQL(strSQL)

            'Sdbc.PubConnection.Close()
        Catch ex As Exception
            'MessageBox.Show(ex.Message, MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            MessageBox.Show(ex.Message & vbCrLf & "删除角色时，发生错误...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        'Sdbc = Nothing
    End Sub

    'add by song
    '2016-03-11
    '作废角色数据
    Private Sub StopRoleData()
        'Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            'Sdbc.PubConnection.Close()
            DbOperateUtils.ExecSQL("update m_Role_t set Role_Acitve=0 where Role_Id='" & Me.TextBox_RoleId.Text & "'")
            'MessageBox.Show(MultLanguage.MultMessage.GetMsg("M000096"), MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            MessageBox.Show("该角色已做废！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            'MessageBox.Show(ex.Message, MultLanguage.MultMessage.GetMsg("M000063"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            MessageBox.Show(ex.Message & vbCrLf & "作废角色时，发生错误...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        'Sdbc = Nothing
    End Sub

    'add by song
    '2016-03-11
    '确认显示角色的可访问权限
    Private Sub CheckData_RoleSet(ByVal RoleIDstring As String)
        Dim Drcheck As DataTable
        Try
            If SaveRole.Enabled = False Then
                'Exit Sub
            End If
            Drcheck = DbOperateUtils.GetDataTable("select tkey from m_RoleRight_t where Role_Id='" & RoleIDstring & "' order by tkey")
            If Drcheck.Rows.Count > 0 Then
                TreeView_Role.Nodes(0).Checked = True
                ClearAllCheck(TreeView_Role.Nodes(0))
                For Each DataRow As DataRow In Drcheck.Rows
                    CheckSet(TreeView_Role.Nodes(0), DataRow(0))
                Next
                'While Drcheck.Read()
                '    CheckSet(TreeView_Role.Nodes(0), Drcheck.GetString(0))
                'End While
            Else
                TreeView_Role.Nodes(0).Checked = False
                ClearAllCheck(TreeView_Role.Nodes(0))
            End If
            'TreeClass.PubConnection.Close()
        Catch ex As Exception
            Throw ex
        End Try
        'Drcheck.Close()
    End Sub

    'add by song
    '2016-03-11
    '存盘Role权限
    Private Sub SaveRoleRight(ByVal tc As TreeNodeCollection)
        Try
            Dim t As TreeNode
            'Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
            For Each t In tc
                If t.Checked = True Then
                    AddUserRoleRight(Me.DataGridView_Role.Item(0, DataGridView_Role.CurrentRow.Index).Value.ToString(), t.Name)
                End If
                If t.Nodes.Count > 0 Then SaveRoleRight(t.Nodes)
            Next
            'Sdbc.PubConnection.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'add by song
    '2016-03-11
    '存盘UserRight权限
    Private Sub SaveUserRight()
        Try
            'Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
            'DbOperateUtils.ExecSQL("delete from m_UserRight_t where UserID+Tkey in (select UserID+Tkey from m_UserRight_t r,m_RoleUser_t u where r.UserID=u.User_Id and u.Role_Id = '" & Me.TextBox_RoleId.Text & "' and UserID+Tkey not in (select u.User_Id+r.Tkey from m_RoleUser_t u,m_RoleRight_t r where u.Role_Id=r.Role_Id and u.Role_Id='" & Me.TextBox_RoleId.Text & "'))")
            'DbOperateUtils.ExecSQL("insert into m_UserRight_t select u.User_Id,r.Tkey,'" & SysMessageClass.UseId & "',getdate() from m_RoleUser_t u,m_RoleRight_t r where u.Role_Id=r.Role_Id and u.Role_Id='" & Me.TextBox_RoleId.Text & "' and  u.User_Id+r.Tkey not in (select r.UserID+r.Tkey from m_UserRight_t r,m_RoleUser_t u where r.UserID=u.User_Id and u.Role_Id = '" & Me.TextBox_RoleId.Text & "')")
            Dim strSQL As String = "delete from m_UserRight_t where UserID+Tkey in (select UserID+Tkey from m_UserRight_t r,m_RoleUser_t u where r.UserID=u.User_Id and u.Role_Id = '" & Me.TextBox_RoleId.Text & "' and UserID+Tkey not in (select u.User_Id+r.Tkey from m_RoleUser_t u,m_RoleRight_t r where u.Role_Id=r.Role_Id and u.Role_Id='" & Me.TextBox_RoleId.Text & "'))"
            strSQL = strSQL & "insert into m_UserRight_t select u.User_Id,r.Tkey,'" & SysMessageClass.UseId & "',getdate() from m_RoleUser_t u,m_RoleRight_t r where u.Role_Id=r.Role_Id and u.Role_Id='" & Me.TextBox_RoleId.Text & "' and  u.User_Id+r.Tkey not in (select r.UserID+r.Tkey from m_UserRight_t r,m_RoleUser_t u where r.UserID=u.User_Id and u.Role_Id = '" & Me.TextBox_RoleId.Text & "')"

            DbOperateUtils.ExecSQL(strSQL)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'add by song
    '2016-03-11
    '删除角色可访问模块
    Private Sub DeleteUserRoleRight(ByVal Role_Id As String)
        SqlCheckStr = New StringBuilder
        Try
            SqlCheckStr.Append("delete from m_RoleRight_t where Role_Id='" & Role_Id & "'")
            SqlCheckStr.Append(Environment.NewLine)
            DbOperateUtils.ExecSQL(SqlCheckStr.ToString)
            'TreeClass.PubConnection.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'add by song
    '2016-03-11
    '添加角色可访问模块
    Private Sub AddUserRoleRight(ByVal Role_Id As String, ByVal Tkey As String)
        SqlCheckStr = New StringBuilder
        Try
            SqlCheckStr.Append("insert m_RoleRight_t values('" & Role_Id & "','" & Tkey & "','" & SysMessageClass.UseId & "',getdate())")
            SqlCheckStr.Append(Environment.NewLine)
            DbOperateUtils.ExecSQL(SqlCheckStr.ToString)
            'TreeClass.PubConnection.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'add by song
    '2016-03-18
    '确定父节点是否选取了Checked
    Private Sub CheckRoleParentNodes(ByVal treeNode As TreeNode, ByVal NodeChecky As Boolean)
        If (treeNode Is TreeView_Role.Nodes(0)) Then Exit Sub

        If treeNode.Parent.Checked = False Then
            If NodeChecky Then
                treeNode.Parent.Checked = True
            End If
        End If
        treeNode = treeNode.Parent
        Me.CheckRoleParentNodes(treeNode, NodeChecky)
    End Sub

    'add by song
    '2016-03-18
    '确定子节点是否选取了Checked
    Private Sub CheckRoleChildNodes(ByVal treeNode As TreeNode, ByVal NodeChecky As Boolean)
        Dim node As TreeNode
        For Each node In treeNode.Nodes
            node.Checked = NodeChecky

            If node.Nodes.Count > 0 Then
                Me.CheckRoleChildNodes(node, node.Checked)
            End If
        Next node
    End Sub

    Private Sub TreeView_Role_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView_Role.AfterCheck
        If e.Action <> TreeViewAction.Unknown Then
            Me.UserTree.BeginUpdate()
            Try
                Me.CheckRoleChildNodes(e.Node, e.Node.Checked)
                Me.CheckRoleParentNodes(e.Node, e.Node.Checked)
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

    Private Sub SearchRole_Click(sender As Object, e As EventArgs) Handles SearchRole.Click
        If Panel3.Visible = False Then
            Panel3.Visible = True
            TreeView_Role.Height = TreeView_Role.Height - 50
            TextBox_RoleId_S.Clear()
            TextBox_RoleName_S.Clear()
            TextBox_RoleId_S.Focus()
        Else
            Panel3.Visible = False
            TreeView_Role.Height = TreeView_Role.Height + 50
        End If
    End Sub

    Private Sub Button_Role_S_Click(sender As Object, e As EventArgs) Handles Button_Role_S.Click
        Dim SqlStr1, SqlStr2, SqlStr As String

        Panel3.Visible = False
        TreeView_Role.Height = TreeView_Role.Height + 50
        If TextBox_RoleId_S.Text <> "" Then
            SqlStr1 = " Role_Id like '%" & TextBox_RoleId_S.Text.Trim() & "%'"
        End If
        If TextBox_RoleName_S.Text <> "" Then
            SqlStr2 = " Role_Name like N'%" & TextBox_RoleName_S.Text.Trim() & "%'"
        End If

        If SqlStr2 <> "" Then
            SqlStr = SqlStr1 & "and" & SqlStr2
        Else
            SqlStr = SqlStr1
        End If

        If SqlStr = "" Then
            SqlStr = "1=1"
        End If
        RoleData(SqlStr)

        TreeView_Role.Enabled = False
        Treeload_Role(TreeView_Role)
        UpdateRoleText()
        CheckData_RoleSet(TextBox_RoleId.Text.Trim())
    End Sub


#Region "填充文本框"
    ''' <summary>
    ''' 填充文本框 
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <param name="cboName"></param>
    ''' <remarks>关晓艳 add 2018-04-24</remarks>
    Private Sub LoadDataToCob(ByVal strSQL As String, ByVal cboName As ComboBox)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        cboName.Items.Clear()
        For index As Integer = 0 To dt.Rows.Count - 1
            cboName.Items.Add(dt.Rows(index)("Ttext").ToString)
        Next
        cboName.Items.Insert(0, "")
    End Sub
#End Region
#Region "二级菜单改变事件"
    ''' <summary>
    ''' 二级菜单改变 三级菜单也改变
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>关晓艳 add 2018-04-24</remarks>
    Private Sub cboSecond_TextChanged(sender As Object, e As EventArgs) Handles cboSecond.TextChanged
        Dim thirdSQL As String = "select Ttext from m_LogTree_t where Tparent = (select Tkey from m_LogTree_t where Tparent ='m0_' and Ttext =N'" & cboSecond.Text.Trim & "') and rightid='mes00' "
        LoadDataToCob(thirdSQL, cboThird)
    End Sub
#End Region
    Dim i As Integer   '设置选中菜单状态
#Region "查询 用户权限管理"
    ''' <summary>
    ''' 查询 用户权限管理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>关晓艳 add 2018-04-24</remarks>
    Private Sub btnSecarch_Click(sender As Object, e As EventArgs) Handles btnSecarch.Click
        Dim UserTreeDt As DataTable

        If String.IsNullOrEmpty(cboSecond.Text.Trim) And String.IsNullOrEmpty(cboThird.Text.Trim) Then
            UserTree.Nodes.Clear()
            Treeload()
            CheckData(Me.UserinfDg.CurrentRow.Cells(0).Value)
            UserTree.Nodes(0).Expand()
            i = 0
        ElseIf Not String.IsNullOrEmpty(cboThird.Text.Trim) Then
            i = 2
            Dim userSQL As String = "with temp (Tkey,Tparent,Ttext,TreeTag)  " _
             & " as( select Tkey,Tparent,Ttext,TreeTag from m_LogTree_t where Ttext like  N'%" & cboThird.Text.Trim & "%' and rightid='mes00'  union all " _
             & " select a.Tkey, a.Tparent,a.Ttext,a.TreeTag from m_LogTree_t a inner join temp on a.Tparent = temp.Tkey  where rightid='mes00') , " _
             & " c(Tkey,Tparent,Ttext,TreeTag)  as( select Tkey,Tparent,Ttext,TreeTag from m_LogTree_t where Ttext like  N'%" & cboThird.Text.Trim & "%' and rightid='mes00' " _
             & " union all select a.Tkey, a.Tparent,a.Ttext,a.TreeTag from m_LogTree_t a  inner join c on a.Tkey  = c.Tparent   where rightid='mes00') " _
             & "   select * from temp 	union  select distinct * from c "

            UserTreeDt = DbOperateUtils.GetDataTable(userSQL)
            If UserTreeDt.Rows.Count <= 0 Then
                Return
            End If
            cboSecond.Text = ""
            UserTree.Nodes.Clear()
            CreateTree(UserTree, "0_", Nothing, UserTreeDt, SysMessageClass.Language)
            'UserTree.ExpandAll()
            UserTree.Nodes(0).Expand()
            Me.UserTree.Focus()
            Me.UserTree.SelectedNode = Me.UserTree.Nodes(0)

            CheckData(Me.UserinfDg.CurrentRow.Cells(0).Value)
        ElseIf Not String.IsNullOrEmpty(cboSecond.Text.Trim) Then
            'Dim secondSQL As String = "select Tkey,Tparent,Ttext,TreeTag from m_LogTree_t where  Ttext =N'" & cboSecond.Text.Trim & "' or Tkey ='m0_'  and rightid='mes00'" _
            '                & " or Tparent =(select Tkey   from m_LogTree_t where  Ttext =N'" & cboSecond.Text.Trim & "' and rightid='mes00' and Tparent ='m0_') "
            Dim secondSQL As String = "with temp (Tkey,Tparent,Ttext,TreeTag)  as( " _
                & " select Tkey,Tparent,Ttext,TreeTag from m_LogTree_t where Ttext= N'" & cboSecond.Text.Trim & "' and rightid='mes00' " _
                & " union all " _
                & " select a.Tkey, a.Tparent,a.Ttext,a.TreeTag from m_LogTree_t a inner join temp on a.Tparent = temp.Tkey  where rightid='mes00') " _
                & " select * from temp union all " _
                & " select Tkey,Tparent,Ttext,TreeTag from m_LogTree_t where Tkey = 'm0_' "

            i = 1
            UserTreeDt = DbOperateUtils.GetDataTable(secondSQL)

            If UserTreeDt.Rows.Count <= 0 Then
                Return
            End If
            UserTree.Nodes.Clear()
            CreateTree(UserTree, "0_", Nothing, UserTreeDt, SysMessageClass.Language)
            ' UserTree.ExpandAll()
            UserTree.Nodes(0).Expand()
            Me.UserTree.Focus()
            Me.UserTree.SelectedNode = Me.UserTree.Nodes(0)
            CheckData(Me.UserinfDg.CurrentRow.Cells(0).Value)
        End If
    End Sub
#End Region
#Region "回车事件"
    Private Sub TxtUserID_TxtUserID_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TxtUserID.PreviewKeyDown
        If e.KeyValue = 13 Then
            Select_ZSHR_YGJBXX()
        End If
    End Sub
#End Region

    Private Sub Select_ZSHR_YGJBXX()
        Dim strsql As String = String.Format("select * from dcsdb.dbo.ZSHR_YGJBXX where cpf01='" & Me.TxtUserID.Text.Trim() & "' ")

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strsql)


            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                CboJobs.Text = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("S_STEXT"))
                CboFactoryID.Text = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("CPF28"))
                'Me.CboFactoryID.SelectedIndex = Me.CboFactoryID.FindString(DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("CPF28")))
                TxtUserName.Text = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("CPF02"))
                CboDept.Text = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("CPF29"))
                CboTeam.Text = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("O_STEXT"))
            End If
        End Using

    End Sub

    Private Sub UserinfDg_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles UserinfDg.DataBindingComplete
        Dim B
        For B = 1 To UserinfDg.Rows.Count - 1
            If UserinfDg.Rows(B).Cells(9).Value.ToString = "离职" Then
                UserinfDg.Rows(B).DefaultCellStyle.BackColor = Color.LightGray
            End If
        Next
    End Sub
End Class
