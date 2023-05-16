Imports System.Data.SqlClient
Imports MainFrame
Public Class FrmOutWH2
    Private ClassInf As New InfClass
    Public g_CustID As String '客戶代碼 
    Private g_Rights As String '權限
    Private g_KDShip As Boolean = False  '正常出貨/其它出貨(預設為正常出貨)
    Private g_strTemp As String '掃描棧板之前的掃描箱數，便於add數據到DG ---2009/5/6
    Dim Pubclass As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim G_time As DateTime  '用於保存當前輸入時間---2009/7/23
    Dim StrPart As String
    Dim IntQty As Integer = 0
    Dim BoolASN As Boolean = False '檢測產品是否需要ASN檢測 2011/08/03
    Dim CustPart As String = ""    '記錄客戶料號
    Dim PartLimitTime As Integer = 365 '記錄料號的有效期
    Dim CheckASNResult As Boolean = False '判讀包裝箱條碼和ASN的結果
    '修改帶出Invoice單號信息

    Private Sub FrmOutWH2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Init()   '初始化變量
        DoRights() '權限處理
        'LoadInvoiceNo() '加載Invoice單到Combox中
    End Sub

    '初始化變量
    Private Sub Init()
        TxtCust.Text = ""
        TxtAddress.Text = ""
        TxtTranType.Text = ""
        TxtCartonid.Text = ""
        LabShipType.Text = ""
        LabelState.Text = ""
        TxtCartonid.BackColor = Color.White
        TxtPalletID.Text = ""
        TxtPalletID.BackColor = Color.White
        LabCartCoun.Text = ""
        PlScan.Enabled = False
        DGShipList.Rows.Clear()
        DGScanList.Rows.Clear()
    End Sub

    Private Sub CobInvoice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobInvoice.TextChanged
        Init()
    End Sub

    '權限處理
    Private Sub DoRights()
        Dim strSql As String
        Dim Rs As SqlDataReader

        strSql = " select * from m_userright_t where tkey='m0820a_' and userid='" & SysCheckData.SysMessageClass.UseId & "'" _
                  & vbNewLine & "select * from m_userright_t where tkey='m0800_' and userid='" & SysCheckData.SysMessageClass.UseId & "'"
        Rs = Pubclass.GetDataReader(strSql)
        If Rs.Read() Then
            BtOtherOut.Enabled = True
        End If
        Rs.NextResult()
        If Rs.Read() Then
            RbCartonScan.Enabled = True
            RbPalletScan.Enabled = True
        End If
        Rs.Close()
        g_Rights = ""
        strSql = " select a.ttext, a.buttonid from m_logtree_t a join m_userright_t b on a.tkey=b.tkey where a.tparent='F0_' and userid='" & SysCheckData.SysMessageClass.UseId & "'"
        Rs = Pubclass.GetDataReader(strSql)
        While Rs.Read
            g_Rights = g_Rights & "," & "'" & Rs(1).ToString & "'"
        End While
        g_Rights = Mid(g_Rights, 2)
        If g_Rights = "" Then g_Rights = "''"
        Rs.Close()
    End Sub

    '加載符合條件Invoice單到Combox中
    Private Sub LoadInvoiceNo()
        Dim StrSql As String
        Dim Rs As SqlDataReader

        CobInvoice.Items.Clear()
        ''Invoice 正式版
        'StrSql = " select Invoice from m_Invoicem_t where Stateid='3' and Updatetime>getdate()-30 and Factoryid in (" & g_Rights & ") union " & _
        '         " select InvoiceJob from m_InvoiceS_t where InvoiceJob like'XVZX%'and Intime>getdate()-30 and Factoryid in (" & g_Rights & ")"
        ''Invoice 測試版
        'StrSql = "select Invoice from m_Invoicem_t where Stateid='3' and Updatetime>getdate()-30 union " & _
        '         "select InvoiceJob from m_InvoiceS_t where InvoiceJob like'XVZX%'and Intime>getdate()-30 "
        '當前正式版
        StrSql = " select distinct  a.invoice  as invoice from m_shipm_t a, m_shipd_t b " _
               & " where a.invoice=b.invoice and (b.states='E' or b.states='1') " _
               & " and b.eintime>getdate()-3 and a.factory in (" & g_Rights & ") and a.usey='Y' " _
               & " and (a.flag<>'2' or a.flag is null) union select invoice  as invoice from m_shipdtotal_t " _
               & " where states in ('0','1') and intime>getdate()-3 and factoryid in (" & g_Rights & ") and usey='Y' " _
               & "  order by invoice "


        Rs = Pubclass.GetDataReader(StrSql)
        If Rs.HasRows Then
            While Rs.Read()
                If Rs(0).ToString() <> "" Then
                    CobInvoice.Items.Add(Rs(0).ToString())
                End If
            End While
        Else
            Rs.Close()
            Exit Sub
        End If

        Rs.Close()

    End Sub

    '加載“出貨”明細信息
    Private Sub LoadShipInfoDetail(ByVal StrInvoice As String)
        Dim Strsql As String
        Dim Rs As SqlDataReader
        Dim IntScanQty As Integer '已掃描數量
        Dim StrStatus As String '狀態
        Dim IntSel As Integer '單選框標識
        Dim i As Integer '用於for 循環

        IntSel = 0
        StrStatus = ""
        CobInvoice.Enabled = True
        DGShipList.Rows.Clear()
        ''Invoice 版
        'Strsql = "select a.Partid,a.Shipqty,a.Outwhid,a.Qty,a.Stateid,b.InvoiceJob from m_InvoiceS_t a left join " & _
        '         "m_InvoiceM_t b on a.InvoiceJob=b.InvoiceJob where b.Invoice='" & StrInvoice & "'and b.Stateid='3' " & _
        '         "union select Partid,Shipqty,Outwhid,Qty,Stateid,InvoiceJob from m_InvoiceS_t where InvoiceJob='" & StrInvoice & "'"
        '當前版

        Strsql = "select distinct a.partid,a.Eqty,a.outwhid,a.Qty,a.States,isnull(c.remark,'') from m_shipdtotal_t a left join m_shipm_t b on " & _
                 "a.Invoice=b.Invoice left join m_whoutm_t c on c.orderseq=a.Invoice where a.Invoice='" & StrInvoice & "' "


        Rs = Pubclass.GetDataReader(Strsql)
        If Rs.HasRows Then
            While Rs.Read
                '已掃描數量
                If Trim(Rs(3).ToString) = "" Then
                    IntScanQty = 0
                Else
                    IntScanQty = Trim(Rs(3).ToString)
                End If
                '狀態
                ''Invoice版
                'If Rs(4).ToString = "0" Then
                '    StrStatus = "待出庫"
                '當前版
                If Rs(4).ToString = "0" Or Rs(4).ToString = "" Then
                    StrStatus = "待出庫"
                ElseIf Rs(4).ToString = "1" Then
                    StrStatus = "掃描中"
                ElseIf Rs(4).ToString = "2" Then
                    StrStatus = "掃描完成"
                ElseIf Rs(4).ToString = "3" Then
                    StrStatus = "需調整"
                End If
                txtRemark.Text = Rs(5).ToString
                If IntScanQty = 0 And Rs(1).ToString = 0 Then StrStatus = "掃描完成"
                '加載數據項
                ''Invoice 版
                'DGShipList.Rows.Add(IntSel, Rs(0).ToString, Rs(1).ToString, IntScanQty, StrStatus, Rs(2).ToString, Rs(5).ToString)
                '當前版
                DGShipList.Rows.Add(IntSel, Rs(0).ToString, Rs(1).ToString, IntScanQty, StrStatus, Rs(2).ToString)
            End While
        Else
            Rs.Close()
            Exit Sub
        End If
        Rs.Close()

        For i = 0 To DGShipList.Rows.Count - 1
            If DGShipList.Item(4, i).Value.ToString = "掃描完成" Then
                DGShipList.Item(4, i).Style.ForeColor = Color.Red
                DGShipList.Item(4, i).Style.SelectionForeColor = Color.Red
            ElseIf DGShipList.Item(4, i).Value.ToString = "需調整" Then
                DGShipList.Item(4, i).Style.ForeColor = Color.Blue
                DGShipList.Item(4, i).Style.SelectionForeColor = Color.Blue
            End If
            '判斷該料號是否需要掃描
            Rs = Pubclass.GetDataReader("select 1 from m_PartPack_t where partid='" & Trim(DGShipList.Item(1, i).Value.ToString) & "'")
            If Rs.Read Then
                DGShipList.Item(7, i).Value = "需要掃描"
            Else
                DGShipList.Item(7, i).Value = "不需要掃描"
            End If
            Rs.Close()
        Next

    End Sub

    '加載“已掃描”明細信息
    Private Sub LoadScanList(ByVal StrWhID As String)
        Dim intCount As Integer
        Dim StrSql As String
        Dim Rs As SqlDataReader

        LabCartCoun.Text = 0
        DGScanList.Rows.Clear()
        If StrWhID = "" Then Exit Sub

        StrSql = " select a.partid, c.palletid, b.cartonid, d.cartonqty, b.userid, substring(convert(varchar,b.intime,120),1,16) " _
               & " from m_whoutm_t a join m_whoutd_t b on a.outwhid=b.outwhid " _
               & " left outer join m_palletcarton_t c on b.cartonid=c.cartonid " _
               & " join m_carton_t d on b.cartonid=d.cartonid where a.outwhid='" & StrWhID & "'"

        intCount = 0
        Rs = Pubclass.GetDataReader(StrSql)
        If Rs.HasRows Then
            While Rs.Read
                intCount = intCount + 1
                DGScanList.Rows.Add(intCount, Rs(0).ToString, Rs(1).ToString, Rs(2).ToString, Rs(3).ToString, _
                                    Rs(4).ToString, Rs(5).ToString)
            End While
        Else
            Rs.Close()
            Exit Sub
        End If
        Rs.Close()
        LabCartCoun.Text = intCount.ToString
        If DGScanList.Rows.Count > 0 Then
            DGScanList.Rows(DGScanList.Rows.Count - 1).Selected = True
            DGScanList.CurrentCell = DGScanList(0, DGScanList.Rows.Count - 1)
            DGScanList.FirstDisplayedScrollingRowIndex = DGScanList.RowCount - 1
        End If

    End Sub

    '下拉框的值改變時加載出貨信息
    Private Sub CobInvoice_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobInvoice.SelectedValueChanged, CobInvoice.SelectedIndexChanged
        LoadShipInfo()
    End Sub

    '下拉框按"Enter"加載出貨信息
    Private Sub CobInvoice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobInvoice.KeyPress
        If e.KeyChar = Chr(13) Then
            LoadShipInfo()
        End If
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    '加載出貨信息--客戶名，客戶地址等
    Private Sub LoadShipInfo()
        If Trim(CobInvoice.Text) = "" Then Exit Sub

        '帶出客戶地址
        Dim Strsql As String
        Dim Rs As SqlDataReader
        '正常出貨
        ''Invoice 版
        'Strsql = "select a.Cusid,a.Receaddr,b.SortName from m_Invoicem_t a left join m_Sortset_t b on a.Trantype=" & _
        '         "b.SortnameEn and b.SortType='IVO-T' where a.Invoice='" & Trim(CobInvoice.Text) & "'and a.Stateid='3'"
        '當前版
        Strsql = "select b.cusid,b.cusname, b.saddress, c.saddress,a.stateid,a.outtype,case isnull(a.asny,'') when '' then isnull(b.asny,'') else isnull(a.asny,'') end asny " _
               & " from m_shipm_t a left join m_custinfo_t b on a.cusid=b.cusid left outer join " _
               & " m_custother_t c on a.cusid=c.cusid where a.invoice='" & Trim(CobInvoice.Text) & "' "
        Rs = Pubclass.GetDataReader(Strsql)
        If Rs.HasRows Then
            While Rs.Read
                g_CustID = Rs(0).ToString
                TxtCust.Text = Rs(1).ToString
                TxtAddress.Text = Rs(2).ToString
                If TxtAddress.Text = "" Then
                    TxtAddress.Text = Rs(3).ToString
                End If
                If Rs(4).ToString = "1" Then
                    LabelState.Text = "未確認"
                ElseIf Rs(4).ToString = "2" Then
                    LabelState.Text = "已確認出庫"
                End If
                If Rs(5).ToString = "O" Then
                    LabShipType.Text = "O-正常出貨"
                ElseIf Rs(5).ToString = "I" Then
                    LabShipType.Text = "I-內部領料"
                ElseIf Rs(5).ToString = "S" Then
                    LabShipType.Text = "S-樣品出貨"
                ElseIf Rs(5).ToString = "T" Then
                    LabShipType.Text = "T-其它出貨"
                End If

                'rework by anday xu 2011/08/19
                '==================================================================
                '判斷Invoice單號是否要ASN檢測,只針對正常出貨
                If Rs(6).ToString.Trim = "Y" And Rs(5).ToString = "O" Then
                    BoolASN = True
                    Me.TxtASN.Visible = True
                    Me.TxtASN.BackColor = Color.White
                    Me.ToolCancelAsn.Text = "取消ASN檢測(&C)"
                Else
                    BoolASN = False
                    Me.TxtASN.Visible = False
                    Me.ToolCancelAsn.Text = "啟用ASN檢測(&C)"
                End If
                '==================================================================
            End While
        Else
            Rs.Close()
        End If
        Rs.Close()




        '當前版本------加載Invoice時改變“料號”狀態
        Try
            Pubclass.ExecSql("update m_shipdtotal_t set states= case when eqty>qty then '1' when eqty=qty then '2' " & _
                             "when eqty<qty then '3' end where Invoice='" & Trim(CobInvoice.Text) & "'and usey='Y'")
        Catch ex As Exception
            SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH2", "PartStateChangedErr", "sys")
            MessageBox.Show("資料變更有誤，請聯系系統管理員！", "錯誤提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        PlScan.Enabled = False
        TxtCartonid.BackColor = Color.White
        TxtPalletID.Text = ""
        TxtPalletID.BackColor = Color.White
        LabCartCoun.Text = ""
        DGShipList.Rows.Clear()
        DGScanList.Rows.Clear()
        '加載出貨明細信息
        LoadShipInfoDetail(Trim(CobInvoice.Text))
    End Sub

    '點擊單筆出貨記錄時，顯示掃描明細
    Private Sub DGShipList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGShipList.CellContentClick
        Dim StrStatus As String = "" '狀態
        'Dim StrScanY As Boolean '是否需要掃描
        Dim i As Integer '用於for循環
        If DGShipList.Rows.Count = 0 Then Exit Sub
        If DGShipList.CurrentCell.RowIndex < 0 Then Exit Sub
        If DGShipList.CurrentCell.ColumnIndex <> 0 Then Exit Sub
        ''DGShipList.EndEdit()
        StrStatus = DGShipList.Item(4, DGShipList.CurrentCell.RowIndex).Value.ToString
        '點擊單選框時, 反顯
        For i = 0 To DGShipList.Rows.Count - 1
            If DGShipList.Item(1, i).Value = DGShipList.Item(1, DGShipList.CurrentCell.RowIndex).Value Then
                If DGShipList.Item(0, DGShipList.CurrentCell.RowIndex).Value = 0 Then
                    DGShipList.Item(0, i).Value = 1
                Else
                    DGShipList.Item(0, i).Value = 0
                End If
            Else
                DGShipList.Item(0, i).Value = 0
            End If
        Next i
        DGShipList.EndEdit()

        If DGShipList.Item(7, DGShipList.CurrentCell.RowIndex).Value.ToString = "不需要掃描" Then
            MessageBox.Show("該料號不需要掃描！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DGShipList.Item(0, DGShipList.CurrentCell.RowIndex).Value = 0
            CobInvoice.Enabled = True
        End If

        If StrStatus = "需調整" Or StrStatus = "掃描完成" Then
            If LabelState.Text = "已確認出庫" Then
                MessageBox.Show("該料號已確認出庫,請先駁回該Invoice單", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGShipList.Item(0, DGShipList.CurrentCell.RowIndex).Value = 0
                CobInvoice.Enabled = True
            End If
        ElseIf StrStatus = "掃描中" Then
            If LabelState.Text = "已確認出庫" Then
                MessageBox.Show("該料號已確認出庫,請先駁回該Invoice單", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGShipList.Item(0, DGShipList.CurrentCell.RowIndex).Value = 0
                CobInvoice.Enabled = True
            End If
        End If

        If Me.DGShipList.CurrentRow.Cells(0).Value = 1 Then
            '========================Add by anday 檢測ANS是否需要檢測=====================================
            Me.StrPart = DGShipList.CurrentRow.Cells(1).Value.ToString
            '判斷產品庫存是否有過期,如果過期則彈出提示框,提示用戶是否解鎖出貨，如果出貨直接出貨
            Dim SqlStr As String = " select min(isnull(lmty,365)-datediff(dd,a.intime,getdate())) gqts from m_carton_t a,M_Mainmo_t b, m_partcontrast_t c,m_wh_t d  " _
                                  & " where a.moid = b.moid And b.partid = Tavcpart and cartonStatus='I' and a.whid=d.whid and d.usey='Y' and d.typeid='G'" _
                                  & " and b.partid='" & StrPart & "'"
            Dim Partdr As DataTable = Pubclass.GetDataTable(SqlStr)
            If Partdr.Rows.Count > 0 Then
                If Partdr.Rows(0)(0).ToString.Trim <> "" Then
                    If CInt(Partdr.Rows(0)(0).ToString) < 1 Then
                        If MessageBox.Show("產品(" & StrPart & ")已經過期 " & vbNewLine & "是否解鎖出貨？", "提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Dim frmError As New FrmScanErrPrompt
                            frmError.Label1.Text = "產品過期放行"
                            frmError.Text = "產品過期放行"
                            frmError.ShowDialog()
                            If frmError.ExitFlag = False Then
                                ExitScan()
                            End If
                        Else
                            ExitScan()
                        End If
                    End If
                End If
            End If
        End If

        '========================Add by anday=========================================================

        Me.IntQty = DGShipList.CurrentRow.Cells(2).Value.ToString
        If DGShipList.Item(0, DGShipList.CurrentCell.RowIndex).Value = 1 Then
            PlScan.Enabled = True
            RbCartonScan.Checked = True
            chkReuse.Checked = False
            CobInvoice.Enabled = False
            txtRemark.Enabled = False
            TxtCartonid.Text = ""
            TxtPalletID.Text = ""
            TxtCartonid.Focus()
            TxtCartonid.BackColor = Color.FromArgb(192, 255, 192)
            Me.TxtASN.BackColor = Color.FromArgb(192, 255, 192)
            '加載掃描明細
            LoadScanList(DGShipList.Item(5, DGShipList.CurrentCell.RowIndex).Value.ToString)

            If HaveTotalQty(Me.StrPart) > Me.IntQty And HaveTotalQty(Me.StrPart) > 0 Then
                '彈出提示先進先出信息
                Dim Frmfrom As New FrmInformation()
                Frmfrom.StrPart = Me.StrPart
                Frmfrom.IntCount = Me.IntQty
                Frmfrom.StrInvoice = Me.CobInvoice.Text
                Frmfrom.ShowDialog()
            End If
        Else
            ExitScan()
        End If

    End Sub

    Public Sub ExitScan()
        '退出掃描
        Me.DGShipList.CurrentRow.Cells(0).Value = 0
        CobInvoice.Enabled = True
        txtRemark.Enabled = True
        PlScan.Enabled = False
        chkReuse.Checked = False
        TxtCartonid.Text = ""
        TxtPalletID.Text = ""
        Me.TxtASN.Text = ""
        TxtCartonid.BackColor = Color.White
        TxtPalletID.BackColor = Color.White
        Me.TxtASN.BackColor = Color.White
        Exit Sub
    End Sub

    'Add by anday_xu 2011/08/03 判斷產品是否需要ASN檢測。
    Public Sub UpdateASN(ByVal StrInvoice As String, ByVal StrAsn As String)
        Dim strSql As String = "update m_shipm_t set asny='" & StrAsn & "', userid='" & _
        MainFrame.SysCheckData.SysMessageClass.UseId & "',intime=getdate() where invoice = '" & StrInvoice & "'"
        Try
            Pubclass.ExecSql(strSql)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    '彈出“其它出貨”對話框
    Private Sub BtOtherOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOtherOut.Click
        Dim FrmOtherOut As New FrmOtherOut

        '判斷有無此Invice單
        Dim Strsql As String
        Dim Rs As SqlDataReader

        Strsql = "select stateid from m_shipm_t where Invoice='" & Trim(CobInvoice.Text) & "'"
        Rs = Pubclass.GetDataReader(Strsql)
        If Rs.HasRows Then
            While Rs.Read
                If Rs(0).ToString = "2" Then
                    MessageBox.Show("該 Invoice [已確認出貨]，請先[駁回]!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Rs.Close()
                    Exit Sub
                Else
                    ReuseClass.StrInvos = Trim(CobInvoice.Text)
                End If
            End While
        Else
            ReuseClass.StrInvos = ""
        End If
        Rs.Close()

        FrmOtherOut.ShowDialog()
        LoadDataAgain() 'superiority weak opporunity threaten
    End Sub

    '掃描外箱
    Private Sub TxtCartonid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCartonid.KeyPress
        Dim intSelrow As Integer '記錄選中數據行的索引
        Dim StrWHid As String = "" '記錄出貨掃描單號
        Dim Inti As Integer '用於for循環 
        Dim bExist As Boolean '判斷箱號是否存在
        Dim StrScanPartNo As String '掃描箱的料號
        Dim StrReturn As String '存儲過程返回字符串
        Dim StrInvoice As String '存儲當前Invoice 號
        Dim StrAsn As String 'ASN 號碼


        If Asc(e.KeyChar) = 13 And Trim(TxtCartonid.Text) <> "" Then
            '加入控制----2秒內輸入完成
            'If DateDiff(DateInterval.Second, G_time, Now) >= 2 Then
            '    TxtCartonid.Text = ""
            '    Exit Sub
            'End If
            StrInvoice = Trim(CobInvoice.Text)
            '取得當前選中行的索引
            intSelrow = GetNowRowIndex()
            '掃描單號
            StrWHid = DGShipList.Item(5, intSelrow).Value.ToString

            '正常掃描--------------------------------------------------------------------------
            If chkReuse.Checked = False Then

                '掃描某料號的第一箱時
                If StrWHid = "" Then
                    '先進先出判斷
                    '取系統出貨掃描單號
                    StrWHid = GetNewWHID(DGShipList.Item(1, intSelrow).Value.ToString, StrInvoice)

                    If StrWHid = "" Then
                        MessageBox.Show("取出貨掃描單號出錯，請重試!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    DGShipList.Item(5, intSelrow).Value = StrWHid
                End If

                '產品先做過期檢測,如果沒有過期則進行ASN判斷
                StrAsn = Me.TxtASN.Text.Trim
                If BoolASN = True And StrAsn = "" Then
                    Me.TxtASN.Focus()
                    Exit Sub
                End If

                '調用存儲過程
                StrReturn = CheckScanData(intSelrow, StrWHid, DGShipList.Item(1, intSelrow).Value.ToString, DGShipList.Item(2, intSelrow).Value, Trim(TxtCartonid.Text), 1, StrAsn)

                If StrReturn = "ASN條碼和客戶料號條碼不一致,不能出貨" Then
                    '系統鎖定
                    Dim frmError As New FrmScanErrPrompt
                    frmError.ShowDialog()
                    Me.TxtASN.Text = ""
                    Me.TxtASN.Focus()
                    Exit Sub
                End If


                If StrReturn = "掃描成功" Then
                    'add數據到掃描表格
                    AddToScanList(1, Trim(TxtCartonid.Text), DGShipList.Item(1, intSelrow).Value.ToString)
                    TxtCartonid.Text = ""
                    Me.TxtASN.Text = ""
                    TxtCartonid.Focus()
                    My.Computer.Audio.Play(My.Resources.pass, AudioPlayMode.Background)

                ElseIf StrReturn = "此出庫單已掃描完成！" Then
                    TxtCartonid.Text = ""
                    MessageBox.Show(StrReturn, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PlScan.Enabled = False
                    chkReuse.Checked = False
                    '加載出貨信息
                    LoadDataAgain()
                    '將客戶名，地址插到m_whoutM_t(當前版本，Invoice不需要)
                    If UpdtCusAdd(StrInvoice) = False Then
                        MessageBox.Show("插入[客戶名]和[客戶地址]有誤，請聯系系統管理員!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    '掃描到最後一筆單的最後一箱時提醒“確認”
                    If CheckDataIsReady(StrInvoice) = "1" Then
                        BtConfirm_Click(sender, e)
                    End If
                Else
                    PlaySimpleSound(1)
                    MessageBox.Show(StrReturn, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Text = ""
                    Me.TxtASN.Text = ""
                    TxtCartonid.Focus()
                End If

                '移除掃描----------------------------------------------------------------------
            Else
                If DGShipList.Item(3, intSelrow).Value <= 0 Then
                    PlaySimpleSound(1)
                    MessageBox.Show("此單已移除完畢!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Text = ""
                    TxtCartonid.Focus()
                    Exit Sub
                End If
                For Inti = 0 To DGScanList.Rows.Count - 1
                    If UCase(DGScanList.Item(3, Inti).Value.ToString) = UCase(Trim(TxtCartonid.Text)) Then
                        bExist = True
                        Exit For
                    End If
                Next Inti
                If bExist = False Then
                    PlaySimpleSound(1)
                    MessageBox.Show("輸入的箱號不在此單中!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Text = ""
                    TxtCartonid.Focus()
                    Exit Sub
                End If
                '取得當前掃描箱的料號
                StrScanPartNo = GetPartNo(Trim(TxtCartonid.Text), 1)
                If StrScanPartNo <> DGShipList.Item(1, intSelrow).Value.ToString Then
                    PlaySimpleSound(1)
                    MessageBox.Show("輸入的箱號料號與選擇的料號不一致!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Text = ""
                    TxtCartonid.Focus()
                    Exit Sub
                End If
                '數據處理
                StrReturn = DelScanData(intSelrow, StrWHid, DGShipList.Item(2, intSelrow).Value, Trim(TxtCartonid.Text), 1)
                If StrReturn = "成功移除！" Then
                    '加載掃描明細
                    LoadScanList(StrWHid)
                    My.Computer.Audio.Play(My.Resources.pass, AudioPlayMode.Background)
                    MessageBox.Show(StrReturn, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCartonid.Text = ""
                    TxtCartonid.Focus()
                ElseIf StrReturn = "此出庫單已經掃描完成！" Then
                    TxtCartonid.Text = ""
                    MessageBox.Show(StrReturn, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PlScan.Enabled = False
                    chkReuse.Checked = False
                    '加載出貨信息
                    LoadDataAgain()
                    '將客戶名，地址插到m_whoutM_t(當前版本，Invoice不需要)
                    If UpdtCusAdd(StrInvoice) = False Then
                        MessageBox.Show("插入[客戶名]和[客戶地址]有誤，請聯系系統管理員!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    '掃描到最後一筆單的最後一箱時提醒“確認”
                    If CheckDataIsReady(StrInvoice) = "1" Then
                        BtConfirm_Click(sender, e)
                    End If
                Else
                    MessageBox.Show(StrReturn, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If

    End Sub

    '掃描棧板
    Private Sub TxtPalletID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPalletID.KeyPress
        Dim intSelrow As Integer '記錄選中數據行的索引
        Dim StrWHid As String = "" '記錄出貨掃描單號
        Dim StrReturn As String '存儲過程返回字符串
        Dim Inti As Integer '用於for循環
        Dim StrScanPartNo As String '存儲掃描的料號
        Dim bExist As Boolean '
        Dim StrInvoice As String '存儲當前Invoice號

        If Asc(e.KeyChar) = 13 And Trim(TxtPalletID.Text) <> "" Then
            StrInvoice = Trim(CobInvoice.Text)
            '取得當前選中行的索引
            intSelrow = GetNowRowIndex()
            '掃描單號
            StrWHid = DGShipList.Item(5, intSelrow).Value.ToString
            '正常掃描--------------------------------------------------------------------------
            If chkReuse.Checked = False Then

                '掃描某料號的第一箱時
                If StrWHid = "" Then
                    '取系統出貨掃描單號
                    StrWHid = GetNewWHID(DGShipList.Item(1, intSelrow).Value.ToString, StrInvoice)
                    If StrWHid = "" Then
                        MessageBox.Show("取出貨掃描單號出錯，請重試!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    DGShipList.Item(5, intSelrow).Value = StrWHid
                End If
                '調用存儲過程
                StrReturn = CheckScanData(intSelrow, StrWHid, DGShipList.Item(1, intSelrow).Value.ToString, DGShipList.Item(2, intSelrow).Value, Trim(TxtPalletID.Text), 2, "")
                If StrReturn = "掃描成功" Then
                    'add數據到掃描表格
                    AddToScanList(2, Trim(TxtPalletID.Text), DGShipList.Item(1, intSelrow).Value.ToString)
                    TxtPalletID.Text = ""
                    TxtPalletID.Focus()
                    My.Computer.Audio.Play(My.Resources.pass, AudioPlayMode.Background)
                ElseIf StrReturn = "此出庫單已掃描完成！" Then
                    TxtPalletID.Text = ""
                    MessageBox.Show(StrReturn, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PlScan.Enabled = False
                    chkReuse.Checked = False
                    '加載出貨信息
                    LoadDataAgain()
                    '將客戶名，地址插到m_whoutM_t(當前版本，Invoice不需要)
                    If UpdtCusAdd(StrInvoice) = False Then
                        MessageBox.Show("插入[客戶名]和[客戶地址]有誤，請聯系系統管理員!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show(StrReturn, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtASN.Text = ""
                End If

                '移除掃描----------------------------------------------------------------------
            Else
                If DGShipList.Item(3, intSelrow).Value <= 0 Then
                    MessageBox.Show("此單已移除完畢!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPalletID.Text = ""
                    TxtPalletID.Focus()
                    Exit Sub
                End If
                For Inti = 0 To DGScanList.Rows.Count - 1
                    If DGScanList.Item(2, Inti).Value = Trim(TxtPalletID.Text) Then
                        bExist = True
                        Exit For
                    End If
                Next Inti
                If bExist = False Then
                    MessageBox.Show("輸入的棧板號不完全在此單中，請使用[箱號掃描]進行移除!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPalletID.Text = ""
                    TxtPalletID.Focus()
                    Exit Sub
                End If
                '取得當前掃描箱的料號
                StrScanPartNo = GetPartNo(Trim(TxtPalletID.Text), 2)
                If StrScanPartNo <> DGShipList.Item(1, intSelrow).Value.ToString Then
                    MessageBox.Show("輸入的棧板料號與選擇的料號不一致!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPalletID.Text = ""
                    TxtPalletID.Focus()
                    Exit Sub
                End If

                '數據處理
                StrReturn = DelScanData(intSelrow, StrWHid, DGShipList.Item(2, intSelrow).Value, Trim(TxtPalletID.Text), 2)
                If StrReturn = "成功移除！" Then
                    '加載掃描明細
                    LoadScanList(StrWHid)
                    My.Computer.Audio.Play(My.Resources.pass, AudioPlayMode.Background)
                    MessageBox.Show("'" & StrReturn & "'", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtPalletID.Text = ""
                    TxtPalletID.Focus()
                ElseIf StrReturn = "此出庫單已經掃描完成！" Then
                    TxtPalletID.Text = ""
                    MessageBox.Show("'" & StrReturn & "'", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PlScan.Enabled = False
                    chkReuse.Checked = False
                    '加載出貨信息
                    LoadDataAgain()

                    '將客戶名，地址插到m_whoutM_t(當前版本，Invoice不需要)
                    If UpdtCusAdd(StrInvoice) = False Then
                        MessageBox.Show("插入[客戶名]和[客戶地址]有誤，請聯系系統管理員!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("'" & StrReturn & "'", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        End If

    End Sub

    '將客戶名，地址插到出庫主表
    Function UpdtCusAdd(ByVal strInvoice As String) As Boolean
        Dim Strsql As String
        Try
            Strsql = "update m_whoutm_t set cusid='" & g_CustID & "', orderseq='" & strInvoice & "', " _
                   & "saddress='" & TxtAddress.Text & "' " _
                   & "where outwhid in (select outwhid from m_shipdtotal_t where invoice='" & strInvoice & "' )"
            Pubclass.ExecSql(Strsql)
            Return True
        Catch ex As Exception
            SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH2", "CheckScanData", "sys")
            Return False
        End Try

    End Function


    '取得當前選中行的索引
    Function GetNowRowIndex()
        Dim i As Integer
        Dim intReturn As Integer

        intReturn = -1
        For i = 0 To DGShipList.Rows.Count - 1
            If DGShipList.Item(0, i).FormattedValue.ToString = "True" Then
                intReturn = i
                Exit For
            End If
        Next
        Return intReturn

    End Function

    '取系統出貨單號
    Private Function GetNewWHID(ByVal strPart As String, ByVal strInvoice As String) As String
        Dim strSql, str As String
        Dim strMaxID As String
        Dim SvrDate As Date
        Dim Rs As SqlDataReader

        Try
            strMaxID = ""
            strSql = " select getdate(), max(outwhid) from m_whoutm_t where " _
                   & " substring(outwhid,3,6) = convert(varchar(6), getdate(), 12) "
            Rs = Pubclass.GetDataReader(strSql)

            If Rs.Read Then
                SvrDate = Rs(0)
                strMaxID = Rs(1).ToString
            End If

            If strMaxID = "" Then
                str = "WO" & Format(SvrDate, "yyMMdd") & "0001"
            Else
                str = "WO" & Mid((1 & Mid(strMaxID, 3)) + 1, 2)
            End If

            Rs.Close()

            strSql = " insert into m_whoutm_t (outwhid, partid, orderseq, shipqty, states, userid, intime) " _
                   & " values ('" & str & "', '" & strPart & "', '" & strInvoice & "', '0', '1', '" & SysCheckData.SysMessageClass.UseId & "', getdate()) " & vbCrLf

            '當前版
            strSql = strSql & " update m_shipdtotal_t set outwhid='" & str & "',States='1' where partid='" & strPart & "'and Invoice='" & strInvoice & "'"

            Pubclass.ExecSql(strSql)

        Catch ex As Exception
            str = ""
            SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH2", "GetNewWHID", "sys")
        End Try

        Return str
    End Function

    '檢查並處理掃描數據
    Private Function CheckScanData(ByVal IntSelrow As Integer, ByVal outwhid As String, ByVal partid As String, ByVal shipqty As Integer, ByVal CaPavalue As String, ByVal flag As String, ByVal StrAsn As String) As String
        Dim StrInvoice As String = CobInvoice.Text 'Invoice 單號
        Dim StrCusid As String = Trim(TxtCust.Text) '客戶代號
        Dim StrOuttype As String   '出貨類型
        Dim StrUserid As String = "" & SysCheckData.SysMessageClass.UseId & "" '用戶名

        Dim Strsql As String
        Dim Rs As SqlDataReader
        Dim StrReturn As String = "excute store procedure 'm_whoutscan_p'  error."

        Try
            If Trim(LabShipType.Text) = "" Then
                StrReturn = "出貨類型不能為空，請修改[出貨類型]！"
                Return StrReturn
            End If
            StrOuttype = LabShipType.Text.Substring(0, 1)

            Strsql = "declare @strmsgText varchar(50),@stateid varchar(1),@scanqty int,@scancarton int,@initcarton int " & _
                     "Exec m_whoutscan_p '" & outwhid & "','" & StrInvoice & "','" & partid & "','" & StrCusid & "'," & _
                     "'" & shipqty & "','" & StrOuttype & "','" & StrUserid & "','" & CaPavalue & "','" & flag & "', '" & StrAsn & "'," & _
                     "@strmsgText output,@stateid output,@scanqty output,@scancarton output,@initcarton output select @strmsgText,@stateid,@scanqty,@scancarton,@initcarton"

            Rs = Pubclass.GetDataReader(Strsql)

            While Rs.Read
                If Rs(0).ToString = "掃描成功" Or Rs(0).ToString = "此出庫單已掃描完成！" Then
                    StrReturn = Rs(0).ToString
                    If Rs(1).ToString = "1" Then
                        DGShipList.Item(4, IntSelrow).Value = "掃描中"
                    ElseIf Rs(1).ToString = "2" Then
                        DGShipList.Item(4, IntSelrow).Value = "掃描完成"
                        DGShipList.Item(4, IntSelrow).Style.ForeColor = Color.Red
                        DGShipList.Item(4, IntSelrow).Style.SelectionForeColor = Color.Red
                    End If
                    DGShipList.Item(3, IntSelrow).Value = Rs(2).ToString
                    LabCartCoun.Text = Rs(3).ToString
                    g_strTemp = Rs(4).ToString
                Else
                    StrReturn = Rs(0).ToString
                End If
            End While
            Rs.Close()

        Catch ex As Exception
            SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH2", "CheckScanData", "sys")
            StrReturn = "excute store procedure 'm_whoutscan_p'  error."
        End Try

        Return StrReturn
    End Function

    '“移除”檢查並處理掃描數據
    Private Function DelScanData(ByVal IntSelrow As Integer, ByVal outwhid As String, ByVal shipqty As Integer, ByVal CaPavalue As String, ByVal flag As String) As String
        Dim StrUserid As String = "" & SysCheckData.SysMessageClass.UseId & "" '用戶名

        Dim Strsql As String
        Dim Rs As SqlDataReader
        Dim StrReturn As String = "excute store procedure 'm_Whdelscan_p'  error."

        Try
            Strsql = "declare @strmsgText varchar(50),@stateid varchar(1),@scanqty int,@scancarton int " & _
                     "Exec m_Whdelscan_p '" & outwhid & "','" & shipqty & "','" & StrUserid & "','" & CaPavalue & "','" & flag & "'," & _
                     "@strmsgText output,@stateid output,@scanqty output,@scancarton output select @strmsgText,@stateid,@scanqty,@scancarton"

            Rs = Pubclass.GetDataReader(Strsql)

            While Rs.Read
                If Rs(0).ToString = "成功移除！" Or Rs(0).ToString = "此出庫單已經掃描完成！" Then
                    StrReturn = Rs(0).ToString
                    If Rs(1).ToString = "1" Then
                        DGShipList.Item(4, IntSelrow).Value = "掃描中"
                    ElseIf Rs(1).ToString = "2" Then
                        DGShipList.Item(4, IntSelrow).Value = "掃描完成"
                    ElseIf Rs(1).ToString = "3" Then
                        DGShipList.Item(4, IntSelrow).Value = "需調整"
                    End If
                    DGShipList.Item(3, IntSelrow).Value = Rs(2).ToString
                    LabCartCoun.Text = Rs(3).ToString
                Else
                    StrReturn = Rs(0).ToString
                End If
            End While
            Rs.Close()

        Catch ex As Exception
            MainFrame.SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH2", "DelScanData", "sys")
            StrReturn = "excute store procedure 'm_Whdelscan_p'  error."
        End Try

        Return StrReturn
    End Function

    '取得當前掃描箱或棧板號的料號
    Private Function GetPartNo(ByVal strValue As String, ByVal intType As Integer) As String
        Dim strReturn As String
        Dim strSql As String
        Dim Rs As SqlDataReader

        strSql = ""
        If intType = 1 Then
            strSql = " select partid from m_mainmo_t where moid in " _
                   & " (select moid from m_carton_t where cartonid='" & strValue & "') "
        End If

        If intType = 2 Then
            strSql = " select partid from m_mainmo_t where moid in " _
                   & " (select top 1 moid from m_carton_t where cartonid in  " _
                   & " (select top 1 cartonid from m_PalletCarton_t where palletid='" & strValue & "')) "
        End If

        Rs = Pubclass.GetDataReader(strSql)
        If Rs.Read Then
            strReturn = Rs(0).ToString
        Else
            strReturn = ""
        End If
        Rs.Close()

        Return strReturn
    End Function

    '單選按鈕切換事件
    Private Sub RbCartonScan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbCartonScan.CheckedChanged
        If RbCartonScan.Checked = True Then
            TxtCartonid.Enabled = True
            TxtCartonid.Focus()
            TxtCartonid.BackColor = Color.FromArgb(192, 255, 192)
            TxtASN.BackColor = Color.FromArgb(192, 255, 192)
            RbPalletScan.Checked = False
            TxtPalletID.Enabled = False
            TxtPalletID.BackColor = Color.White
            TxtPalletID.Text = ""
            TxtCartonid.Text = ""
        Else
            TxtCartonid.Enabled = False
            TxtASN.Enabled = False
            TxtCartonid.BackColor = Color.White
            TxtASN.BackColor = Color.White
            RbPalletScan.Checked = True
            TxtPalletID.Enabled = True
            TxtPalletID.Focus()
            TxtPalletID.BackColor = Color.FromArgb(192, 255, 192)
            TxtPalletID.Text = ""
            TxtCartonid.Text = ""
            TxtASN.Text = ""
        End If
    End Sub

    '插入掃描數據到表格中---(直接插入前台表格)
    Private Sub AddToScanList(ByVal flag As Integer, ByVal strValue As String, ByVal StrPartid As String)
        Dim Strsql As String
        Dim IntSel As Integer ' 記錄序號
        Dim Rs As SqlDataReader

        If flag = 1 Then '外箱掃描
            Strsql = "select a.cartonqty,b.palletid,substring(convert(varchar,getdate(), 120), 1, 16) from m_carton_t a " & _
                     "left join m_palletcarton_t b on a.cartonid=b.cartonid where a.cartonid='" & strValue & "'"
            Rs = Pubclass.GetDataReader(Strsql)
            While Rs.Read
                DGScanList.Rows.Add(LabCartCoun.Text, StrPartid, Rs(1).ToString, strValue, Rs(0).ToString, "" & SysCheckData.SysMessageClass.UseId & "", Rs(2).ToString)
            End While
            Rs.Close()

        Else  '棧板掃描
            Strsql = "select a.cartonid,a.cartonqty,substring(convert(varchar,getdate(), 120), 1, 16) from m_palletcarton_t b " & _
                     "left join m_carton_t a on a.cartonid=b.cartonid where b.palletid='" & strValue & "'"
            Rs = Pubclass.GetDataReader(Strsql)
            IntSel = CType(g_strTemp, Integer)
            While Rs.Read
                IntSel = IntSel + 1
                DGScanList.Rows.Add(IntSel, StrPartid, strValue, Rs(0).ToString, Rs(1).ToString, SysCheckData.SysMessageClass.UseId, Rs(2).ToString)
            End While
            Rs.Close()
            'LabCartCoun.Text = IntSel.ToString
        End If

    End Sub

    '“舍棄”按鈕事件
    Private Sub BtDrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDrop.Click
        Dim StrWhid As String '出庫單號
        'Dim Strsql As String
        Dim IntSelrow As Integer
        'Dim Rs As SqlDataReader

        '取得當前選中行的索引
        IntSelrow = GetNowRowIndex()
        If IntSelrow < 0 Then Exit Sub
        StrWhid = DGShipList.Item(5, IntSelrow).Value

        If StrWhid = "" Then Exit Sub
        '**************************2009/6/24---應倉庫需求，將此句注釋----tangxiang
        ''出貨量為 0 才能舍棄
        'If DGShipList.Item(2, IntSelrow).Value <> 0 Then
        '    MessageBox.Show("出貨數量量不為零，不能舍棄！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        '**************************
        If MsgBox("確實要舍棄出貨掃描單[ " & StrWhid & " ]的資料嗎？", MsgBoxStyle.Question & MsgBoxStyle.YesNo, "確認信息") = MsgBoxResult.Yes Then
            '舍棄數據處理
            DropScanData(StrWhid)
            '加載出貨信息
            LoadShipInfoDetail(CobInvoice.Text)
            DGScanList.Rows.Clear()
            LabCartCoun.Text = 0
            LoadDataAgain()
            MessageBox.Show("[" & StrWhid & "]舍棄成功.", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    '“駁回”按鈕事件
    Private Sub BtApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtReuse.Click
        Dim StrTemp As String

        If Trim(CobInvoice.Text) = "" Then Exit Sub
        If DGShipList.Rows.Count <= 0 Then Exit Sub

        'check 該Invoice單號是否為“已確認”狀態
        ''Invoice版本
        'StrTemp = CheckDataIsOver(Trim(DGShipList.Item(6, 0).Value.ToString))
        '當前版本
        StrTemp = CheckDataIsOver(Trim(CobInvoice.Text))
        If StrTemp = "0" Then
            MessageBox.Show("該Invoice No 狀態不是[已確認],不能駁回！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf StrTemp = "2" Then
            Exit Sub
        End If
        If MessageBox.Show("是否駁回 單號:" & Trim(CobInvoice.Text) & "？", "確認提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            ''Invoice版本
            'Pubclass.ExecSql("update m_InvoiceM_t set Stateid='3' where InvoiceJob='" & Trim(DGShipList.Item(6, 0).Value.ToString) & "'")
            '當前版本
            Pubclass.ExecSql("update m_shipM_t set Stateid='1' where Invoice='" & Trim(CobInvoice.Text) & "'")
            '重新加載數據
            LoadDataAgain()
            MessageBox.Show("駁回成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    '舍棄數據處理
    Private Sub DropScanData(ByVal StrWhid As String)
        Dim Strsql As String = ""
        Try

            Strsql = Strsql & " begin " & vbCrLf

            Strsql = Strsql & " update m_carton_t set cartonstatus='I',updatetime=getdate(),updateuser='" & SysCheckData.SysMessageClass.UseId & "' " _
                            & " where cartonid in (select cartonid from m_whoutd_t where outwhid ='" & StrWhid & "'); " & vbCrLf

            Strsql = Strsql & " update m_palletm_t set palletstatus = 'I' where palletid in " _
                            & " (select distinct palletid from m_palletcarton_t " _
                            & " where cartonid in (select cartonid from m_whoutd_t where outwhid ='" & StrWhid & "')); " & vbCrLf

            Strsql = Strsql & " delete m_whoutm_t where outwhid ='" & StrWhid & "' " & vbCrLf

            Strsql = Strsql & " delete m_whoutd_t where outwhid ='" & StrWhid & "' " & vbCrLf
            ''Invoice版
            'Strsql = Strsql & " update m_InvoiceS_t set Qty=0,Stateid='2', Intime=getdate(), " _
            '                & " Userid='sz30914' where outwhid='" & StrWhid & "' " & vbCrLf
            '當前版本
            Strsql = Strsql & " update m_shipdtotal_t set outwhid='',Qty=0,States='1',Intime=getdate()," _
                            & " Userid='" & SysCheckData.SysMessageClass.UseId & "' where outwhid='" & StrWhid & "' " & vbCrLf

            Strsql = Strsql & " end "

            Pubclass.ExecSql(Strsql)
        Catch ex As Exception
            SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH2", "BtDrop_Click", "sys")
        End Try
    End Sub

    Private Sub BtBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBack.Click
        Me.Close()

    End Sub

    '快捷鍵設定
    Private Sub FrmOutWH2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.D AndAlso e.Alt Then
            BtDrop_Click(sender, e)
        ElseIf e.KeyCode = Keys.R AndAlso e.Alt Then
            BtApply_Click(sender, e)
        ElseIf e.KeyCode = Keys.T AndAlso e.Alt Then
            BtOtherOut_Click(sender, e)
        ElseIf e.KeyCode = Keys.X AndAlso e.Alt Then
            BtBack_Click(sender, e)
        End If

    End Sub

    '加載Invoice 清單到Combox中
    Private Sub CobInvoice_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobInvoice.DropDown
        'LoadInvoiceNo()
    End Sub

    '“確認”按鈕事件
    Private Sub BtConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtConfirm.Click
        Dim StrTemp As String
        Dim StrAffirm As String

        If Trim(CobInvoice.Text) = "" Then Exit Sub
        If DGShipList.Rows.Count <= 0 Then Exit Sub

        'check 該Invoice單號是否全部掃描完成
        ''Invoice版本
        'StrTemp = CheckDataIsReady(Trim(DGShipList.Item(6, 0).Value.ToString))
        '當前版本
        StrTemp = CheckDataIsReady(Trim(CobInvoice.Text))
        If StrTemp = "0" Then
            MessageBox.Show("該Invoice No 尚有料號未掃描完成，不能確認！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf StrTemp = "2" Then
            Exit Sub
        End If
        'check 該Invoice單號是否已確認
        StrAffirm = CheckDataIsOver(Trim(CobInvoice.Text))
        If StrAffirm = "1" Then
            MessageBox.Show("該Invoice No 已經[確認]！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf StrAffirm = "2" Then
            Exit Sub
        End If
        If MessageBox.Show("單號:" & Trim(CobInvoice.Text) & "下的所有料件已掃描完成，是否確認出庫？", "確認提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            ''Invoice 版本
            'Pubclass.ExecSql("update m_InvoiceM_t set Stateid='4' where InvoiceJob='" & Trim(DGShipList.Item(6, 0).Value.ToString) & "'")
            '當前版本
            Pubclass.ExecSql("update m_shipM_t set Stateid='2' where Invoice='" & Trim(CobInvoice.Text) & "' " & vbNewLine & _
                             "update m_whoutm_t set remark='" & Trim(txtRemark.Text) & "' where orderseq='" & Trim(CobInvoice.Text) & "'")
            '
            '重新加載數據
            If BoolASN = True Then
                UpdateASN(Trim(CobInvoice.Text), "Y")
            End If

            LoadDataAgain()
            MessageBox.Show("確認成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    'check 該Invoice單號是否全部掃描完成
    Private Function CheckDataIsReady(ByVal StrInvoice As String) As String
        Dim Strsql As String
        Dim Strtemp As String = ""
        Dim Dr As SqlDataReader
        Dim Inti As Integer '用於for循環
        Dim Intn As Integer = 0 '用於計數
        ''Invoice版本 
        'Strsql = "select Stateid from m_InvoiceS_t where InvoiceJob='" & StrInvoice & "'"
        '當前版本
        For Inti = 0 To DGShipList.Rows.Count - 1
            If DGShipList.Item(7, Inti).Value.ToString = "不需要掃描" Then
                Intn = Intn + 1
                If Intn >= 2 Then
                    Strtemp = Strtemp + ",'" + DGShipList.Item(1, Inti).Value.ToString + "'"
                Else
                    Strtemp = "'" + DGShipList.Item(1, Inti).Value.ToString + "'"
                End If
            End If
        Next
        If Intn = 0 Then
            Strsql = "select States from m_shipdtotal_t where Invoice='" & StrInvoice & "'"
        Else
            Strsql = "select States from m_shipdtotal_t where Invoice='" & StrInvoice & "'and Partid not in(" & Strtemp & ")"
        End If

        Dr = Pubclass.GetDataReader(Strsql)
        If Dr.HasRows Then
            While Dr.Read
                If Dr(0).ToString <> "2" Then
                    Dr.Close()
                    Return "0"
                End If
            End While
        Else
            MessageBox.Show("該Invoice No下無相關資料，不能確認！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dr.Close()
            Return "2"
        End If
        Dr.Close()
        Return "1"
    End Function

    'check 該Invoice單號是否為“已確認”狀態
    Private Function CheckDataIsOver(ByVal StrInvoice As String) As String
        Dim Strsql As String
        Dim Dr As SqlDataReader
        ''Invoice版本
        'Strsql = "select Stateid from m_InvoiceM_t where InvoiceJob='" & StrInvoice & "'"
        '當前版本
        Strsql = "select Stateid from m_shipM_t where Invoice='" & StrInvoice & "'"
        Dr = Pubclass.GetDataReader(Strsql)
        If Dr.HasRows Then
            While Dr.Read
                ''Invoice版本
                'If Dr(0).ToString <> "4" Then
                '當前版本
                If Dr(0).ToString <> "2" Then
                    Dr.Close()
                    Return "0"
                End If
            End While
        Else
            MessageBox.Show("找不到該Invoice No資料！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dr.Close()
            Return "2"
        End If
        Dr.Close()
        Return "1"
    End Function

    '重新加載出貨數據
    Sub LoadDataAgain()
        LoadInvoiceNo()
        LoadShipInfo()

    End Sub

    Private Sub TxtCartonid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCartonid.KeyDown
        If Trim(TxtCartonid.Text) = "" Then
            G_time = Now
        End If

    End Sub

    '判斷是否有更早入庫的產品
    Private Function HaveOldProduct(ByVal strPart As String) As Boolean
        Dim strSql As String
        Dim strReturn As Boolean
        Dim Dr As SqlDataReader

        strSql = " select top 1 a.floorid,a.whid,a.areaid,a.intime " _
               & " from m_Carton_t a join m_Mainmo_t b on a.moid=b.moid " _
               & " where b.partid='" & strPart & "' and a.cartonstatus='I' " _
               & " and convert(datetime, a.intime) - 30 > 0 order by a.intime "
        Dr = Pubclass.GetDataReader(strSql)

        If Dr.Read Then
            ClassInf.StrInf = "該料號: " & strPart & " 在" & vbCrLf & Dr(0).ToString & " 樓層, " _
                            & Dr(1).ToString & " 倉庫, " & Dr(2).ToString & " 儲位 " & vbCrLf & "有 " _
                            & Dr(3).ToString & " 先入庫的產品"
            ClassInf.StrColor = Color.Green
            ClassInf.StrQInf = "你確定不遵守先進先出嗎？"
            ClassInf.StrQColor = Color.Red
            strReturn = True
        Else
            strReturn = False
        End If

        Dr.Close()
        Return strReturn
    End Function

    '統計產品的總庫存
    Private Function HaveTotalQty(ByVal strPart As String) As Integer
        Dim strSql As String
        Dim Dr As SqlDataReader
        Dim qty As Integer

        strSql = "select sum(b.cartonqty) qty from m_mainmo_t a,  m_carton_t b,  " _
               & " m_whinm_t c , m_whind_t d where  a.moid=b.moid and a.partid='" & strPart & "'  and b.moid=c.moid and b.cartonid=d.cartonid  " _
               & "and c.inwhid=d.inwhid  and b.cartonstatus='I'  group by a.partid "
        Dr = Pubclass.GetDataReader(strSql)
        If Dr.Read Then
            qty = Dr(0)
        Else
            qty = 0
        End If
        Dr.Close()
        Return qty
    End Function

    Private Sub FrmOutWH2_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        LoadInvoiceNo()
    End Sub


#Region "聲音播放"
    Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        Select Case PassOrNg
            Case 0
                My.Computer.Audio.Play(My.Resources.pass, AudioPlayMode.Background)
            Case 1
                My.Computer.Audio.Play(Application.StartupPath + "\Error.wav", AudioPlayMode.Background)
                System.Threading.Thread.Sleep(1000)
        End Select
    End Sub
#End Region

    Private Sub TxtASN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtASN.KeyPress
        If Me.TxtCartonid.Text = "" Then
            MessageBox.Show("請先掃描包裝箱條碼！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            Me.TxtCartonid_KeyPress(sender, e)
        End If
    End Sub

    Private Sub chkReuse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReuse.CheckedChanged
        '勾選移除按鈕時判斷是否要顯示ASN條碼掃描框
        If Me.chkReuse.Checked Then
            Me.TxtASN.Text = ""
            Me.TxtASN.Visible = False
        ElseIf BoolASN = True Then
            Me.TxtASN.Text = ""
            Me.TxtASN.Visible = True
        End If
    End Sub

    Private Sub ToolCancelAsn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancelAsn.Click
        If Me.CobInvoice.Text.Trim = "" Then
            MessageBox.Show("請選擇Invoice單號！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim sqlStr As String = "select ASNY from m_shipm_t  where  invoice ='" & Me.CobInvoice.Text.Trim & "'"
        Dim dt As DataTable = Pubclass.GetDataTable(sqlStr)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)(0).ToString.Trim <> "Y" Then
                Me.UpdateASN(Me.CobInvoice.Text.Trim, "Y")
                MessageBox.Show("該Invoice：" & Me.CobInvoice.Text.Trim & "啟用ASN檢測成功！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BoolASN = True
                Me.TxtASN.Visible = True
                Me.TxtASN.BackColor = Me.TxtCartonid.BackColor
                Me.ToolCancelAsn.Text = "取消ASN檢測（&C)"
            Else
                Dim frmError As New FrmScanErrPrompt
                frmError.Label1.Text = "取消ASN檢測"
                frmError.Text = "取消ASN檢測"
                frmError.ShowDialog()
                If frmError.ExitFlag = True Then
                    Me.UpdateASN(Me.CobInvoice.Text.Trim, "N")
                    MessageBox.Show("該Invoice：" & Me.CobInvoice.Text.Trim & "取消ASN檢測成功！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    BoolASN = False
                    Me.TxtASN.Visible = False
                    Me.ToolCancelAsn.Text = "啟用ASN檢測（&C)"
                End If
            End If
        End If
    End Sub
End Class