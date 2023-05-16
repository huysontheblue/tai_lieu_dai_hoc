#Region "Imports"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports BarCodeScan.Data
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports BarCodePrint
Imports System.IO
Imports System.Xml
Imports MainFrame
Imports UIHandler
Imports SysBasicClass
Imports System.Threading
Imports RouteManagement
Imports System.IO.Ports

#End Region
Public Class FrmCrossStageInputScan
    Public scanSetting As New ScanSetting
    Dim WithEvents RS232 As SerialPort
#Region "事件"


    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click
        Dim strSQL As String = ""


        Try
            Dim FrmOpenLock As New FrmSetLock
            FrmNewShareSetForm.vStationType = "P"
            FrmOpenLock.ShowDialog()

            If CartonScanOption.CheckStr = True Then
                Dim FrmScanSet As New FrmNewShareSetForm(ScanSetting)
                FrmScanSet.Owner = Me
                FrmScanSet.ShowDialog()

                If ScanSetting.IsExitFlag = True Then
                    ScanSetting.MoidStr = ""
                    TxtMoId.Text = String.Empty
                    TxtPartid.Text = String.Empty
                    TxtPartid.Text = String.Empty
                    TxtLineId.Text = String.Empty

                    lblMessage.ForeColor = Color.Red
                    lblMessage.Text = "请设置扫描参数"
                    Exit Sub
                End If
                scanSetting.vCurrentStandIndex = scanSetting.vCurrentStandIndex + 1
                TxtBarCode.Focus()
                DGridBarCode.DataSource = Nothing
                TxtMoId.Text = ScanSetting.MoidStr           ''工單
                TxtSitName.Text = scanSetting.vStandId & scanSetting.vStandName
                TxtPartid.Text = ScanSetting.PartidStr ''料件編號
                TxtLineId.Text = ScanSetting.LineStr ''線別

                SetMessage("PASS", "扫描资料设置完成")

                '加载已扫描数量
                GetScanQty()
            End If
          
        Catch ex As Exception
            ScanSetting.MoidStr = ""
            TxtMoId.Text = String.Empty
            TxtPartid.Text = String.Empty
            TxtPartid.Text = String.Empty
            TxtLineId.Text = String.Empty
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "设置扫描参数异常,请重新设置"
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#{1}", Me.TxtMoId.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmCrossStageInputScan", "toolScanSet_Click", "sys")
        End Try
    End Sub
    Private Sub TxtBarCode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TxtBarCode.PreviewKeyDown
        If (scanSetting.MoidStr Is Nothing) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtBarCode.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If (String.IsNullOrEmpty(scanSetting.MoidStr)) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtBarCode.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If e.KeyValue = 13 Then
            StandScan()
        End If
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
#End Region


#Region "函数"

    Private Sub StandScan()
        If InStr(TxtBarCode.Text, "'") Then
            TxtBarCode.Clear()
            Exit Sub
        End If

        If Me.TxtBarCode.Text.Length <> LTrim(Me.TxtBarCode.Text).Length Then

            WorkStantOption.ErrorStr = "ERROR,左端有空格！"
            SetMessage("Fail", "ERROR,左端有空格")
            WorkStantOption.BarCodeStr = TxtBarCode.Text
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)

            Exit Sub
        Else
            ' do nothing
        End If

        If Me.TxtBarCode.Text.Length <> RTrim(Me.TxtBarCode.Text).Length Then

            WorkStantOption.ErrorStr = "ERROR,右端有空格！"
            SetMessage("Fail", "ERROR,右端有空格")
            WorkStantOption.BarCodeStr = TxtBarCode.Text
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)

            Exit Sub
        Else
            ' do nothing
        End If

        Dim BarCode As String = Trim(TxtBarCode.Text).Replace(vbNewLine, "")

        If scanSetting.IsNotCaseSensitive = "Y" Then
            BarCode = BarCode.ToUpper
        End If

        Dim Sqlstr As String = String.Empty

        Try
            'Dim tempstr() As String = scanSetting.vmReplaceArray(scanSetting.vCurrentStandIndex, 1).Split("|")

            Sqlstr = " DECLARE @strmsgid varchar(1), @strmsgText nvarchar(150), @currqty int " & _
                     " EXECUTE [m_CrossStageInputScan_P] '" & Trim(BarCode) & "'," & _
                        "'" & Trim(TxtMoId.Text) & "','" & Trim(TxtLineId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & _
                        "'" & scanSetting.PartidStr & "'," & _
                        "'" & scanSetting.vStandId & "','" & scanSetting.vStandIndex & "','" & scanSetting.vCurrentStandIndex & "'," & _
                        "@strmsgid output,@strmsgText output,@currqty output " & _
                        "SELECT @strmsgid,@strmsgText,isnull(@currqty,1) as currqty "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)

            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0", "1", "2", "3", "5"
                        PlaySimpleSound(1)
                        WorkStantOption.BarCodeStr = BarCode
                        WorkStantOption.ErrorStr = dt.Rows(0)(1)
                        WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                        SetMessage("FAIL", BarCode & Space(3) & dt.Rows(0)(1))
                        ShowFrmScanErrPrompt()
                        SetMessage("PASS", "已解锁，请继续进行作业")
                        TxtBarCode.Text = ""
                        Me.TxtBarCode.Focus()
                        Exit Sub
                    Case "6" ''---掃描成功
                        PlaySimpleSound(0)
                        If scanSetting.vCurrentStandIndex = 1 Then
                            LblMainBarCode.Text = TxtBarCode.Text
                        End If

                        SetMessage("PASS", "扫描成功...")
                        '@OutPPID       
                        'TxtBarCode.Text = dt.Rows(0).Item("PPID").ToString
                        Me.DGridBarCode.Rows.Insert(0, scanSetting.PartidStr, scanSetting.vStandIndex, _
                                                    TxtBarCode.Text, scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3), SysMessageClass.UseId, Now())

                        If DGridBarCode.Rows.Count > 10 Then
                            DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
                        End If
                        LblScanQty.Text = dt.Rows(0).Item("currqty").ToString
                        TxtBarCode.Clear()
                        TxtBarCode.Focus()
                  
                End Select
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            MessageUtils.ShowInformation("数据库连接异常,请检查网络后,重新确认数据扫描!")
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, TxtBarCode.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmNewStantPackScan", "StandScan", "sys")
        End Try
    End Sub
    Private Sub GetScanQty()
        Dim strSQL As String = "SELECT count(1) FROM M_ASSYSND_T  where moid = '{0}' and stationid = '{1}'"
        strSQL = String.Format(strSQL, TxtMoId.Text, scanSetting.vStandId)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        '存在数据返回错误
        If dt.Rows.Count > 0 Then
            LblScanQty.Text = dt.Rows(0)(0).ToString
        End If
    End Sub

    Private Sub DisposeData()
        scanSetting.PackNumber = Nothing
        scanSetting.BarCodeStr = Nothing
        scanSetting.DpetNameStr = Nothing
        scanSetting.ErrorStr = Nothing
        scanSetting.GflenStr = Nothing
        ' scanSetting.LengthStr = Nothing
        scanSetting.LineStr = Nothing
        scanSetting.MoCustStr = Nothing
        scanSetting.MoidqtyStr = Nothing
        'scanSetting.MoidStr = Nothing
        scanSetting.PartidStr = Nothing
        scanSetting.PartPackQty = Nothing
        scanSetting.PrintPort = Nothing
        scanSetting.SnidStr = Nothing
        scanSetting.SnStyleStr1 = Nothing
        scanSetting.SnStyleStr2 = Nothing
        scanSetting.TimeStr = Nothing
        scanSetting.CustStr = Nothing
        ''''''''''''''''
        scanSetting.moType = Nothing
        ''''''''''''''''''''''''''''''''''

        scanSetting.CustIdString = Nothing
        scanSetting.InCartonScanCheck = False

        scanSetting.vStandId = Nothing
        scanSetting.vStandName = Nothing
        scanSetting.vCurrentStandIndex = Nothing
        scanSetting.vStandMaxStaIndex = Nothing
        scanSetting.vTimeStyleSet = Nothing
        Array.Clear(scanSetting.vstyleArray, 0, scanSetting.vstyleArray.Length)
        scanSetting.vStandIndex = Nothing
        scanSetting.TimeStr = Nothing

    End Sub
    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            LabResult.Text = "FAIL"
            lblMessage.Text = message
            LabResult.ForeColor = Color.Crimson
            lblMessage.ForeColor = Color.Crimson
        Else
            LabResult.Text = "PASS"
            lblMessage.Text = message
            LabResult.ForeColor = Color.FromArgb(0, 192, 0)
            lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub


    Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        If (Me.chbMessage.Checked) Then
            Select Case PassOrNg
                Case 0 '正常提示音
                    My.Computer.Audio.Play(My.Resources.Resource1.ok_zhcn, AudioPlayMode.Background)
                    'BeepUp.Beep(500, okWavPlayTime)
                    
                Case 1 '错误提示音
                    My.Computer.Audio.Play(My.Resources.Resource1.fail_zhcn, AudioPlayMode.Background)
                    'BeepUp.Beep(2800, ngWavPlayTime)
                Case 2
                    'My.Computer.Audio.Play(My.Resources.Resource1.chimes, AudioPlayMode.Background)
            End Select
        End If
    End Sub

    Private Sub ShowFrmScanErrPrompt()
        Dim FrmError As New FrmScanErrPrompt(scanSetting)
        FrmError.ShowDialog()
    End Sub
#End Region



  
End Class