Imports System.Windows.Forms

Public Class FrmLotReportRegister
    Public url As String = Nothing
    Private result As String = String.Empty

    Private Sub FrmLotReportRegister_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(url) Then
            WebBrowser1.ScriptErrorsSuppressed = True
            WebBrowser1.Navigate(url)
        End If
    End Sub


    'Add by cq 20150521
    '    private string result = null;
    'private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
    '        {
    '            if (((WebBrowser)sender).ReadyState == WebBrowserReadyState.Complete)
    '            {
    '                HtmlDocument htmlDoc = webBrowser1.Document;
    '                HtmlElement uxResult = htmlDoc.GetElementById("chapterID");
    '                result = Convert.ToString(uxResult.GetAttribute("value"));
    '                if (result == "success") this.Close();

    '            }
    '        }

    Private Sub webBrowser1_ProgressChanged(ByVal sender As Object, ByVal e As WebBrowserProgressChangedEventArgs) Handles WebBrowser1.ProgressChanged

        Dim htmlDoc As HtmlDocument = Nothing
        Dim uxResult As HtmlElement = Nothing
        If CType(sender, WebBrowser).ReadyState = WebBrowserReadyState.Complete Then

            htmlDoc = WebBrowser1.Document
            uxResult = htmlDoc.GetElementById("chapterID")
            result = Convert.ToString(uxResult.GetAttribute("value"))

            If result = "success" Then
                Me.Close()
            End If
        End If
    End Sub
End Class