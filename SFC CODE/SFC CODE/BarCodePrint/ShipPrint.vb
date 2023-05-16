Imports System.Text
Imports MainFrame
Imports System.IO
Public Class ShipPrint
    Public Shared Vendor As String
    Public Shared DeliveryDate As String
    Public Shared GoodsName As String
    Public Shared OrderID As String
    Public Shared PartNum As String
    Public Shared QTY As String
    Public Shared Weight As String
    Public Shared IQCRemark As String
    Public Shared PrinterName As String
    Public Shared PrintQty As Integer = 1
    Public Shared Year As String
    Public Shared Month As String
    Public Shared Day As String
    '总数'
    '打印条码
    Public Shared Sub FileToBarCodePrint(ByVal pFilePath As String)
        '创建bartender对象
        Dim btApp As BarTender.Application = CreateObject("bartender.application")
        btApp.VisibleWindows = BarTender.BtVisibleWindows.btNone
        '创建Format对象
        Dim btFormat As BarTender.Format = btApp.Formats.Open(pFilePath, True)
        btFormat.Printer = ShipPrint.PrinterName

        Try
            For index As Integer = 1 To ShipPrint.PrintQty
                btFormat.SetNamedSubStringValue("Vendor", ShipPrint.Vendor)
                'btFormat.SetNamedSubStringValue("DeliveryDate", ShipPrint.DeliveryDate)
                btFormat.SetNamedSubStringValue("GoodsName", ShipPrint.GoodsName)
                btFormat.SetNamedSubStringValue("OrderID", ShipPrint.OrderID)
                btFormat.SetNamedSubStringValue("PartNum", ShipPrint.PartNum)
                btFormat.SetNamedSubStringValue("QTY", ShipPrint.QTY)
                btFormat.SetNamedSubStringValue("Weight", ShipPrint.Weight)
                btFormat.SetNamedSubStringValue("IQCRemark", ShipPrint.IQCRemark)
                btFormat.SetNamedSubStringValue("Year", ShipPrint.Year)
                btFormat.SetNamedSubStringValue("Month", ShipPrint.Month)
                btFormat.SetNamedSubStringValue("Day", ShipPrint.Day)
                '打印
                '  btFormat.PrintOut(False, True) 'false不要对话框 ,true要有对话框提示
                btFormat.PrintOut(False, False)
            Next
        Catch ex As Exception
            Throw ex
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
    End Sub
    Public Shared Sub KillProcessById(ByVal id As Integer)
        Dim process As Process = System.Diagnostics.Process.GetProcessById(id)
        process.Kill()
    End Sub
End Class
