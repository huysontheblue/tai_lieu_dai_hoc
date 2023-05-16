Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports System.Text

Public Class FrmLeanProCDInfo

    Public lineId As String
    Public opflag As Int16 = 0 '判断是新增还是修改

    Private Sub FrmLeanProCDInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataToCombox()
        LoadDataToDatagridView("  ")

        txtlineId.Text = lineId
        txtlineId.Enabled = False
        ToolbtnState(opflag)
    End Sub
    '填充工序类型复选框
    Private Sub LoadDataToCombox()
        Dim sqlStr As String = "select LeanType,LeanTypeName  from m_LeanType_t where Usey ='Y' order by LeanType "
        Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dReader As SqlDataReader = conn.GetDataReader(sqlStr)
        If dReader.HasRows Then
            Do While dReader.Read
                cboLeanType.Items.Add(dReader.Item(0) & "-" & dReader.Item(1))
            Loop
        Else
            cboLeanType.Items.Clear()
        End If
        dReader.Close()
        If (conn.PubConnection.State = ConnectionState.Open) Then
            conn.PubConnection.Close()
        End If
    End Sub
    '加载产线精益生产项目类别值
    Private Sub LoadDataToDatagridView(ByVal sqlWhere As String)
        Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dReader As SqlDataReader
        Dim sqlStr As String

        dgvLeanTypeVal.Rows.Clear()
        sqlStr = "select a.LineId ,a.LeanType ,b.LeanTypeName  ,a.LeanValue ,a.UpdateUserId ,a.UpdateTime " _
                    & " from m_LeanLineTypeVals_t a left join m_LeanType_t b on a.LeanType =b.LeanType  where LineId='" & lineId & "'  "
        dReader = conn.GetDataReader(sqlStr & sqlWhere & " order by a.LeanType")
        Do While dReader.Read()
            dgvLeanTypeVal.Rows.Add(dReader.Item(0).ToString, dReader.Item(1).ToString & "-" & dReader.Item(2).ToString(), _
                                    dReader.Item(3).ToString, dReader.Item(4).ToString, dReader.Item(5).ToString)
        Loop
        dReader.Close()
        conn = Nothing
    End Sub

    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
    '设置按钮及TextBox状态
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0  '初始查询状态
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolDelete.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True

                Me.cboLeanType.SelectedIndex = -1
            Case 1, 2 '新增 修改
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolDelete.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False

                Me.cboLeanType.Enabled = True
        End Select
    End Sub
    '新增
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Me.cboLeanType.Text = ""
        Me.txtLeanValue.Text = ""
        opflag = 1
        ToolbtnState(opflag)
    End Sub
    '修改
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        '判断记录是否可以被修改
        If Me.dgvLeanTypeVal.Rows.Count = 0 OrElse Me.dgvLeanTypeVal.CurrentRow Is Nothing Then Exit Sub
        '控件赋值
        Me.cboLeanType.SelectedIndex = Me.cboLeanType.FindString(Me.dgvLeanTypeVal.Item(1, Me.dgvLeanTypeVal.CurrentRow.Index).Value.ToString.Trim)
        Me.txtLeanValue.Text = dgvLeanTypeVal.Item(2, Me.dgvLeanTypeVal.CurrentRow.Index).Value.ToString.Trim

        '改变窗体状态
        opflag = 2
        ToolbtnState(2)
        Me.cboLeanType.Enabled = False
    End Sub
    '删除
    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
        '判断记录是否可以被删除
        If Me.dgvLeanTypeVal.Rows.Count = 0 OrElse Me.dgvLeanTypeVal.CurrentRow Is Nothing Then Exit Sub
        Dim leanTypeName As String = Me.dgvLeanTypeVal.Item(1, Me.dgvLeanTypeVal.CurrentRow.Index).Value.ToString.Trim
        Dim leanType As String = leanTypeName.Split("-")(0)
        Dim lined As String = Me.dgvLeanTypeVal.Item(0, Me.dgvLeanTypeVal.CurrentRow.Index).Value.ToString.Trim
        If MessageBox.Show("确定要删除工序：[" + leanTypeName + "]吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            conn.ExecSql("delete from m_LeanLineTypeVals_t  where LineId=N'" & lined & "' and LeanType =N'" & leanType & "'")
            MessageBox.Show("成功删除工序:[" + leanTypeName + "]", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataToDatagridView(" ")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "ProductionPlan.FrmLeanProCDInfo", "toolDelete_Click", "sys")
        End Try

    End Sub
    '返回
    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        cboLeanType.Text = ""
        txtLeanValue.Text = ""

        opflag = 0
        ToolbtnState(0)
        Me.cboLeanType.Enabled = True
    End Sub
    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim sqlStr As String

        If Checkdata() = False Then Exit Sub

        If opflag = 1 Then '新增后执行插入操作
            Dim mcheck As SqlDataReader = conn.GetDataReader("select  LineId,LeanType  from m_LeanLineTypeVals_t  where LineId=N'" & lineId & "' and LeanType =N'" & cboLeanType.Text.Trim.Split("-")(0) & "'")
            If mcheck.HasRows Then
                mcheck.Close()
                MessageBox.Show("该线别下的工序类型已存在！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            mcheck.Close()
            sqlStr = "insert into m_LeanLineTypeVals_t(LineId ,LeanType ,LeanValue ,UpdateUserId ,UpdateTime )" _
                       & " values(N'" & lineId & "',N'" & Me.cboLeanType.Text.Trim.Split("-")(0) & "',N'" & Me.txtLeanValue.Text.Trim & "',N'" & SysMessageClass.UseId.ToUpper.Trim & "',GETDATE ())"

        ElseIf opflag = 2 Then   '修改后保存执行更新操作
            sqlStr = "update  m_LeanLineTypeVals_t set " _
            & " LeanValue = N'" & Me.txtLeanValue.Text.Trim & "',UpdateUserId =N'" & SysMessageClass.UseId.ToUpper.Trim & "',UpdateTime=GETDATE () " _
            & " where lineId = N'" & lineId & "' and LeanType=N'" & Me.cboLeanType.Text.Trim.Split("-")(0) & "'"
        End If

        Try
            conn.ExecSql(sqlStr.ToString)
            LoadDataToDatagridView(" ")
            MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtLeanValue.Text = ""
            Me.cboLeanType.Text = ""
            Me.cboLeanType.Enabled = True
            opflag = 0
            ToolbtnState(opflag)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "ProductionPlan.FrmLeanProCDInfo", "toolDelete_Click", "sys")
        End Try
    End Sub
    '保存时检查文本框是否为空
    Private Function Checkdata() As Boolean
        If Me.cboLeanType.Text.Trim = "" Then
            MessageBox.Show("请选择工序类型!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.cboLeanType
            Return False
        End If

        Dim index As Integer
        index = Me.cboLeanType.FindString(Me.cboLeanType.Text)
        If index <= -1 Then
            MessageBox.Show("请从下拉列表中选择工序类型！")
            Return False
        End If

        If Me.txtLeanValue.Text.Trim = "" Then
            MessageBox.Show("实测工时不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtLeanValue.Focus()
            Return False
        End If

        If IsNumeric(Me.txtLeanValue.Text.Trim) = False Then
            MessageBox.Show("实测工时应为数值类型！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtLeanValue.Focus()
            Return False
        End If
        Return True
    End Function
    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim sql As String = ""
        If cboLeanType.Text.Trim <> "" Then
            sql = sql & " and a.LeanType=N'" & cboLeanType.Text.Trim.Split("-")(0) & "' "
        End If
        If txtLeanValue.Text.Trim <> "" Then
            sql = sql & " and a.LeanValue like N'%" & Me.txtLeanValue.Text.Trim & "%' "
        End If
        LoadDataToDatagridView(sql)
    End Sub
End Class