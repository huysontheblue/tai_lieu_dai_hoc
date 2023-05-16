
'--打印下載申請作業
'--Create by :　馬鋒
'--Create date :　2014/07/03
'--Ver : V01
'--Update by : 
'--Update date : 
'--Update Content: 

#Region "Imports"

Imports System.Windows.Forms
Imports BarCodePrint.SqlClassM
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports SysBasicClass

#End Region

Public Class FrmTiptopPrtTask

#Region "窗體變量"

    Dim LoadM As New SqlClassM      '定義主資源對象
    Dim opFlag As Int16 = 0
    Dim GSqlstr As New StringBuilder
    Dim Gsqlplace As Int16
    Dim CurrTaskid As String = ""
    Dim dvTiptopLot As New DataView
    Dim TemplateStatus As Boolean = False    '模板状态
    Dim Factory As String = VbCommClass.VbCommClass.Factory
    Dim profitcenter As String = VbCommClass.VbCommClass.profitcenter
    Dim UseId As String = VbCommClass.VbCommClass.UseId
    Dim IsConSap As String = VbCommClass.VbCommClass.IsConSap

#End Region

#Region "窗體初始化"

    Private Sub FrmTiptopPrtTask_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
    '窗體登錄事件
    Private Sub FrmTiptopPrtTask_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SysMessageClass.UseId = "sz17690"
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)

        GSqlstr.Append("select a.Ptaskid,case a.Estateid when '1' then '1-待打印' when '2' then '2-打印中' when '3' then '3-被驳回' when '4' then '4-被作废' when '5' then '5-待領取' when '6' then '6-已完成' end as Estateid," _
                    & " case a.Packid when 'S' then 'S-產品條碼標籤' when 'C' then 'C-外箱條碼標籤' when 'P' then 'P-棧板條碼標簽'  when 'N' then 'N-無流水號標簽' end as LabelType,a.Lineid,a.Moid,b.Partid,h.KLabelid,g.Remark as Labelid,a.prtQty,substring(convert(varchar(16),a.Demandtime,21),6,11) as Demandtime,h.PrinterID,h.PTemperature,h.CarbonTape," _
                    & " f.Deptid + '-' + f.djc as Deptname,e.Username as Printuser,substring(convert(varchar(16),a.Printtime,21),6,11) as Printtime,c.Username,substring(convert(varchar(16),a.Intime,21),6,11) as Intime,d.Username as Takeuser," _
                    & " substring(convert(varchar(16),a.Taketime,21),6,11) as Taketime,a.Remark,b.factory,djmdc,shift,linejm,FileVerNo,DriFlag,BuildAttribute " _
                    & " from m_SnAssign_t as a join m_Mainmo_t as b on a.Moid=b.Moid left join m_Dept_t as f on b.Deptid=f.Deptid and b.factory=f.factoryid left join m_Users_t as c " _
                    & " on a.userid=c.userid left join m_Users_t as d on a.Takeuser=d.userid left join m_Users_t as e on a.Printuser=e.userid left join m_PartPack_t as g on b.Partid=g.Partid and a.Packid=g.Packid and g.Usey='Y' " _
                    & " left join m_SnPFormat_t as h on g.PFormatID=h.PFormatID and h.UseY='Y' left join Deptline_t j on f.deptid=j.deptid and a.lineid=j.lineid and b.Factory='" & VbCommClass.VbCommClass.Factory & "' and b.profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'")
        Gsqlplace = GSqlstr.Length
        'LoadM.LoadDataToTSComboBox("select deptid + '-' + djc as deptname from m_Dept_t where dtype='R' and usey='Y' order by deptid", Me.CboDeptname)
        Me.CboDeptname.Items.Insert(0, "ALL")
        LoadM.SetSplitContainer(Me.SplitContainer1)
        LoadM.SetSplitContainer(Me.SplitContainer2)

        FillCombox(CboFactory)
        FillCombox(CboMoType)
        FillCombox(CboDept)
        FillCombox(CboCust)
        FillCombox(CboRuleid)

        SetStatus(opFlag)
        init()
        ClearObject()
        ComShift.SelectedIndex = 0
        Me.CboDept.SelectedIndex = -1
        Me.CboRuleid.SelectedIndex = -1
        Me.CboCust.SelectedIndex = -1

    End Sub
    '加載數據到數據表格
    Private Sub LoadDataToDgrid(ByVal Sqlstr As String, ByRef DGrid As DataGridView)

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            DGrid.Rows.Clear()
            DReader = Conn.GetDataReader(Sqlstr)
            Do While DReader.Read()
                DGrid.Rows.Add(DReader.Item("Ptaskid").ToString, DReader.Item("Estateid").ToString, DReader.Item("LabelType").ToString, DReader.Item("Lineid").ToString, DReader.Item("Moid").ToString, _
                               DReader.Item("Partid").ToString, DReader.Item("KLabelid").ToString, DReader.Item("Labelid").ToString, DReader.Item("prtQty").ToString, DReader.Item("Demandtime").ToString, DReader.Item("PrinterID").ToString, DReader.Item("PTemperature").ToString, DReader.Item("CarbonTape").ToString, DReader.Item("Deptname").ToString, DReader.Item("Printuser").ToString, _
                               DReader.Item("Printtime").ToString, DReader.Item("Username").ToString, DReader.Item("Intime").ToString, DReader.Item("Takeuser").ToString, DReader.Item("Taketime").ToString, DReader.Item("Remark").ToString, DReader.Item("factory").ToString, DReader.Item("djmdc").ToString, DReader.Item("shift").ToString, DReader.Item("linejm").ToString, _
                               DReader.Item("FileVerNo").ToString, DReader.Item("DriFlag").ToString, DReader.Item("BuildAttribute").ToString)
            Loop
            Me.ToolLblCount.Text = DGrid.Rows.Count
            DReader.Close()
            Conn.PubConnection.Close()
            Conn = Nothing
        Catch ex As Exception
            'DReader.Close()
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
                Me.ToolQuery.Enabled = False
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
                Me.ToolQuery.Enabled = True
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
        Me.CboLineid1.DataSource = Nothing
        Me.CboLineid1.Items.Clear()
        Me.CboTemplate.DataSource = Nothing
        Me.CboTemplate.Items.Clear()
        Me.ChkCarton.Checked = False
        Me.ChkNserier.Checked = False
        Me.ChkPPID.Checked = False
        Me.ChkNserier.Enabled = True
        Me.ChkCarton.Enabled = True
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

        '料件碼元設置信息
        Me.txtCoding.Text = ""
        Me.txtVersion.Text = ""
        Me.txtTitle1.Text = ""
        Me.txtTitle2.Text = ""
        Me.txtTitle3.Text = ""

        Dim strBeforePrint As String    '提前時間
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim Dgread As SqlClient.SqlDataReader
        Dgread = Conn.GetDataReader("select sortname from m_sortset_t where sortID='BPrint' and usey='Y'")
        If Dgread.Read Then
            strBeforePrint = Dgread.Item("sortname").ToString
        Else
            strBeforePrint = 90
        End If
        Dgread.Close()
        If IsNumeric(strBeforePrint) = False Or strBeforePrint = "" Then
            strBeforePrint = 90
        End If
        Me.DtMoNeedTime.Value = Now.AddMinutes(CInt(strBeforePrint) + 5)
        Me.LblPPIDPrinted.Text = "0"
        Me.LblCartonPrinted.Text = "0"
        'Me.LblDeptName.Text = ""
        Me.LblMoidqty.Text = "0"
        Me.TxtTaskDesc.Text = ""
        Me.txtPackingCapacity.Text = "0"
        Me.LblTaskid.Text = ""
    End Sub

    Private Sub SetObject()
        Try
            Me.TxtMoid1.Text = Me.DgTask.Item(4, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
            Me.TxtPartid1.Text = Me.DgTask.Item(5, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
            Me.ChkCarton.Checked = IIf(Me.DgTask.Item(2, Me.DgTask.CurrentRow.Index).Value.ToString.Trim = "C-外箱標簽", True, False)
            Me.ChkNppid.Checked = IIf(Me.DgTask.Item(2, Me.DgTask.CurrentRow.Index).Value.ToString.Trim = "N-無流水號標簽", True, False)
            Me.ChkPPID.Checked = IIf(Me.DgTask.Item(2, Me.DgTask.CurrentRow.Index).Value.ToString.Trim = "S-產品標簽", True, False)
            'Me.ChkCarton.Enabled = IIf(Me.DgTask.Item(2, Me.DgTask.CurrentRow.Index).Value.ToString.Trim = "C-外箱條碼", True, False)
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
            'Me.LblDeptName.Text = Me.DgTask.Item(13, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
            Me.TxtTaskDesc.Text = Me.DgTask.Item(20, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
            Me.CboLineid1.Text = Me.DgTask.Item(3, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
            Me.LblTaskid.Text = Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim
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
        Me.CboMoType.SelectedIndex = -1
        Me.CboDept.SelectedIndex = -1
        Me.CboRuleid.SelectedIndex = -1
        Me.CboCust.SelectedIndex = -1


    End Sub
    '編輯任務
    Private Sub ToolEditTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEditTask.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫連接對象
        Dim Dtable As New DataTable
        Try
            Me.Timer.Enabled = False
            If Me.DgTask.Rows.Count = 0 OrElse Me.DgTask.CurrentRow Is Nothing Then Me.Timer.Enabled = True : Exit Try
            Dtable = Conn.GetDataTable("select Estateid from m_SnAssign_t where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim & "'")
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
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmTiptopPrtTask", "ToolEditTask_Click", "sys")
        End Try
    End Sub
    '作廢任務
    Private Sub ToolDelTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDelTask.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫連接對象
        Dim Dtable As New DataTable
        Try
            Me.Timer.Enabled = False
            If Me.DgTask.Rows.Count = 0 OrElse Me.DgTask.CurrentRow Is Nothing Then Exit Try
            Dtable = Conn.GetDataTable("select Estateid from m_SnAssign_t where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim & "'")
            If Dtable.Rows.Count > 0 Then
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
            If CheckRight(Me.DgTask.Item(4, Me.DgTask.CurrentRow.Index).Value.ToString) = False Then Exit Try
            If MessageBox.Show("請確認是否要作廢單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]?", "系統提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Try

            Conn.ExecSql("Update m_SnAssign_t set Estateid='4',userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & "'")
            MessageBox.Show("單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]已被作廢！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmTiptopPrtTask", "ToolDelTask_Click", "sys")
        Finally
            Me.Timer.Enabled = True
        End Try
    End Sub
    '提交任務
    Private Sub ToolCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCommit.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
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

            If opFlag = 1 Then '新增申請單
                Sqlstr.Append("declare @Taskid varchar(11) declare @Taskid1 varchar(11) declare @Taskid2 varchar(11) declare @Taskid4 varchar(11) DECLARE @ERROR_MSG NVARCHAR(128) ")
                If Me.ChkPPID.Checked Then
                    '獲得申請單號
                    Sqlstr.Append(" select @Taskid=Ptaskid from m_SnAssign_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " _
                                & " if @@rowcount=0 begin set @Taskid='T' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " _
                                & " set @Taskid=left(@Taskid,7) + right(Replicate('0',4) + cast(right(@Taskid,4)+1 as varchar),4) End BEGIN TRANSACTION ")
                    'insert 語句
                    Shift = IIf(Me.ComShift.SelectedIndex = 0, "D", "N")
                    If Me.ComShift.SelectedIndex = -1 Then
                        Shift = ""
                    End If
                    Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute) " _
                                & " values(@Taskid,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','S'," & Int(Me.TxtPPIDqty.Text.ToString.Trim) _
                                & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1'," & _
                                " N'" & Me.TxtTaskDesc.Text.ToString.Trim & "','" & Shift & "','" & TxtPPidVER.Text.Trim & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text.Trim & "')")
                End If
                If Me.ChkCarton.Checked Then
                    PrtQty = 0
                    Remark = Me.TxtTaskDesc.Text.Trim
                    If String.IsNullOrEmpty(Me.TxtCartonqty.Text.Trim) = False Then
                        PrtQty = Int(Me.TxtCartonqty.Text.Trim)
                    End If
                    If String.IsNullOrEmpty(Me.TxtPCartonqty.Text.Trim) = False Then
                        PrtQty = PrtQty + 1
                        Remark = Remark + ControlChars.CrLf + "含尾箱,其裝箱數量:" + Me.TxtPCartonqty.Text.Trim
                    End If
                    Shift = IIf(Me.ComShift.SelectedIndex = 0, "D", "N")
                    If Me.ComShift.SelectedIndex = -1 Then
                        Shift = ""
                    End If
                    '獲得申請單號
                    Sqlstr.Append(" select @Taskid1=Ptaskid from m_SnAssign_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " _
                                 & " if @@rowcount=0 begin set @Taskid1='T' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " _
                                 & " set @Taskid1=left(@Taskid1,7) + right(Replicate('0',4) + cast(right(@Taskid1,4)+1 as varchar),4) End BEGIN TRANSACTION ")
                    'insert 語句
                    Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute) " _
                                 & " values(@Taskid1,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','C'," & PrtQty _
                                 & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "'," _
                                 & " getdate(),'1',N'" & Remark & "','" & Shift & "','" & TxtPackVer.Text & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text & "')")
                End If
                Shift = IIf(Me.ComShift.SelectedIndex = 0, "D", "N")
                If Me.ComShift.SelectedIndex = -1 Then
                    Shift = ""
                End If
                If Me.ChkNserier.Checked Then
                    '獲得申請單號
                    Sqlstr.Append(" select @Taskid2=Ptaskid from m_SnAssign_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " _
                                 & " if @@rowcount=0 begin set @Taskid2='T' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " _
                                 & " set @Taskid2=left(@Taskid2,7) + right(Replicate('0',4) + cast(right(@Taskid2,4)+1 as varchar),4) End BEGIN TRANSACTION ")
                    'insert 語句
                    Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute) " _
                                 & " values(@Taskid2,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','P'," & Int(Me.TxtNserierQty.Text.ToString.Trim) _
                                 & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate(),'1'," _
                                 & " N'" & Me.TxtTaskDesc.Text.ToString.Trim & "','" & Shift & "','" & TxtPalletVer.Text & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text & "')")
                End If

                If Me.ChkNppid.Checked Then
                    '獲得申請單號
                    Sqlstr.Append(" select @Taskid4=Ptaskid from m_SnAssign_t where convert(varchar(10),cast(substring(Ptaskid,2,6) as datetime),21) = Convert(varchar(10), getdate(), 21) order by ptaskid  " _
                                 & " if @@rowcount=0 begin set @Taskid4='T' + right(convert(varchar(8),getdate(),112),6) + '0001' End Else begin " _
                                 & " set @Taskid4=left(@Taskid4,7) + right(Replicate('0',4) + cast(right(@Taskid4,4)+1 as varchar),4) End BEGIN TRANSACTION ")
                    'insert 語句
                    Sqlstr.Append(" insert m_SnAssign_t(Ptaskid, Lineid, Moid, Packid, PrtQty, Demandtime, Userid, Intime, Estateid, Remark,shift,FileVerNo,DriFlag,BuildAttribute) " _
                                 & " values(@Taskid4,'" & Me.CboLineid1.Text.Trim.ToUpper & "','" & Me.TxtMoid1.Text.Trim & "','N'," & Int(Me.TxtNqty.Text.ToString.Trim) _
                                 & ",cast('" & Me.DtMoNeedTime.Value.ToString("yyyy-MM-dd HH:mm") & "' as datetime),'" & SysMessageClass.UseId.ToLower & "',getdate()," _
                                 & "'1',N'" & Me.TxtTaskDesc.Text.ToString.Trim & "','" & Shift & "','" & TxtNoVer.Text & "','" & TxtDriFlag.Text.Trim & "','" & TxtBuildAttribute.Text & "')")
                End If

                Dim PartDesc As String
                If Not dvTiptopLot Is Nothing Then
                    PartDesc = dvTiptopLot.Item(0).Item("partDesc").ToString()
                Else
                    PartDesc = ""
                End If

                '工单料件信息   " & Me.DtMoNeedTime.Text.Trim() & "
                Sqlstr.Append("IF NOT EXISTS(SELECT TAvcPart FROM m_PartContrast_t WHERE TAvcPart=N'" & Me.TxtPartid1.Text.Trim() & "') " _
                & " BEGIN  " _
                & "    INSERT INTO m_PartContrast_t(TAvcPart, PartName, PAvcPart, CusID, CustPart, MethodID, UseY, LmtY, WarnDate, Userid, Intime, TypeDest, PartCode, " _
                & "            Supplierid, IsUpload, Isasseble, IsLotScan, IsAlter, MaterialAlter, IsPrintFile, IsTransOracle, IsChkTransData) " _
                & "     VALUES(N'" & Me.TxtPartid1.Text.Trim() & "',NULL,N'" & Me.TxtPartid1.Text.Trim() & "',N'" & Me.CboCust.SelectedValue.ToString() & "',N'" & Me.TxtPartid1.Text.Trim() & "',NULL,'Y',365,7,'" & VbCommClass.VbCommClass.UseId & "',GETDATE(),N'" & PartDesc & "',NULL,NULL,'N','N','N','N','N',NULL,NULL,'N') " _
                & " End " _
                & " IF NOT EXISTS(SELECT Moid FROM m_Mainmo_t WHERE Moid=N'" & Me.TxtMoid1.Text.Trim() & "') " _
                & " BEGIN  " _
                & "     INSERT INTO m_Mainmo_t(Moid, Orderseq, Tmoid, PartID, Cusid, Deptid, Lineid, Moqty, Outqty, Notqty, Scrapqty, Ppidprtqty, Pkgprtqty, Typeid, " _
                & "                EstateID, Routeid, Plandate, Createuser, Createtime, FinalY, Finalqty, Remark, Finalman, Finaltime, States, Factory, " _
                & "                profitcenter, IsLotOk, ParentMo) " _
                & "     VALUES('" & Me.TxtMoid1.Text.Trim() & "',NULL,NULL,'" & Me.TxtPartid1.Text.Trim() & "','" & Me.CboCust.SelectedValue.ToString() & "','" & Me.CboDept.SelectedValue.ToString() & "','" & Me.CboLineid1.SelectedValue.ToString() & "', " _
                & "  '" & Me.LblMoidqty.Text.Trim() & "',NULL,NULL,NULL,0,NULL,'" & Me.CboMoType.SelectedValue.ToString() & "',5,NULL,getdate(),'" & VbCommClass.VbCommClass.UseId & "',GETDATE(),'N',NULL,NULL,'" & VbCommClass.VbCommClass.UseId & "',GETDATE(),NULL,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','N','" & Me.TxtMoid1.Text.Trim() & "') " _
                & " End " _
                & " COMMIT TRANSACTION" _
                & " if @@error>0  " _
                & " BEGIN " _
                & "     SET @ERROR_MSG=N'保存失败，请联系开发人员!' " _
                & "     ROLLBACK TRANSACTION  " _
                & " End")

                '返回申請單號
                Sqlstr.Append(ControlChars.CrLf & "select @ERROR_MSG AS ERROR_MSG,@Taskid as Taskid0,@Taskid1 as Taskid1,@Taskid2 as Taskid2,@Taskid4 as Taskid4")
                RecTable = Conn.GetDataTable(Sqlstr.ToString)


                If Not RecTable Is Nothing Then
                    If Not String.IsNullOrEmpty(RecTable.Rows(0)("ERROR_MSG").ToString()) Then
                        SetMessage(RecTable.Rows(0)("ERROR_MSG").ToString())
                        Return
                    End If
                End If

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
                ElseIf String.IsNullOrEmpty(Me.TxtCartonqty.Text.Trim) = False Then
                    PrtQty = Int(Me.TxtCartonqty.Text.Trim)
                ElseIf Me.ChkNserier.Enabled = True AndAlso Me.ChkNserier.Checked = True Then
                    PrtQty = Int(Me.TxtNserierQty.Text.Trim)
                End If
                If String.IsNullOrEmpty(Me.TxtPCartonqty.Text.Trim) = False Then
                    PrtQty = PrtQty + 1
                    Remark = Remark + ControlChars.CrLf + "含尾箱,其裝箱數量:" + Me.TxtPCartonqty.Text.Trim
                End If
                Sqlstr.Append("update m_SnAssign_t set Estateid=1,Moid='" & Me.TxtMoid1.Text.Trim & "',Lineid='" & Me.CboLineid1.Text.Trim.ToUpper _
                             & "',PrtQty=" & PrtQty & ",Demandtime=cast('" _
                             & Me.DtMoNeedTime.Value.ToString("yyyy/MM/dd HH:mm") & "' as datetime),Remark=N'" & Remark & "',Userid='" & _
                             SysMessageClass.UseId.ToLower & "',intime=getdate(),shift='" & Shift & "',FileVerNo='" & TxtFileVerNo.Text & "',DriFlag='" & TxtDriFlag.Text & "',BuildAttribute='" & TxtBuildAttribute.Text & "' where Ptaskid='" & Me.LblTaskid.Text.Trim & "'")
                Conn.ExecSql(Sqlstr.ToString)
                CurrTaskid.Append(Me.LblTaskid.Text.Trim)
            End If
            GetTaskToRefresh(CurrTaskid.ToString)
            'MsgBox("操作成功！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")

            opFlag = 0
            SetStatus(opFlag)
            ClearObject()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmTiptopPrtTask", "ToolCommit_Click", "sys")
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
    '匯出Excel
    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        Dim ExportClass As New MainFrame.SysDataHandle.SysDataBaseClass
        If Me.DgTask.Rows.Count = 0 Then Exit Sub
        'ExportClass.InportInExcel(GSqlstr.ToString, "打印申請作業", Me.DgTask)
    End Sub
    '駁回任務
    Private Sub ToolBTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBTask.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫連接對象
        Dim Dtable As New DataTable
        Try
            Me.Timer.Enabled = False
            If Me.DgTask.Rows.Count = 0 OrElse Me.DgTask.CurrentRow Is Nothing Then Exit Try
            Dtable = Conn.GetDataTable("select Estateid from m_SnAssign_t where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim & "'")
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
            Conn.ExecSql("update m_SnAssign_t set Estateid=3,Remark=case Remark when '' then '" & BohuiMsg & "' else Remark + '/" & BohuiMsg & "' end,Printuser='" & SysMessageClass.UseId.Trim.ToString & "',Printtime=getdate() where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & "'")
            MessageBox.Show("單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]已被駁回！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmTiptopPrtTask", "ToolBTask_Click", "sys")
        Finally
            Me.Timer.Enabled = True
        End Try
    End Sub
    '條碼打印
    Private Sub ToolPrt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPrt.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim Dtable As SqlDataReader


        Try
            Me.Timer.Enabled = False
            'If Me.DgTask.Rows.Count = 0 OrElse Me.DgTask.CurrentRow Is Nothing Then Exit Try
            'If (DgTask.CurrentRow.Cells("Coldocfile").Value <> DgTask.CurrentRow.Cells("ColFileVerno").Value) Then
            '    MsgBox("料件的打印参数中图面版本号与打印申请的版本号不相同！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            '    Dtable.Dispose()
            '    Exit Try
            'End If
            Dim FinalYstr As String = ""
            Dtable = Conn.GetDataReader("select isnull(FinalY,'') FinalY from m_mainmo_t where moid='" & Me.DgTask.CurrentRow.Cells("Colmoid").Value.ToString & "'")
            If Dtable.HasRows Then
                While Dtable.Read
                    FinalYstr = Dtable!FinalY
                End While
            End If
            Dtable.Close()
            If FinalYstr = "Y" Then
                MsgBox("该工单已结案或已被冻结...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Exit Sub
            End If
            Dtable = Conn.GetDataReader("select Estateid from m_SnAssign_t where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim & "'")
            If Dtable.HasRows Then
                While Dtable.Read
                    If Dtable!Estateid.ToString.Trim <> "1" AndAlso Dtable!Estateid.ToString.Trim <> "2" Then
                        MsgBox("只有單據狀態為[ 待打印] 或者為[ 打印中] 的單據執行此操作！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                        Dtable.Close()
                        Exit Sub
                    End If
                End While
            Else
                MessageBox.Show("系統內不存在單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dtable.Close()
                Exit Sub
            End If
            Dtable.Close()

            Dim IsAllowPrintFile As String = ""
            If Me.ChkNotPrint.Checked Then
                Dtable = Conn.GetDataReader("select isnull(IsPrintFile,'') IsPrintFile from m_PartContrast_t where  TAvcPart=PAvcPart and TAvcPart='" & Me.DgTask.CurrentRow.Cells("ColPartid").Value.ToString & "'")
                If Dtable.HasRows Then
                    While Dtable.Read
                        IsAllowPrintFile = Dtable!IsPrintFile
                    End While
                End If
                Dtable.Close()
                If IsAllowPrintFile = "N" Then
                    MsgBox("该料号不允许生成打印CSV文件...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Exit Sub
                End If
            End If
            If Me.ChkNotPrint.Checked Then
                Dtable = Conn.GetDataReader("select IsLotOk from m_mainmo_t where moid='" & Me.DgTask.CurrentRow.Cells("Colmoid").Value.ToString() & "' and isnull(IsLotOk,'')='Y'")
                If Dtable.HasRows = False Then
                    Dtable.Close()
                    MsgBox("该工单仓库未进行来料批次扫描，不允许生成打印CSV文件...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                    Exit Sub
                End If
            End If
            Dtable.Close()
            '打印
            Dtable = Conn.GetDataReader("select a.Moid,b.Lineid,a.Cusid,c.CodeRuleID,b.Ptaskid,c.Packid from m_Mainmo_t as a join m_SnAssign_t as b " _
                                    & " on b.Moid=a.Moid and b.Estateid in('1','2') join m_PartPack_t as c on a.PartID=c.Partid and c.Packid=b.Packid and c.Usey='Y' " _
                                    & " where b.Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & "'")
            'Dim Sqlstr As String = ""
            If Dtable.HasRows Then
                Dim FrmBarM As New FrmBarM
                While Dtable.Read
                    '更新單據狀態
                    '調出打印界面d
                    FrmBarM.LoadM.CodeRule = Dtable!CodeRuleID.ToString
                    FrmBarM.LoadM.Taskid = Dtable!Ptaskid.ToString
                    FrmBarM.LoadM.DefaultMoid = Dtable!Moid.ToString
                    FrmBarM.LoadM.DefaultLine = Dtable!Lineid.ToString
                    FrmBarM.LoadM.CustID = Dtable!Cusid.ToString
                    FrmBarM.LoadM.Factory = Me.DgTask.CurrentRow.Cells("ColFac").Value.ToString
                    FrmBarM.LoadM.DeptJm = Me.DgTask.CurrentRow.Cells("ColDeptDc").Value.ToString
                    FrmBarM.LoadM.vShift = Me.DgTask.CurrentRow.Cells("Colshift").Value.ToString
                    FrmBarM.LoadM.vLineJm = Me.DgTask.CurrentRow.Cells("LineJm").Value.ToString
                    FrmBarM.LoadM.vRequestDate = Me.DgTask.CurrentRow.Cells("ColNeedDate").Value.ToString
                    FrmBarM.LoadM.vIsprint = IIf(Me.ChkNotPrint.Checked, "Y", "N")
                    FrmBarM.LoadM.vCodeType = Dtable!Packid.ToString
                    FrmBarM.LoadM.vVerNo = Me.DgTask.CurrentRow.Cells("ColFileVerno").Value.ToString
                    FrmBarM.LoadM.vDriFlag = Me.DgTask.CurrentRow.Cells("ColDriFlag").Value.ToString
                    FrmBarM.LoadM.vBuildAttribute = Me.DgTask.CurrentRow.Cells("BuildAttribute").Value.ToString
                End While
                Dtable.Close()
                FrmBarM.BnBulidBarCode_Click(sender, e)
            Else
                Dtable.Close()
                Exit Sub
            End If
            Conn.ExecSql("Update m_SnAssign_t set Estateid='2',Printuser='" & SysMessageClass.UseId.ToLower.Trim & "' where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & "'")
            RefreshGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmTiptopPrtTask", "ToolPrt_Click", "sys")
        Finally
            Me.Timer.Enabled = True
        End Try
    End Sub
    '打印完成
    Private Sub ToolFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolFinish.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫連接對象
        Dim Dtable As New DataTable
        Try
            Me.Timer.Enabled = False
            If Me.DgTask.Rows.Count = 0 OrElse Me.DgTask.CurrentRow Is Nothing Then Exit Try
            Dtable = Conn.GetDataTable("select Estateid from m_SnAssign_t where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim & "'")
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

            Conn.ExecSql("update m_SnAssign_t set Estateid=5,Printtime=getdate() where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & "'")
            MessageBox.Show("單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]打印完成狀態已更新！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmTiptopPrtTask", "ToolFinish_Click", "sys")
        Finally
            Me.Timer.Enabled = True
        End Try
    End Sub
    '單據結案
    Private Sub ToolStopTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStopTask.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫連接對象
        Dim Dtable As New DataTable
        Try
            Me.Timer.Enabled = False
            If Me.DgTask.Rows.Count = 0 OrElse Me.DgTask.CurrentRow Is Nothing Then Exit Try
            Dtable = Conn.GetDataTable("select Estateid from m_SnAssign_t where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString.Trim & "'")
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

            Conn.ExecSql("update m_SnAssign_t set Estateid=6,Taketime=getdate() where Ptaskid='" & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & "'")
            MessageBox.Show("單據[ " & Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString & " ]已結案！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmTiptopPrtTask", "ToolStopTask_Click", "sys")
        Finally
            Me.Timer.Enabled = True
        End Try
    End Sub
    '退出
    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click
        dvTiptopLot = Nothing
        Me.Close()
    End Sub

#End Region

#Region "Bind"

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)

        Dim UserDg As DataTable
        Dim DataHand As New MainFrame.SysDataHandle.SysDataBaseClass

        If ColComboBox.Name = "CboMoType" Then
            UserDg = DataHand.GetDataTable("select typeid,motype from motype_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "motype"
            ColComboBox.ValueMember = "typeid"
        ElseIf ColComboBox.Name = "CboDept" Then
            UserDg = DataHand.GetDataTable("select djc as djc,deptid from   m_Dept_t where factoryid='" & CboFactory.SelectedValue.ToString() & "' and deptid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='10109_' and userid='" & SysMessageClass.UseId & "')")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "djc"
            ColComboBox.ValueMember = "deptid"
        ElseIf ColComboBox.Name = "CboCust" Then
            UserDg = DataHand.GetDataTable("Select  (CusID+'---'+CusName) CusName ,CusID from m_Customer_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "CusName"
            ColComboBox.ValueMember = "CusID"
        ElseIf ColComboBox.Name = "CboLineid1" Then
            UserDg = DataHand.GetDataTable("Select  lineid,lineid from Deptline_t where deptid='" & CboDept.SelectedValue.ToString() & "'")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "lineid"
            ColComboBox.ValueMember = "lineid"
        ElseIf ColComboBox.Name = "CboFactory" Then
            UserDg = DataHand.GetDataTable("Select  factoryid,shortname from m_Dcompany_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "shortname"
            ColComboBox.ValueMember = "factoryid"
        ElseIf ColComboBox.Name = "ComMoType" Then
            UserDg = DataHand.GetDataTable("Select  motype,typeid from motype_t")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "motype"
            ColComboBox.ValueMember = "typeid"
        ElseIf ColComboBox.Name = "CboRuleid" Then
            UserDg = DataHand.GetDataTable("select CodeRuleID,CodeRuleID + '-' + Remark as Ruleid from m_SnRuleM_t where LabelType='S' order by CodeRuleID")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "Ruleid"
            ColComboBox.ValueMember = "CodeRuleID"
        ElseIf ColComboBox.Name = "CboTemplate" Then
            UserDg = DataHand.GetDataTable("select PFormatID,KLabelid from m_SnPFormat_t  where CodeRuleID='" & Me.CboRuleid.SelectedValue.ToString() & "' and usey='Y' order by CodeRuleID")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "KLabelid"
            ColComboBox.ValueMember = "PFormatID"
        End If
        UserDg = Nothing

    End Sub
#End Region

#Region "Commbox"

    Private Sub CobFactory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboFactory.SelectedIndexChanged
        'CboDept.SelectedIndex = -1
        'CboLineid1.SelectedIndex = -1
    End Sub

    Private Sub CboDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDept.SelectedIndexChanged

        If Me.CboDept.SelectedIndex <> -1 Then
            CboLineid1.DataSource = Nothing
            FillCombox(CboLineid1)
            CboLineid1.SelectedIndex = -1
        Else
            Me.CboLineid1.DataSource = Nothing
            Me.CboLineid1.Items.Clear()
            Me.CboLineid1.SelectedIndex = -1
        End If

    End Sub

    Private Sub cboRuleid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRuleid.SelectedIndexChanged
        If Me.CboRuleid.SelectedIndex <> -1 Then
            FillCombox(Me.CboTemplate)
        Else
            Me.CboTemplate.DataSource = Nothing
            Me.CboTemplate.Items.Clear()
            Me.CboTemplate.SelectedIndex = -1
        End If
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
        Sqlstr.Append(" order by a.Demandtime")

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

#End Region

#Region "CheckData/CheckRight"

    Private Function CheckData() As Boolean
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim Dgread As SqlClient.SqlDataReader
        'CheckData
        'If TxtFileVerNo.Text.Trim = "" Then MsgBox("料件的版本编号不能为空！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
        If Me.TxtMoid1.Text.Trim = "" Then MsgBox("工單號不能為空！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
        If Me.TxtPartid1.Text.Trim = "" Then MsgBox("料件編號不能為空！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
        If Me.CboMoType.Text.Trim = "" Then MsgBox("請選擇工单类型！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
        If Me.CboCust.Text.Trim = "" Then MsgBox("請選擇客户！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
        If Me.CboLineid1.Text.Trim = "" Then MsgBox("請選擇生產線別！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
        If Me.CboRuleid.Text.Trim = "" Then MsgBox("请设定工单条码规则！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
        If Me.CboTemplate.Text.Trim = "" Then MsgBox("请设定条码打印模板！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示") : Return False
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
        If Me.ChkCarton.Checked = False AndAlso Me.ChkPPID.Checked = False AndAlso Me.ChkNserier.Checked = False AndAlso Me.ChkNppid.Checked = False Then
            MsgBox("請選擇打印條碼類型及輸入打印數量！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
            Return False
        End If
        If Me.ChkCarton.Checked Then
            '整數箱/尾數箱
            If String.IsNullOrEmpty(Me.TxtCartonqty.Text.Trim) = False Then
                MsgBox("請選擇外箱條碼打印類型及輸入數量！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                Return False
            End If
            'Check數量
            If String.IsNullOrEmpty(Me.TxtCartonqty.Text.Trim) = False OrElse Int(Me.TxtCartonqty.Text) <= 0 Then
                MsgBox("整數箱打印數量不能為空，不能小于！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                Return False
            End If
            If String.IsNullOrEmpty(Me.TxtPCartonqty.Text.Trim) = False Then
                If Me.TxtPCartonqty.Text.Trim = "" Then
                    MsgBox("尾數箱的裝箱數量不能為空！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                    Return False
                End If
                If Int(Me.TxtPCartonqty.Text.Trim) <= 0 Then
                    MsgBox("尾數箱的裝箱數量不能小于！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                    Return False
                End If
                If Int(Me.TxtPCartonqty.Text.Trim) >= Int(Me.txtPackingCapacity.Text.Trim) Then
                    MsgBox("尾數箱的裝箱數量不能大于或等于整數箱的裝箱數量！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                    Return False
                End If
            End If
            '檢查工單是否可以打印(打印下载作业，工单不存在，取消检查)
            Dim ReStr As String = LoadM.CheckMoid(Me.TxtMoid1.Text.Trim, "C", "")
            If ReStr <> "1" Then MsgBox(ReStr, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示") : Return False
        End If
        If Me.ChkPPID.Checked Then
            'Check數量
            If Me.TxtPPIDqty.Text = "" OrElse Int(Me.TxtPPIDqty.Text) <= 0 Then
                MsgBox("打印數量不能為空，不能小于！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                Return False
            End If
            '檢查工單是否可以打印
            'Dim ReStr As String = LoadM.CheckMoid(Me.TxtMoid1.Text.Trim, "S", "")
            'If ReStr <> "1" Then MsgBox(ReStr, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示") : Return False
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

    Private Sub Txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCartonqty.KeyPress, TxtPPIDqty.KeyPress, TxtNserierQty.KeyPress, TxtNqty.KeyPress
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
    '        Me.txtPackingCapacity.Text = IIf(Dgread.Item("Qty").ToString <> "", Dgread.Item("Qty").ToString, "0")
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
    '        Me.txtPackingCapacity.Text = "0"
    '        Me.LblDeptName.Text = ""
    '        Me.DgTask.Rows.Clear()
    '    End If
    '    Dgread.Close()
    'End Sub

    Private Sub ChkPPID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCarton.CheckedChanged, ChkPPID.CheckedChanged, ChkNserier.CheckedChanged, ChkNppid.CheckedChanged

        Me.TxtPPIDqty.Enabled = IIf(Me.ChkPPID.Enabled AndAlso Me.ChkPPID.Checked, True, False)
        Me.TxtNserierQty.Enabled = IIf(Me.ChkNserier.Enabled AndAlso Me.ChkNserier.Checked, True, False)

        Me.TxtCartonqty.Enabled = IIf(Me.ChkCarton.Checked, True, False)
        Me.TxtPCartonqty.Enabled = IIf(Me.ChkCarton.Checked, True, False)
        Me.TxtNqty.Enabled = IIf(Me.ChkNppid.Enabled AndAlso Me.ChkNppid.Checked, True, False)

        '2014-07-04        马锋    增加容量计算
        If Me.ChkCarton.Checked AndAlso String.IsNullOrEmpty(Me.TxtMoid1.Text.Trim()) = False Then
            If Int(Me.txtPackingCapacity.Text.Trim()) > 0 Then
                Dim NotPackingQty As Int16
                NotPackingQty = Int(Me.LblMoidqty.Text.Trim()) - Int(Me.LblCartonPrinted.Text) * Int(Me.txtPackingCapacity.Text.Trim())
                Dim d As Int16 = NotPackingQty Mod Int(Me.txtPackingCapacity.Text.Trim())

                If NotPackingQty Mod Int(Me.txtPackingCapacity.Text.Trim()) = 0 Then
                    Me.TxtCartonqty.Text = (NotPackingQty / Int(Me.txtPackingCapacity.Text.Trim())).ToString()
                Else
                    Me.TxtCartonqty.Text = (NotPackingQty / Int(Me.txtPackingCapacity.Text.Trim())).ToString()
                    Me.TxtPCartonqty.Text = (NotPackingQty Mod Int(Me.txtPackingCapacity.Text.Trim())).ToString()
                End If
            Else
                SetMessage("请设定料件参数包装容量")
            End If
        Else
            Me.TxtCartonqty.Text = "0"
            Me.TxtPCartonqty.Text = "0"
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
        CurrTaskid = Me.DgTask.Item(0, Me.DgTask.CurrentRow.Index).Value.ToString
        Me.LblRemark.Text = Me.DgTask.Item(20, Me.DgTask.CurrentRow.Index).Value.ToString.Replace(ControlChars.CrLf, " ; ")
    End Sub

#End Region

    'Private Sub TxtMoid1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMoid1.Leave

    '    If opFlag = 0 Then Exit Sub
    '    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
    '    Dim Dgread As SqlClient.SqlDataReader = Conn.GetDataReader(" select a.moid,a.Moqty,a.Ppidprtqty,a.Pkgprtqty,b.Qty,c.deptid + '-' + c.djc as deptname " _
    '                                                             & " from m_Mainmo_t as a left join m_PartPack_t as b on a.PartID=b.Partid and b.Usey='Y' and b.Packid='C' " _
    '                                                             & " left join m_Dept_t as c on a.Deptid=c.Deptid and c.usey='Y' where moid='" & Me.TxtMoid1.Text.Trim & "' and Factory='" & VbCommClass.VbCommClass.Factory & "'")
    '    If Dgread.Read Then
    '        Me.LblMoidqty.Text = IIf(Dgread.Item("Moqty").ToString <> "", Dgread.Item("Moqty").ToString, "0")
    '        Me.LblPPIDPrinted.Text = IIf(Dgread.Item("Ppidprtqty").ToString <> "", Dgread.Item("Ppidprtqty").ToString, "0")
    '        Me.LblCartonPrinted.Text = IIf(Dgread.Item("Pkgprtqty").ToString <> "", Dgread.Item("Pkgprtqty").ToString, "0")
    '        Me.txtPackingCapacity.Text = IIf(Dgread.Item("Qty").ToString <> "", Dgread.Item("Qty").ToString, "0")
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
    '        Me.txtPackingCapacity.Text = "0"
    '        Me.LblDeptName.Text = ""
    '        Me.DgTask.Rows.Clear()
    '    End If
    '    Dgread.Close()

    'End Sub

    Private Sub TxtMoid1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMoid1.LostFocus

        If String.IsNullOrEmpty(Me.TxtMoid1.Text.Trim.Trim()) Then
            SetMessage("请输入查询Tiptop工单!")
        End If
        '工单判断
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass    'SFCS系统连接对象(SQL)
        Dim dtLot As New DataTable
        dtLot = Conn.GetDataTable(GetCheckLotSQL(Me.TxtMoid1.Text.Trim()))

        If dtLot.Rows.Count > 0 Then

            'Me.LblMoidqty.Text = IIf(dtLot.Rows(0)("Moqty").ToString <> "", dtLot.Rows(0)("Moqty").ToString, "0")
            'Me.LblPPIDPrinted.Text = IIf(dtLot.Rows(0)("Ppidprtqty").ToString <> "", dtLot.Rows(0)("Ppidprtqty").ToString, "0")
            'Me.LblCartonPrinted.Text = IIf(dtLot.Rows(0)("Pkgprtqty").ToString <> "", dtLot.Rows(0)("Pkgprtqty").ToString, "0")
            'Me.txtPackingCapacity.Text = IIf(dtLot.Rows(0)("Qty").ToString <> "", dtLot.Rows(0)("Qty").ToString, "0")
            ''Me.LblDeptName.Text = Dgread.Item("deptname").ToString
            'Me.TxtPartid1.Text = dtLot.Rows(0)("PartID").ToString()
            GetMoidToRefresh(Me.TxtMoid1.Text.Trim)
            SetMessage("")
            '判断是否有可打印数量
        Else

            Dim TiptopConn As New OracleDb("")  'Tiptop连接对象(Oracle)
            'dvTiptopLot = Nothing
            'dvTiptopLot = SapCommon.GetTiptopLot(SapCommon.GetCheckTiptopLotSQL(Me.TxtMoid1.Text.Trim()))
            '连接到SAP
            If IsConSap = "Y" Then
                dvTiptopLot = SapCommon.GetTiptopLotSAP(Me.TxtMoid1.Text.Trim())
            Else
                dvTiptopLot = SapCommon.GetTiptopLot(Me.TxtMoid1.Text.Trim())
            End If

            '获取Tiptop工单信息
            If Not dvTiptopLot Is Nothing Then

                If dvTiptopLot.Count > 0 Then

                    Me.LblMoidqty.Text = dvTiptopLot.Item(0).Item("sfb08").ToString()
                    Me.LblPPIDPrinted.Text = "0"            'dvTiptopLot.Item(0).Item("").ToString()
                    Me.LblCartonPrinted.Text = "0"          'dvTiptopLot.Item(0).Item("").ToString()
                    'Me.txtPackingCapacity.Text =            'dvTiptopLot.Item(0).Item("").ToString()
                    'Me.LblDeptName.Text = Dgread.Item("deptname").ToString
                    Me.TxtPartid1.Text = dvTiptopLot.Item(0).Item("sfb05").ToString()
                    Me.DtMoNeedTime.Text = dvTiptopLot.Item(0).Item("sfb81").ToString()
                    Me.ChkPPID.Checked = True
                    Me.TxtPPIDqty.Enabled = True
                    Me.TxtPPIDqty.Text = dvTiptopLot.Item(0).Item("sfb08").ToString()

                    Me.CboFactory.SelectedValue = VbCommClass.VbCommClass.Factory
                    'FillCombox(Me.CboDept)
                    Dim d As String = dvTiptopLot.Item(0).Item("tc_imc03").ToString()

                    Me.CboDept.SelectedIndex = Me.CboDept.FindString(dvTiptopLot.Item(0).Item("tc_imc03").ToString().Trim)

                    If Not String.IsNullOrEmpty(dvTiptopLot.Item(0).Item("tc_imc03").ToString()) Then
                        'FillCombox(Me.CboLineid1)
                        'CboDept_SelectedIndexChanged(sender, e)
                        Me.CboLineid1.SelectedIndex = Me.CboLineid1.FindString(dvTiptopLot.Item(0).Item("sfb82").ToString().Trim)
                    Else
                        Me.CboLineid1.SelectedIndex = -1
                    End If

                    Me.CboMoType.SelectedIndex = 0
                    Me.CboCust.SelectedIndex = 0

                    '取得料件打印参数
                    If Not String.IsNullOrEmpty(Me.TxtPartid1.Text.Trim()) Then
                        GetPartToRefresh(Me.TxtPartid1.Text.Trim(), sender, e)
                    Else
                        ClearRule()
                    End If
                    SetMessage("")
                Else
                    SetMessage("工单" & Me.TxtMoid1.Text.Trim() & "不存在!")
                    ClearQuery()
                End If
            Else
                SetMessage("工单" & Me.TxtMoid1.Text.Trim() & "不存在!")
                ClearQuery()
            End If

            TiptopConn = Nothing
        End If
        dtLot.Dispose()
        Conn = Nothing

        'If String.IsNullOrEmpty(Me.TxtMoid1.Text.Trim.Trim()) Then Exit Sub

        'If opFlag = 0 Then Exit Sub
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        'Dim Dgread As SqlClient.SqlDataReader = Conn.GetDataReader(" select a.moid,a.Moqty,a.Ppidprtqty,a.Pkgprtqty,b.Qty,c.deptid + '-' + c.djc as deptname,a.PartID " _
        '                                                         & " from m_Mainmo_t as a left join m_PartPack_t as b on a.PartID=b.Partid and b.Usey='Y' and b.Packid='C' " _
        '                                                         & " left join m_Dept_t as c on a.Deptid=c.Deptid and c.usey='Y' where moid='" & Me.TxtMoid1.Text.Trim & "' and Factory='" & VbCommClass.VbCommClass.Factory & "'")
        'If Dgread.Read Then
        '    Me.LblMoidqty.Text = IIf(Dgread.Item("Moqty").ToString <> "", Dgread.Item("Moqty").ToString, "0")
        '    Me.LblPPIDPrinted.Text = IIf(Dgread.Item("Ppidprtqty").ToString <> "", Dgread.Item("Ppidprtqty").ToString, "0")
        '    Me.LblCartonPrinted.Text = IIf(Dgread.Item("Pkgprtqty").ToString <> "", Dgread.Item("Pkgprtqty").ToString, "0")
        '    Me.txtPackingCapacity.Text = IIf(Dgread.Item("Qty").ToString <> "", Dgread.Item("Qty").ToString, "0")
        '    'Me.LblDeptName.Text = Dgread.Item("deptname").ToString
        '    Me.TxtPartid1.Text = Dgread.Item("PartID").ToString()

        '    '此處加載線別，應該加入廠區的條件，才能保持和打印作業一致并且合理。 modi by frankie 20110715
        '    'LoadM.LoadDataToTSComboBox("select lineid from Deptline_t where deptid='" & Me.LblDeptName.Text.Trim.Split("-")(0) & "' and usey='Y' order by lineid", Me.CboLineid1)
        '    LoadM.LoadDataToTSComboBox("select a.lineid from Deptline_t as a join m_Mainmo_t as b on a.deptid=b.deptid and a.factoryid=b.factory and b.moid='" & Me.TxtMoid1.Text.Trim & "' and a.usey='Y' order by a.lineid", Me.CboLineid1)



        '    '获取打印模板信息   TemplateStatus：true已经定于模板，false未定义
        '    LoadM.LoadDataToTSComboBox("select CodeRuleID + '-' + Remark as Ruleid from m_SnRuleM_t where LabelType='S' order by CodeRuleID", Me.CboRuleid)
        '    '获取打印模板信息

        '    If opFlag = 1 Then GetMoidToRefresh(Me.TxtMoid1.Text.Trim)
        '    SetMessage("")
        'Else
        '    Me.CboLineid1.Items.Clear()
        '    Me.LblMoidqty.Text = "0"
        '    Me.LblPPIDPrinted.Text = "0"
        '    Me.LblCartonPrinted.Text = "0"
        '    Me.txtPackingCapacity.Text = "0"
        '    'Me.LblDeptName.Text = ""
        '    Me.DgTask.Rows.Clear()
        '    Me.TxtPartid1.Text = ""
        '    SetMessage("工单不存在")
        'End If
        'Dgread.Close()

        'If Me.ChkCarton.Checked Then

        '    If Int(Me.txtPackingCapacity.Text.Trim()) > 0 Then
        '        Dim NotPackingQty As Int16
        '        NotPackingQty = Int(Me.LblMoidqty.Text.Trim()) - Int(Me.LblCartonPrinted.Text) * Int(Me.txtPackingCapacity.Text.Trim())
        '        Dim d As Int16 = NotPackingQty Mod Int(Me.txtPackingCapacity.Text.Trim())

        '        If NotPackingQty Mod Int(Me.txtPackingCapacity.Text.Trim()) = 0 Then
        '            Me.TxtCartonqty.Text = (NotPackingQty / Int(Me.txtPackingCapacity.Text.Trim())).ToString()
        '        Else
        '            Me.TxtCartonqty.Text = (NotPackingQty / Int(Me.txtPackingCapacity.Text.Trim())).ToString()
        '            Me.TxtPCartonqty.Text = (NotPackingQty Mod Int(Me.txtPackingCapacity.Text.Trim())).ToString()
        '        End If
        '    Else
        '        Me.TxtCartonqty.Text = "0"
        '        Me.TxtPCartonqty.Text = "0"
        '        SetMessage("请设定料件参数包装容量")
        '    End If
        'End If

    End Sub

    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click

        If String.IsNullOrEmpty(Me.TxtMoid1.Text.Trim.Trim()) Then
            SetMessage("请输入查询Tiptop工单!")
        End If
        '工单判断
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass    'SFCS系统连接对象(SQL)
        Dim dtLot As New DataTable
        dtLot = Conn.GetDataTable(GetCheckLotSQL(Me.TxtMoid1.Text.Trim()))

        If dtLot.Rows.Count > 0 Then
            'LostFocus事件已经处理
            '判断是否有可打印数量
        Else

            dvTiptopLot = Nothing
            dvTiptopLot = SapCommon.GetTiptopLot(SapCommon.GetCheckTiptopLotSQL(Me.TxtMoid1.Text.Trim()))

            '获取Tiptop工单信息
            If dvTiptopLot.Count > 0 Then

                Me.LblMoidqty.Text = dvTiptopLot.Item(0).Item("sfb08").ToString()
                Me.LblPPIDPrinted.Text = "0"            'dvTiptopLot.Item(0).Item("").ToString()
                Me.LblCartonPrinted.Text = "0"          'dvTiptopLot.Item(0).Item("").ToString()
                'Me.txtPackingCapacity.Text =            'dvTiptopLot.Item(0).Item("").ToString()
                'Me.LblDeptName.Text = Dgread.Item("deptname").ToString
                Me.TxtPartid1.Text = dvTiptopLot.Item(0).Item("sfb05").ToString()
                Me.DtMoNeedTime.Text = dvTiptopLot.Item(0).Item("sfb81").ToString()
                Me.ChkPPID.Checked = True
                Me.TxtPPIDqty.Enabled = True
                Me.TxtPPIDqty.Text = dvTiptopLot.Item(0).Item("sfb08").ToString()

                Me.CboFactory.SelectedValue = VbCommClass.VbCommClass.Factory
                'FillCombox(Me.CboDept)
                Dim d As String = dvTiptopLot.Item(0).Item("tc_imc03").ToString()

                Me.CboDept.SelectedIndex = Me.CboDept.FindString(dvTiptopLot.Item(0).Item("tc_imc03").ToString().Trim)

                If Not String.IsNullOrEmpty(dvTiptopLot.Item(0).Item("tc_imc03").ToString()) Then
                    'FillCombox(Me.CboLineid1)
                    'CboDept_SelectedIndexChanged(sender, e)
                    Me.CboLineid1.SelectedIndex = Me.CboLineid1.FindString(dvTiptopLot.Item(0).Item("sfb82").ToString().Trim)
                Else
                    Me.CboLineid1.SelectedIndex = -1
                End If

                '取得料件打印参数
                If Not String.IsNullOrEmpty(Me.TxtPartid1.Text.Trim()) Then
                    GetPartToRefresh(Me.TxtPartid1.Text.Trim(), sender, e)
                Else
                    ClearRule()
                End If
                SetMessage("")
            Else
                SetMessage("工单" & Me.TxtMoid1.Text.Trim() & "不存在!")
                ClearQuery()
            End If

        End If
        dtLot.Dispose()
        Conn = Nothing
    End Sub

#Region "方法"

    Private Sub GetPartToRefresh(ByVal PartId As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strSQL As String
        strSQL = "SELECT distinct m_partpack_t.CodeRuleID,m_partpack_t.PFormatID,m_SnPartSet_t.F_codeID,m_SnRuleD_t.F_codename,m_SnPartSet_t.DValues" & _
                  "  FROM m_partpack_t  " & _
               "  INNER JOIN m_SnPartSet_t on m_SnPartSet_t.partid=m_partpack_t.partid and m_SnPartSet_t.Packid=m_partpack_t.Packid and m_SnPartSet_t.Packitem=m_partpack_t.Packitem  " & _
               "  INNER JOIN m_SnRuleD_t ON m_SnRuleD_t.F_codeID=m_SnPartSet_t.F_codeID and m_SnRuleD_t.CodeRuleID=m_partpack_t.CodeRuleID " & _
                  " WHERE m_partpack_t.Usey='Y' AND m_partpack_t.Partid='" & PartId & "'"
        LoadDataToControl(strSQL, sender, e)
    End Sub

    Private Sub LoadDataToControl(ByVal Sqlstr As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim dtPartRule As New DataTable
        Try
            dtPartRule = Conn.GetDataTable(Sqlstr)
            Dim dRow As DataRow

            'PN, T1, T2, T3, VS
            If dtPartRule.Rows.Count > 0 Then
                Me.CboRuleid.SelectedIndex = Me.CboRuleid.FindString(dtPartRule.Rows(0).Item("CodeRuleID").ToString().Trim)
                'cboRuleid_SelectedIndexChanged(sender, e)
                'Me.CboTemplate.SelectedIndex = Me.CboTemplate.FindString(dtPartRule.Rows(0).Item("PFormatID").ToString().Trim)
                Me.CboTemplate.SelectedValue = dtPartRule.Rows(0).Item("PFormatID").ToString().Trim
                For Each dRow In dtPartRule.Rows
                    GetPartSetting(dRow)
                Next
            End If
            dRow = Nothing
            dtPartRule = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetPartSetting(ByVal dRaw As DataRow)
        Select Case dRaw.Item("F_codeID").ToString().ToUpper()
            Case "PN"
                Me.txtCoding.Text = dRaw.Item("DValues").ToString()
            Case "VS"
                Me.txtVersion.Text = dRaw.Item("DValues").ToString()
            Case "T1"
                Me.txtTitle1.Text = dRaw.Item("DValues").ToString()
            Case "T2"
                Me.txtTitle2.Text = dRaw.Item("DValues").ToString()
            Case "T3"
                Me.txtTitle3.Text = dRaw.Item("DValues").ToString()
        End Select
    End Sub

    Private Sub ClearQuery()
        Me.TxtMoid1.Text = ""
        Me.TxtPPIDqty.Text = ""
        Me.DtMoNeedTime.Text = ""
        Me.TxtPPIDqty.Text = ""
        Me.CboDept.SelectedIndex = -1
        Me.CboLineid1.SelectedIndex = -1
        Me.CboMoType.SelectedIndex = -1
        Me.CboCust.SelectedIndex = -1
        Me.CboRuleid.SelectedIndex = -1
        Me.CboTemplate.Items.Clear()

        Me.txtCoding.Text = ""
        Me.txtVersion.Text = ""
        Me.txtTitle1.Text = ""
        Me.txtTitle2.Text = ""
        Me.txtTitle3.Text = ""
        Me.TxtMoid1.Focus()
    End Sub

    Private Sub ClearRule()
        Me.CboRuleid.SelectedIndex = -1
        Me.CboTemplate.Items.Clear()

        Me.txtCoding.Text = ""
        Me.txtVersion.Text = ""
        Me.txtTitle1.Text = ""
        Me.txtTitle2.Text = ""
        Me.txtTitle3.Text = ""
    End Sub

    Private Sub SetMessage(ByVal Message As String)
        Me.lblMessage.Text = Message
    End Sub
#End Region

#Region "函数"

    Private Function GetCheckLotSQL(ByVal LotName As String) As String
        Dim Sql As String
        Sql = " select a.moid,a.Moqty,a.Ppidprtqty,a.Pkgprtqty,b.Qty,c.deptid + '-' + c.djc as deptname,a.PartID " _
            & "from m_Mainmo_t as a left join m_PartPack_t as b on a.PartID=b.Partid and b.Usey='Y' and b.Packid='C' " _
            & "left join m_Dept_t as c on a.Deptid=c.Deptid and c.usey='Y' where moid=" & FormatQuerySQLString(LotName)
        Return Sql
    End Function



    Private Function FormatSQLString(ByVal Value As String) As String
        Return Value.Replace("'", "''")
    End Function

    Private Function FormatQuerySQLString(ByVal Value As String) As String
        Return "N'" & Value.Replace("'", "''") & "'"
    End Function

#End Region

    Private Sub FrmTiptopPrtTask_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        dvTiptopLot = Nothing
    End Sub

End Class

#Region "DrawNewIco"

'Public Class DataGridViewRolloverCell
'    Inherits DataGridViewTextBoxCell

'    Private mImageFlag As Boolean = False

'    Protected Overrides Sub Paint( _
'        ByVal graphics As Graphics, _
'        ByVal clipBounds As Rectangle, _
'        ByVal cellBounds As Rectangle, _
'        ByVal rowIndex As Integer, _
'        ByVal elementState As DataGridViewElementStates, _
'        ByVal value As Object, _
'        ByVal formattedValue As Object, _
'        ByVal errorText As String, _
'        ByVal cellStyle As DataGridViewCellStyle, _
'        ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, _
'        ByVal paintParts As DataGridViewPaintParts)

'         Call the base class method to paint the default cell appearance.
'        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, _
'            value, formattedValue, errorText, cellStyle, _
'            advancedBorderStyle, paintParts)

'        If Me.ImageFlag = True Then
'            Dim img As Image
'            img = My.Resources.new1

'            Dim newRect As New Rectangle(cellBounds.X + cellBounds.Width - img.Width - 1, cellBounds.Y + img.Height / 2, img.Width, img.Height)
'            graphics.DrawImageUnscaledAndClipped(img, newRect)
'        End If

'    End Sub

'    Public Property ImageFlag() As Boolean
'        Get
'            Return mImageFlag
'        End Get
'        Set(ByVal value As Boolean)
'            mImageFlag = value
'            Me.DataGridView.InvalidateCell(Me)
'        End Set
'    End Property

'End Class

'Public Class DataGridViewRolloverCellColumn
'    Inherits DataGridViewColumn

'    Public Sub New()
'        Me.CellTemplate = New DataGridViewRolloverCell()
'    End Sub

'End Class


#End Region
