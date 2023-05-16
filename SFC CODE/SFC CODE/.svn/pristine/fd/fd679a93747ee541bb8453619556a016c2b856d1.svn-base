Imports MainFrame
Imports System.Text

''' <summary>
''' 创建者：田玉琳
''' 创建日期:20200608
''' 创建内容：华米条码打印（特殊处理）
''' </summary>
''' <remarks></remarks>

Public Class FrmSpecialPrint

    Private btApp As BarTender.Application
    Private btFormat As BarTender.Format


    '初始化
    Private Sub FrmSpecialPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = True Then Exit Sub '只执行第一次
        SqlClassM.GetPrintersList(cboPrinterList)
        SqlClassM.GetPrintersList(cboPrinterList2)

        btApp = New BarTender.Application
        btFormat = New BarTender.Format
    End Sub

    '关闭窗体
    Private Sub FrmSpecialPrint_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
        Catch ex As Exception

        End Try
    End Sub

#Region "华米在线打印"

    '条码扫描
    Private Sub txtPPid_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtPPid.KeyPress
        If e.KeyChar <> Chr(13) Then Exit Sub

        GetPrintData(chkPrint.Checked)

    End Sub

    '打印
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        GetPrintData(True)
    End Sub

    ''' <summary>
    ''' 检查数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckData() As Boolean
        Try

            If String.IsNullOrEmpty(Me.cboPrinterList.Text.Trim) Then
                MessageUtils.ShowInformation("请选择打印机！")
                Return False
            End If

            If (String.IsNullOrEmpty(Me.txtPath.Text.Trim)) Then
                MessageUtils.ShowInformation("打印路径不能为空！")
                Return False
            End If

            If (String.IsNullOrEmpty(Me.txtPPid.Text.Trim)) Then
                MessageUtils.ShowInformation("打印条码不能为空！")
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    '取得打印数据打印
    Private Sub GetPrintData(bPrint As Boolean)

        If CheckData() = False Then
            Exit Sub
        End If

        Dim strSQL As String = "exec [GetH01PrintData_Rework] '{0}' "
        strSQL = String.Format(strSQL, txtPPid.Text.Trim)

        Dim DataTable As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (DataTable.Rows.Count = 0) Then
            Throw New Exception("MES没有要打印数据，请确认!")
        End If

        dgView.Rows.Clear()
        For rowIndex As Integer = 0 To DataTable.Rows.Count - 1
            dgView.Rows.Add(DataTable.Rows(rowIndex).Item(0).ToString, DataTable.Rows(rowIndex).Item(1).ToString)
        Next

        Dim BarFile As New StringBuilder()

        For Each dr As DataRow In DataTable.Rows
            For Each dc As DataColumn In DataTable.Columns
                BarFile.Append("""" & dr(dc.ColumnName).ToString() & """" & ",")
            Next
            BarFile.Remove(BarFile.Length - 1, 1)
            BarFile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
        Next

        If bPrint = True Then
            CommonPrint.FileToBarCodePrint(txtPath.Text, BarFile, cboPrinterList.Text)
        End If

    End Sub

#End Region

#Region "扫描条码直接打印"


    Private Sub btnPrint2_Click(sender As Object, e As EventArgs) Handles btnPrint2.Click
        GetPrintData2()
    End Sub

    Private Sub txtPPid2_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtPPid2.KeyPress
        If e.KeyChar <> Chr(13) Then Exit Sub

        GetPrintData2()
    End Sub

    ''' <summary>
    ''' 检查数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckData2() As Boolean
        Try

            If String.IsNullOrEmpty(Me.cboPrinterList2.Text.Trim) Then
                MessageUtils.ShowInformation("请选择打印机！")
                Return False
            End If

            If (String.IsNullOrEmpty(Me.txtPath2.Text.Trim)) Then
                MessageUtils.ShowInformation("打印路径不能为空！")
                Return False
            End If

            If (String.IsNullOrEmpty(Me.txtPPid2.Text.Trim)) Then
                MessageUtils.ShowInformation("打印条码不能为空！")
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    '取得打印数据打印
    Private Sub GetPrintData2()
        If CheckData2() = False Then
            Exit Sub
        End If

        Dim BarFile As New StringBuilder()

        BarFile.Append("""" & txtPPid2.Text.Trim & """")
        BarFile.Append(Microsoft.VisualBasic.Constants.vbNewLine)

        CommonPrint.FileToBarCodePrint(txtPath2.Text, BarFile, cboPrinterList2.Text)
    End Sub


#End Region

    
End Class