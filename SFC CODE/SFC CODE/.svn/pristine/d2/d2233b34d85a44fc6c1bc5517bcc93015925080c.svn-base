Imports System.Data.SqlClient
Imports MainFrame.SysCheckData

Public Class FrmRepeatCheck

    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

    Private Sub TxtCartonID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCartonID.KeyPress

        If e.KeyChar = Chr(13) Then
            TxtCartonID.Text = Replace(TxtCartonID.Text, "'", "")
            If Me.TxtCartonID.Text = "" Then
                Label26.Text = "外箱条码序号不能为空，请先扫描外箱条码序号..."
                TxtCartonID.Clear()
                TxtCartonID.Focus()
                Exit Sub
            End If
            Dim mRead As SqlDataReader
            'Dim mStatu As String = ""
            Dim Cartonqty As String = ""
            mRead = Conn.GetDataReader("select b.Qty,a.Cartonqty from m_Carton_t a join m_Snsbarcode_t b on a.cartonid=b.sbarcode   where SBarcode='" & TxtCartonID.Text & "'")
            If mRead.HasRows Then
                While mRead.Read
                    Label31.Text = mRead!Cartonqty
                    Cartonqty = mRead!Qty
                End While

                'mRead.Close()
                'Conn.PubConnection.Close()
            Else
                mRead.Close()
                Conn.PubConnection.Close()
                Label26.Text = "系统中，不存在该外箱序号，或还未进行包装作业..."
                TxtCartonID.Clear()
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            'If mStatu = "Y" Then
            TxtCartonID.Enabled = False
            TxtSbarcode.Text = ""
            TxtSbarcode.Enabled = True
            TxtSbarcode.Focus()
            Label28.Text = Cartonqty
            Label26.Text = "外箱条码序号录入成功，请进行产品重码检测..."

            DataGridView2.Rows.Clear()
            mRead = Conn.GetDataReader("select Cartonid,Ppid,State,Userid,Intime from m_PpidCheckRecord_t where Cartonid='" & TxtCartonID.Text & "'")
            If mRead.HasRows Then
                While mRead.Read
                    DataGridView2.Rows.Add(mRead!Cartonid, mRead!Ppid, mRead!Userid, mRead!Intime)
                End While
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            Label30.Text = DataGridView2.Rows.Count
            'Else
            '    Label26.Text = "外箱条码序号还未包装完成，不能进行重码检测..."
            'End If
        End If

    End Sub

    Private Sub TxtSbarcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSbarcode.KeyPress

        If e.KeyChar = Chr(13) Then
            If Me.TxtCartonID.Text = "" Then
                TxtCartonID.Clear()
                TxtCartonID.Focus()
                Label26.Text = "外箱条码序号不能为空，请先扫描外箱条码序号..."
                Exit Sub
            End If
            If Me.TxtSbarcode.Text = "" Then
                TxtSbarcode.Clear()
                TxtSbarcode.Focus()
                Label26.Text = "产品条码序号不能为空，请先扫描产品条码序号..."
                Exit Sub
            End If
            TxtSbarcode.Text = Replace(TxtSbarcode.Text, "'", "")
            Dim mRead As SqlDataReader
            mRead = Conn.GetDataReader("select ppid from m_PpidCheckRecord_t where ppid='" & TxtSbarcode.Text & "'")
            If mRead.HasRows Then
                mRead.Close()
                Conn.PubConnection.Close()
                Dim FrmError As New FrmScanErrPrompt(TxtSbarcode.Text, "系统中已经存在该条码、请确认是否为重码...")
                FrmError.ShowDialog()
                TxtSbarcode.Text = ""
                TxtSbarcode.Focus()
                Label26.Text = "系统中已经存在该条码、请确认是否为重码..."
                Exit Sub
            End If
            mRead.Close()

            mRead = Conn.GetDataReader("select cartonid from m_Cartonsn_t where ppid='" & TxtSbarcode.Text & "' and cartonid<>'" & TxtCartonID.Text & "'")
            If mRead.HasRows Then
                Dim mcartonid As String = ""
                While mRead.Read
                    mcartonid = mRead!cartonid
                End While
                mRead.Close()
                Conn.PubConnection.Close()
                Dim FrmError As New FrmScanErrPrompt(TxtSbarcode.Text, "该产品条码已经包装在外箱" & mcartonid & "中，混装或重码...")
                FrmError.ShowDialog()
                TxtSbarcode.Text = ""
                TxtSbarcode.Focus()
                Label26.Text = "该产品条码已经包装在外箱" & mcartonid & "中，混装或重码..."
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            mRead = Conn.GetDataReader("select b.Cartonqty from m_Cartonsn_t a join m_Carton_t b on a.Cartonid=b.Cartonid where ppid='" & TxtSbarcode.Text & "' and a.cartonid='" & TxtCartonID.Text & "'")
            If mRead.HasRows Then
                While mRead.Read
                    Me.Label31.Text = mRead!Cartonqty
                End While
                mRead.Close()
                Conn.PubConnection.Close()
                'Dim FrmError As New FrmScanErrPrompt(TxtSbarcode.Text, "该外箱不存在该产品，或该产品还未包装或系统中不存在...")
                'FrmError.ShowDialog()
                'TxtSbarcode.Text = ""
                'TxtSbarcode.Focus()
                'Label26.Text = "该外箱不存在该产品，或该产品还未进行包装..."
                'Exit Sub
            Else
                mRead.Close()
                Conn.PubConnection.Close()
                Dim FrmError As New FrmScanErrPrompt(TxtSbarcode.Text, "该外箱不存在该产品，或该产品还未包装或系统中不存在...")
                FrmError.ShowDialog()
                TxtSbarcode.Text = ""
                TxtSbarcode.Focus()
                Label26.Text = "该外箱不存在该产品，或该产品还未进行包装..."
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            Try
                Conn.ExecSql(" insert into m_PpidCheckRecord_t(Cartonid,Ppid,State,Userid,Intime)values('" & TxtCartonID.Text & "','" & TxtSbarcode.Text & "','Y','" & SysMessageClass.UseId & "',getdate()" & ")")
                'mRead = Conn.GetDataReader("select count(*) qty from m_Carton_t where cartonid='" & TxtCartonID.Text & "'")
                'Dim CartonQty As Integer = 0
                'If mRead.HasRows Then
                '    While mRead.Read
                '        CartonQty = CInt(mRead!qty)
                '    End While
                'End If
                'mRead.Close()
                DataGridView2.Rows.Insert(0, TxtCartonID.Text, TxtSbarcode.Text, SysMessageClass.UseId, Now.ToLongDateString)
                DataGridView2.AutoResizeColumns()
                If CInt(Label30.Text) = CInt(Label28.Text) Then
                    Label30.Text = "0"
                    Label28.Text = "0"
                    Label26.Text = "该箱产品序号校验通过，扫描下一外箱条码序号..."
                    DataGridView2.Rows.Clear()
                    Me.TxtSbarcode.Clear()
                    TxtSbarcode.Enabled = False
                    TxtCartonID.Clear()
                    TxtCartonID.Enabled = True
                    TxtCartonID.Focus()
                Else
                    Label30.Text = DataGridView2.Rows.Count
                    Label26.Text = "该产品序号校验通过，扫描下一产品条码序号..."
                    Me.TxtSbarcode.Text = ""
                    TxtSbarcode.Focus()
                End If

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Me.TxtCartonID.Enabled = True
        TxtCartonID.Clear()
        TxtCartonID.Focus()
        TxtSbarcode.Text = ""
        TxtSbarcode.Enabled = False
        Label30.Text = "0"
        Label28.Text = "0"
        Label31.Text = "0"
        DataGridView2.Rows.Clear()

    End Sub

    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
End Class