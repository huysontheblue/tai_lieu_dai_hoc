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

#End Region

Public Class FrmOutOfBoxCheck

#Region "窗體變量"

    Dim IsCustPart As Boolean
    Dim IsPrtPacking As Boolean
    Dim IsScanPallet As Boolean
    Dim PalletID As String                  '栈板条码
    Dim IsFull As Boolean = False           '棧板是否裝滿
    Dim IsLinePrint As String = "N"         '是否在线打印产品条码
    Dim IsReadSn As String = "N"            '是否读取序号
    Dim TgenCarton As String = "N"          '自动生面外箱
    Dim IsPackingPPID As String = "N"       '是否产品序号相同（允许箱产品同包装）
    Dim IsPackType As String = "N"          '包装类型
    Dim IsPrtSelf As String = "N"           '是否在系统里面打印
    Dim IsPrtSelfCarton As String = "N"     '是否在系统里面打印外箱
    Dim CODERULEID As String = ""           '外箱编码原则
    Dim IsScanN As String = "N"             '是否扫描多次
    Dim ScanNumber As Integer = 1           '扫描次数
    Dim LastScanIndex As Integer = 0        '上一次扫描序号 hgd 20170828
    Dim IsTrunk As String = "N"             '田玉琳 20160419
    Dim IsHaveChildCode As String = "N"     '田玉琳 20161102
    Dim IsEquipmentLifeCheck As String = "N"  '魏莎 20161025，是否冶具寿命卡控
    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Dim PackArray As New SysMessageClass.PrtStructure
    Dim printscanPPid As String = String.Empty
    Public scanSetting As New ScanSetting
    Private okWavPlayTime As Integer = 700      '正确声音播放时间
    Private ngWavPlayTime As Integer = 2000     '错误声音播放时间
    Dim frmBoard As FrmProductionBoard          '看板窗体（可多次打开）

    '--自定义校验条码数量和内容
    Dim CheckCurIndex As Integer = 0
    Dim paraArrays As String()      '校验参数
    Dim IsRepeatStyleC As String = "N"
    Dim ssStartindex As Integer     '流水起始位置 田玉琳 2017014
    Dim ssStartLength As Integer    '流水起始长度 田玉琳 2017014
    Dim strIsCharacters As String


    Dim CheckCartonCurIndex As Integer = 0
    Dim paraCartonArrays As String()      '箱条码校验参数
    Dim iCartonStartindex As Integer     '
    Dim iCartonStartLength As Integer    '

#End Region

#Region "窗體事件"
    '快捷键
    Private Sub FrmWorkStantScan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                BnScanSet_Click(sender, e)
            Case Keys.F10 '快捷键F10
                ' OpenProductionBoard()
            Case Keys.Alt + Keys.X
                Me.Close()
        End Select

    End Sub

    '初期化
    Private Sub FrmBarScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btApp = New BarTender.ApplicationClass

        TxtBarCode.Enabled = False
        LblMainBarCode.Text = ""
        LabResult.Text = ""
        lblMessage.Text = "请设置扫描资料"
        ToolUsename.Text = SysMessageClass.UseName
        txt_tmpbarcode.Text = ""

        '设置播放声音时间参数
        SetWavPlayTime()
    End Sub

    '掃描設置
    Private Sub BnScanSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolScanSet.Click
        Dim strSQL As String = ""
        Try
            Me.TxtCartonID.Text = String.Empty
            Me.ActiveControl = Me.TxtCartonID

            lblMessage.Text = "请扫描箱号..."


            Dim o_dt As New DataTable
            o_dt = CType(DGridBarCode.DataSource, DataTable)
            If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                o_dt.Rows.Clear()
            End If
            DGridBarCode.DataSource = o_dt

        Catch ex As Exception
            scanSetting.MoidStr = ""
            TxtMoId.Text = String.Empty
            TxtPartid.Text = String.Empty
            TxtPartid.Text = String.Empty
            TxtPackFullQty.Text = String.Empty
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "设置扫描参数异常,请重新设置"
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#{1}", Me.TxtMoId.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmOutOfBoxCheck", "BnScanSet_Click", "sys")
        End Try
    End Sub
    ''' <summary>
    ''' 判断是否存在异常解锁情况
    ''' </summary>
    ''' <returns>返回发生异常解锁的条码</returns>
    ''' <remarks></remarks>
    Private Function CheckErrLockData() As DataTable
        Dim moid As String = IIf(scanSetting.MoidStr Is Nothing, "", scanSetting.MoidStr)
        Dim lineid As String = IIf(scanSetting.LineStr Is Nothing, "", scanSetting.LineStr)
        Dim Stationid As String = IIf(scanSetting.vStandId Is Nothing, "", scanSetting.vStandId)
        Dim sqlstr As StringBuilder = New StringBuilder
        sqlstr.Append("select ppid,Errordest from m_AssysnE_t WHERE  Userid='" & VbCommClass.VbCommClass.UseId & "' and spoint='" & My.Computer.Name & "' and Moid='" & moid & "' and Teamid='" & lineid & "' and Stationid='" & Stationid & "' and Intime>CONVERT(varchar(10),getdate(),23)  and isnull(Solvetime,'')='' ")
        Return DbOperateUtils.GetDataTable(sqlstr.ToString)
    End Function
    '记录辅助线扫描的设置线别信息,cq 20170221
    Private Sub RecordLineInfo()
        Try
            Dim strSQL As New StringBuilder
            strSQL.Append(" DECLARE @RTVALUE varchar(10), @strmsgText varchar(50) ")
            strSQL.Append(" EXECUTE [m_AutoScanRecordLine_P] '" & Trim(TxtMoId.Text) & "', '" & TxtPackFullQty.Text.Trim & "',  ")
            strSQL.Append(" '" & My.Computer.Name & "', '" & VbCommClass.VbCommClass.UseId & "',@RTVALUE OUTPUT, @strmsgText OUTPUT ")
            strSQL.Append(" SELECT @RTVALUE,@strmsgText")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        SysMessageClass.WriteErrLog(dt.Rows(0)(1), "FrmNewStantPackScan", "RecordLineInfo", "BarCodeScan")
                    Case "1"
                        'OK
                    Case Else
                        'do nothing
                End Select
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmNewStantPackScan", "RecordLineInfo", "BarCodeScan")
        End Try
    End Sub

    '退出
    Private Sub BnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '条码扫描事件
    Private Sub TxtBarCode_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TxtBarCode.PreviewKeyDown
        If (String.IsNullOrEmpty(Me.TxtCartonID.Text)) Then
            lblMessage.Text = "请先扫描箱条码！"
            Me.TxtBarCode.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If e.KeyValue = 13 Then
            StandScan()
        End If
    End Sub

    '箱号输入后事件
    Private Sub TxtCartonID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCartonID.KeyPress
        If e.KeyChar = Chr(13) Then
            CartonIDScanHandle()
        End If
    End Sub

    Private Sub ToolReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TxtPartid.Text = "" Then
            SetMessage("Fail", "扫描资料未设置...")
            Exit Sub
        End If


        Try
            Dim frm As New FrmBarCodeReplace()
            frm.Moid = TxtMoId.Text.Trim
            frm.PartId = TxtPartid.Text.Trim
            frm.LabelNum = scanSetting.LabelNum
            frm.ShowDialog()

        Catch ex As Exception
            lblMessage.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmNewStantPackScan", "ToolReplace_Click", "sys")
            Exit Sub
        End Try
    End Sub

    Private Sub FrmStantPackScan_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
        DisposeData()
        scanSetting.CustIdString = Nothing
        scanSetting.MoidStr = Nothing
        scanSetting.LengthStr = Nothing
        scanSetting.DateCheck = Nothing
    End Sub

#End Region

#Region "獲取掃描检查記錄"
    '扫描
    Private Sub GetScanItem(ByVal Cartonid As String)
        Dim strSQL As String = "SELECT  moid.PartID AS ppartid, ppLink.StaOrderid AS staorderid, ppLink.ScanOrderid AS scanorderid, " &
        "   ppLink.ppid,moid.PartID AS tparttext,CartonSn.Userid AS username,CartonSn.intime " &
        "   FROM m_Cartonsn_t CartonSn INNER JOIN m_Carton_t carton ON carton.Cartonid=CartonSn.Cartonid  " &
        "   INNER JOIN  m_Ppidlink_t ppLink on ppLink.Exppid = CartonSn.ppid" &
        "   INNER JOIN m_Mainmo_t moid ON moid.Moid=carton.Moid WHERE CartonSn.Cartonid='{0}' " &
        "   ORDER BY ppLink.intime desc ,ppLink.ScanOrderid"

        strSQL = String.Format(strSQL, Cartonid)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Dim orderIndex As Integer = 0
        DGridBarCode.Rows.Clear()
        For iIndex As Integer = 0 To dt.Rows.Count - 1
            DGridBarCode.Rows.Add(dt.Rows(iIndex)!ppartid, dt.Rows(iIndex)!staorderid,
                                  dt.Rows(iIndex)!Ppid, dt.Rows(iIndex)!tparttext,
                                  dt.Rows(iIndex)!username, dt.Rows(iIndex)!intime)
        Next

        strSQL = "select COUNT(1) from m_RPartStationD_t where PPartid = '{0}' and State = 1"
        'add by hgd 2017-09-05 箱包装多个站需要加上工站条件
        If scanSetting.vPackType = "Y" And scanSetting.vStandMaxStaIndex > 1 Then
            strSQL = strSQL & " and Stationid='" & scanSetting.vStandId & "'"
        End If
        strSQL = String.Format(strSQL, TxtPartid.Text)
        Dim dt2 As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If CInt(dt2.Rows(0)(0)) > 1 Then
            If dt.Rows.Count > 0 Then
                '如果只是扫描主条码中断后，再次进入扫描时，设置主条码，再扫次条码
                If dt.Rows(0)!scanorderid = "1" Then
                    LblMainBarCode.Text = dt.Rows(0)!Ppid.ToString
                    orderIndex = dt.Rows(0)!staorderid.ToString
                End If
            End If
        End If

        DGridBarCode.AutoResizeColumns()

    End Sub

    '取得数据确认是否是有子条码
    Private Sub IsChildCode()
        IsHaveChildCode = "N"

        '如果没有设置工单退出 
        If scanSetting.vStandId Is Nothing Then Exit Sub

        Dim strSQL As String
        strSQL = "select COUNT(1) from m_RPartStationD_t where PPartid = '{0}' and Stationid = '{1}' and State = 1 "
        strSQL = String.Format(strSQL, TxtPartid.Text.Trim, scanSetting.vStandId.Trim)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If CInt(dt.Rows(0)(0)) > 1 Then
            IsHaveChildCode = "Y"
        End If
    End Sub

#End Region

#Region "條碼掃描"

    Private Sub StandScan()

        If InStr(TxtBarCode.Text, "'") Then
            TxtBarCode.Clear()
            Exit Sub
        End If

        Dim BarCodeOriginal As String = TxtBarCode.Text
        'LblPackQty 应装产品  实装 LblCurrQty ,LblCartonQty(应装箱数)  已装箱LblCurrCarQty
        Dim BarCode As String = Trim(TxtBarCode.Text).Replace(vbNewLine, "")

        If Me.TxtMoId.Text = "" Then
            WorkStantOption.ErrorStr = "請先設置好掃描基本信息！"
            SetMessage("Fail", "請先設置好掃描基本信息!")
            WorkStantOption.BarCodeStr = BarCode
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        If BarCode = "" Then
            WorkStantOption.ErrorStr = "產品條碼不能為空！"
            SetMessage("Fail", "產品條碼不能為空!")
            WorkStantOption.BarCodeStr = BarCode
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        Dim Sqlstr As String = String.Empty

        '@PPID         VARCHAR(150),			--產品條碼                                                         
        '@MO_ID         VARCHAR(64),			--工單編號                                                                                                             
        '@SPOINT       VARCHAR(30),			--電腦名                                                         
        '@USER_ID	VARCHAR(10),			--用戶名                                                                                                                                                                                                                                                  
        '@CARTON_ID    VARCHAR(150),			--外箱條碼                                  
        '@FACT_QUANTITY      INT,			--外箱條碼應裝數量    
        '@RTVALUE    VARCHAR(1) OUTPUT,		--錯誤信息編號               
        '@RTMSG   NVARCHAR(150) OUTPUT,		--錯誤信息内容                                                  
        '@RTCURR_QUANTITY  INT OUTPUT,		--已检查ok數量      
        '@OUTPPID NVARCHAR(64) OUTPUT                                   
        Try

            Sqlstr = " DECLARE @strmsgid varchar(1), @strmsgText varchar(150), @currqty int, @currPqty int, @OutPQty int, @outPPID nvarchar(64) " & _
                     " EXECUTE [m_CheckOutOfBoxBarCode_P] '" & Trim(BarCode) & "'," & _
                        "'" & Trim(TxtMoId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & _
                        "'" & Me.TxtCartonID.Text.Trim & "'," & _
                        "'" & Me.TxtPackFullQty.Text & "'," & _
                        "@strmsgid output,@strmsgText output, @OutPQty output ,@OutPPID output " & _
                        "SELECT @strmsgid,@strmsgText, isnull(@OutPQty,0) as outPQty,@OutPPID as PPID"

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
                    Case "4" ''---掃描成功
                        PlaySimpleSound(0)
                        SetMessage("PASS", "扫描成功...")
                        '@OutPPID       
                        TxtBarCode.Text = dt.Rows(0).Item("PPID").ToString
                        Me.LblCurrCheckedQty.Text = dt.Rows(0).Item("outPQty").ToString
                        Me.DGridBarCode.Rows.Insert(0, TxtBarCode.Text, "1.PASS", SysMessageClass.UseId, Now())

                        If DGridBarCode.Rows.Count > 10 Then
                            DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
                        End If

                        TxtBarCode.Clear()
                        TxtBarCode.Focus()
                    Case "6"
                        'do nothing
                End Select
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            MessageUtils.ShowInformation(ex.ToString)
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, TxtBarCode.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmOutOfBoxCheck", "StandScan", "sys")
        End Try
    End Sub

    Private Sub CartonIDScanHandle()
        Dim Sqlstr As String = String.Empty

        If Me.TxtCartonID.Text = "" Then
            WorkStantOption.ErrorStr = "箱號條碼序號不能為空"
            SetMessage("Fail", "箱號條碼序號不能為空")
            WorkStantOption.BarCodeStr = TxtCartonID.Text
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtCartonID.Text = ""
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        'A, get Base Info
        If Not GetMOInfoAndCheck() Then Exit Sub

        Dim BarCode As String = Trim(TxtCartonID.Text)

        Try

            '@MO_ID      VARCHAR(64),				--當前設置的工單                      
            '@CARTON_ID  VARCHAR(150),				--掃描的箱號                                                     
            '@USER_ID   VARCHAR(32),				--用戶ID
            '@RTVALUE     VARCHAR(1) OUTPUT,		--錯誤信息編號                       
            '@RTMSG   NVARCHAR(256) OUTPUT,			--錯誤信息内容                         
            '@RTQUANTITY       INT OUTPUT 		    --返回箱已检查數量    

            Sqlstr = "DECLARE @strmsgid varchar(1),@strmsgText varchar(50),@NewCartonid varchar(100),@qty int, @CheckedQty float " & _
                "EXECUTE [m_CheckOutOfBoxCarton_p] " & _
                "'" & Trim(scanSetting.MoidStr) & "','" & BarCode & "','" & SysMessageClass.UseId.Trim & "'," & _
                "@strmsgid output,@strmsgText output, @CheckedQty output " & _
                " SELECT @strmsgid ,isnull(@strmsgText,''), @CheckedQty "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "1" To "3"
                        WorkStantOption.ErrorStr = dt.Rows(0)(1).ToString()
                        SetMessage("FAIL", WorkStantOption.ErrorStr)
                        WorkStantOption.BarCodeStr = Trim(TxtCartonID.Text)
                        WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                        ShowFrmScanErrPrompt()
                        SetMessage("PASS", "已解锁，请继续进行作业")
                        Me.TxtCartonID.Focus()
                        Me.TxtCartonID.Clear()
                        PlaySimpleSound(1)
                        Exit Sub
                    Case "4"
                        PlaySimpleSound(0)
                        DGridBarCode.Rows.Clear()
                        'SetGridHeadColumn()
                        ' LblPackQty.Text = ""
                        LblCurrCheckedQty.Text = ""
                        Me.LblCurrCheckedQty.Text = 0
                        SetMessage("PASS", "外箱扫描成功,请继续刷入产品条码检查...")
                        ' ControlState(True)
                        LoadCheckedList() '更新显示第几箱
                        Me.TxtBarCode.Enabled = True
                        Me.ActiveControl = Me.TxtBarCode
                        Me.TxtBarCode.Focus()
                End Select
            Else
                WorkStantOption.ErrorStr = "系统无法识别此外箱标签序号"
                SetMessage("Fail", "系统无法识别此外箱标签序号")
                WorkStantOption.BarCodeStr = TxtCartonID.Text
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                TxtCartonID.Text = ""
                Me.TxtCartonID.Focus()
                PlaySimpleSound(1)
                Exit Sub
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            MessageUtils.ShowInformation("有异常发生，请联系管理员!异常信息：" + ex.ToString)
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, TxtCartonID.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmOutOfBoxCheck", "CartonIDScanHandle", "sys")
            Exit Sub
        End Try
    End Sub

#End Region

#Region "方法"
    Private Function GetMOInfoAndCheck() As Boolean
        GetMOInfoAndCheck = True

        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT a.CARTONID,a.CartonStatus,a.MOID,b.PartID,a.PackingQuantity  " & _
                " FROM m_carton_t a LEFT JOIN dbo.m_Mainmo_t b ON a.moid = b.moid" & _
                " WHERE Cartonid ='" & Me.TxtCartonID.Text.Trim & "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
        If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
            Me.TxtPackFullQty.Text = dt.Rows(0).Item("PackingQuantity")
            Me.TxtMoId.Text = dt.Rows(0).Item("MOID")
            Me.TxtPartid.Text = dt.Rows(0).Item("PartID")
        Else
            GetMOInfoAndCheck = False

            SetMessage("FAIL", Me.TxtCartonID.Text.Trim & Space(3) & "请检查该箱号是否正确！")
            Me.TxtCartonID.Text = ""
            Me.ActiveControl = Me.TxtCartonID
        End If

    End Function


    '条码验证样式
    Private Function CheckStyleC(ByRef BarCode As String) As Boolean

        '********************************20170323 田玉琳 Start --------------
        '增加对验证条码流水和唯一性处理
        If IsRepeatStyleC = "Y" Then
            If txt_tmpbarcode.Text = "" Then
                txt_tmpbarcode.Text = TxtCartonID.Text
                SetMessage("PASS", BarCode & Space(3) & "扫描成品箱条码成功，请继续扫描箱校验条码！")
                TxtCartonID.Clear()
                TxtCartonID.Focus()
                Return False
            Else
                If TxtCartonID.Text <> txt_tmpbarcode.Text Then
                    SetFailContent(BarCode, "校验码" & "{" & BarCode & "}校验不成功...Fail,请重新验证")
                    Return False
                End If
            End If
            txt_tmpbarcode.Text = ""
        End If
        '---------  20170323 田玉琳 End  ---------
        Return True
    End Function

    '检查是否存在重复数据
    Private Function CheckppidIsRepeat(ppid As String) As Boolean
        Dim strSQL As String = "select 1 as cnt from m_AssysnCheck_t where ppid = '{0}' and SCANY = 'Y'"
        strSQL = String.Format(strSQL, ppid)
        Dim count As Integer = DbOperateUtils.GetRowsCount(strSQL)
        '存在数据返回错误
        If count > 0 Then
            Return False
        End If
        Return True
    End Function


    '设置错误信息内容
    Private Sub SetFailContent(BarCode As String, errMsg As String)
        WorkStantOption.BarCodeStr = BarCode
        WorkStantOption.vMainBarCode = Me.TxtBarCode.Text
        WorkStantOption.ErrorStr = errMsg
        SetMessage("FAIL", errMsg)
        ShowFrmScanErrPrompt()
        If WorkStantOption.vDeserTionFlag = True Then
            TxtBarCode.Clear()
            WorkStantOption.vCurrentStandIndex = 1
            ' TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
            ' TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
            LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
        End If
        TxtBarCode.Text = ""
        Me.TxtBarCode.Focus()
    End Sub


    ''' <summary>
    '''显示已经开箱检查的记录列表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadCheckedList()
        Dim lsSQL As String = String.Empty
        Try
            lsSQL = " SELECT PPID,Cartonid,Userid, (CASE  Result WHEN 1 THEN '1.PASS' WHEN 0 THEN '0.NG' ELSE '0.NG' End) Result ,Intime FROM dbo.m_CartonOutCheckD_t " & _
                    " WHERE cartonid ='" & Me.TxtCartonID.Text.Trim & "' "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)

            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    DGridBarCode.Rows.Add(dr.Item("PPID"), dr.Item("Result"), dr.Item("Userid"), dr.Item("Intime"))
                Next

                Me.LblCurrCheckedQty.Text = dt.Rows.Count.ToString
            End If

            DGridBarCode.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ControlState(ByVal BorC As Boolean)

        If BorC Then
            TxtCartonID.Enabled = False
            TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
            'TxtCartonID.BackColor = Color.White
            If IsReadSn = "Y" Then
                Me.TxtBarCode.WordWrap = True
                Me.TxtBarCode.Multiline = True
            End If
            TxtBarCode.Enabled = True
            TxtBarCode.BackColor = Color.White
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            ' SetScanCodeStyle("S")
        Else
            If TgenCarton = "N" Then
                TxtCartonID.Enabled = True
                TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
                'TxtBarCode.BorderColor = Color.FromArgb(209, 31, 73)
                TxtBarCode.Enabled = False
                'TxtBarCode.BackColor = Color.FromArgb(246, 252, 255)
                ''TxtCartonID.BackColor = Color.White
                If scanSetting.vCurrentStandIndex = 1 Then
                    TxtCartonID.Text = ""
                End If

                Me.TxtCartonID.Focus()
                'SetScanCodeStyle("C")
                If IsReadSn = "Y" Then
                    Me.TxtBarCode.WordWrap = True
                    Me.TxtBarCode.Multiline = True
                End If
            Else
                TxtCartonID.Enabled = False
                TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
                'TxtCartonID.BackColor = Color.White
                If IsReadSn = "Y" Then
                    Me.TxtBarCode.WordWrap = True
                    Me.TxtBarCode.Multiline = True
                End If
                TxtCartonID.Text = "GeneratePalletNo"
                TxtBarCode.Enabled = True
                TxtBarCode.BackColor = Color.White
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                ' SetScanCodeStyle("C")
            End If
        End If
    End Sub

    Private Sub ControlState(ByVal BorC As Boolean, ByVal isScanPallet As Boolean)
        If BorC Then
            TxtCartonID.Enabled = False
            TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
            TxtCartonID.BackColor = Color.White
            TxtBarCode.Enabled = True
            TxtBarCode.BackColor = Color.White
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
        Else

            TxtCartonID.Enabled = True
            TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
            TxtBarCode.Enabled = False
            TxtBarCode.Enabled = False
            TxtBarCode.BackColor = Color.FromArgb(246, 252, 255)
            ''TxtCartonID.BackColor = Color.White
            TxtCartonID.Text = ""
            TxtBarCode.Text = ""
            Me.TxtCartonID.Focus()
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

    Private Sub ShowFrmScanErrPrompt()
        Dim FrmError As New FrmScanErrPrompt(scanSetting)
        FrmError.ShowDialog()
    End Sub


    '系统打印箱样式取得
    Private Function GetIsSelfCarton() As Boolean
        Dim strSQL As String = " select CodeRuleID  from m_partpack_t " &
                               " where  partid='{0}' and usey='Y'  and (DisorderTypeId = 'C' and Packid = 'N' or Packid = 'C') "
        strSQL = String.Format(strSQL, TxtPartid.Text)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Dim ruleID As String = dt.Rows(0)(0).ToString
            ' SetCartonStyle(ruleID)
            Return True
        Else
            Return False
        End If
    End Function

    '执行扫描数据LOG
    Private Sub SetScanLog(ppid As String, type As String)
        Dim strSQL As String = " EXEC [Exec_InsertLogInfo] '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}' "
        strSQL = String.Format(strSQL, ppid, Trim(TxtMoId.Text), Trim(TxtPackFullQty.Text), VbCommClass.VbCommClass.UseId, My.Computer.Name,
                               VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, type)
        DbOperateUtils.GetDataTable(strSQL)
    End Sub

#Region "聲音播放"

    '取得声音播放参数 
    Private Sub SetWavPlayTime()
        Dim result As String = ""
        Dim strSQL As String = "select TEXT from m_BaseData_t where [ITEMKEY] = '{0}' "
        strSQL = String.Format(strSQL, "WavPlayTime")

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            okWavPlayTime = dt.Rows(0)(0).ToString
            ngWavPlayTime = dt.Rows(1)(0).ToString
        Else
            okWavPlayTime = 700
            ngWavPlayTime = 2000
        End If
    End Sub

    Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        If (Me.chbMessage.Checked) Then
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
#End Region

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