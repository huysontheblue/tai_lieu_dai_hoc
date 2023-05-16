Imports System.Reflection
Imports System.Resources
Imports MainFrame.SysCheckData

''' <summary>
''' 弹出窗体：图标选择窗口
''' </summary>
''' <remarks></remarks>
Public Class FrmSelectMenuImage

    Dim _imgName As String = ""                     '父窗体传递过来的图标名称值
    Dim _imglist As ImageList = New ImageList()     '图片列表
    Dim _imgSelect As Image                         '当前选中的图片

#Region "自定义方法"

    ''' <summary>
    ''' 从数据库表中，加载图片图片到ListView控件中
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowImageList_FromDatabase()
        Try
            Dim listImg As IList(Of String) = New List(Of String)
           
            '控件设置
            Me._imgSelect = Nothing
            Me._imglist.Images.Clear()
            Me.TxtImageName.Text = ""
            Me.TxtImageSize.Text = ""
            '
            Me.ListView1.Clear()
            Me.ListView1.View = View.LargeIcon
            Me.ListView1.LargeImageList = _imglist
            Me._imglist.ImageSize = New Size(32, 32)    '列表控件显示图片时的尺寸大小  

            '图片资源
            Dim sql As String = "SELECT FId,FImageName,FIsEnabled FROM m_LogtreeImage_t WHERE FIsEnabled=1 "
            Dim dt As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql)

            '加载图片列表
            If Not dt Is Nothing And dt.Rows.Count > 0 Then
                Dim imageName As String = ""
                Dim isEnabled As Boolean = False
                For Each dr As DataRow In dt.Rows
                    imageName = IIf(dr("FImageName") Is Nothing, "", dr("FImageName").ToString)
                    isEnabled = IIf(dr("FIsEnabled") Is Nothing, False, Convert.ToBoolean(dr("FIsEnabled").ToString))
                    '可用则加载
                    If String.IsNullOrEmpty(imageName) = False And isEnabled = True Then
                        listImg.Add(imageName)
                    End If
                Next
            End If

            '反射，取主程序
            Dim ay = Assembly.Load("MesSystem")
            Dim rm = New ResourceManager("MesSystem.Resources", ay)
            '将图片文件，逐个显示出来
            If listImg.Count > 0 Then
                Dim iIndex As Integer = 0   '图片列表的索引，防止生成图片时失败后索引错误
                For i As Integer = 0 To listImg.Count - 1
                    '取图片文件名
                    Dim imageNames As String = listImg(i)
                    Dim ImageObj As String = ""
                    If String.IsNullOrEmpty(imageNames) = False Then
                        If (imageNames.Contains(".")) Then
                            ImageObj = imageNames.Substring(0, imageNames.IndexOf("."))
                        End If
                    End If
                    '生成图片
                    Dim imgPhoto As System.Drawing.Image
                    Dim obj = rm.GetObject(ImageObj)
                    If Not obj Is Nothing Then
                        imgPhoto = CType(obj, Image)
                    Else
                        imgPhoto = Nothing
                        Continue For
                    End If

                    '图片放到ImageList控件中
                    Me._imglist.Images.Add(imgPhoto)
                    '加到ListView1中
                    Me.ListView1.Items.Add(imageNames, iIndex)    '文件名，第I个图片
                    '如果父窗体有传图标名称过来，则对应的选中
                    If String.IsNullOrEmpty(_imgName) = False Then
                        If imageNames = _imgName Then
                            Me._imgSelect = imgPhoto
                            Me.ListView1.Items(iIndex).Selected = True
                            Me.TxtImageName.Text = imageNames
                            Me.TxtImageSize.Text = imgPhoto.Width.ToString & "*" & imgPhoto.Height.ToString
                        End If
                    End If
                    iIndex = iIndex + 1
                Next
            Else
                MessageBox.Show("表m_LogtreeImage_t：未找到数据记录，请检查。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Catch ex As Exception
            MessageUtils.ShowError("显示图片列表时异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' 从指定的文件目录，加载图片显示到ListView控件中
    ''' 没有此路径，不能使用
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowImageList_FromFile()
        Try
            Dim listImgFile As IList(Of String) = New List(Of String)(3)
            Dim imgDir As String = Application.StartupPath + "\\Resources"

            '控件设置
            Me._imgSelect = Nothing
            Me._imglist.Images.Clear()
            Me.TxtImageName.Text = ""
            Me.TxtImageSize.Text = ""
            '
            Me.ListView1.Clear()
            Me.ListView1.View = View.LargeIcon
            Me.ListView1.LargeImageList = _imglist
            Me._imglist.ImageSize = New Size(32, 32)    '列表控件显示图片时的尺寸大小  

            '如果目录存在，则找出所有的文件(不找子目录)
            If IO.Directory.Exists(imgDir) = True Then
                For Each imgDir In System.IO.Directory.GetFiles(imgDir, "*.*", IO.SearchOption.TopDirectoryOnly)
                    If String.IsNullOrEmpty(imgDir) = False Then
                        '指定要的文件格式
                        If imgDir.Contains(".png") Or imgDir.Contains(".ico") Then
                            listImgFile.Add(imgDir)
                        End If
                    End If
                Next
            Else
                MessageBox.Show("存放图标的目录：" & imgDir & "不存在，请检查。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            '将图片文件，逐个显示出来
            If listImgFile.Count > 0 Then
                Dim iIndex As Integer = 0   '图片列表的索引，防止生成图片时失败后索引错误
                For i As Integer = 0 To listImgFile.Count - 1
                    '生成图片
                    Dim imgPhoto As System.Drawing.Image = System.Drawing.Image.FromFile(listImgFile(i))
                    If imgPhoto Is Nothing Then
                        Continue For
                    End If
                    '图片放到ImageList控件中
                    Me._imglist.Images.Add(imgPhoto)

                    '取图片文件名（去掉路径）
                    Dim listfile As IList(Of String) = New List(Of String)
                    Dim fileNames As String = ""
                    listfile = listImgFile(i).Split("\")
                    fileNames = listfile(listfile.Count - 1)

                    '加到ListView1中
                    Me.ListView1.Items.Add(fileNames, iIndex)    '文件名，第I个图片
                    '如果父窗体有传图标名称过来，则对应的选中
                    If String.IsNullOrEmpty(_imgName) = False Then
                        If fileNames = _imgName Then
                            Me._imgSelect = imgPhoto
                            Me.ListView1.Items(iIndex).Selected = True
                            Me.TxtImageName.Text = fileNames
                            Me.TxtImageSize.Text = imgPhoto.Width.ToString & "*" & imgPhoto.Height.ToString
                        End If
                    End If

                    '图片保存到数库
                    'Dim sql As String = "  IF NOT EXISTS (select FImageName from m_LogtreeImage_t where FImageName='" & fileNames & "')" &
                    '                    "     INSERT INTO m_LogtreeImage_t(FImageName)VALUES (N'" & fileNames & "')  "
                    'MainFrame.DbOperateUtils.ExecSQL(sql)
                    'MainFrame.SysCheckData.MessageUtils.ShowInformation("提交成功!")

                    iIndex = iIndex + 1
                Next
            Else
                MessageBox.Show("目录：" & imgDir & " 下，未找到.png格式的图标，请检查。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Catch ex As Exception
            MessageUtils.ShowError("显示图片列表时异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

#End Region

#Region "标准事件"

    ''' <summary>
    ''' 构造函数
    ''' </summary>
    ''' <param name="imgName">图标名称</param>
    ''' <remarks></remarks>
    Sub New(ByVal imgName As String)
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        _imgName = imgName
    End Sub

    ''' <summary>
    ''' 窗体默认加载事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmSelectMenuImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnRefresh.PerformClick()
    End Sub

    ''' <summary>
    ''' 标准事件：刷新按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        ShowImageList_FromDatabase()     '显示图片到ListView控件中
    End Sub

    ''' <summary>
    ''' 标准事件：选择列表中的项变化时
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If Me.ListView1.SelectedItems.Count > 0 Then
            Dim i As Integer = Me.ListView1.Items.IndexOf(Me.ListView1.FocusedItem) '首先获得选中项的索引
            If i >= 0 Then
                Me._imgSelect = Me._imglist.Images(i)
                Me.TxtImageName.Text = Me.ListView1.Items(i).SubItems(0).Text
                Me.TxtImageSize.Text = Me._imgSelect.Width.ToString + "*" + Me._imgSelect.Height.ToString
            End If
        End If
    End Sub

    ''' <summary>
    ''' 标准事件：退出按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    

    ''' <summary>
    ''' 标准事件：关闭按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 标准事件：确定按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnYes_Click(sender As Object, e As EventArgs) Handles BtnYes.Click
        Try
            If (Me.ListView1.Items.Count > 0) Then
                If String.IsNullOrEmpty(Me.TxtImageName.Text.Trim) = True Then
                    MessageBox.Show("请先选择一个图标", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            Else
                MessageBox.Show("没有可选择的图标", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            '给父窗口返回数据
            Dim frmParent As FrmSysMenu = Me.Owner
            frmParent.txtImageName.Text = Me.TxtImageName.Text.Trim
            frmParent.picBoxImageName.Image = Me._imgSelect
            Me.Close()
        Catch ex As Exception
            MessageUtils.ShowError("点击确定按钮时异常:" & vbCrLf & "" + ex.Message)
            Exit Sub
        End Try
    End Sub

#End Region

End Class
