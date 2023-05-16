Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData
Public Class FrmOnlineWorkPrintPES
#Region "属性"
    Private m_printName As String
    Private m_stationId As String
    Private m_partId As String
    Public Moid As String
    Private btApp As BarTender.Application
    Private btFormat As BarTender.Format
    Public WriteOnly Property PrintName() As String
        Set(value As String)
            m_printName = value
        End Set
    End Property

    Public WriteOnly Property StationId() As String
        Set(value As String)
            m_stationId = value
        End Set
    End Property

    Public WriteOnly Property PartId() As String
        Set(value As String)
            m_partId = value
        End Set
    End Property

#End Region

#Region "事件"

    Private Sub FrmOnlineWorkPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = True Then Exit Sub '只执行第一次

        'btApp = New BarTender.Application
        'btFormat = New BarTender.Format
        Me.lblMsg.Text = String.Empty
    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            If ScanCommon.IsTextBoxBlank(txtBarcode, "请输入PE袋条码!") = False Then Exit Sub
            OnlineWorkPrint(txtBarcode.Text.Trim)
            'btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            'System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
            ' Me.Close()
            Me.txtBarcode.Text = String.Empty
            Me.txtBarcode.Focus()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmOnlineWorkPrint", "BnOpenlock_Click", "sys")
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region

#Region "函数"
    '在线打印PE袋标签（华为零售）
    Private Sub OnlineWorkPrint(ByVal ppid As String)
        Try
            Dim strSql As String
            'L01联想打印PE袋标签
            'strSql = "SELECT macaddress AS ppid FROM MESDataCenter.DBO.m_Lnv6MACRead_t where macaddress='" & ppid & "' "
            'Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            ' If dt.Rows.Count > 0 Then
            btApp = New BarTender.Application
            btFormat = New BarTender.Format
            Dim printBarcode As New PrintBarcode
            printBarcode.btApp = btApp
            printBarcode.btFormat = btFormat
            printBarcode.PrintName = Me.m_printName
            printBarcode.PrintL01PES(ppid, Me.m_partId, WorkStantOption.vStandId)
            'Else
            '    MessageUtils.ShowError("错误的mac地址,请检查！")
            'End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOnlineWorkPrint", "OnlineWorkPrint", "sys")
        End Try
    End Sub
#End Region


    Private Sub FrmOnlineWorkPrint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtBarcode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtBarcode.PreviewKeyDown
        If e.KeyValue = 13 Then
            ' txtPassword.Focus()
        End If

    End Sub
End Class