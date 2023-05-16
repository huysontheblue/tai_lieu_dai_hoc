Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing

#Region "Old"
'Public Class FrmRunCardShowPicture
'    Sub New(ByVal imageFile As String)

'        ' 此调用是 Windows 窗体设计器所必需的。
'        InitializeComponent()

'        Me._imageFile = imageFile
'        ' 在 InitializeComponent() 调用之后添加任何初始化。

'    End Sub

'#Region "图象文件"
'    Private _imageFile As String
'    Private Property ImageFile() As String
'        Get
'            Return _imageFile
'        End Get
'        Set(ByVal value As String)
'            _imageFile = value
'        End Set
'    End Property

'    Private _image As Image
'    Private Property MyImage() As Image
'        Get
'            Return _image
'        End Get
'        Set(ByVal value As Image)
'            _image = value
'        End Set
'    End Property
'#End Region

'#Region "获得图象"
'    Private Function GetImage(ByVal imageFile As String) As Image
'        Return Image.FromFile(imageFile)
'    End Function

'#End Region

'    Private Sub FrmRunCardShowPicture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Try
'            PictureBox1.Image = Me.GetImage(Me.ImageFile)
'            Me.MyImage = PictureBox1.Image
'        Catch ex As Exception
'            SysMessageClass.WriteErrLog(ex, "FrmRunCardShowPicture", "FrmRunCardShowPicture_Load", "WIP")
'        End Try
'    End Sub

'    Private Sub 放大ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiZoomIn.Click
'        Try
'            'Dim grfx As Graphics = Me.CreateGraphics()
'            PictureBox1.Image = New Bitmap(Me.MyImage, Me.MyImage.Width * 2, Me.MyImage.Height * 2)
'            Me.MyImage = PictureBox1.Image

'        Catch ex As Exception
'            SysMessageClass.WriteErrLog(ex, "FrmRunCardShowPicture", "tsmiZoomIn_Click", "WIP")
'        End Try


'    End Sub

'    Private Sub tsmiZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiZoomOut.Click
'        Try
'            'Dim grfx As Graphics = Me.CreateGraphics()
'            PictureBox1.Image = New Bitmap(Me.MyImage, Me.MyImage.Width / 2, Me.MyImage.Height / 2)
'            Me.MyImage = PictureBox1.Image

'        Catch ex As Exception
'            SysMessageClass.WriteErrLog(ex, "FrmRunCardShowPicture", "tsmiZoomOut_Click", "WIP")
'        End Try
'    End Sub
'End Class
#End Region


Public Class FrmRunCardShowPicture
    Sub New(ByVal imageFile As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        Me._imageFile = imageFile
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

#Region "图象文件"
    Private _imageFile As String
    Private Property ImageFile() As String
        Get
            Return _imageFile
        End Get
        Set(ByVal value As String)
            _imageFile = value
        End Set
    End Property

    Private _image As Image
    Private Property MyImage() As Image
        Get
            Return _image
        End Get
        Set(ByVal value As Image)
            _image = value
        End Set
    End Property
#End Region

#Region "获得图象"
    Private Function GetImage(ByVal imageFile As String) As Image
        Return Image.FromFile(imageFile)
    End Function

#End Region

    Private Sub FrmRunCardShowPicture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PictureBox1.Image = Me.GetImage(Me.ImageFile)
            Me.MyImage = PictureBox1.Image
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardShowPicture", "FrmRunCardShowPicture_Load", "WIP")
        End Try
    End Sub

    Private Sub 放大ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiZoomIn.Click
        Try
            'Dim grfx As Graphics = Me.CreateGraphics()
            PictureBox1.Image = New Bitmap(Me.MyImage, Me.MyImage.Width * 2, Me.MyImage.Height * 2)
            Me.MyImage = PictureBox1.Image

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardShowPicture", "tsmiZoomIn_Click", "WIP")
        End Try
    End Sub

    Private Sub tsmiZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiZoomOut.Click
        Try
            'Dim grfx As Graphics = Me.CreateGraphics()
            PictureBox1.Image = New Bitmap(Me.MyImage, Me.MyImage.Width / 2, Me.MyImage.Height / 2)
            Me.MyImage = PictureBox1.Image

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardShowPicture", "tsmiZoomOut_Click", "WIP")
        End Try
    End Sub
End Class