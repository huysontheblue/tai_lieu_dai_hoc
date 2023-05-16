Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Windows.Forms

Public Class FrmMaintenancePlan

    Private Sub tsmiSave_Click(sender As Object, e As EventArgs) Handles tsmiSave.Click
        Dim sql = New System.Text.StringBuilder()
        Try
            For Each dgvr As DataGridViewRow In dgvData.Rows
                Dim AssetName = dgvr.Cells("AssetName").Value.ToString()
                Dim Quarter1 = IIf(Convert.ToBoolean(dgvr.Cells("Quarter1").Value.ToString()), 1, 0)
                Dim Quarter2 = IIf(Convert.ToBoolean(dgvr.Cells("Quarter2").Value.ToString()), 1, 0)
                Dim Quarter3 = IIf(Convert.ToBoolean(dgvr.Cells("Quarter3").Value.ToString()), 1, 0)
                Dim Quarter4 = IIf(Convert.ToBoolean(dgvr.Cells("Quarter4").Value.ToString()), 1, 0)
                Dim Month1 = IIf(Convert.ToBoolean(dgvr.Cells("Month1").Value.ToString()), 1, 0)
                Dim Month2 = IIf(Convert.ToBoolean(dgvr.Cells("Month2").Value.ToString()), 1, 0)
                Dim Month3 = IIf(Convert.ToBoolean(dgvr.Cells("Month3").Value.ToString()), 1, 0)
                Dim Month4 = IIf(Convert.ToBoolean(dgvr.Cells("Month4").Value.ToString()), 1, 0)
                Dim Month5 = IIf(Convert.ToBoolean(dgvr.Cells("Month5").Value.ToString()), 1, 0)
                Dim Month6 = IIf(Convert.ToBoolean(dgvr.Cells("Month6").Value.ToString()), 1, 0)
                Dim Month7 = IIf(Convert.ToBoolean(dgvr.Cells("Month7").Value.ToString()), 1, 0)
                Dim Month8 = IIf(Convert.ToBoolean(dgvr.Cells("Month8").Value.ToString()), 1, 0)
                Dim Month9 = IIf(Convert.ToBoolean(dgvr.Cells("Month9").Value.ToString()), 1, 0)
                Dim Month10 = IIf(Convert.ToBoolean(dgvr.Cells("Month10").Value.ToString()), 1, 0)
                Dim Month11 = IIf(Convert.ToBoolean(dgvr.Cells("Month11").Value.ToString()), 1, 0)
                Dim Month12 = IIf(Convert.ToBoolean(dgvr.Cells("Month12").Value.ToString()), 1, 0)
                Dim dt = DbOperateUtils.GetDataTable("select AssetName from m_MaintenancePlan_t where AssetName=N'" & AssetName & "'")
                If dt.Rows.Count > 0 Then '存在保养计划就做修改
                    sql.AppendLine(String.Format("update m_MaintenancePlan_t " & vbCrLf &
                    "set Quarter1={0},Quarter2={1}" & vbCrLf &
                    ",Quarter3={2},Quarter4={3}" & vbCrLf &
                    ",Month1={4},Month2={5},Month3={6},Month4={7}" & vbCrLf &
                    ",Month5={8},Month6={9},Month7={10}" & vbCrLf &
                    ",Month8={11},Month9={12},Month10={13}" & vbCrLf &
                    ",Month11={14},Month12={15} where AssetName=N'{16}'", Quarter1, Quarter2, Quarter3, Quarter4, Month1, Month2, Month3, Month4, Month5, Month6, Month7, Month8, Month9, Month10, Month11, Month12, AssetName))
                Else '不存在保养计划就做新增
                    sql.AppendLine(String.Format("insert into m_MaintenancePlan_t" & vbCrLf &
                    "(AssetName,Quarter1,Quarter2,Quarter3" & vbCrLf &
                    ",Quarter4,Month1,Month2,Month3,Month4" & vbCrLf &
                    ",Month5,Month6,Month7,Month8,Month9" & vbCrLf &
                    ",Month10,Month11,Month12) values(" & vbCrLf &
                    "N'{0}',{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}" & vbCrLf &
                    ",{11},{12},{13},{14},{15},{16})", AssetName, Quarter1, Quarter2, Quarter3, Quarter4, Month1, Month2, Month3, Month4, Month5, Month6, Month7, Month8, Month9, Month10, Month11, Month12))
                End If
            Next
            DbOperateUtils.ExecSQL(sql.ToString())
            MessageUtils.ShowInformation("保存成功!")
        Catch ex As Exception
            MessageUtils.ShowError("保存失败:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub

    Private Sub FrmMaintenancePlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataLoad()
    End Sub

    Private Sub DataLoad()
        dgvData.AutoGenerateColumns = False
        Dim FactoryName = VbCommClass.VbCommClass.Factory
        Dim Profitcenter = VbCommClass.VbCommClass.profitcenter
        Dim where = " and 1=1 "
        If String.IsNullOrEmpty(txtAssetName.Text.Trim()) = False Then
            where += " and AssetName like N'%" & txtAssetName.Text.Trim() & "%'"
        End If
        Dim sql = "SELECT   a.AssetName,isnull(b.Quarter1,0) as Quarter1, isnull(b.Quarter2,0) as Quarter2, isnull(b.Quarter3,0) as Quarter3, " & vbCrLf &
        "isnull(b.Quarter4,0) as Quarter4, isnull(b.Month1,0) as Month1, isnull(b.Month2,0) as Month2, isnull(b.Month3,0) as Month3, isnull(b.Month4,0) as Month4, isnull(b.Month5,0) as Month5," & vbCrLf &
        "isnull(b.Month6,0) as Month6, isnull(b.Month7,0) as Month7, isnull(b.Month8,0) as Month8, isnull(b.Month9,0) as Month9, isnull(b.Month10,0) as Month10, isnull(b.Month11,0) as Month11, isnull(b.Month12,0) as Month12 " & vbCrLf &
        "FROM " & vbCrLf &
        "(" & vbCrLf &
        "SELECT DISTINCT AssetName" & vbCrLf &
        "FROM" & vbCrLf &
        "dbo.m_Asset_t where FactoryName='" & FactoryName & "' " & where & vbCrLf &
        "and Profitcenter='" & Profitcenter & "'and  AssetName not in ('','/') and isnull(usey,1)='1' " & vbCrLf &
        ") AS a LEFT  JOIN" & vbCrLf &
        "dbo.m_MaintenancePlan_t AS b ON b.AssetName = a.AssetName"
        dgvData.DataSource = DbOperateUtils.GetDataTable(sql)
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        DataLoad()
    End Sub

    Private Sub dgvData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellContentClick
        If dgvData.Columns(e.ColumnIndex).Name <> "AssetName" Then
            Dim yy = CType(dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue, Boolean)
            dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = IIf(yy, False, True)
        End If
    End Sub
End Class