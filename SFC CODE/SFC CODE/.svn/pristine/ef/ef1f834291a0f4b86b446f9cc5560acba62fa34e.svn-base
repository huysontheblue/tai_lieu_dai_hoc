Imports MainFrame
Imports System.Text
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle

Public Class FrmRCardLog

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

        lssql = " SELECT TOP 200 ID, a.PartID ,b.StationName,type ,c.UserName ,a.OldModifyTime ," & _
                " OldValue ,d.UserName as NewUserID , a.NewModifyTime , a.NewValue  " & _
                " FROM m_RCardChangeLog_t a left join m_RStation_t b on a.stationid = b.stationid" & _
                " LEFT JOIN m_Users_t c ON a.OldUserID = c.UserID" & _
                " LEFT JOIN m_Users_t d ON a.NewUserID = d.UserID" & _
                " WHERE 1=1 "
        If Not String.IsNullOrEmpty(Me.txtPartID.Text) Then
            '  lssql = lssql + " And a.partid='" & Me.txtPartID.Text.Trim & "'"
            lssql &= " And a.partid='" & Me.txtPartID.Text.Trim & "'"
            sqlWhere = " And a.partid='" & Me.txtPartID.Text.Trim & "'"
        End If

        '右键点击工站，直接查询
        If Not String.IsNullOrEmpty(Me.txtStationID.Text) Then
            lssql = lssql + " And a.Stationid='" & Me.txtStationID.Text.Trim & "'"
            sqlWhere &= " And a.Stationid='" & Me.txtStationID.Text.Trim & "'"
        End If

        lssql &= " ORDER BY a.ID DESC"

        lssql = lssql + " SELECT COUNT(1)  FROM m_RCardChangeLog_t a   left join m_RStation_t b on a.stationid = b.stationid  " & _
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
        dgvRCardChangeLog.AllowUserToResizeColumns =True
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
            SqlStr = " SELECT  a.ID,a.PartID," & _
                     " b.StationName, type, c.UserName,  OldModifyTime,OldValue," & _
                     " d.UserName as NewUserID,a.NewModifyTime,a.NewValue " & _
                     " from  m_RCardChangeLog_t  a left join m_RStation_t b on a.stationid = b.stationid " & _
                    " LEFT JOIN m_Users_t c ON a.OldUserID = c.UserID" & _
                    " LEFT JOIN m_Users_t d ON a.NewUserID = d.UserID" & _
                    "  WHERE 1=1 " & _
                    "  " & SqlWhere & " " & _
                    " order by ID desc "
        Else
            SqlStr = " SELECT TOP 200 a.ID,a.PartID," & _
                  " b.StationName, type, c.UserName,  OldModifyTime,OldValue," & _
                  " d.UserName as NewUserID,a.NewModifyTime,a.NewValue " & _
                  " from  m_RCardChangeLog_t  a left join m_RStation_t b on a.stationid = b.stationid " & _
                 " LEFT JOIN m_Users_t c ON a.OldUserID = c.UserID" & _
                 " LEFT JOIN m_Users_t d ON a.NewUserID = d.UserID" & _
                 "  WHERE 1=1 " & _
                 "  " & SqlWhere & " " & _
                 " order by ID desc "
        End If


        'lssql = " SELECT ID, a.PartID 产品编号,b.StationName 工站名,type 变更类型,c.UserName 修改前人,a.OldModifyTime 修改前时间," & _
        '     " OldValue 修改前内容,d.UserName 修改后人, a.NewModifyTime 修改后时间, a.NewValue 修改后内容 " & _
        '     " FROM m_RCardChangeLog_t a left join m_RStation_t b on a.stationid = b.stationid" & _
        '     " LEFT JOIN m_Users_t c ON a.OldUserID = c.UserID" & _
        '     " LEFT JOIN m_Users_t d ON a.NewUserID = d.UserID" & _
        '     " WHERE a.partid='" & Me.txtPartID.Text.Trim & "'"

        SqlStr = SqlStr + " SELECT COUNT(1)  FROM m_RCardChangeLog_t a   left join m_RStation_t b on a.stationid = b.stationid  " & _
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
            ' dgvChilds.Rows.Clear()
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

            filePath = VbCommClass.VbCommClass.SopFilePath.Substring(0, VbCommClass.VbCommClass.SopFilePath.Length - 8) + "RunCard\RunCardLogTemplate.xlsx"
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
    '    item.Cells(RunCardBusiness.RCardLogGrid.NewModifyTime.ToString).Style.BackColor = Color.MistyRose
    '    item.Cells(RunCardBusiness.RCardLogGrid.NewValue.ToString).Style.BackColor = Color.MistyRose
    '    item.Cells(RunCardBusiness.RCardLogGrid.NewUserID.ToString).Style.BackColor = Color.MistyRose
            'If IsDBNull(item.Cells(RunCardBusiness.RCardLogGrid..ToString).Value) Then
            '    tempSectionID = ""
            'Else
            '    tempSectionID = CStr(item.Cells(RunCardBusiness.BodyGrid.SectionID.ToString).Value)
            'End If
            ' tempSectionID = CStr(IIf(IsDBNull(item.Cells(RunCardBusiness.BodyGrid.SectionID.ToString).Value), "", CStr(item.Cells(RunCardBusiness.BodyGrid.SectionID.ToString).Value)))
            'Select Case tempSectionID
            '    Case "1", "01" '前段加工
            '        item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.LightGreen
            '    Case "2", "02" '产线加工
            '        item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.Aqua
            '    Case "3", "03" '成型加工
            '        item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.PeachPuff
            '    Case "4", "04"
            '        item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.WhiteSmoke
            '    Case "5", "05"
            '        item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.MistyRose
            '    Case "A05"
            '        item.Cells(RunCardBusiness.BodyGrid.StationName.ToString).Style.BackColor = Color.Tomato
            '    Case Else
            '        'do nothing
            'End Select
    ' Next


    'End Sub

    Private Sub ToolRefrech_Click(sender As Object, e As EventArgs) Handles ToolRefrech.Click
        LoadDataToDatagridview("")
    End Sub
End Class