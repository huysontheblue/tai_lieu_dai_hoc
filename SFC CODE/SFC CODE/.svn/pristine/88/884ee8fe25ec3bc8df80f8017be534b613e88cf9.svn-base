Imports MainFrame.SysDataHandle
Imports MainFrame


Public Class FrmPNList

    Private m_strTVPN As String = String.Empty
    Private m_strWirePN1 As String = String.Empty
    Private m_strWIrePN2 As String = String.Empty
    Private m_strWIrePN3 As String = String.Empty
    Private m_strWIrePN4 As String = String.Empty

    Public Sub New(ByVal strTVPN As String, ByVal strWirePN1 As String, _
                   ByVal strWirePN2 As String, ByVal strWirePN3 As String, ByVal strWirePN4 As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        m_strTVPN = strTVPN
        m_strWirePN1 = strWirePN1
        m_strWIrePN2 = strWirePN2
        m_strWIrePN3 = strWirePN3
        m_strWIrePN4 = strWirePN4
    End Sub

    Private Sub FrmPic_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim empPhotoUrl As String = String.Empty
        Dim o_strSQL As String = String.Empty
        Dim sConn As New SysDataBaseClass
        Try
            'Modify by cq 20171212 m_RCardDCheckItem_t ==> m_CutCardDCheckItem_t
            o_strSQL = " SELECT DISTINCT PARTID as 料件编号 " & _
                      "  FROM m_RCardDCheckItem_t" & _
                      "  WHERE lefttvpn = '" & m_strTVPN & "'" & _
                      "  AND leftwirepn1 ='" & m_strWirePN1 & "'" & _
                      "  AND isnull(leftwirepn2,'') ='" & m_strWIrePN2 & "'" & _
                      "  AND isnull(LeftWirePN3,'')='" & m_strWIrePN3 & "'" & _
                      "  AND isnull(LeftWirePN4,'')='" & m_strWIrePN4 & "' " & _
                      " UNION " & _
                    " SELECT DISTINCT PARTID as 料件编号 " & _
                      "  FROM m_RCardDCheckItem_t" & _
                      "  WHERE righttvpn = '" & m_strTVPN & "'" & _
                      "  AND rightwirepn1 ='" & m_strWirePN1 & "'" & _
                      "  AND isnull(rightwirepn2,'') ='" & m_strWIrePN2 & "'" & _
                      "  AND isnull(rightWirePN3,'')='" & m_strWIrePN3 & "'" & _
                      "  AND isnull(rightWirePN4,'')='" & m_strWIrePN4 & "' "
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