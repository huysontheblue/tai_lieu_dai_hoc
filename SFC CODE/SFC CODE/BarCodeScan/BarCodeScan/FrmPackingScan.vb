#Region "Imports"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports BarCodeScan.Data
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports BarCodePrint
'Imports System.Windows.Forms.DataFormats


#End Region

Public Class FrmPackingScan


#Region "窗體變量"

    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim LocalData As New BarCodeScan.Data
    Dim IsCustPart As Boolean
    Dim IsPrtPacking As Boolean
    Dim IsScanPallet As Boolean
    Dim PalletID As String
    Dim IsFull As Boolean = False '棧板是否裝滿
    Dim IsLinePrint As String = "N" ''是否在线打印产品条码
    Dim IsReadSn As String = "N" ''''是否读取序号
    Dim TgenCarton As String = "N" ''''自动生面外箱
    Dim IsPackingPPID As String = "N"     '是否产品序号相同（允许箱产品同包装）
    Dim IsPackType As String = "N"       '包装类型
    Dim btApp As BarTender.Application

    'Declare a BarTender format variable 

    Dim btFormat As New BarTender.Format

    Dim PackArray As New SysMessageClass.PrtStructure
    'Instantiate the BarTender application variable 



    'Private Shared engine As Seagull.BarTender.Print.Engine = Nothing ' T
    ''Private Shared engine As Seagull.BarTender.Print.Engine = Nothing ' The BarTender Print Engine
    'Private Shared format As LabelFormatDocument = Nothing ' The currently open Format
    'Private Const appName As String = "Label Print"
    'Private Const dataSourced As String = "Data Sourced"

#End Region

#Region "窗體事件"

    'Private Sub FrmInCarton_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    DisposeData()
    '    WorkStantOption.CustIdString = Nothing
    '    WorkStantOption.MoidStr = Nothing
    '    WorkStantOption.LengthStr = Nothing
    '    WorkStantOption.DateCheck = Nothing
    'End Sub

    Private Sub FrmWorkStantScan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                BnScanSet_Click(sender, e)
                ''Case Keys.F2
                ''    toolCa_Click(sender, e)
            Case Keys.Alt + Keys.X
                Me.Close()
        End Select

    End Sub


    'Private Sub FrmWorkStantScan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    ''ToolUsename.Text=SysMessageClasss.UseName
    'End Sub


    Private Sub FrmBarScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        btApp = New BarTender.ApplicationClass

        'engine = New Engine(True)
        'SetGridHeadColumn()
        'Me.TxtBarCode.Focus()
        TxtBarCode.Enabled = False
        'TxtBarCode.BackColor = Color.FromArgb(246, 252, 255)
        LblMainBarCode.Text = ""
        LabResult.Text = ""
        lblMessage.Text = "请设置扫描资料"
        'TxtBarCode.Enabled = False
        'TxtCartonScan.Enabled = False
        'LblPackQty.Text = ""
        ToolUsename.Text = SysMessageClass.UseName
        ''''''''''''''''''''2008/04/01 
        'Me.LblType.Visible = False
        '''''''''''''''''''''''''''''''''''''

        'My.Computer.FileSystem.DeleteFile("C:\WINNT\Media\ding.wav", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)

    End Sub

#End Region

#Region "掃描設置/返回按鈕事件"

    Private Sub BnScanSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolScanSet.Click

        Dim CountReader As SqlDataReader
        'Dim DtGetCarton As DataTable
        WorkStantOption.FormName = Me.Name
        If LblMainBarCode.Text.Trim <> "" Then
            'PlaySimpleSound(1)
            MessageBox.Show("該站點對應的次條碼未掃描完整,不能再設置!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            Dim FrmOpenLock As New FrmSetLock
            FrmShareSetForm.vStationType = "P"
            FrmOpenLock.ShowDialog()


            If CartonScanOption.CheckStr = True Then
                'Application.EnableVisualStyles()
                Dim FrmScanSet As New FrmShareSetForm
                FrmScanSet.ShowDialog()

                If WorkStantOption.IsExitFlag = True Then Exit Sub


                Me.LblCartonQty.Text = "0"
                Me.LblCurrCarQty.Text = "0"
                Me.LblPackQty.Text = "0"
                Me.LblCurrQty.Text = "0"
                'LblPackQty 应装产品  实装 LblCurrQty
                'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                TxtBarCode.Focus()
                IsScanPallet = WorkStantOption.ScanPalletCheck ''是否掃描棧板
                IsCustPart = WorkStantOption.CustPartCheck ''是否核對客戶料號
                IsPrtPacking = WorkStantOption.PrtPackingCheck '是否在线打印外箱号
                DGridBarCode.DataSource = Nothing

                TxtMoId.Text = WorkStantOption.MoidStr           ''工單
                TxtSitName.Text = WorkStantOption.vStandId & WorkStantOption.vStandName    ''工單數量
                ''LabCust.Text = WorkStantOption.CustStr ''工單類型
                TxtPartid.Text = WorkStantOption.PartidStr ''料件編號
                '' LabMoCust.Text = WorkStantOption.MoCustStr ''客戶料號
                TxtLineId.Text = WorkStantOption.LineStr ''線別
                'LblTime.Text = WorkStantOption.TimeStr ''掃描開始時間
                'LabCartonQty.Text = WorkStantOption.PartPackQty
                'TxtSnStyle1.Text = WorkStantOption.SnStyleStr1
                'TxtSnStyle2.Text = WorkStantOption.SnStyleStr2
                'Me.TxtBarCode.MaxLength = WorkStantOption.LengthStr
                lblMessage.Text = "扫描资料设置完成"
                WorkStantOption.vCurrentStandIndex = 1
                TxtSnStyle1.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 0)
                TxtSnStyle2.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 1)
                LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
                'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 2)
                ControlState(False)
                If WorkStantOption.PrtPackingCheck Then
                    btFormat = btApp.Formats.Open("D:\PrintFile\RPrintFile\LA06US573-4H.btw", False, String.Empty)
                End If

                CountReader = Conn.GetDataReader("select isnull(IslineMbarcode,'N') IslineMbarcode,isnull(IsUsb,'N') IsUsb,isnull(LinePrtY,'N') LinePrtY,isnull(IsAllowRe,'N') as IsProductSame, isnull(IsPackType,'N') as IsPackType from m_RPartStationD_t where PPartid='" & TxtPartid.Text & "' and TPartid='" & TxtPartid.Text & "' and Stationid='" & WorkStantOption.vStandId & "'  and State='1'")
                If CountReader.HasRows Then
                    While CountReader.Read
                        IsLinePrint = CountReader!IslineMbarcode
                        IsReadSn = CountReader!IsUsb
                        IsPackingPPID = CountReader!IsProductSame
                        IsPackType = CountReader!IsPackType
                        TgenCarton = CountReader!LinePrtY
                        'Me.TxtBarCode.Multiline = True
                    End While
                End If
                CountReader.Close()
                Conn.PubConnection.Close()
                If IsLinePrint = "Y" Then
                    ChkLinePrint.Checked = True
                End If
                ''''  IsUsb成品是否读取usb序号
                ''  LblType.Text = WorkStantOption.moType
                If Not IsScanPallet Then
                    PnlPallet.Visible = False
                    '''''''獲取未裝滿外箱
                    If WorkStantOption.vCartonSame = "Y" Then
                        CountReader = Conn.GetDataReader("select a.Cartonid,a.cartonqty,b.qty from M_Carton_t a join m_SnSBarCode_t b on rtrim(replace(a.cartonid,right(a.cartonid,8),''))=b.sbarcode where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc")
                    Else
                        CountReader = Conn.GetDataReader("select a.Cartonid,a.cartonqty,b.qty from M_Carton_t a join m_SnSBarCode_t b on a.cartonid=b.sbarcode where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc")
                    End If

                    If CountReader.HasRows Then
                        CountReader.Read()
                        TxtCartonID.Text = CountReader("Cartonid").ToString
                        LblPackQty.Text = CountReader("qty").ToString
                        Me.LblCurrQty.Text = CountReader("cartonqty").ToString
                        CountReader.Close()
                        GetScanItem(Me.TxtCartonID.Text)
                        ControlState(True)
                    Else
                        CountReader.Close()
                        Conn.PubConnection.Close()
                        If WorkStantOption.PrtPackingCheck Then

                            Me.TxtCartonID.Text = CartonPrint()
                            LblPackQty.Text = WorkStantOption.PartPackQty
                            Me.LblCurrQty.Text = WorkStantOption.NowCartonScanQty
                            CartonIDScanHandle()
                            ControlState(True)
                        Else
                            ControlState(False)

                        End If
                    End If

                    ''獲取未裝滿主條碼 

                    'CountReader = Conn.GetDataReader("select ppid from  M_Assysn_t  where Moid='" & Me.TxtMoId.Text.Trim & "' and Teamid='" & Me.TxtLineId.Text.Trim & "' and Stationid='" & WorkStantOption.vStandId & "' and Estateid='F' order by Intime desc")
                    'If CountReader.HasRows Then
                    '    CountReader.Read()
                    '    LblMainBarCode.Text = CountReader("ppid").ToString
                    '    CountReader.Close()
                    '    GetScanItem(Me.LblMainBarCode.Text)
                    'Else
                    '    ''WorkStantOption.vStandId = 1
                    '    CountReader.Close()
                    '    '' ControlState(False)
                    'End If
                    'CountReader.Close()
                Else
                    PnlPallet.Visible = True
                    '''''''獲取未裝滿棧板
                    'LblPackQty 应装产品  实装 LblCurrQty
                    'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                    CountReader = Conn.GetDataReader("select Palletid, MultiQty,Palletqty from M_PalletM_t where  Moid='" & Me.TxtMoId.Text.Trim & "' and Teamid='" & Me.TxtLineId.Text.Trim & "'   and PalletStatus='N' ")
                    If CountReader.HasRows Then
                        TxtPalletID.Enabled = False
                        CountReader.Read()
                        TxtPalletID.Text = CountReader("Palletid").ToString
                        LblCartonQty.Text = CountReader("MultiQty").ToString
                        Me.LblCurrCarQty.Text = (Convert.ToInt32(CountReader("Palletqty").ToString)).ToString
                        CountReader.Close()
                        TxtPalletID.Enabled = False
                        'TxtPalletID.BorderColor = Color.FromArgb(35, 130, 196)

                        '''''''獲取未裝滿外箱
                        Dim Ncarton As Boolean = False
                        If WorkStantOption.vCartonSame = "Y" Then
                            CountReader = Conn.GetDataReader("select a.Cartonid,a.cartonqty,b.qty from M_Carton_t a join m_SnSBarCode_t b on rtrim(replace(a.cartonid,right(a.cartonid,8),''))=b.sbarcode where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc")
                        Else
                            CountReader = Conn.GetDataReader("select a.Cartonid,a.cartonqty,b.qty from M_Carton_t a join m_SnSBarCode_t b on a.cartonid=b.sbarcode where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc")
                        End If

                        If CountReader.HasRows Then
                            Ncarton = True
                            CountReader.Read()
                            TxtCartonID.Text = CountReader("Cartonid").ToString
                            LblPackQty.Text = CountReader("qty").ToString
                            Me.LblCurrQty.Text = CountReader("cartonqty").ToString
                            CountReader.Close()
                            GetScanItem(Me.TxtCartonID.Text)
                            ControlState(True)
                        Else
                            CountReader.Close()
                            ControlState(False)
                        End If
                        CountReader.Close()
                        Conn.PubConnection.Close()
                        ''獲取未裝滿主條碼  'LblPackQty 应装产品  实装 LblCurrQty
                        'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                        'If Ncarton = True Then
                        '    CountReader = Conn.GetDataReader("select ppid from  M_Assysn_t  where Moid='" & Me.TxtMoId.Text.Trim & "' and Teamid='" & Me.TxtLineId.Text.Trim & "' and Stationid='" & WorkStantOption.vStandId & "' and Estateid='F' order by Intime desc")
                        '    If CountReader.HasRows Then
                        '        CountReader.Read()
                        '        LblMainBarCode.Text = CountReader("ppid").ToString
                        '        CountReader.Close()
                        '        GetScanItem(Me.LblMainBarCode.Text)
                        '    Else
                        '        ''WorkStantOption.vStandId = 1
                        '        CountReader.Close()
                        '        '' ControlState(False)
                        '    End If
                        '    CountReader.Close()
                        'End If
                    Else
                        CountReader.Close()
                        Conn.PubConnection.Close()
                        TxtPalletID.Enabled = True
                        TxtCartonID.Enabled = False
                        TxtPalletID.Focus()
                        'TxtPalletID.BorderColor = Color.FromArgb(246, 252, 255)
                        'TxtCartonID.BackColor = Color.White
                    End If
                End If

                'CountReader = Conn.GetDataReader("select max(scanorderid) maxid from m_RPartStationM_t where Stationid='" & TxtSitName.Text & "' and ppartid='" & TxtPartid.Text & "' order by a.Intime desc")
                'While CountReader.Read
                '    WorkStantOption.vStandMaxStaIndex = CountReader!maxid
                'End While
                'CountReader.Close()
            End If
            WorkStantOption.CheckStr = False
            LoadPalletPaceQty()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmInCarton", "GetScanItem", "sys")
            Exit Sub
            'Finally
            '    DisposeData()
        End Try

    End Sub

    Private Sub LoadPalletPaceQty()

        ''  Dim PalletStr As String = String.Empty
        Dim dt As DataTable = Conn.GetDataTable(" select isnull(count(Cartonid),0) packcount from m_carton_t where moid='" & Me.TxtMoId.Text & "' and cartonstatus<>'E' ")

        If dt.Rows.Count > 0 Then
            LabCartonQty.Text = dt.Rows(0)("packcount").ToString
        End If
        Conn.PubConnection.Close()
    End Sub
    'Private Sub ControlState(ByVal BorC As Boolean)
    '    'Dim value As Color
    '    'If BorC Then
    '    '    TxtBarCode.Enabled = True
    '    '    BtEnter.Enabled = True
    '    '    TxtCartonScan.Enabled = False
    '    '    BtCatronScan.Enabled = False
    '    '    value = TxtColor.BackColor
    '    '    TxtBarCode.BackColor = value
    '    '    Me.TxtCartonScan.BackColor = Color.White
    '    '    TxtBarCode.Text = ""
    '    '    Me.TxtBarCode.Focus()
    '    'Else
    '    '    TxtBarCode.Enabled = False
    '    '    BtEnter.Enabled = False
    '    '    TxtCartonScan.Enabled = True
    '    '    BtCatronScan.Enabled = True
    '    '    value = TxtColor.BackColor
    '    '    TxtCartonScan.BackColor = value
    '    '    Me.TxtBarCode.BackColor = Color.White
    '    '    TxtCartonScan.Text = ""
    '    '    Me.TxtCartonScan.Focus()
    '    'End If

    'End Sub

    Private Sub BnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        LocalData = Nothing
        Me.Close()
    End Sub

#End Region

    Private Sub DisposeData()
        WorkStantOption.PackNumber = Nothing
        WorkStantOption.BarCodeStr = Nothing
        WorkStantOption.DpetNameStr = Nothing
        WorkStantOption.ErrorStr = Nothing
        WorkStantOption.GflenStr = Nothing
        ' WorkStantOption.LengthStr = Nothing
        WorkStantOption.LineStr = Nothing
        WorkStantOption.MoCustStr = Nothing
        WorkStantOption.MoidqtyStr = Nothing
        'WorkStantOption.MoidStr = Nothing
        WorkStantOption.PartidStr = Nothing
        WorkStantOption.PartPackQty = Nothing
        WorkStantOption.PrintPort = Nothing
        WorkStantOption.SnidStr = Nothing
        WorkStantOption.SnStyleStr1 = Nothing
        WorkStantOption.SnStyleStr2 = Nothing
        WorkStantOption.TimeStr = Nothing
        WorkStantOption.CustStr = Nothing
        ''''''''''''''''
        WorkStantOption.moType = Nothing
        ''''''''''''''''''''''''''''''''''

        WorkStantOption.CustIdString = Nothing
        WorkStantOption.InCartonScanCheck = False

        WorkStantOption.vStandId = Nothing
        WorkStantOption.vStandName = Nothing
        WorkStantOption.vCurrentStandIndex = Nothing
        WorkStantOption.vStandMaxStaIndex = Nothing
        WorkStantOption.vTimeStyleSet = Nothing
        Array.Clear(WorkStantOption.vstyleArray, 0, WorkStantOption.vstyleArray.Length)
        WorkStantOption.vStandIndex = Nothing
        WorkStantOption.TimeStr = Nothing

    End Sub

#Region "獲取掃描記錄"
    Private Sub GetScanItem(ByVal Cartonid As String)


        Dim orderIndex As Integer = 0
        ''  Dim dateStr As String = String.Empty
        DGridBarCode.Rows.Clear()
        'SetGridHeadColumn()
        Dim Dt As SqlDataReader
        '"select b.ismainbarcode,a.scanorderid,a.Exppid,a.ppid,b.ppartid,b.staorderid,b.tparttext,a.userid,a.intime from m_Ppidlink_t a  join m_RPartStationD_t b on  b.scanorderid=a.scanorderid and a.StaOrderid=b.staorderid where" & _
        '" ppartid='" & WorkStantOption.PartidStr & "' and Exppid='" & Cartonid & "'  and b.staorderid='" & WorkStantOption.vStandIndex & "' and a.Usey='Y' and b.state='1' order by a.scanorderid")
        Dt = Conn.GetDataReader("SELECT m_Mainmo_t.PartID AS ppartid, 1 AS staorderid, 1 AS scanorderid,m_Cartonsn_t.ppid,m_Mainmo_t.PartID AS tparttext,m_Cartonsn_t.Userid AS username,m_Cartonsn_t.intime " & _
                       " FROM m_Cartonsn_t INNER JOIN m_SnSBarCode_t ON m_SnSBarCode_t.SBarCode=m_Cartonsn_t.ppid " & _
                    " INNER JOIN m_Mainmo_t ON m_Mainmo_t.Moid=m_SnSBarCode_t.Moid WHERE Cartonid='" & Cartonid & "' ORDER BY m_Cartonsn_t.intime DESC")
        'If Dt.HasRows() Then
        While (Dt.Read())
            DGridBarCode.Rows.Add(Dt!ppartid, Dt!staorderid, Dt!Ppid, Dt!tparttext, Dt!username, Dt!intime)
            If CInt(Dt!scanorderid) > orderIndex Then
                orderIndex = CInt(Dt!scanorderid)
            End If
            'If Dt!ismainbarcode = "Y" Then
            '    dateStr = Dt!intime
            'End If
        End While
        'End If

        'While PubDataReader.Read
        '    Me.CobLine.Items.Add(PubDataReader("lineid").ToString)
        'End While
        'If PubDataReader.Read Then
        ''Dt.NextResult()
        ''While (Dt.Read)
        ''    dateStr = DateDiff("d", dateStr, Dt!Datet)
        ''    If dateStr >= 1 Then
        ''        ToolMainBarcode.Visible = True
        ''    End If
        ''End While
        DGridBarCode.AutoResizeColumns()
        ''WorkStantOption.vCurrentStandIndex = DGridBarCode.Rows.Count + 1
        '' WorkStantOption.vCurrentStandIndex = orderIndex + 1
        Dt.Close()
        Dt.Dispose()
        Conn.PubConnection.Close()
        WorkStantOption.vCurrentStandIndex = IIf(WorkStantOption.vStandMaxStaIndex > orderIndex, orderIndex + 1, 1)
        TxtSnStyle1.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 0)
        TxtSnStyle2.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 1)
        'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 2)
        LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"


    End Sub

    ''Private Sub GetCartonScanItem()

    ''    Dim ChColsText As String
    ''    Dim DtCtScan As DataTable
    ''    Try
    ''        DGridBarCode.DataSource = Nothing
    ''        DtCtScan = Conn.GetDataTable("select * from m_Ppidlink_t where moid='" & Trim(TxtMoId.Text) & "' and teamid='" & Me.TxtLineId.Text & "' and intime >'" & TxtLineId.Text & "' order by intime desc ")
    ''        Me.DGridBarCode.DataSource = DtCtScan
    ''        '' Me.LabCartonQty.Text = DtCtScan.Rows.Count
    ''        If LCase(SysMessageClass.Language) = "english" Then
    ''            ChColsText = ""
    ''        Else
    ''            ChColsText = "裝箱序號|掃描人員|掃描時間"
    ''        End If
    ''        Dim colNames As String() = ChColsText.Split("|")
    ''        Dim i%
    ''        For i = 0 To DGridBarCode.Columns.Count - 1
    ''            DGridBarCode.Columns(i).HeaderText = colNames(i)
    ''            DGridBarCode.Columns(i).Name = colNames(i)
    ''        Next
    ''        DtCtScan = Nothing
    ''    Catch ex As Exception
    ''        SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmInCarton", "GetCartonScanItem", "sys")
    ''    End Try

    ''End Sub
#End Region



#Region "條碼掃描"

    Private Sub StandScan()

        Dim RecDr As SqlDataReader = Nothing
        Dim Sqlstr As String
        Dim BarCode As String


        '' Dim DecideFlag As Char
        ''''''''''''''''''''''

        If InStr(TxtBarCode.Text, "'") Then
            TxtBarCode.Clear()
            Exit Sub
        End If
        If IsScanPallet Then
            If LblCartonQty.Text = "0" Then
                lblMessage.Text = "栈板应装数量不能为0，设置有误..."
                TxtBarCode.Clear()
                PlaySimpleSound(1)
                Exit Sub
            End If
        End If
        If LblPackQty.Text = "0" Then
            If LblCartonQty.Text = "0" Then
                lblMessage.Text = "外箱应装数量不能为0，设置有误..."
                TxtBarCode.Clear()
                PlaySimpleSound(1)
            End If
        End If
        'LblPackQty 应装产品  实装 LblCurrQty
        'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
        BarCode = Trim(TxtBarCode.Text)
        'TxtBarCode.Text = ""
        Dim ReadSn As String = ""
        Dim E75sn As String = "" ''E75序号
        Dim E75Msg As String = "" ''E75序号内容
        If IsReadSn = "Y" Then

            If InStr(TxtBarCode.Text.ToLower, "accessory serial number:") <= 0 Then Exit Sub
            'If e.KeyChar <> Chr(13) Then Exit Sub
            Try

                For i As Integer = 0 To TxtBarCode.Lines.Length - 1
                    If InStr(TxtBarCode.Lines(i).ToString.ToLower, "module serial number:") > 0 Then
                        E75sn = TxtBarCode.Lines(i).ToString.Split(":")(1).Trim
                        Continue For
                    End If
                    If InStr(TxtBarCode.Lines(i).ToString.ToLower, "accessory serial number:") > 0 Then
                        ReadSn = TxtBarCode.Lines(i).ToString.Split(":")(1).Trim
                        Exit For
                    End If
                Next
            Catch ex As Exception
                TxtBarCode.Text = ""
                TxtBarCode.Clear()
                TxtBarCode.Focus()
                TxtBarCode.Text = ex.Message
            End Try

            'If InStr(TxtBarCode.Text.Trim.ToLower, "vid=01") < 1 Then
            '    Me.LabResult.Text = ""

            '    'PlaySimpleSound(1)
            '    WorkStantOption.BarCodeStr = "NONE"
            '    WorkStantOption.vMainBarCode = Me.TxtBarCode.Text

            '    WorkStantOption.ErrorStr = "E75 vID=02, FAIL..."

            '    LabResult.ForeColor = Color.Red
            '    lblMessage.ForeColor = Color.Red
            '    lblMessage.Text = "E75 vID=02, FAIL..."
            '    LabResult.Text = WorkStantOption.ErrorStr
            '    Dim FrmError As New FrmScanErrPrompt
            '    FrmError.ShowDialog() '' WorkStantOption.vPreStation
            '    'Me.TxtBarCode.Text = UCase(ReadSn)
            '    Exit Sub
            'End If
            'Me.Label11.Text = "E75 VID=01,PASS..."
            'Me.Label11.ForeColor = Color.Green

            E75Msg = TxtBarCode.Text.Trim()
            If ReadSn = "" Then
                lblMessage.Text = "该关键物料未经过NI测试站，进行烧录..."
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                PlaySimpleSound(1)
                Exit Sub
            Else
                Me.TxtBarCode.Text = ReadSn
            End If
        Else
            ReadSn = Me.TxtBarCode.Text.Trim
        End If

        If Me.TxtMoId.Text = "" Then
            MessageBox.Show("請先設置好掃描基本信息！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If ''90241
        If BarCode = "" Then
            MessageBox.Show("產品條碼不能為空！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        'If (Me.TxtCartonNo.Text <> "") Then
        '    If DeserTionMainCodeBar() = True Then Exit Sub
        'End If
        BarCode = Me.TxtBarCode.Text.Replace(vbNewLine, "").Trim()

        '2014-09-17     科尔通      华为代码切换暂取消样式检查
        'If IsReadSn <> "Y" And IsPackingPPID <> "N" Then
        '    If Len(BarCode) <> TxtSnStyle2.Text.Trim.Length Then '' WorkStantOption.LengthStr Then
        '        PlaySimpleSound(1)
        '        LabResult.ForeColor = Color.Crimson
        '        lblMessage.ForeColor = Color.Crimson
        '        WorkStantOption.ErrorStr = "條碼長度有誤"
        '        PlaySimpleSound(1)

        '        WorkStantOption.BarCodeStr = BarCode
        '        WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
        '        'Conn.ExecSql("insert m_AssysnE_t (ppid,moid,stationid,teamid,spoint,errordest,userid,intime) values ('" & Trim(BarCode) & "','" & Trim(TxtMoId.Text) & "','AA','" & Trim(Me.TxtLineId.Text) & "','" & My.Computer.Name & "','L條碼長度有誤','" & SysMessageClass.UseId & "',getdate())")
        '        Dim FrmError As New FrmScanErrPrompt
        '        FrmError.ShowDialog()

        '        TxtBarCode.Text = ""
        '        Me.TxtBarCode.Focus()

        '        Exit Sub
        '    End If

        '    'BarCode = BarCode.Replace(vbNewLine, "").Trim
        '    'TextBox1.Text = BarCode
        '    'MessageBox.Show(BarCode)
        '    ''DecideFlag = DecideIsCheckStyle() ''''判斷是否為重工工單打印條碼
        '    ''If (LblType.Text <> "0") Or (DecideFlag = "0" And LblType.Text = "0") Then '''' 重工記錄不更換外箱 不檢查標准樣式.
        '    If TextHandle.verfyBarCodeStyle(TxtSnStyle1.Text, BarCode, TxtSnStyle2.Text) = False Then
        '        LabResult.ForeColor = Color.Crimson
        '        lblMessage.ForeColor = Color.Crimson
        '        WorkStantOption.ErrorStr = "條碼不符合標準樣式"
        '        PlaySimpleSound(1)

        '        WorkStantOption.BarCodeStr = BarCode
        '        WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
        '        '' Conn.ExecSql("insert m_AssysnE_t (ppid,moid,stationid,teamid,spoint,errordest,userid,intime) values ('" & Trim(BarCode) & "','" & Trim(TxtMoId.Text) & "','AA','" & Trim(TxtLineId.Text) & "','" & My.Computer.Name & "','R條碼不符合標準樣式','" & SysMessageClass.UseId & "',getdate())")
        '        Dim FrmError As New FrmScanErrPrompt
        '        FrmError.ShowDialog() '' WorkStantOption.vPreStation

        '        TxtBarCode.Text = ""
        '        Me.TxtBarCode.Focus()
        '        Exit Sub
        '    End If
        'End If

        '箱层级判断/料件号判断     'TxtBarCode  扫描箱号：判断工站扫描是装箱/装产品

        Try
            Dim tempstr() As String = WorkStantOption.vmReplaceArray(WorkStantOption.vCurrentStandIndex, 1).Split("|")
            Sqlstr = "declare @strmsgid varchar(1),@strmsgText varchar(50),@currqty int,@currPqty int, @OutPQty int,@outPPID nvarchar(64) execute [m_CheckPackScan_P] '" & Trim(BarCode) & "','" & E75sn & "','" & E75Msg & "', " & _
                      " '" & Trim(TxtMoId.Text) & "','" & Trim(TxtLineId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & _
                      "'" & WorkStantOption.PartidStr & "','" & tempstr(tempstr.Length - 1) & "','" & LblMainBarCode.Text & "'," & _
                      " '" & WorkStantOption.vStandId & "' ,'" & WorkStantOption.vStandIndex & "','" & WorkStantOption.vCurrentStandIndex & "'," & _
                      " '" & WorkStantOption.vStandMaxStaIndex & "','" & Me.TxtCartonID.Text & "','" & Me.TxtPalletID.Text.Trim & "','" & Me.LblPackQty.Text & "','" & IsPackType.Trim & " ',' " & WorkStantOption.vPPackingProduct.Trim & "'," & _
                      "@strmsgid output,@strmsgText output,@currqty output,@currPqty output, @OutPQty output,@OutPPID output select @strmsgid,@strmsgText,isnull(@currqty,1),isnull(@currPqty,1), isnull(@OutPQty,0) as outPQty,@OutPPID as PPID"

            RecDr = Conn.GetDataReader(Sqlstr)
            If RecDr.HasRows Then
                RecDr.Read()
                Select Case RecDr.GetString(0)
                    Case "0", "1", "2", "3"
                        WorkStantOption.ErrorStr = RecDr.GetString(1)
                        PlaySimpleSound(1)
                        Exit Select
                    Case "4" ''---掃描成功
                        PlaySimpleSound(0)
                        If WorkStantOption.vCurrentStandIndex = 1 Then
                            LblMainBarCode.Text = TxtBarCode.Text
                        End If
                        LabResult.ForeColor = Color.FromArgb(0, 192, 0)
                        lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
                        LabResult.Text = BarCode & Space(3) & "扫描成功..."

                        lblMessage.Text = "PASS"
                        '@OutPPID       
                        TxtBarCode.Text = RecDr.Item("PPID").ToString
                        'Crimson()
                        Me.DGridBarCode.Rows.Insert(0, WorkStantOption.PartidStr, WorkStantOption.vStandIndex, TxtBarCode.Text, WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3), SysMessageClass.UseName, Now())
                        '' DGridBarCode.AutoResizeColumns()
                        'DGridBarCode.ClearSelection()
                        'DGridBarCode.Rows(0).Cells(0).Selected = True
                        If DGridBarCode.Rows.Count > 10 Then
                            DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
                        End If
                        WorkStantOption.vCurrentStandIndex = WorkStantOption.vCurrentStandIndex + 1
                        TxtSnStyle1.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 1)
                        'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 2)
                        LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
                        RecDr.Close()
                        Conn.PubConnection.Close()
                        If UCase(IsLinePrint) = "Y" Then ''在线打印产品条码
                            PrintMainBarcode(ReadSn, TxtPartid.Text)
                        End If
                        TxtBarCode.Clear()
                        TxtBarCode.Focus()

                        Exit Sub
                    Case "5"
                        WorkStantOption.ErrorStr = RecDr.GetString(1)
                        PlaySimpleSound(1)
                        Exit Select
                    Case "6"
                        PlaySimpleSound(0)
                        Me.LblCurrQty.Text = RecDr.GetInt32(2)

                        LabResult.ForeColor = Color.FromArgb(0, 192, 0)
                        lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
                        LabResult.Text = BarCode & Space(3) & "掃描成功！"
                        lblMessage.Text = "PASS"

                        '' DGridBarCode.DisplayedRowCount(True)
                        ''Me.DGridBarCode.Rows.Insert(0, Me.TxtBarCode.Text, Me.TxtCartonNo.Text, SysMessageClass.UseName, Now())
                        Me.DGridBarCode.Rows.Insert(0, WorkStantOption.PartidStr, WorkStantOption.vStandIndex, TxtBarCode.Text, WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3), SysMessageClass.UseName, Now())
                        '' DGridBarCode.AutoResizeColumns()
                        DGridBarCode.ClearSelection()
                        DGridBarCode.Rows(0).Cells(0).Selected = True
                        'DGridBarCode.Rows.Clear()
                        If DGridBarCode.Rows.Count > 10 Then
                            DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
                        End If

                        'If ToolMainBarcode.Visible = False Then ToolMainBarcode.Visible = True
                        WorkStantOption.vCurrentStandIndex = 1
                        TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
                        TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
                        'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
                        LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"

                        If (WorkStantOption.vPPackingProduct.Trim = "Y") Then
                            Me.LblCurrCarQty.Text = RecDr.Item("outPQty").ToString
                        End If
                        RecDr.Close()
                        Conn.PubConnection.Close()
                        If UCase(IsLinePrint) = "Y" Then ''在线打印产品条码
                            PrintMainBarcode(ReadSn, TxtPartid.Text)
                        End If
                        LblMainBarCode.Text = ""
                        'LblCurrQty.Text = Int(LblCurrQty.Text) + 1
                        TxtBarCode.Clear()
                        TxtBarCode.Focus()
                        Exit Sub
                    Case "7"
                        PlaySimpleSound(0)
                        LabCartonQty.Text = RecDr.GetInt32(3)
                        Me.LblCurrQty.Text = RecDr.GetInt32(2)

                        If (WorkStantOption.vPPackingProduct.Trim = "Y") Then
                            Me.LblCurrCarQty.Text = RecDr.Item("outPQty").ToString
                        End If
                        'PlaySimpleSound(0)
                        'LblPackQty 应装产品  实装 LblCurrQty
                        'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                        If IsScanPallet AndAlso Convert.ToInt32(LblCartonQty.Text) = Convert.ToInt32(LblCurrCarQty.Text) Then
                            LabResult.ForeColor = Color.FromArgb(0, 192, 0)
                            lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
                            LabResult.Text = BarCode & Space(3) & "扫描成功，请扫描大外箱或栈板条码！"
                            RecDr.Close()
                            Conn.PubConnection.Close()
                            If UCase(IsLinePrint) = "Y" Then ''在线打印产品条码
                                PrintMainBarcode(ReadSn, TxtPartid.Text)
                            End If
                            Conn.ExecSql("update M_palletM_t set palletstatus='Y' where palletid='" & Me.TxtPalletID.Text & "'")
                            lblMessage.Text = "PASS"
                            DGridBarCode.Rows.Clear()
                            'SetGridHeadColumn()
                            'LblCurrCarQty.Text = (Convert.ToInt32(LblCurrCarQty.Text) + 1).ToString
                            LblCartonQty.Text = "0"
                            LblCurrCarQty.Text = "0"
                            LblCurrQty.Text = "0"
                            LblPackQty.Text = "0"
                            'LblCurrQty
                            WorkStantOption.vCurrentStandIndex = 1
                            TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
                            TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
                            'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
                            LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"

                            LblMainBarCode.Text = ""

                            'LblCurrQty.Text = Int(LblCurrQty.Text) + 1
                            ControlState(False, True)
                            'LoadPalletPaceQty()
                            If UCase(IsLinePrint) = "Y" Then ''在线打印产品条码
                                PrintMainBarcode(BarCode, TxtPartid.Text)
                            End If
                            Exit Sub
                        Else
                            LabResult.ForeColor = Color.FromArgb(0, 192, 0)
                            lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
                            'LblCurrQty.Text
                            LabResult.Text = BarCode & Space(3) & "该箱已经包装完成,请扫描下一箱..."
                            'LblPackQty 应装产品  实装 LblCurrQty
                            'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                            lblMessage.Text = "PASS"
                            DGridBarCode.Rows.Clear()
                            'SetGridHeadColumn()
                            'LblCurrCarQty.Text = Convert.ToInt32(LblCurrCarQty.Text).ToString

                            '' DGridBarCode.DisplayedRowCount(True)
                            ''Me.DGridBarCode.Rows.Insert(0, Me.TxtBarCode.Text, Me.TxtCartonNo.Text, SysMessageClass.UseName, Now())
                            'Me.DGridBarCode.Rows.Insert(0, WorkStantOption.PartidStr, WorkStantOption.vStandIndex, TxtBarCode.Text, WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3), SysMessageClass.UseName, Now())
                            '' DGridBarCode.AutoResizeColumns()
                            'DGridBarCode.ClearSelection()
                            'DGridBarCode.Rows(0).Cells(0).Selected = True
                            'DGridBarCode.Rows.Clear()
                            ''If DGridBarCode.Rows.Count > WorkStantOption.vStandMaxStaIndex * 5 Then
                            ''    DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
                            ''End If

                            'If ToolMainBarcode.Visible = False Then ToolMainBarcode.Visible = True
                            WorkStantOption.vCurrentStandIndex = 1
                            TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
                            TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
                            'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
                            LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
                            'If UCase(IsLinePrint) = "Y" Then ''在线打印产品条码
                            '    PrintMainBarcode(BarCode, TxtPartid.Text)
                            'End If
                            LblMainBarCode.Text = ""
                            RecDr.Close()
                            Conn.PubConnection.Close()
                            If UCase(IsLinePrint) = "Y" Then ''在线打印产品条码
                                PrintMainBarcode(BarCode, TxtPartid.Text)
                            End If
                            If WorkStantOption.PrtPackingCheck Then
                                ' PrintMainBarcode(BarCode, TxtPartid.Text)
                                ' PrintMainBarcode(TxtCartonID.Text, TxtPartid.Text)
                                PrintCartonBarcode(TxtCartonID.Text, TxtMoId.Text, TxtPartid.Text, WorkStantOption.vStandId)
                                Me.TxtCartonID.Text = CartonPrint()
                                LblPackQty.Text = WorkStantOption.PartPackQty
                                Me.LblCurrQty.Text = WorkStantOption.NowCartonScanQty
                                CartonIDScanHandle()
                                lblMessage.Text = "PASS"
                                Me.LabResult.Text = "新外箱条码已创建,请扫描下一箱产品条码..."
                                ControlState(True)
                                'Me.TxtCartonID.Focus()

                            Else
                                ControlState(False)
                                Me.TxtCartonID.Focus()
                            End If
                            'LblCurrQty.Text = Int(LblCurrQty.Text) + 1


                            'LoadPalletPaceQty()
                            'If UCase(IsLinePrint) = "Y" Then ''在线打印产品条码
                            '    PrintMainBarcode(BarCode, TxtPartid.Text)
                            'End If
                            Exit Sub
                        End If
                End Select
                'PlaySimpleSound(1)
                RecDr.Close()
                Conn.PubConnection.Close()
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                LabResult.ForeColor = Color.Crimson
                lblMessage.ForeColor = Color.Crimson
                LabResult.Text = BarCode & Space(3) & "扫描时发生错误！"
                lblMessage.Text = "FAIL"
                Dim FrmError As New FrmScanErrPrompt
                FrmError.ShowDialog()
                ''If WorkStantOption.vDeserTionFlag = True Then
                ''    TxtBarCode.Clear()
                ''    WorkStantOption.vCurrentStandIndex = 1
                ''    TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
                ''    TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
                ''    TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
                ''    LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
                ''    LblMainBarCode.Text = ""
                ''    lblMessage.Text = "舍棄主條碼成功!"
                ''Else
                ''    TxtBarCode.Clear()
                ''    If Me.LblMainBarCode.Text <> "" Then
                ''        lblMessage.Text = "舍棄主條碼失敗!"
                ''    End If
                ''End If
                ''WorkStantOption.vDeserTionFlag = False
                ''WorkStantOption.vMainBarCode = Nothing
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            If Not RecDr Is Nothing Then
                RecDr.Close()
                Conn.PubConnection.Close()
            End If
            'PlaySimpleSound(1)
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            SysMessageClass.WriteErrLog(ex, Me.Name, "BtEnter_Click", "sys")
            Exit Sub
        End Try
    End Sub

    Private Sub PrintMainBarcode(ByVal BarCodeStr As String, ByVal partid As String)

        Try
            'MessageBox.Show(BarCodeStr)
            'btFormat.PrintSetup.IdenticalCopiesOfLabel = 1
            'btFormat.PrintSetup.NumberSerializedLabels = 1
            btFormat.SetNamedSubStringValue("barcode1", BarCodeStr)
            'btFormat.
            'btFormat.Print("", False, -1, Nothing)
            btFormat.PrintOut(False, False)
            'btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            'btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            'TxtBarCode.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'BarCodeToFile(BarCodeStr, Me.TxtPartid.Text)      
    End Sub


#End Region

#Region "条码数据生成至File数据库"
    Public Sub BarCodeToFile(ByVal BarDataStr As String, ByVal partid As String)

        Dim TxtFileStr As New StringBuilder
        Dim pFilePath As String = ""
        Dim mDataRaed As SqlClient.SqlDataReader = Nothing
        Dim PubClass As New SysDataBaseClass
        Try
            'Dim sqlstr As String = " select [barcodesnid],[label10],[label11],[label12],[label13],[label14]," & _
            '                "[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]," & _
            '                "[label23],[label24] from m_BarRecordValue_t   where [barcodesnid]='" & BarDataStr & "'"
            'mDataRaed = PubClass.GetDataReader(sqlstr)
            'If mDataRaed.HasRows Then
            '    While mDataRaed.Read
            '        TxtFileStr.Append("""" & mDataRaed!barcodesnid.ToString & """" & "," & """" & mDataRaed!label10.ToString & """" & "," & """" & mDataRaed!label11.ToString & """" _
            '                          & "," & """" & mDataRaed!label12.ToString & """" & "," & """" & mDataRaed!label13.ToString & """" & "," & """" & mDataRaed!label14.ToString & """" _
            '                          & "," & """" & mDataRaed!label15.ToString & """" & "," & """" & mDataRaed!label16.ToString & """" & "," & """" & mDataRaed!label17.ToString & """" _
            '                          & "," & """" & mDataRaed!label18.ToString & """" & "," & """" & mDataRaed!labe19.ToString & """" & "," & """" & mDataRaed!label20.ToString & """" _
            '                          & "," & """" & mDataRaed!label21.ToString & """" & "," & """" & mDataRaed!label22.ToString & """" & "," & """" & mDataRaed!label23.ToString & """" & "," & """" & mDataRaed!label24.ToString & """")
            '        'pFilePath = mDataRaed!BartenderFile.ToString()
            '    End While
            'End If
            'mDataRaed.Close()
            'MessageBox.Show(TxtFileStr.ToString)
            mDataRaed = PubClass.GetDataReader("select  isRplacePath from  m_RPartStationD_t where ppartid='" & partid & "' and state=1 and  IslineMbarcode='Y'")
            If mDataRaed.HasRows Then
                While mDataRaed.Read
                    pFilePath = mDataRaed!isRplacePath.ToString
                End While
                mDataRaed.Close()
                Conn.PubConnection.Close()
            Else
                mDataRaed.Close()
                Conn.PubConnection.Close()
                'Throw New Exception("模板不能为空")
                mDataRaed = PubClass.GetDataReader("select top 1 BartenderFile from m_SnSBarCode_t where sbarcode='" & BarDataStr & "'")
                If mDataRaed.HasRows Then
                    pFilePath = mDataRaed!BartenderFile.ToString
                    mDataRaed.Close()
                    Conn.PubConnection.Close()
                Else
                    MessageBox.Show("没有该条码的任何资料...")
                    mDataRaed.Close()
                    Conn.PubConnection.Close()
                    Exit Sub
                End If
                MessageBox.Show("")
                Exit Sub
            End If ''

            'MessageBox.Show(pFilePath.ToString)
            If pFilePath = "" Then Exit Sub
            TxtFileStr.Append("""" & BarDataStr & """")
            TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            'If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
            'File.Copy(PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
            'End If

            IO.File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)
            TxtFileStr = Nothing
            FileToBarCodePrint(pFilePath)
        Catch ex As Exception
            If mDataRaed.IsClosed = False Then
                mDataRaed.Close()
                Conn.PubConnection.Close()
            End If

            Throw ex
        End Try


    End Sub
#End Region

#Region "条码打印方法更新，优化速度"

    Private Sub FileToBarCodePrint(ByVal LableFile As String)


        If LableFile = "" Then
            MessageBox.Show("该料件的打印格式，未上传打印模版...")
            Exit Sub
        End If


        btFormat = btApp.Formats.Open(LableFile, False, String.Empty)
        'Me.Timer1.Stop()
        'MessageBox.Show(mytime)
        'btFormat.PrintOut(False, False)
        btFormat.Print("", False, -1, Nothing)
        'Me.Timer1.Stop()
        'End the BarTender process 
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)


        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)

        'SyncLock engine
        '    Dim success As Boolean = True
        '    format = engine.Documents.Open(LableFile)

        '    Dim messages As Messages = Nothing
        '    Dim waitForCompletionTimeout As Integer = 0 ' 10 seconds
        '    Dim result As Result = format.Print(appName, waitForCompletionTimeout, messages)
        '    Dim messageString As String = Constants.vbLf + Constants.vbLf & "Messages:"

        '    format.Close(SaveOptions.DoNotSaveChanges)
        '    'engine.Stop()

        'End SyncLock

    End Sub

#End Region

    'Private Sub TxtBarCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBarCode.KeyPress
    '    e.KeyChar = UCase(e.KeyChar)
    'End Sub

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
        'Case 0  '
        'My.Computer.Audio.Play(My.Resources.Resource1.pass, AudioPlayMode.Background)
        '    Case 1
        'My.Computer.Audio.Play(My.Resources.Resource1.ERR, AudioPlayMode.Background)
        '    Case 2
        'My.Computer.Audio.Play(My.Resources.Resource1.chimes, AudioPlayMode.Background)

    End Sub
#End Region



    Private Sub TxtBarCode_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TxtBarCode.PreviewKeyDown
        If e.KeyValue = 13 Then
            StandScan()
        End If
    End Sub

    Private Sub TxtSnStyle2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSnStyle2.GotFocus, TxtSnStyle1.GotFocus

        If Me.TxtCartonID.ReadOnly = False Then
            TxtCartonID.Focus()
        Else
            If Me.TxtPalletID.ReadOnly = False Then
                TxtPalletID.Focus()
            ElseIf Me.TxtBarCode.ReadOnly = False Then
                TxtBarCode.Focus()
            End If
        End If
    End Sub

    Private Sub toolCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim frm As New FrmPartition
        frm.ShowDialog()

    End Sub


    Private Sub TxtCartonID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCartonID.KeyPress

        'e.KeyChar = UCase(e.KeyChar)
        'If e.KeyChar = Chr(32) Then
        '    e.Handled = True
        'Else
        '    e.Handled = False
        'End If
        If e.KeyChar = Chr(13) Then
            CartonIDScanHandle()
        End If

    End Sub

    Private Sub TxtPalletID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPalletID.KeyPress

        'e.KeyChar = UCase(e.KeyChar)
        'If e.KeyChar = Chr(32) Then
        '    e.Handled = True
        'Else
        '    e.Handled = False
        'End If
        If e.KeyChar = Chr(13) Then
            PalletIDScanHandle() ''掃入棧板條碼
        End If

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
        Else
            If TgenCarton = "N" Then
                TxtCartonID.Enabled = True
                TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
                'TxtBarCode.BorderColor = Color.FromArgb(209, 31, 73)
                TxtBarCode.Enabled = False
                'TxtBarCode.BackColor = Color.FromArgb(246, 252, 255)
                ''TxtCartonID.BackColor = Color.White
                TxtCartonID.Text = ""
                Me.TxtCartonID.Focus()
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
            End If
        End If

    End Sub

    'Private Function GeneratePalletNo() ''生成棧板編號，工單+線別+流水號(4位)

    '    If TxtLineId.Text.Trim = "" Then
    '        MessageBox.Show("没有选择线别或线别资料遗失,不能生成外箱编号")
    '        GeneratePalletNo = ""
    '        Exit Function
    '    End If
    '    Dim palletNoStr As String = String.Empty
    '    Dim cnn As New MainFrame.SysDataHandle.SysDataBaseClass
    '    Dim palletReader As SqlDataReader = cnn.GetDataReader("select isnull(max(Cartonid),'') maxpallno from m_Carton_t where Moid='" & TxtMoId.Text.Trim & "' and Teamid='" & TxtLineId.Text.Trim & "'")
    '    If palletReader.HasRows Then
    '        While palletReader.Read
    '            If palletReader!maxpallno = "" Then
    '                palletNoStr = TxtMoId.Text.Trim + TxtLineId.Text.Trim + "0001"
    '            Else
    '                palletNoStr = Replace(palletReader!maxpallno, TxtMoId.Text.Trim & TxtLineId.Text.Trim, "1")
    '                palletNoStr = TxtMoId.Text.Trim & TxtLineId.Text.Trim & (palletNoStr + 1).ToString.Substring(1)
    '            End If
    '        End While
    '    End If
    '    palletReader.Close()
    '    Return palletNoStr

    'End Function

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
            If isScanPallet Then
                TxtCartonID.Enabled = False
                TxtBarCode.Enabled = False
                TxtPalletID.Enabled = True
                TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
                'TxtBarCode.BorderColor = Color.FromArgb(209, 31, 73)
                TxtBarCode.BackColor = Color.FromArgb(246, 252, 255)
                ''TxtCartonID.BackColor = Color.White
                TxtBarCode.Text = ""
                TxtPalletID.Text = ""
                TxtCartonID.Text = ""
                Me.TxtPalletID.Focus()
            Else
                TxtCartonID.Enabled = True
                TxtPalletID.Enabled = False
                TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
                'TxtBarCode.BorderColor = Color.FromArgb(209, 31, 73)
                TxtBarCode.Enabled = False
                TxtBarCode.Enabled = False
                TxtBarCode.BackColor = Color.FromArgb(246, 252, 255)
                ''TxtCartonID.BackColor = Color.White
                TxtCartonID.Text = ""
                TxtBarCode.Text = ""
                Me.TxtCartonID.Focus()
            End If
        End If

    End Sub

    Private Sub CartonIDScanHandle()

        Dim DrGetCarton As SqlDataReader = Nothing
        Dim DrGetPallet As SqlDataReader = Nothing
        Dim Sqlstr As String = String.Empty
        Dim StrQty As Integer

        If Me.TxtPartid.Text = "" Then
            lblMessage.Text = "扫描资料未设置，请先设置..."
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        If Me.TxtCartonID.Text = "" Then
            lblMessage.Text = "箱號條碼序號不能為空！"
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        '------------------------新增棧板對應多外箱掃描-------------

        'If IsScanPallet Then
        '    Try
        '        Sqlstr = "declare @strmsgid int,@currqty int execute m_CheckPalletCarton_p " & _
        '          " '" & PalletID & "','" & Trim(Trim(Me.TxtCartonID.Text)) & "','" & Trim(Me.TxtMoId.Text) & "','" & Trim(Me.TxtLineId.Text) & "','" & SysMessageClass.UseId & "','" & IIf(IsCustPart, "Y", "N") & "'" & _
        '          " ,@currqty output,@strmsgid output; select @strmsgid,@currqty "

        '        DrGetPallet = Conn.GetDataReader(Sqlstr)
        '        If DrGetPallet.HasRows Then
        '            DrGetPallet.Read()
        '            Select Case DrGetPallet(0).ToString()
        '                Case "1"
        '                    LabResult.Text = "NG"
        '                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
        '                    WorkStantOption.BarCodeStr = TxtCartonID.Text
        '                    WorkStantOption.ErrorStr = "棧板與客戶料號客戶料號不一致"
        '                    Dim FrmError As New FrmScanErrPrompt
        '                    FrmError.ShowDialog()
        '                    DrGetPallet.Close()
        '                    TxtPalletID.Focus()
        '                    Exit Sub
        '                    Exit Select
        '                Case "2" To "3" '2：已裝滿，3：未裝滿
        '                    LblCurrCarQty.Text = DrGetPallet(1).ToString()
        '                    DrGetPallet.Close()
        '                    Exit Select
        '                Case "4" ' 該箱號已經掃描過
        '                    LabResult.Text = "NG"
        '                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
        '                    WorkStantOption.BarCodeStr = TxtCartonID.Text
        '                    WorkStantOption.ErrorStr = "該箱號已經掃描過"
        '                    Dim FrmError As New FrmScanErrPrompt
        '                    FrmError.ShowDialog()
        '                    DrGetPallet.Close()
        '                    TxtCartonID.Text = ""
        '                    Exit Sub
        '                    Exit Select
        '            End Select
        '        End If
        '    Catch ex As Exception
        '        DrGetPallet.Close()
        '        SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmInCarton", "GetScanItem", "sys")
        '        Exit Sub
        '    End Try
        'End If
        '-------------------------------------------------------------------------------
        Dim IsPallte As String = IIf(IsScanPallet, "Y", "N")
        If IsScanPallet = True Then
            If CInt(LblCartonQty.Text) <= CInt(LblCurrCarQty.Text) Then
                lblMessage.Text = "外箱装栈板时，发生异常..."
                TxtCartonID.Clear()
                PlaySimpleSound(1)
                Exit Sub
            End If
        End If
        Try
            'Sqlstr = "declare @strmsgid varchar(1),@strmsgText varchar(50),@qty int execute                                                                                                                                                                                                                                                                                                                     A " & _
            '   " '" & Trim(Me.TxtMoId.Text) & "','" & Trim(TxtCartonID.Text) & "','" & Trim(Me.TxtLineId.Text) & "','" & SysMessageClass.UseId & "'," & _
            '   "@strmsgid output,@strmsgText output,@qty output select @strmsgid ,isnull(@strmsgText,'') ,@qty "
            If WorkStantOption.vCartonSame = "Y" Then
                Sqlstr = "declare @strmsgid varchar(1),@strmsgText varchar(50),@NewCartonid varchar(100),@qty int execute [m_CheckPallMulletCarton_p] " & _
              " '" & Trim(Me.TxtMoId.Text) & "','" & Trim(TxtCartonID.Text) & "','" & IsPallte & "','" & TxtPalletID.Text & "','" & Trim(Me.TxtLineId.Text) & "','" & SysMessageClass.UseId & "','" & WorkStantOption.vCartonSame.Trim & "','" & WorkStantOption.vPPackingProduct.Trim & "'," & _
              "@strmsgid output,@strmsgText output,@NewCartonid output,@qty output select @strmsgid ,isnull(@strmsgText,''),@qty ,@NewCartonid "
            Else
                Sqlstr = "declare @strmsgid varchar(1),@strmsgText varchar(50),@qty int execute [m_CheckPallCarton_p] " & _
              " '" & Trim(Me.TxtMoId.Text) & "','" & Trim(TxtCartonID.Text) & "','" & IsPallte & "','" & TxtPalletID.Text & "','" & Trim(Me.TxtLineId.Text) & "','" & SysMessageClass.UseId & "'," & _
              "@strmsgid output,@strmsgText output,@qty output select @strmsgid ,isnull(@strmsgText,'') ,@qty "
            End If

            DrGetCarton = Conn.GetDataReader(Sqlstr)
            If DrGetCarton.HasRows Then
                DrGetCarton.Read()
                Select Case DrGetCarton(0).ToString()
                    Case "1" To "3"
                        PlaySimpleSound(1)
                        lblMessage.Text = DrGetCarton(1).ToString()
                        Me.TxtCartonID.Clear()
                        DrGetCarton.Close()
                        Conn.PubConnection.Close()
                        Exit Sub
                    Case "4"
                        PlaySimpleSound(0)
                        DGridBarCode.Rows.Clear()
                        'SetGridHeadColumn()
                        LblPackQty.Text = ""
                        LblCurrQty.Text = ""
                        StrQty = CInt(DrGetCarton(2).ToString)
                        If WorkStantOption.vCartonSame = "Y" Then
                            TxtCartonID.Text = DrGetCarton(3).ToString
                        End If
                        DrGetCarton.Close()
                        Conn.PubConnection.Close()
                        LblPackQty.Text = StrQty

                        Me.LblCurrQty.Text = 0
                        'LblPackQty 应装产品  实装 LblCurrQty
                        'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                        If (WorkStantOption.vPPackingProduct.Trim = "N") Then
                            LblCurrCarQty.Text = CInt(LblCurrCarQty.Text) + 1
                        End If

                        'LabCartonQty.Text = CInt(LabCartonQty.Text) + 1
                        lblMessage.Text = "外箱条码序号，扫描成功..."
                        Me.LabResult.Text = "PASS"
                        'LblCurrCarQty.Text = CInt(LblCurrCarQty.Text) + 1
                        ControlState(True)

                End Select
            Else
                lblMessage.Text = "系统无法识别此外箱标签序号！"
                Me.TxtCartonID.Text = ""
                DrGetCarton.Close()
                Conn.PubConnection.Close()
                PlaySimpleSound(1)
                Exit Sub
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            If DrGetCarton.IsClosed = False Then DrGetCarton.Close()
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmInCarton", "GetScanItem", "sys")
            Exit Sub
        End Try

    End Sub

    Private Sub PalletIDScanHandle()
        Dim Sqlstr As String = String.Empty
        If Me.TxtMoId.Text = "" Then
            lblMessage.Text = "请设置扫描资料！"
            PlaySimpleSound(1)
            Exit Sub
        End If
        If Me.TxtPalletID.Text = "" Then
            lblMessage.Text = "栈板條碼序號不能為空！"
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If
        Try
            'Sqlstr = "select (select count(1) from M_palletM_t  where palletid='" & Trim(Me.TxtPalletID.Text) & "') as isexists," & _
            '        " isnull((select c.qty from m_SnSBarCode_t a ,M_Mainmo_t b,M_PartPack_t c where a.Moid=b.Moid and b.PartID=c.Partid and c.packid='P' and c.packlink='N'  and c.usey='Y' and a.SBarCode='" & Trim(Me.TxtPalletID.Text) & "') ,'') as qty, " & _
            '         "( select count(1)  from M_PalletCarton_t where palletid='" & Trim(Me.TxtPalletID.Text) & "') currqty"
            If WorkStantOption.vPalletSame = "Y" Then
                Sqlstr = "declare @strmsgid varchar(1),@strmsgText varchar(50),@InventPalletid varchar(100),@qty int execute [m_CheckMulletPallet_p] " & _
                  " '" & Trim(Me.TxtMoId.Text) & "','" & Trim(TxtPalletID.Text) & "','" & Trim(Me.TxtLineId.Text) & "','" & SysMessageClass.UseId & "','" & WorkStantOption.vPalletSame & "','" & WorkStantOption.vPPackingProduct & "'," & _
                  "@strmsgid output,@strmsgText output,@InventPalletid output,@qty output select @strmsgid ,isnull(@strmsgText,'') ,@qty,@InventPalletid "
            Else
                Sqlstr = "declare @strmsgid varchar(1),@strmsgText varchar(50),@qty int execute [m_CheckPallet_p] " & _
                 " '" & Trim(Me.TxtMoId.Text) & "','" & Trim(TxtPalletID.Text) & "','" & Trim(Me.TxtLineId.Text) & "','" & SysMessageClass.UseId & "'," & _
                 "@strmsgid output,@strmsgText output,@qty output select @strmsgid ,isnull(@strmsgText,'') ,@qty "
            End If

            Dim DrGetCarton As SqlDataReader = Conn.GetDataReader(Sqlstr)
            If DrGetCarton.HasRows Then
                DrGetCarton.Read()
                Select Case DrGetCarton(0).ToString()
                    Case "1" To "3"
                        lblMessage.Text = DrGetCarton(1).ToString()
                        Me.TxtPalletID.Clear()
                        DrGetCarton.Close()
                        Conn.PubConnection.Close()

                        PlaySimpleSound(1)
                        Exit Sub
                    Case "4"
                        DGridBarCode.Rows.Clear()
                        'SetGridHeadColumn()
                        'LblPackQty 应装产品  实装 LblCurrQty
                        'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                        LblPackQty.Text = "0"
                        LblCurrQty.Text = "0"
                        LblCurrCarQty.Text = "0"
                        If WorkStantOption.vPalletSame = "Y" Then
                            TxtPalletID.Text = DrGetCarton(3).ToString
                        End If
                        LblCartonQty.Text = CInt(DrGetCarton(2).ToString)
                        DrGetCarton.Close()
                        Conn.PubConnection.Close()
                        'LblPackQty.Text = StrQty
                        lblMessage.Text = "栈板标签序号扫描成功"

                        TxtPalletID.Enabled = False
                        Me.LabResult.Text = "PASS"
                        'Me.LblCurrQty.Text = 0
                        'LabCartonQty.Text = CInt(LabCartonQty.Text) + 1
                        ControlState(False)

                        PlaySimpleSound(0)
                End Select
            Else
                lblMessage.Text = "系统无法识别此栈板标签序号！"
                Me.TxtCartonID.Text = ""
                DrGetCarton.Close()
                Conn.PubConnection.Close()

                PlaySimpleSound(1)
                Exit Sub
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmInCarton", "GetScanItem", "sys")
            Exit Sub
        End Try

    End Sub

#Region "批次扫描作业"
    Private Sub ToolLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLot.Click

        If Me.TxtMoId.Text = "" Then
            lblMessage.Text = "请先设置扫描资料,才能进行批次扫描..."
            Exit Sub
        End If
        Dim FrmOpenLock As New FrmSetLock
        FrmOpenLock.ShowDialog()
        If CartonScanOption.CheckStr = True Then
            Dim frm As New FrmPartLotScan(Me.TxtMoId.Text, Me.TxtPartid.Text, Me.TxtSitName.Text)
            frm.ShowDialog()
        End If

    End Sub
#End Region

#Region "尾数箱參數設置"
    Private Sub ToolOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolOption.Click

        'If TxtMoId.Text = "" Then
        '    lblMessage.Text = "掃描資料未設置..."
        '    Exit Sub
        'End If
        'Dim FrmOpenLock As New FrmOptionSet(Me.LblCheckTime)
        'FrmOpenLock.ShowDialog()
        'FrmOpenLock = Nothing
        Dim BarCodePrint As New PrintJLabelNew
        If Me.TxtMoId.Text = "" Then
            MsgBox("請先設置打印資料！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Exit Sub
        End If
        ' TxtCartonID 
        If LblCurrQty.Text <> "0" Then
            MsgBox("當前箱未掃描完,不允許尾數設置！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Exit Sub
        End If

        If Me.TxtCartonID.Text <> "" And Me.LblCurrQty.Text <> "0" Then
            MsgBox("正在掃描中,不允許尾數打印！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Exit Sub
        End If

        Try
            ''System.Windows.Forms.Application.EnableVisualStyles()
            Dim FrmLastLock As New FrmCartonLastQtySet
            Dim result As DialogResult = FrmLastLock.ShowDialog()

            If result = DialogResult.OK Then
                LblPackQty.Text = CStr(Val(WorkStantOption.LastPrintQty))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        '' End If
    End Sub
#End Region


    Private Sub ToolReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReplace.Click

        If TxtPartid.Text = "" Then
            lblMessage.Text = "扫描资料未设置..."
            Exit Sub
        End If
        Dim frm As New FrmMBarReplace(Me.TxtPartid.Text)
        frm.ShowDialog()

    End Sub


    Private Sub FrmStantPackScan_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
        DisposeData()
        WorkStantOption.CustIdString = Nothing
        WorkStantOption.MoidStr = Nothing
        WorkStantOption.LengthStr = Nothing
        WorkStantOption.DateCheck = Nothing

        ' Quit the BarTender Print Engine, but do not save changes to any open formats.
        'If engine IsNot Nothing Then
        '    engine.Stop(SaveOptions.DoNotSaveChanges)
        'End If
    End Sub

    Private Sub ChkLinePrint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLinePrint.CheckedChanged

        If ChkLinePrint.Checked = True Then
            IsLinePrint = "Y"
        Else
            IsLinePrint = "N"
        End If

    End Sub
    Private Function CartonPrint() As String

        Dim ServerDate As New DateTime ''''服務器日期時間
        Dim PackBarCode As New PrintJLabelNew
        Dim TimeSqlstr As String = ""

        CartonPrint = ""
        PackArray.AvcPartid = Me.TxtPartid.Text.Trim 'AVC料號
        PackArray.CusName = WorkStantOption.CustStr ' 客戶名稱
        PackArray.Deptid = WorkStantOption.DpetId ' '部門
        PackArray.Lineid = WorkStantOption.LineStr ' Me.TxtLineId.Text.Trim  '線別
        PackArray.Moid = Me.TxtMoId.Text.Trim   '工單
        TimeSqlstr = "select getdate() as nowtime"
        Dim RecTable As SqlDataReader = Conn.GetDataReader(TimeSqlstr)
        While (RecTable.Read)
            ServerDate = CDate(RecTable("nowtime").ToString)
        End While
        PackArray.NowDate = ServerDate.AddHours(-7.5).ToString("yyyy-MM-dd").ToString ''服務器日期
        PackArray.NowMonth = ServerDate.AddHours(-7.5).ToString("MM").ToString ''服務器月份
        RecTable.Close()
        RecTable.Dispose()
        PackArray.Qty = WorkStantOption.PartPackQty ' 200 ' CartonScanOption.vReplaceQty
        If PackBarCode.MarkJLabel(PackArray.ToArray, "Y") Then
            CartonPrint = PackBarCode.JLabelStr ''生成箱號
        End If
        ''  PackArray = Nothing
        ''  RepalceCartonPrint = Nothing


    End Function
    Private Sub PrintCartonBarcode(ByVal CartonBarCodeStr As String, ByVal moid As String, ByVal partid As String, ByVal Stationid As String)
        Dim datastr As String = ""
        Dim i As Integer = 0
        Dim pn As String = ""
        Dim sql_GPN As String = "select top 1 PN from m_Carton_t a left join m_Cartonsn_t b on a.Cartonid =b.Cartonid left join m_A20Box_t c on b.ppid =c.SN where a.Cartonid='" & CartonBarCodeStr & "'"
        Dim Reads As SqlDataReader = Conn.GetDataReader(sql_GPN)
        While (Reads.Read)
            pn = Reads("PN").ToString
        End While
        Reads.Close()

        Dim insertsql As String = "insert m_BarRecordValue_t(barcodeSNID,label10,PrintFlag,Printpc,moid,intime,partid"
        Dim valuesql As String = "select  barcodeSNID='" & CartonBarCodeStr & "',PN='" & pn & "',PrintFlag='1',Printpc='system',moid='" & moid & "',intime=getdate(),partid='" & partid & "'  "
        Dim sql As String = String.Format("declare @datastr varchar(1000)='' select @datastr=@datastr+ppid+''',''' from m_Cartonsn_t where Cartonid='{0}' select ''''+SUBSTRING(@datastr,0,LEN(@datastr)-1) colstr", CartonBarCodeStr)
        Dim RecTable As SqlDataReader = Conn.GetDataReader(sql)
        While (RecTable.Read)
            datastr = RecTable("colstr").ToString
        End While
        RecTable.Close()
        RecTable.Dispose()
        Conn.PubConnection.Close()
        If datastr.Length > 0 Then
            ' datastr = datastr.Substring(0, datastr.Length - 1)
            If datastr.Split(",").Length > 0 Then
                Dim index As Integer = 11
                For i = 0 To datastr.Split(",").Length - 1
                    insertsql = insertsql + ",label" + index.ToString
                    valuesql = valuesql + "," + datastr.Split(",")(i).ToString
                    index = index + 1
                Next

            End If
        End If
        insertsql = insertsql + ")" + valuesql
        Try
            insertsql = insertsql
            ' MessageBox.Show(insertsql)
            Conn.ExecSql(insertsql)
            Conn.PubConnection.Close()
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message
        End Try
        Dim BarRprintHandle As New VbCommClass.VbCommClass
        Try
            BarRprintHandle.BarCodeToFile(CartonBarCodeStr, partid, Stationid)
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message
        End Try


    End Sub


    Private Sub ToolCartonReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TxtPartid.Text = "" Then
            lblMessage.Text = "扫描资料未设置..."
            Exit Sub
        End If
        If WorkStantOption.PrtPackingCheck Then
            Dim frm As New FrmCartonReplace(TxtPartid.Text)
            frm.ShowDialog()
        Else
            lblMessage.Text = "在线打印的外箱才能替换打印..."
            Exit Sub
        End If

    End Sub

    Private Sub ToolError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolError.Click

        '权限检查
        Dim CheckRead As SqlClient.SqlDataReader
        Dim PubClass As New MainFrame.SysDataHandle.SysDataBaseClass

        CheckRead = PubClass.GetDataReader("select distinct a.userid from m_Users_t a left join m_userright_t b on a.userid=b.userid where a.UserId='" & SysMessageClass.UseId & "' and b.tkey='m0510m_'")
        If Not CheckRead.Read Then
            MessageBox.Show("你没有扫描设置的权限...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        CheckRead.Close()
        PubClass = Nothing

        If String.IsNullOrEmpty(TxtMoId.Text.Trim) Then
            lblMessage.Text = "获取清除工单信息失败，请设置扫描参数！"
            Exit Sub
        End If

        If String.IsNullOrEmpty(TxtCartonID.Text.Trim) And String.IsNullOrEmpty(TxtPalletID.Text.Trim) Then
            lblMessage.Text = "未做包装扫描，无法执行清除！"
            Exit Sub
        End If

        Dim Sqlstr As String = String.Empty
        Dim DrGetCarton As SqlDataReader = Nothing

        Try
            Sqlstr = "declare @strmsgid varchar(8),@strmsgText varchar(64)" & _
                    " execute Exec_PackingError @strmsgid output,@strmsgText output,'" & Me.TxtMoId.Text.Trim & "','" & Me.TxtCartonID.Text.Trim & "','" & Me.TxtPalletID.Text.Trim & " ' " & _
                    " select @strmsgid ,isnull(@strmsgText,'')"

            DrGetCarton = Conn.GetDataReader(Sqlstr)
            If DrGetCarton.HasRows Then
                DrGetCarton.Read()
                Select Case DrGetCarton(0).ToString()
                    Case "1"
                        lblMessage.Text = DrGetCarton(1).ToString()
                        Me.TxtCartonID.Clear()
                        Me.TxtPalletID.Clear()
                    Case "0"
                        lblMessage.Text = DrGetCarton(1).ToString()
                End Select

                DrGetCarton.Close()
                Conn.PubConnection.Close()
            Else
                lblMessage.Text = "系统无法识别此外箱标签序号！"
                DrGetCarton.Close()
                Conn.PubConnection.Close()
                PlaySimpleSound(1)
                Exit Sub
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            If DrGetCarton.IsClosed = False Then DrGetCarton.Close()
            Conn.PubConnection.Close()
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmInCarton", "GetScanItem", "sys")
            Exit Sub
        End Try

    End Sub

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

End Class