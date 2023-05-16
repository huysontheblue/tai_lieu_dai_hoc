Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Text

Public Class FrmNgTargetSetup
    Dim SLarge As String = "Z"
    Dim Stype As String = "X"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmNgTargetSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtYear.Text = Date.Now.Year.ToString
        SetDataGrid()
        Large.SelectedIndex = 0
        type.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
           
            If Large.Text = "制程不良目标率维护" Then
                SLarge = "Z"
            Else
                SLarge = "C"
            End If
            If type.Text = "系列别" Then
                Stype = "X"
                If SLarge = "Z" Then
                    dataGrid.Columns(1).HeaderText = "系列"
                    dataGrid.Columns(3).HeaderText = "不良类别"
                Else
                    dataGrid.Columns(1).HeaderText = "系列代码"
                    dataGrid.Columns(3).HeaderText = "系列名"
                End If
            ElseIf type.Text = "客户别" Then
                Stype = "K"
                If SLarge = "Z" Then
                    dataGrid.Columns(1).HeaderText = "客户"
                    dataGrid.Columns(3).HeaderText = "不良类别"
                Else
                    dataGrid.Columns(1).HeaderText = "客户代码"
                    dataGrid.Columns(3).HeaderText = "客户名"
                End If
            ElseIf type.Text = "项目代码" Then
                Stype = "M"
                If SLarge = "Z" Then
                    dataGrid.Columns(1).HeaderText = "项目代码"
                    dataGrid.Columns(3).HeaderText = "不良类别"
                Else
                    dataGrid.Columns(1).HeaderText = "项目代码"
                    dataGrid.Columns(3).HeaderText = "项目名"
                End If
            End If
            If String.IsNullOrEmpty(txtYear.Text.Trim) Then
                MessageUtils.ShowError("年度必须输入！")
                Me.txtYear.Focus()
                Exit Sub
            End If

            SetDataGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmNgTargetSetup", "btnSave_Click", "WIP")
        End Try
    End Sub

    Private Sub SetDataGrid()
        Dim dt As DataTable = GetExcelDataTable()
        If dt.Rows.Count = 0 Then
            MessageUtils.ShowError(String.Format("当年度{0}没有可设置的系列别！", Me.txtYear.Text.Trim))
            Exit Sub
        End If

        dataGrid.DataSource = dt

        dataGrid.MergeColumnNames.Add("SeriesName")

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            SaveData()
            MessageUtils.ShowInformation("保存成功！")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmNgTargetSetup", "btnSave_Click", "WIP")
        End Try
    End Sub

    Private Sub SaveData()
        Dim SeriesID As String
        Dim SeriesName As String
        Dim NgBigCatergoryId As String
        Dim NgBigCatergoryName As String
        Dim Quarter1 As String
        Dim Quarter2 As String
        Dim Quarter3 As String
        Dim Quarter4 As String
        Dim strSQLALL As String = ""
        If SLarge = "C" Then
            '保存数据
            For Each row As DataGridViewRow In dataGrid.Rows
                SeriesName = row.Cells("SeriesName").Value.ToString
                NgBigCatergoryName = row.Cells("NgBigCatergoryName").Value.ToString
                Quarter1 = row.Cells("Quarter1").Value.ToString
                Quarter2 = row.Cells("Quarter2").Value.ToString
                Quarter3 = row.Cells("Quarter3").Value.ToString
                Quarter4 = row.Cells("Quarter4").Value.ToString
                If String.IsNullOrEmpty(Quarter1) = True AndAlso String.IsNullOrEmpty(Quarter2) = True AndAlso
                    String.IsNullOrEmpty(Quarter3) = True AndAlso String.IsNullOrEmpty(Quarter4) = True Then
                    Continue For
                End If
                strSQLALL = strSQLALL.ToString & GetTMainAddSQL(SeriesName, NgBigCatergoryName, Quarter1, Quarter2, Quarter3, Quarter4, SLarge, Stype)
            Next

        Else
            '保存数据
            For Each row As DataGridViewRow In dataGrid.Rows
                SeriesID = row.Cells("SeriesID").Value.ToString
                SeriesName = row.Cells("SeriesName").Value.ToString
                NgBigCatergoryId = row.Cells("NgBigCatergoryId").Value.ToString
                NgBigCatergoryName = row.Cells("NgBigCatergoryName").Value.ToString
                Quarter1 = row.Cells("Quarter1").Value.ToString
                Quarter2 = row.Cells("Quarter2").Value.ToString
                Quarter3 = row.Cells("Quarter3").Value.ToString
                Quarter4 = row.Cells("Quarter4").Value.ToString
                If String.IsNullOrEmpty(Quarter1) = True AndAlso String.IsNullOrEmpty(Quarter2) = True AndAlso
                    String.IsNullOrEmpty(Quarter3) = True AndAlso String.IsNullOrEmpty(Quarter4) = True Then
                    Continue For
                End If
                strSQLALL = strSQLALL.ToString & GetMainAddSQL(SeriesID, SeriesName, NgBigCatergoryId, NgBigCatergoryName, Quarter1, Quarter2, Quarter3, Quarter4, SLarge, Stype)
            Next
        End If

       

        DbOperateUtils.ExecSQL(strSQLALL)

    End Sub

    '退出
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function GetTMainAddSQL(SeriesName As String, NgBigCatergoryName As String,
                                  Quarter1 As String, Quarter2 As String, Quarter3 As String, Quarter4 As String, Large As String, type As String) As String

        Quarter1 = SetBalnkValue(Quarter1)
        Quarter2 = SetBalnkValue(Quarter2)
        Quarter3 = SetBalnkValue(Quarter3)
        Quarter4 = SetBalnkValue(Quarter4)

        Dim strSQLInsert As String = " INSERT INTO m_SeriesNgTarget_t" &
                               "([YEAR],[SeriesID],[NgBigCatergoryId],[SeriesName],[NgBigCatergoryName] " &
                               " ,[Quarter1],[Quarter2],[Quarter3],[Quarter4],FactoryId,profitcenter,[Large],[type])"
        Dim sbSQL As New StringBuilder

        sbSQL.AppendFormat(" IF EXISTS(SELECT 1 FROM m_SeriesNgTarget_t WHERE YEAR = '{0}' AND FactoryId = '{1}' AND profitcenter = '{2}' ",
                               Me.txtYear.Text.Trim, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
        sbSQL.AppendFormat("           AND SeriesID = '{0}' AND Large = '{1}' AND [type] = N'{2}' AND NgBigCatergoryId ='{3}') BEGIN ", SeriesName, Large, type, SeriesName)
        sbSQL.AppendFormat(" UPDATE m_SeriesNgTarget_t ")
        sbSQL.AppendFormat(" SET Quarter1 = '{0}',", Quarter1)
        sbSQL.AppendFormat("  Quarter2 = '{0}',", Quarter2)
        sbSQL.AppendFormat("  Quarter3 = '{0}',", Quarter3)
        sbSQL.AppendFormat("  Quarter4 = '{0}' ", Quarter4)
        sbSQL.AppendFormat("  WHERE YEAR = '{0}' AND FactoryId = '{1}' AND profitcenter = '{2}' ",
                                  Me.txtYear.Text, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
        sbSQL.AppendFormat("  AND SeriesID = '{0}' AND Large = '{1}' AND [type] = N'{2}'; ", SeriesName, Large, type)
        sbSQL.AppendFormat(" END ELSE BEGIN")
        sbSQL.AppendFormat(strSQLInsert)
        sbSQL.AppendFormat("VALUES(")
        sbSQL.AppendFormat("'{0}',", Me.txtYear.Text.Trim)
        sbSQL.AppendFormat("'{0}',", SeriesName)
        sbSQL.AppendFormat("'{0}',", SeriesName)
        sbSQL.AppendFormat("N'{0}',", SeriesName)
        sbSQL.AppendFormat("N'{0}',", NgBigCatergoryName)
        sbSQL.AppendFormat("'{0}',", Quarter1)
        sbSQL.AppendFormat("'{0}',", Quarter2)
        sbSQL.AppendFormat("'{0}',", Quarter3)
        sbSQL.AppendFormat("'{0}',", Quarter4)
        sbSQL.AppendFormat("'{0}',", VbCommClass.VbCommClass.Factory)
        sbSQL.AppendFormat("'{0}',", VbCommClass.VbCommClass.profitcenter)
        sbSQL.AppendFormat("'{0}',", Large)
        sbSQL.AppendFormat("N'{0}')", type)
        sbSQL.AppendFormat(" END ")

        Return sbSQL.ToString
    End Function
    Private Function GetMainAddSQL(SeriesID As String, SeriesName As String, NgBigCatergoryId As String, NgBigCatergoryName As String,
                                   Quarter1 As String, Quarter2 As String, Quarter3 As String, Quarter4 As String, Large As String, type As String) As String

        Quarter1 = SetBalnkValue(Quarter1)
        Quarter2 = SetBalnkValue(Quarter2)
        Quarter3 = SetBalnkValue(Quarter3)
        Quarter4 = SetBalnkValue(Quarter4)

        Dim strSQLInsert As String = " INSERT INTO m_SeriesNgTarget_t" &
                               "([YEAR],[SeriesID],[NgBigCatergoryId],[SeriesName],[NgBigCatergoryName] " &
                               " ,[Quarter1],[Quarter2],[Quarter3],[Quarter4],FactoryId,profitcenter,[Large],[type])"
        Dim sbSQL As New StringBuilder

        sbSQL.AppendFormat(" IF EXISTS(SELECT 1 FROM m_SeriesNgTarget_t WHERE YEAR = '{0}' AND FactoryId = '{1}' AND profitcenter = '{2}' ",
                               Me.txtYear.Text.Trim, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
        sbSQL.AppendFormat("           AND SeriesID = '{0}' AND NgBigCatergoryId = '{1}'AND [type] = N'{2}' ) BEGIN ", SeriesID, NgBigCatergoryId, type)
        sbSQL.AppendFormat(" UPDATE m_SeriesNgTarget_t ")
        sbSQL.AppendFormat(" SET Quarter1 = '{0}',", Quarter1)
        sbSQL.AppendFormat("  Quarter2 = '{0}',", Quarter2)
        sbSQL.AppendFormat("  Quarter3 = '{0}',", Quarter3)
        sbSQL.AppendFormat("  Quarter4 = '{0}' ", Quarter4)
        sbSQL.AppendFormat("  WHERE YEAR = '{0}' AND FactoryId = '{1}' AND profitcenter = '{2}' ",
                                  Me.txtYear.Text, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
        sbSQL.AppendFormat("  AND SeriesID = '{0}' AND NgBigCatergoryId = '{1}'; ", SeriesID, NgBigCatergoryId)
        sbSQL.AppendFormat(" END ELSE BEGIN")
        sbSQL.AppendFormat(strSQLInsert)
        sbSQL.AppendFormat("VALUES(")
        sbSQL.AppendFormat("'{0}',", Me.txtYear.Text.Trim)
        sbSQL.AppendFormat("'{0}',", SeriesID)
        sbSQL.AppendFormat("N'{0}',", NgBigCatergoryId)
        sbSQL.AppendFormat("N'{0}',", SeriesName)
        sbSQL.AppendFormat("N'{0}',", NgBigCatergoryName)
        sbSQL.AppendFormat("'{0}',", Quarter1)
        sbSQL.AppendFormat("'{0}',", Quarter2)
        sbSQL.AppendFormat("'{0}',", Quarter3)
        sbSQL.AppendFormat("'{0}',", Quarter4)
        sbSQL.AppendFormat("'{0}',", VbCommClass.VbCommClass.Factory)
        sbSQL.AppendFormat("'{0}',", VbCommClass.VbCommClass.profitcenter)
        sbSQL.AppendFormat("'{0}',", Large)
        sbSQL.AppendFormat("N'{0}')", type)
        sbSQL.AppendFormat(" END ")

        Return sbSQL.ToString
    End Function

    '取得导出数据
    Private Function GetExcelDataTable() As DataTable
        Dim strSQL As String
        Dim UserID As String = VbCommClass.VbCommClass.UseId 'add by 马跃平2017-12-20 王倩提出需求
        strSQL = "EXEC m_QueryTotalGetSeriesNgTarget '{0}', '{1}', '{2}','{3}',N'{4}',N'{5}'"
        strSQL = String.Format(strSQL, Me.txtYear.Text.Trim, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, UserID, SLarge, Stype)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Return dt
    End Function

    Private Sub dataGrid_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dataGrid.DataError
        If (e.Exception IsNot Nothing) Then
            MessageUtils.ShowError("输入值格式不正确，请重新输入！")
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Function SetBalnkValue(target As String) As String
        Dim result As String = "0"
        If String.IsNullOrEmpty(target) = False Then
            result = target
        End If
        Return result
    End Function

#Region "Grid行数"
    Private Sub dataGrid_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dataGrid.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

End Class