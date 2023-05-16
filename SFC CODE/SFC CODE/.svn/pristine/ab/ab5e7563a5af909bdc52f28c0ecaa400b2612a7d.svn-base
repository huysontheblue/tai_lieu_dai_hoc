
'用户设置
'Create by: 马锋
'Create time: 2015-06-04
'Update by: 
'Update time:  

Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData

Public Class FrmUserSetting

#Region "窗体载入事件"

    Private Sub FrmUserSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ToolbtnState(0)
        LoadControlsData()
    End Sub

#End Region

#Region "工具事件"

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

    Private Sub toolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        ToolbtnState(1)
    End Sub

    Private Sub toolComfire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolComfire.Click
        ToolbtnState(0)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim strSQL As New StringBuilder
        Try
            Dim FactoryCode As String
            Dim ProfitCenter As String
            Dim AutoLogin As String

            If (Me.cbxFactory.Items.Count > 0) Then
                FactoryCode = Me.cbxFactory.Text.Trim
            Else
                FactoryCode = ""
            End If

            If (Me.cbxProfitcenter.Items.Count > 0) Then
                ProfitCenter = Me.cbxProfitcenter.Text.Trim
            Else
                ProfitCenter = ""
            End If

            If (Me.rBtnAutomaticLogin.Checked) Then
                AutoLogin = "2"
            Else
                AutoLogin = "0"
            End If

            strSQL.Append(ControlChars.CrLf & " IF EXISTS(SELECT USERID FROM m_UserSetting_t WHERE USERID='" & SysMessageClass.UseId & "' AND PARAMETER_CODE='FactoryCode') BEGIN UPDATE m_UserSetting_t SET PARAMETER_VALUES=N'" & FactoryCode & "', UPDATEUSER_ID='" & SysMessageClass.UseId & "', UPDATETIME=GETDATE() WHERE PARAMETER_CODE='FactoryCode' and USERID='" & SysMessageClass.UseId & "' END")
            strSQL.Append(ControlChars.CrLf & " ELSE BEGIN INSERT INTO m_UserSetting_t(USERID, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, UPDATETIME) VALUES('" & SysMessageClass.UseId & "','FactoryCode',N'工厂',N'" & FactoryCode & "','" & SysMessageClass.UseId & "',GETDATE()) END")
            strSQL.Append(ControlChars.CrLf & " IF EXISTS(SELECT USERID FROM m_UserSetting_t WHERE USERID='" & SysMessageClass.UseId & "' AND PARAMETER_CODE='ProfitCenter') BEGIN UPDATE m_UserSetting_t SET PARAMETER_VALUES=N'" & ProfitCenter & "', UPDATEUSER_ID='" & SysMessageClass.UseId & "', UPDATETIME=GETDATE() WHERE PARAMETER_CODE='ProfitCenter' and USERID='" & SysMessageClass.UseId & "' END")
            strSQL.Append(ControlChars.CrLf & " ELSE BEGIN INSERT INTO m_UserSetting_t(USERID, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, UPDATETIME) VALUES('" & SysMessageClass.UseId & "','ProfitCenter',N'利润中心',N'" & ProfitCenter & "','" & SysMessageClass.UseId & "',GETDATE()) END")
            strSQL.Append(ControlChars.CrLf & " IF EXISTS(SELECT USERID FROM m_UserSetting_t WHERE USERID='" & SysMessageClass.UseId & "' AND PARAMETER_CODE='AutoLogin') BEGIN UPDATE m_UserSetting_t SET PARAMETER_VALUES=N'" & AutoLogin & "', UPDATEUSER_ID='" & SysMessageClass.UseId & "', UPDATETIME=GETDATE() WHERE PARAMETER_CODE='AutoLogin' and USERID='" & SysMessageClass.UseId & "' END")
            strSQL.Append(ControlChars.CrLf & " ELSE BEGIN INSERT INTO m_UserSetting_t(USERID, PARAMETER_CODE, PARAMETER_NAME, PARAMETER_VALUES, UPDATEUSER_ID, UPDATETIME) VALUES('" & SysMessageClass.UseId & "','AutoLogin',N'登录方式',N'" & AutoLogin & "','" & SysMessageClass.UseId & "',GETDATE()) END")

            Conn.ExecSql(strSQL.ToString())
            SetMessage("保存成功!", False)
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            SetMessage("保存异常!", False)
        End Try
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        LoadControlsData()
    End Sub

#End Region

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0
                Me.ToolReflsh.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolComfire.Enabled = False
                Me.ToolExit.Enabled = True

                Me.cbxFactory.Enabled = False
                Me.cbxProfitcenter.Enabled = False
                Me.rBtnAutomaticLogin.Enabled = False
                Me.rBtnVerifyLogin.Enabled = False
                Me.ActiveControl = Me.cbxFactory
            Case 1
                Me.ToolReflsh.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolComfire.Enabled = True
                Me.ToolExit.Enabled = True

                Me.cbxFactory.Enabled = True
                Me.cbxProfitcenter.Enabled = True
                Me.rBtnAutomaticLogin.Enabled = True
                Me.rBtnVerifyLogin.Enabled = True
                Me.ActiveControl = Me.cbxFactory
        End Select
    End Sub

    Private Sub SetMessage(ByVal Message As String, ByVal statusType As Boolean)

        If (statusType) Then
            Me.lblMessage.ForeColor = Color.Green
        Else
            Me.lblMessage.ForeColor = Color.Red
        End If
        Me.lblMessage.Text = Message
    End Sub

    Private Sub LoadControlsData()
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader = Nothing
        Dim strSQL As String
        Try
            Me.cbxFactory.DataSource = Nothing
            cbxFactory.Items.Clear()
            Dim sql As String = "select Factoryid,Factoryid+'-'+Shortname name from m_Dcompany_t"

            Dim dtGroup As DataTable = Conn.GetDataTable(sql)
            cbxFactory.DisplayMember = "name"
            cbxFactory.ValueMember = "Factoryid"

            cbxFactory.DataSource = dtGroup
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If

            strSQL = "SELECT PARAMETER_CODE,PARAMETER_VALUES FROM m_UserSetting_t WHERE USERID='" & SysMessageClass.UseId & "'"
            Dreader = Conn.GetDataReader(strSQL)
            Do While Dreader.Read()
                Select Case Dreader.Item(0).ToString.ToUpper()
                    Case "FactoryCode".ToUpper()
                        Me.cbxFactory.SelectedIndex = Me.cbxFactory.FindString(Dreader.Item(1).ToString)
                    Case "ProfitCenter".ToUpper()
                        Me.cbxProfitcenter.SelectedIndex = Me.cbxProfitcenter.FindString(Dreader.Item(1).ToString)
                    Case "AutoLogin".ToUpper()
                        If (Dreader.Item(1).ToString = "0") Then
                            Me.rBtnVerifyLogin.Checked = True
                        Else
                            Me.rBtnVerifyLogin.Checked = False
                        End If
                End Select
            Loop
            Dreader.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            If (Dreader.IsClosed = False) Then
                Dreader.Close()
            End If

            SetMessage("加载异常!", False)
        End Try
    End Sub

#Region "控件事件"

    Private Sub cbxFactory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxFactory.SelectedIndexChanged
        If (String.IsNullOrEmpty(Me.cbxFactory.SelectedValue.ToString.Trim)) Then
            Exit Sub
        End If

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim strSQL As String
        Try
            Me.cbxProfitcenter.DataSource = Nothing
            Me.cbxProfitcenter.Items.Clear()
            strSQL = "SELECT PROFITCENTER_CODE, PROFITCENTER_CODE+'('+PROFITCENTER_NAME+')' AS PROFITCENTER_NAME FROM m_ProfitCenter_t WHERE FACTORY_ID='" & Me.cbxFactory.SelectedValue.ToString.Trim & "'"

            Dim dtGroup As DataTable = Conn.GetDataTable(strSQL)

            Me.cbxProfitcenter.DisplayMember = "PROFITCENTER_NAME"
            Me.cbxProfitcenter.ValueMember = "PROFITCENTER_CODE"
            Me.cbxProfitcenter.DataSource = dtGroup

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            MessageBox.Show("获取工厂利润中心失败,请确认网络是否连接正常，重启后重试。")
        End Try
    End Sub

#End Region

    
End Class