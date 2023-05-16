Public Class FrmHWScanBarCodeContrast

    Private Sub tsmiBtnCartonReSet_Click(sender As Object, e As EventArgs) Handles tsmiBtnCartonReSet.Click
        tsmilblCarton.Text = Nothing
        tsmilblQty.Text = Nothing
        txtCartonBarCode.Text = Nothing
        txtBarCode.Text = Nothing
        txtCartonBarCode.Focus()
        txtError.Text = Nothing
    End Sub

    Private Sub txtCartonBarCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCartonBarCode.KeyPress
        If e.KeyChar = Chr(13) Then
            Try
                If String.IsNullOrEmpty(txtMoid.Text) Then
                    SetMessage(False, "请先选择工单!")
                    txtCartonBarCode.Text = Nothing
                    Exit Sub
                ElseIf txtCartonBarCode.Text.IndexOf("【") >= 0 Then
                    SetMessage(False, "请切换成英文输入法!")
                    txtCartonBarCode.Text = Nothing
                    txtCartonBarCode.Focus()
                    Exit Sub
                End If
                Dim CartonBarCode = txtCartonBarCode.Text
                'ASN条码
                If CartonBarCode.Contains("[)>") And CartonBarCode.Contains("S19") Then
                    tsmilblCarton.Text = CartonBarCode.Substring(CartonBarCode.IndexOf("S19") + 1)
                    tsmilblQty.Text = Integer.Parse(tsmilblCarton.Text.Substring(tsmilblCarton.Text.IndexOf("Q") + 1)).ToString()
                Else
                    tsmilblCarton.Text = CartonBarCode
                    tsmilblQty.Text = Integer.Parse(tsmilblCarton.Text.Substring(tsmilblCarton.Text.IndexOf("Q") + 1)).ToString()
                End If
               
                Dim ScanTotal = GetScaneCartonTotal()
                tsmiTotalBarCodeCount.Text = ScanTotal.ToString()
                SetMessage(True, "箱条码:" + CartonBarCode + "解析成功")
                txtBarCode.Focus()
            Catch ex As Exception
                SetMessage(False, ex.Message)
                txtBarCode.Text = Nothing
                txtBarCode.Focus()
            End Try
            
        End If
    End Sub

    Private Sub SetMessage(ByVal V As Boolean, ByVal Err As String)
        If V Then
            txtError.ForeColor = Color.Green
        Else
            txtError.ForeColor = Color.Red
        End If
        txtError.Text = Err
    End Sub

    Private Sub txtBarCode_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub FrmHWScanBarCodeContrast_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCartonBarCode.Focus()
    End Sub

    Private Sub DataLoad()
        Dim where = " where 1=1 "
        If String.IsNullOrEmpty(txtSearchMoid.Text.Trim()) = False Then
            where += " and MoID='" & txtSearchMoid.Text.Trim().ToUpper() & "'"
        End If
        If String.IsNullOrEmpty(txtSearchCarton.Text.Trim()) = False Then
            where += " and CartonCode like'%" & txtSearchCarton.Text.Trim() & "%'"
        End If
        If String.IsNullOrEmpty(txtSearchBagCode.Text.Trim()) = False Then
            where += " and BagBarcode like '%" & txtSearchBagCode.Text.Trim() & "%'"
        End If
        Dim sql = "select top 300 * from m_HWScanBarCodeContrastLog_t " & where & " order by InTime desc"
        dgvData.AutoGenerateColumns = False
        dgvData.DataSource = MainFrame.DbOperateUtils.GetDataTable(sql)
    End Sub

   

    Private Sub tsmiBtnClose_Click(sender As Object, e As EventArgs) Handles tsmiBtnClose.Click
        Me.Close()
    End Sub

    Private Sub txtBarCode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtBarCode.PreviewKeyDown
        If e.KeyValue = 13 Then
            Try
                Dim CartonNum = Convert.ToInt32(tsmilblCarton.Text.Substring(tsmilblCarton.Text.IndexOf("Q") + 1))
                Dim BarCodeNum = Convert.ToInt32(txtBarCode.Text.Substring(txtBarCode.Text.IndexOf("Q") + 1))
                If String.IsNullOrEmpty(tsmilblCarton.Text) Then
                    SetMessage(False, "请先扫描箱条码!")
                    Exit Sub
                ElseIf tsmilblCarton.Text.Trim().Length <> txtBarCode.Text.Trim().Length Then
                    SetMessage(False, "箱条码:" + tsmilblCarton.Text + "的长度与袋条码:" + txtBarCode.Text.Trim() + "的长度不一样!")
                    txtBarCode.Text = Nothing
                    Exit Sub
                ElseIf BarCodeNum > CartonNum Then
                    SetMessage(False, "袋条码:" + txtBarCode.Text + ",Q数量:" + BarCodeNum.ToString() + ",不能大于箱条码:" + tsmilblCarton.Text.Trim() + ",Q数量:" + CartonNum.ToString())
                    txtBarCode.Text = Nothing
                    Exit Sub
                End If

                Dim ScanTotal = GetScaneCartonTotal() + BarCodeNum
                If ScanTotal > Integer.Parse(tsmilblQty.Text) Then
                    SetMessage(False, "扫描袋条码Q总数量:" + ScanTotal.ToString() + ",不能大于箱条码:" + tsmilblCarton.Text + ",Q总数量：" + CartonNum.ToString())
                    txtBarCode.Text = Nothing
                    txtBarCode.Focus()
                    Exit Sub
                End If
                Dim StrOne = tsmilblCarton.Text.Substring(0, tsmilblCarton.Text.IndexOf("Q"))
                Dim StrTwo = txtBarCode.Text.Substring(0, txtBarCode.Text.IndexOf("Q"))
                Dim UserID = MainFrame.SysCheckData.SysMessageClass.UseId
                Dim UserName = MainFrame.DbOperateUtils.GetDataTable("select UserName from m_Users_t where UserID='" & UserID & "'").Rows(0)(0).ToString()
                If StrOne.Equals(StrTwo) Then
                    txtError.Text = Nothing
                    Dim sql = String.Format("insert into m_HWScanBarCodeContrastLog_t" & vbCrLf &
                    "(CartonCode,BagBarcode,InTime,EmpCode,EmpName,MoID) values('{0}','{1}',getdate(),'{2}',N'{3}','{4}')", txtCartonBarCode.Text.Trim(), txtBarCode.Text.Trim(), UserID, UserName, txtMoid.Text)
                    MainFrame.DbOperateUtils.ExecSQL(sql)
                    SetMessage(True, "袋条码:" + txtBarCode.Text + ",与箱条码:" & tsmilblCarton.Text & "批对成功!")
                    txtBarCode.Text = Nothing
                    txtBarCode.Focus()
                    tsmiTotalBarCodeCount.Text = GetScaneCartonTotal().ToString()
                Else
                    SetMessage(False, "袋条码:" + txtBarCode.Text + ",与箱条码:" & tsmilblCarton.Text & "批对失败!")
                    txtBarCode.Text = Nothing
                    txtBarCode.Focus()
                End If
            Catch ex As Exception
                SetMessage(False, ex.Message)
                txtBarCode.Text = Nothing
                txtBarCode.Focus()
            End Try
        End If
    End Sub

    ''' <summary>
    ''' 袋条码总数
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetScaneCartonTotal() As Integer
        Dim Total As Integer = 0
        Dim sqlCheck = "select isnull(sum(cast(substring(BagBarcode, charindex('Q',BagBarcode)+1,len(BagBarcode)) as int)),0)" & vbCrLf &
                "from m_HWScanBarCodeContrastLog_t" & vbCrLf &
                "where CartonCode='" + txtCartonBarCode.Text.Trim() + "' and moid='" + txtMoid.Text.Trim() + "'"
        Dim dt = MainFrame.DbOperateUtils.GetDataTable(sqlCheck)
        Total = Convert.ToInt32(dt.Rows(0)(0))
        Return Total
    End Function

    Private Sub TabControl1_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Selecting
        If TabControl1.SelectedIndex = 1 Then
            DataLoad()
        End If
    End Sub

    Private Sub dgvData_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvData.RowPostPaint
        Dim R = (e.RowIndex + 1).ToString()
        Using sb = New SolidBrush(dgvData.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(R, e.InheritedRowStyle.Font, sb, New Point(e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4))
        End Using
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        DataLoad()
    End Sub

    Private Sub BtnSelectMoid_Click(sender As Object, e As EventArgs) Handles BtnSelectMoid.Click
        Dim frm = New FrmWorkOrder()
        Dim dia = frm.ShowDialog()
        If dia = Windows.Forms.DialogResult.OK Then
            txtMoid.Text = frm._MoNO
            txtCartonBarCode.Focus()
            txtCartonBarCode.Text = Nothing
        End If
    End Sub
End Class