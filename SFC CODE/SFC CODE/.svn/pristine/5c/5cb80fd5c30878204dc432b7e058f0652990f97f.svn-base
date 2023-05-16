'Option Explicit On
'Option Strict On
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.IO
Imports Aspose.Cells
Imports SysBasicClass
Imports MainFrame
Imports System.Text
'Imports SysBasicClass

'
'
'
Public Class FrmMoMain

#Region "变量定义"
    Const GridColZero As Integer = 0
    Const GridColOne As Integer = 1
    Dim ComBoxFlag As Boolean = False
    Public listSerial As New List(Of String)
    Private m_blnNeedClear As Boolean = True
    Private m_Assort As String = String.Empty
    Public m_IsSynTTSortTime As Boolean = False

    Public Enum ActionType
        SaveBatch = 0
        CancelBatch
        PrintMo
    End Enum
    Private Enum RunCardDetailGrid
        ID = 0
        Pn ' 1
        Version
        Qty
        TotalHourPreChild
        CutProPREMO  '04
        PreAssemblyHourPreMo '01
        SemiAutoPREMO 'A05
        ContourHourPreMo '03
        MadeHourPreMo '02
        Remark
        '铆端前加工= rivet point/产线加工/成型加工contour/裁切前加工/生产线前加工/半自动压接连接' 裁切（04）/铆端（01） rivet/半自动压接（A05）Semi-Auto/成型（03）/产线（02）
    End Enum
    ''' <summary>
    ''' 工单的各个状态EstateID
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enumMOState
        ConfirmStart = 1 '1	確認生產工單(firm plan) 	
        BOMNoPrint '2	工單已發放,料表尚未列印	
        BOMPrinted '3	工單已發放,料表已列印	
        MOSend '4	工單已發料	
        WIP '5	在製過程中	
        FQC '6	工單已完工,進入F.Q.C 	
        StoreIn '7	完工入庫	
        Close '8	結案	
        RBatchAndClose '9	工單成功分批并結案	
        ' RPrinted  ?? 'A	工單打印RUN CARD	
        Lock = 10
    End Enum

    Public Enum enumDgMoData
        iSelect = 0 '选择
        MOID '工单编号
        PartID '料件编号
        PartName '品名
        Cusid '客户代码
        CusName '客户名称
        SeriesID
        Factory '工厂名称
        Deptid '生产部门
        djc '部门名称
        lineid '生产线别
        MoQty '工单数量
        PpidPrtqty '成品条码数量 
        PkgPrtqty '外箱打印数量
        motype '工单类型
        statename '工单状态
        Routeid '生产途程
        OrderNO
        Orderseq
        Po '合同
        DeliveryDate
        ScheFinishDate
        Createuser '维护人员
        Createtime '维护时间
        Version 'cq,20160825
        ParentMo
    End Enum


#End Region

#Region "初期化"
    '初期化
    Private Sub FrmMoMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillComboLine(CboMoType)
        FillComboLine(CboConsumer)
        FillComboAdd(CboSeriesID)
        FillComboLine(CboDept)
        FillComboLine(cobLineQuery)
        Me.cboPartID.Text = "ALL" 'Add by CQ 20151202
        DtStarDate.Value = DateAdd(DateInterval.Month, -3, Now())
        DtEndDate.Value = Now()
        Me.LblInfo.Text = String.Empty
        m_IsSynTTSortTime = IsSynTTSortTime()
    End Sub

    ''' <summary>
    ''' 华为成套料号是否开启同步配套工时
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsSynTTSortTime() As Boolean
        Dim Sqlstr As String = "select PARAMETER_VALUES from m_SystemSetting_t where  PARAMETER_CODE='IsSynTTSortTime' and PARAMETER_VALUES=1 "
        Return DbOperateUtils.GetRowsCount(Sqlstr) > 0
    End Function


    Private Sub FillComboLine(ByVal FillComBox As ComboBox)
        Dim dt As DataTable = Nothing

        If FillComBox.Name = "CboDept" Then
            Dim lsSQL As String = " SELECT (deptid+'---'+djc) as djc,deptid FROM  m_Dept_t " & _
                    " WHERE factoryid='" & VbCommClass.VbCommClass.Factory & "' " & _
                    " AND deptid in (SELECT  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='10109_' and userid='" & SysMessageClass.UseId & "')"
            dt = DbOperateUtils.GetDataTable(lsSQL)
        ElseIf FillComBox.Name = "CboConsumer" Then
            dt = DbOperateUtils.GetDataTable("SELECT  * from M_CUSTOMER_T")
        ElseIf FillComBox.Name = "CboMoType" Then
            dt = DbOperateUtils.GetDataTable("select * from motype_t")
        ElseIf FillComBox.Name = "CboSeriesID" Then
            dt = DbOperateUtils.GetDataTable("SELECT [SeriesID],[SeriesName] FROM [m_Series_t] WHERE Usey='Y'")
        ElseIf FillComBox.Name = "cobLineQuery" Then
            Dim sql As String = "SELECT lineid,lineid from Deptline_t A JOIN m_Dept_t B ON A.deptid=B.deptid where B.FACTORYID='" & VbCommClass.VbCommClass.Factory & "'"
            If Not String.IsNullOrEmpty(VbCommClass.VbCommClass.profitcenter) Then
                sql = sql + " and b.profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'"
            End If
            dt = DbOperateUtils.GetDataTable(sql)
        End If

        FillComBox.Items.Add("ALL")

        For i As Integer = 0 To dt.Rows.Count - 1
            If FillComBox.Name = "CboDept" Then
                FillComBox.Items.Add(dt.Rows(i)("deptid").ToString & "---" & dt.Rows(i)("djc").ToString)
            ElseIf FillComBox.Name = "cobLineQuery" Then
                FillComBox.Items.Add(dt.Rows(i)(0).ToString)
            Else
                FillComBox.Items.Add(dt.Rows(i)(0).ToString & "---" & dt.Rows(i)(1).ToString)
            End If
        Next

        FillComBox.Text = CStr(FillComBox.Items.Item(0))
    End Sub

    Private Sub FillComboAdd(ByVal o_FillComBox As ComboBox)
        Dim dt As DataTable = Nothing
        Try
            If o_FillComBox.Name = "CboSeriesID" Then
                dt = DbOperateUtils.GetDataTable("SELECT [SeriesID],[SeriesName] FROM [m_Series_t] WHERE Usey='Y'")
            End If

            o_FillComBox.Items.Add("ALL")

            For i As Integer = 0 To dt.Rows.Count - 1
                listSerial.Add(dt.Rows(i)(0).ToString & "---" & dt.Rows(i)(1).ToString)
            Next
            o_FillComBox.Items.AddRange(listSerial.ToArray())
            o_FillComBox.Text = CStr(o_FillComBox.Items.Item(0)) '默认选中 "ALL"
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "事件"
    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)
        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts
    End Sub

    Private Sub FrmMoMain_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim TabTrans As New TextHandle
        TabTrans.TabTransEnter(sender, e)
        TabTrans = Nothing
    End Sub


    Private Sub ButCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


    Private Sub CboDept_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            QueryDataToGrid()
        End If
    End Sub

    Private Sub CobMono_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ComBoxFlag = False Then
            ComBoxFlag = True
            Exit Sub
        Else
            DgMoData.Rows.Clear()
            TlelCount.Text = "0"
        End If
    End Sub

    '结案
    Private Sub StopFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopFile.Click
        Dim lsSQL As String = ""
        If DgMoData.Rows.Count < 1 Then Exit Sub
        If DgMoData.CurrentRow.Cells(enumDgMoData.MOID).Value.ToString = "" Then Exit Sub
        If MessageBox.Show("你是否对该工单进行结案？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            lsSQL = " UPDATE m_Mainmo_t set FinalY='Y',EstateID='" & enumMOState.Close & "'," & _
                    " Finalman='" & SysMessageClass.UseId & "',Finaltime=getdate() " & _
                    " WHERE Moid='" & DgMoData.CurrentRow.Cells(enumDgMoData.MOID).Value.ToString & "'"
            DbOperateUtils.ExecSQL(lsSQL)
            MessageBox.Show("工单已成功结案...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            QueryDataToGrid()
        End If
    End Sub

    Private Sub CheckFiny_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DgMoData.Rows.Clear()
        TlelCount.Text = "0"
    End Sub

    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        Me.LblInfo.Text = String.Empty

        _MOList.Clear()
        QueryDataToGrid()
    End Sub

    Private Sub CobFactory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CboDept.Items.Count > 0 Then
            CboDept.SelectedIndex = 0
        End If
    End Sub

    Private Sub ExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    '取消结案
    Private Sub ToolReEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReEnd.Click
        Dim lsSQL As String = ""
        If DgMoData.Rows.Count < 1 Then Exit Sub
        If DgMoData.CurrentRow.Cells(GridColZero).Value.ToString = "" Then Exit Sub

        If MessageBox.Show("你是否取消对该工单进行结案？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            lsSQL = " Update m_Mainmo_t set FinalY='N',EstateID='" & enumMOState.WIP & "'," & _
                    " Finalman='" & SysMessageClass.UseId.ToLower & "',Finaltime=null " & _
                    " Where Moid='" & DgMoData.CurrentRow.Cells(enumDgMoData.MOID).Value.ToString & "'"
            DbOperateUtils.ExecSQL(lsSQL)
            MessageBox.Show("工单已成功取消结案...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            QueryDataToGrid()
        End If
    End Sub

    '冻结
    Private Sub ToolHandle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHandle.Click
        Dim lsSQL As String = ""
        If DgMoData.Rows.Count < 1 Then Exit Sub
        If DgMoData.CurrentRow.Cells(GridColZero).Value.ToString = "" Then Exit Sub 'GridColZero
        If MessageBox.Show("你是否对该工单进行扫描冻结,产线将无法进行该工单扫描？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            lsSQL = " Update m_Mainmo_t set FinalY='D',EstateID='8',Finalman='" & SysMessageClass.UseId & "',Finaltime=getdate() " & _
                    " Where Moid='" & DgMoData.CurrentRow.Cells(enumDgMoData.MOID).Value.ToString & "'"
            DbOperateUtils.ExecSQL(lsSQL)
            MessageBox.Show("工单已成功冻结扫描...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            QueryDataToGrid()
        End If
    End Sub

    '取消冻结
    Private Sub ToolUhanlde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolUhanlde.Click
        Dim lsSQL As String = ""
        If DgMoData.Rows.Count < 1 Then Exit Sub
        If DgMoData.CurrentRow.Cells(enumDgMoData.MOID).Value.ToString = "" Then Exit Sub
        If MessageBox.Show("你是否取消该工单进行扫描冻结,产线将恢复？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            lsSQL = " UPDATE m_Mainmo_t set FinalY='N',EstateID='8',Finalman='" & SysMessageClass.UseId & "',Finaltime=getdate() " & _
                    " WHERE Moid='" & DgMoData.CurrentRow.Cells(enumDgMoData.MOID).Value.ToString & "'"
            DbOperateUtils.ExecSQL(lsSQL)
            MessageBox.Show("工单已成功取消冻结扫描...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            QueryDataToGrid()
        End If
    End Sub

    Private Sub ToolPrint_Click(sender As Object, e As EventArgs) Handles ToolPrint.Click
        If CheckMoStatus(ActionType.PrintMo) Then
            Exit Sub
        End If
    End Sub

    Private Sub ToolMOCutCard_Click(sender As Object, e As EventArgs) Handles ToolMOCutCard.Click
        Try
            If _MOList.Count <= 0 Then
                MessageUtils.ShowInformation("请先选择工单！")
                Exit Sub
            End If
            PrintMOCutCard("", _MOList)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMoMain", "ToolMOCutCard_Click", "RCard")
        Finally
            If m_blnNeedClear Then
                _MOList.Clear()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' 同时打印裁线卡和流程卡
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolPrintCutAndRCard_Click(sender As Object, e As EventArgs) Handles ToolPrintCutAndRCard.Click
        Dim o_strNeedPrintCutCardList As String = ""
        If _MOList.Count <= 0 Then
            MessageUtils.ShowInformation("请先选择工单！")
            Exit Sub
        End If

        PrintMOCutCardNotShow(o_strNeedPrintCutCardList, "", _MOList)

        PrintMOCutCardAndRunCard(o_strNeedPrintCutCardList, "", _MOList)

    End Sub


    Private Sub ToolERPDownload_Click(sender As Object, e As EventArgs) Handles ToolERPDownload.Click
        Me.LblInfo.Text = ""
        'If Me.TxtMoNo.Text <> String.Empty Then

        'End If
        QueryERPDataToGrid()
    End Sub

    Private Sub DgMoData_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgMoData.CellValueChanged
        Dim o_stcMO As MOComBusiness.stcMO = New MOComBusiness.stcMO
        If DgMoData.Rows.Count <= 0 Then Exit Sub
        o_stcMO.MOID = CStr(DgMoData.CurrentRow.Cells(enumDgMoData.MOID).Value)
        o_stcMO.LineID = CStr(DgMoData.CurrentRow.Cells(enumDgMoData.lineid).Value)
        o_stcMO.PartID = CStr(DgMoData.CurrentRow.Cells(enumDgMoData.PartID).Value)
        o_stcMO.MOQty = CStr(DgMoData.CurrentRow.Cells(enumDgMoData.MoQty).Value)
        o_stcMO.ParentMo = CStr(DgMoData.CurrentRow.Cells(enumDgMoData.ParentMo).Value)
        If CBool(DgMoData.CurrentRow.Cells(enumDgMoData.iSelect).EditedFormattedValue) = True Then
            txtMo.Text = CStr(DgMoData.CurrentRow.Cells(enumDgMoData.MOID).Value)
            If Not _MOList.Contains(o_stcMO) Then
                _MOList.Add(o_stcMO)
            End If
        Else
            If _MOList.Contains(o_stcMO) Then
                _MOList.Remove(o_stcMO)
            End If
        End If
    End Sub

    Private Sub CheckAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAll.CheckedChanged
        For Each row As DataGridViewRow In DgMoData.Rows
            row.Cells(0).Value = CheckAll.Checked
            Dim o_stcMO As MOComBusiness.stcMO = New MOComBusiness.stcMO
            o_stcMO.MOID = CStr(row.Cells(enumDgMoData.MOID).Value)
            o_stcMO.PartID = CStr(row.Cells(enumDgMoData.PartID).Value)
            o_stcMO.LineID = CStr(row.Cells(enumDgMoData.lineid).Value)
            o_stcMO.MOQty = CStr(row.Cells(enumDgMoData.MoQty).Value)
            o_stcMO.ParentMo = CStr(row.Cells(enumDgMoData.ParentMo).Value)
            If Not _MOList.Contains(o_stcMO) Then
                If CheckAll.Checked = True Then
                    _MOList.Add(o_stcMO)
                End If
            Else
                If _MOList.Count > 0 AndAlso _MOList.Contains(o_stcMO) Then
                    If CheckAll.Checked = False Then
                        _MOList.Remove(o_stcMO)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub DgMoData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgMoData.CellContentClick
        If DgMoData.Rows.Count <= 0 Then Exit Sub
        Dim o_stcMO As MOComBusiness.stcMO = New MOComBusiness.stcMO
        o_stcMO.MOID = CStr(DgMoData.CurrentRow.Cells(enumDgMoData.MOID).Value)
        o_stcMO.PartID = CStr(DgMoData.CurrentRow.Cells(enumDgMoData.PartID).Value)
        o_stcMO.LineID = CStr(DgMoData.CurrentRow.Cells(enumDgMoData.lineid).Value)
        o_stcMO.MOQty = CStr(DgMoData.CurrentRow.Cells(enumDgMoData.MoQty).Value)
        o_stcMO.ParentMo = CStr(DgMoData.CurrentRow.Cells(enumDgMoData.ParentMo).Value)
        If CBool(DgMoData.CurrentRow.Cells(enumDgMoData.iSelect).EditedFormattedValue) = True Then
            txtMo.Text = CStr(DgMoData.CurrentRow.Cells(enumDgMoData.MOID).Value)
            If Not _MOList.Contains(o_stcMO) Then
                _MOList.Add(o_stcMO)
            End If
        Else
            If _MOList.Count > 0 AndAlso _MOList.Contains(o_stcMO) Then
                _MOList.Remove(o_stcMO)
            End If
        End If
    End Sub

#End Region

#Region "方法"


    Private Sub LoadDataInGrid(Optional ByVal FiterSqlStr As String = "", Optional ByVal blnRCardMO As Boolean = False)
        Dim K As Integer
        Dim UserDg As DataTable
        Dim Sqlstr As String
        DgMoData.Rows.Clear()
        DgMoData.ScrollBars = ScrollBars.None

        If blnRCardMO = True Then
            Sqlstr = " SELECT DISTINCT TOP 100 d.partname,a.MOID,a.PartID,a.Cusid,(a.SeriesID+'---'+ g.SeriesName) as SeriesID ," & _
                     " a.factory,a.deptid,a.lineid," & _
                     " (a.MoQty * isnull(part.AmountQty,'1')) moqty, " & _
                     " a.PpidPrtqty, a.PkgPrtqty, a.Createuser, a.Createtime, " & _
                     " b.motype,c.statename,e.cusname,f.djc, a.OrderNO, a.Orderseq, a.DeliveryDate, a.ScheFinishDate,a.version,a.po,a.ParentMo " & _
                     " FROM {0} a left join motype_t b on a.typeid=b.typeid " & _
                     " LEFT JOIN mostate c on a.EstateID=c.stateid  " & _
                     " LEFT JOIN Matter_tab d on a.partid=d.partid " & _
                     " LEFT JOIN m_Customer_t e ON a.Cusid=e.Cusid " & _
                     " LEFT JOIN m_Dept_t f on a.Deptid=f.Deptid" & _
                     " LEFT JOIN m_Series_t g on a.SeriesID=g.SeriesID" & _
                     " LEFT JOIN m_PartContrast_t part on a.partid = part.TAvcPart and part.PavcPart= a.ParentMOPartID"
            Sqlstr = String.Format(Sqlstr, "m_RCardMO_t")
        Else
            Sqlstr = " SELECT DISTINCT TOP 100 d.partname,a.MOID,a.PartID,a.Cusid,(a.SeriesID+'---'+ g.SeriesName) as SeriesID ," & _
                     " a.factory,a.deptid,a.lineid,a.MoQty,a.PpidPrtqty,a.PkgPrtqty,a.Createuser,a.Createtime, " & _
                     " b.motype,c.statename,e.cusname,f.djc, a.OrderNO, a.Orderseq, a.DeliveryDate, a.ScheFinishDate,a.version,a.po ,a.ParentMo  " & _
                     " FROM {0} a left join motype_t b on a.typeid=b.typeid " & _
                     " LEFT JOIN mostate c on a.EstateID=c.stateid  " & _
                     " LEFT JOIN Matter_tab d on a.partid=d.partid " & _
                     " LEFT JOIN m_Customer_t e ON a.Cusid=e.Cusid " & _
                     " LEFT JOIN m_Dept_t f on a.Deptid=f.Deptid" & _
                     " LEFT JOIN m_Series_t g on a.SeriesID=g.SeriesID"
            Sqlstr = String.Format(Sqlstr, "m_MainMO_t")
        End If

        UserDg = DbOperateUtils.GetDataTable(Sqlstr & FiterSqlStr)


        For K = 0 To UserDg.Rows.Count - 1
            DgMoData.Rows.Add("False", UserDg.Rows(K)("Moid"), UserDg.Rows(K)("PartID"), UserDg.Rows(K)(GridColZero), _
                              UserDg.Rows(K)("Cusid"), UserDg.Rows(K)("CusName"), _
                              UserDg.Rows(K)("SeriesID"), _
                              UserDg.Rows(K)("factory"), _
                              UserDg.Rows(K)("Deptid"), UserDg.Rows(K)("djc"), UserDg.Rows(K)("lineid"),
                              UserDg.Rows(K)("MoQty"), UserDg.Rows(K)("PpidPrtqty"), UserDg.Rows(K)("PkgPrtqty"),
                              UserDg.Rows(K)("motype"), UserDg.Rows(K)("statename"), "", _
                              UserDg.Rows(K)("OrderNO"), UserDg.Rows(K)("Orderseq"), UserDg.Rows(K)("po"), _
                              UserDg.Rows(K)("DeliveryDate"), UserDg.Rows(K)("ScheFinishDate"), _
                              UserDg.Rows(K)("Createuser"), _
                              UserDg.Rows(K)("Createtime"), _
                              UserDg.Rows(K)("version"), _
                              UserDg.Rows(K)("ParentMo"))
        Next

        DgMoData.ScrollBars = ScrollBars.Both
        TlelCount.Text = CStr(UserDg.Rows.Count)
        DgMoData.AutoResizeColumns()
        DgMoData.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub QueryDataToGrid(Optional ByVal blnRCardMode As Boolean = False)

        Dim MoControl As Control
        Dim SqlStr As String = ""
        Dim MoFlag As Boolean
        For Each MoControl In GubQertyCondition.Controls
            If TypeOf MoControl Is ComboBox Then
                If UCase(MoControl.Text) <> "ALL" Then
                    MoFlag = True
                    Exit For
                End If
            End If
        Next

        Dim FiterSqlStr As String = ""
        FiterSqlStr = GetFiterString(blnRCardMode)
        If FiterSqlStr = "" Then
            TlelCount.Text = "0"
            Exit Sub
        End If
        LoadDataInGrid(FiterSqlStr, blnRCardMode)
    End Sub

    Private Function CobTextInstr(ByVal MoComBox As ComboBox, Optional blnSplit As Boolean = False, Optional strSplitChar As String = "-") As String

        If MoComBox.Text = "" Then
            CobTextInstr = ""
            Exit Function
        End If

        If blnSplit Then
            Dim I As Integer = InStr(MoComBox.Text.Trim, strSplitChar)
            Dim LineStr As String = MoComBox.Text.Substring(0, I - 1)
            CobTextInstr = LineStr
        Else
            CobTextInstr = MoComBox.Text.Trim()
        End If

        Return CobTextInstr
    End Function

    Private Function GetFiterString(Optional blnRCardMO As Boolean = False) As String

        Dim SqlStr As String = ""
        Dim MoComBoxStr As String = ""
        Dim mos As String = Nothing

        For Each sMO As String In TxtMoNo.Text.Trim.Split(CChar(vbNewLine))
            If Not String.IsNullOrEmpty(sMO.Trim) Then
                'Add by cq 20160419
                If Not HaveChildPnInfo(sMO.Trim, mos, blnRCardMO) Then
                    mos &= "'" & sMO.ToUpper.Trim & "'" & ","
                Else
                    'do nothing
                End If
            End If
        Next

        If Not String.IsNullOrEmpty(mos) Then
            mos = mos.Trim(CChar(","))
            SqlStr = " WHERE A.Moid IN(" & mos & ")"
        End If

        If UCase(CboMoType.Text.Trim) <> "ALL" Then
            MoComBoxStr = CobTextInstr(CboMoType)
            If SqlStr = "" Then
                SqlStr = " WHERE a.typeid='" & MoComBoxStr & "'"
            Else
                SqlStr = SqlStr & " AND a.typeid='" & MoComBoxStr & "'"
            End If
        End If

        If UCase(cboPartID.Text.Trim) <> "ALL" Then
            MoComBoxStr = CobTextInstr(cboPartID)
            If SqlStr = "" Then
                SqlStr = " WHERE a.PartID LIKE '" & MoComBoxStr & "%'"
            Else
                SqlStr = SqlStr & " AND a.PartID LIKE '" & MoComBoxStr & "%'"
            End If
        End If

        If UCase(CboConsumer.Text.Trim) <> "ALL" Then
            MoComBoxStr = CobTextInstr(CboConsumer, True, "---")
            If SqlStr = "" Then
                SqlStr = " WHERE a.CusID='" & MoComBoxStr & "'"
            Else
                SqlStr = SqlStr & " and a.CusID='" & MoComBoxStr & "'"
            End If
        End If

        If UCase(CboSeriesID.Text.Trim) <> "ALL" Then
            MoComBoxStr = CobTextInstr(CboSeriesID, True, "---")
            If SqlStr = "" Then
                SqlStr = " WHERE a.SeriesID='" & MoComBoxStr & "'"
            Else
                SqlStr = SqlStr & " AND a.SeriesID='" & MoComBoxStr & "'"
            End If
        End If

        If UCase(CboDept.Text.Trim) <> "ALL" Then
            MoComBoxStr = CobTextInstr(CboDept)
            If SqlStr = "" Then
                SqlStr = " WHERE a.Deptid='" & MoComBoxStr & "'"
            Else
                SqlStr = SqlStr & " AND a.Deptid='" & MoComBoxStr & "'"
            End If
        End If

        If UCase(cobLineQuery.Text.Trim) <> "ALL" AndAlso Not String.IsNullOrEmpty(cobLineQuery.Text) Then
            If SqlStr = "" Then
                SqlStr = " WHERE a.lineid='" & cobLineQuery.Text & "'"
            Else
                SqlStr = SqlStr & " AND a.lineid='" & cobLineQuery.Text & "'"
            End If
        End If

        If SqlStr = "" Then
            SqlStr = " WHERE CONVERT(datetime,CONVERT(varchar(10), Createtime,120)) BETWEEN '" & DtStarDate.Value.ToShortDateString & "' AND '" & DtEndDate.Value.ToShortDateString & "'"
        Else
            SqlStr = SqlStr & " AND CONVERT(datetime,CONVERT(varchar(10), Createtime,120)) BETWEEN '" & DtStarDate.Value.ToShortDateString & "' and '" & DtEndDate.Value.ToShortDateString & "'"
        End If

        'Add by CQ 20151010
        If SqlStr = "" Then
            SqlStr = " WHERE a.Factory='" & VbCommClass.VbCommClass.Factory & "'"
        Else
            SqlStr = SqlStr + "  AND a.Factory='" & VbCommClass.VbCommClass.Factory & "' "
        End If
        If Not String.IsNullOrEmpty(VbCommClass.VbCommClass.profitcenter) Then
            SqlStr = SqlStr + " AND a.profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'"
        End If
        Return SqlStr
    End Function

    Private Function HaveChildPnInfo(ByVal MO As String, Optional ByRef mos As String = "", Optional ByVal blnRCardMO As Boolean = False) As Boolean
        Dim sql As String = Nothing
        Dim sMOPartID As String = String.Empty
        Try
            'A. First get the Need MO, remove the 2:不展開但自動開立工單
            sMOPartID = MOComBusiness.GetPartIDByMO(MO.Trim)

            '获取该工单的料号及其下面的所有子件的料号
            sql = _
                    "SELECT DISTINCT A.WEIGHT, A.PARTID, A.MOID" + vbCrLf + _
                    "  FROM (SELECT A.MOID, A.PARTID, 1 AS WEIGHT" + vbCrLf + _
                    "          FROM {0} A LEFT JOIN dbo.m_PartContrast_t PART ON A.PARTID =PART.TAvcPart AND part.PAvcPart='" & sMOPartID & "'" + vbCrLf + _
                    "         WHERE     A.PARENTMO = '" & MO.Trim & "'" + vbCrLf + _
                    "               AND A.MOID <> PARENTMO" + vbCrLf + _
                    "               AND A.ESTATEID <> 'A'" + vbCrLf + _
                    "               AND PART.Extensible ='Y'" + vbCrLf + _
                    "        UNION" + vbCrLf + _
                    "        SELECT MOID, PARTID, 0 AS WEIGHT" + vbCrLf + _
                    "          FROM {0} A " + vbCrLf + _
                    "         WHERE A.MOID = '" & MO.Trim & "'" + vbCrLf + _
                    " ) A" + vbCrLf + _
                    "ORDER BY WEIGHT, A.PARTID, A.MOID"
            If blnRCardMO Then
                sql = String.Format(sql, "m_RCardMO_t")
            Else
                sql = String.Format(sql, "m_MainMO_t")
            End If

            Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
                If dt.Rows.Count = 1 Then '说明该工单没有子件料号，很可能是子件工单
                    HaveChildPnInfo = False
                ElseIf dt.Rows.Count > 1 Then '存在子件工单，该工单肯能是成套工单
                    HaveChildPnInfo = True
                    For Each dr As DataRow In dt.Rows
                        mos &= "'" & dr.Item(2).ToString.ToUpper.Trim() & "'" + ","
                    Next
                End If
            End Using
        Catch ex As Exception
        End Try
    End Function

    Private Function CheckMoStatus(ByVal actionType As ActionType) As Boolean
        Dim sqlString As String = ""
        Select Case actionType
            Case actionType.SaveBatch
                sqlString = "SELECT MOID FROM M_MainMO_t WHERE MOID='" & txtMo.Text.Trim & "' AND ESTATEID NOT IN(1,3)"
                Return DbOperateUtils.GetRowsCount(sqlString) > 0
            Case actionType.CancelBatch
                sqlString = "SELECT MOID FROM M_MainMO_t WHERE PARENTMO='" & txtMo.Text.Trim & "' AND MOID<>'" & txtMo.Text.Trim & "' AND ESTATEID NOT IN(1,3)"
                If DbOperateUtils.GetRowsCount(sqlString) > 0 Then
                    MessageBox.Show("工单:" + txtMo.Text + " 的分批工单中存在再分批或已在制程中或完工结案", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lblBatchMsg.Text = "工单:" + txtMo.Text + " 的分批工单中存在再分批或已在制程中或完工结案"
                    Return True
                End If
                sqlString = "SELECT MOID FROM M_MainMO_t WHERE  MOID<>'" & txtMo.Text.Trim & "' AND PARENTMO IN( SELECT MOID FROM M_MAINMO_T WHERE ESTATEID=2 AND FINALY='Y' AND MOID='" & txtMo.Text & "')" '2.工單成功分批并結案
                If DbOperateUtils.GetRowsCount(sqlString) = 0 Then
                    MessageBox.Show("工单:" + txtMo.Text + "未做过分批操作,不允许做取消分批操作", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lblBatchMsg.Text = "工单:" + txtMo.Text + "未做过分批操作,不允许做取消分批操作"
                    Return True
                End If
            Case actionType.PrintMo
                sqlString = "SELECT MOID FROM M_MainMO_t WHERE MOID='" & txtMo.Text.Trim & "' AND ESTATEID= '" & enumMOState.RBatchAndClose & "' AND FINALY='Y'"
                If DbOperateUtils.GetRowsCount(sqlString) = 1 Then
                    MessageBox.Show("工单：" + txtMo.Text + "已经分批,不需要列印流程卡", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return True
                End If
        End Select
    End Function

    Private Sub QueryERPDataToGrid()
        Dim o_dtPartCount As New DataTable
        Dim o_strCustID As String = "", o_strSeriesID As String = ""
        Dim partNumberList As New ArrayList
        Dim o_strFactory As String = VbCommClass.VbCommClass.Factory
        Try
            DgMoData.Rows.Clear()
            If TxtMoNo.Text.Trim = "" Then
                LblInfo.Text = "工单编号不能为空..."
                Exit Sub
            End If

            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                'o_dtPartCount = OracleOperateUtils.GetDataTableSap(SapCommon.GetSql2ErpSap(TxtMoNo.Text, VbCommClass.VbCommClass.profitcenter))
                o_dtPartCount = DbOperateUtils.GetDataTable(SapCommon.GetSql2ErpSap(TxtMoNo.Text, VbCommClass.VbCommClass.profitcenter))
            Else
                o_dtPartCount = OracleOperateUtils.GetDataTable(SapCommon.GetSql2Erp(TxtMoNo.Text, VbCommClass.VbCommClass.profitcenter))
            End If

            If o_dtPartCount.Rows.Count > 0 Then

                If VbCommClass.VbCommClass.IsConSap = "Y" Then
                    Dim sFactory As String = o_dtPartCount.Rows(0).Item("werks").ToString
                    If sFactory <> VbCommClass.VbCommClass.Factory Then
                        Dim msg As String = "登录工厂代码" + VbCommClass.VbCommClass.Factory + "与查询工单" & Me.TxtMoNo.Text.Trim() &
                                            "工厂代码" + sFactory + "不一致，请确认或者切换登录工厂"
                        LblInfo.Text = msg
                        Me.TxtMoNo.Text = ""
                        Exit Sub
                    End If
                End If

                For i As Integer = 0 To o_dtPartCount.Rows.Count - 1
                    '先查TT，还查不到，再给default 。
                    If VbCommClass.VbCommClass.IsConSap = "N" Then
                        'cq 20160616, need get latest Tiptop CustID
                        o_strCustID = SapCommon.GetCustIDFromTT(o_dtPartCount.Rows.Item(i)("sfb05").ToString)
                    End If


                    If String.IsNullOrEmpty(o_strCustID) Then
                        o_strCustID = "99"
                    End If

                    If VbCommClass.VbCommClass.IsConSap = "N" Then
                        o_strSeriesID = SapCommon.GetSeriesIDFromTT(o_dtPartCount.Rows.Item(i)("sfb05").ToString)
                    End If

                    If String.IsNullOrEmpty(o_strSeriesID) Then
                        o_strSeriesID = "018"
                    End If

                    '下载BOM
                    Dim msg As String = ""
                    Dim partNumber As String = o_dtPartCount.Rows.Item(i)("sfb05").ToString

                    '******************************田玉琳 20180402 开始******************************
                    '每次都重新下载9开头,料号相关数据 / 多个时，只下载一次
                    If partNumberList.Contains(partNumber) = False Then
                        If MOComBusiness.DownloadBom(partNumber, msg) = False Then
                            Me.lblMsg.Text = msg
                            Exit Sub
                        End If
                        partNumberList.Add(partNumber)
                    End If
                    '******************************田玉琳 20180402 结束******************************

                    'iSelect, 工单编号sfb01, 料件编号sfb05, 品名partname, (客户), (客户名称), (系列别) ( lxxt,工厂名称),
                    '生产部门tc_imc03,   (tc_imc03, 部门名称) 生产线别SFB82, 工单数量SFB08,  (成品条码数量),  ('' 外箱打印数量)
                    '工单类型, 工单状态,  ('' as 生产途程）订单编号sfb22, 订单项次sfb221, 订单预计交货日期, 工单预计结束生产日期, 维护人员，时间,verison

                    Me.DgMoData.Rows.Add(False, o_dtPartCount.Rows.Item(i)("sfb01").ToString, o_dtPartCount.Rows.Item(i)("sfb05").ToString, _
                                  o_dtPartCount.Rows.Item(i)("partname").ToString, o_strCustID, "", o_strSeriesID, o_strFactory, _
                    o_dtPartCount.Rows.Item(i)("tc_imc03").ToString, o_dtPartCount.Rows.Item(i)("tc_imc03").ToString, _
                    o_dtPartCount.Rows.Item(i)("sfb82").ToString, o_dtPartCount.Rows.Item(i)("sfb08").ToString, "0", "", _
                    o_dtPartCount.Rows.Item(i)("sfb02").ToString, o_dtPartCount.Rows.Item(i)("sfb04").ToString, "", _
                    o_dtPartCount.Rows.Item(i)("sfb22").ToString, _
                    o_dtPartCount.Rows.Item(i)("sfb221").ToString, _
                    o_dtPartCount.Rows.Item(i)("oeb15"),
                    o_dtPartCount.Rows.Item(i)("sfb15"), "", "", GetVersion(o_dtPartCount.Rows.Item(i)("IMA021").ToString)
                                  )

                Next
            Else
                LblInfo.Text = "工单编号在ERP中不存在..."
                Exit Sub
            End If

            Call SaveTiptopMO()

            'refesh the data cq20160825
            QueryDataToGrid(True)
        Catch ex As Exception
            Throw ex
        Finally
            o_dtPartCount.Dispose()
        End Try
    End Sub

    Private Sub SaveTiptopMO()
        Dim strItemNum As String = "0", strChildMoid As String = "", o_strSerial As String = ""
        Dim strSQL As String = "", mos As String = Nothing
        Dim Sql As New System.Text.StringBuilder
        Dim ItemSeq As String = String.Empty
        Dim o_strCreateUserID As String = String.Empty
        Me.lblMsg.Text = String.Empty

        Try
            ' Save auto download from TT , cq 20160907
            For Each Row As DataGridViewRow In DgMoData.Rows
                If Row.Index = DgMoData.Rows.Count Then Exit For
                If Row.Cells(enumDgMoData.MOID).Value Is Nothing Then Exit Sub

                'If  Row.Cells(enumDgMoData.PartID).Value
                ' If Not Row.Cells(enumDgMoData.iSelect).FormattedValue Is Nothing AndAlso Row.Cells(enumDgMoData.iSelect).FormattedValue.ToString = "True" Then
                Sql.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM m_RCardMO_t WHERE moid='" & Row.Cells(enumDgMoData.MOID).Value.ToString & "' and Factory='" & VbCommClass.VbCommClass.Factory & "' and profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "' )")
                Sql.Append("INSERT INTO m_RCardMO_t(Moid,PartID,Cusid,Deptid,lineid,Moqty")
                Sql.Append(",Typeid,EstateID,Plandate,Createuser,Createtime,FinalY,Finalman,Finaltime,Factory,profitcenter")
                Sql.Append(" ,ParentMo, VERSION,SeriesID,ORDERNO,Orderseq,DeliveryDate,ScheFinishDate,PpidprtCount,PackingCount,ProductReprintCount,PackingReprintCount,status,ParentMOPartID)")
                Sql.Append(" VALUES('" & Row.Cells(enumDgMoData.MOID).Value & "','" & Row.Cells(enumDgMoData.PartID).Value & "','" & Row.Cells(enumDgMoData.Cusid).Value & "',")
                Sql.Append("'" & Row.Cells(enumDgMoData.Deptid).Value & "','" & Row.Cells(enumDgMoData.lineid).Value & "','" & Row.Cells(enumDgMoData.MoQty).Value & "',")
                Sql.Append("'" & Row.Cells(enumDgMoData.motype).Value & "','5',")
                Sql.Append(" getdate(),'" & SysMessageClass.UseId.ToLower & "',getdate(),'N',NULL,NULL,")
                Sql.Append(" '" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "',")
                Sql.Append(" '" & Row.Cells(enumDgMoData.MOID).Value & "', '" & Row.Cells(enumDgMoData.Version).Value & "',")
                Sql.Append(" '" & Row.Cells(enumDgMoData.SeriesID).Value & "','" & Row.Cells(enumDgMoData.OrderNO).Value & "',")
                Sql.Append(" '" & Row.Cells(enumDgMoData.Orderseq).Value & "','" & Row.Cells(enumDgMoData.DeliveryDate).Value & "','" & Row.Cells(enumDgMoData.ScheFinishDate).Value & "',")
                Sql.Append(" '0','0','0','0','0','" & Row.Cells(enumDgMoData.PartID).Value & "')")
                '**************************************田玉琳 20180306 开始**************************************
                '增加料号相同时处理，把配置数据更新为1
                Sql.AppendFormat(" update m_PartContrast_t set AmountQty = 1,Intime =getdate() where TAvcPart = PAvcPart and TAvcPart = '{0}'", Row.Cells(enumDgMoData.PartID).Value)
                '**************************************田玉琳 20180306 结束**************************************
                Using dt As DataTable = MOComBusiness.GetChildPnByCurrentMoPn(Row.Cells(enumDgMoData.PartID).Value)
                    If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then


                        For Each drChild As DataRow In dt.Rows
                            'L01D3008-YT-R1, L01D5002-R1
                            strItemNum = Microsoft.VisualBasic.Right(drChild.Item("TAvcPart").ToString, Len(drChild.Item("TAvcPart").ToString) - InStr(drChild.Item("TAvcPart").ToString, "-"))

                            '******************************田玉琳 20180402 开始******************************
                            '本不会存在重复数据，如果有重复下载数据，要删除权限才能重新下载
                            strChildMoid = Row.Cells(enumDgMoData.MOID).Value + "-" + (strItemNum).ToString.PadLeft(2, "0")
                            'If Not String.IsNullOrEmpty(ItemSeq) AndAlso ItemSeq = strItemNum Then
                            '    'maybe repeat
                            '    strChildMoid = Row.Cells(enumDgMoData.MOID).Value + "-" + (strItemNum).ToString.PadLeft(3, "0")
                            'Else
                            '    strChildMoid = Row.Cells(enumDgMoData.MOID).Value + "-" + (strItemNum).ToString.PadLeft(2, "0")
                            'End If
                            '******************************田玉琳 20180402 结束******************************

                            ItemSeq = strItemNum
                            Sql.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM m_RCardMO_t WHERE moid='" & strChildMoid & "' and Factory='" & VbCommClass.VbCommClass.Factory & "'and profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "')")
                            Sql.Append(" INSERT INTO m_RCardMO_t(MOID,PARTID,DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,CUSID,CREATEUSER,CREATETIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,")
                            Sql.Append(" VERSION,ORDERNO,SeriesID,Orderseq,DeliveryDate,ScheFinishDate,PpidprtCount,PackingCount,ProductReprintCount,PackingReprintCount,status,ParentMOPartID)").Append(vbNewLine)
                            Sql.Append(" SELECT '" & strChildMoid & "','" & drChild.Item("TAvcPart").ToString & "',DEPTID,LINEID,MOQTY,TYPEID,ESTATEID,CUSID")
                            Sql.Append(",CREATEUSER,CREATETIME,FACTORY,PROFITCENTER,PARENTMO,OLDESTATEID,'" & drChild.Item("version").ToString & "',ORDERNO,SeriesID")
                            Sql.Append(",Orderseq,DeliveryDate,ScheFinishDate,PpidprtCount,PackingCount,ProductReprintCount,PackingReprintCount,status,ParentMOPartID ")
                            Sql.Append(" FROM m_RCardMO_t WHERE MOID='" & Row.Cells(enumDgMoData.MOID).Value & "'").Append(vbNewLine)
                        Next
                    End If
                End Using
            Next

            If Sql.ToString = "" Then Exit Sub
            Try
                DbOperateUtils.ExecSQL(Sql.ToString)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetVersion(ByVal version As String) As String
        Dim arr() As String
        arr = version.Split(CChar("-"))
        If arr.Length > 1 Then
            If arr(arr.Length - 1).Length > 5 Then Return ""
            Return arr(arr.Length - 1)
        End If
        Return ""
    End Function

    Private Sub ToolMORCard_Click(sender As Object, e As EventArgs) Handles ToolMORCard.Click
        Try
            If _MOList.Count <= 0 Then
                MessageUtils.ShowInformation("请先选择工单！")
                Exit Sub
            End If
            PrintMORunCard("", _MOList)
        Catch ex As Exception
        Finally
            If m_blnNeedClear Then
                _MOList.Clear()
            End If
        End Try
    End Sub

    Private Sub PrintMORunCard(Optional ByVal pn As String = "", Optional ByVal o_stcMO As List(Of MOComBusiness.stcMO) = Nothing)  'ByVal pn As string
        Dim errorMsg As String = Nothing
        Dim outputFileList As String = ""
        Dim o_outputFile As String = ""
        Me.LblInfo.Text = String.Empty
        Dim o_tempTiptopVersion As String = ""
        Dim o_blnCheckedParent As Boolean = False
        Dim o_dtRunCardD As New DataTable
        Try

            If o_stcMO.Count >= 1 Then  'Not IsNothing(o_strMO) 
                For Each o_strTempMO As MOComBusiness.stcMO In o_stcMO
                    o_outputFile = Environment.CurrentDirectory + "\" & o_strTempMO.MOID & ".xlsx" 'cq, 20150615,Environment.CurrentDirectory + "\" & RunCardPn & ".xlsx"
                    Dim frmStation As New FrmRunCardImportStation(o_strTempMO.MOID, "Export", False) 'cq20150615,(Me.RunCardId, Me.RunCardPn, "Export", Me.IsQueryOldVersion)
                    frmStation.runCardPartId = o_strTempMO.PartID

                    If HaveChildPnInfo(o_strTempMO.MOID, "", True) Then
                        '打印流程卡明细表,cq 20160825
                        If MOComBusiness.DownloadBom(o_strTempMO.PartID, errorMsg) = False Then
                            Me.LblInfo.Text = errorMsg
                            Exit Sub
                        End If
                        o_dtRunCardD = GetRCardDetailList(o_strTempMO)

                        '不为空才调用
                        If o_dtRunCardD IsNot Nothing Then
                            Call PrintRunCardDetail(o_strTempMO, o_dtRunCardD)
                            outputFileList &= Environment.CurrentDirectory + "\" & o_strTempMO.MOID & ".xlsx" & ","
                        End If
                        Continue For
                    Else
                        'do nothing
                    End If

                    outputFileList &= Environment.CurrentDirectory + "\" & o_strTempMO.MOID & ".xlsx" & ","
                    If Not CheckRCardStatus(o_strTempMO.PartID) Then
                        MessageUtils.ShowError("该工单对应的流程卡[" & o_strTempMO.PartID & "]的状态必须为已完成，请检查！")
                        Me.LblInfo.Text = "该工单对应的流程卡[" & o_strTempMO.PartID & "]的状态必须为已完成，请检查！"
                        m_blnNeedClear = False
                        Exit Sub
                    End If

                    '华为以“9”开头成品料号，系统自动校验版本；3F的产品以”L”开头，系统通过识别“L”,就不用校验版本
                    If o_strTempMO.PartID.StartsWith("9") Then
                        'Check Version
                        '工单客户版本为空 检验裁线卡 流程卡维护的版本和料件规格版本比较 
                        '不为空  TT主件料件规格版本和主工单客户版本校验是否一致 不一致不能打印  一致则检验裁线卡 流程卡维护的版本和料件规格版本
                        Dim strCustVer As String = GetTTCustVerbyMoid(o_strTempMO.ParentMo)

                        Dim strRCardVersion As String = GetRCardVersion(o_strTempMO.PartID)
                        If strCustVer = "" Then

                            o_tempTiptopVersion = GetTTCustVerbyPart(o_strTempMO.PartID) '打印料件规格版本 主件/子件

                            If strRCardVersion.Trim <> o_tempTiptopVersion.Trim Then
                                Me.LblInfo.Text = "料件:[" & o_strTempMO.PartID & "]版本不一致,TipTop 版本为: " & o_tempTiptopVersion & " ,请找工程处理，TKS!"
                                Exit Sub
                            End If
                        Else
                            Dim strTTPartVer As String = ""
                            strTTPartVer = GetTTCustVerbyMoidPart(o_strTempMO.PartID) '主料件规格版本

                            If strTTPartVer.Trim <> strCustVer.Trim Then
                                Me.LblInfo.Text = "工单客户版本为:" & strCustVer & "和BOM版本不一致,请找工程处理，TKS!"
                                Exit Sub
                            Else
                                o_tempTiptopVersion = GetTTCustVerbyPart(o_strTempMO.PartID) '打印料件规格版本 主件/子件

                                If strRCardVersion.Trim <> o_tempTiptopVersion.Trim Then
                                    Me.LblInfo.Text = "料件:[" & o_strTempMO.PartID & "]版本不一致,TipTop 版本为: " & o_tempTiptopVersion & " ,请找工程处理，TKS!"
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If

                    '改成公用一个sql
                    Using dt As DataTable = MoComDB.GetDataTable(RCard.FrmRunCardImportStation.GetExportSql(o_strTempMO.PartID)) 'frmStation.GetExportSql(o_strTempMO.PartID)
                        If dt.Rows.Count > 0 Then
                            dt.TableName = "RunCard"
                            If Import2ExcelAs(frmStation.filePath, o_outputFile, dt, frmStation.GetVariables(dt, o_strTempMO), o_strTempMO.PartID, o_strTempMO.MOID, errorMsg) Then  'outputFile
                                '
                            Else
                                MessageUtils.ShowError(errorMsg)
                            End If
                        Else
                            MessageUtils.ShowError("料件[" & o_strTempMO.PartID & "]找不到对应的流程卡！")
                            Exit Sub
                        End If
                    End Using
                Next

                If outputFileList.Length > 1 Then
                    outputFileList = outputFileList.Substring(0, outputFileList.Length - 1)
                Else
                    If o_blnCheckedParent = True Then
                        ' Me.lblMsg.Text = "你选中的是父工单，该工单没有流程卡 "
                        SetMsg("E", "你选中的是父工单，该工单没有流程卡!! ")
                        Exit Sub
                    Else
                        ' no output, no need show print diaog,cq 20160825
                        Exit Sub
                    End If
                End If

                Using FrmShow As New FrmShowRunCard()
                    FrmShow.filePath = outputFileList
                    FrmShow.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMoMain", "PrintMORunCard", "sys")
            Throw ex
        Finally
            If Not String.IsNullOrEmpty(outputFileList) Then
                For Each outputFile As String In outputFileList.Split(CChar(","))
                    If File.Exists(outputFile) Then
                        File.Delete(outputFile)
                    End If
                Next
            Else
                If File.Exists(o_outputFile) Then
                    File.Delete(o_outputFile)
                End If
            End If
            If m_blnNeedClear Then
                o_stcMO = Nothing
            End If
        End Try
    End Sub
    Private Sub PrintMOCutCardAndRunCard(ByVal strNeedPrintCutCardList As String, _
                                         Optional ByVal pn As String = "", Optional ByVal o_stcMO As List(Of MOComBusiness.stcMO) = Nothing
                                         )
        Dim errorMsg As String = Nothing
        Dim outputFileList As String = ""
        Dim o_outputFile As String = ""
        Me.LblInfo.Text = String.Empty
        Dim o_tempTiptopVersion As String = ""
        Dim o_blnCheckedParent As Boolean = False
        Dim o_dtRunCardD As New DataTable
        Try

            If o_stcMO.Count >= 1 Then
                For Each o_strTempMO As MOComBusiness.stcMO In o_stcMO
                    o_outputFile = Environment.CurrentDirectory + "\" & o_strTempMO.MOID & ".xlsx"
                    Dim frmStation As New FrmRunCardImportStation(o_strTempMO.MOID, "Export", False)
                    frmStation.runCardPartId = o_strTempMO.PartID

                    If HaveChildPnInfo(o_strTempMO.MOID, "", True) Then
                        '打印流程卡明细表,cq 20160825
                        If MOComBusiness.DownloadBom(o_strTempMO.PartID, errorMsg) = False Then
                            Me.LblInfo.Text = errorMsg
                            Exit Sub
                        End If
                        o_dtRunCardD = GetRCardDetailList(o_strTempMO)
                        Call PrintRunCardDetail(o_strTempMO, o_dtRunCardD)
                        outputFileList &= Environment.CurrentDirectory + "\" & o_strTempMO.MOID & ".xlsx" & ","
                        Continue For
                    Else
                        'do nothing
                    End If

                    outputFileList &= Environment.CurrentDirectory + "\" & o_strTempMO.MOID & ".xlsx" & ","
                    If Not CheckRCardStatus(o_strTempMO.PartID) Then
                        MessageUtils.ShowError("该工单对应的流程卡[" & o_strTempMO.PartID & "]的状态必须为已完成，请检查！")
                        Me.LblInfo.Text = "该工单对应的流程卡[" & o_strTempMO.PartID & "]的状态必须为已完成，请检查！"
                        m_blnNeedClear = False
                        Exit Sub
                    End If

                    '华为以“9”开头成品料号，系统自动校验版本；3F的产品以”L”开头，系统通过识别“L”,就不用校验版本
                    '工单客户版本为空 检验裁线卡 流程卡维护的版本和料件规格版本比较 
                    '不为空  检验裁线卡 流程卡维护的版本 和 客户版本校验是否一致 不一致不能打印
                    If o_strTempMO.PartID.StartsWith("9") Then
                        'Check Version
                        Dim strCustVer As String = ""

                        strCustVer = GetTTCustVerbyMoid(o_strTempMO.ParentMo)

                        Dim strRCardVersion As String = GetRCardVersion(o_strTempMO.PartID)
                        If strCustVer = "" Then
                            o_tempTiptopVersion = GetTTCustVerbyPart(o_strTempMO.PartID)

                            If strRCardVersion.Trim <> o_tempTiptopVersion.Trim Then
                                Me.LblInfo.Text = "料件:[" & o_strTempMO.PartID & "]版本不一致,TipTop 版本为: " & o_tempTiptopVersion & " ,请找工程处理，TKS!"
                                Exit Sub
                            End If
                        Else
                            Dim strTTPartVer As String = ""
                            strTTPartVer = GetTTCustVerbyMoidPart(o_strTempMO.ParentMo) '主料件规格版本

                            If strTTPartVer.Trim <> strCustVer.Trim Then
                                Me.LblInfo.Text = "工单客户版本为:" & strCustVer & "和BOM版本不一致 ,请找工程处理，TKS!"
                                Exit Sub
                            Else
                                o_tempTiptopVersion = GetTTCustVerbyPart(o_strTempMO.PartID) '打印料件规格版本 主件/子件

                                If strRCardVersion.Trim <> o_tempTiptopVersion.Trim Then
                                    Me.LblInfo.Text = "料件:[" & o_strTempMO.PartID & "]版本不一致,TipTop 版本为: " & o_tempTiptopVersion & " ,请找工程处理，TKS!"
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If

                    Using dt As DataTable = MoComDB.GetDataTable(frmStation.GetExportSql(o_strTempMO.PartID))
                        If dt.Rows.Count > 0 Then
                            dt.TableName = "RunCard"
                            If Import2ExcelAs(frmStation.filePath, o_outputFile, dt, frmStation.GetVariables(dt, o_strTempMO), o_strTempMO.PartID, o_strTempMO.MOID, errorMsg) Then  'outputFile
                                '
                            Else
                                MessageUtils.ShowError(errorMsg)
                            End If
                        Else
                            MessageUtils.ShowError("料件[" & o_strTempMO.PartID & "]找不到对应的流程卡！")
                            Exit Sub
                        End If
                    End Using
                Next

                '
                If Not String.IsNullOrEmpty(strNeedPrintCutCardList) Then
                    outputFileList = strNeedPrintCutCardList + "," + outputFileList
                End If

                If outputFileList.Length > 1 Then
                    outputFileList = outputFileList.Substring(0, outputFileList.Length - 1)
                Else
                    If o_blnCheckedParent = True Then
                        SetMsg("E", "你选中的是父工单，该工单没有流程卡!! ")
                        Exit Sub
                    Else
                        ' no output, no need show print diaog,cq 20160825
                        Exit Sub
                    End If
                End If

                Using FrmShow As New FrmShowRunCard()
                    FrmShow.filePath = outputFileList
                    FrmShow.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMoMain", "PrintMORunCard", "sys")
            Throw ex
        Finally
            If Not String.IsNullOrEmpty(outputFileList) Then
                For Each outputFile As String In outputFileList.Split(CChar(","))
                    If File.Exists(outputFile) Then
                        File.Delete(outputFile)
                    End If
                Next
            Else
                If File.Exists(o_outputFile) Then
                    File.Delete(o_outputFile)
                End If
            End If
            If m_blnNeedClear Then
                o_stcMO = Nothing
            End If
        End Try
    End Sub

    ''' <summary>
    ''' 打印工单裁线卡
    ''' </summary>
    ''' <param name="pn"></param>
    ''' <param name="o_stcMO"></param>
    ''' <remarks></remarks>
    Private Sub PrintMOCutCard(Optional ByVal pn As String = "", Optional ByVal o_stcMO As List(Of MOComBusiness.stcMO) = Nothing
                                                                                                                          )
        Dim errorMsg As String = Nothing
        Dim outputFileList As String = ""
        Dim o_outputFile As String = ""
        Me.LblInfo.Text = String.Empty
        Dim o_tempTiptopVersion As String = ""
        Dim o_blnCheckedParent As Boolean = False
        Dim o_dtRunCardD As New DataTable
        Try

            If o_stcMO.Count >= 1 Then
                For Each o_strTempMO As MOComBusiness.stcMO In o_stcMO
                    o_outputFile = Environment.CurrentDirectory + "\" & o_strTempMO.MOID & ".xlsx"  '&
                    Dim frmStation As New FrmCutCardImport(o_strTempMO.MOID, "Export", False)
                    frmStation.runCardPartId = o_strTempMO.PartID

                    If HaveChildPnInfo(o_strTempMO.MOID, "", True) Then
                        Continue For
                    Else
                        'do nothing
                    End If

                    outputFileList &= Environment.CurrentDirectory + "\" & o_strTempMO.MOID & ".xlsx" & ","
                    If Not CheckCutCardStatus(o_strTempMO.PartID) Then
                        MessageUtils.ShowError("该工单对应的裁线卡[" & o_strTempMO.PartID & "]的状态必须为已完成，请检查！")
                        Me.LblInfo.Text = "该工单对应的裁线卡[" & o_strTempMO.PartID & "]的状态必须为已完成，请检查！"
                        m_blnNeedClear = False
                        Exit Sub
                    End If

                    '华为以“9”开头成品料号，系统自动校验版本；3F的产品以”L”开头，系统通过识别“L”,就不用校验版本
                    If o_strTempMO.PartID.StartsWith("9") Then
                        'Check Version
                        Dim strCustVer As String = ""

                        strCustVer = GetTTCustVerbyMoidPart(o_strTempMO.ParentMo)

                        Dim strCutCurdVersion As String = GetCutCardVersion(o_strTempMO.PartID)
                        If strCustVer = "" Then

                            o_tempTiptopVersion = GetTTCustVerbyMoid(o_strTempMO.ParentMo)

                            If strCutCurdVersion.Trim <> o_tempTiptopVersion.Trim Then
                                Me.LblInfo.Text = "料件:[" & o_strTempMO.PartID & "]版本不一致,TipTop 版本为: " & o_tempTiptopVersion & " ,请找工程处理，TKS!"
                                Exit Sub
                            End If
                        Else
                            Dim strTTPartVer As String = ""
                            strTTPartVer = GetTTCustVerbyMoidPart(o_strTempMO.ParentMo) '主料件规格版本

                            If strTTPartVer.Trim <> strCustVer.Trim Then
                                Me.LblInfo.Text = "工单客户版本为:" & strCustVer & "和BOM版本不一致,请找工程处理，TKS!"
                                Exit Sub
                            Else
                                o_tempTiptopVersion = GetTTCustVerbyPart(o_strTempMO.PartID) '打印料件规格版本 主件/子件

                                If strCutCurdVersion.Trim <> o_tempTiptopVersion.Trim Then
                                    Me.LblInfo.Text = "料件:[" & o_strTempMO.PartID & "]版本不一致,TipTop 版本为: " & o_tempTiptopVersion & " ,请找工程处理，TKS!"
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If

                    Using dt As DataTable = MoComDB.GetDataTable(RCard.FrmCutCardImportStation.GetExportSql(o_strTempMO.PartID))  'frmStation.GetExportSql(o_strTempMO.PartID)
                        If dt.Rows.Count > 0 Then
                            dt.TableName = "RunCard"
                            If Import2ExcelAsCutCard(frmStation.filePath, o_outputFile, dt, frmStation.GetVariables(dt, o_strTempMO), o_strTempMO.PartID, o_strTempMO.MOID, errorMsg) Then  'outputFile
                                '
                            Else
                                MessageUtils.ShowError(errorMsg)
                            End If
                        Else
                            MessageUtils.ShowError("料件[" & o_strTempMO.PartID & "]找不到对应的裁线卡！")
                            Exit Sub
                        End If
                    End Using
                Next

                If outputFileList.Length > 1 Then
                    outputFileList = outputFileList.Substring(0, outputFileList.Length - 1)
                Else
                    If o_blnCheckedParent = True Then
                        SetMsg("E", "你选中的是父工单，该工单没有裁线卡!! ")
                        Exit Sub
                    Else
                        ' no output, no need show print diaog,cq 20160825
                        Exit Sub
                    End If
                End If

                Using FrmShow As New FrmShowRunCard()
                    FrmShow.filePath = outputFileList
                    FrmShow.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMoMain", "PrintMORunCard", "sys")
            Throw ex
        Finally
            If Not String.IsNullOrEmpty(outputFileList) Then
                For Each outputFile As String In outputFileList.Split(CChar(","))
                    If File.Exists(outputFile) Then
                        File.Delete(outputFile)
                    End If
                Next
            Else
                If File.Exists(o_outputFile) Then
                    File.Delete(o_outputFile)
                End If
            End If
            If m_blnNeedClear Then
                o_stcMO = Nothing
            End If
        End Try
    End Sub

    Private Sub PrintMOCutCardNotShow(ByRef o_strNeedPrintCList As String, _
                                      Optional ByVal pn As String = "", Optional ByVal o_stcMO As List(Of MOComBusiness.stcMO) = Nothing _
                                      )
        Dim errorMsg As String = Nothing
        Dim outputFileList As String = ""
        Dim o_outputFile As String = ""
        Me.LblInfo.Text = String.Empty
        Dim o_tempTiptopVersion As String = ""
        Dim o_blnCheckedParent As Boolean = False
        Dim o_dtRunCardD As New DataTable
        Try

            If o_stcMO.Count >= 1 Then
                For Each o_strTempMO As MOComBusiness.stcMO In o_stcMO
                    o_outputFile = Environment.CurrentDirectory + "\" & o_strTempMO.MOID + "-C" + ".xlsx"  '&
                    Dim frmStation As New FrmCutCardImport(o_strTempMO.MOID, "Export", False)
                    frmStation.runCardPartId = o_strTempMO.PartID

                    If HaveChildPnInfo(o_strTempMO.MOID, "", True) Then
                        Continue For
                    Else
                        'do nothing
                    End If

                    outputFileList &= Environment.CurrentDirectory + "\" & o_strTempMO.MOID + "-C" + ".xlsx" & ","
                    If Not CheckCutCardStatus(o_strTempMO.PartID) Then
                        MessageUtils.ShowError("该工单对应的裁线卡[" & o_strTempMO.PartID & "]的状态必须为已完成，请检查！")
                        Me.LblInfo.Text = "该工单对应的裁线卡[" & o_strTempMO.PartID & "]的状态必须为已完成，请检查！"
                        m_blnNeedClear = False
                        Exit Sub
                    End If

                    '华为以“9”开头成品料号，系统自动校验版本；3F的产品以”L”开头，系统通过识别“L”,就不用校验版本
                    '工单客户版本为空 检验裁线卡 流程卡维护的版本和料件规格版本比较 
                    '不为空  主工单客户版本和主料件规格版本是否一致 不一致不能打印
                    If o_strTempMO.PartID.StartsWith("9") Then
                        'Check Version
                        Dim strCustVer As String = ""
                        strCustVer = GetTTCustVerbyMoid(o_strTempMO.ParentMo)

                        Dim strCutCurdVersion As String = GetCutCardVersion(o_strTempMO.PartID)
                        If strCustVer = "" Then
                            o_tempTiptopVersion = GetTTCustVerbyPart(o_strTempMO.PartID)

                            If strCutCurdVersion.Trim <> o_tempTiptopVersion.Trim Then
                                Me.LblInfo.Text = "料件:[" & o_strTempMO.PartID & "]版本不一致,TipTop 版本为: " & o_tempTiptopVersion & " ,请找工程处理，TKS!"
                                Exit Sub
                            End If
                        Else
                            Dim strTTPartVer As String = GetTTCustVerbyMoidPart(o_strTempMO.ParentMo) '主料件规格版本

                            If strTTPartVer.Trim <> strCustVer.Trim Then
                                Me.LblInfo.Text = "工单客户版本为:" & strCustVer & "和BOM版本不一致,请找工程处理，TKS!"
                                Exit Sub
                            Else
                                o_tempTiptopVersion = GetTTCustVerbyPart(o_strTempMO.PartID) '打印料件规格版本 主件/子件

                                If strCutCurdVersion.Trim <> o_tempTiptopVersion.Trim Then
                                    Me.LblInfo.Text = "料件:[" & o_strTempMO.PartID & "]版本不一致,TipTop 版本为: " & o_tempTiptopVersion & " ,请找工程处理，TKS!"
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                    Using dt As DataTable = MoComDB.GetDataTable(RCard.FrmCutCardImportStation.GetExportSql(o_strTempMO.PartID)) 'frmStation.GetExportSql(o_strTempMO.PartID)
                        If dt.Rows.Count > 0 Then
                            dt.TableName = "RunCard"
                            If Import2ExcelAsCutCard(frmStation.filePath, o_outputFile, dt, frmStation.GetVariables(dt, o_strTempMO), o_strTempMO.PartID, o_strTempMO.MOID, errorMsg) Then  'outputFile
                                '
                            Else
                                MessageUtils.ShowError(errorMsg)
                            End If
                        Else
                            MessageUtils.ShowError("料件[" & o_strTempMO.PartID & "]找不到对应的裁线卡！")
                            Exit Sub
                        End If
                    End Using
                Next

                If outputFileList.Length > 1 Then
                    outputFileList = outputFileList.Substring(0, outputFileList.Length - 1)
                Else
                    If o_blnCheckedParent = True Then
                        SetMsg("E", "你选中的是父工单，该工单没有裁线卡!! ")
                        Exit Sub
                    Else
                        ' no output, no need show print diaog,cq 20160825
                        Exit Sub
                    End If
                End If

                'Using FrmShow As New FrmShowRunCard()
                '    FrmShow.filePath = outputFileList
                '    FrmShow.ShowDialog()
                'End Using
                o_strNeedPrintCList = outputFileList

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMoMain", "PrintMOCutCardNotShow", "RCard")
            Throw ex
        End Try
    End Sub

    Private Function GetRCardDetailList(ByVal o_strTempMO As MOComBusiness.stcMO) As DataTable
        Dim o_strNotExistPartiDList As String = String.Empty
        Dim o_stdPartID As DataTable = Nothing
        Try
            Using dt As DataTable = MOComBusiness.GetRunCardDetailListDataTable(o_strTempMO.PartID)
                'First check 是否已经制作完成
                If MOComBusiness.ExistUnfinishRCard(o_strTempMO.PartID) Then
                    MessageUtils.ShowInformation("该料件下面子件料的流程卡的状态必须为已完成,请检查！！")
                    GetRCardDetailList = Nothing
                    Exit Function
                End If

                If dt.Rows.Count <= 1 Then
                    MessageUtils.ShowInformation("该料件下面没有要显示的子件料,请确认输入的是成套的料件编号或是成套的工单编号！！")
                    GetRCardDetailList = Nothing
                    Exit Function
                End If

                'cq 20160812, ChildPN's MO almost not maintain
                If Val(dt.Rows.Count - 1) < MOComBusiness.GetChildPNCount(o_strTempMO.PartID, dt, o_stdPartID) Then
                    o_strNotExistPartiDList = MOComBusiness.GetNotExistPartIDList(dt, o_stdPartID)
                    MessageUtils.ShowInformation("该料件下面有子件料[" & o_strNotExistPartiDList & "]未完成,请检查！！")
                    Me.LblInfo.Text = "该料件下面有子件料[" & o_strNotExistPartiDList & "]未完成,请检查！！"
                    GetRCardDetailList = Nothing
                    Exit Function
                End If

                dt.Rows.RemoveAt(dt.Rows.Count - 1)
                Call MOComBusiness.GetRunCardDetailListParameters(o_strTempMO.PartID, dt)
                Using dtResult As DataTable = MOComBusiness.ChangeDataTableStyle(o_strTempMO, dt)
                    GetRCardDetailList = dtResult
                End Using
            End Using
            Return GetRCardDetailList
        Catch ex As Exception
            GetRCardDetailList = Nothing
            SysMessageClass.WriteErrLog(ex, "FrmMoMain", "GetRCardDetailList", "RCard")
        End Try
    End Function

    Private Sub PrintRunCardDetail(ByVal o_stcTempMO As MOComBusiness.stcMO, ByVal o_dtRunCardD As DataTable)
        Dim errorMsg As String = Nothing
        Dim outputFileList As String = ""
        Dim o_outputFile As String = ""
        Dim filePath As String = String.Empty
        Dim o_tempTiptopVersion As String = String.Empty
        Try
            If o_dtRunCardD Is Nothing Then Exit Sub

            filePath = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\RunCardDListTemplate.xlsx"  'Environment.CurrentDirectory & "\Templates" & "\RunCardTemplate.xlsx"
            o_outputFile = Environment.CurrentDirectory + "\" & o_stcTempMO.MOID & ".xlsx"

            Dim frmStation As New FrmRunCardImportStation(o_stcTempMO.PartID, "Export", False)
            ' frmStation.runCardPn = Me.RunCardPn
            Dim dtRCardDCopy As DataTable = o_dtRunCardD.Copy()

            If dtRCardDCopy.Rows.Count >= 4 Then
                For i As Integer = 0 To 4
                    dtRCardDCopy.Rows.RemoveAt(0)
                    i = i + 1
                Next
            End If

            Dim m_Assort As String = dtRCardDCopy.Rows(dtRCardDCopy.Rows.Count - 2).Item("QTY")   'CStr(CDbl(dtRCardDCopy.Compute("sum(QTY)", "").ToString) * 15)

            'add IsSynTTSortTime by cq 20190613
            'If m_IsSynTTSortTime = True Then
            '    '0405, 0407 非
            '    If (o_stcTempMO.PartID.Substring(1, 4) = "0409") OrElse o_stcTempMO.PartID.Substring(1, 4) = "0401" Then
            '        Call SapCommon.AutoUploadTimeToTiptop(m_Assort, o_stcTempMO.PartID)
            '    End If
            'End If

            Using o_dt As DataTable = dtRCardDCopy
                If o_dt.Rows.Count > 0 Then
                    o_dt.TableName = "RunCard"
                    If MOComBusiness.Import2ExcelByAsMO(filePath, o_outputFile, o_dt, MOComBusiness.GetRCardListVariable(o_dt, o_stcTempMO), o_stcTempMO.MOID, o_stcTempMO.PartID, errorMsg) Then  'frmStation.GetVariables(dt)
                        'Using frmshow As New FrmShowRunCard()
                        '    frmshow.m_iDirection = 1  '
                        '    frmshow.filePath = o_outputFile
                        '    frmshow.ShowDialog()
                        'End Using
                    Else
                        MessageUtils.ShowError(errorMsg)
                    End If
                Else
                    MessageUtils.ShowError("找不到对应的流程卡明细信息！")
                End If
            End Using

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMoMain", "PrintRunCardDetail", "RCard")
            Throw ex
        Finally
            'If File.Exists(o_outputFile) Then
            '    File.Delete(o_outputFile)
            'End If
        End Try
    End Sub


    Private Sub SetMsg(ByVal type As String, ByVal msg As String)
        Select Case type
            Case "E"
                Me.LblInfo.ForeColor = System.Drawing.Color.Red
            Case "W"
                Me.LblInfo.ForeColor = System.Drawing.Color.Yellow
            Case Else
                'do nothing
        End Select
        Me.LblInfo.Text = msg
    End Sub

    Public Shared Function Import2ExcelAs(ByVal file As String, ByVal outPutFile As String, ByVal dt As DataTable, _
                                             ByVal dics As System.Collections.Generic.Dictionary(Of String, String),
                                            ByVal strPartID As String, ByVal strMOID As String, ByRef errorMsg As String) As Boolean
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Dim o_strPicturePath As String = "", o_strPartIDPicturePath As String = ""
        Try
            workBookDesigner = New WorkbookDesigner
            wk = New Workbook(file)
            workBookDesigner.Workbook = wk

            workBookDesigner.SetDataSource(dt)

            Dim bc1 As DotNetBarcode = New DotNetBarcode(DotNetBarcode.Types.QRCode)
            bc1.SaveFileType = DotNetBarcode.SaveFileTypes.Gif

            o_strPicturePath = Environment.CurrentDirectory + "\" & "barcode.bmp"
            o_strPartIDPicturePath = Environment.CurrentDirectory + "\" & "barcodePartID.bmp"
            bc1.QRSave(strMOID, o_strPicturePath, 3)

            'cq 20161119
            System.IO.File.Copy(o_strPicturePath, o_strPartIDPicturePath, True)

            'for partid qrcode
            Dim bc2 As DotNetBarcode = New DotNetBarcode(DotNetBarcode.Types.QRCode)
            bc2.SaveFileType = DotNetBarcode.SaveFileTypes.Gif
            bc2.QRSave(strPartID, o_strPartIDPicturePath, 3)

            'E3
            'workBookDesigner.Workbook.Worksheets(0).Cells(2, 4).Value = strMOID
            For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
                workBookDesigner.SetDataSource(dic.Key, dic.Value)
            Next

            Dim pictures As Aspose.Cells.Drawing.PictureCollection = workBookDesigner.Workbook.Worksheets(0).Pictures
            'D1
            pictures.Add(0, 3, o_strPicturePath)

            'A1, PartID
            pictures.Add(0, 1, o_strPartIDPicturePath)

            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(outPutFile, SaveFormat.Xlsx)
            Return True
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        Finally
            If Not workBookDesigner Is Nothing Then
                workBookDesigner = Nothing
            End If
            If Not wk Is Nothing Then
                wk = Nothing
            End If
        End Try
    End Function
    Public Shared Function Import2ExcelAsCutCard(ByVal file As String, ByVal outPutFile As String, ByVal dt As DataTable, _
                                            ByVal dics As System.Collections.Generic.Dictionary(Of String, String),
                                           ByVal strPartID As String, ByVal strMOID As String, ByRef errorMsg As String) As Boolean
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Dim o_strPicturePath As String = "", o_strPartIDPicturePath As String = ""
        Try
            workBookDesigner = New WorkbookDesigner
            wk = New Workbook(file)
            workBookDesigner.Workbook = wk

            workBookDesigner.SetDataSource(dt)

            Dim bc1 As DotNetBarcode = New DotNetBarcode(DotNetBarcode.Types.QRCode)
            bc1.SaveFileType = DotNetBarcode.SaveFileTypes.Gif

            o_strPicturePath = Environment.CurrentDirectory + "\" & "barcode.bmp"
            o_strPartIDPicturePath = Environment.CurrentDirectory + "\" & "barcodePartID.bmp"
            bc1.QRSave(strMOID, o_strPicturePath, 3)

            'cq 20161119
            System.IO.File.Copy(o_strPicturePath, o_strPartIDPicturePath, True)

            'for partid qrcode
            Dim bc2 As DotNetBarcode = New DotNetBarcode(DotNetBarcode.Types.QRCode)
            bc2.SaveFileType = DotNetBarcode.SaveFileTypes.Gif
            bc2.QRSave(strPartID, o_strPartIDPicturePath, 3)

            'E3
            'workBookDesigner.Workbook.Worksheets(0).Cells(2, 4).Value = strMOID
            For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
                workBookDesigner.SetDataSource(dic.Key, dic.Value)
            Next

            Dim pictures As Aspose.Cells.Drawing.PictureCollection = workBookDesigner.Workbook.Worksheets(0).Pictures
            'J1, MOID
            pictures.Add(0, 9, o_strPicturePath)

            'C1, PartID
            pictures.Add(0, 2, o_strPartIDPicturePath)

            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(outPutFile, SaveFormat.Xlsx)
            Return True
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        Finally
            If Not workBookDesigner Is Nothing Then
                workBookDesigner = Nothing
            End If
            If Not wk Is Nothing Then
                wk = Nothing
            End If
        End Try
    End Function

    Private Function GetRCardVersion(ByVal PartID As String) As String
        Dim lsSQL As String = String.Empty
        lsSQL = "SELECT DrawingVer FROM m_RCardM_t WHERE partid ='" & PartID & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetRCardVersion = o_dt.Rows(0).Item(0).ToString
            Else
                GetRCardVersion = ""
            End If
        End Using
    End Function

    Private Function GetCutCardVersion(ByVal PartID As String) As String
        Dim lsSQL As String = String.Empty
        lsSQL = "SELECT DrawingVer FROM m_RCardCutM_t WHERE partid ='" & PartID & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetCutCardVersion = o_dt.Rows(0).Item(0).ToString
            Else
                GetCutCardVersion = ""
            End If
        End Using
    End Function

    Private Function CheckRCardStatus(ByVal parPartID As String) As Boolean
        '1.已完成,2.待审核,0.制作中
        Dim lsSQL As String = String.Empty
        Dim o_iStatus As Integer = -1
        CheckRCardStatus = False
        Try
            lsSQL = " SELECT Status FROM m_RCardM_t" & _
                    " WHERE partid ='" & parPartID & "'"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    o_iStatus = CInt(o_dt.Rows(0).Item("Status"))
                End If
            End Using

            If o_iStatus <> 1 Then
                CheckRCardStatus = False
            Else
                CheckRCardStatus = True
            End If
            Return CheckRCardStatus
        Catch ex As Exception
        End Try
    End Function

    Private Function CheckCutCardStatus(ByVal parPartID As String) As Boolean
        '1.已完成,2.待审核,0.制作中
        Dim lsSQL As String = String.Empty
        Dim o_iStatus As Integer = -1
        CheckCutCardStatus = False
        Try
            lsSQL = " SELECT Status FROM m_RCardCutM_t WHERE partid ='" & parPartID & "'"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    o_iStatus = CInt(o_dt.Rows(0).Item("Status"))
                End If
            End Using

            If o_iStatus <> 1 Then
                CheckCutCardStatus = False
            Else
                CheckCutCardStatus = True
            End If

            Return CheckCutCardStatus
        Catch ex As Exception
        End Try
    End Function

    Private Function GetTTCustVerbyMoid(moid As String)
        Dim strCustVer As String = ""
        If VbCommClass.VbCommClass.IsConSap = "Y" Then
            'strCustVer = SapCommon.GetTTCustVerSap(moid)
            strCustVer = SapCommon.GetTTPartVerSap(moid)
        Else
            strCustVer = SapCommon.GetTTCustVer(moid)
        End If
        Return strCustVer
    End Function
          
    Private Function GetTTCustVerbyPart(part As String)
        Dim strCustVer As String = ""
        If VbCommClass.VbCommClass.IsConSap = "Y" Then
            strCustVer = SapCommon.GetVerFromTiptopSap(part)
        Else
            strCustVer = SapCommon.GetVerFromTiptop(part)
        End If
        Return strCustVer
    End Function

    Private Function GetTTCustVerbyMoidPart(moid As String)
        Dim strCustVer As String = ""
        If VbCommClass.VbCommClass.IsConSap = "Y" Then
            strCustVer = SapCommon.GetTTPartVerSap(moid)
            'strCustVer = SapCommon.GetVerFromTiptopSap(part)
        Else
            strCustVer = SapCommon.GetTTPartVer(moid)
        End If
        Return strCustVer
    End Function

#End Region

    Public _MOList As List(Of MOComBusiness.stcMO) = New List(Of MOComBusiness.stcMO)

#Region " 系列别 模糊匹配功能"
    Private listNew As List(Of String) = New List(Of String)()
    Private Sub CboSeriesID_TextUpdate(sender As Object, e As EventArgs) Handles CboSeriesID.TextUpdate
        '清空combobox
        Me.CboSeriesID.Items.Clear()
        '清空listNew
        listNew.Clear()
        '遍历全部备查数据
        For Each item As String In listSerial
            If (item.ToUpper.Contains(Me.CboSeriesID.Text.ToUpper)) Then
                listNew.Add(item)
            End If
        Next
        'combobox添加已经查到的关键词
        Me.CboSeriesID.Items.AddRange(listNew.ToArray())
        '设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
        Me.CboSeriesID.SelectionStart = Me.CboSeriesID.Text.Length
        ' //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
        Cursor = Cursors.Default
        '自动弹出下拉框
        Me.CboSeriesID.DroppedDown = True
    End Sub

#End Region


End Class