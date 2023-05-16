Imports MainFrame

Public Class FrmHWPackCheckLog

    public m_strPackID As String = ""
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub



    Public Sub New(ByVal strPackID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        m_strPackID = strPackID
    End Sub

    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        ExcelUtils.LoadDataToExcel(Me.dgvPackCheckLog, Me.Text)
    End Sub

  

    Private Sub FrmHWPackCheckLog_Load(sender As Object, e As EventArgs) Handles Me.Load

        Call bindCheckListLog()

    End Sub

    Private Sub bindCheckListLog()
        Dim lssql As String = String.Empty

        lssql = " select PackID,PKG_ID, LX19Code, UserID,Intime from m_HWPackCheckLog_t where packid='" & m_strPackID & "' "

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                dgvPackCheckLog.DataSource = o_dt
            End If
        End Using
    End Sub
End Class