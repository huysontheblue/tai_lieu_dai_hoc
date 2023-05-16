Imports MainFrame.SysDataHandle
Imports System.Windows.Forms

Public Class FrmProcessParametersImport

    Public _importType As ImportTypeGrid

    Public Enum ImportTypeGrid
        ProcessParameters
        CommonDiff
    End Enum

    Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Dim listboxMenu As ContextMenuStrip = New ContextMenuStrip()
        Dim rightMenu As ToolStripMenuItem = New ToolStripMenuItem("复制所有文本")
        AddHandler rightMenu.Click, AddressOf CopyAll
        listboxMenu.Items.Add(rightMenu)
        lblMsgList.ContextMenuStrip = listboxMenu
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private fileName As String = Nothing
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        OpenFileDialog.Filter = "选择文件|*.xls;*.xlsx"
        Dim result As DialogResult = OpenFileDialog.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtPath.Text = OpenFileDialog.FileName
            Cursor.Current = Cursors.Default
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            lblMsgList.Items.Clear()
            If _importType = ImportTypeGrid.ProcessParameters Then
                DoImportProcessParameter()
            ElseIf _importType = ImportTypeGrid.CommonDiff Then
                DoImportCommonDiff()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            DeleteTempTable()
        End Try
    End Sub

    Private tempId As String = Nothing
    Private workStation As String = System.Net.Dns.GetHostName()
    Private dics As System.Collections.Generic.Dictionary(Of String, String) = New System.Collections.Generic.Dictionary(Of String, String)
    Private sConn As New MainFrame.SysDataHandle.SysDataBaseClass

#Region "加工参数"
    Private Sub DoImportProcessParameter()
        Dim errorMsg As String = Nothing
        Using dt As DataTable = SysDataBaseClass.ExportFromExcelByAs(txtPath.Text, "Sheet1", 3, 0, errorMsg)
            If dt Is Nothing Then
                ShowMessage("文件为空,请检查")
            Else
                tempId = VbCommClass.VbCommClass.UseId & Date.Now.ToString("yyyyMMddhh24missfff")
                ChangeDataTableColumnName(dt)
                ChangeDataTableStyle(dt)
                If Not InsertIntoTempTable(dt) Then Exit Sub
                If Not CheckDataDuplicate() Then Exit Sub
                If Not CheckCutSize() Then Exit Sub
                If Not CheckPNSeq() Then Exit Sub
                CheckDataExists()
            End If
        End Using
    End Sub

    Private Sub ChangeDataTableColumnName(ByVal dt As DataTable)
        For Each i As enumImportGrid In [Enum].GetValues(GetType(enumImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(enumImportGrid), i).ToString
        Next
        dt.Rows.RemoveAt(0)
    End Sub

    Private Sub ChangeDataTableStyle(ByVal dt As DataTable)
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
    End Sub

    Private Function InsertIntoTempTable(ByVal dt As DataTable) As Boolean
        Dim errmsg As String = Nothing
        dics.Clear()
        dics.Add("ID", "ID")
        dics.Add("WORKSTATION", "WORKSTATION")
        dics.Add("TVPartNumber", "TVPartNumber")
        dics.Add("TVDescription", "TVDescription")
        dics.Add("WirePartNumber", "WirePartNumber")
        dics.Add("WireDescription", "WireDescription")

        dics.Add("WIREPARTNUMBERTWO", "WIREPARTNUMBERTWO")
        dics.Add("WireDescriptionTwo", "WireDescriptionTwo")
        dics.Add("WIREPARTNUMBERTHREE", "WIREPARTNUMBERTHREE")
        dics.Add("WireDescriptionThree", "WireDescriptionThree")
        dics.Add("WIREPARTNUMBERFOUR", "WIREPARTNUMBERFOUR")
        dics.Add("WireDescriptionFour", "WireDescriptionFour")

        dics.Add("BrassHeight", "BrassHeight")
        dics.Add("BrassWidth", "BrassWidth")
        dics.Add("DrawForce", "DrawForce")
        dics.Add("PeelSize", "PeelSize")
        dics.Add("FrontSize", "FrontSize")
        dics.Add("CutSize", "CutSize")
        dics.Add("CutPartNumber", "CutPartNumber")
        If Not sConn.BulkCopy(dt, "M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T", dics, errmsg) Then
            ShowMessage("导入失败 " & errmsg)
            Return False
        End If
        Return DeleteNullDate()
    End Function

    Private Function DeleteNullDate() As Boolean
        Dim errmsg As String = Nothing
        Dim sql As String = "DELETE FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "'" & vbNewLine & _
        " AND TVPARTNUMBER IS NULL AND TVDESCRIPTION IS NULL AND WIREPARTNUMBER IS NULL AND WIREDESCRIPTION IS NULL AND FRONTSIZE IS NULL" & vbNewLine & _
        " AND BRASSHEIGHT IS NULL AND BRASSWIDTH IS NULL AND DRAWFORCE IS NULL AND PEELSIZE IS NULL AND CUTSIZE IS NULL AND CUTPARTNUMBER IS NULL"
        errmsg = sConn.ExecuteNonQuery(sql)
        If Not String.IsNullOrEmpty(errmsg) Then
            ShowMessage(errmsg)
            Return False
        End If
        Return True
    End Function

    'To Do，Old
    'Private Function CheckDataDuplicate() As Boolean
    '    Dim sql As String = "SELECT TVPARTNUMBER ,WIREPARTNUMBER FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T WHERE TVPARTNUMBER IS NULL OR WIREPARTNUMBER IS NULL " & vbNewLine & _
    '    " AND ID='" & tempId & "' AND WORKSTATION='" & workStation & "' UNION " & vbNewLine & _
    '    " SELECT TVPARTNUMBER ,WIREPARTNUMBER FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "' " & vbNewLine & _
    '    " GROUP BY TVPARTNUMBER ,WIREPARTNUMBER HAVING COUNT(*)>1 "
    '    Using dt As DataTable = sConn.GetDataTable(sql)
    '        If dt.Rows.Count > 0 Then
    '            For Each dr As DataRow In dt.Rows
    '                If String.IsNullOrEmpty(dr(0).ToString) OrElse String.IsNullOrEmpty(dr(1).ToString) Then
    '                    ShowMessage("端子料号或线材料号存在为空的,请确认")
    '                Else
    '                    ShowMessage(String.Format("端子料号:{0},线材料号:{1} 重复,请确认", dr(0).ToString, dr(1).ToString))
    '                End If
    '            Next
    '            Return False
    '        End If
    '    End Using
    '    Return True
    'End Function

    Private Function CheckDataDuplicate() As Boolean
        Dim sql As String = ""

        sql = "SELECT TVPARTNUMBER ,WIREPARTNUMBER, WIREPARTNUMBERTWO, WIREPARTNUMBERTHREE,WIREPARTNUMBERFOUR FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T " & _
           " WHERE TVPARTNUMBER IS NULL OR WIREPARTNUMBER IS NULL  AND ID='" & tempId & "' AND WORKSTATION='" & workStation & "'" & _
           " UNION" & _
           " SELECT TVPARTNUMBER ,WIREPARTNUMBER, '' AS WIREPARTNUMBERTWO,'' AS WIREPARTNUMBERTHREE,'' AS WIREPARTNUMBERFOUR FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T" & _
           " WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "'  AND WIREPARTNUMBERTWO IS NULL" & _
           " AND WIREPARTNUMBERTHREE IS NULL AND WIREPARtNUMBERFOUR IS NULL " & _
           " GROUP BY TVPARTNUMBER ,WIREPARTNUMBER HAVING COUNT(*)>1" & _
           " UNION" & _
           " SELECT TVPARTNUMBER ,WIREPARTNUMBER, WIREPARTNUMBERTWO,'' AS WIREPARTNUMBERTHREE,'' AS WIREPARTNUMBERFOUR FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T " & _
           " WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "' AND WIREPARTNUMBERTHREE IS NULL" & _
           " AND WIREPARTNUMBERFOUR IS NULL" & _
           " GROUP BY TVPARTNUMBER ,WIREPARTNUMBER, WIREPARTNUMBERTWO HAVING COUNT(*)>1 " & _
           " UNION  " & _
           " SELECT TVPARTNUMBER ,WIREPARTNUMBER, WIREPARTNUMBERTWO,WIREPARTNUMBERTHREE,'' AS WIREPARTNUMBERFOUR FROM " & _
           " M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T WHERE ID='" & tempId & "'  AND WORKSTATION='" & workStation & "' " & _
           " AND WIREPARTNUMBERFOUR IS NULL" & _
           " GROUP BY TVPARTNUMBER ,WIREPARTNUMBER, WIREPARTNUMBERTWO ,WIREPARTNUMBERTHREE " & _
           " HAVING COUNT(*)>1 " & _
           " UNION" & _
           " SELECT TVPARTNUMBER ,WIREPARTNUMBER, WIREPARTNUMBERTWO, WIREPARTNUMBERTHREE,WIREPARTNUMBERFOUR FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T " & _
           " WHERE ID='" & tempId & "'  AND WORKSTATION='" & workStation & "' AND WIREPARTNUMBERFOUR IS NULL" & _
           " GROUP BY TVPARTNUMBER ,WIREPARTNUMBER, WIREPARTNUMBERTWO,WIREPARTNUMBERTHREE,WIREPARTNUMBERFOUR " & _
           " HAVING COUNT(*)>1"
        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    If String.IsNullOrEmpty(dr(0).ToString) OrElse String.IsNullOrEmpty(dr(1).ToString) Then
                        ShowMessage("端子料号或线材料号存在为空的,请确认")
                    Else
                        ShowMessage(String.Format("端子料号:{0},线材料号:{1} 重复,请确认", dr(0).ToString, dr(1).ToString))
                    End If
                Next
                Return False
            End If
        End Using
        Return True
    End Function


    Private Sub CheckDataExists()
        Dim msg As String = Nothing
        Dim sql As String = String.Empty

        'sql = "SELECT A.TVPARTNUMBER,A.WIREPARTNUMBER FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T A,M_RUNCARDPROCESSPARAMTERSTANDARD_T B" & vbNewLine & _
        '" WHERE A.TVPARTNUMBER=B.TVPARTNUMBER AND A.WIREPARTNUMBER=B.WIREPARTNUMBER AND A.ID='" & tempId & "' AND A.WORKSTATION='" & workStation & "'"

        sql = "SELECT A.TVPARTNUMBER,A.WIREPARTNUMBER FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T A,M_RUNCARDPROCESSPARAMTERSTANDARD_T B" & vbNewLine & _
              " WHERE A.TVPARTNUMBER=B.TVPARTNUMBER AND A.WIREPARTNUMBER=B.WIREPARTNUMBER  " & _
              " AND   ISNULL(a.WIREPARTNUMBERTWO,'NA') = ISNULL(b.WIREPARTNUMBERTWO, 'NA') " & _
              " AND  ISNULL(a.WIREPARTNUMBERTHREE,'NA') =ISNULL(b.WIREPARTNUMBERTHREE,'NA')" & _
              " AND isnull(a.WIREPARTNUMBERFOUR,'NA') = ISNULL(b.WIREPARTNUMBERFOUR,'NA') and A.ID='" & tempId & "' AND A.WORKSTATION='" & workStation & "'"

        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    msg = String.Format("端子料号为{0}, 线材料号为{1}已经存在", dr(0).ToString, dr(1).ToString)
                    ShowMessage(msg)
                Next
            End If
        End Using
        If Not String.IsNullOrEmpty(msg) Then
            'Dim dr As DialogResult = MessageBox.Show(msg, "提示信息", MessageBoxButtons.YesNoCancel)
            'If dr = Windows.Forms.DialogResult.Yes Then
            '    SaveData(ImportMethod.Cover)
            'ElseIf dr = Windows.Forms.DialogResult.No Then
            '    SaveData(ImportMethod.NoCover)
            'Else
            '    ShowMessage("用户取消导入操作")
            'End If
            SaveData(ImportMethod.NoCover)
        Else
            SaveData(ImportMethod.DirectInsert)
        End If
    End Sub

    Private Function CheckCutSize() As Boolean
        Dim sql As String = "SELECT A.FRONTSIZE FROM ( SELECT ISNUMERIC(FRONTSIZE) FRONTSIZE FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "' AND FRONTSIZE IS NOT NULL) A WHERE A.FRONTSIZE=0"
        If sConn.GetRowsCount(sql) > 0 Then
            ShowMessage("前端尺寸不是数字")
            Return False
        End If
        Return True
    End Function

    Private Function CheckPNSeq() As Boolean
        Dim sql As String = ""
        Dim msg As String = ""

        sql = " SELECT TVPARTNUMBER,ISNULL(WIREPARTNUMBER,'NA') AS WIREPARTNUMBER, ISNULL(WIREPARTNUMBERFOUR,'NA') AS WIREPARTNUMBERFOUR , ISNULL(WIREPARTNUMBERTHREE,'NA')WIREPARTNUMBERTHREE ,ISNULL(WIREPARTNUMBERTWO,'NA')WIREPARTNUMBERTWO  " & _
              " FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "' "
        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    If dr("WIREPARTNUMBERTHREE") <> "NA" Then
                        If dr("WIREPARTNUMBERTWO") = "NA" Then
                            msg = String.Format("端子料号为{0}, 线材料号2不能为空", dr("TVPARTNUMBER").ToString)
                            ShowMessage(msg)
                            Return False
                        End If
                    End If
                    If dr("WIREPARTNUMBERFOUR") <> "NA" Then
                        If dr("WIREPARTNUMBERTHREE") = "NA" Then
                            msg = String.Format("端子料号为{0}, 线材料号3不能为空", dr("TVPARTNUMBER").ToString)
                            ShowMessage(msg)
                            Return False
                        End If
                    End If
                Next
            End If
        End Using
        Return True
    End Function

    Private Sub SaveData(ByVal _importMethod As ImportMethod)
        Dim sql As String = Nothing
        Select Case _importMethod
            Case ImportMethod.Cover
                sql = "UPDATE M_RUNCARDPROCESSPARAMTERSTANDARD_T  SET TVDESCRIPTION=B.TVDESCRIPTION ,WIREDESCRIPTION=B.WIREDESCRIPTION, " & vbNewLine & _
                " BRASSHEIGHT=B.BRASSHEIGHT,BRASSWIDTH=B.BRASSWIDTH,DRAWFORCE=B.DRAWFORCE,PEELSIZE=B.PEELSIZE,FRONTSIZE=B.FRONTSIZE, " & vbNewLine & _
                " CUTSIZE=B.CUTSIZE ,CUTPARTNUMBER=B.CUTPARTNUMBER,INTIME=GETDATE(),CREATEBY='" & VbCommClass.VbCommClass.UseId & "',STATUS='Y'" & vbNewLine & _
                " FROM M_RUNCARDPROCESSPARAMTERSTANDARD_T A,M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T B " & vbNewLine & _
                " WHERE A.TVPARTNUMBER=B.TVPARTNUMBER AND A.WIREPARTNUMBER=B.WIREPARTNUMBER AND B.ID='" & tempId & "' AND WORKSTATION='" & workStation & "'" & vbNewLine & _
                " INSERT INTO M_RUNCARDPROCESSPARAMTERSTANDARD_T(TVPARTNUMBER,TVDESCRIPTION,WIREPARTNUMBER,WIREDESCRIPTION,BRASSHEIGHT,BRASSWIDTH,DRAWFORCE,PEELSIZE" & vbNewLine & _
                " ,FRONTSIZE,CUTSIZE,CUTPARTNUMBER,INTIME,CREATEBY,STATUS) SELECT LTRIM(RTRIM(A.TVPARTNUMBER)),A.TVDESCRIPTION,LTRIM(RTRIM(A.WIREPARTNUMBER)),A.WIREDESCRIPTION,A.BRASSHEIGHT" & vbNewLine & _
                " ,A.BRASSWIDTH,A.DRAWFORCE,A.PEELSIZE ,CAST(A.FRONTSIZE AS FLOAT),A.CUTSIZE,A.CUTPARTNUMBER,GETDATE(),'" & VbCommClass.VbCommClass.UseId & "','Y'" & vbNewLine & _
                " FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T A LEFT JOIN M_RUNCARDPROCESSPARAMTERSTANDARD_T B ON A.TVPARTNUMBER=B.TVPARTNUMBER " & _
                " AND A.WIREPARTNUMBER=B.WIREPARTNUMBER AND A.ID='" & tempId & "' AND A.WORKSTATION='" & workStation & "' WHERE B.WIREPARTNUMBER IS NULL "
            Case ImportMethod.NoCover
                'sql = " INSERT INTO M_RUNCARDPROCESSPARAMTERSTANDARD_T(TVPARTNUMBER,TVDESCRIPTION,WIREPARTNUMBER,WIREDESCRIPTION," & _
                '      " WIREPARTNUMBERTWO,WIREDESCRIPTIONTWO, WIREPARTNUMBERTHREE,WIREDESCRIPTIONTHREE,WIREPARTNUMBERFOUR,WIREDESCRIPTIONFOUR,BRASSHEIGHT,BRASSWIDTH,DRAWFORCE,PEELSIZE" & vbNewLine & _
                '" ,FRONTSIZE,CUTSIZE,CUTPARTNUMBER,INTIME,CREATEBY,STATUS) SELECT LTRIM(RTRIM(A.TVPARTNUMBER)),A.TVDESCRIPTION,LTRIM(RTRIM(A.WIREPARTNUMBER)),A.WIREDESCRIPTION,A.BRASSHEIGHT" & vbNewLine & _
                '" ,A.BRASSWIDTH,A.DRAWFORCE,A.PEELSIZE ,CAST(A.FRONTSIZE AS FLOAT),A.CUTSIZE,A.CUTPARTNUMBER,GETDATE(),'" & VbCommClass.VbCommClass.UseId & "','Y'" & vbNewLine & _
                '" FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T A LEFT JOIN M_RUNCARDPROCESSPARAMTERSTANDARD_T B ON A.TVPARTNUMBER=B.TVPARTNUMBER " & _
                '" AND A.WIREPARTNUMBER=B.WIREPARTNUMBER AND A.ID='" & tempId & "' AND A.WORKSTATION='" & workStation & "' WHERE B.WIREPARTNUMBER IS NULL "

                sql = " INSERT INTO M_RUNCARDPROCESSPARAMTERSTANDARD_T(TVPARTNUMBER,TVDESCRIPTION,WIREPARTNUMBER,WIREDESCRIPTION," & _
           " WIREPARTNUMBERTWO,WIREDESCRIPTIONTWO, WIREPARTNUMBERTHREE,WIREDESCRIPTIONTHREE,WIREPARTNUMBERFOUR,WIREDESCRIPTIONFOUR,BRASSHEIGHT,BRASSWIDTH,DRAWFORCE,PEELSIZE" & vbNewLine & _
     " ,FRONTSIZE,CUTSIZE,CUTPARTNUMBER,INTIME,CREATEBY,STATUS) SELECT LTRIM(RTRIM(A.TVPARTNUMBER)),A.TVDESCRIPTION,LTRIM(RTRIM(A.WIREPARTNUMBER)),A.WIREDESCRIPTION," & vbNewLine & _
     " LTRIM(RTRIM(A.WIREPARTNUMBERTWO)),A.WIREDESCRIPTIONTWO,LTRIM(RTRIM(A.WIREPARTNUMBERTHREE)),A.WIREDESCRIPTIONTHREE,LTRIM(RTRIM(A.WIREPARTNUMBERFOUR)) ,A.WIREDESCRIPTIONFOUR," & vbNewLine & _
     " A.BRASSHEIGHT ,A.BRASSWIDTH,A.DRAWFORCE,A.PEELSIZE ,CAST(A.FRONTSIZE AS FLOAT),A.CUTSIZE,A.CUTPARTNUMBER,Convert(char,getdate(),120),'" & VbCommClass.VbCommClass.UseId & "','Y'" & vbNewLine & _
     " FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T A LEFT JOIN M_RUNCARDPROCESSPARAMTERSTANDARD_T B ON A.TVPARTNUMBER=B.TVPARTNUMBER " & _
     " AND A.WIREPARTNUMBER=B.WIREPARTNUMBER " & _
     " AND ISNULL(A.WIREPARTNUMBER,'NA')= ISNULL(B.WIREPARTNUMBER,'NA')" & _
     " AND ISNULL(A.WIREPARTNUMBERTWO,'NA') = ISNULL(B.WIREPARTNUMBERTWO,'NA')" & _
     " AND ISNULL(A.WIREPARTNUMBERTHREE,'NA') = ISNULL(B.WIREPARTNUMBERTHREE,'NA')" & _
     " AND ISNULL(A.WIREPARTNUMBERFOUR,'NA') = ISNULL(B.WIREPARTNUMBERFOUR,'NA')" & _
     " WHERE  A.ID='" & tempId & "' AND A.WORKSTATION='" & workStation & "' and b.WirePartNumber is  null"
            Case ImportMethod.DirectInsert
                sql = " INSERT INTO M_RUNCARDPROCESSPARAMTERSTANDARD_T(TVPARTNUMBER,TVDESCRIPTION,WIREPARTNUMBER,WIREDESCRIPTION," & _
                 " WIREPARTNUMBERTWO,WIREDESCRIPTIONTWO, WIREPARTNUMBERTHREE,WIREDESCRIPTIONTHREE,WIREPARTNUMBERFOUR,WIREDESCRIPTIONFOUR," & _
                 " BRASSHEIGHT,BRASSWIDTH,DRAWFORCE,PEELSIZE" & vbNewLine & _
                 " ,FRONTSIZE,CUTSIZE,CUTPARTNUMBER,INTIME,CREATEBY,STATUS) " & _
                 " SELECT LTRIM(RTRIM(A.TVPARTNUMBER)),A.TVDESCRIPTION,A.WIREPARTNUMBER,A.WIREDESCRIPTION," & _
                 " LTRIM(RTRIM(A.WIREPARTNUMBERTWO)), A.WIREDESCRIPTIONTWO," & _
                 " LTRIM(RTRIM(A.WIREPARTNUMBERTHREE)), A.WIREDESCRIPTIONTHREE," & _
                 " LTRIM(RTRIM(A.WIREPARTNUMBERFOUR)), A.WIREDESCRIPTIONFOUR," & _
                 " A.BRASSHEIGHT " & vbNewLine & _
                 " ,A.BRASSWIDTH,A.DRAWFORCE,A.PEELSIZE ,CAST(A.FRONTSIZE AS FLOAT),A.CUTSIZE,A.CUTPARTNUMBER,Convert(char,getdate(),120),'" & VbCommClass.VbCommClass.UseId & "','Y'" & vbNewLine & _
                 " FROM M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T A  WHERE A.ID='" & tempId & "' AND A.WORKSTATION='" & workStation & "'"
            Case Else
                ShowMessage("错误的导入方式")
                Exit Sub
        End Select
        If Not String.IsNullOrEmpty(sql) Then
            sConn.ExecSql(sql)
            ShowMessage(txtPath.Text + "导入成功")
            MessageBox.Show("导入成功")
            txtPath.Text = ""
            Button2.Enabled = False
        End If
    End Sub

    Private Sub ShowMessage(ByVal msg As String)
        lblMsgList.Items.Insert(0, msg)
        lblMsgList.Refresh()
    End Sub

    Private Enum enumImportGrid
        TVPARTNUMBER = 0
        TVDESCRIPTION
        WIREPARTNUMBER
        WIREDESCRIPTION
        WirePartNumberTwo
        WireDescriptionTwo
        WirePartNumberThree
        WireDescriptionThree
        WirePartNumberFour
        WireDescriptionFour
        BRASSHEIGHT
        BRASSWIDTH
        DRAWFORCE
        PEELSIZE
        FRONTSIZE
        CUTSIZE
        CUTPARTNUMBER
    End Enum

    Private Enum ImportMethod
        Cover
        NoCover
        DirectInsert
    End Enum

    Private Sub FrmProcessParametersImport_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub CopyAll(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CopyText As String = Nothing
        For i As Integer = 0 To lblMsgList.Items.Count - 1
            CopyText = CopyText + vbNewLine + lblMsgList.Items(i).ToString
        Next
        Clipboard.SetText(CopyText)
    End Sub

    Private Sub DeleteTempTable()
        Dim sql As String = Nothing
        If _importType = ImportTypeGrid.ProcessParameters Then
            sql = "DELETE FROM  M_RUNCARDUPLOADPROCESSPARAMTERSTANDARD_T WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "'"
        ElseIf _importType = ImportTypeGrid.CommonDiff Then
            sql = "DELETE FROM M_RUNCARDALLOWANCEPARAMETERUPLOAD_T WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "'"
        End If
        sConn.ExecuteNonQuery(sql)
    End Sub
#End Region

#Region "公差参数"
    Private Sub DoImportCommonDiff()
        Dim errorMsg As String = Nothing
        Using dt As DataTable = SysDataBaseClass.ExportFromExcelByAs(txtPath.Text, "Sheet1", 1, 0, errorMsg)
            If dt Is Nothing Then
                ShowMessage("文件为空,请检查")
            Else
                tempId = VbCommClass.VbCommClass.UseId & Date.Now.ToString("yyyyMMddhh24missfff")
                ChangeCDDataTableColumnName(dt)
                ChangeDataTableStyle(dt)
                If Not InsertIntoDCTempTable(dt) Then Exit Sub
                If Not CheckDCDataDuplicate() Then Exit Sub
                CheckDCDataExists()
            End If
        End Using
    End Sub

    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
        'dt.Rows.RemoveAt(0)
    End Sub

    Private Function InsertIntoDCTempTable(ByVal dt As DataTable) As Boolean
        Dim errmsg As String = Nothing
        dics.Clear()
        dics.Add("ID", "ID")
        dics.Add("WORKSTATION", "WORKSTATION")
        dics.Add("FinishSizeRangeMin", "FinishSizeRangeMin")
        dics.Add("FinishSizeRangeMax", "FinishSizeRangeMax")
        dics.Add("HWStandardSize", "HWStandardSize")
        dics.Add("EmersonStandardSize", "EmersonStandardSize")
        dics.Add("OtherStandardSize", "OtherStandardSize")
        dics.Add("CutSizeMin", "CutSizeMin")
        dics.Add("Tolerance", "Tolerance")
        If Not sConn.BulkCopy(dt, "M_RUNCARDALLOWANCEPARAMETERUPLOAD_T", dics, errmsg) Then
            ShowMessage("导入失败 " & errmsg)
            Return False
        End If
        Return DeleteDCNullDate()
    End Function

    Private Function DeleteDCNullDate() As Boolean
        Dim errmsg As String = Nothing
        Dim sql As String = "DELETE FROM M_RUNCARDALLOWANCEPARAMETERUPLOAD_T WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "'" & vbNewLine & _
        " AND FINISHSIZERANGEMIN IS NULL AND FINISHSIZERANGEMAX IS NULL "
        errmsg = sConn.ExecuteNonQuery(sql)
        If Not String.IsNullOrEmpty(errmsg) Then
            ShowMessage(errmsg)
            Return False
        End If
        Return True
    End Function

    Private Function CheckDCDataDuplicate() As Boolean
        Dim sql As String = " SELECT FINISHSIZERANGEMIN ,FINISHSIZERANGEMAX FROM M_RUNCARDALLOWANCEPARAMETERUPLOAD_T WHERE ID='" & tempId & "' AND WORKSTATION='" & workStation & "' " & vbNewLine & _
        " GROUP BY FINISHSIZERANGEMIN ,FINISHSIZERANGEMAX HAVING COUNT(*)>1 "
        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    ShowMessage(String.Format("成品尺寸最小值:{0},成品尺寸最大值:{1} 重复,请确认", dr(0).ToString, dr(1).ToString))
                Next
                Return False
            End If
        End Using
        Return True
    End Function

    Private Enum CDImportGrid
        FinishSizeRangeMin
        FinishSizeRangeMax
        HWStandardSize
        EmersonStandardSize
        OtherStandardSize
        CutSizeMin
        ToleranceRange
    End Enum

    Private Sub CheckDCDataExists()
        Dim msg As String = Nothing
        Dim sql As String = "SELECT A.FINISHSIZERANGEMIN,A.FINISHSIZERANGEMAX FROM M_RUNCARDALLOWANCEPARAMETERUPLOAD_T A,M_RUNCARDALLOWANCEPARAMETER_T B" & vbNewLine & _
        " WHERE A.FINISHSIZERANGEMIN=B.FINISHSIZERANGEMIN AND A.FINISHSIZERANGEMAX=B.FINISHSIZERANGEMAX AND A.ID='" & tempId & "' AND A.WORKSTATION='" & workStation & "'"
        Using dt As DataTable = sConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    msg = String.Format("成品尺寸最小值{0}, 成品尺寸最大值{1}已经存在", dr(0).ToString, dr(1).ToString)
                    ShowMessage(msg)
                Next
            End If
        End Using
        If Not String.IsNullOrEmpty(msg) Then
            SaveDCData(ImportMethod.NoCover)
        Else
            SaveDCData(ImportMethod.DirectInsert)
        End If
    End Sub

    Private Sub SaveDCData(ByVal _importMethod As ImportMethod)
        Dim sql As String = Nothing
        Select Case _importMethod
            Case ImportMethod.NoCover
                sql = " INSERT INTO M_RUNCARDALLOWANCEPARAMETER_T(FINISHSIZERANGEMIN,FINISHSIZERANGEMAX," & vbNewLine & _
               " HWSTANDARDSIZE,EMERSONSTANDARDSIZE,OTHERSTANDARDSIZE,CUTSIZEMIN,INTIME,CREATER,STATUS) SELECT LTRIM(RTRIM(A.FINISHSIZERANGEMIN)),LTRIM(RTRIM(A.FINISHSIZERANGEMAX))" & vbNewLine & _
               " ,A.HWSTANDARDSIZE,A.EMERSONSTANDARDSIZE,A.OTHERSTANDARDSIZE ,A.CUTSIZEMIN,GETDATE(),'" & VbCommClass.VbCommClass.UseId & "','Y'" & vbNewLine & _
               " FROM M_RUNCARDALLOWANCEPARAMETERUPLOAD_T A LEFT JOIN M_RUNCARDALLOWANCEPARAMETER_T B ON A.FINISHSIZERANGEMIN=B.FINISHSIZERANGEMIN " & _
               " AND A.FINISHSIZERANGEMAX=B.FINISHSIZERANGEMAX AND A.ID='" & tempId & "' AND A.WORKSTATION='" & workStation & "' WHERE B.FINISHSIZERANGEMIN IS NULL  "
            Case ImportMethod.DirectInsert
                sql = " INSERT INTO M_RUNCARDALLOWANCEPARAMETER_T(FINISHSIZERANGEMIN,FINISHSIZERANGEMAX" & vbNewLine & _
                 " ,HWSTANDARDSIZE,EMERSONSTANDARDSIZE,OTHERSTANDARDSIZE,CUTSIZEMIN,Tolerance,INTIME,CREATER,STATUS) SELECT LTRIM(RTRIM(A.FINISHSIZERANGEMIN)),LTRIM(RTRIM(A.FINISHSIZERANGEMAX))" & vbNewLine & _
               " ,A.HWSTANDARDSIZE,A.EMERSONSTANDARDSIZE,A.OTHERSTANDARDSIZE ,CUTSIZEMIN,Tolerance, GETDATE(),'" & VbCommClass.VbCommClass.UseId & "','Y'" & vbNewLine & _
                 " FROM M_RUNCARDALLOWANCEPARAMETERUPLOAD_T A  WHERE A.ID='" & tempId & "' AND A.WORKSTATION='" & workStation & "'"
            Case Else
                ShowMessage("错误的导入方式")
                Exit Sub
        End Select
        If Not String.IsNullOrEmpty(sql) Then
            sConn.ExecSql(sql)
            ShowMessage(txtPath.Text + "导入成功")
            MessageBox.Show("导入成功")
            txtPath.Text = ""
            Button2.Enabled = False
        End If
    End Sub
#End Region
End Class