#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text

#End Region

Public Class FrmCartonLastSet

#Region "怠砰秙ㄆン"

    Private Sub BnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnCancel.Click

        Me.Close()
        CartonScanOption.LastPrintCheck = False

    End Sub

#End Region

    Private Sub TxtPassWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassWord.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.ActiveControl = BnOpenlock
            BnOpenlock_Click(sender, e)
        End If

    End Sub

    Private Sub BnOpenlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnOpenlock.Click

        Dim LoginClass As New TextHandle
        Dim CheckRead As SqlClient.SqlDataReader
        Dim PubClass As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim QtyStr As String = ""


        TxtLastQty.Text = TxtLastQty.Text.Trim
        Dim Ifalg As Integer
        'If CInt(CartonScanOption.) <= CInt(TxtLastQty.Text) Then
        '    MessageBox.Show("Ю计ゴ计秖ぃ┪单赣ン絚计秖", "矗ボ獺", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    CartonScanOption.LastPrintCheck = False
        '    Me.TxtLastQty.Focus()
        '    Me.TxtLastQty.SelectAll()
        '    Exit Sub
        'End If
        CheckRead = PubClass.GetDataReader("select distinct a.* from m_Users_t a left join m_userright_t b on a.userid=b.userid where  a.autoid='" & Me.TxtPassWord.Text & "' and b.tkey='m0510d_'")
        If Not CheckRead.Read Then
            MessageBox.Show("盞絏ぃタ絋┪礚舦", "矗ボ獺", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CartonScanOption.LastPrintCheck = False
            Me.TxtPassWord.Focus()
            Me.TxtPassWord.SelectAll()
            CheckRead.Close()
            Exit Sub
        Else
            CheckRead.Close()
            If CartonScanOption.vCurrentPalletCartonIndex = 0 Then Ifalg = 0 Else Ifalg = CartonScanOption.vCurrentPalletCartonIndex - 1
            If CartonScanOption.vNoFullFlag = True Then
                If CartonScanOption.vPalletMultQty(Ifalg) <= CInt(TxtLastQty.Text) Then
                    MessageBox.Show("Ю计ゴ砞竚计秖ぃ┪单讽玡絚计秖", "矗ボ獺", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CartonScanOption.LastPrintCheck = False
                    Me.TxtLastQty.Focus()
                    Me.TxtLastQty.SelectAll()
                    Exit Sub
                Else
                    CartonScanOption.vPalletMultQty(Ifalg) = CInt(TxtLastQty.Text)
                    CartonScanOption.vMultQtyStr = String.Join(",", CartonScanOption.vPalletMultQty)
                End If
            Else
                If CartonScanOption.vNormalPalletMultQty(Ifalg) <= CInt(TxtLastQty.Text) Then
                    MessageBox.Show("Ю计ゴ砞竚计秖ぃ┪单讽玡絚计秖", "矗ボ獺", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CartonScanOption.LastPrintCheck = False
                    Me.TxtLastQty.Focus()
                    Me.TxtLastQty.SelectAll()
                    Exit Sub
                Else
                    Dim tempMultQtyStr = String.Join(",", CartonScanOption.vNormalPalletMultQty)
                    If CartonScanOption.LastPrintCheck Then
                        CartonScanOption.vLastPalletMultQty(CartonScanOption.vCurrentPalletCartonIndex - 1) = CInt(TxtLastQty.Text)
                        '' CartonScanOption.vLastPalletMultQty(Ifalg) = CInt(TxtLastQty.Text)
                    Else
                        CartonScanOption.vLastPalletMultQty = tempMultQtyStr.ToString.Split(",")
                        CartonScanOption.vLastPalletMultQty(Ifalg) = CInt(TxtLastQty.Text)
                    End If
                    CartonScanOption.vMultQtyStr = String.Join(",", CartonScanOption.vLastPalletMultQty)
                End If
            End If

            CartonScanOption.LastPrintCheck = True
            CartonScanOption.LastPrintQty = CInt(TxtLastQty.Text)
            Me.Close()
            ''Dim SqlStr As String
            ''Dim Dr As SqlClient.SqlDataReader
            ''SqlStr = "select * from m_PartPack_t where packid='C' and partid='" & CartonScanOption.PartidStr & " '  and usey='Y' "
            ''Dr = PubClass.GetDataReader(SqlStr)
            ''If Dr.Read Then
            ''    If LCase(Dr("coderuleid")) = "c001" Then
            ''        CartonScanOption.LastPrintQty = Microsoft.VisualBasic.Right(StrDup(3, "0") & Trim(TxtLastQty.Text), 3)
            ''    Else
            ''        CartonScanOption.LastPrintQty = Trim(TxtLastQty.Text)
            ''    End If
            ''    Dr.Close()
            ''    Me.Close()
            ''End If
        End If

    End Sub

    Private Sub TxtLastQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLastQty.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.TxtPassWord.Focus()
        End If
        If Me.TxtLastQty.Text = "" And e.KeyChar = "0" Then
            e.Handled = True
            Exit Sub
        End If
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = vbTab Or e.KeyChar = vbCr Or e.KeyChar = vbLf Or e.KeyChar = Chr(22) Or e.KeyChar = Chr(24) Or e.KeyChar = Chr(3) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub FrmLastPrintSet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Me.ActiveControl.Name <> "BnOpenlock" Then CartonScanOption.LastPrintCheck = False

    End Sub

   
End Class