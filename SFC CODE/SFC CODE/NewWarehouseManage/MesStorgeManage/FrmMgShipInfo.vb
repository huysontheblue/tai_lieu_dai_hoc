Imports System.Data.SqlClient

Public Class FrmMgShipInfo

    Private objDB As New MainFrame.SysDataHandle.SysDataBaseClass
    Private Rs As SqlDataReader
    Private g_User As String
    Private g_Rights As String
    Private g_New As Boolean = False
    Private g_DelSQL As String
    Private g_Opcode As Integer
    Public g_MInvoice As String

    '初始化變量
    Private Sub Init()
        g_User = MainFrame.SysCheckData.SysMessageClass.UseId
        DoRights()
        ChangeUI(0)
        LoadInvoiceList()
        LoadCustomer()
        g_DelSQL = ""
        '修改數量事件
        If g_MInvoice <> "" Then
            CobInvoice.SelectedText = g_MInvoice
            LoadInvoiceDetail(CobInvoice.Text)
            ShowShipAddress(CobInvoice.Text)
            BtCancel.Enabled = False

            ChangeUI(2)
            Me.CobFacory.Enabled = False
            Me.CobCust.Enabled = False
            Me.CobAddress.Enabled = False
        End If
    End Sub

    '窗體加載
    Private Sub FrmMgShipInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Init()
    End Sub

    '權限處理
    Private Sub DoRights()
        Dim strSql As String

        g_Rights = ""
        CobFacory.Items.Clear()
        strSql = " select ttext, buttonid from m_logtree_t where tkey in " _
               & " (select tkey from m_userright_t where tkey='F010_' and userid='" & g_User & "' " _
               & " union " _
               & " select tkey from m_userright_t where tkey='F011_' and userid='" & g_User & "') "
        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            g_Rights = g_Rights & "," & "'" & Rs(1).ToString & "'"

            CobFacory.Items.Add(Rs(1).ToString & "-" & Rs(0).ToString)


            ' CobFacory.Items.Add(Rs(0).ToString & "(" & Rs(1).ToString & ")")
        End While

        g_Rights = Mid(g_Rights, 2)
        If g_Rights = "" Then g_Rights = "''"
        Rs.Close()
    End Sub

    '更新界面
    Private Sub ChangeUI(ByVal intOP As Integer)
        If intOP = 1 Then  'New
            BtModify.Enabled = False
            BtNew.Enabled = False
            BtSave.Enabled = True
            BtDrop.Enabled = False
            CobInvoice.SelectedIndex = -1
            CobInvoice.Focus()
            CobCust.Enabled = True
            CobCust.Text = ""
            CobAddress.Enabled = True
            CobAddress.Text = ""
            DGItem.Rows.Clear()
            DGItem.Columns(3).Visible = False
            DGItem.Columns(4).Visible = False
            TxtInvoice.Visible = True
            CobInvoice.Visible = False
            CobFacory.Enabled = True
            TxtCusID.Enabled = False
            chkCreate.Visible = True
            chkCreate.Enabled = True
            chkCreate.Checked = False
            TxtCusID.Text = ""
            TxtInvoice.Focus()
            g_New = True
            ToolStrip2.Enabled = True
            ChangeUID(0)
        ElseIf intOP = 2 Then 'Modify
            BtNew.Enabled = False
            BtSave.Enabled = True
            CobInvoice.Enabled = False
            BtModify.Enabled = False
            CobCust.Enabled = True
            CobAddress.Enabled = True
            BtDrop.Enabled = False
            DGItem.Columns(3).Visible = False
            DGItem.Columns(4).Visible = False
            CobFacory.Enabled = True
            TxtCusID.Enabled = False
            chkCreate.Visible = False
            g_New = False
            ToolStrip2.Enabled = True
            ChangeUID(0)
        Else
            CobInvoice.Enabled = True
            BtNew.Enabled = True
            BtModify.Enabled = False
            BtDrop.Enabled = False
            BtSave.Enabled = False
            CobInvoice.Text = ""
            CobCust.Enabled = False
            CobCust.Text = ""
            CobAddress.Enabled = False
            CobAddress.Text = ""
            DGItem.Rows.Clear()
            CobInvoice.Focus()
            DGItem.Columns(2).Visible = True
            DGItem.Columns(3).Visible = True
            DGItem.Columns(4).Visible = True
            CobFacory.Enabled = False
            TxtInvoice.Text = ""
            TxtInvoice.Visible = False
            CobInvoice.Visible = True
            TxtCusID.Enabled = False
            chkCreate.Visible = False
            TxtCusID.Text = ""
            g_New = False
            ToolStrip2.Enabled = False
            TxtItem.Text = ""
            TxtPartNo.Text = ""
            TxtQty.Text = ""

            TxtItem.Enabled = False
            TxtPartNo.Enabled = False
            TxtQty.Enabled = False
            ChangeUID(0)
        End If
    End Sub

    Private Sub ChangeUID(ByVal intOp As Integer)
        If intOp = 1 Then  'New
            BtDNew.Enabled = False
            BtDEdit.Enabled = False
            BtDDel.Enabled = False
            BtDConfirm.Enabled = True
            BtDReturn.Enabled = True
            TxtItem.Enabled = False
            TxtPartNo.Enabled = True
            TxtQty.Enabled = True
            TxtItem.Text = ""
            TxtPartNo.Text = ""
            TxtQty.Text = ""
            TxtPartNo.Focus()
            DGItem.Enabled = False
        ElseIf intOp = 2 Then
            BtDNew.Enabled = False
            BtDEdit.Enabled = False
            BtDDel.Enabled = False
            BtDConfirm.Enabled = True
            BtDReturn.Enabled = True
            TxtItem.Enabled = False
            TxtPartNo.Enabled = False
            TxtQty.Enabled = True
            TxtQty.Text = ""
            TxtQty.Focus()
            DGItem.Enabled = False
        Else
            BtDNew.Enabled = True
            BtDEdit.Enabled = True
            BtDDel.Enabled = True
            BtDConfirm.Enabled = False
            BtDReturn.Enabled = False
            TxtItem.Enabled = False
            TxtPartNo.Enabled = False
            TxtQty.Enabled = False
            TxtItem.Text = ""
            TxtPartNo.Text = ""
            TxtQty.Text = ""
            DGItem.Focus()
            DGItem.Enabled = True
        End If
    End Sub

    '加載Invoice清單
    Private Sub LoadInvoiceList()
        Dim strSql As String

        CobInvoice.Items.Clear()
        strSql = " select distinct a.invoice from m_shipm_t a, m_shipd_t b " _
               & " where a.invoice=b.invoice and b.states='E' and a.factory in (" & g_Rights & ") " _
               & " and a.usey='Y' order by 1 "
        Rs = objDB.GetDataReader(strSql)

        While Rs.Read()
            CobInvoice.Items.Add(Rs(0).ToString())
        End While
        Rs.Close()
    End Sub

    '加載料號清單
    Private Sub FillGridCombox(ByVal ColComboBox As DataGridViewComboBoxColumn)
        Dim strSql As String

        If ColComboBox.Name = "ComboPart" Then
            ColComboBox.Items.Clear()

            strSql = " select distinct partid from m_mainmo_t "
            Rs = objDB.GetDataReader(strSql)
            While Rs.Read
                ColComboBox.Items.Add(Rs(0).ToString)
            End While
            Rs.Close()
        End If
    End Sub

    '檢查輸入料號是否正確
    Public Function CheckPartNO(ByVal strPartNo As String) As Boolean
        Dim strSql As String
        Dim bReturn As Boolean

        strSql = " select count(*) from matter_tab where partid='" & strPartNo & "' "
        Rs = objDB.GetDataReader(strSql)
        If Rs.Read Then
            If Rs(0) > 0 Then
                bReturn = True
            Else
                bReturn = False
            End If
        Else
            bReturn = False
        End If

        Rs.Close()
        Return bReturn
    End Function

    '顯示出貨客戶/地址
    Private Sub ShowShipAddress(ByVal strInvoice As String)
        Dim strSql As String
        Dim strCust, strAddress As String
        Dim strFactory As String

        strCust = ""
        strAddress = ""
        CobAddress.Text = ""
        CobAddress.Items.Clear()
        CobCust.SelectedIndex = -1

        strSql = " select b.cusid, b.cusname, b.saddress, c.saddress, getdate() dt " _
               & " from m_shipm_t a join m_custinfo_t b on a.cusid=b.cusid left outer join " _
               & " m_custother_t c on a.cusid=c.cusid where a.invoice='" & strInvoice & "' "
        Rs = objDB.GetDataReader(strSql)

        If Rs.Read Then
            strCust = Rs(0).ToString
            TxtCusID.Text = strCust
            CobCust.SelectedIndex = CobCust.Items.IndexOf(Rs(1).ToString)
            strAddress = Rs(2).ToString
            CobAddress.Text = strAddress & "------" & strCust
            If strAddress = "" Then
                CobAddress.Text = Rs(3).ToString & "------" & strCust
            End If
        End If
        Rs.Close()

        strSql = " select b.ttext, a.factory from m_shipm_t a  left outer join m_logtree_t b " _
               & " on a.factory= b.buttonid where invoice='" & strInvoice & "' "
        Rs = objDB.GetDataReader(strSql)
        If Rs.Read() Then
            Dim intPos As Integer
            strFactory = Rs(1).ToString & "-" & Rs(0).ToString

            'Rs(0).ToString & "(" & Rs(1).ToString & ")"
            intPos = CobFacory.Items.IndexOf(strFactory)
            CobFacory.SelectedIndex = intPos
        End If
        Rs.Close()
    End Sub

    '加載Invoice明細
    Private Sub LoadInvoiceDetail(ByVal strInvoice As String)
        Dim strSql As String

        DGItem.Rows.Clear()

        'strSql = " select partid, (case when b.eqty is null then b.sqty " _
        '       & " when b.sqty is null then b.eqty " _
        '       & " when b.eintime is not null and b.intime is not null and b.eintime>b.intime then b.eqty " _
        '       & " when b.intime is not null and b.eintime is not null and b.intime>b.eintime then b.sqty end)qty, " _
        '       & " (case when b.eintime is not null and b.intime is null then " _
        '       & " convert(varchar,b.eintime, 120) + '&'+ b.euserid  " _
        '       & " when b.intime is not null and b.eintime is null then " _
        '       & " convert(varchar,b.intime, 120) + '&'+ b.userid " _
        '       & " when b.eintime is not null and b.intime is not null and b.eintime>b.intime then " _
        '       & " convert(varchar,b.eintime, 120) + '&'+ b.euserid " _
        '       & " when b.intime is not null and b.eintime is not null and b.intime>b.eintime then " _
        '       & " convert(varchar,b.intime, 120) + '&'+ b.userid end)dtusr " _
        '       & " from  m_shipm_t a join m_shipd_t b on a.invoice=b.invoice " _
        '       & " where a.invoice='" & strInvoice & "' "

        strSql = " select b.items, b.partid, b.eqty, substring(convert(varchar,b.eintime, 120), 1, 16) dt, b.euserid, b.states from " _
               & " m_shipm_t a join m_shipd_t b on a.invoice=b.invoice " _
               & " where a.invoice='" & strInvoice & "' "

        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            DGItem.Rows.Add(Rs(0).ToString, Rs(1).ToString, Rs(2).ToString, Rs(3).ToString, Rs(4).ToString)
            If BtNew.Enabled = True Then
                BtNew.Enabled = False
                BtDrop.Enabled = True
                BtModify.Enabled = True
            End If
        End While
        Rs.Close()

    End Sub

    '加載客戶名稱
    Private Sub LoadCustomer()
        Dim strSql As String

        CobCust.Items.Clear()
        CobAddress.Text = ""
        CobAddress.Items.Clear()

        strSql = " select distinct cusname from m_custinfo_t order by cusname "
        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            CobCust.Items.Add(Rs(0).ToString)
        End While
        Rs.Close()
    End Sub

    '加載客戶地址
    Private Sub LoadCustAddress(ByVal strCust As String)
        Dim strSql As String

        CobAddress.Items.Clear()
        CobAddress.Text = ""

        strSql = " select distinct saddress, cusid from m_custinfo_t where cusname='" & strCust & "' "
        Rs = objDB.GetDataReader(strSql)
        While Rs.Read
            CobAddress.Items.Add(Rs(0).ToString & "------" & Rs(1).ToString)
        End While
        Rs.Close()
    End Sub

    '取得新的Customer ID
    Private Function GetCustID(ByVal strAddress As String) As String
        Dim strSql As String
        Dim strReturn As String
        Try
            strSql = " select substring(max(cusid), 3, 4) from m_custother_t where substring(cusid, 1, 2)='XC' "

            Rs = objDB.GetDataReader(strSql)
            If Rs.Read Then
                If Rs(0).ToString = "" Then
                    strReturn = "XC" & "1001"
                Else
                    strReturn = "XC" & Rs(0).ToString + 1
                End If
            Else
                strReturn = "XC" & "1001"
            End If

            Rs.Close()

            strSql = " insert into m_custother_t (cusid, saddress) " _
                   & " values('" & strReturn & "', '" & strAddress & "') " & vbCrLf _
                   & " insert into m_custinfo_t (cusid, cusname, saddress, intime, usey) " _
                   & " values('" & strReturn & "', '" & CobCust.Text & "', '', getdate(), 'Y') "
            objDB.ExecSql(strSql)

        Catch ex As Exception
            strReturn = ""
            Rs.Close()
            MainFrame.SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmMgShipInfo", "GetCustID", "sys")
        End Try

        Return strReturn
    End Function

    '檢查Invoice號碼是否存在
    Private Function CheckInvoiceExist(ByVal strInvoice) As Boolean
        Dim strSql As String
        Dim bRetrun As Boolean

        strSql = " select * from m_shipm_t where invoice='" & strInvoice & "' "
        Rs = objDB.GetDataReader(strSql)

        If Rs.Read Then
            bRetrun = True
        Else
            bRetrun = False
        End If

        Rs.Close()
        Return bRetrun
    End Function

    '檢查出貨明細資料
    Private Function CheckShipList() As Boolean
        Dim i As Integer

        '  If DGItem.Rows.Count = 1 Then Return False

        For i = 0 To DGItem.Rows.Count - 1
            If IsNothing(DGItem.Item(1, i).Value) Or IsNothing(DGItem.Item(2, i).Value) Then
                Return False
            End If

            If DGItem.Item(1, i).Value.ToString = "" Or DGItem.Item(2, i).Value.ToString = "" Then
                Return False
            End If
        Next
        Return True
    End Function

    '刪除出貨明細
    Public Function DelShipList(ByVal strInvoice As String) As String
        Dim strSql As String
        Dim strStates As String

        Try
            strSql = " select states from m_shipd_t where invoice='" & strInvoice & "' and states<>'E' "
            Rs = objDB.GetDataReader(strSql)
            If Rs.Read Then
                strStates = Rs(0).ToString
                If strStates = "1" Then
                    strStates = "此單號正在掃描中，不能刪除"
                End If
                If strStates = "W" Then
                    strStates = "此單號已提交，不能刪除"
                End If
                If strStates = "2" Then
                    strStates = "此單號已確認出庫，不能刪除"
                End If
                Rs.Close()
                Return strStates
            Else
                Rs.Close()
                strSql = " delete from m_shipm_t where invoice='" & strInvoice & "' " & vbCrLf _
                       & " delete from m_shipd_t where invoice='" & strInvoice & "' "
                objDB.ExecSql(strSql)
                Return "OK"
            End If
        Catch ex As Exception
            Rs.Close()
            MainFrame.SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmMgShipInfo", "DelShipList", "sys")
            Return ""
        End Try
    End Function

    Private Sub BtBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub BtNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNew.Click
        ChangeUI(1)
    End Sub

    Private Sub BtModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtModify.Click
        ChangeUI(2)
    End Sub

    Private Sub BtLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadInvoiceDetail(CobInvoice.Text)
        ShowShipAddress(CobInvoice.Text)
    End Sub

    Private Sub CobInvoice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If CobInvoice.Text <> "" And Asc(e.KeyChar) = 13 Then
            BtLoad_Click(sender, e)
        End If
    End Sub

    '保存數據
    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        Dim i As Integer
        Dim strSql As String
        Dim intPos As Integer
        Dim strInvoice As String
        Dim strCustID As String
        Dim strUser As String
        Dim strPartno, Qty As String
        Dim strFactory As String
        Dim strItem As String
        Dim itemString As String

        Try
            DGItem.EndEdit()
            DGItem.Update()

            intPos = CobFacory.Text.IndexOf("-")
            strFactory = Mid(CobFacory.Text, 1, intPos)

            If DGItem.RowCount = 0 Then
                MsgBox("明細資料不能為空。", MsgBoxStyle.Exclamation, "提示信息")
                Exit Sub
            End If


            If g_New = False Then
                If CobInvoice.Text = "" Then
                    MsgBox("Invoice號碼不能為空。", MsgBoxStyle.Exclamation, "提示信息")
                    Exit Sub
                End If
            Else
                If TxtInvoice.Text = "" Then
                    MsgBox("Invoice號碼不能為空。", MsgBoxStyle.Exclamation, "提示信息")
                    Exit Sub
                End If
            End If

            'If CobCust.Text = "" Then
            '    MsgBox("出貨客戶不能為空。", MsgBoxStyle.Exclamation, "提示信息")
            '    Exit Sub
            'End If

            If CobAddress.Text = "" Then
                MsgBox("出貨地址不能為空。", MsgBoxStyle.Exclamation, "提示信息")
                Exit Sub
            End If

            If CheckShipList() = False Then
                MsgBox("出貨明細資料不完整。", MsgBoxStyle.Exclamation, "提示信息")
                Exit Sub
            End If

            If g_New = False Then
                strInvoice = CobInvoice.Text.ToUpper.Trim
            Else
                strInvoice = TxtInvoice.Text.ToUpper.Trim
            End If

            If CobInvoice.Enabled = True And CheckInvoiceExist(strInvoice) = True Then
                MsgBox("Invoice號碼已存在。", MsgBoxStyle.Exclamation, "提示信息")
                Exit Sub
            End If

            intPos = CobAddress.Text.IndexOf("------")
            strUser = MainFrame.SysCheckData.SysMessageClass.UseId
            strCustID = Mid(CobAddress.Text, intPos + 7, CobAddress.Text.Length - intPos)
            If intPos < 0 Then
                TxtCusID.Text = GetCustID(CobAddress.Text)
            End If
            strCustID = TxtCusID.Text

            If strCustID = "" Then Exit Sub

            'str = DelShipList(strInvoice)
            'If str <> "OK" Then
            '    MsgBox(str, MsgBoxStyle.Exclamation, "提示信息")
            '    Exit Sub
            'End If
            Dim bExist As Boolean = False
            strSql = " select * from m_shipm_t where invoice='" & strInvoice & "'  "
            Rs = objDB.GetDataReader(strSql)
            If Rs.Read Then
                bExist = True
            Else
                bExist = False
            End If
            Rs.Close()

            If Not bExist Then
                strSql = " insert into m_shipm_t (invoice, shippno, cusid, eintime, euserid, factory, flag, usey) " _
                       & " values ('" & strInvoice & "', 'N/A', '" & strCustID & "', getdate(), '" & strUser & "',  " _
                       & " '" & strFactory & "', '1', 'Y') "
                objDB.ExecSql(strSql)
            Else
                strSql = " update m_shipm_t set cusid='" & strCustID & "', factory='" & strFactory & "', flag=1, " _
                       & " eintime=getdate(), euserid='" & strUser & "' where invoice='" & strInvoice & "' "
                objDB.ExecSql(strSql)
            End If

            bExist = False

            strSql = " delete from m_shipd_t where invoice='" & strInvoice & "' and outwhid is null "
            objDB.ExecSql(strSql)

            If g_DelSQL <> "" Then
                objDB.ExecSql(g_DelSQL)
            End If

            itemString = ""

            For i = 0 To DGItem.Rows.Count - 1
                strItem = DGItem.Item(0, i).Value.ToString
                strPartno = DGItem.Item(1, i).Value.ToString
                strPartno = strPartno.ToUpper.Trim
                Qty = DGItem.Item(2, i).Value.ToString

                strSql = " select * from m_shipd_t where invoice='" & strInvoice & "' and items='" & strItem & "' "
                Rs = objDB.GetDataReader(strSql)
                If Rs.Read Then
                    bExist = True
                Else
                    bExist = False
                End If
                Rs.Close()

                If Not bExist Then
                    Dim strExistWhid As String
                    strSql = " select distinct outwhid from m_shipd_t where invoice='" & strInvoice & "' " _
                           & " and partid='" & strPartno & "' "
                    Rs = objDB.GetDataReader(strSql)
                    If Rs.Read Then
                        strExistWhid = Rs(0).ToString
                    Else
                        strExistWhid = ""
                    End If
                    Rs.Close()

                    If strExistWhid = "" Then
                        strSql = " insert into m_shipd_t (invoice, items, partid, eqty, eintime, euserid, flag) " _
                                & " values('" & strInvoice & "', '" & strItem & "', '" & strPartno & "', '" & Qty & "', " _
                                & " getdate(), '" & strUser & "', '1') "
                    Else
                        strSql = " insert into m_shipd_t (invoice, items, partid, eqty, eintime, euserid, flag, outwhid, states) " _
                                & " values('" & strInvoice & "', '" & strItem & "', '" & strPartno & "', '" & Qty & "', " _
                                & " getdate(), '" & strUser & "', '1', '" & strExistWhid & "', '1') " & vbCrLf

                        strSql = strSql & " update m_shipd_t set states = '1' where invoice='" & strInvoice & "' and partid='" & strPartno & "' "
                    End If
                    objDB.ExecSql(strSql)
                Else
                    strSql = " update m_shipd_t set flag='1', eqty='" & Qty & "', eintime=getdate() " _
                           & " ,euserid='" & strUser & "' where invoice='" & strInvoice & "' and items='" & strItem & "' " & vbCrLf

                    'strSql = strSql & " update m_shipd_t set states = '1' where invoice='" & strInvoice & "' and partid='" & strPartno & "' "
                    objDB.ExecSql(strSql)
                End If
                itemString = itemString & "'" & strItem & "'" & ","
            Next i

            itemString = Mid(itemString, 1, itemString.Length - 1)

            MsgBox("保存成功.", MsgBoxStyle.Exclamation, "提示信息")
            Init()

            If g_MInvoice <> "" Then
                Close()
            End If
        Catch ex As Exception
            MainFrame.SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmMgShipInfo", "BtSave_Click", "sys")
        End Try
    End Sub

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click
        ChangeUI(0)
    End Sub

    Private Sub CobCust_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobCust.DropDownClosed
        LoadCustAddress(CobCust.Text)
    End Sub

    Private Sub BtDrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDrop.Click
        Dim str As String

        If MsgBox("確實要刪除[ " & CobInvoice.Text & " ]嗎？", MsgBoxStyle.Question & MsgBoxStyle.YesNo, "確認信息") = MsgBoxResult.Yes Then
            str = DelShipList(CobInvoice.Text)

            If str = "OK" Then
                MsgBox("刪除成功.", MsgBoxStyle.Exclamation, "提示信息")
                Init()
            Else
                MsgBox(str, MsgBoxStyle.Exclamation, "提示信息")
            End If
        End If
    End Sub

    '單元格數據驗証
    Private Sub DGItem_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim intValue As Integer
        Dim strValue As String
        Dim intCol, intRow As Integer

        If DGItem.CurrentCell.RowIndex = DGItem.Rows.Count - 1 Then Exit Sub

        If DGItem.CurrentCell.ColumnIndex = 1 Then
            If DGItem.CurrentCell.Value <> Nothing Then
                strValue = DGItem.CurrentCell.Value.ToString
                intCol = DGItem.CurrentCell.ColumnIndex
                intRow = DGItem.CurrentCell.RowIndex
                If strValue <> "" And Not CheckPartNO(strValue) Then
                    MsgBox("輸入的料號錯誤.", 48, "提示信息")
                    DGItem.CurrentCell.Value = ""
                    DGItem.Item(intCol, intRow).Selected = True
                End If
            End If
        End If

        If DGItem.CurrentCell.ColumnIndex = 2 Then
            If DGItem.CurrentCell.Value <> Nothing Then
                strValue = DGItem.CurrentCell.Value.ToString
                intCol = DGItem.CurrentCell.ColumnIndex
                intRow = DGItem.CurrentCell.RowIndex
                If strValue <> "" And (Integer.TryParse(strValue, intValue) = False Or Mid(strValue, 1, 1) = "-") Then
                    MsgBox("數量隻能輸入數字.", 48, "提示信息")
                    DGItem.CurrentCell.Value = ""
                    DGItem.Item(intCol, intRow).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub CobInvoice_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobInvoice.DropDown
        LoadInvoiceList()
    End Sub

    Private Sub CobInvoice_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobInvoice.SelectedIndexChanged
        BtLoad_Click(sender, e)
    End Sub

    Private Sub CobAddress_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobAddress.SelectedIndexChanged
        Dim intPos As Integer

        intPos = CobAddress.Text.IndexOf("------")
        TxtCusID.Text = Mid(CobAddress.Text, intPos + 7, CobAddress.Text.Length - intPos)
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim ctrTextBox As TextBox

        If DGItem.CurrentCell.ColumnIndex <> 2 Then Exit Sub
        ctrTextBox = CType(sender, TextBox)
        e.Handled = False
        If ctrTextBox.Text = "" AndAlso e.KeyChar = ChrW(Keys.D0) Then
            e.Handled = True
            Exit Sub
        End If
        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub DGItem_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Dim ctrTextBox As New TextBox

        If DGItem.CurrentCell.ColumnIndex = 2 Then
            ctrTextBox = CType(e.Control, TextBox)
            AddHandler ctrTextBox.KeyPress, _
            New KeyPressEventHandler(AddressOf TextBox_KeyPress)
        End If

    End Sub

    Public Function GetAutoInvoiceNo() As String
        Dim strSql As String
        Dim strNo As String
        Dim strReturn As String
        Const strFixCode = "XVZX"

        strNo = ""
        strSql = " select substring(max(invoice), 7, 4) from m_shipd_t where substring(invoice, 1, 4)='" & strFixCode & "' "
        Rs = objDB.GetDataReader(strSql)
        If Rs.Read Then
            strNo = Rs(0).ToString
            strNo = "1" & strNo
            strNo = Mid(CType(CType(strNo, Integer) + 1, String), 2, 4)
        End If
        If strNo = "" Then
            strNo = "0001"
        End If
        Rs.Close()

        strReturn = strFixCode & GetYearMonth() & strNo
        Return strReturn
    End Function

    Private Sub chkCreate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCreate.CheckedChanged
        If chkCreate.Checked Then
            TxtInvoice.Text = GetAutoInvoiceNo()
            TxtInvoice.Enabled = False
        Else
            TxtInvoice.Text = ""
            TxtInvoice.Enabled = True
        End If
    End Sub

    Private Sub FrmMgShipInfo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.N AndAlso e.Alt Then
            BtNew_Click(sender, e)
        ElseIf e.KeyCode = Keys.M AndAlso e.Alt Then
            BtModify_Click(sender, e)
        ElseIf e.KeyCode = Keys.D AndAlso e.Alt Then
            BtDrop_Click(sender, e)
        ElseIf e.KeyCode = Keys.S AndAlso e.Alt Then
            BtSave_Click(sender, e)
        ElseIf e.KeyCode = Keys.C AndAlso e.Alt Then
            BtCancel_Click(sender, e)
        ElseIf e.KeyCode = Keys.E AndAlso e.Alt Then
            BtBack_Click(sender, e)
        End If
    End Sub

    Private Function GetYearMonth() As String
        Dim strSql As String
        Dim strYear, strMonth As String
        Dim strReturn As String

        strYear = ""
        strMonth = ""
        strSql = " select datepart(yy, getdate()), datepart(m, getdate()) "
        Rs = objDB.GetDataReader(strSql)

        If Rs.Read Then
            strYear = Rs(0).ToString
            strYear = Mid(strYear, 4, 1)
            strMonth = Rs(1).ToString
            If strMonth.Length > 1 Then
                If strMonth = "10" Then strMonth = "A"
                If strMonth = "11" Then strMonth = "B"
                If strMonth = "12" Then strMonth = "C"
            End If
        Else
            strReturn = "01"
        End If
        Rs.Close()

        strReturn = strYear & strMonth
        Return strReturn
    End Function

    Private Function GetNowTotalQty() As Integer
        Dim i As Integer
        Dim intTmp As Integer

        intTmp = 0
        For i = 0 To DGItem.Rows.Count - 2
            intTmp += DGItem.Item(2, i).Value
        Next i
        Return intTmp
    End Function

    Private Function GetScanState(ByVal invoice As String, ByVal part As String) As String
        Dim strSql As String
        Dim Rs As SqlDataReader
        Dim strReturn As String

        strSql = " select states from m_shipd_t where invoice='" & invoice & "' and partid='" & part & "' "
        Rs = objDB.GetDataReader(strSql)

        If Rs.Read Then
            strReturn = Rs(0).ToString
        Else
            strReturn = 0
        End If
        Rs.Close()

        Return strReturn
    End Function

    Private Function CheckCanDelete(ByVal invoice As String, ByVal part As String, ByVal qty As Integer) As Boolean
        Dim strSql As String
        Dim intTotalQty As Integer
        Dim intScanQty As Integer
        Dim bReturn As Boolean

        strSql = " select sum(a.eqty) Totalqty, b.shipqty Scanqty " _
               & " from m_shipd_t a, m_whoutm_t b where a.outwhid=b.outwhid " _
               & " and a.invoice='" & invoice & "' and a.partid='" & part & "' " _
               & " group by b.shipqty "
        Rs = objDB.GetDataReader(strSql)
        If Rs.Read() Then
            intTotalQty = Rs(0)
            intScanQty = Rs(1)
        Else
            intTotalQty = 0
            intScanQty = 0
        End If
        Rs.Close()

        intTotalQty += GetNowTotalQty() - intTotalQty

        If intScanQty = 0 Then
            bReturn = True
        Else
            If intScanQty > intTotalQty - qty Then
                bReturn = False
            Else
                bReturn = True
            End If
        End If

        Return bReturn
    End Function

    Private Sub DGItem_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs)
        Dim strPart As String
        Dim strItem As String
        Dim intQty As Integer
        Dim strInvoice As String

        If DGItem.Rows.Count > 0 Then
            strItem = DGItem.Item(0, DGItem.CurrentCell.RowIndex).Value
            strPart = DGItem.Item(1, DGItem.CurrentCell.RowIndex).Value
            intQty = DGItem.Item(2, DGItem.CurrentCell.RowIndex).Value

            If g_New = False Then
                strInvoice = CobInvoice.Text
            Else
                strInvoice = TxtInvoice.Text
            End If

            If CheckCanDelete(strInvoice, strPart, intQty) = False Then
                MsgBox("此項刪除將會導致已掃數量大於出貨數量。如果" & vbCrLf & vbCrLf & "確實需要刪除，請先移除已掃描的數據。", 48, "警告信息")
                e.Cancel = True
            Else
                g_DelSQL = g_DelSQL & " delete from m_shipd_t where invoice='" & strInvoice & "' " _
                                    & " and items='" & strItem & "' and partid='" & strPart & "' "
            End If
        End If
    End Sub

    Private Sub DGItem_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        DGItem.Item(0, DGItem.Rows.Count - 1).Value = DGItem.Rows.Count
    End Sub

    Private Sub CobInvoice_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobInvoice.KeyPress
        If Asc(e.KeyChar) = 13 Then
            BtLoad_Click(sender, e)
        End If
    End Sub

    Private Sub BtDNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDNew.Click
        g_Opcode = 1
        ChangeUID(g_Opcode)

    End Sub

    Private Sub BtDEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDEdit.Click
        If TxtPartNo.Text = "" Then
            MsgBox("請選擇要修改的項次.", 48, "提示信息")
            Exit Sub
        End If
        g_Opcode = 2
        ChangeUID(g_Opcode)
    End Sub

    Private Sub BtDDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDDel.Click
        Dim strState As String
        Dim strInvoice As String

        If TxtPartNo.Text = "" Then
            MsgBox("請選擇要刪除的項次.", 48, "提示信息")
            Exit Sub
        End If

        If g_New = False Then
            strInvoice = CobInvoice.Text.ToUpper.Trim
        Else
            strInvoice = TxtInvoice.Text.ToUpper.Trim
        End If

        strState = GetScanState(strInvoice, TxtPartNo.Text)
        If strState = "2" Or strState = "1" Then
            MsgBox("此料號已開始掃描，不能刪除.", 48, "提示信息")
            Exit Sub
        End If

        DGItem.Rows.RemoveAt(DGItem.CurrentRow.Index)
    End Sub

    Private Sub DGItem_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        TxtItem.Text = DGItem.Item(0, DGItem.CurrentRow.Index).Value.ToString
        TxtPartNo.Text = DGItem.Item(1, DGItem.CurrentRow.Index).Value.ToString
        TxtQty.Text = DGItem.Item(2, DGItem.CurrentRow.Index).Value.ToString
    End Sub

    Private Sub TxtQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQty.KeyPress
        Dim ctrTextBox As TextBox
        ctrTextBox = CType(sender, TextBox)

        If ctrTextBox.Text = "" AndAlso e.KeyChar = ChrW(Keys.D0) AndAlso ctrTextBox.Text.Length > 3 Then
            e.Handled = True
            Exit Sub
        End If

        If (Char.IsDigit(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back)) Then '
            e.Handled = False
        Else
            e.Handled = True
        End If

        If ctrTextBox.Text.Length > 5 Then
            If e.KeyChar = ChrW(Keys.Back) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub BtDReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDReturn.Click
        ChangeUID(0)
    End Sub

    Private Sub BtDConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDConfirm.Click
        Dim strState As String
        Dim strInvoice As String

        If g_Opcode = 1 Then
            If TxtPartNo.Text = "" Then
                MsgBox("請輸入料件編號.", 48, "提示信息")
                TxtPartNo.Focus()
                Exit Sub
            End If

            If Not CheckPartNO(TxtPartNo.Text) Then
                MsgBox("輸入的料號錯誤.", 48, "提示信息")
                TxtPartNo.Text = ""
                TxtPartNo.Focus()
                Exit Sub
            End If

            If TxtQty.Text = "" Then
                MsgBox("請輸入數量.", 48, "提示信息")
                TxtQty.Text = ""
                TxtQty.Focus()
                Exit Sub
            End If

            DGItem.Rows.Add("", TxtPartNo.Text, TxtQty.Text)
        End If

        If g_Opcode = 2 Then
            If g_New = False Then
                strInvoice = CobInvoice.Text.ToUpper.Trim
            Else
                strInvoice = TxtInvoice.Text.ToUpper.Trim
            End If

            strState = GetScanState(strInvoice, TxtPartNo.Text)
            If strState = "2" Then
                MsgBox("此料號已確認出貨，不能更改.（如需要請先做駁回操作）", 48, "提示信息")
                Exit Sub
            End If

            DGItem.Item(2, DGItem.CurrentRow.Index).Value = TxtQty.Text
            TxtQty.Enabled = True
        End If
        ChangeUID(0)
    End Sub

    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBack.Click
        Me.Close()
    End Sub
End Class