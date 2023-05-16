Imports MainFrame

Public Class FrmSampleDoc

    Private m_SampleNo As String

    Private Sub FrmSampleDoc_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Me.DesignMode = False Then
            InitLoad()
        End If
    End Sub

    Private Sub InitLoad()
        BindData()
    End Sub

    '邦定数据
    Private Sub BindData()
        Dim sql As String = ""
        sql = " SELECT SampleNO, type, Path  " & _
              " FROM m_SampleDocument_t " & _
              " WHERE  1=1 AND SampleNO = '" & m_SampleNo & "' "
        sql += " ORDER BY  a.Intime DESC"
        dgvDoc.Rows.Clear()
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            For Each row As DataRow In dt.Rows
                dgvDoc.Rows.Add(row("SampleNO").ToString(), row("type").ToString(), _
                                row("Path").ToString()
                                   )
            Next
            ' Me.lblRecordCount.Text = dt.Rows.Count
        End Using


        'strSQL = " SELECT SampleNO 样品单号,  type 文档类型, Path 文档路径 " & _
        '                 " FROM m_SampleDocument_t a  " & _
        '                 " WHERE 1 = 1 "

    End Sub

End Class