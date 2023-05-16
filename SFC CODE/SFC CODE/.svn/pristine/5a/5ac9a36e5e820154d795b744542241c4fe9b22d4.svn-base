Imports System.Text
Imports MainFrame

Public Class FrmQcSnDetail

    Public cid As String


    Private Sub FrmQcSnDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSnDetail()
    End Sub

    Private Sub GetSnDetail()
        'Dim strSQL As String = " SELECT SN, Result, CreateUserId, CreateTime FROM m_QCCheckSnAllResult_t WHERE cid = '{0}' "
        Dim sb As New StringBuilder()
        sb.Append("SELECT a.SN ,b.Result ,d.TestitemName,f.SmallName ,")
        sb.Append(" B.NgCodeId ,c.CCName ,b.PicPath  FROM m_QCCheckSnAllResult_t a left join ")
        sb.Append(" m_QCCheckSnDetail_t b on b.CId=a.Cid  and a.SN=B.SN  left join  ")
        sb.Append(" M_CODE_T c on c.Codeid=b.NgCodeId LEFT JOIN ")
        sb.Append(" m_QCProducttestingM_t d on d.ID=b.BigTypeId LEFT JOIN ")
        sb.Append(" m_QCProducttestingMson_t f on  f.SmallID=b.SmallTypeId and f.large=d.ID ")
        sb.Append(" where  a.CId='" & cid & "' ")
        'strSQL = String.Format(strSQL, cid)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(sb.ToString)

        dgvCheckSN.DataSource = dt
    End Sub

    Private Sub dgvCheckSN_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCheckSN.CellClick
        If e.ColumnIndex > 0 And Me.dgvCheckSN.CurrentRow.Index > -1 Then
            Dim strPicPath As String
            strPicPath = Me.dgvCheckSN.CurrentRow.Cells("colPicPath").Value.ToString

          
            If Not String.IsNullOrEmpty(strPicPath) Then
                Dim img As New System.Drawing.Bitmap(Image.FromFile(strPicPath), Me.imgNg.Width, Me.imgNg.Height)

                Me.imgNg.Image = img
            Else
                Me.imgNg.Image = Nothing
            End If
        End If
    End Sub
#Region "Grid行数"
    Private Sub gridView_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvCheckSN.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

  

    Private Sub dgvCheckSN_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCheckSN.CellFormatting
        If e.ColumnIndex = 1 Then
            Dim _Result As String
            _Result = Me.dgvCheckSN.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
            If _Result = "PASS" Then
                e.CellStyle.ForeColor = Color.Green

            Else
                e.CellStyle.ForeColor = Color.Red

            End If
        End If
    End Sub
End Class