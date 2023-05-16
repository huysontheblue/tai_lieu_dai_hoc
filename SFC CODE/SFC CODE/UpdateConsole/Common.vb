Imports System.IO
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.Threading

''' <summary>
''' 通用程序处理类
''' </summary>
''' <remarks></remarks>
Public Class Common
    ''' <summary>
    ''' 说明：获取文件的版本信息
    ''' 作者：陈忠阳
    ''' </summary>
    ''' <param name="filePath">文件路径</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFileVersion(ByRef filePath) As String
        Try
            Dim file As FileVersionInfo = FileVersionInfo.GetVersionInfo(filePath)
            Return file.FileVersion
        Catch ex As Exception
            Return ""
        End Try
    End Function
    ''' <summary>
    ''' 保存文件流到指定目录
    ''' </summary>
    ''' <param name="fileByte"></param>
    ''' <param name="destinationFilePath"></param>
    ''' <remarks></remarks>
    Public Shared Sub ByteSaveAsFile(ByRef fileByte As Byte(), ByRef destinationFilePath As String)
        Try
            ''Dim fs As New FileStream(destinationFilePath, FileMode.CreateNew, FileAccess.ReadWrite)
            Dim fs As FileStream = File.Create(destinationFilePath, fileByte.Length - 1)
            fs.Write(fileByte, 0, fileByte.Length - 1)
            fs.Close()
            fs.Dispose()
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' 文件版本大小比较
    ''' </summary>
    ''' <param name="minVersion"></param>
    ''' <param name="maxVersion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CompareFileVersion(ByVal minVersion, ByVal maxVersion) As Boolean
        Dim flagVersion As Boolean = False
        Try
            If Not String.IsNullOrEmpty(minVersion.ToString()) And Not String.IsNullOrEmpty(maxVersion.ToString()) Then
                minVersion = minVersion.ToString().Replace(".", "")
                maxVersion = maxVersion.ToString().Replace(".", "")
                If Convert.ToInt32(maxVersion) > Convert.ToInt32(minVersion) Then
                    flagVersion = True
                End If
            End If
        Catch ex As Exception
            flagVersion = False
        End Try
        Return flagVersion
    End Function
#Region "弹出自动关闭MessagBox窗口"
    Public Shared Sub AlertAotuCloseMeessageBox(ByRef msgContent As String, ByRef interval As Integer)
        Dim thParam As System.Threading.ParameterizedThreadStart = New Threading.ParameterizedThreadStart(AddressOf KillMessageBox)
        Dim thread As System.Threading.Thread = New Threading.Thread(thParam)
        thread.Start(interval)
        MessageBox.Show(msgContent, "提示")
    End Sub
    Private Shared Sub KillMessageBox(ByVal interval As Integer)
        System.Threading.Thread.Sleep(interval)
        Dim ptr As IntPtr = FindWindow(vbNullString, "提示")
        If ptr <> IntPtr.Zero Then
            PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero)
        End If
    End Sub
    Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long
    Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, lParam As IntPtr) As Long
    Public Const WM_CLOSE = &H10
    Public Shared Sub ClosePragramByName(ByRef name)
        Dim ptr As IntPtr = FindWindow(vbNullString, name)
        If ptr <> IntPtr.Zero Then
            PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero)
        End If
    End Sub
#End Region
#Region "注册表操作"
    Public Shared Sub InsertRegeditValue(ByRef keyName, ByRef keyValue)
        Dim regWrite As RegistryKey
        regWrite = Registry.LocalMachine.CreateSubKey("Software\\DGMesAutoUpdate\\" + keyName)
        regWrite.SetValue(keyName, keyValue)
        regWrite.Close()
    End Sub
    Public Shared Function ReadRegistValue(ByRef keyName) As String
        Dim regRead As RegistryKey
        regRead = Registry.LocalMachine.OpenSubKey("Software\\DGMesAutoUpdate\\" + keyName)
        If regRead Is Nothing Or IsDBNull(regRead) Then
            Return "0"
        Else
            Dim value As String = IIf(IsDBNull(regRead.GetValue(keyName)), "", regRead.GetValue(keyName).ToString())
            regRead.Close()
            Return value
        End If
    End Function
#End Region
#Region "WCF接口调用"
    Public Shared Function GetSystemAddress(ByRef FactoryId, ByRef ProfitCenter, ByRef UpdateType, ByRef rtValue, ByRef rtMsg) As String
        Dim mesService As New MesDataServices.MESDataServices()
        Return mesService.GetSystemAddress(FactoryId, ProfitCenter, UpdateType, rtValue, rtMsg)
    End Function
#End Region
End Class
