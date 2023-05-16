Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Resources
Imports System.Reflection
Public Class MultMessage

    Public Shared lang As String = "zh-chs"
    ''' <summary>  
    ''' 依据MsgId得到MsgText 
    ''' </summary>  
    ''' <param name="MsgId">信息编号</param>  
    ''' <param name="Lang">语言种类</param>  
    Public Shared Function GetMsg(ByVal MsgId As String)
        Try
            Dim str As String = Nothing
            Dim rsxr As ResXResourceReader
            Dim ds As DataSet = New DataSet()
            Dim dr As DataRow
            Dim i As Integer = 0
            Dim msgresx As String

            'add by song
            '2016-08-31
            Dim rm As ResourceManager = New ResourceManager("MultLanguage.Resource1", Assembly.GetExecutingAssembly())

            If lang = "zh-chs" Then
                msgresx = rm.GetObject("MultMessage_CHS")
            ElseIf lang = "zh-cht" Then
                msgresx = rm.GetObject("MultMessage_CHT")
            ElseIf lang = "en" Then
                msgresx = rm.GetObject("MultMessage_EN")
            ElseIf lang = "vt" Then
                msgresx = rm.GetObject("MultMessage_VT")
            End If

            Dim xml As New Xml.XmlDocument()
            xml.LoadXml(msgresx)

            Dim reader As Xml.XmlNodeReader = New Xml.XmlNodeReader(xml)
            ds.ReadXml(reader)
            reader.Close()

            For i = 0 To ds.Tables("data").Rows.Count - 1
                If ds.Tables("data").Rows(i)(0).ToString = MsgId Then
                    dr = ds.Tables("data").Rows(i)
                    Exit For
                End If
            Next
            If dr Is Nothing Then
                str = ""
            Else
                str = dr(1).ToString
            End If
            Return str
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>  
    ''' 显示信息文本  
    ''' </summary>add by song 2016-05-04 
    ''' <param name="MsgText">信息内容</param>  
    Public Shared Sub ShowText1(ByVal MsgText As String)
        Dim msg As New MultLanguage.MessageBox
        msg.SetText(MsgText)
        msg.ShowDialog()
    End Sub

    ''' <summary>  
    ''' 显示信息文本  
    ''' </summary>add by song 2016-05-04 
    ''' <param name="MsgId">信息编号</param>  
    Public Shared Sub ShowText(ByVal MsgId As String)
        Dim msg As New MultLanguage.MessageBox
        msg.SetText(GetMsg(MsgId))
        msg.ShowDialog()
    End Sub

    ''' <summary>  
    ''' 显示信息文本  
    ''' </summary>add by song 2016-05-04
    ''' <param name="MsgId">编号信息</param>
    ''' <param name="MsgId">对话框类型</param> 
    Public Shared Function ShowText1(ByVal MsgText As String, ByVal MsgType As String)
        Dim msg As New MultLanguage.MessageBox
        msg.SetText(MsgText, MsgType)
        Return msg.ShowDialog()
    End Function

    ''' <summary>  
    ''' 显示信息文本  
    ''' </summary>add by song 2016-05-04
    ''' <param name="MsgId">编号信息</param>
    ''' <param name="MsgId">对话框类型</param> 
    Public Shared Function ShowText(ByVal MsgId As String, ByVal MsgType As String)
        Dim msg As New MultLanguage.MessageBox
        msg.SetText(GetMsg(MsgId), MsgType)
        Return msg.ShowDialog()
    End Function

    ''' <summary>  
    ''' 显示信息文本  
    ''' </summary>add by song 2016-05-04
    ''' <param name="MsgId">编号信息</param>
    ''' <param name="MsgId">对话框类型</param> 
    ''' <param name="MsgId">图标类型</param> 
    Public Shared Function ShowText1(ByVal MsgText As String, ByVal MsgType As String, ByVal IconType As String)
        Dim msg As New MultLanguage.MessageBox
        msg.SetText(MsgText, MsgType, IconType)
        Return msg.ShowDialog()
    End Function

    ''' <summary>  
    ''' 显示信息文本  
    ''' </summary>add by song 2016-05-04
    ''' <param name="MsgId">编号信息</param>
    ''' <param name="MsgId">对话框类型</param> 
    ''' <param name="MsgId">图标类型</param> 
    Public Shared Function ShowText(ByVal MsgId As String, ByVal MsgType As String, ByVal IconType As String)
        Dim msg As New MultLanguage.MessageBox
        msg.SetText(GetMsg(MsgId), MsgType, IconType)
        Return msg.ShowDialog()
    End Function
End Class
