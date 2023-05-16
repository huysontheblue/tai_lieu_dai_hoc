Imports System.Text
Imports MainFrame
Imports System.IO



Public Class CommonPrint



    '写入数据到文件中
    Public Shared Sub FileToBarCodePrint(strTemplatePath As String, BarFile As StringBuilder, printName As String)

        'add by hgd 20180406 更改为当前安装路径
        Dim path As String = System.Windows.Forms.Application.StartupPath & "\Bartender.txt"
        'Dim path As String = "C:\Program Files\默认公司名称\Bartender.txt"
        BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)

        File.WriteAllText(path, BarFile.ToString, Encoding.UTF8)
        FileToBarCodePrint(strTemplatePath, printName)
    End Sub

    '打印条码
    Private Shared Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)
        '每次新建，用完再释放，看是否影响性能
        Dim btApp As BarTender.Application = New BarTender.ApplicationClass
        Dim btFormat As BarTender.Format = New BarTender.Format

        btFormat = btApp.Formats.Open(VbCommClass.VbCommClass.PrintDataModle & pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub


End Class
