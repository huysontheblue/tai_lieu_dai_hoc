
'菜单维护
'Create by: 马锋
'Create time: 2015-06-01
'Update by: 
'Update time:  

#Region "Importsまノ"

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

Public Class FrmLogTree

#Region "变量声明"

    Public opflag As Int16 = 0
#End Region

#Region "加载"

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

    Private Sub FrmLogTree_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadDataToDatagridview(" ")
        ToolbtnState(opflag)
        dgvLogTree.Enabled = True
    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True

                Me.txtRemark.Enabled = False
                Me.txtTreeCode.Enabled = False
                Me.txtTreeName.Enabled = False
                Me.ActiveControl = Me.txtTreeCode
            Case 1
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False

                Me.txtTreeCode.Enabled = True
                Me.txtTreeName.Enabled = True
                Me.txtRemark.Enabled = True
                Me.ChkUsey.Enabled = False

                Me.txtTreeCode.Text = ""
                Me.txtTreeCode.Text = ""
                Me.txtRemark.Text = ""

                Me.ActiveControl = Me.txtTreeCode
            Case 2
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False

                Me.txtTreeCode.Enabled = True
                Me.txtTreeName.Enabled = False
                Me.txtRemark.Enabled = True

                Me.ActiveControl = Me.txtTreeCode
        End Select
    End Sub

#End Region

    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader = Nothing
        Try

            Dim SqlStr As String = ""

            dgvLogTree.Rows.Clear()
            SqlStr = "select Enname, Ttext, Remark, Usey from m_Logtree_t where  Tparent='M0_'  "
            Dreader = Conn.GetDataReader(SqlStr & SqlWhere)
            Do While Dreader.Read()
                dgvLogTree.Rows.Add(Dreader.Item(0).ToString, Dreader.Item(1).ToString, Dreader.Item(2).ToString, _
                Dreader.Item(3).ToString)
            Loop
            Dreader.Close()
            Conn.PubConnection.Close()
            toolStripStatusLabel3.Text = Me.dgvLogTree.Rows.Count

        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            If Not (Dreader.IsClosed) Then
                Dreader.Close()
            End If
            SetMessage("查询异常", False)
        End Try

    End Sub

#Region "CBO/DG"

    Private Sub dgvRstation_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvLogTree.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts
    End Sub

    Private Function Checkdata() As Boolean
        If Me.txtTreeCode.Text.Trim = "" Then
            SetMessage("菜单编号资料不能为空...", False)
            Me.ActiveControl = Me.txtTreeCode
            Return False
        End If
        If Me.txtTreeName.Text.Trim = "" Then
            SetMessage("菜单名称不能为空...", False)
            Me.ActiveControl = Me.txtTreeName
            Return False
        End If
        Return True
    End Function

#End Region

#Region "工具栏事件"

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click
        SetMessage("", False)
        opflag = 1
        ToolbtnState(1)
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        SetMessage("", False)
        If Me.dgvLogTree.Rows.Count = 0 OrElse Me.dgvLogTree.CurrentRow Is Nothing Then Exit Sub

        Me.txtTreeCode.Text = dgvLogTree.CurrentRow.Cells("TreeCode").Value
        Me.txtTreeName.Text = dgvLogTree.CurrentRow.Cells("TreeName").Value
        Me.txtRemark.Text = dgvLogTree.CurrentRow.Cells("Remark").Value
        Me.ChkUsey.Checked = IIf(dgvLogTree.CurrentRow.Cells("ColUsey").Value = "Y", True, False)
        opflag = 2
        ToolbtnState(2)

    End Sub

    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        'SetMessage("", False)
        'If Me.dgvLogTree.Rows.Count = 0 OrElse Me.dgvLogTree.CurrentRow Is Nothing Then Exit Sub

        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

        'Try
        '    Conn.ExecSql("update m_Logtree_t set usey='N' where Ttext = '" & dgvLogTree.CurrentRow.Cells("ColLineid").Value & "'")
        '    'MessageBox.Show("Θ紀: [" + Me.dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]-[" + Me.dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim + "]", "╰参矗ボ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    LoadDataToDatagridview(" where Ttext=N'" & dgvLogTree.CurrentRow.Cells("ColLineid").Value & "'")
        'Catch ex As Exception
        '    SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        '    SetMessage("作废异常", False)
        'End Try

    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        SetMessage("", False)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

        Dim SqlStr As New StringBuilder
        Dim TreeCount As String=""
        Dim TreeId As String
        Dim Tkey As String
        Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")

        If Checkdata() = False Then Exit Sub
        If opflag = 1 Then

            Dim mCheckCodeRead As SqlDataReader = Conn.GetDataReader("SELECT Treeid FROM m_Logtree_t WHERE Ttext=N'" & Me.txtTreeName.Text.Trim() & "'")
            If mCheckCodeRead.HasRows Then

                mCheckCodeRead.Close()
                MessageBox.Show("菜单已经存在！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            mCheckCodeRead.Close()

            Dim mRead As SqlDataReader = Conn.GetDataReader("SELECT count(Treeid) as countTreeid FROM m_Logtree_t WHERE Tparent='m0_'")

            If mRead.HasRows Then
                While mRead.Read
                    TreeCount = Convert.ToInt16(mRead!countTreeid) + 1
                End While
            Else
                TreeCount = "1"
            End If

            mRead.Close()

            TreeId = "m0_" + TreeCount.PadLeft(2, "0")
            Tkey = "m0_" + TreeCount.PadLeft(2, "0") + "_"

            '新增权限
            SqlStr.Append(ControlChars.CrLf & "INSERT INTO m_Logtree_t(Treeid, Tkey, Tparent, Ttext, Enname, Remark, Rightid, Timage, Tsimage, TADimage, TADsimage, TADUsey, TADid, listy, Usey " _
              & " ) VALUES('" & TreeId & "','" & Tkey & "','m0_',N'" & Me.txtTreeName.Text.Trim() & "',N'" & Me.txtTreeCode.Text.Trim() & "',N'" & Me.txtRemark.Text.Trim() & "','mes00','1','1','1','1','N',NULL,'Y', '" & cheUsy & "')")

        ElseIf opflag = 2 Then

            '更新权限
            SqlStr.Append(ControlChars.CrLf & " update m_Logtree_t set Ttext=N'" & Me.txtTreeName.Text.Trim() & "', Enname=N'" & Me.txtTreeCode.Text.Trim() & "', Remark=N'" & Me.txtRemark.Text.Trim & "', Usey='" & cheUsy & "' where Tparent='m0_' and Ttext=N'" & Me.txtTreeName.Text.Trim() & "' ")

        End If
        Try
            Conn.ExecSql(SqlStr.ToString)
            LoadDataToDatagridview(" where Ttext=N'" & Me.txtTreeName.Text.Trim() & "'")

            opflag = 0
            ToolbtnState(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbSave_Click", "sys")
            SetMessage("保存异常", False)
            Exit Sub
        End Try

    End Sub

    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        SetMessage("", False)
        opflag = 0
        ToolbtnState(0)

    End Sub

    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        SetMessage("", False)
        LoadDataToDatagridview(" ")
    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#End Region

    Private Sub SetMessage(ByVal Message As String, ByVal bType As Boolean)
        If (bType) Then
            Me.lblMessage.ForeColor = Color.Green
        Else
            Me.lblMessage.ForeColor = Color.Red
        End If
        Me.lblMessage.Text = Message
    End Sub

End Class