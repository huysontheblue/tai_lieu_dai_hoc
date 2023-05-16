Imports BarTender
Imports System.Xml
Imports System.IO

Public Class FrmScanPrt
    ' Private _txtPath As TextBox
    Private btApp As Application
    Private btFormat As Format
    Private Sub ScanPrt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPath.Text = GetXMLNodeData("path")
        If txtPath.Text.Trim = "" Then
            Dim strAssemblyFilePath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
            Dim strAssemblyDirPath As String = System.IO.Path.GetDirectoryName(strAssemblyFilePath)
            txtPath.Text = strAssemblyDirPath + "\Single.btw"
        End If
    End Sub
    Private Sub ScanHandle()
        Dim sourceString As String = Me.txtBarCode.Text.Trim
        '  sourceString = Me.DeleteUnVisibleChar(sourceString)
        Me.PrintMainBarcode(sourceString, Me.txtPath.Text.Trim)
        Me.txtBarCode.Clear()
        SetXMLNodeData("path", Me.txtPath.Text.Trim)
    End Sub


    Private Sub PrintMainBarcode(ByVal BarCodeStr As String, ByVal PrintFilePath As String)
        If (PrintFilePath = "") Then
            PrintFilePath = "E:\scanprint\Single.btw"
        End If

        If Not System.IO.File.Exists(PrintFilePath) Then
            MessageBox.Show("模板文件不存在" + PrintFilePath)
            Exit Sub
        End If

        Try
            If (Me.btApp Is Nothing) Then
                Me.btApp = New ApplicationClass
            End If
            Me.btFormat = Me.btApp.Formats.Open(PrintFilePath, False, String.Empty)
            Me.btFormat.SetNamedSubStringValue("barcode", BarCodeStr)
            'Me.btFormat.PrintOut(False, False)
            Dim messages As Messages = Nothing
            Me.btFormat.Print("", False, -1, messages)
            Me.btFormat.Close(BtSaveOptions.btDoNotSaveChanges)
            Me.btApp.Quit(BtSaveOptions.btDoNotSaveChanges)

        Catch exception1 As Exception
            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
        End Try
    End Sub


    Private Sub txtBarCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarCode.KeyPress
        If (e.KeyChar = ChrW(13)) Then
            Me.ScanHandle()
        End If

    End Sub
    Private Sub SetXMLNodeData(ByVal XmlNodeName As String, ByVal XmlNodeValue As String)
        Dim strAssemblyFilePath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim strAssemblyDirPath As String = System.IO.Path.GetDirectoryName(strAssemblyFilePath)
        Dim FilePath As String = strAssemblyDirPath + "\\config.xml"
        Dim lXmlDocument As XmlDocument = New XmlDocument()
        If File.Exists(FilePath) Then
            Dim IsExistsNode As Boolean = False
            lXmlDocument.Load(FilePath)
            Dim lXmlNodeList As XmlNodeList = lXmlDocument.SelectSingleNode("Info").ChildNodes
            Dim xn As XmlNode
            For Each xn In lXmlNodeList
                If xn.Name.ToUpper().Equals(XmlNodeName.ToUpper()) Then
                    xn.InnerText = XmlNodeValue
                    IsExistsNode = True
                    Continue For
                End If
            Next
            If Not IsExistsNode Then
                Dim lChildXmlElement As XmlElement = lXmlDocument.CreateElement(XmlNodeName)
                lChildXmlElement.InnerText = XmlNodeValue
                lXmlDocument.SelectSingleNode("Info").AppendChild(lChildXmlElement)
            End If
            lXmlDocument.Save(FilePath)
        Else
            Dim lXmlNode As XmlElement = lXmlDocument.CreateElement("Info")
            Dim lChildXmlElement As XmlElement = Nothing
            lChildXmlElement = lXmlDocument.CreateElement(XmlNodeName)
            lChildXmlElement.InnerText = XmlNodeValue
            lXmlNode.AppendChild(lChildXmlElement)
            lXmlDocument.AppendChild(lXmlNode)
            lXmlDocument.Save(FilePath)
        End If
    End Sub

    Private Function GetXMLNodeData(ByVal XmlNodeName As String) As String
        Dim XmlNodeValue As String = ""
        Dim strAssemblyFilePath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim strAssemblyDirPath As String = System.IO.Path.GetDirectoryName(strAssemblyFilePath)
        Dim FilePath As String = strAssemblyDirPath + "\\config.xml"
        Dim lXmlDocument As XmlDocument = New XmlDocument()
        Try
            If File.Exists(FilePath) Then
                lXmlDocument.Load(FilePath)
                Dim lXmlNodeList As XmlNodeList = lXmlDocument.SelectSingleNode("Info").ChildNodes
                Dim xn As XmlNode
                For Each xn In lXmlNodeList
                    If xn.Name.ToUpper().Equals(XmlNodeName.ToUpper()) Then
                        XmlNodeValue = xn.InnerText
                    End If
                Next
            Else
                Dim lXmlNode As XmlElement = lXmlDocument.CreateElement("Info")
                Dim lChildXmlElement As XmlElement = Nothing
                lChildXmlElement = lXmlDocument.CreateElement(XmlNodeName)
                lChildXmlElement.InnerText = XmlNodeValue
                lXmlNode.AppendChild(lChildXmlElement)
                lXmlDocument.AppendChild(lXmlNode)
                lXmlDocument.Save(FilePath)
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return XmlNodeValue
    End Function
    Private Sub btnPrt_Click(sender As Object, e As EventArgs)
        Me.ScanHandle()
    End Sub
    Private Sub FileToBarCodePrint(ByVal LableFile As String)
        Try
            'If (Me.btApp Is Nothing) Then
            '    Me.btApp = New ApplicationClass
            'End If
            Me.btFormat = Me.btApp.Formats.Open(LableFile, False, String.Empty)
            Me.btFormat.SetNamedSubStringValue("SHIPNO", "EAGLF201601140002")
            Me.btFormat.SetNamedSubStringValue("HAWBNO", "SHA-0052448412")
            Me.btFormat.SetNamedSubStringValue("PONO", "5700045665")
            Me.btFormat.SetNamedSubStringValue("SSCCNO", "(00)107189084111520154")
            Me.btFormat.SetNamedSubStringValue("RETURNTO", "B.I.558 Aldi Blvd Mt.Juliet,TN 37122 USA")
            Me.btFormat.SetNamedSubStringValue("SHIPTO", "Name 2(Example:Al) Name 2(Example:C/O OHL) Address 1(14401 County Road 212) Address 2(Additional line of needed) Address 2(Use for district/Colonia) City,State,Zip(Mt Juliet,TN 38111) Country(USA)")
            Me.btFormat.SetNamedSubStringValue("TEL", "512-674-7878")
            Me.btFormat.SetNamedSubStringValue("CARRIER", "EXD1")
            Me.btFormat.SetNamedSubStringValue("ORIGIN", "HKG")
            Me.btFormat.SetNamedSubStringValue("POE", "JFK1")
            Me.btFormat.SetNamedSubStringValue("SHIPDATE", "01/22/2016")
            Me.btFormat.SetNamedSubStringValue("CARTONS", "120-240/240")
            Me.btFormat.SetNamedSubStringValue("POITEM1", "1")
            Me.btFormat.SetNamedSubStringValue("POITEM2", "2")
            Me.btFormat.SetNamedSubStringValue("POITEM3", "3")
            Me.btFormat.SetNamedSubStringValue("POPART1", "1")
            Me.btFormat.SetNamedSubStringValue("POPART2", "2")
            Me.btFormat.SetNamedSubStringValue("POPART3", "3")
            Me.btFormat.SetNamedSubStringValue("POQTY1", "1")
            Me.btFormat.SetNamedSubStringValue("POQTY2", "2")
            Me.btFormat.SetNamedSubStringValue("POQTY3", "3")
            Dim messages As Messages = Nothing
            Me.btFormat.Print("", False, -1, messages)
            Me.btFormat.Close(BtSaveOptions.btDoNotSaveChanges)
            Me.btApp.Quit(BtSaveOptions.btDoNotSaveChanges)
        Catch exception1 As Exception

            Dim exception As Exception = exception1
            Me.btFormat.Close(BtSaveOptions.btDoNotSaveChanges)
            Me.btApp.Quit(BtSaveOptions.btDoNotSaveChanges)
            Throw New Exception(exception.Message.ToString)

        End Try
    End Sub


    Private Sub FrmScanPrt_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub
End Class