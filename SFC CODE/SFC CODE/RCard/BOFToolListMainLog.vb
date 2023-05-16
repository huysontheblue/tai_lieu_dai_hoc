Public Class BOFToolListMainLog

    Private _MyPartID As String
    ''' <summary>
    ''' 料号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MyPartID() As String
        Get
            Return _MyPartID
        End Get
        Set(ByVal value As String)
            _MyPartID = value
        End Set
    End Property

    Private _MyStationName As String
    ''' <summary>
    ''' 工站
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MyStationName() As String
        Get
            Return _MyStationName
        End Get
        Set(ByVal value As String)
            _MyStationName = value
        End Set
    End Property




    Private Sub BOFToolListMainLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPartID.Text = MyPartID
        txtStationName.Text = MyStationName
        DataLoad()
    End Sub

    ''' <summary>
    ''' 加载数据源
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataLoad()
        Dim where = " where 1=1 "
        If String.IsNullOrEmpty(txtPartID.Text.Trim()) = False Then
            where += " and PartID='" & txtPartID.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(txtStationName.Text.Trim()) = False Then
            where += " and StationName=N'" & txtStationName.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(txtEquimentName.Text.Trim()) = False Then
            where += " and EquimentName=N'" & txtEquimentName.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(txtChangeType.Text.Trim()) = False Then
            where += " and ChangeType=N'" & txtChangeType.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(txtNewUserName.Text.Trim()) = False Then
            where += " and NewUserName=N'" & txtNewUserName.Text.Trim() & "'"
        End If
        where += " order by NewTime desc"
        Try
            Dim dt = MainFrame.DbOperateUtils.GetDataTable("select top 1000 * from m_BOFToolListLog_t" + where)
            dgvData.AutoGenerateColumns = False
            dgvData.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 查询
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        DataLoad()
    End Sub

    ''' <summary>
    ''' 刷新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolRefrech_Click(sender As Object, e As EventArgs) Handles ToolRefrech.Click
        txtPartID.Text = Nothing
        txtStationName.Text = Nothing
        txtEquimentName.Text = Nothing
        txtChangeType.Text = Nothing
        txtNewUserName.Text = Nothing
        DataLoad()
    End Sub

    ''' <summary>
    ''' 导出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolMain_Click(sender As Object, e As EventArgs) Handles toolMain.Click
        Dim sql = "select PartID,OrderBy,StationName,EquimentName,ChangeType" & vbCrLf &
        ",OldUserName,OldTime,OldValue," & vbCrLf &
        "NewUserName, NewTime, NewValue from m_BOFToolListLog_t"
        Dim dt = MainFrame.DbOperateUtils.GetDataTable(sql)
        Dim ay() = {"料号", "工序", "工站", "设备/治具名称", "变更类型", "变更前用户", "变更前时间", "变更前值", "变更后用户", "变更后时间", "变更后值"}
        VbCommClass.NPOIExcle.DataTableExportToExcle(dt, ay, String.Format("{0}BOF清单变更记录.xls", Date.Now.ToString("yyyyMMdd")))
    End Sub

    ''' <summary>
    ''' 行号
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvData_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvData.RowPostPaint
        Dim RowIndex = (e.RowIndex + 1).ToString()
        Using sb As SolidBrush = New SolidBrush(dgvData.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(RowIndex, dgvData.RowHeadersDefaultCellStyle.Font, sb, New Point(e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4))
        End Using

    End Sub
End Class