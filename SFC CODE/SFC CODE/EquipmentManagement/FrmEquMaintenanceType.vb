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


Public Class FrmEquMaintenanceType

#Region "枚举"
    Private Enum FormBtnonType
        Normal
        Add
        Modify
        Delete
        Save
        Undo
        Search
        Refresh
    End Enum

    Private Enum GridView
        AssetName
        MaintenanceProject
        IsMpDay
        IsMpMonth
        IsMpQuarter
        CreateTime
        CreateUserID
        Id
    End Enum
#End Region

#Region "属性"
#Region "当前状态"
    Private _ActivaStatus As String
    Public Property ActivaStatus() As String
        Get
            Return _ActivaStatus
        End Get

        Set(ByVal Value As String)
            _ActivaStatus = Value
        End Set
    End Property
#End Region


#End Region

#Region "窗体事件"
    Private Sub FrmAssetMaintenanceType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '绑定下拉
        LoadEquName()
        '加载数据
        BindData()
        '设置权限
        SetControlEnable(FormBtnonType.Normal)
    End Sub
#End Region

#Region "菜单事件"
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Me._ActivaStatus = FormBtnonType.Add.ToString
        SetControlEnable(FormBtnonType.Add)
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If Me.dgvMaintenanceType.RowCount < 1 OrElse Me.dgvMaintenanceType.CurrentCell Is Nothing Then
            Exit Sub
        End If
        Me._ActivaStatus = FormBtnonType.Modify.ToString
        SetControlEnable(FormBtnonType.Modify)
        Dim AssetName As String = Nothing
        Dim IsMpDay As Boolean = False
        Dim IsMpMonth As Boolean = False
        Dim IsMpQuarter As Boolean = False
        Dim MaintenanceProject As String = Nothing
        AssetName = Me.dgvMaintenanceType.CurrentRow.Cells(GridView.AssetName).Value.ToString
        IsMpDay = IIf(Me.dgvMaintenanceType.CurrentRow.Cells(GridView.IsMpDay).Value.ToString = "√", True, False)
        IsMpMonth = IIf(Me.dgvMaintenanceType.CurrentRow.Cells(GridView.IsMpMonth).Value.ToString = "√", True, False)
        IsMpQuarter = IIf(Me.dgvMaintenanceType.CurrentRow.Cells(GridView.IsMpQuarter).Value.ToString = "√", True, False)
        MaintenanceProject = Me.dgvMaintenanceType.CurrentRow.Cells(GridView.MaintenanceProject).Value.ToString

        Me.cbAssetName.SelectedValue = AssetName
        Me.ckIsMpDay.Checked = IsMpDay
        Me.ckIsMpMonth.Checked = IsMpMonth
        Me.ckIsMpQuarter.Checked = IsMpQuarter
        Me.txtMaintenanceProject.Text = MaintenanceProject
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Me.dgvMaintenanceType.CurrentRow Is Nothing OrElse Me.dgvMaintenanceType.RowCount < 1 Then
            Exit Sub
        End If
        Dim AssetName As String = Nothing
        Dim MaintenanceType As String = Nothing
        Dim confirmMsg As String
        AssetName = Me.dgvMaintenanceType.CurrentRow.Cells(GridView.AssetName).Value.ToString
        MaintenanceType = Me.dgvMaintenanceType.CurrentRow.Cells(GridView.MaintenanceProject).Value.ToString
        confirmMsg = "确定要删除" & AssetName & "的[ " & MaintenanceType & " ]保养项目吗？"
        If (MessageUtils.ShowConfirm(confirmMsg, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            DeleteData()
            '验证是否已在保养的资料
            Me.dgvMaintenanceType.Rows.RemoveAt(Me.dgvMaintenanceType.CurrentRow.Index)
        End If

        SetControlEnable(FormBtnonType.Delete)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If InputCheck() = True Then
            If SaveData() = True Then
                MessageUtils.ShowInformation("保存成功")
                SetControlEnable(FormBtnonType.Save)
                Me._ActivaStatus = FormBtnonType.Normal.ToString
                BindData()
            End If
        End If
    End Sub

    Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        SetControlEnable(FormBtnonType.Undo)
        Me._ActivaStatus = FormBtnonType.Normal.ToString
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SetControlEnable(FormBtnonType.Search)

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        BindData()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    Private Sub dgvMaintenanceType_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvMaintenanceType.CellPainting
        If e.ColumnIndex = 0 AndAlso e.RowIndex <> -1 Then
            '合并单元格
            DrawCell(e)
        End If
    End Sub
#End Region

#Region "方法"

    ''' <summary>
    ''' 检验输入项是否正确
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InputCheck() As Boolean
        Dim r As Boolean = False
        If String.IsNullOrEmpty(cbAssetName.SelectedValue.ToString) OrElse cbAssetName.SelectedValue.ToString = "" Then
            Me.lbMsg.Text = "请选择设备名称!"
            Me.cbAssetName.Focus()
            Return False
        End If
        If Me.ckIsMpDay.Checked = False AndAlso Me.ckIsMpMonth.Checked = False AndAlso Me.ckIsMpQuarter.Checked = False Then
            Me.lbMsg.Text = "至少要选择一项保养类型!"
            Return False
        End If
        If String.IsNullOrEmpty(Me.txtMaintenanceProject.Text.Trim) Then
            Me.lbMsg.Text = "请输入保养项目!"
            Me.txtMaintenanceProject.Focus()
            Return False
        End If

        '检验此保养项目是否重复
        If ExistMpCheck() = False Then
            Me.lbMsg.Text = "此设备的保养项目已存在,请勿重复!"
            Me.txtMaintenanceProject.Focus()
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' 保存数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveData() As Boolean
        Dim result As Boolean = False
        Try
            Dim o_strSql As New StringBuilder
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim IsMpDay As Integer = 0
            Dim IsMpMonth As Integer = 0
            Dim IsMpQuarter As Integer = 0

            IsMpDay = IIf(Me.ckIsMpDay.Checked = True, 1, 0)
            IsMpMonth = IIf(Me.ckIsMpMonth.Checked = True, 1, 0)
            IsMpQuarter = IIf(Me.ckIsMpQuarter.Checked = True, 1, 0)
            '新增
            If Me.ActivaStatus = FormBtnonType.Add.ToString Then
                o_strSql.Append("INSERT INTO m_EquMaintenanceType_t (AssetName,MaintenanceProject,IsMpDay,IsMpMonth,IsMpQuarter,CreateTime,CreateUserID)")
                o_strSql.Append(String.Format(" VALUES(N'{0}',N'{1}',{2},{3},{4},GETDATE(),N'{5}')", Me.cbAssetName.SelectedValue.ToString, txtMaintenanceProject.Text.Trim,
                                       IsMpDay, IsMpMonth, IsMpQuarter, UserID))
                DbOperateUtils.ExecSQL(o_strSql.ToString)
            Else
                Dim _Id As String
                _Id = Me.dgvMaintenanceType.CurrentRow.Cells(GridView.Id).Value.ToString
                o_strSql.Append(String.Format("UPDATE m_EquMaintenanceType_t SET AssetName=N'{0}',IsMpDay={1},IsMpMonth={2},IsMpQuarter={3} ,MaintenanceProject=N'{4}',CreateUserID=N'{5}',CreateTime=GETDATE() WHERE ID='{6}'",
                                              Me.cbAssetName.SelectedValue.ToString, IsMpDay, IsMpMonth, IsMpQuarter, Me.txtMaintenanceProject.Text.Trim, UserID, _Id))
                DbOperateUtils.ExecSQL(o_strSql.ToString)
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquMaintenanceType", "SaveData()", "sys")
        End Try
        Return True
    End Function

    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DeleteData() As Boolean
        Dim r As Boolean = False
        Try
            Dim o_strSql As New StringBuilder
            Dim Id As String = Nothing
            Id = Me.dgvMaintenanceType.CurrentRow.Cells(GridView.Id).Value.ToString()
            o_strSql.Append(String.Format(" DELETE m_EquMaintenanceType_t WHERE ID={0} ", Id))
            DbOperateUtils.ExecSQL(o_strSql.ToString)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquMaintenanceType", "DeleteData()", "sys")
        End Try
        Return True
    End Function
    ''' <summary>
    ''' 校验保养项目是否重复
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExistMpCheck() As Boolean
        Dim result As Boolean = False

        Try
            Dim o_strSql As New StringBuilder
            Dim iRow As Integer = 0
            Dim Id As String = Nothing
            o_strSql.Append(String.Format("SELECT * FROM m_EquMaintenanceType_t WHERE AssetName=N'{0}' AND MaintenanceProject=N'{1}'",
                              Me.cbAssetName.SelectedValue.ToString, Me.txtMaintenanceProject.Text.Trim))
            '修改
            If Me.ActivaStatus = FormBtnonType.Modify.ToString Then
                Id = Me.dgvMaintenanceType.CurrentRow.Cells(GridView.Id).Value.ToString()
                o_strSql.Append(" and Id<>'" & Id & "'")
            End If
            iRow = DbOperateUtils.GetRowsCount(o_strSql.ToString)
            If iRow > 0 Then
                Return False
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquMaintenanceType", "ExistMpCheck()", "sys")
        End Try
        Return True
    End Function


    ''' <summary>
    ''' 加载数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BindData()
        Try
            Dim sb As New StringBuilder
            Dim dt As DataTable
            sb.Append("SELECT a.AssetName,a.MaintenanceProject, case when IsMpDay=1 then '√' else '×' end IsMpDay,")
            sb.Append("   case when IsMpMonth=1  then '√' else '×' end IsMpMonth ,case when IsMpQuarter=1 then '√' else '×' end IsMpQuarter ")
            sb.Append(" ,b.UserName ,CreateTime,Id  FROM dbo.m_EquMaintenanceType_t a left join m_Users_t b on b.UserID=a.CreateUserID where 1=1")


            If Me.cbAssetName.SelectedValue.ToString <> "" Then
                sb.Append(" and a.AssetName=N'" & Me.cbAssetName.SelectedValue.ToString & "'")
            End If

            If Me.ckIsMpDay.Checked = True Then
                sb.Append(" and a.IsMpDay=1 ")
            End If
            If Me.ckIsMpMonth.Checked = True Then
                sb.Append(" and a.IsMpMonth=1 ")
            End If
            If Me.ckIsMpMonth.Checked = True Then
                sb.Append(" and a.IsMpQuarter=1 ")
            End If
            If Not String.IsNullOrEmpty(Me.txtMaintenanceProject.Text.Trim) Then
                sb.Append(" and a.MaintenanceProject like '%" & Me.txtMaintenanceProject.Text.Trim & "%' ")
            End If

            sb.Append(" order by a.AssetName,a.Id asc")
            dt = DbOperateUtils.GetDataTable(sb.ToString)

            Me.dgvMaintenanceType.DataSource = dt
            Me.lbRowAount.Text = dt.Rows.Count
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquMaintenanceType", "BindData()", "sys")
        End Try
    End Sub
    ''' <summary>
    ''' 加载模具名称下拉列表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadEquName()
        Try
            'Dim strSQL As String = " SELECT  C.NAME AS VALUE, C.NAME AS TEXT FROM " & _
            '                       " m_Equipment_t A  INNER JOIN  M_EQUIPMENTCATEGORY_T C ON A.MiddleCategory = C.TYPE" & _
            '                       " WHERE A.MiddleCategory ='MJ' " & _
            '                       " GROUP BY C.NAME"
            '手动后台去维护
            'Dim strSQL As String = "SELECT  NAME AS VALUE, Name_Text AS TEXT FROM M_EQUIPMENTCategoryTypeName_T WHERE 1=1 and usey='1'"
            Dim strSQL As String = "select  SortName AS VALUE ,SortName AS TEXT from m_Sortset_t where SortType ='MouldType' and Usey ='Y'"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            Dim dr As DataRow = dt.NewRow

            dr("text") = ""
            dr("value") = ""
            dt.Rows.InsertAt(dr, 0)
            cbAssetName.DataSource = dt
            cbAssetName.DisplayMember = "text"
            cbAssetName.ValueMember = "value"
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmEquMaintenanceType", "LoadEquName", "Equ")
        End Try
    End Sub

    ''' <summary>
    ''' 画单元格
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DrawCell(ByVal e As DataGridViewCellPaintingEventArgs)
        If e.CellStyle.Alignment = DataGridViewContentAlignment.NotSet Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        Dim gridBrush As Brush = New SolidBrush(Me.dgvMaintenanceType.GridColor)
        Dim backBrush As SolidBrush = New SolidBrush(e.CellStyle.BackColor)
        Dim fontBrush As SolidBrush = New SolidBrush(e.CellStyle.ForeColor)
        Dim cellwidth As Integer = 0
        '上面相同的行数
        Dim UpRows As Integer = 0
        '下面相同的行数
        Dim DownRows As Integer = 0
        '总行数
        Dim count As Integer = 0

        If e.RowIndex <> -1 Then
            cellwidth = e.CellBounds.Width
            Dim gridLinePen As Pen = New Pen(gridBrush)
            Dim curValue As String = IIf(e.Value Is Nothing, "", e.Value.ToString.Trim)

            Dim curSelected = IIf(Me.dgvMaintenanceType.CurrentRow.Cells(e.ColumnIndex).Value Is Nothing, "", Me.dgvMaintenanceType.CurrentRow.Cells(e.ColumnIndex).Value.ToString.Trim())
            If Not String.IsNullOrEmpty(curValue) Then
                '获取下面的行数
                For i = e.RowIndex To Me.dgvMaintenanceType.Rows.Count - 1
                    If Me.dgvMaintenanceType.Rows(i).Cells(e.ColumnIndex).Value.Equals(curValue) Then
                        DownRows = DownRows + 1
                        If e.RowIndex <> i Then
                            cellwidth = IIf(cellwidth < Me.dgvMaintenanceType.Rows(i).Cells(e.ColumnIndex).Size.Width, cellwidth, Me.dgvMaintenanceType.Rows(i).Cells(e.ColumnIndex).Size.Width)
                        End If
                    Else
                        Exit For
                    End If
                Next
                '获取上面的行数
                Dim ir As Integer = e.RowIndex
                While ir >= 0
                    If Me.dgvMaintenanceType.Rows(ir).Cells(e.ColumnIndex).Value.Equals(curValue) Then
                        UpRows = UpRows + 1
                        If e.RowIndex <> ir Then
                            cellwidth = IIf(cellwidth < Me.dgvMaintenanceType.Rows(ir).Cells(e.ColumnIndex).Size.Width, cellwidth, Me.dgvMaintenanceType.Rows(ir).Cells(e.ColumnIndex).Size.Width)
                        End If
                    Else
                        Exit While
                    End If
                    ir = ir - 1
                End While

                count = DownRows + UpRows - 1
                If count < 2 Then
                    Return
                End If
            End If

            If Me.dgvMaintenanceType.Rows(e.RowIndex).Selected = True Then
                backBrush.Color = e.CellStyle.SelectionBackColor
                fontBrush.Color = e.CellStyle.SelectionForeColor
            End If
            '以背景色填充
            e.Graphics.FillRectangle(backBrush, e.CellBounds)

            '画字符串
            PaintingFont(e, cellwidth, UpRows, DownRows, count)
            If DownRows = 1 Then
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                count = 0
            End If
            ''画右边线
            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' 画字符串
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="cellwidth"></param>
    ''' <param name="UpRows">上面的行数</param>
    ''' <param name="DownRows">下面的行数</param>
    ''' <param name="count">总行数</param>
    ''' <remarks></remarks>
    Private Sub PaintingFont(ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs, ByVal cellwidth As Integer, ByVal UpRows As Integer, ByVal DownRows As Integer, ByVal count As Integer)

        Dim fontBrush As SolidBrush = New SolidBrush(e.CellStyle.ForeColor)
        Dim fontheight As Integer = CInt(e.Graphics.MeasureString(e.Value.ToString, e.CellStyle.Font).Height)
        Dim fontwidth As Integer = CInt(e.Graphics.MeasureString(e.Value.ToString, e.CellStyle.Font).Width)
        Dim cellheight As Integer = e.CellBounds.Height

        If e.CellStyle.Alignment = DataGridViewContentAlignment.BottomCenter Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y + cellheight * DownRows - fontheight)
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.BottomLeft Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y + cellheight * DownRows - fontheight)
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2)
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2)
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2)
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.TopCenter Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1))
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.TopLeft Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1))
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1))
        Else
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2)
        End If
    End Sub

    ''' <summary>
    ''' 设置控件权限
    ''' </summary>
    ''' <param name="fbt"></param>
    ''' <remarks></remarks>
    Private Sub SetControlEnable(ByVal fbt As FormBtnonType)
        Me.cbAssetName.SelectedIndex = 0
        Me.ckIsMpDay.Checked = False
        Me.ckIsMpMonth.Checked = False
        Me.ckIsMpQuarter.Checked = False
        Me.txtMaintenanceProject.Text = ""
        Me.lbMsg.Text = ""
        Select Case fbt
            Case FormBtnonType.Normal
                Me.cbAssetName.Enabled = False
                Me.ckIsMpDay.Enabled = False
                Me.ckIsMpMonth.Enabled = False
                Me.ckIsMpQuarter.Enabled = False
                Me.txtMaintenanceProject.Enabled = False
            Case FormBtnonType.Add
                Me.btnNew.Enabled = False
                Me.btnModify.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnSearch.Enabled = False
                Me.btnRefresh.Enabled = False
                Me.btnSave.Enabled = True
                Me.btnUndo.Enabled = True

                Me.cbAssetName.Enabled = True
                Me.ckIsMpDay.Enabled = True
                Me.ckIsMpMonth.Enabled = True
                Me.ckIsMpQuarter.Enabled = True
                Me.txtMaintenanceProject.Enabled = True
            Case FormBtnonType.Modify
                Me.btnNew.Enabled = False
                Me.btnModify.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnSearch.Enabled = False
                Me.btnRefresh.Enabled = False
                Me.btnSave.Enabled = True
                Me.btnUndo.Enabled = True
                Me.cbAssetName.Enabled = True
                Me.ckIsMpDay.Enabled = True
                Me.ckIsMpMonth.Enabled = True
                Me.ckIsMpQuarter.Enabled = True
                Me.txtMaintenanceProject.Enabled = True
            Case FormBtnonType.Save
                Me.btnNew.Enabled = True
                Me.btnModify.Enabled = True
                Me.btnDelete.Enabled = True
                Me.btnSearch.Enabled = True
                Me.btnRefresh.Enabled = True
                Me.btnSave.Enabled = False
                Me.btnUndo.Enabled = False

                Me.cbAssetName.Enabled = False
                Me.ckIsMpDay.Enabled = False
                Me.ckIsMpMonth.Enabled = False
                Me.ckIsMpQuarter.Enabled = False
                Me.txtMaintenanceProject.Enabled = False
            Case FormBtnonType.Undo
                Me.btnNew.Enabled = True
                Me.btnModify.Enabled = True
                Me.btnDelete.Enabled = True
                Me.btnSearch.Enabled = True
                Me.btnRefresh.Enabled = True
                Me.btnSave.Enabled = False
                Me.btnUndo.Enabled = False

                Me.cbAssetName.Enabled = False
                Me.ckIsMpDay.Enabled = False
                Me.ckIsMpMonth.Enabled = False
                Me.ckIsMpQuarter.Enabled = False
                Me.txtMaintenanceProject.Enabled = False
            Case FormBtnonType.Search
                Me.cbAssetName.Enabled = True
                Me.ckIsMpDay.Enabled = True
                Me.ckIsMpMonth.Enabled = True
                Me.ckIsMpQuarter.Enabled = True
                Me.txtMaintenanceProject.Enabled = True
            Case Else
                'do Nothing
        End Select
    End Sub
#End Region


End Class