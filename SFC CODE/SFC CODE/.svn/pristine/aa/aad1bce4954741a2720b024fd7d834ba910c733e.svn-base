Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmInput
    Dim strSQL As String
    Dim dt As DataTable
    Dim dg As DataTable
    Dim db As DataTable
    Dim scoreList = New List(Of String)()
    Dim TableName As String
    Public tab As String
    '权限加载可上传类型
    Private Sub FillCombox(ByVal comboBox As ComboBox)
        strSQL = "SELECT B.Ttext AS QryName from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm2000901' and b.listy='N' WHERE a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'"
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

    Private Sub FrmInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCombox(cboQueryType)
        
    End Sub

    Private Sub Btnupload_Click(sender As Object, e As EventArgs) Handles Btnupload.Click
        Try
            If (String.IsNullOrEmpty(Me.cboQueryType.Text.Trim())) Then
                MessageBox.Show("请选择上传类型!")
                Return
            End If
            Excel()
            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If sdfimport.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            Dim filename As String = ""
            Dim errorMsg As String = ""
            filename = sdfimport.FileName
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAsA(filename, 0, 0, errorMsg)
            'Dim columns As Integer = dtUploadData.Columns.Count
            For index = 0 To dtUploadData.Columns.Count - 1

                If scoreList.Contains(dtUploadData.Rows(0)(index).ToString()) Then
                    dtUploadData.Columns(index).ColumnName() = dtUploadData.Rows(0)(index).ToString()
                End If
                'dtUploadData.Columns(index).ColumnName() = dtUploadData.Rows(0)(index).ToString()
            Next
            dtUploadData.Rows.RemoveAt(0)
            Dim PASS As Int32 = 0
            Dim FILL As Int32 = 0
            Dim QTY As Int32 = 0
            Dim ShipmentNo, PlanDate, PoNo, PartId, CustPartID, ProjectDesc, Quantity, NetWeight, GrossWeight, WarehouseNO, FactoryNO, StockPileNO As String
            Dim da As DataTable = New DataTable()
            da.Columns.Add("ShipmentNo")
            da.Columns.Add("NG")
            da.Columns.Add("CustPartID")
            For i = 0 To dtUploadData.Rows.Count - 1
                ShipmentNo = dtUploadData.Rows(i)(dt.Rows(0)(2))
                PlanDate = dtUploadData.Rows(i)(dt.Rows(1)(2))
                PoNo = dtUploadData.Rows(i)(dt.Rows(2)(2))
                PartId = dtUploadData.Rows(i)(dt.Rows(3)(2))
                CustPartID = dtUploadData.Rows(i)(dt.Rows(4)(2))
                ProjectDesc = dtUploadData.Rows(i)(dt.Rows(5)(2))
                Quantity = dtUploadData.Rows(i)(dt.Rows(6)(2))
                NetWeight = dtUploadData.Rows(i)(dt.Rows(7)(2))
                GrossWeight = dtUploadData.Rows(i)(dt.Rows(8)(2))
                WarehouseNO = If(String.IsNullOrEmpty(dtUploadData.Rows(i)(dt.Rows(9)(2)).ToString()) = True, "", dtUploadData.Rows(i)(dt.Rows(9)(2)))
                FactoryNO = dtUploadData.Rows(i)(dt.Rows(10)(2))
                StockPileNO = dtUploadData.Rows(i)(dt.Rows(11)(2))
                da.Rows.Add()
                da.Rows(FILL)(0) = ShipmentNo
                da.Rows(FILL)(2) = CustPartID
                strSQL = "select ShipmentNo from m_DeliveryOrder_t WHERE ShipmentNo = '" & ShipmentNo & "' and CustPartID = '" & CustPartID & "'and Usey = 'Y'"
                dg = DbOperateReportUtils.GetDataTable(strSQL)
                If dg.Rows.Count > 0 Then
                    da.Rows(FILL)(1) = "交货编号重复"
                    FILL += 1
                    Continue For
                End If
                strSQL = "INSERT INTO " & TableName & " (ShipmentNo,PlanDate,PoNo,PartId,CustPartID,ProjectDesc,Quantity,NetWeight,GrossWeight,WarehouseNO,FactoryNO,StockPileNO,UserId,InTime) " &
                    " VALUES (N'" & ShipmentNo & "',N'" & PlanDate & "',N'" & PoNo & "',N'" & PartId & "',N'" & CustPartID & "',N'" & ProjectDesc & "'," &
                    "N'" & Quantity & "',N'" & NetWeight & "',N'" & GrossWeight & "',N'" & WarehouseNO & "',N'" & FactoryNO & "',N'" & StockPileNO & "',N'" & VbCommClass.VbCommClass.UseId & "',getdate())"
                If Not String.IsNullOrEmpty(strSQL.ToString) Then
                    DbOperateUtils.ExecSQL(strSQL.ToString)
                    PASS += 1
                End If
            Next
            MessageBox.Show("导入成功" & PASS & "条 失败" & (dtUploadData.Rows.Count - PASS) & "")
            'If dtUploadData.Rows.Count - PASS > 0 Then
            '    QTY = da.Rows.Count
            '    If da.Rows(QTY - 1)(1).ToString() = "" Then
            '        da.Rows(QTY - 1).Delete()
            '    End If
            '    UserinfDg.DataSource = da
            'End If
            'Dim Fr As FrmImport = New FrmImport
            'Fr.Owner = Me
            'Fr.tab = Me.cboQueryType.Text
            Me.Close()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "ProductionPlan.FrmImport", "toolImport_Click", "sys")
        End Try
    End Sub
End Class