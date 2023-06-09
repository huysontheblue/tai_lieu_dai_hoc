Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class FrmEmailUpdate
    Dim DBHelper As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim SaveType As String  '保存狀態


#Region "給DgvShowEmail賦值"
    Public Sub GetDataToDgv(ByVal SqlStr As String)
        Dim EData As DataTable
        Try
            Me.DgvShowEmail.Rows.Clear()
            EData = DBHelper.GetDataTable(SqlStr)
            If EData.Rows.Count > 0 Then
                For EDInt As Integer = 0 To EData.Rows.Count - 1
                    Me.DgvShowEmail.Rows.Add(EData.Rows(EDInt)("AutoID").ToString.Trim, EData.Rows(EDInt)("FrmName").ToString.Trim, _
                    EData.Rows(EDInt)("Userid").ToString.Trim, EData.Rows(EDInt)("MailAddr").ToString.Trim, _
                    EData.Rows(EDInt)("InputUser").ToString.Trim, EData.Rows(EDInt)("InputDate").ToString.Trim, _
                    EData.Rows(EDInt)("usey").ToString.Trim)
                Next
            End If
        Catch ex As Exception
            Call GetInfoHint("數據賦值失敗！")
        End Try
    End Sub
#End Region

#Region "重繪datagridview單元格,選中時去除焦點"
    Private Sub DgvShowEmail_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgvShowEmail.RowPrePaint
        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts
    End Sub
#End Region

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

#Region "工具條事件"
    '新增
    Private Sub TsbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbNew.Click
        '清空Txt
        ClearTxt()
        '清空顯示表格
        'Me.DgvShowEmail.Rows.Clear()

        '給保存狀態賦值為增加
        SaveType = "INSERT"
        '改變按鈕狀態
        BtnAndTxtState("INSERT")
    End Sub
    '修改
    Private Sub TsbUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbUpdate.Click
        '給保存狀態賦值為增加
        SaveType = "UPDATE"
        '改變按鈕狀態
        BtnAndTxtState("UPDATE")
    End Sub
    '刷新
    Private Sub TsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbRefresh.Click
        Dim RSql As New StringBuilder() '刷新SQL
        Try
            RSql.Append("select AutoID,FrmName,isnull(Userid,'') as Userid,MailAddr,InputUser,InputDate,usey from M_UserMail_t where ")
            RSql.Append(" usey='")
            RSql.Append(IIf(Me.CkbYesOrNo.Checked = True, "Y", "N")) '系統別
            RSql.Append("'")
            If Me.CmbSystemType.Text.Trim <> "" Then '判斷查詢條件是否有系統別
                RSql.Append(" and FrmName='")
                RSql.Append(Me.CmbSystemType.Text.Trim) '系統別
                RSql.Append("'")
            End If
            If Me.TxtJobNO.Enabled = False Then '判斷查詢條件是否有工號
                RSql.Append(" and isnull(Userid,'') = ''") '工號
            ElseIf Me.TxtJobNO.Text <> "" Then
                RSql.Append(" and isnull(Userid,'') = '")
                RSql.Append(Me.TxtJobNO.Text.Trim) '工號
                RSql.Append("'")
            End If
            If Me.TxtEmail.Text.Trim <> "" Then '判斷查詢條件是否有Email地址
                RSql.Append(" and MailAddr = '")
                RSql.Append(Me.TxtEmail.Text.Trim) 'Email
                RSql.Append("'")
            End If
            '根據查詢條件查詢數據
            Call GetDataToDgv(RSql.ToString)

        Catch ex As Exception
            Call GetInfoHint("數據刷新失敗！")
        End Try
        TsbRefresh.Enabled = False
    End Sub
    '查詢
    Private Sub TsbQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbQuery.Click
        '清空Txt
        ClearTxt()
        BtnAndTxtState("SELECT")
        TsbRefresh.Enabled = True
    End Sub
    '返回
    Private Sub TsbReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbReturn.Click
        '重新加載窗體
        Call FrmEmailUpdate_Load(sender, e)
    End Sub
    '退出
    Private Sub TsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbClose.Click
        '關閉窗體
        Me.Close()
    End Sub
    '儲存
    Private Sub TsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbSave.Click
        '數據儲存

        Call DBSave()
    End Sub
    '刪除
    Private Sub TsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbDelete.Click
        Dim RSql As New StringBuilder() '刪除的SQL
        Try
            If GetYesOrNo("您是否確認刪除,系統別：" & Me.CmbSystemType.Text.Trim & "  工號：" & Me.TxtJobNO.Text.Trim & vbNewLine _
            & "Email：" & Me.TxtEmail.Text.Trim & "有效否：" & IIf(Me.CkbYesOrNo.Checked = True, "Y", "N") & "的資料！") Then
                RSql.Append("delete M_UserMail_t where autoid='" & Me.DgvShowEmail.CurrentRow.Cells("ColID").Value.ToString.Trim & "'")
                DBHelper.ExecSql(RSql.ToString)
                Call GetInfoHint("數據刪除成功！")
                '刷新數據，查詢數據的前100條數據
                Call GetDataToDgv("select AutoID,FrmName,isnull(Userid,'') as Userid,MailAddr,InputUser,InputDate,usey from M_UserMail_t")
            End If

        Catch ex As Exception
            Call GetInfoHint("數據刪除失敗！")
        End Try
    End Sub

#End Region

#Region "按鈕輸入框狀態"
    Public Sub BtnAndTxtState(ByVal State As String)
        Select Case UCase(State)
            Case "INSERT"
                Me.TsbNew.Enabled = False
                Me.TsbUpdate.Enabled = False
                Me.TsbSave.Enabled = True
                Me.TsbReturn.Enabled = True
                Me.TsbDelete.Enabled = False
                Me.TsbQuery.Enabled = False
                Me.TsbRefresh.Enabled = False
                Me.CmbSystemType.Enabled = True
                Me.CmbUserType.Enabled = True
                Me.TxtJobNO.Enabled = True
                Me.TxtEmail.Enabled = True
                Me.CkbYesOrNo.Checked = True
            Case "UPDATE"
                Me.TsbNew.Enabled = False
                Me.TsbUpdate.Enabled = False
                Me.TsbSave.Enabled = True
                Me.TsbReturn.Enabled = True
                Me.TsbDelete.Enabled = False
                Me.TsbQuery.Enabled = False
                Me.TsbRefresh.Enabled = False
                Me.CmbSystemType.Enabled = False
                Me.CmbUserType.Enabled = False
                Me.TxtJobNO.Enabled = False
                Me.TxtEmail.Enabled = True
            Case "UNDO"
                Me.TsbNew.Enabled = True
                Me.TsbUpdate.Enabled = True
                Me.TsbSave.Enabled = False
                Me.TsbReturn.Enabled = False
                Me.TsbDelete.Enabled = True
                Me.TsbQuery.Enabled = True
                Me.TsbRefresh.Enabled = False
                Me.CmbSystemType.Enabled = False
                Me.CmbUserType.Enabled = False
                Me.TxtJobNO.Enabled = False
                Me.TxtEmail.Enabled = False
            Case "SELECT"
                Me.TsbNew.Enabled = False
                Me.TsbUpdate.Enabled = False
                Me.TsbSave.Enabled = False
                Me.TsbReturn.Enabled = True
                Me.TsbDelete.Enabled = True
                Me.TsbQuery.Enabled = True
                Me.TsbRefresh.Enabled = True
                Me.CmbSystemType.Enabled = True
                Me.CmbUserType.Enabled = True
                Me.TxtJobNO.Enabled = True
                Me.TxtEmail.Enabled = True
        End Select
    End Sub
#End Region

#Region "清空Txt"
    Public Sub ClearTxt()
        Me.CmbSystemType.Text = ""
        Me.TxtJobNO.Text = ""
        Me.TxtEmail.Text = ""
    End Sub
#End Region

#Region "數據儲存"

    Public Sub DBSave()

        Dim ESql As New StringBuilder() 'sql 

        '判斷要保存的數據是否為空
        If DBSaveJudgeEditIsNull() Then Exit Sub

        '判斷保存時是新增或修改
        If SaveType = "INSERT" Then
            Try
                '判斷工號是否存在
                If DBSaveJudgeJobNO(Me.CmbSystemType.Text.Trim, Me.TxtJobNO.Text.Trim) Then Exit Sub

                ESql.Append("insert into M_UserMail_t(FrmName,Userid,MailAddr,InputUser,InputDate,usey) values('")
                ESql.Append(Me.CmbSystemType.Text.Trim) '系統別
                ESql.Append("','")
                ESql.Append(Me.TxtJobNO.Text.Trim) '工號
                ESql.Append("','")
                ESql.Append(Me.TxtEmail.Text.Trim) 'Email地址
                ESql.Append("','")
                ESql.Append(SysMessageClass.UseId) '輸入人
                ESql.Append("',")
                ESql.Append("getdate()") '輸入時間
                ESql.Append(",'")
                ESql.Append(IIf(Me.CkbYesOrNo.Checked = True, "Y", "N")) '有效否
                ESql.Append("')")
                '執行sql數據保存
                DBHelper.ExecSql(ESql.ToString)

                Call GetInfoHint("數據保存成功！")
                '重新初始化資料
                LoadFrom()
            Catch ex As Exception
                Call GetInfoHint("數據保存失敗！")
            End Try
        ElseIf SaveType = "UPDATE" Then
            Try
                ESql.Append("update M_UserMail_t set ")
                ESql.Append("MailAddr='")
                ESql.Append(Me.TxtEmail.Text.Trim) 'Email地址
                ESql.Append("', InputUser='")
                ESql.Append(SysMessageClass.UseId) '輸入人
                ESql.Append("',InputDate = ")
                ESql.Append("getdate()") '輸入時間
                ESql.Append(",usey='")
                ESql.Append(IIf(Me.CkbYesOrNo.Checked = True, "Y", "N")) '有效否
                ESql.Append("' where autoid='" & Me.DgvShowEmail.CurrentRow.Cells(0).Value.ToString & "'")
                '執行sql數據保存
                DBHelper.ExecSql(ESql.ToString)

                Call GetInfoHint("數據更新成功！")
                LoadFrom()
            Catch ex As Exception
                Call GetInfoHint("數據更新失敗！")
            End Try
        End If
    End Sub

    Private Function IsValidEmail(ByVal strIn As String) As Boolean
        ' Return true if strIn is in valid e-mail format. 
        Return Regex.IsMatch(strIn, "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
    End Function


    '數據保存判斷輸入值是否為空
    Public Function DBSaveJudgeEditIsNull() As Boolean
        '系統別
        If Me.CmbSystemType.Text.Trim = "" Then
            Call GetInfoHint("[系統別]不能為空！")
            Return True
            '工號
        ElseIf Me.TxtJobNO.Text.Trim = "" And Me.CmbUserType.SelectedItem.ToString.Trim = "個人" Then
            Call GetInfoHint("[工號]不能為空！")
            Return True
            'Email地址
        ElseIf Me.TxtEmail.Text.Trim = "" Then
            Call GetInfoHint("[Email地址]不能為空！")
            Return True
        End If

        If Me.CmbUserType.SelectedItem.ToString.Trim = "個人" Then
            If IsValidEmail(Me.TxtEmail.Text) = False Then
                MessageBox.Show("郵件錯誤！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtEmail.Text = ""
                Me.TxtEmail.Focus()
                Return True
            End If
        End If
        Return False
    End Function

    '數據保存判斷系統別+工號是否存在
    Public Function DBSaveJudgeJobNO(ByVal SystemType As String, ByVal JobNO As String) As Boolean
        Dim SJNSql As New StringBuilder()
        Dim SJNData As DataTable '記錄查詢數據
        Try
            '根據系統別工號查詢是否存在相同的項
            SJNSql.Append("select AutoID,FrmName,isnull(Userid,'') as Userid,MailAddr,InputUser,InputDate,usey from M_UserMail_t where ")
            SJNSql.Append("FrmName='")
            SJNSql.Append(Me.CmbSystemType.Text.Trim) '系統別
            SJNSql.Append("' and  isnull(Userid,'') = '")
            SJNSql.Append(Me.TxtJobNO.Text.Trim) '工號
            SJNSql.Append("' and  MailAddr = '")
            SJNSql.Append(Me.TxtEmail.Text.Trim) 'Email地址
            SJNSql.Append("'")

            SJNData = DBHelper.GetDataTable(SJNSql.ToString)

            If SJNData.Rows.Count > 0 Then
                Call GetInfoHint("該[系統別]+[工號]已存在,請重新輸入！")
                Me.DgvShowEmail.Rows.Clear()
                For SJNInt As Integer = 0 To SJNData.Rows.Count - 1
                    Me.DgvShowEmail.Rows.Add(SJNData.Rows(SJNInt)("AutoID").ToString.Trim, SJNData.Rows(SJNInt)("FrmName").ToString.Trim, _
                    SJNData.Rows(SJNInt)("Userid").ToString.Trim, SJNData.Rows(SJNInt)("MailAddr").ToString.Trim, _
                    SJNData.Rows(SJNInt)("InputUser").ToString.Trim, SJNData.Rows(SJNInt)("InputDate").ToString.Trim, _
                    SJNData.Rows(SJNInt)("usey").ToString.Trim)
                Next
                Return True
            End If
        Catch ex As Exception
            Call GetInfoHint("查詢工號錯誤！")
            Return True
        End Try
        Return False
    End Function
#End Region

#Region "窗體load事件"
    Private Sub FrmEmailUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadFrom()
    End Sub
#End Region

    '系統初始化
    Private Sub LoadFrom()
        '加載系統別資料
        Call GetSystemType("select distinct FrmName from M_UserMail_t")
        '初始話數據，查詢資料的前100條數據
        Call GetDataToDgv("select AutoID,FrmName,isnull(Userid,'') as Userid,MailAddr,InputUser,InputDate,usey from M_UserMail_t")

        '系統默認選中第一行
        DgvShowEmail.Rows(0).Selected = True
        '賦值
        Call GetShowEmail()
        '默認用戶別為個人
        CmbUserType.SelectedIndex = 0
        BtnAndTxtState("UNDO")
    End Sub


#Region "加載系統別"
    Public Sub GetSystemType(ByVal STSql As String)
        Dim STData As DataTable '記錄系統別數據
        Try
            STData = DBHelper.GetDataTable(STSql)
            If STData.Rows.Count > 0 Then
                Me.CmbSystemType.DataSource = STData  '給系統別賦值
                Me.CmbSystemType.DisplayMember = "FrmName"
                Me.CmbSystemType.ValueMember = "FrmName"
                'For STint As Integer = 0 To STData.Rows.Count - 1
                '    Me.CmbSystemType.Items.Add(STData.Rows(STint)("FrmName").ToString)
                'Next
            End If
        Catch ex As Exception
            Call GetInfoHint("加載系統別失敗！")
        End Try
    End Sub
#End Region

#Region "輸入框事件"
    '選擇用戶別（個人或群組）
    Private Sub CmbUserType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbUserType.SelectedIndexChanged
        If CmbUserType.SelectedIndex = 0 Then '個人
            Me.TxtJobNO.Enabled = True
        ElseIf CmbUserType.SelectedIndex = 1 Then '群組
            Me.TxtJobNO.Enabled = False
            Me.TxtJobNO.Text = ""
        End If
    End Sub
#End Region

#Region "數據顯示框事件"
    '選中資料行
    Private Sub DgvShowEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgvShowEmail.Click
        Try
            Call GetShowEmail()
        Catch ex As Exception
            Call GetInfoHint("表格賦值錯誤！")
        End Try
    End Sub
    '賦值給輸入框
    Public Sub GetShowEmail()
        If DgvShowEmail.Rows.Count < 1 Then Exit Sub
        Me.CmbSystemType.Text = Me.DgvShowEmail.CurrentRow.Cells("ColFromName").Value.ToString.Trim '系統別
        If String.IsNullOrEmpty(Me.DgvShowEmail.CurrentRow.Cells("ColJobNO").Value) Then
            Me.CmbUserType.SelectedIndex = 1   '群組
        Else
            CmbUserType.SelectedIndex = 0  '個人
            Me.TxtJobNO.Text = Me.DgvShowEmail.CurrentRow.Cells("ColJobNO").Value.ToString.Trim '工號
        End If
        Me.TxtEmail.Text = Me.DgvShowEmail.CurrentRow.Cells("ColEmail").Value.ToString.Trim 'Email地址
        Me.CkbYesOrNo.Checked = IIf(Me.DgvShowEmail.CurrentRow.Cells("ColState").Value.ToString.Trim = "Y", True, False) '有效否
    End Sub
#End Region


    Private Sub TxtJobNO_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtJobNO.Leave
        '根據用戶輸入的工號帶出郵件地址
        If Not String.IsNullOrEmpty(Me.TxtJobNO.Text) Then
            Dim SqlStr As String = " select  b.loginid,b.username,b.email from opendatasource('SQLOLEDB','Data Source=192.168.23.71;User ID=szsa;Password=szsa').MyDataWareHouse.dbo.Mem_GenInf b  " _
                                & "where  b.id is not null and b.Invisible ='false' and b.loginid='" & Me.TxtJobNO.Text.Trim & "'"
            Dim dt As DataTable = DBHelper.GetDataTable(SqlStr)
            If dt.Rows.Count > 0 Then
                Me.LblName.Text = dt.Rows(0)("username").ToString
                Me.TxtEmail.Text = dt.Rows(0)("email").ToString
            End If
        End If
    End Sub

    Private Sub FrmEmailUpdate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


End Class