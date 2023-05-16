Imports System.IO
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports Aspose.Cells
Imports System.Windows.Forms
Imports System.Text

Public Class FrmCutCardImportStation

    Public cutCardPartId As String
    Public operation As String
    Private _isQueryOldVersion As Boolean
    Public m_CutcardList As String
    Public m_stcCutcardList As List(Of RCardComBusiness.stcCutcard) = New List(Of RCardComBusiness.stcCutcard)
    Public filePath As String = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\RunCardTemplate.xlsx"  'Environment.CurrentDirectory & "\Templates" & "\RunCardTemplate.xlsx"
    Public m_strCutfilePath As String = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\CutCardTemplate.xlsx"

    Public Enum RunCard
        Seq = 0
        StationName
        WorkHour
        Equipment
        Standard
        Remark
    End Enum

    Public Enum RunCardUpload
        ID = 0
        SEQ
        STATIONID
        WORKHOUR
        EQUIPMENT
        STANDARD
        REMARK
        WORKSTATION
        PARTNUMBER
    End Enum

    Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Sub New(ByVal cutCardPn As String, ByVal operation As String, ByVal isQueryOldVersion As Boolean)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        cutCardPn = cutCardPn
        operation = operation
        txtPath.Text = ""
        _isQueryOldVersion = isQueryOldVersion
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

#Region "属性"

#End Region

#Region "事件"
    Private Sub FrmCutCardImportStation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lsSQL As String = ""
        lblMsgList.Items.Clear()

        lsSQL = " SELECT DISTINCT cusid,cusname FROM m_Customer_t WHERE usey='Y' "

        FillGridCombox(Me.CobCust, lsSQL)
        FillGridCombox(Me.CobSeriesID, "SELECT [SeriesID],[SeriesName] FROM [m_Series_t] WHERE Usey='Y'")

        Me.CobCust.SelectedIndex = -1
        Me.CobSeriesID.SelectedIndex = -1
    End Sub

    Private Sub FillGridCombox(ByVal CobName As ComboBox, ByVal SqlStr As String)

        Dim ScanClass As New SysDataBaseClass
        Dim ScanReader As SqlClient.SqlDataReader
        ScanReader = ScanClass.GetDataReader(SqlStr)
        CobName.Items.Clear()

        Do While ScanReader.Read()
            If CobName.Name <> "CobSerial" Then
                CobName.Items.Add(ScanReader(0).ToString & "(" & ScanReader(1).ToString & ")")
            Else
                CobName.Items.Add(ScanReader(0).ToString & "(" & ScanReader(1).ToString)
            End If
        Loop
        ScanReader.Close()
        CobName.SelectedIndex = -1
    End Sub


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        FolderBrowserDialog1.Description = "请选择文件目录"
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
        FolderBrowserDialog1.ShowNewFolderButton = True
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtPath.Text = FolderBrowserDialog1.SelectedPath
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        If Not BaseSet() Then
            Exit Sub
        End If
        DoImport()
    End Sub

    Private Function BaseSet() As Boolean
        If IsNothing(Me.CobCust.SelectedItem) OrElse String.IsNullOrEmpty(Me.CobCust.SelectedItem.ToString) Then
            ShowMessage("请先选择客户编号！！")
            Return False
        End If

        If IsNothing(Me.CobSeriesID.SelectedItem) OrElse String.IsNullOrEmpty(Me.CobSeriesID.SelectedItem.ToString) Then
            ShowMessage("请先选择系列别！！")
            Return False
        End If
        Return True
    End Function

#End Region

    Private errorMsgs As New System.Text.StringBuilder
    Private folder As String = Environment.CurrentDirectory & "\UpLoadMessage\ErrorMessages_" & Date.Now.ToString("yyyyMMdd")
    Private bakFolder As String = Environment.CurrentDirectory & "\UpLoadMessage\SuccessFiles_" & Date.Now.ToString("yyyyMMdd")
    Private pn As String = Nothing
    Private strSetPN As String = Nothing
    Private version As String = Nothing
    Private directoryInfo As DirectoryInfo
    Private fileInfos As FileInfo()

#Region "导入"

    Private Enum ImportGrid
        version = 0
        pn
    End Enum

    Private Function CheckDtValue(ByVal dt As DataTable)
        If dt.Rows(ImportGrid.version)(0) Is DBNull.Value Or dt.Rows(ImportGrid.pn)(0) Is DBNull.Value Then
            Return False
        End If
        Return True
    End Function

    Private Sub SetDtStyle(ByVal dt As DataTable)
        pn = VbCommClass.VbCommClass.PartNumberPrefix & dt.Rows(ImportGrid.pn)(0)
        version = dt.Rows(ImportGrid.version)(0).ToString().Trim
        pn = pn.Trim
        dt.Rows.RemoveAt(0)
        dt.Rows.RemoveAt(0)
        dt.Rows.RemoveAt(0)
    End Sub

    Private Sub CreateFolder()
        If Not Directory.Exists(folder) Then
            Directory.CreateDirectory(folder)
        End If
        If Not Directory.Exists(bakFolder) Then
            Directory.CreateDirectory(bakFolder)
        End If
    End Sub

    Private Sub CreateErrorMsgFile()
        If Not File.Exists(folder & "\ErrorMsg.txt") Then
            Using f1 As FileStream = New FileStream(folder & "\ErrorMsg.txt", FileMode.Create, FileAccess.Write)
                Using sw As StreamWriter = New StreamWriter(f1)
                    sw.WriteLine(System.DateTime.Now.ToString("yyyy/mm/dd hh24:mm:ss"))
                    sw.WriteLine(errorMsgs.ToString)
                End Using
            End Using
        Else
            Using f1 As FileStream = New FileStream(folder & "\ErrorMsg.txt", FileMode.Append, FileAccess.Write)
                Using sw As StreamWriter = New StreamWriter(f1)
                    sw.WriteLine(System.DateTime.Now.ToString("yyyy/mm/dd HH24:mm:ss"))
                    sw.WriteLine(errorMsgs.ToString)
                End Using
            End Using
        End If
    End Sub

    Private Sub MoveFileToBackup(ByVal file As FileInfo)
        If System.IO.File.Exists(file.FullName) Then
            If System.IO.File.Exists(bakFolder + "\" + file.Name) Then
                System.IO.File.Delete(bakFolder + "\" + file.Name)
            End If
            System.IO.File.Move(file.FullName, bakFolder + "\" + file.Name)
        End If
    End Sub

    Private Sub DoImport()
        Try
            directoryInfo = New DirectoryInfo(txtPath.Text)
            fileInfos = directoryInfo.GetFiles()
            If fileInfos.Length > 0 Then
                CreateFolder()
                UploadFile()
            Else
                ShowMessage("该目录下面不存在Excel文件请确认！！")
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub UploadFile()
        Dim errorMsg As String = Nothing
        For Each file As FileInfo In fileInfos
            errorMsgs.Remove(0, errorMsgs.Length)
            Try
                If file.Extension.ToUpper = ".xlsx".ToUpper Or file.Extension.ToUpper = ".xls".ToUpper Then
                    Using dt As DataTable = SysDataBaseClass.ExportFromExcelByAs(file.FullName, "Sheet1", 0, 0, errorMsg)
                        If dt Is Nothing Then
                            ShowMessage(file.Name & "-->文件为空请确认！！")
                            errorMsgs.Append(file.Name & "-->文件为空请确认！！").Append(vbNewLine)
                        Else
                            If Not CheckDtValue(dt) Then
                                ShowMessage(file.Name & "-->料件编号或是版本为空！")
                                errorMsgs.Append(file.Name & "-->料件编号或是版本为空！！").Append(vbNewLine)
                            End If
                            SetDtStyle(dt)
                            SetColumnName(dt)
                            If CheckAndSaveData(dt, file.Name) Then
                                MoveFileToBackup(file)
                            Else
                                If errorMsgs.Length > 0 Then
                                    CreateErrorMsgFile()
                                End If
                            End If
                        End If
                    End Using
                End If
            Catch ex As Exception
                lblMsg.Text = ex.Message
                ShowMessage(ex.Message)
                errorMsgs.Append(file.Name & " " & ex.Message).Append(vbNewLine)
            End Try
        Next
    End Sub

    Private Sub SetColumnName(ByVal dt As DataTable)
        dt.Columns(RunCard.Seq).ColumnName = "SEQ"
        dt.Columns(RunCard.StationName).ColumnName = "STATIONNAME"
        dt.Columns(RunCard.WorkHour).ColumnName = "WORKHOUR"
        dt.Columns(RunCard.Equipment).ColumnName = "EQUIPMENT"
        dt.Columns(RunCard.Standard).ColumnName = "STANDARD"
        dt.Columns(RunCard.Remark).ColumnName = "REMARK"
    End Sub

    Private Function CheckAndSaveData(ByVal dt As DataTable, ByVal file As String) As Boolean
        If PnExists() Then
            ShowMessage(file & "料号 " & pn + " 的裁线卡已经存在，请确认")
            errorMsgs.Append(file & "料号 " & pn + " 的裁线卡已经存在，请确认").Append(vbNewLine)

            If MessageUtils.ShowConfirm("你确定删除旧料号？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                Return False
            End If
        End If
        Dim errorMsg As String = Nothing

        If Not PnDownLoadBom(file) Then
            Return False
        End If
        Try
            If InsertIntoTempTable(dt, file) Then
                If Not CheckStationIsOk() Then
                    'lblMsg.Text = file & " 工站存在为空或是工站重复"
                    ShowMessage(file & " 工站存在为空或是工站重复")
                    errorMsgs.Append(file & "--> 工站存在为空或是工站重复")
                    Return False
                End If
                If Not CheckStationStand(errorMsg) Then
                    ShowMessage(file & "" & errorMsg.Trim(",") & " 不是标准工站,或者该工站已经作废")
                    errorMsgs.Append(file & "--> " & errorMsg.Trim(",") + "不是标准工站，或者该工站已经作废")
                    Return False
                End If
                If Not CheckWorkHourIsOk() Then
                    'lblMsg.Text = file & " 工时不是数字"
                    ShowMessage(file & " 工时不是数字")
                    errorMsgs.Append(file & "--> 工时不是数字")
                    Return False
                End If
                If Not SaveData(dt, file) Then
                    Return False
                Else
                    ShowMessage(file & " 导入成功")
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            lblMsgList.Items.Insert(0, file & "--> " & ex.Message)
            'lblMsg.Text = file & ex.Message
            errorMsgs.Append(file & "--> " & ex.Message)
            Return False
        Finally
            DeleteTempTable()
        End Try
    End Function

    Private Function PnExists() As Boolean
        Dim sql As String = "SELECT PartID FROM m_RCardCutM_t WHERE PartID = '" & pn & "' " &
                             RCardComBusiness.GetFatoryProfitcenter()

        Using dt As DataTable = RCardComBusiness.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return True
            End If
        End Using
        Return False
    End Function

    Private Function PnDownLoadBom(ByVal file As String) As Boolean
        Dim strCustID As String = "", strSeriesID As String = ""

        'A. First Download PN from ERP,Add by CQ 20151116
        Dim strSQL As String = SapCommon.GetErpFilterSql(pn)
        Dim o_dt As DataTable = RCardComBusiness.GetDataTableOracle(strSQL)
        Try

            'add by cq 20180130
            If IsNothing(o_dt) OrElse o_dt.Rows.Count <= 0 Then
                ShowMessage(file & "-->请检查该料是否维护BOM资料！！")
                errorMsgs.Append(file & "-->请先维护BOM资料！！").Append(vbNewLine)
                Return False
            End If

            'Get CustID from MES first, if not get, then get from UI
            strCustID = RunCardBusiness.GetCustIDFromTT(pn)
            If String.IsNullOrEmpty(strCustID) Then
                If (Not IsNothing(Me.CobCust.SelectedItem)) AndAlso Me.CobCust.SelectedItem.ToString <> "" Then
                    strCustID = Me.CobCust.SelectedItem.ToString.Split("(")(0)
                Else
                    ShowMessage(file & "-->请先选择客户编号！！")
                    errorMsgs.Append(file & "-->请先选择客户编号！！").Append(vbNewLine)
                    Return False
                End If
            End If

            'Get Serial from TT first, if not get, then get from UI
            strSeriesID = RunCardBusiness.GetSerialIDFromTT(pn)
            If String.IsNullOrEmpty(strSeriesID) Then
                If (Not IsNothing(Me.CobSeriesID.SelectedItem)) AndAlso Me.CobSeriesID.SelectedItem.ToString <> "" Then
                    strSeriesID = Me.CobSeriesID.SelectedItem.ToString.Split("(")(0)
                Else
                    ShowMessage(file & "-->请先选择系列别！！")
                    errorMsgs.Append(file & "-->请先选择系列别！！").Append(vbNewLine)
                    Return False
                End If
            End If

            o_dt.Columns.Add("CustID", GetType(String))
            For Each dr As DataRow In o_dt.Rows
                dr.Item("CustID") = strCustID
            Next

            o_dt.Columns.Add("SeriesID", GetType(String))
            For Each dr As DataRow In o_dt.Rows()
                dr.Item("SeriesID") = strSeriesID
            Next

            If Not RunCardBusiness.SaveErpData(o_dt) Then
                ShowMessage(file & "-->执行sql 错误，请联系IT！！")
                errorMsgs.Append(file & "-->执行sql 错误，请联系IT！！").Append(vbNewLine)
                Return False
            End If

            Dim sql As String = "SELECT DISTINCT ISNULL(DESCRIPTION,'') FROM m_PartContrast_t WHERE TAvcPart='" & pn & "' AND TAvcPart = PAvcPart "
            Using dt As DataTable = RCardComBusiness.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    '华为以“9”开头成品料号，系统自动校验版本；3F的产品以”L”开头，系统通过识别“L”,就不用校验版本
                    If pn.Trim.StartsWith("9") Then
                        If version.Trim <> GetVersion(dt.Rows(0)(0)).Trim Then
                            ShowMessage(file & "-->料号版本和BOM的不一致，请检查！！")
                            errorMsgs.Append(file & "-->料号版本和BOM的不一致，请检查！！").Append(vbNewLine)
                            Return False
                        End If
                    Else
                        'by bass version check
                    End If
                Else
                    ShowMessage(file & "-->料号不存在于BOM，请检查！！")
                    errorMsgs.Append(file & "-->料号不存在于BOM，请检查！！").Append(vbNewLine)
                    Return False
                End If
            End Using
            Return True
        Catch ex As Exception
            Return False
        Finally
            o_dt = Nothing
        End Try
    End Function

    Private Function GetVersion(ByVal desc As String) As String
        Dim arr() As String
        arr = desc.Split("-")
        If arr.Length > 1 Then
            Return arr(arr.Length - 1)
        End If
        Return "NOFOUND"
    End Function

    Private Function CheckStationIsOk() As Boolean
        Dim sql As String = "SELECT STATIONNAME FROM m_RCardUpload_t WHERE STATIONNAME IS NULL AND ID='" & tempId & "' AND WORKSTATION='" & workStation & "'" &
            RCardComBusiness.GetFatoryProfitcenter() & " UNION " &
            "SELECT STATIONNAME FROM m_RCardUpload_t WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "'" &
            RCardComBusiness.GetFatoryProfitcenter() & " GROUP BY STATIONNAME HAVING COUNT(STATIONNAME)>1"

        Using dt As DataTable = RCardComBusiness.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return False
            End If
        End Using

        Return True
    End Function

    Private Function CheckStationStand(ByRef errorMsg As String) As Boolean
        'Modify by cq20151229, Add usey='Y', not allow no use station import
        Dim sql As String = "SELECT STATIONNAME FROM m_RCardUpload_t A WHERE A.ID='" & tempId & "' AND A.WORKSTATION='" & workStation &
            "' AND NOT EXISTS (SELECT 1 FROM m_Rstation_t B WHERE B.STATIONNAME=A.STATIONNAME AND USEY ='Y')"
        Using dt As DataTable = RCardComBusiness.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    errorMsg += row(0).ToString + ","
                Next
                Return False
            End If
        End Using
        Return True
    End Function

    Private Function CheckWorkHourIsOk() As Boolean
        Dim sql As String = "SELECT A.WORKHOUR FROM (SELECT ISNUMERIC(WORKHOUR) WORKHOUR FROM m_RCardUpload_t WHERE ID='" & tempId &
            "' AND WORKSTATION='" & workStation & "' AND WORKHOUR IS NOT NULL) A WHERE A.WORKHOUR=0"
        Using dt As DataTable = RCardComBusiness.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return False
            End If
        End Using
        Return True
    End Function

    Private Function SaveData(dtt As DataTable, file As String) As Boolean
        Dim o_strExecSQLResult As String = ""
        Try
            Dim arrayList As New ArrayList
            Dim userID As String = VbCommClass.VbCommClass.UseId

            arrayList.Add("ID|" & tempId)
            arrayList.Add("workStation|" & workStation)
            arrayList.Add("Version|" & version)
            arrayList.Add("UserID|" & userID)
            o_strExecSQLResult = RCardComBusiness.ExecuteNonQureyByProc("udpSaveImportRCardCut", arrayList)
            If o_strExecSQLResult <> "" Then
                ShowMessage(file & "导入失败->" & o_strExecSQLResult)
                errorMsgs.Append(file & "-->" & o_strExecSQLResult)
                Return False
            End If
            Return True
        Catch ex As Exception
            ShowMessage(file & "导入失败->" & ex.ToString)
            errorMsgs.Append(file & "-->" & ex.ToString)
            Return False
        End Try
    End Function

    Private tempId As String = Nothing
    Private workStation As String = System.Net.Dns.GetHostName()

    Private Function InsertIntoTempTable(ByVal dt As DataTable, ByVal file As String) As Boolean
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        tempId = pn & VbCommClass.VbCommClass.UseId & Date.Now.ToString("yyyyMMddhh24missfff")
        Dim sql As New System.Text.StringBuilder
        Dim errmsg As String = Nothing
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        Try
            '删除以前数据
            DeleteTempTable()

            AddExternColumns(dt)

            dics.Add("ID", "ID")
            dics.Add("WORKSTATION", "WORKSTATION")
            dics.Add("SEADEFINE", "SEQ")
            dics.Add("STATIONNAME", "STATIONNAME")
            dics.Add("WORKHOUR", "WORKHOUR")
            dics.Add("EQUIPMENT", "EQUIPMENT")
            dics.Add("STANDARD", "STANDARD")
            dics.Add("REMARK", "REMARK")
            dics.Add("PARTNUMBER", "PARTNUMBER")
            dics.Add("Factoryid", "Factoryid")
            dics.Add("Profitcenter", "Profitcenter")
            If Not sConn.BulkCopy(dt, "m_RCardUpload_t", dics, errmsg) Then
                ShowMessage(file & "导入失败 " & errmsg)
                errorMsgs.Append(file & "导入失败 " & errmsg)
                Return False
            End If
            DeleteNullDate()
            Return True
        Catch ex As Exception
            If Not dics Is Nothing Then
                dics.Clear()
                dics = Nothing
            End If
            ShowMessage(file & ex.Message)
            errorMsgs.Append(file & "导入失败 " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Private Sub AddExternColumns(ByVal dt As DataTable)
        AddTableColumns("ID", tempId, dt)
        AddTableColumns("WORKSTATION", workStation, dt)
        AddTableColumns("SEADEFINE", "", dt)
        AddTableColumns("PARTNUMBER", pn, dt)
        AddTableColumns("Factoryid", VbCommClass.VbCommClass.Factory, dt)
        AddTableColumns("Profitcenter", VbCommClass.VbCommClass.profitcenter, dt)
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i)("SEADEFINE") = (i + 1).ToString
            dt.Rows(i)("STATIONNAME") = dt.Rows(i)("STATIONNAME").ToString().Replace("'", "''").Trim
            dt.Rows(i)("EQUIPMENT") = dt.Rows(i)("EQUIPMENT").ToString().Replace("'", "''").Trim
            dt.Rows(i)("STANDARD") = dt.Rows(i)("STANDARD").ToString().Replace("'", "''").Trim
            dt.Rows(i)("REMARK") = dt.Rows(i)("REMARK").ToString().Replace("'", "''").Trim
        Next
    End Sub

    Private Sub AddTableColumns(drColumnName As String, defaultValue As String, ByVal dt As DataTable)
        Dim drColumn As DataColumn = New DataColumn
        drColumn.DataType = GetType(String)
        drColumn.ColumnName = drColumnName
        If defaultValue <> "" Then
            drColumn.DefaultValue = defaultValue
        End If

        dt.Columns.Add(drColumn)
    End Sub

    Public Sub DeleteNullDate()
        Dim sql As String = "DELETE FROM m_RCardUpload_t WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "'" & vbNewLine & _
        " AND (STATIONNAME IS NULL OR STATIONNAME='') AND (WORKHOUR IS NULL OR WORKHOUR ='') AND (EQUIPMENT IS NULL OR EQUIPMENT='') AND (STANDARD IS NULL OR STANDARD='') AND( REMARK IS NULL OR REMARK ='')"
        RCardComBusiness.ExecSQL(sql)
    End Sub

    Public Sub DeleteTempTable()
        Dim sql As String = Nothing
        sql = " INSERT INTO m_RCardUploadLog_t  SELECT * FROM  m_RCardUpload_t WHERE ID='" & tempId & "'AND WORKSTATION='" & workStation & "'" & vbNewLine & _
              " DELETE FROM m_RCardUpload_t WHERE ID='" & tempId & "'AND WORKSTATION='" & workStation & "'"
        RCardComBusiness.ExecSQL(sql)
    End Sub

    Private Sub ShowMessage(ByVal msg As String)
        lblMsgList.Items.Insert(0, msg)
        lblMsgList.Refresh()
    End Sub

#End Region

#Region "导出"

    Public Sub SelectExportPath(ByVal pn As String, Optional ByRef strPath As String = "")
        FolderBrowserDialog1.Description = "请选择保存文件路径"
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
        FolderBrowserDialog1.ShowNewFolderButton = True
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtPath.Text = FolderBrowserDialog1.SelectedPath
            strPath = txtPath.Text
            Cursor.Current = Cursors.Default
            cutCardPartId = pn + "_" + DateTime.Now.ToShortTimeString()
            ' DoExport()
        End If
    End Sub


    Public Sub SelectPath(ByVal pn As String, Optional ByRef strPath As String = "")
        FolderBrowserDialog1.Description = "请选择保存文件路径"
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
        FolderBrowserDialog1.ShowNewFolderButton = True
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtPath.Text = FolderBrowserDialog1.SelectedPath
            strPath = txtPath.Text
            Cursor.Current = Cursors.Default
            cutCardPartId = pn + "_" + DateTime.Now.ToShortTimeString()
            DoExport()
        End If
    End Sub

    Private Sub DoExport()
        Dim o_TempoutputFile As String = String.Empty
        Dim errorMsg As String = Nothing
        Try
            For Each o_TempstcCutcard In m_stcCutcardList

                o_TempoutputFile = txtPath.Text & "\" & o_TempstcCutcard.CutCardPartPN & ".xlsx"
                Using dt As DataTable = RCardComBusiness.GetDataTable(GetExportSql(o_TempstcCutcard.CutCardPartPN, Me._isQueryOldVersion, o_TempstcCutcard.CutCardVersion))
                    If dt.Rows.Count > 0 Then
                        dt.TableName = "RunCard"
                        'SysDataBaseClass ==> Cut 20170825
                        If CutCardBusiness.Import2ExcelByAs(m_strCutfilePath, o_TempoutputFile, dt, GetVariables(dt), o_TempstcCutcard.CutCardPartPN, errorMsg) = False Then
                            MessageBox.Show(errorMsg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("料件找不到对应的裁线卡['" & o_TempstcCutcard.CutCardPartPN & "']", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Next
            MessageBox.Show("导出成功,请查看！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Shared Function GetExportSql(Optional ByVal cutCardPn As String = "", Optional ByVal isQueryOldVersion As Boolean = False, Optional ByVal strRCardVersion As String = "") As String
        Dim sql As String = Nothing
        Dim strFilterVerSQL As String = String.Empty

        If String.IsNullOrEmpty(strRCardVersion) Then
            strFilterVerSQL = ""
        Else
            strFilterVerSQL = "	AND HEADER.DrawingVer = DETAIL.DrawingVer	AND DETAIL.DRAWINGVER = '" & strRCardVersion & "'"
        End If

        'isnull(LeftWirePN1,REPLACE(REPLACE(RAWINFO_Part,'<TAvcPart>',''),'</TAvcPart>','')) LeftWirePN1

        If isQueryOldVersion = False Then

            sql = "SELECT PartID, DRAWINGVER, SHAPE," & _
                "       ID AS SEQ," &
                "       STATIONNAME," &
                "       LABORHOUR AS HOURS," &
                " StdLabors," & _
                "       EQUIPMENT," & _
                "       REMARK,SID SECTIONID," &
                "       TypeDest," &
                "       DESCRIPTION," &
                "       STATUS," &
                "       AUDITUSERID," &
                "       CREATEUSERID ," &
                "       DID, MODIFYTIME ,REPLACE(REPLACE(RAWINFO_Part,'<TAvcPart>',''),'</TAvcPart>','') LeftWirePN1 ,RAWINFO_Des WireDes," & _
                " LeftProcessStandard, RightProcessStandard, LeftTVPN, RightTVPN, " & _
                "  IIF( LCLValue is null, STANDARD, LCLValue+IIf(ISNULL(REMARK,'')='', '', '('+ REMARK + ')')) LCLValue" & _
                "  FROM " & _
                "  (SELECT A.*,  (SELECT DISTINCT PARTD.TAvcPart+' || '" &
                 "      FROM {2} PARTDETAIL,{3} PARTD" & _
                    "      WHERE PARTDETAIL.EWPartNumber=PARTD.TAvcPart" & _
                     "        AND PARTDETAIL.Stationid  = A.Stationid" &
                     "        AND PARTDETAIL.PartID = A.PartID" &
                     "        AND ISNULL(PARTD.TYPE,'R')='R'" &
                      "        AND  PARTD.PAvcPart = '" & cutCardPn & "' " & _
                      "       AND PARTDETAIL.EWPartNumber NOT IN (SELECT DISTINCT TVPN FROM dbo.m_RCardProParam_t WHERE status=1)" &
                      "     AND NOT ( TAvcPart LIKE '2_____-%' OR TAvcPart LIKE '03%' OR  TAvcPart LIKE '10_-%' OR  TAvcPart LIKE '11_-%' OR  TAvcPart LIKE '27%' OR  TAvcPart LIKE '05%')" & _
                      "        AND PARTD.TAvcPart <> PARTD.PAvcPart" &
                      "        FOR XML PATH('')) RAWINFO_Part," & _
                      " (SELECT DISTINCT  IIF(ISNULL(PARTD.DESCRIPTION,'')='', partd.typedest, partd.DESCRIPTION) +' || ' " & _
                 "      FROM {2} PARTDETAIL,{3} PARTD" & _
                    "      WHERE PARTDETAIL.EWPartNumber=PARTD.TAvcPart" & _
                     "        AND PARTDETAIL.Stationid  = A.Stationid" &
                     "        AND PARTDETAIL.PartID = A.PartID" &
                     "        AND ISNULL(PARTD.TYPE,'R')='R'" &
                     "       AND  PARTD.PAvcPart = '" & cutCardPn & "' " & _
                     "       AND  PARTDETAIL.EWPartNumber NOT IN (SELECT DISTINCT TVPN FROM dbo.m_RCardProParam_t WHERE status=1)" &
                     "       AND NOT ( TAvcPart LIKE '2_____-%' OR TAvcPart LIKE '03%' OR  TAvcPart LIKE '10_-%' OR  TAvcPart LIKE '11_-%' OR  TAvcPart LIKE '27%' OR  TAvcPart LIKE '05%')" & _
                     "       AND PARTD.TAvcPart <> PARTD.PAvcPart" &
                     "        FOR XML PATH('')) RAWINFO_Des" & _
                "   FROM" &
                "     (SELECT " &
                "        HEADER.PartID ,HEADER.DRAWINGVER,HEADER.SHAPE, " &
                "       CAST(ROW_NUMBER() OVER(ORDER BY DETAIL.STATIONSQ) AS INT) ID,STATION.Stationid,STATION.STATIONNAME STATIONNAME,ISNULL(DETAIL.WORKINGHOURS,0) LABORHOUR," &
                "       DETAIL.EQUIPMENT EQUIPMENT, StdLabors," & _
                "      IIf(DETAIL.PROCESSSTANDARD is null,'', DETAIL.PROCESSSTANDARD + IIf(ISNULL(DETAIL.REMARK,'')='', '', '('+ DETAIL.REMARK + ')')) STANDARD," & _
                "       DETAIL.REMARK REMARK,SECTION.ID SID,PART.TypeDest, " &
                "       PART.DESCRIPTION," & _
                "         (SELECT TOP 1 username FROM m_Users_t AA, m_RCardCutMAuditLog_t BB WHERE AA.userid = BB.AuditUser AND BB.partid ='" & cutCardPn & "'  ORDER BY AuditTime DESC) AUDITUSERID," & _
                "       HEADER.INTIME,Header.modifyTime,DETAIL.StationID  DID, " & _
                "     (SELECT username from m_Users_t WHERE userid = HEADER.userid) CREATEUSERID," & _
                "       CASE HEADER.STATUS WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END STATUS" & _
                "  , item.LeftWirePN1 , " & _
                " ISNULL(item.LeftTVPNShow,item.LeftTVPN )LeftTVPN, " & _
                " isnull(item.RightTVPNShow,item.RightTVPN)RightTVPN, item.ResultValue as LCLValue," & _
                " (SELECT TOP 1 DESCRIPTION FROM dbo.m_PartContrast_t m1 WHERE m1.TAvcPart=item.LeftWirePN1 AND DESCRIPTION <> '') WireDes, " & _
                "  DETAIL.LeftProcessStandard, DETAIL.RightProcessStandard" & _
                "      FROM (SELECT TOP 1 * FROM V_m_PartContrast_t WHERE TAvcPart = PAvcPart AND TAvcPart='" & cutCardPn & "')  PART,{0} HEADER,{1} DETAIL, m_Rstation_t STATION" &
                "      LEFT JOIN m_RstationSection_t SECTION ON STATION.SECTIONID=SECTION.ID" &
                "      LEFT JOIN dbo.m_CutCardDCheckItem_t  item  ON   item.STATIONID = STATION.Stationid AND ITEM.PARTID ='" & cutCardPn & "' AND item.CheckItemID ='LCL'" & _
                "      AND SECTION.USEY=1" &
                "      WHERE 1=1" &
                "        AND HEADER.PARTID =PART.TAvcPart" &
                "        AND HEADER.PARTID=DETAIL.PARTID" &
                "        AND DETAIL.STATIONID =STATION.Stationid AND HEADER.FACTORYID = DETAIL.Factoryid" &
                "	     AND HEADER.Profitcenter= DETAIL.Profitcenter" + "" & strFilterVerSQL & "" & _
                RCardComBusiness.GetFatoryProfitcenter("HEADER") &
                "  ) A)B " &
                "ORDER BY B.ID"
            sql = String.Format(sql, "m_RCardCutM_t", "m_RCardCutD_t", "m_CutCardDPart_t", "m_PartContrast_t")
        Else

            '' -- IIF( LCLValue is null, (STANDARD+IIf(ISNULL(REMARK,'')='', '', '('+ REMARK + ')')) , LCLValue + IIf(ISNULL(REMARK,'')='', '', '('+ REMARK + ')')) LCLValue 
            ''  (dbo.RegexReplace(SUBSTRING(STANDARD,1, CHARINDEX(';',STANDARD)-1),'[^0-9/±]','',0)+ IIf(ISNULL(REMARK,'')='', '', '('+ REMARK + ')'))LCLValue
            ''IIF( CHARINDEX(N'裁线',STANDARD)=0,STANDARD,dbo.RegexReplace(SUBSTRING(STANDARD,1, CHARINDEX(';',STANDARD)-1),'[^0-9/±/./+/-]','',0)+ IIf(ISNULL(REMARK,'')='', '', '('+ REMARK + ')'))LCLValue
            'item.ResultValue as LCLValue 20190621===> 
            ' AND ISNULL(( IIF(partdetail.DrawingVer<>'',partdetail.DrawingVer,'VA' )) ,'VA') = 'VA'   
            'isnull(item.LeftTVPNShow,item.LeftTVPN)LeftTVPN ==> isnull(DETAIL.LeftTVPN,isnull(item.LeftTVPNShow,item.LeftTVPN))LeftTVPN

            sql = "SELECT PartID,DRAWINGVER, SHAPE," & _
             "       ID AS SEQ," &
             "       STATIONNAME," &
             "       LABORHOUR AS HOURS," &
             "       StdLabors," & _
             "       EQUIPMENT," &
             "       STANDARD," &
             "       REMARK,SID SECTIONID," &
             "       TypeDest," &
             "       DESCRIPTION," &
             "       STATUS," &
             "       AUDITUSERID," &
             "       CREATEUSERID ," &
             "       DID, MODIFYTIME," & _
             "  ISNULL(WIREPN, REPLACE(REPLACE(RAWINFO_Part,'<TAvcPart>',''),'</TAvcPart>','')) LeftWirePN1 , RAWINFO_Des WireDes," & _
             " LeftProcessStandard, RightProcessStandard, LeftTVPN, RightTVPN, " & _
            "IIF( LCLValue is null, (STANDARD+IIf(ISNULL(REMARK,'')='', '', '('+ REMARK + ')')) , LCLValue + IIf(ISNULL(REMARK,'')='', '', '('+ REMARK + ')')) LCLValue " & _
            " FROM " & _
             "  (SELECT A.*," &
             "     (SELECT DISTINCT PARTD.TAvcPart+ ' || '" &
             "      FROM {2} PARTDETAIL,{3} PARTD" &
             "      WHERE PARTDETAIL.EWPartNumber=PARTD.TAvcPart" &
             "        AND PARTDETAIL.Stationid  = A.Stationid" &
             "        AND PARTDETAIL.PartID = A.PartID" &
             "        AND ISNULL(PARTD.TYPE,'R')='R'" &
             "        AND  PARTD.PAvcPart = '" & cutCardPn & "' " & _
             "        AND PARTDETAIL.EWPartNumber NOT IN (SELECT DISTINCT TVPN FROM dbo.m_RCardProParam_t WHERE status=1)" &
             "       AND ISNULL(( IIF(partdetail.DrawingVer<>'',partdetail.DrawingVer,'" & strRCardVersion & "' )) ,'" & strRCardVersion & "') ='" & strRCardVersion & "'" &
             "        AND PARTD.TAvcPart <> PARTD.PAvcPart" &
             "        FOR XML PATH('')" & _
             "        ) AS RAWINFO_Part," &
                   "     (SELECT DISTINCT  PARTD.DESCRIPTION+' || '" &
             "      FROM {2} PARTDETAIL,{3} PARTD" &
             "      WHERE PARTDETAIL.EWPartNumber=PARTD.TAvcPart" &
             "        AND PARTDETAIL.Stationid  = A.Stationid" &
             "        AND PARTDETAIL.PartID = A.PartID" &
             "        AND ISNULL(PARTD.TYPE,'R')='R'" &
             "        AND  PARTD.PAvcPart = '" & cutCardPn & "' " & _
             "        AND ISNULL(( IIF(partdetail.DrawingVer<>'',partdetail.DrawingVer,'" & strRCardVersion & "' )) ,'" & strRCardVersion & "') ='" & strRCardVersion & "'" &
             "        AND PARTD.TAvcPart <> PARTD.PAvcPart" &
             "        FOR XML PATH('')" & _
             "        ) AS RAWINFO_Des" &
             "   FROM" &
             "     (SELECT " &
             "        HEADER.PartID ,HEADER.DRAWINGVER,HEADER.SHAPE, " &
             "       CAST(ROW_NUMBER() OVER(ORDER BY DETAIL.STATIONSQ) AS INT) ID,STATION.Stationid,STATION.STATIONNAME STATIONNAME,ISNULL(DETAIL.WORKINGHOURS,0) LABORHOUR," &
             "       DETAIL.EQUIPMENT EQUIPMENT, StdLabors," & _
             "       DETAIL.PROCESSSTANDARD + IIf(ISNULL(DETAIL.REMARK,'')='', '', '('+ DETAIL.REMARK + ')') STANDARD," & _
             "       DETAIL.REMARK REMARK,SECTION.ID SID,PART.TypeDest, " &
             "       PART.DESCRIPTION," & _
             " (SELECT TOP 1 username FROM m_Users_t AA, m_RCardCutMAuditLog_t BB WHERE AA.userid = BB.AuditUser AND BB.partid ='" & cutCardPn & "'  ORDER BY AuditTime DESC) AUDITUSERID," & _
             "       HEADER.INTIME,Header.modifyTime,DETAIL.StationID  DID, " & _
             "     (SELECT username from m_Users_t WHERE userid = HEADER.userid) CREATEUSERID," & _
             "       CASE HEADER.STATUS WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END STATUS" &
             "     ,item.LeftWirePN1 , isnull(DETAIL.LeftTVPN,isnull(item.LeftTVPNShow,item.LeftTVPN))LeftTVPN, isnull(DETAIL.RightTVPN,isnull(item.RightTVPNShow,item.RightTVPN))RightTVPN, isnull(DETAIL.LCLValue,item.ResultValue) as LCLValue," & _
             " (SELECT TOP 1 DESCRIPTION FROM dbo.m_PartContrast_t m1 WHERE m1.TAvcPart=item.LeftWirePN1 AND DESCRIPTION <> '') WireDes, " & _
             "  DETAIL.LeftProcessStandard, DETAIL.RightProcessStandard,  DETAIL.WIREPN " & _
             "      FROM (SELECT TOP 1 * FROM V_m_PartContrast_t WHERE TAvcPart = PAvcPart AND TAvcPart='" & cutCardPn & "') PART,{0} HEADER,{1} DETAIL, m_Rstation_t STATION" &
             "      LEFT JOIN m_RstationSection_t SECTION ON STATION.SECTIONID=SECTION.ID" &
             "      LEFT JOIN dbo.m_CutCardDCheckItemLOG_t  item  ON   item.STATIONID = STATION.Stationid AND ITEM.PARTID ='" & cutCardPn & "' AND item.Version='" & strRCardVersion & "' AND item.CheckItemID ='LCL'" & _
             "      AND SECTION.USEY=1" &
             "      WHERE 1=1 " &
             "        AND HEADER.PARTID =PART.TAvcPart" &
             "        AND HEADER.PARTID=DETAIL.PARTID" &
             "        AND DETAIL.STATIONID =STATION.Stationid AND HEADER.FACTORYID = DETAIL.Factoryid" &
             "	     AND HEADER.Profitcenter= DETAIL.Profitcenter" + "" & strFilterVerSQL & "" & _
             RCardComBusiness.GetFatoryProfitcenter("HEADER") &
             "  ) A)B " &
             "ORDER BY B.ID"
            sql = String.Format(sql, "m_CutCardMOldVer_t", "m_CutCardDOldVer_t", "m_CutCardDPartOldVer_t", "m_PartContrastOldVer_t")
        End If

        Return sql
    End Function

    Public Function GetNoVariables(ByVal dt As DataTable) As System.Collections.Generic.Dictionary(Of String, String)
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        If dt.Rows.Count > 0 Then
            dics.Add("PN", dt.Rows(0)("PartID").ToString)
        End If
        Return dics
    End Function

    Public Function GetRCardListVariable(ByVal dt As DataTable, ByVal strParentPartID As String) As System.Collections.Generic.Dictionary(Of String, String)
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        Dim o_iAssortMultiple As Integer = 1
        Try
            Dim o_dt As DataTable = dt.Copy()
            If o_dt.Rows.Count >= 5 Then
                For i As Integer = o_dt.Rows.Count - 1 To i > o_dt.Rows.Count - 5 Step -1
                    dt.Rows.RemoveAt(i)
                    If i < o_dt.Rows.Count - 5 Then
                        Exit For
                    End If
                Next
            End If

            Dim o_dtNew As DataTable = dt.Clone()
            For Each col As DataColumn In o_dtNew.Columns
                If col.ColumnName = "QTY" Then
                    col.DataType = GetType(Integer)
                End If
            Next

            For Each dr As DataRow In dt.Rows
                o_dtNew.Rows.Add(dr.ItemArray)
            Next



            If dt.Rows.Count > 0 Then
                ' ID/PN/Version/Qty/TotalHourPreChild/CutProPreChild/PreAssemblyHourPreChild/
                'SemiAutoPreChild/ContourHourPreChild/MadeHourPreChild/CutProPreMO

                o_iAssortMultiple = RunCardBusiness.GetAssortMultiple()

                dics.Add("PN", strParentPartID) 'dt.Rows(0)("PN").ToString.Split("-")(0)
                dics.Add("VERSION", RunCardBusiness.GetVerFromErp(strParentPartID))
                '&=$Total	&=Cut	&=$PreAssembly	&=$SemiAuto	&=$Contour	&=$Made
                dics.Add("Pack", CStr(Val(o_dtNew.Compute("sum(QTY)", "")) * o_iAssortMultiple)) '15
                dics.Add("Lot", CStr(Val(o_dtNew.Compute("sum(QTY)", "")) * o_iAssortMultiple + 28)) '15
                dics.Add("Cut", o_dt.Rows(o_dt.Rows.Count - 1).Item("CutProPreChild"))
                dics.Add("PreAssembly", o_dt.Rows(o_dt.Rows.Count - 1).Item("PreAssemblyHourPreChild"))
                dics.Add("SemiAuto", o_dt.Rows(o_dt.Rows.Count - 1).Item("SemiAutoPreChild"))
                dics.Add("Contour", o_dt.Rows(o_dt.Rows.Count - 1).Item("ContourHourPreChild"))
                dics.Add("Made", o_dt.Rows(o_dt.Rows.Count - 1).Item("MadeHourPreChild"))
                dics.Add("Total", o_dt.Rows(o_dt.Rows.Count - 1).Item("TotalHourPreChild"))
            End If
            Return dics
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetVariables(ByVal dt As DataTable) As System.Collections.Generic.Dictionary(Of String, String)
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        Dim strArea As New StringBuilder
        Dim strPN As String = ""
        Dim o_strStdUPPH As String = ""
        Dim o_iAmountQty As Integer = 0
        If dt.Rows.Count > 0 Then

            dics.Add("PN", dt.Rows(0)("PartID").ToString)
            dics.Add("VERSION", dt.Rows(0)("DRAWINGVER").ToString)
            dics.Add("SHAPE", dt.Rows(0)("SHAPE").ToString)
            dics.Add("DESCRIPTION1", dt.Rows(0)("DESCRIPTION").ToString)
            strPN = dt.Rows(0)("PartID").ToString
            'Add by cq 20160510
            If strPN.IndexOf("-") > 0 Then
                o_iAmountQty = CutCardBusiness.GetAmountQtyFromTT(strPN.Substring(0, strPN.IndexOf("-")), strPN)
            Else
                '对于单根，父料号和 子料号一样
                o_iAmountQty = CutCardBusiness.GetAmountQtyFromTT(strPN, strPN)
            End If
            dics.Add("AmountQty", CStr(o_iAmountQty))

            '铆端前加工 产线加工,成型加工,裁切前加工,生产线前加工, 半自动压接连接
            ' 裁切（04）/铆端（01）/半自动压接（A05）/成型（03）/产线（02）/总工时	
            dics.Add("Cut", IIf(IsDBNull(dt.Compute("sum(HOURS)", "SECTIONID= '04'")), 0, dt.Compute("sum(HOURS)", "SECTIONID= '04'")))
            dics.Add("PreAssembly", IIf(IsDBNull(dt.Compute("sum(HOURS)", "SECTIONID= '01'")), 0, dt.Compute("sum(HOURS)", "SECTIONID= '01'")))
            dics.Add("SemiAuto", IIf(IsDBNull(dt.Compute("sum(HOURS)", "SECTIONID= 'A05'")), 0, dt.Compute("sum(HOURS)", "SECTIONID= 'A05'")))
            dics.Add("Contour", IIf(IsDBNull(dt.Compute("sum(HOURS)", "SECTIONID= '03'")), 0, dt.Compute("sum(HOURS)", "SECTIONID= '03'")))
            dics.Add("Made", IIf(IsDBNull(dt.Compute("sum(HOURS)", "SECTIONID= '02'")), 0, dt.Compute("sum(HOURS)", "SECTIONID= '02'")))
            dics.Add("Total", dt.Compute("sum(HOURS)", ""))
            dics.Add("DESCRIPTION", dt.Rows(0)("TypeDest").ToString)
            dics.Add("STATUS", dt.Rows(0)("STATUS").ToString)
            dics.Add("CREATEUSER", dt.Rows(0)("CREATEUSERID").ToString)
            dics.Add("AuditUser", dt.Rows(0)("AUDITUSERID").ToString)
            dics.Add("MODIFYTIME", dt.Rows(0)("MODIFYTIME").ToString)

            If dt.Rows(0)("DESCRIPTION").ToString.IndexOf("日本市场") >= 0 Then
                strArea.Append("(日本市场)")
            End If
            If dt.Rows(0)("TypeDest").ToString.IndexOf("贴UL标签") >= 0 Then
                strArea.Append("(贴UL标签)")
            End If

            dics.Add("Area", strArea.ToString)
        End If
        Return dics
    End Function

#End Region

    Private Sub lblMsgList_Click(sender As Object, e As EventArgs) Handles lblMsgList.Click
        If lblMsgList.SelectedIndex >= 0 Then
            Clipboard.SetText(lblMsgList.Items(lblMsgList.SelectedIndex).ToString())
        End If
    End Sub
End Class