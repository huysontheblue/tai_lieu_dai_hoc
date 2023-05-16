Imports System.Data.SqlClient
Imports MainFrame.SysCheckData

Public Class FrmPackForScrap

    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

    Private Sub TxtCartonID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCartonID.KeyPress

        If e.KeyChar = Chr(13) Then
            TxtCartonID.Text = Replace(TxtCartonID.Text, "'", "")
            ToolUsename.Text = SysMessageClass.UseId
            If Me.TxtCartonID.Text = "" Then
                Label26.Text = "外箱条码序号不能为空，请先扫描外箱条码序号..."
                TxtCartonID.Clear()
                TxtCartonID.Focus()
                Exit Sub
            Else
                Dim mRead As SqlDataReader
                'Dim Cartonqty As String = ""
                mRead = Conn.GetDataReader("select b.Qty,a.Cartonqty,b.Moid from m_CartonScrap_t a join m_Snsbarcode_t b on a.cartonid=b.sbarcode   where SBarcode='" & TxtCartonID.Text & "'")
                If mRead.HasRows Then  '判断m_Carton_t表中是否存在扫入的外箱条码，
                    While mRead.Read
                        lbBefore.Text = mRead!Cartonqty
                        'Cartonqty = mRead!Qty
                        TxtMO.Text = mRead!Moid
                        lbTotal.Text = mRead!Qty
                    End While
                    mRead.Close()

                    DataGridView2.Rows.Clear()
                    mRead = Conn.GetDataReader("select ppid,Cartonid,Userid,Intime from m_CartonsnScrap_t where Cartonid='" & TxtCartonID.Text.Trim() & "'")
                    If mRead.HasRows Then
                        While mRead.Read
                            DataGridView2.Rows.Add(mRead!Cartonid, mRead!Ppid, mRead!Userid, mRead!Intime)
                        End While
                    End If
                    mRead.Close()
                    lbNowPack.Text = DataGridView2.Rows.Count
                    TxtSbarcode.Text = ""
                    TxtSbarcode.Focus()
                    Label26.Text = "外箱条码序号扫描成功，请扫描产品条码进行装箱..."
                Else
                    Dim sCartonID As String = ""
                    Dim sMOid As String = ""
                    Dim sLineid As String = ""
                    Dim qty As Integer
                    ' Dim dRead As SqlDataReader
                    mRead.Close()
                    mRead = Conn.GetDataReader("select SBarcode,Moid,Lineid,Qty from m_Snsbarcode_t  where SBarcode='" & TxtCartonID.Text & "'")
                    If mRead.HasRows Then  '判断m_Snsbarcode_t中书否存在扫入的外箱条码
                        While mRead.Read
                            sCartonID = mRead!SBarcode
                            sMOid = mRead!Moid
                            sLineid = mRead!Lineid
                            qty = mRead!Qty
                        End While
                        mRead.Close()
                        Try

                            Conn.ExecSql("insert into m_CartonScrap_t(Cartonid,Moid,Cartonqty,CartonStatus,Teamid,Userid,Intime,Packlink)" & _
                                         "values ('" & sCartonID & "','" & sMOid & "','0','N','" & sLineid & "','" & SysMessageClass.UseId & "',getdate(),'P' )")

                        Catch ex As Exception

                        End Try
                        lbBefore.Text = "0"
                        lbNowPack.Text = DataGridView2.Rows.Count
                        lbTotal.Text = qty
                        TxtMO.Text = sMOid
                        TxtSbarcode.Text = ""
                        TxtSbarcode.Focus()
                        Label26.Text = "外箱条码序号录入成功，请扫描产品条码进行装箱..."
                    Else
                        mRead.Close()
                        Label26.Text = "系统中，不存在该外箱序号,请确认..."
                        Exit Sub
                    End If
                End If
            End If
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
            mRead = Conn.GetDataReader("select ppid,Cartonid from m_CartonsnScrap_t where ppid='" & TxtSbarcode.Text & "'")
            If mRead.HasRows Then
                Dim mcartonid As String = ""
                While mRead.Read
                    mcartonid = mRead!Cartonid
                End While
                mRead.Close()
                Dim FrmError As New FrmScanErrPrompt(TxtSbarcode.Text, "该产品条码已经包装在外箱" & mcartonid & "中，已装、混装或重码...")
                FrmError.ShowDialog()
                TxtSbarcode.Text = ""
                TxtSbarcode.Focus()
                Label26.Text = "该产品条码已经包装在外箱" & mcartonid & "中，已装、混装或重码..."
                Exit Sub
            End If
            mRead.Close()

            mRead = Conn.GetDataReader("select SBarcode,Moid,Lineid,Qty from m_Snsbarcode_t  where SBarcode='" & TxtSbarcode.Text.Trim() & "'")
            If mRead.HasRows Then
                If (CInt(lbNowPack.Text) + CInt(lbBefore.Text)) < CInt(lbTotal.Text) Then
                    mRead.Close()
                    Conn.PubConnection.Close()
                    Try
                        Conn.ExecSql("insert into m_CartonsnScrap_t (ppid,Cartonid,Userid,Intime) values ('" & TxtSbarcode.Text.Trim() & "','" & TxtSbarcode.Text.Trim() & "','" & SysMessageClass.UseId & "',getdate()) ")

                        DataGridView2.Rows.Insert(0, TxtCartonID.Text, TxtSbarcode.Text, SysMessageClass.UseId, Now.ToLongDateString)
                        DataGridView2.AutoResizeColumns()
                        lbNowPack.Text = DataGridView2.Rows.Count
                        If (CInt(lbNowPack.Text) + CInt(lbBefore.Text)) = CInt(lbTotal.Text) Then
                            mRead.Close()
                            Conn.PubConnection.Close()
                            Try
                                Conn.ExecSql("update m_CartonScrap_t set CartonStatus='Y' where Cartonid='" & TxtCartonID.Text.Trim() & "'")

                            Catch ex As Exception

                            End Try
                            Conn.PubConnection.Close()
                            Try
                                Conn.ExecSql("update m_CartonScrap_t set Cartonqty=Cartonqty+1 where Cartonid='" & TxtCartonID.Text.Trim() & "'")
                            Catch ex As Exception

                            End Try
                            lbNowPack.Text = "0"
                            lbTotal.Text = "0"
                            lbBefore.Text = "0"
                            Label26.Text = "该箱产品已经装满，扫描下一外箱条码序号..."
                            DataGridView2.Rows.Clear()
                            Me.TxtSbarcode.Clear()
                            TxtCartonID.Clear()
                            TxtMO.Clear()
                            TxtCartonID.Focus()
                        Else
                            mRead.Close()
                            Conn.PubConnection.Close()
                            Try
                                Conn.ExecSql("update m_CartonScrap_t set Cartonqty=Cartonqty+1 where Cartonid='" & TxtCartonID.Text.Trim() & "'")
                            Catch ex As Exception

                            End Try
                            lbNowPack.Text = DataGridView2.Rows.Count
                            Label26.Text = "该产品序号已经包装完成，扫描下一产品条码序号..."
                            Me.TxtSbarcode.Text = ""
                            TxtSbarcode.Focus()
                        End If
                    Catch ex As Exception
                    End Try
                Else
                    lbNowPack.Text = "0"
                    lbTotal.Text = "0"
                    lbBefore.Text = "0"
                    Label26.Text = "该箱产品已经装满，当前扫描的产品" + TxtSbarcode.Text + "没有装箱成功，请扫描其他外箱条码序号再进行包装，..."
                    DataGridView2.Rows.Clear()
                    Me.TxtSbarcode.Clear()
                    TxtMO.Clear()
                    TxtCartonID.Clear()
                    TxtCartonID.Focus()
                End If
            Else
                mRead.Close()
                'Conn.PubConnection.Close()
                TxtSbarcode.Clear()
                TxtSbarcode.Focus()
                Label26.Text = "产品条码序号在系统中不存在，请重新扫描..."
                Exit Sub
            End If

        End If


    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.TxtCartonID.Enabled = True
        TxtCartonID.Clear()
        TxtCartonID.Focus()
        TxtSbarcode.Text = ""
        TxtMO.Clear()
        'TxtSbarcode.Enabled = False
        lbNowPack.Text = "0"
        lbTotal.Text = "0"
        lbBefore.Text = "0"
        DataGridView2.Rows.Clear()
    End Sub

    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
End Class