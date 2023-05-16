
'--海翼出货状况报表
'--Create by :　马锋
'--Create date :　2016/08/19
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
Imports LXWarehouseManage
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports MainFrame
Imports Aspose.Cells

#End Region

Public Class FrmCustomerOrderQuery

#Region "变量声明"


#End Region

#Region "加载事件"

    Private Sub FrmCustomerOrderQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvCustomerOrder.AutoGenerateColumns = False
            Me.dtpStartDate.Value = Now.AddDays(-1)
            Me.dtpEndDate.Value = Now.AddDays(1)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        Try
            If CheckQueryParameter(True) Then
                Me.dgvCustomerOrder.DataSource = Nothing
                Me.dgvCustomerOrder.Rows.Clear()
                Return
            End If

            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.Append(" SELECT   m_CustomerOrder_t.OrderNO, m_CustomerOrderItem_t.PartId, m_CustomerOrderDetail_t.FNSKU, m_CustomerOrderDetail_t.ExportingCountries, m_CustomerOrderDetail_t.ShippingMethod, ")
            strSQL.Append(" m_CustomerOrderDetail_t.PRDimensions, m_CustomerOrderDetail_t.CustomerDelivery, m_CustomerOrderDetail_t.ExportQuantity, m_CustomerOrderDetail_t.PrinteQuantity, ")
            strSQL.Append(" m_CustomerOrderDetail_t.PackingQuantity, m_CustomerOrderDetail_t.StorageQuantity, m_CustomerOrderDetail_t.ShipmentsQuantity ")
            strSQL.Append(" FROM  m_CustomerOrder_t")
            strSQL.Append(" LEFT JOIN m_CustomerOrderItem_t ON m_CustomerOrderItem_t.CustomerOrderID=m_CustomerOrder_t.CustomerOrderID ")
            strSQL.Append(" LEFT JOIN m_CustomerOrderDetail_t ON m_CustomerOrderDetail_t.CustomerOrderItemID=m_CustomerOrderItem_t.CustomerOrderItemID ")
            strSQL.Append(" WHERE m_CustomerOrderDetail_t.CreateTime BETWEEN '" & Me.dtpStartDate.Text.Trim & "' AND '" & Me.dtpEndDate.Text.Trim & "'")

            If (Not String.IsNullOrEmpty(Me.txtShippingNO.Text.Trim)) Then
                strSQL.Append(" AND m_CustomerOrder_t.OrderNO LIKE '%" & Me.txtShippingNO.Text.Trim & "%' ")
            End If

            If (Not String.IsNullOrEmpty(Me.txtFNSKU.Text.Trim)) Then
                strSQL.Append(" AND m_CustomerOrderDetail_t.FNSKU LIKE '%" & Me.txtFNSKU.Text.Trim & "%' ")
            End If

            If (Not String.IsNullOrEmpty(Me.txtPartId.Text.Trim)) Then
                strSQL.Append(" AND m_CustomerOrderItem_t.PartId LIKE '%" & Me.txtPartId.Text.Trim & "%' ")
            End If

            Me.dgvCustomerOrder.DataSource = DbOperateReportUtils.GetDataTable(strSQL.ToString())

        Catch ex As Exception
            SetMessage(Me.lblMessage, "刷新异常", False)
        End Try
    End Sub

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        Try
            If Me.dgvCustomerOrder.RowCount < 1 Then Exit Sub
            LoadDataToExcel(Me.dgvCustomerOrder, Me.Text)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "汇出异常", False)
        End Try
    End Sub

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "关闭异常", False)
        End Try
    End Sub

#End Region

#Region "函数"

    Private Function CheckQueryParameter(ByVal MessageFlag As Boolean) As Boolean
        If (dtpEndDate.Value < dtpStartDate.Value) Then
            If (MessageFlag) Then
                MsgBox("查询结束时间不能大于开始时间！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
            End If
            Return True
        End If

        Return False
    End Function

    Public Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String)
        Try

            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            '导出CSV文件格式，以便用户查询，以,号区分

            If Not Directory.Exists("c:\MES") Then
                Directory.CreateDirectory("c:\MES")
            End If

            Dim Swriter As New IO.StreamWriter("c:\MES\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            Dim r As Integer
            Dim c As Integer
            For r = 0 To DgMoData.Rows.Count - 1
                wValue = ""
                nColqty = 0
                For c = 0 To DgMoData.Columns.Count - 1
                    '写入标题行
                    If bColName = False Then
                        If wColName = "" Then
                            wColName = DgMoData.Columns(c).HeaderText.Replace(",", "，")
                        Else
                            wColName = wColName + "," + DgMoData.Columns(c).HeaderText.Replace(",", "，")
                        End If
                    End If

                    '写入每行的值
                    'If DgMoData(c, r).Value Is System.DBNull.Value Then
                    If nColqty = 0 Then
                        wValue = DgMoData(c, r).Value.ToString.Replace(",", "，")
                    Else
                        wValue = wValue + "," + DgMoData(c, r).Value.ToString.Replace(",", "，")
                    End If

                    nColqty = nColqty + 1
                Next

                If wColName <> "" And bColName = False Then
                    Swriter.WriteLine(wColName)
                    bColName = True
                End If

                Swriter.WriteLine(wValue)
            Next
            Swriter.Close()

            MessageBox.Show("文件导出成功,导出位置：c:\MES\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

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