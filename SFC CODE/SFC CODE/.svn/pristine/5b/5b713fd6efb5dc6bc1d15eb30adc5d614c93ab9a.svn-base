

#Region "类库导入"
Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports LXWarehouseManage
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports NPOI.HSSF.UserModel
#End Region


Public Class FrmWmsOutter

    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass ''定义窗体级全局变量
    Dim RowIndex As Integer = -1
    Dim _dt As DateTime = DateTime.Now
    ''' <summary>
    ''' </summary>
    ''' <param name="sender">栈板扫描时</param>
    ''' <param name="e">2014年1月11日 ouxiangfeng</param>
    ''' <remarks>昆山联滔出货报表生成</remarks>
    Private Sub radPallet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radPallet.CheckedChanged

        TxtCarton.Enabled = False
        TxtCarton.Clear()
        TxtPalletId.Enabled = True
        TxtPalletId.Clear()
        TxtPalletId.Focus()

    End Sub


    ''' <summary>
    ''' </summary>
    ''' <param name="sender">外箱扫描时</param>
    ''' <param name="e">2014年1月11日 ouxiangfeng</param>
    ''' <remarks>昆山联滔出货报表生成</remarks>
    Private Sub RadPack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadPack.CheckedChanged

        TxtCarton.Enabled = True
        TxtCarton.Clear()
        TxtCarton.Focus()
        TxtPalletId.Enabled = False
        TxtPalletId.Clear()

    End Sub

    ''' <summary>
    ''' </summary>
    ''' <param name="sender">栈板外箱扫描</param>
    ''' <param name="e">2014年1月11日 ouxiangfeng</param>
    ''' <remarks>昆山联滔出货报表生成</remarks>
    Private Sub RadPalltPack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadPalltPack.CheckedChanged

        TxtCarton.Enabled = False
        TxtCarton.Clear()
        TxtPalletId.Enabled = True
        TxtPalletId.Clear()
        TxtPalletId.Focus()

    End Sub

#Region "栈板扫描"
    Private Sub TxtPalletId_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPalletId.KeyPress

        If Me.GetNowRowIndex = -1 Then
            TxtPalletId.Clear()
            Me.LblMsg.Text = "请选择出货的明细项..."
            Exit Sub
        End If
        Dim tempDt As DateTime = DateTime.Now '保存按键按下时刻的时间点
        Dim ts As TimeSpan = tempDt.Subtract(_dt) '获取时间间隔
        Dim WhFlag As Boolean = False
        'If ts.Milliseconds > 50 Then

        '    '判断时间间隔，如果时间间隔大于50毫秒，则将TextBox清空 
        '    Me.TxtPalletId.Text = ""
        '    _dt = tempDt
        '    Me.LblMsg.Text = "不允许手工键盘录入及复制拷贝,请使用扫描枪作业..."
        '    Me.TxtPalletId.Text = ""
        '    Return
        'End If

        If e.KeyChar = Chr(13) Then
            If TxtPalletId.Text = "" Then
                LblMsg.Text = "栈板条码序号,不能为空......"
                TxtPalletId.Clear()
                Exit Sub
            End If
            Dim mRead As SqlDataReader
            mRead = Conn.GetDataReader("select b.partid,Qty from m_snsbarcode_t a join m_mainmo_t b on a.moid=b.moid where sbarcode='" & TxtPalletId.Text & "'")
            If mRead.HasRows = False Then
                LblMsg.Text = "栈板条码序号:" & "【" & TxtPalletId.Text & "】,不存在......"
                TxtPalletId.Clear()
                mRead.Close()
                Conn.PubConnection.Close()
                Exit Sub
            Else
                While mRead.Read
                    LblPalletQty.Text = mRead!Qty
                    LblPartid.Text = mRead!partid
                End While
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            If LblPartid.Text <> dgOgbList.Rows(RowIndex).Cells("ColPartid").Value Then
                LblMsg.Text = "栈板所属料号与出货单项的料件编号不符..."
                Exit Sub
            End If




            Dim Sqlstr As String
            Dim NewWhidNo As String = ""
            mRead = Conn.GetDataReader("select Outwhid from m_WhOutM_t where Avcoutid='" & cobOutShNo.Text & "' and Orderseq='" & dgOgbList.Rows(RowIndex).Cells("ColItem").Value & "'")
            If mRead.HasRows Then
                While mRead.Read
                    TxtOpNo.Text = mRead!Outwhid
                End While
            Else
                TxtOpNo.Text = ""
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            If TxtOpNo.Text = "" Then
                Sqlstr = "select  dbo.GetCostBillID('INV',getdate()) as Outwhid"
                mRead = Conn.GetDataReader(Sqlstr)
                If mRead.HasRows Then
                    While mRead.Read
                        NewWhidNo = mRead.GetString(0)
                    End While
                Else
                    mRead.Close()
                    Conn.PubConnection.Close()
                    LblMsg.Text = "系统在自动生成出货单号时,发生错误..."
                    Exit Sub
                End If
                mRead.Close()
                Conn.PubConnection.Close()
            Else
                NewWhidNo = TxtOpNo.Text
            End If

            Dim mPallQty As String = "0"
            mRead = Conn.GetDataReader("select isnull(count(*),0) PallQty from m_WhOutD_t where Outwhid='" & NewWhidNo & "' and PallteID='" & TxtPalletId.Text & "'")
            If mRead.HasRows Then
                While mRead.Read
                    mPallQty = mRead!PallQty
                End While
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            LabCartCoun.Text = mPallQty

            'mRead = Conn.GetDataReader("select 1 from m_WhOutM_t where Avcoutid='" & cobOutShNo.Text & "' and Orderseq= '" & dgOgbList.Rows(RowIndex).Cells("ColItem").Value & "'")
            'If mRead.HasRows Then
            '    WhFlag = True
            'End If
            'mRead.Close()
            Dim MarkSel As String = ""
            Dim Cursor As String = ""
            If InStr(TxtCusor.Text, "-") > 0 Then
                Cursor = TxtCusor.Text.Split("-")(0)
            End If
            If RadPack.Checked = True Then MarkSel = "0" : If radPallet.Checked = True Then MarkSel = "1" : If RadPalltPack.Checked = True Then MarkSel = "2"
            If TxtOpNo.Text = "" Then
                TxtOpNo.Text = NewWhidNo
                Sqlstr = " insert into m_WhOutM_t(Outwhid,Avcoutid,Partid,Cusid,Orderseq,Saddress,Shipqty,States,Outtype,Remark,Userid,Intime)values(" & _
                        "'" & TxtOpNo.Text & "','" & cobOutShNo.Text & "','" & LblPartid.Text & "','" & Cursor & "'," & _
                       " '" & dgOgbList.Rows(RowIndex).Cells("ColItem").Value & "','" & TxtAddr.Text & "', " & _
                       "'" & dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value & "','N','O','" & MarkSel & "','" & SysMessageClass.UseId & "',getdate())"
                Conn.ExecSql(Sqlstr)
                Conn.PubConnection.Close()
            End If

            If radPallet.Checked Then
                Dim PalltePackQty As Integer = 0
                mRead = Conn.GetDataReader("select a.Cartonid,b.Cartonqty from m_PalletCarton_t a join m_carton_t b on a.cartonid=b.cartonid where Palletid='" & TxtPalletId.Text & "' ")
                If mRead.HasRows Then
                    While mRead.Read
                        dgScanData.Rows.Add(False, LblPartid.Text, mRead!Cartonid, mRead!Cartonqty, SysMessageClass.UseId, Now, TxtPalletId.Text)
                        PalltePackQty = PalltePackQty + CInt(mRead!Cartonqty)
                        Sqlstr = Sqlstr & vbNewLine & " insert into m_WhOutD_t(Outwhid,CartonID,PallteID,CartonOutqty,UserID,Intime)values('" & TxtOpNo.Text & "','" & mRead!Cartonid & "','" & TxtPalletId.Text & "','" & mRead!Cartonqty & "','" & SysMessageClass.UseId & "',getdate())"
                    End While
                End If
                mRead.Close()
                Conn.PubConnection.Close()
                If dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value = PalltePackQty Then
                    Sqlstr = " update m_WhOutM_t set Shipqty='" & PalltePackQty & "',States='Y' where Avcoutid='" & cobOutShNo.Text & "' and Orderseq= '" & dgOgbList.Rows(RowIndex).Cells("ColItem").Value & "'"
                ElseIf dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value < PalltePackQty Then
                    TxtPalletId.Clear()
                    LblMsg.Text = "栈板包装数据大于出货单的出货数量..."
                    Exit Sub
                End If
                Try
                    Conn.ExecSql(Sqlstr)
                    Conn.PubConnection.Close()
                    LblMsg.Text = "栈板条码扫描成功..."
                Catch ex As Exception
                    LblMsg.Text = "栈板扫描时发生异常:" & ex.Message
                End Try
                LblMsg.Text = "栈板条码扫描成功..."
                TxtPalletId.Clear()
                TxtPalletId.Focus()
            ElseIf RadPalltPack.Checked Then
                LblMsg.Text = "栈板条码扫描成功..."
                TxtPalletId.Enabled = False
                TxtCarton.Enabled = True
                TxtCarton.Clear()
                TxtCarton.Focus()
            End If

        End If

    End Sub
#End Region


    Private Sub FrmWmsOutter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InitControlStatus()
        LoadOgbIncombo()
        Me.ActiveControl = Me.cobOutShNo
    End Sub

    Private Sub LoadOgbIncombo()

        Try
            Dim OracleObject As New OracleDb("")
            Dim DsObject As New DataSet()
            DsObject = OracleObject.ExecuteQuery("select distinct oga01 from " & VbCommClass.VbCommClass.Factory & ".oga_file  inner join " & VbCommClass.VbCommClass.Factory & ".ogb_file   " & _
            "on ogb01=oga01  where oga09 not in('1','5') and oga55='1' and ogapost='N' ")
            For Each cc As DataRow In DsObject.Tables(0).Rows
                cobOutShNo.Items.Add(cc(0).ToString())
            Next
        Catch ex As Exception
            LblMsg.Text = ex.Message
        End Try

    End Sub

    Private Sub InitControl()

        lblPqty.Text = "0"
        LblMsg.Text = "提示信息..."
        'this.LblCus.Text = "";
        LabCartCoun.Text = "0"
        'DgOutList.Rows.Clear()
        dgOgbList.Rows.Clear()
    End Sub

    Private Sub cobOutShNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cobOutShNo.KeyPress

        cobOutShNo.DroppedDown = True
        If e.KeyChar = Chr(13) Then
            cobOutShNo_SelectedIndexChanged(sender, e)
        End If

    End Sub

    Private Sub cobOutShNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobOutShNo.SelectedIndexChanged

        RowIndex = -1
        InitControlStatus()
        InitControl()
        Dim OracleObject As New OracleDb("")
        Dim DsObject As New DataSet()
        Dim sqlstr As String = ""
        sqlstr = "select 'false',OGB03,OGB04,OGB12,0 scanqty,'N' status,ogb11,oga04,oga044,ocd02,occ02,occ241  from " & VbCommClass.VbCommClass.Factory & ".ogb_file a  join " & VbCommClass.VbCommClass.Factory & ".oga_file t on a.ogb01=t.oga01  " & _
        " left join " & VbCommClass.VbCommClass.Factory & ".ocd_file e on t.oga04=e.ocd01 left join " & VbCommClass.VbCommClass.Factory & ".occ_file b on b.occ01=t.oga04 where  ogb01='" + cobOutShNo.Text + "' order by OGB03"
        DsObject = OracleObject.ExecuteQuery(sqlstr)
        For Each cc As DataRow In DsObject.Tables(0).Rows
            ''//this.DgOutList.Rows.Add(cc[0].ToString(), cc[1].ToString(), cc[2].ToString(), cc[3].ToString(), cc[4].ToString(), cc[5].ToString(), cc[6].ToString());
            dgOgbList.Rows.Add(cc(0).ToString(), cc(1).ToString(), cc(2).ToString(), cc(3).ToString(), cc(4).ToString(), cc(5).ToString(), cc(6).ToString())
            TxtCusor.Text = cc("oga04").ToString() & "-" & cc("occ02").ToString()
            TxtAddr.Text = cc("occ241").ToString()
            'TxtAddr.Text = cc("ocd02").ToString()
            'If (cc(5).ToString() = "Y") Then
            '    '' //DgOutList.Rows[DgOutList.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(228,242,249);
            '    dgOgbList.Rows(dgOgbList.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(228, 242, 249)
            '    ''//DgOutList.Rows[DgOutList.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.White;
            'End If
        Next

    End Sub


#Region "获取当前行号"
    Public Function GetNowRowIndex() As Integer

        'Dim i As Integer = 0
        Dim intReturn As Integer = 0
        intReturn = -1
        For i As Integer = 0 To dgOgbList.Rows.Count - 1
            If dgOgbList.Rows(i).Cells(0).FormattedValue.ToString() = "True" Then
                intReturn = i
                Exit For '' // TODO: might not be correct. Was : Exit For
            End If
        Next
        Return intReturn

    End Function
#End Region

#Region "初始化时控件的状态"
    Private Sub ToolInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolInit.Click

        InitControlStatus()

    End Sub

    Private Sub InitControlStatus()
        ''TxtPartid.Clear ();
        ''TxtPartid.Enabled=false;
        ''TxtPartid.Focus();
        TxtCarton.Clear()
        TxtCarton.Enabled = True
        ''TxtCartonQty.Clear();
        ''TxtCartonQty.Enabled=false ;
        If (VbCommClass.VbCommClass.Factory = "LXXT" And VbCommClass.VbCommClass.profitcenter = "SEE-D") Then
            Me.TabControlScan.SelectedIndex = 1
        Else
            Me.TabControlScan.SelectedIndex = 0
        End If
    End Sub

#End Region

#Region "退出窗体"
    Private Sub BtBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBack.Click

        Me.Close()

    End Sub
#End Region

    Private Sub cobOutShNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobOutShNo.TextChanged

        dgScanData.Rows.Clear()
        dgOgbList.Rows.Clear()

    End Sub

    Private Sub TxtCarton_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCarton.KeyPress

        If Me.GetNowRowIndex = -1 Then
            TxtCarton.Clear()
            Me.LblMsg.Text = "请选择出货的明细项..."
            Exit Sub
        End If
        'Dim tempDt As DateTime = DateTime.Now '保存按键按下时刻的时间点
        'Dim ts As TimeSpan = tempDt.Subtract(_dt) '获取时间间隔
        'If ts.Milliseconds > 50 Then

        '    '判断时间间隔，如果时间间隔大于50毫秒，则将TextBox清空 
        '    Me.TxtCarton.Text = ""
        '    _dt = tempDt
        '    Me.LblMsg.Text = "不允许手工键盘录入及复制拷贝,请使用扫描枪作业..."
        '    Me.TxtCarton.Text = ""
        '    Return
        'End If
        If RadPalltPack.Checked = True And TxtPalletId.Text = "" Then
            Me.LblMsg.Text = "选择:栈板+外箱出货扫描模式时,栈板编号不能为空..."
            Exit Sub
        End If

        If e.KeyChar = Chr(13) Then
            If TxtCarton.Text.Trim = "" Then
                Me.LblMsg.Text = "外箱条码序号,不能为空..."
                Exit Sub
            End If
            Dim Mread As SqlDataReader
            Dim PackQty As Integer = 0
            Dim PackStatus As String = ""
            Dim Lindid As String = ""
            Dim StateStar As String = ""
            Dim StateEnd As String = ""
            Dim StateStr As String = ""
            Dim fppid As String = ""
            Mread = Conn.GetDataReader("select top 1 Cartonqty,CartonStatus,Teamid,b.ppid from m_Carton_t a left join m_CartonSN_t b on a.Cartonid=b.Cartonid where a.cartonid='" & TxtCarton.Text & "'")
            If Mread.HasRows Then
                While Mread.Read
                    PackQty = Mread!Cartonqty
                    PackStatus = Mread!CartonStatus
                    Lindid = Mread!Teamid
                    fppid = Mread!ppid
                End While
            Else
                Me.LblMsg.Text = "该外箱条码不存在,或未进行包装记录..."
                Mread.Close()
                Conn.PubConnection.Close()
                TxtCarton.Clear()
                Exit Sub
            End If
            Mread.Close()
            Conn.PubConnection.Close()

            Mread = Conn.GetDataReader("select isnull(State,'') StateStr,isnull(StateBegin,'') StateBegin,isnull(StateEnd,'') StateEnd from m_Dline_t where Lineid='" & Lindid & "'")
            If Mread.HasRows Then
                While Mread.Read
                    StateStr = Mread!StateStr
                    StateStar = Mread!StateBegin
                    StateEnd = Mread!StateEnd
                End While
            End If
            Mread.Close()
            Conn.PubConnection.Close()
            Dim LineState As String = ""
            Dim PartState As String = ""
            If StateStr = "Y" Then
                Dim mSqlLine As String = ""
                'If StateStar = "" Or StateEnd = "" Then
                '    mSqlLine = " select 1 from m_Carton_t where cartonid='" & TxtCarton.Text & "' and Teamid='" & Lindid & "'"
                '    'Me.LblMsg.Text = "该外箱条码所在的线别被冻结，不允许出货扫描..."
                '    'TxtCarton.Clear()
                '    'Exit Sub
                'Else
                If StateStar <> "" Then
                    mSqlLine = " select 1 from m_Carton_t where cartonid='" & TxtCarton.Text & "' and Teamid='" & Lindid & "' and intime between '" & StateStar & "' and '" & StateEnd & "'"
                End If
                Mread = Conn.GetDataReader(mSqlLine)
                If Mread.HasRows Then
                    Mread.Close()
                    Conn.PubConnection.Close()
                    LineState = "D"
                    'Me.LblMsg.Text = "该外箱条码所在的线别：" & Lindid & "被冻结，不允许出货扫描" & StateStar & "~" & StateEnd
                    'TxtCarton.Clear()
                    'Exit Sub
                Else
                    LineState = "Y"
                End If
                Mread.Close()
                Conn.PubConnection.Close()

                mSqlLine = "select UseY from m_PartContrast_t where TAvcPart=PAvcPart and TAvcPart='" & LblPartid.Text & "'"
                Mread = Conn.GetDataReader(mSqlLine)
                If Mread.HasRows Then
                    While Mread.Read
                        PartState = Mread!UseY
                    End While
                End If
                Mread.Close()
                Conn.PubConnection.Close()

            End If


            If LineState = "D" And PartState = "D" Then
                Me.LblMsg.Text = "线别：" & Lindid & ",在" & StateStar & "--" & StateEnd & "时间段生产的产品被冻结，不允许出货扫描..."
                TxtCarton.Clear()
                Exit Sub
            End If


            If LineState = "D" And PartState = "Y" Then
                Me.LblMsg.Text = "线别：" & Lindid & ",在" & StateStar & "--" & StateEnd & "时间段生产的所有产品被冻结，不允许出货扫描..."
                TxtCarton.Clear()
                Exit Sub
            End If

            If LineState = "Y" And PartState = "D" Then
                Me.LblMsg.Text = "当前料号的所有产品被冻结，不允许出货扫描..."
                TxtCarton.Clear()
                Exit Sub
            End If


            If PackStatus = "O" Then
                Me.LblMsg.Text = "该外箱条码已经进行出货扫描,请检查外箱是否重复或实物未出货..."
                TxtCarton.Clear()
                Conn.PubConnection.Close()
                Exit Sub
            End If
            If PackStatus <> "Y" Then
                Me.LblMsg.Text = "该外箱条码未进行包装完成,或被作废或被替换..."
                TxtCarton.Clear()
                Conn.PubConnection.Close()
                Exit Sub
            End If
            Mread = Conn.GetDataReader("select 1  from m_WhOutD_t where cartonid='" & TxtCarton.Text & "'")
            If Mread.HasRows Then
                Mread.Close()
                Me.LblMsg.Text = "外箱条码已经进行出货扫描,请检查外箱是否重复或实物未出货..."
                TxtCarton.Clear()
                Conn.PubConnection.Close()
                Exit Sub
            End If
            Mread.Close()

            If chk_checkno.Checked Then
                Mread = Conn.GetDataReader("select 1  from m_PpidCheckRecord_t where cartonid='" & TxtCarton.Text & "'")
                If Mread.HasRows = False Then
                    Mread.Close()
                    Me.LblMsg.Text = "该外箱条码未进行条码检验作业,不允许出货扫描..."
                    TxtCarton.Clear()
                    Conn.PubConnection.Close()
                    Exit Sub
                End If
                Mread.Close()
                Conn.PubConnection.Close()
            End If

            If RadPalltPack.Checked = True Then
                If CInt(LabCartCoun.Text) + 1 > CInt(LblPalletQty.Text) Then
                    Me.LblMsg.Text = "该栈板已经包装完成,不允许再进行外箱包装..."
                    TxtCarton.Clear()
                    TxtCarton.Enabled = False
                    TxtPalletId.Clear()
                    TxtPalletId.Enabled = True
                    TxtPalletId.Focus()
                    Conn.PubConnection.Close()
                    Exit Sub
                End If
            End If
            'If RadPalltPack.Checked = True Then
            '    Mread = Conn.GetDataReader("select Palletid  from m_PalletCarton_t where  cartonid='" & TxtCarton.Text & "'")
            '    If Mread.HasRows Then
            '        While Mread.Read
            '            If TxtPalletId.Text.Trim <> Mread!Palletid Then
            '                Mread.Close()
            '                Me.LblMsg.Text = "当前扫描外箱条码不属于当前栈板条码：【" & TxtPalletId.Text & "】..."
            '                TxtCarton.Clear()
            '                Exit Sub
            '            End If
            '        End While
            '    End If
            'End If
            'Mread.Close()
            Dim Sqlstr As String = ""
            Dim MarkSel As String = ""
            If RadPack.Checked = True Then MarkSel = "0" : If radPallet.Checked = True Then MarkSel = "1" : If RadPalltPack.Checked = True Then MarkSel = "2"
            If TxtOpNo.Text = "" Then
                Sqlstr = "select  dbo.GetCostBillID('INV',getdate()) as Outwhid"
                Mread = Conn.GetDataReader(Sqlstr)
                If Mread.HasRows Then
                    While Mread.Read
                        TxtOpNo.Text = Mread.GetString(0)
                    End While
                Else
                    Mread.Close()
                    Conn.PubConnection.Close()
                    LblMsg.Text = "系统在自动生成出货单号时,发生错误..."
                    Conn.PubConnection.Close()
                    Exit Sub
                End If
                Mread.Close()
                Conn.PubConnection.Close()
                Sqlstr = " insert into m_WhOutM_t(Outwhid,Avcoutid,Partid,Cusid,Orderseq,Saddress,Shipqty,States,Outtype,Remark,Userid,Intime)values(" & _
                      "'" & TxtOpNo.Text & "','" & cobOutShNo.Text & "','" & LblPartid.Text & "','" & TxtCusor.Text & "'," & _
                     " '" & dgOgbList.Rows(RowIndex).Cells("ColItem").Value & "','" & TxtAddr.Text & "', " & _
                     "'" & dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value & "','N','O','" & MarkSel & "','" & SysMessageClass.UseId & "',getdate())"
            End If
            'Dim ShipQty As Integer = 0
            'Mread = Conn.GetDataReader("select sum(CartonOutqty) from m_WhOutD_t where Outwhid='" & TxtOpNo.Text & "'")
            'If Mread.HasRows Then
            '    While Mread.Read
            '        ShipQty = Mread!Shipqty
            '    End While
            'End If
            'Mread.Close()
            If PackQty + CInt(dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value) > CInt(dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value) Then
                Me.LblMsg.Text = "该外箱的箱装数量与已出货的外箱数量,超过了出货单号的数量..."
                Conn.PubConnection.Close()
                Exit Sub
            End If

            Sqlstr = Sqlstr & vbNewLine & " insert into m_WhOutD_t(Outwhid,CartonID,PallteID,CartonOutqty,UserID,Intime)values('" & TxtOpNo.Text & "','" & TxtCarton.Text & "','" & TxtPalletId.Text & "','" & PackQty & "','" & SysMessageClass.UseId & "',getdate())"
            Sqlstr = Sqlstr & vbNewLine & " update m_Carton_t set CartonStatus='O' where Cartonid='" & TxtCarton.Text & "'"
            Try
                Conn.ExecSql(Sqlstr)
                Conn.PubConnection.Close()
                dgScanData.Rows.Add(False, LblPartid.Text, TxtCarton.Text, PackQty, SysMessageClass.UseId, Now.ToString("yyyy-MM-dd hh:mm:ss"), TxtPalletId.Text)
                If PackQty + CInt(dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value) = CInt(dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value) Then
                    dgOgbList.Rows(RowIndex).Cells("ColState").Value = "Y"
                    dgOgbList.Rows(dgOgbList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
                    dgOgbList.Rows(dgOgbList.Rows.Count - 1).DefaultCellStyle.Format = Font.Bold
                End If
                If RadPalltPack.Checked = True Then
                    LabCartCoun.Text = CInt(LabCartCoun.Text) + 1
                    If CInt(LabCartCoun.Text) = CInt(LblPalletQty.Text) Then
                        TxtCarton.Clear()
                        TxtCarton.Enabled = False
                        TxtPalletId.Clear()
                        TxtPalletId.Enabled = True
                        TxtPalletId.Focus()
                        LabCartCoun.Text = "0"
                        LblPalletQty.Text = "0"
                        Exit Sub
                    End If
                End If

                dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value = CInt(dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value) + PackQty
                lblPqty.Text = dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value
                LblMsg.Text = "出货成功..."
                TxtCarton.Clear()

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub dgOgbList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOgbList.CellContentClick

        If (dgOgbList.Rows.Count = 0) Then
            Exit Sub
        End If

        If (dgOgbList.CurrentCell.RowIndex < 0) Then
            Exit Sub
        End If
        If (dgOgbList.CurrentCell Is Nothing) Then
            Exit Sub
        End If
        If (dgOgbList.CurrentRow Is Nothing) Then
            Exit Sub
        End If
        If (e.ColumnIndex <> 0) Then
            Exit Sub
        End If
        lblPqty.Text = "0"
        InitControlStatus()
        For i As Integer = 0 To dgOgbList.Rows.Count - 1

            Dim ck As DataGridViewCheckBoxCell = dgOgbList.Rows(i).Cells(0)
            If (i <> e.RowIndex) Then
                ck.Value = False
            Else
                ck.Value = True
                RowIndex = i
            End If
        Next

        dgOgbList.EndEdit()
        LblPartid.Text = dgOgbList.Rows(RowIndex).Cells("ColPartid").Value

        'Dim OracleObject As New OracleDb("")
        Dim Sqlstr As String = "select Shipqty,Outwhid  from m_WhOutM_t where Avcoutid='" + cobOutShNo.Text + "' and Orderseq='" + dgOgbList.Rows(RowIndex).Cells("ColItem").Value + "' "
        Dim outQty As SqlDataReader = Conn.GetDataReader(Sqlstr)
        If (outQty.HasRows) Then
            While outQty.Read
                'lblPqty.Text = outQty("Shipqty").ToString()
                TxtOpNo.Text = outQty("Outwhid").ToString()
            End While
        Else
            lblPqty.Text = "0"
        End If
        outQty.Close()
        Conn.PubConnection.Close()
        Sqlstr = "select isnull(sum(CartonOutqty),0) outQty from m_WhOutD_t where Outwhid='" + TxtOpNo.Text + "'"
        outQty = Conn.GetDataReader(Sqlstr)
        If (outQty.HasRows) Then
            While outQty.Read
                lblPqty.Text = outQty("outQty").ToString()
            End While
        Else
            lblPqty.Text = "0"
        End If
        outQty.Close()
        Conn.PubConnection.Close()
        dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value = lblPqty.Text
        If dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value = lblPqty.Text Then
            dgOgbList.Rows(RowIndex).Cells("ColState").Value = "Y"
            dgOgbList.Rows(dgOgbList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
            dgOgbList.Rows(dgOgbList.Rows.Count - 1).DefaultCellStyle.Format = Font.Bold

            TxtCarton.Enabled = False
            TxtPalletId.Enabled = False
            radPallet.Enabled = False
            RadPalltPack.Enabled = False

            Me.txtHWCarton.Enabled = False
            Me.txtHWPart.Enabled = False
            Me.txtHWQty.Enabled = False
            Me.txtLXCarton.Enabled = False

            'LblMsg.Text = "该出货单项次已经扫描完成,不允许再扫描..."
            SetMessage("该出货单项次已经扫描完成,不允许再扫描...", False)
        Else
            radPallet.Enabled = True
            RadPalltPack.Enabled = True
        End If
        outQty.Close()
        dgScanData.Rows.Clear()
        'LXWarehouseManage.OracleDb OracleObject = new OracleDb("");
        Dim DsObject As New DataSet()
        'Dim sqlstr As String = ""
        If TxtOpNo.Text.Trim <> "" Then
            Sqlstr = "select CartonID,CartonOutqty,UserID,Intime,PallteID  from m_WhOutD_t where Outwhid='" & TxtOpNo.Text & "'"
            outQty = Conn.GetDataReader(Sqlstr)
            If outQty.HasRows Then
                While outQty.Read
                    dgScanData.Rows.Add(False, dgOgbList.Rows(RowIndex).Cells("ColPartid").Value, outQty(0).ToString(), outQty(1).ToString(), outQty(2).ToString(), outQty(3).ToString(), outQty(4).ToString())
                End While
            End If
            outQty.Close()
            Conn.PubConnection.Close()
            ToolLblCount.Text = dgScanData.Rows.Count.ToString()
        Else
            ToolLblCount.Text = "0"
        End If
        If (Me.TabControlScan.SelectedIndex = 0) Then
            'TxtCarton.Focus()
            Me.ActiveControl = Me.TxtCarton
        Else
            Me.ActiveControl = Me.txtHWCarton
        End If

    End Sub

    Private Sub dgScanData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgScanData.CellContentClick

        If dgScanData.Rows.Count < 1 Then
            Exit Sub
        End If
        If (dgScanData.CurrentCell.ColumnIndex = 0) Then
            If (Convert.ToBoolean(dgScanData.CurrentCell.Value.ToString()) = True) Then
                dgScanData.CurrentCell.Value = False
            Else
                dgScanData.CurrentCell.Value = True
            End If
        End If

    End Sub

    Private Sub ToolSDele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSDele.Click

        Dim tmpList As New List(Of DataGridViewRow)()
        Dim Sqlstr As String = ""
        Dim DeleteQty As Integer = 0
        For j As Integer = 0 To dgScanData.Rows.Count
            If (Convert.ToBoolean(dgScanData(0, j).EditedFormattedValue.ToString())) Then
                tmpList.Add(dgScanData.Rows(j))
                If (Sqlstr = "") Then
                    Sqlstr = "'" + dgScanData.Rows(j).Cells("colPack").Value.ToString() + "'"
                Else
                    Sqlstr = Sqlstr + "," + "'" + dgScanData.Rows(j).Cells("colPack").Value.ToString() + "'"
                    DeleteQty = DeleteQty + CInt(dgScanData.Rows(j).Cells("ColCatronQty").Value.ToString())
                End If
            End If
        Next
        If (Sqlstr = "") Then Exit Sub
        Try
            Dim OracleObject As New OracleDb("")
            ''//DataSet DsObject = new DataSet();
            Sqlstr = "delete from m_WhOutD_t where Outwhid='" + cobOutShNo.Text + "' and CartonID in(" + Sqlstr + ")"
            Conn.ExecSql(Sqlstr)
            Dim Rowcount As Integer = tmpList.Count
            For i As Integer = 0 To tmpList.Count
                dgScanData.Rows.Remove(tmpList(i))
                ''MessageBox.Show(tmpList[i].Cells[2].Value.ToString());
            Next
            tmpList = Nothing
            lblPqty.Text = (CInt(lblPqty.Text) - DeleteQty).ToString()
            LabCartCoun.Text = (CInt(LabCartCoun.Text) - Rowcount).ToString()
            dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value = (CInt(dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value.ToString()) - DeleteQty).ToString()
        Catch ex As Exception
            'LblMsg.Text = "移除指定外箱时出错，请检查原因..." + ex.Message

            SetMessage("移除指定外箱时出错，请检查原因...", False)
        End Try

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Dim file As New FileStream("D:\软件\MES代码\WarehouseManage\ShareFile\packList.xls", FileMode.Open, FileAccess.Read)
        Dim hssfworkbook = New HSSFWorkbook(file)
        Dim sheet1 As HSSFSheet = hssfworkbook.GetSheet("Sheet1")
        sheet1.GetRow(1).GetCell(1).SetCellValue(200200)
        sheet1.GetRow(2).GetCell(1).SetCellValue(300)
        sheet1.GetRow(3).GetCell(1).SetCellValue(500050)
        sheet1.GetRow(4).GetCell(1).SetCellValue(8000)
        sheet1.GetRow(5).GetCell(1).SetCellValue(110)
        sheet1.GetRow(6).GetCell(1).SetCellValue(100)
        sheet1.GetRow(7).GetCell(1).SetCellValue(200)
        sheet1.GetRow(8).GetCell(1).SetCellValue(210)
        sheet1.GetRow(9).GetCell(1).SetCellValue(2300)
        sheet1.GetRow(10).GetCell(1).SetCellValue(240)
        sheet1.GetRow(11).GetCell(1).SetCellValue(180123)
        sheet1.GetRow(12).GetCell(1).SetCellValue(150)

        ''Force excel to recalculate all the formula while open

        sheet1.ForceFormulaRecalculation = True

        file = New FileStream("test.xls", FileMode.Create)
        hssfworkbook.Write(file)
        file.Close()

    End Sub

   
    Private Sub RadPPID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadPPID.CheckedChanged

        TxtPPID.Enabled = True
        TxtCarton.Enabled = False
        TxtPalletId.Enabled = False
        TxtPPID.Focus()

    End Sub

    Private Sub TxtPPID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPPID.KeyPress

        If Me.GetNowRowIndex = -1 Then
            'Me.LblMsg.Text = "请选择出货的明细项..."
            SetMessage("请选择出货的明细项...", False)
            TxtPPID.Clear()
            Exit Sub
        End If
        If e.KeyChar = Chr(13) Then
            If TxtDri.Text.Trim = "" Then
                TxtPPID.Clear()
                'LblMsg.Text = "Dir送货人为空,请设置资料,不允许出货扫描..."
                SetMessage("Dir送货人为空,请设置资料,不允许出货扫描...", False)
                Exit Sub
            End If
            If TxtConfig.Text.Trim = "" Then
                TxtPPID.Clear()
                'LblMsg.Text = "产品的Config为空,请设置资料,不允许出货扫描..."
                SetMessage("产品的Config为空,请设置资料,不允许出货扫描...", False)
                Exit Sub
            End If
            Dim DirStr As String = "" : Dim ConfigStr As String = ""
            Dim mRead As SqlDataReader = Conn.GetDataReader(" select label10,label11 from m_BarRecordValue_t where barcodeSNID='" & TxtPPID.Text & "' ")
            If mRead.HasRows Then
                While mRead.Read
                    ConfigStr = mRead!label10
                    DirStr = mRead!label11
                End While
            Else
                mRead.Close()
                Conn.PubConnection.Close()
                TxtPPID.Clear()
                'LblMsg.Text = "系统中不存在该产品条码,不允许出货扫描..."
                SetMessage("系统中不存在该产品条码,不允许出货扫描...", False)
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            If Replace(ConfigStr, "Build name-Config ", "").Trim <> TxtConfig.Text Then
                TxtPPID.Clear()
                'LblMsg.Text = "该产品的打印参数值：" & ConfigStr & ",与出货扫描的Config值：" & TxtConfig.Text & " 不符..."
                SetMessage("该产品的打印参数值：" & ConfigStr & ",与出货扫描的Config值：" & TxtConfig.Text & " 不符....", False)
                Exit Sub
                'Build name-Config 0
                'DRI:Einess
            End If
            If Replace(DirStr, "DRI:", "").Trim <> TxtDri.Text Then
                TxtPPID.Clear()
                'LblMsg.Text = "该产品的打印参数值：" & DirStr & ",与出货扫描的Dri值：" & TxtDri.Text & " 不符..."
                SetMessage("该产品的打印参数值：" & DirStr & ",与出货扫描的Dri值：" & TxtDri.Text & " 不符...", False)
                Exit Sub
                'Build name-Config 0
                'DRI:Einess
            End If
            mRead = Conn.GetDataReader(" select 1 from m_Assysn_t where ppid='" & TxtPPID.Text & "' and stationid in('A00004','P00001') ")
            If mRead.HasRows = False Then
                mRead.Close()
                Conn.PubConnection.Close()
                TxtPPID.Clear()
                'LblMsg.Text = "该产品条码未经过产线包装扫描,不允许出货扫描..."
                SetMessage("该产品条码未经过产线包装扫描,不允许出货扫描...", False)
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            mRead = Conn.GetDataReader(" select 1 from m_WhOutD_t where CartonID='" & TxtPPID.Text & "' ")
            If mRead.HasRows Then
                mRead.Close()
                Conn.PubConnection.Close()
                TxtPPID.Clear()
                'LblMsg.Text = "该产品条码已进行过出货扫描,不允许重复进行出货扫描..."
                SetMessage("该产品条码已进行过出货扫描,不允许重复进行出货扫描...", False)
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            Dim PackQty As Integer = 0
            Dim Sqlstr As String = ""
            Dim MarkSel As String = ""
            If RadPack.Checked = True Then MarkSel = "0" : If radPallet.Checked = True Then MarkSel = "1" : If RadPalltPack.Checked = True Then MarkSel = "2"
            If TxtOpNo.Text = "" Then
                Sqlstr = "select  dbo.GetCostBillID('INV',getdate()) as Outwhid"
                mRead = Conn.GetDataReader(Sqlstr)
                If mRead.HasRows Then
                    While mRead.Read
                        TxtOpNo.Text = mRead.GetString(0)
                    End While
                Else
                    mRead.Close()
                    Conn.PubConnection.Close()
                    'LblMsg.Text = "系统在自动生成出货单号时,发生错误..."
                    SetMessage("系统在自动生成出货单号时,发生错误...", False)
                    Exit Sub
                End If
                mRead.Close()
                Conn.PubConnection.Close()
                Sqlstr = " insert into m_WhOutM_t(Outwhid,Avcoutid,Partid,Cusid,Orderseq,Saddress,Shipqty,States,Outtype,Remark,Userid,Intime)values(" & _
                      "'" & TxtOpNo.Text & "','" & cobOutShNo.Text & "','" & LblPartid.Text & "','" & TxtCusor.Text & "'," & _
                     " '" & dgOgbList.Rows(RowIndex).Cells("ColItem").Value & "','" & TxtAddr.Text & "', " & _
                     "'" & dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value & "','N','O','" & MarkSel & "','" & SysMessageClass.UseId & "',getdate())"
            End If

            If PackQty + CInt(dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value) > CInt(dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value) Then
                'Me.LblMsg.Text = "该外箱的箱装数量与已出货的外箱数量,超过了出货单号的数量..."
                SetMessage("该外箱的箱装数量与已出货的外箱数量,超过了出货单号的数量...", False)
                Exit Sub
            End If

            Sqlstr = Sqlstr & vbNewLine & " insert into m_WhOutD_t(Outwhid,CartonID,PallteID,CartonOutqty,UserID,Intime)values('" & TxtOpNo.Text & "','" & TxtPPID.Text & "','" & TxtPPID.Text & "','" & PackQty & "','" & SysMessageClass.UseId & "',getdate())"
            'Sqlstr = Sqlstr & vbNewLine & " update m_Carton_t set CartonStatus='O' where Cartonid='" & TxtCarton.Text & "'"
            Try
                Conn.ExecSql(Sqlstr)
                dgScanData.Rows.Add(False, LblPartid.Text, TxtPPID.Text, PackQty, SysMessageClass.UseId, Now.ToString("yyyy-MM-dd hh:mm:ss"), TxtPPID.Text)
                If PackQty + CInt(dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value) = CInt(dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value) Then
                    dgOgbList.Rows(RowIndex).Cells("ColState").Value = "Y"
                    dgOgbList.Rows(dgOgbList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
                    dgOgbList.Rows(dgOgbList.Rows.Count - 1).DefaultCellStyle.Format = Font.Bold
                End If
                If RadPalltPack.Checked = True Then
                    LabCartCoun.Text = CInt(LabCartCoun.Text) + 1
                    If CInt(LabCartCoun.Text) = CInt(LblPalletQty.Text) Then
                        TxtCarton.Clear()
                        TxtCarton.Enabled = False
                        TxtPalletId.Clear()
                        TxtPalletId.Enabled = True
                        TxtPalletId.Focus()
                        LabCartCoun.Text = "0"
                        LblPalletQty.Text = "0"
                        Exit Sub
                    End If
                End If

                dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value = CInt(dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value) + PackQty
                lblPqty.Text = dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value
                TxtCarton.Clear()
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub ToolBTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBTask.Click

        ToolBTask.Enabled = False
        TxtDri.ReadOnly = False
        TxtDri.Focus()
        TxtConfig.ReadOnly = False
        ToolBack.Enabled = True
        ToolFinish.Enabled = True
        chk_checkno.Enabled = True


    End Sub

    Private Sub ToolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBack.Click

        ToolBTask.Enabled = True
        TxtDri.ReadOnly = True
        TxtConfig.ReadOnly = True
        ToolBack.Enabled = False
        ToolFinish.Enabled = False

    End Sub

    Private Sub ToolFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolFinish.Click

        ToolBTask.Enabled = True
        TxtDri.ReadOnly = True
        TxtConfig.ReadOnly = True
        ToolBack.Enabled = False
        ToolFinish.Enabled = False

    End Sub

#Region "华为出货扫描"

    '1355D-150400445

    Private Sub TabControlScan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlScan.SelectedIndexChanged
        If (Me.TabControlScan.SelectedIndex = 0) Then

        Else
            If (Me.chbCheckQty.Checked) Then
                Me.txtHWQty.Enabled = True
                Me.txtHWQty.Text = ""
            Else
                Me.txtHWQty.Enabled = False
                Me.txtHWQty.Text = ""
            End If
            Me.ActiveControl = Me.txtHWShippingNO
        End If
    End Sub

    Private Sub chbCheckQty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCheckQty.CheckedChanged
        If (Me.chbCheckQty.Checked) Then
            Me.txtHWQty.Enabled = True
            Me.txtHWQty.Text = ""
        Else
            Me.txtHWQty.Enabled = False
            Me.txtHWQty.Text = ""
        End If
    End Sub

    Private Sub txtHWCarton_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHWCarton.KeyPress
        Dim CheckHWCartonID As SqlDataReader
        Try
            If e.KeyChar = Chr(13) Then
                If Me.GetNowRowIndex = -1 Then
                    SetMessage("请选择出货的明细项...", False)
                    ClearValue(Me.txtHWCarton)
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtHWShippingNO.Text.Trim)) Then
                    SetMessage("扫描华为出货单号不能为空!", False)
                    ClearValue(Me.txtHWCarton)
                    Me.ActiveControl = Me.txtHWShippingNO
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtHWCarton.Text.Trim)) Then
                    SetMessage("扫描华为箱号不能为空!", False)
                    ClearValue(Me.txtHWCarton)
                    Exit Sub
                End If

                If (Not CheckHWCarton(Me.txtHWShippingNO.Text.Trim, Me.txtHWCarton.Text.Trim)) Then

                End If

                Dim Sqlstr As String = "SELECT TOP 1 Outwhid FROM m_WhOutD_t WHERE HWCartonId='" & Me.txtHWCarton.Text.Trim.Replace("'", "''") & "'"
                CheckHWCartonID = Conn.GetDataReader(Sqlstr)
                If (CheckHWCartonID.HasRows) Then
                    SetMessage("扫描华为箱号已经存在!", False)
                    ClearValue(Me.txtHWCarton)
                Else
                    SetMessage("华为箱号扫描成功!", True)
                    Me.ActiveControl = Me.txtHWPart
                End If
                CheckHWCartonID.Close()
                Conn.PubConnection.Close()

            End If
        Catch ex As Exception
            If (Not CheckHWCartonID Is Nothing) Then
                If (Not CheckHWCartonID.IsClosed) Then
                    CheckHWCartonID.Close()
                End If
            End If
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            SetMessage("执行华为箱号扫描异常!", False)
        End Try
    End Sub

    Private Sub txtHWPart_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHWPart.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                If Me.GetNowRowIndex = -1 Then
                    SetMessage("请选择出货的明细项...", False)
                    Me.txtHWCarton.Text = ""
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtHWCarton.Text.Trim)) Then
                    SetMessage("请先扫描华为箱号...", False)
                    Me.txtHWCarton.Text = ""
                    Me.ActiveControl = Me.txtHWCarton
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtHWPart.Text.Trim)) Then
                    SetMessage("扫描华为料号不能为空...", False)
                    Me.txtHWPart.Text = ""
                    Me.ActiveControl = Me.txtHWPart
                    Exit Sub
                End If

                If (Me.chbCheckQty.Checked) Then
                    Me.ActiveControl = Me.txtHWQty
                Else
                    Me.ActiveControl = Me.txtLXCarton
                End If
                SetMessage("华为料号扫描成功!", True)
            End If
        Catch ex As Exception
            SetMessage("执行华为料号扫描异常!", False)
        End Try
    End Sub

    Private Sub txtHWQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHWQty.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                If Me.GetNowRowIndex = -1 Then
                    SetMessage("请选择出货的明细项...", False)
                    ClearValue(Me.txtHWCarton)
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtHWCarton.Text.Trim)) Then
                    SetMessage("请先扫描华为箱号...", False)
                    ClearValue(Me.txtHWCarton)
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtHWPart.Text.Trim)) Then
                    SetMessage("请先扫描华为料号...", False)
                    Me.txtHWQty.Text = ""
                    Me.ActiveControl = Me.txtHWPart
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtHWQty.Text.Trim)) Then
                    SetMessage("扫描华为装箱数量不能为空...", False)
                    Me.txtHWCarton.Text = ""
                    Me.ActiveControl = Me.txtHWCarton
                    Exit Sub
                End If

                If (CInt(Me.txtHWQty.Text.Trim) <= 0) Then
                    SetMessage("扫描箱号数量必须大于0...", False)
                    Me.txtHWQty.Text = ""
                    Me.ActiveControl = Me.txtHWQty
                    Exit Sub
                End If

                SetMessage("华为装箱数量扫描成功!", True)
                Me.ActiveControl = Me.txtLXCarton
            End If
        Catch ex As Exception
            Me.txtHWQty.Text = ""
            Me.ActiveControl = Me.txtHWQty
            SetMessage("扫描华为装箱数量格式错误!", False)
        End Try
    End Sub

    Private Sub txtLXCarton_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLXCarton.KeyPress
        Dim Mread As SqlDataReader

        Try
            If e.KeyChar = Chr(13) Then
                If Me.GetNowRowIndex = -1 Then
                    SetMessage("请选择出货的明细项...", False)
                    Me.txtHWCarton.Text = ""
                    Me.txtLXCarton.Text = ""
                    Exit Sub
                End If

                Dim strShippingPart As String

                strShippingPart = Me.dgOgbList.Rows(RowIndex).Cells("ColCusPN").Value.ToString.Trim()
                If (String.IsNullOrEmpty(strShippingPart)) Then
                    SetMessage("请选择出货料号!", False)
                    Me.txtLXCarton.Text = ""
                    Me.ActiveControl = Me.txtHWCarton
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtHWCarton.Text.Trim)) Then
                    SetMessage("请先扫描华为箱号...", False)
                    Me.txtHWCarton.Text = ""
                    Me.txtLXCarton.Text = ""
                    Me.ActiveControl = Me.txtHWCarton
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(Me.txtHWPart.Text.Trim)) Then
                    SetMessage("请先扫描华为料号...", False)
                    Me.txtHWPart.Text = ""
                    Me.txtLXCarton.Text = ""
                    Me.ActiveControl = Me.txtHWPart
                    Exit Sub
                End If

                Dim strHWQty As String
                
                If (Me.chbCheckQty.Checked) Then
                    If (String.IsNullOrEmpty(Me.txtHWQty.Text.Trim)) Then
                        SetMessage("请先扫描箱号数量...", False)
                        Me.txtHWQty.Text = ""
                        Me.txtLXCarton.Text = ""
                        Me.ActiveControl = Me.txtHWQty
                        Exit Sub
                    End If

                    If (CInt(Me.txtHWQty.Text.Trim) <= 0) Then
                        SetMessage("扫描箱号数量必须大于0...", False)
                        Me.txtHWQty.Text = ""
                        Me.txtLXCarton.Text = ""
                        Me.ActiveControl = Me.txtHWQty
                        Exit Sub
                    End If
                    strHWQty = Me.txtHWQty.Text.Trim().Replace("'", "''")
                Else
                    strHWQty = "0"
                End If

                If (Not CheckBarcode(Me.txtHWPart.Text.Trim, Me.txtHWQty.Text.Trim, Me.txtLXCarton.Text.Trim, strShippingPart, Me.chbCheckQty.Checked, Me.chbDimensional.Checked)) Then
                    SetMessage("扫描华为料号与立讯外箱料号或数量不一致", False)
                    Me.txtLXCarton.Text = ""
                    Me.ActiveControl = Me.txtLXCarton
                    Exit Sub
                End If

                Dim PackQty As Integer = 0
                Dim PackStatus As String = ""
                Dim Lindid As String = ""
                Dim StateStar As String = ""
                Dim StateEnd As String = ""
                Dim StateStr As String = ""
                Dim fppid As String = ""

                'select top 1 Cartonqty,CartonStatus,Teamid,b.ppid from m_Carton_t a left join m_CartonSN_t b on a.Cartonid=b.Cartonid where a.cartonid='" & TxtCarton.Text & "'"
                If (Me.ChbCheckCarton.Checked) Then
                    If (Me.chbCartonSame.Checked) Then
                        Mread = Conn.GetDataReader("SELECT TOP 1 ISNULL(QTY,0) AS Cartonqty, 'Y' AS CartonStatus, '' AS Teamid FROM m_MOPackingLevel WHERE SBarCode='" & Me.txtLXCarton.Text.Trim.Replace("'", "''") & "'")
                    Else
                        Mread = Conn.GetDataReader("select top 1 Cartonqty,CartonStatus,Teamid from m_Carton_t where cartonid='" & Me.txtLXCarton.Text.Trim.Replace("'", "''") & "'")
                    End If

                    If Mread.HasRows Then
                        While Mread.Read
                            PackQty = Mread!Cartonqty
                            PackStatus = Mread!CartonStatus
                            Lindid = Mread!Teamid
                        End While
                    Else
                        SetMessage("该外箱条码不存在或未进行包装...", False)
                        Mread.Close()
                        Conn.PubConnection.Close()
                        Me.txtLXCarton.Text = ""
                        Me.ActiveControl = Me.txtLXCarton
                        Exit Sub
                    End If
                    Mread.Close()
                    Conn.PubConnection.Close()

                    If (Not Me.chbCartonSame.Checked) Then
                        If PackStatus = "O" Then
                            SetMessage("该外箱条码已经进行出货扫描,请检查外箱是否重复或实物未出货...", False)
                            Me.txtLXCarton.Text = ""
                            Me.ActiveControl = Me.txtLXCarton
                            Exit Sub
                        End If
                        If PackStatus <> "Y" Then
                            SetMessage("该外箱条码未进行包装完成,或被作废或被替换...", False)
                            Me.txtLXCarton.Text = ""
                            Me.ActiveControl = Me.txtLXCarton
                            Exit Sub
                        End If
                    End If
                Else
                    PackQty = GetLXCartonQty(Me.txtLXCarton.Text.Trim())
                    If (PackQty = 0) Then
                        SetMessage("扫描立讯外箱格式错误无法获取数量...", False)
                        Me.txtLXCarton.Text = ""
                        Me.ActiveControl = Me.txtLXCarton
                        Exit Sub
                    End If
                End If

              

                If PackQty + CInt(dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value) > CInt(dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value) Then
                    SetMessage("该外箱的箱装数量与已出货的外箱数量,超过了出货单号的数量...", False)
                    Me.txtLXCarton.Text = ""
                    Me.ActiveControl = Me.txtLXCarton
                    Exit Sub
                End If

                Dim Sqlstr As String = ""
                Dim MarkSel As String = ""

                If TxtOpNo.Text = "" Then
                    Sqlstr = "select  dbo.GetCostBillID('INV',getdate()) as Outwhid"
                    Mread = Conn.GetDataReader(Sqlstr)
                    If Mread.HasRows Then
                        While Mread.Read
                            TxtOpNo.Text = Mread.GetString(0)
                        End While
                    Else
                        Mread.Close()
                        Conn.PubConnection.Close()
                        SetMessage("系统在自动生成出货单号时,发生错误...", False)
                        Exit Sub
                    End If
                    Mread.Close()
                    Conn.PubConnection.Close()
                    Sqlstr = " insert into m_WhOutM_t(Outwhid,Avcoutid,Partid,Cusid,Orderseq,Saddress,Shipqty,States,Outtype,Remark,Userid,Intime)values(" & _
                          "'" & TxtOpNo.Text & "','" & cobOutShNo.Text & "','" & LblPartid.Text & "',N'" & TxtCusor.Text & "'," & _
                         " '" & dgOgbList.Rows(RowIndex).Cells("ColItem").Value & "',N'" & TxtAddr.Text & "', " & _
                         "'" & dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value & "','N','O','" & MarkSel & "','" & SysMessageClass.UseId & "',getdate())"
                End If

                If (Not Me.chbCartonSame.Checked) Then
                    Sqlstr = Sqlstr & vbNewLine & " insert into m_WhOutD_t(Outwhid,CartonID,PallteID,CartonOutqty,CustDeliveryNO,UserID,Intime)values('" & TxtOpNo.Text & "','" & Me.txtLXCarton.Text.Trim.Replace("'", "''") & "','','" & PackQty & "','" & Me.txtHWShippingNO.Text.Trim.Replace("'", "''") & "','" & SysMessageClass.UseId & "',getdate())"
                    If (Me.ChbCheckCarton.Checked) Then
                        Sqlstr = Sqlstr & vbNewLine & " update m_Carton_t set CartonStatus='O' where Cartonid='" & Me.txtLXCarton.Text.Trim.Replace("'", "''") & "'"
                    End If

                    Sqlstr = Sqlstr & vbNewLine & " SELECT '" & Me.txtLXCarton.Text.Trim.Replace("'", "''") & "' "
                Else
                    Sqlstr = Sqlstr & vbNewLine & "DECLARE @CurrentCartonID VARCHAR(64) "
                    Sqlstr = Sqlstr & vbNewLine & "DECLARE @STYLEMAX INT "
                    Sqlstr = Sqlstr & vbNewLine & "IF NOT EXISTS(SELECT 1 FROM m_StyleFormat_t WHERE StyleFormat='" & Me.txtLXCarton.Text.Trim.Replace("'", "''") & "' ) BEGIN "
                    Sqlstr = Sqlstr & vbNewLine & "SET @STYLEMAX = 10000000 "
                    Sqlstr = Sqlstr & vbNewLine & "INSERT INTO m_StyleFormat_t(StyleFormat,StyleType,styleValue)VALUES('" & Me.txtLXCarton.Text.Trim.Replace("'", "''") & "', 'C', @STYLEMAX) End "
                    Sqlstr = Sqlstr & vbNewLine & "UPDATE m_StyleFormat_t SET styleValue = styleValue + 1 WHERE StyleFormat = '" & Me.txtLXCarton.Text.Trim.Replace("'", "''") & "' AND StyleType='C' "
                    Sqlstr = Sqlstr & vbNewLine & "SELECT @CurrentCartonID = ISNULL(StyleFormat + CONVERT(NVARCHAR(32),styleValue), '') FROM m_StyleFormat_t WHERE StyleFormat = '" & Me.txtLXCarton.Text.Trim.Replace("'", "''") & "' AND StyleType='C' "
                    Sqlstr = Sqlstr & vbNewLine & "INSERT INTO m_WhOutD_t(Outwhid, CartonID, HWShippingNO, HWCartonId, HWPartId, HWQty, PallteID, CartonOutqty, UserID, Intime) VALUES('" & TxtOpNo.Text & "', @CurrentCartonID, '" & Me.txtHWShippingNO.Text.Trim.Replace("'", "''") & "','" & Me.txtHWCarton.Text.Trim.Replace("'", "''") & "','" & Me.txtHWPart.Text.Trim.Replace("'", "''") & "','" & strHWQty & "','','" & PackQty & "','" & SysMessageClass.UseId & "',getdate()) "
                    Sqlstr = Sqlstr & vbNewLine & "SELECT  @CurrentCartonID "
                End If

                'Conn.ExecSql(Sqlstr)
                Dim CurrentCartonId As String
                Mread = Conn.GetDataReader(Sqlstr)
                If Mread.HasRows Then
                    While Mread.Read
                        CurrentCartonId = Mread.GetString(0)
                    End While
                Else
                    Mread.Close()
                    Conn.PubConnection.Close()
                    SetMessage("系统执行华为出货扫描,发生错误...", False)
                    Exit Sub
                End If
                Mread.Close()
                Conn.PubConnection.Close()

                'Me.txtLXCarton.Text.Trim.Replace("'", "''")
                dgScanData.Rows.Add(False, LblPartid.Text, CurrentCartonId, PackQty, SysMessageClass.UseId, Now.ToString("yyyy-MM-dd hh:mm:ss"), "")
                If PackQty + CInt(dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value) = CInt(dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value) Then
                    dgOgbList.Rows(RowIndex).Cells("ColState").Value = "Y"
                    dgOgbList.Rows(dgOgbList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
                    dgOgbList.Rows(dgOgbList.Rows.Count - 1).DefaultCellStyle.Format = Font.Bold
                End If

                'If RadPalltPack.Checked = True Then
                '    LabCartCoun.Text = CInt(LabCartCoun.Text) + 1
                '    If CInt(LabCartCoun.Text) = CInt(LblPalletQty.Text) Then
                '        TxtCarton.Clear()
                '        TxtCarton.Enabled = False
                '        TxtPalletId.Clear()
                '        TxtPalletId.Enabled = True
                '        TxtPalletId.Focus()
                '        LabCartCoun.Text = "0"
                '        LblPalletQty.Text = "0"
                '        Exit Sub
                '    End If
                'End If

                dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value = CInt(dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value) + PackQty
                lblPqty.Text = dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value

                SetMessage("执行华为出货扫描成功!", True)
                ClearValue(Me.txtHWCarton)
            End If
        Catch ex As Exception
            If (Not Mread Is Nothing) Then
                If (Not Mread.IsClosed) Then
                    Mread.Close()
                End If
            End If

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            SetMessage("执行立讯箱号扫描异常!", False)
            Me.txtLXCarton.Text = ""
            Me.ActiveControl = Me.txtLXCarton
        End Try
    End Sub

    Private Sub SetMessage(ByVal strMessage As String, ByVal MessageType As Boolean)
        If (MessageType) Then
            LblMsg.ForeColor = Color.Green
        Else
            Me.LblMsg.ForeColor = Color.Red
        End If
        Me.LblMsg.Text = strMessage
    End Sub

    Private Sub ClearValue(ByVal activeControl As Control)
        Me.txtHWCarton.Text = ""
        Me.txtHWPart.Text = ""
        Me.txtHWQty.Text = ""
        Me.txtLXCarton.Text = ""
        Me.ActiveControl = activeControl
    End Sub

    Private Function CheckHWCarton(ByVal strHWShippingNO As String, ByVal strHWCarton As String) As Boolean
        Try
            Dim rtValue As Boolean = False
            Dim strCartonShippingNO As String

            strCartonShippingNO = strHWCarton.Substring(2, strHWCarton.Length - 6)

            If (strCartonShippingNO.ToUpper <> strHWShippingNO.ToUpper) Then
                rtValue = False
            Else
                rtValue = True
            End If

            Return rtValue
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function CheckBarcode(ByVal strHWPart As String, ByVal strHWQty As String, ByVal strLXCarton As String, ByVal strShippingPart As String, ByVal bCheckQty As Boolean, ByVal bDimensional As Boolean) As Boolean
        Try
            Dim rtValue As Boolean = False
            Dim strLXPart As String
            Dim strLXQty As String

            If (Not bDimensional) Then
                strLXPart = strLXCarton.Split("/")(0).Substring(2, strLXCarton.Split("/")(0).Length - 2)
                strLXQty = strLXCarton.Substring(strLXCarton.Length - 4, 4)
                '(strShippingPart.Substring(1, strShippingPart.Length - 1).ToUpper
                If (strShippingPart.ToUpper <> strHWPart.ToUpper) Then
                    rtValue = False
                Else
                    If (strHWPart.ToUpper <> strLXPart.ToUpper) Then
                        rtValue = False
                    Else
                        rtValue = True
                    End If
                End If

                If (rtValue) Then
                    If (bCheckQty) Then
                        If (CInt(strLXQty) <> CInt(strHWQty)) Then
                            rtValue = False
                        Else
                            rtValue = True
                        End If
                    End If
                End If
            Else
                rtValue = True
            End If
            Return rtValue
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function GetLXCartonQty(ByVal strLXCarton As String) As Int32
        Try
            Dim rtQty As Int32
            rtQty = CInt(strLXCarton.Substring(strLXCarton.Length - 4, 4))
            Return rtQty
        Catch ex As Exception
            Return 0
        End Try
    End Function

#End Region

End Class