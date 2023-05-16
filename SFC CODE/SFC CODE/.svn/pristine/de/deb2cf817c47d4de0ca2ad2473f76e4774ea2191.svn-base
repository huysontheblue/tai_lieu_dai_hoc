Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports LXWarehouseManage
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports MainFrame

Public Class FrmWmsOutterBBY
    Dim strMESShippingNO As String = ""
    Dim rtValue As String

    Private Sub txtPO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPO.KeyPress


        If e.KeyChar = Chr(13) Then
            If Not DateVerify(Me.txtPO) Then
                Return
            End If
        End If
    End Sub
    Private Function DateVerify(ByVal txtName As TextBox) As Boolean
        Try

            If txtPO.Name.ToUpper() = "txtPO".ToUpper() Then

                If String.IsNullOrEmpty(Me.txtPO.Text.Trim()) Then
                    SetMessage("FAIL", "PO单号不能为空")
                    Me.txtPO.Text = String.Empty
                    Me.txtPO.Focus()
                    Return False
                End If

                SetScanFocus()
                Return True
            End If

            If txtSKU.Name.ToUpper() = "txtSKU".ToUpper() Then

                If String.IsNullOrEmpty(Me.txtPO.Text.Trim()) Then

                    SetMessage("FAIL", "PO单号不能为空")
                    Me.txtPO.Text = String.Empty
                    Me.txtPO.Focus()
                    Return False
                End If

                If String.IsNullOrEmpty(Me.txtSKU.Text.Trim()) Then

                    SetMessage("FAIL", "SKU码不能为空")
                    Me.txtSKU.Text = String.Empty
                    Me.txtSKU.Focus()
                    Return False
                End If

                SetScanFocus()
                Return True
            End If

            Return True
        Catch
            SetMessage("FAIL", "数据验证异常")
            Return False
        End Try
    End Function
    Private Sub SetScanFocus()
        If String.IsNullOrEmpty(Me.txtPO.Text.Trim()) Then
            Me.txtPO.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Me.txtSKU.Text.Trim()) Then
            Me.txtSKU.Focus()
            Return
        End If
    End Sub

    Private Sub txtSKU_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSKU.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                If Not DateVerify(Me.txtPO) Then
                    Return
                End If
                Dim outTotalQty As String = ""
                Dim outTotalCartonCount As String = ""
                Dim outScanCartonCount As String = ""
                Dim outMESShippingNO As String = ""
                Dim PO As String = txtPO.Text
                Dim SKU As String = txtSKU.Text.Trim()
                Dim type As String = "1"
                Dim sql As String = "   declare @RTVALUE VARCHAR(1) declare @RTMSG NVARCHAR(128) declare @OUTTOTALQTY FLOAT  declare  @OUTTOTALCNT FLOAT declare @OUTSCANCNT FLOAT declare @OUTDELIVERYNO VARCHAR(32)" &
               "exec [Exec_BBYShippingScan] @RTVALUE output,@RTMSG output ,@OUTTOTALQTY output, @OUTTOTALCNT output,@OUTSCANCNT output,@OUTDELIVERYNO  output, " &
                " '" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','" & strMESShippingNO & "','" & Me.txtPO.Text & "','" & Me.txtSKU.Text & "','" & VbCommClass.VbCommClass.UseId & "',1 " &
                 " SELECT @RTVALUE,@RTMSG,@OUTTOTALQTY,@OUTTOTALCNT,@OUTSCANCNT,@OUTDELIVERYNO"
                Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
                If dt.Rows(0)(0).ToString() = "1" Then
                    SetMessage("PASS", "执行扫描成功")
                    dgvUnPackBox.Rows.Insert(0, txtPO.Text, txtSKU.Text, VbCommClass.VbCommClass.UseId, DateTime.Now.ToString())
                    Me.txtSKU.Text = String.Empty
                    Me.txtSKU.Focus()
                    Me.lblRequirement.Text = dt.Rows(0)(3).ToString
                    Me.lblSentNumber.Text = dt.Rows(0)(4).ToString()
                    strMESShippingNO = dt.Rows(0)(5).ToString()
                    Me.lblOut.Text = (CInt(Me.lblRequirement.Text) - CInt(Me.lblSentNumber.Text)).ToString()
                    '再扫描PO号
                    txtPO.Text = ""
                    txtPO.Focus()
                    If lblOut.Text = "0" Then
                        strMESShippingNO = "" '扫描完成重置No
                        SetMessage("PASS", "扫描完成！")
                    End If
                Else
                    SetMessage("FAIL", dt.Rows(0)(1).ToString())
                    Me.txtSKU.Focus()
                End If
            End If
        Catch ex As Exception
            SetMessage("FAIL", "扫描检查箱号异常")
            Me.txtSKU.Text = String.Empty
            Me.txtSKU.Focus()
        End Try
    End Sub
    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            lblMessage.Text = "FAIL" & message
            lblMessage.ForeColor = Color.Red
        Else
            lblMessage.Text = "PASS" & message
            lblMessage.ForeColor = Color.Green
        End If
    End Sub

    Private Sub FrmWmsOutterBBY_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class