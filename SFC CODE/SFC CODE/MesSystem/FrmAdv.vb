Imports System.Data.SqlClient
Imports System.IO
Imports MainFrame
Imports MainFrame.SysCheckData
''' <summary>
''' 展示公告详情 2018/08/31
''' </summary>
''' <remarks></remarks>
Public Class FrmAdv


    Private Sub FrmAdv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetRichadv()  '展示公告详情
    End Sub

#Region "方法"
    '获取公告详情页面
    Private Sub GetRichadv()
        Dim strSQL As String = " select top 1 richText  from m_richAdv_t a left join m_Advert_t b on a.richID =b.id  where b.usey ='Y' "
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
                    Me.RichTextBoxEx1.LoadFile(mstream, RichTextBoxStreamType.RichText)
                End Using
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MesSystem.FrmAdv", "GetRichadv", "sys")
            Exit Sub
        End Try
    End Sub
#End Region
#Region "事件"
    'richtextbox失去焦点 不可编辑
    Private Declare Function HideCaret Lib "User32.dll" (ByVal hwnd As Long) As Boolean
    Private Sub RichTextBoxEx1_MouseDown(sender As Object, e As MouseEventArgs) Handles RichTextBoxEx1.MouseDown
        HideCaret(RichTextBoxEx1.Handle)
    End Sub
    Private Sub RichTextBoxEx1_MouseMove(sender As Object, e As MouseEventArgs) Handles RichTextBoxEx1.MouseMove
        HideCaret(RichTextBoxEx1.Handle)
    End Sub
    Private Sub RichTextBoxEx1_KeyUp(sender As Object, e As KeyEventArgs) Handles RichTextBoxEx1.KeyUp
        HideCaret(RichTextBoxEx1.Handle)
    End Sub

    '关闭当前窗体
    Private Sub labExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
#End Region 
End Class