

#Region "Imports Area"

Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle

#End Region

Public Class FrmMjBasicMessage

#Region "怠砰そ跑秖"

    Public opflag As Int16 = 0  '耞琌穝糤临琌э
    Public frmRstationid As String = "" 'FrmRPartStation怠砰肚stationid
    Public frmRstationname As String = "" 'FrmRPartStation怠砰肚stationname
    Public frmStationtype As String = ""  'FrmRPartStation怠砰肚StationType

#End Region

#Region "怠砰更"

    Private Sub FrmRstationSet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                'オよ龄 
                SendKeys.Send("{+Tab}")  'Shift + Tab 舱龄 
            Case 13
                SendKeys.Send("{Tab}")
            Case 38 'よ龄 
            Case 39 'よ龄 
                'SendKeys.Send("{+Tab}")
            Case 40  'よ龄 
                'SendKeys.Send("{+Tab}")
            Case 27 'Esc龄 
                Me.Close()
        End Select
    End Sub
    '怠砰更
    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Erightbutton() '弄秙舦
        LoadDataToCombox()
        LoadDataToDatagridview(" where a.usey='Y'")
        opflag = 0
        ToolbtnState(opflag)

    End Sub
    '北垫虫逆秙舦よ猭
    'Private Sub Erightbutton()
    '    Dim Conn As New SysDataBaseClass
    '    Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02003' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
    '    Dim Obj As Object
    '    While Reader.Read
    '        '硄筁北ン嘿眔北ン龟ㄒ
    '        Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
    '        Obj.Tag = "Yes"
    '    End While
    '    Reader.Close()
    'End Sub
    '砞竚秙秙のTextBox篈
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '﹍琩高篈
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                Me.toolCheck.Enabled = False
                'GroupBox
                TxtCarriType.Enabled = False
                Me.TxtCcavQty.Enabled = False
                Me.TxtCarrierDesc.Enabled = False
                Me.TxtCarrierName.Enabled = False
                Me.TxtAllowUseCount.Enabled = False
                Me.TxtAlertCount.Enabled = False
                TxtCarrierID.Enabled = False
                Me.dgvRstation.Enabled = True
                TxtCarrierDesc.Enabled = False
                Me.TxtPartid.Enabled = False
            Case 1, 2 '穝糤,э
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                Me.toolCheck.Enabled = False
                'GroupBox
                Me.TxtCarriType.Enabled = True
                Me.TxtCcavQty.Enabled = True
                Me.TxtCarrierDesc.Enabled = True
                Me.TxtCarrierName.Enabled = True
                Me.TxtAllowUseCount.Enabled = True
                Me.TxtAlertCount.Enabled = True
                TxtCarrierID.Enabled = True
                Me.dgvRstation.Enabled = False
                TxtCarrierDesc.Enabled = True
                Me.TxtPartid.Enabled = True
            Case 3 '眖FrmRPartStation怠砰い秨币怠砰篈
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                Me.toolCheck.Enabled = False
                'GroupBox
                Me.TxtCcavQty.Enabled = True
                Me.TxtCarrierDesc.Enabled = True
                Me.TxtCarrierName.Enabled = True
                Me.TxtAllowUseCount.Enabled = True
                Me.TxtAlertCount.Enabled = True
                TxtCarrierID.Enabled = False
                Me.TxtCarriType.Enabled = False
                Me.dgvRstation.Enabled = False
                TxtCarrierDesc.Enabled = True
                Me.TxtPartid.Enabled = True
        End Select
    End Sub

#End Region

#Region "加载载具类别及线别"

    Private Sub LoadDataToCombox()

        Dim SqlStr As String = "select distinct CarrierType from m_Carrier_t where  Usey='Y'"
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader
        Dreader = Conn.GetDataReader(SqlStr)
        CobMatype.Items.Clear()
        CobMatype.Items.Add("")
        Do While Dreader.Read()
            CobMatype.Items.Add(Dreader.Item(0).ToString)
        Loop
        Dreader.Close()

        SqlStr = "select distinct a.deptid,b.djc from deptline_t a join m_Dept_t b on a.deptid=b.deptid where b.usey='Y'"
        Dreader = Conn.GetDataReader(SqlStr)
        Cobdept.Items.Clear()
        Cobdept.Items.Add("")
        Do While Dreader.Read()
            Cobdept.Items.Add(Dreader.Item(0).ToString & "-" & Dreader.Item(1).ToString)
        Loop

        Dreader.Close()

        Conn = Nothing

    End Sub
    '杆更Dg
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader
        Dim SqlStr As String = ""

        dgvRstation.Rows.Clear()
        SqlStr = "select Partid,CarrierType,CarrierID,CarrierName,CarrierCcav,AllowUseCount,AlertCount,CarrierDesc, " _
              & " case a.usey when 'Y' then 'Y-有效' when 'N' then 'N-作废' end as Usey,b.username,convert(varchar(19),a.intime,21) as intime  " _
              & " from m_Carrier_t a left join m_users_t b " _
              & " on a.userid=b.userid " & SqlWhere
        Dreader = Conn.GetDataReader(SqlStr)
        Do While Dreader.Read()
            dgvRstation.Rows.Add(Dreader.Item(0).ToString, Dreader.Item(1).ToString, Dreader.Item(2).ToString, _
            Dreader.Item(3).ToString, Dreader.Item(4).ToString, Dreader.Item(5).ToString, Dreader.Item(6).ToString, Dreader.Item(7).ToString, Dreader.Item(8).ToString, Dreader.Item(9).ToString, Dreader.Item(10).ToString)
        Loop
        Dreader.Close()
        toolStripStatusLabel3.Text = Me.dgvRstation.Rows.Count
        Conn = Nothing

    End Sub

#End Region

#Region "CBO/DG单计沮北ン闽ㄆン"
    '更datagridview虫じΤ礘翴
    Private Sub dgvRstation_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvRstation.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub
    ''蛮阑︽ㄆン
    'Private Sub dgvRstation_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRstation.CellDoubleClick
    '    tsbCheck_Click(sender, e)
    'End Sub

    Private Function Checkdata() As Boolean

        If Me.TxtCarriType.Text.Trim = "" Then
            MessageBox.Show("载具类别不能为空...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCarrierID.Focus()
            Return False
        End If
        If Me.TxtPartid.Text = "" Then
            MessageBox.Show("料件编号不能为空...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCarrierID.Focus()
            Return False
        End If
        If Me.TxtCcavQty.Text.Trim = "" Then
            MessageBox.Show("子件数量不能为空...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCarrierID.Focus()
            Return False
        End If
        If Me.TxtCarrierID.Text.Trim = "" Then
            MessageBox.Show("载具编号不能为空...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCarrierID.Focus()
            Return False
        End If
        If Me.TxtCarrierName.Text.Trim = "" Then
            MessageBox.Show("载具名称不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.TxtCarrierName
            Return False
        End If
        If Me.TxtAllowUseCount.Text.Trim = "" Then
            MessageBox.Show("载具使用寿命不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtAllowUseCount.Focus()
            Return False
        End If
        If Me.TxtAlertCount.Text.Trim = "" Then
            MessageBox.Show("载具预警次数不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtAlertCount.Focus()
            Return False
        End If
        If CInt(TxtAlertCount.Text) >= CInt(TxtAllowUseCount.Text) Then
            MessageBox.Show("载具预警次数不能超过使用次数", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtAlertCount.Focus()
            Return False
        End If
        Return True
    End Function

#End Region

#Region "垫虫逆秙ㄆン"
    '穝糤
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click

        Me.TxtCarriType.Text = ""
        Me.TxtCcavQty.Text = ""
        TxtCarrierName.Text = ""
        TxtCarrierDesc.Text = ""
        TxtCarrierID.Text = ""
        TxtAllowUseCount.Text = ""
        TxtAlertCount.Text = ""
        Me.TxtPartid.Text = ""
        opflag = 1
        ToolbtnState(1)

    End Sub
    'э
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click

        '耞癘魁琌砆э
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        Me.TxtPartid.Text = dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        Me.TxtCarriType.Text = dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        Me.TxtCarrierID.Text = dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        TxtCarrierName.Text = dgvRstation.Item(3, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        TxtCcavQty.Text = dgvRstation.Item(4, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        TxtAllowUseCount.Text = dgvRstation.Item(5, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        TxtAlertCount.Text = dgvRstation.Item(6, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        TxtCarrierDesc.Text = dgvRstation.Item(7, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        'TxtCarrierDesc.Text = dgvRstation.Item(8, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        'э跑怠砰篈
        opflag = 3
        ToolbtnState(opflag)

    End Sub
    '紀
    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        '耞癘魁琌砆紀
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        'If Me.dgvRstation.Item(4, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "Y" Then
        '    MessageBox.Show("该笔记录已作废", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        'If MessageBox.Show("絋﹚璶紀: [" + Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]-[" + Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "] 盾?", "╰参矗ボ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            'Conn.ExecSql("update m_Carrier_t set usey='N',userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() where CarrierID = '" & Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
            Conn.ExecSql("delete m_Carrier_t  where CarrierID = '" & Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
            'MessageBox.Show("Θ紀: [" + Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]-[" + Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]", "╰参矗ボ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataToDatagridview(" where CarrierID='" & Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        End Try

    End Sub
    '玂
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim Rtable As New DataTable
        Dim SqlStr As New StringBuilder

        If Checkdata() = False Then Exit Sub
        If opflag = 1 Then 
            ' INSERT INTO [MESDB].[dbo].[m_Carrier_t]
            '([CarrierID]
            ',[CarrierName]
            ',[CarrierType]
            ',[CarrierCcav]
            ',[AllowUseCount]
            ',[AlertCount]
            ',[CarrierDesc]
            ',[Usey]
            ',[Userid]
            ',[Intime])
            ' VALUES()

            SqlStr.Append("insert [m_Carrier_t]([CarrierType],[Partid],[CarrierID], [CarrierName], [CarrierCcav], [AllowUseCount], [AlertCount], [CarrierDesc], usey, userid,LastMainDate, intime) " & _
                      " values('" & TxtCarriType.Text & "','" & TxtPartid.Text & "','" & TxtCarrierID.Text & "',N'" & TxtCarrierName.Text.Trim & "','" & TxtCcavQty.Text & "'," & _
                      " '" & TxtAllowUseCount.Text & "','" & TxtAlertCount.Text & "',N'" & TxtCarrierDesc.Text & "','Y','" & SysMessageClass.UseId.ToLower.Trim & "',getdate())")
            'SqlStr.Append(ControlChars.CrLf & "select @Stationid")
            SqlStr.Append(vbNewLine & " insert into m_CarrierMainTain_t(CarrierID,MainDate,IsNew,Mark,Userid,Intime)values('" & TxtCarrierID.Text & "',getdate(),'Y',N'系统初始化','" & SysMessageClass.UseId.ToLower.Trim & "',getdate(),getdate())")
        ElseIf opflag = 3 Then     'э玂磅︽穝巨
            SqlStr.Append("update m_Carrier_t set CarrierName =N'" & TxtCarrierName.Text & "',Partid='" & TxtPartid.Text & "',CarrierCcav='" & TxtCcavQty.Text & "',AllowUseCount='" & TxtAllowUseCount.Text & "',AlertCount='" & TxtAlertCount.Text & "', CarrierDesc =N'" & TxtCarrierDesc.Text.Trim & "',userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() where CarrierID = '" & TxtCarrierID.Text.Trim & "' and usey='Y'")
            'SqlStr.Append(ControlChars.CrLf & "select '" & txtStationid.Text.Trim & "'")
        End If
        Try
            Conn.ExecSql(SqlStr.ToString)
            LoadDataToDatagridview("  where CarrierID='" & TxtCarrierID.Text.Trim & "'")
            'LoadDataToDatagridview(" where a.usey='Y'")
            'MessageBox.Show("玂Θ", "╰参矗ボ", MessageBoxButtons.OK, MessageBoxIcon.Information)

            TxtCarriType.Text = ""
            TxtCarrierID.Text = ""
            TxtAlertCount.Text = ""
            TxtAllowUseCount.Text = ""
            TxtCcavQty.Text = ""
            TxtCarrierName.Text = ""
            TxtCarrierDesc.Text = ""
            opflag = 0
            ToolbtnState(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbSave_Click", "sys")
            Exit Sub
        End Try

    End Sub
    '
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click

        TxtCarriType.Text = ""
        TxtCarrierName.Text = ""
        TxtCarrierDesc.Text = ""
        TxtCarrierID.Text = ""
        TxtAllowUseCount.Text = ""
        TxtAlertCount.Text = ""
        TxtCcavQty.Text = ""
        TxtPartid.Text = ""
        opflag = 0
        ToolbtnState(0)

    End Sub
    '琩高
    Private Sub tsbQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click

        Dim flag As Boolean = False
        Dim Sql As String = "where 1=1"

        If Me.TxtCarriType.Text.Trim <> "" Then
            'If flag = False Then
            '    Sql = " where Stationtype='" & Me.cboType.Text.Trim.Split("-")(0) & "' "
            'Else
            Sql = Sql & " and CarrierType='" & Me.TxtCarriType.Text & "' "
            'flag = True
            'End If
        End If
        If Me.TxtCarrierID.Text.Trim <> "" Then
            'If flag = False Then
            '    Sql = " where Stationid like '" & Me.txtStationid.Text.Trim & "%' "
            'Else
            Sql = Sql & " and CarrierID like '" & Me.TxtCarrierID.Text.Trim & "%' "
            'flag = True
            'End If
        End If
        If Me.TxtCarrierName.Text.Trim <> "" Then
            'If flag = False Then
            '    Sql = " where Stationname like '" & Me.txtStationName.Text.Trim & "%' "
            'Else
            Sql = Sql & " and CarrierName like '" & Me.TxtCarrierName.Text.Trim & "%' "
            '    flag = True
            'End If
        End If
        LoadDataToDatagridview(Sql)

    End Sub
    ''匡拒
    'Private Sub tsbCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCheck.Click

    '    If Me.toolCheck.Enabled = False Then Exit Sub
    '    If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
    '    If Me.dgvRstation.Item(4, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "Y" Then
    '        MessageBox.Show("该笔资料已作废", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Exit Sub
    '    End If
    '    frmRstationid = Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
    '    frmRstationname = Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
    '    frmStationtype = Me.dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
    '    Me.Close()

    'End Sub
    '癶
    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click

        Me.Close()

    End Sub

#End Region

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAllowUseCount.KeyPress

        If Char.IsDigit(e.KeyChar) = False AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAlertCount.KeyPress

        If Char.IsDigit(e.KeyChar) = False AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If

    End Sub

  
    Private Sub TxtCcavQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCcavQty.KeyPress

        If Char.IsDigit(e.KeyChar) = False AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If

    End Sub

    Private Sub Cobdept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cobdept.SelectedIndexChanged

        Dim SqlStr As String = " select  lineid from dbo.deptline_t where deptid='" & Cobdept.Text.Split("-")(0) & "' and   Usey='Y'"
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader
        Dreader = Conn.GetDataReader(SqlStr)
        CobLineid.Items.Clear()
        CobLineid.Items.Add("")
        Do While Dreader.Read()
            CobLineid.Items.Add(Dreader.Item(0).ToString)
        Loop
        Dreader.Close()

    End Sub

    Private Sub toolCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCheck.Click

        If CobMatype.Text = "" Then
            MessageBox.Show("机台类别不能为空，请选择机台类别...")
            CobMatype.Focus()
            Exit Sub
        End If
        If CobLineid.Text = "" Then
            MessageBox.Show("机台产量计数线别不能为空，请选择对应的产量统计线别...")
            CobLineid.Focus()
            Exit Sub
        End If
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            Conn.ExecSql("update m_Carrier_t set LineID='" & CobLineid.Text & "' where CarrierType='" & CobMatype.Text & "'")
            MessageBox.Show("保存成功...", "提示信息")
        Catch ex As Exception
            MessageBox.Show("保存时，发生错误...", "提示信息")
        End Try


    End Sub

   
End Class