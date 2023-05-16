Imports MainFrame.SysDataHandle
Imports MainFrame


Public Class FrmMacList

    Private m_strReqID As String = String.Empty

    Public Sub New(ByVal strReqID As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        m_strReqID = strReqID

    End Sub

    Private Sub FrmPic_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim empPhotoUrl As String = String.Empty
        Dim o_strSQL As String = String.Empty
        Dim sConn As New SysDataBaseClass
        Try

            o_strSQL = " SELECT Mac MAC地址, PartID 料号 , Createtime 创建时间," & _
                       " (Case STATUS when 0 then '0.未使用' when 1 then '1.占用中' when 2 then '2.已使用' end )状态 , " & _
                       " usetime 被使用时间,Useby 使用人  FROM m_PartMacaddressD_t " & _
                       " WHERE RequestID='" & m_strReqID & "' "
            Using o_dt As DataTable = sConn.GetDataTable(o_strSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.dgvMACList.DataSource = o_dt
                    Me.lblRecordCount.Text = CStr(o_dt.Rows.Count)
                Else
                    Me.dgvMACList.DataSource = Nothing
                End If
            End Using

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        ExcelUtils.LoadDataToExcel(Me.dgvMACList, Me.Text)
    End Sub
End Class