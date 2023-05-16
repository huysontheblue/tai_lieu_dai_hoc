Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Text
Imports System.Data.SqlClient

Public Class FrmReworkOut_DG
    Dim PubClass As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim StrRequest As String

    Private Sub FrmReworkOut_DG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCobType(CobRwBill, "select outwhid from m_WhoutM_t where  States='1' and outtype='R'")
        FillCobType(CobRwMoid, "select distinct(moid) from m_Requestm_t where usey='Y' and retype = 2 ")
    End Sub

    Private Sub FrmReworkOut_DG_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.A AndAlso e.Alt Then
            TsBnOutBill_Click(sender, e)
        ElseIf e.KeyCode = Keys.S AndAlso e.Alt Then
            TsBtEnter_Click(sender, e)
        ElseIf e.KeyCode = Keys.D AndAlso e.Alt Then
            TsBtDrop_Click(sender, e)
        ElseIf e.KeyCode = Keys.E AndAlso e.Alt Then
            TsBnBack_Click(sender, e)
        End If
    End Sub


#Region "新建單據編號"
    Private Function GetOutWhId() As String ''新建單據編號

        Dim DataGridTable As DataTable
        DataGridTable = PubClass.GetDataTable("select max(Outwhid) from m_WhOutM_t where substring(Outwhid,3,6)=convert(varchar(6),getdate(),12)")
        If DataGridTable.Rows(0).Item(0) Is DBNull.Value Then
            Return "WO" & Format(Now, "yyMMdd") & "0001"
        Else
            Return "WO" & Mid((1 & Mid(DataGridTable.Rows(0).Item(0), 3)) + 1, 2)
        End If

    End Function
#End Region

#Region "填充下拉菜單資料"
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
    Private Sub FillCob(ByVal CboName As ComboBox, ByVal SqlStr As String)

        Dim CboDr As SqlDataReader
        CboName.Items.Clear()
        CboDr = PubClass.GetDataReader(SqlStr)
        If CboDr.HasRows Then
            While CboDr.Read
                CboName.Items.Add(CboDr.GetString(0) & "(" & CboDr.GetString(1) & ")")
            End While
        End If
        CboDr.Close()

    End Sub
#End Region

    Private Sub CobRwBill_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobRwBill.SelectedIndexChanged

        Dim DrGetInf As SqlDataReader = Nothing
        Dim DtSumQty As DataTable
        Dim StrRwMoid As String
        Dim StrPartid As String
        Dim StrRwDept As String
        Dim StrRwQty As String
        Dim StrOuttime As String
        Dim StrObject As String
        'Dim StrWay As String
        Dim StrDescript As String

        Try
            DrGetInf = PubClass.GetDataReader("select b.partid,a.rwmoid,a.shipqty,c.djc,d.requester,d.changey,a.remark,a.intime from m_WhoutM_t a left join m_Mainmo_t b on a.rwmoid=b.moid left join m_dept_t c on b.deptid=c.deptid left join m_RequestM_t d on a.rwmoid=d.moid where outwhid = '" & Trim(CobRwBill.Text) & "'")
            If DrGetInf.HasRows Then
                DrGetInf.Read()
                StrRwMoid = DrGetInf("rwmoid").ToString
                StrPartid = DrGetInf("Partid").ToString
                StrRwDept = DrGetInf("djc").ToString
                StrRwQty = DrGetInf("shipqty").ToString
                StrOuttime = Format(DrGetInf.GetDateTime(7), "yy/MM/dd HH:mm:ss")
                StrObject = DrGetInf("requester").ToString
                'StrWay = IIf(DrGetInf("changey").ToString = "Y", "更換條碼序號", "不更換條碼序號")
                StrDescript = DrGetInf("remark").ToString
                DrGetInf.Close()
                CobRwMoid.Text = StrRwMoid
                TxtPartid.Text = StrPartid
                TxtRwDept.Text = StrRwDept
                TxtRwQty.Text = StrRwQty
                TxtOuttime.Text = StrOuttime
                TxtObject.Text = StrObject
                TxtDescript.Text = StrDescript
            End If
            DrGetInf.Close()
            DtSumQty = PubClass.GetDataTable("select sum(Cartonqty) from m_Carton_t where Cartonid in (select Cartonid from m_WhoutD_t where outwhid='" & CobRwBill.Text & "') ")
            If DtSumQty.Rows(0).Item(0) Is DBNull.Value Then
                Me.LabSumQty.Text = 0
            Else
                Me.LabSumQty.Text = DtSumQty.Rows(0).Item(0)
            End If
            DtSumQty = Nothing
            GetScanItem()
        Catch ex As Exception
            DrGetInf.Close()
            'MessageBox.Show(ex.Message, "提示信息!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmReworkOut", "CobRwBill_SelectedIndexChanged", "sys")
        End Try
    End Sub

#Region "獲取單據掃描記錄"
    Private Sub GetScanItem()

        Dim ChColsText As String
        Dim DtCtScan As DataTable
        Try
            DtCtScan = PubClass.GetDataTable("select a.outwhid,a.Cartonid,b.cartonqty,a.Userid,convert(varchar(20),a.Intime,20) from m_WhoutD_t a left join m_Carton_t b on a.cartonid=b.cartonid where a.Outwhid='" & CobRwBill.Text & "'")
            Me.DGridBarCode.DataSource = DtCtScan
            Me.LabCQty.Text = DtCtScan.Rows.Count
            If LCase(SysMessageClass.Language) = "english" Then
                ChColsText = ""
            Else
                ChColsText = "單據編號|裝箱序號|包裝數量|掃描人員|掃描時間"
            End If
            Dim colNames As String() = ChColsText.Split("|")
            Dim i%
            For i = 0 To DGridBarCode.Columns.Count - 1
                DGridBarCode.Columns(i).HeaderText = colNames(i)
                DGridBarCode.Columns(i).Name = colNames(i)
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmReworkOut", "GetScanItem", "sys")
        End Try


    End Sub
#End Region

    Private Sub BtCScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCScan.Click

        Dim StrScan As New StringBuilder
        Dim DrPubUse As SqlDataReader = Nothing
        Dim StrStatus As String
        Dim StrQty As String
        'Dim StrType As String '重工方式

        ''加入輸入時間控制--2秒
        'If DateDiff(DateInterval.Second, G_time, Now) >= 2 Then
        '    TxtCartonId.Text = ""
        '    Exit Sub
        'End If

        StrScan.Remove(0, StrScan.ToString.Length)
        If CobRwBill.Text = "" Then
            MessageBox.Show("請先建立出庫單!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If CobRwMoid.Text = "" Then
            MessageBox.Show("請先輸入重工工單!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Trim(TxtCartonId.Text) = "" Then
            MessageBox.Show("裝箱序號不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try

            DrPubUse = PubClass.GetDataReader("select cartonqty,cartonstatus from M_Carton_t where cartonid='" & Trim(TxtCartonId.Text) & "' and moid in(select a.resourcemo from m_Requestd_t a join m_Requestm_t b on a.requestid=b.requestid where b.requestid='" & StrRequest & "')")
            If DrPubUse.HasRows Then
                DrPubUse.Read()
                StrStatus = DrPubUse("cartonstatus").ToString
                StrQty = DrPubUse("cartonqty").ToString
                DrPubUse.Close()

                If CInt(StrQty) + CInt(LabSumQty.Text) > CInt(TxtRwQty.Text) Then
                    MessageBox.Show("請注意！產品掃描數量大於重工數量!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonId.Text = ""
                    Exit Sub
                End If
                If StrStatus = "E" Then
                    MessageBox.Show("該箱為空箱，不能出庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonId.Text = ""
                    Exit Sub
                ElseIf StrStatus = "S" Then
                    MessageBox.Show("該箱已被拆合，不能出庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonId.Text = ""
                    Exit Sub
                ElseIf StrStatus = "N" Then
                    MessageBox.Show("該箱處於產線包裝狀態，不能出庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonId.Text = ""
                    Exit Sub
                ElseIf StrStatus = "O" Then
                    MessageBox.Show("該箱已正常出庫，不能再出庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonId.Text = ""
                    Exit Sub
                ElseIf StrStatus = "Y" Then
                    MessageBox.Show("該箱未入庫，不能直接出庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonId.Text = ""
                    Exit Sub
                ElseIf StrStatus = "R" Then
                    MessageBox.Show("該箱已出庫重工，不能再出庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonId.Text = ""
                    Exit Sub
                ElseIf StrStatus = "Q" Then
                    MessageBox.Show("該箱已FQC抽驗判退,不能出庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonId.Clear()
                    Exit Sub
                ElseIf StrStatus = "I" Then
                    Me.LabSumQty.Text = CInt(Me.LabSumQty.Text) + CInt(StrQty)
                    If Me.LabCQty.Text = 0 Then
                        StrScan.Append("update m_WhoutM_t set partid='" & Trim(Me.TxtPartid.Text) & "',rwmoid='" & Trim(Me.CobRwMoid.Text) & "' where outwhid='" & Trim(Me.CobRwBill.Text) & "'")
                        StrScan.Append(Environment.NewLine)
                    End If
                End If
            Else
                MessageBox.Show("該箱產品不屬於當前重工工單,或無法識別此箱號!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCartonId.Text = ""
                DrPubUse.Close()
                Exit Sub
            End If
            '**********************************************************
            'rework Time:      2008/12/01 
            'rework by:        tangxiang
            'Reason :          m_WhOutD_t表增加“出庫數量”
            '**********************************************************
            'StrScan.Append("insert m_WhOutD_t(Outwhid,Cartonid,Userid,Intime) values('" & Trim(CobRwBill.Text) & "','" & Trim(TxtCartonId.Text) & "','" & (SysMessageClass.UseId) & "',getdate())")
            StrScan.Append("insert m_WhOutD_t(Outwhid,Cartonid,Userid,Intime,CartonOutQty) values('" & Trim(CobRwBill.Text) & "','" & Trim(TxtCartonId.Text) & "','" & (SysMessageClass.UseId) & "',getdate(),'" & StrQty & "')")
            StrScan.Append(Environment.NewLine)
            '**********************************************************
            'rework Time:      2008/12/01 
            'rework by:        tangxiang
            'Reason :          M_Carton_t表增加“更新人員、時間”
            '**********************************************************
            'StrScan.Append("update M_Carton_t set CartonStatus='R',intime=getdate(),userid='" & (SysMessageClass.UseId) & "' where Cartonid='" & Trim(TxtCartonId.Text) & "'")
            StrScan.Append("update M_Carton_t set CartonStatus='R',updatetime=getdate(),updateuser='" & (SysMessageClass.UseId) & "' where Cartonid='" & Trim(TxtCartonId.Text) & "'")
            StrScan.Append(Environment.NewLine)

            ''*********************換主條碼與不換主條碼的不同處理*******************************************2009/09/06********
            'DrPubUse = PubClass.GetDataReader("select changey from m_RequestM_t where usey='Y' and moid='" & Trim(CobRwMoid.Text) & "'")
            'If DrPubUse.HasRows Then
            '    DrPubUse.Read()
            '    StrType = DrPubUse(0).ToString

            '    If StrType = "1" Then '換主條碼
            '        StrScan.Append("update m_SnSBarCode_t set usey='N' where sbarcode='" & Trim(TxtCartonId.Text) & "'")
            '        StrScan.Append(Environment.NewLine)
            '        StrScan.Append("update m_SnSBarCode_t set usey='N' where sbarcode in(select ppid from m_cartonsn_t where cartonid='" & Trim(TxtCartonId.Text) & "')")
            '        StrScan.Append(Environment.NewLine)
            '        StrScan.Append("update m_Assysn_t set Estateid='R'  where ppid in(select ppid from m_cartonsn_t where cartonid='" & Trim(TxtCartonId.Text) & "')")
            '        StrScan.Append(Environment.NewLine)
            '        StrScan.Append("update m_AssysnD_t set Estateid='R' where ppid in(select ppid from m_cartonsn_t where cartonid='" & Trim(TxtCartonId.Text) & "')")
            '        StrScan.Append(Environment.NewLine)
            '        StrScan.Append("update m_Ppidlink_t set usey='N' where exppid in(select ppid from m_cartonsn_t where cartonid='" & Trim(TxtCartonId.Text) & "')")
            '        StrScan.Append(Environment.NewLine)
            '    ElseIf StrType = "0" Then '不換主條碼
            '        StrScan.Append("update m_SnSBarCode_t set usey='N' where sbarcode='" & Trim(TxtCartonId.Text) & "'")
            '        StrScan.Append(Environment.NewLine)
            '        StrScan.Append("delete a from m_AssysnD_t a ,m_Assysn_t b where a.ppid=b.ppid and a.stationid=b.stationid " & _
            '                       "and b.ppid in(select ppid from m_cartonsn_t where cartonid='" & Trim(TxtCartonId.Text) & "')")
            '        StrScan.Append(Environment.NewLine)
            '        StrScan.Append("update m_assysn_t set stationid=(select top 1 stationid from m_RPartStationD_t where " & _
            '                       "state =1 and ppartid='" & Trim(TxtPartid.Text) & "' and staorderid = " & _
            '                       "(select case  max(staorderid) when 1 then 0 else max(staorderid)-1 end " & _
            '                       "from m_RPartStationD_t where  state =1 and ppartid='" & Trim(TxtPartid.Text) & "')) " & _
            '                       "where ppid in(select ppid from m_cartonsn_t where cartonid='" & Trim(TxtCartonId.Text) & "')")
            '        StrScan.Append(Environment.NewLine)
            '        StrScan.Append("update m_Assysn_t set Estateid='R'  where ppid in(select ppid from m_cartonsn_t where cartonid='" & Trim(TxtCartonId.Text) & "')")
            '        StrScan.Append(Environment.NewLine)
            '        StrScan.Append("delete from m_cartonsn_t where cartonid='" & Trim(TxtCartonId.Text) & "'")
            '        StrScan.Append(Environment.NewLine)
            '    Else
            '        MessageBox.Show("該箱所對應的重工工單未維護重工方式,或無法識別此箱號!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        TxtCartonId.Text = ""
            '        DrPubUse.Close()
            '        Exit Sub
            '    End If
            '    DrPubUse.Close()
            'Else
            '    MessageBox.Show("該箱所對應的重工工單未維護重工方式,或無法識別此箱號!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    TxtCartonId.Text = ""
            '    DrPubUse.Close()
            '    Exit Sub
            'End If

            PubClass.ExecSql(StrScan.ToString)
            StrScan.Remove(0, StrScan.ToString.Length)
            '2009/08/18---與倉庫調撥動作相關聯---唐祥
            PubClass.ExecSql("exec m_Rework_ReMove_p '" & Trim(TxtCartonId.Text) & "','" & Trim(TxtPartid.Text) & "','" & (SysMessageClass.UseId) & "'")
            GetScanItem()
            TxtCartonId.Text = ""
        Catch ex As Exception
            DrPubUse.Close()
            'MessageBox.Show(ex.Message, "提示信息!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmInStorge", "BtScan_Click", "sys")
        End Try

    End Sub

    Private Sub TxtCartonId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCartonId.KeyPress
        If e.KeyChar = Chr(13) Then
            BtCScan_Click(sender, e)
            Me.TxtCartonId.Clear()
        End If
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub BtPScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim StrScan As New StringBuilder
        Dim DtPubUse As DataTable
        Dim DrPubUse As SqlDataReader

        StrScan.Remove(0, StrScan.ToString.Length)
        If CobRwBill.Text = "" Then
            MessageBox.Show("請先建立出庫單!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If CobRwMoid.Text = "" Then
            MessageBox.Show("請先輸入重工工單!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Trim(TxtPalletid.Text) = "" Then
            MessageBox.Show("棧板序號不能為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            DtPubUse = PubClass.GetDataTable("select distinct(b.cartonstatus) from m_PalletCarton_t a left join m_Carton_t b on a.cartonid=b.cartonid where Palletid='" & Trim(Me.TxtPalletid.Text) & "'")
            If DtPubUse.Rows.Count > 1 Then
                MessageBox.Show("該棧板箱號狀態不一，只能單箱掃描出庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtPalletid.Text = ""
                DtPubUse = Nothing
                Exit Sub
            Else
                Select Case DtPubUse.Rows(0).Item(0)
                    Case "N"
                        MessageBox.Show("該棧板箱號處於產線包裝狀態，不得出庫重工!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtPalletid.Text = ""
                        Exit Sub
                    Case "Y"
                        MessageBox.Show("該棧板箱號未入庫，不得出庫重工!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtPalletid.Text = ""
                        Exit Sub
                    Case "S"
                        MessageBox.Show("該棧板箱號均已拆箱，只能單箱掃描出庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtPalletid.Text = ""
                        Exit Sub
                    Case "O"
                        MessageBox.Show("該棧板箱號已出庫，不得再出庫重工!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtPalletid.Text = ""
                        Exit Sub
                    Case "E"
                        MessageBox.Show("該棧板箱號均已拆空，不得出庫重工!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtPalletid.Text = ""
                        Exit Sub
                    Case "R"
                        MessageBox.Show("該棧板箱號已出庫重工，不能再出庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtPalletid.Text = ""
                        Exit Sub
                    Case "Q"
                        MessageBox.Show("該棧板箱號已FQC抽驗判退,不能出庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtPalletid.Text = ""
                        Exit Sub
                    Case "I"
                        DtPubUse = Nothing
                        DtPubUse = PubClass.GetDataTable("select * from m_PalletCarton_t a join m_Carton_t b on a.cartonid=b.cartonid where b.moid not in(select aa.resourcemo from m_Requestd_t aa join m_RequestM_t bb on aa.requestid=bb.requestid where aa.moid='" & Trim(Me.CobRwMoid.Text) & "' ) where a.Palletid='" & Trim(Me.TxtPalletid.Text) & "'")
                        If DtPubUse.Rows.Count > 1 Then
                            MessageBox.Show("該棧板有不屬於該重工工單的箱號，不能以棧板出庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.TxtPalletid.Text = ""
                            DtPubUse = Nothing
                            Exit Sub
                        End If
                        DrPubUse = PubClass.GetDataReader("select sum(cartonqty) from m_Carton_t where cartonid in (select  cartonid from m_PalletCarton_t where Palletid='" & Trim(Me.TxtPalletid.Text) & "')")
                        DrPubUse.Read()
                        If DrPubUse.GetInt32(0) + CInt(LabSumQty.Text) > CInt(TxtRwQty.Text) Then
                            MessageBox.Show("請注意！產品掃描數量大於出貨數量!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.TxtPalletid.Text = ""
                            DrPubUse.Close()
                            Exit Sub
                        End If
                        LabSumQty.Text = CInt(LabSumQty.Text) + DrPubUse.GetInt32(0)
                        DrPubUse.Close()
                        If Me.LabCQty.Text = "" Then
                            StrScan.Append("update m_WhoutM_t set remoid='" & Trim(Me.CobRwMoid.Text) & "',Partid='" & Trim(TxtPartid.Text) & "',Shipqty='" & Trim(Me.TxtRwQty.Text) & "' where outwhid='" & Trim(Me.CobRwBill.Text) & "'")
                            StrScan.Append(Environment.NewLine)
                        End If
                        '**********************************************************
                        'rework Time:      2008/12/01 
                        'rework by:        tangxiang
                        'Reason :          m_WhOutD_t表增加“出庫數量”
                        '**********************************************************
                        'StrScan.Append("insert into m_WhoutD_t select '" & Trim(CobRwBill.Text) & "',cartonid,'" & (SysMessageClass.UseId) & "',getdate() from m_PalletCarton_t where Palletid='" & Trim(Me.TxtPalletid.Text) & "'")
                        StrScan.Append("insert into m_WhoutD_t select '" & Trim(CobRwBill.Text) & "',cartonid,'" & (SysMessageClass.UseId) & "',getdate(),CartonQty from m_Carton_t where cartonid in(select cartonid from m_PalletCarton_t where Palletid='" & Trim(Me.TxtPalletid.Text) & "'and usey='Y')")
                        StrScan.Append(Environment.NewLine)
                        '**********************************************************
                        'rework Time:      2008/12/01 
                        'rework by:        tangxiang
                        'Reason :          M_Carton_t表增加更新人員、時間
                        '**********************************************************
                        'StrScan.Append("update M_Carton_t set CartonStatus='R',intime=getdate(),userid='" & (SysMessageClass.UseId) & "' where Cartonid in(select cartonid from m_PalletCarton_t where Palletid='" & Trim(Me.TxtPalletid.Text) & "')")
                        StrScan.Append("update M_Carton_t set CartonStatus='R',updatetime=getdate(),updateuser='" & (SysMessageClass.UseId) & "' where Cartonid in(select cartonid from m_PalletCarton_t where Palletid='" & Trim(Me.TxtPalletid.Text) & "')")
                        StrScan.Append(Environment.NewLine)
                        StrScan.Append("update m_Assysn_t set Estateid='R' where ppid in(select ppid from M_Cartonsn_t where cartonid in (select cartonid from m_PalletCarton_t where Palletid='" & Trim(Me.TxtPalletid.Text) & "'))")

                        PubClass.ExecSql(StrScan.ToString)
                        StrScan.Remove(0, StrScan.ToString.Length)
                        GetScanItem()   ''獲取單據掃描記錄
                        Me.TxtPalletid.Text = ""
                    Case Else
                        MessageBox.Show("無法識別此棧板箱號!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtPalletid.Text = ""
                        Exit Sub
                End Select
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutStorge", "BtPScan_Click", "sys")
        Finally
            DtPubUse = Nothing
        End Try

    End Sub

    Private Sub TxtPalletid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            BtPScan_Click(sender, e)
            Me.TxtPalletid.Text = ""
        End If
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub CobRwMoid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobRwMoid.KeyPress
        If e.KeyChar = Chr(13) Then
            TxtCartonId.Focus()
        End If
    End Sub

    Private Sub CobRwMoid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobRwMoid.SelectedIndexChanged
        Dim DrGetData As SqlDataReader
        If Me.CobRwMoid.Text = "" Then Exit Sub
        DrGetData = PubClass.GetDataReader("select a.partid,c.djc,a.moqty,b.requester,b.requestid from m_Mainmo_t a join m_Requestm_t b on a.moid=b.moid left join m_Dept_t c on a.deptid=c.deptid  where a.moid='" & Trim(CobRwMoid.Text) & "'and b.retype=2")
        If DrGetData.Read Then
            TxtPartid.Text = DrGetData("Partid").ToString
            TxtRwDept.Text = DrGetData("djc").ToString
            TxtRwQty.Text = DrGetData("moqty").ToString
            TxtObject.Text = DrGetData("requester").ToString
            StrRequest = DrGetData("requestid").ToString
        End If
        DrGetData.Close()
    End Sub

    Private Sub TsBnOutBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBnOutBill.Click
        Try ''1.新建入庫單
            If MessageBox.Show("你確定要新建出庫單嗎？", "信息提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                Me.TxtPartid.Text = ""
                Me.CobRwMoid.SelectedIndex = -1
                TxtRwDept.Text = ""
                TxtRwQty.Text = ""
                TxtOuttime.Text = ""
                TxtObject.Text = ""
                TxtDescript.Text = ""
                LabCQty.Text = ""
                Me.LabSumQty.Text = ""
                CobRwBill.Items.Add(GetOutWhId())
                CobRwBill.SelectedIndex = CobRwBill.Items.Count - 1

                TxtOuttime.Text = Format(Now, "yyyy/MM/dd HH:mm")
                ''2.保存新建的入庫單
                PubClass.ExecSql("insert m_WhOutM_t(Outwhid,outtype,Userid,Intime) values('" & Trim(CobRwBill.Text) & "','R','" & (SysMessageClass.UseId) & "',getdate())")
                CobRwMoid.Focus()
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "提示信息!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmReworkOut", "BtNewBill_Click", "sys")
        End Try

    End Sub

    Private Sub TsBtEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtEnter.Click
        If DGridBarCode.Rows.Count < 1 Then Exit Sub
        Dim StrInCof As New StringBuilder
        Dim StrType As String '重工方式
        Dim DrPubUse As SqlDataReader = Nothing

        If MessageBox.Show("你確定將單據" & Me.CobRwBill.Text & "出庫嗎？", "信息提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            If LabSumQty.Text <> TxtRwQty.Text Then
                MessageBox.Show("產品掃描數量與出貨數量不符,不能出庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            StrInCof.Append("update m_WhoutM_t set States='2',Remark='" & Trim(TxtDescript.Text) & "',Shipqty='" & Trim(Me.TxtRwQty.Text) & "' where outwhid='" & Me.CobRwBill.Text & "'")
            'StrInCof.Append(Environment.NewLine)
            'StrInCof.Append("update M_Carton_t set CartonStatus='O',intime=getdate(),userid='" & (SysMessageClass.UseId) & "' where Cartonid in (select Cartonid from m_WhoutD_t where outwhid='" & CobOutBill.Text & "') ")
            '*********************換主條碼與不換主條碼的不同處理*******************************************2009/09/06********
            DrPubUse = PubClass.GetDataReader("select changey from m_RequestM_t where usey='Y' and moid='" & Trim(CobRwMoid.Text) & "'")
            If DrPubUse.HasRows Then
                DrPubUse.Read()
                StrType = DrPubUse(0).ToString

                If StrType = "1" Then '換主條碼
                    StrInCof.Append("update m_SnSBarCode_t set usey='N' where sbarcode in(select cartonid from m_WhOUTD_t where OUTwhid='" & Me.CobRwBill.Text & "')")
                    StrInCof.Append(Environment.NewLine)
                    StrInCof.Append("update m_SnSBarCode_t set usey='N' where sbarcode in(select ppid from m_cartonsn_t where cartonid in (select cartonid from m_WhOUTD_t where OUTwhid='" & Me.CobRwBill.Text & "'))")
                    StrInCof.Append(Environment.NewLine)
                    StrInCof.Append("update m_Assysn_t set Estateid='R'  where ppid in(select ppid from m_cartonsn_t where cartonid in (select cartonid from m_WhOUTD_t where OUTwhid='" & Me.CobRwBill.Text & "'))")
                    StrInCof.Append(Environment.NewLine)
                    StrInCof.Append("update m_AssysnD_t set Estateid='R' where ppid in(select ppid from m_cartonsn_t where cartonid in (select cartonid from m_WhOUTD_t where OUTwhid='" & Me.CobRwBill.Text & "'))")
                    StrInCof.Append(Environment.NewLine)
                    StrInCof.Append("update m_Ppidlink_t set usey='N' where exppid in(select ppid from m_cartonsn_t where cartonid in (select cartonid from m_WhOUTD_t where OUTwhid='" & Me.CobRwBill.Text & "'))")
                    StrInCof.Append(Environment.NewLine)
                ElseIf StrType = "0" Then '不換主條碼
                    StrInCof.Append("update m_SnSBarCode_t set usey='N' where sbarcode in (select cartonid from m_WhOUTD_t where OUTwhid='" & Me.CobRwBill.Text & "')")
                    StrInCof.Append(Environment.NewLine)
                    StrInCof.Append("delete a from m_AssysnD_t a ,m_Assysn_t b where a.ppid=b.ppid and a.stationid=b.stationid " & _
                                   "and b.ppid in(select ppid from m_cartonsn_t where cartonid in (select cartonid from m_WhOUTD_t where OUTwhid='" & Me.CobRwBill.Text & "'))")
                    StrInCof.Append(Environment.NewLine)
                    StrInCof.Append("update m_assysn_t set stationid=isnull((select top 1 stationid from m_RPartStationD_t where " & _
                                   "state =1 and ppartid='" & Trim(TxtPartid.Text) & "' and staorderid = " & _
                                   "(select case  max(staorderid) when 1 then 0 else max(staorderid)-1 end " & _
                                   "from m_RPartStationD_t where  state =1 and ppartid='" & Trim(TxtPartid.Text) & "')),'') " & _
                                   "where ppid in(select ppid from m_cartonsn_t where cartonid in (select cartonid from m_WhOUTD_t where OUTwhid='" & Me.CobRwBill.Text & "'))")
                    StrInCof.Append(Environment.NewLine)
                    StrInCof.Append("update m_Assysn_t set Estateid='R'  where ppid in(select ppid from m_cartonsn_t where cartonid in (select cartonid from m_WhOUTD_t where OUTwhid='" & Me.CobRwBill.Text & "'))")
                    StrInCof.Append(Environment.NewLine)
                    StrInCof.Append("delete from m_cartonsn_t where cartonid in (select cartonid from m_WhOUTD_t where OUTwhid='" & Me.CobRwBill.Text & "')")
                    StrInCof.Append(Environment.NewLine)
                Else
                    MessageBox.Show("該箱所對應的重工工單未維護重工方式!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonId.Text = ""
                    DrPubUse.Close()
                    Exit Sub
                End If
                DrPubUse.Close()
            Else
                MessageBox.Show("該箱所對應的重工工單未維護重工方式!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCartonId.Text = ""
                DrPubUse.Close()
                Exit Sub
            End If
            PubClass.ExecSql(StrInCof.ToString)
            StrInCof.Remove(0, StrInCof.ToString.Length)
            CobRwBill.Items.Remove(CobRwBill.Text)
            CobRwBill.SelectedIndex = -1
            Me.DGridBarCode.DataSource = Nothing
            Me.TxtPartid.Text = ""
            TxtRwDept.Text = ""
            TxtRwQty.Text = ""
            Me.TxtDescript.Text = ""
            TxtObject.Text = ""
            Me.TxtOuttime.Text = ""
            LabCQty.Text = ""
            Me.LabSumQty.Text = ""

        End If
    End Sub

    Private Sub TsBtDrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtDrop.Click
        If Me.CobRwBill.Text = "" Then Exit Sub
        Dim StrInDrop As New StringBuilder
        If MessageBox.Show("你確定捨棄重工出庫單號:" & Me.CobRwBill.Text & "？", "信息提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            '**********************************************************
            'rework Time:      2008/12/01 
            'rework by:        tangxiang
            'Reason :          M_Carton_t表增加更新人員、時間
            '**********************************************************
            'StrInDrop.Append("update M_Carton_t set cartonstatus='I' where cartonid in (select cartonid from m_WhOUTD_t where OUTwhid='" & Me.CobRwBill.Text & "' )")
            StrInDrop.Append("update M_Carton_t set cartonstatus='I',updatetime=getdate(),updateuser='" & (SysMessageClass.UseId) & "' where cartonid in (select cartonid from m_WhOUTD_t where OUTwhid='" & Me.CobRwBill.Text & "' )")
            StrInDrop.Append(Environment.NewLine)
            'StrInDrop.Append("update m_Assysn_t set Estateid='' where ppid in(select ppid from M_Cartonsn_t where cartonid in (select cartonid from m_WhOUTD_t where OUTwhid='" & Me.CobRwBill.Text & "' )) ")
            'StrInDrop.Append(Environment.NewLine)
            StrInDrop.Append("delete from m_WhOutM_t  where outwhid='" & Me.CobRwBill.Text & "'")
            StrInDrop.Append(Environment.NewLine)
            StrInDrop.Append("delete from m_WhoutD_t  where outwhid='" & Me.CobRwBill.Text & "'")

            PubClass.ExecSql(StrInDrop.ToString)
            CobRwBill.Items.Remove(CobRwBill.Text)
            CobRwBill.SelectedIndex = -1
            Me.DGridBarCode.DataSource = Nothing
            Me.TxtPartid.Text = ""
            TxtRwDept.Text = ""
            TxtRwQty.Text = ""
            Me.TxtDescript.Text = ""
            TxtObject.Text = ""
            Me.TxtOuttime.Text = ""
            LabCQty.Text = ""
            Me.LabSumQty.Text = ""
        End If
    End Sub

    Private Sub TsBnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBnBack.Click
        PubClass = Nothing
        Me.Close()
    End Sub

    Private Sub TxtRwQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRwQty.KeyPress
        If Char.IsDigit(e.KeyChar) OrElse e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            TxtCartonId.Focus()
        End If
    End Sub

    'Private Sub TxtCartonId_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCartonId.KeyDown
    '    If TxtCartonId.Text = "" Then
    '        G_time = Now
    '    End If
    'End Sub
End Class