Imports MainFrame.SysDataHandle
Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmSampleDocHis
    Private m_strSampleNo As String = String.Empty
    Private m_strType As String = String.Empty

    Private Enum enumdgvDocList
        Type
        Path
        Intime
    End Enum
    Public Sub New(ByVal strSampleNo As String, ByVal strType As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        m_strSampleNo = strSampleNo
        m_strType = strType
    End Sub

    Private Sub FrmSampleDocHis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim o_strSQL As String = String.Empty
        Dim sConn As New SysDataBaseClass
        Try
            o_strSQL = " SELECT type,Path,intime,UserName" & _
                      "  FROM m_SampleDocumentHis_t" & _
                      "  WHERE SampleNo = '" & m_strSampleNo & "' " & _
                      "  AND  TYPE = N'" & m_strType & "' ORDER BY intime DESC"
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(o_strSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.dgvDocList.DataSource = o_dt
                Else
                    Me.dgvDocList.DataSource = Nothing
                End If
            End Using
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSampleDocHis", "FrmSampleDocHis_Load", "Sample")
            Throw ex
        End Try
    End Sub

    Private Sub dgvDocList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocList.CellContentClick
        If e.RowIndex = -1 OrElse Me.dgvDocList.Rows.Count <= 0 Then Exit Sub
        Dim o_strColumnName As String = String.Empty
        o_strColumnName = dgvDocList.CurrentCell.OwningColumn.Name
        Select Case o_strColumnName
            Case dgvDocList.Columns(enumdgvDocList.Path).Name
                System.Diagnostics.Process.Start(Me.dgvDocList.CurrentCell.Value.ToString)
            Case Else
                Exit Sub
        End Select
    End Sub
End Class