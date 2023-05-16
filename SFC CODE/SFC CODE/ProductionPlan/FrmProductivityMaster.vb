
'--生产效率维护
'--Create by :　马锋
'--Create date :　2017/01/11
'--Update date :  
'--Ver : V01

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
Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports MainFrame
Imports Aspose.Cells

#End Region

Public Class FrmProductivityMaster

#Region "窗体事件"

    Private Sub FrmProductivityMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False
            LoadBindData()
            SetStatus(0)
            Me.cboDept.SelectedIndex = -1
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        Try
            SetStatus(1)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub ToolAgain_Click(sender As Object, e As EventArgs) Handles ToolAgain.Click
        Try
            'If (String.IsNullOrEmpty(Me.mtxtLine.Text.Trim())) Then
            '    GetMesData.SetMessage(Me.lblMessage, "重新下载工单不能为空", False)
            '    Me.ActiveControl = Me.mtxtLine
            '    Return
            'End If

            'Dim strSQL As StringBuilder = New StringBuilder

            'strSQL.AppendLine(" DECLARE @RTVALUE VARCHAR(8), @RTMSG NVARCHAR(128) ")
            'strSQL.AppendLine(" EXEC GetAgainTiptopMOPlan @RTVALUE OUTPUT, @RTMSG OUTPUT, '', '', '" & VbCommClass.VbCommClass.UseId & "', '" & Me.txtMOId.Text.Trim & "' ")
            'strSQL.AppendLine(" SELECT @RTVALUE, @RTMSG  ")

            'Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)

            'If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then

            '    If (dtTemp.Rows(0).Item(0).ToString = "1") Then
            '        GetMesData.SetMessage(Me.lblMessage, "重新下载工单成功", True)
            '    Else
            '        GetMesData.SetMessage(Me.lblMessage, dtTemp.Rows(0).Item(1).ToString, False)
            '    End If
            'End If

            GetProductivity()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "下载异常", False)
        End Try
    End Sub

    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                GetMesData.SetMessage(lblMessage, "请选择要修改数据", False)
                Exit Sub
            End If

            Me.mtxtLine.Text = Me.dgvQuery.CurrentRow.Cells("LineId").Value
            Me.txtProductivityValue.Text = Me.dgvQuery.CurrentRow.Cells("ProductivityValue").Value
            Me.dtpStartTime.Text = Me.dgvQuery.CurrentRow.Cells("StartDate").Value
            Me.dtpEndTime.Text = Me.dgvQuery.CurrentRow.Cells("EndDate").Value

            SetStatus(1)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "修改异常", False)
        End Try
    End Sub

    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub ToolCommit_Click(sender As Object, e As EventArgs) Handles ToolCommit.Click
        Try
            If (Not CheckSave()) Then
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            strSQL.AppendLine(" IF EXISTS(SELECT LineId FROM m_PlanProductivity_t WHERE LineId = '" & Me.mtxtLine.Text.Trim & "') BEGIN UPDATE m_PlanProductivity_t SET ProductivityValue = '" & Me.txtProductivityValue.Text.Trim & "', StartDate='" & Me.dtpStartTime.Text & "', EndDate='" & Me.dtpEndTime.Text & "' WHERE LineId = '" & Me.mtxtLine.Text.Trim & "' End Else BEGIN ")
            strSQL.AppendLine(" INSERT INTO m_PlanProductivity_t(LineId, StartDate, EndDate, ProductivityValue, ProductivityType, CreateUserId, CreateTime)VALUES( '" & Me.mtxtLine.Text.Trim & "', '" & Me.dtpStartTime.Text & "', '" & Me.dtpEndTime.Text & "', '" & Me.txtProductivityValue.Text.Trim & "', '1', '" & VbCommClass.VbCommClass.UseId & "', GETDATE() ) End ")

            DbOperateUtils.ExecSQL(strSQL.ToString)

            SetStatus(0)
            GetProductivity()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存异常", False)
        End Try
    End Sub

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        Try
            SetStatus(0)
            GetProductivity()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "返回异常", False)
        End Try
    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Try
            GetProductivity()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Try
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "退出异常", False)
        End Try
    End Sub

    Private Sub mtxtLine_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtLine.ButtonCustomClick
        Try
    
            Dim frmLineQuery As New FrmLineQuery(Me.mtxtLine.Text)
            'frmLineQuery.ShowDialog()
            'update by hgd 2017-03-31  返回部门代码
            If frmLineQuery.ShowDialog() = Windows.Forms.DialogResult.Yes Then


            End If

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Try
            'Dim strFilePath As String
            'Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
            'openFileDialog.Filter = "Execl文件|*.xls;*.xlsx"
            'openFileDialog.Multiselect = False
            'openFileDialog.Title = "选择计划导入Execl文件"
            'If (openFileDialog.ShowDialog() = DialogResult.OK) Then
            '    strFilePath = openFileDialog.FileName
            '    Dim strMsg As String = ""
            '    If (Not String.IsNullOrEmpty(strFilePath)) Then
            '        Dim dtLoadData As DataTable = ExportFromExcelByAs(strFilePath, 0, 0, 0, strMsg)
            '        If (Not String.IsNullOrEmpty(strMsg)) Then
            '            SetMessage(lblMessage, strMsg, False)
            '            Exit Sub
            '        End If

            '        GetFormatUpDateData(dtLoadData, Me.dgvImport)
            '    End If
            'End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载路径异常", False)
        End Try
    End Sub

#End Region

#Region "方法"

    Private Sub LoadBindData()
        Try
            Me.cboDept.DisplayMember = "dqc"
            Me.cboDept.ValueMember = "deptid"
            Me.cboDept.DataSource = DbOperateUtils.GetDataTable("SELECT deptid, dqc FROM M_DEPT_T WHERE USEY='Y' AND FACTORYID = '" & VbCommClass.VbCommClass.Factory & "' AND ISNULL(PROFITCENTER, '')='" & VbCommClass.VbCommClass.profitcenter & "'")
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载数据异常", False)
        End Try
    End Sub

    Private Sub SetStatus(ByVal statusFlag As Int16)
        Select Case (statusFlag)
            Case 0
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.ToolAgain.Enabled = True
                Me.ToolCommit.Enabled = False
                Me.ToolBack.Enabled = False
                Me.ToolQuery.Enabled = True
                Me.ToolExitFrom.Enabled = True
            Case 1
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolAgain.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolBack.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolExitFrom.Enabled = False
        End Select
    End Sub

    Private Sub GetProductivity()
        Try
            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine("SELECT   PlanProductivityID, LineId, StartDate, EndDate, ProductivityValue, ProductivityType, CreateUserId, CreateTime FROM m_PlanProductivity_t WHERE 1=1 ")

            If Not String.IsNullOrEmpty(Me.mtxtLine.Text.Trim()) Then
                strSQL.AppendLine(" AND LineId LIKE '%" & Me.mtxtLine.Text.Trim & "%' ")
            End If

            If Not String.IsNullOrEmpty(Me.cboDept.SelectedValue) Then
                strSQL.AppendLine(" AND LineId IN (SELECT DISTINCT lineid FROM deptline_t WHERE deptid='" & Me.cboDept.SelectedValue & "')")
            End If

            Me.dgvQuery.DataSource = DbOperateUtils.GetDataTable(strSQL.ToString)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Function CheckSave() As Boolean
        Try
            If (String.IsNullOrEmpty(Me.mtxtLine.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "产线不能为空", False)
                Return False
            End If

            If (String.IsNullOrEmpty(Me.txtProductivityValue.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "人力不能为空", False)
                Return False
            Else
                If Not IsNumeric(Me.txtProductivityValue.Text.Trim) Then
                    GetMesData.SetMessage(Me.lblMessage, "人力必须为数字", False)
                    Return False
                Else
                    If (CDbl(Me.txtProductivityValue.Text.Trim) <= 0) Then
                        GetMesData.SetMessage(Me.lblMessage, "人力必须大于0", False)
                        Return False
                    End If
                End If
            End If

            If (Me.dtpEndTime.Value < Me.dtpStartTime.Value) Then
                GetMesData.SetMessage(Me.lblMessage, "查询结束时间不能大于开始时间", False)
                Return False
            End If
            Return True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常", False)
            Return False
        End Try
    End Function

#End Region

#Region "函数"

    'Public Shared Function ExportFromExcelByAs(ByVal file As String, ByVal sheetId As Int16, ByVal rowStartIndex As Integer, ByVal colStartIndex As Integer, ByRef errorMsg As String) As DataTable
    '    Try
    '        Dim aBook As New Aspose.Cells.Workbook(file)
    '        Dim aSheet As Worksheet = aBook.Worksheets(0)
    '        Dim aCell As Cells = aSheet.Cells
    '        Dim aOptions As Aspose.Cells.ExportTableOptions = New Aspose.Cells.ExportTableOptions
    '        aOptions.SkipErrorValue = True
    '        Dim dtTemp As DataTable = New DataTable

    '        For i As Int16 = 0 To 9
    '            dtTemp.Columns.Add(i)
    '        Next

    '        aCell.ExportDataTable(dtTemp, 1, 0, 200, False)
    '        'Using dt As DataTable = aCell.ExportDataTable(rowStartIndex, colStartIndex, aCell.MaxRow + 1, aCell.MaxColumn + 1, True)

    '        '    Return dt
    '        'End Using
    '        Return dtTemp
    '    Catch ex As Exception
    '        errorMsg = ex.Message
    '        Return Nothing
    '    End Try
    'End Function

    'Private Sub GetFormatUpDateData(ByVal dtLoadData As DataTable, ByVal dgvContorls As DataGridViewX)
    '    Try
    '        If (dtLoadData Is Nothing) Then
    '            Me.dgvImport.DataSource = Nothing
    '            Me.dgvImport.Rows.Clear()
    '            SetMessage(Me.lblMessage, "没有任何更新数据", False)
    '            Exit Sub
    '        Else
    '            If (dtLoadData.Rows.Count <= 0) Then
    '                SetMessage(Me.lblMessage, "没有任何更新数据", False)
    '                Me.dgvImport.DataSource = Nothing
    '                Me.dgvImport.Rows.Clear()
    '                Exit Sub
    '            End If
    '        End If

    '        FNSKUList.Rows.Clear()

    '        Dim drData As DataRow
    '        For i As Int16 = 0 To dtLoadData.Rows.Count - 1
    '            drData = FNSKUList.NewRow()
    '            drData("OrderNO") = dtLoadData.Rows(i).Item(0).ToString
    '            drData("PartId") = dtLoadData.Rows(i).Item(1).ToString
    '            drData("ExportQuantity") = dtLoadData.Rows(i).Item(2).ToString
    '            drData("FNSKU") = dtLoadData.Rows(i).Item(3).ToString
    '            drData("ExportingCountries") = dtLoadData.Rows(i).Item(4).ToString
    '            drData("ShippingMethod") = dtLoadData.Rows(i).Item(5).ToString
    '            drData("PRDimensions") = dtLoadData.Rows(i).Item(6).ToString
    '            drData("titlemini") = dtLoadData.Rows(i).Item(7).ToString
    '            drData("CustomerDelivery") = dtLoadData.Rows(i).Item(8).ToString

    '            FNSKUList.Rows.Add(drData)
    '        Next
    '        FNSKUList.AcceptChanges()
    '        Me.dgvImport.DataSource = FNSKUList
    '    Catch ex As Exception
    '        SetMessage(Me.lblMessage, "更新文件格式不正确,请确认格式", False)
    '    End Try
    'End Sub

    'Private Function CheckImportSave() As Boolean
    '    Dim rtValue As Boolean = True
    '    Try
    '        If (Me.dgvImport.Rows.Count = 0) Then
    '            SetMessage(lblMessage, "没有任何保存数据!", False)
    '            rtValue = False
    '        Else
    '            Dim strPartId, strFNSKU, strExportingCountries, strShippingMethod, strPRDimensions, strCustomerDelivery, strExportQuantity As String
    '            Dim CheckFor As Boolean = True
    '            Dim dQuantity As Double = 0
    '            Dim dCheckQuantity As Double = 0
    '            Dim var As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)()
    '            var.Clear()

    '            For i As Int16 = 0 To Me.dgvImport.Rows.Count - 1
    '                strPartId = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("PartId").Value), "", Me.dgvImport.Rows(i).Cells("PartId").Value)
    '                strFNSKU = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("FNSKU").Value), "", Me.dgvImport.Rows(i).Cells("FNSKU").Value)
    '                strExportingCountries = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("ExportingCountries").Value), "", Me.dgvImport.Rows(i).Cells("ExportingCountries").Value)
    '                strShippingMethod = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("ShippingMethod").Value), "", Me.dgvImport.Rows(i).Cells("ShippingMethod").Value)
    '                strPRDimensions = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("PRDimensions").Value), "", Me.dgvImport.Rows(i).Cells("PRDimensions").Value)
    '                strCustomerDelivery = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("CustomerDelivery").Value), "", Me.dgvImport.Rows(i).Cells("CustomerDelivery").Value)
    '                strExportQuantity = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("ExportQuantity").Value), "", Me.dgvImport.Rows(i).Cells("ExportQuantity").Value)

    '                If (String.IsNullOrEmpty(strExportingCountries)) Then
    '                    rtValue = False
    '                    CheckFor = False
    '                    SetMessage(Me.lblMessage, "第" & i + 1 & "行输入出口国家不能为空", False)
    '                    Exit For
    '                End If

    '                If (String.IsNullOrEmpty(strShippingMethod)) Then
    '                    rtValue = False
    '                    CheckFor = False
    '                    SetMessage(Me.lblMessage, "第" & i + 1 & "行输入出货方式不能为空", False)
    '                    Exit For
    '                End If

    '                If (String.IsNullOrEmpty(strCustomerDelivery)) Then
    '                    rtValue = False
    '                    CheckFor = False
    '                    SetMessage(Me.lblMessage, "第" & i + 1 & "行输入客户交期不能为空", False)
    '                    Exit For
    '                End If

    '                If (String.IsNullOrEmpty(strPRDimensions)) Then
    '                    rtValue = False
    '                    CheckFor = False
    '                    SetMessage(Me.lblMessage, "第" & i + 1 & "行输入PR维度不能为空", False)
    '                    Exit For
    '                End If

    '                If Not IsNumeric(strExportQuantity) Then
    '                    rtValue = False
    '                    CheckFor = False
    '                    SetMessage(Me.lblMessage, "第" & i + 1 & "行输入交货数量格式错误", False)
    '                    Exit For
    '                End If
    '                If (CDbl(strExportQuantity) <= 0) Then
    '                    rtValue = False
    '                    CheckFor = False
    '                    SetMessage(Me.lblMessage, "第" & i + 1 & "行输入交货数量不能小于0", False)
    '                    Exit For
    '                End If

    '                Dim value As Int16 = 0
    '                If var.TryGetValue(strPartId, value) Then
    '                    var.Item(strPartId) = value + strExportQuantity
    '                Else
    '                    var.Add(strPartId, strExportQuantity)
    '                End If
    '            Next

    '            If (rtValue) Then
    '                Dim strSQL As String
    '                Dim dtTemp As DataTable
    '                Dim iQuantity, SumExportQuantity, iExportQuantity As Int32

    '                Dim pair As KeyValuePair(Of String, Integer)
    '                For Each pair In var
    '                    '" SELECT m_CustomerOrderItem_t.Quantity, ISNULL(SUM(ExportQuantity),0) AS SumExportQuantity FROM  m_CustomerOrder_t" & _
    '                    '" INNER JOIN m_CustomerOrderItem_t ON m_CustomerOrderItem_t.CustomerOrderID=m_CustomerOrder_t.CustomerOrderID " & _
    '                    '" LEFT JOIN m_CustomerOrderDetail_t ON m_CustomerOrderDetail_t.CustomerOrderItemID=m_CustomerOrderItem_t.CustomerOrderItemID " & _
    '                    '" WHERE m_CustomerOrder_t.OrderNO='" & Me.mtxtContractOrder.Text.Trim & "' AND m_CustomerOrderItem_t.PartId='" & pair.Key & "' AND m_CustomerOrder_t.DeleteFlag = '0' AND m_CustomerOrderItem_t.DeleteFlag = '0' AND ISNULL(m_CustomerOrderDetail_t.DeleteFlag,'0') = '0' GROUP BY m_CustomerOrderItem_t.Quantity "

    '                    strSQL = "IF EXISTS(SELECT 1 FROM  m_CustomerOrder_t  " & _
    '                             " INNER JOIN m_CustomerOrderItem_t ON m_CustomerOrderItem_t.CustomerOrderID=m_CustomerOrder_t.CustomerOrderID   " & _
    '                             " LEFT JOIN m_CustomerOrderDetail_t ON m_CustomerOrderDetail_t.CustomerOrderItemID=m_CustomerOrderItem_t.CustomerOrderItemID   " & _
    '                             " WHERE m_CustomerOrder_t.OrderNO='" & Me.mtxtContractOrder.Text.Trim & "' AND m_CustomerOrderItem_t.PartId='" & pair.Key & "' AND ISNULL(m_CustomerOrderDetail_t.DeleteFlag,'0') = '0' )  BEGIN " & _
    '                             " SELECT m_CustomerOrderItem_t.Quantity, ISNULL(SUM(ExportQuantity),0) AS SumExportQuantity " & _
    '                             " FROM  m_CustomerOrder_t  " & _
    '                             " INNER JOIN m_CustomerOrderItem_t ON m_CustomerOrderItem_t.CustomerOrderID=m_CustomerOrder_t.CustomerOrderID   " & _
    '                             " LEFT JOIN m_CustomerOrderDetail_t ON m_CustomerOrderDetail_t.CustomerOrderItemID=m_CustomerOrderItem_t.CustomerOrderItemID   " & _
    '                             " WHERE m_CustomerOrder_t.OrderNO='" & Me.mtxtContractOrder.Text.Trim & "' AND m_CustomerOrderItem_t.PartId='" & pair.Key & "' AND m_CustomerOrder_t.DeleteFlag = '0'  " & _
    '                             " AND m_CustomerOrderItem_t.DeleteFlag = '0'  " & _
    '                             " AND ISNULL(m_CustomerOrderDetail_t.DeleteFlag,'0') = '0'  " & _
    '                             " GROUP BY m_CustomerOrderItem_t.Quantity  " & _
    '                            " END ELSE BEGIN " & _
    '                                 " SELECT m_CustomerOrderItem_t.Quantity, 0 AS SumExportQuantity " & _
    '                             " FROM  m_CustomerOrder_t  " & _
    '                             " INNER JOIN m_CustomerOrderItem_t ON m_CustomerOrderItem_t.CustomerOrderID=m_CustomerOrder_t.CustomerOrderID   " & _
    '                             " WHERE m_CustomerOrder_t.OrderNO='" & Me.mtxtContractOrder.Text.Trim & "' AND m_CustomerOrderItem_t.PartId='" & pair.Key & "' AND m_CustomerOrder_t.DeleteFlag = '0'  " & _
    '                             " AND m_CustomerOrderItem_t.DeleteFlag = '0' END"

    '                    dtTemp = DbOperateUtils.GetDataTable(strSQL)

    '                    If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
    '                        iQuantity = CInt(dtTemp.Rows(0).Item(0))
    '                        SumExportQuantity = CInt(dtTemp.Rows(0).Item(1))
    '                    Else
    '                        SetMessage(lblMessage, "导入合约订单料号:" & pair.Key & "，不存在!", False)
    '                        rtValue = False
    '                        Exit For
    '                    End If

    '                    If (SumExportQuantity + pair.Value > iQuantity) Then
    '                        SetMessage(lblMessage, "料号:" & pair.Key & "出货数量不能大于,合约订单数量!", False)
    '                        rtValue = False
    '                        Exit For
    '                    End If
    '                Next
    '            End If
    '        End If
    '    Catch ex As Exception
    '        SetMessage(lblMessage, "执行保存检查异常!", False)
    '        rtValue = False
    '    End Try

    '    Return rtValue
    'End Function

    Public Shared Sub SetMessage(ByVal lblMessage As LabelX, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

#End Region

End Class