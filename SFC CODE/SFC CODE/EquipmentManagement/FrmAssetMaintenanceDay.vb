
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

Public Class FrmAssetMaintenanceDay


#Region "构造函数"
    ''' <summary>
    ''' 构造
    ''' </summary>
    ''' <param name="AssetNo">设备编码</param>
    ''' <param name="AssetName">设备名称</param>
    ''' <param name="Model">型号</param>
    ''' <remarks></remarks>
    Sub New(ByVal AssetNo As String, ByVal AssetName As String, ByVal Model As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        Me.txtAssetName.Text = AssetName
        Me.txtAssetNameToDay.Text = AssetName
        Me.txtAssetNo.Text = AssetNo
        Me.txtModel.Text = Model
    End Sub
#End Region
#Region "窗体事件"
    ''' <summary>
    ''' 初始加载窗体
    ''' </summary>
    Private Sub FrmAssetMaintenanceDay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtPickerCurrentDay.Value = Date.Now
        dtpMonths.Value = Date.Now
        Me.lbMonths.Text = Now.ToString("yyyy-MM")
        LoadMaintenEveryDay()
        LoadMainenEverDayUser()
        GetControlright("FrmEquipment")
    End Sub

    Public Sub GetControlright(ByVal Apformid As String)
        Dim lsSQL As String = "select ButtonID from m_Logtree_t a left join m_userright_t b on a.Tkey=b.tkey where b.userid='" & SysCheckData.SysMessageClass.UseId & "' AND a.Formid=(select apid from m_SysapForm_t where Apformid='" & Apformid & "' ) and a.listy='N' and a.Tkey ='m131a5_'"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                btnSpecSave.Enabled = True
            Else
                btnSpecSave.Enabled = False
            End If
        End Using
    End Sub

    ''' <summary>
    ''' 页签切换
    ''' </summary>
    Private Sub tcMaintenanceDay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcMaintenanceDay.SelectedIndexChanged
        If tcMaintenanceDay.SelectedIndex = 1 Then
            LoadMaintenToDay()
        Else
            LoadMaintenEveryDay()
            LoadMainenEverDayUser()
        End If
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Me.dgvMaintenToDay.RowCount < 1 Then Exit Sub
        If CheckData() = True Then
            If SaveData() = True Then
                Me.lbMsg.Text = "此次设备保养成功!"
                LoadMaintenToDay()
            End If
        End If
    End Sub

    ''' <summary>
    ''' 查找
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Not String.IsNullOrEmpty(Me.dtpMonths.Text) Then
            Me.lbMonths.Text = Me.dtpMonths.Text
            LoadMaintenEveryDay()
            LoadMainenEverDayUser()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
#End Region


#Region "DataGridView事件"


    Private Sub dgvMaintenanceEveryDay_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvMaintenanceEveryDay.CellFormatting

        If e.ColumnIndex = 0 Then
            Me.dgvMaintenanceEveryDay.Columns(e.ColumnIndex).Width = 250
        Else
            Me.dgvMaintenanceEveryDay.Columns(e.ColumnIndex).Width = 33

            If e.ColumnIndex = GetNowToDays() Then
                e.CellStyle.BackColor = Color.Yellow
            End If
        End If
    End Sub
    Private Sub dgvMaintenToDay_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMaintenToDay.CellContentClick
        If Me.dgvMaintenToDay.CurrentRow Is Nothing OrElse Me.dgvMaintenToDay.RowCount < 1 Then Exit Sub

        If e.ColumnIndex = 3 OrElse e.ColumnIndex = 4 OrElse e.ColumnIndex = 5 Then

            Select Case e.ColumnIndex
                Case 3
                    Me.dgvMaintenToDay.Rows(e.RowIndex).Cells(4).Value = False
                    Me.dgvMaintenToDay.Rows(e.RowIndex).Cells(5).Value = False
                Case 4
                    Me.dgvMaintenToDay.Rows(e.RowIndex).Cells(3).Value = False
                    Me.dgvMaintenToDay.Rows(e.RowIndex).Cells(5).Value = False
                Case Else
                    Me.dgvMaintenToDay.Rows(e.RowIndex).Cells(3).Value = False
                    Me.dgvMaintenToDay.Rows(e.RowIndex).Cells(4).Value = False
            End Select
        End If
    End Sub

    Private Sub dgvMaintenanceEveryDay_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvMaintenanceEveryDay.CellMouseDown
        If Me.dgvMaintenanceEveryDay.CurrentRow Is Nothing OrElse Me.dgvMaintenanceEveryDay.RowCount < 1 Then Exit Sub

        If e.ColumnIndex > 0 AndAlso e.RowIndex > -1 Then
            Dim day As String = Nothing
            day = Me.lbMonths.Text
            'day = Now.ToString("yyyy-MM")
            If e.ColumnIndex < 10 Then
                day = day + "-0" + e.ColumnIndex.ToString
            Else
                day = day + "-" + e.ColumnIndex.ToString
            End If
            LoadMainanceEverDayRecord(day)
        End If

    End Sub

    Private Sub dgvMaintenanceEverDayUser_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvMaintenanceEverDayUser.CellMouseDown
        If Me.dgvMaintenanceEverDayUser.CurrentRow Is Nothing OrElse Me.dgvMaintenanceEverDayUser.RowCount < 1 Then Exit Sub

        If e.ColumnIndex > -1 AndAlso e.RowIndex > -1 Then


            Dim day As String = Nothing
            day = Me.dgvMaintenanceEverDayUser.Rows(e.RowIndex).Cells(0).Value.ToString
       
            LoadMainanceEverDayRecord(day)
        End If
    End Sub
#End Region


#Region "自定义方法"
    ''' <summary>
    '''加载每日保养记录表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMaintenEveryDay()
        Try
            Dim o_strSql As New StringBuilder
            Dim dt As New DataTable
            If String.IsNullOrEmpty(Me.lbMonths.Text) Then
                Exit Sub
            End If

            dt = DbOperateUtils.GetDataTable(String.Format("exec GetAssetMaintenanceByDay N'{0}',N'{1}','{2}'", Me.txtAssetNo.Text, Me.txtAssetName.Text, Me.lbMonths.Text))
            If dt.Rows.Count > 0 Then
                Me.dgvMaintenanceEveryDay.DataSource = dt
                Me.dgvMaintenanceEveryDay.Columns(0).HeaderCell.Value = "保养项目"
            Else
                ClearDataGridView(Me.dgvMaintenanceEveryDay)
                ClearDataGridView(Me.dgvMainanceRecord)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceDay", "LoadMaintenEveryDay()", "sys")
        End Try

    End Sub

    ''' <summary>
    ''' 获取保养日期
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMainenEverDayUser()
        Try
            Dim o_strSql As New StringBuilder
            Dim day As String
            Dim dt As New DataTable
            If String.IsNullOrEmpty(Me.lbMonths.Text) Then
                Exit Sub
            End If
            o_strSql.Append("select CONVERT(varchar(10), a.Maintenancetime,121)AS Maintenancetime ,b.UserName from m_AssetMaintenanceDay_t a left join ")
            o_strSql.Append(String.Format(" m_Users_t b on b.UserID=a.CreateUserID WHERE a.AssetNo='{0}' and CONVERT(varchar(7), a.Maintenancetime,121)='{1}'", Me.txtAssetNo.Text, Me.lbMonths.Text))
            o_strSql.Append(" group by b.UserName,CONVERT(varchar(10), a.Maintenancetime,121) ")

            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                Me.dgvMaintenanceEverDayUser.DataSource = dt
                day = Me.dgvMaintenanceEverDayUser.CurrentRow.Cells(0).Value.ToString
                LoadMainanceEverDayRecord(day)
            Else
                ClearDataGridView(Me.dgvMaintenanceEverDayUser)
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceDay", "LoadMainenEverDayUser()", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 获取某天的保养记录
    ''' </summary>
    ''' <param name="DayDate">YYYY-MM-DD</param>
    ''' <remarks></remarks>
    Private Sub LoadMainanceEverDayRecord(ByVal DayDate As String)
        Try
            Dim o_strSql As New StringBuilder
            Dim dt As New DataTable
            o_strSql.Append("SELECT  a.MaintenanceProject,CASE WHEN a.Status='O' THEN 'OK' when a.Status='X' THEN 'NG' else N'机台未使用' END Status, ")
            o_strSql.Append(" a.Maintenancetime,b.UserName,a.Remark from m_AssetMaintenanceDay_t  a left join m_Users_t b on b.UserID=a.CreateUserID")
            o_strSql.Append(String.Format(" WHERE AssetNo='{0}' and CONVERT(varchar(10), Maintenancetime,121)='{1}' ", Me.txtAssetNo.Text.Trim, DayDate))

            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                Me.dgvMainanceRecord.DataSource = dt
            Else
                ClearDataGridView(Me.dgvMainanceRecord)
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceDay", "LoadMainanceEverDayRecord()", "sys")
        End Try
    End Sub

    ''' <summary>
    '''加载当日保养数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMaintenToDay()
        Try
            Dim o_strSql As New StringBuilder
            Dim dt As New DataTable
            o_strSql.Append("SELECT row_number() OVER(ORDER BY  ID) idx,AssetName,MaintenanceProject,0 as IsOk,0 as IsNg,0 AS IsNotUsed,'' as  Remark  ")
            o_strSql.Append(String.Format("  FROM m_AssetMaintenanceType_t WHERE AssetName =N'{0}' and IsMpDay=1   ORDER BY id ASC", Me.txtAssetNameToDay.Text.Trim))

            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                Me.dgvMaintenToDay.DataSource = dt

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceDay", "BindData()", "sys")
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
    ''' 校验数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckData() As Boolean

        '检验当日是否有保养
        If ExistMaintenanceCurrentDaySystem() = True Then
            Me.lbMsg.Text = "当日已保养,请勿重复保养!"
            Return False
        End If

        '检验输入
        If InputCheckGridView() = False Then
            Return False
        End If

        Return True
    End Function
    ''' <summary>
    ''' 校验当日保养DataGridView输入
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InputCheckGridView() As Boolean
        Dim maintenanceProct As String = Nothing
        Dim IsOk As Boolean = False
        Dim IsNg As Boolean = False
        Dim IsNotUsed As Boolean = False
        Me.dgvMaintenToDay.EndEdit()
        For Each Row As DataGridViewRow In Me.dgvMaintenToDay.Rows


            IsOk = CType(Row.Cells(3), DataGridViewCheckBoxCell).EditedFormattedValue
            IsNg = CType(Row.Cells(4), DataGridViewCheckBoxCell).EditedFormattedValue
            IsNotUsed = CType(Row.Cells(5), DataGridViewCheckBoxCell).EditedFormattedValue

            maintenanceProct = Row.Cells(2).Value.ToString
            If IsOk = False AndAlso IsNg = False AndAlso IsNotUsed = False Then

                Me.lbMsg.Text = "请维护保养项目：" & maintenanceProct
                Return False
            End If

            If IsNg = True AndAlso String.IsNullOrEmpty(Row.Cells(6).Value.ToString) Then

                Me.lbMsg.Text = "请填写保养项目：" & maintenanceProct & "出现NG，备注为必填!"
                Return False
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' 保存保养记录
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveData() As Boolean

        Try
            Dim dt As New DataTable
            Me.dgvMaintenToDay.EndEdit()
            dt = CType(Me.dgvMaintenToDay.DataSource, DataTable)
            For Each row As DataRow In dt.Rows
                SaveDataRow(row)
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceDay", "SaveData()", "sys")
        End Try

        Return True
    End Function

    ''' <summary>
    ''' 保存每行记录
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Private Sub SaveDataRow(ByVal row As DataRow)
        Dim AssetNo As String = Nothing
        Dim MaintenanceProject As String = Nothing
        Dim Status As String = Nothing
        Dim isOK As Boolean = False
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        Dim o_strSql As New StringBuilder

        If Not row Is Nothing Then
            If row("IsOk").ToString = "1" Then
                Status = "O"
            ElseIf row("IsNg").ToString = "1" Then
                Status = "X"
            Else
                Status = "I"
            End If

            o_strSql.Append("INSERT INTO m_AssetMaintenanceDay_t(AssetNo ,MaintenanceProject,Status,Remark,CreateTime,CreateUserID,Maintenancetime)")
            o_strSql.Append(String.Format(" VALUES(N'{0}',N'{1}',N'{2}',N'{3}',GETDATE(),N'{4}',GETDATE())",
                                          Me.txtAssetNo.Text.Trim, row("MaintenanceProject").ToString, Status, row("Remark").ToString, UserID))

            DbOperateUtils.ExecSQL(o_strSql.ToString)
        End If
    End Sub

    ''' <summary>
    ''' 获取当天日期的天
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNowToDays() As Integer
        Dim d As Integer
        d = CInt(Now.Day.ToString)
        Return d
    End Function
#End Region

    Private Sub btnSpecSave_Click(sender As Object, e As EventArgs) Handles btnSpecSave.Click
        If Me.dgvMaintenToDay.RowCount < 1 Then Exit Sub
        If CheckDataSpec() = True Then
            If SaveDataSpec() = True Then
                Me.lbMsg.Text = "此次设备保养成功!"
                ' Me._MaintenanceIsExist = True
                LoadMaintenToDay()
            End If
        End If
    End Sub

    Private Function SaveDataSpec() As Boolean
        Try
            Dim dt As New DataTable
            Me.dgvMaintenToDay.EndEdit()
            dt = CType(Me.dgvMaintenToDay.DataSource, DataTable)
            For Each row As DataRow In dt.Rows
                SaveDataRowSpec(row)
            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceDay", "SaveDataSpec", "Equ")
        End Try
        Return True
    End Function

    Private Sub SaveDataRowSpec(ByVal row As DataRow)
        Dim AssetNo As String = Nothing
        Dim MaintenanceProject As String = Nothing
        Dim Status As String = Nothing
        Dim isOK As Boolean = False
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        Dim o_strSql As New StringBuilder

        If Not row Is Nothing Then
            If row("IsOk").ToString = "1" Then
                Status = "O"
            ElseIf row("IsNg").ToString = "1" Then
                Status = "X"
            Else
                Status = "I"
            End If

            o_strSql.Append("INSERT INTO m_AssetMaintenanceDay_t(AssetNo ,MaintenanceProject,Status,Remark,CreateTime,CreateUserID,Maintenancetime)")
            o_strSql.Append(String.Format(" VALUES(N'{0}',N'{1}',N'{2}',N'{3}',getdate(),N'{4}','" & dtPickerCurrentDay.Value & "')",
                                          Me.txtAssetNo.Text.Trim, row("MaintenanceProject").ToString, Status, row("Remark").ToString, UserID))

            DbOperateUtils.ExecSQL(o_strSql.ToString)
        End If
    End Sub

    Private Function CheckDataSpec() As Boolean
         If ExistMaintenanceCurrentDay() = True Then
            Me.lbMsg.Text = String.Format("当日[{0}]已保养,请勿重复保养!", dtPickerCurrentDay.Value.ToShortDateString)
            Return False
        End If
        '检验输入
        If InputCheckGridView() = False Then
            Return False
        End If
        Return True
    End Function

    Private Function ExistMaintenanceCurrentDay() As Boolean
        Try
            Dim strSql As String = Nothing
            strSql = String.Format("SELECT 1 FROM m_AssetMaintenanceDay_t " &
                                   "WHERE AssetNo='{0}' AND convert(varchar(10),Maintenancetime,111) = convert(varchar(10),CAST('{1}' AS DATETIME),111) ",
                                   Me.txtAssetNo.Text.Trim, dtPickerCurrentDay.Value.ToShortDateString)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                Me.lbMsg.Text = "当日已保养!"
                Return True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceDay", "ExistMaintenanceCurrentDay", "Equ")
        End Try
        Return False
    End Function

    Private Function ExistMaintenanceCurrentDaySystem() As Boolean
        Try
            Dim strSql As String = Nothing
            strSql = String.Format("SELECT 1 FROM m_AssetMaintenanceDay_t " &
                                   "WHERE AssetNo='{0}' AND convert(varchar(10),Maintenancetime,111) = convert(varchar(10),getdate(),111) ",
                                   Me.txtAssetNo.Text.Trim)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                Me.lbMsg.Text = "当日已保养!"
                Return True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssetMaintenanceDay", "ExistMaintenanceCurrentDaySystem", "Equ")
        End Try
        Return False
    End Function

End Class