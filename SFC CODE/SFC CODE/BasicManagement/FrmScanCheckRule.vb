'added by yingxuewei on 20140916
'此功能主要用于产品扫描的基础资料设置

Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle

Public Class FrmScanCheckRule


    Dim SqlStr As New StringBuilder
    Dim LostCheck As Boolean
    Dim SqlSearch As String
    Dim Searchy As Boolean
    Dim StrOldPart As String
    Dim StrOldPPart As String
    Dim StrOldStation As String

    Private Sub FrmScanRuleChk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Erightbutton()
        '抓取状态为有效的数据
        LoadDataToDatagridview(" and a.state='1'")
        SetControlStutas("UNDO")
    End Sub

#Region "加载所有有效的数据"
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dt As DataTable
        Dim SqlStr As String = ""

        dgvScanChkRule.DataSource = ""
        ' dgvScanChkRule.Rows.Clear()
        SqlStr = "SELECT [Ppartid] 父料号,[Tpartid] 料号,[Revid] 版本号,[StaOrderid] 站点顺序,[Stationid] 站点编码,[ScanOrderid] 扫描顺序 " _
              & " ,[IsNiTestCheck] 是否NI测试校验,[IsLaserCheck] 是否镭射校验,[IsPcbaTestCheck] 是否PCBA测试校验,[IsGuessSemiCheck] 是否高斯半成品测试校验 " _
              & " ,[IsGuessFinishCheck] 是否高斯成品校验,[IsAcrTestCheck] 是否ACR测试校验,[IsAoiTestCheck] 是否AOI测试校验 " _
              & " ,[IsFunctionOne] 是否FT1测试校验,[IsFunctionTwo] 是否FT2测试校验,[IsVoltageTest] 是否压力测试校验,[IsGenTestResult] 是否Gen测试校验" _
              & " ,[IsCheckA20testResult] 是否A20测试校验,[IsCheckA20BurningResult] 是否A20烧入校验,[IsLotCheck] 是否批次校验 " _
              & " ,[IsAOIone] 是否AOI1测试校验,[IsACRone] 是否ACR1测试校验,[IsACRIQC] 是否ACRIQC校验 ,[IsSpecCheck] 是否外观检校验 " _
              & " ,[IsW2Check] 是否W2校验,[IsW2NetLinkCheck] 是否W2网络连接校验 ,[IsFinalCheck] 是否最终校验,[IsRandomOQC] 是否OQC抽检校验 " _
              & " ,[OqcCount] OQC抽检数量,[OqcCheck] OQC校验,[MagentSelf] 是否磁力半成品校验,[MagentFilesh] 是否磁力成品校验 " _
              & " ,[IsShipCheck] 是否出货校验,[IsMultLotCheck] 是否多批次校验,[IsLinkMsn] 是否MSN绑定校验,[IsWiggleChk] 是否摇摆测试校验 " _
              & " ,[IsE75Chk] 是否E75测试校验,[IsWeightChk] 是否称重校验,[IsChargeChk] 是否充电校验,[IsTwoInOneChk] 是否二合一校验 " _
              & " ,[IsW2FT6Chk] '是否W2 FT6校验',[IsPLPackChk] 是否充电宝校验,[IsAllowMuLine] 是否允许多线别校验,[IsCheckParentPart] 是否父工艺流程扫描校验,case when [State]='1' then '有效' when [State]='0' then '已作廢' end 状态 " _
              & " ,[Userid] 设置人,[Intime] 设置时间 FROM [MESDB].[dbo].[m_ScanCheckRule_t] a where 1=1  " _
              & "  " & SqlWhere
        dt = Conn.GetDataTable(SqlStr)
        dgvScanChkRule.DataSource = dt
        ToolStripStatusLabel1.Text = dt.Rows.Count
        Conn.PubConnection.Close()
        Conn = Nothing
    End Sub
#End Region

#Region "设置控件状态"

    Private Sub SetControlStutas(ByVal FlagStr As String)

        Select Case UCase(FlagStr)
            Case "ADD"  '新增
                NewFile.Enabled = False
                EditFile.Enabled = False
                toolAbandon.Enabled = False
                Save.Enabled = True
                UnDo.Enabled = True
                Search.Enabled = False
                FileRefresh.Enabled = False
                ExitFrom.Enabled = True

                '设置校验的复选框属性
                Me.IsNIChk.Checked = False
                Me.IsLaserChk.Checked = False
                Me.IsPCBAChk.Checked = False
                Me.IsGuesSemiChk.Checked = False
                Me.IsGuesFinChk.Checked = False
                Me.IsAcrChk.Checked = False
                Me.IsAoiChk.Checked = False
                Me.IsFT1Chk.Checked = False
                Me.IsFT2Chk.Checked = False
                Me.IsVoltageChk.Checked = False
                Me.IsGenChk.Checked = False
                Me.IsLotChk.Checked = False
                Me.IsRanOQCChk.Checked = False
                Me.IsOQCChk.Checked = False
                Me.IsShipChk.Checked = False
                Me.IsMagnetSemiChk.Checked = False
                Me.IsMagnetFChk.Checked = False
                Me.IsMultiLotChk.Checked = False
                Me.IsLinkMSNChk.Checked = False
                Me.IsA20Chk.Checked = False
                Me.IsA20BurnChk.Checked = False
                Me.IsACRoneChk.Checked = False
                Me.IsAcrIqcChk.Checked = False
                Me.IsSpecChk.Checked = False
                Me.IsW2Chk.Checked = False
                Me.IsW2NetLinkChk.Checked = False
                Me.IsFinalChk.Checked = False
                Me.IsWiggleChk.Checked = False
                Me.IsE75Chk.Checked = False
                Me.IsWeightChk.Checked = False
                Me.IsChargeChk.Checked = False
                Me.IsTwoInOneChk.Checked = False
                Me.IsW2FT6Chk.Checked = False
                Me.IsPLPackChk.Checked = False
                Me.IsAOIOneChk.Checked = False
                Me.IsAllowMuLineChk.Checked = False
                Me.IsChkParentPart.Checked = False


            Case "EDIT"  '编辑
                NewFile.Enabled = False
                EditFile.Enabled = False
                toolAbandon.Enabled = False
                Save.Enabled = True
                UnDo.Enabled = True
                Search.Enabled = False
                FileRefresh.Enabled = False
                ExitFrom.Enabled = True

            Case "UNDO"  '返回
                NewFile.Enabled = True
                EditFile.Enabled = True
                toolAbandon.Enabled = True
                Save.Enabled = False
                UnDo.Enabled = False
                Search.Enabled = True
                FileRefresh.Enabled = True
                ExitFrom.Enabled = True

                '设置校验的复选框属性
                Me.IsNIChk.Checked = False
                Me.IsLaserChk.Checked = False
                Me.IsPCBAChk.Checked = False
                Me.IsGuesSemiChk.Checked = False
                Me.IsGuesFinChk.Checked = False
                Me.IsAcrChk.Checked = False
                Me.IsAoiChk.Checked = False
                Me.IsFT1Chk.Checked = False
                Me.IsFT2Chk.Checked = False
                Me.IsVoltageChk.Checked = False
                Me.IsGenChk.Checked = False
                Me.IsLotChk.Checked = False
                Me.IsRanOQCChk.Checked = False
                Me.IsOQCChk.Checked = False
                Me.IsShipChk.Checked = False
                Me.IsMagnetSemiChk.Checked = False
                Me.IsMagnetFChk.Checked = False
                Me.IsMultiLotChk.Checked = False
                Me.IsLinkMSNChk.Checked = False
                Me.IsA20Chk.Checked = False
                Me.IsA20BurnChk.Checked = False
                Me.IsACRoneChk.Checked = False
                Me.IsAcrIqcChk.Checked = False
                Me.IsSpecChk.Checked = False
                Me.IsW2Chk.Checked = False
                Me.IsW2NetLinkChk.Checked = False
                Me.IsFinalChk.Checked = False
                Me.IsWiggleChk.Checked = False
                Me.IsE75Chk.Checked = False
                Me.IsWeightChk.Checked = False
                Me.IsChargeChk.Checked = False
                Me.IsTwoInOneChk.Checked = False
                Me.IsW2FT6Chk.Checked = False
                Me.IsPLPackChk.Checked = False
                Me.IsAOIOneChk.Checked = False
                Me.IsAllowMuLineChk.Checked = False
                Me.IsChkParentPart.Checked = False


        End Select

    End Sub
#End Region

#Region "新增新的资料"
    Private Sub NewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewFile.Click
        SysMessageClass.EditFlag = True
        AddRecord()
        TxtTavcPart.Enabled = True
        Me.TxtTavcPart.Focus()
    End Sub

    Private Sub AddRecord()

        Me.CobStationid.SelectedIndex = -1
        ChgRecord(0)
        SetControlStutas("ADD")
        ClearControl()

    End Sub

    Private Sub ChgRecord(ByVal Flag As Integer)

        Dim EmsCon As Control
        Select Case Flag

            Case 0 '新增和编辑
                Me.dgvScanChkRule.Enabled = True
                For Each EmsCon In Me.Controls
                    If TypeOf EmsCon Is System.Windows.Forms.TextBox Then
                        EmsCon.Enabled = True
                    ElseIf TypeOf EmsCon Is System.Windows.Forms.CheckBox Then
                        EmsCon.Enabled = True
                    ElseIf TypeOf EmsCon Is ComboBox Then
                        EmsCon.Enabled = True
                    End If

                Next
                dgvScanChkRule.Enabled = False
                Me.TxtTavcPart.Enabled = False
            Case 1 '查询
                For Each EmsCon In Me.Controls
                    If TypeOf EmsCon Is System.Windows.Forms.TextBox Then
                        EmsCon.Enabled = False
                    ElseIf TypeOf EmsCon Is System.Windows.Forms.CheckBox Then
                        EmsCon.Enabled = False
                    ElseIf TypeOf EmsCon Is ComboBox Then
                        EmsCon.Enabled = False
                    End If

                Next
                dgvScanChkRule.Enabled = True
        End Select
    End Sub

    Private Sub ClearControl()

        Dim ClearCon As Control

        For Each ClearCon In Me.Controls
            If TypeOf ClearCon Is System.Windows.Forms.TextBox Then
                ClearCon.Text = ""
            ElseIf TypeOf ClearCon Is ComboBox Then
                ClearCon.Text = ""
            End If
        Next
        Me.CobStationid.SelectedIndex = -1
    End Sub
#End Region

#Region "编辑选中的行"

    Private Sub EditFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditFile.Click
        If dgvScanChkRule.RowCount < 1 Then Exit Sub
        If Me.dgvScanChkRule.CurrentRow.Index = -1 Then Exit Sub
        StrOldPart = Me.dgvScanChkRule.CurrentRow.Cells(1).Value.ToString()
        StrOldPPart = Me.dgvScanChkRule.CurrentRow.Cells(0).Value.ToString()
        StrOldStation = Me.dgvScanChkRule.CurrentRow.Cells(4).Value.ToString()
        SysMessageClass.EditFlag = False
        EditRecord()
        SetValueToControl()
        Me.TxtTavcPart.Focus()
    End Sub

    Private Sub EditRecord()

        ChgRecord(0)
        SetControlStutas("EDIT")

    End Sub

    Private Sub SetValueToControl()

        If dgvScanChkRule.RowCount < 1 Then Exit Sub
        If Me.dgvScanChkRule.CurrentRow.Index < 0 Then Exit Sub
        Me.TxtTavcPart.Text = Me.dgvScanChkRule.Item(1, dgvScanChkRule.CurrentRow.Index).Value.ToString
        Me.TxtPavcPart.Text = Me.dgvScanChkRule.Item(0, dgvScanChkRule.CurrentRow.Index).Value.ToString
        Me.CobStationid.Text = Me.dgvScanChkRule.Item(4, dgvScanChkRule.CurrentRow.Index).Value.ToString
        Me.TxtStationNo.Text = Me.dgvScanChkRule.Item(3, dgvScanChkRule.CurrentRow.Index).Value.ToString
        Me.txtScanOrder.Text = Me.dgvScanChkRule.Item(5, dgvScanChkRule.CurrentRow.Index).Value.ToString
        Me.txtVersion.Text = Me.dgvScanChkRule.Item(2, dgvScanChkRule.CurrentRow.Index).Value.ToString

        Me.IsNIChk.Checked = IIf(Me.dgvScanChkRule.Item(6, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsLaserChk.Checked = IIf(Me.dgvScanChkRule.Item(7, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsPCBAChk.Checked = IIf(Me.dgvScanChkRule.Item(8, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsGuesSemiChk.Checked = IIf(Me.dgvScanChkRule.Item(9, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsGuesFinChk.Checked = IIf(Me.dgvScanChkRule.Item(10, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsAcrChk.Checked = IIf(Me.dgvScanChkRule.Item(11, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsAoiChk.Checked = IIf(Me.dgvScanChkRule.Item(12, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsFT1Chk.Checked = IIf(Me.dgvScanChkRule.Item(13, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsFT2Chk.Checked = IIf(Me.dgvScanChkRule.Item(14, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsVoltageChk.Checked = IIf(Me.dgvScanChkRule.Item(15, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsGenChk.Checked = IIf(Me.dgvScanChkRule.Item(16, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsLotChk.Checked = IIf(Me.dgvScanChkRule.Item(19, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsRanOQCChk.Checked = IIf(Me.dgvScanChkRule.Item(27, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsOQCChk.Checked = IIf(Me.dgvScanChkRule.Item(28, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsShipChk.Checked = IIf(Me.dgvScanChkRule.Item(32, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsMagnetSemiChk.Checked = IIf(Me.dgvScanChkRule.Item(30, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsMagnetFChk.Checked = IIf(Me.dgvScanChkRule.Item(31, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsMultiLotChk.Checked = IIf(Me.dgvScanChkRule.Item(33, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsLinkMSNChk.Checked = IIf(Me.dgvScanChkRule.Item(34, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsA20Chk.Checked = IIf(Me.dgvScanChkRule.Item(17, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsA20BurnChk.Checked = IIf(Me.dgvScanChkRule.Item(18, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsACRoneChk.Checked = IIf(Me.dgvScanChkRule.Item(21, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsAcrIqcChk.Checked = IIf(Me.dgvScanChkRule.Item(22, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsSpecChk.Checked = IIf(Me.dgvScanChkRule.Item(23, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsW2Chk.Checked = IIf(Me.dgvScanChkRule.Item(24, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsW2NetLinkChk.Checked = IIf(Me.dgvScanChkRule.Item(25, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsFinalChk.Checked = IIf(Me.dgvScanChkRule.Item(26, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsWiggleChk.Checked = IIf(Me.dgvScanChkRule.Item(35, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsE75Chk.Checked = IIf(Me.dgvScanChkRule.Item(36, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsWeightChk.Checked = IIf(Me.dgvScanChkRule.Item(37, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsChargeChk.Checked = IIf(Me.dgvScanChkRule.Item(38, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsTwoInOneChk.Checked = IIf(Me.dgvScanChkRule.Item(39, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsW2FT6Chk.Checked = IIf(Me.dgvScanChkRule.Item(40, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsPLPackChk.Checked = IIf(Me.dgvScanChkRule.Item(41, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsAOIOneChk.Checked = IIf(Me.dgvScanChkRule.Item(20, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsAllowMuLineChk.Checked = IIf(Me.dgvScanChkRule.Item(42, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)
        Me.IsChkParentPart.Checked = IIf(Me.dgvScanChkRule.Item(43, dgvScanChkRule.CurrentRow.Index).Value.ToString = "Y", True, False)

    End Sub

#End Region

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        SaveData()
    End Sub

    Private Sub SaveData()

        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DrCheck As SqlDataReader
        Dim SqlStr As String
        Try
            CheckRecord()

            Dim IsNI As String = IIf(IsNIChk.Checked, "Y", "N")
            Dim IsLaser As String = IIf(IsLaserChk.Checked, "Y", "N")
            Dim IsPCBA As String = IIf(IsPCBAChk.Checked, "Y", "N")
            Dim IsGuessSemi As String = IIf(IsGuesSemiChk.Checked, "Y", "N")
            Dim IsGuessFin As String = IIf(IsGuesFinChk.Checked, "Y", "N")
            Dim IsAcr As String = IIf(IsAcrChk.Checked, "Y", "N")
            Dim IsAoi As String = IIf(IsAoiChk.Checked, "Y", "N")
            Dim IsFT1 As String = IIf(IsFT1Chk.Checked, "Y", "N")
            Dim IsFT2 As String = IIf(IsFT2Chk.Checked, "Y", "N")
            Dim IsVoltage As String = IIf(IsVoltageChk.Checked, "Y", "N")
            Dim IsGen As String = IIf(IsGenChk.Checked, "Y", "N")
            Dim IsLot As String = IIf(IsLotChk.Checked, "Y", "N")
            Dim IsRandOQC As String = IIf(IsRanOQCChk.Checked, "Y", "N")
            Dim IsOQC As String = IIf(IsOQCChk.Checked, "Y", "N")
            Dim IsShip As String = IIf(IsShipChk.Checked, "Y", "N")
            Dim IsMagnetSemi As String = IIf(IsMagnetSemiChk.Checked, "Y", "N")
            Dim IsMagnetFin As String = IIf(IsMagnetFChk.Checked, "Y", "N")
            Dim IsMultiLot As String = IIf(IsMultiLotChk.Checked, "Y", "N")
            Dim IsLinkMSN As String = IIf(IsLinkMSNChk.Checked, "Y", "N")
            Dim IsA20 As String = IIf(IsA20Chk.Checked, "Y", "N")
            Dim IsA20Burn As String = IIf(IsA20BurnChk.Checked, "Y", "N")
            Dim IsAcrOne As String = IIf(IsACRoneChk.Checked, "Y", "N")
            Dim IsAcrIqc As String = IIf(IsAcrIqcChk.Checked, "Y", "N")
            Dim IsSpec As String = IIf(IsSpecChk.Checked, "Y", "N")
            Dim IsW2Ch As String = IIf(IsW2Chk.Checked, "Y", "N")
            Dim IsW2NetLink As String = IIf(IsW2NetLinkChk.Checked, "Y", "N")
            Dim IsFinal As String = IIf(IsFinalChk.Checked, "Y", "N")
            Dim IsWiggle As String = IIf(IsWiggleChk.Checked, "Y", "N")
            Dim IsE75 As String = IIf(IsE75Chk.Checked, "Y", "N")
            Dim IsWeight As String = IIf(IsWeightChk.Checked, "Y", "N")
            Dim IsCharge As String = IIf(IsChargeChk.Checked, "Y", "N")
            Dim IsTwoInOne As String = IIf(IsTwoInOneChk.Checked, "Y", "N")
            Dim IsW2FT6 As String = IIf(IsW2FT6Chk.Checked, "Y", "N")
            Dim IsPLPack As String = IIf(IsPLPackChk.Checked, "Y", "N")
            Dim IsAOIOne As String = IIf(IsAOIOneChk.Checked, "Y", "N")
            Dim IsAllMuLine As String = IIf(IsAllowMuLineChk.Checked, "Y", "N")
            Dim IsParentPart As String = IIf(IsChkParentPart.Checked, "Y", "N")


            If SysMessageClass.EditFlag = True Then
                DrCheck = Sdbc.GetDataReader("select Ppartid,Tpartid from m_ScanCheckRule_t where State='1' and Tpartid='" & Trim(Me.TxtTavcPart.Text) & "' and Ppartid='" & Trim(Me.TxtPavcPart.Text) & "' and Stationid= '" & Trim(Me.CobStationid.Text) & "' ")
                If DrCheck.HasRows Then
                    MessageBox.Show("系统中已存在有效的该料号的该站点信息", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DrCheck.Close()
                    Sdbc.PubConnection.Close()
                    Exit Sub
                End If
                DrCheck.Close()
                Sdbc.PubConnection.Close()
                SqlStr = " INSERT INTO [m_ScanCheckRule_t]([Ppartid],[Tpartid],[Revid],[StaOrderid],[Stationid],[ScanOrderid] " _
                & " ,[IsNiTestCheck],[IsLaserCheck],[IsPcbaTestCheck],[IsGuessSemiCheck],[IsGuessFinishCheck] " _
                & " ,[IsAcrTestCheck],[IsAoiTestCheck],[IsFunctionOne],[IsFunctionTwo] ,[IsVoltageTest],[IsGenTestResult] " _
                & " ,[IsCheckA20testResult],[IsCheckA20BurningResult],[IsLotCheck],[IsAOIone],[IsACRone],[IsACRIQC],[IsSpecCheck] " _
                & " ,[IsW2Check],[IsW2NetLinkCheck],[IsFinalCheck],[IsRandomOQC],[OqcCount],[OqcCheck],[State],[Userid] " _
                & " ,[Intime],[MagentSelf],[MagentFilesh],[IsShipCheck],[IsMultLotCheck] ,[IsLinkMsn],[IsWiggleChk],[IsE75Chk] " _
                & " ,[IsWeightChk],[IsChargeChk],[IsTwoInOneChk],[IsW2FT6Chk],[IsPLPackChk],[IsAllowMuLine],[IsCheckParentPart]) VALUES( " _
                & " '" & TxtPavcPart.Text.Trim & "','" & TxtTavcPart.Text.Trim & "','" & txtVersion.Text.Trim & "','" & TxtStationNo.Text.Trim & "'," _
                & " '" & CobStationid.Text.Trim & "','" & txtScanOrder.Text.Trim & "','" & IsNI & "','" & IsLaser & "','" & IsPCBA & "'," _
                & " '" & IsGuessSemi & "','" & IsGuessFin & "','" & IsAcr & "','" & IsAoi & "','" & IsFT1 & "','" & IsFT2 & "','" & IsVoltage & "'," _
                & " '" & IsGen & "','" & IsA20 & "','" & IsA20Burn & "','" & IsLot & "','" & IsAOIOne & "','" & IsAcrOne & "','" & IsAcrIqc & "','" & IsSpec & "'," _
                & " '" & IsW2Ch & "','" & IsW2NetLink & "','" & IsFinal & "','" & IsRandOQC & "','" & txtRanOQCQty.Text.Trim & "','" & IsOQC & "','1','" & SysMessageClass.UseId & "'," _
                & " GETDATE(),'" & IsMagnetSemi & "','" & IsMagnetFin & "','" & IsShip & "','" & IsMultiLot & "','" & IsLinkMSN & "','" & IsWiggle & "','" & IsE75 & "'," _
                & " '" & IsWeight & "','" & IsCharge & "','" & IsTwoInOne & "','" & IsW2FT6 & "','" & IsPLPack & "','" & IsAllMuLine & "','" & IsParentPart & "' )"
            Else
                SqlStr = "UPDATE [MESDB].[dbo].[m_ScanCheckRule_t] SET [Ppartid] ='" & TxtPavcPart.Text.Trim & "' ,[Tpartid] ='" & TxtTavcPart.Text.Trim & "' ,[Revid] = '" & txtVersion.Text.Trim & "'" _
              & ",[StaOrderid] = '" & TxtStationNo.Text.Trim & "',[Stationid] = '" & CobStationid.Text.Trim & "',[ScanOrderid] = '" & txtScanOrder.Text.Trim & "',[IsNiTestCheck] = '" & IsNI & "'" _
              & ",[IsLaserCheck] = '" & IsLaser & "',[IsPcbaTestCheck] = '" & IsPCBA & "',[IsGuessSemiCheck] = '" & IsGuessSemi & "'" _
              & ",[IsGuessFinishCheck] = '" & IsGuessFin & "',[IsAcrTestCheck] = '" & IsAcr & "',[IsAoiTestCheck] = '" & IsAoi & "',[IsFunctionOne] = '" & IsFT1 & "'" _
              & ",[IsFunctionTwo] = '" & IsFT1 & "',[IsVoltageTest] = '" & IsVoltage & "',[IsGenTestResult] = '" & IsGen & "',[IsCheckA20testResult] = '" & IsA20 & "'" _
              & ",[IsCheckA20BurningResult] = '" & IsA20Burn & "',[IsLotCheck] = '" & IsLot & "',[IsAOIone] = '" & IsAOIOne & "'" _
              & ",[IsACRone] = '" & IsAcrOne & "',[IsACRIQC] = '" & IsAcrIqc & "',[IsSpecCheck] = '" & IsSpec & "',[IsW2Check] = '" & IsW2Ch & "'" _
              & ",[IsW2NetLinkCheck] = '" & IsW2NetLink & "',[IsFinalCheck] = '" & IsFinal & "',[IsRandomOQC] = '" & IsRandOQC & "'" _
              & ",[OqcCount] = '" & txtRanOQCQty.Text.Trim & "',[OqcCheck] = '" & IsOQC & "',[State] = '1',[Userid] = '" & SysMessageClass.UseId & "'" _
              & ",[Intime] = GETDATE(),[MagentSelf] = '" & IsMagnetSemi & "',[MagentFilesh] = '" & IsMagnetFin & "',[IsShipCheck] = '" & IsShip & "'" _
              & ",[IsMultLotCheck] = '" & IsMultiLot & "',[IsLinkMsn] = '" & IsLinkMSN & "',[IsWiggleChk] = '" & IsWiggle & "'" _
              & ",[IsE75Chk] = '" & IsE75 & "',[IsWeightChk] = '" & IsWeight & "',[IsChargeChk] = '" & IsCharge & "',[IsTwoInOneChk] = '" & IsTwoInOne & "'" _
              & ",[IsW2FT6Chk] = '" & IsW2FT6 & "',[IsPLPackChk] = '" & IsPLPack & "',[IsAllowMuLine] = '" & IsAllMuLine & "',[IsCheckParentPart] = '" & IsParentPart & "'" _
              & " WHERE [Ppartid] ='" & StrOldPPart & "' and [Tpartid] ='" & StrOldPart & "' and [Stationid] = '" & StrOldStation & "'"
            End If

            Sdbc.ExecSql(SqlStr)
            Sdbc.PubConnection.Close()
            ChgRecord(1)
            SetControlStutas("UNDO")
            LoadDataToDatagridview(" and a.state='1'")
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & "错误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub CheckRecord()

        Dim TavcPartErr As New Exception("料件编号不能为空!")
        TavcPartErr.Source = "CheckRecord"
        If Me.TxtTavcPart.Text = "" Then
            Throw TavcPartErr
        End If

        Dim PavcPartErr As New Exception("父料件编号不能为空")
        PavcPartErr.Source = "CheckRecord"
        If Me.TxtPavcPart.Text = "" Then
            Throw PavcPartErr
        End If

        Dim StationidErr As New Exception("站点编码不能为空")
        StationidErr.Source = "CheckRecord"
        If Me.CobStationid.Text = "" Then
            Throw StationidErr
        End If

        Dim TxtStationNoErr As New Exception("站点顺序不能为空")
        TxtStationNoErr.Source = "CheckRecord"
        If Me.TxtStationNo.Text = "" Then
            Throw TxtStationNoErr
        End If

        Dim txtScanOrderErr As New Exception("扫描顺序不能为空")
        txtScanOrderErr.Source = "CheckRecord"
        If Me.txtScanOrder.Text = "" Then
            Throw txtScanOrderErr
        End If

        Dim VersionrErr As New Exception("版本号不能为空")
        VersionrErr.Source = "CheckRecord"
        If Me.txtVersion.Text = "" Then
            Throw VersionrErr
        End If

        Dim RandomOQCErr As New Exception("需抽检的抽检数量不能为空")
        RandomOQCErr.Source = "CheckRecord"
        If IsRanOQCChk.Checked = True And Me.txtRanOQCQty.Text = "" Then
            Throw RandomOQCErr
        End If
    End Sub

    Private Sub UnDo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnDo.Click
        LostCheck = True
        CancelChg()
        LostCheck = False
        Searchy = False
    End Sub

    Private Sub CancelChg()

        ChgRecord(1)
        SetControlStutas("UNDO")
        SetValueToControl()

    End Sub

    Private Sub ExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub


    Private Sub FileRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileRefresh.Click
        If Searchy = False Then
            LoadDataToDatagridview(" and a.state='1' ")
            SetValueToControl()
            Exit Sub
        End If

        Dim SqlStr As String = ""
        If Me.TxtTavcPart.Text <> "" Then
            SqlStr = SqlStr + " and a.Tpartid like '%" & Trim(TxtTavcPart.Text) & "%'"
        End If
        If Me.TxtPavcPart.Text <> "" Then
            SqlStr = SqlStr + " and a.Ppartid like '" & Trim(TxtPavcPart.Text) & "%'"
        End If
        If Me.CobStationid.Text <> "" Then
            SqlStr = SqlStr + " and a.Stationid like '" & CobStationid.Text.Trim & "%'"
        End If

        LoadDataToDatagridview(SqlStr)
        SetValueToControl()
        EditFile.Enabled = True
    End Sub

    Private Sub dgvScanChkRule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvScanChkRule.Click
        SetValueToControl()
    End Sub

    Private Sub toolAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        If dgvScanChkRule.RowCount < 1 Then Exit Sub
        If Me.dgvScanChkRule.CurrentRow.Index = -1 Then Exit Sub
        Dim Sdbc As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlString As String
        If MessageBox.Show("你确定要将该料件的的站点信息作废？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Try
                SqlString = "update m_ScanCheckRule_t set State='0'  where Ppartid ='" & TxtPavcPart.Text.Trim & "' and Tpartid ='" & TxtTavcPart.Text.Trim & "' and Stationid = '" & CobStationid.Text.Trim & "'"
                Sdbc.ExecSql(SqlString)
                Sdbc.PubConnection.Close()
                LoadDataToDatagridview("")
            Catch Eex As Exception
                MessageBox.Show(Eex.Message & vbNewLine & "料件作废时，发生错误!", "提示信息", MessageBoxButtons.OK)
            Finally
                Sdbc = Nothing
            End Try
        End If
        Sdbc = Nothing
        SetValueToControl()
    End Sub

    Private Sub Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search.Click
        NewFile.Enabled = False
        EditFile.Enabled = False
        Save.Enabled = False
        UnDo.Enabled = True
        Search.Enabled = False
        FileRefresh.Enabled = True
        ExitFrom.Enabled = True
        ClearControl()
        TxtTavcPart.Enabled = True
        TxtPavcPart.Enabled = True
        CobStationid.Enabled = True
        Searchy = True
        Me.TxtTavcPart.Focus()
    End Sub


End Class