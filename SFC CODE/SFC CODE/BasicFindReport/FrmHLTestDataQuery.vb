Imports MainFrame

Public Class FrmHLTestDataQuery
    Dim ExcelSql As String = ""
    Private Sub FrmHLTestDataQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
        Try
            'Dim mRead As SqlDataReader = ObjDB.GetDataReader("select TestTypeID,TestTypeName from m_TestType_v ")
            'If mRead.HasRows Then
            '    While mRead.Read
            '        CobDept.Items.Add(mRead!TestTypeID & "-" & mRead!TestTypeName)
            '    End While
            'End If
            'mRead.Close()
            Dim dt As DataTable = DbOperateReportUtils.GetDataTable("select DISTINCT ProductGroup from m_HLTestType_v where ProductGroup like 'HL%' ")

            UIHandler.UIFunction.Fill_Combobox(dt, CobProduct)

            CobProduct.SelectedIndex = 0


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.DefaultButton1, "提示信息")
        End Try
    End Sub
    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        Dim myThread As New Threading.Thread(AddressOf ShowWaitWindow)

        Try
            'If CobFactory.Text <> "" Then
            '    g_Factory = GetFactoryCode(CobFactory.Text)
            'Else
            '    g_Factory = ""
            'End If

            DgMoData.Focus()
            If Not CheckDate(DtStar, DtEnd) Then Exit Sub

            If Not CheckCondition() Then
                MsgBox("由于数据量较大，请输入更精确的查询条件...", 48, "提示")
                Exit Sub
            End If
            myThread.Start()
            ShowData()
            Threading.Thread.Sleep(300)
        Finally
            myThread.Abort()
        End Try
    End Sub
    Private Sub ShowData()
        Dim StartDT, EndDT As String
        'Dim ColsText As String
        'Dim i As Integer
        Dim Sqlstr As String = ""
        'Dim ColsName As String()
        Dim DtCtScan As DataTable

        StartDT = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        EndDT = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Sqlstr = " where Collecttime between '" & StartDT & "' and  '" & EndDT & "'"
        DgMoData.DataSource = Nothing
        DgMoData.Rows.Clear()

        Dim result As String = "%"

        'If CobDept.Text <> "" AndAlso LCase(CobDept.Text) <> "all" Then
        '    Sqlstr = Sqlstr & " and test_station_name='" & CobDept.Text.Split("-")(0) & "'"
        'End If
        'If CobPart.Text <> "" AndAlso LCase(CobPart.Text) <> "all" Then
        '    Sqlstr = Sqlstr & " and c.partid='" & CobPart.Text & "'"
        'End If
        'Dim SelectStr As String = ""
        'Dim KeyStr As String = ""
        'Dim mRead As SqlDataReader = ObjDB.GetDataReader("select SelectSql,KeyFileld from m_TestType_v where TestTypeID='" & CobDept.Text.Split("-")(0) & "'")
        'If mRead.HasRows Then
        '    While mRead.Read
        '        SelectStr = mRead!SelectSql
        '        KeyStr = mRead!KeyFileld
        '    End While
        'End If
        'mRead.Close()

        Dim ppid As String = ""
        If CobPPID.Text <> "" AndAlso LCase(CobPPID.Text) <> "all" Then
            If CobPPID.Lines.Length > 0 Then
                Dim ii As Integer = 0
                For ii = 0 To CobPPID.Lines.Length - 1
                    If CobPPID.Lines(ii).ToString.Trim = "" Then
                        Continue For
                    Else
                        ppid = ppid + CobPPID.Lines(ii).ToString.Trim + ","
                    End If
                Next
                ' Dim line1 As String = Me.CobPPID.Lines(0)
                ppid = ppid.Substring(0, ppid.Length - 1)
            End If
            ' Sqlstr = Sqlstr & " and  a.Exppid='" & CobPPID.Text & "'"

        Else
            ppid = "%"
        End If
        Dim productgroup As String = CobProduct.Text.Trim
        Dim moid As String = ""
        If txtMO.Text.Trim <> "" Then
            moid = txtMO.Text.Trim
        Else
            moid = "%"
        End If
        Dim partid As String = ""
        If txtPartID.Text.Trim <> "" Then
            partid = txtPartID.Text.Trim
        Else
            partid = "%"
        End If
        'ColsText = "moid|partid|product|sn|test_station_name|station_id|sw_version|result|start_time|stop_time|mac_address|list_of_failing_tests|failure_message|[override] "
        Dim sql As String = String.Format("m_QueryHLTestRecords_p '{0}','{1}','{2}','{3}','{4}','{5}','{6}'", StartDT, EndDT, productgroup, CobTestName.Text.Split("-")(0).Trim, ppid, moid, partid)
        Try
            ExcelSql = sql
            'DtCtScan = ObjDB.GetDataTable(SelectStr & Sqlstr)
            DtCtScan = DbOperateReportUtils.GetDataTable(sql)
            ToolCount.Text = DtCtScan.Rows.Count.ToString()
            'ColsName = ColsText.Split("|")
            DgMoData.DataSource = DtCtScan
            DgMoData.Refresh()
            DtCtScan.Dispose()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        If Me.DgMoData.RowCount < 1 Then Exit Sub
        LoadDataToExcel(Me.DgMoData, Me.Text)
    End Sub

    Private Function CheckCondition() As Boolean
        'If CobPPID.Text = "ALL" And CobMo.Text = "ALL" And CobPart.Text = "ALL" _
        '   And CobDept.Text = "ALL" And CobCus.Text = "ALL" And CoboLine.Text = "ALL" Then
        '    Return False
        'Else
        Return True
        'End If
    End Function


    Private Sub CobProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CobProduct.SelectedIndexChanged
        Try
            'Dim mRead As SqlDataReader = ObjDB.GetDataReader("select TestTypeID,TestTypeName from m_TestType_v ")
            'If mRead.HasRows Then
            '    While mRead.Read
            '        CobDept.Items.Add(mRead!TestTypeID & "-" & mRead!TestTypeName)
            '    End While
            'End If
            'mRead.Close()
            Dim dt As DataTable = DbOperateReportUtils.GetDataTable("select TestTypeID + '-' + TestTypeName FROM m_HLTestType_v where ProductGroup ='" & CobProduct.Text.Trim & "' ")

            UIHandler.UIFunction.Fill_Combobox(dt, CobTestName)

            CobTestName.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.DefaultButton1, "提示信息")
        End Try
    End Sub
End Class