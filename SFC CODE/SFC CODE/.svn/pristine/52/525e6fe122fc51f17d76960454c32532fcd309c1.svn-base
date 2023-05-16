'Option Strict On
Imports System.Drawing.Printing
Imports MainFrame.SysDataHandle
Imports SysBasicClass
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Class FrmSTDPrintCard
    Private Mo As String = ""
    Private isMultipMo As Boolean = False
    Private path As String = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\ProcessRunCard\ProcessRunCard.btw"
    Public Enum enumMOState
        ConfirmStart = 1 '        1	確認生產工單(firm plan) 	
        BOMNoPrint '2	工單已發放,料表尚未列印	
        BOMPrinted '3	工單已發放,料表已列印	
        MOSend '4	工單已發料	
        WIP '5	在製過程中	
        FQC '6	工單已完工,進入F.Q.C 	
        StoreIn '7	完工入庫	
        Close '8	結案	
        RBatchAndClose '9	工單成功分批并結案	
        ' RPrinted  ?? 'A	工單打印RUN CARD	
    End Enum
    Public Sub New(ByVal inputMo As String, ByVal inputMos As Boolean)
        Try
            Mo = inputMo
            ' 此调用是 Windows 窗体设计器所必需的。
            InitializeComponent()
            txtMo.Text = inputMo
            isMultipMo = inputMos
            ' 在 InitializeComponent() 调用之后添加任何初始化。
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FrmPrintCard_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Not LabelHelper.btFormatRunCard Is Nothing Then
                LabelHelper.btFormatRunCard.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
                LabelHelper.btFormatRunCard = Nothing
            End If
            If Not LabelHelper.btAppRunCard Is Nothing Then
                LabelHelper.btAppRunCard.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
                LabelHelper.KillProcessByIdS(LabelHelper.btAppRunCard.ProcessId)
                LabelHelper.btAppRunCard = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmPrintCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim a As Threading.Thread = New Threading.Thread(AddressOf LabelHelper.CreateInstance)
            a.Start()
            InitControls()
            If Not isMultipMo Then
                LoadChildPnInfo(Mo)
            Else
                ChkSelectAll.Enabled = False
                ChkPn.Enabled = False
            End If
            If txtMo.Text = "" Then
                txtMo.Select()
            Else
                cboPrinter.Select()
            End If
            Threading.Thread.Sleep(2000)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitControls()
        'txtMo.Text = Mo
        Label7.Text = ""
        txtCopies.Text = CStr(1)
        ChkSelectAll.Checked = True
        cboReportType.Items.Clear()
        cboReportType.Items.Insert(0, "在线流程卡")
        cboReportType.SelectedIndex = 0
        'cboReportType.Items.Insert(0, "")
        ChkPn.DataSource = Nothing
        InitPrinter()
        InitPrintType()
    End Sub

    Private Sub InitPrinter()
        cboPrinter.Items.Clear()
        Using pDoc As New PrintDocument
            Dim defaultPrinter As String = pDoc.PrinterSettings.PrinterName
            For Each printer As String In PrinterSettings.InstalledPrinters
                cboPrinter.Items.Add(printer)
            Next
            cboPrinter.Items.Insert(0, "")
        End Using
    End Sub

    Private Sub InitPrintType()
        Using dt As DataTable = New DataTable
            dt.Columns.Add("Value", System.Type.GetType("System.String"))
            dt.Columns.Add("Text", System.Type.GetType("System.String"))
            Dim dr As DataRow = dt.NewRow
            'dr(0) = "ONE-D"
            'dr(1) = "一维码打印"
            'dt.Rows.Add(dr)
            dr = dt.NewRow
            dr(0) = "TWO-D"
            dr(1) = "二维码打印"
            dt.Rows.Add(dr)
            'dr = dt.NewRow
            'dt.Rows.InsertAt(dr, 0)
            cboPrintType.DataSource = dt.DefaultView
            cboPrintType.DisplayMember = "Text"
            cboPrintType.ValueMember = "Value"
        End Using
    End Sub

    'Private Sub LoadChildPnInfo(ByVal mo As String)
    '    Dim sqlConn As New SysDataBaseClass
    '    Dim sql As String = Nothing
    '    'If IsInputMoEqualParentMo() Then
    '    '获取该工单的料号及其下面的所有子件的料号
    '    sql = "SELECT DISTINCT A.WEIGHT,A.PARTID,A.MOID FROM (SELECT A.MOID,A.PARTID,1 AS WEIGHT FROM M_RUNCARDWORKORDER_T A " & _
    '    " WHERE A.PARENTMO='" & mo.Trim & "' AND A.MOID<>PARENTMO AND A.ESTATEID<>2" & _
    '    " UNION " & _
    '    " SELECT  MOID ,PARTID,0 AS WEIGHT FROM M_RUNCARDWORKORDER_T  A  WHERE A.MOID='" & mo.Trim & "' ) A ORDER BY WEIGHT,A.PARTID, A.MOID"

    '    Using dt As DataTable = sqlConn.GetDataTable(sql)
    '        If dt.Rows.Count = 1 Then '说明该工单没有子件料号，很可能是子件工单
    '            ChkPn.DataSource = dt.DefaultView
    '            ChkPn.DisplayMember = "PARTID"
    '            ChkPn.ValueMember = "MOID"
    '        ElseIf dt.Rows.Count > 1 Then '存在子件工单，该工单肯能是成套工单
    '            dt.Rows.RemoveAt(0)
    '            'For Each row As DataRow In dt.Rows
    '            'Next
    '            ChkPn.DataSource = dt.DefaultView
    '            ChkPn.DisplayMember = "PARTID"
    '            ChkPn.ValueMember = "MOID"
    '        End If
    '    End Using
    '    ChkSelectAll_CheckedChanged(Nothing, Nothing)
    '    sqlConn = Nothing
    'End Sub

    Private Sub LoadChildPnInfo(ByVal MO As String)
        Dim sqlConn As New SysDataBaseClass
        Dim sql As String = Nothing
        '获取该工单的料号及其下面的所有子件的料号
        sql = _
                "SELECT DISTINCT A.WEIGHT, A.PARTID, A.MOID" + vbCrLf + _
                "  FROM (SELECT A.MOID, A.PARTID, 1 AS WEIGHT" + vbCrLf + _
                "          FROM m_MainMO_t A" + vbCrLf + _
                "         WHERE     A.PARENTMO = '" & MO & "'" + vbCrLf + _
                "               AND A.MOID <> PARENTMO" + vbCrLf + _
                "               AND A.ESTATEID <> 'A'" + vbCrLf + _
                "        UNION" + vbCrLf + _
                "        SELECT MOID, PARTID, 0 AS WEIGHT" + vbCrLf + _
                "          FROM m_MainMO_t A" + vbCrLf + _
                "         WHERE A.MOID = '" & MO & "') A" + vbCrLf + _
                "ORDER BY WEIGHT, A.PARTID, A.MOID"

        Using dt As DataTable = sqlConn.GetDataTable(sql)
            If dt.Rows.Count = 1 Then '说明该工单没有子件料号，很可能是子件工单
                ChkPn.DataSource = dt.DefaultView
                ChkPn.DisplayMember = "PARTID"
                ChkPn.ValueMember = "MOID"
            ElseIf dt.Rows.Count > 1 Then '存在子件工单，该工单肯能是成套工单
                dt.Rows.RemoveAt(0)
                ChkPn.DataSource = dt.DefaultView
                ChkPn.DisplayMember = "PARTID"
                ChkPn.ValueMember = "MOID"
            End If
        End Using
        ChkSelectAll_CheckedChanged(Nothing, Nothing)
        sqlConn = Nothing
    End Sub

    Private dics As New Dictionary(Of String, String)
    Private partIds As String = Nothing
    Private moids As String = Nothing
    Private sMOs As New ArrayList()

    Private Sub PrintByMultipMo()
        Dim pn As String = Nothing
        Dim pns As String = Nothing
        dics.Clear()
        sMOs.Clear()
        For Each sMO As String In Mo.Split(CChar(vbNewLine))
            partIds = Nothing
            moids = Nothing
            If Not String.IsNullOrEmpty(sMO) AndAlso sMO <> "" Then
                LoadChildPnInfo(sMO)
                If Not CheckPnEffective(sMO.Trim, pn) Then
                    If String.IsNullOrEmpty(pns) Then
                        pns += pn + ","
                    End If
                    If Not String.IsNullOrEmpty(pns) AndAlso Not pns.Contains(pn) Then
                        pns += pn + ","
                    End If
                    pn = Nothing
                Else
                    For i As Integer = 0 To ChkPn.Items.Count - 1
                        partIds += "'" + ChkPn.Items(i)("PARTID") + "'" + ","
                        moids += "'" + ChkPn.Items(i)("MOID") + "'" + ","
                    Next
                    If Not String.IsNullOrEmpty(partIds) Then partIds = partIds.Trim(CChar(","))
                    If Not String.IsNullOrEmpty(moids) Then moids = moids.Trim(CChar(","))
                    dics.Add(moids, partIds)
                    sMOs.Add(sMO)
                End If
            End If
        Next
        If Not String.IsNullOrEmpty(pns) Then pns = pns.Trim(CChar(","))
        If Not String.IsNullOrEmpty(pns) Then
            If MessageBox.Show("料件{" + pns + "}流程卡未生效或是未维护或版本错误或是未下载BOM配置清单,请通知相关人员！！") = Windows.Forms.DialogResult.OK Then
                If dics.Count <= 0 Then
                    Exit Sub
                End If
            End If
        End If
        Dim index As Integer = 0
        Using fm As New FrmSTDShowRunCard("")
            For Each dic As KeyValuePair(Of String, String) In dics
                fm.pn = GetMoPn(CStr(sMOs(index)))
                fm.mo = CStr(sMOs(index))
                fm.reportInputParametersVar.Pn = ""
                fm.reportInputParametersVar.Mo = ""
                fm.reportInputParametersVar.Pn = dic.Value
                fm.reportInputParametersVar.Mo = dic.Key
                If fm.reportInputParametersVar.Pn.Contains(",") Then
                    fm.reportInputParametersVar.printAll = True
                Else
                    fm.reportInputParametersVar.printAll = False
                End If
                fm.reportInputParametersVar.printerName = CStr(cboPrinter.SelectedItem)
                fm.reportInputParametersVar.reportTypeFlag = FrmSTDShowRunCard.ReportType.PorcessCardReport
                fm.reportInputParametersVar.printTypeFlag = FrmSTDShowRunCard.PrintType.PrintReport
                fm.reportInputParametersVar.copies = CInt(txtCopies.Text)
                fm.reportInputParametersVar.PrintMethod = cboPrintType.SelectedValue.ToString
                'fm.reportInputParametersVar.Mo = txtMo.Text
                'fm.ShowOrPrintReport()
                'ChkPn.DataSource = Nothing
                Dim idx As Integer = 0
                Threading.Thread.Sleep(200)
                Using dt As DataTable = GetPrintProcessCardDataTable(GetProcessRunCardSql(fm.reportInputParametersVar.Pn, fm.reportInputParametersVar.Mo, GetMoPn(CStr(sMOs(index)))))
                    If dt.Rows.Count > 0 Then
                        Label7.Text = "打印中,请稍等......"
                        LabelHelper.PrintProcessCard(dt, CStr(cboPrinter.SelectedItem), path, CInt(txtCopies.Text), fm.reportInputParametersVar.Pn)
                        Label7.Text = ""
                    End If
                End Using
                index += 1
                ChkPn.DataSource = Nothing
            Next
        End Using
        If dics.Count > 0 Then
            MessageBox.Show("打印作业流程卡成功", "提示信息")
        End If
    End Sub

    Private Sub InitPara()
        If txtMo.Text.EndsWith(vbNewLine) Then
            txtMo.Text = txtMo.Text.Substring(0, txtMo.Text.LastIndexOf(vbNewLine)).Trim
        End If
        If txtMo.Text.StartsWith(vbNewLine) Then
            txtMo.Text = txtMo.Text.Substring(txtMo.Text.IndexOf(vbNewLine), txtMo.Text.Length).Trim
        End If
        If txtMo.Text.Trim().Split(CChar(vbNewLine)).Length > 1 Then
            isMultipMo = True
            Mo = txtMo.Text
            ChkSelectAll.Enabled = False
            ChkPn.Enabled = False
            ChkPn.DataSource = Nothing
        Else
            ChkSelectAll.Enabled = True
            ChkPn.Enabled = True
            isMultipMo = False
            LoadChildPnInfo(txtMo.Text)
        End If
    End Sub

    'Private Function CheckPnEffective(ByVal mo As String, ByRef pn As String) As Boolean
    '    Dim sqlConn As New MainFrame.SysDataHandle.SysDataBaseClass
    '    Dim index As Integer = 0
    '    Dim moPn As String = GetMoPn(mo)

    '    Dim sql As String = "SELECT DISTINCT A.PARTNUMBER FROM M_RUNCARDPARTNUMBER_T A,M_RUNCARD_T B,M_RUNCARDWORKORDER_T C" & vbNewLine & _
    '  " WHERE A.ID=B.PARTID AND B.STATUS=1 AND A.PARTNUMBER=C.PARTID AND B.DRAWINGVER=C.VERSION AND C.PARENTMO='" & mo & "' AND C.PARTID IN("
    '    For i As Integer = 0 To ChkPn.Items.Count - 1
    '        If ChkPn.GetItemChecked(i) Then
    '            sql += "'" + ChkPn.Items(i)("PARTID") + "'" + ","
    '            index += 1
    '        End If
    '    Next
    '    sql = sql.Trim(",")
    '    sql += ")"
    '    Using dt As DataTable = sqlConn.GetDataTable(sql)
    '        If dt.Rows.Count <= 0 OrElse dt.Rows.Count <> index Then
    '            If ChkPn.Items.Count > 1 Then
    '                pn = moPn
    '            ElseIf ChkPn.Items(0)("PARTID").ToString <> moPn Then
    '                pn = moPn
    '            Else
    '                pn = ChkPn.Items(0)("PARTID").ToString
    '            End If
    '        End If
    '    End Using
    '    sqlConn = Nothing
    '    If Not String.IsNullOrEmpty(pn) Then
    '        Return False
    '    End If
    '    If Not CheckPnDownloadBom(mo, pn) Then Return False
    '    ' If Not CheckPnVersion(mo, pn) Then Return False
    '    Return True
    'End Function

    Private Function CheckPnEffective(ByVal mo As String, ByRef pn As String) As Boolean
        Dim sqlConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim index As Integer = 0
        Dim moPn As String = GetMoPn(mo)

        ' Dim sql As String = "SELECT DISTINCT A.PARTNUMBER FROM M_RUNCARDPARTNUMBER_T A,M_RUNCARD_T B,M_RUNCARDWORKORDER_T C" & vbNewLine & _
        '" WHERE A.ID=B.PARTID AND B.STATUS=1 AND A.PARTNUMBER=C.PARTID AND B.DRAWINGVER=C.VERSION AND C.PARENTMO='" & mo & "' AND C.PARTID IN("

        Dim SQL As String = _
                    "SELECT DISTINCT a.TAvcPart" + vbCrLf + _
                    "  FROM m_PartContrast_t a, m_RCardM_t b, m_Mainmo_t c" + vbCrLf + _
                    " WHERE     A.TAvcPart = B.PARTID" + vbCrLf + _
                    "       AND B.STATUS = 1" + vbCrLf + _
                    "       AND A.TAvcPart = C.PARTID" + vbCrLf + _
                    "       AND B.DRAWINGVER = C.VERSION" + vbCrLf + _
                    "       AND (C.PARENTMO = '" & mo & "' OR  C.MOID='" & mo & "')" + vbCrLf + _
                    "       AND C.PARTID IN ("

        For i As Integer = 0 To ChkPn.Items.Count - 1
            If ChkPn.GetItemChecked(i) Then
                SQL += "'" + CStr(ChkPn.Items(i)("PARTID")) + "'" + ","
                index += 1
            End If
        Next
        SQL = SQL.Trim(CChar(","))
        SQL += "  ) and b.Factoryid = '" & VbCommClass.VbCommClass.Factory & "' AND b.Profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'"
        Using dt As DataTable = sqlConn.GetDataTable(SQL)
            If dt.Rows.Count <= 0 OrElse dt.Rows.Count <> index Then
                If ChkPn.Items.Count > 1 Then
                    pn = moPn
                ElseIf ChkPn.Items(0)("PARTID").ToString <> moPn Then
                    pn = moPn
                Else
                    pn = ChkPn.Items(0)("PARTID").ToString
                End If
            End If
        End Using
        sqlConn = Nothing
        If Not String.IsNullOrEmpty(pn) Then
            Return False
        End If
        If Not CheckPnDownloadBom(mo, pn) Then Return False
        ' If Not CheckPnVersion(mo, pn) Then Return False
        Return True
    End Function

    'Private Function CheckPnDownloadBom(ByVal mo As String, ByRef pn As String) As Boolean
    '    Dim moPn As String = GetMoPn(mo)
    '    If ChkPn.Items.Count = 1 AndAlso ChkPn.Items(0)("PARTID").ToString = moPn Then Return True

    '    Dim sqlConn As New MainFrame.SysDataHandle.SysDataBaseClass
    '    Dim index As Integer = 0
    '    Dim sql As String = "SELECT DISTINCT B.PARTNUMBER FROM M_RUNCARDPARTNUMBER_T A,M_RUNCARDPARTNUMBER_T B,M_RUNCARDBOMINFO_T C " & vbNewLine & _
    '    " WHERE A.PARTNUMBER='" & moPn & "' AND B.PARTNUMBER IN("
    '    For i As Integer = 0 To ChkPn.Items.Count - 1
    '        If ChkPn.GetItemChecked(i) Then
    '            sql += "'" + ChkPn.Items(i)("PARTID") + "'" + ","
    '            index += 1
    '        End If
    '    Next
    '    sql = sql.Trim(",")
    '    sql += ") AND C.PARENTPARTID=A.ID AND C.PARTID=B.ID"
    '    Using dt As DataTable = sqlConn.GetDataTable(sql)
    '        If dt.Rows.Count <= 0 OrElse dt.Rows.Count <> index Then
    '            If ChkPn.Items.Count > 1 Then
    '                pn = moPn
    '            ElseIf ChkPn.Items(0)("PARTID").ToString <> moPn Then
    '                pn = moPn
    '            ElseIf ChkPn.Items(0)("PARTID").ToString = moPn Then

    '            End If
    '        End If
    '    End Using
    '    sqlConn = Nothing
    '    If Not String.IsNullOrEmpty(pn) Then Return False
    '    Return True
    'End Function

    Private Function CheckPnDownloadBom(ByVal mo As String, ByRef pn As String) As Boolean
        Dim moPn As String = GetMoPn(mo)
        If ChkPn.Items.Count = 1 AndAlso ChkPn.Items(0)("PARTID").ToString = moPn Then Return True

        Dim sqlConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim index As Integer = 0

        Dim sql As String = "SELECT DISTINCT TAvcPart FROM m_PartContrast_t " & vbNewLine & _
        " WHERE PAvcPart='" & moPn & "' AND  TAvcPart IN("
        For i As Integer = 0 To ChkPn.Items.Count - 1
            If ChkPn.GetItemChecked(i) Then
                sql += "'" + ChkPn.Items(i)("PARTID") + "'" + ","
                index += 1
            End If
        Next
        sql = sql.Trim(CChar(","))
        sql += ") "
        Using dt As DataTable = sqlConn.GetDataTable(sql)
            If dt.Rows.Count <= 0 OrElse dt.Rows.Count <> index Then
                If ChkPn.Items.Count > 1 Then
                    pn = moPn
                ElseIf ChkPn.Items(0)("PARTID").ToString <> moPn Then
                    pn = moPn
                ElseIf ChkPn.Items(0)("PARTID").ToString = moPn Then

                End If
            End If
        End Using
        sqlConn = Nothing
        If Not String.IsNullOrEmpty(pn) Then Return False
        Return True
    End Function

    '
    'Private Function CheckPnVersion(ByVal MO As String, ByRef pn As String) As Boolean
    '    Dim sqlConn As New MainFrame.SysDataHandle.SysDataBaseClass
    '    Dim index As Integer = 0
    '    Dim sql As String = "SELECT DISTINCT A.PARTNUMBER FROM M_RUNCARDPARTNUMBER_T A,M_RUNCARD_T B,M_RUNCARDWORKORDER_T C " & vbNewLine & _
    '    " WHERE A.ID=B.PARTID AND A.PARTNUMBER=C.PARTID AND B.DRAWINGVER=C.VERSION AND C.PARENTMO='" & MO & "' AND C.PARTID IN("
    '    For i As Integer = 0 To ChkPn.Items.Count - 1
    '        If ChkPn.GetItemChecked(i) Then
    '            sql += "'" + ChkPn.Items(i)("PARTID") + "'" + ","
    '            index += 1
    '        End If
    '    Next
    '    sql = sql.Trim(",")
    '    sql += ")"
    '    Using dt As DataTable = sqlConn.GetDataTable(sql)
    '        If dt.Rows.Count <= 0 OrElse dt.Rows.Count <> index Then
    '            If ChkPn.Items.Count > 1 Then
    '                pn = GetMoPn(MO)
    '            Else
    '                pn = ChkPn.Items(0)("PARTID").ToString
    '            End If
    '        End If
    '    End Using
    '    sqlConn = Nothing
    '    If Not String.IsNullOrEmpty(pn) Then Return False
    '    Return True
    'End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim pn As String = Nothing
        Try
            If Not CheckBasicInput() Then
                Exit Sub
            End If
            If isMultipMo Then
                PrintByMultipMo()
                Exit Sub
            End If
            If CheckMoStatus() Then
                Exit Sub
            End If
            If Not CheckPnEffective(txtMo.Text.Trim, pn) Then
                MessageBox.Show("料件{" + pn + "}未生效或是未维护流程卡或版本错误或是未下载BOM配置清单,请通知工程人员！！")
                Exit Sub
            End If
            Using fm As New FrmSTDShowRunCard(GetMoPn(txtMo.Text))
                For i As Integer = 0 To ChkPn.Items.Count - 1
                    If ChkPn.GetItemChecked(i) Then
                        fm.reportInputParametersVar.Pn += "'" + ChkPn.Items(i)("PARTID") + "'" + ","
                        fm.reportInputParametersVar.Mo += "'" + ChkPn.Items(i)("MOID") + "'" + ","
                    End If
                Next
                fm.mo = txtMo.Text.Trim
                fm.reportInputParametersVar.Pn = fm.reportInputParametersVar.Pn.Trim(CChar(","))
                fm.reportInputParametersVar.Mo = fm.reportInputParametersVar.Mo.Trim(CChar(","))
                fm.reportInputParametersVar.PrintMethod = cboPrintType.SelectedValue.ToString
                If fm.reportInputParametersVar.Pn.Contains(",") Then
                    fm.reportInputParametersVar.printAll = True
                Else
                    fm.reportInputParametersVar.printAll = False
                End If
                fm.reportInputParametersVar.printerName = CStr(cboPrinter.SelectedItem)
                fm.reportInputParametersVar.reportTypeFlag = FrmSTDShowRunCard.ReportType.PorcessCardReport
                fm.reportInputParametersVar.printTypeFlag = FrmSTDShowRunCard.PrintType.PrintReport
                fm.reportInputParametersVar.copies = CInt(txtCopies.Text)
                'fm.ShowOrPrintReport()
                Dim idx As Integer = 0
                Using dt As DataTable = GetPrintProcessCardDataTable(CStr(GetProcessRunCardSql(fm.reportInputParametersVar.Pn, fm.reportInputParametersVar.Mo, GetMoPn(txtMo.Text))))
                    If dt.Rows.Count > 0 Then
                        Label7.Text = "打印中,请稍等......"
                        LabelHelper.PrintProcessCard(dt, CStr(cboPrinter.SelectedItem), path, CInt(txtCopies.Text), fm.reportInputParametersVar.Pn)
                        Label7.Text = ""
                    End If
                End Using

            End Using
            ChkPn.DataSource = Nothing
            MessageBox.Show("打印作业流程卡成功", "提示信息")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function CheckBasicInput() As Boolean
        If txtMo.Text = "" Then
            MessageBox.Show("工单不能为空", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If cboReportType.SelectedItem.ToString = "" Or cboReportType.SelectedItem Is Nothing Then
            MessageBox.Show("请选择流程卡类型", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If cboPrintType.SelectedValue Is Nothing Or String.IsNullOrEmpty(cboPrintType.SelectedValue.ToString) Then
            MessageBox.Show("请选择打印方式", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If IsNothing(cboPrinter.SelectedItem) OrElse String.IsNullOrEmpty(CStr(cboPrinter.SelectedItem)) Then 'cboPrinter.SelectedItem = "" Or cboPrinter.SelectedItem = Nothing Then
            MessageBox.Show("请选择打印机", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If (ChkPn.CheckedItems.Count = 0 AndAlso isMultipMo = False) Then
            MessageBox.Show("请选择需要打印的料件", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If txtCopies.Text = "" Or Not IsNumeric(txtCopies.Text) Then
            MessageBox.Show("打印份数不能为空且必须为大于零的整数", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtMo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMo.KeyPress
        'If e.KeyChar = Chr(13) Then
        '    If CheckMoStatus() Then
        '        Exit Sub
        '    End If
        '    ChkPn.DataSource = Nothing
        '    'Mo = txtMo.Text
        '    LoadChildPnInfo(txtMo.Text)
        '    cboReportType.Select()
        'End If
        If e.KeyChar = Chr(13) Then
            InitPara()
        End If
    End Sub

    Private Function CheckMoStatus() As Boolean
        Dim sqlConn As New MainFrame.SysDataHandle.SysDataBaseClass
        ' Dim sqlString As String = "SELECT MOID FROM M_RUNCARDWORKORDER_T WHERE MOID='" & txtMo.Text.Trim & "' AND ESTATEID=2 AND FINALY='Y'"
        Dim sqlString As String = "SELECT MOID FROM M_MainMO_T WHERE MOID='" & txtMo.Text.Trim & "' AND ESTATEID='" & enumMOState.RBatchAndClose & "' AND FINALY='Y'"
        If sqlConn.GetRowsCount(sqlString) = 1 Then
            MessageBox.Show("工单：" + txtMo.Text + "已经分批,不需要列印流程卡", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return True
        End If
        Return False
    End Function

    Private Function IsInputMoEqualParentMo() As Boolean
        Dim sqlConn As New MainFrame.SysDataHandle.SysDataBaseClass
        'select * from m_Mainmo_t where moid ='E511D-141101448' and moid = ParentMo
        Dim sqlString As String = "SELECT MOID FROM M_MainMO_T WHERE MOID='" & txtMo.Text.Trim & "' AND MOID=PARENTMO"
        If sqlConn.GetRowsCount(sqlString) = 1 Then
            Return True
        End If
        Return False
    End Function

    Private Sub ChkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSelectAll.CheckedChanged
        For i As Integer = 0 To ChkPn.Items.Count - 1
            ChkPn.SetItemChecked(i, ChkSelectAll.Checked)
        Next
    End Sub

    '有以下几种情况
    '1.当MO为成套工单时，查看其下面的每个单根的料件是否存在M_RUNCARDPARTNUMBER_T,不存在,重新download（一般维护了流程卡就会有）主要防止先download工单在维护流程卡
    '2.当MO为单根工单其下面没有可展开的子件则为该工单对应的料件是否存在
    '3.当MO为单根工单其下面有可展开的子件，这种情况类似1，把单根工单看成是成套工单，其下面可展开的子件相当于成套下面的单根料件(但是这种情况不知道有没有)
    Private Function CheckNeedReloadBom() As Boolean
        Dim sConn As SysDataBaseClass = New SysDataBaseClass
        'Dim sql As String = "SELECT A.PARTID FROM M_RUNCARDWORKORDER_T A " & _
        '                    " LEFT JOIN M_RUNCARDPARTNUMBER_T B ON A.PARTID=B.PARTNUMBER WHERE A.PARENTMO='" & txtMo.Text & "' AND B.PARTNUMBER IS NULL "

        Dim sql As String = _
                            "SELECT A.PARTID" + vbCrLf + _
                            "  FROM M_MainMO_T A LEFT JOIN m_PartContrast_t B ON A.PARTID = B.TAvcPart" + vbCrLf + _
                            " WHERE A.PARENTMO = '" & txtMo.Text & "' AND B.TAvcPart IS NULL"
        Return sConn.GetRowsCount(sql) > 0
    End Function

    'Private Function GetMoPn(ByVal mo As String) As String
    '    Dim sConn As SysDataBaseClass = New SysDataBaseClass
    '    Dim sql As String = "SELECT PARTID  FROM M_RUNCARDWORKORDER_T WHERE MOID = '" & mo.Trim & "'"
    '    Dim pn As String = ""
    '    Using dt As DataTable = sConn.GetDataTable(sql)
    '        If dt.Rows.Count > 0 Then
    '            pn = dt.Rows(0)(0)
    '        End If
    '    End Using
    '    sConn = Nothing
    '    Return pn
    'End Function

    Private Function GetMoPn(ByVal mo As String) As String
        Dim sConn As SysDataBaseClass = New SysDataBaseClass
        Dim sql As String = "SELECT PARTID  FROM M_MainMO_T WHERE MOID = '" & mo.Trim & "'"
        Dim pn As String = ""
        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                pn = CStr(dt.Rows(0)(0))
            End If
        End Using
        sConn = Nothing
        Return pn
    End Function

    Private Function GetProcessRunCardSql(ByVal cpn As String, ByVal mo As String, ByVal pn As String) As String
        'Dim sql As String = "SELECT ROW_NUMBER() OVER(PARTITION BY A.PARTNUMBER ORDER BY A.PARTNUMBER,C.STATIONSQ) ID," & vbNewLine & _
        '"D.STATIONNAME WORKSTATIONCONTENT," & vbNewLine & _
        '" 'F/'+M.MOID+'/'+CAST(A.ID AS VARCHAR)+'/'+CAST(D.ID AS VARCHAR) FUNCTIONBARCODE,  " & vbNewLine & _
        '" M.MOQTY * ISNULL(E.QTY,1)  MOQTY ,A.PARTNUMBER PN,M.MOID,'' COMMENT,M.ORDERNO,ISNULL(E.QTY,1) ConfigQty,M.MOQTY MQTY,'' BarcodePath " & vbNewLine & _
        '" FROM M_RUNCARDPARTNUMBER_T A 
        'LEFT JOIN M_RUNCARDBOMINFO_T E ON A.ID=E.PARTID 
        'LEFT JOIN M_RUNCARDPARTNUMBER_T F ON  F.PARTNUMBER='" & pn & "' AND E.PARENTPARTID=F.ID" & vbNewLine & _
        '",M_RUNCARD_T B,M_RUNCARDDETAIL_T C,M_RUNCARDWORKORDER_T M, M_RUNCARDSTATION_T D " & vbNewLine & _
        '" WHERE M.PARTID IN(" & cpn & ") " & vbNewLine & _
        '" AND M.MOID IN(" & mo & ")" & vbNewLine & _
        '" AND M.PARTID=A.PARTNUMBER" & vbNewLine & _
        '" AND A.ID =B.PARTID" & vbNewLine & _
        '" AND B.ID=C.RUNCARDID  " & vbNewLine & _
        '" AND C.STATIONID =D.ID " & vbNewLine & _
        '" AND B.STATUS=1 " & vbNewLine & _
        '" AND C.STATUS=1"
        'Return sql
        'Modify by cq 20151223, add A.TAVCPART<> A.PAVCPART
        Dim sql As String = _
              "SELECT ROW_NUMBER ()" + vbCrLf + _
              "          OVER (PARTITION BY A.TAvcPart ORDER BY A.TAvcPart, C.STATIONSQ)" + vbCrLf + _
              "          ID," + vbCrLf + _
              "       D.STATIONNAME WORKSTATIONCONTENT," + vbCrLf + _
              "       'F/' + M.MOID + '/' + D.Stationid AS FUNCTIONBARCODE," + vbCrLf + _
              "       M.MOQTY * ISNULL (A.AmountQty, 1) MOQTY," + vbCrLf + _
              "       A.TAvcPart PN," + vbCrLf + _
              "       M.MOID," + vbCrLf + _
              "       '' COMMENT," + vbCrLf + _
              "       M.ORDERNO," + vbCrLf + _
              "       ISNULL (A.AmountQty, 1) ConfigQty," + vbCrLf + _
              "       M.MOQTY MQTY," + vbCrLf + _
              "       '' BarcodePath" + vbCrLf + _
              "  FROM m_PartContrast_t A," + vbCrLf + _
              "       M_RCARDM_T B," + vbCrLf + _
              "       M_RCardD_T C," + vbCrLf + _
              "       M_MainMO_t M," + vbCrLf + _
              "       M_RSTATION_T D" + vbCrLf + _
              " WHERE     M.PARTID IN (" & cpn & ")" + vbCrLf + _
              "       AND M.MOID IN (" & mo & ")" + vbCrLf + _
              "       AND M.PARTID = A.TAvcPart" + vbCrLf + _
              "       AND A.TAvcPart = B.PARTID" + vbCrLf + _
              "       AND B.partID = C.PartID" + vbCrLf + _
              "       AND C.STATIONID = D.Stationid" + vbCrLf + _
              "       AND A.TAVCPART<> A.PAVCPART" + vbCrLf + _
              "       AND B.STATUS = 1" + vbCrLf + _
              "       AND C.STATUS = 1" & _
              "  AND B.factoryid ='" & VbCommClass.VbCommClass.Factory & "'  AND B.Profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'" & _
              "  AND C.FACTORYID = M.Factory"
        Return sql
    End Function

    Private Function GetPrintProcessCardDataTable(ByVal sql As String) As DataTable
        Dim sConn As SysDataBaseClass = New SysDataBaseClass
        Return sConn.GetDataTable(sql)
    End Function

    Private Sub FrmSTDPrintCard_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        '  DllImport("uxtheme.dll")
    End Sub
End Class

#Region "ReDownload Bom Info"
Public Class STDReloadBomInfo

    Private Enum BomInfo
        ID = 0
        ParentPartId
        ChildPartId
        Version
        Format
        CFormat '子的描述
        ParentDescription
        ChildDescription
        EffectiveDate
        ExpirationDate
        Extensible
        Qty
    End Enum
    '该redownload 的功能可能会下载很多无用的料件信息
    'Public Shared Sub ReloadBom(ByVal rpn As String)
    '    Dim sql As System.Text.StringBuilder
    '    Dim sConn As SysDataBaseClass
    '    Try
    '        Using dt As DataTable = GetBomInfoFormErp(rpn)
    '            If dt.Rows.Count > 0 Then
    '                sql = New System.Text.StringBuilder
    '                sql.Append(" DELETE FROM M_RUNCARDBOMINFO_T WHERE PARENTPARTID IN(SELECT A.PARTID FROM M_RUNCARDBOMINFO_T A,M_RUNCARDPARTNUMBER_T B WHERE B.PARTNUMBER='" & rpn & "' AND B.ID=A.PARENTPARTID)").Append(vbNewLine)
    '                sql.Append(" DELETE FROM M_RUNCARDBOMINFO_T WHERE PARENTPARTID IN(SELECT ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & rpn & "')").Append(vbNewLine)
    '                For i As Integer = 0 To dt.Rows.Count - 1
    '                    sql.Append(" IF NOT EXISTS(SELECT 1 FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "') begin").Append(vbNewLine)
    '                    sql.Append(" INSERT INTO M_RUNCARDPARTNUMBER_T(PARTNUMBER,DESCRIPTION,STATUS,USERID,INTIME,DESCRIPTION1,TYPE) VALUES('" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "',").Append(vbNewLine)
    '                    sql.Append(" N'" & dt.Rows(i)(BomInfo.ParentDescription).ToString.Replace("'", "''") & "','1','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & dt.Rows(i)(BomInfo.Format).ToString.Replace("'", "''") & "','R') end ").Append(vbNewLine)
    '                    sql.Append(" ELSE BEGIN UPDATE M_RUNCARDPARTNUMBER_T SET DESCRIPTION=N'" & dt.Rows(i)(BomInfo.ParentDescription).ToString.Replace("'", "''") & "',DESCRIPTION1=N'" & dt.Rows(i)(BomInfo.Format).ToString.Replace("'", "''") & "' WHERE PARTNUMBER='" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "' END").Append(vbNewLine)
    '                    sql.Append(" IF NOT EXISTS(SELECT 1 FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & dt.Rows(i)(BomInfo.ChildPartId).ToString & "') begin").Append(vbNewLine)
    '                    sql.Append(" INSERT INTO M_RUNCARDPARTNUMBER_T(PARTNUMBER,DESCRIPTION,STATUS,USERID,INTIME,DESCRIPTION1,TYPE) VALUES('" & dt.Rows(i)(BomInfo.ChildPartId).ToString & "',").Append(vbNewLine)
    '                    sql.Append(" N'" & dt.Rows(i)(BomInfo.ChildDescription).ToString.Replace("'", "''") & "','1','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & dt.Rows(i)(BomInfo.CFormat).ToString.Replace("'", "''") & "','R') end").Append(vbNewLine)
    '                    sql.Append(" ELSE BEGIN UPDATE M_RUNCARDPARTNUMBER_T SET DESCRIPTION=N'" & dt.Rows(i)(BomInfo.ChildDescription).ToString.Replace("'", "''") & "',DESCRIPTION1=N'" & dt.Rows(i)(BomInfo.CFormat).ToString.Replace("'", "''") & "' WHERE PARTNUMBER='" & dt.Rows(i)(BomInfo.ChildPartId).ToString & "' END").Append(vbNewLine)
    '                    sql.Append(" IF NOT EXISTS(SELECT 1 FROM M_RUNCARDBOMINFO_T WHERE PARENTPARTID=(SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "') AND PARTID=(SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & dt.Rows(i)(BomInfo.ChildPartId).ToString & "')) begin").Append(vbNewLine)
    '                    sql.Append(" INSERT INTO M_RUNCARDBOMINFO_T(PARENTPARTID,PARTID,STATUS,USERID,INTIME,EXTENSIBLE,QTY,EFFECTIVEDATE,EXPIRATIONDATE,VERSION,FORMAT) ").Append(vbNewLine)
    '                    sql.Append(" VALUES((SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "'),").Append(vbNewLine)
    '                    sql.Append("(SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & dt.Rows(i)(BomInfo.ChildPartId).ToString & "'),'1','" & VbCommClass.VbCommClass.UseId & "',getdate(),'" & dt.Rows(i)(BomInfo.Extensible).ToString & "','" & dt.Rows(i)(BomInfo.Qty).ToString & "'").Append(vbNewLine)
    '                    sql.Append(",'" & dt.Rows(i)(BomInfo.EffectiveDate).ToString & "','" & dt.Rows(i)(BomInfo.ExpirationDate).ToString & "','" & dt.Rows(i)(BomInfo.Version).ToString & "',N'" & dt.Rows(i)(BomInfo.Format).ToString.Replace("'", "''") & "') end").Append(vbNewLine)
    '                    sql.Append(" ELSE BEGIN UPDATE M_RUNCARDBOMINFO_T SET QTY='" & dt.Rows(i)(BomInfo.Qty).ToString & "',EXTENSIBLE='" & dt.Rows(i)(BomInfo.Extensible).ToString & "'").Append(vbNewLine)
    '                    sql.Append(",EFFECTIVEDATE='" & dt.Rows(i)(BomInfo.EffectiveDate).ToString & "',EXPIRATIONDATE='" & dt.Rows(i)(BomInfo.ExpirationDate).ToString & "'").Append(vbNewLine)
    '                    sql.Append(",VERSION='" & dt.Rows(i)(BomInfo.Version).ToString & "',USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=getdate(),FORMAT=N'" & dt.Rows(i)(BomInfo.Format).ToString.Replace("'", "''") & "'").Append(vbNewLine)
    '                    sql.Append(" WHERE PARENTPARTID=(SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "') ").Append(vbNewLine)
    '                    sql.Append(" AND PARTID=(SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & dt.Rows(i)(BomInfo.ChildPartId).ToString & "') end").Append(vbNewLine)
    '                Next
    '            End If
    '        End Using
    '        If Not sql Is Nothing AndAlso sql.ToString().Length > 0 Then
    '            sConn = New SysDataBaseClass
    '            sConn.ExecSql(sql.ToString)
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If Not sConn Is Nothing Then
    '            sConn = Nothing
    '        End If
    '        If Not sql Is Nothing Then
    '            sql.Remove(0, sql.Length)
    '            sql = Nothing
    '        End If
    '    End Try

    'End Sub

    Public Shared Sub ReloadBom(ByVal rpn As String)
        Dim sql As System.Text.StringBuilder = Nothing
        Dim sConn As SysDataBaseClass = Nothing
        Try
            Using dt As DataTable = GetBomInfoFormErp(rpn)
                If dt.Rows.Count > 0 Then
                    sql = New System.Text.StringBuilder
                    sql.Append(" DELETE  from m_PartContrast_t where PAvcPart in ('" & rpn & "')").Append(vbNewLine)
                    sql.Append(" DELETE  from m_PartContrast_t where TAvcPart in ('" & rpn & "')").Append(vbNewLine)
                    For i As Integer = 0 To dt.Rows.Count - 1
                        sql.Append(" IF NOT EXISTS(SELECT 1 FROM m_PartContrast_t WHERE PAvcPart='" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "') begin").Append(vbNewLine)
                        sql.Append(" INSERT INTO m_PartContrast_t(TAvcPart,PAvcPart,TypeDest,UseY,USERID,INTIME,DESCRIPTION,TYPE) VALUES('" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "',").Append(vbNewLine)
                        'INSERT INTO M_RUNCARDPARTNUMBER_T(PARTNUMBER,DESCRIPTION,STATUS,USERID,INTIME,DESCRIPTION1,TYPE) VALUES('" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "',
                        sql.Append(" '" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "',N'" & dt.Rows(i)(BomInfo.ParentDescription).ToString.Replace("'", "''") & "','1','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & dt.Rows(i)(BomInfo.Format).ToString.Replace("'", "''") & "','R') end ").Append(vbNewLine)
                        sql.Append(" ELSE BEGIN UPDATE m_PartContrast_t SET TypeDest=N'" & dt.Rows(i)(BomInfo.ParentDescription).ToString.Replace("'", "''") & "',DESCRIPTION=N'" & dt.Rows(i)(BomInfo.Format).ToString.Replace("'", "''") & "' WHERE TAvcPart='" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "' END").Append(vbNewLine)

                        sql.Append(" IF NOT EXISTS(SELECT 1 FROM m_PartContrast_t WHERE TAvcPart='" & dt.Rows(i)(BomInfo.ChildPartId).ToString & "') begin").Append(vbNewLine)
                        sql.Append(" INSERT INTO m_PartContrast_t(TAvcPart,PAvcPart,TypeDest,UseY,USERID,INTIME,DESCRIPTION1,TYPE) VALUES('" & dt.Rows(i)(BomInfo.ChildPartId).ToString & "','" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "',").Append(vbNewLine)
                        sql.Append(" N'" & dt.Rows(i)(BomInfo.ChildDescription).ToString.Replace("'", "''") & "'，'1','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & dt.Rows(i)(BomInfo.CFormat).ToString.Replace("'", "''") & "','R') end").Append(vbNewLine)
                        sql.Append(" ELSE BEGIN UPDATE m_PartContrast_t SET TypeDest=N'" & dt.Rows(i)(BomInfo.ChildDescription).ToString.Replace("'", "''") & "',DESCRIPTION=N'" & dt.Rows(i)(BomInfo.CFormat).ToString.Replace("'", "''") & "' WHERE TAvcPart='" & dt.Rows(i)(BomInfo.ChildPartId).ToString & "' END").Append(vbNewLine)

                        sql.Append(" IF NOT EXISTS(SELECT 1 FROM m_PartContrast_t WHERE PAvcPart='" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "' AND TAvcPart='" & dt.Rows(i)(BomInfo.ChildPartId).ToString & "' begin").Append(vbNewLine)
                        sql.Append(" INSERT INTO M_RUNCARDBOMINFO_T( PAvcPart,TAvcPart,UseY,USERID,INTIME,EXTENSIBLE,AmountQty,EFFECTIVEDATE,EXPIRATIONDATE,VERSION,DESCRIPTION) ").Append(vbNewLine)
                        'INSERT INTO M_RUNCARDBOMINFO_T(PARENTPARTID,PARTID,STATUS,USERID,INTIME,EXTENSIBLE,QTY,EFFECTIVEDATE,EXPIRATIONDATE,VERSION,FORMAT) 
                        sql.Append(" VALUES('" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "',").Append(vbNewLine)
                        '(SELECT TOP 1 ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "'),
                        sql.Append(" '" & dt.Rows(i)(BomInfo.ChildPartId).ToString & "','1','" & VbCommClass.VbCommClass.UseId & "',getdate(),'" & dt.Rows(i)(BomInfo.Extensible).ToString & "','" & dt.Rows(i)(BomInfo.Qty).ToString & "'").Append(vbNewLine)
                        sql.Append(",'" & dt.Rows(i)(BomInfo.EffectiveDate).ToString & "','" & dt.Rows(i)(BomInfo.ExpirationDate).ToString & "','" & dt.Rows(i)(BomInfo.Version).ToString & "',N'" & dt.Rows(i)(BomInfo.Format).ToString.Replace("'", "''") & "') end").Append(vbNewLine)
                        sql.Append(" ELSE BEGIN UPDATE m_PartContrast_t SET AmountQty='" & dt.Rows(i)(BomInfo.Qty).ToString & "',EXTENSIBLE='" & dt.Rows(i)(BomInfo.Extensible).ToString & "'").Append(vbNewLine)
                        'ELSE BEGIN UPDATE M_RUNCARDBOMINFO_T SET QTY='" & dt.Rows(i)(BomInfo.Qty).ToString & "',EXTENSIBLE='" & dt.Rows(i)(BomInfo.Extensible).ToString & "'
                        sql.Append(",EFFECTIVEDATE='" & dt.Rows(i)(BomInfo.EffectiveDate).ToString & "',EXPIRATIONDATE='" & dt.Rows(i)(BomInfo.ExpirationDate).ToString & "'").Append(vbNewLine)
                        sql.Append(",VERSION='" & dt.Rows(i)(BomInfo.Version).ToString & "',USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=getdate(),DESCRIPTION=N'" & dt.Rows(i)(BomInfo.Format).ToString.Replace("'", "''") & "'").Append(vbNewLine)
                        sql.Append(" WHERE PAvcPart='" & dt.Rows(i)(BomInfo.ParentPartId).ToString & "' ").Append(vbNewLine)
                        sql.Append(" AND TAvcPart='" & dt.Rows(i)(BomInfo.ChildPartId).ToString & "' end").Append(vbNewLine)
                    Next
                End If
            End Using
            If Not sql Is Nothing AndAlso sql.ToString().Length > 0 Then
                sConn = New SysDataBaseClass
                sConn.ExecSql(sql.ToString)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
            If Not sql Is Nothing Then
                sql.Remove(0, sql.Length)
                sql = Nothing
            End If
        End Try

    End Sub

    Private Shared Function GetBomInfoFormErp(ByVal rpn As String) As DataTable
        Dim oConn As OracleDb = New OracleDb("")
        Try
            ' oConn = New OracleDb("")
            Using dt As DataTable = oConn.ExecuteQuery(SapCommon.GetSql(rpn)).Tables(0)
                Return dt
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            If Not oConn Is Nothing Then
                oConn = Nothing
            End If
        End Try
    End Function

End Class
#End Region
