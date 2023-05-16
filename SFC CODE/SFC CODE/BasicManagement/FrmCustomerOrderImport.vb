
'--合约订单导入功能
'--Create by :　马锋
'--Create date :　2016/08/17
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
Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports MainFrame
Imports Aspose.Cells

#End Region

Public Class FrmCustomerOrderImport

#Region "变量声明"

    Dim _ContractOrderNo As String
    Dim _FNSKUList As DataTable

    Public Property FNSKUList() As DataTable
        Get
            If (_FNSKUList Is Nothing) Then
                _FNSKUList = New DataTable()
                Dim dc As DataColumn
                _FNSKUList.Columns.Add("OrderNO", Type.GetType("System.String"))
                _FNSKUList.Columns.Add("PartId", Type.GetType("System.String"))
                _FNSKUList.Columns.Add("FNSKU", Type.GetType("System.String"))
                _FNSKUList.Columns.Add("ExportingCountries", Type.GetType("System.String"))
                _FNSKUList.Columns.Add("ShippingMethod", Type.GetType("System.String"))
                _FNSKUList.Columns.Add("PRDimensions", Type.GetType("System.String"))

                _FNSKUList.Columns.Add("CustomerDelivery", Type.GetType("System.String"))
                _FNSKUList.Columns.Add("ExportQuantity", Type.GetType("System.String"))
                _FNSKUList.Columns.Add("titlemini", Type.GetType("System.String"))

            End If
            Return _FNSKUList
        End Get

        Set(ByVal Value As DataTable)
            _FNSKUList = Value
        End Set
    End Property

#End Region

#Region "窗体构造"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal ContractOrderNo As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _ContractOrderNo = ContractOrderNo
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmCustomerOrderImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvImport.AutoGenerateColumns = False
            Me.mtxtContractOrder.Text = _ContractOrderNo
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub mtxtImportURL_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtImportURL.ButtonCustomClick
        Try
            Dim strFilePath As String
            Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
            openFileDialog.Filter = "Execl文件|*.xls;*.xlsx"
            openFileDialog.Multiselect = False
            openFileDialog.Title = "选择计划导入Execl文件"
            If (openFileDialog.ShowDialog() = DialogResult.OK) Then
                strFilePath = openFileDialog.FileName
                Dim strMsg As String = ""
                If (Not String.IsNullOrEmpty(strFilePath)) Then
                    Me.mtxtImportURL.Text = strFilePath
                    Dim dtLoadData As DataTable = ExportFromExcelByAs(strFilePath, 0, 0, 0, strMsg)
                    If (Not String.IsNullOrEmpty(strMsg)) Then
                        SetMessage(lblMessage, strMsg, False)
                        Exit Sub
                    End If

                    GetFormatUpDateData(dtLoadData, Me.dgvImport)
                End If
            End If
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载路径异常", False)
        End Try
    End Sub

    Private Sub ToolCommit_Click(sender As Object, e As EventArgs) Handles ToolCommit.Click
        SetMessage(Me.lblMessage, "", False)
        Try
            Me.dgvImport.CommitEdit(DataGridViewDataErrorContexts.Commit)
            Me.dgvImport.EndEdit()
            If Not (CheckSave()) Then
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            Dim strOrderNo, strPartId, strFNSKU, strExportingCountries, strShippingMethod, strPRDimensions, strCustomerDelivery, strExportQuantity, strTitlemini As String

            strOrderNo = Me.mtxtContractOrder.Text.Trim
            strSQL.AppendLine(" DECLARE @CustomerOrderItemID VARCHAR(32) ")
            For i As Int16 = 0 To Me.dgvImport.Rows.Count - 1

                strPartId = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("PartId").Value), "", Me.dgvImport.Rows(i).Cells("PartId").Value)
                strFNSKU = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("FNSKU").Value), "", Me.dgvImport.Rows(i).Cells("FNSKU").Value)
                strExportingCountries = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("ExportingCountries").Value), "", Me.dgvImport.Rows(i).Cells("ExportingCountries").Value)
                strShippingMethod = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("ShippingMethod").Value), "", Me.dgvImport.Rows(i).Cells("ShippingMethod").Value)
                strPRDimensions = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("PRDimensions").Value), "", Me.dgvImport.Rows(i).Cells("PRDimensions").Value)
                strCustomerDelivery = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("CustomerDelivery").Value), "", Me.dgvImport.Rows(i).Cells("CustomerDelivery").Value)
                strExportQuantity = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("ExportQuantity").Value), "", Me.dgvImport.Rows(i).Cells("ExportQuantity").Value)
                strTitlemini = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("Titlemini").Value), "", Me.dgvImport.Rows(i).Cells("Titlemini").Value)
                strSQL.AppendLine(" SELECT @CustomerOrderItemID = m_CustomerOrderItem_t.CustomerOrderItemID FROM  m_CustomerOrder_t INNER JOIN m_CustomerOrderItem_t ON m_CustomerOrderItem_t.CustomerOrderID=m_CustomerOrder_t.CustomerOrderID WHERE m_CustomerOrder_t.OrderNO='" & strOrderNo & "' AND   m_CustomerOrderItem_t.PartId='" & strPartId & "' AND  m_CustomerOrderItem_t.DeleteFlag = '0' ")
                strSQL.AppendLine(" INSERT INTO m_CustomerOrderDetail_t(CustomerOrderItemID, PartId, FNSKU, ExportingCountries, ShippingMethod, PRDimensions, CustomerDelivery, ExportQuantity, CreateUserId, CreateTime)VALUES( ")
                strSQL.AppendLine(" @CustomerOrderItemID, '" & strPartId & "', '" & strFNSKU & "', '" & strExportingCountries & "', '" & strShippingMethod & "', '" & strPRDimensions & "', '" & strCustomerDelivery & "', '" & strExportQuantity & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE())")
                strSQL.AppendLine(" UPDATE m_CustomerOrderItem_t SET TitleMini='" & strTitlemini & "', SKUQuantity = (SELECT SUM(ExportQuantity) FROM m_CustomerOrderDetail_t WHERE CustomerOrderItemID = @CustomerOrderItemID AND PartId = '" & strPartId & "' AND DeleteFlag = '0' ) WHERE CustomerOrderItemID = @CustomerOrderItemID AND PartId = '" & strPartId & "' AND DeleteFlag = '0' ")
            Next
            
            If Not (String.IsNullOrEmpty(strSQL.ToString)) Then
                DbOperateUtils.ExecSQL(strSQL.ToString)
            End If

            SetMessage(lblMessage, "保存行成功!", False)
            Me.Close()
        Catch ex As Exception
            SetMessage(lblMessage, "保存行异常!", False)
        End Try
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    Private Sub LinkLabelImportFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelImportFile.LinkClicked
        SetMessage(Me.lblMessage, "", False)
        Try

            If (Not File.Exists(Application.StartupPath() + "\CustomerOrderTemplate.xlsx")) Then

                Dim template As Byte() = My.Resources.CustomerOrderTemplate
                File.WriteAllBytes(Application.StartupPath() + "\CustomerOrderTemplate.xlsx", template)
            End If
            Process.Start(Application.StartupPath() + "\CustomerOrderTemplate.xlsx")

        Catch ex As Exception
            SetMessage(Me.lblMessage, "打开模版本文件异常,请确认模文件是否存在！", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Public Shared Function ExportFromExcelByAs(ByVal file As String, ByVal sheetId As Int16, ByVal rowStartIndex As Integer, ByVal colStartIndex As Integer, ByRef errorMsg As String) As DataTable
        Try
            Dim aBook As New Aspose.Cells.Workbook(file)
            Dim aSheet As Worksheet = aBook.Worksheets(0)
            Dim aCell As Cells = aSheet.Cells
            Dim aOptions As Aspose.Cells.ExportTableOptions = New Aspose.Cells.ExportTableOptions
            aOptions.SkipErrorValue = True
            Dim dtTemp As DataTable = New DataTable

            For i As Int16 = 0 To 9
                dtTemp.Columns.Add(i)
            Next

            aCell.ExportDataTable(dtTemp, 1, 0, 200, False)
            'Using dt As DataTable = aCell.ExportDataTable(rowStartIndex, colStartIndex, aCell.MaxRow + 1, aCell.MaxColumn + 1, True)

            '    Return dt
            'End Using
            Return dtTemp
        Catch ex As Exception
            errorMsg = ex.Message
            Return Nothing
        End Try
    End Function

    Private Sub GetFormatUpDateData(ByVal dtLoadData As DataTable, ByVal dgvContorls As DataGridViewX)
        Try
            If (dtLoadData Is Nothing) Then
                Me.dgvImport.DataSource = Nothing
                Me.dgvImport.Rows.Clear()
                SetMessage(Me.lblMessage, "没有任何更新数据", False)
                Exit Sub
            Else
                If (dtLoadData.Rows.Count <= 0) Then
                    SetMessage(Me.lblMessage, "没有任何更新数据", False)
                    Me.dgvImport.DataSource = Nothing
                    Me.dgvImport.Rows.Clear()
                    Exit Sub
                End If
            End If

            FNSKUList.Rows.Clear()

            Dim drData As DataRow
            For i As Int16 = 0 To dtLoadData.Rows.Count - 1
                drData = FNSKUList.NewRow()
                drData("OrderNO") = dtLoadData.Rows(i).Item(0).ToString
                drData("PartId") = dtLoadData.Rows(i).Item(1).ToString
                drData("ExportQuantity") = dtLoadData.Rows(i).Item(2).ToString
                drData("FNSKU") = dtLoadData.Rows(i).Item(3).ToString
                drData("ExportingCountries") = dtLoadData.Rows(i).Item(4).ToString
                drData("ShippingMethod") = dtLoadData.Rows(i).Item(5).ToString
                drData("PRDimensions") = dtLoadData.Rows(i).Item(6).ToString
                drData("titlemini") = dtLoadData.Rows(i).Item(7).ToString
                drData("CustomerDelivery") = dtLoadData.Rows(i).Item(8).ToString

                FNSKUList.Rows.Add(drData)
            Next
            FNSKUList.AcceptChanges()
            Me.dgvImport.DataSource = FNSKUList
        Catch ex As Exception
            SetMessage(Me.lblMessage, "更新文件格式不正确,请确认格式", False)
        End Try
    End Sub

    Private Function CheckSave() As Boolean
        Dim rtValue As Boolean = True
        Try
            If (Me.dgvImport.Rows.Count = 0) Then
                SetMessage(lblMessage, "没有任何保存数据!", False)
                rtValue = False
            Else
                Dim strPartId, strFNSKU, strExportingCountries, strShippingMethod, strPRDimensions, strCustomerDelivery, strExportQuantity As String
                Dim CheckFor As Boolean = True
                Dim dQuantity As Double = 0
                Dim dCheckQuantity As Double = 0
                Dim var As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)()
                var.Clear()

                For i As Int16 = 0 To Me.dgvImport.Rows.Count - 1
                    strPartId = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("PartId").Value), "", Me.dgvImport.Rows(i).Cells("PartId").Value)
                    strFNSKU = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("FNSKU").Value), "", Me.dgvImport.Rows(i).Cells("FNSKU").Value)
                    strExportingCountries = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("ExportingCountries").Value), "", Me.dgvImport.Rows(i).Cells("ExportingCountries").Value)
                    strShippingMethod = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("ShippingMethod").Value), "", Me.dgvImport.Rows(i).Cells("ShippingMethod").Value)
                    strPRDimensions = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("PRDimensions").Value), "", Me.dgvImport.Rows(i).Cells("PRDimensions").Value)
                    strCustomerDelivery = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("CustomerDelivery").Value), "", Me.dgvImport.Rows(i).Cells("CustomerDelivery").Value)
                    strExportQuantity = IIf(IsDBNull(Me.dgvImport.Rows(i).Cells("ExportQuantity").Value), "", Me.dgvImport.Rows(i).Cells("ExportQuantity").Value)

                    'If (String.IsNullOrEmpty(strFNSKU)) Then
                    '    rtValue = False
                    '    CheckFor = False
                    '    SetMessage(Me.lblMessage, "第" & i + 1 & "行输入FNSKU不能为空", False)
                    '    Exit For
                    'End If

                    If (String.IsNullOrEmpty(strExportingCountries)) Then
                        rtValue = False
                        CheckFor = False
                        SetMessage(Me.lblMessage, "第" & i + 1 & "行输入出口国家不能为空", False)
                        Exit For
                    End If

                    If (String.IsNullOrEmpty(strShippingMethod)) Then
                        rtValue = False
                        CheckFor = False
                        SetMessage(Me.lblMessage, "第" & i + 1 & "行输入出货方式不能为空", False)
                        Exit For
                    End If

                    If (String.IsNullOrEmpty(strCustomerDelivery)) Then
                        rtValue = False
                        CheckFor = False
                        SetMessage(Me.lblMessage, "第" & i + 1 & "行输入客户交期不能为空", False)
                        Exit For
                    End If

                    If (String.IsNullOrEmpty(strPRDimensions)) Then
                        rtValue = False
                        CheckFor = False
                        SetMessage(Me.lblMessage, "第" & i + 1 & "行输入PR维度不能为空", False)
                        Exit For
                    End If

                    If Not IsNumeric(strExportQuantity) Then
                        rtValue = False
                        CheckFor = False
                        SetMessage(Me.lblMessage, "第" & i + 1 & "行输入交货数量格式错误", False)
                        Exit For
                    End If
                    If (CDbl(strExportQuantity) <= 0) Then
                        rtValue = False
                        CheckFor = False
                        SetMessage(Me.lblMessage, "第" & i + 1 & "行输入交货数量不能小于0", False)
                        Exit For
                    End If

                    Dim value As Int16 = 0
                    If var.TryGetValue(strPartId, value) Then
                        var.Item(strPartId) = value + strExportQuantity
                    Else
                        var.Add(strPartId, strExportQuantity)
                    End If
                Next

                If (rtValue) Then
                    Dim strSQL As String
                    Dim dtTemp As DataTable
                    Dim iQuantity, SumExportQuantity, iExportQuantity As Int32

                    Dim pair As KeyValuePair(Of String, Integer)
                    For Each pair In var
                        '" SELECT m_CustomerOrderItem_t.Quantity, ISNULL(SUM(ExportQuantity),0) AS SumExportQuantity FROM  m_CustomerOrder_t" & _
                        '" INNER JOIN m_CustomerOrderItem_t ON m_CustomerOrderItem_t.CustomerOrderID=m_CustomerOrder_t.CustomerOrderID " & _
                        '" LEFT JOIN m_CustomerOrderDetail_t ON m_CustomerOrderDetail_t.CustomerOrderItemID=m_CustomerOrderItem_t.CustomerOrderItemID " & _
                        '" WHERE m_CustomerOrder_t.OrderNO='" & Me.mtxtContractOrder.Text.Trim & "' AND m_CustomerOrderItem_t.PartId='" & pair.Key & "' AND m_CustomerOrder_t.DeleteFlag = '0' AND m_CustomerOrderItem_t.DeleteFlag = '0' AND ISNULL(m_CustomerOrderDetail_t.DeleteFlag,'0') = '0' GROUP BY m_CustomerOrderItem_t.Quantity "

                        strSQL = "IF EXISTS(SELECT 1 FROM  m_CustomerOrder_t  " & _
                                 " INNER JOIN m_CustomerOrderItem_t ON m_CustomerOrderItem_t.CustomerOrderID=m_CustomerOrder_t.CustomerOrderID   " & _
                                 " LEFT JOIN m_CustomerOrderDetail_t ON m_CustomerOrderDetail_t.CustomerOrderItemID=m_CustomerOrderItem_t.CustomerOrderItemID   " & _
                                 " WHERE m_CustomerOrder_t.OrderNO='" & Me.mtxtContractOrder.Text.Trim & "' AND m_CustomerOrderItem_t.PartId='" & pair.Key & "' AND ISNULL(m_CustomerOrderDetail_t.DeleteFlag,'0') = '0' )  BEGIN " & _
                                 " SELECT m_CustomerOrderItem_t.Quantity, ISNULL(SUM(ExportQuantity),0) AS SumExportQuantity " & _
                                 " FROM  m_CustomerOrder_t  " & _
                                 " INNER JOIN m_CustomerOrderItem_t ON m_CustomerOrderItem_t.CustomerOrderID=m_CustomerOrder_t.CustomerOrderID   " & _
                                 " LEFT JOIN m_CustomerOrderDetail_t ON m_CustomerOrderDetail_t.CustomerOrderItemID=m_CustomerOrderItem_t.CustomerOrderItemID   " & _
                                 " WHERE m_CustomerOrder_t.OrderNO='" & Me.mtxtContractOrder.Text.Trim & "' AND m_CustomerOrderItem_t.PartId='" & pair.Key & "' AND m_CustomerOrder_t.DeleteFlag = '0'  " & _
                                 " AND m_CustomerOrderItem_t.DeleteFlag = '0'  " & _
                                 " AND ISNULL(m_CustomerOrderDetail_t.DeleteFlag,'0') = '0'  " & _
                                 " GROUP BY m_CustomerOrderItem_t.Quantity  " & _
                                " END ELSE BEGIN " & _
                                     " SELECT m_CustomerOrderItem_t.Quantity, 0 AS SumExportQuantity " & _
                                 " FROM  m_CustomerOrder_t  " & _
                                 " INNER JOIN m_CustomerOrderItem_t ON m_CustomerOrderItem_t.CustomerOrderID=m_CustomerOrder_t.CustomerOrderID   " & _
                                 " WHERE m_CustomerOrder_t.OrderNO='" & Me.mtxtContractOrder.Text.Trim & "' AND m_CustomerOrderItem_t.PartId='" & pair.Key & "' AND m_CustomerOrder_t.DeleteFlag = '0'  " & _
                                 " AND m_CustomerOrderItem_t.DeleteFlag = '0' END"

                        dtTemp = DbOperateUtils.GetDataTable(strSQL)

                        If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                            iQuantity = CInt(dtTemp.Rows(0).Item(0))
                            SumExportQuantity = CInt(dtTemp.Rows(0).Item(1))
                        Else
                            SetMessage(lblMessage, "导入合约订单料号:" & pair.Key & "，不存在!", False)
                            rtValue = False
                            Exit For
                                End If

                        If (SumExportQuantity + pair.Value > iQuantity) Then
                            SetMessage(lblMessage, "料号:" & pair.Key & "出货数量不能大于,合约订单数量!", False)
                            rtValue = False
                            Exit For
                                End If
                    Next
                End If
            End If
        Catch ex As Exception
            SetMessage(lblMessage, "执行保存检查异常!", False)
            rtValue = False
        End Try

        Return rtValue
    End Function

    Public Shared Sub SetMessage(ByVal lblMessage As ToolStripLabel, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

#End Region



End Class