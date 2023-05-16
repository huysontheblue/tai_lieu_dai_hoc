Imports MainFrame
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Net
Imports System.IO
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class FrmContact

    '变量定义
    Dim OperateFlag As EditMode '操作模式

    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum


#Region "相关事件"

    '初期化
    Private Sub FrmContact_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '设定用戶權限
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        TabControl1_SelectedIndexChanged(Nothing, Nothing)

        dtpDTQuery.Value = Date.Now
        SetIPAddress()

        BMComDB.BindComboxDutyUser(cboDutyUser)
        BMComDB.BindComboxDutyType(cmbDuteType)

        toolSearch_Click(Nothing, Nothing)
    End Sub

    '切换选择
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        SetToolButton(False)
        If TabControl1.SelectedIndex = 0 Then
            'toolSearch.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(ToolStar.Tag) = "YES", True, False))
        Else
            Me.toolNew.Enabled = IIf(DbOperateUtils.DBNullToStr(toolNew.Tag) = "YES", True, False)
            Me.toolModify.Enabled = IIf(DbOperateUtils.DBNullToStr(toolModify.Tag) = "YES", True, False)
            Me.toolDelete.Enabled = IIf(DbOperateUtils.DBNullToStr(toolDelete.Tag) = "YES", True, False)
            'Me.toolBatch.Enabled = IIf(DbOperateUtils.DBNullToStr(toolBatch.Tag) = "YES", True, False)
            Me.toolBatch.Enabled = True
        End If
    End Sub

    '设置颜色
    Private Sub dgViewQuery_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgViewQuery.DataBindingComplete
        SetWeekDate()
        SetCurrentDay()
    End Sub

    '控件点选
    Private Sub dgViewEdit_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgViewEdit.CellClick
        '面板控件赋值
        If e.RowIndex < 0 Then Exit Sub

        SetGroupBox(dgViewEdit)
    End Sub

#End Region


#Region "工具条"

    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '查询
    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        If TabControl1.SelectedIndex = 0 Then
            QueryData()
        Else
            QueryEveryData()
        End If
    End Sub

    '新增
    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        '设置操作模式
        OperateFlag = EditMode.ADD
        '工具栏控件状态
        SetControlStatus(EditMode.ADD)
        '清除面板控件值
        ClearGroupBox()

    End Sub

    '修改
    Private Sub toolModify_Click(sender As Object, e As EventArgs) Handles toolModify.Click
        '设置操作模式
        OperateFlag = EditMode.EDIT
        '工具栏控件状态
        SetControlStatus(EditMode.EDIT)

    End Sub

    '删除
    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        If MessageUtils.ShowConfirm("确定要删除吗？", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim strSQL As String = " delete m_DutyPlan_t where ID = '{0}' "

            strSQL = String.Format(strSQL, Val(Me.lblId.Text.Trim))
            DbOperateUtils.ExecSQL(strSQL)
            MessageUtils.ShowInformation("删除成功")
            QueryEveryData()
        End If
    End Sub

    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim index As Integer = TabControl1.SelectedIndex
        If Me.OperateFlag = EditMode.ADD Or Me.OperateFlag = EditMode.EDIT Then
            '检查输入
            If CheckInput() = False Then
                Exit Sub
            End If
            '确认信息
            If MessageUtils.ShowConfirm("你确定保存吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            '保存
            If SaveData() = False Then Exit Sub

            MessageUtils.ShowInformation("保存成功")
            '清除面板控件值
            ClearGroupBox()

            'ToogleGroupBox(0)
            '刷新
            QueryEveryData()
            SetControlStatus(EditMode.UNDO)
        End If
    End Sub

    '返回
    Private Sub toolUndo_Click(sender As Object, e As EventArgs) Handles toolUndo.Click
        '设置操作模式
        OperateFlag = EditMode.UNDO
        '工具栏控件状态
        SetControlStatus(EditMode.UNDO)
        '清除面板控件值
        ClearGroupBox()
    End Sub

#End Region


#Region "方法"

#Region "检查输入"
    Private Function CheckInput() As Boolean

        Try
            If cboDutyUser.Text = "" Then
                MessageUtils.ShowError("值班人员不能为空！")
                Return False
            End If
            If cmbDuteType.Text = "" Then
                MessageUtils.ShowError("值班类型不能为空")
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return True

    End Function
#End Region

#Region "保存数据"
    Private Function SaveData() As Boolean
        Dim strSQL As String = ""
        Try

            Dim userId As String = VbCommClass.VbCommClass.UseId
            Dim FactoryName As String = VbCommClass.VbCommClass.Factory
            Dim Profitcenter As String = VbCommClass.VbCommClass.profitcenter
            Dim dutyDate As String = dtpDT.Value.Date.ToString("yyyy/MM/dd")
            Dim dutyUser As String = cboDutyUser.SelectedValue.ToString
            Dim strBSQL As New System.Text.StringBuilder
            '
            If OperateFlag = EditMode.ADD Then     '新增
                '设备编号是否存在
                strSQL = "SELECT 1 FROM m_DutyPlan_t(nolock) where CONVERT(varchar,DT,111) =N'{0}' and UserID = '{1}'"
                strSQL = String.Format(strSQL, dutyDate, dutyUser)
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    MessageUtils.ShowError(String.Format("人员{0}在日期{1}已安排值班计划，请修改!", dutyUser, dutyDate))
                    Return False
                Else
                    strSQL = " INSERT INTO m_DutyPlan_t([DT],[UserID],[DutyType],[Remark],CreateUser,Intime)"

                    strBSQL.Append(strSQL)
                    strBSQL.Append(" VALUES(")
                    strBSQL.AppendFormat("N'{0}',", dutyDate)
                    strBSQL.AppendFormat("N'{0}',", dutyUser)
                    strBSQL.AppendFormat("N'{0}',", cmbDuteType.Text)
                    strBSQL.AppendFormat("N'{0}',", txtRemark.Text)
                    strBSQL.AppendFormat("N'{0}',", userId)
                    strBSQL.AppendFormat(" getdate() ")
                    strBSQL.Append(");")

                End If
            Else    '修改
                strSQL = "UPDATE m_DutyPlan_t "

                strBSQL.Append(strSQL)
                strBSQL.AppendFormat(" SET DT = N'{0}', ", dutyDate)
                strBSQL.AppendFormat(" UserID = N'{0}', ", dutyUser)
                strBSQL.AppendFormat(" DutyType = N'{0}', ", cmbDuteType.Text)
                strBSQL.AppendFormat(" Remark = N'{0}' ,", txtRemark.Text)
                strBSQL.AppendFormat(" CreateUser = N'{0}', ", userId)
                strBSQL.AppendFormat(" InTime=getdate() ")
                strBSQL.AppendFormat(" WHERE ID = {0}", Val(Me.lblId.Text.Trim))

            End If
            '执行SQL
            DbOperateUtils.ExecSQL(strBSQL.ToString)
            Return True
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            Return False
        End Try
    End Function
#End Region

    '查询数据
    Private Sub QueryData()
        Dim strSQL As String = " exec [usp_Duty_WeekPlan] '{0}','1' "
        strSQL = String.Format(strSQL, dtpDTQuery.Value.Date)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        dgViewQuery.DataSource = dt
    End Sub

    '设置当前日期颜色
    Private Sub SetCurrentDay()
        Dim strSQL As String = String.Empty
        strSQL = String.Format("  select DATENAME(MONTH,GETDATE())+'/'+DATENAME(DAY,GETDATE()) ")

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Dim curWeekday As String = String.Empty
        If dt.Rows.Count > 0 Then
            curWeekday = dt.Rows(0)(0).ToString
        End If

        For i As Integer = 0 To dgViewQuery.Columns.Count - 1
            If dgViewQuery.Columns(i).HeaderText.Contains(curWeekday) Then
                For rowIndex As Integer = 0 To dgViewQuery.Rows.Count - 1
                    If String.IsNullOrEmpty(dgViewQuery.Rows(rowIndex).Cells(i).Value.ToString) = False Then
                        dgViewQuery.Rows(rowIndex).Cells(i).Style.BackColor = Color.Green
                    End If
                Next
            End If
        Next

    End Sub

    '设置表头
    Private Function SetWeekDate()
        Dim strSQL As String = String.Empty
        strSQL = String.Format(" select * from fun_weekdate('{0}') ", dtpDTQuery.Value.Date)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        For i As Integer = 0 To dt.Rows.Count - 1
            'dgViewQuery.Columns(i + 6).HeaderText = dt.Rows(i)(0).ToString & Environment.NewLine & dt.Rows(i)(1).ToString
            dgViewQuery.Columns(i + 6).HeaderText = "  " & dt.Rows(i)(1).ToString & Convert.ToDateTime(dt.Rows(i)(0).ToString).ToString("MM/dd")
        Next
        Return dt
    End Function

    '查询所有数据
    Private Sub QueryEveryData()
        Dim strSQL As String = String.Empty
        strSQL = " select CONVERT(varchar,dt,111) dt,DATENAME (DW ,dt) weekday," &
                 " (select UserName from m_DutyUsers_t dtUser where dtUser.UserID = dtPlan.UserID) UserName,DutyType,Remark,UserID,ID " &
                 " from m_DutyPlan_t dtPlan where 1=1 "
        Dim strWhere As String = ""
        Dim strOrder As String = " order by dt"
        If chkMonthSearch.Checked = True Then
            strWhere = strWhere + String.Format(" and CONVERT(varchar(6),dt,112) = '{0}'", dtpDT.Value.ToString("yyyyMM"))
        Else
            strWhere = strWhere + String.Format(" and CONVERT(varchar,dt,112) = '{0}'", dtpDT.Value.ToString("yyyyMMdd"))
        End If
        If cboDutyUser.Text <> "" Then
            strWhere = strWhere + String.Format(" and dtPlan.UserID = '{0}'", cboDutyUser.SelectedValue.ToString)
        End If
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere + strOrder)

        dgViewEdit.DataSource = dt
    End Sub

    '设置按钮编辑性
    Private Sub SetToolButton(bFlag As Boolean)
        toolNew.Enabled = bFlag
        toolModify.Enabled = bFlag
        toolDelete.Enabled = bFlag
        toolSave.Enabled = bFlag
        toolUndo.Enabled = bFlag
        toolBatch.Enabled = bFlag
    End Sub

    '设置状态
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
                Me.toolDelete.Enabled = IIf(DbOperateUtils.DBNullToStr(toolDelete.Tag) = "YES", True, False)
                Me.toolBatch.Enabled = IIf(DbOperateUtils.DBNullToStr(toolBatch.Tag) = "YES", True, False)
                Me.toolNew.Enabled = True
                Me.toolModify.Enabled = True
                Me.toolDelete.Enabled = True
                Me.toolBatch.Enabled = True
                toolSearch.Enabled = True
            Case EditMode.SEARCH '搜索
                'toolUndo.Enabled = True
                'toolSearch.Enabled = True
        End Select
    End Sub

    '设置按钮状态
    Private Sub SetButtonEnable(bFlag As Boolean)
        toolNew.Enabled = bFlag
        toolModify.Enabled = bFlag
        toolSave.Enabled = bFlag
        toolUndo.Enabled = bFlag
        toolDelete.Enabled = bFlag
        'toolSearch.Enabled = bFlag
    End Sub

    '设置值 
    Private Sub SetGroupBox(dgGrid As DataGridView)
        Me.lblId.Text = dgGrid.Item("colID", dgGrid.CurrentRow.Index).Value.ToString()
        Me.dtpDT.Text = dgGrid.Item("colDTA", dgGrid.CurrentRow.Index).Value.ToString()
        Me.cboDutyUser.SelectedValue = dgGrid.Item("colUserID", dgGrid.CurrentRow.Index).Value.ToString()
        Me.cmbDuteType.Text = dgGrid.Item("colDutyType", dgGrid.CurrentRow.Index).Value.ToString()
        Me.txtRemark.Text = dgGrid.Item("colRemark", dgGrid.CurrentRow.Index).Value.ToString()
    End Sub

    '查找电脑IP
    Private Sub SetIPAddress()
        Try
            Dim ipHost As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
            Dim ipaddress As IPAddress = Nothing
            Dim list As ArrayList = New ArrayList
            Dim ips As String = ""
            For i As Integer = 0 To ipHost.AddressList.Length - 1
                ipaddress = ipHost.AddressList(i)
                If (ipaddress.AddressFamily.ToString() = "InterNetwork") Then
                    If ipaddress.ToString.Length <> 19 Then
                        ips = ipaddress.ToString
                    End If
                End If
            Next
          
            txtIP.Text = String.Format("{0}（{1}）", My.Computer.Name, ips)
        Catch ex As Exception

        End Try
    End Sub

#Region "清除 GroupBox 面板控件值"
    Private Sub ClearGroupBox()
        Me.dtpDT.Value = DateTime.Now
        Me.cboDutyUser.Text = ""
        Me.cmbDuteType.Text = ""
        Me.txtRemark.Text = ""
    End Sub
#End Region

#End Region


    '魏孟丽
    Dim fileName As String '打开文件的路径
    Dim table_Name As String '打开文件的sheet名字
    Dim dtExcel As DataTable '将Excel内的数据存储在dataTable中
    Dim strcon As String = "server = 172.20.22.91; uid = mes; pwd = dg'songyy; database = MESDB"
    Dim sqlCon As SqlConnection '连接数据库
    Dim i As Integer '计数器
    Dim dr As DataRow
    Dim ds As New DataSet()
    Private Sub toolBatch_Click(sender As Object, e As EventArgs) Handles toolBatch.Click
        Try
            Dim ofd As New OpenFileDialog()
            ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "databackup\\" '默认打开文件的位置
            ofd.Filter = "Excel files office2003(*.xls)|*.xls|Excel office2010(*.xlsx)|*.xlsx|All files (*.*)|*.*" '默认打开文件的类型
            ofd.FilterIndex = 2 '默认选中上面文件类型的第二个
            ofd.RestoreDirectory = True '默认打开上次打开的文件
            If ofd.ShowDialog() = DialogResult.OK Then
                fileName = ofd.FileName '文件的全路径
                bind(fileName)
            End If
            sqlCon = New SqlConnection(strcon)
            sqlCon.Open()
            If dtExcel.Rows.Count > 0 Then
                dr = Nothing
                table_Name = table_Name.Substring(0, table_Name.Length - 1)
                For i = 0 To dtExcel.Rows.Count - 1
                    dr = dtExcel.Rows(i)
                    insertToSql(dr)
                Next
                sqlCon.Close()
                MsgBox("导入成功！")
            Else
                MsgBox("没有数据！")
                Return
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub bind(fileName As String)
        Try
            Dim sConnString As String = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source={0};" + "Extended Properties='Excel 8.0;HDR=YES;IMEX=1';", fileName)
            If (Path.GetExtension(fileName)).ToLower() = ".xls" Then
                sConnString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "data source=" + fileName + ";Extended Properties=Excel 5.0;Persist Security Info=False"
            End If
            Using oleDbConn As New OleDbConnection(sConnString)
                oleDbConn.Open()
                Dim dt As DataTable = oleDbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
                table_Name = dt.Rows(0)(2).ToString() 'Excel中sheetName
            End Using
            Dim da As New OleDbDataAdapter("SELECT *  FROM [" + table_Name + "]", sConnString)
            da.Fill(ds)
            dtExcel = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub insertToSql(dr As DataRow)
        Try
            '将表中的名字换成工号
            Dim strSQL As String = "select UserID from m_DutyUsers_t where UserName=N'" & dr("UserID").ToString() & "'"
            'excel表中的列名和数据库中的列名一定要对应  
            Dim datime As String = dr("DT").ToString()
            Dim userid As String = DbOperateUtils.GetDataTable(strSQL).Rows(0)(0)
            Dim dutytype As String = dr("DutyType").ToString()
            Dim remark As String = dr("Remark").ToString()
            Dim createuser As String = dr("CreateUser").ToString()
            Dim intime As String = dr("Intime").ToString()
            Dim sql As String = "insert into " + "" + table_Name + "" + " values(N'" + datime + "',N'" + userid + "',N'" + dutytype + "',N'" + remark + "',N'" + createuser + "',N'" + intime + "')"
            Dim cmd As New SqlCommand(sql, sqlCon)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        
    End Sub

End Class