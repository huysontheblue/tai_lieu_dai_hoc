
'工站維護
'Create by: 余烽華
'Create time: 2009/8/20
'Update by: 楊三良
'Update time: 2009/8/27

#Region "Imports引用"

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

Public Class FrmRStationSet

#Region "窗體公共變量"

    Public opflag As Int16 = 0  '判斷是新增還是修改
    Public frmRstationid As String = "" '向FrmRPartStation窗體回傳stationid
    Public frmRstationname As String = "" '向FrmRPartStation窗體回傳stationname
    Public frmStationtype As String = ""  '向FrmRPartStation窗體回傳StationType

#End Region

#Region "窗體加載"

    Private Sub FrmRstationSet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                '左方向鍵 
                SendKeys.Send("{+Tab}")  '按Shift + Tab 組合鍵 
            Case 13
                SendKeys.Send("{Tab}")
            Case 38 '上方向鍵 
            Case 39 '右方向鍵 
                'SendKeys.Send("{+Tab}")
            Case 40  '下方向鍵 
                'SendKeys.Send("{+Tab}")
            Case 27 'Esc鍵 
                Me.Close()
        End Select
    End Sub
    '窗體載入
    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Erightbutton() '讀取按鈕權限
            LoadDataToCombox()
            LoadDataToDatagridview(" where a.status=1")
            ToolbtnState(opflag)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    '控制菜單欄按鈕權限方法
    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        'Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02003' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        'Dim Obj As Object
        'While Reader.Read
        '    '通過控件名稱得到控件實例
        '    Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
        '    Obj.Tag = "Yes"
        'End While
        'Reader.Close()

        Dim Obj As Object
        Using dt As DataTable = Conn.GetDataTable("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02spt' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
            For Each dr As DataRow In dt.Rows
                Obj = CType(Me.GetType().GetField("_" & dr("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
                Obj.Tag = "Yes"
            Next
        End Using
    End Sub
    '設置按鈕按鈕及TextBox狀態
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '初始查詢狀態
                Me.toolAdd.Enabled = IIf(Me.toolAdd.Tag.ToString <> "Yes", False, True)
                Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                Me.toolAbandon.Enabled = IIf(Me.toolAbandon.Tag.ToString <> "Yes", False, True)
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                Me.toolCheck.Enabled = False
                'GroupBox
                Me.cboType.Enabled = True
                Me.txtStationdest.Enabled = False
                Me.txtStationid.Enabled = True
                Me.txtStationName.Enabled = True
                Me.dgvRstation.Enabled = True
                Me.ActiveControl = Me.txtStationid
            Case 1, 2 '新增,修改
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                Me.toolCheck.Enabled = False
                'GroupBox
                Me.txtStationdest.Enabled = True
                Me.txtStationName.Enabled = True
                Me.cboType.Enabled = IIf(opflag = 1, True, False)
                Me.txtStationid.Enabled = False
                Me.dgvRstation.Enabled = False
                Me.ActiveControl = IIf(opflag = 1, Me.cboType, Me.txtStationName)
            Case 3 '從FrmRPartStation窗體中開啟此窗體時的狀態
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                Me.toolCheck.Enabled = True
                'GroupBox
                Me.cboType.Enabled = True
                Me.txtStationdest.Enabled = False
                Me.txtStationid.Enabled = True
                Me.txtStationName.Enabled = True
                Me.dgvRstation.Enabled = True
                Me.ActiveControl = Me.txtStationid
        End Select
    End Sub

#End Region

#Region "給數據控件Cbo、Dg加載數據"
    '裝載CboType工站類別
    Private Sub LoadDataToCombox()

        Dim SqlStr As String = "select ID,StationTypeName from M_RUNCARDSTATIONTYPE_T where status =1 order by id"
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim Dreader As SqlDataReader = Conn.GetDataReader(SqlStr)
        'cboType.Items.Clear()
        'cboType.Items.Add("")
        'Do While Dreader.Read()
        '    cboType.Items.Add(Dreader.Item(0) & "-" & Dreader.Item(1))
        'Loop

        'Dreader.Close()
        cboType.Items.Clear()
        cboType.Items.Add("")
        Using dt As DataTable = Conn.GetDataTable("select ID,StationTypeName from M_RUNCARDSTATIONTYPE_T where status =1 order by id")
            For Each dr As DataRow In dt.Rows
                cboType.Items.Add(dr.Item(0) & "-" & dr.Item(1))
            Next
        End Using

        Conn = Nothing

    End Sub
    '裝載Dg表格
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim Dreader As SqlDataReader
        Dim SqlStr As String = ""

        dgvRstation.Rows.Clear()
        SqlStr = "select Cast(c.id as varchar) + '-' + c.stationTypename as StationType,Stationno,Stationname,a.description, " & _
 " case a.status when '1' then '1-衄虴' when 'N' then '0-釬煙' end as Usey," & _
" b.username,convert(varchar(19),a.intime,21) as intime " & _
" from M_RUNCARDSTATION_T a left join dbo.M_RUNCARDSTATIONTYPE_T c on a.Stationtypeid=c.id   " & _
" left join m_users_t b " & _
"on a.userid=b.userid "
        If Not String.IsNullOrEmpty(SqlWhere) Then SqlStr &= SqlWhere
        SqlStr &= " ORDER BY A.STATIONNO"
        'Dreader = Conn.GetDataReader(SqlStr)
        'Do While Dreader.Read()
        '    dgvRstation.Rows.Add(Dreader.Item(0).ToString, Dreader.Item(1).ToString, Dreader.Item(2).ToString, _
        '    Dreader.Item(3).ToString, Dreader.Item(4).ToString, Dreader.Item(5).ToString, Dreader.Item(6).ToString)
        'Loop
        'Dreader.Close()
        Using dt As DataTable = Conn.GetDataTable(SqlStr)
            For Each dr As DataRow In dt.Rows
                dgvRstation.Rows.Add(dr.Item(0).ToString, dr.Item(1).ToString, dr.Item(2).ToString, _
         dr.Item(3).ToString, dr.Item(4).ToString, dr.Item(5).ToString, dr.Item(6).ToString)
            Next
        End Using
        toolStripStatusLabel3.Text = Me.dgvRstation.Rows.Count
        Conn = Nothing
    End Sub

#End Region

#Region "CBO/DG等數據控件相關事件"
    '取消加載datagridview單元格有焦點
    Private Sub dgvRstation_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvRstation.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub
    '雙擊行事件
    Private Sub dgvRstation_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRstation.CellDoubleClick
        tsbCheck_Click(sender, e)
    End Sub

    Private Function Checkdata() As Boolean
        If Me.cboType.Text.Trim = "" Then
            'MessageBox.Show("請選擇工站類型！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.cboType
            Return False
        End If
        If Me.txtStationName.Text.Trim = "" Then
            'MessageBox.Show("請輸入工站名稱！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.txtStationName
            Return False
        End If
        Return True
    End Function

#End Region

#Region "菜單欄按鈕事件"
    '新增
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click

        txtStationName.Text = ""
        txtStationdest.Text = ""
        txtStationid.Text = ""
        opflag = 1
        ToolbtnState(1)

    End Sub
    '修改
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click

        '判斷記錄是否可以被修改
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        'If Me.dgvRstation.Item(4, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "Y" Then
        '    MessageBox.Show("該工站編號已經作廢，不允許進行修改！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        '控件賦值
        cboType.SelectedIndex = Me.cboType.FindString(dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim)
        txtStationid.Text = dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtStationName.Text = dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtStationdest.Text = dgvRstation.Item(3, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        '改變窗體狀態
        opflag = 2
        ToolbtnState(2)

    End Sub
    '作廢
    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        '判斷記錄是否可以被作廢
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        'If Me.dgvRstation.Item(4, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "Y" Then
        '    MessageBox.Show("蜆捩暮翹眒釬煙", "枑尨陓洘", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        'If MessageBox.Show("確定要作廢工站: [" + Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]-[" + Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "] 嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            Conn.ExecSql("update M_RUNCARDSTATION_T set status=0,userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() where Stationno = '" & Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
            'MessageBox.Show("成功作廢工站: [" + Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]-[" + Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataToDatagridview(" where Stationid='" & Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        End Try

    End Sub
    '保存
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim Rtable As New DataTable
        Dim SqlStr As New StringBuilder

        If Checkdata() = False Then Exit Sub
        If opflag = 1 Then  '新增后保存執行插入操作
            SqlStr.Append("declare @Stationid varchar(6),@type varchar(6) set @type='" & Me.cboType.Text.Trim.Split("-")(0) & "' " _
              & "select @Stationid=max(Stationid) from M_RUNCARDSTATION_T where stationtypeid =@type if @Stationid is null " _
              & "begin set @Stationid=@type + '00001' End Else begin " _
              & "set @Stationid=@type + right(Replicate('0',5) + cast(cast(right(@Stationid,5) as int)+1 as varchar),5) " _
              & " End ")
            SqlStr.Append(ControlChars.CrLf & "insert M_RUNCARDSTATION_T(Stationno, Stationname, Stationtypeid, description, status,userid, intime) " _
                     & " values(@Stationid,N'" & txtStationName.Text.Trim & "','" & cboType.Text.ToString.Trim.Split("-")(0) & "'," _
                     & " N'" & txtStationdest.Text.Trim & "',1,'" & SysMessageClass.UseId.ToLower.Trim & "',getdate())")
            SqlStr.Append(ControlChars.CrLf & "select @Stationid")
        ElseIf opflag = 2 Then     '修改后保存執行更新操作
            SqlStr.Append("update M_RUNCARDSTATION_T set Stationname =N'" & txtStationName.Text.Trim & "',description =N'" & txtStationdest.Text.Trim & "',userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() where Stationno = '" & txtStationid.Text.Trim & "' and status=1")
            'SqlStr.Append(ControlChars.CrLf & "select '" & txtStationid.Text.Trim & "'")
        End If
        Try
            Conn.ExecSql(SqlStr.ToString)
            LoadDataToDatagridview("  where Stationno='" & txtStationid.Text.Trim & "'")
            'LoadDataToDatagridview(" where a.usey='Y'")
            'MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            cboType.SelectedIndex = -1
            txtStationid.Text = ""
            txtStationName.Text = ""
            txtStationdest.Text = ""
            opflag = 0
            ToolbtnState(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbSave_Click", "sys")
            Exit Sub
        End Try

    End Sub
    '返回
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click

        cboType.SelectedIndex = -1
        txtStationid.Text = ""
        txtStationName.Text = ""
        txtStationdest.Text = ""
        opflag = 0
        ToolbtnState(0)

    End Sub
    '查詢
    Private Sub tsbQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click

        Dim flag As Boolean = False
        Dim Sql As String = "where 1=1"

        If Me.cboType.Text.Trim <> "" Then
            'If flag = False Then
            '    Sql = " where Stationtype='" & Me.cboType.Text.Trim.Split("-")(0) & "' "
            'Else
            Sql = Sql & " and StationtypeID='" & Me.cboType.Text.Trim.Split("-")(0) & "' "
            'flag = True
            'End If
        End If
        If Me.txtStationid.Text.Trim <> "" Then
            'If flag = False Then
            '    Sql = " where Stationid like '" & Me.txtStationid.Text.Trim & "%' "
            'Else
            Sql = Sql & " and StationNO like '" & Me.txtStationid.Text.Trim & "%' "
            'flag = True
            'End If
        End If
        If Me.txtStationName.Text.Trim <> "" Then
            'If flag = False Then
            '    Sql = " where Stationname like '" & Me.txtStationName.Text.Trim & "%' "
            'Else
            Sql = Sql & " and Stationname like '" & Me.txtStationName.Text.Trim & "%' "
            '    flag = True
            'End If
        End If
        LoadDataToDatagridview(Sql)

    End Sub
    '選擇
    Private Sub tsbCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCheck.Click
        If Me.toolCheck.Enabled = False Then Exit Sub
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        If Me.dgvRstation.Item(4, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "1" Then
            MessageBox.Show("蜆捩訧蹋眒釬煙", "枑尨陓洘", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        frmRstationid = Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        frmRstationname = Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        frmStationtype = Me.dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        Me.Close()
    End Sub
    '退出
    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click

        Me.Close()

    End Sub

#End Region

    Private Sub ToolBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBlock.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        '判斷記錄是否可以被作廢
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        'If Me.dgvRstation.Item(4, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "Y" Then
        '    MessageBox.Show("蜆捩暮翹眒釬煙", "枑尨陓洘", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        'If MessageBox.Show("確定要作廢工站: [" + Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]-[" + Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "] 嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            Conn.ExecSql("update M_RUNCARDSTATION_T set status=2,userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() where Stationno = '" & Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
            'MessageBox.Show("成功作廢工站: [" + Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]-[" + Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataToDatagridview(" where Stationid='" & Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
            MessageBox.Show("蜆桴萸眒冪輛俴雲賦,祥埰勍禸鏡...", "枑尨陓洘", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        End Try

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        '判斷記錄是否可以被作廢
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        'If Me.dgvRstation.Item(4, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "Y" Then
        '    MessageBox.Show("蜆捩暮翹眒釬煙", "枑尨陓洘", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        'If MessageBox.Show("確定要作廢工站: [" + Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]-[" + Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "] 嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            Conn.ExecSql("update M_RUNCARDSTATION_T set status=1,userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() where Stationno = '" & Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
            'MessageBox.Show("成功作廢工站: [" + Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]-[" + Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataToDatagridview(" where Stationid='" & Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
            MessageBox.Show("蜆桴萸眒冪賤壺雲賦,埰勍禸鏡...", "枑尨陓洘", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        End Try

    End Sub
End Class