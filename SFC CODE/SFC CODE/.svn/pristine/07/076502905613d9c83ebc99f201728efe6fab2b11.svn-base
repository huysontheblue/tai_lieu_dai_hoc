Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Drawing
Imports UIHandler
Imports Microsoft.Win32
Imports System.IO.Ports
Imports System.Threading
Imports System.Windows.Forms

Public Class FrmWeightCheck


    Private ngWavPlayTime As Integer = 2000     '错误声音播放时间
    Public Delegate Sub HandleInterfaceUpdataDelegate(ByVal text As String)
    Private interfaceUpdataHandle As HandleInterfaceUpdataDelegate
    Private Sp As SerialPort = New SerialPort()
    Private m_strRealWeight As String = ""
    Private m_blnNextStep As Boolean = True

    Private Sub TxtSheetNo_PreviewKeyDown(sender As Object, e As Windows.Forms.PreviewKeyDownEventArgs) Handles TxtSheetNo.PreviewKeyDown
        If String.IsNullOrEmpty(Me.cboCOMNo.Text) Then
            SetMessage("FAIL", "端口号不能为空!")
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.cobBardRate.Text) Then
            SetMessage("FAIL", "波特率不能为空!")
            Exit Sub
        End If


        If e.KeyValue = 13 Then
            '   StandScan()
        End If
    End Sub


    Private Sub StandWeightCheck()
        Me.txtOutputWeight.Text = ""

        'check whether HW 资料已经上传
        Dim lsSQL As New StringBuilder
        Dim Sqlstr As String = ""

        Sqlstr = " DECLARE @strmsgid  varchar(10), @strmsgText  nvarchar(100)" & _
                 " DECLARE @StdMinWeight float " & _
                 " DECLARE @StdMaxWeight float " & _
                 " EXECUTE [m_HWCheckPackWeight_P] '" & TxtSheetNo.Text.Trim & "', " & _
                 " @StdMinWeight output, @StdMaxWeight output,@strmsgText OUTPUT, @strmsgid output" & _
                 " SELECT @strmsgid,@strmsgText,@StdMinWeight,@StdMaxWeight  "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
        If dt.Rows.Count > 0 Then
            Select Case Val(DbOperateUtils.DBNullToStr(dt.Rows(0)(0)))
                Case Is < 0
                    SetMessage("FAIL", dt.Rows(0).Item(1))
                    Me.TxtSheetNo.Focus()
                    Me.TxtSheetNo.Clear()
                    PlaySimpleSound(1)
                    Exit Sub
                Case Else
                    'check OK, pass
                    Me.TxtStdMinWeight.Text = DbOperateUtils.DBNullToStr(dt.Rows(0).Item(2))
                    Me.txtStdMaxWeight.Text = DbOperateUtils.DBNullToStr(dt.Rows(0).Item(3))
            End Select
        End If

        If String.IsNullOrEmpty(Me.TxtStdMinWeight.Text) OrElse String.IsNullOrEmpty(Me.txtStdMaxWeight.Text) Then
            SetMessage("FAIL", "標準重量最大或最小值不能為空, 請檢查!")
            Me.TxtSheetNo.Focus()
            Me.TxtSheetNo.Clear()
            PlaySimpleSound(1)
            Exit Sub
        End If
    End Sub

    Private Sub UpdateCheckOKResult(ByVal strRealWeight As String)
        Dim lsSQL As New StringBuilder

        Dim strState As String = ""
        If (Val(Me.LblShouldCheckQty.Text) = Val(Me.LblCheckedQty.Text)) AndAlso (Val(Me.LblShouldCheckQty.Text)) > 0 Then
            strState = "1"
        Else
            strState = "0"
        End If

        lsSQL.AppendLine(" UPDATE m_HWPackWeight_t SET RealWeight='" & Val(strRealWeight.Trim) & "',WeightTime = getdate(), State=1 , WeightUserID = '" & VbCommClass.VbCommClass.UseId & "'")
        lsSQL.AppendLine(" WHERE HWCartonID='" & Me.TxtHWCartonID.Text.Trim & "' AND SheetNo ='" & Me.TxtSheetNo.Text.Trim & "'")

        lsSQL.AppendLine(" If ISNULL(( SELECT TOP 1 1 FROM m_HWPackWeightLogM_t WHERE HWCartonID='" & Me.TxtHWCartonID.Text.Trim & "'),0) =0 ")
        lsSQL.AppendLine(" BEGIN")
        lsSQL.AppendLine(" Insert into m_HWPackWeightLogM_t(PartID,HWCartonID,State,UserID,Intime,checkedqty ) ")
        lsSQL.AppendLine(" Values('" & Me.TxtPartid.Text.Trim & "','" & Me.TxtHWCartonID.Text.Trim & "',")
        lsSQL.AppendLine("  0, '" & VbCommClass.VbCommClass.UseId & "', getdate(),1) ")
        lsSQL.AppendLine("End")
        lsSQL.AppendLine(" Else  ")
        lsSQL.AppendLine(" BEGIN")
        lsSQL.AppendLine(" Update m_HWPackWeightLogM_t SET STATE='" & strState & "', CheckedQty= '" & Val(Me.LblCheckedQty.Text) & "' WHERE HWCartonID='" & Me.TxtHWCartonID.Text.Trim & "'")
        lsSQL.AppendLine("End")

        lsSQL.AppendLine(" If ISNULL(( SELECT TOP 1 1 FROM m_HWPackWeightLogD_t WHERE HWCartonID='" & Me.TxtHWCartonID.Text.Trim & "' and Sheetno='" & Me.TxtSheetNo.Text.Trim & "' ),0) =0 ")
        lsSQL.AppendLine(" BEGIN")
        lsSQL.AppendLine(" Insert into m_HWPackWeightLogD_t(sheetNo,PartID,HWCartonID,RealWeight,UserID,Intime) ")
        lsSQL.AppendLine(" Values('" & Me.TxtSheetNo.Text.Trim & "', '" & Me.TxtPartid.Text.Trim & "','" & Me.TxtHWCartonID.Text.Trim & "',")
        lsSQL.AppendLine(" '" & Val(strRealWeight.Trim) & "', '" & VbCommClass.VbCommClass.UseId & "', getdate()) ")
        lsSQL.AppendLine("End")

        DbOperateUtils.ExecSQL(lsSQL.ToString)


    End Sub


    Private Sub UpdateTextBox(ByVal text As String)
        txtOutputWeight.Text = text
    End Sub


    Private Sub ATCommand3(ByVal ATCmd As String, ByVal StCmd As String)
        Dim response As String = ""
        response = ATCommand(ATCmd, StCmd)
    End Sub


    Private Function ATCommand(ByVal ATCmd As String, ByVal StCmd As String) As String
        Dim response As String = ""
        Dim i As Integer
        If Not ATCmd.EndsWith("\x01a") Then
            If Not (ATCmd.EndsWith(Chr(13)) Or ATCmd.EndsWith("\r\n")) Then
                ATCmd = ATCmd + "\r"
            End If
        End If
        Sp.WriteLine(ATCmd)

        '第一次读响应数据 
        If Sp.BytesToRead > 0 Then
            response = Sp.ReadExisting()

            '去除前端多可能多读取的字符 
            If response.IndexOf(ATCmd) > 0 Then
                response = response.Substring(response.IndexOf(ATCmd))
            Else

            End If

            If response = "" Or response.IndexOf(StCmd) < 0 Then
                If response <> "" Then
                    If response.Trim() = "ERROR" Then
                        'throw vError = new UnknowException("Unknown exception in sending command:" + ATCmd); 
                    End If
                    If response.IndexOf("+CMS ERROR") >= 0 Then
                        Dim cols() As String = New String(100) {}
                        cols = response.Split(";"c)
                        If cols.Length > 1 Then
                            Dim errorCode As String = cols(1)
                        End If
                    End If
                End If
            End If
        End If

        '读第一次没有读完的响应数据，直到读到特征数据或超时 
        For i = 0 To 3 - 1 Step i + 1
            Thread.Sleep(1000)
            response = response + Sp.ReadExisting()
            If response.IndexOf(StCmd) >= 0 Then
                Exit For
            End If
        Next

        Return response
    End Function


    Public Sub Sp_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs)
        Dim strTemp As String = ""
        Dim iSecond As Double = 0.5

        Dim dtOld As DateTime = System.DateTime.Now
        Dim dtNow As DateTime = System.DateTime.Now
        Dim dtInter As TimeSpan
        dtInter = dtNow - dtOld

        Dim i As Integer = Sp.BytesToRead
        If i > 0 Then
            Try
                strTemp = Sp.ReadExisting()
            Catch

            End Try

            ' \r表示回车,在VB中等同于Chr(13)
            ' If strTemp.ToLower().IndexOf("\r") < 0 Then
            If strTemp.ToLower().IndexOf(Chr(13)) < 0 Then
                i = 0
                ' Me.Invoke(interfaceUpdataHandle, strTemp)
            Else
                Me.Invoke(interfaceUpdataHandle, strTemp)
            End If
        End If
        While dtInter.TotalSeconds < iSecond And i <= 0
            dtNow = System.DateTime.Now
            dtInter = dtNow - dtOld
            i = Sp.BytesToRead
            If i > 0 Then
                Try
                    strTemp += Sp.ReadExisting()
                Catch

                End Try
                '\r
                If strTemp.ToLower().IndexOf(Chr(13)) < 0 Then
                    i = 0
                Else
                    Me.Invoke(interfaceUpdataHandle, strTemp)
                End If
            End If
        End While
        ' do null  
    End Sub


    Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        If 1 = 1 Then
            Select Case PassOrNg
                Case 0 '正常提示音
                    'My.Computer.Audio.Play(My.Resources.Resource1.ok_zhcn, AudioPlayMode.Background)
                    'BeepUp.Beep(500, okWavPlayTime)
                Case 1 '错误提示音
                    'My.Computer.Audio.Play(My.Resources.Resource1.fail_zhcn, AudioPlayMode.Background)
                    BeepUp.Beep(2800, ngWavPlayTime)
                Case 2
                    'My.Computer.Audio.Play(My.Resources.Resource1.chimes, AudioPlayMode.Background)
            End Select
        End If
    End Sub

    Private Sub SetMessage(result As String, message As String)
        'If result.ToUpper = "FAIL" Then
        '    LabResult.Text = "FAIL"
        '    lblMessage.Text = message
        '    LabResult.ForeColor = Color.Crimson
        '    lblMessage.ForeColor = Color.Crimson
        'Else
        '    LabResult.Text = "PASS"
        '    lblMessage.Text = message
        '    LabResult.ForeColor = Color.FromArgb(0, 192, 0)
        '    lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
        'End If

        Select Case result.ToUpper

            Case "FAIL"
                LabResult.Text = "FAIL"
                lblMessage.Text = message
                LabResult.ForeColor = Color.Crimson
                lblMessage.ForeColor = Color.Crimson
            Case Else
                LabResult.Text = "PASS"
                lblMessage.Text = message
                LabResult.ForeColor = Color.FromArgb(0, 192, 0)
                lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
        End Select

    End Sub


    Private Sub FrmWeightCheck_Load(sender As Object, e As EventArgs) Handles Me.Load

        LabResult.Text = ""
        lblMessage.Text = "请扫描"
        ToolUsename.Text = SysMessageClass.UseName

        Call SetIniCOMValue()

        Me.ActiveControl = Me.TxtSheetNo
    End Sub

    Private Sub SetIniCOMValue()

        Call GetComByPCName()

        If String.IsNullOrEmpty(Me.cboCOMNo.Text) OrElse String.IsNullOrEmpty(Me.cobBardRate.Text) Then
            lblMessage.Text = "请先设置COM的值"
            Exit Sub
        End If
    End Sub

    Private Sub GetComByPCName()
        Dim lsSQL As String = ""
        lsSQL = " SELECT SUBSTRING( TEXT,0, CHARINDEX('|',TEXT)), SUBSTRING( TEXT,charindex('|',TEXT)+1,LEN(TEXT)) " & _
                " FROM m_HWWeightBaseData_t   " & _
                " WHERE PCVALUE ='" & My.Computer.Name & "' "
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) And o_dt.Rows.Count > 0 Then
                Me.cboCOMNo.Text = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item(0))
                Me.cobBardRate.Text = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item(1))
            End If
        End Using
    End Sub

    ''' <summary>
    ''' 获取COM口
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetComList()
        Dim keyCom As RegistryKey = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm")
        If Not keyCom Is Nothing Then
            Dim sSubKeys() As String = keyCom.GetValueNames()
            Me.cboCOMNo.Items.Clear()
            Dim sName As String
            For Each sName In sSubKeys
                Dim sValue As String = CType(keyCom.GetValue(sName), String)
                Me.cboCOMNo.Items.Add(sValue)
            Next
        End If
    End Sub


    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolCOMSetting_Click(sender As Object, e As EventArgs) Handles toolCOMSetting.Click

        Dim frmPCCOMSet As New FrmPCCOMSet()
        frmPCCOMSet.ShowDialog()
        cboCOMNo.Text = frmPCCOMSet.txtCOMValue.Text.Trim
        cobBardRate.Text = frmPCCOMSet.TxtBaudRate.Text.Trim

        If (Not String.IsNullOrEmpty(Me.cboCOMNo.Text)) AndAlso (Not String.IsNullOrEmpty(Me.cobBardRate.Text)) Then
            lblMessage.Text = "设置COM OK, 请开始称重..."
        End If
    End Sub

    Private Sub btnENT_Click(sender As Object, e As EventArgs) Handles btnENT.Click
        If (Me.cboCOMNo.Text.Trim() <> "") AndAlso (Me.cobBardRate.Text <> "") Then
            interfaceUpdataHandle = New HandleInterfaceUpdataDelegate(AddressOf UpdateTextBox) '实例化委托对象 
            Sp.PortName = Me.cboCOMNo.Text.Trim()
            Sp.BaudRate = Convert.ToInt32(Me.cobBardRate.Text.Trim())
            Sp.Parity = Parity.None
            Sp.StopBits = StopBits.One
        End If

        AddHandler Sp.DataReceived, AddressOf Sp_DataReceived

        Sp.ReceivedBytesThreshold = 1
        Try
            Sp.Open()

            ATCommand3("AT+CLIP=1\r", "OK")

            btPause.Enabled = True
            Me.btnENT.Enabled = False

            lblMessage.Text = "打开监听OK, 请开始称重检查..."
        Catch
            MessageUtils.ShowError("端口" + Me.cboCOMNo.Text.Trim() + "打开失败！")
        End Try
    End Sub

    Private Sub btPause_Click(sender As Object, e As EventArgs) Handles btPause.Click
        Sp.Close()
        Me.btnENT.Enabled = True
        btPause.Enabled = False
    End Sub

    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click

        Dim frmSelectCarton As New FrmSelectCarton

        frmSelectCarton.ShowDialog()

        Me.TxtHWCartonID.Text = frmSelectCarton.CobHWCartonID.Text

        Me.TxtPartid.Text = GetPartID()

        BindNeedCheckList()

        BindAlreadyCheckedList()

        If Me.dgvNeedCheckList.RowCount > 0 Then
            ' Me.TxtSheetNo.Text = Me.dgvNeedCheckList.Rows(0).Cells(0).Value
        Else
            SetMessage("FAIL", "请更换装箱单号, 請檢查!")
            Me.TxtSheetNo.Focus()
            Me.TxtSheetNo.Clear()
            PlaySimpleSound(1)
            Exit Sub
        End If
    End Sub

    Private Function GetPartID() As String

        Dim lsSQL As String = ""
        GetPartID = ""

        lsSQL = " SELECT  PARTID, State FROM m_HWPackWeight_t  " & _
                " WHERE HWCartonID='" & Me.TxtHWCartonID.Text.Trim & "' "

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then

                Me.LblShouldCheckQty.Text = CStr(o_dt.Rows.Count)

                GetPartID = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item(0))

            End If
        End Using
        Return GetPartID
    End Function


    ''' <summary>
    ''' 加载待检查的明细列表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BindNeedCheckList()
        Dim lssql As String = ""
        lssql = " SELECT  SHEETNO, RequestQty, GrossWeight  FROM m_HWPackWeight_t " & _
                " WHERE STATE =0  AND HWCartonID='" & Me.TxtHWCartonID.Text & "' " & _
                " ORDER BY SHEETNO, REQUESTQTY DESC "

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
            If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                Me.dgvNeedCheckList.DataSource = o_dt
            Else
                Me.dgvNeedCheckList.DataSource = Nothing
            End If
        End Using
    End Sub

    Private Sub BindAlreadyCheckedList()
        Dim lssql As String = ""
        lssql = " SELECT  SHEETNO, RealWeight, UserID, Intime  " & _
                " FROM m_HWPackWeight_t " & _
                " WHERE STATE =1 AND  HWCartonID='" & Me.TxtHWCartonID.Text & "'" & _
                " ORDER BY Intime DESC "

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
            If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                Me.DGridBarCode.DataSource = o_dt
                Me.LblCheckedQty.Text = o_dt.Rows.Count
            Else
                Me.DGridBarCode.DataSource = Nothing
                Me.LblCheckedQty.Text = "0"
            End If
        End Using
    End Sub

    Private Sub dgvNeedCheckList_CellDoubleClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgvNeedCheckList.CellDoubleClick

        If Me.dgvNeedCheckList.RowCount <= 0 Then Exit Sub

        Me.lblMessage.Text = String.Empty
        Me.LabResult.Text = String.Empty

        Me.TxtSheetNo.Text = Me.dgvNeedCheckList.CurrentRow.Cells(0).Value
        If Not IsDBNull(Me.dgvNeedCheckList.CurrentRow.Cells(2)) Then
            Me.TxtStdMinWeight.Text = Math.Round(Me.dgvNeedCheckList.CurrentRow.Cells(2).Value * 0.97, 2)
        End If

        Me.txtStdMaxWeight.Text = Math.Round(Me.dgvNeedCheckList.CurrentRow.Cells(2).Value * 1.03, 2)
        'need clear 
        Me.txtOutputWeight.Text = String.Empty
    End Sub

    ''' <summary>
    ''' 代替回车事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtSheetNo_TextChanged(sender As Object, e As EventArgs) Handles TxtSheetNo.TextChanged

        '检查监听 是否打开
        If Me.btnENT.Enabled = True Then
            SetMessage("FAIL", "请先点击监听按钮!")
            Me.TxtSheetNo.Focus()
            ' Me.TxtSheetNo.Clear()
            PlaySimpleSound(1)
            Exit Sub
        End If

        If LabResult.Text.Trim.ToUpper = "FAIL" Then
            Exit Sub
        End If

        Call StandWeightCheck()

    End Sub

    'Private Sub txtOutput_TextChanged(sender As Object, e As EventArgs) Handles txtOutput.TextChanged
    '    'try to get the Real Weight
    'End Sub

    Private Sub toolCheck_Click(sender As Object, e As EventArgs) Handles toolCheck.Click

        'A check UI  是否正确
        If String.IsNullOrEmpty(Me.TxtHWCartonID.Text) Then
            SetMessage("FAIL", "装箱单号不能为空!")
            Me.TxtHWCartonID.Focus()
            Me.TxtHWCartonID.Clear()
            PlaySimpleSound(1)
            Exit Sub
        End If

        'B check whether checked 
        If IsChecked() Then
            SetMessage("FAIL", "该箱已经检查过,请更换下一个!")
            Me.TxtSheetNo.Focus()
            Me.TxtSheetNo.Clear()
            PlaySimpleSound(1)
            Exit Sub
        End If

        'try to get the Real Weight
        If Not String.IsNullOrEmpty(Me.txtOutputWeight.Text) Then
            Dim strTmpWeight As String = Me.txtOutputWeight.Text
            If (strTmpWeight.Contains(vbCrLf)) Then
                strTmpWeight = strTmpWeight.Replace(vbCrLf, "@")
                Dim strarr As String()
                strarr = strTmpWeight.Split("@")

                For Each item As String In strarr
                    'N.W.:   0.68kg
                    If item.Contains("N.W.") Then
                        strTmpWeight = item.Split(":")(1).Replace("kg", "")
                        Exit For
                    End If
                Next
            Else
                If strTmpWeight.Contains("N.W.") Then
                    strTmpWeight = strTmpWeight.Split(":")(1).Replace("kg", "")
                End If
            End If

            'Compare the weight data
            If Val(strTmpWeight) < Val(TxtStdMinWeight.Text.Trim) Then
                SetMessage("FAIL", "不能低于標準重量最小值, 請檢查!")
                Me.TxtSheetNo.Focus()
                'Me.TxtSheetNo.Clear()
                PlaySimpleSound(1)
                Exit Sub
            End If

            If Val(strTmpWeight) > Val(txtStdMaxWeight.Text.Trim) Then
                SetMessage("FAIL", "不能超過標準重量最大值, 請檢查!")
                Me.TxtSheetNo.Focus()
                ' Me.TxtSheetNo.Clear()
                PlaySimpleSound(1)
                Exit Sub
            End If

            'weight check ok
            Call UpdateCheckOKResult(strTmpWeight)

            Call ShowCheckedList()

            'Refesh the need check list
            Call BindNeedCheckList()

            'Clear UI
            Me.txtOutputWeight.Text = String.Empty

            'Auto change to Next SheetNO
            Call SetNextSheetNo()

            SetMessage("PASS", "称重检查ok, 请检查下一箱!")
        Else
            SetMessage("FAIL", "请放置箱并称重!")
        End If
    End Sub

    Private Sub SetNextSheetNo()
        If Me.dgvNeedCheckList.Rows.Count > 0 Then
            Me.TxtSheetNo.Text = Me.dgvNeedCheckList.Rows(0).Cells(0).Value
            If Not IsDBNull(Me.dgvNeedCheckList.CurrentRow.Cells(2)) Then
                Me.TxtStdMinWeight.Text = Math.Round(Me.dgvNeedCheckList.Rows(0).Cells(2).Value * 0.97, 2)
            End If

            Me.txtStdMaxWeight.Text = Math.Round(Me.dgvNeedCheckList.Rows(0).Cells(2).Value * 1.03, 2)
            'need clear 
            Me.txtOutputWeight.Text = String.Empty
        End If
    End Sub

    Private Function IsChecked() As Boolean
        Dim lsSQL As String = String.Empty

        IsChecked = False

        lsSQL = " SELECT SheetNo FROM m_HWPackWeightLogD_t " & _
                " Where HWCartonID='" & Me.TxtHWCartonID.Text.Trim & "' AND  SHEETNO ='" & Me.TxtSheetNo.Text.Trim & "'"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsChecked = True
            End If
        End Using
        Return IsChecked
    End Function


    Private Sub ShowCheckedList()

        Dim lsSQL As String = ""

        lsSQL = " SELECT  [SheetNo] ,[RealWeight] ,[WeightUserID] ,[Intime]" & _
                " FROM m_HWPackWeight_t  " & _
                " WHERE HWCartonID='" & Me.TxtHWCartonID.Text.Trim & "' " & _
                " ORDER BY Intime DESC"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                DGridBarCode.DataSource = o_dt
                Me.LblCheckedQty.Text = o_dt.Rows.Count
            End If
        End Using
    End Sub

    Private Sub dgvResult_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvNeedCheckList.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
End Class