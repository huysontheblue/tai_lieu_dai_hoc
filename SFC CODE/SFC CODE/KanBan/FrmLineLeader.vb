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
Imports SysBasicClass

Public Class FrmLineLeader

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

        '关晓艳 2017-10-27 新增6个字段
        PieCode
        PieName
        PqeCode
        PqeName
        SjCode
        SjName
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
            FillCombox(cboDept)
            'Add by cq 20160801
            FillType(CboType)
            LoadDataToDatagridview()
            ToolbtnState(opflag)
            dgvLineLeader.Enabled = True
            cboDept.SelectedIndex = -1
            Me.CboType.SelectedIndex = -1
        Catch ex As Exception
            'Throw ex
        End Try
    End Sub

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Mread As SqlDataReader = sConn.GetDataReader(" SELECT deptid,dqc  FROM m_Dept_t WHERE Factoryid='" & VbCommClass.VbCommClass.Factory & "'")
        If Mread.HasRows Then
            While Mread.Read
                cboDept.Items.Add(Mread!deptid & "-" & Mread!dqc)
            End While
        End If
        Mread.Close()
        sConn.PubConnection.Close()
    End Sub

    Private Sub FillType(ByVal ColComboBox As ComboBox)
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Mread As SqlDataReader = sConn.GetDataReader(" SELECT typeid,typeName  FROM m_ProductType_t WHERE Usey='Y'")
        If Mread.HasRows Then
            While Mread.Read
                CboType.Items.Add(Mread!typeid & "-" & Mread!typeName)
            End While
        End If
        Mread.Close()
        sConn.PubConnection.Close()
    End Sub

    '
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

        Reader = Conn.GetDataReader("select Lineid,Linename from m_Dline_t where Usey='Y'")
        If Reader.HasRows Then
            While Reader.Read
                cboLine.Items.Add(Reader!Lineid & "-" & Reader!Linename)
            End While
        End If

        Reader.Close()

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
                Me.cboDept.Enabled = True
                Me.txtLineLeaderID.Enabled = True
                Me.cboLine.Enabled = True
                Me.txtLineManQty.Enabled = True
                Me.dgvLineLeader.Enabled = True
                Me.ActiveControl = Me.cboDept
                Me.CboType.Enabled = True
            Case 1, 2
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'GroupBox
                Me.txtLineLeaderID.Enabled = True
                Me.txtLineManQty.Enabled = True
                cboDept.Enabled = IIf(opflag = 1, True, False)
                cboLine.Enabled = IIf(opflag = 1, True, False)
                Me.dgvLineLeader.Enabled = False
                Me.ActiveControl = IIf(opflag = 1, Me.cboDept, Me.txtLineLeaderID)
            Case 3
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'GroupBox
                Me.cboDept.Enabled = True
                Me.txtLineLeaderID.Enabled = False
                Me.txtLineManQty.Enabled = False
                Me.cboLine.Enabled = True
                Me.dgvLineLeader.Enabled = True
                Me.ActiveControl = Me.cboDept
        End Select
    End Sub

#End Region

    Private Sub LoadDataToDatagridview(Optional ByVal SqlWhere As String = "")
        'Dim SqlStr As String =
        '    " SELECT a.deptid+'-'+b.dqc as deptid, lineid, leaderid, LeaderName, " & _
        '    " telphone,lineman, a.typeName as typeid  , a.usey, userid, intime " & _
        '    " FROM deptlineD_t a " & _
        '    " Left join m_Dept_t b  ON a.deptid = b.deptid " & _
        '    " WHERE 1=1 "

        'gg()
        Dim SqlStr As String =
            " SELECT a.deptid+'-'+b.dqc as deptid, lineid, leaderid, LeaderName," & _
            "telphone,lineman, a.typeName as typeid  , a.usey, userid, intime," & _
            "PieCode ,PieName ,PqeCode ,PqeName ,SjCode ,SjName  " & _
            "FROM deptlineD_t a  Left join m_Dept_t b  ON a.deptid = b.deptid " & _
            "WHERE 1=1 "


        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr & SqlWhere)

        dgvLineLeader.DataSource = dt
        Me.lblRecordCount.Text = dt.Rows.Count
        '" Left join m_ProductType_t  c ON c.typeid = a.typeid and c.useY='Y' " & _
    End Sub

#Region "CBO/DG事件"

    Private Sub dgvLineLeader_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)
        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts
    End Sub


    Private Function Checkdata() As Boolean

        If Me.cboDept.Text.Trim = "" Then
            LblMsg.Text = "生产部门不能为空..."
            Me.ActiveControl = Me.cboDept
            Return False
        End If

        'If DbOperateUtils.GetDataTable("select*FROM deptlineD_t  WHERE lineid ='" & Me.cboLine.Text.Trim & "'").Rows.Count > 0 Then
        '    LblMsg.Text = "生产线别已存在..."
        '    Me.ActiveControl = Me.cboLine
        '    Return False
        'End If

        If Me.cboLine.Text.Trim = "" Then
            LblMsg.Text = "生产线别不能为空..."
            Me.ActiveControl = Me.cboLine
            Return False
        End If

        If Me.txtLineManQty.Text <> "" Then
            If Val(Me.txtLineManQty.Text) <= 0 Then
                LblMsg.Text = "线别人数必须大于0..."
                Me.ActiveControl = Me.txtLineManQty
                Me.txtLineManQty.Focus()
                Return False
            End If
        End If

        If String.IsNullOrEmpty(Me.txtLineLeaderID.Text) Then
            LblMsg.Text = "线长工号不能为空..."
            Me.ActiveControl = Me.txtLineLeaderID
            Return False
        End If

        '关晓艳 2018-05-21 修改线长姓名手动输入，取消卡控  
        'If Not IsMESUser() Then
        '    LblMsg.Text = "输入的线长工号不在MES中！..."
        '    Me.ActiveControl = Me.txtLineLeaderID
        '    Return False
        'End If
        If String.IsNullOrEmpty(Me.txtLineLeaderName.Text) Then
            LblMsg.Text = "线长姓名不能为空..."
            Me.ActiveControl = Me.txtLineLeaderName
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
        Me.cboDept.SelectedIndex = -1
        Me.cboLine.SelectedIndex = -1
        Me.CboType.SelectedIndex = -1
        Me.cboLine.Text = ""
        txtLineLeaderID.Text = ""
        Me.txtLineManQty.Text = ""
        opflag = 1
        ToolbtnState(1)
        Me.ChkUsey.Checked = True 'Default
        Me.LblMsg.Text = ""
        Me.ToolReUse.Enabled = False 'Add by cq 20151222
        Me.txtLineLeaderID.Enabled = True
        Me.CboType.Enabled = True
    End Sub

    Private Sub toolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        If Me.dgvLineLeader.Rows.Count = 0 OrElse Me.dgvLineLeader.CurrentRow Is Nothing Then Exit Sub

        cboDept.SelectedIndex = Me.cboDept.FindString(DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.deptid).Value))
        If Me.cboLine.Items.Count <= 0 Then
            Call BindLine(DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.deptid).Value))
        End If

        CboType.SelectedIndex = Me.CboType.FindString(DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.typeid).Value))

        cboLine.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.lineid).Value)
        txtLineLeaderID.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.leaderid).Value)
        Me.txtTel.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.lineleaderTel).Value)
        txtLineManQty.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.lineman).Value)
        '关晓艳 2017-10-27 新增6个栏位信息
        txtpieCode.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.PieCode).Value)
        txtpieName.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.PieName).Value)
        txtpqeCode.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.PqeCode).Value)
        txtpqeName.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.PqeName).Value)
        txtsjCode.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.SjCode).Value)
        txtsjName.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.SjName).Value)
        '关晓艳 2018-05-21 手动修改线长姓名
        txtLineLeaderName.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.lineleadername).Value)

        ChkUsey.Checked = IIf(DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.usey).Value) = "Y", True, False)
        opflag = 2
        ToolbtnState(2)

        'me.txtlineleaderid.enabled = false
    End Sub

    '作废
    Private Sub toolAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        Dim lsSQL As String = ""
        If Me.dgvLineLeader.Rows.Count = 0 OrElse Me.dgvLineLeader.CurrentRow Is Nothing Then Exit Sub

        Try
            lsSQL = _
                "UPDATE deptlineD_t" + vbCrLf + _
                "   SET usey = 'N'" + vbCrLf + _
                " WHERE deptid = '" & dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.deptid).Value.Split("-")(0) & "' and lineid ='" & dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.lineid).Value & "'" + vbCrLf + _
                "      and leaderid ='" & dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.leaderid).Value & "'"

            DbOperateUtils.ExecSQL(lsSQL)
            LoadDataToDatagridview()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmLineLeader", "toolAbandon_Click", "sys")
        End Try
    End Sub

    Private Sub toolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        Dim SqlStr As New StringBuilder
        Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")
        Dim o_strDeptlineD_t As String = "", o_strSQL As String = "", o_strTypeID As String = ""
        Me.LblMsg.Text = ""

        If Checkdata() = False Then Exit Sub

        If IsNothing(cboDept.SelectedValue) Then
            o_strDeptlineD_t = Me.cboDept.Text.Split("-")(0)
        Else
            o_strDeptlineD_t = cboDept.SelectedValue.ToString.Trim()
        End If

        If IsNothing(CboType.SelectedValue) Then
            o_strTypeID = Me.CboType.Text.Split("-")(0)
        Else
            o_strTypeID = CboType.SelectedValue.ToString.Trim()
        End If

        If opflag = 1 Then
            o_strSQL = " SELECT lineid FROM DeptlineD_t WHERE deptid='" & o_strDeptlineD_t & "' " & _
                       " AND lineid=N'" & Me.cboLine.Text.Trim() & "' " & _
                       " AND leaderid ='" & Me.txtLineLeaderID.Text.Trim() & "'"
            Dim rowCnt As Integer = DbOperateUtils.GetRowsCount(o_strSQL)
            If rowCnt > 0 Then
                Me.LblMsg.Text = "该线别的线长已经存在!"
                MessageUtils.ShowError("该线别的线长已经存在！")
                Exit Sub
            End If
            If DbOperateUtils.GetDataTable("select*FROM deptlineD_t  WHERE lineid ='" & Me.cboLine.Text.Trim & "'").Rows.Count > 0 Then
                Me.LblMsg.Text = "该线别已经存在线长!"
                MessageUtils.ShowError("该线别已经存在线长！")
                Exit Sub
            End If
            'SqlStr.Append(ControlChars.CrLf & "INSERT INTO DeptlineD_t(deptid, lineid, leaderid,leaderName,lineman,USEY,userid,intime,TELPHONE) ")
            'SqlStr.Append(" VALUES('" & o_strDeptlineD_t & "',N'" & Me.cboLine.Text.Trim & "','" & Me.txtLineLeaderID.Text.Trim() & "', N'" & m_strLineLeaderName & "',")
            'SqlStr.Append(" " & Val(Me.txtLineManQty.Text.Trim) & ",'" & cheUsy & "',")
            'SqlStr.Append("'" & SysMessageClass.UseId & "',GETDATE(), '" & txtTel.Text.Trim() & "' )")
            '关晓艳 2017-10-27 新增6个栏位信息，重写sql语句 
            '王南刚 2018-03-12 修改了SQL语句
            '关晓艳 2018-05-21 修改线长姓名手动输入 m_strLineLeaderName改为Me.txtLineLeaderName.Text.Trim()
            SqlStr.Append(ControlChars.CrLf & "INSERT INTO DeptlineD_t(deptid, lineid, leaderid,leaderName,lineman,USEY,userid,intime,TELPHONE,PieCode ,PieName ,PqeCode ,PqeName ,SjCode ,SjName) ")
            SqlStr.Append(" VALUES('" & o_strDeptlineD_t & "',N'" & Me.cboLine.Text.Trim & "','" & Me.txtLineLeaderID.Text.Trim() & "', N'" & Me.txtLineLeaderName.Text.Trim() & "',")
            SqlStr.Append(" " & Val(Me.txtLineManQty.Text.Trim) & ",'" & cheUsy & "',")
            SqlStr.Append("'" & SysMessageClass.UseId & "',GETDATE(), '" & txtTel.Text.Trim() & "',")
            SqlStr.Append("'" & Me.txtpieCode.Text.Trim() & "',N'" & Me.txtpieName.Text.Trim() & "','" & Me.txtpqeCode.Text.Trim() & "',N'" & Me.txtpqeName.Text.Trim() & "','" & Me.txtsjCode.Text.Trim() & "',N'" & Me.txtsjName.Text.Trim() & "')")

        ElseIf opflag = 2 Then
            'SqlStr.Append(" UPDATE deptlineD_t SET lineman= " & Val(Me.txtLineManQty.Text.Trim) & ", USEY= '" & cheUsy & "',")
            'SqlStr.Append(" USERID='" & SysMessageClass.UseId & "',intime=getdate(),telphone='" & Me.txtTel.Text.Trim & "' ")
            'SqlStr.Append(" WHERE deptid = '" & cboDept.Text.Trim.Split("-")(0) & "' AND  lineid =N'" & Me.cboLine.Text.Trim & "'")
            'SqlStr.Append(" AND leaderid='" & Me.txtLineLeaderID.Text.Trim() & "'")
            '关晓艳 2017-10-27 更新6个栏位的信息 
            '王南刚 2018-03-12 修改了SQL语句
            '关晓艳 2018-05-21 修改线长姓名手动输入 m_strLineLeaderName改为Me.txtLineLeaderName.Text.Trim()
            SqlStr.Append(" UPDATE deptlineD_t SET   leaderid=N'" & txtLineLeaderID.Text & "', leadername=N'" & Me.txtLineLeaderName.Text.Trim() & "',lineman = '" & Val(Me.txtLineManQty.Text.Trim) & "',USEY= '" & cheUsy & "',")
            SqlStr.Append(" USERID=N'" & SysMessageClass.UseId & "',intime=getdate(),telphone=N'" & Me.txtTel.Text.Trim & "',typename=N'" & CboType.Text & "' ")
            SqlStr.Append(", PieCode=N'" & Me.txtpieCode.Text.Trim() & "',PieName=N'" & Me.txtpieName.Text.Trim() & "' ")
            SqlStr.Append(", PqeName=N'" & Me.txtpqeName.Text.Trim() & "',PqeCode=N'" & Me.txtpqeCode.Text.Trim() & "' ")
            SqlStr.Append(", SjCode=N'" & Me.txtsjCode.Text.Trim() & "',SjName=N'" & Me.txtsjName.Text.Trim() & "' ")
            SqlStr.Append(" WHERE deptid = N'" & cboDept.Text.Trim.Split("-")(0) & "' ")
            SqlStr.Append(" AND lineid=N'" & Me.cboLine.Text.Trim() & "' AND usey='Y' ")
            'AND  lineid =N'" & Me.cboLine.Text.Trim & "'
        End If
        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadDataToDatagridview()
            opflag = 0
            ToolbtnState(0)
            ClearUIValue(opflag)
            dgvLineLeader.Enabled = True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmDeptLine", "toolSave_Click", "sys")
            Exit Sub
        End Try
    End Sub

    Private Sub ClearUIValue(ByVal flag As Integer)
        Select Case flag
            Case 0 'default
                Me.cboDept.Text = ""
                Me.cboLine.Text = ""
                Me.txtLineLeaderID.Text = ""
                Me.txtLineManQty.Text = ""
                ' Me.txtTel.Text = ""
                Me.LblMsg.Text = ""

                '关晓艳 2017-10-27 清空新增6个栏位信息
                Me.txtpieCode.Text = ""
                Me.txtpieName.Text = ""
                Me.txtpqeCode.Text = ""
                Me.txtpqeName.Text = ""
                Me.txtsjName.Text = ""
                Me.txtsjCode.Text = ""
                '关晓艳 2018-05-21 清空线长姓名
                Me.txtLineLeaderName.Text = ""
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

        If Me.cboDept.Text.Trim <> "" Then
            strWhere = strWhere & " AND a.deptid='" & Me.cboDept.Text.Trim.Split("-")(0) & "' "
        End If

        If Me.cboLine.Text.Trim <> "" Then
            strWhere = strWhere & " AND a.lineid ='" & Me.cboLine.Text.Trim() & "'"
        End If

        If Me.txtLineLeaderID.Text.Trim <> "" Then
            strWhere = strWhere & " AND a.leaderid like '" & Me.txtLineLeaderID.Text.Trim & "%' "
        End If

        If Me.ChkUsey.Checked Then
            strWhere = strWhere & " AND a.usey like 'Y%' "
        Else
            strWhere = strWhere & " AND a.usey like 'N%' "
        End If

        If Me.CboType.Text <> "" Then
            'ISNULL(CHARINDEX( ',E20,', ','+TYPEID + ','),-1) >0 
            strWhere = strWhere & " AND ISNULL(CHARINDEX('," & Me.CboType.Text.Trim.Split("-")(0) & ",',','+TypeID +','),-1) >0"
        End If

        LoadDataToDatagridview(strWhere)
    End Sub

    Private Sub cbbFactory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim lsSQL As String = String.Empty
        lsSQL = "SELECT deptid,dqc FROM m_Dept_t WHERE Factoryid='" & cboDept.Text.Split("-")(0) & "'"
        Dim Mread As SqlDataReader = sConn.GetDataReader(lsSQL)
        If Mread.HasRows Then
            While Mread.Read
                cboDept.Items.Add(Mread!deptid & "-" & Mread!dqc)
            End While
        End If
        Mread.Close()
        sConn.PubConnection.Close()
    End Sub

    Private Sub CboDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDept.SelectedIndexChanged
        Dim o_sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim o_strDeptid As String = ""
        Try
            cboLine.Items.Clear()
            If cboDept.SelectedValue Is Nothing Then
                If cboDept.Text <> String.Empty Then
                    o_strDeptid = cboDept.Text.Split("-")(0)
                End If
            Else
                o_strDeptid = cboDept.SelectedValue
            End If

            Dim Mread As SqlDataReader = o_sConn.GetDataReader("SELECT lineid  FROM deptline_t where deptid='" & o_strDeptid & "' and usey='Y'")
            If Mread.HasRows Then
                While Mread.Read
                    cboLine.Items.Add(Mread!lineid)
                End While
            End If
            Mread.Close()
            o_sConn.PubConnection.Close()
        Catch ex As Exception
            Throw ex
        Finally
            o_sConn = Nothing
        End Try
    End Sub

    Private Sub BindLine(ByVal parDeptID As String)
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        cboLine.Items.Clear()

        Dim Mread As SqlDataReader = sConn.GetDataReader(" SELECT lineid  FROM deptline_t WHERE deptid='" & parDeptID & "' AND usey='Y'")
        If Mread.HasRows Then
            While Mread.Read
                cboLine.Items.Add(Mread!lineid)
            End While
        End If
        Mread.Close()
        sConn.PubConnection.Close()
    End Sub

    Private Sub ToolReUse_Click(sender As Object, e As EventArgs) Handles ToolReUse.Click
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim o_sbSQL As New StringBuilder
        If Me.dgvLineLeader.Rows.Count = 0 OrElse Me.dgvLineLeader.CurrentRow Is Nothing Then Exit Sub

        Try
            With dgvLineLeader.CurrentRow

                If .Cells(enumdgvLineLeader.usey).Value = "Y" Then
                    MessageBox.Show("该条记录已经生效,无需再生效！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                o_sbSQL.Append(" DELETE FROM deptlineD_t  WHERE deptid = '" & dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.deptid).Value.Split("-")(0) & "' AND ")
                o_sbSQL.Append(" LINEID ='" & .Cells(enumdgvLineLeader.lineid).Value & "'")
                o_sbSQL.Append(" AND leaderid ='" & .Cells(enumdgvLineLeader.leaderid).Value & "' AND usey='Y'")
                o_sbSQL.Append(" UPDATE deptlineD_t")
                o_sbSQL.Append(" SET usey = 'Y'")
                o_sbSQL.Append(" WHERE deptid = '" & dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.deptid).Value.Split("-")(0) & "' AND lineid ='" & .Cells(enumdgvLineLeader.lineid).Value & "'")
                o_sbSQL.Append(" AND leaderid ='" & .Cells(enumdgvLineLeader.leaderid).Value & "'")
            End With
            DbOperateUtils.ExecSQL(o_sbSQL.ToString)
            LoadDataToDatagridview()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmLineLeader", "ToolReUse_Click", "sys")
        End Try
    End Sub

    Private Sub txtLineManQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLineManQty.KeyPress
        e.Handled = True
        '输入0－9和回连键时有效  
        If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = "" Then
            e.Handled = False
        End If
        '输入小数点情况  
        If e.KeyChar = "." Then
            '小数点不能在第一位  
            If txtLineManQty.Text.Length <= 0 Then
                e.Handled = True
            Else
                '小数点不在第一位  
                Dim f As Double
                If Double.TryParse(txtLineManQty.Text + e.KeyChar, f) Then
                    e.Handled = False
                End If
            End If
        End If
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


    Private Sub toolType_Click(sender As Object, e As EventArgs) Handles toolType.Click
        Dim isAdd As Boolean
        Dim isDelete As Boolean
        Try
            If toolAdd.Tag Is Nothing Then toolAdd.Tag = "NO"
            isAdd = (toolAdd.Tag.ToString.ToUpper() = "YES")
            isDelete = (toolAbandon.Tag.ToString.ToUpper() = "YES")

            'If dgvRstation.Item(enumdgvRstation.Stationtype, dgvRstation.CurrentRow.Index).Value.ToString().Trim().Split("-")(0).ToUpper <> "R" Then
            '    MessageBox.Show("非流程卡工站，不需要维护校验项次!")
            '    Exit Sub
            'End If

            'Id/StationNo/StationName
            Using frm As New FrmLineType(dgvLineLeader.Item(1, dgvLineLeader.CurrentRow.Index).Value.ToString(), _
                                                           isAdd, isDelete)
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvLineLeader_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvLineLeader.CellFormatting


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

        'If IsDBNull(Me.dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.typeid).Value) Then
        '    o_strTypeID = ""
        'Else
        '    o_strTypeID = Me.dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.typeid).Value.ToString
        'End If

        'If Not String.IsNullOrEmpty(o_strTypeID) Then
        '    For Each o_strTempTypeID As String In o_strTypeID.Split(",")
        '        o_strFinishTypeID = o_strFinishTypeID + IIf(o_strFinishTypeID.Equals(String.Empty), "", ",") + GetTypeName(o_strTempTypeID)
        '    Next
        'End If

        'If Not String.IsNullOrEmpty(o_strFinishTypeID) Then
        '    Me.dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.typeid).Value = o_strFinishTypeID
        'End If
    End Sub

    Private Sub toolUpdateTTLineLeader_Click(sender As Object, e As EventArgs) Handles toolUpdateTTLineLeader.Click
        'Dim OracleObject As New OracleDb("")

        'Dim lsSQL As String = ""

        'lsSQL = " SELECT  tc_imc01 as LineID, tc_imd03 as LeaderID , tc_imd04 as LeaderName " & _
        '        " FROM " & VbCommClass.VbCommClass.Factory & ".TC_IMC_FILE a  " & _
        '        " LEFT JOIN  " & VbCommClass.VbCommClass.Factory & ".tc_imd_file  b ON  a.tc_imc01=b.tc_imd01" & _
        '        " WHERE 1 = 1 "


        'Dim o_dtTTLineInfo As DataTable = OracleObject.ExecuteQuery(lsSQL).Tables(0)

        'If Not IsNothing(o_dtTTLineInfo) AndAlso o_dtTTLineInfo.Rows.Count > 0 Then
        '    Call updateMESLineLeaderInfo(o_dtTTLineInfo)
        'Else
        '    Exit Sub
        'End If

        'MessageUtils.ShowInformation("更新OK!")
    End Sub


    Private Sub updateMESLineLeaderInfo(ByVal M_TTLINE_T As DataTable)
        Dim lsSQL As String = ""

        Try
            lsSQL = " UPDATE a   SET a.leadername = b.leadername,  a.leaderid = b.leaderid, intime=getdate(), userid ='" & VbCommClass.VbCommClass.UseId & "' " & _
                    " FROM deptlineD_t a  LEFT JOIN M_TTLINE_T b on a.lineid = b.lineid" & _
                    " WHERE 1 = 1 And a.leaderid <> b.leaderid" & _
                    " and a.usey ='Y' "
            DbOperateUtils.ExecSQL(lsSQL)
        Catch ex As Exception
            ' Throw ex
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmLineLeader", "updateMESLineLeaderInfo", "KanBan")
        End Try

    End Sub



End Class