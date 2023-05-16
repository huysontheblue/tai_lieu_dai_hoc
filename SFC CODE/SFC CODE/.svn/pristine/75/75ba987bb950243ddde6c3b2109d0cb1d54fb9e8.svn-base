Imports System.Data.SqlClient
Imports System.Data
Imports MainFrame
Imports MesStorgeManage

Module Module1
    Dim Pubclass As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim MyForm As New FrmOutWH2


    Public Sub LoadDataAgainTest()
        Dim StrSql As String
        Dim Rs As SqlDataReader

        MyForm.CobInvoice.Items.Clear()
        'StrSql = " select Invoice from m_Invoicem_t where Stateid='3' and Updatetime>getdate()-30 and Factoryid in (" & g_Rights & ") " & _
        '         "union select InvoiceJob from m_InvoiceS_t where InvoiceJob like'XVZX%'and Intime>getdate()-30"
        'StrSql = "select Invoice from m_Invoicem_t where Stateid='3' and Updatetime>getdate()-30 union " & _
        '         "select InvoiceJob from m_InvoiceS_t where InvoiceJob like'XVZX%'and Intime>getdate()-30 "
        StrSql = " select distinct a.invoice from m_shipm_t a, m_shipd_t b " _
              & " where a.invoice=b.invoice and (b.states='E' or b.states='1') " _
              & " and b.eintime>getdate()-3 and a.usey='Y' " _
              & " and (a.flag<>'2' or a.flag is null)"
        Rs = Pubclass.GetDataReader(StrSql)
        While Rs.Read()
            If Rs(0).ToString() <> "" Then
                MyForm.CobInvoice.Items.Add(Rs(0).ToString())
            End If
        End While
        Rs.Close()

        '加載出貨信息
        LoadShipInfo()

    End Sub

    '加載出貨信息
    Private Sub LoadShipInfo()
        If Trim(MyForm.CobInvoice.Text) = "" Then Exit Sub

        '帶出客戶地址
        Dim Strsql As String
        Dim Rs As SqlDataReader
        '正常出貨
        'Strsql = "select a.Cusid,a.Receaddr,b.SortName from m_Invoicem_t a left join m_Sortset_t b on a.Trantype=" & _
        '         "b.SortnameEn and b.SortType='A' where a.Invoice='" & Trim(Myfrom.CobInvoice.Text) & "'and a.Stateid='3'"
        Strsql = "select b.cusid,b.cusname, b.saddress, c.saddress,a.stateid,a.outtype " _
               & " from m_shipm_t a left join m_custinfo_t b on a.cusid=b.cusid left outer join " _
               & " m_custother_t c on a.cusid=c.cusid where a.invoice='" & Trim(MyForm.CobInvoice.Text) & "' "
        Rs = Pubclass.GetDataReader(Strsql)
        'Invoice版本
        'While Rs.Read
        '    Myfrom.TxtCust.Text = Rs(0).ToString
        '    Myfrom.TxtAddress.Text = Rs(1).ToString
        '    Myfrom.TxtTranType.Text = Rs(2).ToString
        '    Myfrom.LabShipType.Text = "O-正常出貨"
        'End While
        '當前版本
        While Rs.Read
            MyForm.g_CustID = Rs(0).ToString
            MyForm.TxtCust.Text = Rs(1).ToString
            MyForm.TxtAddress.Text = Rs(2).ToString
            If MyForm.TxtAddress.Text = "" Then
                MyForm.TxtAddress.Text = Rs(3).ToString
            End If
            If Rs(4).ToString = "1" Then
                MyForm.LabelState.Text = "未確認"
            ElseIf Rs(4).ToString = "2" Then
                MyForm.LabelState.Text = "已確認出庫"
            End If
            If Rs(5).ToString = "O" Then
                MyForm.LabShipType.Text = "O-正常出貨"
            ElseIf Rs(5).ToString = "I" Then
                MyForm.LabShipType.Text = "I-內部領料"
            ElseIf Rs(5).ToString = "S" Then
                MyForm.LabShipType.Text = "S-樣品出貨"
            ElseIf Rs(5).ToString = "T" Then
                MyForm.LabShipType.Text = "T-其它出貨"
            End If
        End While
        Rs.Close()
        '當前版本------加載Invoice時改變“料號”狀態
        Try
            Pubclass.ExecSql("update m_shipdtotal_t set states= case when eqty>qty then '1' when eqty=qty then '2' " & _
                             "when eqty<qty then '3' end where Invoice='" & Trim(MyForm.CobInvoice.Text) & "'and usey='Y'")
        Catch ex As Exception
            SysCheckData.SysMessageClass.WriteErrLog(ex, "MesWarehouseManage.FrmOutWH2", "PartStateChangedErr", "sys")
            MessageBox.Show("資料變更有誤，請聯系系統管理員！", "錯誤提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        MyForm.PlScan.Enabled = False
        MyForm.TxtCartonid.BackColor = Color.White
        MyForm.TxtPalletID.Text = ""
        MyForm.TxtPalletID.BackColor = Color.White
        MyForm.LabCartCoun.Text = ""
        MyForm.DGShipList.Rows.Clear()
        MyForm.DGScanList.Rows.Clear()
        '加載出貨明細信息
        LoadShipInfoDetail(Trim(MyForm.CobInvoice.Text))
        MyForm.CobInvoice.Enabled = True
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
        MyForm.DGShipList.Rows.Clear()
        ''Invoice版本
        'Strsql = "select a.Partid,a.Shipqty,a.Outwhid,a.Qty,a.Stateid,b.InvoiceJob from m_InvoiceS_t a left join " & _
        '         "m_InvoiceM_t b on a.InvoiceJob=b.InvoiceJob where b.Invoice='" & StrInvoice & "'and b.Stateid='3' " & _
        '         "union select Partid,Shipqty,Outwhid,Qty,Stateid,InvoiceJob from m_InvoiceS_t where InvoiceJob='" & StrInvoice & "'"
        Strsql = "select a.partid,a.Eqty,a.outwhid,a.Qty,a.States from m_shipdtotal_t a left join " & _
                 "m_shipm_t b on a.Invoice=b.Invoice where b.Invoice='" & StrInvoice & "' "
        Rs = Pubclass.GetDataReader(Strsql)
        While Rs.Read
            '已掃描數量
            If Trim(Rs(3).ToString) = "" Then
                IntScanQty = 0
            Else
                IntScanQty = Trim(Rs(3).ToString)
            End If
            '狀態
            If Rs(4).ToString = "0" Then
                StrStatus = "待出庫"
            ElseIf Rs(4).ToString = "1" Then
                StrStatus = "掃描中"
            ElseIf Rs(4).ToString = "2" Then
                StrStatus = "掃描完成"
            ElseIf Rs(4).ToString = "3" Then
                StrStatus = "需調整"
            End If
            If IntScanQty = 0 And Rs(1).ToString = 0 Then StrStatus = "掃描完成"
            'Invoice版本
            ''加載數據項
            'Myfrom.DGShipList.Rows.Add(IntSel, Rs(0).ToString, Rs(1).ToString, IntScanQty, StrStatus, Rs(2).ToString, Rs(5).ToString)
            MyForm.DGShipList.Rows.Add(IntSel, Rs(0).ToString, Rs(1).ToString, IntScanQty, StrStatus, Rs(2).ToString)
        End While
        Rs.Close()

        For i = 0 To MyForm.DGShipList.Rows.Count - 1
            If MyForm.DGShipList.Item(4, i).Value.ToString = "掃描完成" Then
                MyForm.DGShipList.Item(4, i).Style.ForeColor = Color.Red
                MyForm.DGShipList.Item(4, i).Style.SelectionForeColor = Color.Red
            ElseIf MyForm.DGShipList.Item(4, i).Value.ToString = "需調整" Then
                MyForm.DGShipList.Item(4, i).Style.ForeColor = Color.Blue
                MyForm.DGShipList.Item(4, i).Style.SelectionForeColor = Color.Blue
            End If
            '判斷該料號是否需要掃描
            Rs = Pubclass.GetDataReader("select 1 from m_PartPack_t where partid='" & Trim(MyForm.DGShipList.Item(1, i).Value.ToString) & "'")
            If Rs.Read Then
                MyForm.DGShipList.Item(7, i).Value = "需要掃描"
            Else
                MyForm.DGShipList.Item(7, i).Value = "不需要掃描"
            End If
            Rs.Close()
        Next

    End Sub

End Module
