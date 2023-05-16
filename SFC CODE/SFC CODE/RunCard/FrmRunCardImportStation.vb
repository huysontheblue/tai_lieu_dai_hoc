Imports System.IO
Imports MainFrame.SysDataHandle
Imports Aspose.Cells
Imports System.Windows.Forms

Public Class FrmRunCardImportStation

    Public runCardId As Integer
    Public runCardPn As String
    Public operation As String
    Private _isQueryOldVersion As String
    Public m_RuncardList As String


    Sub New(ByVal runCardId As Integer, ByVal runCardPn As String, ByVal operation As String, ByVal isQueryOldVersion As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        runCardId = runCardId
        runCardPn = runCardPn
        operation = operation
        txtPath.Text = ""
        _isQueryOldVersion = isQueryOldVersion
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub
    Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub


    Private Sub FrmRunCardImportStation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMsgList.Items.Clear()
    End Sub

    Public Enum RunCard
        Seq = 0
        StationName
        WorkHour
        Equipment
        Standard
        Remark
    End Enum

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


    Private errorMsgs As New System.Text.StringBuilder
    Private folder As String = Environment.CurrentDirectory & "\ErrorMessages_" & Date.Now.ToString("yyyyMMdd")
    Private bakFolder As String = Environment.CurrentDirectory & "\SuccessFiles_" & Date.Now.ToString("yyyyMMdd")
    Private pn As String = Nothing
    Private version As String = Nothing
    Private directoryInfo As DirectoryInfo
    Private fileInfos As FileInfo()

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        DoImport()
    End Sub

#Region "导入"

    Private Enum ImportGrid
        Version = 0
        Pn
    End Enum
    Private Function CheckDtValue(ByVal dt As DataTable)
        If dt.Rows(ImportGrid.Version)(0) Is DBNull.Value Or dt.Rows(ImportGrid.Pn)(0) Is DBNull.Value Then
            Return False
        End If
        Return True
    End Function

    Private Sub SetDtStyle(ByVal dt As DataTable)
        pn = VbCommClass.VbCommClass.PartNumberPrefix & dt.Rows(ImportGrid.Pn)(0)
        version = dt.Rows(ImportGrid.Version)(0).ToString().Trim
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
                    'sw.BaseStream.Seek(0, SeekOrigin.End)
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
            Dim sql As String = Nothing
            directoryInfo = New DirectoryInfo(txtPath.Text)
            fileInfos = directoryInfo.GetFiles()
            If fileInfos.Length > 0 Then
                CreateFolder()
                UploadFile()
            Else
                'lblMsg.Text = "该目录下面不存在Excel文件请确认！！"
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
                            'lblMsg.Text = file.Name & " 文件为空请确认！！"
                            ShowMessage(file.Name & "-->文件为空请确认！！")
                            errorMsgs.Append(file.Name & "-->文件为空请确认！！").Append(vbNewLine)
                            Continue For
                        Else
                            If Not CheckDtValue(dt) Then
                                'lblMsg.Text = file.Name & " 料件编号或是版本为空！！"
                                ShowMessage(file.Name & "-->料件编号或是版本为空！")
                                errorMsgs.Append(file.Name & "-->料件编号或是版本为空！！").Append(vbNewLine)
                                Continue For
                            End If
                            SetDtStyle(dt)
                            SetColumnName(dt)
                            If CheckData(dt, file.Name) Then
                                MoveFileToBackup(file)
                            Else
                                If errorMsgs.Length > 0 Then
                                    CreateErrorMsgFile()
                                End If
                                Continue For
                            End If
                        End If
                    End Using
                End If
            Catch ex As Exception
                lblMsg.Text = ex.Message
                ShowMessage(ex.Message)
                errorMsgs.Append(file.Name & " " & ex.Message).Append(vbNewLine)
            Finally

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

    Private Function CheckData(ByVal dt As DataTable, ByVal file As String) As Boolean
        'If PnExists() Then
        '    ''lblMsg.Text = file & "料号 " & pn + " 的流程卡已经存在，请确认"
        '    'ShowMessage(file & "料号 " & pn + " 的流程卡已经存在，请确认")
        '    'errorMsgs.Append(file & "料号 " & pn + " 的流程卡已经存在，请确认").Append(vbNewLine)
        '    'Return False
        'End If
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
                    ShowMessage(file & "" & errorMsg.Trim(",") & " 不是标准工站")
                    errorMsgs.Append(file & "--> " & errorMsg.Trim(",") + "不是标准工站")
                    Return False
                End If
                If Not CheckWorkHourIsOk() Then
                    'lblMsg.Text = file & " 工时不是数字"
                    ShowMessage(file & " 工时不是数字")
                    errorMsgs.Append(file & "--> 工时不是数字")
                    Return False
                End If
                If Not SaveData(file) Then
                    Return False
                Else
                    ShowMessage(file & " 导入成功")
                    'lblMsg.Text = file & " 导入成功"
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

    Private sConn As New MainFrame.SysDataHandle.SysDataBaseClass


    Private Function PnExists() As Boolean
        Dim sql As String = "SELECT A.PARTNUMBER FROM M_RUNCARDSTATION_T A,M_RUNCARD_T B WHERE A.ID=B.PARTID AND A.PARTNUMBER='" & pn & "'"
        If sConn.GetRowsCount(sql) > 0 Then
            Return True
        End If
        Return False
    End Function

    Private Function PnDownLoadBom(ByVal file As String) As Boolean
        Dim sql As String = "SELECT PARTNUMBER FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & pn & "'"
        'If sConn.GetRowsCount(sql) <= 0 Then
        ReloadBomInfo.ReloadBom(pn)
        'End If
        sql = "SELECT DESCRIPTION1 FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & pn & "'"
        Using dt1 As DataTable = sConn.GetDataTable(sql)
            If dt1.Rows.Count > 0 Then
                If version <> GetVersion(dt1.Rows(0)(0)) Then
                    ShowMessage(file & "-->料号版本和BOM的不一致，请检查！！")
                    'lblMsg.Text = file & "-->料号版本和BOM的不一致，请检查！！"
                    errorMsgs.Append(file & "-->料号版本和BOM的不一致，请检查！！").Append(vbNewLine)
                    Return False
                End If
            Else
                'lblMsg.Text = file & "-->料号不存在于BOM，请检查！！"
                ShowMessage(file & "-->料号不存在于BOM，请检查！！")
                errorMsgs.Append(file & "-->料号不存在于BOM，请检查！！").Append(vbNewLine)
                Return False
            End If
        End Using
        Return True
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
        Dim sql As String = "SELECT STATIONNAME FROM M_RUNCARDUPLOAD_T WHERE STATIONNAME IS NULL AND ID='" & tempId & "' AND WORKSTATION='" & workStation & "' UNION" & vbNewLine & _
        "SELECT STATIONNAME FROM M_RUNCARDUPLOAD_T WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "' GROUP BY STATIONNAME HAVING COUNT(STATIONNAME)>1"
        If sConn.GetRowsCount(sql) > 0 Then
            Return False
        End If
        Return True
    End Function

    Private Function CheckStationStand(ByRef errorMsg As String) As Boolean
        Dim sql As String = "SELECT STATIONNAME FROM M_RUNCARDUPLOAD_T A WHERE A.ID='" & tempId & "' AND A.WORKSTATION='" & workStation & "' AND NOT EXISTS (SELECT 1 FROM M_RUNCARDSTATION_T B WHERE B.STATIONNAME=A.STATIONNAME)"
        Using dt As DataTable = sConn.GetDataTable(sql)
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
        Dim sql As String = "SELECT A.WORKHOUR FROM ( SELECT ISNUMERIC(WORKHOUR) WORKHOUR FROM M_RUNCARDUPLOAD_T WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "' AND WORKHOUR IS NOT NULL) A WHERE A.WORKHOUR=0"
        If sConn.GetRowsCount(sql) > 0 Then
            Return False
        End If
        Return True
    End Function

    Private Function GetSaveSql() As String
        Dim sql As New System.Text.StringBuilder
        sql.Append(" DECLARE @PARTID INT ").Append(vbNewLine)
        sql.Append(" DECLARE @ID INT ").Append(vbNewLine)
        sql.Append(" DECLARE @MAXSEQ INT ").Append(vbNewLine)
        sql.Append(" DECLARE @RUNCARDDETAILID INT ").Append(vbNewLine)
        sql.Append(" DECLARE @OLDRUNCARDID INT ").Append(vbNewLine)
        sql.Append(" DECLARE @VERSION VARCHAR(10) ").Append(vbNewLine)
        sql.Append(" DECLARE @NEWRUNCARDID INT ").Append(vbNewLine)
        'sql.Append(" DECLARE @ERRORCODE VARCHAR(100) OUTPUT").Append(vbNewLine)
        sql.Append(" BEGIN TRY ").Append(vbNewLine)
        sql.Append(" BEGIN TRANSACTION ").Append(vbNewLine)
        sql.Append(" UPDATE M_RUNCARDSTATION_T SET SECTIONID=1 WHERE SECTIONID=1")
        sql.Append(" SELECT @MAXSEQ=SUBSTRING(MAX(STATIONNO),2,LEN(MAX(STATIONNO))-1) FROM M_RUNCARDSTATION_T ").Append(vbNewLine)
        sql.Append(" INSERT INTO M_RUNCARDSTATION_T(STATIONNO,STATIONNAME,STATIONTYPEID,STATUS,USERID,INTIME,DESCRIPTION,SECTIONID)").Append(vbNewLine)
        sql.Append(" SELECT 'A'+RIGHT('000'+CAST(@MAXSEQ+A.ID AS VARCHAR),4),").Append(vbNewLine)
        sql.Append(" A.STATIONNAME,4,1,'" & VbCommClass.VbCommClass.UseId & "',GETDATE(),NULL,").Append(vbNewLine)
        sql.Append(" CASE").Append(vbNewLine)
        sql.Append(" WHEN A.STATIONNAME LIKE N'%裁线%' THEN 1 ").Append(vbNewLine)
        sql.Append(" WHEN A.STATIONNAME LIKE N'%成型%' THEN 3 ").Append(vbNewLine)
        sql.Append(" ELSE 2 END ").Append(vbNewLine)
        sql.Append(" FROM(").Append(vbNewLine)
        sql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY A.STATIONNAME) ID, A.STATIONNAME").Append(vbNewLine)
        sql.Append(" FROM M_RUNCARDUPLOAD_T A LEFT JOIN M_RUNCARDSTATION_T B").Append(vbNewLine)
        sql.Append(" ON A.STATIONNAME=B.STATIONNAME WHERE A.ID='" & tempId & "'AND WORKSTATION='" & workStation & "' ").Append(vbNewLine)
        sql.Append(" AND B.STATIONNO IS NULL) A GROUP BY A.ID,A.STATIONNAME").Append(vbNewLine)
        sql.Append(" SELECT @PARTID=ID FROM M_RUNCARDPARTNUMBER_T WHERE PARTNUMBER='" & pn & "'").Append(vbNewLine)
        sql.Append(" SELECT @VERSION=DRAWINGVER,@ID=ID FROM M_RUNCARD_T WHERE PARTID=@PARTID").Append(vbNewLine)
        sql.Append(" IF @VERSION IS NOT NULL AND @VERSION<>'" & version & "' ").Append(vbNewLine)
        sql.Append(" BEGIN").Append(vbNewLine)
        sql.Append("    IF EXISTS(SELECT TOP 1 1 FROM M_RUNCARDOLDVERSION_T WHERE PARTID=@PARTID  AND DRAWINGVER= @VERSION)").Append(vbNewLine)
        sql.Append("        BEGIN")
        sql.Append("            SELECT @NEWRUNCARDID=ID FROM M_RUNCARDOLDVERSION_T WHERE PARTID=@PARTID AND DRAWINGVER=@VERSION").Append(vbNewLine)
        sql.Append("            DELETE A FROM M_RUNCARDPARTDETAILOLDVERSION_T A,M_RUNCARDDETAILOLDVERSION_T B ").Append(vbNewLine)
        sql.Append("                WHERE B.RUNCARDID = @NEWRUNCARDID AND B.ID=A.RUNCARDDETAILID").Append(vbNewLine)
        sql.Append("            DELETE FROM M_RUNCARDDETAILOLDVERSION_T WHERE RUNCARDID=@NEWRUNCARDID ").Append(vbNewLine)
        sql.Append("            DELETE FROM M_RUNCARDOLDVERSION_T WHERE ID=@NEWRUNCARDID ").Append(vbNewLine)
        sql.Append("        END").Append(vbNewLine)
        sql.Append("    INSERT INTO M_RUNCARDOLDVERSION_T(PARTID,DRAWINGVER,SHAPE,DRAWINGFILEPATH,REMARK,USERID,STATUS,INTIME,MODIFYTIME,PARTNUMBER) SELECT").Append(vbNewLine)
        sql.Append("            PARTID,DRAWINGVER,SHAPE,DRAWINGFILEPATH,REMARK,USERID,STATUS,INTIME,GETDATE(),PARTNUMBER FROM M_RUNCARD_T WHERE ID=@ID").Append(vbNewLine)
        sql.Append("    SELECT @NEWRUNCARDID =ID FROM M_RUNCARDOLDVERSION_T WHERE PARTID=@PARTID AND DRAWINGVER=@VERSION").Append(vbNewLine)
        sql.Append("    INSERT INTO M_RUNCARDDETAILOLDVERSION_T(RUNCARDID,STATIONSQ,STATIONID,WORKINGHOURS,EQUIPMENT,PROCESSSTANDARD,").Append(vbNewLine)
        sql.Append("            SOPFILEPATH,REMARK,USERID,STATUS,INTIME,PARTNUMBER,STATIONNAME) SELECT @NEWRUNCARDID,B.STATIONSQ,B.STATIONID,B.WORKINGHOURS,B.EQUIPMENT,").Append(vbNewLine)
        sql.Append("            B.PROCESSSTANDARD,B.SOPFILEPATH,B.REMARK,B.USERID,B.STATUS,B.INTIME,B.PARTNUMBER,B.STATIONNAME FROM M_RUNCARDDETAIL_T B ").Append(vbNewLine)
        sql.Append("            WHERE B.RUNCARDID =@ID").Append(vbNewLine)
        sql.Append("    INSERT INTO M_RUNCARDPARTDETAILOLDVERSION_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER) SELECT C.ID,A.PARTID, A.USERID,A.INTIME,A.PARTNUMBER,A.EWPARTNUMBER FROM ").Append(vbNewLine)
        sql.Append("            M_RUNCARDPARTDETAIL_T A,M_RUNCARDDETAIL_T B,M_RUNCARDDETAILOLDVERSION_T C WHERE A.RUNCARDDETAILID=B.ID AND B.RUNCARDID=@ID").Append(vbNewLine)
        sql.Append("            AND B.STATIONID=C.STATIONID AND C.RUNCARDID=@NEWRUNCARDID").Append(vbNewLine)
        sql.Append(" END").Append(vbNewLine)
        sql.Append(" IF EXISTS(SELECT 1 FROM M_RUNCARD_T WHERE PARTID=@PARTID)").Append(vbNewLine)
        sql.Append("    BEGIN").Append(vbNewLine)
        sql.Append("        SELECT @OLDRUNCARDID=ID FROM M_RUNCARD_T WHERE PARTID=@PARTID").Append(vbNewLine)
        sql.Append("        INSERT INTO M_RUNCARDLOG_T SELECT ID, PARTID,'','" & VbCommClass.VbCommClass.UseId & "',STATUS, INTIME, DRAWINGVER, DRAWINGFILEPATH, 'DELETE', GETDATE(),PARTNUMBER").Append(vbNewLine)
        sql.Append("                FROM M_RUNCARD_T WHERE ID=@OLDRUNCARDID").Append(vbNewLine)
        sql.Append("        DELETE FROM M_RUNCARD_T WHERE PARTID=@PARTID").Append(vbNewLine)
        sql.Append("        INSERT INTO M_RUNCARD_T(PARTID,DRAWINGVER,SHAPE,DRAWINGFILEPATH,REMARK,USERID,STATUS,INTIME,PARTNUMBER) VALUES(").Append(vbNewLine)
        sql.Append("            @PARTID,'" & version & "',NULL,NULL,NULL,'" & VbCommClass.VbCommClass.UseId & "',0,GETDATE(),'" & pn & "')").Append(vbNewLine)
        sql.Append("        SELECT @RUNCARDDETAILID=ID FROM M_RUNCARD_T WHERE PARTID=@PARTID").Append(vbNewLine)
        sql.Append("        INSERT INTO M_RUNCARDDETAIL_T(RUNCARDID,STATIONSQ,STATIONID,WORKINGHOURS,EQUIPMENT,").Append(vbNewLine)
        sql.Append("            PROCESSSTANDARD,SOPFILEPATH,REMARK,USERID,STATUS,INTIME,SHAPE,PARTNUMBER,STATIONNAME)").Append(vbNewLine)
        sql.Append("            SELECT @RUNCARDDETAILID,ROW_NUMBER() OVER(ORDER BY A.SEQ),B.ID,").Append(vbNewLine)
        sql.Append("            CASE WHEN A.WORKHOUR LIKE '%.[1-9][0-9]%' THEN ROUND(ISNULL(A.WORKHOUR,0),1,1)+0.1").Append(vbNewLine)
        sql.Append("            WHEN A.WORKHOUR LIKE '%.[1-9]' THEN ISNULL(A.WORKHOUR,0) ELSE ISNULL(A.WORKHOUR,0) END WORKHOUR,").Append(vbNewLine)
        sql.Append("            A.EQUIPMENT, A.STANDARD, C.SOPFILEPATH, A.REMARK, ").Append(vbNewLine)
        sql.Append("            '" & VbCommClass.VbCommClass.UseId & "',1,GETDATE(),NULL,'" & pn & "',B.STATIONNAME ").Append(vbNewLine)
        sql.Append("            FROM M_RUNCARDUPLOAD_T A,M_RUNCARDSTATION_T B LEFT JOIN M_RUNCARDDETAIL_T C ON B.ID=C.STATIONID AND C.RUNCARDID=@OLDRUNCARDID ").Append(vbNewLine)
        sql.Append("            WHERE A.STATIONNAME=B.STATIONNAME AND A.ID='" & tempId & "' AND A.WORKSTATION='" & workStation & "'").Append(vbNewLine)
        sql.Append("        INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER) ").Append(vbNewLine)
        sql.Append("            SELECT D.ID,A.PARTID ,'" & VbCommClass.VbCommClass.UseId & "',GETDATE(),'" & pn & "',A.EWPARTNUMBER FROM ").Append(vbNewLine)
        sql.Append("            M_RUNCARDPARTDETAIL_T A,M_RUNCARDDETAIL_T D,M_RUNCARDPARTNUMBER_T E,M_RUNCARDSTATION_T B LEFT JOIN M_RUNCARDDETAIL_T C ON B.ID=C.STATIONID AND C.RUNCARDID=@OLDRUNCARDID").Append(vbNewLine)
        sql.Append("            WHERE A.RUNCARDDETAILID=C.ID AND D.STATIONID=B.ID AND D.RUNCARDID=@RUNCARDDETAILID AND A.PARTID=E.ID AND E.STATUS=1 AND E.TYPE='E' ").Append(vbNewLine)
        sql.Append("        INSERT INTO M_RUNCARDPARTDETAIL_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER,EWPARTNUMBER) ").Append(vbNewLine)
        sql.Append("            SELECT D.ID,A.PARTID ,'" & VbCommClass.VbCommClass.UseId & "',GETDATE(),'" & pn & "',A.EWPARTNUMBER FROM ").Append(vbNewLine)
        sql.Append("            M_RUNCARDPARTDETAIL_T A,M_RUNCARDDETAIL_T D,M_RUNCARDBOMINFO_T F,M_RUNCARDSTATION_T B LEFT JOIN M_RUNCARDDETAIL_T C ON B.ID=C.STATIONID AND C.RUNCARDID=@OLDRUNCARDID").Append(vbNewLine)
        sql.Append("            WHERE A.RUNCARDDETAILID=C.ID AND D.STATIONID=B.ID AND D.RUNCARDID=@RUNCARDDETAILID AND A.PARTID=F.PARTID AND F.PARENTPARTID=@PARTID ").Append(vbNewLine)
        sql.Append("        DELETE A FROM M_RUNCARDPARTDETAIL_T A,M_RUNCARDDETAIL_T B WHERE A.RUNCARDDETAILID=B.ID AND B.RUNCARDID=@OLDRUNCARDID").Append(vbNewLine)
        sql.Append("        DELETE A FROM M_RUNCARDDETAIL_T A WHERE A.RUNCARDID=@OLDRUNCARDID").Append(vbNewLine)
        sql.Append("    END").Append(vbNewLine)
        sql.Append(" ELSE").Append(vbNewLine)
        sql.Append("    BEGIN").Append(vbNewLine)
        sql.Append("        INSERT INTO M_RUNCARD_T(PARTID,DRAWINGVER,SHAPE,DRAWINGFILEPATH,REMARK,USERID,STATUS,INTIME,PARTNUMBER) VALUES(").Append(vbNewLine)
        sql.Append("            @PARTID,'" & version & "',NULL,NULL,NULL,'" & VbCommClass.VbCommClass.UseId & "',0,GETDATE(),'" & pn & "')").Append(vbNewLine)
        sql.Append("            SELECT @RUNCARDDETAILID=ID FROM M_RUNCARD_T WHERE PARTID=@PARTID").Append(vbNewLine)
        sql.Append("        INSERT INTO M_RUNCARDDETAIL_T(RUNCARDID,STATIONSQ,STATIONID,WORKINGHOURS,EQUIPMENT,").Append(vbNewLine)
        sql.Append("            PROCESSSTANDARD,SOPFILEPATH,REMARK,USERID,STATUS,INTIME,SHAPE,PARTNUMBER,STATIONNAME)").Append(vbNewLine)
        sql.Append("            SELECT @RUNCARDDETAILID,ROW_NUMBER() OVER(ORDER BY A.SEQ),B.ID,").Append(vbNewLine)
        sql.Append("            CASE WHEN A.WORKHOUR LIKE '%.[1-9][0-9]%' THEN ROUND(ISNULL(A.WORKHOUR,0),1,1)+0.1").Append(vbNewLine)
        sql.Append("            WHEN A.WORKHOUR LIKE '%.[1-9]' THEN ISNULL(A.WORKHOUR,0) ELSE ISNULL(A.WORKHOUR,0) END WORKHOUR,").Append(vbNewLine)
        sql.Append("            A.EQUIPMENT, A.STANDARD, NULL, A.REMARK, ").Append(vbNewLine)
        sql.Append("            '" & VbCommClass.VbCommClass.UseId & "',1,GETDATE(),NULL,'" & pn & "',B.STATIONNAME ").Append(vbNewLine)
        sql.Append("            FROM M_RUNCARDUPLOAD_T A,M_RUNCARDSTATION_T B WHERE A.STATIONNAME=B.STATIONNAME AND A.ID='" & tempId & "'").Append(vbNewLine)
        sql.Append("            AND A.WORKSTATION='" & workStation & "'").Append(vbNewLine)
        sql.Append("    END").Append(vbNewLine)
        sql.Append(" COMMIT TRANSACTION ").Append(vbNewLine)
        sql.Append("    SET @ERRORCODE='' ").Append(vbNewLine)
        sql.Append(" END TRY").Append(vbNewLine)
        sql.Append(" BEGIN CATCH").Append(vbNewLine)
        sql.Append("     IF @@TRANCOUNT > 0").Append(vbNewLine)
        sql.Append("         BEGIN").Append(vbNewLine)
        sql.Append("            ROLLBACK TRANSACTION").Append(vbNewLine)
        sql.Append("            SET @ERRORCODE=ERROR_MESSAGE() ").Append(vbNewLine)
        sql.Append("         END").Append(vbNewLine)
        sql.Append(" END CATCH")
        Return sql.ToString
    End Function

    Private Function SaveData(ByVal file As String) As Boolean

        Dim errMsg As String = Nothing
        Dim err As New SqlClient.SqlParameter("@ERRORCODE", SqlDbType.VarChar, 1000)
        err.Direction = ParameterDirection.Output '?指定
        err.Value = ""
        Dim Paramters As SqlClient.SqlParameter() = Nothing
        Paramters = New SqlClient.SqlParameter() {err}
        errMsg = sConn.ExecuteNonQuery(GetSaveSql(), Paramters)
        If Not errMsg Is Nothing AndAlso Not String.IsNullOrEmpty(errMsg) Then
            'lblMsg.Text = file & errMsg
            ShowMessage(file & errMsg)
            errorMsgs.Append(file & errMsg)
            Return False
        ElseIf Not String.IsNullOrEmpty(err.Value.ToString) Then
            ShowMessage(file & "导入失败->" & err.Value.ToString)
            errorMsgs.Append(file & "-->" & err.Value.ToString)
            Return False
        End If
        Return True
    End Function

    Private tempId As String = Nothing
    Private workStation As String = System.Net.Dns.GetHostName()
    Private dics As System.Collections.Generic.Dictionary(Of String, String) = New System.Collections.Generic.Dictionary(Of String, String)

    Private Function InsertIntoTempTable(ByVal dt As DataTable, ByVal file As String) As Boolean
        tempId = pn & VbCommClass.VbCommClass.UseId & Date.Now.ToString("yyyyMMddhh24missfff")
        Dim sql As New System.Text.StringBuilder
        Dim errmsg As String = Nothing
        'Dim sConn1 As New SysDataBaseClass

        Try
            AddExternColumns(dt)
            dics.Clear()
            dics.Add("ID", "ID")
            dics.Add("WORKSTATION", "WORKSTATION")
            dics.Add("SEADEFINE", "SEQ")
            dics.Add("STATIONNAME", "STATIONNAME")
            dics.Add("WORKHOUR", "WORKHOUR")
            dics.Add("EQUIPMENT", "EQUIPMENT")
            dics.Add("STANDARD", "STANDARD")
            dics.Add("REMARK", "REMARK")
            dics.Add("PARTNUMBER", "PARTNUMBER")
            If Not sConn.BulkCopy(dt, "M_RUNCARDUPLOAD_T", dics, errmsg) Then
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
        Dim dr As DataColumn = New DataColumn
        dr.DataType = GetType(String)
        dr.ColumnName = "ID"
        dr.DefaultValue = tempId
        dt.Columns.Add(dr)
        Dim dr1 As DataColumn = New DataColumn
        dr1.DataType = GetType(String)
        dr1.ColumnName = "WORKSTATION"
        dr1.DefaultValue = workStation
        dt.Columns.Add(dr1)
        Dim drID As DataColumn = New DataColumn
        drID.DataType = GetType(Integer)
        drID.ColumnName = "SEADEFINE"
        dt.Columns.Add(drID)
        Dim drPn As DataColumn = New DataColumn
        drPn.DataType = GetType(String)
        drPn.ColumnName = "PARTNUMBER"
        dt.Columns.Add(drPn)
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i)("SEADEFINE") = i + 1
            dt.Rows(i)("STATIONNAME") = dt.Rows(i)("STATIONNAME").ToString().Replace("'", "''").Trim
            dt.Rows(i)("EQUIPMENT") = dt.Rows(i)("EQUIPMENT").ToString().Replace("'", "''").Trim
            dt.Rows(i)("STANDARD") = dt.Rows(i)("STANDARD").ToString().Replace("'", "''").Trim
            dt.Rows(i)("REMARK") = dt.Rows(i)("REMARK").ToString().Replace("'", "''").Trim
            dt.Rows(i)("PARTNUMBER") = pn
        Next
    End Sub

    Public Sub DeleteNullDate()
        Dim sql As String = "DELETE FROM M_RUNCARDUPLOAD_T WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "'" & vbNewLine & _
        " AND (STATIONNAME IS NULL OR STATIONNAME='') AND (WORKHOUR IS NULL OR WORKHOUR ='') AND (EQUIPMENT IS NULL OR EQUIPMENT='') AND (STANDARD IS NULL OR STANDARD='') AND( REMARK IS NULL OR REMARK ='')"
        sConn.ExecuteNonQuery(sql)
    End Sub

    Public Sub DeleteTempTable()
        Dim sql As String = Nothing
        sql = " INSERT INTO M_RUNCARDUPLOADLOG_T  SELECT * FROM  M_RUNCARDUPLOAD_T WHERE ID='" & tempId & "'AND WORKSTATION='" & workStation & "'" & vbNewLine & _
              " DELETE FROM M_RUNCARDUPLOAD_T WHERE ID='" & tempId & "'AND WORKSTATION='" & workStation & "'"
        sConn.ExecuteNonQuery(sql)
    End Sub

    Private Sub ShowMessage(ByVal msg As String)
        lblMsgList.Items.Insert(0, msg)
        lblMsgList.Refresh()
    End Sub

#End Region

#Region "导出"

    Public Sub SelectPath(ByVal pn As String, ByVal _runcardid As Integer)
        FolderBrowserDialog1.Description = "请选择保存文件路径"
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
        FolderBrowserDialog1.ShowNewFolderButton = True
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtPath.Text = FolderBrowserDialog1.SelectedPath
            Cursor.Current = Cursors.Default
            runCardPn = pn
            runCardId = _runcardid
            DoExport()
        End If
    End Sub

    Public filePath As String = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\RunCardTemplate.xlsx"  'Environment.CurrentDirectory & "\Templates" & "\RunCardTemplate.xlsx"
    Private Sub DoExport()
        Dim o_TempoutputFile As String = String.Empty 'txtPath.Text & "\" & runCardPn & ".xlsx"
        Dim errorMsg As String = Nothing
        Try
            For Each o_TempRuncardPN As String In m_RuncardList.Split(",")

                o_TempoutputFile = txtPath.Text & "\" & o_TempRuncardPN & ".xlsx"
                Using dt As DataTable = sConn.GetDataTable(GetExportSql(o_TempRuncardPN))
                    If dt.Rows.Count > 0 Then
                        dt.TableName = "RunCard"
                        If SysDataBaseClass.Import2ExcelByAs(filePath, o_TempoutputFile, dt, GetVariables(dt), errorMsg) Then
                            'MessageBox.Show("导出成功,请查看！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show(errorMsg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("料件找不到对应的流程卡", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Next
            MessageBox.Show("导出成功,请查看！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    'Private Sub DoExport()
    '    Dim outputFile As String = txtPath.Text & "\" & runCardPn & ".xlsx"
    '    Dim errorMsg As String = Nothing
    '    Try
    '        Using dt As DataTable = sConn.GetDataTable(GetExportSql)
    '            If dt.Rows.Count > 0 Then
    '                dt.TableName = "RunCard"
    '                If SysDataBaseClass.Import2ExcelByAs(filePath, outputFile, dt, GetVariables(dt), errorMsg) Then
    '                    MessageBox.Show("导出成功,请查看！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Else
    '                    MessageBox.Show(errorMsg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                End If
    '            Else
    '                MessageBox.Show("料件找不到对应的流程卡", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End Try
    'End Sub

    Public Function GetExportSql(Optional ByVal runCardPn As String = "") As String
        Dim sql As String = Nothing
        If _isQueryOldVersion = "false" Then
            sql = "SELECT  PARTNUMBER,DRAWINGVER,SHAPE,ID AS SEQ,STATIONNAME,LABORHOUR AS HOURS," & _
                  " EQUIPMENT,STANDARD,REMARK,SID SECTIONID," & _
                  " DESCRIPTION1,DESCRIPTION," & _
                  " STATUS,AUDITUSERID,CREATEUSERID ,DID," & _
                  " LEFT(RAWINFO,LEN(RAWINFO)-3) AS RAWINFO" & _
                  " FROM( SELECT A.*," & _
                  "  (SELECT PARTD.PARTNUMBER+':'+PARTD.DESCRIPTION1+' || '" & _
                  " FROM M_RUNCARDDETAIL_T DETAIL," & _
                  " M_RUNCARDPARTDETAIL_T PARTDETAIL,M_RUNCARDPARTNUMBER_T PARTD" & _
                  " WHERE DETAIL.ID = A.DID" & _
                  " AND DETAIL.ID=PARTDETAIL.RUNCARDDETAILID" & _
                  " AND PARTDETAIL.PARTID=PARTD.ID" & _
                  " AND ISNULL(PARTD.TYPE,'R')='R'" & _
                  " FOR XML PATH('')) AS RAWINFO" & _
                  " FROM ( SELECT HEADER.PARTNUMBER,HEADER.DRAWINGVER,HEADER.SHAPE, " & _
                  " CAST(ROW_NUMBER() OVER(ORDER BY DETAIL.STATIONSQ) AS INT) ID, " & _
                  " STATION.STATIONNAME STATIONNAME,ISNULL(DETAIL.WORKINGHOURS,0) LABORHOUR, " & _
                  " DETAIL.EQUIPMENT EQUIPMENT,DETAIL.PROCESSSTANDARD STANDARD, " & _
                  " DETAIL.REMARK REMARK,SECTION.ID SID,PART.DESCRIPTION1," & _
                  " PART.DESCRIPTION,HEADER.USERID AUDITUSERID,HEADER.INTIME,DETAIL.ID DID," & _
                  " DETAIL.USERID CREATEUSERID," & _
                  " Case HEADER.STATUS" & _
                  " WHEN 1 THEN N'已完成'" & _
                  " WHEN 2 THEN N'待审核'" & _
                  "ELSE N'制作中' END STATUS" & _
                  " FROM M_RUNCARDPARTNUMBER_T PART,M_RUNCARD_T HEADER,M_RUNCARDDETAIL_T DETAIL," & _
                  " M_RUNCARDSTATION_T STATION LEFT JOIN M_RUNCARDSTATIONSECTION_T SECTION " & _
                  " ON STATION.SECTIONID=SECTION.ID AND SECTION.STATUS=1  " & _
                  " WHERE PART.PARTNUMBER='" & runCardPn & "'" & _
                  " AND HEADER.PARTID =PART.ID " & _
                  " AND HEADER.ID=DETAIL.RUNCARDID " & _
                  " AND DETAIL.STATIONID =STATION.ID  " & _
                  " ) A)B ORDER BY B.ID "

        Else
            sql = "SELECT  PARTNUMBER,DRAWINGVER,SHAPE,ID AS SEQ,STATIONNAME,LABORHOUR AS HOURS," & _
                  " EQUIPMENT,STANDARD,REMARK,SID SECTIONID," & _
                  " DESCRIPTION1,DESCRIPTION," & _
                  " STATUS,AUDITUSERID,CREATEUSERID ,DID," & _
                  " LEFT(RAWINFO,LEN(RAWINFO)-3) AS RAWINFO" & _
                  " FROM( SELECT A.*," & _
                 "  (SELECT PARTD.PARTNUMBER+':'+PARTD.DESCRIPTION1+' || '" & _
                  " FROM M_RUNCARDDETAIL_T DETAIL," & _
                  " M_RUNCARDPARTDETAIL_T PARTDETAIL,M_RUNCARDPARTNUMBER_T PARTD" & _
                  " WHERE DETAIL.ID = A.DID" & _
                  " AND DETAIL.ID=PARTDETAIL.RUNCARDDETAILID" & _
                  " AND PARTDETAIL.PARTID=PARTD.ID" & _
                  " AND ISNULL(PARTD.TYPE,'R')='R'" & _
                  " FOR XML PATH('')) AS RAWINFO" & _
                  " FROM ( SELECT HEADER.PARTNUMBER,HEADER.DRAWINGVER,HEADER.SHAPE, " & _
                  " CAST(ROW_NUMBER() OVER(ORDER BY DETAIL.STATIONSQ) AS INT) ID, " & _
                  " STATION.STATIONNAME STATIONNAME,ISNULL(DETAIL.WORKINGHOURS,0) LABORHOUR, " & _
                  " DETAIL.EQUIPMENT EQUIPMENT,DETAIL.PROCESSSTANDARD STANDARD, " & _
                  " DETAIL.REMARK REMARK,SECTION.ID SID,PART.DESCRIPTION1," & _
                  " PART.DESCRIPTION,HEADER.USERID AUDITUSERID,HEADER.INTIME,DETAIL.ID DID," & _
                  " DETAIL.USERID CREATEUSERID," & _
                  " Case HEADER.STATUS" & _
                  " WHEN 1 THEN N'已完成'" & _
                  " WHEN 2 THEN N'待审核'" & _
                  "ELSE N'制作中' END STATUS" & _
                  " FROM M_RUNCARDPARTNUMBER_T PART,M_RUNCARD_T HEADER,M_RUNCARDDETAIL_T DETAIL," & _
                  " M_RUNCARDSTATION_T STATION LEFT JOIN M_RUNCARDSTATIONSECTION_T SECTION " & _
                  " ON STATION.SECTIONID=SECTION.ID AND SECTION.STATUS=1  " & _
                  " WHERE PART.PARTNUMBER='" & runCardPn & "'" & _
                  " AND HEADER.PARTID =PART.ID " & _
                  " AND HEADER.ID=DETAIL.RUNCARDID " & _
                  " AND DETAIL.STATIONID =STATION.ID  " & _
                  " AND HEADER.ID ='" & runCardId & "'" & _
                  " ) A)B ORDER BY B.ID "
        End If
        Return sql
    End Function

    'Public Function GetExportSql() As String
    '    Dim sql As String = Nothing
    '    If _isQueryOldVersion = "false" Then
    '        sql = "SELECT C.PARTNUMBER PN,C.DESCRIPTION,C.DESCRIPTION1," & vbNewLine & _
    '        " CASE " & vbNewLine & _
    '        " WHEN A.STATUS =0 THEN '未完成'" & vbNewLine & _
    '        " WHEN A.STATUS=2 THEN '待审核'" & vbNewLine & _
    '        " ELSE '已完成' END AS STATUS,A.SHAPE," & vbNewLine & _
    '        " A.DRAWINGVER VERSION,C.USERID CREATEUSER," & vbNewLine & _
    '        " CONVERT(VARCHAR(10),A.INTIME,111) CREATEDATE," & vbNewLine & _
    '        " B.STATIONSQ SEQ,D.STATIONNAME,B.WORKINGHOURS HOURS,B.EQUIPMENT," & vbNewLine & _
    '        " B.PROCESSSTANDARD STANDARD,B.REMARK,B.USERID MODIFYUSER," & vbNewLine & _
    '        "   CONVERT(VARCHAR(10),B.INTIME,111) MODIFYDATE" & vbNewLine & _
    '        "  FROM M_RUNCARD_T A,M_RUNCARDDETAIL_T B,M_RUNCARDPARTNUMBER_T C,M_RUNCARDSTATION_T D" & vbNewLine & _
    '       "    WHERE(A.PARTID = C.ID)" & vbNewLine & _
    '       " AND A.ID=B.RUNCARDID" & vbNewLine & _
    '       " AND B.STATIONID=D.ID" & vbNewLine & _
    '       " AND C.PARTNUMBER='" & runCardPn & "'" & vbNewLine & _
    '       " ORDER BY B.STATIONSQ"
    '    Else
    '        sql = "SELECT C.PARTNUMBER PN,C.DESCRIPTION,C.DESCRIPTION1," & vbNewLine & _
    '         " CASE " & vbNewLine & _
    '         " WHEN A.STATUS =0 THEN '未完成'" & vbNewLine & _
    '         " WHEN A.STATUS=2 THEN '待审核'" & vbNewLine & _
    '         " ELSE '已完成' END AS STATUS,A.SHAPE," & vbNewLine & _
    '         " A.DRAWINGVER VERSION,C.USERID CREATEUSER," & vbNewLine & _
    '         " CONVERT(VARCHAR(10),A.INTIME,111) CREATEDATE," & vbNewLine & _
    '         " B.STATIONSQ SEQ,D.STATIONNAME,B.WORKINGHOURS HOURS,B.EQUIPMENT," & vbNewLine & _
    '         " B.PROCESSSTANDARD STANDARD,B.REMARK,B.USERID MODIFYUSER," & vbNewLine & _
    '         "        CONVERT(VARCHAR(10),B.INTIME,111) MODIFYDATE" & vbNewLine & _
    '         "  FROM M_RUNCARDOLDVERSION_T A,M_RUNCARDDETAILOLDVERSION_T B,M_RUNCARDPARTNUMBER_T C,M_RUNCARDSTATION_T D" & vbNewLine & _
    '         "        WHERE(A.PARTID = C.ID)" & vbNewLine & _
    '         " AND A.ID=B.RUNCARDID" & vbNewLine & _
    '         " AND B.STATIONID=D.ID" & vbNewLine & _
    '         " AND C.PARTNUMBER='" & runCardPn & "'" & vbNewLine & _
    '         " AND A.ID=" & runCardId & "" & vbNewLine & _
    '         " ORDER BY B.STATIONSQ"
    '    End If

    '    Return sql
    'End Function

    Public Function GetVariables(ByVal dt As DataTable) As System.Collections.Generic.Dictionary(Of String, String)
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        If dt.Rows.Count > 0 Then
            'dics.Add(ExportRunCardGrid.Pn.ToString, dt.Rows(0)(ExportRunCardGrid.Pn).ToString)
            'dics.Add(ExportRunCardGrid.Description.ToString, dt.Rows(0)(ExportRunCardGrid.Description).ToString)
            'dics.Add(ExportRunCardGrid.Description1.ToString, dt.Rows(0)(ExportRunCardGrid.Description1).ToString)
            'dics.Add(ExportRunCardGrid.Status.ToString, dt.Rows(0)(ExportRunCardGrid.Status).ToString)
            'dics.Add(ExportRunCardGrid.Shape.ToString, dt.Rows(0)(ExportRunCardGrid.Shape).ToString)
            'dics.Add(ExportRunCardGrid.Version.ToString, dt.Rows(0)(ExportRunCardGrid.Version).ToString)
            'dics.Add(ExportRunCardGrid.CreateUser.ToString, dt.Rows(0)(ExportRunCardGrid.CreateUser).ToString)
            'dics.Add(ExportRunCardGrid.CreateDate.ToString, dt.Rows(0)(ExportRunCardGrid.CreateDate).ToString)

            dics.Add("PN", dt.Rows(0)("PARTNUMBER").ToString)
            dics.Add("VERSION", dt.Rows(0)("DRAWINGVER").ToString)
            dics.Add("SHAPE", dt.Rows(0)("SHAPE").ToString)
            dics.Add("DESCRIPTION1", dt.Rows(0)("DESCRIPTION1").ToString)

            dics.Add("RunCard.HoursType", "总工时:" & dt.Compute("sum(HOURS)", "") & "前加工:" & dt.Compute("sum(HOURS)", "SECTIONID= 1") & Space(1) & "产线:" & dt.Compute("sum(HOURS)", "SECTIONID= 2") & "成型:" & IIf(IsNothing(dt.Compute("sum(HOURS)", "SECTIONID= 3")), 0, dt.Compute("sum(HOURS)", "SECTIONID= 3")))
            dics.Add("DESCRIPTION", dt.Rows(0)("DESCRIPTION1").ToString)
            dics.Add("STATUS", dt.Rows(0)("STATUS").ToString)
            dics.Add("CREATEUSER", dt.Rows(0)("CREATEUSERID").ToString)
            dics.Add("AuditUser", dt.Rows(0)("AUDITUSERID").ToString)

        End If
        Return dics
    End Function

    Public Enum ExportRunCardGrid
        Pn = 0
        Description
        Description1
        Status
        Shape
        Version
        CreateUser
        CreateDate
        Seq
        StationName
        Hours
        Equipment
        Standard
        Remark
        ModifyUser
        ModifyDate
    End Enum

#End Region

End Class