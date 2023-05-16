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
Imports MainFrame

#End Region

Public Class FrmNcauseCode

#Region "定义"

    Public opflag As Int16 = 0
    Dim lastindex As Int16 = -1

    Private Enum CDImportGrid
        rCodeID
        rCCName
        rCEName
        rCsortName
        rEsortName
    End Enum
#End Region


#Region "KEYDOWN"

    Private Sub FrmNcauseCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                SendKeys.Send("{+Tab}")
            Case 13
                SendKeys.Send("{Tab}")
            Case 27
                Me.Close()
        End Select
    End Sub

    '初期化
    Private Sub FrmNcauseCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BMComDB.BindComboxNGCategory(cboType)
        LoadDataToDatagridview("")
        Erightbutton()
        ToolbtnState(opflag)
    End Sub

    '不同状态处理
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '初期化
                Me.toolAdd.Enabled = IIf(Me.toolAdd.Tag.ToString <> "Yes", False, True)
                Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                Me.toolAbandon.Enabled = IIf(Me.toolAbandon.Tag.ToString <> "Yes", False, True)
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = False
                'GroupBox
                Me.cboType.Enabled = True
                Me.txtStationdest.Enabled = False
                Me.txtStationid.Enabled = True
                Me.txtStationName.Enabled = True
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
                Me.txtStationdest.Enabled = True
                Me.txtStationName.Enabled = True
                Me.cboType.Enabled = IIf(opflag = 1, True, False)
                Me.txtStationid.Enabled = True
                Me.dgvRstation.Enabled = False
                dgvRstation.ReadOnly = True
                Me.ActiveControl = IIf(opflag = 1, Me.cboType, Me.txtStationName)
            Case 3 '
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = True
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


#Region "事件处理"

    '新增处理
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click

        txtStationName.Text = ""
        txtStationdest.Text = ""
        txtStationid.Text = ""
        opflag = 1
        ToolbtnState(1)
        ComCode_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    '编辑处理
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click

        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub

        If dgvRstation.Item(6, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim <> "" Then
            Dim bigCode As String = dgvRstation.Item(6, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim.Substring(0, 2)
            cboType.SelectedValue = bigCode
        End If

        Dim rcos As String = dgvRstation.Item(6, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        ComCode.SelectedValue = rcos
        opflag = 2
        If lastindex <> -1 Then
            dgvRstation.Rows(lastindex).DefaultCellStyle.BackColor = Color.White
        End If
        dgvRstation.Rows(dgvRstation.CurrentRow.Index).DefaultCellStyle.BackColor = Color.PaleGreen
        lastindex = dgvRstation.CurrentRow.Index

        txtStationid.Text = dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtStationName.Text = dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtStationdest.Text = dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim

        ToolbtnState(2)
        Me.txtStationid.Enabled = False
        cboType.Enabled = True

    End Sub

    '作废处理
    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click

        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        Try
            DbOperateUtils.ExecSQL("update m_Coder_t set usey='N',intime=getdate() where rCodeID = '" & Me.dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
            LoadDataToDatagridview(GetSqlWhere())
            MessageUtils.ShowInformation("作废成功！")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmNcauseCode", "tsbAbandon_Click", "sys")
            MessageUtils.ShowError("作废失败！")
        End Try

    End Sub

    '保存
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click

        Dim Rtable As New DataTable
        Dim SqlStr As New StringBuilder
        If ComCode.Text = "" Then
            MessageUtils.ShowError("请选择不良现象!")
            Exit Sub
        End If
        Dim rEsortName As String = ComCode.Text.Split("-")(1).ToString
        Dim cbType As String = ""
        If cboType.Text.Split("-").Length > 1 Then
            cbType = cboType.Text.Split("-")(1).ToString
        Else
            cbType = cboType.Text
        End If

        If Checkdata() = False Then Exit Sub
        If opflag = 1 Then  '
            SqlStr.Append(ControlChars.CrLf & "insert m_Coder_t(rCodeID, rCCName, rCsortName, rCEName,rEsortName, rduty, usey, intime,userid) " _
                     & " values('" & txtStationid.Text & "',N'" & txtStationName.Text.Trim & "',N'" & cbType & "'," _
                     & " N'" & txtStationdest.Text.Trim & "','" & rEsortName & "',N'制造','Y',getdate(),'" & SysMessageClass.UseId & "')")
        ElseIf opflag = 2 Then
            SqlStr.Append("update m_Coder_t set rCCName =N'" & txtStationName.Text.Trim & "',rCsortName=N'" & cbType & "',rCEName =N'" & txtStationdest.Text.Trim &
                          "',rEsortName='" & rEsortName & "',intime=getdate(),userid='" & SysMessageClass.UseId & "' where rCodeID = '" & txtStationid.Text.Trim & "' ")
        End If
        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadDataToDatagridview(GetSqlWhere())

            cboType.SelectedIndex = -1
            txtStationid.Text = ""
            txtStationName.Text = ""
            txtStationdest.Text = ""
            opflag = 0
            ToolbtnState(0)
            lastindex = -1
            MessageUtils.ShowInformation("保存成功！")
        Catch ex As Exception
            MessageUtils.ShowInformation("保存失败！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmNcauseCode", "tsbSave_Click", "sys")
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
        If lastindex <> -1 Then
            dgvRstation.Rows(lastindex).DefaultCellStyle.BackColor = Color.White
        End If
    End Sub

    '查询
    Private Sub tsbQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        LoadDataToDatagridview(GetSqlWhere())
    End Sub

    '退出
    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        If cboType.SelectedValue Is Nothing Then Exit Sub
        txtStationid.Text = ""
        BMComDB.BindComboxNGCode(ComCode, cboType.SelectedValue.ToString)
    End Sub

    Private Sub ComCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComCode.SelectedIndexChanged
        '新增状态时
        If opflag = 1 Then
            If ComCode.SelectedValue Is Nothing Then Exit Sub
            If String.IsNullOrEmpty(ComCode.SelectedValue.ToString) = False Then
                txtStationid.Text = BMComDB.GetMAXRCodeid(ComCode.SelectedValue.ToString)
            End If
        End If
    End Sub

#End Region


#Region "方法"

    '按钮权限
    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02003' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        Dim Obj As Object
        While Reader.Read
            Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
            Obj.Tag = "Yes"
        End While
        Reader.Close()
        Conn.PubConnection.Close()
    End Sub

 
    '查询条件
    Private Function GetSqlWhere() As String
        Dim Sql As String = ""

        If Me.cboType.Text.Trim <> "" Then
            If cboType.Text.Split("-").Length > 1 Then
                Sql = Sql & " and rCsortName=N'" & Me.cboType.Text.Trim.Split("-")(1) & "' "
            Else
                Sql = Sql & " and rCsortName=N'" & Me.cboType.Text.Trim & "' "
            End If
        End If
        If Me.txtStationid.Text.Trim <> "" Then
            Sql = Sql & " and rCodeID like '%" & Me.txtStationid.Text.Trim & "%' "
        End If
        If Me.txtStationName.Text.Trim <> "" Then
            Sql = Sql & " and rCCName like N'%" & Me.txtStationName.Text.Trim & "%' "
        End If

        Return Sql
    End Function

    '初期化GRIDVIEW
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader
        Dim SqlStr As String = ""

        dgvRstation.Rows.Clear()
        SqlStr = "select rCodeID,rCCName,rCEName,rCsortName, " _
              & " case a.usey when 'Y' then N'Y-有效' when 'N' then N'N-作废' end as Usey,convert(varchar(19),a.intime,21) as intime,rEsortName  " _
              & " from m_Coder_t a where 1= 1 " & SqlWhere
        Dreader = Conn.GetDataReader(SqlStr)
        Do While Dreader.Read()
            dgvRstation.Rows.Add(Dreader.Item(0).ToString, Dreader.Item(1).ToString, Dreader.Item(2).ToString, _
            Dreader.Item(3).ToString, Dreader.Item(4).ToString, Dreader.Item(5).ToString, Dreader.Item(6).ToString)
        Loop
        Dreader.Close()
        toolStripStatusLabel3.Text = Me.dgvRstation.Rows.Count
        Conn.PubConnection.Close()
        Conn = Nothing
        lastindex = -1
    End Sub

    '检查数据
    Private Function Checkdata() As Boolean

        If Me.cboType.Text.Trim = "" Then
            MessageUtils.ShowError("不良原因类别不能为空!")
            Me.ActiveControl = Me.cboType
            Return False
        End If

        If Me.txtStationid.Text.Trim = "" Then
            MessageUtils.ShowError("不良原因代码不能为空!")
            Me.ActiveControl = Me.txtStationid
            Return False
        End If
        If Me.txtStationName.Text.Trim = "" Then
            MessageUtils.ShowError("不良原因名称不能为空!")
            Me.ActiveControl = Me.txtStationName
            Return False
        End If
        If opflag = 1 Then
            Dim dt As DataTable = DbOperateUtils.GetDataTable("select rCodeID from m_Coder_t where rCodeID='" & txtStationid.Text & "'")
            If dt.Rows.Count > 0 Then
                MessageUtils.ShowError("已经存在该不良原因代码!")
                Me.ActiveControl = Me.cboType
                Return False
            End If
        End If

        Return True
    End Function

#End Region

End Class