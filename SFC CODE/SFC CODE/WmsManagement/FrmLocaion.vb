Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Text
Imports SysCommClass
Imports System.Windows.Forms

Public Class FrmLocaion

    Private Enum FormBtnonType
        Normal
        Add
        Modify
        Delete
        Save
        Undo
        Search
    End Enum

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

    '初期化
    Private Sub FrmLocaion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '设置权限
        SetControlEnable(FormBtnonType.Normal)
        With Me.dgvView
            .AutoResizeColumns()
            .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            .ScrollBars = ScrollBars.Both
        End With
    End Sub

#Region "事件"
    '查询 
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        SetControlEnable(FormBtnonType.Search)
        Search()
    End Sub
    '返回
    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        SetControlEnable(FormBtnonType.Undo)
        Me._ActivaStatus = FormBtnonType.Normal.ToString
    End Sub
    '作废
    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        If Me.dgvView.CurrentRow Is Nothing OrElse Me.dgvView.RowCount < 1 Then
            Exit Sub
        End If
        Dim LocationId As String = ""
        Dim LocationName As String = ""
        Dim confirmMsg As String
        LocationName = Me.dgvView.CurrentRow.Cells("LocationName").Value.ToString
        LocationId = Me.dgvView.CurrentRow.Cells("LocationID").Value.ToString
        confirmMsg = "确定要删除[ " & LocationName & " ]吗？"
        If (MessageUtils.ShowConfirm(confirmMsg, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            DeleteData()
            '验证是否已在保养的资料
            Me.dgvView.Rows.RemoveAt(Me.dgvView.CurrentRow.Index)
        End If
        SetControlEnable(FormBtnonType.Delete)
    End Sub
    '新增
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Me._ActivaStatus = FormBtnonType.Add.ToString
        SetControlEnable(FormBtnonType.Add)

    End Sub
    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        If InputCheck() = True Then
            If SaveData() = True Then
                MessageUtils.ShowInformation("保存成功")
                SetControlEnable(FormBtnonType.Save)
                Me._ActivaStatus = FormBtnonType.Normal.ToString
                Search()
            End If
        End If
    End Sub
    '退出 
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If Me.dgvView.RowCount < 1 OrElse Me.dgvView.CurrentCell Is Nothing Then
            Exit Sub
        End If

        SetControlEnable(FormBtnonType.Modify)
        Me._ActivaStatus = FormBtnonType.Modify.ToString

    End Sub
    '单击
    Private Sub dgvView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellClick
        If e.RowIndex = -1 Then Exit Sub

        txtLocationID.Text = dgvView.Rows(e.RowIndex).Cells("LocationID").Value.ToString
        txtLocationName.Text = dgvView.Rows(e.RowIndex).Cells("LocationName").Value.ToString

        ChkUsey.Checked = False
        If dgvView.Rows(e.RowIndex).Cells("Usey").Value.ToString = "Y" Then
            ChkUsey.Checked = True
        End If
    End Sub

    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#End Region

#Region "方法"

    Private Sub Search()
        Dim strSQL As String = " SELECT LocationID, LocationName,Usey,UserId,Intime FROM m_WHLocation_t " &
                               " WHERE 1=1  "

        Dim strWhere As New System.Text.StringBuilder

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtLocationID.Text)) = False Then
            strWhere.AppendFormat(" and LocationID = '{0}' ", txtLocationID.Text)
        End If

        'If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtLocationName.Text)) = False Then
        '    strWhere.AppendFormat(" and LocationName like '%{0}%' ", txtLocationName.Text)
        'End If
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString)
        dgvView.DataSource = dt
    End Sub

    Private Function InputCheck() As Boolean
        If String.IsNullOrEmpty(Me.txtLocationID.Text.Trim) Then
            Me.lbMsg.Text = "请输入仓库代码!"
            Me.txtLocationID.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtLocationName.Text.Trim) Then
            Me.lbMsg.Text = "请输入仓库名称!"
            Me.txtLocationName.Focus()
            Return False
        End If

        '此仓库代码已存在是否重复
        If ExistMpCheck("1") = False Then
            Me.lbMsg.Text = "此仓库代码已存在,请勿重复!"
            Me.txtLocationID.Focus()
            Return False
        End If

        '此仓库名称已存在是否重复
        If ExistMpCheck("2") = False Then
            Me.lbMsg.Text = "此仓库名称已存在,请勿重复!"
            Me.txtLocationID.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function ExistMpCheck(type As String) As Boolean
        Dim result As Boolean = False

        Try

            If Me.ActivaStatus <> FormBtnonType.Add.ToString Then
                Return True
            End If

            Dim strSQL As String
            strSQL = "SELECT LocationID, LocationName FROM m_WHLocation_t WHERE 1=1 "

            If type = "1" Then
                strSQL = strSQL + String.Format(" and LocationID = '{0}' ", txtLocationID.Text)
            Else
                strSQL = strSQL + String.Format(" and LocationName = '{0}' ", txtLocationName.Text)
            End If

            Dim iRow As Int16 = DbOperateUtils.GetRowsCount(strSQL.ToString)

            If iRow > 0 Then
                Return False
            End If
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmLocaion", "ExistMpCheck()", "sys")
        End Try
        Return True
    End Function

    Private Function SaveData() As Boolean
        Dim result As Boolean = False
        Try
            Dim o_strSql As New StringBuilder
            Dim UserID As String = VbCommClass.VbCommClass.UseId

            Dim check As String = "N"

            If ChkUsey.Checked = True Then
                check = "Y"
            End If

            '新增
            If Me.ActivaStatus = FormBtnonType.Add.ToString Then
                o_strSql.Append("INSERT INTO m_WHLocation_t (LocationID, LocationName ,Usey,UserId,Intime)")
                o_strSql.Append(String.Format(" VALUES(N'{0}',N'{1}','Y','{2}',GETDATE())", Me.txtLocationID.Text, txtLocationName.Text.Trim, UserID))
            Else
                o_strSql.Append(String.Format("UPDATE m_WHsLocation_t SET LocationName=N'{0}',Usey='{1}',UserId=N'{2}',Intime=GETDATE() WHERE LocationID='{3}'",
                                               Me.txtLocationName.Text.ToString, check, UserID, Me.txtLocationID.Text.Trim))
            End If
            DbOperateUtils.ExecSQL(o_strSql.ToString)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquMaintenanceType", "SaveData()", "sys")
        End Try
        Return True
    End Function

    Private Sub DeleteData()
        Try
            Dim LocationID = dgvView.Rows(dgvView.CurrentRow.Index).Cells("LocationID").Value.ToString

            Dim strSQL As String = " update m_WHsLocation_t set usey = 'N' where LocationID = '{0}' "
            strSQL = String.Format(strSQL, LocationID)

            DbOperateUtils.ExecSQL(strSQL)

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 设置控件权限
    ''' </summary>
    ''' <param name="fbt"></param>
    ''' <remarks></remarks>
    Private Sub SetControlEnable(ByVal fbt As FormBtnonType)
        Select Case fbt
            Case FormBtnonType.Normal

            Case FormBtnonType.Add
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolQuery.Enabled = False
                Me.toolSave.Enabled = True
                Me.toolBack.Enabled = True
            Case FormBtnonType.Modify
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolQuery.Enabled = False
                Me.toolSave.Enabled = True
                Me.toolBack.Enabled = True
            Case FormBtnonType.Save
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolQuery.Enabled = True
                Me.toolSave.Enabled = False
                Me.toolBack.Enabled = False
            Case FormBtnonType.Undo
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolQuery.Enabled = True
                Me.toolSave.Enabled = False
                Me.toolBack.Enabled = False
            Case FormBtnonType.Search

            Case Else
                'do Nothing
        End Select
    End Sub

#End Region


End Class