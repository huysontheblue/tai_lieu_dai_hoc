Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame

'�ϥΦs�x�L�{ by�Gzhichao_yi Date:2010-06-23

Public Class FrmWhOutQuery

    Private dataSet As New DataSet("dataSet")
    Private strCondition As String
    Private strSaveSql As String
    '  Private strHistory As String
    Private g_Factory As String

#Region "��ødatagridview�椸��,�襤�ɥh���J�I"

    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgMoData.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

#End Region


    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        If Me.DgMoData.RowCount < 1 Then Exit Sub
        ' ObjDB.InportInExcel("select ' ', x.* from  (" & strSaveSql & ") x", "�X�w���ӰO���d��", Me.DgMoData, GetQueryCondition)

        'ObjDB.LoadDataToExcel("�X�w���ӰO���d��", DgMoData, "")
        'LoadDataToOpExcel("�X�w���ӰO���d��", DgMoData, "")
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

        'param(0) = New SqlParameter("@begintime", SqlDbType.Char)    '@begintime   varchar(25),  --�_�l�ɶ�
        'param(0).Value = StartDT

        'param(1) = New SqlParameter("@endtime", SqlDbType.Char)      '@endtime     varchar(25),  --�פ�ɶ�
        'param(1).Value = EndDT

        'param(2) = New SqlParameter("@factoryid", SqlDbType.Char)     '@factoryid    varchar(2),   --���q�O 
        'param(2).Value = g_Factory

        'param(3) = New SqlParameter("@stateid", SqlDbType.Char)     '@stateid      varchar(1),   --�X�w���A all�G%�F1�G���T�{�F2�G�w�T�{
        'If Me.CobOutState.Text <> "0-ALL" Then
        '    param(3).Value = Me.CobOutState.Text
        'Else
        '    param(3).Value = "%"
        'End If


        'param(4) = New SqlParameter("@moid", SqlDbType.Char)     '@moid         varchar(12),  --�u��s�� 
        'If Me.CobWO.Text <> "0-ALL" Then
        '    param(4).Value = Me.CobWO.Text
        'Else
        '    param(4).Value = "%"
        'End If

        'param(5) = New SqlParameter("@partid ", SqlDbType.Char)     '@partid       varchar(20),  --�ƥ�s�� 
        'If Me.CobPartid.Text <> "0-ALL" Then
        '    param(5).Value = Me.CobPartid.Text
        'Else
        '    param(5).Value = "%"
        'End If

        'param(6) = New SqlParameter("@states", SqlDbType.Char)     '@states       varchar(1),   --���y���A all�G%�F1�G���y���F2�G���y�����F3�G�ݽվ�
        'If Me.CobScanState.Text <> "0-ALL" Then
        '    param(6).Value = Me.CobScanState.Text
        'Else
        '    param(6).Value = "%"
        'End If

        'param(7) = New SqlParameter("@cartonid  ", SqlDbType.Char)    '@cartonid      v varchar(35),  --�~�c�s��
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

        'param(9) = New SqlParameter("@outtype", SqlDbType.Char)     '@outtype      varchar(1),   --�X�w���� all�G%�Fo�G���`�X�f�FI:������ơFS�G�˫~�X�f�FT�G��L�X�f�FR�G���u�X�w
        'If Me.CobType.Text <> "0-ALL" Then
        '    param(9).Value = Me.CobType.Text
        'Else
        '    param(9).Value = "%"
        'End If

        'param(10) = New SqlParameter("@outwhid ", SqlDbType.Char)     '@outwhid--�X�w�渹�]�d���`��ƮɼW�[���ءA���Ӯɱo��ȡ^
        'If type = "T" Then
        '    If Me.Cobwh.Text <> "0-ALL" Then
        '        param(10).Value = Me.Cobwh.Text
        '    Else
        '        param(10).Value = "%"
        '    End If
        'Else
        '    param(10).value = cartonid
        'End If


        'param(11) = New SqlParameter("@flag ", SqlDbType.NChar)         '--'T':���`���ơF'D':����Ӹ��
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
                sql = "  select a.Outwhid ��������, a.Intime ��������,c.Intime ��������,'' ��Ʒ�ͺ�,SN SN��,TID ����,EMAC 'WIFI Mac��ַ',WMAC 'RJ Mac��ַ',IMEI '�ƶ��豸��(IMEI)',PN '�������κ�(PN)', '' '����汾��','' 'Ӳ���汾��','' '���İ汾��',c.Cartonid '���',a.Cusid '�ͻ�����',a.Saddress '�����ص�','' '��Ӫ��'  from m_WhOutM_t a inner join m_WhOutD_t b on a.Outwhid=b.Outwhid   left join m_Cartonsn_t c on b.CartonID=c.Cartonid   left join m_A20Box_t d on c.ppid=d.sn inner join dbo.fun_splitToTable('" & ppid & "',',') w on c.Cartonid=w.col1"

            Else
                sql = "  select a.Outwhid ��������, a.Intime ��������,c.Intime ��������,'' ��Ʒ�ͺ�,SN SN��,TID ����,EMAC 'WIFI Mac��ַ',WMAC 'RJ Mac��ַ',IMEI '�ƶ��豸��(IMEI)',PN '�������κ�(PN)', '' '����汾��','' 'Ӳ���汾��','' '���İ汾��',c.Cartonid '���',a.Cusid '�ͻ�����',a.Saddress '�����ص�','' '��Ӫ��'  from m_WhOutM_t a inner join m_WhOutD_t b on a.Outwhid=b.Outwhid   left join m_Cartonsn_t c on b.CartonID=c.Cartonid   left join m_A20Box_t d on c.ppid=d.sn"

            End If
            'Dim sql As String = "  select a.Intime ��������,c.Intime ��������,'' ��Ʒ�ͺ�,SN SN��,TID ����,EMAC 'WIFI Mac��ַ',WMAC 'RJ Mac��ַ',IMEI '�ƶ��豸��(IMEI)',PN '�������κ�(PN)', '' '����汾��','' 'Ӳ���汾��','' '���İ汾��',c.Cartonid '���',a.Cusid '�ͻ�����',a.Saddress '�����ص�','' '��Ӫ��'  from m_WhOutM_t a inner join m_WhOutD_t b on a.Outwhid=b.Outwhid   left join m_Cartonsn_t c on b.CartonID=c.Cartonid   left join m_A20Box_t d on c.ppid=d.sn"

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
                sql = " select a.intime ��װʱ��,IMEI,HARDCODE,QRCODE,WIFIMAC,BTMAC,ICCID,SMINO,a.intime 'Manufacture Date',b.cartonId, GSM_FW,BLE_FW,Model='',Color='' from m_Carton_t b join m_Cartonsn_t a on b.Cartonid=a.Cartonid join dbo.fun_splitToTable('" & ppid & "',',') d on b.Cartonid=d.col1 left join m_W2BarCodes_t c on a.ppid =c.IMEI "

            Else
                sql = " select a.intime ��װʱ��,IMEI,HARDCODE,QRCODE,WIFIMAC,BTMAC,ICCID,SMINO,a.intime 'Manufacture Date',b.cartonId, GSM_FW,BLE_FW,Model='',Color='' from m_Carton_t b join m_Cartonsn_t a on b.Cartonid=a.Cartonid  left join m_W2BarCodes_t c on a.ppid =c.IMEI "

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
            'Rs = ObjDB.GetDataReader("select a.Outwhid,Avcoutid,Orderseq,Partid,Shipqty,scanQty,Cusid,Saddress,case when Shipqty=scanQty then N'Y-����ɨ�����' else N'N-����ɨ��δ���' end States,Userid,Intime,Remark  from dbo.m_WhOutM_t  a join (select SUM(CartonOutqty) scanQty,Outwhid from m_WhOutD_t group by Outwhid) b on a.Outwhid=b.Outwhid  " & Sqlstr)
            Try
                dat = DbOperateReportUtils.GetDataTable("select a.Outwhid �������,Avcoutid TITOP��������,Orderseq ���,Partid �ϼ�����,Shipqty ��������,scanQty ɨ������,Cusid �ͻ�����,Saddress ������ַ,case when Shipqty=scanQty then N'Y-����ɨ�����' else N'N-����ɨ��δ���' end ״̬,Userid ������Ա,Intime ����ʱ��,Remark ��ע  from dbo.m_WhOutM_t  a join (select SUM(CartonOutqty) scanQty,Outwhid from m_WhOutD_t group by Outwhid) b on a.Outwhid=b.Outwhid  " & Sqlstr)
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


        ToolCount.Text = "��¼����:" & DgMoData.RowCount.ToString()
        ToolQty.Text = "����������" & intQty.ToString()

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


        FrmShowDetail.TabTitle = "��������|������|ջ����|��װ����|������Ա|����ʱ��"
        FrmShowDetail.strSQL = "execute [m_QueryWhoutRecode_p] '" & strCondition & "' "
        'Dim sqlparam(1) As SqlParameter
        'sqlparam(0) = New SqlParameter("@outwhid", SqlDbType.Char)    '@begintime   varchar(25),  --�_�l�ɶ�
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
        str = "�_�l�ɶ�:" & DtStar.Value.ToString() & "��" & DtEnd.Value.ToString() & "  " & "�u�t�O:" & CobFactory.Text & " " _
            & "�~�c�s��:" & TxtPpid.Text & "  " & "�ƥ�s��:" & CobPartid.Text _
            & "Invoice No:" & CobOderNo.Text & "  " & "�X�w����:" & CobType.Text
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