Public Class FrmParetoShowSub

    'Public Enum dispalyType
    '    DAY = 0
    '    WEEK
    '    MONTH
    'End Enum

    Private m_type As String
    Public WriteOnly Property Type As String
        Set(value As String)
            m_type = value
        End Set
    End Property

    Private m_date As Date
    Public WriteOnly Property SDate As Date
        Set(value As Date)
            m_date = value
        End Set
    End Property

    ''' <summary>
    ''' 查找旧数据
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmParetoShowSub_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboQueryLine.Enabled = False
        cboPartID.Enabled = False
        If m_type = "日" Then
            Me.Text = "不良参照查询（前一天数据）"
        ElseIf m_type = "周" Then
            Me.Text = "不良参照查询（前一周数据）"
        ElseIf m_type = "月" Then
            Me.Text = "不良参照查询（前一月数据）"
        End If
        SetFindVisible()
        '设置前一天时间
        btnBefore_Click(Nothing, Nothing)
        '查找不良数据
        LoadNGData()
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        LoadNGData()
    End Sub

    Private Sub LoadNGData()
        Dim dateFrom As String = Me.dtpDate.Value.ToString("yyyy-MM-dd")
        Dim dateTo As String = Me.dtpDateTo.Value.ToString("yyyy-MM-dd")

        Dim dt As DataTable
        If m_type = "日" Then
            dt = KBCom.GetNGData(Me.cboPartID.Text.Trim(), Me.cboQueryLine.Text, dateFrom)
        Else
            dt = KBCom.GetNGData(Me.cboPartID.Text.Trim(), Me.cboQueryLine.Text, dateFrom, dateTo)
        End If

        dgvNG.DataSource = Nothing
        ' 项次/ 不良内容/不良数 / 不良率 / 影响度 / 累计影响度
        If dt.Rows.Count > 0 Then
            dgvNG.DataSource = KBCom.GetTable(dt)
        End If
        dgvNG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvNG.Width = 540
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If dtpDate.Value > Date.Now Then Exit Sub

        If m_type = "日" Then
            m_date = dtpDate.Value.AddDays(1)
        ElseIf m_type = "周" Then
            m_date = dtpDate.Value.AddDays(7)
        ElseIf m_type = "月" Then
            m_date = dtpDate.Value.AddMonths(1)
        End If
        SetDateValue()
        LoadNGData()
    End Sub

    Private Sub btnBefore_Click(sender As Object, e As EventArgs) Handles btnBefore.Click
        If m_type = "日" Then
            m_date = dtpDate.Value.AddDays(-1)
        ElseIf m_type = "周" Then
            m_date = dtpDate.Value.AddDays(-7)
        ElseIf m_type = "月" Then
            m_date = dtpDate.Value.AddMonths(-1)
        End If
        SetDateValue()
        LoadNGData()
    End Sub

    Private Sub SetFindVisible()
        If m_type = "日" Then
            lblStartDate.Text = "日期:"
            Me.SplitContainer3.Panel1Collapsed = True
            'dtpDate.Value = Date.Now
        Else
            Me.SplitContainer3.Panel1Collapsed = False
            lblStartDate.Text = "开始日:"
            lblEndDate.Text = "结束日:"
        End If
    End Sub

    Private Sub SetDateValue()
        If m_type = "日" Then
            dtpDate.Value = m_date
        ElseIf m_type = "周" Then
            dtpDate.Value = KBCom.GetWeekFirstDaySun(m_date)
            dtpDateTo.Value = KBCom.GetWeekLastDaySat(m_date)
        ElseIf m_type = "月" Then
            Dim d1 As DateTime = New DateTime(m_date.Year, m_date.Month, 1)
            Dim d2 As DateTime = d1.AddMonths(1).AddDays(-1)
            dtpDate.Value = d1
            dtpDateTo.Value = d2
        End If
    End Sub

End Class