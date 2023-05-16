Imports MainFrame.SysCheckData
Imports Aspose.Cells
Imports MainFrame

Public Class FrmBYscanrecord

    Public Shared Sub MydataTest(PPartid As String, moid As String, startingTime As DateTime, EndTime As DateTime)
        Dim BrowDialog As FolderBrowserDialog = New FolderBrowserDialog()
        BrowDialog.ShowNewFolderButton = True
        BrowDialog.Description = "请选择Excel保存位置"

        If BrowDialog.ShowDialog() = DialogResult.OK Then

            Try
                Dim MYpath As String = BrowDialog.SelectedPath
                Dim workbook As Workbook = New Workbook()
                workbook.Worksheets.Clear()
                Dim styleTitle As Style = workbook.Styles(workbook.Styles.Add())
                styleTitle.HorizontalAlignment = TextAlignmentType.Center
                styleTitle.Font.Name = "宋体"
                styleTitle.Font.Size = 18
                styleTitle.Font.IsBold = True
                Dim style2 As Style = workbook.Styles(workbook.Styles.Add())
                style2.HorizontalAlignment = TextAlignmentType.Center
                style2.Font.Name = "宋体"
                style2.Font.Size = 14
                style2.Font.IsBold = True
                style2.IsTextWrapped = True
                style2.Borders(BorderType.LeftBorder).LineStyle = CellBorderType.Thin
                style2.Borders(BorderType.RightBorder).LineStyle = CellBorderType.Thin
                style2.Borders(BorderType.TopBorder).LineStyle = CellBorderType.Thin
                style2.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Thin
                Dim style3 As Style = workbook.Styles(workbook.Styles.Add())
                style3.HorizontalAlignment = TextAlignmentType.Center
                style3.Font.Name = "宋体"
                style3.Font.Size = 12
                style3.Borders(BorderType.LeftBorder).LineStyle = CellBorderType.Thin
                style3.Borders(BorderType.RightBorder).LineStyle = CellBorderType.Thin
                style3.Borders(BorderType.TopBorder).LineStyle = CellBorderType.Thin
                style3.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Thin
                Dim tblDatas As DataTable = New DataTable()
                tblDatas.Columns.Add("Name", Type.[GetType]("System.String"))
                tblDatas.Rows.Add(New Object() {"工单"})
                tblDatas.Rows.Add(New Object() {"条码"})
                tblDatas.Rows.Add(New Object() {"工站"})
                tblDatas.Rows.Add(New Object() {"sitem"})
                tblDatas.Rows.Add(New Object() {"codeid"})
                tblDatas.Rows.Add(New Object() {"状态"})
                tblDatas.Rows.Add(New Object() {"线别"})
                tblDatas.Rows.Add(New Object() {"扫描电脑"})
                tblDatas.Rows.Add(New Object() {"扫描人员"})
                tblDatas.Rows.Add(New Object() {"扫描时间"})
                tblDatas.Rows.Add(New Object() {"Rstationid"})
                tblDatas.Rows.Add(New Object() {"Rstateid"})
                tblDatas.Rows.Add(New Object() {"Mark2"})
                tblDatas.Rows.Add(New Object() {"Mark3"})
                tblDatas.Rows.Add(New Object() {"ppidqty"})
                Dim path As String = System.IO.Path.Combine(MYpath, "BY扫描记录" & DateTime.Now.ToString("yyyy-MM-dd").Trim() & ".xls")
                Dim strSQL As String = ""
                If PPartid = "" Then
                    strSQL = " SELECT DISTINCT StaOrderid,a.Stationid ,b.Stationname FROM dbo.m_RPartStationD_t(NOLOCK) a " &
                        " LEFT JOIN m_Rstation_t(NOLOCK) b ON b.Stationid = a.Stationid " &
                        " LEFT JOIN m_Mainmo_t c ON c.PartID = a.PPartid WHERE c.Moid = '" + moid + "' " &
                        " AND Revid =(SELECT Revid FROM m_RPartStationM_t(NOLOCK) WHERE PPartid = c.PartID AND State = '1') " &
                        " ORDER BY StaOrderid"
                End If
                If moid = "" Then
                    strSQL = "SELECT DISTINCT StaOrderid,a.Stationid ,b.Stationname FROM dbo.m_RPartStationD_t(NOLOCK) a " &
                           " LEFT JOIN m_Rstation_t(NOLOCK) b ON b.Stationid = a.Stationid" &
                           " WHERE PPartid = '" + PPartid + "' " &
                           " AND Revid =(SELECT Revid FROM m_RPartStationM_t(NOLOCK) WHERE PPartid = '" + PPartid + "' AND State = '1')  ORDER BY StaOrderid"
                End If
                If moid <> "" And PPartid <> "" Then
                    strSQL = " SELECT DISTINCT StaOrderid,a.Stationid ,b.Stationname FROM dbo.m_RPartStationD_t(NOLOCK) a " &
                       " LEFT JOIN m_Rstation_t(NOLOCK) b ON b.Stationid = a.Stationid " &
                       " LEFT JOIN m_Mainmo_t c ON c.PartID = a.PPartid WHERE c.Moid = '" + moid + "' AND a.PPartid = '" + PPartid + "' " &
                       " AND Revid =(SELECT Revid FROM m_RPartStationM_t(NOLOCK) WHERE PPartid = '" + PPartid + "' AND State = '1') " &
                       " ORDER BY StaOrderid"
                End If
                Dim ds As DataTable = DbOperateUtils.GetDataTable(strSQL)
                Dim AssetModelName As DataTable = ds
                Dim StartDT As String = startingTime.ToString("yyyy/MM/dd HH:mm:ss")
                Dim EndDT As String = EndTime.ToString("yyyy/MM/dd HH:mm:ss")
                For i As Integer = 0 To AssetModelName.Rows.Count - 1
                    workbook.Worksheets.Add((i + 1).ToString() & "-" & AssetModelName.Rows(i)("Stationname").ToString().Trim())
                Next

                For j As Integer = 0 To AssetModelName.Rows.Count - 1
                    Dim sql As String = ""
                    If PPartid = "" Then
                        sql = "select * from m_assysnd_t(NOLOCK) where moid = '" + moid + "'and Stationid='" + ds.Rows(j)(1).ToString() + "'" &
                            " AND Intime>= '" + startingTime + "' AND  Intime <= '" + EndDT + "'"
                    End If
                    If moid = "" Then
                        sql = "select * from m_assysnd_t(NOLOCK) where moid in( select Moid from m_Mainmo_t(NOLOCK) where partid='" + PPartid + "')and Stationid='" + ds.Rows(j)(1).ToString() + "'" &
                                " AND Intime>= '" + startingTime + "' AND  Intime <= '" + EndDT + "' "
                    End If
                    If moid <> "" And PPartid <> "" Then
                         sql = "select * from m_assysnd_t(NOLOCK) where moid = '" + moid + "'and Stationid='" + ds.Rows(j)(1).ToString() + "'" &
                           " AND Intime>= '" + startingTime + "' AND  Intime <= '" + EndDT + "'"
                    End If
                    Dim da As DataTable = DbOperateUtils.GetDataTable(sql)
                    Dim dt As DataTable = da
                    Dim sheet0 As Worksheet = workbook.Worksheets(j)
                    Dim cells As Cells = sheet0.Cells

                    If dt IsNot Nothing Then
                        Dim Colnum As Integer = dt.Columns.Count
                        Dim Rownum As Integer = dt.Rows.Count
                        cells.Merge(0, 0, 1, Colnum)
                        cells(0, 0).PutValue(AssetModelName.Rows(j)("Stationname").ToString().Trim())
                        cells(0, 0).SetStyle(styleTitle)
                        cells.SetRowHeight(0, 38)

                        For i As Integer = 0 To Colnum - 1
                            cells(1, i).PutValue(tblDatas.Rows(i)("Name"))
                            cells(1, i).SetStyle(style2)
                        Next

                        cells.SetRowHeight(1, 30)
                        'cells.SetColumnWidth(0, 22)
                        'cells.SetColumnWidth(1, 22)
                        'cells.SetColumnWidth(14, 22)
                        Dim columnCount As Integer = cells.MaxColumn
                        Dim rowCount As Integer = cells.MaxRow

                        For col As Integer = 0 To columnCount - 1
                            sheet0.AutoFitColumn(col, 0, rowCount)
                        Next

                        For col As Integer = 0 To columnCount
                            cells.SetColumnWidthPixel(col, cells.GetColumnWidthPixel(col) + 60)
                        Next
                        For i As Integer = 0 To Rownum - 1

                            For k As Integer = 0 To Colnum - 1
                                cells(2 + i, k).PutValue(dt.Rows(i)(k).ToString())
                                cells(2 + i, k).SetStyle(style3)
                            Next

                            cells.SetRowHeight(2 + i, 17)
                        Next
                    End If
                Next

                workbook.Save(path)
                Process.Start(path)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End If
    End Sub

    Private Sub FrmBYscanrecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
    End Sub

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        If CobPart.Text.Trim() = "" And CobMo.Text.Trim() = "" Then
            MessageUtils.ShowError("请至少输入一个查询条件！")
            Exit Sub
        End If
        MydataTest(CobPart.Text.Trim(), CobMo.Text.Trim(), DtStar.Text.Trim(), DtEnd.Text.Trim())
    End Sub

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub
End Class