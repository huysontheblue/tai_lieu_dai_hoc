Public Class MessageBox

    Public Function SetText(ByVal MsgText As String)
        PictureBox_Error.Visible = False
        PictureBox_Info.Visible = True
        PictureBox_Warning.Visible = False
        Button_Ok.Visible = True
        Button_Ok.Left = Button_Cancel.Left
        Button_Cancel.Visible = False
        Button_Yes.Visible = False
        Button_No.Visible = False
        TextBox_Display.Text = MsgText
    End Function

    Public Function SetText(ByVal MsgText As String, ByVal MsgType As String)
        Select Case MsgType
            Case "OkCancel"
                PictureBox_Error.Visible = False
                PictureBox_Info.Visible = False
                PictureBox_Warning.Visible = True
                Button_Ok.Visible = True
                Button_Cancel.Visible = True
                Button_Yes.Visible = False
                Button_No.Visible = False
                TextBox_Display.Text = MsgText
            Case "YesNo"
                PictureBox_Error.Visible = False
                PictureBox_Info.Visible = True
                PictureBox_Warning.Visible = False
                Button_Ok.Visible = False
                Button_Cancel.Visible = False
                Button_Yes.Visible = True
                Button_No.Visible = True
                TextBox_Display.Text = MsgText
        End Select
    End Function

    Public Function SetText(ByVal MsgText As String, ByVal MsgType As String, ByVal IconType As String)
        PictureBox_Error.Visible = False
        PictureBox_Info.Visible = False
        PictureBox_Warning.Visible = True
        Select Case MsgType
            Case "OkCancel"
                Button_Ok.Visible = True
                Button_Cancel.Visible = True
                Button_Yes.Visible = False
                Button_No.Visible = False
                TextBox_Display.Text = MsgText
            Case "YesNo"
                Button_Ok.Visible = False
                Button_Cancel.Visible = False
                Button_Yes.Visible = True
                Button_No.Visible = True
                TextBox_Display.Text = MsgText
        End Select

        Select Case IconType
            Case "Error"
                PictureBox_Error.Visible = True
                PictureBox_Info.Visible = False
                PictureBox_Warning.Visible = False
            Case "Info"
                PictureBox_Error.Visible = False
                PictureBox_Info.Visible = True
                PictureBox_Warning.Visible = False
            Case "Warning"
                PictureBox_Error.Visible = False
                PictureBox_Info.Visible = False
                PictureBox_Warning.Visible = True
        End Select
    End Function

    Private Sub Button_Ok_Click(sender As Object, e As EventArgs) Handles Button_Ok.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Button_Yes_Click(sender As Object, e As EventArgs) Handles Button_Yes.Click
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub Button_No_Click(sender As Object, e As EventArgs) Handles Button_No.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub

    Private Sub MessageBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MultLanguage.Language.lang = "zh-chs" Then
            Me.Text = "提示信息"
            Button_Ok.Text = "确定"
            Button_Cancel.Text = "取消"
            Button_Yes.Text = "是"
            Button_No.Text = "否"
        ElseIf MultLanguage.Language.lang = "zh-cht" Then
            Me.Text = "提示信息"
            Button_Ok.Text = "確定"
            Button_Cancel.Text = "取消"
            Button_Yes.Text = "是"
            Button_No.Text = "否"
        ElseIf MultLanguage.Language.lang = "en" Then
            Me.Text = "Infomation"
            Button_Ok.Text = "Ok"
            Button_Cancel.Text = "Cancel"
            Button_Yes.Text = "Yes"
            Button_No.Text = "No"
        End If
    End Sub
End Class