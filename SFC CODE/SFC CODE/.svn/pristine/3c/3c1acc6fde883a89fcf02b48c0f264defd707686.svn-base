Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData
Imports Aspose.Cells
Imports System.IO
Imports MainFrame.SysDataHandle



Public Class FrmStandardJobScheduling
    Sub New()
        InitializeComponent()
        Dim UserID As String = VbCommClass.VbCommClass.UseId

        'For Each tsi As ToolStripItem In cmsMain.Items
        '    If Not tsi.Tag Is Nothing Then
        '        If String.IsNullOrEmpty(tsi.Tag.ToString()) = False Then
        '            Dim sql = "select Tkey from dbo.m_UserRight_t" & vbCrLf &
        '            "where Tkey in" & vbCrLf &
        '            "(" & vbCrLf &
        '            "select Tkey from dbo.m_Logtree_t" & vbCrLf &
        '            "where Tkey='M17014003_'" & vbCrLf &
        '            ") and UserID='" & UserID & "'"
        '            Dim yy = DbOperateUtils.GetDataTable(sql).Rows.Count
        '            tsi.Enabled = IIf(yy > 0, True, False)
        '        End If
        '    End If
        'Next




        For Each contxt As ToolStripMenuItem In cmsMain.Items
            Dim sql = "select * from m_UserRight_t where UserID='" & UserID & "' and tkey=N'" & contxt.Tag & "'"
            If Not contxt.ToolTipText Is Nothing Then
                Dim dt = DbOperateUtils.GetDataTable(sql)
                contxt.Enabled = IIf(dt.Rows.Count > 0, True, False)
                If contxt.Tag = "M17014005_" AndAlso contxt.Enabled = True Then
                    m_blnHaveEditHeader = True
                End If
            End If
        Next


        For Each contxt As ToolStripMenuItem In cmsDetail.Items
            Dim sql = "select * from m_UserRight_t where UserID='" & UserID & "' and tkey=N'" & contxt.Tag & "'"
            If Not contxt.ToolTipText Is Nothing Then
                Dim dt = DbOperateUtils.GetDataTable(sql)
                contxt.Enabled = IIf(dt.Rows.Count > 0, True, False)
            End If
        Next


    End Sub

    Public m_blnHaveEditHeader As Boolean = False

    ''' <summary>
    ''' 打印导出模板地址
    ''' </summary>
    ''' <remarks></remarks>
    ''' Dim Ssql As String
    '''
    Dim FullPathFile As String = "\\192.168.20.123\SFCShare\File\产品制程标准排配导出打印模板\StandardJobScheduling.xls"

    Private Sub FrmStandardJobScheduling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindStatus()
        DataBindMain()
    End Sub

#Region "加载头部数据"
    ''' <summary>
    ''' 加载头部数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataBindMain()
        Dim strWhere = " and 1=1 "
        If String.IsNullOrEmpty(txtPartID.Text.Trim()) = False Then
            strWhere += " and a.PartID like '%" & txtPartID.Text.Trim() & "%'"
        End If
        If String.IsNullOrEmpty(txtECNNO.Text.Trim()) = False Then
            strWhere += " and a.ECN_No like '%" & txtECNNO.Text.Trim() & "%'"
        End If
        If String.IsNullOrEmpty(ComboStatus.Text) = False Then
            strWhere += " and a.Status='" & ComboStatus.SelectedValue & "'"
        End If
        strWhere += " and a.FactNO='" & VbCommClass.VbCommClass.Factory & "'"
        strWhere += " and a.Profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'"
        strWhere += " order by [Status], isnull(a.ModifyTime,a.CreateTime) desc"
        Dim sql = "select top 100 a.ID,a.PartID, a.Version,a.FilePath,a.ECN_No,a.Remark," & vbCrLf &
        "substring(a.FilePath,len(a.FilePath)-charindex('\',reverse(a.FilePath))+2,len(a.FilePath)) as FileName," & vbCrLf &
        "case " & vbCrLf &
        "when [Status]=0 then N'制作中'" & vbCrLf &
        "when [Status]=1 then N'待审核'" & vbCrLf &
        "when [Status]=3 then N'待DCC审核'" & vbCrLf &
        "when [Status]=2 then N'已完成'" & vbCrLf &
        "end ZStatus,a.CreateName,a.CreateTime,a.ModifyName,a.ModifyTime" & vbCrLf &
        ",(select sum(isnull(BalancePerson,0)) from " & vbCrLf &
        "dbo.m_ProductStandardAllocationD_t where MainID=a.ID) TotalBalancePerson" & vbCrLf &
        "from m_ProductStandardAllocation_t a" & vbCrLf &
        "where a.Usey='Y'" & strWhere
        Dim dt = DbOperateUtils.GetDataTable(sql)
        dgvMain.AutoGenerateColumns = False
        dgvMain.DataSource = dt
        chkAll.Checked = False
    End Sub
#End Region

#Region "加载明细数据"
    ''' <summary>
    ''' 加载明细数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataBindDetail()
        Dim ID = dgvMain.CurrentRow.Cells("ID").Value.ToString()
        Dim sql = "select * from dbo.fun_m_ProductStandardAllocationD_t(" & ID & ",'R')" & vbCrLf &
        "union all" & vbCrLf &
        "select * from dbo.fun_m_ProductStandardAllocationD_t(" & ID & ",'U')"
        Dim dt = DbOperateUtils.GetDataTable(sql)
        dgvDetail.AutoGenerateColumns = False
        dgvDetail.DataSource = dt
    End Sub
#End Region

#Region "绑定状态"
    ''' <summary>
    ''' 绑定状态
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BindStatus()
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add(New DataColumn("ID"))
        dt.Columns.Add(New DataColumn("Name"))
        Dim dr As DataRow = dt.NewRow()
        dr(0) = "0"
        dr(1) = "制作中"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "1"
        dr(1) = "待审核"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "3"
        dr(1) = "待DCC审核"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "2"
        dr(1) = "已完成"
        dt.Rows.Add(dr)

        ComboStatus.DataSource = dt
        ComboStatus.ValueMember = "ID"
        ComboStatus.DisplayMember = "Name"

        ComboStatus.SelectedIndex = -1
    End Sub
#End Region

#Region "新增表头"
    ''' <summary>
    ''' 新增表头
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiAddMain_Click(sender As Object, e As EventArgs) Handles tsmiAddMain.Click
        Dim frm = New FrmStandardJobSchedulingAddMain()
        frm.OP = "Add"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            DataBindMain()
        End If
    End Sub
#End Region

#Region "获取选择行的ID标识"
    ''' <summary>
    ''' 获取选择行的ID标识
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMainID() As String
        Dim MainID As String = Nothing
        If Not dgvMain.CurrentRow Is Nothing Then
            MainID = dgvMain.CurrentRow.Cells("ID").Value.ToString()
        End If
        Return MainID
    End Function
#End Region

#Region "修改表头"
    ''' <summary>
    ''' 修改表头
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiEditMain_Click(sender As Object, e As EventArgs) Handles tsmiEditMain.Click
        Dim ID = GetMainID()
        If ID Is Nothing Then
            MessageUtils.ShowError("请选择一行数据!")
            Exit Sub
        End If
        Dim frm = New FrmStandardJobSchedulingAddMain()
        frm.OP = "Edit"
        frm.ID = ID
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            DataBindMain()
        End If
    End Sub
#End Region

#Region "确认表头"
    ''' <summary>
    ''' 确认表头
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiconfirmMain_Click(sender As Object, e As EventArgs) Handles tsmiconfirmMain.Click
        Try
            Dim ID = GetMainID()
            If ID Is Nothing Then
                MessageUtils.ShowError("请选择一行数据!")
                Exit Sub
            ElseIf Not dgvMain.CurrentRow.Cells("Status").Value.ToString() = "制作中" Then
                MessageUtils.ShowError("非制作中的机种,不可确认,请核实!")
                Exit Sub
            End If
            '1待审核 3待DCC审核
            subAsyncChangeStatus(1, ID)
            Dim EmailTo = ""
            Dim sql = "select PARAMETER_VALUES from m_SystemSetting_t" & vbCrLf &
            "where MODE_NAME='MES' and PARAMETER_CODE='StandardJobSchedulingToEmail'"
            Dim dt = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                EmailTo = dt.Rows(0)(0).ToString()
            End If
            Dim PartID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()

            If Not String.IsNullOrEmpty(EmailTo) Then
                MailUtils.SeedMail(EmailTo, "产品制程标准排配待审通知", "请负责人审核机种:" + PartID)
            End If

            MessageUtils.ShowInformation("确认成功!")
            DetailCmsDetailIsvalidated()
        Catch ex As Exception
            MessageUtils.ShowError("发生异常:" & vbCrLf & "" & ex.Message)
        End Try
    End Sub
#End Region

#Region "模拟ajax异步刷新当前行的状态栏位【0.制作中==》1.待审核（IE）==》3待DCC审核==》2.已完成】"
    ''' <summary>
    ''' 模拟ajax异步刷新当前行的状态栏位
    ''' </summary>
    ''' <param name="CurrentValue">当前值</param>
    ''' <param name="MainID">主键标识ID</param>
    ''' <remarks></remarks>
    Private Sub subAsyncChangeStatus(ByVal CurrentValue As String, ByVal MainID As String)
        Dim result = ""
        Select Case CurrentValue
            Case "0"
                result = "制作中"
            Case "1"
                result = "待审核"
            Case "3"
                result = "待DCC审核"
            Case "2"
                result = "已完成"
        End Select
        dgvMain.CurrentRow.Cells("Status").Value = result
        Dim sql = "update m_ProductStandardAllocation_t set Status='" & CurrentValue & "' where ID=" + MainID
        DbOperateUtils.ExecSQL(sql)
    End Sub
#End Region

#Region "审核表头"
    ''' <summary>
    ''' 审核表头
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiAuditingMain_Click(sender As Object, e As EventArgs) Handles tsmiAuditingMain.Click
        Dim _CurrStatus As String = Nothing
        Dim _NextStatus As String = Nothing
        Dim _NextStatusName As String = Nothing
        Try
            Dim ID = GetMainID()
            'If ID Is Nothing Then
            '    MessageUtils.ShowError("请选择一行数据!")
            '    Exit Sub
            'ElseIf Not dgvMain.CurrentRow.Cells("Status").Value.ToString() = "待审核" Then
            '    MessageUtils.ShowError("非待审核的机种,不可审核,请核实!")
            '    Exit Sub
            'End If

            If ID Is Nothing Then
                MessageUtils.ShowError("请选择一行数据!")
                Exit Sub
            End If

            _CurrStatus = dgvMain.CurrentRow.Cells("Status").Value.ToString().Trim()
            If _CurrStatus = "待审核" Then
                _NextStatusName = "待DCC审核"    '3待DCC审核
                _NextStatus = 3
            ElseIf _CurrStatus = "待DCC审核" Then
                _NextStatusName = "已完成"
                _NextStatus = 2
            Else
                MessageUtils.ShowError("非待审核的机种,不可审核,请核实!")
                Exit Sub
            End If

            'DCC审核 检查是否有权限
            If _NextStatusName = "已完成" Then
                Dim DCC_Checker = ""
                Dim sql = "select PARAMETER_VALUES from m_SystemSetting_t" & vbCrLf &
                "where MODE_NAME='MES' and PARAMETER_CODE='StandardJobSchedulingToEmailDCC'"
                Dim dt = DbOperateUtils.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    DCC_Checker = dt.Rows(0)(0).ToString().Split("|")(1)
                    If ("," + DCC_Checker.Trim.ToUpper + ",").IndexOf("," & VbCommClass.VbCommClass.UseId.Trim.ToUpper & ",") <= 0 Then
                        MessageUtils.ShowError("没有待DCC审核的权限,请核实!")
                        Exit Sub
                    End If
                End If
            End If

            '待审核==》待DCC审核  or 【待DCC审核==》已完成】
            subAsyncChangeStatus(_NextStatus, ID)

            '通知DCC审核
            If _NextStatusName = "待DCC审核" Then
                Dim EmailTo = ""
                Dim sql = "select PARAMETER_VALUES from m_SystemSetting_t" & vbCrLf &
                "where MODE_NAME='MES' and PARAMETER_CODE='StandardJobSchedulingToEmailDCC'"
                Dim dt = DbOperateUtils.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    EmailTo = dt.Rows(0)(0).ToString().Split("|")(0)
                End If
                Dim PartID = dgvMain.CurrentRow.Cells("PartID").Value.ToString()

                If Not String.IsNullOrEmpty(EmailTo) Then
                    MailUtils.SeedMail(EmailTo, "产品制程标准排配[待DCC审核]通知--" & PartID & "", "请负责人审核机种:" + PartID)
                End If
            End If

            MessageUtils.ShowInformation("审核成功!")
            DetailCmsDetailIsvalidated()
        Catch ex As Exception
            MessageUtils.ShowError("发生异常:" & vbCrLf & "" & ex.Message)
        End Try
    End Sub
#End Region

#Region "取消生效表头"
    ''' <summary>
    ''' 取消生效表头
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiCancelEffectMain_Click(sender As Object, e As EventArgs) Handles tsmiCancelEffectMain.Click
        Try
            Dim ID = GetMainID()
            If ID Is Nothing Then
                MessageUtils.ShowError("请选择一行数据!")
                Exit Sub
            End If
            Dim dr = MessageUtils.ShowConfirm("是否要取消生效该行数据?", MessageBoxButtons.OKCancel)
            If dr = Windows.Forms.DialogResult.OK Then
                subAsyncChangeStatus(0, ID)
                MessageUtils.ShowInformation("取消生效成功!")
                DetailCmsDetailIsvalidated()
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "作废表头"
    ''' <summary>
    ''' 作废表头
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiInvalidMain_Click(sender As Object, e As EventArgs) Handles tsmiInvalidMain.Click
        Try
            Dim ID = GetMainID()
            If ID Is Nothing Then
                MessageUtils.ShowError("请选择一行数据!")
                Exit Sub
            End If
            Dim dr = MessageUtils.ShowConfirm("是否要作废该行数据?", MessageBoxButtons.OKCancel)
            If dr = Windows.Forms.DialogResult.OK Then
                If dgvMain.CurrentRow.Cells("Status").Value.ToString() <> "制作中" Then
                    MessageUtils.ShowError("只有制作中的才能作废,如果要作废请先点击取消生效!")
                    Exit Sub
                End If

                Dim sql = New System.Text.StringBuilder()
                sql.AppendLine("delete m_ProductStandardAllocationD_t where MainID='" & ID & "'")
                sql.AppendLine("delete m_ProductStandardAllocation_t where id='" & ID & "'")
                DbOperateUtils.ExecSQL(sql.ToString())
                MessageUtils.ShowInformation("作废成功!")
                DataBindMain()
            End If
        Catch ex As Exception
            MessageUtils.ShowError("取消发生异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "打印"
    ''' <summary>
    ''' 打印
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiPrintMain_Click(sender As Object, e As EventArgs) Handles tsmiPrintMain.Click
        Try
            Dim ID = GetMainID()
            If ID Is Nothing Then
                MessageUtils.ShowError("请选择一行数据!")
                Exit Sub
            ElseIf Not dgvMain.CurrentRow.Cells("Status").Value.ToString() = "已完成" Then
                MessageUtils.ShowError("非已完成的机种,不可打印,请核实!")
                Exit Sub
            End If
            Dim dgvr As DataGridViewRow = dgvMain.CurrentRow
            Dim PartID = dgvr.Cells("PartID").Value.ToString()
            Dim Version = dgvr.Cells("Version").Value.ToString()

            Dim FullPathName = Application.StartupPath + "\" + Replace(PartID, "/", "_") + "-标准排配表" + Version + ".xls"
            CreateXls(FullPathName)
            Dim frm = New FrmPrint()
            frm.FilePathList.Add(FullPathName)
            frm.ShowDialog()
        Catch ex As Exception
            MessageUtils.ShowError("发生异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "导出"
    ''' <summary>
    ''' 导出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiExportMain_Click(sender As Object, e As EventArgs) Handles tsmiExportMain.Click
        Try
            Dim ID = GetMainID()
            Dim dgvr As DataGridViewRow = dgvMain.CurrentRow
            If ID Is Nothing Then
                MessageUtils.ShowError("请选择一行数据!")
                Exit Sub
                'ElseIf Not dgvr.Cells("Status").Value.ToString() = "已完成" Then
                '    MessageUtils.ShowError("非已完成的机种,不可导出,请核实!")
                '    Exit Sub
            End If
            Dim PartID = dgvr.Cells("PartID").Value.ToString()
            Dim Version = dgvr.Cells("Version").Value.ToString()

            SaveFileDialog1.Filter = "xls|.xls"
            SaveFileDialog1.InitialDirectory = True
            SaveFileDialog1.FileName = Replace(PartID, "/", "_") + "-标准排配表" + Version + ".xls"

            If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CreateXls(SaveFileDialog1.FileName)
                MessageUtils.ShowInformation("导出成功!")
                System.Diagnostics.Process.Start(SaveFileDialog1.FileName)
            End If
        Catch ex As Exception
            MessageUtils.ShowError("发生异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "版本列表"
    ''' <summary>
    ''' 版本列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function VersionArrayList() As List(Of String)
        Dim list = New List(Of String)
        list.Add("X")
        list.Add("A")
        list.Add("B")
        list.Add("C")
        list.Add("D")
        list.Add("E")
        list.Add("F")
        list.Add("G")
        list.Add("H")
        list.Add("I")
        list.Add("J")
        list.Add("K")
        list.Add("L")
        list.Add("M")
        list.Add("N")
        list.Add("O")
        list.Add("P")
        list.Add("Q")
        list.Add("R")
        list.Add("S")
        list.Add("T")
        list.Add("U")
        list.Add("V")
        list.Add("W")
        list.Add("Y")
        list.Add("Z")
        Return list
    End Function
#End Region

#Region "生成Xls文件"
    ''' <summary>
    ''' 生成Xls文件
    ''' </summary>
    ''' <param name="FullPathName">要生成的路径</param>
    ''' <remarks></remarks>
    Private Sub CreateXls(ByVal FullPathName As String)
        Dim TotalRowCount = 0 '记录流程工站和线外工站的总行数 
        Dim FilePath = dgvMain.CurrentRow.Cells("FilePath").Value.ToString()
        Dim Designer = New WorkbookDesigner()
        Dim Book = New Workbook(FullPathFile)
        Designer.Workbook = Book
        Dim ds = New DataSet()
        Dim dtMain = DbOperateUtils.GetDataTable("select * from m_ProductStandardAllocation_t where id=" + GetMainID())
        dtMain.TableName = "Main" '表头
        ds.Tables.Add(dtMain)
        Dim dtDetailR = DbOperateUtils.GetDataTable("select * from dbo.fun_m_ProductStandardAllocationD_t(" & GetMainID() & ",'R')")
        dtDetailR.TableName = "R" '表身流程工站
        If dtDetailR.Rows.Count > 0 Then
            TotalRowCount = dtDetailR.Rows.Count
        End If
        ds.Tables.Add(dtDetailR)
        Dim dtDetailU = DbOperateUtils.GetDataTable("select * from dbo.fun_m_ProductStandardAllocationD_t(" & GetMainID() & ",'U')")
        dtDetailU.TableName = "U" '表身线外工站
        If dtDetailU.Rows.Count > 0 Then
            TotalRowCount = TotalRowCount + dtDetailU.Rows.Count
        Else '没有线外工站默认空一行
            TotalRowCount = TotalRowCount + 1
        End If
        ds.Tables.Add(dtDetailU)
        Designer.SetDataSource(ds)

        '产品制程标准排配负责人
        Dim FuZeRen = ""
        Dim XiuDingTime = ""
        If dtMain.Rows.Count > 0 Then
            FuZeRen = IIf(String.IsNullOrEmpty(dtMain.Rows(0)("ModifyName").ToString()), dtMain.Rows(0)("CreateName").ToString(), dtMain.Rows(0)("ModifyName").ToString())
            If String.IsNullOrEmpty(dtMain.Rows(0)("ModifyTime").ToString()) Then
                XiuDingTime = Convert.ToDateTime(dtMain.Rows(0)("CreateTime").ToString()).ToString("yyyy/MM/dd")
            Else
                XiuDingTime = Convert.ToDateTime(dtMain.Rows(0)("ModifyTime").ToString()).ToString("yyyy/MM/dd")
            End If
        End If

        Dim Version = ""
        If dtMain.Rows.Count > 0 Then
            Version = dtMain.Rows(0)("Version").ToString()
        End If

        Dim VersionIndex As Integer = 0

        For i As Integer = 0 To VersionArrayList().Count - 1
            If Version.ToUpper().Contains(VersionArrayList()(i)) Then
                VersionIndex = i
                Exit For
            End If
        Next



        Dim dics = New Dictionary(Of String, String)()
        dics.Add("Revise", FuZeRen & vbCrLf & XiuDingTime & "")
        dics.Add("VersionOne", VersionArrayList()(VersionIndex + 1))
        dics.Add("VersionTwo", VersionArrayList()(VersionIndex + 2))
        dics.Add("VersionThree", VersionArrayList()(VersionIndex + 3))
        dics.Add("VersionFour", VersionArrayList()(VersionIndex + 4))
        dics.Add("VersionFive", VersionArrayList()(VersionIndex + 5))
        For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
            Designer.SetDataSource(dic.Key, dic.Value)
        Next
        Designer.Process()

        Dim Sheet = Book.Worksheets(0)
        '有上传图片
        If String.IsNullOrEmpty(FilePath) = False Then

            TotalRowCount = IIf(TotalRowCount = 0, 1, TotalRowCount) '没有数据就默认空1行
            Dim PictureIndex = Sheet.Pictures.Add(12 + TotalRowCount, 8, FilePath)
            Dim Picture = Sheet.Pictures(PictureIndex)
            Picture.Top = 20
            Picture.Left = 10
            Picture.Width = 410
            Picture.Height = 270
        End If

        Dim list = New List(Of String)

        '流程工站公式
        For i As Integer = 0 To dtDetailR.Rows.Count - 1

            Dim OrderBy As String = Sheet.Cells(i + 4, 0).Value.ToString()

            '合并数据 add by 马跃平 2018-11-19
            Dim sql = "select sum(SWorkingHours) SWorkingHours,sum(OutPut) OutPut,sum(BalancePerson) as BalancePerson," & vbCrLf &
            "cast(sum(SWorkingHours)/ isnull(sum(BalancePerson),1) as decimal(18,1)) as BalanceHours," & vbCrLf &
            "cast(3600/(cast(sum(SWorkingHours)/ isnull(sum(BalancePerson),1) as decimal(18,1)))as decimal(18,1)) as BalanceQty" & vbCrLf &
            "from m_ProductStandardAllocationD_t" & vbCrLf &
            "where MainID = " & GetMainID() & "" & vbCrLf &
            "and OrderBy in " & vbCrLf &
            "(" & vbCrLf &
            "select cast(CellMergingOrderBy as varchar) " & vbCrLf &
            "from m_ProductStandardAllocationDMerging_t" & vbCrLf &
            "where MainID = " & GetMainID() & " And OrderBy = '" & OrderBy & "'" & vbCrLf &
            ") or (OrderBy='" & OrderBy & "' and MainID=" & GetMainID() & ")"
            Dim dt = DbOperateUtils.GetDataTable(sql)
            '汇总要合并单元格的值
            If dt.Rows.Count > 0 Then
                If String.IsNullOrEmpty(dt.Rows(0)("BalancePerson").ToString()) = False Then
                    'Sheet.Cells(i + 4, 2).Value = Convert.ToDouble(dt.Rows(0)("SWorkingHours").ToString()) '2019-03-22张永康提出合并数据后,标准工时不变,平衡工时和平衡产量合并
                    Sheet.Cells(i + 4, 4).Value = Convert.ToDouble(dt.Rows(0)("OutPut").ToString())
                    Sheet.Cells(i + 4, 8).Value = Convert.ToDouble(dt.Rows(0)("BalancePerson").ToString())
                    Dim BalanceHours = dt.Rows(0)("BalanceHours").ToString().Trim()
                    Dim BalanceQty = dt.Rows(0)("BalanceQty").ToString().Trim()
                    If String.IsNullOrEmpty(BalanceHours) = False Then
                        Sheet.Cells(i + 4, 9).Value = Convert.ToDouble(BalanceHours)
                    End If
                    If String.IsNullOrEmpty(BalanceQty) = False Then
                        Sheet.Cells(i + 4, 10).Value = Convert.ToDouble(BalanceQty)
                    End If
                End If
            End If
            '清空被合并单元格的值
            If DbOperateUtils.GetDataTable("select * from m_ProductStandardAllocationDMerging_t where MainID=" & GetMainID() & " and CellMergingOrderBy='" & OrderBy & "'").Rows.Count > 0 Then
                'Sheet.Cells(i + 4, 2).Value = Nothing '2019-03-22张永康提出合并数据后,标准工时不变,平衡工时和平衡产量合并
                Sheet.Cells(i + 4, 4).Value = Nothing
                Sheet.Cells(i + 4, 8).Value = Nothing
                Sheet.Cells(i + 4, 9).Value = Nothing
                Sheet.Cells(i + 4, 10).Value = Nothing
            Else
                '导出Excel附带计算公式
                Sheet.Cells(i + 4, 4).Formula = "=SUM(3600/" & Sheet.Cells(i + 4, 2).Name & ")"

                Dim dtCellMerging = DbOperateUtils.GetDataTable("select * from m_ProductStandardAllocationDMerging_t where MainID=" & GetMainID() & " and OrderBy=" & OrderBy & " ")

                '2019-03-22张永康提出合并数据后,标准工时不变,平衡工时和平衡产量合并
                If String.IsNullOrEmpty(Sheet.Cells(i + 4, 8).Value) = False And dtCellMerging.Rows.Count = 0 Then
                    Sheet.Cells(i + 4, 9).Formula = "=SUM(" & Sheet.Cells(i + 4, 2).Name & "/" & Sheet.Cells(i + 4, 8).Name & ")"
                    Sheet.Cells(i + 4, 10).Formula = "=SUM(3600/" & Sheet.Cells(i + 4, 9).Name & ")"
                End If
            End If
        Next
        '线外工站公式
        For i As Integer = 0 To dtDetailU.Rows.Count - 1
            Sheet.Cells(i + 7 + dtDetailR.Rows.Count, 4).Formula = "=SUM(3600/" & Sheet.Cells(i + 7 + dtDetailR.Rows.Count, 2).Name & ")"
            If Not Sheet.Cells(i + 7 + dtDetailR.Rows.Count, 8).Value Is Nothing Then
                Sheet.Cells(i + 7 + dtDetailR.Rows.Count, 9).Formula = "=SUM(" & Sheet.Cells(i + 7 + dtDetailR.Rows.Count, 2).Name & "/" & Sheet.Cells(i + 7 + dtDetailR.Rows.Count, 8).Name & ")"
                Sheet.Cells(i + 7 + dtDetailR.Rows.Count, 10).Formula = "=SUM(3600/" & Sheet.Cells(i + 7 + dtDetailR.Rows.Count, 9).Name & ")"
            End If
        Next


        Book.CalculateFormula(True)
        Designer.Workbook.Save(FullPathName)

    End Sub
#End Region

#Region "新增表身"
    ''' <summary>
    ''' 新增表身
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiAddDetail_Click(sender As Object, e As EventArgs) Handles tsmiAddDetail.Click
        Try
            Dim ID = GetMainID()
            If ID Is Nothing Then
                MessageUtils.ShowError("请选择一行料号数据!")
                Exit Sub
            End If
            Dim frm = New FrmStandardJobSchedulingAddDetails()
            frm.MainID = ID
            frm.OP = "Add"
            frm.ShowDialog()
            DataBindDetail()
            ClacTotalBalancePerson()
        Catch ex As Exception
            MessageUtils.ShowError("发生异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "修改表身"
    ''' <summary>
    ''' 修改表身
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiEditDetail_Click(sender As Object, e As EventArgs) Handles tsmiEditDetail.Click
        Dim ID = GetMainID()
        If ID Is Nothing Then
            MessageUtils.ShowError("请选择一行料号数据!")
            Exit Sub
        End If
        If dgvDetail.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行工站数据!")
            Exit Sub
        End If
        Dim frm = New FrmStandardJobSchedulingAddDetails()
        frm.OP = "Edit"
        frm.MainID = ID
        frm.DetailID = dgvDetail.CurrentRow.Cells("DetailID").Value.ToString()

        Dim StationType = ""
        If dgvDetail.CurrentRow.Cells("StationType").Value = "流程工站" Then
            StationType = "R"
        ElseIf dgvDetail.CurrentRow.Cells("StationType").Value = "线外工站" Then
            StationType = "U"
        End If
        frm.OrderBy = dgvDetail.CurrentRow.Cells("OrderBy").Value.ToString()
        frm.StationType = StationType
        Dim dr = frm.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            DataBindDetail()
            ClacTotalBalancePerson()
        End If
    End Sub
#End Region

#Region "删除表身"
    Private Sub tsmiDeteleDetail_Click(sender As Object, e As EventArgs) Handles tsmiDeteleDetail.Click
        Try
            Dim ID = GetMainID()
            If ID Is Nothing Then
                MessageUtils.ShowError("请选择一行料号数据!")
                Exit Sub
            End If
            If dgvDetail.CurrentRow Is Nothing Then
                MessageUtils.ShowError("请选择一行工单数据!")
                Exit Sub
            End If
            Dim DetailID = dgvDetail.CurrentRow.Cells("DetailID").Value.ToString()
            Dim StationType = ""
            If dgvDetail.CurrentRow.Cells("StationType").Value = "流程工站" Then
                StationType = "R"
            ElseIf dgvDetail.CurrentRow.Cells("StationType").Value = "线外工站" Then
                StationType = "U"
            End If
            Dim EmpNO = VbCommClass.VbCommClass.UseId
            Dim EmpName = VbCommClass.VbCommClass.UseName
            Dim OrderBy = dgvDetail.CurrentRow.Cells("OrderBy").Value.ToString()
            Dim dr = MessageUtils.ShowConfirm("是否要删除该行的工站资料?", MessageBoxButtons.OKCancel)
            If dr = Windows.Forms.DialogResult.OK Then
                Dim sql = "exec Proc_ModifyProductStandardAllocationD 'Delete'," & ID & "," & DetailID & ",'" & StationType & "','" & OrderBy & "','','','" & EmpNO & "',N'" & EmpName & "'"
                DbOperateUtils.ExecSQL(sql)
                DataBindDetail()
                ClacTotalBalancePerson()
            End If
        Catch ex As Exception
            MessageUtils.ShowError("发生异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub
#End Region

#Region "查询"
    ''' <summary>
    ''' 查询
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        DataBindMain()
    End Sub
#End Region

#Region "表头单元格双击事件"
    ''' <summary>
    ''' 表头单元格双击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvMain_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMain.CellDoubleClick
        If dgvMain.Columns(e.ColumnIndex).Name = "FileName" Then
            Dim dgvr = dgvMain.Rows(e.RowIndex)
            Dim FilePath = dgvr.Cells("FilePath").Value.ToString().Trim()
            If String.IsNullOrEmpty(FilePath) = False Then
                System.Diagnostics.Process.Start(FilePath)
            End If
        End If
    End Sub
#End Region

#Region "表头所选内容发生变更时事件"
    ''' <summary>
    ''' 表头所选内容发生变更时事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvMain_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMain.SelectionChanged
        Try
            DataBindDetail()
            DetailCmsDetailIsvalidated()
        Catch ex As Exception
            MessageUtils.ShowError("发生异常:" & vbCrLf & "" & ex.Message)
        End Try
    End Sub
#End Region

#Region "表身右键快捷键是否可用"
    ''' <summary>
    ''' 表身右键快捷键是否可用
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DetailCmsDetailIsvalidated()
        Dim ID = GetMainID()
        Dim yy As Boolean = True
        Dim sql = "select Status from m_ProductStandardAllocation_t where ID=" + ID
        Dim dt = DbOperateUtils.GetDataTable(sql)
        If ID Is Nothing Then
            yy = False
        ElseIf dt.Rows.Count > 0 Then
            If dt.Rows(0)(0).ToString() <> "0" Then
                yy = False
            End If
        End If
        cmsDetail.Enabled = yy
        dgvDetail.ReadOnly = IIf(yy, False, True)
        If yy = True AndAlso m_blnHaveEditHeader = True Then
            tsmiEditMain.Enabled = yy
        Else
            tsmiEditMain.Enabled = False
        End If
    End Sub
#End Region

#Region "清空查询条件"
    ''' <summary>
    ''' 清空查询条件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtPartID.Text = Nothing
        txtECNNO.Text = Nothing
    End Sub
#End Region

#Region "表身在选中行插入一个工站"
    ''' <summary>
    ''' 表身在选中行插入一个工站
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiChaRu_Click(sender As Object, e As EventArgs) Handles tsmiChaRu.Click
        Dim ID = GetMainID()
        If ID Is Nothing Then
            MessageUtils.ShowError("请选择一行料号数据!")
            Exit Sub
        End If
        If dgvDetail.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行工站数据!")
            Exit Sub
        End If
        Dim DetailID = dgvDetail.CurrentRow.Cells("DetailID").Value.ToString()

        Dim StationType = ""
        If dgvDetail.CurrentRow.Cells("StationType").Value = "流程工站" Then
            StationType = "R"
        ElseIf dgvDetail.CurrentRow.Cells("StationType").Value = "线外工站" Then
            StationType = "U"
        End If

        Dim OrderBy = dgvDetail.CurrentRow.Cells("OrderBy").Value.ToString()

        Dim frm = New FrmStandardJobSchedulingAddDetails()
        frm.OP = "Insert"
        frm.MainID = ID
        frm.DetailID = DetailID
        frm.OrderBy = OrderBy
        frm.StationType = StationType
        Dim dr = frm.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            DataBindDetail()
            ClacTotalBalancePerson()
        End If
    End Sub
#End Region

#Region "退出"
    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub
#End Region

    Dim RowIndex As Integer = 0
    Dim ColumnIndex As Integer = 0

#Region "表身单元格结束编辑事件"
    ''' <summary>
    ''' 表身单元格结束编辑事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvDetail_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellEndEdit
        Dim DetailID = dgvDetail.Rows(RowIndex).Cells("DetailID").Value.ToString()
        Dim UserID = VbCommClass.VbCommClass.UseId
        Dim UserName = VbCommClass.VbCommClass.UseName
        Dim a As Double = 0
        If dgvDetail.Columns(ColumnIndex).Name = "BalancePerson" Then
            Dim BalancePerson = dgvDetail.Rows(RowIndex).Cells("BalancePerson").Value.ToString().Trim()
            Dim SWorkingHours = dgvDetail.Rows(RowIndex).Cells("SWorkingHours").Value.ToString()
            If String.IsNullOrEmpty(SWorkingHours) Then
                dgvDetail.Rows(RowIndex).Cells("BalancePerson").Value = Nothing
                MessageUtils.ShowError("请确认选择行的标准工时是否有输入值!")
                Exit Sub
            End If
            If String.IsNullOrEmpty(BalancePerson) = False Then
                If Double.TryParse(BalancePerson, a) = True Then
                    If Double.Parse(BalancePerson) < 0 Then
                        MessageUtils.ShowError("平衡人力必须大于0!")
                        dgvDetail.Rows(RowIndex).Cells("BalancePerson").Value = Nothing
                        Exit Sub
                    End If
                    If Double.Parse(BalancePerson) < 1 And Double.Parse(BalancePerson) > 0 Then
                        If BalancePerson <> "0.5" Then
                            MessageUtils.ShowError("平衡人力输入小于1的数字只能输入0.5")
                            dgvDetail.Rows(RowIndex).Cells("BalancePerson").Value = Nothing
                            Exit Sub
                        End If
                    End If
                    Dim BalanceHours = ""
                    If BalancePerson <> "0" And BalancePerson <> "0.0" Then
                        BalanceHours = String.Format("{0:0.0}", Double.Parse(SWorkingHours) / Convert.ToDouble(BalancePerson))
                    Else
                        BalanceHours = "null"
                    End If

                    Dim BalanceQty = ""
                    If BalancePerson <> "0" And BalancePerson <> "0.0" Then
                        BalanceQty = String.Format("{0:0.0}", Convert.ToInt32(3600 / Double.Parse(BalanceHours)))
                    Else
                        BalanceQty = "null"
                    End If
                    BalancePerson = IIf(BalancePerson = "0" Or BalancePerson = "0.0", "null", BalancePerson)

                    DbOperateUtils.ExecSQL("update m_ProductStandardAllocationD_t set BalanceHours=" & BalanceHours & ",BalanceQty=" & BalanceQty & ",BalancePerson=" & BalancePerson & ",InTime=getdate()  ,EmpNO='" & UserID & "',EmpName=N'" & UserName & "' where id=" + DetailID)
                    If BalancePerson <> "null" Then
                        dgvDetail.Rows(RowIndex).Cells("BalanceQty").Value = BalanceQty
                        dgvDetail.Rows(RowIndex).Cells("BalanceHours").Value = BalanceHours
                    Else
                        dgvDetail.Rows(RowIndex).Cells("BalancePerson").Value = Nothing
                        dgvDetail.Rows(RowIndex).Cells("BalanceQty").Value = Nothing
                        dgvDetail.Rows(RowIndex).Cells("BalanceHours").Value = Nothing
                    End If

                    ClacTotalBalancePerson()
                End If
            End If
        ElseIf dgvDetail.Columns(ColumnIndex).Name = "UndulationTime" Then '修改波动时间
            Dim UndulationTime = dgvDetail.Rows(RowIndex).Cells(ColumnIndex).Value.ToString()
            UndulationTime = IIf(String.IsNullOrEmpty(UndulationTime), "null", UndulationTime)
            DbOperateUtils.ExecSQL("update m_ProductStandardAllocationD_t set UndulationTime=" & UndulationTime & ",InTime=getdate() ,EmpNO='" & UserID & "',EmpName=N'" & UserName & "' where id=" + DetailID)
        ElseIf dgvDetail.Columns(ColumnIndex).Name = "SWorkingHours" Then '修改标准工时
            Dim SWorkingHours = dgvDetail.Rows(RowIndex).Cells("SWorkingHours").Value.ToString()
            If String.IsNullOrEmpty(SWorkingHours) = False Then
                If Double.TryParse(SWorkingHours, a) = False Then
                    MessageUtils.ShowError("标准工时必须是数字类型!")
                    dgvDetail.Rows(RowIndex).Cells("SWorkingHours").Value = Nothing
                ElseIf Double.Parse(SWorkingHours) <= 0 Then
                    MessageUtils.ShowError("标准工时必须是大于0!")
                    dgvDetail.Rows(RowIndex).Cells("SWorkingHours").Value = Nothing
                End If
                Dim OutPut = Convert.ToInt32(3600 / Double.Parse(SWorkingHours))
                dgvDetail.Rows(RowIndex).Cells("OutPut").Value = OutPut
                DbOperateUtils.ExecSQL("update m_ProductStandardAllocationD_t set SWorkingHours=" & SWorkingHours & ",OutPut=" & OutPut & ",InTime=getdate(),EmpNO='" & UserID & "',EmpName=N'" & UserName & "' where id=" + DetailID)
            End If
        ElseIf dgvDetail.Columns(ColumnIndex).Name = "StationName" Then  '修改工站名称
            Dim StationName = dgvDetail.Rows(RowIndex).Cells(ColumnIndex).Value.ToString()
            DbOperateUtils.ExecSQL("update m_ProductStandardAllocationD_t set StationName=N'" & StationName & "',InTime=getdate() ,EmpNO='" & UserID & "',EmpName=N'" & UserName & "'   where id=" + DetailID)
        ElseIf dgvDetail.Columns(ColumnIndex).Name = "Equiment" Then
            Dim Equiment = dgvDetail.Rows(RowIndex).Cells(ColumnIndex).Value.ToString()
            DbOperateUtils.ExecSQL("update m_ProductStandardAllocationD_t set Equiment=N'" & Equiment & "',InTime=getdate() ,EmpNO='" & UserID & "',EmpName=N'" & UserName & "'   where id=" + DetailID)
        End If
    End Sub
#End Region

#Region "变更工站数据就计算单头总人力"
    ''' <summary>
    ''' 变更工站数据就计算单头总人力
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClacTotalBalancePerson()
        dgvMain.CurrentRow.Cells("TotalBalancePerson").Value = DbOperateUtils.GetDataTable("select sum(isnull(BalancePerson,0)) from dbo.m_ProductStandardAllocationD_t where MainID=" + GetMainID()).Rows(0)(0).ToString()
    End Sub
#End Region


    ''' <summary>
    ''' 单元格双击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvDetail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellDoubleClick
        RowIndex = e.RowIndex
        ColumnIndex = e.ColumnIndex
        'If dgvDetail.Columns(ColumnIndex).Name = "StationName" Then '从PLM导入的工站在MES系统中不存在时就做修改动作
        '    Dim frm = New FrmStations()
        '    frm._StationID = dgvDetail.Rows(RowIndex).Cells("StationID").Value
        '    frm._StationName = dgvDetail.Rows(RowIndex).Cells("StationName").Value
        '    Dim dr = frm.ShowDialog()
        '    If dr = Windows.Forms.DialogResult.OK Then
        '        Dim DetailID = dgvDetail.Rows(RowIndex).Cells("DetailID").Value.ToString()
        '        DbOperateUtils.ExecSQL("update m_ProductStandardAllocationD_t set StationID='" & frm._StationID & "',StationName=N'" & frm._StationName & "',Equiment=N'" & frm._Equipment & "' where id=" + DetailID)
        '        dgvDetail.Rows(RowIndex).Cells("StationID").Value = frm._StationID
        '        dgvDetail.Rows(RowIndex).Cells("StationName").Value = frm._StationName
        '        dgvDetail.Rows(RowIndex).Cells("Equiment").Value = frm._Equipment
        '    End If
        'End If
    End Sub

    Private Sub dgvDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDetail.DataError

    End Sub

    ''' <summary>
    ''' 全选
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        Dim yy As Boolean = chkAll.Checked
        For Each dgvr As DataGridViewRow In dgvMain.Rows
            dgvr.Cells("ChkItem").Value = yy
        Next
    End Sub

    Private Sub dgvMain_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMain.CellClick
        If dgvMain.Columns(e.ColumnIndex).Name = "ChkItem" Then
            Dim BoolValue = dgvMain.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue
            dgvMain.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = IIf(BoolValue, False, True)
        End If
    End Sub

    ''' <summary>
    ''' 导出选择的表头
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiExportHead_Click(sender As Object, e As EventArgs) Handles tsmiExportHead.Click
        Dim id = ""
        For Each dgvr As DataGridViewRow In dgvMain.Rows
            If CType(dgvr.Cells("ChkItem").Value, Boolean) = True Then
                id += dgvr.Cells("ID").Value.ToString() + ","
            End If
        Next
        If String.IsNullOrEmpty(id) Then
            MessageUtils.ShowError("请勾选要导出的数据")
            Exit Sub
        End If
        Dim sql = "select row_number() over(order by id) as R,a.PartID, a.Version,a.ECN_No," & vbCrLf &
       "substring(a.FilePath,len(a.FilePath)-charindex('\',reverse(a.FilePath))+2,len(a.FilePath)) as FileName," & vbCrLf &
       "case " & vbCrLf &
       "when [Status]=0 then N'制作中'" & vbCrLf &
       "when [Status]=1 then N'待审核'" & vbCrLf &
       "when [Status]=3 then N'待DCC审核'" & vbCrLf &
       "when [Status]=2 then N'已完成'" & vbCrLf &
       "end ZStatus,a.CreateName,a.CreateTime,a.ModifyName,a.ModifyTime" & vbCrLf &
       ",(select sum(isnull(BalancePerson,0)) from " & vbCrLf &
       "dbo.m_ProductStandardAllocationD_t where MainID=a.ID) TotalBalancePerson" & vbCrLf &
       ",a.Remark from m_ProductStandardAllocation_t a" & vbCrLf &
       "where a.Usey='Y' and id in (" & id.Trim(",") & ")"
        Dim dt = DbOperateUtils.GetDataTable(sql)
        dt.TableName = "Main"
        Dim errorMsg = ""
        Dim FilePath = "\\192.168.20.123\SFCShare\File\产品制程标准排配导出打印模板\StandardJobSchedulingHead.xls"
        Dim sf = New System.Windows.Forms.SaveFileDialog()
        sf.FileName = "产品制程标准排配" & Date.Now.ToString("yyyyMMdd") & ".xls"
        If sf.ShowDialog() = Windows.Forms.DialogResult.OK Then
            sf.RestoreDirectory = True
            Dim Book = New Workbook(FilePath)
            Dim Designer = New WorkbookDesigner()
            Designer.Workbook = Book
            Designer.SetDataSource(dt)
            Designer.Process()
            Designer.Workbook.Save(sf.FileName, SaveFormat.Excel97To2003)
            MessageUtils.ShowInformation("导出OK")
            System.Diagnostics.Process.Start(sf.FileName)
        End If

    End Sub

#Region "合并工序"
    ''' <summary>
    ''' 合并工序
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiCellMerging_Click(sender As Object, e As EventArgs) Handles tsmiCellMerging.Click
        If dgvDetail.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行工站数据!")
            Exit Sub
        ElseIf dgvDetail.CurrentRow.Cells("StationType").Value.ToString() = "线外工站" Then
            MessageUtils.ShowError("只开放流程工站合并数据!")
            Exit Sub
        End If
        Dim frm = New FrmCellMerging()
        frm._OBy = dgvDetail.CurrentRow.Cells("OrderBy").Value.ToString()
        frm._MID = dgvDetail.CurrentRow.Cells("MainID").Value.ToString()
        frm.DetailID = dgvDetail.CurrentRow.Cells("DetailID").Value.ToString()
        frm._WorkHours = dgvDetail.CurrentRow.Cells("SWorkingHours").Value.ToString()
        frm.m_BalanceHours = dgvDetail.CurrentRow.Cells("BalanceHours").Value.ToString()
        Dim sql = "select * from m_ProductStandardAllocationDMerging_t where MainID=" & frm._MID & " and CellMergingOrderBy=" & frm._OBy & ""
        Dim dt = DbOperateUtils.GetDataTable(sql)
        If dt.Rows.Count > 0 Then
            MessageUtils.ShowError("工序:" & frm._OBy & ",已经被合并到工序:" & dt.Rows(0)("OrderBy") & ",请选择其它工序的工站!")
            Exit Sub
        End If
        frm.ShowDialog()
        DataBindDetail()
    End Sub
#End Region

    Private Sub 复制ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 复制ToolStripMenuItem.Click
        Dim ID = GetMainID()
        Dim dgvr As DataGridViewRow = dgvMain.CurrentRow
        If ID Is Nothing Then
            MessageUtils.ShowError("请选择一行数据!")
            Exit Sub
        ElseIf Not dgvr.Cells("Status").Value.ToString() = "已完成" Then
            MessageUtils.ShowError("非已完成的机种,不可复制,请核实!")
            Exit Sub
        End If
        Dim frm = New FrmCopy()
        frm.ID = ID
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            DataBindMain()
        End If
        'Ssql = "SELECT PartID,Version,FilePath,ECN_No,Remark,Usey  FROM m_ProductStandardAllocation_t WHERE ID = '" + ID + "'"
        'dg = DbOperateUtils.GetDataTable(Ssql)
        'Ssql = "INSERT INTO m_ProductStandardAllocation_t (PartID,Version,FilePath,ECN_No,Remark,Status,Usey,CreateBy,CreateName," &
        '       "CreateTime,ModifyBy,ModifyName,ModifyTime,FactNO,Profitcenter) VALUES ('" + dg.Rows(0)(0) + "','" + dg.Rows(0)(1) + "'" &
        '       ",'" + dg.Rows(0)(2) + "','" + dg.Rows(0)(3) + "','" + dg.Rows(0)(4) + "','0','" + dg.Rows(0)(5) + "')"
    End Sub

    Private Sub dgvDetail_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellContentClick
        Dim ds As String
        ds = ""
        Dim StationName, Ssql As String
        Dim dg As DataTable
        StationName = dgvDetail(4, dgvDetail.CurrentCell.RowIndex).Value


        Dim p As ToolTip = New ToolTip()
        p.ShowAlways = True

        Ssql = "SELECT DISTINCT D.ProductType as ProductType,StandardHour FROM m_RstationWorkHour_t A " &
               " left join  ProductType_t d on d.ProductTypeID=a.ProductTypeID" & _
               "  LEFT JOIN m_Rstation_t b ON a.stationid = b.stationid " & _
               " WHERE b.StationName = N'" + StationName + "'"
        dg = DbOperateUtils.GetDataTable(Ssql)
        If e.ColumnIndex <> -1 AndAlso e.RowIndex <> -1 Then
            If ds IsNot Nothing AndAlso dgvDetail.CurrentRow.IsNewRow = False AndAlso dgvDetail.CurrentRow.Cells(0).Value.ToString() <> "" Then
                If dgvDetail(dgvDetail.CurrentCell.ColumnIndex, dgvDetail.CurrentCell.RowIndex).Value.ToString() <> "" Then
                    dgvDetail(e.ColumnIndex, e.RowIndex).ToolTipText = "当前行基本信息:" & vbLf
                    For index = 0 To dg.Rows.Count - 1
                        dgvDetail(e.ColumnIndex, e.RowIndex).ToolTipText += "产品形态:" & dg.Rows(index)(0) + "||标准工时:" & dg.Rows(index)(1) & vbLf
                        ' p.SetToolTip(dgvDetail, "产品形态:" & dg.Rows(index)(0) + "||标准工时:" & dg.Rows(index)(1) & vbLf)
                    Next
                    ' dgvDetail(e.ColumnIndex, e.RowIndex).ToolTipText
                End If
            End If
        End If

    End Sub


    'Private Sub dgvDetail_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellContentClick
    '    Dim ds As String
    '    ds = ""
    '    Dim StationName, Ssql As String
    '    Dim dg As DataTable
    '    StationName = dgvDetail(4, dgvDetail.CurrentCell.RowIndex).Value
    '    Ssql = "SELECT B.PartID,A.SWorkingHours FROM m_ProductStandardAllocationD_t A " &
    '           "LEFT JOIN m_ProductStandardAllocation_t B ON A.MainID=B.ID" &
    '           " WHERE A.StationName = N'" + StationName + "'"
    '    dg = DbOperateUtils.GetDataTable(Ssql)
    '    If e.ColumnIndex <> -1 AndAlso e.RowIndex <> -1 Then
    '        If ds IsNot Nothing AndAlso dgvDetail.CurrentRow.IsNewRow = False AndAlso dgvDetail.CurrentRow.Cells(0).Value.ToString() <> "" Then
    '            If dgvDetail(dgvDetail.CurrentCell.ColumnIndex, dgvDetail.CurrentCell.RowIndex).Value.ToString() <> "" Then
    '                dgvDetail(e.ColumnIndex, e.RowIndex).ToolTipText = "当前行基本信息:" & vbLf
    '                For index = 0 To dg.Rows.Count - 1
    '                    dgvDetail(e.ColumnIndex, e.RowIndex).ToolTipText += "     机种:" & dg.Rows(index)(0) + "     标准工时:" & dg.Rows(index)(1) & vbLf
    '                Next
    '            End If
    '        End If
    '    End If
    'End Sub
End Class