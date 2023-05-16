Imports System.Windows.Forms

Public Class FrmSetPrintQTY

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If String.IsNullOrEmpty(Me.cbxPrint.Text) Then
            MessageBox.Show("请选择打印机!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If String.IsNullOrEmpty(Me.txtPrintQTY.Text.Trim) Then
            MessageBox.Show("请输入打印数量!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not IsNumeric(Me.txtPrintQTY.Text) Then
            MessageBox.Show("打印数量必须是数字!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        ShipPrint.PrintQty = Me.txtPrintQTY.Text
        ShipPrint.PrinterName = Me.cbxPrint.Text
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmSetPrintQTY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPrinter()
    End Sub

    Private Sub LoadPrinter()
        cbxPrint.Items.Clear()
        Dim plist As ArrayList = GetPrinterList()
        plist.Insert(0, "")
        For index As Integer = 0 To plist.Count - 1
            cbxPrint.Items.Add(plist.Item(index))
        Next
        cbxPrint.SelectedIndex = 0
    End Sub
    Public Function GetPrinterList() As ArrayList
        Dim list As New ArrayList
        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            list.Add(printer)
        Next
        Return list
    End Function
End Class