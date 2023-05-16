Imports System.Threading
Imports MainFrame

Public Class FrmNiRecordAnalyseQuery

    Dim dtDept As DataTable = Nothing
    Dim dtLines As DataTable = Nothing
    Dim Teststion As DataTable = Nothing
    Dim dtMacs As DataTable = Nothing
    Dim dtBadItem As DataTable = Nothing
    Dim dicBadItem As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
    Dim isFormLoad As Boolean = True

    Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass

    Private Sub FrmNiRecordAnalyseQuery_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not dtDept Is Nothing Then
            dtDept.Dispose()
        End If
        If Not dtLines Is Nothing Then
            dtLines.Dispose()
        End If
        If Not Teststion Is Nothing Then
            Teststion.Dispose()
        End If
        If Not dtMacs Is Nothing Then
            dtMacs.Dispose()
        End If
        If Not dtBadItem Is Nothing Then
            dtBadItem.Dispose()
        End If
    End Sub


    Private Sub FrmNiRecordAnalyseQuery_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'add by song
            '2016-09-22
            '设置英语版的控件位置
            If MultLanguage.Language.lang = "en" Then
                SetControl()
            End If
            LoadDetps()
            LoadLines()
            ' LoadBadItem()
            '  LoadMacs()
            LoadTeststation()
            isFormLoad = False
            DtStar.Value = Now
            DtEnd.Value = Now

            'add by song
            '2016-09-19
            If MultLanguage.Language.lang = "zh-cht " Then
                cobShowStyle.Items.Clear()
                cobShowStyle.Items.Add("1.千分比")
                cobShowStyle.Items.Add("2.百分比")
            ElseIf MultLanguage.Language.lang = "en" Then
                cobShowStyle.Items.Clear()
                cobShowStyle.Items.Add("1.Thousand division ratio")
                cobShowStyle.Items.Add("2.Percentage")
            End If
        Catch ex As Exception
            MultLanguage.MultMessage.ShowText(ex.Message)
        End Try
    End Sub

    'add by song
    '2016-09-22
    '设置英语版的控件位置
    Private Sub SetControl()
        CobPPID.Left += 15
        CobPPID.Width += 45
        cobShowStyle.Location = New Point(cobShowStyle.Location.X + 25, cobShowStyle.Location.Y)
        cobShowStyle.Width += 75
        Label9.Location = New Point(Label9.Location.X + 10, Label9.Location.Y + 30)
    End Sub

    Private Sub LoadDetps()
        Dim sql As String = " SELECT DEPTID,DEPTID+'-'+DqC DISV FROM DBO.M_DEPT_T WHERE USEY='Y' "
        dtDept = conn.GetDataTable(sql)
        dtDept.Rows.InsertAt(dtDept.NewRow, 0)
        CboDeptid.DataSource = dtDept
        CboDeptid.DisplayMember = "DISV"
        CboDeptid.ValueMember = "DEPTID"
        conn.PubConnection.Close()
    End Sub

    Private Sub LoadLines()
        Dim sql As String = "SELECT DEPTID,LINEID FROM DBO.DEPTLINE_T WHERE USEY='Y' "
        dtLines = conn.GetDataTable(sql)
        conn.PubConnection.Close()
    End Sub

    Private Sub LoadTeststation()
        Dim sql As String = "select  TestTypeID, TestTypeName from m_testtype_v WHERE USEY='Y' "
        Teststion = conn.GetDataTable(sql)
        conn.PubConnection.Close()

            ComboBox1.Items.Clear()

        For i = 0 To Teststion.Rows.Count - 1
            ComboBox1.Items.Add(Teststion.Rows(i)("TestTypeID") & "-" & Teststion.Rows(i)("TestTypeName"))
        Next
      
    End Sub

    Private Sub LoadBadItem()
        Dim sql As String = "SELECT BADITEM,UPPER(KEYWORD) KEYWORD,KEYPOINT FROM M_NITESTRECORDANALYSEITEM_T WHERE STATUS='Y' ORDER BY BADITEM"
        dtBadItem = conn.GetDataTable(sql)
        conn.PubConnection.Close()
        dicBadItem.Clear()
        For Each dr As DataRow In dtBadItem.Rows
            If dicBadItem.Count = 0 Then
                dicBadItem.Add(dr("BADITEM").ToString, 0)
            Else
                If Not dicBadItem.ContainsKey(dr("BADITEM").ToString) Then
                    dicBadItem.Add(dr("BADITEM").ToString, 0)
                End If
            End If
        Next
    End Sub

    Private Sub LoadMacs()
        Dim sql As String = "SELECT LINEID,NIMACID FROM M_SENDASNDATAINFO_T WHERE ISUSE='Y'"
        dtMacs = conn.GetDataTable(sql)
        conn.PubConnection.Close()
    End Sub

    Private Sub CboDeptid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboDeptid.SelectedValueChanged
        If Not IsDBNull(CboDeptid.SelectedValue) AndAlso Not isFormLoad Then
            CobLineId.Items.Clear()
            For Each dr As DataRow In dtLines.Select("DEPTID='" & CboDeptid.SelectedValue & "'")
                CobLineId.Items.Add(dr("LINEID").ToString)
            Next
            CobLineId.Items.Insert(0, "")
        End If
    End Sub

    Private Sub ClearDics()
        Dim keys(dicBadItem.Count - 1) As String
        dicBadItem.Keys.CopyTo(keys, 0)
        For i As Integer = 0 To keys.Length - 1
            dicBadItem(keys(i)) = 0
        Next
    End Sub

    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        If ComboBox1.Text = "" Then
            MessageBox.Show("请选择测试站点")
            Exit Sub
        End If
        SlectLine()
        If Not BasicCheck() Then Return
        Label9.Text = ""
        LblNGcount.Text = "0pcs"
        LblNGqty.Text = "0%"
        Dim myThread As Threading.Thread = Nothing
       
        Try
            myThread = New Threading.Thread(AddressOf ShowWaitWindow)
            myThread.Start()
            Threading.Thread.Sleep(500)
            LoadData()
        Catch ex As Exception
            MultLanguage.MultMessage.ShowText(ex.Message)
        Finally
            Try
                If Not myThread Is Nothing Then
                    myThread.Abort()
                    myThread.Join()
                End If
            Catch ex As ThreadAbortException
            Catch ex As Exception
            End Try
            Application.DoEvents()
        End Try
    End Sub

    Private Function BasicCheck()
        'If String.IsNullOrEmpty(CobLineId.Text) Then
        '    'MessageBox.Show("请选择线别")
        '    MultLanguage.MultMessage.ShowText(String.Format(MultLanguage.MultMessage.GetMsg("M000081"), Label4.Text.Trim(":")))
        '    Return False
        'End If
        If DtStar.Value > DtEnd.Value Then
            MsgBox("起始時間不能大於結束時間!", 48, "提示")
            'MultLanguage.MultMessage.ShowText("M000067")
            DtStar.Value = Now()
            DtEnd.Value = Now()
            Return False
        End If
        Dim startDate As DateTime = DateTime.Parse(DtStar.Text)
        Dim endDate As DateTime = DateTime.Parse(DtEnd.Text)
        If startDate.AddDays(1) < endDate Then
            MsgBox("查询时间相隔最多请不要超过" & 1 & "天", 48, "提示")
            'MultLanguage.MultMessage.ShowText(String.Format(MultLanguage.MultMessage.GetMsg("M000069"), 1))
            Return False
        End If
        'If String.IsNullOrEmpty(niMacIds) Then
        '    MsgBox("该线别没有维护对应的Mac信息，请确认")
        '    'MultLanguage.MultMessage.ShowText("M000398")
        '    Return False
        'End If
        Return True
    End Function


    Dim resultFormat1 As String = "{0}pcs"
    Dim resultFormat2 As String = "{0}%"
    Dim resultFormat3 As String = "{0}不良数:{1}pcs 不良率:{2}%"

    Private Enum NiResultEnum
        Asn = 0
        Result
        TestTime
        TESTCOUNT
      
    End Enum
    Private Sub ChangeColumnStyle()
        dgNiResult.Columns(NiResultEnum.Asn).HeaderText = "SN"
        dgNiResult.Columns(NiResultEnum.Asn).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        If MultLanguage.Language.lang = "zh-chs" Then
            dgNiResult.Columns(NiResultEnum.Result).HeaderText = "测试结果"
            dgNiResult.Columns(NiResultEnum.TestTime).HeaderText = "测试时间"
            'dgNiResult.Columns(NiResultEnum.LineId).HeaderText = "机台编号"
            dgNiResult.Columns(NiResultEnum.TESTCOUNT).HeaderText = "测试次数"
            'If (VbCommClass.VbCommClass.Factory = "LX21") OrElse (VbCommClass.VbCommClass.Factory = "LXVN") Then
            '    dgNiResult.Columns(NiResultEnum.Fmsg).HeaderText = "不良信息"
            'End If
        ElseIf MultLanguage.Language.lang = "zh-cht" Then
            dgNiResult.Columns(NiResultEnum.Result).HeaderText = "測試結果"
            dgNiResult.Columns(NiResultEnum.TestTime).HeaderText = "測試時間"
            'dgNiResult.Columns(NiResultEnum.LineId).HeaderText = "機臺編號"
            dgNiResult.Columns(NiResultEnum.TESTCOUNT).HeaderText = "TESTCOUNT"
            'If (VbCommClass.VbCommClass.Factory = "LX21") OrElse (VbCommClass.VbCommClass.Factory = "LXVN") Then
            '    dgNiResult.Columns(NiResultEnum.Fmsg).HeaderText = "不良信息"
            'End If
        ElseIf MultLanguage.Language.lang = "en" Then
            dgNiResult.Columns(NiResultEnum.Result).HeaderText = "TestResult"
            dgNiResult.Columns(NiResultEnum.TestTime).HeaderText = "TestTime"
            'dgNiResult.Columns(NiResultEnum.LineId).HeaderText = "MachineId"
            dgNiResult.Columns(NiResultEnum.TESTCOUNT).HeaderText = "TESTCOUNT"
            'If (VbCommClass.VbCommClass.Factory = "LX21") OrElse (VbCommClass.VbCommClass.Factory = "LXVN") Then
            '    dgNiResult.Columns(NiResultEnum.Fmsg).HeaderText = "Msg"
            'End If
        End If
        'If (VbCommClass.VbCommClass.Factory = "LX21") OrElse (VbCommClass.VbCommClass.Factory = "LXVN") Then
        '    dgNiResult.Columns(NiResultEnum.Fmsg).Visible = True
        'Else
        '    dgNiResult.Columns(NiResultEnum.Fmsg).Visible = False

        'End If
        'dgNiResult.Columns(NiResultEnum.IsAnalyse).Visible = True
    End Sub
    Public Sub LoadData()
        Dim BeginDate As String = DtStar.Value.ToString("yyyy-MM-dd HH:mm:ss")
        Dim EndDate As String = DtEnd.Value.ToString("yyyy-MM-dd HH:mm:ss")
        Dim lineId As String = CobLineId.Text
        Dim result = IIf(CobStatus.Text = "ALL", "", CobStatus.Text)
        Dim ppid As String = CobPPID.Text
        Dim sql As String
        'If ComboBox1.Text = "APP" Then
        '    sql = String.Format("execute [m_QueryNiTestRecordAnalyse_p_APP] '{0}','{1}','{2}','{3}','{4}'", BeginDate, EndDate, result, niMacIds, ppid)
        'Else
        '    sql = String.Format("execute [m_QueryNiTestRecordAnalyse_p] '{0}','{1}','{2}','{3}','{4}'", BeginDate, EndDate, result, niMacIds, ppid)
        'End If
        ' sql = String.Format("execute [m_QueryNiTestRecordAnalyse_p] '{0}','{1}','{2}','{3}','{4}'", BeginDate, EndDate, result, niMacIds, ppid)
        sql = "SELECT SaveTableName  from m_testtype_v where TestTypeID='" & ComboBox1.Text.Split("-")(0) & "'"
        Dim testtable As DataTable
        testtable= conn.GetDataTable(sql)

        Dim teble As String = testtable.Rows(0)("SaveTableName").ToString()
        sql = "SELECT  ppid ,RESULT, intime , TESTCOUNT FROM  MESDataCenter.DBO.m_TestResult_t  WHERE intime BETWEEN '" & BeginDate & "' and '" & EndDate & "' and stationid='" & ComboBox1.Text.Split("-")(0) & "'"
        If result <> "" Then
            sql = "SELECT  ppid ,RESULT, intime , TESTCOUNT FROM  MESDataCenter.DBO.m_TestResult_t  WHERE intime BETWEEN '" & BeginDate & "' and '" & EndDate & "' and stationid='" & ComboBox1.Text.Split("-")(0) & "' and  result='" & result & "'"

        End If
        If CobPPID.Text <> "" Then
            sql += " and ppid='" & CobPPID.Text & "'"
        End If
        Try
            dgNiResult.DataSource = Nothing
            dgNiResult.Refresh()
            dgNiResultDetail.DataSource = Nothing
            dgNiResultDetail.Refresh()
            Dim dt As DataTable = conn.GetDataTable(sql)
            Analsyse(dt)
            dgNiResult.DataSource = dt
            ChangeColumnStyle()
            ToolCount.Text = dt.Rows.Count
            'dgNiResultDetail.Rows.Clear()
        Catch ex As Exception
            Throw ex
        Finally
            conn.PubConnection.Close()
        End Try
    End Sub


    Private Sub Analsyse(ByVal dt As DataTable)
        Dim strOutput As String = Nothing
        Dim drs() As DataRow = Nothing
        Dim isItemAnalyse As Boolean = False
        Dim ngCount As Integer = dt.Select("RESULT='FAIL'").Length
        Dim totalCount As Integer = dt.Rows.Count

        If MultLanguage.Language.lang = "zh-cht" Then
            resultFormat3 = "{0}不良數:{1}pcs 不良率:{2}%"
        ElseIf MultLanguage.Language.lang = "en" Then
            resultFormat3 = "{0}Defective Num:{1}pcs Defective Rate:{2}%"
        End If

        LblNGcount.Text = String.Format(resultFormat1, ngCount)
        If totalCount = 0 Then
            totalCount = 1
        End If
        If ngCount <> 0 Then
            If cobShowStyle.SelectedIndex = 0 OrElse cobShowStyle.SelectedIndex = -1 Then
                LblNGqty.Text = String.Format(resultFormat2, Math.Round((ngCount / totalCount * 100), 3).ToString("0.000"))
            Else
                LblNGqty.Text = String.Format(resultFormat2, Math.Round((ngCount / totalCount * 100), 2).ToString("0.00"))
            End If
        End If
        ClearDics()
        'For Each dr As DataRow In dtBadItem.Select("KEYPOINT=1 ", "BADITEM")
        '    If Not String.IsNullOrEmpty(dr("KEYWORD").ToString) Then
        '        drs = dt.Select("RESULT='FAIL' AND FMSG LIKE '%" & dr("KEYWORD").ToString & "%' AND ISANALYSE=0")
        '        dicBadItem(dr("BADITEM").ToString) += drs.Length
        '        For Each drItem As DataRow In drs
        '            drItem("ISANALYSE") = 1
        '        Next
        '    End If
        'Next
        'For Each dr As DataRow In dtBadItem.Select("KEYPOINT=0 ", "BADITEM")
        '    If Not String.IsNullOrEmpty(dr("KEYWORD").ToString) Then
        '        drs = dt.Select("RESULT='FAIL' AND FMSG LIKE '" & dr("KEYWORD").ToString & "%' AND ISANALYSE=0")
        '        dicBadItem(dr("BADITEM").ToString) += drs.Length
        '        For Each drItem As DataRow In drs
        '            drItem("ISANALYSE") = 1
        '        Next
        '    End If
        'Next
        'If dtBadItem.Select("KEYWORD=''").Length > 0 Then
        '    Dim otherCount = dt.Select("RESULT='FAIL' AND ISANALYSE=0").Length
        '    For Each drItem As DataRow In drs
        '        drItem("ISANALYSE") = 1
        '    Next
        '    dicBadItem(dtBadItem.Select("KEYWORD=''")(0)("BADITEM").ToString) += otherCount
        'End If
        Dim index As Integer = 0
        For Each dic As KeyValuePair(Of String, Integer) In dicBadItem
            If dic.Value > 0 Then
                If cobShowStyle.SelectedIndex = 0 OrElse cobShowStyle.SelectedIndex = -1 Then
                    strOutput += String.Format(resultFormat3, dic.Key, dic.Value, Math.Round((dic.Value / totalCount * 100), 3).ToString("0.000")) + "     "
                Else
                    strOutput += String.Format(resultFormat3, dic.Key, dic.Value, Math.Round((dic.Value / totalCount * 100), 2).ToString("0.00")) + "     "
                End If
                index += 1
                If index Mod 2 = 0 Then
                    index = 0
                    strOutput = strOutput.Trim
                    strOutput += vbNewLine
                End If
            End If
        Next
        If Not String.IsNullOrEmpty(strOutput) Then
            If strOutput.EndsWith(vbNewLine) Then
                strOutput = strOutput.Substring(0, strOutput.LastIndexOf(vbNewLine)).Trim
            End If
        End If
        Label9.Text = ""
        Label9.Text = strOutput
    End Sub

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(Me.dgNiResult, Me.Text)
    End Sub


    Private Sub dgNiResult_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgNiResult.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim str As String
            str = "SELECT SaveTableName  from m_testtype_v where TestTypeID='" & ComboBox1.Text.Split("-")(0) & "'"
            Dim testtable As DataTable
            testtable = conn.GetDataTable(str)

            Dim teble As String = testtable.Rows(0)("SaveTableName").ToString()
            Dim sql As String = "SELECT * FROM MESDataCenter.dbo." & teble & " where " & vbNewLine
            sql &= " ppid='" & dgNiResult.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString & "'"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
            dgNiResultDetail.DataSource = dt
            'dgNiResultDetail.Columns(NiResultEnum.Asn).HeaderText = "ASN"
            'If MultLanguage.Language.lang = "zh-chs" Then
            '    dgNiResultDetail.Columns(NiResultEnum.Asn).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    dgNiResultDetail.Columns(NiResultEnum.TestTime).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    'dgNiResultDetail.Columns(NiResultEnum.LineId).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    'dgNiResultDetail.Columns(NiResultEnum.Fmsg).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    dgNiResultDetail.Columns(NiResultEnum.TestTime).DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss"
            '    dgNiResultDetail.Columns(NiResultEnum.Result).HeaderText = "测试结果"
            '    dgNiResultDetail.Columns(NiResultEnum.TestTime).HeaderText = "测试时间"
            '    'dgNiResultDetail.Columns(NiResultEnum.LineId).HeaderText = "机台编号"
            '    'dgNiResultDetail.Columns(NiResultEnum.Fmsg).HeaderText = "不良信息"
            '    'If (VbCommClass.VbCommClass.Factory = "LX21") OrElse (VbCommClass.VbCommClass.Factory = "LXVN") Then
            '    '    dgNiResultDetail.Columns(NiResultEnum.Fmsg).HeaderText = "不良信息"
            '    'End If
            'ElseIf MultLanguage.Language.lang = "zh-cht" Then
            '    dgNiResultDetail.Columns(NiResultEnum.Result).HeaderText = "測試結果"
            '    dgNiResultDetail.Columns(NiResultEnum.TestTime).HeaderText = "測試時間"
            '    'dgNiResultDetail.Columns(NiResultEnum.LineId).HeaderText = "機臺編號"
            '    'If (VbCommClass.VbCommClass.Factory = "LX21") OrElse (VbCommClass.VbCommClass.Factory = "LXVN") Then
            '    '    dgNiResultDetail.Columns(NiResultEnum.Fmsg).HeaderText = "不良信息"
            '    'End If
            'Else
            '    dgNiResultDetail.Columns(NiResultEnum.Result).HeaderText = "TestResult"
            '    dgNiResultDetail.Columns(NiResultEnum.TestTime).HeaderText = "TestTime"
            '    'dgNiResultDetail.Columns(NiResultEnum.LineId).HeaderText = "MachineId"
            '    'dgNiResultDetail.Columns(NiResultEnum.Fmsg).HeaderText = "Msg"
            '    'If (VbCommClass.VbCommClass.Factory = "LX21") OrElse (VbCommClass.VbCommClass.Factory = "LXVN") Then
            '    '    dgNiResultDetail.Columns(NiResultEnum.Fmsg).HeaderText = "Msg"
            '    'End If
            'End If

            'If (VbCommClass.VbCommClass.Factory = "LX21") OrElse (VbCommClass.VbCommClass.Factory = "LXVN") Then
            '    dgNiResultDetail.Columns(NiResultEnum.Fmsg).Visible = True
            'Else
            '    dgNiResultDetail.Columns(NiResultEnum.Fmsg).Visible = False
            'End If

            'Dim sql As String = "SELECT A.SN,A.RESULT,A.START_TIME,A.STATION_ID,A.LIST_OF_FAILING_TESTS FROM M_NITESTRECORD_T A" & vbNewLine
            'sql &= " WHERE A.SN='" & dgNiResult.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString & "'"
            'dgNiResultDetail.Rows.Clear()
            'Using dt As DataTable = conn.GetDataTable(sql)
            '    For Each dr As DataRow In dt.Rows
            '        dgNiResultDetail.Rows.Add(dr("SN").ToString, dr("RESULT").ToString, dr("START_TIME").ToString, dr("STATION_ID").ToString, dr("LIST_OF_FAILING_TESTS").ToString)
            '    Next
            'End Using
            ToolStripStatusLabel2.Text = dgNiResultDetail.Rows.Count
        End If
    End Sub

    Dim niMacIds As String = Nothing

    Private Sub CobLineId_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Not CobLineId.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CobLineId.SelectedItem) Then
            niMacIds = Nothing
            If ComboBox1.Text = "NI" Then
                For Each dr As DataRow In dtMacs.Select("LINEID='" & CobLineId.SelectedItem & "' AND NIMACID LIKE '%CON-FINAL%'")
                    If String.IsNullOrEmpty(niMacIds) Then
                        niMacIds = "''" + dr("NIMACID") + "'',"
                    Else
                        niMacIds += "''" + dr("NIMACID") + "'',"
                    End If
                Next

            End If
            If ComboBox1.Text = "APP" Then
                For Each dr As DataRow In dtMacs.Select("LINEID='" & CobLineId.SelectedItem & "' AND NIMACID LIKE '%QT1%'")
                    If String.IsNullOrEmpty(niMacIds) Then
                        niMacIds = "''" + dr("NIMACID") + "'',"
                    Else
                        niMacIds += "''" + dr("NIMACID") + "'',"
                    End If
                Next

            End If

            If Not String.IsNullOrEmpty(niMacIds) Then
                niMacIds = niMacIds.Trim(",")
            End If
        End If
    End Sub
    Public Sub SlectLine()
        If Not CobLineId.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(CobLineId.SelectedItem) Then
            niMacIds = Nothing
            If ComboBox1.Text = "NI" Then
                For Each dr As DataRow In dtMacs.Select("LINEID='" & CobLineId.SelectedItem & "' AND NIMACID LIKE '%CON-FINAL%'")
                    If String.IsNullOrEmpty(niMacIds) Then
                        niMacIds = "''" + dr("NIMACID") + "'',"
                    Else
                        niMacIds += "''" + dr("NIMACID") + "'',"
                    End If
                Next

            End If
            If ComboBox1.Text = "APP" Then
                For Each dr As DataRow In dtMacs.Select("LINEID='" & CobLineId.SelectedItem & "' AND NIMACID LIKE '%QT1%'")
                    If String.IsNullOrEmpty(niMacIds) Then
                        niMacIds = "''" + dr("NIMACID") + "'',"
                    Else
                        niMacIds += "''" + dr("NIMACID") + "'',"
                    End If
                Next

            End If

            If Not String.IsNullOrEmpty(niMacIds) Then
                niMacIds = niMacIds.Trim(",")
            End If
        End If
    End Sub
    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Not IsDBNull(ComboBox1.SelectedValue) AndAlso Not isFormLoad Then
            ComboBox1.Items.Clear()

            For i = 0 To Teststion.Rows.Count
                ComboBox1.Items.Add(Teststion.Rows(i)("TestTypeID") & "-" & Teststion.Rows(i)("TestTypeName"))
            Next
            ComboBox1.Items.Insert(0, "")
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim frmForm As New FrmNiRecordAnalyseQueryVN

   
        frmForm.Show()
    End Sub
End Class