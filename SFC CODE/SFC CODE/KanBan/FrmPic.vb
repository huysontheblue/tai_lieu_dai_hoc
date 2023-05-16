Public Class FrmPic

    Private m_strUserID As String = String.Empty


    Public Sub New(ByVal strUserID As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        m_strUserID = strUserID
    End Sub

    Private Sub FrmPic_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim empPhotoUrl As String = String.Empty
        Try
            Dim o_EmployeeWCF As New EmployeeWCF.EmployeeWCF()
            empPhotoUrl = o_EmployeeWCF.GetEmpPhoto(m_strUserID)
            o_EmployeeWCF.Dispose()

            PictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create(empPhotoUrl).GetResponse().GetResponseStream())
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class