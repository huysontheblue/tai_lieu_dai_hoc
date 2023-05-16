Imports MainFrame.SysCheckData
Imports System.Data.SqlClient

Public Class FrmSNCheck

    Private Sub FrmSNCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtBarCode.Enabled = False
        LabResult.Text = ""
        lblMessage.Text = "请设置扫描资料"
        ToolUsename.Text = SysMessageClass.UseName
    End Sub
    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click
        Try
            Dim frmset As New FrmSNCheckSet
            frmset.ShowDialog()

            If Not String.IsNullOrEmpty(WorkStantOption.MoidStr) Then
                TxtBarCode.Enabled = True
                TxtBarCode.Focus()
                TxtMoId.Text = WorkStantOption.MoidStr           ''工單
                TxtPartid.Text = WorkStantOption.PartidStr  '料號
                ''LabCust.Text = WorkStantOption.CustStr ''工單類型               TxtPartid.Text = WorkStantOption.PartidStr ''料件編號
                TxtLineId.Text = WorkStantOption.LineStr ''線別
                lblMessage.Text = "扫描资料设置完成"
            Else
                lblMessage.Text = "扫描资料设置Fail"
            End If

         
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmSNCheck", "GetScanItem", "sys")
            Exit Sub
        End Try

    End Sub

    Private Sub TxtBarCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBarCode.KeyPress
        If e.KeyChar = Chr(13) Then

            Dim RecDr As SqlDataReader = Nothing
            Dim Sqlstr As String = ""
            Dim BarCode As String
            Dim factory As String = VbCommClass.VbCommClass.Factory
            Dim profit As String = VbCommClass.VbCommClass.profitcenter
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            BarCode = Trim(TxtBarCode.Text).ToUpper

            If Me.TxtMoId.Text = "" Or Me.TxtPartid.Text = "" Or Me.TxtLineId.Text = "" Then
                MessageBox.Show("請先設置好掃描基本信息！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                PlaySimpleSound(1)
                Exit Sub
            End If
            Try
                Dim Moid As String = Trim(TxtMoId.Text).ToUpper
                Sqlstr = "declare @strmsgid varchar(1),@strmsgText varchar(50)   execute [Exec_CheckSN] @strmsgid OUT,@strmsgText OUT," & _
                           " '" & factory & "','" & profit & "','" & Trim(TxtLineId.Text) & "','" & SysMessageClass.UseId & "'," & _
                          " '" & Trim(TxtMoId.Text) & "','" & Trim(TxtPartid.Text) & "','" & BarCode & "'" & _
                         " select @strmsgid,@strmsgText"
                RecDr = Conn.GetDataReader(Sqlstr)
                If RecDr.HasRows Then
                    RecDr.Read()
                    Select Case RecDr.GetString(0)
                        Case "1"
                            PlaySimpleSound(0)
                            LabResult.ForeColor = Color.FromArgb(0, 192, 0)
                            lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
                            LabResult.Text = BarCode & Space(3) & "扫描成功..."
                            lblMessage.Text = "PASS"
                            Me.DGridBarCode.Rows.Insert(0, BarCode, Moid, VbCommClass.VbCommClass.UseId, Date.Now.ToString)
                            If DGridBarCode.Rows.Count > 10 Then
                                DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
                            End If
                            TxtBarCode.Text = ""
                            Me.TxtBarCode.Focus()
                            Exit Sub
                        Case "0"
                            LabResult.ForeColor = Color.Crimson
                            lblMessage.ForeColor = Color.Crimson
                            WorkStantOption.ErrorStr = RecDr.GetString(1)
                            Exit Select
                    End Select
                End If
                PlaySimpleSound(1)
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = BarCode
                LabResult.Text = BarCode & Space(3) & "扫描时发生错误！"
                lblMessage.Text = "FAIL"
                Dim FrmError As New FrmScanErrPrompt
                FrmError.ShowDialog()
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                Exit Sub
            Catch ex As Exception
                PlaySimpleSound(1)
                'If Not RecDr Is Nothing Then
                '    RecDr.Close()
                '    Conn.PubConnection.Close()
                'End If
                'PlaySimpleSound(1)
                MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                SysMessageClass.WriteErrLog(ex, Me.Name, "TxtBarCode_KeyPress", "sys")
                Exit Sub
            Finally
                If Not RecDr Is Nothing Then
                    RecDr.Close()
                    Conn.PubConnection.Close()
                End If
            End Try
        End If
    End Sub
#Region "聲音播放"
    Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        If (Me.chbMessage.Checked) Then
            Select Case PassOrNg
                Case 0
                    My.Computer.Audio.Play(My.Resources.Resource1.ok_zhcn, AudioPlayMode.Background)
                Case 1
                    My.Computer.Audio.Play(My.Resources.Resource1.fail_zhcn, AudioPlayMode.Background)
                Case 2
                    My.Computer.Audio.Play(My.Resources.Resource1.chimes, AudioPlayMode.Background)

            End Select
        End If
    End Sub
#End Region

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
End Class