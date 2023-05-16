Imports System.IO
Imports System.Windows.Forms

Public Class LabelHelper
    Public Sub New(ByVal partNumber As String, ByVal number As String, ByVal lot As String, ByVal storage As String, ByVal lineId As String, ByVal coutnumber As String, Optional ByVal copies As Integer = 1)
        Me.PartNumber = partNumber
        Me.Number = number
        Me.Lot = lot
        Me.Storage = storage
        Me.LineId = lineId
        Me.Copies = Copies
        Me.COUNTNUM = coutnumber
    End Sub

    Private PartNumber As String
    Private Number As String
    Private Lot As String
    Private Storage As String
    Private Print As String
    Private LineId As String
    Private Copies As Integer = 1
    Private COUNTNUM As String '总数'
    Public Function GetPrinterList() As ArrayList
        Dim list As New ArrayList
        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            list.Add(printer)
        Next
        Return list
    End Function


    Public Function PrintLabel(ByVal printer As String, ByVal filePath As String) As Boolean
        '创建bartender对象
        Dim btApp As BarTender.Application = CreateObject("bartender.application")
        btApp.VisibleWindows = BarTender.BtVisibleWindows.btNone
        '创建Format对象
        Dim btFormat As BarTender.Format = btApp.Formats.Open(filePath, True)
        btFormat.Printer = printer

        Try
            For index As Integer = 1 To Copies
                btFormat.SetNamedSubStringValue("PartNumber", PartNumber)
                btFormat.SetNamedSubStringValue("QTY", Number)
                btFormat.SetNamedSubStringValue("LOT", Lot)
                btFormat.SetNamedSubStringValue("Storage", Storage)
                btFormat.SetNamedSubStringValue("LineId", LineId)
                btFormat.SetNamedSubStringValue("COUNTNUM", COUNTNUM) '总数'
                '打印
                '  btFormat.PrintOut(False, True) 'false不要对话框 ,true要有对话框提示
                btFormat.PrintOut(False, False)
            Next
            Return True
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
    End Function

    Private Sub KillProcessById(ByVal id As Integer)
        Dim process As Process = System.Diagnostics.Process.GetProcessById(id)
        process.Kill()
    End Sub

    Public Shared Function PrintLabel(ByVal printer As String, ByVal partList As List(Of LabelHelper), ByVal filePath As String) As Boolean
        '创建bartender对象
        Dim btApp As BarTender.Application = CreateObject("bartender.application")
        btApp.VisibleWindows = BarTender.BtVisibleWindows.btNone
        '创建Format对象
        Dim btFormat As BarTender.Format = btApp.Formats.Open(filePath, True)
        btFormat.Printer = printer

        Try
            For Each pList As LabelHelper In partList
                For index As Integer = 1 To pList.Copies
                    btFormat.SetNamedSubStringValue("PartNumber", pList.PartNumber)
                    btFormat.SetNamedSubStringValue("QTY", pList.Number)
                    btFormat.SetNamedSubStringValue("LOT", pList.Lot)
                    btFormat.SetNamedSubStringValue("Storage", pList.Storage)
                    btFormat.SetNamedSubStringValue("LineId", pList.LineId)
                    btFormat.SetNamedSubStringValue("COUNTNUM", pList.COUNTNUM) '总数'
                    btFormat.PrintSetup.IdenticalCopiesOfLabel = pList.Copies
                    '打印
                    '  btFormat.PrintOut(False, True) 'false不要对话框 ,true要有对话框提示
                    ' btFormat.PrintOut(False, False)
                Next
                btFormat.PrintOut(False, False)
                Threading.Thread.Sleep(100)
            Next
            Return True
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
                KillProcessByIdS(btApp.ProcessId)
            End If
        End Try
    End Function

    Public Shared Function PrintLabelALL(ByVal printer As String, ByVal partList As List(Of LabelHelper), ByVal filePath As String) As Boolean
        '创建bartender对象
        Dim btApp As BarTender.Application = CreateObject("bartender.application")
        btApp.VisibleWindows = BarTender.BtVisibleWindows.btNone
        '创建Format对象
        Dim btFormat As BarTender.Format = btApp.Formats.Open(filePath, True)
        btFormat.Printer = printer

        Try
            For Each pList As LabelHelper In partList
                For index As Integer = 1 To pList.Copies
                    btFormat.SetNamedSubStringValue("PartNumber", pList.PartNumber)
                    btFormat.SetNamedSubStringValue("QTY", pList.Number)
                    btFormat.SetNamedSubStringValue("LOT", pList.Lot)
                    btFormat.SetNamedSubStringValue("Storage", pList.Storage)
                    btFormat.SetNamedSubStringValue("LineId", pList.LineId)
                    btFormat.SetNamedSubStringValue("COUNTNUM", pList.COUNTNUM) '总数'
                    btFormat.PrintSetup.IdenticalCopiesOfLabel = pList.Copies
                    '打印
                    '  btFormat.PrintOut(False, True) 'false不要对话框 ,true要有对话框提示
                    ' btFormat.PrintOut(False, False)
                Next
                btFormat.PrintOut(False, False)
            Next


            Return True
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
                KillProcessByIdS(btApp.ProcessId)
            End If
        End Try
    End Function

    Public Shared Sub KillProcessByIdS(ByVal id As Integer)
        Dim process As Process = System.Diagnostics.Process.GetProcessById(id)
        process.Kill()
    End Sub

    Public Shared btAppRunCard As BarTender.Application '= CreateObject("bartender.application")
    Public Shared btFormatRunCard As BarTender.Format
    Private Shared path1 As String = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\ProcessRunCard\ProcessRunCard2D.btw"

    Public Shared Sub CreateInstance()
        If btAppRunCard Is Nothing Then
            btAppRunCard = CreateObject("bartender.application")
        End If
        btAppRunCard.VisibleWindows = BarTender.BtVisibleWindows.btNone
        '创建Format对象
        btFormatRunCard = btAppRunCard.Formats.Open(path1, False, String.Empty)
    End Sub


    Public Shared dics As New Dictionary(Of String, Dictionary(Of String, String))
    Public Shared ds As New Dictionary(Of String, String)
    Public Shared Function PrintProcessCard(ByVal dt As DataTable, ByVal printer As String, ByVal path As String, ByVal Copies As Integer, ByVal pns As String)
        'If btAppRunCard Is Nothing Then
        '    btAppRunCard = CreateObject("bartender.application")
        'End If
        'btAppRunCard.VisibleWindows = BarTender.BtVisibleWindows.btNone
        ''创建Format对象
        'btFormatRunCard = btAppRunCard.Formats.Open(path1, False, String.Empty)
        btFormatRunCard.Printer = printer
        Try
            GenerateTxt(dt, pns, Copies)
            btFormatRunCard.Print("", False, -1, Nothing)
            Return True
        Catch ex As Exception
            Throw ex
        Finally
            'If Not btFormatRunCard Is Nothing Then
            '    btFormatRunCard.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            '    btFormatRunCard = Nothing
            'End If
            'If Not btAppRunCard Is Nothing Then
            '    btAppRunCard.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            '    KillProcessByIdS(LabelHelper.btAppRunCard.ProcessId)
            '    btAppRunCard = Nothing
            'End If
        End Try
    End Function

    Private Shared Sub GenerateTxt(ByVal dt As DataTable, ByVal pns As String, ByVal Copies As Integer)
        Dim str As String = Nothing
        Using sw As New StreamWriter("D:\ProcessRunCard.txt", False, System.Text.Encoding.UTF8)
            For i As Integer = 1 To 30
                str &= """" & ProcessRunCardGrid.STATION.ToString + i.ToString() & ""","
                str &= """" & ProcessRunCardGrid.MOQTY.ToString + i.ToString() & ""","
                str &= """" & ProcessRunCardGrid.FUNCTIONBARCODE.ToString + i.ToString() & ""","
                str &= """" & ProcessRunCardGrid.ID.ToString + i.ToString() & ""","
            Next
            str &= """PN"",""MQTY"",""CONFIGQTY"",""MOID"""
            sw.WriteLine(str)
            For Each strPn As String In pns.Split(",")
                str = Nothing
                Dim dr() As DataRow = dt.Select("PN=" & strPn)
                For index As Integer = 1 To Copies
                    For inte As Integer = 0 To CInt(System.Math.Ceiling(dr.Length / 30)) - 1
                        str = Nothing
                        For idx As Integer = 1 To 30
                            If inte * 30 + idx <= dr.Length Then
                                str &= """" & dr(inte * 30 + idx - 1)("WORKSTATIONCONTENT").ToString & ""","
                                str &= """" & dr(inte * 30 + idx - 1)("MOQTY").ToString & ""","
                                str &= """" & dr(inte * 30 + idx - 1)("FUNCTIONBARCODE").ToString & ""","
                                str &= """" & dr(inte * 30 + idx - 1)("ID").ToString & ""","
                            Else
                                str &= """" & "" & ""","
                                str &= """" & "" & ""","
                                str &= """" & "" & ""","
                                str &= """" & "" & ""","
                            End If
                        Next
                        str &= """" & dr(0)("PN").ToString & ""","
                        str &= """" & dr(0)("MQTY").ToString & ""","
                        str &= """" & dr(0)("CONFIGQTY").ToString & ""","
                        str &= """" & dr(0)("MOID").ToString & """"
                        sw.WriteLine(str)
                    Next
                Next
            Next
        End Using
    End Sub

    Public Enum ProcessRunCardGrid
        STATION
        MOQTY
        ID
        FUNCTIONBARCODE
    End Enum
End Class
