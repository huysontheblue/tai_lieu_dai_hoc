Imports System.Text
Imports System.Windows.Forms
Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmAutoMadeData


    '变量定义
    Dim OperateFlag As EditMode '操作模式
    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DtEnd.Value = DateTime.Now.ToString
        DtStar.Value = DateTime.Now.AddDays(-30).ToString
        '绑定数据
        LoadAssetNeedMadeData()


    End Sub

    Private Sub LoadAssetNeedMadeData()
        Dim StrSql As String = ""
        Try
            StrSql = " SELECT a.AssetNo,b.MaintenanceProject " & _
          " FROM dbo.m_Asset_t a " & _
         " LEFT JOIN dbo.m_AssetMaintenanceType_t b ON a.AssetName = b.AssetName " & _
         "  WHERE 1 = 1" & _
        " AND b.MaintenanceProject IS NOT NULL  " & _
        " AND Profitcenter ='" & VbCommClass.VbCommClass.profitcenter & "'" & _
        " AND B.ISMPDAY =1"

            If OperateFlag = EditMode.SEARCH Then
                StrSql = StrSql + GetSqlWhere()
            End If

            'StrSql = StrSql + " ORDER BY A.Status DESC "
            LoadData(StrSql)
        Catch ex As Exception
            'MessageUtils.ShowError(ex.Message)
        End Try


    End Sub

    Private Sub LoadData(ByVal Sql As String)
        Dim col As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn
        col.Name = "选择"
        col.ReadOnly = False
        col.TrueValue = True
        col.FalseValue = False
        Try
            Using dt As DataTable = DbOperateUtils.GetDataTable(Sql)

                SetColumnsProperty(col, dgvAsset, dt)
            End Using
        Catch ex As Exception
            'Throw ex
            '  SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmAsset", "LoadData", "sys")
        End Try
    End Sub

    Private Sub SetColumnsProperty(col As DataGridViewCheckBoxColumn, dgGrid As DataGridView, dt As DataTable)
        Try
            If dgGrid.Columns.Count > 0 Then dgGrid.Columns.Clear()
            dgGrid.DataSource = dt
            dgGrid.Columns.Insert(0, col)
            '"备注"列全屏显示
            ' dgGrid.Columns(AssetGrid.ID).Visible = False
            ' dgGrid.Columns(AssetGrid.Remark).Visible = False
            dgGrid.ReadOnly = False
            '    dgGrid.Columns(0).HeaderText = "   选择"
            'SetSelectAll(dgGrid)
            'dgGrid.Columns(AssetGrid.ID).Width = 40
            'dgGrid.Columns(AssetGrid.checkbox).Width = 60
            'dgGrid.Columns(AssetGrid.AssetNO).Width = 100
            'dgGrid.Columns(AssetGrid.AssetName).Width = 105
            'dgGrid.Columns(AssetGrid.Model).Width = 105
            'dgGrid.Columns(AssetGrid.Status).Width = 80
            'dgGrid.Columns(AssetGrid.Qty).Width = 80
            'dgGrid.Columns(AssetGrid.KeeperName).Width = 95
            'dgGrid.Columns(AssetGrid.Storage).Width = 105
            'dgGrid.Columns(AssetGrid.FactoryID).Width = 60
            'dgGrid.Columns(AssetGrid.ProfitCenter).Width = 80
            'ToolStatusLabel.Text = String.Format("查询结果{0}笔", dgGrid.RowCount.ToString)
            'CheckBox = 0 AssetNO,AssetName,Model,Status,Qty,KeeperName,Storage,CreateUserID,CreateTime,FactoryID,ProfitCenter,ID
        Catch ex As Exception
            'Throw ex
            ' SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmAsset", "SetColumnsProperty", "sys")
        End Try
    End Sub


    Private Function GetSqlWhere() As String
        Dim sbSqlWhere As New StringBuilder

        If Me.txtAssetNo.Text.Trim() <> "" Then
            sbSqlWhere.Append(" AND [AssetNo] LIKE N'%" & txtAssetNo.Text.Trim().Replace("'", "''") & "%' ")
        End If




        Return sbSqlWhere.ToString
    End Function

    Private Sub toolRefresh_Click(sender As Object, e As EventArgs) Handles toolRefresh.Click
        OperateFlag = EditMode.SEARCH

        LoadAssetNeedMadeData()

    End Sub

    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        OperateFlag = EditMode.SEARCH
    End Sub

    Private Sub ToolLend_Click(sender As Object, e As EventArgs) Handles ToolLend.Click
        Dim strInsertSQL As New StringBuilder

        Dim ts As TimeSpan = DtEnd.Value - DtStar.Value



        For Each dr As DataGridViewRow In Me.dgvAsset.Rows

            '            INSERT INTO  m_AssetMaintenanceDay_t(AssetNo, MaintenanceProject,Status, CreateTime,CreateUserID,Remark)
            'VALUES( 'J001793',N'确认动作是否正常', 'O', '2018-05-26 09:08','E005779','')
            'J001793/确认机台表面是否清洁
            For i As Integer = 0 To ts.Days
                ' DtStar.Value.AddDays(+i).ToString()
                If (Not DtStar.Value.AddDays(+i).DayOfWeek = DayOfWeek.Sunday) Then
                    strInsertSQL.Append(" If not exists(")
                    strInsertSQL.Append(" SELECT top 1 1 FROM m_AssetMaintenanceDay_t WHERE AssetNo='" & dr.Cells(1).Value & "' ")
                    strInsertSQL.Append(" AND MaintenanceProject=N'" & dr.Cells(2).Value & "' ")
                    strInsertSQL.Append(" AND  CONVERT(VARCHAR(10),createtime,120 ) =  '" & DtStar.Value.AddDays(+i).ToString.Substring(0, 10) & "') ")
                    strInsertSQL.Append(" begin  ")
                    strInsertSQL.Append(" Insert into m_AssetMaintenanceDay_t( assetNo, MaintenanceProject,Status, CreateTime,CreateUserID)")
                    strInsertSQL.Append(" values( '" & dr.Cells(1).Value & "', N'" & dr.Cells(2).Value & "','O', '" & DtStar.Value.AddDays(+i).ToString & "','E005779') ")
                    strInsertSQL.Append(" END  ")
                End If

            Next



        Next


        DbOperateUtils.ExecSQL(strInsertSQL.ToString)

        MessageUtils.ShowInformation("维护成功！")
        '   DateTime dt1 = Convert.ToDateTime("2008-7-22");
        'DateTime dt2 = Convert.ToDateTime("2009-7-30");
        'TimeSpan ts = (TimeSpan)(dt2 - dt1);



    End Sub
End Class