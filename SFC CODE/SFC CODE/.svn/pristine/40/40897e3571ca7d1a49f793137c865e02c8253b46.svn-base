Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.Windows.Forms
Imports System.IO


''' <summary>
''' 图片截取--共用图片截剪
''' 创建人：黄广都
''' 创建日期：2016-12-19
''' </summary>
''' <remarks></remarks>
Public Class FrmPictureCut


#Region "字段属性"
    'pictureBox控件的最大宽度
    Private Const AreaWidth As Integer = 512
    'pictureBox控件的最大高度
    Private Const AreaHeight As Integer = 384
    '矩形选框，用于截取图片
    Public m_Rect As Rectangle = Nothing
    '指定鼠标移动事件是否需要响应
    Private canMove As Boolean = False

    '初始化鼠标当前X坐标
    Private mouseLocationX As Integer = 0

    '初始化鼠标当前Y坐标
    Private mouseLocationY As Integer = 0
    '图片路径
    Private picPath As String = Nothing


#End Region

#Region "事件"
    Dim bmp As Bitmap = Nothing
    ''' <summary>
    ''' 图片载入按钮单击事件响应
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim openDlg As OpenFileDialog = New OpenFileDialog()
        openDlg.InitialDirectory = "."
        openDlg.Filter = "JPG File(*.jpg)|*.jpg|JPEG File(*.jpeg)|*.jpeg|PNG File(*.png)|*.png|BMP File(*.bmp)|*.bmp"
        openDlg.RestoreDirectory = True
        openDlg.FileName = "sourcePic"
        If (openDlg.ShowDialog() = DialogResult.OK) Then
            picPath = openDlg.FileName
            If (Not picPath Is Nothing AndAlso System.IO.File.Exists(picPath)) Then
                '  Dim bmp As Bitmap = New Bitmap(Image.FromFile(picPath))
                bmp = Image.FromFile(picPath)
                If bmp.Width > AreaWidth Then
                    picArea.Width = AreaWidth
                    picArea.Height = bmp.Height * AreaWidth / bmp.Width

                End If
                If bmp.Height > AreaHeight Then
                    picArea.Height = AreaHeight
                    picArea.Width = bmp.Width * AreaHeight / bmp.Height

                End If

                If bmp.Width <= picArea.Width Then
                    picArea.Width = bmp.Width
                End If

                If bmp.Height <= picArea.Height Then
                    picArea.Height = bmp.Height
                End If

                If picArea.Width < AreaWidth AndAlso picArea.Height < AreaHeight Then
                    maxPic.Checked = False
                End If
                '初始化矩形裁剪选框
                m_Rect = New Rectangle(0, 0, 0, 0)
                '初始化选框大小调整滑块
                track.Value = CInt(20 * 0.8)
                m_Rect.Width = CInt(picArea.Width * 0.8F)
                m_Rect.Height = CInt(picArea.Width * 0.8F)
                If m_Rect.Height > picArea.Height Then
                    '默认选取宽的高度、宽度
                    m_Rect.Height = 200
                    m_Rect.Width = 200
                End If

                Dim fs As FileStream = File.OpenRead(picPath)
                picArea.Image = Image.FromStream(fs)
                fs.Close()
                If picArea.Image Is Nothing Then
                    MessageBox.Show("图片上传失败！")
                End If

                '重绘pictureBox控件，触发paint事件
                picArea.Invalidate()
                bmp.Dispose()
            End If

        Else
            MessageBox.Show("未上传图片!")
        End If
    End Sub

    ''' <summary>
    ''' 保存截剪后的图片
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Me.m_Rect <> Nothing AndAlso Not picArea.Image Is Nothing Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' pictureBox控件重绘
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picArea_Paint(sender As Object, e As PaintEventArgs) Handles picArea.Paint
        Dim g As Graphics = e.Graphics
        If m_Rect <> Nothing Then
            Dim pen As Pen = New Pen(New SolidBrush(Color.White), 3)

            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            g.DrawRectangle(pen, Me.m_Rect)

        End If

    End Sub



    ''' <summary>
    ''' pictureBox内鼠标单击事件响应，保证鼠标在矩形选框内才可响应鼠标移动事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picArea_MouseDown(sender As Object, e As MouseEventArgs) Handles picArea.MouseDown
        Try
            Dim pt As Point
            pt = picArea.PointToClient(Control.MousePosition)


            If pt.X < m_Rect.X OrElse pt.X > m_Rect.X + m_Rect.Width OrElse pt.Y < m_Rect.Y OrElse pt.Y > m_Rect.Y + m_Rect.Height Then
                canMove = False
            Else
                canMove = True
                '更新当前鼠标X坐标 = true;
                mouseLocationX = pt.X
                '更新当前鼠标Y坐标
                mouseLocationY = pt.Y
            End If
        Catch ex As Exception
            Throw ex
        End Try



    End Sub

    ''' <summary>
    ''' 鼠标矩形选框内移动事件响应，保证矩形选框始终在pictureBox控件内部
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picArea_MouseMove(sender As Object, e As MouseEventArgs) Handles picArea.MouseMove

        If Me.m_Rect <> Nothing AndAlso Not picArea.Image Is Nothing Then
            If canMove = True Then
                '获取鼠标相对pictureBox控件的坐标
                Dim pt As Point
                pt = picArea.PointToClient(Control.MousePosition)


                m_Rect.X += pt.X - mouseLocationX
                m_Rect.Y += pt.Y - mouseLocationY

                mouseLocationX = pt.X
                mouseLocationY = pt.Y
                m_Rect.X = IIf(m_Rect.X < 0, 0, m_Rect.X)
                m_Rect.Y = IIf(m_Rect.Y < 0, 0, m_Rect.Y)
                m_Rect.X = IIf(m_Rect.X + m_Rect.Width > picArea.Width, picArea.Width - m_Rect.Width, m_Rect.X)
                m_Rect.Y = IIf(m_Rect.Y + m_Rect.Height > picArea.Height, picArea.Height - m_Rect.Height, m_Rect.Y)

                '重绘pictureBox控件
                picArea.Invalidate()
            End If
        End If

    End Sub




    ''' <summary>
    ''' 鼠标按键弹起事件响应，保证鼠标没有按键按下时无法响应鼠标移动事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picArea_MouseUp(sender As Object, e As MouseEventArgs) Handles picArea.MouseUp
        Me.canMove = False
    End Sub
    ''' <summary>
    ''' 保证pictureBox控件始终居中对齐
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub picArea_SizeChanged(sender As Object, e As EventArgs) Handles picArea.SizeChanged
        picArea.Left = panel.Left + panel.Width / 2 - picArea.Width / 2
        picArea.Top = panel.Top + panel.Height / 2 - picArea.Height / 2
    End Sub

    ''' <summary>
    ''' 使用滑块动态调整矩形选框大小
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub track_ValueChanged(sender As Object, e As EventArgs) Handles track.ValueChanged

        If Me.m_Rect <> Nothing AndAlso Not picArea.Image Is Nothing Then

            Dim ch As Double = CDbl(CDbl(track.Value) / 20.0F)
            If ((picArea.Width - m_Rect.Width) * 1.0F / (picArea.Height - m_Rect.Height) < 0.6) Then
                m_Rect.Width = CInt(picArea.Width * ch)
            Else
                m_Rect.Height = CInt(picArea.Height * ch)
                m_Rect.Width = CInt(picArea.Height * ch)
            End If
            If (m_Rect.X + m_Rect.Width > picArea.Width) Then
                m_Rect.X = picArea.Width - m_Rect.Width
            End If

            If (m_Rect.Y + m_Rect.Height > picArea.Height) Then
                m_Rect.Y = picArea.Height - m_Rect.Height
            End If
            picArea.Invalidate()
        End If
    End Sub

    ''' <summary>
    ''' 最大化图片和恢复图片原始尺寸显示方式的切换
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub maxPic_CheckedChanged(sender As Object, e As EventArgs) Handles maxPic.CheckedChanged
        If maxPic.Checked = True Then
            If picArea.Width < AreaWidth AndAlso picArea.Height < AreaHeight Then
                Dim tmp As Integer = picArea.Width
                picArea.Width = AreaWidth
                picArea.Height = picArea.Height * AreaWidth / tmp
                If picArea.Height > AreaHeight Then
                    tmp = picArea.Height
                    picArea.Height = AreaHeight
                    picArea.Width = picArea.Width * AreaHeight / tmp
                End If
                Dim ch As Double = CDbl(CDbl(track.Value) / 20.0F)
                If (picArea.Width - m_Rect.Width) * 1.0F / (picArea.Height - m_Rect.Height) < 0.6 Then

                    m_Rect.Width = CInt(picArea.Width * ch)
                    m_Rect.Height = m_Rect.Width * 800 / 480
                Else
                    m_Rect.Height = CInt(picArea.Height * ch)
                    m_Rect.Width = CInt(picArea.Width * ch)
                End If

                If m_Rect.X + m_Rect.Width > picArea.Width Then
                    m_Rect.X = picArea.Width - m_Rect.Width
                End If

                If m_Rect.Y + m_Rect.Height > picArea.Height Then
                    m_Rect.Y = picArea.Height - m_Rect.Height
                End If
            End If
        Else
            If picArea.Width = AreaWidth OrElse picArea.Height = AreaHeight Then
                Dim bmp As Bitmap = New Bitmap(Me.picArea.Image)
                If bmp.Width < AreaWidth AndAlso bmp.Height < AreaHeight Then

                    picArea.Width = bmp.Width
                    picArea.Height = bmp.Height
                End If
                m_Rect.Width = CInt(picArea.Width * CDbl(track.Value) / 20.0F)
                m_Rect.Height = m_Rect.Width * 800 / 480
                If m_Rect.Height > picArea.Height Then
                    m_Rect.Height = CInt(picArea.Height * CDbl(track.Value) / 20.0F)
                    m_Rect.Width = CInt(picArea.Height * CDbl(track.Value) / 20.0F)
                End If
                '保证矩形选框不越界
                If m_Rect.X + m_Rect.Width > picArea.Width Then
                    m_Rect.X = picArea.Width - m_Rect.Width
                End If

                If m_Rect.Y + m_Rect.Height > picArea.Height Then
                    m_Rect.Y = picArea.Height - m_Rect.Height
                End If
            End If
        End If


    End Sub
#End Region
#Region "方法"
    ''' <summary>
    ''' 图片裁剪方法
    ''' </summary>
    ''' <param name="b">需裁剪的图片位图</param>
    ''' <param name="StartX">裁剪起始X坐标</param>
    ''' <param name="StartY">裁剪起始Y坐标</param>
    ''' <param name="iWidth">裁剪宽度</param>
    ''' <param name="iHeight">裁剪高度</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function KiCut(ByVal b As Bitmap, ByVal StartX As Integer, ByVal StartY As Integer, ByVal iWidth As Integer, iHeight As Integer) As Bitmap


        Dim bmpOut As Bitmap = New Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb)

        Try

            If b Is Nothing Then
                Return Nothing
            End If
            Dim w As Integer = b.Width
            Dim h As Integer = b.Height

            If StartX >= w OrElse StartY >= h Then
                Return Nothing
            End If


            If StartX + iWidth > w Then
                iWidth = w - StartX
            End If


            If StartY + iHeight > h Then
                iHeight = h - StartY
            End If

            Dim g As Graphics = Graphics.FromImage(bmpOut)
            g.DrawImage(b, New Rectangle(0, 0, iWidth, iHeight), New Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel)
            g.Dispose()
        Catch ex As Exception
            Return Nothing
        End Try
        Return bmpOut
    End Function
#End Region
 
End Class