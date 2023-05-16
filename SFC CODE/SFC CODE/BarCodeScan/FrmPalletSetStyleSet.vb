''程式功能:線上掃描檢測及打印外箱條碼
''程式開發人員時間:2009/08/05 歐翔烽

#Region "Imports area"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.data.SqlClient
Imports BarCodeScan.Data
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData

#End Region


Public Class FrmPalletSetStyleSet

    ''Dim multiboxStr As String

    Private Sub FrmPalletSetStyleSet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Me.ActiveControl.Name <> "ButOk" Then CartonScanOption.vIsPalletStyle = False

    End Sub

    Private Sub FrmPalletSetStyleSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CobPalletStyle.Focus()
        loadDataInCombox()

    End Sub

    Private Sub TxtPassWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassWord.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.ActiveControl = ButOk
            ButOk_Click(sender, e)
        End If

    End Sub

    Private Sub loadDataInCombox()

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim cnnRead As SqlDataReader = Conn.GetDataReader("select multibox,multiqty from m_partpack_t where partid='" & CartonScanOption.PartidStr & "'  and packid='C' and usey='Y' and multiy='Y'")
        If cnnRead.Read Then
            ''multiboxStr = cnnRead!multibox
            Dim multStr() As String = cnnRead!multiqty.ToString.Replace(Chr(13), "").Replace(Chr(10), "").Trim.Split(";")
            For i As Integer = 0 To multStr.Length - 1
                CobPalletStyle.Items.Add(multStr(i).ToString)
            Next
        End If

    End Sub

    Private Sub ButOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButOk.Click

        Dim LoginClass As New TextHandle
        Dim CheckRead As SqlClient.SqlDataReader
        Dim PubClass As New MainFrame.SysDataHandle.SysDataBaseClass
        If Me.CobPalletStyle.Text = "" Then
            MessageBox.Show("沒有設置任何棧板包裝箱資料！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CartonScanOption.vIsPalletStyle = False
            Exit Sub
        End If
        Try
            CheckRead = PubClass.GetDataReader("select distinct a.* from m_Users_t a left join m_userright_t b on a.userid=b.userid where  a.autoid='" & Me.TxtPassWord.Text & "' and b.tkey='m0510d_'")
            If Not CheckRead.Read Then
                MessageBox.Show("密碼不正確或無權限！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CartonScanOption.LastPrintCheck = False
                Me.TxtPassWord.Focus()
                Me.TxtPassWord.SelectAll()
                CheckRead.Close()
                Exit Sub
            Else
                CheckRead.Close()
                ''Dim QtyStr As String = ""
                ''Dim QtyRecord As String = ""
                'For i As Integer = 0 To ChkPallet.Items.Count - 1
                '    If ChkPallet.GetItemChecked(i) = True Then
                '        QtyRecord = ChkPallet.Items(i).ToString.Substring(InStr(ChkPallet.Items(i).ToString(), "-"))
                '        QtyStr = QtyStr & IIf(QtyStr = "", QtyRecord, "," & QtyRecord)
                '    End If
                'Next  PubDataReader!multiqty.ToString.Replace(Chr(13), "").Replace(Chr(10), "").Trim.Split(";")
                Dim multStr() As String = Me.CobPalletStyle.Text.ToString.Replace(Chr(13), "").Replace(Chr(10), "").Trim.Split(",")
                CartonScanOption.vCurrentPalletCartonIndex = 1
                'CartonScanOption.vCurrentPalletCartonCount = multStr.Length
                'CartonScanOption.vPalletMultQty = CobPalletStyle.Text.Split(",")
                'CartonScanOption.vMultQtyStr = Me.CobPalletStyle.Text

                CartonScanOption.vNormalPalletMultQty = CobPalletStyle.Text.ToString.Replace(Chr(13), "").Replace(Chr(10), "").Trim.Split(",")
                CartonScanOption.vNormalPalletCartonCount = multStr.Length
                CartonScanOption.vMultQtyStr = Me.CobPalletStyle.Text
                CartonScanOption.vIsPalletStyle = True
                PubClass = Nothing
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("設置棧板包裝方式時出錯!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

    End Sub

    Private Sub ButExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButExit.Click

        Me.Close()

    End Sub

    Private Sub CobPalletStyle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobPalletStyle.KeyPress

        If e.KeyChar = Chr(13) Then
            TxtPassWord.Focus()
        End If

    End Sub
End Class