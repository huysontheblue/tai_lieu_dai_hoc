Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Text
Imports iTextSharp.awt.geom.Point2D

Public Class PDFCommon


    Private Shared Function CreateChineseFont()
        Return BaseFont.CreateFont("C:\Windows\Fonts\SIMHEI.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
    End Function

    Public Shared NgDate As String  '不良日期
    Public Shared PartId As String  '料号
    Public Shared LineId As String  '线别
    Public Shared ProductLabel As String '产品标签
    Public Shared Qty As String     '数量
    Public Shared Status As String  '状态
    Public Shared UserName As String '用户名

    '生成PDF
    Public Shared Sub CreatePdf(pdfPath As String, imagePath As String, dtQty As DataTable, dtReason As DataTable)

        Dim document As Document = New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 2.0F)

        Try
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(pdfPath, FileMode.Create))

            document.Open()

            Dim bsFont As BaseFont = CreateChineseFont()

            Dim tittleFont As Font = New Font(bsFont, 16.0F, Font.BOLD)  '
            Dim contentFontBold As Font = New Font(bsFont, 10.0F, Font.BOLD) '
            Dim contentFont As Font = New Font(bsFont, 9.0F) '

            Dim tittle As iTextSharp.text.Paragraph = New Paragraph("制程不良分析表", tittleFont)
            tittle.Alignment = Element.ALIGN_CENTER
            document.Add(tittle)
            '加一空白行
            AddBlank(document, contentFont)
          
            Dim tablebase As PdfPTable = New PdfPTable(6)
            tablebase.WidthPercentage = 100
            tablebase.SetWidths(New Single() {50, 150, 150, 150, 150, 150})
            Dim al As ArrayList = New ArrayList
            al.Add(NgDate)
            al.Add(PartId)
            al.Add(LineId)
            al.Add(ProductLabel)
            al.Add(Qty)
            AddTableTittleCell(tablebase, contentFontBold, NgDate, 2)
            AddTableTittleCell(tablebase, contentFontBold, PartId)
            AddTableTittleCell(tablebase, contentFontBold, LineId)
            AddTableTittleCell(tablebase, contentFontBold, ProductLabel)
            AddTableTittleCell(tablebase, contentFontBold, Qty)
            document.Add(tablebase)

            Dim table As PdfPTable = New PdfPTable(6)
            table.WidthPercentage = 100
            table.SetWidths(New Single() {50, 150, 150, 150, 150, 150})
            al.Clear()
            al.Add("项次")
            al.Add("不良内容")
            al.Add("不良数")
            al.Add("不良率")
            al.Add("影响度")
            al.Add("累计影响度")
            AddTableTittle(table, contentFontBold, al)
            AddTable(table, dtQty, contentFont, 2)
            document.Add(table)

            '加图像
            AddPicture(document, imagePath)

            Dim table2 As PdfPTable = New PdfPTable(7)
            table2.WidthPercentage = 100
            table2.SetWidths(New Single() {30, 100, 300, 300, 100, 100, 150})

            Dim cell As PdfPCell = New PdfPCell(New Phrase("前三项不良分析", contentFontBold))
            cell.Colspan = 7
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.VerticalAlignment = Element.ALIGN_MIDDLE
            table2.AddCell(cell)

            al.Clear()
            al.Add("NO")
            al.Add("不良项目")
            al.Add("不良原因")
            al.Add("处理方案&改善对策")
            al.Add("责任人")
            al.Add("完成时间")
            al.Add("结果追踪")
            AddTableTittle(table2, contentFontBold, al)
            '添加内容
            AddTable(table2, dtReason, contentFont)
            document.Add(table2)

            Dim content As String = "状态：" + Status + "      确认人：" + UserName
            Dim footer As iTextSharp.text.Paragraph = New Paragraph(content, contentFont)
            document.Add(footer)

        Catch ex As Exception
            Throw ex
        Finally
            document.Close()
        End Try
    End Sub

    '加表单元格
    Private Shared Sub AddTableTittleCell(table As PdfPTable, contentFont As Font, content As String, Optional colspan As Integer = 1)
        Dim cell As PdfPCell
        cell = New PdfPCell(New Phrase(content, contentFont))
        cell.HorizontalAlignment = Element.ALIGN_CENTER
        cell.VerticalAlignment = Element.ALIGN_MIDDLE
        cell.Colspan = colspan
        table.AddCell(cell)
    End Sub

    '加表头
    Private Shared Sub AddTableTittle(table As PdfPTable, contentFont As Font, al As ArrayList)
        Dim cell As PdfPCell
        For colIndex As Integer = 0 To al.Count - 1
            cell = New PdfPCell(New Phrase(al(colIndex), contentFont))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.VerticalAlignment = Element.ALIGN_MIDDLE
            table.AddCell(cell)
        Next
    End Sub

    '加空白行
    Private Shared Sub AddBlank(document As Document, contentFont As Font)
        Dim normalLineHeight As Single = 20.0F

        Dim pBlank As Paragraph = New Paragraph(" ", contentFont)
        pBlank.Leading = normalLineHeight
        document.Add(pBlank)
    End Sub

    '加表
    Private Shared Sub AddTable(table As PdfPTable, dt As DataTable, contentFont As Font, Optional flag As String = "1")
        Dim cell As PdfPCell
        For rowIndex As Integer = 0 To dt.Rows.Count - 1
            If rowIndex <> dt.Rows.Count - 1 Then
                cell = New PdfPCell(New Phrase(rowIndex + 1, contentFont))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.VerticalAlignment = Element.ALIGN_MIDDLE
                table.AddCell(cell)
            End If
            For colIndex As Integer = 0 To dt.Columns.Count - 1
                cell = New PdfPCell(New Phrase(dt.Rows(rowIndex)(colIndex).ToString, contentFont))
                If flag <> "1" And rowIndex = dt.Rows.Count - 1 And colIndex = 0 Then
                    cell.Colspan = 2
                End If
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.VerticalAlignment = Element.ALIGN_MIDDLE
                table.AddCell(cell)
            Next
        Next
    End Sub

    '加入表
    Private Shared Sub AddTable(table As PdfPTable, dt As DataTable, contentFont As Font)
        Dim cell As PdfPCell
        For rowIndex As Integer = 0 To dt.Rows.Count - 1
            cell = New PdfPCell(New Phrase(rowIndex + 1, contentFont))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.VerticalAlignment = Element.ALIGN_MIDDLE
            cell.FixedHeight = 70.0F
            'cell.FixedHeight = 40.0F
            table.AddCell(cell)
            For colIndex As Integer = 0 To dt.Columns.Count - 1
                cell = New PdfPCell(New Phrase(dt.Rows(rowIndex)(colIndex).ToString, contentFont))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.VerticalAlignment = Element.ALIGN_MIDDLE
                table.AddCell(cell)
            Next
        Next
    End Sub

    '加入图片
    Private Shared Sub AddPicture(document As Document, imagePath As String)
        Dim pdfImg As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imagePath)
        document.Add(pdfImg)
    End Sub



End Class
