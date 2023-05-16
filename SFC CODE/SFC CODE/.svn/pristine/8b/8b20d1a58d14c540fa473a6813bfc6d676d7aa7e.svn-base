Imports MainFrame.SysCheckData
Imports MainFrame
Public Class FrmOnlineSopQuery


#Region "查询条件"
    Private _QueryWhere As String
    Public Property QueryWhere() As String
        Get
            Return _QueryWhere
        End Get

        Set(ByVal Value As String)
            _QueryWhere = Value
        End Set
    End Property

    Private _IsQueryOld As Boolean
    Public Property IsQueryOld() As Boolean
        Get
            Return _IsQueryOld
        End Get

        Set(ByVal Value As Boolean)
            _IsQueryOld = Value
        End Set
    End Property
#End Region


    Private Sub FrmOnlineSopQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpStartDate.Value = Now().AddMonths(-1).ToString("yyyy-MM-dd")
        dtpEndDate.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
        BindComboxStatus(Me.cbStatus)

        If Me.chkIsQueryOld.Checked = True Then
            _IsQueryOld = True
        Else
            _IsQueryOld =False
        End If

    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If Me.cbStaDate.Checked AndAlso Me.cbEndDate.Checked Then

            If DateDiff("d", CDate(dtpStartDate.Value), CDate(dtpEndDate.Value)) < 0 Then
                MessageUtils.ShowError("开始日期不得大于结束日期!")
                Exit Sub
            End If
        End If

     
        Me._QueryWhere = GetQueryString()
        Me._IsQueryOld = IIf(Me.chkIsQueryOld.Checked = True, True, False)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 获取查询字串
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetQueryString() As String
        Dim strWhere As String = ""
        If Not String.IsNullOrEmpty(Me.txtSopName.Text.Trim) Then

            strWhere &= " AND a.SopName like N'%" & Me.txtSopName.Text.Trim & "%'"
        End If
        If Not String.IsNullOrEmpty(Me.txtDocId.Text.Trim) Then
            strWhere &= " AND a.DocId like '%" & Me.txtDocId.Text.Trim & "%'"
        End If

        If Not String.IsNullOrEmpty(Me.txtPartDesc.Text.Trim) Then
            strWhere &= " AND a.PartDesc like N'%" & Me.txtPartDesc.Text.Trim & "%' "
        End If
        If Not String.IsNullOrEmpty(Me.cbStatus.SelectedValue.ToString) Then
            strWhere &= " AND a.Status like N'%" & Me.cbStatus.SelectedValue.ToString & "%' "
        End If
        If Not String.IsNullOrEmpty(Me.txtVersion.Text.Trim) Then
            strWhere &= " AND a.Version like N'%" & Me.txtVersion.Text.Trim & "%' "
        End If
        If Not String.IsNullOrEmpty(Me.txtShape.Text.Trim) Then
            strWhere &= " AND a.Shape like N'%" & Me.txtShape.Text.Trim & "%' "
        End If

        If Not String.IsNullOrEmpty(Me.txtUserName.Text.Trim) Then
            strWhere &= " AND c.UserName like N'%" & Me.txtUserName.Text.Trim & "%' "
        End If
        If Me.cbStaDate.Checked AndAlso Me.cbEndDate.Checked Then
            If Not String.IsNullOrEmpty(dtpStartDate.Text.Trim) AndAlso Not String.IsNullOrEmpty(dtpEndDate.Text.Trim) Then
                strWhere &= " AND a.CreateTime >= '" & dtpStartDate.Text.Trim & "' AND a.CreateTime <= '" & dtpEndDate.Text.Trim & "' "
            End If
        End If

        Return strWhere
    End Function


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


End Class