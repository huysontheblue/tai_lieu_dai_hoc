Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmWareHouseOut


    Private Sub FrmWareHouseOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me.dgvWHsOutD
            .AutoResizeColumns()
            .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            .ScrollBars = ScrollBars.Both
        End With
    End Sub

    '退出
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            ScanOutwhid()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '明细出货查询 
    Private Sub toolCargoOutDetail_Click(sender As Object, e As EventArgs) Handles toolCargoOutDetail.Click
        Dim frm As FrmWareHouseOutDetail = New FrmWareHouseOutDetail
        frm.outId = txtOutwhid.Text
        frm.ShowDialog()
    End Sub

    '扫描出货单号
    Private Sub txtOutwhid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOutwhid.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtOutwhid.Text.Trim = "" Then
                Exit Sub
            End If

            ScanOutwhid()
        End If
    End Sub

    Private Sub ScanOutwhid()
        Try

            lblResult.Text = ""

            If String.IsNullOrEmpty(txtOutwhid.Text) = True Then
                SetMessage("FAIL", "请输入出货单号！")
                Me.txtCarton.Clear()
                Exit Sub
            End If

            Dim strSQL As String = "SELECT CartonID, ProNo, LotNo, Version, Qty, Location, UserId, Intime FROM m_WhsOutD_t where Outwhid = '{0}' "
            strSQL = String.Format(strSQL, txtOutwhid.Text)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            'If dt.Rows.Count = 0 Then
            '    SetMessage("FAIL", String.Format("出货单号{0}还没有出货！", txtOutwhid.Text))
            '    Me.txtCarton.Clear()
            '    Exit Sub
            'End If

            Me.dgvWHsOutD.Rows.Clear()
            For Each DrRow As DataRow In dt.Rows
                Me.dgvWHsOutD.Rows.Add(DrRow("CartonID").ToString.Trim, DrRow("ProNo").ToString.Trim,
                                       DrRow("LotNo").ToString.Trim, DrRow("Version").ToString.Trim,
                                       DrRow("Qty").ToString.Trim, DrRow("Location").ToString.Trim,
                                       DrRow("Userid").ToString.Trim, DrRow("Intime").ToString.Trim)
            Next

            SetQtys(txtOutwhid.Text)

            Me.txtCarton.Focus()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '扫描箱号
    Private Sub txtCarton_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCarton.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtCarton.Text.Trim = "" Then
                Exit Sub
            End If

            ScanCarton()
        End If
    End Sub

    Private Sub SetQtys(outid As String)
        Dim strSQL As String =
            " select sum(NeedQty)NeedQty,sum(AlreadyQty)AlreadyQty,(sum(NeedQty) - sum(alreadyqty))WaitQty" &
            " from ( " &
            " select sum(qty) NeedQty,0 as AlreadyQty  from m_WHsDeliver_t where outwhid = '{0}'" &
            " union all" &
            " select 0, isnull(sum(qty),0)  from m_WhsOutD_t where outwhid = '{0}') A"

        strSQL = String.Format(strSQL, outid)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            lblAlreadyQty.Text = dt.Rows(0)("AlreadyQty").ToString()
            lblWaitQty.Text = dt.Rows(0)("WaitQty").ToString()
            lblNeedQty.Text = dt.Rows(0)("NeedQty").ToString()
            If dt.Rows(0)("WaitQty") = 0 Then
                SetMessage("PASS", "该出货单已完成出货！")
            End If
        End If
    End Sub

    Private Sub ScanCarton()
        Try
            Dim barcode As String = txtCarton.Text
            Dim strSQL As String = " declare @strmsgid varchar(1),@strmsgText nvarchar(500),@AlreadyQty INT ,@WaitQty INT ,@NeedQty INT " &
                             " declare @ProNo2 varchar(100),@LotNo2 varchar(100),@Version2 varchar(100),@Cartonqty2 INT,@Location2 varchar(100)" &
                             " exec m_Wh_CartonScanOut_p '{0}','{1}','{2}', @strmsgid output,@strmsgText output,@AlreadyQty output,@WaitQty output,@NeedQty output," &
                             " @ProNo2 output,@LotNo2 output,@Version2 output,@Cartonqty2 output,@Location2 output " &
                             " select @strmsgid,@strmsgText,@AlreadyQty as AlreadyQty,@WaitQty as WaitQty ,@NeedQty as NeedQty," &
                             " @ProNo2 as ProNo,@LotNo2 as LotNo,@Version2 as Version,@Cartonqty2 as Cartonqty,@Location2 as Location"

            strSQL = String.Format(strSQL, txtOutwhid.Text, barcode, SysMessageClass.UseId)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "0"
                        SetMessage("FAIL", dt.Rows(0)(1).ToString())
                        Me.txtCarton.Clear()
                        Exit Sub
                    Case 1
                        Me.txtCarton.Clear()
                        SetMessage("PASS", "外箱条码" + Trim(barcode) + "扫描成功！")

                        Dim ProNo As String = dt.Rows(0)("ProNo").ToString()
                        Dim LotNo As String = dt.Rows(0)("LotNo").ToString()
                        Dim Version As String = dt.Rows(0)("Version").ToString()
                        Dim Cartonqty As String = dt.Rows(0)("Cartonqty").ToString()
                        Dim Location As String = dt.Rows(0)("Location").ToString()

                        lblAlreadyQty.Text = dt.Rows(0)("AlreadyQty").ToString()
                        lblWaitQty.Text = dt.Rows(0)("WaitQty").ToString()
                        lblNeedQty.Text = dt.Rows(0)("NeedQty").ToString()

                        If dt.Rows(0)("WaitQty") = 0 Then
                            SetMessage("PASS", "该出货单已完成出货！")
                        End If

                        Me.dgvWHsOutD.Rows.Insert(0, barcode, ProNo, LotNo, Version, Cartonqty, Location, SysMessageClass.UseId, Now())

                        dgvWHsOutD.ClearSelection()
                        dgvWHsOutD.Rows(0).Cells(0).Selected = True
                        If dgvWHsOutD.Rows.Count > 30 Then
                            dgvWHsOutD.Rows.RemoveAt(dgvWHsOutD.Rows.Count - 2)
                        End If
                End Select
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try

    End Sub

    '设置信息
    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            lblResult.Text = message
            lblResult.ForeColor = Color.Red
        Else
            lblResult.Text = message
            lblResult.ForeColor = Color.Green
        End If
    End Sub

End Class