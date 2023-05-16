

'--From Name:Belkin出货检查扫描
'--Create by :马锋
'--Create date :　2015/01/16
'--Update date :  
'--Ver : V01

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD

Public Class FrmCheckShippingBarCode

    'Private Declare Function sndPlaySound Lib "winmm.dll" Alias "sndPlaySoundA" (ByVal lpszSoundName As String, ByVal uFlags As Long) As Long
    'Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    Public Declare Auto Function PlaySound Lib "winmm.dll" (ByVal pszSound As String, ByVal hmod As IntPtr, ByVal fdwSound As Integer) As Boolean


    Private Sub FrmCheckShippingBarCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtCheckBarcode.Enabled = True
        Me.txtScanBarcode.Enabled = False
        Me.btnClear.Enabled = True
        Me.btnHandle.Enabled = False
        Me.lblQuantity.Text = "0000"
        Me.lblResult.Text = ""
        Me.lblResult.BackColor = System.Drawing.SystemColors.Control
        Me.txtCheckBarcode.Focus()
    End Sub

    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtCheckBarcode.Text = ""
        Me.txtScanBarcode.Text = ""

        Me.txtCheckBarcode.Enabled = True
        Me.txtCheckBarcode.Focus()
    End Sub

    Private Sub txtCheckBarcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCheckBarcode.KeyPress
        If e.KeyChar = Chr(13) Then
            If (String.IsNullOrEmpty(Me.txtCheckBarcode.Text.Trim())) Then
                Me.txtScanBarcode.Text = ""
                Me.txtScanBarcode.Enabled = False
                Me.txtCheckBarcode.Enabled = True
                Me.txtCheckBarcode.Focus()
            Else
                Me.txtCheckBarcode.Text = UCase(Me.txtCheckBarcode.Text.Trim())
                Me.txtCheckBarcode.Enabled = False
                Me.btnClear.Enabled = True
                Me.txtScanBarcode.Enabled = True
                Me.txtScanBarcode.Focus()
            End If
        End If
    End Sub

    Private Sub txtScanBarcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScanBarcode.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.txtScanBarcode.Enabled = False
            SetMessage("")

            If (String.IsNullOrEmpty(Me.txtScanBarcode.Text.Trim())) Then
                Me.txtScanBarcode.Focus()
            Else
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
                Dim strCheckResult As String
                Try
                    Dim strSQL As String

                    If (Me.txtCheckBarcode.Text.Trim().ToUpper() = Me.txtScanBarcode.Text.Trim().ToUpper()) Then
                        strCheckResult = "1"
                    Else
                        strCheckResult = "0"
                    End If

                    strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                             " EXECUTE Exec_BelkinShippingCheck @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'," & _
                             "'" & SysMessageClass.UseId & "','" & Me.txtShippingNO.Text.Trim.ToUpper().Replace("'", "''") & "','" & Me.txtCheckBarcode.Text.Trim().ToUpper().Replace("'", "''") & "','" & Me.txtScanBarcode.Text.Trim().ToUpper().Replace("'", "''") & "','" & strCheckResult.Replace("'", "''") & "'" & _
                             " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "
                    Dim drGetSQLRecor As SqlDataReader = Conn.GetDataReader(strSQL)
                    If drGetSQLRecor.HasRows Then
                        drGetSQLRecor.Read()
                        Select Case drGetSQLRecor(0).ToString()
                            Case "0"
                                SetMessage(drGetSQLRecor(1).ToString())
                                Me.lblResult.Text = "NG"
                                Me.lblResult.ForeColor = Color.Red      'Red
                                Me.lblResult.BackColor = Color.Pink
                            Case "1"
                                Me.lblQuantity.Text = CInt(Me.lblQuantity.Text.Trim()) + 1
                                Me.lblResult.Text = "OK"
                                Me.lblResult.ForeColor = Color.Green    'Green
                                Me.lblResult.BackColor = Color.PaleGreen
                        End Select
                    End If
                    drGetSQLRecor = Nothing
                    Conn = Nothing
                Catch ex As Exception
                    Conn = Nothing
                    strCheckResult = 0
                    SetMessage("系统提交异常")
                    Me.lblResult.Text = "NG"
                    Me.lblResult.ForeColor = Color.Red      'Red
                    Me.lblResult.BackColor = Color.Pink
                    PlayMessage(0)
                End Try
                UpdateCheckShippingDate(strCheckResult)
                If (strCheckResult = "0") Then
                    PlayMessage(0)
                End If
            End If
            Me.txtScanBarcode.Text = ""
            Me.txtScanBarcode.Enabled = True
            Me.txtScanBarcode.Focus()
        End If

    End Sub

    Private Sub btnHandle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHandle.Click
        PlaySimpleSound(0)

    End Sub

    Private Sub SetMessage(ByVal Message As String)
        Me.lblMessage.Text = Message
    End Sub

#Region "聲音播放"

    Sub UpdateCheckShippingDate(ByVal CheckResult As String)
 
        Me.dgvScanList.Rows.Insert(0, Me.dgvScanList.RowCount + 1, Me.txtShippingNO.Text.Trim, "", Me.txtCheckBarcode.Text.Trim.ToUpper(), Me.txtScanBarcode.Text.Trim().ToUpper(), CheckResult)
        Me.dgvScanList.ClearSelection()
        Me.dgvScanList.Rows(0).Cells(0).Selected = True
        Select Case CheckResult
            Case "0"
                Me.dgvScanList.Rows(0).DefaultCellStyle.BackColor = Color.Red
                'Me.dgvScanList.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End Select
    End Sub

    Sub PlayMessage(ByVal result As Integer)
        Dim strPath As String=""
        Dim ip As UIntPtr = UIntPtr.Zero
        Select Case result

            Case 0
                strPath = Application.StartupPath & "\Play\fail_zhcn.wav"
            Case 1
                strPath = Application.StartupPath & "\Play\ok_zhcn.wav"
        End Select

        Dim bResult As Boolean = PlaySound(strPath, IntPtr.Zero, ip)

    End Sub


    Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        If (Me.ChkPlay.Checked) Then
            Select Case PassOrNg
                Case 0
                    My.Computer.Audio.Play(My.Resources.Resource1.ok_zhcn, AudioPlayMode.Background)
                Case 1
                    My.Computer.Audio.Play(My.Resources.Resource1.fail_zhcn, AudioPlayMode.Background)
                Case 2
                    My.Computer.Audio.Play(My.Resources.Resource1.chimes, AudioPlayMode.Background)

            End Select
        End If
        'Case 0  '
        'My.Computer.Audio.Play(My.Resources.Resource1.pass, AudioPlayMode.Background)
        '    Case 1
        'My.Computer.Audio.Play(My.Resources.Resource1.ERR, AudioPlayMode.Background)
        '    Case 2
        'My.Computer.Audio.Play(My.Resources.Resource1.chimes, AudioPlayMode.Background)

    End Sub

    Sub PlayWavFile(ByVal strFileName As String, ByVal PlayCount As Long, ByVal JianGe As Long)
        'strFileName 要播放的文件名(带路径)
        'playCount 播放的次数
        'JianGe  多次播放时,每次的时间间隔
        'If Len(Dir(strFileName)) = 0 Then Exit Sub
        'If PlayCount = 0 Then Exit Sub
        'If JianGe < 1000 Then JianGe = 1000
        'DoEvents()
        'sndPlaySound(strFileName, 16 + 1)
        'Sleep(JianGe)
        'Call PlayWavFile(strFileName, PlayCount - 1, 0)
    End Sub
#End Region

End Class