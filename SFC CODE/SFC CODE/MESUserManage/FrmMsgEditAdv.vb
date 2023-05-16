Imports System.Text
Imports System.IO
Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports MainFrame

''' <summary>
''' 公告详情 实现图文并茂
''' add by 关晓艳 2018/08/31
''' </summary>
''' <remarks></remarks>
Public Class FrmMsgEditAdv

    Public advMessage As String '公告标题及内容
    Public advId As Integer      '公告ID
    Dim title As String = "Untitled" '打开保存文件的标题
    Dim ec As Encoding = Encoding.UTF8 '设置文本格式为UTF-8
    Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass

    Private Sub FrmMsgEditAdv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFamily()   '获取系统字体
        Me.richTextBoxEx1.Text = advMessage   '显示公告标题和内容
        GetRichAdv() '显示当前公告信息详情
    End Sub

#Region "菜单事件"
    '打开
    Private Sub openToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles openToolStripMenuItem.Click
        'OpenFileDialog1 主要打开rtf格式的文件
        Try
            openFileDialog1.Filter = "文本文件|*.rtf"
            If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                title = openFileDialog1.FileName
                Me.Text = title  '显示打开的文件名
                richTextBoxEx1.ReadOnly = False
                Dim ext As String = title.Substring(title.LastIndexOf(".") + 1) '获取文件格式
                ext = ext.ToLower()
                Dim fs As FileStream = New FileStream(title, FileMode.Open, FileAccess.Read)
                Dim sr As StreamReader = New StreamReader(fs, ec)
                If ext = "rtf" Then     '如果后缀是 rtf 加载文件进来
                    richTextBoxEx1.LoadFile(title, RichTextBoxStreamType.RichText)
                Else
                    MessageBox.Show("请选择rtf格式文件！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'richTextBoxEx1.Text = sr.ReadToEnd
                End If
                fs.Close()
                sr.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub 
    '另存为
    Private Sub aSaveAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles aSaveAToolStripMenuItem.Click
        Try
            If saveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                title = saveFileDialog1.FileName
                Me.Text = title
                saveFileDialog1.Filter = "文本文件|*.rtf"

                If Path.GetExtension(saveFileDialog1.FileName).ToLower = ".rtf" Then
                    richTextBoxEx1.SaveFile(title, RichTextBoxStreamType.RichText)
                Else
                    MessageBox.Show("请将文件保存为rtf格式!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                richTextBoxEx1.ReadOnly = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    '退出
    Private Sub exitEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles exitEToolStripMenuItem.Click
        Me.Close()
    End Sub
    '剪切
    Private Sub XToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XToolStripMenuItem.Click
        richTextBoxEx1.Cut() '剪切
    End Sub
    '复制
    Private Sub VToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VToolStripMenuItem.Click
        richTextBoxEx1.Copy() '复制
    End Sub
    '粘贴
    Private Sub PToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PToolStripMenuItem.Click
        richTextBoxEx1.Paste()
    End Sub
    '插入图片
    Private Sub insertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles insertToolStripMenuItem.Click
        Try
            Dim o As OpenFileDialog = New OpenFileDialog
            o.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            o.Title = "请选择图片"
            ' o.Filter = "jpeg|*.jpeg|jpg|*.jpg|png|*.png|gif|*.gif"
            o.Filter = "图片|*.jpg;*.png;*.gif;*.jpeg;*.bmp"
            If o.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fileName = o.FileName
                Try
                    Dim bmp As Image = Image.FromFile(fileName)
                    Clipboard.SetDataObject(bmp)

                    Dim dataFormat As DataFormats.Format = DataFormats.GetFormat(DataFormats.Bitmap)
                    If richTextBoxEx1.CanPaste(dataFormat) Then
                        richTextBoxEx1.Paste(dataFormat)
                    End If
                Catch ex As Exception
                    MessageBox.Show("图片插入失败！" + ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End If
            Me.richTextBoxEx1.Focus()
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "导航栏事件"
    '加粗
    Private Sub boldToolStripButton1_Click(sender As Object, e As EventArgs) Handles boldToolStripButton1.Click, BoldToolStripMenuItem.Click
        '按一下加粗 再按一下不加粗
        If richTextBoxEx1.SelectionFont IsNot Nothing Then
            Dim currentFont As Font = richTextBoxEx1.SelectionFont
            Dim newFontStyle As FontStyle
            If richTextBoxEx1.SelectionFont.Bold Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Bold
            End If

            If richTextBoxEx1.SelectionFont.Italic Then
                newFontStyle = newFontStyle Or FontStyle.Italic
            End If

            If richTextBoxEx1.SelectionFont.Underline Then
                newFontStyle = newFontStyle Or FontStyle.Underline
            End If

            If richTextBoxEx1.SelectionFont.Strikeout Then
                newFontStyle = newFontStyle Or FontStyle.Strikeout
            End If

            richTextBoxEx1.SelectionFont = New Font( _
               currentFont.FontFamily, _
               currentFont.Size, _
               newFontStyle _
            )
        End If
    End Sub
    '倾斜
    Private Sub iToolStripButton2_Click(sender As Object, e As EventArgs) Handles iToolStripButton2.Click, ItalicToolStripMenuItem.Click
        ' richTextBoxEx1.SelectionFont = New Font(richTextBoxEx1.SelectionFont, richTextBoxEx1.SelectionFont.Style ^ FontStyle.Italic)
        If richTextBoxEx1.SelectionFont IsNot Nothing Then
            Dim currentFont As Font = richTextBoxEx1.SelectionFont
            Dim newFontStyle As FontStyle
            If richTextBoxEx1.SelectionFont.Italic Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Italic
            End If

            If richTextBoxEx1.SelectionFont.Bold Then
                newFontStyle = newFontStyle Or FontStyle.Bold
            End If

            If richTextBoxEx1.SelectionFont.Underline Then
                newFontStyle = newFontStyle Or FontStyle.Underline
            End If

            If richTextBoxEx1.SelectionFont.Strikeout Then
                newFontStyle = newFontStyle Or FontStyle.Strikeout
            End If

            richTextBoxEx1.SelectionFont = New Font( _
               currentFont.FontFamily, _
               currentFont.Size, _
               newFontStyle _
            )
        End If
    End Sub
    '加下划线
    Private Sub uToolStripButton3_Click(sender As Object, e As EventArgs) Handles uToolStripButton3.Click, UnderlineToolStripMenuItem.Click
        'richTextBoxEx1.SelectionFont = New Font(richTextBoxEx1.SelectionFont, richTextBoxEx1.SelectionFont.Style ^ FontStyle.Underline)
        If richTextBoxEx1.SelectionFont IsNot Nothing Then
            Dim currentFont As Font = richTextBoxEx1.SelectionFont
            Dim newFontStyle As FontStyle
            If richTextBoxEx1.SelectionFont.Underline Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Underline
            End If

            If richTextBoxEx1.SelectionFont.Italic Then
                newFontStyle = newFontStyle Or FontStyle.Italic
            End If

            If richTextBoxEx1.SelectionFont.Bold Then
                newFontStyle = newFontStyle Or FontStyle.Bold
            End If

            If richTextBoxEx1.SelectionFont.Strikeout Then
                newFontStyle = newFontStyle Or FontStyle.Strikeout
            End If


            richTextBoxEx1.SelectionFont = New Font( _
               currentFont.FontFamily, _
               currentFont.Size, _
               newFontStyle _
            )
        End If
    End Sub
    '删除线
    Private Sub strikeToolStripButton8_Click(sender As Object, e As EventArgs) Handles strikeToolStripButton8.Click
        If richTextBoxEx1.SelectionFont IsNot Nothing Then
            Dim currentFont As Font = richTextBoxEx1.SelectionFont
            Dim newFontStyle As FontStyle
            If richTextBoxEx1.SelectionFont.Strikeout Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Strikeout
            End If

            If richTextBoxEx1.SelectionFont.Italic Then
                newFontStyle = newFontStyle Or FontStyle.Italic
            End If

            If richTextBoxEx1.SelectionFont.Bold Then
                newFontStyle = newFontStyle Or FontStyle.Bold
            End If

            If richTextBoxEx1.SelectionFont.Underline Then
                newFontStyle = newFontStyle Or FontStyle.Underline
            End If

            richTextBoxEx1.SelectionFont = New Font( _
               currentFont.FontFamily, _
               currentFont.Size, _
               newFontStyle _
            )
        End If
    End Sub
    '插入图片
    Private Sub ipStripButton13_Click(sender As Object, e As EventArgs) Handles ipStripButton13.Click
        Dim bmp As Bitmap
        If openImageDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fileName As String = openImageDialog.FileName
            Try
                openImageDialog.Filter = "图片|*.jpg;*.png;*.gif;*.jpeg;*.bmp"
                bmp = New Bitmap(fileName)  '文件转化为Bitmap
                Clipboard.SetDataObject(bmp)
                Dim dft As DataFormats.Format = DataFormats.GetFormat(DataFormats.Bitmap)
                If Me.richTextBoxEx1.CanPaste(dft) Then
                    richTextBoxEx1.Paste(dft)  '图片加入到富文本中去
                End If
            Catch ex As Exception
                MessageBox.Show("图片插入失败" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub
    '字体颜色
    Private Sub colorToolStripButton4_Click(sender As Object, e As EventArgs) Handles colorToolStripButton4.Click, FontToolStripMenuItem.Click
        If colorDialog1.ShowDialog = DialogResult.OK Then
            richTextBoxEx1.SelectionColor = colorDialog1.Color '直接设置选中字段的颜色
        End If
    End Sub
    '撤销
    Private Sub undoToolStripButton2_Click(sender As Object, e As EventArgs) Handles undoToolStripButton2.Click
        richTextBoxEx1.Undo() '撤销
    End Sub
    '重做
    Private Sub redoToolStripButton1_Click(sender As Object, e As EventArgs) Handles redoToolStripButton1.Click
        richTextBoxEx1.Redo() '重做
    End Sub
    '左对齐
    Private Sub LeftToolStripButton7_Click(sender As Object, e As EventArgs) Handles LeftToolStripButton7.Click, 左对齐LToolStripMenuItem.Click
        Me.richTextBoxEx1.SelectionAlignment = HorizontalAlignment.Left
        Me.richTextBoxEx1.Focus()
    End Sub
    '居中
    Private Sub centerToolStripButton8_Click(sender As Object, e As EventArgs) Handles centerToolStripButton8.Click, 居中对齐CToolStripMenuItem.Click
        'Me.richTextBoxEx1.SelectionAlignment = HorizontalAlignment.Center
        If richTextBoxEx1.SelectionAlignment = HorizontalAlignment.Center Then
            Me.richTextBoxEx1.SelectionAlignment = HorizontalAlignment.Left
        Else
            Me.richTextBoxEx1.SelectionAlignment = HorizontalAlignment.Center
        End If
        richTextBoxEx1.Focus()
    End Sub
    '右对齐
    Private Sub rightToolStripButton9_Click(sender As Object, e As EventArgs) Handles rightToolStripButton9.Click, 右对齐RToolStripMenuItem.Click
        'Me.richTextBoxEx1.SelectionAlignment = HorizontalAlignment.Right
        If richTextBoxEx1.SelectionAlignment = HorizontalAlignment.Right Then
            Me.richTextBoxEx1.SelectionAlignment = HorizontalAlignment.Left
        Else
            Me.richTextBoxEx1.SelectionAlignment = HorizontalAlignment.Right
        End If
        Me.richTextBoxEx1.Focus()
    End Sub
    '字体变大
    Private Sub bigToolStripButton15_Click(sender As Object, e As EventArgs) Handles bigToolStripButton15.Click
        ZoomInout(False) '增加
    End Sub
    '字体变小
    Private Sub smallToolStripButton14_Click(sender As Object, e As EventArgs) Handles smallToolStripButton14.Click
        ZoomInout(True) '减小
    End Sub
    '设置字体样式
    Private Sub familyToolStripComboBoxName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles familyToolStripComboBoxName.SelectedIndexChanged
        If Me.familyToolStripComboBoxName.SelectedItem = Nothing Then
            Return
        End If
        Dim ss As String = Me.familyToolStripComboBoxName.SelectedItem.ToString.Trim
        richTextBoxEx1.SelectionFont = New Font(ss, richTextBoxEx1.SelectionFont.Size, richTextBoxEx1.SelectionFont.Style)
    End Sub
    '设置字体大小
    Private Sub fontSizeToolStripComboBoxSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles fontSizeToolStripComboBoxSize.SelectedIndexChanged
        Try
            If fontSizeToolStripComboBoxSize.SelectedItem = Nothing Then
                Return
            End If
            Dim size As Integer = Convert.ToInt32(Me.fontSizeToolStripComboBoxSize.SelectedItem.ToString.Trim)
            richTextBoxEx1.SelectionFont = New Font(Me.richTextBoxEx1.SelectionFont.FontFamily, size, richTextBoxEx1.SelectionFont.Style)
        Catch ex As Exception

        End Try
    End Sub
    '项目符号
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        If richTextBoxEx1.SelectionBullet Then
            richTextBoxEx1.SelectionBullet = False
        Else
            richTextBoxEx1.SelectionBullet = True
            richTextBoxEx1.BulletIndent = 10
        End If
        richTextBoxEx1.Focus()
    End Sub
    '保存   将richtext+图片保存至数据库
    Private Sub saveToolStripButton1_Click(sender As Object, e As EventArgs) Handles saveToolStripButton1.Click, saveSToolStripMenuItem.Click
        Try
            Dim ms As MemoryStream = New MemoryStream
            ms.Position = 0
            '把当前richtextbox内容包括图片和文本保存到流中
            richTextBoxEx1.SaveFile(ms, RichTextBoxStreamType.RichText)
            Dim buffer() As Byte = ms.GetBuffer
            Dim insertStr As String
            '如果存在就更新 不存在就插入
            Dim strSQL As String = "SELECT  1 FROM m_richAdv_t where RichID=" & advId
            Dim ds As DataSet = DbOperateUtils.GetDataSet(strSQL)

            Dim param(1) As SqlParameter
            param(0) = New SqlParameter("@advId", SqlDbType.Int)
            param(0).Value = advId
            param(1) = New SqlParameter("@blobData", SqlDbType.Image)
            param(1).Value = buffer

            If ds.Tables(0).Rows.Count > 0 Then
                insertStr = "update m_richAdv_t  set richText =@blobData,intime =GETDATE()  where richID =@advId"
            Else
                insertStr = "insert into mesdb.dbo.m_richAdv_t(RichID,RichText) values(@advId,@blobData)"
            End If

            conn.ExecSql(insertStr, param)
            MessageBox.Show("保存成功")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        richTextBoxEx1.Clear()
    End Sub
    '查看
    Private Sub seeToolStripButton1_Click(sender As Object, e As EventArgs) Handles seeToolStripButton1.Click
        GetRichAdv()
    End Sub
    '文本背景颜色
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click, ColorToolStripMenuItem.Click
        Dim f As ColorDialog = New ColorDialog
        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            richTextBoxEx1.SelectionBackColor = f.Color
        End If
        richTextBoxEx1.Focus()
    End Sub
    '减少缩进量
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        '每次以10个像素进行缩进
        richTextBoxEx1.SelectionIndent = richTextBoxEx1.SelectionIndent - 10
        richTextBoxEx1.Focus()
    End Sub
    '增加缩进量
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        '每次以10个像素进行缩进
        richTextBoxEx1.SelectionIndent = richTextBoxEx1.SelectionIndent + 10
        richTextBoxEx1.Focus()
    End Sub
    '下标
    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If richTextBoxEx1.SelectionCharOffset < 0 Then
            richTextBoxEx1.SelectionCharOffset = 0
        Else
            richTextBoxEx1.SelectionCharOffset = -5
        End If
        richTextBoxEx1.Focus()
    End Sub
    '上标
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If richTextBoxEx1.SelectionCharOffset > 0 Then
            richTextBoxEx1.SelectionCharOffset = 0
        Else
            richTextBoxEx1.SelectionCharOffset = 5
        End If
        richTextBoxEx1.Focus()
    End Sub
    '清空richtextbox
    Private Sub ClearToolStripButton6_Click(sender As Object, e As EventArgs) Handles ClearToolStripButton6.Click
        richTextBoxEx1.Clear()
        richTextBoxEx1.Focus()
    End Sub
#End Region

#Region "方法"
    ''' <summary>
    ''' 控制字体变大或变小
    ''' </summary>
    ''' <param name="isZoomOut"></param>
    ''' <remarks></remarks>
    Private Sub ZoomInout(ByVal isZoomOut As Boolean)
        Dim zoom As Single = 0
        zoom = Me.richTextBoxEx1.ZoomFactor
        If isZoomOut Then
            zoom -= Convert.ToSingle(0.1)
        Else
            zoom += Convert.ToSingle(0.1)
        End If
        If zoom < 0.64 OrElse zoom > 64 Then
            Return
        End If
        Me.richTextBoxEx1.ZoomFactor = zoom
    End Sub

    ''' <summary>
    ''' 获取公告详情
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetRichAdv()
        Dim strSQL As String = "SELECT  RichText FROM m_richAdv_t where RichID=" & advId
        Try
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count <= 0 Then
                Return
            End If
            '从数据库读取至richtext
            Dim bWrite() As Byte = dt.Rows(0)("RichText")
            Dim bwLength As Integer = UBound(bWrite) - LBound(bWrite) + 1
            If bwLength > 0 Then
                Using mstream As MemoryStream = New MemoryStream()
                    mstream.Write(bWrite, 0, bwLength)
                    mstream.Position = 0
                    '将stream填充到richtextbox
                    Me.richTextBoxEx1.LoadFile(mstream, RichTextBoxStreamType.RichText)
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 获取系统字体
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetFamily()
        Dim arrStrNames As List(Of String) = New List(Of String)()
        Dim myFont As InstalledFontCollection = New InstalledFontCollection
        Dim fontFamilys() As FontFamily = myFont.Families
        If fontFamilys Is Nothing OrElse fontFamilys.Length < 1 Then
            Return
        Else
            For Each item As FontFamily In fontFamilys
                familyToolStripComboBoxName.Items.Add(item.Name)
                familyToolStripComboBoxName.SelectedIndex = familyToolStripComboBoxName.Items.IndexOf("宋体")
                '设置默认字体大小
                fontSizeToolStripComboBoxSize.SelectedIndex = fontSizeToolStripComboBoxSize.Items.IndexOf("16")
            Next
        End If
    End Sub
#End Region
End Class