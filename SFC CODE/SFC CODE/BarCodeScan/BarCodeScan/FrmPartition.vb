
''***************************************************
''-----------拆关联: 2020/02/11---------
'更新者：田玉琳
''***************************************************

#Region "Imports"

Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports MainFrame

#End Region

Public Class FrmPartition

#Region "怠砰ㄆン"

    Private Sub FrmPartition_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37 '
                SendKeys.Send("+{Tab}")  'Shift + Tab 
            Case 13 'Enter
                SendKeys.Send("{Tab}")
            Case 38 '
            Case 39 '
                SendKeys.Send("{Tab}")
            Case 40  '
                'SendKeys.Send("{Tab}")
            Case 27 'Esc
                Me.Close()
        End Select
    End Sub

    '初期化
    Private Sub FrmPartition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim CheckRead As DataTable
        CheckRead = DbOperateUtils.GetDataTable("select distinct a.userid from m_Users_t a  join m_userright_t b on a.userid=b.userid where  b.tkey='m031d_' and a.userid='" & SysMessageClass.UseId & "'")
        If Not CheckRead.Rows.Count = 0 Then
            Me.btnGo_W.Enabled = False
        Else
            Me.btnGo_W.Enabled = True
        End If
        Me.TabControl1.SelectedIndex = 0
        Me.ActiveControl = Me.txtCartonid_Q
    End Sub

#End Region

#Region "产品关联查询"
    '更Me.dgvQueryMMe.dgvChai_M
    Private Sub LoadDataToDgvQueryM(ByVal dgv As DataGridView, ByVal BarCodeStr As String, ByVal BarCodeType As String)
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DReader As DataTable
        Dim SqlStr As String = ""

        dgv.Rows.Clear()
        Select Case BarCodeType
            Case "Cartonid"
                SqlStr = "select a.Cartonid,b.ppid,a.moid,c.partid,d.username as userid,convert(varchar(19),b.intime,21) as intime " _
                    & " from dbo.m_Carton_t as a left join dbo.m_CartonSn_t as b on a.Cartonid=b.Cartonid left join dbo.m_Mainmo_t as c " _
                    & " on a.moid=c.moid left join dbo.m_Users_t as d on b.userid=d.userid " _
                    & " where a.Cartonid='" & BarCodeStr & "' order by a.Cartonid,b.ppid "
            Case "Mppid"
                SqlStr = "select distinct isnull(c.Cartonid,N'未包装') as Cartonid,a.ppid as ppid,a.moid,b.partid,d.username as userid,Convert(varchar(19),a.intime,21) as intime " _
                    & " from dbo.m_Assysn_t as a left join dbo.m_Mainmo_t as b on a.moid=b.moid  " _
                    & " left join dbo.m_CartonSn_t as c on a.ppid=c.ppid left join dbo.m_Users_t as d on a.userid=d.userid " _
                    & " where a.ppid='" & BarCodeStr & "'"
            Case "Dppid"
                SqlStr = "select distinct isnull(d.Cartonid,N'产品未关联') as Cartonid,a.Exppid as ppid,b.moid,c.partid,e.username as userid,Convert(varchar(19),d.intime,21) as intime " _
                    & " from dbo.m_Ppidlink_t as a left join dbo.m_Assysn_t as b on a.Exppid=b.ppid left join dbo.m_Mainmo_t as c on b.moid=c.moid  " _
                    & " left join dbo.m_CartonSn_t as d on a.Exppid=d.ppid left join dbo.m_Users_t as e on d.userid=e.userid " _
                    & " where a.usey='Y' and a.ppid='" & BarCodeStr & "' and a.ScanOrderid<>1"
        End Select
        DReader = DbOperateUtils.GetDataTable(SqlStr)

        If DReader.Rows.Count = 0 Then
            MessageUtils.ShowInformation("没有查询到相关的记录!")
            Exit Sub
        End If

        dgv.Rows.Clear()
        For iIndex As Integer = 0 To DReader.Rows.Count - 1
            dgv.Rows.Add(DReader.Rows(iIndex)("Cartonid").ToString.Trim.ToUpper, DReader.Rows(iIndex)("ppid").ToString.Trim.ToUpper,
                         DReader.Rows(iIndex)("moid").ToString.Trim, DReader.Rows(iIndex)("partid").ToString.Trim.ToUpper,
                         DReader.Rows(iIndex)("userid").ToString.Trim, DReader.Rows(iIndex)("intime").ToString.Trim)
            LblPartid.Text = DReader.Rows(iIndex)("partid").ToString.Trim.ToUpper
        Next

    End Sub
    '更Me.dgvQueryDMe.dgvChai_D
    Private Sub LoadDataToDgvQueryD(ByVal dgv As DataGridView, ByVal BarCodeStr As String)
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlStr As String
        Dim DReader As DataTable

        dgv.Rows.Clear()
        SqlStr = " select distinct d.TPartText,d.TPartid,b.ppid from dbo.m_Assysn_t as a " _
            & " left join dbo.m_Ppidlink_t as b on b.Exppid=a.Ppid and b.ScanOrderid<>1 and b.usey='Y'" _
            & " left join dbo.m_Mainmo_t as c on a.moid=c.moid left join dbo.m_RPartStationD_t as d  " _
            & " on c.partid=d.ppartid and d.state='1' and b.StaOrderid=d.StaOrderid and b.ScanOrderid=d.ScanOrderid" _
            & " where a.ppid='" & BarCodeStr & "'"
        DReader = DbOperateUtils.GetDataTable(SqlStr)

        dgv.Rows.Clear()
        For iIndex As Integer = 0 To DReader.Rows.Count - 1
            dgv.Rows.Add(DReader.Rows(iIndex).Item("TPartText").ToString.Trim, DReader.Rows(iIndex).Item("TPartid").ToString.Trim, DReader.Rows(iIndex).Item("ppid").ToString.Trim)
            dgv.CurrentCell = dgv.Item(0, 0)
        Next

        'If DReader.HasRows Then
        '    Do While DReader.Read()
        '        dgv.Rows.Add(DReader.Item("TPartText").ToString.Trim, DReader.Item("TPartid").ToString.Trim, DReader.Item("ppid").ToString.Trim)
        '    Loop
        '    dgv.CurrentCell = dgv.Item(0, 0)
        'End If
        'DReader.Close()
        'Conn = Nothing
    End Sub
    '更Me.dgvReplace
    Private Sub LoadDataToDgvReplace(ByVal dgv As DataGridView, ByVal NewPPid As String, ByVal OldPPid As String)
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlStr As String
        Dim ds As New DataSet
        Dim dt As New DataTable

        dgv.Rows.Clear()
        SqlStr = "declare @Return varchar(1),@ReturnD varchar(1),@Cartonid varchar(50),@Type varchar(1)" _
                 & " set @Type = (select COUNT(*) from dbo.m_RPartStationD_t a left join dbo.m_Mainmo_t b on " _
                 & " a.PPartid=b.PartID left join dbo.m_Assysn_t c on b.Moid=c.Moid " _
                 & " where a.State='1' and c.Ppid='" & OldPPid & "' and ScanOrderid=1)" _
                 & " begin if @Type = '1'  " _
                 & " set @Return = case(select 1 from m_SnSBarCode_t a join m_Assysn_t b on a.moid=b.moid and b.ppid='" & OldPPid & "' " _
                 & " where a.UseY='Y' and a.SBarCode='" & NewPPid & "') when '2' then '2' else '1' end    else" _
                 & " set @Return = case (select 1 from m_Assysn_t where Estateid='Y' and ppid='" & NewPPid & "')" _
                 & " when '2' then '2' else '1' end  " _
                 & " end" _
                 & " set @ReturnD = case (select 2 from m_CartonSn_t where ppid='" & NewPPid & "')" _
                 & " when '2' then '2' else '1' end    select @Return,@ReturnD " _
                 & " if @Return='1' and @ReturnD='1' begin " _
                 & " set @Cartonid = (select Cartonid from m_CartonSn_t where ppid='" & OldPPid & "')" _
                 & " update m_Ppidlink_t set Usey='N',Canceluser='" & SysMessageClass.UseId.Trim.ToLower & "',Canceltime=getdate() where Exppid='" & OldPPid & "'" _
                 & " update m_Assysn_t set Ppid='" & NewPPid & "',Userid='" & SysMessageClass.UseId.Trim.ToLower & "',Intime=getdate() where Ppid='" & OldPPid & "'" _
                 & " update m_AssysnD_t set Ppid='" & NewPPid & "',Userid='" & SysMessageClass.UseId.Trim.ToLower & "',Intime=getdate() where Ppid='" & OldPPid & "'" _
                 & " delete m_CartonSn_t where ppid='" & OldPPid & "'" _
                 & " insert m_CartonSn_t values('" & NewPPid & "',@Cartonid,'" & SysMessageClass.UseId.Trim.ToLower & "',getdate(),null)  " _
                 & " insert into m_Ppidlink_t select '" & NewPPid & "',StaOrderid,ScanOrderid,Itemid,Ppid,'Y','" & SysMessageClass.UseId.Trim.ToLower & "'," _
                 & " getdate(),Canceluser,Canceltime,Tpartid,Codeid,Stationid,Partid ,Rstateid, Revid ,lotid, Mark1,Mark2,Mark3,  Mark4 from m_Ppidlink_t  a where a.Exppid='" & OldPPid & "'    end " _
                 & " select @Cartonid,a.ppid,'" & OldPPid & "',b.moid,c.partid,d.username,Convert(varchar(19),a.intime,21)" _
                 & " from dbo.m_CartonSn_t as a left join dbo.m_Carton_t b on a.Cartonid=b.Cartonid left join dbo.m_Mainmo_t as c " _
                 & " on b.moid=c.moid left join dbo.m_Users_t as d on a.userid=d.userid " _
                 & " where a.ppid='" & NewPPid & "'"
        ds = DbOperateUtils.GetDataSet(SqlStr)
        If ds.Tables(0).Rows(0)(0) = "1" Then
            If ds.Tables(0).Rows(0)(1) = "1" Then
                dt = ds.Tables(1)
                For i As Int16 = 0 To dt.Rows.Count - 1
                    dgv.Rows.Add(dt.Rows(i)(0).ToString, dt.Rows(i)(1).ToString, dt.Rows(i)(2).ToString, dt.Rows(i)(3).ToString,
                                 dt.Rows(i)(4).ToString, dt.Rows(i)(5).ToString, dt.Rows(i)(6).ToString)
                Next
                'MessageBox.Show("产品替换成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MessageUtils.ShowInformation("产品替换成功!")
            Else
                'MessageBox.Show("条码替换发生错误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MessageUtils.ShowInformation("条码替换发生错误!")
                txtNewppid_H.Focus()
                txtNewppid_H.Text = ""
            End If
        Else
            'MessageBox.Show("条码替换发生错误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MessageUtils.ShowInformation("条码替换发生错误!")
            txtNewppid_H.Focus()
            txtNewppid_H.Text = ""
        End If
        ds.Dispose()
        dt.Dispose()
        'Conn = Nothing
    End Sub
    '拆关联
    Private Sub ChaiLink(ByVal dgv As DataGridView, ByVal BarCodeStr As String, ByVal BarCodeType As String)
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlStr As String
        Dim dt As New DataTable

        Select Case BarCodeType
            Case "Cartonid"
                LblPartid.Text = ""
                Dim StationStr As String = ""
                Dim StaOrderid As Byte
                LoadDataToDgvQueryM(dgv, BarCodeStr, BarCodeType)
                Dim mReader As DataTable = DbOperateUtils.GetDataTable(" select a.stationid,StaOrderid from m_RPartStationD_t a join m_Rstation_t b on a.stationid=b.stationid where b.Stationtype='P' and  ppartid='" & LblPartid.Text.Trim & "' and state=1  and ScanOrderid=1")
                If mReader.Rows.Count > 0 Then
                    StationStr = mReader.Rows(0)!stationid
                    StaOrderid = mReader.Rows(0)!StaOrderid
                Else
                    'mReader.Close()
                    MessageUtils.ShowInformation("该产品料号在料件站点资料里，没有设置包装站或已拆关联!")
                    'MessageBox.Show("该产品料号在料件站点资料里，没有设置包装站或已拆关联", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                'mReader.Close()

                Dim PreStationid As String = ""
                If StaOrderid > 1 Then
                    Dim preOrderNo As Byte = StaOrderid - 1
                    mReader = DbOperateUtils.GetDataTable("select stationid from m_RPartStationD_t where PPartid='" & LblPartid.Text & "' and StaOrderid='" & preOrderNo & "' and State=1 and ScanOrderid=1")
                    If mReader.Rows.Count = 0 Then
                        'MessageBox.Show("该条码站点资料并没有前面工站...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        MessageUtils.ShowInformation("该条码站点资料并没有前面工站!")
                        Exit Sub
                    Else
                        PreStationid = mReader.Rows(0)!stationid
                    End If
                End If

                Try
                    SqlStr = " DECLARE  @RTVALUE varchar(1),@RTMSG varchar(50) " & _
             " execute [Exec_AssemblyExceptionHandle]  @RTVALUE OUTPUT, " & _
             " @RTMSG OUTPUT,'" & SysMessageClass.FactoryId & "','" & SysMessageClass.FactoryId & "','" & SysMessageClass.UseId & "'," & _
             "'" & StationStr & "','" & PreStationid & "','" & StaOrderid & "'," & _
             " '" & BarCodeStr & "' ,'','0' " & _
             " select @RTVALUE,@RTMSG "
                    Dim drGetSQLRecor As DataTable = DbOperateUtils.GetDataTable(SqlStr)
                    If drGetSQLRecor.Rows.Count > 0 Then
                        If drGetSQLRecor.Rows(0)(0).ToString() = "0" Then
                            'MessageBox.Show(drGetSQLRecor.Rows(0)(1).ToString(), "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            MessageUtils.ShowInformation(drGetSQLRecor.Rows(0)(1).ToString())
                        Else
                            MessageUtils.ShowInformation("拆分外箱关联" & BarCodeStr & "完成")
                            'MessageBox.Show("拆分外箱关联" & BarCodeStr & "完成", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Catch ex As Exception
                    'MessageBox.Show("拆分外箱关联时，发生错误" & ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MessageUtils.ShowInformation("拆分外箱关联时，发生错误" & ex.Message)
                End Try
            Case "Mppid"
                LblPartid.Text = ""
                LoadDataToDgvQueryM(dgv, BarCodeStr, BarCodeType)
                Dim Stationid As String = ""
                Dim ScanDate As String = ""
                Dim mReader As DataTable = DbOperateUtils.GetDataTable("select stationid,intime from m_Assysn_t where ppid='" & BarCodeStr & "' ")
                If mReader.Rows.Count > 0 Then
                    Stationid = mReader.Rows(0)!stationid
                    ScanDate = mReader.Rows(0)!intime
                Else
                    MessageUtils.ShowInformation("不存在该产品条码或已被拆关联")
                    'MessageBox.Show("不存在该产品条码或已被拆关联...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim StaOrderNo As Byte
                mReader = DbOperateUtils.GetDataTable("select StaOrderid from m_RPartStationD_t where PPartid='" & LblPartid.Text & "' and stationid='" & Stationid & "' and State=1 and ScanOrderid=1")
                If mReader.Rows.Count = 0 Then
                    MessageUtils.ShowInformation("该条码未设置站点资料或未进行关联扫描")
                    'MessageBox.Show("该条码未设置站点资料或未进行关联扫描...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    StaOrderNo = mReader.Rows(0)!StaOrderid
                End If

                Dim PreStationid As String = ""
                If StaOrderNo > 1 Then
                    Dim preOrderNo As Byte = StaOrderNo - 1
                    mReader = DbOperateUtils.GetDataTable("select stationid from m_RPartStationD_t where PPartid='" & LblPartid.Text & "' and StaOrderid='" & preOrderNo & "' and State=1 and ScanOrderid=1")
                    If mReader.Rows.Count = 0 Then
                        'MessageBox.Show("该条码站点资料并没有前面工站...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        MessageUtils.ShowInformation("该条码站点资料并没有前面工站")
                        Exit Sub
                    Else
                        PreStationid = mReader.Rows(0)!stationid
                    End If
                End If

                SqlStr = " delete from m_AssysnD_t where ppid='" & BarCodeStr & "' and stationid='" & Stationid & "'"
                SqlStr = SqlStr & vbNewLine & " INSERT INTO m_PpidlinkDelete_t SELECT  Exppid, StaOrderid, ScanOrderid, Itemid, Ppid, Usey, Userid, Intime, Canceluser, Canceltime, Tpartid, Codeid, StationId, Partid, Rstateid, Revid, Lotid, Mark1, Mark2, Mark3, Mark4, '" & SysMessageClass.UseId & "', GETDATE() FROM m_Ppidlink_t(NOLOCK) WHERE exppid='" & BarCodeStr & "' and stationid='" & Stationid & "'"
                SqlStr = SqlStr & vbNewLine & " delete from m_PpidLink_t where exppid='" & BarCodeStr & "' and stationid='" & Stationid & "'"
                SqlStr = SqlStr & vbNewLine & " insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,Moid,Userid,Intime,OldTime)Values('" & BarCodeStr & "',''," & _
                " N'拆关联','" & SysMessageClass.UseId.Trim & "',getdate(),'" & ScanDate & "')"
                If StaOrderNo = 1 Then
                    SqlStr = SqlStr & vbNewLine & " delete from m_Assysn_t where ppid='" & BarCodeStr & "' and stationid='" & Stationid & "'"
                    SqlStr = SqlStr & vbNewLine & " update m_snsbarcode_t set usey='Y' where sbarcode='" & BarCodeStr & "'"
                Else
                    SqlStr = SqlStr & vbNewLine & " update m_Assysn_t set stationid='" & PreStationid & "' where ppid='" & BarCodeStr & "'"
                End If
                Try
                    DbOperateUtils.ExecSQL(SqlStr)
                    'MessageBox.Show("主条码拆分关联：" & BarCodeStr & " 完成", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MessageUtils.ShowInformation("主条码拆分关联：" & BarCodeStr & " 完成")
                Catch ex As Exception
                    'MessageBox.Show("主条码拆分关联时，发生错误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MessageUtils.ShowInformation("主条码拆分关联时，发生错误")
                End Try

        End Select
    End Sub

#End Region

#Region "按钮"
    '执行按钮--关联查询
    Private Sub btnGo_Q_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo_Q.Click
        If Me.txtCartonid_Q.Text.Trim = "" AndAlso Me.txtMppid_Q.Text.Trim = "" AndAlso Me.txtDppid_Q.Text.Trim = "" Then Exit Sub

        Me.dgvQueryM.Rows.Clear()
        Me.dgvQueryD.Rows.Clear()
        '
        If Me.txtCartonid_Q.Text.Trim <> "" Then
            LoadDataToDgvQueryM(Me.dgvQueryM, Me.txtCartonid_Q.Text.Trim, "Cartonid")
        End If
        '
        If Me.txtMppid_Q.Text.Trim <> "" Then
            LoadDataToDgvQueryM(Me.dgvQueryM, Me.txtMppid_Q.Text.Trim, "Mppid")
        End If
        '
        If Me.txtDppid_Q.Text.Trim <> "" Then
            LoadDataToDgvQueryM(Me.dgvQueryM, Me.txtDppid_Q.Text.Trim, "Dppid")
        End If
    End Sub
    '执行按钮--拆关联
    Private Sub btnGo_W_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo_W.Click
        If Me.txtCartonid_W.Text.Trim = "" AndAlso Me.txtMppid_W.Text.Trim = "" Then Exit Sub
        '睲
        Me.dgvChai_M.Rows.Clear()
        Me.dgvChai_D.Rows.Clear()
        '╊絚
        If Me.txtCartonid_W.Text.Trim <> "" Then
            ChaiLink(Me.dgvChai_M, Me.txtCartonid_W.Text.Trim, "Cartonid")
        End If
        '╊Θ珇
        If Me.txtMppid_W.Text.Trim <> "" Then
            ChaiLink(Me.dgvChai_M, Me.txtMppid_W.Text.Trim, "Mppid")
        End If
    End Sub
    '替换执行
    Private Sub btnGo_H_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo_H.Click
        If Me.txtOldppid_H.Text.Trim = "" OrElse Me.txtNewppid_H.Text.Trim = "" Then Exit Sub
        '
        LoadDataToDgvReplace(Me.dgvReplace, Me.txtNewppid_H.Text.Trim, Me.txtOldppid_H.Text.Trim)
    End Sub
    '退出 
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit_Q.Click, btnExit_H.Click, btnExit_W.Click
        Me.Close()
    End Sub
#End Region

#Region "GRID事件"
    'dgvQueryM
    Private Sub dgvQueryM_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQueryM.CellEnter, dgvChai_M.CellEnter
        If sender.Rows.Count = 0 OrElse sender.CurrentRow Is Nothing Then Exit Sub
        '
        If sender Is Me.dgvQueryM Then
            LoadDataToDgvQueryD(Me.dgvQueryD, Me.dgvQueryM.Item(1, Me.dgvQueryM.CurrentRow.Index).Value.ToString.Trim)
        End If
        '
        If sender Is Me.dgvChai_M Then
            LoadDataToDgvQueryD(Me.dgvChai_D, Me.dgvChai_M.Item(1, Me.dgvChai_M.CurrentRow.Index).Value.ToString.Trim)
        End If
    End Sub
    'TabControl切换
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.TabControl1.SelectedIndex = -1 Then Exit Sub
        Select Case Me.TabControl1.SelectedIndex
            Case 0
                Me.ActiveControl = Me.txtCartonid_Q
            Case 1
                Me.ActiveControl = Me.txtCartonid_W
            Case 2
                Me.ActiveControl = Me.txtOldppid_H
        End Select
    End Sub

    '旧条码离开事件
    Private Sub txtOldppid_H_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOldppid_H.Leave
        If Me.txtOldppid_H.Text = "" Then Exit Sub

        Dim SqlStr As String

        SqlStr = "select 1 from m_Assysn_t a join m_CartonSn_t b on a.ppid=b.ppid where a.Estateid<>'N' and a.ppid='" & Me.txtOldppid_H.Text.Trim & "'"
        If DbOperateUtils.GetDataTable(SqlStr).Rows.Count = 0 Then
            MessageBox.Show("不存在该产品信息的记录", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtOldppid_H.Text = ""
            Me.ActiveControl = Me.txtOldppid_H
        End If
    End Sub

    ''ゅセ秈ㄆン
    'Private Sub txt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCartonid_Q.Enter, txtMppid_Q.Enter, txtDppid_Q.Enter, txtCartonid_W.Enter, txtMppid_W.Enter, txtOldppid_H.Enter
    '    'Select Case sender.name.ToString.Trim
    '    '    Case "txtCartonid_Q", "txtMppid_Q", "txtDppid_Q"  '闽羛琩高ゅセ秈ㄆン
    '    '        Me.txtCartonid_Q.Text = ""
    '    '        Me.txtMppid_Q.Text = ""
    '    '        Me.txtDppid_Q.Text = ""
    '    '    Case "txtCartonid_W", "txtMppid_W"  '闽羛╊传ゅセ秈ㄆン
    '    '        Me.txtCartonid_W.Text = ""
    '    '        Me.txtMppid_W.Text = ""
    '    '    Case "txtOldppid_H"  '蠢传穨ゅセ秈ㄆン
    '    '        Me.txtOldppid_H.Text = ""
    '    '        Me.txtNewppid_H.Text = ""
    '    'End Select
    'End Sub

#End Region

End Class
