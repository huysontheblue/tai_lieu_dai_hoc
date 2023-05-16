Imports System.Text

Public Class FrmMsgEdit
    Dim DBHelper As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim SaveType As StatusType  '保存狀態
    Dim lastindex As Int16 = -1
    Enum StatusType
        ADD = -1
        EDIT = 0
        DEL = 1
        QUERY = 2
        CANCLE = 3
    End Enum
   
    Private Sub TsbNew_Click(sender As Object, e As EventArgs) Handles TsbNew.Click
        ClearTxt()
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
        SaveType = StatusType.ADD
        BtnAndTxtState(StatusType.ADD)
    End Sub
    Public Sub ClearTxt()
        Me.CmbType.SelectedIndex = -1
        Me.txtTitle.Text = ""
        Me.txtUrl.Text = ""
        Me.txtContent.Text = ""
        Me.CkbUsey.Checked = False
        Me.txtID.Text = "-1"
    End Sub

    Private Sub TsbSave_Click(sender As Object, e As EventArgs) Handles TsbSave.Click
        DBSave()
    End Sub
    Public Sub DBSave()

        Dim ESql As New StringBuilder() 'sql 

        '判斷要保存的數據是否為空
        'If DBSaveJudgeEditIsNull() Then Exit Sub

        '判斷保存時是新增或修改
        If SaveType = StatusType.ADD Then
            Try
                If Me.txtTitle.Text.Trim = "" Then
                    MessageBox.Show("标题不能为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If Me.txtContent.Text.Trim = "" Then
                    MessageBox.Show("内容不能为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                ESql.Append("insert into m_Advert_t(type,title,contents,dtstart,dtend,url,usey) values('")
                ESql.Append(Me.CmbType.Text.Split("-")(0).Trim) '类别
                ESql.Append("',N'")
                ESql.Append(Me.txtTitle.Text.Trim) '密码
                ESql.Append("',N'")
                ESql.Append(Me.txtContent.Text.Trim) '内容
                ESql.Append("','")
                ESql.Append(Me.DtStar.Value.ToString("yyyy-MM-dd HH:mm:ss").Trim) '内容
                ESql.Append("','")
                ESql.Append(Me.DtEnd.Value.ToString("yyyy-MM-dd HH:mm:ss").Trim) '内容
                ESql.Append("','")
                ESql.Append(Me.txtUrl.Text.Trim) '链接
                ESql.Append("','")
                ESql.Append(IIf(Me.CkbUsey.Checked = True, "Y", "N")) '启用否
                ESql.Append("')")
                '執行sql數據保存
                DBHelper.ExecSql(ESql.ToString)

                Call GetInfoHint("數據保存成功！")
                '重新初始化資料
                LoadFrom()
            Catch ex As Exception
                Call GetInfoHint("數據保存失敗！")
            End Try
        ElseIf SaveType = StatusType.EDIT Then
            Try
                If txtID.Text.Trim = "" Or txtID.Text.Trim = "-1" Then
                    MessageBox.Show("请选择一条数据！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If Me.txtTitle.Text.Trim = "" Then
                    MessageBox.Show("标题不能为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If Me.txtContent.Text.Trim = "" Then
                    MessageBox.Show("内容不能为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                ESql.Append("update m_Advert_t set ")
                ESql.Append("type='")
                ESql.Append(Me.CmbType.Text.Split("-")(0).Trim) 'Email地址
                ESql.Append("', title=N'")
                ESql.Append(Me.txtTitle.Text.Trim) '
                ESql.Append("', contents=N'")
                ESql.Append(Me.txtContent.Text.Trim) '
                ESql.Append("', dtstart='")
                ESql.Append(Me.DtStar.Value.ToString("yyyy-MM-dd HH:mm:ss").Trim) '
                ESql.Append("', dtend='")
                ESql.Append(Me.DtEnd.Value.ToString("yyyy-MM-dd HH:mm:ss").Trim) '
                ESql.Append("', url='")
                ESql.Append(Me.txtUrl.Text.Trim) '
                ESql.Append("',Intime = ")
                ESql.Append("getdate()") '輸入時間
                ESql.Append(",Usey='")
                ESql.Append(IIf(Me.CkbUsey.Checked = True, "Y", "N")) '有效否
                ESql.Append("' where id='" & txtID.Text.ToString & "'")
                '執行sql數據保存
                DBHelper.ExecSql(ESql.ToString)

                Call GetInfoHint("數據更新成功！")
                LoadFrom()
            Catch ex As Exception
                Call GetInfoHint("數據更新失敗！")
            End Try
        ElseIf SaveType = StatusType.DEL Then
            Try
                ESql.Append("delete  m_Advert_t  ")
                ESql.Append(" where id='" & txtID.Text.ToString & "'")
                '執行sql數據保存
                DBHelper.ExecSql(ESql.ToString)

                Call GetInfoHint("數據刪除成功！")
                LoadFrom()
            Catch ex As Exception
                Call GetInfoHint("數據刪除失敗！")
            End Try
        End If
    End Sub
    Private Sub LoadFrom()
        GetDataToDgv("select * from m_Advert_t order by id desc")
        '默認用戶別為個人
        CmbType.SelectedIndex = -1
        BtnAndTxtState(StatusType.CANCLE)
    End Sub
    Public Sub GetDataToDgv(ByVal SqlStr As String)
        Dim EData As DataTable
        Try
            Me.DgvShowTb.Rows.Clear()
            EData = DBHelper.GetDataTable(SqlStr)
            If EData.Rows.Count > 0 Then
                For EDInt As Integer = 0 To EData.Rows.Count - 1
                    Me.DgvShowTb.Rows.Add( _
                    EData.Rows(EDInt)("id").ToString.Trim, _
                    EData.Rows(EDInt)("type").ToString.Trim, _
                    EData.Rows(EDInt)("title").ToString.Trim, _
                    EData.Rows(EDInt)("contents").ToString.Trim, _
                    EData.Rows(EDInt)("url").ToString.Trim, _
                    EData.Rows(EDInt)("dtstart").ToString.Trim, _
                    EData.Rows(EDInt)("dtend").ToString.Trim, _
                    EData.Rows(EDInt)("usey").ToString.Trim, _
                    EData.Rows(EDInt)("Intime").ToString.Trim)
                Next
            End If
            'toolStripStatusLabel3.Text = Me.DgvShowTb.Rows.Count
        Catch ex As Exception
            Call GetInfoHint("數據賦值失敗！")
        End Try
    End Sub
    Public Sub BtnAndTxtState(ByVal State As StatusType)
        Select Case State
            Case StatusType.ADD
                Me.TsbNew.Enabled = False
                Me.TsbUpdate.Enabled = False
                Me.TsbSave.Enabled = True
                Me.TsbReturn.Enabled = True
                Me.TsbDelete.Enabled = False
                Me.TsbQuery.Enabled = False
                Me.TsbRefresh.Enabled = False
                TsbPublishCancle.Enabled = False
                TsbPublish.Enabled = False
                TsbView.Enabled = False
                DgvShowTb.Enabled = True
                GroupBox1.Enabled = True
                'Me.CmbType.Enabled = True
                'txtUrl.Enabled = True
                'txtTitle.Enabled = True
                'txtContent.Enabled = True
                '公告详情按钮不可用
                Me.toolAdv.Enabled = False
            Case StatusType.EDIT
                Me.TsbNew.Enabled = False
                Me.TsbUpdate.Enabled = False
                Me.TsbSave.Enabled = True
                Me.TsbReturn.Enabled = True
                Me.TsbDelete.Enabled = True
                Me.TsbQuery.Enabled = False
                Me.TsbRefresh.Enabled = False
                TsbPublishCancle.Enabled = True
                TsbPublish.Enabled = True
                TsbView.Enabled = True
                DgvShowTb.Enabled = False
                GroupBox1.Enabled = True

                'Me.CmbType.Enabled = True
                'txtUrl.Enabled = True
                'txtTitle.Enabled = True
                'txtContent.Enabled = True

                '公告详情按钮不可用
                Me.toolAdv.Enabled = False
            Case StatusType.CANCLE
                Me.TsbNew.Enabled = True
                Me.TsbUpdate.Enabled = True
                Me.TsbSave.Enabled = False
                Me.TsbReturn.Enabled = False
                Me.TsbDelete.Enabled = False
                Me.TsbQuery.Enabled = True
                Me.TsbRefresh.Enabled = False
                TsbPublishCancle.Enabled = False
                TsbPublish.Enabled = False
                TsbView.Enabled = False
                DgvShowTb.Enabled = True

                GroupBox1.Enabled = False
                'Me.CmbType.Enabled = False
                'txtUrl.Enabled = False
                'txtTitle.Enabled = False
                'txtContent.Enabled = False

                '公告详情按钮可用
                Me.toolAdv.Enabled = True
            Case StatusType.QUERY
                Me.TsbNew.Enabled = False
                Me.TsbUpdate.Enabled = False
                Me.TsbSave.Enabled = False
                Me.TsbReturn.Enabled = True
                Me.TsbDelete.Enabled = False
                Me.TsbQuery.Enabled = False
                Me.TsbRefresh.Enabled = True
                TsbPublishCancle.Enabled = False
                TsbPublish.Enabled = False
                TsbView.Enabled = False
                DgvShowTb.Enabled = True
                GroupBox1.Enabled = True
                'Me.CmbType.Enabled = False
                'txtUrl.Enabled = False
                'txtTitle.Enabled = False
                'txtContent.Enabled = False

                '公告详情按钮可用
                Me.toolAdv.Enabled = False
            Case StatusType.DEL
                Me.TsbNew.Enabled = True
                Me.TsbUpdate.Enabled = True
                Me.TsbSave.Enabled = False
                Me.TsbReturn.Enabled = False
                Me.TsbDelete.Enabled = False
                Me.TsbQuery.Enabled = True
                Me.TsbRefresh.Enabled = False
                TsbPublishCancle.Enabled = False
                TsbPublish.Enabled = False
                TsbView.Enabled = False
                DgvShowTb.Enabled = True
                Me.CmbType.Enabled = False
                txtUrl.Enabled = False
                txtTitle.Enabled = False
                txtContent.Enabled = False
        End Select
        CkbUsey.Enabled = False
    End Sub
#Region "信息提示框"
    Public Sub GetInfoHint(ByVal ErrorStr As String)
        MessageBox.Show(ErrorStr, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Public Function GetYesOrNo(ByVal YoNStr As String) As Boolean
        If MessageBox.Show(YoNStr, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Return True
        End If
        Return False
    End Function
#End Region

    Private Sub TsbUpdate_Click(sender As Object, e As EventArgs) Handles TsbUpdate.Click
        SaveType = StatusType.EDIT
        BtnAndTxtState(SaveType)
        txtID.Text = DgvShowTb.Item("id", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
        txtTitle.Text = DgvShowTb.Item("title", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
        txtContent.Text = DgvShowTb.Item("contents", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
        txtUrl.Text = DgvShowTb.Item("url", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
        Dim type As String = DgvShowTb.Item("type", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
        If (type = "0") Then
            CmbType.SelectedIndex = 0
        Else
            CmbType.SelectedIndex = 1
        End If
        Dim usey As String = DgvShowTb.Item("Usey", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim.ToString
        If usey = "Y" Then
            CkbUsey.Checked = True
        Else
            CkbUsey.Checked = False
        End If
        If lastindex <> -1 Then
            DgvShowTb.Rows(lastindex).DefaultCellStyle.BackColor = Color.White
        End If
        DtStar.Value = DgvShowTb.Item("dtstart", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
        DtEnd.Value = DgvShowTb.Item("dtends", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
        DgvShowTb.Rows(DgvShowTb.CurrentRow.Index).DefaultCellStyle.BackColor = Color.PaleGreen
        lastindex = DgvShowTb.CurrentRow.Index

        'If txtID.Text <> "" And txtID.Text <> "-1" Then
        '    SaveType = StatusType.EDIT
        '    BtnAndTxtState(SaveType)

        'Else
        '    GetInfoHint("請選擇一條數據")
        '    Exit Sub
        'End If

    End Sub

    Private Sub FrmMsgEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFrom()
    End Sub

    Private Sub TsbReturn_Click(sender As Object, e As EventArgs) Handles TsbReturn.Click
        SaveType = StatusType.CANCLE
        BtnAndTxtState(SaveType)
        If lastindex <> -1 Then
            DgvShowTb.Rows(lastindex).DefaultCellStyle.BackColor = Color.White
        End If
    End Sub

    Private Sub TsbDelete_Click(sender As Object, e As EventArgs) Handles TsbDelete.Click
        SaveType = StatusType.DEL
        DBSave()
        ClearTxt()
        BtnAndTxtState(StatusType.DEL)

    End Sub

    Private Sub TsbRefresh_Click(sender As Object, e As EventArgs) Handles TsbRefresh.Click
        Try
            Dim sql As String = "select * from m_Advert_t where (1=1)"
            If txtTitle.Text <> "" Then
                sql = sql + String.Format(" and title like '%{0}%'", txtTitle.Text.Trim)
            End If
            If CmbType.SelectedIndex >= 0 Then
                sql = sql + String.Format(" and type='{0}'", Me.CmbType.Text.Split("-")(0).Trim)
            End If
            sql = sql + " order by id desc"
            GetDataToDgv(sql)
            lastindex = -1
        Catch ex As Exception
            Call GetInfoHint("數據刷新失敗！")
        End Try

        TsbRefresh.Enabled = False
    End Sub

    Private Sub TsbQuery_Click(sender As Object, e As EventArgs) Handles TsbQuery.Click
        ClearTxt()
        BtnAndTxtState(StatusType.QUERY)
        TsbRefresh.Enabled = True
    End Sub

    Private Sub TsbView_Click(sender As Object, e As EventArgs) Handles TsbView.Click

        OpenWin(txtID.Text.Trim)
    End Sub
    Private Sub OpenWin(ByVal aid As String)

        Dim frmShowWarning As SysBasicClass.FormMessageBox = New SysBasicClass.FormMessageBox(aid)
        Dim p As Point = New Point(Screen.PrimaryScreen.WorkingArea.Width - frmShowWarning.Width, Screen.PrimaryScreen.WorkingArea.Height)
        frmShowWarning.PointToScreen(p)
        frmShowWarning.Location = p
        frmShowWarning.Show()
        Dim i As Integer = 0
        For i = 0 To frmShowWarning.Height - 1
            frmShowWarning.Location = New Point(p.X, p.Y - i)
            Threading.Thread.Sleep(10)
        Next
    End Sub

    Private Sub DgvShowTb_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvShowTb.CellClick
        If e.RowIndex = -1 Then Exit Sub
        With DgvShowTb.Rows(e.RowIndex)
            txtID.Text = DgvShowTb.Item("id", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
            txtTitle.Text = DgvShowTb.Item("title", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
            txtContent.Text = DgvShowTb.Item("contents", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
            txtUrl.Text = DgvShowTb.Item("url", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
            Dim type As String = DgvShowTb.Item("type", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
            If (type = "0") Then
                CmbType.SelectedIndex = 0
            Else
                CmbType.SelectedIndex = 1
            End If
            Dim usey As String = DgvShowTb.Item("Usey", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim.ToString
            If usey = "Y" Then
                CkbUsey.Checked = True
            Else
                CkbUsey.Checked = False
            End If
            DtStar.Value = DgvShowTb.Item("dtstart", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
            DtEnd.Value = DgvShowTb.Item("dtends", Me.DgvShowTb.CurrentRow.Index).Value.ToString.Trim
            If lastindex <> -1 Then
                DgvShowTb.Rows(lastindex).DefaultCellStyle.BackColor = Color.White
            End If
            DgvShowTb.Rows(DgvShowTb.CurrentRow.Index).DefaultCellStyle.BackColor = Color.PaleGreen
            lastindex = DgvShowTb.CurrentRow.Index
        End With
    End Sub

    Private Sub TsbPublish_Click(sender As Object, e As EventArgs) Handles TsbPublish.Click
        Try

            Dim sqlstr As String = "update m_Advert_t set usey='N' where usey='Y' "
            sqlstr = sqlstr & vbNewLine & String.Format("update m_Advert_t set usey='Y' where id='{0}' ", txtID.Text.Trim)
            sqlstr = sqlstr & vbNewLine & "update m_users_t set ShowAdv=1,Advid=null,Advtime=null "

            DBHelper.ExecSql(sqlstr)
            DBHelper.PubConnection.Close()
            Call GetInfoHint("发布成功！")
            LoadFrom()
            'OpenWin("-1")
            BtnAndTxtState(StatusType.CANCLE)
        Catch ex As Exception
            Call GetInfoHint("发布失败！")
        End Try
    End Sub

    Private Sub TsbClose_Click(sender As Object, e As EventArgs) Handles TsbClose.Click
        Me.Close()
    End Sub

    Private Sub TsbPublishCancle_Click(sender As Object, e As EventArgs) Handles TsbPublishCancle.Click
        Try

            Dim sqlstr As String = ""
            sqlstr = sqlstr & vbNewLine & String.Format("update m_Advert_t set usey='N' where id='{0}' ", txtID.Text.Trim)
            sqlstr = sqlstr & vbNewLine & "update m_users_t set ShowAdv=0 "

            DBHelper.ExecSql(sqlstr)
            DBHelper.PubConnection.Close()
            Call GetInfoHint("取消成功！")
            LoadFrom()
            'OpenWin("-1")
            BtnAndTxtState(StatusType.CANCLE)
        Catch ex As Exception
            Call GetInfoHint("取消失败！")
        End Try
    End Sub

    '公告详情
    Private Sub toolAdv_Click(sender As Object, e As EventArgs) Handles toolAdv.Click
        If Me.DgvShowTb.RowCount <= 0 Or txtID.Text.Trim.Trim.ToString = "" Or txtID.Text.Trim.Trim.ToString = "-1" Then
            MessageBox.Show("请先选择一行要编辑的公告信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim frmAdv As FrmMsgEditAdv = New FrmMsgEditAdv
        frmAdv.advMessage = "标题：" + Me.txtTitle.Text.Trim.ToString() + vbCrLf + "内容：" + Me.txtContent.Text.Trim.ToString
        frmAdv.advId = Me.txtID.Text.Trim.ToString
        frmAdv.ShowDialog()
    End Sub
End Class