'Imports Seagull.BarTender.Print

Public Class BarcodePrintClass

    'Private Shared engine As Engine = Nothing ' The BarTender Print Engine
    'Private Shared format As LabelFormatDocument = Nothing ' The currently open Format
    'Private Const appName As String = "Label Print"
    'Private Const dataSourced As String = "Data Sourced"
    Shared btApp As BarTender.Application

    'Declare a BarTender format variable 

    Shared btFormat As New BarTender.Format
#Region "获取本地打印机列表"

	''' <summary> 
	''' 获取本地打印机列表 
	''' 可以通过制定参数获取网络打印机 
	''' 打印机列表
	''' </summary> 

	Public Shared Sub GetPrinterList(ByVal cboPrinters As System.Windows.Forms.ComboBox)
        'Dim alRet As New System.Collections.ArrayList()
        'Dim printers As New Printers()
        'For Each printer As Printer In printers
        '    cboPrinters.Items.Add(printer.PrinterName)
        'Next printer

        'If printers.Count > 0 Then
        '    ' Automatically select the default printer.
        '    cboPrinters.SelectedItem = printers.Default.PrinterName
        'End If
    End Sub
#End Region

#Region "条码打印方法更新，优化速度"

    Shared Sub FileToBarCodePrint(ByVal LableFile As String)

        Try
            btApp = New BarTender.ApplicationClass
            btFormat = btApp.Formats.Open(LableFile, False, String.Empty)
            'Me.Timer1.Stop()
            'MessageBox.Show(mytime)
            'btFormat.PrintOut(False, False)
            btFormat.Print("", False, -1, Nothing)
            'Me.Timer1.Stop()
            'End the BarTender process 
            btFormat.Close(BarTender.BtSaveOptions.btSaveChanges)

            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)

        Catch ex As Exception
            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            Throw New Exception(ex.Message.ToString())
        End Try



    End Sub

#End Region

End Class
