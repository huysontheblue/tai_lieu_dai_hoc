

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


Public Class FrmWmsRejected

    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass ''定义窗体级全局变量
    Dim RowIndex As Integer = -1
    Dim _dt As DateTime = DateTime.Now
    ''' <summary>
    ''' </summary>
    ''' <param name="sender">栈板扫描时</param>
    ''' <param name="e">2014年1月11日 ouxiangfeng</param>
    ''' <remarks>昆山联滔出货报表生成</remarks>
    Private Sub radPallet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadPallet.CheckedChanged
        If RadPallet.Checked Then
            RadPack.Checked = False
            RadPPID.Checked = False
            TxtInput.Focus()
        End If
    End Sub


    ''' <summary>
    ''' </summary>
    ''' <param name="sender">外箱扫描时</param>
    ''' <param name="e">2014年1月11日 ouxiangfeng</param>
    ''' <remarks>昆山联滔出货报表生成</remarks>
    Private Sub RadPack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadPack.CheckedChanged
        If RadPack.Checked Then

            'RadPack.Checked = True
            RadPallet.Checked = False
            RadPPID.Checked = False

            TxtInput.Enabled = True
            TxtInput.Clear()
            TxtInput.Focus()
        End If

    End Sub

    ''' <summary>
    ''' </summary>
    ''' <param name="sender">栈板外箱扫描</param>
    ''' <param name="e">2014年1月11日 ouxiangfeng</param>
    ''' <remarks>昆山联滔出货报表生成</remarks>
    Private Sub RadPalltPack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        TxtInput.Enabled = False
        TxtInput.Clear()


    End Sub

#Region "栈板扫描"

#End Region


    Private Sub FrmWmsRejected_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InitControlStatus()
        'LoadOgbIncombo()

    End Sub



    Private Sub InitControl()

        lblPqty.Text = "0"
        LblMsg.Text = "提示信息..."
        'this.LblCus.Text = "";
        'LabCartCoun.Text = "0"
        'DgOutList.Rows.Clear()
        'dgOgbList.Rows.Clear()
    End Sub

    Private Sub cobOutShNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        'cobOutShNo.DroppedDown = True
        If e.KeyChar = Chr(13) Then
            'cobOutShNo_SelectedIndexChanged(sender, e)
        End If

    End Sub




#Region "获取当前行号"
    'Public Function GetNowRowIndex() As Integer

    '    'Dim i As Integer = 0
    '    Dim intReturn As Integer = 0
    '    intReturn = -1
    '    For i As Integer = 0 To dgOgbList.Rows.Count - 1
    '        If dgOgbList.Rows(i).Cells(0).FormattedValue.ToString() = "True" Then
    '            intReturn = i
    '            Exit For '' // TODO: might not be correct. Was : Exit For
    '        End If
    '    Next
    '    Return intReturn

    'End Function
#End Region

#Region "初始化时控件的状态"
    Private Sub ToolInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolInit.Click

        InitControlStatus()

    End Sub

    Private Sub InitControlStatus()
        ''TxtPartid.Clear ();
        ''TxtPartid.Enabled=false;
        ''TxtPartid.Focus();
        TxtInput.Clear()
        TxtInput.Enabled = True
        ''TxtCartonQty.Clear();
        ''TxtCartonQty.Enabled=false ;
    End Sub

#End Region

#Region "退出窗体"
    Private Sub BtBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBack.Click

        Me.Close()

    End Sub
#End Region

    Private Sub cobOutShNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        dgScanData.Rows.Clear()
        'dgOgbList.Rows.Clear()

    End Sub

    Private Sub TxtCarton_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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

        If RadPallet.Checked = True Then
            Me.LblMsg.Text = "选择:栈板+外箱出货扫描模式时,栈板编号不能为空..."
            Exit Sub
        End If

        If e.KeyChar = Chr(13) Then
            If TxtInput.Text.Trim = "" Then
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
            Mread = Conn.GetDataReader("select top 1 Cartonqty,CartonStatus,Teamid,b.ppid from m_Carton_t a left join m_CartonSN_t b on a.Cartonid=b.Cartonid where a.cartonid='" & TxtInput.Text & "'")
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
                TxtInput.Clear()
                Exit Sub
            End If
            Mread.Close()



            Mread = Conn.GetDataReader("select isnull(State,'') StateStr,isnull(StateBegin,'') StateBegin,isnull(StateEnd,'') StateEnd from m_Dline_t where Lineid='" & Lindid & "'")
            If Mread.HasRows Then
                While Mread.Read
                    StateStr = Mread!StateStr
                    StateStar = Mread!StateBegin
                    StateEnd = Mread!StateEnd
                End While
            End If
            Mread.Close()
            If StateStr = "Y" Then
                Dim mSqlLine As String = ""
                If StateStar = "" Or StateEnd = "" Then
                    Me.LblMsg.Text = "该外箱条码所在的线别被冻结，不允许出货扫描..."
                    TxtInput.Clear()
                    Exit Sub
                Else
                    mSqlLine = " select 1 from m_Carton_t where cartonid='" & TxtInput.Text & "' and Teamid='" & Lindid & "' and intime between '" & StateStar & "' and '" & StateEnd & "'"
                End If
                Mread = Conn.GetDataReader(mSqlLine)
                If Mread.HasRows = False Then
                    Mread.Close()
                    Me.LblMsg.Text = "该外箱条码所在的线别：" & Lindid & "被冻结，不允许出货扫描-" & StateStar & "~" & StateEnd
                    TxtInput.Clear()
                    Exit Sub
                End If
                Mread.Close()
            End If

            If PackStatus = "O" Then
                Me.LblMsg.Text = "该外箱条码已经进行出货扫描,请检查外箱是否重复或实物未出货..."
                TxtInput.Clear()
                Exit Sub
            End If
            If PackStatus <> "Y" Then
                Me.LblMsg.Text = "该外箱条码未进行包装完成,或被作废或被替换..."
                TxtInput.Clear()
                Exit Sub
            End If
            Mread = Conn.GetDataReader("select 1  from m_WhOutD_t where cartonid='" & TxtInput.Text & "'")
            If Mread.HasRows Then
                Mread.Close()
                Me.LblMsg.Text = "外箱条码已经进行出货扫描,请检查外箱是否重复或实物未出货..."
                TxtInput.Clear()
                Exit Sub
            End If
            Mread.Close()

            If chk_ppid.Checked Then
                Mread = Conn.GetDataReader("select 1  from m_PpidCheckRecord_t where cartonid='" & TxtInput.Text & "'")
                If Mread.HasRows = False Then
                    Mread.Close()
                    Me.LblMsg.Text = "该外箱条码未进行条码检验作业,不允许出货扫描..."
                    TxtInput.Clear()
                    Exit Sub
                End If
                Mread.Close()
            End If

            'If RadPalltPack.Checked = True Then
            '    If CInt(LabCartCoun.Text) + 1 > CInt(LblPalletQty.Text) Then
            '        Me.LblMsg.Text = "该栈板已经包装完成,不允许再进行外箱包装..."
            '        TxtInput.Clear()
            '        TxtInput.Enabled = False
            '        TxtPalletId.Clear()
            '        TxtPalletId.Enabled = True
            '        TxtPalletId.Focus()
            '        Exit Sub
            '    End If
            'End If
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
            '    Dim Sqlstr As String = ""
            '    Dim MarkSel As String = ""
            '    If RadPack.Checked = True Then MarkSel = "0" : If RadPallet.Checked = True Then MarkSel = "1" : If RadPalltPack.Checked = True Then MarkSel = "2"
            '    If TxtOpNo.Text = "" Then
            '        Sqlstr = "declare @InvNo varchar(50) execute [PRO_AutoLSH] 'INV','Outwhid','m_WhOutM_t',@InvNo output select @InvNo"
            '        Mread = Conn.GetDataReader(Sqlstr)
            '        If Mread.HasRows Then
            '            While Mread.Read
            '                TxtOpNo.Text = Mread.GetString(0)
            '            End While
            '        Else
            '            Mread.Close()
            '            LblMsg.Text = "系统在自动生成出货单号时,发生错误..."
            '            Exit Sub
            '        End If
            '        Mread.Close()
            '        Sqlstr = " insert into m_WhOutM_t(Outwhid,Avcoutid,Partid,Cusid,Orderseq,Saddress,Shipqty,States,Outtype,Remark,Userid,Intime)values(" & _
            '              "'" & TxtOpNo.Text & "','" & cobOutShNo.Text & "','" & LblPartid.Text & "','" & TxtCusor.Text & "'," & _
            '             " '" & dgOgbList.Rows(RowIndex).Cells("ColItem").Value & "','" & TxtAddr.Text & "', " & _
            '             "'" & dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value & "','N','O','" & MarkSel & "','" & SysMessageClass.UseId & "',getdate())"
            '    End If
            '    'Dim ShipQty As Integer = 0
            '    'Mread = Conn.GetDataReader("select sum(CartonOutqty) from m_WhOutD_t where Outwhid='" & TxtOpNo.Text & "'")
            '    'If Mread.HasRows Then
            '    '    While Mread.Read
            '    '        ShipQty = Mread!Shipqty
            '    '    End While
            '    'End If
            '    'Mread.Close()
            '    If PackQty + CInt(dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value) > CInt(dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value) Then
            '        Me.LblMsg.Text = "该外箱的箱装数量与已出货的外箱数量,超过了出货单号的数量..."
            '        Exit Sub
            '    End If

            '    Sqlstr = Sqlstr & vbNewLine & " insert into m_WhOutD_t(Outwhid,CartonID,PallteID,CartonOutqty,UserID,Intime)values('" & TxtOpNo.Text & "','" & TxtCarton.Text & "','" & TxtPalletId.Text & "','" & PackQty & "','" & SysMessageClass.UseId & "',getdate())"
            '    Sqlstr = Sqlstr & vbNewLine & " update m_Carton_t set CartonStatus='O' where Cartonid='" & TxtInput.Text & "'"
            '    Try
            '        Conn.ExecSql(Sqlstr)
            '        dgScanData.Rows.Add(False, LblPartid.Text, TxtCarton.Text, PackQty, SysMessageClass.UseId, Now.ToString("yyyy-MM-dd hh:mm:ss"), TxtPalletId.Text)
            '        If PackQty + CInt(dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value) = CInt(dgOgbList.Rows(RowIndex).Cells("ColOutQty").Value) Then
            '            dgOgbList.Rows(RowIndex).Cells("ColState").Value = "Y"
            '            dgOgbList.Rows(dgOgbList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
            '            dgOgbList.Rows(dgOgbList.Rows.Count - 1).DefaultCellStyle.Format = Font.Bold
            '        End If
            '        If RadPalltPack.Checked = True Then
            '            LabCartCoun.Text = CInt(LabCartCoun.Text) + 1
            '            If CInt(LabCartCoun.Text) = CInt(LblPalletQty.Text) Then
            '                TxtInput.Clear()
            '                TxtInput.Enabled = False
            '                TxtPalletId.Clear()
            '                TxtPalletId.Enabled = True
            '                TxtPalletId.Focus()
            '                LabCartCoun.Text = "0"
            '                LblCartonQty.Text = "0"
            '                Exit Sub
            '            End If
            '        End If

            '        dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value = CInt(dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value) + PackQty
            '        lblPqty.Text = dgOgbList.Rows(RowIndex).Cells("ColScanQty").Value
            '        LblMsg.Text = "出货成功..."
            '        TxtInput.Clear()

            '    Catch ex As Exception

            '    End Try
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

   


    Private Sub RadPPID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadPPID.CheckedChanged
        If RadPPID.Checked Then
            RadPallet.Checked = False
            RadPack.Checked = False
            TxtInput.Focus()
        End If

      
    End Sub

    Private Sub TxtInput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtInput.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim inputbarcode As String = Strings.StrConv(TxtInput.Text, VbStrConv.Narrow, 0)
            TxtInput.Text = inputbarcode.Trim
            If TxtInput.Text.Trim = "" Then
                Me.LblMsg.Text = "条码序号,不能为空..."
                Exit Sub
            End If
            Dim PackQty As Int32 = 0
            Dim Mread As SqlDataReader
            If RadPack.Checked = True Then
                ''检测外箱是否存在
                Mread = Conn.GetDataReader("select top 1 Cartonqty,CartonStatus,Teamid from m_Carton_t a left join m_CartonSN_t b on a.Cartonid=b.Cartonid where a.CartonStatus='O' and a.cartonid='" & TxtInput.Text & "'")
                If Mread.HasRows Then
                    While Mread.Read
                        PackQty = Mread!Cartonqty
                       
                    End While
                Else
                    Me.LblMsg.Text = "外箱条码[" + TxtInput.Text + "]不存在,或未进行包装出货..."
                    Mread.Close()
                    TxtInput.Clear()
                    TxtInput.Focus()
                    Exit Sub
                End If
                Mread.Close()

                Dim exesql As String = String.Format(" DECLARE @result int exec m_WhOutD_Rejected_p '{0}','{1}','1',@result = @result OUTPUT SELECT	@result as N'result'", TxtInput.Text, SysMessageClass.UseId)
                Try
                    ' Conn.ExecSql(sql)
                    Dim rev As Integer = 0
                    Dim RecDr As SqlDataReader = Conn.GetDataReader(exesql)
                    If RecDr.HasRows Then
                        RecDr.Read()
                        rev = RecDr.GetInt32(0)
                        RecDr.Close()
                    End If
                    If rev = 1 Then
                        LblMsg.Text = "退货成功"
                        LblMsg.ForeColor = Color.Green
                        dgScanData.Rows.Add(False, LblPartid.Text, TxtInput.Text, PackQty, SysMessageClass.UseId, Now.ToString("yyyy-MM-dd hh:mm:ss"), "")
                        lblPqty.Text = PackQty.ToString
                    Else
                        LblMsg.Text = "退货失败"
                        LblMsg.ForeColor = Color.Red
                  
                    End If
                Catch ex As Exception
                    LblMsg.Text = "退货失败" & ex.ToString
                    LblMsg.ForeColor = Color.Red
                End Try
                TxtInput.Clear()
                TxtInput.Focus()

            End If
            If RadPPID.Checked = True Then
                ''检测产品是否存在
                Mread = Conn.GetDataReader("select top 1 Cartonqty,CartonStatus,Teamid from m_Carton_t a left join m_CartonSN_t b on a.Cartonid=b.Cartonid where a.CartonStatus='O' and b.ppid='" & TxtInput.Text & "'")
                If Mread.HasRows Then
                    'While Mread.Read
                    '    PackQty = Mread!Cartonqty
                    '    PackStatus = Mread!CartonStatus
                    '    Lindid = Mread!Teamid
                    '    fppid = Mread!ppid
                    'End While
                Else
                    Me.LblMsg.Text = "产品条码[" + TxtInput.Text + "]不存在,或未进行包装出货..."
                    Mread.Close()
                    TxtInput.Clear()
                    TxtInput.Focus()
                    Exit Sub
                End If
                Mread.Close()


                Dim exesql As String = String.Format(" DECLARE @result int exec m_WhOutD_Rejected_p '{0}','{1}','3',@result = @result OUTPUT SELECT	@result as N'result'", TxtInput.Text, SysMessageClass.UseId)
                Try
                    ' Conn.ExecSql(sql)
                    Dim rev As Integer = 0
                    Dim RecDr As SqlDataReader = Conn.GetDataReader(exesql)
                    If RecDr.HasRows Then
                        RecDr.Read()
                        rev = RecDr.GetInt32(0)
                        RecDr.Close()
                    End If
                    If rev = 1 Then
                        LblMsg.Text = "退货成功"
                        LblMsg.ForeColor = Color.Green

                    Else
                        LblMsg.Text = "退货失败"
                        LblMsg.ForeColor = Color.Red
                    End If
                Catch ex As Exception
                    LblMsg.Text = "退货失败" & ex.ToString
                    LblMsg.ForeColor = Color.Red
                End Try
                TxtInput.Clear()
                TxtInput.Focus()


            End If
            If RadPallet.Checked = True Then
                ''检测栈板是否存在

                Mread = Conn.GetDataReader("select top 1 Cartonqty,CartonStatus,Teamid from m_Carton_t a left join m_CartonSN_t b on a.Cartonid=b.Cartonid where a.CartonStatus='O' and b.ppid='" & TxtInput.Text & "'")
                If Mread.HasRows Then
                    While Mread.Read
                        PackQty = Mread!Cartonqty
                    End While
                Else
                    Me.LblMsg.Text = "产品条码[" + TxtInput.Text + "]不存在,或未进行包装出货..."
                    Mread.Close()
                    TxtInput.Clear()
                    TxtInput.Focus()
                    Exit Sub
                End If
                Mread.Close()

                Dim exesql As String = String.Format(" DECLARE @result int exec m_WhOutD_Rejected_p '{0}','{1}','2',@result = @result OUTPUT SELECT	@result as N'result'", TxtInput.Text, SysMessageClass.UseId)
                Try
                    ' Conn.ExecSql(sql)
                    Dim rev As Integer = 0
                    Dim RecDr As SqlDataReader = Conn.GetDataReader(exesql)
                    If RecDr.HasRows Then
                        RecDr.Read()
                        rev = RecDr.GetInt32(0)
                        RecDr.Close()
                    End If
                    If rev = 1 Then

                        LblMsg.Text = "退货成功"
                        LblMsg.ForeColor = Color.Green

                        dgScanData.Rows.Add(False, LblPartid.Text, TxtInput.Text, PackQty, SysMessageClass.UseId, Now.ToString("yyyy-MM-dd hh:mm:ss"), "")
                      

                    Else
                        LblMsg.Text = "退货失败"
                        LblMsg.ForeColor = Color.Red
                    End If
                Catch ex As Exception
                    LblMsg.Text = "退货失败" & ex.ToString
                    LblMsg.ForeColor = Color.Red
                End Try
            End If
        End If
    End Sub
End Class