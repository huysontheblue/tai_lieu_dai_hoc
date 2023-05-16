#Region "Imports"
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms.DataFormats
Imports MainFrame

#End Region
Public Class FrmSampleScan
    Public scanSetting As New SampleScanSetting

#Region "初期化"

    '快捷键
    Private Sub FrmWorkStantScan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                ToolStar_Click(sender, e)
                ''Case Keys.F2
                ''    toolCa_Click(sender, e)
            Case Keys.F10 '快捷键F10
                ' OpenProductionBoard()
            Case Keys.Alt + Keys.X
                Me.Close()
        End Select

    End Sub

    '初始化
    Private Sub FrmSampleScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitialUI()
    End Sub

    ''' <summary>
    ''' 初始化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitialUI()
        Me.lblMessage.Text = "请先设置基础资料"
        Me.lblMOID.Text = "" : Me.lblMOLot.Text = "" : Me.lblPartID.Text = ""
        Me.lblCartonQty.Text = ""

    End Sub

#End Region

#Region "事件"
    '基础设置
    Private Sub ToolStar_Click(sender As Object, e As EventArgs) Handles ToolStar.Click
        Try
            Dim FrmScanSet As New FrmSampleSet()
            FrmScanSet.Owner = Me
            Dim result As DialogResult = FrmScanSet.ShowDialog()
            If result = DialogResult.OK Then
                Me.lblMOID.Text = Data.MoidStr  '工單编号
                Me.lblPartID.Text = Data.PartidStr    '料件编号
                Me.lblMOLot.Text = Data.MoidqtyStr '工單数量
                Me.lblSampleNo.Text = Data.SampleNOStr '样品单号
                Me.lblMessage.Text = ""

                Call LoadDataToDataGrid()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleScan", "ToolStar_Click", "Sample")
        End Try
    End Sub
    '退出 
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '提交
    Private Sub btnCommit_Click(sender As Object, e As EventArgs)
        Try
            Dim o_iNowPerPackedQty As Integer = 0
            Me.lblMessage.Text = ""
            If Not BaseCheck() Then
                Exit Sub
            End If
            'Refresh the data
            LoadDataToDataGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleScan", "btnCommit_Click", "Sample")
            ' MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub tsbDisplayBoard_Click(sender As Object, e As EventArgs)
        ' OpenProductionBoard()
    End Sub

#End Region

#Region "方法"

    ''' <summary>
    ''' 取得扫描数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadDataToDataGrid()
        Dim orderIndex As Integer = 0
        Dim lsSQL As String = ""
        dgvScanInfo.Rows.Clear()
        Dim dt As DataTable = Nothing
        Try
            lsSQL = " SELECT TOP 1  SampleNO, StartTime,EndTime,UserID " & _
                    " FROM m_SampleScan_t     " & _
                    " WHERE MOID='" & Me.lblMOID.Text & "'"
            dt = DbOperateUtils.GetDataTable(lsSQL)
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                dgvScanInfo.Rows.Add(dt.Rows(rowIndex)!SampleNO,
                                     dt.Rows(rowIndex)!StartTime, dt.Rows(rowIndex)!EndTime,
                                     dt.Rows(rowIndex)!Userid)
            Next

            If dt.Rows.Count > 0 Then
                If DbOperateUtils.DBNullToStr(dt.Rows(0)!StartTime) <> "" Then
                    Me.txtSampleStart.Enabled = False
                    Me.txtSampleEnd.Enabled = True
                    ' Me.lblMessage.Text = "请刷入样品条码，记录结束时间"
                    SetMessage("", "请刷入样品条码，记录结束时间")
                    Me.txtSampleEnd.Text = ""
                    Me.txtSampleEnd.Focus()
                End If

                If DbOperateUtils.DBNullToStr(dt.Rows(0)!EndTime) <> "" Then
                    Me.txtSampleEnd.Enabled = False
                    '  Me.lblMessage.Text = "该样品单已经刷入结束时间，无需再扫描!"
                    SetMessage("W", "该样品单已经刷入结束时间，无需再扫描!")
                End If
            Else
                Me.txtSampleStart.Enabled = True
                Me.txtSampleEnd.Enabled = False
                Me.lblMessage.Text = "请刷入样品条码，记录开始生产时间"
                Me.txtSampleStart.Focus()
            End If
            dgvScanInfo.AutoResizeColumns()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "SampleManage.FrmSampleScan", "LoadDataToDataGrid", "Sample")
            Throw ex
        End Try
    End Sub


    '基础检查
    Private Function BaseCheck() As Boolean
        Return True
    End Function

#End Region

    Private Sub txtSampleStart_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtSampleStart.PreviewKeyDown
        If e.KeyValue = 13 Then
            Call ScanStartTimeProcess()
        End If
    End Sub

    Private Sub ScanStartTimeProcess()
        If (String.IsNullOrEmpty(Me.lblMOID.Text)) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.txtSampleStart.Text = ""
            ' PlaySimpleSound(1)
            Exit Sub
        End If

        If Me.txtSampleStart.Text.Trim <> Me.lblSampleNo.Text.Trim Then
            SetMessage("E", "刷入的样品条码与选择的样品单号不一致！")
            Me.txtSampleStart.Text = ""
            Me.txtSampleStart.Focus()
            Exit Sub
        End If

        Dim strSQL As String = ""
        '  @SampleNo VARCHAR(50), @UserID  varchar(20),@MOID  varchar(30),@TimeType varchar(10)
        strSQL = "  EXECUTE [m_SampleRecordProductTime_p] '{0}','{1}','{2}','{3}' "
        strSQL = String.Format(strSQL, Me.lblSampleNo.Text, SysMessageClass.UseId, Me.lblMOID.Text, "S")

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        ' Me.lblMessage.Text = " PASS, 记录开始时间成功！"
        SetMessage("", "PASS, 记录开始时间成功")
        Me.txtSampleEnd.Enabled = True
        Me.txtSampleEnd.Focus()
        'Add by cq 20161110,refesh the data
        Call GetScanItem()
    End Sub

#Region "获取子件掃描記錄"
    Private Sub GetScanItem()
        Dim orderIndex As Integer = 0
        Dim Dt As New DataTable
        Dim lsSQL As String = String.Empty
        Try
            If Me.dgvScanInfo.Rows.Count > 0 Then
                Me.dgvScanInfo.Rows.Clear()
            End If
            lsSQL = " SELECT   SampleNO, StartTime, EndTime, UserID  FROM m_SampleScan_t " & _
                    " Where SampleNO ='" & Me.lblSampleNo.Text.Trim & "' ORDER BY SampleNO"
            Dt = DbOperateUtils.GetDataTable(lsSQL)
            'While (Dt.Read())
            '    DGridBarCode.Rows.Add(Dt!PartID, Dt!Qty, Dt!ScanedQty, Dt!UserID, Dt!intime)
            'End While
            dgvScanInfo.DataSource = Dt

            dgvScanInfo.AutoResizeColumns()
        Catch ex As Exception
        End Try
    End Sub
#End Region

    Private Sub txtSampleEnd_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtSampleEnd.PreviewKeyDown
        If e.KeyValue = 13 Then
            Call ScanEndTimeProcess()
        End If
    End Sub


    Private Sub ScanEndTimeProcess()
        If (String.IsNullOrEmpty(Me.lblMOID.Text)) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.txtSampleStart.Text = ""
            ' PlaySimpleSound(1)
            Exit Sub
        End If

        If Me.txtSampleEnd.Text.Trim <> Me.lblSampleNo.Text.Trim Then    
            SetMessage("E", "刷入的样品条码与选择的样品单号不一致！")
            Me.txtSampleEnd.Text = ""
            Me.txtSampleEnd.Focus()
            Exit Sub
        End If

        Dim strSQL As String = ""
        '  @SampleNo VARCHAR(50), @UserID  varchar(20),@MOID  varchar(30),@TimeType varchar(10)
        strSQL = "  EXECUTE [m_SampleRecordProductTime_p] '{0}','{1}','{2}','{3}' "
        strSQL = String.Format(strSQL, Me.lblSampleNo.Text, SysMessageClass.UseId, Me.lblMOID.Text, "E")

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        ' Me.lblMessage.Text = " PASS, 记录结束时间成功！"
        SetMessage("", "PASS, 记录结束时间成功！")

        'Add by cq 20161110,refesh the data
        Call GetScanItem()
    End Sub


    Private Sub SetMessage(ByVal msgType As String, ByVal strMsg As String)
        Select Case msgType
            Case "E"
                Me.lblMessage.ForeColor = Color.Red
            Case "W"
                Me.lblMessage.ForeColor = Color.Yellow
            Case Else
                Me.lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
        End Select

        Me.lblMessage.Text = strMsg

    End Sub
End Class