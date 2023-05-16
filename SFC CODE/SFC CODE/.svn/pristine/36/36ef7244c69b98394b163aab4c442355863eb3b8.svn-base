#Region "Imports"
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports MainFrame

#End Region

Public Class FrmAberrantErrPrompt
    Dim ExitFlag As Boolean
    'Dim scanSetting As ScanSetting
    Dim ScanSn As String = Nothing
    Dim IsTextScanCheck As Boolean = True
    Private _dt As DateTime = DateTime.Now
    Dim ErrMsg As String = Nothing
    Dim ErrTitle As String = Nothing
    '是否继续执行当前动作
    Private _IsContinueExec As Boolean
    Public Property IsContinueExec() As Boolean
        Get
            Return _IsContinueExec
        End Get

        Set(ByVal Value As Boolean)
            _IsContinueExec = Value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _BarCode As String, ByVal _ErrMsg As String, ByVal _ErrTitle As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        'scanSetting = _scanSetting
        ScanSn = _BarCode
        ErrMsg = _ErrMsg
        ErrTitle = _ErrTitle
        Me._IsContinueExec = False
    End Sub


    Private Sub FrmAberrantErrPrompt_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If ExitFlag = True Then
            Exit Sub
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmAberrantErrPrompt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '1289/C/E/1711/107884
        '1289/C/E/1711/107883

        LabSn.Text = ScanSn
        RTxtErrdes.Text = ErrMsg
        lbTitile.Text = ErrTitle
        FillCombox(Me.CobError)
        Me._IsContinueExec = False
    End Sub


#Region "函数"

    ''' <summary>
    ''' 判断登录用户是否高级用户
    ''' </summary>
    ''' <returns>true代表高级用户，false代表普通用户</returns>
    ''' <remarks></remarks>
    Private Function IsPowerUser() As Boolean
        Dim sql As String = "select usergrade from m_users_t where  UserID='" & VbCommClass.VbCommClass.UseId & "' and isnull(usergrade,1)<>1 "
        Return DbOperateUtils.GetRowsCount(sql) > 0
    End Function
    ''' <summary>
    ''' 绑定默认错误解决方案
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim UserDg As DataTable
        Dim lsSQL As String = String.Empty
        'dqc+'--'+deptid
        If ColComboBox.Name = "CobError" Then
            lsSQL = " select SortID,SortName from m_Sortset_t where SortType='lockerror' and Usey='Y' order by Orderid"
            UserDg = DbOperateUtils.GetDataTable(lsSQL)
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "SortName"
            ColComboBox.ValueMember = "SortID"
        End If
        UserDg = Nothing
    End Sub
    Private Sub SaveAssysnErr()
        Try
            Dim sqlstr As StringBuilder = New StringBuilder
            sqlstr.Append("insert m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark,Solveuser,Solvetime)")
            sqlstr.Append("select Ppid='" & ScanSn & "',Moid='',Stationid='',Teamid='',Spoint=N'" & My.Computer.Name & "',Errordest=N'" & RTxtErrdes.Text & "',Userid='" & VbCommClass.VbCommClass.UseId & "',Intime=getdate(),Errormark=N'" & CobError.Text & "',solveuser='" & Me.txtUserName.Text.Trim & "',Solvetime=getdate() ")
            DbOperateUtils.ExecSQL(sqlstr.ToString)
        Catch ex As Exception

        End Try

    End Sub

    Private Function OpenLockUp() As Boolean
        'Dim LoginClass As New TextHandle
        Dim strSQL As String = String.Empty
        Dim o_strPPID As String = String.Empty
        If CobError.Text = "" Then
            MessageBox.Show("解决方法不能為空！", "提示資訊", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If (String.IsNullOrEmpty(Me.txtUserName.Text.Trim())) Then
            MessageBox.Show("请输入解锁用户工号！", "提示資訊", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Dim dt As DataTable = DbOperateUtils.GetDataTable("select distinct a.userid from m_Users_t a left join m_userright_t b on a.userid=b.userid where a.UserID='" & Me.txtUserName.Text.Trim & "' and a.autoid='" & Me.TxtUserPass.Text & "' and b.tkey='m0510b_' AND A.Usey='1' ")
        If dt.Rows.Count = 0 Then
            MessageBox.Show("密碼不正確或無權限或用户无效！", "提示資訊", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtUserPass.Focus()
            Me.TxtUserPass.SelectAll()
            Return False
        End If
        Return True
    End Function
#End Region

    Private Sub txtUserName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUserName.KeyPress
        If IsTextScanCheck Then
            If e.KeyChar <> Chr(13) Then
                ''禁止用键盘手动输入
                Dim tempDt As DateTime = DateTime.Now
                Dim ts As TimeSpan = tempDt.Subtract(_dt)
                If (ts.Milliseconds > 50) Then
                    txtUserName.Text = ""
                End If
                _dt = tempDt
            Else
                Me.ActiveControl = TxtUserPass
                Me.TxtUserPass.Focus()
            End If
        End If
    End Sub

    Private Sub TxtUserPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUserPass.KeyPress
        If IsTextScanCheck Then
            If e.KeyChar <> Chr(13) Then
                ''禁止用键盘手动输入
                Dim tempDt As DateTime = DateTime.Now
                Dim ts As TimeSpan = tempDt.Subtract(_dt)
                If (ts.Milliseconds > 50) Then
                    TxtUserPass.Text = ""
                End If
                _dt = tempDt
            Else
                If InStr(TxtUserPass.ToString.ToLower, "accessory serial") > 0 Then
                    TxtUserPass.Clear()
                    Exit Sub
                End If
                'BnOpenlock_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub BnOpenlock_Click(sender As Object, e As EventArgs) Handles BnOpenlock.Click
   
        If OpenLockUp() = True Then
            If (MessageUtils.ShowConfirm("替换的条码和新条码样式不一致，确定要继续替换吗?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                SaveAssysnErr()
                Me._IsContinueExec = True
                Me.ExitFlag = True
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    Private Sub BnCancel_Click(sender As Object, e As EventArgs) Handles BnCancel.Click
        If OpenLockUp() = True Then
            SaveAssysnErr()
            Me.IsContinueExec = False
            Me.ExitFlag = True
            Me.DialogResult = Windows.Forms.DialogResult.No
            Me.Close()
        End If
    End Sub
End Class