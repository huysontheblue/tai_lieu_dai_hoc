'--MES资料获取类
'--Create by :　马锋
'--Create date :　2015/07/22
'--Ver : V01
'--Update date :  
'--

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports Microsoft.Office.Interop
Imports Aspose.Cells
#End Region

Public Class GetMesData

    Private Shared Property DateTime As Date

    Public Shared Function GetDateTime() As DateTime
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim strTemp As DateTime

        Try

            Dim strSQL As String

            strSQL = " SELECT GETDATE() "

            DateTime = Convert.ToDateTime(Conn.GetDataTable(strSQL).Rows(0).Item(0).ToString)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return DateTime
    End Function

    Public Shared Function GetLineList(ByVal strLineId As String) As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dtTemp As DataTable

        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strLineId)) Then
                strWhere = " AND LINEID LIKE '%" & strLineId & "%'"
            End If
            strSQL = "SELECT DEPTID, LINEID FROM DEPTLINE_T WHERE USEY = 'Y' " & strWhere

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetUserList(ByVal strUser As String) As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dtTemp As DataTable

        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strUser)) Then
                strWhere = " WHERE UserID='" & strUser & "'"
            End If
            strSQL = "SELECT UserID, UserName, Dept, Descript FROM m_Users_t " & strWhere

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetDeptList(ByVal strFactoryId As String, ByVal strProfitcenter As String, ByVal strDeptCode As String) As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dtTemp As DataTable

        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strDeptCode)) Then
                strWhere = " WHERE djc='" & strDeptCode & "'"
            End If

            If (String.IsNullOrEmpty(strDeptCode)) Then
                strSQL = "SELECT djc AS DeptCode, dqc AS DeptName FROM m_Dept_t "
            Else
                strSQL = "SELECT djc AS DeptCode, dqc AS DeptName FROM m_Dept_t " & strWhere
            End If

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetProductionPlan(ByVal strFactoryId As String, ByVal strProfitcenter As String, ByVal strTransactionId As String) As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dtTemp As DataTable

        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strTransactionId)) Then
                strWhere = " AND TransactionId='" & strTransactionId & "'"
            End If
            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY ProductionPlanId )as RowNum, ProductionPlanId, FactoryId, Profitcenter, TransactionId, PlanMonth, OrderNumber, DeptId, DeptName, Remark, CheckUser, " & _
                     " CheckTime, StatusFlag, DeleteFlag, CreateTime, CreateUser, CASE StatusFlag WHEN '1' THEN N'有效' ELSE N'无效'  END AS StatusFlagName FROM m_ProductionPlan_t WHERE FactoryId='" & strFactoryId & "' AND Profitcenter='" & strProfitcenter & "' " & strWhere

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetProductionPlanItem(ByVal strFactoryId As String, ByVal strProfitcenter As String, ByVal strTransactionId As String) As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dtTemp As DataTable

        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strTransactionId)) Then
                strWhere = " AND m_ProductionPlanItem_t.TransactionId='" & strTransactionId & "'"
            End If
            strSQL = "SELECT  ROW_NUMBER()OVER(ORDER BY ProductionPlanItemId )as RowNum, m_ProductionPlanItem_t.ProductionPlanItemId, m_ProductionPlanItem_t.TransactionId, m_ProductionPlanItem_t.PlanMonth, m_ProductionPlanItem_t.MaterialNO, m_ProductionPlanItem_t.MOID, m_ProductionPlanItem_t.LineId, m_ProductionPlanItem_t.LineName, m_ProductionPlanItem_t.DeptId, m_ProductionPlanItem_t.DeptName, m_ProductionPlanItem_t.ProductionQuantity, " & _
            " m_ProductionPlanItem_t.CustomerId, m_ProductionPlanItem_t.CustomerName, m_ProductionPlanItem_t.UnfinishedQuantity, m_ProductionPlanItem_t.ExpectedDate, m_ProductionPlanItem_t.SingleDay, m_ProductionPlanItem_t.StandardWorkingHours, m_ProductionPlanItem_t.ManpowerNumber, m_ProductionPlanItem_t.Effectiveness," & _
            " m_ProductionPlanItem_t.EstimatedDays, m_ProductionPlanItem_t.ExpectedCapacity, m_ProductionPlanItem_t.ProductionDays, m_ProductionPlanItem_t.WKone, m_ProductionPlanItem_t.WKtwo, m_ProductionPlanItem_t.NOYieldQuantity, m_ProductionPlanItem_t.Remark, m_ProductionPlanItem_t.LineUserName, CASE StatusFlag WHEN '1' THEN N'有效' ELSE N'无效'  END AS StatusFlagName, " & _
            " m_ProductionPlanItem_t.StatusFlag, m_ProductionPlanItem_t.DeleteFlag, m_ProductionPlanItem_t.UpdateTime, m_ProductionPlanItem_t.UpdateUser, m_ProductionPlanItem_t.CreateTime, m_PlanDailyWork_t.DailyWorkOne, m_PlanDailyWork_t.DailyWorkTwo, m_PlanDailyWork_t.DailyWorkThree," & _
            " m_PlanDailyWork_t.DailyWorkFour, m_PlanDailyWork_t.DailyWorkFive, m_PlanDailyWork_t.DailyWorkSix, m_PlanDailyWork_t.DailyWorkSeven, m_PlanDailyWork_t.DailyWorkEight, m_PlanDailyWork_t.DailyWorkNine, m_PlanDailyWork_t.DailyWorkTen, m_PlanDailyWork_t.DailyWorkEleven," & _
            " m_PlanDailyWork_t.DailyWorkTwelve, m_PlanDailyWork_t.DailyWorkThirteen, m_PlanDailyWork_t.DailyWorkFourteen, m_PlanDailyWork_t.DailyWorkFifteen, m_PlanDailyWork_t.DailyWorkSixteen, m_PlanDailyWork_t.DailyWorkSeveteen, m_PlanDailyWork_t.DailyWorkEighteen, m_PlanDailyWork_t.DailyWorkNineteen," & _
            " m_PlanDailyWork_t.DailyWorkTwenty, m_PlanDailyWork_t.DailyWorkTwentyone, m_PlanDailyWork_t.DailyWorkTwentytwo, m_PlanDailyWork_t.DailyWorkTwentythree, m_PlanDailyWork_t.DailyWorkTwentyfour, m_PlanDailyWork_t.DailyWorkTwentyfive, m_PlanDailyWork_t.DailyWorkTwentysix, m_PlanDailyWork_t.DailyWorkTwentyseven," & _
            " m_PlanDailyWork_t.DailyWorkTwentyeight, m_PlanDailyWork_t.DailyWorkTwentynine, m_PlanDailyWork_t.DailyWorkThirty, m_PlanDailyWork_t.DailyWorkThirtyone" & _
            " FROM m_ProductionPlanItem_t INNER JOIN m_PlanDailyWork_t ON m_ProductionPlanItem_t.TransactionId = m_PlanDailyWork_t.TransactionId AND " & _
            " m_ProductionPlanItem_t.PlanMonth = m_PlanDailyWork_t.PlanMonth And m_ProductionPlanItem_t.MaterialNO = m_PlanDailyWork_t.MaterialNO And" & _
            " m_ProductionPlanItem_t.MOID = m_PlanDailyWork_t.MOID And m_ProductionPlanItem_t.LineName = m_PlanDailyWork_t.LineName WHERE 1=1 " & strWhere

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function


    Public Shared Function GetSettingParameterSQL(ByVal ParameterCode As String) As String
        Return "SELECT PARAMETER_VALUE, PARAMETER_NAME FROM m_SettingParameter_t WHERE PARAMETER_MODE='" & ParameterCode & "' ORDER BY ORDERID ASC"
    End Function

    Public Shared Function GetDateTableALL(ByVal dtTemp As DataTable, ByVal lblMessage As LabelX) As DataTable
        Try
            If (Not dtTemp Is Nothing) Then
                Dim drTemp As DataRow
                drTemp = dtTemp.NewRow
                drTemp(0) = "ALL"
                drTemp(1) = "ALL"
                dtTemp.Rows.Add(drTemp)
                dtTemp.AcceptChanges()
            End If
        Catch ex As Exception
            GetMesData.SetMessage(lblMessage, "加载控件ALL异常", False)
        End Try
        Return dtTemp
    End Function

    Public Shared Function ReelExtract(ByVal ReelBarCode As String, ByRef MaterialNO As String, ByRef VendorCode As String, ByRef DateCode As String, ByRef Qty As Int16, ByRef Versions As String) As Boolean

        Try

            '物料条码：131-022061-004R0AM0151014AU0025000010   2014-11-11  科尔通料号处理，解析从右边开始，增加栈板P类型条码
            '栈板条码：131-022061-004R0AM0151014AU000025000010P    2014-11-27      取消栈板条码        更改原有条码规则，数量增加到7位
            If (ReelBarCode.Substring(ReelBarCode.Length - 1, 1).ToUpper() = "P") Then

                MaterialNO = ReelBarCode.Substring(0, ReelBarCode.Length - 25)
                VendorCode = ReelBarCode.Substring(ReelBarCode.Length - 23, 6)
                DateCode = ReelBarCode.Substring(ReelBarCode.Length - 17, 4)
                Qty = Int16.Parse(ReelBarCode.Substring(ReelBarCode.Length - 12, 6))
                Versions = ReelBarCode.Substring(ReelBarCode.Length - 25, 2)

            Else

                '从左开始解析
                'MaterialNO = ReelBarCode.Substring(0, 15);
                'VendorCode = ReelBarCode.Substring(16, 6);
                'DateCode = ReelBarCode.Substring(23, 4);
                'Qty = Int16.Parse(ReelBarCode.Substring(27, 6));

                '七位数量
                MaterialNO = ReelBarCode.Substring(0, ReelBarCode.Length - 22)
                VendorCode = ReelBarCode.Substring(ReelBarCode.Length - 20, 6)
                DateCode = ReelBarCode.Substring(ReelBarCode.Length - 14, 4)
                Qty = Int16.Parse(ReelBarCode.Substring(ReelBarCode.Length - 10, 7))
                Versions = ReelBarCode.Substring(ReelBarCode.Length - 22, 2)

                'MaterialNO = ReelBarCode.Substring(0, ReelBarCode.Length - 21);
                'VendorCode = ReelBarCode.Substring(ReelBarCode.Length - 19, 6);
                'DateCode = ReelBarCode.Substring(ReelBarCode.Length - 13, 4);
                'Qty = Int16.Parse(ReelBarCode.Substring(ReelBarCode.Length - 9, 6));
                'Versions = ReelBarCode.Substring(ReelBarCode.Length - 21, 2);
            End If
            Return True
        Catch
            MaterialNO = String.Empty
            VendorCode = String.Empty
            DateCode = String.Empty
            Qty = 0
            Versions = String.Empty
            Return False
        End Try
    End Function

    Public Shared Sub SetMessage(ByVal lblMessage As LabelX, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As Label, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As LabelItem, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

    Public Shared Function ExportFromExcelByAs(ByVal file As String, ByVal sheetId As Int16, ByVal rowStartIndex As Integer, ByVal colStartIndex As Integer, ByRef errorMsg As String) As DataTable
        Try
            Dim aBook As New Aspose.Cells.Workbook(file)
            Dim aSheet As Worksheet = aBook.Worksheets(0)
            Dim aCell As Cells = aSheet.Cells
            Dim aOptions As Aspose.Cells.ExportTableOptions = New Aspose.Cells.ExportTableOptions
            aOptions.SkipErrorValue = True
            Dim dtTemp As DataTable = New DataTable

            For i As Int16 = 0 To 70
                dtTemp.Columns.Add(i)
            Next

            aCell.ExportDataTable(dtTemp, 1, 0, 1000, False)
            'Using dt As DataTable = aCell.ExportDataTable(rowStartIndex, colStartIndex, aCell.MaxRow + 1, aCell.MaxColumn + 1, True)

            '    Return dt
            'End Using
            Return dtTemp
        Catch ex As Exception
            errorMsg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Shared Sub GetPlanMonthDayColumnName(ByVal iYear As Int16, ByVal iMonth As Int16, ByVal dgvControls As DevComponents.DotNetBar.Controls.DataGridViewX, ByVal iStartColumn As Int16, ByVal lblMessage As LabelX)
        Try
            Dim strColumnName As String
            Dim MonthDay As Int16 = DateTime.DaysInMonth(iYear, iMonth)
            Dim iDayTemp As Int16
            For i As Int16 = 0 To MonthDay - 1
                iDayTemp = i + 1
                strColumnName = Convert.ToString(iMonth) + "/" + Convert.ToString(iDayTemp)
                dgvControls.Columns(iStartColumn + i).HeaderText = strColumnName
            Next

            For K As Int16 = 0 To 31 - 1
                dgvControls.Columns(iStartColumn + K).Visible = True
            Next

            For j As Int16 = MonthDay To 30
                dgvControls.Columns(iStartColumn + j).Visible = False
            Next
        Catch ex As Exception
            GetMesData.SetMessage(lblMessage, "加载计划列名异常", False)
        End Try
    End Sub

    Public Shared Sub GetPlanMonthDayColumnName(ByVal iYear As Int16, ByVal iMonth As Int16, ByVal dgvControls As DevComponents.DotNetBar.Controls.DataGridViewX, ByVal iStartColumn As Int16, ByVal lblMessage As LabelItem)
        Try
            Dim strColumnName As String
            Dim MonthDay As Int16 = DateTime.DaysInMonth(iYear, iMonth)
            Dim iDayTemp As Int16
            For i As Int16 = 0 To MonthDay - 1
                iDayTemp = i + 1
                strColumnName = Convert.ToString(iMonth) + "/" + Convert.ToString(iDayTemp)
                dgvControls.Columns(iStartColumn + i).HeaderText = strColumnName
            Next

            For K As Int16 = 0 To 31 - 1
                dgvControls.Columns(iStartColumn + K).Visible = True
            Next

            For j As Int16 = MonthDay To 30
                dgvControls.Columns(iStartColumn + j).Visible = False
            Next
        Catch ex As Exception
            GetMesData.SetMessage(lblMessage, "加载计划列名异常", False)
        End Try
    End Sub

    Public Shared Sub GetColumnVisiable(ByVal dgvControls As DevComponents.DotNetBar.Controls.DataGridViewX, ByVal dtVisiableColumn As DataTable, ByVal lblMessage As LabelX)
        Try
            For i As Int16 = 0 To dtVisiableColumn.Rows.Count - 1
                dgvControls.Columns(dtVisiableColumn.Rows(i).Item("ColumnId")).Visible = dtVisiableColumn.Rows(i).Item("VisiableFlag")
            Next
        Catch ex As Exception
            GetMesData.SetMessage(lblMessage, "加载计划列名显示异常", False)
        End Try
    End Sub

    Public Shared Sub GetDataGridXColumn(ByVal dgvControls As DevComponents.DotNetBar.Controls.DataGridViewX, ByVal dtVisiableColumn As DataTable, ByVal lblMessage As LabelX)
        Try
            dtVisiableColumn.Rows.Clear()
            Dim drData As DataRow
            For i As Int16 = 0 To dgvControls.Columns.Count - 1
                If (Right(dgvControls.Columns(i).Name.ToUpper, 2) <> "Id".ToUpper And dgvControls.Columns(i).HeaderText.ToUpper <> "Column1".ToUpper) Then
                    drData = dtVisiableColumn.NewRow()
                    drData("ColumnId") = dgvControls.Columns(i).Name
                    drData("ColumnName") = dgvControls.Columns(i).HeaderText
                    drData("VisiableType") = "1"
                    drData("VisiableFlag") = dgvControls.Columns(i).Visible
                    dtVisiableColumn.Rows.Add(drData)
                End If
            Next
            dtVisiableColumn.AcceptChanges()
        Catch ex As Exception
            GetMesData.SetMessage(lblMessage, "加载计划列名异常", False)
        End Try
    End Sub

#Region "获取本地打印机列表"

    Public Shared Sub GetPrintersList(ByVal CboName As ComboBox)
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            CboName.Items.Add(iprt)
        Next
    End Sub

    Public Shared Sub GetPrintersList(ByVal CboName As DataGridViewComboBoxColumn)
        CboName.Items.Clear()
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            CboName.Items.Add(iprt)
        Next
    End Sub

    Public Shared Function CheckPrintersList(ByVal PrintName As String) As Boolean
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            If (iprt.Trim = PrintName) Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region

End Class
