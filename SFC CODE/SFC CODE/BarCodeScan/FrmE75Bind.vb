
Imports System.IO



Public Class FrmE75Bind

    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Private Sub ToolStar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStar.Click

        Me.TxtCsn.Clear()
        Me.TxtCsn.Enabled = True
        Me.TxtCsn.Focus()
        Me.TxtLsn.Clear()
        Me.TxtLsn.Enabled = False

    End Sub

    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

#Region "判斷掃描條碼樣式是否正確"

    Shared Function verfyBarCodeStyle(ByVal TxtSnStyle1 As String, ByVal TxtBarCode As String, ByVal TxtSnStyle2 As String) As Boolean

        Dim NewStylesStr As String = ""
        Dim SnStryle() As Char
        Dim SnBarCode() As Char
        Dim I As Byte
        Dim MultSnStyle As String() = Nothing
        If InStr(TxtSnStyle1, ";") > 0 Then
            MultSnStyle = (TxtSnStyle1 & ";" & TxtSnStyle2).Split(";")
            SnStryle = MultSnStyle(0)
        Else
            SnStryle = TxtSnStyle1.ToCharArray
        End If


        SnBarCode = TxtBarCode.ToCharArray
        For I = 0 To UBound(SnStryle)
            If SnStryle(I) = "*" Then
                SnBarCode(I) = "*"
            End If
            NewStylesStr = NewStylesStr + SnBarCode(I)
        Next
        If InStr(TxtSnStyle1, ";") > 0 Then
            For IFlag As Byte = 0 To MultSnStyle.Length - 1
                If MultSnStyle(IFlag) = NewStylesStr Then ''不用instr,以防止出現兩者組合字符符合條件的情況
                    verfyBarCodeStyle = True
                    Exit Function
                End If
            Next
        Else
            If TxtSnStyle2 = NewStylesStr OrElse TxtSnStyle1 = NewStylesStr Then ''不用instr,以防止出現兩者組合字符符合條件的情況
                verfyBarCodeStyle = True
                Exit Function
            End If
        End If

    End Function

#End Region

    Private Sub TxtCsn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCsn.KeyPress

        If e.KeyChar <> Chr(13) Then Exit Sub
        If TxtCsn.Text.Trim = "" Then
            lblmsg.Text = "Cable条码不能为空，请扫描..."
            TxtCsn.Clear()
            TxtCsn.Focus()
            Exit Sub
        End If
        If TxtCsn.Text.Length <> 17 Then
            lblmsg.Text = "Cable条码长度不正确，正确为17位..."
            TxtCsn.Clear()
            TxtCsn.Focus()
            Exit Sub
        End If
        If verfyBarCodeStyle(TextBox1.Text, TxtCsn.Text, TextBox1.Text) = False Then
            lblmsg.Text = "Cable条码标准样式不一致..."
            TxtCsn.Clear()
            TxtCsn.Focus()
            Exit Sub
        End If

        'Dim TestStr As String = System.IO.File.ReadAllText(Application.StartupPath & "\Test.txt")
        'If InStr(TestStr, TxtCsn.Text) > 0 Then
        '    lblmsg.Text = "该USB已经绑定过序号..."
        '    TxtCsn.Clear()
        '    TxtCsn.Focus()
        '    Exit Sub
        'End If
        Dim mRead As SqlClient.SqlDataReader = Conn.GetDataReader("select CableSN from M_LineReadSn_t where CableSN='" & TxtCsn.Text & "'")
        If mRead.HasRows Then
            lblmsg.Text = "该USB已经绑定过序号..."
            TxtCsn.Clear()
            TxtCsn.Focus()
            mRead.Close()
            Exit Sub
        End If
        mRead.Close()
        TxtCsn.Enabled = False
        TxtLsn.Clear()
        TxtLsn.Enabled = True
        TxtLsn.Focus()
        'Conn.GetDataReader("select * from M_LineReadSn_t where CableSN='"")

    End Sub

    Private Sub TxtLsn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLsn.KeyPress

        If InStr(TxtLsn.Text.ToLower, "accessory serial number:") <= 0 Then Exit Sub
        'If e.KeyChar <> Chr(13) Then Exit Sub
        Try
            Dim ReadSn As String = ""
            For i As Integer = 0 To TxtLsn.Lines.Length - 1
                If InStr(TxtLsn.Lines(i).ToString.ToLower, "interface module serial number") > 0 Then
                    ReadSn = TxtLsn.Lines(i).ToString.Split(":")(1).Trim
                    Exit For
                End If
            Next
            If ReadSn.Length <> 17 Then
                lblmsg.Text = "连接器序号长度应为17位..."
                TxtLsn.Text = ""
                TxtLsn.Clear()
                TxtLsn.Text = vbNullString
                TxtLsn.Focus()
                Exit Sub
            End If

            'Dim TestStr As String = System.IO.File.ReadAllText(Application.StartupPath & "\Test.txt")
            'If InStr(TestStr, ReadSn) > 0 Then
            '    lblmsg.Text = "该连接器序号已经绑定USB序号..."
            '    TxtLsn.Text = ""
            '    TxtLsn.Clear()
            '    TxtLsn.Text = vbNullString
            '    TxtLsn.Focus()
            '    Exit Sub
            'End If
            'Dim sw As StreamWriter = File.AppendText(Application.StartupPath & "\Test.txt")
            'sw.WriteLine(TxtCsn.Text & vbTab & ReadSn)
            'sw.Flush()
            'sw.Close()
            'Me.DataGridView1.Rows.Add(TxtCsn.Text, ReadSn)
            'lblmsg.Text = "扫描成功"
            'Me.TxtCsn.Clear()
            'Me.TxtCsn.Enabled = True
            'Me.TxtCsn.Focus()
            'Me.TxtLsn.Clear()
            'Me.TxtLsn.Enabled = False
            Dim mRead As SqlClient.SqlDataReader = Conn.GetDataReader("select CableSN from M_LineReadSn_t where  LineSn='" & ReadSn & "'")
            If mRead.HasRows Then
                lblmsg.Text = "该连接器序号已经绑定USB序号..."

                TxtLsn.Text = ""
                TxtLsn.Clear()

                TxtLsn.Text = vbNullString
                TxtLsn.Focus()
                TxtLsn.SelectAll()
                'SendKeys("{HOME}")

                mRead.Close()
                Exit Sub
            Else
                mRead.Close()
                If ChkScanppid.Checked = True Then
                    TxtCsn.Text = ReadSn
                End If
                Conn.ExecSql("insert into M_LineReadSn_t values('" & TxtCsn.Text & "','" & ReadSn & "','" & TxtLsn.Text & "',getdate())")
                Me.DataGridView1.Rows.Add(TxtCsn.Text, ReadSn)
                lblmsg.Text = "扫描成功"
                If ChkScanppid.Checked = False Then
                    Me.TxtCsn.Clear()
                    Me.TxtCsn.Enabled = True
                    Me.TxtCsn.Focus()
                    Me.TxtLsn.Clear()
                    Me.TxtLsn.Enabled = False
                Else
                    Me.TxtCsn.Clear()
                    Me.TxtCsn.Enabled = False
                    Me.TxtLsn.Clear()
                    Me.TxtLsn.Enabled = True
                    Me.TxtLsn.Focus()
                End If
            End If

        Catch ex As Exception
            TxtLsn.Text = ""
            TxtLsn.Clear()
            TxtLsn.Focus()
            lblmsg.Text = ex.Message
        End Try
    End Sub

    Private Sub ToolConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolConfig.Click

        Dim sqlstr As String = "select * from M_LineReadSn_t where intime between '" & D1.Value & "' and '" & D2.Value & "'  "
        If Txtc.Text.Trim <> "" Then
            sqlstr = sqlstr & " and  CableSN='" & Txtc.Text.Trim & "'"
        End If
        Dim mRead As SqlClient.SqlDataReader = Conn.GetDataReader(sqlstr)
        If mRead.HasRows Then
            While mRead.Read
                Me.DataGridView2.Rows.Add(mRead!CableSN.ToString, mRead!LineSn.ToString, mRead!LineMsg.ToString, mRead!intime.ToString)
            End While
        End If
        mRead.Close()

    End Sub

    'Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    '    MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = "172.17.30.200"

    'End Sub

    Private Sub toolExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click

        Me.Close()

    End Sub

    Private Sub ChkScanppid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkScanppid.CheckedChanged

        If ChkScanppid.Checked = True Then

            TxtCsn.Enabled = False
            TxtLsn.Clear()
            TxtLsn.Enabled = True
            TxtLsn.Focus()
        Else
            TxtCsn.Enabled = True
            TxtCsn.Clear()
            TxtLsn.Clear()
            TxtLsn.Enabled = False
            TxtLsn.Focus()
        End If

    End Sub
End Class
