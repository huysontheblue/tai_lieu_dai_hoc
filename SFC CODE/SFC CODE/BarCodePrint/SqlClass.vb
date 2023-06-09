
'--打印作業程序公用類
'--Create by :　Airlo(楊三良)
'--Create date :　2007/3/1
'--Ver : V01的

'--Edit : 整理及優化
'--Time : 2007/4/17
'--by : Airlo(楊三良) 

#Region "Imports"

Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Text
Imports System.Data.SqlClient
Imports System.IO

#End Region

Public Class SqlClassM

#Region "類內部參數"



    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim mCodeRule As String
    Dim mPackId As String
    Dim mPackitem As String
    Dim mDisorderType As String
    Dim mPackingLevel As String
    Dim mVersionType As String
    Dim mVersion As String
    Dim mCustID As String
    Dim mCustName As String
    Dim mTaskid As String
    Dim mDefaultMoid As String
    Dim mDefaultLine As String
    Dim mFactory As String ''''
    Dim mDeptJm As String '''''D/C JM..
    Dim mShift As String
    Dim mLineJm As String
    Dim mRequestDate As String
    Dim mIsprint As String
    Dim mCodeType As String
    Dim mCustmerPN As String
    Dim mVerNo As String
    Dim mDriFlag As String
    Dim mBuildAttribute As String
    Dim mExtended1 As String
    Dim mExtended2 As String
    Dim mExtended3 As String
    Dim mPO As String
    Dim mDistributionFlag As String
    Dim mGroupPrintFlag As String
    Dim mSnDistributionCount As Int16
    Dim m_SectionCodeRule As Boolean = False
#End Region

#Region "窗體基本屬性"
    Public Property Extended1() As String

        Get
            Return mExtended1
        End Get
        Set(ByVal value As String)
            mExtended1 = value
        End Set

    End Property
    Public Property Extended2() As String

        Get
            Return mExtended2
        End Get
        Set(ByVal value As String)
            mExtended2 = value
        End Set

    End Property
    Public Property Extended3() As String

        Get
            Return mExtended3
        End Get
        Set(ByVal value As String)
            mExtended3 = value
        End Set

    End Property

    Public Property PackId() As String

        Get
            Return mPackId
        End Get
        Set(ByVal value As String)
            mPackId = value
        End Set

    End Property

    Public Property Packitem() As String

        Get
            Return mPackitem
        End Get
        Set(ByVal value As String)
            mPackitem = value
        End Set

    End Property

    Public Property DisorderType() As String

        Get
            Return mDisorderType
        End Get
        Set(ByVal value As String)
            mDisorderType = value
        End Set

    End Property

    Public Property PackingLevel() As String

        Get
            Return mPackingLevel
        End Get
        Set(ByVal value As String)
            mPackingLevel = value
        End Set

    End Property

    Public Property VersionType() As String

        Get
            Return mVersionType
        End Get
        Set(ByVal value As String)
            mVersionType = value
        End Set

    End Property

    Public Property Version() As String

        Get
            Return mVersion
        End Get
        Set(ByVal value As String)
            mVersion = value
        End Set

    End Property

    Public Property vBuildAttribute() As String

        Get
            Return mBuildAttribute
        End Get
        Set(ByVal value As String)
            mBuildAttribute = value
        End Set

    End Property

    Public Property vDriFlag() As String

        Get
            Return mDriFlag
        End Get
        Set(ByVal value As String)
            mDriFlag = value
        End Set

    End Property

    Public Property vVerNo() As String

        Get
            Return mVerNo
        End Get
        Set(ByVal value As String)
            mVerNo = value
        End Set

    End Property

    Public Property vCustmerPN() As String

        Get
            Return mCustmerPN
        End Get
        Set(ByVal value As String)
            mCustmerPN = value
        End Set

    End Property

    Public Property vCodeType() As String

        Get
            Return mCodeType
        End Get
        Set(ByVal value As String)
            mCodeType = value
        End Set

    End Property

    Public Property vIsprint() As String

        Get
            Return mIsprint
        End Get
        Set(ByVal value As String)
            mIsprint = value
        End Set

    End Property

    Public Property vRequestDate() As String

        Get
            Return mRequestDate
        End Get
        Set(ByVal value As String)
            mRequestDate = value
        End Set

    End Property

    Public Property vLineJm() As String

        Get
            Return mLineJm
        End Get
        Set(ByVal value As String)
            mLineJm = value
        End Set

    End Property

    Public Property vShift() As String

        Get
            Return mShift
        End Get
        Set(ByVal value As String)
            mShift = value
        End Set

    End Property

    Public Property Factory() As String

        Get
            Return mFactory
        End Get
        Set(ByVal value As String)
            mFactory = value
        End Set

    End Property


    Public Property DeptJm() As String

        Get
            Return mDeptJm
        End Get
        Set(ByVal value As String)
            mDeptJm = value
        End Set

    End Property


    Public Property CodeRule() As String

        Get
            Return mCodeRule
        End Get
        Set(ByVal value As String)
            mCodeRule = value
        End Set

    End Property

    Public Property CustID() As String

        Get
            Return mCustID
        End Get
        Set(ByVal value As String)
            mCustID = value
        End Set

    End Property

    Public Property CustName() As String

        Get
            Return mCustName
        End Get
        Set(ByVal value As String)
            mCustName = value
        End Set

    End Property

    Public Property Taskid() As String

        Get
            Return mTaskid
        End Get
        Set(ByVal value As String)
            mTaskid = value
        End Set

    End Property

    Public Property DefaultMoid() As String

        Get
            Return mDefaultMoid
        End Get
        Set(ByVal value As String)
            mDefaultMoid = value
        End Set

    End Property

    Public Property DefaultLine() As String

        Get
            Return mDefaultLine
        End Get
        Set(ByVal value As String)
            mDefaultLine = value
        End Set

    End Property

    Public Property PO() As String

        Get
            Return mPO
        End Get
        Set(ByVal value As String)
            mPO = value
        End Set

    End Property

    Public Property DistributionFlag() As String

        Get
            Return mDistributionFlag
        End Get
        Set(ByVal value As String)
            mDistributionFlag = value
        End Set

    End Property


    Public Property GroupPrintFlag() As String

        Get
            Return mGroupPrintFlag
        End Get
        Set(ByVal value As String)
            mGroupPrintFlag = value
        End Set

    End Property

    '分段流水号总个数
    Public Property SnDistributionCount() As String

        Get
            Return mSnDistributionCount
        End Get
        Set(ByVal value As String)
            mSnDistributionCount = value
        End Set

    End Property

    ''' <summary>
    ''' 不同机种流水分段区分
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SectionCodeRule() As Boolean

        Get
            Return m_SectionCodeRule
        End Get
        Set(ByVal value As Boolean)
            m_SectionCodeRule = value
        End Set

    End Property

#End Region

#Region "建制"

    Public Sub New()
        mCodeRule = ""
        mCustID = ""
        mCustName = ""
        mTaskid = ""
        mDefaultMoid = ""
        mDefaultLine = ""
    End Sub

#End Region

#Region "Dispose"

    Public Sub dispose()
        mCodeRule = ""
        mCustID = ""
        mCustName = ""
        mTaskid = ""
        mDefaultMoid = ""
        mDefaultLine = ""
    End Sub

#End Region

#Region "設置Form"

    Public Sub SetSplitContainer(ByRef SplitC As SplitContainer)

        SplitC.FixedPanel = FixedPanel.Panel1
        SplitC.BorderStyle = BorderStyle.None
        SplitC.SplitterWidth = 1
        SplitC.IsSplitterFixed = True

    End Sub

#End Region

#Region "裝載數據到窗體"

    Public Sub LoadDataToTSComboBox(ByVal Sqlstr As String, ByRef Cbo As Object)

        Dim RecReader As SqlDataReader
        Try
            RecReader = Conn.GetDataReader(Trim(Sqlstr))
            Cbo.Items.Clear()
            Do While RecReader.Read()
                Cbo.Items.Add(RecReader.GetString(0).ToString)
            Loop
            RecReader.Close()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub LoadDataToDataGrid(ByVal Sqlstr As String, ByRef DGrid As DataGridView)
        Dim I As Int16
        Dim RecTable As New DataTable
        DGrid.DataSource = Nothing
        Try
            DGrid.Rows.Clear()
            RecTable = Conn.GetDataTable(Trim(Sqlstr))

            With RecTable
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGrid.Rows.Add(.Rows(I)("CodeRuleID"), .Rows(I)("LabelType"), .Rows(I)("Remark"), .Rows(I)("Fstyle"), .Rows(I)("Fdest"), .Rows(I)("Flen"), .Rows(I)("Gflen"), .Rows(I)("UserName"), .Rows(I)("Intime"))
                    Next
                    DGrid.Refresh()
                    DGrid.Focus()
                    DGrid.CurrentCell = DGrid.Item(0, 0)
                    CodeRule = DGrid.Item(0, 0).Value
                Else
                    CodeRule = ""
                End If
                .Dispose()
            End With
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "日期轉換函數"

    Public Function ShowShortTime(ByVal DateTime1 As DateTime, ByVal ShowStyle As String) As String
        Dim I As Int16
        Dim Sqlstr As String
        Dim RecTable As New DataTable
        Dim ShortTime As String
        Dim WNum As Int16

        ShortTime = ""
        Try
            Select Case ShowStyle
                Case "W"
                    Sqlstr = "select datepart(wk,'" & DateTime1.Date & "') as WInt,datepart(dw,'" & DateTime1.Date & "') as WStr"
                    RecTable = Conn.GetDataTable(Trim(Sqlstr))
                    WNum = IIf(RecTable.Rows(0).Item("WStr").ToString <> "1", Int(RecTable.Rows(0).Item("WInt").ToString), Int(RecTable.Rows(0).Item("WInt").ToString) - 1)

                    Sqlstr = "select a.CodeUnit from m_SnUnitD_t as a join m_SnRuleD_t as b on a.UnitID=b.UnitID and b.CodeRuleID='" & CodeRule & "' and b.F_codeID='W' where a.CodeSort='" & Format(DateTime1, "yyyy").ToString & "-" & WNum & "'"
                    RecTable = Conn.GetDataTable(Trim(Sqlstr))
                    ShortTime = RecTable.Rows(0).Item("CodeUnit").ToString

                    RecTable.Dispose()
                Case "D"
                    Sqlstr = "select b.F_codestart,a.CodeUnit from m_SnUnitD_t  as a join (select F_codeID,F_codestart,UnitID from m_SnRuleD_t  where CodeRuleID='" & CodeRule & "' and F_codeID in('Y','M','D')) as b on a. UnitID=b. UnitID and a.CodeSort =case b.F_codeID when 'Y' then '" & _
                             Format(DateTime1, "yyyy").ToString & "' when 'M' then '" & Format(DateTime1, "MM").ToString & "' when 'D' then '" & Format(DateTime1, "dd").ToString & "' end order by b.F_codestart"
                    RecTable = Conn.GetDataTable(Trim(Sqlstr))
                    For I = 0 To RecTable.Rows.Count - 1
                        ShortTime = IIf(ShortTime = "", RecTable.Rows(I).Item("CodeUnit").ToString, ShortTime & RecTable.Rows(I).Item("CodeUnit").ToString)
                    Next

                    RecTable.Dispose()
                Case "DW"     '2009/11/11修改
                    Sqlstr = "select a.CodeUnit from m_SnUnitD_t as a join m_SnRuleD_t as b on a.UnitID=b.UnitID and b.CodeRuleID='" & CodeRule & "' and b.F_codeID='DW' where a.CodeSort=datepart(dw,dateadd(day, -1, '" & DateTime1.Date.ToString("yyyy/MM/dd") & "'))"
                    RecTable = Conn.GetDataTable(Sqlstr)
                    ShortTime = RecTable.Rows(0)("CodeUnit").ToString
                    RecTable.Dispose()
                Case "DY"     '2009/11/11修改
                    Sqlstr = "select a.CodeUnit from m_SnUnitD_t as a join m_SnRuleD_t as b on a.UnitID=b.UnitID and b.CodeRuleID='" & CodeRule & "' and b.F_codeID='DY' where a.CodeSort=datepart(dy,dateadd(day, -1, '" & DateTime1.Date.ToString("yyyy/MM/dd") & "'))"
                    RecTable = Conn.GetDataTable(Sqlstr)
                    ShortTime = RecTable.Rows(0)("CodeUnit").ToString
                    RecTable.Dispose()
            End Select

            Return ShortTime
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    '重載日期轉換函數 modi by frankie 20110804 增加周別判斷。 
    Public Function ShowShortTime(ByVal DateTime1 As DateTime, ByVal ShowStyle As String, ByVal Unitid As String) As String
        Dim Sqlstr As String = ""
        Dim RecTable As New DataTable
        Dim ShortTime As String = ""
        Dim WNum As Int16
        Dim year As String = ""
        Try
            Select Case ShowStyle
                Case "W"
                    Sqlstr = "select datepart(wk,'" & DateTime1.Date & "') as WInt,datepart(dw,'" & DateTime1.Date & "') as WStr,datepart(wk,'" & DateTime1.Date.AddDays(-1) & "') as WInt1"
                    RecTable = Conn.GetDataTable(Trim(Sqlstr))
                    '處理之後，星期一為每周第一天，星期日為最好一天。
                    WNum = IIf(RecTable.Rows(0).Item("WStr").ToString <> "1", Int(RecTable.Rows(0).Item("WInt").ToString), Int(RecTable.Rows(0).Item("WInt1").ToString))

                    If Unitid = "W2" Then
                        'AVC標準周別
                        Sqlstr = "select datepart(dw,'" & DateTime1.Year & "/01/01') as da,datepart(wk,'" & DateTime1.AddYears(-1).Year & "/12/31') as ye"
                        RecTable = Conn.GetDataTable(Trim(Sqlstr))
                        If RecTable.Rows(0).Item("da").ToString <> "1" Then   '判斷本年第一天是否是星期天，如果是，則不操作。
                            If WNum > 1 Then        '
                                WNum = WNum - 1    '如周別不是第一周，且本年第一天不是星期天，則周別需減去1。
                            Else
                                WNum = Int(RecTable.Rows(0).Item("ye").ToString)  '如周別為第一周，且本年第一天不是星期天，則周別取前一年的最后一周。
                            End If
                        End If

                        Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and CodeSort='" & WNum & "'"
                    ElseIf Unitid = "W3" Then   '如果是第3周，則直接取日期等于今天的周別碼  
                        Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and  datediff(d,CodeSort,'" & DateTime1.Date.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo) & "' )=0"
                    ElseIf Unitid = "W4" Then   '如果是第4周，則直接取日期等于今天的周別碼  
                        Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and  datediff(d,CodeSort,'" & DateTime1.Date.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo) & "')=0"
                    Else
                        Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and CodeSort='" & Format(DateTime1, "yyyy").ToString & "-" & WNum & "'"
                    End If
                Case "Y"
                    '含有AVC標準周別的條碼，其年碼需做特殊處理。
                    Sqlstr = "select 1 from m_SnRuleD_t where UnitID='W2' and coderuleid='" & CodeRule & "'"
                    RecTable = Conn.GetDataTable(Trim(Sqlstr))
                    If RecTable.Rows.Count > 0 Then
                        'AVC標準周別
                        Sqlstr = " select datepart(wk,'" & DateTime1.Date & "') as WInt,datepart(dw,'" & DateTime1.Date & "') as WStr,datepart(wk,'" & DateTime1.Date.AddDays(-1) & "') as WInt1, " _
                               & " datepart(dw,'" & DateTime1.Year & "/01/01') as da,datepart(wk,'" & DateTime1.AddYears(-1).Year & "/12/31') as ye"
                        RecTable = Conn.GetDataTable(Trim(Sqlstr))
                        '處理之後，星期一為每周第一天，星期日為最好一天。
                        WNum = IIf(RecTable.Rows(0).Item("WStr").ToString <> "1", Int(RecTable.Rows(0).Item("WInt").ToString), Int(RecTable.Rows(0).Item("WInt1").ToString))
                        If (RecTable.Rows(0).Item("da").ToString <> "1" AndAlso WNum = 1) OrElse (RecTable.Rows(0).Item("da").ToString = "1" AndAlso WNum = RecTable.Rows(0).Item("ye").ToString) Then
                            '該年第一天不是星期天，且周別取了該年的第一周；或該年第一天是星期天，且周別取的是前一年的最後一周；則年碼都需為前一年。
                            Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and CodeSort='" & DateTime1.AddYears(-1).ToString("yyyy") & "'"
                            Exit Select
                        End If
                    End If
                    Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and CodeSort='" & DateTime1.ToString("yyyy") & "'"
                Case "M"
                    Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and CodeSort='" & DateTime1.ToString("MM") & "'"
                Case "D"
                    Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and CodeSort='" & DateTime1.ToString("dd") & "'"
                Case "DW"
                    '修改為正常取日期，不能減一天 by frankie20110810
                    'Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and CodeSort=datepart(dw,dateadd(day, -1, '" & DateTime1.Date.ToString("yyyy/MM/dd") & "'))"
                    Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and CodeSort=datepart(dw, '" & DateTime1.Date.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo) & "')"
                Case "DY"
                    '修改為正常取日期，不能減一天 modi by frankie20110810
                    '將DY2單獨列出來,DY2用日期進行對比。 add by frankie 20110819
                    If Unitid = "DY2" Then
                        Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and datediff(d,CodeSort,'" & DateTime1.Date.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo) & "')=0"
                    ElseIf Unitid = "DY3" Then
                        Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and CodeSort='" & DateTime1.Date.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo) & "'"
                    Else
                        'Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and CodeSort=datepart(dy,dateadd(day, -1, '" & DateTime1.Date.ToString("yyyy/MM/dd") & "'))"
                        Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & Unitid & "' and CodeSort=datepart(dy, '" & DateTime1.Date.ToString("yyyy/MM/dd", System.Globalization.DateTimeFormatInfo.InvariantInfo) & "')"
                    End If
            End Select
            RecTable = Conn.GetDataTable(Sqlstr)
            ShortTime = RecTable.Rows(0)("CodeUnit").ToString
            RecTable.Dispose()
            Return ShortTime
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "布尔转换函数"

    Public Shared Function StringToBoolean(ByVal strValue As String) As Boolean
        If (strValue = "N") Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function BooleanToString(ByVal bValue As Boolean) As String
        If bValue Then
            Return "Y"
        Else
            Return "N"
        End If
    End Function
#End Region

#Region "获取本地打印机列表"

    Public Shared Sub GetPrintersList(ByVal CboName As ComboBox)
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            CboName.Items.Add(iprt)
        Next
    End Sub

    Public Shared Sub GetPrintersList(ByVal CboName As DataGridViewComboBoxColumn)
        CboName.Items.Clear()
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            CboName.Items.Add(iprt)
        Next
    End Sub

    Public Shared Function CheckPrintersList(ByVal PrintName As String) As Boolean
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            If (iprt.Trim = PrintName) Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region
    ''#Region "建立臨時打印文件"

    ''Public Sub PrintFile(ByVal FileStr As String)
    ''    Dim MyTextFilePath As String = Application.StartupPath & "\temp.txt"
    ''    Dim Sw As StreamWriter

    ''    Sw = File.CreateText(MyTextFilePath)
    ''    Sw.WriteLine(FileStr)
    ''    Sw.Flush()
    ''    Sw.Close()

    ''End Sub

    ''#End Region

#Region "檢查編碼原則是否含有校驗位"

    Public Function CheckCodeRule(ByVal CodeRuleID As String) As Boolean
        Dim RecTable As SqlDataReader = Nothing
        Try
            RecTable = Conn.GetDataReader("select top 1 1 from m_SnRuleD_t where F_codeID='XC' and CodeRuleID='" & CodeRuleID & "'")
            If RecTable.HasRows Then
                RecTable.Close()
                Return True
            End If
            RecTable.Close()
            Return False
        Catch ex As Exception
            RecTable.Close()
            Return False
            Throw ex
        End Try
    End Function
    '產生檢驗位
    Public Function GetChkCode(ByVal sSerialNo As String, ByVal HtSn As Hashtable, ByVal ReHtSn As Hashtable, ByVal UnitLen As Integer) As String

        Try
            Dim iLoop As Integer
            Dim SumOdd As Integer = 0
            Dim SumEven As Integer = 0
            Dim SumTotal As Integer
            Dim ChkDigit As Integer
            Dim ChkDigitValue As String
            Dim ArrSnChar() As Char
            Dim TmpTable As New DataTable

            If sSerialNo = "" Then
                Return ""
            End If
            ' 循環 sSerialNo 中的字符
            ' 加總奇數位 (SumOdd)
            ' 加總偶數位 (SumEven)
            ArrSnChar = sSerialNo.ToCharArray()
            For iLoop = 0 To ArrSnChar.Length - 1
                If (iLoop Mod 2) = 0 Then
                    SumEven = SumEven + CInt(HtSn.Item(ArrSnChar(iLoop).ToString()))
                Else
                    SumOdd = SumOdd + CInt(HtSn.Item(ArrSnChar(iLoop).ToString()))
                End If
            Next
            '奇數位總和*3 +偶數位總和
            SumTotal = SumEven + SumOdd * 3
            '校驗數字  進制長度-（校驗位總和 mod 進制長度）
            If (SumTotal Mod UnitLen) = 0 Then
                ChkDigit = 0
            Else
                ChkDigit = UnitLen - (SumTotal Mod UnitLen)
            End If
            '校驗數字對應的值
            ChkDigitValue = ReHtSn.Item(CStr(ChkDigit)).ToString()
            '返回帶校驗碼的流水號
            'If mCodeRule = "B014" Then
            '    If InStr(sSerialNo, "_") > 0 Then
            '        Return sSerialNo.Split("_")(0) + ChkDigitValue + "_CC"
            '    Else
            '        Return sSerialNo + ChkDigitValue + "_CC"
            '    End If

            'Else
            Return sSerialNo + ChkDigitValue
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            Return ""
        End Try

    End Function

    ''产生索尼条码校验码
    'Public Function GenChecksumValue(ByVal sSerialNo As String) As String
    '    '方法：C1 = ((16 – (((13 * (Y1+W1+S1+P1+X2+X4+X6)) + (Y2+W2+S2+X1+X3+X5)) mod 16)) mod 16) 16
    '    ' C2 = ((16 – (((7 * (Y1+W1+S1+P1+X1+X3+X5)) + (Y2+W2+S2+C1+X2+X4+X6)) mod 16)) mod 16) 16
    '    Dim OldSerialNo As String = sSerialNo
    '    sSerialNo = sSerialNo.Substring(23)
    '    Dim b As Integer = Int32.Parse("A", System.Globalization.NumberStyles.HexNumber)
    '    Try
    '        Dim iLoop As Integer
    '        Dim SumOdd As Integer = 0
    '        Dim SumEven As Integer = 0
    '        Dim SumTotal As Integer
    '        Dim ArrSnChar() As Char
    '        Dim SeArrSnChar() As Char
    '        'Dim TmpTable As New DataTable
    '        Dim Frist As String = ""
    '        If sSerialNo = "" Then
    '            Return ""
    '        End If
    '        ' 循環 sSerialNo 中的字符
    '        ' 加總奇數位 (SumOdd)
    '        ' 加總偶數位 (SumEven)
    '        ArrSnChar = sSerialNo.ToCharArray()
    '        For iLoop = 0 To ArrSnChar.Length - 1
    '            If (iLoop Mod 2) = 0 Then
    '                SumEven = SumEven + Int32.Parse((ArrSnChar(iLoop).ToString()), System.Globalization.NumberStyles.HexNumber)
    '            Else
    '                SumOdd = SumOdd + Int32.Parse((ArrSnChar(iLoop).ToString()), System.Globalization.NumberStyles.HexNumber)
    '            End If
    '        Next

    '        ''*******************索尼校验码算法***************************
    '        ''@第一位校验码
    '        SumTotal = SumEven * 13 + SumOdd
    '        SumTotal = SumTotal Mod 16
    '        SumTotal = 16 - SumTotal
    '        SumTotal = SumTotal Mod 16
    '        Frist = Hex(SumTotal).ToString
    '        ''@第二位校验码

    '        sSerialNo = sSerialNo.Insert(7, Frist)
    '        SeArrSnChar = sSerialNo.ToCharArray()
    '        SumEven = 0 : SumOdd = 0 : SumTotal = 0
    '        For iLoop = 0 To SeArrSnChar.Length - 1
    '            If (iLoop Mod 2) = 0 Then
    '                SumEven = SumEven + Int32.Parse((SeArrSnChar(iLoop).ToString()), System.Globalization.NumberStyles.HexNumber)
    '            Else
    '                SumOdd = SumOdd + Int32.Parse((SeArrSnChar(iLoop).ToString()), System.Globalization.NumberStyles.HexNumber)
    '            End If
    '        Next
    '        SumTotal = 7 * SumEven + SumOdd
    '        SumTotal = SumTotal Mod 16
    '        SumTotal = 16 - SumTotal
    '        SumTotal = SumTotal Mod 16
    '        Frist = Hex(SumTotal).ToString
    '        ''************************************************************

    '        '奇數位總和*3 +偶數位總和

    '        'Return sSerialNo + Frist
    '        Return OldSerialNo.Substring(0, 23) + sSerialNo + Frist
    '        'End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message.ToString)
    '        Return ""
    '    End Try

    'End Function
    ''产生索尼条码校验码
    Public Function GenChecksumValue(ByVal sSerialNo As String) As String
        '方法：C1 = ((16 – (((13 * (Y1+W1+S1+P1+X2+X4+X6)) + (Y2+W2+S2+X1+X3+X5)) mod 16)) mod 16) 16
        ' C2 = ((16 – (((7 * (Y1+W1+S1+P1+X1+X3+X5)) + (Y2+W2+S2+C1+X2+X4+X6)) mod 16)) mod 16) 16

        Dim str As String = ""
        str = sSerialNo.Substring(0, 22)
        sSerialNo = sSerialNo.Substring(22)

        Dim b As Integer = Int32.Parse("A", System.Globalization.NumberStyles.HexNumber)
        Try
            Dim iLoop As Integer
            Dim SumOdd As Integer = 0
            Dim SumEven As Integer = 0
            Dim SumTotal As Integer
            Dim ArrSnChar() As Char
            Dim SeArrSnChar() As Char
            'Dim TmpTable As New DataTable
            Dim Frist As String = ""
            If sSerialNo = "" Then
                Return ""
            End If
            ' 循環 sSerialNo 中的字符
            ' 加總奇數位 (SumOdd)
            ' 加總偶數位 (SumEven)
            ArrSnChar = sSerialNo.ToCharArray()
            For iLoop = 0 To ArrSnChar.Length - 1
                If (iLoop Mod 2) = 0 Then
                    SumEven = SumEven + Int32.Parse((ArrSnChar(iLoop).ToString()), System.Globalization.NumberStyles.HexNumber)
                Else
                    SumOdd = SumOdd + Int32.Parse((ArrSnChar(iLoop).ToString()), System.Globalization.NumberStyles.HexNumber)
                End If
            Next

            ''*******************索尼校验码算法***************************
            ''@第一位校验码
            SumTotal = SumEven * 13 + SumOdd
            SumTotal = SumTotal Mod 16
            SumTotal = 16 - SumTotal
            SumTotal = SumTotal Mod 16
            Frist = Hex(SumTotal).ToString
            ''@第二位校验码

            sSerialNo = sSerialNo.Insert(7, Frist)
            SeArrSnChar = sSerialNo.ToCharArray()
            SumEven = 0 : SumOdd = 0 : SumTotal = 0
            For iLoop = 0 To SeArrSnChar.Length - 1
                If (iLoop Mod 2) = 0 Then
                    SumEven = SumEven + Int32.Parse((SeArrSnChar(iLoop).ToString()), System.Globalization.NumberStyles.HexNumber)
                Else
                    SumOdd = SumOdd + Int32.Parse((SeArrSnChar(iLoop).ToString()), System.Globalization.NumberStyles.HexNumber)
                End If
            Next
            SumTotal = 7 * SumEven + SumOdd
            SumTotal = SumTotal Mod 16
            SumTotal = 16 - SumTotal
            SumTotal = SumTotal Mod 16
            Frist = Hex(SumTotal).ToString
            ''************************************************************

            '奇數位總和*3 +偶數位總和

            Return str + sSerialNo + Frist
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            Return ""
        End Try

    End Function

    Public Function GenChecksumValue(ByVal sSerialNo As String, ByVal codeRuleId As String) As String
        '方法：C1 = ((16 – (((13 * (Y1+W1+S1+P1+X2+X4+X6)) + (Y2+W2+S2+X1+X3+X5)) mod 16)) mod 16) 16  
        'C2 = ((16 – (((7 * (Y1+W1+S1+P1+X1+X3+X5)) + (Y2+W2+S2+C1+X2+X4+X6)) mod 16)) mod 16) 16

        Dim str As String = ""
        str = sSerialNo.Substring(0, 7)
        sSerialNo = str + sSerialNo.Substring(9, 6)

        Dim b As Integer = Int32.Parse("A", System.Globalization.NumberStyles.HexNumber)
        Try
            Dim iLoop As Integer
            Dim SumOdd As Integer = 0
            Dim SumEven As Integer = 0
            Dim SumTotal As Integer
            Dim ArrSnChar() As Char
            Dim SeArrSnChar() As Char
            'Dim TmpTable As New DataTable
            Dim Frist As String = ""
            If sSerialNo = "" Then
                Return ""
            End If
            ' 循環 sSerialNo 中的字符
            ' 加總奇數位 (SumOdd)
            ' 加總偶數位 (SumEven)
            ArrSnChar = sSerialNo.ToCharArray()
            For iLoop = 0 To ArrSnChar.Length - 1
                If (iLoop Mod 2) = 0 Then
                    SumEven = SumEven + Int32.Parse((ArrSnChar(iLoop).ToString()), System.Globalization.NumberStyles.HexNumber)
                Else
                    SumOdd = SumOdd + Int32.Parse((ArrSnChar(iLoop).ToString()), System.Globalization.NumberStyles.HexNumber)
                End If
            Next

            ''*******************索尼校验码算法***************************
            ''@第一位校验码
            SumTotal = SumEven * 13 + SumOdd
            SumTotal = SumTotal Mod 16
            SumTotal = 16 - SumTotal
            SumTotal = SumTotal Mod 16
            Frist = Hex(SumTotal).ToString
            ''@第二位校验码

            sSerialNo = sSerialNo.Insert(7, Frist)
            SeArrSnChar = sSerialNo.ToCharArray()
            SumEven = 0 : SumOdd = 0 : SumTotal = 0
            For iLoop = 0 To SeArrSnChar.Length - 1
                If (iLoop Mod 2) = 0 Then
                    SumEven = SumEven + Int32.Parse((SeArrSnChar(iLoop).ToString()), System.Globalization.NumberStyles.HexNumber)
                Else
                    SumOdd = SumOdd + Int32.Parse((SeArrSnChar(iLoop).ToString()), System.Globalization.NumberStyles.HexNumber)
                End If
            Next
            SumTotal = 7 * SumEven + SumOdd
            SumTotal = SumTotal Mod 16
            SumTotal = 16 - SumTotal
            SumTotal = SumTotal Mod 16
            Frist = Hex(SumTotal).ToString
            ''************************************************************

            '奇數位總和*3 +偶數位總和

            Return sSerialNo + Frist 'str + sSerialNo + Frist
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            Return ""
        End Try

    End Function

#End Region

#Region "檢查工單"

    Public Function CheckMoid(ByVal Moid As String, ByVal LabelStyle As String, ByVal CodeRuleid As String) As String
        Dim Sqlstr As String = ""
        Dim RecTable As New DataTable
        Try
            'Sqlstr = "declare @ReturnStr varchar(100) declare @FinalY varchar(1) declare @UseY varchar(1) declare @Line varchar(10) " & _
            '         " select @FinalY=FinalY,@Line=lineid from m_Mainmo_t where moid='" & Moid & "' if @@rowcount=0 begin SET @ReturnStr='工單在ERP上未維護，或者未下載到系統里面！' GoTo Rturn End " & _
            '         " if @FinalY='Y' begin SET @ReturnStr='工單已經結案！' GoTo Rturn End " & _
            '         " select @UseY=a.usey from m_SnPartSet_t as a join m_Mainmo_t as b on a.TAvcPart=b.Partid and b.moid='" & Moid & "' join m_PartPack_t as c on a.TAvcPart=c.Partid and c.Packid='" & LabelStyle & "' and a.CodeRuleID=c.CodeRuleID where a.usey<>'N' " & _
            '         " if @@rowcount=0 begin SET @ReturnStr='料件沒有維護打印參數' GoTo Rturn End if @UseY='P' begin SET @ReturnStr='料件的打印參數沒有確認！' GoTo Rturn End " & _
            '         " set @ReturnStr='1' Rturn: select @ReturnStr as ReStr "
            Sqlstr = "declare @ReturnStr varchar(100) declare @FinalY varchar(1) declare @UseY varchar(1) declare @Line varchar(10) " & _
                    " select @FinalY=FinalY,@Line=lineid from m_Mainmo_t where moid='" & Moid & "' if @@rowcount=0 begin SET @ReturnStr='工單在ERP上未維護，或者未下載到系統里面！' GoTo Rturn End " & _
                    " if @FinalY='Y' begin SET @ReturnStr='工單已經結案！' GoTo Rturn End " & _
                    " select @UseY=a.usey from m_PartPack_t as a join m_Mainmo_t as b on a.Partid=b.Partid and b.moid='" & Moid & "' where a.usey<>'N' and a.Packid='" & LabelStyle & "' " & _
                    " if @@rowcount=0 begin SET @ReturnStr='料件沒有維護打印參數' GoTo Rturn End if @UseY='P' begin SET @ReturnStr='料件的打印參數沒有確認！' GoTo Rturn End " & _
                    " if @UseY='C' begin SET @ReturnStr='料件未設置打印格式！' GoTo Rturn End set @ReturnStr='1' Rturn: select @ReturnStr as ReStr "
            RecTable = Conn.GetDataTable(Sqlstr)
            Return RecTable.Rows(0)(0).ToString
        Catch ex As Exception
            Return "0"
            Throw ex
        End Try
    End Function

#End Region

#Region "產生樣式"

    Public Function MakeStyle(ByRef BarCodePart(,) As String, ByVal BarCodePartNum As Int16) As String
        Dim I, J As Int16
        Dim Sqlstr As String
        Dim RecTable As New DataTable
        Dim BarCodeStyle As New StringBuilder
        Dim Obj As New Object
        Try
            '產生樣式
            Sqlstr = "select  f_codeid,f_orderid,isstyle,f_codelen from m_SnRuleD_t where coderuleid='" & mCodeRule & "' and bararea='barcode1' and f_codeid not in('Y','M') order by f_orderid"
            RecTable = Conn.GetDataTable(Sqlstr)
            For I = 0 To RecTable.Rows.Count - 1
                If RecTable.Rows(I)("isstyle").ToString = "Y" Then
                    For J = 1 To BarCodePartNum
                        If BarCodePart(1, J) = RecTable.Rows(I).Item("F_codeID").ToString AndAlso BarCodePart(4, J) = 1 Then
                            BarCodeStyle.Append(BarCodePart(2, J))
                            BarCodePart(4, J) = 2
                        End If
                    Next
                Else
                    BarCodeStyle.Append(StrDup(CInt(RecTable.Rows(I)("f_codelen").ToString), RecTable.Rows(I)("f_codeid").ToString))
                End If
            Next
            RecTable.Dispose()
            For I = 1 To BarCodePartNum
                BarCodePart(4, I) = 1
            Next

            Return BarCodeStyle.ToString
        Catch ex As Exception
            Throw ex
            Return ""
        End Try
    End Function

#End Region

#Region "同标签多流水码"

#Region "生成流水碼"

    Public Function AtrriMarkSBCode(ByVal TempSBCode As StringBuilder, ByVal CurrCodePos As Int16, ByVal SBCodeLEN As Int16, ByVal SBCodeUnit(,) As String, ByVal CurrCodeUnitTable As DataTable) As StringBuilder
        Dim CurrCodeUnitView As New DataView
        Dim CurrRowView As DataRowView
        Dim CurrLow As String
        Dim CurrUnitPos As Int16

        CurrLow = TempSBCode.ToString.Substring(SBCodeLEN - CurrCodePos, 1)
        CurrCodeUnitView = New DataView(CurrCodeUnitTable)
        CurrCodeUnitView.RowFilter = "UnitID='" & SBCodeUnit(SBCodeLEN - CurrCodePos, 1) & "'"
        CurrCodeUnitView.Sort = "CodeSort asc"

        For Each CurrRowView In CurrCodeUnitView
            If CurrRowView.Item("CodeUnit").ToString = CurrLow Then
                CurrUnitPos = CInt(CurrRowView.Item("CodeSort").ToString.Trim)
                Exit For
            End If
        Next

        If CurrUnitPos < (CInt(SBCodeUnit(SBCodeLEN - CurrCodePos, 2)) - 1) Then
            CurrUnitPos = CurrUnitPos + 1
            For Each CurrRowView In CurrCodeUnitView
                If CurrUnitPos = CInt(CurrRowView.Item("CodeSort").ToString.Trim) Then
                    CurrLow = CurrRowView.Item("CodeUnit").ToString
                    Exit For
                End If
            Next
            TempSBCode.Remove(SBCodeLEN - CurrCodePos, 1)
            TempSBCode.Insert(SBCodeLEN - CurrCodePos, CurrLow, 1)
            Return TempSBCode

            Exit Function
        Else
            CurrUnitPos = 0
            For Each CurrRowView In CurrCodeUnitView
                If CurrUnitPos = CInt(CurrRowView.Item("CodeSort").ToString.Trim) Then
                    CurrLow = CurrRowView.Item("CodeUnit").ToString
                    Exit For
                End If
            Next
            TempSBCode.Remove(SBCodeLEN - CurrCodePos, 1)
            TempSBCode.Insert(SBCodeLEN - CurrCodePos, CurrLow, 1)

            If CurrCodePos = SBCodeLEN Then
                MsgBox("編碼原則允許的數量已達上限！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Return Nothing
            Else
                TempSBCode = MarkSBCode(TempSBCode, CurrCodePos + 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable)
                Return TempSBCode
            End If
        End If
        CurrCodeUnitView.Dispose()
    End Function

#End Region

    Public Sub SetAttributeSBCode(ByRef CurrSBCode As StringBuilder, ByRef SBCodeLEN As Int16, ByRef SBCodeUnit(,) As String, ByVal BarCodeStyleMax As String)
        Dim I As Int16
        Dim Sqlstr As String
        Dim RecTable As New DataTable
        'Dim BarCodeStyleMax As String = ""
        Try
            Sqlstr = "select a.F_orderid,a.UnitID,b.UnitLen,c.CodeUnit from m_SnRuleD_t as a join m_SnUnitM_t as b on a.CodeRuleID='" & CodeRule & "' and a.F_codeID='S' and a.BarArea='BarCode2' and a.unitid=b.unitid join m_SnUnitD_t as c on a.unitid=c.unitid and c.CodeSort='0' order by F_orderid asc"
            RecTable = Conn.GetDataTable(Sqlstr)

            If RecTable.Rows.Count > 0 Then
                SBCodeLEN = RecTable.Rows.Count
                ReDim SBCodeUnit(SBCodeLEN - 1, 2)
                For I = 0 To RecTable.Rows.Count - 1
                    SBCodeUnit(I, 1) = RecTable.Rows(I).Item("UnitID").ToString
                    SBCodeUnit(I, 2) = RecTable.Rows(I).Item("UnitLen").ToString
                    CurrSBCode.Append(RecTable.Rows(I).Item("CodeUnit").ToString)
                Next I
            End If
            'If CurrSBCode.Length <> BarCodeStyleMax Then
            '    MessageBox.Show("料件打印参数设置的起始流水码与编码原则设置不符...")
            '    Exit Sub
            'End If
            If BarCodeStyleMax = "" OrElse BarCodeStyleMax = "0" Then
            Else
                CurrSBCode.Remove(0, CurrSBCode.Length)
                CurrSBCode.Append(BarCodeStyleMax)
            End If

            RecTable.Dispose()
            Conn.PubConnection.Close()
        Catch ex As Exception
            Throw ex
            'Finally
            '    Conn.PubConnection.Close()
            '    Conn = Nothing
        End Try
    End Sub

    Public Function AtrriSetCurrCodeUnitTable(ByVal SBCodeLEN As Int16, ByVal SBCodeUnit(,) As String) As DataTable
        Dim I As Int16
        Dim Sqlstr As String

        Try
            Sqlstr = "select UnitID,CodeSort,CodeUnit from m_SnUnitD_t where UnitID in('"
            For I = 0 To SBCodeLEN - 1
                If I = SBCodeLEN - 1 Then
                    Sqlstr = Sqlstr & SBCodeUnit(I, 1) & "')"
                Else
                    Sqlstr = Sqlstr & SBCodeUnit(I, 1) & "','"
                End If
            Next I
            Return Conn.GetDataTable(Sqlstr)
        Catch ex As Exception
            Throw ex
        Finally
            Conn.PubConnection.Close()

        End Try
    End Function

#End Region

#Region "轉換流水碼"

    Public Function CodeToInt(ByVal CodeSn As String, ByVal CodeRule As String) As Int64
        Dim SBCodeLEN As Int16
        Dim UnitCode(,) As String
        Dim IntS As Int64 = 0
        Dim I As Int16
        Dim Sqlstr As String
        Dim RecTable As New DataTable

        Try
            Sqlstr = "select b.F_orderid,b.UnitID,a.UnitLen from m_SnUnitM_t as a join (select F_orderid,UnitID from m_SnRuleD_t where CodeRuleID='" & CodeRule & "' and F_codeID='S' and BarArea='BarCode1') as b on a.UnitID=b.UnitID order by b.F_orderid desc"
            RecTable = Conn.GetDataTable(Sqlstr)
            If RecTable.Rows.Count = 0 Then Exit Try

            SBCodeLEN = RecTable.Rows.Count
            ReDim UnitCode(2, RecTable.Rows.Count)
            For I = 0 To RecTable.Rows.Count - 1
                UnitCode(1, I) = RecTable.Rows(I).Item("UnitID").ToString
                UnitCode(2, I) = RecTable.Rows(I).Item("UnitLen").ToString
            Next
            RecTable.Dispose()

            For I = 0 To SBCodeLEN - 1
                Sqlstr = "select CodeSort from m_SnUnitD_t where UnitID='" & UnitCode(1, I) & "' and CodeUnit='" & Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(CodeSn, I + 1), 1) & "'"
                RecTable = Conn.GetDataTable(Sqlstr)
                If I <> 0 Then
                    IntS = IntS + Int(RecTable.Rows(0).Item("CodeSort")) * DiGui(I, UnitCode)
                Else
                    IntS = IntS + Int(RecTable.Rows(0).Item("CodeSort"))
                End If
            Next
            RecTable.Dispose()
            Return IntS
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function IntToCode(ByVal IntS As Int64, ByVal CodeRule As String) As String
        Dim SBCodeLEN As Int16
        Dim UnitCode(,) As String
        Dim CodeSn As String = ""
        Dim TempCodeInt As Int64 = 0
        Dim I As Int16
        Dim Sqlstr As String
        Dim RecTable As New DataTable

        Try
            Sqlstr = "select b.F_orderid,b.UnitID,a.UnitLen from m_SnUnitM_t as a join m_SnRuleD_t  as b on b.CodeRuleID='" & CodeRule & "' and b.F_codeID='S' and b.BarArea='BarCode1' and a.UnitID=b.UnitID order by b.F_orderid desc"
            RecTable = Conn.GetDataTable(Sqlstr)
            If RecTable.Rows.Count = 0 Then Exit Try
            SBCodeLEN = RecTable.Rows.Count
            ReDim UnitCode(2, RecTable.Rows.Count)
            For I = 0 To RecTable.Rows.Count - 1
                UnitCode(1, I) = RecTable.Rows(I).Item("UnitID").ToString
                UnitCode(2, I) = RecTable.Rows(I).Item("UnitLen").ToString
            Next
            RecTable.Dispose()

            I = 0
            Do
                If I >= UnitCode.GetUpperBound(1) Then
                    MsgBox("此料件當天生產數量已達上限，流水號已用完！", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "系統提示")
                    Return ""
                End If
                TempCodeInt = IntS Mod Int(UnitCode(2, I))
                Sqlstr = "select CodeUnit from m_SnUnitD_t where UnitID='" & UnitCode(1, I) & "' and CodeSort='" & TempCodeInt & "'"
                RecTable = Conn.GetDataTable(Sqlstr)
                CodeSn = RecTable.Rows(0).Item("CodeUnit").ToString & CodeSn
                IntS = Int(IntS / Int(UnitCode(2, I)))
                I += 1
                RecTable.Dispose()
            Loop While IntS <> 0
            CodeSn = StrDup(SBCodeLEN - Len(CodeSn), "0") & CodeSn
            Return CodeSn
        Catch ex As Exception
            Return ""
        End Try
        Return ""
    End Function

    Private Function DiGui(ByVal i As Int16, ByVal UnitCode(,) As String) As Int64
        If i = 0 Then
            Return 1
        Else
            Return Int(UnitCode(2, i - 1)) * DiGui(i - 1, UnitCode)
        End If
    End Function

#End Region

#Region "生成流水號及其準備"

#Region "生成條碼准備"

    Public Sub SetSBCode(ByRef CurrSBCode As StringBuilder, ByRef SBCodeLEN As Int16, ByRef SBCodeUnit(,) As String, ByVal BarCodeStyleMax As String)
        Dim I As Int16
        Dim Sqlstr As String
        Dim RecTable As New DataTable

        Try
            Sqlstr = " SELECT a.F_orderid,a.UnitID,b.UnitLen,c.CodeUnit " & _
                     " FROM m_SnRuleD_t as a join m_SnUnitM_t as b on a.CodeRuleID='" & CodeRule & "' and a.F_codeID='S' " & _
                     " and a.BarArea='BarCode1' and a.unitid=b.unitid join m_SnUnitD_t as c on a.unitid=c.unitid and c.CodeSort='0' order by F_orderid asc"
            RecTable = Conn.GetDataTable(Sqlstr)

            If RecTable.Rows.Count > 0 Then
                SBCodeLEN = RecTable.Rows.Count
                ReDim SBCodeUnit(SBCodeLEN - 1, 2)
                For I = 0 To RecTable.Rows.Count - 1
                    SBCodeUnit(I, 1) = RecTable.Rows(I).Item("UnitID").ToString
                    SBCodeUnit(I, 2) = RecTable.Rows(I).Item("UnitLen").ToString
                    CurrSBCode.Append(RecTable.Rows(I).Item("CodeUnit").ToString)
                Next I
            End If

            If BarCodeStyleMax = "" OrElse BarCodeStyleMax = "0" Then
            Else
                CurrSBCode.Remove(0, CurrSBCode.Length)
                CurrSBCode.Append(BarCodeStyleMax)
            End If

            RecTable.Dispose()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SqlClass", "SetSBCode", "BarcodePrint")
            Throw ex
        End Try
    End Sub

    Public Function SetCurrCodeUnitTable(ByVal SBCodeLEN As Int16, ByVal SBCodeUnit(,) As String) As DataTable
        Dim I As Int16
        Dim Sqlstr As String

        Try

            Sqlstr = "select UnitID,CodeSort,CodeUnit from m_SnUnitD_t where UnitID in('"
            For I = 0 To SBCodeLEN - 1
                If I = SBCodeLEN - 1 Then
                    Sqlstr = Sqlstr & SBCodeUnit(I, 1) & "')"
                Else
                    Sqlstr = Sqlstr & SBCodeUnit(I, 1) & "','"
                End If
            Next I
            Return Conn.GetDataTable(Sqlstr)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SqlClass", "SetCurrCodeUnitTable", "BarcodePrint")
            Throw ex
        End Try
    End Function
    '设置分段流水号区间数组
    Public Sub SetSnDistributionArr(ByRef SNDistributionArr(,) As String, ByVal dtSnDistribution As DataTable)
        Dim I As Int32
        Dim SnLen As Int32
        Try
            If dtSnDistribution.Rows.Count > 0 Then
                SnLen = dtSnDistribution.Rows.Count

                ReDim SNDistributionArr(SnLen - 1, 2)
                For I = 0 To dtSnDistribution.Rows.Count - 1
                    SNDistributionArr(I, 1) = dtSnDistribution.Rows(I).Item("MinSN").ToString
                    SNDistributionArr(I, 2) = dtSnDistribution.Rows(I).Item("MaxSN").ToString
                Next I
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "生成流水碼"

    Public Function MarkSBCode(ByVal TempSBCode As StringBuilder, ByVal CurrCodePos As Int16, ByVal SBCodeLEN As Int16, ByVal SBCodeUnit(,) As String, ByVal CurrCodeUnitTable As DataTable) As StringBuilder
        Dim CurrCodeUnitView As New DataView
        Dim CurrRowView As DataRowView
        Dim CurrLow As String
        Dim CurrUnitPos As Int16

        CurrLow = TempSBCode.ToString.Substring(SBCodeLEN - CurrCodePos, 1)
        CurrCodeUnitView = New DataView(CurrCodeUnitTable)
        CurrCodeUnitView.RowFilter = "UnitID='" & SBCodeUnit(SBCodeLEN - CurrCodePos, 1) & "'"
        CurrCodeUnitView.Sort = "CodeSort asc"

        For Each CurrRowView In CurrCodeUnitView
            If CurrRowView.Item("CodeUnit").ToString = CurrLow Then
                CurrUnitPos = CInt(CurrRowView.Item("CodeSort").ToString.Trim)
                Exit For
            End If
        Next

        If CurrUnitPos < (CInt(SBCodeUnit(SBCodeLEN - CurrCodePos, 2)) - 1) Then
            CurrUnitPos = CurrUnitPos + 1
            For Each CurrRowView In CurrCodeUnitView
                If CurrUnitPos = CInt(CurrRowView.Item("CodeSort").ToString.Trim) Then
                    CurrLow = CurrRowView.Item("CodeUnit").ToString
                    Exit For
                End If
            Next
            TempSBCode.Remove(SBCodeLEN - CurrCodePos, 1)
            TempSBCode.Insert(SBCodeLEN - CurrCodePos, CurrLow, 1)
            Return TempSBCode

            Exit Function
        Else
            CurrUnitPos = 0
            For Each CurrRowView In CurrCodeUnitView
                If CurrUnitPos = CInt(CurrRowView.Item("CodeSort").ToString.Trim) Then
                    CurrLow = CurrRowView.Item("CodeUnit").ToString
                    Exit For
                End If
            Next
            TempSBCode.Remove(SBCodeLEN - CurrCodePos, 1)
            TempSBCode.Insert(SBCodeLEN - CurrCodePos, CurrLow, 1)

            'add by hgd 2017-04-26 未设置流水号打印区间，顺序打印，避开其它厂区号段区间


            If CurrCodePos = SBCodeLEN Then
                MsgBox("編碼原則允許的數量已達上限！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Return Nothing
            Else
                TempSBCode = MarkSBCode(TempSBCode, CurrCodePos + 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable)
                Return TempSBCode
            End If
        End If
        CurrCodeUnitView.Dispose()
    End Function

#End Region

#Region "生成流水碼-add by hgd 20170426"

    Public Function MarkSKBCode(ByVal TempSBCode As StringBuilder, ByVal CurrCodePos As Int16, ByVal SBCodeLEN As Int16, ByVal SBCodeUnit(,) As String, ByVal CurrCodeUnitTable As DataTable, ByVal SNDistributionArr(,) As String) As StringBuilder
        Dim CurrCodeUnitView As New DataView
        Dim CurrRowView As DataRowView
        Dim CurrLow As String
        Dim CurrUnitPos As Int16
        '是否在号段区间内
        Dim IsSnInterval As Boolean = False
        Dim I As Int32 = 1
        Try
            CurrLow = TempSBCode.ToString.Substring(SBCodeLEN - CurrCodePos, 1)
            CurrCodeUnitView = New DataView(CurrCodeUnitTable)
            CurrCodeUnitView.RowFilter = "UnitID='" & SBCodeUnit(SBCodeLEN - CurrCodePos, 1) & "'"
            CurrCodeUnitView.Sort = "CodeSort asc"

            For Each CurrRowView In CurrCodeUnitView
                If CurrRowView.Item("CodeUnit").ToString = CurrLow Then
                    CurrUnitPos = CInt(CurrRowView.Item("CodeSort").ToString.Trim)
                    Exit For
                End If
            Next

            If CurrUnitPos < (CInt(SBCodeUnit(SBCodeLEN - CurrCodePos, 2)) - 1) Then

                CurrUnitPos = CurrUnitPos + 1
                For Each CurrRowView In CurrCodeUnitView
                    If CurrUnitPos = CInt(CurrRowView.Item("CodeSort").ToString.Trim) Then
                        CurrLow = CurrRowView.Item("CodeUnit").ToString
                        Exit For
                    End If
                Next

                TempSBCode.Remove(SBCodeLEN - CurrCodePos, 1)
                TempSBCode.Insert(SBCodeLEN - CurrCodePos, CurrLow, 1)

                ' add by hgd 20170426 未设置流水号打印区间，顺序打印，避开其它厂区号段区间,并从大区间的开始
                If (Not IsNothing(SNDistributionArr)) AndAlso SNDistributionArr.Length > 0 AndAlso Me.SnDistributionCount > 0 AndAlso Me.DistributionFlag <> "Y" Then
                    For I = 1 To Me.SnDistributionCount
                        If TempSBCode.ToString = SNDistributionArr(I - 1, 1) Then
                            TempSBCode.Remove(0, TempSBCode.Length)
                            TempSBCode.Append(SNDistributionArr(I - 1, 2))
                            IsSnInterval = True
                            Exit For
                        End If

                    Next


                    If IsSnInterval = True Then
                        TempSBCode = MarkSKBCode(TempSBCode, CurrCodePos, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable, SNDistributionArr)
                    End If

                End If
                Return TempSBCode
                Exit Function
            Else
                CurrUnitPos = 0
                For Each CurrRowView In CurrCodeUnitView
                    If CurrUnitPos = CInt(CurrRowView.Item("CodeSort").ToString.Trim) Then
                        CurrLow = CurrRowView.Item("CodeUnit").ToString
                        Exit For
                    End If
                Next
                TempSBCode.Remove(SBCodeLEN - CurrCodePos, 1)
                TempSBCode.Insert(SBCodeLEN - CurrCodePos, CurrLow, 1)


                If CurrCodePos = SBCodeLEN Then
                    MsgBox("編碼原則允許的數量已達上限！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Return Nothing
                Else
                    TempSBCode = MarkSKBCode(TempSBCode, CurrCodePos + 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable, SNDistributionArr)
                    Return TempSBCode
                End If
            End If
            CurrCodeUnitView.Dispose()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SqlClass", "MarkSKBCode", "BarcodePrint")
        End Try
    End Function

#End Region

    Public Function SetPrtStrTable(ByVal PFormat As String) As DataTable
        Dim Sqlstr As String
        Try
            Sqlstr = "select Orderid,Commands,Areaid,Style from m_SnFormat_t where PFormatID='" & PFormat & "' order by Orderid asc"
            Return Conn.GetDataTable(Sqlstr)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "窗體控件的權限"

    Public Sub SetObjRight(ByVal Sqlstr As String, ByRef Obj As Object)
        Dim RecTable As New DataTable
        Try
            RecTable = Conn.GetDataTable(Sqlstr)
            Obj.Enabled = IIf(RecTable.Rows.Count > 0, True, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "鎖定CboMoid"

    Public Sub LockMoid(ByVal Moid As String, ByRef Cbo As ComboBox)
        Cbo.SelectedIndex = Cbo.FindStringExact(Moid)
        Cbo.Enabled = False
    End Sub

#End Region

#Region "解除打印時對料件的鎖定"

    Public Sub OpenDistributionLock(ByVal StyleID As String, ByVal FactoryId As String, Optional ByVal SNDistributionID As String = Nothing)
        Dim Sqlstr As String = ""

        Try
            Sqlstr = "update m_SnDistributionStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & StyleID & "' AND FactoryId='" & Factory & "' "

            If Not SNDistributionID Is Nothing Then
                Sqlstr = Sqlstr + " and SNDistributionID='" & SNDistributionID & "'"
            End If
            Conn.ExecSql(Sqlstr)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub OpenLock(ByVal StyleID As String)
        Dim Sqlstr As String = ""
        '去掉空格
        Try
            Sqlstr = "update m_SnStyle_t set IsUsed='N',Intime=getdate() where RTRIM(LTRIM(StyleID))='" & StyleID & "'"
            Conn.ExecSql(Sqlstr)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub OpenCustomizeLock(ByVal StyleID As String)
        Dim Sqlstr As String = ""

        Try
            Sqlstr = "update m_SnCustomizeStyle_t set IsUsed='N',Intime=getdate() where CustomizeStyleID='" & StyleID & "'"
            Conn.ExecSql(Sqlstr)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "打印模板路径文件名"

    Public Function PrintFilePath(ByVal PFormat) As String

        Dim Sqlstr As String
        Try
            Sqlstr = "select TemplatePath from M_SnMFormat_t where PFormatID='" & PFormat & "'"
            Dim MsqlRdaer As SqlDataReader = Conn.GetDataReader(Sqlstr)
            Sqlstr = ""
            If MsqlRdaer.HasRows Then
                While MsqlRdaer.Read
                    Sqlstr = MsqlRdaer!TemplatePath.ToString
                End While
            End If
            MsqlRdaer.Close()
            Return Sqlstr
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

End Class

Public Class SqlClassD

#Region "類內部參數"

    Dim mStyleID As String
    Dim mStyleIDCartonNotFull As String
    Dim mCustomizeStyleID As String
    Dim mCurrAVCPartID As String
    Dim mCurrPrintNum As Int16
    Dim mCurrMoid As String
    Dim mAxSPos As Int16
    '检查Barcode起始位置Add By KyLinQiu 20170609
    Dim mChkPos As Int16
    Dim mLblSPos As Int16
    '检查Label起始位置Add By KyLinQiu 20170609
    Dim mChkLblPos As Int16
    '检查是否启用检测位Add By KyLinQiu 20170609
    Dim _isChkFlag As String
    Dim _isChkLabFlag As Boolean
    Dim mBarCodeStyleMax As String
    Dim mCurrMaxInt As Int64
    Dim mPFormat As String
    Shared mUpdateTime As String
    Dim mPrintColNum As Int16
    Dim mStartInt As Int64
    Dim mStartSn As String
    Dim mEndInt As Int64
    Dim mEndSn As String
    Dim mMantissaFlag As Boolean
    Dim mMantissaBoxQty As Int16
    Dim mAtrrBarCodeStyleMax As String
    Dim mAtrrCurrMaxInt As Int64
    Dim mSpecFilterStr As String ''特别过滤字符
#End Region

#Region "窗體基本屬性"

    Public Property AtrrBarCodeStyleMax() As String

        Get
            Return mAtrrBarCodeStyleMax
        End Get
        Set(ByVal value As String)
            mAtrrBarCodeStyleMax = value
        End Set

    End Property

    Public Property AtrrCurrMaxInt() As Int64

        Get
            Return mAtrrCurrMaxInt
        End Get
        Set(ByVal value As Int64)
            mAtrrCurrMaxInt = value
        End Set

    End Property

    Public Property EndInt() As Int64

        Get
            Return mEndInt
        End Get
        Set(ByVal value As Int64)
            mEndInt = value
        End Set

    End Property

    Public Property StartInt() As Int64

        Get
            Return mStartInt
        End Get
        Set(ByVal value As Int64)
            mStartInt = value
        End Set

    End Property

    Public Property EndSn() As String

        Get
            Return mEndSn
        End Get
        Set(ByVal value As String)
            mEndSn = value
        End Set

    End Property

    Public Property StartSn() As String

        Get
            Return mStartSn
        End Get
        Set(ByVal value As String)
            mStartSn = value
        End Set

    End Property

    Public Shared Property UpdateTime() As String

        Get
            Return mUpdateTime
        End Get
        Set(ByVal value As String)
            mUpdateTime = value
        End Set

    End Property

    Public Property PFormat() As String

        Get
            Return mPFormat
        End Get
        Set(ByVal value As String)
            mPFormat = value
        End Set

    End Property

    Public Property StyleID() As String
        Get
            Return mStyleID
        End Get
        Set(ByVal value As String)
            mStyleID = value
        End Set
    End Property

    Public Property StyleIDCartonNotFull() As String

        Get
            Return mStyleIDCartonNotFull
        End Get
        Set(ByVal value As String)
            mStyleIDCartonNotFull = value
        End Set

    End Property

    Public Property CustomizeStyleID() As String

        Get
            Return mCustomizeStyleID
        End Get
        Set(ByVal value As String)
            mCustomizeStyleID = value
        End Set

    End Property

    Public Property CurrMoid() As String

        Get
            Return mCurrMoid
        End Get
        Set(ByVal value As String)
            mCurrMoid = value
        End Set

    End Property

    Public Property CurrAVCPartID() As String

        Get
            Return mCurrAVCPartID
        End Get
        Set(ByVal value As String)
            mCurrAVCPartID = value
        End Set

    End Property

    Public Property CurrPrintNum() As Int64

        Get
            Return mCurrPrintNum
        End Get
        Set(ByVal value As Int64)
            mCurrPrintNum = value
        End Set

    End Property

    Public Property PrintColNum() As Int16

        Get
            Return mPrintColNum
        End Get
        Set(ByVal value As Int16)
            mPrintColNum = value
        End Set

    End Property

    Public Property CurrMaxInt() As Int64

        Get
            Return mCurrMaxInt
        End Get
        Set(ByVal value As Int64)
            mCurrMaxInt = value
        End Set

    End Property

    Public Property AxSPos() As Int16

        Get
            Return mAxSPos
        End Get
        Set(ByVal value As Int16)
            mAxSPos = value
        End Set

    End Property
    ''检查Barcode起始位置Add By KyLinQiu 20170609
    Public Property ChkPos() As Int16
        Get
            Return mChkPos
        End Get
        Set(ByVal value As Int16)
            mChkPos = value
        End Set
    End Property

    Public Property LblSPos() As Int16

        Get
            Return mLblSPos
        End Get
        Set(ByVal value As Int16)
            mLblSPos = value
        End Set

    End Property
    ''检查Label起始位置Add By KyLinQiu 20170609
    Public Property ChkLblPos() As Int16
        Get
            Return mChkLblPos
        End Get
        Set(ByVal value As Int16)
            mChkLblPos = value
        End Set
    End Property

    Public Property IsChkFlag() As String
        Get
            Return _isChkFlag
        End Get
        Set(ByVal value As String)
            _isChkFlag = value
        End Set
    End Property

    Public Property IsChkLabFlag() As Boolean
        Get
            Return _isChkLabFlag
        End Get
        Set(ByVal value As Boolean)
            _isChkLabFlag = value
        End Set
    End Property

    Public Property BarCodeStyleMax() As String

        Get
            Return mBarCodeStyleMax
        End Get
        Set(ByVal value As String)
            mBarCodeStyleMax = value
        End Set

    End Property

    Public Property MantissaFlag() As Boolean

        Get
            Return mMantissaFlag
        End Get
        Set(ByVal value As Boolean)
            mMantissaFlag = value
        End Set

    End Property

    Public Property MantissaBoxQty() As Int16

        Get
            Return mMantissaBoxQty
        End Get
        Set(ByVal value As Int16)
            mMantissaBoxQty = value
        End Set

    End Property
    ''' <summary>
    ''' 特殊过滤字符
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SpecFilterStr() As String

        Get
            Return mSpecFilterStr
        End Get
        Set(ByVal value As String)
            mSpecFilterStr = value
        End Set

    End Property

#End Region

#Region "建制"

    Public Sub New()
        mCurrMoid = ""
        mStyleID = ""
        mCurrAVCPartID = "##########"
        mCurrPrintNum = 0
        mAxSPos = 0
        mChkPos = 0
        mLblSPos = 0
        mChkLblPos = 0
        _isChkFlag = False
        _isChkLabFlag = False
        mBarCodeStyleMax = ""
        mCurrMaxInt = 0
        mPFormat = ""
        mPrintColNum = 0
        mStartInt = 0
        mStartSn = ""
        mEndInt = 0
        mEndSn = ""
        MantissaFlag = False
    End Sub

#End Region

#Region "Dispose"

    Public Sub dispose()
        mCurrMoid = ""
        mStyleID = ""
        mCurrAVCPartID = "##########"
        mCurrPrintNum = 0
        mAxSPos = 0
        mChkPos = 0
        mLblSPos = 0
        mChkLblPos = 0
        _isChkFlag = False
        _isChkLabFlag = False
        mBarCodeStyleMax = ""
        mCurrMaxInt = 0
        mPFormat = ""
        mPrintColNum = 0
        mStartInt = 0
        mStartSn = ""
        mEndInt = 0
        mEndSn = ""
        MantissaFlag = False
    End Sub

#End Region

End Class