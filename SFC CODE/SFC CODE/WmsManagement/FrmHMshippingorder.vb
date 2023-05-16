Imports System.Windows.Forms
Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmHMshippingorder

    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Dim i As Int32
        Dim sdfimport As New OpenFileDialog
        sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
        If sdfimport.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
        Dim filename As String = ""
        Dim errorMsg As String = ""
        Dim ReMark As String = ""
        filename = sdfimport.FileName
        Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAsA(filename, 0, 0, errorMsg)
        If dtUploadData.Columns.Count <> 14 Then
            MessageBox.Show("格式不正确")
            Return
        End If
        dtUploadData.Rows.RemoveAt(0)
        For i = 0 To dtUploadData.Rows.Count - 1
            Dim TIME As String = dtUploadData.Rows(i)(0).ToString()
            Dim ADDRESS As String = dtUploadData.Rows(i)(1).ToString()
            Dim ShpgNt As String = dtUploadData.Rows(i)(2).ToString()
            Dim bookingnote As String = dtUploadData.Rows(i)(3).ToString()
            Dim shippingQty As String = dtUploadData.Rows(i)(4).ToString()
            Dim Cartons As String = dtUploadData.Rows(i)(5).ToString()
            Dim SAPShippingList As String = dtUploadData.Rows(i)(6).ToString()
            Dim PartNo As String = dtUploadData.Rows(i)(7).ToString()
            Dim CYorCFS As String = dtUploadData.Rows(i)(8).ToString()
            Dim type As String = dtUploadData.Rows(i)(9).ToString()
            Dim shipaddressed As String = dtUploadData.Rows(i)(10).ToString()
            Dim recipients As String = dtUploadData.Rows(i)(11).ToString()
            Dim phone As String = dtUploadData.Rows(i)(12).ToString()
            Dim DL As String = dtUploadData.Rows(i)(13).ToString()
            If DL = "" Then
                Continue For
            End If
            If PartNo = "" Then
                Continue For
            End If
            If shippingQty = "" Then
                Continue For
            End If
            Dim strSQL As String = "SELECT DL FROM  m_ShippingList_t WHERE DL ='" + DL + "' AND PARTNO = '" + PartNo + "'"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                Continue For
            End If
            strSQL = "INSERT INTO dbo.m_ShippingList_t(shippTIME,ADDRESS,ShpgNt,bookingnote, shippingQty, Cartons,SAPShippingList,PartNo,CYorCFS,type,shipaddressed,recipients,phone,DL,insetTIME,USREID)" &
                   " VALUES('" + TIME + "',N'" + ADDRESS + "',N'" + ShpgNt + "',N'" + bookingnote + "',N'" + shippingQty + "',N'" + Cartons + "',N'" + SAPShippingList + "',N'" + PartNo + "',N'" + CYorCFS + "',N'" + type + "',N'" + shipaddressed + "',N'" + recipients + "',N'" + phone + "',N'" + DL + "',GETDATE(),'" + VbCommClass.VbCommClass.UseId + "')"
            DbOperateUtils.GetDataTable(strSQL)
        Next
        MessageBox.Show("导入成功")
        Dim SQL As String = "SELECT TOP 1000 * FROM m_ShippingList_t ORDER BY insetTIME DESC"
        Dim dr As DataTable = DbOperateUtils.GetDataTable(SQL)
        dataGrid.DataSource = dr
        'A()
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim SQL As String = "SELECT * FROM m_ShippingList_t WHERE 1=1 "
        If txtPONumber.Text <> "" Then
            SQL += "and DL = '" + txtPONumber.Text.Trim() + "'"
        End If

        If chkDeliveryDate.Checked = True Then
            SQL += "and shippTIME = '" + dtpTime.Text + "'"
        End If
        SQL += " ORDER BY insetTIME DESC"
        Dim dr As DataTable = DbOperateUtils.GetDataTable(SQL)
        dataGrid.DataSource = dr
    End Sub

    Private Sub FrmHMshippingorder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dtpTime.Text = Date.Now.AddHours(-7.5).Date.ToString("yyyy/MM/dd").ToString
        Dim SQL As String = "SELECT TOP 1000 * FROM m_ShippingList_t ORDER BY insetTIME DESC"
        Dim dr As DataTable = DbOperateUtils.GetDataTable(SQL)
        dataGrid.DataSource = dr
    End Sub

    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        If Me.dataGrid.Rows.Count = 0 OrElse Me.dataGrid.CurrentRow Is Nothing Then
            Exit Sub
        End If
        Dim index As Int16 = dataGrid.CurrentRow.Index
        Dim DL As String = dataGrid.Rows(index).Cells("DL").Value
        Dim PartNo As String = dataGrid.Rows(index).Cells("PartNo").Value
        Dim SQL As String = "DELETE m_ShippingList_t WHERE DL = '" + DL + "' AND PartNo = '" + PartNo + "'"
        DbOperateUtils.GetDataTable(SQL)
        dataGrid.Rows.Remove(dataGrid.Rows(index))
        MessageUtils.ShowInformation("删除成功")
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub lkFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkFile.LinkClicked
        ExcelUtils.GetExcelTemplate(VbCommClass.VbCommClass.PrintDataModle, "华米出货单导入模板")
    End Sub
    Private Sub Query()
        For rowIndex As Integer = 0 To dataGrid.Rows.Count - 1
            If dataGrid.Rows(rowIndex).Cells("STATES").Value.ToString = "N" Then
                dataGrid.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.LightGray
            Else
                dataGrid.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.White
            End If
        Next
        tsbLabel1.Text = "行数：" + dataGrid.Rows.Count.ToString
    End Sub

    Private Sub dataGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGrid.CellClick
        If Me.dataGrid.Rows.Count = 0 OrElse Me.dataGrid.CurrentRow Is Nothing Then
            Exit Sub
        End If
        Dim index As Int16 = dataGrid.CurrentRow.Index
        If dataGrid.Rows(index).Cells("STATES").Value.ToString = "N" Then
            toolDelete.Enabled = False
        Else
            toolDelete.Enabled = True
        End If
    End Sub

    Private Sub dataGrid_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dataGrid.DataBindingComplete
        Query()
    End Sub
End Class