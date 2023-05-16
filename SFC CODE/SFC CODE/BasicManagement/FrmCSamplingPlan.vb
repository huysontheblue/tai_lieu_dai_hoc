Imports MainFrame

Public Class FrmCSamplingPlan

    Private Sub btnAppend_Click(sender As Object, e As EventArgs) Handles btnAppend.Click
        Dim frm As FrmCSamplingPlanData = New FrmCSamplingPlanData
        frm.g_sUpdateType = "APPEND"
        frm.ShowDialog()
        ShowData()
    End Sub
    Dim SamplingName, SamplingId, SamplingType As String
    Private Sub FrmCSamplingPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combShow.SelectedIndex = 0
        ShowData()
    End Sub
    Public Sub ShowData()
        Dim strSQL As String
        Dim dt As DataTable
        strSQL = "SELECT SamplingId AS SamplingId,SamplingName AS 抽验计划,SamplingDesc AS 抽验计划描述,CASE WHEN SamplingType='C' THEN N'产量' ELSE N'正常' END AS 检验方式 ,MA_RejectQty AS 主缺判退标准,MI_RejectQty 次缺判退标准 ,CR_RejectQty 重缺判退标准,Remark AS 备注,(SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员,CreateTime AS 维护时间 FROM m_QCSamplingPlan_t WHERE Usey = 'Y'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        gvData.DataSource = dt
    End Sub
    Private Sub btnDetailAppend_Click(sender As Object, e As EventArgs) Handles btnDetailAppend.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then
            Return
        End If
        If SamplingType = "正常" Then
            Dim frm As FrmCSamplingPlanDate = New FrmCSamplingPlanDate
            frm.g_sUpdateType = "APPEND"
            frm.SamplingId = SamplingId
            frm.ShowDialog()
            Dim strSQL As String
            Dim dt As DataTable
            strSQL = "SELECT ConfigQty 配置数,ConfigUnit AS 配置单位,FuncQCRatio AS ""功能检验比例(基数为已送检小批量)"",ContinBatchQty AS 连续检验批,RejectBatchQty AS 判退批次数,IsDefault AS 默认项,CheckLevel AS 检验程度,NextCheckLevel AS 下一检验程度 ,(SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员,CreateTime AS 维护时间 FROM m_QCSamplingPlanDetail_t  WHERE SamplingId = '" + SamplingId + "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            gvDetail.DataSource = dt
        Else
            Dim frm As FrmCSamplingPlanDatb = New FrmCSamplingPlanDatb
            frm.g_sUpdateType = "APPEND"
            frm.SamplingId = SamplingId
            frm.ShowDialog()
            Dim strSQL As String
            Dim dt As DataTable
            strSQL = "SELECT LowerLimit AS 产量下限范围,UpperLimit AS 产量上限范围,AppearanceRatio AS 外观检验比例 ,FunctionRatio AS ""功能检验比例(基数为已送检小批量)"", ConfigQty AS 送检配置数, IsEnable AS 是否有效,(SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员 , CreateTime AS 维护时间 FROM m_QCSamplingPlanCapacityDetail_t WHERE SamplingId = '" + SamplingId + "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            gvDetail.DataSource = dt
        End If
    End Sub

    Private Sub gvData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvData.CellClick
        SamplingId = gvData(0, gvData.CurrentCell.RowIndex).Value()
        SamplingType = gvData(3, gvData.CurrentCell.RowIndex).Value()
        Dim strSQL As String
        Dim dt As DataTable
        If SamplingType = "产量" Then
            btnDetailDelete.Enabled = False
            ToolStripButton1.Enabled = True
            strSQL = "SELECT LowerLimit AS 产量下限范围,UpperLimit AS 产量上限范围,AppearanceRatio AS 外观检验比例 ,FunctionRatio AS ""功能检验比例(基数为已送检小批量)"", ConfigQty AS 送检配置数,IsEnable AS 是否有效, (SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员 , CreateTime AS 维护时间 FROM m_QCSamplingPlanCapacityDetail_t WHERE SamplingId = '" + SamplingId + "'"
        Else
            btnDetailDelete.Enabled = True
            ToolStripButton1.Enabled = False
            strSQL = "SELECT ConfigQty 配置数,ConfigUnit AS 配置单位,FuncQCRatio AS ""功能检验比例(基数为已送检小批量)"",ContinBatchQty AS 连续检验批,RejectBatchQty AS 判退批次数,IsDefault AS 默认项,CheckLevel AS 检验程度,NextCheckLevel AS 下一检验程度 ,(SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员,CreateTime AS 维护时间 FROM m_QCSamplingPlanDetail_t  WHERE SamplingId = '" + SamplingId + "'"
        End If
        'strSQL = "SELECT ConfigQty 配置数,ConfigUnit AS 配置单位,FuncQCRatio AS 功能检验比例,ContinBatchQty AS 连续检验批,RejectBatchQty AS 判退批次数,IsDefault AS 默认项,CheckLevel AS 检验程度,NextCheckLevel AS 下一检验程度 ,(SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员,CreateTime AS 维护时间 FROM m_QCSamplingPlanDetail_t  WHERE SamplingId = '" + SamplingId + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        gvDetail.DataSource = dt
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then
            Return
        End If
        Dim frm As FrmCSamplingPlanData = New FrmCSamplingPlanData()
        Try
            frm.g_sUpdateType = "Update"
            Dim index As Integer = gvData.CurrentRow.Index
            frm.SamplingId = gvData(0, gvData.CurrentCell.RowIndex).Value()
            frm.SamplingName = gvData.Rows(index).Cells("抽验计划").Value.ToString()
            frm.SamplingDesc = gvData.Rows(index).Cells("抽验计划描述").Value.ToString()
            frm.SamplingType = gvData.Rows(index).Cells("检验方式").Value.ToString()
            frm.MA_RejectQty = gvData.Rows(index).Cells("主缺判退标准").Value.ToString()
            frm.MI_RejectQty = gvData.Rows(index).Cells("次缺判退标准").Value.ToString()
            frm.CR_RejectQty = gvData.Rows(index).Cells("重缺判退标准").Value.ToString()
            frm.Remark = gvData.Rows(index).Cells("备注").Value.ToString()
            frm.ShowDialog()
            Dim strSQL As String
            Dim dt As DataTable
            strSQL = "SELECT SamplingId AS SamplingId ,SamplingName AS 抽验计划,SamplingDesc AS 抽验计划描述,CASE WHEN SamplingType='C' THEN N'产量' ELSE N'正常' END AS 检验方式 ,MA_RejectQty AS 主缺判退标准,MI_RejectQty 次缺判退标准 ,CR_RejectQty 重缺判退标准,Remark AS 备注,(SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员,CreateTime AS 维护时间 FROM m_QCSamplingPlan_t WHERE SamplingId = '" + SamplingId + "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            gvData.DataSource = dt
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnDetailModify_Click(sender As Object, e As EventArgs) Handles btnDetailModify.Click
        If gvDetail.Rows.Count = 0 OrElse gvDetail.CurrentRow Is Nothing Then
            Return
        End If
        If SamplingType = "正常" Then
            Dim frm As FrmCSamplingPlanDate = New FrmCSamplingPlanDate()
            Try
                frm.g_sUpdateType = "Update"
                Dim index As Integer = gvDetail.CurrentRow.Index
                frm.SamplingId = gvData(0, gvData.CurrentCell.RowIndex).Value()
                frm.ConfigQty = gvDetail.Rows(index).Cells("配置数").Value.ToString()
                frm.ConfigUnit = gvDetail.Rows(index).Cells("配置单位").Value.ToString()
                frm.FuncQCRatio = gvDetail.Rows(index).Cells("功能检验比例(基数为已送检小批量)").Value.ToString()
                frm.ContinBatchQty = gvDetail.Rows(index).Cells("连续检验批").Value.ToString()
                frm.RejectBatchQty = gvDetail.Rows(index).Cells("判退批次数").Value.ToString()
                frm.IsDefault = gvDetail.Rows(index).Cells("默认项").Value.ToString()
                frm.CheckLevel = gvDetail.Rows(index).Cells("检验程度").Value.ToString()
                frm.NextCheckLevel = gvDetail.Rows(index).Cells("下一检验程度").Value.ToString()
                frm.ShowDialog()
                Dim strSQL As String
                Dim dt As DataTable
                strSQL = "SELECT ConfigQty 配置数,ConfigUnit AS 配置单位,FuncQCRatio AS ""功能检验比例(基数为已送检小批量)"",ContinBatchQty AS 连续检验批,RejectBatchQty AS 判退批次数,IsDefault AS 默认项,CheckLevel AS 检验程度,NextCheckLevel AS 下一检验程度 ,(SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员,CreateTime AS 维护时间 FROM m_QCSamplingPlanDetail_t  WHERE SamplingId = '" + SamplingId + "'"
                dt = DbOperateUtils.GetDataTable(strSQL)
                gvDetail.DataSource = dt
            Catch ex As Exception
            End Try
        Else
            Dim frm As FrmCSamplingPlanDatb = New FrmCSamplingPlanDatb()
            Try
                frm.g_sUpdateType = "Update"
                Dim index As Integer = gvDetail.CurrentRow.Index
                frm.SamplingId = gvData(0, gvData.CurrentCell.RowIndex).Value()
                frm.LowerLimit = gvDetail.Rows(index).Cells("产量下限范围").Value.ToString()
                frm.UpperLimit = gvDetail.Rows(index).Cells("产量上限范围").Value.ToString()
                frm.AppearanceRatio = gvDetail.Rows(index).Cells("外观检验比例").Value.ToString()
                frm.FunctionRatio = gvDetail.Rows(index).Cells("功能检验比例(基数为已送检小批量)").Value.ToString()
                frm.ConfigQty = gvDetail.Rows(index).Cells("送检配置数").Value.ToString()
                frm.IsEnable = gvDetail.Rows(index).Cells("是否有效").Value.ToString()
                frm.ShowDialog()
                Dim strSQL As String
                Dim dt As DataTable
                strSQL = "SELECT LowerLimit AS 产量下限范围,UpperLimit AS 产量上限范围,AppearanceRatio AS 外观检验比例 ,FunctionRatio AS ""功能检验比例(基数为已送检小批量)"", ConfigQty AS 送检配置数,IsEnable AS 是否有效, (SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员 , CreateTime AS 维护时间 FROM m_QCSamplingPlanCapacityDetail_t WHERE SamplingId = '" + SamplingId + "'"
                dt = DbOperateUtils.GetDataTable(strSQL)
                gvDetail.DataSource = dt
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnDetailDelete_Click(sender As Object, e As EventArgs) Handles btnDetailDelete.Click
        If gvDetail.Rows.Count = 0 OrElse gvDetail.CurrentRow Is Nothing Then
            Return
        End If
        Dim strSQL As String
        Dim dt As DataTable
        strSQL = "DELETE m_QCSamplingPlanDetail_t WHERE SamplingId= '" + gvData(0, gvData.CurrentCell.RowIndex).Value().ToString + "' AND CheckLevel=N'" + gvDetail(6, gvDetail.CurrentCell.RowIndex).Value().ToString + "' AND NextCheckLevel = N'" + gvDetail(7, gvDetail.CurrentCell.RowIndex).Value().ToString + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        strSQL = "SELECT ConfigQty 配置数,ConfigUnit AS 配置单位,FuncQCRatio AS ""功能检验比例(基数为已送检小批量)"",ContinBatchQty AS 连续检验批,RejectBatchQty AS 批次批退标准,IsDefault AS 默认项,CheckLevel AS 检验程度,NextCheckLevel AS 下一检验程度 ,(SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员,CreateTime AS 维护时间 FROM m_QCSamplingPlanDetail_t  WHERE SamplingId = '" + SamplingId + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        gvDetail.DataSource = dt
    End Sub

    Private Sub btnDisabled_Click(sender As Object, e As EventArgs) Handles btnDisabled.Click
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then
            Return
        End If
        Dim strSQL As String
        Dim dt As DataTable
        strSQL = "UPDATE m_QCSamplingPlan_t SET Usey = 'N',CreateUserId = '" + VbCommClass.VbCommClass.UseId + "',CreateTime= getdate() WHERE SamplingId = '" + gvData(0, gvData.CurrentCell.RowIndex).Value().ToString() + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        S()
    End Sub
    Private Sub S()
        Dim strSQL As String
        Dim dt As DataTable
        btnDelete.Visible = (combShow.SelectedIndex = 1)
        btnDisabled.Visible = (combShow.SelectedIndex = 0)
        btnEnabled.Visible = (combShow.SelectedIndex = 1)
        strSQL = "SELECT SamplingId,SamplingName AS 抽验计划,SamplingDesc AS 抽验计划描述,CASE WHEN SamplingType='C' THEN N'产量' ELSE N'正常' END AS 检验方式,MA_RejectQty AS 主缺判退标准,MI_RejectQty 次缺判退标准 ,CR_RejectQty 重缺判退标准,Remark AS 备注,(SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员,CreateTime AS 维护时间 FROM m_QCSamplingPlan_t WHERE 1=1"
        If combShow.SelectedIndex = 0 Then
            strSQL = strSQL + " and Usey = 'Y'"
        ElseIf (combShow.SelectedIndex = 1) Then
            strSQL = strSQL + " and Usey = 'N'"
        End If
        If combFilter.Text.Trim = "抽验计划" Then
            strSQL = strSQL + " and SamplingName like N'%" + editFilter.Text + "%'"
        ElseIf combFilter.Text.Trim = "抽验计划描述" Then
            strSQL = strSQL + " and SamplingDesc like N'%" + editFilter.Text.Trim() + "%'"
        ElseIf combFilter.Text.Trim = "主缺判退标准" Then
            strSQL = strSQL + " and MA_RejectQty like'%" + editFilter.Text.Trim() + "%'"
        ElseIf combFilter.Text.Trim = "次缺判退标准" Then
            strSQL = strSQL + " and MI_RejectQty like'%" + editFilter.Text.Trim() + "%'"
        ElseIf combFilter.Text.Trim = "重缺判退标准" Then
            strSQL = strSQL + " and CR_RejectQty like'%" + editFilter.Text.Trim() + "%'"
        End If
        dt = DbOperateUtils.GetDataTable(strSQL)
        gvData.DataSource = dt
    End Sub

    Private Sub combShow_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combShow.SelectedIndexChanged
        S()
    End Sub

    Private Sub gvData_DataSourceChanged(sender As Object, e As EventArgs) Handles gvData.DataSourceChanged
        Dim strSQL As String
        Dim dt As DataTable
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then
            gvDetail.DataSource = ""
            Return
        End If
        SamplingId = gvData(0, gvData.CurrentCell.RowIndex).Value()
        SamplingType = gvData(3, gvData.CurrentCell.RowIndex).Value()
        If SamplingType = "产量" Then
            btnDetailDelete.Enabled = False
            ToolStripButton1.Enabled = True
            strSQL = "SELECT LowerLimit AS 产量下限范围,UpperLimit AS 产量上限范围,AppearanceRatio AS 外观检验比例 ,FunctionRatio AS ""功能检验比例(基数为已送检小批量)"", ConfigQty AS 送检配置数,IsEnable AS 是否有效, (SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员 , CreateTime AS 维护时间 FROM m_QCSamplingPlanCapacityDetail_t WHERE SamplingId = '" + SamplingId + "'"
        Else
            btnDetailDelete.Enabled = True
            ToolStripButton1.Enabled = False
            strSQL = "SELECT ConfigQty 配置数,ConfigUnit AS 配置单位,FuncQCRatio AS ""功能检验比例(基数为已送检小批量)"",ContinBatchQty AS 连续检验批,RejectBatchQty AS 判退批次数,IsDefault AS 默认项,CheckLevel AS 检验程度,NextCheckLevel AS 下一检验程度 ,(SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员,CreateTime AS 维护时间 FROM m_QCSamplingPlanDetail_t  WHERE SamplingId = '" + SamplingId + "'"
        End If
        dt = DbOperateUtils.GetDataTable(strSQL)
        gvDetail.DataSource = dt
    End Sub
    Private Sub editFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles editFilter.KeyDown
        If e.KeyValue = 13 Then
            S()
        End If
    End Sub

    Private Sub btnEnabled_Click(sender As Object, e As EventArgs) Handles btnEnabled.Click
        Dim strSQL As String
        Dim dt As DataTable
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then
            Return
        End If
        strSQL = "UPDATE m_QCSamplingPlan_t SET Usey = 'Y',CreateUserId = '" + VbCommClass.VbCommClass.UseId + "',CreateTime= getdate() WHERE SamplingId = '" + gvData(0, gvData.CurrentCell.RowIndex).Value().ToString + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        S()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strSQL As String
        Dim dt As DataTable
        If gvData.Rows.Count = 0 OrElse gvData.CurrentRow Is Nothing Then
            Return
        End If
        Dim index As Integer = gvData.CurrentRow.Index
        strSQL = "DELETE m_QCSamplingPlan_t WHERE SamplingId = '" + gvData(0, gvData.CurrentCell.RowIndex).Value().ToString + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        S()
    End Sub

    Private Sub gvDetail_DataSourceChanged(sender As Object, e As EventArgs) Handles gvDetail.DataSourceChanged
        If gvDetail.Rows.Count = 0 OrElse gvDetail.CurrentRow Is Nothing Then
            Return
        End If
        Dim index As Integer = gvDetail.CurrentRow.Index
        If SamplingType = "产量" Then
            If gvDetail.Rows(index).Cells("是否有效").Value.ToString() = "N" Then
                ToolStripButton2.Enabled = True
                ToolStripButton1.Enabled = False
                btnDetailDelete.Enabled = False
            Else
                ToolStripButton2.Enabled = False
                ToolStripButton1.Enabled = True
                btnDetailDelete.Enabled = False
            End If
        End If
    End Sub

    Private Sub gvDetail_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvDetail.CellClick
        If gvDetail.Rows.Count = 0 OrElse gvDetail.CurrentRow Is Nothing Then
            Return
        End If
        Dim index As Integer = gvDetail.CurrentRow.Index
        If SamplingType = "产量" Then
            If gvDetail.Rows(index).Cells("是否有效").Value.ToString() = "N" Then
                ToolStripButton2.Enabled = True
                ToolStripButton1.Enabled = False
                btnDetailDelete.Enabled = False
            Else
                ToolStripButton2.Enabled = False
                ToolStripButton1.Enabled = True
                btnDetailDelete.Enabled = False
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If gvDetail.Rows.Count = 0 OrElse gvDetail.CurrentRow Is Nothing Then
            Return
        End If
        Dim index As Integer = gvDetail.CurrentRow.Index
        Dim strSQL As String
        Dim dt As DataTable
        strSQL = "UPDATE m_QCSamplingPlanCapacityDetail_t SET IsEnable='N',CreateUserId='" + VbCommClass.VbCommClass.UseId + "',CreateTime= getdate()  WHERE SamplingId= '" + SamplingId + "' AND LowerLimit=N'" + gvDetail.Rows(index).Cells("产量下限范围").Value.ToString() + "' AND UpperLimit = N'" + gvDetail.Rows(index).Cells("产量上限范围").Value.ToString() + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        strSQL = "SELECT LowerLimit AS 产量下限范围,UpperLimit AS 产量上限范围,AppearanceRatio AS 外观检验比例 ,FunctionRatio AS ""功能检验比例(基数为已送检小批量)"", ConfigQty AS 送检配置数,IsEnable AS 是否有效, (SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员 , CreateTime AS 维护时间 FROM m_QCSamplingPlanCapacityDetail_t WHERE SamplingId = '" + SamplingId + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        gvDetail.DataSource = dt
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If gvDetail.Rows.Count = 0 OrElse gvDetail.CurrentRow Is Nothing Then
            Return
        End If
        Dim index As Integer = gvDetail.CurrentRow.Index
        Dim strSQL As String
        Dim dt As DataTable
        strSQL = "UPDATE m_QCSamplingPlanCapacityDetail_t SET IsEnable='Y',CreateUserId='" + VbCommClass.VbCommClass.UseId + "',CreateTime= getdate()  WHERE SamplingId= '" + SamplingId + "' AND LowerLimit=N'" + gvDetail.Rows(index).Cells("产量下限范围").Value.ToString() + "' AND UpperLimit = N'" + gvDetail.Rows(index).Cells("产量上限范围").Value.ToString() + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        strSQL = "SELECT LowerLimit AS 产量下限范围,UpperLimit AS 产量上限范围,AppearanceRatio AS 外观检验比例 ,FunctionRatio AS ""功能检验比例(基数为已送检小批量)"", ConfigQty AS 送检配置数,IsEnable AS 是否有效, (SELECT UserName FROM m_Users_t WHERE UserID = CreateUserId) AS 维护人员 , CreateTime AS 维护时间 FROM m_QCSamplingPlanCapacityDetail_t WHERE SamplingId = '" + SamplingId + "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        gvDetail.DataSource = dt
    End Sub
End Class