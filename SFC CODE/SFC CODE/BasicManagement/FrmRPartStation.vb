
''***************************************************

#Region "窗體引用"

Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports luxshare.RouteDesign
Imports MainFrame

#End Region

Public Class FrmRPartStation

#Region "窗體共有變量"

    Dim opFlag As Int16 = 0   '狀態變更控制變量
    Dim FileNameStr As String = ""
    ' Dim routeDesign As RouteDesign
    ' Dim routeDesign As FlowChart

    Public result As String
    Public newPartIdm As String  '复制料号的新料号
    Public m_strCurrVer As String
    Public m_strCurrPartID As String
#End Region

#Region "窗體加載"

    Private Sub FrmRPartStation_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyValue
            Case 37
                '左方向鍵 
                SendKeys.Send("+{Tab}")  '按Shift + Tab 組合鍵 
            Case 13
                SendKeys.Send("{Tab}")
            Case 38 '上方向鍵 
            Case 39 '右方向鍵 
                'SendKeys.Send("{Tab}")
            Case 40  '下方向鍵 
                'SendKeys.Send("{Tab}")
        End Select
    End Sub
    '窗體加載
    Private Sub FrmRPartStation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.DesignMode = True Then Exit Sub

        Erightbutton() '讀取按鈕權限
        FillListCheckBoxList(ChkListBox, "select id,RuleName from m_RPartStationRules_t where Ruleusey='Y' order by RuleOrderby desc", "id", "RuleName")
        opFlag = 0
        SetState(opFlag) '設置初始狀態
        '  TabControl1.Enabled = True
        '  routeDesign = New RouteDesign()
    End Sub

    Private Sub SetComBox()
        Dim strSQL As String =
            " SELECT CodeRuleID, CONVERT(VARCHAR,PackItem) + '/' + Packid + '/' + CodeRuleID AS CodeRuleName FROM m_PartPack_t " &
            " WHERE PackId <> 'A' AND PackId <> 'S' AND PackId <> 'P' AND ISNULL(DisorderTypeId,'') <> 'S' AND USEY='Y' AND Partid='" & Me.txtTPartid.Text.Trim & "'"

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Dim dr As DataRow = dt.NewRow

        dr("CodeRuleID") = ""
        dr("CodeRuleName") = ""
        dt.Rows.InsertAt(dr, 0)

        Me.cboPack.DisplayMember = "CodeRuleName"
        Me.cboPack.ValueMember = "CodeRuleID"
        Me.cboPack.DataSource = dt

        Me.cboPack2.DisplayMember = "CodeRuleName"
        Me.cboPack2.ValueMember = "CodeRuleID"
        Me.cboPack2.DataSource = dt.Copy

        Me.cboWorkCodeRuleId.DisplayMember = "CodeRuleName"
        Me.cboWorkCodeRuleId.ValueMember = "CodeRuleID"
        Me.cboWorkCodeRuleId.DataSource = dt.Copy
    End Sub

    '增加设置以前选中的数据
    Private Sub SetCheckBoxSelected(ByVal Partid As String, ByVal Rev As Integer)
        Dim strSQL As String = "select RuleId from m_RPartStationCheckRule_t where Ppartid = '{0}'  and Revid = '{1}'"
        strSQL = String.Format(strSQL, Partid, Rev)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Dim RuleId As String
        Dim dbRuleId As String

        '移除已经选择的
        For k As Integer = 0 To ChkListBox.Items.Count - 1
            ChkListBox.SetItemChecked(k, False)
        Next

        For icnt As Integer = 0 To dt.Rows.Count - 1
            dbRuleId = dt.Rows(icnt)(0).ToString
            ''If ChkListBox.row.Count = 0 Then Exit Sub
            For k As Integer = 0 To ChkListBox.Items.Count - 1
                RuleId = CType(ChkListBox.Items(k), DataRowView).Row(0).ToString
                If RuleId = dbRuleId Then
                    ChkListBox.SetItemChecked(k, True)
                    Continue For
                End If
            Next
        Next

    End Sub

    '按鈕權限判斷
    Private Sub Erightbutton()
        Dim dt As DataTable = DbOperateUtils.GetDataTable("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02002' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        Dim Obj As Object
        For index As Integer = 0 To dt.Rows.Count - 1
            '通過控件名稱得到控件實例
            Obj = CType(Me.GetType().GetField("_" & dt.Rows(index)("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
            Obj.Tag = "Yes"
        Next



    End Sub
    '按鈕狀態設置
    Private Sub SetState(ByVal flag As Integer)
        Select Case flag
            Case 0 '初始查詢狀態
                Me.toolNew.Enabled = IIf(Me.toolNew.Tag.ToString <> "Yes", False, True)
                Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                Me.toolAbandon.Enabled = IIf(Me.toolAbandon.Tag.ToString <> "Yes", False, True)
                Me.toolComfire.Enabled = IIf(Me.toolComfire.Tag.ToString <> "Yes", False, True)
                Me.toolRecovery.Enabled = IIf(Me.toolRecovery.Tag.ToString <> "Yes", False, True)
                Me.toolRules.Enabled = IIf(Me.toolRules.Tag.ToString <> "Yes", False, True)
                Me.toolBack.Enabled = False

                If Not IsNothing(Me.btnModifyCode.Tag) Then
                    Me.btnModifyCode.Enabled = IIf(Me.btnModifyCode.Tag.ToString <> "Yes", False, True)
                Else
                     Me.btnModifyCode.Enabled  =False
                End If
                'Me.toolExport.Enabled = True

                Me.BnQuery.Text = "查 詢"
                'Me.BnQuery.Image = My.Resources.查詢

                Me.SplitContainer3.Panel1.Enabled = True
                Me.SplitContainer3.Panel2.Enabled = True
                Me.TabControlPanel1.Enabled = False
                Me.TabControlPanel2.Enabled = False
                Me.TabControlPanel3.Enabled = False
                Me.ActiveControl = Me.txtPartid
                LblDelete.Enabled = False
                LblDown.Enabled = False
                LblSave.Enabled = False
                LblUp.Enabled = False
                btnSaveNgBackStation.Enabled = False
                'Me.TabControl1.Enabled = true

            Case 1, 2 '新增/修改狀態
                Me.toolNew.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolComfire.Enabled = False
                Me.toolBack.Enabled = True
                'Me.toolExport.Enabled = False

                Me.BnQuery.Text = IIf(opFlag = 1, "保 存", "查 詢")
                'Me.BnQuery.Image = IIf(opFlag = 1, My.Resources.保存, My.Resources.查詢)

                Me.SplitContainer3.Panel1.Enabled = IIf(opFlag = 1, True, False)
                Me.SplitContainer3.Panel2.Enabled = False
                'Me.SplitContainer6.Enabled = True
                Me.SplitContainer6.Enabled = True
                Me.TabControlPanel1.Enabled = True
                Me.TabControlPanel2.Enabled = True
                Me.TabControlPanel3.Enabled = True
                Me.ActiveControl = IIf(opFlag = 1, Me.txtPartid, Me.trvData)
                LblDelete.Enabled = True
                LblDown.Enabled = True
                LblSave.Enabled = True
                LblUp.Enabled = True
                LblQuery.Enabled = True
                btnSaveNgBackStation.Enabled = True
        End Select

    End Sub
    '清空控件內容
    Private Sub ClearObj()
        Me.txtStationid.Text = ""
        Me.txtStationName.Text = ""
        Me.txtStationtype.Text = ""
        Me.txtTPartid.Text = ""
        Me.txtTPartText.Text = ""
        Me.TxtTpartT.Text = ""
        Me.LstPartSum.Items.Clear()
        Me.ckbIsAllowRe.Checked = False
        Me.ChbCustPart.Checked = False
        Me.ChkScanPallet.Checked = False
        Me.ckbIsPrtSelf.Checked = False
        Me.ckbIsShowPacking.Checked = False
        Me.ckbIsCheckTestY.Checked = False
        Me.ChbTestNum.Text = ""
        Me.ChkSplit.Checked = False
        'Me.TxtSplitQty.Text = ""
        Me.TxtSplitQty.Checked = False
        Me.ChkRelate.Checked = False
        Me.CboTestType.Text = ""
        Me.CboTestType.Enabled = False
        Me.CboShowP.Text = ""
        Me.CboShowP.Enabled = False
        Me.chkIsScanN.Checked = False
        Me.Checktime.Enabled = True
        Me.chkQCPlan.Enabled = True

    End Sub

    Private Sub FillListCheckBoxList(ByVal ComControl As CheckedListBox, ByVal SqlStr As String, ByVal ValleField As String, ByVal TextField As String)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
        'Dim dr As DataRow = dt.NewRow
        'dr(ValleField) = ""
        'dr(TextField) = ""
        'dt.Rows.InsertAt(dr, 0)
        ComControl.DataSource = dt.DefaultView
        ComControl.ValueMember = ValleField
        ComControl.DisplayMember = TextField
    End Sub
#End Region

#Region "數據表控件顯示風格設置"
    ' 繪製被選取之節點的背景色與節點文字 
    Private Sub trvData_DrawNode(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawTreeNodeEventArgs) Handles trvData.DrawNode
        ' 繪製被選取之節點的背景色與節點文字。 
        If ((e.State And TreeNodeStates.Selected) <> 0) Then
            Dim aa As New SolidBrush(Color.FromArgb(2, 165, 222))
            e.Graphics.FillRectangle(aa, NodeBounds(e.Node))
            '2, 165, 222
            ' 提取節點字型。如果節點字型未被設定， 
            ' 就使用TreeView的字型。 
            Dim nodeFont As Font = e.Node.NodeFont
            If (nodeFont Is Nothing) Then
                nodeFont = (CType(sender, TreeView)).Font
            End If
            ' 繪製節點文字。 //繪制節點文字   
            e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, e.Bounds.Left - 2, e.Bounds.Top)
        Else
            e.DrawDefault = True
        End If
        ' 如果存在節點標記，就將它繪製在節點標籤的右側。 
        If ((e.Node.Tag IsNot Nothing)) Then
            e.Graphics.DrawString(e.Node.Tag.ToString(), New Font("宋体", 10, FontStyle.Regular), Brushes.Yellow, e.Bounds.Right + 2, e.Bounds.Top)
        End If
        ' 如果節點擁有焦點，便將焦點矩形繪製得夠大。
        ' 以便能夠容納節點標籤文字。 
        If ((e.State & TreeNodeStates.Focused) <> 0) Then
            Dim focusPen As New Pen(Color.Black)
            focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
            Dim focusBounds As Rectangle = NodeBounds(e.Node)
            focusBounds.Size = New Size(focusBounds.Width - 1, focusBounds.Height - 1)
            e.Graphics.DrawRectangle(focusPen, focusBounds)
        End If
        ' 繪製被選取之節點的背景色。如果該節點擁有標記文字 
        ' 「低於安全庫存，請盡快補貨。」的話，NodeBounds方法 
        ' 會使得醒目提示區域擁有足夠的大小來容納它。
    End Sub
    ' 將傳回值設定成正常的節點邊界範圍
    Private Function NodeBounds(ByVal node As System.Windows.Forms.TreeNode) As Rectangle
        If node IsNot Nothing Then
            ' 將傳回值設定成正常的節點邊界範圍。 
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

    'Private Sub DataGridView_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvSun.RowPrePaint, dgvMain.RowPrePaint
    '    e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts
    'End Sub

    Private Sub trvData_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trvData.MouseDown
        Dim clickedNode As TreeNode = trvData.GetNodeAt(e.X, e.Y)
        If (NodeBounds(clickedNode).Contains(e.X, e.Y)) Then
            trvData.SelectedNode = clickedNode
        End If
    End Sub

#End Region

#Region "根據查詢結果加載數據"
    '查詢后得到的初始數據
    Private Sub LoadDataTodgvMain(ByVal Partid As String)

        '田玉琳 20200521 修改到存储过程中执行
        Dim SqlStr As String = "exec GetFindPartSql '{0}','{1}'"
        SqlStr = String.Format(SqlStr, Partid, VbCommClass.VbCommClass.Factory)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)

        Me.dgvMain.Rows.Clear()
        Me.dgvSun.Rows.Clear()
        Me.trvData.Nodes.Clear()
        Me.dgvNGCode.Rows.Clear()
        For index As Integer = 0 To dt.Rows.Count - 1
            dgvMain.Rows.Add(dt.Rows(index)("PPartid").ToString, dt.Rows(index)("PartName").ToString, dt.Rows(index)("Revid").ToString, _
                      dt.Rows(index)("State").ToString, dt.Rows(index)("UserID").ToString, dt.Rows(index)("Intime").ToString, _
                      dt.Rows(index)("Comfireuser").ToString, dt.Rows(index)("Comfiretime").ToString, _
                      dt.Rows(index)("Canceluser").ToString, dt.Rows(index)("Canceltime").ToString)
        Next

        If Me.dgvMain.Rows.Count = 0 AndAlso Me.dgvMain.CurrentRow Is Nothing Then Exit Sub
        Dim partidr As String = Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        Dim revId As String = Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        LoadDataToTreeView(partidr, revId) 'TreeView數據綁定
        LoadDataTodgvSun(partidr, revId) 'dgvSun數據綁定
        LoadDataTodgvNGCode(partidr, revId)
        LoadRouteView(Partid, revId)

    End Sub

    Public Shared Function GetPartFatory() As String
        Dim strValue As String = " AND (factory='" & VbCommClass.VbCommClass.Factory & "' or factory = '') "

        Return strValue
    End Function

    '加載treeview數據
    Private Sub LoadDataToTreeView(ByVal Partid As String, ByVal Rev As Integer)
        Dim dtable As New DataTable
        Dim dStaView As New DataView
        Dim dScanView As New DataView
        Dim node As TreeNode
        Dim SqlStr As String

        trvData.Nodes.Clear()
        '加載根節點ddd
        node = New TreeNode("成品料号：" & Partid)
        node.ImageIndex = 3
        node.Tag = "0"
        '加載明細子節點
        SqlStr = " select a.StaOrderid,a.Stationid,b.StationName,'' as ScanOrderid,'' as TPartid,'' as TPartText,'1' as Dtype,isnull(ScanY,'Y') as ScanY " _
               & " from m_RPartStationD_t a left join m_Rstation_t b on a.Stationid = b.Stationid " _
               & " where a.PPartid='" & Partid & "' and a.Revid =" & Rev _
               & " union " _
               & " select a.StaOrderid,a.Stationid,b.StationName,a.ScanOrderid,a.TPartid,a.TPartText,'2' as Dtype,isnull(ScanY,'Y') as ScanY " _
               & " from m_RPartStationD_t a left join m_Rstation_t b on a.Stationid = b.Stationid " _
               & " where a.PPartid='" & Partid & "' and a.Revid =" & Rev
        dtable = DbOperateUtils.GetDataTable(SqlStr)
        dStaView = New DataView(dtable)
        dScanView = New DataView(dtable)
        If dtable.Rows.Count <> 0 Then
            dStaView.RowFilter = "Dtype='1'"
            dStaView.Sort = "StaOrderid ASC"
            For i As Int16 = 0 To dStaView.Count - 1
                Dim node1 As TreeNode = New TreeNode(dStaView.Item(i)(0).ToString.Trim & ". " & dStaView.Item(i)(1).ToString.Trim & "-" & dStaView.Item(i)(2).ToString.Trim)
                node1.ImageIndex = 1
                node1.Tag = dStaView.Item(i)(0).ToString.Trim
                If dStaView.Item(i)(7).ToString.Trim = "N" Then
                    node1.ForeColor = Color.Red
                End If
                node.Nodes.Add(node1)

                dScanView.RowFilter = "Dtype='2' and StaOrderid='" & dStaView.Item(i)(0).ToString.Trim & "'"
                dScanView.Sort = "ScanOrderid ASC"
                For j As Int16 = 0 To dScanView.Count - 1
                    Dim node2 As TreeNode = New TreeNode(dScanView.Item(j)(0).ToString.Trim & "-" & dScanView.Item(j)(3).ToString.Trim & ". " & dScanView.Item(j)(4).ToString.Trim & "-" & dScanView.Item(j)(5).ToString.Trim)
                    node2.ImageIndex = 2
                    If dScanView.Item(j)(7).ToString.Trim = "N" Then
                        node2.ForeColor = Color.Red
                    End If
                    node2.Tag = dScanView.Item(j)(0).ToString.Trim & " - " & dScanView.Item(j)(3).ToString.Trim
                    node1.Nodes.Add(node2)
                Next
            Next
        End If
        trvData.Nodes.Add(node)
        trvData.ExpandAll()

        dStaView.Dispose()
        dScanView.Dispose()
        dtable.Dispose()
    End Sub
    '根據查詢結果加載dgvSun數據
    Private Sub LoadDataTodgvSun(ByVal Partid As String, ByVal Rev As Integer)
        Dim SqlStr As String

        'Me.toolSunCount.Text = 0
        SqlStr = " select a.StaOrderid,a.Stationid,b.StationName as StationName,a.ScanOrderid, " _
               & "          a.TPartid,a.TPartText,a.IsMainBarcode,a.IsPrtSelf,a.IsAllowRe,a.IsCheckTestY,a.IsShowPacking,a.ShowColPos, " _
               & "          c.username username,convert(varchar(19),a.Intime,21) as intime,d.testtypeid,NgBackStationId=isnull(a.NgBackStationId,'') ,e.SaveTableName " _
               & " from m_RPartStationD_t a join m_Rstation_t b on a.Stationid = b.Stationid  " _
               & " left join m_users_t c on a.userid=c.userid " _
               & " left join m_TestStationPart_t d on a.Stationid=d.MesStationId AND a.PPartid = d.PARTID " _
               & " LEFT JOIN MESDataCenter.dbo.m_TestType_t e ON e.TestTypeId = d.TestTypeID" _
               & " where a.PPartid='" & Partid & "' and a.Revid=" & Rev
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
        dgvSun.Rows.Clear()
        For index As Integer = 0 To dt.Rows.Count - 1
            dgvSun.Rows.Add(dt.Rows(index)("StaOrderid"), dt.Rows(index)("Stationid"), dt.Rows(index)("StationName"), _
                         dt.Rows(index)("ScanOrderid"), dt.Rows(index)("TPartid"), dt.Rows(index)("TPartText"), _
                        IIf(dt.Rows(index)("IsMainBarcode").ToString = "Y", True, False), _
                        IIf(dt.Rows(index)("IsPrtSelf").ToString = "Y", True, False), _
                        IIf(dt.Rows(index)("IsAllowRe").ToString = "Y", True, False), _
                        IIf(dt.Rows(index)("IsCheckTestY").ToString = "Y", True, False), _
                        IIf(dt.Rows(index)("IsShowPacking").ToString = "Y", True, False), _
                        dt.Rows(index)("ShowColPos"), dt.Rows(index)("testtypeid"), dt.Rows(index)("NgBackStationId"),
                        dt.Rows(index)("SaveTableName")) '''', DReader.Item("username"), DReader.Item("Intime"),
        Next
    End Sub


    Private Sub LoadDataTodgvNGCode(ByVal Partid As String, ByVal Rev As Integer)
        Dim SqlStr As String

        SqlStr = " select a.CodeID, a.CodeName, a.Stationid,b.StationName as StationName, " _
               & "          c.username username,convert(varchar(19),a.Intime,21) as intime " _
               & " from m_StationCode_t a JOIN m_Rstation_t b on a.Stationid = b.Stationid " _
               & " left join m_users_t c on a.userid=c.userid " _
               & " where a.Partid='" & Partid & "' and a.Version=" & Rev
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
        dgvNGCode.Rows.Clear()
        For index As Integer = 0 To dt.Rows.Count - 1
            dgvNGCode.Rows.Add(dt.Rows(index)("CodeID"), dt.Rows(index)("CodeName"))
        Next
    End Sub


    '根据料件生成Route View
    Private Sub LoadRouteView(ByVal Partid As String, ByVal Rev As Integer)
        'Dim strSQL As String
        'Dim dtRouteList As DataTable
        'routeDesign.RouteClear()
        'Try
        '    strSQL = "SELECT m_RPartStationD_t.PPartid, m_RPartStationD_t.StaOrderid, m_RPartStationD_t.Stationid, m_Rstation_t.Stationname " _
        '     & "FROM m_RPartStationD_t " _
        '     & "INNER JOIN m_Rstation_t ON m_Rstation_t.Stationid=m_RPartStationD_t.Stationid " _
        '     & "WHERE PPartid='" & Partid.Trim().Replace("'", "''") & "' AND Revid='" & Rev & "' AND ScanOrderid='1' " _
        '     & "ORDER BY m_RPartStationD_t.StaOrderid ASC"
        '    dtRouteList = DbOperateUtils.GetDataTable(strSQL)
        '    routeDesign.RouteList = dtRouteList
        '    routeDesign.LoadRouteNodeObject()
        '    pbDesign.Width = routeDesign.RouteDesignWidth
        '    Me.pbDesign.Refresh()
        '    dtRouteList.Dispose()
        'Catch ex As Exception
        '    Me.pbDesign.Refresh()
        'End Try
        BindFlow(Partid, Rev)

    End Sub
#End Region

#Region "工具條按鈕事件"
    '新增
    Private Sub toolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolNew.Click
        dgvMain.Rows.Clear()
        dgvSun.Rows.Clear()
        trvData.Nodes.Clear()
        txtPartid.Text = ""
        opFlag = 1
        SetState(opFlag)
    End Sub
    '修改
    Private Sub toolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        Dim SqlStr As String = ""   'SQL語句

        If Me.dgvMain.Rows.Count = 0 OrElse Me.dgvMain.CurrentRow Is Nothing Then Exit Sub
        If Me.dgvMain.Item(3, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) = "2" Then
            MessageBox.Show("該版本已經作廢，不能被修改！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Me.dgvMain.Item(3, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) = "1" Then
            MessageBox.Show("該版本已經确认，不能被修改！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Me.dgvMain.Item(3, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) = "1" Then
            If MessageBox.Show("請確認是否要生成成品料號: [" + Me.dgvMain.Item(3, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim + "] 的新版本?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
            '複製料件站點設置中已確認的版本數據，生成新的版本
            'SqlStr = "declare @MaxRevid int select @MaxRevid=Max(Revid) from dbo.m_RPartStationM_t " _
            '    & " where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' insert dbo.m_RPartStationM_t(PPartid, Revid, State, UserID, Intime) select '" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' as PPartid, " _
            '    & " isnull(@MaxRevid+1,1) as Revid,'0' as State,'" & SysMessageClass.UseId.Trim.ToLower & "' as Userid,getdate() as Intime insert m_RPartStationD_t(" _
            '    & " PPartid, Revid, StaOrderid, ScanOrderid, Stationid, TPartid, TPartText,IsReplaceable, ReplaceID,IsMainBarcode, IsPrtSelf, IsAllowRe,IsCheckTestY,IsShowPacking,ShowColPos, Remark, State, UserID, Intime)" _
            '    & " select PPartid,isnull(@MaxRevid+1,1) as Revid,StaOrderid,ScanOrderid,Stationid, " _
            '    & " TPartid,TPartText,IsReplaceable, ReplaceID,IsMainBarCode,IsPrtSelf,IsAllowRe,IsCheckTestY,IsShowPacking,ShowColPos,Remark,'0' as State,'" & SysMessageClass.UseId.Trim.ToLower & "' as UserID,getdate() as Intime " _
            '    & " from m_RPartStationD_t where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & ""

            '部件條碼含有可替代料，更新時間：2009/10/14
            SqlStr = " declare @MaxRevid int,@Userid varchar(10),@PPartid varchar(35),@Revid int " _
                   & " set @Userid='" & SysMessageClass.UseId.Trim.ToLower & "' " _
                   & " set @PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' " _
                   & " set @Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim _
                   & " select @MaxRevid=Max(Revid) from dbo.m_RPartStationM_t where PPartid=@PPartid " _
                   & " insert dbo.m_RPartStationM_t(PPartid, Revid, State, UserID, Intime) " _
                   & " select @PPartid as PPartid,isnull(@MaxRevid+1,1) as Revid,'0' as State,@Userid as Userid,getdate() as Intime  " _
                   & " insert m_RPartStationD_t(PPartid, Revid, StaOrderid, ScanOrderid, Stationid,TPartid, TPartText,IsReplaceable, ReplaceID,IsMainBarcode, " _
                   & "                          IsPrtSelf, IsAllowRe,IsSemiProduct,IsCheckTestY,IsShowPacking,ShowColPos,Remark, State, UserID, Intime,Cmby,IsSplit,SplitQty,IsScanN) " _
                   & " select PPartid, isnull(@MaxRevid+1,1) as Revid,StaOrderid,ScanOrderid,Stationid,TPartid,TPartText,IsReplaceable, " _
                   & "        case IsReplaceable when 'Y' then dbo.FunCreateReplaceID() when 'N' then Null end as ReplaceID,IsMainBarCode,IsPrtSelf,IsAllowRe, " _
                   & "        IsSemiProduct,IsCheckTestY,IsShowPacking,ShowColPos,Remark,'0' as State,@Userid as UserID,getdate() as Intime,Cmby,IsSplit,SplitQty,IsScanN ,ScanNumber" _
                   & " from m_RPartStationD_t where PPartid=@PPartid and Revid=@Revid " _
            & " insert m_RPartStationT_t(ReplaceID, Itemid, TPartid, UserID, Intime) " _
            & " select c.ReplaceID, b.Itemid, b.TPartid, @Userid as UserID,GETDATE() as Intime " _
            & " from m_RPartStationD_t as a join m_RPartStationD_t as c on a.PPartid=c.PPartid and a.StaOrderid=c.StaOrderid and a.ScanOrderid=c.ScanOrderid " _
            & " join dbo.m_RPartStationT_t as b on a.ReplaceID=b.ReplaceID " _
            & " where a.PPartid=@PPartid and a.Revid= @Revid and c.Revid=isnull(@MaxRevid+1,1) " _
            & "delete from m_RPartStationT_t a join m_RPartStationD_t b on a.ReplaceID=b.ReplaceID where b.ppartid=@PPartid and Revid=@Revid "
            Try
                DbOperateUtils.ExecSQL(SqlStr)
                LoadDataTodgvMain(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
                Me.dgvMain.CurrentCell = Me.dgvMain.Item(0, 0)
                MessageBox.Show("已生成新的版本: " & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "toolEdit_Click", "sys")
            End Try
        End If
        opFlag = 2
        SetState(opFlag)
    End Sub
    '作廢
    Private Sub toolAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        Dim SqlStr As String = ""   '作廢主表SQL語句

        If Me.dgvMain.Rows.Count = 0 OrElse Me.dgvMain.CurrentRow Is Nothing Then Exit Sub
        If Me.dgvMain.Item(3, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) = "2" Then
            MessageBox.Show("該版本已經作廢，不能再作廢！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        SqlStr = " update m_RPartStationM_t set State=2,Canceluser='" & SysMessageClass.UseId.ToLower.Trim & "',Canceltime=getdate() " _
               & " where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim _
               & " update m_RPartStationD_t set State=2 " _
               & " where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        If MessageBox.Show("是否要作廢成品料號: [" + Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim + "] 第[" + Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim + "]版本?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadDataTodgvMain(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            MessageBox.Show("作廢成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "toolAbandon_Click", "sys")
        End Try
    End Sub
    '返回
    Private Sub toolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        'Me.btnDel.Enabled = True
        'Me.btnDown.Enabled = True
        'Me.btnUp.Enabled = True
        'Me.btnSave.Enabled = True
        Me.BnSelectSta.Enabled = True
        opFlag = 0
        SetState(opFlag)
    End Sub
    '確認


    Private Sub toolComfire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolComfire.Click
        Dim dtable As New DataTable
        Dim SqlStr As String = ""   'SQL語句

        If Me.dgvMain.Rows.Count = 0 OrElse Me.dgvMain.CurrentRow Is Nothing Then Exit Sub
        If Me.dgvMain.Item(3, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "0" Then
            MessageBox.Show("只有[0-編輯中]狀態的版本才能被確認！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        'update by xavier   平整度|所有測試參數維護完整才允許確定''''''''''''''''''''''''''''''''''
        Dim SQL As String = "select TestTypeID from  m_RPartStationD_t where ppartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid='" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and IsCheckTestY='Y' "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)
        Dim dt2 As DataTable = Nothing
        For i As Integer = 0 To dt.Rows.Count - 1
            SqlStr = "declare @TestIDlist varchar(50) ,@tempindex int,@tempTestID varchar(5),@ResultID varchar(5) " & _
                    " set  @TestIDlist='" + dt.Rows(i)(0).ToString + "'" & _
                    " set @TestIDlist=@TestIDlist+';'" & _
                    " set @tempindex=charindex(';',@TestIDlist) " & _
                    " while @tempindex>0 " & _
                    " begin " & _
                    " set @tempTestID=substring(@TestIDlist,0,6)" & _
                    " set @TestIDlist=substring(@TestIDlist,@tempindex+1,len(@TestIDlist)-6) " & _
                    " if not  exists (select 1 from  m_TestType_t a, m_TestCheck_t b where a.savetablename=b.checktable and a.usey='y' and b.usey='y' and a.TestTypeID=@tempTestID)	" & _
                    " begin " & _
                    " set @ResultID=@tempTestID " & _
                    " break " & _
                    " End " & _
                    " set @tempindex=charindex(';',@TestIDlist) " & _
                    " End " & _
                    " select isnull(@ResultID,'')"
            dt2 = DbOperateUtils.GetDataTable(SqlStr)
            If dt2.Rows(0)(0).ToString <> "0" And dt2.Rows(0)(0).ToString <> "" Then
                MessageBox.Show("該料件測試ID{" & dt2.Rows(0)(0).ToString & "}没有维护测试参数或者校验参数！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next
        'update by xavier   平整度|所有測試參數維護完整才允許確定''''''''''''''''''''''''''''''''''

        SqlStr = "select 1 from m_RPartStationM_t where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and State=1" '是否存在確認記錄
        dtable = DbOperateUtils.GetDataTable(SqlStr)
        If dtable.Rows.Count > 0 Then
            MessageBox.Show("該料件的掃描設置版本中已經有一筆被確認，不能再確認其他版本！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        SqlStr = " update m_RPartStationM_t set State=1,Comfireuser='" & SysMessageClass.UseId.ToLower.Trim & "',Comfiretime=getdate() " _
               & " where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim _
               & " update m_RPartStationD_t set State=1 " _
               & " where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        If MessageBox.Show("是否要確認成品料號: [" + Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim + "] 第[" + Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim + "]版本?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadDataTodgvMain(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            MessageBox.Show("確認成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "tsbAffirm_Click", "sys")
        End Try
    End Sub
    '匯出
    Private Sub toolExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ExportClass As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Sqlstr As String = ""
        If Me.dgvMain.Rows.Count = 0 OrElse Me.dgvSun.Rows.Count = 0 OrElse Me.dgvMain.CurrentRow Is Nothing Then Exit Sub
        Try
            Sqlstr = " select a.StaOrderid,a.Stationid,b.StationName as StationName,a.ScanOrderid, " _
                   & "        a.TPartid,a.TPartText,a.IsMainBarcode,a.IsPrtSelf,a.IsAllowRe,a.IsCheckTestY,a.IsShowPacking,a.ShowColPos, " _
                   & "        c.username username,convert(varchar(19),a.Intime,21) as intime " _
                   & " from m_RPartStationD_t a join m_Rstation_t b on a.Stationid = b.Stationid left join m_users_t c on a.userid=c.userid " _
                   & " where a.PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and a.Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
            'ExportClass.InportInExcel(Sqlstr.ToString, "料件掃描站點設置", Me.dgvSun)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "toolExport_Click", "sys")
        End Try
    End Sub
    '退出
    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
    '查詢
    Private Sub BnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnQuery.Click
        Dim dtable As New DataTable
        Dim SqlStr As String = ""

        If txtPartid.Text.Trim = "" Then Exit Sub
        If opFlag = 0 Then '查詢狀態
            LoadDataTodgvMain(Me.txtPartid.Text.Trim)
        ElseIf opFlag = 1 Then '新增狀態
            If MessageBox.Show("請確認是否要生成成品料號:[" + Me.txtPartid.Text.Trim + "]的新版本?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
            '部件料號含有替代料，更新日期：2009/10/14     
            SqlStr = " declare @MaxRevid int,@Return varchar(1),@PPartid varchar(35),@Userid varchar(10)  " _
                & " declare @MaxRow int,@id int,@StaOrderid int,@ScanOrderid int " _
                & " set @PPartid='" & Me.txtPartid.Text.Trim & "'  set @Userid='" & SysMessageClass.UseId.Trim.ToLower & "' " _
                & " set @Return=case (select 1 from dbo.m_PartContrast_t where TavcPart=@PPartid TavcPart=PavcPart and usey='Y') when '1' then '1' else '2' end " _
                & " if @Return='1' begin select @MaxRevid=Max(Revid) from dbo.m_RPartStationM_t where PPartid=@PPartid " _
                & " insert dbo.m_RPartStationM_t(PPartid, Revid, State, UserID, Intime) " _
                & " select @PPartid as PPartid,isnull(@MaxRevid+1,1) as Revid,'0' as State,@Userid as Userid,getdate() as Intime " _
                & " select @MaxRow=COUNT(*) from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid " _
                & " set @id = 1 if @MaxRow>0 begin while @id <= @MaxRow begin " _
                & " select @StaOrderid = StaOrderid,@ScanOrderid=ScanOrderid from( " _
                & " select  StaOrderid,ScanOrderid,row_number()over(order by StaOrderid,ScanOrderid) as id " _
                & " from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid) a where id = @id " _
                & " insert m_RPartStationD_t (PPartid, Revid, StaOrderid, ScanOrderid, Stationid,  TPartid, " _
                & " TPartText,IsReplaceable, ReplaceID,IsMainBarcode,IsPrtSelf, IsAllowRe,IsSemiProduct,IsScanN,IsCustPart,IsScanPallet,IsCheckTestY,TestTypeID,IsShowPacking,ShowColPos, Remark, State, UserID, Intime,Cmby,IsSplit,Ismatch,SplitBegin,SplitEnd,SplitQty) " _
                & " select PPartid, isnull(@MaxRevid+1,1) as Revid,StaOrderid,ScanOrderid,Stationid, " _
                & " TPartid,TPartText,IsReplaceable,case IsReplaceable when 'Y' then dbo.FunCreateReplaceID() when 'N' then Null end as ReplaceID," _
                & " IsMainBarCode,IsPrtSelf,IsAllowRe,IsSemiProduct,IsScanN, ScanNumber,IsCustPart,IsScanPallet, IsCheckTestY,TestTypeID,IsShowPacking,ShowColPos,Remark,'0' as State,@Userid as UserID,getdate() as Intime,Cmby,IsSplit,Ismatch,SplitBegin,SplitEnd,SplitQty " _
                & " from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid and  StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid " _
                & " set @id = @id +1 End End " _
                & " insert m_RPartStationT_t(ReplaceID, Itemid, TPartid, UserID, Intime) " _
                & " select c.ReplaceID, b.Itemid, b.TPartid, @Userid as UserID,GETDATE() as Intime " _
                & " from m_RPartStationD_t as a join m_RPartStationD_t as c on a.PPartid=c.PPartid and a.StaOrderid=c.StaOrderid and a.ScanOrderid=c.ScanOrderid " _
                & " join dbo.m_RPartStationT_t as b on a.ReplaceID=b.ReplaceID where a.PPartid=@PPartid and a.Revid=@MaxRevid and c.Revid=isnull(@MaxRevid+1,1) End " _
                & " select @Return as Re "

            dtable = DbOperateUtils.GetDataTable(SqlStr)
            If dtable.Rows(0)(0).ToString.Trim = "1" Then
                LoadDataTodgvMain(Me.txtPartid.Text.Trim)
                Me.dgvMain.CurrentCell = Me.dgvMain.Item(0, 0)
                MessageBox.Show("已生成版本: " & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf dtable.Rows(0)(0).ToString.Trim = "2" Then
                MessageBox.Show("此料號在系統中不存在，請確認料號是否輸入正確！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.txtPartid
                Exit Sub
            End If
            Me.SplitContainer3.Panel1.Enabled = False
        End If
    End Sub


    'Private Sub BnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnQuery.Click
    '    Dim dtable As New DataTable
    '    Dim SqlStr As String = ""

    '    If txtPartid.Text.Trim = "" Then Exit Sub
    '    If opFlag = 0 Then '查詢狀態
    '        LoadDataTodgvMain(Me.txtPartid.Text.Trim)
    '    ElseIf opFlag = 1 Then '新增狀態
    '        If MessageBox.Show("請確認是否要生成成品料號:[" + Me.txtPartid.Text.Trim + "]的新版本?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
    '        '部件料號含有替代料，更新日期：2009/10/14     
    '        SqlStr = " declare @MaxRevid int,@Return varchar(1),@PPartid varchar(35),@Userid varchar(10)  " _
    '            & " declare @MaxRow int,@id int,@StaOrderid int,@ScanOrderid int " _
    '            & " set @PPartid='" & Me.txtPartid.Text.Trim & "'  set @Userid='" & SysMessageClass.UseId.Trim.ToLower & "' " _
    '            & " set @Return=case (select 1 from dbo.m_PartContrast_t where TavcPart=@PPartid TavcPart=PavcPart and usey='Y') when '1' then '1' else '2' end " _
    '            & " if @Return='1' begin select @MaxRevid=Max(Revid) from dbo.m_RPartStationM_t where PPartid=@PPartid " _
    '            & " insert dbo.m_RPartStationM_t(PPartid, Revid, State, UserID, Intime) " _
    '            & " select @PPartid as PPartid,isnull(@MaxRevid+1,1) as Revid,'0' as State,@Userid as Userid,getdate() as Intime " _
    '            & " select @MaxRow=COUNT(*) from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid " _
    '            & " set @id = 1 if @MaxRow>0 begin while @id <= @MaxRow begin " _
    '            & " select @StaOrderid = StaOrderid,@ScanOrderid=ScanOrderid from( " _
    '            & " select  StaOrderid,ScanOrderid,row_number()over(order by StaOrderid,ScanOrderid) as id " _
    '            & " from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid) a where id = @id " _
    '            & " insert m_RPartStationD_t (PPartid, Revid, StaOrderid, ScanOrderid, Stationid,  TPartid, " _
    '            & " TPartText,IsReplaceable, ReplaceID,IsMainBarcode,IsPrtSelf, IsAllowRe,IsSemiProduct,IsScanN,IsCustPart,IsScanPallet,IsCheckTestY,TestTypeID,IsShowPacking,ShowColPos, Remark, State, UserID, Intime,Cmby,IsSplit,Ismatch,SplitBegin,SplitEnd,SplitQty) " _
    '            & " select PPartid, isnull(@MaxRevid+1,1) as Revid,StaOrderid,ScanOrderid,Stationid, " _
    '            & " TPartid,TPartText,IsReplaceable,case IsReplaceable when 'Y' then dbo.FunCreateReplaceID() when 'N' then Null end as ReplaceID," _
    '            & " IsMainBarCode,IsPrtSelf,IsAllowRe,IsSemiProduct,IsScanN, ScanNumber,IsCustPart,IsScanPallet, IsCheckTestY,TestTypeID,IsShowPacking,ShowColPos,Remark,'0' as State,@Userid as UserID,getdate() as Intime,Cmby,IsSplit,Ismatch,SplitBegin,SplitEnd,SplitQty " _
    '            & " from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid and  StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid " _
    '            & " set @id = @id +1 End End " _
    '            & " insert m_RPartStationT_t(ReplaceID, Itemid, TPartid, UserID, Intime) " _
    '            & " select c.ReplaceID, b.Itemid, b.TPartid, @Userid as UserID,GETDATE() as Intime " _
    '            & " from m_RPartStationD_t as a join m_RPartStationD_t as c on a.PPartid=c.PPartid and a.StaOrderid=c.StaOrderid and a.ScanOrderid=c.ScanOrderid " _
    '            & " join dbo.m_RPartStationT_t as b on a.ReplaceID=b.ReplaceID where a.PPartid=@PPartid and a.Revid=@MaxRevid and c.Revid=isnull(@MaxRevid+1,1) End " _
    '            & " select @Return as Re "

    '        dtable = DbOperateUtils.GetDataTable(SqlStr)
    '        If dtable.Rows(0)(0).ToString.Trim = "1" Then
    '            LoadDataTodgvMain(Me.txtPartid.Text.Trim)
    '            Me.dgvMain.CurrentCell = Me.dgvMain.Item(0, 0)
    '            MessageBox.Show("已生成版本: " & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        ElseIf dtable.Rows(0)(0).ToString.Trim = "2" Then
    '            MessageBox.Show("此料號在系統中不存在，請確認料號是否輸入正確！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Me.ActiveControl = Me.txtPartid
    '            Exit Sub
    '        End If
    '        Me.SplitContainer3.Panel1.Enabled = False
    '    End If
    'End Sub

    ''测试工站关联
    Private Sub toolTestSation_Click(sender As Object, e As EventArgs) Handles toolTestSation.Click
        Dim fr As FrmTestSFCStaion = New FrmTestSFCStaion
        fr.Owner = Me
        fr.sPartId = Me.txtPartid.Text.Trim
        fr.ShowDialog()
    End Sub
#End Region

#Region "點擊控件之後顯示數據"
    '單擊dgvMain數據行在Treeview1中顯示相關數據
    Private Sub dgvMain_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMain.CellEnter
        If Me.dgvMain.Rows.Count = 0 OrElse Me.dgvMain.CurrentRow Is Nothing Then
            'routeDesign.RouteClear()
            'Me.pbDesign.Refresh()
            Exit Sub
        End If

        Dim partid As String = Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        Dim revId As String = Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim

        LoadDataToTreeView(partid, revId)
        LoadDataTodgvSun(partid, revId)

        LoadRouteView(partid, revId)
        Me.LblVer.Text = revId

        SetCheckBoxSelected(partid, revId)
    End Sub
    '樹結點選中后發生的狀態改變
    Private Sub trvData_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvData.AfterSelect

        Dim Dtable As New DataTable
        Dim SqlStr As String
        Dim CurrSta As Int16 = 0
        Dim CurrScan As Int16 = 0
        Me.CobCScanId.Items.Clear()
        Me.CobCStation.Items.Clear()
        If Me.trvData.Nodes.Count = 0 OrElse Me.trvData.SelectedNode Is Nothing Then Exit Sub
        RadNmerger.Checked = True
        If e.Node.Level = 0 Then
            CurrSta = 0
            CurrScan = 0
        ElseIf e.Node.Level = 1 Then
            CurrSta = e.Node.Tag.ToString.Trim
            CurrScan = 1
        ElseIf e.Node.Level = 2 Then
            CurrSta = e.Node.Tag.ToString.Trim.Split("-")(0)
            CurrScan = e.Node.Tag.ToString.Trim.Split("-")(1)
        End If

        SqlStr = " SELECT c.SortName as Stationtype,a.Stationid,b.StationName,a.TPartid,a.TPartText,a.IsReplaceable,a.ReplaceID," _
               & " a.IsPrtSelf, a.IsAllowRe,a.IsSemiProduct,a.IsScanPallet,a.IsScanN,a.ScanNumber,a.IsCustPart,a.IsCheckTestY,a.TestTypeID,a.IsPrtPacking,a.IsOnlineGenCartonID,a.IsOnlineGenCartonID2, a.IsLinePrintFullCode," _
               & " a.IsShowPacking,a.isendsta,a.Cmby,a.ShowColPos,a.IsUpDown,a.isSplit,a.SplitQty,a.LabelNum,a.IsLineWeight,a.RepeatStyle,a.RepeatPara,a.RepeatStyleC,a.CartonRepeatStyle,a.CartonRepeatPara," _
               & " a.IsRelated,ContY,ASNY,LinePrtY,Ismatch,SplitBegin,SplitEnd,CheckSupY,CheckStaorder,CheckScanorder,IslineMbarcode,IsAllowNG," _
               & " IsAllowNGQty,NGqtySC,NGqtycount,IsUsb,isnull(IsPackingSame,'N') IsPackingSame,isnull(IsReadPCB,'N') IsReadPCB,isnull(IsWritePCB,'N') IsWritePCB," _
               & " isnull(IsPalletSame,'') IsPalletSame, isnull(IsPackType,'N') as IsPackType,ISNULL(IsCartonSame,'N') AS IsCartonSame, " _
               & " ISNULL(IsSamePacking,'N') AS IsSamePacking, isnull(IsPPackingProduct,'N') as IsPPackingProduct,isnull(IsCheckMoForCarton,'Y') as IsCheckMo, " _
               & " isnull(IsAssemblySN,'N') as IsAssemblySN, isnull(IsSSCC, 'N') as IsSSCC,a.LabelNum, CodeRuleID,CodeRuleID2, IsOldKanBanCheck,isnull(chkIsOnlineGenPalletID,'N') AS chkIsOnlineGenPalletID, ISNULL(IsPrtSelfCarton,'N') AS IsPrtSelfCarton ,isnull(IsPrtSelfPallet,'N') AS IsPrtSelfPallet" _
               & " ,isnull(IsOnlineWorkPrint,'N') as IsOnlineWorkPrint,isnull(IsNotCaseSensitive,'N') as IsNotCaseSensitive,WorkCodeRuleID,NgBackStationId,UpLimitWeight,LowLimitWeight,a.IsPpidLineWeight,a.PpidUpLimitWeight,a.PpidLowLimitWeight,a.BarePpidUpLimitWeight,a.BarePpidLowLimitWeight,a.BigCartonRepeatStyle,a.BigCartonRepeatPara" _
               & "  ,isnull(IsQCPlan,'N') as IsQCPlan,QCPlanId,IsQCCheckOut,IsCheckLink " _
               & " from dbo.m_RPartStationD_t as a  " _
               & " left join m_Rstation_t b on a.Stationid = b.Stationid " _
               & " left join m_Sortset_t c on b.Stationtype=c.SortID and c.SortType='StationType' " _
               & " where a.PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' " _
               & "       and a.Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim _
               & "       and a.StaOrderid=case " & e.Node.Level & " when 0 then 1 when 1 then " & CurrSta & " when 2 then " & CurrSta & " end " _
               & "       and a.ScanOrderid=case " & e.Node.Level & " when 0 then 1 when 1 then 1 when 2 then " & CurrScan & " end "
        Dtable = DbOperateUtils.GetDataTable(SqlStr)
        ClearObj()  '清空控件
        If Dtable.Rows.Count = 0 Then
            '按鈕權限控制
            If opFlag <> 0 Then
                'Me.btnDel.Enabled = False
                'Me.btnDown.Enabled = False
                'Me.btnUp.Enabled = False
                'Me.btnSave.Enabled = True
                Me.BnSelectSta.Enabled = True
                Me.txtTPartid.Enabled = True
                Me.txtTPartText.Enabled = True
                Me.TxtTpartT.Enabled = True
                Me.btnAdd.Enabled = True
                Me.btnClearpart.Enabled = True

                If e.Node.Level = 0 Then  '根節點,ContY,ASNY,LinePrtY
                    Me.txtTPartid.Text = Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
                    Me.txtTPartText.Text = "主條碼"
                    Me.txtTPartid.Enabled = False
                    'Me.txtTPartText.Enabled = False
                    Me.TxtTpartT.Enabled = False
                    Me.btnAdd.Enabled = False
                    Me.btnClearpart.Enabled = False
                    SetComBox() ' 20160524 田玉琳
                    SetCobQCPlan()
                End If
            End If
        Else
            Me.txtStationid.Text = IIf(e.Node.Level = 0, "", Dtable.Rows(0)("Stationid").ToString.Trim)
            Me.txtStationName.Text = IIf(e.Node.Level = 0, "", Dtable.Rows(0)("StationName").ToString.Trim)
            '回流工序赋值 --by hs ke20180428
            Me.txtNgCuurStationId.Text = txtStationid.Text
            Me.txtNgCuurStationName.Text = txtStationName.Text
            txtNgCuurStationStaOrder.Text = CurrSta.ToString
            txtStationid.ReadOnly = True
            txtNgCuurStationName.ReadOnly = True
            txtNgCuurStationStaOrder.ReadOnly = True
            txtNgBackStationId.SelectedValue = IIf(e.Node.Level = 0, "", Dtable.Rows(0)("NgBackStationId").ToString.Trim)
            SetBindBackComBox(CurrSta)
            SetCobQCPlan()
            '回流工序赋值


            Me.txtStationtype.Text = IIf(e.Node.Level = 0, "", Dtable.Rows(0)("Stationtype").ToString.Trim)
            Me.txtTPartid.Text = IIf(e.Node.Level = 1, "", Dtable.Rows(0)("TPartid").ToString.Trim)
            Me.txtTPartText.Text = IIf(e.Node.Level = 1, "", Dtable.Rows(0)("TPartText").ToString.Trim)
            Me.ckbIsAllowRe.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsAllowRe").ToString.Trim = "Y", True, False)
            Me.ChbCustPart.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsCustPart").ToString.Trim = "Y", True, False)
            Me.ChkScanPallet.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsScanPallet").ToString.Trim = "Y", True, False)
            Me.ckbIsPrtSelf.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPrtSelf").ToString.Trim = "Y", True, False)
            Me.chkIsScanN.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsScanN").ToString.Trim = "Y", True, False)
            Me.chkIsSemiProduct.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsSemiProduct").ToString.Trim = "Y", True, False)
            Me.ChkIsPrtPacking.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPrtPacking").ToString.Trim = "Y", True, False)
            Me.chkIsOnlineGenCartonID.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsOnlineGenCartonID").ToString.Trim = "Y", True, False)
            Me.chkIsOnlineGenCartonID2.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsOnlineGenCartonID2").ToString.Trim = "Y", True, False)
            Me.chkIsOnlineGenPalletID.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("chkIsOnlineGenPalletID").ToString.Trim = "Y", True, False)
            Me.ChkIsPrtSelfCarton.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPrtSelfCarton").ToString.Trim = "Y", True, False)
            Me.IsPrtSelfPallet.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("ISPRTSELFPALLET").ToString.Trim = "Y", True, False)
            Me.chkIsLinePrintFullCode.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsLinePrintFullCode").ToString.Trim = "Y", True, False)
            Me.chkIsLineWeight.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsLineWeight").ToString.Trim = "Y", True, False)
            Me.chkIsPpidLineWeight.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPpidLineWeight").ToString.Trim = "Y", True, False)
            Me.chkRepeatStyle.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("RepeatStyle").ToString.Trim = "Y", True, False)
            Me.chkRepeatStyleC.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("RepeatStyleC").ToString.Trim = "Y", True, False)
            Me.chkIsScanN.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsScanN").ToString.Trim = "Y", True, False)
            'add by cq 20171103 
            Me.chkCartonRepeatStyle.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("CartonRepeatStyle").ToString.Trim = "Y", True, False)
            'add by cq 20180829 
            Me.chkBigCartonRepeatStyle.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("BigCartonRepeatStyle").ToString.Trim = "Y", True, False)
            Me.IsPrtSelfPallet.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPrtSelfPallet").ToString.Trim = "Y", True, False)

            'add by 邓炯 条码不区分大小写20180731
            Me.chkIsNotCaseSensitive.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsNotCaseSensitive").ToString.Trim = "Y", True, False)

            'add by hgd 20180403是否在线打印制程外箱
            Me.ckIsOnlineWorkPrint.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsOnlineWorkPrint").ToString.Trim = "Y", True, False)

          
            If Me.chkRepeatStyle.Checked Then
                If Dtable.Rows(0)("RepeatPara").ToString.Trim = "" Then
                    CobChekTimes.SelectedIndex = 0
                    Me.txtRepeatPara.Text = "{@ppid}"
                Else
                    CobChekTimes.SelectedIndex = Dtable.Rows(0)("RepeatPara").ToString.Trim.Split(",").Length - 1
                    Me.txtRepeatPara.Text = Dtable.Rows(0)("RepeatPara").ToString.Trim
                End If
            Else
                CobChekTimes.SelectedIndex = 0
                Me.txtRepeatPara.Text = ""
            End If


            'add by cq 20171103
            If Me.chkCartonRepeatStyle.Checked Then
                If Dtable.Rows(0)("CartonRepeatPara").ToString.Trim = "" Then
                    CobCartonChekTimes.SelectedIndex = 0
                    Me.txtCartonRepeatPara.Text = "{@ppid}"
                Else
                    CobCartonChekTimes.SelectedIndex = Dtable.Rows(0)("CartonRepeatPara").ToString.Trim.Split(",").Length - 1
                    Me.txtCartonRepeatPara.Text = Dtable.Rows(0)("CartonRepeatPara").ToString.Trim
                End If
            Else
                CobCartonChekTimes.SelectedIndex = 0
                Me.txtCartonRepeatPara.Text = ""
            End If

            'add by cq 20180828
            If Me.chkBigCartonRepeatStyle.Checked Then
                If Dtable.Rows(0)("BigCartonRepeatPara").ToString.Trim = "" Then
                    CobBigCartonChekTimes.SelectedIndex = 0
                    Me.txtBigCartonRepeatPara.Text = "{@ppid}"
                Else
                    CobBigCartonChekTimes.SelectedIndex = Dtable.Rows(0)("BigCartonRepeatPara").ToString.Trim.Split(",").Length - 1
                    Me.txtBigCartonRepeatPara.Text = Dtable.Rows(0)("BigCartonRepeatPara").ToString.Trim
                End If
            Else
                CobBigCartonChekTimes.SelectedIndex = 0
                Me.txtBigCartonRepeatPara.Text = ""
            End If

            'add by hgd 20180531 是否在线称重,显示上下限
            If Me.chkIsLineWeight.Checked Then
                Me.txtUpLimitWeight.Text = Dtable.Rows(0)("UpLimitWeight").ToString.Trim
                Me.txtLowLimitWeight.Text = Dtable.Rows(0)("LowLimitWeight").ToString.Trim
            End If

            If Me.chkIsPpidLineWeight.Checked Then
                Me.txtPpidUpLimitWeight.Text = Dtable.Rows(0)("PpidUpLimitWeight").ToString.Trim
                Me.txtPpidLowLimitWeight.Text = Dtable.Rows(0)("PpidLowLimitWeight").ToString.Trim
            End If

            ' If Me.chkIsBarePpidLineWeight.Checked Then
            Me.txtBarePpidUpLimitWeight.Text = DbOperateUtils.DBNullToStr(Dtable.Rows(0)("BarePpidUpLimitWeight").ToString.Trim)
            Me.txtBarePpidLowLimitWeight.Text = DbOperateUtils.DBNullToStr(Dtable.Rows(0)("BarePpidLowLimitWeight").ToString.Trim)
            If Not String.IsNullOrEmpty(Me.txtBarePpidUpLimitWeight.Text) Then
                Me.chkIsBarePpidLineWeight.Checked = True
            Else
                Me.chkIsBarePpidLineWeight.Checked = False
            End If
            'End If

            If Me.chkIsScanN.Checked Then
                TextBoxUL1.Text = Dtable.Rows(0)("ScanNumber").ToString.Trim
            End If

            Me.TxtLabelNum.Text = Dtable.Rows(0)("LabelNum").ToString.Trim ''是否在线打印整箱条码(标签数)
            Me.ckbIsShowPacking.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsShowPacking").ToString.Trim = "Y", True, False)
            'Me.RadNmerger.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("Cmby").ToString.Trim = "0", True, False)
            'Me.RadQmerger.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("Cmby").ToString.Trim = "1", True, False)
            'Me.RadHmerger.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("Cmby").ToString.Trim = "2", True, False)
            Me.ckbIsUpMaterial.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsUpDown").ToString.Trim = "Y", True, False)
            Me.Checktime.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("isendsta").ToString.Trim = "Y", True, False)
            Me.ckbIsCheckTestY.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsCheckTestY").ToString.Trim = "Y", True, False)
            If Me.ckbIsCheckTestY.Checked Then
                Me.ChbTestNum.SelectedIndex = IIf(e.Node.Level <> 1, Dtable.Rows(0)("TestTypeID").ToString.Trim.Split(";").Length() - 1, -1)
            End If
            Me.CboShowP.SelectedIndex = IIf(Me.ckbIsShowPacking.Checked = False, -1, Me.CboShowP.FindStringExact(Dtable.Rows(0)("ShowColPos").ToString.Trim))
            Me.CboShowP.Enabled = Me.ckbIsShowPacking.Checked
            SetComBox() ' 20160524 田玉琳
            Me.cboPack.SelectedIndex = Me.cboPack.FindString(Dtable.Rows(0)("CodeRuleID").ToString)
            Me.cboPack2.SelectedIndex = Me.cboPack2.FindString(Dtable.Rows(0)("CodeRuleID2").ToString)
            Me.cboWorkCodeRuleId.SelectedIndex = Me.cboWorkCodeRuleId.FindString(Dtable.Rows(0)("WorkCodeRuleId").ToString)
            Me.TxtLabelNum.Text = Dtable.Rows(0)("LabelNum").ToString
            'Me.LblSupplier.Text = Dtable.Rows(0)("Supplierid").ToString

            Me.ChkIsContinual.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("ContY").ToString.Trim = "Y", True, False)
            Me.ChkASN.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("ASNY").ToString.Trim = "Y", True, False)
            Me.ChkTTprint.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("LinePrtY").ToString.Trim = "Y", True, False)
            Me.ChkTTprint.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("LinePrtY").ToString.Trim = "Y", True, False)
            'isnull(IsPackingSame,'N') IsPackingSame,isnull(IsReadPCB,'N') IsReadPCB,isnull(IsWritePCB,'N') IsReadPCB,isnull(IsPalletSame,'') IsPalletSame
            Me.ChkCartonSame.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsCartonSame").ToString.Trim = "Y", True, False)
            Me.ChkReadPCB.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsReadPCB").ToString.Trim = "Y", True, False)
            Me.ChkWritePCB.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsWritePCB").ToString.Trim = "Y", True, False)
            Me.ChkPalletSame.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPalletSame").ToString.Trim = "Y", True, False)
            'add by paul 20141110
            'for checking the mo(scaned sn) is the same as the system setup
            Me.ChkMo.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsCheckMo").ToString.Trim = "Y", True, False)


            Me.ChkPackingType.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPackType").ToString.Trim = "Y", True, False)
            Me.ChkSamePacking.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsSamePacking").ToString.Trim = "Y", True, False)
            'added by paul 20150310 是否为制程条码
            Me.ChkAssemblySN.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsAssemblySN").ToString.Trim = "Y", True, False)

            Me.chkParitySSCC.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsSSCC").ToString.Trim = "Y", True, False)

            Me.Chkmatch.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("Ismatch").ToString.Trim = "Y", True, False)
            Me.TxtSpiltBegin.Text = Dtable.Rows(0)("splitbegin").ToString
            Me.TxtSpiltEnd.Text = Dtable.Rows(0)("splitend").ToString

            Me.ChkSupplier.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("CheckSupY").ToString.Trim = "Y", True, False)
            Me.CobCStation.Text = Dtable.Rows(0)("CheckStaorder").ToString
            Me.CobCScanId.Text = Dtable.Rows(0)("CheckScanorder").ToString

            If e.Node.Level <> 1 And Dtable.Rows.Count Then
                'Me.TxtSplitQty.Text = Dtable.Rows(0)("SplitQty").ToString.Trim
                Me.TxtSplitQty.Checked = IIf(Dtable.Rows(0)("SplitQty").ToString = "Y", True, False)
            End If
            Me.ChkRelate.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsRelated").ToString.Trim = "Y", True, False)
            ChkLinePinrtM.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IslineMbarcode").ToString.Trim = "Y", True, False) ''在线打印主条码
            ChkUsb.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsUsb").ToString.Trim = "Y", True, False) ''读取USB序号
            CheckNcount.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsAllowNG").ToString.Trim = "Y", True, False) ''允许发生不良的次数
            TxtNGcount.Text = Dtable.Rows(0)("IsAllowNGQty").ToString.Trim ''允许次数
            ChkClaQty.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("NGqtySC").ToString.Trim = "Y", True, False) ''时间内不良达到数量时预警
            TxtClaQty.Text = Dtable.Rows(0)("NGqtycount").ToString.Trim ''多少个不良预警
            'Me.RadNmerger.Checked = IIf(e.Node.Level = 1 AndAlso Dtable.Rows(0)("Cmby").ToString.Trim = "0", True, False)Ismatch

            Me.ChkOldKanBanCheck.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsOldKanBanCheck").ToString.Trim = "Y", True, False)
            'If RadQmerger.Checked = False AndAlso RadHmerger.Checked = False Then
            '    RadNmerger.Checked = True
            'End If
            '' Me.CboTestType.SelectedIndex = IIf(Me.ckbIsCheckTestY.Checked = False, -1, Me.CboTestType.FindString(Dtable.Rows(0)("TestType").ToString.Trim))
            ''Me.CboTestType.Enabled = Me.ckbIsCheckTestY.Checked

            'add by hgd 20200115是否抽验计划
            Me.chkQCPlan.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsQCPlan").ToString.Trim = "Y", True, False)

            'add by hgd 20200115是否品质检验CheckOut
            Me.chkQCCheckOut.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsQCCheckOut").ToString.Trim = "Y", True, False)
            If Me.chkQCPlan.Checked Then
                Me.CobQCPlan.SelectedValue = Dtable.Rows(0)("QCPlanId").ToString.Trim
            Else
                Me.CobQCPlan.SelectedIndex = -1
            End If

            'add by hgd 20200309是否Link检查
            Me.chkIsCheckLink.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsCheckLink").ToString.Trim = "Y", True, False)
            '按鈕權限控制
            If opFlag <> 0 Then
                If e.Node.Level = 0 Then '根節點
                    'Me.btnDel.Enabled = False
                    'Me.btnDown.Enabled = False
                    'Me.btnUp.Enabled = False
                    'Me.btnSave.Enabled = True
                    Me.BnSelectSta.Enabled = True
                    Me.btnAdd.Enabled = False
                    Me.btnClearpart.Enabled = False
                    Me.TxtTpartT.Enabled = False
                    Me.txtTPartid.Enabled = False
                    Me.txtTPartText.Enabled = False
                Else  '工站節點和掃描條碼節點
                    'Me.btnDel.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
                    'Me.btnDown.Enabled = IIf(e.Node.NextNode Is Nothing OrElse (e.Node.Level = 2 AndAlso CurrScan = "1"), False, True)
                    'Me.btnUp.Enabled = IIf(e.Node.PrevNode Is Nothing OrElse (e.Node.Level = 2 AndAlso CurrScan < "3"), False, True)
                    Me.btnAdd.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
                    Me.btnClearpart.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
                    'Me.btnSave.Enabled = True
                    Me.BnSelectSta.Enabled = False
                    Me.txtTPartid.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
                    'Me.txtTPartText.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
                    'Modified by Aimee 20150312, enable to change PN Des(CurrScan = "1", 可能是制程条码也可能是成品条码)
                    Me.txtTPartText.Enabled = True
                    Me.TxtTpartT.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
                End If
            End If
            '刷出部件料號的替代料
            If Dtable.Rows(0)("IsReplaceable").ToString.Trim = "Y" Then
                SqlStr = "select itemid,TPartid from m_RPartStationT_t where ReplaceID='" & Dtable.Rows(0)("ReplaceID").ToString.Trim & "' order by itemid"
                Dtable = DbOperateUtils.GetDataTable(SqlStr)
                For i As Integer = 0 To Dtable.Rows.Count - 1
                    Me.LstPartSum.Items.Add(Dtable.Rows(i)(1).ToString.Trim)
                Next
            End If

            SqlStr = "select RuleId from m_RPartStationCheckRule_t where Ppartid='" + Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim + "' and Tpartid='" + Me.txtTPartid.Text + "' and Revid='" + Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim + "' and StaOrderid=case " & e.Node.Level & " when 0 then 1 when 1 then " & CurrSta & " when 2 then " & CurrSta & " end and Stationid='" + Me.txtStationid.Text + "'  and ScanOrderid=case " & e.Node.Level & " when 0 then 1 when 1 then 1 when 2 then " & CurrScan & " end  "

            Dtable = DbOperateUtils.GetDataTable(SqlStr)
            'ChkListBox.ClearSelected()
            Dim k As Integer = 0
            For k = 0 To ChkListBox.Items.Count - 1
                ChkListBox.SetItemChecked(k, False)
                If Dtable.Rows.Count > 0 Then
                    For i As Integer = 0 To Dtable.Rows.Count - 1
                        Dim id As String = Dtable.Rows(i)(0).ToString.Trim
                        Dim val As String = CType(ChkListBox.Items(k), DataRowView).Row(0).ToString
                        If id = val Then
                            ChkListBox.SetItemChecked(k, True)
                        End If
                    Next
                End If

            Next
        End If
        SetPackData()
        SetPackData2()

        If e.Node.Level = 2 Then
            If Not IsNothing(Me.dgvMain.CurrentRow) Then
                m_strCurrVer = Me.dgvMain.Item("ColVer", Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
            Else
                m_strCurrVer = ""
            End If
            LoadDataTodgvNGCode(txtPartid.Text, m_strCurrVer)
        End If

    End Sub

#End Region

#Region "掃描工站設置明細"
    '查詢工站
    Private Sub BnSelectSta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnSelectSta.Click
        Dim frm As New FrmRStationSet
        frm.StartPosition = FormStartPosition.CenterParent
        frm.opflag = 3
        frm.ShowDialog()
        Me.txtStationid.Text = frm.frmRstationid
        Me.txtStationName.Text = frm.frmRstationname
        Me.txtStationtype.Text = frm.frmStationtype
    End Sub



    '清空部件料號
    Private Sub BnClearpart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearpart.Click
        Me.LstPartSum.Items.Clear()
        Me.TxtTpartT.Text = ""
        Me.ActiveControl = Me.TxtTpartT
    End Sub

    Private Sub BnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Me.TxtTpartT.Text.Trim = "" Then Exit Sub
        If Me.LstPartSum.Items.Contains(Me.TxtTpartT.Text.Trim) = True OrElse Me.TxtTpartT.Text.Trim = Me.txtTPartid.Text.Trim Then
            MessageBox.Show("该料件已经在列表中或已經選為部件料號！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtTpartT.Text = ""
            Me.ActiveControl = Me.TxtTpartT
            Exit Sub
        End If
        If Me.TxtTpartT.Text.Trim = Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim Then
            MessageBox.Show("部件料號不能與主料號相同！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtTpartT.Text = ""
            Me.ActiveControl = Me.TxtTpartT
            Exit Sub
        End If
        If CheckPartid(Me.TxtTpartT) = False Then Exit Sub
        Me.LstPartSum.Items.Add(Me.TxtTpartT.Text.Trim)
        Me.TxtTpartT.Text = ""
        Me.ActiveControl = Me.TxtTpartT
    End Sub

#End Region

#Region "textbox事件"
    '離開成品料號textbox后事件
    Private Sub txtPartid_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartid.Leave, txtTPartid.Leave, TxtTpartT.Leave
        If sender.Text.ToString.Trim = "" Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        If CheckPartid(sender) = False Then Exit Sub
    End Sub
    '改變成品料號textbox后事件
    Private Sub txtPartid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartid.TextChanged
        dgvMain.Rows.Clear()
        trvData.Nodes.Clear()
        dgvSun.Rows.Clear()
        ClearObj()
    End Sub

    Private Sub ckbIsShowPacking_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CboShowP.Enabled = Me.ckbIsShowPacking.Checked
    End Sub

#End Region

#Region "數據檢驗"
    '驗證料件是否存在
    Private Function CheckPartid(ByVal sender As System.Object) As Boolean
        Dim SqlStr As String = "select 1 from m_PartContrast_t where tavcpart='" & sender.text.ToString.Trim & "' and usey='Y'" & GetPartFatory()
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)
        If dt.Rows.Count = 0 Then
            MessageBox.Show("此料号在系统中不存在，请确认料号是否输入正确！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            sender.text = ""
            Me.ActiveControl = sender
            Return False
        End If
        Return True
    End Function

    Private Function CheckStationid(ByVal strPartId As String, ByVal strRevId As String, ByVal strStaOrderid As String, ByVal strStationId As String) As Boolean
        Try
            Select Case Me.trvData.SelectedNode.Level
                Case 0
                    'AND StaOrderid = '" & strStaOrderid & "' 
                    Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT PPartid FROM m_RPartStationD_t WHERE PPartid = '" & strPartId & "' AND Revid = '" & strRevId & "' AND ScanOrderid = '1' AND Stationid = '" & strStationId & "' ")
                    If (dtTemp Is Nothing Or dtTemp.Rows.Count <= 0) Then
                        Return True
                    Else
                        MessageBox.Show("工站已经存在扫描流程中，同流程工站不能重复！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                Case Else
                    Return True
            End Select
        Catch ex As Exception
            MessageBox.Show("检查料件扫描流程工站是否存在异常,请确认网络连接是否正常！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    '保存前數據驗證
    Private Function CheckDataForSave() As Boolean
        If Me.trvData.Nodes.Count = 0 OrElse Me.trvData.SelectedNode Is Nothing Then Return False

        Dim isParts As Boolean = False
        'add by hgd 20191107 判断是否部件条码
        If txtTPartid.Text <> "" Then
            Dim sPpartid = Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
            If txtTPartid.Text <> sPpartid Then
                isParts = True
            End If
        Else

            If txtStationid.Text.Trim = "" Then
                MessageBox.Show("請選擇掃描工站編號信息！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.BnSelectSta
                Return False
            Else
                If Not CheckStationid(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(0).Trim, Me.txtStationid.Text.Trim) Then
                    Me.ActiveControl = Me.txtStationid
                    Return False
                End If
            End If

            If Me.txtTPartid.Text.Trim = "" Then
                MessageBox.Show("請輸入掃描部件料號！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.txtTPartid
                Return False
            Else
                If CheckPartid(Me.txtTPartid) = False Then
                    Me.ActiveControl = Me.txtTPartid
                    Return False
                End If
            End If

            If Me.Chkmatch.Checked Then
                If CInt(Me.TxtSpiltEnd.Text) < 1 Or Me.TxtSpiltBegin.Text = "" Or (Me.TxtSpiltEnd.Text) = "" Or CInt(Me.TxtSpiltEnd.Text) < 1 Then
                    MessageBox.Show("截取的起止位及长度不能为空！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Me.ActiveControl = Me.BnSelectSta
                    Return False
                End If
            End If

            'If Me.ChkSplit.Checked = True Then
            '    If Me.TxtSplitQty.Text = "" Or Me.TxtSplitQty.Text = 0 Then
            '        MessageBox.Show("請輸入拆分元件的數量！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.TxtSplitQty.Focus()
            '        Return False
            '    End If
            'End If

            If Me.txtTPartText.Text.Trim = "" Then
                MessageBox.Show("請輸入掃描部件名稱！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.txtTPartText
                Return False
            End If
            If Me.ckbIsShowPacking.Checked = True AndAlso Me.CboShowP.Text.Trim = "" Then
                MessageBox.Show("請選擇該部件條碼序號在外箱標籤上顯示的列位置！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.CboShowP
                Return False
            End If ''Me.trvData.SelectedNode.Index = 0 Or
            'If Me.trvData.SelectedNode.Level = 1 Then
            '    If Me.ChkSupplier.Checked = True Then
            '        MessageBox.Show("料件設置樹根結點不允許設置部件是否成套參數！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.ActiveControl = Me.CobCStation
            '        Return False
            '    End If
            'End If
            If Me.ckbIsCheckTestY.Checked = True AndAlso Me.ChbTestNum.Text.Trim = "" Then
                MessageBox.Show("請選擇該部件條碼序號需要測試的次數！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.ChbTestNum
                Return False
            End If

        End If
        If (Me.ChkIsPrtPacking.Checked Or Me.chkIsOnlineGenCartonID.Checked Or ChkIsPrtSelfCarton.Checked = False) Then
            If Me.cboPack.Text = "" And isParts = False Then
                MessageBox.Show("請選擇該部件條碼序號需要的外箱打印编码原则！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.cboPack
                Return False
            End If
        End If
        If (Me.chkIsScanN.Checked) Then
            If Val(Me.TextBoxUL1.Text) < 1 Then
                MessageBox.Show("组合数不能小于1！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.cboPack
                Return False
            End If
        End If
        If (Me.chkIsOnlineGenCartonID2.Checked) Then
            If Me.cboPack2.Text = "" Then
                MessageBox.Show("請選擇該部件條碼序號需要的外箱打印编码原则！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.cboPack2
                Return False
            End If
        End If

        If (Me.ckIsOnlineWorkPrint.Checked) Then
            If Me.cboWorkCodeRuleId.Text = "" Then
                MessageBox.Show("請選擇該条码制程外箱编码原则！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.cboWorkCodeRuleId
                Return False
            End If
        End If

        If Me.ChkSupplier.Checked = True Then
            If Me.CobCScanId.Text = "" Then
                MessageBox.Show("如需檢查材料供應商部件是否成套,站點掃描順序不能為空！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.CobCScanId
                Return False
            End If
            If Me.CobCStation.Text = "" Then
                MessageBox.Show("如需檢查材料供應商部件是否成套,站點不能為空！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.CobCStation
                Return False
            End If
        End If

        If Me.chkQCPlan.Checked = True Then
            If Me.CobQCPlan.SelectedValue = 0 Then
                MessageBox.Show("請選擇抽驗計劃！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.CobQCPlan
                Return False
            End If

            If Me.chkQCCheckOut.Checked = True Then
                MessageBox.Show("已勾選抽驗計劃,不能設置品質抽檢CheckOut！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.CobQCPlan
                Return False
            End If
        End If

        If Me.chkIsPpidLineWeight.Checked = True Then
            If Me.chkIsBarePpidLineWeight.Checked=True Then
                MessageBox.Show("已勾選产品称重,不能再勾选裸机产品称重！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.chkIsBarePpidLineWeight
                Return False
            End If
        End If

        If Me.chkIsBarePpidLineWeight.Checked = True Then
            If Val(txtBarePpidLowLimitWeight.Text) >= Val(txtBarePpidUpLimitWeight.Text) Then
                MessageBox.Show("下限必须小于上限的重量！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.txtBarePpidUpLimitWeight
                Return False
            End If
            If String.IsNullOrEmpty(Me.txtBarePpidLowLimitWeight.Text) OrElse String.IsNullOrEmpty(Me.txtBarePpidUpLimitWeight.Text) Then
                MessageBox.Show("下限和上限的重量都必须维护！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.txtBarePpidUpLimitWeight
                Return False
            End If
        Else
            ''保持界面是否勾选来决定是否存上下限
            Me.txtBarePpidLowLimitWeight.Text = String.Empty
            Me.txtBarePpidUpLimitWeight.Text = String.Empty
        End If

        Return True
    End Function

#End Region

#Region "取消是否核對測試結果判斷是否存在數據"

    Private Sub ckbIsCheckTestY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.ckbIsCheckTestY.Checked = True Then
            Me.ChbTestNum.Enabled = True
            Me.ChbTestNum.SelectedIndex = 0
            Exit Sub
        End If
        Dim SqlStr As String = "select 1 from m_RPartStationD_t as a  left join m_Testtype_t as b on a.testtypeid=b.testtypeid where a.ppartid='" & Me.txtPartid.Text.Trim & "' and usey='Y'"
        If DbOperateUtils.GetDataTable(SqlStr).Rows.Count > 0 Then
            'MessageBox.Show("此料號在系統中存在掃描數據，取消后需要重新掃描，是否確認取消！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If MessageBox.Show("此料號在系統中存在掃描數據，取消后需要重新掃描，是否確認取消！", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                Exit Sub
                Me.ckbIsCheckTestY.Checked = True
            Else
                Me.ChbTestNum.Enabled = False
                Me.ChbTestNum.SelectedIndex = -1
            End If

        End If
    End Sub

#End Region

#Region "只允许输入数字"
    Private Sub TxtSpiltBegin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = Chr(13) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
#End Region

    'Private Sub Chkmatch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If Me.Chkmatch.Checked = True Then
    '        Me.TxtSpiltEnd.Enabled = True
    '        Me.TxtSpiltBegin.Enabled = True
    '    Else
    '        Me.TxtSpiltEnd.Enabled = False
    '        Me.TxtSpiltBegin.Enabled = False
    '    End If

    'End Sub

    'Private Sub ChkSupplier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If ChkSupplier.Checked = False Then
    '        Me.CobCScanId.Items.Clear()
    '        Me.CobCStation.Items.Clear()
    '    Else
    '        If Me.trvData.SelectedNode.Index = -1 Then Exit Sub
    '        CobCStation.Items.Clear()
    '        Dim dt As DataTable = DbOperateUtils.GetDataTable("select distinct Stationid from m_RPartStationD_t where ppartid='" & Me.txtPartid.Text.Trim &
    '                                                          "' and staorderid<='" & CInt(Me.trvData.SelectedNode.Index + 1) & "' and Revid='" &
    '                                                          Me.dgvMain.CurrentRow.Cells("ColVer").Value & "'")
    '        For index As Integer = 0 To dt.Rows.Count - 1
    '            CobCStation.Items.Add(dt.Rows(index)("Stationid").ToString)
    '        Next
    '    End If

    'End Sub

    'Private Sub CobCStation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If Me.trvData.SelectedNode.Index = -1 Then Exit Sub
    '    CobCScanId.Items.Clear()
    '    Dim dt As DataTable = DbOperateUtils.GetDataTable("select ScanOrderid from m_RPartStationD_t where ppartid='" & Me.txtPartid.Text.Trim &
    '                                                      "' and Stationid='" & Me.CobCStation.Text & "'  and Revid='" &
    '                                                      Me.dgvMain.CurrentRow.Cells("ColVer").Value & "'")
    '    For index As Integer = 0 To dt.Rows.Count - 1
    '        CobCScanId.Items.Add(dt.Rows(index)("ScanOrderid").ToString)
    '    Next
    'End Sub

    Private Sub ChbScanPallet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkScanPallet.CheckedChanged
        If Me.ChkScanPallet.Checked Then
            'Me.ChbCustPart.Enabled = True

            Me.ChkPalletSame.Enabled = True
        Else
            'Me.ChbCustPart.Enabled = False
            'Me.ChbCustPart.Checked = False

            Me.ChkPalletSame.Enabled = False
            Me.ChkPalletSame.Checked = False
        End If
    End Sub

    'Private Sub ckbIsCheckTestY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.ckbIsCheckTestY.Checked Then
    '        Me.ChbTestNum.Enabled = True
    '        Me.ChbTestNum.SelectedIndex = 0
    '    Else
    '        Me.ChbTestNum.Enabled = False
    '        Me.ChbTestNum.SelectedIndex = -1
    '    End If
    'End Sub


    Private Sub LblUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUp.Click
        Dim SqlStr As String = ""

        If Me.trvData.Nodes.Count = 0 OrElse Me.trvData.SelectedNode Is Nothing Then Exit Sub
        Select Case Me.trvData.SelectedNode.Level
            Case 0   '不允許上移根節點
                MessageBox.Show("根節點不能被上移！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Case 1   '工站上移，Update所有工站的順序
                If Me.trvData.SelectedNode.PrevNode Is Nothing Then Exit Sub
                SqlStr = "declare @CurrSta as int declare @PPartid as varchar(35) declare @Revid as int " _
                     & " set @PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' set @Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & " set @CurrSta=" & Me.trvData.SelectedNode.Tag.ToString.Trim _
                     & " Update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(),StaOrderid = 9999 where PPartid=@PPartid and Revid=@Revid and StaOrderid=@CurrSta " _
                     & " Update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(),StaOrderid=@CurrSta where PPartid=@PPartid and Revid=@Revid and StaOrderid=@CurrSta-1 " _
                     & " Update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(),StaOrderid=@CurrSta-1 where PPartid=@PPartid and Revid=@Revid and StaOrderid=9999 "
            Case 2   '上移掃描部件，Update該工站所有掃描部件的順序
                If Me.trvData.SelectedNode.PrevNode Is Nothing Then Exit Sub
                SqlStr = "declare @CurrScanid as int declare @PPartid as varchar(35) declare @Revid as int declare @Scanid as int " _
                     & " set @PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' set @Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & " set @CurrScanid=" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(0) & " set @Scanid=" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(1) _
                     & " Update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(),ScanOrderid = 9999 where PPartid=@PPartid and Revid=@Revid and StaOrderid=@CurrScanid and ScanOrderid=@Scanid " _
                     & " Update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(),ScanOrderid=@Scanid where PPartid=@PPartid and Revid=@Revid and StaOrderid=@CurrScanid and ScanOrderid=@Scanid-1 " _
                     & " Update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(),ScanOrderid=@Scanid-1 where PPartid=@PPartid and Revid=@Revid and StaOrderid=@CurrScanid and ScanOrderid=9999 "
        End Select
        If MessageBox.Show("請確認是否執行上移操作?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            DbOperateUtils.ExecSQL(SqlStr)
            MessageBox.Show("上移成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            Me.trvData.SelectedNode = Me.trvData.Nodes(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "btnDel_Click", "sys")
        End Try

    End Sub

    Private Sub LblDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblDown.Click
        Dim SqlStr As String = ""

        If Me.trvData.Nodes.Count = 0 OrElse Me.trvData.SelectedNode Is Nothing Then Exit Sub
        Select Case Me.trvData.SelectedNode.Level
            Case 0   '不允許下移根節點
                MessageBox.Show("根節點不能被下移！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Case 1   '工站下移，Update所有工站的順序
                If Me.trvData.SelectedNode.NextNode Is Nothing Then Exit Sub
                SqlStr = "declare @CurrSta as int declare @PPartid as varchar(35) declare @Revid as int " _
                     & " set @PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' set @Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & " set @CurrSta=" & Me.trvData.SelectedNode.Tag.ToString.Trim _
                     & " Update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(),StaOrderid = 9999 where PPartid=@PPartid and Revid=@Revid and StaOrderid=@CurrSta " _
                     & " Update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(),StaOrderid=@CurrSta where PPartid=@PPartid and Revid=@Revid and StaOrderid=@CurrSta+1 " _
                     & " Update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(),StaOrderid=@CurrSta+1 where PPartid=@PPartid and Revid=@Revid and StaOrderid=9999 "
            Case 2   '下移掃描部件，Update該工站所有掃描部件的順序
                If Me.trvData.SelectedNode.NextNode Is Nothing Then Exit Sub
                SqlStr = "declare @CurrScanid as int declare @PPartid as varchar(35) declare @Revid as int declare @Scanid as int " _
                     & " set @PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' set @Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & " set @CurrScanid=" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(0) & " set @Scanid=" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(1) _
                     & " Update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(),ScanOrderid = 9999 where PPartid=@PPartid and Revid=@Revid and StaOrderid=@CurrScanid and ScanOrderid=@Scanid " _
                     & " Update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(),ScanOrderid=@Scanid where PPartid=@PPartid and Revid=@Revid and StaOrderid=@CurrScanid and ScanOrderid=@Scanid+1 " _
                     & " Update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(),ScanOrderid=@Scanid+1 where PPartid=@PPartid and Revid=@Revid and StaOrderid=@CurrScanid and ScanOrderid=9999 "
        End Select
        If MessageBox.Show("請確認是否執行下移操作?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            DbOperateUtils.ExecSQL(SqlStr)
            MessageBox.Show("下移成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            Me.trvData.SelectedNode = Me.trvData.Nodes(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "btnDel_Click", "sys")
        End Try
    End Sub

    Private Sub LblSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblSave.Click
        Dim SqlStr As String = ""
        Dim oldTestId As String = ""
        If CheckDataForSave() = False Then Exit Sub
        If Me.trvData.SelectedNode Is Nothing Then Exit Sub
        ''''
        Dim IsNewTestID As Boolean = True
        Dim dt As DataTable = Nothing

        If Me.trvData.SelectedNode.Level = 2 AndAlso ckbIsCheckTestY.Checked Then
            SqlStr = "select TestTypeID from  m_RPartStationD_t where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "'  and Revid='" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and  IsCheckTestY='Y' and   StaOrderid='" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(0).Trim & "' and ScanOrderid='" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(1).Trim & "' "
            dt = DbOperateUtils.GetDataTable(SqlStr)
            If dt.Rows.Count > 0 Then
                oldTestId = dt.Rows(0)("TestTypeID").ToString().Trim()
                If ChbTestNum.Text.Trim() <> "" Then
                    If oldTestId.Split(";").Length = Int(ChbTestNum.Text.Trim()) Then ''通過“；”分隔出單個的測試ID，并判斷其個數是否改變
                        IsNewTestID = False
                    Else
                        IsNewTestID = True
                    End If
                Else
                    IsNewTestID = True
                End If
            Else
                IsNewTestID = True
            End If
        ElseIf Me.trvData.SelectedNode.Level = 1 Then
            IsNewTestID = True
        End If
        ''''''''''''''''''''''''''''
        'If Me.TxtSplitQty.Text.Trim = String.Empty Then Me.TxtSplitQty.Text = 0

        '拆分標識
        Dim SFlag As String = IIf(ChkSplit.Checked, "Y", "N")
        '自動關聯PCB標識
        Dim sRelatedFlag As String = IIf(ChkRelate.Checked, "Y", "N")
        Dim TestID As String
        If Me.ChbTestNum.Text = "" Then
            TestID = "0"
        Else
            TestID = Me.ChbTestNum.Text
        End If

        '************************田玉琳 20161103 开始 *****************************************************
        If IsBarcodeHaveSS() = True And ckbIsAllowRe.Checked = False Then
            Dim message As String = "扫描的条码为【流水产品条码】，请确认是否勾选条码序号是否唯一？" & vbCrLf & "确认自动勾选,并保存。"
            Dim btn As DialogResult = MessageBox.Show(message, "确认信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If btn = DialogResult.OK Then
                ckbIsAllowRe.Checked = True
            End If
        End If
        '************************田玉琳 20161103 结束 *****************************************************

        '************************田玉琳 20200414 开始 *****************************************************
        '田玉琳 20200414 开始
        '如生产料件检验设置错误或漏设置{/11}时，系统可依PQE录入料号进行卡控
        If IsPQECheck11() = False And chkRepeatStyle.Checked = True Then
            MessageUtils.ShowInformation("料件检验设置异常,条码检验参数要设置为11,请重新设置")
            Exit Sub
        End If
        '************************田玉琳 20200414 结束 *****************************************************

        'update語句加入update對應的站別ID和掃描次序 StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid 
        Select Case Me.trvData.SelectedNode.Level
            Case 0  '根節點''@CheckSupY varchar(1),@CheckStaorder varchar(50),@CheckScanorder int
                'Insert新工站，Update所有工站的主條碼信息
                'update by hgd 2018-04-03加入支持工站在线打印和编码原则
                SqlStr = "declare @MaxSta int,@PPartid varchar(35),@Revid as int,@Stationid varchar(6),@TPartid varchar(35),@TPartText nvarchar(20) " _
                    & " declare @IsPrtSelf varchar(1),@IsAllowRe varchar(1),@IsSemiProduct varchar(1),@IsScanN varchar(1),@ScanNumber int ,@IsCustPart varchar(1), @IsCheckTestY varchar(1),@TestID varchar(50),@IsPrtPacking varchar(1)," _
                    & " @IsOnlineGenCartonID varchar(1),@IsOnlineGenCartonID2 varchar(1),@IsLinePrintFullCode varchar(1),@IsLineWeight varchar(1),@RepeatStyle varchar(1),@RepeatPara varchar(200),@RepeatStyleC varchar(1),@CartonRepeatStyle varchar(1),@CartonRepeatPara varchar(200),@IsShowPacking varchar(1),@IsCheckTime varchar(1),@ShowPos int,@Userid varchar(10) " _
                    & ",@UpLimitWeight varchar(30),@LowLimitWeight varchar(30),@IsPpidLineWeight varchar(1),@PpidUpLimitWeight varchar(30),@PpidLowLimitWeight varchar(30),@BarePpidUpLimitWeight varchar(30),@BarePpidLowLimitWeight varchar(30) " _
                    & ",@IsCmby varchar(50),@IsUpDown varchar(50),@ContY varchar(50),@Asny varchar(50),@LinePrtY varchar(50),@Ismatch varchar(50),@splitbegin int,@splitend int,@CheckSupY varchar(1),@CheckStaorder varchar(50),@CheckScanorder int,@WorkCodeRuleID varchar(50) " _
                    & ",@IslineMbarcode varchar(1),@IsAllowNG varchar(1),@IsAllowNGQty int ,@NGqtySC varchar(1),@NGqtycount int ,@IsUsb varchar(1),@LabelNum int," _
                    & " @IsWritePCB varchar(1),@IsReadPCB varchar(1),@IsPackType varchar(1), @IsSamePacking varchar(1),@IsCartonSame varchar(1),@IsScanPallet varchar(1)," _
                    & " @IsPalletSame varchar(1),@IsPackingSame varchar(1),@IsPPackingProduct varchar(1),@IsCheckMo varchar(1),@IsAssemblySN varchar(1), @IsSSCC varchar(1), @IsOldKanBanCheck varchar(1),@chkIsOnlineGenPalletID varchar(1),@IsPrtSelfCarton varchar(1) ,@IsPrtSelfPallet VARCHAR(1),@IsOnlineWorkPrint  VARCHAR(1),@IsNotCaseSensitive  VARCHAR(1),@BigCartonRepeatStyle varchar(1),@BigCartonRepeatPara varchar(200), " _
                    & " @IsQCPlan varchar(1),@QCPlanId int , @IsQCCheckOut varchar(1), @IsCheckLink varchar(1)" _
                    & " set @PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' " _
                    & " set @Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim _
                    & " set @Stationid='" & Me.txtStationid.Text.Trim & "' " _
                    & " set @TPartid='" & Me.txtTPartid.Text.Trim & "' " _
                    & " set @TPartText=N'" & Me.txtTPartText.Text.Trim & "' " _
                    & " set @IsPrtSelf='" & IIf(Me.ckbIsPrtSelf.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowRe='" & IIf(Me.ckbIsAllowRe.Checked = True, "Y", "N") & "' " _
                    & " set @IsSemiProduct='" & IIf(Me.chkIsSemiProduct.Checked = True, "Y", "N") & "' " _
                    & " set @IsScanN='" & IIf(Me.chkIsScanN.Checked = True, "Y", "N") & "' " _
                    & " set @ScanNumber='" & Me.TextBoxUL1.Text.Trim & "' " _
                    & " set @IsCustPart='" & IIf(Me.ChbCustPart.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckTestY='" & IIf(Me.ckbIsCheckTestY.Checked = True, "Y", "N") & "' " _
                    & " set @TestID=case @IsCheckTestY when 'Y' then dbo.FunCreateTestID1(" & TestID & ") else '' end  " _
                    & " set @IsPrtPacking='" & IIf(Me.ChkIsPrtPacking.Checked = True, "Y", "N") & "' " _
                    & " set @IsOnlineGenCartonID='" & IIf(Me.chkIsOnlineGenCartonID.Checked = True, "Y", "N") & "' " _
                    & " set @IsOnlineGenCartonID2='" & IIf(Me.chkIsOnlineGenCartonID2.Checked = True, "Y", "N") & "' " _
                    & " set @chkIsOnlineGenPalletID='" & IIf(Me.chkIsOnlineGenPalletID.Checked = True, "Y", "N") & "'" _
                    & " set @IsPrtSelfCarton='" & IIf(Me.ChkIsPrtSelfCarton.Checked = True, "Y", "N") & "'" _
                    & " SET @IsPrtSelfPallet='" & IIf(Me.IsPrtSelfPallet.Checked = True, "Y", "N") & "'" _
                    & " set @IsLinePrintFullCode='" & IIf(Me.chkIsLinePrintFullCode.Checked = True, "Y", "N") & "' " _
                    & " set @IsLineWeight='" & IIf(Me.chkIsLineWeight.Checked = True, "Y", "N") & "' " _
                    & " set @IsPpidLineWeight='" & IIf(Me.chkIsPpidLineWeight.Checked = True, "Y", "N") & "' " _
                    & " set @RepeatStyle='" & IIf(Me.chkRepeatStyle.Checked = True, "Y", "N") & "' " _
                    & " set @RepeatStyleC='" & IIf(Me.chkRepeatStyleC.Checked = True, "Y", "N") & "' " _
                    & " set @RepeatPara='" & Me.txtRepeatPara.Text & "' " _
                    & " set @CartonRepeatStyle='" & IIf(Me.chkCartonRepeatStyle.Checked = True, "Y", "N") & "' " _
                    & " set @CartonRepeatPara='" & Me.txtCartonRepeatPara.Text & "' " _
                    & " set @BigCartonRepeatStyle='" & IIf(Me.chkBigCartonRepeatStyle.Checked = True, "Y", "N") & "' " _
                    & " set @BigCartonRepeatPara='" & Me.txtBigCartonRepeatPara.Text & "' " _
                    & " set @LabelNum='" & Me.TxtLabelNum.Text & "' " _
                    & " set @IsShowPacking='" & IIf(Me.ckbIsShowPacking.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckTime='" & IIf(Me.Checktime.Checked = True, "Y", "N") & "' " _
                    & " set @IsCmby='" & IIf(Me.RadNmerger.Checked = True, "0", IIf(Me.RadQmerger.Checked = True, "1", "2")) & "' " _
                    & " set @IsUpDown='" & IIf(Me.ckbIsUpMaterial.Checked = True, "Y", "N") & "' " _
                    & " set @ContY='" & IIf(Me.ChkIsContinual.Checked = True, "Y", "N") & "' " _
                    & " set @Asny='" & IIf(Me.ChkASN.Checked = True, "Y", "N") & "' " _
                    & " set @LinePrtY='" & IIf(Me.ChkTTprint.Checked = True, "Y", "N") & "' " _
                    & " set @Ismatch='" & IIf(Me.Chkmatch.Checked = True, "Y", "N") & "' " _
                    & " set @splitbegin='" & IIf(Me.Chkmatch.Checked = True, Me.TxtSpiltBegin.Text, 0) & "' " _
                    & " set @splitend='" & IIf(Me.Chkmatch.Checked = True, Me.TxtSpiltEnd.Text, 0) & "' " _
                    & " set @CheckSupY='" & IIf(Me.ChkSupplier.Checked = True, "Y", "N") & "' " _
                    & " set @IslineMbarcode='" & IIf(Me.ChkLinePinrtM.Checked = True, "Y", "N") & "' " _
                    & " set @IsUsb='" & IIf(Me.ChkUsb.Checked = True, "Y", "N") & "' " _
                    & " set @IsPackType='" & IIf(Me.ChkPackingType.Checked = True, "Y", "N") & "' " _
                    & " set @IsSamePacking='" & IIf(Me.ChkSamePacking.Checked = True, "Y", "N") & "' " _
                    & " set @IsCartonSame='" & IIf(Me.ChkCartonSame.Checked = True, "Y", "N") & "' " _
                    & " set @IsScanPallet='" & IIf(Me.ChkScanPallet.Checked = True, "Y", "N") & "' " _
                    & " set @IsPalletSame='" & IIf(Me.ChkPalletSame.Checked = True, "Y", "N") & "' " _
                    & " set @IsPackingSame='" & IIf(Me.ChkCartonSame.Checked = True, "Y", "N") & "' " _
                    & " set @IsReadPCB='" & IIf(Me.ChkReadPCB.Checked = True, "Y", "N") & "' " _
                    & " set @IsWritePCB='" & IIf(Me.ChkWritePCB.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowNG='" & IIf(Me.CheckNcount.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowNGQty='" & IIf(Me.CheckNcount.Checked = True, Me.TxtNGcount.Text, "") & "' " _
                    & " set @IsPPackingProduct='" & IIf(Me.ChkSamePacking.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckMo='" & IIf(Me.ChkMo.Checked = True, "Y", "N") & "' " _
                    & " set @IsAssemblySN='" & IIf(Me.ChkAssemblySN.Checked = True, "Y", "N") & "' " _
                    & " set @IsSSCC='" & IIf(Me.chkParitySSCC.Checked = True, "Y", "N") & "' " _
                    & " set @NGqtySC='" & IIf(Me.ChkClaQty.Checked = True, "Y", "N") & "' " _
                    & " set @NGqtycount='" & IIf(Me.CheckNcount.Checked = True, Me.TxtClaQty.Text, "") & "' " _
                    & " set @CheckStaorder='" & IIf(Me.ChkSupplier.Checked = True, Me.CobCStation.Text, "") & "' " _
                    & " set @CheckScanorder='" & IIf(Me.ChkSupplier.Checked = True, Me.CobCScanId.Text, "") & "' " _
                    & " set @ShowPos='" & IIf(Me.ckbIsShowPacking.Checked = True, Me.CboShowP.Text.Trim, 0) & "' " _
                    & " set @Userid='" & SysMessageClass.UseId.Trim.ToLower & "' " _
                    & " set @UpLimitWeight='" & txtUpLimitWeight.Text & "' " _
                    & " set @LowLimitWeight='" & txtLowLimitWeight.Text & "' " _
                    & " set @PpidUpLimitWeight='" & txtPpidUpLimitWeight.Text & "' " _
                    & " set @PpidLowLimitWeight='" & txtPpidLowLimitWeight.Text & "' " _
                    & " set @BarePpidUpLimitWeight='" & txtBarePpidUpLimitWeight.Text & "' " _
                    & " set @BarePpidLowLimitWeight='" & txtBarePpidLowLimitWeight.Text & "' " _
                    & " set @IsOldKanBanCheck = '" & IIf(Me.ChkOldKanBanCheck.Checked = True, "Y", "N") & "' " _
                    & " set @IsOnlineWorkPrint = '" & IIf(Me.ckIsOnlineWorkPrint.Checked = True, "Y", "N") & "' " _
                    & " set @IsNotCaseSensitive = '" & IIf(Me.chkIsNotCaseSensitive.Checked = True, "Y", "N") & "' " _
                    & " set @IsQCPlan = '" & IIf(Me.chkQCPlan.Checked = True, "Y", "N") & "' " _
                    & " set @IsQCCheckOut = '" & IIf(Me.chkQCCheckOut.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckLink = '" & IIf(Me.chkIsCheckLink.Checked = True, "Y", "N") & "' " _
                    & " select @MaxSta=Max(StaOrderid) from dbo.m_RPartStationD_t where PPartid=@PPartid and Revid=@Revid " _
                    & " insert dbo.m_RPartStationD_t(PPartid, Revid, StaOrderid, ScanOrderid, Stationid, TPartid, TPartText,IsReplaceable,ReplaceID, " _
                    & " IsMainBarcode,IsPrtSelf, IsAllowRe ,IsSemiProduct,IsScanN,ScanNumber,IsScanPallet,IsCustPart,  IsCheckTestY, IsPrtPacking,IsOnlineGenCartonID,IsOnlineGenCartonID2,IsLinePrintFullCode,LabelNum,IsLineWeight,RepeatStyle,RepeatPara,RepeatStyleC,CartonRepeatStyle,CartonRepeatPara,IsShowPacking,isendsta,ShowColPos, State, UserID, " _
                    & " Intime,Cmby,IsUpDown,testtypeid,IsSplit,SplitQty,IsRelated,ContY,ASNY,LinePrtY,Ismatch,splitbegin,splitend,CheckSupY,CheckStaorder,CheckScanorder, " _
                    & " IslineMbarcode,IsAllowNG,IsAllowNGQty,NGqtySC,NGqtycount,IsUsb,isRplacePath,IsPackingSame,IsWritePCB,IsReadPCB,IsPalletSame,IsPackType," _
                    & " IsPPackingProduct,IsCheckMoForCarton,IsCartonSame,IsAssemblySN, IsSSCC, CodeRuleID,CodeRuleID2, IsOldKanBanCheck,chkIsOnlineGenPalletID,IsPrtSelfCarton,ISPRTSELFPALLET,IsOnlineWorkPrint,WorkCodeRuleID,UpLimitWeight,LowLimitWeight,IsPpidLineWeight,PpidUpLimitWeight,PpidLowLimitWeight,BarePpidUpLimitWeight,BarePpidLowLimitWeight,IsNotCaseSensitive,BigCartonRepeatStyle,BigCartonRepeatPara,IsQCPlan,QCPlanId,IsQCCheckOut,IsCheckLink) " _
                    & " values(@PPartid,@Revid,isnull(@MaxSta+1,1),1,@Stationid,@TPartid,@TPartText,'N',NULL,'Y',@IsPrtSelf,@IsAllowRe,@IsSemiProduct,@IsScanN,@ScanNumber,@IsScanPallet,@IsCustPart," _
                    & " @IsCheckTestY,@IsPrtPacking,@IsOnlineGenCartonID,@IsOnlineGenCartonID2,@IsLinePrintFullCode,@LabelNum,@IsLineWeight,@RepeatStyle,@RepeatPara,@RepeatStyleC, @CartonRepeatStyle,@CartonRepeatPara, @IsShowPacking,@IsCheckTime,@ShowPos,'0',@Userid,getdate(),@IsCmby,@IsUpDown,@TestID,'" & SFlag & "','" & IIf(TxtSplitQty.Checked, "Y", "N") & "'," _
                    & " '" & sRelatedFlag & "',@ContY,@Asny,@LinePrtY,@Ismatch,@splitbegin,@splitend,@CheckSupY,@CheckStaorder,@CheckScanorder,@IslineMbarcode, " _
                    & " @IsAllowNG ,@IsAllowNGQty,@NGqtySC,@NGqtycount,@IsUsb,'" & "RPrintFile\" & txtPartid.Text.Trim & "\" & FileNameStr & "',@IsPackingSame,@IsWritePCB," _
                    & " @IsReadPCB,@IsPalletSame,@IsPackType,@IsPPackingProduct,@IsCheckMo,@IsCartonSame,@IsAssemblySN, @IsSSCC, '" _
                    & IIf(Me.cboPack.SelectedValue Is Nothing, "", Me.cboPack.Text) & "','" & IIf(Me.cboPack2.SelectedValue Is Nothing, "", Me.cboPack2.Text) & "', @IsOldKanBanCheck,@chkIsOnlineGenPalletID,@IsPrtSelfCarton,@ISPRTSELFPALLET, " _
                    & " @IsOnlineWorkPrint,'" & IIf(Me.cboWorkCodeRuleId.SelectedValue Is Nothing, "", Me.cboWorkCodeRuleId.Text) & "',@UpLimitWeight,@LowLimitWeight,@IsPpidLineWeight,@PpidUpLimitWeight,@PpidLowLimitWeight,@BarePpidUpLimitWeight,@BarePpidLowLimitWeight,@IsNotCaseSensitive,@BigCartonRepeatStyle,@BigCartonRepeatPara," _
                    & " @IsQCPlan ,'" & IIf(Me.CobQCPlan.SelectedValue Is Nothing, "", Me.CobQCPlan.SelectedValue) & "',@IsQCCheckOut,@IsCheckLink)"
                '當主條碼兩站設置屬性不一致會產生update問題，故註釋
            Case 1  '工站節點
                'Insert新部件條碼
                SqlStr = "declare @MaxItemid int,@MaxScanid int,@IsReplaceable varchar(1),@ReplaceID varchar(12),@TestID varchar(50),@PPartid varchar(35),@Revid int,@StaOrderid int " _
                    & " declare @Stationid varchar(6),@TPartid varchar(35),@TPartText nvarchar(20),@ContY varchar(50),@Asny varchar(50),@LinePrtY varchar(50),@Ismatch varchar(50),@splitbegin int,@splitend int,@CheckSupY varchar(1),@CheckStaorder varchar(50),@CheckScanorder int  " _
                    & " declare @IsPrtSelf varchar(1),@IsAllowRe varchar(1),@IsSemiProduct varchar(1),@IsScanN varchar(1), @ScanNumber int ,@IsCustPart varchar(1),@IsCheckTestY varchar(1),@IsPrtPacking varchar(1),@WorkCodeRuleID varchar(50)," _
                    & " @IsOnlineGenCartonID varchar(1),@IsOnlineGenCartonID2 varchar(1),@IsLinePrintFullCode varchar(1),@LabelNum int,@IsLineWeight varchar(1),@RepeatStyle varchar(1),@RepeatPara varchar(200),@RepeatStyleC varchar(1),@CartonRepeatStyle varchar(1),@CartonRepeatPara varchar(200),@IsShowPacking varchar(1),@IsCheckTime varchar(1),@ShowPos int,@Userid varchar(10),@IsCmby varchar(50),@IsUpDown varchar(50) " _
                    & ",@IslineMbarcode varchar(1),@IsAllowNG varchar(1),@IsAllowNGQty int ,@NGqtySC varchar(1),@NGqtycount int ,@IsUsb varchar(1),@IsWritePCB varchar(1),@IsReadPCB varchar(1),@IsPPackingProduct varchar(1),@IsCheckMo varchar(1),@UpLimitWeight varchar(30),@LowLimitWeight varchar(30),@IsPpidLineWeight varchar(1),@PpidUpLimitWeight varchar(30) ,@PpidLowLimitWeight varchar(30),@BarePpidUpLimitWeight varchar(30) ,@BarePpidLowLimitWeight varchar(30) " _
                    & ",@IsPackType varchar(1), @IsSamePacking varchar(1),@IsCartonSame varchar(1),@IsScanPallet varchar(1),@IsPalletSame varchar(1),@IsPackingSame varchar(1),@IsAssemblySN varchar(1), @IsSSCC varchar(1), @IsOldKanBanCheck varchar(1),@chkIsOnlineGenPalletID VARCHAR(1),@IsPrtSelfCarton varchar(1),@IsPrtSelfPallet VARCHAR(1),@IsOnlineWorkPrint  VARCHAR(1) ,@IsNotCaseSensitive  VARCHAR(1),@BigCartonRepeatStyle varchar(1),@BigCartonRepeatPara varchar(200)" _
                    & ",@IsQCPlan varchar(1),@QCPlanId int, @IsQCCheckOut varchar(1), @IsCheckLink varchar(1) " _
                    & " set @IsReplaceable='" & IIf(Me.LstPartSum.Items.Count > 0, "Y", "N") & "' " _
                    & " set @ReplaceID=case @IsReplaceable when 'Y' then dbo.FunCreateReplaceID() else '' end " _
                    & " set @PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' " _
                    & " set @Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim _
                    & " set @StaOrderid=" & Me.trvData.SelectedNode.Tag.ToString.Trim _
                    & " set @Stationid='" & Me.txtStationid.Text.Trim & "' " _
                    & " set @TPartid='" & Me.txtTPartid.Text.Trim & "' " _
                    & " set @TPartText=N'" & Me.txtTPartText.Text.Trim & "' " _
                    & " set @IsPrtSelf='" & IIf(Me.ckbIsPrtSelf.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowRe='" & IIf(Me.ckbIsAllowRe.Checked = True, "Y", "N") & "' " _
                    & " set @IsSemiProduct='" & IIf(Me.chkIsSemiProduct.Checked = True, "Y", "N") & "' " _
                    & " set @IsScanN='" & IIf(Me.chkIsScanN.Checked = True, "Y", "N") & "' " _
                    & " set @ScanNumber='" & Me.TextBoxUL1.Text.Trim & "' " _
                    & " set @IsCustPart='" & IIf(Me.ChbCustPart.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckTestY='" & IIf(Me.ckbIsCheckTestY.Checked = True, "Y", "N") & "' "
                If IsNewTestID = True Then '
                    If ckbIsCheckTestY.Checked Then  '不需校驗測試結果時，不產生測試ID
                        SqlStr = SqlStr + " set @TestID=case @IsCheckTestY when 'Y' then dbo.FunCreateTestID1(" & TestID & ") else '' end "
                    Else
                        SqlStr = SqlStr + " set @TestID=''"
                    End If
                Else
                    SqlStr = SqlStr + " set @TestID='" & oldTestId & "'"
                End If
                SqlStr = SqlStr & " set @IsShowPacking='" & IIf(Me.ckbIsShowPacking.Checked = True, "Y", "N") & "' " _
                    & " set @IsPrtPacking='" & IIf(Me.ChkIsPrtPacking.Checked = True, "Y", "N") & "' " _
                    & " set @IsOnlineGenCartonID='" & IIf(Me.chkIsOnlineGenCartonID.Checked = True, "Y", "N") & "' " _
                    & " set @IsOnlineGenCartonID2='" & IIf(Me.chkIsOnlineGenCartonID2.Checked = True, "Y", "N") & "' " _
                    & " set @IsLinePrintFullCode='" & IIf(Me.chkIsLinePrintFullCode.Checked = True, "Y", "N") & "' " _
                    & " set @IsLineWeight='" & IIf(Me.chkIsLineWeight.Checked = True, "Y", "N") & "' " _
                     & " set @IsPpidLineWeight='" & IIf(Me.chkIsPpidLineWeight.Checked = True, "Y", "N") & "' " _
                    & " set @RepeatStyle='" & IIf(Me.chkRepeatStyle.Checked = True, "Y", "N") & "' " _
                    & " set @RepeatStyleC='" & IIf(Me.chkRepeatStyleC.Checked = True, "Y", "N") & "' " _
                    & " set @RepeatPara='" & Me.txtRepeatPara.Text & "' " _
                    & " set @CartonRepeatStyle='" & IIf(Me.chkCartonRepeatStyle.Checked = True, "Y", "N") & "' " _
                    & " set @CartonRepeatPara='" & Me.txtCartonRepeatPara.Text & "' " _
                    & " set @BigCartonRepeatStyle='" & IIf(Me.chkBigCartonRepeatStyle.Checked = True, "Y", "N") & "' " _
                    & " set @BigCartonRepeatPara='" & Me.txtBigCartonRepeatPara.Text & "' " _
                    & " set @LabelNum='" & Me.TxtLabelNum.Text & "' " _
                    & " set @IsCheckTime='" & IIf(Me.Checktime.Checked = True, "Y", "N") & "' " _
                    & " set @IsCmby='" & IIf(Me.RadNmerger.Checked = True, "0", IIf(Me.RadQmerger.Checked = True, "1", "2")) & "' " _
                    & " set @IsUpDown='" & IIf(Me.ckbIsUpMaterial.Checked = True, "Y", "N") & "' " _
                    & " set @ContY='" & IIf(Me.ChkIsContinual.Checked = True, "Y", "N") & "' " _
                    & " set @Asny='" & IIf(Me.ChkASN.Checked = True, "Y", "N") & "' " _
                    & " set @LinePrtY='" & IIf(Me.ChkTTprint.Checked = True, "Y", "N") & "' " _
                    & " set @Ismatch='" & IIf(Me.Chkmatch.Checked = True, "Y", "N") & "' " _
                    & " set @splitbegin='" & IIf(Me.Chkmatch.Checked = True, Me.TxtSpiltBegin.Text, 0) & "' " _
                    & " set @splitend='" & IIf(Me.Chkmatch.Checked = True, Me.TxtSpiltEnd.Text, 0) & "' " _
                    & " set @CheckSupY='" & IIf(Me.ChkSupplier.Checked = True, "Y", "N") & "' " _
                    & " set @CheckStaorder='" & IIf(Me.ChkSupplier.Checked = True, Me.CobCStation.Text, "") & "' " _
                    & " set @CheckScanorder='" & IIf(Me.ChkSupplier.Checked = True, Me.CobCScanId.Text, "") & "' " _
                    & " set @ShowPos=" & IIf(Me.ckbIsShowPacking.Checked = True, Me.CboShowP.Text.Trim, 0) _
                    & " set @IslineMbarcode='" & IIf(Me.ChkLinePinrtM.Checked = True, "Y", "N") & "' " _
                    & " set @IsUsb='" & IIf(Me.ChkUsb.Checked = True, "Y", "N") & "' " _
                    & " set @IsPackType='" & IIf(Me.ChkPackingType.Checked = True, "Y", "N") & "' " _
                    & " set @IsSamePacking='" & IIf(Me.ChkSamePacking.Checked = True, "Y", "N") & "' " _
                    & " set @IsCartonSame='" & IIf(Me.ChkCartonSame.Checked = True, "Y", "N") & "' " _
                    & " set @IsScanPallet='" & IIf(Me.ChkScanPallet.Checked = True, "Y", "N") & "' " _
                    & " set @IsPalletSame='" & IIf(Me.ChkPalletSame.Checked = True, "Y", "N") & "' " _
                    & " set @IsPackingSame='" & IIf(Me.ChkCartonSame.Checked = True, "Y", "N") & "' " _
                    & " set @IsPPackingProduct='" & IIf(Me.ChkSamePacking.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckMo='" & IIf(Me.ChkMo.Checked = True, "Y", "N") & "' " _
                    & " set @IsAssemblySN='" & IIf(Me.ChkAssemblySN.Checked = True, "Y", "N") & "' " _
                    & " set @IsSSCC='" & IIf(Me.chkParitySSCC.Checked = True, "Y", "N") & "' " _
                    & " set @IsReadPCB='" & IIf(Me.ChkReadPCB.Checked = True, "Y", "N") & "' " _
                    & " set @IsWritePCB='" & IIf(Me.ChkWritePCB.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowNG='" & IIf(Me.CheckNcount.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowNGQty='" & IIf(Me.CheckNcount.Checked = True, Me.TxtNGcount.Text, "") & "' " _
                    & " set @NGqtySC='" & IIf(Me.ChkClaQty.Checked = True, "Y", "N") & "' " _
                    & " set @NGqtycount='" & IIf(Me.CheckNcount.Checked = True, Me.TxtClaQty.Text, "") & "' " _
                    & " set @Userid='" & SysMessageClass.UseId.Trim.ToLower & "' " _
                    & " set @IsOldKanBanCheck = '" & IIf(Me.ChkOldKanBanCheck.Checked = True, "Y", "N") & "' " _
                    & "  set @chkIsOnlineGenPalletID='" & IIf(Me.chkIsOnlineGenPalletID.Checked = True, "Y", "N") & "'" _
                    & "  set @IsPrtSelfCarton='" & IIf(Me.ChkIsPrtSelfCarton.Checked = True, "Y", "N") & "'" _
                    & "  set @ISPRTSELFPALLET='" & IIf(Me.IsPrtSelfPallet.Checked = True, "Y", "N") & "'" _
                    & " set @IsOnlineWorkPrint = '" & IIf(Me.ckIsOnlineWorkPrint.Checked = True, "Y", "N") & "' " _
                    & " set @UpLimitWeight='" & txtUpLimitWeight.Text & "' " _
                    & " set @LowLimitWeight='" & txtLowLimitWeight.Text & "' " _
                    & " set @PpidUpLimitWeight='" & txtPpidUpLimitWeight.Text & "' " _
                    & " set @PpidLowLimitWeight='" & txtPpidLowLimitWeight.Text & "' " _
                    & " set @BarePpidUpLimitWeight='" & txtBarePpidUpLimitWeight.Text & "' " _
                    & " set @BarePpidLowLimitWeight='" & txtBarePpidLowLimitWeight.Text & "' " _
                    & " set @IsNotCaseSensitive = '" & IIf(Me.chkIsNotCaseSensitive.Checked = True, "Y", "N") & "' " _
                    & " set @IsQCPlan = '" & IIf(Me.chkQCPlan.Checked = True, "Y", "N") & "' " _
                    & " set @IsQCCheckOut = '" & IIf(Me.chkQCCheckOut.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckLink = '" & IIf(Me.chkIsCheckLink.Checked = True, "Y", "N") & "' " _
                    & " select @MaxScanid=Max(ScanOrderid) from dbo.m_RPartStationD_t where PPartid=@PPartid and Revid=@Revid and StaOrderid=@StaOrderid " _
                    & " insert dbo.m_RPartStationD_t(PPartid, Revid, StaOrderid, ScanOrderid, Stationid, TPartid, TPartText,IsReplaceable,ReplaceID, IsMainBarcode, " _
                    & " IsPrtSelf, IsAllowRe,IsSemiProduct,IsScanN,ScanNumber,IsCustPart, IsCheckTestY, IsPrtPacking,IsOnlineGenCartonID,IsOnlineGenCartonID2,IsLinePrintFullCode,LabelNum,IsLineWeight,RepeatStyle,RepeatPara,RepeatStyleC,CartonRepeatStyle,CartonRepeatPara,IsShowPacking,isendsta,ShowColPos, State, UserID, Intime,Cmby,IsUpDown,testtypeid," _
                    & " IsSplit,SplitQty,IsRelated,ContY,ASNY,LinePrtY,Ismatch,splitbegin,splitend,CheckSupY,CheckStaorder,CheckScanorder" _
                    & " ,IslineMbarcode,IsAllowNG,IsAllowNGQty,NGqtySC,NGqtycount,IsUsb,isRplacePath,IsWritePCB,IsReadPCB,IsPackType,IsSamePacking," _
                    & " IsCartonSame,IsScanPallet,IsPalletSame,IsPPackingProduct,IsCheckMoForCarton,IsPackingSame,IsAssemblySN, IsSSCC, IsOnlineWorkPrint,CodeRuleID,CodeRuleID2,IsOldKanBanCheck,chkIsOnlineGenPalletID,IsPrtSelfCarton,ISPRTSELFPALLET,WorkCodeRuleID,UpLimitWeight,LowLimitWeight,IsPpidLineWeight,PpidUpLimitWeight,PpidLowLimitWeight,BarePpidUpLimitWeight,BarePpidLowLimitWeight," _
                    & " IsNotCaseSensitive,BigCartonRepeatStyle,BigCartonRepeatPara,IsQCPlan,QCPlanId,IsQCCheckOut,IsCheckLink) " _
                    & " VALUES(@PPartid,@Revid,@StaOrderid,isnull(@MaxScanid+1,1),@Stationid,@TPartid,@TPartText,@IsReplaceable,@ReplaceID,'N',@IsPrtSelf,@IsAllowRe,@IsSemiProduct,@IsScanN," _
                    & " @ScanNumber  ,@IsCustPart ,@IsCheckTestY,@IsPrtPacking,@IsOnlineGenCartonID,@IsOnlineGenCartonID2,@IsLinePrintFullCode,@LabelNum,@IsLineWeight,@RepeatStyle,@RepeatPara,@RepeatStyleC, @CartonRepeatStyle,@CartonRepeatPara, @IsShowPacking,@IsCheckTime,@ShowPos,'0',@Userid,getdate(),@IsCmby,@IsUpDown,@TestID,'" & SFlag & "'," _
                    & " '" & IIf(TxtSplitQty.Checked, "Y", "N") & "','" & sRelatedFlag & "',@ContY,@Asny,@LinePrtY,@Ismatch,@splitbegin,@splitend,@CheckSupY,@CheckStaorder,@CheckScanorder, " _
                    & " @IslineMbarcode,@IsAllowNG,@IsAllowNGQty,@NGqtySC,@NGqtycount,@IsUsb,'" & "RPrintFile\" & txtPartid.Text.Trim & "\" & FileNameStr & "',@IsWritePCB,@IsReadPCB,@IsPackType," _
                    & " @IsSamePacking,@IsCartonSame,@IsScanPallet,@IsPalletSame,@IsPPackingProduct,@IsCheckMo,@IsPackingSame,@IsAssemblySN, @IsSSCC,@IsOnlineWorkPrint, '" _
                    & IIf(Me.cboPack.SelectedValue Is Nothing, "", Me.cboPack.Text) & "','" & IIf(Me.cboPack2.SelectedValue Is Nothing, "", Me.cboPack2.Text) & "', @IsOldKanBanCheck,@chkIsOnlineGenPalletID,@IsPrtSelfCarton,@ISPRTSELFPALLET, '" _
                    & IIf(Me.cboWorkCodeRuleId.SelectedValue Is Nothing, "", Me.cboWorkCodeRuleId.Text) & "',@UpLimitWeight,@LowLimitWeight,@IsPpidLineWeight,@PpidUpLimitWeight,@PpidLowLimitWeight,@BarePpidUpLimitWeight,@BarePpidLowLimitWeight,@IsNotCaseSensitive, @BigCartonRepeatStyle,@BigCartonRepeatPara," _
                    & " @IsQCPlan ,'" & IIf(Me.CobQCPlan.SelectedValue Is Nothing, "", Me.CobQCPlan.SelectedValue) & "',@IsQCCheckOut,@IsCheckLink)"
                If Me.LstPartSum.Items.Count > 0 Then
                    For i As Integer = 0 To Me.LstPartSum.Items.Count - 1
                        SqlStr = SqlStr & ControlChars.CrLf & " select @MaxItemid=Max(itemid) from dbo.m_RPartStationT_t where ReplaceID=@ReplaceID " _
                           & " insert m_RPartStationT_t(ReplaceID, Itemid, TPartid, UserID, Intime) values(@ReplaceID,isnull(@MaxItemid+1,1)," _
                           & " '" & Me.LstPartSum.Items.Item(i).ToString.Trim & "',@Userid,getdate())"
                    Next
                End If
            Case 2  '部件條碼節點
                'Update原有部件條碼信息
                SqlStr = "declare @MaxItemid int,@IsReplaceable varchar(1),@ReplaceID varchar(12),@TestID varchar(50),@PPartid varchar(35),@Revid int,@StaOrderid int " _
                    & " declare @Stationid varchar(6),@TPartid varchar(35),@TPartText nvarchar(20),@ScanOrderid int,@ContY varchar(50),@Asny varchar(50)," _
                    & " @LinePrtY varchar(50),@Ismatch varchar(50),@splitbegin int,@splitend int,@CheckSupY varchar(1),@CheckStaorder varchar(50),@CheckScanorder int " _
                    & " declare @IsPrtSelf varchar(1),@IsAllowRe varchar(1),@IsSemiProduct varchar(1),@IsScanN varchar(1),@ScanNumber int ,@IsCustPart varchar(1),@IsCheckTestY varchar(1),@IsPrtPacking varchar(1)," _
                    & " @IsOnlineGenCartonID varchar(1),@IsOnlineGenCartonID2 varchar(1),@IsLinePrintFullCode varchar(1),@LabelNum int,@IsLineWeight varchar(1), " _
                    & " @RepeatStyle varchar(1),@RepeatPara varchar(200),@RepeatStyleC varchar(1), @CartonRepeatStyle varchar(1),@CartonRepeatPara varchar(200),@IsShowPacking varchar(1), " _
                    & " @IsCheckTime varchar(1),@ShowPos int,@Userid varchar(10),@IsCmby varchar(50),@IsUpDown varchar(50) ,@IsOnlineWorkPrint  VARCHAR(1),@WorkCodeRuleID varchar(50) " _
                    & ",@IslineMbarcode varchar(1),@IsAllowNG varchar(1),@IsAllowNGQty int ,@NGqtySC varchar(1),@NGqtycount int ,@IsUsb varchar(1)" _
                    & ",@IsPackType varchar(1), @IsSamePacking varchar(1),@IsCartonSame varchar(1),@IsScanPallet varchar(1),@IsPalletSame varchar(1),@IsPackingSame varchar(1)," _
                    & "@UpLimitWeight varchar(30),@LowLimitWeight varchar(30),@IsPpidLineWeight varchar(1),@PpidUpLimitWeight varchar(30) ,@PpidLowLimitWeight varchar(30),@BarePpidUpLimitWeight varchar(30) ,@BarePpidLowLimitWeight varchar(30), " _
                    & " @IsWritePCB varchar(1),@IsReadPCB varchar(1),@IsPPackingProduct varchar(1),@IsCheckMo nvarchar(1),@IsAssemblySN varchar(1), @IsSSCC varchar(1), @IsOldKanBanCheck varchar(1),@chkIsOnlineGenPalletID VARCHAR(1),@IsPrtSelfCarton varchar(1),@ISPRTSELFPALLET VARCHAR(1) ," _
                    & " @IsNotCaseSensitive VARCHAR(1),@BigCartonRepeatStyle varchar(1),@BigCartonRepeatPara varchar(200),@IsQCPlan varchar(1),@QCPlanId int,@IsQCCheckOut varchar(1),@IsCheckLink varchar(1)" _
                    & " set @IsReplaceable='" & IIf(Me.LstPartSum.Items.Count > 0, "Y", "N") & "' " _
                    & " set @ReplaceID=case @IsReplaceable when 'Y' then dbo.FunCreateReplaceID() else '' end " _
                    & " set @PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' " _
                    & " set @Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim _
                    & " set @StaOrderid=" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(0).Trim _
                    & " set @ScanOrderid=" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(1).Trim _
                    & " set @Stationid='" & Me.txtStationid.Text.Trim & "' " _
                    & " set @TPartid='" & Me.txtTPartid.Text.Trim & "' " _
                    & " set @TPartText=N'" & Me.txtTPartText.Text.Trim & "' " _
                    & " set @IsPrtSelf='" & IIf(Me.ckbIsPrtSelf.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowRe='" & IIf(Me.ckbIsAllowRe.Checked = True, "Y", "N") & "' " _
                    & " set @IsSemiProduct='" & IIf(Me.chkIsSemiProduct.Checked = True, "Y", "N") & "' " _
                    & " set @IsScanN='" & IIf(Me.chkIsScanN.Checked = True, "Y", "N") & "' " _
                    & " set @ScanNumber='" & Me.TextBoxUL1.Text.Trim & "' " _
                    & " set @IsCustPart='" & IIf(Me.ChbCustPart.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckTestY='" & IIf(Me.ckbIsCheckTestY.Checked = True, "Y", "N") & "' "
                If IsNewTestID = True Then '多個測試ID
                    If ckbIsCheckTestY.Checked Then  '不需校驗測試結果時，不產生測試ID
                        SqlStr = SqlStr + " set @TestID=case @IsCheckTestY when 'Y' then dbo.FunCreateTestID1(" & TestID & ") else '' end "
                    End If
                Else
                    SqlStr = SqlStr + " set @TestID='" & oldTestId & "'"
                End If
                'Add update TPartText when CurrScan = "1" by Aimee 20150312, enable to change PN Des(CurrScan = "1", 可能是制程条码也可能是成品条码)
                SqlStr = SqlStr & " set @IsShowPacking='" & IIf(Me.ckbIsShowPacking.Checked = True, "Y", "N") & "' " _
                    & " set @IsPrtPacking='" & IIf(Me.ChkIsPrtPacking.Checked = True, "Y", "N") & "' " _
                    & " set @IsOnlineGenCartonID='" & IIf(Me.chkIsOnlineGenCartonID.Checked = True, "Y", "N") & "' " _
                    & " set @IsOnlineGenCartonID2='" & IIf(Me.chkIsOnlineGenCartonID2.Checked = True, "Y", "N") & "' " _
                    & " set @chkIsOnlineGenPalletID='" & IIf(Me.chkIsOnlineGenPalletID.Checked = True, "Y", "N") & "'" _
                    & " set @IsPrtSelfCarton='" & IIf(Me.ChkIsPrtSelfCarton.Checked = True, "Y", "N") & "'" _
                    & " set @ISPRTSELFPALLET='" & IIf(Me.IsPrtSelfPallet.Checked = True, "Y", "N") & "'" _
                    & " set @IsLinePrintFullCode='" & IIf(Me.chkIsLinePrintFullCode.Checked = True, "Y", "N") & "' " _
                    & " set @IsLineWeight='" & IIf(Me.chkIsLineWeight.Checked = True, "Y", "N") & "' " _
                    & " set @IsPpidLineWeight='" & IIf(Me.chkIsPpidLineWeight.Checked = True, "Y", "N") & "' " _
                    & " set @RepeatStyle='" & IIf(Me.chkRepeatStyle.Checked = True, "Y", "N") & "' " _
                    & " set @RepeatStyleC='" & IIf(Me.chkRepeatStyleC.Checked = True, "Y", "N") & "' " _
                    & " set @RepeatPara='" & Me.txtRepeatPara.Text & "' " _
                    & " set @CartonRepeatStyle='" & IIf(Me.chkCartonRepeatStyle.Checked = True, "Y", "N") & "' " _
                    & " set @CartonRepeatPara='" & Me.txtCartonRepeatPara.Text & "' " _
                    & " set @BigCartonRepeatStyle='" & IIf(Me.chkBigCartonRepeatStyle.Checked = True, "Y", "N") & "' " _
                    & " set @BigCartonRepeatPara='" & Me.txtBigCartonRepeatPara.Text & "' " _
                    & " set @LabelNum='" & Me.TxtLabelNum.Text & "' " _
                    & " set @IsCheckTime='" & IIf(Me.Checktime.Checked = True, "Y", "N") & "' " _
                    & " set @IsCmby='" & IIf(Me.RadNmerger.Checked = True, "0", IIf(Me.RadQmerger.Checked = True, "1", "2")) & "' " _
                    & " set @IsUpDown='" & IIf(Me.ckbIsUpMaterial.Checked = True, "Y", "N") & "' " _
                    & " set @ContY='" & IIf(Me.ChkIsContinual.Checked = True, "Y", "N") & "' " _
                    & " set @Asny='" & IIf(Me.ChkASN.Checked = True, "Y", "N") & "' " _
                    & " set @LinePrtY='" & IIf(Me.ChkTTprint.Checked = True, "Y", "N") & "' " _
                    & " set @Ismatch='" & IIf(Me.Chkmatch.Checked = True, "Y", "N") & "' " _
                    & " set @splitbegin='" & IIf(Me.Chkmatch.Checked = True, Me.TxtSpiltBegin.Text, 0) & "' " _
                    & " set @splitend='" & IIf(Me.Chkmatch.Checked = True, Me.TxtSpiltEnd.Text, 0) & "' " _
                    & " set @CheckSupY='" & IIf(Me.ChkSupplier.Checked = True, "Y", "N") & "' " _
                    & " set @CheckStaorder='" & IIf(Me.ChkSupplier.Checked = True, Me.CobCStation.Text, "") & "' " _
                    & " set @CheckScanorder='" & IIf(Me.ChkSupplier.Checked = True, Me.CobCScanId.Text, "") & "' " _
                    & " set @ShowPos=" & IIf(Me.ckbIsShowPacking.Checked = True, Me.CboShowP.Text.Trim, 0) _
                    & " set @IslineMbarcode='" & IIf(Me.ChkLinePinrtM.Checked = True, "Y", "N") & "' " _
                    & " set @IsUsb='" & IIf(Me.ChkUsb.Checked = True, "Y", "N") & "' " _
                    & " set @IsPackType='" & IIf(Me.ChkPackingType.Checked = True, "Y", "N") & "' " _
                    & " set @IsSamePacking='" & IIf(Me.ChkSamePacking.Checked = True, "Y", "N") & "' " _
                    & " set @IsCartonSame='" & IIf(Me.ChkCartonSame.Checked = True, "Y", "N") & "' " _
                    & " set @IsScanPallet='" & IIf(Me.ChkScanPallet.Checked = True, "Y", "N") & "' " _
                    & " set @IsPalletSame='" & IIf(Me.ChkPalletSame.Checked = True, "Y", "N") & "' " _
                    & " set @IsPackingSame='" & IIf(Me.ChkCartonSame.Checked = True, "Y", "N") & "' " _
                    & " set @IsPPackingProduct='" & IIf(Me.ChkSamePacking.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckMo='" & IIf(Me.ChkMo.Checked = True, "Y", "N") & "' " _
                    & " set @IsAssemblySN='" & IIf(Me.ChkAssemblySN.Checked = True, "Y", "N") & "' " _
                    & " set @IsSSCC='" & IIf(Me.chkParitySSCC.Checked = True, "Y", "N") & "' " _
                    & " set @IsReadPCB='" & IIf(Me.ChkReadPCB.Checked = True, "Y", "N") & "' " _
                    & " set @IsWritePCB='" & IIf(Me.ChkWritePCB.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowNG='" & IIf(Me.CheckNcount.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowNGQty='" & IIf(Me.CheckNcount.Checked = True, Me.TxtNGcount.Text, "") & "' " _
                    & " set @NGqtySC='" & IIf(Me.ChkClaQty.Checked = True, "Y", "N") & "' " _
                    & " set @NGqtycount='" & IIf(Me.CheckNcount.Checked = True, Me.TxtClaQty.Text, "") & "' " _
                    & " set @Userid='" & SysMessageClass.UseId.Trim.ToLower & "' " _
                    & " set @UpLimitWeight='" & txtUpLimitWeight.Text & "' " _
                    & " set @LowLimitWeight='" & txtLowLimitWeight.Text & "' " _
                    & " set @PpidUpLimitWeight='" & txtPpidUpLimitWeight.Text & "' " _
                    & " set @PpidLowLimitWeight='" & txtPpidLowLimitWeight.Text & "' " _
                    & " set @BarePpidUpLimitWeight='" & txtBarePpidUpLimitWeight.Text & "' " _
                    & " set @BarePpidLowLimitWeight='" & txtBarePpidLowLimitWeight.Text & "' " _
                    & " set @IsOldKanBanCheck = '" & IIf(Me.ChkOldKanBanCheck.Checked = True, "Y", "N") & "' " _
                    & " SET @chkIsOnlineGenPalletID='" & IIf(Me.chkIsOnlineGenPalletID.Checked = True, "Y", "N") & "'" _
                    & " set @IsOnlineWorkPrint = '" & IIf(Me.ckIsOnlineWorkPrint.Checked = True, "Y", "N") & "' " _
                    & " set @IsNotCaseSensitive = '" & IIf(Me.chkIsNotCaseSensitive.Checked = True, "Y", "N") & "' " _
                    & " set @IsQCPlan = '" & IIf(Me.chkQCPlan.Checked = True, "Y", "N") & "' " _
                    & " set @IsQCCheckOut = '" & IIf(Me.chkQCCheckOut.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckLink = '" & IIf(Me.chkIsCheckLink.Checked = True, "Y", "N") & "' " _
                    & " if @ScanOrderid=1 begin " _
                    & " Update dbo.m_RPartStationD_t set TPartText=@TPartText,userid=@Userid,isRplacePath='" & "RPrintFile\" & txtPartid.Text.Trim & "\" & FileNameStr & "',intime=getdate(),IsPrtSelf=@IsPrtSelf,IsAllowRe=@IsAllowRe,IsSemiProduct=@IsSemiProduct," _
                    & " IsCustPart=@IsCustPart,IsCheckTestY=@IsCheckTestY,IsPrtPacking=@IsPrtPacking,IsOnlineGenCartonID=@IsOnlineGenCartonID,IsOnlineGenCartonID2=@IsOnlineGenCartonID2," _
                    & " IsLinePrintFullCode=@IsLinePrintFullCode,IsLineWeight=@IsLineWeight,RepeatStyle=@RepeatStyle,RepeatPara=@RepeatPara,RepeatStyleC=@RepeatStyleC,CartonRepeatStyle=@CartonRepeatStyle,CartonRepeatPara=@CartonRepeatPara,IsShowPacking=@IsShowPacking,isendsta=@IsCheckTime,ShowColPos=@ShowPos," _
                    & " Cmby=@IsCmby,IsUpDown=@IsUpDown,testtypeid=@TestID,IsSplit='" & SFlag & "',SplitQty='" & IIf(TxtSplitQty.Checked, "Y", "N") & "',IsRelated = '" & sRelatedFlag & "'," _
                    & " ContY=@ContY,ASNY=@Asny,LinePrtY=@LinePrtY,Ismatch=@Ismatch,splitbegin=@splitbegin,splitend=@splitend,CheckSupY=@CheckSupY, LabelNum = @LabelNum,IsScanN=@IsScanN,ScanNumber=@ScanNumber, " _
                    & " CheckStaorder=@CheckStaorder,CheckScanorder=@CheckScanorder,IsPackType=@IsPackType,IsSamePacking=@IsSamePacking,IsCartonSame=@IsCartonSame,IsScanPallet=@IsScanPallet," _
                    & " IsPalletSame=@IsPalletSame,IsReadPCB=@IsReadPCB,IsWritePCB=@IsWritePCB,IsPPackingProduct=@IsPPackingProduct,IsCheckMoForCarton=@IsCheckMo, IsPackingSame=@IsPackingSame," _
                    & " IsAssemblySN=@IsAssemblySN, IsSSCC=@IsSSCC, CodeRuleID='" & IIf(Me.cboPack.SelectedValue Is Nothing, "", Me.cboPack.Text) _
                    & "',CodeRuleID2 = '" & IIf(Me.cboPack2.SelectedValue Is Nothing, "", Me.cboPack2.Text) & "', IsOldKanBanCheck = @IsOldKanBanCheck " _
                    & " ,IslineMbarcode=@IslineMbarcode,IsUsb=@IsUsb,IsAllowNG=@IsAllowNG,IsAllowNGQty=@IsAllowNGQty,NGqtySC=@NGqtySC,NGqtycount=@NGqtycount,chkIsOnlineGenPalletID=@chkIsOnlineGenPalletID,IsPrtSelfCarton=@IsPrtSelfCarton,ISPRTSELFPALLET=@ISPRTSELFPALLET,IsOnlineWorkPrint=@IsOnlineWorkPrint,IsNotCaseSensitive=@IsNotCaseSensitive " _
                    & "  ,WorkCodeRuleID = '" & IIf(Me.cboWorkCodeRuleId.SelectedValue Is Nothing, "", Me.cboWorkCodeRuleId.Text) & "',UpLimitWeight=@UpLimitWeight,LowLimitWeight=@LowLimitWeight,IsPpidLineWeight=@IsPpidLineWeight,PpidUpLimitWeight=@PpidUpLimitWeight,PpidLowLimitWeight=@PpidLowLimitWeight,BarePpidUpLimitWeight=@BarePpidUpLimitWeight,BarePpidLowLimitWeight=@BarePpidLowLimitWeight,BigCartonRepeatStyle=@BigCartonRepeatStyle,BigCartonRepeatPara=@BigCartonRepeatPara " _
                    & " ,IsQCPlan=@IsQCPlan,QCPlanId='" & IIf(Me.CobQCPlan.SelectedValue Is Nothing, "", Me.CobQCPlan.SelectedValue) & "',IsQCCheckOut=@IsQCCheckOut,IsCheckLink=@IsCheckLink " _
                    & " WHERE PPartid=@PPartid and Revid=@Revid and IsMainBarcode='Y' and StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid " _
                    & " end else begin " _
                    & " delete from m_RPartStationT_t where ReplaceID in(select ReplaceID from m_RPartStationD_t where PPartid=@PPartid and Revid=@Revid and StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid) " _
                    & " Update dbo.m_RPartStationD_t set userid=@Userid,isRplacePath='" & "RPrintFile\" & txtPartid.Text.Trim & "\" & FileNameStr & "',intime=getdate(), " _
                    & " TPartid=@TPartid,TPartText=@TPartText,IsReplaceable=@IsReplaceable,IsReadPCB=@IsReadPCB,IsWritePCB=@IsWritePCB," _
                    & " ReplaceID=@ReplaceID,IsPrtSelf=@IsPrtSelf,IsAllowRe=@IsAllowRe,IsSemiProduct=@IsSemiProduct,IsScanN=@IsScanN,ScanNumber=@ScanNumber,IsCustPart=@IsCustPart,IsCheckTestY=@IsCheckTestY," _
                    & " Cmby=@IsCmby,IsUpDown=@IsUpDown,IsPrtPacking=@IsPrtPacking,IsOnlineGenCartonID=@IsOnlineGenCartonID,IsOnlineGenCartonID2=@IsOnlineGenCartonID2,IsLinePrintFullCode=@IsLinePrintFullCode,IsLineWeight=@IsLineWeight," _
                    & " RepeatStyle=@RepeatStyle,RepeatPara=@RepeatPara,RepeatStyleC=@RepeatStyleC,CartonRepeatStyle=@CartonRepeatStyle,CartonRepeatPara=@CartonRepeatPara,IsShowPacking=@IsShowPacking,isendsta=@IsCheckTime,ShowColPos=@ShowPos,testtypeid=@TestID," _
                    & " IsSplit='" & SFlag & "',SplitQty='" & IIf(TxtSplitQty.Checked, "Y", "N") & "',IsRelated = '" & sRelatedFlag & "',ContY=@ContY,ASNY=@Asny,LinePrtY=@LinePrtY," _
                    & " Ismatch=@Ismatch,splitbegin=@splitbegin,splitend=@splitend,CheckSupY=@CheckSupY,CheckStaorder=@CheckStaorder,CheckScanorder=@CheckScanorder,LabelNum=@LabelNum, " _
                    & " IslineMbarcode=@IslineMbarcode,IsUsb=@IsUsb,IsAllowNG=@IsAllowNG,IsAllowNGQty=@IsAllowNGQty,NGqtySC=@NGqtySC,NGqtycount=@NGqtycount,IsPPackingProduct=@IsPPackingProduct,IsCheckMoForCarton=@IsCheckMo,IsAssemblySN=@IsAssemblySN, IsSSCC=@IsSSCC, " _
                    & " IsPpidLineWeight=@IsPpidLineWeight,PpidUpLimitWeight=@PpidUpLimitWeight,PpidLowLimitWeight=@PpidLowLimitWeight,BarePpidUpLimitWeight=@BarePpidUpLimitWeight,BarePpidLowLimitWeight=@BarePpidLowLimitWeight," _
                    & " CodeRuleID='" & IIf(Me.cboPack.SelectedValue Is Nothing, "", Me.cboPack.Text) & "' , CodeRuleID2='" & IIf(Me.cboPack2.SelectedValue Is Nothing, "", Me.cboPack2.Text) & "' " _
                    & " ,IsPackType=@IsPackType,IsSamePacking=@IsSamePacking,IsCartonSame=@IsCartonSame,IsScanPallet=@IsScanPallet,IsPalletSame=@IsPalletSame,IsPackingSame=@IsPackingSame, IsOldKanBanCheck=@IsOldKanBanCheck,chkIsOnlineGenPalletID=@chkIsOnlineGenPalletID,IsPrtSelfCarton=@IsPrtSelfCarton,ISPRTSELFPALLET=@ISPRTSELFPALLET," _
                    & " IsNotCaseSensitive=@IsNotCaseSensitive,BigCartonRepeatStyle=@BigCartonRepeatStyle,BigCartonRepeatPara=@BigCartonRepeatPara, " _
                    & " IsQCPlan=@IsQCPlan,QCPlanId='" & IIf(Me.CobQCPlan.SelectedValue Is Nothing, "", Me.CobQCPlan.SelectedValue) & "',IsQCCheckOut=@IsQCCheckOut,IsCheckLink=@IsCheckLink " _
                    & " where PPartid=@PPartid and Revid=@Revid and StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid " _
                    & " end "

                Dim RuleId As String = ""
                Dim text As String = ""
                Dim k As Integer = 0
                SqlStr = SqlStr & ControlChars.CrLf & " delete m_RPartStationCheckRule_t where Ppartid=@PPartid and Tpartid=@TPartid and Revid=@Revid and StaOrderid=@StaOrderid and Stationid=@Stationid and ScanOrderid=@ScanOrderid   "
                For k = 0 To ChkListBox.CheckedItems.Count - 1
                    RuleId = CType(ChkListBox.CheckedItems(k), DataRowView).Row(0).ToString
                    text = CType(ChkListBox.CheckedItems(k), DataRowView).Row(1).ToString
                    SqlStr = SqlStr & ControlChars.CrLf & " insert m_RPartStationCheckRule_t(Ppartid,Tpartid,Revid,StaOrderid,Stationid,ScanOrderid,RuleId,Ruleusey,RuleOrderby)  " _
                           & " values (@PPartid,@TPartid,@Revid,@StaOrderid,@Stationid,@ScanOrderid,'" & RuleId & "','Y','" & k & "')"
                Next

                If Me.LstPartSum.Items.Count > 0 Then
                    For i As Integer = 0 To Me.LstPartSum.Items.Count - 1
                        SqlStr = SqlStr & ControlChars.CrLf & " select @MaxItemid=Max(itemid) from dbo.m_RPartStationT_t where ReplaceID=@ReplaceID " _
                            & " insert m_RPartStationT_t(ReplaceID, Itemid, TPartid,UserID, Intime) values(@ReplaceID,isnull(@MaxItemid+1,1),'" & Me.LstPartSum.Items.Item(i).ToString.Trim & "',@Userid,getdate())"
                    Next
                End If
        End Select

        Try
            DbOperateUtils.ExecSQL(SqlStr)
            MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadRouteView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            'Me.pbDesign.Refresh()
            Me.trvData.SelectedNode = Me.trvData.Nodes(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "btnSave_Click", "sys")
        End Try
    End Sub

    Private Sub LblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblDelete.Click
        Dim SqlStr As String = ""

        If Me.trvData.Nodes.Count = 0 OrElse Me.trvData.SelectedNode Is Nothing Then Exit Sub
        Select Case Me.trvData.SelectedNode.Level
            Case 0   '不允許刪除根節點
                MessageBox.Show("不允許刪除根節點！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Case 1   '允許刪除工站及工站對應的所有掃描部件，Update所有工站的順序
                SqlStr = " delete from m_RPartStationT_t where ReplaceID in(select ReplaceID from m_RPartStationD_t where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & " and StaOrderid=" & Me.trvData.SelectedNode.Tag.ToString.Trim & ") " _
                       & " delete from dbo.m_RPartStationD_t where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & " and StaOrderid=" & Me.trvData.SelectedNode.Tag.ToString.Trim _
                       & " update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(), StaOrderid = StaOrderid - 1 where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & " and StaOrderid>" & Me.trvData.SelectedNode.Tag.ToString.Trim
            Case 2   '允許刪除掃描部件，Update該工站所有掃描部件的順序
                If Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(1) = "1" Then
                    MessageBox.Show("不允許刪除主條碼！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                SqlStr = " delete from m_RPartStationT_t where ReplaceID in(select ReplaceID from m_RPartStationD_t where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & " and StaOrderid=" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(0) & " and ScanOrderid=" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(1) & ") " _
                       & " delete from dbo.m_RPartStationD_t where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & " and StaOrderid=" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(0) & " and ScanOrderid=" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(1) _
                       & " update dbo.m_RPartStationD_t set userid='" & SysMessageClass.UseId.Trim.ToLower & "',intime=getdate(), StaOrderid = StaOrderid - 1 where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & " and StaOrderid=" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(0) & " and ScanOrderid>" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(1)
        End Select
        If MessageBox.Show("請確認是否要執行刪除操作?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            DbOperateUtils.ExecSQL(SqlStr)
            MessageBox.Show("刪除成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadRouteView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            '  Me.pbDesign.Refresh()
            Me.trvData.SelectedNode = Me.trvData.Nodes(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "btnDel_Click", "sys")
        End Try
    End Sub

    Private Sub LblQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblQuery.Click
        Dim dtable As New DataTable
        Dim SqlStr As String = ""
        Dim o_SqlStr As New StringBuilder

        If txtPartid.Text.Trim = "" Then
            'routeDesign.RouteClear()
            'Me.pbDesign.Refresh()
            Exit Sub
        End If

        If opFlag = 0 Then '查詢狀態
            LoadDataTodgvMain(Me.txtPartid.Text.Trim)
        ElseIf opFlag = 1 Then '新增狀態
            If MessageUtils.ShowConfirm("請確認是否要生成成品料號:[" + Me.txtPartid.Text.Trim + "]的新版本?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then Exit Sub
            '************************田玉琳 20170307 开始 *****************************************************
            Dim isAllowRe As String = "N"
            If IsBarcodeHaveSS() = True Then
                isAllowRe = "Y"
            End If
            '************************田玉琳 20170307 结束 *****************************************************
            o_SqlStr.AppendFormat(" exec GetNewPartDSql '{0}','{1}','{2}','{3}'",
                                  Me.txtPartid.Text.Trim, VbCommClass.VbCommClass.UseId, isAllowRe, VbCommClass.VbCommClass.Factory)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(o_SqlStr.ToString)

            If dt.Rows(0)(0).ToString.Trim = "2" Then
                MessageUtils.ShowInformation("此料號在系統中不存在，請確認料號是否輸入正確！")
                Me.ActiveControl = Me.txtPartid
                Exit Sub
            End If

            LoadDataTodgvMain(Me.txtPartid.Text.Trim)
            Me.dgvMain.CurrentCell = Me.dgvMain.Item(0, 0)
            MessageUtils.ShowInformation("已生成版本: " & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
        End If
    End Sub

    'Private Sub LblQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblQuery.Click
    '    Dim dtable As New DataTable
    '    Dim SqlStr As String = ""
    '    Dim o_SqlStr As New StringBuilder

    '    If txtPartid.Text.Trim = "" Then
    '        'routeDesign.RouteClear()
    '        'Me.pbDesign.Refresh()

    '        Exit Sub
    '    End If

    '    If opFlag = 0 Then '查詢狀態
    '        LoadDataTodgvMain(Me.txtPartid.Text.Trim)
    '    ElseIf opFlag = 1 Then '新增狀態
    '        If MessageBox.Show("請確認是否要生成成品料號:[" + Me.txtPartid.Text.Trim + "]的新版本?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
    '        '************************田玉琳 20170307 开始 *****************************************************
    '        Dim isAllowRe As String = "N"
    '        If IsBarcodeHaveSS() = True Then
    '            isAllowRe = "Y"
    '        End If
    '        '************************田玉琳 20170307 结束 *****************************************************
    '        '部件料號含有替代料，更新日期：2009/10/14   
    '        '周可海
    '        SqlStr = " declare @MaxRevid int,@Return varchar(1),@PPartid varchar(35),@Userid varchar(10), @IsAllowRe varchar(1) " _
    '            & " declare @MaxRow int,@id int,@StaOrderid int,@ScanOrderid int " _
    '            & " set @PPartid='" & Me.txtPartid.Text.Trim & "'  set @Userid='" & SysMessageClass.UseId.Trim.ToLower & "' " _
    '            & " set @IsAllowRe = '" & isAllowRe & "'" _
    '            & " set @Return=case (select distinct 1 from dbo.m_PartContrast_t where TavcPart=@PPartid and TavcPart=PavcPart and usey='Y' " & GetPartFatory() & ") when '1' then '1' else '2' end " _
    '            & " if @Return='1' begin select @MaxRevid=Max(Revid) from dbo.m_RPartStationM_t where PPartid=@PPartid " _
    '            & " insert dbo.m_RPartStationM_t(PPartid, Revid, State, UserID, Intime) " _
    '            & " select @PPartid as PPartid,isnull(@MaxRevid+1,1) as Revid,'0' as State,@Userid as Userid,getdate() as Intime " _
    '            & " select @MaxRow=COUNT(*) from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid " _
    '            & " set @id = 1 if @MaxRow>0 begin while @id <= @MaxRow begin " _
    '            & " select @StaOrderid = StaOrderid,@ScanOrderid=ScanOrderid from( " _
    '            & " select  StaOrderid,ScanOrderid,row_number()over(order by StaOrderid,ScanOrderid) as id " _
    '            & " from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid) a where id = @id " _
    '            & " insert m_RPartStationD_t (PPartid, Revid, StaOrderid, ScanOrderid, Stationid,  TPartid, " _
    '            & " TPartText,IsReplaceable, ReplaceID,IsMainBarcode,IsPrtSelf, IsAllowRe,IsSemiProduct,IsScanN,ScanNumber,IsCustPart,IsScanPallet,IsCheckTestY,TestTypeID,IsShowPacking," _
    '            & " ShowColPos, Remark, State, UserID, Intime,Cmby,IsSplit,Ismatch,SplitBegin,SplitEnd,SplitQty,IslineMbarcode,IsAllowNG,IsAllowNGQty," _
    '            & " NGqtySC,NGqtycount,IsUsb,isRplacePath,IsPackingSame,IsReadPCB,IsWritePCB) " _
    '            & " select PPartid, isnull(@MaxRevid+1,1) as Revid,StaOrderid,ScanOrderid,Stationid, " _
    '            & " TPartid,TPartText,IsReplaceable,case IsReplaceable when 'Y' then dbo.FunCreateReplaceID() when 'N' then Null end as ReplaceID," _
    '            & " IsMainBarCode,IsPrtSelf,@IsAllowRe,IsSemiProduct,IsScanN, ScanNumber,IsCustPart,IsScanPallet, IsCheckTestY,TestTypeID,IsShowPacking,ShowColPos,Remark,'0' as State," _
    '            & " @Userid as UserID,getdate() as Intime,Cmby,IsSplit,Ismatch,SplitBegin,SplitEnd,SplitQty,IslineMbarcode,IsAllowNG,IsAllowNGQty,NGqtySC," _
    '            & " NGqtycount,IsUsb,isRplacePath,IsPackingSame,IsReadPCB,IsWritePCB " _
    '            & " from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid and  StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid " _
    '            & " insert m_RPartStationCheckRule_t(Ppartid,Tpartid,Revid,StaOrderid,Stationid,ScanOrderid,RuleId,Ruleusey,RuleOrderby) " _
    '            & " select Ppartid,Tpartid,Revid=isnull(@MaxRevid+1,1),StaOrderid,Stationid,ScanOrderid,RuleId,Ruleusey,RuleOrderby from m_RPartStationCheckRule_t where PPartid=@PPartid " _
    '            & " and Revid=CAST(@MaxRevid AS VARCHAR) and  StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid " _
    '            & " set @id = @id +1 End End " _
    '            & " insert m_RPartStationT_t(ReplaceID, Itemid, TPartid, UserID, Intime) " _
    '            & " select c.ReplaceID, b.Itemid, b.TPartid, @Userid as UserID,GETDATE() as Intime " _
    '            & " from m_RPartStationD_t as a join m_RPartStationD_t as c on a.PPartid=c.PPartid and a.StaOrderid=c.StaOrderid and a.ScanOrderid=c.ScanOrderid " _
    '            & " join dbo.m_RPartStationT_t as b on a.ReplaceID=b.ReplaceID where a.PPartid=@PPartid and a.Revid=@MaxRevid and c.Revid=isnull(@MaxRevid+1,1) End " _
    '            & " select @Return as Re "

    '        o_SqlStr.Append(" declare @sql varchar(max)  ")
    '        o_SqlStr.Append(" exec GetSapBOMSql '888', '1021','PQDB76-6300-001-1H','01',2,@sql output")
    '        o_SqlStr.Append(" select @sql")

    '        dtable = DbOperateUtils.GetDataTable(SqlStr)
    '        If dtable.Rows(0)(0).ToString.Trim = "1" Then
    '            'routeDesign.RouteClear()
    '            LoadDataTodgvMain(Me.txtPartid.Text.Trim)
    '            Me.dgvMain.CurrentCell = Me.dgvMain.Item(0, 0)

    '            MessageBox.Show("已生成版本: " & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        ElseIf dtable.Rows(0)(0).ToString.Trim = "2" Then
    '            MessageBox.Show("此料號在系統中不存在，請確認料號是否輸入正確！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Me.ActiveControl = Me.txtPartid
    '            '   routeDesign.RouteClear()
    '            ' Me.pbDesign.Refresh()
    '            Exit Sub
    '        End If
    '        'Me.SplitContainer3.Panel1.Enabled = False
    '    End If
    'End Sub

    Private Sub CheckNcount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'IIf(CheckNcount.Checked = True, TxtNGcount.Enabled = True, TxtNGcount.Enabled = False
        If CheckNcount.Checked Then
            TxtNGcount.Enabled = True
        Else
            TxtNGcount.Enabled = False
        End If



    End Sub

    Private Sub ChkClaQty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'IIf(ChkClaQty.Checked = True, TxtClaQty.Enabled = True, TxtClaQty.Enabled = False)
        If ChkClaQty.Checked Then
            TxtClaQty.Enabled = True
        Else
            TxtClaQty.Enabled = False
        End If
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim files() As String
        Dim result As DialogResult = OpenFileDialog.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtFilename.Text = OpenFileDialog.FileName
            ' Open the format.
            FileNameStr = OpenFileDialog.SafeFileNames(0).ToString
        End If

    End Sub

    Private Sub ChkLinePinrtM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkIsPrtPacking.CheckedChanged
        If ChkIsPrtPacking.Checked Then
            If (Not String.IsNullOrEmpty(Me.txtPartid.Text.Trim)) AndAlso txtPartid.Text.Substring(0, 3) = "L99" Then
                'DO NOTHING
            Else
                chkIsOnlineGenCartonID.Checked = False
                ChkIsPrtSelfCarton.Checked = True
            End If
        End If

        SetPackData()
    End Sub

    Private Sub chkIsOnlineGenCartonID_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsOnlineGenCartonID.CheckedChanged
        If chkIsOnlineGenCartonID.Checked Then

            If (Not String.IsNullOrEmpty(Me.txtPartid.Text.Trim)) AndAlso txtPartid.Text.Substring(0, 3) = "L99" Then
                'do nothing
            Else
                ChkIsPrtPacking.Checked = False
                ChkIsPrtSelfCarton.Checked = True
            End If
        End If

        SetPackData()
    End Sub

    '选择是否系统打印外箱 
    Private Sub ChkIsPrtSelfCarton_CheckedChanged(sender As Object, e As EventArgs) Handles ChkIsPrtSelfCarton.CheckedChanged
        If ChkIsPrtSelfCarton.Checked = False Then
            If (Not String.IsNullOrEmpty(Me.txtPartid.Text.Trim)) AndAlso txtPartid.Text.Substring(0, 3) = "L99" Then
                'do nothing
            Else
                ChkIsPrtPacking.Checked = False
                chkIsOnlineGenCartonID.Checked = False
            End If
        End If

        SetPackData()
    End Sub

    Private Sub SetPackData()
        If (Me.ChkIsPrtPacking.Checked Or Me.chkIsOnlineGenCartonID.Checked Or ChkIsPrtSelfCarton.Checked = False) Then
            Me.cboPack.Enabled = True
        Else
            Me.cboPack.Enabled = False
            Me.cboPack.Text = ""
        End If
    End Sub

    Private Sub chkIsOnlineGenCartonID2_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsOnlineGenCartonID2.CheckedChanged
        SetPackData2()
    End Sub

    Private Sub SetPackData2()
        If (Me.chkIsOnlineGenCartonID2.Checked) Then
            Me.cboPack2.Enabled = True
        Else
            Me.cboPack2.Enabled = False
            Me.cboPack2.Text = ""
        End If
    End Sub
    Private Sub SetWorkOnlinePrint()
        If (Me.ckIsOnlineWorkPrint.Checked) Then
            Me.cboWorkCodeRuleId.Enabled = True
        Else
            Me.cboWorkCodeRuleId.Enabled = False
            Me.cboWorkCodeRuleId.Text = ""
        End If
    End Sub
    Private Sub chkIsLinePrintFullCode_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsLinePrintFullCode.CheckedChanged
        If chkIsLinePrintFullCode.Checked Then
            TxtLabelNum.Text = 1
        Else
            TxtLabelNum.Text = ""
        End If
    End Sub

    Private Sub toolRecovery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolRecovery.Click
        If Not (CheckRecovery()) Then
            Exit Sub
        End If
        Try
            Dim partid As String = Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
            Dim revid As String = Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
            Dim SqlStr As String =
              " update m_RPartStationM_t set State=1,Comfireuser='" & SysMessageClass.UseId.ToLower.Trim & "',Comfiretime=getdate() " &
              " where PPartid='" & partid & "' and Revid=" & revid &
              " update m_RPartStationD_t set State=1  where PPartid='" & partid & "' and Revid=" & revid

            DbOperateUtils.ExecSQL(SqlStr)
            MessageBox.Show("恢复成功!")
            LoadDataTodgvMain(Me.txtPartid.Text.Trim)
        Catch ex As Exception
            MessageBox.Show("系统错误，请联系开发人员！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "toolRecovery_Click", "sys")
        End Try
    End Sub

    Private Function CheckRecovery() As Boolean
        If Me.dgvMain.Rows.Count = 0 OrElse Me.dgvMain.CurrentRow Is Nothing Then
            MessageBox.Show("恢复失败，请选择恢复的版本!")
            Return False
        End If

        If (Me.dgvMain.Rows(Me.dgvMain.CurrentRow.Index).Cells("ColVerdd").Value.ToString.Trim.Split("-")(0) = "0") Then
            MessageBox.Show("恢复失败，该版本未确认。请先确认!")
            Return False
        End If

        Try
            '检查确认版本
            Dim dt As DataTable = DbOperateUtils.GetDataTable("SELECT PPartid FROM m_RPartStationM_t WHERE PPartid='" & Me.dgvMain.Rows(Me.dgvMain.CurrentRow.Index).Cells("Column12").Value.ToString.Trim & "' and state='1'")
            If dt.Rows.Count > 0 Then
                MessageBox.Show("恢复失败，当前料号存在确认版本!")
                Return False
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show("执行恢复检查异常,请确认网络连接")
            Return False
        End Try
    End Function

    Private Sub ChkPackingType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPackingType.CheckedChanged

        'update by hgd 2015-08-16 新加入栈板（流水码扫描）,已支持箱包装栈板扫，所以注释掉
        'If (Me.ChkPackingType.Checked) Then
        '    Me.ChkScanPallet.Enabled = False
        '    Me.ChkPalletSame.Enabled = False
        '    Me.ChkScanPallet.Checked = False
        '    Me.ChkPalletSame.Checked = False

        'Else
        '    Me.ChkScanPallet.Enabled = True
        '    Me.ChkPalletSame.Enabled = True
        'End If
    End Sub

    Private Sub ChkSamePacking_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSamePacking.CheckedChanged

        If (Me.ChkSamePacking.Checked) Then
            If (Me.ChkScanPallet.Checked = True) Then
                Me.ChkPalletSame.Checked = True
                Me.ChkPalletSame.Enabled = False
            End If

            Me.ChkCartonSame.Checked = True
            Me.ChkCartonSame.Enabled = False

            Me.ckbIsAllowRe.Enabled = False
            Me.ckbIsAllowRe.Checked = False
        Else
            If (Me.ChkScanPallet.Checked = True) Then

            End If
            Me.ChkCartonSame.Enabled = True
            Me.ChkPalletSame.Enabled = True

            Me.ckbIsAllowRe.Enabled = True
        End If

    End Sub

    'Private Sub pbDesign_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbDesign.Paint
    '    Try
    '        routeDesign.RouteDesignPaint(e)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub ToolStripbtnRules_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolRules.Click
        Dim fr As FrmRPartStationRules = New FrmRPartStationRules
        fr.ShowDialog()
        FillListCheckBoxList(ChkListBox, "select id,RuleName from m_RPartStationRules_t where Ruleusey='Y' order by RuleOrderby desc", "id", "RuleName")
    End Sub

    Private Sub CobChekTimes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CobChekTimes.SelectedIndexChanged
        Dim cur As Integer = Integer.Parse(CobChekTimes.Text.ToString)
        Dim i As Integer = 0
        Dim parameter As String = ""
        If cur > 0 Then
            For i = 0 To cur - 1
                parameter = parameter + "," + "{@ppid}"
            Next
            parameter = parameter.Substring(1).ToString
        Else

        End If
        txtRepeatPara.Text = parameter
    End Sub

    Private Sub chkRepeatStyle_CheckedChanged(sender As Object, e As EventArgs) Handles chkRepeatStyle.CheckedChanged
        If chkRepeatStyle.Checked Then
            txtRepeatPara.Enabled = True
            CobChekTimes.Enabled = True
        Else
            CobChekTimes.Enabled = False
            txtRepeatPara.Enabled = False

        End If
    End Sub

    '判断是否产品条码
    Private Function IsBarcodeHaveSS() As Boolean
        Dim strSQL As String =
            " select PARTID,Packid ,CodeRuleID from " &
            " (SELECT PARTID,STUFF((SELECT ',' + Packid FROM m_PartPack_t WHERE PARTID=A.PARTID AND StatusFlag = '2' AND Packid LIKE '%S%' FOR XML PATH('')),1, 1, '') AS Packid, " &
            " STUFF((SELECT ',' + CodeRuleID FROM m_PartPack_t WHERE PARTID=A.PARTID AND StatusFlag = '2' AND Packid LIKE '%S%' FOR XML PATH('')),1, 1, '') AS CodeRuleID" &
            " FROM m_PartPack_t A where Usey = 'Y' and StatusFlag = '2'" &
            " GROUP BY PARTID) AA WHERE Packid LIKE '%S%' and Partid = '{0}'"


        If txtTPartid.Text <> "" Then

            Dim sPpartid = Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
            If txtTPartid.Text <> sPpartid Then
                'add by hgd 20191029 如果是部件条码，则不强制流水码的条码唯一性
                Return False
            End If
            strSQL = String.Format(strSQL, txtTPartid.Text)
        Else
            strSQL = String.Format(strSQL, txtPartid.Text)
        End If

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 1 Then
            Return True
        End If
        Return False
    End Function

    '判断是否产品条码
    Private Function IsPQECheck11() As Boolean
        Dim strSQL As String = "  SELECT PartId,IsValid  FROM m_HWCheckPartIdPara where IsValid = 'Y' and Partid = '{0}'"

        If txtTPartid.Text = "" Then
            Return True
        End If

        strSQL = String.Format(strSQL, txtPartid.Text)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 1 Then
            If chkRepeatStyle.Checked = True Then
                If (txtRepeatPara.Text.Contains("|11")) = True Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Dim frm As FrmRPartStationSub = New FrmRPartStationSub
        frm.ShowDialog()

        '不为OK时不设置
        If frm.DialogResult <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        Dim oneValue As String
        Dim twoValue As String
        Dim threeValue As String
        oneValue = frm.ListBox1.Text
        twoValue = frm.ListBox2.Text
        threeValue = frm.ListBox3.Text

        Dim sepcValue As String = ""
        If frm.cmbSpec.Text <> "" Then
            sepcValue = frm.cmbSpec.SelectedValue.ToString
        End If

        ClearCheckBox()

        '是否检验工单
        ChkMo.Checked = True

        '(1)高频房扫描(袋子相同)
        If sepcValue = "1" Then
            ckbIsPrtSelf.Checked = True
            ckbIsAllowRe.Checked = True
            ChkIsPrtPacking.Checked = True
            ChkIsPrtSelfCarton.Checked = True
            chkIsOnlineGenCartonID2.Checked = True
            ChkCartonSame.Checked = True
            '(2)高频房扫描(袋子不相同)
        ElseIf sepcValue = "2" Then
            ckbIsPrtSelf.Checked = True
            ckbIsAllowRe.Checked = True
            ChkIsPrtPacking.Checked = True
            ChkIsPrtSelfCarton.Checked = True
            chkIsOnlineGenCartonID2.Checked = True
            '(3)生成外箱在线打印整箱条码
        ElseIf sepcValue = "3" Then
            'ckbIsPrtSelf.Checked = True
            ckbIsAllowRe.Checked = True
            chkIsOnlineGenCartonID.Checked = True
            ChkIsPrtSelfCarton.Checked = True
            chkIsLinePrintFullCode.Checked = True
            If cboPack.Items.Count = 1 Then
                cboPack.SelectedIndex = 0
            End If
            '(4)生成外箱在线称重打印整箱条码
        ElseIf sepcValue = "4" Then
            ckbIsPrtSelf.Checked = True
            ckbIsAllowRe.Checked = True
            chkIsOnlineGenCartonID.Checked = True
            ChkIsPrtSelfCarton.Checked = True
            chkIsLinePrintFullCode.Checked = True
            chkIsLineWeight.Checked = True
            If cboPack.Items.Count = 1 Then
                cboPack.SelectedIndex = 0
            End If
        Else
            If oneValue.Contains("非系统") Then
                ckbIsPrtSelf.Checked = False
            ElseIf oneValue.Contains("系统") Then
                ckbIsPrtSelf.Checked = True
            ElseIf oneValue.Contains("箱包装") Then
                ChkPackingType.Checked = True
            End If

            If oneValue.Contains("唯一") Then
                ckbIsAllowRe.Checked = True
            ElseIf oneValue.Contains("固定") Then
                ckbIsAllowRe.Checked = False
            ElseIf oneValue.Contains("箱包装") Then
                ChkPackingType.Checked = True
            End If

            '箱设置
            If twoValue.Contains("非系统") Then
                ChkIsPrtSelfCarton.Checked = False
            ElseIf twoValue.Contains("系统") Then
                ChkIsPrtSelfCarton.Checked = True
            ElseIf twoValue.Contains("自动生成") Then
                chkIsOnlineGenCartonID.Checked = True
                If cboPack.Items.Count = 1 Then
                    cboPack.SelectedIndex = 0
                End If
            End If

            '固定外箱
            If twoValue.Contains("固定") Then
                ChkCartonSame.Checked = True
            End If
            'If twoValue.Contains("在线打印") Then
            '    ChkIsPrtPacking.Checked = True
            '    If cboPack.Items.Count = 1 Then
            '        cboPack.SelectedIndex = 0
            '    End If
            'End If

            '大箱设置
            If threeValue.Contains("非系统") Then
                'ChkIsPrtSelfCarton.Checked = False
            ElseIf threeValue.Contains("系统") Then
                ChkScanPallet.Checked = True
            End If

            '固定大外箱
            If threeValue.Contains("固定") Then
                ChkPalletSame.Checked = True
            End If

        End If

    End Sub

    '清空选择
    Private Sub ClearCheckBox()
        For Each ClearCon As Control In Me.groupBox2.Controls
            If TypeOf ClearCon Is System.Windows.Forms.CheckBox Then
                DirectCast(ClearCon, CheckBox).Checked = False
            End If
            If TypeOf ClearCon Is DevComponents.DotNetBar.Controls.ComboBoxEx Then
                DirectCast(ClearCon, DevComponents.DotNetBar.Controls.ComboBoxEx).Text = ""
            End If
        Next
    End Sub

    ''' <summary>
    ''' add by cq 20171103,  箱条码校验
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkCartonRepeatStyle_CheckedChanged(sender As Object, e As EventArgs) Handles chkCartonRepeatStyle.CheckedChanged, chkIsNotCaseSensitive.CheckedChanged
        If chkCartonRepeatStyle.Checked Then
            txtCartonRepeatPara.Enabled = True
            CobCartonChekTimes.Enabled = True
        Else
            CobCartonChekTimes.Enabled = False
            txtCartonRepeatPara.Enabled = False
        End If
    End Sub

    Private Sub CobCartonChekTimes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CobCartonChekTimes.SelectedIndexChanged
        Dim cur As Integer = Integer.Parse(CobCartonChekTimes.Text.ToString)
        Dim i As Integer = 0
        Dim parameter As String = ""
        If cur > 0 Then
            For i = 0 To cur - 1
                parameter = parameter + "," + "{@ppid}"
            Next
            parameter = parameter.Substring(1).ToString
        Else

        End If
        txtCartonRepeatPara.Text = parameter
    End Sub

    Private Sub ckIsOnlineWorkPrint_CheckedChanged(sender As Object, e As EventArgs) Handles ckIsOnlineWorkPrint.CheckedChanged
        SetWorkOnlinePrint()
    End Sub

    Private Sub chkIsLineWeight_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsLineWeight.CheckedChanged
        If chkIsLineWeight.Checked Then
            txtUpLimitWeight.Enabled = True
            txtLowLimitWeight.Enabled = True
        Else
            txtUpLimitWeight.Enabled = False
            txtLowLimitWeight.Enabled = False
        End If
    End Sub
    Private Sub chkIsPpidLineWeight_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsPpidLineWeight.CheckedChanged
        If chkIsPpidLineWeight.Checked Then
            txtPpidUpLimitWeight.Enabled = True
            txtPpidLowLimitWeight.Enabled = True
        Else
            txtPpidUpLimitWeight.Enabled = False
            txtPpidLowLimitWeight.Enabled = False
        End If
    End Sub

#Region "动态绘制工序流程图--by hs ke 20180427"
    ''' <summary>
    ''' 工序数据源
    ''' </summary>
    ''' <remarks></remarks>
    Private newDtValue As DataTable = New DataTable
    Public Property NewDt() As DataTable
        Get
            Return newDtValue
        End Get
        Set(ByVal value As DataTable)
            newDtValue = value
        End Set
    End Property
    ''' <summary>
    ''' 流程图展开高度
    ''' </summary>
    ''' <remarks></remarks>
    Private _SplitterHeight As Integer = 70
    Public Property SplitterHeight() As Integer
        Get
            Return _SplitterHeight
        End Get
        Set(ByVal value As Integer)
            _SplitterHeight = value
        End Set
    End Property
    ''' <summary>
    ''' 动态绑定工站流程图
    ''' </summary>
    ''' <param name="Partid">物料</param>
    ''' <param name="Rev">版本号</param>
    ''' <remarks></remarks>
    Public Sub BindFlow(ByVal Partid As String, ByVal Rev As String)
        'Dim charstr As String = "①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳㉑㉒㉓㉔㉕㉖㉗㉘㉙㉚㉛㉜㉝㉞㉟㊱㊲㊳㊴㊵㊶㊷㊸㊹㊺㊻㊼㊽㊾㊿"
        Dim sqlstr As System.Text.StringBuilder = New System.Text.StringBuilder
        'sqlstr.Append(String.Format("select a.Stationid,NgBackStationId=isnull(NgBackStationId,''),Stationname,StaOrderid,Text=cast(StaOrderid as varchar(2))+'-'+a.Stationid+'-'+Stationname from m_RPartStationD_t a left join m_Rstation_t b on a.Stationid =b.Stationid  where  a.PPartid='{0}' and Revid='{1}' order by a.staorderid", Partid, Rev))

        sqlstr.Append(" select a.Stationid,NgBackStationId=isnull(NgBackStationId,''),")
        sqlstr.Append(" case when a.ScanOrderid>1 then cast(ScanOrderid as varchar(2))+'-'+a.TPartid+'-部件' ")
        sqlstr.Append(" else Stationname end Stationname,StaOrderid,ScanOrderid,")
        sqlstr.Append(" Text=  case when a.ScanOrderid>1 then cast(StaOrderid as varchar(2))+'-'+a.TPartid+'-部件'")
        sqlstr.Append(" else cast(StaOrderid as varchar(2))+'-'+a.Stationid+'-'+Stationname end,a.Isrelated ")
        sqlstr.Append(String.Format(" from m_RPartStationD_t a left join m_Rstation_t b on a.Stationid =b.Stationid   where  a.PPartid='{0}' and Revid='{1}' AND isnull(a.Stationid,'') <> '' order by a.staorderid", Partid, Rev))


        Dim colcounts As Integer = 100
        Dim ds As DataSet = MainFrame.DbOperateUtils.GetDataSet(sqlstr.ToString)
        _borderPanel.Controls.Clear()
        If ds.Tables.Count > 0 Then
            NewDt = ds.Tables(0)
            Dim iTmpTop As Integer = 0
            Dim iTmpLeft As Integer = 0
            Dim iDex As Integer = 0
            '是否允许跳站
            Dim IsUpRelated = False
            Dim i As Integer = 0
            For i = 0 To NewDt.Rows.Count - 1
                Dim stationid As String = NewDt.Rows(i)("Stationid")
                Dim NgBackStationId As String = NewDt.Rows(i)("NgBackStationId")
                Dim Stationname As String = NewDt.Rows(i)("Stationname")
                Dim Isrelated As String = NewDt.Rows(i)("Isrelated")
                Dim ScanOrderid As String = NewDt.Rows(i)("ScanOrderid")
                Dim yu As Integer = i Mod colcounts
                Dim zn As Integer = i \ colcounts
                Dim lb As Button = New Button
                lb.Text = "（" + CStr(i + 1) + "）" + vbNewLine + Stationname + vbNewLine + stationid
                'lb.Text = charstr.Substring(i, 1).ToString  + vbNewLine + Stationname + vbNewLine + stationid
                If NewDt.Rows.Count = 1 Then
                    lb.Text = Stationname + vbNewLine + stationid
                End If
                lb.Name = "txt" + stationid + ScanOrderid
                'lb.Width = 100
                'lb.Height = 50
                'lb.Top = 10 + 50 * zn
                'lb.Left = 10 + 120 * yu

                lb.Width = 120
                lb.Height = 60
                'modify by hgd 20191113 调整工站流程图
                If ScanOrderid = "1" Then
                    iTmpTop = 0
                    yu = IIf(IsUpRelated = True, yu - iDex, yu)
                    lb.Top = 10 + 60 * zn
                    lb.Left = 10 + 150 * yu
                    iTmpTop = lb.Top
                    iTmpLeft = lb.Left

                Else
                    If ScanOrderid = "2" Then
                        iDex = iDex + 1

                    End If
                    lb.Top = iTmpTop + 20 + lb.Height
                    lb.Left = iTmpLeft
                    iTmpTop = lb.Top
                    IsUpRelated = True
                    lb.ForeColor = Color.Olive
                End If


                'modify by hgd 20191113 允许跳站用演示区分
                If Isrelated = "Y" Then
                    lb.ForeColor = Color.LightSalmon
                End If
                'lb.BackColor = Color.Red
                _borderPanel.Controls.Add(lb)
            Next
        End If
        _borderPanel.Refresh()
    End Sub
    ''' <summary>
    ''' 绑定当前工站前面的所有工序
    ''' </summary>
    ''' <param name="CuurStaOrderid"></param>
    ''' <remarks></remarks>
    Private Sub SetBindBackComBox(ByVal CuurStaOrderid As Integer)
        Dim dt As DataTable = NewDt
        Dim dv As DataView = NewDt.DefaultView()
        dv.RowFilter = (String.Format("StaOrderid<='{0}'", CuurStaOrderid))
        Me.txtNgBackStationId.DisplayMember = "Text"
        Me.txtNgBackStationId.ValueMember = "Stationid"
        Me.txtNgBackStationId.DataSource = dv
    End Sub
    ''' <summary>
    ''' 正常工站连线
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="colA">起点工站</param>
    ''' <param name="colB">到达工站</param>
    ''' <remarks></remarks>
    Private Sub LinkToABControl(ByVal e As PaintEventArgs, ByVal colA As Control, ByVal colB As Control)
        Dim g As Graphics = e.Graphics
        Dim pen As Pen = New Pen(Color.Blue, 2.0F)
        Dim lineCap As System.Drawing.Drawing2D.AdjustableArrowCap = New System.Drawing.Drawing2D.AdjustableArrowCap(3, 3, True)
        pen.CustomStartCap = lineCap
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        Dim Points() As Point = New Point(1) {}
        Points(0) = New Point(colB.Location.X, colB.Location.Y + 25)
        Points(1) = New Point(colA.Location.X + 100, colA.Location.Y + 25)
        g.DrawLines(pen, Points)
        pen.Dispose()
    End Sub

    ''' <summary>
    ''' 正常工站垂直连线
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="colA">起点工站</param>
    ''' <param name="colB">到达工站</param>
    ''' <remarks></remarks>
    Private Sub LinkToVerticalABControl(ByVal e As PaintEventArgs, ByVal colA As Control, ByVal colB As Control)
        Dim g As Graphics = e.Graphics
        Dim pen As Pen = New Pen(Color.LightSalmon, 2.0F)
        pen.DashStyle = Drawing2D.DashStyle.Dash
        Dim lineCap As System.Drawing.Drawing2D.AdjustableArrowCap = New System.Drawing.Drawing2D.AdjustableArrowCap(3, 3, True)
        pen.CustomStartCap = lineCap
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        Dim Points() As Point = New Point(1) {}
        Points(0) = New Point(colB.Location.X + colB.Size.Width / 2, colB.Location.Y)
        Points(1) = New Point(colA.Location.X + colA.Size.Width / 2, colA.Location.Y)
        g.DrawLines(pen, Points)

        pen.Dispose()
    End Sub
    ''' <summary>
    ''' 回流工站连线
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="colA">起点工站</param>
    ''' <param name="colB">NG回流工站</param>
    ''' <param name="ts"></param>
    ''' <remarks></remarks>
    Private Sub LinkBackABControl(ByVal e As PaintEventArgs, ByVal colA As Control, ByVal colB As Control, Optional ByVal ts As Integer = 1)
        Dim g As Graphics = e.Graphics
        Dim pen As Pen = New Pen(Color.DarkGray, 1.0F)
        Dim lineCap As System.Drawing.Drawing2D.AdjustableArrowCap = New System.Drawing.Drawing2D.AdjustableArrowCap(3, 3, True)
        pen.CustomStartCap = lineCap

        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        Dim Points() As Point = New Point(3) {}
        Points(0) = New Point(colB.Location.X - colB.Size.Width / 2 + 100 + 2 * ts, colB.Location.Y + colA.Size.Height)
        Points(1) = New Point(colB.Location.X - colB.Size.Width / 2 + 100 + 2 * ts, colB.Location.Y + colA.Size.Height + 15 + 5 * ts)
        Points(2) = New Point(colA.Location.X + colA.Size.Width / 2 + 0 * ts, colA.Location.Y + colA.Size.Height + 15 + 5 * ts)
        Points(3) = New Point(colA.Location.X + colA.Size.Width / 2 + 0 * ts, colA.Location.Y + colA.Size.Height)
        g.DrawLines(pen, Points)
        g.DrawString("NG", New Font("宋体", 9.0F, FontStyle.Regular), New SolidBrush(Color.Red), New Point(colA.Location.X + colA.Size.Width / 2 - 20, colA.Location.Y + colA.Size.Height + 5 + 5 * (ts - 1)))

        pen.Dispose()
    End Sub
    ''' <summary>
    ''' 工站绘图连线
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub _borderPanel_Paint(sender As Object, e As PaintEventArgs) Handles _borderPanel.Paint
        Dim i As Integer = 0
        Dim ImageHeight As Integer = 15
        Dim ScanOrderid As String
        Dim NextScanOrderid As String
        If NewDt.Rows.Count > 2 Then
            For i = 0 To NewDt.Rows.Count - 1

                Dim colAName As String = "txt" & NewDt.Rows(i)("Stationid") & NewDt.Rows(i)("ScanOrderid")
                Dim controlA As Button = _borderPanel.Controls.Find(colAName, False)(0)

                Dim colBName As String = ""
                If i < NewDt.Rows.Count - 1 Then
                    ScanOrderid = NewDt.Rows(i)("ScanOrderid")
                    NextScanOrderid = NewDt.Rows(i + 1)("ScanOrderid")
                    colBName = "txt" & NewDt.Rows(i + 1)("Stationid") & NewDt.Rows(i + 1)("ScanOrderid")
                    Dim controlB As Button = _borderPanel.Controls.Find(colBName, False)(0)

                    If NextScanOrderid = "1" And ScanOrderid <> "1" Then
                        '最后部件与下一工站
                        Dim colCName As String = "txt" & NewDt.Rows(i)("Stationid") & "1"
                        Dim controlC As Button = _borderPanel.Controls.Find(colCName, False)(0)
                        LinkToABControl(e, controlC, controlB)
                    ElseIf ScanOrderid = "1" And NextScanOrderid <> "1" Then
                        '部件：垂直连线
                        LinkToVerticalABControl(e, controlA, controlB)

                    ElseIf ScanOrderid <> "1" And NextScanOrderid <> "1" Then
                        '部件：垂直连线
                        LinkToVerticalABControl(e, controlA, controlB)
                    Else
                        LinkToABControl(e, controlA, controlB)
                    End If

                End If
                If (NewDt.Rows(i)("NgBackStationId") <> "") Then
                    Dim colBack As String = "txt" + NewDt.Rows(i)("NgBackStationId") & "1"
                    Dim controlBack As Button = _borderPanel.Controls.Find(colBack, False)(0)
                    LinkBackABControl(e, controlA, controlBack, 1 * i)
                    ImageHeight = ImageHeight + 5
                End If
            Next
            SplitterHeight = 80 + ImageHeight
        End If
    End Sub
    ''' <summary>
    ''' 折叠流程图
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If ToolStripButton7.Text = "展开工序流程图(&X)" Then
            SplitContainer5.SplitterDistance = SplitterHeight '200
            ToolStripButton7.Text = "收缩工序流程图(&X)"
        Else
            SplitContainer5.SplitterDistance = 70
            ToolStripButton7.Text = "展开工序流程图(&X)"
        End If
    End Sub
    ''' <summary>
    ''' 导出流程图
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            SplitContainer5.SplitterDistance = SplitterHeight '先展开后导出流程图
            Dim bt As Bitmap = New Bitmap(_borderPanel.Width, _borderPanel.Height)
            _borderPanel.DrawToBitmap(bt, New Rectangle(0, 0, _borderPanel.Width, _borderPanel.Height))
            Dim save As SaveFileDialog = New SaveFileDialog
            save.Filter = "图片（*.JPG）|*.JPG"
            If save.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim path As String = save.FileName
                If path <> "" Then
                    bt.Save(path)
                End If
            End If
            '导出图片后恢复是否展开状态
            If ToolStripButton7.Text = "展开工序流程图(&X)" Then
                SplitContainer5.SplitterDistance = 70
            Else
                SplitContainer5.SplitterDistance = SplitterHeight
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnSaveNgBackStation_Click(sender As Object, e As EventArgs) Handles btnSaveNgBackStation.Click
        Dim backStationId As String = txtNgBackStationId.SelectedValue

        Dim partid As String = Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        Dim revId As String = Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim

        Dim tmpstationid As String = txtNgCuurStationId.Text.Trim
        Dim tmpStaOrderid As String = txtNgCuurStationStaOrder.Text.Trim
        Try
            Dim sql As String = "update m_RPartStationD_t set NgBackStationId='" & backStationId & "' from m_RPartStationD_t where PPartid='" & partid & "' and Stationid='" & tmpstationid & "' and StaOrderid='" & tmpStaOrderid & "' and ScanOrderid=1 and Revid=" & revId & ""
            MainFrame.DbOperateUtils.ExecSQL(sql.ToString)

            BindFlow(partid, revId)
        Catch ex As Exception

        End Try



    End Sub
#End Region




    Private Sub chkBigCartonRepeatStyle_CheckedChanged(sender As Object, e As EventArgs) Handles chkBigCartonRepeatStyle.CheckedChanged
        If chkBigCartonRepeatStyle.Checked Then
            txtBigCartonRepeatPara.Enabled = True
            CobBigCartonChekTimes.Enabled = True
        Else
            CobBigCartonChekTimes.Enabled = False
            txtBigCartonRepeatPara.Enabled = False
        End If
    End Sub

    Private Sub CobBigCartonChekTimes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CobBigCartonChekTimes.SelectedIndexChanged
        Dim cur As Integer = Integer.Parse(CobBigCartonChekTimes.Text.ToString)
        Dim i As Integer = 0
        Dim parameter As String = ""
        If cur > 0 Then
            For i = 0 To cur - 1
                parameter = parameter + "," + "{@ppid}"
            Next
            parameter = parameter.Substring(1).ToString
        Else

        End If
        txtBigCartonRepeatPara.Text = parameter
    End Sub

    '复制料号 2018/12/28 关晓艳
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Try
            Dim strSQL As String = String.Format("select 1 from dbo.m_RPartStationM_t where PPartid='{0}'", Me.txtPartid.Text.Trim)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count < 1 Then
                MessageUtils.ShowInformation("料号没有设置料件版本，不可复制!")
                Return
            End If
            result = ""

            Dim fr As FrmRPartStationCopy = New FrmRPartStationCopy
            fr.Owner = Me
            fr.oldPartId = Me.txtPartid.Text.Trim
            fr.ShowDialog()


            If result = "1" Then
                Me.txtPartid.Text = newPartIdm
                LoadDataTodgvMain(Me.txtPartid.Text.Trim)
                Me.dgvMain.CurrentCell = Me.dgvMain.Item(0, 0)
                MessageUtils.ShowInformation("已生成版本: " & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "btnCopy_Click", "sys")
            Exit Sub
        End Try
    End Sub



    Private Sub btnModifyCode_Click(sender As Object, e As EventArgs) Handles btnModifyCode.Click
        Dim fr As FrmRStationNgOfPart = New FrmRStationNgOfPart()
        fr.station = txtStationid.Text
        fr.stationName = txtStationName.Text ' dgvRstation.Item(2, Me.dgvRstation.CurrentRow.Index).Value.ToString.Trim
        fr.m_strPartID = txtPartid.Text
        If Not IsNothing(Me.dgvMain.CurrentRow) Then
            fr.m_strCurrentVer = Me.dgvMain.Item("ColVer", Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        Else
            fr.m_strCurrentVer = ""
        End If
        m_strCurrVer = fr.m_strCurrentVer
        fr.ShowDialog()


        LoadDataTodgvNGCode(txtPartid.Text, Val(m_strCurrVer))
    End Sub

    Private Sub chkIsScanN_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsScanN.CheckedChanged
        If chkIsScanN.Checked Then
            TextBoxUL1.Text = "1"
        Else
            TextBoxUL1.Text = ""
        End If
    End Sub


    Private Sub toolPartBom_Click(sender As Object, e As EventArgs) Handles toolPartBom.Click

        Dim fr As FrmPartBom = New FrmPartBom
        fr.Owner = Me
        fr.PartNo = Me.txtPartid.Text.Trim
        fr.ShowDialog()
    End Sub

    Private Sub chkQCPlan_CheckedChanged(sender As Object, e As EventArgs) Handles chkQCPlan.CheckedChanged
        If chkQCPlan.Checked Then

            Me.CobQCPlan.Enabled = True
            Me.chkQCCheckOut.Checked = False
        Else
            Me.CobQCPlan.Enabled = False
        End If
    End Sub

    Private Sub SetCobQCPlan()
        Dim strSql As String
        Try
            strSql = "SELECT 0 AS SamplingId,'' AS SamplingName UNION select SamplingId,SamplingName from m_QCSamplingPlan_t WHERE USEY='Y' "
            Dim Dtable As DataTable = DbOperateUtils.GetDataTable(strSql)

            Me.CobQCPlan.DisplayMember = "SamplingName"
            Me.CobQCPlan.ValueMember = "SamplingId"
            Me.CobQCPlan.DataSource = Dtable.Copy

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub chkIsBarePpidLineWeight_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsBarePpidLineWeight.CheckedChanged
        If chkIsBarePpidLineWeight.Checked Then
            txtBarePpidUpLimitWeight.Enabled = True
            txtBarePpidLowLimitWeight.Enabled = True
        Else
            txtBarePpidUpLimitWeight.Enabled = False
            txtBarePpidLowLimitWeight.Enabled = False
            'Me.txtBarePpidLowLimitWeight.Text = String.Empty
            'Me.txtBarePpidUpLimitWeight.Text = String.Empty
        End If
    End Sub
End Class