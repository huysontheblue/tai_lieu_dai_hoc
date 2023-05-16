Imports MainFrame
Imports System.Text

Public Class FrmChildPrintMoNum
    Public motherMoid As String
    Public motherBarcode As String
    Public sqlStr As String
    Public printerName As String

    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Dim pFilePath As String = "" 'Application.StartupPath & "\BartenderFile\ReelBarcode.btw"

#Region "初始化"
    '初始化
    Private Sub FrmChildPrintMoNum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMotherMoid.Text = motherMoid
        txtMotherBarcode.Text = motherBarcode
        txtPrintNum.Text = "1"

        btApp = New BarTender.ApplicationClass
    End Sub
#End Region

#Region "事件"
    '取消
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    '打印
    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        Dim i As Integer
        Dim num As Integer

        If IsNumeric(txtPrintNum.Text.ToString) Then
            num = Convert.ToInt32(txtPrintNum.Text.ToString)
        Else
            MessageUtils.ShowInformation("打印数量请填写数字类型！")
            Return
        End If

        If num < 1 Then
            MessageUtils.ShowInformation("打印数量不能小于1")
            Return
        End If


        pFilePath = VbCommClass.VbCommClass.PrintDataModle & "MotherMoidPrintFIle\MoidPrint.btw"
        '打印
        If (Not String.IsNullOrEmpty(sqlStr.ToString)) Then
            DbOperateUtils.ExecSQL(sqlStr.ToString)

            For i = 1 To num
                FileToBarCodePrint(pFilePath, printerName)
            Next
            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)  '打印完成后进行关闭
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)

        End If
    End Sub
#End Region

#Region "方法"
    '调用打印机开始打印
    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)
        btFormat = btApp.Formats.Open(pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        'btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        'btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub
#End Region

End Class