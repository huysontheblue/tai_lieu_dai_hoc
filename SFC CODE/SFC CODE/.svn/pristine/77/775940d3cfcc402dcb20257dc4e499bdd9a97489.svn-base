Imports System.Windows.Forms

Public Class LabelPrintHelper
    Public Shared Function PrintLabel(ByVal dics As List(Of KeyValue), ByVal printerName As String, ByRef errorMsg As String, ByVal fileName As String, ByVal prePage As Integer, Optional ByVal copies As Integer = 1)
        Dim btApp As BarTender.Application = Nothing
        Dim btFormat As BarTender.Format = Nothing
        Try
            '创建bartender对象
            btApp = CreateObject("bartender.application")
            btApp.VisibleWindows = BarTender.BtVisibleWindows.btNone
            '创建Format对象
            'Dim strTemp1 As String = Application.StartupPath()
            'Dim strTemp2 As String = Environment.CurrentDirectory

            'btFormat = btApp.Formats.Open(Application.StartupPath() + "\EquipmentTemplate\" + fileName, True)
            btFormat = btApp.Formats.Open(fileName, True)
            btFormat.Printer = printerName
            'If prePage = 1 Then
            '    For Each dic As KeyValue In dics
            '        btFormat.SetNamedSubStringValue(dic.Key, dic.Value)
            '        btFormat.PrintOut(False, False)
            '    Next
            'Else
            For i As Integer = 1 To copies
                For Each dic As KeyValue In dics
                    If dic.Index = i Then
                        btFormat.SetNamedSubStringValue(dic.Key, dic.Value)
                    End If
                Next
                btFormat.PrintOut(False, False)
            Next
            'End If
            '打印
            '  btFormat.PrintOut(False, True) 'false不要对话框 ,true要有对话框提示
            Return True
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        Finally
            '释放资源
            If Not btFormat Is Nothing Then
                btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
                btFormat = Nothing
            End If
            If Not btApp Is Nothing Then
                btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
                KillProcessById(btApp.ProcessId)
            End If
        End Try
    End Function
    Private Shared Sub KillProcessById(ByVal id As Integer)
        Dim process As Process = System.Diagnostics.Process.GetProcessById(id)
        process.Kill()
    End Sub
    Public Shared Sub InitPrinter(ByVal cboPrinter As ComboBox)
        cboPrinter.Items.Clear()
        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            cboPrinter.Items.Add(printer)
        Next
        cboPrinter.Items.Insert(0, "")
    End Sub
End Class
