Imports MainFrame
Imports System.Xml
Imports MainFrame.SysDataHandle
Imports System.Text
Imports MainFrame.SysCheckData
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmReportAdm
    Dim Conn As New SysDataHandle.SysDataBaseClass
    Dim SysClass As String = "0"
    Dim StartApp As String = "MesSystem.exe"
    Dim AppName As String = "MES"
    Dim SqlserverName As String = "" '"data source=172.17.32.12;initial catalog=MESDB;uid=sa;pwd=050033068027066029014023030"
    Dim ServerIP As String

    Public opFlag As Integer = 0
    Public CuurIndexMstr As Integer = 0

    Public CuurDetRowIndex As Integer = 0
    Public CuurDetColIndex As Integer = 0

    Private newQryDsValue As DataSet
    Public Property NewQryDs() As DataSet
        Get
            Return newQryDsValue
        End Get
        Set(ByVal value As DataSet)
            newQryDsValue = value
        End Set
    End Property
    Private Sub FrmReportAdm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadTreeData()
    End Sub
   
    Private Sub loadTreeData()
        AdvTree1.Nodes.Clear()
        Dim dt As DataTable = Conn.GetDataTable("select a.Tkey,Tparent,Ttext,Enname,TreeTag,SQLSCRIPT,SqlUsey from m_Logtree_t a left join m_Logtree_Det_t b on a.Tkey=b.Tkey order by a.OrderBy")
        Bind_Tv(dt, AdvTree1.Nodes, "m09_", "Tkey", "Tparent", "Ttext", True, False)
        cmbTparent.Nodes.Clear()
        Bind_Tv(dt, cmbTparent.AdvTree.Nodes, "m09_", "Tkey", "Tparent", "Ttext", True, False)
    End Sub
    '/ <summary>
    '/ 绑定TreeView（利用TreeNodeCollection）
    '/ </summary>
    '/ <param name="tnc">TreeNodeCollection（TreeView的节点集合）</param>
    '/ <param name="pid_val">父id的值</param>
    '/ <param name="id">数据库 id 字段名</param>
    '/ <param name="pid">数据库 父id 字段名</param>
    '/ <param name="text">数据库 文本 字段值</param>
    Private Sub Bind_Tv(ByVal dt As DataTable, ByVal tnc As DevComponents.AdvTree.NodeCollection, ByVal pid_val As String, ByVal id As String, ByVal pid As String, ByVal text As String, ByVal isfirst As Boolean, ByVal IsMultiple As Boolean)
        Dim dv As DataView = New DataView(dt) '将DataTable存到DataView中，以便于筛选数据
        Dim tn As DevComponents.AdvTree.Node '建立TreeView的节点（TreeNode），以便将取出的数据添加到节点中 As TreeNode
        '以下为三元运算符，如果父id为空，则为构建“父id字段 is null”的查询条件，否则构建“父id字段=父id字段值”的查询条件
        Dim filter As String = "" ' String.IsNullOrEmpty(pid_val) ? pid + " is null" : String.Format(pid + "='{0}'",pid_val) 
        If isfirst Then
            If String.IsNullOrEmpty(pid_val) Then
                filter = "Tkey is null or Tkey =''"
            Else
                filter = String.Format("Tkey='{0}'", pid_val)
            End If
        Else
            If String.IsNullOrEmpty(pid_val) Then
                filter = pid + " is null or " + pid + " =''"
            Else
                filter = String.Format(pid + "='{0}'", pid_val)
            End If
        End If

        dv.RowFilter = filter '利用DataView将数据进行筛选，选出相同 父id值 的数据
        Dim drv As DataRowView
        For Each drv In dv
            tn = New DevComponents.AdvTree.Node() '建立一个新节点（学名叫：一个实例）
            tn.Name = drv(id).ToString() '节点的Value值，一般为数据库的id值
            tn.Text = drv(text).ToString() '节点的Text，节点的文本显示         
            If IsMultiple Then
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv(id).ToString()))
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv(pid).ToString()))
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv("Enname").ToString()))
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv("TreeTag").ToString()))
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv("SQLSCRIPT").ToString()))
                tn.Cells.Add(New DevComponents.AdvTree.Cell(drv("SqlUsey").ToString()))
            End If
            tn.Expanded = True

            tnc.Add(tn) '将该节点加入到TreeNodeCollection（节点集合）中
            Bind_Tv(dt, tn.Nodes, tn.Name, id, pid, text, False, IsMultiple) '递归（反复调用这个方法，直到把数据取完为止）
        Next
    End Sub
    Private Sub chkSqlUsey_CheckedChanged(sender As Object, e As EventArgs) Handles chkSqlUsey.CheckedChanged
        If chkSqlUsey.Checked Then
            'txtSQLSCRIPT.Text = ""
            txtSQLSCRIPT.Enabled = True
            txtSQLSCRIPT.Focus()
        Else
            'txtSQLSCRIPT.Text = "例如：select * from m_Carton_t where Intime between @intime1 and @intime2 and Moid=@Moid and Teamid=@Teamid and Cartonid=@Cartonid"
            txtSQLSCRIPT.Enabled = False
        End If
    End Sub
    Private Sub chkDetUsey_CheckedChanged(sender As Object, e As EventArgs) Handles chkDetUsey.CheckedChanged
        If chkDetUsey.Checked Then
            'txtDetScript.Text = ""
            txtDetScript.Enabled = True
            txtDetScript.Focus()
        Else
            'txtDetScript.Text = "范例：select * from m_Cartonsn_t  where Cartonid='{0}'"
            txtDetScript.Enabled = False
        End If
    End Sub

    Private Sub chkChartUsey_CheckedChanged(sender As Object, e As EventArgs) Handles chkChartUsey.CheckedChanged
        If chkChartUsey.Checked Then
            'txtChartScript.Text = ""
            txtChartScript.Enabled = True
            'txtChartTitle.Text = ""
            txtChartTitle.Enabled = True
            'txtChartType.SelectedIndex = -1
            txtChartType.Enabled = True
            txtChartScript.Focus()
        Else
            'txtChartScript.Text = "范例：select Xcol,Tcol from tableName "
            txtChartScript.Enabled = False
            txtChartTitle.Enabled = False
            txtChartType.Enabled = False
        End If
    End Sub


    Private Sub AdvTree1_Click(sender As Object, e As EventArgs) Handles AdvTree1.Click
        If opFlag = 1 Then
            Exit Sub
        End If
        If Me.AdvTree1.Nodes.Count = 0 Or AdvTree1.SelectedNode Is Nothing Or AdvTree1.SelectedIndex = 0 Then
            Exit Sub
        End If
        CuurIndexMstr = AdvTree1.SelectedIndex
        Dim tkey As String = AdvTree1.SelectedNode.Name
        Dim dt As DataTable = GetlogtreeDt(tkey)
        Me.txtTkey.Text = tkey
        Me.txtTtext.Text = dt.Rows(0)("Ttext").ToString
        Dim Tparent As String = dt.Rows(0)("Tparent").ToString
        cmbTparent.SelectedNode = cmbTparent.Nodes.Find(Tparent, True)(0)
        Me.txtEnname.Text = dt.Rows(0)("Enname").ToString
        Me.txtTreeTag.Text = dt.Rows(0)("TreeTag").ToString
        If dt.Rows(0)("SqlUsey").ToString = "Y" Then
            Me.chkSqlUsey.Checked = True
        Else
            Me.chkSqlUsey.Checked = False
        End If
        Me.txtSQLSCRIPT.Text = dt.Rows(0)("SqlScript").ToString
        If dt.Rows(0)("DetUsey").ToString = "Y" Then
            Me.chkDetUsey.Checked = True
        Else
            Me.chkDetUsey.Checked = False
        End If
        Me.txtDetScript.Text = dt.Rows(0)("DetScript").ToString
        If dt.Rows(0)("ChartUsey").ToString = "Y" Then
            Me.chkChartUsey.Checked = True
        Else
            Me.chkChartUsey.Checked = False
        End If
        Me.txtChartScript.Text = dt.Rows(0)("ChartScript").ToString
        Me.txtChartTitle.Text = dt.Rows(0)("ChartTitle").ToString
        Me.txtChartType.Text = dt.Rows(0)("ChartType").ToString

        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False

        txttkey1.Text = txtTkey.Text
        txtTtext1.Text = txtTtext.Text
        txtSQLSCRIPT1.Text = txtSQLSCRIPT.Text


        txttkey1.ReadOnly = True
        txtTtext1.ReadOnly = True
        txtSQLSCRIPT1.ReadOnly = True

        Dim dtdet As DataTable = GetQryDetDt(tkey)
        DataGridViewX1.DataSource = dtdet
        If dtdet.Rows.Count > 0 Then
            DataGridViewX1.CurrentCell = DataGridViewX1.Rows(0).Cells(0)
            DataGridViewX1_CellClick(Nothing, Nothing)
        End If
        GroupBox5.Enabled = False


    End Sub
    Private Function GetlogtreeDt(ByVal tkey As String) As DataTable
        Dim sql As String = String.Format("select a.Tkey,a.Tparent,a.Ttext,a.Enname,a.TreeTag,b.SqlScript,b.SqlUsey,DetScript,DetUsey,ChartScript,ChartTitle,ChartType,ChartUsey from m_Logtree_t a left join m_Logtree_Det_t b on a.Tkey=b.Tkey where a.Tkey='{0}'", tkey)
        Return Conn.GetDataTable(sql.ToString)
    End Function
    Private Function GetQryDetDt(ByVal tkey As String) As DataTable
        Dim sql As String = String.Format("select Tkey,QRYSEQ,PARA_NAME,PARA_CHG_NAME,PARA_TYPE,PARA_LENGTH,DEFAULT_VALUE,TABLENAME,ISNUL,CONDITIONSQL,STAMPUSERNAME,STAMPDATETIME from m_Logtree_Qry_t where Tkey='{0}'  order by QRYSEQ ", tkey)
        Return Conn.GetDataTable(sql.ToString)
    End Function

    

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        Select Case Me.TabControl1.SelectedTabIndex
            Case 0   '菜单主表
                opFlag = 1
                SetStatus(opFlag)
                ClearLogtreeData()
            Case 1   '编辑报表查询主表
                opFlag = 4
                SetStatus(opFlag)
                ClearQryDetData()
                'GroupBox3.Enabled = True
        End Select
        CuurIndexMstr = 0
    End Sub
    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click

        Select Case Me.TabControl1.SelectedTabIndex
            Case 0   '编辑菜单数据
                EditLogtreeData()

            Case 1   '编辑报表查询
                EditQryDetData()
                'GroupBox3.Enabled = True
        End Select
    End Sub
    Private Sub ToolSave_Click(sender As Object, e As EventArgs) Handles ToolSave.Click

        Select Case TabControl1.SelectedTabIndex
            Case 0   '菜单主表
                SaveLogtreeData()
            Case 1   '编辑报表查询
                SaveQryDetData()
        End Select
    End Sub
    Private Sub SaveLogtreeData()
        Try
            If txtTtext.Text = "" Then
                MessageBox.Show("菜单名称不能为空")
                txtTtext.Focus()
                Exit Sub
            End If

            Dim sqlstr As New StringBuilder
            Dim parameters() As SqlParameter = {New SqlParameter("@SQLSCRIPT", SqlDbType.NText), New SqlParameter("@DetScript", SqlDbType.NText), New SqlParameter("@ChartScript", SqlDbType.NText), New SqlParameter("@ChartTitle", SqlDbType.NVarChar, 100), New SqlParameter("@ChartType", SqlDbType.VarChar, 1)}

            parameters(0).Value = txtSQLSCRIPT.Text.Trim
            parameters(1).Value = txtDetScript.Text.Trim
            parameters(2).Value = txtChartScript.Text.Trim
            parameters(3).Value = txtChartTitle.Text.Trim
            parameters(4).Value = txtChartType.Text.Trim.Split("-")(0)

            If opFlag = 1 Then
                sqlstr.Append(" declare @keyid varchar(20) select @keyid=dbo.f_IncIdent(isnull(max(left(Tkey,5)),'m0900'),1) from m_Logtree_t where  left(Tkey,4)='m090'")
                sqlstr.Append(" insert m_Logtree_t(Treeid,Tkey,Tparent,Ttext,Enname,TreeTag,Rightid,Formid,ButtonID,Timage,Tsimage,TADimage,TADsimage,TADUsey,listy,Usey,Remark) values(	@keyid	,	@keyid+'_'	,	'" & cmbTparent.SelectedNode.Name & "'	,	N'" & txtTtext.Text.Trim & "'	,	N'" & txtEnname.Text.Trim & "'	,	'" & txtTreeTag.Text.Trim & "'	,	'mes00'	,	'apm09005'	,	NULL	,	1	,	1	,	1	,	1	,	'N'	,	'Y'	,	NULL	,	NULL	)")
                If chkSqlUsey.Checked Then
                    sqlstr.Append(" insert m_Logtree_Det_t(Tkey,SqlScript,SqlUsey,DetScript,DetUsey,ChartScript,ChartTitle,ChartType,ChartUsey) ")
                    sqlstr.Append(" values(@keyid+'_',@SQLSCRIPT,'" & IIf(chkSqlUsey.Checked, "Y", "N") & "',@DetScript,'" & IIf(chkDetUsey.Checked, "Y", "N") & "',@ChartScript,@ChartTitle,@ChartType,'" & IIf(chkChartUsey.Checked, "Y", "N") & "') ")

                    sqlstr.Append(" declare @Tparent varchar(30)")
                    sqlstr.Append(" declare @ReportUsey varchar(1)='Y'")
                    sqlstr.Append(" update m_Logtree_t set ReportUsey=@ReportUsey where Tkey=@keyid+'_'")
                    sqlstr.Append(" select @Tparent=Tparent from m_Logtree_t where Tkey=@keyid+'_'")
                    sqlstr.Append(" while @Tparent<>'m0_'  ")
                    sqlstr.Append(" begin")
                    sqlstr.Append(" if @ReportUsey='N'")
                    sqlstr.Append(" begin")
                    sqlstr.Append("  if not exists(select * from m_Logtree_t where ReportUsey='Y' and Tparent=@Tparent)")
                    sqlstr.Append("  begin")
                    sqlstr.Append("  update m_Logtree_t set ReportUsey='N' where Tkey=@Tparent	")
                    sqlstr.Append("  end")
                    sqlstr.Append("  select @Tparent=Tparent from m_Logtree_t where Tkey=@Tparent ")
                    sqlstr.Append(" end")
                    sqlstr.Append(" else")
                    sqlstr.Append("  begin")
                    sqlstr.Append("   update m_Logtree_t set ReportUsey='Y' where Tkey=@Tparent")
                    sqlstr.Append("   select @Tparent=Tparent from m_Logtree_t where Tkey=@Tparent  ")
                    sqlstr.Append("  end")
                    sqlstr.Append(" end")
                End If


                sqlstr.Append(" select  @keyid+'_' as Tkey ")
            End If
            If opFlag = 2 Then
                If txtTkey.Text.Trim.ToLower <> cmbTparent.SelectedNode.Name.Trim.ToLower Then
                    sqlstr.Append(" declare @keyid varchar(20) select  @keyid='" & txtTkey.Text & "' ")
                    sqlstr.Append(" update m_Logtree_t set Ttext=N'" & txtTtext.Text.Trim & "',Enname=N'" & txtEnname.Text.Trim & "',TreeTag=N'" & txtTreeTag.Text.Trim & "', Tparent='" & cmbTparent.SelectedNode.Name & "'	 where Tkey=@keyid ")
                    If chkSqlUsey.Checked Then
                        sqlstr.Append(" if not exists(select * from m_Logtree_Det_t where Tkey=@keyid) ")
                        sqlstr.Append(" insert m_Logtree_Det_t(Tkey,SqlScript,SqlUsey,DetScript,DetUsey,ChartScript,ChartTitle,ChartType,ChartUsey) ")
                        sqlstr.Append(" values(@keyid,@SQLSCRIPT,'" & IIf(chkSqlUsey.Checked, "Y", "N") & "',@DetScript,'" & IIf(chkDetUsey.Checked, "Y", "N") & "',@ChartScript,@ChartTitle,@ChartType,'" & IIf(chkChartUsey.Checked, "Y", "N") & "') ")
                        sqlstr.Append(" else ")
                        sqlstr.Append(" update m_Logtree_Det_t set SqlScript=@SQLSCRIPT,SqlUsey='" & IIf(chkSqlUsey.Checked, "Y", "N") & "',DetScript=@DetScript,DetUsey='" & IIf(chkDetUsey.Checked, "Y", "N") & "',ChartScript=@ChartScript,ChartTitle=@ChartTitle,ChartType=@ChartType,ChartUsey='" & IIf(chkChartUsey.Checked, "Y", "N") & "' where Tkey=@keyid ")
                        sqlstr.Append(" declare @ReportUsey varchar(1)='Y'")
                    Else
                        sqlstr.Append(" update m_Logtree_Det_t set SqlScript=@SQLSCRIPT,SqlUsey='N',DetScript=@DetScript,DetUsey='" & IIf(chkDetUsey.Checked, "Y", "N") & "',ChartScript=@ChartScript,ChartTitle=@ChartTitle,ChartType=@ChartType,ChartUsey='" & IIf(chkChartUsey.Checked, "Y", "N") & "' where Tkey=@keyid ")
                        sqlstr.Append(" declare @ReportUsey varchar(1)='N'")
                    End If
                    sqlstr.Append(" declare @Tparent varchar(30)")
                    sqlstr.Append(" update m_Logtree_t set ReportUsey=@ReportUsey where Tkey=@keyid")
                    sqlstr.Append(" select @Tparent=Tparent from m_Logtree_t where Tkey=@keyid")
                    sqlstr.Append(" while @Tparent<>'m0_'  ")
                    sqlstr.Append(" begin")
                    sqlstr.Append(" if @ReportUsey='N'")
                    sqlstr.Append(" begin")
                    sqlstr.Append("  if not exists(select * from m_Logtree_t where ReportUsey='Y' and Tparent=@Tparent)")
                    sqlstr.Append("  begin")
                    sqlstr.Append("  update m_Logtree_t set ReportUsey='N' where Tkey=@Tparent	")
                    sqlstr.Append("  end")
                    sqlstr.Append("  select @Tparent=Tparent from m_Logtree_t where Tkey=@Tparent ")
                    sqlstr.Append(" end")
                    sqlstr.Append(" else")
                    sqlstr.Append("  begin")
                    sqlstr.Append("   update m_Logtree_t set ReportUsey='Y' where Tkey=@Tparent")
                    sqlstr.Append("   select @Tparent=Tparent from m_Logtree_t where Tkey=@Tparent  ")
                    sqlstr.Append("  end")
                    sqlstr.Append(" end")
                    sqlstr.Append(" select  @keyid as Tkey ")
                Else
                    MessageBox.Show("不允许设置父级菜单为本身！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

            End If
            Dim Rtable As DataTable = Conn.GetDataTable(sqlstr.ToString.Trim, parameters)
            Me.txtTkey.Text = Rtable.Rows(0)("Tkey").ToString.Trim
            loadTreeData()
            ToolUnDo_Click(Nothing, Nothing)
            AdvTree1.SelectedIndex = AdvTree1.FindNodeByDataKey(Me.txtTkey.Text).Index ' CuurIndexMstr
            AdvTree1_Click(Nothing, Nothing)
            MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'ClearQryDetData()
            'TabControl1.SelectedIndex = 1
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmReportManage", "SaveLogtreeData", "sys")
        End Try

    End Sub

    Private Sub SaveQryDetData()
        Try
            Dim sqlstr As New StringBuilder
            Dim parameters() As SqlParameter = {New SqlParameter("@Tkey", SqlDbType.VarChar, 20), New SqlParameter("@PARA_NAME", SqlDbType.VarChar, 50), New SqlParameter("@PARA_CHG_NAME", SqlDbType.NVarChar, 50), New SqlParameter("@PARA_TYPE", SqlDbType.VarChar, 1), New SqlParameter("@PARA_LENGTH", SqlDbType.Int, 4), New SqlParameter("@DEFAULT_VALUE", SqlDbType.NVarChar, 200), New SqlParameter("@TABLENAME", SqlDbType.NVarChar, 2000), New SqlParameter("@CONDITIONSQL", SqlDbType.NVarChar, 500)}

            parameters(0).Value = txttkey1.Text.Trim
            parameters(1).Value = txtPARA_NAME.Text
            parameters(2).Value = txtPARA_CHG_NAME.Text
            parameters(3).Value = comPARA_TYPE.Text.Split("-")(0)
            parameters(4).Value = Integer.Parse(txtPARA_LENGTH.Text)
            parameters(5).Value = txtDEFAULT_VALUE.Text
            parameters(6).Value = txtTABLENAME.Text
            parameters(7).Value = txtCONDITIONSQL.Text


            If opFlag = 4 Then
                sqlstr.Append(" declare @QRYSEQ int select @QRYSEQ=isnull(max(QRYSEQ),0)+1  from m_Logtree_Qry_t where Tkey=@Tkey")
                sqlstr.Append(" insert m_Logtree_Qry_t(Tkey,QRYSEQ,PARA_NAME,PARA_CHG_NAME,PARA_TYPE,PARA_LENGTH,DEFAULT_VALUE,TABLENAME,SELVALUES,ISNUL,CONDITIONSQL,STAMPUSERNAME,STAMPDATETIME) values(@Tkey,@QRYSEQ	,@PARA_NAME,@PARA_CHG_NAME,@PARA_TYPE		,	@PARA_LENGTH	,	@DEFAULT_VALUE ,	@TABLENAME	,	N''	,	'" & IIf(ChkISNUL.Checked, 1, 0) & "'	,	@CONDITIONSQL	,	'" & SysMessageClass.UseId & "'	,	getdate()	)")
                sqlstr.Append(" select  @QRYSEQ as QRYSEQ ")
            End If
            If opFlag = 5 Then
                sqlstr.Append(" update m_Logtree_Qry_t set PARA_NAME=@PARA_NAME	,	PARA_CHG_NAME=@PARA_CHG_NAME	,	PARA_TYPE=@PARA_TYPE		,	PARA_LENGTH=@PARA_LENGTH	,	DEFAULT_VALUE=@DEFAULT_VALUE	,	TABLENAME=@TABLENAME	,	SELVALUES=N''	,	ISNUL='" & IIf(ChkISNUL.Checked, 1, 0) & "'	,	CONDITIONSQL=@CONDITIONSQL	,	STAMPUSERNAME='" & SysMessageClass.UseId & "'	,	STAMPDATETIME=getdate() where Tkey=@Tkey and QRYSEQ='" & txtSEQ.Text.Trim & "' ")
                sqlstr.Append(" select  '" & txtSEQ.Text & "' as QRYSEQ ")
            End If
            Dim Rtable As DataTable = Conn.GetDataTable(sqlstr.ToString.Trim, parameters)
            Me.txtSEQ.Text = Rtable.Rows(0)("QRYSEQ").ToString.Trim
            Dim dtdet As DataTable = GetQryDetDt(txttkey1.Text.Trim)
            DataGridViewX1.DataSource = dtdet
            MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ToolUnDo_Click(Nothing, Nothing)
            ClearQryDetData()
            GroupBox5.Enabled = False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmReportManage", "SaveLogtreeQryData", "sys")
        End Try
    End Sub

    Private Sub ToolUnDo_Click(sender As Object, e As EventArgs) Handles ToolUnDo.Click
        Select Case TabControl1.SelectedTabIndex
            Case 0   '菜单主表
                opFlag = 0
                SetStatus(opFlag)
                GroupBox1.Enabled = False
                GroupBox2.Enabled = False
                GroupBox3.Enabled = False
                AdvTree1.Enabled = True
                'ClearLogtreeData()

            Case 1   '编辑报表查询主表
                opFlag = 3
                SetStatus(opFlag)
                GroupBox5.Enabled = False
                DataGridViewX1.Enabled = True

        End Select
        Me.TabControl1.Tag = Me.TabControl1.SelectedTabIndex

    End Sub

    Private Sub EditLogtreeData()
        If Me.AdvTree1.Nodes.Count = 0 Or AdvTree1.SelectedNode Is Nothing Or Me.txtTkey.Text = "" Then
            MessageBox.Show("请选择子菜单")
            Exit Sub
        End If

        opFlag = 2
        SetStatus(opFlag)
        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        GroupBox3.Enabled = True
        AdvTree1.Enabled = False
        Me.ActiveControl = Me.txtTtext
    End Sub
    Private Sub EditQryDetData()
        If Me.DataGridViewX1.RowCount = 0 Or DataGridViewX1.SelectedRows Is Nothing Then
            MessageBox.Show("请选择一条参数记录")
            Exit Sub
        End If
        'Me.txtSEQ.Text = DataGridViewX1.CurrentRow.Cells(1).Value.ToString
        'Me.txtPARA_NAME.Text = DataGridViewX1.CurrentRow.Cells("PARA_NAME").Value.ToString
        'Me.txtPARA_CHG_NAME.Text = DataGridViewX1.CurrentRow.Cells("PARA_CHG_NAME").Value.ToString
        'Me.comPARA_TYPE.SelectedIndex = Me.comPARA_TYPE.FindString(DataGridViewX1.CurrentRow.Cells("PARA_TYPE").Value.ToString)
        'Me.txtDEFAULT_VALUE.Text = DataGridViewX1.CurrentRow.Cells("DEFAULT_VALUE").Value.ToString
        'Me.txtPARA_LENGTH.Text = DataGridViewX1.CurrentRow.Cells("PARA_LENGTH").Value.ToString
        'Me.txtTABLENAME.Text = DataGridViewX1.CurrentRow.Cells("TABLENAME").Value.ToString
        'Me.ChkISNUL.Checked = Boolean.Parse(DataGridViewX1.CurrentRow.Cells("ISNUL").Value.ToString)
        'Me.txtCONDITIONSQL.Text = DataGridViewX1.CurrentRow.Cells("CONDITIONSQL").Value.ToString
      

        opFlag = 5
        SetStatus(opFlag)
        DataGridViewX1.Enabled = False
        GroupBox5.Enabled = True
        Me.ActiveControl = Me.txtPARA_NAME
    End Sub
    '設置工具條按鈕的可用
    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0
                ToolNew.Enabled = IIf(ToolNew.Tag.ToString = "YES", True, False)
                ToolEdit.Enabled = IIf(ToolEdit.Tag.ToString = "YES", True, False)
                ToolDelete.Enabled = IIf(ToolDelete.Tag.ToString = "YES", True, False)
                ToolSave.Enabled = False
                ToolUnDo.Enabled = False
                ToolRefresh.Enabled = True
                'ToolLock.Enabled = True
                'ToolUnLock.Enabled = True
            Case 1, 2
                ToolNew.Enabled = False
                ToolEdit.Enabled = False
                ToolDelete.Enabled = False
                ToolSave.Enabled = True
                ToolUnDo.Enabled = True
                ToolRefresh.Enabled = False
                'ToolLock.Enabled = False
                'ToolUnLock.Enabled = False
            Case 3
                ToolNew.Enabled = IIf(ToolNew.Tag.ToString = "YES", True, False)
                ToolEdit.Enabled = IIf(ToolEdit.Tag.ToString = "YES", True, False)
                ToolDelete.Enabled = IIf(ToolDelete.Tag.ToString = "YES", True, False)
                ToolSave.Enabled = False
                ToolUnDo.Enabled = False
                ToolRefresh.Enabled = True
            Case 4, 5 '設置編碼原則明細表中按鈕的可用: 新增/修改
                ToolNew.Enabled = False
                ToolEdit.Enabled = False
                ToolDelete.Enabled = False
                ToolSave.Enabled = True
                ToolUnDo.Enabled = True
                ToolRefresh.Enabled = False

                'Me.CboRuleID.Enabled = False
                'Me.cmbType.Enabled = IIf(opFlag = 4, True, False)
                'Me.btnOpen.Enabled = False
                'Me.dgM_SnRuleD_t.Enabled = False
            Case 6   '設置格式主表狀態： 初始
                ToolNew.Enabled = IIf(ToolNew.Tag.ToString = "YES", True, False)
                ToolEdit.Enabled = IIf(ToolEdit.Tag.ToString = "YES", True, False)
                ToolDelete.Enabled = IIf(ToolDelete.Tag.ToString = "YES", True, False)

                ToolSave.Enabled = False
                ToolUnDo.Enabled = False
                ToolRefresh.Enabled = True

                'Me.txtPFormatID.Enabled = True
                'Me.CboRuleID2.Enabled = True
                'Me.dgm_SnPFormat_t.Enabled = True
                'Me.ActiveControl = Me.txtPFormatID
                'Me.btnOpen.Enabled = False
                'Me.txtFilename.Clear()
                'Me.btnOpen.Enabled = False

                'Areaid.ReadOnly = True
                'Areaid.DefaultCellStyle.BackColor = Color.White
                'Style.ReadOnly = True
                'Style.DefaultCellStyle.BackColor = Color.White

        End Select
    End Sub
    Private Sub ClearLogtreeData()
        Me.txtTkey.Text = ""
        Me.cmbTparent.Text = "m09_"
        cmbTparent.SelectedIndex = 0
        Me.txtTtext.Text = ""
        Me.txtEnname.Text = ""
        Me.txtTreeTag.Text = ""
    

        chkChartUsey.Checked = False
        chkSqlUsey.Checked = False
        chkDetUsey.Checked = False
        txtChartScript.Text = ""
        txtChartTitle.Text = ""
        txtChartType.SelectedIndex = -1
        txtDetScript.Text = ""
        txtSQLSCRIPT.Text = ""
        AdvTree1.Enabled = True
        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        GroupBox3.Enabled = True
    End Sub

    Private Sub ClearQryDetData()
        txtSEQ.Text = ""
        txtPARA_NAME.Text = ""
        txtPARA_CHG_NAME.Text = ""
        txtDEFAULT_VALUE.Text = ""
        txtCONDITIONSQL.Text = ""
        ChkISNUL.Checked = False
        txtTABLENAME.Text = ""
        txtPARA_LENGTH.Text = ""
        comPARA_TYPE.SelectedIndex = -1
        DataGridViewX1.Enabled = True
        GroupBox5.Enabled = True
    End Sub

    Private Sub TabItem1_MouseDown(sender As Object, e As MouseEventArgs) Handles TabItem1.MouseDown
        If opFlag <> 0 AndAlso opFlag <> 3 Then Me.TabControl1.SelectedTabIndex = Me.TabControl1.Tag : Exit Sub
        Me.TabControl1.Tag = Me.TabControl1.SelectedTabIndex
    End Sub

    Private Sub TabItem2_MouseDown(sender As Object, e As MouseEventArgs) Handles TabItem2.MouseDown
        If opFlag <> 0 AndAlso opFlag <> 3 Then Me.TabControl1.SelectedTabIndex = Me.TabControl1.Tag : Exit Sub
        Me.TabControl1.Tag = Me.TabControl1.SelectedTabIndex
    End Sub
    Private Sub txtSQLSCRIPT1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSQLSCRIPT1.KeyDown
        If e.Modifiers = Keys.Control And e.KeyCode = Keys.A Then
            txtSQLSCRIPT1.SelectAll()
        End If

    End Sub

    Private Sub txtSQLSCRIPT_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSQLSCRIPT.KeyDown
        If e.Modifiers = Keys.Control And e.KeyCode = Keys.A Then
            txtSQLSCRIPT.SelectAll()
        End If
    End Sub

    Private Sub txtTABLENAME_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTABLENAME.KeyDown
        If e.Modifiers = Keys.Control And e.KeyCode = Keys.A Then
            txtTABLENAME.SelectAll()
        End If
    End Sub

    Private Sub DataGridViewX1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellClick
        If opFlag = 4 Then
            Exit Sub
        End If
        If Me.DataGridViewX1.RowCount = 0 Or DataGridViewX1.SelectedRows Is Nothing Then
            Exit Sub
        End If
        'CuurIndexDet = DataGridViewX1.Current
        Dim tkey As String = DataGridViewX1.CurrentRow.Cells("Tkey").Value
        Me.txtSEQ.Text = DataGridViewX1.CurrentRow.Cells(1).Value.ToString
        Me.txtPARA_NAME.Text = DataGridViewX1.CurrentRow.Cells("PARA_NAME").Value.ToString
        Me.txtPARA_CHG_NAME.Text = DataGridViewX1.CurrentRow.Cells("PARA_CHG_NAME").Value.ToString
        Me.comPARA_TYPE.SelectedIndex = Me.comPARA_TYPE.FindString(DataGridViewX1.CurrentRow.Cells("PARA_TYPE").Value.ToString)
        Me.txtDEFAULT_VALUE.Text = DataGridViewX1.CurrentRow.Cells("DEFAULT_VALUE").Value.ToString
        Me.txtPARA_LENGTH.Text = DataGridViewX1.CurrentRow.Cells("PARA_LENGTH").Value.ToString
        Me.txtTABLENAME.Text = DataGridViewX1.CurrentRow.Cells("TABLENAME").Value.ToString
        Me.ChkISNUL.Checked = Boolean.Parse(DataGridViewX1.CurrentRow.Cells("ISNUL").Value.ToString)
        Me.txtCONDITIONSQL.Text = DataGridViewX1.CurrentRow.Cells("CONDITIONSQL").Value.ToString
        CuurDetRowIndex = DataGridViewX1.CurrentCell.RowIndex
        CuurDetColIndex = DataGridViewX1.CurrentCell.ColumnIndex


    End Sub

    Private Sub LblUp_Click(sender As Object, e As EventArgs) Handles LblUp.Click
        If opFlag = 4 Then
            Exit Sub
        End If
        If Me.DataGridViewX1.RowCount = 0 Or DataGridViewX1.SelectedRows Is Nothing Then
            Exit Sub
        End If
        Dim tkey As String = DataGridViewX1.CurrentRow.Cells("Tkey").Value
        Dim seq As Integer = Integer.Parse(DataGridViewX1.CurrentRow.Cells("QRYSEQ").Value)
        Dim count As Integer = DataGridViewX1.RowCount
        If seq = 1 Then
            MessageBox.Show("已经到顶，不需再往上移动")
            Exit Sub
        End If
        Dim sql As String = String.Format(" update m_Logtree_Qry_t set QRYSEQ=99 where Tkey='{0}' and QRYSEQ={1}", tkey, seq.ToString)
        sql = sql + String.Format(" update m_Logtree_Qry_t set QRYSEQ={2} where Tkey='{0}' and QRYSEQ={1}", tkey, (seq - 1).ToString, seq.ToString)
        sql = sql + String.Format(" update m_Logtree_Qry_t set QRYSEQ={1} where Tkey='{0}' and QRYSEQ=99", tkey, (seq - 1).ToString)
        sql = sql + String.Format("select Tkey,QRYSEQ,PARA_NAME,PARA_CHG_NAME,PARA_TYPE,PARA_LENGTH,DEFAULT_VALUE,TABLENAME,ISNUL,CONDITIONSQL,STAMPUSERNAME,STAMPDATETIME from m_Logtree_Qry_t where Tkey='{0}'  order by QRYSEQ ", tkey)
        Dim dtdet As DataTable = Conn.GetDataTable(sql.ToString.Trim)
        DataGridViewX1.DataSource = dtdet
        CuurDetRowIndex = CuurDetRowIndex - 1
        DataGridViewX1.CurrentCell = DataGridViewX1.Rows(CuurDetRowIndex).Cells(CuurDetColIndex)
        txtSEQ.Text = (seq - 1).ToString
    End Sub

    Private Sub LblDown_Click(sender As Object, e As EventArgs) Handles LblDown.Click
        If opFlag = 4 Then
            Exit Sub
        End If
        If Me.DataGridViewX1.RowCount = 0 Or DataGridViewX1.SelectedRows Is Nothing Then
            Exit Sub
        End If
        Dim tkey As String = DataGridViewX1.CurrentRow.Cells("Tkey").Value
        Dim seq As Integer = Integer.Parse(DataGridViewX1.CurrentRow.Cells("QRYSEQ").Value)
        Dim count As Integer = DataGridViewX1.RowCount
        If seq = count Then
            MessageBox.Show("已经到底，不需再往下移动")
            Exit Sub
        End If
        Dim sql As String = String.Format(" update m_Logtree_Qry_t set QRYSEQ=99 where Tkey='{0}' and QRYSEQ={1}", tkey, seq.ToString)
        sql = sql + String.Format(" update m_Logtree_Qry_t set QRYSEQ={2} where Tkey='{0}' and QRYSEQ={1}", tkey, (seq + 1).ToString, seq.ToString)
        sql = sql + String.Format(" update m_Logtree_Qry_t set QRYSEQ={1} where Tkey='{0}' and QRYSEQ=99", tkey, (seq + 1).ToString)
        sql = sql + String.Format("select Tkey,QRYSEQ,PARA_NAME,PARA_CHG_NAME,PARA_TYPE,PARA_LENGTH,DEFAULT_VALUE,TABLENAME,ISNUL,CONDITIONSQL,STAMPUSERNAME,STAMPDATETIME from m_Logtree_Qry_t where Tkey='{0}'  order by QRYSEQ ", tkey)
        Dim dtdet As DataTable = Conn.GetDataTable(sql.ToString.Trim)
        DataGridViewX1.DataSource = dtdet
        CuurDetRowIndex = CuurDetRowIndex + 1
        DataGridViewX1.CurrentCell = DataGridViewX1.Rows(CuurDetRowIndex).Cells(CuurDetColIndex)
        txtSEQ.Text = (seq + 1).ToString
    End Sub
    Private Function ReplaceNoCase(ByVal realaceValue As String, ByVal oldValue As String, ByVal NewValue As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(realaceValue, oldValue, NewValue, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function
    Private Sub BnSelectSta_Click(sender As Object, e As EventArgs) Handles BnSelectSta.Click
        Dim frm As FrmQueryInfo = New FrmQueryInfo
        frm.ShowDialog()
        txtTABLENAME.Text = frm._INFO.returnValue
    End Sub

    Private Sub btnquerytest_Click(sender As Object, e As EventArgs) Handles btnquerytest.Click
        Dim frm As FrmReportChar = New FrmReportChar()
        frm.Text = "统计图范例-随机生成DEMO数据"
        frm.ShowDialog()

    End Sub

    Private Sub btnReportView_Click(sender As Object, e As EventArgs) Handles btnReportView.Click
        Dim Frm As FrmReportMain = New FrmReportMain
        Frm.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub comPARA_TYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comPARA_TYPE.SelectedIndexChanged
        'C -字符格式
        'S -字符格式(多行)
        'D -日期格式
        'N -数字格式
        'L -下拉列表
        'T -下拉选择(可输入)
        If comPARA_TYPE.Text.Split("-")(0).ToString() = "C" Then
            txtPARA_LENGTH.Text = "50"
        End If
        If comPARA_TYPE.Text.Split("-")(0).ToString() = "S" Then
            txtPARA_LENGTH.Text = "8000"
        End If
        If comPARA_TYPE.Text.Split("-")(0).ToString() = "D" Then
            txtPARA_LENGTH.Text = "30"
        End If
        If comPARA_TYPE.Text.Split("-")(0).ToString() = "N" Then
            txtPARA_LENGTH.Text = "8"
        End If
        If comPARA_TYPE.Text.Split("-")(0).ToString() = "T" Then
            txtPARA_LENGTH.Text = "50"
        End If
    End Sub


    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        Select Case TabControl1.SelectedTabIndex
            Case 0   '菜单主表
                'DeleteLogtreeData()
            Case 1   '编辑报表查询
                DeleteQryDetData()
        End Select
    End Sub
    Private Sub DeleteQryDetData()
        Try
            Dim sqlstr As New StringBuilder
            Dim parameters() As SqlParameter = {New SqlParameter("@Tkey", SqlDbType.VarChar, 20), New SqlParameter("@PARA_NAME", SqlDbType.VarChar, 50), New SqlParameter("@PARA_CHG_NAME", SqlDbType.NVarChar, 50), New SqlParameter("@PARA_TYPE", SqlDbType.VarChar, 1), New SqlParameter("@PARA_LENGTH", SqlDbType.Int, 4), New SqlParameter("@DEFAULT_VALUE", SqlDbType.NVarChar, 200), New SqlParameter("@TABLENAME", SqlDbType.NVarChar, 2000), New SqlParameter("@CONDITIONSQL", SqlDbType.NVarChar, 500)}

            parameters(0).Value = txttkey1.Text.Trim
            parameters(1).Value = txtPARA_NAME.Text
            parameters(2).Value = txtPARA_CHG_NAME.Text
            parameters(3).Value = comPARA_TYPE.Text.Split("-")(0)
            parameters(4).Value = Integer.Parse(txtPARA_LENGTH.Text)
            parameters(5).Value = txtDEFAULT_VALUE.Text.ToLower
            parameters(6).Value = txtTABLENAME.Text.ToLower
            parameters(7).Value = txtCONDITIONSQL.Text

            sqlstr.Append(" delete m_Logtree_Qry_t  where Tkey=@Tkey and QRYSEQ='" & txtSEQ.Text.Trim.ToLower & "' ")
            Dim Rtable As String = Conn.ExecuteNonQuery(sqlstr.ToString.Trim, parameters)
            Dim dtdet As DataTable = GetQryDetDt(txttkey1.Text.Trim)
            DataGridViewX1.DataSource = dtdet
            MessageBox.Show("删除成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ToolUnDo_Click(Nothing, Nothing)
            ClearQryDetData()
            GroupBox5.Enabled = False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmReportManage", "SaveLogtreeQryData", "sys")
        End Try
    End Sub

End Class