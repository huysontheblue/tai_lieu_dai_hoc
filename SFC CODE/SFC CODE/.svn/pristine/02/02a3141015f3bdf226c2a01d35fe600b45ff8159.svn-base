Option Strict On
Option Explicit On
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Xml
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Text.RegularExpressions
Imports MainFrame
Imports SysBasicClass
''' <summary>
''' 修改者： 黄广都
''' 修改日： 2016/11/21
''' 修改内容：
''' -------------------修改记录---------------------
''' </summary>
''' <remarks>在线SOP单身编辑</remarks>
Public Class FrmOnlineSopDetailEdit


#Region "属性"
    '宽度
    Private _PicWidth As Integer = CInt(271)
    '高度
    Private _PicHeight As Integer = CInt(250)
    'SOP示意图存放目录
    'Private _PicDirector As String = "D:\OnlineSop\SOP" & "\" & VbCommClass.VbCommClass.Factory
    '----------------正式-------------------------
    Private _PicDirector As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\RunCard\OnlineSop\SOP" & "\" & VbCommClass.VbCommClass.Factory
    Private m_iniText1 As String = "" '步骤①
    Private m_iniText2 As String = ""
    Private m_iniText3 As String = ""
    Private m_iniText4 As String = ""
    Private m_iniText5 As String =""
    Private m_iniText6 As String = ""
    Private m_iniPartList As String = ""  '用料号+数量区分
    Private m_iniEquList As String = ""  '用编码+条件区分
    Private m_iniItems As String =""

#Region "最大页数"
    Private _MaxPage As Integer
    Public Property MaxPage() As Integer
        Get
            Return _MaxPage
        End Get

        Set(ByVal Value As Integer)
            _MaxPage = Value
        End Set
    End Property
#End Region

#Region "是否显示文控印章"
    Private _IsShowSeal As Boolean
    Public Property IsShowSeal() As Boolean
        Get
            Return _IsShowSeal
        End Get
        Set(ByVal Value As Boolean)
            _IsShowSeal = Value
        End Set
    End Property
#End Region

#Region "文件编码"
    Private _docID As String
    Public Property docID() As String
        Get
            Return _docID
        End Get

        Set(ByVal Value As String)
            _docID = Value
        End Set
    End Property
#End Region

#Region "SOP名称"
    Private _sopName As String
    Public Property sopName() As String
        Get
            Return _sopName
        End Get

        Set(ByVal Value As String)
            _sopName = Value
        End Set
    End Property
#End Region


#Region "产品料号"
    Private _PartID As String
    Public Property PartID() As String
        Get
            Return _PartID
        End Get

        Set(ByVal Value As String)
            _PartID = Value
        End Set
    End Property
#End Region
#Region "事件类型"
    Private _actionType As String
    Public Property actionType() As String
        Get
            Return _actionType
        End Get

        Set(ByVal Value As String)
            _actionType = Value
        End Set
    End Property
#End Region

#Region "主键ID"
    Private _Id As String
    Public Property Id() As String
        Get
            Return _Id
        End Get

        Set(ByVal Value As String)
            _Id = Value
        End Set
    End Property
#End Region

#End Region


#Region "构造函数"
    ''add by cq 20180803, add sopName
    'Sub New(ByVal actionType As String, ByVal docId As String, ByVal sopName As String, _
    '         ByVal partId As String, ByVal Id As String, Optional ByVal _IsSeal As Boolean = False)

    '    ' 此调用是 Windows 窗体设计器所必需的。
    '    InitializeComponent()
    '    Me._docID = docId
    '    Me._sopName = sopName
    '    Me._Id = Id
    '    Me._actionType = actionType
    '    Me._IsShowSeal = _IsSeal
    '    Me._PartID = partId
    'End Sub

    Sub New(ByVal actionType As String, ByVal docId As String, _
            ByVal partId As String, ByVal Id As String, Optional ByVal _IsSeal As Boolean = False, Optional sopName As String = "")

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me._docID = docId
        Me._sopName = sopName
        Me._Id = Id
        Me._actionType = actionType
        Me._IsShowSeal = _IsSeal
        Me._PartID = partId
    End Sub

#End Region

#Region "窗体事件"

    Private Sub FrmOnlineSopDetailEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case actionType
            '新增
            Case "Add"
                Me.txtPageSize.Text = CStr(GetNextPageSize())
                Me.txtVerNo.Text = "X1"
                Me.txtEcnNo.Text = "NEW"
                Me.txtPartId.Text = PartID
                Me.txtCreateUserId.Text = VbCommClass.VbCommClass.UseName
                Me.txtStationName.Focus()
                '默认选中
                Me.cbIsLF.Checked = True

                '设置页面权限
                SetControlsEnable()
                '修改\查看\分页查看
            Case Else
                Me._MaxPage = GetMaxPageSize()
                If Me.Id Is Nothing Then
                    ShowPageBindData(1)
                Else
                    BindData()
                End If
                txtVerNo.Enabled = False
                SetControlsEnable()
        End Select
    End Sub

    Private Sub btnUpdataOne_Click(sender As Object, e As EventArgs) Handles btnUpdataOne.Click
        Dim frmPicCut As New FrmPictureCut()

        If frmPicCut.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not frmPicCut.picArea.Image Is Nothing Then
                Dim map As Bitmap = New Bitmap(frmPicCut.picArea.Image)
                '通过比例换算裁剪图片保证裁剪结果的正确
                map = frmPicCut.KiCut(map, CInt(frmPicCut.m_Rect.X * map.Width / frmPicCut.picArea.Width), CInt(frmPicCut.m_Rect.Y * map.Height / frmPicCut.picArea.Height), CInt(map.Width * frmPicCut.m_Rect.Width / frmPicCut.picArea.Width), CInt(map.Height * frmPicCut.m_Rect.Height / frmPicCut.picArea.Height))
                If Not map Is Nothing Then
                    Me.PictureBoxOne.Image = Image.FromHbitmap(map.GetHbitmap())
                    Me.btnUpdataOne.Tag = "HaveImage"
                End If
                map.Dispose()
            End If
        End If
    End Sub

    Private Sub btnUpdataTwo_Click(sender As Object, e As EventArgs) Handles btnUpdataTwo.Click
        Dim frmPicCut As New FrmPictureCut()
        If frmPicCut.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not frmPicCut.picArea.Image Is Nothing Then
                Dim map As Bitmap = New Bitmap(frmPicCut.picArea.Image)
                '通过比例换算裁剪图片保证裁剪结果的正确
                map = frmPicCut.KiCut(map, CInt(frmPicCut.m_Rect.X * map.Width / frmPicCut.picArea.Width), CInt(frmPicCut.m_Rect.Y * map.Height / frmPicCut.picArea.Height), CInt(map.Width * frmPicCut.m_Rect.Width / frmPicCut.picArea.Width), CInt(map.Height * frmPicCut.m_Rect.Height / frmPicCut.picArea.Height))
                If Not map Is Nothing Then
                    Me.PictureBoxTwo.Image = Image.FromHbitmap(map.GetHbitmap())
                    Me.btnUpdataTwo.Tag = "HaveImage"
                End If
            End If
        End If
    End Sub

    Private Sub btnUpdataThr_Click(sender As Object, e As EventArgs) Handles btnUpdataThr.Click
        Dim frmPicCut As New FrmPictureCut()

        If frmPicCut.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not frmPicCut.picArea.Image Is Nothing Then
                Dim map As Bitmap = New Bitmap(frmPicCut.picArea.Image)
                '通过比例换算裁剪图片保证裁剪结果的正确
                map = frmPicCut.KiCut(map, CInt(frmPicCut.m_Rect.X * map.Width / frmPicCut.picArea.Width), CInt(frmPicCut.m_Rect.Y * map.Height / frmPicCut.picArea.Height), CInt(map.Width * frmPicCut.m_Rect.Width / frmPicCut.picArea.Width), CInt(map.Height * frmPicCut.m_Rect.Height / frmPicCut.picArea.Height))
                If Not map Is Nothing Then
                    Me.PictureBoxThree.Image = Image.FromHbitmap(map.GetHbitmap())

                    Me.btnUpdataThr.Tag = "HaveImage"
                End If
            End If
        End If
    End Sub

    Private Sub btnUpdataFour_Click(sender As Object, e As EventArgs) Handles btnUpdataFour.Click
        Dim frmPicCut As New FrmPictureCut()
        If frmPicCut.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not frmPicCut.picArea.Image Is Nothing Then
                Dim map As Bitmap = New Bitmap(frmPicCut.picArea.Image)
                '通过比例换算裁剪图片保证裁剪结果的正确
                map = frmPicCut.KiCut(map, CInt(frmPicCut.m_Rect.X * map.Width / frmPicCut.picArea.Width), CInt(frmPicCut.m_Rect.Y * map.Height / frmPicCut.picArea.Height), CInt(map.Width * frmPicCut.m_Rect.Width / frmPicCut.picArea.Width), CInt(map.Height * frmPicCut.m_Rect.Height / frmPicCut.picArea.Height))
                If Not map Is Nothing Then
                    Me.PictureBoxFour.Image = Image.FromHbitmap(map.GetHbitmap())
                    Me.btnUpdataFour.Tag = "HaveImage"
                End If
            End If
        End If
    End Sub

    Private Sub btnUpdataFive_Click(sender As Object, e As EventArgs) Handles btnUpdataFive.Click

        Dim frmPicCut As New FrmPictureCut()

        If frmPicCut.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not frmPicCut.picArea.Image Is Nothing Then
                Dim map As Bitmap = New Bitmap(frmPicCut.picArea.Image)
                '通过比例换算裁剪图片保证裁剪结果的正确
                map = frmPicCut.KiCut(map, CInt(frmPicCut.m_Rect.X * map.Width / frmPicCut.picArea.Width), CInt(frmPicCut.m_Rect.Y * map.Height / frmPicCut.picArea.Height), CInt(map.Width * frmPicCut.m_Rect.Width / frmPicCut.picArea.Width), CInt(map.Height * frmPicCut.m_Rect.Height / frmPicCut.picArea.Height))
                If Not map Is Nothing Then
                    Me.PictureBoxFive.Image = Image.FromHbitmap(map.GetHbitmap())
                    Me.btnUpdataFive.Tag = "HaveImage"
                End If
            End If
        End If
    End Sub

    Private Sub btnUpdataSix_Click(sender As Object, e As EventArgs) Handles btnUpdataSix.Click
        Dim frmPicCut As New FrmPictureCut()
        If frmPicCut.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not frmPicCut.picArea.Image Is Nothing Then
                Dim map As Bitmap = New Bitmap(frmPicCut.picArea.Image)
                '通过比例换算裁剪图片保证裁剪结果的正确
                map = frmPicCut.KiCut(map, CInt(frmPicCut.m_Rect.X * map.Width / frmPicCut.picArea.Width), CInt(frmPicCut.m_Rect.Y * map.Height / frmPicCut.picArea.Height), CInt(map.Width * frmPicCut.m_Rect.Width / frmPicCut.picArea.Width), CInt(map.Height * frmPicCut.m_Rect.Height / frmPicCut.picArea.Height))
                If Not map Is Nothing Then
                    Me.PictureBoxSix.Image = Image.FromHbitmap(map.GetHbitmap())
                    Me.btnUpdataSix.Tag = "HaveImage"
                End If
            End If
        End If
    End Sub

    Private Sub btnClearOne_Click(sender As Object, e As EventArgs) Handles btnClearOne.Click
        ClearPicture(Me.PictureBoxOne, Me.btnUpdataOne)
    End Sub

    Private Sub btnClearTwo_Click(sender As Object, e As EventArgs) Handles btnClearTwo.Click
        ClearPicture(Me.PictureBoxTwo, Me.btnUpdataTwo)
    End Sub

    Private Sub btnClearThr_Click(sender As Object, e As EventArgs) Handles btnClearThr.Click
        ClearPicture(Me.PictureBoxThree, Me.btnUpdataThr)
    End Sub

    Private Sub btnClearFou_Click(sender As Object, e As EventArgs) Handles btnClearFou.Click
        ClearPicture(Me.PictureBoxFour, Me.btnUpdataFour)
    End Sub

    Private Sub btnClearFive_Click(sender As Object, e As EventArgs) Handles btnClearFive.Click
        ClearPicture(Me.PictureBoxFive, Me.btnUpdataFive)
    End Sub

    Private Sub btnClearSix_Click(sender As Object, e As EventArgs) Handles btnClearSix.Click
        ClearPicture(Me.PictureBoxSix, Me.btnUpdataSix)
    End Sub
    ''' <summary>
    ''' 保存
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            Dim dr = MainFrame.SysCheckData.MessageUtils.ShowConfirm("是否保存?", MessageBoxButtons.OKCancel)
            If dr = Windows.Forms.DialogResult.OK Then

                If CheckInput() = True Then
                    If SaveData() Then
                        '新增
                        If actionType = "Add" Then
                            '不关闭窗口，清空内容，继续添加
                            ClearFormData()
                            Me.lblMsg.Text = "保存成功!"
                            Me.txtCreateUserId.Text = VbCommClass.VbCommClass.UseName
                            Me.txtPageSize.Text = CStr(GetNextPageSize())
                            Me.txtVerNo.Text = "X1"
                            Me.txtEcnNo.Text = "NEW"
                        Else
                            '退出
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopDetailEdit", "SaveData()", "sys")
        End Try

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' 使用物料添加行
    ''' </summary>
    Private Sub btnPartAdd_Click(sender As Object, e As EventArgs) Handles btnPartAdd.Click
        Try
            Dim frmMater As New FrmSelectMaterials(Me.txtPartId.Text.Trim)
            If frmMater.ShowDialog() = Windows.Forms.DialogResult.OK Then
                For Each row As DataGridViewRow In frmMater.dgvMaterial.Rows
                    If Not row.Cells(0).Value Is Nothing Then
                        If row.Cells(0).Value.ToString = "Y" Then
                            Me.dgvPart.Rows.Add(row.Cells(2).Value.ToString(), row.Cells(1).Value.ToString(), "", row.Cells(3).Value.ToString().Replace("'", ""))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopDetailEdit", "btnPartAdd_Click", "sys")
        End Try
    End Sub
    ''' <summary>
    ''' 设备、工治具添加行
    ''' </summary>
    Private Sub btnEquiAdd_Click(sender As Object, e As EventArgs) Handles btnEquiAdd.Click
        Try

            Dim frmEqui As New FrmSelectEquipment()
            If frmEqui.ShowDialog() = Windows.Forms.DialogResult.OK Then
                For Each row As DataGridViewRow In frmEqui.dgvEqui.Rows
                    If Not row.Cells(0).Value Is Nothing Then
                        If row.Cells(0).Value.ToString = "Y" Then
                            Me.dgvEquipment.Rows.Add(row.Cells(2).Value.ToString(), row.Cells(1).Value.ToString(), "")
                        End If
                    End If
                Next

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopDetailEdit", "btnEquiAdd_Click", "sys")
        End Try
    End Sub
    ''' <summary>
    ''' 使用物料减行
    ''' </summary>
    Private Sub btnPartMnuis_Click(sender As Object, e As EventArgs) Handles btnPartMnuis.Click
        Me.dgvPart.Rows.RemoveAt(Me.dgvPart.CurrentRow.Index)
        Me.dgvPart.EndEdit()
    End Sub
    ''' <summary>
    ''' 设备、工治具减行
    ''' </summary>
    Private Sub btnEquiMnuis_Click(sender As Object, e As EventArgs) Handles btnEquiMnuis.Click

        Me.dgvEquipment.Rows.RemoveAt(Me.dgvEquipment.CurrentRow.Index)
        Me.dgvEquipment.EndEdit()
    End Sub

    ''' <summary>
    ''' 上一页
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPreviousPage_Click(sender As Object, e As EventArgs) Handles btnPreviousPage.Click
        If String.IsNullOrEmpty(Me.txtPageSize.Text.Trim) Then Exit Sub
        Dim _Page As Integer = 1
        _Page = CInt(IIf(CInt(Me.txtPageSize.Text.Trim) > 1, CInt(CInt(Me.txtPageSize.Text.Trim) - 1), CInt(1)))
        ClearFormData()
        ShowPageBindData(_Page)
    End Sub
    ''' <summary>
    ''' 下一页
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnNextPage_Click(sender As Object, e As EventArgs) Handles btnNextPage.Click
        If String.IsNullOrEmpty(Me.txtPageSize.Text.Trim) Then Exit Sub
        Dim _Page As Integer = 1
        _Page = CInt(IIf(CInt(Me.txtPageSize.Text.Trim) < Me.MaxPage, CInt(CInt(Me.txtPageSize.Text.Trim) + 1), Me.MaxPage))
        ClearFormData()
        ShowPageBindData(_Page)
    End Sub
#End Region

#Region "自定义函数"
    ''' <summary>
    ''' 校验数据
    ''' </summary>
    Private Function CheckInput() As Boolean
        '产品料号
        If String.IsNullOrEmpty(Me.txtPartId.Text.Trim()) OrElse Me.txtPartId.Text.Trim() = "" Then
            Me.lblMsg.Text = "请输入产品料号!"
            Me.txtPartId.Focus()
            Return False
        End If

        '工站名称
        If String.IsNullOrEmpty(Me.txtStationName.Text.Trim()) OrElse Me.txtStationName.Text.Trim() = "" Then
            Me.lblMsg.Text = "请输入工站名称!"
            Me.txtStationName.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtPageSize.Text.Trim()) Then
            Me.lblMsg.Text = "请输入页次!"
            Me.txtPageSize.Focus()
            Return False
        End If

        If RegexNumber(Me.txtPageSize.Text.Trim) = False Then
            Me.lblMsg.Text = "页次必须是数字!"
            Me.txtPageSize.Focus()
            Return False
        End If
        '版次
        If String.IsNullOrEmpty(Me.txtVerNo.Text.Trim()) OrElse Me.txtVerNo.Text.Trim() = "" Then
            Me.lblMsg.Text = "请输入版次!"
            Me.txtVerNo.Focus()
            Return False
        End If

        If OnlineSopBusiness.CheckVersionItRight(Nothing, Me.txtVerNo.Text.Trim) = False Then
            Me.lblMsg.Text = "请版次格式输入有误!"
            Me.txtVerNo.Focus()
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' 保存数据
    ''' </summary>
    Private Function SaveData() As Boolean
        Dim r As Boolean = False
        Try
            Dim sb As New StringBuilder()
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim Falg As Integer = 0
            Dim Msg As String = "", PartXml As String = "", EquiXml As String = "", PicXml As String = String.Empty
            Dim picFileName As String = String.Empty
            Dim picOrderIndex As Integer = 1
            '图片地址
            Dim picPath As String = String.Empty
            '图片目录
            Dim picDirector As String = String.Empty
            picDirector = _PicDirector & "\" & docID
            If System.IO.Directory.Exists(picDirector) = False Then
                Directory.CreateDirectory(picDirector)
            End If

            '示意图
            If Not Me.btnUpdataOne.Tag.ToString = "NoIamge" Then
                picFileName = Now.ToString("yyyyMMddHHmmssffff") & ".jpg"
                picPath = picDirector & "\" & picFileName
                Dim picOne As New System.Drawing.Bitmap(PictureBoxOne.Image, _PicWidth, _PicHeight)
                picOne.SetResolution(96, 96)
                picOne.Save(picPath)
                PicXml &= "<rows OrdIndex=""1"" PicPath=""" & picPath & """/>"
            End If

            If Not Me.btnUpdataTwo.Tag.ToString = "NoIamge" Then
                picFileName = Now.ToString("yyyyMMddHHmmssffff") & ".jpg"
                picPath = picDirector & "\" & picFileName
                Dim picTwo As New System.Drawing.Bitmap(PictureBoxTwo.Image, _PicWidth, _PicHeight)
                picTwo.SetResolution(96, 96)
                picTwo.Save(picPath)
                PicXml &= "<rows OrdIndex=""2"" PicPath=""" & picPath & """ />"
            End If

            If Not Me.btnUpdataThr.Tag.ToString = "NoIamge" Then
                picFileName = Now.ToString("yyyyMMddHHmmssffff") & ".jpg"
                picPath = picDirector & "\" & picFileName
                Dim picTre As New System.Drawing.Bitmap(PictureBoxThree.Image, _PicWidth, _PicHeight)
                picTre.SetResolution(96, 96)
                'xDpi: System.Drawing.Bitmap 的水平分辨率，以每英寸的点数为单位。
                'yDpi: System.Drawing.Bitmap 的垂直分辨率，以每英寸的点数为单位。
                picTre.Save(picPath)
                PicXml &= "<rows OrdIndex=""3"" PicPath=""" & picPath & """ />"
            End If

            If Not Me.btnUpdataFour.Tag.ToString = "NoIamge" Then
                picFileName = Now.ToString("yyyyMMddHHmmssffff") & ".jpg"
                picPath = picDirector & "\" & picFileName
                Dim picFou As New System.Drawing.Bitmap(PictureBoxFour.Image, _PicWidth, _PicHeight)
                picFou.SetResolution(96, 96)
                picFou.Save(picPath)
                PicXml &= "<rows OrdIndex=""4"" PicPath=""" & picPath & """/>"
            End If
            If Not Me.btnUpdataFive.Tag.ToString = "NoIamge" Then
                picFileName = Now.ToString("yyyyMMddHHmmssffff") & ".jpg"
                picPath = picDirector & "\" & picFileName
                Dim picFive As New System.Drawing.Bitmap(PictureBoxFive.Image, _PicWidth, _PicHeight)
                picFive.SetResolution(96, 96)
                picFive.Save(picPath)
                PicXml &= "<rows OrdIndex=""5"" PicPath=""" & picPath & """ />"
            End If

            If Not Me.btnUpdataSix.Tag.ToString = "NoIamge" Then
                picFileName = Now.ToString("yyyyMMddHHmmssffff") & ".jpg"
                picPath = picDirector & "\" & picFileName
                Dim picSix As New System.Drawing.Bitmap(PictureBoxSix.Image, _PicWidth, _PicHeight)
                picSix.SetResolution(96, 96)
                picSix.Save(picPath)
                PicXml &= "<rows OrdIndex=""6"" PicPath=""" & picPath & """/>"
            End If

            Me.dgvPart.EndEdit()
            Me.dgvEquipment.EndEdit()
            '使用物料
            Dim _IsAddXml As Boolean = False
            Dim _TempString As String = "", _TempPartList As String = ""

            If Me.dgvPart.Rows.Count > 1 Then
                For index = 1 To Me.dgvPart.Rows.Count - 1
                    _IsAddXml = False
                    _TempString = ""
                    If Not Me.dgvPart.Rows(index - 1).Cells(1).Value Is Nothing Then
                        _TempString &= "<rows PartId=""" & OnlineSopBusiness.GetXmlCharHandle(Me.dgvPart.Rows(index - 1).Cells(1).Value.ToString)
                        _IsAddXml = True
                        _TempPartList &= OnlineSopBusiness.GetXmlCharHandle(Me.dgvPart.Rows(index - 1).Cells(1).Value.ToString) + ","
                    Else
                        _TempString &= "<rows PartId="""
                    End If
                    If Not Me.dgvPart.Rows(index - 1).Cells(0).Value Is Nothing Then
                        _TempString &= """  PartName=""" & System.Security.SecurityElement.Escape(Me.dgvPart.Rows(index - 1).Cells(0).Value.ToString)
                        '_TempString &= """  PartName=""" & OnlineSopBusiness.GetXmlCharHandle(Me.dgvPart.Rows(index - 1).Cells(0).Value.ToString)
                        '  string s = System.Security.SecurityElement.Escape(Me.dgvPart.Rows(index - 1).Cells(0).Value.ToString);
                        _IsAddXml = True
                    Else
                        _TempString &= """  PartName="""
                    End If
                    If Not Me.dgvPart.Rows(index - 1).Cells(2).Value Is Nothing Then
                        _TempString &= """  Amount=""" & OnlineSopBusiness.GetXmlCharHandle(Me.dgvPart.Rows(index - 1).Cells(2).Value.ToString)
                        _IsAddXml = True
                        _TempPartList &= OnlineSopBusiness.GetXmlCharHandle(Me.dgvPart.Rows(index - 1).Cells(2).Value.ToString) + "|"
                    Else
                        _TempString &= """  Amount="""
                        _TempPartList &= "0" + "|"
                    End If
                    If Not Me.dgvPart.Rows(index - 1).Cells(3).Value Is Nothing Then
                        _TempString &= """  Spec=""" & OnlineSopBusiness.GetXmlCharHandle(Me.dgvPart.Rows(index - 1).Cells(3).Value.ToString) & """/>"
                        _IsAddXml = True
                    Else
                        _TempString &= """  Spec=""""/>"
                    End If
                    If _IsAddXml = True Then
                        PartXml &= _TempString
                    End If
                Next
            End If

            If Not String.IsNullOrEmpty(_TempPartList) Then
                _TempPartList = _TempPartList.Substring(0, _TempPartList.Length - 1)
            End If

            Dim _TempEquList As String = ""
            If Me.dgvEquipment.Rows.Count > 1 Then
                For index = 1 To Me.dgvEquipment.Rows.Count - 1
                    _IsAddXml = False
                    _TempString = ""

                    If Not Me.dgvEquipment.Rows(index - 1).Cells(0).Value Is Nothing Then
                        _TempString &= "<rows EquiName=""" & OnlineSopBusiness.GetXmlCharHandle(Me.dgvEquipment.Rows(index - 1).Cells(0).Value.ToString)
                        _IsAddXml = True
                    Else
                        _TempString &= "<rows EquiName="""
                    End If
                    If Not Me.dgvEquipment.Rows(index - 1).Cells(1).Value Is Nothing Then
                        _TempString &= """  EquiNo=""" & OnlineSopBusiness.GetXmlCharHandle(Me.dgvEquipment.Rows(index - 1).Cells(1).Value.ToString)
                        _IsAddXml = True
                        _TempEquList &= OnlineSopBusiness.GetXmlCharHandle(Me.dgvEquipment.Rows(index - 1).Cells(1).Value.ToString) + ","
                    Else
                        _TempString &= """  EquiNo="""
                        _TempEquList &= "" + ","
                    End If
                    If Not Me.dgvEquipment.Rows(index - 1).Cells(2).Value Is Nothing Then
                        _TempString &= """  EquiDesc=""" & OnlineSopBusiness.GetXmlCharHandle(Me.dgvEquipment.Rows(index - 1).Cells(2).Value.ToString) & """/>"
                        _IsAddXml = True
                        _TempEquList &= OnlineSopBusiness.GetXmlCharHandle(Me.dgvEquipment.Rows(index - 1).Cells(2).Value.ToString) + "|"
                    Else
                        _TempString &= """  EquiDesc=""""/>"
                    End If
                    If _IsAddXml = True Then
                        EquiXml &= _TempString
                    End If
                Next
            End If

            If Not String.IsNullOrEmpty(_TempEquList) Then
                _TempEquList = _TempEquList.Substring(0, _TempEquList.Length - 1)
            End If

            Dim strOldModifyUserId As String = "", strOldModifyTime As String = ""
            Call GetOldInfo(Me.docID, Me.txtStationName.Text.Trim, strOldModifyUserId, strOldModifyTime)

                ''''''''''''''''分割线''''''''''''''''''
                '插入数据明细表
                Dim para(26) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@Id", SqlDbType.VarChar, 50),
                New SqlParameter("@DocId", SqlDbType.VarChar, 50),
                New SqlParameter("@PartId", SqlDbType.NVarChar, 50),
                New SqlParameter("@StationName", SqlDbType.NVarChar, 100),
                New SqlParameter("@EcnNo", SqlDbType.NVarChar, 50),
                New SqlParameter("@VerNo", SqlDbType.NVarChar, 50),
                New SqlParameter("@PageSize", SqlDbType.NVarChar, 50),
                New SqlParameter("@InsItems", SqlDbType.NVarChar, 500),
                New SqlParameter("@CreateUserId", SqlDbType.NVarChar, 50),
                New SqlParameter("@IsFinger", SqlDbType.Bit, 10),
                New SqlParameter("@IsAS", SqlDbType.Bit, 10),
                New SqlParameter("@IsLF", SqlDbType.Bit, 10),
                New SqlParameter("@IsHF", SqlDbType.Bit, 10),
                New SqlParameter("@IsOth", SqlDbType.Bit, 10),
                New SqlParameter("@IsFocusStation", SqlDbType.Bit, 10),
                New SqlParameter("@PicDescOne", SqlDbType.NVarChar, 500),
                New SqlParameter("@PicDescTwo", SqlDbType.NVarChar, 500),
                New SqlParameter("@PicDescThr", SqlDbType.NVarChar, 500),
                New SqlParameter("@PicDescFou", SqlDbType.NVarChar, 500),
                New SqlParameter("@PicDescFiv", SqlDbType.NVarChar, 500),
                New SqlParameter("@PicDescSix", SqlDbType.NVarChar, 500),
                New SqlParameter("@PartXml", SqlDbType.Xml, PartXml.Length),
                New SqlParameter("@EquiXml", SqlDbType.Xml, EquiXml.Length),
                New SqlParameter("@PicXml", SqlDbType.Xml, PicXml.Length),
                New SqlParameter("@Msg", SqlDbType.NVarChar, 100),
                New SqlParameter("@Falg", SqlDbType.Int, 20),
                New SqlParameter("@IsMask", IIf(cbIsMask.Checked, 1, 0)),
                New SqlParameter("@IsEarplugs", IIf(cbIsEarplugs.Checked, 1, 0)),
                New SqlParameter("@IsProtectiveGlasses", IIf(cbIsProtectiveGlasses.Checked, 1, 0)),
                New SqlParameter("@IsLeftHand", IIf(ChkIsLeftHand.Checked, 1, 0)),
                New SqlParameter("@IsRightHand", IIf(chkIsRightHand.Checked, 1, 0))
            }

                parameters(0).Value = Me.Id
                parameters(1).Value = Me.docID
                parameters(2).Value = Me.txtPartId.Text.Trim
                parameters(3).Value = Me.txtStationName.Text.Trim
                parameters(4).Value = Me.txtEcnNo.Text.Trim
                parameters(5).Value = Me.txtVerNo.Text.Trim
                parameters(6).Value = Me.txtPageSize.Text.Trim
                parameters(7).Value = Me.txtInsItems.Text.Trim
                parameters(8).Value = UserID
                'add by hgd 2017-04-28 加入手指套选择
            parameters(9).Value = IIf(Me.chkIsRightHand.Checked = True, 1, 0)
            parameters(10).Value = IIf(Me.cbIsAS.Checked = True, 1, 0)
            parameters(11).Value = IIf(Me.cbIsLF.Checked = True, 1, 0)
            parameters(12).Value = IIf(Me.cbIsHF.Checked = True, 1, 0)
            parameters(13).Value = IIf(Me.cbOth.Checked = True, 1, 0)
            parameters(14).Value = IIf(Me.cbIsFocusStation.Checked = True, 1, 0)
            parameters(15).Value = Me.txtOne.Text.Trim
            parameters(16).Value = Me.txtTwo.Text.Trim
            parameters(17).Value = Me.txtThree.Text.Trim
            parameters(18).Value = Me.txtFour.Text.Trim
            parameters(19).Value = Me.txtFive.Text.Trim
            parameters(20).Value = Me.txtSix.Text.Trim
            parameters(21).Value = PartXml
            parameters(22).Value = EquiXml
            parameters(23).Value = PicXml
            parameters(24).Value = Msg
            parameters(24).Direction = ParameterDirection.Output
            parameters(25).Value = Falg
            parameters(25).Direction = ParameterDirection.Output
            DbOperateUtils.ExecuteNonQureyByProc("Exec_OnlineSopSave", parameters)
            If parameters(25).Value.ToString = "0" Then
                MessageUtils.ShowError(parameters(24).Value.ToString)
                Return False
            End If

            'add by cq 
            If m_iniText1 <> Me.txtOne.Text.Trim Then
                ' GetOldInfo(Me.docID, Me.txtStationName.Text.Trim, strOldModifyUserId, strOldModifyTime)
                sb.Append("  INSERT INTO m_SOPChangeLog_t(DocID,[StationID],[TYPE] ")
                sb.Append(" ,[OldUserID],[OldModifyTime],[OldValue],[NewUserID],[NewModifyTime],NewValue,SOPName)")
                sb.Append(" VALUES( '" & Me.docID & "',N'" & Me.txtStationName.Text.Trim & "',N'步骤①','" & strOldModifyUserId & "','" & strOldModifyTime & "', N'" & m_iniText1 & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & Me.txtOne.Text.Trim & "','" & sopName & "' )")
            End If

            If m_iniText2 <> Me.txtTwo.Text.Trim Then
                sb.Append("  INSERT INTO m_SOPChangeLog_t(DocID,[StationID],[TYPE] ")
                sb.Append(" ,[OldUserID],[OldModifyTime],[OldValue],[NewUserID],[NewModifyTime],NewValue,SOPName)")
                sb.Append(" VALUES( '" & Me.docID & "',N'" & Me.txtStationName.Text.Trim & "',N'步骤②','" & strOldModifyUserId & "','" & strOldModifyTime & "', N'" & m_iniText2 & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & Me.txtTwo.Text.Trim & "','" & sopName & "' )")
            End If

            If m_iniText3 <> Me.txtThree.Text.Trim Then
                sb.Append("  INSERT INTO m_SOPChangeLog_t(DocID,[StationID],[TYPE] ")
                sb.Append(" ,[OldUserID],[OldModifyTime],[OldValue],[NewUserID],[NewModifyTime],NewValue,SOPName)")
                sb.Append(" VALUES( '" & Me.docID & "',N'" & Me.txtStationName.Text.Trim & "',N'步骤③','" & strOldModifyUserId & "','" & strOldModifyTime & "', N'" & m_iniText3 & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & Me.txtThree.Text.Trim & "','" & sopName & "' )")
            End If

            If m_iniText4 <> Me.txtFour.Text.Trim Then
                sb.Append("  INSERT INTO m_SOPChangeLog_t(DocID,[StationID],[TYPE] ")
                sb.Append(" ,[OldUserID],[OldModifyTime],[OldValue],[NewUserID],[NewModifyTime],NewValue,SOPName)")
                sb.Append(" VALUES( '" & Me.docID & "',N'" & Me.txtStationName.Text.Trim & "',N'步骤④','" & strOldModifyUserId & "','" & strOldModifyTime & "', N'" & m_iniText4 & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & Me.txtFour.Text.Trim & "','" & sopName & "')")
            End If

            If m_iniText5 <> Me.txtFive.Text.Trim Then
                sb.Append("  INSERT INTO m_SOPChangeLog_t(DocID,[StationID],[TYPE] ")
                sb.Append(" ,[OldUserID],[OldModifyTime],[OldValue],[NewUserID],[NewModifyTime],NewValue,SOPName)")
                sb.Append(" VALUES( '" & Me.docID & "',N'" & Me.txtStationName.Text.Trim & "',N'步骤⑤','" & strOldModifyUserId & "','" & strOldModifyTime & "', N'" & m_iniText5 & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & Me.txtFive.Text.Trim & "','" & sopName & "' )")
            End If

            If m_iniText6 <> Me.txtSix.Text.Trim Then
                sb.Append("  INSERT INTO m_SOPChangeLog_t(DocID,[StationID],[TYPE] ")
                sb.Append(" ,[OldUserID],[OldModifyTime],[OldValue],[NewUserID],[NewModifyTime],NewValue,SOPName)")
                sb.Append(" VALUES( '" & Me.docID & "',N'" & Me.txtStationName.Text.Trim & "',N'步骤⑥','" & strOldModifyUserId & "','" & strOldModifyTime & "', N'" & m_iniText6 & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & Me.txtSix.Text.Trim & "','" & sopName & "' )")
            End If

            If m_iniPartList <> _TempPartList Then
                sb.Append("  INSERT INTO m_SOPChangeLog_t(DocID,[StationID],[TYPE] ")
                sb.Append(" ,[OldUserID],[OldModifyTime],[OldValue],[NewUserID],[NewModifyTime],NewValue,SOPName)")
                sb.Append(" VALUES( '" & Me.docID & "',N'" & Me.txtStationName.Text.Trim & "',N'物料','" & strOldModifyUserId & "','" & strOldModifyTime & "', N'" & m_iniPartList & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & _TempPartList & "','" & sopName & "' )")
            End If

            If m_iniEquList <> _TempEquList Then
                sb.Append("  INSERT INTO m_SOPChangeLog_t(DocID,[StationID],[TYPE] ")
                sb.Append(" ,[OldUserID],[OldModifyTime],[OldValue],[NewUserID],[NewModifyTime],NewValue,SOPName)")
                sb.Append(" VALUES( '" & Me.docID & "',N'" & Me.txtStationName.Text & "',N'设备/治具','" & strOldModifyUserId & "','" & strOldModifyTime & "', N'" & m_iniEquList & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & _TempEquList & "','" & sopName & "' )")
            End If

            '注意事项
            If m_iniItems <> txtInsItems.Text.Trim Then
                sb.Append("  INSERT INTO m_SOPChangeLog_t(DocID,[StationID],[TYPE] ")
                sb.Append(" ,[OldUserID],[OldModifyTime],[OldValue],[NewUserID],[NewModifyTime],NewValue,SOPName)")
                sb.Append(" VALUES( '" & Me.docID & "',N'" & Me.txtStationName.Text.Trim & "',N'注意事项','" & strOldModifyUserId & "','" & strOldModifyTime & "', N'" & m_iniItems & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & txtInsItems.Text.Trim & "','" & sopName & "' )")
            End If

            If Not String.IsNullOrEmpty(sb.ToString) Then
                DbOperateUtils.ExecSQL(sb.ToString)
            End If

        Catch ex As Exception
            Me.lblMsg.Text = "保存时发生异常，请联系开发人员!"
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopDetailEdit", "SaveData()", "sys")
            Return False
        End Try
        Return True
    End Function

    Private Function GetOldInfo(ByVal DocID As String, ByVal stationName As String, _
                                 ByRef strModifyUserId As String, ByRef strModifyTime As String) As String
        Dim lsSQL As String = ""

        lsSQL = " SELECT  ModifyTime,ModifyUserId  FROM m_OnlineSopItem_t WHERE DocId ='" & DocID & "' AND StationName =N'" & stationName & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                strModifyUserId = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("ModifyUserId"))
                strModifyTime = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("ModifyTime"))
            End If
        End Using
    End Function

    ''' <summary>
    ''' 清空Form数据
    ''' </summary>
    Private Function ClearFormData() As Boolean
        Dim r As Boolean = False
        Try
            For Each contr As Control In Me.Panel3.Controls
                If (TypeOf contr Is System.Windows.Forms.TextBox) Then
                    If contr.Name <> "txtPartId" Then
                        contr.Text = ""
                    End If
                End If

                If (TypeOf contr Is System.Windows.Forms.RichTextBox) Then
                    contr.Text = ""
                End If

                If (TypeOf contr Is System.Windows.Forms.PictureBox) Then
                    If contr.Name <> "pbSeal" Then
                        CType(contr, PictureBox).Image = Global.RCard.My.Resources.Resources.noimage
                    End If
                End If

                If (TypeOf contr Is System.Windows.Forms.Button) Then
                    contr.Tag = "NoIamge"
                End If
            Next

            Me.dgvPart.Rows.Clear()
            Me.dgvEquipment.Rows.Clear()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopDetailEdit", "ClearFormData()", "sys")
        End Try
        Return True
    End Function

    ''' <summary>
    ''' 绑定数据
    ''' </summary>
    ''' <remarks></remarks>
    Sub BindData()
        Try
            Dim o_strSql As New StringBuilder
            Dim ds As DataSet
            Dim dt As New DataTable
            Dim dtPart As DataTable, dtEqui As DataTable, dtPic As DataTable
            m_iniPartList = "" : m_iniEquList = ""


            o_strSql.Append("SELECT A.Id,a.PartId,a.StationName,a.VerNo,a.EcnNo,a.PageSize,a.IsFinger,a.IsAS,a.IsLF,a.IsHF,a.IsOth,a.IsFocusStation,a.InsItems,isnull(a.IsMask,0) IsMask,isnull(a.IsEarplugs,0) IsEarplugs,isnull(a.IsProtectiveGlasses,0) IsProtectiveGlasses,IsLeftHand,IsRightHand,")
            o_strSql.Append(" a.Remark,c.UserName,b.VerifyUserName,b.ProdUserName,b.QCUserName,b.ApprovalUserName")
            o_strSql.Append(" FROM m_OnlineSopItem_t a  INNER JOIN m_OnlineSop_t b on b.DocId=a.DocId")
            o_strSql.Append(" LEFT JOIN m_Users_t c on c.UserID=b.CreateUserId   WHERE A.Id='" & Id & "';")
            o_strSql.Append(" SELECT PartName,PartId,Amount,Spec FROM m_OnlineSopPart_t WHERE PId='" & Id & "';")
            o_strSql.Append(" SELECT EquiName,EquiNo,EquiDesc FROM m_OnlineSopEquipment_t WHERE PId='" & Id & "';")
            o_strSql.Append(" SELECT OrdIndex,PicPath,PicDesc FROM m_OnlineSopPicture_t WHERE PId='" & Id & "' ORDER BY OrdIndex ASC;")
            ds = DbOperateUtils.GetDataSet(o_strSql.ToString)
            If Not ds Is Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                dt = ds.Tables(0)
                dtPart = ds.Tables(1)
                dtEqui = ds.Tables(2)
                dtPic = ds.Tables(3)
                Me.txtPartId.Text = dt.Rows(0)("PartId").ToString
                Me.txtStationName.Text = dt.Rows(0)("StationName").ToString
                Me.txtEcnNo.Text = dt.Rows(0)("EcnNo").ToString
                Me.txtVerNo.Text = dt.Rows(0)("VerNo").ToString
                Me.txtPageSize.Text = dt.Rows(0)("PageSize").ToString
                Me.txtInsItems.Text = dt.Rows(0)("InsItems").ToString
                m_iniItems = Me.txtInsItems.Text
                Me.txtCreateUserId.Text = dt.Rows(0)("UserName").ToString
                Me.txtVerifyUserName.Text = dt.Rows(0)("VerifyUserName").ToString
                Me.txtProdUserName.Text = dt.Rows(0)("ProdUserName").ToString
                Me.txtQCUserName.Text = dt.Rows(0)("QCUserName").ToString
                Me.txtApprovalUserName.Text = dt.Rows(0)("ApprovalUserName").ToString

                Me.cbIsAS.Checked = CBool(dt.Rows(0)("IsAS").ToString)
                Me.cbIsLF.Checked = CBool(dt.Rows(0)("IsLF").ToString)
                Me.cbIsHF.Checked = CBool(dt.Rows(0)("IsHF").ToString)
                Me.cbOth.Checked = CBool(dt.Rows(0)("IsOth").ToString)
                Me.cbIsFocusStation.Checked = CBool(dt.Rows(0)("IsFocusStation").ToString)

                'add by 马跃平 2018-08-27
                cbIsMask.Checked = CBool(dt.Rows(0)("IsMask").ToString())
                cbIsEarplugs.Checked = CBool(dt.Rows(0)("IsEarplugs").ToString())
                cbIsProtectiveGlasses.Checked = CBool(dt.Rows(0)("IsProtectiveGlasses").ToString())
                'add by 马跃平 2018-12-05
                Me.chkIsRightHand.Checked = CBool(dt.Rows(0)("IsRightHand").ToString())
                Me.ChkIsLeftHand.Checked = CBool(dt.Rows(0)("IsLeftHand").ToString())
                'IsAS,IsLF,IsHF,IsOth
                '绑定DataGridView

                For Each row As DataRow In dtPart.Rows
                    Me.dgvPart.Rows.Add(row("PartName").ToString(), row("PartId").ToString(), row("Amount").ToString(), row("Spec").ToString())
                    'PartID,Amount|
                    m_iniPartList &= row("PartId").ToString() & "," & row("Amount").ToString() + "|"
                Next

                If m_iniPartList.Length > 0 Then
                    m_iniPartList = m_iniPartList.Substring(0, m_iniPartList.Length - 1)
                End If

                For Each row As DataRow In dtEqui.Rows
                    Me.dgvEquipment.Rows.Add(row("EquiName").ToString(), row("EquiNo").ToString(), row("EquiDesc").ToString())
                    m_iniEquList &= row("EquiNo").ToString() & "," & row("EquiDesc").ToString() + "|"
                Next

                If m_iniEquList.Length > 0 Then
                    m_iniEquList = m_iniEquList.Substring(0, m_iniEquList.Length - 1)
                End If

                Dim img As Integer = 0
                '绑定示意图
                For index = 0 To dtPic.Rows.Count - 1
                    img = dtPic.Rows(index)("PicPath").ToString.Length
                    Select Case index
                        '新增
                        Case 0
                            If img > 0 Then
                                Me.PictureBoxOne.Image = Image.FromFile(dtPic.Rows(index)("PicPath").ToString)
                                Me.PictureBoxOne.ImageLocation = dtPic.Rows(index)("PicPath").ToString
                                Me.btnUpdataOne.Tag = "HaveImage"
                            End If
                            Me.txtOne.Text = dtPic.Rows(index)("PicDesc").ToString
                            m_iniText1 = Me.txtOne.Text
                        Case 1
                            If img > 0 Then
                                Me.PictureBoxTwo.Image = Image.FromFile(dtPic.Rows(index)("PicPath").ToString)
                                Me.PictureBoxTwo.ImageLocation = dtPic.Rows(index)("PicPath").ToString
                                Me.btnUpdataTwo.Tag = "HaveImage"
                            End If
                            Me.txtTwo.Text = dtPic.Rows(index)("PicDesc").ToString
                            m_iniText2 = Me.txtTwo.Text
                        Case 2
                            If img > 0 Then
                                Me.PictureBoxThree.Image = Image.FromFile(dtPic.Rows(index)("PicPath").ToString)
                                Me.PictureBoxThree.ImageLocation = dtPic.Rows(index)("PicPath").ToString
                                Me.btnUpdataThr.Tag = "HaveImage"
                            End If
                            Me.txtThree.Text = dtPic.Rows(index)("PicDesc").ToString
                            m_iniText3 = Me.txtThree.Text
                        Case 3
                            If img > 0 Then
                                Me.PictureBoxFour.Image = Image.FromFile(dtPic.Rows(index)("PicPath").ToString)
                                Me.PictureBoxFour.ImageLocation = dtPic.Rows(index)("PicPath").ToString
                                Me.btnUpdataFour.Tag = "HaveImage"
                            End If
                            Me.txtFour.Text = dtPic.Rows(index)("PicDesc").ToString
                            m_iniText4 = Me.txtFour.Text
                        Case 4
                            If img > 0 Then
                                Me.PictureBoxFive.Image = Image.FromFile(dtPic.Rows(index)("PicPath").ToString)
                                Me.PictureBoxFive.ImageLocation = dtPic.Rows(index)("PicPath").ToString
                                Me.btnUpdataFive.Tag = "HaveImage"
                            End If
                            Me.txtFive.Text = dtPic.Rows(index)("PicDesc").ToString
                            m_iniText5 = Me.txtFive.Text
                        Case 5
                            If img > 0 Then
                                Me.PictureBoxSix.Image = Image.FromFile(dtPic.Rows(index)("PicPath").ToString)
                                Me.PictureBoxSix.ImageLocation = dtPic.Rows(index)("PicPath").ToString
                                Me.btnUpdataSix.Tag = "HaveImage"
                            End If
                            Me.txtSix.Text = dtPic.Rows(index)("PicDesc").ToString
                            m_iniText6 = Me.txtSix.Text
                        Case Else
                            'do nothing
                    End Select

                Next
            End If


        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopDetailEdit", "BindData()", "sys")
        End Try
    End Sub

    Public Function DataTable2Xml(ByVal vTable As DataTable) As String
        If IsNothing(vTable) Then Return String.Empty
        Dim writer As StringWriter = New StringWriter()
        vTable.WriteXml(writer)
        Dim xmlstr As String = writer.ToString()
        writer.Close()
        Return xmlstr
    End Function



    ''' <summary>
    ''' 显示分页数据
    ''' </summary>
    ''' <param name="_PageSize">页次</param>
    ''' <remarks></remarks>
    Sub ShowPageBindData(ByVal _PageSize As Integer)
        Try
            Dim o_strSql As New StringBuilder
            Dim ds As DataSet
            Dim dt As New DataTable
            Dim dtPart As DataTable
            Dim dtEqui As DataTable
            Dim dtPic As DataTable
            o_strSql.Append("SELECT A.Id,a.PartId,a.StationName,a.VerNo,a.EcnNo,a.PageSize,IsFinger,IsAS,IsLF,IsHF,IsOth,IsFocusStation,a.InsItems,isnull(a.IsMask,0) IsMask,isnull(a.IsEarplugs,0) IsEarplugs,isnull(a.IsProtectiveGlasses,0) IsProtectiveGlasses,IsLeftHand,IsRightHand,")
            o_strSql.Append(" a.Remark,c.UserName,b.VerifyUserName,b.ProdUserName,b.QCUserName,b.ApprovalUserName")
            o_strSql.Append(" FROM m_OnlineSopItem_t a  INNER JOIN m_OnlineSop_t b on b.DocId=a.DocId")
            o_strSql.Append(" LEFT JOIN m_Users_t c on c.UserID=b.CreateUserId   WHERE a.DocId='" & docID & "' and a.PageSize='" & _PageSize & "';")
            o_strSql.Append(" SELECT a.PId,a.PartName,a.PartId,a.Amount,a.Spec FROM m_OnlineSopPart_t a inner join ")
            o_strSql.Append(" m_OnlineSopItem_t b on b.Id=a.PId where DocId ='" & docID & "' and PageSize=" & _PageSize & ";")
            o_strSql.Append(" SELECT a.EquiName,a.EquiNo,a.EquiDesc FROM m_OnlineSopEquipment_t a inner join ")
            o_strSql.Append(" m_OnlineSopItem_t b on b.Id=a.PId where DocId ='" & docID & "' and PageSize=" & _PageSize & ";")
            o_strSql.Append(" SELECT a.OrdIndex,a.PicPath,a.PicDesc FROM m_OnlineSopPicture_t a inner join ")
            o_strSql.Append(" m_OnlineSopItem_t b on b.Id=a.PId where DocId ='" & docID & "' and PageSize=" & _PageSize & " ORDER BY OrdIndex ASC; ")

            ds = DbOperateUtils.GetDataSet(o_strSql.ToString)
            If Not ds Is Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                dt = ds.Tables(0)
                dtPart = ds.Tables(1)
                dtEqui = ds.Tables(2)
                dtPic = ds.Tables(3)
                Me._Id = dt.Rows(0)("Id").ToString
                Me.txtPartId.Text = dt.Rows(0)("PartId").ToString
                Me.txtStationName.Text = dt.Rows(0)("StationName").ToString
                Me.txtEcnNo.Text = dt.Rows(0)("EcnNo").ToString
                Me.txtVerNo.Text = dt.Rows(0)("VerNo").ToString
                Me.txtPageSize.Text = dt.Rows(0)("PageSize").ToString

                Me.txtInsItems.Text = dt.Rows(0)("InsItems").ToString
                Me.txtCreateUserId.Text = dt.Rows(0)("UserName").ToString
                Me.txtVerifyUserName.Text = dt.Rows(0)("VerifyUserName").ToString
                Me.txtProdUserName.Text = dt.Rows(0)("ProdUserName").ToString
                Me.txtQCUserName.Text = dt.Rows(0)("QCUserName").ToString
                Me.txtApprovalUserName.Text = dt.Rows(0)("ApprovalUserName").ToString

                Me.chkIsRightHand.Checked = CBool(dt.Rows(0)("IsFinger").ToString)
                Me.cbIsAS.Checked = CBool(dt.Rows(0)("IsAS").ToString)
                Me.cbIsLF.Checked = CBool(dt.Rows(0)("IsLF").ToString)
                Me.cbIsHF.Checked = CBool(dt.Rows(0)("IsHF").ToString)
                Me.cbOth.Checked = CBool(dt.Rows(0)("IsOth").ToString)
                Me.cbIsFocusStation.Checked = CBool(dt.Rows(0)("IsFocusStation").ToString)


                'add by 马跃平 2018-11-08
                cbIsMask.Checked = CBool(dt.Rows(0)("IsMask").ToString())
                cbIsEarplugs.Checked = CBool(dt.Rows(0)("IsEarplugs").ToString())
                cbIsProtectiveGlasses.Checked = CBool(dt.Rows(0)("IsProtectiveGlasses").ToString())


                '绑定DataGridView
                For Each row As DataRow In dtPart.Rows
                    Me.dgvPart.Rows.Add(row("PartName").ToString(), row("PartId").ToString(), row("Amount").ToString(), row("Spec").ToString())
                Next

                For Each row As DataRow In dtEqui.Rows
                    Me.dgvEquipment.Rows.Add(row("EquiName").ToString(), row("EquiNo").ToString(), row("EquiDesc").ToString())
                Next

                Dim img As Integer = 0
                '绑定示意图
                For index = 0 To dtPic.Rows.Count - 1
                    img = dtPic.Rows(index)("PicPath").ToString.Length
                    Select Case index
                        '新增
                        Case 0
                            If img > 0 Then
                                Me.PictureBoxOne.Image = Image.FromFile(dtPic.Rows(index)("PicPath").ToString)
                                Me.PictureBoxOne.ImageLocation = dtPic.Rows(index)("PicPath").ToString
                                Me.btnUpdataOne.Tag = "HaveImage"
                            End If
                            Me.txtOne.Text = dtPic.Rows(index)("PicDesc").ToString
                        Case 1
                            If img > 0 Then
                                Me.PictureBoxTwo.Image = Image.FromFile(dtPic.Rows(index)("PicPath").ToString)
                                Me.PictureBoxTwo.ImageLocation = dtPic.Rows(index)("PicPath").ToString
                                Me.btnUpdataTwo.Tag = "HaveImage"
                            End If
                            Me.txtTwo.Text = dtPic.Rows(index)("PicDesc").ToString
                        Case 2
                            If img > 0 Then
                                Me.PictureBoxThree.Image = Image.FromFile(dtPic.Rows(index)("PicPath").ToString)
                                Me.PictureBoxThree.ImageLocation = dtPic.Rows(index)("PicPath").ToString

                                Me.btnUpdataThr.Tag = "HaveImage"
                            End If

                            Me.txtThree.Text = dtPic.Rows(index)("PicDesc").ToString
                        Case 3
                            If img > 0 Then
                                Me.PictureBoxFour.Image = Image.FromFile(dtPic.Rows(index)("PicPath").ToString)
                                Me.PictureBoxFour.ImageLocation = dtPic.Rows(index)("PicPath").ToString
                                Me.btnUpdataFour.Tag = "HaveImage"
                            End If
                            Me.txtFour.Text = dtPic.Rows(index)("PicDesc").ToString
                        Case 4
                            If img > 0 Then
                                Me.PictureBoxFive.Image = Image.FromFile(dtPic.Rows(index)("PicPath").ToString)
                                Me.PictureBoxFive.ImageLocation = dtPic.Rows(index)("PicPath").ToString
                                Me.btnUpdataFive.Tag = "HaveImage"
                            End If

                            Me.txtFive.Text = dtPic.Rows(index)("PicDesc").ToString
                        Case 5
                            If img > 0 Then
                                Me.PictureBoxSix.Image = Image.FromFile(dtPic.Rows(index)("PicPath").ToString)
                                Me.PictureBoxSix.ImageLocation = dtPic.Rows(index)("PicPath").ToString
                                Me.btnUpdataSix.Tag = "HaveImage"
                            End If

                            Me.txtSix.Text = dtPic.Rows(index)("PicDesc").ToString
                        Case Else
                    End Select
                Next
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopDetailEdit", "BindData()", "sys")
        End Try
    End Sub



    ''' <summary>
    ''' 获取下个页次
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNextPageSize() As Integer
        Dim r As Integer = 1
        Try
            Dim _RowAount As Integer = 0
            Dim strSql As String
            strSql = "select * from m_OnlineSopItem_t where DocId='" & docID & "'"
            _RowAount = DbOperateUtils.GetRowsCount(strSql)
            r = _RowAount + 1
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopDetailEdit", "BindData()", "sys")
        End Try
        Return r
    End Function

    ''' <summary>
    ''' 获取最大页码
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMaxPageSize() As Integer
        Dim r As Integer = 1
        Try
            Dim _RowAount As Integer = 1
            Dim strSql As String
            strSql = "select * from m_OnlineSopItem_t where DocId='" & docID & "'"
            _RowAount = DbOperateUtils.GetRowsCount(strSql)
            r = _RowAount
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineSopDetailEdit", "GetMaxPageSize()", "sys")
        End Try
        Return r
    End Function


    ''' <summary>
    ''' 校验是否是数字
    ''' </summary>
    ''' <param name="strNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RegexNumber(ByVal strNumber As String) As Boolean
        Dim reg_Barcode As Regex = New Regex("^[0-9]*$")
        If reg_Barcode.IsMatch(strNumber) = False Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' 清除图片
    ''' </summary>
    ''' <param name="pic"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ClearPicture(pic As System.Windows.Forms.PictureBox, but As System.Windows.Forms.Button) As Boolean
        CType(pic, PictureBox).Image = Global.RCard.My.Resources.Resources.noimage
        CType(but, System.Windows.Forms.Button).Tag = "NoIamge"
        Return True
    End Function


    ''' <summary>
    ''' 设置界面权限
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetControlsEnable()
        '查看
        If actionType = "View" Then
            Me.btnOK.Visible = False
            Me.btnUpdataOne.Visible = False
            Me.btnUpdataTwo.Visible = False
            Me.btnUpdataThr.Visible = False
            Me.btnUpdataFour.Visible = False
            Me.btnUpdataFive.Visible = False
            Me.btnUpdataSix.Visible = False

            Me.btnClearOne.Visible = False
            Me.btnClearTwo.Visible = False
            Me.btnClearThr.Visible = False
            Me.btnClearFou.Visible = False
            Me.btnClearFive.Visible = False
            Me.btnClearSix.Visible = False

            Me.btnPartAdd.Enabled = False
            Me.btnPartMnuis.Enabled = False
            Me.btnEquiAdd.Enabled = False
            Me.btnEquiMnuis.Enabled = False

            Me.dgvPart.ReadOnly = True
            Me.dgvEquipment.ReadOnly = True

            Me.btnCancel.Location = New Point(498, 9)
            Me.dgvPart.AllowUserToAddRows = False
            Me.dgvEquipment.AllowUserToAddRows = False

            Me.btnPreviousPage.Visible = True
            Me.btnNextPage.Visible = True
            Me.chkIsRightHand.Enabled = False
            Me.cbIsAS.Enabled = False
            Me.cbIsLF.Enabled = False
            Me.cbIsHF.Enabled = False
            Me.cbOth.Enabled = False
            Me.cbIsFocusStation.Enabled = False
            For Each contr As Control In Me.Panel3.Controls
                If (TypeOf contr Is System.Windows.Forms.TextBox) Then
                    If CType(contr, System.Windows.Forms.TextBox).Name <> "txtPartId" Then
                        CType(contr, System.Windows.Forms.TextBox).Enabled = False
                    End If
                End If
                If (TypeOf contr Is System.Windows.Forms.RichTextBox) Then
                    CType(contr, System.Windows.Forms.RichTextBox).ReadOnly = True
                End If

            Next
        ElseIf actionType = "Modify" Then
            Me.btnPreviousPage.Visible = True
            Me.btnNextPage.Visible = True
        Else
            Me.btnPreviousPage.Visible = False
            Me.btnNextPage.Visible = False
        End If
        '是否显示印章
        If Me.IsShowSeal = True Then
            Me.pbSeal.Visible = True
        End If
    End Sub
#End Region

End Class
