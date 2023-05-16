Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Xml
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports MainFrame
Imports SysBasicClass
Imports System.Text.RegularExpressions

Public Class FrmOnlineSopEMail

#Region "枚举"
    Private Enum FormBtnonType
        Normal
        Add
        Modify
        Delete
        Save
        Undo
        Search
        Refresh
    End Enum

    Private Enum EmailGridView
        UserID
        UserName
        Email
        StatusText
        CreUserId
        InTime
        Satus
        Id
    End Enum
#End Region

#Region "属性"
#Region "当前状态"
    Private _ActivaStatus As String
    Public Property ActivaStatus() As String
        Get
            Return _ActivaStatus
        End Get

        Set(ByVal Value As String)
            _ActivaStatus = Value
        End Set
    End Property
#End Region
    Private Shared ReadOnly reg_Email As Regex = New Regex("^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$")



#End Region

#Region "事件"

    Private Sub FrmOnlineSopEMail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me._ActivaStatus = FormBtnonType.Normal.ToString
        BindData()
        BindComboxStatus(Me.cbStatus)
        SetControlEnable(FormBtnonType.Normal)
    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Me._ActivaStatus = FormBtnonType.Add.ToString
        SetControlEnable(FormBtnonType.Add)
    End Sub
    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If Me.dgvEmail.RowCount < 1 OrElse Me.dgvEmail.CurrentCell Is Nothing Then
            Exit Sub
        End If
        Dim _UserId As String = Nothing
        Dim _UserName As String = Nothing
        Dim _Email As String = Nothing
        Dim _Satus As String = Nothing
        _UserId = Me.dgvEmail.CurrentRow.Cells(EmailGridView.UserID).Value.ToString
        _UserName = Me.dgvEmail.CurrentRow.Cells(EmailGridView.UserName).Value.ToString
        _Email = Me.dgvEmail.CurrentRow.Cells(EmailGridView.Email).Value.ToString
        _Satus = Me.dgvEmail.CurrentRow.Cells(EmailGridView.Satus).Value.ToString
        Me._ActivaStatus = FormBtnonType.Modify.ToString
        SetControlEnable(FormBtnonType.Modify)
        Me.txtUserID.Text = _UserId
        Me.txtUserName.Text = _UserName
        Me.txtEmail.Text = _Email
        Me.cbStatus.SelectedValue = _Satus
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Me.dgvEmail.RowCount < 1 OrElse Me.dgvEmail.CurrentCell Is Nothing Then
            Exit Sub
        End If
        Dim confirmMsg As String
        Dim _Email As String
        _Email = Me.dgvEmail.CurrentRow.Cells(EmailGridView.Email).Value.ToString

        confirmMsg = "确定要删除[" & _Email & "]邮件吗？"
        If (MessageUtils.ShowConfirm(confirmMsg, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            DeleteEmail()

            Me.dgvEmail.Rows.RemoveAt(Me.dgvEmail.CurrentRow.Index)
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If InputCheck() = True Then

            If SaveData() = True Then
                MessageUtils.ShowInformation("保存成功")
                SetControlEnable(FormBtnonType.Save)
                Me._ActivaStatus = FormBtnonType.Normal.ToString
                BindData()
            End If
        End If


    End Sub
    Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        SetControlEnable(FormBtnonType.Undo)
        Me._ActivaStatus = FormBtnonType.Normal.ToString
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SetControlEnable(FormBtnonType.Search)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        BindData()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnMailRelation_Click(sender As Object, e As EventArgs) Handles btnMailRelation.Click
        If Me.dgvEmail.CurrentCell.RowIndex > -1 AndAlso Me.dgvEmail.CurrentCell.ColumnIndex > -1 AndAlso Me.dgvEmail.RowCount > 0 Then
            Dim _UserId As String = Nothing
            Dim _UserName As String = Nothing
            Dim _Satus As String = Nothing
            _UserId = Me.dgvEmail.CurrentRow.Cells(EmailGridView.UserID).Value.ToString
            _Satus = Me.dgvEmail.CurrentRow.Cells(EmailGridView.Satus).Value.ToString
            _UserName = Me.dgvEmail.CurrentRow.Cells(EmailGridView.UserName).Value.ToString
            If _Satus <> "N" Then
                MessageUtils.ShowWarning("仅为制作中状态的资料可关联设置,请知悉！")
                Exit Sub
            End If

            Dim frmMailRelation As New FrmOnlineSopMailRelation(_UserId, _UserName)
            If frmMailRelation.ShowDialog() = Windows.Forms.DialogResult.OK Then
                LoadMailRelation(_UserId, _UserName)
            End If
        End If
    
    End Sub

    Private Sub dgvEmail_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmail.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso Me.dgvEmail.RowCount > 0 Then
            Dim _UserId As String = Nothing
            Dim _UserName As String = Nothing
            Dim _Satus As String = Nothing
            _UserId = Me.dgvEmail.CurrentRow.Cells(EmailGridView.UserID).Value.ToString
            _Satus = Me.dgvEmail.CurrentRow.Cells(EmailGridView.Satus).Value.ToString
            _UserName = Me.dgvEmail.CurrentRow.Cells(EmailGridView.UserName).Value.ToString
            If _Satus <> "N" Then
                Me.dgvMailRelation.Rows.Clear()
                Exit Sub
            End If
            LoadMailRelation(_UserId, _UserName)
        End If
    End Sub

    Private Sub dgvEmail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmail.CellDoubleClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso Me.dgvEmail.RowCount > 0 Then
            Dim _UserId As String = Nothing
            Dim _UserName As String = Nothing
            Dim _Satus As String = Nothing
            _UserId = Me.dgvEmail.CurrentRow.Cells(EmailGridView.UserID).Value.ToString
            _Satus = Me.dgvEmail.CurrentRow.Cells(EmailGridView.Satus).Value.ToString
            _UserName = Me.dgvEmail.CurrentRow.Cells(EmailGridView.UserName).Value.ToString
            If _Satus <> "N" Then
                Exit Sub
            End If

            Dim frmMailRelation As New FrmOnlineSopMailRelation(_UserId, _UserName)
            If frmMailRelation.ShowDialog() = Windows.Forms.DialogResult.OK Then
                LoadMailRelation(_UserId, _UserName)
            End If
        End If
    End Sub


#End Region

#Region "函数"

    ''' <summary>
    ''' 获取数据并绑定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BindData()
        Try
            Dim strSql As String
            Dim dt As DataTable
            strSql = "  SELECT a.UserId,a.UserName,a.Email,c.TEXT as StatusText,a.CreUserId,a.InTime,a.Satus ,a.Id " &
                     "   FROM m_OnlineSopEmail_t a left join  m_BaseData_t c on c.VALUE=a.Satus and c.ITEMKEY='OnlineSopStatus'   left join m_Users_t d on d.UserID=a.ProdPM  where 1=1  "

            If Not String.IsNullOrEmpty(Me.txtUserID.Text.Trim) Then
                strSql &= " and a.UserID like '%" & Me.txtUserID.Text.Trim & "%'"
            End If
            If Not String.IsNullOrEmpty(Me.txtUserName.Text.Trim) Then
                strSql &= " and a.UserName like N'%" & Me.txtUserName.Text.Trim & "%'"
            End If
            If Not String.IsNullOrEmpty(Me.txtEmail.Text.Trim) Then
                strSql &= " and a.Email like '%" & Me.txtUserID.Text.Trim & "%'"
            End If

            If Me.cbStatus.SelectedText.ToString <> "" Then
                strSql &= " and c.TEXT  = '" & Me.cbStatus.SelectedText.ToString & "'"
            End If

            strSql &= " order by a.InTime desc"
            dt = DbOperateUtils.GetDataTable(strSql)
            Me.dgvEmail.DataSource = dt
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopEMail", "BindData()", "sys")
        End Try


    End Sub

    ''' <summary>
    ''' 检查输入项
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InputCheck() As Boolean
        Dim r As Boolean = False

        If String.IsNullOrEmpty(Me.txtUserID.Text.Trim) Then
            MessageUtils.ShowInformation("请输入工号!")
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtUserName.Text.Trim) Then
            MessageUtils.ShowInformation("请输入姓名!")
            Return False
        End If
        If String.IsNullOrEmpty(Me.txtEmail.Text.Trim) Then
            MessageUtils.ShowInformation("请输入邮箱地址!")
            Return False
        End If

        If reg_Email.IsMatch(Me.txtEmail.Text.Trim.ToString) = False Then
            MessageUtils.ShowInformation("请输入正确的邮件地址!")
            Return False
        End If
        If Me.cbStatus.SelectedIndex < 1 Then
            MessageUtils.ShowInformation("请选择审批状态!")
            Return False
        End If
        If String.IsNullOrEmpty(Me.cbStatus.SelectedValue.ToString) Then
            MessageUtils.ShowInformation("请选择审批状态!")
            Return False
        End If

        'If CheckIsExist() = True Then
        '    MessageUtils.ShowInformation("一个用户不能设置多种邮件提醒!")
        '    Return False
        'End If
   
        Return True
    End Function

    ''' <summary>
    ''' 保存数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveData() As Boolean
        Dim r As Boolean = False

        Dim o_strSql As New StringBuilder
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        If ActivaStatus = FormBtnonType.Add.ToString Then
            If ExistsUserIDStaus() Then
                MessageUtils.ShowInformation("已经存在该用户的该状态,无需重复添加!")
                Return False
            End If
            o_strSql.Append("INSERT INTO m_OnlineSopEmail_t(UserId,UserName,Satus,Email,Usey,CreUserId,InTime)")
            o_strSql.Append(String.Format("VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'Y','{4}',getdate())", Me.txtUserID.Text.Trim, Me.txtUserName.Text, Me.cbStatus.SelectedValue.ToString, Me.txtEmail.Text.Trim, UserID))
            DbOperateUtils.ExecSQL(o_strSql.ToString)
        Else
            Dim _UserId As String
            Dim _Email As String
            Dim _Id As String
            _UserId = Me.dgvEmail.CurrentRow.Cells(EmailGridView.UserID).Value.ToString
            _Email = Me.dgvEmail.CurrentRow.Cells(EmailGridView.Email).Value.ToString
            _Id = Me.dgvEmail.CurrentRow.Cells(EmailGridView.Id).Value.ToString
            o_strSql.Append(String.Format("update  m_OnlineSopEmail_t set  UserID=N'{0}' ,UserName=N'{1}',Satus=N'{2}', Email='{3}',CreUserId='{4}',InTime=getdate() ",
                                          Me.txtUserID.Text.Trim, Me.txtUserName.Text, Me.cbStatus.SelectedValue.ToString, Me.txtEmail.Text.Trim, UserID))
            o_strSql.Append(String.Format(" WHERE  ID='{0}'", _Id))

            DbOperateUtils.ExecSQL(o_strSql.ToString)
        End If


        Return True
    End Function

    Public Function ExistsUserIDStaus() As Boolean
        Dim o_strSql As New StringBuilder
        o_strSql.Append("select TOP 1 1 from m_OnlineSopEmail_t where UserID='" + Me.txtUserID.Text.Trim + "' and Satus=N'" + Me.cbStatus.SelectedValue.ToString + "'")
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(o_strSql.ToString())
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                ExistsUserIDStaus = True
            Else
                ExistsUserIDStaus = False
            End If
        End Using

        Return ExistsUserIDStaus
    End Function


    ''' <summary>
    ''' 删除指定行的数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DeleteEmail() As Boolean
        Dim r As Boolean = False
        Dim strSql As String
        Dim _Id As String

        Try
            _Id = Me.dgvEmail.CurrentRow.Cells(EmailGridView.Id).Value.ToString
            strSql = String.Format(" DELETE m_OnlineSopEmail_t WHERE  Id='{0}'", _Id)
            DbOperateUtils.ExecSQL(strSql)
            r = True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopEMail", "DeleteEmail()", "sys")
        End Try
        Return r
    End Function


    ''' <summary>
    ''' 检查当前用户是否已添加此邮箱地址
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckIsExist() As Boolean
        Dim r As Boolean = False
        Try
            Dim strSql As String
            Dim iRow As Integer = 0
            strSql = String.Format(" select * from  m_OnlineSopEmail_t WHERE  UserID='{0}'  ", Me.txtUserID.Text.Trim)

            'strSql = String.Format(" select * from  m_OnlineSopEmail_t WHERE  UserID='{0}' AND Email='{1}' and Satus='{2}' ", Me.txtUserID.Text.Trim, Me.txtEmail.Text.Trim, Me.cbStatus.SelectedValue.ToString)

            If ActivaStatus = FormBtnonType.Modify.ToString Then
                Dim _Id As String
                _Id = Me.dgvEmail.CurrentRow.Cells(EmailGridView.Id).Value.ToString
                strSql &= " and Id <> '" & _Id & "'"
            End If

            iRow = DbOperateUtils.GetRowsCount(strSql)
            r = IIf(iRow > 0, True, False)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopEMail", "CheckExist()", "sys")
        End Try
        Return r
    End Function


    ''' <summary>
    ''' 绑定关联设置
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMailRelation(ByVal makeuserid As String, ByVal makeusername As String)
        Try
            Dim strSql As String
            Dim dt As DataTable
            Dim s_S As String = Nothing
            Dim s_Qc As String = Nothing
            Dim s_Pro As String = Nothing
            Dim s_A As String = Nothing
            Dim s_Dcc As String = Nothing
            Dim I As Int16
            strSql = "  select RelationType,RelationUserName  from m_OnlineSopMailRelation_t where MakeUserId='" & makeuserid & "' and Usey='Y' "
            dt = DbOperateUtils.GetDataTable(strSql)
            Me.dgvMailRelation.Rows.Clear()
            If dt.Rows.Count > 0 Then

                For I = 0 To dt.Rows.Count - 1
                    Select Case dt.Rows(I)!RelationType.ToString
                        Case "S"
                            If s_S Is Nothing Then
                                s_S = dt.Rows(I)!RelationUserName.ToString
                            Else
                                s_S = s_S & ";" & dt.Rows(I)!RelationUserName.ToString
                            End If

                        Case "Q"
                            If s_Qc Is Nothing Then
                                s_Qc = dt.Rows(I)!RelationUserName.ToString
                            Else
                                s_Qc = s_Qc & ";" & dt.Rows(I)!RelationUserName.ToString
                            End If
                        Case "P"
                            If s_Pro Is Nothing Then
                                s_Pro = dt.Rows(I)!RelationUserName.ToString
                            Else
                                s_Pro = s_Pro & ";" & dt.Rows(I)!RelationUserName.ToString
                            End If
                        Case "A"
                            If s_A Is Nothing Then
                                s_A = dt.Rows(I)!RelationUserName.ToString
                            Else
                                s_A = s_A & ";" & dt.Rows(I)!RelationUserName.ToString
                            End If
                        Case "C"
                            If s_Dcc Is Nothing Then
                                s_Dcc = dt.Rows(I)!RelationUserName.ToString
                            Else
                                s_Dcc = s_Dcc & ";" & dt.Rows(I)!RelationUserName.ToString
                            End If
                    End Select
                Next
                Me.dgvMailRelation.Rows.Add(makeusername, s_S, s_Qc, s_Pro, s_A, s_Dcc)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopEMail", "LoadMailRelation()", "sys")
        End Try
    End Sub


    ''' <summary>
    ''' 设置控件权限
    ''' </summary>
    ''' <param name="fbt"></param>
    ''' <remarks></remarks>
    Private Sub SetControlEnable(ByVal fbt As FormBtnonType)
        Me.txtUserID.Text = ""
        Me.txtEmail.Text = ""
        Me.txtUserName.Text = ""
        Me.cbStatus.SelectedIndex = 0

        Select Case fbt
            Case FormBtnonType.Normal
                Me.txtUserID.ReadOnly = True
                Me.txtEmail.ReadOnly = True
                Me.txtUserName.ReadOnly = True
                Me.cbStatus.Enabled = False
            Case FormBtnonType.Add
                Me.btnNew.Enabled = False
                Me.btnModify.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnSearch.Enabled = False
                Me.btnRefresh.Enabled = False
                Me.btnSave.Enabled = True
                Me.btnUndo.Enabled = True
                Me.txtUserID.ReadOnly = False
                Me.txtEmail.ReadOnly = False
                Me.txtUserName.ReadOnly = False
                Me.cbStatus.Enabled = True
            Case FormBtnonType.Modify
                Me.btnNew.Enabled = False
                Me.btnModify.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnSearch.Enabled = False
                Me.btnRefresh.Enabled = False
                Me.btnSave.Enabled = True
                Me.btnUndo.Enabled = True
                Me.txtUserID.ReadOnly = True
                Me.txtEmail.ReadOnly = False
                Me.txtUserName.ReadOnly = False
                Me.cbStatus.Enabled = True
            Case FormBtnonType.Save
                Me.btnNew.Enabled = True
                Me.btnModify.Enabled = True
                Me.btnDelete.Enabled = True
                Me.btnSearch.Enabled = True
                Me.btnRefresh.Enabled = True
                Me.btnSave.Enabled = False
                Me.btnUndo.Enabled = False
                Me.txtUserID.ReadOnly = True
                Me.txtEmail.ReadOnly = True
                Me.txtUserName.ReadOnly = True
                Me.cbStatus.Enabled = False

            Case FormBtnonType.Undo
                Me.btnNew.Enabled = True
                Me.btnModify.Enabled = True
                Me.btnDelete.Enabled = True
                Me.btnSearch.Enabled = True
                Me.btnRefresh.Enabled = True
                Me.btnSave.Enabled = False
                Me.btnUndo.Enabled = False
                Me.txtUserID.ReadOnly = True
                Me.txtEmail.ReadOnly = True
                Me.txtUserName.ReadOnly = True
                Me.cbStatus.Enabled = False
            Case FormBtnonType.Search
                Me.txtUserID.ReadOnly = False
                Me.txtEmail.ReadOnly = False
                Me.txtUserName.ReadOnly = False
                Me.cbStatus.Enabled = True
            Case Else
                'do Nothing

        End Select
    End Sub



    ''' <summary>
    ''' SOP状态
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Private Shared Sub BindComboxStatus(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select value,text from m_BaseData_t where itemkey = 'OnlineSopStatus' and status = 1 order by SORT "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Dim dr As DataRow = dt.NewRow

        dr("text") = ""
        dr("value") = ""
        dt.Rows.InsertAt(dr, 0)
        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = "text"
        ColComboBox.ValueMember = "value"

    End Sub
#End Region

End Class