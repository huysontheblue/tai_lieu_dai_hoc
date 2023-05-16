Imports MainFrame
Imports MainFrame.SysCheckData

Public Class BOFToolListDetailCopy

    Private Sub BOFToolListDetailCopy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bindStation()
    End Sub

#Region "加载工站"
    ''' <summary>
    ''' 加载工站
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub bindStation()
        Dim sql = "select * from dbo.m_Rstation_t where usey='Y'"
        cmbStation.DataSource = MainFrame.DbOperateUtils.GetDataTable(sql)
        cmbStation.DisplayMember = "Stationname"
        cmbStation.ValueMember = "Stationid"
        cmbStation.SelectedIndex = -1
    End Sub
#End Region

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


    Private _MyOrderBy As String
    ''' <summary>
    ''' 排序
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MyOrderBy() As String
        Get
            Return _MyOrderBy
        End Get
        Set(ByVal value As String)
            _MyOrderBy = value
        End Set
    End Property

    Private _MyStationID As String

    ''' <summary>
    ''' 工站
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MyStationID() As String
        Get
            Return _MyStationID
        End Get
        Set(ByVal value As String)
            _MyStationID = value
        End Set
    End Property



    ''' <summary>
    ''' 确定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        Try
            If String.IsNullOrEmpty(cmbStation.Text.Trim()) Then
                MessageUtils.ShowError("请选择新的工站!")
                Exit Sub
            ElseIf Me.MyStationID = cmbStation.SelectedValue.ToString() Then
                MessageUtils.ShowError("新旧工站不能相同!")
                Exit Sub
            End If
            Dim UserID = VbCommClass.VbCommClass.UseId
            Dim UserName = VbCommClass.VbCommClass.UseName
            Dim sql = String.Format("exec BOFToolListCopyStation '{0}',{1},'{2}',N'{3}','{4}',N'{5}','{6}',N'{7}'",
            Me.MyPartID, Me.MyOrderBy, Me.MyStationID, txtOldStationName.Text.Trim(),
            cmbStation.SelectedValue, cmbStation.Text, UserID, UserName)
            DbOperateUtils.ExecSQL(sql)
            Me.Close()
            MessageUtils.ShowInformation("复制成功!")
        Catch ex As Exception
            MessageUtils.ShowError("复制工站异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 取消
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class