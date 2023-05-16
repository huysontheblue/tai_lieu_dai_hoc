
'窗体资料维护
'Create by: 马锋
'Create time: 2015-06-01
'Update by: 
'Update time:  

#Region "Imports"

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

Public Class FrmSNRule

#Region "变量声明"

    Public opflag As Int16 = 0

#End Region

#Region "加载事件"

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

    Private Sub FrmWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'DtStar.Value = DateAdd(DateInterval.Day, -1, Now())
        'DtEnd.Value = Now()
        Erightbutton() '弄秙舦
        'LoadDataToCombox()
        LoadDataToDatagridview(" ")
        ToolbtnState(opflag)
        dgvLogTree.Enabled = True
    End Sub

    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        'Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02003' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        'Dim Obj As Object
        'If Reader.HasRows Then
        '    While Reader.Read
        '        '硄筁北ン嘿眔北ン龟ㄒ
        '        Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
        '        Obj.Tag = "Yes"
        '    End While
        'End If
        'Reader.Close()

        Dim Reader As SqlDataReader = Conn.GetDataReader("select Factoryid,Shortname from m_Dcompany_t where Usey='Y'")
        If Reader.HasRows Then
            With Reader.Read
                cbbFactory.Items.Add(Reader!Factoryid & "-" & Reader!Shortname)
            End With
        End If
        Reader.Close()
        cbbFactory.SelectedIndex = -1

    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '﹍琩高篈
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = False

                'GroupBox
                Me.cbbFactory.Enabled = False
                Me.txtRemark.Enabled = False
                Me.txtDeptCode.Enabled = False
                Me.txtDeptName.Enabled = False
                Me.dgvLogTree.Enabled = False
                Me.ActiveControl = Me.txtDeptCode
            Case 1, 2 '穝糤,э
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'Me.toolCheck.Enabled = False

                'GroupBox
                Me.txtRemark.Enabled = True
                Me.txtDeptName.Enabled = True
                Me.cbbFactory.Enabled = IIf(opflag = 1, True, False)
                'Me.txtStationName.Enabled = False
                Me.dgvLogTree.Enabled = False
                Me.ActiveControl = IIf(opflag = 1, Me.cbbFactory, Me.txtDeptName)
            Case 3 '眖FrmRPartStation怠砰い秨币怠砰篈
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = True
                'GroupBox
                Me.cbbFactory.Enabled = True
                Me.txtRemark.Enabled = False
                Me.txtDeptName.Enabled = True
                Me.txtDeptName.Enabled = True
                Me.dgvLogTree.Enabled = True

                Me.ActiveControl = Me.txtDeptName
        End Select
    End Sub

#End Region

    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader
        Dim SqlStr As String = ""

        dgvLogTree.Rows.Clear()
        SqlStr = "select deptid,djc,dqc,Factoryid,usey from m_Dept_t where usey='Y' "
        Dreader = Conn.GetDataReader(SqlStr & SqlWhere)
        Do While Dreader.Read()
            dgvLogTree.Rows.Add(Dreader.Item(0).ToString, Dreader.Item(1).ToString, Dreader.Item(2).ToString, _
            Dreader.Item(3).ToString, Dreader.Item(4).ToString)
        Loop
        Dreader.Close()
        toolStripStatusLabel3.Text = Me.dgvLogTree.Rows.Count
        Conn = Nothing
    End Sub

#Region "CBO/DG"

    Private Sub dgvRstation_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

    Private Sub dgvRstation_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        tsbCheck_Click(sender, e)
    End Sub

    Private Function Checkdata() As Boolean
        If Me.txtDeptCode.Text.Trim = "" Then
            LblMsg.Text = "部门编号资料不能为空..."
            Me.ActiveControl = Me.txtDeptCode
            Return False
        End If
        If Me.txtDeptName.Text.Trim = "" Then
            LblMsg.Text = "部门名称不能为空..."
            Me.ActiveControl = Me.txtDeptName
            Return False
        End If
        If Me.cbbFactory.Text.Trim = "" Then
            LblMsg.Text = "部门所属公司不能为空..."
            Me.ActiveControl = Me.cbbFactory
            Return False
        End If
        Return True
    End Function

#End Region

#Region "菜单事件"

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click

        txtDeptCode.Text = ""
        txtRemark.Text = ""
        txtDeptName.Text = ""
        cbbFactory.SelectedIndex = -1
        opflag = 1
        ToolbtnState(1)
        txtDeptCode.Enabled = True

    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click

        If Me.dgvLogTree.Rows.Count = 0 OrElse Me.dgvLogTree.CurrentRow Is Nothing Then Exit Sub

        txtDeptCode.Text = dgvLogTree.CurrentRow.Cells("ColLineid").Value
        txtDeptName.Text = dgvLogTree.CurrentRow.Cells("ColLineName").Value
        cbbFactory.Text = dgvLogTree.CurrentRow.Cells("ColLinegx").Value
        txtRemark.Text = dgvLogTree.CurrentRow.Cells("Colmark").Value

        opflag = 2
        ToolbtnState(2)

    End Sub

    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click

        If Me.dgvLogTree.Rows.Count = 0 OrElse Me.dgvLogTree.CurrentRow Is Nothing Then Exit Sub
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

        Try
            Conn.ExecSql("update m_Dept_t set usey='N' where deptid = '" & dgvLogTree.CurrentRow.Cells("ColLineid").Value & "'")
            LoadDataToDatagridview(" where deptid='" & dgvLogTree.CurrentRow.Cells("ColLineid").Value & "'")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        End Try

    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim Rtable As New DataTable
        Dim SqlStr As New StringBuilder
        Dim TreeCount As String=""
        Dim TreeId As String
        Dim Tkey As String
        Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")

        If Checkdata() = False Then Exit Sub
        If opflag = 1 Then

            Dim mCheckCodeRead As SqlDataReader = Conn.GetDataReader("SELECT lineid FROM deptline_t WHERE lineid='" & Me.txtDeptCode.Text.Trim() & "'")
            If mCheckCodeRead.HasRows Then

                mCheckCodeRead.Close()
                MessageBox.Show("线别已经存在！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            mCheckCodeRead.Close()

            Dim mRead As SqlDataReader = Conn.GetDataReader("SELECT count(Treeid) as countTreeid FROM m_Logtree_t WHERE Tparent='z09_'")

            If mRead.HasRows Then
                While mRead.Read
                    TreeCount = Convert.ToInt16(mRead!countTreeid) + 1
                End While
            Else
                TreeCount = "1"
            End If

            mRead.Close()

            TreeId = "z01" + TreeCount.PadLeft(3, "0")
            Tkey = "z01" + TreeCount.PadLeft(3, "0") + "_"

            SqlStr.Append(ControlChars.CrLf & "insert into m_Dept_t(deptid, djc, Factoryid,dqc,usey) " _
                     & " values('" & txtDeptCode.Text & "',N'" & txtDeptName.Text.Trim & "','" & cbbFactory.Text.ToString.Trim.Split("-")(0) & "'," _
                     & " N'" & txtRemark.Text.Trim & "','Y')")

            '新增权限
            SqlStr.Append(ControlChars.CrLf & "INSERT INTO m_Logtree_t(Treeid, Tkey, Tparent, Ttext, Enname, TreeTag, Rightid, Formid, ButtonID, Timage, Tsimage, TADimage, " _
              & " TADsimage, TADUsey, TADid, listy) VALUES('" & TreeId & "','" & Tkey & "','z09_',N'" & Me.txtDeptCode.Text.Trim() & "',N'" & Me.txtDeptName.Text.Trim() & "',null,'mes00','Line','" & Me.txtDeptCode.Text.Trim & "','4','4','2','3','Y',null,'N')")

        ElseIf opflag = 2 Then
            SqlStr.Append("update m_Dept_t set djc =N'" & txtDeptName.Text.Trim & "',dqc =N'" & txtRemark.Text.Trim & "' where deptid = '" & txtDeptCode.Text.Trim & "'")
            'SqlStr.Append(ControlChars.CrLf & "select '" & txtStationid.Text.Trim & "'")

            '更新权限
            SqlStr.Append(ControlChars.CrLf & " update m_Logtree_t set Ttext=N'" & Me.txtDeptCode.Text.Trim() & "', Enname=N'" & Me.txtDeptName.Text.Trim() & "' where Tparent='z09_' and Ttext=N'" & Me.txtDeptCode.Text.Trim() & "' ")

        End If
        Try
            Conn.ExecSql(SqlStr.ToString)
            LoadDataToDatagridview(" ")

            cbbFactory.SelectedIndex = -1
            txtDeptName.Text = ""
            txtDeptName.Text = ""
            txtRemark.Text = ""
            opflag = 0
            ToolbtnState(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbSave_Click", "sys")
            Exit Sub
        End Try

    End Sub
    '
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click

        cbbFactory.SelectedIndex = -1
        txtDeptCode.Text = ""
        txtDeptName.Text = ""
        txtRemark.Text = ""
        opflag = 0
        ToolbtnState(0)

    End Sub

    Private Sub tsbCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#End Region

    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        LoadDataToDatagridview(" ")
    End Sub

End Class