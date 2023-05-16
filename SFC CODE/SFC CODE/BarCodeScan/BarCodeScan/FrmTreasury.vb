Imports MainFrame

Public Class FrmTreasury
    Dim tt As DataTable
    Dim Numbers As String

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim formation As New Frminformation
        formation.ShowDialog()
        Try
            Numbers = VbCommClass.VbCommClass.PPartid
            tt = DbOperateUtils.GetDataTable("select Numbers,Ppartid,PO,BoxName,PackingList,Mark,Qty,Remarks,type,Userid,time from m_Shipments WHERE Numbers='" & Numbers & "'")
            For Each w As Control In Textcheck.Controls
                If TypeName(w) = "TextBox" Then
                    If CType(w, TextBox).Tag <> "" Then
                        CType(w, TextBox).Text = tt.Rows(0)(Convert.ToInt16(CType(w, TextBox).Tag) - 1)
                    End If
                End If
            Next
            If tt.Rows(0)(8) = "非直发直体" Then
                CheckBox1.Checked = True
            Else
                CheckBox1.Checked = False
            End If
            txtCartonID.Enabled = True
            txtCartonID.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ShowFrmScanErrPrompt()
        Dim FrmError As New FrmScanErrPrompt
        FrmError.ShowDialog()
    End Sub
   
    Private Sub Textcheck_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCartonID.KeyDown
        If e.KeyValue = 13 Then
            If txtCartonID.Text.Trim <> "" Then
                tt = DbOperateUtils.GetDataTable("SELECT Numbers,Ppartid,PO,BoxName,PackingList,Mark,Qty,Remarks,type,Userid,time from m_Shipments " & _
                                                 "WHERE state='N' AND Mark='" + txtCartonID.Text.Trim + "'")
                If tt.Rows().Count > 0 Then
                    For Each w As Control In Textcheck.Controls
                        If TypeName(w) = "TextBox" Then
                            If CType(w, TextBox).Tag <> "" Then
                                CType(w, TextBox).Text = tt.Rows(0)(Convert.ToInt16(CType(w, TextBox).Tag) - 1)
                            End If
                        End If
                    Next
                    Label12.Text = DbOperateUtils.GetDataTable("select*FROM m_Treasury where Numbers='" & txtCartonID.Text.Trim & "'").Rows.Count
                    Textppidcheck.Enabled = True
                    Textppidcheck.Focus()
                Else
                    WorkStantOption.ErrorStr = "校验失败扫描唛头不存在"
                    WorkStantOption.BarCodeStr = "校验失败扫描唛头不存在"
                    WorkStantOption.vMainBarCode = "校验失败扫描唛头不存在"
                    Textcheck.Text = ""
                    ShowFrmScanErrPrompt()
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub Textppidcheck_KeyDown(sender As Object, e As KeyEventArgs) Handles Textppidcheck.KeyDown
        If e.KeyValue = 13 Then
            If TextQty.Text.Trim = Label12.Text.Trim Then
               Shipments()
            End If
            If DbOperateUtils.GetDataTable(" SELECT*from m_Inspection where ppid='" + Textppidcheck.Text.Trim + "' and state='Y'").Rows.Count > 0 Then
            Else
                WorkStantOption.ErrorStr = "产品未通过送检无法出货"
                WorkStantOption.BarCodeStr = "产品未通过送检无法出货"
                WorkStantOption.vMainBarCode = "产品未通过送检无法出货"
                Textppidcheck.Text = ""
                ShowFrmScanErrPrompt()
                Return
            End If
            If DbOperateUtils.GetDataTable(" SELECT*FROM m_Treasury where Ppartid='" & Textppidcheck.Text.Trim & "'").Rows.Count = 0 Then
                DbOperateUtils.ExecSQL(" INSERT INTO m_Treasury(Numbers,Ppartid,Userid) VALUES ('" & txtCartonID.Text.Trim & "','" & Textppidcheck.Text.Trim & "','" & VbCommClass.VbCommClass.UseId & "')")
                Label12.Text = Convert.ToInt16(Label12.Text.Trim) + 1
                Me.DGridBarCode.Rows.Insert(0, TextNumbers.Text.Trim, Textppidcheck.Text.Trim, VbCommClass.VbCommClass.UseId, Date.Now)
                If TextQty.Text.Trim = Label12.Text.Trim Then
                   Shipments()
                Else
                    Textppidcheck.Text = ""
                End If
            Else
                WorkStantOption.ErrorStr = "产品已出货不能重复出货"
                WorkStantOption.BarCodeStr = "产品已出货不能重复出货"
                WorkStantOption.vMainBarCode = "产品已出货不能重复出货"
                Textppidcheck.Text = ""
                ShowFrmScanErrPrompt()
            End If
        End If
    End Sub
    Private Sub Shipments()
        If MessageBox.Show("定单数量已满是否出货", "满箱提示", MessageBoxButtons.YesNo).ToString = "Yes" Then
            For Each w As Control In Textcheck.Controls
                If TypeName(w) = "TextBox" Then
                    CType(w, TextBox).Text = ""
                End If
            Next
            DbOperateUtils.ExecSQL("update m_Shipments SET state='Y' WHERE Mark='" & txtCartonID.Text.Trim & "'")
            txtCartonID.Text = ""
            Textppidcheck.Text = ""
            txtCartonID.Enabled = False
            Textppidcheck.Enabled = False
        Else
            Textppidcheck.Text = ""
        End If
    End Sub
    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        If TextQty.Text.Trim = Label12.Text.Trim Then
            Shipments()
        Else
            MessageBox.Show("为达到出货数量无法出货")
        End If
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        If DbOperateUtils.GetDataTable("select*FROM m_Treasury where Numbers='" & txtCartonID.Text.Trim & "'").Rows.Count > 0 Then
            If MessageBox.Show("是否要清除" + txtCartonID.Text.Trim + "唛头的出货条码", "满箱提示", MessageBoxButtons.YesNo).ToString = "Yes" Then
                DbOperateUtils.ExecSQL("DELETE m_Treasury where Numbers='" & txtCartonID.Text.Trim & "'")
                Label12.Text = "0"
                MessageBox.Show("清除成功")
            End If
        Else
            MessageBox.Show("唛头" + txtCartonID.Text.Trim + "无扫描记录无法清除")
        End If

    End Sub
End Class