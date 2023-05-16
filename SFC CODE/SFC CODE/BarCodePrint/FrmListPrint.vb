
'--条码打印作业
'--Create by :　马锋
'--Create date :　2014/07/17
'--Update date :  
'--2015-01-15   马锋    增加对N类型包装条码无法追踪打印记录
'--Ver : V01
'--Update :  田玉琳 2018/10/19
'--更新内容：更新客户料号，删除多余代码
'--Update :  田玉琳 2019/10/1
'--更新内容：增加切换SAP
'--Update :  田玉琳 2019/11/29
'--更新内容：增加itemcode
'--Update :  田玉琳 2020/04/27
'--更新内容：箱的多流水打印

#Region "Imports"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD
Imports MainFrame
Imports VbCommClass

#End Region

Public Class FrmListPrint

#Region "窗體變量"

    Dim LoadM As New BarCodePrint.SqlClassM
    Public LoadD As New SqlClassD      '定義子資源對象
    Dim Sqlstr As New StringBuilder
    'Dim CustPart As String          '客戶料號
    Dim opFlag As Int16 = 0
    Dim dvTiptopLot As New DataView
    Dim TemplateStatus As Boolean = False    '模板状态
    Dim BarCodePartTable As New DataTable
    Dim CurrCodeUnitTable As New DataTable   '定義馬元資源表
    Dim PrtStrTable As New DataTable      '打印命令字符串
    Dim PrtArray As New MainFrame.SysCheckData.SysMessageClass.PrtStructure
    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Dim pFilePath As String = ""
    Dim PrintPart(,) As String    '建立打印字符串來源信息數組
    Dim SBCodeUnit(,) As String       '建立條碼流水號所用到的碼制信息數組
    Dim SBCodeLEN As Int16        '流水號的長度，也是數組的變量
    Dim PrintStr As New StringBuilder     '建立條碼打印字符串

    Dim BarValueStr As New StringBuilder()
    Dim BarFile As New StringBuilder()

    Dim MoidPrinted As Int64 = 0      '工單已打印數量
    Dim AxTempCode As New StringBuilder
    Dim LblTempCode As New StringBuilder
    Dim PrintCodeValue As StringBuilder '标签各元素的值
    Dim YMDCode As New StringBuilder

    Dim CurrSeriNo As String

    Dim DataType As String

    Dim strMOID As String
    ''***********************多流水码修改
    Dim IsmullitStyle As String = "N"
    Dim PubAtrributeStype As String = "" '附属条码的样式
    Dim CurrAtrrCodeUnitTable As New DataTable   '定義馬元資源表
    Dim AtrrSBCodeUnit(,) As String       '建立條碼流水號所用到的碼制信息數組
    Dim AtrrSBCodeLEN As Int16        '流水號的長度，也是數組的變量
    Dim AtrrCode As String = ""
    Dim AtrrCodeLen As Int16 ''附属条码
    Dim AtrrAxTempCode As New StringBuilder
    Dim AtrrCurrSeriNo As String
    ''***********************多流水码修改
    Private m_strOrderNO As String = String.Empty
    Private m_strOrderSeq As String = String.Empty
    Private m_DeliveryDate As String = String.Empty
    Private m_ScheFinishDate As String = String.Empty
    Private m_CheckAqci120 As String = String.Empty
    Private strPrintNumber As String = "0"
    Private strConfigurationQty As String = "0" '配置数
    Private strGroupPrintFlag As String = "N"  '附属条码是否组合打印
    Dim Mreader As DataTable ' 田玉琳 20170407

    Private SNDistributionID As String = String.Empty ' 号段ID(黄广都 2017-04-24)
    Private SNDistributionCount As Int16 = 0 ' 厂区号段设置总数(黄广都 2017-04-24)
    Dim SNDistributionArr(,) As String       '厂区分段流水号区间数组


    Dim m_AddPrtCheck As Boolean = False ''补数标签打印判断
    Dim m_AddApplyList As String = "" '补数标签申请单
    Dim m_AddPrtQty As Integer = 0 '补数标签数量
    Dim m_AddPrtFinishedQty As Integer = 0 '补数标签已完成数量
    Dim strTestPrt As String = "N"
    Dim strPrintVer As String = ""
    'Dim NewFactory As String = VbCommClass.VbCommClass.Factory '直接取值，禁止重新赋值工厂代码
    'Dim Newprofitcenter As String = VbCommClass.VbCommClass.profitcenter '直接取值，禁止重新赋值工厂代码
    Dim UseId As String = VbCommClass.VbCommClass.UseId
    Dim IsConSap As String = VbCommClass.VbCommClass.IsConSap

#Region "包装"
    Dim MoidAllNum As Int64 = 0         '工單批量
    Dim MoidLastNum As Int64            '工單尾數量
    Dim CtPrtingNum As Int64            '工單可打印箱數
    Dim PackMethod As Int16 = 0         '裝箱數量
    Dim Packlink As String = ""         '箱標簽類型
    Dim PackItems As String = ""         '条码类型
#End Region

#End Region

#Region "窗体事件"

    Private Sub FrmListPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        btApp = New BarTender.ApplicationClass

        '檢視用戶權限()
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        SetStatus(opFlag)

        LoadControlData()
        ClearObject()

        Me.chbPrintListSelect.Checked = True
        Me.txtMOId.Focus()
        ToolStripStatusLabel1.Text = "申请记录："
    End Sub

    Private Sub FrmListPrint_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click
        DataType = "NEW"
        opFlag = 1
        SetStatus(opFlag)
        ClearObject()

        Me.txtDemandInfo.Text = "合同号: " + Environment.NewLine + "需求信息:"

        Me.CboMoType.SelectedIndex = -1
        Me.CboDept.SelectedIndex = -1
        Me.CboCust.SelectedIndex = -1
        Me.CboSeries.SelectedIndex = -1
        Me.CboItemCode.SelectedIndex = -1
        Me.txtPrintCount.Enabled = False
        Me.ActiveControl = Me.txtMOId
        dgvPrintList.Columns.Item("FileVerNo").ReadOnly = False
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.BackColor = Color.White
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.ForeColor = Color.FromArgb(0, 122, 204)
    End Sub

    Private Sub ToolCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCommit.Click
        dgvPrintList.EndEdit()
        Dim StrSavaSQL As New StringBuilder
        SetMessage("")
        Try
            If (CheckLotSave()) Then
                Exit Sub
            End If

            Dim partID_SFB05 As String = dvTiptopLot.Table.Rows(0).Item("SFB05").ToString


            Dim CustID As String = ""
            If CboCust.SelectedValue IsNot Nothing Then
                CustID = CboCust.SelectedValue.ToString()
            End If
            Dim SeriesID As String = ""
            If CboSeries.SelectedValue IsNot Nothing Then
                SeriesID = CboSeries.SelectedValue.ToString()
            End If
            '增加ItemCode 田玉琳20191129
            Dim ItemCode As String = ""
            If CboItemCode.SelectedValue IsNot Nothing Then
                ItemCode = CboItemCode.SelectedValue.ToString()
            End If

            '2016-06-13  
            If (Not String.IsNullOrEmpty(Me.txtPO.Text)) Then
                DbOperateUtils.ExecSQL(
                    " IF EXISTS(SELECT Partid FROM m_PartPack_t WHERE Partid='" & partID_SFB05 & "' AND PACKID='N' AND CodeRuleID='N001' AND Usey='Y') " & _
                    " BEGIN DECLARE @PACKITEM VARCHAR(8) " & _
                    " SELECT TOP 1 @PACKITEM=PACKITEM FROM m_PartPack_t WHERE Partid='" & partID_SFB05 & "' AND PACKID='N' AND CodeRuleID='N001' AND Usey='Y' " & _
                    " UPDATE m_SnPartSet_t SET DValues=N'" & Me.txtPO.Text.Trim & "' WHERE Partid='" & partID_SFB05 & "' AND Packid='N' AND Packitem=@PACKITEM AND F_codeID='PO' AND Usey='Y' END ")
            End If

            '处理重载已经存在数据
            If (DataType = "AGAIN") Then
                StrSavaSQL.Append(" DELETE m_SnAssign_t WHERE Moid IN (SELECT MOID FROM m_Mainmo_t WHERE ParentMo='" & strMOID.Trim & "')")
                StrSavaSQL.Append(" DELETE m_Mainmo_t WHERE ParentMo='" & strMOID.Trim & "'")
            End If

            '************************** 田玉琳 20181227 开始 **************************
            '针对所有新产品，第一次生产PQE需在系统内维护30天每日柏拉图
            StrSavaSQL.Append(" IF NOT EXISTS(SELECT 1 FROM m_PartContrast_t WHERE TAvcPart='" & partID_SFB05 & "' AND intime < GETDATE()-1 )  ")
            StrSavaSQL.Append(" BEGIN  ")
            StrSavaSQL.Append(" IF NOT EXISTS(SELECT Partid FROM m_AssyTsProcssCheckPartId WHERE Partid='" & partID_SFB05 & "' AND TYPE = 'D' )  ")
            StrSavaSQL.Append(" BEGIN  ")
            StrSavaSQL.AppendFormat("   INSERT INTO m_AssyTsProcssCheckPartId(PartId, TYPE, ValidStartDate, ValidEndDate, IsValid, Remark, UserId, InTime) " &
                                    "   VALUES('{0}','D',convert(VARCHAR(10),getdate(),111),convert(VARCHAR(10),getdate()+30,111), 'Y',N'LISTPRINT-download'," &
                                    "   '{1}',getdate()) ", partID_SFB05, UseId)
            StrSavaSQL.Append(" END  ")
            StrSavaSQL.Append(" END  ")
            '************************** 田玉琳 20181227 结束 **************************
            'Me.CboDept.SelectedValue.ToString()
            '保存工单
            StrSavaSQL.Append(" INSERT INTO m_MODemand_t(MOID, DemandNote, CreateUserId, CreateTime)VALUES('" & strMOID & "', N'" & Me.txtDemandInfo.Text.Trim().Replace("'", "''") & "', '" & UseId & "', GETDATE())")

            Dim deptId As String = Me.CboDept.SelectedValue.ToString()

            '2017-03-14   修正主工单料号没有维护料件打印参数生成无主工单BUG
            StrSavaSQL.Append(" IF NOT EXISTS(SELECT Moid FROM m_Mainmo_t WHERE Moid=N'" & strMOID & "' AND ParentMo=N'" & strMOID & "') " _
                   & " BEGIN  " _
                   & "     INSERT INTO m_Mainmo_t(Moid,Tmoid, PartID, Cusid, Deptid, Lineid, Moqty, Outqty, Notqty, Scrapqty, Ppidprtqty, Pkgprtqty, Typeid, " _
                   & "                EstateID, Routeid, Plandate, Createuser, Createtime, FinalY, Finalqty, Remark, Finalman, Finaltime, States, Factory, " _
                   & "                profitcenter, IsLotOk, ParentMo, DemandInfo, demandTime,Version,SeriesID,ItemCode, ORDERNO,Orderseq,DeliveryDate,ScheFinishDate, BlueprintVersion, PackageVersion,PO,CreateAPID) " _
                   & "     VALUES('" & strMOID & "',NULL,'" & Me.TxtPartid.Text.Trim & "'," _
                   & " '" & CustID & "','" & deptId & "','" & Me.CboLine.SelectedValue.ToString() & "', " _
                   & "  '" & Convert.ToInt32(Me.txtQty.Text.Trim()) & "',NULL,NULL,NULL,0,NULL," _
                   & " '" & Me.CboMoType.SelectedValue.ToString() & "',5,NULL,getdate(),'" & UseId & "',GETDATE(),'N',NULL,N'" & Me.TxtTaskDesc.Text.Trim & "', " _
                   & " '" & UseId & "',GETDATE(),NULL,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'," _
                   & " 'N','" & strMOID & "',N'" & Me.txtDemandInfo.Text.Trim() & "', cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime) " _
                   & "  ,'" & GetVersion(Me.TxtPartid.Text.Trim) & "','" & SeriesID & "','" & ItemCode & "'," _
                   & " '" & m_strOrderNO & "','" & m_strOrderSeq & "',' " & m_DeliveryDate & "','" & m_ScheFinishDate & "', '" & Me.txtBlueprintVersion.Text.Trim() &
                   "', '" & Me.txtPackageVersion.Text.Trim() & "',N'" & Me.txtPO.Text.Trim & "','LISTPRINT')" _
                   & " End ")

            For I As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                If (Microsoft.VisualBasic.Left(dgvPrintList.Rows(I).Cells("lableType").Value.ToString, 1) <> "A") Then
                    StrSavaSQL.Append(" IF NOT EXISTS(SELECT Moid FROM m_Mainmo_t WHERE Moid=N'" & dgvPrintList.Rows(I).Cells("Moid").Value.ToString & "') " _
                    & " BEGIN  " _
                    & "     INSERT INTO m_Mainmo_t(Moid,Tmoid, PartID, Cusid, Deptid, Lineid, Moqty, Outqty, Notqty, Scrapqty, Ppidprtqty, Pkgprtqty, Typeid, " _
                    & "                EstateID, Routeid, Plandate, Createuser, Createtime, FinalY, Finalqty, Remark, Finalman, Finaltime, States, Factory, " _
                    & "                profitcenter, IsLotOk, ParentMo, DemandInfo, demandTime,Version,SeriesID,ItemCode,ORDERNO,Orderseq,DeliveryDate,ScheFinishDate, BlueprintVersion, PackageVersion,PO,CreateAPID) " _
                    & "     VALUES('" & dgvPrintList.Rows(I).Cells("Moid").Value.ToString & "',NULL,'" & dgvPrintList.Rows(I).Cells("PartId").Value.ToString & "'," _
                    & " '" & CustID & "','" & deptId & "','" & Me.CboLine.SelectedValue.ToString() & "', " _
                    & "  '" & Convert.ToInt32(Me.txtQty.Text.Trim()) * Convert.ToInt16(dgvPrintList.Rows(I).Cells("ConfigurationQty").Value.ToString) & "',NULL,NULL,NULL,0,NULL," _
                    & " '" & Me.CboMoType.SelectedValue.ToString() & "',5,NULL,getdate(),'" & UseId & "',GETDATE(),'N',NULL,N'" & Me.TxtTaskDesc.Text.Trim & "', " _
                    & " '" & UseId & "',GETDATE(),NULL,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'," _
                    & " 'N','" & strMOID & "',N'" & Me.txtDemandInfo.Text.Trim() & "', cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime) " _
                    & "  ,'" & GetVersion(dgvPrintList.Rows(I).Cells("PartId").Value.ToString) & "','" & SeriesID & "','" & ItemCode & "'," _
                    & " '" & m_strOrderNO & "','" & m_strOrderSeq & "',' " & m_DeliveryDate & "','" & m_ScheFinishDate & "', '" & Me.txtBlueprintVersion.Text.Trim() & "', '" &
                    Me.txtPackageVersion.Text.Trim() & "',N'" & Me.txtPO.Text.Trim & "','LISTPRINT')" _
                    & " End ")
                End If
            Next

            '筛选料号只有A类型数据，产生工单
            Dim PartId As String
            Dim NewPartId As String
            Dim arrList As New ArrayList()
            Dim arrNewList As New ArrayList()
            Dim bTemp As Boolean
            Dim bNew As Boolean

            '取得所有非A产生工单料号
            For k As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                PartId = dgvPrintList.Rows(k).Cells("PartId").Value.ToString
                bTemp = False
                If (Microsoft.VisualBasic.Left(dgvPrintList.Rows(k).Cells("lableType").Value.ToString, 1) <> "A") Then
                    For k1 As Int16 = 0 To arrList.Count - 1
                        If (arrList(k1) = PartId) Then
                            bTemp = True
                            Exit For
                        End If
                    Next
                    If (Not bTemp) Then
                        arrList.Add(PartId)
                    End If
                End If
            Next

            '取得单附属条码申请工单
            For j As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                NewPartId = dgvPrintList.Rows(j).Cells("PartId").Value.ToString
                bTemp = False
                If (Microsoft.VisualBasic.Left(dgvPrintList.Rows(j).Cells("lableType").Value.ToString, 1) = "A") Then

                    For j1 As Int16 = 0 To arrList.Count - 1
                        If (arrList(j1) = NewPartId) Then
                            bTemp = True
                            Exit For
                        End If
                    Next

                    If (Not bTemp) Then
                        bNew = False
                        For j2 As Int16 = 0 To arrNewList.Count - 1
                            If (arrNewList(j2) = NewPartId) Then
                                bNew = True
                                Exit For
                            End If
                        Next
                        If (Not bNew) Then
                            arrNewList.Add(NewPartId)

                            StrSavaSQL.Append(" IF NOT EXISTS(SELECT Moid FROM m_Mainmo_t WHERE Moid=N'" & dgvPrintList.Rows(j).Cells("Moid").Value.ToString & "') " _
                            & " BEGIN  " _
                            & "     INSERT INTO m_Mainmo_t(Moid, Orderseq, Tmoid, PartID, Cusid, Deptid, Lineid, Moqty, Outqty, Notqty, Scrapqty, Ppidprtqty, Pkgprtqty, Typeid, " _
                            & "                EstateID, Routeid, Plandate, Createuser, Createtime, FinalY, Finalqty, Remark, Finalman, Finaltime, States, Factory, " _
                            & "                profitcenter, IsLotOk, ParentMo, DemandInfo, demandTime,version, BlueprintVersion, PackageVersion,PO,SeriesID,ItemCode,CreateAPID) " _
                            & "     VALUES('" & dgvPrintList.Rows(j).Cells("Moid").Value.ToString & "',NULL,NULL,'" & dgvPrintList.Rows(j).Cells("PartId").Value.ToString & "','" &
                                    CustID & "','" & deptId & "','" & Me.CboLine.SelectedValue.ToString() & "', " _
                            & "  '" & Convert.ToInt32(Me.txtQty.Text.Trim()) * Convert.ToInt32(dgvPrintList.Rows(j).Cells("ConfigurationQty").Value.ToString) &
                            "',NULL,NULL,NULL,0,NULL,'" & Me.CboMoType.SelectedValue.ToString() & "',5,NULL,getdate(),'" & UseId & "',GETDATE(),'N',NULL,N'" &
                            Me.TxtTaskDesc.Text.Trim & "','" & UseId & "',GETDATE(),NULL,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter &
                            "','N','" & strMOID & "',N'" & Me.txtDemandInfo.Text.Trim() & "', cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime) " _
                            & " ,'" & GetVersion(dgvPrintList.Rows(j).Cells("PartId").Value.ToString) & "', '" & Me.txtBlueprintVersion.Text.Trim() & "', '" &
                            Me.txtPackageVersion.Text.Trim() & "',N'" & Me.txtPO.Text.Trim & "','" & SeriesID & "','" & ItemCode & "','LISTPRINT') " _
                            & " End ")
                        End If
                    End If
                End If
            Next
            arrList = Nothing
            arrNewList = Nothing

            '保存打印申请
            Dim PtaskId As String = ""
            Dim shift As String
            Dim taskPrefix As String = ""
            Dim taskNo As Int32

            shift = IIf(Me.CboShift.SelectedIndex = 0, "D", "N")
            If Me.CboShift.SelectedIndex = -1 Then
                shift = ""
            End If

            Dim strPrtTestQty As Double = 0

            For I As Int16 = 0 To Me.dgvPrintList.RowCount - 1

                If (String.IsNullOrEmpty(PtaskId)) Then
                    PtaskId = GetTaskId()
                    taskPrefix = Microsoft.VisualBasic.Left(PtaskId, 7)
                    taskNo = CInt(Microsoft.VisualBasic.Right(PtaskId, 4))
                Else
                    PtaskId = taskPrefix + (taskNo + I).ToString.PadLeft(4, "0")
                End If

                If Not String.IsNullOrEmpty(PtaskId) Then

                    strPrtTestQty = Convert.ToDouble(Me.txtQty.Text.ToString.Trim) * Convert.ToDouble(Me.dgvPrintList.Rows(I).Cells("ConfigurationQty").Value) * 0.008

                    If strPrtTestQty < 10 Then
                        strPrtTestQty = 5
                    Else
                        strPrtTestQty = 10
                    End If

                    'Modfiy by cq2018019, add mainmo qty * ConfigurationQty
                    StrSavaSQL.Append(" INSERT INTO m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,ConfigurationQty, PrtTestQty) " _
                    & " VALUES('" & PtaskId & "','" & Me.CboLine.Text.Trim.ToUpper & "','" & dgvPrintList.Rows(I).Cells("Moid").Value.ToString & "','" &
                    Microsoft.VisualBasic.Left(Me.dgvPrintList.Rows(I).Cells("lableType").Value, 1) & "'," &
                    Val(Me.txtQty.Text) * Convert.ToInt32(dgvPrintList.Rows(I).Cells("ConfigurationQty").Value.ToString) & "," _
                    & " cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower &
                    "',getdate(),'1',N'" & Me.TxtTaskDesc.Text.Trim & "','" & shift & "','" & dgvPrintList.Rows(I).Cells("FileVerNo").Value.ToString.Trim & "',N'" &
                    TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text.Trim & "','" & Me.dgvPrintList.Rows(I).Cells("PackItem").Value & "','" &
                    Me.dgvPrintList.Rows(I).Cells("ConfigurationQty").Value & "', '" & strPrtTestQty & "')")

                End If
            Next
            '& "     SET @ERROR_MSG=N'保存失败，请联系开发人员!' " _

            If (Not String.IsNullOrEmpty(StrSavaSQL.ToString)) Then
                DbOperateUtils.ExecSQL(StrSavaSQL.ToString())
            End If

            StrSavaSQL = Nothing

            opFlag = 0
            SetStatus(opFlag)
            ClearObject()
            GetLot()
            dgvPrintList.Columns.Item("FileVerNo").ReadOnly = True
            dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.BackColor = Color.White
            dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.ForeColor = Color.Black
        Catch ex As Exception
            StrSavaSQL = Nothing
            SetMessage("保存失败,请联系开发人员!")
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "ToolCommit_Click", "sys")
        End Try
    End Sub

    Private Sub ToolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBack.Click
        ClearObject()
        opFlag = 0
        SetStatus(opFlag)
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        If CheckQueryParameter(False) Then
            Return
        End If

        GetLot()
        dgvPrintList.Columns.Item("FileVerNo").ReadOnly = True
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.BackColor = Color.White
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.ForeColor = Color.Black

    End Sub

    Private Sub ToolPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPrt.Click
        Me.ToolPrt.Enabled = False
        Me.IsmullitStyle = "N"
        Me.strTestPrt = "N"
        Me.dgvPrintList.EndEdit()
        '号段ID
        Me.SNDistributionID = Nothing
        Dim iFirstSelectedRowIndex As Integer = -1

        '20200626 田玉琳 判断如果没有权限下载退出
        If IsHaveProfitAuth(2) = False Then
            Exit Sub
        End If

        If (MessageBox.Show("本次打印数量:" & Me.txtPrintCount.Text & ",是否开始打印?", "打印确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.No) Then
            Me.ToolPrt.Enabled = True
            Exit Sub
        End If

        Try
            Me.lblMessage.Text = String.Empty
            If dgvPrintList.RowCount > 0 Then
                Dim ChkCount As Integer = 0
                'Dim Temp As DataGridViewCheckBoxCell
                'For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                '    Temp = dgvPrintList.Rows(i).Cells("ChkSelect")
                '    If (Not Temp Is Nothing AndAlso Temp.EditedFormattedValue = True) Then
                '        ChkCount = ChkCount + 1
                '    End If
                '    If ChkCount > 1 Then
                '        Exit For
                '    End If
                'Next
                'If (ChkCount > 1) Then
                '    SetMessage("不支持同时进行多个打印项标签打印，请选择单项进行打印!")
                '    Me.ToolPrt.Enabled = True
                '    Exit Sub
                'End If
                If (CheckPrint(Me.dgvPrintList)) Then

                    CheckEcnChange()

                    If IsConSap = "N" Then
                        Dim strErrorMessage As String = ""
                        If (Not CheckVersion(Me.dgvLotList.Rows(Me.dgvLotList.CurrentRow.Index).Cells("ColPartid").Value.ToString, strErrorMessage)) Then
                            If (MessageBox.Show(strErrorMessage, "PLM版本检查", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) =
                                    Windows.Forms.DialogResult.Cancel) Then
                                Me.ToolPrt.Enabled = True
                                Exit Sub
                            End If
                        End If
                    Else

                    End If

                    Dim index As Integer
                    Dim chkTemp As DataGridViewCheckBoxCell

                    For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                        chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                            iFirstSelectedRowIndex = i
                            Exit For
                        End If
                    Next
                    strPrintNumber = Me.txtPrintCount.Text.Trim
                    For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                        chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then

                            'hs ke 验证是否需要卡控数量，是否需要执行标签补数 2017-12-8
                            Dim strTeskId As String = dgvPrintList.Rows(i).Cells("PtaskId").Value.ToString
                            Dim strMOID As String = dgvPrintList.Rows(i).Cells("Moid").Value.ToString
                            Dim strPartid As String = dgvPrintList.Rows(i).Cells("PartId").Value.ToString
                            Dim strPackId As String = Microsoft.VisualBasic.Left(dgvPrintList.Rows(i).Cells("lableType").Value.ToString, 1)
                            Dim strlableType As String = dgvPrintList.Rows(i).Cells("lableType").Value.ToString
                            Dim strDisorderType As String = dgvPrintList.Rows(i).Cells("DisorderType").Value.ToString
                            Dim strPackItem As String = dgvPrintList.Rows(i).Cells("PackItem").Value.ToString
                            'Dim strVersion As String = dgvPrintList.Rows(i).Cells("Remark").Value.ToString
                            Dim strVersionType As String = dgvPrintList.Rows(i).Cells("VersionTypeText").Value.ToString.Trim.Split("-")(0)
                            If IsPrintLock() Then
                                If Me.dgvLotList.Rows(Me.dgvLotList.CurrentRow.Index).Cells("CusName").Value.ToString = "华为" AndAlso
                               (strPackId = "S" Or strPackId = "C") Then

                                    If (Not CheckPrintQty(strTeskId, strMOID, strPackId, strPackItem, strDisorderType)) Then

                                        Dim dt As DataTable = GetApplyAddPrintDt(strTeskId, strPackId, strPackItem)
                                        If dt.Rows.Count > 0 Then

                                            If (MessageBox.Show("第" + (i + 1).ToString + "行" & strlableType & ",打印数量已超过需求数量，已有补数申请单，是否执行补数标签打印:" &
                                                                Me.txtPrintCount.Text & "?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.Yes) Then
                                                Dim FrmSelAdd As New FrmSelAddPrtInfo
                                                FrmSelAdd.AppDt = dt
                                                FrmSelAdd.ShowDialog()
                                                If FrmSelAdd.IsFlag Then
                                                    Dim arr As String() = FrmSelAdd.SelApList.Split("-")
                                                    m_AddApplyList = arr(0).ToString
                                                    m_AddPrtQty = arr(1).ToString
                                                    If (CInt(Me.txtPrintCount.Text.Trim) > CInt(m_AddPrtQty)) Then
                                                        SetMessage("第" + (i + 1).ToString + "行" & strlableType & ",打印数量已超过需求数量,执行补数标签打印，补数需求数量为：" & m_AddPrtQty & ",当前打印数量已超出")
                                                        m_AddPrtCheck = False
                                                        '  Return False
                                                        Exit For
                                                    Else
                                                        m_AddPrtCheck = True
                                                        SetMessage("第" + (i + 1).ToString + "行" & strlableType & "，执行补数标签打印,数量为" & txtPrintCount.Text.Trim)
                                                        'Return False
                                                        'Exit For
                                                    End If
                                                Else
                                                    m_AddPrtCheck = False
                                                    '   Return False
                                                    Exit For
                                                End If
                                            Else
                                                SetMessage("第" + (i + 1).ToString + "行" & strlableType & "打印数量已超过需求数量!不允许打印")
                                                '  Return False
                                                Exit For
                                            End If


                                        Else
                                            SetMessage("第" + (i + 1).ToString + "行" & strlableType & "打印数量已超过需求数量!")
                                            '    Return False
                                            Exit For
                                        End If

                                    End If
                                End If
                            End If
                            'hs ke 验证是否需要卡控数量，是否需要执行标签补数 2017-12-8
                            strPrintVer = ""
                            '不连接SAP去查找卡控
                            If IsConSap = "N" Then
                                If VbCommClass.VbCommClass.Factory = "LXXT" And VbCommClass.VbCommClass.profitcenter = "SEE-D" And strPackId <> "A" Then ' 检查TT客户版本和规格版本是否一致
                                    Dim dt As DataTable = DbOperateUtils.GetDataTable("exec [Exec_CheckPrintVersion] '" + strMOID + "','" + strPartid + "','','',''")
                                    If dt.Rows.Count > 0 Then
                                        If dt.Rows(0)("Result") <> "OK" Then
                                            Dim strCustVer As String = dt.Rows(0)("CustVer").ToString
                                            Dim strSpeVer As String = dt.Rows(0)("SpecVer").ToString
                                            Dim frmprtver As New FrmPrtVer(strCustVer, strSpeVer)
                                            frmprtver.ShowDialog()
                                            If Not frmprtver.Flag Then
                                                SetMessage("请选择选择打印版本！")
                                                Me.ToolPrt.Enabled = True
                                                Exit Sub
                                            Else
                                                strPrintVer = frmprtver.ConfirmVer
                                            End If
                                        End If
                                    End If
                                End If
                            End If

                            If Me.chkConfirm.Checked = True AndAlso i > iFirstSelectedRowIndex Then
                                If (MessageBox.Show("继续下一个标签打印", "标签确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.Yes) Then
                                    PrintBarCode(dgvPrintList.Rows(i), i + 1)
                                Else
                                    Application.DoEvents()
                                End If
                            Else
                                TxtTaskDesc.Text = "当前抛出" & txtPrintCount.Text & " PCS"
                                PrintBarCode(dgvPrintList.Rows(i), i + 1)
                            End If
                        End If
                    Next
                    If chkGetCodeNoPrint.Checked = False Then 'By 田玉琳 20151210 Update
                        index = dgvLotList.CurrentCell.RowIndex
                        DbOperateUtils.ExecSQL("UPDATE M_MAINMO_T SET CHECKTEXT=N'打印完成' where MOID='" & Me.dgvLotList.Rows(index).Cells("Colmoid").Value.ToString & "'")
                    End If
                    If VbCommClass.VbCommClass.Factory = "LX53" Then
                        InitJxPar()
                        Me.ToolPrt.Enabled = True
                        Exit Sub
                    End If
                Else
                    Me.ToolPrt.Enabled = True
                    Exit Sub
                End If
            Else
                SetMessage("没有任何可供打印行!")
            End If

            GetLot()
        Catch ex As Exception
            SetMessage(ex.Message.ToString())
        End Try
        Me.ToolPrt.Enabled = True
    End Sub

    ', Timer.Tick
    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        If CheckQueryParameter(True) Then
            Return
        End If

        GetLot() '出错
        Me.txtPrintCount.Enabled = True
        dgvPrintList.Columns.Item("FileVerNo").ReadOnly = True
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.BackColor = Color.White
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.ForeColor = Color.Black
    End Sub

    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    Private Sub ToolAgain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolAgain.Click
        DataType = "AGAIN"
        opFlag = 1
        SetStatus(opFlag)
        ClearObject()

        Me.CboMoType.SelectedIndex = -1
        Me.CboDept.SelectedIndex = -1
        Me.CboCust.SelectedIndex = -1
        Me.CboSeries.SelectedIndex = -1
        Me.CboItemCode.SelectedIndex = -1
        Me.txtPrintCount.Enabled = False
        Me.ActiveControl = Me.txtMOId
        dgvPrintList.Columns.Item("FileVerNo").ReadOnly = False
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.BackColor = Color.White
        dgvPrintList.Columns.Item("FileVerNo").DefaultCellStyle.ForeColor = Color.FromArgb(0, 122, 204)
    End Sub

    Private Sub ToolPrintLoak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPrintLoak.Click
        Dim chkTemp As DataGridViewCheckBoxCell
        Dim styleId As String = ""
        Dim strSQL As String = "", strSQL2 As String = ""
        Dim sRow As String = ""
        For i As Integer = 0 To Me.dgvPrintList.RowCount - 1
            chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
            If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                If Not InitializePrintParameter(dgvPrintList.Rows(i)) Then
                    MessageBox.Show("标签类型非 《待打印》 《和打印中》无法解锁")
                    Return
                End If

                styleId = MakeStyle() '產生樣式

                '三分钟锁定的不允许解锁
                If CheckAllowUnLock(styleId) = False Then

                    sRow = "[" & (i + 1).ToString & "]"
                    Continue For
                End If
                'strSQL = strSQL + " UPDATE m_SnDistributionStyle_t set IsUsed='N',Intime=getdate() where IsUsed='Y' AND StyleID='{0}' AND FactoryId='{1}' "
                'strSQL = String.Format(strSQL, styleId.Replace("'", "''"), VbCommClass.VbCommClass.Factory)
                'add by hgd 2017-12-26 加入三分钟内不能强制解锁
                strSQL = strSQL + " UPDATE m_SnDistributionStyle_t set IsUsed='N',Intime=getdate() where IsUsed='Y' AND StyleID='" & styleId.Replace("'", "''") & "' AND FactoryId='" & VbCommClass.VbCommClass.Factory & "'  "
                'strSQL = String.Format(strSQL, styleId.Replace("'", "''"), VbCommClass.VbCommClass.Factory)

                ' strSQL = strSQL + " UPDATE m_SnStyle_t SET IsUsed='N' WHERE IsUsed='Y' and StyleID = '{0}' "
                strSQL = strSQL + " UPDATE m_SnStyle_t SET IsUsed='N' WHERE IsUsed='Y' and StyleID = '" & styleId.Replace("'", "''") & "'  "

                If loadm.SectionCodeRule Then
                    strSQL = strSQL + " UPDATE m_SnStyleSECTION_t SET IsUsed='N' WHERE IsUsed='Y' and StyleID = '" & styleId.Replace("'", "''") & "' and CodeRuleID='" & LoadM.CodeRule & "'"
                End If
                'strSQL = strSQL & String.Format(strSQL2, styleId.Replace("'", "''"))
            End If
        Next

        If strSQL <> "" Then
            DbOperateUtils.ExecSQL(strSQL)
            If String.IsNullOrEmpty(sRow) Then
                MessageUtils.ShowInformation("解锁成功！")
            Else
                MessageUtils.ShowInformation("其它条码解锁成功,第" & sRow & "行样式被占用,三分钟内无法解锁！")
            End If

        Else
            If Not String.IsNullOrEmpty(sRow) Then
                MessageUtils.ShowInformation("第" & sRow & "行样式被占用,三分钟内无法解锁！")
            Else
                MessageUtils.ShowInformation("没有锁定条码！")
            End If
        End If
    End Sub

    Private Sub ToolMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolMove.Click

        Try
            If dgvLotList.RowCount > 0 Then
                SetMessage("")
                Dim index As Integer
                index = dgvLotList.CurrentCell.RowIndex
                DbOperateUtils.ExecSQL("UPDATE M_MAINMO_T SET CHECKTEXT=N'信息不符,退单' where MOID='" & Me.dgvLotList.Rows(index).Cells("Colmoid").Value.ToString & "'")
                SetMessage("工单号为" + Me.dgvLotList.Rows(index).Cells("Colmoid").Value.ToString + "退单成功!")
            Else
                SetMessage("没有任何可供回退的行!")
            End If

        Catch ex As Exception
            SetMessage(ex.ToString())
        End Try

    End Sub

    Private Sub ToolDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDelete.Click
        Try

            If (MessageBox.Show("你确定删除？", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel) Then
                Exit Sub
            End If

            Dim strMOId As String
            If Me.dgvLotList.Rows.Count = 0 OrElse Me.dgvLotList.CurrentRow Is Nothing Then
                MessageBox.Show("请选择要删除工单!")
                Exit Sub
            End If

            strMOId = Me.dgvLotList.Item("Colmoid", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim

            CheckLotAgain(strMOId)

            If CheckQueryParameter(True) Then
                Return
            End If

            GetLot() '出错
            Me.txtPrintCount.Enabled = True

        Catch ex As Exception
            SetMessage("执行工单删除异常!" + ex.Message.ToString())
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "ToolDelete_Click", "sys")
        End Try
    End Sub

    Private Sub ToolCommitInfo_Click(sender As Object, e As EventArgs) Handles ToolCommitInfo.Click
        Try
            SetMessage("")
            If Me.dgvLotList.Rows.Count = 0 OrElse Me.dgvLotList.CurrentRow Is Nothing Then
                SetMessage("请选择提交需求工单")
                Exit Sub
            End If

            If (String.IsNullOrEmpty(Me.txtDemandInfo.Text.Trim)) Then
                SetMessage("提交需求信息不能为空")
                Exit Sub
            End If

            Dim strSQL As StringBuilder = New StringBuilder
            Dim strMOid As String = Me.dgvLotList.Rows(Me.dgvLotList.CurrentRow.Index).Cells("Colmoid").Value

            strSQL.AppendLine(" INSERT INTO m_MODemand_t(MOID, DemandNote, CreateUserId, CreateTime)VALUES('" & strMOid & "', N'" & Me.txtDemandInfo.Text.Trim.Replace("'", "''") & "' , '" & UseId & "', GETDATE())")
            strSQL.AppendLine(" UPDATE m_Mainmo_t SET DemandInfo = N'" & Me.txtDemandInfo.Text.Trim & "', CHECKTEXT = N'新增需求' WHERE MOID='" & strMOid & "'")

            DbOperateUtils.ExecSQL(strSQL.ToString())
            GetLot()
        Catch ex As Exception
            SetMessage("保存失败!" + ex.Message.ToString())
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub dgvPrintList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrintList.CellEnter
        On Error Resume Next

        If Me.dgvPrintList.Rows.Count = 0 OrElse Me.dgvPrintList.CurrentRow Is Nothing Then
            Exit Sub
        End If

        GetPrintItemParameter(Me.dgvPrintList.Item("Moid", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, Me.dgvPrintList.Item("PartId", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, Microsoft.VisualBasic.Left(Me.dgvPrintList.Item("lableType", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, 1), Me.dgvPrintList.Item("PackItem", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim)
        GetPrintInfo(Me.dgvPrintList.Item("Moid", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, Me.dgvPrintList.Item("PartId", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, Microsoft.VisualBasic.Left(Me.dgvPrintList.Item("lableType", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim, 1), Me.dgvPrintList.Item("PackItem", Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim)
    End Sub

    Private Sub dgvLotList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLotList.CellEnter
        Try
            RemoveHandler dgvLotList.CellEnter, AddressOf dgvLotList_CellEnter

            If Me.dgvLotList.Rows.Count = 0 OrElse Me.dgvLotList.CurrentRow Is Nothing Then
                Exit Sub
            End If
            Me.txtPrintCount.Text = CInt(Me.dgvLotList.Item("ColQty", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim) - CInt(Me.dgvLotList.Item("Ppidprtqty", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim)

            If (Me.ChkDemandTime.Checked) Then
                If (Not String.IsNullOrEmpty(Me.dgvLotList.Item("Plandate", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim)) Then
                    If (CheckDemand(Me.dgvLotList.Item("Plandate", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim)) Then
                        Me.LblPrintDate.Text = Me.dgvLotList.Item("Plandate", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim
                        PrtArray.NowDate = CDate(Me.LblPrintDate.Text).ToString("yyyy-MM-dd").ToString
                        PrtArray.NowMonth = CDate(Me.LblPrintDate.Text).ToString("MM").ToString
                        SetArrayLbl(PrtArray.ToArray)
                    End If
                End If
            End If

            Me.txtDemandInfo.Text = Me.dgvLotList.Item("DemandInfo", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim

            GetLotPrintList(Me.dgvLotList.Item("Colmoid", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim, Me.dgvLotList.Item("ColPartId", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim, "", True)
        Catch ex As Exception
            SetMessage("获取工单打印清单异常")
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "dgvLotList_CellEnter", "sys")
        Finally
            AddHandler dgvLotList.CellEnter, AddressOf dgvLotList_CellEnter
        End Try
    End Sub

    Private Sub CboDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDept.SelectedIndexChanged
        If Me.CboDept.SelectedIndex <> -1 Then
            CboLine.DataSource = Nothing
            FillCombox(CboLine)
            CboLine.SelectedIndex = -1
        Else
            Me.CboLine.DataSource = Nothing
            Me.CboLine.Items.Clear()
            Me.CboLine.SelectedIndex = -1
        End If
    End Sub

    'Handles txtMOId.KeyDown
    Private Sub txtMOId_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMOId.KeyDown
        Dim lsSQL As String = "", o_strPONo As String = ""
        Dim o_strCusID As String = "", o_strSerialID As String = "", o_strItemCode As String = ""
        Dim o_strMsg As String = ""
        SetMessage("")
        Me.mtxtMOid.Text = ""
        Me.CboCust.SelectedIndex = -1
        Me.CboSeries.SelectedIndex = -1
        Me.CboItemCode.SelectedIndex = -1

        Try
            If (e.KeyCode = Keys.Enter) Then
                If (ToolNew.Enabled) Or (ToolAgain.Enabled) Then
                    Exit Sub
                End If
                Me.rtxtStepMessage.Text = ""

                strMOID = String.Empty

                If String.IsNullOrEmpty(Me.txtMOId.Text.Trim.Trim()) Then
                    SetMessage("请输入查询Tiptop工单!")
                    SetStepMessage("请输入查询Tiptop工单!", False)
                End If

                If (m_CheckAqci120 = "N" And IsConSap = "N") Then
                    If (String.IsNullOrEmpty(Me.CboCust.SelectedValue)) Then
                        SetStepMessage("请选择工单客户!", False)
                        Exit Sub
                    End If
                End If
                'If (Me.CboCust.Items.Count > 0) Then  'mark by cq
                '    If (String.IsNullOrEmpty(Me.CboCust.Text.ToString())) Then
                '        SetMessage("更新BOM失败,请先选择客户!")
                '        Exit Sub
                '    End If
                'End If

                'If (Me.CboSeries.Items.Count > 0) Then 'Mark by cq20151225
                '    If (String.IsNullOrEmpty(Me.CboSeries.Text.ToString())) Then
                '        SetMessage("更新BOM失败,请先选择系列别!")
                '        Exit Sub
                '    End If
                'End If

                '处理重载已经存在数据
                If (DataType = "AGAIN") Then
                    strMOID = txtMOId.Text
                    If CheckHaveData(strMOID) = False Then
                        Exit Sub
                    End If
                End If

                '工单判断
                Dim dtLot As New DataTable
                '检查料号，避免资源浪费
                dtLot = DbOperateUtils.GetDataTable(GetCheckLotSQL(Me.txtMOId.Text.Trim()))

                If dtLot.Rows.Count > 0 And (DataType <> "AGAIN") Then
                    'GetMoidToRefresh(Me.txtMOId.Text.Trim)
                    SetMessage("工单" + Me.txtMOId.Text.Trim + "已经下载完成!")
                    SetStepMessage("工单" + Me.txtMOId.Text.Trim + "已经下载完成!", False)
                    ClearQuery()
                Else

                    'Dim TiptopConn As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
                    dvTiptopLot = Nothing

                    '连接到SAP
                    If IsConSap = "Y" Then
                        dvTiptopLot = SapCommon.GetTiptopLotSAP(Me.txtMOId.Text.Trim())
                    Else
                        dvTiptopLot = SapCommon.GetTiptopLot(Me.txtMOId.Text.Trim())
                    End If


                    '获取Tiptop工单信息
                    If Not dvTiptopLot Is Nothing Then

                        If dvTiptopLot.Count > 0 Then
                            If IsConSap = "Y" Then
                                If dvTiptopLot.Table.Rows(0).Item("werks").ToString <> VbCommClass.VbCommClass.Factory Then
                                    Dim msg As String = "登录工厂代码" + VbCommClass.VbCommClass.Factory + "与查询工单" & Me.txtMOId.Text.Trim() & "工厂代码" + dvTiptopLot.Table.Rows(0).Item("werks").ToString + "不一致，请确认或者切换登录工厂"
                                    SetMessage(msg)
                                    ClearQuery()
                                    Exit Sub
                                End If
                            End If

                            '部门
                            Dim deptIdSap As String = dvTiptopLot.Item(0).Item("tc_imc03").ToString().Trim
                            '线别
                            Dim LineSap As String = dvTiptopLot.Item(0).Item("sfb82").ToString()

                            If (String.IsNullOrEmpty(deptIdSap)) Or deptIdSap.Length < 3 Then
                                o_strMsg = "ERP中间表未找到部门，请联系生管维护部门！"
                                SetMessage(o_strMsg)
                                Me.CboDept.SelectedIndex = -1
                            End If

                            If (String.IsNullOrEmpty(LineSap)) Or LineSap.Length < 3 Then
                                o_strMsg += "ERP中间表未找到线别，请联系生管维护线别！"
                                SetMessage(o_strMsg)
                                Me.CboLine.SelectedIndex = -1
                            End If

                            Dim dvChildPart As DataView
                            '连接到SAP
                            If IsConSap = "Y" Then
                                dvChildPart = SapCommon.GetPartInfoSap(dvTiptopLot)
                            Else
                                dvChildPart = SapCommon.GetPartInfo(dvTiptopLot)
                            End If

                            'cq 20160713
                            If Not IsNothing(dvTiptopLot.Table.Rows(0).Item("OEA10")) Then
                                Me.txtPO.Text = dvTiptopLot.Table.Rows(0).Item("OEA10").ToString
                            Else
                                Me.txtPO.Text = ""
                            End If

                            ' Me.txtDemandInfo.Text = Me.txtDemandInfo.Text.Split(Environment.NewLine)(0) + o_strPONo + Environment.NewLine + Me.txtDemandInfo.Text.Split(Environment.NewLine)(1)
                            Me.txtQty.Text = dvTiptopLot.Item(0).Item("sfb08").ToString()
                            Me.TxtPartid.Text = dvTiptopLot.Item(0).Item("sfb05").ToString()
                            Me.DtMoNeedTime.Text = dvTiptopLot.Item(0).Item("sfb81").ToString()
                            'If (Not String.IsNullOrEmpty(dvTiptopLot.Item(0).Item("tc_imc03").ToString())) AndAlso dvTiptopLot.Item(0).Item("tc_imc03").ToString().Length > 1 Then
                            '    Me.CboDept.SelectedIndex = Me.CboDept.FindString(dvTiptopLot.Item(0).Item("tc_imc03").ToString().Trim)
                            'Else
                            '    o_strMsg = "SAP中间表未找到部门，请联系生管维护线别或手动选择部门！"
                            '    SetMessage(o_strMsg)
                            '    Me.CboDept.SelectedIndex = -1
                            'End If
                            'If (Not String.IsNullOrEmpty(dvTiptopLot.Item(0).Item("sfb82").ToString())) AndAlso dvTiptopLot.Item(0).Item("sfb82").ToString().Length > 1 Then 'tc_imc03 ==> sfb82,cq 20150916
                            '    Me.CboLine.SelectedIndex = Me.CboLine.FindString(dvTiptopLot.Item(0).Item("sfb82").ToString().Trim)
                            'Else
                            '    o_strMsg += "SAP中间表未找到线别，请联系生管维护线别或手动选择线别！"
                            '    SetMessage(o_strMsg)
                            '    Me.CboLine.SelectedIndex = -1
                            '    'Exit Sub  
                            'End If

                            '设置部门
                            If (Not String.IsNullOrEmpty(deptIdSap)) AndAlso deptIdSap.Length > 1 Then
                                Me.CboDept.SelectedIndex = Me.CboDept.FindString(deptIdSap)
                            End If
                            '设置线别
                            If (Not String.IsNullOrEmpty(LineSap)) AndAlso LineSap.Length > 1 Then
                                Me.CboLine.SelectedIndex = Me.CboLine.FindString(LineSap)
                            End If

                            Me.CboMoType.SelectedIndex = 0

                            If (m_CheckAqci120 = "Y" And IsConSap = "N") Then

                                Dim dt As DataTable = SapCommon.GetCustAndSeriesID(Me.TxtPartid.Text.Trim)
                                If dt.Rows.Count > 0 Then
                                    o_strCusID = dt.Rows(0)("CusID").ToString
                                    o_strSerialID = dt.Rows(0)("SeriesID").ToString
                                End If
                                If o_strCusID = "" Then
                                    o_strCusID = SapCommon.getCusIDFromTT(Me.TxtPartid.Text.Trim)
                                End If

                                If String.IsNullOrEmpty(o_strCusID) Then
                                    'Modfiy by cq 20160314
                                    SetMessage("料号对应客户不存在,请找PQE在SPC中或者Tiptop Aqci120中维护料号对应客户!")
                                    Exit Sub
                                Else
                                    Me.CboCust.SelectedIndex = Me.CboCust.FindString(o_strCusID)
                                End If
                                If o_strSerialID = "" Then
                                    o_strSerialID = SapCommon.GetSerialIDFromTT(Me.TxtPartid.Text.Trim)
                                End If
                                If String.IsNullOrEmpty(o_strSerialID) Then
                                    'Modfiy by cq 20160314
                                    SetMessage("料号对应系列别不存在,请找PQE在SPC中【物料检验项目设置】中维护料号对应系列别!")
                                    Exit Sub
                                Else
                                    Me.CboSeries.SelectedIndex = Me.CboSeries.FindString(o_strSerialID)
                                End If
                                Me.CboSeries.Refresh()
                            End If

                            '是SAP
                            If (IsConSap = "Y") Then
                                '以后到spc新增专门维护功能才用
                                txtBlueprintVersion.Text = dvTiptopLot.Item(0).Item("ZZZEIVR").ToString()
                                txtPackageVersion.Text = dvTiptopLot.Item(0).Item("ZZCUST_VER").ToString()

                                '先从SPC获取料号如果没有到MES下载维护
                                'Dim dt As DataTable = SapCommon.GetCustAndSeriesID(Me.TxtPartid.Text.Trim)
                                'If dt.Rows.Count > 0 Then
                                '    o_strCusID = dt.Rows(0)("CusID").ToString
                                '    o_strSerialID = dt.Rows(0)("SeriesID").ToString
                                'End If

                                '不存在到MES中维护好料号，选择正确的客户和系列
                                'Dim strSQL As String = "SELECT top 1 CusId, SeriesID FROM m_PartContrastExtend_t WHERE tavcpart = pavcpart AND pavcpart = '{0}' " &
                                '                            SapCommon.GetPartFatory & " ORDER BY seriesid desc"

                                'strSQL = String.Format(strSQL, Me.TxtPartid.Text.Trim)

                                Dim dt As DataTable = CommClass.GetPartCusIdSeriIDDt(Me.TxtPartid.Text.Trim)
                                If (dt.Rows.Count = 0) Then
                                    SetMessage("料件对应客户/系列别不存在,请找PQE在SPC中【物料检验项目设置】维护！")
                                    Exit Sub
                                End If

                                o_strCusID = dt.Rows(0)("CusID").ToString
                                o_strSerialID = dt.Rows(0)("SeriesID").ToString
                                o_strItemCode = dt.Rows(0)("ItemCode").ToString
                                If o_strCusID = "" Then
                                    SetMessage("料号对应客户不存在,请找PQE在SPC中【物料检验项目设置】维护！")
                                    Exit Sub
                                End If
                                If o_strSerialID = "" Then
                                    SetMessage("料号对应系列别不存在,请找PQE在SPC中【物料检验项目设置】中维护！")
                                    Exit Sub
                                End If

                                '只对东莞厂区要求
                                If VbCommClass.VbCommClass.Factory = "0131" Then
                                    If o_strItemCode = "" Then
                                        SetMessage("料号对应项目代码不存在,请找PQE在SPC中【物料检验项目设置】中维护！")
                                        Exit Sub
                                    End If
                                End If

                                Me.CboCust.SelectedIndex = Me.CboCust.FindString(o_strCusID)
                                Me.CboSeries.SelectedIndex = Me.CboSeries.FindString(o_strSerialID)
                                '增加 田玉琳20191129
                                '如果不存在ITEMCODE，设置默认为N/A
                                If o_strItemCode = "" Then
                                    o_strItemCode = "N/A"
                                End If

                                Me.CboItemCode.SelectedIndex = Me.CboItemCode.FindString(o_strItemCode)
                            End If
                            m_strOrderNO = dvTiptopLot.Item(0).Item("sfb22").ToString()
                            m_strOrderSeq = dvTiptopLot.Item(0).Item("sfb221").ToString()
                            m_DeliveryDate = dvTiptopLot.Item(0).Item("oeb15").ToString()
                            m_ScheFinishDate = dvTiptopLot.Item(0).Item("sfb15").ToString()
                            If Not dvChildPart Is Nothing Then
                                SavaChildPart(dvChildPart)
                                'Dim ProductId As String = "", ModifyDate As String = ""
                                'GetProductModify(dvChildPart, ProductId, ModifyDate)
                                'If CheckBOM(ProductId, ModifyDate) Then
                                '    'IMA02=成套电缆，需要向下展开子BOM
                                '    SavaProductBOM(dvChildPart)
                                'End If
                            End If

                            '取得料件打印清和打印参数
                            If Not String.IsNullOrEmpty(Me.TxtPartid.Text.Trim()) Then
                                'GetPartToRefresh(Me.TxtPartid.Text.Trim(), sender, e)
                                GetLotPrintList(Me.txtMOId.Text.Trim, Me.TxtPartid.Text.Trim, Me.txtQty.Text.Trim, False)
                                ProcessLoadMo(Me.txtMOId.Text.Trim, dgvPrintList)
                                If (dgvPrintList.Rows.Count = 0) Then
                                    SetMessage("料号未设置标签信息，请找标签室维护【料件打印参数】!")
                                End If
                            End If
                            'SetMessage("")
                        Else
                            SetMessage("工单" & Me.txtMOId.Text.Trim() & "不存在!")
                            ClearQuery()
                        End If
                    Else
                        SetMessage("工单" & Me.txtMOId.Text.Trim() & "不存在或者该工单已完结!")
                        ClearQuery()
                    End If

                End If
                strMOID = Me.txtMOId.Text.Trim

                dtLot.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SetMessage("工单" & Me.txtMOId.Text.Trim() & "下载异常!")
            SetStepMessage("工单" + Me.txtMOId.Text.Trim + "下载异常!", False)
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "txtMOId_KeyDown", "sys")
        End Try
    End Sub

    Private Sub BnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnEdit.Click
        Try
            Dim FrmEditTime As New FrmEditTime
            FrmEditTime.ShowDialog()
            If SqlClassD.UpdateTime.ToString <> "" Then
                Me.LblPrintDate.Text = String.Format(CDate(SqlClassD.UpdateTime.ToString), "yyyy-MM-dd")
                SqlClassD.UpdateTime = ""
                PrtArray.NowDate = CDate(Me.LblPrintDate.Text).ToString("yyyy-MM-dd").ToString
                PrtArray.NowMonth = CDate(Me.LblPrintDate.Text).ToString("MM").ToString
                SetArrayLbl(PrtArray.ToArray)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BnEdit_Click", "sys")
        End Try
    End Sub

    Private Sub txtPrintCount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrintCount.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.CboDept.Focus()
        End If
        If Me.txtPrintCount.Text = "" And e.KeyChar = "0" Then
            e.Handled = True
            Exit Sub
        End If
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = vbTab Or e.KeyChar = vbCr Or e.KeyChar = vbLf Or e.KeyChar = Chr(22) Or e.KeyChar = Chr(24) Or e.KeyChar = Chr(3) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.CboDept.Focus()
        End If
        If Me.txtQty.Text = "" And e.KeyChar = "0" Then
            e.Handled = True
            Exit Sub
        End If
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = vbTab Or e.KeyChar = vbCr Or e.KeyChar = vbLf Or e.KeyChar = Chr(22) Or e.KeyChar = Chr(24) Or e.KeyChar = Chr(3) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub chbPrintListSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPrintListSelect.CheckedChanged
        Try
            If (Me.dgvPrintList.RowCount > 0) Then
                For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                    dgvPrintList.Rows(i).Cells("ChkSelect").Value = Me.chbPrintListSelect.Checked
                Next
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "chbPrintListSelect_CheckedChanged", "sys")
        End Try
    End Sub

#End Region

#Region "Function"

    Private Sub GetProductModify(ByVal dvBOM As DataView, ByRef ProductId As String, ByRef ModifyDate As String)
        If Not dvBOM Is Nothing Then
            For i As Int16 = 0 To dvBOM.Count - 1
                If (dvBOM.Item(i).Item("PARENT_PART").ToString = dvBOM.Item(i).Item("IMA01").ToString) Then
                    ProductId = dvBOM.Item(i).Item("PARENT_PART").ToString()
                    ModifyDate = dvBOM.Item(i).Item("MODIFYDATE").ToString()
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Function CheckBOM(ByVal ProductId As String, ByVal ModifyDate As String) As Boolean
        Dim dtPrintStatus As New DataTable
        Try
            dtPrintStatus = DbOperateUtils.GetDataTable("SELECT TOP 1 COMPONENT_ID, ISNULL(MODIFIY_DATE, DATEADD(year,-10,GETDATE())) AS MODIFIY_DATE FROM M_BOM_T WHERE PRODUCT_ID='" & ProductId & "' AND COMPONENT_ID='" & ProductId & "'")
            If (Not dtPrintStatus Is Nothing And dtPrintStatus.Rows.Count > 0) Then
                If (DateDiff("d", CDate(dtPrintStatus.Rows(0).Item("MODIFIY_DATE").ToString()), CDate(ModifyDate)) <= 0) Then
                    Return False
                Else
                    DbOperateUtils.ExecSQL("DELETE M_BOM_T WHERE PRODUCT_ID='" & ProductId & "'")
                    Return True
                End If
            Else
                Return True
            End If

            dtPrintStatus = Nothing
        Catch ex As Exception
            dtPrintStatus = Nothing
            Return False
        End Try
    End Function

    Private Sub CheckLotAgain(ByVal strMOid As String)
        Try
            If (String.IsNullOrEmpty(strMOid.Trim)) Then
                SetMessage("工单" & strMOid.Trim() & "不存在!")
                Exit Sub
            End If

            If CheckHaveData(strMOid) = False Then
                Exit Sub
            End If

            ''执行删除
            Dim SqlStr As String
            SqlStr = " DELETE m_SnAssign_t WHERE Moid IN (SELECT MOID FROM m_Mainmo_t WHERE ParentMo='" & strMOid.Trim & "')" & _
                    " DELETE m_Mainmo_t WHERE ParentMo='" & strMOid.Trim & "'"
            DbOperateUtils.ExecSQL(SqlStr)

            SetMessage("工单" & strMOid.Trim() & "删除成功!")
        Catch ex As Exception
            SetMessage("工单" & strMOid.Trim() & "删除失败!" + ex.Message.ToString())
        End Try
    End Sub

    '更新者田玉琳/20181203
    Private Function CheckHaveData(strMOid As String) As Boolean
        '检查是否已经打印
        Dim strSQL As String

        strSQL = "SELECT Ptaskid FROM m_Mainmo_t INNER JOIN m_SnAssign_t ON m_SnAssign_t.MOID=m_Mainmo_t.MOID WHERE m_Mainmo_t.ParentMo='" &
                 strMOid & "' AND FinishPrintQty>0"
        Dim dtPrintStatus As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If (Not dtPrintStatus Is Nothing And dtPrintStatus.Rows.Count > 0) Then
            SetMessage("工单" & strMOid & "已经打印，不允许重新下载或删除!")
            Return False
        End If

        strSQL = "SELECT TOP 1 Ppid from m_AssysnD_t WHERE Moid = '" & strMOid & "'"
        Dim dtScanStatus As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If (Not dtScanStatus Is Nothing And dtScanStatus.Rows.Count > 0) Then
            SetMessage("工单" & strMOid & "已经扫描记录，不允许重新下载或删除!")
            Return False
        End If

        Return True
    End Function

    Private Function CheckLotSave() As Boolean
        'Mark by cq 20171209
        'If (String.IsNullOrEmpty(strMOID)) Then
        '    SetMessage("工单BOM下载超时，请重新下载工单!")
        '    Return True
        'End If

        '20200626 田玉琳 判断如果没有权限下载退出
        If IsHaveProfitAuth(1) = False Then
            Return True
        End If

        If (String.IsNullOrEmpty(Me.txtMOId.Text.Trim())) Then
            SetMessage("请输入下载工单!")
            Return True
        End If
        If (String.IsNullOrEmpty(Me.TxtPartid.Text.Trim())) Then
            SetMessage("工单料号不能为空!")
            Return True
        End If
        If (String.IsNullOrEmpty(Me.txtQty.Text.Trim())) Then
            SetMessage("工单数量不能为空!")
            Return True
        Else
            If (CInt(Me.txtQty.Text.Trim()) <= 0) Then
                SetMessage("工单数量不能为空!")
                Return True
            End If
        End If
        If (String.IsNullOrEmpty(Me.CboShift.Text.Trim())) Then
            SetMessage("请选择班别!")
            Return True
        End If
        If (String.IsNullOrEmpty(Me.CboDept.Text.Trim())) Then
            SetMessage("请选择部门!")
            Return True
        End If
        If (String.IsNullOrEmpty(Me.CboLine.Text.Trim())) Then
            SetMessage("请选择线别!")
            Return True
        End If
        If (String.IsNullOrEmpty(Me.CboMoType.Text.Trim())) Then
            SetMessage("请选择工单类型!")
            Return True
        End If

        '只验证东莞厂区 谭丽辉要求
        If VbCommClass.VbCommClass.Factory = "0131" Then
            If (String.IsNullOrEmpty(Me.CboItemCode.Text.Trim())) Then
                SetMessage("请选择项目代码!")
                Return True
            End If
        End If

        Dim strUserName As String = ""
        Dim dt As DataTable = DbOperateUtils.GetDataTable("exec [usp_Duty_WeekPlanUserName] '','2'")

        If dt.Rows.Count > 0 Then
            strUserName = dt.Rows(0)(0).ToString
        End If

        '连接到SAP
        If (Not Me.CboCust.Text.Trim().Contains("---")) Then
            SetMessage("客户不存在,请联系值班人员" & strUserName & "维护客户基础资料!")
            Return True
        End If
        If (String.IsNullOrEmpty(Me.CboCust.Text.Trim())) OrElse String.IsNullOrEmpty(Me.CboCust.SelectedValue.ToString()) Then
            SetMessage("请选择客户,如客户不存在,请联系值班人员" & strUserName & "维护客户资料!")
            Return True
        End If

        If (String.IsNullOrEmpty(Me.CboSeries.Text.Trim())) OrElse String.IsNullOrEmpty(Me.CboSeries.SelectedValue.ToString()) Then
            SetMessage("请选择系列别,如系列别不存在,请联系值班人员" & strUserName & "维护系列别资料!")
            Return True
        End If

        'If (String.IsNullOrEmpty(Me.TxtFileVerNo.Text.Trim)) Then
        '    SetMessage("请输入图面版号!")
        '    Return True
        'End If
        If (String.IsNullOrEmpty(Me.txtBlueprintVersion.Text.Trim())) Then
            SetMessage("请输入蓝图版本!")
            Me.txtBlueprintVersion.Focus()
            Return True
        End If

        If (String.IsNullOrEmpty(Me.txtPackageVersion.Text.Trim())) Then
            SetMessage("请输入包规版本!")
            Me.txtPackageVersion.Focus()
            Return True
        End If

        If (String.IsNullOrEmpty(Me.txtPO.Text.Trim())) Then
            SetMessage("请输入合同号!")
            Me.txtPO.Focus()
            Return True
        End If

        Dim iSelect As Boolean = False
        Dim chkTemp As DataGridViewCheckBoxCell
        For i As Int16 = 0 To Me.dgvPrintList.Rows.Count - 1
            chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
            If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                If (String.IsNullOrEmpty(dgvPrintList.Rows(i).Cells("lableType").Value.ToString.Trim)) Then
                    SetMessage("请配置第" + (i + 1).ToString + "行料件打印参数，并确保其他料件参数已经配置OK!")
                    Exit For
                End If
                '判断是否设置模板
                If (String.IsNullOrEmpty(dgvPrintList.Rows(i).Cells("LabelTemplates").Value.ToString.Trim)) Then
                    SetMessage("请配置第" + (i + 1).ToString + "行料件打印模板，并确保其他料件打印模板已经配置OK!")
                    Exit For
                End If
                If (Microsoft.VisualBasic.Left(dgvPrintList.Rows(i).Cells("lableType").Value.ToString.Trim, 1) = "C") Then
                    If (String.IsNullOrEmpty(dgvPrintList.Rows(i).Cells("PackingQty").Value.ToString.Trim) Or CInt(dgvPrintList.Rows(i).Cells("PackingQty").Value.ToString.Trim) <= 0) Then
                        SetMessage("请配置第" + (i + 1).ToString + "行包装容量，并确保其他包装打印料件包装容量已经配置OK!")
                        Exit For
                    End If
                End If
                iSelect = True
            End If
        Next

        If (iSelect = False) Then
            SetMessage("料号未设置标签信息，请找标签室维护【料件打印参数】!")
            Return True
        End If

        Return False
    End Function


    '确认是否有利润中心权限
    Private Function IsHaveProfitAuth(stype As String) As Boolean
        Dim strSQL As String = " DECLARE @strmsgid varchar(1), @strmsgText nvarchar(150)" &
                               " EXEC GetCheckUserRightMoidNew '{0}','{1}','{2}','{3}','{4}',@strmsgid OUTPUT ,@strmsgText OUTPUT " &
                               " SELECT @strmsgid,@strmsgText"
        strSQL = String.Format(strSQL, SysMessageClass.UseId, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter,
                               CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString, stype)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)(0) = "1" Then
                SetMessage(dt.Rows(0)(1).ToString)
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub GridViewColumnEdit(ByVal gvName As DataGridView, ByVal ColumnNum As Integer)
        For I As Int16 = 0 To gvName.Columns.Count - 1
            gvName.Columns(1).ReadOnly = True
        Next
    End Sub

    Private Function CheckQueryParameter(ByVal MessageFlag As Boolean) As Boolean
        If (dtpStartDate.Value < dtpEndDate.Value) Then
            If (MessageFlag) Then
                MsgBox("查询结束时间不能大于开始时间！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
            End If
            Return True
        End If
        Return False
    End Function

    Private Function GetCheckLotSQL(ByVal LotName As String) As String
        Dim Sql As String
        Sql = " SELECT a.moid,a.Moqty,a.Ppidprtqty,a.Pkgprtqty,b.Qty,c.deptid + '-' + c.djc as deptname,a.PartID " _
            & "FROM m_Mainmo_t as a LEFT JOIN m_PartPack_t as b on a.PartID=b.Partid and b.Usey='Y' and b.Packid='C' " _
            & "LEFT JOIN m_Dept_t as c on a.Deptid=c.Deptid and c.usey='Y' WHERE moid=" & FormatQuerySQLString(LotName)
        Return Sql
    End Function



    Private Function CheckPrint(ByVal dgvPrint As DataGridView) As Boolean
        Dim iSelect As Boolean = False
        Dim chkTemp As DataGridViewCheckBoxCell
        Dim strTeskId As String
        Dim strMoid As String
        Dim strPartid As String
        Dim strPackItem As String
        Dim strPackId As String
        Dim strDisorderType As String
        Dim strVersion As String
        Dim strVersionType As String

        For I As Int16 = 0 To dgvPrintList.RowCount - 1
            chkTemp = dgvPrintList.Rows(I).Cells("ChkSelect")
            'Dim b As Boolean = chkTemp.FormattedValue

            If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then

                strTeskId = dgvPrintList.Rows(I).Cells("PtaskId").Value.ToString
                strMoid = dgvPrintList.Rows(I).Cells("Moid").Value.ToString
                strPartid = dgvPrintList.Rows(I).Cells("PartId").Value.ToString
                strPackId = Microsoft.VisualBasic.Left(dgvPrintList.Rows(I).Cells("lableType").Value.ToString, 1)
                strDisorderType = dgvPrintList.Rows(I).Cells("DisorderType").Value.ToString
                strPackItem = dgvPrintList.Rows(I).Cells("PackItem").Value.ToString
                strVersion = dgvPrintList.Rows(I).Cells("Remark").Value.ToString
                strVersionType = dgvPrintList.Rows(I).Cells("VersionTypeText").Value.ToString.Trim.Split("-")(0)

                '判断打印数量
                If Not IsNumeric(Me.txtPrintCount.Text.Trim) Then
                    SetMessage("输入打印数量有误！")
                    txtPrintCount.SelectAll()
                    txtPrintCount.Focus()
                    Return False
                    Exit For
                Else
                    If Integer.Parse(Me.txtPrintCount.Text.Trim) <= 0 Then
                        SetMessage("输入打印数量不能小于0！")
                        txtPrintCount.SelectAll()
                        txtPrintCount.Focus()
                        Return False
                        Exit For
                    End If
                End If

                'If Microsoft.VisualBasic.Left(Me.dgvPrintList.Rows(I).Cells("DisorderType").Value.ToString, 1) = "S" Then
                '    If (Int(Me.txtPrintCount.Text.Trim) > 1000) Then
                '        SetMessage("产品条码一次打印數量限制在1-1000以內！")
                '        Return False
                '        Exit For
                '    End If
                'End If
                '*****************************田玉琳 2017/04/01 取消测试打印管控 开始*****************************
                '检查打印数量(2017-03-22  马锋  打开打印数量管控),cq 20171123, add 客户限制+labeltype ='C' OR 'S'
                'If IsPrintLock() Then
                '    If Me.dgvLotList.Rows(Me.dgvLotList.CurrentRow.Index).Cells("CusName").Value.ToString = "华为" AndAlso _
                '   (Microsoft.VisualBasic.Left(dgvPrintList.Rows(I).Cells("lableType").Value.ToString.Trim, 1) = "S" Or Microsoft.VisualBasic.Left(dgvPrintList.Rows(I).Cells("lableType").Value.ToString.Trim, 1) = "C") Then

                '        If (Not CheckPrintQty(strTeskId, strMoid, strPackId, strPackItem, strDisorderType)) Then

                '            Dim dt As DataTable = GetApplyAddPrintDt(strTeskId, strPackId, strPackItem)
                '            If dt.Rows.Count > 0 Then

                '                If (MessageBox.Show("第" + (I + 1).ToString + "行,打印数量已超过需求数量，已有补数申请单，是否执行补数标签打印:" & Me.txtPrintCount.Text & "?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.Yes) Then
                '                    Dim FrmSelAdd As New FrmSelAddPrtInfo
                '                    FrmSelAdd.AppDt = dt
                '                    FrmSelAdd.ShowDialog()
                '                    If FrmSelAdd.IsFlag Then
                '                        Dim arr As String() = FrmSelAdd.SelApList.Split("-")
                '                        m_AddApplyList = arr(0).ToString
                '                        m_AddPrtQty = arr(1).ToString
                '                        If (CInt(Me.txtPrintCount.Text.Trim) > CInt(m_AddPrtQty)) Then
                '                            SetMessage("第" + (I + 1).ToString + "行,打印数量已超过需求数量，执行补数标签打印，补数需求数量为：" & m_AddPrtQty & ",当前打印数量已超出")
                '                            m_AddPrtCheck = False
                '                            Return False
                '                            Exit For
                '                        Else
                '                            m_AddPrtCheck = True
                '                            SetMessage("第" + (I + 1).ToString + "行，执行补数标签打印,数量为" & txtPrintCount.Text.Trim)
                '                            'Return False
                '                            'Exit For
                '                        End If
                '                    Else
                '                        m_AddPrtCheck = False
                '                        Return False
                '                        Exit For
                '                    End If
                '                Else
                '                    SetMessage("第" + (I + 1).ToString + "行打印数量已超过需求数量!不允许打印")
                '                    Return False
                '                    Exit For
                '                End If


                '            Else
                '                SetMessage("第" + (I + 1).ToString + "行打印数量已超过需求数量!")
                '                Return False
                '                Exit For
                '            End If

                '        End If
                '    End If
                'End If

                '*****************************田玉琳 2017/04/01 取消测试打印管控 结束*****************************

                '判断是否配置料件参数
                If (String.IsNullOrEmpty(dgvPrintList.Rows(I).Cells("lableType").Value.ToString.Trim)) Then
                    SetMessage("第" + (I + 1).ToString + "行料件打印参数，并确保其他料件参数已经配置OK!")
                    Return False
                    Exit For
                End If
                '判断是否设置模板
                If (String.IsNullOrEmpty(dgvPrintList.Rows(I).Cells("LabelTemplates").Value.ToString.Trim)) Then
                    SetMessage("第" + (I + 1).ToString + "行料件打印模板，并确保其他料件打印模板已经配置OK!")
                    Return False
                    Exit For
                End If
                If (Microsoft.VisualBasic.Left(dgvPrintList.Rows(I).Cells("lableType").Value.ToString.Trim, 1) = "C") Then
                    If (String.IsNullOrEmpty(dgvPrintList.Rows(I).Cells("PackingQty").Value.ToString.Trim) Or CInt(dgvPrintList.Rows(I).Cells("PackingQty").Value.ToString.Trim) <= 0) Then
                        SetMessage("第" + (I + 1).ToString + "行包装容量，并确保其他包装打印料件包装容量已经配置OK!")
                        Return False
                        Exit For
                    End If
                End If

                '判断打印机是否可用
                If (String.IsNullOrEmpty(dgvPrintList.Rows(I).Cells("PrinterName").EditedFormattedValue.ToString.Trim)) Then
                    SetMessage("第" + (I + 1).ToString + "行打印机，并确保其他料件打印机本机配置OK!")
                    Return False
                    Exit For
                Else
                    Dim ps As New PrinterSettings
                    ps.PrinterName = dgvPrintList.Rows(I).Cells("PrinterName").EditedFormattedValue.ToString.Trim
                    If (ps.IsValid = False) Then
                        SetMessage("第" + (I + 1).ToString + "行打印机不可用，请检查!")
                        Return False
                        Exit For
                    End If
                End If
                iSelect = True
            End If
        Next

        If (iSelect = False) Then
            SetMessage("请选择打印项目!")
        End If
        Return iSelect
    End Function

    Private Function CheckVersion(ByVal strPartid As String, ByRef strRtMessage As String) As Boolean
        Dim strMessage As String
        Try
            Dim strBlueprintVersion As String = ""
            Dim strPackageVersion As String = ""
            Dim strClassification As String = ""
            Dim strSQL As New StringBuilder
            Dim dtPartVersion As DataTable
            Dim strPartTemp As String
            Dim strCheckVersionFlag As String
            Dim strVersion As String

            strSQL.AppendLine(" SELECT * FROM OPENQUERY([172.20.22.101],'SELECT A.SOP_VER + CAST(A.SOP_GEN AS VARCHAR(8)) AS VERSION, A.CLASSIFICATION ")
            strSQL.AppendLine(" FROM OPENPLM.INNOVATOR.cad a INNER JOIN OPENPLM.INNOVATOR.cad_part b on a.id=b.source_id INNER JOIN OPENPLM.INNOVATOR.part c on b.related_id=c.id ")
            strSQL.AppendLine(" WHERE C.LX_IMA01 = ''" & strPartid & "'' AND A.STATE = ''Released'' AND A.IS_CURRENT = ''1'' ORDER BY A.SOP_GEN DESC, A.STATE DESC ')")

            dtPartVersion = DbOperateUtils.GetDataTable(strSQL.ToString)

            If (dtPartVersion Is Nothing) Then
                strRtMessage = "料件[" & strPartid & "],PLM版本不存在"
                Return False
            Else
                If (dtPartVersion.Rows.Count > 0) Then
                    For i As Int16 = 0 To dtPartVersion.Rows.Count - 1
                        strClassification = dtPartVersion.Rows(i).Item("CLASSIFICATION").ToString

                        If (InStr(strClassification, "蓝图") <> 0) Then
                            strBlueprintVersion = dtPartVersion.Rows(i).Item("VERSION").ToString
                        End If

                        If (InStr(strClassification, "包规") <> 0) Then
                            strPackageVersion = dtPartVersion.Rows(i).Item("VERSION").ToString
                        End If
                    Next

                    Dim chkTemp As DataGridViewCheckBoxCell
                    Dim bCheckVersion As Boolean = True

                    strMessage = "料件[" & strPartid & "],"
                    For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                        chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                            strPartTemp = Me.dgvPrintList.Rows(i).Cells("PartId").Value.ToString
                            If (strPartTemp = strPartid) Then
                                strCheckVersionFlag = Me.dgvPrintList.Rows(i).Cells("VersionTypeText").Value.ToString.Split("-")(0)
                                If (strCheckVersionFlag <> 0) Then
                                    strVersion = IIf(IsDBNull(Me.dgvPrintList.Rows(i).Cells("Remark").Value), "", Me.dgvPrintList.Rows(i).Cells("Remark").Value.ToString)

                                    Select Case (strCheckVersionFlag)
                                        Case ("1")
                                            If (strBlueprintVersion <> strVersion) Then
                                                bCheckVersion = False
                                                strMessage = strMessage + "蓝图版本[PLM:" & IIf(String.IsNullOrEmpty(strBlueprintVersion), "", strBlueprintVersion) & ",MES:" & strVersion & "]"
                                            End If
                                        Case ("2")
                                            If (strPackageVersion <> strVersion) Then
                                                bCheckVersion = False
                                                strMessage = strMessage + "包规版本[PLM:" & IIf(String.IsNullOrEmpty(strPackageVersion), "", strPackageVersion) & ",MES:" & strVersion & "]"
                                            End If
                                    End Select
                                End If
                            End If
                        End If
                    Next
                    If (bCheckVersion = False) Then
                        strRtMessage = strMessage + "和PLM不存在"
                        Return False
                    Else
                        Return True
                    End If
                Else
                    strRtMessage = "料件[" & strPartid & "],PLM版本不存在"
                    Return False
                End If
            End If
        Catch ex As Exception
            strRtMessage = "料件[" & strPartid & "],PLM版本获取异常"
            Return False
        End Try
    End Function

    Private Function FormatSQLString(ByVal Value As String) As String
        Return Value.Replace("'", "''")
    End Function

    Private Function FormatQuerySQLString(ByVal Value As String) As String
        Return "N'" & Value.Replace("'", "''") & "'"
    End Function

    Private Function InitializePrintParameter(ByVal PrintData As DataGridViewRow) As Boolean
        Dim Dtable As DataTable
        Try

            Dtable = DbOperateUtils.GetDataTable("select a.Moid,b.Lineid,a.Cusid,c.CodeRuleID,b.Ptaskid,c.Packid,A.PO, c.DistributionFlag,c.GroupPrintFlag from m_Mainmo_t as a join m_SnAssign_t as b " _
                                        & " on b.Moid=a.Moid and b.Estateid in('1','2') join m_PartPack_t as c on a.PartID=c.Partid and c.Packid=b.Packid AND c.Packitem= b.Packitem and c.Usey='Y' " _
                                        & " where b.Ptaskid='" & PrintData.Cells("Ptaskid").Value.ToString & "'")

            If Dtable.Rows.Count = 0 Then
                Return False
            End If

            LoadM.CodeRule = Dtable.Rows(0)!CodeRuleID.ToString
            LoadM.Packitem = PrintData.Cells("PackItem").Value.ToString
            LoadM.DisorderType = Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1)
            LoadM.PackingLevel = PrintData.Cells("PackingLevel").Value.ToString
            LoadM.Taskid = Dtable.Rows(0)!Ptaskid.ToString
            LoadM.DefaultMoid = Dtable.Rows(0)!Moid.ToString
            LoadM.DefaultLine = Dtable.Rows(0)!Lineid.ToString
            LoadM.CustID = Dtable.Rows(0)!Cusid.ToString
            LoadM.Factory = VbCommClass.VbCommClass.Factory
            LoadM.DeptJm = PrintData.Cells("djmdc").Value.ToString
            LoadM.vShift = PrintData.Cells("shift").Value.ToString
            LoadM.vLineJm = PrintData.Cells("LineJm").Value.ToString
            LoadM.vRequestDate = PrintData.Cells("Demandtime").Value.ToString
            LoadM.vIsprint = IIf(Me.ChkNotPrint.Checked, "Y", "N")
            LoadM.vCodeType = Dtable.Rows(0)!Packid.ToString
            LoadM.vVerNo = PrintData.Cells("FileVerNo").Value.ToString
            LoadM.vDriFlag = PrintData.Cells("DriFlag").Value.ToString
            LoadM.vBuildAttribute = PrintData.Cells("BuildAttribute").Value.ToString
            LoadM.PO = Dtable.Rows(0)!PO.ToString
            LoadM.DistributionFlag = Dtable.Rows(0)!DistributionFlag.ToString
            LoadM.GroupPrintFlag = Dtable.Rows(0)!GroupPrintFlag.ToString

            Dtable = DbOperateUtils.GetDataTable("select distinct a.TAvcPart,a.CustPart,c.CusName,b.Deptid,f.djc,b.Lineid,b.Moqty,b.Ppidprtqty,b.PkgPrtqty,d.Packid,j.TemplatePath,e.PFormatID,e.PaperSize,e.ColNum,e.RowNum,d.Packlink,d.Multiy,d.MultiQty,d.Qty,d.StartInt,d.StartSn,d.EndInt,d.EndSn,SpecFilterStr=isnull(k.SortName,'') " _
                    & "from m_PartContrast_t as a join m_Mainmo_t as b on a.TAvcPart=b.PartID and b.Moid='" & LoadM.DefaultMoid & "' and b.FinalY='N' " _
                    & "left join m_Dept_t as f on b.Deptid=f.Deptid left join m_Customer_t as c on a.CusID=c.CusID join m_PartPack_t as d on a.TAvcPart=d.Partid and d.CodeRuleID='" & LoadM.CodeRule & "' and d.usey='Y'  and d.PackItem='" & PrintData.Cells("PackItem").Value.ToString & "'" _
                    & "left join m_Sortset_t as k on c.CusID=k.SortID and k.SortType='SpecCharCustID' and k.Usey='Y' " _
                    & "left join m_SnPFormat_t as e on d.PFormatID=e.PFormatID  left join m_SnMFormat_t as j on d.PFormatID=j.PFormatID")

            If Dtable.Rows.Count = 0 Then
                Return False
            End If

            Dim dt As DataTable
            Dim strSQL As String = "SELECT PARAMETER_NAME,PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='MES' " &
                                   "AND PARAMETER_NAME IN ('MfgID','LocID', 'Madein','MadeinSX') AND PARAMETER_CODE = '{0}' "
            strSQL = String.Format(strSQL, VbCommClass.VbCommClass.Factory)
            dt = DbOperateUtils.GetDataTable(strSQL)

            LoadD.CurrAVCPartID = Dtable.Rows(0)("TAvcPart").ToString.ToUpper.Trim
            LoadD.CurrMoid = LoadM.DefaultMoid
            LoadD.PFormat = Dtable.Rows(0)("PFormatID").ToString
            LoadD.PrintColNum = Int(IIf(Dtable.Rows(0)("ColNum").ToString <> "", Dtable.Rows(0)("ColNum").ToString, 0)) * CInt(Dtable.Rows(0)("RowNum").ToString)
            LoadD.StartSn = Dtable.Rows(0)("StartSn").ToString
            LoadD.EndSn = Dtable.Rows(0)("EndSn").ToString
            LoadD.EndInt = Int(IIf(Dtable.Rows(0)("EndInt").ToString <> "", Dtable.Rows(0)("EndInt").ToString, "0"))
            LoadD.StartInt = Int(IIf(Dtable.Rows(0)("StartInt").ToString <> "", Dtable.Rows(0)("StartInt").ToString, "0"))
            LoadD.SpecFilterStr = Dtable.Rows(0)("SpecFilterStr").ToString '增加特殊过滤字符--by hs ke
            PackItems = Dtable.Rows(0)("Packid").ToString
            Packlink = Dtable.Rows(0)("Packlink").ToString
            MoidAllNum = Int(IIf(Dtable.Rows(0)("Moqty").ToString <> "", Dtable.Rows(0)("Moqty").ToString, 0))
            MoidPrinted = Int(IIf(Dtable.Rows(0)("PkgPrtqty").ToString <> "", Dtable.Rows(0)("PkgPrtqty").ToString, 0))

            'CtPrtingNum = Int(MoidAllNum / PackMethod) - MoidPrinted  '可打印箱數
            'MoidLastNum = MoidAllNum Mod PackMethod  '尾數
            PrtArray.AvcPartid = Dtable.Rows(0)("TAvcPart").ToString.ToUpper.Trim
            PrtArray.CusName = Dtable.Rows(0)("CusName").ToString.Trim
            PrtArray.Deptid = Dtable.Rows(0)("Deptid").ToString.ToUpper.Trim
            PrtArray.Lineid = LoadM.vLineJm
            PrtArray.Moid = LoadD.CurrMoid.ToUpper.Trim
            PrtArray.Qty = IIf(Dtable.Rows(0)("Qty").ToString <> "", Dtable.Rows(0)("Qty").ToString, "1")     'IIf(Dtable("Qty").ToString <> "", Dtable("Qty").ToString, 0)
            PrtArray.ConfigFlag = LoadM.vVerNo
            PrtArray.DriFlag = LoadM.vDriFlag
            PrtArray.BuildAttribute = LoadM.vBuildAttribute
            PrtArray.DateCode = ""
            PrtArray.WorkType = LoadM.vShift
            PrtArray.ContainerNo = "##/##"
            PrtArray.PO = LoadM.PO
            pFilePath = Dtable.Rows(0)("TemplatePath").ToString

            PrtArray.MfgID = ""
            PrtArray.LocID = ""
            PrtArray.Madein = ""
            PrtArray.MadeinSX = ""
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                Select Case dt.Rows(rowIndex).Item(0).ToString.ToUpper()
                    Case "MfgID".ToUpper()
                        PrtArray.MfgID = dt.Rows(rowIndex).Item(1).ToString
                    Case "LocID".ToUpper()
                        PrtArray.LocID = dt.Rows(rowIndex).Item(1).ToString
                    Case "Madein".ToUpper
                        PrtArray.Madein = dt.Rows(rowIndex).Item(1).ToString
                    Case "MadeinSX".ToUpper
                        PrtArray.MadeinSX = dt.Rows(rowIndex).Item(1).ToString
                End Select
            Next

            If MarkBarTable(Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1), PrintData.Cells("PackItem").Value.ToString) = False Then
                Exit Try
            End If

            '*****************************田玉琳 20170406 开始 *****************************
            Mreader = DbOperateUtils.GetDataTable("select  BarArea  from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule & "' order by F_orderid asc")
            '*****************************田玉琳 20170406 结束 *****************************

            SetArrayLbl(PrtArray.ToArray)

            Return True
        Catch ex As Exception

            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "InitializePrintParameter()", "sys")

            Exit Function
            'Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 获取补数标签申请数据，已审核，未打印完成的
    ''' </summary>
    ''' <param name="PtaskId"></param>
    ''' <param name="PackId"></param>
    ''' <param name="PackItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetApplyAddPrintDt(ByVal PtaskId As String, ByVal PackId As String, ByVal PackItem As String) As DataTable
        Dim Sqlstr As String = "select appid=a.ComplementApplicationId,a.PrtQty,FinishPrintQty=isnull(a.FinishPrintQty,0),ConfigurationQty," &
            "ApplyUserid=a.Userid+'/'+b.username,ApplyTime=a.Intime,a.Estateid from m_ComplementApplicationItem_t a join m_Users_t b on a.Userid=b.UserID " &
            "WHERE  a.Ptaskid='" & PtaskId & "' and Packid='" & PackId & "' and Packitem='" & PackItem & "' and (a.Estateid=1 or a.Estateid=2) "
        Return DbOperateUtils.GetDataTable(Sqlstr)
    End Function
    ''' <summary>
    ''' 华为标签数量锁定是否开启
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsPrintLock() As Boolean
        Dim Sqlstr As String = "select PARAMETER_VALUES from m_SystemSetting_t where  PARAMETER_CODE='PrintQtyLock' and PARAMETER_VALUES=1 and MODE_NAME='" & VbCommClass.VbCommClass.Factory & "' "
        Return DbOperateUtils.GetRowsCount(Sqlstr) > 0
    End Function
    ''' <summary>
    ''' 标签打印数量判定--包含补数标签ApplyAddQty by hs ke
    ''' </summary>
    ''' <param name="PtaskId"></param>
    ''' <param name="Moid"></param>
    ''' <param name="PackId"></param>
    ''' <param name="DisorderType"></param>
    ''' <param name="PackItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckPrintQty(ByVal PtaskId As String, ByVal Moid As String, ByVal PackId As String, ByVal DisorderType As String, ByVal PackItem As String) As Boolean
        Dim Sqlstr As String
        'AND Packid=
        Sqlstr = "SELECT PrtQty=ISNULL(PrtQty,0),ISNULL(FinishPrintQty,0) AS FinishPrintQty FROM m_SnAssign_t WHERE Ptaskid='" + PtaskId + "' AND Moid='" + Moid + "'"

        Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
        If dt.Rows.Count > 0 Then
            Dim D As String = dt.Rows(0)("FinishPrintQty").ToString
            Dim S As String = dt.Rows(0)("PrtQty").ToString
            If (CInt(dt.Rows(0)("FinishPrintQty").ToString) + CInt(Me.txtPrintCount.Text.Trim)) > CInt(dt.Rows(0)("PrtQty").ToString) Then
                Return False
            Else
                Return True
            End If
        End If
        Return False
    End Function

    Private Function CheckTestPrintQty(ByVal PtaskId As String, ByVal Moid As String, ByVal PackId As String, ByVal DisorderType As String, ByVal PackItem As String) As Boolean
        Dim Sqlstr As String
        'AND Packid=
        Sqlstr = "SELECT ISNULL(PrtTestQty,0) AS PrtTestQty,ISNULL(FinishTestPrintQty,0) AS FinishTestPrintQty FROM m_SnAssign_t WHERE Ptaskid='" + PtaskId + "' AND Moid='" + Moid + "'"

        Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
        If dt.Rows.Count > 0 Then
            Dim D As String = dt.Rows(0)("FinishTestPrintQty").ToString
            Dim S As String = dt.Rows(0)("PrtTestQty").ToString
            If (CInt(dt.Rows(0)("FinishTestPrintQty").ToString) + CInt(Me.txtPrintCount.Text.Trim)) > CInt(dt.Rows(0)("PrtTestQty").ToString) Then
                Return False
            Else
                Return True
            End If
        End If
        Return False
    End Function

    '建立條碼打印數組
    Private Function MarkBarTable(ByVal PackId As String, ByVal PackItem As String) As Boolean
        Dim Sqlstr As String = ""
        Dim RecTable As New DataTable
        '建立條碼組成部分並分別賦初值
        Try
            Sqlstr = "SELECT DISTINCT a.F_codeID,isnull(cast(b.ShortName as Nvarchar(128))," _
   & " LEFT(IIF(a.f_codeid='PO',ISNULL(mo.PO,c.DValues),c.DValues),F_codelen)) as ShortName," _
   & " a.F_orderid, a.UnitID, a.BarArea, a.SplitChar,a.DResource, a.IsStyle,a.IsPrintStyle,a.F_codelen,a.IsBoxQty  " _
   & " from m_SnRuleD_t as a join m_SnRuleM_t as d on a.CodeRuleID=d.CodeRuleID left join (select b.F_codeid,c.ShortName from m_SnSet_t as b " _
   & " join m_SnSet_t as c on b.CodeRuleID=c.CodeRuleID and b.F_codeid=c.F_codeid where b.CodeRuleID='" & LoadM.CodeRule.ToString & "' group by b.F_codeid,c.ShortName " _
   & " having count(b.f_codeid)=1) as b on a.F_codeid=b.F_codeid left join m_SnPartSet_t as c on a.F_codeid=c.F_codeid and d.LabelType=c.packid " _
   & " and c.partid='" & LoadD.CurrAVCPartID.ToString & "' and c.usey='Y'  and c.Packid='" & PackId & "' and c.Packitem='" & PackItem & "' " _
   & " LEFT JOIN m_Mainmo_t mo on mo.partid = c.Partid  and mo.moid ='" & LoadD.CurrMoid.ToString.Trim() & "'" _
   & " where a.CodeRuleID='" & LoadM.CodeRule.ToString & "'"
            RecTable = DbOperateUtils.GetDataTable(Trim(Sqlstr))
            If RecTable.Rows.Count > 0 Then
                BarCodePartTable = RecTable
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "MarkBarTable", "sys")
            Throw ex
        Finally
            RecTable.Dispose()
        End Try
    End Function

    '檢查樣式
    Private Function CheckStyle() As Boolean

        Dim Sqlstr As String, o_srtSql As New StringBuilder
        Dim dvSnDis As New DataView

        'Dim RecTable As New DataTable
        Try
            LoadD.StyleID = MakeStyle() '產生樣式
            '是否分段流水号
            If (LoadM.DistributionFlag = "Y") Then
                '分号段打印
                Dim dtDistribution As DataTable = DbOperateUtils.GetDataTable(" SELECT MinInt, MinSN, MaxInt, MaxSN, PrintInt, PrintSN,ISNULL(SNDistributionID,0) SNDistributionID FROM m_SNDistribution_t WHERE FactoryID = '" & VbCommClass.VbCommClass.Factory & "' AND PartId = '" & LoadD.CurrAVCPartID & "' AND CodeRuleId = '" & LoadM.CodeRule & "' ")

                If dtDistribution Is Nothing Or dtDistribution.Rows.Count = 0 Then
                    MsgBox("料号：" & LoadD.CurrAVCPartID & "分段流水码,未设置工厂号段！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Return False
                Else
                    'add by hgd 2018-01-22 检查是否多个料号共用一个样式
                    Sqlstr = " SELECT   SNDistributionID FROM m_SnDistributionStyle_t WHERE StyleID='" & LoadD.StyleID.ToString.Replace("'", "''") & "' AND  "
                    Sqlstr = Sqlstr & "   EXISTS (SELECT 1 FROM ( SELECT TOP 1 StyleID,MaxIn FROM (  SELECT a.StyleID,b.MinSN,b.MaxSN,count(1) AS Rcout,MAX(A.MaxInt) AS  MaxIn from m_SnDistributionStyle_t  a  INNER JOIN "
                    Sqlstr = Sqlstr & "  m_SNDistribution_t b on b.SNDistributionID=a.SNDistributionID   WHERE StyleID='" & LoadD.StyleID.ToString.Replace("'", "''") & "' GROUP BY a.StyleID,b.MinSN,b.MaxSN "
                    Sqlstr = Sqlstr & "  HAVING count(1)>1) AS t) as t1 where t1.StyleID= m_SnDistributionStyle_t.StyleID and t1.MaxIn=m_SnDistributionStyle_t.MaxInt) "
                    Dim dtMorePartStyle As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
                    If dtMorePartStyle.Rows.Count > 0 Then
                        '相同料号使用同一样式且号段一致，则取当前流水最大的记录
                        Me.SNDistributionID = dtMorePartStyle.Rows(0)!SNDistributionID.ToString
                    End If

                    'add by hgd 多号段，检验是否有选择号段
                    If Me.SNDistributionCount > 1 AndAlso String.IsNullOrEmpty(Me.SNDistributionID) Then
                        MsgBox("料号：" & LoadD.CurrAVCPartID & ",该厂区设置了多流水号段,必须选择一个号段打印！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                        Return False
                    End If
                    '检验是否超号段
                    If Me.SNDistributionCount > 1 Then
                        dvSnDis = New DataView(dtDistribution)
                        dvSnDis.RowFilter = "SNDistributionID='" & Me.SNDistributionID & "'"

                        If (Int(dvSnDis.ToTable.Rows(0).Item("PrintInt").ToString) + LoadD.CurrPrintNum > Int(dvSnDis.ToTable.Rows(0).Item("MaxInt").ToString)) Then
                            MsgBox("料号：" & LoadD.CurrAVCPartID & ",打印超过工厂号段设置！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                            Return False
                        End If
                    Else
                        '当前厂区只设置了一个号段
                        If (Int(dtDistribution.Rows(0).Item("PrintInt").ToString) + LoadD.CurrPrintNum > Int(dtDistribution.Rows(0).Item("MaxInt").ToString)) Then
                            MsgBox("料号：" & LoadD.CurrAVCPartID & ",打印超过工厂号段设置！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                            Return False
                        End If

                        Sqlstr = "update m_SnDistributionStyle_t set SNDistributionID='" & Me.SNDistributionID & "',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "' AND FactoryId='" & VbCommClass.VbCommClass.Factory & "' and SNDistributionID='" & Me.SNDistributionID & "' "
                        If strTestPrt <> "Y" Then
                            DbOperateUtils.ExecSQL(Sqlstr)
                        End If
                    End If

                End If

                '2016-12-26 马锋  增加解决多工厂流水码，不同码元和料号按样式起止号生成

                Dim dtSNDistributionStyle As New DataTable
                ' = DbOperateUtils.GetDataTable(" SELECT StyleID,MaxInt,MaxSN,IsUsed,ISNULL(SNDistributionID,0)SNDistributionID from m_SnDistributionStyle_t where StyleID='" & LoadD.StyleID.ToString.Replace("'", "''") & "' AND FactoryId = '" & VbCommClass.VbCommClass.Factory & "' ")
                Sqlstr = "SELECT StyleID,MaxInt,MaxSN,IsUsed,ISNULL(SNDistributionID,0)SNDistributionID from m_SnDistributionStyle_t where StyleID='" & LoadD.StyleID.ToString.Replace("'", "''") & "' AND FactoryId = '" & VbCommClass.VbCommClass.Factory & "' "
                If Not Me.SNDistributionID Is Nothing AndAlso Not String.IsNullOrEmpty(Me.SNDistributionID) Then
                    Sqlstr = Sqlstr + " AND SNDistributionID='" & Me.SNDistributionID & "'"
                End If
                dtSNDistributionStyle = DbOperateUtils.GetDataTable(Sqlstr)
                If Not dtSNDistributionStyle Is Nothing And dtSNDistributionStyle.Rows.Count > 0 Then
                    'Add by hgd 2017-04-25 厂区多号段打印
                    If Me.SNDistributionCount > 1 And Not Me.SNDistributionID Is Nothing Then
                        Dim dvSnDisStyle As New DataView
                        Dim dtSnDisStyle As New DataTable
                        dvSnDisStyle = New DataView(dtSNDistributionStyle)
                        dvSnDisStyle.RowFilter = "SNDistributionID='" & Me.SNDistributionID & "'"
                        dtSnDisStyle = dvSnDisStyle.ToTable()

                        If dtSnDisStyle.Rows.Count > 0 Then
                            '打印未锁住的
                            If dtSnDisStyle.Rows(0).Item("IsUsed").ToString = "N" Then
                                LoadD.BarCodeStyleMax = dtSnDisStyle.Rows(0).Item("MaxSN").ToString
                                LoadD.CurrMaxInt = Int(dtSnDisStyle.Rows(0).Item("MaxInt").ToString)
                                Sqlstr = "update m_SnDistributionStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "' AND FactoryId='" & VbCommClass.VbCommClass.Factory & "' and SNDistributionID='" & Me.SNDistributionID & "'"
                                If strTestPrt <> "Y" Then
                                    DbOperateUtils.ExecSQL(Sqlstr)
                                End If
                            Else
                                MsgBox("此工單正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                                Return False
                            End If
                        Else
                            '从未绑定过的，关联号段设置表，打印未锁住的

                            Dim tempArrDis() As DataRow
                            tempArrDis = dtSNDistributionStyle.Select("SNDistributionID='0'")
                            If tempArrDis.Length > 0 Then
                                If tempArrDis(0).Item("IsUsed").ToString = "N" Then
                                    LoadD.BarCodeStyleMax = tempArrDis(0).Item("MaxSN").ToString
                                    LoadD.CurrMaxInt = Int(tempArrDis(0).Item("MaxInt").ToString)
                                    Sqlstr = "update m_SnDistributionStyle_t set IsUsed='Y',SNDistributionID='" & Me.SNDistributionID & "',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "' AND FactoryId='" & VbCommClass.VbCommClass.Factory & "' and SNDistributionID is null"
                                    If strTestPrt <> "Y" Then
                                        DbOperateUtils.ExecSQL(Sqlstr)
                                    End If
                                Else
                                    MsgBox("此工單正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                                    Return False
                                End If
                            End If

                        End If

                    Else
                        '独立号段，打印未锁住的
                        If dtSNDistributionStyle.Rows(0).Item("IsUsed").ToString = "N" Then
                            LoadD.BarCodeStyleMax = dtSNDistributionStyle.Rows(0).Item("MaxSN").ToString
                            LoadD.CurrMaxInt = Int(dtSNDistributionStyle.Rows(0).Item("MaxInt").ToString)
                            Sqlstr = "update m_SnDistributionStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "' AND FactoryId='" & VbCommClass.VbCommClass.Factory & "' and SNDistributionID='" & Me.SNDistributionID & "' "
                            If strTestPrt <> "Y" Then
                                DbOperateUtils.ExecSQL(Sqlstr)
                            End If
                        Else
                            MsgBox("此工單正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                            Return False
                        End If
                    End If




                Else
                    'add by hgd 2017-04-25 添加厂区多号段
                    If Me.SNDistributionCount > 1 And Not Me.SNDistributionID Is Nothing Then

                        LoadD.StartSn = dvSnDis.ToTable.Rows(0).Item("MinSN").ToString
                        LoadD.StartInt = Int(dvSnDis.ToTable.Rows(0).Item("MinInt").ToString)
                    Else

                        LoadD.StartSn = dtDistribution.Rows(0).Item("MinSN").ToString
                        LoadD.StartInt = Int(dtDistribution.Rows(0).Item("MinInt").ToString)
                        Me.SNDistributionID = dtDistribution.Rows(0).Item("SNDistributionID").ToString
                    End If
                    LoadD.BarCodeStyleMax = LoadD.StartSn.ToString
                    LoadD.CurrMaxInt = LoadD.StartInt
                    Sqlstr = "insert into m_SnDistributionStyle_t(StyleID, FactoryId, StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime,SNDistributionID) values('" & LoadD.StyleID.Replace("'", "''") & "', '" & VbCommClass.VbCommClass.Factory & "','" & LoadD.StyleID.Replace("'", "''") & "'," & LoadD.StartInt & ",'" & LoadD.StartSn & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & Me.SNDistributionID & "')"
                    If strTestPrt <> "Y" Then
                        DbOperateUtils.ExecSQL(Sqlstr)
                    End If
                End If
                '*****************************  马锋 2016-12-26   *************************
            Else
                '顺序打印
                If IsSectionSCodeRule(LoadM.CodeRule) Then
                    ' Sqlstr = "select StyleID,MaxInt,MaxSN,ISNULL(IsUsed,'N')IsUsed from m_SnStyle_t " & _
                    '          " where StyleID='" & LoadD.StyleID.ToString.Replace("'", "''") & "' AND CodeRuleID='" & LoadM.CodeRule & "'"
                    Sqlstr = "SELECT * FROM dbo.f_getPrintMaxSN('" & LoadD.StyleID.ToString.Replace("'", "''") & "','" & LoadM.CodeRule & "') "

                Else
                    Sqlstr = "select StyleID,MaxInt,MaxSN,ISNULL(IsUsed,'N')IsUsed from m_SnStyle_t where StyleID='" & LoadD.StyleID.ToString.Replace("'", "''") & "'"
                End If
                Using RecTable As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
                    If RecTable.Rows.Count > 0 Then
                        If RecTable.Rows(0)("IsUsed").ToString = "N" Then
                            LoadD.BarCodeStyleMax = RecTable.Rows(0)("MaxSN").ToString
                            LoadD.CurrMaxInt = Int(RecTable.Rows(0)("MaxInt").ToString)
                            If LoadM.SectionCodeRule = True Then

                                'copy the already exists data to new table
                                o_srtSql.Append(" if not exists ( select top 1 1 from m_snstylesection_t WHERE StyleID='" & LoadD.StyleID.Replace("'", "''") & "' AND CodeRuleID ='" & LoadM.CodeRule & "')")
                                o_srtSql.AppendLine(" begin ")
                                o_srtSql.Append(" INSERT INTO m_snstylesection_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Descripe,Userid,Intime)")
                                o_srtSql.Append("  SELECT StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Descripe,Userid,Intime ")
                                o_srtSql.Append(" FROM m_SnStyle_t WHERE StyleID='" & LoadD.StyleID.Replace("'", "''") & "' AND CodeRuleID ='" & LoadM.CodeRule & "'")
                                o_srtSql.AppendLine(" end ")

                                Sqlstr = o_srtSql.ToString + " UPDATE m_SnStylesection_t SET IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "' AND CodeRuleID ='" & LoadM.CodeRule & "'"
                            Else
                                Sqlstr = "update m_SnStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "'"
                            End If

                            If strTestPrt <> "Y" Then
                                DbOperateUtils.ExecSQL(Sqlstr)
                            End If
                        Else
                            MsgBox("此工單正在打印中！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                            Return False
                        End If
                    Else
                        'update by hgd 2017-09-06 判断起始流水码是否大于0
                        If LoadD.StartInt < 0 Then
                            LoadD.StartInt = 0
                            LoadD.StartSn = ""
                        End If

                        LoadD.BarCodeStyleMax = LoadD.StartSn.ToString
                        LoadD.CurrMaxInt = LoadD.StartInt

                        If loadm.SectionCodeRule Then
                            Sqlstr = "insert into m_SnStylesection_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & LoadD.StyleID.Replace("'", "''") & "','" & LoadD.CurrAVCPartID & "','" & LoadM.CodeRule & "','" & LoadD.StyleID.Replace("'", "''") & "'," & LoadD.StartInt & ",'" & LoadD.StartSn & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
                        Else
                            Sqlstr = "insert into m_SnStyle_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & LoadD.StyleID.Replace("'", "''") & "','" & LoadD.CurrAVCPartID & "','" & LoadM.CodeRule & "','" & LoadD.StyleID.Replace("'", "''") & "'," & LoadD.StartInt & ",'" & LoadD.StartSn & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
                        End If

                        If strTestPrt <> "Y" Then
                            DbOperateUtils.ExecSQL(Sqlstr)
                        End If
                    End If
                End Using
            End If
            dvSnDis.Dispose()
            Return True
        Catch ex As Exception
            LoadM.OpenLock(LoadD.StyleID.Replace("'", "''"))

            If (LoadM.DistributionFlag = "Y") Then
                LoadM.OpenDistributionLock(LoadD.StyleID.Replace("'", "''"), VbCommClass.VbCommClass.Factory, Me.SNDistributionID)
            End If
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "CheckStyle", "sys")
            Throw ex
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 检查是否 是相同的条码样式，但是流水不一样， hq1，hq5存在第一位流水区分产品的特殊情况
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsSectionSCodeRule(ByVal strCodeRule As String) As Boolean
        Dim lssql As String = String.Empty
        lssql = "SELECT TOP 1 1 FROM m_SNCodeSectionS_t WHERE CodeRuleID='" & strCodeRule & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsSectionSCodeRule = True
                LoadM.SectionCodeRule = True
            Else
                IsSectionSCodeRule = False
                LoadM.SectionCodeRule = False
            End If
        End Using

    End Function

    '例行檢查
    Private Function Checking(ByVal PrintData As DataGridViewRow) As Boolean

        Dim FCLNumber As Int32
        Dim TrunkNumber As Int32

        '測試端口是否存在
        'If SysMessageClass.PrinterPort.Trim = "" Then
        '    MsgBox("請選擇打印端口,並下載字體！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
        '    Return False
        'End If
        '檢測AVC料件

        If LoadD.CurrAVCPartID = "" OrElse LoadD.CurrAVCPartID = "##########" Then
            MsgBox("條碼中各部分不能為空!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Return False
        End If
        '檢測打印數量   AndAlso Int(Me.txtPrintCount.Text.Trim) <= 1000
        If IsNumeric(Me.txtPrintCount.Text.Trim) Then
            If (CInt(Me.txtPrintCount.Text.Trim) <= 0) Then
                MsgBox("打印数量必须大于0！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Return False
            End If
            If (Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) = "C" Or Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1) = "C" Or Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1) = "P") Then

                If ((CInt(Me.txtPrintCount.Text.Trim) Mod CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)) = 0) Then
                    FCLNumber = CInt(Me.txtPrintCount.Text.Trim) / CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)
                    TrunkNumber = 0
                    LoadD.MantissaFlag = False
                Else
                    FCLNumber = Int(CInt(Me.txtPrintCount.Text.Trim) / CInt(PrintData.Cells("PackingQty").Value.ToString.Trim))
                    TrunkNumber = 1
                    LoadD.MantissaFlag = True
                    LoadD.MantissaBoxQty = CInt(Me.txtPrintCount.Text.Trim) Mod CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)
                End If
                LoadD.CurrPrintNum = FCLNumber + TrunkNumber

            Else
                '当前待打印数量=打印数*配置数
                LoadD.CurrPrintNum = CInt(Me.txtPrintCount.Text.Trim) * CInt(PrintData.Cells("ConfigurationQty").Value.ToString.Trim)
                LoadD.MantissaFlag = False
            End If
        Else
            LoadD.CurrPrintNum = 0
            MsgBox("一次打印數量限制在1-1000以內！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Return False
        End If
        'If Int(Me.LblMoidPrinted.Text.Trim) + LoadD.CurrPrintNum > Int(Me.LblMoidNum.Text.Trim) Then
        '    If MessageBox.Show("你申請的打印量已超標，請確認是否需要打印這么多量？", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Return False
        'End If
        Return True
    End Function

    Private Function CheckingPrintQuantity(ByVal strPOInfo As String, ByVal PrintData As DataGridViewRow) As Boolean
        Try
            Dim FCLNumber As Int32
            Dim TrunkNumber As Int32
            Dim strPOValue As String
            Dim strPrintQuantity As String
            Dim arrPOInfo As Array = Split(strPOInfo, "*")
            strPOValue = arrPOInfo(0)
            strPrintQuantity = arrPOInfo(1)

            If LoadD.CurrAVCPartID = "" OrElse LoadD.CurrAVCPartID = "##########" Then
                MsgBox("條碼中各部分不能為空!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Return False
            End If

            If IsNumeric(strPrintQuantity) Then
                If (CInt(strPrintQuantity) <= 0) Then
                    MsgBox("打印数量必须大于0！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Return False
                End If
                If (Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) = "C" Or Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1) = "C" Or Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1) = "P") Then

                    If ((CInt(strPrintQuantity) Mod CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)) = 0) Then
                        FCLNumber = CInt(strPrintQuantity) / CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)
                        TrunkNumber = 0
                        LoadD.MantissaFlag = False
                    Else
                        FCLNumber = Int(CInt(strPrintQuantity) / CInt(PrintData.Cells("PackingQty").Value.ToString.Trim))
                        TrunkNumber = 1
                        LoadD.MantissaFlag = True
                        LoadD.MantissaBoxQty = CInt(strPrintQuantity) Mod CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)
                    End If
                    LoadD.CurrPrintNum = FCLNumber + TrunkNumber

                Else
                    LoadD.CurrPrintNum = CInt(strPrintQuantity) * CInt(PrintData.Cells("ConfigurationQty").Value.ToString.Trim)
                    LoadD.MantissaFlag = False
                End If

                For I As Int16 = 0 To BarCodePartTable.Rows.Count - 1
                    If (BarCodePartTable.Rows(I).Item("F_codeID").ToString = "PO") Then
                        BarCodePartTable.Rows(I).Item("ShortName") = strPOValue
                    End If
                Next
            Else
                LoadD.CurrPrintNum = 0
                MsgBox("一次打印數量限制在1-1000以內！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function CheckPOString(ByVal strPO As String, ByRef POQuantity As Double) As Boolean
        Dim rtValue As Boolean = True
        Try
            If (InStr(strPO, "，") > 0 And InStr(strPO, "*") > 0) Then
                Dim arrPrintList As New ArrayList(Split(strPO, "，"))
                Dim arrPOInfo As Array

                For i As Integer = 0 To arrPrintList.Count - 1
                    If arrPrintList(i) = "-" Then
                        Continue For
                    End If

                    arrPOInfo = Split(arrPrintList(i), "*")

                    If (arrPOInfo.Length >= 2) Then
                        If (IsNumeric(arrPOInfo(1))) Then
                            POQuantity = POQuantity + arrPOInfo(1)
                        Else
                            rtValue = False
                            Exit For
                        End If
                    Else
                        rtValue = False
                        Exit For
                    End If
                Next
            Else
                rtValue = False
            End If

        Catch ex As Exception
            rtValue = False
        End Try
        Return rtValue
    End Function

    '產生樣式
    Private Function MakeStyle() As String
        Dim I As Integer
        Dim Flag As Boolean = False
        Dim ChkFlag As Boolean = False
        Dim TempView As DataView
        LoadD.ChkPos = 0
        LoadD.IsChkFlag = ""
        Dim BarCodeStyle As New StringBuilder
        AxTempCode.Remove(0, AxTempCode.Length)
        LblTempCode.Remove(0, LblTempCode.Length)
        YMDCode.Remove(0, YMDCode.Length)  'ADD 田玉琳 2016/03/21
        Try
            TempView = New DataView(BarCodePartTable)
            TempView.RowFilter = "bararea='BarCode1'"
            TempView.Sort = "f_orderid asc"
            '產生樣式
            For I = 0 To TempView.Count - 1
                '******************ADD 田玉琳 2016/03/21**********************************Start
                If (TempView.Item(I).Item("F_codeID").ToString = "Y" OrElse
                 TempView.Item(I).Item("F_codeID").ToString = "M" OrElse
                 TempView.Item(I).Item("F_codeID").ToString = "D" OrElse
                 TempView.Item(I).Item("F_codeID").ToString = "W") AndAlso
                 TempView.Item(I).Item("UnitID").ToString <> "" Then
                    YMDCode.Append(TempView.Item(I).Item("ShortName").ToString)
                End If

                '检查Barcode起始位置Add By KyLinQiu 20170609 --预留校验位 by kehuasong 20190408
                If (TempView.Item(I).Item("F_codeID").ToString.ToUpper = "XC") AndAlso (TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC2" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC3" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC4" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC5" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC6" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC7" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC8" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC9") AndAlso ChkFlag = False Then
                    LoadD.ChkPos = AxTempCode.Length
                    LoadD.IsChkFlag = TempView.Item(I).Item("UnitID").ToString.ToUpper
                    ChkFlag = True
                End If

                '******************ADD 田玉琳 2016/03/21**********************************end
                If TempView.Item(I).Item("IsPrintStyle").ToString = "Y" Then
                    BarCodeStyle.Append(TempView.Item(I).Item("ShortName").ToString)
                    AxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                Else
                    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" AndAlso Flag = False Then
                        LoadD.AxSPos = AxTempCode.Length
                        Flag = True
                    End If
                    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "Q" Then
                        AxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                    Else
                        If TempView.Item(I).Item("ShortName").ToString.Trim <> "" Then
                            AxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                        Else
                            If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "XC" Then
                                AxTempCode.Append(TempView.Item(I).Item("F_codeID").ToString.Substring(0, TempView.Item(I).Item("F_codelen")))
                            Else
                                AxTempCode.Append(TempView.Item(I).Item("F_codeID").ToString)
                            End If

                        End If
                    End If
                    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "XC" Then
                        BarCodeStyle.Append(TempView.Item(I).Item("F_codeID").ToString.Substring(0, TempView.Item(I).Item("F_codelen")))
                    Else
                        BarCodeStyle.Append(TempView.Item(I).Item("F_codeID").ToString)
                    End If

                End If
                'BarCodeStyle.Append(TempView.Item(I).Item("SplitChar").ToString)
            Next

            Flag = False
            ChkFlag = False
            TempView = New DataView(BarCodePartTable)
            TempView.RowFilter = "bararea='BarLabel1'"
            TempView.Sort = "f_orderid asc"
            '產生樣式Label1
            For I = 0 To TempView.Count - 1
                '检查Barcode起始位置Add By KyLinQiu 20170609
                If (TempView.Item(I).Item("F_codeID").ToString.ToUpper = "XC") AndAlso (TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC2" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC3" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC4" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC5" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC6" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC7" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC8" Or TempView.Item(I).Item("UnitID").ToString.ToUpper = "XC9") AndAlso ChkFlag = False Then
                    LoadD.ChkLblPos = AxTempCode.Length
                    ChkFlag = True
                End If

                If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" AndAlso Flag = False Then
                    LoadD.LblSPos = LblTempCode.Length
                    Flag = True
                End If
                If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" Then
                    LblTempCode.Append(TempView.Item(I).Item("F_codeID").ToString)
                ElseIf TempView.Item(I).Item("F_codeID").ToString.ToUpper = "XC" Then
                    LblTempCode.Append(TempView.Item(I).Item("F_codeID").ToString.Substring(0, TempView.Item(I).Item("F_codelen")))
                Else
                    LblTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                End If

                'If TempView.Item(I).Item("F_codeID").ToString.ToUpper <> "S" Then
                '    LblTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                'End If
                'If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" Then
                '    LblTempCode.Append(TempView.Item(I).Item("F_codeID").ToString)
                'End If

                LblTempCode.Append(TempView.Item(I).Item("SplitChar").ToString)
            Next

            Return BarCodeStyle.ToString
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "MakeStyle", "sys")
            Throw ex
            Return ""
        End Try
    End Function

    Private Function GetTaskId() As String
        Dim SqlStr As String
        Dim Taskid As String = ""
        Try
            SqlStr = "declare @Taskid varchar(11) " & _
                " select @Taskid=Ptaskid from m_SnAssign_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " & _
                " if @@rowcount=0 begin set @Taskid='T' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " & _
                " set @Taskid=left(@Taskid,7) + right(Replicate('0',4) + cast(right(@Taskid,4)+1 as varchar),4) End  SELECT @Taskid AS Taskid"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
            If dt.Rows.Count > 0 Then
                Taskid = dt.Rows(0)("Taskid").ToString
            End If
        Catch ex As Exception
            Taskid = ""
        End Try
        Return Taskid
    End Function

    Private Function CheckDemand(ByVal DemandTime As String) As Boolean
        Dim strTemp As String = ""
        Try
            strTemp = FormatDateTime(DemandTime)
            Return True
        Catch
            Return False
        End Try
    End Function
#End Region

#Region "Bind"

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)

        Dim UserDg As DataTable

        If ColComboBox.Name = "CboMoType" Then
            UserDg = CommClass.GetMotypeDt() ' UserDg = DbOperateUtils.GetDataTable("select typeid,motype from motype_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "motype"
            ColComboBox.ValueMember = "typeid"
        ElseIf ColComboBox.Name = "CboDept" Then
            'If VbCommClass.VbCommClass.IsConSap = "Y" Then
            '    UserDg = DbOperateUtils.GetDataTable("select deptid+'_'+dqc as djc,deptid from   m_Dept_t where factoryid='" & VbCommClass.VbCommClass.PCompany & "' and deptid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='10109_' and userid='" & SysMessageClass.UseId & "')")

            'Else
            '    UserDg = DbOperateUtils.GetDataTable("select deptid+'_'+dqc  as djc,deptid from   m_Dept_t where factoryid='" & VbCommClass.VbCommClass.Factory & "' and deptid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='10109_' and userid='" & SysMessageClass.UseId & "')")

            'End If
            UserDg = CommClass.GetUserDeptDt()
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "djc"
            ColComboBox.ValueMember = "deptid"
        ElseIf ColComboBox.Name = "CboCust" Then
            UserDg = CommClass.GetCustomerDt()
            ' UserDg = DbOperateUtils.GetDataTable("Select (CusID+'---'+CusName) CusName ,CusID from m_Customer_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "CusName"
            ColComboBox.ValueMember = "CusID"
        ElseIf ColComboBox.Name = "CboCust" Then
            UserDg = CommClass.GetCustomerDt()
            ' UserDg = DbOperateUtils.GetDataTable("Select (CusID+'---'+CusName) CusName ,CusID from m_Customer_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "CusName"
            ColComboBox.ValueMember = "CusID"
        ElseIf ColComboBox.Name = "CboLine" Then
            Dim deptid As String = ""
            If CboDept.SelectedValue IsNot Nothing Then
                deptid = CboDept.SelectedValue.ToString()
            End If
            UserDg = CommClass.GetDeptLineDt(deptid) ' DbOperateUtils.GetDataTable("Select  lineid,lineid from Deptline_t where deptid='" & deptid & "'")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "lineid"
            ColComboBox.ValueMember = "lineid"
            'Dim sql As String = "SELECT distinct lineid,lineid from Deptline_t A JOIN m_Dept_t B ON A.deptid=B.deptid where B.FACTORYID='" & VbCommClass.VbCommClass.Factory & "'"
            'If Not String.IsNullOrEmpty(profitcenter) Then
            '    sql = sql + " and b.profitcenter='" & profitcenter & "'"
            'End If
            'sql = sql + " order by a.lineid "
            'UserDg = DbOperateUtils.GetDataTable(sql)
            'ColComboBox.DataSource = UserDg
            'ColComboBox.DisplayMember = "lineid"
            'ColComboBox.ValueMember = "lineid"
        ElseIf ColComboBox.Name = "CboItemCode" Then
            UserDg = CommClass.GetItemCodeDt()
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "ProjectName"
            ColComboBox.ValueMember = "ProjectName"
        ElseIf ColComboBox.Name = "CboSeries" Then
            UserDg = CommClass.GetSeriesDt()
            'UserDg = DbOperateUtils.GetDataTable(" SELECT ([SeriesID]+'---'+[SeriesName])SeriesName ,[SeriesID] FROM [m_Series_t] WHERE Usey='Y'")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "SeriesName"
            ColComboBox.ValueMember = "SeriesID"
        End If
        UserDg = Nothing
    End Sub
#End Region

#Region "方法"
    Private Sub SavaProductBOM(ByVal dvChildPart As DataView)
        Dim strChildSava As New StringBuilder
        Dim strPartType As String
        Dim strBomVersion As String
        Dim strItemNumber As String
        Try
            '后续关闭 AmountQty组件用量更新(配置数)
            '更改使用BOM检查
            strBomVersion = "V1.0"
            For i As Int16 = 0 To dvChildPart.Count - 1
                strItemNumber = i + 1
                If (Not String.IsNullOrEmpty(dvChildPart.Item(i).Item("IMA01").ToString) And Convert.ToInt16(dvChildPart.Item(i).Item("BMD03").ToString) <= 1) Then
                    If dvChildPart.Item(i).Item("PARENT_PART").ToString = dvChildPart.Item(i).Item("IMA01").ToString Then
                        strPartType = "0"
                    Else
                        strPartType = "1"
                    End If

                    strChildSava.Append(vbNewLine &
                        "IF NOT EXISTS(SELECT COMPONENT_ID FROM M_BOM_T WHERE COMPONENT_ID='" &
                        dvChildPart.Item(i).Item("IMA01").ToString & "' AND PRODUCT_ID='" & dvChildPart.Item(i).Item("PARENT_PART").ToString &
                        "' ) BEGIN INSERT INTO M_BOM_T(COMPONENT_ID, PRODUCT_ID, VERSION, ITEM_NUMBER, PART_NUMBER, QUANTITY, NAME, DESCRIPTION, SPECIFICATION, " &
                        "PART_TYPE, TYPE_NAME, REF_DES, FLAGS, MODIFIY_DATE) VALUES(N'" & dvChildPart.Item(i).Item("IMA01").ToString & "',N'" &
                        dvChildPart.Item(i).Item("PARENT_PART").ToString & "',N'" & strBomVersion & "','" & strItemNumber & "',N'" &
                        dvChildPart.Item(i).Item("IMA01").ToString & "',N'" & dvChildPart.Item(i).Item("BMB06").ToString & "' " &
                        ",N'" & dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''") & "',N'" &
                        dvChildPart.Item(i).Item("IMA021").ToString.Replace("'", "''") & "',N'" &
                        dvChildPart.Item(i).Item("IMA021").ToString.Replace("'", "''") & "',N'" & strPartType &
                        "',N'" & dvChildPart.Item(i).Item("IMA02").ToString.Replace("'", "''") & "',NULL, '1','" &
                        dvChildPart.Item(i).Item("MODIFYDATE").ToString & "') END ")
                End If
            Next
            If (Not String.IsNullOrEmpty(strChildSava.ToString)) Then
                DbOperateUtils.ExecSQL(strChildSava.ToString())
            End If
            strChildSava = Nothing
            SetStepMessage("BOM基本信息更新完成!", True)
        Catch ex As Exception
            SetStepMessage("BOM基本信息更新异常!", False)
            strChildSava = Nothing
        End Try
    End Sub

    Private Sub SavaChildPart(ByVal dvChildPart As DataView)
        Dim strChildSava As New StringBuilder
        Dim o_strCusID As String = String.Empty
        Dim strCustPart As String = String.Empty
        Try
            o_strCusID = Me.CboCust.SelectedValue
            If o_strCusID Is Nothing Then
                o_strCusID = String.Empty
            End If
            'If String.IsNullOrEmpty(o_strCusID) Then
            '    SetStepMessage("保存料件基本信息异常,客户不能为空!", False)
            '    Exit Sub
            'End If
            '连接TT时去取客户料号
            If VbCommClass.VbCommClass.IsConSap = "N" Then
                strCustPart = SapCommon.GetCustPartFromTT(Me.TxtPartid.Text.Trim)
            End If

            '后续关闭 AmountQty组件用量更新(配置数), (Add column Extensible,Version, cq 20150916)
            '更改使用BOM检查
            Dim PARENT_PART, PRODUCT_ID, IMA01, IMA02, BMB06, IMA021, EXTENSIABLE, Version, BMD03, BMD04 As String
            Version = String.Empty
            For i As Int16 = 0 To dvChildPart.Count - 1
                If (Not String.IsNullOrEmpty(dvChildPart.Item(i).Item("IMA01").ToString)) Then
                    PARENT_PART = dvChildPart.Item(i).Item("PARENT_PART").ToString.Replace("'", "''")
                    PRODUCT_ID = dvChildPart.Item(i).Item("PRODUCT_ID").ToString.Replace("'", "''")
                    IMA01 = dvChildPart.Item(i).Item("IMA01").ToString.Replace("'", "''")
                    IMA02 = dvChildPart.Item(i).Item("IMA02").ToString.Replace("'", "''")
                    BMB06 = dvChildPart.Item(i).Item("BMB06").ToString.Replace("'", "''")
                    IMA021 = dvChildPart.Item(i).Item("IMA021").ToString.Replace("'", "''")
                    EXTENSIABLE = dvChildPart.Item(i).Item("EXTENSIABLE").ToString.Replace("'", "''")
                    Version = dvChildPart.Item(i).Item("VERSION").ToString.Replace("'", "''")
                    BMD03 = dvChildPart.Item(i).Item("BMD03").ToString().Replace("'", "''")
                    BMD04 = dvChildPart.Item(i).Item("BMD04").ToString().Replace("'", "''")

                    '与工单上数据为准
                    'If VbCommClass.VbCommClass.IsConSap = "Y" Then
                    '    If PARENT_PART = PRODUCT_ID And PARENT_PART = IMA01 Then
                    '        '设置蓝图版本
                    '        txtBlueprintVersion.Text = Version
                    '    End If
                    'End If

                    strChildSava.Append(vbNewLine &
                    " IF('" & PARENT_PART & "'='" & PRODUCT_ID & "' AND '" & PARENT_PART & "'='" & IMA01 &
                    "' ) BEGIN " &
                    " IF NOT EXISTS(SELECT TAvcPart FROM M_partcontrast_t WHERE TAvcPart=N'" & IMA01 & "' AND PAvcPart='" & PARENT_PART &
                    "' AND Factory = '" & VbCommClass.VbCommClass.Factory & "') BEGIN " &
                    "   INSERT INTO M_partcontrast_t(TAvcPart, PartName, PAvcPart, CusID, CustPart, MethodID, TypeDest, UseY, LmtY, WarnDate, Userid, Intime, PartCode, " &
                    "   Supplierid, IsUpload, Isasseble, IsLotScan, IsAlter, MaterialAlter, IsPrintFile, IsTransOracle, IsChkTransData, AmountQty, DESCRIPTION, " &
                    "   SubstituteFlag, IngredientsPart, SubstituteNumber,Extensible,Version,SeriesID,Factory) " &
                    "   SELECT N'" & PARENT_PART & "',NULL,N'" & PARENT_PART & "','" & o_strCusID & "'," & " N'" & strCustPart & "',NULL, N'" & IMA02 & "'," &
                                    " 'Y',365,7,'SYSTEM',GETDATE(),NULL,NULL,'N','N','N','N','N',NULL,NULL,'N','" &
                                    1 & "', N'" & IMA021 & "', 0, NULL, 0,'" & EXTENSIABLE & "', " & " '" & Version & "', '" & CboSeries.SelectedValue &
                    "' ,'" & VbCommClass.VbCommClass.Factory & "' END ELSE BEGIN UPDATE M_partcontrast_t SET CustPart = '" & strCustPart & "' WHERE TAvcPart=N'" & IMA01 & "' AND PAvcPart='" & PARENT_PART & "' AND Factory ='" & VbCommClass.VbCommClass.Factory & "' END" &
                    " END ELSE BEGIN IF ('" & BMD03 & "'='0' OR '" & BMD03 & "'='1') " &
                    " BEGIN " &
                    " IF NOT EXISTS(SELECT TAvcPart FROM M_Partcontrast_t WHERE TAvcPart=N'" & IMA01 & "' AND PAvcPart='" & PARENT_PART &
                    "'  AND Factory = '" & VbCommClass.VbCommClass.Factory & "') BEGIN " &
                    " INSERT INTO M_partcontrast_t(TAvcPart, PartName, PAvcPart, CusID, CustPart, MethodID, TypeDest, UseY, LmtY, WarnDate, Userid, Intime, PartCode, " &
                    " Supplierid, IsUpload, Isasseble, IsLotScan, IsAlter, MaterialAlter, IsPrintFile, IsTransOracle, " & _
                    " IsChkTransData, AmountQty, DESCRIPTION, SubstituteFlag, IngredientsPart, SubstituteNumber,Extensible,Version,SeriesID,Factory) " &
                    " SELECT N'" & IMA01 & "',NULL,N'" & PARENT_PART & "'," &
                    " '" & o_strCusID & "',N'" & IMA01 & "',NULL, N'" & IMA02 + (i + 1).ToString & "'," &
                    " 'Y',365,7,'SYSTEM',GETDATE(),NULL,NULL,'N','N','N','N','N',NULL,NULL,'N','" & BMB06 &
                    "', N'" & IMA021 & "', 0, NULL,0,'" & EXTENSIABLE & "', " & " '" & Version & "', '" & CboSeries.SelectedValue &
                    "'  ,'" & VbCommClass.VbCommClass.Factory & "' END " &
                    " IF NOT EXISTS(SELECT TAvcPart FROM M_partcontrast_t WHERE TAvcPart=N'" & IMA01 & "' AND PAvcPart='" & IMA01 &
                    "'  AND Factory = '" & VbCommClass.VbCommClass.Factory & "') " &
                    " BEGIN " &
                    " INSERT INTO M_partcontrast_t(TAvcPart, PartName, PAvcPart, CusID, CustPart, MethodID, TypeDest, UseY, LmtY, WarnDate, Userid, Intime, PartCode, " &
                    " Supplierid, IsUpload, Isasseble, IsLotScan, IsAlter, MaterialAlter, IsPrintFile, IsTransOracle, IsChkTransData, AmountQty, DESCRIPTION," &
                    " SubstituteFlag, IngredientsPart, SubstituteNumber,Extensible,Version,SeriesID,Factory) " &
                    " SELECT N'" & IMA01 & "',NULL,N'" & IMA01 & "','" & o_strCusID & "',N'" & IMA01 & "',NULL, N'" & IMA02 + (i + 1).ToString & "'," &
                    " 'Y',365,7,'SYSTEM',GETDATE(),NULL,NULL,'N','N','N','N','N',NULL,NULL,'N','" & 1 &
                    "', N'" & IMA021 & "', 0, NULL, 0," & " '" & EXTENSIABLE & "','" & Version & "', '" & CboSeries.SelectedValue & "' " &
                    "  ,'" & VbCommClass.VbCommClass.Factory & "' END END " & _
                    " IF (ISNULL('" & BMD04 & "','')<>'')" &
                    " BEGIN " & _
                    " IF NOT EXISTS(SELECT TAvcPart FROM M_partcontrast_t WHERE TAvcPart=N'" & BMD04 & "' AND PAvcPart='" & PARENT_PART &
                    "'  AND Factory = '" & VbCommClass.VbCommClass.Factory & "') BEGIN " &
                    " INSERT INTO M_partcontrast_t(TAvcPart, PartName, PAvcPart, CusID, CustPart, MethodID, TypeDest, UseY, LmtY, WarnDate, Userid, Intime, PartCode, " &
                    " Supplierid, IsUpload, Isasseble, IsLotScan, IsAlter, MaterialAlter, IsPrintFile, IsTransOracle, IsChkTransData, AmountQty, DESCRIPTION," &
                    " SubstituteFlag, IngredientsPart, SubstituteNumber,Extensible,Version,SeriesID,Factory) " &
                    " SELECT N'" & BMD04 & "',NULL,N'" & PARENT_PART & "'," & " '" & o_strCusID & "',N'" & IMA01 & "',NULL, N'" &
                    IMA02 & "'," & " 'Y',365,7,'SYSTEM',GETDATE(),NULL,NULL,'N','N','N','N','N',NULL,NULL,'N','" &
                    BMB06 & "', N'" & IMA021 & "'," & " 1, '" & IMA01 & "', '" & BMD03 & "'," & " '" & EXTENSIABLE & "','" &
                    Version & "', '" & CboSeries.SelectedValue & "'  ,'" & VbCommClass.VbCommClass.Factory & "'  END " &
                    " END END")
                End If
            Next

            If VbCommClass.VbCommClass.IsConSap = "N" Then
                '设置蓝图版本
                txtBlueprintVersion.Text = Version
            End If

            If (Not String.IsNullOrEmpty(strChildSava.ToString)) Then
                DbOperateUtils.ExecSQL(strChildSava.ToString())
            End If
            strChildSava = Nothing
            SetStepMessage("料件基本信息更新完成!", True)
        Catch ex As Exception
            strChildSava = Nothing
            SetStepMessage("料件基本信息更新异常!", False)
        End Try
    End Sub

    Private Function GetVersion(ByVal parPN As String) As String
        Dim lsSQL As String = ""
        GetVersion = ""
        Try
            lsSQL = " SELECT ISNULL(VERSION,'') as VERSION  FROM m_PartContrast_t WHERE TAvcPart  = '{0}' AND Factory = '{1}' " & SapCommon.GetPartFatory
            lsSQL = String.Format(lsSQL, parPN, VbCommClass.VbCommClass.Factory)
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    GetVersion = o_dt.Rows(0).Item("VERSION").ToString
                Else
                    GetVersion = ""
                End If
            End Using
            Return GetVersion
        Catch ex As Exception
        End Try
    End Function

    Private Sub LoadControlData()

        FillCombox(CboMoType)
        FillCombox(CboDept)
        FillCombox(CboLine)
        FillCombox(CboCust)
        FillCombox(CboSeries) 'Add by CQ 20151123
        FillCombox(CboItemCode)

        Me.CboDept.SelectedIndex = -1
        Me.CboLine.SelectedIndex = -1
        Me.CboMoType.SelectedIndex = -1
        Me.CboCust.SelectedIndex = -1
        Me.CboSeries.SelectedIndex = -1
        Me.CboItemCode.SelectedIndex = -1

        Me.dtpEndDate.Value = Now.AddDays(-1)
        Me.dtpStartDate.Value = Now.AddDays(1)

        Dim DateT As New DateTime
        Dim RecTable As DataTable
        RecTable = DbOperateUtils.GetDataTable("select getdate() as nowtime")
        If RecTable.Rows.Count > 0 Then
            DateT = CDate(RecTable.Rows(0)!nowtime.ToString)
        End If

        Dim strSQL As String = ""
        If (IsConSap = "Y") Then
            strSQL = "SELECT CheckAqci120 FROM m_Factory_t WHERE Factoryid = '" & VbCommClass.VbCommClass.Factory & "'"
        Else
            strSQL = "SELECT CheckAqci120 FROM m_Dcompany_t WHERE Factoryid = '" & VbCommClass.VbCommClass.Factory & "'"
        End If
        Dim dtCheckAqci120 As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (Not dtCheckAqci120 Is Nothing And dtCheckAqci120.Rows.Count > 0) Then
            m_CheckAqci120 = dtCheckAqci120.Rows(0).Item("CheckAqci120").ToString
        End If
        Me.LblPrintDate.Text = DateT.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
        PrtArray.NowDate = CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString
        PrtArray.NowMonth = CDate(Me.LblPrintDate.Text.ToString).ToString("MM").ToString
    End Sub

    '狀態顯示
    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始
                Me.ToolNew.Enabled = IIf(ToolNew.Tag.ToString = "YES", True, False)
                Me.ToolAgain.Enabled = IIf(ToolAgain.Tag.ToString = "YES", True, False)
                'Me.ToolEdit.Enabled = IIf(ToolEdit.Tag.ToString = "YES", True, False)
                Me.ToolDelete.Enabled = IIf(Me.ToolDelete.Tag.ToString = "YES", True, False)
                Me.ToolCommitInfo.Enabled = IIf(Me.ToolCommitInfo.Tag.ToString = "YES", True, False)

                Me.ToolCommit.Enabled = False
                Me.ToolQuery.Enabled = True
                Me.ToolBack.Enabled = False
                Me.ToolPrt.Enabled = True
                Me.Timer.Enabled = True
                Me.ToolMove.Enabled = True
                Me.mtxtMOid.Enabled = False

                Me.txtMOId.Text = ""
                Me.TxtPartid.Text = ""
                Me.txtQty.Text = ""
                Me.TxtFileVerNo.Text = ""
                Me.TxtDriFlag.Text = ""
                Me.txtPrintCount.Text = ""
                Me.TxtBuildAttribute.Text = ""
                Me.TxtTaskDesc.Text = ""
                Me.CboShift.SelectedIndex = -1
                Me.CboDept.SelectedIndex = -1
                Me.CboLine.SelectedIndex = -1
                Me.CboMoType.SelectedIndex = -1
                Me.CboCust.SelectedIndex = -1
                Me.CboSeries.SelectedIndex = -1
                Me.CboItemCode.SelectedIndex = -1
                Me.txtMOId.Enabled = True
                Me.TxtPartid.Enabled = True
                Me.txtQty.Enabled = False
                Me.TxtFileVerNo.Enabled = False
                Me.TxtDriFlag.Enabled = False
                Me.txtPrintCount.Enabled = False
                Me.TxtBuildAttribute.Enabled = False
                Me.TxtTaskDesc.Enabled = False
                Me.CboShift.Enabled = False
                Me.CboDept.Enabled = False
                Me.CboLine.Enabled = False
                Me.CboMoType.Enabled = False
                Me.CboCust.Enabled = False
                Me.CboSeries.Enabled = False
                Me.CboItemCode.Enabled = False
                'DgVer.Enabled = False
            Case 1    '新增
                Me.ToolNew.Enabled = False
                Me.ToolAgain.Enabled = False
                'Me.ToolEdit.Enabled = False
                'Me.ToolCancel.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolBack.Enabled = True
                Me.ToolPrt.Enabled = False
                Me.Timer.Enabled = False
                Me.ToolMove.Enabled = False
                Me.ToolDelete.Enabled = False
                Me.ToolCommitInfo.Enabled = False


                Me.CboShift.SelectedIndex = -1
                Me.CboDept.SelectedIndex = -1
                Me.CboLine.SelectedIndex = -1
                Me.CboMoType.SelectedIndex = -1
                Me.CboCust.SelectedIndex = -1
                Me.CboSeries.SelectedIndex = -1
                Me.CboItemCode.SelectedIndex = -1
                Me.txtMOId.Enabled = True
                Me.TxtPartid.Enabled = False
                Me.txtQty.Enabled = True
                Me.TxtFileVerNo.Enabled = True
                Me.TxtDriFlag.Enabled = True
                Me.txtPrintCount.Enabled = True
                Me.TxtBuildAttribute.Enabled = True
                Me.TxtTaskDesc.Enabled = True
                Me.CboShift.Enabled = True
                Me.CboDept.Enabled = True
                Me.CboLine.Enabled = True
                Me.CboMoType.Enabled = True
                Me.CboCust.Enabled = True
                Me.CboItemCode.Enabled = True
                Me.mtxtMOid.Enabled = True

                If VbCommClass.VbCommClass.Factory = "LXXT" Then
                    Me.CboSeries.Enabled = False
                Else
                    Me.CboSeries.Enabled = True
                End If

                'DgVer.Enabled = True
                'DgVer.Columns(0).ReadOnly = True
                'DgVer.Columns(1).ReadOnly = True
            Case 2  '修改
                Me.ToolNew.Enabled = False
                'Me.ToolEdit.Enabled = False
                'Me.ToolCancel.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolBack.Enabled = True
                Me.ToolPrt.Enabled = False
                Me.Timer.Enabled = False
                Me.ToolMove.Enabled = False
                Me.ToolDelete.Enabled = False
                Me.ToolCommitInfo.Enabled = False

                Me.txtMOId.Enabled = True
                Me.TxtPartid.Enabled = False
                Me.txtQty.Enabled = True
                Me.TxtFileVerNo.Enabled = True
                Me.TxtDriFlag.Enabled = True
                Me.txtPrintCount.Enabled = True
                Me.TxtBuildAttribute.Enabled = True
                Me.TxtTaskDesc.Enabled = True
                Me.CboShift.Enabled = True
                Me.CboDept.Enabled = True
                Me.CboLine.Enabled = True
                Me.CboMoType.Enabled = True
                Me.CboCust.Enabled = True
                Me.CboSeries.Enabled = True
                Me.CboItemCode.Enabled = True
                'DgVer.Enabled = True
                'DgVer.Columns(0).ReadOnly = True
                'DgVer.Columns(1).ReadOnly = True
        End Select
    End Sub

    Private Sub ClearObject()
        Me.txtMOId.Text = ""
        strMOID = ""
        Me.TxtPartid.Text = ""
        'Me.CboLine.DataSource = Nothing
        'Me.CboLine.Items.Clear()
        Me.txtBlueprintVersion.Text = ""
        Me.txtPackageVersion.Text = ""
        Me.txtPO.Text = "" 'cq 20160718
        Me.txtQty.Text = ""
        Me.txtQty.Enabled = False

        Me.dgvLotList.Rows.Clear()
        Me.dgvPrintList.Rows.Clear()
        Me.dgvRuleList.Rows.Clear()
    End Sub

    Private Sub ClearQueryObject()
        Me.txtMOId.Text = ""
        Me.TxtPartid.Text = ""
        Me.txtPrintCount.Text = ""
    End Sub

    Private Sub ClearQuery()

        Me.txtMOId.Text = ""
        Me.txtQty.Text = ""
        Me.TxtPartid.Text = ""
        Me.DtMoNeedTime.Text = ""
        Me.CboDept.SelectedIndex = -1
        Me.CboLine.SelectedIndex = -1
        Me.CboMoType.SelectedIndex = -1
        Me.CboCust.SelectedIndex = -1
        Me.CboSeries.SelectedIndex = -1
        Me.CboItemCode.SelectedIndex = -1
        Me.txtMOId.Focus()
        Me.dgvLotList.Rows.Clear()
        Me.dgvPrintList.Rows.Clear()
        Me.dgvRuleList.Rows.Clear()

    End Sub

    '取得打印工单
    Private Sub GetLot()

        Sqlstr.Remove(0, Sqlstr.Length)
        If VbCommClass.VbCommClass.Factory = "LX53" Then
            Dim sql As String = GetJxSql()
            If Not String.IsNullOrEmpty(sql) Then
                LoadData(sql, Me.dgvLotList)
            End If
        Else
            'and m_dept_t.Factoryid='" & VbCommClass.VbCommClass.Factory & "'
            Sqlstr.Append(" SELECT DISTINCT m_Mainmo_t.Moid,PartID,Moqty,ISNULL(Ppidprtqty,0) AS Ppidprtqty, ISNULL(PpidprtCount,0) AS PpidprtCount,ISNULL(Pkgprtqty,0) AS Pkgprtqty, ")
            Sqlstr.Append(" m_Dept_t.DQC, m_Mainmo_t.Lineid,m_Mainmo_t.CHECKTEXT, CONVERT(VARCHAR(10),cast(m_Mainmo_t.Plandate as datetime),120) AS Plandate, m_Customer_t.CusName, Createuser=m_Mainmo_t.Createuser+'/'+usr.UserName, ")
            Sqlstr.Append(" m_Mainmo_t.Createtime, m_Mainmo_t.Remark, ")
            Sqlstr.Append(" m_Mainmo_t.DemandInfo, CONVERT(VARCHAR(10),m_Mainmo_t.demandTime,120) AS demandTime, BlueprintVersion, PackageVersion,PO ")
            Sqlstr.Append(" FROM m_Mainmo_t(NOLOCK) ")
            Sqlstr.Append(" LEFT JOIN m_Customer_t(NOLOCK) ON m_Customer_t.CusID=m_Mainmo_t.Cusid ")
            Sqlstr.Append(" LEFT JOIN m_Dept_t(NOLOCK) ON m_Dept_t.deptid=m_Mainmo_t.Deptid AND m_Dept_t.Factoryid=m_Mainmo_t.Factory ")
            Sqlstr.Append(" LEFT JOIN m_users_t usr on m_Mainmo_t.Createuser=usr.UserID ")
            Sqlstr.Append(" WHERE m_Mainmo_t.Factory=N'" & VbCommClass.VbCommClass.Factory & "' and m_Mainmo_t.profitcenter=N'" & VbCommClass.VbCommClass.profitcenter & "' ")
            Sqlstr.Append(" AND m_Mainmo_t.Moid=m_Mainmo_t.ParentMo and m_Mainmo_t.Createtime between cast('" & Me.dtpEndDate.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime) and cast('" & Me.dtpStartDate.Value.ToString("yyyy/MM/dd") + " 23:59:59" & "' as datetime)")

            If Not String.IsNullOrEmpty(Me.txtMOId.Text.Trim) Then
                Sqlstr.Append(" and m_Mainmo_t.moid like '%" & Me.txtMOId.Text.ToString.Trim & "%'")
            End If

            If Not String.IsNullOrEmpty(Me.TxtPartid.Text.Trim) Then
                Sqlstr.Append(" and m_Mainmo_t.partid like '%" & Me.TxtPartid.Text.ToString.Trim & "%'")
            End If

            'add exclude mo, which mo not line leader request label,  cq 20160901 
            ' Sqlstr.Append(" and m_Mainmo_t.DemandInfo  is not null")
            Sqlstr.Append(" ORDER BY m_Mainmo_t.Createtime DESC")
            LoadData(Sqlstr.ToString, Me.dgvLotList)
        End If
        'LoadTypeInGrid(TxtPartid.Text)
    End Sub

    '取得工单打印清单
    Private Sub GetLotPrintList(ByVal strMOid As String, ByVal strPartId As String, ByVal strQty As String, ByVal QueryFlag As Boolean)

        Sqlstr.Remove(0, Sqlstr.Length)

        'Dim strSQL As String = " EXEC GetLotPrintList '{0}','{1}','{2}','{3}','{4}','{5}','{6}'"
        'strSQL = String.Format(strSQL, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, strMOid, strPartId, strQty, VbCommClass.VbCommClass.UseId, QueryFlag)
        'Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        'If dt.Rows.Count = 0 Then
        '    Exit Sub
        'End If
        'LoadData(Sqlstr.ToString, Me.dgvPrintList)
        If (QueryFlag) Then
            Sqlstr.Append(" SELECT DISTINCT m_SnAssign_t.Ptaskid,m_Mainmo_t.Moid, m_PartContrast_t.TAvcPart, m_PartContrast_t.PAvcPart, ")
            Sqlstr.Append(" m_Sortset_t.SortID + '-' + m_Sortset_t.SortName as LabelType, m_SnAssign_t.Packitem,ChildDisorderType.SortID + '-' + ChildDisorderType.SortName as DisorderType, ")
            Sqlstr.Append(" m_Mainmo_t.Moqty AS Qty,m_SnAssign_t.PrtQty*ISNULL(m_SnAssign_t.ConfigurationQty,1) PrintQty, ISNULL(m_SnAssign_t.FinishPrintQty,0) AS FinishPrintQty,ISNULL(m_SnAssign_t.ConfigurationQty,1) AS ConfigurationQty, m_PartPack_t.PrinterName, ")
            Sqlstr.Append(" case m_partpack_t.Packid when 'S' then '' else case m_partpack_t.Multiy when 'Y' then m_partpack_t.MultiQty when 'N' then m_partpack_t.Qty end end as PackingQty, ")
            Sqlstr.Append(" m_SnPFormat_t.KLabelid, m_PartPack_t.Description,'' PrintStatus, ")
            Sqlstr.Append(" djmdc,shift,linejm,convert(varchar(10),m_SnAssign_t.Demandtime,120) as Demandtime,(FileVerNo + iif(isnull(m_SnAssign_t.Remark,'')='','','#'+ m_SnAssign_t.Remark ))FileVerNo,m_PartPack_t.Remark,DriFlag,BuildAttribute, case m_SnAssign_t.Estateid when '1' then '1-待打印' when '2' then '2-打印中' when '3' then '3-被驳回' when '4' then '4-被作废' when '5' then '5-待領取' when '6' then '6-已完成' end as Estateid, ISNULL(m_PartPack_t.PackingLevel,'0') AS PackingLevel, m_Mainmo_t.PartID as applyPart, ISNULL(m_PartPack_t.VersionType, '0') + '-' + PartVersionType.PARAMETER_NAME AS VersionTypeText,m_SnAssign_t.LABELPN, m_SnAssign_t.PrintNumber,m_PartPack_t.GroupPrintFlag,Userid=m_SnAssign_t.Userid+'/'+usr.UserName,m_SnAssign_t.Intime, m_SnAssign_t.ApplyAddQty, m_SnAssign_t.FinishedAddQty ")
            Sqlstr.Append(" FROM m_Mainmo_t(NOLOCK) INNER JOIN m_SnAssign_t(NOLOCK) ON m_Mainmo_t.Moid= m_SnAssign_t.Moid ")
            Sqlstr.Append(" INNER JOIN m_PartContrast_t(NOLOCK) ON m_PartContrast_t.TAvcPart=m_Mainmo_t.PartID AND m_PartContrast_t.TAvcPart=m_PartContrast_t.PAvcPart ")
            Sqlstr.Append(" INNER JOIN m_PartPack_t(NOLOCK) ON m_PartContrast_t.TAvcPart = m_PartPack_t.Partid AND ")
            Sqlstr.Append("        m_PartPack_t.Partid = m_PartContrast_t.TAvcPart AND m_PartPack_t.Usey = 'Y' AND  m_PartPack_t.Packid=m_SnAssign_t.Packid AND m_PartPack_t.Packitem=m_SnAssign_t.Packitem")
            Sqlstr.Append(" LEFT JOIN m_SnPFormat_t(NOLOCK)  ON m_PartPack_t.PFormatID = m_SnPFormat_t.PFormatID ")
            Sqlstr.Append(" LEFT JOIN m_Sortset_t(NOLOCK)  ON m_PartPack_t.Packid = m_Sortset_t.SortID and m_Sortset_t.SortType='labeltype' and m_Sortset_t.usey='Y' ")
            Sqlstr.Append(" LEFT JOIN m_Dept_t(NOLOCK) on m_Mainmo_t.Deptid=m_Dept_t.Deptid ")
            Sqlstr.Append(" LEFT JOIN Deptline_t(NOLOCK) on m_Dept_t.deptid=Deptline_t.deptid and m_SnAssign_t.lineid=Deptline_t.lineid ")
            Sqlstr.Append(" LEFT JOIN m_Sortset_t(NOLOCK) AS ChildDisorderType ON m_PartPack_t.DisorderTypeId = ChildDisorderType.SortID and ChildDisorderType.SortType='labeltype' and ChildDisorderType.usey='Y' ")
            Sqlstr.Append(" INNER JOIN m_SettingParameter_t(NOLOCK) PartVersionType ON PartVersionType.PARAMETER_VALUE = m_PartPack_t.VersionType AND PartVersionType.PARAMETER_CODE = 'PartVersionType' ")
            Sqlstr.Append(" LEFT JOIN m_users_t usr on m_SnAssign_t.userid=usr.UserID ")
            Sqlstr.Append(" WHERE m_Mainmo_t.ParentMo='" & strMOid & "' AND m_Mainmo_t.Factory='" & VbCommClass.VbCommClass.Factory & "' and m_Mainmo_t.profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'  ")
            If VbCommClass.VbCommClass.Factory = "LX53" Then
                Sqlstr.Append(" AND m_SnAssign_t.ESTATEID NOT IN(3,4) ORDER BY m_SnAssign_t.INTIME DESC")
            Else
                Sqlstr.Append(" ORDER BY m_PartContrast_t.TAvcPart ASC")
            End If
        Else
            Sqlstr.Append(" SELECT DISTINCT '' AS Ptaskid,'" + strMOid + "' AS 'MOID', m_PartContrast_t.TAvcPart, m_PartContrast_t.PAvcPart, ")
            Sqlstr.Append("     m_Sortset_t.SortID + '-' + m_Sortset_t.SortName as LabelType, m_PartPack_t.Packitem, ChildDisorderType.SortID + '-' + ChildDisorderType.SortName as DisorderType, ")
            Sqlstr.Append("     " + strQty + " AS Qty,CONVERT(float,'" + strQty + "')* CASE m_partpack_t.Packid WHEN 'A' THEN m_PartPack_t.ConfigurationQty ELSE isnull(m_PartContrast_t.AmountQty,1) END AS PrintQty, CASE m_partpack_t.Packid WHEN 'A' THEN m_PartPack_t.ConfigurationQty ELSE isnull(m_PartContrast_t.AmountQty,1) END AS ConfigurationQty, 0 AS FinishPrintQty, m_PartPack_t.PrinterName, ")
            Sqlstr.Append("     case m_partpack_t.Packid when 'S' then '' else case m_partpack_t.Multiy when 'Y' then m_partpack_t.MultiQty when 'N' then m_partpack_t.Qty end end as PackingQty, ")
            Sqlstr.Append("     m_SnPFormat_t.KLabelid, m_PartPack_t.Description,'' PrintStatus, ")
            Sqlstr.Append(" '' djmdc, '' shift, ''linejm, '' as Demandtime, '' FileVerNo, m_PartPack_t.Remark, '' AS VersionTypeText, '' DriFlag, ''BuildAttribute, '0-待保存' as Estateid, ISNULL(m_PartPack_t.PackingLevel,'0') AS PackingLevel, '" + strPartId + "' as applyPart,'' as LABELPN, '0' AS PrintNumber,m_PartPack_t.GroupPrintFlag,Userid='" & UseId & "',Intime=getdate(), '' as ApplyAddQty, '' as FinishedAddQty ")
            Sqlstr.Append(" FROM (")
            Sqlstr.Append(" SELECT TAvcPart, PAvcPart, (CASE when AmountQty = 0 THEN 1 ELSE isnull(AmountQty,1) end)AmountQty  FROM m_PartContrast_t WHERE PAvcPart = '" + strPartId + "'  AND Pavcpart <> TAvcPart AND factory = '" & VbCommClass.VbCommClass.Factory & "' ")
            Sqlstr.Append(" UNION ALL")
            Sqlstr.Append(" SELECT TAvcPart, PAvcPart, 1 FROM m_PartContrast_t WHERE PAvcPart = '" + strPartId + "'  AND Pavcpart = TAvcPart  AND factory = '" & VbCommClass.VbCommClass.Factory & "' ")
            Sqlstr.Append(" ) m_PartContrast_t ")
            '料件必须设置参数，不然确定打印标签类型
            Sqlstr.Append(" INNER JOIN m_PartPack_t(NOLOCK) ON m_PartContrast_t.TAvcPart = m_PartPack_t.Partid AND ")
            Sqlstr.Append("        m_PartPack_t.Partid = m_PartContrast_t.TAvcPart AND m_PartPack_t.Usey = 'Y' ")
            Sqlstr.Append(" LEFT JOIN m_SnPFormat_t(NOLOCK)  ON m_PartPack_t.PFormatID = m_SnPFormat_t.PFormatID ")
            Sqlstr.Append(" LEFT JOIN m_Sortset_t(NOLOCK)  ON m_PartPack_t.Packid = m_Sortset_t.SortID and m_Sortset_t.SortType='labeltype' and m_Sortset_t.usey='Y' ")
            Sqlstr.Append(" LEFT JOIN m_Sortset_t(NOLOCK) AS ChildDisorderType ON m_PartPack_t.DisorderTypeId = ChildDisorderType.SortID and ChildDisorderType.SortType='labeltype' and ChildDisorderType.usey='Y' ")
            'WHERE m_PartContrast_t.PAvcPart='" + strPartId + "' 
            Sqlstr.Append(" ORDER BY m_PartContrast_t.TAvcPart ASC")

        End If
        LoadData(Sqlstr.ToString, Me.dgvPrintList)
    End Sub

    '取得工单打印项参数配置
    Private Sub GetPrintItemParameter(ByVal strMOid As String, ByVal strPartId As String, ByVal strPackid As String, ByVal strPactItem As String)
        Sqlstr.Remove(0, Sqlstr.Length)
        Sqlstr.Append(" select distinct a.F_codeID,c.F_codename, IIF(a.f_codeid ='PO', ISNULL(MO.PO,a.DValues), a.DValues )DValues")
        Sqlstr.Append(" from m_SnPartSet_t as a  ")
        Sqlstr.Append(" join m_PartPack_t as b on a.partid=b.partid and a.Packid=b.Packid and a.Packitem=b.Packitem  ")
        Sqlstr.Append(" join m_SnRuleD_t as c on a.F_codeID=c.F_codeID and b.CodeRuleID=c.CodeRuleID  ")
        Sqlstr.Append(" join m_Mainmo_t mo on a.partid = mo.PartID and mo.moid ='" & strMOid & "'")
        Sqlstr.Append(" where a.Partid='" & strPartId & "' and a.Packid='" & strPackid & "' and a.Packitem='" & strPactItem & "' order by a.F_codeID")
        LoadData(Sqlstr.ToString, Me.dgvRuleList)
    End Sub

    '填充数据
    Private Sub LoadData(ByVal Sqlstr As String, ByVal dgvName As DataGridView)
        Dim DReader As DataTable
        Try
            dgvName.Rows.Clear()
            DReader = DbOperateUtils.GetDataTable(Sqlstr)

            Dim cmbTmp As DataGridViewComboBoxColumn
            Dim FCLNumber As Int32
            Dim TrunkNumber As Int32
            Dim PrintName As String

            cmbTmp = dgvPrintList.Columns("PrinterName")
            SqlClassM.GetPrintersList(cmbTmp)

            For index As Integer = 0 To DReader.Rows.Count - 1
                If dgvName Is Me.dgvLotList Then
                    dgvName.Rows.Add(DReader.Rows(index)("Moid").ToString, DReader.Rows(index)("Partid").ToString, DReader.Rows(index)("Moqty").ToString, DReader.Rows(index)("Ppidprtqty").ToString _
                    , DReader.Rows(index)("PpidprtCount").ToString, DReader.Rows(index)("Pkgprtqty").ToString, DReader.Rows(index)("Lineid").ToString, _
                    DReader.Rows(index)("BlueprintVersion").ToString, DReader.Rows(index)("PackageVersion").ToString, DReader.Rows(index)("PO").ToString, _
                    DReader.Rows(index)("CHECKTEXT").ToString, DReader.Rows(index)("DemandInfo").ToString, DReader.Rows(index)("Plandate").ToString _
                    , DReader.Rows(index)("DQC").ToString, DReader.Rows(index)("CusName").ToString, DReader.Rows(index)("demandTime").ToString, DReader.Rows(index)("Createuser").ToString, DReader.Rows(index)("Createtime").ToString, DReader.Rows(index)("Remark").ToString)
                ElseIf dgvName Is Me.dgvRuleList Then
                    dgvName.Rows.Add(DReader.Rows(index)("F_codeID").ToString, DReader.Rows(index)("F_codename").ToString, DReader.Rows(index)("DValues").ToString)
                ElseIf dgvName Is Me.dgvPrintList Then

                    'If (Not String.IsNullOrEmpty(DReader.Item("PrinterName").ToString)) Then
                    '    cmbTmp.ValueMember = DReader.Item("PrinterName").ToString
                    'Else
                    '    cmbTmp.ValueMember = -1
                    'End If

                    If (SqlClassM.CheckPrintersList(DReader.Rows(index)("PrinterName").ToString)) Then
                        PrintName = DReader.Rows(index)("PrinterName").ToString
                    Else
                        PrintName = ""
                    End If

                    If (Microsoft.VisualBasic.Left(DReader.Rows(index)("LabelType").ToString, 1) = "C" Or Microsoft.VisualBasic.Left(DReader.Rows(index)("DisorderType").ToString, 1) = "C" Or Microsoft.VisualBasic.Left(DReader.Rows(index)("DisorderType").ToString, 1) = "P") Then
                        If ((CInt(DReader.Rows(index)("PrintQTY").ToString) - CInt(DReader.Rows(index)("FinishPrintQty").ToString)) Mod CInt(DReader.Rows(index)("PackingQty").ToString) = 0) Then
                            FCLNumber = (CInt(DReader.Rows(index)("PrintQTY").ToString) - CInt(DReader.Rows(index)("FinishPrintQty").ToString)) / CInt(DReader.Rows(index)("PackingQty").ToString)
                            TrunkNumber = 0
                        Else
                            FCLNumber = System.Math.Truncate((CInt(DReader.Rows(index)("PrintQTY").ToString) - CInt(DReader.Rows(index)("FinishPrintQty").ToString)) / CInt(DReader.Rows(index)("PackingQty").ToString))
                            TrunkNumber = 1
                        End If
                    Else
                        FCLNumber = 0
                        TrunkNumber = 0
                    End If

                    Dim defaultSelected As Boolean = True
                    If VbCommClass.VbCommClass.Factory = "LX53" Then
                        defaultSelected = False
                    End If
                    dgvName.Rows.Add(defaultSelected, DReader.Rows(index)("Ptaskid").ToString, DReader.Rows(index)("Moid").ToString, DReader.Rows(index)("LabelType").ToString, DReader.Rows(index)("PackItem").ToString, DReader.Rows(index)("TAvcPart").ToString, DReader.Rows(index)("PAvcPart").ToString, DReader.Rows(index)("FileVerNo").ToString, DReader.Rows(index)("VersionTypeText").ToString, DReader.Rows(index)("Remark").ToString, DReader.Rows(index)("Userid").ToString, DReader.Rows(index)("Intime").ToString, _
                    DReader.Rows(index)("Qty").ToString, DReader.Rows(index)("PrintQTY").ToString, DReader.Rows(index)("FinishPrintQty").ToString, DReader.Rows(index)("ApplyAddQty").ToString, DReader.Rows(index)("FinishedAddQty").ToString, DReader.Rows(index)("ConfigurationQty").ToString, DReader.Rows(index)("LABELPN").ToString, PrintName, DReader.Rows(index)("PackingQty").ToString, FCLNumber, TrunkNumber, DReader.Rows(index)("PrintNumber").ToString, DReader.Rows(index)("KLabelid").ToString, DReader.Rows(index)("Description").ToString, DReader.Rows(index)("PrintStatus").ToString, DReader.Rows(index)("DisorderType").ToString, _
                    DReader.Rows(index)("djmdc").ToString, DReader.Rows(index)("shift").ToString, DReader.Rows(index)("linejm").ToString, DReader.Rows(index)("Demandtime").ToString, DReader.Rows(index)("DriFlag").ToString, DReader.Rows(index)("BuildAttribute").ToString, DReader.Rows(index)("Estateid").ToString, DReader.Rows(index)("PackingLevel").ToString, DReader.Rows(index)("applyPart").ToString, DReader.Rows(index)("GroupPrintFlag").ToString)
                    If DReader.Rows(index)("FinishPrintQty").ToString <> "" And DReader.Rows(index)("PrintQTY").ToString <> "" Then
                        If Convert.ToDecimal(DReader.Rows(index)("PrintQTY").ToString) > Convert.ToDecimal(DReader.Rows(index)("FinishPrintQty").ToString) Then
                            'dgvName.Rows(index).DefaultCellStyle.ForeColor = Color.Green
                            dgvName.Rows(index).DefaultCellStyle.BackColor = Color.White
                        Else
                            dgvName.Rows(index).DefaultCellStyle.BackColor = Color.LightGray
                        End If
                    End If
                    If DReader.Rows(index)("ApplyAddQty").ToString <> "" And DReader.Rows(index)("FinishedAddQty").ToString <> "" Then
                        If Convert.ToDecimal(DReader.Rows(index)("ApplyAddQty").ToString) > Convert.ToDecimal(DReader.Rows(index)("FinishedAddQty").ToString) Then
                            dgvName.Rows(index).DefaultCellStyle.ForeColor = Color.Green
                        Else
                            dgvName.Rows(index).DefaultCellStyle.ForeColor = Color.Black
                        End If
                    End If

                End If
            Next
            Me.ToolLblCount.Text = Me.dgvPrintList.Rows.Count

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "LoadData", "sys")
            Throw ex '出错
        End Try
    End Sub

    Private Sub BindPrintList(ByVal strSQL As String, ByVal dgvName As DataGridView)
        Dim dtTemp As DataTable
        Try
            dtTemp = DbOperateUtils.GetDataTable(strSQL)

            dtTemp = Nothing
        Catch ex As Exception
            dtTemp = Nothing
        End Try
    End Sub

    Private Sub PrintBarCode(ByVal PrintData As DataGridViewRow, ByVal rowNum As Int16)
        Try
            BarValueStr.Remove(0, BarValueStr.Length)
            BarFile.Remove(0, BarFile.Length)
            '配置数
            strConfigurationQty = IIf(IsDBNull(PrintData.Cells("ConfigurationQty").Value), "1", PrintData.Cells("ConfigurationQty").Value)

            If (Not PrintData Is Nothing) Then
                If InitializePrintParameter(PrintData) = False Then
                    Exit Sub
                End If

                '打印状态
                If (Microsoft.VisualBasic.Left(PrintData.Cells("Estateid").Value.ToString, 1) = "1") Then
                    DbOperateUtils.ExecSQL("Update m_SnAssign_t set Estateid='2',Printuser='" & SysMessageClass.UseId.ToLower.Trim & "' where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
                End If
                Dim _Packid As String = Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1)
                Select Case (_Packid)
                    Case "A"
                        BuildABarCode(PrintData) '附属条码
                    Case "S", "K"
                        BuildSBarCode(PrintData) '产品条码/ 增加制程条码 K
                    Case "C"
                        '需增加尾箱处理
                        BuildCBarCode(PrintData) '外箱条码
                    Case "P"
                        BuildPBarCode(PrintData) '栈板条码
                    Case "N"
                        '需增加尾箱处理
                        'BuildCBarCode(PrintData)
                        BuildNBarCode(PrintData) '无流水号条码
                End Select

                If m_AddPrtCheck Then '执行补数标签打印后，跟前补数申请单清单，处理申请单已完成数量，数量不足，按照顺序扣数
                    PrintApplyAddData(PrintData.Cells("PtaskId").Value.ToString, _Packid, PrintData.Cells("Packitem").Value.ToString, UseId, Me.m_AddApplyList, strPrintNumber)
                End If
            Else
                SetMessage("获取行" + rowNum.ToString + "打印数据失败!")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PrintApplyAddData(ByVal Ptaskid As String, ByVal Packid As String, ByVal Packitem As String, ByVal userid As String, ByVal appidlist As String, ByVal PrintQty As String)
        Try
            Dim sql As String = "exec Exec_PrintApplyAddData N'" & Ptaskid & "',N'" & Packid & "','" & Packitem & "',N'" & userid & "',N'" & appidlist & "'," & PrintQty & " "
            If strTestPrt <> "Y" Then
                DbOperateUtils.ExecSQL(sql)
            End If
        Catch ex As Exception
            SetMessage("执行补数标签扣数异常，处理数据失败!")
        End Try

    End Sub
    '數組傳遞參數
    Private Sub SetArrayLbl(ByVal Array() As String)
        'Dim I As Int16
        'Dim IsCheckCode As String = "N"
        'Dim ArrayCheck As Integer = 0
        'Try
        '    For I = 0 To BarCodePartTable.Rows.Count - 1
        '        If BarCodePartTable.Rows(I).Item("DResource").ToString <> "" AndAlso Microsoft.VisualBasic.Left(BarCodePartTable.Rows(I).Item("DResource").ToString, 5) = "Array" Then
        '            BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(Replace(BarCodePartTable.Rows(I).Item("DResource").ToString, "Array", ""))).Trim


        '        End If
        '        If (BarCodePartTable.Rows(I).Item("F_codeID").ToString = "Y" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "M" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "D" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "W" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "DW" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "DY") AndAlso BarCodePartTable.Rows(I).Item("UnitID").ToString <> "" Then
        '            BarCodePartTable.Rows(I).Item("ShortName") = LoadM.ShowShortTime(CDate(Array(7)), BarCodePartTable.Rows(I).Item("F_codeID").ToString, BarCodePartTable.Rows(I).Item("UnitID").ToString)
        '        End If
        '    Next
        'Catch ex As Exception
        '    Throw ex
        'End Try

        Dim I As Int16
        Try
            For I = 0 To BarCodePartTable.Rows.Count - 1
                If BarCodePartTable.Rows(I).Item("DResource").ToString <> "" AndAlso Microsoft.VisualBasic.Left(BarCodePartTable.Rows(I).Item("DResource").ToString, 5) = "Array" Then
                    If (BarCodePartTable.Rows(I).Item("F_codeID").ToString() = "Q") Then
                        If ((BarCodePartTable.Rows(I).Item("IsBoxQty").ToString() = "Y")) Then
                            BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(BarCodePartTable.Rows(I).Item("DResource").ToString.Substring(5))).Trim
                        Else
                            BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(BarCodePartTable.Rows(I).Item("DResource").ToString.Substring(5))).Trim.PadLeft(CInt(BarCodePartTable.Rows(I).Item("F_codelen").ToString), "0")
                        End If
                    Else
                        BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(BarCodePartTable.Rows(I).Item("DResource").ToString.Substring(5))).Trim
                    End If

                End If
                If (BarCodePartTable.Rows(I).Item("F_codeID").ToString = "Y" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "M" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "D" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "W" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "DW" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "DY") AndAlso BarCodePartTable.Rows(I).Item("UnitID").ToString <> "" Then
                    BarCodePartTable.Rows(I).Item("ShortName") = LoadM.ShowShortTime(CDate(Array(7)), BarCodePartTable.Rows(I).Item("F_codeID").ToString, BarCodePartTable.Rows(I).Item("UnitID").ToString)
                End If

                '增加校验位类别XC判断 Add By KyLin Qiu 20170609--Begin
                If (BarCodePartTable.Rows(I).Item("F_codeID").ToString.Trim.ToUpper = "XC") AndAlso (BarCodePartTable.Rows(I).Item("UnitID").ToString.Trim.ToUpper = "XC2" Or BarCodePartTable.Rows(I).Item("UnitID").ToString.Trim.ToUpper = "XC3") Then
                    '目前写死一位已以C表示,后续如果有新需求可以拓展
                    BarCodePartTable.Rows(I).Item("ShortName") = "C"
                    'BarCodePartTable.Rows(I).Item("ShortName") = BarCodePartTable.Rows(I).Item("F_codelen").ToString.Trim
                End If
                '增加校验位类别XC判断 Add By KyLin Qiu 20170609--End

            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "SetArrayLbl", "sys")
            Throw ex
        End Try
    End Sub

    Private Sub SetMessage(ByVal Message As String)
        If Message.Length > 100 Then
            Me.lblMessage.Text = Message.Substring(0, 99)
        Else
            Me.lblMessage.Text = Message
        End If
    End Sub

    Private Sub SetStepMessage(ByVal StrMessage As String, ByVal MessageType As Boolean)

        Me.rtxtStepMessage.AppendText(StrMessage + Environment.NewLine)
        Dim p1 As Integer = Me.rtxtStepMessage.Text.IndexOf(StrMessage)
        Dim p2 As Integer = StrMessage.Length
        Me.rtxtStepMessage.Select(Me.rtxtStepMessage.Text.Length - p2 - 1, p2)
        If (MessageType) Then
            Me.rtxtStepMessage.SelectionColor = Color.Lime
        Else
            Me.rtxtStepMessage.SelectionColor = Color.Red
        End If

    End Sub

    Private Sub ProcessLoadMo(ByVal strMOid As String, ByVal dgvPrintList As DataGridView)
        If (Not dgvPrintList Is Nothing) Then
            Dim strPartId As String
            Dim strParentPartId As String
            Dim strApplyPartId As String
            Dim strItemNum As String
            Dim MaxItemNum As Int16 = 0
            Dim strChildMoid As String

            For I As Int16 = 0 To Me.dgvPrintList.Rows.Count - 1
                strPartId = Me.dgvPrintList.Rows(I).Cells("PartId").Value.ToString
                strParentPartId = Me.dgvPrintList.Rows(I).Cells("ParentPartId").Value.ToString
                strApplyPartId = Me.dgvPrintList.Rows(I).Cells("applyPart").Value.ToString

                If (strPartId.ToUpper <> strParentPartId.ToUpper) Then
                    strItemNum = Microsoft.VisualBasic.Right(strPartId, Len(strPartId) - InStrRev(strPartId, "-"))
                    'If (IsNumeric(strItemNum)) Then
                    '    If (Convert.ToInt16(strItemNum) > MaxItemNum) Then
                    '        MaxItemNum = Convert.ToInt16(strItemNum)
                    '    Else
                    '        MaxItemNum = MaxItemNum + 1
                    '    End If
                    'Else
                    '    If MaxItemNum > I Then
                    '        MaxItemNum = MaxItemNum + 1
                    '    Else
                    '        MaxItemNum = I + 1
                    '    End If
                    'End If

                    If (IsNumeric(strItemNum)) Then
                        If (strApplyPartId = strParentPartId) Then
                            strChildMoid = strMOid + "-" + (strItemNum).ToString.PadLeft(2, "0")
                        Else
                            If (strParentPartId = strPartId.Split("-")(0)) Then
                                strChildMoid = strMOid + "-" + strParentPartId + "-" + (strItemNum).ToString.PadLeft(2, "0")
                            Else
                                strChildMoid = strMOid + "-" + strParentPartId + "-" + strPartId
                            End If
                        End If

                    Else
                        'strChildMoid = strMOid + "-" + (I).ToString.PadLeft(2, "0")    '全部按流水号自增
                        strChildMoid = strMOid + "-" + strPartId
                    End If

                    Me.dgvPrintList.Rows(I).Cells("Moid").Value = strChildMoid
                End If
            Next
        End If
    End Sub

    '设置尾箱数量，可以根据是否为箱设置是否补加0
    '田玉琳 20190226
    Private Sub FormatMantissaBoxQty(ByVal MantissaQty As Int64)
        Try
            If (Not BarCodePartTable Is Nothing) Then
                For I As Int16 = 0 To BarCodePartTable.Rows.Count - 1
                    If BarCodePartTable.Rows(I).Item("DResource").ToString <> "" AndAlso Microsoft.VisualBasic.Left(BarCodePartTable.Rows(I).Item("DResource").ToString, 5) = "Array" Then
                        If (BarCodePartTable.Rows(I).Item("F_codeID").ToString() = "Q") Then
                            If ((BarCodePartTable.Rows(I).Item("IsBoxQty").ToString() = "Y")) Then
                                BarCodePartTable.Rows(I).Item("ShortName") = MantissaQty
                            Else
                                BarCodePartTable.Rows(I).Item("ShortName") = MantissaQty.ToString.PadLeft(CInt(BarCodePartTable.Rows(I).Item("F_codelen").ToString), "0")
                            End If
                            'If (BarCodePartTable.Rows(I).Item("BarArea").ToString() <> "BarCode1") Then
                            '    BarCodePartTable.Rows(I).Item("ShortName") = MantissaQty
                            'Else
                            '    If ((BarCodePartTable.Rows(I).Item("IsBoxQty").ToString() = "Y")) Then
                            '        BarCodePartTable.Rows(I).Item("ShortName") = MantissaQty
                            '    Else
                            '        BarCodePartTable.Rows(I).Item("ShortName") = MantissaQty.ToString.PadLeft(CInt(BarCodePartTable.Rows(I).Item("F_codelen").ToString), "0")
                            '    End If
                            'End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "FormatMantissaBoxQty", "BarCodePrint")
            Throw ex
        End Try
    End Sub

#End Region

#Region "打印"

    Private Sub BuildABarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim WorkStr As String = ""
            Dim Icount As Int16 = 0
            Dim PrinterName As String
            PrinterName = PrintData.Cells("PrinterName").EditedFormattedValue.ToString

            Me.strGroupPrintFlag = PrintData.Cells("GroupPrintFlag").Value.ToString

            '2015-06-16     马锋      InitializePrintParameter已经处理BarCodePartTable集合值，取消该段异常代码
            'For I As Integer = 0 To BarCodePartTable.Rows.Count - 1
            '    If Icount = 2 Then Exit For
            '    
            '    'If BarCodePartTable.Rows(I)("DResource").ToString = "Array5" Then
            '    '    '' PkgOldQtyStr = BarCodePartTable.Rows(I)("shortname")
            '    '    BarCodePartTable.Rows(I)("shortname") = Me.CboLine.Text.Split("-")(1)
            '    '    Icount = Icount + 1
            '    'End If
            '    If BarCodePartTable.Rows(I)("DResource").ToString = "Array9" Then
            '        If Me.CboShift.Text = "白班" Then '''''班別,
            '            WorkStr = "D"
            '        Else
            '            WorkStr = "N"
            '        End If
            '        BarCodePartTable.Rows(I)("shortname") = WorkStr
            '        Icount = Icount + 1
            '    End If
            'Next

            '打印前例行檢查及生成樣式和檢測樣式
            If Checking(PrintData) = False OrElse CheckStyle() = False Then
                Exit Sub
            End If
            AMainMarkSCode(PrinterName, PrintData.Cells("PtaskId").Value.ToString) '生成序號並打印
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildABarCode", "sys")
        End Try
    End Sub

#Region "多流水码样式程式"

    '產生樣式
    Private Function MakeAtrributeStyle() As String
        Dim I As Integer
        Dim Flag As Boolean = False
        Dim TempView As DataView

        Dim BarCodeStyle As New StringBuilder
        AtrrAxTempCode.Remove(0, AtrrAxTempCode.Length)
        'LblTempCode.Remove(0, LblTempCode.Length)
        Try
            TempView = New DataView(BarCodePartTable)
            TempView.RowFilter = "bararea='BarCode2'"
            TempView.Sort = "f_orderid asc"
            '產生樣式
            For I = 0 To TempView.Count - 1
                If TempView.Item(I).Item("IsPrintStyle").ToString = "Y" Then
                    BarCodeStyle.Append(TempView.Item(I).Item("ShortName").ToString)
                    AtrrAxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                Else
                    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" AndAlso Flag = False Then
                        AtrrCodeLen = AtrrAxTempCode.Length
                        Flag = True
                    End If
                    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "Q" Then
                        AtrrAxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                    Else
                        If TempView.Item(I).Item("ShortName").ToString.Trim <> "" Then
                            AtrrAxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                        Else
                            AtrrAxTempCode.Append(TempView.Item(I).Item("F_codeID").ToString)
                        End If
                    End If
                    BarCodeStyle.Append(TempView.Item(I).Item("F_codeID").ToString)
                End If
                'BarCodeStyle.Append(TempView.Item(I).Item("SplitChar").ToString)
            Next

            Flag = False
            'TempView = New DataView(BarCodePartTable)
            'TempView.RowFilter = "bararea='BarLabel1'"
            'TempView.Sort = "f_orderid asc"
            ''產生樣式Label1
            'For I = 0 To TempView.Count - 1
            '    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" AndAlso Flag = False Then
            '        LoadD.LblSPos = LblTempCode.Length
            '        Flag = True
            '    End If
            '    If TempView.Item(I).Item("F_codeID").ToString.ToUpper <> "S" Then
            '        LblTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
            '    End If
            '    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" Then
            '        LblTempCode.Append(TempView.Item(I).Item("F_codeID").ToString)
            '    End If
            '    LblTempCode.Append(TempView.Item(I).Item("SplitChar").ToString)
            'Next

            Return BarCodeStyle.ToString
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "MakeAtrributeStyle", "sys")
            Throw ex
            Return ""
        End Try
    End Function

    '檢查樣式 oxf20151116
    Private Function CheckAtrrStyle() As Boolean
        Dim Sqlstr As String
        Try
            PubAtrributeStype = MakeAtrributeStyle()
            Sqlstr = "select StyleID,MaxInt,MaxSN,ISNULL(IsUsed,'N')IsUsed from m_SnStyle_t where StyleID='" & PubAtrributeStype & "'"
            Using RecTable As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
                If RecTable.Rows.Count > 0 Then
                    If RecTable.Rows(0)("IsUsed").ToString = "N" Then
                        LoadD.AtrrBarCodeStyleMax = RecTable.Rows(0)("MaxSN").ToString
                        LoadD.AtrrCurrMaxInt = Int(RecTable.Rows(0)("MaxInt").ToString)
                        Sqlstr = "update m_SnStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & PubAtrributeStype & "'"
                        If strTestPrt <> "Y" Then
                            DbOperateUtils.ExecSQL(Sqlstr)
                        End If
                    Else
                        MsgBox("标签中第二对象的流水码正在打印中...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                        Return False
                    End If
                Else

                    'LoadD.AtrrBarCodeStyleMax = ""
                    'LoadD.AtrrCurrMaxInt = 0
                    LoadD.AtrrBarCodeStyleMax = LoadD.StartSn.ToString
                    LoadD.AtrrCurrMaxInt = LoadD.StartInt
                    Sqlstr = "insert into m_SnStyle_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & PubAtrributeStype & "','" & LoadD.CurrAVCPartID & "','" & LoadM.CodeRule & "','" & PubAtrributeStype & "'," & LoadD.StartInt & ",'" & LoadD.StartSn & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
                    DbOperateUtils.ExecSQL(Sqlstr)
                End If
            End Using
            Return True
        Catch ex As Exception
            LoadM.OpenLock(LoadD.StyleID)
            LoadM.OpenLock(PubAtrributeStype)
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "CheckAtrrStyle", "sys")
            Throw ex
            Return False
        End Try
    End Function

#End Region

    Private Sub BuildSBarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim PrinterName As String

            PrinterName = PrintData.Cells("PrinterName").EditedFormattedValue.ToString
            '**************************分段流水号*********************
            Me.SNDistributionCount = 0
            Me.SNDistributionID = String.Empty
            LoadM.SnDistributionCount = 0
            'Add by hgd 2017-04-25 获取分段流水号
            If Not LoadM.CodeRule Is Nothing Then
                GetSnDistributionCount(PrintData.Cells("PartId").Value.ToString(), LoadM.CodeRule)

                'Add by hgd 2017-04-25  当前厂区设置了多个流水号区段，弹出选择一个区段打印
                If Me.SNDistributionCount > 1 Then

                    Dim frmDisSel As New FrmDistributionSel(PrintData.Cells("PartId").Value.ToString(), LoadM.CodeRule)
                    If frmDisSel.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        For Each row As DataGridViewRow In frmDisSel.grvDistribution.Rows
                            If Not row.Cells(0).Value Is Nothing Then
                                If row.Cells(0).Value.ToString = "Y" Then
                                    '分段流水号ID
                                    Me.SNDistributionID = row.Cells(8).Value.ToString()
                                End If
                            End If
                        Next

                    End If
                End If

            End If

            ''********************************************************
            '打印前例行檢查及生成樣式和檢測樣式
            If Checking(PrintData) = False OrElse CheckStyle() = False Then
                Exit Sub
            End If

            ''********************************************************
            CheckIsMullitStyle(PrintData)
            ''********************************************************


            MainMarkSCode(PrinterName, PrintData.Cells("PtaskId").Value.ToString, PrintData) '生成序號並打印
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildSBarCode", "sys")
            Throw ex
        End Try
    End Sub

    Private Sub CheckIsMullitStyle(ByVal PrintData As DataGridViewRow)
        Dim Sqlstr As String = "select ISNULL(IsMultCode,'') IsMultCode from m_partpack_t a WITH(NOLOCK) join m_SnRuleM_t b WITH(NOLOCK) " & _
    " on a.CodeRuleID=b.CodeRuleID  where Partid='" & PrintData.Cells("PartId").Value.ToString() & "' and " & _
    " Packid='" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "' and a.Usey='Y'"
        Dim Mread As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
        If Mread.Rows.Count > 0 Then
            IsmullitStyle = Mread.Rows(0)!IsMultCode.ToString
        End If
        '是否多流水
        If IsmullitStyle = "Y" Then
            If CheckAtrrStyle() = False Then
                Exit Sub
            End If
        End If
    End Sub


    Private Sub BuildCBarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim WorkStr As String = ""
            Dim Icount As Int16 = 0
            For I As Integer = 0 To BarCodePartTable.Rows.Count - 1
                If Icount = 2 Then Exit For
                If BarCodePartTable.Rows(I)("DResource").ToString = "Array9" Then
                    If Me.CboShift.Text = "白班" Then '''''班別,
                        WorkStr = "D"
                    Else
                        WorkStr = "N"
                    End If
                    BarCodePartTable.Rows(I)("shortname") = WorkStr
                    Icount = Icount + 1
                End If
            Next
            ''打印前例行檢查及生成樣式和檢測樣式
            'If Checking(PrintData) = False OrElse CheckStyle() = False Then
            '    Exit Sub
            'End If

            'CMainMarkSCode(PrintData) '生成序號並打印
            '**************************分段流水号*********************
            Me.SNDistributionCount = 0
            Me.SNDistributionID = String.Empty
            LoadM.SnDistributionCount = 0
            'Add by hgd 2017-04-25 获取分段流水号
            If Not LoadM.CodeRule Is Nothing Then
                GetSnDistributionCount(PrintData.Cells("PartId").Value.ToString(), LoadM.CodeRule)

                'Add by hgd 2017-04-25  当前厂区设置了多个流水号区段，弹出选择一个区段打印
                If Me.SNDistributionCount > 1 Then

                    Dim frmDisSel As New FrmDistributionSel(PrintData.Cells("PartId").Value.ToString(), LoadM.CodeRule)
                    If frmDisSel.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        For Each row As DataGridViewRow In frmDisSel.grvDistribution.Rows
                            If Not row.Cells(0).Value Is Nothing Then
                                If row.Cells(0).Value.ToString = "Y" Then
                                    '分段流水号ID
                                    Me.SNDistributionID = row.Cells(8).Value.ToString()
                                End If
                            End If
                        Next

                    End If
                End If

            End If

            Dim existPO As Boolean = False
            Dim strPO As String = ""

            For i As Integer = 0 To BarCodePartTable.Rows.Count - 1
                If (BarCodePartTable.Rows(i).Item("f_codeid") = "PO") Then
                    strPO = BarCodePartTable.Rows(i).Item("ShortName")
                    existPO = True
                End If
            Next

            Dim printPOQuantity As Double = 0

            If (VbCommClass.VbCommClass.Factory = "LXXT") And existPO = True And CheckPOString(strPO, printPOQuantity) Then

                Dim arrPrintList As New ArrayList(Split(strPO, "，"))

                If (CDbl(Me.txtPrintCount.Text.Trim) > printPOQuantity) Then
                    arrPrintList.Add("*" & CStr(CDbl(Me.txtPrintCount.Text.Trim) - printPOQuantity))
                End If

                If CheckStyle() = False Then
                    Exit Sub
                End If

                '是否多流水
                ''********************************************************
                CheckIsMullitStyle(PrintData)
                ''********************************************************


                '增加工单总数量，非合同号打印
                For i As Integer = 0 To arrPrintList.Count - 1
                    '打印数量和PO更新

                    If (CheckingPrintQuantity(arrPrintList(i), PrintData) = False) Then
                        Exit Sub
                    End If

                    CMainMarkSCode(PrintData) '生成序號並打印
                Next
            Else

                If Checking(PrintData) = False OrElse CheckStyle() = False Then
                    Exit Sub
                End If

                '是否多流水
                ''********************************************************
                CheckIsMullitStyle(PrintData)
                ''********************************************************

                CMainMarkSCode(PrintData) '生成序號並打印
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildCBarCode", "sys")
            Throw ex
        End Try
    End Sub

    Private Sub BuildNBarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim WorkStr As String = ""
            Dim Icount As Int16 = 0
            Dim PrinterName As String
            Dim DisorderType As String
            PrinterName = PrintData.Cells("PrinterName").EditedFormattedValue.ToString
            DisorderType = Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1)

            'If CboLine.Text = "" Then
            '    MsgBox("请选择自动线线别...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            '    Exit Sub
            'End If
            If String.IsNullOrEmpty(DisorderType) Then
                MsgBox("请配置无序打印条码类型...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Exit Sub
            End If

            '2015-06-16     马锋      InitializePrintParameter已经处理BarCodePartTable集合值，取消该段异常代码
            'For I As Integer = 0 To BarCodePartTable.Rows.Count - 1
            '    If Icount = 2 Then Exit For
            '    If BarCodePartTable.Rows(I)("DResource").ToString = "Array5" Then
            '        '' PkgOldQtyStr = BarCodePartTable.Rows(I)("shortname")
            '        BarCodePartTable.Rows(I)("shortname") = Me.CboLine.Text.Split("-")(1)
            '        Icount = Icount + 1
            '    End If
            '    If BarCodePartTable.Rows(I)("DResource").ToString = "Array9" Then
            '        If Me.CboShift.Text = "白班" Then '''''班別,
            '            WorkStr = "D"
            '        Else
            '            WorkStr = "N"
            '        End If
            '        BarCodePartTable.Rows(I)("shortname") = WorkStr
            '        Icount = Icount + 1
            '    End If
            'Next

            ' ''打印前例行檢查及生成樣式和檢測樣式s
            'If Checking(PrintData) = False OrElse CheckStyle() = False Then
            '    Exit Sub
            'End If
            ''增加尾数箱处理 , PrintData.Cells("PtaskId").Value.ToString
            'NMainMarkSCode(PrinterName, "N", DisorderType, PrintData.Cells("PtaskId").Value.ToString, LoadM.Packitem, PrintData) '生成序號並打印

            Dim existPO As Boolean = False
            Dim strPO As String = ""

            For i As Integer = 0 To BarCodePartTable.Rows.Count - 1
                If (BarCodePartTable.Rows(i).Item("f_codeid") = "PO") Then
                    strPO = BarCodePartTable.Rows(i).Item("ShortName")
                    existPO = True
                End If
            Next

            Dim printPOQuantity As Double = 0

            If (VbCommClass.VbCommClass.Factory = "LXXT") And existPO = True And CheckPOString(strPO, printPOQuantity) Then
                Dim strPOTemp As String = strPO
                If InStr(strPO, "，-") > 0 Then
                    strPO = strPO.Replace("，-", "")
                End If

                Dim arrPrintList As New ArrayList(Split(strPO, "，"))

                If (CDbl(Me.txtPrintCount.Text.Trim) > printPOQuantity) And Microsoft.VisualBasic.Right(strPOTemp, 1) = "-" Then
                    arrPrintList.Add("*" & CStr(CDbl(Me.txtPrintCount.Text.Trim) - printPOQuantity))
                End If

                If CheckStyle() = False Then
                    Exit Sub
                End If

                '增加工单总数量，非合同号打印
                For i As Integer = 0 To arrPrintList.Count - 1
                    '打印数量和PO更新

                    If (CheckingPrintQuantity(arrPrintList(i), PrintData) = False) Then
                        Exit Sub
                    End If

                    NMainMarkSCode(PrinterName, "N", DisorderType, PrintData.Cells("PtaskId").Value.ToString, LoadM.Packitem, PrintData) '生成序號並打印
                Next
            Else

                If Checking(PrintData) = False OrElse CheckStyle() = False Then
                    Exit Sub
                End If

                '增加尾数箱处理 , PrintData.Cells("PtaskId").Value.ToString
                NMainMarkSCode(PrinterName, "N", DisorderType, PrintData.Cells("PtaskId").Value.ToString, LoadM.Packitem, PrintData) '生成序號並打印
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildNBarCode", "sys")
            Throw ex
        End Try
    End Sub

    Private Sub BuildPBarCode(ByVal PrintData As DataGridViewRow)
        Try
            'Dim WorkStr As String = ""
            'Dim Icount As Int16 = 0
            'For I As Integer = 0 To BarCodePartTable.Rows.Count - 1
            '    If Icount = 2 Then Exit For
            '    If BarCodePartTable.Rows(I)("DResource").ToString = "Array9" Then
            '        If Me.CboShift.Text = "白班" Then '''''班別,
            '            WorkStr = "D"
            '        Else
            '            WorkStr = "N"
            '        End If
            '        BarCodePartTable.Rows(I)("shortname") = WorkStr
            '        Icount = Icount + 1
            '    End If
            'Next
            ''打印前例行檢查及生成樣式和檢測樣式
            'If Checking(PrintData) = False OrElse CheckStyle() = False Then
            '    Exit Sub
            'End If

            'CMainMarkSCode(PrintData) '生成序號並打印
            '**************************分段流水号*********************
            Me.SNDistributionCount = 0
            Me.SNDistributionID = String.Empty
            'Add by hgd 2017-04-25 获取分段流水号
            If Not LoadM.CodeRule Is Nothing Then
                GetSnDistributionCount(PrintData.Cells("PartId").Value.ToString(), LoadM.CodeRule)

                'Add by hgd 2017-04-25  当前厂区设置了多个流水号区段，弹出选择一个区段打印
                If Me.SNDistributionCount > 1 Then

                    Dim frmDisSel As New FrmDistributionSel(PrintData.Cells("PartId").Value.ToString(), LoadM.CodeRule)
                    If frmDisSel.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        For Each row As DataGridViewRow In frmDisSel.grvDistribution.Rows
                            If Not row.Cells(0).Value Is Nothing Then
                                If row.Cells(0).Value.ToString = "Y" Then
                                    '分段流水号ID
                                    Me.SNDistributionID = row.Cells(8).Value.ToString()
                                End If
                            End If
                        Next

                    End If
                End If

            End If

            Dim existPO As Boolean = False
            Dim strPO As String = ""

            For i As Integer = 0 To BarCodePartTable.Rows.Count - 1
                If (BarCodePartTable.Rows(i).Item("f_codeid") = "PO") Then
                    strPO = BarCodePartTable.Rows(i).Item("ShortName")
                    existPO = True
                End If
            Next

            Dim printPOQuantity As Double = 0

            If (VbCommClass.VbCommClass.Factory = "LXXT") And existPO = True And CheckPOString(strPO, printPOQuantity) Then

                Dim arrPrintList As New ArrayList(Split(strPO, "，"))

                If (CDbl(Me.txtPrintCount.Text.Trim) > printPOQuantity) Then
                    arrPrintList.Add("*" & CStr(CDbl(Me.txtPrintCount.Text.Trim) - printPOQuantity))
                End If

                If CheckStyle() = False Then
                    Exit Sub
                End If

                '增加工单总数量，非合同号打印
                For i As Integer = 0 To arrPrintList.Count - 1
                    '打印数量和PO更新

                    If (CheckingPrintQuantity(arrPrintList(i), PrintData) = False) Then
                        Exit Sub
                    End If
                    PMainMarkCode(PrintData) '生成序號並打印

                Next
            Else

                If Checking(PrintData) = False OrElse CheckStyle() = False Then
                    Exit Sub
                End If

                PMainMarkCode(PrintData) '生成序號並打印
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildCBarCode", "sys")
            Throw ex
        End Try
    End Sub


#Region "有序条码"

    '生成序號並打印條碼
    Private Function MainMarkSCode(ByVal printName As String, ByVal taskId As String, ByVal PrintData As DataGridViewRow) As Boolean
        Dim I, N As Int16
        Dim SqlStr As New StringBuilder
        Dim CurrNum As Int16 = 0
        Dim CurrSBCode As New StringBuilder
        Dim AtrrrCurrSBCode As New StringBuilder
        Dim StartCode As String = ""
        Dim GPParameters As String = ""

        '清空，避免获取前面 m_BarRecordValue_t
        'BarValueStr.Remove(0, BarValueStr.Length)
        Try

            '打印前準備工作
            LoadM.SetSBCode(CurrSBCode, SBCodeLEN, SBCodeUnit, LoadD.BarCodeStyleMax)
            CurrCodeUnitTable = LoadM.SetCurrCodeUnitTable(SBCodeLEN, SBCodeUnit)
            ''**********************************************
            '是否有多流水号
            If IsmullitStyle = "Y" Then
                LoadM.SetAttributeSBCode(AtrrrCurrSBCode, AtrrSBCodeLEN, AtrrSBCodeUnit, LoadD.AtrrBarCodeStyleMax)
                CurrAtrrCodeUnitTable = LoadM.SetCurrCodeUnitTable(AtrrSBCodeLEN, AtrrSBCodeUnit)
            End If
            'Dim pFilePath As String = LoadM.PrintFilePath(LoadD.PFormat)
            If pFilePath = "" Then
                MsgBox("该料号未设置打印模板...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Exit Function
            End If

            'PrtStrTable = LoadM.SetPrtStrTable(LoadD.PFormat) 改为模板打印，不需要取指令数据
            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)
            '打印條碼

            'SqlStr.Append(vbNewLine & SetPrintStartTime(LoadD.CurrMoid, LoadD.StyleID.Replace("'", "''")))
            '正式打印條碼
            '处理打印张数
            For I = 1 To LoadD.CurrPrintNum
                '根據舊序號產生新序號
                CurrSeriNo = ""

                CurrSBCode = LoadM.MarkSKBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable, Me.SNDistributionArr)

                '流水号位，特殊字符过滤
                Dim specstr As String = LoadD.SpecFilterStr ' "UC,13,IO"
                If specstr <> "" Then
                    For Each Str As String In specstr.Split(",")
                        While CurrSBCode.ToString.IndexOf(Str) >= 0
                            CurrSBCode = LoadM.MarkSKBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable, Me.SNDistributionArr)
                        End While
                    Next
                End If




                CurrSeriNo = CurrSBCode.ToString
                ''**********************************************
                '多流水
                If IsmullitStyle = "Y" Then
                    AtrrCurrSeriNo = ""
                    AtrrrCurrSBCode = LoadM.AtrriMarkSBCode(AtrrrCurrSBCode, 1, AtrrSBCodeLEN, AtrrSBCodeUnit, CurrAtrrCodeUnitTable)
                    AtrrCurrSeriNo = AtrrrCurrSBCode.ToString()
                End If
                ''**********************************************
                If CurrSBCode.ToString = "" Then
                    'SqlStr &= ControlChars.CrLf & CheckCurrSBCode(N, UseY, CurrNum, CurrSBCode.ToString)
                    MsgBox("流水號已達最大值!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Exit For
                End If
                '起始流水號
                If I = 1 Then
                    StartCode = CurrSBCode.ToString
                End If
                '结束流水号
                If I = LoadD.CurrPrintNum Then

                End If
                '根據新序號產生新的條碼信息
                AxTempCode.Remove(LoadD.AxSPos, SBCodeLEN)
                'LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
                AxTempCode.Insert(LoadD.AxSPos, CurrSBCode.ToString)

                ''微软专用第7位校验0~6检查码 by hs ke 20190404
                ''微软专用第7位校验0~6检查码 田玉琳 20191115
                If LoadD.IsChkFlag = "XC4" Then
                    AxTempCode.Remove(LoadD.ChkPos, 1) '移除校验位码‘XC’
                    Dim msstring As String = AxTempCode.ToString.Substring(0, 6).ToString
                    Dim CheckValue As String = GetMicrosoftdigit(msstring).ToString
                    If CheckValue <> "" Then
                        AxTempCode.Insert(LoadD.ChkPos, CheckValue)
                    Else
                        Exit Function
                    End If
                End If
                '增加XC6 田玉琳 201911127
                If LoadD.IsChkFlag = "XC6" Then
                    AxTempCode.Remove(LoadD.ChkPos, 1) '移除校验位码‘XC’
                    Dim msstring As String = AxTempCode.ToString.Substring(0, 6).ToString
                    Dim CheckValue As String = GetMicrosoftdigit2(msstring).ToString
                    If CheckValue <> "" Then
                        AxTempCode.Insert(LoadD.ChkPos, CheckValue)
                    Else
                        Exit Function
                    End If
                End If

                'cq20200617
                If LoadD.IsChkFlag = "XC7" Then
                    AxTempCode.Remove(LoadD.ChkPos, 1) '移除校验位码‘XC’
                    Dim msstring As String = AxTempCode.ToString.Substring(0, 6).ToString
                    Dim CheckValue As String = GetMicrosoftdigitNoAbs(msstring).ToString
                    If CheckValue <> "" Then
                        AxTempCode.Insert(LoadD.ChkPos, CheckValue)
                    Else
                        Exit Function
                    End If
                End If

                '添加检查位Add By KyLinQiu 20170609 微软校验位计算
                If LoadD.IsChkFlag = "XC2" Then
                    AxTempCode.Remove(LoadD.ChkPos, 1)
                    Dim msstring As String = AxTempCode.ToString.Substring(0, 6).ToString
                    'Dim CheckValue As String = GetChkNumber(CurrSBCode.ToString)\
                    Dim CheckValue As String = GetChkNumber(msstring)
                    If CheckValue <> "" Then
                        AxTempCode.Insert(LoadD.ChkPos, CheckValue)
                    Else
                        Exit Function
                    End If
                End If
                If LoadD.IsChkFlag = "XC3" Then
                    AxTempCode.Remove(LoadD.ChkPos, 1)
                    Dim msstring As String = AxTempCode.ToString.Substring(0, LoadD.ChkPos).ToString
                    'Dim CheckValue As String = GetChkNumber(CurrSBCode.ToString)\
                    Dim CheckValue As String = GetSsccNCode(msstring, LoadD.ChkPos)
                    If CheckValue <> "" Then
                        AxTempCode.Insert(LoadD.ChkPos, CheckValue)
                    Else
                        Exit Function
                    End If
                End If

                If LoadD.IsChkFlag = "XC5" Then
                    AxTempCode.Remove(LoadD.ChkPos, 1)
                    Dim msstring As String = AxTempCode.ToString.Substring(0, LoadD.ChkPos).ToString
                    'Dim CheckValue As String = GetChkNumber(CurrSBCode.ToString)\
                    Dim CheckValue As String = GetXC5Code(msstring)
                    If CheckValue <> "" Then
                        AxTempCode.Insert(LoadD.ChkPos, CheckValue)
                    Else
                        Exit Function
                    End If
                End If

                'LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                If LblTempCode.ToString <> "" Then
                    LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
                    LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                    If LoadD.IsChkLabFlag Then
                        LblTempCode.Remove(LoadD.ChkLblPos, 1)
                        Dim msstring As String = AxTempCode.ToString.Substring(0, 6).ToString
                        Dim CheckValue As String = GetChkNumber(msstring)
                        'Dim CheckValue As String = GetChkNumber(CurrSBCode.ToString)
                        If CheckValue <> "" Then
                            LblTempCode.Insert(LoadD.ChkLblPos, CheckValue)
                        Else
                            Exit Function
                        End If
                    End If
                End If
                ''**********************************************
                If IsmullitStyle = "Y" Then
                    AtrrAxTempCode.Remove(AtrrCodeLen, AtrrSBCodeLEN)
                    AtrrAxTempCode.Insert(AtrrCodeLen, AtrrrCurrSBCode.ToString)
                End If
                ''**********************************************
                '臨時數組
                CurrNum += 1
                N += 1
                ReDim Preserve PrintPart(2, N)
                PrintPart(1, N) = AxTempCode.ToString
                PrintPart(2, N) = LblTempCode.ToString
                '生成打印指令If N = LoadD.PrintColNum Then
                If N = 1 Then
                    'PrintBarCode(UseY)   '
                    ModlePrintGenRecord("Y")
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    'PrintBarCode(UseY)
                    ModlePrintGenRecord("Y")
                    ReDim PrintPart(2, 0)
                    N = 0
                End If


                '******************ADD 田玉琳 2016/03/21**********************************Start
                '#20160314#70A1#客户格式的时间(我推测是63E)#十进制的流水
                '十进制作时间#客户格式的流水#客户格式的时间#十进制的流水 '2016/03/28 Update
                'Dim StartSn As Integer = IIf(LoadD.StartSn <> "", LoadD.StartSn, 0)
                'Dim SSSS As Integer = StartSn + LoadD.CurrMaxInt + I
                'GPParameters = String.Format("{0}#{1}#{2}#{3}",
                '               CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyyMMdd"), CurrSBCode, YMDCode, SSSS)
                '******************ADD 田玉琳 2016/03/21**********************************end
                TextHandle.DeleteUnVisibleChar(AxTempCode.ToString)
                '生成存儲Sql語句dd
                'SqlStr &= ControlChars.CrLf & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate) values('" & AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "',case '" & Microsoft.VisualBasic.Left(LoadM.CodeRule.ToUpper, 1) & "' when 'P' then 'P' when 'B' then 'S' when 'D' then 'S' end,1,'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "')"          " & PrtArray.Qty & "
                SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel,GPParameters) values('" &
                              TextHandle.DeleteUnVisibleChar(AxTempCode.ToString) & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine &
                              "',case '" & Microsoft.VisualBasic.Left(LoadM.CodeRule.ToUpper, 1) & "' when 'P' then 'P' when 'B' then 'S' when 'D' then 'S' when 'K' then 'K' end,'1','Y','" &
                              SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & pFilePath & "','" &
                              LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "','" & GPParameters & "')")
            Next
            LoadD.BarCodeStyleMax = CurrSBCode.ToString
            LoadD.CurrMaxInt = LoadD.CurrMaxInt + CurrNum
            '多流水码
            LoadD.AtrrBarCodeStyleMax = AtrrrCurrSBCode.ToString
            LoadD.AtrrCurrMaxInt = LoadD.AtrrCurrMaxInt + CurrNum

            MoidPrinted += LoadD.CurrPrintNum
            'add by hgd 20170426 将最大流水SN间转换
            'LoadD.CurrMaxInt = LoadM.CodeToInt(CurrSBCode.ToString, Me.LoadM.CodeRule)

            '分段流水号打印
            If (LoadM.DistributionFlag = "Y") Then
                '多号段打印
                SqlStr.Append(vbNewLine & " UPDATE m_SNDistribution_t SET PrintInt=" & LoadD.CurrMaxInt & ", PrintSN='" & LoadD.BarCodeStyleMax & "' WHERE FactoryID='" & VbCommClass.VbCommClass.Factory & "' AND PartId='" & LoadD.CurrAVCPartID & "' AND CodeRuleId='" & LoadM.CodeRule & "' and  SNDistributionID='" & Me.SNDistributionID & "' ")
                SqlStr.Append(vbNewLine & " UPDATE m_SnDistributionStyle_t SET MaxInt=" & LoadD.CurrMaxInt & ", MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' WHERE FactoryID='" & VbCommClass.VbCommClass.Factory & "' AND StyleID='" & LoadD.StyleID & "' and  SNDistributionID='" & Me.SNDistributionID & "' ")
            Else
                '非号段打印
                If loadm.SectionCodeRule = True Then
                    SqlStr.Append(vbNewLine & "update m_SnStylesection_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & LoadD.StyleID & "' AND CodeRuleId='" & LoadM.CodeRule & "'")
                Else
                    SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & LoadD.StyleID & "'")
                End If
            End If

            If IsmullitStyle = "Y" Then
                SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.AtrrCurrMaxInt & ",MaxSN='" & LoadD.AtrrBarCodeStyleMax & "',IsUsed='N' where StyleID='" & PubAtrributeStype & "'")
            End If
            SqlStr.Append(vbNewLine & "update m_Mainmo_t set Ppidprtqty=isnull(Ppidprtqty,0)+" & CurrNum & ",PpidprtCount=PpidprtCount+" & LoadD.CurrPrintNum & "*" & PrtArray.Qty & " where Moid='" & LoadD.CurrMoid & "'")
            If VbCommClass.VbCommClass.Factory = "LX53" Then
                SqlStr.Append(vbNewLine & "update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & txtPrintCount.Text & " where Ptaskid='" & taskId & "'")
            Else
                If Me.chkTestPrint.Checked Then
                    SqlStr.Append(vbNewLine & " update m_SnAssign_t set FinishTestPrintQty=isnull(FinishTestPrintQty,0)+" & CurrNum)
                    If strPrintVer <> "" Then
                        SqlStr.Append(", PrintVer='" + strPrintVer + "'")
                    End If
                    SqlStr.Append(" where Ptaskid='" & taskId & "'")
                Else
                    SqlStr.Append(vbNewLine & "update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & strPrintNumber * strConfigurationQty & ", PrintNumber = ISNULL(PrintNumber,0) + " & CurrNum)
                    If strPrintVer <> "" Then
                        SqlStr.Append(",PrintVer='" + strPrintVer + "'")
                    End If
                    SqlStr.Append(" where Ptaskid='" & taskId & "'")
                    'SqlStr.Append(vbNewLine & "update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & strPrintNumber * strConfigurationQty & ", PrintNumber = ISNULL(PrintNumber,0) + " & CurrNum & ",FinishedAddQty=case when (isnull(ApplyAddQty,0)>isnull(FinishedAddQty,0) and PrtQty+isnull(ApplyAddQty,0)=isnull(FinishPrintQty,0)+" & strPrintNumber * strConfigurationQty & ") then isnull(ApplyAddQty,0) else isnull(FinishedAddQty,0) end  where Ptaskid='" & taskId & "'")
                End If
            End If

            'SqlStr.Append(vbNewLine & "INSERT into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
            '                             " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "',case '" & Microsoft.VisualBasic.Left(LoadM.CodeRule.ToUpper, 1) & "' when 'P' then 'P' when 'D' then 'S' when 'K' then 'K' end,'" & LoadD.StyleID & "',1," & LoadD.CurrPrintNum & ",'" & StartCode & "~" & CurrSBCode.ToString & "','" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & SysMessageClass.UseId.ToLower & "',getdate())")
            'Modify insert print record, cq 20170310
            SqlStr.Append(vbNewLine & "INSERT INTO m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
                                         " VALUES('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "', '" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & LoadD.StyleID & "',1," & LoadD.CurrPrintNum & ",'" & StartCode & "~" & CurrSBCode.ToString & "','" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & SysMessageClass.UseId.ToLower & "',getdate())")

            SqlStr.Append(vbNewLine & BarValueStr.ToString())
            'SqlStr.Append(vbNewLine & "update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID & "'")
            'If IsmullitStyle = "Y" Then
            '    SqlStr.Append(vbNewLine & "update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & PubAtrributeStype & "'")
            'End If
            SqlStr.Append(vbNewLine & SetUnLockSnStyle())
            'SqlStr.Append(vbNewLine & SetPrintEndTime(LoadD.StyleID.Replace("'", "''")))

            BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)


            'File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            File.WriteAllText("C:\Program Files\默认公司名称" & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            If SqlStr.ToString() <> "" Then
                If strTestPrt <> "Y" Then '测试扫描不更新
                    DbOperateUtils.ExecSQL(SqlStr.ToString())
                End If
                If chkGetCodeNoPrint.Checked = False Then 'By 田玉琳 20151210 Update
                    FileToBarCodePrint(pFilePath, printName)
                    Try
                        '打印记录，用户追踪打印明细
                        If File.Exists("C:\Program Files\默认公司名称" & "\Bartender.txt") Then
                            Dim SetFile As String = "C:\Program Files\默认公司名称" & "\txt\"
                            Dim datestr As String = Now.ToString("yyyyMMdd").ToString
                            SetFile = SetFile & "\" & datestr & "\"
                            If Not Directory.Exists(SetFile) Then
                                Directory.CreateDirectory(SetFile)
                            End If
                            File.Copy("C:\Program Files\默认公司名称" & "\Bartender.txt", SetFile & "\" & DateTime.Now.ToString("HHmmss") & "_" & LoadD.CurrMoid & ".txt", True)
                        End If
                    Catch ex As Exception

                    End Try
                End If
            End If


            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "MainMarkSCode", "sys")
            Throw ex
        End Try
    End Function
    ''微软新产品条码校验位计算公式：
    ''        A. 数字1-6（NNNNNN）为123456
    ''        检查码=((7-1)+(7-2)+(7-3)+(7-4)+(7-5)+(7-6))/7的余数
    ''        假如余数为0，使用“7”作为检查码｜ 使用7-余数0=”7”作为检码.
    ''        B.当数值大于7时, 是否取相减的绝对值
    ''        例如：999999:
    ''        检查码=(｜7-9｜+｜7-9｜+｜7-9｜+｜7-9｜+｜7-9｜+｜7-9｜)/7=1余5 ，“5”为检查码- - - 是否正确？使用7-余数5=”2”作为检码.
    ''        例如：007899:
    ''        检查码=(｜7-0｜+｜7-0｜+｜7-7｜+｜7-8｜+｜7-9｜+｜7-9｜)/7=19/7=2余5，“5”为检查码- - - 是否正确？使用7-余数5=”2”作为检码.
    ''' <summary>
    ''' '微软新产品条码校验位计算方法函数
    ''' </summary>
    ''' <param name="inputstr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMicrosoftdigit(ByVal inputstr As String) As Integer
        Dim sum As Integer = 0
        Dim i As Integer = 0
        For i = 0 To inputstr.Length - 1
            sum = sum + System.Math.Abs(7 - Integer.Parse(inputstr.Substring(i, 1)))
        Next
        Return 7 - sum Mod 7
    End Function

    ''微软新产品条码校验位计算公式：7-((n1+n2+n3+n4+n5+n6)/7的余数)
    ''         数字1-6（NNNNNN）为123456
    ''        检查码=(1+2+3+4+5+6)/7的余数
    ''        假如余数为0，使用“7”作为检查码｜ 使用7-余数0=”7”作为检码.
    Private Function GetMicrosoftdigitNoAbs(ByVal inputstr As String) As Integer
        Dim sum As Integer = 0
        Dim i As Integer = 0
        For i = 0 To inputstr.Length - 1
            sum = sum + Integer.Parse(inputstr.Substring(i, 1))
        Next
        Return 7 - sum Mod 7
    End Function

    '为立德新加不用7减
    ''微软新产品条码校验位计算公式：
    ''        A. 数字1-6（NNNNNN）为123456
    ''        检查码=((7-1)+(7-2)+(7-3)+(7-4)+(7-5)+(7-6))/7的余数
    ''        假如余数为0，使用“7”作为检查码｜ 使用余数0=”7”作为检码.
    ''        B.当数值大于7时, 是否取相减的绝对值
    ''        例如：999999:
    ''        检查码=(｜7-9｜+｜7-9｜+｜7-9｜+｜7-9｜+｜7-9｜+｜7-9｜)/7=1余5 ，“5”为检查码- - - 是否正确？使用余数5=”2”作为检码.
    ''        例如：007899:
    ''        检查码=(｜7-0｜+｜7-0｜+｜7-7｜+｜7-8｜+｜7-9｜+｜7-9｜)/7=19/7=2余5，“5”为检查码- - - 是否正确？使用余数5=”2”作为检码.
    ''' <summary>
    ''' '微软新产品条码校验位计算方法函数
    ''' </summary>
    ''' <param name="inputstr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMicrosoftdigit2(ByVal inputstr As String) As Integer
        Dim sum As Integer = 0
        Dim i As Integer = 0
        For i = 0 To inputstr.Length - 1
            sum = sum + System.Math.Abs(7 - Integer.Parse(inputstr.Substring(i, 1)))
        Next
        Return sum Mod 7
    End Function

    '微软第七位校验
    Private Function GetChkNumber(ByVal barcode As String) As String
        Try
            Dim CharValue() As Char = barcode.ToCharArray()
            Dim sumValue As Integer = 0
            For Each cha As Char In CharValue
                sumValue += Convert.ToInt32(cha.ToString)
            Next
            Dim CheckValue As Integer = (7 * barcode.Length - sumValue) Mod 7
            If CheckValue = 0 Then
                CheckValue = 7
            Else
                '取绝对值,因为余数可能有负数
                CheckValue = Math.Abs(CheckValue)
            End If
            Return CheckValue.ToString
        Catch ex As Exception
            MessageBox.Show("生成检验码位时出错,请检查编码原则参数设置！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function
    'SCCN校验码
    Private Function GetSsccNCode(ByVal strN1toN17 As String, ByVal len As Integer) As String
        Dim strN18 As String = ""
        Try
            Dim intOdd As Integer = 0
            Dim intEven As Integer = 0
            Dim intN18 As Integer = 0
            Dim strNum As String = ""


            If (String.IsNullOrEmpty(strN1toN17) OrElse strN1toN17.Length <> len OrElse Not IsNumeric(strN1toN17)) Then
                Return strN18
            End If
            Dim i As Integer
            For i = strN1toN17.Length To 1 Step -1
                strNum = Mid(strN1toN17, i, 1)
                If (i Mod 2 = 1) Then
                    intOdd += CInt(strNum)
                Else
                    intEven += CInt(strNum)
                End If
            Next
            intOdd = intOdd * 3
            intN18 = intOdd + intEven '奇数结果+偶数结果
            intN18 = IIf(intN18 Mod 10 = 0, 0, ((intN18 \ 10 + 1) * 10) - intN18)
            strN18 = intN18.ToString()
            Return strN18
        Catch ex As Exception
            MessageBox.Show("生成检验码位时出错,请检查编码原则参数设置！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return strN18
        End Try
    End Function

    'SCCN校验码
    ''' <summary>
    ''' 创建者：田玉琳
    ''' 创建日期：20190903
    ''' 内容：第13位--安捷校验码
    ''' </summary>
    ''' <param name="barcode">条码</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetXC5Code(ByVal barcode As String) As String
        Dim CheckValue As String = ""
        Try
            Dim strSQL As String = "SELECT  CodeSort , CodeUnit  FROM m_SnUnitD_t WHERE UnitID = 'XC5'"

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            Dim CharValue() As Char = barcode.ToCharArray()
            Dim sumValue As Integer = 0
            Dim codeValue As Integer = 0
            Dim dr() As DataRow

            For rowIndex As Integer = 0 To CharValue.Length - 1
                dr = dt.Select(String.Format(" CodeUnit = '{0}' ", CharValue(rowIndex)))
                codeValue = Convert.ToInt16(dr(0)("CodeSort").ToString)

                sumValue += codeValue * Math.Pow(2, rowIndex)
            Next

            CheckValue = sumValue Mod 13
            If CheckValue = "10" Then
                CheckValue = "A"
            ElseIf CheckValue = "11" Then
                CheckValue = "B"
            ElseIf CheckValue = "12" Then
                CheckValue = "C"
            End If

            Return CheckValue.ToString
        Catch ex As Exception
            MessageBox.Show("生成检验码位时出错,请检查编码原则参数设置！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return CheckValue
        End Try
    End Function

    Private Function SetPrintStartTime(moid As String, style As String) As String

        SetPrintStartTime = " insert m_AutoPrintinfo_t (MOID, PRINTSTYLE, PrintStartTime, PrintEndTime, DiffTime, Pcname, Userid, inTime)" &
                       " values ('{0}','{1}',getdate(),NULL,NULL,'{3}','{4}',getdate())"
        SetPrintStartTime = String.Format(SetPrintStartTime, moid, style, My.Computer, UseId)
    End Function

    Private Function SetPrintEndTime(style As String) As String
        SetPrintEndTime = " DECLARE @MAXID VARCHAR(10) " &
                      " SELECT @MAXID = MAX(ID) FROM m_AutoPrintinfo_t WHERE PRINTSTYLE = '{0}' " &
                      " UPDATE m_AutoPrintinfo_t SET PrintEndTime = GETDATE(),DiffTime = DATEDIFF (S, GETDATE() , PrintStartTime) " &
                      " WHERE  ID = @MAXID"
        SetPrintEndTime = String.Format(SetPrintEndTime, style)
    End Function

    Private Function SetUnLockSnStyle() As String
        SetUnLockSnStyle =
            " update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "'" & vbNewLine &
            " update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & PubAtrributeStype & "'" & vbNewLine &
            " update m_SnStyleSection_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "'" & vbNewLine &
            " update m_SnDistributionStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "' AND FactoryId='" & VbCommClass.VbCommClass.Factory & "' "
    End Function

    Private Sub ModlePrintGenRecord(ByVal UseY As String)
        Dim I As Int16
        Dim Areaid As String
        Dim Dtable As DataTable
        Dim FixStr As String = " INSERT INTO [m_BarRecordValue_t]" & _
                      "([PackId],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                     ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                     ",[label23],[label24],[label25],[label26],[label27],[label28],[label29]) " & _
                      "VALUES('S','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',getdate(),"
        Dim nPrintStr = New StringBuilder()
        Try
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString
                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        'PrintStr.Append(CommandStr)
                        For I = 0 To TempView.Count - 1
                            'nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                            If I = 0 Then
                                If (I > 0) Then
                                    nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                Else
                                    nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                End If
                            Else
                                nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                            End If
                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 7).ToLower = "barcode" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barcode1" Then
                            Dim strcode As String = PrintPart(1, 1)
                            If strTestPrt = "Y" Then
                                strcode = ReplaceTestBarcode(strcode)
                            End If
                            If PrintStr.ToString = "" Then
                                nPrintStr.Append(strcode)
                            Else
                                nPrintStr.Append(vbNewLine & "~#" & strcode)
                            End If
                            Continue For
                            'Exit Try
                        End If
                        ''************************************ouxiangfeng 20151116********************
                        If Areaid.ToLower = "barcode2" Then
                            Dim strcode As String = AtrrAxTempCode.ToString
                            If strTestPrt = "Y" Then
                                strcode = ReplaceTestBarcode(strcode)
                            End If
                            If nPrintStr.ToString = "" Then
                                nPrintStr.Append(strcode)
                            Else
                                nPrintStr.Append(vbNewLine & strcode)
                            End If
                            Continue For
                            'Exit Try
                        End If
                        ''************************************ouxiangfeng 20151116********************
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        nPrintStr.Append(vbNewLine)
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString)
                        Next
                        nPrintStr.Append(CurrSeriNo)
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barlabel1" Then
                            If UseY = "N" Then
                                nPrintStr.Append(vbNewLine & "This is test")
                            Else
                                Dim strcode As String = PrintPart(2, 1)
                                If strTestPrt = "Y" Then
                                    strcode = ReplaceTestBarcode(strcode)
                                End If
                                nPrintStr.Append(vbNewLine & strcode)
                            End If
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If
                End Using
            Next

            ''''''''''''''''''组成标签元素值SQL语句及TXT数据源
            Dim sArray As String() = System.Text.RegularExpressions.Regex.Split(nPrintStr.ToString(), Microsoft.VisualBasic.Constants.vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim StrLen As Integer = sArray.Length
            BarValueStr.Append(FixStr)
            If BarFile.ToString() <> "" Then
                BarFile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            End If
            Dim Index As Integer = 0
            For Each ifalg As String In sArray

                If Index = 0 Then
                    BarFile.Append("""" & ifalg.ToString() & """")
                    BarValueStr.Append("'" & ifalg.ToString() & "'")
                Else
                    BarFile.Append(",""" & ifalg.ToString() & """")
                    BarValueStr.Append("," & "'" & ifalg.ToString() & "'")
                End If

                Index = Index + 1
            Next
            Dim SpaceStr As String = ","
            For j As Int16 = 1 To 21 - StrLen - 1
                SpaceStr = SpaceStr & "'',"
            Next
            SpaceStr = SpaceStr & "'')"
            BarValueStr.Append(SpaceStr)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "ModlePrintGenRecord", "sys")
            Throw ex
        End Try
    End Sub

#End Region

    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)

        'btFormat.PrintOut(False, False)
        btFormat = btApp.Formats.Open(VbCommClass.VbCommClass.PrintDataModle & pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

#Region "附属标签打印"

    '生成序號並打印條碼
    Private Function AMainMarkSCode(ByVal PrintName As String, ByVal taskId As String) As Boolean
        Dim I, N As Int16
        Dim SqlStr As String = ""
        Dim CurrNum As Int16 = 0

        'Add by Byron.Huang 2017-01-19  加入条码类型
        Dim lableType As String = Nothing

        Try

            '打印前準備工作
            PrtStrTable = LoadM.SetPrtStrTable(LoadD.PFormat)
            PrintStr.Remove(0, PrintStr.Length)
            '
            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)
            '打印條碼
            For I = 1 To LoadD.CurrPrintNum
                N += 1
                CurrNum += 1

                ReDim Preserve PrintPart(2, N)
                PrintPart(1, N) = AxTempCode.ToString
                PrintPart(2, N) = LblTempCode.ToString

                '尾数箱处理
                'If (LoadD.MantissaFlag) And I = LoadD.CurrPrintNum Then
                '    FormatMantissaBoxQty(LoadD.MantissaBoxQty)
                'End If

                '生成打印指令
                If N = LoadD.PrintColNum Then
                    'PrintBarCode(UseY)
                    'Add by Byron.Huang 2017-01-19  添加类型
                    NModlePrintGenRecord("N", False, 0, "A")
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    'PrintBarCode(UseY)
                    'Add by Byron.Huang 2017-01-19 添加类型
                    NModlePrintGenRecord("N", False, 0, "A")
                    ReDim PrintPart(2, 0)
                    N = 0
                End If
            Next
            'Me.LblYN.Text = CurrNum & "/" & LoadD.CurrPrintNum
            '插入數據庫並傳送打印指令到打印機
            'My.Computer.Name & Now.ToString("yyyy-MM-dd HH:mm:ss")      MakeStyle()
            Dim BarFlag As String = LoadD.StyleID
            SqlStr &= ControlChars.CrLf & ABarCodePrint(BarFlag, PrintStr.ToString)
            '新增条码记录到SnBarCode        " & Me.CboBarCodeType.Text.Trim.Split("-")(0) & "" & PrtArray.Qty & "
            SqlStr &= " if NOT exists(select SbarCode from m_SnSBarCode_t where SBarCode=N'" & BarFlag.Replace("'", "''") & "')    begin " & _
                      " insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & TextHandle.DeleteUnVisibleChar(AxTempCode.ToString.Replace("'", "''")) & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & Microsoft.VisualBasic.Left(LoadM.CodeRule.ToUpper, 1) & "','1','Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')  end "
            'update by hgd 2017-12-21
            If Me.chkTestPrint.Checked Then
                SqlStr &= " update m_SnAssign_t set FinishTestPrintQty=isnull(FinishTestPrintQty,0)+" & CurrNum & " "
                If strPrintVer <> "" Then
                    SqlStr &= " ,PrintVer='" + strPrintVer + "' "
                End If
                SqlStr &= " where Ptaskid='" & taskId & "'"
            Else
                SqlStr &= " update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & strPrintNumber * strConfigurationQty & ", PrintNumber = ISNULL(PrintNumber,0) + " & CurrNum & " "
                If strPrintVer <> "" Then
                    SqlStr &= " ,PrintVer='" + strPrintVer + "' "
                End If
                SqlStr &= " where Ptaskid='" & taskId & "' "
            End If
            SqlStr &= vbNewLine & SetUnLockSnStyle()

            If SqlStr <> "" Then
                If strTestPrt <> "Y" Then
                    DbOperateUtils.ExecSQL(SqlStr)
                End If
                FileToBarCodePrint(pFilePath, PrintName)
            End If
            Try
                '打印记录，用户追踪打印明细
                If File.Exists("C:\Program Files\默认公司名称" & "\Bartender.txt") Then
                    Dim SetFile As String = "C:\Program Files\默认公司名称" & "\txt\"
                    Dim datestr As String = Now.ToString("yyyyMMdd").ToString
                    SetFile = SetFile & "\" & datestr & "\"
                    If Not Directory.Exists(SetFile) Then
                        Directory.CreateDirectory(SetFile)
                    End If
                    File.Copy("C:\Program Files\默认公司名称" & "\Bartender.txt", SetFile & "\" & DateTime.Now.ToString("HHmmss") & "_" & LoadD.CurrMoid & ".txt", True)
                End If
            Catch ex As Exception

            End Try
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "AMainMarkSCode", "sys")
            Throw ex
        Finally
            LoadM.OpenLock(LoadD.StyleID.Trim.Replace("'", "''"))
        End Try
    End Function

    Private Function ABarCodePrint(ByVal BarFlag As String, ByVal PrintStr As String) As String

        Try

            Dim StrSplit As String() = {"~#"}
            Dim MaxFileLenth As Int16 = 16 ''临时方法，建议直接获取数据库表字段，进行循环。
            Dim NoValueLenth As Int16 = 0
            Dim printFlag As String = BarFlag '' My.Computer.Name & Now.ToString("yyyy-MM-dd HH:mm:ss")
            Dim Str As String() = PrintStr.Split(StrSplit, StringSplitOptions.RemoveEmptyEntries)

            Dim FixStr As String = " IF NOT EXISTS(SELECT barcodeSNID  FROM m_BarRecordValue_t WHERE barcodeSNID='" & printFlag.Replace("'", "''") & "')" & _
                       " BEGIN INSERT INTO [m_BarRecordValue_t]" & _
                       "([PackId],[PrintFlag],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                       ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                       ",[label23],[label24]) " & _
                       "VALUES('A','" & printFlag.Replace("'", "''") & "','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',GetDate()"
            Dim BarValue As String()
            Dim SqlStr As New StringBuilder

            Dim SpaceStr As String
            Dim TxtFileStr As New StringBuilder
            'Dim BarRecord() As String = PrintStr.ToString.Split("~#") 30
            For k As Int16 = 0 To Str.Length - 1
                If (k = 0) Then
                    SqlStr.Append(FixStr)
                End If

                SpaceStr = ""
                BarValue = Str(k).ToString.Trim.Split(vbNewLine) ''
                NoValueLenth = MaxFileLenth - BarValue.Length
                For i As Int16 = 0 To BarValue.Length - 1
                    'If BarValue(i).ToString.Replace(Chr(10), "").Trim = "" Then
                    '    Continue For
                    'End If

                    If (k = 0) Then
                        SqlStr.Append("," & "'" & Trim(BarValue(i).ToString.Replace(Chr(10), "").Replace("'", "''")) & "'")
                    End If

                    If k = 0 Then
                        If i = 0 Then
                            TxtFileStr.Append("""" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        Else
                            TxtFileStr.Append(",""" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        End If
                    Else
                        If i = 0 Then
                            TxtFileStr.Append(vbNewLine & """" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        Else
                            TxtFileStr.Append(",""" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        End If
                    End If
                Next

                'If k = Str.Length - 1 Then
                '    NoValueLenth = NoValueLenth - 1
                'End If

                If (k = 0) Then
                    'If LoadD.CurrPrintNum = 1 Then
                    '    NoValueLenth = NoValueLenth - 1
                    'End If
                    For j As Int16 = 1 To NoValueLenth - 1
                        SpaceStr = SpaceStr & "'',"
                    Next
                    SpaceStr = SpaceStr & "'') END"
                    SqlStr.Append("," & SpaceStr & vbNewLine)
                End If
            Next
            TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            If File.Exists("C:\Program Files\默认公司名称" & "\Bartender.txt") = False Then
                File.Copy(VbCommClass.VbCommClass.PrintDataModle, "C:\Program Files\默认公司名称" & "\Bartender.txt", True)
            End If
            File.WriteAllText("C:\Program Files\默认公司名称" & "\Bartender.txt", TxtFileStr.ToString, Encoding.UTF8)
            ABarCodePrint = SqlStr.ToString
            'File.AppendAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)
        Catch ex As Exception
            Return ""
            MessageBox.Show(ex.Message)
        End Try

    End Function

#End Region

#Region "无序打印"
    '生成序號並打印條碼
    Private Function NMainMarkSCode(ByVal PrintName As String, ByVal UseY As String, ByVal DisorderType As String, ByVal taskId As String, ByVal PackItem As String, ByVal PrintData As DataGridViewRow) As Boolean
        Dim I, N As Int16
        'Dim SqlStr As String = ""
        Dim SqlStr As New StringBuilder
        Dim CurrNum As Int16 = 0
        Dim BarFlag As String = LoadD.StyleID
        Dim tempCurrentPrintQty As String = "0"
        Try
            '打印前準備工作
            PrtStrTable = LoadM.SetPrtStrTable(LoadD.PFormat)
            PrintStr.Remove(0, PrintStr.Length)
            '--
            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)
            '打印條碼

            For I = 1 To LoadD.CurrPrintNum
                N += 1
                CurrNum += 1

                ReDim Preserve PrintPart(2, N)
                PrintPart(1, N) = AxTempCode.ToString
                PrintPart(2, N) = LblTempCode.ToString
                '尾数箱处理
                If (LoadD.MantissaFlag) And I = LoadD.CurrPrintNum Then
                    FormatMantissaBoxQty(LoadD.MantissaBoxQty)
                    FormatMantissaWeight(LoadD.MantissaBoxQty, PrintData)
                    LoadD.StyleID = MakeStyle()
                    'BarFlag = LoadD.StyleID
                    'PrintData.Cells("PackingLevel").Value.ToString()

                    SqlStr.Append(" declare @hasqty int=0 if NOT exists(select SbarCode from m_SnSBarCode_t where SBarCode=N'" & LoadD.StyleID & "')  begin " & _
                      " insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & LoadD.StyleID & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & DisorderType & "','" & LoadD.MantissaBoxQty & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & pFilePath & "','" & PackItem & "','" & DisorderType & "','" & LoadM.PackingLevel & "')  end ")
                    SqlStr.Append(" else begin select @hasqty=qty from m_SnSBarCode_t where SBarCode=N'" & LoadD.StyleID & "' end")
                    SqlStr.Append(" IF( NOT EXISTS(SELECT PartId FROM m_MOPackingLevel WHERE PartId='" & PrintData.Cells("PartId").Value.ToString & "' AND MOID='" & LoadD.CurrMoid & "' AND PackId='" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "' AND SBarCode='" & LoadD.StyleID & "' AND DisorderTypeId='" & DisorderType & "'))" & _
                         " BEGIN INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty,DisorderTypeId) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & LoadD.StyleID & "',case when @hasqty>1 then @hasqty else '" & LoadD.MantissaBoxQty & "' end,'" & DisorderType & "') End ")
                    '" ELSE BEGIN UPDATE m_MOPackingLevel SET PACKID='" & DisorderType & "',PackItem='" & PrintData.Cells("PackItem").Value.ToString & "',PackingLevel='" & PrintData.Cells("PackingLevel").Value.ToString & "',Qty='" & LoadD.MantissaBoxQty & "' Where PartId='" & PrintData.Cells("PartId").Value.ToString & "' and MOId='" & LoadD.CurrMoid & "' END "
                    PrintPart(1, 1) = LoadD.StyleID
                    NModlePrintGenRecord(UseY, LoadD.MantissaFlag, LoadD.MantissaBoxQty)
                    ReDim PrintPart(2, 0)
                    N = 0
                    Continue For
                End If

                FormatMantissaBoxQty(PrintData.Cells("PackingQty").Value.ToString)
                LoadD.StyleID = MakeStyle()
                PrintPart(1, 1) = LoadD.StyleID
                BarFlag = LoadD.StyleID
                '生成打印指令
                If N = LoadD.PrintColNum Then
                    'PrintBarCode(UseY)

                    NModlePrintGenRecord(UseY, LoadD.MantissaFlag, LoadD.MantissaBoxQty)
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    'PrintBarCode(UseY)
                    NModlePrintGenRecord(UseY, LoadD.MantissaFlag, LoadD.MantissaBoxQty)
                    ReDim PrintPart(2, 0)
                    N = 0
                End If
            Next

            If UseY = "Y" Then
                LoadD.CurrMaxInt = LoadD.CurrMaxInt + LoadD.CurrPrintNum
                SqlStr.Append(ControlChars.CrLf & " update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.CurrMaxInt & "',IsUsed='N' where StyleID='" & BarFlag & "'")
                MoidPrinted += LoadD.CurrPrintNum
                '打印記錄信息
                SqlStr.Append(ControlChars.CrLf & " insert into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime,sBarCode) " & _
                                                                  " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','N','" & BarFlag & "'," & PrtArray.Qty & "," & LoadD.CurrPrintNum & ",'','" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & BarFlag & "')")
            Else
                'Add by cq 20170309
                If Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) = "N" Then
                    tempCurrentPrintQty = Me.txtPrintCount.Text
                Else
                    tempCurrentPrintQty = LoadD.CurrPrintNum
                End If
                'LoadD.CurrPrintNum ==> tempCurrentPrintQty
                SqlStr.Append(ControlChars.CrLf & " INSERT INTO m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime,sBarCode) " & _
                                              " VALUES('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','N','" & BarFlag & "'," & PrtArray.Qty & "," & Val(tempCurrentPrintQty) & ",'','" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & BarFlag & "')")

            End If
            'Me.LblYN.Text = CurrNum & "/" & LoadD.CurrPrintNum
            '插入數據庫並傳送打印指令到打印機
            'My.Computer.Name & Now.ToString("yyyy-MM-dd HH:mm:ss")
            'MakeStyle()

            SqlStr.Append(ControlChars.CrLf & NBarCodePrint(BarFlag, PrintStr.ToString))
            '新增条码记录到SnBarCode        " & Me.CboBarCodeType.Text.Trim.Split("-")(0) & "
            If (LoadD.CurrPrintNum > 1 Or LoadD.MantissaFlag = False) Then
                'modify by cq 20171128, query sql not use SBarCode=N'" & BarFlag & "'
                SqlStr.Append(" if NOT exists(select SbarCode from m_SnSBarCode_t where SBarCode='" & BarFlag & "')    begin " & _
                      " insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & BarFlag & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & DisorderType & "','" & PrtArray.Qty & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(LblPrintDate.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & pFilePath & "','" & PackItem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')  end ")
                'SqlStr &= " update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & CurrNum & " where Ptaskid='" & taskId & "'"
                SqlStr.Append(" IF( NOT EXISTS(SELECT PartId FROM m_MOPackingLevel WHERE PartId='" & PrintData.Cells("PartId").Value.ToString & "' AND MOID='" & LoadD.CurrMoid & "' AND PackId='" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "' AND SBarCode='" & BarFlag & "' AND DisorderTypeId='" & DisorderType & "'))" & _
                         " BEGIN INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel, SBarCode,qty, DisorderTypeId) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & BarFlag & "','" & PrtArray.Qty & "', '" & DisorderType & "') End ")
                '" ELSE BEGIN UPDATE m_MOPackingLevel SET PACKID='" & DisorderType & "',PackItem='" & PrintData.Cells("PackItem").Value.ToString & "',PackingLevel='" & PrintData.Cells("PackingLevel").Value.ToString & "',Qty='" & PrtArray.Qty & "' Where PartId='" & PrintData.Cells("PartId").Value.ToString & "' and MOId='" & LoadD.CurrMoid & "' END "
            End If

            '更新已打印数量
            If DisorderType = "C" Then
                SqlStr.Append(" update m_Mainmo_t set PkgPrtqty=isnull(PkgPrtqty,0)+" & CurrNum & "  where Moid='" & LoadD.CurrMoid & "'")
            End If

            SqlStr.Append(" DECLARE @PrinteQuantity FLOAT, @NotPrinteQuantity FLOAT, @CustomerOrderDetailID VARCHAR(32) ")
            SqlStr.Append(" SET @PrinteQuantity = '" & CurrNum & "' ")
            SqlStr.Append(" IF EXISTS(SELECT 1 FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND FNSKU = '" & BarFlag & "' AND (ExportQuantity - PrinteQuantity) > 0) ")
            SqlStr.Append(" BEGIN WHILE(@PrinteQuantity > 0) BEGIN ")
            SqlStr.Append(" IF EXISTS(SELECT 1 FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND FNSKU = '" & BarFlag & "' AND (ExportQuantity - PrinteQuantity) > 0) ")
            SqlStr.Append(" BEGIN SELECT TOP 1 @CustomerOrderDetailID = CustomerOrderDetailID, @NotPrinteQuantity = ExportQuantity - PrinteQuantity ")
            SqlStr.Append(" FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND FNSKU = '" & BarFlag & "' AND (ExportQuantity - PrinteQuantity) > 0 ORDER BY CreateTime ASC ")

            SqlStr.Append(" IF (@PrinteQuantity > @NotPrinteQuantity) BEGIN UPDATE m_CustomerOrderDetail_t SET PrinteQuantity = PrinteQuantity + @NotPrinteQuantity WHERE CustomerOrderDetailID = @CustomerOrderDetailID ")
            SqlStr.Append(" SET @PrinteQuantity = @PrinteQuantity - @NotPrinteQuantity End ELSE BEGIN UPDATE m_CustomerOrderDetail_t SET PrinteQuantity = PrinteQuantity + @PrinteQuantity WHERE CustomerOrderDetailID = @CustomerOrderDetailID ")
            SqlStr.Append(" SET @PrinteQuantity = 0 End End ELSE BEGIN SET @PrinteQuantity = 0 End End End ")

            If VbCommClass.VbCommClass.Factory = "LX53" Then
                SqlStr.Append(" UPDATE m_SnAssign_t SET FinishPrintQty=isnull(FinishPrintQty,0)+" & txtPrintCount.Text & " where Ptaskid ='" & PrintData.Cells("PtaskId").Value.ToString & "' ")
            Else
                If Me.chkTestPrint.Checked Then
                    SqlStr.Append(" update m_SnAssign_t set FinishTestPrintQty=isnull(FinishTestPrintQty,0)+" & CurrNum)
                    If strPrintVer <> "" Then
                        SqlStr.Append(",PrintVer='" + strPrintVer + "'")
                    End If
                    SqlStr.Append("where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
                Else
                    SqlStr.Append(" UPDATE m_SnAssign_t SET FinishPrintQty=isnull(FinishPrintQty,0)+" & strPrintNumber * strConfigurationQty & ", PrintNumber = ISNULL(PrintNumber,0) + " & CurrNum)
                    If strPrintVer <> "" Then
                        SqlStr.Append(",PrintVer='" + strPrintVer + "'")
                    End If
                    SqlStr.Append("where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
                End If
            End If
            'SqlStr.Append(vbNewLine & SetUnLockSnStyle())
            If SqlStr.ToString <> "" Then
                If strTestPrt <> "Y" Then
                    DbOperateUtils.ExecSQL(SqlStr.ToString)
                End If
                FileToBarCodePrint(pFilePath, PrintName)
            End If
            If (LoadD.MantissaFlag) Then
                LoadM.OpenLock(BarFlag)
            End If
            LoadM.OpenLock(LoadD.StyleID)

            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "NMainMarkSCode", "sys")
            Throw ex
        Finally
            LoadM.OpenLock(BarFlag.Trim)
            If (LoadD.MantissaFlag = True) Then
                LoadM.OpenLock(LoadD.StyleID.Trim)
            End If
        End Try
    End Function

    Private Function NBarCodePrint(ByVal BarFlag As String, ByVal PrintStr As String) As String

        Try
            '增加对打印记录无法查询数据记录
            Dim StrSplit As String() = {"~#"}
            Dim MaxFileLenth As Int16 = 16 ''临时方法，建议直接获取数据库表字段，进行循环。
            Dim NoValueLenth As Int16 = 0
            Dim printFlag As String = BarFlag '' My.Computer.Name & Now.ToString("yyyy-MM-dd HH:mm:ss")
            Dim Str As String() = PrintStr.Split(StrSplit, StringSplitOptions.RemoveEmptyEntries)
            Dim FixStr As String
            Dim BarValue As String()
            Dim SqlStr As New StringBuilder
            Dim strPrintRecard As String

            Dim SpaceStr As String
            Dim strSpace As String
            Dim TxtFileStr As New StringBuilder
            'Dim BarRecord() As String = PrintStr.ToString.Split("~#") 30
            For k As Int16 = 0 To Str.Length - 1
                strPrintRecard = ""
                strSpace = ""
                If k = 0 Or ((LoadD.MantissaFlag) And k = LoadD.CurrPrintNum - 1) Then
                    If (LoadD.MantissaFlag) And k = LoadD.CurrPrintNum - 1 Then
                        FixStr = " IF NOT EXISTS(SELECT barcodeSNID  FROM m_BarRecordValue_t WHERE barcodeSNID='" & LoadD.StyleID & "' and PackId = 'N' )" & _
                           " BEGIN INSERT INTO [m_BarRecordValue_t]" & _
                           "([PackId],[PrintFlag],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                           ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                           ",[label23],[label24]) " & _
                           "VALUES('N','" & LoadD.StyleID & "','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',GetDate()"


                        SqlStr.Append(FixStr)
                    Else
                        FixStr = " IF NOT EXISTS(SELECT barcodeSNID  FROM m_BarRecordValue_t WHERE barcodeSNID='" & printFlag & "' and PackId = 'N' )" & _
                           " BEGIN INSERT INTO [m_BarRecordValue_t]" & _
                           "([PackId],[PrintFlag],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                           ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                           ",[label23],[label24]) " & _
                           "VALUES('N','" & printFlag & "','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',GetDate()"
                        SqlStr.Append(FixStr)
                    End If

                    strPrintRecard = "INSERT INTO M_NPrintRecord_t(PRINT_COMPUTER, MOID, PARTID, PACKID, PACKITEM, PRINT_USER, CREATE_TIME, BARCODE, LABEL10, LABEL11, LABEL12, LABEL13, " & _
                                    "LABEL14, LABEL15, LABEL16, LABEL17, LABEL18, LABEL19, LABEL20, LABEL21, LABEL22, LABEL23, LABEL24)VALUES(" & _
                                    "'" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "','N','" & LoadM.Packitem & "','" & SysMessageClass.UseId.ToLower & "',GetDate()"
                End If

                SpaceStr = ""

                BarValue = Str(k).Trim.ToString.Split(vbNewLine) ''
                'NoValueLenth = MaxFileLenth - BarValue.Length + 1  
                NoValueLenth = MaxFileLenth - BarValue.Length
                For i As Int16 = 0 To BarValue.Length - 1
                    'If BarValue(i).ToString.Replace(Chr(10), "").Trim = "" Then
                    'Continue For
                    'End If
                    If (k = 0 Or ((LoadD.MantissaFlag) And k = LoadD.CurrPrintNum - 1)) Then
                        SqlStr.Append("," & "'" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & "'")
                        strPrintRecard = strPrintRecard & "," & "'" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & "'"
                    End If

                    If k = 0 Then
                        If i = 0 Then
                            TxtFileStr.Append("""" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        Else
                            TxtFileStr.Append(",""" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        End If
                    Else
                        If i = 0 Then
                            TxtFileStr.Append(vbNewLine & """" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        Else
                            TxtFileStr.Append(",""" & Trim(BarValue(i).ToString.Replace(Chr(10), "")) & """")
                        End If
                    End If
                Next
                'If k = Str.Length - 1 Then
                '    NoValueLenth = NoValueLenth - 1
                'End If
                '**********************2016/04/01 田玉琳  Add'**********************Start
                '箱号的要求设置时替换内容
                TxtFileStr.Replace("##/##", String.Format("{0}/{1}", (k + 1).ToString, LoadD.CurrPrintNum.ToString))
                '**********************2016/04/01 田玉琳  Add'**********************End

                If k = 0 Or ((LoadD.MantissaFlag) And k = LoadD.CurrPrintNum - 1) Then
                    For j As Int16 = 1 To NoValueLenth - 1
                        SpaceStr = SpaceStr & "'',"
                        strSpace = strSpace & "'',"
                    Next
                    SpaceStr = SpaceStr & "'') END"

                    strPrintRecard = strPrintRecard & "," & strSpace & "'')"
                    SqlStr.Append("," & SpaceStr & vbNewLine)
                    SqlStr.Append(strPrintRecard & vbNewLine)
                End If
            Next

            TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            If File.Exists("C:\Program Files\默认公司名称" & "\Bartender.txt") = False Then
                File.Copy(VbCommClass.VbCommClass.PrintDataModle, "C:\Program Files\默认公司名称" & "\Bartender.txt", True)
            End If
            File.WriteAllText("C:\Program Files\默认公司名称" & "\Bartender.txt", TxtFileStr.ToString, Encoding.UTF8)
            NBarCodePrint = SqlStr.ToString
            'File.AppendAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)
        Catch ex As Exception
            Return ""
            MessageBox.Show(ex.Message)
        End Try


    End Function

    ''码元值生成至数据库，供exce调用
    Private Sub NModlePrintGenRecord(ByVal UseY As String, ByVal MantissaFlag As Boolean, ByVal MantissaBoxQty As Int16, Optional ByVal LableType As String = Nothing)
        Dim I As Int16
        Dim Areaid As String
        Dim Dtable As DataTable
        Dim TmpStr As New StringBuilder
        Dim OtherStr As New StringBuilder
        Try
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString

                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        'PrintStr.Append(CommandStr)
                        For I = 0 To TempView.Count - 1
                            'If(TempView.Item(I).Item("ShortName").ToString
                            If I = 0 Then
                                If Me.strGroupPrintFlag = "Y" Then
                                    'Add by Byron.Huang 2017-01-19  附属条码的参数，每个参数都需要打印一个条码
                                    If LableType = "A" AndAlso TempView.Item(I).Item("ShortName").ToString <> "" AndAlso TempView.Item(I).Item("DResource").ToString = "PartSet" Then
                                        If TempView.Item(I).Item("UnitId").ToString = "" Then
                                            PrintStr.Append(TmpStr.ToString + OtherStr.ToString)
                                            TmpStr = New StringBuilder()

                                            TmpStr.Append(vbNewLine & "~#" & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                            Continue For
                                        Else
                                            TmpStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                        End If
                                    End If

                                    'Add by Byron.Byron 2017-01-19 附属条码，其它条码部分
                                    OtherStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)

                                End If
                                If (I > 0) Then
                                    PrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                Else
                                    PrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                End If
                            Else
                                PrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                            End If

                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 7).ToLower = "barcode" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barcode1" Then
                            If PrintStr.ToString = "" Then
                                PrintStr.Append(PrintPart(1, 1))
                            Else
                                PrintStr.Append(vbNewLine & "~#" & PrintPart(1, 1))
                            End If
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            PrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barlabel1" Then
                            If UseY = "N" Then
                                PrintStr.Append(vbNewLine & "This is test")
                            Else
                                PrintStr.Append(vbNewLine & PrintPart(2, 1))
                            End If
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            PrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If
                End Using

            Next


            'Add by Byron.Huang 2017-01-19  附属条码，拼接字符
            If LableType = "A" AndAlso Me.strGroupPrintFlag = "Y" AndAlso TmpStr.ToString.Length > 0 Then
                PrintStr.Append(TmpStr.ToString + OtherStr.ToString)
            End If

            Dtable = Nothing
        Catch ex As Exception
            Dtable = Nothing
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "NModlePrintGenRecord", "sys")
            Throw ex
        End Try

    End Sub

#End Region

#Region "包装打印"
    '生成序號並打印條碼
    Private Function CMainMarkSCode(ByVal PrintData As DataGridViewRow) As Boolean
        Dim I, N As Int16
        Dim SqlStr As New System.Text.StringBuilder
        Dim CurrNum As Int16 = 0
        Dim CurrSBCode As New StringBuilder
        Dim AtrrrCurrSBCode As New StringBuilder
        Dim StartCode As String = ""
        Try

            '打印前準備工作
            LoadM.SetSBCode(CurrSBCode, SBCodeLEN, SBCodeUnit, LoadD.BarCodeStyleMax)
            CurrCodeUnitTable = LoadM.SetCurrCodeUnitTable(SBCodeLEN, SBCodeUnit)

            '是否有多流水号
            If IsmullitStyle = "Y" Then
                LoadM.SetAttributeSBCode(AtrrrCurrSBCode, AtrrSBCodeLEN, AtrrSBCodeUnit, LoadD.AtrrBarCodeStyleMax)
                CurrAtrrCodeUnitTable = LoadM.SetCurrCodeUnitTable(AtrrSBCodeLEN, AtrrSBCodeUnit)
            End If

            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)

            '打印條碼
            ''''''''''''''''''''''''''''''''''''
            '正式打印條碼
            For I = 1 To LoadD.CurrPrintNum
                '根據舊序號產生新序號
                'CurrSBCode = LoadM.MarkSBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable)

                CurrSBCode = LoadM.MarkSKBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable, Me.SNDistributionArr)
                '流水号位，特殊字符过滤
                Dim specstr As String = LoadD.SpecFilterStr ' "UC,13,IO"
                If specstr <> "" Then
                    For Each Str As String In specstr.Split(",")
                        While CurrSBCode.ToString.IndexOf(Str) >= 0
                            CurrSBCode = LoadM.MarkSKBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable, Me.SNDistributionArr)
                        End While
                    Next
                End If

                ''**********************************************
                '多流
                If IsmullitStyle = "Y" Then
                    AtrrCurrSeriNo = ""
                    AtrrrCurrSBCode = LoadM.AtrriMarkSBCode(AtrrrCurrSBCode, 1, AtrrSBCodeLEN, AtrrSBCodeUnit, CurrAtrrCodeUnitTable)
                    AtrrCurrSeriNo = AtrrrCurrSBCode.ToString()
                End If
                ''**********************************************

                If CurrSBCode.ToString = "" Then
                    'SqlStr &= ControlChars.CrLf & CheckCurrSBCode(N, UseY, CurrNum, CurrSBCode.ToString)
                    MsgBox("流水號已達最大值!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Exit For
                End If
                '起始流水號
                If I = 1 Then
                    StartCode = CurrSBCode.ToString
                End If
                ''根據新序號產生新的條碼信息
                'AxTempCode.Remove(LoadD.AxSPos, SBCodeLEN)

                'AxTempCode.Insert(LoadD.AxSPos, CurrSBCode.ToString)
                'If LblTempCode.ToString <> "" Then
                '    LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
                '    LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                'End If

                ''臨時數組
                'CurrNum += 1
                'N += 1
                'ReDim Preserve PrintPart(2, N)
                'PrintPart(1, N) = AxTempCode.ToString
                'PrintPart(2, N) = LblTempCode.ToString

                If (LoadD.MantissaFlag) And I = LoadD.CurrPrintNum Then
                    FormatMantissaBoxQty(LoadD.MantissaBoxQty)
                    LoadD.StyleIDCartonNotFull = MakeStyle()
                    '根據新序號產生新的條碼信息
                    AxTempCode.Remove(LoadD.AxSPos, SBCodeLEN)

                    AxTempCode.Insert(LoadD.AxSPos, CurrSBCode.ToString)
                    ''微软专用第7位校验0~6检查码 by hs ke 20190404
                    If LoadD.IsChkFlag = "XC4" Then
                        AxTempCode.Remove(LoadD.ChkPos, 1) '移除校验位码‘XC’
                        Dim msstring As String = AxTempCode.ToString.Substring(0, 6).ToString
                        Dim CheckValue As String = GetMicrosoftdigit(msstring).ToString
                        If CheckValue <> "" Then
                            AxTempCode.Insert(LoadD.ChkPos, CheckValue)
                        Else
                            Exit Function
                        End If
                    End If
                    '不用7减余数 田玉琳 20191115
                    '增加XC6 田玉琳 201911127
                    If LoadD.IsChkFlag = "XC6" Then
                        AxTempCode.Remove(LoadD.ChkPos, 1) '移除校验位码‘XC’
                        Dim msstring As String = AxTempCode.ToString.Substring(0, 6).ToString
                        Dim CheckValue As String = GetMicrosoftdigit2(msstring).ToString
                        If CheckValue <> "" Then
                            AxTempCode.Insert(LoadD.ChkPos, CheckValue)
                        Else
                            Exit Function
                        End If
                    End If

                    'add by cq20200617
                    If LoadD.IsChkFlag = "XC7" Then
                        AxTempCode.Remove(LoadD.ChkPos, 1) '移除校验位码‘XC’
                        Dim msstring As String = AxTempCode.ToString.Substring(0, 6).ToString
                        Dim CheckValue As String = GetMicrosoftdigitNoAbs(msstring).ToString
                        If CheckValue <> "" Then
                            AxTempCode.Insert(LoadD.ChkPos, CheckValue)
                        Else
                            Exit Function
                        End If
                    End If

                    'SCCN校验码
                    If LoadD.IsChkFlag = "XC3" Then
                        AxTempCode.Remove(LoadD.ChkPos, 1)
                        Dim msstring As String = AxTempCode.ToString.Substring(0, LoadD.ChkPos).ToString
                        'Dim CheckValue As String = GetChkNumber(CurrSBCode.ToString)\
                        Dim CheckValue As String = GetSsccNCode(msstring, LoadD.ChkPos)
                        If CheckValue <> "" Then
                            AxTempCode.Insert(LoadD.ChkPos, CheckValue)
                        Else
                            Exit Function
                        End If
                    End If
                    If LblTempCode.ToString <> "" Then
                        LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
                        LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                    End If
                    ''**********************************************
                    If IsmullitStyle = "Y" Then
                        AtrrAxTempCode.Remove(AtrrCodeLen, AtrrSBCodeLEN)
                        AtrrAxTempCode.Insert(AtrrCodeLen, AtrrrCurrSBCode.ToString)
                    End If
                    ''**********************************************
                    '臨時數組
                    CurrNum += 1
                    N += 1
                    ReDim Preserve PrintPart(2, N)
                    PrintPart(1, N) = AxTempCode.ToString
                    PrintPart(2, N) = LblTempCode.ToString
                    'TextHandle.DeleteUnVisibleChar(AxTempCode.ToString)
                    SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "'," & LoadD.MantissaBoxQty & ",'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')")
                    SqlStr.Append(vbNewLine & "INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & AxTempCode.ToString & "','" & LoadD.MantissaBoxQty & "')")
                    'PrintPart(1, 1) = LoadD.StyleID
                    CModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0
                    Continue For
                End If
                '根據新序號產生新的條碼信息
                AxTempCode.Remove(LoadD.AxSPos, SBCodeLEN)

                AxTempCode.Insert(LoadD.AxSPos, CurrSBCode.ToString)
                ''微软专用第7位校验0~6检查码 by hs ke 20190404
                If LoadD.IsChkFlag = "XC4" Then
                    AxTempCode.Remove(LoadD.ChkPos, 1) '移除校验位码‘XC’
                    Dim msstring As String = AxTempCode.ToString.Substring(0, 6).ToString
                    Dim CheckValue As String = GetMicrosoftdigit(msstring).ToString
                    If CheckValue <> "" Then
                        AxTempCode.Insert(LoadD.ChkPos, CheckValue)
                    Else
                        Exit Function
                    End If
                End If
                '增加XC6 田玉琳 201911127
                If LoadD.IsChkFlag = "XC6" Then
                    AxTempCode.Remove(LoadD.ChkPos, 1) '移除校验位码‘XC’
                    Dim msstring As String = AxTempCode.ToString.Substring(0, 6).ToString
                    Dim CheckValue As String = GetMicrosoftdigit2(msstring).ToString
                    If CheckValue <> "" Then
                        AxTempCode.Insert(LoadD.ChkPos, CheckValue)
                    Else
                        Exit Function
                    End If
                End If
                'SCCN校验码
                If LoadD.IsChkFlag = "XC3" Then
                    AxTempCode.Remove(LoadD.ChkPos, 1)
                    Dim msstring As String = AxTempCode.ToString.Substring(0, LoadD.ChkPos).ToString
                    'Dim CheckValue As String = GetChkNumber(CurrSBCode.ToString)\
                    Dim CheckValue As String = GetSsccNCode(msstring, LoadD.ChkPos)
                    If CheckValue <> "" Then
                        AxTempCode.Insert(LoadD.ChkPos, CheckValue)
                    Else
                        Exit Function
                    End If
                End If
                If LblTempCode.ToString <> "" Then
                    LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
                    LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                End If

                '臨時數組
                CurrNum += 1
                N += 1
                ReDim Preserve PrintPart(2, N)
                PrintPart(1, N) = AxTempCode.ToString
                PrintPart(2, N) = LblTempCode.ToString



                If (I = 1) Then
                    FormatMantissaBoxQty(PrintData.Cells("PackingQty").Value.ToString)
                    'LoadD.StyleID = MakeStyle()
                End If

                If IsmullitStyle = "Y" Then
                    AtrrAxTempCode.Remove(AtrrCodeLen, AtrrSBCodeLEN)
                    AtrrAxTempCode.Insert(AtrrCodeLen, AtrrrCurrSBCode.ToString)
                End If
                '生成打印指令
                If N = LoadD.PrintColNum Then
                    CModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    CModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0S
                End If
                'TextHandle.DeleteUnVisibleChar(AxTempCode.ToString)
                SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "'," & PrtArray.Qty & ",'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')")
                SqlStr.Append(vbNewLine & "INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & AxTempCode.ToString & "','" & PrtArray.Qty & "')")
            Next
            LoadD.BarCodeStyleMax = CurrSBCode.ToString
            LoadD.CurrMaxInt = LoadD.CurrMaxInt + CurrNum

            '多流水码
            LoadD.AtrrBarCodeStyleMax = AtrrrCurrSBCode.ToString
            LoadD.AtrrCurrMaxInt = LoadD.AtrrCurrMaxInt + CurrNum

            MoidPrinted += LoadD.CurrPrintNum
            'add by hgd 20170426 将最大流水SN间转换
            'LoadD.CurrMaxInt = LoadM.CodeToInt(CurrSBCode.ToString, Me.LoadM.CodeRule)
            If (LoadM.DistributionFlag = "Y") Then
                SqlStr.Append(vbNewLine & " UPDATE m_SNDistribution_t SET PrintInt=" & LoadD.CurrMaxInt & ", PrintSN='" & LoadD.BarCodeStyleMax & "' WHERE FactoryID='" & VbCommClass.VbCommClass.Factory & "' AND PartId='" & LoadD.CurrAVCPartID & "' AND CodeRuleId='" & LoadM.CodeRule & "' and  SNDistributionID='" & Me.SNDistributionID & "'  ")
                SqlStr.Append(vbNewLine & " UPDATE m_SnDistributionStyle_t SET MaxInt=" & LoadD.CurrMaxInt & ", MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' WHERE FactoryID='" & VbCommClass.VbCommClass.Factory & "' AND StyleID='" & LoadD.StyleID & "' and  SNDistributionID='" & Me.SNDistributionID & "'  ")
            Else
                SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & LoadD.StyleID & "'")

            End If

            If IsmullitStyle = "Y" Then
                SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.AtrrCurrMaxInt & ",MaxSN='" & LoadD.AtrrBarCodeStyleMax & "',IsUsed='N' where StyleID='" & PubAtrributeStype & "'")
            End If

            SqlStr.Append(vbNewLine & "update m_Mainmo_t set PkgPrtqty=isnull(PkgPrtqty,0)+" & CurrNum & "  where Moid='" & LoadD.CurrMoid & "'")

            SqlStr.Append(vbNewLine & "insert into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
                                         " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & Me.CboLine.Text.Trim & "','C','" & LoadD.StyleID & "'," & PackMethod & "," & LoadD.CurrPrintNum & ",'" & CurrSBCode.ToString & "','" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & SysMessageClass.UseId.ToLower & "',getdate())")
            SqlStr.Append(vbNewLine & BarValueStr.ToString())
            If VbCommClass.VbCommClass.Factory = "LX53" Then
                SqlStr.Append(vbNewLine & " update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & txtPrintCount.Text & " where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
            Else
                '2016-09-21     马锋      CurrNum更改为txtPrintCount.Text，CurrNum是打印张数
                If Me.chkTestPrint.Checked Then
                    SqlStr.Append(vbNewLine & " update m_SnAssign_t set FinishTestPrintQty=isnull(FinishTestPrintQty,0)+" & CurrNum)
                    If strPrintVer <> "" Then
                        SqlStr.Append(",PrintVer='" + strPrintVer + "'")
                    End If
                    SqlStr.Append(" where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
                Else
                    SqlStr.Append(vbNewLine & " update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & strPrintNumber * strConfigurationQty & ", PrintNumber = ISNULL(PrintNumber,0) + " & CurrNum)
                    If strPrintVer <> "" Then
                        SqlStr.Append(",PrintVer='" + strPrintVer + "'")
                    End If
                    SqlStr.Append(" where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
                End If

            End If

            SqlStr.Append(vbNewLine & "update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID & "'")
            'LK5MF052-CS-R  
            SqlStr.Append(vbNewLine & "DECLARE @PrinteQuantity FLOAT, @NotPrinteQuantity FLOAT, @CustomerOrderDetailID VARCHAR(32), @PRDimensions VARCHAR(32) ")
            SqlStr.Append(vbNewLine & "SET @PrinteQuantity = '" & txtPrintCount.Text & "' SET @PRDimensions = '" & Microsoft.VisualBasic.Left(LoadD.StyleID, Microsoft.VisualBasic.Len(LoadD.StyleID) - 4) & "' ")
            SqlStr.Append(vbNewLine & "IF EXISTS(SELECT 1 FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND PRDimensions = @PRDimensions AND ISNULL(FNSKU,'') = '' AND (ExportQuantity - PrinteQuantity) > 0)  ")
            SqlStr.Append(vbNewLine & "BEGIN WHILE(@PrinteQuantity > 0) BEGIN ")
            SqlStr.Append(vbNewLine & "IF EXISTS(SELECT 1 FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND PRDimensions = @PRDimensions AND ISNULL(FNSKU,'') = '' AND (ExportQuantity - PrinteQuantity) > 0)  ")
            SqlStr.Append(vbNewLine & "BEGIN SELECT TOP 1 @CustomerOrderDetailID = CustomerOrderDetailID, @NotPrinteQuantity = ExportQuantity - PrinteQuantity  ")
            SqlStr.Append(vbNewLine & "FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND PRDimensions = @PRDimensions AND ISNULL(FNSKU,'') = '' AND (ExportQuantity - PrinteQuantity) > 0 ORDER BY CreateTime ASC  ")
            SqlStr.Append(vbNewLine & "	IF (@PrinteQuantity > @NotPrinteQuantity) BEGIN	UPDATE m_CustomerOrderDetail_t SET PrinteQuantity = PrinteQuantity + @NotPrinteQuantity WHERE CustomerOrderDetailID = @CustomerOrderDetailID  ")
            SqlStr.Append(vbNewLine & " SET @PrinteQuantity = @PrinteQuantity - @NotPrinteQuantity End ELSE BEGIN  ")
            SqlStr.Append(vbNewLine & "UPDATE m_CustomerOrderDetail_t SET PrinteQuantity = PrinteQuantity + @PrinteQuantity WHERE CustomerOrderDetailID = @CustomerOrderDetailID  ")
            SqlStr.Append(vbNewLine & "SET @PrinteQuantity = 0 End End ELSE BEGIN SET @PrinteQuantity = 0 End End End ")

            SqlStr.Append(vbNewLine & SetUnLockSnStyle())
            'Me.LblYN.Text = CurrNum & "/" & LoadD.CurrPrintNum
            'If UseY = "Y" Then '
            '    MoidPrinted += LoadD.CurrPrintNum
            '    CtPrtingNum -= LoadD.CurrPrintNum
            '    Me.LblMoidOkNum.Text = MoidPrinted & " Box"
            '    Me.LblCartonPrintNum.Text = CtPrtingNum & " Box"
            'End If
            '插入數據庫並傳送打印指令到打印機

            BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24"",""lable25"",""lable26"",""lable27"",""lable28"",""lable29""" & vbNewLine)
            File.WriteAllText("C:\Program Files\默认公司名称" & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            If SqlStr.ToString() <> "" Then
                If strTestPrt <> "Y" Then
                    DbOperateUtils.ExecSQL(SqlStr.ToString)
                End If
                FileToBarCodePrint(pFilePath, PrintData.Cells("PrinterName").Value.ToString)
            End If

            Try
                '打印记录，用户追踪打印明细
                If File.Exists("C:\Program Files\默认公司名称" & "\Bartender.txt") Then
                    Dim SetFile As String = "C:\Program Files\默认公司名称" & "\txt\"
                    Dim datestr As String = Now.ToString("yyyyMMdd").ToString
                    SetFile = SetFile & "\" & datestr & "\"
                    If Not Directory.Exists(SetFile) Then
                        Directory.CreateDirectory(SetFile)
                    End If
                    File.Copy("C:\Program Files\默认公司名称" & "\Bartender.txt", SetFile & "\" & DateTime.Now.ToString("HHmmss") & "_" & LoadD.CurrMoid & ".txt", True)
                End If
            Catch ex As Exception

            End Try
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildCBarCode", "sys")
            Throw ex
        Finally
            LoadM.OpenLock(LoadD.StyleID)
            If (LoadM.DistributionFlag = "Y") Then
                LoadM.OpenDistributionLock(LoadD.StyleID.Replace("'", "''"), VbCommClass.VbCommClass.Factory, Me.SNDistributionID)
            End If
        End Try
    End Function

    ''码元值生成至数据库，供exce调用
    Private Sub CModlePrintGenRecord()
        Dim I As Int16
        Dim Areaid As String
        Dim Dtable As DataTable
        Dim FixStr As String = " INSERT INTO [m_BarRecordValue_t]" & _
                      "([PackId],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                     ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                     ",[label23],[label24],label25,label26,label27,label28,label29) " & _
                      "VALUES('C','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',getdate(),"
        Dim nPrintStr = New StringBuilder()
        Try
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString
                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        'PrintStr.Append(CommandStr)
                        For I = 0 To TempView.Count - 1
                            'nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)

                            If I = 0 Then
                                If (I > 0) Then
                                    nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                Else
                                    nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                End If
                            Else
                                nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                            End If
                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 7).ToLower = "barcode" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barcode1" Then
                            Dim strcode As String = PrintPart(1, 1)
                            If strTestPrt = "Y" Then
                                strcode = ReplaceTestBarcode(strcode)
                            End If
                            If PrintStr.ToString = "" Then
                                nPrintStr.Append(strcode)
                            Else
                                nPrintStr.Append(vbNewLine & "~#" & strcode)
                            End If
                            Continue For
                            'Exit Try
                        End If
                        ''************************************田玉琳 20200427********************
                        If Areaid.ToLower = "barcode2" Then
                            Dim strcode As String = AtrrAxTempCode.ToString
                            If strTestPrt = "Y" Then
                                strcode = ReplaceTestBarcode(strcode)
                            End If
                            If nPrintStr.ToString = "" Then
                                nPrintStr.Append(strcode)
                            Else
                                nPrintStr.Append(vbNewLine & strcode)
                            End If
                            Continue For
                            'Exit Try
                        End If
                        ''************************************田玉琳 20200427********************
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If


                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barlabel1" Then
                            Dim strcode As String = PrintPart(2, 1)
                            If strTestPrt = "Y" Then
                                strcode = ReplaceTestBarcode(strcode)
                            End If
                            nPrintStr.Append(vbNewLine & strcode)
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If
                End Using

            Next

            ''''''''''''''''''组成标签元素值SQL语句及TXT数据源
            Dim sArray As String() = System.Text.RegularExpressions.Regex.Split(nPrintStr.ToString(), Microsoft.VisualBasic.Constants.vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim StrLen As Integer = sArray.Length
            BarValueStr.Append(FixStr)
            If BarFile.ToString() <> "" Then
                BarFile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            End If
            Dim Index As Integer = 0
            For Each ifalg As String In sArray
                'if (BarValueStr.ToString() == "")
                '{
                '    BarFile.Append("\"" + i.ToString() + "\"");
                '    BarValueStr.Append("," + "'" + i.ToString() + "'");
                '}
                'else
                '{

                If Index = 0 Then
                    BarFile.Append("""" & ifalg.ToString() & """")
                    BarValueStr.Append("'" & ifalg.ToString() & "'")
                Else
                    BarFile.Append(",""" & ifalg.ToString() & """")
                    BarValueStr.Append("," & "'" & ifalg.ToString() & "'")
                End If

                '}

                Index = Index + 1
            Next
            Dim SpaceStr As String = ","
            For j As Int16 = 1 To 21 - StrLen - 1
                SpaceStr = SpaceStr & "'',"
            Next
            SpaceStr = SpaceStr & "'')"
            BarValueStr.Append(SpaceStr)

            Dtable = Nothing
        Catch ex As Exception
            Dtable = Nothing
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "CModlePrintGenRecord", "sys")
            Throw ex
        End Try

    End Sub

#End Region


#Region "栈板条码打印"

    '生成栈板序號並打印條碼
    Private Function PMainMarkCode(ByVal PrintData As DataGridViewRow) As Boolean
        Dim I, N As Int16
        Dim SqlStr As New System.Text.StringBuilder
        Dim CurrNum As Int64 = 0
        Dim CurrSBCode As New StringBuilder
        Dim StartCode As String = ""
        Try

            '打印前準備工作
            LoadM.SetSBCode(CurrSBCode, SBCodeLEN, SBCodeUnit, LoadD.BarCodeStyleMax)
            CurrCodeUnitTable = LoadM.SetCurrCodeUnitTable(SBCodeLEN, SBCodeUnit)
            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)

            '打印條碼
            ''''''''''''''''''''''''''''''''''''
            '正式打印條碼
            For I = 1 To LoadD.CurrPrintNum
                '根據舊序號產生新序號
                'CurrSBCode = LoadM.MarkSBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable)

                CurrSBCode = LoadM.MarkSKBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable, Me.SNDistributionArr)
                '流水号位，特殊字符过滤
                Dim specstr As String = LoadD.SpecFilterStr ' "UC,13,IO"
                If specstr <> "" Then
                    For Each Str As String In specstr.Split(",")
                        While CurrSBCode.ToString.IndexOf(Str) >= 0
                            CurrSBCode = LoadM.MarkSKBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable, Me.SNDistributionArr)
                        End While
                    Next
                End If

                If CurrSBCode.ToString = "" Then
                    'SqlStr &= ControlChars.CrLf & CheckCurrSBCode(N, UseY, CurrNum, CurrSBCode.ToString)
                    MsgBox("流水號已達最大值!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Exit For
                End If
                '起始流水號
                If I = 1 Then
                    StartCode = CurrSBCode.ToString
                End If
                '根據新序號產生新的條碼信息
                AxTempCode.Remove(LoadD.AxSPos, SBCodeLEN)

                AxTempCode.Insert(LoadD.AxSPos, CurrSBCode.ToString)
                If LblTempCode.ToString <> "" Then
                    LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
                    LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                End If

                '臨時數組
                CurrNum += 1
                N += 1
                ReDim Preserve PrintPart(2, N)
                PrintPart(1, N) = AxTempCode.ToString
                PrintPart(2, N) = LblTempCode.ToString

                If (LoadD.MantissaFlag) And I = LoadD.CurrPrintNum Then
                    FormatMantissaBoxQty(LoadD.MantissaBoxQty)
                    'LoadD.StyleID = MakeStyle()LoadD.StyleID
                    'TextHandle.DeleteUnVisibleChar(AxTempCode.ToString)
                    SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "'," & LoadD.MantissaBoxQty & ",'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')")
                    SqlStr.Append(vbNewLine & "INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & AxTempCode.ToString & "','" & LoadD.MantissaBoxQty & "')")
                    'PrintPart(1, 1) = LoadD.StyleID
                    CModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0
                    Continue For
                End If

                If (I = 1) Then
                    FormatMantissaBoxQty(PrintData.Cells("PackingQty").Value.ToString)
                    'LoadD.StyleID = MakeStyle()
                End If

                '生成打印指令
                If N = LoadD.PrintColNum Then

                    PModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    PModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0S
                End If
                'TextHandle.DeleteUnVisibleChar(AxTempCode.ToString)
                SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "'," & PrtArray.Qty & ",'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')")
                SqlStr.Append(vbNewLine & "INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty) VALUES('" & PrintData.Cells("PartId").Value.ToString & "','" & LoadD.CurrMoid & "','" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & PrintData.Cells("PackItem").Value.ToString & "','" & LoadM.PackingLevel & "','" & AxTempCode.ToString & "','" & PrtArray.Qty & "')")
            Next
            LoadD.BarCodeStyleMax = CurrSBCode.ToString
            LoadD.CurrMaxInt = LoadD.CurrMaxInt + CurrNum
            MoidPrinted += LoadD.CurrPrintNum
            'add by hgd 20170426 将最大流水SN间转换--注释掉
            'LoadD.CurrMaxInt = LoadM.CodeToInt(CurrSBCode.ToString, Me.LoadM.CodeRule)
            If (LoadM.DistributionFlag = "Y") Then
                SqlStr.Append(vbNewLine & " UPDATE m_SNDistribution_t SET PrintInt=" & LoadD.CurrMaxInt & ", PrintSN='" & LoadD.BarCodeStyleMax & "' WHERE FactoryID='" & VbCommClass.VbCommClass.Factory & "' AND PartId='" & LoadD.CurrAVCPartID & "' AND CodeRuleId='" & LoadM.CodeRule & "' and  SNDistributionID='" & Me.SNDistributionID & "'  ")
                SqlStr.Append(vbNewLine & " UPDATE m_SnDistributionStyle_t SET MaxInt=" & LoadD.CurrMaxInt & ", MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' WHERE FactoryID='" & VbCommClass.VbCommClass.Factory & "' AND StyleID='" & LoadD.StyleID & "' and  SNDistributionID='" & Me.SNDistributionID & "'  ")
            Else
                SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & LoadD.StyleID & "'")

            End If

            SqlStr.Append(vbNewLine & "update m_Mainmo_t set PkgPrtqty=isnull(PkgPrtqty,0)+" & CurrNum & "  where Moid='" & LoadD.CurrMoid & "'")

            SqlStr.Append(vbNewLine & "insert into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
                                         " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & Me.CboLine.Text.Trim & "','C','" & LoadD.StyleID & "'," & PackMethod & "," & LoadD.CurrPrintNum & ",'" & CurrSBCode.ToString & "','" & CDate(Me.LblPrintDate.Text.ToString).ToString("yyyy-MM-dd").ToString & "','" & SysMessageClass.UseId.ToLower & "',getdate())")
            SqlStr.Append(vbNewLine & BarValueStr.ToString())
            If VbCommClass.VbCommClass.Factory = "LX53" Then
                SqlStr.Append(vbNewLine & " update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & txtPrintCount.Text & " where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
            Else
                '2016-09-21     马锋      CurrNum更改为txtPrintCount.Text，CurrNum是打印张数
                If Me.chkTestPrint.Checked Then
                    SqlStr.Append(vbNewLine & " update m_SnAssign_t set FinishTestPrintQty=isnull(FinishTestPrintQty,0)+" & CurrNum)
                    If strPrintVer <> "" Then
                        SqlStr.Append(",PrintVer='" + strPrintVer + "'")
                    End If
                    SqlStr.Append(" where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
                Else
                    SqlStr.Append(vbNewLine & " update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & strPrintNumber * strConfigurationQty & ", PrintNumber = ISNULL(PrintNumber,0) + " & CurrNum)
                    If strPrintVer <> "" Then
                        SqlStr.Append(",PrintVer='" + strPrintVer + "'")
                    End If
                    SqlStr.Append(" where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
                End If

            End If

            SqlStr.Append(vbNewLine & "update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID & "'")
            'LK5MF052-CS-R  
            SqlStr.Append(vbNewLine & "DECLARE @PrinteQuantity FLOAT, @NotPrinteQuantity FLOAT, @CustomerOrderDetailID VARCHAR(32), @PRDimensions VARCHAR(32) ")
            SqlStr.Append(vbNewLine & "SET @PrinteQuantity = '" & txtPrintCount.Text & "' SET @PRDimensions = '" & Microsoft.VisualBasic.Left(LoadD.StyleID, Microsoft.VisualBasic.Len(LoadD.StyleID) - 4) & "' ")
            SqlStr.Append(vbNewLine & "IF EXISTS(SELECT 1 FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND PRDimensions = @PRDimensions AND ISNULL(FNSKU,'') = '' AND (ExportQuantity - PrinteQuantity) > 0)  ")
            SqlStr.Append(vbNewLine & "BEGIN WHILE(@PrinteQuantity > 0) BEGIN ")
            SqlStr.Append(vbNewLine & "IF EXISTS(SELECT 1 FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND PRDimensions = @PRDimensions AND ISNULL(FNSKU,'') = '' AND (ExportQuantity - PrinteQuantity) > 0)  ")
            SqlStr.Append(vbNewLine & "BEGIN SELECT TOP 1 @CustomerOrderDetailID = CustomerOrderDetailID, @NotPrinteQuantity = ExportQuantity - PrinteQuantity  ")
            SqlStr.Append(vbNewLine & "FROM m_CustomerOrderDetail_t WHERE PartId = '" & PrintData.Cells("PartId").Value.ToString & "' AND PRDimensions = @PRDimensions AND ISNULL(FNSKU,'') = '' AND (ExportQuantity - PrinteQuantity) > 0 ORDER BY CreateTime ASC  ")
            SqlStr.Append(vbNewLine & "	IF (@PrinteQuantity > @NotPrinteQuantity) BEGIN	UPDATE m_CustomerOrderDetail_t SET PrinteQuantity = PrinteQuantity + @NotPrinteQuantity WHERE CustomerOrderDetailID = @CustomerOrderDetailID  ")
            SqlStr.Append(vbNewLine & " SET @PrinteQuantity = @PrinteQuantity - @NotPrinteQuantity End ELSE BEGIN  ")
            SqlStr.Append(vbNewLine & "UPDATE m_CustomerOrderDetail_t SET PrinteQuantity = PrinteQuantity + @PrinteQuantity WHERE CustomerOrderDetailID = @CustomerOrderDetailID  ")
            SqlStr.Append(vbNewLine & "SET @PrinteQuantity = 0 End End ELSE BEGIN SET @PrinteQuantity = 0 End End End ")

            SqlStr.Append(vbNewLine & SetUnLockSnStyle())
            'Me.LblYN.Text = CurrNum & "/" & LoadD.CurrPrintNum
            'If UseY = "Y" Then '
            '    MoidPrinted += LoadD.CurrPrintNum
            '    CtPrtingNum -= LoadD.CurrPrintNum
            '    Me.LblMoidOkNum.Text = MoidPrinted & " Box"
            '    Me.LblCartonPrintNum.Text = CtPrtingNum & " Box"
            'End If
            '插入數據庫並傳送打印指令到打印機

            BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
            File.WriteAllText("C:\Program Files\默认公司名称" & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            If SqlStr.ToString() <> "" Then
                If strTestPrt <> "Y" Then
                    DbOperateUtils.ExecSQL(SqlStr.ToString)
                End If
                FileToBarCodePrint(pFilePath, PrintData.Cells("PrinterName").Value.ToString)
            End If
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildCBarCode", "sys")
            Throw ex
        Finally
            LoadM.OpenLock(LoadD.StyleID)
            If (LoadM.DistributionFlag = "Y") Then
                LoadM.OpenDistributionLock(LoadD.StyleID.Replace("'", "''"), VbCommClass.VbCommClass.Factory, Me.SNDistributionID)
            End If
        End Try
    End Function

    ''码元值生成至数据库，供exce调用
    Private Sub PModlePrintGenRecord()
        Dim I As Int16
        Dim Areaid As String
        Dim Dtable As DataTable
        Dim FixStr As String = " INSERT INTO [m_BarRecordValue_t]" & _
                      "([PackId],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                     ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                     ",[label23],[label24],label25,label26,label27,label28,label29) " & _
                      "VALUES('P','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',getdate(),"
        Dim nPrintStr = New StringBuilder()
        Try
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString
                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        'PrintStr.Append(CommandStr)
                        For I = 0 To TempView.Count - 1
                            'nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)

                            If I = 0 Then
                                If (I > 0) Then
                                    nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                Else
                                    nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                End If
                            Else
                                nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                            End If
                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 7).ToLower = "barcode" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barcode1" Then
                            Dim strcode As String = PrintPart(1, 1)
                            If strTestPrt = "Y" Then
                                strcode = ReplaceTestBarcode(strcode)
                            End If
                            If PrintStr.ToString = "" Then
                                nPrintStr.Append(strcode)
                            Else
                                nPrintStr.Append(vbNewLine & "~#" & strcode)
                            End If
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barlabel1" Then
                            Dim strcode As String = PrintPart(2, 1)
                            If strTestPrt = "Y" Then
                                strcode = ReplaceTestBarcode(strcode)
                            End If
                            nPrintStr.Append(vbNewLine & strcode)
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If
                End Using

            Next

            ''''''''''''''''''组成标签元素值SQL语句及TXT数据源
            Dim sArray As String() = System.Text.RegularExpressions.Regex.Split(nPrintStr.ToString(), Microsoft.VisualBasic.Constants.vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim StrLen As Integer = sArray.Length
            BarValueStr.Append(FixStr)
            If BarFile.ToString() <> "" Then
                BarFile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            End If
            Dim Index As Integer = 0
            For Each ifalg As String In sArray
                'if (BarValueStr.ToString() == "")
                '{
                '    BarFile.Append("\"" + i.ToString() + "\"");
                '    BarValueStr.Append("," + "'" + i.ToString() + "'");
                '}
                'else
                '{

                If Index = 0 Then
                    BarFile.Append("""" & ifalg.ToString() & """")
                    BarValueStr.Append("'" & ifalg.ToString() & "'")
                Else
                    BarFile.Append(",""" & ifalg.ToString() & """")
                    BarValueStr.Append("," & "'" & ifalg.ToString() & "'")
                End If

                '}

                Index = Index + 1
            Next
            Dim SpaceStr As String = ","
            For j As Int16 = 1 To 21 - StrLen - 1
                SpaceStr = SpaceStr & "'',"
            Next
            SpaceStr = SpaceStr & "'')"
            BarValueStr.Append(SpaceStr)

            Dtable = Nothing
        Catch ex As Exception
            Dtable = Nothing
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "PModlePrintGenRecord", "sys")
            Throw ex
        End Try

    End Sub
#End Region
#End Region


    Private Sub dgvPrintList_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPrintList.CellLeave
        dgvPrintList.EndEdit()
        TxtDriFlag.Clear()
        TxtBuildAttribute.Clear()
    End Sub
    '获取分段流水号信息
    Private Sub GetSnDistributionCount(ByVal strPartId As String, ByVal strCoderuleId As String)
        Try
            Me.SNDistributionCount = 0
            LoadM.SnDistributionCount = 0
            Me.SNDistributionID = ""

            Dim sbSql As New StringBuilder
            Dim ds As New DataSet
            sbSql.Append("SELECT COUNT(1) as ItemCount FROM m_SNDistribution_t  WHERE FactoryID='" & VbCommClass.VbCommClass.Factory & "' and  PartId='" & strPartId & "' AND CodeRuleId = '" & strCoderuleId & "' ;")
            sbSql.Append(" SELECT   MinInt,MinSN, MaxInt, MaxSN, PrintInt, PrintSN,SNDistributionID,FactoryID FROM m_SNDistribution_t  WHERE PartId='" & strPartId & "' AND CodeRuleId = '" & strCoderuleId & "' order by  MaxInt asc;")
            ds = DbOperateUtils.GetDataSet(sbSql.ToString)
            If Not ds Is Nothing Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.SNDistributionCount = CInt(ds.Tables(0).Rows(0)!ItemCount.ToString)

                End If
                If ds.Tables(1).Rows.Count > 0 Then
                    LoadM.SnDistributionCount = ds.Tables(1).Rows.Count
                    '设置流水号区间数组
                    LoadM.SetSnDistributionArr(Me.SNDistributionArr, ds.Tables(1))
                    '仅设置了一个号段
                    If Me.SNDistributionCount = 1 Then
                        Dim drDis() As DataRow
                        drDis = ds.Tables(1).Select("FactoryID='" & VbCommClass.VbCommClass.Factory & "'")
                        If drDis.Length > 0 Then
                            Me.SNDistributionID = drDis(0).Item("SNDistributionID").ToString
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "GetSnDistributionCount", "sys")
            Throw ex
        End Try
    End Sub

    Private Sub GetPrintInfo(ByVal strMOid As String, ByVal strPartId As String, ByVal strPackid As String, ByVal strPactItem As String)
        Dim sql As String = "SELECT SUM(PRTQTY) QTY FROM m_SnAssign_t WHERE MOID='" & strMOid & "' AND PACKID='" & strPackid & "' GROUP BY MOID"
        Try
            Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    TxtDriFlag.Text = "工单申请了" + dt.Rows(0)("qty").ToString
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub


    Private Sub FormatMantissaWeight(ByVal missingQty As Integer, ByVal row As DataGridViewRow)
        Try
            If (Not BarCodePartTable Is Nothing) And VbCommClass.VbCommClass.Factory = "LX53" Then
                For I As Int16 = 0 To BarCodePartTable.Rows.Count - 1
                    If BarCodePartTable.Rows(I).Item("DResource").ToString <> "" AndAlso BarCodePartTable.Rows(I).Item("DResource").ToString = "PartSet" Then
                        If (BarCodePartTable.Rows(I).Item("F_codeID").ToString() = "MW") OrElse (BarCodePartTable.Rows(I).Item("F_codeID").ToString() = "JW") Then
                            BarCodePartTable.Rows(I).Item("ShortName") = Math.Round(((BarCodePartTable.Rows(I).Item("ShortName") / CInt(row.Cells("PackingQty").Value.ToString)) * missingQty), 2)
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "FormatMantissaWeight", "sys")
            Throw ex
        End Try
    End Sub

    Private Sub InitJxPar()
        If VbCommClass.VbCommClass.Factory = "LX53" Then
            GetLotPrintList(Me.dgvLotList.Item("Colmoid", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim, Me.dgvLotList.Item("ColPartId", Me.dgvLotList.CurrentRow.Index).Value.ToString.Trim, "", True)
        End If
    End Sub

    Private Function GetJxSql()
        Dim moids As String = Nothing

        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtMOId.Text) Then
            moids = "'" & txtMOId.Text & "'"
        Else
            sql = "SELECT DISTINCT A.MOID FROM m_SnAssign_t A JOIN M_MAINMO_T B ON A.MOID=B.MOID WHERE A.ESTATEID NOT IN(3,4) AND PRTQTY>FINISHPRINTQTY AND INTIME BETWEEN CAST('" & Me.dtpEndDate.Value.ToString("yyyy/MM/dd") + " 00:00:00" & "' as datetime) and cast('" & Me.dtpStartDate.Value.ToString("yyyy/MM/dd") + " 23:59:59" & "' as datetime) AND B.Factory=N'" & VbCommClass.VbCommClass.Factory & "' and B.profitcenter=N'" & VbCommClass.VbCommClass.profitcenter & "' "
            Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        moids &= "'" & dr("MOID") & "',"
                    Next
                End If
            End Using
        End If


        If Not String.IsNullOrEmpty(moids) Then
            moids = moids.Trim(",")
            sql = " SELECT Moid,PartID,Moqty,ISNULL(Ppidprtqty,0) AS Ppidprtqty, ISNULL(PpidprtCount,0) AS PpidprtCount,ISNULL(Pkgprtqty,0) AS Pkgprtqty, " & vbNewLine
            sql &= " m_Dept_t.DQC, m_Mainmo_t.Lineid,m_Mainmo_t.CHECKTEXT, CONVERT(VARCHAR(10),m_Mainmo_t.Plandate,120) AS Plandate, m_Customer_t.CusName, Createuser, Createtime, m_Mainmo_t.Remark, " & vbNewLine
            sql &= " m_Mainmo_t.DemandInfo, CONVERT(VARCHAR(10),m_Mainmo_t.demandTime,120) AS demandTime, BlueprintVersion, PackageVersion,PO " & vbNewLine
            sql &= " FROM m_Mainmo_t " & vbNewLine
            sql &= " LEFT JOIN m_Customer_t ON m_Customer_t.CusID=m_Mainmo_t.Cusid " & vbNewLine
            sql &= " LEFT JOIN m_Dept_t ON m_Dept_t.deptid=m_Mainmo_t.Deptid " & vbNewLine
            sql &= " WHERE m_Mainmo_t.Factory=N'" & VbCommClass.VbCommClass.Factory & "' and m_Mainmo_t.profitcenter=N'" & VbCommClass.VbCommClass.profitcenter & "' " & vbNewLine
            sql &= " AND m_Mainmo_t.Moid=m_Mainmo_t.ParentMo AND M_MAINMO_T.MOID IN(" & moids & ")"
            If Not String.IsNullOrEmpty(Me.TxtPartid.Text.Trim) Then
                sql += sql & vbNewLine & " and m_Mainmo_t.partid like '%" & Me.TxtPartid.Text.ToString.Trim & "%'"
            End If
            sql += " ORDER BY m_Mainmo_t.Createtime DESC"
            Return sql
        Else
            Return Nothing
        End If
    End Function
    Private Sub ToolTestPrt_Click(sender As Object, e As EventArgs) Handles ToolTestPrt.Click
        Me.strTestPrt = "Y"
        Me.ToolPrt.Enabled = False
        Me.IsmullitStyle = "N"
        Me.dgvPrintList.EndEdit()
        '号段ID
        Me.SNDistributionID = Nothing
        Dim iFirstSelectedRowIndex As Integer = -1


        '20200626 田玉琳 判断如果没有权限下载退出
        If IsHaveProfitAuth(2) = False Then
            Exit Sub
        End If


        If (MessageBox.Show("本次打印数量:" & Me.txtPrintCount.Text & ",是否开始打印?", "打印确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.No) Then
            Me.ToolPrt.Enabled = True
            Exit Sub
        End If

        Try
            Me.lblMessage.Text = String.Empty
            If dgvPrintList.RowCount > 0 Then
                Dim ChkCount As Integer = 0

                If (CheckPrint(Me.dgvPrintList)) Then

                    If IsConSap = "N" Then
                        Dim strErrorMessage As String = ""
                        If (Not CheckVersion(Me.dgvLotList.Rows(Me.dgvLotList.CurrentRow.Index).Cells("ColPartid").Value.ToString, strErrorMessage)) Then
                            If (MessageBox.Show(strErrorMessage, "PLM版本检查", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) =
                                    Windows.Forms.DialogResult.Cancel) Then
                                Me.ToolPrt.Enabled = True
                                Exit Sub
                            End If
                        End If
                    Else

                    End If

                    Dim index As Integer
                    Dim chkTemp As DataGridViewCheckBoxCell

                    For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                        chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                            iFirstSelectedRowIndex = i
                            Exit For
                        End If
                    Next
                    strPrintNumber = Me.txtPrintCount.Text.Trim
                    For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
                        chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
                        If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then

                            'hs ke 验证是否需要卡控数量，是否需要执行标签补数 2017-12-8
                            Dim strTeskId As String = dgvPrintList.Rows(i).Cells("PtaskId").Value.ToString
                            Dim strMOID As String = dgvPrintList.Rows(i).Cells("Moid").Value.ToString
                            Dim strPartid As String = dgvPrintList.Rows(i).Cells("PartId").Value.ToString
                            Dim strPackId As String = Microsoft.VisualBasic.Left(dgvPrintList.Rows(i).Cells("lableType").Value.ToString, 1)
                            Dim strlableType As String = dgvPrintList.Rows(i).Cells("lableType").Value.ToString
                            Dim strDisorderType As String = dgvPrintList.Rows(i).Cells("DisorderType").Value.ToString
                            Dim strPackItem As String = dgvPrintList.Rows(i).Cells("PackItem").Value.ToString
                            'Dim strVersion As String = dgvPrintList.Rows(i).Cells("Remark").Value.ToString
                            Dim strVersionType As String = dgvPrintList.Rows(i).Cells("VersionTypeText").Value.ToString.Trim.Split("-")(0)
                            If IsPrintLock() Then
                                '測試打印不檢查
                                ' If Me.dgvLotList.Rows(Me.dgvLotList.CurrentRow.Index).Cells("CusName").Value.ToString = "华为" AndAlso _
                                '(strPackId = "S" Or strPackId = "C" Or strPackId = "N") Then

                                '     If (Not CheckPrintQty(strTeskId, strMOID, strPackId, strPackItem, strDisorderType)) Then

                                '         Dim dt As DataTable = GetApplyAddPrintDt(strTeskId, strPackId, strPackItem)
                                '         If dt.Rows.Count > 0 Then

                                '             If (MessageBox.Show("第" + (i + 1).ToString + "行" & strlableType & ",打印数量已超过需求数量，已有补数申请单，是否执行补数标签打印:" & Me.txtPrintCount.Text & "?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.Yes) Then
                                '                 Dim FrmSelAdd As New FrmSelAddPrtInfo
                                '                 FrmSelAdd.AppDt = dt
                                '                 FrmSelAdd.ShowDialog()
                                '                 If FrmSelAdd.IsFlag Then
                                '                     Dim arr As String() = FrmSelAdd.SelApList.Split("-")
                                '                     m_AddApplyList = arr(0).ToString
                                '                     m_AddPrtQty = arr(1).ToString
                                '                     If (CInt(Me.txtPrintCount.Text.Trim) > CInt(m_AddPrtQty)) Then
                                '                         SetMessage("第" + (i + 1).ToString + "行" & strlableType & ",打印数量已超过需求数量,执行补数标签打印，补数需求数量为：" & m_AddPrtQty & ",当前打印数量已超出")
                                '                         m_AddPrtCheck = False
                                '                         '  Return False
                                '                         Exit For
                                '                     Else
                                '                         m_AddPrtCheck = True
                                '                         SetMessage("第" + (i + 1).ToString + "行" & strlableType & "，执行补数标签打印,数量为" & txtPrintCount.Text.Trim)
                                '                         'Return False
                                '                         'Exit For
                                '                     End If
                                '                 Else
                                '                     m_AddPrtCheck = False
                                '                     '   Return False
                                '                     Exit For
                                '                 End If
                                '             Else
                                '                 SetMessage("第" + (i + 1).ToString + "行" & strlableType & "打印数量已超过需求数量!不允许打印")
                                '                 '  Return False
                                '                 Exit For
                                '             End If


                                '         Else
                                '             SetMessage("第" + (i + 1).ToString + "行" & strlableType & "打印数量已超过需求数量!")
                                '             '    Return False
                                '             Exit For
                                '         End If

                                '     End If
                                ' End If
                            End If
                            'hs ke 验证是否需要卡控数量，是否需要执行标签补数 2017-12-8


                            If Me.chkConfirm.Checked = True AndAlso i > iFirstSelectedRowIndex Then
                                If (MessageBox.Show("继续下一个标签打印", "标签确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.Yes) Then
                                    PrintBarCode(dgvPrintList.Rows(i), i + 1)
                                Else
                                    Application.DoEvents()
                                End If
                            Else
                                TxtTaskDesc.Text = "当前抛出" & txtPrintCount.Text & " PCS"
                                PrintBarCode(dgvPrintList.Rows(i), i + 1)
                            End If
                        End If
                    Next
                    If chkGetCodeNoPrint.Checked = False Then 'By 田玉琳 20151210 Update
                        index = dgvLotList.CurrentCell.RowIndex
                        DbOperateUtils.ExecSQL("UPDATE M_MAINMO_T SET CHECKTEXT=N'打印完成' where MOID='" & Me.dgvLotList.Rows(index).Cells("Colmoid").Value.ToString & "'")
                    End If
                    If VbCommClass.VbCommClass.Factory = "LX53" Then
                        InitJxPar()
                        Me.ToolPrt.Enabled = True
                        Exit Sub
                    End If
                Else
                    Me.ToolPrt.Enabled = True
                    Exit Sub
                End If
            Else
                SetMessage("没有任何可供打印行!")
            End If

            GetLot()
        Catch ex As Exception
            SetMessage(ex.ToString())
        End Try
        Me.ToolPrt.Enabled = True
    End Sub

    Private Function ReplaceTestBarcode(ByVal strbaroce As String) As String
        Dim newcode As String = String.Empty
        If strbaroce.Length > 4 Then
            newcode = strbaroce.Replace(strbaroce.Substring(0, 4), "TEST")
        Else
            For Each code As String In strbaroce
                newcode = newcode + "T"
            Next
        End If
        Return newcode
    End Function

    '检查是否可以强制解锁
    Private Function CheckAllowUnLock(ByVal StyleId As String) As Boolean
        Dim b As Boolean = True
        Dim sb As New StringBuilder
        Dim ds As New DataSet
        sb.Append(" SELECT * FROM m_SnStyle_t where StyleID='" & StyleId & "' and IsUsed='Y' and  DATEDIFF(MI,Intime,getdate())<=3 ;")
        sb.Append("   select * from m_SnDistributionStyle_t where StyleID='" & StyleId & "' and IsUsed='Y' and  DATEDIFF(MI,Intime,getdate())<=3 ")
        ds = DbOperateUtils.GetDataSet(sb.ToString)
        If Not ds Is Nothing Then
            If Not ds.Tables(0) Is Nothing And ds.Tables(0).Rows.Count > 0 Then
                b = False
            End If
            If Not ds.Tables(1) Is Nothing And ds.Tables(1).Rows.Count > 0 Then
                b = False
            End If
        End If
        Return b
    End Function

    Private Sub ToolInPortTxt_Click(sender As Object, e As EventArgs) Handles ToolInPortTxt.Click
        Dim j As Int16 = 0
        Dim chkTemp As DataGridViewCheckBoxCell
        Dim strPartid As String = ""
        Dim strPackId As String = ""
        Dim strPackItem As String = ""
        For i As Int16 = 0 To Me.dgvPrintList.RowCount - 1
            chkTemp = dgvPrintList.Rows(i).Cells("ChkSelect")
            If (Not chkTemp Is Nothing AndAlso chkTemp.EditedFormattedValue = True) Then
                j = j + 1
                If j > 1 Then
                    SetMessage("只能选择一行!")
                    Exit Sub
                End If
                strPartid = dgvPrintList.Rows(i).Cells("PartId").Value.ToString
                strPackItem = dgvPrintList.Rows(i).Cells("PackItem").Value.ToString
                strPackId = Microsoft.VisualBasic.Left(dgvPrintList.Rows(i).Cells("lableType").Value.ToString, 1)
            End If
        Next
        Dim listtemp As FrmListTemplate = New FrmListTemplate(strPartid, strPackItem, strPackId)
        listtemp.ShowDialog()
    End Sub

    Private Sub CheckEcnChange()
        Dim partid As String = Me.dgvLotList.Rows(Me.dgvLotList.CurrentRow.Index).Cells("ColPartid").Value.ToString

        Dim strSQL As String = "SELECT ecnstate,EcnChangePO  FROM m_PartContrastExtend_t WHERE tavcpart = pavcpart AND  pavcpart= '{0}' AND factory = '{1}'"

        strSQL = String.Format(strSQL, partid, VbCommClass.VbCommClass.Factory)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count > 0) Then
            Dim ecnstate As String = dt.Rows(0)(0).ToString
            If ecnstate = "Y" Then
                Dim frm As New FrmSelEcnChangeRemind
                frm.partId = partid

                frm.ShowDialog()
            End If
        End If
    End Sub



    Private Sub mtxtMOid_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMOid.ButtonCustomClick
        Try
            Dim frmLineMOQuery As New FrmLineMOQuery(Me.mtxtMOid, "")
            'Dim frmMOQuery As New FrmMOQuery(Me.mtxtMOid, Me.CboSupport.Text.Split("(")(0))
            frmLineMOQuery.ShowDialog()
            Me.txtMOId.Text = Me.mtxtMOid.Text

        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub
End Class
