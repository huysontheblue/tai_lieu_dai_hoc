Imports System.IO
Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmUploadFile

    Private _DuanZi As String
    ''' <summary>
    ''' 端子料号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DuanZi() As String
        Get
            Return _DuanZi
        End Get
        Set(ByVal value As String)
            _DuanZi = value
        End Set
    End Property

    Private _XianCai As String
    ''' <summary>
    ''' 线材料号
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property XianCai() As String
        Get
            Return _XianCai
        End Get
        Set(ByVal value As String)
            _XianCai = value
        End Set
    End Property

    Private _FilePathName As String
    ''' <summary>
    ''' 加工参数旧文件地址
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FilePathName() As String
        Get
            Return _FilePathName
        End Get
        Set(ByVal value As String)
            _FilePathName = value
        End Set
    End Property






    Private Sub FrmUploadFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ''' <summary>
    ''' 上传文件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnFileUpload_Click(sender As Object, e As EventArgs) Handles BtnFileUpload.Click
        Try
            Dim FileName As String = ""

            Dim FilePath As String = "\\192.168.20.123\RunCard\加工工艺参数维护\\" + DuanZi + "_" + XianCai + "\\"
            If String.IsNullOrEmpty(OpenFileDialog1.FileName) Then
                MessageUtils.ShowError("请选择要上传的文件")
                Exit Sub
            End If
            If Directory.Exists(FilePath) = False Then
                Directory.CreateDirectory(FilePath)
            End If
            FileName = OpenFileDialog1.FileName.Substring(OpenFileDialog1.FileName.LastIndexOf("\") + 1)
            If File.Exists(FilePath + FileName) Then
                File.Delete(FilePath + FileName)
            ElseIf File.Exists(FilePathName) Then
                File.Delete(FilePathName)
            End If
            Dim by As Byte() = File.ReadAllBytes(OpenFileDialog1.FileName)
            File.WriteAllBytes(FilePath + FileName, by)
            Dim sql = String.Format("update m_RCardProParam_t " & vbCrLf &
            "set FileName = N'{0}'," & vbCrLf &
            "FilePath = N'{1}'" & vbCrLf &
            "WHERE TVPN='{2}' AND WirePN='{3}'", FileName, FilePath + FileName, DuanZi, XianCai)
            DbOperateUtils.ExecSQL(sql)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageUtils.ShowError("上传资料异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub

    Private Sub BtnSelectFile_Click(sender As Object, e As EventArgs) Handles BtnSelectFile.Click
        OpenFileDialog1.ShowDialog()
        TxtPathFileName.Text = OpenFileDialog1.FileName
    End Sub
End Class