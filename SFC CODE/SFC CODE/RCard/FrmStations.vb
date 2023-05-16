Public Class FrmStations

    ''' <summary>
    ''' 工站编号
    ''' </summary>
    ''' <remarks></remarks>
    Public _StationID As String

    ''' <summary>
    ''' 工站名称
    ''' </summary>
    ''' <remarks></remarks>
    Public _StationName As String

    ''' <summary>
    ''' 工站设备治具名称
    ''' </summary>
    ''' <remarks></remarks>
    Public _Equipment As String

    ''' <summary>
    ''' 提交
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtSubmit_Click(sender As Object, e As EventArgs) Handles BtSubmit.Click
        Try
            Me._StationID = cmbStationName.SelectedValue
            Me._StationName = cmbStationName.Text.Split("-")(0)
            Dim sql = "select Equipment from m_Rstation_t where Stationid='" & Me._StationID & "'"
            Dim dt = MainFrame.DbOperateUtils.GetDataTable(sql)
            If dt.Rows(0)(0).ToString() <> "手工" Then
                Me._Equipment = dt.Rows(0)(0).ToString()
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MainFrame.SysCheckData.MessageUtils.ShowError("提交失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub

#Region "绑定工站"
    ''' <summary>
    ''' 绑定工站
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataBindStation()
        Dim sql = "select a.Stationid,a.Stationname+'-'+b.SortName as Stationname " & vbCrLf &
        "from m_Rstation_t a" & vbCrLf &
        "Join" & vbCrLf &
        "(" & vbCrLf &
        "select * from m_Sortset_t where SortType = 'StationType' and Usey='Y'	" & vbCrLf &
        ")  b on b.SortID=a.Stationtype" & vbCrLf &
        "where a.Stationtype in('R','U','H') and a.usey='Y'"
        cmbStationName.DataSource = MainFrame.DbOperateUtils.GetDataTable(sql)
        cmbStationName.ValueMember = "Stationid"
        cmbStationName.DisplayMember = "Stationname"
        cmbStationName.SelectedIndex = -1
    End Sub
#End Region

    Private Sub FrmStations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataBindStation()
        cmbStationName.SelectedValue = Me._StationID
    End Sub
End Class