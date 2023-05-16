Imports MainFrame
Imports SysBasicClass
Imports System.Text
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports System.Drawing

Public Class FrmMaterialReg

#Region "变量定义"

    Private dics As New List(Of KeyValue)

    '变量定义
    Dim OperateFlag As EditMode '操作模式

    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum

    Private Enum RegGrid
        PartID
        PName
        Specs
        InQty
        RemainQty
        SafeQty
        GAP
    End Enum
    Private m_ApplyUserIDList As String
    Private m_TiptopStartTime As String
    Private m_PartIDNoUseList As String
#End Region

    Private Sub FrmMaterialReg_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.DesignMode = False Then

            '设定用戶權限
            Dim ERigth As New SysDataBaseClass
            ERigth.GetControlright(Me)

            m_ApplyUserIDList = GetApplyUserIDList()
            m_TiptopStartTime = GetTiptopStartTime()
            m_PartIDNoUseList = PartIDNoUseList()
            GetTop10TTSheetInfo(Where(), True)
        End If
    End Sub

    Private Function GetApplyUserIDList() As String
        Dim lsSQL As String = ""
        Dim tempApplyUserID As String = ""
        lsSQL = " SELECT ApplyUserID  FROM m_EquBuyList_t " & _
                " WHERE 1=1 AND usey='1' "

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                For Each dr As DataRow In o_dt.Rows
                    tempApplyUserID &= IIf(String.IsNullOrEmpty(tempApplyUserID), "", ",") & dr.Item(0)
                Next
            Else
                tempApplyUserID = ""
            End If
        End Using
        GetApplyUserIDList = tempApplyUserID
    End Function

    Private Function PartIDNoUseList() As String
        Dim lsSQL As String = ""
        Dim tempPartIDNoUse As String = ""
        lsSQL = " SELECT PartID  FROM m_MaterialNoUse_t " & _
                " WHERE 1=1  "

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                For Each dr As DataRow In o_dt.Rows
                    tempPartIDNoUse &= IIf(String.IsNullOrEmpty(tempPartIDNoUse), "", ",") & dr.Item(0)
                Next
            Else
                tempPartIDNoUse = ""
            End If
        End Using
        PartIDNoUseList = tempPartIDNoUse
    End Function

    Private Function GetTiptopStartTime() As String
        Dim lsSQL As String = ""
        Dim tempApplyUserID As String = ""
        lsSQL = " SELECT TiptopStartTime  FROM m_EquBuySet_t " & _
                " WHERE 1=1  "

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetTiptopStartTime = o_dt.Rows(0).Item(0)
            Else
                GetTiptopStartTime = ""
            End If
        End Using
    End Function

    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        '设置操作模式
        OperateFlag = EditMode.SEARCH
        '工具栏控件状态
        SetControlStatus(EditMode.SEARCH)
        '清除面板控件值
        ClearGroupBox()
        '面板控件可写
        ToogleGroupBox(1)
        ' txtSheetNo.Enabled = True
        'Me.txtSheetNo.ReadOnly = False
        'Me.txtSheetNo.Focus()
    End Sub

#Region "开关 GroupBox 面板控件状态"
    Private Sub ToogleGroupBox(ByVal flag As Integer)
        Select Case flag
            Case 0
                ' Me.cboStatus.Enabled = False
                'Me.cboStatus.Enabled = False
            Case 1
                'Me.cboStatus.Enabled = True
                'Me.cboStatus.Enabled = True
        End Select
    End Sub
#End Region

#Region "清除 GroupBox 面板控件值"
    Private Sub ClearGroupBox()
        Me.lblId.Text = ""
        Me.txtSafeQty.Text = ""
        ' Me.cboStatus.SelectedIndex = 0
        'Me.cboStatus.SelectedIndex = 0
    End Sub
#End Region

#Region "设置工具栏控件状态"
    Private Sub SetControlStatus(ByVal flag As EditMode)
        SetButtonEnable(False)
        Select Case UCase(flag)
            Case EditMode.ADD '新增
                toolSave.Enabled = True
                toolUndo.Enabled = True
            Case EditMode.EDIT '修改
                toolSave.Enabled = True
                toolUndo.Enabled = True
            Case EditMode.UNDO '初始化
                Me.toolNew.Enabled = IIf(DbOperateUtils.DBNullToStr(toolNew.Tag) = "YES", True, False)
                Me.toolModify.Enabled = IIf(DbOperateUtils.DBNullToStr(toolModify.Tag) = "YES", True, False)
                ' Me.tsmiCopyRecord.Enabled = IIf(DbOperateUtils.DBNullToStr(tsmiCopyRecord.Tag) = "YES", True, False)
                'toolPrint.Enabled = True
                toolExport.Enabled = True
                toolSearch.Enabled = True
                TabEquipment.Enabled = True
                ClearText()
            Case EditMode.SEARCH '搜索
                TabEquipment.Enabled = True
                toolUndo.Enabled = True
                toolSearch.Enabled = True
                toolRefresh.Enabled = True
                toolExport.Enabled = True
        End Select
    End Sub

    Private Sub ClearText()
        ' cboCategory.SelectedValue = ""
        Me.txtPartID.Text = ""
        Me.txtPName.Text = ""
        Me.txtSafeQty.Text = ""
    End Sub

    Private Sub SetButtonEnable(bFlag As Boolean)
        toolNew.Enabled = bFlag
        toolModify.Enabled = bFlag
        toolSave.Enabled = bFlag
        toolUndo.Enabled = bFlag
        toolSearch.Enabled = bFlag
        toolRefresh.Enabled = bFlag
        toolExport.Enabled = bFlag
        TabEquipment.Enabled = bFlag
    End Sub

#End Region

    Private Function Where() As String
        Dim strWhere As String = " and 1=1"
        If Not String.IsNullOrEmpty(Me.txtPartID.Text) Then
            strWhere = strWhere + " AND b.inb04 LIKE '" & Me.txtPartID.Text.Trim & "' "
        End If

        If Not String.IsNullOrEmpty(Me.txtReqUserID.Text) Then
            strWhere = strWhere + " AND  a.ina11 LIKE '" & Me.txtReqUserID.Text.Trim & "' "
        End If

        If Not String.IsNullOrEmpty(Me.txtPName.Text) Then
            strWhere = strWhere + " AND c.ima02 LIKE '%" & Me.txtPName.Text.Trim & "%' "
        End If
        Return strWhere
    End Function

    Private Sub toolRefresh_Click(sender As Object, e As EventArgs) Handles toolRefresh.Click
        Dim strWhere As String = String.Empty
        ' a.ina01 as 收货单号,  b.inb03 as 项次, b.inb04 as 料件编号,")
        ' c.ima02 as 品名, c.ima021 as 规格, b.inb16 as 入库数量")
        'If Not String.IsNullOrEmpty(Me.txtSheetNo.Text) Then
        '    strWhere = strWhere + " AND a.ina01 LIKE '" & Me.txtSheetNo.Text.Trim & "' "
        'End If

        'If Not String.IsNullOrEmpty(Me.txtItem.Text) Then
        '    strWhere = strWhere + " AND b.inb03 = '" & Me.txtItem.Text.Trim & "'"
        'End If

        'If Not String.IsNullOrEmpty(Me.txtPartID.Text) Then
        '    strWhere = strWhere + " AND b.inb04 LIKE '" & Me.txtPartID.Text.Trim & "' "
        'End If

        'If Not String.IsNullOrEmpty(Me.txtReqUserID.Text) Then
        '    strWhere = strWhere + " AND  a.ina11 LIKE '" & Me.txtReqUserID.Text.Trim & "' "
        'End If

        'If Not String.IsNullOrEmpty(Me.txtPName.Text) Then
        '    strWhere = strWhere + " AND c.ima02 LIKE '%" & Me.txtPName.Text.Trim & "%' "
        'End If

        'Call GetTTSheetInfo(Where())
        txtPartID.Text = Nothing
        txtSafeQty.Text = Nothing
        txtPName.Text = Nothing
        GetTop10TTSheetInfo(Where(), False)
    End Sub


    Private Sub GetTTSheetInfo(Optional ByVal strWhereCondition As String = "")
        Dim lsSQL As New StringBuilder, o_strSQL As New StringBuilder
        Dim OracleObject As New OracleDb("")

        Try

            lsSQL.Append(" SELECT * FROM (")
            lsSQL.Append("  SELECT INB04 as 料件编号, ima02 品名, ima021 as 规格 , sum(inb16) as Tiptop总入库数量")
            lsSQL.Append("  FROM ")
            lsSQL.Append("( ")
            lsSQL.Append(" SELECT a.ina01 as 收货单号, b.inb03 as 项次, b.inb04 , c.ima02 , c.ima021, b.inb16")
            lsSQL.Append(" FROM " & VbCommClass.VbCommClass.Factory & ".ina_file a ")
            lsSQL.Append(" INNER JOIN " & VbCommClass.VbCommClass.Factory & ".INB_FILE b ON a.ina01=b.inb01")
            lsSQL.Append(" INNER JOIN " & VbCommClass.VbCommClass.Factory & ".IMA_FILE c ON b.inb04=c.ima01")
            lsSQL.Append(" WHERE a.INABU='SEE-D' AND ((b.inb04 LIKE '195-0023%') OR (b.inb04 LIKE '195-0022%')) ")
            lsSQL.Append(" AND a.ina03>=to_date('" & m_TiptopStartTime & "','yyyy-MM-dd') ")

            If Not String.IsNullOrEmpty(strWhereCondition) Then
                lsSQL.Append(strWhereCondition)
            End If

            If Not String.IsNullOrEmpty(m_ApplyUserIDList) Then
                lsSQL.Append(" AND  a.ina11 IN ('" & m_ApplyUserIDList.Replace(",", "','") & "')")
            End If

            If Not String.IsNullOrEmpty(m_PartIDNoUseList) Then
                lsSQL.Append(" AND  b.inb04 not in ('" & m_PartIDNoUseList.Replace(",", "','") & "')")
            End If

            lsSQL.Append(")")
            lsSQL.Append(" GROUP BY inb04,ima02,ima021")
            lsSQL.Append(" )")
            lsSQL.Append(" WHERE rownum  <=1000")

            Dim o_dtTTSheetInfo As DataTable = OracleObject.ExecuteQuery(lsSQL.ToString).Tables(0)

            '料件编号, ima02 品名, ima021 as 规格 , sum(inb16) as Tiptop总入库数量
            'Modify sql, select 100 ==>1000
            o_strSQL.Append(" SELECT DISTINCT TOP 1000 PartID, PName,Spec, 0 as Tiptop总入库数量 ")
            o_strSQL.Append(" FROM  m_MaterialBaseQty_t ")
            o_strSQL.Append(" Where 1=1 and usey='1' ")

            If Not String.IsNullOrEmpty(Me.txtPartID.Text) Then
                o_strSQL.Append(" AND partid LIKE '%" & Me.txtPartID.Text.Trim & "%' ")
            End If

            If Not String.IsNullOrEmpty(Me.txtPName.Text) Then
                o_strSQL.Append(" AND PName LIKE '%" & Me.txtPName.Text.Trim & "%' ")
            End If


            Dim o_dtMESBaseQtyInfo As DataTable = DbOperateUtils.GetDataTable(o_strSQL.ToString)

            For Each csDr As DataRow In o_dtMESBaseQtyInfo.Rows
                If o_dtTTSheetInfo.Select("料件编号 = '" & csDr.Item("PartID") & "'").Length <= 0 Then
                    o_dtTTSheetInfo.Rows.Add(csDr.ItemArray)
                End If
            Next
            '如果2个表种可能有主键一样的数据，那么还需要在循环中判断一下，相同主键存在的数据不添加。


            o_dtTTSheetInfo.Columns.Add("剩余数量")  '添加列:  
            o_dtTTSheetInfo.Columns.Add("安全库存")
            o_dtTTSheetInfo.Columns.Add("GAP", Type.GetType("System.Int32"))


            '遍历:
            For Each dr As DataRow In o_dtTTSheetInfo.Rows
                '获取指定列的值
                '赋值..row.Item()可以通过列名和index获取
                '料件参数, 总入库数量,   剩余数量-安全库存 
                dr.Item("剩余数量") = GetRemainQty(dr(0), dr(3))
                dr.Item("安全库存") = GetSafeQty(dr(0))
                dr.Item("GAP") = Val(dr.Item("剩余数量")) - Val(dr.Item("安全库存"))
            Next

            Dim thisView As DataView = New DataView(o_dtTTSheetInfo)
            thisView.Sort = " GAP"
            Me.lblRecord.Text = CStr(o_dtTTSheetInfo.Rows.Count)
            Me.dgvReg.DataSource = thisView
            Me.dgvReg.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMaterialReg", "GetTTSheetInfo", "Equ")
        End Try
    End Sub

    ''' <summary>
    ''' 查询和刷新数据源
    ''' </summary>
    ''' <param name="strWhereCondition">查询条件</param>
    ''' <param name="IsFormLoad">是否是窗体初始加载</param>
    ''' <remarks></remarks>
    Private Sub GetTop10TTSheetInfo(ByVal strWhereCondition As String, ByVal IsFormLoad As Boolean)
        Dim lsSQL As New StringBuilder, o_strSQL As New StringBuilder
        Dim OracleObject As New OracleDb("")

        Try
            Dim num As Integer = IIf(IsFormLoad, 10, 1000)
            lsSQL.Append(" SELECT * FROM (")
            lsSQL.Append("  SELECT INB04 , ima02 , ima021  , sum(inb16) as inb16")
            lsSQL.Append(",0 as ResidualQuantity,0 as SafetyStock,0 AS GAP  FROM ")
            lsSQL.Append("( ")
            lsSQL.Append(" SELECT a.ina01 as 收货单号, b.inb03 as 项次, b.inb04 , c.ima02 , c.ima021, b.inb16")
            lsSQL.Append(" FROM " & VbCommClass.VbCommClass.Factory & ".ina_file a ")
            lsSQL.Append(" INNER JOIN " & VbCommClass.VbCommClass.Factory & ".INB_FILE b ON a.ina01=b.inb01")
            lsSQL.Append(" INNER JOIN " & VbCommClass.VbCommClass.Factory & ".IMA_FILE c ON b.inb04=c.ima01")
            lsSQL.Append(" WHERE a.INABU='SEE-D' AND ((b.inb04 LIKE '195-0023%') OR (b.inb04 LIKE '195-0022%')) ")
            lsSQL.Append(" AND a.ina03>=to_date('" & m_TiptopStartTime & "','yyyy-MM-dd') ")

            If Not String.IsNullOrEmpty(strWhereCondition) Then
                lsSQL.Append(strWhereCondition)
            End If

            If Not String.IsNullOrEmpty(m_ApplyUserIDList) Then
                lsSQL.Append(" AND  a.ina11 IN ('" & m_ApplyUserIDList.Replace(",", "','") & "')")
            End If

            If Not String.IsNullOrEmpty(m_PartIDNoUseList) Then
                lsSQL.Append(" AND  b.inb04 not in ('" & m_PartIDNoUseList.Replace(",", "','") & "')")
            End If

            lsSQL.Append(")")
            lsSQL.Append(" GROUP BY inb04,ima02,ima021")
            lsSQL.Append(" )")
            lsSQL.Append(" WHERE rownum  <=" & num & "")

            Dim o_dtTTSheetInfo As DataTable = OracleObject.ExecuteQuery(lsSQL.ToString).Tables(0)

            '料件编号, ima02 品名, ima021 as 规格 , sum(inb16) as Tiptop总入库数量
            'Modify sql, select 100 ==>1000
            o_strSQL.Append(" SELECT DISTINCT TOP " & num & " PartID, PName,Spec, 0 as Tiptop总入库数量 ")
            o_strSQL.Append(" FROM  m_MaterialBaseQty_t ")
            o_strSQL.Append(" Where 1=1 and usey='1' ")

            If Not String.IsNullOrEmpty(Me.txtPartID.Text) Then
                o_strSQL.Append(" AND partid LIKE '%" & Me.txtPartID.Text.Trim & "%' ")
            End If

            If Not String.IsNullOrEmpty(Me.txtPName.Text) Then
                o_strSQL.Append(" AND PName LIKE '%" & Me.txtPName.Text.Trim & "%' ")
            End If


            Dim o_dtMESBaseQtyInfo As DataTable = DbOperateUtils.GetDataTable(o_strSQL.ToString)

            For Each csDr As DataRow In o_dtMESBaseQtyInfo.Rows
                If o_dtTTSheetInfo.Select("INB04 = '" & csDr.Item("PartID") & "'").Length <= 0 Then
                    o_dtTTSheetInfo.Rows.Add(csDr.ItemArray)
                End If
            Next
            '如果2个表种可能有主键一样的数据，那么还需要在循环中判断一下，相同主键存在的数据不添加。


            'o_dtTTSheetInfo.Columns.Add("剩余数量")  '添加列:  
            'o_dtTTSheetInfo.Columns.Add("安全库存")
            'o_dtTTSheetInfo.Columns.Add("GAP", Type.GetType("System.Int32"))


            '遍历:
            For Each dr As DataRow In o_dtTTSheetInfo.Rows
                '获取指定列的值
                '赋值..row.Item()可以通过列名和index获取
                '料件参数, 总入库数量,   剩余数量-安全库存 
                'dr.Item("剩余数量") = GetRemainQty(dr(0), dr(3))
                'dr.Item("安全库存") = GetSafeQty(dr(0))
                'dr.Item("GAP") = Val(dr.Item("剩余数量")) - Val(dr.Item("安全库存"))
                dr.Item("ResidualQuantity") = GetRemainQty(dr(0), dr(3))
                dr.Item("SafetyStock") = GetSafeQty(dr(0))
                dr.Item("GAP") = Val(dr.Item("ResidualQuantity")) - Val(dr.Item("SafetyStock"))
            Next
            Me.dgvReg.AutoGenerateColumns = False
            Dim thisView As DataView = New DataView(o_dtTTSheetInfo)
            thisView.Sort = " GAP"
            Me.lblRecord.Text = CStr(thisView.Count)
            Me.dgvReg.DataSource = thisView
            Me.dgvReg.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            SetSelectAll(dgvReg)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMaterialReg", "GetTTSheetInfo", "Equ")
        End Try
    End Sub

    Private Sub SetSelectAll(dgGrid As DataGridView)
        Dim rect As Rectangle = dgGrid.GetCellDisplayRectangle(0, -1, True)
        rect.X = rect.Location.X + rect.Width / 4 + 15
        rect.Y = rect.Location.Y + (rect.Height / 2 - 9)
        Dim cbHeader As CheckBox = New CheckBox()
        cbHeader.Name = "checkboxHeader"
        cbHeader.Size = New Size(18, 18)
        cbHeader.Location = rect.Location
        cbHeader.Checked = False
        AddHandler cbHeader.CheckedChanged, AddressOf cbHeader_CheckedChanged
        dgGrid.Controls.Add(cbHeader)
    End Sub

    Private Sub cbHeader_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim chk As CheckBox = DirectCast(sender, CheckBox)
        Dim gvr As DataGridView = DirectCast(chk.Parent, DataGridView)

        SetCheckBox(chk, gvr)
    End Sub

    Private Sub SetCheckBox(chk As CheckBox, gvr As DataGridView)
        If chk.Checked Then
            For Each row As DataGridViewRow In gvr.Rows
                row.Cells(0).Value = True
            Next
        Else
            For Each row As DataGridViewRow In gvr.Rows
                row.Cells(0).Value = False
            Next
        End If
    End Sub

    Private Function GetSafeQty(ByVal strPartID As String) As String
        Dim lsSQL As String = String.Empty

        'Only care PartID 20170321
        lsSQL = " SELECT SafeQty  " & _
                " FROM m_MaterialBaseQty_t  " & _
                " WHERE PartID = '" & strPartID & "' AND USEY='1' "

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                If Val(o_dt.Rows(0).Item(0)) = 0 Then
                    GetSafeQty = ""
                Else
                    GetSafeQty = Val(o_dt.Rows(0).Item(0))
                End If
            Else
                GetSafeQty = ""
            End If
        End Using

    End Function

    ''' <summary>
    '''  剩余数量 = TT总购入数 - 总领用数量 +  期初数
    ''' </summary>
    ''' <param name="strPartID"></param>
    ''' <param name="strTTInQty"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetRemainQty(ByVal strPartID As String, ByVal strTTInQty As String) As Double
        Dim lsSQL As String = String.Empty

        'Only care PartID 20170321
        lsSQL = " SELECT ISNULL(SUM(cast(RegQty as  numeric )),0) as UseQty  " & _
              " FROM m_MaterialRegLog_t  " & _
              " WHERE PartID = '" & strPartID & "'" & _
              " AND Status='1'"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetRemainQty = Val(strTTInQty) - Val(o_dt.Rows(0).Item(0)) + GetInitialQty(strPartID)
            Else
                GetRemainQty = Val(strTTInQty) - 0 + GetInitialQty(strPartID)
            End If
        End Using
    End Function

    Private Function GetInitialQty(ByVal strPartID As String) As Double
        Dim lsSQL As String = String.Empty

        'Only care PartID 20170321
        lsSQL = " SELECT ISNULL(SUM(cast(Qty as  numeric )),0) as UseQty  " & _
              " FROM m_MaterialBaseQty_t  " & _
              " WHERE PartID = '" & strPartID & "'"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetInitialQty = o_dt.Rows(0).Item(0)
            Else
                GetInitialQty = 0
            End If
        End Using

    End Function


    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolUndo_Click(sender As Object, e As EventArgs) Handles toolUndo.Click
        '设置操作模式
        OperateFlag = EditMode.UNDO
        '工具栏控件状态
        SetControlStatus(EditMode.UNDO)
        '清除面板控件值
        ClearGroupBox()
        '面板控件只读
        ToogleGroupBox(0)
    End Sub

    Private Sub toolRegrecord_Click(sender As Object, e As EventArgs) Handles toolRegRecord.Click
        If Me.dgvReg.CurrentRow Is Nothing Then Exit Sub
        Dim frmReg As New FrmReg
        frmReg.txtPartID.Text = Me.dgvReg.CurrentRow.Cells("ColINB04").Value
        frmReg.txtPName.Text = Me.dgvReg.CurrentRow.Cells("Colima02").Value
        frmReg.m_strRemainQty = Me.dgvReg.CurrentRow.Cells("ColResidualQuantity").Value.ToString()
        frmReg.Owner = Me
        frmReg.ShowDialog()
    End Sub

    Private Sub ToolLook_Click(sender As Object, e As EventArgs) Handles ToolLook.Click
        Dim frmlog As New FrmRegLog
        ' frmlog.StartPosition = FormStartPosition.CenterScreen
        frmlog.Owner = Me
        frmlog.ShowDialog()
    End Sub

    Private Sub dgvReg_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs)
        Try
            If e.RowIndex = -1 Then Exit Sub


            If Me.dgvReg.RowCount < 1 Then Exit Sub
            '新增、查询 模式下不可操作
            'If OperateFlag = EditMode.ADD Or OperateFlag = EditMode.EDIT Or OperateFlag = EditMode.SEARCH Then
            '    Exit Sub
            'End If

            Me.txtPartID.Text = Me.dgvReg.Item(RegGrid.PartID, Me.dgvReg.CurrentRow.Index).Value.ToString.Trim()
            Me.txtSafeQty.Text = Me.dgvReg.Item(RegGrid.SafeQty, Me.dgvReg.CurrentRow.Index).Value.ToString.Trim()

            LoadRegDetail(e.RowIndex)

            'mark by cq20170508
            ' LoadBaseQtyDetail(e.RowIndex)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSample", "dgvSample_CellClick", "Equ")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub


    Private Sub LoadRegDetail(curRowIndex As Integer)
        Dim strSQL As String = ""
        Dim o_strPartID As String = ""
        Dim strWhere As String = String.Empty

        Try
            If dgvReg.Rows.Count = 0 Then
                Exit Sub
            End If

            strSQL =
                  " SELECT PartID 料件编号, (RegUserID+'/'+ b.UserName) 领用人, a.Intime 领用时间 , RegQty 领用数量, " & _
                  " (CASE  a.Status  WHEN '0' then N'待确认' when '1' then N'已确认' ELSE N'待确认' end) as 状态 " & _
                  " FROM m_MaterialRegLog_t a " & _
                  " LEFT JOIN m_Users_t b ON a.RegUserID = b.UserID " & _
                  " WHERE 1=1 "

            '0.编号, 1.
            If IsNothing(dgvReg.Rows(curRowIndex).Cells(RegGrid.PartID).Value) OrElse IsDBNull(dgvReg.Rows(curRowIndex).Cells(RegGrid.PartID).Value) Then
                Exit Sub
            Else
                o_strPartID = dgvReg.Rows(curRowIndex).Cells(RegGrid.PartID).Value
            End If

            strWhere = String.Format(" AND a.PartID = '{0}'", o_strPartID)
            Dim strOrder As String = " ORDER BY a.Intime "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder)

            dgvRegLog.DataSource = dt

            dgvRegLog.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMaterialReg", "LoadRegDetail", "Equ")
        End Try
    End Sub

    Private Sub LoadBaseQtyDetail(curRowIndex As Integer)
        Dim strSQL As String = ""
        Dim o_strPartID As String = ""
        Dim strWhere As String = String.Empty

        Try
            If dgvReg.Rows.Count = 0 Then
                Exit Sub
            End If

            strSQL =
                  " SELECT PartID 料件编号, (RegUserID+'/'+ b.UserName) 领用人, a.Intime 领用时间 , RegQty 领用数量 " & _
                  " FROM m_MaterialBaseQty_t a " & _
                  " LEFT JOIN m_Users_t b ON a.RegUserID = b.UserID " & _
                  " WHERE 1=1 "

            '0.编号, 1.
            If IsNothing(dgvReg.Rows(curRowIndex).Cells(RegGrid.PartID).Value) OrElse IsDBNull(dgvReg.Rows(curRowIndex).Cells(RegGrid.PartID).Value) Then
                Exit Sub
            Else
                o_strPartID = dgvReg.Rows(curRowIndex).Cells(RegGrid.PartID).Value
            End If

            strWhere = String.Format(" AND a.PartID = '{0}'", o_strPartID)
            Dim strOrder As String = " ORDER BY a.Intime "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder)

            dgvBaseQty.DataSource = dt

            dgvBaseQty.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            'SysMessageClass.WriteErrLog(ex, "FrmMaterialReg", "LoadBaseQtyDetail", "Equ")
        End Try
    End Sub

    Private Sub toolBuyList_Click(sender As Object, e As EventArgs) Handles toolBuyList.Click
        Dim frmlog As New FrmBuyList
        frmlog.Owner = Me
        frmlog.ShowDialog()
    End Sub

    Private Sub ToolBaseQty_Click(sender As Object, e As EventArgs) Handles ToolBaseQty.Click
        Dim frmlog As New FrmMaterialBaseQty

        frmlog.Owner = Me
        frmlog.ShowDialog()
    End Sub

    Private Sub dgvReg_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)

        'If e.RowIndex = -1 Then Exit Sub

        'For Each dr As DataGridViewRow In Me.dgvReg.Rows
        '    If Val(dr.Cells(RegGrid.GAP).Value) <= 0 Then
        '        dr.DefaultCellStyle.BackColor = Drawing.Color.Red
        '    End If
        'Next
    End Sub

    Private Sub toolModify_Click(sender As Object, e As EventArgs) Handles toolModify.Click
        '设置操作模式
        OperateFlag = EditMode.EDIT
        '工具栏控件状态
        SetControlStatus(EditMode.EDIT)

        Me.txtSafeQty.Enabled = True

    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            Dim strSQL As String = String.Empty
            Dim insertSql As New System.Text.StringBuilder
            Dim strSafeQty As String = Me.txtSafeQty.Text.Trim

            If OperateFlag = EditMode.ADD Then
                'strSQL = "select 1 from m_EquipmentCategory_t where NAME = N'{0}'"
                'strSQL = String.Format(strSQL, categoryName)

                'Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

                'If dt.Rows.Count > 0 Then
                '    MessageUtils.ShowError("类别名称" + categoryName + "已存在!")
                '    Exit Sub
                'End If
            ElseIf OperateFlag = EditMode.EDIT Then
                strSQL = "UPDATE [m_MaterialBaseQty_t] "
                insertSql.Append(strSQL)

                insertSql.AppendFormat("SET SafeQty = N'{0}' ", Val(strSafeQty))
                insertSql.AppendFormat(",UserID = N'{0}'", VbCommClass.VbCommClass.UseId)
                insertSql.AppendFormat(",InTime = getdate()")
                insertSql.AppendFormat(" WHERE PartID = '{0}'", Me.txtPartID.Text.Trim)

                DbOperateUtils.ExecSQL(insertSql.ToString)
            End If

            '设置操作模式
            OperateFlag = EditMode.UNDO
            '工具栏控件状态
            SetControlStatus(EditMode.UNDO)

            GetTTSheetInfo(" AND b.inb04 LIKE '" & Me.txtPartID.Text.Trim & "'")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEqupmentCategory", "toolRefresh_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub ToolCheck_Click(sender As Object, e As EventArgs)

        Dim lsSQL As New StringBuilder
        Dim strPartID As String = ""
        If Me.dgvRegLog.CurrentRow Is Nothing Then Exit Sub

        strPartID = Me.dgvRegLog.CurrentRow.Cells(0).Value

        lsSQL.Append(" Update  m_MaterialRegLog_t Set Status='1'  WHERE PartID='" & strPartID & "' ")

        DbOperateUtils.ExecSQL(lsSQL.ToString)

        MessageUtils.ShowInformation("审核成功!")
    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        Dim lsSQL As New StringBuilder, o_strPartID As String = ""
        If Me.dgvReg.Rows.Count = 0 OrElse Me.dgvReg.CurrentRow Is Nothing Then Exit Sub

        o_strPartID = dgvReg.CurrentRow.Cells(RegGrid.PartID).Value
        Try


            lsSQL.Append(" IF ISNULL((SELECT TOP 1 1 FROM  m_MaterialNoUse_t where partid ='" & o_strPartID & "'),0)=0  ")
            lsSQL.Append(" Begin")
            lsSQL.Append(" Insert into m_MaterialNoUse_t(PartID,UserID,Intime) Values(")
            lsSQL.Append(" '" & o_strPartID & "', '" & VbCommClass.VbCommClass.UseId & "',getdate())")
            lsSQL.Append(" End")

            lsSQL.Append(" IF ISNULL((SELECT TOP 1 1 FROM  m_MaterialBaseQty_t where partid ='" & o_strPartID & "'),0)=1  ")
            lsSQL.Append(" Begin")
            lsSQL.Append("  Update m_MaterialBaseQty_t Set UseY='0'")
            lsSQL.Append("  where partid ='" & o_strPartID & "'")
            lsSQL.Append(" End")

            If MessageUtils.ShowConfirm("你确认作废料号:[" & o_strPartID & "] 吗?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                DbOperateUtils.ExecSQL(lsSQL.ToString)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMaterialReg", "toolAbandon_Click", "Equ")
        End Try
    End Sub

    ''' <summary>
    ''' 查找所有的料的记录，速度会比较慢
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Call GetTTSheetInfo()
    End Sub

    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        Dim dt As DataTable
        dt = GetDataTable(dgvReg.DataSource)   'dgvReg.DataSource
        ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)

        'ExcelUtils.LoadDataToExcel(dgvReg, Me.Text)
    End Sub

    ''' <summary>
    ''' 转换DataView成DataTable
    ''' </summary>
    ''' <param name="obDataView"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataTable(ByVal obDataView As DataView) As DataTable
        If IsNothing(obDataView) Then
            Throw New ArgumentNullException("DataView", "Invalid DataView Object specified")
        End If

        Dim obNewDt As DataTable = obDataView.Table.Clone()
        Dim idx As Integer = 0
        Dim strColNames() As String = New String(obNewDt.Columns.Count) {}
        Dim col As DataColumn
        For Each col In obNewDt.Columns
            strColNames(idx) = col.ColumnName
            idx = idx + 1
        Next

        Dim viewEnumerator As IEnumerator = obDataView.GetEnumerator()
        While viewEnumerator.MoveNext()
            Dim drv As DataRowView = CType(viewEnumerator.Current, DataRowView)
            Dim dr As DataRow = obNewDt.NewRow()
            Try
                Dim strName As String
                For Each strName In strColNames
                    dr(strName) = drv(strName)
                Next
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            obNewDt.Rows.Add(dr)
        End While
        Return obNewDt
    End Function

    'Public Function GetDgvToTable(ByVal dgv As DataGridView) As DataTable
    '    Dim dt As DataTable = New DataTable()
    '    Dim count As Integer
    '    For count = 0 To dgv.Columns.Count - 1 Step count + 1
    '        Dim dc As DataColumn = New DataColumn(dgv.Columns(count).Name.ToString())
    '        dt.Columns.Add(dc)
    '    Next
    '    Dim RowCount As Integer
    '    For RowCount = 0 To dgv.Rows.Count - 1 Step RowCount + 1
    '        Dim dr As DataRow = dt.NewRow()
    '        Dim countsub As Integer
    '        For countsub = 0 To dgv.Columns.Count - 1 Step countsub + 1
    '            dr(countsub) = Convert.ToString(dgv.Rows(count).Cells(countsub).Value)
    '        Next
    '        dt.Rows.Add(dr)
    '    Next
    '    Return dt
    'End Function

    'add by 马跃平 2018-04-10
    Private Sub dgvReg_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvReg.RowPostPaint
        If e.RowIndex > -1 Then
            Dim objValue As Object = dgvReg.Rows(e.RowIndex).Cells("ColGAP").Value
            If Not objValue = Nothing Then
                If Val(objValue) <= 0 Then
                    dgvReg.Rows(e.RowIndex).DefaultCellStyle.BackColor = Drawing.Color.Red
                End If
            End If

        End If

    End Sub

    Private Sub dgvReg_SelectionChanged(sender As Object, e As EventArgs) Handles dgvReg.SelectionChanged
        'Me.txtPartID.Text = Me.dgvReg.Item("ColINB04", Me.dgvReg.CurrentRow.Index).Value.ToString.Trim()
        'Me.txtSafeQty.Text = Me.dgvReg.Item("ColSafetyStock", Me.dgvReg.CurrentRow.Index).Value.ToString.Trim()
        Dim dgvr As DataGridViewRow = dgvReg.CurrentRow
        Me.txtPartID.Text = dgvr.Cells("ColINB04").Value.ToString()
        Me.txtSafeQty.Text = dgvr.Cells("ColSafetyStock").Value.ToString()
        LoadRegDetail(dgvReg.CurrentRow.Index)
    End Sub

#Region "删除"
    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        Dim ay As ArrayList = New ArrayList
        For Each dgr As DataGridViewRow In dgvReg.Rows
            Dim objValue As Object = dgr.Cells(0).Value
            If Not objValue = Nothing Then
                If objValue.ToString() = "True" Then
                    ay.Add(dgr.Cells("ColINB04").Value)
                End If
            End If
        Next
        If ay.Count = 0 Then
            MessageUtils.ShowWarning("请勾选要删除的值")
            Exit Sub
        End If
        Dim dr As DialogResult = MessageBox.Show("你确定要删除选择的数据吗?", "友情提示", MessageBoxButtons.OKCancel)
        If dr = DialogResult.OK Then
            For Each objValue As Object In ay
                DbOperateUtils.ExecSQL("delete m_MaterialBaseQty_t where partid='" & objValue.ToString & "'")
                DbOperateUtils.ExecSQL("delete m_MaterialRegLog_t where partid='" & objValue.ToString & "'")
            Next
        End If
        MessageUtils.ShowInformation("删除成功")
        txtPartID.Text = Nothing
        txtSafeQty.Text = Nothing
        GetTop10TTSheetInfo(Where(), True)
    End Sub
#End Region

End Class