#Region "Imports"
Imports System.Windows.Forms
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports MainFrame
Imports SysBasicClass
#End Region
Public Class FrmMerryShipScan

    '是否扫描结束
    Private IsFinish As Boolean = True

    Private Sub FrmMerryShipScan_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        IsFinish = True
    End Sub


#Region "函数"
    Private Sub ScanData()
        If txtBarCode.Text.Trim().Length <> 100 Then
            MessageBox.Show("二维码长度不符")
            Return
        End If
        Try
            Dim o_strSql As New StringBuilder
            Dim Barcode As String = txtBarCode.Text.Trim
            Dim sSn As String = lbBarcode.Text.Trim
            Dim UseId As String = SysMessageClass.UseId
            If CheckData() = True Then
                Dim PPID = Barcode.Substring(0, 20)
                Dim PPIDV As String
                Dim C_Partid As String = PPID.Replace("#", "")
                Dim a As String = PPID
                a = a.Substring(a.Length - 1)
                If a = "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "第一段20位尾部出现#号"
                    Return
                End If
                PPID = Barcode.Substring(20, 10)
                Dim SupplierCode As String = PPID.Replace("#", "")
                a = PPID
                PPIDV = a.Substring(0, 1)
                If PPIDV <> "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "第二段10位开始部位出现数字"
                    Return
                End If
                a = a.Substring(a.Length - 1)
                If a = "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "第二段10位尾部出现#号"
                    Return
                End If


                Dim ShipDate As String = Barcode.Substring(30, 6)

                a = ShipDate
                PPIDV = a.Substring(0, 1)
                If PPIDV = "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If
                a = a.Substring(a.Length - 1)
                If a = "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If





                Dim ss As String = Barcode.Substring(36, 6)
                a = ss
                PPIDV = a.Substring(0, 1)
                If PPIDV = "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If
                a = a.Substring(a.Length - 1)
                If a = "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If



                PPID = Barcode.Substring(42, 20)
                Dim OrderNo As String = PPID.Replace("#", "")
                a = PPID
                PPIDV = a.Substring(0, 1)
                If PPIDV <> "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If
                a = a.Substring(a.Length - 1)
                If a = "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If




                Dim OrderQty As String = CInt(Barcode.Substring(62, 8))
                a = OrderQty
                PPIDV = a.Substring(0, 1)
                If PPIDV = "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If
                a = a.Substring(a.Length - 1)
                If a = "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If



                PPID = Barcode.Substring(70, 15)
                Dim ProDate As String = PPID.Replace("#", "")
                a = PPID
                PPIDV = a.Substring(0, 1)
                If PPIDV <> "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If
                a = a.Substring(a.Length - 1)
                If a = "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If

                PPID = Barcode.Substring(85, 6)
                Dim GP As String = PPID.Replace("#", "")
                a = PPID
                PPIDV = a.Substring(0, 1)
                If PPIDV <> "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If
                a = a.Substring(a.Length - 1)
                If a = "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If


                PPID = Barcode.Substring(91, 9)
                Dim PO As String = PPID.Replace("#", "")
                a = PPID
                PPIDV = a.Substring(0, 1)
                If PPIDV <> "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If
                a = a.Substring(a.Length - 1)
                If a = "#" Then
                    lbUnPackBoxMessage.ForeColor = Color.Red
                    lbUnPackBoxMessage.Text = "二维码中存在#号错误"
                    Return
                End If

                o_strSql.Append("INSERT INTO dbo.m_MerryShipScan_t ")
                o_strSql.Append("(Ppid,sBarCode,C_Partid,SupplierCode,ShipDate,OrderNo,OrderQty,ProDate,GP,ss,PO,USERID,INTIME)")
                o_strSql.Append(" VALUES('" & Barcode & "','" & sSn & "','" & C_Partid & "','" & SupplierCode & "','" & ShipDate & "','" & OrderNo & "','" & OrderQty & "','" & ProDate & "','" & GP & "','" & ss & "','" & PO & "','" & UseId & "',getdate())")

                DbOperateUtils.ExecSQL(o_strSql.ToString)
                SetMessage("PASS", "扫描成功！")
                IsFinish = True
                lbBarcode.Text = "......"
                Me.dgvMerryShip.Rows.Insert(0, sSn, C_Partid, SupplierCode, ShipDate, OrderNo, OrderQty, ProDate, GP, ss, PO, SysMessageClass.UseId, Now())
                '' DGridBarCode.AutoResizeColumns()
                dgvMerryShip.ClearSelection()
                dgvMerryShip.Rows(0).Cells(0).Selected = True
                If dgvMerryShip.Rows.Count > 10 Then
                    dgvMerryShip.Rows.RemoveAt(dgvMerryShip.Rows.Count - 1)
                End If

                txtBarCode.Text = ""
                txtBarCode.Focus()
            End If

        Catch
            lbUnPackBoxMessage.ForeColor = Color.Red
            lbUnPackBoxMessage.Text = "扫描条码错误"
        End Try


    End Sub

    Private Function CheckData() As Boolean
        If Check53AC5554900() = False Then
            Return False
        End If
        If CheckExists() = False Then
            SetMessage("FAIL", "当前条码已扫描过，请勿重复操作!")

            txtBarCode.Text = ""
            txtBarCode.Focus()
            Return False
        End If
        Return True
    End Function

    '左右电池53AC5554900
    Private Function Check53AC5554900() As Boolean
        If txtBarCode.Text.Length < 100 Then
            SetMessage("FAIL", "出货标签长度不足!")
            txtBarCode.Text = ""
            txtBarCode.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function CheckExists() As Boolean
        Dim strSql As String
        strSql = "SELECT ppid from m_MerryShipScan_t where ppid='" & txtBarCode.Text.Trim & "'"
        Dim i As Integer = DbOperateUtils.GetRowsCount(strSql)
        If i > 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub SetMessage(result As String, message As String)

        If result.ToUpper = "FAIL" Then

            lbUnPackBoxResult.Text = "FAIL"
            lbUnPackBoxMessage.Text = message
            lbUnPackBoxResult.ForeColor = Color.Crimson
            lbUnPackBoxMessage.ForeColor = Color.Crimson
        Else
            lbUnPackBoxResult.Text = "PASS"
            lbUnPackBoxMessage.Text = message
            lbUnPackBoxResult.ForeColor = Color.FromArgb(0, 192, 0)
            lbUnPackBoxMessage.ForeColor = Color.FromArgb(0, 192, 0)
        End If

    End Sub

#End Region

    Private Sub txtBarCode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtBarCode.PreviewKeyDown
        If e.KeyValue = 13 Then
            If Not CheckBox1.Checked Then
                lbBarcode.Text = "88888888"
                ScanData()
            Else
                If Not String.IsNullOrEmpty(txtBarCode.Text) Then
                    If IsFinish = True Then
                        If Not String.IsNullOrEmpty(txtBarCode.Text) Then
                            lbBarcode.Text = txtBarCode.Text
                            SetMessage("PASS", "条形码扫描成功，请继续扫描二维码标签......")
                            IsFinish = False
                        End If
                        txtBarCode.Text = ""
                        Exit Sub
                    End If
                    ScanData()
                End If
            End If
        End If
    End Sub
End Class