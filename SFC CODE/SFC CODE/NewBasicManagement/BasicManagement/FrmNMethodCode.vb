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

Public Class FrmNMethodCode

#Region "定义"
    Public opflag As Int16 = 0
    Dim lastindex As Int16 = -1

    Private Enum CDImportGrid
        MstyleId
        MstyleName
        MstyleEName
        StyleSort
    End Enum
#End Region


#Region "KEYDOWN"

    Private Sub FrmRstationSet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LoadDataToCombox()
        BMComDB.BindComboxNGCode(ComCode)
        LoadDataToDatagridview("")
        Erightbutton()
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
                'Me.cboType.Enabled = IIf(opflag = 1, True, False)
                Me.txtStationid.Enabled = True
                Me.dgvRstation.Enabled = False
                dgvRstation.ReadOnly = True
                'Me.ActiveControl = IIf(opflag = 1, Me.cboType, Me.txtStationName)
            Case 3 '
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = True
                'GroupBox
                'Me.cboType.Enabled = True
                Me.txtStationdest.Enabled = False
                Me.txtStationid.Enabled = True
                Me.txtStationName.Enabled = True
                Me.dgvRstation.Enabled = True
                Me.ActiveControl = Me.txtStationid
        End Select
    End Sub

#End Region


#Region "事件处理 "
    '新增
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click
        txtStationName.Text = ""
        txtStationdest.Text = ""
        txtStationid.Text = ""
        opflag = 1
        ToolbtnState(1)
    End Sub

    '编辑
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub

        txtStationid.Text = dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtStationName.Text = dgvRstation.Item(1, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        txtStationdest.Text = dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        Dim rcos As String = dgvRstation.Item(3, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        ComCode.SelectedValue = rcos
        '
        opflag = 2
        If lastindex <> -1 Then
            dgvRstation.Rows(lastindex).DefaultCellStyle.BackColor = Color.White
        End If
        dgvRstation.Rows(dgvRstation.CurrentRow.Index).DefaultCellStyle.BackColor = Color.PaleGreen
        lastindex = dgvRstation.CurrentRow.Index

        ToolbtnState(2)
        Me.txtStationid.Enabled = False
    End Sub

    '废除
    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        Try
            DbOperateUtils.ExecSQL("update m_MainTainStyle_t set usey='N',intime=getdate() where MstyleId = '" & Me.dgvRstation.Item(0, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim & "'")
            LoadDataToDatagridview(GetSqlWhere())
            MessageUtils.ShowInformation("作废成功！")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
            MessageUtils.ShowError("作废失败！")
        End Try
    End Sub

    '保存
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        Dim SqlStr As New StringBuilder
        If ComCode.Text = "" Then
            MessageBox.Show("请选择不良现象")
            Exit Sub
        End If
        Dim rEsortName As String = ComCode.Text.Split("-")(1).ToString
        'Dim cbType As String = cboType.Text.Split("-")(0).ToString
        If Checkdata() = False Then Exit Sub
        If opflag = 0 Then
            MessageBox.Show("保存前需要点击新建或修改")
            Exit Sub
        End If
        If opflag = 1 Then      '新增
            SqlStr.Append(ControlChars.CrLf & "insert m_MainTainStyle_t(MstyleId,MstyleName,MstyleEName,StyleSort,usey,userid,intime) " _
                     & " values('" & txtStationid.Text & "',N'" & txtStationName.Text.Trim & "'," _
                     & " N'" & txtStationdest.Text.Trim & "','" & rEsortName & "','Y','" & SysMessageClass.UseId & "',getdate())")
        ElseIf opflag = 2 Then  '编辑
            SqlStr.Append("update m_MainTainStyle_t set MstyleName =N'" & txtStationName.Text.Trim & "',MstyleEName =N'" & txtStationdest.Text.Trim & "',StyleSort='" & rEsortName & "',intime=getdate(),userid='" & SysMessageClass.UseId & "' where MstyleId = '" & txtStationid.Text.Trim & "' ")
        End If
        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadDataToDatagridview(GetSqlWhere())

            txtStationid.Text = ""
            txtStationName.Text = ""
            txtStationdest.Text = ""
            opflag = 0
            ToolbtnState(0)
            lastindex = -1
            MessageUtils.ShowInformation("保存成功！")
        Catch ex As Exception
            MessageUtils.ShowInformation("保存失败！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbSave_Click", "sys")
        End Try
    End Sub

    '返回
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
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

    '不良现象代码
    Private Sub ComCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComCode.SelectedIndexChanged
        '新增状态时
        If opflag = 1 Then
            If String.IsNullOrEmpty(ComCode.SelectedValue.ToString) = False Then
                txtStationid.Text = BMComDB.GetMAXMainTainStyleId(ComCode.SelectedValue.ToString)
            End If
        End If
    End Sub

#End Region


#Region "方法"

    '查询条件
    Private Function GetSqlWhere() As String
        Dim Sql As String = ""
        If Me.txtStationid.Text.Trim <> "" Then
            Sql = Sql & " and MstyleId like '%" & Me.txtStationid.Text.Trim & "%' "
        End If
        If Me.txtStationName.Text.Trim <> "" Then
            Sql = Sql & " and MstyleName like N'%" & Me.txtStationName.Text.Trim & "%' "
        End If
        Return Sql
    End Function

    '初期化GRIDVIEW
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim SqlStr As String = ""

        SqlStr = " select MstyleId,MstyleName,MstyleEName,StyleSort, case a.usey when 'Y' then N'Y-有效' when 'N' then N'N-作废' end as Usey," &
                 " userid,convert(varchar(19),a.intime,21) as intime  " &
                 " from m_MainTainStyle_t a where 1=1 " & SqlWhere
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)

        dgvRstation.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            dgvRstation.Rows.Add(dt.Rows(i).Item(0).ToString, dt.Rows(i).Item(1).ToString, dt.Rows(i).Item(2).ToString,
            dt.Rows(i).Item(3).ToString, dt.Rows(i).Item(4).ToString, dt.Rows(i).Item(5).ToString, dt.Rows(i).Item(6).ToString)
        Next

        toolStripStatusLabel3.Text = Me.dgvRstation.Rows.Count
    End Sub

    '检查数据
    Private Function Checkdata() As Boolean
        If Me.ComCode.Text.Trim = "" Then
            MessageUtils.ShowError("不良现象不能为空!")
            Me.ActiveControl = Me.ComCode
            Return False
        End If

        If Me.txtStationid.Text.Trim = "" Then
            MessageUtils.ShowError("维修代码不能为空!")
            Me.ActiveControl = Me.txtStationid
            Return False
        End If
        If Me.txtStationName.Text.Trim = "" Then
            MessageUtils.ShowError("维修名称不能为空!")
            Me.ActiveControl = Me.txtStationName
            Return False
        End If
        If opflag = 1 Then
            Dim dt As DataTable = DbOperateUtils.GetDataTable("select 1 from m_MainTainStyle_t where MstyleId='" & txtStationid.Text & "'")
            If dt.Rows.Count > 0 Then
                MessageUtils.ShowError("已经存在该不良维修代码!")
                Me.ActiveControl = Me.txtStationid
                Return False
            End If
        End If

        Return True
    End Function

#End Region


End Class