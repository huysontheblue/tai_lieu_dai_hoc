Imports MainFrame
Imports System.Text
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle

Public Class FrmSOPLog

    Private _sqlWhere As String = ""
    Public Property sqlWhere() As String
        Get
            Return _sqlWhere
        End Get

        Set(ByVal Value As String)
            _sqlWhere = Value
        End Set
    End Property

    Private _dtOutLog As DataTable
    Public Property dtOutLog() As DataTable
        Get
            Return _dtOutLog
        End Get

        Set(ByVal Value As DataTable)
            _dtOutLog = Value
        End Set
    End Property


    Private Sub FrmRCardLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim lssql As String = ""
        Dim sqlWhere As String = String.Empty

        lssql = " SELECT TOP 200 ID, a.SOPName ,a.StationID as StationName ,type ,c.UserName as OldUserID ,a.OldModifyTime ," & _
                " OldValue ,d.UserName as NewUserID , a.NewModifyTime , a.NewValue  " & _
                " FROM m_SOPChangeLog_t a " & _
                " LEFT JOIN m_Users_t c ON a.OldUserID = c.UserID" & _
                " LEFT JOIN m_Users_t d ON a.NewUserID = d.UserID" & _
                " WHERE 1=1 "
        If Not String.IsNullOrEmpty(Me.txtDocID.Text) Then
            '  lssql = lssql + " And a.partid='" & Me.txtPartID.Text.Trim & "'"
            lssql &= " And a.DocID=N'" & Me.txtDocID.Text.Trim & "'"
            sqlWhere = " And a.DocID=N'" & Me.txtDocID.Text.Trim & "'"
        End If



        '右键点击工站，直接查询
        If Not String.IsNullOrEmpty(Me.txtStationID.Text) Then
            lssql = lssql + " And a.Stationid=N'" & Me.txtStationID.Text.Trim & "'"
            sqlWhere &= " And a.Stationid=N'" & Me.txtStationID.Text.Trim & "'"
        End If

        lssql &= " ORDER BY a.ID DESC"

        lssql = lssql + " SELECT COUNT(1)  FROM m_SOPChangeLog_t a  " & _
           " LEFT JOIN m_Users_t c ON a.OldUserID = c.UserID" & _
            " LEFT JOIN m_Users_t d ON a.NewUserID = d.UserID" & _
          " WHERE 1=1  " & sqlWhere

        Using o_ds As DataSet = DbOperateUtils.GetDataSet(lssql)
            If Not IsNothing(o_ds.Tables(0)) AndAlso o_ds.Tables(0).Rows.Count > 0 Then
                dgvRCardChangeLog.DataSource = o_ds.Tables(0)
                dtOutLog = o_ds.Tables(0)

                toolStripStatusLabel3.Text = CStr(Me.dgvRCardChangeLog.Rows.Count) + "/总笔数:" + IIf(DbOperateUtils.DBNullToStr(o_ds.Tables(1).Rows(0).Item(0)) = "0", "0", CStr(o_ds.Tables(1).Rows(0).Item(0)))

            End If
        End Using
        '   dgvRCardChangeLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvRCardChangeLog.AllowUserToResizeColumns = True
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim frmRCarLogQuerySet As New FrmRCardLogQuery()
        frmRCarLogQuerySet.Owner = Me
        frmRCarLogQuerySet.ShowDialog()
        If frmRCarLogQuerySet.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.sqlWhere = frmRCarLogQuerySet.sqlWhere
        End If
        LoadDataToDatagridview(Me.sqlWhere)
    End Sub


    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim SqlStr As String = "", QuoteNo As String = ""
        If Me.chkAll.Checked = True Then
            SqlStr = " SELECT  a.ID,a.SOPName," & _
                     " a.StationId as StationName, type, c.UserName as OldUserID,  OldModifyTime,OldValue," & _
                     " d.UserName as NewUserID,a.NewModifyTime,a.NewValue " & _
                     " from  m_SOPChangeLog_t  a " & _
                    " LEFT JOIN m_Users_t c ON a.OldUserID = c.UserID" & _
                    " LEFT JOIN m_Users_t d ON a.NewUserID = d.UserID" & _
                    "  WHERE 1=1 " & _
                    "  " & SqlWhere & " " & _
                    " order by ID desc "
        Else
            SqlStr = " SELECT TOP 200 a.ID,a.SOPName," & _
                  " a.stationID as StationName, type, c.UserName as OldUserID,  OldModifyTime,OldValue," & _
                  " d.UserName as NewUserID,a.NewModifyTime,a.NewValue " & _
                  " FROM  m_SOPChangeLog_t  a " & _
                 " LEFT JOIN m_Users_t c ON a.OldUserID = c.UserID" & _
                 " LEFT JOIN m_Users_t d ON a.NewUserID = d.UserID" & _
                 "  WHERE 1=1 " & _
                 "  " & SqlWhere & " " & _
                 " order by ID desc "
        End If


        SqlStr = SqlStr + " SELECT COUNT(1)  FROM m_SOPChangeLog_t a   " & _
                          " LEFT JOIN m_Users_t c ON a.OldUserID = c.UserID" & _
                 " LEFT JOIN m_Users_t d ON a.NewUserID = d.UserID" & _
               " WHERE 1=1  " & SqlWhere

        Dim ds As DataSet = DbOperateUtils.GetDataSet(SqlStr)
        If ds.Tables.Count > 0 AndAlso (Not IsNothing(ds.Tables(0))) Then 'dt.Rows.Count > 0 Then
            '  dgvRCardChangeLog.AutoGenerateColumns = False
            dgvRCardChangeLog.DataSource = ds.Tables(0) 'dt
            _dtOutLog = ds.Tables(0)
            toolStripStatusLabel3.Text = CStr(Me.dgvRCardChangeLog.Rows.Count) + "/总笔数:" + IIf(DbOperateUtils.DBNullToStr(ds.Tables(1).Rows(0).Item(0)) = "0", "0", CStr(ds.Tables(1).Rows(0).Item(0)))
            If dgvRCardChangeLog.Rows.Count > 0 Then
                '  QuoteNo = dgvRCardChangeLog.Rows(0).Cells(enumdgvRStation.QuoteNo).Value  '14
            Else
                Exit Sub
            End If
            '  dgvRCardChangeLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            ' GridViewBound(QuoteNo)
        Else
            dgvRCardChangeLog.DataSource = Nothing
        End If
    End Sub


    Private Sub toolMain_Click(sender As Object, e As EventArgs) Handles toolMain.Click
        Dim strPath As String = ""
        Dim frmStation As New FrmRunCardImportStation("", "Export", False)
        frmStation.SelectExportPath("RunCard", strPath)

        Call DoExportLog(strPath)
    End Sub

    Private Sub DoExportLog(ByVal strPath As String)
        Dim o_outputFile As String = ""
        Dim errorMsg As String = Nothing
        Dim filePath As String = ""
        Try

            filePath = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\OnlineSop\SOPLogTemplate.xlsx"
            o_outputFile = strPath + "\" & Date.Now.ToString("yyyyMMddHHmmss") & ".xlsx"

            Dim frmStation As New FrmRunCardImportStation("", "Export", False)
            ' frmStation.runCardPn = Me.RunCardPn
            If IsNothing(_dtOutLog) OrElse _dtOutLog.Rows.Count <= 0 Then
                MessageUtils.ShowError("找不到对应的流程卡修改日志信息！")
                Exit Sub
            End If

            Using dt As DataTable = _dtOutLog
                If dt.Rows.Count > 0 Then
                    dt.TableName = "RunCard"
                    If SysDataBaseClass.Import2ExcelByAs(filePath, o_outputFile, dt, frmStation.GetNoVariablesLog(dt), errorMsg) Then
                        'Using frmshow As New FrmShowRunCard()
                        '    frmshow.filePath = o_outputFile
                        '    frmshow.ShowDialog()
                        'End Using
                    Else
                        MessageUtils.ShowError(errorMsg)
                    End If
                Else
                    MessageUtils.ShowError("找不到对应的流程卡修改日志信息！")
                    Exit Sub
                End If
            End Using

            MessageBox.Show("导出成功,请查看！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCard", "DoExportLog", "RCard")
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function GetLogTable()
        Try
            Dim DtGrid As DataTable
            DtGrid = CType(dgvRCardChangeLog.DataSource, DataTable).Copy()
            Return GetLogTable
        Catch ex As Exception

        End Try
    End Function

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    ' Private Sub dgvRCardChangeLog_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvRCardChangeLog.DataBindingComplete

    ' dgvRCardChangeLog.Rows
    'For Each item As DataGridViewRow In dgvRCardChangeLog.Rows


    Private Sub ToolRefrech_Click(sender As Object, e As EventArgs) Handles ToolRefrech.Click
        LoadDataToDatagridview("")
    End Sub
End Class