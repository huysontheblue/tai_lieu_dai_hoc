Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Management

Public Class FrmOnlineWorkPrintanker
#Region "属性"
    Private m_printName As String
    Private m_stationId As String
    Private m_partId As String
    Private part As String
    Private btApp As BarTender.Application
    Private btFormat As BarTender.Format
    Public WriteOnly Property PrintName() As String
        Set(value As String)
            m_printName = value
        End Set
    End Property
    Public Sub New(ByVal Partid As String)

        InitializeComponent()
        part = Partid

    End Sub
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

        btApp = New BarTender.Application
        btFormat = New BarTender.Format
    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            If ScanCommon.IsTextBoxBlank(txtBarcode, "请输入产品条码!") = False Then Exit Sub
            If ScanCommon.IsTextBoxBlank(txtPassword, "请输入解锁密码!") = False Then Exit Sub
            If ScanCommon.IsOpenLock(txtPassword, "没有解锁权限!") = False Then Exit Sub
            OnlineWorkPrint(txtBarcode.Text)
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
            DbOperateUtils.ExecSQL("insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,moid,Userid,Intime)values('" & txtBarcode.Text & "','" & txtBarcode.Text & "',N'替换打印','" & SysMessageClass.UseId & "',getdate()" & ")")

            Me.Close()
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
    '在线打印制程外箱（华为零售）
    Private Sub OnlineWorkPrint(ByVal ppid As String)
        Try
            Dim strSql As String
            strSql = "select BatchNo,Stationid from m_WorkStationScanBatch_t where CartonStatus='Y' and exists(select 1 from m_WorkStationScanBatchD_t where m_WorkStationScanBatchD_t.BatchNo=m_WorkStationScanBatch_t.BatchNo and m_WorkStationScanBatchD_t.ppid='" & ppid & "' ) and stationid='" & Me.m_stationId & "'"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                Dim printBarcode As New PrintBarcode
                printBarcode.btApp = btApp
                printBarcode.btFormat = btFormat
                printBarcode.PrintName = Me.m_printName
                ' printBarcode.PrintOnlineWorkList(dt.Rows(0)!BatchNo.ToString, Me.m_partId, dt.Rows(0)!Stationid.ToString)
                printBarcode.PrintOnlineWifiList(dt.Rows(0)!BatchNo.ToString, Me.m_partId, dt.Rows(0)!Stationid.ToString)
            Else
                'L01联想打印彩盒 DJ
                strSql = "select ppid from V_M_L01BarcodeLink_t where semippid='" & ppid & "' "
                dt = DbOperateUtils.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    Dim printBarcode As New PrintBarcode
                    printBarcode.btApp = btApp
                    printBarcode.btFormat = btFormat
                    printBarcode.PrintName = Me.m_printName
                    printBarcode.PrintL01WorkList(ppid, Me.m_partId, WorkStantOption.vStandId)
                End If
            End If

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
            Dim strSql As String
            strSql = "select top 1 * from MESDB.dbo.m_GetUSBInfoSet_t where usey='Y' and PartID='" & part & "' order by Intime desc"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            Dim searcher As New ManagementObjectSearcher(dt.Rows(0)("Scope").ToString(), dt.Rows(0)("QueryString").ToString())
            Dim result As ManagementObjectCollection = searcher.Get()
            If (result Is Nothing) Or (result.Count = 0) Then

                txtBarcode.Text = ""
                Exit Sub
            End If
            For Each queryObj As ManagementObject In searcher.Get()
                For Each item As PropertyData In queryObj.Properties
                    Try
                        If item.Value <> "" Then
                            Dim convert = Split(item.Value, "\")
                            Dim _barcode As String = convert(dt.Rows(0)("Section").ToString()).ToString
                            txtBarcode.Text = _barcode
                           
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString())
                    End Try
                Next
            Next
            txtPassword.Focus()
        End If



    End Sub
End Class