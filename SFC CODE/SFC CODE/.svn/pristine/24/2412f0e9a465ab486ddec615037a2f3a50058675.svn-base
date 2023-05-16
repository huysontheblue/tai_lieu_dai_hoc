
'--PLM BOM查询
'--Create by :　马锋
'--Create date :　2016/01/29
'--Ver : V01
'--Update date :  
'--

#Region "名称空间"

Imports System.ComponentModel
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports DevComponents.DotNetBar
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports LXWarehouseManage
Imports luxshare.RouteDesign

#End Region

Public Class FrmWorkflowMaster

    Dim routeDesign As RouteDesign

#Region "加载事件"

    Private Sub FrmWorkflowMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

#End Region


#Region "菜单事件"

    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click

    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click

    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click

    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click

    End Sub

    Private Sub toolComfire_Click(sender As Object, e As EventArgs) Handles toolComfire.Click

    End Sub

    Private Sub toolRecovery_Click(sender As Object, e As EventArgs) Handles toolRecovery.Click

    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub trvData_DrawNode(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawTreeNodeEventArgs) Handles trvData.DrawNode
        If ((e.State And TreeNodeStates.Selected) <> 0) Then
            Dim aa As New SolidBrush(Color.FromArgb(2, 165, 222))
            e.Graphics.FillRectangle(aa, NodeBounds(e.Node))
            Dim nodeFont As Font = e.Node.NodeFont
            If (nodeFont Is Nothing) Then
                nodeFont = (CType(sender, TreeView)).Font
            End If
            e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, e.Bounds.Left - 2, e.Bounds.Top)
        Else
            e.DrawDefault = True
        End If
        If ((e.Node.Tag IsNot Nothing)) Then
            e.Graphics.DrawString(e.Node.Tag.ToString(), New Font("宋体", 10, FontStyle.Regular), Brushes.Yellow, e.Bounds.Right + 2, e.Bounds.Top)
        End If
        If ((e.State & TreeNodeStates.Focused) <> 0) Then
            Dim focusPen As New Pen(Color.Black)
            focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Dim focusBounds As Rectangle = NodeBounds(e.Node)
            focusBounds.Size = New Size(focusBounds.Width - 1, focusBounds.Height - 1)
            e.Graphics.DrawRectangle(focusPen, focusBounds)
        End If
    End Sub

    Private Function NodeBounds(ByVal node As System.Windows.Forms.TreeNode) As Rectangle
        If node IsNot Nothing Then
            Dim bounds As Rectangle = node.Bounds
            If node.Tag IsNot Nothing Then
                Dim g As Graphics = trvData.CreateGraphics()
                Dim tagWidth As Integer = CType(g.MeasureString(node.Tag.ToString(), New Font("宋体", 10, FontStyle.Regular)).Width + 6, Integer)
                bounds.Offset(tagWidth * 2, 0)
                bounds = Rectangle.Inflate(bounds, tagWidth * 2, 0)
            End If
            Return bounds
        End If
    End Function

    Private Sub trvData_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trvData.MouseDown
        Dim clickedNode As TreeNode = trvData.GetNodeAt(e.X, e.Y)
        If (NodeBounds(clickedNode).Contains(e.X, e.Y)) Then
            trvData.SelectedNode = clickedNode
        End If
    End Sub

    Private Sub trvData_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvData.AfterSelect
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim Dtable As New DataTable
        'Dim SqlStr As String
        'Dim CurrSta As Int16 = 0
        'Dim CurrScan As Int16 = 0
        'Me.CobCScanId.Items.Clear()
        'Me.CobCStation.Items.Clear()
        'If Me.trvData.Nodes.Count = 0 OrElse Me.trvData.SelectedNode Is Nothing Then Exit Sub
        'RadNmerger.Checked = True
        'If e.Node.Level = 0 Then
        '    CurrSta = 0
        '    CurrScan = 0
        'ElseIf e.Node.Level = 1 Then
        '    CurrSta = e.Node.Tag.ToString.Trim
        '    CurrScan = 1
        'ElseIf e.Node.Level = 2 Then
        '    CurrSta = e.Node.Tag.ToString.Trim.Split("-")(0)
        '    CurrScan = e.Node.Tag.ToString.Trim.Split("-")(1)
        'End If

        'SqlStr = " SELECT c.SortName as Stationtype,a.Stationid,b.StationName,a.TPartid,a.TPartText,a.IsReplaceable,a.ReplaceID," _
        '       & " a.IsPrtSelf, a.IsAllowRe,a.IsScanPallet,a.IsCustPart,a.IsCheckTestY,a.TestTypeID,a.IsPrtPacking,a.IsOnlineGenCartonID, a.IsShowPacking,a.isendsta,a.Cmby,a.ShowColPos,a.IsUpDown,a.isSplit,a.SplitQty," _
        '       & " a.IsRelated,ContY,ASNY,LinePrtY,Ismatch,SplitBegin,SplitEnd,CheckSupY,CheckStaorder,CheckScanorder,IslineMbarcode,IsAllowNG," _
        '       & " IsAllowNGQty,NGqtySC,NGqtycount,IsUsb,isnull(IsPackingSame,'N') IsPackingSame,isnull(IsReadPCB,'N') IsReadPCB,isnull(IsWritePCB,'N') IsWritePCB,isnull(IsPalletSame,'') IsPalletSame, isnull(IsPackType,'N') as IsPackType,ISNULL(IsCartonSame,'N') AS IsCartonSame, ISNULL(IsSamePacking,'N') AS IsSamePacking, isnull(IsPPackingProduct,'N') as IsPPackingProduct,isnull(IsCheckMoForCarton,'Y') as IsCheckMo,isnull(IsAssemblySN,'N') as IsAssemblySN, isnull(IsSSCC, 'N') as IsSSCC, CodeRuleID " _
        '       & " from dbo.m_RPartStationD_t as a  " _
        '       & " left join m_Rstation_t b on a.Stationid = b.Stationid " _
        '       & " left join m_Sortset_t c on b.Stationtype=c.SortID and c.SortType='StationType' " _
        '       & " where a.PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' " _
        '       & "       and a.Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim _
        '       & "       and a.StaOrderid=case " & e.Node.Level & " when 0 then 1 when 1 then " & CurrSta & " when 2 then " & CurrSta & " end " _
        '       & "       and a.ScanOrderid=case " & e.Node.Level & " when 0 then 1 when 1 then 1 when 2 then " & CurrScan & " end "
        'Dtable = Conn.GetDataTable(SqlStr)
        'ClearObj()  '清空控件
        'If Dtable.Rows.Count = 0 Then
        '    '按鈕權限控制
        '    If opFlag <> 0 Then
        '        Me.btnDel.Enabled = False
        '        Me.btnDown.Enabled = False
        '        Me.btnUp.Enabled = False
        '        Me.btnSave.Enabled = True
        '        Me.BnSelectSta.Enabled = True
        '        Me.txtTPartid.Enabled = True
        '        Me.txtTPartText.Enabled = True
        '        Me.TxtTpartT.Enabled = True
        '        Me.btnAdd.Enabled = True
        '        Me.btnClearpart.Enabled = True

        '        If e.Node.Level = 0 Then  '根節點,ContY,ASNY,LinePrtY
        '            Me.txtTPartid.Text = Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        '            Me.txtTPartText.Text = "主條碼"
        '            Me.txtTPartid.Enabled = False
        '            'Me.txtTPartText.Enabled = False
        '            Me.TxtTpartT.Enabled = False
        '            Me.btnAdd.Enabled = False
        '            Me.btnClearpart.Enabled = False
        '        End If
        '    End If
        'Else
        '    Me.txtStationid.Text = IIf(e.Node.Level = 0, "", Dtable.Rows(0)("Stationid").ToString.Trim)
        '    Me.txtStationName.Text = IIf(e.Node.Level = 0, "", Dtable.Rows(0)("StationName").ToString.Trim)
        '    Me.txtStationtype.Text = IIf(e.Node.Level = 0, "", Dtable.Rows(0)("Stationtype").ToString.Trim)
        '    Me.txtTPartid.Text = IIf(e.Node.Level = 1, "", Dtable.Rows(0)("TPartid").ToString.Trim)
        '    Me.txtTPartText.Text = IIf(e.Node.Level = 1, "", Dtable.Rows(0)("TPartText").ToString.Trim)
        '    Me.ckbIsAllowRe.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsAllowRe").ToString.Trim = "Y", True, False)
        '    Me.ChbCustPart.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsCustPart").ToString.Trim = "Y", True, False)
        '    Me.ChkScanPallet.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsScanPallet").ToString.Trim = "Y", True, False)
        '    Me.ckbIsPrtSelf.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPrtSelf").ToString.Trim = "Y", True, False)
        '    Me.ChkIsPrtPacking.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPrtPacking").ToString.Trim = "Y", True, False)
        '    Me.chkIsOnlineGenCartonID.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsOnlineGenCartonID").ToString.Trim = "Y", True, False)
        '    Me.ckbIsShowPacking.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsShowPacking").ToString.Trim = "Y", True, False)
        '    Me.RadNmerger.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("Cmby").ToString.Trim = "0", True, False)
        '    Me.RadQmerger.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("Cmby").ToString.Trim = "1", True, False)
        '    Me.RadHmerger.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("Cmby").ToString.Trim = "2", True, False)
        '    Me.ckbIsUpMaterial.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsUpDown").ToString.Trim = "Y", True, False)
        '    Me.Checktime.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("isendsta").ToString.Trim = "Y", True, False)
        '    Me.ckbIsCheckTestY.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsCheckTestY").ToString.Trim = "Y", True, False)
        '    If Me.ckbIsCheckTestY.Checked Then
        '        Me.ChbTestNum.SelectedIndex = IIf(e.Node.Level <> 1, Dtable.Rows(0)("TestTypeID").ToString.Trim.Split(";").Length() - 1, -1)
        '    End If
        '    Me.CboShowP.SelectedIndex = IIf(Me.ckbIsShowPacking.Checked = False, -1, Me.CboShowP.FindStringExact(Dtable.Rows(0)("ShowColPos").ToString.Trim))
        '    Me.CboShowP.Enabled = Me.ckbIsShowPacking.Checked
        '    Me.cboPack.SelectedIndex = Me.cboPack.FindString(Dtable.Rows(0)("CodeRuleID").ToString)
        '    'Me.LblSupplier.Text = Dtable.Rows(0)("Supplierid").ToString

        '    Me.ChkIsContinual.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("ContY").ToString.Trim = "Y", True, False)
        '    Me.ChkASN.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("ASNY").ToString.Trim = "Y", True, False)
        '    Me.ChkTTprint.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("LinePrtY").ToString.Trim = "Y", True, False)
        '    Me.ChkTTprint.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("LinePrtY").ToString.Trim = "Y", True, False)
        '    'isnull(IsPackingSame,'N') IsPackingSame,isnull(IsReadPCB,'N') IsReadPCB,isnull(IsWritePCB,'N') IsReadPCB,isnull(IsPalletSame,'') IsPalletSame
        '    Me.ChkCartonSame.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsCartonSame").ToString.Trim = "Y", True, False)
        '    Me.ChkReadPCB.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsReadPCB").ToString.Trim = "Y", True, False)
        '    Me.ChkWritePCB.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsWritePCB").ToString.Trim = "Y", True, False)
        '    Me.ChkPalletSame.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPalletSame").ToString.Trim = "Y", True, False)
        '    'add by paul 20141110
        '    'for checking the mo(scaned sn) is the same as the system setup
        '    Me.ChkMo.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsCheckMo").ToString.Trim = "Y", True, False)


        '    Me.ChkPackingType.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPackType").ToString.Trim = "Y", True, False)
        '    Me.ChkSamePacking.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsSamePacking").ToString.Trim = "Y", True, False)
        '    'added by paul 20150310 是否为制程条码
        '    Me.ChkAssemblySN.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsAssemblySN").ToString.Trim = "Y", True, False)

        '    Me.chkParitySSCC.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsSSCC").ToString.Trim = "Y", True, False)

        '    Me.Chkmatch.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("Ismatch").ToString.Trim = "Y", True, False)
        '    Me.TxtSpiltBegin.Text = Dtable.Rows(0)("splitbegin").ToString
        '    Me.TxtSpiltEnd.Text = Dtable.Rows(0)("splitend").ToString

        '    Me.ChkSupplier.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("CheckSupY").ToString.Trim = "Y", True, False)
        '    Me.CobCStation.Text = Dtable.Rows(0)("CheckStaorder").ToString
        '    Me.CobCScanId.Text = Dtable.Rows(0)("CheckScanorder").ToString

        '    If e.Node.Level <> 1 And Dtable.Rows.Count Then
        '        'Me.TxtSplitQty.Text = Dtable.Rows(0)("SplitQty").ToString.Trim
        '        Me.TxtSplitQty.Checked = IIf(Dtable.Rows(0)("SplitQty").ToString = "Y", True, False)
        '    End If
        '    Me.ChkRelate.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsRelated").ToString.Trim = "Y", True, False)
        '    ChkLinePinrtM.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IslineMbarcode").ToString.Trim = "Y", True, False) ''在线打印主条码
        '    ChkUsb.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsUsb").ToString.Trim = "Y", True, False) ''读取USB序号
        '    CheckNcount.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsAllowNG").ToString.Trim = "Y", True, False) ''允许发生不良的次数
        '    TxtNGcount.Text = Dtable.Rows(0)("IsAllowNGQty").ToString.Trim ''允许次数
        '    ChkClaQty.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("NGqtySC").ToString.Trim = "Y", True, False) ''时间内不良达到数量时预警
        '    TxtClaQty.Text = Dtable.Rows(0)("NGqtycount").ToString.Trim ''多少个不良预警
        '    'Me.RadNmerger.Checked = IIf(e.Node.Level = 1 AndAlso Dtable.Rows(0)("Cmby").ToString.Trim = "0", True, False)Ismatch

        '    If RadQmerger.Checked = False AndAlso RadHmerger.Checked = False Then
        '        RadNmerger.Checked = True
        '    End If
        '    '' Me.CboTestType.SelectedIndex = IIf(Me.ckbIsCheckTestY.Checked = False, -1, Me.CboTestType.FindString(Dtable.Rows(0)("TestType").ToString.Trim))
        '    ''Me.CboTestType.Enabled = Me.ckbIsCheckTestY.Checked
        '    '按鈕權限控制
        '    If opFlag <> 0 Then
        '        If e.Node.Level = 0 Then '根節點
        '            Me.btnDel.Enabled = False
        '            Me.btnDown.Enabled = False
        '            Me.btnUp.Enabled = False
        '            Me.btnSave.Enabled = True
        '            Me.BnSelectSta.Enabled = True
        '            Me.btnAdd.Enabled = False
        '            Me.btnClearpart.Enabled = False
        '            Me.TxtTpartT.Enabled = False
        '            Me.txtTPartid.Enabled = False
        '            Me.txtTPartText.Enabled = False
        '        Else  '工站節點和掃描條碼節點
        '            Me.btnDel.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
        '            Me.btnDown.Enabled = IIf(e.Node.NextNode Is Nothing OrElse (e.Node.Level = 2 AndAlso CurrScan = "1"), False, True)
        '            Me.btnUp.Enabled = IIf(e.Node.PrevNode Is Nothing OrElse (e.Node.Level = 2 AndAlso CurrScan < "3"), False, True)
        '            Me.btnAdd.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
        '            Me.btnClearpart.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
        '            Me.btnSave.Enabled = True
        '            Me.BnSelectSta.Enabled = False
        '            Me.txtTPartid.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
        '            'Me.txtTPartText.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
        '            'Modified by Aimee 20150312, enable to change PN Des(CurrScan = "1", 可能是制程条码也可能是成品条码)
        '            Me.txtTPartText.Enabled = True
        '            Me.TxtTpartT.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
        '        End If
        '    End If
        '    '刷出部件料號的替代料
        '    If Dtable.Rows(0)("IsReplaceable").ToString.Trim = "Y" Then
        '        SqlStr = "select itemid,TPartid from m_RPartStationT_t where ReplaceID='" & Dtable.Rows(0)("ReplaceID").ToString.Trim & "' order by itemid"
        '        Dtable = Conn.GetDataTable(SqlStr)
        '        For i As Integer = 0 To Dtable.Rows.Count - 1
        '            Me.LstPartSum.Items.Add(Dtable.Rows(i)(1).ToString.Trim)
        '        Next
        '    End If
        'End If
        'Conn = Nothing
    End Sub


    Private Sub LblQuery_Click(sender As Object, e As EventArgs) Handles LblQuery.Click

    End Sub

    Private Sub LblUp_Click(sender As Object, e As EventArgs) Handles LblUp.Click

    End Sub

    Private Sub LblDown_Click(sender As Object, e As EventArgs) Handles LblDown.Click

    End Sub

    Private Sub LblSave_Click(sender As Object, e As EventArgs) Handles LblSave.Click

    End Sub

    Private Sub LblDelete_Click(sender As Object, e As EventArgs) Handles LblDelete.Click

    End Sub

    Private Sub pbDesign_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbDesign.Paint
        Try
            routeDesign.RouteDesignPaint(e)
        Catch ex As Exception

        End Try
    End Sub




#End Region


End Class