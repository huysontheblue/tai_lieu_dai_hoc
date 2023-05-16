Imports System.Drawing

Public Class CmbDatagridbiew
    Private data As New List(Of MyRect)
    Private Dgv As DataGridView

    Public Sub New(_dgv As DataGridView)
        Me.Dgv = _dgv
        AddHandler _dgv.CellPainting, AddressOf DGV_CellPainting
    End Sub

    Public Sub Add(_rect As MyRect)
        Me.data.Add(_rect)
        Me.SetCellEnabled(_rect)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_top">行索引左上</param>
    ''' <param name="_left">列索引左上</param>
    ''' <param name="_bottom">行索引右下</param>
    ''' <param name="_right">列索引右下</param>
    ''' <remarks></remarks>
    Public Sub Add(_top As Integer, _left As Integer, _bottom As Integer, _right As Integer)
        Me.data.Add(New MyRect(_top, _left, _bottom, _right))
    End Sub

    Private Sub SetCellEnabled(_rect As MyRect)
        For i = -_rect.Top To _rect.Bottom
            For j = _rect.Left To _rect.Right
                Me.Dgv.Rows(i).Cells(j).ReadOnly = True
            Next
        Next
    End Sub

    Private Function InRects(rowIndex As Integer, colIndex As Integer) As Integer
        For i = 0 To Me.data.Count - 1
            If Me.data(i).InRect(rowIndex, colIndex) Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub DGV_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        Using gridBush As SolidBrush = New SolidBrush(Me.Dgv.GridColor), backColorBrush As SolidBrush = New SolidBrush(e.CellStyle.BackColor)
            Using gridLinePen = New Pen(gridBush)
                If Me.data.Count = 0 Then
                    Return
                End If
                Dim index As Integer = Me.InRects(e.RowIndex, e.ColumnIndex)
                If index = -1 Then
                    Return
                End If
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds)
                If e.RowIndex = Me.data(index).Bottom Then
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left - 1, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Right - 1)
                End If
                If e.ColumnIndex = Me.data(index).Right Then
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                End If
                e.Handled = True
                For i = 0 To Me.data.Count - 1
                    Dim rect1 As Rectangle = Me.Dgv.GetCellDisplayRectangle(Me.data(i).Left, Me.data(i).Top, False)
                    Dim rect2 As Rectangle = Me.Dgv.GetCellDisplayRectangle(Me.data(i).Right, Me.data(i).Bottom, False)
                    Dim rect As Rectangle = New Rectangle(rect1.Left, rect1.Top, rect2.Right - rect1.Left, rect2.Bottom - rect1.Top)
                    Dim text As String
                    text = Me.Dgv.Rows(Me.data(i).Top).Cells(Me.data(i).Left).Value.ToString()
                    Try
                        Dim yy As Object = Me.Dgv.Rows(Me.data(i).Top).Cells(Me.data(i).Left + 1).Value.ToString()
                        If Not yy Is Nothing Then
                            text = text + " " + yy.ToString()
                        End If
                    Catch ex As Exception

                    End Try
                    Dim sz As SizeF = e.Graphics.MeasureString(text, e.CellStyle.Font)
                    e.Graphics.DrawString(text, e.CellStyle.Font, New SolidBrush(e.CellStyle.ForeColor), rect.Left + (rect.Width - sz.Width) / 2, rect.Top + (rect.Height - sz.Height) / 2, StringFormat.GenericDefault)
                Next
            End Using
        End Using
    End Sub
End Class

Public Class MyRect
    Public Top As Integer
    Public Right As Integer
    Public Bottom As Integer
    Public Left As Integer
    Public Sub New(_top As Integer, _left As Integer, _bottom As Integer, _right As Integer)
        Me.Top = _top
        Me.Right = _right
        Me.Bottom = _bottom
        Me.Left = _left
    End Sub

    Public Function InRect(rowIndex As Integer, colIndex As Integer) As Boolean
        If rowIndex >= Me.Top And rowIndex <= Me.Bottom And colIndex >= Me.Left And colIndex <= Me.Right Then
            Return True
        Else
            Return False
        End If
    End Function
End Class