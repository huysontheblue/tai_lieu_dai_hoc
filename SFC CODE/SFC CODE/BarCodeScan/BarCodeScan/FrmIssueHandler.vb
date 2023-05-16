Imports MainFrame
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Public Class FrmIssueHandler
    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Enum PalletGrid
        PalletId = 0
        MultiQty
        PalletQty
        Status
        ButtonE
    End Enum

    Enum CartonGrid
        PalletId = 0
        CartonId
        PackingQty
        CartonQty
        Status
        ButtonE
    End Enum

    Enum Series
        Selected = 0
        CartonId
        CartonQty
        Sn
    End Enum

    Enum QueryType
        Series
        Carton
        Pallet
    End Enum

    Sub New(ByVal MOID As String, ByVal index As Integer)
        InitializeComponent()
        txtMoid.Text = MOID
        TabControl1.SelectedIndex = index
    End Sub

    Sub New(ByVal MOID As String, ByVal arr As String())
        InitializeComponent()
        txtMoid.Text = MOID
        TextBox2.Text = MOID
        Dim currentIndex As Integer = 0
        For index As Integer = 0 To arr.Length - 1
            If arr(index) = "true" Then
                TabControl1.TabPages(index).Tag = True
                currentIndex = index
            Else
                TabControl1.TabPages(index).Tag = False
            End If
        Next
        TabControl1.SelectTab(currentIndex)
    End Sub

#Region "漏扫查询"
    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click
        If String.IsNullOrEmpty(txtMoid.Text) Then
            MessageBox.Show("请先输入工单")
            Exit Sub
        End If
        Query(QueryType.Series)

    End Sub
    Dim dt As DataTable
    Dim dr() As DataRow
    Private Sub Query(ByVal type As QueryType)
        Dim sql As String = Nothing
        Select Case type
            Case QueryType.Series
                sql = "SELECT PPID  FROM M_CARTONSN_T A,M_CARTON_T B WHERE A.CARTONID=B.CARTONID AND B.MOID='" & txtMoid.Text & "' ORDER BY A.INTIME DESC"
            Case QueryType.Carton
                sql = "SELECT CARTONID AS PPID  FROM M_CARTON_T  WHERE MOID='" & txtMoid.Text & "' ORDER BY INTIME DESC"
            Case QueryType.Pallet
                sql = "SELECT PALLETID AS PPID  FROM M_PALLETM_T WHERE MOID='" & txtMoid.Text & "' ORDER BY INTIME DESC"
        End Select

        dt = DbOperateUtils.GetDataTable(sql)
        dgResult.DataSource = dt
        dgResult.Columns(0).Width = 250
    End Sub

    Private Sub FrmIssueHandler_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetCPQty()
        If Not String.IsNullOrEmpty(txtMoid.Text) Then
            toolScanSet_Click(Nothing, Nothing)
        End If
        txtPPid.Focus()
        txtPPid.Select()
    End Sub

    Private Sub txtPPid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPPid.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtPPid.Text.Trim.ToUpper = "REWORK" Then
                Me.Close()
            End If
            If dt Is Nothing Then
                txtPPid.Clear()
                MessageBox.Show("请先输入工单查询该工单已扫描的产品条码")
                txtMoid.Focus()
                Exit Sub
            End If
            dr = dt.Select("PPID='" & txtPPid.Text & "'")
            If dr.Length > 0 Then
                lblMsg.Text = String.Format("条码{0}已扫描过", txtPPid.Text)
                lblMsg.ForeColor = Color.Blue
            Else
                lblMsg.Text = String.Format("条码{0}没有描过", txtPPid.Text)
                lblMsg.ForeColor = Color.Red
                dgvMissed.Rows.Insert(0, txtPPid.Text)
            End If
            txtPPid.Clear()
        End If
    End Sub

    Private Sub cobType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cobType.SelectedIndexChanged
        If Not cobType.SelectedItem Is Nothing Then
            If cobType.SelectedItem.ToString.Substring(0, 1) = "S" Then
                Query(QueryType.Series)
            ElseIf cobType.SelectedItem.ToString.Substring(0, 1) = "C" Then
                Query(QueryType.Carton)
            Else
                Query(QueryType.Pallet)
            End If
        End If
    End Sub

#End Region

#Region "条码替换"
    Dim cStartIndex As Integer = -1
    Dim cLength As Integer = -1
    Dim pStartIndex As Integer = -1
    Dim pLength As Integer = -1
    Private Sub GetCPQty()
        Dim sql As String = "SELECT B.PACKID, F_CODESTART,F_CODELEN FROM M_MAINMO_T A,M_PARTPACK_T B,m_SnRuleD_t C WHERE A.MOID='" & txtMoid.Text & "' AND A.PARTID=B.PARTID " & vbNewLine & _
        "AND  B.PACKID='C' AND B.CodeRuleID=C.CodeRuleID AND  C.F_codeID='Q' AND BarArea='BarCode1' " & vbNewLine & _
        " UNION SELECT B.PACKID, F_CODESTART,F_CODELEN FROM M_MAINMO_T A,M_PARTPACK_T B,m_SnRuleD_t C WHERE A.MOID='" & txtMoid.Text & "' AND A.PARTID=B.PARTID " & vbNewLine & _
        " AND  B.PACKID='P' AND B.CodeRuleID=C.CodeRuleID AND  C.F_codeID='Q' AND BarArea='BarCode1' "
        Using dt As DataTable = Conn.GetDataTable(sql)
            For Each dr As DataRow In dt.Rows
                If dr("PACKID") = "C" Then
                    cStartIndex = dr("F_CODESTART").ToString
                    cLength = dr("F_CODELEN").ToString
                ElseIf dr("PACKID") = "P" Then
                    pStartIndex = dr("F_CODESTART").ToString
                    pLength = dr("F_CODELEN").ToString
                End If
            Next
        End Using

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnReplace.Click
        If String.IsNullOrEmpty(cobReplaceType.SelectedItem) Then
            MessageBox.Show("请选择替换类型")
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtIssuePPid.Text) OrElse String.IsNullOrEmpty(txtOkPPid.Text) Then
            MessageBox.Show("请输入不良条码或良品条码")
            Exit Sub
        End If

        Dim style1 As String = ""
        Dim style2 As String = ""
        If Not cobReplaceType.SelectedItem Is Nothing Then
            If cobReplaceType.SelectedItem.ToString.Substring(0, 1) = "S" Then
                style1 = FrmStantPackScanBS.sStyle(0)
                style2 = FrmStantPackScanBS.sStyle(1)
            ElseIf cobReplaceType.SelectedItem.ToString.Substring(0, 1) = "C" Then
                style1 = FrmStantPackScanBS.cStyle(0)
                style2 = FrmStantPackScanBS.cStyle(1)
            Else
                style1 = FrmStantPackScanBS.pStyle(0)
                style2 = FrmStantPackScanBS.pStyle(1)
            End If
        End If
        If style1.Length <> txtOkPPid.Text.Length Then
            MessageBox.Show("条码长度不一致，不允许替换", "警告")
            Exit Sub
        End If
        If TextHandle.verfyBarCodeStyle(style1, txtOkPPid.Text, style2) = False Then
            MessageBox.Show("条码样式不符，不允许替换", "警告")
            Exit Sub
        End If
        Dim sql As String = Nothing
        Try


            If Not cobReplaceType.SelectedItem Is Nothing Then
                Dim cartonsStatus As String = "N"
                Dim cartonId As String = Nothing
                If cobReplaceType.SelectedItem.ToString.Substring(0, 1) = "S" Then
                    sql = "SELECT CARTONID FROM M_CARTONSN_T WHERE PPID='" & txtOkPPid.Text & "'"
                    Using dt As DataTable = Conn.GetDataTable(sql)
                        If dt.Rows.Count > 0 Then
                            MessageBox.Show("该条码已扫在外箱" & dt.Rows(0)(0).ToString & "中不能替换，请确认")
                            Exit Sub
                        End If
                    End Using
                    sql = "SELECT A.CARTONID,B.CARTONSTATUS FROM M_CARTONSN_T A JOIN M_CARTON_T B ON A.CARTONID=B.CARTONID WHERE PPID='" & txtIssuePPid.Text & "'"
                    Using dt As DataTable = Conn.GetDataTable(sql)
                        If dt.Rows.Count <= 0 Then
                            MessageBox.Show("该不良条码未扫描,不能替换,请确认")
                            Exit Sub
                        Else
                            cartonsStatus = dt.Rows(0)("CARTONSTATUS").ToString
                        End If
                    End Using
                    If cartonsStatus <> "Y" Then
                        MessageBox.Show("该不良品对应的外箱{" + cartonId + "}未包装完成，不允许替换")
                        Exit Sub
                    End If
                    sql = "UPDATE M_ASSYSN_T SET PPID='" & txtOkPPid.Text & "' WHERE PPID='" & txtIssuePPid.Text & "'"
                    sql = sql + vbNewLine + "UPDATE M_ASSYSND_T SET PPID='" & txtOkPPid.Text & "' WHERE PPID='" & txtIssuePPid.Text & "'"
                    sql = sql + vbNewLine + "UPDATE M_PPIDLINK_T SET EXPPID='" & txtOkPPid.Text & "',PPID='" & txtOkPPid.Text & "' WHERE EXPPID='" & txtIssuePPid.Text & "'"
                    sql = sql + vbNewLine + "UPDATE M_CARTONSN_T SET PPID='" & txtOkPPid.Text & "' WHERE PPID='" & txtIssuePPid.Text & "'"
                    sql = sql + vbNewLine + "UPDATE M_SNSBARCODE_T SET USEY='S' WHERE SBARCODE='" & txtOkPPid.Text & "'"
                    sql = sql + vbNewLine & "insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,Moid,Userid,Intime)values('" & txtIssuePPid.Text.Trim & "','" & txtOkPPid.Text.Trim & "',N'產品替换','" & SysMessageClass.UseId & "',getdate()" & ")"
                ElseIf cobReplaceType.SelectedItem.ToString.Substring(0, 1) = "C" Then
                    Dim qty As Integer = 0
                    Dim cartonStatus As String = "N"
                    sql = "SELECT CARTONID,CARTONSTATUS,PACKINGQUANTITY FROM M_CARTON_T WHERE CARTONID='" & txtIssuePPid.Text & "'"
                    Using dt As DataTable = Conn.GetDataTable(sql)
                        If dt.Rows.Count > 0 Then
                            qty = CInt(dt.Rows(0)("PACKINGQUANTITY").ToString)
                            cartonStatus = dt.Rows(0)("CARTONSTATUS").ToString
                        Else
                            MessageBox.Show("该不良条码未扫描，请确认")
                            Exit Sub
                        End If
                    End Using
                    If cartonStatus <> "Y" Then
                        MessageBox.Show("该不良条码未包装完成，请包装完成后再替换")
                        Exit Sub
                    End If
                    sql = "SELECT CARTONID FROM M_CARTON_T WHERE CARTONID='" & txtOkPPid.Text & "'"
                    Using dt As DataTable = Conn.GetDataTable(sql)
                        If dt.Rows.Count > 0 Then
                            MessageBox.Show("良品条码已扫描，不允许替换,请确认")
                            Exit Sub
                        End If
                    End Using
                    If cLength > 0 Then
                        Dim qtys As Integer = CInt(txtOkPPid.Text.Substring(cStartIndex - 1, cLength))
                        If qtys <> qty Then
                            MessageBox.Show("不良条码装箱数量{" & qty & "}和良品条码装箱数量{" & qtys & "}不一致，请确认")
                            Exit Sub
                        End If
                    Else
                        If (MessageBox.Show("不良条码装箱数量为{" & qty & "},请确认良品条码装箱数量和不良条码装箱数量一致", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No) Then
                            Exit Sub
                        End If
                    End If
                    sql = "UPDATE M_CARTON_T SET CARTONID='" & txtOkPPid.Text & "' WHERE CARTONID='" & txtIssuePPid.Text & "'"
                    sql = sql + vbNewLine + "UPDATE M_CARTONSN_T SET CARTONID='" & txtOkPPid.Text & "' WHERE CARTONID='" & txtIssuePPid.Text & "'"
                    sql = sql + vbNewLine + "UPDATE M_PALLETCARTON_T SET CARTONID='" & txtOkPPid.Text & "'  WHERE CARTONID='" & txtIssuePPid.Text & "'"
                    sql = sql + vbNewLine + "UPDATE M_SNSBARCODE_T SET USEY='S' WHERE SBARCODE='" & txtOkPPid.Text & "'"
                    sql = sql + vbNewLine & "insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,Moid,Userid,Intime)values('" & txtIssuePPid.Text.Trim & "','" & txtOkPPid.Text.Trim & "',N'小箱袋替换','" & SysMessageClass.UseId & "',getdate()" & ")"
                Else
                    Dim qty As Integer = 0
                    Dim palletStatus As String = "N"
                    sql = "SELECT PALLETID,PALLETSTATUS,MULTIQTY FROM M_PALLETM_T WHERE PALLETID='" & txtIssuePPid.Text & "'"
                    Using dt As DataTable = Conn.GetDataTable(sql)
                        If dt.Rows.Count > 0 Then
                            qty = CInt(dt.Rows(0)("MULTIQTY").ToString)
                            palletStatus = dt.Rows(0)("PALLETSTATUS").ToString
                        Else
                            MessageBox.Show("该不良条码未扫描，请确认")
                            Exit Sub
                        End If
                    End Using
                    If palletStatus <> "Y" Then
                        MessageBox.Show("该不良条码未包装完成，请包装完成后再替换")
                        Exit Sub
                    End If
                    sql = "SELECT PALLETID FROM M_PALLETM_T WHERE PALLETID='" & txtOkPPid.Text & "'"
                    Using dt As DataTable = Conn.GetDataTable(sql)
                        If dt.Rows.Count > 0 Then
                            MessageBox.Show("良品条码已扫描，不允许替换")
                            Exit Sub
                        End If
                    End Using
                    If pLength > 0 Then
                        Dim qtys As Integer = CInt(txtOkPPid.Text.Substring(pStartIndex - 1, pLength))
                        If qtys <> qty Then
                            MessageBox.Show("不良条码装箱数量{" & qty & "}和良品条码装箱数量{" & qtys & "}不一致，请确认")
                            Exit Sub
                        End If
                    Else
                        If (MessageBox.Show("不良条码装箱数量为{" & qty & "},请确认良品条码装箱数量和不良条码装箱数量一致", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No) Then
                            Exit Sub
                        End If
                    End If
                    sql = "UPDATE M_PALLETM_T SET PALLETID='" & txtOkPPid.Text & "' WHERE PALLETID='" & txtIssuePPid.Text & "'"
                    sql = sql + vbNewLine + "UPDATE M_PALLETCARTON_T SET PALLETID='" & txtOkPPid.Text & "'  WHERE PALLETID='" & txtIssuePPid.Text & "'"
                    sql = sql + vbNewLine + "UPDATE M_SNSBARCODE_T SET USEY='S' WHERE SBARCODE='" & txtOkPPid.Text & "'"
                    sql = sql + vbNewLine & "insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,Moid,Userid,Intime)values('" & txtIssuePPid.Text.Trim & "','" & txtOkPPid.Text.Trim & "',N'大箱袋替换','" & SysMessageClass.UseId & "',getdate()" & ")"
                End If
            End If
            If Not String.IsNullOrEmpty(sql) Then
                Conn.ExecSql(sql)
                MessageBox.Show("替换成功")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub TabControl1_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Selecting
        If Not String.IsNullOrEmpty(e.TabPage.Tag) AndAlso Not Convert.ToBoolean(e.TabPage.Tag) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#Region "条码扫描"
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            If String.IsNullOrEmpty(TextBox1.Text) Then
                MessageBox.Show("条码不能为空，请先输入条码")
                Exit Sub
            End If
            Dim style1 As String = Nothing
            Dim style2 As String = Nothing
            Try
                If Not cobScanType.SelectedItem Is Nothing Then
                    GetBarcodeStyle(style1, style2)
                    If cobScanType.SelectedItem.ToString.Substring(0, 1) = "C" Then
                        ScanCarton(style1, style2)
                    Else
                        ScanPallet(style1, style2)
                    End If
                Else
                    MessageBox.Show("请选择扫描类型")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub GetBarcodeStyle(ByRef style1 As String, ByRef style2 As String)
        If Not cobScanType.SelectedItem Is Nothing Then
            If cobScanType.SelectedItem.ToString.Substring(0, 1) = "C" Then
                style1 = FrmStantPackScanBS.cStyle(0)
                style2 = FrmStantPackScanBS.cStyle(1)
            Else
                style1 = FrmStantPackScanBS.pStyle(0)
                style2 = FrmStantPackScanBS.pStyle(1)
            End If
        End If
    End Sub

    Private Sub ScanCarton(ByVal style1 As String, ByVal style2 As String)
        If style1.Length <> TextBox1.Text.Length Then
            'MessageBox.Show("条码长度已当前料号对应箱袋条码长度不一致，不允许扫描", "警告")
            ShowFrmScanErrPrompt("条码长度已当前料号对应箱袋条码长度不一致，不允许扫描", TextBox1.Text)
            lblScanMessage.Text = "条码长度已当前料号对应箱袋条码长度不一致，不允许扫描"
            TextBox1.SelectAll()
            Exit Sub
        End If
        If TextHandle.verfyBarCodeStyle(style1, TextBox1.Text, style2) = False Then
            ' MessageBox.Show("条码样式不符，不允许扫描", "警告")
            ShowFrmScanErrPrompt("条码样式不符，不允许扫描描", TextBox1.Text)
            lblScanMessage.Text = "条码样式不符，不允许扫描"
            TextBox1.SelectAll()
            Exit Sub
        End If
        Dim lsSQL As String = Nothing
        If FrmStantPackScanBS.isCartonSame Then
            Dim GenOuterCartonIDNonInsert As String = Nothing
            lsSQL = String.Format("declare @CurrentCartonID varchar(50) exec m_GetNCartonId_p '{0}',@CurrentCartonID output select @CurrentCartonID ", TextBox1.Text)
            Using o_dt As DataTable = Conn.GetDataTable(lsSQL)
                If o_dt.Rows.Count > 0 Then
                    GenOuterCartonIDNonInsert = CStr(o_dt.Rows(0).Item(0))
                End If
            End Using
            If String.IsNullOrEmpty(GenOuterCartonIDNonInsert) Then
                MessageBox.Show("产生外箱失败")
                lblScanMessage.Text = "产生外箱失败"
                TextBox1.SelectAll()
                Exit Sub
            End If
            TextBox1.Text = GenOuterCartonIDNonInsert
            lsSQL = String.Format("INSERT INTO M_CARTONMANUAL_T(CARTONID,MOID,USERID,INTIME) VALUES('{0}','{1}','{2}',GETDATE())", TextBox1.Text, TextBox2.Text, VbCommClass.VbCommClass.UseId)
        Else
            lsSQL = String.Format("SELECT CARTONID FROM M_CARTONMANUAL_T WHERE CARTONID='{0}'", TextBox1.Text)
            Using o_dt As DataTable = Conn.GetDataTable(lsSQL)
                If o_dt.Rows.Count > 0 Then
                    'MessageBox.Show("该条码已扫描,请勿重复扫描")
                    ShowFrmScanErrPrompt("该条码已扫描,请勿重复扫描", TextBox1.Text)
                    lblScanMessage.Text = "该条码已扫描,请勿重复扫描"
                    TextBox1.SelectAll()
                    Exit Sub
                End If
            End Using
            lsSQL = String.Format("INSERT INTO M_CARTONMANUAL_T(CARTONID,MOID,USERID,INTIME) VALUES('{0}','{1}','{2}',GETDATE())", TextBox1.Text, TextBox2.Text, VbCommClass.VbCommClass.UseId)
        End If
        Conn.ExecSql(lsSQL)
        dgScanResult.Rows.Insert(0, TextBox1.Text)
        lblScanMessage.Text = String.Format("条码 {0} 扫描成功", TextBox1.Text)
        lblTotal.Text = String.Format("共{0}笔", dgScanResult.Rows.Count)
        TextBox1.Clear()
    End Sub

    Private Sub ScanPallet(ByVal style1 As String, ByVal style2 As String)
        If style1.Length <> TextBox1.Text.Length Then
            'MessageBox.Show("条码长度已当前料号对应箱袋条码长度不一致，不允许扫描", "警告")
            ShowFrmScanErrPrompt("条码长度已当前料号对应箱袋条码长度不一致，不允许扫", TextBox1.Text)
            lblScanMessage.Text = "条码长度已当前料号对应箱袋条码长度不一致，不允许扫描"
            Exit Sub
        End If
        If TextHandle.verfyBarCodeStyle(style1, TextBox1.Text, style2) = False Then
            'MessageBox.Show("条码样式不符，不允许扫描", "警告")
            ShowFrmScanErrPrompt("条码样式不符，不允许扫描", TextBox1.Text)
            lblScanMessage.Text = "条码样式不符，不允许扫描"
            Exit Sub
        End If
        Dim lsSQL As String = Nothing
        If FrmStantPackScanBS.isPalletSame Then
            Dim GenOuterCartonIDNonInsert As String = Nothing
            lsSQL = String.Format("declare @CurrentCartonID varchar(50) exec m_GetNPalletId_p '{0}',@CurrentCartonID output select @CurrentCartonID ", TextBox1.Text)
            Using o_dt As DataTable = Conn.GetDataTable(lsSQL)
                If o_dt.Rows.Count > 0 Then
                    GenOuterCartonIDNonInsert = CStr(o_dt.Rows(0).Item(0))
                End If
            End Using
            If String.IsNullOrEmpty(GenOuterCartonIDNonInsert) Then
                MessageBox.Show("产生外箱失败")
                lblScanMessage.Text = "产生外箱失败"
                Exit Sub
            End If
            TextBox1.Text = GenOuterCartonIDNonInsert
            lsSQL = String.Format("INSERT INTO M_PALLETMANUAL_T(PALLETID,MOID,USERID,INTIME) VALUES('{0}','{1}','{2}',GETDATE())", TextBox1.Text, TextBox2.Text, VbCommClass.VbCommClass.UseId)
        Else
            lsSQL = String.Format("SELECT PALLETID FROM M_PALLETMANUAL_T WHERE PALLETID='{0}'", TextBox1.Text)
            Using o_dt As DataTable = Conn.GetDataTable(lsSQL)
                If o_dt.Rows.Count > 0 Then
                    'MessageBox.Show("该条码已扫描,请勿重复扫描")
                    ShowFrmScanErrPrompt("该条码已扫描,请勿重复扫描", TextBox1.Text)
                    lblScanMessage.Text = "该条码已扫描,请勿重复扫描"
                    Exit Sub
                End If
            End Using
            lsSQL = String.Format("INSERT INTO M_PALLETMANUAL_T(PALLETID,MOID,USERID,INTIME) VALUES('{0}','{1}','{2}',GETDATE())", TextBox1.Text, TextBox2.Text, VbCommClass.VbCommClass.UseId)
        End If
        Conn.ExecSql(lsSQL)
        dgScanResult.Rows.Insert(0, TextBox1.Text)
        lblScanMessage.Text = String.Format("条码 {0} 扫描成功", TextBox1.Text)
        lblTotal.Text = String.Format("共{0}笔", dgScanResult.Rows.Count)
        TextBox1.Clear()
    End Sub

    Private Sub GetScanResult()
        Dim sql As String = Nothing
        If cobScanType.SelectedItem.ToString.Substring(0, 1) = "C" Then
            sql = String.Format("SELECT CARTONID FROM M_CARTONMANUAL_T WHERE MOID='{0}'", TextBox2.Text)
        Else
            sql = String.Format("SELECT PALLETID FROM M_PALLETMANUAL_T WHERE MOID='{0}'", TextBox2.Text)
        End If
        dgScanResult.Rows.Clear()
        Using o_dt As DataTable = Conn.GetDataTable(sql)
            For Each dr As DataRow In o_dt.Rows
                dgScanResult.Rows.Insert(0, dr(0).ToString())
            Next
        End Using
        lblTotal.Text = String.Format("共{0}笔", dgScanResult.Rows.Count)
    End Sub

    Private Sub cobScanType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cobScanType.SelectedIndexChanged
        Try
            If Not cobScanType.SelectedItem Is Nothing Then
                If cobScanType.SelectedItem.ToString.Substring(0, 1) = "C" Then
                    lblStyle1.Text = FrmStantPackScanBS.cStyle(0)
                    lblStyle2.Text = FrmStantPackScanBS.cStyle(1)
                Else
                    lblStyle1.Text = FrmStantPackScanBS.pStyle(0)
                    lblStyle2.Text = FrmStantPackScanBS.pStyle(1)
                End If
                GetScanResult()
            Else
                lblStyle1.Text = ""
                lblStyle2.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try      
    End Sub

    Private Sub ShowFrmScanErrPrompt(ByVal message As String, ByVal barcode As String)
        WorkStantOption.ErrorStr = message '"條碼不符合標準樣式"
        'SetMessage("FAIL", "條碼不符合標準樣式")
        'PlaySimpleSound(1)
        WorkStantOption.BarCodeStr = barcode
        WorkStantOption.vMainBarCode = barcode
        Using FrmError As New FrmScanErrPrompt
            FrmError.ShowDialog()
        End Using
    End Sub

#End Region
End Class






