
Imports System.Windows.Forms
Imports System.Text
'Imports Seagull.BarTender.Print
Imports System.IO
Imports MainFrame

Public Class VbCommClass

    Shared m_UseName As String
    Public Shared PPartid As String
    Shared m_UseId As String
    Shared m_Lang As String
    Shared m_DeptId As String
    Shared m_PCompany As String
    Shared m_Factory As String
    Shared m_styleid As String '主题ID
    Shared m_PrintDataModle As String
    Shared m_DrawingFilePath As String
    Shared m_SopFilePath As String
    Shared m_PrintRecord As String
    Shared MFormType As String
    Public Shared IsConSap As String = "N"  '"N"

    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    'Private Const appName As String = "Label Print"
    'Private Const dataSourced As String = "Data Sourced"
    Private Shared Mprofitcenter As String
    Private Shared MAutoLogin As String
    Shared m_IslinkErp As String
    Shared _mandt As String
    Shared m_IsTestSystem As String
    Private isClosing As Boolean = False ' Set to tru
    Shared m_dtClientMac As DataTable
    Shared m_CheckClientMac As String
    Shared m_CheckProgramFileVersion As String
    Shared m_VersionConn As String
    Shared m_ClientVersionId As String
    Shared m_ClientVersionName As String
    Shared m_IslinkLDAP As String  'cq, 20160113
    Private btApp As BarTender.Application
    Private btFormat As New BarTender.Format
#Region "是否为正式机"
    Public Shared Property vIsTestSystem() As String
        Get
            Return m_IsTestSystem
        End Get

        Set(ByVal Value As String)
            m_IsTestSystem = Value
        End Set
    End Property
#End Region


#Region "是否连接ERP"
    Public Shared Property vIslinkErp() As String
        Get
            Return m_IslinkErp
        End Get

        Set(ByVal Value As String)
            m_IslinkErp = Value
        End Set
    End Property
#End Region

#Region "打印记录文件"
    Public Shared Property VprintRecord() As String
        Get
            Return m_PrintRecord
        End Get

        Set(ByVal Value As String)
            m_PrintRecord = Value
        End Set
    End Property
#End Region

    '#Region "获取本地打印机列表"
    '    '
    '    ''' <summary> 
    '    ''' 获取本地打印机列表 
    '    ''' 可以通过制定参数获取网络打印机 
    '    ''' </summary> 
    '    ''' <returns>打印机列表</returns> 
    '    Public Shared Sub GetPrinterList(ByVal cboPrinters As System.Windows.Forms.ComboBox)
    '        Dim alRet As New System.Collections.ArrayList()
    '        Dim printers As New Printers()
    '        For Each printer As Printer In printers
    '            cboPrinters.Items.Add(printer.PrinterName)
    '        Next printer

    '        If printers.Count > 0 Then
    '            ' Automatically select the default printer.
    '            cboPrinters.SelectedItem = printers.Default.PrinterName
    '        End If
    '    End Sub
    '#End Region

#Region "单据类型"
    Public Shared Property vFormType() As String
        Get
            Return MFormType
        End Get

        Set(ByVal Value As String)
            MFormType = Value
        End Set
    End Property
#End Region


#Region "自动登录"
    Public Shared Property AutoLogin() As String
        Get
            If MAutoLogin Is Nothing Or String.IsNullOrEmpty(MAutoLogin) Then
                Return "0"
            End If
            Return MAutoLogin
        End Get

        Set(ByVal Value As String)
            If String.IsNullOrEmpty(Value) Then
                MAutoLogin = "0"
            Else

                MAutoLogin = Value
            End If
        End Set
    End Property
#End Region

#Region "服务器"
    '20190924 田玉琳增加 sap服务器
    Public Shared Property SapServer() As String
        Get
            Return _mandt
        End Get

        Set(ByVal Value As String)
            _mandt = Value
        End Set
    End Property
#End Region

#Region "利润中心"
    Public Shared Property profitcenter() As String
        Get
            Return Mprofitcenter
        End Get

        Set(ByVal Value As String)
            Mprofitcenter = Value
        End Set
    End Property
#End Region

#Region "打印模板"
    Public Shared Property PrintDataModle() As String
        Get
            Return m_PrintDataModle
        End Get

        Set(ByVal Value As String)
            m_PrintDataModle = Value
        End Set
    End Property
#End Region


#Region "图纸文件"
    'add by paul liu 20140808
    Public Shared Property DrawingFilePath() As String
        Get
            Return m_DrawingFilePath
        End Get

        Set(ByVal Value As String)
            m_DrawingFilePath = Value
        End Set
    End Property
#End Region

#Region "图纸文件"
    'add by paul liu 20140811
    Public Shared Property SopFilePath() As String
        Get
            Return m_SopFilePath
        End Get

        Set(ByVal Value As String)
            m_SopFilePath = Value
        End Set
    End Property
#End Region

#Region "语言"
    Public Shared Property Language() As String
        Get
            Return m_Lang
        End Get

        Set(ByVal Value As String)
            m_Lang = Value
        End Set
    End Property
#End Region


#Region "公司别"
    Public Shared Property PCompany() As String
        Get
            Return m_PCompany
        End Get

        Set(ByVal Value As String)
            m_PCompany = Value
        End Set
    End Property
#End Region
#Region "工厂别"
    Public Shared Property Factory() As String
        Get
            Return m_Factory
        End Get

        Set(ByVal Value As String)
            m_Factory = Value
        End Set
    End Property
#End Region
#Region "主题样式"
    Public Shared Property StyleID() As String
        Get
            Return m_styleid
        End Get

        Set(ByVal Value As String)
            m_styleid = Value
        End Set
    End Property
#End Region
#Region "用戶姓名"
    Public Shared Property UseName() As String
        Get
            Return m_UseName
        End Get

        Set(ByVal Value As String)
            m_UseName = Value
        End Set
    End Property
#End Region

#Region "用戶ID"
    Public Shared Property UseId() As String
        Get
            Return m_UseId
        End Get

        Set(ByVal Value As String)
            m_UseId = Value
        End Set
    End Property
#End Region

#Region "用戶部門"
    Public Shared Property UseDeptid() As String
        Get
            Return m_DeptId
        End Get

        Set(ByVal Value As String)
            m_DeptId = Value
        End Set
    End Property
#End Region

#Region "料件前缀"
    Private Shared _PartNumberPrefix As String
    Public Shared Property PartNumberPrefix() As String
        Get
            Return _PartNumberPrefix
        End Get
        Set(ByVal value As String)
            _PartNumberPrefix = value
        End Set
    End Property
#End Region

    Public Shared Property CheckClientMac() As String
        Get
            If (m_CheckClientMac Is Nothing) Then
                m_CheckClientMac = "N"
            End If
            Return m_CheckClientMac
        End Get
        Set(ByVal value As String)
            m_CheckClientMac = value
        End Set
    End Property

    Public Shared Property CheckProgramFileVersion() As String
        Get
            If (m_CheckProgramFileVersion Is Nothing) Then
                m_CheckProgramFileVersion = "N"
            End If
            Return m_CheckProgramFileVersion
        End Get
        Set(ByVal value As String)
            m_CheckProgramFileVersion = value
        End Set
    End Property

    Public Shared Property VersionConn() As String
        Get
            If (m_VersionConn Is Nothing) Then
                m_VersionConn = "N"
            End If
            Return m_VersionConn
        End Get
        Set(ByVal value As String)
            m_VersionConn = value
        End Set
    End Property

    Public Shared Property dtClientMac() As DataTable
        Get
            If (m_dtClientMac Is Nothing) Then
                m_dtClientMac = New DataTable()
                m_dtClientMac.Columns.Add("ClientMacAddress", Type.GetType("System.String"))
            End If
            Return m_dtClientMac
        End Get

        Set(value As DataTable)
            m_dtClientMac = value
        End Set
    End Property

    Public Shared Property ClientVersionId() As String
        Get
            Return m_ClientVersionId
        End Get

        Set(value As String)
            m_ClientVersionId = value
        End Set
    End Property

    Public Shared Property ClientVersionName() As String
        Get
            Return m_ClientVersionName
        End Get

        Set(value As String)
            m_ClientVersionName = value
        End Set
    End Property

    Public Shared Property IsAdLink() As String
        Get
            Return m_IslinkLDAP
        End Get

        Set(value As String)
            m_IslinkLDAP = value
        End Set
    End Property

#Region "播放声音"
    Public Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        Select Case PassOrNg
            Case 0
                My.Computer.Audio.Play(Application.StartupPath + "\PASS.wav", AudioPlayMode.Background)
            Case 1
                My.Computer.Audio.Play(Application.StartupPath + "\Error.wav", AudioPlayMode.Background)
                System.Threading.Thread.Sleep(1000)
        End Select
    End Sub
#End Region

#Region "删除控制符"
    ''' <summary>
    ''' 功能描述：删除不可见字符。
    ''' </summary>
    ''' <param name="sourceString">原字符串</param>
    ''' <returns></returns>
    Public Shared Function DeleteUnVisibleChar(ByVal sourceString As String) As String
        Dim strBuilder As New System.Text.StringBuilder(131)

        Dim aaa() As Byte = Encoding.UTF8.GetBytes(sourceString)

        Dim uc() As Char = Encoding.UTF8.GetChars(aaa)
        For k As Integer = 0 To uc.Length - 1
            If Char.IsControl(uc(k)) = False Then
                strBuilder.Append(uc(k))
            End If
        Next

        Return strBuilder.ToString()
    End Function
#End Region

#Region "条码数据生成至File数据库"
    Public Sub BarCodeToFile(ByVal BarDataStr As String, ByVal partid As String, ByVal Stationid As String)

        Dim TxtFileStr As New StringBuilder
        Dim pFilePath As String = ""
        Dim mDataRaed As SqlClient.SqlDataReader
        Try
            Dim sqlstr As String = " select [barcodesnid],[label10],[label11],[label12],[label13],[label14]," & _
                            "[label15],[label16],[label17],[label18],[label19],[label20],[label21],[label22]," & _
                            "[label23],[label24],[label25],[label26],[label27],[label28],[label29],[label30],[label31],[label32],[label33],[label34],[label35],[label36],[label37],[label38],[labe19] from m_BarRecordValue_t   where [barcodesnid]='" & BarDataStr & "'"
            mDataRaed = Conn.GetDataReader(sqlstr)
            If mDataRaed.HasRows Then
                While mDataRaed.Read
                    TxtFileStr.Append("""" & mDataRaed!barcodesnid.ToString & """" & "," & """" & mDataRaed!label10.ToString & """" & "," & """" & mDataRaed!label11.ToString & """" _
                                      & "," & """" & mDataRaed!label12.ToString & """" & "," & """" & mDataRaed!label13.ToString & """" & "," & """" & mDataRaed!label14.ToString & """" _
                                      & "," & """" & mDataRaed!label15.ToString & """" & "," & """" & mDataRaed!label16.ToString & """" & "," & """" & mDataRaed!label17.ToString & """" _
                                      & "," & """" & mDataRaed!label18.ToString & """" & "," & """" & mDataRaed!label19.ToString & """" & "," & """" & mDataRaed!label20.ToString & """" _
                                      & "," & """" & mDataRaed!label21.ToString & """" & "," & """" & mDataRaed!label22.ToString & """" & "," & """" & mDataRaed!label23.ToString & """" _
                                      & "," & """" & mDataRaed!label24.ToString & """" & "," & """" & mDataRaed!label25.ToString & """" & "," & """" & mDataRaed!label26.ToString & """" _
                                      & "," & """" & mDataRaed!label27.ToString & """" & "," & """" & mDataRaed!label28.ToString & """" & "," & """" & mDataRaed!label29.ToString & """" _
                                      & "," & """" & mDataRaed!label30.ToString & """" & "," & """" & mDataRaed!label31.ToString & """" & "," & """" & mDataRaed!label32.ToString & """" _
                                      & "," & """" & mDataRaed!label33.ToString & """" & "," & """" & mDataRaed!label34.ToString & """" & "," & """" & mDataRaed!label35.ToString & """" _
                                      & "," & """" & mDataRaed!label36.ToString & """" & "," & """" & mDataRaed!label37.ToString & """" & "," & """" & mDataRaed!label38.ToString & """" & "," & """" & mDataRaed!labe19.ToString & """")
                    'pFilePath = mDataRaed!BartenderFile.ToString()
                End While
            End If
            mDataRaed.Close()
            'MessageBox.Show(TxtFileStr.ToString)
            mDataRaed = Conn.GetDataReader("select  isRplacePath from  m_RPartStationD_t where ppartid='" & partid & "' and state=1  and stationid='" & Stationid & "'")
            If mDataRaed.HasRows Then
                While mDataRaed.Read
                    pFilePath = mDataRaed!isRplacePath.ToString
                End While
            Else
                'Throw New Exception("模板不能为空")
                mDataRaed.Close()
                Exit Sub
            End If
            mDataRaed.Close()
            'MessageBox.Show(pFilePath.ToString)
            If pFilePath = "" Then Exit Sub
            'TxtFileStr.Append("""" & BarDataStr & """")
            'TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24"",""lable25"",""lable26"",""lable27"",""lable28"",""lable29"",""lable30"",""lable31"",""lable32"",""lable33"",""lable34""" & vbNewLine)
            TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24"",""lable25"",""lable26"",""lable27"",""lable28"",""lable29"",""lable30"",""lable31"",""lable32"",""lable33"",""lable34"",""lable35"",""lable36"",""lable37"",""lable38"",""labe19""" & vbNewLine)

            'If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
            'File.Copy(PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
            'End If
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)
            'File.WriteAllText(Application.StartupPath & "\Bartender.txt", """" & BarDataStr & """")
            'MessageBox.Show(m_PrintDataModle & pFilePath)
            If pFilePath.IndexOf("\\1") >= 0 Then
                FileToBarCodePrint(pFilePath)
            Else
                FileToBarCodePrint(m_PrintDataModle & pFilePath)
            End If
            'BarcodePrintClass.FileToBarCodePrint(m_PrintDataModle & pFilePath)
        Catch ex As Exception
            'mDataRaed.Close()
            Throw ex
        End Try


    End Sub
    Public Sub PrintCartonPpidToFile(ByVal CartonBarcode As String, ByVal partid As String, ByVal Stationid As String)

        Dim TxtFileStr As New StringBuilder
        Dim pFilePath As String = ""
        Dim mDataRaed As SqlClient.SqlDataReader
        Try
            Dim sqlstr As String = " select ppid from m_Cartonsn_t where Cartonid='" & CartonBarcode & "' order by Intime"
            mDataRaed = Conn.GetDataReader(sqlstr)
            If mDataRaed.HasRows Then
                While mDataRaed.Read
                    TxtFileStr.Append("""" & mDataRaed!ppid.ToString & """" & vbNewLine)
                    'pFilePath = mDataRaed!BartenderFile.ToString()
                End While
            End If
            mDataRaed.Close()
            'MessageBox.Show(TxtFileStr.ToString)
            mDataRaed = Conn.GetDataReader("select  isRplacePath from  m_RPartStationD_t where ppartid='" & partid & "' and state=1  and stationid='" & Stationid & "'")
            If mDataRaed.HasRows Then
                While mDataRaed.Read
                    pFilePath = mDataRaed!isRplacePath.ToString
                End While
            Else
                'Throw New Exception("模板不能为空")
                mDataRaed.Close()
                Exit Sub
            End If
            mDataRaed.Close()
            'MessageBox.Show(pFilePath.ToString)
            If pFilePath = "" Then Exit Sub
            'TxtFileStr.Append("""" & BarDataStr & """")
            TxtFileStr.Insert(0, """barcodeSN""" & vbNewLine)

            'If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
            'File.Copy(PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
            'End If
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)
            'File.WriteAllText(Application.StartupPath & "\Bartender.txt", """" & BarDataStr & """")
            'MessageBox.Show(m_PrintDataModle & pFilePath)
            'BarcodePrintClass.FileToBarCodePrint(m_PrintDataModle & pFilePath)
            If pFilePath.IndexOf("\\1") >= 0 Then
                FileToBarCodePrint(pFilePath)
            Else
                FileToBarCodePrint(m_PrintDataModle & pFilePath)
            End If
        Catch ex As Exception
            'mDataRaed.Close()
            Throw ex
        End Try


    End Sub
    Public Sub PrintPalletPpidToFile(ByVal PalletBarcode As String, ByVal partid As String, ByVal Stationid As String)

        Dim TxtFileStr As New StringBuilder
        Dim pFilePath As String = ""
        Dim mDataRaed As SqlClient.SqlDataReader
        Try
            Dim sqlstr As String = " select b.ppid from m_PalletCarton_t a inner join m_Cartonsn_t b on a.Cartonid=b.Cartonid where a.Palletid='" & PalletBarcode & "' order by b.Intime"
            mDataRaed = Conn.GetDataReader(sqlstr)
            If mDataRaed.HasRows Then
                While mDataRaed.Read
                    TxtFileStr.Append("""" & mDataRaed!ppid.ToString & """" & vbNewLine)
                End While
            End If
            mDataRaed.Close()
            'MessageBox.Show(TxtFileStr.ToString)
            mDataRaed = Conn.GetDataReader("select  isRplacePath from  m_RPartStationD_t where ppartid='" & partid & "' and state=1  and stationid='" & Stationid & "'")
            If mDataRaed.HasRows Then
                While mDataRaed.Read
                    pFilePath = mDataRaed!isRplacePath.ToString
                End While
            Else
                'Throw New Exception("模板不能为空")
                mDataRaed.Close()
                Exit Sub
            End If
            mDataRaed.Close()
            'MessageBox.Show(pFilePath.ToString)
            If pFilePath = "" Then Exit Sub
            'TxtFileStr.Append("""" & BarDataStr & """")
            TxtFileStr.Insert(0, """barcodeSN""" & vbNewLine)

            'If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
            'File.Copy(PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
            'End If
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)
            'File.WriteAllText(Application.StartupPath & "\Bartender.txt", """" & BarDataStr & """")
            'MessageBox.Show(m_PrintDataModle & pFilePath)
            'BarcodePrintClass.FileToBarCodePrint(m_PrintDataModle & pFilePath)
            If pFilePath.IndexOf("\\1") >= 0 Then
                FileToBarCodePrint(pFilePath)
            Else
                FileToBarCodePrint(m_PrintDataModle & pFilePath)
            End If
        Catch ex As Exception
            'mDataRaed.Close()
            Throw ex
        End Try


    End Sub
#End Region

    '#Region "条码打印方法更新，优化速度"

    '    Shared Sub FileToBarCodePrint(ByVal LableFile As String)

    '        engine = New Engine(True)
    '        SyncLock engine
    '            Dim success As Boolean = True
    '            format = engine.Documents.Open(LableFile)
    '            '' Assign number of identical copies if it is not datasourced.
    '            'If format.PrintSetup.SupportsIdenticalCopies = True Then
    '            '    Dim copies As Integer = 1
    '            '    success = Int32.TryParse(txtIdenticalCopies.Text, copies) AndAlso (copies >= 1)
    '            '    If (Not success) Then
    '            '        MessageBox.Show(Me, "Identical Copies must be an integer greater than or equal to 1.", appName)
    '            '    Else
    '            '        format.PrintSetup.IdenticalCopiesOfLabel = copies
    '            '    End If
    '            'End If

    '            ' Assign number of serialized copies if it is not datasourced.
    '            'If success AndAlso (format.PrintSetup.SupportsSerializedLabels = True) Then
    '            '    Dim copies As Integer = 1
    '            '    success = True '' Int32.TryParse(txtSerializedCopies.Text, copies) AndAlso (copies >= 1)
    '            '    If (Not success) Then
    '            '        MessageBox.Show(Me, "Serialized Copies must be an integer greater than or equal to 1.", appName)
    '            '    Else
    '            '        format.PrintSetup.NumberOfSerializedLabels = copies
    '            '    End If
    '            'End If

    '            ' If there are no incorrect values in the copies boxes then print.
    '            'If success Then
    '            Cursor.Current = Cursors.WaitCursor

    '            ' Get the printer from the dropdown and assign it to the format.
    '            'If cboPrinters.SelectedItem IsNot Nothing Then
    '            '    format.PrintSetup.PrinterName = cboPrinters.SelectedItem.ToString()
    '            'End If

    '            Dim messages As Messages = Nothing
    '            Dim waitForCompletionTimeout As Integer = 6000 ' 10 seconds
    '            Dim result As Result = format.Print(appName, waitForCompletionTimeout, messages)
    '            Dim messageString As String = Constants.vbLf + Constants.vbLf & "Messages:"

    '            'For Each message As Seagull.BarTender.Print.Message In messages
    '            '    messageString &= Constants.vbLf + Constants.vbLf + message.Text
    '            'Next message
    '            format.Close(SaveOptions.DoNotSaveChanges)
    '            engine.Stop()
    '            'If result = result.Failure Then
    '            '    MessageBox.Show("Print Failed" & messageString, appName)
    '            'Else
    '            '    MessageBox.Show("Label was successfully sent to printer." & messageString, appName)
    '            'End If
    '            'End If
    '        End SyncLock

    '    End Sub

    '#End Region


#Region "模板打印打印"
    Sub FileToBarCodePrint(ByVal LableFile As String)
        Try
            btApp = New BarTender.ApplicationClass
            btFormat = btApp.Formats.Open(LableFile, False, String.Empty)
            btFormat.Print("", False, -1, Nothing)
            btFormat.Close(BarTender.BtSaveOptions.btSaveChanges)
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        Catch ex As Exception
            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            Throw New Exception(ex.Message.ToString())
        End Try
    End Sub

#End Region

End Class
