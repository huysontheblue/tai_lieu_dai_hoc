Imports MainFrame
Imports MainFrame.SysCheckData
Imports DBUtility

Public Class Frminspect
    Public moid, LineId, prod As String
    Private Sub Frminspect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dtpTime.Text = Date.Now.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
        Me.dtpTime1.Text = Date.Now.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
        Me.dtpTime2.Text = Date.Now.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
        Me.dtpTime3.Text = Date.Now.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
        Me.dtpTime4.Text = Date.Now.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
        Me.dtpTime5.Text = Date.Now.AddHours(-7.5).Date.ToString("yyyy-MM-dd").ToString
        If moid <> "" Then
            txtMOId.ReadOnly = True
            txtMOId.Text = moid
            txtLineId.Text = LineId
            txtprod.Text = prod
            WorkOrderCode()
        Else
            ToolCommodityinspection.Enabled = True
        End If
    End Sub

    Private Sub ToolCommodityinspection_Click(sender As Object, e As EventArgs) Handles ToolCommodityinspection.Click
        Try
            Dim FrmSubmission As New FrmSubmission
            FrmSubmission.moid = Me.txtMOId.Text
            FrmSubmission.LineId = Me.txtLineId.Text
            FrmSubmission.QTY = Me.txtMOQuantity.Text
            FrmSubmission.Prod = Me.txtprod.Text
            'FrmSubmission.ShowDialog()
            If FrmSubmission.ShowDialog() = DialogResult.OK Then
                Dim SPCN0 As String = ""
                SPCN0 = FrmSubmission.SP
                Dim SQL As String = " SELECT SPC2TT,line,workordercode,decode(AUART,'ZP01','量产工单','ZP02','样品工单','ZP03','返工工单','ZP04','委外工单','ZP05','委外返工'," &
                    " 'ZP06','样品工单','SU01','子工单','')command,MaterialCode,nvl(Version,'')Version,StorageQuantity,SPCNO  " &
                    " ,SendTime,nvl(CheckTime,'')CheckTime,decode(Status,'2','生产中','4','待检验','32','检验退回','16','待入库','64','已完成','128','报废')Status, " &
                    " decode(Judgement,'1','OK','2','NG','')Judgement,(ChkEmpCode||'('||ChkEmpName)|| ')'ChkEmpName,(QADeptCode ||'('|| QADeptName)|| ')'QADeptName " &
                    " FROM S2_PRODUCTSTORE where SPCNO ='" + SPCN0 + "'"
                Dim dt As DataTable = DbOracleForSpcHelperSQL.Query(SQL).Tables(0)
                dgvInspectionQuery.DataSource = dt
            End If
            WorkOrderCode()
        Catch ex As Exception
            MessageUtils.ShowError("打开送检异常！")
        End Try

        'ToolReflsh.Enabled = True
        'If Int16.Parse(txtInspectionQuantity.Text) = 0 OrElse Int16.Parse(Int16.Parse(txtInspectionQuantity.Text.Trim()) - Int16.Parse(txtNotInspectionQty.Text.Trim())) < 0 Then
        '    MessageUtils.ShowError("送检数量不能小于0或大于未送检数量！")
        '    Exit Sub
        'End If
        'If txtLineId.Text.Trim = "" Then
        '    MessageUtils.ShowError("线别不能为空！")
        '    Exit Sub
        'End If
        'Dim FQC As FQC.FQC = New FQC.FQC()
        'Dim Model As FQC.SendFQCModel = New FQC.SendFQCModel
        'Model.WorkOrderCode = "" + txtMOId.Text.Trim() + ""
        'Model.Line = "" + txtLineId.Text.Trim() + ""
        'Model.UserCode = "" + VbCommClass.VbCommClass.UseId + ""
        'Model.StorageQuantity = txtInspectionQuantity.Text.Trim()
        'Model.BiaoQianTime = dtpTime.Text.Trim()
        'Model.ProducDate = dtpTime1.Text.Trim()
        'Dim SPC As FQC.BizResultOfSendFQCResultModel = FQC.SendFQC(Model)
        'Dim Code As String = SPC.Code
        'Dim Message As String = SPC.Message
        'Dim Result As FQC.SendFQCResultModel = SPC.Result
        'Dim SPCNO As String = Result.SPCNO
        'If Code = "Error" Then
        '    MessageUtils.ShowError("SPC返回:" + Message)
        '    Exit Sub
        'Else
        '    MessageUtils.ShowInformation("SPC返回:" + SPCNO)
        '    dgvInspectionQuery.DataSource = ""
        '    Dim SQL As String = " SELECT * FROM  OPENQUERY(SPC,'SELECT SPC2TT,line,workordercode,decode(AUART,''ZP01'',''量产工单'',''ZP02'',''样品工单'',''ZP03'',''返工工单'',''ZP04'',''委外工单'',''ZP05'',''委外返工''," &
        '        " ''ZP06'',''样品工单'',''SU01'',''子工单'','''')command,MaterialCode,nvl(Version,'' '')Version,StorageQuantity,SPCNO  " &
        '        " ,SendTime,nvl(CheckTime,'''')CheckTime,decode(Status,''2'',''生产中'',''4'',''待检验'',''32'',''检验退回'',''16'',''待入库'',''64'',''已完成'',''128'',''报废'')Status, " &
        '        " decode(Judgement,''1'',''OK'',''2'',''NG'','' '')Judgement,(ChkEmpCode||''(''||ChkEmpName)|| '')''ChkEmpName,(QADeptCode ||''(''|| QADeptName)|| '')''QADeptName " &
        '        " FROM S2_PRODUCTSTORE where SPCNO =''" + SPCNO + "%''')"
        '    Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)
        '    dgvInspectionQuery.DataSource = dt
        '    WorkOrderCode()
        'End If

    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        empty()
    End Sub
    Private Sub WorkOrderCode()
        Dim SQL As String = "SELECT  a.Moqty,ISNULL(SUM(Cartonqty),0) as SCANQTY ,(a.Moqty-ISNULL(SUM(Cartonqty),0)) AS qty ,a.PartID FROM  m_Mainmo_t  a  " &
                            " LEFT JOIN m_Carton_t b ON b.Moid = a.Moid WHERE a.MOID = '" + txtMOId.Text.Trim() + "' GROUP BY a.Moqty,a.PartID"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)
        txtMOQuantity.Text = dt.Rows(0)(0).ToString()
        txtMOAlreadyQty.Text = dt.Rows(0)(1).ToString()
        txtNotAlreadyQty.Text = dt.Rows(0)(2).ToString()
        txtInspectionQuantity.Text = dt.Rows(0)(2).ToString()
        txtprod.Text = dt.Rows(0)(3).ToString()
        SQL = "SELECT nvl(SUM(StorageQuantity),0) AS StorageQuantity FROM  S2_PRODUCTSTORE  WHERE WorkOrderCode ='" + txtMOId.Text.Trim() + "'AND Status != '128' "
        Dim dr As DataTable = DbOracleForSpcHelperSQL.Query(SQL).Tables(0)
        txtAlreadyInspectionQty.Text = dr.Rows(0)(0).ToString()
        txtNotInspectionQty.Text = Int64.Parse(txtMOQuantity.Text) - Int64.Parse(txtAlreadyInspectionQty.Text)
    End Sub
    Private Sub empty()
        txtMOId.ReadOnly = False
        ToolCommodityinspection.Enabled = False
        ToolReflsh.Enabled = True
        txtMOId.Text = ""
        txtLineId.Text = ""
        txtMOQuantity.Text = ""
        txtMOAlreadyQty.Text = ""
        txtNotAlreadyQty.Text = ""
        txtInspectionQuantity.Text = ""
        txtAlreadyInspectionQty.Text = ""
        txtNotInspectionQty.Text = ""
        RichTextBoxEx1.Text = ""
    End Sub

    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        If txtMOId.Text.Trim() = "" And txtLineId.Text.Trim() = "" Then
            MessageUtils.ShowError("请至少输入一个查询条件！")
            Exit Sub
        End If
        Dim sql As String = ""
        If txtLineId.Text.Trim() = "" Then
            sql = "SELECT SPC2TT,line,workordercode,decode(AUART,'ZP01','量产工单','ZP02','样品工','ZP03','返工工单','ZP04','委外工单','ZP05','委外返工'," &
                          " 'ZP06','样品工单','SU01','子工单','')command,MaterialCode,nvl(Version,'')Version,StorageQuantity,SPCNO  " &
                          " ,SendTime,nvl(CheckTime,'')CheckTime,decode(Status,'2','生产中','4','待检验','32','检验退回','16','待入库','64','已完成','128','报废')Status, " &
                          " decode(Judgement,'1','OK','2','NG','')Judgement,(ChkEmpCode||'('||ChkEmpName)|| ')'ChkEmpName,(QADeptCode ||'('|| QADeptName)|| ')'QADeptName " &
                          " FROM S2_PRODUCTSTORE where workordercode like '" + txtMOId.Text.Trim() + "%'and SendTime >= to_date('" + dtpTime2.Text + " 00:00:00','yyyy/MM/dd hh24:mi:ss')  and SendTime <= to_date('" + dtpTime3.Text + " 23:59:59','yyyy/MM/dd hh24:mi:ss')"
        End If
        If txtMOId.Text.Trim() = "" Then
            sql = "SELECT SPC2TT,line,workordercode,decode(AUART,'ZP01','量产工单','ZP02','样品工单','ZP03','返工工单','ZP04','委外工单','ZP05','委外返工'," &
                          " 'ZP06','样品工单','SU01','子工单','')command,MaterialCode,nvl(Version,'')Version,StorageQuantity,SPCNO  " &
                          " ,SendTime,nvl(CheckTime,'')CheckTime,decode(Status,'2','生产中','4','待检验','32','检验退回','16','待入库','64','已完成','128','报废')Status, " &
                          " decode(Judgement,'1','OK','2','NG','')Judgement,(ChkEmpCode||'('||ChkEmpName)|| ')'ChkEmpName,(QADeptCode ||'('|| QADeptName)|| ')'QADeptName " &
                          " FROM S2_PRODUCTSTORE where line='" + txtLineId.Text.Trim() + "'and SendTime >= to_date('" + dtpTime2.Text + " 00:00:00','yyyy/MM/dd hh24:mi:ss')  and SendTime <= to_date('" + dtpTime3.Text + " 23:59:59','yyyy/MM/dd hh24:mi:ss')"
        End If
        If txtLineId.Text.Trim() <> "" And txtMOId.Text.Trim() <> "" Then
            sql = "SELECT SPC2TT,line,workordercode,decode(AUART,'ZP01','量产工单','ZP02','样品工单','ZP03','返工工单','ZP04','委外工单','ZP05','委外返工'," &
                        " 'ZP06','样品工单','SU01','子工单','')command,MaterialCode,nvl(Version,'')Version,StorageQuantity,SPCNO  " &
                          " ,SendTime,nvl(CheckTime,'')CheckTime,decode(Status,'2','生产中','4','待检验','32','检验退回','16','待入库','64','已完成','128','报废')Status, " &
                          " decode(Judgement,'1','OK','2','NG','')Judgement,(ChkEmpCode||'('||ChkEmpName)|| ')'ChkEmpName,(QADeptCode ||'('|| QADeptName)|| ')'QADeptName " &
                        " FROM S2_PRODUCTSTORE where workordercode like'" + txtMOId.Text.Trim() + "%'and line = '" + txtLineId.Text.Trim() + "'and SendTime >= to_date('" + dtpTime2.Text + "  00:00:00','yyyy/mm/dd hh24:mi:ss')  and SendTime <= to_date('" + dtpTime3.Text + " 23:59:59','yyyy/mm/dd hh24:mi:ss')"
        End If
        'sql = "SELECT SPC2TT,line,workordercode,decode(AUART,'ZP01','量产工单','ZP02','样品工单','ZP03','返工工单','ZP04','委外工单','ZP05','委外返工'," &
        '                " 'ZP06','样品工单','SU01','子工单','')command,MaterialCode,nvl(Version,' ')Version,StorageQuantity,SPCNO  " &
        '                " ,SendTime,nvl(CheckTime,'')CheckTime,decode(Status,'2','生产中','4','待检验','32','检验退回','16','待入库','64','已完成','128','报废')Status, " &
        '                " decode(Judgement,'1','OK','2','NG','')Judgement,(ChkEmpCode||'('||ChkEmpName)|| ')'ChkEmpName,(QADeptCode ||'('|| QADeptName)|| ')'QADeptName " &
        '                " FROM S2_PRODUCTSTORE where workordercode like'" + txtMOId.Text.Trim() + "%'and line = '" + txtLineId.Text.Trim() + "'and SendTime >= to_date('" + dtpTime2.Text + "  00:00:00','yyyy/mm/dd hh24:mi:ss')  and SendTime <= to_date('" + dtpTime3.Text + " 23:59:59','yyyy/mm/dd hh24:mi:ss')" &
        '                " and CheckTime>=to_date('" + dtpTime4.Text + " 00:00:00','yyyy/MM/dd hh24:mi:ss') and CheckTime<=to_date('" + dtpTime5.Text + " 23:59:59','yyyy/MM/dd hh24:mi:ss')"
        Dim dt As DataTable = DbOracleForSpcHelperSQL.Query(sql).Tables(0)
        'Dim DT As DataTable = DbOracleForSpcHelperSQL.Query(sql).Tables(0)
        dgvInspectionQuery.DataSource = dt
    End Sub

    Private Sub txtMOId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMOId.KeyDown
        If e.KeyValue <> 13 Then
            Return
        Else
            Dim sql As String = "SELECT Lineid FROM m_Mainmo_t WHERE Moid = '" + txtMOId.Text.Trim() + "'"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count = 0 Then
                MessageUtils.ShowError("工单不存在！")
                Exit Sub
            Else
                txtLineId.Text = dt.Rows(0)(0).ToString()
                ToolCommodityinspection.Enabled = True
                WorkOrderCode()
                Dim strsql As String = "SELECT * FROM  OPENQUERY([EDSAP],'SELECT * FROM  ZTPP0017  WHERE AUFNR =''" + Me.txtMOId.Text.Trim() + "''AND STATUS != ''X''AND MANDT=''888''') "
                Dim dr As DataTable = DbOperateUtils.GetDataTable(strsql)
                If dr.Rows.Count = 0 Then
                    MessageUtils.ShowError("SAP工单已结案不允许继续送检！")
                    ToolCommodityinspection.Enabled = False
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        If Me.dgvInspectionQuery.Rows.Count = 0 OrElse Me.dgvInspectionQuery.CurrentRow Is Nothing Then
            Exit Sub
        End If
        Dim index As Int16 = dgvInspectionQuery.CurrentRow.Index
        Dim FQC As FQC.FQC = New FQC.FQC()
        Dim DelFQC As FQC.DelFQCModel = New FQC.DelFQCModel
        DelFQC.SPCNO = "" + dgvInspectionQuery.Rows(index).Cells("InspectionTime").Value + ""
        DelFQC.UserCode = "" + VbCommClass.VbCommClass.UseId + ""
        Dim SPCDel As FQC.BizResult = FQC.DelFQC(DelFQC)
        Dim Code As String = SPCDel.Code
        Dim Message As String = SPCDel.Message
        If Code = "Error" Then
            MessageUtils.ShowError("SPC返回:" + Message)
            Exit Sub
        Else
            dgvInspectionQuery.Rows.Remove(dgvInspectionQuery.Rows(index))
            WorkOrderCode()
            MessageUtils.ShowInformation("删除成功")
        End If
    End Sub
End Class