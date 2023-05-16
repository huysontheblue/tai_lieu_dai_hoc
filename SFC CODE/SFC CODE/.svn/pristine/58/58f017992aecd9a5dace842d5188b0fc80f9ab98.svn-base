Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.IO

Public Class FrmImport

    Dim strSQL As String
    Dim dt As DataTable
    Dim dg As DataTable
    Dim db As DataTable
    Dim scoreList = New List(Of String)()
    Dim TableName As String
    Public tab As String


    Private Sub FrmImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'FillCombox(toolImport.ComboBox)
        FillCombox(cboQueryType)
        DtStar.Value = DateTime.Now.AddDays(-7).ToString()
        DtEnd.Value = DateTime.Now.AddDays(+1).ToString()
    End Sub
    Private Sub FillCombox(ByVal comboBox As ComboBox)

        strSQL = "select QryName from m_ExcelTempletM_t where Usey = 'Y'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        comboBox.DataSource = dt
        comboBox.DisplayMember = "QryName"
        comboBox.ValueMember = "QryName"
    End Sub
    Private Sub Excel()
        strSQL = "SELECT M.TableName, A.FieldName,A.ExcelColChName FROM (select * from m_ExcelTempletD_t where QryCode = (select QryCode from m_ExcelTempletM_t where QryName = N'" & cboQueryType.Text & "')) AS A LEFT JOIN m_ExcelTempletM_t M ON A.QryCode = M.QryCode ORDER BY A.SQE "
        dt = DbOperateReportUtils.GetDataTable(strSQL)
        TableName = dt.Rows(0)(0).ToString()
        For i = 0 To Conversion.Int(dt.Rows.Count - 1)
            scoreList.Add(dt.Rows(i)(2))
        Next
    End Sub

    'Private Sub toolImport_DropDownClosed(sender As Object, e As EventArgs) Handles toolImport.DropDownClosed
    '    Try

    '        Excel()
    '        Dim sdfimport As New OpenFileDialog
    '        sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
    '        If sdfimport.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
    '        Dim filename As String = ""
    '        Dim errorMsg As String = ""
    '        filename = sdfimport.FileName
    '        Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAsA(filename, 0, 0, errorMsg)
    '        'Dim columns As Integer = dtUploadData.Columns.Count
    '        For index = 0 To dtUploadData.Columns.Count - 1

    '            If scoreList.Contains(dtUploadData.Rows(0)(index).ToString()) Then
    '                dtUploadData.Columns(index).ColumnName() = dtUploadData.Rows(0)(index).ToString()
    '            End If
    '            'dtUploadData.Columns(index).ColumnName() = dtUploadData.Rows(0)(index).ToString()
    '        Next
    '        dtUploadData.Rows.RemoveAt(0)
    '        Dim PASS As Int32 = 0
    '        Dim FILL As Int32 = 0
    '        Dim QTY As Int32 = 0
    '        Dim ShipmentNo, PlanDate, PoNo, PartId, CustPartID, ProjectDesc, Quantity, NetWeight, GrossWeight, WarehouseNO, FactoryNO, StockPileNO As String
    '        Dim da As DataTable = New DataTable()
    '        da.Columns.Add("ShipmentNo")
    '        da.Columns.Add("NG")
    '        For i = 0 To dtUploadData.Rows.Count - 1
    '            ShipmentNo = dtUploadData.Rows(i)(dt.Rows(0)(2))
    '            PlanDate = dtUploadData.Rows(i)(dt.Rows(1)(2))
    '            PoNo = dtUploadData.Rows(i)(dt.Rows(2)(2))
    '            PartId = dtUploadData.Rows(i)(dt.Rows(3)(2))
    '            CustPartID = dtUploadData.Rows(i)(dt.Rows(4)(2))
    '            ProjectDesc = dtUploadData.Rows(i)(dt.Rows(5)(2))
    '            Quantity = dtUploadData.Rows(i)(dt.Rows(6)(2))
    '            NetWeight = dtUploadData.Rows(i)(dt.Rows(7)(2))
    '            GrossWeight = dtUploadData.Rows(i)(dt.Rows(8)(2))
    '            WarehouseNO = dtUploadData.Rows(i)(dt.Rows(9)(2))
    '            FactoryNO = dtUploadData.Rows(i)(dt.Rows(10)(2))
    '            StockPileNO = dtUploadData.Rows(i)(dt.Rows(11)(2))
    '            da.Rows.Add()
    '            da.Rows(FILL)(0) = ShipmentNo
    '            strSQL = "select ShipmentNo from m_DeliveryOrder_t WHERE ShipmentNo = '" & ShipmentNo & "'"
    '            dg = DbOperateReportUtils.GetDataTable(strSQL)
    '            If dg.Rows.Count > 0 Then
    '                da.Rows(FILL)(1) = "交货编号重复"
    '                FILL += 1
    '                Continue For
    '            End If
    '            strSQL = "INSERT INTO " & TableName & " (ShipmentNo,PlanDate,PoNo,PartId,CustPartID,ProjectDesc,Quantity,NetWeight,GrossWeight,WarehouseNO,FactoryNO,StockPileNO,UserId,InTime) " &
    '                " VALUES (N'" & ShipmentNo & "',N'" & PlanDate & "',N'" & PoNo & "',N'" & PartId & "',N'" & CustPartID & "',N'" & ProjectDesc & "'," &
    '                "N'" & Quantity & "',N'" & NetWeight & "',N'" & GrossWeight & "',N'" & WarehouseNO & "',N'" & FactoryNO & "',N'" & StockPileNO & "',N'" & VbCommClass.VbCommClass.UseId & "',getdate())"
    '            If Not String.IsNullOrEmpty(strSQL.ToString) Then
    '                DbOperateUtils.ExecSQL(strSQL.ToString)
    '                PASS += 1
    '            End If
    '        Next
    '        MessageBox.Show("导入成功" & PASS & "条 失败" & (dtUploadData.Rows.Count - PASS) & "")
    '        If dtUploadData.Rows.Count - PASS > 0 Then
    '            QTY = da.Rows.Count
    '            If da.Rows(QTY - 1)(1).ToString() = "" Then
    '                da.Rows(QTY - 1).Delete()
    '            End If
    '            UserinfDg.DataSource = da
    '        End If
    '    Catch ex As Exception
    '        SysMessageClass.WriteErrLog(ex, "ProductionPlan.FrmImport", "toolImport_Click", "sys")
    '    End Try
    'End Sub
    '作废当前选中行数据
    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        Dim A As String
        Dim B As String
        Dim C As String = cboQueryType.Text
        Dim D As String
        If UserinfDg.RowCount < 1 OrElse UserinfDg.CurrentRow Is Nothing Then Exit Sub
        A = UserinfDg.CurrentRow.Index
        B = UserinfDg.Rows(UserinfDg.CurrentRow.Index).Cells(0).Value.ToString()
        D = UserinfDg.Rows(UserinfDg.CurrentRow.Index).Cells(4).Value.ToString()
        Dim dr As DialogResult = MessageBox.Show("是否作废'" & B & "'？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If dr = DialogResult.OK Then
            strSQL = "UPDATE m_DeliveryOrder_t SET Usey = 'N' ,updTime = getdate() where ShipmentNo = '" & B & "'and CustPartID = '" & D & "'"
            DbOperateUtils.ExecSQL(strSQL)
            MessageBox.Show("已作废")
        End If
        strSQL = "select shipmentNo AS " & scoreList(0) & ",PlanDate AS " & scoreList(1) & ",PoNo AS '参考订单采购单号',PartId AS " & scoreList(3) & ",CustPartID AS " & scoreList(4) & ",ProjectDesc AS " & scoreList(5) & ",Quantity AS " & scoreList(6) & ",NetWeight AS " & scoreList(7) & ",GrossWeight AS " & scoreList(8) & ",WarehouseNO AS " & scoreList(9) & ",FactoryNO AS " & scoreList(10) & ",StockPileNO AS " & scoreList(11) & ",(select UserName from m_users_t where UserID=a.UserID) AS '录入人员' ,a.Intime AS '录入时间'  from m_DeliveryOrder_t a left join m_users_t b on a.UserID = b.UserID where a.Usey = 'Y' and a.InTime >='" & DtStar.Value.ToString("yyyy/MM/dd") & "' and a.InTime <='" & DtEnd.Value.ToString("yyyy/MM/dd") & "'"
        db = DbOperateUtils.GetDataTable(strSQL)
        UserinfDg.DataSource = db
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Excel()
        strSQL = "select shipmentNo AS " & scoreList(0) & ",PlanDate AS " & scoreList(1) & ",PoNo AS '参考订单采购单号',PartId AS " & scoreList(3) & ",CustPartID AS " & scoreList(4) & ",ProjectDesc AS " & scoreList(5) & ",Quantity AS " & scoreList(6) & ",NetWeight AS " & scoreList(7) & ",GrossWeight AS " & scoreList(8) & ",WarehouseNO AS " & scoreList(9) & ",FactoryNO AS " & scoreList(10) & ",StockPileNO AS " & scoreList(11) & ",(select UserName from m_users_t where UserID=a.UserID) AS '录入人员' ,a.Intime AS '录入时间'  from m_DeliveryOrder_t a left join m_users_t b on a.UserID = b.UserID where a.Usey = 'Y' and a.InTime >='" & DtStar.Value.ToString("yyyy/MM/dd") & "' and a.InTime <='" & DtEnd.Value.ToString("yyyy/MM/dd") & "'"
        If String.IsNullOrEmpty(TextBox1.Text.Trim) = False Then
            strSQL = strSQL & " AND a.shipmentNo='" & TextBox1.Text.Trim & "'"
        End If
        db = DbOperateUtils.GetDataTable(strSQL)
        UserinfDg.DataSource = db
    End Sub

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        Dim frm As FrmInput = New FrmInput
        frm.ShowDialog()

        Excel()
        strSQL = "select top 100 shipmentNo AS " & scoreList(0) & ",PlanDate AS " & scoreList(1) & ",PoNo AS '参考订单采购单号',PartId AS " & scoreList(3) & ",CustPartID AS " & scoreList(4) & ",ProjectDesc AS " & scoreList(5) & ",Quantity AS " & scoreList(6) & ",NetWeight AS " & scoreList(7) & ",GrossWeight AS " & scoreList(8) & ",WarehouseNO AS " & scoreList(9) & ",FactoryNO AS " & scoreList(10) & ",StockPileNO AS " & scoreList(11) & ",(select UserName from m_users_t where UserID=a.UserID) AS '录入人员' ,a.Intime AS '录入时间'  from m_DeliveryOrder_t a left join m_users_t b on a.UserID = b.UserID where a.Usey = 'Y' order by a.InTime desc"
        db = DbOperateUtils.GetDataTable(strSQL)
        UserinfDg.DataSource = db
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolLoadMoBan_Click(sender As Object, e As EventArgs) Handles toolLoadMoBan.Click
        Try
            Dim ssf = New SaveFileDialog()
            ssf.FileName = "出货单-SAP.XLSX"
            ssf.Filter = "Excel|*.XLSX"
            If ssf.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Using fs As FileStream = CType(ssf.OpenFile(), FileStream)
                    Dim data = System.IO.File.ReadAllBytes("\\192.168.20.123\SFCShare\File\出货单导入模板\出货单-SAP.XLSX")
                    fs.Write(data, 0, data.Length)
                    fs.Flush()
                End Using
                MessageUtils.ShowInformation("下载成功!")
            Else
                MessageUtils.ShowInformation("下载失败!")
            End If
        Catch ex As Exception
            MessageUtils.ShowError("下载异常:" & vbCrLf & ex.Message)
        End Try
    End Sub
End Class