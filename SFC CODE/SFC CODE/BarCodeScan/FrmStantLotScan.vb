Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmStantLotScan

    Public scanSetting As New ScanSetting

    '初期化
    Private Sub FrmStantLotScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = True Then Exit Sub '只执行第一次

        lblMessage.Text = "请设置扫描资料"
        ToolUsename.Text = SysMessageClass.UseName

    End Sub

    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click
        scanSetting.FormName = Me.Name
        Try
            Dim FrmOpenLock As New FrmSetLock
            FrmShareSetForm.vStationType = "P"
            FrmOpenLock.ShowDialog()

            If CartonScanOption.CheckStr = True Then
                'Application.EnableVisualStyles()
                Dim FrmScanSet As New FrmLotShareSetForm(scanSetting)
                FrmScanSet.Owner = Me
                FrmScanSet.ShowDialog()

                If scanSetting.IsExitFlag = True Then
                    scanSetting.MoidStr = ""
                    TxtMoId.Text = String.Empty
                    TxtPartid.Text = String.Empty
                    TxtPartid.Text = String.Empty
                    TxtLineId.Text = String.Empty
                    LabResult.Text = ""
                    LabResult.ForeColor = Color.Red
                    lblMessage.ForeColor = Color.Red
                    lblMessage.Text = "请设置扫描参数"
                    Exit Sub
                End If

                TxtBarCode.Focus()

                SetMessage("PASS", "扫描资料设置完成...")

                LblScanTime.Text = WorkStantOption.TimeStr
                TxtMoId.Text = scanSetting.MoidStr           ''工單
                TxtSitName.Text = scanSetting.vStandId & scanSetting.vStandName    ''工單數量
                TxtPartid.Text = scanSetting.PartidStr ''料件編號
                TxtLineId.Text = scanSetting.LineStr ''線別
                LblMoqty.Text = scanSetting.MoidqtyStr '工单生产数量
                TxtSnStyle1.Text = scanSetting.SnStyleStr1

                '扫描记录明细
                BindGrid()
                DispScanData()

            End If
            WorkStantOption.CheckStr = False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmStantLotScan", "toolScanSet_Click", "sys")
            Exit Sub
        End Try

    End Sub

    '条码扫描
    Private Sub TxtBarCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBarCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            StandScan()
        End If
    End Sub

    '退出 
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#Region "條碼掃描"

    '条码扫描
    Private Sub StandScan()
        Try
            Dim BarCode As String = Trim(TxtBarCode.Text)
            Dim strSQL As String
            Dim LOT_QTY As String
            Dim CUR_QTY As String

            '检查扫描数据
            If CheckScanData() = False Then
                Dim FrmError As New FrmScanErrPrompt(scanSetting)
                FrmError.ShowDialog()
                Exit Sub
            End If

            strSQL = "  DECLARE @strmsgid varchar(1), @strmsgText varchar(150),@CUR_QTY int, @LOT_QTY int, @LOT_CNT int " & _
                    "   EXECUTE [m_NewLotPackScan_P] '" & BarCode & "','" & Trim(TxtMoId.Text) & "','" & scanSetting.vStandId & "'," & _
                    "   '" & Trim(TxtLineId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & _
                    "   @strmsgid output,@strmsgText output,@CUR_QTY output, @LOT_QTY output, @LOT_CNT output " & _
                    "   SELECT @strmsgid,@strmsgText,@CUR_QTY,@LOT_QTY,@LOT_CNT "

            '保存生成的批次条码记录
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0", "1", "2", "3", "5"
                        PlaySimpleSound(1)
                        WorkStantOption.BarCodeStr = BarCode
                        WorkStantOption.ErrorStr = dt.Rows(0)(1)
                        WorkStantOption.vMainBarCode = BarCode
                        SetMessage("FAIL", BarCode & Space(3) & dt.Rows(0)(1))
                        ShowFrmScanErrPrompt()
                        SetMessage("PASS", "已解锁，请继续进行作业")
                        TxtBarCode.Text = ""
                        Me.TxtBarCode.Focus()
                        Exit Sub
                    Case "4" ''---掃描成功
                        SetMessage("PASS", "扫描成功...")
                        '@OutPPID       
                        CUR_QTY = dt.Rows(0).Item(2).ToString
                        LOT_QTY = dt.Rows(0).Item(3).ToString
                        lblScanLotNum.Text = dt.Rows(0).Item(4).ToString
                        LabCartonQty.Text = LOT_QTY

                        Me.DGridBarCode.Rows.Insert(0, scanSetting.PartidStr, Trim(scanSetting.vStandId) + "-" + Trim(scanSetting.vStandName), _
                                                    TxtBarCode.Text, CUR_QTY, SysMessageClass.UseId, Now())

                        If DGridBarCode.Rows.Count > 10 Then
                            DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
                        End If

                        TxtBarCode.Clear()
                        TxtBarCode.Focus()
                End Select
            End If

        Catch ex As Exception
            'PlaySimpleSound(1)
            SysMessageClass.WriteErrLog(ex, Me.Name, "BtEnter_Click", "sys")
        End Try
    End Sub

#End Region

    Private Function CheckScanData() As Boolean
        CheckScanData = False
        '检查基本信息设置
        If Me.TxtMoId.Text = "" Then
            SetMessage("FAIL", "請先設置好掃描基本信息！")
            Exit Function
        End If

        CheckScanData = True
    End Function

    '显示扫描历史数据
    Private Sub BindGrid()

        Dim strSQL As String =
            "   SELECT MM.PartID," &
            "       (ASD.Stationid + '-' + RST.Stationname ) AS Stationid," &
            "       ASD.Ppid," &
            "       SSC.Qty," &
            "       (ASD.Userid + '-' + US.UserName) AS Userid, " &
            "       ASD.Intime" &
            "   FROM m_AssysnD_t ASD" &
            "   INNER JOIN m_SnSBarCode_t SSC ON PPID= SBarCode" &
            "       AND ASD.MOID=SSC.MOID" &
            "       AND PACKID='L'" &
            "   INNER JOIN m_Mainmo_t MM ON MM.MOID = SSC.MOID" &
            "   LEFT JOIN m_Rstation_t RST ON ASD.Stationid = RST.Stationid" &
            "   LEFT JOIN m_Users_t  US ON  ASD.Userid = US.UserID" &
            "   WHERE ASD.MOID = '{0}' AND RST.Stationid = '{1}' " &
            "   ORDER BY ASD.Intime desc "
        strSQL = String.Format(strSQL, TxtMoId.Text, scanSetting.vStandId)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        DGridBarCode.Rows.Clear()
        For Each dr As DataRow In dt.Rows
            DGridBarCode.Rows.Add(dr("PartID").ToString, dr("Stationid").ToString, dr("Ppid").ToString,
                                  dr("Qty").ToString, dr("Userid").ToString, dr("Intime").ToString)
        Next

    End Sub

    ''' <summary>
    ''' 显示数量和次数
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DispScanData()
        Dim strSQL As String = "select SUM(PPIDQTY) QTY,COUNT(1) CNT from m_AssysnD_t where moid = '{0}' and Stationid = '{1}' and Estateid = 'Y' "
        strSQL = String.Format(strSQL, TxtMoId.Text, scanSetting.vStandId)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        lblScanLotNum.Text = 0
        LabCartonQty.Text = 0
        If dt.Rows.Count > 0 Then
            lblScanLotNum.Text = dt.Rows(0)("CNT").ToString
            LabCartonQty.Text = dt.Rows(0)("QTY").ToString
        End If
    End Sub

    Private Sub ShowFrmScanErrPrompt()
        Dim FrmError As New FrmScanErrPrompt(scanSetting)
        FrmError.ShowDialog()
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

#Region "工单状态设置"

    Private Sub toolMOStatusSetting_Click(sender As Object, e As EventArgs) Handles toolMOStatusSetting.Click
        Try
            If (String.IsNullOrEmpty(Me.TxtMoId.Text.Trim)) Then
                lblMessage.Text = "请设置工单！"
                Exit Sub
            End If

            Dim FrmMOStatusSetting As New FrmMOStatusSetting(Me.TxtMoId.Text.Trim, Me.TxtLineId.Text.Trim)
            FrmMOStatusSetting.ShowDialog()

        Catch ex As Exception
            lblMessage.Text = "打开工单状态设置异常！"
        End Try
    End Sub

#End Region

    '双击复制工单和料件的内容,方面运维时复制粘贴Add By KyLinQiu 20170717
    Private Sub TxtMoId_DoubleClick(sender As Object, e As EventArgs) Handles TxtMoId.DoubleClick, TxtPartid.DoubleClick
        Try
            Dim LabText As Label = sender
            If LabText Is Nothing Then
                Exit Sub
            End If
            Clipboard.SetText(LabText.Text.Trim)
        Catch ex As Exception
        End Try
    End Sub

End Class