Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmWareHouseIn
    Private locationId As String
    Private locationName As String


    Private Sub FrmWareHouseIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me.dgvReturn
            .AutoResizeColumns()
            .AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            .ScrollBars = ScrollBars.Both
        End With
    End Sub

    Private Sub ToolBasic_Click(sender As Object, e As EventArgs) Handles ToolBasic.Click
        Dim frm As FrmLocationSet = New FrmLocationSet
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            locationId = frm.locationId
            locationName = frm.locationName
            txtOutwhid.Text = frm.OutId

            lblLocation.Text = locationName
        End If

    End Sub

    Private Sub txtEquipment_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCarton.KeyPress
        If e.KeyChar = Chr(13) Then
            ScanCarton(txtCarton.Text.Trim)
        End If
    End Sub

    Private Sub ScanCarton(cartonId As String)
        Try
            '
            If lblLocation.Text = "" Then
                MessageUtils.ShowWarning("请选择库位再进行箱扫描！")
                Me.txtCarton.Clear()
                Me.txtCarton.Focus()
                Exit Sub
            End If

            If txtCarton.Text = "" Then
                MessageUtils.ShowWarning("请输入箱扫描！")
                Me.txtCarton.Focus()
                Exit Sub
            End If

            Dim cartondid As String = txtCarton.Text.Trim

            Dim strSQL As String =
            " declare @strmsgid varchar(1),@strmsgText nvarchar(500),@partid varchar(100),@Qty varchar(100),@moid varchar(100)" &
            " exec m_Wh_CartonScanIn_p '{0}' ,'{1}','{2}','{3}',@strmsgid output , @strmsgText output, " &
                    "@partid output , @moid output, @Qty output" &
            " select @strmsgid,@strmsgText,@partid,@moid,@Qty"
            strSQL = String.Format(strSQL, cartondid, SysMessageClass.UseId, locationId, txtOutwhid.Text)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "0"
                        SetMessage("FAIL", dt.Rows(0)(1).ToString())
                        Me.txtCarton.Clear()
                        txtCarton.Focus()
                        Exit Sub
                    Case "1"
                        SetMessage("PASS", "外箱条码扫描成功！")
                        Dim partID As String = dt.Rows(0)(2).ToString()
                        Dim moid As String = dt.Rows(0)(3).ToString()
                        Dim Qty As String = dt.Rows(0)(4).ToString()

                        Me.dgvReturn.Rows.Insert(0, cartondid, partID, moid, Qty, locationName, SysMessageClass.UseId, Now())
                        If dgvReturn.Rows.Count > 30 Then
                            dgvReturn.Rows.RemoveAt(dgvReturn.Rows.Count - 2)
                        End If
                        Me.txtCarton.Clear()
                        txtCarton.Focus()
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

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub toolInDetail_Click(sender As Object, e As EventArgs) Handles toolInDetail.Click
        Dim Moid As String = ""
        If dgvReturn.Rows.Count > 0 Then
            Moid = Me.dgvReturn.Rows(0).Cells(2).Value.ToString.Trim
        End If

        Dim frm As FrmWareHouseInDetail = New FrmWareHouseInDetail

        frm.Mmoid = Moid
        frm.ShowDialog()
    End Sub

End Class