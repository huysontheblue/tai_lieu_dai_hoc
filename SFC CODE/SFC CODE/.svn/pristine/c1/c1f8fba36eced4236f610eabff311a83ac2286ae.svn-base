Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame

'ㄏノ纗筁祘 byzhichao_yi Date:2010-06-23

Public Class FrmWhOutQuery

    Private dataSet As New DataSet("dataSet")
    Private strCondition As String
    Private strSaveSql As String
    '  Private strHistory As String
    Private g_Factory As String

#Region "酶datagridview虫じ,匡い埃礘翴"

    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgMoData.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

#End Region


    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        If Me.DgMoData.RowCount < 1 Then Exit Sub
        ' ObjDB.InportInExcel("select ' ', x.* from  (" & strSaveSql & ") x", "畐灿癘魁琩高", Me.DgMoData, GetQueryCondition)

        'ObjDB.LoadDataToExcel("畐灿癘魁琩高", DgMoData, "")
        'LoadDataToOpExcel("畐灿癘魁琩高", DgMoData, "")
        LoadDataToExcel(Me.DgMoData, Me.Text)
    End Sub
    Private Sub FrmWhOutQuery2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")

        FillComboLine(Me.CobType)
        'FillComboLine(Me.CobPartid)
        'FillComboLine(Me.CobPartid)
        'FillComboLine(Me.Cobwh)
        'FillComboLine(Me.CobCarton)
        'FillComboLine(Me.CobOderNo)
        'FillComboLine(Me.CobWO)
        'CobType.SelectedIndex = 0
        'CobScanState.SelectedIndex = 0
        'CobOutState.SelectedIndex = 0
        ''LoadDataToCombo(CobCus, 1)
        ''FillFactory(CobFactory, "sz30914")
        'FillFactory(CobFactory, MainFrame.SysCheckData.SysMessageClass.UseId)
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        Dim myThread As New Threading.Thread(AddressOf ShowWaitWindow)

        Try
            If CobFactory.Text <> "" Then
                g_Factory = GetFactoryCode(CobFactory.Text)
            Else
                g_Factory = ""
            End If

            DgMoData.Focus()
            If Not CheckDate(DtStar, DtEnd) Then Exit Sub
            myThread.Start()
            ShowWHOutMaster(0)
            Threading.Thread.Sleep(300)
        Finally
            myThread.Abort()
        End Try
    End Sub

    'Private Function GetReplacedSQL(ByVal strSQL As String, ByVal strYear As String, ByVal strQ As String) As String
    '    'Dim str As String
    '    'str = strSQL
    '    'str = Replace(str, "m_whoutm_t", "mesdbnd.dbo.m_whoutm_t" & strYear & strQ)
    '    'str = Replace(str, "m_whoutd_t", "mesdbnd.dbo.m_whoutd_t" & strYear & strQ)
    '    'str = Replace(str, "m_carton_t", "mesdbnd.dbo.m_carton_t" & strYear & strQ)
    '    'str = Replace(str, "m_cartonlot_t", "mesdbnd.dbo.m_cartonlot_t" & strYear & strQ)
    '    'str = Replace(str, "m_snsbarcode_t", "mesdbnd.dbo.m_snsbarcode_t" & strYear & strQ)
    '    'Return str
    'End Function

    Private Function SetSqlparameter(ByVal type As String, ByVal cartonid As String) As SqlParameter()
        'Dim StartDT, EndDT As String
        'StartDT = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        'EndDT = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")

        'Dim Sqlstr As String
        'Sqlstr = " where a.intime between '" & StartDT & "' and  '" & EndDT & "'"

        'If Cobwh.Text <> "" AndAlso LCase(Cobwh.Text) <> "all" Then
        '    Sqlstr = Sqlstr & " and  a.Outwhid='" & Cobwh.Text & "'"
        'End If

        'If ComInvoice.Text <> "" AndAlso LCase(ComInvoice.Text) <> "all" Then
        '    Sqlstr = Sqlstr & " and  a.Avcoutid ='" & ComInvoice.Text & "'"
        'End If
        Dim param(11) As SqlParameter

        'param(0) = New SqlParameter("@begintime", SqlDbType.Char)    '@begintime   varchar(25),  --癬﹍丁
        'param(0).Value = StartDT

        'param(1) = New SqlParameter("@endtime", SqlDbType.Char)      '@endtime     varchar(25),  --沧ゎ丁
        'param(1).Value = EndDT

        'param(2) = New SqlParameter("@factoryid", SqlDbType.Char)     '@factoryid    varchar(2),   --そ 
        'param(2).Value = g_Factory

        'param(3) = New SqlParameter("@stateid", SqlDbType.Char)     '@stateid      varchar(1),   --畐篈 all%1ゼ絋粄2絋粄
        'If Me.CobOutState.Text <> "0-ALL" Then
        '    param(3).Value = Me.CobOutState.Text
        'Else
        '    param(3).Value = "%"
        'End If


        'param(4) = New SqlParameter("@moid", SqlDbType.Char)     '@moid         varchar(12),  --虫絪腹 
        'If Me.CobWO.Text <> "0-ALL" Then
        '    param(4).Value = Me.CobWO.Text
        'Else
        '    param(4).Value = "%"
        'End If

        'param(5) = New SqlParameter("@partid ", SqlDbType.Char)     '@partid       varchar(20),  --ン絪腹 
        'If Me.CobPartid.Text <> "0-ALL" Then
        '    param(5).Value = Me.CobPartid.Text
        'Else
        '    param(5).Value = "%"
        'End If

        'param(6) = New SqlParameter("@states", SqlDbType.Char)     '@states       varchar(1),   --苯磞篈 all%1苯磞い2苯磞ЧΘ3惠秸俱
        'If Me.CobScanState.Text <> "0-ALL" Then
        '    param(6).Value = Me.CobScanState.Text
        'Else
        '    param(6).Value = "%"
        'End If

        'param(7) = New SqlParameter("@cartonid  ", SqlDbType.Char)    '@cartonid      v varchar(35),  --絚絪腹
        'If Me.CobCarton.Text <> "0-ALL" Then
        '    param(7).Value = Me.CobCarton.Text
        'Else
        '    param(7).Value = "%"
        'End If

        'param(8) = New SqlParameter("@invoice ", SqlDbType.Char)     '@invoice      varchar(15),  --invoice 
        'If Me.CobOderNo.Text <> "0-ALL" Then
        '    param(8).Value = Me.CobOderNo.Text
        'Else
        '    param(8).Value = "%"
        'End If

        'param(9) = New SqlParameter("@outtype", SqlDbType.Char)     '@outtype      varchar(1),   --畐摸 all%oタ盽砯I:ず场烩S妓珇砯Tㄤ砯R畐
        'If Me.CobType.Text <> "0-ALL" Then
        '    param(9).Value = Me.CobType.Text
        'Else
        '    param(9).Value = "%"
        'End If

        'param(10) = New SqlParameter("@outwhid ", SqlDbType.Char)     '@outwhid--畐虫腹琩高羆戈糤灿眔结
        'If type = "T" Then
        '    If Me.Cobwh.Text <> "0-ALL" Then
        '        param(10).Value = Me.Cobwh.Text
        '    Else
        '        param(10).Value = "%"
        '    End If
        'Else
        '    param(10).value = cartonid
        'End If


        'param(11) = New SqlParameter("@flag ", SqlDbType.NChar)         '--'T':羆砰戈'D':灿戈
        'param(11).Value = type


        Return param
    End Function

    Private Sub ShowWHOutMaster(ByVal intCheck)
        Dim factory As String = ""
        Dim intQty As Integer
        'Dim strDt As String
        'Dim strCust As String
        'Dim dt As Date
        intQty = 0
        DgMoData.DataSource = Nothing
        DgMoData.Rows.Clear()
        'Dim param(11) As SqlParameter
        'param = SetSqlparameter("T", "")
        Dim StartDT, EndDT As String
        StartDT = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        EndDT = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")

        Dim Sqlstr As String
        Sqlstr = " where a.intime between '" & StartDT & "' and  '" & EndDT & "'"

        If Cobwh.Text <> "" AndAlso LCase(Cobwh.Text) <> "all" Then
            Sqlstr = Sqlstr & " and  a.Outwhid='" & Cobwh.Text & "'"
        End If

        If ComInvoice.Text <> "" AndAlso LCase(ComInvoice.Text) <> "all" Then
            Sqlstr = Sqlstr & " and  a.Avcoutid ='" & ComInvoice.Text & "'"
        End If

        Dim dat As DataTable = New DataTable
        Dim col As DataGridViewColumn = New DataGridViewColumn()
        DgMoData.Columns.Clear()
        Dim ppid As String = ""
        Dim sql As String = ""
        'DgMoData.Columns.CopyTo(col)
        'DgMoData.Rows .
        'Rs = ObjDB.GetDataReader("execute m_QueryWhoutRecode_p @begintime,@endtime,@factoryid,@stateid,@moid,@partid,@states,@cartonid,@invoice,@outtype,@outwhid,@flag", param)
        If CobType.Text.Split("-")(0).ToUpper = "CU0226" Then
            'If CobCarton.Text <> "" AndAlso LCase(CobCarton.Text) <> "all" Then
            '    Sqlstr = Sqlstr & " and  b.Cartonid ='" & CobCarton.Text & "'"
            'End If
            If TxtPpid.Text.Trim <> "" Then
                If TxtPpid.Lines.Length > 0 Then
                    Dim ii As Integer = 0
                    For ii = 0 To TxtPpid.Lines.Length - 1
                        If TxtPpid.Lines(ii).ToString.Trim = "" Then
                            Continue For
                        Else
                            ppid = ppid + TxtPpid.Lines(ii).ToString.Trim + ","
                        End If
                    Next
                    ppid = ppid.Substring(0, ppid.Length - 1)
                End If
                sql = "  select a.Outwhid 出货单号, a.Intime 出货日期,c.Intime 生产日期,'' 产品型号,SN SN号,TID 广电号,EMAC 'WIFI Mac地址',WMAC 'RJ Mac地址',IMEI '移动设备号(IMEI)',PN '生产批次号(PN)', '' '软件版本号','' '硬件版本号','' '包材版本号',c.Cartonid '箱号',a.Cusid '客户代码',a.Saddress '出货地点','' '运营商'  from m_WhOutM_t a inner join m_WhOutD_t b on a.Outwhid=b.Outwhid   left join m_Cartonsn_t c on b.CartonID=c.Cartonid   left join m_A20Box_t d on c.ppid=d.sn inner join dbo.fun_splitToTable('" & ppid & "',',') w on c.Cartonid=w.col1"

            Else
                sql = "  select a.Outwhid 出货单号, a.Intime 出货日期,c.Intime 生产日期,'' 产品型号,SN SN号,TID 广电号,EMAC 'WIFI Mac地址',WMAC 'RJ Mac地址',IMEI '移动设备号(IMEI)',PN '生产批次号(PN)', '' '软件版本号','' '硬件版本号','' '包材版本号',c.Cartonid '箱号',a.Cusid '客户代码',a.Saddress '出货地点','' '运营商'  from m_WhOutM_t a inner join m_WhOutD_t b on a.Outwhid=b.Outwhid   left join m_Cartonsn_t c on b.CartonID=c.Cartonid   left join m_A20Box_t d on c.ppid=d.sn"

            End If
            'Dim sql As String = "  select a.Intime 出货日期,c.Intime 生产日期,'' 产品型号,SN SN号,TID 广电号,EMAC 'WIFI Mac地址',WMAC 'RJ Mac地址',IMEI '移动设备号(IMEI)',PN '生产批次号(PN)', '' '软件版本号','' '硬件版本号','' '包材版本号',c.Cartonid '箱号',a.Cusid '客户代码',a.Saddress '出货地点','' '运营商'  from m_WhOutM_t a inner join m_WhOutD_t b on a.Outwhid=b.Outwhid   left join m_Cartonsn_t c on b.CartonID=c.Cartonid   left join m_A20Box_t d on c.ppid=d.sn"

            Try
                dat = DbOperateReportUtils.GetDataTable(sql & Sqlstr)
                intQty = dat.Rows.Count
                DgMoData.DataSource = dat
                dat.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        ElseIf CobType.Text.Split("-")(0).ToUpper = "CU0230" Then
            If TxtPpid.Text.Trim <> "" Then
                If TxtPpid.Lines.Length > 0 Then
                    Dim ii As Integer = 0
                    For ii = 0 To TxtPpid.Lines.Length - 1
                        If TxtPpid.Lines(ii).ToString.Trim = "" Then
                            Continue For
                        Else
                            ppid = ppid + TxtPpid.Lines(ii).ToString.Trim + ","
                        End If
                    Next
                    ppid = ppid.Substring(0, ppid.Length - 1)
                End If
                sql = " select a.intime 包装时间,IMEI,HARDCODE,QRCODE,WIFIMAC,BTMAC,ICCID,SMINO,a.intime 'Manufacture Date',b.cartonId, GSM_FW,BLE_FW,Model='',Color='' from m_Carton_t b join m_Cartonsn_t a on b.Cartonid=a.Cartonid join dbo.fun_splitToTable('" & ppid & "',',') d on b.Cartonid=d.col1 left join m_W2BarCodes_t c on a.ppid =c.IMEI "

            Else
                sql = " select a.intime 包装时间,IMEI,HARDCODE,QRCODE,WIFIMAC,BTMAC,ICCID,SMINO,a.intime 'Manufacture Date',b.cartonId, GSM_FW,BLE_FW,Model='',Color='' from m_Carton_t b join m_Cartonsn_t a on b.Cartonid=a.Cartonid  left join m_W2BarCodes_t c on a.ppid =c.IMEI "

            End If
            Try
                dat = DbOperateReportUtils.GetDataTable(sql & Sqlstr)
                intQty = dat.Rows.Count
                DgMoData.DataSource = dat
                dat.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        Else
            'Rs = ObjDB.GetDataReader("select a.Outwhid,Avcoutid,Orderseq,Partid,Shipqty,scanQty,Cusid,Saddress,case when Shipqty=scanQty then N'Y-出货扫描完成' else N'N-出货扫描未完成' end States,Userid,Intime,Remark  from dbo.m_WhOutM_t  a join (select SUM(CartonOutqty) scanQty,Outwhid from m_WhOutD_t group by Outwhid) b on a.Outwhid=b.Outwhid  " & Sqlstr)
            Try
                dat = DbOperateReportUtils.GetDataTable("select a.Outwhid 出货编号,Avcoutid TITOP出货单号,Orderseq 项次,Partid 料件编码,Shipqty 出货数量,scanQty 扫描数量,Cusid 客户代码,Saddress 出货地址,case when Shipqty=scanQty then N'Y-出货扫描完成' else N'N-出货扫描未完成' end 状态,Userid 出货人员,Intime 操作时间,Remark 备注  from dbo.m_WhOutM_t  a join (select SUM(CartonOutqty) scanQty,Outwhid from m_WhOutD_t group by Outwhid) b on a.Outwhid=b.Outwhid  " & Sqlstr)
                'Me.DgMoData.Columns.Clear()
                Me.DgMoData.DataSource = Nothing
                'dat = ObjDB.GetDataTable(Sql & Sqlstr)
                intQty = dat.Rows.Count
                DgMoData.DataSource = dat
                dat.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


            'Do While Rs.Read


            '    DgMoData.Rows.Add(intCheck, Rs("Outwhid").ToString, Rs("Avcoutid").ToString, Rs("Orderseq").ToString, Rs("Partid").ToString, _
            '                      Rs("Shipqty").ToString, strCust, Rs("scanQty").ToString, Rs("Cusid").ToString, Rs("Saddress").ToString, Rs("States").ToString, Rs("Remark").ToString, _
            '                     Rs("userid").ToString, strDt, Rs("Intime").ToString)
            '    intQty += Rs("shipqty")
            '    DgMoData.Item(1, 0).Selected = True
            'Loop
            'Rs.Close()
        End If


        ToolCount.Text = "记录笔数:" & DgMoData.RowCount.ToString()
        ToolQty.Text = "出货数量：" & intQty.ToString()

    End Sub

    Private Sub FillComboLine(ByVal FillComBox As ComboBox)
        'FillComBox.Items.Clear()
        'FillComBox.Items.Add("0-ALL")
        'FillComBox.SelectedIndex = 0
        If FillComBox.Name = "CobType" Then

            Dim strSQL As String = "select CusID +'-'+ CusName from m_Customer_t"
            Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSQL)

            UIHandler.UIFunction.Fill_ComboboxBlank(dt, FillComBox)

            'Try
            '    Dim CheckRead As SqlDataReader = ObjDB.GetDataReader("select CusID,CusName from m_Customer_t")
            '    If CheckRead.HasRows Then
            '        While CheckRead.Read
            '            FillComBox.Items.Add(CheckRead!CusID & "-" & CheckRead!CusName)
            '        End While
            '    End If
            '    CheckRead.Close()
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            'Finally
            '    ObjDB.PubConnection.Close()
            'End Try

        End If



        ' FillComBox.Text = FillComBox.Items.Item(0)
    End Sub

    Private Sub ConnectChang(ByVal sender As Object, ByVal e As System.EventArgs) Handles CobPartid.TextChanged, _
         CobOderNo.TextChanged, _
        CobType.TextChanged, CobFactory.TextChanged
        Me.DgMoData.DataSource = Nothing
        Me.DgMoData.Rows.Clear()
        Me.ToolQty.Text = ""
    End Sub

    Private Sub MenuItemAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strValue As String
        Dim bSelect As Boolean

        For i As Integer = 0 To DgMoData.Rows.Count - 1
            DgMoData.Item(0, i).Value = 1
            DgMoData.Item(4, 1).Selected = True
            bSelect = DgMoData.Item(0, i).Value
            strValue = DgMoData.Item(1, i).Value.ToString()
        Next
    End Sub

    Private Sub DgMoData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMoData.CellClick
        'Dim strValue As String
        'Dim bSelect As Boolean
        'Dim intRow, intCol As Integer

        'intCol = e.ColumnIndex
        'intRow = e.RowIndex

        'If intCol = 0 And intRow >= 0 Then
        '    If DgMoData.Item(0, intRow).Value.ToString = "0" Then
        '        DgMoData.Item(0, intRow).Value = "1"
        '    Else
        '        DgMoData.Item(0, intRow).Value = "0"
        '    End If
        '    strValue = DgMoData.Item(1, intRow).Value.ToString()
        '    bSelect = DgMoData.Item(0, intRow).Value
        'End If
    End Sub

    Private Sub ShowDetail(ByVal strKey As String)
        Dim FrmShowDetail As New FrmShowDetail

        strCondition = ""
        If strKey <> "" Then
            strCondition = strKey
        Else
            Exit Sub
        End If


        FrmShowDetail.TabTitle = "出货单号|外箱编号|栈板编号|包装数量|出库人员|出库时间"
        FrmShowDetail.strSQL = "execute [m_QueryWhoutRecode_p] '" & strCondition & "' "
        'Dim sqlparam(1) As SqlParameter
        'sqlparam(0) = New SqlParameter("@outwhid", SqlDbType.Char)    '@begintime   varchar(25),  --癬﹍丁
        'sqlparam(0).Value = strCondition

        ''param(0).Value = StartDT
        'FrmShowDetail.Sqlparam = sqlparam
        FrmShowDetail.ShowDialog()

    End Sub

    Private Sub MenuItemNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DgMoData.RowCount > 0 Then
            ToolReflsh_Click(sender, e)
        End If
    End Sub

    Private Sub MenuItemAll_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemAll.Click
        DgMoData.Rows.Clear()
        ShowWHOutMaster(1)
    End Sub

    Private Sub MenuItemNone_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemNone.Click
        If DgMoData.RowCount > 0 Then
            ToolReflsh_Click(sender, e)
        End If
    End Sub

    Private Sub MenuItemDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDetail.Click

        DgMoData.Item(2, 0).Selected = True
        ShowDetail("")
    End Sub

    Private Sub DgMoData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMoData.CellDoubleClick
        Dim str As String
        If e.RowIndex = -1 Then Exit Sub
        str = DgMoData.Rows(e.RowIndex).Cells(0).Value.ToString()
        ShowDetail(str)
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If DgMoData.RowCount <= 0 Then
            MenuItemAll.Enabled = False
            MenuItemNone.Enabled = False
            MenuItemDetail.Enabled = False
        Else
            MenuItemAll.Enabled = True
            MenuItemNone.Enabled = True
            MenuItemDetail.Enabled = True
        End If
    End Sub

    Private Function GetQueryCondition() As String
        Dim str As String
        str = "癬﹍丁:" & DtStar.Value.ToString() & "" & DtEnd.Value.ToString() & "  " & "紅:" & CobFactory.Text & " " _
            & "絚絪腹:" & TxtPpid.Text & "  " & "ン絪腹:" & CobPartid.Text _
            & "Invoice No:" & CobOderNo.Text & "  " & "畐摸:" & CobType.Text
        Return str
    End Function


    Private Sub ToolShowDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolShowDetail.Click

        Dim str As String
        If DgMoData.CurrentRow.Index = -1 Then Exit Sub
        str = DgMoData.Rows(DgMoData.CurrentRow.Index).Cells(1).Value.ToString()
        ShowDetail(str)

    End Sub

    '2009-08-30 by tangxiang ----
#Region "Enter-->Tab"

    Private Sub CobType_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobType.KeyPress
        If e.KeyChar = Chr(13) Then
            ToolReflsh_Click(sender, e)
        End If
    End Sub

    Private Sub DtStar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtStar.KeyPress, DtEnd.KeyPress, CobWO.KeyPress, CobScanState.KeyPress, CobPartid.KeyPress, CobOutState.KeyPress, CobOderNo.KeyPress, CobFactory.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

#End Region

    Private Sub DgMoData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMoData.CellContentClick

        'Dim str As String
        'If DgMoData.CurrentRow.Index = -1 Then Exit Sub
        'str = DgMoData.Rows(DgMoData.CurrentRow.Index).Cells(0).Value.ToString()
        'ShowDetail(str)

    End Sub
End Class