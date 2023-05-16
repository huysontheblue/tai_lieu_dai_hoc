

Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Xml
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports MainFrame
Imports SysBasicClass
Public Class FrmAssetMaintenanceMonth

#Region "构造函数"
    ''' <summary>
    ''' 构造
    ''' </summary>
    ''' <param name="AssetNo">设备编码</param>
    ''' <param name="AssetName">设备名称</param>
    ''' <param name="Model">型号</param>
    ''' <param name="Storage">资产位置</param>
    ''' <remarks></remarks>
    Sub New(ByVal AssetNo As String, ByVal AssetName As String, ByVal Model As String, ByVal Storage As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        Me.txtAssetName.Text = AssetName
        Me.txtAssetNo.Text = AssetNo
        Me.txtModel.Text = Model
        Me.txtStorage.Text = Storage
    End Sub
#End Region
#Region "窗体事件"
    Private Sub FrmAssetMaintenanceMonth_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '检验月或季度保养是否已保养
        'ExistMaintenanceToMonth()
        'ExistMaintenanceToQuarter()
       
        '加载年份
        LoadYaer()

        LoadMaintenanceMonth()
        LoadMaintenanceQuarter()

        GetControlright("FrmEquipment")
    End Sub

    Public Sub GetControlright(ByVal Apformid As String)
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim lsSQL As String = "SELECT ButtonID from m_Logtree_t a left join m_userright_t b on a.Tkey=b.tkey where b.userid='" & SysCheckData.SysMessageClass.UseId & "' AND a.Formid=(select apid from m_SysapForm_t where Apformid='" & Apformid & "' ) and a.listy='N' and a.Tkey ='m131a5_'"
        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                btnSpecMonSave.Enabled = True
                btnSpecQuaSave.Enabled = True
            Else
                btnSpecMonSave.Enabled = False
                btnSpecQuaSave.Enabled = False
            End If
        End Using
    End Sub

    Private Sub tcMaintenanceMorQ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcMaintenanceMorQ.SelectedIndexChanged
        If Me.tcMaintenanceMorQ.SelectedIndex = 0 Then
            LoadMaintenanceMonth()
            LoadMaintenanceQuarter()
        ElseIf Me.tcMaintenanceMorQ.SelectedIndex = 1 Then
            LoadMaintenanceMonthEdit()
            txtProcessMonth.Text = Date.Now.Month.ToString
        Else
            LoadMaintenanceQuarterEdit()
            txtQuarter.Text = EquManageCommon.GetQuarter()
        End If
    End Sub

    ''' <summary>
    ''' 月保养保存
    ''' </summary>
    Private Sub btnMonSave_Click(sender As Object, e As EventArgs) Handles btnMonSave.Click
        If Me.dgvMaintenanceM.RowCount < 1 Then Exit Sub
        If CheckDataMonth() = True Then
            If SaveDataMonth() = True Then
                Me.lbMsgMM.Text = "此次设备月保养成功!"

                LoadMaintenanceMonthEdit()
            End If
        End If
    End Sub

    Private Sub btnMonExit_Click(sender As Object, e As EventArgs) Handles btnMonExit.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' 季保养保存
    ''' </summary>
    Private Sub btnQuaSave_Click(sender As Object, e As EventArgs) Handles btnQuaSave.Click
        If Me.dgvMaintenanceQ.RowCount < 1 Then Exit Sub
        If CheckDataQuarter() = True Then
            If SaveDataQuarter() = True Then

                Me.lbMsgQua.Text = "此次设备季保养成功!"
                LoadMaintenanceQuarterEdit()
            End If
        End If
    End Sub

    Private Sub btnQuaExit_Click(sender As Object, e As EventArgs) Handles btnQuaExit.Click
        Me.Close()
    End Sub

    Private Sub cbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYear.SelectedIndexChanged
        If Me.cbYear.SelectedItem.ToString() <> "" Then
            Me.lbYear.Text = Me.cbYear.SelectedItem.ToString
            Me.lbYear2.Text = Me.cbYear.SelectedItem.ToString
            Me.lbYear3.Text = Me.cbYear.SelectedItem.ToString
            LoadMaintenanceMonth()
            LoadMaintenanceQuarter()
        End If
    End Sub
#End Region
#Region "DataGridView 事件"
    Private Sub dgvMaintenanceM_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMaintenanceM.CellContentClick
        If Me.dgvMaintenanceM.CurrentRow Is Nothing OrElse Me.dgvMaintenanceM.RowCount < 1 Then Exit Sub

        If e.ColumnIndex = 3 OrElse e.ColumnIndex = 4 Then

            Select Case e.ColumnIndex
                Case 3
                    Me.dgvMaintenanceM.Rows(e.RowIndex).Cells(4).Value = False
                Case Else
                    Me.dgvMaintenanceM.Rows(e.RowIndex).Cells(3).Value = False
            End Select
        End If
    End Sub

    Private Sub dgvMaintenanceQ_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMaintenanceQ.CellContentClick
        If Me.dgvMaintenanceQ.CurrentRow Is Nothing OrElse Me.dgvMaintenanceQ.RowCount < 1 Then Exit Sub

        If e.ColumnIndex = 3 OrElse e.ColumnIndex = 4 Then

            Select Case e.ColumnIndex
                Case 3
                    Me.dgvMaintenanceQ.Rows(e.RowIndex).Cells(4).Value = False
                Case Else
                    Me.dgvMaintenanceQ.Rows(e.RowIndex).Cells(3).Value = False
            End Select
        End If
    End Sub

    Private Sub dgvMaintenanceMonth_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvMaintenanceMonth.CellMouseDown
        If Me.dgvMaintenanceMonth.CurrentRow Is Nothing OrElse Me.dgvMaintenanceMonth.RowCount < 1 Then Exit Sub

        If e.ColumnIndex > 1 AndAlso e.RowIndex > -1 Then
            Dim month As String = Nothing
            month = (e.ColumnIndex - 1).ToString

            LoadMaintenanceMonthRecord(month)
        End If
    End Sub

    Private Sub dgvMaintenanceQuarter_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvMaintenanceQuarter.CellMouseDown
        If Me.dgvMaintenanceQuarter.CurrentRow Is Nothing OrElse Me.dgvMaintenanceQuarter.RowCount < 1 Then Exit Sub

        If e.ColumnIndex > 1 AndAlso e.RowIndex > -1 Then
            Dim quarter As String = Nothing
            quarter = (e.ColumnIndex - 1).ToString

            LoadMaintenanceQuarterRecord(quarter)
        End If
    End Sub
#End Region
#Region "自定义函数"

    ''' <summary>
    ''' 加载月保养记录表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMaintenanceMonth()
        Try
            Dim o_strSql As New StringBuilder
            Dim dt As New DataTable
            o_strSql.Append("SELECT Id,MaintenanceProject,[1] as M1,[2] as M2,[3] as M3,[4] as M4,[5] as M5,[6] as M6,[7] as M7,[8] as M8,[9] as M9,[10] as M10,[11] as M11,[12] as M12  ")
            o_strSql.Append(" FROM ( SELECT a.Id,a.MaintenanceProject,case when b.Status='O' then '√' else '×' END AS [Status], b.Months as [DD] FROM m_AssetMaintenanceType_t a ")
            o_strSql.Append(" inner join  m_AssetMaintenanceMonth_t b on b.MaintenanceProject=a.MaintenanceProject ")
            o_strSql.Append(String.Format(" left join m_Users_t c on c.UserID=b.CreateUserID  where a.AssetName=N'{0}'", Me.txtAssetName.Text.Trim))
            o_strSql.Append(String.Format(" and  b.AssetNo=N'{0}' AND  b.Year = '{1}' )AS T ", Me.txtAssetNo.Text.Trim, Me.lbYear.Text))
            o_strSql.Append(" PIVOT(MAX([Status]) FOR [DD] IN([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12]) ) AS D ")
            'order by D.Id asc
            '串接保养人
            o_strSql.Append("  UNION ALL  SELECT 50000, N'保养人签名' AS MaintenanceProject,")
            o_strSql.Append(" CASE WHEN Months='1' THEN UserName else '' end M1, CASE WHEN Months='2' THEN UserName else '' end M2,")
            o_strSql.Append(" CASE WHEN Months='3' THEN UserName else '' end M3, CASE WHEN Months='4' THEN UserName else '' end M4,")
            o_strSql.Append(" CASE WHEN Months='5' THEN UserName else '' end M5,   CASE WHEN Months='6' THEN UserName else '' end M6,")
            o_strSql.Append(" CASE WHEN Months='7' THEN UserName else '' end M7, CASE WHEN Months='8' THEN UserName else '' end M8, ")
            o_strSql.Append(" CASE WHEN Months='9' THEN UserName else '' end M9, CASE WHEN Months='10' THEN UserName else '' end M10,")
            o_strSql.Append(" CASE WHEN Months='11' THEN UserName else '' end M11, CASE WHEN Months='12' THEN UserName else '' end M12")
            o_strSql.Append(" FROM (  SELECT  b.Months ,c.UserName FROM m_AssetMaintenanceType_t a    inner join   m_AssetMaintenanceMonth_t b on b.MaintenanceProject=a.MaintenanceProject ")
            o_strSql.Append(String.Format(" left join m_Users_t c on c.UserID=b.CreateUserID where a.AssetName=N'{0}' and  b.AssetNo=N'{1}' AND ", Me.txtAssetName.Text, Me.txtAssetNo.Text))
            o_strSql.Append(String.Format(" b.Year = '{0}' group by b.Months,c.UserName) AS t   order by ID ASC", Me.lbYear.Text))
            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                Me.dgvMaintenanceMonth.DataSource = dt
            Else
                ClearDataGridView(Me.dgvMaintenanceMonth)
                ClearDataGridView(Me.dgvMonthRecord)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "LoadMaintenanceMonth()", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 加载季保养记录表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMaintenanceQuarter()
        Try
            Dim o_strSql As New StringBuilder
            Dim dt As New DataTable
            o_strSql.Append("SELECT ID,MaintenanceProject,[1] as Q1,[2] as Q2,[3] as Q3,[4] as Q4  ")
            o_strSql.Append("  FROM ( SELECT a.Id,a.MaintenanceProject,case when b.Status='O' then '√' else '×' END AS [Status], b.Quarter as [DD] ")
            o_strSql.Append("  FROM m_AssetMaintenanceType_t a  inner join m_AssetMaintenanceQuarter_t b on b.MaintenanceProject=a.MaintenanceProject  ")
            o_strSql.Append(" left join m_Users_t c on c.UserID=b.CreateUserID ")
            o_strSql.Append(String.Format("  where a.AssetName=N'{0}' and  b.AssetNo=N'{1}' AND   ", Me.txtAssetName.Text, Me.txtAssetNo.Text))
            o_strSql.Append(String.Format("     b.Year = '{0}' )AS T  ", Me.lbYear.Text))
            o_strSql.Append("  PIVOT(MAX([Status]) FOR [DD] IN([1],[2],[3],[4]) ) AS D ")
            'order by D.Id asc 

            '串接保养人
            o_strSql.Append(" UNION ALL SELECT 5000,N'保养人签名' AS MaintenanceProject, CASE WHEN Quarter='1' THEN UserName else '' end Q1,")
            o_strSql.Append(" CASE WHEN Quarter='2' THEN UserName else '' end Q2,CASE WHEN Quarter='3' THEN UserName else '' end Q3,")
            o_strSql.Append(" CASE WHEN Quarter='4' THEN UserName else '' end Q4  FROM (  SELECT  b.Quarter ,c.UserName")
            o_strSql.Append(" FROM m_AssetMaintenanceType_t a  right join   m_AssetMaintenanceQuarter_t b on b.MaintenanceProject=a.MaintenanceProject")
            o_strSql.Append(String.Format("   left join m_Users_t c on c.UserID=b.CreateUserID  where a.AssetName=N'{0}' and  b.AssetNo=N'{1}' AND", Me.txtAssetName.Text, Me.txtAssetNo.Text))
            o_strSql.Append(String.Format("  b.Year  = '{0}' group by b.Quarter,c.UserName) AS t   order by ID ASC", Me.lbYear.Text))

            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                Me.dgvMaintenanceQuarter.DataSource = dt
            Else
                ClearDataGridView(Me.dgvMaintenanceQuarter)
                ClearDataGridView(Me.dgvQuarterRecord)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "LoadMaintenanceMonth()", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 加载当月保养待记录
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMaintenanceMonthEdit()
        Try
            Dim o_strSql As New StringBuilder
            Dim dt As New DataTable
            o_strSql.Append("SELECT row_number() OVER(ORDER BY  ID) idx,AssetName,MaintenanceProject,0 as IsOk,0 as IsNg,'' as Remark ")
            o_strSql.Append(String.Format("  FROM m_AssetMaintenanceType_t WHERE AssetName =N'{0}' and IsMpMonth=1   ORDER BY id ASC", Me.txtAssetName.Text.Trim))

            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                Me.dgvMaintenanceM.DataSource = dt

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "BindData()", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 加载当季保养待记录
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMaintenanceQuarterEdit()
        Try
            Dim o_strSql As New StringBuilder
            Dim dt As New DataTable
            o_strSql.Append("SELECT row_number() OVER(ORDER BY  ID) idx,AssetName,MaintenanceProject,0 as IsOk,0 as IsNg,'' as Remark ")
            o_strSql.Append(String.Format("  FROM m_AssetMaintenanceType_t WHERE AssetName =N'{0}' and IsMpQuarter=1   ORDER BY id ASC", Me.txtAssetName.Text.Trim))

            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                Me.dgvMaintenanceQ.DataSource = dt

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "BindData()", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 清空DataGridView 数据
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <remarks></remarks>
    Private Sub ClearDataGridView(ByVal dgv As DataGridView)
        Dim dt As New DataTable
        dt = CType(dgv.DataSource, DataTable)
        If Not dt Is Nothing Then
            dt.Rows.Clear()
            dgv.DataSource = dt
        End If
    End Sub


    ''' <summary>
    ''' 获得选择的月份的保养记录
    ''' </summary>
    ''' <param name="month"></param>
    ''' <remarks></remarks>
    Private Sub LoadMaintenanceMonthRecord(ByVal month As String)
        Try
            Dim o_strSql As New StringBuilder
            Dim dt As New DataTable
            o_strSql.Append(" SELECT a.MaintenanceProject,a.Months,CASE WHEN a.Status='O' then 'OK' else 'NG' END Status,a.CreateTime,b.UserName,a.Remark FROM m_AssetMaintenanceMonth_t a")
            o_strSql.Append(String.Format("  left join m_Users_t b on b.UserID=a.CreateUserID WHERE AssetNo=N'{0}' ", Me.txtAssetNo.Text.Trim))
            o_strSql.Append(String.Format(" and  a.Year ='{0}'  and a.Months='{1}'", Me.lbYear.Text, month))
            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                Me.dgvMonthRecord.DataSource = dt
            Else
                ClearDataGridView(Me.dgvMonthRecord)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "LoadMaintenanceMonthRecord()", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 获得选择的季度的保养记录
    ''' </summary>
    ''' <param name="quarter"></param>
    ''' <remarks></remarks>
    Private Sub LoadMaintenanceQuarterRecord(ByVal quarter As String)
        Try
            Dim o_strSql As New StringBuilder
            Dim dt As New DataTable
            o_strSql.Append(" SELECT a.MaintenanceProject,a.Quarter,CASE WHEN a.Status='O' then 'OK' else 'NG' END Status,a.CreateTime,b.UserName,a.Remark FROM m_AssetMaintenanceQuarter_t a")
            o_strSql.Append(String.Format("  left join m_Users_t b on b.UserID=a.CreateUserID WHERE AssetNo=N'{0}' ", Me.txtAssetNo.Text.Trim))
            o_strSql.Append(String.Format(" and  a.Year ='{0}'  and a.Quarter='{1}'", Me.lbYear.Text, quarter))
            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                Me.dgvQuarterRecord.DataSource = dt
            Else

                ClearDataGridView(Me.dgvQuarterRecord)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "LoadMaintenanceQuarterRecord()", "sys")
        End Try
    End Sub


    ''' <summary>
    ''' 校验月保养数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckDataMonth() As Boolean

        '检验当月是否有保养
        If ExistMaintenanceToMonth() = True Then
            Me.lbMsgMM.Text = "当月已保养，请勿重复保养!"
            Return False
        End If

        '检验输入
        If InputCheckGridViewToMonth() = False Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 校验季保养数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckDataQuarter() As Boolean

        '检验当月是否有保养
        If ExistMaintenanceToQuarter() = True Then
            Me.lbMsgQua.Text = "当季已保养，请勿重复保养!"
            Return False
        End If

        '检验输入
        If InputCheckGridViewToQuarter() = False Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 校验当日保养DataGridView输入-月保养
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InputCheckGridViewToMonth() As Boolean
        Dim maintenanceProct As String = Nothing
        Dim IsOk As Boolean = False
        Dim IsNg As Boolean = False
        Me.dgvMaintenanceM.EndEdit()
        For Each Row As DataGridViewRow In Me.dgvMaintenanceM.Rows

            IsOk = CType(Row.Cells(3), DataGridViewCheckBoxCell).EditedFormattedValue
            IsNg = CType(Row.Cells(4), DataGridViewCheckBoxCell).EditedFormattedValue
            maintenanceProct = Row.Cells(2).Value.ToString
            If IsOk = False AndAlso IsNg = False Then
                Me.lbMsgMM.Text = "请维护保养项目：" & maintenanceProct

                Return False
            End If
            If IsNg = True AndAlso String.IsNullOrEmpty(Row.Cells(5).Value.ToString) Then
                Me.lbMsgMM.Text = "保养项目：" & maintenanceProct & "出现NG，备注为必填!"

                Return False
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' 校验当日保养DataGridView输入-季保养
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InputCheckGridViewToQuarter() As Boolean
        Dim maintenanceProct As String = Nothing
        Dim IsOk As Boolean = False
        Dim IsNg As Boolean = False
        Me.dgvMaintenanceQ.EndEdit()
        For Each Row As DataGridViewRow In Me.dgvMaintenanceQ.Rows

            IsOk = CType(Row.Cells(3), DataGridViewCheckBoxCell).EditingCellFormattedValue
            IsNg = CType(Row.Cells(4), DataGridViewCheckBoxCell).EditingCellFormattedValue
            maintenanceProct = Row.Cells(2).Value.ToString
            If IsOk = False AndAlso IsNg = False Then
                Me.lbMsgQua.Text = "请维护保养项目：" & maintenanceProct

                Return False
            End If

            If IsNg = True AndAlso String.IsNullOrEmpty(Row.Cells(5).Value.ToString) Then

                Me.lbMsgQua.Text = "保养项目：" & maintenanceProct & "出现NG，备注为必填!"
                Return False
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' 检验当月是否有保养
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExistMaintenanceToMonth() As Boolean
        Try
            Dim strSql As String = Nothing
            Dim iRow As Integer = 0
            strSql = String.Format("SELECT * FROM m_AssetMaintenanceMonth_t WHERE AssetNo='{0}' AND Months=cast(datepart(MONTH,getdate()) as varchar(10)) and Year = cast(datepart(YEAR,getdate()) as varchar(10))  ", Me.txtAssetNo.Text.Trim)
            iRow = DbOperateUtils.GetRowsCount(strSql)
            If iRow > 0 Then
                Return True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "ExistMaintenanceToMonth()", "sys")
        End Try
        Return False
    End Function

    ''' <summary>
    ''' 检验当日是否有保养
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExistMaintenanceToQuarter() As Boolean
        Try
            Dim strSql As String = Nothing
            Dim iRow As Integer = 0
            strSql = String.Format("SELECT * FROM m_AssetMaintenanceQuarter_t WHERE AssetNo='{0}' and  Quarter=cast(datepart(QUARTER,getdate()) as varchar(10)) and Year = cast(datepart(YEAR,getdate()) as varchar(10))   ", Me.txtAssetNo.Text.Trim)
            iRow = DbOperateUtils.GetRowsCount(strSql)
            If iRow > 0 Then
                Return True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "ExistMaintenanceToQuarter()", "sys")
        End Try
        Return False
    End Function

    ''' <summary>
    ''' 保存月保养记录
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveDataMonth() As Boolean

        Try
            Dim dt As New DataTable
            Me.dgvMaintenanceM.EndEdit()
            dt = CType(Me.dgvMaintenanceM.DataSource, DataTable)
            For Each row As DataRow In dt.Rows
                SaveDataRowToMonth(row)
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "SaveDataMonth()", "sys")
        End Try

        Return True
    End Function

    ''' <summary>
    ''' 保存月保养记录
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveDataQuarter() As Boolean

        Try
            Dim dt As New DataTable
            Me.dgvMaintenanceQ.EndEdit()
            dt = CType(Me.dgvMaintenanceQ.DataSource, DataTable)
            For Each row As DataRow In dt.Rows
                SaveDataRowToQuarter(row)
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "SaveDataQuarter()", "sys")
        End Try

        Return True
    End Function

    ''' <summary>
    ''' 保存每行记录-月保养
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Private Sub SaveDataRowToMonth(ByVal row As DataRow)
        Try
            Dim AssetNo As String = Nothing
            Dim MaintenanceProject As String = Nothing
            Dim Status As String = Nothing
            Dim isOK As Boolean = False
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim o_strSql As New StringBuilder
            If Not row Is Nothing Then
                If row("IsOk").ToString = "1" Then
                    Status = "O"
                Else
                    Status = "X"
                End If
                o_strSql.Append("INSERT INTO m_AssetMaintenanceMonth_t(AssetNo,MaintenanceProject,Months,Status,Remark,CreateTime,CreateUserID,YEAR)")
                o_strSql.Append(String.Format(" VALUES(N'{0}',N'{1}',CAST( datepart(MONTH,GETDATE()) as varchar(10)),N'{2}',N'{3}',GETDATE(),N'{4}','{5}')",
                                              Me.txtAssetNo.Text.Trim, row("MaintenanceProject").ToString, Status, row("Remark").ToString, UserID, lbYear.Text))

                DbOperateUtils.ExecSQL(o_strSql.ToString)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "SaveDataRowToMonth()", "sys")
        End Try

    End Sub

    ''' <summary>
    ''' 保存每行记录-季保养
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Private Sub SaveDataRowToQuarter(ByVal row As DataRow)
        Try
            Dim AssetNo As String = Nothing
            Dim MaintenanceProject As String = Nothing
            Dim Status As String = Nothing
            Dim isOK As Boolean = False
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim o_strSql As New StringBuilder
            If Not row Is Nothing Then
                If row("IsOk").ToString = "1" Then
                    Status = "O"
                Else
                    Status = "X"
                End If
                o_strSql.Append("INSERT INTO m_AssetMaintenanceQuarter_t(AssetNo,MaintenanceProject,Quarter,Status,Remark,CreateTime,CreateUserID,YEAR)")
                o_strSql.Append(String.Format(" VALUES(N'{0}',N'{1}',CAST( datepart(quarter,GETDATE()) as varchar(10)),N'{2}',N'{3}',GETDATE(),N'{4}','{5}')",
                                              Me.txtAssetNo.Text.Trim, row("MaintenanceProject").ToString, Status, row("Remark").ToString, UserID, lbYear.Text))

                DbOperateUtils.ExecSQL(o_strSql.ToString)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "SaveDataRowToQuarter()", "sys")
        End Try

    End Sub

    ''' <summary>
    ''' 加载年份
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadYaer()
        Dim i As Integer = Now.Year
        Dim j As Integer
        For j = i - 3 To i
            Me.cbYear.Items.Add(j.ToString)
        Next
        Me.cbYear.SelectedIndex = Me.cbYear.Items.Count - 1
    End Sub

#End Region

    Private Sub btnSpecMonSave_Click(sender As Object, e As EventArgs) Handles btnSpecMonSave.Click
        If Me.dgvMaintenanceM.RowCount < 1 Then Exit Sub

        If String.IsNullOrEmpty(txtProcessMonth.Text) Then
            Me.lbMsgMM.Text = "错误,请先输入此次保养月份!"
            Exit Sub
        Else
            If Val(txtProcessMonth.Text) = 0 Then
                Me.lbMsgMM.Text = "错误,输入此次保养月份的格式错误，必须为数字!"
                Exit Sub
            End If
        End If
        If CheckDataMonthSpec() = True Then
            If SaveDataMonthSpec() = True Then
                Me.lbMsgMM.Text = "此次设备月保养成功!"
                ' Me._MonthIsExist = True
                LoadMaintenanceMonthEdit()
            End If
        End If
    End Sub

    Private Function SaveDataMonthSpec() As Boolean
        Try
            Dim dt As New DataTable
            Me.dgvMaintenanceM.EndEdit()
            dt = CType(Me.dgvMaintenanceM.DataSource, DataTable)
            For Each row As DataRow In dt.Rows
                SaveDataRowToMonthSpec(row)
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquMaintenanceMonth", "SaveDataMonthSpec", "Equ")
        End Try

        Return True
    End Function

    Private Sub SaveDataRowToMonthSpec(ByVal row As DataRow)
        Try
            Dim AssetNo As String = Nothing
            Dim MaintenanceProject As String = Nothing
            Dim Status As String = Nothing
            Dim isOK As Boolean = False
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim o_strSql As New StringBuilder
            If Not row Is Nothing Then
                If row("IsOk").ToString = "1" Then
                    Status = "O"
                Else
                    Status = "X"
                End If
                o_strSql.Append("INSERT INTO m_AssetMaintenanceMonth_t(AssetNo,MaintenanceProject,Months,Status,Remark,CreateTime,CreateUserID,YEAR)")
                o_strSql.Append(String.Format(" VALUES(N'{0}',N'{1}', " & Val(Me.txtProcessMonth.Text) & ",N'{2}',N'{3}',GETDATE(),N'{4}','{5}')",
                                              Me.txtAssetNo.Text.Trim, row("MaintenanceProject").ToString, Status, row("Remark").ToString, UserID, Me.lbYear.Text))

                DbOperateUtils.ExecSQL(o_strSql.ToString)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "SaveDataRowToMonthSpec", "Equ")
        End Try
    End Sub

    Private Sub btnSpecQuaSave_Click(sender As Object, e As EventArgs) Handles btnSpecQuaSave.Click
        If Me.dgvMaintenanceQ.RowCount < 1 Then Exit Sub
        If CheckDataQuarterSpec() = True Then
            If SaveDataQuarterSpec() = True Then
                Me.lbMsgQua.Text = "此次设备季保养成功!"
                ' Me._QuarterIsExist = True
                LoadMaintenanceQuarterEdit()
            End If
        End If
    End Sub

    Private Function SaveDataQuarterSpec() As Boolean
        Try
            Dim dt As New DataTable
            Me.dgvMaintenanceQ.EndEdit()
            dt = CType(Me.dgvMaintenanceQ.DataSource, DataTable)
            For Each row As DataRow In dt.Rows
                SaveDataRowToQuarterSpec(row)
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "SaveDataQuarterSpec", "Equ")
        End Try
        Return True
    End Function

    Private Sub SaveDataRowToQuarterSpec(ByVal row As DataRow)
        Try
            Dim AssetNo As String = Nothing
            Dim MaintenanceProject As String = Nothing
            Dim Status As String = Nothing
            Dim isOK As Boolean = False
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim o_strSql As New StringBuilder
            If Not row Is Nothing Then
                If row("IsOk").ToString = "1" Then
                    Status = "O"
                Else
                    Status = "X"
                End If
                o_strSql.Append("INSERT INTO m_AssetMaintenanceQuarter_t(AssetNo,MaintenanceProject,Quarter,Status,Remark,CreateTime,CreateUserID,YEAR)")
                o_strSql.Append(String.Format(" VALUES(N'{0}',N'{1}', '" & Val(Me.txtQuarter.Text.Trim) & "',N'{2}',N'{3}',GETDATE(),N'{4}','{5}')",
                                              Me.txtAssetNo.Text.Trim, row("MaintenanceProject").ToString, Status, row("Remark").ToString, UserID, lbYear.Text))

                DbOperateUtils.ExecSQL(o_strSql.ToString)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "SaveDataRowToQuarterSpec", "Equ")
        End Try
    End Sub

    Private Function CheckDataQuarterSpec() As Boolean

        '检验当季是否有保养
        If ExistMaintenanceToQuarterSpec() Then
            Me.lbMsgQua.Text = "当季已保养，请勿重复保养!"
            Return False
        End If

        '不允许提前维护季度
        If Val(Me.txtQuarter.Text) > EquManageCommon.GetQuarter() Then
            Me.lbMsgQua.Text = "不允许提前维护季度!"
            Return False
        End If

        '检验输入
        If InputCheckGridViewToQuarter() = False Then
            Return False
        End If

        Return True
    End Function

    Private Function ExistMaintenanceToQuarterSpec() As Boolean
        Try
            Dim strSql As String = Nothing
            Dim iRow As Integer = 0
            strSql = String.Format("SELECT * FROM m_AssetMaintenanceQuarter_t WHERE AssetNo='{0}' AND YEAR = '" & lbYear3.Text &
                                   "' AND  Quarter=" & Val(Me.txtQuarter.Text), Me.txtAssetNo.Text.Trim)
            iRow = DbOperateUtils.GetRowsCount(strSql)
            If iRow > 0 Then
                Return True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquMaintenanceMonth", "ExistMaintenanceToQuarterSpec()", "sys")
        End Try
        Return False
    End Function

    'Private Function myQuarter() As Int16
    '    Dim myMonth As Int16 = Now.Month

    '    Select Case myMonth
    '        Case 1, 2, 3
    '            myQuarter = 1
    '        Case 4, 5, 6
    '            myQuarter = 2
    '        Case 7, 8, 9
    '            myQuarter = 3
    '        Case 10, 11, 12
    '            myQuarter = 4
    '    End Select
    'End Function

    Private Function CheckDataMonthSpec() As Boolean
        '检验当月是否有保养
        If ExistMaintenanceToMonthSpec() Then
            Me.lbMsgMM.Text = "当月已保养，请勿重复保养!"
            Return False
        End If

        '检验输入
        If InputCheckGridViewToMonth() = False Then
            Return False
        End If

        Return True
    End Function

    Private Function ExistMaintenanceToMonthSpec() As Boolean
        Try
            Dim strSql As String = Nothing
            Dim iRow As Integer = 0
            strSql = String.Format(" SELECT * FROM m_AssetMaintenanceMonth_t WHERE AssetNo='{0}' AND YEAR = '" & lbYear3.Text &
                                   "' AND Months= '" & Val(txtProcessMonth.Text) & "' ", Me.txtAssetNo.Text.Trim)
            iRow = DbOperateUtils.GetRowsCount(strSql)
            If iRow > 0 Then
                Return True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceMonth", "ExistMaintenanceToMonthSpec", "Equ")
        End Try
        Return False
    End Function


End Class