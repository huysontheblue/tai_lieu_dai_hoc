Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports MainFrame
Imports System.Drawing
Imports System.IO
Imports System.Text

Public Class FrmMouldBasis

    Public opFlag As Int16 = 0  '判断是新增还是修改
  
#Region "定义导入列名称枚举"
    Private Enum CDImportGrid
        MouldID     '模号
        ParaDesc    '尾网OD/线槽OD
        MapID   '模具图号
        NewMouldID  '新模号
        Type    '模别
        Cavitys '模穴数
        Strips  '模条数
        Tails   '网尾数
        Slots   '线槽数
        Parts   '适应机种
        Location    '现有位置
        AssetsID    '资产编号
        Storage '固定储位
        LimitTimes  '寿命次数
        AlertTimes  '预警次数
    End Enum
#End Region

#Region "初始化"
    Private Sub FrmMouldBasis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolBtnState(opFlag)    '设置按钮状态
        FillCombox(cboStorage) '加载储位信息
        FillCombox(cboType) '加载模别信息
        LoadDataToBasis() '加载模具基础信息
        dtpNextMonthKeep.Value = System.DateTime.Now.ToString("yyyy-MM-dd")
        dtpNextSeasonKeep.Value = System.DateTime.Now.ToString("yyyy-MM-dd")
    End Sub
#End Region

#Region "事件"
    '新增
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        ClearGroupBox()
        butnMatn.Visible = True
        opFlag = 1
        ToolBtnState(opFlag)
    End Sub

    '修改
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If dgvBasis.RowCount < 1 OrElse dgvBasis.CurrentRow Is Nothing Then Exit Sub
        SetControlValue()
        butnMatn.Visible = True
        opFlag = 2
        ToolBtnState(opFlag)
    End Sub

    '删除
    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        If dgvBasis.Rows.Count = 0 OrElse dgvBasis.CurrentRow Is Nothing Then Exit Sub

        Dim mouldID As String = Me.dgvBasis.Item(0, dgvBasis.CurrentRow.Index).Value.ToString.Trim
        If MessageUtils.ShowConfirm("确定要删除模号[" & mouldID & "]吗?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Try
            Dim strSQL As String = String.Format("delete from m_Mould_t where MouldID='{0}'", mouldID)
            DbOperateUtils.ExecSQL(strSQL)
            MessageUtils.ShowInformation("删除模号[" & mouldID & "]成功!")
            ClearGroupBox()
            LoadDataToBasis()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldBasis", "toolDelete_Click", "sys")
        End Try
    End Sub

    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            '检查数据
            If CheckData() = False Then Exit Sub

            If SaveData() = False Then Exit Sub

            MessageUtils.ShowInformation("保存成功")

            opFlag = 0
            ToolBtnState(opFlag)
            ClearGroupBox()  '清除面板控件值
            LoadDataToBasis()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldBasis", "toolSave_Click", "sys")
        End Try
    End Sub

    '返回
    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        opFlag = 0
        butnMatn.Visible = False
        ToolBtnState(opFlag)
        ClearGroupBox()  '清除面板控件值
    End Sub

    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        butnMatn.Visible = False
        LoadDataToBasis()
    End Sub

    '导入
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Try
            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If sdfimport.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

            Dim filename As String = ""
            Dim errorMsg As String = ""
            filename = sdfimport.FileName

            '取得用户上传数据 （15：代表15列数据）
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 15, errorMsg)

            ChangeCDDataTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select(" ")
            '= dtUploadData.Select(" Station is not null") '防止追加

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            '数据插入到DB中
            Dim strSQL As String = GetInsertSQL(DrrR)
            If DbOperateUtils.ExecSQL(strSQL) = "" Then
                MessageUtils.ShowInformation("成功导入!")
            End If
            ClearGroupBox()
            LoadDataToBasis()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldBasis", "toolImport_Click", "sys")
        End Try
    End Sub

    '导出
    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        Try
            Dim strSql As String

            strSql = "select MouldID 模号,ParaDesc 尾网OD,MapID 模具图号,NewMouldID 新模号,Type 模别,Cavitys 模穴数,Strips 模条数,Tails 网尾数," &
                     " Slots 线槽数,Parts 适应机种,Location 现有位置,AssetsID 资产编号,Storage 固定储位,LimitTimes 寿命次数,AlertTimes 预警次数, " &
                     " UsedTimes 使用次数," &
                     " case UseStatus when 0 then N'0-闲置中' when 1 then N'1-使用中' when 2 then N'2-维修中' end 使用状态, " &
                     " m.FactoryID 厂区,m.ProfileID 利润中心,m.UserID+'/'+u.UserName 操作人,m.Intime 操作时间," &
                     " case  when LimitTimes-UsedTimes<=0 then 0  when AlertTimes-UsedTimes<=0 then 1 else 2 end sort FROM m_Mould_t m " &
                     " left join m_Users_t u on m.UserID=u.UserID "

            Dim dtExportData As DataTable = GetListData(strSql).Copy
            If dtExportData.Rows.Count = 0 Then
                MessageUtils.ShowInformation("没有模具资料信息！")
                Return
            End If

            ExcelUtils.LoadDataToExcelFromDT(dtExportData, Me.Text)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldBasis", "toolExport_Click", "sys")
        End Try
    End Sub

    '模具寿命管控
    Private Sub toolMouldBasicLife_Click(sender As Object, e As EventArgs) Handles toolMouldBasicLife.Click     
        Dim frm As FrmMouldBasisLife = New FrmMouldBasisLife
        frm.MouldId = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("MouldID").Value.ToString
        frm.ShowDialog()
        ClearGroupBox()
        LoadDataToBasis()
    End Sub

    '下载模具导入模板
    Private Sub toolLoadMoBan_Click(sender As Object, e As EventArgs) Handles toolLoadMoBan.Click
        Try
            Dim ssf = New SaveFileDialog()
            ssf.FileName = "模具导入模板.xls"
            ssf.Filter = "Excel|*.xls"
            If ssf.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Using fs As FileStream = CType(ssf.OpenFile(), FileStream)
                    Dim data = System.IO.File.ReadAllBytes("\\192.168.20.123\SFCShare\File\模具导入模板\模具导入模板.xls")
                    fs.Write(data, 0, data.Length)
                    fs.Flush()
                End Using
                MessageUtils.ShowInformation("下载成功!")
            Else
                MessageUtils.ShowInformation("下载失败!")
            End If
        Catch ex As Exception
            MessageUtils.ShowError("下载异常:" & vbCrLf & ex.Message)
        End Try
    End Sub

    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    'DatagridView单击事件
    Private Sub dgvBasis_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBasis.CellClick
        If e.RowIndex = -1 Then Exit Sub
        SetControlValue()
    End Sub

    'DataGridview颜色显示 
    Private Sub dgvBasis_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvBasis.DataBindingComplete
        Dim usedTimes As Integer    '使用次数
        Dim alertTimes As Integer   '预警次数
        Dim limitTimes As Integer   '寿命次数

        For Each item As DataGridViewRow In dgvBasis.Rows
            usedTimes = CInt(item.Cells("UsedTimes").Value.ToString)
            alertTimes = CInt(item.Cells("AlertTimes").Value.ToString)
            limitTimes = CInt(item.Cells("LimitTimes").Value.ToString)

            If usedTimes >= limitTimes Then
                item.DefaultCellStyle.BackColor = Color.Red
            ElseIf usedTimes >= alertTimes Then
                item.DefaultCellStyle.BackColor = Color.Yellow
            End If
        Next
    End Sub

#End Region

#Region "方法"
    '设置按钮及textbox状态
    Private Sub ToolBtnState(ByVal flag As Short)
        Select Case flag
            Case 0 '初始查询状态
                toolAdd.Enabled = True
                toolEdit.Enabled = True
                toolDelete.Enabled = True
                toolBack.Enabled = True
                toolSave.Enabled = False
                toolQuery.Enabled = True
                toolImport.Enabled = True
                toolExport.Enabled = True
                toolMouldBasicLife.Enabled = True
                dgvBasis.Enabled = True

                txtMouldID.ReadOnly = False
                cboStatus.Enabled = True
            Case 1   '新增 
                toolAdd.Enabled = False
                toolEdit.Enabled = False
                toolDelete.Enabled = False
                toolBack.Enabled = True
                toolSave.Enabled = True
                toolQuery.Enabled = False
                toolImport.Enabled = False
                toolExport.Enabled = False
                toolMouldBasicLife.Enabled = False
                dgvBasis.Enabled = False

                txtMouldID.ReadOnly = False
                cboStatus.SelectedIndex = 1
                cboStatus.Enabled = False
                txtUsedTimes.Text = "0"
            Case 2  '修改
                toolAdd.Enabled = False
                toolEdit.Enabled = False
                toolDelete.Enabled = False
                toolBack.Enabled = True
                toolSave.Enabled = True
                toolQuery.Enabled = False
                toolImport.Enabled = False
                toolExport.Enabled = False
                toolMouldBasicLife.Enabled = False
                dgvBasis.Enabled = False

                Me.txtMouldID.ReadOnly = True
                cboStatus.Enabled = False
        End Select
    End Sub

    ''' <summary>
    ''' 清除 GroupBox 面板控件值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearGroupBox()
        txtMouldID.Text = ""
        txtParaDesc.Text = ""
        txtMapID.Text = ""
        txtNewMouldID.Text = ""
        cboType.SelectedIndex = 0
        txtCavitys.Text = ""
        txtStrips.Text = ""
        txtTails.Text = ""
        txtSlots.Text = ""
        txtParts.Text = ""
        txtLocation.Text = ""
        txtAssetsID.Text = ""
        cboStorage.SelectedIndex = 0
        txtLimitTimes.Text = ""
        txtAlertTimes.Text = ""
        txtUsedTimes.Text = ""
        cboStatus.SelectedIndex = 0
    End Sub

    '保存时输入判断
    Private Function CheckData() As Boolean
        Dim strSql As String = ""
        If txtMouldID.Text.Trim = "" Then
            MessageUtils.ShowInformation("请输入模号!")
            txtMouldID.Focus()
            Return False
        End If

        'If txtParts.Text.Trim = "" Then
        '    MessageUtils.ShowInformation("请输入适应机种!")
        '    txtParts.Focus()
        '    Return False
        'End If


        '判断寿命次数和预警次数是否为数字
        If Not IsNumeric(txtLimitTimes.Text.Trim) Then
            MessageUtils.ShowInformation("寿命次数应为数字!")
            txtLimitTimes.Focus()
            Return False
        End If
        If Not IsNumeric(txtAlertTimes.Text.Trim) Then
            MessageUtils.ShowInformation("预警次数应为数字!")
            txtAlertTimes.Focus()
            Return False
        End If

        If CInt(txtAlertTimes.Text.Trim) > CInt(txtLimitTimes.Text.Trim) Then
            MessageUtils.ShowInformation("预警次数不应大于寿命次数!")
            Return False
        End If

        If cboStorage.SelectedIndex = -1 OrElse cboStorage.SelectedIndex = 0 Then
            MessageUtils.ShowInformation("请选择固定储位!")
            Return False
        End If

        If cboType.SelectedIndex = -1 OrElse cboType.SelectedIndex = 0 Then
            MessageUtils.ShowInformation("请选择模别!")
            Return False
        End If
        strSql = "select 1 from m_Storage_t where StorageID = N'" & cboStorage.Text & "' and Usey ='Y'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
        If dt.Rows.Count = 0 Then
            MessageUtils.ShowError("储位不存在!")
            Return False
        End If
        'Dim dt1 As DataTable = DbOperateUtils.GetDataTable(String.Format("select 1 from m_Mould_t where Storage='{0}' AND FactoryID='{1}' ", cboStorage.Text, VbCommClass.VbCommClass.Factory))
        'If dt1.Rows.Count > 0 Then
        '    MessageUtils.ShowWarning("储位已使用")
        '    Return False
        'End If
        Return True
    End Function

    '保存数据
    Private Function SaveData() As Boolean
        Dim strSql As String = ""
        Try
            Dim MouldID As String = txtMouldID.Text.Trim
            Dim ParaDesc As String = txtParaDesc.Text.Trim
            Dim MapID As String = txtMapID.Text.Trim
            Dim NewMouldID As String = txtNewMouldID.Text.Trim
            Dim Type As String = cboType.SelectedValue.ToString
            Dim Cavitys As String = txtCavitys.Text.Trim
            Dim Strips As String = txtStrips.Text.Trim
            Dim Tails As String = txtTails.Text.Trim
            Dim Slots As String = txtSlots.Text.Trim
            Dim Parts As String = txtParts.Text.Trim
            Dim Location As String = txtLocation.Text.Trim
            Dim AssetsID As String = txtAssetsID.Text.Trim
            Dim Storage As String = cboStorage.SelectedValue.ToString
            Dim LimitTimes As Integer = txtLimitTimes.Text.Trim
            Dim AlertTimes As Integer = txtAlertTimes.Text.Trim
            Dim UsedTimes As Integer = txtUsedTimes.Text.Trim
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim FactoryID As String = VbCommClass.VbCommClass.Factory
            Dim ProfileID As String = VbCommClass.VbCommClass.profitcenter

            Dim strBSQL As New System.Text.StringBuilder
            Dim NextMonthKeep = dtpNextMonthKeep.Text.Trim()
            Dim NextSeasonKeep = dtpNextSeasonKeep.Text.Trim()
            If opFlag = 1 Then    '新增
                '模号是否存在
                strSql = "select 1 from m_Mould_t where MouldID='" & MouldID & "'"
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowError("模号:" + MouldID + " 已存在!")
                    Return False
                End If

                strSql = " INSERT INTO m_Mould_t (MouldID,ParaDesc,MapID,NewMouldID,Type,Cavitys,Strips,Tails ,Slots,Parts,Location," &
                         " AssetsID,Storage,LimitTimes,AlertTimes,UsedTimes,UseStatus,UserID,Intime,FactoryID,ProfileID,NextMonthKeep,NextSeasonKeep) "

                strBSQL.Append(strSql)
                strBSQL.Append(" VALUES(")
                strBSQL.AppendFormat("N'{0}',", MouldID)
                strBSQL.AppendFormat("N'{0}',", ParaDesc)
                strBSQL.AppendFormat("N'{0}',", MapID)
                strBSQL.AppendFormat("N'{0}',", NewMouldID)
                strBSQL.AppendFormat("N'{0}',", Type)
                strBSQL.AppendFormat("N'{0}',", Cavitys)
                strBSQL.AppendFormat("N'{0}',", Strips)
                strBSQL.AppendFormat("N'{0}',", Tails)
                strBSQL.AppendFormat("N'{0}',", Slots)
                strBSQL.AppendFormat("N'{0}',", Parts)
                strBSQL.AppendFormat("N'{0}',", Location)
                strBSQL.AppendFormat("N'{0}',", AssetsID)
                strBSQL.AppendFormat("N'{0}',", Storage)
                strBSQL.AppendFormat("'{0}',", LimitTimes)
                strBSQL.AppendFormat("N'{0}',", AlertTimes)
                strBSQL.AppendFormat("'{0}',", UsedTimes)
                strBSQL.AppendFormat("{0},", 0)
                strBSQL.AppendFormat("N'{0}',", UserID)
                strBSQL.AppendFormat("getdate(),")
                strBSQL.AppendFormat("N'{0}',", FactoryID)
                strBSQL.AppendFormat("N'{0}' ,", ProfileID)
                strBSQL.AppendFormat("N'{0}',", NextMonthKeep)
                strBSQL.AppendFormat("N'{0}' ", NextSeasonKeep)
                strBSQL.Append(");")

                'strSql = "INSERT INTO m_Equipment_t (EquipmentNo,NextMonthKeep,NextSeasonKeep,FactoryName,Profitcenter)"
                'strBSQL.Append(strSql)
                'strBSQL.Append(" VALUES(")
                'strBSQL.AppendFormat("N'{0}',", MouldID)
                'strBSQL.AppendFormat("N'{0}',", NextMonthKeep)
                'strBSQL.AppendFormat("N'{0}',", NextSeasonKeep)
                'strBSQL.AppendFormat("N'{0}',", FactoryID)
                'strBSQL.AppendFormat("N'{0}'", ProfileID)
                'strBSQL.Append(");")
            ElseIf opFlag = 2 Then '修改
                strSql = "UPDATE m_Mould_t "

                strBSQL.Append(strSql)
                strBSQL.AppendFormat(" SET ParaDesc = N'{0}', ", ParaDesc)
                strBSQL.AppendFormat(" MapID = N'{0}', ", MapID)
                strBSQL.AppendFormat(" NewMouldID = N'{0}', ", NewMouldID)
                strBSQL.AppendFormat(" Type = N'{0}' ,", Type)
                strBSQL.AppendFormat(" Cavitys = N'{0}' ,", Cavitys)
                strBSQL.AppendFormat(" Strips = N'{0}',", Strips)
                strBSQL.AppendFormat(" Tails = N'{0}',", Tails)
                strBSQL.AppendFormat(" Slots = N'{0}', ", Slots)
                strBSQL.AppendFormat(" Parts = N'{0}', ", Parts)
                strBSQL.AppendFormat(" Location = N'{0}', ", Location)
                strBSQL.AppendFormat(" AssetsID = N'{0}', ", AssetsID)
                strBSQL.AppendFormat(" Storage=N'{0}',", Storage)   '
                strBSQL.AppendFormat(" LimitTimes=N'{0}',", LimitTimes)
                strBSQL.AppendFormat(" AlertTimes=N'{0}',", AlertTimes)   '
                strBSQL.AppendFormat(" UsedTimes=N'{0}',", UsedTimes)
                strBSQL.AppendFormat(" UserID = N'{0}', ", UserID)
                strBSQL.AppendFormat(" NextMonthKeep = N'{0}', ", NextMonthKeep)
                strBSQL.AppendFormat(" NextSeasonKeep = N'{0}', ", NextSeasonKeep)
                strBSQL.AppendFormat(" InTime=getdate() ")
                strBSQL.AppendFormat(" WHERE MouldID = '{0}'", MouldID)

                'strSql = "UPDATE m_Equipment_t"
                'strBSQL.Append(strSql)
                'strBSQL.AppendFormat(" SET NextMonthKeep = N'{0}', ", NextMonthKeep)
                'strBSQL.AppendFormat(" NextSeasonKeep = N'{0}' ", NextSeasonKeep)
                'strBSQL.AppendFormat(" WHERE EquipmentNo = '{0}'", MouldID)
            End If

            '执行SQL
            DbOperateUtils.ExecSQL(strBSQL.ToString)

            Return True
        Catch ex As Exception

        End Try
    End Function

    '加载固定储位下拉列表
    Private Sub FillCombox(ByVal comboBox As ComboBox)
        Dim strSQL As String
        Dim dt As DataTable
        If comboBox.Name = "cboStorage" Then
            strSQL = "select '' StorageID,'' Warehouse union select StorageID,Warehouse  from m_Storage_t where FactoryID='" + VbCommClass.VbCommClass.Factory + "'AND Usey ='Y'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            comboBox.DataSource = dt
            comboBox.DisplayMember = "StorageID"
            comboBox.ValueMember = "StorageID"
        End If
        If comboBox.Name = "cboType" Then
            strSQL = "select '' SortID,'' SortName  union" &
                    " select SortID ,SortName from m_Sortset_t where SortType ='MouldType' and Usey ='Y' "
            dt = DbOperateUtils.GetDataTable(strSQL)
            comboBox.DataSource = dt
            comboBox.DisplayMember = "StorageID"
            comboBox.ValueMember = "SortName"
        End If

        dt = Nothing
    End Sub

    '加载数据
    Private Sub LoadDataToBasis()
        Dim dt As DataTable
        Dim strSQL As String

        Try
            strSQL = "SELECT TOP 100 MouldID,ParaDesc,MapID,NewMouldID,Type,Cavitys,Strips,Tails,Slots,Parts,Location,AssetsID,Storage,LimitTimes,AlertTimes,UsedTimes, " &
                " case UseStatus when 0 then N'0-闲置中' when 1 then N'1-使用中' when 2 then N'2-维修中' end UseStatus, " &
                " m.FactoryID,m.ProfileID,m.UserID+'/'+u.UserName UserID,m.Intime," &
                " case  when LimitTimes-UsedTimes<=0 then 0  when AlertTimes-UsedTimes<=0 then 1 else 2 end sort FROM m_Mould_t m " &
                " left join m_Users_t u on m.UserID=u.UserID "
            dt = GetListData(strSQL)
            dgvBasis.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 设置面板控件值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetControlValue()
        txtMouldID.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("MouldID").Value.ToString
        txtParaDesc.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("ParaDesc").Value.ToString
        txtMapID.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("MapID").Value.ToString
        txtNewMouldID.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("NewMouldID").Value.ToString
        cboType.SelectedValue = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Type").Value.ToString
        txtCavitys.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Cavitys").Value.ToString
        txtStrips.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Strips").Value.ToString
        txtTails.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Tails").Value.ToString
        txtSlots.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Slots").Value.ToString
        txtParts.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Parts").Value.ToString
        txtLocation.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Location").Value.ToString
        txtAssetsID.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("AssetsID").Value.ToString
        cboStorage.SelectedValue = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("Storage").Value.ToString
        txtLimitTimes.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("LimitTimes").Value.ToString
        txtAlertTimes.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("AlertTimes").Value.ToString
        txtUsedTimes.Text = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("UsedTimes").Value.ToString
        cboStatus.SelectedItem = dgvBasis.Rows(dgvBasis.CurrentRow.Index).Cells("UseStatus").Value.ToString
    End Sub

    ''' <summary>
    ''' 改变Table列名 ChangeCDDataTableColumnName
    ''' </summary>
    ''' <param name="dtUploadData"></param>
    ''' <remarks></remarks>
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
    End Sub

    '检查上传数据 CheckUploadData
    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        'DB 模号
        Dim mouldIdSQL As String = " select MouldID,* from m_Mould_t "
        Dim mouldIdDT As DataTable = DbOperateUtils.GetDataTable(mouldIdSQL)

        '仓库储位
        Dim StorageIdSQL As String = "select StorageID from m_Storage_t where Usey ='Y' "
        Dim StorageIdDT As DataTable = DbOperateUtils.GetDataTable(StorageIdSQL)

        Dim hashtable As Hashtable = New Hashtable

        For index As Integer = 0 To DrrR.Length - 1
            '模号
            Dim strMouldId As String = DrrR(index)("MouldID").ToString.Trim
            If hashtable.Contains(strMouldId) Then
                MessageUtils.ShowError("上传数据中有重复的模号[" + strMouldId + "]")
                Return False
            End If

            ' Dim returnCode As String
            If strMouldId <> "" Then
                If CheckExistUserColumns(mouldIdDT, "MouldID", strMouldId) Then
                    MessageUtils.ShowError("上传[模号]已在资料库中:'" & strMouldId & "'")
                    Return False
                End If
            Else
                MessageUtils.ShowError("[模号]中有空值，请检查后重新上传")
                Return False
            End If

            Dim StrStorageId As String = DrrR(index)("Storage").ToString.Trim
            If StrStorageId <> "" Then
                If CheckExistUserColumns(StorageIdDT, "StorageID", StrStorageId) = False Then
                    MessageUtils.ShowError("上传[仓库储位]不在资料库中:'" & StrStorageId & "'")
                    Return False
                End If
            Else
                MessageUtils.ShowError("[仓库储位]中有空值，请检查后重新上传")
                Return False
            End If


            '资产编号
            Dim strAssetsID As String = DrrR(index)("AssetsID").ToString.Trim
            If strAssetsID = "" Then
                MessageUtils.ShowError("[资产编号]不能为空，请检查后重新上传!")
                Return False
            End If

            '寿命次数
            Dim strLimitTimes As String = DrrR(index)("LimitTimes").ToString.Trim
            If Not IsNumeric(strLimitTimes) Then
                MessageUtils.ShowWarning("[寿命次数]应为数字类型，请检查后重新上传!")
                Return False
            End If

            '预警次数
            Dim strAlertTimes As String = DrrR(index)("AlertTimes").ToString.Trim
            If Not IsNumeric(strAlertTimes) Then
                MessageUtils.ShowWarning("[预警次数]应为数字类型，请检查后重新上传!")
                Return False
            End If
            If CInt(strLimitTimes) < CInt(strAlertTimes) Then
                MessageUtils.ShowWarning("[寿命次数]应大于[预警次数]，请检查后重新上传!")
                Return False
            End If

            hashtable.Add(strMouldId, strMouldId)
        Next

        Return True
    End Function

    '检查方法
    Private Function CheckExistUserColumns(ByVal dt As DataTable, ByVal DBColumns As String, ByVal ColumnsValue As String) As Boolean
        Dim dr() As DataRow = dt.Select(String.Format("{0}='{1}'", DBColumns, ColumnsValue))
        If dr.Length > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    '插入SQL文本 GetInsertSQL
    Private Function GetInsertSQL(DRS As DataRow()) As String
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        Dim FactoryID As String = VbCommClass.VbCommClass.Factory
        Dim ProfileID As String = VbCommClass.VbCommClass.profitcenter

        Dim strSQL As String = "INSERT INTO [dbo].[m_Mould_t] " &
           "([MouldID] ,[ParaDesc],[MapID] ,[NewMouldID],[Type] ,[Cavitys] ,[Strips],[Tails] ,[Slots] ,[Parts] ,[Location] ,[AssetsID]" &
           ",[Storage] ,[LimitTimes] ,[AlertTimes] ,[UsedTimes] ,[UseStatus] ,[UserID] ,[Intime] ,[FactoryID],[ProfileID])" &
           "VALUES('{0}','{1}','{2}','{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}','{9}',N'{10}','{11}','{12}',{13},{14},0,0,'{15}',getdate() ,'{16}' ,'{17}') "
        Dim strInsertSQL As New StringBuilder
        For Each row As DataRow In DRS
            strInsertSQL.AppendFormat(strSQL, row(0).ToString, row(1).ToString, row(2).ToString, row(3).ToString, row(4).ToString, row(5).ToString, row(6).ToString,
                                      row(7).ToString, row(8).ToString, row(9).ToString, row(10).ToString, row(11).ToString, row(12).ToString, row(13).ToString,
                                       row(14).ToString, UserID, FactoryID, ProfileID)
            strInsertSQL.AppendLine()
        Next

        Return strInsertSQL.ToString
    End Function

    '获取数据源
    Private Function GetListData(ByVal strSQL As String) As DataTable
        Dim strWhere As String = " where 1=1 "
        If Not String.IsNullOrEmpty(txtMouldID.Text.Trim) Then
            strWhere = strWhere & " and MouldID like '%" & Me.txtMouldID.Text.Trim & "%' "
        End If

        If Not String.IsNullOrEmpty(cboStatus.Text.Trim) Then
            strWhere = strWhere & " and UseStatus=" & cboStatus.SelectedItem.ToString.Substring(0, 1)
        End If
        GetListData = DbOperateUtils.GetDataTable(strSQL & strWhere & EquManageCommon.GetFatoryProfileID("m") & " ORDER BY  sort,m.intime DESC")  '& EquManageCommon.GetFatoryProfitcenter("m")
    End Function
#End Region
 
#Region "Grid行数"
    Private Sub dgvBasis_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvBasis.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region
    '新增维护模具号支持绑定多个线槽和机种
    Private Sub butnMatn_Click(sender As Object, e As EventArgs) Handles butnMatn.Click
        If txtMouldID.Text.Trim = "" Then
            MessageUtils.ShowInformation("请输入模号!")
            Return
        End If
        Dim frm As FrmWireslot = New FrmWireslot
        frm.MouldID = txtMouldID.Text.Trim
        frm.ShowDialog()
    End Sub

    Private Sub dtpNextSeasonKeep_ValueChanged(sender As Object, e As EventArgs) Handles dtpNextSeasonKeep.ValueChanged
        dtpNextSeasonKeep.CustomFormat = "yyyy-MM-dd"
    End Sub

    Private Sub dtpNextMonthKeep_ValueChanged(sender As Object, e As EventArgs) Handles dtpNextMonthKeep.ValueChanged
        dtpNextMonthKeep.CustomFormat = "yyyy-MM-dd"
    End Sub
End Class