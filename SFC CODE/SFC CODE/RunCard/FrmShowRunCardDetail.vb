Imports System
Imports System.Data
Imports MainFrame.SysDataHandle
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmShowRunCardDetail
    Private frmShowReport As FrmShowRunCard

    Private Sub FrmShowRunCardDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPn.Select()
        cboReportType.Items.Clear()
        cboReportType.Items.Add("工艺流程卡")
        cboReportType.Items.Add("工艺流程卡明细表")
        cboReportType.Items.Insert(0, "")
        ' FrmShowRunCard.InitRDoc()
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        Try
            If Not CheckBasic() Then
                Exit Sub
            End If
            If txtPn.Text <> "" Then
                frmShowReport = New FrmShowRunCard(txtPn.Text)
            Else
                frmShowReport = New FrmShowRunCard(GetPnByMo())
            End If
            frmShowReport.reportInputParametersVar.showPrintButton = False
            frmShowReport.reportInputParametersVar.reportTypeFlag = IIf(cboReportType.SelectedItem = "工艺流程卡明细表", FrmShowRunCard.ReportType.RunCardDetailReport, FrmShowRunCard.ReportType.RunCardReport)
            frmShowReport.reportInputParametersVar.printTypeFlag = FrmShowRunCard.PrintType.ShowReport
            frmShowReport.reportInputParametersVar.showExportButton = True
            If frmShowReport.reportInputParametersVar.reportTypeFlag = FrmShowRunCard.ReportType.RunCardDetailReport Then
                Using dt As DataTable = frmShowReport.GetRunCardDetailListDataTable()
                    If dt.Rows.Count <= 1 Then
                        MessageBox.Show("该料件下面没有要显示的子件料,请确认输入的是成套的料件编号或是成套的工单编号！！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    dt.Rows.RemoveAt(dt.Rows.Count - 1)
                    GetRunCardDetailListParameters(dt)
                    Using dtResult As DataTable = ChangeDataTableStyle(dt)
                        dgvRunCardDetail.DataSource = dtResult
                    End Using
                    dgvRunCardDetail.ColumnHeadersVisible = False
                    dgvRunCardDetail.Columns(RunCardDetailGrid.ID).Width = 60
                    dgvRunCardDetail.Columns(RunCardDetailGrid.Qty).Width = 150
                    dgvRunCardDetail.Columns(RunCardDetailGrid.AssemblyHourPreMo).Width = 190
                    dgvRunCardDetail.Columns(RunCardDetailGrid.Pn).Width = 150
                    dgvRunCardDetail.Rows(2).DefaultCellStyle = style
                    dgvRunCardDetail.Columns(0).DefaultCellStyle = style
                    TabControl1.SelectedIndex = 1
                End Using
            Else
                Using dt As DataTable = frmShowReport.GetRunCardDataTable()
                    If dt.Rows.Count <= 1 Then
                        MessageBox.Show("该料件还没有维护工艺流程卡,请先维护工艺流程卡！！或输入的是成套料件或成套工单,请确认！！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    dt.Rows.RemoveAt(dt.Rows.Count - 1)
                    GetRunCardReportParameters(dt)
                    Using dtResult As DataTable = ChangeRunCardDataTableStyle(dt)
                        dgvRunCard.DataSource = dtResult
                    End Using
                    dgvRunCard.ColumnHeadersVisible = False
                    dgvRunCard.Columns(RunCardStyleGrid.ID).Width = 60
                    dgvRunCard.Columns(RunCardStyleGrid.WorkStationContent).Width = 130
                    dgvRunCard.Columns(RunCardStyleGrid.WorkHour).Width = 60
                    dgvRunCard.Columns(RunCardStyleGrid.Equipment).Width = 120
                    dgvRunCard.Columns(RunCardStyleGrid.ProcessStandard).Width = 250
                    dgvRunCard.Columns(RunCardStyleGrid.Remark).Width = 200
                    dgvRunCard.Columns(RunCardStyleGrid.RawInfo).Width = 200
                    dgvRunCard.Columns(RunCardStyleGrid.EquipmentInfo).Width = 200
                    TabControl1.SelectedIndex = 0
                    dgvRunCard.Rows(2).DefaultCellStyle = style
                    dgvRunCard.Rows(dgvRunCard.Rows.Count - 2).DefaultCellStyle = style
                    dgvRunCard.Columns(0).DefaultCellStyle = style
                End Using
            End If
            'frmShowReport.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function CheckBasic() As Boolean
        If txtPn.Text = "" Then
            MessageBox.Show("请输入料件编号", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cboReportType.SelectedItem = "" Then
            MessageBox.Show("请选择报表类型", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Public Function GetPnByMo() As String
        Dim sqlConn As New SysDataBaseClass
        Dim sqlString As String = "SELECT PARTID FROM M_RUNCARDWORKORDER_T WHERE MOID='" & txtMoNo.Text & "'AND STATUS<>2"
        Using dt As DataTable = sqlConn.GetDataTable(sqlString)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0).ToString
            Else
                MessageBox.Show("工单编号不存在或是已分批结案，请确认！！！！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Using
        Return ""
    End Function

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Assort As String = Nothing
    Private TotalHourPreMo As String = Nothing
    Private QTY As String = Nothing
    Private TotalHourPreMoSum As String = Nothing
    Private PreAssemblyHourPreChildSum As String = Nothing
    Private AssemblyHourPreChildSum As String = Nothing
    Private MadeHourPreChildSum As String = Nothing
    Private Version As String = Nothing

    Private Sub GetRunCardDetailListParameters(ByVal dt As DataTable)
        Version = GetPnVersion(txtPn.Text)
        If dt.Rows.Count > 0 Then
            Assort = dt.Compute("sum(QTY)", "") * 15
            TotalHourPreMoSum = dt.Compute("sum(TotalHourPreMo)", "") + 28 + dt.Compute("sum(QTY)", "") * 15
            PreAssemblyHourPreChildSum = dt.Compute("sum(PreAssemblyHourPreChild)", "")
            AssemblyHourPreChildSum = (dt.Compute("sum(TotalHourPreMo)", "") + 28 + dt.Compute("sum(QTY)", "") * 15) - dt.Compute("sum(PreAssemblyHourPreChild)", "") - dt.Compute("sum(MadeHourPreChild)", "")
            MadeHourPreChildSum = dt.Compute("sum(MadeHourPreChild)", "")
        Else
            Assort = 0
            TotalHourPreMoSum = ""
            PreAssemblyHourPreChildSum = ""
            AssemblyHourPreChildSum = ""
            MadeHourPreChildSum = ""
        End If
    End Sub

    Private Function GetPnVersion(ByVal rpn As String) As String
        Dim oConn As New SysDataBaseClass
        Dim sql As String = "SELECT A.FORMAT FROM M_RUNCARDBOMINFO_T A,M_RUNCARDPARTNUMBER_T B WHERE B.PARTNUMBER='" & rpn & "' AND B.ID=A.PARENTPARTID"
        Using dt As DataTable = oConn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return GetVersion(dt.Rows(0)(0))
            End If
        End Using
        Return ""
    End Function

    Private Function GetVersion(ByVal format As String) As String
        Dim arr() As String
        'Dim reg As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("[\u4e00-\u9fa5]")
        'Dim reg1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^[A-Z]{0,2}([0-9]{0,2})?$")
        arr = format.Split("-")
        If arr.Length > 1 Then 'AndAlso Not reg.IsMatch(arr(arr.Length - 1)) And reg1.IsMatch(arr(arr.Length - 1)) Then
            Return arr(arr.Length - 1)
            'ElseIf arr.Length > 2 AndAlso reg1.IsMatch(arr(arr.Length - 2)) Then
            'Return arr(arr.Length - 2)
            'ElseIf arr.Length > 3 AndAlso reg1.IsMatch(arr(arr.Length - 3)) Then
            'Return arr(arr.Length - 3)
            'ElseIf arr.Length > 4 AndAlso reg1.IsMatch(arr(arr.Length - 4)) Then
            'Return arr(arr.Length - 4)
        End If
        Return ""
    End Function

    Private Function ChangeDataTableStyle(ByVal dtRaw As DataTable) As DataTable
        Using dt As DataTable = New DataTable
            For index As Integer = 0 To RunCardDetailGrid.Remark
                dt.Columns.Add(dtRaw.Columns(index).ColumnName, GetType(String))
            Next
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = "工单量:" + ""
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.AssemblyHourPreMo) = "产品图号:" + txtPn.Text
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = "工单号:" + ""
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.AssemblyHourPreMo) = "版次:" + Version
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ID) = "ID"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Pn) = "子件"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "子件版本"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "配置"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = "子件总工时"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = "子件前加工"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.MadeHourPreMo) = "子件成型"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.AssemblyHourPreMo) = "子件产线"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Remark) = "备注项"
            For rowIndex As Integer = 0 To dtRaw.Rows.Count - 1
                dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ID) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.ID)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Pn) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.Pn)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.Version)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.Qty)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.TotalHourPreChild)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = dtRaw.Rows(rowIndex)(6)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.MadeHourPreMo) = dtRaw.Rows(rowIndex)(8)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.AssemblyHourPreMo) = dtRaw.Rows(rowIndex)(10)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Remark) = ""
            Next
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "贴标签:"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = "3"
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "入/封胶袋(配套):"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = Assort
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "终检:"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = "10"
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "包装:"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = "15"
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "总计:"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = TotalHourPreMoSum
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = PreAssemblyHourPreChildSum
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.MadeHourPreMo) = MadeHourPreChildSum
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.AssemblyHourPreMo) = AssemblyHourPreChildSum
            Return dt
        End Using
    End Function

    Private Enum RunCardDetailGrid
        ID = 0
        Pn
        Version
        Qty
        TotalHourPreChild
        PreAssemblyHourPreMo
        MadeHourPreMo
        AssemblyHourPreMo
        Remark
    End Enum

    Private RunCardGraphPar As String = Nothing
    Private RunCardVersionPar As String = Nothing
    Private RunCardShapePar As String = Nothing
    Private RunCardTotalHourPar As String = Nothing
    Private RunCardPreAssemblyPar As String = Nothing
    Private RunCardAssemblyPar As String = Nothing
    Private RunCardDescriptionPar As String = Nothing
    Private RunCardDescription1Par As String = Nothing
    Private RunCardStatusPar As String = Nothing
    Private RunCardCreateUserPar As String = Nothing
    Private RunCardCreateDatePar As String = Nothing
    Private RunCardApprovalPar As String = Nothing
    Private RunCardCheckPar As String = Nothing
    Private RunCardMadePar As String = Nothing

    Private Sub GetRunCardReportParameters(ByVal dt As DataTable)
        If dt.Rows.Count > 1 Then
            '图号

            RunCardGraphPar = txtPn.Text
            '版本
            RunCardVersionPar = dt.Rows(0)(RunCardEnum.DrawingVer).ToString()
            '形态
            RunCardShapePar = dt.Rows(0)(RunCardEnum.Shape).ToString()
            '总工时
            RunCardTotalHourPar = Convert.ToDouble(dt.Compute("sum(LaborHour)", "")) * (1 + 0.005 * (dt.Rows.Count))
            '前加工
            If dt.Select("SECTIONNAME = 1").Length > 0 Then
                RunCardPreAssemblyPar = dt.Compute("sum(LaborHour)", "SECTIONNAME = 1")
            Else
                RunCardPreAssemblyPar = dt.Compute("sum(LaborHour)", "")
            End If
            '成型
            If dt.Select("SECTIONNAME = 3").Length > 0 Then
                RunCardAssemblyPar = dt.Compute("sum(LaborHour)", "SECTIONNAME = 3")
            Else
                RunCardAssemblyPar = ""
            End If
            '描述
            RunCardDescriptionPar = dt.Rows(0)(RunCardEnum.Description).ToString
            '规格 
            RunCardDescription1Par = dt.Rows(0)(RunCardEnum.Description1).ToString
            '状态
            RunCardStatusPar = IIf(dt.Rows(0)(RunCardEnum.Status).ToString = "0", "制作中", IIf(dt.Rows(0)(RunCardEnum.Status).ToString = "1", "已生效", "待审核"))
            '创建人
            RunCardCreateUserPar = dt.Rows(0)(RunCardEnum.UserId).ToString
            '创建日期
            RunCardCreateDatePar = dt.Rows(0)(RunCardEnum.Intime).ToString
        Else
            '图号
            RunCardGraphPar = ""
            '版本
            RunCardVersionPar = ""
            '形态
            RunCardShapePar = ""
            '总工时
            RunCardTotalHourPar = ""
            '前加工
            RunCardPreAssemblyPar = ""
            '成型
            RunCardAssemblyPar = ""
            '描述
            RunCardDescriptionPar = ""
            '规格
            RunCardDescription1Par = ""
            '状态
            RunCardStatusPar = ""
            '创建人
            RunCardCreateUserPar = ""
            '创建日期
            RunCardCreateDatePar = ""
        End If
        '核准
        RunCardApprovalPar = ""
        '审核
        RunCardCheckPar = ""
        '制作
        RunCardMadePar = ""
    End Sub

    Private Enum RunCardEnum
        DrawingNo = 0
        DrawingVer
        Shape
        ID
        WorkStationContent
        LaborHour
        Equipment
        ProcessStandard
        Comment
        Operater
        IPQC
        SectionName
        Description1
        Description
        Status
        UserId
        Intime
        DID
        RawInfo
        EquipmentInfo
    End Enum

    Private Enum RunCardStyleGrid
        ID = 0
        WorkStationContent
        WorkHour
        Equipment
        ProcessStandard
        Remark
        RawInfo
        EquipmentInfo
    End Enum

    Private Function ChangeRunCardDataTableStyle(ByVal dtRaw As DataTable) As DataTable
        Using dt As DataTable = New DataTable
            For index As Integer = 0 To RunCardStyleGrid.EquipmentInfo
                dt.Columns.Add(dtRaw.Columns(index).ColumnName, GetType(String))
            Next
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ID) = "图号:"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkStationContent) = txtPn.Text
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Equipment) = "形态:"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ProcessStandard) = RunCardShapePar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Remark) = "描述:" + RunCardDescriptionPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.RawInfo) = "创建人"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.EquipmentInfo) = RunCardCreateUserPar
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ID) = "版本:"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkStationContent) = RunCardVersionPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Equipment) = "规格:"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ProcessStandard) = RunCardDescription1Par
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Remark) = "状态:" + RunCardStatusPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.RawInfo) = "创建时间"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.EquipmentInfo) = RunCardCreateDatePar
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ID) = "序号"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkStationContent) = "工站内容"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkHour) = "工时(s)"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Equipment) = "设备/治具"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ProcessStandard) = "工艺标准"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Remark) = "备注"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.RawInfo) = "物料信息"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.EquipmentInfo) = "工装信息"
            For rowIndex As Integer = 0 To dtRaw.Rows.Count - 1
                dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ID) = dtRaw.Rows(rowIndex)(RunCardEnum.ID)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkStationContent) = dtRaw.Rows(rowIndex)(RunCardEnum.WorkStationContent)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkHour) = dtRaw.Rows(rowIndex)(RunCardEnum.LaborHour)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Equipment) = dtRaw.Rows(rowIndex)(RunCardEnum.Equipment)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ProcessStandard) = dtRaw.Rows(rowIndex)(RunCardEnum.ProcessStandard)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.Remark) = dtRaw.Rows(rowIndex)(RunCardEnum.Comment)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.RawInfo) = dtRaw.Rows(rowIndex)(RunCardEnum.RawInfo)
                dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.EquipmentInfo) = dtRaw.Rows(rowIndex)(RunCardEnum.EquipmentInfo)
            Next
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkStationContent) = "总工时(s):"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkHour) = RunCardTotalHourPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ProcessStandard) = "前加工(s):" + RunCardPreAssemblyPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.RawInfo) = "成型(s):" + RunCardAssemblyPar
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ID) = "核准:"
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.WorkStationContent) = RunCardApprovalPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.ProcessStandard) = "审核:" + RunCardCheckPar
            dt.Rows(dt.Rows.Count - 1)(RunCardStyleGrid.RawInfo) = "制作:" + RunCardMadePar
            Return dt
        End Using
    End Function

    Private style As New DataGridViewCellStyle() With {.Font = New Font("Tahoma", 10.5, FontStyle.Bold), .Alignment = DataGridViewContentAlignment.MiddleCenter}
End Class
