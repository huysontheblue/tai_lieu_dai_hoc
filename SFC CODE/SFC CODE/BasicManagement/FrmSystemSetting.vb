
'系统设置
'Create by: 马锋
'Create time: 2015-06-04
'Update by: 
'Update time:  

Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData

Public Class FrmSystemSetting

#Region "窗体载入事件"

    Private Sub FrmSystemSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ToolbtnState(0)
        LoadControlsData()
    End Sub

#End Region

#Region "datagridview"


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
            strSQL.Append(ControlChars.CrLf & "UPDATE m_SystemSetting_t SET PARAMETER_VALUES=N'" & Me.txtPrintFile.Text.Trim() & "', UPDATEUSER_ID='" & SysMessageClass.UseId & "', UPDATETIME=GETDATE() WHERE PARAMETER_CODE='PrintFile'")
            strSQL.Append(ControlChars.CrLf & "UPDATE m_SystemSetting_t SET PARAMETER_VALUES=N'" & Me.txtSopFile.Text.Trim() & "', UPDATEUSER_ID='" & SysMessageClass.UseId & "', UPDATETIME=GETDATE() WHERE PARAMETER_CODE='SopFile'")
            strSQL.Append(ControlChars.CrLf & "UPDATE m_SystemSetting_t SET PARAMETER_VALUES=N'" & IIf(Me.cbxTiptopCheck.Checked = True, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId & "', UPDATETIME=GETDATE() WHERE PARAMETER_CODE='IsLinkErp'")
            strSQL.Append(ControlChars.CrLf & "UPDATE m_SystemSetting_t SET PARAMETER_VALUES=N'" & Me.txtPrintDateFile.Text.Trim() & "', UPDATEUSER_ID='" & SysMessageClass.UseId & "', UPDATETIME=GETDATE() WHERE PARAMETER_CODE='PrintDateFile'")
            strSQL.Append(ControlChars.CrLf & "UPDATE m_SystemSetting_t SET PARAMETER_VALUES=N'" & IIf(Me.chkClientMac.Checked = True, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId & "', UPDATETIME=GETDATE() WHERE PARAMETER_CODE='CheckClientMac'")
            strSQL.Append(ControlChars.CrLf & "UPDATE m_SystemSetting_t SET PARAMETER_VALUES=N'" & IIf(Me.chkVersionConn.Checked = True, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId & "', UPDATETIME=GETDATE() WHERE PARAMETER_CODE='VersionConn'")
            strSQL.Append(ControlChars.CrLf & "UPDATE m_SystemSetting_t SET PARAMETER_VALUES=N'" & IIf(Me.chkProgramFileVersion.Checked = True, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId & "', UPDATETIME=GETDATE() WHERE PARAMETER_CODE='CheckProgramFileVersion'")
            strSQL.Append(ControlChars.CrLf & "UPDATE m_SystemSetting_t SET PARAMETER_VALUES=N'" & IIf(Me.chkReleasedVersion.Checked = True, "Y", "N") & "', UPDATEUSER_ID='" & SysMessageClass.UseId & "', UPDATETIME=GETDATE() WHERE PARAMETER_CODE='ReleasedVersion'")
            strSQL.Append(ControlChars.CrLf & "UPDATE m_SystemSetting_t SET PARAMETER_VALUES=N'" & Me.txtDataMigrationCount.Text & "', UPDATEUSER_ID='" & SysMessageClass.UseId & "', UPDATETIME=GETDATE() WHERE PARAMETER_CODE='DataMigrationCount'")

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

                Me.txtPrintFile.Enabled = False
                Me.txtSopFile.Enabled = False
                Me.txtPrintDateFile.Enabled = False
                Me.cbxTiptopCheck.Enabled = False
                Me.chkReleasedVersion.Enabled = False
                Me.chkClientMac.Enabled = False
                Me.chkVersionConn.Enabled = False
                Me.chkProgramFileVersion.Enabled = False
                Me.txtDataMigrationCount.Enabled = False
                Me.ActiveControl = Me.txtPrintFile
            Case 1
                Me.ToolReflsh.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolComfire.Enabled = True
                Me.ToolExit.Enabled = True

                Me.txtPrintFile.Enabled = True
                Me.txtSopFile.Enabled = True
                Me.txtPrintDateFile.Enabled = True
                Me.chkReleasedVersion.Enabled = True
                Me.cbxTiptopCheck.Enabled = True
                Me.chkClientMac.Enabled = True
                Me.chkVersionConn.Enabled = True
                Me.chkProgramFileVersion.Enabled = True
                Me.txtDataMigrationCount.Enabled = True
                Me.ActiveControl = Me.txtPrintFile
        End Select
    End Sub

    Private Sub LoadControlsData()
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader = Nothing
        Dim strSQL As String
        Try
            strSQL = "SELECT PARAMETER_CODE,PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='MES'"
            Dreader = Conn.GetDataReader(strSQL)
            Do While Dreader.Read()
                Select Case Dreader.Item(0).ToString.ToUpper()
                    Case "PrintFile".ToUpper()
                        Me.txtPrintFile.Text = Dreader.Item(1).ToString
                    Case "SopFile".ToUpper()
                        Me.txtSopFile.Text = Dreader.Item(1).ToString
                    Case "IsLinkErp".ToUpper()
                        Me.cbxTiptopCheck.Checked = IIf(Dreader.Item(1).ToString = "Y", True, False)
                    Case "PrintDateFile".ToUpper()
                        Me.txtPrintDateFile.Text = Dreader.Item(1).ToString
                    Case "ReleasedVersion".ToUpper()
                        Me.chkReleasedVersion.Checked = IIf(Dreader.Item(1).ToString = "Y", True, False)
                    Case "CheckClientMac".ToUpper()
                        Me.chkClientMac.Checked = IIf(Dreader.Item(1).ToString = "Y", True, False)
                    Case "VersionConn".ToUpper()
                        Me.chkVersionConn.Checked = IIf(Dreader.Item(1).ToString = "Y", True, False)
                    Case "CheckProgramFileVersion".ToUpper()
                        Me.chkProgramFileVersion.Checked = IIf(Dreader.Item(1).ToString = "Y", True, False)
                    Case "DataMigrationCount".ToUpper()
                        Me.txtDataMigrationCount.Text = Dreader.Item(1).ToString
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

    Private Sub SetMessage(ByVal Message As String, ByVal statusType As Boolean)

        If (statusType) Then
            Me.lblMessage.ForeColor = Color.Green
        Else
            Me.lblMessage.ForeColor = Color.Red
        End If
        Me.lblMessage.Text = Message
    End Sub


End Class