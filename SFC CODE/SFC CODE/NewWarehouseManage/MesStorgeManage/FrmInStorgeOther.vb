Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Text
Imports System.Data.SqlClient
Imports System.Xml
Imports System.IO

Public Class FrmInStorgeOther
    Dim PubClass As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim G_BlnFirst As Boolean '是否為第一箱
    Dim G_time As DateTime  '用於保存當前輸入時間---2009/7/24
    Dim StrWwflag As Boolean '用戶判讀是否委外包裝箱
    'rework by anday 2011/09/05


    Private Sub FrmInStorgeOther_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SysMessageClass.UseId = "sz30914"
        Dim Dr As SqlDataReader

        LabSumQty.Text = 0
        FillCobType(CobInBill, "select Inwhid from m_WhInM_t where userid='" & SysMessageClass.UseId & "' and States='1'")

        FillCobType(CobFloor, "select distinct(Floorid) from m_Wh_t where factory in(select buttonid from m_UserRight_t a join m_Logtree_t b on a.tkey=b.tkey where b.tparent='F0_' and a.userid= '" & SysMessageClass.UseId & "')and usey='Y' and floorid <> ''")

        ''FillCobType(CobWhid, "select distinct(whid) from m_Whouse_t where whid like '%G'")
        Me.RbCartonScan.Checked = True '
        Dr = PubClass.GetDataReader("select * from m_userright_t where tkey='m0800_' and userid='" & SysMessageClass.UseId & "'")
        If Dr.HasRows Then
            RbCartonScan.Enabled = True
            RbCartonScan.Tag = "YES"
            RbPalletScan.Enabled = True
            RbPalletScan.Tag = "YES"
        End If
        Dr.Close()

    End Sub

    Private Sub FrmInStorgeOther_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.A AndAlso e.Alt Then
            ToolStripButton1_Click(sender, e)
        ElseIf e.KeyCode = Keys.S AndAlso e.Alt Then
            TsBtEnter_Click(sender, e)
        ElseIf e.KeyCode = Keys.D AndAlso e.Alt Then
            TsBtDrop_Click(sender, e)
        ElseIf e.KeyCode = Keys.E AndAlso e.Alt Then
            TsBnBack_Click(sender, e)
        End If
    End Sub


#Region "新建單據編號"
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBnInBill.Click
        'Try ''1.新建入庫單
        '    If MessageBox.Show("你確定要新建入庫單嗎？", "信息提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
        '        Me.TxtMoid.Text = ""
        LabCQty.Text = ""
        TxtInQty.Text = ""
        Me.TxtPartid.Text = ""
        Me.TxtDiscript.Text = ""
        Me.TxtIntime.Text = ""
        CobFloor.SelectedIndex = -1
        Me.CobWhArea.SelectedIndex = -1
        Me.CobWhid.SelectedIndex = -1
        LabCQty.Text = ""
        Me.TxtMoid.Text = ""
        Me.TxtInQty.Text = ""
        Me.LabSumQty.Text = ""
        Me.TxtPalletID.Text = ""
        TxtInQty.Enabled = True
        CobFloor.Enabled = True
        CobWhid.Enabled = True
        CobWhArea.Enabled = True
        TxtDiscript.Enabled = True
        Me.DGridBarCode.DataSource = Nothing
        TxtInQty.Focus()

    End Sub
#End Region

#Region "新建單據編號函數"
    Private Function GetInWhId() As String ''新建單據編號

        Dim DataGridTable As DataTable
        Dim StrMaxInBill As String = ""

        DataGridTable = PubClass.GetDataTable("select max(Inwhid) from m_WhInM_t where substring(Inwhid,3,6)=convert(varchar(6),getdate(),12) and Inwhid like 'WI%'")
        If DataGridTable.Rows(0).Item(0) Is DBNull.Value Then
            StrMaxInBill = "WI" & Format(Now, "yyMMdd") & "0001"
            DataGridTable = Nothing
            Return StrMaxInBill
        Else
            StrMaxInBill = "WI" & Mid((1 & Mid(DataGridTable.Rows(0).Item(0), 3)) + 1, 2)
            DataGridTable = Nothing
            Return StrMaxInBill
        End If

    End Function
#End Region

#Region "入庫掃描"

    Private Sub TxtCartonid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCartonid.KeyPress
        Dim StrScan As New StringBuilder
        Dim DrPubUse As SqlDataReader = Nothing
        Dim IntQty As Int64
        Dim StrCarton As String = "" '(2008/11/20加入)
        Dim StrMaxInBill As String '最大入庫單號
        Dim StrInType As String
        'Dim StrCobFloor As String
        'Dim StrCobWhid As String
        'Dim StrCobWhArea As String
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            Try
                ''加入輸入時間控制--2秒
                'If DateDiff(DateInterval.Second, G_time, Now) >= 2 Then
                '    TxtCartonid.Text = ""
                '    Exit Sub
                'End If
                'If CobInBill.Text = "" Then
                '    PlaySimpleSound(1)
                '    MessageBox.Show("請先建立入庫單!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    TxtCartonid.Text = ""
                '    Exit Sub
                'End If

                If TxtInQty.Text = "" Then
                    PlaySimpleSound(1)
                    MessageBox.Show("請先輸入入庫數量!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Text = ""
                    Exit Sub
                End If

                If Trim(TxtCartonid.Text) = "" Then
                    PlaySimpleSound(1)
                    MessageBox.Show("裝箱序號不能為空!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Text = ""
                    Exit Sub
                End If

                'rework by anday 2011/09/02 更新委外包裝箱狀態為"Y"
                Try
                    CheckWwWo(Trim(TxtCartonid.Text))
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try

                If TxtMoid.Text = "" Then ''掃描第一筆箱號
                    G_BlnFirst = True
                    DrPubUse = PubClass.GetDataReader("select b.partid,a.Cartonqty,a.CartonStatus,b.moid from M_Carton_t a join m_Mainmo_t b on a.Moid=b.Moid where  a.cartonid='" & Trim(TxtCartonid.Text) & "'")
                    If DrPubUse.HasRows Then
                        DrPubUse.Read()
                        Dim strStatus As String = DrPubUse.GetString(2)
                        StrCarton = DrPubUse("Cartonqty").ToString  '箱裝數量(2008/11/20加入)
                        If strStatus = "I" Then
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱已入庫,不能重復入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        ElseIf strStatus = "S" Then
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱為拆散箱,不能重復入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        ElseIf strStatus = "E" Then
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱為空箱,不能入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        ElseIf strStatus = "N" Then
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱未裝滿,不能入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        ElseIf strStatus = "O" Then
                            '----rework by anday_xu  增加委外工單的處理''
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱已正常出庫,不能再入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub

                        ElseIf strStatus = "R" Then
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱已出庫重工,不能再入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        ElseIf strStatus = "Q" Then
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱已FQC抽驗判退,不能入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        ElseIf strStatus = "Y" Then
                            If CInt(TxtInQty.Text) < CInt(DrPubUse("Cartonqty").ToString) Then
                                PlaySimpleSound(1)
                                MessageBox.Show("該箱數量大於入庫數量!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                TxtCartonid.Clear()
                                DrPubUse.Close()
                                Exit Sub
                            End If
                            Dim FrmInformation As New FrmInfShow
                            Dim ClassInf As New InfClass
                            ClassInf.StrInf = "該箱所屬工單為： " & DrPubUse("moid").ToString & vbCrLf & "該箱所屬料號為： " & DrPubUse("partid").ToString & vbCrLf & "該箱包裝數量為： " & DrPubUse("Cartonqty").ToString
                            ClassInf.StrColor = Color.Green
                            ClassInf.StrQInf = "你確定掃描這批產品嗎?"
                            ClassInf.StrQColor = Color.Red
                            PlaySimpleSound(3)
                            FrmInformation.ShowDialog()
                            If ClassInf.ChoseY = True Then
                                RbCartonScan.Enabled = False
                                Me.RbPalletScan.Enabled = False
                                TxtMoid.Text = DrPubUse("moid").ToString
                                TxtPartid.Text = DrPubUse("partid").ToString
                                Me.LabSumQty.Text = DrPubUse("Cartonqty").ToString
                                DrPubUse.Close()
                                '生成最大入庫單號
                                StrMaxInBill = GetInWhId()
                                CobInBill.Items.Add(StrMaxInBill)
                                CobInBill.SelectedIndex = CobInBill.Items.Count - 1
                                Me.DGridBarCode.DataSource = Nothing
                                TxtIntime.Text = Format(Now, "yyyy/MM/dd HH:mm")
                                TxtCartonid.Focus()
                                If RbPalletScan.Checked = True And Trim(TxtPalletID.Text) <> "" Then
                                    StrInType = "P"
                                Else
                                    StrInType = "C"
                                End If
                                StrScan.Append("insert m_WhInM_t(Inwhid,Intype,Userid,Intime,Moid) values('" & StrMaxInBill & "','" & StrInType & "','" & SysMessageClass.UseId & "','" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "','" & Trim(Me.TxtMoid.Text) & "')")
                                StrScan.Append(Environment.NewLine)
                                ClassInf.ChoseY = False
                            Else
                                TxtCartonid.Clear()
                                DrPubUse.Close()
                                ClassInf.ChoseY = False
                                Exit Sub
                            End If
                        Else
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱不符合入庫狀態,其狀態為: " & DrPubUse.GetString(2) & " !", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        End If
                    Else
                        PlaySimpleSound(1)
                        MessageBox.Show("無法識別此箱號!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtCartonid.Clear()
                        DrPubUse.Close()
                        Exit Sub
                    End If
                Else ''核對工單
                    G_BlnFirst = False
                    DrPubUse = PubClass.GetDataReader("select Cartonqty,CartonStatus from M_Carton_t where cartonid='" & Trim(TxtCartonid.Text) & "' and moid='" & Trim(Me.TxtMoid.Text) & "'")

                    If DrPubUse.HasRows Then
                        DrPubUse.Read()
                        Dim strStatus As String = DrPubUse.GetString(1)
                        StrCarton = DrPubUse("Cartonqty").ToString  '箱裝數量(2008/11/20加入)
                        If strStatus = "I" Then
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱已入庫,不能重復入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        ElseIf strStatus = "S" Then
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱為拆散箱,不能重復入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        ElseIf strStatus = "E" Then
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱為空箱,不能入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        ElseIf strStatus = "N" Then
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱未裝滿,不能入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        ElseIf strStatus = "O" Then
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱已正常出庫,不能再入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        ElseIf strStatus = "R" Then
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱已出庫重工,不能再入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        ElseIf strStatus = "Q" Then
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱已FQC抽驗判退,不能入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        ElseIf strStatus = "Y" Then
                            If CInt(TxtInQty.Text) < CInt(StrCarton) + CInt(Me.LabSumQty.Text) Then
                                PlaySimpleSound(1)
                                MessageBox.Show("產品總數大於入庫數量!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                TxtCartonid.Clear()
                                DrPubUse.Close()
                                Exit Sub
                            End If
                            IntQty = StrCarton
                            DrPubUse.Close()
                            Me.LabSumQty.Text = Me.LabSumQty.Text + IntQty
                        Else
                            PlaySimpleSound(1)
                            MessageBox.Show("該箱不符合入庫狀態,其狀態為: " & DrPubUse.GetString(1) & " !", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            TxtCartonid.Clear()
                            DrPubUse.Close()
                            Exit Sub
                        End If
                    Else
                        PlaySimpleSound(1)
                        MessageBox.Show("該箱不屬於當前工單或無法識別此箱號!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtCartonid.Clear()
                        DrPubUse.Close()
                        Exit Try
                    End If
                End If

                If Me.RbCartonScan.Checked = True Then
                    '**********************************************************
                    'rework Time:      2008/11/20 
                    'rework by:        tangxiang
                    'Reason :          M_WHInD_t表增加CartonInQty(入庫數量)
                    '**********************************************************
                    'StrScan.Append("insert m_WhInD_t(Inwhid,Cartonid,Userid,Intime) values('" & Trim(CobInBill.Text) & "','" & Trim(TxtCartonid.Text) & "','" & (SysMessageClass.UseId) & "',getdate())")
                    StrScan.Append("insert m_WhInD_t(Inwhid,Cartonid,Userid,Intime,CartonInQty) values('" & Trim(CobInBill.Text) & "','" & Trim(TxtCartonid.Text) & "','" & (SysMessageClass.UseId) & "',getdate(),'" & StrCarton & "')")
                    StrScan.Append(Environment.NewLine)
                    '**********************************************************
                    'rework Time:      2008/11/20 
                    'rework by:        tangxiang
                    'Reason :          M_Carton_t表增加 updatetime 和updateuser
                    '**********************************************************
                    ' StrScan.Append("update M_Carton_t set CartonStatus='I',intime=getdate(),userid='" & (SysMessageClass.UseId) & "' where Cartonid='" & Trim(TxtCartonid.Text) & "'")
                    StrScan.Append("update M_Carton_t set CartonStatus='I',updatetime=getdate(),updateuser='" & (SysMessageClass.UseId) & "' where Cartonid='" & Trim(TxtCartonid.Text) & "'")
                    PubClass.ExecSql(StrScan.ToString)
                    StrScan.Remove(0, StrScan.ToString.Length)
                    GetScanItem()
                Else
                    '*********************************************************
                    'rework Time:      2008/11/20 
                    'rework by:        tangxiang
                    'Reason :          M_WHInD_t表增加CartonInQty(入庫數量)
                    '*********************************************************
                    'StrScan.Append("insert m_WhInD_t(Inwhid,Cartonid,Userid,Intime) values('" & Trim(CobInBill.Text) & "','" & Trim(TxtCartonid.Text) & "','" & (SysMessageClass.UseId) & "',getdate())")
                    StrScan.Append("insert m_WhInD_t(Inwhid,Cartonid,Userid,Intime,CartonInQty) values('" & Trim(CobInBill.Text) & "','" & Trim(TxtCartonid.Text) & "','" & (SysMessageClass.UseId) & "',getdate(),'" & StrCarton & "')")
                    StrScan.Append(Environment.NewLine)
                    '*********************************************************
                    'rework Time:      2008/11/20 
                    'rework by:        tangxiang
                    'Reason :          M_Carton_t表增加 updatetime 和updateuser
                    '*********************************************************
                    'StrScan.Append("update M_Carton_t set CartonStatus='I',intime=getdate(),userid='" & (SysMessageClass.UseId) & "' where Cartonid='" & Trim(TxtCartonid.Text) & "'")
                    StrScan.Append("update M_Carton_t set CartonStatus='I',updatetime=getdate(),updateuser='" & (SysMessageClass.UseId) & "' where Cartonid='" & Trim(TxtCartonid.Text) & "'")
                    StrScan.Append(Environment.NewLine)
                    StrScan.Append("update M_PalletM_t set inwhid='" & CobInBill.Text & "', Palletqty=Palletqty + 1,intime=getdate(),userid='" & (SysMessageClass.UseId) & "' where PalletID='" & Trim(Me.TxtPalletID.Text) & "'")
                    StrScan.Append(Environment.NewLine)
                    StrScan.Append("insert into M_PalletCarton_t(Palletid,Cartonid,Usey,userid,intime) values('" & Trim(Me.TxtPalletID.Text) & "','" & Trim(Me.TxtCartonid.Text) & "','Y','" & (SysMessageClass.UseId) & "',getdate())")
                    PubClass.ExecSql(StrScan.ToString)
                    StrScan.Remove(0, StrScan.ToString.Length)
                    GetPScanItem()
                End If
                TxtCartonid.Clear()
                PlaySimpleSound(0)
                If LabSumQty.Text = Me.TxtInQty.Text Then
                    MessageBox.Show("掃描數量已達到入庫數量，請確認入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Exit Sub
            Catch ex As Exception
                DrPubUse.Close()
                SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmInStorge", "TxtCartonid_KeyPress", "sys")
            End Try
        End If
    End Sub

    Private Sub CheckWwWo(ByVal StrCartionid As String)
        '判斷箱號是否是委外入庫的工單中的箱號
        Dim strSql As String = " SELECT * FROM m_WhOutD_t a,WS_worked_t b,m_carton_t c where" _
                              & " a.OUTWHID=b.keyid  and a.cartonid=c.cartonid and CartonStatus='O'" _
                              & " and a.cartonid='" & StrCartionid & "'" _
                              & " and a.cartonid not in (select cartonid from m_WhInD_t ) "

        Dim DrPubCarton As SqlDataReader = PubClass.GetDataReader(strSql)
        If DrPubCarton.HasRows Then
            DrPubCarton.Close()
            PubClass.ExecSql("update m_carton_t set CartonStatus='Y' where cartonid='" & StrCartionid & "'")
        End If
        DrPubCarton.Close()
    End Sub


    Private Sub RbCartonScan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbCartonScan.CheckedChanged
        Dim value As Color
        value = TxtColor.BackColor
        If RbCartonScan.Checked = True Then
            TxtCartonid.Enabled = True
            TxtPalletID.Enabled = False
            BtPScanEnd.Enabled = False
            TxtCartonid.BackColor = value
            Me.TxtPalletID.BackColor = Color.White
            Me.TxtCartonid.Focus()
        Else
            TxtCartonid.Enabled = False
            TxtPalletID.Enabled = True
            BtPScanEnd.Enabled = True
            TxtPalletID.BackColor = value
            Me.TxtCartonid.BackColor = Color.White
            Me.TxtPalletID.Focus()
        End If
    End Sub

    Private Sub TxtPalletID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPalletID.KeyPress
        Dim DrPCscan As SqlDataReader
        Dim StrScan As New StringBuilder
        Dim StrMoid As String
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then
            'If CobInBill.Text = "" Then
            '    MessageBox.Show("請先建立入庫單!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    TxtPalletID.Text = ""
            '    Exit Sub
            'End If
            If TxtInQty.Text = "" Then
                MessageBox.Show("請先輸入入庫數量!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtPalletID.Text = ""
                Exit Sub
            End If
            If Trim(TxtPalletID.Text) = "" Then
                MessageBox.Show("棧板序號不能為空!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtPalletID.Text = ""
                Exit Sub
            End If
            DrPCscan = PubClass.GetDataReader("Select * from m_SnSBarCode_t where sbarcode='" & Trim(Me.TxtPalletID.Text) & "'")
            If DrPCscan.Read Then
                Select Case DrPCscan("usey").ToString
                    Case "N"
                        MessageBox.Show("該棧板條碼為測試條碼！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtPalletID.Text = ""
                        DrPCscan.Close()
                        Exit Sub
                    Case "S"
                        MessageBox.Show("該棧板條碼已掃描過！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtPalletID.Text = ""
                        DrPCscan.Close()
                        Exit Sub
                    Case "Y"
                        StrMoid = DrPCscan("moid").ToString
                        DrPCscan.Close()
                        'StrScan.Append("update m_WhInM_t set intype='P' where inwhid='" & Trim(CobInBill.Text) & "'")
                        'StrScan.Append(Environment.NewLine)
                        StrScan.Append("update m_SnSBarCode_t set usey='S' where Sbarcode='" & Trim(Me.TxtPalletID.Text) & "'")
                        StrScan.Append(Environment.NewLine)
                        StrScan.Append("insert into M_PalletM_t(Palletid,moid,PalletQty,PalletStatus,userid,intime) values('" & Trim(Me.TxtPalletID.Text) & "','" & StrMoid & "','0','N','" & SysMessageClass.UseId.ToLower & "',getdate())")
                        PubClass.ExecSql(StrScan.ToString)
                        StrScan.Remove(0, StrScan.ToString.Length)
                        RbCartonScan.Enabled = False
                        Me.RbPalletScan.Enabled = False
                        Dim value As Color
                        value = TxtColor.BackColor
                        TxtCartonid.Enabled = True
                        TxtPalletID.Enabled = False
                        BtPScanEnd.Enabled = True
                        TxtCartonid.BackColor = value
                        Me.TxtPalletID.BackColor = Color.White
                        Me.TxtCartonid.Focus()
                End Select
            Else
                DrPCscan.Close()
                MessageBox.Show("無法識別該棧板條碼！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtPalletID.Text = ""
            End If

        End If

    End Sub

    Private Sub BtPScanEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPScanEnd.Click
        Dim DrPCscan As SqlDataReader
        If Me.TxtPalletID.Text = "" Then
            MessageBox.Show("請先掃描棧板條碼！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtPalletID.Focus()
            Exit Sub
        End If
        DrPCscan = PubClass.GetDataReader("select * from m_PalletCarton_t where palletid='" & Trim(Me.TxtPalletID.Text) & "'")
        If Not DrPCscan.Read Then
            DrPCscan.Close()
            MessageBox.Show("請先進行棧板包裝箱號條碼掃描！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtCartonid.Focus()
            Exit Sub
        End If
        DrPCscan.Close()
        If MessageBox.Show("你確定完成該棧板包裝嗎？", "信息提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            PubClass.ExecSql("update M_PalletM_t set PalletStatus='I' Where Palletid='" & Trim(Me.TxtPalletID.Text) & "'")
            RbCartonScan.Enabled = True
            Me.RbPalletScan.Enabled = True
            TxtPalletID.Text = ""
            RbPalletScan.Checked = True
        End If
    End Sub

#End Region

#Region "聲音播放"
    Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        Select Case PassOrNg
            Case 0
                My.Computer.Audio.Play(My.Resources.pass, AudioPlayMode.Background)
            Case 1
                My.Computer.Audio.Play("\\192.168.80.19\PrgUpdate\MesUpdate\Error.wav", AudioPlayMode.Background)
                System.Threading.Thread.Sleep(1000)
        End Select
    End Sub
#End Region

#Region "選擇未處理完工單並帶出相關信息"
    Private Sub CobInBill_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobInBill.SelectedIndexChanged

        'Dim StrCobFloor As String
        'Dim StrCobWhid As String
        'Dim StrCobWhArea As String
        Dim DrGetInf As SqlDataReader
        Dim DtSumQty As DataTable
        '第一箱退出程式
        If G_BlnFirst = True Then Exit Sub

        Me.TxtPartid.Text = ""
        Me.TxtDiscript.Text = ""
        Me.TxtIntime.Text = ""
        CobFloor.SelectedIndex = -1
        Me.CobWhArea.SelectedIndex = -1
        Me.CobWhid.SelectedIndex = -1
        LabCQty.Text = ""
        Me.TxtMoid.Text = ""
        Me.TxtInQty.Text = ""
        Me.LabSumQty.Text = ""
        Me.TxtPalletID.Text = ""
        TxtInQty.Enabled = True
        CobFloor.Enabled = True
        CobWhid.Enabled = True
        CobWhArea.Enabled = True
        TxtDiscript.Enabled = True
        Me.DGridBarCode.DataSource = Nothing
        Try
            DrGetInf = PubClass.GetDataReader("select a.moid,a.inqty,b.partid,a.intime from m_WhInM_t a join m_Mainmo_t b on a.moid=b.moid where a.inwhid='" & CobInBill.Text & "' ")
            If DrGetInf.Read Then
                TxtIntime.Text = Format(DrGetInf.GetDateTime(3), "yyyy/MM/dd HH:mm:ss")
                TxtMoid.Text = DrGetInf("moid").ToString
                TxtPartid.Text = DrGetInf("partid").ToString
                If DrGetInf("inqty").ToString = 0 Then
                    Me.TxtInQty.Text = ""
                Else
                    Me.TxtInQty.Text = DrGetInf("inqty").ToString
                End If
                'DrGetInf.Close()
                'DrGetInf = PubClass.GetDataReader("select top 1 floorid,whid,areaid from m_WhInM_t a join m_Mainmo_t b on a.moid=b.moid where b.partid ='" & TxtPartid.Text & "' ")
                'If DrGetInf.HasRows Then
                '    DrGetInf.Read()
                '    StrCobFloor = DrGetInf("floorid").ToString
                '    StrCobWhid = DrGetInf("whid").ToString
                '    StrCobWhArea = DrGetInf("areaid").ToString
                '    DrGetInf.Close()
                '    CobFloor.Text = StrCobFloor
                '    CobWhid.Text = StrCobWhid
                '    CobWhArea.Text = StrCobWhArea
                'End If
                DrGetInf.Close()
                DtSumQty = PubClass.GetDataTable("select sum(Cartonqty) from m_Carton_t where Cartonid in (select Cartonid from m_WhInD_t where inwhid='" & CobInBill.Text & "') ")
                If DtSumQty.Rows(0).Item(0) Is DBNull.Value Then
                    Me.LabSumQty.Text = 0
                Else
                    Me.LabSumQty.Text = DtSumQty.Rows(0).Item(0)
                End If
                DtSumQty = Nothing
            End If
            DrGetInf.Close()
            DrGetInf = PubClass.GetDataReader("select * from m_WhInM_t where inwhid='" & CobInBill.Text & "'")
            If DrGetInf.Read Then
                Select Case DrGetInf("intype").ToString
                    Case "C"
                        DrGetInf.Close()
                        RbCartonScan.Checked = True
                        GetScanItem()
                        If CInt(Me.LabCQty.Text) = 0 Then
                            RbCartonScan.Enabled = IIf(RbCartonScan.Tag = "YES", True, False)
                            RbPalletScan.Enabled = IIf(RbPalletScan.Tag = "YES", True, False)
                        Else
                            RbCartonScan.Enabled = False
                            RbPalletScan.Enabled = False
                        End If
                    Case "P"
                        DrGetInf.Close()
                        DrGetInf = PubClass.GetDataReader("select palletid from M_PalletM_t  where inwhid='" & CobInBill.Text & "' and palletstatus='N'")
                        If DrGetInf.Read Then
                            TxtPalletID.Text = DrGetInf("palletid").ToString
                            DrGetInf.Close()
                            Me.RbPalletScan.Checked = True
                            Me.TxtPalletID.Enabled = False
                            RbCartonScan.Enabled = False
                            RbPalletScan.Enabled = False
                            TxtCartonid.Enabled = True
                            TxtPalletID.Enabled = False
                            Dim value As Color
                            value = TxtColor.BackColor
                            TxtCartonid.BackColor = value
                            Me.TxtPalletID.BackColor = Color.White
                        Else
                            Me.RbPalletScan.Checked = True
                            Me.TxtPalletID.Enabled = True
                            RbCartonScan.Enabled = False
                            RbPalletScan.Enabled = False
                            TxtCartonid.Enabled = False
                            TxtPalletID.Enabled = True
                            Me.BtPScanEnd.Enabled = False
                            Dim value As Color
                            value = TxtColor.BackColor
                            TxtPalletID.BackColor = value
                            Me.TxtCartonid.BackColor = Color.White
                        End If
                        DrGetInf.Close()
                        GetPScanItem()
                End Select
            End If
            DrGetInf.Close()
            If Me.LabCQty.Text <> "" AndAlso Me.LabCQty.Text <> 0 Then
                TxtCartonid.Focus()
            Else
                TxtInQty.Focus()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmInStorge", "CobInBill_SelectedIndexChanged", "sys")
        End Try

    End Sub
#End Region

#Region "確認入庫"
    Private Sub TsBtEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtEnter.Click

        If DGridBarCode.Rows.Count < 1 Then
            Exit Sub
        End If
        If TxtPalletID.Text <> "" Then
            MessageBox.Show("請先完成棧板包裝掃描!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.BtPScanEnd.Focus()
            Exit Sub
        End If
        If TxtInQty.Text = "" Then
            MessageBox.Show("請先輸入入庫數量!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtInQty.Focus()
            Exit Sub
        End If
        If CobFloor.Text = "" Then
            MessageBox.Show("請選擇[樓層別]!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobFloor.Focus()
            Exit Sub
        End If
        If CobWhArea.Text = "" Then
            MessageBox.Show("請選擇[倉庫儲位]!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobWhArea.Focus()
            Exit Sub
        End If
        If CobWhid.Text = "" Then
            MessageBox.Show("請選擇[倉庫別]!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CobWhArea.Focus()
            Exit Sub
        End If
        If CInt(LabSumQty.Text) <> CInt(TxtInQty.Text) Then
            MessageBox.Show("產品掃描數量與入庫數量不符!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCartonid.Focus()
            Exit Sub
        End If
        '2009/5/4.加入
        If CheckWareHouse(Trim(CobWhid.Text), Trim(TxtPartid.Text)) = False Then
            If MessageBox.Show("當前倉位不是該料號已入庫的倉位，確定入到此倉位中嗎？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                ConfirmInStorge()
                Exit Sub
            Else
                Return
            End If
        End If
        ConfirmInStorge()
    End Sub

#End Region

#Region "check 倉位是否為料號已入庫之倉位"

    Function CheckWareHouse(ByVal StrWhid As String, ByVal StrPartid As String) As Boolean
        Dim Dr As SqlDataReader

        Dr = PubClass.GetDataReader("select 1 from (select a.whid from m_whinm_t a,m_mainmo_t b,m_carton_t c where " & _
                                    "a.moid=b.moid and b.moid=c.moid and c.cartonstatus='I'and b.partid='" & StrPartid & "') a where a.whid= '" & StrWhid & "' ")
        If Dr.Read Then
            Dr.Close()
            Return True
        Else
            Dr.Close()
            Return False
        End If
    End Function

#End Region

#Region "確定入庫數據處理"
    Sub ConfirmInStorge()
        Dim StrInCof As New StringBuilder
        If MessageBox.Show("你確定將入庫單號:" & Me.CobInBill.Text & "入庫嗎？", "信息提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            StrInCof.Append("update m_WhInM_t set inqty='" & Trim(TxtInQty.Text) & "', Floorid='" & Trim(CobFloor.Text) & "',Whid='" & Trim(CobWhid.Text) & "',Areaid='" & Trim(CobWhArea.Text) & "',States='2',Remark='" & Trim(TxtDiscript.Text) & "' where Inwhid='" & Me.CobInBill.Text & "'")
            '********************************************
            'rework by tangxiang   2008/12/24
            'reason : carton表加入“倉別，樓層，儲位” 
            '********************************************
            StrInCof.Append(Environment.NewLine)
            StrInCof.Append("update M_Carton_t set Floorid='" & Trim(CobFloor.Text) & "',Whid='" & Trim(CobWhid.Text) & "',Areaid='" & Trim(CobWhArea.Text) & "' where Cartonid in (select Cartonid from m_WhInD_t where inwhid='" & CobInBill.Text & "') ")
            PubClass.ExecSql(StrInCof.ToString)

            StrInCof.Remove(0, StrInCof.ToString.Length)
            CobInBill.Items.Remove(CobInBill.Text)
            CobInBill.SelectedIndex = -1
            Me.DGridBarCode.DataSource = Nothing
            Me.TxtPartid.Text = ""
            Me.TxtDiscript.Text = ""
            Me.TxtIntime.Text = ""
            CobFloor.SelectedIndex = -1
            Me.CobWhArea.SelectedIndex = -1
            Me.CobWhid.SelectedIndex = -1
            LabCQty.Text = ""
            Me.TxtMoid.Text = ""
            Me.TxtInQty.Text = ""
            Me.LabSumQty.Text = ""
            TxtInQty.Enabled = False
            CobFloor.Enabled = False
            CobWhid.Enabled = False
            CobWhArea.Enabled = False
            TxtDiscript.Enabled = False
            MessageBox.Show("入庫成功!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
#End Region

#Region "廢除掃描記錄"
    Private Sub TsBtDrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtDrop.Click
        If Me.CobInBill.Text = "" Then Exit Sub
        Dim StrInDrop As New StringBuilder
        If MessageBox.Show("你確定捨棄入庫單號:" & Me.CobInBill.Text & "？", "信息提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            '**********************************************************
            'rework Time:      2008/11/20 
            'rework by:        tangxiang
            'Reason :          M_Carton_t表增加 updatetime 和updateuser
            '**********************************************************
            StrInDrop.Append("update M_Carton_t set cartonstatus='Y',updatetime=getdate(),updateuser='" & (SysMessageClass.UseId) & "' where cartonid in (select cartonid from m_WhInD_t where inwhid='" & Me.CobInBill.Text & "' )")
            StrInDrop.Append(Environment.NewLine)
            StrInDrop.Append(" update M_Carton_t set cartonstatus='O',updatetime=getdate(),updateuser='" & (SysMessageClass.UseId) & "' where cartonid in (select cartonid from m_WhInD_t where inwhid='" & Me.CobInBill.Text & "'")
            StrInDrop.Append(" and cartonid in  (SELECT c.cartonid FROM m_WhOutD_t a,WS_worked_t b,m_carton_t c where a.OUTWHID = b.keyid And a.cartonid = c.cartonid )) ")
            StrInDrop.Append(Environment.NewLine)
            StrInDrop.Append("update m_SnSBarCode_t set usey='Y' where sbarcode in(select palletid from M_PalletM_t where inwhid='" & Me.CobInBill.Text & "')")
            StrInDrop.Append(Environment.NewLine)
            StrInDrop.Append("delete from m_PalletCarton_t where palletid in(select palletid from M_PalletM_t where inwhid='" & Me.CobInBill.Text & "')")
            StrInDrop.Append(Environment.NewLine)
            StrInDrop.Append("delete from M_PalletM_t where Inwhid='" & Me.CobInBill.Text & "'")
            StrInDrop.Append(Environment.NewLine)
            StrInDrop.Append("delete from m_WhInM_t where Inwhid='" & Me.CobInBill.Text & "'")
            StrInDrop.Append(Environment.NewLine)
            StrInDrop.Append("delete from m_WhInD_t  where Inwhid='" & Me.CobInBill.Text & "'")
            PubClass.ExecSql(StrInDrop.ToString)
            StrInDrop.Remove(0, StrInDrop.ToString.Length)
            CobInBill.Items.Remove(CobInBill.Text)
            CobInBill.SelectedIndex = -1
            Me.DGridBarCode.DataSource = Nothing
            Me.TxtPartid.Text = ""
            Me.TxtDiscript.Text = ""
            Me.TxtIntime.Text = ""
            CobFloor.SelectedIndex = -1
            Me.CobWhArea.SelectedIndex = -1
            Me.CobWhid.SelectedIndex = -1
            LabCQty.Text = ""
            Me.TxtMoid.Text = ""
            Me.TxtInQty.Text = ""
            Me.LabSumQty.Text = ""
            TxtInQty.Enabled = False
            CobFloor.Enabled = False
            CobWhid.Enabled = False
            CobWhArea.Enabled = False
            TxtDiscript.Enabled = False
            Dim value As Color
            value = TxtColor.BackColor
            RbCartonScan.Checked = True
            TxtCartonid.Enabled = True
            TxtPalletID.Enabled = False
            BtPScanEnd.Enabled = False
            TxtCartonid.BackColor = value
            Me.TxtPalletID.BackColor = Color.White
            TxtPalletID.Text = ""
            Me.TxtCartonid.Focus()

        End If
    End Sub

#End Region

#Region "獲取單據掃描記錄"
    Private Sub GetScanItem()

        Dim ChColsText As String
        Dim DtCtScan As DataTable
        Try
            DtCtScan = PubClass.GetDataTable("select a.Inwhid,a.Cartonid,b.cartonqty,a.Userid,convert(varchar(20),a.Intime,20) from m_WhInD_t a left join m_Carton_t b on a.cartonid=b.cartonid where a.inwhid='" & CobInBill.Text & "' order by a.Intime desc")
            Me.DGridBarCode.DataSource = DtCtScan
            Me.LabCQty.Text = DtCtScan.Rows.Count
            If LCase(SysMessageClass.Language) = "english" Then
                ChColsText = ""
            Else
                ChColsText = "單據編號|裝箱序號|包裝數量|掃描人員|掃描時間"
            End If
            Dim colNames As String() = ChColsText.Split("|")
            Dim i As Integer
            For i = 0 To DGridBarCode.Columns.Count - 1
                DGridBarCode.Columns(i).HeaderText = colNames(i)
                DGridBarCode.Columns(i).Name = colNames(i)
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmInStorge", "GetScanItem", "sys")
        End Try


    End Sub
    Private Sub GetPScanItem()

        Dim ChColsText As String
        Dim DtCtScan As DataTable
        Try
            DtCtScan = PubClass.GetDataTable("select a.Inwhid,c.palletid,a.Cartonid,b.cartonqty,a.Userid,convert(varchar(20),a.Intime,20) from m_WhInD_t a left join m_Carton_t b on a.cartonid=b.cartonid join M_PalletCarton_t c on a.cartonid=c.cartonid where a.inwhid='" & CobInBill.Text & "' order by a.Intime desc")
            Me.DGridBarCode.DataSource = DtCtScan
            Me.LabCQty.Text = DtCtScan.Rows.Count
            If LCase(SysMessageClass.Language) = "english" Then
                ChColsText = ""
            Else
                ChColsText = "單據編號|棧板序號|裝箱序號|包裝數量|掃描人員|掃描時間"
            End If
            Dim colNames As String() = ChColsText.Split("|")
            Dim i As Integer
            For i = 0 To DGridBarCode.Columns.Count - 1
                DGridBarCode.Columns(i).HeaderText = colNames(i)
                DGridBarCode.Columns(i).Name = colNames(i)
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmInStorge", "GetScanItem", "sys")
        End Try


    End Sub
#End Region

#Region "填充ComBox資料"
    Private Sub FillCobType(ByVal CboName As ComboBox, ByVal SqlStr As String)

        Dim CboDr As SqlDataReader
        CboName.Items.Clear()
        If CboName.Name = "CobWhArea" Then
            CboName.Items.Add("貨架")
        End If
        CboDr = PubClass.GetDataReader(SqlStr)
        If CboDr.HasRows Then
            While CboDr.Read
                CboName.Items.Add(CboDr.GetString(0))
            End While
        End If
        CboDr.Close()

    End Sub
#End Region

    Private Sub BtPScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim StrScan As New StringBuilder
        Dim DtPubUse As DataTable
        Dim DrPubUse As SqlDataReader
        Dim IntQty As Int32 = 0
        Dim StrCobFloor As String
        Dim StrCobWhid As String
        Dim StrCobWhArea As String
        Dim StrCarton As String  '箱裝數量

        StrScan.Remove(0, StrScan.ToString.Length)
        If CobInBill.Text = "" Then
            MessageBox.Show("請先建立入庫單!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If TxtInQty.Text = "" Then
            MessageBox.Show("請先輸入入庫數量!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Trim(Me.TxtPalletID.Text) = "" Then
            MessageBox.Show("棧板序號不能為空!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            DtPubUse = PubClass.GetDataTable("select distinct(b.cartonstatus) from m_PalletCarton_t a join m_Carton_t b on a.cartonid=b.cartonid where Palletid='" & Trim(Me.TxtPalletID.Text) & "'")
            If DtPubUse.Rows.Count <> 1 Then
                MessageBox.Show("該棧板箱號狀態不一或無法識別此棧板，只能單箱入庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtPalletID.Clear()
                DtPubUse = Nothing
                Exit Sub
            Else
                Select Case DtPubUse.Rows(0).Item(0)
                    Case "N"
                        MessageBox.Show("該棧板箱號未裝滿,不能入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtCartonid.Clear()
                        Exit Sub
                    Case "I"
                        MessageBox.Show("該棧板箱號已入庫,不能重復入庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtPalletID.Clear()
                        Exit Sub
                    Case "S"
                        MessageBox.Show("該棧板箱號均已拆箱,不能入庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtPalletID.Clear()
                        Exit Sub
                    Case "O"
                        MessageBox.Show("該棧板箱號已出庫,不能再入庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtPalletID.Clear()
                        Exit Sub
                    Case "E"
                        MessageBox.Show("該棧板箱號均已拆空,不能入庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtPalletID.Clear()
                        Exit Sub
                    Case "R"
                        MessageBox.Show("該棧板箱號已出庫重工,不能再入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtPalletID.Clear()
                        Exit Sub
                    Case "Q"
                        MessageBox.Show("該棧板箱號已經FQC抽驗判退,不能入庫!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtPalletID.Clear()
                        Exit Sub
                    Case "Y"
                        DtPubUse = Nothing
                        StrScan.Append("select sum(cartonqty) as 'Cartonqty' from m_Carton_t where cartonid in (select  cartonid from m_PalletCarton_t where Palletid='" & Trim(Me.TxtPalletID.Text) & "')")
                        StrScan.Append(Environment.NewLine)
                        StrScan.Append("select b.partid,a.moid,a.Cartonqty from m_Carton_t a join m_Mainmo_t b on a.moid=b.moid where a.cartonid=(select top 1 cartonid from m_PalletCarton_t where Palletid='" & Trim(Me.TxtPalletID.Text) & "')")
                        DrPubUse = PubClass.GetDataReader(StrScan.ToString)
                        StrScan.Remove(0, StrScan.ToString.Length)

                        If DrPubUse.Read() Then
                            StrCarton = DrPubUse("Cartonqty").ToString()  '(2008/11/20 加入)

                            If CInt(TxtInQty.Text) < CInt(DrPubUse("Cartonqty").ToString) + CInt(Me.LabSumQty.Text) Then
                                MessageBox.Show("產品總數大於入庫數量!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                TxtCartonid.Clear()
                                DrPubUse.Close()
                                Exit Sub
                            End If

                            LabSumQty.Text = CInt(LabSumQty.Text) + CInt(DrPubUse.GetInt32(0))

                            DrPubUse.NextResult()
                            If DrPubUse.Read() Then
                                If TxtMoid.Text = "" Then
                                    Dim FrmInformation As New FrmInfShow
                                    Dim ClassInf As New InfClass
                                    ClassInf.StrInf = "該棧板所屬工單為： " & DrPubUse("moid").ToString & vbCrLf & "該棧板所屬料號為： " & DrPubUse("partid").ToString & vbCrLf & "該棧板箱號包裝數量為： " & DrPubUse("Cartonqty").ToString
                                    ClassInf.StrColor = Color.Green
                                    ClassInf.StrQInf = "你確定掃描這批產品嗎?"
                                    ClassInf.StrQColor = Color.Red
                                    PlaySimpleSound(3)
                                    FrmInformation.ShowDialog()
                                    If ClassInf.ChoseY = True Then
                                        TxtMoid.Text = DrPubUse("moid").ToString
                                        TxtPartid.Text = DrPubUse("partid").ToString
                                        'Me.LabSumQty.Text = DrPubUse("Cartonqty").ToString
                                        DrPubUse.Close()
                                        DrPubUse = PubClass.GetDataReader("select top 1 a.floorid,a.whid,a.areaid ,a.intime from dbo.m_WhInM_t a join dbo.m_Mainmo_t b on a.moid=b.moid where b.partid='" & TxtPartid.Text & "' order by a.intime desc")
                                        If DrPubUse.Read Then
                                            StrCobFloor = DrPubUse("floorid").ToString
                                            StrCobWhid = DrPubUse("whid").ToString
                                            StrCobWhArea = DrPubUse("areaid").ToString
                                            DrPubUse.Close()
                                            CobFloor.Text = StrCobFloor
                                            CobWhid.Text = StrCobWhid
                                            CobWhArea.Text = StrCobWhArea
                                        End If

                                        StrScan.Append("update m_WhInM_t set Moid='" & Trim(TxtMoid.Text) & "' where inwhid='" & Trim(CobInBill.Text) & "'")
                                        StrScan.Append(Environment.NewLine)
                                        ClassInf.ChoseY = False
                                    Else
                                        TxtPalletID.Clear()
                                        ClassInf.ChoseY = False
                                        Exit Sub
                                    End If
                                Else
                                    If Trim(Me.TxtMoid.Text) <> Trim(DrPubUse("moid").ToString) Then
                                        MessageBox.Show("該棧板工單不屬當前工單，不得入庫!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        TxtPalletID.Clear()
                                        Exit Sub
                                    End If
                                End If
                                DrPubUse.Close()
                                '*********************************************************
                                'rework Time:      2008/11/20 
                                'rework by:        tangxiang
                                'Reason :          M_WHInD_t表增加CartonInQty(入庫數量)
                                '*********************************************************
                                'StrScan.Append("insert into m_WhInD_t select '" & Trim(CobInBill.Text) & "',cartonid,'" & (SysMessageClass.UseId) & "','" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "' from m_PalletCarton_t where Palletid='" & Trim(Me.TxtPalletID.Text) & "'")
                                StrScan.Append("insert into m_WhInD_t select '" & Trim(CobInBill.Text) & "',cartonid,'" & (SysMessageClass.UseId) & "','" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "',CartonQty from M_Carton_t where cartonid in(select cartonid from m_PalletCarton_t where Palletid='" & Trim(Me.TxtPalletID.Text) & "' and usey='Y')")
                                StrScan.Append(Environment.NewLine)
                                '**********************************************************
                                'rework Time:      2008/11/20 
                                'rework by:        tangxiang
                                'Reason :          M_Carton_t表增加 updatetime 和updateuser
                                '**********************************************************
                                'StrScan.Append("update M_Carton_t set CartonStatus='I',intime=getdate(),userid='" & (SysMessageClass.UseId) & "' where Cartonid in(select cartonid from m_PalletCarton_t where Palletid='" & Trim(Me.TxtPalletID.Text) & "')")
                                StrScan.Append("update M_Carton_t set CartonStatus='I',updatetime=getdate(),updateuser='" & (SysMessageClass.UseId) & "' where Cartonid in(select cartonid from m_PalletCarton_t where Palletid='" & Trim(Me.TxtPalletID.Text) & "')")
                                PubClass.ExecSql(StrScan.ToString)
                                StrScan.Remove(0, StrScan.ToString.Length)
                                GetScanItem()   ''獲取單據掃描記錄
                                TxtPalletID.Clear()
                                PlaySimpleSound(0)
                            End If
                        End If
                    Case Else
                        MessageBox.Show("無法識別此棧板箱號!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtCartonid.Clear()
                        Exit Sub
                End Select
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmInStorge", "BtPScan_Click", "sys")
        Finally
            DtPubUse = Nothing
        End Try

    End Sub

    Private Sub TsBnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBnBack.Click
        PubClass = Nothing
        Me.Close()
    End Sub

    Private Sub TxtInQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtInQty.KeyPress
        If Char.IsDigit(e.KeyChar) OrElse e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            TxtCartonid.Focus()
        End If
    End Sub

    Private Sub CobFloor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobFloor.SelectedIndexChanged
        If Me.CobFloor.Text = "" Then Exit Sub
        FillCobType(CobWhid, "select whid from m_Wh_t where floorid='" & Trim(CobFloor.Text) & "' and usey='Y'")
        FillCobType(CobWhArea, "select Areaid from m_WhArea_t where Floorid='" & Trim(CobFloor.Text) & "' and usey='Y' ")
    End Sub

#Region "獲取上次輸入的倉庫儲位信息"

    Private Sub LoadWhAddInformation()

        Dim xmldoc As New XmlDocument
        Try
            ''xmldoc.Load(My.Application.Info.DirectoryPath & "\WhAdd.xml") '讀取XML中的上次輸入的倉庫儲位信息
            xmldoc.Load(Application.StartupPath & "\WhAdd.xml") '讀取XML中的上次輸入的倉庫儲位信息

            Dim nodeList As XmlNodeList = xmldoc.SelectSingleNode("filelist").ChildNodes
            For Each xn As XmlNode In nodeList
                If LCase(xn.Name) = "floor" Then
                    CobFloor.Text = xn.InnerText
                End If
                If LCase(xn.Name) = "whid" Then
                    CobWhid.Text = xn.InnerText
                End If
                If LCase(xn.Name) = "wharea" Then
                    Me.CobWhArea.Text = xn.InnerText
                End If
                If LCase(xn.Name) = "remark" Then
                    TxtDiscript.Text = xn.InnerText
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "不存在XML文件", "提示信息", MessageBoxButtons.OK)
            Exit Sub
        End Try

    End Sub

#End Region

#Region "保存上次輸入的倉庫儲位信息"

    Private Sub MoffiyLogWhAdd()

        Dim XmlDoc As New XmlDocument
        Try
            '' XmlDoc.Load(My.Application.Info.DirectoryPath & "\WhAdd.xml")  ''打開XML文件
            XmlDoc.Load(Application.StartupPath & "\WhAdd.xml") '讀取XML中的上次輸入的倉庫儲位信息
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "不存在XML文件", "提示信息", MessageBoxButtons.OK)
        End Try
        File.SetAttributes(Application.StartupPath & "\WhAdd.xml", FileAttributes.Normal) ''設置XML文件為可讀寫

        Dim nodeList As XmlNodeList = XmlDoc.SelectSingleNode("filelist").ChildNodes
        For Each xn As XmlNode In nodeList
            If LCase(xn.Name) = "floor" Then
                xn.InnerText = CobFloor.Text
            End If
            If LCase(xn.Name) = "whid" Then
                xn.InnerText = CobWhid.Text
            End If
            If LCase(xn.Name) = "wharea" Then
                xn.InnerText = Me.CobWhArea.Text
            End If
            If LCase(xn.Name) = "remark" Then
                xn.InnerText = TxtDiscript.Text
                Exit For
            End If
        Next

        XmlDoc.Save(Application.StartupPath & "\WhAdd.xml")

    End Sub

#End Region

    'Private Sub TxtCartonid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCartonid.KeyDown
    '    If Trim(TxtCartonid.Text) = "" Then
    '        G_time = Now
    '    End If
    'End Sub

    '委外數據導入
    Private Sub TsBtPutIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtPutIn.Click
        Try

            ' ''************************************************
            ' ''--------------------解壓縮----------------------
            ' ''************************************************
            ' ''解壓縮exe的系統路徑
            ''Dim ServerDir As String = "\\pc-1636\WinRAR"
            ' ''.rar文件路徑
            ''Dim strFileName() As String = Directory.GetFiles("\\pc-1636\DATA\OtherDataRAR")

            ' ''如果不存在數據文件夾，則新建
            ''If Directory.Exists("\\pc-1636\DATA\OtherDataXML") = False Then
            ''    Directory.CreateDirectory("\\pc-1636\DATA\OtherDataXML")
            ''End If

            ''For Inti As Integer = 0 To strFileName.Length - 1
            ''    '定義線程
            ''    Dim Process1 As New System.Diagnostics.Process
            ''    'rar.exe的路徑
            ''    Process1.StartInfo.FileName = (ServerDir + "\Rar.exe")
            ''    '啟動程序的引數集
            ''    Process1.StartInfo.Arguments = "x -t -o+ -p- " + " " + strFileName(Inti) + " " + "\\pc-1636\DATA\OtherDataXML"
            ''    '設置隱藏dos窗口
            ''    Process1.StartInfo.UseShellExecute = False
            ''    Process1.StartInfo.RedirectStandardInput = True
            ''    Process1.StartInfo.RedirectStandardOutput = True
            ''    Process1.StartInfo.CreateNoWindow = True
            ''    '開始解壓
            ''    Process1.Start()
            ''    Process1.WaitForExit()
            ''    Process1.Close()
            ''    Dim XmlFileName() As String = Directory.GetFiles("\\pc-1636\DATA\OtherDataXML")
            ''    Dim IntTemp As Integer = 0
            ''    For Each str As String In XmlFileName
            ''        If Path.GetFileNameWithoutExtension(str) = Path.GetFileNameWithoutExtension(strFileName(Inti)) Then
            ''            IntTemp = 1
            ''            Exit For
            ''        End If
            ''    Next
            ''    If IntTemp <> 1 Then
            ''        MsgBox("解壓縮失敗！")
            ''        Exit Sub
            ''    End If
            ''    '將rar轉移
            ''    Directory.Move(strFileName(Inti), "\\pc-1636\DATA\SpareData\RAR\" + Path.GetFileNameWithoutExtension(strFileName(Inti)) + ".rar")

            ''Next

            '************************************************
            '-------------------數據導入DB-------------------
            '************************************************
            Dim StrXmlPath As String
            Dim XmlName() As String = Directory.GetFiles("\\pc-1636\DATA\OtherDataXML")
            For Inti As Integer = 0 To XmlName.Length - 1
                StrXmlPath = XmlName(Inti)
                '導入數據
                PubClass.ExecSql("exec sp_GetDataFromXML_PPID '" & StrXmlPath & "'")
                '將xml轉移
                Directory.Move(StrXmlPath, "\\pc-1636\DATA\SpareXML\" + Path.GetFileNameWithoutExtension(StrXmlPath) + ".xml")
            Next
            MsgBox("導入成功！")

        Catch ex As Exception
            MsgBox("導入失敗！")
            SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmInStorge", "TsBtPutIn_Click", "sys")
        End Try
    End Sub


End Class


