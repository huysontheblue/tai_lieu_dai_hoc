Imports MainFrame
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Drawing

Public Class FrmPrintRepairBar
    Dim pFilePath As String = ""
    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Public printerName As String
    Dim BarValueStr As New StringBuilder()
    Dim LoadM As New BarCodePrint.SqlClassM
    Dim SBCodeLEN As Int16        '流水號的長度，也是數組的變量
    Dim SBCodeUnit(,) As String       '建立條碼流水號所用到的碼制信息數組
    Public LoadD As New SqlClassD      '定義子資源對象
    Dim CurrCodeUnitTable As New DataTable   '定義馬元資源表
    Dim PrintStr As New StringBuilder     '建立條碼打印字符串
    Dim PrintPart(,) As String    '建立打印字符串來源信息數組
    Dim CurrSeriNo As String
    Dim AxTempCode As New StringBuilder
    Dim LblTempCode As New StringBuilder
    Dim MoidPrinted As Int64 = 0      '工單已打印數量
    Dim BarFile As New StringBuilder()
    Private SNDistributionID As String = String.Empty ' 号段ID(黄广都 2017-04-24)
    Private SNDistributionCount As Int16 = 0 ' 厂区号段设置总数(黄广都 2017-04-24)
    Dim SNDistributionArr(,) As String       '厂区分段流水号区间数组
    Dim strTestPrt As String = "N"
    Dim PrtArray As New MainFrame.SysCheckData.SysMessageClass.PrtStructure
    Dim Mreader As DataTable ' 田玉琳 20170407
    Private strPrintNumber As String = "0"
    Dim BarCodePartTable As New DataTable
    Dim PubAtrributeStype As String = "" '附属条码的样式
    Dim YMDCode As New StringBuilder
    Dim Sqlstr As New StringBuilder

#Region "包装"
    Dim MoidAllNum As Int64 = 0         '工單批量
    Dim MoidLastNum As Int64            '工單尾數量
    Dim CtPrtingNum As Int64            '工單可打印箱數
    Dim PackMethod As Int16 = 0         '裝箱數量
    Dim Packlink As String = ""         '箱標簽類型
    Dim PackItems As String = ""         '条码类型
#End Region

    Private Sub txtPrintQty_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtPrintQty.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Convert.ToInt16(e.KeyChar) <> 8 AndAlso Convert.ToInt16(e.KeyChar) <> 1 AndAlso Convert.ToInt16(e.KeyChar) <> 3 AndAlso Convert.ToInt16(e.KeyChar) <> 22 Then
            e.Handled = True
        End If
    End Sub

    Private Sub FrmPrintRepairBar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SqlClassM.GetPrintersList(CboPrinter)
        btApp = New BarTender.ApplicationClass
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim i As Integer = 0
        Dim sqlStr As String = String.Empty

        If String.IsNullOrEmpty(Me.txtPrintQty.Text.Trim) Then
            ' Me.lblMsg.Text = "NG,打印数量不能为空！"
            SetMessage("Fail", "NG,打印数量不能为空！")
            Exit Sub
        End If

        If String.IsNullOrEmpty(CboPrinter.Text.Trim) Then
            ' Me.lblMsg.Text = "NG,请先选择打印机！"
            SetMessage("Fail", "NG,请先选择打印机！")
            Exit Sub
        End If
        '
        AutoApplyTask()

        PrintBarCode(dgvPrintList.Rows(i), i + 1)

    End Sub

    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            'LabResult.Text = "FAIL"
            lblMsg.Text = message
            ' LabResult.ForeColor = Color.Crimson
            lblMsg.ForeColor = Color.Crimson
        Else
            'LabResult.Text = "PASS"
            lblMsg.Text = message
            'LabResult.ForeColor = Color.FromArgb(0, 192, 0)
            lblMsg.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub


    Private Sub AutoApplyTask()
        Dim sqlstr As New StringBuilder
        Dim o_Shift As String
        Dim RecTable As New DataTable
        Dim o_Ptaskid As String = String.Empty
        Dim o_strTaskDesc As String = "Repair auto apply" ' Me.TxtTaskDesc.Text.ToString.Trim
        Dim o_strLineId As String = "XTNG1"    'Me.CboLineid1.Text.Trim.ToUpper
        Dim o_strMoid As String = "NGMO"    'Me.TxtMoid1.Text.Trim
        'Me.TxtPPIDqty.Text.ToString.Trim
        Dim o_strFileVerNo As String = "A"
        Dim o_strDriFlag As String = "N"
        Dim o_strBuildAttribute As String = "N"
        Dim o_strPackItem As String = "S" 'Me.CboPackItem.SelectedValue.ToString.Trim
        Dim o_strExtended1 As String = "N", o_strExtended2 = "N", o_strExtended3 = "N"  'DPrtTestQty
        Dim o_strPnLable As String = ""
        Dim PrintName As String = Me.CboPrinter.Text.Trim
        Dim o_strDisorderType As String = ""

        sqlstr.Append("declare @Taskid varchar(11) declare @Taskid1 varchar(11)")
        'If Me.ChkPPID.Checked Then

        '獲得申請單號
        sqlstr.Append(" select @Taskid=Ptaskid from m_SnAssign_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " _
                    & " if @@rowcount=0 begin set @Taskid='T' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " _
                    & " set @Taskid=left(@Taskid,7) + right(Replicate('0',4) + cast(right(@Taskid,4)+1 as varchar),4) End ")
        'insert 語句
        o_Shift = "D"  'IIf(Me.ComShift.SelectedIndex = 0, "D", "N")

        sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,Extended1,Extended2,Extended3,LABELPN, PrtTestQty) " _
                & " values(@Taskid,'" & o_strLineId & "','" & o_strMoid & "','S'," & Int(Me.txtPrintQty.Text.ToString.Trim) _
                & ",cast('" & Me.DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & o_strTaskDesc & "'," _
                & "'" & o_Shift & "','" & o_strFileVerNo & "','" & o_strDriFlag & "','" & o_strBuildAttribute & "',1," _
                & "'" & o_strExtended1 & "','" & o_strExtended2 & "','" & o_strExtended3 & "','" & o_strPnLable & "', '0')")
        '返回申請單號
        sqlstr.Append(ControlChars.CrLf & "select @Taskid as Taskid0")
        RecTable = DbOperateUtils.GetDataTable(sqlstr.ToString)
        If Not IsNothing(RecTable) AndAlso RecTable.Rows.Count > 0 Then
            o_Ptaskid = RecTable.Rows(0).Item("Taskid0")
        End If

        GetLotPrintList(o_strMoid, "NGPN", Val(txtPrintQty.Text), True, o_Ptaskid)

    End Sub

    '取得工单打印清单
    Private Sub GetLotPrintList(ByVal strMOid As String, ByVal strPartId As String, ByVal strQty As String,
                                ByVal QueryFlag As Boolean, ByVal o_Ptaskid As String)

        Sqlstr.Remove(0, Sqlstr.Length)

        Sqlstr.Append(" SELECT DISTINCT m_SnAssign_t.Ptaskid,m_Mainmo_t.Moid, m_PartContrast_t.TAvcPart, m_PartContrast_t.PAvcPart, ")
        Sqlstr.Append(" m_Sortset_t.SortID + '-' + m_Sortset_t.SortName as LabelType, m_SnAssign_t.Packitem,ChildDisorderType.SortID + '-' + ChildDisorderType.SortName as DisorderType, ")
        Sqlstr.Append(" m_Mainmo_t.Moqty AS Qty,m_SnAssign_t.PrtQty*ISNULL(m_SnAssign_t.ConfigurationQty,1) PrintQty, ISNULL(m_SnAssign_t.FinishPrintQty,0) AS FinishPrintQty,ISNULL(m_SnAssign_t.ConfigurationQty,1) AS ConfigurationQty, m_PartPack_t.PrinterName, ")
        Sqlstr.Append(" case m_partpack_t.Packid when 'S' then '' else case m_partpack_t.Multiy when 'Y' then m_partpack_t.MultiQty when 'N' then m_partpack_t.Qty end end as PackingQty, ")
        Sqlstr.Append(" m_SnPFormat_t.KLabelid, m_PartPack_t.Description,'' PrintStatus, ")
        Sqlstr.Append(" djmdc,shift,linejm,convert(varchar(10),m_SnAssign_t.Demandtime,120) as Demandtime,(FileVerNo + iif(isnull(m_SnAssign_t.Remark,'')='','','#'+ m_SnAssign_t.Remark ))FileVerNo,m_PartPack_t.Remark,DriFlag,BuildAttribute, case m_SnAssign_t.Estateid when '1' then '1-待打印' when '2' then '2-打印中' when '3' then '3-被驳回' when '4' then '4-被作废' when '5' then '5-待領取' when '6' then '6-已完成' end as Estateid,")
        Sqlstr.Append(" ISNULL(m_PartPack_t.PackingLevel,'0') AS PackingLevel, m_Mainmo_t.PartID as applyPart, ISNULL(m_PartPack_t.VersionType, '0') + '-' + PartVersionType.PARAMETER_NAME AS VersionTypeText,m_SnAssign_t.LABELPN, m_SnAssign_t.PrintNumber,m_PartPack_t.GroupPrintFlag,Userid=m_SnAssign_t.Userid+'/'+usr.UserName,m_SnAssign_t.Intime, m_SnAssign_t.ApplyAddQty, m_SnAssign_t.FinishedAddQty ")
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
        Sqlstr.Append(" WHERE m_Mainmo_t.ParentMo='" & strMOid & "' ")

        '注释掉厂区和利润中心 是为了 所有的 登录方式都能满足，不用在每个厂区和利润中心下建工单等资料
        'AND m_Mainmo_t.Factory='" & VbCommClass.VbCommClass.Factory & "' and m_Mainmo_t.profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'  ")

        Sqlstr.Append(" AND m_SnAssign_t.Ptaskid='" & o_Ptaskid & "' ")
        If VbCommClass.VbCommClass.Factory = "LX53" Then
            Sqlstr.Append(" AND m_SnAssign_t.ESTATEID NOT IN(3,4) ORDER BY m_SnAssign_t.INTIME DESC")
        Else
            Sqlstr.Append(" ORDER BY m_PartContrast_t.TAvcPart ASC")
        End If

        LoadData(Sqlstr.ToString, Me.dgvPrintList)
    End Sub

    '填充数据
    Private Sub LoadData(ByVal Sqlstr As String, ByVal dgvName As DataGridView)
        Dim DReader As DataTable
        Try
            dgvName.Rows.Clear()
            DReader = DbOperateUtils.GetDataTable(Sqlstr)

            'Dim cmbTmp As DataGridViewComboBoxColumn
            Dim FCLNumber As Int32
            Dim TrunkNumber As Int32
            Dim PrintName As String

            'cmbTmp = dgvPrintList.Columns("PrinterName")
            'SqlClassM.GetPrintersList(cmbTmp)

            For index As Integer = 0 To DReader.Rows.Count - 1
                If dgvName Is Nothing Then  'Me.dgvLotList
                    dgvName.Rows.Add(DReader.Rows(index)("Moid").ToString, DReader.Rows(index)("Partid").ToString, DReader.Rows(index)("Moqty").ToString, DReader.Rows(index)("Ppidprtqty").ToString _
                    , DReader.Rows(index)("PpidprtCount").ToString, DReader.Rows(index)("Pkgprtqty").ToString, DReader.Rows(index)("Lineid").ToString, _
                    DReader.Rows(index)("BlueprintVersion").ToString, DReader.Rows(index)("PackageVersion").ToString, DReader.Rows(index)("PO").ToString, _
                    DReader.Rows(index)("CHECKTEXT").ToString, DReader.Rows(index)("DemandInfo").ToString, DReader.Rows(index)("Plandate").ToString _
                    , DReader.Rows(index)("DQC").ToString, DReader.Rows(index)("CusName").ToString, DReader.Rows(index)("demandTime").ToString, DReader.Rows(index)("Createuser").ToString, DReader.Rows(index)("Createtime").ToString, DReader.Rows(index)("Remark").ToString)
                ElseIf dgvName Is Nothing Then  'dgvRuleList
                    dgvName.Rows.Add(DReader.Rows(index)("F_codeID").ToString, DReader.Rows(index)("F_codename").ToString, DReader.Rows(index)("DValues").ToString)
                ElseIf dgvName Is Me.dgvPrintList Then
                    'If (SqlClassM.CheckPrintersList(DReader.Rows(index)("PrinterName").ToString)) Then
                    '    PrintName = DReader.Rows(index)("PrinterName").ToString
                    'Else
                    '    PrintName = ""
                    'End If

                    PrintName = Me.CboPrinter.Text.Trim

                    If (Microsoft.VisualBasic.Left(DReader.Rows(index)("LabelType").ToString, 1) = "C" Or Microsoft.VisualBasic.Left(DReader.Rows(index)("DisorderType").ToString, 1) = "C" Or Microsoft.VisualBasic.Left(DReader.Rows(index)("DisorderType").ToString, 1) = "P") Then
                        If ((CInt(DReader.Rows(index)("PrintQTY").ToString) - CInt(DReader.Rows(index)("FinishPrintQty").ToString)) Mod CInt(DReader.Rows(index)("PackingQty").ToString) = 0) Then
                            FCLNumber = 0 '(CInt(DReader.Rows(index)("PrintQTY").ToString) - CInt(DReader.Rows(index)("FinishPrintQty").ToString)) / CInt(DReader.Rows(index)("PackingQty").ToString)
                            TrunkNumber = 0
                        Else
                            FCLNumber = 0 ' System.Math.Truncate((CInt(DReader.Rows(index)("PrintQTY").ToString) - CInt(DReader.Rows(index)("FinishPrintQty").ToString)) / CInt(DReader.Rows(index)("PackingQty").ToString))
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
                    DReader.Rows(index)("djmdc").ToString, DReader.Rows(index)("shift").ToString, DReader.Rows(index)("linejm").ToString, DReader.Rows(index)("Demandtime").ToString, DReader.Rows(index)("DriFlag").ToString, DReader.Rows(index)("BuildAttribute").ToString, DReader.Rows(index)("Estateid").ToString,
                    DReader.Rows(index)("PackingLevel").ToString,
                    DReader.Rows(index)("applyPart").ToString, DReader.Rows(index)("GroupPrintFlag").ToString)
                    If DReader.Rows(index)("FinishPrintQty").ToString <> "" And DReader.Rows(index)("PrintQTY").ToString <> "" Then
                        If Convert.ToDecimal(DReader.Rows(index)("PrintQTY").ToString) > Convert.ToDecimal(DReader.Rows(index)("FinishPrintQty").ToString) Then
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
            ' Me.ToolLblCount.Text = Me.dgvPrintList.Rows.Count

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "LoadData", "sys")
            Throw ex '出错
        End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="PrintData"></param>
    ''' <param name="rowNum"></param>
    ''' <remarks></remarks>
    Private Sub PrintBarCode(ByVal PrintData As DataGridViewRow, ByVal rowNum As Int16)
        Try
            BarValueStr.Remove(0, BarValueStr.Length)
            ' BarFile.Remove(0, BarFile.Length)
            '配置数
            ' strConfigurationQty = IIf(IsDBNull(PrintData.Cells("ConfigurationQty").Value), "1", PrintData.Cells("ConfigurationQty").Value)

            If (Not PrintData Is Nothing) Then
                If InitializePrintParameter(PrintData) = False Then
                    Exit Sub
                End If

                '打印状态
                If (Microsoft.VisualBasic.Left(PrintData.Cells("Estateid").Value.ToString, 1) = "1") Then
                    DbOperateUtils.ExecSQL("Update m_SnAssign_t set Estateid='2',Printuser='" & SysMessageClass.UseId.ToLower.Trim & "' where Ptaskid='" & PrintData.Cells("PtaskId").Value.ToString & "'")
                End If

                BuildSBarCode(PrintData) '产品条码/ 增加制程条码 K

            Else
                ' SetMessage("获取行" + rowNum.ToString + "打印数据失败!")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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
            LoadM.vIsprint = "Y"     'IIf(Me.ChkNotPrint.Checked, "Y", "N")
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

            PrtArray.NowDate = CDate(Me.DateTimePicker1.Text).ToString("yyyy-MM-dd").ToString
            PrtArray.NowMonth = CDate(Me.DateTimePicker1.Text).ToString("MM").ToString

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

    '數組傳遞參數
    Private Sub SetArrayLbl(ByVal Array() As String)

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


    Private Sub BuildSBarCode(ByVal PrintData As DataGridViewRow)
        Try
            Dim PrinterName As String

            PrinterName = Me.CboPrinter.Text.Trim()        'PrintData.Cells("PrinterName").EditedFormattedValue.ToString
            '**************************分段流水号*********************
            ' Me.SNDistributionCount = 0
            ' Me.SNDistributionID = String.Empty
            LoadM.SnDistributionCount = 0
            'Add by hgd 2017-04-25 获取分段流水号
            'If Not LoadM.CodeRule Is Nothing Then
            '    GetSnDistributionCount(PrintData.Cells("PartId").Value.ToString(), LoadM.CodeRule)
            'End If

            ''********************************************************
            '打印前例行檢查及生成樣式和檢測樣式
            If Checking(PrintData) = False OrElse CheckStyle() = False Then
                Exit Sub
            End If

            MainMarkSCode(PrinterName, PrintData.Cells("PtaskId").Value.ToString, PrintData) '生成序號並打印
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "BuildSBarCode", "sys")
            Throw ex
        End Try
    End Sub

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
        If IsNumeric(Me.txtPrintQty.Text.Trim) Then
            'If (CInt(Me.txtPrintCount.Text.Trim) <= 0) Then
            '    MsgBox("打印数量必须大于0！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            '    Return False
            'End If
            If (Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) = "C" Or Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1) = "C" Or Microsoft.VisualBasic.Left(PrintData.Cells("DisorderType").Value.ToString, 1) = "P") Then

                If ((CInt(Me.txtPrintQty.Text.Trim) Mod CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)) = 0) Then
                    FCLNumber = CInt(Me.txtPrintQty.Text.Trim) / CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)
                    TrunkNumber = 0
                    LoadD.MantissaFlag = False
                Else
                    FCLNumber = Int(CInt(Me.txtPrintQty.Text.Trim) / CInt(PrintData.Cells("PackingQty").Value.ToString.Trim))
                    TrunkNumber = 1
                    LoadD.MantissaFlag = True
                    LoadD.MantissaBoxQty = CInt(Me.txtPrintQty.Text.Trim) Mod CInt(PrintData.Cells("PackingQty").Value.ToString.Trim)
                End If
                LoadD.CurrPrintNum = FCLNumber + TrunkNumber

            Else
                '当前待打印数量=打印数*配置数
                LoadD.CurrPrintNum = CInt(Me.txtPrintQty.Text.Trim) * CInt(PrintData.Cells("ConfigurationQty").Value.ToString.Trim)
                LoadD.MantissaFlag = False
            End If
        Else
            LoadD.CurrPrintNum = 0
            MsgBox("一次打印數量限制在1-1000以內！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Return False
        End If
        Return True
    End Function


    '檢查樣式
    Private Function CheckStyle() As Boolean

        Dim Sqlstr As String
        Dim dvSnDis As New DataView
        'Me.IsMoreShareStyle = "N"

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
            Else
                '顺序打印
                Sqlstr = "select StyleID,MaxInt,MaxSN,ISNULL(IsUsed,'N')IsUsed from m_SnStyle_t where StyleID='" & LoadD.StyleID.ToString.Replace("'", "''") & "'"
                Using RecTable As DataTable = DbOperateUtils.GetDataTable(Sqlstr)

                    If RecTable.Rows.Count > 0 Then
                        If RecTable.Rows(0)("IsUsed").ToString = "N" Then
                            LoadD.BarCodeStyleMax = RecTable.Rows(0)("MaxSN").ToString
                            LoadD.CurrMaxInt = Int(RecTable.Rows(0)("MaxInt").ToString)
                            Sqlstr = "update m_SnStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "'"
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

                        Sqlstr = "insert into m_SnStyle_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) values('" & LoadD.StyleID.Replace("'", "''") & "','" & LoadD.CurrAVCPartID & "','" & LoadM.CodeRule & "','" & LoadD.StyleID.Replace("'", "''") & "'," & LoadD.StartInt & ",'" & LoadD.StartSn & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
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
            'If IsmullitStyle = "Y" Then
            '    LoadM.SetAttributeSBCode(AtrrrCurrSBCode, AtrrSBCodeLEN, AtrrSBCodeUnit, LoadD.AtrrBarCodeStyleMax)
            '    CurrAtrrCodeUnitTable = LoadM.SetCurrCodeUnitTable(AtrrSBCodeLEN, AtrrSBCodeUnit)
            'End If

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
                'If IsmullitStyle = "Y" Then
                '    AtrrCurrSeriNo = ""
                '    AtrrrCurrSBCode = LoadM.AtrriMarkSBCode(AtrrrCurrSBCode, 1, AtrrSBCodeLEN, AtrrSBCodeUnit, CurrAtrrCodeUnitTable)
                '    AtrrCurrSeriNo = AtrrrCurrSBCode.ToString()
                'End If
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




                'LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                If LblTempCode.ToString <> "" Then
                    LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
                    LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                    If LoadD.IsChkLabFlag Then
                        LblTempCode.Remove(LoadD.ChkLblPos, 1)
                        Dim msstring As String = AxTempCode.ToString.Substring(0, 6).ToString
                        Dim CheckValue As String = "" 'GetChkNumber(msstring)
                        If CheckValue <> "" Then
                            LblTempCode.Insert(LoadD.ChkLblPos, CheckValue)
                        Else
                            Exit Function
                        End If
                    End If
                End If
                ''**********************************************
                'If IsmullitStyle = "Y" Then
                '    AtrrAxTempCode.Remove(AtrrCodeLen, AtrrSBCodeLEN)
                '    AtrrAxTempCode.Insert(AtrrCodeLen, AtrrrCurrSBCode.ToString)
                'End If
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
                              SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(DateTimePicker1.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & pFilePath & "','" &
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
                SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & LoadD.StyleID & "'")
            End If

            'If IsmullitStyle = "Y" Then
            '    SqlStr.Append(vbNewLine & "update m_SnStyle_t set MaxInt=" & LoadD.AtrrCurrMaxInt & ",MaxSN='" & LoadD.AtrrBarCodeStyleMax & "',IsUsed='N' where StyleID='" & PubAtrributeStype & "'")
            'End If

            SqlStr.Append(vbNewLine & "update m_Mainmo_t set Ppidprtqty=isnull(Ppidprtqty,0)+" & CurrNum & ",PpidprtCount=PpidprtCount+" & LoadD.CurrPrintNum & "*" & PrtArray.Qty & " where Moid='" & LoadD.CurrMoid & "'")

            SqlStr.Append(vbNewLine & "update m_SnAssign_t set FinishPrintQty=isnull(FinishPrintQty,0)+" & strPrintNumber * 1 & ", PrintNumber = ISNULL(PrintNumber,0) + " & CurrNum)

            'If strPrintVer <> "" Then
            '    SqlStr.Append(",PrintVer='" + strPrintVer + "'")
            'End If

            SqlStr.Append(" where Ptaskid='" & taskId & "'")


            'Modify insert print record, cq 20170310
            SqlStr.Append(vbNewLine & "INSERT INTO m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
                                             " VALUES('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "', '" & Microsoft.VisualBasic.Left(PrintData.Cells("lableType").Value.ToString, 1) & "','" & LoadD.StyleID & "',1," & LoadD.CurrPrintNum & ",'" & StartCode & "~" & CurrSBCode.ToString & "','" & CDate(Me.DateTimePicker1.Text.Trim.ToString).ToString("yyyy-MM-dd") & "','" & SysMessageClass.UseId.ToLower & "',getdate())")

            SqlStr.Append(vbNewLine & BarValueStr.ToString())
            'SqlStr.Append(vbNewLine & "update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID & "'")
            'If IsmullitStyle = "Y" Then
            '    SqlStr.Append(vbNewLine & "update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & PubAtrributeStype & "'")
            'End If
            SqlStr.Append(vbNewLine & SetUnLockSnStyle())
            'SqlStr.Append(vbNewLine & SetPrintEndTime(LoadD.StyleID.Replace("'", "''")))

            BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)


            File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            If SqlStr.ToString() <> "" Then
                If strTestPrt <> "Y" Then '测试扫描不更新
                    DbOperateUtils.ExecSQL(SqlStr.ToString())
                End If
                'If chkGetCodeNoPrint.Checked = False Then 'By 田玉琳 20151210 Update （生成不打印选项)
                FileToBarCodePrint(pFilePath, printName)
                SetMessage("PASS", "打印成功！")
                Me.txtPrintQty.Text = ""

                Try
                    '打印记录，用户追踪打印明细
                    If File.Exists(Application.StartupPath & "\Bartender.txt") Then
                        Dim SetFile As String = Application.StartupPath & "\txt\"
                        Dim datestr As String = Now.ToString("yyyyMMdd").ToString
                        SetFile = SetFile & "\" & datestr & "\"
                        If Not Directory.Exists(SetFile) Then
                            Directory.CreateDirectory(SetFile)
                        End If
                        File.Copy(Application.StartupPath & "\Bartender.txt", SetFile & "\" & DateTime.Now.ToString("HHmmss") & "_" & LoadD.CurrMoid & ".txt", True)
                    End If
                Catch ex As Exception

                End Try
                'End If
            End If


            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "MainMarkSCode", "sys")
            Throw ex
        End Try
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
                            'If strTestPrt = "Y" Then
                            '    strcode = ReplaceTestBarcode(strcode)
                            'End If
                            If PrintStr.ToString = "" Then
                                nPrintStr.Append(strcode)
                            Else
                                nPrintStr.Append(vbNewLine & "~#" & strcode)
                            End If
                            Continue For
                            'Exit Try
                        End If
                        ''************************************ouxiangfeng 20151116********************
                        'If Areaid.ToLower = "barcode2" Then
                        '    Dim strcode As String = AtrrAxTempCode.ToString
                        '    If strTestPrt = "Y" Then
                        '        strcode = ReplaceTestBarcode(strcode)
                        '    End If
                        '    If nPrintStr.ToString = "" Then
                        '        nPrintStr.Append(strcode)
                        '    Else
                        '        nPrintStr.Append(vbNewLine & strcode)
                        '    End If
                        '    Continue For
                        'End If
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
                                'If strTestPrt = "Y" Then
                                '    strcode = ReplaceTestBarcode(strcode)
                                'End If
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


    ''' <summary>
    ''' 解锁打印使用中的样式
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetUnLockSnStyle() As String
        SetUnLockSnStyle =
            " update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "'" & vbNewLine &
            " update m_SnStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & PubAtrributeStype & "'" & vbNewLine &
            " update m_SnDistributionStyle_t set IsUsed='N',Intime=getdate() where StyleID='" & LoadD.StyleID.Replace("'", "''") & "' AND FactoryId='" & VbCommClass.VbCommClass.Factory & "' "
    End Function

    '调用打印机开始打印
    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)
        btFormat = btApp.Formats.Open(VbCommClass.VbCommClass.PrintDataModle & pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

 
End Class