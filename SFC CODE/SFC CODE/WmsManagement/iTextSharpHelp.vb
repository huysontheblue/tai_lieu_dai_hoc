
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.io

Public Class iTextSharpHelp

    Public Shared Function CreateChineseFont(ByVal fontSize As Integer) As iTextSharp.text.Font
        StreamUtil.AddToResourceSearch("iTextAsian.dll")
        StreamUtil.AddToResourceSearch("iTextAsianCmaps.dll")
        Dim baseFT As BaseFont = BaseFont.CreateFont("STSong-Light", "UniGB-UCS2-H", BaseFont.EMBEDDED)
        Dim font As iTextSharp.text.Font = New iTextSharp.text.Font(baseFT)
        font.Size = fontSize
        Return font
    End Function
End Class
