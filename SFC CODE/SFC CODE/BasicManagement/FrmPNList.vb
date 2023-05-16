Imports MainFrame.SysDataHandle
Imports MainFrame


Public Class FrmPNList

    Private m_strStationID As String = String.Empty

    Public Sub New(ByVal strStationID As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        m_strStationID = strStationID
    End Sub

    Private Sub FrmPic_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim o_strSQL As String = String.Empty
        Dim sConn As New SysDataBaseClass
        Try
            o_strSQL = " SELECT DISTINCT PARTID as 料件编号 " & _
                      "  FROM m_RCardD_t" & _
                      "  WHERE StationID = '" & m_strStationID & "'"
            Using o_dt As DataTable = sConn.GetDataTable(o_strSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.dgvPNList.DataSource = o_dt
                    Me.lblRecordCount.Text = CStr(o_dt.Rows.Count)
                Else
                    Me.dgvPNList.DataSource = Nothing
                End If
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        ExcelUtils.LoadDataToExcel(Me.dgvPNList, Me.Text)
    End Sub
End Class