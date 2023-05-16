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
Imports MainFrame

Public Class FrmSampleLine

#Region "变量定义"

    Public opflag As Int16 = 0  '
    Public m_strLineLeaderName As String = ""

    Private Enum enumdgvLineLeader
        deptid = 0
        lineid
        leaderid
        lineleadername
        lineleaderTel
        lineman
        typeid
        usey
        userid
        intime
    End Enum
#End Region

#Region "加载"

    Private Sub FrmRstationSet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                SendKeys.Send("{+Tab}")  'Shift + Tab
            Case 13
                SendKeys.Send("{Tab}")
            Case 38 '
            Case 39 '
                'SendKeys.Send("{+Tab}")
            Case 40  '
                'SendKeys.Send("{+Tab}")
            Case 27 '
                Me.Close()
        End Select
    End Sub

    Private Sub FrmLineLeader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Erightbutton()
            LoadDataToDatagridview()
            ToolbtnState(opflag)
            dgvLineLeader.Enabled = True
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Mread As SqlDataReader = sConn.GetDataReader(" SELECT deptid,dqc  FROM m_Dept_t WHERE Factoryid='" & VbCommClass.VbCommClass.Factory & "'")
        If Mread.HasRows Then
            While Mread.Read
                ' cboDept.Items.Add(Mread!deptid & "-" & Mread!dqc)
            End While
        End If
        Mread.Close()
        sConn.PubConnection.Close()
    End Sub

    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02003' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        Dim Obj As Object
        If Reader.HasRows Then
            While Reader.Read
                Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
                Obj.Tag = "Yes"
            End While
        End If
        Reader.Close()

        'Reader = Conn.GetDataReader("select Lineid,Linename from m_Dline_t where Usey='Y'")
        'If Reader.HasRows Then
        '    While Reader.Read
        '        cboLine.Items.Add(Reader!Lineid & "-" & Reader!Linename)
        '    End While
        'End If

        'Reader.Close()

    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0  ''初始查詢狀態
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True

                'GroupBox
                Me.ChkUsey.Checked = True
                Me.txtLineLeaderID.Enabled = True
                Me.txtLineID.Enabled = True
                Me.dgvLineLeader.Enabled = True
            Case 1, 2
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'GroupBox
                Me.txtLineLeaderID.Enabled = True
                txtLineID.Enabled = IIf(opflag = 1, True, False)
                Me.dgvLineLeader.Enabled = False
                ' Me.ActiveControl = IIf(opflag = 1, Me.cboDept, Me.txtLineLeaderID)
            Case 3
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'GroupBox
                ' Me.cboDept.Enabled = True
                Me.txtLineLeaderID.Enabled = False
                ' Me.txtLineManQty.Enabled = False
                Me.txtLineID.Enabled = True
                Me.dgvLineLeader.Enabled = True
                ' Me.ActiveControl = Me.cboDept
        End Select
    End Sub

#End Region

    Private Sub LoadDataToDatagridview(Optional ByVal SqlWhere As String = "")
        Dim SqlStr As String =
            " SELECT  lineid, leaderid, LeaderName, " & _
            " telphone, a.usey, userid, intime " & _
            " FROM m_SampleLine_t a " & _
            " Left join m_Dept_t b  on a.deptid = b.deptid " & _
            " WHERE 1=1 "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr & SqlWhere)

        dgvLineLeader.DataSource = dt
        Me.lblRecordCount.Text = dt.Rows.Count
    End Sub

#Region "CBO/DG事件"

    Private Sub dgvLineLeader_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)
        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts
    End Sub

    Private Function Checkdata() As Boolean

        If Me.txtLineID.Text.Trim = "" Then
            LblMsg.Text = "生产线别不能为空..."
            Me.ActiveControl = Me.txtLineID
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtLineLeaderID.Text) Then
            LblMsg.Text = "线长工号不能为空..."
            Me.ActiveControl = Me.txtLineLeaderID
            Return False
        End If

        If Not IsMESUser() Then
            LblMsg.Text = "输入的线长工号不在MES中！..."
            Me.ActiveControl = Me.txtLineLeaderID
            Return False
        End If

        Return True
    End Function

    Private Function IsMESUser() As Boolean
        Try
            Dim lsSQL As String = String.Empty
            lsSQL = _
                " SELECT USERID,userName" + vbCrLf + _
                " FROM M_Users_t" + vbCrLf + _
                " WHERE  USEY = 1 AND USERID = '" & Me.txtLineLeaderID.Text.Trim() & "'"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    m_strLineLeaderName = o_dt.Rows(0).Item("userName")
                    IsMESUser = True
                Else
                    IsMESUser = False
                End If
            End Using
            Return IsMESUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "菜单事件"

    '添加
    Private Sub toolAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click

        Me.txtLineID.Text = ""
        txtLineLeaderID.Text = ""
        opflag = 1
        ToolbtnState(1)
        Me.ChkUsey.Checked = True 'Default
        Me.LblMsg.Text = ""
        Me.ToolReUse.Enabled = False 'Add by cq 20151222
        Me.txtLineLeaderID.Enabled = True
    End Sub

    Private Sub toolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        If Me.dgvLineLeader.Rows.Count = 0 OrElse Me.dgvLineLeader.CurrentRow Is Nothing Then Exit Sub

        txtLineID.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.lineid).Value)
        txtLineLeaderID.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.leaderid).Value)
        Me.txtTel.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.lineleaderTel).Value)
        ChkUsey.Checked = IIf(DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.usey).Value) = "Y", True, False)
        opflag = 2
        ToolbtnState(2)

        Me.txtLineLeaderID.Enabled = False
    End Sub

    '作废
    Private Sub toolAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        Dim lsSQL As String = ""
        If Me.dgvLineLeader.Rows.Count = 0 OrElse Me.dgvLineLeader.CurrentRow Is Nothing Then Exit Sub

        Try
            lsSQL = _
                "UPDATE m_SampleLine_t" + vbCrLf + _
                "   SET usey = 'N'" + vbCrLf + _
                " WHERE lineid ='" & dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.lineid).Value & "'" + vbCrLf + _
                "      and leaderid ='" & dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.leaderid).Value & "'"

            DbOperateUtils.ExecSQL(lsSQL)
            LoadDataToDatagridview()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmLineLeader", "toolAbandon_Click", "Sample")
        End Try
    End Sub

    Private Sub toolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        Dim SqlStr As New StringBuilder
        Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")
        Dim o_strm_SampleLine_t As String = "", o_strSQL As String = "", o_strTypeID As String = ""
        Me.LblMsg.Text = ""

        If Checkdata() = False Then Exit Sub

        If opflag = 1 Then
            o_strSQL = " SELECT lineid FROM m_SampleLine_t WHERE deptid='" & o_strm_SampleLine_t & "' " & _
                       " AND lineid=N'" & Me.txtLineID.Text.Trim() & "' " & _
                       " AND leaderid ='" & Me.txtLineLeaderID.Text.Trim() & "'"
            Dim rowCnt As Integer = DbOperateUtils.GetRowsCount(o_strSQL)
            If rowCnt > 0 Then
                Me.LblMsg.Text = "该线别的线长已经存在!"
                MessageUtils.ShowError("该线别的线长已经存在！")
                Exit Sub
            End If
            SqlStr.Append(ControlChars.CrLf & "INSERT INTO m_SampleLine_t( lineid, leaderid,leaderName,USEY,userid,intime,TELPHONE) ")
            SqlStr.Append(" VALUES('" & o_strm_SampleLine_t & "',N'" & Me.txtLineID.Text.Trim & "','" & Me.txtLineLeaderID.Text.Trim() & "', N'" & m_strLineLeaderName & "',")
            SqlStr.Append(" '" & cheUsy & "',")
            SqlStr.Append("'" & SysMessageClass.UseId & "',GETDATE(), '" & txtTel.Text.Trim() & "' )")
        ElseIf opflag = 2 Then
            SqlStr.Append(" UPDATE m_SampleLine_t SET  USEY= '" & cheUsy & "',")
            SqlStr.Append(" USERID='" & SysMessageClass.UseId & "',intime=getdate(),telphone='" & Me.txtTel.Text.Trim & "' ")
            SqlStr.Append(" WHERE  lineid =N'" & Me.txtLineID.Text.Trim & "'")
            SqlStr.Append(" AND leaderid='" & Me.txtLineLeaderID.Text.Trim() & "'")
        End If
        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadDataToDatagridview()
            opflag = 0
            ToolbtnState(0)
            ClearUIValue(opflag)
            dgvLineLeader.Enabled = True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSampleLine", "toolSave_Click", "Sample")
            Exit Sub
        End Try
    End Sub

    Private Sub ClearUIValue(ByVal flag As Integer)
        Select Case flag
            Case 0 'default
                Me.txtLineID.Text = ""
                Me.txtLineLeaderID.Text = ""
                Me.LblMsg.Text = ""
            Case Else
        End Select
    End Sub
    '
    Private Sub toolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        opflag = 0
        ToolbtnState(0)
        ClearUIValue(opflag)
        Me.ToolReUse.Enabled = True
    End Sub

    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#End Region

    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        Dim strWhere As String = String.Empty

        If Me.txtLineID.Text.Trim <> "" Then
            strWhere = strWhere & " AND a.lineid ='" & Me.txtLineID.Text.Trim() & "'"
        End If

        If Me.txtLineLeaderID.Text.Trim <> "" Then
            strWhere = strWhere & " AND a.leaderid like '" & Me.txtLineLeaderID.Text.Trim & "%' "
        End If

        If Me.ChkUsey.Checked Then
            strWhere = strWhere & " AND a.usey like 'Y%' "
        Else
            strWhere = strWhere & " AND a.usey like 'N%' "
        End If

        LoadDataToDatagridview(strWhere)
    End Sub

    Private Sub ToolReUse_Click(sender As Object, e As EventArgs) Handles ToolReUse.Click
        Dim o_sbSQL As New StringBuilder
        If Me.dgvLineLeader.Rows.Count = 0 OrElse Me.dgvLineLeader.CurrentRow Is Nothing Then Exit Sub

        Try
            With dgvLineLeader.CurrentRow

                If .Cells(enumdgvLineLeader.usey).Value = "Y" Then
                    MessageBox.Show("该条记录已经生效,无需再生效！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                o_sbSQL.Append(" DELETE FROM m_SampleLine_t  WHERE deptid = '" & .Cells(enumdgvLineLeader.deptid).Value & "' AND ")
                o_sbSQL.Append(" LINEID ='" & .Cells(enumdgvLineLeader.lineid).Value & "'")
                o_sbSQL.Append(" AND leaderid ='" & .Cells(enumdgvLineLeader.leaderid).Value & "' AND usey='Y'")
                o_sbSQL.Append(" UPDATE m_SampleLine_t")
                o_sbSQL.Append(" SET usey = 'Y'")
                o_sbSQL.Append(" WHERE deptid = '" & .Cells(enumdgvLineLeader.deptid).Value & "' AND lineid ='" & .Cells(enumdgvLineLeader.lineid).Value & "'")
                o_sbSQL.Append(" AND leaderid ='" & .Cells(enumdgvLineLeader.leaderid).Value & "'")
            End With
            DbOperateUtils.ExecSQL(o_sbSQL.ToString)
            LoadDataToDatagridview()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmLineLeader", "ToolReUse_Click", "sys")
        End Try
    End Sub

    Private Sub txtTel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTel.KeyPress
        e.Handled = True
        '输入0－9和回连键时有效  
        If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = "" Then
            e.Handled = False
        End If
        '输入-情况  
        If e.KeyChar = "-" Then
            '不能在第一位  
            If txtTel.Text.Length <= 0 Then
                e.Handled = True
            Else
                '-不在第一位  
                e.Handled = False
            End If
        End If
    End Sub

    Private Function GetTelFromDCS(ByVal parUserID As String) As String
        Dim lsSQL As String = String.Empty
        GetTelFromDCS = ""
        Try
            lsSQL = " SELECT count(1) from dbo.SysObjects WHERE id = OBJECT_ID('dcsdb.dbo.MV_DCS_CPF')"
            Using dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item(0) = 0 Then
                        Return GetTelFromDCS
                    End If
                End If
            End Using

            lsSQL = " SELECT CPF15 FROM [DCSDB].[dbo].[MV_DCS_CPF] WHERE  CPF01='" & parUserID & "'"

            Dim dtTel As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If dtTel.Rows.Count > 0 Then
                GetTelFromDCS = DbOperateUtils.DBNullToStr(dtTel.Rows(0)(0).ToString)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub txtLineLeaderID_Leave(sender As Object, e As EventArgs) Handles txtLineLeaderID.Leave
        Dim o_strTel As String = String.Empty
        If Not String.IsNullOrEmpty(Me.txtLineLeaderID.Text) Then
            o_strTel = GetTelFromDCS(txtLineLeaderID.Text.Trim)
            '  txtTel.Text = GetTelFromDCS(txtLineLeaderID.Text.Trim)
            If Not String.IsNullOrEmpty(o_strTel) Then
                txtTel.Text = o_strTel
            Else
                'do nothing
            End If
        End If
    End Sub

    Private Function GetTypeName(ByVal strTypeID As String) As String
        Dim o_strSQL As String = String.Empty
        o_strSQL = " SELECT typeName from m_ProductType_t  where typeid ='" & strTypeID & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(o_strSQL)
            If Not IsNothing(o_dt) And o_dt.Rows.Count > 0 Then
                GetTypeName = o_dt.Rows(0).Item(0)
            Else
                GetTypeName = ""
            End If
        End Using
        Return GetTypeName
    End Function

    Private Sub dgvLineLeader_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvLineLeader.CellPainting
        'If Me.dgvLineLeader.Rows.Count = 0 OrElse Me.dgvLineLeader.CurrentRow Is Nothing Then Exit Sub
        'Dim o_strTypeID As String = String.Empty
        'Dim o_strFinishTypeID As String = String.Empty
    End Sub
End Class