Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Text
Imports System.Data.SqlClient
Imports BarCodePrint
'rework by anday 2011/08/30

Public Class FrmNewLabel

    Dim PubClass As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim Teamid As String
    Dim Deptid As String
    Dim Strfloorid As String
    Dim StrWhid As String
    Dim StrAreaid As String
    Dim StrMoid As String
    Dim StrPartid As String
    Dim StrPacklink As String
    Dim StrCustName As String
    Dim Cartonlink As String
    Dim Datet As New DateTime
    Dim WNid As String
    Dim CartonStillQty As Integer
    Dim StrBDcScan As New StringBuilder

    Private Sub FrmNewLabel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        ''快捷建處理
        If e.KeyCode = Keys.P AndAlso e.Alt Then
            TsBnPrint_Click(sender, e)
        ElseIf e.KeyCode = Keys.T AndAlso e.Alt Then
            TsBtTest_Click(sender, e)
        ElseIf e.KeyCode = Keys.D AndAlso e.Alt Then
            TsBtDrop_Click(sender, e)
        ElseIf e.KeyCode = Keys.E AndAlso e.Alt Then
            TsBnBack_Click(sender, e)
        End If
    End Sub

    Private Sub FrmNewLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RecTable As New DataTable
        Dim Sqlstr As String
        Dim Pubclass As New SysDataBaseClass
        Me.CobShift.SelectedIndex = 0
        'check 修改打印時間的權限
        If CheckPrintTimeRight() = True Then DtpMakeDay.Enabled = True

        Sqlstr = "select '" & DtpMakeDay.Value.ToString & "' as Datet"
        RecTable = Pubclass.GetDataTable(Sqlstr)
        Datet = CType((RecTable.Rows(0).Item("Datet").ToString), DateTime)
        RecTable.Dispose()
        Me.SplitContainer1.Panel2Collapsed = True
        FillCobType(CobNCartonid, "select distinct a.cartonid from m_Carton_t a join m_Whclink_t b on a.cartonid=b.ncartonid join m_Mainmo_t c on a.moid=c.moid where a.cartonstatus='N' and c.factory in(select buttonid from m_UserRight_t a join m_Logtree_t b on a.tkey=b.tkey where b.tparent='F0_' and a.userid='" & SysMessageClass.UseId & "')")
        Me.TxtNeedQty.Focus()
    End Sub

#Region "check 修改打印時間的權限"
    Function CheckPrintTimeRight() As Boolean

        Dim Dr As SqlDataReader
        Dr = PubClass.GetDataReader("select 1 from m_UserRight_t a join m_Logtree_t b on a.tkey=b.tkey " & _
                                    "where b.tparent='m0830_'and b.tkey='m0830a_' and a.userid='" & SysMessageClass.UseId & "' ")
        If Dr.HasRows Then
            Dr.Close()
            Return True
        Else
            Dr.Close()
            Return False
        End If
    End Function

#End Region

#Region "新建單據編號函數"
    Private Function GetInWhId() As String ''新建單據編號，獲取最大編號

        Dim DataGridTable As DataTable
        DataGridTable = PubClass.GetDataTable("select max(Inwhid) from m_WhInM_t where substring(Inwhid,3,6)=convert(varchar(6),getdate(),12) and inwhid like 'WN%'")
        If DataGridTable.Rows(0).Item(0) Is DBNull.Value Then
            Return "WN" & Format(Now, "yyMMdd") & "0001"
        Else
            Return "WN" & Mid((1 & Mid(DataGridTable.Rows(0).Item(0), 3)) + 1, 2)
        End If
        DataGridTable = Nothing
    End Function
#End Region

#Region "掃描箱號"
    Private Sub BtCartonScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCartonScan.Click

        Dim DrScan As SqlDataReader = Nothing
        Dim StrPacklink As String
        If Trim(TxtCartonid.Text) = "" Then
            MessageBox.Show("裝箱序號不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Trim(Me.TxtNeedQty.Text) = "" Then
            MessageBox.Show("應裝數量不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCartonid.Text = ""
            TxtNeedQty.Focus()
            Exit Sub
        End If
        If CInt(Me.TxtNeedQty.Text) > 0 And Lblrealqty.Text = Me.TxtNeedQty.Text Then
            MessageBox.Show("產品數量已達到要求，不得再裝載!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCartonid.Text = ""
            ClearControl()
            Exit Sub
        End If
        If Me.CobNCartonid.Text <> "" AndAlso Me.DGridBarCode.Rows.Count < 1 Then
            MessageBox.Show("該箱拆合出現網絡通訊異常，請重新作業！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobNCartonid.SelectedIndex = -1
            Me.TxtMoid.Text = ""
            Me.TxtPartid.Text = ""
            Me.TxtNeedQty.Enabled = True
            TxtCartonid.Text = ""
            Exit Sub
        End If
        Try
            '******************************
            'rework by tangxiang  2008/12/30
            'reason : carton 表加“Packlink”字段
            '******************************
            'DrScan = PubClass.GetDataReader("select a.Packlink from m_PartPack_t a join m_Mainmo_t b on a.partid=b.partid join m_Carton_t c on b.moid=c.moid where a.usey='Y' and c.cartonid='" & Trim(Me.TxtCartonid.Text) & "'")
            DrScan = PubClass.GetDataReader("select Packlink from m_Carton_t where cartonid='" & Trim(Me.TxtCartonid.Text) & "'")
            If DrScan.Read Then

                StrPacklink = DrScan("Packlink").ToString
                DrScan.Close()
                Select Case StrPacklink
                    Case "P"
                        CartonPpScan()       ''連接PPID 
                    Case "N"
                        CartonOnlyScan()     ''無任何連接
                    Case "D"
                        CartonDcScan()       ''有連接D/C
                End Select
            Else
                MessageBox.Show("無法識別此箱號!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtCartonid.Clear()

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmNewLabel", "BtCartonScan_Click", "sys")
        Finally
            DrScan.Close()
        End Try

    End Sub


    Private Sub TxtCartonid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCartonid.KeyPress
        If e.KeyChar = Chr(13) Then
            BtCartonScan_Click(sender, e)
        End If
        e.KeyChar = UCase(e.KeyChar)
    End Sub
#End Region

    Private Sub CartonPpScan()
        Dim StrCartonid As String
        Dim StrNcartonid As String = ""
        Dim DrScan As SqlDataReader = Nothing
        Dim MoBarCode As New PrintJLabelNew
        Dim PrtArray As New SysMessageClass.PrtStructure
        Dim StrBnew As New StringBuilder
        Dim MoidStr As String = ""
        Dim PartidStr As String = ""
        Dim FristY As Boolean = False
        StrBnew.Remove(0, Len(StrBnew.ToString))

        Try
            '************************************* 
            'rework by tangxiang       2008/12/26
            'reason : cartyon表加入倉別，樓層別等 
            '*************************************
            'DrScan = PubClass.GetDataReader("select a.cartonstatus,a.moid,b.partid,a.cartonqty,b.deptid,a.teamid,e.cusname,i.floorid,i.whid,i.areaid from m_Carton_t a join m_Mainmo_t b on a.moid=b.moid JOIN m_WhInd_t h on a.cartonid=h.cartonid join m_WhInm_t i on h.inwhid=i.inwhid left join m_Customer_t e on b.cusid=e.cusid where a.cartonid='" & Trim(TxtCartonid.Text) & "'")
            DrScan = PubClass.GetDataReader("select a.cartonstatus,a.moid,b.partid,a.cartonqty,b.deptid,a.teamid,e.cusname,a.floorid,a.whid,a.areaid,a.Packlink,i.states from m_Carton_t a join m_Mainmo_t b on a.moid=b.moid JOIN m_WhInd_t h on a.cartonid=h.cartonid join m_WhInm_t i on h.inwhid=i.inwhid left join m_Customer_t e on b.cusid=e.cusid where a.cartonid='" & Trim(TxtCartonid.Text) & "'")
            If DrScan.Read Then
                '加入“未入庫的箱”不能拆合--2009/6/24--by tangxiang
                If DrScan("states").ToString = "1" Then
                    MessageBox.Show("該箱還未確認入庫,不能拆和!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                End If
                If DrScan("Partid").ToString <> TxtPartid.Text AndAlso TxtPartid.Text <> "" Then
                    MessageBox.Show("該箱不屬當前料號,不能拆和!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                End If
                If DrScan("cartonstatus").ToString = "N" Then
                    MessageBox.Show("該箱還未包裝完成,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "Y" Then
                    MessageBox.Show("該箱還未入庫,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "E" Then
                    MessageBox.Show("該箱已拆空,不能再使用!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "O" Then
                    MessageBox.Show("該箱已出庫,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "R" Then
                    MessageBox.Show("該箱已出庫重工,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "Q" Then
                    MessageBox.Show("該箱已FQC抽驗判退,不能拆合!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "I" OrElse DrScan("cartonstatus").ToString = "S" Then
                    If CInt(DrScan("cartonqty").ToString) + CInt(Lblrealqty.Text) > CInt(Me.TxtNeedQty.Text) Then
                        MessageBox.Show("產品數量超過應裝數量!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtCartonid.Clear()
                        DrScan.Close()
                        Exit Sub
                    End If
                    StrCartonid = Trim(Me.TxtCartonid.Text)
                    Me.TxtCartonid.Clear()
                    If Me.TxtPartid.Text = "" Then   ''掃描第一筆，調用打印指令產生新箱序號
                        FristY = True
                        MoidStr = DrScan("moid").ToString
                        PartidStr = DrScan("partid").ToString
                        Strfloorid = DrScan("floorid").ToString
                        StrWhid = DrScan("whid").ToString
                        StrAreaid = DrScan("Areaid").ToString
                        StrPacklink = DrScan("Packlink").ToString
                        StrCustName = DrScan("cusname").ToString
                        Teamid = DrScan("teamid").ToString
                        Deptid = DrScan("deptid").ToString
                        DrScan.Close()

                        PrtArray.AvcPartid = PartidStr
                        PrtArray.CusName = StrCustName
                        PrtArray.Deptid = Deptid
                        PrtArray.Lineid = Teamid
                        PrtArray.Moid = MoidStr
                        PrtArray.NowDate = Datet.ToString("yyyy-MM-dd")
                        PrtArray.NowMonth = Datet.ToString("MM")
                        PrtArray.Qty = Me.TxtNeedQty.Text

                        'rework by anday 2011/8/19
                        'Dim IntLabel As Integer = 0
                        'Dim strSql As String = "select top 1 b.partid,a.flen from dbo.m_SnRuleM_t a,M_partpack_t b where a.CodeRuleID=b.CodeRuleID and b.usey='Y' and partid='" & PartidStr & "'"
                        'Dim dt As DataTable = PubClass.GetDataTable(strSql)
                        'If dt.Rows.Count > 0 Then
                        '    IntLabel = CInt(dt.Rows(0)(0).ToString)
                        'End If
                        'If MoBarCode.MarkJLabel(PrtArray.ToArray, "Y") Then
                        '    If IntLabel <> MoBarCode.JLabelStr.Length Then
                        '        Dim MoBarCode As New PrintJLabelNew
                        '    End If
                        'Else
                        'End If


                        If MoBarCode.MarkJLabel(PrtArray.ToArray, "Y") Then
                            StrNcartonid = MoBarCode.JLabelStr
                            '*************** 
                            'rework by Anday 2011/08/19  
                            '***************
                            'StrBnew.Append("insert into m_Carton_t(Cartonid,Moid,Cartonqty,CartonStatus,Teamid,Userid,Intime) values('" & Trim(StrNcartonid) & "','" & Trim(MoidStr) & "','" & Trim(Me.TxtNeedQty.Text) & "','N','" & Trim(Teamid) & "','" & (SysMessageClass.UseId) & "',getdate())")
                            StrBnew.Append("insert into m_Carton_t(Cartonid,Moid,Cartonqty,CartonStatus,Teamid,floorid,Whid,Areaid,Packlink,Userid,Intime,updateuser,updatetime) " & _
                                           "values('" & Trim(StrNcartonid) & "','" & Trim(MoidStr) & "','" & Trim(Me.TxtNeedQty.Text) & "','N','" & Trim(Teamid) & "','" & Strfloorid & "'," & _
                                           "'" & StrWhid & "','" & StrAreaid & "','" & StrPacklink & "','" & (SysMessageClass.UseId) & "',getdate(),'" & (SysMessageClass.UseId) & "',getdate())")
                            StrBnew.Append(Environment.NewLine)
                            StrBnew.Append("insert into m_Whclink_t(Ppid,Ncartonid,Cartonid,MoveQty,Userid,Intime) select ppid,'" & Trim(StrNcartonid) & "','" & Trim(StrCartonid) & "',1,'" & (SysMessageClass.UseId) & "',getdate() from m_CartonSn_t where cartonid='" & Trim(StrCartonid) & "'")
                            StrBnew.Append(Environment.NewLine)
                            StrBnew.Append("update m_CartonSn_t set cartonid='" & Trim(StrNcartonid) & "' where cartonid='" & Trim(StrCartonid) & "'")
                            StrBnew.Append(Environment.NewLine)

                            MoBarCode = Nothing
                            Cartonlink = "P"
                        Else
                            MessageBox.Show("新箱生成失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            MoBarCode = Nothing
                            Exit Sub
                        End If
                    Else
                        StrBnew.Append("insert into m_Whclink_t(Ppid,Ncartonid,Cartonid,MoveQty,Userid,Intime) select ppid,'" & Trim(CobNCartonid.Text) & "','" & Trim(StrCartonid) & "',1,'" & (SysMessageClass.UseId) & "',getdate() from m_CartonSn_t where cartonid='" & Trim(StrCartonid) & "'")
                        StrBnew.Append(Environment.NewLine)
                        StrBnew.Append("update m_CartonSn_t set cartonid='" & Trim(CobNCartonid.Text) & "' where cartonid='" & Trim(StrCartonid) & "'")
                        StrBnew.Append(Environment.NewLine)

                    End If
                    '***************
                    'rework by tangxiang 2008/11/24
                    '***************
                    'StrBnew.Append("update m_Carton_t set cartonqty=0,CartonStatus='E' where Cartonid='" & Trim(StrCartonid) & "'")
                    StrBnew.Append("update m_Carton_t set cartonqty=0,CartonStatus='E',updatetime=getdate(),updateuser='" & (SysMessageClass.UseId) & "' where Cartonid='" & Trim(StrCartonid) & "'")

                    DrScan.Close()
                    DrScan = PubClass.GetDataReader("select palletid from m_PalletCarton_t where cartonid='" & Trim(StrCartonid) & "'")
                    If DrScan.Read Then
                        StrBnew.Append("update m_PalletM_t set palletqty=palletqty-1  where palletid='" & DrScan("palletid").ToString & "'")
                        StrBnew.Append(Environment.NewLine)
                        StrBnew.Append("update m_PalletCarton_t set usey='N' where cartonid='" & Trim(StrCartonid) & "'")
                        StrBnew.Append(Environment.NewLine)
                    End If
                    DrScan.Close()
                    PubClass.ExecSql(StrBnew.ToString)
                    StrBnew.Remove(0, Len(StrBnew.ToString))
                    If FristY = True Then
                        CobNCartonid.Items.Add(StrNcartonid)
                        CobNCartonid.SelectedIndex = CobNCartonid.Items.Count - 1
                        Me.TxtMoid.Text = MoidStr
                        Me.TxtPartid.Text = PartidStr
                        Me.TxtNeedQty.Enabled = False
                        FristY = False
                    End If
                    GetScanItem()
                    LabScanState.Text = "箱號條碼　" & StrCartonid & "　掃描成功"
                    PlaySimpleSound(0)
                    If Lblrealqty.Text = Me.TxtNeedQty.Text Then
                        MessageBox.Show("產品數量已達到要求!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearControl()
                        Exit Sub
                    End If
                End If
            Else
                MessageBox.Show("無法識別此箱號,或未經入庫掃描!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtCartonid.Clear()
                Exit Sub
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmNewLabel", "BtCartonScan_Click", "sys")
        Finally
            DrScan.Close()
        End Try

    End Sub

    Private Sub CartonOnlyScan()
        Dim StrCartonid As String
        Dim StrNcartonid As String = ""
        Dim DrScan As SqlDataReader = Nothing
        Dim MoBarCode As New PrintJLabelNew
        Dim PrtArray As New SysMessageClass.PrtStructure
        Dim StrBnew As New StringBuilder
        Dim CartonNowQty As Integer = 0
        Dim MoveQty As Integer = 0
        Dim CartonNowStatus As String = Nothing
        Dim MoidStr As String = ""
        Dim PartidStr As String = ""
        Dim FristY As Boolean = False

        StrBnew.Remove(0, Len(StrBnew.ToString))
        Try
            '***************************
            'rework by tangxiang  2008/12/26
            'reason : carton表加倉庫別，樓層別等
            '***************************
            'DrScan = PubClass.GetDataReader("select a.cartonstatus,a.moid,b.partid,a.cartonqty,b.deptid,a.teamid,e.cusname,i.floorid,i.whid,i.areaid from m_Carton_t a join m_Mainmo_t b on a.moid=b.moid JOIN m_WhInd_t h on a.cartonid=h.cartonid join m_WhInm_t i on h.inwhid=i.inwhid left join m_Customer_t e on b.cusid=e.cusid where a.cartonid='" & Trim(TxtCartonid.Text) & "'")
            DrScan = PubClass.GetDataReader("select a.cartonstatus,a.moid,b.partid,a.cartonqty,b.deptid,a.teamid,e.cusname,a.floorid,a.whid,a.areaid,a.Packlink,i.states from m_Carton_t a join m_Mainmo_t b on a.moid=b.moid JOIN m_WhInd_t h on a.cartonid=h.cartonid join m_WhInm_t i on h.inwhid=i.inwhid left join m_Customer_t e on b.cusid=e.cusid where a.cartonid='" & Trim(TxtCartonid.Text) & "'")
            If DrScan.Read Then
                '加入“未入庫的箱”不能拆合--2009/6/24--by tangxiang
                If DrScan("states").ToString = "1" Then
                    MessageBox.Show("該箱還未確認入庫,不能拆和!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                End If
                If DrScan("Partid").ToString <> TxtPartid.Text AndAlso TxtPartid.Text <> "" Then
                    MessageBox.Show("該箱不屬當前料號,不能拆和!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                End If
                If DrScan("cartonstatus").ToString = "N" Then
                    MessageBox.Show("該箱還未包裝完成,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "Y" Then
                    MessageBox.Show("該箱還未入庫,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "E" Then
                    MessageBox.Show("該箱已拆空,不能再使用!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "O" Then
                    MessageBox.Show("該箱已出庫,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "R" Then
                    MessageBox.Show("該箱已出庫重工,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "Q" Then
                    MessageBox.Show("該箱已FQC抽驗判退,不能拆合!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "I" OrElse DrScan("cartonstatus").ToString = "S" Then
                    If CInt(DrScan("cartonqty").ToString) + CInt(Lblrealqty.Text) > CInt(Me.TxtNeedQty.Text) Then
                        MoveQty = CInt(Me.TxtNeedQty.Text) - CInt(Lblrealqty.Text)
                        CartonNowQty = CInt(DrScan("cartonqty").ToString) - MoveQty
                        Lblrealqty.Text = CInt(Me.TxtNeedQty.Text)
                        CartonNowStatus = "S"
                    Else
                        MoveQty = CInt(DrScan("cartonqty").ToString)
                        CartonNowQty = 0
                        Lblrealqty.Text = CInt(Lblrealqty.Text) + CInt(DrScan("cartonqty").ToString)
                        CartonNowStatus = "E"
                    End If
                    StrCartonid = Trim(Me.TxtCartonid.Text)
                    Me.TxtCartonid.Clear()
                    If Me.TxtPartid.Text = "" Then
                        FristY = True
                        MoidStr = DrScan("moid").ToString
                        PartidStr = DrScan("partid").ToString
                        Strfloorid = DrScan("floorid").ToString
                        StrWhid = DrScan("whid").ToString
                        StrAreaid = DrScan("Areaid").ToString
                        StrPacklink = DrScan("Packlink").ToString
                        StrCustName = DrScan("cusname").ToString
                        Teamid = DrScan("teamid").ToString
                        Deptid = DrScan("deptid").ToString
                        DrScan.Close()

                        PrtArray.AvcPartid = PartidStr
                        PrtArray.CusName = StrCustName
                        PrtArray.Deptid = Deptid
                        PrtArray.Lineid = Teamid
                        PrtArray.Moid = MoidStr
                        PrtArray.NowDate = Datet.ToString("yyyy-MM-dd")
                        PrtArray.NowMonth = Datet.ToString("MM")
                        PrtArray.Qty = Me.TxtNeedQty.Text

                        If MoBarCode.MarkJLabel(PrtArray.ToArray, "Y") Then
                            StrNcartonid = MoBarCode.JLabelStr
                            '***************
                            'rework by tangxiang 2008/12/26
                            '***************
                            'StrBnew.Append("insert into m_Carton_t(Cartonid,Moid,Cartonqty,CartonStatus,Teamid,Userid,Intime) values('" & Trim(StrNcartonid) & "','" & Trim(MoidStr) & "','" & Trim(Me.TxtNeedQty.Text) & "','N','" & Trim(Teamid) & "','" & (SysMessageClass.UseId) & "',getdate())")
                            StrBnew.Append("insert into m_Carton_t(Cartonid,Moid,Cartonqty,CartonStatus,Teamid,Floorid,Whid,Areaid,Packlink,Userid,Intime,updateuser,updatetime) " & _
                                           "values('" & Trim(StrNcartonid) & "','" & Trim(MoidStr) & "','" & Trim(Me.TxtNeedQty.Text) & "','N','" & Trim(Teamid) & "','" & Strfloorid & "'," & _
                                           "'" & StrWhid & "','" & StrAreaid & "','" & StrPacklink & "','" & (SysMessageClass.UseId) & "',getdate(),'" & (SysMessageClass.UseId) & "',getdate())")
                            StrBnew.Append(Environment.NewLine)
                            StrBnew.Append("insert into m_Whclink_t(Ppid,Ncartonid,Cartonid,MoveQty,Userid,Intime) values( 'NoPPID','" & Trim(StrNcartonid) & "','" & StrCartonid & "','" & MoveQty & "','" & (SysMessageClass.UseId) & "',getdate() )")
                            StrBnew.Append(Environment.NewLine)
                            MoBarCode = Nothing
                            Cartonlink = "N"
                        Else
                            MoBarCode = Nothing
                            MessageBox.Show("新箱生成失敗", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Else
                        StrBnew.Append("insert into m_Whclink_t(Ppid,Ncartonid,Cartonid,MoveQty,Userid,Intime) values( 'NoPPID','" & Trim(Me.CobNCartonid.Text) & "','" & StrCartonid & "','" & MoveQty & "','" & (SysMessageClass.UseId) & "',getdate() )")
                        StrBnew.Append(Environment.NewLine)
                    End If
                    DrScan.Close()
                    DrScan = PubClass.GetDataReader("select palletid from m_PalletCarton_t where cartonid='" & Trim(StrCartonid) & "'")
                    If DrScan.Read Then
                        StrBnew.Append("update m_PalletM_t set palletqty=palletqty-1  where palletid='" & DrScan("palletid").ToString & "'")
                        StrBnew.Append(Environment.NewLine)
                        StrBnew.Append("update m_PalletCarton_t set usey='N' where cartonid='" & Trim(StrCartonid) & "'")
                        StrBnew.Append(Environment.NewLine)
                    End If
                    DrScan.Close()

                    '***************
                    'rework by tangxiang 2008/11/24
                    '***************
                    'StrBnew.Append("update m_Carton_t set CartonStatus='" & CartonNowStatus & "',cartonqty='" & CartonNowQty & "' where Cartonid='" & Trim(StrCartonid) & "'")
                    StrBnew.Append("update m_Carton_t set CartonStatus='" & CartonNowStatus & "',cartonqty='" & CartonNowQty & "',updateuser='" & (SysMessageClass.UseId) & "',updatetime=getdate() where Cartonid='" & Trim(StrCartonid) & "'")
                    PubClass.ExecSql(StrBnew.ToString)
                    StrBnew.Remove(0, Len(StrBnew.ToString))
                    If FristY = True Then
                        CobNCartonid.Items.Add(StrNcartonid)
                        CobNCartonid.SelectedIndex = CobNCartonid.Items.Count - 1
                        Me.TxtMoid.Text = MoidStr
                        Me.TxtPartid.Text = PartidStr
                        Me.TxtNeedQty.Enabled = False
                        FristY = False
                    End If
                    GetCartonScanItem()
                    LabScanState.Text = "箱號條碼　" & StrCartonid & "　掃描成功"
                    PlaySimpleSound(0)
                    If Lblrealqty.Text = Me.TxtNeedQty.Text Then
                        MessageBox.Show("數量已達到要求!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearControl()
                        Exit Sub
                    End If
                End If
            Else
                MessageBox.Show("無法識別此箱號,或未經入庫掃描!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtCartonid.Clear()
                Exit Sub
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmNewLabel", "BtCartonScan_Click", "sys")
        Finally
            DrScan.Close()
        End Try
    End Sub

    Private Sub CartonDcScan()
        Dim DrScan As SqlDataReader = Nothing
        Dim MoBarCode As New PrintJLabelNew
        Dim PrtArray As New SysMessageClass.PrtStructure
        Dim CartonNowQty As Integer = 0
        Dim CartonQty, Inti As Integer
        Dim MoveQty As Integer = 0
        Dim CartonNowStatus As String = Nothing

        StrBDcScan.Remove(0, Len(StrBDcScan.ToString))
        Try
            '***********加入不同DateCode不能合箱的信息提示---by tangxiang---2009/6/23
            If DGridBarCode.Rows.Count > 0 Then
                DrScan = PubClass.GetDataReader("select dcno from m_cartonlot_t where cartonid='" & Trim(TxtCartonid.Text) & "'")
                If DrScan.HasRows Then
                    While DrScan.Read
                        For Inti = 0 To DGridBarCode.Rows.Count - 1
                            If DrScan("dcno").ToString <> DGridBarCode.Item(0, Inti).Value Then
                                Dim FrmInformation As New FrmInfShow
                                Dim ClassInf As New InfClass
                                ClassInf.StrInf = "        " & SysMessageClass.UseId & "                                      " & _
                                                  "        中興、愛默生、康舒、騰訊等客戶          出貨有不同DateCode時,嚴禁做拆合箱作業"
                                ClassInf.StrColor = Color.Red
                                ClassInf.StrQInf = "你確定拆合這箱產品嗎?"
                                ClassInf.StrQColor = Color.Red
                                PlaySimpleSound(3)
                                FrmInformation.ShowDialog()
                                If ClassInf.ChoseY = False Then
                                    DrScan.Close()
                                    Exit Sub
                                End If
                            End If
                        Next
                    End While
                End If
                DrScan.Close()
            End If

            '****************************
            'rework by tangxiang  2008/12/26
            'reason : carton 表中加樓層別，倉庫別等
            '****************************
            'DrScan = PubClass.GetDataReader("select a.cartonstatus,a.moid,b.partid,a.cartonqty,b.deptid,a.teamid,e.cusname,i.floorid,i.whid,i.areaid from m_Carton_t a join m_Mainmo_t b on a.moid=b.moid JOIN m_WhInd_t h on a.cartonid=h.cartonid join m_WhInm_t i on h.inwhid=i.inwhid left join m_Customer_t e on b.cusid=e.cusid where a.cartonid='" & Trim(TxtCartonid.Text) & "'")
            DrScan = PubClass.GetDataReader("select a.cartonstatus,a.moid,b.partid,a.cartonqty,b.deptid,a.teamid,e.cusname,a.floorid,a.whid," & _
            " a.areaid,a.Packlink,g.dcno,i.states,b.Factory,d.djmdc,k.linejm from m_Carton_t a join m_cartonlot_t g on a.cartonid=g.cartonid join m_Mainmo_t b on a.moid=b.moid " & _
            "  left join m_Dept_t d on b.deptid=d.deptid join m_WhInd_t h on a.cartonid=h.cartonid join m_WhInm_t i on h.inwhid=i.inwhid left join m_Customer_t e " & _
            " on b.cusid=e.cusid left join m_snsbarcode_t p on a.cartonid=p.sbarcode left join deptline_t k on b.deptid=k.deptid and p.lineid=k.lineid and k.usey='Y' where a.cartonid='" & Trim(TxtCartonid.Text) & "'")
            If DrScan.Read Then
                '加入“未入庫的箱”不能拆合--2009/6/24--by tangxiang
                If DrScan("states").ToString = "1" Then
                    MessageBox.Show("該箱還未確認入庫,不能拆和!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                End If
                If DrScan("Partid").ToString <> TxtPartid.Text AndAlso TxtPartid.Text <> "" Then
                    MessageBox.Show("該箱不屬當前料號,不能拆和!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                End If
                If DrScan("cartonstatus").ToString = "N" Then
                    MessageBox.Show("該箱還未包裝完成,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "Y" Then
                    MessageBox.Show("該箱還未入庫,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "E" Then
                    MessageBox.Show("該箱已拆空,不能再使用!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "O" Then
                    MessageBox.Show("該箱已出庫,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "R" Then
                    MessageBox.Show("該箱已出庫重工,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "Q" Then
                    MessageBox.Show("該箱已FQC抽驗判退,不能拆合!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Clear()
                    DrScan.Close()
                    Exit Sub
                ElseIf DrScan("cartonstatus").ToString = "I" OrElse DrScan("cartonstatus").ToString = "S" Then
                    CartonQty = CInt(DrScan("cartonqty").ToString)
                    StrPartid = DrScan("partid").ToString
                    StrMoid = DrScan("moid").ToString
                    StrCustName = DrScan("cusname").ToString
                    Strfloorid = DrScan("floorid").ToString
                    StrWhid = DrScan("whid").ToString
                    StrAreaid = DrScan("Areaid").ToString
                    StrPacklink = DrScan("Packlink").ToString
                    Teamid = DrScan("teamid").ToString
                    Deptid = DrScan("deptid").ToString
                    '''''oxf20111118
                    Me.TxtFactory.Text = DrScan("Factory").ToString
                    Me.TxtDeptJM.Text = DrScan("djmdc").ToString
                    Me.TxtlineJM.Text = DrScan("linejm").ToString
                    '''''''''''
                    DrScan.Close()
                    If Me.TxtPartid.Text = "" Then

                        TxtMoid.Text = StrMoid
                        Me.TxtPartid.Text = StrPartid
                        Me.TxtNeedQty.Enabled = False
                       

                        PrtArray.AvcPartid = Me.TxtPartid.Text
                        PrtArray.CusName = StrCustName
                        PrtArray.Deptid = Deptid
                        PrtArray.Lineid = Teamid
                        PrtArray.Moid = TxtMoid.Text
                        PrtArray.NowDate = Datet.ToString("yyyy-MM-dd")
                        PrtArray.NowMonth = Datet.ToString("MM")
                        PrtArray.Qty = Me.TxtNeedQty.Text



                        '''''''''''''''''''''''''''''

                        Dim Year As String = Mid(DatePart(DateInterval.Year, CDate(PrtArray.NowDate)), 3)
                        Dim Week As String = Microsoft.VisualBasic.Right(StrDup(2, "0") & (DatePart(DateInterval.WeekOfYear, CDate(PrtArray.NowDate).AddDays(-1)) - 1), 2)
                        Dim DayWeek As String = DatePart(DateInterval.Weekday, CDate(PrtArray.NowDate).AddDays(-1))

                        Dim DeptJm As String = Me.TxtDeptJM.Text
                        Dim Factory As String
                        If UCase(TxtFactory.Text) = "SZ" Then
                            Factory = "C"
                        Else
                            Factory = "N"
                        End If
                        Dim mShift As String

                        If CobShift.Text = "白班" Then
                            mShift = "D"
                        Else
                            mShift = "N"
                        End If


                        Dim lineJm As String = Me.TxtlineJM.Text

                        Dim dc1 As String = DeptJm & lineJm & Year & Week _
                                       & DayWeek & mShift & Factory
                        PrtArray.WorkType = mShift
                        PrtArray.DateCode = dc1

                        '''''''''''''''''''''''''''''''''''



                        If MoBarCode.MarkJLabel(PrtArray.ToArray, "Y") Then
                            CobNCartonid.Items.Add(MoBarCode.JLabelStr)
                            MoBarCode = Nothing
                            CobNCartonid.SelectedIndex = CobNCartonid.Items.Count - 1
                            Cartonlink = "D"
                        End If
                        If CobNCartonid.Text.Trim = "" Then
                            MessageBox.Show("新箱生成失敗", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                        '***************
                        'rework by tangxiang 2008/12/26
                        '***************
                        'StrBDcScan.Append("insert into m_Carton_t(Cartonid,Moid,Cartonqty,CartonStatus,Teamid,Userid,Intime) values('" & Trim(CobNCartonid.Text) & "','" & Trim(TxtMoid.Text) & "','" & Trim(Me.TxtNeedQty.Text) & "','N','" & Trim(Teamid) & "','" & (SysMessageClass.UseId) & "',getdate())")
                        StrBDcScan.Append("insert into m_Carton_t(Cartonid,Moid,Cartonqty,CartonStatus,Teamid,Floorid,Whid,Areaid,Packlink,Userid,Intime,updateuser,updatetime) " & _
                                          "values('" & Trim(CobNCartonid.Text) & "','" & Trim(TxtMoid.Text) & "','" & Trim(Me.TxtNeedQty.Text) & "','N','" & Trim(Teamid) & "','" & Strfloorid & "'," & _
                                          "'" & StrWhid & "','" & StrAreaid & "','" & StrPacklink & "','" & (SysMessageClass.UseId) & "',getdate(),'" & (SysMessageClass.UseId) & "',getdate())")
                        StrBDcScan.Append(Environment.NewLine)
                    End If

                    If CartonQty + CInt(Lblrealqty.Text) > CInt(Me.TxtNeedQty.Text) Then
                        MoveQty = CInt(Me.TxtNeedQty.Text) - CInt(Lblrealqty.Text)
                        CartonStillQty = CartonQty - MoveQty
                        CartonNowQty = CartonQty - MoveQty
                        CartonNowStatus = "S"
                        DrScan = PubClass.GetDataReader("select Count(*) DCcount from m_CartonLot_t where cartonid='" & TxtCartonid.Text & "'")
                        DrScan.Read()
                        If CInt(DrScan("DCcount").ToString) > 1 Then
                            Me.SplitContainer1.Panel2Collapsed = False
                            DrScan.Close()
                            Me.TxtCartonid.Enabled = False
                            Me.BtCartonScan.Enabled = False
                            DcChoose()
                            Me.DgDcload.Focus()
                            Exit Sub
                        End If
                        DrScan.Close()
                        StrBDcScan.Append("insert into m_Whclink_t(Ppid,Ncartonid,Cartonid,MoveQty,Userid,Intime) Select dcno,'" & Trim(CobNCartonid.Text) & "','" & Trim(TxtCartonid.Text) & "','" & MoveQty & "','" & (SysMessageClass.UseId) & "',getdate()  from m_CartonLot_t where cartonid='" & Trim(TxtCartonid.Text) & "'")
                        StrBDcScan.Append(Environment.NewLine)
                    Else
                        MoveQty = CartonQty
                        CartonNowQty = 0
                        Lblrealqty.Text = CInt(Lblrealqty.Text) + CartonQty
                        CartonNowStatus = "E"
                        StrBDcScan.Append("insert into m_Whclink_t(Ppid,Ncartonid,Cartonid,MoveQty,Userid,Intime) Select dcno,'" & Trim(CobNCartonid.Text) & "','" & Trim(TxtCartonid.Text) & "',dcqty,'" & (SysMessageClass.UseId) & "',getdate()  from m_CartonLot_t where cartonid='" & Trim(TxtCartonid.Text) & "'")
                        StrBDcScan.Append(Environment.NewLine)
                    End If
                    DrScan = PubClass.GetDataReader("select palletid from m_PalletCarton_t where cartonid='" & Trim(TxtCartonid.Text) & "'")
                    If DrScan.Read Then
                        StrBDcScan.Append("update m_PalletM_t set palletqty=palletqty-1  where palletid='" & DrScan("palletid").ToString & "'")
                        StrBDcScan.Append(Environment.NewLine)
                        StrBDcScan.Append("update m_PalletCarton_t set usey='N' where cartonid='" & Trim(TxtCartonid.Text) & "'")
                        StrBDcScan.Append(Environment.NewLine)
                    End If
                    DrScan.Close()
                    StrBDcScan.Append("update m_CartonLot_t set dcqty='" & CartonNowQty & "' where cartonid='" & Trim(TxtCartonid.Text) & "'")
                    StrBDcScan.Append(Environment.NewLine)
                    StrBDcScan.Append("delete from m_CartonLot_t where cartonid='" & Trim(CobNCartonid.Text) & "'")
                    StrBDcScan.Append(Environment.NewLine)
                    StrBDcScan.Append("insert into m_CartonLot_t(Dcno,cartonid,dcqty,userid,intime) select ppid,'" & Trim(CobNCartonid.Text) & "',sum(moveqty),'" & (SysMessageClass.UseId) & "',getdate() from dbo.m_Whclink_t where ncartonid='" & Trim(CobNCartonid.Text) & "' group by ppid")
                    StrBDcScan.Append(Environment.NewLine)
                    '***************
                    'rework by tangxiang 2008/11/24
                    '***************
                    'StrBDcScan.Append("update m_Carton_t set CartonStatus='" & CartonNowStatus & "',cartonqty='" & CartonNowQty & "' where Cartonid='" & Trim(TxtCartonid.Text) & "'")
                    StrBDcScan.Append("update m_Carton_t set CartonStatus='" & CartonNowStatus & "',cartonqty='" & CartonNowQty & "',updateuser='" & (SysMessageClass.UseId) & "',updatetime=getdate() where Cartonid='" & Trim(TxtCartonid.Text) & "'")
                    PubClass.ExecSql(StrBDcScan.ToString)
                    StrBDcScan.Remove(0, Len(StrBDcScan.ToString))
                    GetCartonDcScanItem()
                    LabScanState.Text = "箱號條碼　" & TxtCartonid.Text & "　掃描成功"
                    TxtCartonid.Text = ""
                    PlaySimpleSound(0)
                    If Lblrealqty.Text = Me.TxtNeedQty.Text Then
                        MessageBox.Show("數量已達到要求!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '2009/8/25  tangxiang  拆合完畢後清空控件
                        ClearControl()
                        Exit Sub
                    End If
                End If
            Else
                MessageBox.Show("無法識別此箱號,或未經入庫掃描!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtCartonid.Clear()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmNewLabel", "BtCartonScan_Click", "sys")
        Finally
            DrScan.Close()
        End Try
    End Sub

    Private Sub DcChoose()          ''顯示箱內D/C的裝箱記錄
        Dim DtDcload As DataTable
        Dim K As Integer
        DtDcload = PubClass.GetDataTable("select 'false' ChooseY,cartonid,dcno,dcqty,'' moveqty from m_CartonLot_t where cartonid='" & TxtCartonid.Text.Trim() & "'")
        DgDcload.Rows.Clear()
        DgDcload.ScrollBars = ScrollBars.None
        For K = 0 To DtDcload.Rows.Count - 1
            DgDcload.Rows.Add(DtDcload.Rows(K)("ChooseY"), DtDcload.Rows(K)("cartonid"), DtDcload.Rows(K)("dcno"), DtDcload.Rows(K)("dcqty"), DtDcload.Rows(K)("moveqty"))
        Next
        DgDcload.ScrollBars = ScrollBars.Both
        DtDcload = Nothing
        DgDcload.AutoResizeColumns()
        DgDcload.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

#Region "聲音播放"
    Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        Select Case PassOrNg
            Case 0
                My.Computer.Audio.Play(My.Resources.pass, AudioPlayMode.Background)
            Case 1
                My.Computer.Audio.Play(My.Resources.ERR, AudioPlayMode.Background)
            Case 2
                My.Computer.Audio.Play(My.Resources.chimes, AudioPlayMode.Background)
            Case 3
                My.Computer.Audio.Play(My.Resources.chord, AudioPlayMode.Background)
        End Select
    End Sub
#End Region

#Region "掃描單產品"
    Private Sub BtPpidScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPpidScan.Click
        Dim FristY As Boolean = False
        Dim StrNcartonid As String = ""
        Dim DrPpidScan As SqlDataReader = Nothing
        Dim MoBarCode As New PrintJLabel
        Dim PrtArray As New SysMessageClass.PrtStructure
        Dim StrCartonid As String
        Dim StrPpid As String
        Dim StrPartid As String = ""
        Dim StrMoid As String = ""
        Dim StrCustName As String
        Dim StrBppid As New StringBuilder

        StrBppid.Remove(0, Len(StrBppid.ToString))

        If Trim(Me.TxtPpid.Text) = "" Then
            MessageBox.Show("產品序號不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Trim(Me.TxtNeedQty.Text) = "" Then
            MessageBox.Show("應裝數量不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtPpid.Text = ""
            TxtNeedQty.Focus()
            Exit Sub
        End If
        If Lblrealqty.Text = Me.TxtNeedQty.Text Then
            MessageBox.Show("產品數量已達到要求，不得再裝載!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtPpid.Text = ""
            ClearControl()
            Exit Sub
        End If
        Try
            '**********************************
            'rework by tangxiang  2008/12/26
            'reason :  carton 表加樓層別，倉庫別等
            '**********************************
            'DrPpidScan = PubClass.GetDataReader("select a.cartonid,b.cartonstatus,b.moid,c.partid,c.deptid,b.teamid,f.cusname,h.floorid,h.whid,h.areaid from m_CartonSn_t a join m_Carton_t b on a.cartonid=b.cartonid join m_Mainmo_t c on c.moid=b.moid join m_whind_t g on g.cartonid=b.cartonid join m_whinm_t h on g.inwhid=h.inwhid left join m_Customer_t f on c.cusid=f.cusid where a.ppid='" & Trim(Me.TxtPpid.Text) & "'")
            DrPpidScan = PubClass.GetDataReader("select a.cartonid,b.cartonstatus,b.moid,c.partid,c.deptid,b.teamid,f.cusname,b.floorid,b.whid,b.areaid,b.Packlink,i.states from m_CartonSn_t a join m_Carton_t b on a.cartonid=b.cartonid join m_Mainmo_t c on c.moid=b.moid join m_whind_t g on g.cartonid=b.cartonid join m_whinm_t i on i.inwhid=g.inwhid left join m_Customer_t f on c.cusid=f.cusid where a.ppid='" & Trim(Me.TxtPpid.Text) & "'")
            If DrPpidScan.Read Then
                '加入“未入庫的箱”不能拆合--2009/6/24--by tangxiang
                If DrPpidScan("states").ToString = "1" Then
                    MessageBox.Show("該箱還未確認入庫,不能拆和!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtPpid.Clear()
                    DrPpidScan.Close()
                    Exit Sub
                End If
                If DrPpidScan("Partid").ToString <> TxtPartid.Text AndAlso TxtPartid.Text <> "" Then
                    MessageBox.Show("該箱不屬當前料號,不能拆和!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtPpid.Clear()
                    DrPpidScan.Close()
                    Exit Sub
                End If
                If DrPpidScan("cartonstatus").ToString = "N" Then
                    MessageBox.Show("該箱產品還未包裝完成,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPpid.Clear()
                    DrPpidScan.Close()
                    Exit Sub
                ElseIf DrPpidScan("cartonstatus").ToString = "Y" Then
                    MessageBox.Show("該箱產品還未入庫,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPpid.Clear()
                    DrPpidScan.Close()
                    Exit Sub
                ElseIf DrPpidScan("cartonstatus").ToString = "E" Then
                    MessageBox.Show("該箱產品已拆空,不能再使用!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPpid.Clear()
                    DrPpidScan.Close()
                    Exit Sub
                ElseIf DrPpidScan("cartonstatus").ToString = "O" Then
                    MessageBox.Show("該箱產品已出庫,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPpid.Clear()
                    DrPpidScan.Close()
                    Exit Sub
                ElseIf DrPpidScan("cartonstatus").ToString = "R" Then
                    MessageBox.Show("該箱產品已出庫重工,不能拆合!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPpid.Clear()
                    DrPpidScan.Close()
                    Exit Sub
                ElseIf DrPpidScan("cartonstatus").ToString = "Q" Then
                    MessageBox.Show("該箱產品已FQC抽驗判退,不能拆合!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPpid.Clear()
                    DrPpidScan.Close()
                    Exit Sub
                ElseIf DrPpidScan("cartonstatus").ToString = "I" OrElse DrPpidScan("cartonstatus").ToString = "S" Then
                    StrPpid = Trim(Me.TxtPpid.Text)
                    Me.TxtPpid.Clear()
                    StrCartonid = DrPpidScan("cartonid").ToString
                    If Me.TxtPartid.Text = "" Then
                        FristY = True
                        Me.Strfloorid = DrPpidScan("floorid").ToString
                        Me.StrWhid = DrPpidScan("whid").ToString
                        Me.StrAreaid = DrPpidScan("Areaid").ToString
                        StrPacklink = DrPpidScan("Packlink").ToString
                        StrMoid = DrPpidScan("moid").ToString
                        StrPartid = DrPpidScan("partid").ToString
                        StrCustName = DrPpidScan("cusname").ToString
                        Teamid = DrPpidScan("teamid").ToString
                        Deptid = DrPpidScan("deptid").ToString
                        DrPpidScan.Close()

                        PrtArray.AvcPartid = StrPartid
                        PrtArray.CusName = StrCustName
                        PrtArray.Deptid = Deptid
                        PrtArray.Lineid = Teamid
                        PrtArray.Moid = StrMoid
                        PrtArray.NowDate = Datet.ToString("yyyy-MM-dd")
                        PrtArray.NowMonth = Datet.ToString("MM")
                        PrtArray.Qty = Me.TxtNeedQty.Text

                        If MoBarCode.MarkJLabel(PrtArray.ToArray, "Y") Then
                            StrNcartonid = MoBarCode.JLabelStr
                            '***************
                            'rework by tangxiang 2008/12/26
                            '***************
                            'StrBppid.Append("insert into m_Carton_t(Cartonid,Moid,Cartonqty,CartonStatus,Teamid,Userid,Intime) values('" & Trim(StrNcartonid) & "','" & Trim(StrMoid) & "','" & Trim(Me.TxtNeedQty.Text) & "','N','" & Trim(Teamid) & "','" & (SysMessageClass.UseId) & "',getdate())")
                            StrBppid.Append("insert into m_Carton_t(Cartonid,Moid,Cartonqty,CartonStatus,Teamid,Floorid,Whid,Areaid,Packlink,Userid,Intime,updateuser,updatetime) " & _
                                            "values('" & Trim(StrNcartonid) & "','" & Trim(StrMoid) & "','" & Trim(Me.TxtNeedQty.Text) & "','N','" & Trim(Teamid) & "','" & Strfloorid & "'," & _
                                            "'" & StrWhid & "','" & StrAreaid & "','" & StrPacklink & "','" & (SysMessageClass.UseId) & "',getdate(),'" & (SysMessageClass.UseId) & "',getdate())")
                            StrBppid.Append(Environment.NewLine)
                            StrBppid.Append("insert into m_Whclink_t(Ppid,Ncartonid,Cartonid,Moveqty,Userid,Intime) values( '" & Trim(StrPpid) & "','" & Trim(StrNcartonid) & "','" & Trim(StrCartonid) & "',1,'" & SysMessageClass.UseId & "',getdate())")
                            StrBppid.Append(Environment.NewLine)
                            StrBppid.Append("update m_CartonSn_t set cartonid='" & Trim(StrNcartonid) & "' where ppid='" & Trim(StrPpid) & "'")
                            StrBppid.Append(Environment.NewLine)
                            MoBarCode = Nothing
                            Cartonlink = "P"
                        Else
                            MoBarCode = Nothing
                            MessageBox.Show("新箱生成失敗", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Else
                        StrBppid.Append("insert into m_Whclink_t(Ppid,Ncartonid,Cartonid,Moveqty,Userid,Intime) values( '" & Trim(StrPpid) & "','" & Trim(CobNCartonid.Text) & "','" & Trim(StrCartonid) & "',1,'" & SysMessageClass.UseId & "',getdate())")
                        StrBppid.Append(Environment.NewLine)
                        StrBppid.Append("update m_CartonSn_t set cartonid='" & Trim(CobNCartonid.Text) & "' where ppid='" & Trim(StrPpid) & "'")
                        StrBppid.Append(Environment.NewLine)
                    End If
                    DrPpidScan.Close()
                    DrPpidScan = PubClass.GetDataReader("select palletid,cartonid from m_PalletCarton_t where cartonid=(select cartonid from m_CartonSn_t where ppid='" & StrPpid & "')")
                    If DrPpidScan.Read Then
                        StrBDcScan.Append("update m_PalletM_t set palletqty=palletqty-1  where palletid='" & DrPpidScan("palletid").ToString & "'")
                        StrBDcScan.Append(Environment.NewLine)
                        StrBDcScan.Append("update m_PalletCarton_t set usey='N' where cartonid='" & DrPpidScan("cartonid").ToString & "'")
                        StrBDcScan.Append(Environment.NewLine)
                    End If
                    DrPpidScan.Close()
                    '***************
                    'rework by tangxiang 2008/11/24
                    '***************
                    'StrBppid.Append("update m_carton_t set cartonstatus= case cartonqty when 1 then 'E' else 'S' END ,cartonqty=cartonqty-1 where Cartonid='" & Trim(StrCartonid) & "'")
                    StrBppid.Append("update m_carton_t set cartonstatus= case cartonqty when 1 then 'E' else 'S' END ,cartonqty=cartonqty-1,updateuser='" & SysMessageClass.UseId & "',updatetime=getdate() where Cartonid='" & Trim(StrCartonid) & "'")
                    PubClass.ExecSql(StrBppid.ToString)
                    StrBppid.Remove(0, Len(StrBppid.ToString))
                    If FristY = True Then
                        CobNCartonid.Items.Add(StrNcartonid)
                        CobNCartonid.SelectedIndex = CobNCartonid.Items.Count - 1
                        Me.TxtMoid.Text = StrMoid
                        Me.TxtPartid.Text = StrPartid
                        Me.TxtNeedQty.Enabled = False
                        FristY = False
                    End If
                    GetScanItem()
                    PlaySimpleSound(0)
                    LabScanState.Text = "產品條碼　" & StrPpid & "　掃描成功"
                    If Lblrealqty.Text = Me.TxtNeedQty.Text Then
                        MessageBox.Show("產品數量已達到要求!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearControl()
                        Exit Sub
                    End If
                    Me.TxtPpid.Focus()
                End If
            Else
                MessageBox.Show("無法識別此產品所在箱號，或該箱未經入庫掃描!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtPpid.Clear()
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmNewLabel", "BtPpidScan_Click", "sys")
        Finally
            DrPpidScan.Close()

        End Try

    End Sub

    Private Sub TxtPpid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPpid.KeyPress
        If e.KeyChar = Chr(13) Then
            BtPpidScan_Click(sender, e)
            Me.TxtPpid.Clear()
        End If
        e.KeyChar = UCase(e.KeyChar)
    End Sub
#End Region

#Region "獲取單據掃描記錄"
    Private Sub GetScanItem()

        Dim ChColsText As String
        Dim DtCtScan As DataTable
        Try
            DtCtScan = PubClass.GetDataTable("select ppid,ncartonid,cartonid,userid,intime from m_Whclink_t where ncartonid='" & CobNCartonid.Text & "' order by intime desc")
            Me.DGridBarCode.DataSource = DtCtScan
            Lblrealqty.Text = DtCtScan.Rows.Count
            If LCase(SysMessageClass.Language) = "english" Then
                ChColsText = ""
            Else
                ChColsText = "產品條碼序號|新裝箱序號|原裝箱序號|掃描人員|掃描時間"
            End If
            Dim colNames As String() = ChColsText.Split("|")
            Dim i%
            For i = 0 To DGridBarCode.Columns.Count - 1
                DGridBarCode.Columns(i).HeaderText = colNames(i)
                DGridBarCode.Columns(i).Name = colNames(i)
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmNewLabel", "GetScanItem", "sys")
        End Try

    End Sub

    Private Sub GetCartonScanItem()
        Dim DtCtScan As DataTable
        Dim ChColsText As String
        Dim Qty As Integer
        Try
            DtCtScan = PubClass.GetDataTable("select ncartonid,cartonid,moveqty,userid,intime from m_Whclink_t where ncartonid='" & CobNCartonid.Text & "' order by intime desc")
            Me.DGridBarCode.DataSource = DtCtScan
            Me.Lblrealqty.Text = 0
            For Qty = 0 To DGridBarCode.Rows.Count - 1
                Me.Lblrealqty.Text = CInt(Me.Lblrealqty.Text) + CInt(DGridBarCode.Rows(Qty).Cells(2).Value)
            Next
            If LCase(SysMessageClass.Language) = "english" Then
                ChColsText = ""
            Else
                ChColsText = "新裝箱序號|原裝箱序號|拆移數量|掃描人員|掃描時間"
            End If
            Dim colNames As String() = ChColsText.Split("|")
            Dim i%
            For i = 0 To DGridBarCode.Columns.Count - 1
                DGridBarCode.Columns(i).HeaderText = colNames(i)
                DGridBarCode.Columns(i).Name = colNames(i)
            Next

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmNewLabel", "GetScanItem", "sys")
        End Try

    End Sub

    Private Sub GetCartonDcScanItem()
        Dim DtCtScan As DataTable
        Dim ChColsText As String
        Dim Qty As Integer
        Try
            DtCtScan = PubClass.GetDataTable("select ppid,ncartonid,cartonid,moveqty,userid,intime from m_Whclink_t where ncartonid='" & CobNCartonid.Text & "' order by intime desc")
            Me.DGridBarCode.DataSource = DtCtScan
            Me.Lblrealqty.Text = 0
            For Qty = 0 To DGridBarCode.Rows.Count - 1
                Me.Lblrealqty.Text = CInt(Me.Lblrealqty.Text) + CInt(DGridBarCode.Rows(Qty).Cells(3).Value)
            Next
            If LCase(SysMessageClass.Language) = "english" Then
                ChColsText = ""
            Else
                ChColsText = "日期碼|新裝箱序號|原裝箱序號|拆移數量|掃描人員|掃描時間"
            End If
            Dim colNames As String() = ChColsText.Split("|")
            Dim i%
            For i = 0 To DGridBarCode.Columns.Count - 1
                DGridBarCode.Columns(i).HeaderText = colNames(i)
                DGridBarCode.Columns(i).Name = colNames(i)
            Next

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmNewLabel", "GetScanItem", "sys")
        End Try

    End Sub
#End Region

#Region "選擇未確認的新箱"
    Private Sub CobNCartonid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobNCartonid.SelectedIndexChanged

        Dim DrGetitems As SqlDataReader = Nothing
        Dim SqlStr As New StringBuilder
        Dim StrPacklink As String = ""
        If CobNCartonid.Text = "" Then Exit Sub
        Me.CobShift.SelectedIndex = 0
        Try
            SqlStr.Append("select a.moid,b.partid,b.deptid,b.lineid,e.cusname,d.djc,a.cartonqty,f.CustPart,b.Factory,d.djmdc,g.linejm from m_Carton_t a join m_Mainmo_t b " & _
            "on a.moid=b.moid left join m_Dept_t d on b.deptid=d.deptid  left join m_Customer_t e on b.cusid=e.cusid left join m_PartContrast_t f " & _
            " on b.partid=f.TAvcPart left join m_snsbarcode_t p on a.cartonid=p.sbarcode  left join deptline_t g on b.deptid=g.deptid and p.lineid=g.lineid and g.usey='Y' where a.cartonid='" & Trim(CobNCartonid.Text) & "'")
            SqlStr.Append(Environment.NewLine)
            '*****************************
            '直接從m_carton_t 表裡面抓樓層，倉位，儲位，連接方式   2009/3/12  tangxiang
            '*****************************
            'SqlStr.Append("select b.floorid,b.whid,b.areaid from m_WhInD_t a join m_WhInm_t b on a.inwhid=b.inwhid where a.cartonid in(select top 1 cartonid from m_Whclink_t where ncartonid='" & Trim(CobNCartonid.Text) & "')")
            SqlStr.Append("select floorid,whid,areaid,Packlink from m_carton_t where cartonid='" & Trim(CobNCartonid.Text) & "'")
            DrGetitems = PubClass.GetDataReader(SqlStr.ToString)
            SqlStr.Remove(0, SqlStr.ToString.Length)
            If DrGetitems.Read Then
                TxtMoid.Text = DrGetitems("moid").ToString
                TxtFactory.Text = DrGetitems("Factory").ToString
                Me.TxtDeptJM.Text = DrGetitems("djmdc").ToString
                Me.TxtlineJM.Text = DrGetitems("linejm").ToString
                StrCustName = DrGetitems("cusname").ToString
                TxtNeedQty.Text = DrGetitems("cartonqty").ToString
                Me.TxtPartid.Text = DrGetitems("partid").ToString
                Teamid = DrGetitems("lineid").ToString
                Deptid = DrGetitems("deptid").ToString
                DrGetitems.NextResult()
                If DrGetitems.Read Then
                    Me.Strfloorid = DrGetitems("floorid").ToString
                    Me.StrWhid = DrGetitems("whid").ToString
                    Me.StrAreaid = DrGetitems("Areaid").ToString
                    StrPacklink = DrGetitems("Packlink").ToString()
                End If
                DrGetitems.Close()
                TxtNeedQty.Enabled = False
                '*****************************
                '直接從m_carton_t 表裡面抓樓層，倉位，儲位，連接方式   2009/3/12  tangxiang
                '*****************************
                'DrGetitems = PubClass.GetDataReader("select * from m_PartPack_t a join m_Mainmo_t b on a.partid=b.partid join m_Carton_t c on b.moid=c.moid where a.usey='Y' and c.cartonid='" & Trim(Me.CobNCartonid.Text) & "'")
                'DrGetitems.Read()
                'StrPacklink = DrGetitems("Packlink").ToString()
                DrGetitems.Close()
                Select Case StrPacklink
                    Case "P"
                        Cartonlink = "P"
                        GetScanItem()
                    Case "N"
                        Cartonlink = "N"
                        GetCartonScanItem()
                    Case "D"
                        Cartonlink = "D"
                        GetCartonDcScanItem()
                End Select
                TxtCartonid.Focus()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmNewLabel", "CobNCartonid_SelectedIndexChanged", "sys")
        Finally
            DrGetitems.Close()
        End Try

    End Sub

#End Region

#Region "填充ComBox資料"
    Private Sub FillCobType(ByVal CboName As ComboBox, ByVal SqlStr As String)

        Dim CboDr As SqlDataReader
        CboName.Items.Clear()
        CboDr = PubClass.GetDataReader(SqlStr)
        If CboDr.HasRows Then
            While CboDr.Read
                CboName.Items.Add(CboDr.GetString(0))
            End While
        End If
        CboDr.Close()
    End Sub
#End Region


#Region "新箱確認"
    Private Sub TsBnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBnPrint.Click
        If Me.DGridBarCode.Rows.Count < 1 Then Exit Sub
        Dim StrBNew As New StringBuilder
        Dim DrCartonPrinty As SqlDataReader
        Dim MoBarCode As New PrintJLabelNew
        Dim MobarcodeOld As New PrintJLabel
        Dim PrtArray As New SysMessageClass.PrtStructure
        PrtArray.AvcPartid = Me.TxtPartid.Text
        PrtArray.CusName = StrCustName
        PrtArray.Deptid = Deptid
        PrtArray.Lineid = Teamid
        PrtArray.Moid = TxtMoid.Text
        PrtArray.NowDate = Datet.ToString("yyyy-MM-dd")
        PrtArray.NowMonth = Datet.ToString("MM")
        PrtArray.Qty = Me.TxtNeedQty.Text


        '''''''''''''''''''''''''''''

        Dim Year As String = Mid(DatePart(DateInterval.Year, CDate(PrtArray.NowDate)), 3)
        Dim Week As String = Microsoft.VisualBasic.Right(StrDup(2, "0") & (DatePart(DateInterval.WeekOfYear, CDate(PrtArray.NowDate).AddDays(-1)) - 1), 2)
        Dim DayWeek As String = DatePart(DateInterval.Weekday, CDate(PrtArray.NowDate).AddDays(-1))

        Dim DeptJm As String = Me.TxtDeptJM.Text
        Dim Factory As String
        If UCase(TxtFactory.Text) = "SZ" Then
            Factory = "C"
        Else
            Factory = "N"
        End If
        Dim mShift As String

        If CobShift.Text = "白班" Then
            mShift = "D"
        Else
            mShift = "N"
        End If

        
        Dim lineJm As String = Me.TxtlineJM.Text

        Dim dc1 As String = DeptJm & lineJm & Year & Week _
                       & DayWeek & mShift & Factory
        PrtArray.WorkType = mShift
        PrtArray.DateCode = dc1

        '''''''''''''''''''''''''''''''

        If CInt(Lblrealqty.Text) <> CInt(Me.TxtNeedQty.Text) Then
            MessageBox.Show("產品數量不符合裝箱要求,不得打印新箱!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        MessageBox.Show("請確保打印機已下載了字體！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If MessageBox.Show("你確定打印新箱嗎？", "信息提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Try
                '**************************************ouxiangfeng 2011/12/14*********************
                'DrCartonPrinty = PubClass.GetDataReader("select cartonstatus from m_carton_t where Cartonid='" & Trim(Me.CobNCartonid.Text) & "'")
                Dim sqlStr As String = " select a.coderuleid,c.cartonstatus from m_partpack_t a join  m_mainmo_t b " & _
                "on a.partid=b.partid and a.packid='C' and a.usey='Y' join m_carton_t c on b.moid=c.moid and c.cartonid='" & CobNCartonid.Text & "'"
                DrCartonPrinty = PubClass.GetDataReader(sqlStr)
                '**************************************ouxiangfeng 2011/12/14*********************
                If DrCartonPrinty.Read() Then
                    If DrCartonPrinty("cartonstatus").ToString = "N" Then
                        Dim CodeRuld As String = DrCartonPrinty("coderuleid").ToString
                        DrCartonPrinty.Close()
                        WNid = GetInWhId()
                        '***************
                        'rework by tangxiang 2008/11/24
                        '***************
                        'StrBNew.Append("update m_carton_t set cartonstatus='I'where Cartonid='" & Trim(Me.CobNCartonid.Text) & "'")
                        StrBNew.Append("update m_carton_t set cartonstatus='I',updateuser='" & SysMessageClass.UseId & "',updatetime=getdate() where Cartonid='" & Trim(Me.CobNCartonid.Text) & "'")
                        StrBNew.Append(Environment.NewLine)
                        StrBNew.Append("insert m_WhInm_t(Inwhid,Moid,Inqty,Floorid,Whid,Areaid,States,Remark,Userid,Intime) values('" & WNid & "','" & Trim(TxtMoid.Text) & "','" & Trim(TxtNeedQty.Text) & "','" & Me.Strfloorid & "','" & Me.StrWhid & "','" & Me.StrAreaid & "',2,'倉庫留存之拆合新箱','" & (SysMessageClass.UseId) & "',GETDATE())")
                        StrBNew.Append(Environment.NewLine)
                        '***************
                        'rework by tangxiang 2008/11/24 \\主表和次表數量相等
                        '***************
                        'StrBNew.Append("insert m_WhInD_t(Inwhid,Cartonid,Userid,Intime) values('" & WNid & "','" & Trim(CobNCartonid.Text) & "','" & (SysMessageClass.UseId) & "',GETDATE())")
                        StrBNew.Append("insert m_WhInD_t(Inwhid,Cartonid,Userid,Intime,CartonInQty) values('" & WNid & "','" & Trim(CobNCartonid.Text) & "','" & (SysMessageClass.UseId) & "',GETDATE(),'" & Trim(TxtNeedQty.Text) & "')")
                        StrBNew.Append(Environment.NewLine)
                        StrBNew.Append("update m_SnSBarCode_t set UseY='S' where Sbarcode='" & Trim(Me.CobNCartonid.Text) & "'")
                        PubClass.ExecSql(StrBNew.ToString)
                        If CodeRuld = "C001" Or CodeRuld = "C002" Then ''固定，靈活設置需要將舊版外箱移至新版打印。
                            MobarcodeOld.PrintCarton(PrtArray.ToArray, Trim(Me.CobNCartonid.Text), "Y")  ''舊版外條打印程式
                        Else
                            MoBarCode.PrintCarton(PrtArray.ToArray, Trim(Me.CobNCartonid.Text), "Y")  ''新箱打印
                        End If
                        CobNCartonid.Items.Remove(CobNCartonid.Text)
                        CobNCartonid.SelectedIndex = -1
                        TxtMoid.Text = ""
                        TxtPartid.Text = ""
                        TxtNeedQty.Text = ""
                        LabScanState.Text = ""
                        Lblrealqty.Text = "0"
                        Me.DGridBarCode.DataSource = Nothing
                        Me.TxtNeedQty.Enabled = True
                    Else
                        DrCartonPrinty.Close()
                        MessageBox.Show("該外箱序號已在其他電腦上打印，打印失敗！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    End If
            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmNewLabel", "BnNewEnter_Click", "sys")
            Finally
                MoBarCode = Nothing
                WNid = Nothing
                Strfloorid = Nothing
                StrWhid = Nothing
                StrAreaid = Nothing
            End Try
        End If

    End Sub

#End Region

#Region "新箱作廢"
    Private Sub TsBtDrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtDrop.Click

        Dim StrBDrop As New StringBuilder
        If Me.DGridBarCode.Rows.Count < 1 Then Exit Sub
        If MessageBox.Show("你確定作廢建立新箱嗎？", "信息提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Try
                Select Case Cartonlink
                    Case "P"
                        '***************
                        'rework by tangxiang 2008/11/24
                        '***************
                        'StrBDrop.Append("update m_Carton_t set cartonqty =cartonqty+QtyOne,cartonstatus=case QtyOne when QtyAll then 'I' else 'S' END from ( select a.cartonid,a.qtyone,b.qtyall from (select cartonid,count(ppid) QtyOne from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "' group by cartonid ) a join (select cartonid,count(ppid) QtyAll from m_Whclink_t group by cartonid ) b on a.cartonid=b.cartonid ) Ta where m_Carton_t.cartonid=Ta.cartonid ")
                        StrBDrop.Append("update m_Carton_t set updateuser='" & SysMessageClass.UseId & "',updatetime=getdate(), cartonqty =cartonqty+QtyOne,cartonstatus=case QtyOne when QtyAll then 'I' else 'S' END from ( select a.cartonid,a.qtyone,b.qtyall from (select cartonid,count(ppid) QtyOne from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "' group by cartonid ) a join (select cartonid,count(ppid) QtyAll from m_Whclink_t group by cartonid ) b on a.cartonid=b.cartonid ) Ta where m_Carton_t.cartonid=Ta.cartonid ")
                        StrBDrop.Append(Environment.NewLine)
                        StrBDrop.Append("update b set cartonid=a.cartonid from m_Whclink_t a join m_Cartonsn_t b on a.ncartonid=b.cartonid and a.ppid=b.ppid where a.ncartonid='" & Trim(Me.CobNCartonid.Text) & "' ")
                        StrBDrop.Append(Environment.NewLine)
                    Case "N"
                        '***************
                        'rework by tangxiang 2008/11/24
                        '***************
                        'StrBDrop.Append("update m_Carton_t set Cartonqty = cartonqty + ta.moveqty,cartonstatus= case Tb.CartonCount when 1 then 'I' else 'S' END from (select * from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "') Ta ,(select cartonid,count(cartonid) CartonCount from m_Whclink_t where cartonid in(select cartonid from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "') group by cartonid) Tb where m_Carton_t.cartonid=Ta.cartonid and m_Carton_t.cartonid=Tb.cartonid ")
                        StrBDrop.Append("update m_Carton_t set updateuser='" & SysMessageClass.UseId & "',updatetime=getdate(), Cartonqty = cartonqty + ta.moveqty,cartonstatus= case Tb.CartonCount when 1 then 'I' else 'S' END from (select * from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "') Ta ,(select cartonid,count(cartonid) CartonCount from m_Whclink_t where cartonid in(select cartonid from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "') group by cartonid) Tb where m_Carton_t.cartonid=Ta.cartonid and m_Carton_t.cartonid=Tb.cartonid ")
                        StrBDrop.Append(Environment.NewLine)
                    Case "D"
                        StrBDrop.Append("update m_CartonLot_t set dcqty=dcqty+moveqty from m_Whclink_t a where m_CartonLot_t.cartonid=a.cartonid and m_CartonLot_t.dcno=a.ppid and a.ncartonid='" & Trim(Me.CobNCartonid.Text) & "'")
                        StrBDrop.Append(Environment.NewLine)
                        '***************
                        'rework by tangxiang 2008/11/24
                        '***************
                        'StrBDrop.Append("update m_Carton_t set Cartonqty = cartonqty + ta.moveqty,cartonstatus= case tb.Qtyone when tb.Qtyall then 'I' else 'S' END from (select cartonid,sum(moveqty) moveqty from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "' group by cartonid) Ta ,(select a.cartonid,a.CartonCount Qtyone,b.cartoncount Qtyall from (select cartonid,count(*) CartonCount from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "' group by cartonid) a join (select cartonid,count(*) CartonCount from m_Whclink_t where cartonid in(select cartonid from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "') group by cartonid) b on a.cartonid=b.cartonid) tb where m_Carton_t.cartonid=Ta.cartonid and m_Carton_t.cartonid=Tb.cartonid")
                        StrBDrop.Append("update m_Carton_t set updateuser='" & SysMessageClass.UseId & "',updatetime=getdate(), Cartonqty = cartonqty + ta.moveqty,cartonstatus= case tb.Qtyone when tb.Qtyall then 'I' else 'S' END from (select cartonid,sum(moveqty) moveqty from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "' group by cartonid) Ta ,(select a.cartonid,a.CartonCount Qtyone,b.cartoncount Qtyall from (select cartonid,count(*) CartonCount from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "' group by cartonid) a join (select cartonid,count(*) CartonCount from m_Whclink_t where cartonid in(select cartonid from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "') group by cartonid) b on a.cartonid=b.cartonid) tb where m_Carton_t.cartonid=Ta.cartonid and m_Carton_t.cartonid=Tb.cartonid")
                        StrBDrop.Append(Environment.NewLine)
                        StrBDrop.Append("delete m_CartonLot_t where cartonid='" & Trim(Me.CobNCartonid.Text) & "'")
                        StrBDrop.Append(Environment.NewLine)
                End Select

                StrBDrop.Append("update m_PalletCarton_t set usey='Y' where cartonid in(select distinct cartonid from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "')")
                StrBDrop.Append(Environment.NewLine)
                StrBDrop.Append("update m_PalletM_t set palletqty=a.qty from (select palletid,count(cartonid) qty from m_PalletCarton_t where cartonid in(select distinct cartonid from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "') and usey='Y' Group by palletid )a where m_PalletM_t.palletid=a.palletid")
                StrBDrop.Append(Environment.NewLine)
                StrBDrop.Append("delete from m_Carton_t where cartonid='" & Trim(Me.CobNCartonid.Text) & "'")
                StrBDrop.Append(Environment.NewLine)
                StrBDrop.Append("delete from m_SnSBarCode_t where SBarCode='" & Trim(Me.CobNCartonid.Text) & "'")
                StrBDrop.Append(Environment.NewLine)
                StrBDrop.Append("delete from m_WhInM_t where inwhid =(select inwhid from m_WhInD_t where cartonid='" & Trim(Me.CobNCartonid.Text) & "')")
                StrBDrop.Append(Environment.NewLine)
                StrBDrop.Append("delete from m_Whclink_t where ncartonid='" & Trim(Me.CobNCartonid.Text) & "'")
                PubClass.ExecSql(StrBDrop.ToString)
                CobNCartonid.Items.Remove(CobNCartonid.Text)
                CobNCartonid.SelectedIndex = -1
                TxtMoid.Text = ""
                TxtPartid.Text = ""
                TxtNeedQty.Text = ""
                LabScanState.Text = ""
                Lblrealqty.Text = "0"
                Me.DGridBarCode.DataSource = Nothing
                Me.TxtNeedQty.Enabled = True
            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmNewLabel", "BtDrop_Click", "sys")
            End Try

        End If
    End Sub
#End Region

    Private Sub TxtNeedQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNeedQty.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = Chr(13) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    ''測試打印
    Private Sub TsBtTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtTest.Click
        Try
            If CobNCartonid.Text = "" Then
                MsgBox("請先進行掃描以生成新箱！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Exit Sub
            End If
            If CInt(Lblrealqty.Text) <> CInt(Me.TxtNeedQty.Text) Then
                MessageBox.Show("產品數量不符合裝箱要求，不得測試打印新箱!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim MoBarCode As New PrintJLabelNew
           
            Dim PrtArray As New SysMessageClass.PrtStructure
            PrtArray.AvcPartid = Me.TxtPartid.Text
            PrtArray.CusName = StrCustName
            PrtArray.Deptid = Deptid
            PrtArray.Lineid = Teamid
            PrtArray.Moid = TxtMoid.Text
            PrtArray.NowDate = Datet.ToString("yyyy-MM-dd")
            PrtArray.NowMonth = Datet.ToString("MM")
            PrtArray.Qty = Me.TxtNeedQty.Text
            If MoBarCode.MarkJLabel(PrtArray.ToArray, "N") Then
                MoBarCode.PrintCarton(PrtArray.ToArray, MoBarCode.JLabelStr, "N")
            End If
            MoBarCode = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub TsBnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBnBack.Click
        Deptid = ""
        Teamid = ""
        PubClass = Nothing
        Me.Close()
    End Sub

    ''一箱有裝多种D/C的拆合箱維護
    Private Sub BtGetDc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGetDc.Click
        Dim i As Integer
        Dim SumQty As Integer
        Dim DrScan As SqlDataReader
        For i = 0 To DgDcload.Rows.Count - 1
            If DgDcload.Rows(i).Cells(0).Value = True Then
                If DgDcload.Rows(i).Cells(4).Value <> "" Then
                    SumQty = SumQty + CInt(DgDcload.Rows(i).Cells(4).Value)
                    'SbDcSave.Append("insert into m_CartonLot_t(Dcno,cartonid,DCqty,userid,intime) values('" & DgDcload.Rows(i).Cells(2).Value & "','" & CobNCartonid.Text & "','" & DgDcload.Rows(i).Cells(4).Value & "','" & (SysMessageClass.UseId) & "',getdate() )")
                    'SbDcSave.Append(Environment.NewLine)
                    StrBDcScan.Append("update m_CartonLot_t set dcqty='" & CInt(DgDcload.Rows(i).Cells(3).Value) - CInt(DgDcload.Rows(i).Cells(4).Value) & "' where dcno='" & DgDcload.Rows(i).Cells(2).Value & "' and cartonid='" & DgDcload.Rows(i).Cells(1).Value & "'")
                    StrBDcScan.Append(Environment.NewLine)
                    StrBDcScan.Append("insert into m_Whclink_t(Ppid,Ncartonid,Cartonid,MoveQty,Userid,Intime) values( '" & DgDcload.Rows(i).Cells(2).Value & "','" & Trim(CobNCartonid.Text) & "','" & Trim(TxtCartonid.Text) & "','" & DgDcload.Rows(i).Cells(4).Value & "','" & (SysMessageClass.UseId) & "',getdate() )")
                    StrBDcScan.Append(Environment.NewLine)
                End If
            End If
        Next
        If SumQty <> CInt(Me.TxtNeedQty.Text) - CInt(Lblrealqty.Text) Then
            MessageBox.Show("轉移總數量不符合新箱剩餘所需數量", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            StrBDcScan.Remove(0, Len(StrBDcScan.ToString))
            '***************
            'rework by tangxiang 2008/11/24
            '***************
            'StrBDcScan.Append("insert into m_Carton_t(Cartonid,Moid,Cartonqty,CartonStatus,Teamid,Userid,Intime) values('" & Trim(CobNCartonid.Text) & "','" & Trim(TxtMoid.Text) & "','" & Trim(Me.TxtNeedQty.Text) & "','N','" & Trim(Teamid) & "','" & (SysMessageClass.UseId) & "',getdate())")
            StrBDcScan.Append("insert into m_Carton_t(Cartonid,Moid,Cartonqty,CartonStatus,Teamid,Floorid,Whid,Areaid,Packlink," & _
                              "Userid,Intime,updateuser,updatetime) values('" & Trim(CobNCartonid.Text) & "','" & Trim(TxtMoid.Text) & "'," & _
                              "'" & Trim(Me.TxtNeedQty.Text) & "','N','" & Trim(Teamid) & "','" & Strfloorid & "','" & StrWhid & "','" & StrAreaid & "'," & _
                              "'" & StrPacklink & "','" & (SysMessageClass.UseId) & "',getdate(),'" & (SysMessageClass.UseId) & "',getdate())")
            StrBDcScan.Append(Environment.NewLine)
            Exit Sub
        Else
            ''判斷入庫時是否有做棧板包裝掃描
            DrScan = PubClass.GetDataReader("select palletid from m_PalletCarton_t where cartonid='" & Trim(TxtCartonid.Text) & "'")
            If DrScan.Read Then
                StrBDcScan.Append("update m_PalletM_t set palletqty=palletqty-1  where palletid='" & DrScan("palletid").ToString & "'")
                StrBDcScan.Append(Environment.NewLine)
                StrBDcScan.Append("update m_PalletCarton_t set usey='N' where cartonid='" & Trim(TxtCartonid.Text) & "'")
                StrBDcScan.Append(Environment.NewLine)
            End If
            DrScan.Close()

            StrBDcScan.Append("delete from m_CartonLot_t where cartonid='" & Trim(CobNCartonid.Text) & "'")
            StrBDcScan.Append(Environment.NewLine)
            StrBDcScan.Append("insert into m_CartonLot_t(Dcno,cartonid,dcqty,userid,intime) select ppid,'" & Trim(CobNCartonid.Text) & "',sum(moveqty),'" & (SysMessageClass.UseId) & "',getdate() from m_Whclink_t where ncartonid='" & Trim(CobNCartonid.Text) & "' group by ppid")
            StrBDcScan.Append(Environment.NewLine)
            '***************
            'rework by tangxiang 2008/11/24 
            '***************
            'StrBDcScan.Append("update m_Carton_t set CartonStatus='S',cartonqty='" & CartonStillQty & "' where Cartonid='" & Trim(TxtCartonid.Text) & "'")
            StrBDcScan.Append("update m_Carton_t set updateuser='" & SysMessageClass.UseId & "',updatetime=getdate(),CartonStatus='S',cartonqty='" & CartonStillQty & "' where Cartonid='" & Trim(TxtCartonid.Text) & "'")
            PubClass.ExecSql(StrBDcScan.ToString)
            StrBDcScan.Remove(0, Len(StrBDcScan.ToString))
            GetCartonDcScanItem()
            LabScanState.Text = "箱號條碼　" & TxtCartonid.Text & "　掃描成功"
            Lblrealqty.Text = CInt(Me.TxtNeedQty.Text)
            TxtCartonid.Text = ""
            Me.SplitContainer1.Panel2Collapsed = True
            Me.TxtCartonid.Enabled = True
            Me.BtCartonScan.Enabled = True
            Me.TxtCartonid.Focus()
            PlaySimpleSound(0)
            If Lblrealqty.Text = Me.TxtNeedQty.Text Then
                MessageBox.Show("數量已達到要求!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearControl()
                Exit Sub
            End If

        End If
    End Sub

    Private Sub Btback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btback.Click
        Me.SplitContainer1.Panel2Collapsed = True
        Me.TxtCartonid.Text = ""
        Me.TxtCartonid.Enabled = True
        Me.BtCartonScan.Enabled = True
        Me.TxtCartonid.Focus()
    End Sub

    Private Sub DgDcload_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDcload.CellEndEdit
        If e.ColumnIndex <> 4 Then Exit Sub
        If DgDcload.CurrentCell.Value = "" Then Exit Sub
        If CInt(DgDcload.CurrentCell.Value) > CInt(DgDcload.Rows(e.RowIndex).Cells(3).Value) Then
            DgDcload.CurrentCell.Value = ""
            MessageBox.Show("轉移數量不得大於箱內數量", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim ctrTextBox As TextBox
        ctrTextBox = CType(sender, TextBox)
        If ctrTextBox.Text = "" AndAlso e.KeyChar = ChrW(Keys.D0) Then
            e.Handled = True
            Exit Sub
        End If
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back)) Then    ''Datagrid某列只能輸入數字
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub DgDcload_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgDcload.EditingControlShowing

        Dim ctrTextBox As TextBox
        ctrTextBox = CType(e.Control, TextBox)
        AddHandler ctrTextBox.KeyPress, _
        New KeyPressEventHandler(AddressOf TextBox_KeyPress)
    End Sub

    '修改打印時間
    Private Sub DtpMakeDay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpMakeDay.ValueChanged
        Dim RecTable As New DataTable
        Dim Sqlstr As String

        Sqlstr = "select '" & DtpMakeDay.Value.ToString & "' as Datet"
        RecTable = PubClass.GetDataTable(Sqlstr)
        Datet = CType((RecTable.Rows(0).Item("Datet").ToString), DateTime)
        RecTable.Dispose()
    End Sub

    Sub ClearControl()

        TxtMoid.Text = ""
        TxtPartid.Text = ""
        TxtNeedQty.Text = ""
        TxtNeedQty.Enabled = True
        LabScanState.Text = ""
        Lblrealqty.Text = "0"
        DGridBarCode.DataSource = Nothing
        DgDcload.DataSource = Nothing

        Me.SplitContainer1.Panel2Collapsed = True
        FillCobType(CobNCartonid, "select distinct a.cartonid from m_Carton_t a join m_Whclink_t b on a.cartonid=b.ncartonid join m_Mainmo_t c on a.moid=c.moid where a.cartonstatus='N' and c.factory in(select buttonid from m_UserRight_t a join m_Logtree_t b on a.tkey=b.tkey where b.tparent='F0_' and a.userid='" & SysMessageClass.UseId & "')")
        CobNCartonid.SelectedIndex = -1
        Me.TxtNeedQty.Focus()

    End Sub

End Class