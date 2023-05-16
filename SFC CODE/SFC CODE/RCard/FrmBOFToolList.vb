Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells
Imports System.Net
Imports System.Net.Mail
Imports SysBasicClass
Imports DBUtility

''' <summary>
''' add by 马跃平
''' </summary>
''' <remarks></remarks>
Public Class FrmBOFToolList
    Public m_strWhere As String = String.Empty
#Region "构造函数"
    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()
        Dim UseId = VbCommClass.VbCommClass.UseId
        For Each contxt As ToolStripMenuItem In contxtMenuMain.Items
            Dim sql = "select * from m_UserRight_t where UserID='" & UseId & "' and tkey='" & contxt.ToolTipText & "'"
            If Not contxt.ToolTipText Is Nothing Then
                Dim dt = DbOperateUtils.GetDataTable(sql)
                contxt.Enabled = IIf(dt.Rows.Count > 0, True, False)
            End If
        Next

        For Each item As ToolStripItem In toolStrip1.Items
            If Not item.ToolTipText Is Nothing Then
                If String.IsNullOrEmpty(item.ToolTipText.Trim()) = False Then
                    Dim sql = "select * from m_UserRight_t where UserID='" & UseId & "' and tkey='" & item.ToolTipText & "'"
                    Dim dt = DbOperateUtils.GetDataTable(sql)
                    item.Enabled = IIf(dt.Rows.Count > 0, True, False)
                End If
            End If
        Next

        txtCount.Text = DbOperateUtils.GetDataTable("select count(1) from m_BOFToolList_t").Rows(0)(0).ToString()
    End Sub
#End Region

#Region "窗体加载"
    Private Sub FrmBOFToolList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bindMain("")
    End Sub
#End Region

#Region "加载主档资料"
    ''' <summary>
    ''' 加载主档资料
    ''' </summary>
    ''' <param name="where">查询条件</param>
    ''' <remarks></remarks>
    Private Sub bindMain(ByVal where As String)


        dgvMain.AutoGenerateColumns = False
        Dim sql = "select TOP 50 * from V_m_BOFToolList_t " + where

        dgvMain.DataSource = DbOperateUtils.GetDataTable(sql)

        txtCount.Text = DbOperateUtils.GetDataTable("select count(1) from m_BOFToolList_t").Rows(0)(0).ToString()
    End Sub
#End Region

#Region "新增主资料"
    ''' <summary>
    ''' 新增主资料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NewFileMain_Click(sender As Object, e As EventArgs) Handles tsmiHeaderAdd.Click
        Dim frmAdd = New FrmAddBOFToolListMain()
        Dim dr As DialogResult = frmAdd.ShowDialog()
        If dr = DialogResult.OK Then
            bindMain("")
        End If
    End Sub
#End Region

#Region "修改主资料"
    ''' <summary>
    ''' 修改主资料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EditFileMain_Click(sender As Object, e As EventArgs) Handles tsmiHeaderModify.Click
        Dim UserName = VbCommClass.VbCommClass.UseName
        If dgvMain.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行数据!")
            Exit Sub
        ElseIf Convert.ToInt32(dgvMain.CurrentRow.Cells("State").Value) <> 0 And UserName <> dgvMain.CurrentRow.Cells("PIEName").Value.ToString() Then
            MessageUtils.ShowError("只有制作中的才可以修改!")
            Exit Sub
        End If
        Dim frmAdd = New FrmAddBOFToolListMain()
        frmAdd.PartID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
        frmAdd.Version = dgvMain.CurrentRow.Cells("Version").Value.ToString()
        frmAdd.OP = "Modify"
        Dim dr As DialogResult = frmAdd.ShowDialog()
        If dr = DialogResult.OK Then
            bindMain("")
        End If
    End Sub
#End Region

#Region "删除主表资料"
    ''' <summary>
    ''' 删除主表资料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DeleteMain_Click(sender As Object, e As EventArgs) Handles tsmiHeaderDelete.Click
        Try
            If dgvMain.CurrentRow Is Nothing Then
                MessageUtils.ShowError("请选择一行数据!")
                Exit Sub
            ElseIf Convert.ToInt32(dgvMain.CurrentRow.Cells("State").Value) <> 0 Then
                MessageUtils.ShowError("只有制作中的才可以删除!")
                Exit Sub
            End If
            Dim partID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
            Dim BOFVersion = dgvMain.CurrentRow.Cells("Version").Value.ToString()
            Dim dr As DialogResult = MessageUtils.ShowConfirm("确定要删除料号:" + partID + ",相关数据!", MessageBoxButtons.OKCancel)
            Dim sql = New System.Text.StringBuilder()
            If dr = Windows.Forms.DialogResult.OK Then

                sql.AppendLine(" insert into m_BOFToolListDEquimentBack_t([PartID],[StationOrderBy]")
                sql.AppendLine(" ,[StationID],[StationName],[EquimentType],[EquimentName],[DemandQty]")
                sql.AppendLine(" ,[Price],[Total],[Capacity],[FixtureNumber]")
                sql.AppendLine(",[Remark],[UserID],[UserName],[InTime],[EquimentNameZhiJu]")
                sql.AppendLine(" ,DemandQtyZhiJu,[PriceZhiJu],[TotalZhiJu]")
                sql.AppendLine(",[FESchedule],[BOFVersion],[backUserID],[backTime]) select [PartID],[StationOrderBy]")
                sql.AppendLine("  ,[StationID],[StationName],[EquimentType],[EquimentName]")
                sql.AppendLine(" ,[DemandQty],[Price],[Total],[Capacity],[FixtureNumber],[Remark],[UserID]")
                sql.AppendLine(" ,UserName,[InTime],[EquimentNameZhiJu],[DemandQtyZhiJu],[PriceZhiJu]")
                sql.AppendLine(" ,[TotalZhiJu],[FESchedule],[BOFVersion], '" & VbCommClass.VbCommClass.UseId & "',getdate() ")
                sql.AppendLine(" from m_BOFToolListDEquiment_t where partid=N'" & partID & "' AND isnull(BOFVersion,'" & BOFVersion & "') ='" & BOFVersion & "'")

                sql.AppendLine(" Insert into m_BOFToolListDBack_t( partID,[OrderBy],[Stationid],[StationName],[InTime],[UserID],[UserName],[Equipment],[BOFVersion]) select [partID]")
                sql.AppendLine(" ,[OrderBy],[Stationid],[StationName],[InTime],[UserID],[UserName],[Equipment],[BOFVersion]")
                sql.AppendLine(" from m_BOFToolListD_t  where partid=N'" & partID & "' AND isnull(BOFVersion,'" & BOFVersion & "') ='" & BOFVersion & "'")

                sql.AppendLine(" Insert into m_BOFToolListBack_t( [partID],[CustName],[Version],[ProductName],[Description],[Shape],[PIEName],[FEEmpNo],[FEName],[InTime],[State],[DocID],[FETargetDate],[FESchedule],[BeOverduNum],[warnDate],[FEDutyEmail],[FEDutyBossEmail],[BossEmailDept],[BossEmailDeptChief],[PIEMail],UrgentState) select [partID]")
                sql.AppendLine(" ,[CustName],[Version],[ProductName],[Description],[Shape]")
                sql.AppendLine(" ,[PIEName],[FEEmpNo],[FEName],[InTime],[State],[DocID]")
                sql.AppendLine(" ,[FETargetDate],[FESchedule],[BeOverduNum],[warnDate],[FEDutyEmail]")
                sql.AppendLine(" ,[FEDutyBossEmail],[BossEmailDept],[BossEmailDeptChief],[PIEMail],[UrgentState]")
                sql.AppendLine(" from m_BOFToolList_t  where partid=N'" & partID & "' AND isnull(Version,'" & BOFVersion & "') ='" & BOFVersion & "'")

                ' sql.AppendLine("delete m_BOFToolListLog_t WHERE PartID='" & partID & "' AND isnull(BOFVersion,'" & BOFVersion & "') ='" & BOFVersion & "' ")
                sql.AppendLine(" delete m_BOFToolListDEquiment_t where partid=N'" & partID & "' AND isnull(BOFVersion,'" & BOFVersion & "') ='" & BOFVersion & "'")
                sql.AppendLine(" delete m_BOFToolListD_t where partid=N'" & partID & "' AND isnull(BOFVersion,'" & BOFVersion & "') ='" & BOFVersion & "'")
                sql.AppendLine(" delete m_BOFToolList_t where partid=N'" & partID & "' AND isnull(Version,'" & BOFVersion & "') ='" & BOFVersion & "'")

                DbOperateUtils.ExecSQL(sql.ToString())
                MessageUtils.ShowInformation("删除成功")
                bindMain("")
            End If
        Catch ex As Exception
            MessageUtils.ShowError("删除异常:" & vbCrLf & "" + ex.Message)
        End Try

    End Sub
#End Region

#Region "主 DataGridView SelectionChanged事件"
    Private Sub dgvMain_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMain.SelectionChanged
        Dim partID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
        Dim CurrentVer As String = dgvMain.CurrentRow.Cells("Version").Value.ToString()
        bindDetail(CurrentVer)
        dgvDetail.ClearSelection()
        bindEquiment(partID, "", "", CurrentVer)

    End Sub
#End Region

#Region "加载BOF明细资料"
    ''' <summary>
    ''' 加载BOF明细资料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub bindDetail(Optional ByVal strVersion As String = "")
        If Not dgvMain.CurrentRow Is Nothing Then
            Dim partID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
            Dim sql = "select * from m_BOFToolListD_t a" & vbCrLf &
            "where PartID=N'" & partID & "' and isnull(BOFVersion,'" & strVersion & "') = '" & strVersion & "' order by OrderBy"
            dgvDetail.AutoGenerateColumns = False
            dgvDetail.DataSource = DbOperateUtils.GetDataTable(sql)
        End If
    End Sub
#End Region

#Region "新增明细资料"
    ''' <summary>
    ''' 新增明细资料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NewFileDetail_Click(sender As Object, e As EventArgs) Handles tsmiDetailAdd.Click
        If dgvMain.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选新增一笔BOF主档料号资料")
            Exit Sub
        End If

        If IsValiteOperation() = False Then
            MessageUtils.ShowError("只有制作中的数据才可以操作")
            Exit Sub
        End If

        Dim partID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
        Dim CurrentVer As String = dgvMain.CurrentRow.Cells("Version").Value.ToString()
        Dim Detail = New FrmAddBOFToolListDetail()
        Detail.PartID = partID
        Detail.BOFVersion = CurrentVer
        Detail.OP = "Add"
        Detail.ShowDialog()
        bindDetail(CurrentVer)
        dgvDetail.ClearSelection()
        bindEquiment(partID, "", "", CurrentVer)
        setMainTotal(CurrentVer)
    End Sub
#End Region

#Region "修改明细资料"
    ''' <summary>
    ''' 修改明细资料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EditFileDetail_Click(sender As Object, e As EventArgs) Handles tsmiDetailModify.Click
        If dgvMain.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选一笔BOF主档料号资料")
            Exit Sub
        ElseIf dgvDetail.SelectedRows.Count = 0 Then
            MessageUtils.ShowError("请选中一笔工站资料")
            Exit Sub
        End If
        If IsValiteOperation() = False Then
            MessageUtils.ShowError("只有制作中的数据才可以操作")
            Exit Sub
        End If
        Dim partID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
        Dim CurrentVer = dgvMain.CurrentRow.Cells("Version").Value.ToString()
        Dim Stationid = dgvDetail.CurrentRow.Cells("Stationid").Value.ToString()
        Dim Detail = New FrmAddBOFToolListDetail()
        Detail.OP = "Modify"
        Detail.PartID = partID
        Detail.MyStationID = Stationid
        Detail.BOFToolListDID = Convert.ToInt32(dgvDetail.CurrentRow.Cells("BOFToolListDID").Value)
        Detail.MyStationName = dgvDetail.CurrentRow.Cells("StationName").Value.ToString()
        Detail.OrderBy = dgvDetail.CurrentRow.Cells("OrderBy").Value.ToString()
        Detail.MyUserName = dgvDetail.CurrentRow.Cells("UserName").Value.ToString()
        Detail.MyInTime = Date.Parse(dgvDetail.CurrentRow.Cells("DInTime").Value)
        Detail.ShowDialog()
        bindDetail(CurrentVer)
        dgvDetail.ClearSelection()
        bindEquiment(partID, "", "", CurrentVer)
        setMainTotal()
    End Sub
#End Region

#Region "删除明细资料"
    ''' <summary>
    ''' 删除明细资料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DeleteDetail_Click(sender As Object, e As EventArgs) Handles tsmiDetailDelete.Click
        Try
            If dgvDetail.SelectedRows.Count = 0 Then
                MessageUtils.ShowError("请选中一笔工站资料")
                Exit Sub
            End If
            If IsValiteOperation() = False Then
                MessageUtils.ShowError("只有制作中的数据才可以操作")
                Exit Sub
            End If
            Dim partID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
            Dim CurrentVer = dgvMain.CurrentRow.Cells("Version").Value.ToString()
            Dim OrderBy = dgvDetail.CurrentRow.Cells("OrderBy").Value.ToString()
            Dim Stationname = dgvDetail.CurrentRow.Cells("Stationname").Value.ToString()
            Dim dr = DbOperateUtils.GetDataTable("select * from m_BOFToolListD_t where partID=N'" & partID & "' and OrderBy='" & OrderBy & "'").Rows(0)
            Dim dl = MessageUtils.ShowConfirm("确定要删除工序是:" & OrderBy & ",工站:" & Stationname & "的信息嘛?", MessageBoxButtons.OKCancel)
            If dl = Windows.Forms.DialogResult.OK Then
                Dim sql = New StringBuilder()

                sql.AppendLine("delete m_BOFToolListDEquiment_t WHERE partID=N'" & partID & "' and bofVersion='" & CurrentVer & "' and StationOrderBy='" & OrderBy & "'")
                sql.AppendLine("delete m_BOFToolListD_t where partID=N'" & partID & "' and bofVersion='" & CurrentVer & "' and OrderBy='" & OrderBy & "'")
                sql.AppendLine("exec Proc_ModifyBOFToolListDOrderBy N'" & partID & "'," & OrderBy & ",'Delete',-1,'" & CurrentVer & "'")
                sql.AppendLine(String.Format("insert into m_BOFToolListLog_t " & vbCrLf &
     "(PartID,ChangeType,OldUserName,OldTime,OldValue,NewUserName,NewTime,NewValue,StationName,EquimentName,OrderBy) " & vbCrLf &
     "values(N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}','{6}',N'{7}',N'{8}',N'{9}','{10}')", partID, "删除工站", dr("UserName").ToString(), dr("InTime").ToString(), Stationname, VbCommClass.VbCommClass.UseName, Date.Now, "", Stationname, "", OrderBy))
                DbOperateUtils.ExecSQL(sql.ToString())

                MessageUtils.ShowInformation("删除成功")
                bindDetail(CurrentVer)
                dgvDetail.ClearSelection()
                bindEquiment(partID, "", "", CurrentVer)
                setMainTotal(CurrentVer)
            End If
        Catch ex As Exception
            MessageUtils.ShowError("删除出错:" & vbCrLf & "" + ex.Message)
        End Try

    End Sub
#End Region

#Region "导出Excel"
    ''' <summary>
    ''' 导出Excel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles tsmiExport.Click
        Try
            If dgvMain.CurrentRow Is Nothing Then
                MessageUtils.ShowError("请选一笔BOF主档料号资料")
                Exit Sub
            ElseIf Convert.ToInt32(dgvMain.CurrentRow.Cells("State").Value) <> 2 Then
                MessageUtils.ShowError("只有已完成的数据才可以导出")
                Exit Sub
            End If
            Dim partID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
            Dim BOFVersion = dgvMain.CurrentRow.Cells("Version").Value.ToString()
            SaveFileDialog1.Filter = "xls(*.xls)|*.xls"
            SaveFileDialog1.RestoreDirectory = True
            SaveFileDialog1.FileName = Replace(partID, "/", "_") & "-" & "治具BOF清单.xls"
            If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CreateXls(SaveFileDialog1.FileName, partID, BOFVersion)
                MessageUtils.ShowInformation("导出成功!")
                System.Diagnostics.Process.Start(SaveFileDialog1.FileName)
            End If
        Catch ex As Exception
            MessageUtils.ShowError("导出异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "生成Excel文档"
    ''' <summary>
    ''' 生成Excel文档
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CreateXls(ByVal FilePath As String, ByVal partID As String, ByVal BOFVersion As String)

        Dim ds = DbOperateUtils.GetDataSet("exec Proc_BOFExportAndPrintSql N'" & partID & "', '" & BOFVersion & "'")
        ds.Tables(0).TableName = "dtMain"
        Dim dtMain = ds.Tables(0)
        ds.Tables(1).TableName = "A"
        Dim dtDetail = ds.Tables(1)
        Dim Designer = New WorkbookDesigner()

        Dim book = New Workbook("\\192.168.20.123\RunCard\EMCBOFEquipmentList.xls")
        Designer.Workbook = book
        Dim sheet = book.Worksheets(0)
        sheet.Name = "BOF清单"

        Dim dics = New Dictionary(Of String, String)
        dics.Add("PartID", dtMain.Rows(0)("PartID").ToString())
        dics.Add("CustName", dtMain.Rows(0)("CustName").ToString())
        dics.Add("Version", "版本:" + dtMain.Rows(0)("Version").ToString())
        dics.Add("AllTotal", dtMain.Rows(0)("AllTotal").ToString())
        dics.Add("InTime", Convert.ToDateTime(dtMain.Rows(0)("InTime").ToString()).ToString("yyyy-MM-dd"))
        dics.Add("PIEName", "PIE:" + dtMain.Rows(0)("PIEName").ToString())
        dics.Add("FEName", "FE:" + dtMain.Rows(0)("FEName").ToString())
        For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
            Designer.SetDataSource(dic.Key, dic.Value)
        Next
        Designer.SetDataSource(dtDetail)
        Designer.Process()
        Dim cells As Cells = sheet.Cells
        Dim list = New List(Of String)

        For i As Integer = 0 To dtDetail.Rows.Count - 1
            Dim StationName = dtDetail.Rows(i)("StationName").ToString()
            Dim R = dtDetail.Rows(i)("R").ToString()
            If (list.Contains(R + "_" + StationName) = False) Then
                list.Add(R + "_" + StationName)
                Dim Count As Integer = dtDetail.Select("R='" & R & "' and StationName='" & StationName & "'").Length
                cells.Merge(3 + i, 0, Count, 1)
                cells.Merge(3 + i, 1, Count, 1)
            End If
        Next
        Designer.Workbook.Save(FilePath)
    End Sub
#End Region

#Region "退出"
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
#End Region

#Region "绑定料号工站设备和工治具资料"
    ''' <summary>
    ''' 绑定料号工站设备和工治具资料
    ''' </summary>
    ''' <param name="partID">料号</param>
    ''' <param name="Stationid">工站编号</param>
    ''' <param name="StationOrderBy">工站排序</param>
    ''' <remarks></remarks>
    Private Sub bindEquiment(ByVal partID As String, ByVal Stationid As String, ByVal StationOrderBy As String, Optional ByVal strVer As String = "")
        Dim where = " where 1=1 "

        If Not String.IsNullOrEmpty(partID) Then
            where &= " and a.PartID=N'" & partID & "'"
        End If
        If Not String.IsNullOrEmpty(Stationid) Then
            where &= " and a.Stationid='" & Stationid & "'"
        End If
        If Not String.IsNullOrEmpty(StationOrderBy) Then
            where &= " and a.StationOrderBy=" + StationOrderBy
        End If

        If Not String.IsNullOrEmpty(strVer) Then
            where &= " and  isnull(a.BOFVersion,'')='" & strVer & "'"    '" & strVer & "
        End If

        where &= " order by b.OrderBy,a.EquimentType"

        'AND isnull(a.BOFVersion, isnull(b.BOFVersion,'')) = isnull(b.BOFVersion,'') 
        Dim sql = "select a.* from V_m_BOFToolListDEquiment_t a" & vbCrLf &
        "join m_BOFToolListD_t b on b.PartID=a.PartID and b.OrderBy=a.StationOrderBy AND A.StationID=B.Stationid  AND isnull(a.BOFVersion, isnull(b.BOFVersion,'')) = isnull(b.BOFVersion,'') " + vbCrLf + where
        Dim dt = DbOperateUtils.GetDataTable(sql)
        dgvEquiment.AutoGenerateColumns = False
        dgvEquiment.DataSource = dt
        dgvEquiment.MergeColumnNames.Add("StationOrderBy")
        dgvEquiment.MergeColumnNames.Add("EquimentType")
        dgvEquiment.MergeColumnNames.Add("Capacity")
        dgvEquiment.MergeColumnNames.Add("FixtureNumber")
        dgvEquiment.MergeColumnNames.Add("EStationName")

        dgvEquiment.ClearSelection()
    End Sub
#End Region

#Region "工站dgvDetail_SelectionChanged"
    Private Sub dgvDetail_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDetail.SelectionChanged
        Dim partid = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
        Dim Version As String = dgvMain.CurrentRow.Cells("Version").Value.ToString()  'BOFVersion
        Dim Stationid = dgvDetail.CurrentRow.Cells("Stationid").Value.ToString()
        Dim OrderBy = dgvDetail.CurrentRow.Cells("OrderBy").Value.ToString()
        bindEquiment(partid, Stationid, OrderBy, Version)
    End Sub
#End Region

#Region "新增装备和治具"
    ''' <summary>
    ''' 新增装备和治具
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiEquimentAdd_Click(sender As Object, e As EventArgs) Handles tsmiEquimentAdd.Click
        If dgvDetail.SelectedRows.Count = 0 Then
            MessageUtils.ShowError("请选择一个工站!")
            Exit Sub
        End If
        If IsValiteOperation() = False Then
            MessageUtils.ShowError("只有制作中的数据才可以操作")
            Exit Sub
        End If
        Dim frmAdd = New FrmAddBOFToolListEquiment()
        frmAdd.OP = "Add"
        frmAdd.PartID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
        frmAdd.BOFVersion = dgvMain.CurrentRow.Cells("Version").Value.ToString()

        frmAdd.OrderBy = dgvDetail.CurrentRow.Cells("OrderBy").Value.ToString()
        frmAdd.Stationid = dgvDetail.CurrentRow.Cells("Stationid").Value.ToString()
        frmAdd.TxtPartID.Text = frmAdd.PartID
        frmAdd.txtStationName.Text = dgvDetail.CurrentRow.Cells("StationName").Value.ToString()

        frmAdd.ShowDialog()
        bindEquiment(frmAdd.PartID, "", "", frmAdd.BOFVersion)
        setMainTotal(frmAdd.BOFVersion)
    End Sub
#End Region

#Region "编辑装备和治具"
    ''' <summary>
    ''' 编辑装备和治具
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiEquimentEdit_Click(sender As Object, e As EventArgs) Handles tsmiEquimentEdit.Click
        If dgvEquiment.SelectedRows.Count = 0 Then
            MessageUtils.ShowError("请选择一行设备数据!")
            Exit Sub
        End If
        If IsValiteOperation() = False Then
            MessageUtils.ShowError("只有制作中的数据才可以操作")
            Exit Sub
        End If
        Dim frmAdd = New FrmAddBOFToolListEquiment()
        frmAdd.OP = "Modify"
        frmAdd.ID = dgvEquiment.CurrentRow.Cells("ID").Value.ToString()
        frmAdd.OrderBy = dgvEquiment.CurrentRow.Cells("StationOrderBy").Value.ToString()
        frmAdd.PartID = dgvEquiment.CurrentRow.Cells("EPartID").Value.ToString()
        frmAdd.Stationid = dgvEquiment.CurrentRow.Cells("EStationid").Value.ToString()
        frmAdd.TxtPartID.Text = frmAdd.PartID
        frmAdd.txtStationName.Text = dgvEquiment.CurrentRow.Cells("EStationName").Value.ToString()
        frmAdd.ShowDialog()
        bindEquiment(frmAdd.PartID, "", "")
        setMainTotal()
    End Sub
#End Region

#Region "删除设备和治具"
    ''' <summary>
    ''' 删除设备和治具
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiEquimentDelete_Click(sender As Object, e As EventArgs) Handles tsmiEquimentDelete.Click
        Try
            If dgvEquiment.SelectedRows.Count = 0 Then
                MessageUtils.ShowError("请选择一行设备数据!")
                Exit Sub
            End If
            If IsValiteOperation() = False Then
                MessageUtils.ShowError("只有制作中的数据才可以操作")
                Exit Sub
            End If
            Dim dr = MessageUtils.ShowConfirm("确定要删除改行的设备信息吗?", MessageBoxButtons.OKCancel)
            If dr = Windows.Forms.DialogResult.OK Then
                Dim id = dgvEquiment.CurrentRow.Cells("ID").Value.ToString()
                DbOperateUtils.ExecSQL("delete m_BOFToolListDEquiment_t where id=" & id)
                Dim partid = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
                Dim BOFVersion As String = dgvMain.CurrentRow.Cells("Version").Value.ToString()
                bindEquiment(partid, "", "", BOFVersion)
                setMainTotal(BOFVersion)
            End If

        Catch ex As Exception
            MessageUtils.ShowError("删除失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "新增,编辑,删除后不刷新重新计算主表格的相关总费用"
    ''' <summary>
    ''' 新增,编辑,删除后不刷新重新计算主表格的相关总费用
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setMainTotal(Optional ByVal strVersion As String = "")
        Dim partID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
        Dim sql = "select sum(Total) from m_BOFToolListDEquiment_t " & vbCrLf &
        "where partid=N'" & partID & "' and BOFVersion='" & strVersion & "'  and EquimentType = N'设备'"
        dgvMain.CurrentRow.Cells("DeviceToal").Value = DbOperateUtils.GetDataTable(sql).Rows(0)(0)
        sql = "select sum(TotalZhiJu) from m_BOFToolListDEquiment_t " & vbCrLf &
        "where partid=N'" & partID & "' and BOFVersion='" & strVersion & "' and EquimentType = N'治具'"
        dgvMain.CurrentRow.Cells("FixturesToal").Value = DbOperateUtils.GetDataTable(sql).Rows(0)(0)
        sql = "select sum(Total+TotalZhiJu) from m_BOFToolListDEquiment_t " & vbCrLf &
       "where partid=N'" & partID & "' and BOFVersion='" & strVersion & "'"
        dgvMain.CurrentRow.Cells("AllTotal").Value = DbOperateUtils.GetDataTable(sql).Rows(0)(0)
    End Sub
#End Region

#Region "主表格双击事件"
    Private Sub dgvMain_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMain.CellDoubleClick

        Try
            Select Case dgvMain.Columns(e.ColumnIndex).Name.ToUpper
                Case "FILEPATH"
                    Dim arrPara(0) As String
                    Dim dtPLMData As DataTable
                    Dim o_iLength As Integer
                    Dim BomQuery As New com.luxshare_ict.plm.WebService1
                    Dim Valueyy As String = dgvMain.CurrentRow.Cells("PartID").Value

                    Dim DT As DataTable = BomQuery.GetPLMCADD(VbCommClass.VbCommClass.UseId, Valueyy, "蓝图")
                    Dim o_strFilter As String = Valueyy + "%"

                    If DT.Rows.Count > 0 Then
                        If DT.Select("lx_parts LIKE '" & o_strFilter & "'").Length > 0 Then
                            arrPara(0) = CStr(DT.Select("lx_parts LIKE '" & o_strFilter & "'")(0).Item(1))
                        Else
                            If Not IsNothing(DT) Then
                                DT.Clear()
                            End If
                            o_iLength = InStr(Valueyy, "-") - 1
                            If o_iLength <= 0 Then
                                o_iLength = CStr(Valueyy).Length
                            End If
                        End If
                    End If

                    DT = BomQuery.GetPLMCADD(VbCommClass.VbCommClass.UseId, Valueyy.Substring(0, o_iLength), "蓝图")
                    o_strFilter = Valueyy.Substring(0, o_iLength) + "%"
                    If DT.Rows.Count > 0 Then
                        If DT.Select("lx_parts LIKE '" & o_strFilter & "'").Length > 0 Then
                            arrPara(0) = CStr(DT.Select("lx_parts LIKE '" & o_strFilter & "'")(0).Item(1))
                        End If
                    End If

                    dtPLMData = BomQuery.GetPLMData_current(arrPara, "n/K67oxui8q8TFMwoAQKng==")
                    If dtPLMData.Rows.Count > 0 Then
                        Dim strEncryptionURL As String = CStr(dtPLMData.Rows(0).Item("url"))
                        If (String.IsNullOrEmpty(strEncryptionURL)) Then
                            Exit Sub
                        End If
                        Dim strURL As String = "http://172.20.22.85:17888/OnlinePreview/plmonline?cdid=" + dtPLMData.Rows(0).Item("id").ToString()
                        System.Diagnostics.Process.Start(strURL)
                    Else
                        MessageUtils.ShowError("图纸路径不存在！")
                    End If

                Case "BOFFILE"
                    Dim o_strURL As String= string.Empty
                    o_strURL = dgvMain.CurrentRow.Cells("BOFFile").Value.ToString
                    If Not String.IsNullOrEmpty(o_strURL) Then
                        System.Diagnostics.Process.Start(o_strURL)
                    End If
                Case Else
                    'do nothing
            End Select
            ' If dgvMain.Columns(e.ColumnIndex).Name = "FilePath" Then

            ' End If
        Catch ex As Exception
            MessageUtils.ShowError("查看图纸路径异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "审核主表资料"
    ''' <summary>
    ''' 审核主表资料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tmisHeadAuditing_Click(sender As Object, e As EventArgs) Handles tmisHeadAuditing.Click
        If dgvMain.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一笔资料审核")
            Return
        End If

        Dim State = dgvMain.CurrentRow.Cells("State").Value
        If Convert.ToInt32(State) <> 1 Then
            MessageUtils.ShowError("只有待审核状态才能审核")
            Return
        End If

        Dim partid = dgvMain.CurrentRow.Cells("PartID").Value
        Dim BOFVersion As String = dgvMain.CurrentRow.Cells("Version").Value.ToString.Trim()
        Dim FilePath = Application.StartupPath + "\" + Replace(partid, "/", "_") & "-" & "治具BOF清单.xls"

        Try
            Dim sql = "update m_BOFToolList_t set state='2' where partid=N'" & partid & "' and Version='" & BOFVersion & "'"
            DbOperateUtils.ExecSQL(sql)
            MessageUtils.ShowInformation("审核成功")
            ChangeStatus(dgvMain.CurrentRow, "2")

            CreateXls(FilePath, partid, BOFVersion)

            SendEmailAndAttachment(FilePath, partid, BOFVersion)

            If System.IO.File.Exists(FilePath) Then
                System.IO.File.Delete(FilePath)
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "审核主档资料生成Excel文档邮件通知FE负责人"
    ''' <summary>
    ''' 审核主档资料生成Excel文档邮件通知FE负责人
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SendEmailAndAttachment(ByVal FileName As String, ByVal partid As String, ByVal strVersion As String)
        Try

            Dim dt = DbOperateUtils.GetDataTable("select * from m_BOFToolList_t where PartID=N'" & partid & "' and version ='" & strVersion & "'")

            If String.IsNullOrEmpty(dt.Rows(0)("FETargetDate").ToString()) Then
                MessageUtils.ShowError("FE完成日期不能为空,请检查! ")
                Exit Sub
            End If

            Dim PIEName = dt.Rows(0)("PIEName").ToString()
            Dim FEName = dt.Rows(0)("FEName").ToString()
            Dim MailTo = dt.Rows(0)("FEDutyEmail").ToString()
            Dim MainCC = dt.Rows(0)("PIEMail").ToString() + ";" + dt.Rows(0)("EquDutyEmail").ToString() + ";" + dt.Rows(0)("PDDutyEmail").ToString()
            Dim MailBody = "<p>尊敬的MES用户</p> 料号:" & partid & "已经生成BOF治具清单列表,详情请看邮件附档"
            MailBody += "<p>治具入库,请及时核对BOF治具数量,有问题及时反馈!</p><br/>"
            MailBody += "<table border='1'  cellspacing='0'>"
            MailBody += "<tr>"
            MailBody += "<td>版本</td><td>" & dt.Rows(0)("Version").ToString() & "</td>"
            MailBody += "</tr>"
            MailBody += "<tr>"
            MailBody += "<td>品名</td><td>" & dt.Rows(0)("ProductName").ToString() & "</td>"
            MailBody += "</tr>"
            MailBody += "<tr>"
            MailBody += "<td>规格</td><td>" & dt.Rows(0)("Description").ToString() & "</td>"
            MailBody += "</tr>"
            MailBody += "<tr>"
            MailBody += "<td>形态</td><td>" & dt.Rows(0)("Shape").ToString() & "</td>"
            MailBody += "</tr>"
            MailBody += "<tr>"
            MailBody += "<td>FE完成日期</td><td>" & Convert.ToDateTime(dt.Rows(0)("FETargetDate").ToString()).ToString("yyyy-MM-dd") & "</td>"
            MailBody += "</tr>"
            MailBody += "</table>"
            Dim sc = New SmtpClient()
            sc.EnableSsl = False
            sc.Credentials = New System.Net.NetworkCredential("sfc@it.luxshare-ict.com", "Share888")
            sc.Host = "192.168.20.40"
            sc.Port = 25
            Dim mm = New MailMessage()
            mm.From = New MailAddress("sfc@it.luxshare-ict.com")
            mm.Priority = MailPriority.High
            mm.Subject = "料号:" & partid & ",BOF治具清单审核完成,FE负责人通知"
            mm.Body = MailBody
            mm.IsBodyHtml = True
            mm.BodyEncoding = System.Text.Encoding.UTF8
            Dim MailToStr = MailTo.Split(";")
            For Each item As String In MailToStr
                mm.To.Add(item)
            Next

            For Each tempCC As String In MainCC.Split(";")
                If Not String.IsNullOrEmpty(tempCC) Then
                    mm.CC.Add(tempCC)
                End If
            Next

            mm.CC.Add("Chenqi.Chen@luxshare-ict.com")
            Dim FEDutyBossEmailStr = dt.Rows(0)("FEDutyBossEmail").ToString().Split(";")
            For Each item As String In FEDutyBossEmailStr
                If Not String.IsNullOrEmpty(item) Then
                    mm.CC.Add(item)
                End If
            Next

            mm.Headers.Add("X-Priority", "3")
            mm.Headers.Add("X-MSMail-Priority", "Normal")
            mm.Headers.Add("X-Mailer", "Microsoft Outlook Express 6.00.2900.2869")
            mm.Headers.Add("X-MimeOLE", "Produced By Microsoft MimeOLE V6.00.2900.2869")
            mm.Headers.Add("ReturnReceipt", "1")

            '1.txt;2.txt
            For Each o_tempFile As String In FileName.Split(";")
                If Not String.IsNullOrEmpty(o_tempFile) Then
                    mm.Attachments.Add(New Attachment(o_tempFile))
                End If
            Next

            sc.Send(mm)
            mm.Dispose()
        Catch ex As Exception
            Dim MainCC = "Chenqi.Chen@luxshare-ict.com;"
            Dim EmailTitle = "BOF治具清单审核完成发送邮件异常通知"
            MainFrame.MailUtils.SeedMail(MainCC, EmailTitle, ex.Message)
            Dim strErrFun As String = "SendEmail" + "'" & partid & "'"
            SysMessageClass.WriteErrLog(ex, "FrmBOFToolList", strErrFun, "RCard")
        End Try
    End Sub
#End Region


#Region "主表做流程判断的时候无刷新数据"
    ''' <summary>
    ''' 主表做流程判断的时候无刷新数据
    ''' </summary>
    ''' <param name="dgvr">DataGridView当前行数据</param>
    ''' <param name="status"></param>
    ''' <remarks></remarks>
    Private Sub ChangeStatus(ByVal dgvr As DataGridViewRow, ByVal status As String)
        If status = "2" Then
            dgvr.Cells("State").Value = 2
            dgvr.Cells("StateName").Value = "已完成"
        ElseIf status = "1" Then
            dgvr.Cells("State").Value = 1
            dgvMain.CurrentRow.Cells("StateName").Value = "待审核"
        ElseIf status = "0" Then
            dgvr.Cells("State").Value = 0
            dgvr.Cells("StateName").Value = "制作中"
        End If
    End Sub
#End Region

#Region "确认主表数据"
    ''' <summary>
    ''' 确认主表数据
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiHeadConfirm_Click(sender As Object, e As EventArgs) Handles tsmiHeadConfirm.Click
        Try
            If dgvMain.CurrentRow Is Nothing Then
                MessageUtils.ShowError("请选择一笔资料确认")
                Return
            End If
            Dim partid = dgvMain.CurrentRow.Cells("PartID").Value
            Dim State = dgvMain.CurrentRow.Cells("State").Value
            Dim Version As String = dgvMain.CurrentRow.Cells("Version").Value.ToString().Trim()
            If Convert.ToInt32(State) <> 0 Then
                MessageUtils.ShowError("只有制作中状态才能确认")
                Return
            End If
            Dim sql = "UPDATE m_BOFToolList_t set state='1' where partid=N'" & partid & "' and Version='" & Version & "'"
            DbOperateUtils.ExecSQL(sql)
            MessageUtils.ShowInformation("确认成功")
            ChangeStatus(dgvMain.CurrentRow, "1")
        Catch ex As Exception
            MessageUtils.ShowError("确认出错:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "驳回主表数据"
    ''' <summary>
    ''' 驳回主表数据
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiHeadReject_Click(sender As Object, e As EventArgs) Handles tsmiHeadReject.Click
        Try
            If dgvMain.CurrentRow Is Nothing Then
                MessageUtils.ShowError("请选择一笔资料驳回")
                Return
            End If
            Dim partid = dgvMain.CurrentRow.Cells("PartID").Value
            Dim Version As String = dgvMain.CurrentRow.Cells("Version").Value.ToString().Trim()

            Dim dr = MessageUtils.ShowConfirm("确认要驳回料号:" & partid & "的数据吗?", MessageBoxButtons.OKCancel)
            If dr = Windows.Forms.DialogResult.OK Then
                Dim sql = "update m_BOFToolList_t set state='0',FESchedule='X' where partid=N'" & partid & "'and Version='" & Version & "'"
                ' N'X.进行中', N'Y.已完成'
                DbOperateUtils.ExecSQL(sql)
                MessageUtils.ShowInformation("驳回成功")
                ChangeStatus(dgvMain.CurrentRow, "0")
            End If
        Catch ex As Exception
            MessageUtils.ShowError("驳回出错:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "只有制作中的数据才可以新增,编辑,删除"
    ''' <summary>
    ''' 只有制作中的数据才可以新增,编辑,删除
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsValiteOperation() As Boolean
        If Convert.ToInt32(dgvMain.CurrentRow.Cells("State").Value <> 0) Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region

#Region "BOF清单单头查询功能"
    ''' <summary>
    ''' BOF清单单头查询功能
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiHeaderSearch_Click(sender As Object, e As EventArgs) Handles tsmiHeaderSearch.Click
        Dim frm = New FrmBOFToolListSearch()
        Dim dr = frm.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            bindMain(frm.Where)
            m_strWhere = frm.Where
        End If
    End Sub
#End Region

#Region "刷新"
    ''' <summary>
    ''' 刷新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        bindMain("")
    End Sub
#End Region

#Region "查看变更履历"
    ''' <summary>
    ''' 查看变更履历
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolExportChangeLog_Click(sender As Object, e As EventArgs) Handles toolExportChangeLog.Click
        Dim frm = New BOFToolListMainLog()
        frm.ShowDialog()
    End Sub
#End Region

#Region "导出单头"
    ''' <summary>
    ''' 导出单头
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExportHeader_Click(sender As Object, e As EventArgs) Handles btnExportHeader.Click
        If dgvMain.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一笔OBF主档资料")
            Exit Sub
        End If

        Dim sql = "select DocID,PartID,CustName,Version,ProductName,[Description]" & vbCrLf &
        ",Shape,PIEName,FEName,FESchedule,InTime,DeviceToal,FixturesToal" & vbCrLf &
        ",AllTotal,StateName from V_m_BOFToolList_t"
        Dim dt = DbOperateUtils.GetDataTable(sql + m_strWhere)

        ' Dim dt As DataTable = dgvMain.DataSource


        Dim ay() = {"文件编号", "料号", "客户", "版本", "品名", "描述", "形态", "PIE", "FE", "治具进度", "时间", "设备总额", "治具总额", "总额", "状态"}
        VbCommClass.NPOIExcle.DataTableExportToExcle(dt, ay, String.Format("OBF清单{0}.xls", Date.Now.ToString("yyyyMMdd")))
    End Sub
#End Region

#Region "单头变更记录"
    ''' <summary>
    ''' 单头变更记录
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiChangeLog_Click(sender As Object, e As EventArgs) Handles tsmiChangeLog.Click
        If dgvMain.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行料号数据!")
            Exit Sub
        End If
        Dim frm = New BOFToolListMainLog()
        frm.MyPartID = dgvMain.CurrentRow.Cells("PartID").Value
        frm.ShowDialog()
    End Sub
#End Region

#Region "工站变更记录"
    ''' <summary>
    ''' 工站变更记录
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiStationChangeLog_Click(sender As Object, e As EventArgs) Handles tsmiStationChangeLog.Click
        If dgvDetail.SelectedRows.Count = 0 Then
            MessageUtils.ShowError("请选中一笔工站资料")
            Exit Sub
        End If
        Dim frm = New BOFToolListMainLog()
        frm.MyPartID = dgvMain.CurrentRow.Cells("PartID").Value
        frm.MyStationName = dgvDetail.CurrentRow.Cells("StationName").Value
        frm.ShowDialog()
    End Sub
#End Region

#Region "单头批量审核"
    ''' <summary>
    ''' 单头批量审核
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAudit_Click(sender As Object, e As EventArgs) Handles btnAudit.Click
        Try
            Dim list = GetCheckPartIDList()
            If list.Count = 0 Then
                MessageUtils.ShowError("请勾选一个料号的数据!")
                Exit Sub
            ElseIf AuditingDataIsOk(list) = False Then
                Exit Sub
            End If
            Dim listDgvr = New List(Of DataGridViewRow)
            Dim sql = New System.Text.StringBuilder()
            For Each dgvr As DataGridViewRow In dgvMain.Rows
                Dim BoolValue = Convert.ToBoolean(dgvr.Cells("ColChk").FormattedValue)
                If BoolValue = True Then
                    Dim PartID = dgvr.Cells("PartID").Value.ToString()
                    Dim BOFVersion As String = dgvr.Cells("Version").Value.ToString()
                    Dim DocID = dgvr.Cells("DocID").Value.ToString()
                    Dim BOFFile As String = dgvr.Cells("BOFFile").Value.ToString()
                    sql.AppendLine(String.Format("UPDATE m_BOFToolList_t SET state='2' WHERE partid=N'{0}' and DocID='{1}'", PartID, DocID))
                    listDgvr.Add(dgvr)
                    Dim FilePath = Application.StartupPath + "\" + Replace(PartID, "/", "_") & "-" & "治具BOF清单.xls"
                    CreateXls(FilePath, PartID, BOFVersion)

                    FilePath = FilePath + ";" + BOFFile
                    SendEmailAndAttachment(FilePath, PartID, BOFVersion)
                    If System.IO.File.Exists(FilePath) Then
                        System.IO.File.Delete(FilePath)
                    End If
                End If
            Next

            Try
                DbOperateUtils.ExecSQL(sql.ToString())
            Catch ex As Exception
                Throw ex
            End Try

            For Each dgvr As DataGridViewRow In listDgvr
                ChangeStatus(dgvr, "2")
            Next

            MessageUtils.ShowInformation("审核成功!")


        Catch ex As Exception
            Throw ex
            MessageUtils.ShowError("审核出现异常:" & vbCrLf & "" + ex.Message)

        End Try

    End Sub
#End Region

#Region "检查所勾选的数据全部数据是否符合审核"
    ''' <summary>
    ''' 检查所勾选的数据全部数据是否符合审核
    ''' </summary>
    ''' <param name="list">勾选的数据源</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AuditingDataIsOk(ByVal list As List(Of String))
        Dim yy = True
        For Each strItem As String In list
            Dim sql = "select * from  m_BOFToolList_t" & vbCrLf &
            "where [State]='1' and PartID=N'" & strItem & "'"
            Dim dt = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count = 0 Then
                yy = False
                MessageUtils.ShowError("料号:" + strItem + ",不是待审核状态,不能审核,请取消勾选!")
                Exit For
            End If
        Next
        Return yy
    End Function
#End Region

#Region "检查所勾选的数据全部数据是否已经完成状态"
    ''' <summary>
    ''' 检查所勾选的数据全部数据是否已经完成状态
    ''' </summary>
    ''' <param name="list"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckDataIsComplete(ByVal list As List(Of String)) As Boolean
        Dim yy = True
        For Each strItem As String In list
            Dim sql = "select * from  m_BOFToolList_t" & vbCrLf &
            "where [State]='2' and PartID=N'" & strItem & "'"
            Dim dt = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count = 0 Then
                yy = False
                MessageUtils.ShowError("料号:" + strItem + ",非完成状态，不允许打印输出，请找工程处理!")
                Exit For
            End If
        Next
        Return yy
    End Function
#End Region

#Region "获取勾选的料号集合"
    ''' <summary>
    ''' 获取勾选的料号集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCheckPartIDList() As List(Of String)
        Dim list = New List(Of String)
        For Each dgvr As DataGridViewRow In dgvMain.Rows
            Dim BoolValue = Convert.ToBoolean(dgvr.Cells("ColChk").FormattedValue)
            If BoolValue = True Then
                list.Add(dgvr.Cells("PartID").Value.ToString())
            End If
        Next
        Return list
    End Function
#End Region

#Region "全选"
    ''' <summary>
    ''' 全选
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAll.CheckedChanged
        Dim chk = ChkAll.Checked
        For Each dgvr As DataGridViewRow In dgvMain.Rows
            dgvr.Cells("ColChk").Value = chk
        Next
    End Sub
#End Region

#Region "单头单元格点击事件"
    ''' <summary>
    ''' 单头单元格点击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvMain_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMain.CellClick
        If dgvMain.Columns(e.ColumnIndex).Name = "ColChk" Then
            Dim BoolValue = dgvMain.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue
            dgvMain.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = IIf(BoolValue, False, True)
        End If
    End Sub
#End Region

#Region "打印"
    ''' <summary>
    ''' 打印
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim PartIDList = GetCheckPartIDList()
        If PartIDList.Count = 0 Then
            MessageUtils.ShowError("请勾选一个料号的数据!")
            Exit Sub
        ElseIf CheckDataIsComplete(PartIDList) = False Then
            Exit Sub
        End If
        Dim frm = New FrmPrint()
        For Each PartID As String In PartIDList
            Dim FilePath = Application.StartupPath + "\" + Replace(PartID, "/", "_") & "-" & "治具BOF清单.xls"
            CreateXls(FilePath, PartID, "")
            frm.FilePathList.Add(FilePath)
        Next
        frm.ShowDialog()
    End Sub
#End Region

#Region "BOF复制"
    ''' <summary>
    ''' BOF复制
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        If dgvMain.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行料号数据!")
            Exit Sub
        End If
        Dim frm = New FrmBOFToolListCopy()
        frm.txtOldPartID.Text = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
        Dim dr = frm.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            MessageUtils.ShowInformation("复制成功")
            bindMain("")
        End If
    End Sub
#End Region

#Region "插入工站"
    ''' <summary>
    ''' 插入工站
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiInsertStation_Click(sender As Object, e As EventArgs) Handles tsmiInsertStation.Click
        If dgvMain.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选一笔BOF主档料号资料")
            Exit Sub
        ElseIf dgvDetail.SelectedRows.Count = 0 Then
            MessageUtils.ShowError("请选中一笔工站资料")
            Exit Sub
        End If
        If IsValiteOperation() = False Then
            MessageUtils.ShowError("只有制作中的数据才可以操作")
            Exit Sub
        End If
        Dim partID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
        Dim Version = dgvMain.CurrentRow.Cells("Version").Value.ToString()
        Dim Detail = New FrmAddBOFToolListDetail()
        Detail.OP = "Insert"
        Detail.OrderBy = dgvDetail.CurrentRow.Cells("OrderBy").Value.ToString()
        Detail.PartID = partID
        Detail.BOFVersion = Version
        Detail.ShowDialog()
        bindDetail()
        dgvDetail.ClearSelection()
        bindEquiment(partID, "", "")
        setMainTotal()
    End Sub
#End Region

#Region "复制工站 "
    ''' <summary>
    '''复制工站 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiCopyStation_Click(sender As Object, e As EventArgs) Handles tsmiCopyStation.Click
        If dgvMain.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选一笔BOF主档料号资料")
            Exit Sub
        ElseIf dgvDetail.SelectedRows.Count = 0 Then
            MessageUtils.ShowError("请选中一笔工站资料")
            Exit Sub
        End If
        If IsValiteOperation() = False Then
            MessageUtils.ShowError("只有制作中的数据才可以操作")
            Exit Sub
        End If
        Dim frm = New BOFToolListDetailCopy()
        frm.MyPartID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
        frm.MyOrderBy = dgvDetail.CurrentRow.Cells("OrderBy").Value.ToString()
        frm.MyStationID = dgvDetail.CurrentRow.Cells("Stationid").Value.ToString()
        frm.txtOldStationName.Text = dgvDetail.CurrentRow.Cells("StationName").Value.ToString()
        Dim dr = frm.ShowDialog()
        bindDetail()
        dgvDetail.ClearSelection()
        bindEquiment(frm.MyPartID, "", "")
        setMainTotal()
    End Sub
#End Region

#Region "治具进度变更成完成状态"
    ''' <summary>
    ''' 治具进度变更成完成状态
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiFESchedule_Click(sender As Object, e As EventArgs) Handles tsmiFESchedule.Click
        Try
            If dgvMain.CurrentRow Is Nothing Then
                MessageUtils.ShowError("请选择一笔资料!")
                Return
            End If
            Dim PartID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
            Dim BOFVersion As String = dgvMain.CurrentRow.Cells("Version").Value.ToString()
            Dim BOFFile As String = dgvMain.CurrentRow.Cells("BOFFile").Value.ToString()
            Dim sql = New System.Text.StringBuilder()
            sql.AppendLine("update m_BOFToolList_t set FESchedule='Y' where PartID=N'" & PartID & "' and Version='" & BOFVersion & "'")
            sql.AppendLine("update m_BOFToolListDEquiment_t set FESchedule='Y' where PartID=N'" & PartID & "' and BOFVersion='" & BOFVersion & "'")
            dgvMain.CurrentRow.Cells("FESchedule").Value = "已完成"
            For Each dgvr As DataGridViewRow In dgvEquiment.Rows
                dgvr.Cells("FEScheduleE").Value = "已完成"
            Next
            DbOperateUtils.ExecSQL(sql.ToString())
            MessageUtils.ShowInformation("治具进度变更完成状态OK!")
            Dim frm = New FrmEmployeeOnJob()
            frm._PartID = PartID
            frm._BOFVersion = BOFVersion
            frm._BOFFile = BOFFile
            frm.ShowDialog()
        Catch ex As Exception
            MessageUtils.ShowError("发生异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "治具进度单项进度完成"
    ''' <summary>
    ''' 治具进度单项进度完成
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiFEScheduleItem_Click(sender As Object, e As EventArgs) Handles tsmiFEScheduleItem.Click
        Try
            If dgvEquiment.SelectedRows.Count = 0 Then
                MessageUtils.ShowError("请选择一行设备数据!")
                Exit Sub
            End If
            Dim partid = dgvMain.CurrentRow.Cells("PartID").Value.ToString()
            Dim BOFVersion As String = dgvMain.CurrentRow.Cells("Version").Value.ToString()
            Dim BOFFile As String = dgvMain.CurrentRow.Cells("BOFFile").Value.ToString()
            Dim ID = dgvEquiment.SelectedRows(0).Cells("ID").Value.ToString()
            DbOperateUtils.ExecSQL("update m_BOFToolListDEquiment_t set FESchedule='Y' where ID=" + ID)
            Dim sql = "select * from m_BOFToolListDEquiment_t where PartID=N'" & partid & "' and FESchedule='X'"
            '说明所有的明细项的治具进度全部变更成已完成状态
            If DbOperateUtils.GetDataTable(sql).Rows.Count = 0 Then
                DbOperateUtils.ExecSQL("UPDATE m_BOFToolList_t set FESchedule='Y' where PartID=N'" & partid & "' and Version='" & BOFVersion & "'")
                dgvMain.CurrentRow.Cells("FESchedule").Value = "已完成"
                Dim frm = New FrmEmployeeOnJob()
                frm._PartID = partid
                frm._BOFVersion = BOFVersion
                frm._BOFFile = BOFFile
                frm.ShowDialog()
            End If
            MessageUtils.ShowInformation("设备及治具单项进度变更成功!")
            bindEquiment(partid, "", "", BOFVersion)
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class