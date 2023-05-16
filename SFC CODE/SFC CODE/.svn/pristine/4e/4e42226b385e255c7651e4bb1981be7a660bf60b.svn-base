Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports MainFrame

''' <summary>
''' 修改者： 田玉琳
''' 修改日： 2015/09/09
''' 修改内容：表变更
''' </summary>
''' <remarks>修改流程卡后影响范围</remarks>
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
            fileName = OpenFileDialog.SafeFileName
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
            MessageUtils.ShowError(ex.Message)
        Finally
            DeleteTempTable()
        End Try
    End Sub

    Private tempId As String = Nothing
    Private workStation As String = System.Net.Dns.GetHostName()
    Private dics As System.Collections.Generic.Dictionary(Of String, String) = New System.Collections.Generic.Dictionary(Of String, String)
    'Private sConn As New MainFrame.SysDataHandle.SysDataBaseClass

#Region "加工参数"
    Private Sub DoImportProcessParameter()
        Dim errorMsg As String = Nothing
        Using dt As DataTable = SysDataBaseClass.ExportFromExcelByAs(txtPath.Text, "Sheet1", 3, 0, errorMsg)
            'Using dt As DataTable = ExcelUtils.ExportFromExcelByAs(txtPath.Text, 0, 3, 0, errorMsg)
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
                If Not CheckEquPN() Then Exit Sub
                CheckDataExists()
                ExecCNCUpdate()
            End If
        End Using
    End Sub

    Private Sub ChangeDataTableColumnName(ByVal dt As DataTable)
        For Each i As enumImportGrid In [Enum].GetValues(GetType(enumImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(enumImportGrid), i).ToString
        Next
        'dt.Rows.RemoveAt(0) 模板变更 马跃平 2018-04-25
        dt.Rows.RemoveAt(dt.Rows.Count - 1)
        dt.Rows.RemoveAt(dt.Rows.Count - 1)
        dt.Rows.RemoveAt(dt.Rows.Count - 1)
    End Sub

    Private Sub ChangeDataTableStyle(ByVal dt As DataTable)
        Dim dr As DataColumn = New DataColumn
        dr.DataType = GetType(String)
        dr.ColumnName = "ID"
        dr.DefaultValue = tempId
        dt.Columns.Add(dr)
        Dim dr1 As DataColumn = New DataColumn
        dr1.DataType = GetType(String)
        dr1.ColumnName = "workStation"
        dr1.DefaultValue = workStation
        dt.Columns.Add(dr1)
        Dim dr2 As DataColumn = New DataColumn
        dr2.DataType = GetType(String)
        dr2.ColumnName = "Factoryid"
        dr2.DefaultValue = VbCommClass.VbCommClass.Factory
        dt.Columns.Add(dr2)
        Dim dr3 As DataColumn = New DataColumn
        dr3.DataType = GetType(String)
        dr3.ColumnName = "Profitcenter"
        dr3.DefaultValue = VbCommClass.VbCommClass.profitcenter
        dt.Columns.Add(dr3)
    End Sub


    Private Function InsertIntoTempTable(ByVal dt As DataTable) As Boolean
        Dim errmsg As String = Nothing
        dics.Clear()
        dics.Add("ID", "ID")
        dics.Add("WORKSTATION", "WORKSTATION")
        dics.Add("TVPN", "TVPN")
        dics.Add("TVDes", "TVDes")
        dics.Add("WirePN", "WirePN")
        dics.Add("WirePNDes", "WirePNDes")
        dics.Add("WirePN2", "WirePN2")
        dics.Add("WirePNDes2", "WirePNDes2")
        dics.Add("WirePN3", "WirePN3")
        dics.Add("WirePNDes3", "WirePNDes3")
        dics.Add("WirePN4", "WirePN4")
        dics.Add("WirePNDes4", "WirePNDes4")
        dics.Add("BrassHeight", "BrassHeight")
        dics.Add("BrassWidth", "BrassWidth")
        dics.Add("OutDaoHeight", "OutDaoHeight")
        dics.Add("OutDaoWidth", "OutDaoWidth")
        dics.Add("SX", "SX")
        dics.Add("XX", "XX")
        dics.Add("SP", "SP")
        dics.Add("XP", "XP")
        dics.Add("DrawForce", "DrawForce")
        dics.Add("PeelSize", "PeelSize")
        dics.Add("FrontSize", "FrontSize")
        dics.Add("CutSize", "CutSize")
        dics.Add("CutPN", "CutPN")
        dics.Add("EquPN", "EquPN")
        dics.Add("Factoryid", "Factoryid")
        dics.Add("Profitcenter", "Profitcenter")
        dt = RCardComBusiness.GetNewDataTable(dt, "TVPN IS NOT NULL", "")  'Add by CQ 20151118
        If Not DbOperateUtils.BulkCopy(dt, "m_RCardProParamUp_t", dics, errmsg) Then
            ShowMessage("导入失败 " & errmsg)
            Return False
        End If
        Return DeleteNullDate()
    End Function

    Private Function DeleteNullDate() As Boolean
        Dim errmsg As String = Nothing
        Dim sql As String = "DELETE FROM m_RCardProParamUp_t WHERE ID='" & tempId & "' AND workStation='" & workStation & "'" & _
        " AND TVPN IS NULL AND TVDes IS NULL AND WirePN IS NULL AND WirePNDes IS NULL AND FrontSize IS NULL" & _
        " AND BrassHeight IS NULL AND BrassWidth IS NULL AND DrawForce IS NULL AND PeelSize IS NULL AND CutSize IS NULL AND CutPN IS NULL"
        errmsg = DbOperateUtils.ExecSQL(sql)
        If Not String.IsNullOrEmpty(errmsg) Then
            ShowMessage(errmsg)
            Return False
        End If
        Return True
    End Function

    Private Function CheckDataDuplicate() As Boolean
        Dim sql As String = ""

        sql = "SELECT TVPN ,WirePN, WirePN2, WirePN3,WirePN4 FROM m_RCardProParamUp_t " & _
           " WHERE TVPN IS NULL OR WirePN IS NULL  AND ID='" & tempId & "' AND workStation='" & workStation & "'" & _
           " UNION" & _
           " SELECT TVPN ,WirePN, '' AS WirePN2,'' AS WirePN3,'' AS WirePN4 FROM m_RCardProParamUp_t" & _
           " WHERE ID='" & tempId & "' AND workStation='" & workStation & "'  AND WirePN2 IS NULL" & _
           " AND WirePN3 IS NULL AND WirePN4 IS NULL " & _
           " GROUP BY TVPN ,WirePN HAVING COUNT(*)>1" & _
           " UNION" & _
           " SELECT TVPN ,WirePN, WirePN2,'' AS WirePN3,'' AS WirePN4 FROM m_RCardProParamUp_t " & _
           " WHERE ID='" & tempId & "' AND workStation='" & workStation & "' AND WirePN3 IS NULL" & _
           " AND WirePN4 IS NULL" & _
           " GROUP BY TVPN ,WirePN, WirePN2 HAVING COUNT(*)>1 " & _
           " UNION  " & _
           " SELECT TVPN ,WirePN, WirePN2,WirePN3,'' AS WirePN4 FROM " & _
           " m_RCardProParamUp_t WHERE ID='" & tempId & "'  AND workStation='" & workStation & "' " & _
           " AND WirePN4 IS NULL" & _
           " GROUP BY TVPN ,WirePN, WirePN2 ,WirePN3 " & _
           " HAVING COUNT(*)>1 " & _
           " UNION" & _
           " SELECT TVPN ,WirePN, WirePN2, WirePN3,WirePN4 FROM m_RCardProParamUp_t " & _
           " WHERE ID='" & tempId & "'  AND workStation='" & workStation & "' AND WirePN4 IS NULL" & _
           " GROUP BY TVPN ,WirePN, WirePN2,WirePN3,WirePN4 " & _
           " HAVING COUNT(*)>1"
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
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

    Private Sub ExecCNCUpdate()
        '*************************************************田玉琳 20171102 开始*************************************************
        Dim strSQL As String = " SELECT TOP 10 TVPN,WirePN FROM m_RCardProParamUp_t " &
                               " WHERE  ISNULL(WirePN2,'')='' AND ISNULL(WirePN3,'')='' AND ISNULL(WirePN4,'')='' " &
                               " AND id= '{0}' AND WORKSTATION = '{1}' "
        strSQL = String.Format(strSQL, tempId, workStation)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        RCardComBusiness.ExecCNCUpdateList(dt)
        '*************************************************田玉琳 20171102 结束*************************************************
    End Sub

    Private Sub CheckDataExists()
        Dim msg As String = Nothing
        Dim sql As String = String.Empty

        sql = "SELECT A.TVPN,A.WirePN FROM m_RCardProParamUp_t A,m_RCardProParam_t B" & _
              " WHERE A.TVPN=B.TVPN AND A.WirePN=B.WirePN  " & _
              " AND  ISNULL(a.WirePN2,'NA') = ISNULL(b.WirePN2, 'NA') " & _
              " AND  ISNULL(a.WirePN3,'NA') = ISNULL(b.WirePN3,'NA')" & _
              " AND isnull(a.WirePN4,'NA') = ISNULL(b.WirePN4,'NA') and A.ID='" & tempId & "' AND A.workStation='" & workStation & "'"

        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
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
        Dim sql As String = String.Empty
        sql = " SELECT A.FrontSize FROM ( SELECT ISNUMERIC(FrontSize) FrontSize FROM m_RCardProParamUp_t " & _
              " WHERE ID='" & tempId & "' AND workStation='" & workStation & "' AND FrontSize IS NOT NULL) A WHERE A.FrontSize=0"
        'If DbOperateUtils.GetRowsCount(sql) > 0 Then
        '    ShowMessage("前端尺寸不是数字")
        '    Return False
        'End If
        Return True
    End Function

    'Add by cq 20151231
    Private Function CheckEquPN() As Boolean
        Dim sql As String = String.Empty, msg As String = "", o_strErrEquPNList As String = ""
        sql = " SELECT EquPN FROM m_RCardProParamUp_t" & _
              " WHERE EquPN NOT IN (SELECT TAvcPart FROM m_PartContrast_t WHERE 1=1)" & _
              " AND ID='" & tempId & "' AND workStation='" & workStation & "' AND EquPN IS NOT NULL"
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    o_strErrEquPNList &= IIf(o_strErrEquPNList.Equals(String.Empty), "", ",") + dr.Item(0)
                Next
                msg = String.Format("下列工治具料号:{0}不存在", o_strErrEquPNList)
                ShowMessage(msg)
                Return False
            Else
                Return True
            End If
        End Using
        Return True
    End Function

    Private Function CheckPNSeq() As Boolean
        Dim sql As String = ""
        Dim msg As String = ""

        sql = " SELECT TVPN,ISNULL(WirePN,'NA') AS WirePN, ISNULL(WirePN4,'NA') AS WirePN4 , ISNULL(WirePN3,'NA')WirePN3 ,ISNULL(WirePN2,'NA')WirePN2  " & _
              " FROM m_RCardProParamUp_t WHERE ID='" & tempId & "' AND workStation='" & workStation & "' "
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    If dr("WirePN3") <> "NA" Then
                        If dr("WirePN2") = "NA" Then
                            msg = String.Format("端子料号为{0}, 线材料号2不能为空", dr("TVPN").ToString)
                            ShowMessage(msg)
                            Return False
                        End If
                    End If
                    If dr("WirePN4") <> "NA" Then
                        If dr("WirePN3") = "NA" Then
                            msg = String.Format("端子料号为{0}, 线材料号3不能为空", dr("TVPN").ToString)
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
                sql = "UPDATE m_RCardProParam_t  SET TVDes=B.TVDes ,WirePNDes=B.WirePNDes, " & _
                " BrassHeight=B.BrassHeight,BrassWidth=B.BrassWidth," & _
                " OutDaoHeight=B.OutDaoHeight,OutDaoWidth=B.OutDaoWidth," & _
                " DrawForce=B.DrawForce,PeelSize=B.PeelSize,FrontSize=B.FrontSize, " & _
                " CutSize=B.CutSize ,CutPN=B.CutPN,INTIME=GETDATE(),UserID='" & VbCommClass.VbCommClass.UseId & "',STATUS=1" & _
                " FROM m_RCardProParam_t A,m_RCardProParamUp_t B " & _
                " WHERE A.TVPN=B.TVPN AND A.WirePN=B.WirePN AND B.ID='" & tempId & "' AND workStation='" & workStation & "'" & _
                " INSERT INTO m_RCardProParam_t(TVPN,TVDes,WirePN,WirePNDes,BrassHeight,BrassWidth,OutDaoHeight,OutDaoWidth,DrawForce,PeelSize," & _
                " FrontSize,CutSize,CutPN,INTIME,UserID,STATUS,Factoryid,Profitcenter) " & _
                " SELECT LTRIM(RTRIM(A.TVPN)),A.TVDes,LTRIM(RTRIM(A.WirePN)),A.WirePNDes,A.BrassHeight" & _
                " ,A.BrassWidth,A.OutDaoHeight,A.OutDaoWidth,A.DrawForce,A.PeelSize ,CAST(A.FrontSize AS FLOAT),A.CutSize,A.CutPN,GETDATE(),'" & VbCommClass.VbCommClass.UseId & "',1,'" & _
                  VbCommClass.VbCommClass.Factory & "'," & "'" & VbCommClass.VbCommClass.profitcenter & "'" & _
                " FROM m_RCardProParamUp_t A LEFT JOIN m_RCardProParam_t B ON A.TVPN=B.TVPN " & _
                " AND A.WirePN=B.WirePN AND A.ID='" & tempId & "' AND A.workStation='" & workStation & "' WHERE B.WirePN IS NULL "
            Case ImportMethod.NoCover
                sql = _
               " DELETE  FROM m_RCardProParam_t " + vbCrLf + _
               " WHERE ISNULL(tvpn,'') + ISNULL(WirePN,'') + ISNULL(WirePN2,'')  + ISNULL(WirePN3,'')   + ISNULL(WirePN4,'')" + vbCrLf + _
               " IN (SELECT ISNULL(a.tvpn,'') + ISNULL(a.WirePN,'') + ISNULL(a.WirePN2,'')  + ISNULL(a.WirePN3,'')   + ISNULL(a.WirePN4,'')" + vbCrLf + _
               "     FROM m_RCardProParamUp_t a " + vbCrLf + _
               "	 LEFT JOIN m_RCardProParam_t b ON   A.TVPN = B.TVPN" + vbCrLf + _
               "                AND A.WirePN = B.WirePN  " + vbCrLf + _
               "                AND A.FactoryID = B.FactoryID  " + vbCrLf + _
               "                AND A.Profitcenter = B.Profitcenter  " + vbCrLf + _
               "                AND ISNULL (A.WirePN, 'NA') = ISNULL (B.WirePN, 'NA')" + vbCrLf + _
               "                AND ISNULL (A.WirePN2, 'NA') = ISNULL (B.WirePN2, 'NA')" + vbCrLf + _
               "                AND ISNULL (A.WirePN3, 'NA') = ISNULL (B.WirePN3, 'NA')" + vbCrLf + _
               "                AND ISNULL (A.WirePN4, 'NA') = ISNULL (B.WirePN4, 'NA')" + vbCrLf + _
               "    WHERE     A.ID = '" & tempId & "'" + vbCrLf + _
               "          AND A.workStation = '" & workStation & "')" + vbCrLf + _
               " AND Factoryid='" & VbCommClass.VbCommClass.Factory & "'" & " AND Profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'"

                sql &= " INSERT INTO m_RCardProParam_t(TVPN,TVDes,WirePN,WirePNDes," & _
                 " WirePN2,WirePNDes2, WirePN3,WirePNDes3,WirePN4,WirePNDes4,BrassHeight,BrassWidth,OutDaoHeight,OutDaoWidth," & _
                 " SX,XX,SP,XP," & _
                 " DrawForce, PeelSize, " & _
                 " FrontSize,CutSize,CutPN,EquPN,INTIME,UserID,STATUS,Factoryid,Profitcenter)" & _
                 " SELECT LTRIM(RTRIM(A.TVPN)),A.TVDes,LTRIM(RTRIM(A.WirePN)),A.WirePNDes," & _
                 " LTRIM(RTRIM(A.WirePN2)),A.WirePNDes2,LTRIM(RTRIM(A.WirePN3)),A.WirePNDes3,LTRIM(RTRIM(A.WirePN4)) ,A.WirePNDes4," & _
                 " A.BrassHeight ,A.BrassWidth,A.OutDaoHeight ,A.OutDaoWidth," & _
                 " A.SX ,A.XX,A.SP ,A.XP," & _
                 " A.DrawForce,A.PeelSize ,A.FrontSize,A.CutSize,A.CutPN,A.EquPN,Convert(char,getdate(),120),'" & _
                   VbCommClass.VbCommClass.UseId & "','1','" & VbCommClass.VbCommClass.Factory & "'," & "'" & VbCommClass.VbCommClass.profitcenter & "'" & _
                 " FROM m_RCardProParamUp_t A LEFT JOIN m_RCardProParam_t B ON A.TVPN=B.TVPN " & _
                 " AND A.WirePN=B.WirePN " & _
                 " AND A.FactoryID = B.FactoryID " & _
                 " AND A.Profitcenter = B.Profitcenter  " & _
                 " AND ISNULL(A.WirePN,'NA')= ISNULL(B.WirePN,'NA')" & _
                 " AND ISNULL(A.WirePN2,'NA') = ISNULL(B.WirePN2,'NA')" & _
                 " AND ISNULL(A.WirePN3,'NA') = ISNULL(B.WirePN3,'NA')" & _
                 " AND ISNULL(A.WirePN4,'NA') = ISNULL(B.WirePN4,'NA')" & _
                 " WHERE  A.ID='" & tempId & "' AND A.workStation='" & workStation & "'"  ' mark [AND b.WirePN IS NULL],cq20151120
            Case ImportMethod.DirectInsert
                'cq 20160627,add trim WirePN, 20170524, add sx,xx,sp,xp
                sql = " INSERT INTO m_RCardProParam_t(TVPN,TVDes,WirePN,WirePNDes," & _
                 " WirePN2,WirePNDes2, WirePN3,WirePNDes3,WirePN4,WirePNDes4," & _
                 " BrassHeight,BrassWidth,OutDaoHeight,OutDaoWidth," & _
                 " SX,XX,SP,XP," & _
                 " DrawForce, PeelSize, " & _
                 " FrontSize,CutSize,CutPN,EquPN,INTIME,UserID,STATUS,Factoryid,Profitcenter) " & _
                 " SELECT LTRIM(RTRIM(A.TVPN)),A.TVDes," & _
                 " LTRIM(RTRIM(A.WirePN)),A.WirePNDes," & _
                 " LTRIM(RTRIM(A.WirePN2)), A.WirePNDes2," & _
                 " LTRIM(RTRIM(A.WirePN3)), A.WirePNDes3," & _
                 " LTRIM(RTRIM(A.WirePN4)), A.WirePNDes4," & _
                 " A.BrassHeight, A.BrassWidth, A.OutDaoHeight,A.OutDaoWidth," & _
                 " A.SX,A.XX,A.SP,A.XP," & _
                 " A.DrawForce,A.PeelSize ,CAST(A.FrontSize AS FLOAT),A.CutSize,A.CutPN, A.EquPN,Convert(char,getdate(),120),'" & VbCommClass.VbCommClass.UseId & "','1'," & _
                 " Factoryid,Profitcenter " & _
                 " FROM m_RCardProParamUp_t A  WHERE A.ID='" & tempId & "' AND A.workStation='" & workStation & "'" & _
                 " AND A.Factoryid='" & VbCommClass.VbCommClass.Factory & "'" & " AND A.Profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'"
            Case Else
                ShowMessage("错误的导入方式")
                Exit Sub
        End Select
        If Not String.IsNullOrEmpty(sql) Then
            DbOperateUtils.ExecSQL(sql)
            ShowMessage(txtPath.Text + "导入成功")
            MessageUtils.ShowInformation("导入成功")
            txtPath.Text = ""
            Button2.Enabled = False
        End If
    End Sub

    Private Sub ShowMessage(ByVal msg As String)
        lblMsgList.Items.Insert(0, msg)
        lblMsgList.Refresh()
    End Sub

    Private Enum OldenumImportGrid
        TVPN = 0
        TVDes
        WirePN
        WirePNDes
        WirePN2
        WirePNDes2
        WirePN3
        WirePNDes3
        WirePN4
        WirePNDes4
        BrassHeight
        BrassWidth
        DrawForce
        PeelSize
        FrontSize
        CutSize
        CutPN
        EquPN
    End Enum

    Private Enum enumImportGrid
        TVPN = 0
        TVDes
        WirePN
        WirePNDes
        WirePN2
        WirePNDes2
        WirePN3
        WirePNDes3
        WirePN4
        WirePNDes4
        BrassHeight
        BrassWidth
        OutDaoHeight
        OutDaoWidth
        SX
        XX
        SP
        XP
        DrawForce
        PeelSize
        FrontSize
        CutSize
        CutPN
        EquPN
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
            sql = "DELETE FROM  m_RCardProParamUp_t WHERE ID='" & tempId & "' AND workStation='" & workStation & "'"
        ElseIf _importType = ImportTypeGrid.CommonDiff Then
            sql = "DELETE FROM m_RCardAllowanceParamUp_t WHERE ID='" & tempId & "' AND workStation='" & workStation & "'"
        End If
        DbOperateUtils.ExecSQL(sql)
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
        dics.Add("Factoryid", "Factoryid")
        dics.Add("Profitcenter", "Profitcenter")
        If Not DbOperateUtils.BulkCopy(dt, "m_RCardAllowanceParamUp_t", dics, errmsg) Then
            ShowMessage("导入失败 " & errmsg)
            Return False
        End If
        Return DeleteDCNullDate()
    End Function

    Private Function DeleteDCNullDate() As Boolean
        Dim errmsg As String = Nothing
        Dim sql As String = "DELETE FROM m_RCardAllowanceParamUp_t WHERE ID='" & tempId & "' AND workStation='" & workStation & "'" & _
        " AND FinishSizeRangeMin IS NULL AND FinishSizeRangeMax IS NULL "
        errmsg = DbOperateUtils.ExecSQL(sql)
        If Not String.IsNullOrEmpty(errmsg) Then
            ShowMessage(errmsg)
            Return False
        End If
        Return True
    End Function

    Private Function CheckDCDataDuplicate() As Boolean
        Dim sql As String = " SELECT FinishSizeRangeMin ,FinishSizeRangeMax FROM m_RCardAllowanceParamUp_t WHERE ID='" & tempId & "' AND workStation='" & workStation & "' " & _
        " GROUP BY FinishSizeRangeMin ,FinishSizeRangeMax HAVING COUNT(*)>1 "
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
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
        Tolerance
    End Enum

    Private Sub CheckDCDataExists()
        Dim msg As String = Nothing
        Dim sql As String = "SELECT A.FinishSizeRangeMin,A.FinishSizeRangeMax FROM m_RCardAllowanceParamUp_t A,m_RCardAllowanceParam_t B" & _
        " WHERE A.FinishSizeRangeMin=B.FinishSizeRangeMin AND A.FinishSizeRangeMax=B.FinishSizeRangeMax AND A.ID='" & tempId & "' AND A.workStation='" & workStation & "'"
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
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
                sql = " INSERT INTO m_RCardAllowanceParam_t(FinishSizeRangeMin,FinishSizeRangeMax," &
               " HWStandardSize,EmersonStandardSize,OtherStandardSize,CutSizeMin,INTIME,UserID,STATUS,ToleranceRange,Factoryid,Profitcenter)" &
               " SELECT LTRIM(RTRIM(A.FinishSizeRangeMin)),LTRIM(RTRIM(A.FinishSizeRangeMax))" &
               " ,A.HWStandardSize,A.EmersonStandardSize,A.OtherStandardSize ,A.CutSizeMin,GETDATE(),'" & VbCommClass.VbCommClass.UseId & "','Y'" & ",Tolerance,A.Factoryid,A.Profitcenter " &
               " FROM m_RCardAllowanceParamUp_t A LEFT JOIN m_RCardAllowanceParam_t B ON A.FinishSizeRangeMin=B.FinishSizeRangeMin " & _
               " AND A.FinishSizeRangeMax=B.FinishSizeRangeMax AND A.ID='" & tempId & "' AND A.workStation='" & workStation & "' WHERE B.FinishSizeRangeMin IS NULL  "
            Case ImportMethod.DirectInsert
                sql = " INSERT INTO m_RCardAllowanceParam_t(FinishSizeRangeMin,FinishSizeRangeMax" &
                 " ,HWStandardSize,EmersonStandardSize,OtherStandardSize,CutSizeMin,ToleranceRange,INTIME,UserID,STATUS,Factoryid,Profitcenter) " &
                 "SELECT LTRIM(RTRIM(A.FinishSizeRangeMin)),LTRIM(RTRIM(A.FinishSizeRangeMax))" &
               " ,A.HWStandardSize,A.EmersonStandardSize,A.OtherStandardSize ,CutSizeMin,Tolerance, GETDATE(),'" & VbCommClass.VbCommClass.UseId & "','Y'" & ",A.Factoryid,A.Profitcenter  " &
                 " FROM m_RCardAllowanceParamUp_t A  WHERE A.ID='" & tempId & "' AND A.workStation='" & workStation & "'"
            Case Else
                ShowMessage("错误的导入方式")
                Exit Sub
        End Select
        If Not String.IsNullOrEmpty(sql) Then
            DbOperateUtils.ExecSQL(sql)
            ShowMessage(txtPath.Text + "导入成功")
            MessageUtils.ShowInformation("导入成功")
            txtPath.Text = ""
            Button2.Enabled = False
        End If
    End Sub
#End Region
End Class