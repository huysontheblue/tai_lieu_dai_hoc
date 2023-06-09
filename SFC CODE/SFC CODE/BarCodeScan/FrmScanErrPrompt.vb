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

Public Class FrmScanErrPrompt

    Dim ExitFlag As Boolean
    Dim scanSetting As ScanSetting
    Dim ScanSn As String = Nothing
    Dim IsTextScanCheck As Boolean = True

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal _scanSetting As ScanSetting)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        scanSetting = _scanSetting

    End Sub

    Private Sub FrmScanError_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If ExitFlag = True Then
            Exit Sub
        Else
            e.Cancel = True
        End If

    End Sub


    Private Sub FrmScanError_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Not scanSetting Is Nothing) Then

            Me.LabSn.Text = "條碼序號:" & scanSetting.BarCodeStr
            RTxtErrdes.Text = scanSetting.ErrorStr
            Me.ScanSn = scanSetting.BarCodeStr
            If scanSetting.BarCodeStr = "" Then
                Me.LabSn.Text = "條碼序號:" & WorkStantOption.BarCodeStr
                Me.ScanSn = WorkStantOption.BarCodeStr
            End If
            If scanSetting.ErrorStr = "" Then
                RTxtErrdes.Text = WorkStantOption.ErrorStr
            End If
        Else
            Me.LabSn.Text = "條碼序號:" & WorkStantOption.BarCodeStr
            RTxtErrdes.Text = WorkStantOption.ErrorStr
            Me.ScanSn = WorkStantOption.BarCodeStr
        End If
        FillCombox(CobError)
        IsCreateErrData()
        Me.CobError.SelectedIndex = -1
        If IsPowerUser() = True Then
            GroupBox1.Text = "请选择或者输入异常解决方法进行解锁"
            IsTextScanCheck = False
        Else
            IsTextScanCheck = True
            GroupBox1.Text = "已禁止手动输入解锁用户工号和密码，请扫描用户工卡和密码进行解锁验证;"
        End If
        'zhenfei.hu 2016-11-16 16:40:31 CZ和BZ异常处理时权限用户为当前登录工号,默认使用当前工号
        If VbCommClass.VbCommClass.Factory = "BZLANTO" Or VbCommClass.VbCommClass.Factory = "CHUZHOU" Then
            Me.txtUserName.Text = SysMessageClass.UseId.ToUpper
            Me.ActiveControl = TxtUserPass
            Me.CobError.SelectedIndex = 0
            Me.TxtUserPass.Focus()
        Else
            Me.ActiveControl = CobError
            Me.CobError.Focus()
        End If
       

    End Sub
    ''' <summary>
    ''' 判断登录用户是否高级用户
    ''' </summary>
    ''' <returns>true代表高级用户，false代表普通用户</returns>
    ''' <remarks></remarks>
    Private Function IsCreateErrData() As Boolean
        Dim moid As String = ""
        Dim lineid As String = ""
        Dim Stationid As String = ""
        If scanSetting Is Nothing Then
            moid = IIf(WorkStantOption.MoidStr Is Nothing, "", WorkStantOption.MoidStr)
            lineid = IIf(WorkStantOption.LineStr Is Nothing, "", WorkStantOption.LineStr)
            Stationid = IIf(WorkStantOption.vStandId Is Nothing, "", WorkStantOption.vStandId)
        Else
            moid = IIf(scanSetting.MoidStr Is Nothing, "", scanSetting.MoidStr)
            lineid = IIf(scanSetting.LineStr Is Nothing, "", scanSetting.LineStr)
            Stationid = IIf(scanSetting.vStandId Is Nothing, "", scanSetting.vStandId)
        End If

        Dim errMessage As String = ""
        If RTxtErrdes.Text.Length > 100 Then
            errMessage = RTxtErrdes.Text.Substring(0, 100)
        End If
        Dim sqlstr As StringBuilder = New StringBuilder
        sqlstr.Append("if not exists(select * from m_AssysnE_t WHERE  ppid='" & Me.ScanSn & "' and spoint='" & My.Computer.Name & "' and Intime>CONVERT(varchar(10),getdate(),23)  and isnull(Solvetime,'')='') ")
        sqlstr.Append("begin ")
        sqlstr.Append("insert m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime)")
        sqlstr.Append("select Ppid='" & ScanSn & "',Moid='" & moid & "',Stationid='" & Stationid & "',Teamid='" & lineid & "',Spoint=N'" & My.Computer.Name & "',Errordest=N'" & errMessage & "',Userid='" & VbCommClass.VbCommClass.UseId & "',Intime=getdate()")
        sqlstr.Append("end ")
        DbOperateUtils.ExecSQL(sqlstr.ToString)
    End Function

    ''' <summary>
    ''' 判断登录用户是否高级用户
    ''' </summary>
    ''' <returns>true代表高级用户，false代表普通用户</returns>
    ''' <remarks></remarks>
    Private Function IsPowerUser() As Boolean
        Dim sql As String = "select usergrade from m_users_t where  UserID='" & VbCommClass.VbCommClass.UseId & "' and isnull(usergrade,1)<>1 "
        If DbOperateUtils.GetRowsCount(sql) > 0 Then
            Return True
        Else
            Return False
        End If
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
    Private Sub BnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnCancel.Click

        Me.TxtUserPass.Text = ""

    End Sub

    Private Sub TxtUserPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUserPass.KeyPress
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
                BnOpenlock_Click(sender, e)
            End If
        Else
            If e.KeyChar = Chr(13) Then
                BnOpenlock_Click(sender, e)
            End If
        End If
       

    End Sub

    Private Sub BnOpenlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnOpenlock.Click
        Dim LoginClass As New TextHandle
        Dim strSQL As String = String.Empty
        Dim o_strPPID As String = String.Empty

        If CobError.Text = "" Then
            MessageBox.Show("解决方法不能為空！", "提示資訊", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If (String.IsNullOrEmpty(Me.txtUserName.Text.Trim())) Then
            MessageBox.Show("请输入解锁用户工号！", "提示資訊", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim dt As DataTable = DbOperateUtils.GetDataTable("select distinct a.userid from m_Users_t a left join m_userright_t b on a.userid=b.userid where a.UserID='" & Me.txtUserName.Text.Trim & "' and a.autoid='" & Me.TxtUserPass.Text & "' and b.tkey='m0510b_' AND A.Usey='1' ")
        If dt.Rows.Count = 0 Then
            MessageBox.Show("密碼不正確或無權限或用户无效！", "提示資訊", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If (Not scanSetting Is Nothing) Then
                scanSetting.vDeserTionFlag = False
            Else
                WorkStantOption.vDeserTionFlag = False
            End If
            Me.TxtUserPass.Focus()
            Me.TxtUserPass.SelectAll()
        Else
            Data.CheckStr = True
            If IsNothing(scanSetting) Then
                o_strPPID = ""
            Else
                o_strPPID = scanSetting.BarCodeStr
            End If

            Dim errMessage As String = ""
            If RTxtErrdes.Text.Length > 100 Then
                errMessage = RTxtErrdes.Text.Substring(0, 100)
            End If

            If (Not scanSetting Is Nothing) Then
                If scanSetting.vMainBarCode Is Nothing Then
                    scanSetting.vMainBarCode = ""
                End If
                If (scanSetting.vSq = "Y" And scanSetting.vMainBarCode.Trim <> "") Then
                    DeserTionMainCodeBar()
                Else
                    scanSetting.vDeserTionFlag = False
                    Dim moid As String = IIf(scanSetting.MoidStr Is Nothing, "", scanSetting.MoidStr)
                    Dim lineid As String = IIf(scanSetting.LineStr Is Nothing, "", scanSetting.LineStr)
                    Dim Stationid As String = IIf(scanSetting.vStandId Is Nothing, "", scanSetting.vStandId)

                    Dim sqlstr As StringBuilder = New StringBuilder
                    sqlstr.Append("if exists(select * from m_AssysnE_t WHERE ppid='" & Me.ScanSn & "' and spoint='" & My.Computer.Name & "' and isnull(Solvetime,'')='') ")
                    sqlstr.Append("begin ")
                    sqlstr.Append(" UPDATE m_AssysnE_t with(rowlock) SET Errormark=N'" & CobError.Text & "',Solvetime=getdate(),solveuser='" & Me.txtUserName.Text.Trim & "' WHERE ppid='" & Me.ScanSn & "' and spoint='" & My.Computer.Name & "' and isnull(Solvetime,'')='' ")
                    sqlstr.Append("end ")
                    sqlstr.Append("else ")
                    sqlstr.Append("begin ")
                    sqlstr.Append("insert m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark,Solveuser,Solvetime)")
                    sqlstr.Append("select Ppid='" & ScanSn & "',Moid='" & moid & "',Stationid='" & Stationid & "',Teamid='" & lineid & "',Spoint=N'" & My.Computer.Name & "',Errordest=N'" & errMessage & "',Userid='" & VbCommClass.VbCommClass.UseId & "',Intime=getdate(),Errormark=N'" & CobError.Text & "',solveuser='" & Me.txtUserName.Text.Trim & "',Solvetime=getdate() ")
                    sqlstr.Append("end ")
                    DbOperateUtils.ExecSQL(sqlstr.ToString)
                    'strSQL = " UPDATE m_AssysnE_t with(rowlock) SET Errormark='" & CobError.Text & "',Solvetime=getdate()," & _
                    '         " solveuser='" & Me.txtUserName.Text.Trim & "' " & _
                    '         " WHERE ppid='" & Me.ScanSn & "' and spoint='" & My.Computer.Name & "' and isnull(Solvetime,'')=''"

                    'DbOperateUtils.ExecSQL(strSQL)
                End If
            Else
                If (WorkStantOption.vSq = "Y" And WorkStantOption.vMainBarCode.Trim <> "") Then
                    DeserTionMainCodeBar()
                Else

                    WorkStantOption.vDeserTionFlag = False

                    Dim moid As String = IIf(WorkStantOption.MoidStr Is Nothing, "", WorkStantOption.MoidStr)
                    Dim lineid As String = IIf(WorkStantOption.LineStr Is Nothing, "", WorkStantOption.LineStr)
                    Dim Stationid As String = IIf(WorkStantOption.vStandId Is Nothing, "", WorkStantOption.vStandId)
                    Dim sqlstr As StringBuilder = New StringBuilder
                    sqlstr.Append("if exists(select * from m_AssysnE_t WHERE ppid='" & Me.ScanSn & "' and spoint='" & My.Computer.Name & "' and isnull(Solvetime,'')='') ")
                    sqlstr.Append("begin ")
                    sqlstr.Append(" UPDATE m_AssysnE_t with(rowlock) SET Errormark=N'" & CobError.Text & "',Solvetime=getdate(),solveuser='" & Me.txtUserName.Text.Trim & "' WHERE ppid='" & Me.ScanSn & "' and spoint='" & My.Computer.Name & "' and isnull(Solvetime,'')='' ")
                    sqlstr.Append("end ")
                    sqlstr.Append("else ")
                    sqlstr.Append("begin ")
                    sqlstr.Append("insert m_AssysnE_t(Ppid,Moid,Stationid,Teamid,Spoint,Errordest,Userid,Intime,Errormark,Solveuser,Solvetime)")
                    sqlstr.Append("select Ppid='" & ScanSn & "',Moid='" & moid & "',Stationid='" & Stationid & "',Teamid='" & lineid & "',Spoint=N'" & My.Computer.Name & "',Errordest=N'" & errMessage & "',Userid='" & VbCommClass.VbCommClass.UseId & "',Intime=getdate(),Errormark=N'" & CobError.Text & "',solveuser='" & Me.txtUserName.Text.Trim & "',Solvetime=getdate() ")
                    sqlstr.Append("end ")

                    DbOperateUtils.ExecSQL(sqlstr.ToString)
                End If
            End If
            ExitFlag = True
            Me.Close()
        End If

    End Sub

    Private Function DeserTionMainCodeBar() As Boolean
        Dim sqlStr As New StringBuilder
        Dim sqlErr As New StringBuilder
        If (Not scanSetting Is Nothing) Then
            If scanSetting.vPreStation <> "" Then
                sqlStr.Append("delete from m_AssysnD_t where ppid='" & scanSetting.vMainBarCode & "' and stationid='" & scanSetting.vStandId & "' " & vbNewLine)
                sqlStr.Append("update m_Assysn_t set stationid='" & scanSetting.vPreStation & "' where ppid='" & scanSetting.vMainBarCode & "'" & vbNewLine)
                sqlStr.Append("delete from m_Ppidlink_t where exppid='" & scanSetting.vMainBarCode & "'  and usey='Y'  and stationid='" & scanSetting.vStandId & "' " & vbNewLine)
            Else
                sqlStr.Append("delete from m_AssysnD_t where ppid='" & scanSetting.vMainBarCode & "' " & vbNewLine)
                sqlStr.Append("delete from m_Assysn_t where ppid='" & scanSetting.vMainBarCode & "'" & vbNewLine)
                sqlStr.Append("delete from m_Ppidlink_t where exppid='" & scanSetting.vMainBarCode & "'" & vbNewLine)
            End If
            sqlErr.Append("包装扫描解锁：参数 scanSetting Nothing")
        Else

            If WorkStantOption.vPreStation <> "" Then
                sqlStr.Append("delete from m_AssysnD_t where ppid='" & WorkStantOption.vMainBarCode & "' and stationid='" & WorkStantOption.vStandId & "' " & vbNewLine)
                sqlStr.Append("update m_Assysn_t set stationid='" & WorkStantOption.vPreStation & "' where ppid='" & WorkStantOption.vMainBarCode & "'" & vbNewLine)
                sqlStr.Append("delete from m_Ppidlink_t where exppid='" & WorkStantOption.vMainBarCode & "'  and usey='Y'  and stationid='" & WorkStantOption.vStandId & "' " & vbNewLine)
            Else
                sqlStr.Append("delete from m_AssysnD_t where ppid='" & WorkStantOption.vMainBarCode & "' " & vbNewLine)
                sqlStr.Append("delete from m_Assysn_t where ppid='" & WorkStantOption.vMainBarCode & "'" & vbNewLine)
                sqlStr.Append("delete from m_Ppidlink_t where exppid='" & WorkStantOption.vMainBarCode & "'" & vbNewLine)
            End If
            sqlErr.Append("包装扫描解锁：参数 scanSetting.vPreStation值" + scanSetting.vPreStation)
        End If
        'SysMessageClass.WriteErrLog(sqlErr.ToString, "DeserTionMainCodeBar", "FrmOnlineSop_Load", "sys")
        sqlStr.Append("update m_AssysnE_t with(ROWLOCK) set Errormark='" & CobError.Text & "',Solvetime=getdate(),solveuser='" & Me.txtUserName.Text.Trim & "' WHERE ppid='" & Data.BarCodeStr & "' and spoint='" & My.Computer.Name & "' and isnull(Solvetime,'')=''" & vbNewLine)
        sqlStr.Append("insert into m_Errinfo_t(ErrTime,Userid,NTUser,ErrNum,ErrDest,ErrForm,Errformprg,Errtype) values(getdate()")
        sqlStr.Append(",'" & SysMessageClass.UseId & "','" & System.Environment.UserName & "','1',N'" & sqlErr.ToString & "','BarCodeScan','DeserTionMainCodeBar',N'解锁')")
        Try
            DbOperateUtils.ExecSQL(sqlStr.ToString)
            If (Not scanSetting Is Nothing) Then
                scanSetting.vDeserTionFlag = True
            Else
                WorkStantOption.vDeserTionFlag = True
            End If

        Catch ex As Exception
            If (Not scanSetting Is Nothing) Then
                scanSetting.vDeserTionFlag = False
            Else
                WorkStantOption.vDeserTionFlag = False
            End If
            Exit Function
        End Try

    End Function
    Private _dt As DateTime = DateTime.Now
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
        Else
            If e.KeyChar = Chr(13) Then
                Me.ActiveControl = TxtUserPass
                Me.TxtUserPass.Focus()
            End If
        End If
    End Sub

    Private Sub txtUserName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserName.KeyDown
        If IsTextScanCheck Then
            If e.KeyCode = Keys.ControlKey Then
                MessageBox.Show("禁止复制,粘贴!")
            End If
        End If
    End Sub

    Private Sub txtUserName_MouseDown(sender As Object, e As MouseEventArgs) Handles txtUserName.MouseDown
        If IsTextScanCheck Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                MessageBox.Show("禁止复制,粘贴!")
            End If
        End If
    End Sub
End Class
