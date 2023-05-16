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

Public Class FrmLastPalletSet

    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

    Private Sub ButExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButExit.Click

        Me.Close()
        'CartonScanOption.vLastPalletCheck = False
        'CartonScanOption.vIsLastPallet = False

    End Sub

    Private Sub FrmLastPalletSet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ''CartonScanOption.vIsLastPallet = False
        If Me.ActiveControl.Name <> "ButOk" Then CartonScanOption.vLastPalletCheck = False

    End Sub

    Private Sub FrmLastPalletSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ''Dim sqlreader As SqlDataReader = Conn.GetDataReader("select * from m_PartPack_t where Partid='" & CartonScanOption.PartidStr & "' and  packid = 'C' and multiy = 'Y'")
        '' Dim MultiQty As String
        ''While sqlreader.Read
        'MultiQty = sqlreader!MultiQty.ToString()
        ''CartonScanOption.vNormalPalletMultQty
        '' Dim items As String() = MultiQty.Split(","c)
        For i As Integer = 0 To CartonScanOption.vNormalPalletMultQty.Length - 1
            Me.ChkPallet.Items.Add("第" & i + 1 & "箱包裝數量-" & CartonScanOption.vNormalPalletMultQty(i).ToString, True)
        Next
        ''End While
        '' sqlreader.Close()
        Me.TxtPassWord.Focus()

    End Sub

#Region "確定設置尾數棧板"
    Private Sub ButOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButOk.Click

        Dim LoginClass As New TextHandle
        Dim CheckRead As SqlClient.SqlDataReader
        Dim PubClass As New MainFrame.SysDataHandle.SysDataBaseClass
        If ChkPallet.CheckedItems.Count < 1 Then
            MessageBox.Show("沒有設置任何棧板包裝箱資料！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CartonScanOption.LastPrintCheck = False
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
                Dim QtyStr As String = ""
                Dim QtyRecord As String = ""
                For i As Integer = 0 To ChkPallet.Items.Count - 1
                    If ChkPallet.GetItemChecked(i) = True Then
                        QtyRecord = ChkPallet.Items(i).ToString.Substring(InStr(ChkPallet.Items(i).ToString(), "-"))
                        QtyStr = QtyStr & IIf(QtyStr = "", QtyRecord, "," & QtyRecord)
                    End If
                Next
                '' Dim palletNo As String = GeneratePalletNo()

                'PubClass.ExecSql(" insert into m_PalletM_t(Palletid,Moid,Teamid,MultiBox,MultiQty,Palletqty,PalletStatus,UserID,Intime)" & _
                '            "values('" & palletNo & "','" & CartonScanOption.MoidStr & "','" & CartonScanOption.LineStr & "','" & ChkPallet.CheckedItems.Count & "','" & QtyStr & "','1','N','" & SysMessageClass.UseId & "',getdate() ) ")
                ''CartonScanOption.vPalletNo = palletNo


                CartonScanOption.vCurrentPalletCartonIndex = 1
                CartonScanOption.vCurrentPalletCartonCount = ChkPallet.CheckedItems.Count
                '' CartonScanOption.PackNumber = CartonScanOption.MoidStr & palletNo & "1"
                CartonScanOption.vPalletMultQty = QtyStr.Split(",")
                CartonScanOption.vMultQtyStr = QtyStr
                CartonScanOption.vLastPalletCheck = True
                PubClass = Nothing
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("設置尾數棧板時出錯!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

    End Sub

    Private Function GeneratePalletNo() ''生成棧板編號，工單+線別+流水號(4位)

        Dim palletNoStr As String = String.Empty
        Dim cnn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim palletReader As SqlDataReader = cnn.GetDataReader("select isnull(max(Palletid),'') maxpallno from m_PalletM_t where Moid='" & CartonScanOption.MoidStr & "' and Teamid='" & CartonScanOption.LineStr & "'")
        If palletReader.HasRows Then
            While palletReader.Read
                If palletReader!maxpallno = "" Then
                    palletNoStr = CartonScanOption.MoidStr + CartonScanOption.LineStr + "0001"
                Else
                    palletNoStr = Replace(palletReader!maxpallno, CartonScanOption.MoidStr & CartonScanOption.LineStr, "1")
                    palletNoStr = CartonScanOption.MoidStr & CartonScanOption.LineStr & (palletNoStr + 1).ToString.Substring(1)
                End If
            End While
        End If
        palletReader.Close()
        Return palletNoStr

    End Function

#End Region

    Private Sub TxtPassWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassWord.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.ActiveControl = ButOk
            ButOk_Click(sender, e)
        End If

    End Sub

End Class