Imports System.Text
Imports MainFrame
Imports System.Drawing
Imports DevComponents.DotNetBar

Public Class FrmShipSheetPrint
    Private Ticket As String = String.Empty
    Private Sub FrmShipSheetPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dtpDeleveryDate.Text = DateTime.Now.Date
        ControlToolBar("")
        Me.txtVendor.Focus()
    End Sub

#Region "工具事件"
    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        SetMessage(lblMessage, "", True)
        GetQueryData()
    End Sub

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        ControlToolBar("New")
        SetMessage(lblMessage, "", True)
        Me.Ticket = String.Empty
    End Sub

    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        ControlToolBar("Edit")
        SetMessage(lblMessage, "", True)
        Me.Ticket = String.Empty
        If Me.dgvList.Rows.Count > 0 And Not (Me.dgvList.CurrentRow Is Nothing) Then
            Me.Ticket = Me.dgvList.CurrentRow.Cells("TicketID").Value
            Me.txtVendor.Text = Me.dgvList.CurrentRow.Cells("Vendor").Value
            Me.txtGoodsName.Text = Me.dgvList.CurrentRow.Cells("GoodsName").Value
            Me.txtOrderID.Text = Me.dgvList.CurrentRow.Cells("OrderID").Value
            Me.txtPartid.Text = Me.dgvList.CurrentRow.Cells("PartNum").Value
            Me.txtQTY.Text = Me.dgvList.CurrentRow.Cells("QTY").Value
            Me.txtWeight.Text = Me.dgvList.CurrentRow.Cells("Weight").Value
            Me.txtRemark.Text = Me.dgvList.CurrentRow.Cells("IQCRemark").Value
            Me.dtpDeleveryDate.Text = Me.dgvList.CurrentRow.Cells("DeliveryDate").Value
        Else
            SetMessage(lblMessage, "请选择需要编辑的列", False)
        End If
    End Sub

    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click

    End Sub

    Private Sub ToolCommit_Click(sender As Object, e As EventArgs) Handles ToolCommit.Click
        If String.IsNullOrEmpty(Ticket) Then
            SaveNew()
        Else
            SaveEdit()
        End If
        ControlToolBar("")
    End Sub

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        Me.dtpDeleveryDate.Text = DateTime.Now.Date
        SetMessage(lblMessage, "", True)
        ControlToolBar("")
    End Sub

    Private Sub ToolPrt_Click(sender As Object, e As EventArgs) Handles ToolPrt.Click

        Me.Ticket = String.Empty
        Me.lblPrintQTY.Visible = True

        lblPrinter.Visible = True

      
        'Dim ship As ShipPrint = New ShipPrint
        If Me.dgvList.Rows.Count <= 0 OrElse Me.dgvList.CurrentRow Is Nothing Then
            SetMessage(lblMessage, "请选择需要打印的行", False)
            Return
        Else
            Dim FrmSet As New FrmSetPrintQTY
            FrmSet.ShowDialog()
            Me.Ticket = Me.dgvList.CurrentRow.Cells("TicketID").Value
            Me.txtVendor.Text = Me.dgvList.CurrentRow.Cells("Vendor").Value
            ShipPrint.Vendor = Me.txtVendor.Text
            Me.txtGoodsName.Text = Me.dgvList.CurrentRow.Cells("GoodsName").Value
            ShipPrint.GoodsName = Me.txtGoodsName.Text
            Me.txtOrderID.Text = Me.dgvList.CurrentRow.Cells("OrderID").Value
            ShipPrint.OrderID = Me.txtOrderID.Text
            Me.txtPartid.Text = Me.dgvList.CurrentRow.Cells("PartNum").Value
            ShipPrint.PartNum = Me.txtPartid.Text
            Me.txtQTY.Text = Double.Parse(Me.dgvList.CurrentRow.Cells("QTY").Value).ToString
            ShipPrint.QTY = Me.txtQTY.Text
            Me.txtWeight.Text = Double.Parse(Me.dgvList.CurrentRow.Cells("Weight").Value).ToString
            ShipPrint.Weight = Me.txtWeight.Text
            Me.txtRemark.Text = Me.dgvList.CurrentRow.Cells("IQCRemark").Value
            ShipPrint.IQCRemark = Me.txtRemark.Text
            Me.dtpDeleveryDate.Text = Me.dgvList.CurrentRow.Cells("DeliveryDate").Value
            ShipPrint.DeliveryDate = Me.dtpDeleveryDate.Text
            Dim dedate As Date = CDate(ShipPrint.DeliveryDate)
            ShipPrint.Year = Format(dedate, "yyyy")
            ShipPrint.Month = Format(dedate, "MM")
            ShipPrint.Day = Format(dedate, "dd")
            Me.lblNum.Text = ShipPrint.PrintQty
            Me.lblPrinter.Text = ShipPrint.PrinterName
        End If
        'If Me.cbxPrint.Text.Trim = String.Empty Then
        '    SetMessage(lblMessage, "请选择打印机和输入打印数量", False)

        '    cbxPrint.Focus()
        '    Return
        'End If
        'If Me.txtPrintQTY.Text.Trim = String.Empty Then
        '    SetMessage(lblMessage, "请选择打印机和输入打印数量", False)
        '    txtPrintQTY.Focus()
        '    Return
        'End If
        Try
            'ShipPrint.PrintQty = Me.txtPrintQTY.Text
            Dim path As String = VbCommClass.VbCommClass.PrintDataModle & "PrintFile\ShipPrint\ShipPrint3"
            ShipPrint.FileToBarCodePrint(path)
            SavePrint()
            ControlToolBar("")
            GetQueryData()
            SetMessage(lblMessage, "打印成功", True)
        Catch ex As Exception
            SetMessage(lblMessage, "打印错误", False)
        End Try
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub
#End Region
#Region "方法"
    Private Sub SaveNew()
        Dim qty As String = Me.txtQTY.Text.Trim
        Dim weight As String = Me.txtWeight.Text.Trim

        Try
            If Not CheckNum(qty) Then
                SetMessage(lblMessage, "数量必须是数字", False)
                txtQTY.Focus()
                Return
            End If
            If Not CheckNum(weight) Then
                SetMessage(lblMessage, "重量必须是数字", False)
                txtWeight.Focus()
                Return
            End If
            'If Not CheckNum(printqty) Then
            '    SetMessage(lblMessage, "打印数量必须是数字", False)
            '    txtPrintQTY.Focus()
            '    Return
            'End If
            Dim strSQL As New StringBuilder
            strSQL.AppendLine(" INSERT INTO [m_ShipSheetPrint_t]( [Vendor], [DeliveryDate], [GoodsName], [OrderID], [PartNum], [QTY], [Weight], [IQCRemark], [CreateUserID])" &
                          " VALUES( N'" & Me.txtVendor.Text.Trim & "', '" & Me.dtpDeleveryDate.Text.Trim & "', N'" & Me.txtGoodsName.Text.Trim & "', '" & Me.txtOrderID.Text.Trim & "', '" &
                          Me.txtPartid.Text.Trim & "', " & IIf(String.IsNullOrEmpty(qty), "NULL", qty) & ", " & IIf(String.IsNullOrEmpty(weight), "NULL", weight) & ",N'" & Me.txtRemark.Text.Trim & "','" &
                          VbCommClass.VbCommClass.UseId & "' )")
            DbOperateUtils.ExecSQL(strSQL.ToString)
            GetQueryData()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "保存异常", False)
        End Try

    End Sub
    Private Sub SaveEdit()
        Dim qty As String = Me.txtQTY.Text.Trim
        Dim weight As String = Me.txtWeight.Text.Trim

        Try
            If Not CheckNum(qty) Then
                SetMessage(lblMessage, "数量必须是数字", False)
                txtQTY.Focus()
                Return
            End If
            If Not CheckNum(weight) Then
                SetMessage(lblMessage, "重量必须是数字", False)
                txtWeight.Focus()
                Return
            End If
            'If Not CheckNum(printqty) Then
            '    SetMessage(lblMessage, "打印数量必须是数字", False)
            '    txtPrintQTY.Focus()
            '    Return
            'End If
            Dim strSQL As New StringBuilder
            strSQL.AppendLine(" UPDATE [m_ShipSheetPrint_t] SET [Vendor] = N'" & Me.txtVendor.Text.Trim & "',[DeliveryDate] = '" & Me.dtpDeleveryDate.Text.Trim & "'  ,[GoodsName] = N'" & Me.txtGoodsName.Text.Trim & "'," &
                            " [OrderID] = '" & Me.txtOrderID.Text.Trim & "'   ,[PartNum] = '" & Me.txtPartid.Text.Trim & "',[QTY] = " & IIf(String.IsNullOrEmpty(qty), "NULL", qty) &
                            ",[Weight] = " & IIf(String.IsNullOrEmpty(weight), "NULL", weight) & ",[IQCRemark] = N'" & Me.txtRemark.Text.Trim & "'  ,[UpdateUserID] ='" &
                           VbCommClass.VbCommClass.UseId & "'   ,[UpdateTime] =getDate() " &
                 " WHERE   TicketID='" & Me.Ticket & "'")
            DbOperateUtils.ExecSQL(strSQL.ToString)
            GetQueryData()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "保存异常", False)
        End Try

    End Sub
    Private Sub SavePrint()

        Try
           
            Dim strSQL As New StringBuilder
            strSQL.AppendLine(" UPDATE [m_ShipSheetPrint_t] SET  [PrintUserID] ='" &
                           VbCommClass.VbCommClass.UseId & "',[PrintTime] =getDate(),[PrintQTY] = " & IIf(String.IsNullOrEmpty(ShipPrint.PrintQty), "NULL", ShipPrint.PrintQty) &
                 " WHERE   TicketID='" & Me.Ticket & "'")
            DbOperateUtils.ExecSQL(strSQL.ToString)
            GetQueryData()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "保存异常", False)
        End Try
    End Sub
    Private Function CheckNum(ByVal num As String) As Boolean
        If String.IsNullOrEmpty(num) Then
            Return True
        End If
        If IsNumeric(num) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub GetQueryData()
        Dim Sqlstr As New StringBuilder
        Sqlstr.Append("SELECT   TicketID, Vendor, DeliveryDate, GoodsName, OrderID, PartNum, QTY, Weight, IQCRemark, CreateUserID, CreateTime,  PrintUserID,PrintTime,PrintQTY " &
                 "   FROM     m_ShipSheetPrint_t WHERE 1=1 ")
        If Not String.IsNullOrEmpty(Me.txtVendor.Text.Trim) Then
            Sqlstr.Append(" AND VENDOR LIKE N'%" & Me.txtVendor.Text.Trim.ToUpper & "%'")
        End If
        If Not String.IsNullOrEmpty(Me.txtGoodsName.Text.Trim) Then
            Sqlstr.Append(" AND GOODSNAME LIKE N'%" & Me.txtGoodsName.Text.Trim.ToUpper & "%'")
        End If
        If Not String.IsNullOrEmpty(Me.txtOrderID.Text.Trim) Then
            Sqlstr.Append(" AND ORDERID LIKE '%" & Me.txtOrderID.Text.Trim.ToUpper & "%'")
        End If
        If Not String.IsNullOrEmpty(Me.txtPartid.Text.Trim) Then
            Sqlstr.Append(" AND PARTNUM LIKE '%" & Me.txtPartid.Text.Trim.ToUpper & "%'")
        End If
        'If Not String.IsNullOrEmpty(Me.dtpDeleveryDate.Text.Trim) Then
        '    Sqlstr.Append(" AND DeliveryDate = '" & Me.dtpDeleveryDate.Text.Trim & "'")
        'End If
        Sqlstr.Append(" ORDER BY DeliveryDate DESC")
        Try
            Me.dgvList.DataSource = DbOperateUtils.GetDataTable(Sqlstr.ToString)
            Me.lblNum.Text = ""
        Catch ex As Exception
            SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub
    Private Sub ControlToolBar(ByVal type As String)
        Select Case type
            Case "Edit"
                Me.ToolNew.Enabled = False
                Me.ToolPrt.Enabled = False
                Me.ToolCommit.Enabled = True
            Case "New"
                Me.ToolCommit.Enabled = True
                Me.ToolPrt.Enabled = False
            Case Else
                Me.ToolEdit.Enabled = True
                Me.ToolNew.Enabled = True
                Me.ToolQuery.Enabled = True
                Me.ToolDelete.Enabled = False
                Me.ToolPrt.Enabled = True
                Me.ToolCommit.Enabled = False
                Me.Ticket = ""
                Me.txtVendor.Text = ""
                Me.txtGoodsName.Text = ""
                Me.txtOrderID.Text = ""
                Me.txtPartid.Text = ""
                Me.txtQTY.Text = ""
                Me.txtWeight.Text = ""
                Me.txtRemark.Text = ""
                Me.dtpDeleveryDate.Text = DateTime.Now.Date
  
                lblPrinter.Visible = False

        End Select
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