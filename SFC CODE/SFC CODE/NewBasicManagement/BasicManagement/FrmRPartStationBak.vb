
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

#End Region

Public Class FrmRPartStationBak

#Region "窗體共有變量"

    Public opFlag As Int16 = 0   '狀態變更控制變量
    Dim FileNameStr As String = ""
    Public frmRstationid As String = "" 'FrmRPartStation怠砰肚stationid
    Public frmRstationname As String = "" 'FrmRPartStation怠砰肚stationname
    Public frmStationtype As String = ""
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
        Erightbutton() '讀取按鈕權限
        'opFlag = 0
        SetState(opFlag) '設置初始狀態
        TabControl1.Enabled = True
        FillListCheckBoxList(ChkListBox, "select id,RuleName from m_RPartStationRules_t where Ruleusey='Y' order by RuleOrderby desc", "id", "RuleName")
    End Sub
    Private Sub FillListCheckBoxList(ByVal ComControl As CheckedListBox, ByVal SqlStr As String, ByVal ValleField As String, ByVal TextField As String)
        Dim ScanClass As New SysDataBaseClass
        Dim dt As DataTable = ScanClass.GetDataTable(SqlStr)
        'Dim dr As DataRow = dt.NewRow
        'dr(ValleField) = ""
        'dr(TextField) = ""
        'dt.Rows.InsertAt(dr, 0)
        ComControl.DataSource = dt.DefaultView
        ComControl.ValueMember = ValleField
        ComControl.DisplayMember = TextField

    End Sub
    '按鈕權限判斷
    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02002' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        Dim Obj As Object
        While Reader.Read
            '通過控件名稱得到控件實例
            Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
            Obj.Tag = "Yes"
        End While
        Reader.Close()
        Conn.PubConnection.Close()
    End Sub
    '按鈕狀態設置
    Private Sub SetState(ByVal flag As Integer)
        Select Case flag
            Case 0 '初始查詢狀態
                Me.toolNew.Enabled = IIf(Me.toolNew.Tag.ToString <> "Yes", False, True)
                Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                Me.toolAbandon.Enabled = IIf(Me.toolAbandon.Tag.ToString <> "Yes", False, True)
                Me.toolComfire.Enabled = IIf(Me.toolComfire.Tag.ToString <> "Yes", False, True)
                ToolBackup.Enabled = IIf(Me.toolComfire.Tag.ToString <> "Yes", False, True)
                Me.toolBack.Enabled = False
                'Me.toolExport.Enabled = True

                Me.BnQuery.Text = "查 詢"
                'Me.BnQuery.Image = My.Resources.查詢

                Me.SplitContainer3.Panel1.Enabled = True
                Me.SplitContainer3.Panel2.Enabled = True
                Me.SplitContainer6.Enabled = False
                Me.ActiveControl = Me.txtPartid
                LblDelete.Enabled = False
                LblDown.Enabled = False
                LblSave.Enabled = False
                LblUp.Enabled = False
                ToolSel.Enabled = False
                'Me.TabControl1.Enabled = true
                'Me.toolScanRule.Enabled = False
            Case 1, 2 '新增/修改狀態
                Me.toolNew.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolComfire.Enabled = False
                Me.toolBack.Enabled = True
                'Me.toolExport.Enabled = False
                ToolBackup.Enabled = False
                Me.BnQuery.Text = IIf(opFlag = 1, "保 存", "查 詢")
                'Me.BnQuery.Image = IIf(opFlag = 1, My.Resources.保存, My.Resources.查詢)

                Me.SplitContainer3.Panel1.Enabled = IIf(opFlag = 1, True, False)
                Me.SplitContainer3.Panel2.Enabled = False
                Me.SplitContainer6.Enabled = True
                Me.ActiveControl = IIf(opFlag = 1, Me.txtPartid, Me.trvData)
                LblDelete.Enabled = True
                LblDown.Enabled = True
                LblSave.Enabled = True
                LblUp.Enabled = True
                LblQuery.Enabled = True
                ToolSel.Enabled = False
                'If txtTPartid.Text <> "" And txtStationid.Text <> "" Then
                '    Me.toolScanRule.Enabled = IIf(opFlag = 1, False, True)
                'End If

            Case 3 '新增/修改狀態
                Me.toolNew.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolComfire.Enabled = False
                Me.toolBack.Enabled = False
                Me.ToolSel.Enabled = True
                ToolBackup.Enabled = False
                txtPartid.Text = frmRstationname
                LoadDataTodgvMain(frmRstationname)
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
        Me.ChbScanPallet.Checked = False
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
        Me.Checktime.Enabled = True
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
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim DReader As SqlClient.SqlDataReader
        Dim SqlStr As String

        Me.dgvMain.Rows.Clear()
        Me.dgvSun.Rows.Clear()
        Me.trvData.Nodes.Clear()
        SqlStr = " select a.PPartid, a.Revid, case a.State when '0' then N'0-编辑中 ' when '1' then N'1-已确认' when '2' then N'2-已作废' when '5' then N'5-副流程' end as State," _
               & "        b.username UserID, convert(varchar(19),a.Intime,21) as intime, c.username as Canceluser," _
               & "	      convert(varchar(19),a.Canceltime,21) as canceltime,e.PartName,d.username Comfireuser, convert(varchar(19),Comfiretime,21) comfiretime " _
               & " from m_RPartStationM_t a join m_PartContrast_t e on a.PPartid=e.tavcpart and e.tavcpart=e.pavcpart " _
               & " left join m_users_t b on a.userid=b.userid " _
               & " left join m_users_t c on a.Canceluser=c.userid " _
               & " left join m_users_t d on a.Comfireuser=d.userid " _
               & " where PPartid='" & Partid & "' " _
               & " order by Revid desc "
        DReader = Conn.GetDataReader(SqlStr)
        Do While DReader.Read()
            dgvMain.Rows.Add(DReader.Item("PPartid").ToString, DReader.Item("PartName").ToString, DReader.Item("Revid").ToString, _
                        DReader.Item("State").ToString, DReader.Item("UserID").ToString, DReader.Item("Intime").ToString, _
                        DReader.Item("Comfireuser").ToString, DReader.Item("Comfiretime").ToString, _
                        DReader.Item("Canceluser").ToString, DReader.Item("Canceltime").ToString)
        Loop
        DReader.Close()
        Conn.PubConnection.Close()
        'Conn = Nothing

        If Me.dgvMain.Rows.Count = 0 AndAlso Me.dgvMain.CurrentRow Is Nothing Then Exit Sub
        LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim) 'TreeView數據綁定
        LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim) 'dgvSun數據綁定
    End Sub
    '加載treeview數據
    Private Sub LoadDataToTreeView(ByVal Partid As String, ByVal Rev As Integer)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
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
        SqlStr = " select a.StaOrderid,a.Stationid,b.StationName,'' as ScanOrderid,'' as TPartid,'' as TPartText,'1' as Dtype " _
               & " from m_RPartStationD_t a left join m_Rstation_t b on a.Stationid = b.Stationid " _
               & " where a.PPartid='" & Partid & "' and a.Revid =" & Rev _
               & " union " _
               & " select a.StaOrderid,a.Stationid,b.StationName,a.ScanOrderid,a.TPartid,a.TPartText,'2' as Dtype " _
               & " from m_RPartStationD_t a left join m_Rstation_t b on a.Stationid = b.Stationid " _
               & " where a.PPartid='" & Partid & "' and a.Revid =" & Rev
        dtable = Conn.GetDataTable(SqlStr)
        dStaView = New DataView(dtable)
        dScanView = New DataView(dtable)
        If dtable.Rows.Count <> 0 Then
            dStaView.RowFilter = "Dtype='1'"
            dStaView.Sort = "StaOrderid ASC"
            For i As Int16 = 0 To dStaView.Count - 1
                Dim node1 As TreeNode = New TreeNode(dStaView.Item(i)(0).ToString.Trim & ". " & dStaView.Item(i)(1).ToString.Trim & "-" & dStaView.Item(i)(2).ToString.Trim)
                node1.ImageIndex = 1
                node1.Tag = dStaView.Item(i)(0).ToString.Trim
                node.Nodes.Add(node1)

                dScanView.RowFilter = "Dtype='2' and StaOrderid='" & dStaView.Item(i)(0).ToString.Trim & "'"
                dScanView.Sort = "ScanOrderid ASC"
                For j As Int16 = 0 To dScanView.Count - 1
                    Dim node2 As TreeNode = New TreeNode(dScanView.Item(j)(0).ToString.Trim & "-" & dScanView.Item(j)(3).ToString.Trim & ". " & dScanView.Item(j)(4).ToString.Trim & "-" & dScanView.Item(j)(5).ToString.Trim)
                    node2.ImageIndex = 2
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
        Conn.PubConnection.Close()
        Conn = Nothing
    End Sub
    '根據查詢結果加載dgvSun數據
    Private Sub LoadDataTodgvSun(ByVal Partid As String, ByVal Rev As Integer)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlStr As String
        Dim DReader As SqlClient.SqlDataReader

        dgvSun.Rows.Clear()
        'Me.toolSunCount.Text = 0
        SqlStr = " select a.StaOrderid,a.Stationid,b.StationName as StationName,a.ScanOrderid, " _
               & "          a.TPartid,a.TPartText,a.IsMainBarcode,a.IsPrtSelf,a.IsAllowRe,a.IsCheckTestY,a.IsShowPacking,a.ShowColPos, " _
               & "          c.username username,convert(varchar(19),a.Intime,21) as intime,testtypeid  " _
               & " from m_RPartStationD_t a join m_Rstation_t b on a.Stationid = b.Stationid " _
               & " left join m_users_t c on a.userid=c.userid " _
               & " where a.PPartid='" & Partid & "' and a.Revid=" & Rev
        DReader = Conn.GetDataReader(SqlStr)
        Do While DReader.Read()
            dgvSun.Rows.Add(DReader.Item("StaOrderid"), DReader.Item("Stationid"), DReader.Item("StationName"), _
                         DReader.Item("ScanOrderid"), DReader.Item("TPartid"), DReader.Item("TPartText"), _
                        IIf(DReader.Item("IsMainBarcode").ToString = "Y", True, False), _
                        IIf(DReader.Item("IsPrtSelf").ToString = "Y", True, False), _
                        IIf(DReader.Item("IsAllowRe").ToString = "Y", True, False), _
                        IIf(DReader.Item("IsCheckTestY").ToString = "Y", True, False), _
                        IIf(DReader.Item("IsShowPacking").ToString = "Y", True, False), _
                        DReader.Item("ShowColPos"), DReader.Item("testtypeid")) '''', DReader.Item("username"), DReader.Item("Intime"),
        Loop
        'Me.toolSunCount.Text = Me.dgvSun.Rows.Count
        DReader.Close()
        Conn.PubConnection.Close()
        Conn = Nothing
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
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
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
                   & "                          IsPrtSelf, IsAllowRe,IsCheckTestY,IsShowPacking,ShowColPos,Remark, State, UserID, Intime,Cmby,IsSplit,SplitQty) " _
                   & " select PPartid, isnull(@MaxRevid+1,1) as Revid,StaOrderid,ScanOrderid,Stationid,TPartid,TPartText,IsReplaceable, " _
                   & "        case IsReplaceable when 'Y' then dbo.FunCreateReplaceID() when 'N' then Null end as ReplaceID,IsMainBarCode,IsPrtSelf,IsAllowRe, " _
                   & "        IsCheckTestY,IsShowPacking,ShowColPos,Remark,'0' as State,@Userid as UserID,getdate() as Intime,Cmby,IsSplit,SplitQty " _
                   & " from m_RPartStationD_t where PPartid=@PPartid and Revid=@Revid " _
            & " insert m_RPartStationT_t(ReplaceID, Itemid, TPartid, UserID, Intime) " _
            & " select c.ReplaceID, b.Itemid, b.TPartid, @Userid as UserID,GETDATE() as Intime " _
            & " from m_RPartStationD_t as a join m_RPartStationD_t as c on a.PPartid=c.PPartid and a.StaOrderid=c.StaOrderid and a.ScanOrderid=c.ScanOrderid " _
            & " join dbo.m_RPartStationT_t as b on a.ReplaceID=b.ReplaceID " _
            & " where a.PPartid=@PPartid and a.Revid= @Revid and c.Revid=isnull(@MaxRevid+1,1) " _
            & "delete from m_RPartStationT_t a join m_RPartStationD_t b on a.ReplaceID=b.ReplaceID where b.ppartid=@PPartid and Revid=@Revid "
            Try
                Conn.ExecSql(SqlStr)
                Conn.PubConnection.Close()
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
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
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
            Conn.ExecSql(SqlStr.ToString)
            Conn.PubConnection.Close()
            LoadDataTodgvMain(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            MessageBox.Show("作廢成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Conn = Nothing
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "toolAbandon_Click", "sys")
        End Try
    End Sub
    '返回
    Private Sub toolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        Me.btnDel.Enabled = True
        Me.btnDown.Enabled = True
        Me.btnUp.Enabled = True
        Me.btnSave.Enabled = True
        Me.BnSelectSta.Enabled = True
        opFlag = 0
        SetState(opFlag)
    End Sub
    '確認
    Private Sub toolComfire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolComfire.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dtable As New DataTable
        Dim SqlStr As String = ""   'SQL語句

        If Me.dgvMain.Rows.Count = 0 OrElse Me.dgvMain.CurrentRow Is Nothing Then Exit Sub
        If Me.dgvMain.Item(3, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "0" Then
            MessageBox.Show("只有[0-編輯中]狀態的版本才能被確認！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        'update by xavier   平整度|所有測試參數維護完整才允許確定''''''''''''''''''''''''''''''''''
        Dim SQL As String = "select TestTypeID from  m_RPartStationD_t where ppartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid='" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and IsCheckTestY='Y' "
        Dim dt As DataTable = Conn.GetDataTable(SQL)
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
            If Conn.GetDataTable(SqlStr).Rows(0)(0).ToString <> "0" And Conn.GetDataTable(SqlStr).Rows(0)(0).ToString <> "" Then
                MessageBox.Show("該料件測試ID{" & Conn.GetDataTable(SqlStr).Rows(0)(0).ToString & "}没有维护测试参数或者校验参数！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next
        Conn.PubConnection.Close()
        'update by xavier   平整度|所有測試參數維護完整才允許確定''''''''''''''''''''''''''''''''''

        SqlStr = "select 1 from m_RPartStationM_t where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and State=1" '是否存在確認記錄
        dtable = Conn.GetDataTable(SqlStr)
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
            Conn.ExecSql(SqlStr.ToString)
            LoadDataTodgvMain(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            MessageBox.Show("確認成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Conn.PubConnection.Close()
            Conn = Nothing
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
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
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
                & " set @Return=case (select 1 from dbo.m_PartContrast_t where TavcPart=@PPartid and usey='Y') when '1' then '1' else '2' end " _
                & " if @Return='1' begin select @MaxRevid=Max(Revid) from dbo.m_RPartStationM_t where PPartid=@PPartid " _
                & " insert dbo.m_RPartStationM_t(PPartid, Revid, State, UserID, Intime) " _
                & " select @PPartid as PPartid,isnull(@MaxRevid+1,1) as Revid,'0' as State,@Userid as Userid,getdate() as Intime " _
                & " select @MaxRow=COUNT(*) from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid " _
                & " set @id = 1 if @MaxRow>0 begin while @id <= @MaxRow begin " _
                & " select @StaOrderid = StaOrderid,@ScanOrderid=ScanOrderid from( " _
                & " select  StaOrderid,ScanOrderid,row_number()over(order by StaOrderid,ScanOrderid) as id " _
                & " from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid) a where id = @id " _
                & " insert m_RPartStationD_t (PPartid, Revid, StaOrderid, ScanOrderid, Stationid,  TPartid, " _
                & " TPartText,IsReplaceable, ReplaceID,IsMainBarcode,IsPrtSelf, IsAllowRe,IsCustPart,IsScanPallet,IsCheckTestY,TestTypeID,IsShowPacking,ShowColPos, Remark, State, UserID, Intime,Cmby,IsSplit,Ismatch,SplitBegin,SplitEnd,SplitQty) " _
                & " select PPartid, isnull(@MaxRevid+1,1) as Revid,StaOrderid,ScanOrderid,Stationid, " _
                & " TPartid,TPartText,IsReplaceable,case IsReplaceable when 'Y' then dbo.FunCreateReplaceID() when 'N' then Null end as ReplaceID," _
                & " IsMainBarCode,IsPrtSelf,IsAllowRe, IsCustPart,IsScanPallet, IsCheckTestY,TestTypeID,IsShowPacking,ShowColPos,Remark,'0' as State,@Userid as UserID,getdate() as Intime,Cmby,IsSplit,Ismatch,SplitBegin,SplitEnd,SplitQty " _
                & " from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid and  StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid " _
                & " set @id = @id +1 End End " _
                & " insert m_RPartStationT_t(ReplaceID, Itemid, TPartid, UserID, Intime) " _
                & " select c.ReplaceID, b.Itemid, b.TPartid, @Userid as UserID,GETDATE() as Intime " _
                & " from m_RPartStationD_t as a join m_RPartStationD_t as c on a.PPartid=c.PPartid and a.StaOrderid=c.StaOrderid and a.ScanOrderid=c.ScanOrderid " _
                & " join dbo.m_RPartStationT_t as b on a.ReplaceID=b.ReplaceID where a.PPartid=@PPartid and a.Revid=@MaxRevid and c.Revid=isnull(@MaxRevid+1,1) End " _
                & " select @Return as Re "


            dtable = Conn.GetDataTable(SqlStr)
            If dtable.Rows(0)(0).ToString.Trim = "1" Then
                LoadDataTodgvMain(Me.txtPartid.Text.Trim)
                Me.dgvMain.CurrentCell = Me.dgvMain.Item(0, 0)
                MessageBox.Show("已生成版本: " & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf dtable.Rows(0)(0).ToString.Trim = "2" Then
                MessageBox.Show("此料號在系統中不存在，請確認料號是否輸入正確！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActiveControl = Me.txtPartid
                Exit Sub
            End If
            Conn.PubConnection.Close()
            Me.SplitContainer3.Panel1.Enabled = False
        End If
    End Sub

#End Region

#Region "點擊控件之後顯示數據"
    '單擊dgvMain數據行在Treeview1中顯示相關數據
    Private Sub dgvMain_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMain.CellEnter
        If Me.dgvMain.Rows.Count = 0 OrElse Me.dgvMain.CurrentRow Is Nothing Then Exit Sub
        LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
        LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
        Me.LblVer.Text = Me.dgvMain.CurrentRow.Cells("colver").Value
    End Sub
    '樹結點選中后發生的狀態改變
    Private Sub trvData_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvData.AfterSelect
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
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

        SqlStr = " select c.SortName as Stationtype,a.Stationid,b.StationName,a.TPartid,a.TPartText,a.IsReplaceable,a.ReplaceID," _
               & " a.IsPrtSelf, a.IsAllowRe,a.IsScanPallet,a.IsCustPart,a.IsCheckTestY,a.TestTypeID,a.IsPrtPacking, a.IsShowPacking,a.isendsta,a.Cmby,a.ShowColPos,a.IsUpDown,a.isSplit,a.SplitQty,a.LotQty," _
               & " a.IsRelated,ContY,ASNY,LinePrtY,Ismatch,SplitBegin,SplitEnd,CheckSupY,CheckStaorder,CheckScanorder,IslineMbarcode,IsAllowNG," _
               & " IsAllowNGQty,NGqtySC,NGqtycount,IsUsb,isnull(IsPackingSame,'N') IsPackingSame,isnull(IsReadPCB,'N') IsReadPCB,isnull(IsWritePCB,'N') IsWritePCB, " _
               & " isnull(IsPalletSame,'') IsPalletSame,isnull(IsFWCheck,'N') IsFWCheck,Isnull(CheckIsPremix,'') CheckIsPremix " _
               & " from dbo.m_RPartStationD_t as a  " _
               & " left join m_Rstation_t b on a.Stationid = b.Stationid " _
               & " left join m_Sortset_t c on b.Stationtype=c.SortID and c.SortType='StationType' " _
               & " where a.PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' " _
               & "       and a.Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim _
               & "       and a.StaOrderid=case " & e.Node.Level & " when 0 then 1 when 1 then " & CurrSta & " when 2 then " & CurrSta & " end " _
               & "       and a.ScanOrderid=case " & e.Node.Level & " when 0 then 1 when 1 then 1 when 2 then " & CurrScan & " end "
        Dtable = Conn.GetDataTable(SqlStr)
        ClearObj()  '清空控件
        If Dtable.Rows.Count = 0 Then
            '按鈕權限控制
            If opFlag <> 0 Then
                Me.btnDel.Enabled = False
                Me.btnDown.Enabled = False
                Me.btnUp.Enabled = False
                Me.btnSave.Enabled = True
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
                End If
            End If
        Else
            Me.txtStationid.Text = IIf(e.Node.Level = 0, "", Dtable.Rows(0)("Stationid").ToString.Trim)
            Me.txtStationName.Text = IIf(e.Node.Level = 0, "", Dtable.Rows(0)("StationName").ToString.Trim)
            Me.txtStationtype.Text = IIf(e.Node.Level = 0, "", Dtable.Rows(0)("Stationtype").ToString.Trim)
            Me.txtTPartid.Text = IIf(e.Node.Level = 1, "", Dtable.Rows(0)("TPartid").ToString.Trim)
            Me.txtTPartText.Text = IIf(e.Node.Level = 1, "", Dtable.Rows(0)("TPartText").ToString.Trim)
            Me.ckbIsAllowRe.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsAllowRe").ToString.Trim = "Y", True, False)
            Me.ChbCustPart.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsCustPart").ToString.Trim = "Y", True, False)
            Me.ChbScanPallet.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsScanPallet").ToString.Trim = "Y", True, False)
            Me.ckbIsPrtSelf.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPrtSelf").ToString.Trim = "Y", True, False)
            Me.ChkIsPrtPacking.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPrtPacking").ToString.Trim = "Y", True, False)
            Me.ckbIsShowPacking.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsShowPacking").ToString.Trim = "Y", True, False)
            Me.RadNmerger.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("Cmby").ToString.Trim = "0", True, False)
            Me.RadQmerger.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("Cmby").ToString.Trim = "1", True, False)
            Me.RadHmerger.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("Cmby").ToString.Trim = "2", True, False)
            Me.ckbIsUpMaterial.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsUpDown").ToString.Trim = "Y", True, False)
            Me.Checktime.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("isendsta").ToString.Trim = "Y", True, False)
            Me.ckbIsCheckTestY.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsCheckTestY").ToString.Trim = "Y", True, False)
            If Me.ckbIsCheckTestY.Checked Then
                Me.ChbTestNum.SelectedIndex = IIf(e.Node.Level <> 1, Dtable.Rows(0)("TestTypeID").ToString.Trim.Split(";").Length() - 1, -1)
            End If
            Me.CboShowP.SelectedIndex = IIf(Me.ckbIsShowPacking.Checked = False, -1, Me.CboShowP.FindStringExact(Dtable.Rows(0)("ShowColPos").ToString.Trim))
            Me.CboShowP.Enabled = Me.ckbIsShowPacking.Checked

            'Me.LblSupplier.Text = Dtable.Rows(0)("Supplierid").ToString  CheckIsPremix
            Me.ChkIsPremix.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("CheckIsPremix").ToString.Trim = "Y", True, False)
            Me.ChkIsContinual.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("ContY").ToString.Trim = "Y", True, False)
            Me.ChkASN.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("ASNY").ToString.Trim = "Y", True, False)
            Me.ChkTTprint.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("LinePrtY").ToString.Trim = "Y", True, False)
            Me.ChkTTprint.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("LinePrtY").ToString.Trim = "Y", True, False)
            'isnull(IsPackingSame,'N') IsPackingSame,isnull(IsReadPCB,'N') IsReadPCB,isnull(IsWritePCB,'N') IsReadPCB,isnull(IsPalletSame,'') IsPalletSame
            Me.ChkSameCarton.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPackingSame").ToString.Trim = "Y", True, False)
            Me.ChkReadPCB.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsReadPCB").ToString.Trim = "Y", True, False)
            Me.ChkWritePCB.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsWritePCB").ToString.Trim = "Y", True, False)
            Me.ChkPalletSame.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPalletSame").ToString.Trim = "Y", True, False)
            Me.ChkFW.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsFWCheck").ToString.Trim = "Y", True, False)


            'Me.ChkWritePCB.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsWritePCB").ToString.Trim = "Y", True, False)
            'Me.ChkPalletSame.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsPalletSame").ToString.Trim = "Y", True, False)
            'Me.ChkWritePCB.Checked = If(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("LotQty").ToString.Trim = "Y", True, False)


            Me.Chkmatch.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("Ismatch").ToString.Trim = "Y", True, False)
            Me.TxtSpiltBegin.Text = Dtable.Rows(0)("splitbegin").ToString
            Me.TxtSpiltEnd.Text = Dtable.Rows(0)("splitend").ToString

            Me.ChkSupplier.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("CheckSupY").ToString.Trim = "Y", True, False)
            Me.CobCStation.Text = Dtable.Rows(0)("CheckStaorder").ToString
            Me.CobCScanId.Text = Dtable.Rows(0)("CheckScanorder").ToString

            If e.Node.Level <> 1 And Dtable.Rows.Count Then
                Me.TxtSplitQty.Checked = IIf(Dtable.Rows(0)("isSplit").ToString = "Y", True, False)
                Me.TxtSplitQty.Checked = IIf(Dtable.Rows(0)("SplitQty").ToString = "Y", True, False)
                Me.TxtLotQty.Text = Dtable.Rows(0)("LotQty").ToString
            End If
            Me.ChkRelate.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsRelated").ToString.Trim = "Y", True, False)
            ChkLinePinrtM.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IslineMbarcode").ToString.Trim = "Y", True, False) ''在线打印主条码
            ChkUsb.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsUsb").ToString.Trim = "Y", True, False) ''读取USB序号
            CheckNcount.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("IsAllowNG").ToString.Trim = "Y", True, False) ''允许发生不良的次数
            TxtNGcount.Text = Dtable.Rows(0)("IsAllowNGQty").ToString.Trim ''允许次数
            ChkClaQty.Checked = IIf(e.Node.Level <> 1 AndAlso Dtable.Rows(0)("NGqtySC").ToString.Trim = "Y", True, False) ''时间内不良达到数量时预警
            TxtClaQty.Text = Dtable.Rows(0)("NGqtycount").ToString.Trim ''多少个不良预警
            'Me.RadNmerger.Checked = IIf(e.Node.Level = 1 AndAlso Dtable.Rows(0)("Cmby").ToString.Trim = "0", True, False)Ismatch

            If RadQmerger.Checked = False AndAlso RadHmerger.Checked = False Then
                RadNmerger.Checked = True
            End If
            '' Me.CboTestType.SelectedIndex = IIf(Me.ckbIsCheckTestY.Checked = False, -1, Me.CboTestType.FindString(Dtable.Rows(0)("TestType").ToString.Trim))
            ''Me.CboTestType.Enabled = Me.ckbIsCheckTestY.Checked
            '按鈕權限控制
            If opFlag <> 0 Then
                If e.Node.Level = 0 Then '根節點
                    Me.btnDel.Enabled = False
                    Me.btnDown.Enabled = False
                    Me.btnUp.Enabled = False
                    Me.btnSave.Enabled = True
                    Me.BnSelectSta.Enabled = True
                    Me.btnAdd.Enabled = False
                    Me.btnClearpart.Enabled = False
                    Me.TxtTpartT.Enabled = False
                    Me.txtTPartid.Enabled = False
                    Me.txtTPartText.Enabled = False
                Else  '工站節點和掃描條碼節點
                    Me.btnDel.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
                    Me.btnDown.Enabled = IIf(e.Node.NextNode Is Nothing OrElse (e.Node.Level = 2 AndAlso CurrScan = "1"), False, True)
                    Me.btnUp.Enabled = IIf(e.Node.PrevNode Is Nothing OrElse (e.Node.Level = 2 AndAlso CurrScan < "3"), False, True)
                    Me.btnAdd.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
                    Me.btnClearpart.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
                    Me.btnSave.Enabled = True
                    Me.BnSelectSta.Enabled = False
                    Me.txtTPartid.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
                    Me.txtTPartText.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
                    Me.TxtTpartT.Enabled = IIf(e.Node.Level = 2 AndAlso CurrScan = "1", False, True)
                End If
            End If
            '刷出部件料號的替代料
            If Dtable.Rows(0)("IsReplaceable").ToString.Trim = "Y" Then
                SqlStr = "select itemid,TPartid from m_RPartStationT_t where ReplaceID='" & Dtable.Rows(0)("ReplaceID").ToString.Trim & "' order by itemid"
                Dtable = Conn.GetDataTable(SqlStr)
                For i As Integer = 0 To Dtable.Rows.Count - 1
                    Me.LstPartSum.Items.Add(Dtable.Rows(i)(1).ToString.Trim)
                Next
            End If

            SqlStr = "select RuleId from m_RPartStationCheckRule_t where Ppartid='" + Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim + "' and Tpartid='" + Me.txtTPartid.Text + "' and Revid='" + Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim + "' and StaOrderid=case " & e.Node.Level & " when 0 then 1 when 1 then " & CurrSta & " when 2 then " & CurrSta & " end and Stationid='" + Me.txtStationid.Text + "'  and ScanOrderid=case " & e.Node.Level & " when 0 then 1 when 1 then 1 when 2 then " & CurrScan & " end  "

            Dtable = Conn.GetDataTable(SqlStr)
            ChkListBox.ClearSelected()
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
            'For i As Integer = 0 To Dtable.Rows.Count - 1
            '    Dim id As String = Dtable.Rows(i)(0).ToString.Trim
            '    For k = 0 To ChkListBox.Items.Count - 1
            '        Dim val As String = CType(ChkListBox.Items(k), DataRowView).Row(0).ToString
            '        If id = val Then
            '            ChkListBox.SetItemChecked(k, True)
            '        End If
            '    Next
            'Next


        End If
        Conn.PubConnection.Close()
        Conn = Nothing
        'If txtStationid.Text <> "" And txtTPartid.Text <> "" And Me.LblSave.Enabled Then
        '    toolScanRule.Enabled = True
        'Else
        '    toolScanRule.Enabled = False
        'End If
    End Sub

#End Region

#Region "掃描工站設置明細"
    '查詢工站
    Private Sub BnSelectSta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnSelectSta.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim frm As New FrmRStationSet

        frm.opflag = 3
        frm.ShowDialog()
        Me.txtStationid.Text = frm.frmRstationid
        Me.txtStationName.Text = frm.frmRstationname
        Me.txtStationtype.Text = frm.frmStationtype
    End Sub
    '保存
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlStr As String = ""
        Dim oldTestId As String = ""
        If CheckDataForSave() = False Then Exit Sub
        If Me.trvData.SelectedNode Is Nothing Then Exit Sub
        'xavier_xu 2012/04/23測試id數量改變時，產生新測試ID'''''''''
        Dim IsNewTestID As Boolean = True
        If Me.trvData.SelectedNode.Level = 2 AndAlso ckbIsCheckTestY.Checked Then
            SqlStr = "select TestTypeID from  m_RPartStationD_t where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "'  and Revid='" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and  IsCheckTestY='Y' and   StaOrderid='" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(0).Trim & "' and ScanOrderid='" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(1).Trim & "' "
            If Conn.GetDataTable(SqlStr).Rows.Count > 0 Then
                oldTestId = Conn.GetDataTable(SqlStr).Rows(0)("TestTypeID").ToString().Trim()
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
        'update語句加入update對應的站別ID和掃描次序 StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid 
        Select Case Me.trvData.SelectedNode.Level
            Case 0  '根節點''@CheckSupY varchar(1),@CheckStaorder varchar(50),@CheckScanorder int
                'Insert新工站，Update所有工站的主條碼信息
                SqlStr = "declare @MaxSta int,@PPartid varchar(35),@Revid as int,@Stationid varchar(6),@TPartid varchar(35),@TPartText nvarchar(20) " _
                    & " declare @IsPrtSelf varchar(1),@IsAllowRe varchar(1),@IsScanPallet varchar(1),@IsCustPart varchar(1), @IsCheckTestY varchar(1),@TestID varchar(50),@IsShowPacking varchar(1),@IsCheckTime varchar(1),@ShowPos int,@Userid varchar(10) " _
                    & ",@IsCmby varchar(50),@IsUpDown varchar(50),@ContY varchar(50),@Asny varchar(50),@LinePrtY varchar(50),@Ismatch varchar(50),@splitbegin int,@splitend int,@CheckSupY varchar(1),@CheckStaorder varchar(50),@CheckScanorder int " _
                    & " set @PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' " _
                    & " set @Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim _
                    & " set @Stationid='" & Me.txtStationid.Text.Trim & "' " _
                    & " set @TPartid='" & Me.txtTPartid.Text.Trim & "' " _
                    & " set @TPartText=N'" & Me.txtTPartText.Text.Trim & "' " _
                    & " set @IsPrtSelf='" & IIf(Me.ckbIsPrtSelf.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowRe='" & IIf(Me.ckbIsAllowRe.Checked = True, "Y", "N") & "' " _
                    & " set @IsScanPallet='" & IIf(Me.ChbScanPallet.Checked = True, "Y", "N") & "' " _
                    & " set @IsCustPart='" & IIf(Me.ChbCustPart.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckTestY='" & IIf(Me.ckbIsCheckTestY.Checked = True, "Y", "N") & "' " _
                    & " set @TestID=case @IsCheckTestY when 'Y' then dbo.FunCreateTestID1(" & TestID & ") else '' end  " _
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
                    & " set @CheckStaorder='" & IIf(Me.ChkSupplier.Checked = True, Me.CobCStation.Text, "") & "' " _
                    & " set @CheckScanorder='" & IIf(Me.ChkSupplier.Checked = True, Me.CobCScanId.Text, "") & "' " _
                    & " set @ShowPos=" & IIf(Me.ckbIsShowPacking.Checked = True, Me.CboShowP.Text.Trim, 0) _
                    & " set @Userid='" & SysMessageClass.UseId.Trim.ToLower & "' " _
                    & " select @MaxSta=Max(StaOrderid) from dbo.m_RPartStationD_t where PPartid=@PPartid and Revid=@Revid " _
                    & " insert dbo.m_RPartStationD_t(PPartid, Revid, StaOrderid, ScanOrderid, Stationid, TPartid, TPartText,IsReplaceable,ReplaceID, IsMainBarcode,IsPrtSelf, IsAllowRe ,IsScanPallet,IsCustPart,  IsCheckTestY, IsShowPacking,isendsta,ShowColPos, State, UserID, Intime,Cmby,IsUpDown,testtypeid,IsSplit,SplitQty,IsRelated,ContY,ASNY,LinePrtY,Ismatch,splitbegin,splitend,CheckSupY,CheckStaorder,CheckScanorder) " _
                    & " values(@PPartid,@Revid,isnull(@MaxSta+1,1),1,@Stationid,@TPartid,@TPartText,'N',NULL,'Y',@IsPrtSelf,@IsAllowRe,@IsScanPallet,@IsCustPart,@IsCheckTestY,@IsShowPacking,@IsCheckTime,@ShowPos,'0',@Userid,getdate(),@IsCmby,@IsUpDown,@TestID,'" & SFlag & "','" & IIf(TxtSplitQty.Checked, "Y", "N") & "','" & sRelatedFlag & "',@ContY,@Asny,@LinePrtY,@Ismatch,@splitbegin,@splitend,@CheckSupY,@CheckStaorder,@CheckScanorder) "
                '當主條碼兩站設置屬性不一致會產生update問題，故註釋
                '& " Update dbo.m_RPartStationD_t " _
                '& " set userid=@Userid,intime=getdate(),IsPrtSelf=@IsPrtSelf,IsAllowRe=@IsAllowRe,IsCheckTestY=@IsCheckTestY,IsShowPacking=@IsShowPacking,isendsta=@IsCheckTime,ShowColPos=@ShowPos,Cmby=@IsCmby,IsUpDown=@IsUpDown,testtypeid=@TestID,IsSplit='" & SFlag & "',SplitQty='" & TxtSplitQty.Text & "',IsRelated='" & sRelatedFlag & "' " _
                '& " where PPartid=@PPartid and Revid=@Revid and IsMainBarcode='Y'"
            Case 1  '工站節點
                'Insert新部件條碼
                SqlStr = "declare @MaxItemid int,@MaxScanid int,@IsReplaceable varchar(1),@ReplaceID varchar(12),@TestID varchar(50),@PPartid varchar(35),@Revid int,@StaOrderid int " _
                    & " declare @Stationid varchar(6),@TPartid varchar(35),@TPartText nvarchar(20),@ContY varchar(50),@Asny varchar(50),@LinePrtY varchar(50),@Ismatch varchar(50),@splitbegin int,@splitend int,@CheckSupY varchar(1),@CheckStaorder varchar(50),@CheckScanorder int  " _
                    & " declare @IsPrtSelf varchar(1),@IsAllowRe varchar(1),@IsScanPallet varchar(1),@IsCustPart varchar(1),@IsCheckTestY varchar(1),@IsShowPacking varchar(1),@IsCheckTime varchar(1),@ShowPos int,@Userid varchar(10),@IsCmby varchar(50),@IsUpDown varchar(50) " _
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
                    & " set @IsScanPallet='" & IIf(Me.ChbScanPallet.Checked = True, "Y", "N") & "' " _
                    & " set @IsCustPart='" & IIf(Me.ChbCustPart.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckTestY='" & IIf(Me.ckbIsCheckTestY.Checked = True, "Y", "N") & "' "
                If IsNewTestID = True Then 'update by xavier_xu 多個測試ID
                    If ckbIsCheckTestY.Checked Then  '不需校驗測試結果時，不產生測試ID
                        SqlStr = SqlStr + " set @TestID=case @IsCheckTestY when 'Y' then dbo.FunCreateTestID1(" & TestID & ") else '' end "
                    Else
                        SqlStr = SqlStr + " set @TestID=''"
                    End If
                Else
                    SqlStr = SqlStr + " set @TestID='" & oldTestId & "'"
                End If
                SqlStr = SqlStr & " set @IsShowPacking='" & IIf(Me.ckbIsShowPacking.Checked = True, "Y", "N") & "' " _
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
                    & " set @Userid='" & SysMessageClass.UseId.Trim.ToLower & "' " _
                    & " select @MaxScanid=Max(ScanOrderid) from dbo.m_RPartStationD_t where PPartid=@PPartid and Revid=@Revid and StaOrderid=@StaOrderid " _
                    & " insert dbo.m_RPartStationD_t(PPartid, Revid, StaOrderid, ScanOrderid, Stationid, TPartid, TPartText,IsReplaceable,ReplaceID, IsMainBarcode, IsPrtSelf, IsAllowRe,IsScanPallet,IsCustPart, IsCheckTestY, IsShowPacking,isendsta,ShowColPos, State, UserID, Intime,Cmby,IsUpDown,testtypeid,IsSplit,SplitQty,IsRelated,ContY,ASNY,LinePrtY,Ismatch,splitbegin,splitend,CheckSupY,CheckStaorder,CheckScanorder) " _
                    & " values(@PPartid,@Revid,@StaOrderid,isnull(@MaxScanid+1,1),@Stationid,@TPartid,@TPartText,@IsReplaceable,@ReplaceID,'N',@IsPrtSelf,@IsAllowRe,@IsScanPallet,@IsCustPart ,@IsCheckTestY,@IsShowPacking,@IsCheckTime,@ShowPos,'0',@Userid,getdate(),@IsCmby,@IsUpDown,@TestID,'" & SFlag & "','" & IIf(TxtSplitQty.Checked, "Y", "N") & "','" & sRelatedFlag & "',@ContY,@Asny,@LinePrtY,@Ismatch,@splitbegin,@splitend,@CheckSupY,@CheckStaorder,@CheckScanorder) "
                If Me.LstPartSum.Items.Count > 0 Then
                    For i As Integer = 0 To Me.LstPartSum.Items.Count - 1
                        SqlStr = SqlStr & ControlChars.CrLf & " select @MaxItemid=Max(itemid) from dbo.m_RPartStationT_t where ReplaceID=@ReplaceID " _
                           & " insert m_RPartStationT_t(ReplaceID, Itemid, TPartid, UserID, Intime) values(@ReplaceID,isnull(@MaxItemid+1,1),'" & Me.LstPartSum.Items.Item(i).ToString.Trim & "',@Userid,getdate())"
                    Next
                End If
            Case 2  '部件條碼節點
                'Update原有部件條碼信息
                SqlStr = "declare @MaxItemid int,@IsReplaceable varchar(1),@ReplaceID varchar(12),@TestID varchar(50),@PPartid varchar(35),@Revid int,@StaOrderid int " _
                    & " declare @Stationid varchar(6),@TPartid varchar(35),@TPartText nvarchar(20),@ScanOrderid int,@ContY varchar(50),@Asny varchar(50),@LinePrtY varchar(50),@Ismatch varchar(50),@splitbegin int,@splitend int,@CheckSupY varchar(1),@CheckStaorder varchar(50),@CheckScanorder int   " _
                    & " declare @IsPrtSelf varchar(1),@IsAllowRe varchar(1),@IsScanPallet varchar(1),@IsCustPart varchar(1),@IsCheckTestY varchar(1),@IsShowPacking varchar(1),@IsCheckTime varchar(1),@ShowPos int,@Userid varchar(10),@IsCmby varchar(50),@IsUpDown varchar(50) " _
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
                    & " set @IsScanPallet='" & IIf(Me.ChbScanPallet.Checked = True, "Y", "N") & "' " _
                    & " set @IsCustPart='" & IIf(Me.ChbCustPart.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckTestY='" & IIf(Me.ckbIsCheckTestY.Checked = True, "Y", "N") & "' "
                If IsNewTestID = True Then 'update by xavier_xu 多個測試ID
                    If ckbIsCheckTestY.Checked Then  '不需校驗測試結果時，不產生測試ID
                        SqlStr = SqlStr + " set @TestID=case @IsCheckTestY when 'Y' then dbo.FunCreateTestID1(" & TestID & ") else '' end "
                    End If
                Else
                    SqlStr = SqlStr + " set @TestID='" & oldTestId & "'"
                End If
                SqlStr = SqlStr & " set @IsShowPacking='" & IIf(Me.ckbIsShowPacking.Checked = True, "Y", "N") & "' " _
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
                    & " set @Userid='" & SysMessageClass.UseId.Trim.ToLower & "' " _
                    & " if @ScanOrderid=1 begin " _
                    & " Update dbo.m_RPartStationD_t set userid=@Userid,intime=getdate(),IsPrtSelf=@IsPrtSelf,IsAllowRe=@IsAllowRe,IsScanPallet=@IsScanPallet,IsCustPart=@IsCustPart,IsCheckTestY=@IsCheckTestY,IsShowPacking=@IsShowPacking,isendsta=@IsCheckTime,ShowColPos=@ShowPos,Cmby=@IsCmby,IsUpDown=@IsUpDown,testtypeid=@TestID,IsSplit='" & SFlag & "',SplitQty='" & IIf(TxtSplitQty.Checked, "Y", "N") & "',IsRelated = '" & sRelatedFlag & "',ContY=@ContY,ASNY=@Asny,LinePrtY=@LinePrtY,Ismatch=@Ismatch,splitbegin=@splitbegin,splitend=@splitend,CheckSupY=@CheckSupY,CheckStaorder=@CheckStaorder,CheckScanorder=@CheckScanorder " _
                    & " where PPartid=@PPartid and Revid=@Revid and IsMainBarcode='Y' and StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid " _
                    & " end else begin " _
                    & " delete from m_RPartStationT_t where ReplaceID in(select ReplaceID from m_RPartStationD_t where PPartid=@PPartid and Revid=@Revid and StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid) " _
                    & " Update dbo.m_RPartStationD_t set userid=@Userid,intime=getdate(),TPartid=@TPartid,TPartText=@TPartText,IsReplaceable=@IsReplaceable,ReplaceID=@ReplaceID,IsPrtSelf=@IsPrtSelf,IsAllowRe=@IsAllowRe,IsScanPallet=@IsScanPallet,IsCustPart=@IsCustPart,IsCheckTestY=@IsCheckTestY,Cmby=@IsCmby,IsUpDown=@IsUpDown,IsShowPacking=@IsShowPacking,isendsta=@IsCheckTime,ShowColPos=@ShowPos,testtypeid=@TestID,IsSplit='" & SFlag & "',SplitQty='" & IIf(TxtSplitQty.Checked, "Y", "N") & "',IsRelated = '" & sRelatedFlag & "',ContY=@ContY,ASNY=@Asny,LinePrtY=@LinePrtY,Ismatch=@Ismatch,splitbegin=@splitbegin,splitend=@splitend,CheckSupY=@CheckSupY,CheckStaorder=@CheckStaorder,CheckScanorder=@CheckScanorder " _
                    & " where PPartid=@PPartid and Revid=@Revid and StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid " _
                    & " end "
                If Me.LstPartSum.Items.Count > 0 Then
                    For i As Integer = 0 To Me.LstPartSum.Items.Count - 1
                        SqlStr = SqlStr & ControlChars.CrLf & " select @MaxItemid=Max(itemid) from dbo.m_RPartStationT_t where ReplaceID=@ReplaceID " _
                            & " insert m_RPartStationT_t(ReplaceID, Itemid, TPartid,UserID, Intime) values(@ReplaceID,isnull(@MaxItemid+1,1),'" & Me.LstPartSum.Items.Item(i).ToString.Trim & "',@Userid,getdate())"
                    Next
                End If
        End Select
        If MessageBox.Show("請確認資料是否正確？", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            Conn.ExecSql(SqlStr)
            Conn.PubConnection.Close()
            MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            Me.trvData.SelectedNode = Me.trvData.Nodes(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "btnSave_Click", "sys")
        End Try
    End Sub
    '刪除
    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
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
            Conn.ExecSql(SqlStr)
            Conn.PubConnection.Close()
            MessageBox.Show("刪除成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            Me.trvData.SelectedNode = Me.trvData.Nodes(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "btnDel_Click", "sys")
        End Try
    End Sub
    '上移
    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
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
            Conn.ExecSql(SqlStr)
            Conn.PubConnection.Close()
            MessageBox.Show("上移成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            Me.trvData.SelectedNode = Me.trvData.Nodes(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "btnDel_Click", "sys")
        End Try
    End Sub
    '下移
    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
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
            Conn.ExecSql(SqlStr)
            Conn.PubConnection.Close()
            MessageBox.Show("下移成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            Me.trvData.SelectedNode = Me.trvData.Nodes(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "btnDel_Click", "sys")
        End Try
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
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlStr As String = "select 1 from m_PartContrast_t where tavcpart='" & sender.text.ToString.Trim & "' and usey='Y'"
        Dim mRead As SqlDataReader = Conn.GetDataReader(SqlStr)
        If mRead.HasRows = False Then
            MessageBox.Show("此料号在系统中不存在，请确认料号是否输入正确！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            sender.text = ""
            Me.ActiveControl = sender
            mRead.Close()
            Return False
        End If
        mRead.Close()
        'SqlStr = "select 1 from M_PartPack_t where  Partid='" & sender.text.ToString.Trim & "' And usey='Y' "
        'mRead = Conn.GetDataReader(SqlStr)
        'If mRead.HasRows = False Then
        '    MessageBox.Show("该料号未设置条码打印参数...", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    sender.text = ""
        '    Me.ActiveControl = sender
        '    mRead.Close()
        '    Return False
        'End If
        'mRead.Close()
        Return True

    End Function
    '保存前數據驗證
    Private Function CheckDataForSave() As Boolean
        If Me.trvData.Nodes.Count = 0 OrElse Me.trvData.SelectedNode Is Nothing Then Return False
        If txtStationid.Text.Trim = "" Then
            MessageBox.Show("請選擇掃描工站編號信息！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.BnSelectSta
            Return False
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
            'Dim Conn As New SysDataBaseClass
            'Dim mRead As SqlDataReader
            'Dim mPartSup As String = ""
            'mRead = Conn.GetDataReader("select ScanOrderid from m_RPartStationD_t where ppartid='" & Me.txtPartid.Text.Trim & "' and Stationid='" & Me.CobCStation.Text & "' and ScanOrderid='" & Me.CobCScanId.Text & "' and Revid='" & Me.dgvMain.CurrentRow.Cells("ColVer").Value & "'")
            'If mRead.HasRows Then
            '    While mRead.Read
            '        mPartSup = mRead!Tpartid.ToString
            '    End While
            'End If
            'mRead.Close()
            'Conn.GetDataReader("select Supplierid from m_PartContrast_t where TAvcPart='" & mPartSup & "'")
            'If mRead.HasRows Then
            '    While mRead.Read
            '        mPartSup = mRead!Supplierid.ToString
            '    End While
            'End If
            'mRead.Close()
            'If mPartSup <> Me.LblSupplier.Text Then
            '    MessageBox.Show("當前料號的供應商,必須與工站" & CobCStation.Text & "第" & CobCScanId.Text & "順序的一致！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.ActiveControl = Me.CobCScanId
            '    Return False
            'End If
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
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlStr As String = "select 1 from m_RPartStationD_t as a  left join m_Testtype_t as b on a.testtypeid=b.testtypeid where a.ppartid='" & Me.txtPartid.Text.Trim & "' and usey='Y'"
        If Conn.GetDataTable(SqlStr).Rows.Count > 0 Then
            'MessageBox.Show("此料號在系統中存在掃描數據，取消后需要重新掃描，是否確認取消！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If MessageBox.Show("此料號在系統中存在掃描數據，取消后需要重新掃描，是否確認取消！", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                Exit Sub
                Me.ckbIsCheckTestY.Checked = True
            Else
                Me.ChbTestNum.Enabled = False
                Me.ChbTestNum.SelectedIndex = -1
            End If

        End If
        Conn.PubConnection.Close()
    End Sub

#End Region

    '#Region "拆分數量"
    '    Private Sub TxtSplitQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    '        If e.KeyChar = Chr(13) Then
    '            Me.TxtSplitQty.Focus()
    '        End If
    '        If Me.TxtSplitQty.Text = "" And e.KeyChar = "0" Then
    '            e.Handled = True
    '            Exit Sub
    '        End If
    '        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = vbTab Or e.KeyChar = vbCr Or e.KeyChar = vbLf Or e.KeyChar = Chr(22) Or e.KeyChar = Chr(24) Or e.KeyChar = Chr(3) Then
    '            e.Handled = False
    '        Else
    '            e.Handled = True
    '        End If


    '    End Sub
    '#End Region

    Private Sub ChkSplit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ChkSplit.Checked Then
            Me.TxtLotQty.Enabled = True
            TxtLotQty.Focus()
        Else
            Me.TxtLotQty.Enabled = False
            TxtLotQty.Text = ""
        End If

    End Sub

#Region "只允许输入数字"
    Private Sub TxtSpiltBegin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLotQty.KeyPress

        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = Chr(13) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
#End Region

    Private Sub Chkmatch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.Chkmatch.Checked = True Then
            Me.TxtSpiltEnd.Enabled = True
            Me.TxtSpiltBegin.Enabled = True
        Else
            Me.TxtSpiltEnd.Enabled = False
            Me.TxtSpiltBegin.Enabled = False
        End If

    End Sub

    Private Sub ChkSupplier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ChkSupplier.Checked = False Then
            Me.CobCScanId.Items.Clear()
            Me.CobCStation.Items.Clear()
        Else
            If Me.trvData.SelectedNode.Index = -1 Then Exit Sub
            CobCStation.Items.Clear()
            Dim Conn As New SysDataBaseClass
            Dim mRead As SqlDataReader = Conn.GetDataReader("select distinct Stationid from m_RPartStationD_t where ppartid='" & Me.txtPartid.Text.Trim & "' and staorderid<='" & CInt(Me.trvData.SelectedNode.Index + 1) & "' and Revid='" & Me.dgvMain.CurrentRow.Cells("ColVer").Value & "'")
            If mRead.HasRows Then
                While mRead.Read
                    Me.CobCStation.Items.Add(mRead("Stationid").ToString)
                End While
            End If
            mRead.Close()
            Conn.PubConnection.Close()
        End If

    End Sub


    Private Sub CobCStation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.trvData.SelectedNode.Index = -1 Then Exit Sub
        CobCScanId.Items.Clear()
        Dim Conn As New SysDataBaseClass
        Dim mRead As SqlDataReader = Conn.GetDataReader("select ScanOrderid from m_RPartStationD_t where ppartid='" & Me.txtPartid.Text.Trim & "' and Stationid='" & Me.CobCStation.Text & "'  and Revid='" & Me.dgvMain.CurrentRow.Cells("ColVer").Value & "'")
        If mRead.HasRows Then
            While mRead.Read
                Me.CobCScanId.Items.Add(mRead("ScanOrderid").ToString)
            End While
        End If
        mRead.Close()
        Conn.PubConnection.Close()

    End Sub

    Private Sub ChbScanPallet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.ChbScanPallet.Checked Then
            Me.ChbCustPart.Enabled = True
        Else
            Me.ChbCustPart.Enabled = False
            Me.ChbCustPart.Checked = False

        End If
    End Sub


    Private Sub ckbIsCheckTestY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.ckbIsCheckTestY.Checked Then
            Me.ChbTestNum.Enabled = True
            Me.ChbTestNum.SelectedIndex = 0
        Else
            Me.ChbTestNum.Enabled = False
            Me.ChbTestNum.SelectedIndex = -1
        End If
    End Sub




    Private Sub LblUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUp.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
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
            Conn.ExecSql(SqlStr)
            Conn.PubConnection.Close()
            MessageBox.Show("上移成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            Me.trvData.SelectedNode = Me.trvData.Nodes(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "btnDel_Click", "sys")
        End Try

    End Sub

    Private Sub LblDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblDown.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
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
            Conn.ExecSql(SqlStr)
            Conn.PubConnection.Close()
            MessageBox.Show("下移成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            Me.trvData.SelectedNode = Me.trvData.Nodes(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "btnDel_Click", "sys")
        End Try
    End Sub

    Private Sub LblSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblSave.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlStr As String = ""
        Dim oldTestId As String = ""
        If CheckDataForSave() = False Then Exit Sub
        If Me.trvData.SelectedNode Is Nothing Then Exit Sub
        ''''
        Dim IsNewTestID As Boolean = True
        If Me.trvData.SelectedNode.Level = 2 AndAlso ckbIsCheckTestY.Checked Then
            SqlStr = "select TestTypeID from  m_RPartStationD_t where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "'  and Revid='" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and  IsCheckTestY='Y' and   StaOrderid='" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(0).Trim & "' and ScanOrderid='" & Me.trvData.SelectedNode.Tag.ToString.Trim.Split("-")(1).Trim & "' "
            If Conn.GetDataTable(SqlStr).Rows.Count > 0 Then
                oldTestId = Conn.GetDataTable(SqlStr).Rows(0)("TestTypeID").ToString().Trim()
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
        Dim sRelatedFlag As String = IIf(TxtSplitQty.Checked, "Y", "N")
        Dim TestID As String
        If Me.ChbTestNum.Text = "" Then
            TestID = "0"
        Else
            TestID = Me.ChbTestNum.Text
        End If
        'Dim fr As FrmRPartStationCheckRule = New FrmRPartStationCheckRule
        'fr._Ppartid = Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        'fr._Tpartid = txtTPartid.Text.Trim
        'fr._Stationid = txtStationid.Text.Trim
        'fr._Revid = Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        'fr._StaOrderid = CurrSta
        'fr._ScanOrderid = CurrScan
        'fr.ShowDialog()




        'update語句加入update對應的站別ID和掃描次序 StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid 
        Select Case Me.trvData.SelectedNode.Level
            Case 0  '根節點''@CheckSupY varchar(1),@CheckStaorder varchar(50),@CheckScanorder int
                'Insert新工站，Update所有工站的主條碼信息
                SqlStr = "declare @MaxSta int,@PPartid varchar(35),@Revid as int,@Stationid varchar(6),@TPartid varchar(35),@TPartText nvarchar(20) " _
                    & " declare @IsPrtSelf varchar(1),@IsAllowRe varchar(1),@IsScanPallet varchar(1),@IsCustPart varchar(1), @IsCheckTestY varchar(1),@TestID varchar(50),@IsPrtPacking varchar(1),@IsShowPacking varchar(1),@IsCheckTime varchar(1),@ShowPos int,@Userid varchar(10) " _
                    & ",@IsCmby varchar(50),@IsUpDown varchar(50),@ContY varchar(50),@Asny varchar(50),@LinePrtY varchar(50),@Ismatch varchar(50),@splitbegin int,@splitend int,@CheckSupY varchar(1),@CheckStaorder varchar(50),@CheckScanorder int " _
                    & ",@IslineMbarcode varchar(1),@IsAllowNG varchar(1),@IsAllowNGQty int ,@NGqtySC varchar(1),@NGqtycount int ,@IsUsb varchar(1),@IsPackingSame varchar(1),@IsWritePCB varchar(1) " _
                    & ",@IsReadPCB varchar(1),@IsPalletSame varchar(1),@IsFWCheck varchar(1),@ChkIsPremix varchar(1) " _
                    & " set @PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' " _
                    & " set @Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim _
                    & " set @Stationid='" & Me.txtStationid.Text.Trim & "' " _
                    & " set @TPartid='" & Me.txtTPartid.Text.Trim & "' " _
                    & " set @TPartText=N'" & Me.txtTPartText.Text.Trim & "' " _
                    & " set @ChkIsPremix='" & IIf(Me.ChkIsPremix.Checked = True, "Y", "N") & "' " _
                    & " set @IsPrtSelf='" & IIf(Me.ckbIsPrtSelf.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowRe='" & IIf(Me.ckbIsAllowRe.Checked = True, "Y", "N") & "' " _
                    & " set @IsScanPallet='" & IIf(Me.ChbScanPallet.Checked = True, "Y", "N") & "' " _
                    & " set @IsCustPart='" & IIf(Me.ChbCustPart.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckTestY='" & IIf(Me.ckbIsCheckTestY.Checked = True, "Y", "N") & "' " _
                    & " set @TestID=case @IsCheckTestY when 'Y' then dbo.FunCreateTestID1(" & TestID & ") else '' end  " _
                    & " set @IsPrtPacking='" & IIf(Me.ChkIsPrtPacking.Checked = True, "Y", "N") & "' " _
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
                    & " set @IsPackingSame='" & IIf(Me.ChkSameCarton.Checked = True, "Y", "N") & "' " _
                    & " set @IsReadPCB='" & IIf(Me.ChkReadPCB.Checked = True, "Y", "N") & "' " _
                    & " set @IsWritePCB='" & IIf(Me.ChkWritePCB.Checked = True, "Y", "N") & "' " _
                    & " set @IsFWCheck='" & IIf(Me.ChkFW.Checked = True, "Y", "N") & "' " _
                    & " set @IsPalletSame='" & IIf(Me.ChkPalletSame.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowNG='" & IIf(Me.CheckNcount.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowNGQty='" & IIf(Me.CheckNcount.Checked = True, Me.TxtNGcount.Text, "") & "' " _
                    & " set @NGqtySC='" & IIf(Me.ChkClaQty.Checked = True, "Y", "N") & "' " _
                    & " set @NGqtycount='" & IIf(Me.CheckNcount.Checked = True, Me.TxtClaQty.Text, "") & "' " _
                    & " set @CheckStaorder='" & IIf(Me.ChkSupplier.Checked = True, Me.CobCStation.Text, "") & "' " _
                    & " set @CheckScanorder='" & IIf(Me.ChkSupplier.Checked = True, Me.CobCScanId.Text, "") & "' " _
                    & " set @ShowPos='" & IIf(Me.ckbIsShowPacking.Checked = True, Me.CboShowP.Text.Trim, 0) & "' " _
                    & " set @Userid='" & SysMessageClass.UseId.Trim.ToLower & "' " _
                    & " select @MaxSta=Max(StaOrderid) from dbo.m_RPartStationD_t where PPartid=@PPartid and Revid=@Revid " _
                    & " insert dbo.m_RPartStationD_t(PPartid, Revid, StaOrderid, ScanOrderid, Stationid, TPartid, TPartText,IsReplaceable,ReplaceID, " _
                    & " IsMainBarcode,IsPrtSelf, IsAllowRe ,IsScanPallet,IsCustPart,  IsCheckTestY, IsPrtPacking,IsShowPacking,isendsta,ShowColPos, State, UserID, " _
                    & " Intime,Cmby,IsUpDown,testtypeid,IsSplit,SplitQty,LotQty,IsRelated,ContY,ASNY,LinePrtY,Ismatch,splitbegin,splitend,CheckSupY,CheckStaorder,CheckScanorder, " _
                    & " IslineMbarcode,IsAllowNG,IsAllowNGQty,NGqtySC,NGqtycount,IsUsb,isRplacePath,IsPackingSame,IsWritePCB,IsReadPCB,IsPalletSame,IsFWCheck,CheckIsPremix) " _
                    & " values(@PPartid,@Revid,isnull(@MaxSta+1,1),1,@Stationid,@TPartid,@TPartText,'N',NULL,'Y',@IsPrtSelf,@IsAllowRe,@IsScanPallet,@IsCustPart," _
                    & " @IsCheckTestY,@IsPrtPacking,@IsShowPacking,@IsCheckTime,@ShowPos,'0',@Userid,getdate(),@IsCmby,@IsUpDown,@TestID,'" & SFlag & "','" & IIf(TxtSplitQty.Checked, "Y", "N") & "'," _
                    & " '" & TxtLotQty.Text & "','" & sRelatedFlag & "',@ContY,@Asny,@LinePrtY,@Ismatch,@splitbegin,@splitend,@CheckSupY,@CheckStaorder,@CheckScanorder,@IslineMbarcode, " _
                    & " @IsAllowNG ,@IsAllowNGQty,@NGqtySC,@NGqtycount,@IsUsb,'" & "RPrintFile\" & txtPartid.Text.Trim & "\" & FileNameStr & "',@IsPackingSame,@IsWritePCB,@IsReadPCB,@IsPalletSame,@IsFWCheck,@ChkIsPremix) "
                Dim RuleId As String = ""
                Dim text As String = ""
                Dim k As Integer = 0
                For k = 0 To ChkListBox.CheckedItems.Count - 1
                    RuleId = CType(ChkListBox.CheckedItems(k), DataRowView).Row(0).ToString
                    text = CType(ChkListBox.CheckedItems(k), DataRowView).Row(1).ToString
                    SqlStr = SqlStr & ControlChars.CrLf & " insert m_RPartStationCheckRule_t(Ppartid,Tpartid,Revid,StaOrderid,Stationid,ScanOrderid,RuleId,Ruleusey,RuleOrderby)  " _
                           & " values (@PPartid,@TPartid,@Revid,isnull(@MaxSta+1,1),@Stationid,1,'" & RuleId & "','Y','" & k & "')"
                Next
                'fr._Ppartid = Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
                'fr._Tpartid = txtTPartid.Text.Trim
                'fr._Stationid = txtStationid.Text.Trim
                'fr._Revid = Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
                'fr._StaOrderid = CurrSta
                'fr._ScanOrderid = CurrScan


                '當主條碼兩站設置屬性不一致會產生update問題，故註釋
                '& " Update dbo.m_RPartStationD_t " _
                '& " set userid=@Userid,intime=getdate(),IsPrtSelf=@IsPrtSelf,IsAllowRe=@IsAllowRe,IsCheckTestY=@IsCheckTestY,IsShowPacking=@IsShowPacking,isendsta=@IsCheckTime,ShowColPos=@ShowPos,Cmby=@IsCmby,IsUpDown=@IsUpDown,testtypeid=@TestID,IsSplit='" & SFlag & "',SplitQty='" & TxtSplitQty.Text & "',IsRelated='" & sRelatedFlag & "' " _
                '& " where PPartid=@PPartid and Revid=@Revid and IsMainBarcode='Y'"
            Case 1  '工站節點
                'Insert新部件條碼
                SqlStr = "declare @MaxItemid int,@MaxScanid int,@IsReplaceable varchar(1),@ReplaceID varchar(12),@TestID varchar(50),@PPartid varchar(35),@Revid int,@StaOrderid int " _
                    & " declare @Stationid varchar(6),@TPartid varchar(35),@TPartText nvarchar(20),@ContY varchar(50),@Asny varchar(50),@LinePrtY varchar(50),@Ismatch varchar(50),@splitbegin int,@splitend int,@CheckSupY varchar(1),@CheckStaorder varchar(50),@CheckScanorder int  " _
                    & " declare @IsPrtSelf varchar(1),@IsAllowRe varchar(1),@IsScanPallet varchar(1),@IsCustPart varchar(1),@IsCheckTestY varchar(1),@IsPrtPacking varchar(1),@IsShowPacking varchar(1),@IsCheckTime varchar(1),@ShowPos int,@Userid varchar(10),@IsCmby varchar(50),@IsUpDown varchar(50) " _
                    & ",@IslineMbarcode varchar(1),@IsAllowNG varchar(1),@IsAllowNGQty int ,@ChkIsPremix varchar(1),@NGqtySC varchar(1),@NGqtycount int ,@IsUsb varchar(1),@IsPackingSame varchar(1),@IsWritePCB varchar(1),@IsReadPCB varchar(1),@IsPalletSame varchar(1),@IsFWCheck varchar(1) " _
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
                    & " set @IsScanPallet='" & IIf(Me.ChbScanPallet.Checked = True, "Y", "N") & "' " _
                    & " set @ChkIsPremix='" & IIf(Me.ChkIsPremix.Checked = True, "Y", "N") & "' " _
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
                    & " set @IsPackingSame='" & IIf(Me.ChkSameCarton.Checked = True, "Y", "N") & "' " _
                    & " set @IsReadPCB='" & IIf(Me.ChkReadPCB.Checked = True, "Y", "N") & "' " _
                    & " set @IsWritePCB='" & IIf(Me.ChkWritePCB.Checked = True, "Y", "N") & "' " _
                    & " set @IsFWCheck='" & IIf(Me.ChkFW.Checked = True, "Y", "N") & "' " _
                    & " set @IsPalletSame='" & IIf(Me.ChkPalletSame.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowNG='" & IIf(Me.CheckNcount.Checked = True, "Y", "N") & "' " _
                    & " set @ChkIsPremix='" & IIf(Me.ChkIsPremix.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowNGQty='" & IIf(Me.CheckNcount.Checked = True, Me.TxtNGcount.Text, "") & "' " _
                    & " set @NGqtySC='" & IIf(Me.ChkClaQty.Checked = True, "Y", "N") & "' " _
                    & " set @NGqtycount='" & IIf(Me.CheckNcount.Checked = True, Me.TxtClaQty.Text, "") & "' " _
                    & " set @Userid='" & SysMessageClass.UseId.Trim.ToLower & "' " _
                    & " select @MaxScanid=Max(ScanOrderid) from dbo.m_RPartStationD_t where PPartid=@PPartid and Revid=@Revid and StaOrderid=@StaOrderid " _
                    & " insert dbo.m_RPartStationD_t(PPartid, Revid, StaOrderid, ScanOrderid, Stationid, TPartid, TPartText,IsReplaceable,ReplaceID, IsMainBarcode, " _
                    & " IsPrtSelf, IsAllowRe,IsScanPallet,IsCustPart, IsCheckTestY, IsPrtPacking,IsShowPacking,isendsta,ShowColPos, State, UserID, Intime,Cmby,IsUpDown,testtypeid," _
                    & " IsSplit,SplitQty,LotQty,IsRelated,ContY,ASNY,LinePrtY,Ismatch,splitbegin,splitend,CheckSupY,CheckStaorder,CheckScanorder" _
                    & " ,IslineMbarcode,IsAllowNG,IsAllowNGQty,NGqtySC,NGqtycount,IsUsb,isRplacePath,IsPackingSame,IsWritePCB,IsReadPCB,IsPalletSame,IsFWCheck,CheckIsPremix) " _
                    & " values(@PPartid,@Revid,@StaOrderid,isnull(@MaxScanid+1,1),@Stationid,@TPartid,@TPartText,@IsReplaceable,@ReplaceID,'N',@IsPrtSelf,@IsAllowRe," _
                    & " @IsScanPallet,@IsCustPart ,@IsCheckTestY,@IsPrtPacking,@IsShowPacking,@IsCheckTime,@ShowPos,'0',@Userid,getdate(),@IsCmby,@IsUpDown,@TestID,'" & SFlag & "'," _
                    & " '" & IIf(TxtSplitQty.Checked, "Y", "N") & "','" & TxtLotQty.Text & "','" & sRelatedFlag & "',@ContY,@Asny,@LinePrtY,@Ismatch,@splitbegin,@splitend,@CheckSupY,@CheckStaorder,@CheckScanorder, " _
                    & " @IslineMbarcode,@IsAllowNG,@IsAllowNGQty,@NGqtySC,@NGqtycount,@IsUsb,'" & "RPrintFile\" & txtPartid.Text.Trim & "\" & FileNameStr & "',@IsPackingSame,@IsWritePCB,@IsReadPCB,@IsPalletSame,@IsFWCheck,@ChkIsPremix) "
                Dim RuleId As String = ""
                Dim text As String = ""
                Dim k As Integer = 0
                For k = 0 To ChkListBox.CheckedItems.Count - 1
                    RuleId = CType(ChkListBox.CheckedItems(k), DataRowView).Row(0).ToString
                    text = CType(ChkListBox.CheckedItems(k), DataRowView).Row(1).ToString
                    SqlStr = SqlStr & ControlChars.CrLf & " insert m_RPartStationCheckRule_t(Ppartid,Tpartid,Revid,StaOrderid,Stationid,ScanOrderid,RuleId,Ruleusey,RuleOrderby)  " _
                           & " values (@PPartid,@TPartid,@Revid,@StaOrderid,@Stationid,isnull(@MaxScanid+1,1),'" & RuleId & "','Y','" & k & "')"
                Next
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
                    & " declare @IsPrtSelf varchar(1),@IsAllowRe varchar(1),@IsScanPallet varchar(1),@IsCustPart varchar(1),@IsCheckTestY varchar(1),@IsPrtPacking varchar(1),@IsShowPacking varchar(1), " _
                    & " @IsCheckTime varchar(1),@ShowPos int,@Userid varchar(10),@IsCmby varchar(50),@IsUpDown varchar(50) " _
                    & ",@IslineMbarcode varchar(1),@IsAllowNG varchar(1),@IsAllowNGQty int ,@NGqtySC varchar(1),@NGqtycount int ,@IsUsb varchar(1)" _
                    & ",@IsPackingSame varchar(1),@IsWritePCB varchar(1),@ChkIsPremix varchar(1),@IsReadPCB varchar(1),@IsPalletSame varchar(1),@IsFWCheck varchar(1) " _
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
                    & " set @IsScanPallet='" & IIf(Me.ChbScanPallet.Checked = True, "Y", "N") & "' " _
                    & " set @IsCustPart='" & IIf(Me.ChbCustPart.Checked = True, "Y", "N") & "' " _
                    & " set @ChkIsPremix='" & IIf(Me.ChkIsPremix.Checked = True, "Y", "N") & "' " _
                    & " set @IsCheckTestY='" & IIf(Me.ckbIsCheckTestY.Checked = True, "Y", "N") & "' "
                If IsNewTestID = True Then '多個測試ID
                    If ckbIsCheckTestY.Checked Then  '不需校驗測試結果時，不產生測試ID
                        SqlStr = SqlStr + " set @TestID=case @IsCheckTestY when 'Y' then dbo.FunCreateTestID1(" & TestID & ") else '' end "
                    End If
                Else
                    SqlStr = SqlStr + " set @TestID='" & oldTestId & "'"
                End If
                SqlStr = SqlStr & " set @IsShowPacking='" & IIf(Me.ckbIsShowPacking.Checked = True, "Y", "N") & "' " _
                    & " set @IsPrtPacking='" & IIf(Me.ChkIsPrtPacking.Checked = True, "Y", "N") & "' " _
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
                    & " set @IsPackingSame='" & IIf(Me.ChkSameCarton.Checked = True, "Y", "N") & "' " _
                    & " set @IsReadPCB='" & IIf(Me.ChkReadPCB.Checked = True, "Y", "N") & "' " _
                    & " set @IsWritePCB='" & IIf(Me.ChkWritePCB.Checked = True, "Y", "N") & "' " _
                    & " set @IsFWCheck='" & IIf(Me.ChkFW.Checked = True, "Y", "N") & "' " _
                    & " set @IsPalletSame='" & IIf(Me.ChkPalletSame.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowNG='" & IIf(Me.CheckNcount.Checked = True, "Y", "N") & "' " _
                    & " set @ChkIsPremix='" & IIf(Me.ChkIsPremix.Checked = True, "Y", "N") & "' " _
                    & " set @IsAllowNGQty='" & IIf(Me.CheckNcount.Checked = True, Me.TxtNGcount.Text, "") & "' " _
                    & " set @NGqtySC='" & IIf(Me.ChkClaQty.Checked = True, "Y", "N") & "' " _
                    & " set @NGqtycount='" & IIf(Me.CheckNcount.Checked = True, Me.TxtClaQty.Text, "") & "' " _
                    & " set @Userid='" & SysMessageClass.UseId.Trim.ToLower & "' " _
                    & " if @ScanOrderid=1 begin " _
                    & " Update dbo.m_RPartStationD_t set userid=@Userid,isRplacePath='" & "RPrintFile\" & txtPartid.Text.Trim & "\" & FileNameStr & "',intime=getdate(),IsPrtSelf=@IsPrtSelf,IsAllowRe=@IsAllowRe," _
                    & " IsScanPallet=@IsScanPallet,IsCustPart=@IsCustPart,IsCheckTestY=@IsCheckTestY,IsPrtPacking=@IsPrtPacking,IsShowPacking=@IsShowPacking,isendsta=@IsCheckTime,ShowColPos=@ShowPos," _
                    & " Cmby=@IsCmby,IsUpDown=@IsUpDown,testtypeid=@TestID,IsSplit='" & SFlag & "',SplitQty='" & IIf(TxtSplitQty.Checked, "Y", "N") & "',LotQty='" & TxtLotQty.Text & "',IsRelated = '" & sRelatedFlag & "'," _
                    & " ContY=@ContY,ASNY=@Asny,LinePrtY=@LinePrtY,Ismatch=@Ismatch,splitbegin=@splitbegin,splitend=@splitend,CheckSupY=@CheckSupY,CheckIsPremix=@ChkIsPremix," _
                    & " CheckStaorder=@CheckStaorder,CheckScanorder=@CheckScanorder,IsPackingSame=@IsPackingSame,IsReadPCB=@IsReadPCB,IsWritePCB=@IsWritePCB,IsPalletSame=@IsPalletSame,IsFWCheck=@IsFWCheck " _
                    & " ,IslineMbarcode=@IslineMbarcode,IsUsb=@IsUsb,IsAllowNG=@IsAllowNG,IsAllowNGQty=@IsAllowNGQty,NGqtySC=@NGqtySC,NGqtycount=@NGqtycount " _
                    & " where PPartid=@PPartid and Revid=@Revid and IsMainBarcode='Y' and StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid " _
                    & " end else begin " _
                    & " delete from m_RPartStationT_t where ReplaceID in(select ReplaceID from m_RPartStationD_t where PPartid=@PPartid and Revid=@Revid and StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid) " _
                    & " Update dbo.m_RPartStationD_t set userid=@Userid,isRplacePath='" & "RPrintFile\" & txtPartid.Text.Trim & "\" & FileNameStr & "',intime=getdate(), " _
                    & " TPartid=@TPartid,TPartText=@TPartText,IsReplaceable=@IsReplaceable,IsPackingSame=@IsPackingSame,IsReadPCB=@IsReadPCB,IsWritePCB=@IsWritePCB,IsPalletSame=@IsPalletSame,IsFWCheck=@IsFWCheck," _
                    & " ReplaceID=@ReplaceID,IsPrtSelf=@IsPrtSelf,IsAllowRe=@IsAllowRe,IsScanPallet=@IsScanPallet,IsCustPart=@IsCustPart,IsCheckTestY=@IsCheckTestY,CheckIsPremix=@ChkIsPremix," _
                    & " Cmby=@IsCmby,IsUpDown=@IsUpDown,IsPrtPacking=@IsPrtPacking,IsShowPacking=@IsShowPacking,isendsta=@IsCheckTime,ShowColPos=@ShowPos,testtypeid=@TestID," _
                    & " IsSplit='" & SFlag & "',SplitQty='" & IIf(TxtSplitQty.Checked, "Y", "N") & "',LotQty='" & TxtLotQty.Text & "',IsRelated = '" & sRelatedFlag & "',ContY=@ContY,ASNY=@Asny,LinePrtY=@LinePrtY," _
                    & " Ismatch=@Ismatch,splitbegin=@splitbegin,splitend=@splitend,CheckSupY=@CheckSupY,CheckStaorder=@CheckStaorder,CheckScanorder=@CheckScanorder, " _
                    & " IslineMbarcode=@IslineMbarcode,IsUsb=@IsUsb,IsAllowNG=@IsAllowNG,IsAllowNGQty=@IsAllowNGQty,NGqtySC=@NGqtySC,NGqtycount=@NGqtycount " _
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
        If Me.ChkLinePinrtM.Checked = True Or Me.ChkIsPrtPacking.Checked = True Then
            If Me.txtFilename.Text = "" Then
                MessageBox.Show("勾选打印成品条码时，请上传打印模版！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Dim SavePathFileName As String = String.Empty
            Dim value As String
            'Dim FilePath As String
            ' value = "RPrintFile\" & txtPartid.Text.Trim
            value = VbCommClass.VbCommClass.PrintDataModle & "RPrintFile\" & Me.txtPartid.Text.Trim
            If Me.txtFilename.Text <> "" Then
                If System.IO.Directory.Exists(value) = False Then
                    Directory.CreateDirectory(value)
                    'File.Create(FilePath & FilePath)
                End If
                File.Copy(Me.txtFilename.Text, value & "\" & FileNameStr, True)
            End If
        End If
        'If MessageBox.Show("請確認資料是否正確？", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            Conn.ExecSql(SqlStr)
            Conn.PubConnection.Close()
            MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            Me.trvData.SelectedNode = Me.trvData.Nodes(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "btnSave_Click", "sys")
        End Try
    End Sub

    Private Sub LblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblDelete.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
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
            Conn.ExecSql(SqlStr)
            Conn.PubConnection.Close()
            MessageBox.Show("刪除成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDataToTreeView(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            LoadDataTodgvSun(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim, Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            Me.trvData.SelectedNode = Me.trvData.Nodes(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "btnDel_Click", "sys")
        End Try
    End Sub


    Private Sub LblQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblQuery.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
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
                & " set @Return=case (select 1 from dbo.m_PartContrast_t where TavcPart=@PPartid and TavcPart=PavcPart and usey='Y') when '1' then '1' else '2' end " _
                & " if @Return='1' begin select @MaxRevid=Max(Revid) from dbo.m_RPartStationM_t where PPartid=@PPartid " _
                & " insert dbo.m_RPartStationM_t(PPartid, Revid, State, UserID, Intime) " _
                & " select @PPartid as PPartid,isnull(@MaxRevid+1,1) as Revid,'0' as State,@Userid as Userid,getdate() as Intime " _
                & " select @MaxRow=COUNT(*) from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid " _
                & " set @id = 1 if @MaxRow>0 begin while @id <= @MaxRow begin " _
                & " select @StaOrderid = StaOrderid,@ScanOrderid=ScanOrderid from( " _
                & " select  StaOrderid,ScanOrderid,row_number()over(order by StaOrderid,ScanOrderid) as id " _
                & " from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid) a where id = @id " _
                & " insert m_RPartStationD_t (PPartid, Revid, StaOrderid, ScanOrderid, Stationid,  TPartid, " _
                & " TPartText,IsReplaceable, ReplaceID,IsMainBarcode,IsPrtSelf, IsAllowRe,IsCustPart,IsScanPallet,IsCheckTestY,TestTypeID,IsShowPacking," _
                & " ShowColPos, Remark, State, UserID, Intime,Cmby,IsSplit,Ismatch,SplitBegin,SplitEnd,SplitQty,IslineMbarcode,IsAllowNG,IsAllowNGQty," _
                & " NGqtySC,NGqtycount,IsUsb,isRplacePath,IsPackingSame,IsReadPCB,IsWritePCB) " _
                & " select PPartid, isnull(@MaxRevid+1,1) as Revid,StaOrderid,ScanOrderid,Stationid, " _
                & " TPartid,TPartText,IsReplaceable,case IsReplaceable when 'Y' then dbo.FunCreateReplaceID() when 'N' then Null end as ReplaceID," _
                & " IsMainBarCode,IsPrtSelf,IsAllowRe, IsCustPart,IsScanPallet, IsCheckTestY,TestTypeID,IsShowPacking,ShowColPos,Remark,'0' as State," _
                & "@Userid as UserID,getdate() as Intime,Cmby,IsSplit,Ismatch,SplitBegin,SplitEnd,SplitQty,IslineMbarcode,IsAllowNG,IsAllowNGQty,NGqtySC," _
                & "NGqtycount,IsUsb,isRplacePath,IsPackingSame,IsReadPCB,IsWritePCB " _
                & " from m_RPartStationD_t where PPartid=@PPartid and Revid=@MaxRevid and  StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid " _
                & " insert m_RPartStationCheckRule_t(Ppartid,Tpartid,Revid,StaOrderid,Stationid,ScanOrderid,RuleId,Ruleusey,RuleOrderby) " _
                & " select Ppartid,Tpartid,Revid=isnull(@MaxRevid+1,1),StaOrderid,Stationid,ScanOrderid,RuleId,Ruleusey,RuleOrderby from m_RPartStationCheckRule_t where PPartid=@PPartid and Revid=@MaxRevid and  StaOrderid=@StaOrderid and ScanOrderid=@ScanOrderid " _
                & " set @id = @id +1 End End " _
                & " insert m_RPartStationT_t(ReplaceID, Itemid, TPartid, UserID, Intime) " _
                & " select c.ReplaceID, b.Itemid, b.TPartid, @Userid as UserID,GETDATE() as Intime " _
                & " from m_RPartStationD_t as a join m_RPartStationD_t as c on a.PPartid=c.PPartid and a.StaOrderid=c.StaOrderid and a.ScanOrderid=c.ScanOrderid " _
                & " join dbo.m_RPartStationT_t as b on a.ReplaceID=b.ReplaceID where a.PPartid=@PPartid and a.Revid=@MaxRevid and c.Revid=isnull(@MaxRevid+1,1) End " _
                & " select @Return as Re "


            dtable = Conn.GetDataTable(SqlStr)
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
            Conn.PubConnection.Close()
        End If
    End Sub

    Private Sub CheckNcount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckNcount.CheckedChanged

        'IIf(CheckNcount.Checked = True, TxtNGcount.Enabled = True, TxtNGcount.Enabled = False
        If CheckNcount.Checked Then
            TxtNGcount.Enabled = True
        Else
            TxtNGcount.Enabled = False
        End If

    End Sub

    Private Sub ChkClaQty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkClaQty.CheckedChanged
        'IIf(ChkClaQty.Checked = True, TxtClaQty.Enabled = True, TxtClaQty.Enabled = False)
        If ChkClaQty.Checked Then
            TxtClaQty.Enabled = True
        Else
            TxtClaQty.Enabled = False
        End If
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click

        'Dim files() As String
        Dim result As DialogResult = OpenFileDialog.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtFilename.Text = OpenFileDialog.FileName
            ' Open the format.
            FileNameStr = OpenFileDialog.SafeFileNames(0).ToString
        End If

    End Sub

    Private Sub ChkLinePinrtM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLinePinrtM.CheckedChanged, ChkIsPrtPacking.CheckedChanged

        If ChkLinePinrtM.Checked Or ChkIsPrtPacking.Checked Then
            txtFilename.Enabled = True
            Me.btnOpen.Enabled = True
        Else
            txtFilename.Enabled = False
            Me.btnOpen.Enabled = False
        End If

    End Sub


    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        'Dim FrmFWModify As New FrmFWModify
        'FrmFWModify.ShowDialog()
    End Sub

    Private Sub ToolSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSel.Click

        If Me.ToolSel.Enabled = False Then Exit Sub
        If Me.dgvMain.Rows.Count = 0 OrElse Me.dgvMain.CurrentRow Is Nothing Then Exit Sub
        If Me.dgvMain.Item(3, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) = "2" Then
            MessageBox.Show("该笔资料已作废", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        frmRstationid = Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        'frmRstationname = Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        'frmStationtype = Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        Me.Close()

    End Sub

    Private Sub ToolBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBackup.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlStr As String = ""   '作廢主表SQL語句

        If Me.dgvMain.Rows.Count = 0 OrElse Me.dgvMain.CurrentRow Is Nothing Then Exit Sub
        If Me.dgvMain.Item(3, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) = "2" Then
            MessageBox.Show("該版本已經作廢，不能再設置為副流程！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        SqlStr = " update m_RPartStationM_t set State=5,Canceluser='" & SysMessageClass.UseId.ToLower.Trim & "',Canceltime=getdate() " _
               & " where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim _
               & " update m_RPartStationD_t set State=5 " _
               & " where PPartid='" & Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim & "' and Revid=" & Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        If MessageBox.Show("是否要設置成品料號: [" + Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim + "] 第[" + Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim + "]版本，为副流程？", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            Conn.ExecSql(SqlStr.ToString)
            Conn.PubConnection.Close()
            LoadDataTodgvMain(Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim)
            MessageBox.Show("设置副流程成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Conn = Nothing
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStation", "toolAbandon_Click", "sys")
        End Try

    End Sub

    Private Sub dgvMain_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMain.CellContentDoubleClick

        If Me.ToolSel.Enabled = False Then Exit Sub
        If Me.dgvMain.Rows.Count = 0 OrElse Me.dgvMain.CurrentRow Is Nothing Then Exit Sub
        If Me.dgvMain.Item(3, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) = "2" Then
            MessageBox.Show("该笔资料已作废", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        frmRstationid = Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        'frmRstationname = Me.dgvMain.Item(2, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        'frmStationtype = Me.dgvMain.Item(0, Me.dgvMain.CurrentRow.Index).Value.ToString.Trim
        Me.Close()

    End Sub



    Private Sub ToolStripbtnRules_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripbtnRules.Click
        Dim fr As FrmRPartStationRules = New FrmRPartStationRules
        fr.ShowDialog()
        FillListCheckBoxList(ChkListBox, "select id,RuleName from m_RPartStationRules_t where Ruleusey='Y' order by RuleOrderby desc", "id", "RuleName")
    End Sub

    Private Sub ToolStripSeparator1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSeparator1.Click

    End Sub
End Class