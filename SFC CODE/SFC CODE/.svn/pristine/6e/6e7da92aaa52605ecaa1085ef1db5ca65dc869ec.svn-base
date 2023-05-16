
'--打印申請作業
'--Create by :　Airlo(楊三良)
'--Create date :　/4/14
'--Ver : V01
'--Update by : Nan
'--Update date : 2009/4/14
'--Update Content: 將外箱標簽的整箱和尾箱申請分開

#Region "Imports"

Imports System.Windows.Forms
Imports BarCodePrint.SqlClassM
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports MainFrame

#End Region

Public Class FrmPrtTask

#Region "窗體變量"

    Dim LoadM As New SqlClassM      '定義主資源對象
    Dim opFlag As Int16 = 0
    Dim GSqlstr As New StringBuilder
    Dim Gsqlplace As Int16
    Dim CurrTaskid As String = ""
    Dim LoadLine As String = "" 'hzf 2016-11-17 15:57:42 公共变量防止带不出线别

    '江西厂区代码 Add By KyLinQiu20180129
    Private FactoryOfJX As String = "XINYU;LX53;BSDZ;JIZHOU;LX21;M02600;WANXUN;"

#End Region

#Region "窗體初始化"

    Private Sub FrmPrtTask_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
    '窗體登錄事件
    Private Sub FrmPrtTask_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SysMessageClass.UseId = "sz17690"
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        'modify by paul 20150310 增加制程条码 K
        GSqlstr.Append("select a.Ptaskid,case a.Estateid when '1' then '1-待打印' when '2' then '2-打印中' when '3' then '3-被驳回' when '4' then '4-被作废' when '5' then '5-待領取' when '6' then '6-已完成' end as Estateid," _
                    & " case a.Packid  when 'A' then 'A-附屬條碼標籤' when 'S' then 'S-產品條碼標籤' when 'C' then 'C-外箱條碼標籤' when 'P' then 'P-棧板條碼標簽'  when 'N' then 'N-無流水號標簽' when 'K' then N'K-制程条码' end as LabelType,a.Lineid,a.Moid,b.Partid,h.KLabelid,g.Remark as Labelid,a.prtQty,a.finishprintqty,substring(convert(varchar(16),a.Demandtime,21),6,11) as Demandtime,h.PrinterID,h.PTemperature,h.CarbonTape,h.PFormatID,h.PaperSize," _
                    & " f.Deptid + '-' + f.djc as Deptname,e.Username as Printuser,substring(convert(varchar(16),a.Printtime,21),6,11) as Printtime,c.Username,substring(convert(varchar(16),a.Intime,21),6,11) as Intime,d.Username as Takeuser," _
                    & " substring(convert(varchar(16),a.Taketime,21),6,11) as Taketime,a.Remark,b.factory,djmdc,shift,linejm,FileVerNo,DriFlag,BuildAttribute,Extended1,Extended2,Extended3,LABELPN,a.packitem " _
                    & " from m_SnAssign_t as a join m_Mainmo_t as b on a.Moid=b.Moid and b.Factory='" & VbCommClass.VbCommClass.Factory & "' and b.profitcenter='" & VbCommClass.VbCommClass.profitcenter & "' AND a.Estateid <> '4' left join m_Dept_t as f on b.Deptid=f.Deptid and b.factory=f.factoryid left join m_Users_t as c " _
                    & " on a.userid=c.userid left join m_Users_t as d on a.Takeuser=d.userid left join m_Users_t as e on a.Printuser=e.userid inner join m_PartPack_t as g on b.Partid=g.Partid and a.Packid=g.Packid and a.Packitem=g.Packitem and g.Usey='Y' " _
                    & " left join m_SnPFormat_t as h on g.PFormatID=h.PFormatID and h.UseY='Y' left join Deptline_t j on f.deptid=j.deptid and a.lineid=j.lineid ")
        Gsqlplace = GSqlstr.Length
        If VbCommClass.VbCommClass.Factory = "BZLANTO" Or VbCommClass.VbCommClass.Factory = "CHUZHOU" Then
            LoadM.LoadDataToTSComboBox("select deptid + '-' + djc as deptname from m_Dept_t where dtype='R' and usey='Y' order by deptid", Me.CboDeptname)
            '增加FQC单号等设置 zhenfei.hu  2017-2-27 09:05:22
            Label26.Text = "FQC/工单："
            Label31.Text = "PO/工号："
            Label32.Text = "净重/毛重："
            Label33.Text = "制造/交货日期："
            TxtDriFlag.Text = "NA"
            txtExtended1.Text = "NA"
            txtExtended2.Text = "NA"
            txtExtended3.Text = "NA"

        End If
        Me.CboDeptname.Items.Insert(0, "ALL")
        LoadM.SetSplitContainer(Me.SplitContainer1)
        LoadM.SetSplitContainer(Me.SplitContainer2)
        SetStatus(opFlag)
        init()
        ClearObject()
        ComShift.SelectedIndex = 0
    End Sub
    '加載數據到數據表格
    Private Sub LoadDataToDgrid(ByVal Sqlstr As String, ByRef DGrid As DataGridView)
        Try
            DGrid.Rows.Clear()
            Dim DReader As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            For Each row As DataRow In DReader.Rows
                DGrid.Rows.Add(row.Item("Ptaskid").ToString, row.Item("Estateid").ToString, row.Item("LabelType").ToString, row.Item("Lineid").ToString,
                               row.Item("Moid").ToString, row.Item("Partid").ToString, row.Item("KLabelid").ToString, row.Item("Labelid").ToString,
                               row.Item("prtQty").ToString, row.Item("finishprintqty").ToString, row.Item("Demandtime").ToString, row.Item("PFormatID").ToString,
                               row.Item("PaperSize").ToString, row.Item("Remark").ToString, row.Item("PrinterID").ToString, row.Item("PTemperature").ToString,
                               row.Item("CarbonTape").ToString, row.Item("Deptname").ToString, row.Item("Printuser").ToString, row.Item("Printtime").ToString,
                               row.Item("Username").ToString, row.Item("Intime").ToString, row.Item("Takeuser").ToString, row.Item("Taketime").ToString,
                               row.Item("factory").ToString, row.Item("djmdc").ToString, row.Item("shift").ToString, row.Item("linejm").ToString,
                               row.Item("FileVerNo").ToString, row.Item("DriFlag").ToString, row.Item("BuildAttribute").ToString, row.Item("Extended1").ToString,
                               row.Item("Extended2").ToString, row.Item("Extended3").ToString, row.Item("LABELPN").ToString, row.Item("packitem").ToString)
            Next

            Me.ToolLblCount.Text = DGrid.Rows.Count
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '狀態顯示
    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始
                Me.ToolAddNew.Enabled = IIf(ToolAddNew.Tag.ToString = "YES", True, False)
                Me.ToolEditTask.Enabled = IIf(ToolEditTask.Tag.ToString = "YES", True, False)
                Me.ToolDelTask.Enabled = IIf(ToolDelTask.Tag.ToString = "YES", True, False)
                Me.ToolCommit.Enabled = False
                Me.ToolBack.Enabled = False
                Me.ToolRefresh.Enabled = True
                Me.ToolExcel.Enabled = True
                Me.ToolBTask.Enabled = IIf(ToolBTask.Tag.ToString = "YES", True, False)
                Me.ToolPrt.Enabled = IIf(ToolPrt.Tag.ToString = "YES", True, False)
                Me.ToolFinish.Enabled = IIf(ToolFinish.Tag.ToString = "YES", True, False)
                Me.ToolStopTask.Enabled = IIf(ToolStopTask.Tag.ToString = "YES", True, False)
                Me.ToolExitFrom.Enabled = True

                Me.Timer.Enabled = True
                Me.SplitContainer1.Panel1Collapsed = True
                Me.SplitContainer2.Panel1Collapsed = False
            Case 1, 2    '新增/修改
                Me.ToolAddNew.Enabled = False
                Me.ToolEditTask.Enabled = False
                Me.ToolDelTask.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolBack.Enabled = True
                Me.ToolRefresh.Enabled = False
                Me.ToolExcel.Enabled = False
                Me.ToolBTask.Enabled = False
                Me.ToolPrt.Enabled = False
                Me.ToolFinish.Enabled = False
                Me.ToolStopTask.Enabled = False
                Me.ToolExitFrom.Enabled = True

                Me.Timer.Enabled = False
                Me.SplitContainer1.Panel1Collapsed = False
                Me.SplitContainer2.Panel1Collapsed = True
        End Select
    End Sub

    Private Sub init()

        Me.CboLineid.SelectedIndex = 0
        Me.CboTaskid.SelectedIndex = 0
        Me.CboTaskStatus.SelectedIndex = 0
        Me.CboMoid.SelectedIndex = 0
        Me.CboPartid.SelectedIndex = 0
        Me.CboDeptname.SelectedIndex = 0
        Me.CboLabelType.SelectedIndex = 0
        Me.DtpStarttime.Value = Now.AddDays(-1)
        Me.DtpEndtime.Value = Now.AddDays(1)
        Me.LblRemark.Text = ""

    End Sub

    Private Sub ClearObject()
        Me.TxtMoid1.Text = ""
        Me.TxtPartid1.Text = ""
        Me.CboLineid1.Items.Clear()
        Me.ChkCarton.Checked = False
        Me.ChkACtn.Checked = False
        Me.ChkPCtn.Checked = False
        Me.ChkNserier.Checked = False
        Me.ChkPPID.Checked = False
        Me.ChkNserier.Enabled = True
        Me.ChkCarton.Enabled = True
        Me.ChkACtn.Enabled = False
        Me.ChkPCtn.Enabled = False
        Me.ChkPPID.Enabled = True
        Me.TxtPPIDqty.Text = ""
        Me.TxtPPIDqty.Enabled = False
        Me.TxtNserierQty.Text = ""
        Me.TxtNserierQty.Enabled = False
        Me.TxtCartonqty.Text = ""
        Me.TxtCartonqty.Enabled = False
        Me.TxtPCartonqty.Text = ""
        Me.TxtPCartonqty.Enabled = False
        Me.TxtNqty.Text = ""
        Me.TxtNqty.Enabled = False
        Me.TxtFileVerNo.Clear()
        Me.txtPnLable.Clear()

        Dim strBeforePrint As String    '提前時間
        Dim Dgread As DataTable
        Dgread = DbOperateUtils.GetDataTable("select sortname from m_sortset_t where sortID='BPrint' and usey='Y'")
        If Dgread.Rows.Count > 0 Then
            strBeforePrint = Dgread.Rows(0).Item("sortname").ToString
        Else
            strBeforePrint = 90
        End If
        If IsNumeric(strBeforePrint) = False Or strBeforePrint = "" Then
            strBeforePrint = 90
        End If
        Me.DtMoNeedTime.Value = Now.AddMinutes(CInt(strBeforePrint) + 5)
        Me.LblPPIDPrinted.Text = "0"
        Me.LblCartonPrinted.Text = "0"
        Me.LblDeptName.Text = ""
        Me.LblMoidqty.Text = "0"
        Me.TxtTaskDesc.Text = ""
        Me.LblPackqty.Text = "0"
        Me.LblTaskid.Text = ""
        ChkPPID.Checked = False
        ChkNserier.Checked = False
        ChkNppid.Checked = False
        ChkCarton.Checked = False
        chkAttached.Checked = False
        Try
            CboPackItem.Items.Clear()
        Catch ex As Exception
            Try
                CboPackItem.DataSource = Nothing
            Catch ex1 As Exception
            End Try
        End Try
    End Sub

    Private Sub SetObject()
        Try
            Me.TxtMoid1.Text = Me.DgTask.Item(4, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
            Me.TxtPartid1.Text = Me.DgTask.Item(5, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
            Me.ChkCarton.Checked = IIf(Me.DgTask.Item(2, Me.DgTask.CurrentRow.Index).Value.ToString.Trim = "C-外箱標簽", True, False)
            Me.ChkNppid.Checked = IIf(Me.DgTask.Item(2, Me.DgTask.CurrentRow.Index).Value.ToString.Trim = "N-無流水號標簽", True, False)
            Me.ChkPPID.Checked = IIf(Me.DgTask.Item(2, Me.DgTask.CurrentRow.Index).Value.ToString.Trim = "S-產品標簽", True, False)
            'Me.ChkCarton.Enabled = IIf(Me.DgTask.Item(2, Me.DgTask.CurrentRow.Index).Value.ToString.Trim = "C-外箱條碼", True, False)
            Me.ChkACtn.Enabled = Me.ChkCarton.Enabled
            Me.ChkPCtn.Enabled = Me.ChkCarton.Enabled
            Me.ChkACtn.Checked = Me.ChkCarton.Checked
            Me.ChkNserier.Enabled = IIf(Me.DgTask.Item(2, Me.DgTask.CurrentRow.Index).Value.ToString.Trim = "P-栈板標簽", True, False)
            Me.ChkPPID.Enabled = IIf(Me.DgTask.Item(2, Me.DgTask.CurrentRow.Index).Value.ToString.Trim = "S-產品條碼", True, False)
            Me.TxtNqty.Text = IIf(Me.ChkNppid.Checked, Me.DgTask.Item(8, Me.DgTask.CurrentRow.Index).Value.ToString.Trim, "")
            Me.TxtNqty.Enabled = Me.ChkNppid.Checked

            Me.TxtPPIDqty.Text = IIf(Me.ChkPPID.Checked, Me.DgTask.Item(8, Me.DgTask.CurrentRow.Index).Value.ToString.Trim, "")
            Me.TxtPPIDqty.Enabled = Me.ChkPPID.Checked
            Me.TxtNserierQty.Text = IIf(Me.ChkNserier.Checked, Me.DgTask.Item(8, Me.DgTask.CurrentRow.Index).Value.ToString.Trim, "")
            Me.TxtNserierQty.Enabled = Me.ChkNserier.Checked
            Me.TxtCartonqty.Text = IIf(Me.ChkCarton.Checked, Me.DgTask.Item(8, Me.DgTask.CurrentRow.Index).Value.ToString.Trim, "")
            Me.TxtCartonqty.Enabled = Me.ChkCarton.Checked
            Me.DtMoNeedTime.Value = Now.AddMinutes(35)
            Me.LblDeptName.Text = Me.DgTask.Item(13, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
            Me.TxtTaskDesc.Text = Me.DgTask.Item(20, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
            Me.CboLineid1.Text = Me.DgTask.Item(3, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
            Me.LblTaskid.Text = Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
            Me.txtPnLable.Text = Me.DgTask.Item(32, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
            Me.TxtFileVerNo.Text = Me.DgTask.Item(7, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "工具條事件"
    '新建任務
    Private Sub ToolAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolAddNew.Click
        opFlag = 1
        SetStatus(opFlag)
        ClearObject()
        Me.DgTask.Rows.Clear()
        Me.ActiveControl = Me.TxtMoid1
    End Sub
    '編輯任務
    Private Sub ToolEditTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEditTask.Click
        Dim Dtable As New DataTable
        Try
            Me.Timer.Enabled = False
            If Me.DgTask.Rows.Count = 0 OrElse Me.DgTask.CurrentRow Is Nothing Then Me.Timer.Enabled = True : Exit Try
            Dtable = DbOperateUtils.GetDataTable("select Estateid from m_SnAssign_t where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim & "'")
            If Dtable.Rows.Count > 0 Then
                If Dtable.Rows(0)("Estateid").ToString.Trim <> "1" AndAlso Dtable.Rows(0)("Estateid").ToString.Trim <> "3" Then
                    MsgBox("只有單據狀態為[ 待打印] 或者為[ 被駁回] 的單據才能被修改！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Me.Timer.Enabled = True
                    Dtable.Dispose()
                    Exit Try
                End If
            Else
                MessageBox.Show("系統內不存在單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Timer.Enabled = True
                Dtable.Dispose()
                Exit Try
            End If
            If CheckRight(Me.DgTask.Item(4, Me.DgTask.CurrentRow.Index).Value.ToString) = False Then Me.Timer.Enabled = True : Exit Try
            opFlag = 2
            SetStatus(opFlag)
            SetObject()
            GetMoidToRefresh(Me.TxtMoid1.Text.Trim)
            Me.ActiveControl = Me.TxtMoid1
        Catch ex As Exception
            Me.Timer.Enabled = True
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmPrtTask", "ToolEditTask_Click", "sys")
        End Try
    End Sub
    '作廢任務
    Private Sub ToolDelTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDelTask.Click
        Dim Dtable As New DataTable
        Dim finishQty As Integer = 0
        Try
            Me.Timer.Enabled = False
            If Me.DgTask.Rows.Count = 0 OrElse Me.DgTask.CurrentRow Is Nothing Then Exit Try
            Dtable = DbOperateUtils.GetDataTable("select Estateid ,isnull(finishPrintQty,0) finishPrintQty from m_SnAssign_t where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim & "'")
            If Dtable.Rows.Count > 0 Then
                finishQty = Convert.ToInt32(Dtable.Rows(0)("finishPrintQty"))
                If Dtable.Rows(0)("Estateid").ToString.Trim <> "1" AndAlso Dtable.Rows(0)("Estateid").ToString.Trim <> "3" Then
                    MsgBox("只有單據狀態為[ 待打印] 或者為[ 被駁回] 的單據才能被作廢！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Dtable.Dispose()
                    Exit Try
                End If
            Else
                MessageBox.Show("系統內不存在單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dtable.Dispose()
                Exit Try
            End If
            If factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
                If finishQty > 0 Then
                    MessageBox.Show("当前单据已开始打印,不能作废,请通知标签室退单", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Try
                End If
            End If
            If CheckRight(Me.DgTask.Item(4, Me.DgTask.CurrentRow.Index).Value.ToString) = False Then Exit Try
            If MessageBox.Show("請確認是否要作廢單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]?", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Try

            DbOperateUtils.ExecSQL("Update m_SnAssign_t set Estateid='4',userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & "'")
            MessageBox.Show("單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]已被作廢！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmPrtTask", "ToolDelTask_Click", "sys")
        Finally
            Me.Timer.Enabled = True
        End Try
    End Sub
    '提交任務
    Private Sub ToolCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCommit.Click
        Dim CurrTaskid As New StringBuilder
        Dim Sqlstr As New StringBuilder
        Dim RecTable As New DataTable
        Dim PrtQty As Integer = 0
        Dim Remark As String = ""
        Dim Shift As String
        Try
            If CheckData() = False Then Exit Try
            If CheckRight(Me.TxtMoid1.Text.Trim) = False Then Exit Try
            'If MsgBox("確認要提交該單據嗎？", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "系統提示") = MsgBoxResult.No Then Exit Try
            Dim DPrtTestQty As Double = 0

            If opFlag = 1 Then '新增申請單

                Sqlstr.Append("declare @Taskid varchar(11) declare @Taskid1 varchar(11) declare @Taskid2 varchar(11) declare @Taskid4 varchar(11) declare @Taskid5 varchar(11)  declare @Taskid6 varchar(11)")
                If Me.ChkPPID.Checked Then

                    DPrtTestQty = Convert.ToInt64(Me.TxtPPIDqty.Text.ToString.Trim) * 0.008

                    If DPrtTestQty < 10 Then
                        DPrtTestQty = 5
                    Else
                        DPrtTestQty = 10
                    End If

                    '獲得申請單號
                    Sqlstr.Append(" select @Taskid=Ptaskid from m_SnAssign_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " _
                                & " if @@rowcount=0 begin set @Taskid='T' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " _
                                & " set @Taskid=left(@Taskid,7) + right(Replicate('0',4) + cast(right(@Taskid,4)+1 as varchar),4) End ")
                    'insert 語句
                    Shift = IIf(Me.ComShift.SelectedIndex = 0, "D", "N")
                    If Me.ComShift.SelectedIndex = -1 Then
                        Shift = ""
                    End If
                    If Me.FactoryOfJX.Contains(VbCommClass.VbCommClass.Factory.Trim & ";") Then
                        Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,Extended1,Extended2,Extended3,LABELPN) " _
                                & " values(@Taskid,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','S'," & Int(Me.TxtPPIDqty.Text.ToString.Trim) _
                                & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & Me.TxtTaskDesc.Text.ToString.Trim & "','" & Shift & "','" & TxtFileVerNo.Text.Trim & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text.Trim & "','" & Me.CboPackItem.SelectedValue.ToString.Trim & "','" & Me.txtExtended1.Text.ToString.Trim & "','" & Me.txtExtended2.Text.ToString.Trim & "','" & Me.txtExtended3.Text.ToString.Trim & "','" & Me.txtPnLable.Text & "')")
                    Else
                        Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,Extended1,Extended2,Extended3,LABELPN, PrtTestQty) " _
                                & " values(@Taskid,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','S'," & Int(Me.TxtPPIDqty.Text.ToString.Trim) _
                                & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & Me.TxtTaskDesc.Text.ToString.Trim & "','" & Shift & "','" & TxtFileVerNo.Text.Trim & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text.Trim & "','" & Me.CboPackItem.SelectedValue.ToString.Trim & "','" & Me.txtExtended1.Text.ToString.Trim & "','" & Me.txtExtended2.Text.ToString.Trim & "','" & Me.txtExtended3.Text.ToString.Trim & "','" & Me.txtPnLable.Text & "', '" & DPrtTestQty & "')")
                    End If
                End If
                If Me.ChkCarton.Checked Then
                    PrtQty = 0
                    Remark = Me.TxtTaskDesc.Text.Trim
                    If Me.ChkACtn.Enabled = True AndAlso Me.ChkACtn.Checked = True Then
                        PrtQty = Int(Me.TxtCartonqty.Text.Trim)
                    End If
                    If Me.ChkPCtn.Enabled = True AndAlso Me.ChkPCtn.Checked = True Then
                        PrtQty = PrtQty + 1
                        Remark = Remark + ControlChars.CrLf + "含尾箱,其裝箱數量:" + Me.TxtPCartonqty.Text.Trim
                    End If
                    Shift = IIf(Me.ComShift.SelectedIndex = 0, "D", "N")
                    If Me.ComShift.SelectedIndex = -1 Then
                        Shift = ""
                    End If

                    DPrtTestQty = Convert.ToInt64(PrtQty) * 0.008

                    If DPrtTestQty < 10 Then
                        DPrtTestQty = 5
                    Else
                        DPrtTestQty = 10
                    End If

                    '獲得申請單號
                    Sqlstr.Append(" select @Taskid1=Ptaskid from m_SnAssign_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " _
                                 & " if @@rowcount=0 begin set @Taskid1='T' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " _
                                 & " set @Taskid1=left(@Taskid1,7) + right(Replicate('0',4) + cast(right(@Taskid1,4)+1 as varchar),4) End ")
                    'insert 語句
                    '新余厂区特殊  没有PrtTestQty字段 Modified ByKyLinQiu20180111
                    If Me.FactoryOfJX.Contains(VbCommClass.VbCommClass.Factory.Trim & ";") Then
                        Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,Extended1,Extended2,Extended3,LABELPN) " _
                                & " values(@Taskid1,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','C'," & PrtQty _
                                & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & Remark & "','" & Shift & "','" & TxtFileVerNo.Text & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text & "','" & Me.CboPackItem.SelectedValue.ToString.Trim & "','" & Me.txtExtended1.Text.ToString.Trim & "','" & Me.txtExtended2.Text.ToString.Trim & "','" & Me.txtExtended3.Text.ToString.Trim & "','" & txtPnLable.Text.Trim & "')")
                    Else
                        Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,Extended1,Extended2,Extended3,LABELPN, PrtTestQty) " _
                                 & " values(@Taskid1,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','C'," & PrtQty _
                                 & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & Remark & "','" & Shift & "','" & TxtFileVerNo.Text & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text & "','" & Me.CboPackItem.SelectedValue.ToString.Trim & "','" & Me.txtExtended1.Text.ToString.Trim & "','" & Me.txtExtended2.Text.ToString.Trim & "','" & Me.txtExtended3.Text.ToString.Trim & "','" & txtPnLable.Text.Trim & "', '" & DPrtTestQty & "')")
                    End If
                End If
                Shift = IIf(Me.ComShift.SelectedIndex = 0, "D", "N")
                If Me.ComShift.SelectedIndex = -1 Then
                    Shift = ""
                End If
                If Me.ChkNserier.Checked Then
                    DPrtTestQty = Convert.ToInt64(Me.TxtNserierQty.Text.ToString.Trim) * 0.008

                    If DPrtTestQty < 10 Then
                        DPrtTestQty = 5
                    Else
                        DPrtTestQty = 10
                    End If
                    '獲得申請單號
                    Sqlstr.Append(" select @Taskid2=Ptaskid from m_SnAssign_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " _
                                 & " if @@rowcount=0 begin set @Taskid2='T' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " _
                                 & " set @Taskid2=left(@Taskid2,7) + right(Replicate('0',4) + cast(right(@Taskid2,4)+1 as varchar),4) End ")
                    'insert 語句
                    If Me.FactoryOfJX.Contains(VbCommClass.VbCommClass.Factory.Trim & ";") Then
                        Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,Extended1,Extended2,Extended3,LABELPN) " _
                                 & " values(@Taskid2,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','P'," & Int(Me.TxtNserierQty.Text.ToString.Trim) _
                                 & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & Me.TxtTaskDesc.Text.ToString.Trim & "','" & Shift & "','" & TxtFileVerNo.Text & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text & "','" & Me.CboPackItem.SelectedValue.ToString.Trim & "','" & Me.txtExtended1.Text.ToString.Trim & "','" & Me.txtExtended2.Text.ToString.Trim & "','" & Me.txtExtended3.Text.ToString.Trim & "','" & txtPnLable.Text.Trim & "')")
                    Else
                        Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,Extended1,Extended2,Extended3,LABELPN, PrtTestQty) " _
                                 & " values(@Taskid2,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','P'," & Int(Me.TxtNserierQty.Text.ToString.Trim) _
                                 & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & Me.TxtTaskDesc.Text.ToString.Trim & "','" & Shift & "','" & TxtFileVerNo.Text & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text & "','" & Me.CboPackItem.SelectedValue.ToString.Trim & "','" & Me.txtExtended1.Text.ToString.Trim & "','" & Me.txtExtended2.Text.ToString.Trim & "','" & Me.txtExtended3.Text.ToString.Trim & "','" & txtPnLable.Text.Trim & "', '" & DPrtTestQty & "')")
                    End If
                End If

                If Me.ChkNppid.Checked Then
                    DPrtTestQty = Convert.ToInt64(Me.TxtNqty.Text.ToString.Trim) * 0.008

                    If DPrtTestQty < 10 Then
                        DPrtTestQty = 5
                    Else
                        DPrtTestQty = 10
                    End If
                    '獲得申請單號
                    Sqlstr.Append(" select @Taskid4=Ptaskid from m_SnAssign_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " _
                                 & " if @@rowcount=0 begin set @Taskid4='T' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " _
                                 & " set @Taskid4=left(@Taskid4,7) + right(Replicate('0',4) + cast(right(@Taskid4,4)+1 as varchar),4) End ")
                    'insert 語句
                    If Me.FactoryOfJX.Contains(VbCommClass.VbCommClass.Factory.Trim & ";") Then
                        Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,Extended1,Extended2,Extended3,LABELPN) " _
                                 & " values(@Taskid4,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','N'," & Int(Me.TxtNqty.Text.ToString.Trim) _
                                 & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & Me.TxtTaskDesc.Text.ToString.Trim & "','" & Shift & "','" & TxtFileVerNo.Text & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text & "','" & Me.CboPackItem.SelectedValue.ToString.Trim & "','" & Me.txtExtended1.Text.ToString.Trim & "','" & Me.txtExtended2.Text.ToString.Trim & "','" & Me.txtExtended3.Text.ToString.Trim & "','" & txtPnLable.Text.Trim & "')")
                    Else
                        Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,Extended1,Extended2,Extended3,LABELPN, PrtTestQty) " _
                                 & " values(@Taskid4,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','N'," & Int(Me.TxtNqty.Text.ToString.Trim) _
                                 & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & Me.TxtTaskDesc.Text.ToString.Trim & "','" & Shift & "','" & TxtFileVerNo.Text & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text & "','" & Me.CboPackItem.SelectedValue.ToString.Trim & "','" & Me.txtExtended1.Text.ToString.Trim & "','" & Me.txtExtended2.Text.ToString.Trim & "','" & Me.txtExtended3.Text.ToString.Trim & "','" & txtPnLable.Text.Trim & "', '" & DPrtTestQty & "')")
                    End If
                End If

                If Me.chkAttached.Checked Then
                    DPrtTestQty = Convert.ToInt64(Me.txtAttachedQty.Text.ToString.Trim) * 0.008

                    If DPrtTestQty < 10 Then
                        DPrtTestQty = 5
                    Else
                        DPrtTestQty = 10
                    End If
                    '獲得申請單號
                    Sqlstr.Append(" select @Taskid5=Ptaskid from m_SnAssign_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " _
                                & " if @@rowcount=0 begin set @Taskid5='T' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " _
                                & " set @Taskid5=left(@Taskid5,7) + right(Replicate('0',4) + cast(right(@Taskid5,4)+1 as varchar),4) End ")
                    'insert 語句
                    If Me.FactoryOfJX.Contains(VbCommClass.VbCommClass.Factory.Trim & ";") Then
                        Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,Extended1,Extended2,Extended3,LABELPN) " _
                                & " values(@Taskid5,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','A'," & Int(Me.txtAttachedQty.Text.ToString.Trim) _
                                & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & Me.TxtTaskDesc.Text.ToString.Trim & "','" & Shift & "','" & TxtFileVerNo.Text.Trim & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text.Trim & "','" & Me.CboPackItem.SelectedValue.ToString.Trim & "','" & Me.txtExtended1.Text.ToString.Trim & "','" & Me.txtExtended2.Text.ToString.Trim & "','" & Me.txtExtended3.Text.ToString.Trim & "','" & txtPnLable.Text.Trim & "')")
                    Else
                        Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,Extended1,Extended2,Extended3,LABELPN, PrtTestQty) " _
                                & " values(@Taskid5,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','A'," & Int(Me.txtAttachedQty.Text.ToString.Trim) _
                                & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & Me.TxtTaskDesc.Text.ToString.Trim & "','" & Shift & "','" & TxtFileVerNo.Text.Trim & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text.Trim & "','" & Me.CboPackItem.SelectedValue.ToString.Trim & "','" & Me.txtExtended1.Text.ToString.Trim & "','" & Me.txtExtended2.Text.ToString.Trim & "','" & Me.txtExtended3.Text.ToString.Trim & "','" & txtPnLable.Text.Trim & "', '" & DPrtTestQty & "')")
                    End If
                End If

                'modify by paul20150310 增加制程条码K
                If Me.chkAssembly.Checked Then
                    DPrtTestQty = Convert.ToInt64(Me.txtAssemblyQty.Text.ToString.Trim) * 0.008

                    If DPrtTestQty < 10 Then
                        DPrtTestQty = 5
                    Else
                        DPrtTestQty = 10
                    End If
                    '獲得申請單號
                    Sqlstr.Append(" select @Taskid6=Ptaskid from m_SnAssign_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " _
                                & " if @@rowcount=0 begin set @Taskid6='T' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " _
                                & " set @Taskid6=left(@Taskid6,7) + right(Replicate('0',4) + cast(right(@Taskid6,4)+1 as varchar),4) End ")
                    'insert 語句
                    If Me.FactoryOfJX.Contains(VbCommClass.VbCommClass.Factory.Trim & ";") Then
                        Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,Extended1,Extended2,Extended3,LABELPN) " _
                               & " values(@Taskid6,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','K'," & Int(Me.txtAssemblyQty.Text.ToString.Trim) _
                               & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & Me.TxtTaskDesc.Text.ToString.Trim & "','" & Shift & "','" & TxtFileVerNo.Text.Trim & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text.Trim & "','" & Me.CboPackItem.SelectedValue.ToString.Trim & "','" & Me.txtExtended1.Text.ToString.Trim & "','" & Me.txtExtended2.Text.ToString.Trim & "','" & Me.txtExtended3.Text.ToString.Trim & "','" & txtPnLable.Text & "')")
                    Else
                        Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute,Packitem,Extended1,Extended2,Extended3,LABELPN, PrtTestQty) " _
                                   & " values(@Taskid6,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','K'," & Int(Me.txtAssemblyQty.Text.ToString.Trim) _
                                   & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1',N'" & Me.TxtTaskDesc.Text.ToString.Trim & "','" & Shift & "','" & TxtFileVerNo.Text.Trim & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text.Trim & "','" & Me.CboPackItem.SelectedValue.ToString.Trim & "','" & Me.txtExtended1.Text.ToString.Trim & "','" & Me.txtExtended2.Text.ToString.Trim & "','" & Me.txtExtended3.Text.ToString.Trim & "','" & txtPnLable.Text & "', '" & DPrtTestQty & "')")
                    End If
                End If

                '返回申請單號
                Sqlstr.Append(ControlChars.CrLf & "select @Taskid as Taskid0,@Taskid1 as Taskid1,@Taskid2 as Taskid2,@Taskid4 as Taskid4, @Taskid5 as Taskid5")
                RecTable = DbOperateUtils.GetDataTable(Sqlstr.ToString)
                If RecTable.Rows(0)("Taskid0").ToString <> "" Then
                    CurrTaskid.Append(RecTable.Rows(0)("Taskid0").ToString)
                End If
                If RecTable.Rows(0)("Taskid1").ToString <> "" Then
                    CurrTaskid.Append("," & RecTable.Rows(0)("Taskid1").ToString)
                End If
                If RecTable.Rows(0)("Taskid2").ToString <> "" Then
                    CurrTaskid.Append("," & RecTable.Rows(0)("Taskid2").ToString)
                End If
                If RecTable.Rows(0)("Taskid4").ToString <> "" Then
                    CurrTaskid.Append("," & RecTable.Rows(0)("Taskid4").ToString)
                End If
                If RecTable.Rows(0)("Taskid5").ToString <> "" Then
                    CurrTaskid.Append("," & RecTable.Rows(0)("Taskid5").ToString)
                End If
                GetTaskToRefresh(CurrTaskid.ToString)
                RecTable.Dispose()
            End If
            Shift = IIf(Me.ComShift.SelectedIndex = 0, "D", "N")
            If Me.ComShift.SelectedIndex = -1 Then
                Shift = ""
            End If
            If opFlag = 2 Then    '修改申請單
                PrtQty = 0
                Remark = Me.TxtTaskDesc.Text.Trim
                If Me.ChkPPID.Enabled = True AndAlso Me.ChkPPID.Checked = True Then
                    PrtQty = Int(Me.TxtPPIDqty.Text.Trim)
                ElseIf Me.ChkACtn.Enabled = True AndAlso Me.ChkACtn.Checked = True Then
                    PrtQty = Int(Me.TxtCartonqty.Text.Trim)
                ElseIf Me.ChkNserier.Enabled = True AndAlso Me.ChkNserier.Checked = True Then
                    PrtQty = Int(Me.TxtNserierQty.Text.Trim)
                ElseIf Me.ChkNppid.Enabled = True AndAlso ChkNppid.Checked = True Then
                    PrtQty = Int(Me.TxtNqty.Text.Trim)
                ElseIf Me.chkAttached.Enabled = True AndAlso chkAttached.Checked = True Then
                    PrtQty = Int(Me.txtAttachedQty.Text.Trim)
                End If
                If Me.ChkPCtn.Enabled = True AndAlso Me.ChkPCtn.Checked = True Then
                    PrtQty = PrtQty + 1
                    Remark = Remark + ControlChars.CrLf + "含尾箱,其裝箱數量:" + Me.TxtPCartonqty.Text.Trim
                End If
                Sqlstr.Append("update m_SnAssign_t set Estateid=1,Moid='" & Me.TxtMoid1.Text.Trim & "',Lineid='" & Me.CboLineid1.Text.Trim.ToUpper _
                             & "',PrtQty=" & PrtQty & ",Demandtime=cast('" _
                             & Me.DtMoNeedTime.Value.ToString("yyyy/MM/dd HH:mm") & "' as datetime),Remark=N'" & Remark & "',Userid='" & _
                             SysMessageClass.UseId.ToLower & "',intime=getdate(),shift='" & Shift & "',FileVerNo='" & TxtFileVerNo.Text & "',DriFlag='" & TxtDriFlag.Text & "',BuildAttribute='" & TxtBuildAttribute.Text & "',LABELPN='" & txtPnLable.Text.Trim & "' where Ptaskid='" & Me.LblTaskid.Text.Trim & "'")
                DbOperateUtils.ExecSQL(Sqlstr.ToString)
                CurrTaskid.Append(Me.LblTaskid.Text.Trim)
            End If
            GetTaskToRefresh(CurrTaskid.ToString)
            'MsgBox("操作成功！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")

            opFlag = 0
            SetStatus(opFlag)
            ClearObject()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmPrtTask", "ToolCommit_Click", "sys")
        End Try
    End Sub
    '返回
    Private Sub ToolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBack.Click
        ClearObject()
        opFlag = 0
        SetStatus(opFlag)
        RefreshGrid()
    End Sub
    '刷新,1分鐘自動刷新
    Private Sub ToolRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRefresh.Click, Timer.Tick
        RefreshGrid()
    End Sub
    ''匯出Excel
    'Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
    '    'Dim ExportClass As New MainFrame.SysDataHandle.SysDataBaseClass
    '    'If Me.DgTask.Rows.Count = 0 Then Exit Sub
    '    'ExportClass.InportInExcel(GSqlstr.ToString, "打印申請作業", Me.DgTask)
    'End Sub
    '駁回任務
    Private Sub ToolBTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBTask.Click
        Dim Dtable As New DataTable
        Try
            Me.Timer.Enabled = False
            If Me.DgTask.Rows.Count = 0 OrElse Me.DgTask.CurrentRow Is Nothing Then Exit Try
            Dtable = DbOperateUtils.GetDataTable("select Estateid from m_SnAssign_t where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim & "'")
            If Dtable.Rows.Count > 0 Then
                If Dtable.Rows(0)("Estateid").ToString.Trim <> "1" AndAlso Dtable.Rows(0)("Estateid").ToString.Trim <> "2" Then
                    MsgBox("只有單據狀態為[ 待打印] 或者為[ 打印中] 的單據才能被駁回！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Dtable.Dispose()
                    Exit Try
                End If
            Else
                MessageBox.Show("系統內不存在單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dtable.Dispose()
                Exit Try
            End If
            If MessageBox.Show("請確認是否要駁回單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]?", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Try

            Dim BohuiMsg As String = InputBox("请输入单据[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]的駁回原因：", "申請單據駁回")
            If BohuiMsg.Trim = "" Then MessageBox.Show("駁回原因不能為空！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Try
            DbOperateUtils.ExecSQL("update m_SnAssign_t set Estateid=3,Remark=case Remark when '' then '" & BohuiMsg & "' else Remark + '/" & BohuiMsg & "' end,Printuser='" & SysMessageClass.UseId.Trim.ToString & "',Printtime=getdate() where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & "'")
            MessageBox.Show("單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]已被駁回！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmPrtTask", "ToolBTask_Click", "sys")
        Finally
            Me.Timer.Enabled = True
        End Try
    End Sub
    '條碼打印
    Private Sub ToolPrt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPrt.Click
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim Dtable As DataTable

        Try
            'added by paul 2015/03/14
            If Me.DgTask.Rows.Count <= 0 Then
                Exit Sub
            End If
            'end added
            Me.Timer.Enabled = False
            'If Me.DgTask.Rows.Count = 0 OrElse Me.DgTask.CurrentRow Is Nothing Then Exit Try
            'If (DgTask.CurrentRow.Cells("Coldocfile").Value <> DgTask.CurrentRow.Cells("ColFileVerno").Value) Then
            '    MsgBox("料件的打印参数中图面版本号与打印申请的版本号不相同！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            '    Dtable.Dispose()
            '    Exit Try
            'End If
            Dim FinalYstr As String = ""
            Dtable = DbOperateUtils.GetDataTable("select isnull(FinalY,'') FinalY from m_mainmo_t where moid='" & Me.DgTask.CurrentRow.Cells("Colmoid").Value.ToString & "'")
            If Dtable.Rows.Count > 0 Then
                FinalYstr = Dtable.Rows(0)!FinalY
            End If
            If FinalYstr = "Y" Then
                MsgBox("该工单已结案或已被冻结...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Exit Sub
            End If
            Dtable = DbOperateUtils.GetDataTable("select Estateid from m_SnAssign_t where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim & "'")
            If Dtable.Rows.Count > 0 Then
                If Dtable.Rows(0)!Estateid.ToString.Trim <> "1" AndAlso Dtable.Rows(0)!Estateid.ToString.Trim <> "2" Then
                    MsgBox("只有單據狀態為[ 待打印] 或者為[ 打印中] 的單據執行此操作！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Exit Sub
                End If
            Else
                MessageBox.Show("系統內不存在單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim IsAllowPrintFile As String = ""
            If Me.ChkNotPrint.Checked Then
                Dtable = DbOperateUtils.GetDataTable("select isnull(IsPrintFile,'') IsPrintFile from m_PartContrast_t where  TAvcPart=PAvcPart and TAvcPart='" & Me.DgTask.CurrentRow.Cells("ColPartid").Value.ToString & "'")
                If Dtable.Rows.Count > 0 Then
                    IsAllowPrintFile = Dtable.Rows(0)!IsPrintFile
                End If
                If IsAllowPrintFile = "N" Then
                    MsgBox("该料号不允许生成打印CSV文件...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Exit Sub
                End If
            End If
            If Me.ChkNotPrint.Checked Then
                Dtable = DbOperateUtils.GetDataTable("select IsLotOk from m_mainmo_t where moid='" & Me.DgTask.CurrentRow.Cells("Colmoid").Value.ToString() & "' and isnull(IsLotOk,'')='Y'")
                If Dtable.Rows.Count = 0 Then
                    MsgBox("该工单仓库未进行来料批次扫描，不允许生成打印CSV文件...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Exit Sub
                End If
            End If
            '打印
            Dtable = DbOperateUtils.GetDataTable("select a.Moid,b.Lineid,a.Cusid,c.CodeRuleID,b.Ptaskid,c.Packid,b.Extended1,b.Extended2,b.Extended3 from m_Mainmo_t as a join m_SnAssign_t as b " _
                                    & " on b.Moid=a.Moid and b.Estateid in('1','2') join m_PartPack_t as c on a.PartID=c.Partid and c.Packid=b.Packid and c.Usey='Y' and c.Packitem=b.Packitem " _
                                    & " where b.Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & "'")
            'Dim Sqlstr As String = ""
            If Dtable.Rows.Count > 0 Then
                Dim FrmBarM As New FrmBarM
                '更新單據狀態
                '調出打印界面d
                FrmBarM.LoadM.CodeRule = Dtable.Rows(0)!CodeRuleID.ToString
                FrmBarM.LoadM.Taskid = Dtable.Rows(0)!Ptaskid.ToString
                FrmBarM.LoadM.DefaultMoid = Dtable.Rows(0)!Moid.ToString
                FrmBarM.LoadM.DefaultLine = Dtable.Rows(0)!Lineid.ToString
                FrmBarM.LoadM.CustID = Dtable.Rows(0)!Cusid.ToString
                FrmBarM.LoadM.Factory = Me.DgTask.CurrentRow.Cells("ColFac").Value.ToString
                FrmBarM.LoadM.DeptJm = Me.DgTask.CurrentRow.Cells("ColDeptDc").Value.ToString
                FrmBarM.LoadM.vShift = Me.DgTask.CurrentRow.Cells("Colshift").Value.ToString
                FrmBarM.LoadM.vLineJm = Me.DgTask.CurrentRow.Cells("LineJm").Value.ToString
                FrmBarM.LoadM.vRequestDate = Me.DgTask.CurrentRow.Cells("ColNeedDate").Value.ToString
                FrmBarM.LoadM.vIsprint = IIf(Me.ChkNotPrint.Checked, "Y", "N")
                FrmBarM.LoadM.vCodeType = Dtable.Rows(0)!Packid.ToString
                FrmBarM.LoadM.vVerNo = Me.DgTask.CurrentRow.Cells("ColFileVerno").Value.ToString
                FrmBarM.LoadM.vDriFlag = Me.DgTask.CurrentRow.Cells("ColDriFlag").Value.ToString
                FrmBarM.LoadM.vBuildAttribute = Me.DgTask.CurrentRow.Cells("BuildAttribute").Value.ToString

                FrmBarM.LoadM.Extended1 = Dtable.Rows(0)!Extended1.ToString
                FrmBarM.LoadM.Extended2 = Dtable.Rows(0)!Extended2.ToString
                FrmBarM.LoadM.Extended3 = Dtable.Rows(0)!Extended3.ToString
                FrmBarM.BnBulidBarCode_Click(sender, e)
            Else
                Exit Sub
            End If
            DbOperateUtils.ExecSQL("Update m_SnAssign_t set Estateid='2',Printuser='" & SysMessageClass.UseId.ToLower.Trim & "' where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & "'")
            RefreshGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmPrtTask", "ToolPrt_Click", "sys")
        Finally
            Me.Timer.Enabled = True
        End Try
    End Sub
    '打印完成
    Private Sub ToolFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolFinish.Click
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫連接對象
        Dim Dtable As New DataTable
        Try
            Me.Timer.Enabled = False
            If Me.DgTask.Rows.Count = 0 OrElse Me.DgTask.CurrentRow Is Nothing Then Exit Try
            Dtable = DbOperateUtils.GetDataTable("select Estateid from m_SnAssign_t where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim & "'")
            If Dtable.Rows.Count > 0 Then
                If Dtable.Rows(0)("Estateid").ToString.Trim <> "2" Then
                    MsgBox("只有單據狀態為[ 打印中] 的單據才能維護該操作！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Dtable.Dispose()
                    Exit Try
                End If
            Else
                MessageBox.Show("系統內不存在單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dtable.Dispose()
                Exit Try
            End If
            If MessageBox.Show("請確認單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]是否已打印完成?", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Try

            DbOperateUtils.ExecSQL("update m_SnAssign_t set Estateid=5,Printtime=getdate() where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & "'")
            MessageBox.Show("單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]打印完成狀態已更新！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmPrtTask", "ToolFinish_Click", "sys")
        Finally
            Me.Timer.Enabled = True
        End Try
    End Sub
    '單據結案
    Private Sub ToolStopTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStopTask.Click
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫連接對象
        Dim Dtable As New DataTable
        Try
            Me.Timer.Enabled = False
            If Me.DgTask.Rows.Count = 0 OrElse Me.DgTask.CurrentRow Is Nothing Then Exit Try
            Dtable = DbOperateUtils.GetDataTable("select Estateid from m_SnAssign_t where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim & "'")
            If Dtable.Rows.Count > 0 Then
                If Dtable.Rows(0)("Estateid").ToString.Trim <> "5" Then
                    MsgBox("只有單據狀態為[ 待領取] 的單據才能被結案！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Dtable.Dispose()
                    Exit Try
                End If
            Else
                MessageBox.Show("系統內不存在單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dtable.Dispose()
                Exit Try
            End If
            If MessageBox.Show("請確認單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]的條碼是否已被領取?", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Try

            DbOperateUtils.ExecSQL("update m_SnAssign_t set Estateid=6,Taketime=getdate() where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & "'")
            MessageBox.Show("單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]已結案！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmPrtTask", "ToolStopTask_Click", "sys")
        Finally
            Me.Timer.Enabled = True
        End Try
    End Sub
    '退出
    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

#End Region

#Region "獲得Sql語句刷新表格"

    Private Sub RefreshGrid()
        Dim Sqlstr As New StringBuilder
        Dim Flag As Boolean = False

        If Me.CboMoid.Text <> "" AndAlso Me.CboMoid.Text <> "ALL" Then
            If Flag = True Then
                Sqlstr.Append(" and a.moid like '" & Me.CboMoid.Text.ToString.Trim & "%'")
            Else
                Sqlstr.Append(" where a.moid like '" & Me.CboMoid.Text.ToString.Trim & "%'")
                Flag = True
            End If
        End If

        If Me.CboTaskid.Text <> "" AndAlso Me.CboTaskid.Text <> "ALL" Then
            If Flag = True Then
                Sqlstr.Append(" and a.Ptaskid like '" & Me.CboTaskid.Text.ToString.Trim & "%'")
            Else
                Sqlstr.Append(" where a.Ptaskid like '" & Me.CboTaskid.Text.ToString.Trim & "%'")
                Flag = True
            End If
        End If

        If Me.CboLineid.Text <> "" AndAlso Me.CboLineid.Text <> "ALL" Then
            If Flag = True Then
                Sqlstr.Append(" and a.Lineid like '" & Me.CboLineid.Text.ToString.Trim & "%'")
            Else
                Sqlstr.Append(" where a.Lineid like '" & Me.CboLineid.Text.ToString.Trim & "%'")
                Flag = True
            End If
        End If

        If Me.CboPartid.Text <> "" AndAlso Me.CboPartid.Text <> "ALL" Then
            If Flag = True Then
                Sqlstr.Append(" and b.partid like '" & Me.CboPartid.Text.ToString.Trim & "%'")
            Else
                Sqlstr.Append(" where b.partid like '" & Me.CboPartid.Text.ToString.Trim & "%'")
                Flag = True
            End If
        End If

        If Me.CboTaskStatus.SelectedIndex > 0 Then
            If Flag = True Then
                Sqlstr.Append(" and a.Estateid='" & Me.CboTaskStatus.Text.Trim.Split("-")(0) & "'")
            Else
                Sqlstr.Append(" where a.Estateid='" & Me.CboTaskStatus.Text.Trim.Split("-")(0) & "'")
                Flag = True
            End If
        ElseIf Me.CboTaskStatus.SelectedIndex = -1 AndAlso Me.CboTaskStatus.Text.Trim <> "" Then
            Dim Param() As String = Me.CboTaskStatus.Text.Trim.Split(",")
            If Flag = True Then
                Sqlstr.Append(" and a.Estateid in(")
            Else
                Sqlstr.Append(" Where a.Estateid in(")
                Flag = True
            End If
            For i As Integer = 0 To Param.GetUpperBound(0)
                Sqlstr.Append("'" & Param(i) & "',")
            Next i
            Sqlstr.Remove(Sqlstr.Length - 1, 1)
            Sqlstr.Append(") ")
        End If

        If Me.CboLabelType.SelectedIndex > 0 Then
            If Flag = True Then
                Sqlstr.Append(" and a.Packid='" & Me.CboLabelType.Text.Trim.Split("-")(0) & "'")
            Else
                Sqlstr.Append(" where a.Packid='" & Me.CboLabelType.Text.Trim.Split("-")(0) & "'")
                Flag = True
            End If
        End If

        If Me.CboDeptname.SelectedIndex > 0 Then
            If Flag = True Then
                Sqlstr.Append(" and f.deptid='" & Me.CboDeptname.Text.Trim.Split("-")(0) & "'")
            Else
                Sqlstr.Append(" where f.deptid='" & Me.CboDeptname.Text.Trim.Split("-")(0) & "'")
                Flag = True
            End If
        End If

        If Flag = True Then
            Sqlstr.Append(" and a.intime between cast('" & Me.DtpStarttime.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime) and cast('" & Me.DtpEndtime.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime)")
        Else
            Sqlstr.Append(" where a.intime between cast('" & Me.DtpStarttime.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime) and cast('" & Me.DtpEndtime.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime)")
            Flag = True
        End If
        If VbCommClass.VbCommClass.Factory = "BZLANTO" Or VbCommClass.VbCommClass.Factory = "CHUZHOU" Then '根据标签纸尺寸来排序,方便多料号打印不频繁换纸
            If Flag = True Then
                Sqlstr.Append(" and b.Factory='" & VbCommClass.VbCommClass.Factory & "' and b.profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'")
            Else
                Sqlstr.Append(" where b.Factory='" & VbCommClass.VbCommClass.Factory & "' and b.profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'")
                Flag = True
            End If
            Sqlstr.Append(" order by a.Estateid,h.PaperSize desc,a.Demandtime")
        End If


        GSqlstr.Remove(Gsqlplace, GSqlstr.Length - Gsqlplace)
        GSqlstr.Append(Sqlstr.ToString)
        LoadDataToDgrid(GSqlstr.ToString, Me.DgTask)
        'DrawNewIco
        For i As Int16 = 0 To Me.DgTask.Rows.Count - 1
            Dim TextAndImage As DataGridViewRolloverCell = Me.DgTask.Item(0, i)
            TextAndImage.ImageFlag = IIf(Me.DgTask.Item(1, i).Value.ToString.Trim = "1-待打印", True, False)
            If Me.DgTask.Item(0, i).Value.ToString = CurrTaskid Then
                Me.DgTask.CurrentCell = Me.DgTask.Item(0, i)
            End If
        Next
        If Me.DgTask.Rows.Count > 0 Then
            CurrTaskid = Me.DgTask.CurrentCell.Value.ToString
            Me.LblRemark.Text = Me.DgTask.Item(20, Me.DgTask.CurrentRow.Index).Value.ToString.Replace(ControlChars.CrLf, " ; ")
        End If
    End Sub

    Private Sub GetTaskToRefresh(ByVal SqlParam As String)
        Dim Param() As String
        Dim Sqlstr As New StringBuilder

        If SqlParam.Length <= 0 Then Exit Sub
        Param = SqlParam.Trim.Split(",")
        Sqlstr.Append(" Where a.Ptaskid in(")
        For i As Integer = 0 To Param.GetUpperBound(0)
            Sqlstr.Append("'" & Param(i) & "',")
        Next i
        Sqlstr.Remove(Sqlstr.Length - 1, 1)
        Sqlstr.Append(") order by a.Demandtime")
        GSqlstr.Remove(Gsqlplace, GSqlstr.Length - Gsqlplace)
        GSqlstr.Append(Sqlstr.ToString)
        LoadDataToDgrid(GSqlstr.ToString, Me.DgTask)
        'DrawNewIco
        For i As Int16 = 0 To Me.DgTask.Rows.Count - 1
            Dim TextAndImage As DataGridViewRolloverCell = Me.DgTask.Item(0, i)
            TextAndImage.ImageFlag = IIf(Me.DgTask.Item(1, i).Value.ToString.Trim = "1-待打印", True, False)
            If Me.DgTask.Item(0, i).Value.ToString = CurrTaskid Then
                Me.DgTask.CurrentCell = Me.DgTask.Item(0, i)
            End If
        Next
        If Me.DgTask.Rows.Count > 0 Then
            CurrTaskid = Me.DgTask.CurrentCell.Value.ToString
            Me.LblRemark.Text = Me.DgTask.Item(20, Me.DgTask.CurrentRow.Index).Value.ToString.Replace(ControlChars.CrLf, " ; ")
        End If
    End Sub

    Private Sub GetMoidToRefresh(ByVal Moid As String)
        Dim Sqlstr As String
        If Moid.Trim = "" Then Exit Sub
        Sqlstr = " Where a.Moid='" & Moid.Trim & "' order by a.Demandtime"
        GSqlstr.Remove(Gsqlplace, GSqlstr.Length - Gsqlplace)
        GSqlstr.Append(Sqlstr.ToString)
        LoadDataToDgrid(GSqlstr.ToString, Me.DgTask)
        'DrawNewIco
        For i As Int16 = 0 To Me.DgTask.Rows.Count - 1
            Dim TextAndImage As DataGridViewRolloverCell = Me.DgTask.Item(0, i)
            TextAndImage.ImageFlag = IIf(Me.DgTask.Item(1, i).Value.ToString.Trim = "1-待打印", True, False)
            If Me.DgTask.Item(0, i).Value.ToString = CurrTaskid Then
                Me.DgTask.CurrentCell = Me.DgTask.Item(0, i)
            End If
        Next
        If Me.DgTask.Rows.Count > 0 Then
            CurrTaskid = Me.DgTask.CurrentCell.Value.ToString
            Me.LblRemark.Text = Me.DgTask.Item(20, Me.DgTask.CurrentRow.Index).Value.ToString.Replace(ControlChars.CrLf, " ; ")
        End If
    End Sub

    Private Sub GetPackItem(ByVal PartId As String, ByVal PackId As String, ByVal CboPackItem As ComboBox)
        If (String.IsNullOrEmpty(PartId)) Then
            Exit Sub
        End If

        If (String.IsNullOrEmpty(PackId)) Then
            Exit Sub
        End If

        Dim strSQL As String
        strSQL = "SELECT Packitem, PackId+'-'+ description+'-'+ m_SnPFormat_t.KLabelid as LabelType FROM m_PartPack_t " & _
               " LEFT JOIN  m_SnPFormat_t on m_SnPFormat_t.PFormatID=m_PartPack_t.PFormatID " & _
               " WHERE m_PartPack_t.Partid='" & PartId & "' AND m_PartPack_t.Usey='Y' AND m_PartPack_t.Packid='" & PackId & "'"
        If factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
            strSQL += " AND m_PartPack_t.CODERULEID NOT IN('N029','N033','N036') AND m_PartPack_t.USEY='Y'"
        End If
        Dim UserDg As DataTable
        'Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass

        CboPackItem.DataSource = Nothing
        CboPackItem.Items.Clear()
        Try
            UserDg = DbOperateUtils.GetDataTable(strSQL)
            CboPackItem.DataSource = UserDg
            CboPackItem.DisplayMember = "LabelType"
            CboPackItem.ValueMember = "Packitem"
            UserDg = Nothing
        Catch ex As Exception
            UserDg = Nothing
        End Try
    End Sub

#End Region

#Region "CheckData/CheckRight"

    Private Function CheckData() As Boolean
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim Dgread As SqlClient.SqlDataReader
        'CheckData
        If TxtFileVerNo.Text.Trim = "" Then
            TxtFileVerNo.Focus()
            MsgBox("料件的版本编号不能为空！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False

        End If
        If Me.TxtMoid1.Text.Trim = "" Then MsgBox("工單號不能為空！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
        If Me.TxtPartid1.Text.Trim = "" Then MsgBox("料件編號不能為空！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
        If Me.CboLineid1.Text.Trim = "" Then MsgBox("請選擇生產線別！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
        If Me.TxtFileVerNo.Text.Trim = "" Then MsgBox("版本编号不能为空！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
        If (String.IsNullOrEmpty(CboPackItem.Text.Trim)) Then MsgBox("请选择类型项次！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
        If VbCommClass.VbCommClass.Factory <> "BZLANTO" And VbCommClass.VbCommClass.Factory <> "CHUZHOU" Then
            If AsapCheck() Then Return False
        End If
        'If Me.TxtFileVerNo.Text.Trim <> "A" And Me.TxtFileVerNo.Text.Trim <> "B" Then MsgBox("版本编号只能为A或B！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
        'CheckMoid
        Dgread = Conn.GetDataReader("select PartID,Moid,FinalY from m_Mainmo_t where moid='" & Me.TxtMoid1.Text.Trim & "'")
        If Dgread.Read Then
            If Dgread.Item("PartID").ToString.Trim.ToUpper <> Me.TxtPartid1.Text.Trim.ToUpper Then
                MsgBox("該工單的料件編號是[ " & Dgread.Item("PartID").ToString.Trim.ToUpper & " ]，與輸入的料件編號不符！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                Dgread.Close()
                Return False
            End If
            If Dgread.Item("FinalY").ToString.Trim.ToUpper = "Y" Then
                MsgBox("該工單已結案！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                Dgread.Close()
                Return False
            End If
            If Dgread.Item("FinalY").ToString.Trim.ToUpper = "D" Then
                MsgBox("該工單已被冻结！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                Dgread.Close()
                Return False
            End If
        End If
        Dgread.Close()

        '檢查是否有選擇打印產品條碼或外箱條碼
        If Me.ChkCarton.Checked = False AndAlso Me.ChkPPID.Checked = False AndAlso Me.ChkNserier.Checked = False AndAlso Me.ChkNppid.Checked = False AndAlso Me.chkAttached.Checked = False AndAlso Me.chkAssembly.Checked = False Then
            MsgBox("請選擇打印條碼類型及輸入打印數量！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
            Return False
        End If
        If Me.ChkCarton.Checked Then
            '整數箱/尾數箱
            If Me.ChkACtn.Checked = False AndAlso Me.ChkPCtn.Checked = False Then
                MsgBox("請選擇外箱條碼打印類型及輸入數量！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                Return False
            End If
            'Check數量
            If Me.ChkACtn.Checked = True AndAlso (Me.TxtCartonqty.Text = "" OrElse Int(Me.TxtCartonqty.Text) <= 0) Then
                MsgBox("整數箱打印數量不能為空，不能小于！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                Return False
            End If
            If Me.ChkPCtn.Checked = True Then
                If Me.TxtPCartonqty.Text.Trim = "" Then
                    MsgBox("尾數箱的裝箱數量不能為空！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                    Return False
                End If
                If Int(Me.TxtPCartonqty.Text.Trim) <= 0 Then
                    MsgBox("尾數箱的裝箱數量不能小于！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                    Return False
                End If
                If Int(Me.TxtPCartonqty.Text.Trim) >= Int(Me.LblPackqty.Text.Trim) Then
                    MsgBox("尾數箱的裝箱數量不能大于或等于整數箱的裝箱數量！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                    Return False
                End If
            End If
            '檢查工單是否可以打印
            Dim ReStr As String = LoadM.CheckMoid(Me.TxtMoid1.Text.Trim, "C", "")
            If ReStr <> "1" Then MsgBox(ReStr, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示") : Return False
        End If
        'modify by paul 20150310 增加制程条码 K
        If Me.chkAssembly.Checked Then
            'Check數量
            If Me.txtAssemblyQty.Text = "" OrElse Int(Me.txtAssemblyQty.Text) <= 0 Then
                MsgBox("打印數量不能為空，不能小于！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                Return False
            End If
            '檢查工單是否可以打印
            Dim ReStr As String = LoadM.CheckMoid(Me.TxtMoid1.Text.Trim, "K", "")
            If ReStr <> "1" Then MsgBox(ReStr, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示") : Return False
        End If
        If Me.ChkPPID.Checked Then
            'Check數量
            If Me.TxtPPIDqty.Text = "" OrElse Int(Me.TxtPPIDqty.Text) <= 0 Then
                MsgBox("打印數量不能為空，不能小于！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                Return False
            End If
            '檢查工單是否可以打印
            Dim ReStr As String = LoadM.CheckMoid(Me.TxtMoid1.Text.Trim, "S", "")
            If ReStr <> "1" Then MsgBox(ReStr, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示") : Return False
        End If
        If Me.ChkNppid.Checked Then
            'Check數量
            If Me.TxtNqty.Text = "" OrElse Int(Me.TxtNqty.Text) <= 0 Then
                MsgBox("打印數量不能為空，不能小于！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                Return False
            End If
            '檢查工單是否可以打印
            Dim ReStr As String = LoadM.CheckMoid(Me.TxtMoid1.Text.Trim, "N", "")
            If ReStr <> "1" Then MsgBox(ReStr, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示") : Return False
        End If

        If Me.ChkNserier.Checked Then
            'Check數量
            If Me.TxtNserierQty.Text = "" OrElse Int(Me.TxtNserierQty.Text) <= 0 Then
                MsgBox("打印數量不能為空，不能小于！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                Return False
            End If
            '檢查工單是否可以打印
            Dim ReStr As String = LoadM.CheckMoid(Me.TxtMoid1.Text.Trim, "P", "")
            If ReStr <> "1" Then MsgBox(ReStr, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示") : Return False
        End If

        'Check需求時間
        'Dgread = Conn.GetDataReader("select convert(varchar(16),getdate()+'00:30:00',21) as Dtime,getdate() as nowtime")
        'If Dgread.Read Then
        '    If CDate(Me.DtMoNeedTime.Value.ToString("yyyy/MM/dd HH:mm")) < CDate(Dgread.Item("Dtime").ToString) Then
        '        MsgBox("需求時間設置必須大於當前時間分鐘以上！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
        '        Dgread.Close()
        '        Return False
        '    ElseIf CDate(Me.DtMoNeedTime.Value.ToString("yyyy/MM/dd HH:mm")).Date > CDate(Dgread.Item("nowtime").ToString).AddDays(1).Date Then
        '        MsgBox("需求時間必須是設置成當天！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
        '        Dgread.Close()
        '        Return False
        '    End If
        'End If
        'Dgread.Close()

        'Check需求時間
        'modi by frankie把“打印申請作業”里的需求時間由原來的min以上，更改為參數設置以上
        Dim strBeforePrint As String    '提前時間
        Dgread = Conn.GetDataReader("select sortname from m_sortset_t where sortID='BPrint' and usey='Y'")
        If Dgread.Read Then
            strBeforePrint = Dgread.Item("sortname").ToString
        Else
            MsgBox("[需求時間提前量]未在參數表中設置，請聯系資訊人員！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
            Dgread.Close()
            Return False
            strBeforePrint = ""
        End If
        Dgread.Close()
        If IsNumeric(strBeforePrint) = False Or strBeforePrint = "" Then
            MsgBox("[需求時間提前量]在參數表中設置值錯誤，請聯系資訊人員！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
            Dgread.Close()
            Return False
        End If

        'Dgread = Conn.GetDataReader("select convert(varchar(16),getdate()+'00:" & strBeforePrint & ":00',21) as Dtime,getdate() as nowtime")
        'Dgread = Conn.GetDataReader("select convert(varchar(16),dateadd(mi," & strBeforePrint & ",getdate()),21) as Dtime,getdate() as nowtime")
        'If Dgread.Read Then
        '    If CDate(Me.DtMoNeedTime.Value.ToString("yyyy/MM/dd HH:mm")) < CDate(Dgread.Item("Dtime").ToString) Then
        '        MsgBox("需求時間設置必須大於當前時間" & strBeforePrint & "分鐘以上！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
        '        Dgread.Close()
        '        Return False
        '    ElseIf CDate(Me.DtMoNeedTime.Value.ToString("yyyy/MM/dd HH:mm")).Date > CDate(Dgread.Item("nowtime").ToString).AddDays(1).Date Then
        '        MsgBox("需求時間必須是設置成當天！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
        '        Dgread.Close()
        '        Return False
        '    End If
        'End If
        Dgread.Close()
        Return True
    End Function
    '檢測工單的存儲權限
    Private Function CheckRight(ByVal Moid As String) As Boolean
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim Dgread As SqlClient.SqlDataReader = Conn.GetDataReader("select a.Buttonid + '-' + a.Ttext as Dept,c.tkey from m_Logtree_t as a " _
                                                                & " join m_Mainmo_t as b on a.buttonid=b.Deptid left join m_UserRight_t as c " _
                                                                & " on a.Tkey=c.Tkey and c.userid='" & SysMessageClass.UseId.ToLower.Trim & "' " _
                                                                & " where a.formid='Dept' and b.moid='" & Moid & "'")
        If Dgread.Read AndAlso Dgread.Item("tkey").ToString.Trim = "" Then
            MessageBox.Show("該用戶沒有設置[ " & Dgread.Item("Dept").ToString.Trim & " ] 部門工單的權限！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dgread.Close()
            Return False
        End If
        Dgread.Close()
        Conn = Nothing
        Return True
    End Function

#End Region

#Region "按鍵事件"

    Private Sub Txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCartonqty.KeyPress, TxtPPIDqty.KeyPress, TxtNserierQty.KeyPress, TxtPCartonqty.KeyPress, TxtNqty.KeyPress
        If Char.IsDigit(e.KeyChar) = False AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    'Private Sub TxtMoid1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMoid1.TextChanged
    '    If opFlag = 0 Then Exit Sub
    '    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
    '    Dim Dgread As SqlClient.SqlDataReader = Conn.GetDataReader(" select a.moid,a.Moqty,a.Ppidprtqty,a.Pkgprtqty,b.Qty,c.deptid + '-' + c.djc as deptname " _
    '                                                             & " from m_Mainmo_t as a left join m_PartPack_t as b on a.PartID=b.Partid and b.Usey='Y' and b.Packid='C' " _
    '                                                             & " left join m_Dept_t as c on a.Deptid=c.Deptid and c.usey='Y' where moid='" & Me.TxtMoid1.Text.Trim & "' and Factory='" & VbCommClass.VbCommClass.Factory & "'")
    '    If Dgread.Read Then
    '        Me.LblMoidqty.Text = IIf(Dgread.Item("Moqty").ToString <> "", Dgread.Item("Moqty").ToString, "0")
    '        Me.LblPPIDPrinted.Text = IIf(Dgread.Item("Ppidprtqty").ToString <> "", Dgread.Item("Ppidprtqty").ToString, "0")
    '        Me.LblCartonPrinted.Text = IIf(Dgread.Item("Pkgprtqty").ToString <> "", Dgread.Item("Pkgprtqty").ToString, "0")
    '        Me.LblPackqty.Text = IIf(Dgread.Item("Qty").ToString <> "", Dgread.Item("Qty").ToString, "0")
    '        Me.LblDeptName.Text = Dgread.Item("deptname").ToString
    '        '此處加載線別，應該加入廠區的條件，才能保持和打印作業一致并且合理。 modi by frankie 20110715
    '        'LoadM.LoadDataToTSComboBox("select lineid from Deptline_t where deptid='" & Me.LblDeptName.Text.Trim.Split("-")(0) & "' and usey='Y' order by lineid", Me.CboLineid1)
    '        LoadM.LoadDataToTSComboBox("select a.lineid from Deptline_t as a join m_Mainmo_t as b on a.deptid=b.deptid and a.factoryid=b.factory and b.moid='" & Me.TxtMoid1.Text.Trim & "' and a.usey='Y' order by a.lineid", Me.CboLineid1)

    '        If opFlag = 1 Then GetMoidToRefresh(Me.TxtMoid1.Text.Trim)
    '    Else
    '        Me.CboLineid1.Items.Clear()
    '        Me.LblMoidqty.Text = "0"
    '        Me.LblPPIDPrinted.Text = "0"
    '        Me.LblCartonPrinted.Text = "0"
    '        Me.LblPackqty.Text = "0"
    '        Me.LblDeptName.Text = ""
    '        Me.DgTask.Rows.Clear()
    '    End If
    '    Dgread.Close()
    'End Sub

    Private Sub ChkPPID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCarton.CheckedChanged, ChkPPID.CheckedChanged, ChkNserier.CheckedChanged, ChkACtn.CheckedChanged, ChkPCtn.CheckedChanged, ChkNppid.CheckedChanged, chkAttached.CheckedChanged, chkAssembly.CheckedChanged
        Me.TxtPPIDqty.Enabled = IIf(Me.ChkPPID.Enabled AndAlso Me.ChkPPID.Checked, True, False)
        Me.TxtNserierQty.Enabled = IIf(Me.ChkNserier.Enabled AndAlso Me.ChkNserier.Checked, True, False)
        Me.ChkACtn.Enabled = IIf(Me.ChkCarton.Enabled AndAlso Me.ChkCarton.Checked, True, False)
        Me.ChkPCtn.Enabled = IIf(Me.ChkCarton.Enabled AndAlso Me.ChkCarton.Checked, True, False)
        Me.TxtCartonqty.Enabled = IIf(Me.ChkACtn.Enabled AndAlso Me.ChkACtn.Checked, True, False)
        Me.TxtPCartonqty.Enabled = IIf(Me.ChkPCtn.Enabled AndAlso Me.ChkPCtn.Checked, True, False)
        Me.TxtNqty.Enabled = IIf(Me.ChkNppid.Enabled AndAlso Me.ChkNppid.Checked, True, False)
        Me.txtAttachedQty.Enabled = IIf(Me.chkAttached.Enabled AndAlso Me.chkAttached.Checked, True, False)
        'added by paul 20150310
        Me.txtAssemblyQty.Enabled = IIf(Me.chkAssembly.Enabled AndAlso Me.chkAssembly.Checked, True, False)
        Dim PackId As String = ""
        'added by paul
        If (Me.chkAssembly.Checked) Then
            PackId = "K"
        End If

        If (Me.ChkPPID.Checked) Then
            PackId = "S"
        End If

        If (Me.ChkCarton.Checked) Then
            PackId = "C"
        End If

        If (Me.ChkNppid.Checked) Then
            PackId = "N"
        End If

        If (Me.ChkNserier.Checked) Then
            PackId = "P"
        End If

        If (Me.chkAttached.Checked) Then
            PackId = "A"
        End If

        GetPackItem(Me.TxtPartid1.Text.Trim, PackId, CboPackItem)
        If (CboPackItem.Items.Count > 0) Then
            CboPackItem.SelectedIndex = 0
        End If
    End Sub

    Private Sub DtpStarttime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpStarttime.ValueChanged, DtpEndtime.ValueChanged
        If Me.ActiveControl Is Nothing Then Exit Sub
        Me.DgTask.Rows.Clear()
    End Sub

    Private Sub CboTaskid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboTaskid.KeyPress, CboTaskStatus.KeyPress, CboMoid.KeyPress, CboLineid.KeyPress, CboPartid.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboTaskStatus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboTaskid.TextChanged, CboTaskStatus.TextChanged, CboMoid.TextChanged, CboPartid.TextChanged, CboLineid.TextChanged
        If Me.ActiveControl Is Nothing Then Exit Sub
        Me.DgTask.Rows.Clear()
    End Sub

    Private Sub CboTaskStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTaskStatus.SelectedIndexChanged, CboLabelType.SelectedIndexChanged, CboDeptname.SelectedIndexChanged
        If Me.ActiveControl Is Nothing Then Exit Sub
        If sender.text.ToString.Trim = "" Then Exit Sub
        RefreshGrid()
    End Sub

    Private Sub DgTask_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgTask.CellClick

        If Me.DgTask.CurrentRow Is Nothing Then Exit Sub
        CurrTaskid = Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString
        Me.LblRemark.Text = Me.DgTask.Item(20, Me.DgTask.CurrentRow.Index).Value.ToString.Replace(ControlChars.CrLf, " ; ")
    End Sub

#End Region


    Private Sub TxtMoid1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMoid1.LostFocus

        If opFlag = 0 Then Exit Sub
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim Dgread As DataTable = DbOperateUtils.GetDataTable(
            " select a.moid,a.Moqty,a.Ppidprtqty,a.Pkgprtqty,b.Qty,c.deptid + '-' + c.djc as deptname,a.deptid, a.lineid " &
            " from m_Mainmo_t as a left join m_PartPack_t as b on a.PartID=b.Partid and b.Usey='Y' and b.Packid='C' " &
            " left join m_Dept_t as c on a.Deptid=c.Deptid and c.usey='Y' where moid='" & Me.TxtMoid1.Text.Trim &
            "' and Factory='" & VbCommClass.VbCommClass.Factory & "'")
        If Dgread.Rows.Count > 0 Then
            Me.LblMoidqty.Text = IIf(Dgread.Rows(0).Item("Moqty").ToString <> "", Dgread.Rows(0).Item("Moqty").ToString, "0")
            Me.LblPPIDPrinted.Text = IIf(Dgread.Rows(0).Item("Ppidprtqty").ToString <> "", Dgread.Rows(0).Item("Ppidprtqty").ToString, "0")
            Me.LblCartonPrinted.Text = IIf(Dgread.Rows(0).Item("Pkgprtqty").ToString <> "", Dgread.Rows(0).Item("Pkgprtqty").ToString, "0")
            Me.LblPackqty.Text = IIf(Dgread.Rows(0).Item("Qty").ToString <> "", Dgread.Rows(0).Item("Qty").ToString, "0")
            Me.LblDeptName.Text = Dgread.Rows(0).Item("deptname").ToString
            Dim deptid As String = Dgread.Rows(0).Item("deptid").ToString
            Dim lineid As String = Dgread.Rows(0).Item("lineid").ToString
            '此處加載線別，應該加入廠區的條件，才能保持和打印作業一致并且合理。 modi by frankie 20110715
            'LoadM.LoadDataToTSComboBox("select lineid from Deptline_t where deptid='" & Me.LblDeptName.Text.Trim.Split("-")(0) & "' and usey='Y' order by lineid", Me.CboLineid1)
            'LoadM.LoadDataToTSComboBox("select a.lineid from Deptline_t as a join m_Mainmo_t as b on a.deptid=b.deptid and a.factoryid=b.factory and b.moid='" & Me.TxtMoid1.Text.Trim & "' and a.usey='Y' order by a.lineid", Me.CboLineid1)
            Dim dt As DataTable = VbCommClass.CommClass.GetDeptLineDt(deptid)

            CboLineid1.Items.Clear()
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                CboLineid1.Items.Add(dt.Rows(rowIndex)(0).ToString)
            Next
            CboLineid1.Text = lineid

            If VbCommClass.VbCommClass.Factory = "BZLANTO" Then
                Me.CboLineid1.Text = LoadLine
            End If
            If opFlag = 1 Then GetMoidToRefresh(Me.TxtMoid1.Text.Trim)
        Else
            Me.CboLineid1.Items.Clear()
            Me.LblMoidqty.Text = "0"
            Me.LblPPIDPrinted.Text = "0"
            Me.LblCartonPrinted.Text = "0"
            Me.LblPackqty.Text = "0"
            Me.LblDeptName.Text = ""
            Me.DgTask.Rows.Clear()
        End If

    End Sub

    Private Sub TxtMoid1_Leave(sender As Object, e As EventArgs) Handles TxtMoid1.Leave
        If Not String.IsNullOrEmpty(TxtMoid1.Text) Then
            Dim sql As String = "SELECT A.PARTID ,A.LINEID,ISNULL(A.MOQTY,0) MOQTY,B.PACKID FROM M_MAINMO_T A LEFT JOIN M_PARTPACK_T  B ON  A.PARTID=B.PARTID WHERE A.MOID='" & TxtMoid1.Text & "' AND B.CODERULEID NOT IN('N029','N033') AND B.USEY='Y' "
            'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Try
                Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
                    If dt.Rows.Count > 0 Then
                        TxtPartid1.Text = dt.Rows(0)("PARTID").ToString
                        CboLineid1.Text = dt.Rows(0)("LINEID").ToString
                        LoadLine = dt.Rows(0)("LINEID").ToString
                        ChkPPID.Enabled = False
                        ChkCarton.Enabled = False
                        ChkNppid.Enabled = False
                        ChkNserier.Enabled = False
                        chkAttached.Enabled = False

                        If Not String.IsNullOrEmpty(dt.Rows(0)("PARTID").ToString) Then
                            For Each dr As DataRow In dt.Rows
                                If dr("PACKID") = "N" Then
                                    ChkNppid.Enabled = True
                                End If
                                If dr("PACKID") = "S" Then
                                    ChkPPID.Enabled = True
                                End If
                                If dr("PACKID") = "C" Then
                                    ChkCarton.Enabled = True
                                End If
                                If dr("PACKID") = "P" Then
                                    ChkNserier.Enabled = True
                                End If
                                If dr("PACKID") = "A" Then
                                    chkAttached.Enabled = True
                                End If
                            Next
                        Else
                            ChkPPID.Enabled = True
                            ChkCarton.Enabled = True
                            ChkNppid.Enabled = True
                            ChkNserier.Enabled = True
                            chkAttached.Enabled = True
                        End If
                    End If
                End Using
            Catch ex As Exception
                'Finally
                '    Conn.PubConnection.Close()
            End Try
        End If
    End Sub
    Dim factory As String = "LX53,WANXUN,M02600,JIZHOU,XINYU,LX21,COCRXIN,BZLANTO,CHUZHOU"
    Private Function AsapCheck()
        If factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
            If (String.IsNullOrEmpty(txtPnLable.Text)) Then
                txtPnLable.Focus()
                MsgBox("请输入标签料号！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
            End If
            Dim sql As String = "SELECT SUM(PRTQTY) qty FROM m_SnAssign_t WHERE MOID='" & TxtMoid1.Text & "' AND PACKID='" & CboPackItem.Text.Substring(0, 1) & "' AND PACKITEM='" & CboPackItem.SelectedValue.ToString & "' AND ESTATEID NOT IN(3,4) GROUP BY MOID"
            'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim qty As Integer = 0
            Try
                Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
                    If dt.Rows.Count > 0 Then
                        qty = Int(dt.Rows(0)("qty").ToString)
                    End If
                End Using
                If TxtPPIDqty.Enabled = True Then qty = qty + IIf(String.IsNullOrEmpty(TxtPPIDqty.Text), 0, Int(TxtPPIDqty.Text))
                If TxtCartonqty.Enabled = True Then qty = qty + IIf(String.IsNullOrEmpty(TxtCartonqty.Text), 0, Int(TxtCartonqty.Text))
                If TxtNqty.Enabled = True Then qty = qty + IIf(String.IsNullOrEmpty(TxtNqty.Text), 0, Int(TxtNqty.Text))
                If TxtNserierQty.Enabled = True Then qty = qty + IIf(String.IsNullOrEmpty(TxtNserierQty.Text), 0, Int(TxtNserierQty.Text))
                If txtAttachedQty.Enabled = True Then qty = qty + IIf(String.IsNullOrEmpty(txtAttachedQty.Text), 0, Int(txtAttachedQty.Text))
                If qty > Int(LblMoidqty.Text) Then
                    MessageBox.Show(String.Format("该工单申请标签数量{0}已经超出工单生产数量{1}", qty, LblMoidqty.Text))
                End If
            Catch ex As Exception
                'Finally
                '    If Not Conn Is Nothing Then
                '        Conn.PubConnection.Close()
                '    End If
            End Try
        End If
        Return False
    End Function

    Private Sub INITCONTROL(ByVal PACKID As String)
        If PACKID = ChkPPID.Name Then
            ChkNppid.Checked = False
            TxtNqty.Enabled = False
            ChkCarton.Checked = False
            TxtCartonqty.Enabled = False
            ChkNserier.Checked = False
            TxtNserierQty.Enabled = False
            chkAttached.Checked = False
            txtAttachedQty.Enabled = False
        ElseIf PACKID = ChkCarton.Name Then
            ChkNppid.Checked = False
            TxtNqty.Enabled = False
            ChkPPID.Checked = False
            TxtPPIDqty.Enabled = False
            ChkNserier.Checked = False
            TxtNserierQty.Enabled = False
            chkAttached.Checked = False
            txtAttachedQty.Enabled = False
        ElseIf PACKID = ChkNserier.Name Then
            ChkNppid.Checked = False
            TxtNqty.Enabled = False
            ChkPPID.Checked = False
            TxtPPIDqty.Enabled = False
            ChkCarton.Checked = False
            TxtCartonqty.Enabled = False
            chkAttached.Checked = False
            txtAttachedQty.Enabled = False
        ElseIf PACKID = chkAttached.Name Then
            ChkNppid.Checked = False
            TxtNqty.Enabled = False
            ChkPPID.Checked = False
            TxtPPIDqty.Enabled = False
            ChkCarton.Checked = False
            TxtCartonqty.Enabled = False
            ChkNserier.Checked = False
            TxtNserierQty.Enabled = False
        ElseIf PACKID = ChkNppid.Name Then
            ChkPPID.Checked = False
            TxtPPIDqty.Enabled = False
            chkAttached.Checked = False
            txtAttachedQty.Enabled = False
            ChkCarton.Checked = False
            TxtCartonqty.Enabled = False
            ChkNserier.Checked = False
            TxtNserierQty.Enabled = False
        End If
    End Sub

    Dim drv As DataRowView
    Private Sub CboPackItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPackItem.SelectedIndexChanged
        If factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
            Try
                If Not CboPackItem.SelectedItem Is Nothing Then
                    drv = CType(CboPackItem.SelectedItem, DataRowView)
                    If drv.Item(1).Substring(0, 1) = "N" Then
                        ' TxtNqty.Text = LblMoidqty.Text
                        TxtPPIDqty.Clear()
                        TxtCartonqty.Clear()
                        TxtNserierQty.Clear()
                        txtAttachedQty.Clear()
                    End If
                    If drv.Item(1).Substring(0, 1) = "S" Then
                        'TxtPPIDqty.Text = LblMoidqty.Text
                        TxtNqty.Clear()
                        TxtCartonqty.Clear()
                        TxtNserierQty.Clear()
                        txtAttachedQty.Clear()
                    End If
                    If drv.Item(1).Substring(0, 1) = "C" Then
                        'TxtCartonqty.Text = LblMoidqty.Text
                        TxtNqty.Clear()
                        TxtPPIDqty.Clear()
                        TxtNserierQty.Clear()
                        txtAttachedQty.Clear()

                        'BZLANTO存在多外箱标签情况,需要每次调整外箱标签时调整对应的外箱箱装数量  hzf 2017-10-28 10:51:52
                        If VbCommClass.VbCommClass.Factory = "BZLANTO" Or VbCommClass.VbCommClass.Factory = "CHUZHOU" Then
                            Dim sql As String = "select Qty from m_PartPack_t where Partid='" & TxtPartid1.Text & "' AND PACKID='" & CboPackItem.Text.Substring(0, 1) & "' and Packitem='" & CboPackItem.SelectedValue.ToString & "'"
                            'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
                            Try
                                Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
                                    If dt.Rows.Count > 0 Then
                                        LblPackqty.Text = dt.Rows(0)("Qty").ToString
                                    End If
                                End Using
                            Catch ex As Exception
                                'Finally
                                '    Conn.PubConnection.Close()
                            End Try
                        End If
                    End If
                    If drv.Item(1).Substring(0, 1) = "P" Then
                        'TxtNserierQty.Text = LblMoidqty.Text
                        TxtNqty.Clear()
                        TxtPPIDqty.Clear()
                        TxtCartonqty.Clear()
                        txtAttachedQty.Clear()
                    End If
                    If drv.Item(1).Substring(0, 1) = "K" Then
                        'txtAttachedQty.Text = LblMoidqty.Text
                        TxtNqty.Clear()
                        TxtPPIDqty.Clear()
                        TxtCartonqty.Clear()
                        TxtNserierQty.Clear()
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub CboPackItem_MouseHover(sender As Object, e As EventArgs) Handles CboPackItem.MouseHover
        ToolTip1.SetToolTip(CboPackItem, CboPackItem.Text)
    End Sub
End Class

#Region "DrawNewIco"

Public Class DataGridViewRolloverCell
    Inherits DataGridViewTextBoxCell

    Private mImageFlag As Boolean = False

    Protected Overrides Sub Paint( _
        ByVal graphics As Graphics, _
        ByVal clipBounds As Rectangle, _
        ByVal cellBounds As Rectangle, _
        ByVal rowIndex As Integer, _
        ByVal elementState As DataGridViewElementStates, _
        ByVal value As Object, _
        ByVal formattedValue As Object, _
        ByVal errorText As String, _
        ByVal cellStyle As DataGridViewCellStyle, _
        ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, _
        ByVal paintParts As DataGridViewPaintParts)

        ' Call the base class method to paint the default cell appearance.
        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, _
            value, formattedValue, errorText, cellStyle, _
            advancedBorderStyle, paintParts)

        If Me.ImageFlag = True Then
            Dim img As Image
            img = My.Resources.new1

            Dim newRect As New Rectangle(cellBounds.X + cellBounds.Width - img.Width - 1, cellBounds.Y + img.Height / 2, img.Width, img.Height)
            graphics.DrawImageUnscaledAndClipped(img, newRect)
        End If

    End Sub

    Public Property ImageFlag() As Boolean
        Get
            Return mImageFlag
        End Get
        Set(ByVal value As Boolean)
            mImageFlag = value
            Me.DataGridView.InvalidateCell(Me)
        End Set
    End Property

End Class

Public Class DataGridViewRolloverCellColumn
    Inherits DataGridViewColumn

    Public Sub New()
        Me.CellTemplate = New DataGridViewRolloverCell()
    End Sub

End Class

#End Region
