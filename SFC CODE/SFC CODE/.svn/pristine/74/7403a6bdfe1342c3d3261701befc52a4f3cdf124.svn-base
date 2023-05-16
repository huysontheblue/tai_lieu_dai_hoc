#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports MainFrame
Imports Aspose.Cells

#End Region

Public Class GetMesData


    '生成二维码
    Public Shared Sub SetQR(DetailSheet As Worksheet, Outwhid As String, size As Integer, leftRow As Integer, leftColumn As Integer)
        Dim bc1 As DotNetBarcode = New DotNetBarcode(DotNetBarcode.Types.Code39)
        bc1.SaveFileType = DotNetBarcode.SaveFileTypes.Gif

        Dim o_strPicturePath As String = Environment.CurrentDirectory + "\" & "barcode.bmp"
        bc1.QRSave(Outwhid, o_strPicturePath, size)

        Dim pictures As Aspose.Cells.Drawing.PictureCollection = DetailSheet.Pictures
        'C1
        pictures.Add(leftRow, leftColumn, o_strPicturePath)
    End Sub

    '生成二维码
    'Public Shared Sub SetQR(Outwhid As String, DetailSheet As Worksheet)
    '    Dim bc1 As DotNetBarcode = New DotNetBarcode(DotNetBarcode.Types.Code39)
    '    bc1.SaveFileType = DotNetBarcode.SaveFileTypes.Gif

    '    Dim o_strPicturePath As String = Environment.CurrentDirectory + "\" & "barcode.bmp"
    '    bc1.QRSave(Outwhid, o_strPicturePath, 3)

    '    Dim pictures As Aspose.Cells.Drawing.PictureCollection = DetailSheet.Pictures
    '    'C1
    '    pictures.Add(0, 6, o_strPicturePath)
    'End Sub

    Public Shared Function GetLocation() As DataTable
        Dim strSQL As String = "  select [LocationID],[LocationName] from [m_WHLocation_t] where usey = 'y'"

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)

        Return dt
    End Function

    Public Shared Sub SetMessage(ByVal lblMessage As LabelX, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As Label, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As LabelItem, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub


#Region "获取本地打印机列表"

    Public Shared Sub GetPrintersList(ByVal CboName As ComboBox)
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            CboName.Items.Add(iprt)
        Next
    End Sub

    Public Shared Sub GetPrintersList(ByVal CboName As DataGridViewComboBoxColumn)
        CboName.Items.Clear()
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            CboName.Items.Add(iprt)
        Next
    End Sub

    Public Shared Function CheckPrintersList(ByVal PrintName As String) As Boolean
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            If (iprt.Trim = PrintName) Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region

End Class
