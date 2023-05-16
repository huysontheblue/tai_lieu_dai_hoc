Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Text
Imports System.IO

Public Class FrmScanAberrantHandle

    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim E75str As String = ""
    Dim InitialTestTab As String = "N"

    Private Function IsBarcodeExists(ByVal barcode As String, ByVal AllSn As String) As Boolean
        Dim dt As DataTable = DbOperateUtils.GetDataTable("select CableSN,LineMsg from  M_LineReadSn_t where CableSN='" & barcode & "'")
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)!LineMsg <> AllSn Then
                MessageUtils.ShowError("E75内容不符，请检查是否条码打印重复")
                Return True
            End If
            Return True
        End If
        Return False
    End Function


    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click

        Me.Close()

    End Sub


    Private Sub DoJxRemove()
        If String.IsNullOrEmpty(replaceppidold.Text.Trim) Then
            MessageBox.Show("请输入不良品条码")
            Exit Sub
        End If
        Dim Cartonid As String = ""
        Dim PalletId As String = ""
        Dim Packstate As String = ""
        Dim sql As String = "SELECT A.CARTONID,A.CARTONSTATUS,D.PALLETID,E.PACKID FROM M_CARTON_T A JOIN M_CARTONSN_T B ON A.CARTONID=B.CARTONID" & vbNewLine
        sql += "LEFT JOIN m_SnSBarCode_t E ON B.PPID=E.SBARCODE" & vbNewLine
        sql += "LEFT JOIN M_PALLETCARTON_T C ON A.CARTONID=C.CARTONID " & vbNewLine
        sql += "LEFT JOIN M_PALLETM_T D ON C.PALLETID=D.PALLETID" & vbNewLine
        sql += "WHERE B.PPID='" & replaceppidold.Text.Trim & "'"
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Cartonid = dt.Rows(0)("CARTONID").ToString
                PalletId = dt.Rows(0)("PALLETID").ToString
                Packstate = dt.Rows(0)("CARTONSTATUS").ToString
            Else
                MessageBox.Show("该产品还未进行包装或为非流水码包装产品,不允许移除...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End Using
        If Packstate <> "Y" Then
            MessageBox.Show("该产品对应的外箱，尚未包装完成，不允许移除...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim Msqlstr As String
        Msqlstr = " delete from m_Cartonsn_t where ppid='" & replaceppidold.Text & "'"
        Msqlstr = Msqlstr & vbNewLine & " update m_Carton_t set Cartonqty=Cartonqty-1,CARTONSTATUS='N' where Cartonid='" & Cartonid & "'"
        Msqlstr = Msqlstr & vbNewLine & " update m_palletm_t set palletqty=palletqty-1,PALLETSTATUS='N' where PALLETID='" & PalletId & "'"
        Msqlstr = Msqlstr & vbNewLine & " delete from M_PPIDLINK_T where EXppid='" & replaceppidold.Text & "'"
        Msqlstr = Msqlstr & vbNewLine & " delete from M_ASSYSND_T where ppid='" & replaceppidold.Text & "'"
        Msqlstr = Msqlstr & vbNewLine & " delete from M_ASSYSN_T where ppid='" & replaceppidold.Text & "'"
        Msqlstr = Msqlstr & vbNewLine & " UPDATE M_SNSBARCODE_T SET USEY='E' where SBARCODE='" & replaceppidold.Text & "'"
        Msqlstr = Msqlstr & vbNewLine & "insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,Moid,Userid,Intime)values('" & replaceppidold.Text & "','" & Cartonid & "',N'產品移除','" & SysMessageClass.UseId & "',getdate()" & ")"
        Try
            DbOperateUtils.ExecSQL(Msqlstr)
            MessageBox.Show("移除成功，请重新做扫描设定后包装")
        Catch ex As Exception
            MessageBox.Show("移除失败,请通知管理员")
        End Try
    End Sub

    Dim factory As String = "LX53,WANXUN"
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
        '    DoJxRemove()
        '    Exit Sub
        'End If
        Dim Cartonid As String = ""
        Dim PalletId As String = ""
        Dim Packstate As String = ""
        Dim mRead As SqlDataReader
        mRead = Conn.GetDataReader(" select a.cartonid,b.CartonStatus from m_Cartonsn_t a join m_Carton_t b on a.cartonid=b.cartonid where a.ppid='" & replaceppidold.Text & "' ")
        If mRead.HasRows Then
            While mRead.Read
                Cartonid = mRead!cartonid
                Packstate = mRead!CartonStatus
            End While
        Else
            mRead.Close()
            Conn.PubConnection.Close()
            MessageBox.Show("该产品还未进行包装...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        mRead.Close()
        Conn.PubConnection.Close()
        If Packstate = "Y" Then
            mRead.Close()
            Conn.PubConnection.Close()
            MessageBox.Show("该产品对应的外箱，已经包装完成，不允许移除...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim Msqlstr As String
        Msqlstr = " delete from m_Cartonsn_t where ppid='" & replaceppidold.Text & "'"
        Msqlstr = Msqlstr & vbNewLine & " update m_Carton_t set Cartonqty=Cartonqty-1 where Cartonid='" & Cartonid & "'"
        Msqlstr = Msqlstr & vbNewLine & "insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,Moid,Userid,Intime)values('" & replaceppidold.Text & "','" & Cartonid & "',N'產品移除','" & SysMessageClass.UseId & "',getdate()" & ")"
        Try
            Conn.ExecSql(Msqlstr)
            Conn.PubConnection.Close()
            MessageBox.Show("该产品已移除成功，请检查外箱的实际装箱数量...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("该产品移除时，发生错误...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub DoJxReplace()
        If Me.replaceppidold.Text = "" Or replaceppidnew.Text = "" Then
            MessageBox.Show("不良品序号或替换产品序号不能为空...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim Cartonid As String = Nothing
        Dim PalletId As String = Nothing
        Dim Packstate As String = Nothing
        Dim PARTID As String = Nothing
        Dim sql As String = "SELECT A.CARTONID,A.CARTONSTATUS,C.PARTID FROM M_CARTON_T A JOIN M_CARTONSN_T B ON A.CARTONID=B.CARTONID" & vbNewLine
        sql += "LEFT JOIN m_SnSBarCode_t E  ON B.PPID=E.SBARCODE JOIN M_MAINMO_T C ON E.MOID=C.MOID " & vbNewLine
        sql += "WHERE B.PPID='{0}' "
        Using dt As DataTable = DbOperateUtils.GetDataTable(String.Format(sql, replaceppidold.Text.Trim))
            If dt.Rows.Count > 0 Then
                Cartonid = dt.Rows(0)("CARTONID").ToString
                Packstate = dt.Rows(0)("CARTONSTATUS").ToString
                PARTID = dt.Rows(0)("PARTID").ToString
            Else
                MessageBox.Show("不良品产品还未进行包装或为非流水码包装产品,不允许替换...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End Using
        If Packstate <> "Y" Then
            MessageBox.Show("该产品对应的外箱，尚未包装完成，不允许替换...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim packId As String = Nothing
        Dim usey As String = Nothing
        Dim cartonids As String = Nothing
        Dim partidS As String = Nothing
        Dim sql1 As String = "SELECT * FROM M_CARTONSN_T   WHERE PPID='" & replaceppidnew.Text.Trim & "'"
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql1)
            If dt.Rows.Count > 0 Then
                MessageBox.Show("良品条码已经做了包装，不允许替换")
                Exit Sub
            End If
        End Using
        If replaceppidnew.Text.Trim.Length <> replaceppidold.Text.Trim.Length Then
            MessageBox.Show("新旧条码样式不一致,请确认")
            Exit Sub
        End If
        sql1 = "SELECT A.USEY,B.PARTID FROM M_SNSBARCODE_T A JOIN M_MAINMO_T B ON A.MOID=B.MOID WHERE A.SBARCODE='" & replaceppidnew.Text.Trim & "'"
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql1)
            If dt.Rows.Count > 0 Then
                partidS = dt.Rows(0)("PARTID").ToString
                usey = dt.Rows(0)("USEY").ToString
                If PARTID <> partidS Then
                    MessageBox.Show("良品料号和不良品料号不一致,请确认")
                    Exit Sub
                End If
                If usey <> "Y" Then
                    MessageBox.Show("良品条码已扫描或在维修中,请确认")
                    Exit Sub
                End If
            End If
        End Using
        Dim Msqlstr As String
        Msqlstr = " update  m_Cartonsn_t set ppid='" & replaceppidnew.Text.Trim & "' where ppid='" & replaceppidold.Text.Trim & "'"
        Msqlstr = Msqlstr & vbNewLine & " UPDATE  M_SNSBARCODE_T SET USEY='S'  where SBARCODE='" & replaceppidnew.Text.Trim & "'"
        Msqlstr = Msqlstr & vbNewLine & " UPDATE  M_PPIDLINK_T SET EXPPID='" & replaceppidnew.Text.Trim & "',PPID='" & replaceppidnew.Text.Trim & "' where EXppid='" & replaceppidold.Text.Trim & "'"
        Msqlstr = Msqlstr & vbNewLine & " UPDATE  M_ASSYSND_T SET PPID='" & replaceppidnew.Text.Trim & "' where ppid='" & replaceppidold.Text.Trim & "'"
        Msqlstr = Msqlstr & vbNewLine & " UPDATE  M_ASSYSN_T SET PPID='" & replaceppidnew.Text.Trim & "' where ppid='" & replaceppidold.Text.Trim & "'"
        Msqlstr = Msqlstr & vbNewLine & "insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,Moid,Userid,Intime)values('" & replaceppidold.Text.Trim & "','" & replaceppidnew.Text.Trim & "',N'產品替换','" & SysMessageClass.UseId & "',getdate()" & ")"
        Try
            DbOperateUtils.ExecSQL(Msqlstr)
            MessageBox.Show("替换成功")
        Catch ex As Exception
            MessageBox.Show("替换失败,请通知管理员")
        End Try
    End Sub

    Private Sub btnMainBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainBarcode.Click
        'If factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
        '    DoJxReplace()
        '    Exit Sub
        'End If

        Dim mRead As SqlDataReader
        Dim mReadbcp As DataTable
        Dim Cartonid As String = ""
        Dim Packstate As String = ""
        Dim OldMoid As String = ""
        Dim NewMoid As String = ""
        Dim OldPartid As String = ""
        Dim NewPartid As String = ""
        If String.IsNullOrEmpty(Me.rtxtRemark.Text.Trim) Then
            MessageUtils.ShowInformation("请填写替换说明!")
            Exit Sub
        End If

        If Me.replaceppidold.Text = "" Or replaceppidnew.Text = "" Then
            MessageUtils.ShowInformation("不良品序号或替换产品序号不能为空...")
            Exit Sub
        End If

        '判断新旧条码长度是否一致 关晓艳 2018/08/14
        If Len(Me.replaceppidold.Text.Trim) <> Len(Me.replaceppidnew.Text.Trim) Then
            MessageUtils.ShowInformation("替换新旧条码长度不一致")
            Exit Sub
        End If


        mRead = Conn.GetDataReader(" select a.cartonid,b.CartonStatus,b.Moid from m_Cartonsn_t a join m_Carton_t b on a.cartonid=b.cartonid where a.ppid='" & replaceppidold.Text & "' ")
        'mReadbcp = Conn.GetDataReader(" select*FROM m_CartonsnBan_t where ppid='" & replaceppidold.Text & "' ")

        If mRead.HasRows Then
            While mRead.Read
                Cartonid = mRead!cartonid
                Packstate = mRead!CartonStatus
                OldMoid = mRead!Moid
            End While
        Else
            mRead.Close()
            Conn.PubConnection.Close()
            mReadbcp = DbOperateUtils.GetDataTable(" select*FROM m_CartonsnBan_t where ppid='" & replaceppidold.Text & "' ")
            If mReadbcp.Rows.Count > 0 Then
                Conn.ExecSql(" UPDATE m_CartonsnBan_t SET  ppid='" & replaceppidnew.Text & "' WHERE  ppid='" & replaceppidold.Text & "'")
                MessageUtils.ShowInformation("半成品替换成功")
                Return

            End If
            mRead.Close()
            Conn.PubConnection.Close()
            MessageUtils.ShowInformation("该产品还未进行包装...")
            Exit Sub
        End If
        mRead.Close()
        Conn.PubConnection.Close()
        If Packstate = "N" Then
            mRead.Close()
            Conn.PubConnection.Close()
            MessageUtils.ShowInformation("该产品对应的外箱，未包装完成，不允许替换...")
            Exit Sub
        End If
        mRead = Conn.GetDataReader(" select cartonid from m_Cartonsn_t  where ppid='" & replaceppidnew.Text & "' ")
        If mRead.HasRows Then

            mRead.Close()
            Conn.PubConnection.Close()
            MessageUtils.ShowInformation("替换的新产品，已装箱，不允许替换...")
            Exit Sub

        End If
        mRead.Close()
        Conn.PubConnection.Close()
        mRead = Conn.GetDataReader(" select partid from m_mainmo_t  where moid='" & OldMoid & "' ")
        If mRead.HasRows Then
            While mRead.Read
                'mRead.Close()
                OldPartid = mRead!partid
                'Exit Sub
            End While
        End If
        mRead.Close()
        Conn.PubConnection.Close()
        If CheckSysBarcode(replaceppidold.Text) And Not SystemPrtChk.Checked Then
            MessageUtils.ShowInformation("旧条码是系统打印条码，需要勾选系统打印条码...")
            Exit Sub
        End If
        If SystemPrtChk.Checked Then '系统打印条码，检查工单号
            mRead = Conn.GetDataReader(" select b.PartID from m_SnSBarCode_t a join m_Mainmo_t b on a.Moid=b.Moid   where a.sbarcode='" & replaceppidnew.Text & "' and a.usey='Y' ")
            If mRead.HasRows Then
                While mRead.Read
                    'mRead.Close()
                    NewPartid = mRead!partid
                    'Exit Sub
                End While
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            'update by hgd 20180224 有些重工的产品，标签是供应商提供，工单不一样，所以要提供替换支持
            'If OldPartid <> NewPartid Then
            '    MessageBox.Show("替换的新产品与旧产品，必须为相同料号工单产品，否则不允许替换...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If
        Else


            If replaceppidnew.Text.Trim.Length <> replaceppidold.Text.Trim.Length Then
                MessageUtils.ShowInformation("非系统打印替换新旧条码长度不一致，不允许进行替换...")
                Exit Sub
            End If
            '非系统条码校验样式是否一致 add by hgd 2018-01-18
            If CheckStyleIsSame(replaceppidold.Text.Trim, replaceppidnew.Text.Trim) = False Then
                Dim ErrMsg As String = "新条码和旧条码的样式不一致，请确认是否为同一料号..."
                Dim frmErrPrompt As FrmAberrantErrPrompt = New FrmAberrantErrPrompt(replaceppidold.Text, ErrMsg, "条码替换异常确认")
                If frmErrPrompt.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    If frmErrPrompt.IsContinueExec = False Then
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If


        Dim Msqlstr As String
        '替换的同时更新EAN add by 2018-01-20
        Msqlstr = " update m_PackingCheckBarcode_t set AffiliatedBarCode=( select d.AffiliatedBarCode from m_cartonsn_t  a inner join "
        Msqlstr = Msqlstr & vbNewLine & " m_carton_t b on b.Cartonid=a.Cartonid left join m_mainmo_t c on c.Moid=b.Moid left join "
        Msqlstr = Msqlstr & vbNewLine & " m_PackingCheckSetting_t d on d.PartId=c.PartID 	where a.ppid='" & replaceppidold.Text & "' and m_PackingCheckBarcode_t.BarCode=a.ppid) "
        Msqlstr = Msqlstr & vbNewLine & " where BarCode='" & replaceppidold.Text & "'"
        Msqlstr = Msqlstr & vbNewLine & " update m_Cartonsn_t set ppid='" & replaceppidnew.Text & "' where ppid='" & replaceppidold.Text & "'"
        Msqlstr = Msqlstr & vbNewLine & " update m_snsbarcode_t set Usey='S' where SBarCode='" & replaceppidnew.Text & "'"
        Msqlstr = Msqlstr & vbNewLine & " update m_snsbarcode_t set Usey='N' where SBarCode='" & replaceppidold.Text & "'"

        '条码主条码替换的时候，只更新包装站的资料（因为新条码在其他工站有记录，防止主键冲突),cq20200215
        Msqlstr = Msqlstr & vbNewLine & " update m_AssysnD_t set ppid='" & replaceppidnew.Text & "' WHERE ppid='" & replaceppidold.Text & "' AND Stationid LIKE 'P%' "

        '由于这个表 是PPID为主键，因此只能先删除，后更新防止主键冲突
        Msqlstr = Msqlstr & vbNewLine & "  DELETE FROM m_Assysn_t WHERE ppid ='" & replaceppidnew.Text.Trim & "' "
        Msqlstr = Msqlstr & vbNewLine & " update m_Assysn_t set ppid='" & replaceppidnew.Text & "' where ppid='" & replaceppidold.Text & "' AND Stationid LIKE 'P%'"

        Msqlstr = Msqlstr & vbNewLine & " update m_ppidlink_t set exppid='" & replaceppidnew.Text & "' where exppid='" & replaceppidold.Text & "' AND Stationid LIKE 'P%'"
        Msqlstr = Msqlstr & vbNewLine & " update m_ppidlink_t set ppid='" & replaceppidnew.Text & "' where ppid='" & replaceppidold.Text & "' AND Stationid LIKE 'P%' "

        Msqlstr = Msqlstr & vbNewLine & " update m_PackingCheckBarcode_t set BarCode='" & replaceppidnew.Text & "' where BarCode='" & replaceppidold.Text & "' " 'add by hgd 20170115 更新包装附属检测
        Msqlstr = Msqlstr & vbNewLine & " update ReportDB.dbo.m_AssysnDReport_t set ppid='" & replaceppidnew.Text & "' where moid='" & OldMoid & "' and ppid='" & replaceppidold.Text & "'"
        Msqlstr = Msqlstr & vbNewLine & " UPDATE m_CartonsnBan_t SET  ppid='" & replaceppidnew.Text & "' WHERE  ppid='" & replaceppidold.Text & "'"
        Msqlstr = Msqlstr & vbNewLine & " insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,moid,Userid,Intime,Remark)values('" & replaceppidold.Text & "','" & replaceppidnew.Text & "',N'產品替換','" & SysMessageClass.UseId & "',getdate(),N'" & Me.rtxtRemark.Text.Trim & "'" & ")"
        Try
            DbOperateUtils.ExecSQL(Msqlstr)
            replaceppidold.Clear()
            replaceppidnew.Clear()
            MessageUtils.ShowInformation("该产品已被新产品替换成功，请将新产品放入旧产品对应的外箱内...")
        Catch ex As Exception
            MessageUtils.ShowInformation("该产品替换时，发生错误...")
        End Try
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Me.TxtCartonID.Enabled = True
        TxtCartonID.Clear()
        TxtCartonID.Focus()
        txtSbarcode.Text = ""
        txtSbarcode.Enabled = False
        labPpidQty.Text = "0"
        labQty.Text = "0"
        labInstallQty.Text = "0"
        DataGridView2.Rows.Clear()

    End Sub

    Private Sub TxtSbarcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSbarcode.KeyPress

        If e.KeyChar = Chr(13) Then
            If Me.TxtCartonID.Text = "" Then
                TxtCartonID.Clear()
                TxtCartonID.Focus()
                Label26.Text = "外箱条码序号不能为空，请先扫描外箱条码序号..."
                Exit Sub
            End If
            If Me.txtSbarcode.Text = "" Then
                txtSbarcode.Clear()
                txtSbarcode.Focus()
                Label26.Text = "产品条码序号不能为空，请先扫描产品条码序号..."
                Exit Sub
            End If

            If E75str <> txtSbarcode.Text Then
                Dim FrmError As New FrmScanErrPrompt(txtSbarcode.Text, "E75序号和产品条码不一致，产品装混...")
                FrmError.ShowDialog()
                txtSbarcode.Text = ""
                txtSbarcode.Focus()
                Label26.Text = "系统中已经存在该条码、请确认是否为重码..."
                Exit Sub
            End If
            txtSbarcode.Text = Replace(txtSbarcode.Text, "'", "")
            Dim mRead As SqlDataReader
            mRead = Conn.GetDataReader("select ppid from [m_CartonCheckRecord_t] where ppid='" & txtSbarcode.Text & "'")
            If mRead.HasRows Then
                mRead.Close()
                Dim FrmError As New FrmScanErrPrompt(txtSbarcode.Text, "系统中已经存在该条码、请确认是否为重码...")
                FrmError.ShowDialog()
                txtSbarcode.Text = ""
                txtSbarcode.Focus()
                Label26.Text = "系统中已经存在该条码、请确认是否为重码..."
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            mRead = Conn.GetDataReader("select cartonid from m_Cartonsn_t where ppid='" & txtSbarcode.Text & "' and cartonid<>'" & TxtCartonID.Text & "'")
            If mRead.HasRows Then
                Dim mcartonid As String = ""
                While mRead.Read
                    mcartonid = mRead!cartonid
                End While
                mRead.Close()
                Conn.PubConnection.Close()
                Dim FrmError As New FrmScanErrPrompt(txtSbarcode.Text, "该产品条码已经包装在外箱" & mcartonid & "中，混装或重码...")
                FrmError.ShowDialog()
                txtSbarcode.Text = ""
                txtSbarcode.Focus()
                Label26.Text = "该产品条码已经包装在外箱" & mcartonid & "中，混装或重码..."
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            mRead = Conn.GetDataReader("select b.Cartonqty from m_Cartonsn_t a join m_Carton_t b on a.Cartonid=b.Cartonid where ppid='" & txtSbarcode.Text & "' and a.cartonid='" & TxtCartonID.Text & "'")
            If mRead.HasRows Then
                While mRead.Read
                    Me.labInstallQty.Text = mRead!Cartonqty
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
                Dim FrmError As New FrmScanErrPrompt(txtSbarcode.Text, "该外箱不存在该产品，或该产品还未包装或系统中不存在...")
                FrmError.ShowDialog()
                txtSbarcode.Text = ""
                txtSbarcode.Focus()
                Label26.Text = "该外箱不存在该产品，或该产品还未进行包装..."
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            Try
                Conn.ExecSql(" insert into m_CartonCheckRecord_t(Cartonid,Ppid,State,Userid,Intime)values('" & TxtCartonID.Text & "','" & txtSbarcode.Text & "','Y','" & SysMessageClass.UseId & "',getdate()" & ")")
                'mRead = Conn.GetDataReader("select count(*) qty from m_Carton_t where cartonid='" & TxtCartonID.Text & "'")
                'Dim CartonQty As Integer = 0
                'If mRead.HasRows Then
                '    While mRead.Read
                '        CartonQty = CInt(mRead!qty)
                '    End While
                'End If
                'mRead.Close()
                DataGridView2.Rows.Insert(0, TxtCartonID.Text, txtSbarcode.Text, SysMessageClass.UseId, Now.ToLongDateString)
                DataGridView2.AutoResizeColumns()
                If CInt(labPpidQty.Text) = CInt(labQty.Text) Then
                    labPpidQty.Text = "0"
                    labQty.Text = "0"
                    Label26.Text = "该箱产品序号校验通过，扫描下一外箱条码序号..."
                    DataGridView2.Rows.Clear()
                    Me.txtSbarcode.Clear()
                    Me.txtChipId.Clear()
                    txtSbarcode.Enabled = False
                    TxtCartonID.Clear()
                    TxtCartonID.Enabled = True
                    TxtCartonID.Focus()
                Else
                    labPpidQty.Text = DataGridView2.Rows.Count
                    Label26.Text = "该产品序号校验通过，扫描下一产品条码序号..."
                    Me.txtSbarcode.Text = ""
                    txtSbarcode.Enabled = False
                    Me.txtChipId.Clear()
                    Me.txtChipId.Enabled = True
                    Me.txtChipId.Focus()
                End If

            Catch ex As Exception

            End Try

        End If

    End Sub

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
                    labInstallQty.Text = mRead!Cartonqty
                    Cartonqty = mRead!Qty
                End While

                mRead.Close()
                Conn.PubConnection.Close()
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
            txtChipId.Text = ""
            txtChipId.Enabled = True
            txtChipId.Focus()
            'TxtSbarcode.Text = ""
            'TxtSbarcode.Enabled = True
            'TxtSbarcode.Focus()
            labQty.Text = Cartonqty
            Label26.Text = "外箱条码序号录入成功，请进行E75及产品重码检测..."

            mRead = Conn.GetDataReader("select Cartonid,Ppid,State,Userid,Intime from m_CartonCheckRecord_t where Cartonid='" & TxtCartonID.Text & "'")
            If mRead.HasRows Then
                While mRead.Read
                    DataGridView2.Rows.Add(mRead!Cartonid, mRead!Ppid, mRead!Userid, mRead!Intime)
                End While
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            labPpidQty.Text = DataGridView2.Rows.Count
            'Else
            '    Label26.Text = "外箱条码序号还未包装完成，不能进行重码检测..."
            'End If
        End If

    End Sub


    '关箱操作
    Private Sub ButColseCarton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButColseCarton.Click

        If txtCarton.Text.Trim = "" Then
            MessageUtils.ShowInformation("请输入或扫描要关箱的外箱条码序号...")
            Exit Sub
        End If
        If ChkIsN.Checked = True Then
            Dim Pqty As String = ""
            Dim Status As String = ""
            Dim Cqty As String = ""
            Dim mRead As SqlDataReader
            mRead = Conn.GetDataReader("select Qty from m_snsbarcode_t where sbarcode='" & txtCarton.Text.Trim & "' ")
            If mRead.HasRows Then
                While mRead.Read
                    Pqty = mRead!Qty.ToString
                End While
            Else
                mRead.Close()
                Conn.PubConnection.Close()
                MessageUtils.ShowInformation("该外箱序号,在打印记录表中不存在...")
                txtCarton.Clear()
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            mRead = Conn.GetDataReader("select CartonStatus,Cartonqty from m_Carton_t where Cartonid='" & txtCarton.Text.Trim & "' ")
            If mRead.HasRows Then
                While mRead.Read
                    Status = mRead!CartonStatus.ToString
                    Cqty = mRead!Cartonqty.ToString
                End While
            Else
                mRead.Close()
                Conn.PubConnection.Close()
                MessageUtils.ShowInformation("该外箱序号,还未进行包装扫描...")
                txtCarton.Clear()
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            If Status.ToUpper = "Y" Then
                MessageUtils.ShowInformation("该外箱序号，已经包装完成，不能进行关箱作业...")
                txtCarton.Clear()
                Exit Sub
            End If
            'If Cqty = Pqty Then
            '    MessageBox.Show("该外箱序号，实物已包装完成，不能进行关箱作业...")
            '    TxtCarton4.Clear()
            '    Exit Sub
            'End If
            '把装箱数量改为实际装箱数量
            DbOperateUtils.ExecSQL("update m_Carton_t set CartonStatus='Y',PackingQuantity = Cartonqty,Updatetime=getdate(),MARK2=N'强制关箱'  where Cartonid='" & txtCarton.Text.Trim & "'")
            MessageUtils.ShowInformation("该外箱序号关箱成功，请重新进行扫描设置，进行包装扫描...")
            txtCarton.Clear()
            Exit Sub
        Else
            MessageUtils.ShowInformation("目前只针对实物装满箱，但状态为N的外箱条码序号作关箱处理...")
            txtCarton.Clear()
            Exit Sub
        End If

    End Sub


    Private Sub btnOkMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOkMore.Click

        If TxtOutPack.Text.Trim = "" Or TxtOutPPID.Text.Trim = "" Then
            MessageUtils.ShowError("请输入多装的外箱条码及产品序号...")
            Exit Sub
        End If
        Dim Carton As Integer
        Dim FactCqrton As Integer
        Dim PackQTy As Integer
        Dim maread As SqlDataReader
        maread = Conn.GetDataReader("select Qty from m_SnSBarCode_t where sbarcode='" & TxtOutPack.Text & "'")
        If maread.HasRows Then
            While maread.Read()
                Carton = maread!Qty
            End While
        Else
            maread.Close()
            Conn.PubConnection.Close()
            MessageUtils.ShowError("该产品外箱序号不存在...")
            TxtOutPack.Clear()
            TxtOutPack.Focus()
            Exit Sub
        End If
        maread.Close()
        Conn.PubConnection.Close()
        maread = Conn.GetDataReader("select count(*) Pqty from m_Cartonsn_t where Cartonid='" & TxtOutPack.Text & "'")
        If maread.HasRows Then
            While maread.Read()
                FactCqrton = maread!Pqty
            End While
        Else
            maread.Close()
            Conn.PubConnection.Close()
            MessageUtils.ShowError("该产品外箱序号未进行包装扫描...")
            TxtOutPack.Clear()
            TxtOutPack.Focus()
            Exit Sub
        End If
        maread.Close()
        Conn.PubConnection.Close()

        maread = Conn.GetDataReader("select Cartonqty from m_Carton_t where Cartonid='" & TxtOutPack.Text & "'")
        If maread.HasRows Then
            While maread.Read()
                PackQTy = maread!Cartonqty
            End While
        Else
            maread.Close()
            Conn.PubConnection.Close()
            MessageUtils.ShowError("该产品外箱序号未进行包装扫描...")
            TxtOutPack.Clear()
            TxtOutPack.Focus()
            Exit Sub
        End If
        maread.Close()
        Conn.PubConnection.Close()
        If FactCqrton <> PackQTy Then
            MessageUtils.ShowError("该产品外箱包装主表的包装数据，与明细包装数据不符...")
            TxtOutPack.Clear()
            TxtOutPack.Focus()
            Exit Sub
        End If
        If PackQTy > Carton = False Then
            MessageUtils.ShowError("该产品外箱实装数量并未大于应装数量...")
            TxtOutPack.Clear()
            TxtOutPack.Focus()
            Exit Sub
        End If

        maread = Conn.GetDataReader("select ppid from m_Cartonsn_t where Cartonid='" & TxtOutPack.Text & "' and ppid='" & TxtOutPPID.Text & "'")
        If maread.HasRows = False Then
            maread.Close()
            Conn.PubConnection.Close()
            MessageUtils.ShowError("该产品条码与外箱条码不匹配...")
            TxtOutPPID.Clear()
            TxtOutPPID.Focus()
            Exit Sub
        End If
        maread.Close()
        Conn.PubConnection.Close()
        Dim sqlStr As String
        sqlStr = "delete from  m_Cartonsn_t  where ppid='" & TxtOutPPID.Text & "' and Cartonid='" & TxtOutPack.Text & " '"
        sqlStr = sqlStr & vbNewLine & " update m_Carton_t set Cartonqty=Cartonqty-1 where Cartonid='" & TxtOutPack.Text & "'"
        sqlStr = sqlStr & vbNewLine & " delete from m_AssysnD_t where ppid='" & TxtOutPPID.Text & "'"
        sqlStr = sqlStr & vbNewLine & " delete from m_Assysn_t where ppid='" & TxtOutPPID.Text & "' "
        sqlStr = sqlStr & vbNewLine & " delete from m_ppidlink_t where exppid='" & TxtOutPPID.Text & "'"
        Try
            'MessageBox.Show(sqlStr)
            DbOperateUtils.ExecSQL(sqlStr)
            MessageUtils.ShowInformation("移除多包装的产品成功，请将移出的产品，流回产线进行重包装，原包装箱已可正常使用")
        Catch ex As Exception
            MessageUtils.ShowInformation(ex.Message)
        End Try


    End Sub

    Private Sub btnOkLess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOkLess.Click

        If TxtLastPack.Text.Trim = "" Then
            MessageBox.Show("产品外箱序号不能为空...", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtLastPack.Clear()
            TxtLastPack.Focus()
            Exit Sub
        End If
        Dim maread As SqlDataReader
        Dim Carton As Integer = 0
        Dim PackQty As Integer = 0
        maread = Conn.GetDataReader("select count(*) Pqty from m_Cartonsn_t where Cartonid='" & TxtLastPack.Text & "'")
        If maread.HasRows Then
            While maread.Read()
                Carton = maread!Pqty
            End While
        Else
            maread.Close()
            Conn.PubConnection.Close()
            MessageBox.Show("该产品外箱序号不存在...", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtLastPack.Clear()
            TxtLastPack.Focus()
            Exit Sub
        End If
        maread.Close()
        Conn.PubConnection.Close()
        maread = Conn.GetDataReader("select Cartonqty from m_Carton_t where Cartonid='" & TxtLastPack.Text & "' and CartonStatus='Y'")
        If maread.HasRows Then
            While maread.Read()
                PackQty = maread!Cartonqty
            End While
        Else
            MessageBox.Show("该产品外箱序号不存在或未包装完成，不能进行处理...", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtLastPack.Clear()
            TxtLastPack.Focus()
            Exit Sub
        End If
        maread.Close()
        Conn.PubConnection.Close()
        Dim DiffQty As Integer = CInt(PackQty) - CInt(Carton)
        If DiffQty = 0 Then
            MessageBox.Show("该产品外箱序号未短装或多装，不能进行处理...", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtLastPack.Clear()
            TxtLastPack.Focus()
            Exit Sub
        End If
        Try
            'Dim Sqlstr As String = "update  m_Carton_t set Cartonqty='" & Carton & "',CartonStatus='N' where  Cartonid='" & TxtLastPack.Text & "'"
            'MessageBox.Show(Sqlstr)
            DbOperateUtils.ExecSQL("update  m_Carton_t set Cartonqty='" & Carton & "',CartonStatus='N' where  Cartonid='" & TxtLastPack.Text & "'")
            MessageBox.Show("外箱状态已恢复，请接着包装", "提示信息", MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK)
        End Try


    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If Txtmoid.Text.Trim = "" Then
    '        MessageBox.Show("工单编号不能为空...")
    '        Txtmoid.Clear()
    '        Txtmoid.Focus()
    '        Exit Sub
    '    End If
    '    If CobLine.SelectedIndex = -1 Then
    '        MessageBox.Show("线别编号不能为空...")
    '        CobLine.SelectedIndex = -1
    '        CobLine.Focus()
    '        Exit Sub
    '    End If
    '    Dim mSqlstr As String = "update m_mainmo_t set Lineid='" & CobLine.Text & "' where moid='" & Txtmoid.Text.Trim & "'"
    '    mSqlstr = mSqlstr & vbNewLine & "insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,moid,Userid,Intime)values('" & Txtmoid.Text.Trim & "','" & CobLine.Text & "',N'线别更改','" & SysMessageClass.UseId & "',getdate()" & ")"
    '    DbOperateUtils.ExecSQL(mSqlstr)
    '    MessageBox.Show("工单对应生线别编号更新成功...")

    'End Sub

    Private Sub FrmScanAberrantHandle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim mRead As SqlDataReader = Conn.GetDataReader("select lineid from deptline_t where usey='Y'")
        If mRead.HasRows Then
            While mRead.Read
                CobLine.Items.Add(mRead!lineid)
            End While
        End If
        mRead.Close()
        Conn.PubConnection.Close()
        If factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then

        End If
        ToolUsename.Text = VbCommClass.VbCommClass.UseName '.UseId
        Me.InitialTestTab = "N"
    End Sub

    Private Sub btnRepaireOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRepaireOk.Click

        Dim mRead As SqlDataReader = Conn.GetDataReader("select Oldbarcode from m_BarcodeExch_t where Oldbarcode='" & txtRepaire.Text & "'")
        If mRead.HasRows = False Then
            mRead.Close()
            MessageBox.Show("该条码未进行替换或移除作业，不允许进行当前操作...")
            Exit Sub
        End If
        mRead.Close()
        Dim Sqlser As New System.Text.StringBuilder
        Sqlser.Append(" delete from m_Assysn_t where ppid=='" & txtRepaire.Text & "'")
        Sqlser.Append(" delete from m_AssysnD_t where ppid=='" & txtRepaire.Text & "'")
        Sqlser.Append(" delete from m_ppidlink_t where exppid=='" & txtRepaire.Text & "'")
        Sqlser.Append(" delete from m_PpidCheckRecord_t where ppid=='" & txtRepaire.Text & "'")
        Try
            DbOperateUtils.ExecSQL(Sqlser.ToString)
            MessageBox.Show("更改成功，请重新做包装扫描...", "提示信息", MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show("更改时发生错误...", "提示信息", MessageBoxButtons.OK)
        End Try

    End Sub


    Private Sub btnContainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContainer.Click

        Dim Oldmoid As String = ""
        Dim Newmoid As String = ""
        Dim FactQty As Integer = 0
        Dim CartonQty As Integer = 0
        If String.IsNullOrEmpty(Me.rtxtRemark.Text.Trim) Then
            MessageUtils.ShowInformation("请填写替换说明!")
            Exit Sub
        End If

        '判断新旧条码长度是否一致 关晓艳 2018/08/14
        If Len(Me.txtOldCarton.Text.Trim) <> Len(Me.txtNewCarton.Text.Trim) Then
            MessageUtils.ShowInformation("替换新旧条码长度不一致!")
            Exit Sub
        End If


        Dim dt As DataTable = DbOperateUtils.GetDataTable("select moid,Cartonqty from m_carton_t where cartonid='" & txtOldCarton.Text & "'")
        If dt.Rows.Count = 0 Then
            txtOldCarton.Clear()
            txtOldCarton.Focus()
            MessageUtils.ShowInformation("该作废外箱还未进行包装扫描，不允许被替换...")
            Exit Sub
        Else
            Oldmoid = dt.Rows(0)!moid
            CartonQty = dt.Rows(0)!Cartonqty
        End If

        If SystemPrtCartonChk.Checked = True Then
            dt.Reset()
            dt = DbOperateUtils.GetDataTable("select moid,Qty from m_snsbarcode_t where sbarcode='" & txtNewCarton.Text & "' and usey='Y'")
            If dt.Rows.Count = 0 Then
                txtNewCarton.Clear()
                txtNewCarton.Focus()
                MessageUtils.ShowInformation("新外箱已经扫描过，不允许替换...")
                Exit Sub
            Else
                Newmoid = dt.Rows(0)!moid
                FactQty = dt.Rows(0)!Cartonqty
            End If
            If FactQty <> CartonQty Then
                MessageUtils.ShowInformation("旧外箱与新外箱所装的产品数量不符，不允许替换...")
                Exit Sub
            End If
            If Oldmoid <> Newmoid Then
                MessageUtils.ShowInformation("旧外箱与新外箱不属于同一个工单，不允许替换...")
                Exit Sub
            End If
        End If

        Dim sqlstr As String
        Try
            sqlstr = "update m_snsbarcode_t set usey='N' where sbarcode='" & Me.txtOldCarton.Text & "'"
            sqlstr = sqlstr & vbNewLine & " update m_snsbarcode_t set usey='S' where sbarcode='" & Me.txtNewCarton.Text & "'"
            sqlstr = sqlstr & vbNewLine & " update m_cartonsn_t set cartonid='" & Me.txtNewCarton.Text & "' where cartonid='" & Me.txtOldCarton.Text & "'"
            sqlstr = sqlstr & vbNewLine & " update m_carton_t set cartonid='" & Me.txtNewCarton.Text & "' where cartonid='" & Me.txtOldCarton.Text & "'"
            sqlstr = sqlstr & vbNewLine & " update m_PalletCarton_t set cartonid='" & Me.txtNewCarton.Text & "' where cartonid='" & Me.txtOldCarton.Text & "'"
            sqlstr = sqlstr & vbNewLine & " update m_PpidCheckRecord_t set cartonid='" & Me.txtNewCarton.Text & "' where cartonid='" & Me.txtOldCarton.Text & "'"
            sqlstr = sqlstr & vbNewLine & "insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,moid,Userid,Intime,Remark)values('" & txtOldCarton.Text & "','" & txtNewCarton.Text & "',N'外箱替換','" & SysMessageClass.UseId & "',getdate(),N'" & Me.rtxtRemark.Text.Trim & "'" & ")"
            DbOperateUtils.ExecSQL(sqlstr)
            MessageUtils.ShowInformation("外箱替换成功...")
        Catch ex As Exception
            MessageUtils.ShowInformation(ex.Message)
        End Try

    End Sub

    'hwASN 替换
    Private Sub btnHWAsn_Click(sender As Object, e As EventArgs) Handles btnHWAsn.Click
        Dim Sqlstr As String = String.Empty
        Try
            Sqlstr = " declare @Msg nvarchar(500),@ReturnValue int " & _
                     " exec [m_NewCheckHWASNExch]  '{0}','{1}','{2}','{3}',@Msg out,@ReturnValue out" &
                     " select @ReturnValue,@Msg"
            Sqlstr = String.Format(Sqlstr, txtHWAsnOld.Text.Trim, txtHWAsnNew.Text.Trim, rtxtRemark.Text.Trim, SysMessageClass.UseId)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "1" '失败
                        txtHWAsnOld.Text = ""
                        MessageUtils.ShowInformation(dt.Rows(0)(1))
                        Exit Select
                    Case "2" '失败
                        txtHWAsnNew.Text = ""
                        MessageUtils.ShowInformation(dt.Rows(0)(1))
                        Exit Select
                    Case "3" '失败
                        MessageUtils.ShowInformation(dt.Rows(0)(1))
                        Exit Select
                    Case "0" ''---替换成功
                        MessageUtils.ShowInformation(dt.Rows(0)(1))
                        txtHWAsnOld.Text = ""
                        txtHWAsnNew.Text = ""
                        Exit Select
                End Select
            End If
        Catch ex As Exception
            MessageUtils.ShowInformation(ex.Message)
        End Try
    End Sub


    Private Sub TextBox15_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCartonBarcode.KeyPress

        If e.KeyChar = Chr(13) Then

            txtCartonBarcode.Text = Replace(txtCartonBarcode.Text, "'", "")
            If Me.txtCartonBarcode.Text = "" Then
                Label45.Text = "外箱条码序号不能为空，请先扫描外箱条码序号..."
                txtCartonBarcode.Clear()
                txtCartonBarcode.Focus()
                Exit Sub
            End If
            Dim mRead As SqlDataReader
            'Dim mStatu As String = ""
            Dim Cartonqty As String = ""
            mRead = Conn.GetDataReader("select a.Qty,b.Cartonqty,b.Moid,b.Teamid from m_SnSBarCode_t a join m_Carton_t b on a.SBarCode=b.Cartonid  where SBarCode='" & txtCartonBarcode.Text & "' ")
            'mRead = Conn.GetDataReader("select Cartonqty from m_Carton_t   where cartonid='" & TextBox15.Text & "' and CartonStatus='Y'")

            If mRead.HasRows Then
                While mRead.Read
                    Label46.Text = mRead!Cartonqty.ToString + "/" + mRead!Qty.ToString
                    txtCartonMoid.Text = mRead!Moid.ToString
                    txtCartonLine.Text = mRead!Teamid.ToString
                    txtCartonQty.Text = mRead!Qty.ToString
                    TextBox18.Text = mRead!Cartonqty.ToString
                End While
                mRead.Close()
                Conn.PubConnection.Close()
            Else
                mRead.Close()
                Conn.PubConnection.Close()
                Label45.Text = "系统中，不存在该外箱序号，或还没有完成进行包装作业或已报废..."
                txtCartonBarcode.Clear()
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            Label45.Text = ""
            LoadCartonData(txtCartonBarcode.Text.Trim)
            btnUnbox.Enabled = True
            btnOkCarton.Enabled = True
        End If

    End Sub
    Private Sub LoadCartonData(ByVal cartonid As String)
        DataGridView1.Rows.Clear()
        Dim sql As String = "select Cartonid,ppid,Userid,Intime from m_Cartonsn_t where Cartonid='" & cartonid & "'"
        Dim mRead As SqlDataReader
        mRead = Conn.GetDataReader(sql)
        If mRead.HasRows Then
            While mRead.Read

                Me.DataGridView1.Rows.Insert(0, mRead.Item(0).ToString, mRead.Item(1).ToString, mRead.Item(2).ToString, mRead.Item(3).ToString)
                '' DGridBarCode.AutoResizeColumns()
                DataGridView1.ClearSelection()
                DataGridView1.Rows(0).Cells(0).Selected = True
            End While
        End If
        mRead.Close()
        Conn.PubConnection.Close()
    End Sub

    Private Sub TextBox16_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPpidBarcode.KeyPress

        If e.KeyChar = Chr(13) Then

            txtPpidBarcode.Text = Replace(txtPpidBarcode.Text, "'", "")
            If Me.txtPpidBarcode.Text = "" Then
                Label45.Text = "产品条码序号不能为空..."
                txtPpidBarcode.Clear()
                txtPpidBarcode.Focus()
                Exit Sub
            End If
            If txtCartonQty.Text = TextBox18.Text Then
                Label45.Text = "该箱已经装满，不能再扫描"
                Exit Sub
            End If
            Dim mRead As SqlDataReader
            'Dim mStatu As String = ""
            Dim Cartonid As String = ""
            Dim ppidmoid As String = ""
            Dim Intime As String = ""
            mRead = Conn.GetDataReader("select a.Moid,Cartonid=isnull(Cartonid,''),ppid,b.Intime from m_SnSBarCode_t a left join M_CARTONSN_T b on a.SBarCode=b.ppid  where SBarCode='" & txtPpidBarcode.Text & "' ")
            If mRead.HasRows Then
                While mRead.Read
                    Cartonid = mRead!Cartonid
                    ppidmoid = mRead!Moid
                    Intime = mRead!Intime.ToString
                End While
                mRead.Close()
                Conn.PubConnection.Close()
            Else
                '---非系统打印标签，什么都不判断
                'mRead.Close()
                'Conn.PubConnection.Close()
                'Label45.Text = "该产品条码不存在打印记录，或者是无流水号条码，不允许合并装箱"
                'Exit Sub
            End If
            If Cartonid <> "" Then
                Label45.Text = "该条码已经包装扫描过，外箱:" + Cartonid + "，时间:" + Intime
                txtPpidBarcode.SelectAll()
                txtPpidBarcode.Focus()
                Exit Sub
            End If
            If ppidmoid.Trim.ToLower <> "" Then
                If ppidmoid.Trim.ToLower <> txtCartonMoid.Text.Trim.ToLower Then
                    Label45.Text = "该条码所在工单与非当前外箱工单不一致，不允许合并装箱"
                    txtPpidBarcode.SelectAll()
                    txtPpidBarcode.Focus()
                    Exit Sub
                End If
            End If

            Dim Msqlstr As New System.Text.StringBuilder
            Msqlstr.Append(" declare @PPID varchar(100)='" & txtPpidBarcode.Text & "' " & vbNewLine)
            Msqlstr.Append(" declare @CARTON_ID varchar(100)='" & txtCartonBarcode.Text & "' " & vbNewLine)
            Msqlstr.Append(" declare @USER_ID varchar(100)='" & ToolUsename.Text & "'" & vbNewLine)
            Msqlstr.Append(" declare @AllQty int=" & txtCartonQty.Text & " " & vbNewLine)
            Msqlstr.Append(" declare @CartonQty int=0 " & vbNewLine)

            Msqlstr.Append(" insert M_CARTONSN_T(ppid,Cartonid,ppidQty,Userid,Status,Intime,Mark1)" & vbNewLine)
            Msqlstr.Append(" VALUES (@PPID,@CARTON_ID,1,@USER_ID,0,GETDATE(),N'合并装箱') " & vbNewLine)
            'Msqlstr.Append(" delete from m_Cartonsn_t where cartonid='" & TextBox15.Text & "'" & vbNewLine)
            Msqlstr.Append(" update m_Carton_t set Cartonqty=ISNULL(Cartonqty,0)+1  where cartonid='" & txtCartonBarcode.Text & "'" & vbNewLine)
            Msqlstr.Append(" insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,moid,Userid,Intime)values(@PPID,@CARTON_ID,N'合并装箱','" & SysMessageClass.UseId & "',getdate())")
            Try
                'MessageBox.Show(Msqlstr.ToString)
                DbOperateUtils.ExecSQL(Msqlstr.ToString)
                Me.DataGridView1.Rows.Insert(0, txtCartonBarcode.Text.ToString, txtPpidBarcode.Text.ToString, ToolUsename.Text, Now.ToString("yyyy/MM/dd HH:mm:ss").ToString)
                '' DGridBarCode.AutoResizeColumns()
                DataGridView1.ClearSelection()
                DataGridView1.Rows(0).Cells(0).Selected = True
                TextBox18.Text = (Integer.Parse(TextBox18.Text) + 1).ToString
                Label46.Text = TextBox18.Text + "/" + txtCartonQty.Text
                If txtCartonQty.Text = TextBox18.Text Then
                    Label45.Text = "装箱扫描完成...该箱已经装满，请继续扫描下一箱"
                    txtCartonBarcode.Clear()
                    txtCartonBarcode.Focus()
                Else
                    Label45.Text = "装箱扫描完成..."
                    txtPpidBarcode.Clear()
                    txtPpidBarcode.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub

    Private Sub btnUnbox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnbox.Click

        If txtCartonBarcode.Text.Trim = "" Then
            Label45.Text = "外箱条码不允许为空..."
            Exit Sub
        End If


        Dim Cartonqty As String = ""
        Dim mRead As SqlDataReader = Conn.GetDataReader("select Cartonqty=isnull(Cartonqty,0) from m_Carton_t where cartonid='" & txtCartonBarcode.Text & "'")
        If mRead.HasRows Then
            While mRead.Read
                Cartonqty = mRead!Cartonqty
            End While
            mRead.Close()
            Conn.PubConnection.Close()
            If Cartonqty = "0" Then
                Label45.Text = "该箱为空箱，不需要拆箱..."
                Exit Sub
            End If
        Else
            mRead.Close()
            Conn.PubConnection.Close()
            Label45.Text = "外箱条码不存在或者已删除..."
            Exit Sub
        End If


        Dim Msqlstr As New System.Text.StringBuilder
        Msqlstr.Append(" insert m_CartonsnRework_t(ppid,Cartonid,ppidQty,Userid,Status,Intime,Mark1)" & vbNewLine)
        Msqlstr.Append(" select ppid,Cartonid,ppidQty,Userid,Status,Intime,Mark1=N'外箱拆除' from m_Cartonsn_t where Cartonid='" & txtCartonBarcode.Text & "' " & vbNewLine)
        Msqlstr.Append(" delete from m_Cartonsn_t where cartonid='" & txtCartonBarcode.Text & "'" & vbNewLine)
        Msqlstr.Append(" update m_Carton_t set Cartonqty='0' where cartonid='" & txtCartonBarcode.Text & "'" & vbNewLine)
        Msqlstr.Append(" insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,moid,Userid,Intime)values('" & txtCartonBarcode.Text & "','" & txtCartonBarcode.Text & "',N'外箱拆箱','" & SysMessageClass.UseId & "',getdate())")
        Try
            'MessageBox.Show(Msqlstr.ToString)
            DbOperateUtils.ExecSQL(Msqlstr.ToString)

            Label45.Text = "外箱条码" + txtCartonBarcode.Text + "拆箱处理完成..."
            btnUnbox.Enabled = False
            btnOkCarton.Enabled = False
            txtCartonBarcode.Clear()
            txtPpidBarcode.Clear()
            txtCartonBarcode.Enabled = True
            txtCartonBarcode.Focus()
            txtPpidBarcode.Enabled = False
            txtCartonMoid.Clear()
            txtCartonLine.Clear()
            Label46.Text = 0
            'Label47.Text = 0
            LoadCartonData(txtCartonBarcode.Text.Trim)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub btnPartBarcode_Click(sender As Object, e As EventArgs) Handles btnPartBarcode.Click
        If String.IsNullOrEmpty(Me.rtxtRemark.Text.Trim) Then
            MessageUtils.ShowInformation("请填写替换说明!")
            Exit Sub
        End If
        If Me.replaceppidold.Text = "" Or replaceppidnew.Text = "" Then
            MessageUtils.ShowInformation("不良品序号或替换产品序号不能为空...")
            Exit Sub
        End If
        If CheckSysBarcode(replaceppidold.Text) And Not SystemPrtChk.Checked Then
            MessageUtils.ShowInformation("旧条码是系统打印条码，需要勾选系统打印条码...")
            Exit Sub
        End If
        If CheckMainPPID(replaceppidold.Text) Then
            MessageUtils.ShowInformation("旧产品条码是主条码,不能用部件条码替换...")
            Exit Sub
        End If

        '判断新旧条码长度是否一致 关晓艳 2018/08/14
        If Len(Me.replaceppidold.Text.Trim) <> Len(Me.replaceppidnew.Text.Trim) Then
            MessageUtils.ShowInformation("替换新旧条码长度不一致")
            Exit Sub
        End If

        Dim mSql As String = "update m_snsbarcode_t set Usey='S' where SBarCode='" & replaceppidnew.Text & "'"
        mSql = mSql & vbNewLine & " update m_snsbarcode_t set Usey='N' where SBarCode='" & replaceppidold.Text & "'"
        mSql = mSql & vbNewLine & " update m_ppidlink_t set ppid='" & replaceppidnew.Text & "' where ppid='" & replaceppidold.Text & "' and exppid<>ppid"
        mSql = mSql & vbNewLine & "insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,moid,Userid,Intime,Remark)values('" & replaceppidold.Text & "','" & replaceppidnew.Text & "',N'部件替換','" & SysMessageClass.UseId & "',getdate(),N'" & Me.rtxtRemark.Text & "'" & ")"
        Try
            Conn.ExecSql(mSql)
            Conn.PubConnection.Close()
            replaceppidold.Clear()
            replaceppidnew.Clear()
            MessageUtils.ShowInformation("该产品已被新的部件替换成功，请将新部件放入旧部件对应的外箱内...")
        Catch ex As Exception
            MessageUtils.ShowInformation("该产品替换时，发生错误...")
        End Try

    End Sub


    Private Sub btnOkCarton_Click(sender As Object, e As EventArgs) Handles btnOkCarton.Click
        If btnOkCarton.Text = "确认重新扫描装箱" Then
            txtCartonBarcode.Enabled = False
            txtPpidBarcode.Enabled = True

            btnOkCarton.Text = "取消装箱扫描"
            btnUnbox.Enabled = False
            Dim Cartonqty As String = ""
            Dim mRead As SqlDataReader = Conn.GetDataReader("select a.Qty,b.Cartonqty,b.Moid,b.Teamid from m_SnSBarCode_t a join m_Carton_t b on a.SBarCode=b.Cartonid  where SBarCode='" & txtCartonBarcode.Text & "' ")
            'mRead = Conn.GetDataReader("select Cartonqty from m_Carton_t   where cartonid='" & TextBox15.Text & "' and CartonStatus='Y'")

            If mRead.HasRows Then
                While mRead.Read
                    Label46.Text = mRead!Cartonqty.ToString + "/" + mRead!Qty.ToString
                    txtCartonMoid.Text = mRead!Moid.ToString
                    txtCartonLine.Text = mRead!Teamid.ToString
                    txtCartonQty.Text = mRead!Qty.ToString
                    TextBox18.Text = mRead!Cartonqty.ToString
                End While
                mRead.Close()
                Conn.PubConnection.Close()
            Else
                mRead.Close()
                Conn.PubConnection.Close()
                Label45.Text = "系统中，不存在该外箱序号，或还没有完成进行包装作业或已报废..."
                txtCartonBarcode.Clear()
                Exit Sub
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            txtPpidBarcode.Focus()
        Else
            txtCartonBarcode.Enabled = True
            txtPpidBarcode.Enabled = False
            txtPpidBarcode.Clear()
            btnOkCarton.Text = "确认重新扫描装箱"
            btnUnbox.Enabled = True
            txtCartonBarcode.SelectAll()
            txtCartonBarcode.Focus()
        End If

    End Sub

#Region "设置扫描数量"
    '确认
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim strSQL As String = "if ('{0}' = 'true')" &
       " begin update m_MOPackingLevel set qty = '{1}', createtime =getdate() where SBarCode  = '{3}' End " &
       " Else " &
       " begin update m_snsbarcode_t set qty ='{1}',userid = '{2}',intime =getdate() where SBarCode  = '{3}' End "

        strSQL = String.Format(strSQL, chkIsPackType.Checked.ToString.ToLower, txtNewQty.Text.Trim, VbCommClass.VbCommClass.UseId, txtScanPpid.Text.Trim)

        DbOperateUtils.ExecSQL(strSQL)

        MessageUtils.ShowInformation("更新成功，可以扫描了！")
    End Sub

    '扫描条码取得原数量
    Private Sub txtScanPpid_KeyDown(sender As Object, e As KeyEventArgs) Handles txtScanPpid.KeyDown
        If e.KeyValue = 13 Then
            Dim strSQL As String = "if ('{0}' = 'true')" &
           " begin select qty  from m_MOPackingLevel where SBarCode  = '{1}'  End " &
           " Else " &
           " begin select qty  from m_snsbarcode_t where SBarCode  = '{1}' end "

            strSQL = String.Format(strSQL, chkIsPackType.Checked.ToString.ToLower, txtScanPpid.Text.Trim)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            '如果没有数据时
            txtOldQty.Text = 0
            If dt.Rows.Count > 0 Then
                txtOldQty.Text = dt.Rows(0)(0).ToString
            End If
        End If
    End Sub

#End Region


    Private Sub btnCloseCarton_Click(sender As Object, e As EventArgs) Handles btnCloseCarton.Click
        Try
            If txtCartonBarcode.Text.Trim = "" Then
                Label45.Text = "外箱条码不允许为空..."
                Exit Sub
            End If


            Dim Cartonqty As String = ""
            Dim mRead As SqlDataReader = Conn.GetDataReader("select Cartonqty=isnull(Cartonqty,0) from m_Carton_t where cartonid='" & txtCartonBarcode.Text & "'")
            If mRead.HasRows Then
                While mRead.Read
                    Cartonqty = mRead!Cartonqty
                End While
                mRead.Close()
                Conn.PubConnection.Close()
                'If Cartonqty = "0" Then
                '    Label45.Text = "该箱为空箱，不能关箱..."
                '    Exit Sub
                'End If
            Else
                mRead.Close()
                Conn.PubConnection.Close()
                Label45.Text = "外箱条码不存在或者已删除..."
                Exit Sub
            End If

            Conn.ExecSql("update m_Carton_t set CartonStatus='Y',PackingQuantity = Cartonqty,MARK2=N'强制关箱'  where Cartonid='" & txtCartonBarcode.Text.Trim & "'")
            Conn.PubConnection.Close()
            Label45.Text = "外箱条码" + txtCartonBarcode.Text + "关箱处理完成..."
            btnUnbox.Enabled = False
            btnOkCarton.Enabled = False
            txtCartonBarcode.Clear()
            txtPpidBarcode.Clear()
            txtCartonBarcode.Enabled = True
            txtCartonBarcode.Focus()
            txtPpidBarcode.Enabled = False
            txtCartonMoid.Clear()
            txtCartonLine.Clear()
            Label46.Text = 0
            'Label47.Text = 0
            LoadCartonData(txtCartonBarcode.Text.Trim)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub replaceppidold_KeyPress(sender As Object, e As KeyPressEventArgs) Handles replaceppidold.KeyPress
        If e.KeyChar = Chr(13) Then

            replaceppidnew.Focus()
        End If
    End Sub

    Private Function CheckMainPPID(ByVal oldppid As String) As Boolean
        Dim mRead As SqlDataReader = Conn.GetDataReader("select ppid from m_Ppidlink_t  where ppid='" & replaceppidold.Text & "' and exppid=ppid")
        Try
            If mRead.HasRows Then
                Return True
            Else
                Return False
            End If
        Finally
            mRead.Close()
            Conn.PubConnection.Close()
        End Try
    End Function
    Private Function CheckSysBarcode(ByVal oldppid As String) As Boolean
        Dim mRead As SqlDataReader = Conn.GetDataReader("select SBarCode from m_SnSBarCode_t  where SBarCode='" & replaceppidold.Text & "'")
        Try
            If mRead.HasRows Then
                Return True
            Else
                Return False
            End If
        Finally
            mRead.Close()
            Conn.PubConnection.Close()
        End Try
    End Function

    '检查待替换的条码样式是否一致 add by hgd 2018-01-18
    Private Function CheckStyleIsSame(ByVal barcode As String, ByVal newBarCode As String) As Boolean
        Dim styleId As String = ""
        Dim o_strSql As New StringBuilder
        Dim o_strStyleSql As New StringBuilder
        Dim strTmp As String
        Dim strTmpStyle As String
        Dim dt As New DataTable
        Dim dtStyle As New DataTable
        Try
            o_strSql.Append("SELECT b.Cartonid,b.Moid,c.PartID,d.CodeRuleID FROM M_CARTONSN_T a left join  ")
            o_strSql.Append(" M_CARTON_T b on b.Cartonid=a.Cartonid left join ")
            o_strSql.Append(" m_mainmo_t c on c.Moid=b.Moid left join ")
            o_strSql.Append(" m_PartPack_t d on d.Partid=c.PartID and d.Usey='Y' AND (D.Packid='S' OR D.DisorderTypeId='S') ")
            o_strSql.Append("  WHERE PPID='" & barcode & "' ")
            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                o_strStyleSql.Append(" declare @moid varchar(100)='" & dt.Rows(0)!Moid.ToString & "' ")
                o_strStyleSql.Append(" declare @dates varchar(10)=GETDATE() ")
                o_strStyleSql.Append(" declare @partid varchar(100) ")
                o_strStyleSql.Append(" select @partid=partid from m_mainmo_t where moid=@moid ")
                o_strStyleSql.Append(" DECLARE @SnStyle1 varchar(70),@SnStyle2 varchar(70),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2='' set @Gflen='' ")
                o_strStyleSql.Append(" EXECUTE [m_StyleShow_p_AssembleSta] @partid,'" & dt.Rows(0)!CodeRuleID.ToString & "',@dates,@SnStyle1 output ,@SnStyle2 output,@Gflen output,@moid  SELECT @SnStyle1,@SnStyle2,@Gflen ")
                dtStyle = DbOperateUtils.GetDataTable(o_strStyleSql.ToString)
                If dtStyle.Rows.Count > 0 Then
                    styleId = dtStyle.Rows(0)(0).ToString
                    Dim i As Int32
                    For i = 0 To styleId.Length - 1
                        strTmp = styleId.Substring(i, 1)
                        strTmpStyle = newBarCode.Substring(i, 1)
                        If strTmp <> "*" Then
                            If strTmp <> strTmpStyle Then
                                'MessageBox.Show("新条码和旧条码的样式不一致，无法替换，请确认下是否为同一供应商来料...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return False
                            End If
                        End If
                    Next

                End If
            Else
                MessageUtils.ShowInformation("当前产品条码没有扫描过，无法替换...")
                Return False
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function


#Region "机台测试数据异常处理"
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedTab.Name = "tpTestDataHandle" AndAlso Me.InitialTestTab = "N" Then
            Dim strsql As String = "select distinct isnull(productgroup,'') name, productgroup value from MESDataCenter .dbo .m_TestType_t  where ProductGroup IS NOT null"
            LoadDataToCob(strsql, cbbGroupStation)
            Me.lbTestMsg.Text = ""
            Me.InitialTestTab = "Y"
        End If
    End Sub

    Private Sub cbbGroupStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbGroupStation.SelectedIndexChanged
        If cbbGroupStation.Text <> "" Then
            Dim sqlquery As String = "select '('+TestTypeID+')'+ testtypename name,TestTypeID value  from MESDataCenter .dbo .m_TestType_t  where  productgroup ='" & cbbGroupStation.Text & "'and Usey ='Y' order by stationseq"
            LoadDataToCob(sqlquery, cbbStation)
        Else
            MessageBox.Show("请选择群组")

        End If
    End Sub

    Private Sub btnTestHandle_Click(sender As Object, e As EventArgs) Handles btnTestHandle.Click
        Try
            Dim o_strSql As New StringBuilder
            Dim strStationId As String
            Dim dt As New DataTable
            strStationId = Me.cbbStation.SelectedValue.ToString

            If String.IsNullOrEmpty(Me.txtTestPPid.Text) Then
                Me.lbTestMsg.Text = "请扫描产品条码!"
                Exit Sub
            End If
            o_strSql.Append("DECLARE @FLAG INT;")
            o_strSql.Append(" EXEC EXEC_TestDataFailHandle_P '" & strStationId & "','" & Me.txtTestPPid.Text & "',@FLAG OUTPUT")
            o_strSql.Append(" SELECT @FLAG ")
            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)(0).ToString = "1" Then
                    Me.lbTestMsg.Text = "机台测试Fail数据清除成功!"

                Else
                    Me.lbTestMsg.Text = "条码不存在,机台测试Fail数据清除失败!"
                End If
                Me.txtTestPPid.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadDataToCob(ByVal SqlStr As String, ByVal CobName As ComboBox)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
        CobName.DataSource = Nothing

        'For index As Integer = 0 To dt.Rows.Count - 1
        '    CobName.Items.Add(dt.Rows(index)(0).ToString)
        'Next
        CobName.DataSource = dt
        CobName.DisplayMember = "name"
        CobName.ValueMember = "value"
    End Sub

#End Region

    '替换条码不允许手动输入 必须扫描枪输入 关晓艳2018/08/14
    Private _dt As DateTime = DateTime.Now  '定义一个成员函数用于保存每次的时间点
    Private Sub replaceppidnew_KeyPress(sender As Object, e As KeyPressEventArgs) Handles replaceppidnew.KeyPress
        If e.KeyChar <> Chr(13) Then
            ''禁止用键盘手动输入
            Dim tempDt As DateTime = DateTime.Now  '保存按键按下时刻的时间点
            Dim ts As TimeSpan = tempDt.Subtract(_dt)  '获取时间间隔
            If (ts.Milliseconds > 50) Then
                replaceppidnew.Text = ""   '判断时间间隔，如果时间间隔大于50毫秒，则将TextBox清空 
            End If
            _dt = tempDt
        Else
            Me.ActiveControl = replaceppidnew
            Me.replaceppidnew.Focus()
        End If
    End Sub
    Private Sub txtNewCarton_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNewCarton.KeyPress
        If e.KeyChar <> Chr(13) Then
            Dim tempDt As DateTime = DateTime.Now
            Dim ts As TimeSpan = tempDt.Subtract(_dt)  '获取时间间隔   
            If ts.Milliseconds > 50 Then
                txtNewCarton.Text = ""
            End If
            _dt = tempDt
        Else
            Me.ActiveControl = txtNewCarton
            Me.txtNewCarton.Focus()
        End If
    End Sub

    Private Sub txtHWAsnNew_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHWAsnNew.KeyPress
        If e.KeyChar <> Chr(13) Then
            Dim tempDt As DateTime = DateTime.Now
            Dim ts As TimeSpan = tempDt.Subtract(_dt)  '获取时间间隔   
            If ts.Milliseconds > 50 Then
                txtHWAsnNew.Text = ""
            End If
            _dt = tempDt
        Else
            Me.ActiveControl = txtNewCarton
            Me.txtHWAsnNew.Focus()
        End If
    End Sub

    Private Sub txtNewPallet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNewPallet.KeyPress
        If e.KeyChar <> Chr(13) Then
            Dim tempDt As DateTime = DateTime.Now
            Dim ts As TimeSpan = tempDt.Subtract(_dt)  '获取时间间隔   
            If ts.Milliseconds > 50 Then
                txtNewPallet.Text = ""
            End If
            _dt = tempDt
        Else
            Me.ActiveControl = txtNewCarton
            Me.txtNewPallet.Focus()
        End If
    End Sub
    '栈板替换 关晓艳 2018/09/18
    Private Sub btnPallet_Click(sender As Object, e As EventArgs) Handles btnPallet.Click
        Dim oldMoid As String
        Dim newMoid As String
        Dim newQty As Integer
        Dim oldQty As Integer

        If String.IsNullOrEmpty(Me.rtxtRemark.Text.Trim) Then
            MessageUtils.ShowInformation("请填写替换说明！")
            Exit Sub
        End If
        If Me.txtOldPallet.Text = "" Or Me.txtNewPallet.Text = "" Then
            MessageUtils.ShowInformation("旧栈板编号或新栈板编号不能为空！")
            Exit Sub
        End If
        If Len(Me.txtOldPallet.Text.Trim) <> Len(Me.txtNewPallet.Text.Trim) Then
            MessageUtils.ShowInformation("替换新旧栈板编号长度不一致！")
            Return
        End If

        Dim dt As DataTable = DbOperateUtils.GetDataTable("select Palletid,Palletqty,Moid from m_palletM_t where Palletid ='" & Me.txtOldPallet.Text.Trim & "'")
        If dt.Rows.Count <= 0 Then
            MessageUtils.ShowInformation("该替换的旧栈板编号还未进行包装扫描，不允许被替换！")
            Return
        Else
            oldMoid = dt.Rows(0)(2).ToString
            oldQty = dt.Rows(0)(1).ToString
        End If

        Dim dt1 As DataTable = DbOperateUtils.GetDataTable("select 1 from m_PalletCarton_t  where Palletid ='" & Me.txtNewPallet.Text.Trim & "'")
        If dt1.Rows.Count > 0 Then
            MessageUtils.ShowInformation("该替换的新栈板编号已装箱，不允许被替换！")
            Return
        End If

        If SystemPrtPalletChk.Checked Then
            Dim dt2 As DataTable = DbOperateUtils.GetDataTable("select moid,Qty from m_snsbarcode_t where sbarcode='" & Me.txtNewPallet.Text.Trim & "'")
            If dt2.Rows.Count <= 0 Then
                MessageUtils.ShowInformation("新栈板外箱非系统打印条码！")
                Return
            Else
                newMoid = dt2.Rows(0)(0).ToString
                newQty = dt2.Rows(0)(1).ToString
                If oldQty <> newQty Then
                    MessageUtils.ShowInformation("新旧栈板所装数量不符，不允许替换！")
                    Return
                End If
                If oldMoid <> newMoid Then
                    MessageUtils.ShowInformation("新旧栈板工单不符，不允许替换！")
                    Return
                End If
            End If
        End If
        Dim strSQL As String
        Try
            strSQL = "update m_snsbarcode_t set usey='N' where sbarcode='" & Me.txtOldPallet.Text & "'"
            strSQL = strSQL & vbNewLine & " update m_snsbarcode_t set usey='S' where sbarcode='" & Me.txtNewPallet.Text & "'"
            strSQL = strSQL & vbNewLine & " update m_palletM_t set Palletid='" & Me.txtNewPallet.Text & "' where Palletid='" & Me.txtOldPallet.Text & "'"
            strSQL = strSQL & vbNewLine & " update m_PalletCarton_t set Palletid='" & Me.txtNewPallet.Text & "' where Palletid='" & Me.txtOldPallet.Text & "'"
            strSQL = strSQL & vbNewLine & "insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,moid,Userid,Intime,Remark)values('" & txtOldPallet.Text & "','" & txtNewPallet.Text & "',N'" & oldMoid & "','" & SysMessageClass.UseId & "',getdate(),N'" & Me.rtxtRemark.Text.Trim & "'" & ")"
            DbOperateUtils.ExecSQL(strSQL)
            MessageUtils.ShowInformation("栈板替换成功！")
        Catch ex As Exception
            MessageUtils.ShowInformation(ex.Message)
        End Try
        Me.txtNewPallet.Text = ""
        Me.txtOldPallet.Text = ""
        Me.rtxtRemark.Text = ""
    End Sub


    Private Sub btnChangeMoid_Click(sender As Object, e As EventArgs) Handles btnChangeMoid.Click
        If String.IsNullOrEmpty(Me.txtChangeMoid.Text.Trim) Then
            MessageUtils.ShowInformation("请输入重新投入的工单！")
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.txtChangePpid.Text.Trim) Then
            MessageUtils.ShowInformation("请输入重新投入的产品条码！")
            Exit Sub
        End If
        Dim strPpid As String = Me.txtChangePpid.Text.Trim
        Dim sqlChangeMo As String = " declare @Rtv int declare @Msg nvarchar(150) " & vbCrLf &
          " exec m_PpidChangeMoInput_P '" + Me.txtChangeMoid.Text.Trim + "','" + strPpid + "','" + SysMessageClass.UseId + "', @Rtv OUTPUT,@Msg OUTPUT " & vbCrLf &
          " select @Rtv,@Msg "
        Dim dtCmo As DataTable = DbOperateUtils.GetDataTable(sqlChangeMo)
        If dtCmo.Rows.Count > 0 Then
            Me.txtChangePpid.Clear()
            If dtCmo.Rows(0)(0).ToString() = "1" Then
                labChangeMoMsg.Text = "产品条码：" & strPpid & "重新投入新工单成功！"
                labChangeMoMsg.ForeColor = Color.Green

            Else
                labChangeMoMsg.Text = "产品条码重新投入失败：" & dtCmo.Rows(0)(1).ToString()
                labChangeMoMsg.ForeColor = Color.Red
            End If
        End If



    End Sub

    Private Sub txtChangePpid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChangePpid.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not String.IsNullOrEmpty(txtChangePpid.Text) Then
                GetChangePpidStation(txtChangePpid.Text.Trim)
            End If
        End If

    End Sub


    Private Sub GetChangePpidStation(ByVal ppid As String)
        Dim strSql As String
        strSql = "select a.Stationid+'-'+b.Stationname  as stationname from m_Assysn_t a  left join m_Rstation_t b on b.Stationid=a.Stationid where a.Ppid='" + ppid + "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
        labChangeMoMsg.Text = ""
        If dt.Rows.Count > 0 Then
            labChangeMoMsg.Text = "当前工站：" & dt.Rows(0)("stationname").ToString()
            labChangeMoMsg.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ShowFrmScanErrPrompt(barcode As String, message As String)
        Dim FrmError As New FrmScanErrPrompt(barcode, message)
        FrmError.ShowDialog()
    End Sub

    Private Sub txtLXASN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLXASN.KeyPress
        If e.KeyChar = Chr(13) Then
            CheckLXASNPSNCode()
        End If
    End Sub

    Private Sub btnLXAsn_Click(sender As Object, e As EventArgs) Handles btnLXAsn.Click
        CheckLXASNPSNCode()
    End Sub

    Private Sub CheckLXASNPSNCode()
        Dim strSql As String
        strSql = " declare @Msg nvarchar(500),@ReturnValue int exec [m_NewCheckLXASNPSNCode] '{0}',@Msg out,@ReturnValue out select @Msg,@ReturnValue"
        strSql = String.Format(strSql, txtLXASN.Text.Trim)

        Dim dtHWASN As DataTable = DbOperateUtils.GetDataTable(strSql)
        '条码判断
        If dtHWASN.Rows(0)(1).ToString() = "0" Then '扫描成功
            lblLXasnPSN.Text = "验证成功！"
            'ShowFrmScanErrPrompt(txtLXASN.Text, dtHWASN.Rows(0)(0).ToString())
            Me.txtLXASN.Text = ""
            Me.txtLXASN.Focus()
        ElseIf dtHWASN.Rows(0)(1).ToString() = "1" Then '抛错误信息
            lblLXasnPSN.Text = dtHWASN.Rows(0)(0).ToString()
            'ShowFrmScanErrPrompt(txtLXASN.Text, dtHWASN.Rows(0)(0).ToString())
            Me.txtLXASN.Text = ""
            Me.txtLXASN.Focus()
            Exit Sub
        End If
    End Sub


    Private Sub txtScanSN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtScanSn.KeyPress
        If e.KeyChar = Chr(13) Then
            SnScanMatch()
        End If
    End Sub

    Private Sub SnScanMatch()
        Dim isScan As String = CheckSnScan()
        If isScan = "1" Then
            lblSNMatchMssg.Text = "该SN已被扫描过,结果为: UI重复"
            lblSNMatchMssg.ForeColor = Color.Red
            Me.txtScanSn.Text = ""
            Me.txtScanSn.Focus()
            Exit Sub
        End If

        If isScan = "2" Then
            lblSNMatchMssg.Text = "该SN已被扫描过,结果为: Pass"
            lblSNMatchMssg.ForeColor = Color.Green
            Me.txtScanSn.Text = ""
            Me.txtScanSn.Focus()
            Exit Sub
        End If

        Dim mRead As SqlDataReader = Conn.GetDataReader("select Sn from SnMatch where Sn='" & Me.txtScanSn.Text.Trim() & "'")
        If mRead.HasRows Then
            mRead.Close()
            Conn.PubConnection.Close()
            lblSNMatchMssg.Text = "UI重复"
            InsertSnMatchList("Y")
            lblSNMatchMssg.ForeColor = Color.Red
            Me.txtScanSn.Text = ""
            Me.txtScanSn.Focus()
        Else
            mRead.Close()
            Conn.PubConnection.Close()
            lblSNMatchMssg.Text = "Pass"
            InsertSnMatchList("N")
            lblSNMatchMssg.ForeColor = Color.Green
            Me.txtScanSn.Text = ""
            Me.txtScanSn.Focus()
        End If
    End Sub

    '''返回值1 : 表示该SN 已被扫描过，扫描结果为UI重复
    '''返回值2 : 表示该SN 已被扫描过，扫描结果为Pass
    '''返回值3 : 表示该SN 已未被扫描
    Private Function CheckSnScan() As String
        Dim mRead As SqlDataReader = Conn.GetDataReader("select [Status] from SnMatchList where Sn='" & Me.txtScanSn.Text.Trim() & "'")
        Dim status As String = "N"
        If mRead.HasRows Then
            While mRead.Read
                status = mRead!Status
            End While
            mRead.Close()
            Conn.PubConnection.Close()
            If status = "Y" Then
                Return "1"
            Else
                Return "2"
            End If
        Else
            mRead.Close()
            Conn.PubConnection.Close()
            Return "3"
        End If
    End Function

    Private Sub InsertSnMatchList(ByVal status As String)
        Dim sqlstr As String = "Insert into SnMatchList Select '{0}','{1}'"
        sqlstr = String.Format(sqlstr, Me.txtScanSn.Text.Trim(), status)
        Conn.ExecSql(sqlstr)
        Conn.PubConnection.Close()
    End Sub


    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        Dim sqlstr As String = "select SN,case [Status] when 'Y' then 'UI重复' else 'Pass' end as [Status] from SnMatchList"
        Dim ds As DataSet = DbOperateUtils.GetDataSet(sqlstr)
        Dim dt As DataTable = ds.Tables(0)
        Try
            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If

            Dim Swriter As New IO.StreamWriter("c:\MesExport\SN扫描记录.csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            For Each r As DataRow In dt.Rows

                nColqty = 0

                For Each c As DataColumn In dt.Columns
                    '写入标题行
                    If bColName = False Then
                        If wColName = "" Then
                            wColName = c.ColumnName.Replace(",", "，")
                        Else
                            wColName = wColName + "," + c.ColumnName.Replace(",", "，")
                        End If
                    End If

                    '写入每行的值
                    If nColqty = 0 Then
                        wValue = r.Item(c.ColumnName).ToString.Replace(",", "，")
                    Else
                        wValue = wValue + "," + r.Item(c.ColumnName).ToString.Replace(",", "，")
                    End If
                    nColqty = nColqty + 1

                Next

                If wColName <> "" And bColName = False Then
                    Swriter.WriteLine(wColName)
                    bColName = True
                End If

                Swriter.WriteLine(wValue)

            Next
            Swriter.Close()

            MessageBox.Show("文件导出成功,导出位置：c:\MesExport\SN扫描记录.csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
