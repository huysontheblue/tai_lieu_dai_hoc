Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
'Imports Biff8Excel
'Imports Biff8Excel.Excel
Imports MainFrame
Imports System.IO

Module Common
    Dim ObjDB As New SysDataBaseClass()
    Dim rs As SqlDataReader

    Public Sub LoadDataToCombo(ByRef ComBox As ComboBox, ByVal intType As Integer)
        Dim strSql As String
        Dim strUser As String
        Dim intDeptCount As Integer

        strSql = ""
        strUser = MainFrame.SysCheckData.SysMessageClass.UseId
        Select Case intType
            Case 1 '取客戶
                strSql = "select distinct cusid+'-'+cusname from m_customer_t"
            Case 2 '取部門
                'strSql = "select distinct deptid+'-'+djc from m_dept_t where dtype='R' "

                strSql = " select distinct deptid+'-'+djc from m_dept_t a, m_logtree_t b, m_userright_t c " _
                       & " where a.deptid=b.buttonid and b.tkey=c.tkey and a.dtype='R' " _
                       & " and c.userid='" & strUser & "' "
            Case 3 '取工站
                strSql = "select distinct stationname from m_rstation_t"
        End Select

        rs = ObjDB.GetDataReader(strSql)

        ComBox.Items.Clear()
        ComBox.DropDownStyle = ComboBoxStyle.DropDownList
        ComBox.Items.Add("ALL")

        intDeptCount = 0
        Do While rs.Read
            ComBox.Items.Add(rs(0))
            intDeptCount += 1
        Loop

        If intType = "2" And intDeptCount <= 1 Then
            ComBox.Items.Remove("ALL")
        End If
        If ComBox.Items.Count > 0 Then
            ComBox.SelectedIndex = 0
        End If

        rs.Close()
    End Sub

    Public Sub LoadLineIDToCombo(ByRef ComBox As ComboBox, ByVal strDept As String)

        Dim strSql As String

        strSql = " select distinct a.lineid from deptline_t a, m_dept_t b  " _
               & " where a.deptid=b.deptid and b.deptid='" & strDept & "' "

        rs = ObjDB.GetDataReader(strSql)
        ComBox.Items.Clear()
        ComBox.DropDownStyle = ComboBoxStyle.DropDownList
        ComBox.Items.Add("ALL")
        Do While rs.Read
            ComBox.Items.Add(rs(0))
        Loop
        ComBox.SelectedIndex = 0

        rs.Close()

    End Sub

    '得到需要查詢的季度
    '返回字串 AYYQQQQ 1.A表示時間范圍是否是本季度裡（1為真0為假） 2.YY.表示年份 3.QQQQ表示時間范圍包含那幾個季度（1為真0為假）。
    Public Function GetQuarterCondition(ByVal starDate As String, ByVal endDate As String) As String
        Dim str As String
        Dim strSql As String
        Dim Year, T1, T2, T3, T4 As String
        Dim starQ, endQ, nowQ As Integer
        str = "1000000"
        strSql = " select substring(convert(varchar, datepart(yy, getdate())),3,2)y, " _
               & " datepart(q, '" & starDate & "') star_q, datepart(q, '" & endDate & "') end_q, " _
               & " datepart(q,getdate()) now_q "
        rs = ObjDB.GetDataReader(strSql)
        If rs.Read Then
            Year = Mid(starDate, 3, 2)
            starQ = rs(1)
            endQ = rs(2)
            nowQ = rs(3)
        Else
            Year = "00"
            starQ = 0
            endQ = 0
            nowQ = 0
        End If
        rs.Close()

        'If (starQ = endQ) And (starQ = nowQ) Then
        ' str = "1" + Year + "0000"
        'Else
        T1 = "0"
        T2 = "0"
        T3 = "0"
        T4 = "0"
        Select Case endQ
            Case 1
                T1 = 1
            Case 2
                T2 = 1
                If starQ = 1 Then T1 = 1
            Case 3
                T3 = 1
                If starQ = 1 Then
                    T1 = 1
                    T2 = 1
                End If
                If starQ = 2 Then T2 = 1
            Case 4
                T4 = 1
                If starQ = 1 Then
                    T1 = 1
                    T2 = 1
                    T3 = 1
                End If
                If starQ = 2 Then
                    T2 = 1
                    T3 = 1
                End If
                If starQ = 3 Then T3 = 1
        End Select

        str = "0" & Year & T1.ToString() & T2.ToString() & T3.ToString() & T4.ToString()
        'End If

        Return str
    End Function

    '取歷史記錄的表
    Private Function GetReplacedSQL(ByVal strSQL As String, ByVal strYear As String, ByVal strQ As String) As String
        Dim str As String
        str = strSQL
        str = Replace(str, "m_assysn_t", "mesdbnd.dbo.m_assysn_t" & strYear & strQ)
        str = Replace(str, "m_carton_t", "mesdbnd.dbo.m_carton_t" & strYear & strQ)
        str = Replace(str, "m_cartonsn_t", "mesdbnd.dbo.m_cartonsn_t" & strYear & strQ)
        str = Replace(str, "m_cartonlot_t", "mesdbnd.dbo.m_cartonlot_t" & strYear & strQ)
        str = Replace(str, "m_snsbarcode_t", "mesdbnd.dbo.m_snsbarcode_t" & strYear & strQ)
        str = Replace(str, "m_qcmain_t", "mesdbnd.dbo.m_qcmain_t" & strYear & strQ)
        str = Replace(str, "m_qcdetail_t", "mesdbnd.dbo.m_qcdetail_t" & strYear & strQ)
        str = Replace(str, "m_qclist_t", "mesdbnd.dbo.m_qclist_t" & strYear & strQ)

        str = Replace(str, "m_Assysn_t", "mesdbnd.dbo.m_Assysn_t" & strYear & strQ)
        str = Replace(str, "m_whinm_t", "mesdbnd.dbo.m_whinm_t" & strYear & strQ)
        str = Replace(str, "m_whind_t", "mesdbnd.dbo.m_whind_t" & strYear & strQ)
        str = Replace(str, "m_whoutd_t", "mesdbnd.dbo.m_whoutd_t" & strYear & strQ)
        str = Replace(str, "m_whoutm_t", "mesdbnd.dbo.m_whoutm_t" & strYear & strQ)

        Return str
    End Function

    '處理查詢歷史數據 SQL
    Public Function GetHistoryDataSQL(ByVal starDate As String, ByVal endDate As String, ByVal OldSQL As String) As String
        Dim i, j As Integer
        Dim strTmp, str, Year As String
        Dim intBY, intEY As Integer
        Dim strHistory As String
        Dim strSQL As String

        str = OldSQL
        strSQL = OldSQL
        intBY = CType(Mid(starDate, 1, 4), Integer)   '起始年
        intEY = CType(Mid(endDate, 1, 4), Integer)    '結束年

        If intBY = intEY Then  '如果在同一年
            strHistory = GetQuarterCondition(starDate, endDate)
            If Mid(strHistory, 1, 1) <> "1" Then
                Year = Mid(strHistory, 2, 2)
                strTmp = Mid(strHistory, 4, 4)
                For i = 1 To 4
                    If Mid(strTmp, i, 1) = "1" Then
                        strSQL += " union " + GetReplacedSQL(str, Year, i.ToString())
                    End If
                Next i
            End If
        Else  '跨年處理
            For j = 1 To intEY - intBY
                strHistory = GetQuarterCondition(starDate, CType(intBY, String) & "/12/31 23:59:59")
                If Mid(strHistory, 1, 1) <> "1" Then
                    Year = Mid(strHistory, 2, 2)
                    strTmp = Mid(strHistory, 4, 4)
                    For i = 1 To 4
                        If Mid(strTmp, i, 1) = "1" Then
                            strSQL += " union " + GetReplacedSQL(str, Year, i.ToString())
                        End If
                    Next i
                End If

                intBY += 1
            Next

            strHistory = GetQuarterCondition(CType(intEY, String) & "/01/01 00:00:00", endDate)
            If Mid(strHistory, 1, 1) <> "1" Then
                Year = Mid(strHistory, 2, 2)
                strTmp = Mid(strHistory, 4, 4)
                For i = 1 To 4
                    If Mid(strTmp, i, 1) = "1" Then
                        strSQL += " union " + GetReplacedSQL(str, Year, i.ToString())
                    End If
                Next i
            End If
        End If
        strSQL = strSQL '& "order by 1 desc "

        Return strSQL
    End Function
    ''' <summary>
    ''' 检查时间
    ''' </summary>
    ''' <param name="starDT"></param>
    ''' <param name="endDT"></param>
    ''' <param name="checkt">默认检测时间间隔</param>
    ''' <param name="months">检测时间间隔月份数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckDate(ByVal starDT As DateTimePicker, ByVal endDT As DateTimePicker, Optional ByVal checkt As Boolean = True, Optional ByVal months As Integer = 2)
        If starDT.Value > endDT.Value Then
            MsgBox("起始時間不能大於結束時間!", 48, "提示")
            starDT.Value = DateAdd(DateInterval.Day, -1, Now())
            endDT.Value = Now()
            Return False
        End If

        If starDT.Value < "2007-01-01" Then
            MsgBox("起始時間不能小於2007-01-01!", 48, "提示")
            starDT.Value = DateAdd(DateInterval.Day, -1, Now())
            Return False
        End If

        'If endDT.Value > Now Then
        '    MsgBox("結束時間不能大於現在時間!", 48, "提示")
        '    endDT.Value = Now()
        '    Return False
        'End If
        If checkt Then
            Dim startDate As DateTime = DateTime.Parse(starDT.Text)
            Dim endDate As DateTime = DateTime.Parse(endDT.Text)
            If startDate.AddMonths(months) < endDate Then
                MsgBox("查询时间相隔最多请不要超过" & months.ToString & "个月", 48, "提示")
                starDT.Value = DateAdd(DateInterval.Month, -1, endDate)
                Return False
            End If
        Else
            Return True
        End If
        Return True
    End Function

    Public Sub FillFactory(ByRef ComBox As ComboBox, ByVal strUser As String)
        Dim strSql As String
        '
        ComBox.Items.Clear()
        strSql = " select ttext, buttonid from m_logtree_t where tkey in " _
               & " (select tkey from m_userright_t where tkey in " _
               & " (select tkey from m_logtree_t where tparent='F0_') " _
               & " and userid='" & strUser & "') "
        rs = ObjDB.GetDataReader(strSql)
        While rs.Read
            'ComBox.Items.Add(rs(0).ToString & "(" & rs(1).ToString & ")")
            ComBox.Items.Add(rs(1).ToString & "-" & rs(0).ToString)
        End While
        rs.Close()
        ComBox.SelectedIndex = 0
    End Sub

    Public Function GetUserName(ByVal strUserID As String) As String
        Dim dt As DataTable = Nothing
        Try
            dt = ObjDB.GetDataTable("select UserName from m_Users_t where UserID='" & strUserID & "'")
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0).ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
        End Try
    End Function

    Public Sub BindComboBox(ByVal strValue As String, ByVal Combox As ComboBox)
        Dim dt As DataTable = New DataTable
        Try
            dt.Columns.Add("Text")
            dt.Columns.Add("Value")

            Combox.Items.Clear()
            For Each str As String In strValue.Split(",")
                dt.Rows.Add(str.Split("-")(1), str.Split("-")(0))
            Next
            Combox.DataSource = dt
            Combox.DisplayMember = "Text"
            Combox.ValueMember = "Value"
            Combox.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function DecodeCaseSQL(ByVal strColumnName As String, ByVal strDecodeValue As String) As String
        Return "(CASE WHEN " & strColumnName & "='" & strDecodeValue.Replace("-", "' THEN N'").Replace(",", "' WHEN " & strColumnName & "='") & "' END) " & strColumnName
    End Function

    Public Function GetLocalPCInfo() As String
        Dim localIP As String = String.Empty
        Dim IPHostEntry As System.Net.IPHostEntry
        Try
            IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
            For Each IPAddress As System.Net.IPAddress In (IPHostEntry.AddressList)
                If IPAddress.AddressFamily.ToString() = "InterNetwork" Then
                    localIP = IPAddress.ToString()
                    Exit For
                End If
            Next
            Return System.Net.Dns.GetHostName() & "(" & localIP & ")"
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetFactoryCode(ByVal strFullName) As String
        'Dim intStar, intEnd As Integer
        Dim intPos As Integer
        Dim strReturn As String

        intPos = InStr(strFullName, "-")
        strReturn = Mid(strFullName, 1, intPos - 1)
        Return strReturn
    End Function

    '取-前的字符
    Public Function Getid(ByVal strFullName) As String
        Dim intPos As Integer
        Dim strReturn As String
        If strFullName <> "" Then
            If strFullName = "ALL" Then
                strReturn = "%"
                Return strReturn
                Exit Function
            End If
            intPos = InStr(strFullName, "-")
            strReturn = Mid(strFullName, 1, intPos - 1)
        Else
            strReturn = "%"
        End If
        Return strReturn
    End Function

    'Public Sub ShowWaitWindow()
    '    Dim frmwait As New FrmWait()
    '    frmwait.ShowDialog()
    '    Application.DoEvents()
    'End Sub

    '不需要安裝ms office,匯出Excel
    Public Sub LoadDataToOpExcel(ByVal ReportName As String, ByVal GridControl As DataGridView, ByVal ConditionStr As String)
        'If GridControl.RowCount < 1 Then Exit Sub

        'Dim xlBook As ExcelWorkbook

        'Dim xlSheet As ExcelWorksheet

        'Dim RowField, ColField As Integer

        'xlBook = Nothing

        'xlSheet = Nothing

        'xlBook = New ExcelWorkbook()

        'xlBook.SetDefaultFont("Arial", 10)

        'xlBook.CreateSheet("sheet1")

        'xlSheet = xlBook.GetSheet("sheet1")

        'xlBook.SetActiveSheet = "sheet1"



        'Dim style = xlBook.CreateStyle()

        'style.BorderLineStyle = EnumLineStyle.Thin

        'style.DiagLineColour = EnumColours.Aqua

        'style.HorizontalAlignment = EnumHorizontalAlignment.Right

        'For ColField = 1 To GridControl.Columns.Count

        '    xlSheet.AddCell(ColField, 5, GridControl.Columns(ColField - 1).HeaderText, style)

        'Next ColField

        'For RowField = 1 To GridControl.RowCount

        '    For ColField = 1 To GridControl.Columns.Count

        '        xlSheet.AddCell(ColField, 5 + RowField, GridControl.Item(ColField - 1, RowField - 1).Value, style)

        '        xlSheet.GridLines() = True

        '    Next

        'Next

        'With xlSheet

        '    .AddCell(1, 1, "奇宏電子(深圳)有限公司")

        '    .AddCell(1, 2, "報表名稱:" & ReportName & "     制表日期:" & Now() & "    制表人:" & MainFrame.SysCheckData.SysMessageClass.UseName)

        '    .AddCell(1, 3, ConditionStr)

        'End With



        ''判斷文件是否存在，存在就彈出保存按鈕

        'Dim Path As String = Application.StartupPath() & "\xls"



        'If Not System.IO.Directory.Exists(Path) Then

        '    System.IO.Directory.CreateDirectory(Path)

        'End If

        'Dim filename As String = Path & "\report.xls"

        'If File.Exists(filename) And IsOpened(filename) Then

        '    filename = Path & "\report" & Now().ToString("mmss") & ".xls"

        'End If

        'xlBook.Save(filename)

        'If File.Exists(filename) Then

        '    System.Diagnostics.Process.Start(filename)

        '    Try

        '        Dim filen1() As String = System.IO.Directory.GetFiles(Path)

        '        Dim qty As Integer

        '        For qty = 0 To filen1.Length

        '            If Not IsOpened(filen1(qty)) And filen1(qty) <> filename Then

        '                File.Delete(filen1(qty))

        '            End If

        '        Next

        '    Catch ex As Exception



        '    End Try

        'Else

        '    MsgBox("sorry ,the file is  not exists!")

        'End If

        'xlSheet = Nothing

        'xlBook = Nothing



    End Sub
    ''' <summary>
    ''' DataGridView数据导出excel 公共方法
    ''' </summary>
    ''' <param name="DgMoData">DataGridView控件ID</param>
    ''' <param name="tbname">导出文件名称</param>
    ''' <remarks></remarks>
    Public Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String)
        Try


            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim getTable As New DataTable
            getTable.TableName = tbname

            getTable = DgMoData.DataSource

            '导出CSV文件格式，以便用户查询，以,号区分

            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If

            Dim Swriter As New IO.StreamWriter("c:\MesExport\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            For Each r As DataRow In getTable.Rows

                nColqty = 0

                For Each c As DataColumn In getTable.Columns
                    '写入标题行
                    If bColName = False Then
                        If wColName = "" Then
                            wColName = c.ColumnName.Replace(",", "，")
                        Else
                            wColName = wColName + "," + c.ColumnName.Replace(",", "，")
                        End If
                    End If

                    '写入每行的值
                    If nColqty = 0 Then
                        wValue = r.Item(c.ColumnName).ToString.Replace(",", "，")
                    Else
                        wValue = wValue + "," + r.Item(c.ColumnName).ToString.Replace(",", "，")
                    End If
                    nColqty = nColqty + 1

                Next

                If wColName <> "" And bColName = False Then
                    Swriter.WriteLine(wColName)
                    bColName = True
                End If

                Swriter.WriteLine(wValue)

            Next
            Swriter.Close()

            MessageBox.Show("文件导出成功,导出位置：c:\MesExport\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function IsOpened(ByVal filename As String) As Boolean

        Try

            Dim fs As FileStream = New FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read)

            If Not fs.CanWrite Then

                fs.Dispose()

                Return False

            End If

        Catch ex As Exception

            Return True

        End Try

    End Function

End Module
