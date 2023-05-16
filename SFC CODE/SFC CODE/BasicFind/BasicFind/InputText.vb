Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports System.Text

Public Class InputText
    Dim _text As MaskedTextBoxAdv
    Public Sub New(ByVal ObjText As MaskedTextBoxAdv)

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        _text = ObjText
        Dim str As New StringBuilder()
        If ObjText.Text.ToString().Trim() <> "" Then
            Dim strarry As String() = ObjText.Text.ToString().Trim().Split(";")
            For i = 0 To strarry.Length - 1
                str.Append(strarry(i).ToString().Trim())
                str.AppendLine()
            Next
        End If
        textBoxX1.Text = str.ToString()
    End Sub
    
    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim txt As String = ""
        If (textBoxX1.Text <> "") Then
            For i = 0 To textBoxX1.Lines.Length - 1
                If textBoxX1.Lines(i).ToString().Trim() <> "" Then
                    txt = txt + textBoxX1.Lines(i).ToString().Trim() + ";"
                End If
            Next
            txt = txt.Substring(0, txt.Length - 1)
        End If
        _text.Text = txt
        Me.Close()
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        Me.Close()
    End Sub
End Class