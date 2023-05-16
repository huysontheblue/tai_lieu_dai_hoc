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

Public Class FrmLineLookUp
    Public opflag As Int16 = 0
    
    Private Sub toolAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click
        '点击新增
        txtStationid.Text = ""
        txtCusLine.Text = ""
        opflag = 1
        ToolbtnState(1)

    End Sub

    Private Sub toolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        '编辑选中的行
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        cobLine.Text = dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtStationid.Text = dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtCusLine.Text = dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        opflag = 2
        ToolbtnState(2)
        Me.cobLine.Enabled = False
        txtStationid.Enabled = True
    End Sub

    Private Sub toolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        '保存新增或修改的资料
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Rtable As New DataTable
        Dim SqlStr As New StringBuilder

        If Checkdata() = False Then Exit Sub
        If opflag = 1 Then
            SqlStr.Append(ControlChars.CrLf & "insert into m_LineLookUp_t (LineId,StationId,CusLineId,UserId,Usey,InTime)" _
                     & " values('" & cobLine.Text.Trim.ToString() & "',N'" & txtStationid.Text.Trim & "',N'" & txtCusLine.Text.Trim.ToString() & "'," _
                     & " N'" & SysMessageClass.UseId & "','Y',getdate())")

        ElseIf opflag = 2 Then
            SqlStr.Append("update m_LineLookUp_t set StationId=N'" & txtStationid.Text.ToString & "',CusLineId =N'" & txtCusLine.Text.Trim & "',UserId='" & SysMessageClass.UseId & "',intime=getdate() where LineId = '" & cobLine.Text.Trim & "' and usey='Y'")
            SqlStr.Append(ControlChars.CrLf & "select '" & cobLine.Text.Trim & "'")
        End If
        Try
            Rtable = Conn.GetDataTable(SqlStr.ToString)
            LoadDataToDatagridview(" where Lineid='" & cobLine.Text.ToString.Trim & "'")

            cobLine.SelectedIndex = -1
            txtStationid.Text = ""
            txtCusLine.Text = ""
            opflag = 0
            ToolbtnState(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbSave_Click", "sys")
            Exit Sub
        End Try
    End Sub

    Private Sub toolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        cobLine.SelectedIndex = -1
        txtStationid.Text = ""
        txtCusLine.Text = ""
        opflag = 0
        ToolbtnState(0)
    End Sub

    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        Dim flag As Boolean = False
        Dim Sql As String = "where 1=1"

        If Me.cobLine.Text.Trim <> "" Then

            Sql = Sql & " and Lineid='" & Me.cobLine.Text.Trim & "' "

        End If
        If Me.txtStationid.Text.Trim <> "" Then

            Sql = Sql & " and Stationid like '" & Me.txtStationid.Text.Trim & "%' "

        End If
        If Me.txtCusLine.Text.Trim <> "" Then

            Sql = Sql & " and CusLine like '" & Me.txtCusLine.Text.Trim & "%' "

        End If
        LoadDataToDatagridview(Sql)
    End Sub

    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
         Try
            Conn.ExecSql("update m_LineLookUp_t set usey='N',intime=getdate() where LineID = '" & Me.dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
            LoadDataToDatagridview(" where LineID='" & Me.dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        End Try
    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '清空
                Me.toolAdd.Enabled = IIf(Me.toolAdd.Tag.ToString <> "Yes", False, True)
                Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                Me.toolAbandon.Enabled = IIf(Me.toolAbandon.Tag.ToString <> "Yes", False, True)
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = False
                'GroupBox
                Me.cobLine.Enabled = True
                Me.txtStationid.Enabled = True
                Me.txtCusLine.Enabled = True
                Me.dgvRstation.Enabled = True
                Me.ActiveControl = Me.txtStationid
            Case 1, 2 '新增，编辑
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'Me.toolCheck.Enabled = False
                'GroupBox

                Me.txtCusLine.Enabled = True
                Me.cobLine.Enabled = IIf(opflag = 1, True, False)
                Me.txtStationid.Enabled = True
                Me.dgvRstation.Enabled = False
                Me.ActiveControl = IIf(opflag = 1, Me.cobLine, Me.txtCusLine)
            Case 3
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = True
                'GroupBox
                Me.cobLine.Enabled = True
                Me.txtStationid.Enabled = True
                Me.txtCusLine.Enabled = True
                Me.dgvRstation.Enabled = True
                Me.ActiveControl = Me.txtStationid
        End Select
    End Sub

    Private Sub FrmLineLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Erightbutton()
        LoadDataToCombox()
        LoadDataToDatagridview(" where a.usey='Y'")
        ToolbtnState(opflag)
    End Sub
    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02003' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        Dim Obj As Object
        While Reader.Read
            Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
            Obj.Tag = "Yes"
        End While
        Reader.Close()
    End Sub

    Private Sub LoadDataToCombox()

        Dim SqlStr As String = "select lineid from deptline_t where usey='Y' order by lineid"
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader = Conn.GetDataReader(SqlStr)
        cobLine.Items.Clear()
        cobLine.Items.Add("")
        Do While Dreader.Read()
            cobLine.Items.Add(Dreader.Item(0))
        Loop

        Dreader.Close()
        Conn = Nothing

    End Sub

    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader
        Dim SqlStr As String = ""

        dgvRstation.Rows.Clear()
        SqlStr = "select LineId,StationId,CusLineId,  " _
              & " case a.Usey when 'Y' then 'Y-有效' when 'N' then 'N-已作廢' end as Usey,UserId,convert(varchar(19),a.intime,21) as intime  " _
              & " from m_LineLookUp_t a  " _
              & "  " & SqlWhere
        Dreader = Conn.GetDataReader(SqlStr)
        Do While Dreader.Read()
            dgvRstation.Rows.Add(Dreader.Item(0).ToString, Dreader.Item(1).ToString, Dreader.Item(2).ToString, _
            Dreader.Item(3).ToString, Dreader.Item(4).ToString, Dreader.Item(5).ToString)
        Loop
        Dreader.Close()
        toolStripStatusLabel3.Text = Me.dgvRstation.Rows.Count
        Conn = Nothing
    End Sub


    Private Function Checkdata() As Boolean



        If Me.cobLine.Text.Trim = "" Then
            MessageBox.Show("公司线别不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.cobLine
            Return False
        End If

        If Me.txtStationid.Text.Trim = "" Then
            MessageBox.Show("站点编码不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.txtStationid
            Return False
        End If
        If Me.txtCusLine.Text.Trim = "" Then
            MessageBox.Show("客户线别不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.txtCusLine
            Return False
        End If
        If opflag = 1 Then
            Dim Dreader As SqlDataReader
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            Dreader = Conn.GetDataReader("select Lineid from m_LineLookUp_t where usey='Y' and Lineid='" & cobLine.Text & "'")
            If Dreader.HasRows Then
                MessageBox.Show("已经存在该公司线别与客户线别的对照关系，请确认！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dreader.Close()
                Me.ActiveControl = Me.cobLine
                Return False
            End If
            Dreader.Close()
            Conn.PubConnection.Close()
        End If

        Return True
    End Function

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        Dim FrmFWModify As New FrmFWModify
        FrmFWModify.ShowDialog()
    End Sub
End Class