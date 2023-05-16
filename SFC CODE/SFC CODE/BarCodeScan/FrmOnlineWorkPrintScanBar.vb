Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData
Public Class FrmOnlineWorkPrintScanBar
#Region "属性"
    Private m_printName As String
    Private m_stationId As String
    Private m_partId As String
    Private btApp As BarTender.Application
    Private btFormat As BarTender.Format
    Public m_strRemark As String = ""
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
            If ScanCommon.IsTextBoxBlank(txtBarcode, "请输入条码!") = False Then Exit Sub
            '  If ScanCommon.IsTextBoxBlank(txtPassword, "请输入解锁密码!") = False Then Exit Sub
            '  If ScanCommon.IsOpenLock(txtPassword, "没有解锁权限!") = False Then Exit Sub

            If Not CheckIsPrint(txtBarcode.Text) Then
                'do nothing
            Else
                'reprint
                Dim form2 As FrmRePrint = New FrmRePrint(txtBarcode.Text)
                form2.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
                If (form2.ShowDialog() = DialogResult.OK) Then
                    Me.txtPRemark.Text = form2.m_strRemark
                    'Me.txtBarcode.Text = ""
                Else
                    Me.txtBarcode.Text = ""
                    Exit Sub
                End If
            End If

            OnlineWorkPrint(txtBarcode.Text.Trim)
            'btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            'System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
            ' Me.Close()
            If Not String.IsNullOrEmpty(txtBarcode.Text.Trim) Then
                Insert(txtBarcode.Text.Trim)
            End If
            Me.txtBarcode.Text = String.Empty
            Me.txtPRemark.Text = String.Empty
            Me.txtBarcode.Focus()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmOnlineWorkPrint", "BnOpenlock_Click", "sys")
        End Try
    End Sub

    Private Sub Insert(ByVal sn As String)
        Dim line As String = "XT001"
        ' Dim version As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
        Dim sql As String = "insert into m_MSM06OnlinePrint_t (ppid,line,intime,remark) values ('" & sn & "','" & line & "',getdate(),N'" & Me.txtPRemark.Text.Trim & "')"
        DbOperateUtils.ExecSQL(sql)
    End Sub


    ''' <summary>
    ''' 检查是否已经打印
    ''' </summary>
    ''' <param name="sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckIsPrint(ByVal sn As String) As Boolean
        Dim dt As DataTable = New DataTable()
        Dim sql As String = "select ppid from m_MSM06OnlinePrint_t where ppid='" & sn & "'"
        dt = DbOperateUtils.GetDataTable(sql)

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

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
                'Dim printBarcode As New PrintBarcode
                'printBarcode.btApp = btApp
                'printBarcode.btFormat = btFormat
                'printBarcode.PrintName = Me.m_printName
                'printBarcode.PrintOnlineWorkList(dt.Rows(0)!BatchNo.ToString, Me.m_partId, dt.Rows(0)!Stationid.ToString)
            Else
                'L01联想打印彩盒 DJ
                ' strSql = "SELECT macaddress AS ppid FROM MESDataCenter.DBO.m_Lnv6MACRead_t where macaddress='" & ppid & "' "
                ' dt = DbOperateUtils.GetDataTable(strSql)
                ' If dt.Rows.Count > 0 Then
                btApp = New BarTender.Application
                btFormat = New BarTender.Format
                Dim printBarcode As New PrintBarcode
                printBarcode.btApp = btApp
                printBarcode.btFormat = btFormat
                printBarcode.PrintName = Me.m_printName
                ' printBarcode.PrintL01MAC(ppid, Me.m_partId, WorkStantOption.vStandId)
                printBarcode.PrintScanBar(ppid, Me.m_partId, WorkStantOption.vStandId)
                ' Else
                '  MessageUtils.ShowError("错误的mac地址,请检查！")
                'End If
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
            ' txtPassword.Focus()
        End If



    End Sub
End Class