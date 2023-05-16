Imports MainFrame
Imports MainFrame.SysCheckData

''' <summary>
''' 料件基础资料-测试项目规格上下限维护
''' </summary>
''' <remarks>
''' Created by Aimee on 20180329
''' </remarks>
Public Class FrmPartTestRules

    Private toolStatus As EnumTools = EnumTools.Initial
    Private unitDesEnValid As Boolean = False
    Private unitDesCnValid As Boolean = False

#Region "枚举类型"
    '枚举：查询的列
    Private Enum EnumPartTestRules
        ''' <summary>
        ''' 立讯料件
        ''' </summary>
        ''' <remarks></remarks>
        PartNumber

        ''' <summary>
        ''' 客户料号
        ''' </summary>
        ''' <remarks></remarks>
        CusPartNumber

        ''' <summary>
        ''' 测试项目
        ''' </summary>
        ''' <remarks></remarks>
        TestItem

        ''' <summary>
        ''' 测试回路
        ''' </summary>
        ''' <remarks></remarks>
        TestLoop

        ''' <summary>
        ''' 规格下限
        ''' </summary>
        ''' <remarks></remarks>
        SpecLowerLimit

        ''' <summary>
        ''' 规格上限
        ''' </summary>
        ''' <remarks></remarks>
        SpecUpperLimit

        ''' <summary>
        ''' 单位(0.xx)
        ''' </summary>
        ''' <remarks></remarks>
        Unit

        ''' <summary>
        ''' 单位(英文)
        ''' </summary>
        ''' <remarks></remarks>
        UnitDesEn

        ''' <summary>
        ''' 单位(中文)
        ''' </summary>
        ''' <remarks></remarks>
        UnitDesCn

        ''' <summary>
        ''' 测试条件
        ''' </summary>
        ''' <remarks></remarks>
        TestCondition

        ''' <summary>
        ''' 有效否
        ''' </summary>
        ''' <remarks></remarks>
        Usey

        ''' <summary>
        ''' 设置人员
        ''' </summary>
        ''' <remarks></remarks>
        ModifyBy

        ''' <summary>
        ''' 设置时间
        ''' </summary>
        ''' <remarks></remarks>
        ModifyTime
    End Enum

    '枚举：操作状态（新增、修改、修改客户料号、初始）
    Private Enum EnumTools
        Initial
        Add
        Edit
        Customer
    End Enum

    '枚举：测试项目
    Private Enum EnumTestItem
        ''' <summary>
        ''' 阻抗
        ''' </summary>
        ''' <remarks></remarks>
        Impedance

        ''' <summary>
        ''' 绝缘
        ''' </summary>
        ''' <remarks></remarks>
        Insulation

        ''' <summary>
        ''' 耐压
        ''' </summary>
        ''' <remarks></remarks>
        ProofPressure
    End Enum

    '枚举：单位
    Private Enum EnumUnit
        ''' <summary>
        ''' 自定义
        ''' </summary>
        ''' <remarks></remarks>
        Custom
        mV
        V
        KV
        MV_
        mΩ
        Ω
        KΩ
        MΩ_
        mA
        A
        KA
        MA_
    End Enum
#End Region

#Region "触发事件"
    '页面加载
    Private Sub FrmPartTestRules_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Initialization()
        EnableControls()
        LoadDataToDatagridview("", 100)
    End Sub

    '测试项目变更
    Private Sub cboTestItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTestItem.SelectedIndexChanged
        Try
            If cboTestItem.Text = "" OrElse toolStatus = EnumTools.Initial Then Exit Sub
            Dim testItem As EnumTestItem = [Enum].Parse(GetType(EnumTestItem), cboTestItem.Text.Split(".")(0))
            cboTestLoop.Text = "1"
            txtTestLoopDes.Text = ""
            cboTestLoop.Enabled = False
            If testItem = EnumTestItem.Impedance Then
                cboTestLoop.Enabled = True
                txtTestLoopDes.Text = "VBus+GND"
                cboUnit.Text = CInt(EnumUnit.mΩ).ToString + ".mΩ"
            ElseIf testItem = EnumTestItem.Insulation Then
                cboUnit.Text = CInt(EnumUnit.MΩ_).ToString + ".MΩ"
            ElseIf testItem = EnumTestItem.ProofPressure Then
                cboUnit.Text = CInt(EnumUnit.mA).ToString + ".mA"
            Else
                cboUnit.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageUtils.ShowInformation("系统异常，请联系值班人员处理！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartTestRules", "TestItem_SelectedIndexChanged", "sys")
        End Try
    End Sub

    '单位变更
    Private Sub cboUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUnit.SelectedIndexChanged
        Try
            If cboUnit.Text = "" Then Exit Sub
            Dim unit As String = cboUnit.Text.Split(".")(0)
            txtUnitDesEn.ForeColor = Color.Black
            txtUnitDesCn.ForeColor = Color.Black
            txtUnitDesEn.Enabled = False
            txtUnitDesCn.Enabled = False
            unitDesEnValid = True
            unitDesCnValid = True

            Select Case [Enum].Parse(GetType(EnumUnit), unit)
                Case EnumUnit.mV
                    txtUnitDesEn.Text = "mV"
                    txtUnitDesCn.Text = "毫伏特"
                Case EnumUnit.V
                    txtUnitDesEn.Text = "V"
                    txtUnitDesCn.Text = "伏特"
                Case EnumUnit.KV
                    txtUnitDesEn.Text = "KV"
                    txtUnitDesCn.Text = "千伏特"
                Case EnumUnit.MV_
                    txtUnitDesEn.Text = "MV"
                    txtUnitDesCn.Text = "兆伏特"
                Case EnumUnit.mΩ
                    txtUnitDesEn.Text = "mΩ"
                    txtUnitDesCn.Text = "毫欧姆"
                Case EnumUnit.Ω
                    txtUnitDesEn.Text = "Ω"
                    txtUnitDesCn.Text = "欧姆"
                Case EnumUnit.KΩ
                    txtUnitDesEn.Text = "KΩ"
                    txtUnitDesCn.Text = "千欧姆"
                Case EnumUnit.MΩ_
                    txtUnitDesEn.Text = "MΩ"
                    txtUnitDesCn.Text = "兆欧姆"
                Case EnumUnit.mA
                    txtUnitDesEn.Text = "mA"
                    txtUnitDesCn.Text = "毫安"
                Case EnumUnit.A
                    txtUnitDesEn.Text = "A"
                    txtUnitDesCn.Text = "安"
                Case EnumUnit.KA
                    txtUnitDesEn.Text = "KA"
                    txtUnitDesCn.Text = "千安"
                Case EnumUnit.MA_
                    txtUnitDesEn.Text = "MA"
                    txtUnitDesCn.Text = "兆安"
                Case Else
                    txtUnitDesEn.Enabled = True
                    txtUnitDesEn.Text = "英文符号"
                    txtUnitDesCn.Enabled = True
                    txtUnitDesCn.Text = "中文描述"
                    txtUnitDesCn.ForeColor = Color.LightGray
                    txtUnitDesEn.ForeColor = Color.LightGray
                    unitDesEnValid = False
                    unitDesCnValid = False
            End Select
        Catch ex As Exception
            MessageUtils.ShowInformation("系统异常，请联系值班人员处理！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartTestRules", "Unit_SelectedIndexChanged", "sys")
        End Try
    End Sub

    '关闭
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            LoadDataToDatagridview(GetSqlWhere, 1000)
        Catch ex As Exception
            MessageUtils.ShowInformation("系统异常，请联系值班人员处理！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartTestRules", "Query_Click", "sys")
        End Try
    End Sub

    '新增
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        toolStatus = EnumTools.Add
        Initialization()
        EnableControls()
    End Sub

    '修改
    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        Try
            If dgvPartTestRules.RowCount < 1 OrElse dgvPartTestRules.CurrentRow.Index < 0 Then Exit Sub
            Dim row As DataGridViewRow = dgvPartTestRules.CurrentRow
            Dim testLoop As String = row.Cells(EnumPartTestRules.TestLoop).Value.ToString
            Dim unit As String = row.Cells(EnumPartTestRules.Unit).Value.ToString
            If unit.StartsWith("0") Then unit = "0.自定义"

            txtPartNumber.Text = row.Cells(EnumPartTestRules.PartNumber).Value.ToString
            txtCusPartNumber.Text = row.Cells(EnumPartTestRules.CusPartNumber).Value.ToString
            cboTestItem.Text = row.Cells(EnumPartTestRules.TestItem).Value.ToString
            cboTestLoop.Text = testLoop.Split(".")(0)
            If testLoop.Split(".").Length > 1 Then txtTestLoopDes.Text = testLoop.Split(".")(1)
            txtTestCondition.Text = row.Cells(EnumPartTestRules.TestCondition).Value.ToString
            txtSpecLowerLimit.Text = row.Cells(EnumPartTestRules.SpecLowerLimit).Value.ToString
            txtSpecUpperLimit.Text = row.Cells(EnumPartTestRules.SpecUpperLimit).Value.ToString
            cboUnit.Text = unit
            txtUnitDesEn.Text = row.Cells(EnumPartTestRules.UnitDesEn).Value.ToString
            txtUnitDesCn.Text = row.Cells(EnumPartTestRules.UnitDesCn).Value.ToString

            toolStatus = EnumTools.Edit
            EnableControls()
            txtPartNumber.Enabled = False
            txtCusPartNumber.Enabled = False
            cboTestItem.Enabled = False
            cboTestLoop.Enabled = False
            txtUnitDesEn.Enabled = True
            txtUnitDesCn.Enabled = True
            txtUnitDesEn.ForeColor = Color.Black
            txtUnitDesCn.ForeColor = Color.Black
            unitDesEnValid = True
            unitDesCnValid = True
            If Not unit.StartsWith("0") Then txtUnitDesEn.Enabled = False : txtUnitDesCn.Enabled = False
        Catch ex As Exception
            MessageUtils.ShowInformation("系统异常，请联系值班人员处理！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartTestRules", "Edit_Click", "sys")
        End Try
    End Sub

    '修改客户料号
    Private Sub toolCustomer_Click(sender As Object, e As EventArgs) Handles toolCustomer.Click
        toolStatus = EnumTools.Customer
        EnableControls()
    End Sub

    '新增、修改后保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim ds As DataSet
        Try
            Dim partNumber As String = txtPartNumber.Text.Trim
            Dim cusPartNumber As String = txtCusPartNumber.Text.Trim
            Dim testItem As String = cboTestItem.Text.Trim
            Dim testLoop As String = cboTestLoop.Text.Trim
            Dim testLoopDes As String = txtTestLoopDes.Text.Trim
            Dim testCondition As String = txtTestCondition.Text.Trim
            Dim specLowerLimit As String = txtSpecLowerLimit.Text.Trim
            Dim specUpperLimit As String = txtSpecUpperLimit.Text.Trim
            Dim unit As String = cboUnit.Text.Trim
            Dim unitDesEn As String = txtUnitDesEn.Text.Trim
            Dim unitDesCn As String = txtUnitDesCn.Text.Trim

            If partNumber = "" Then
                MessageUtils.ShowInformation("立讯料号不能为空！") : Exit Sub
            ElseIf cusPartNumber = "" Then
                MessageUtils.ShowInformation("客户料号不能为空！") : Exit Sub
            End If
            If toolStatus = EnumTools.Customer Then GoTo SavePartTestRules
            If testItem = "" OrElse testItem.Split(".").Length <> 2 Then
                MessageUtils.ShowInformation("请先选择测试项目！") : Exit Sub
            ElseIf testLoop = "" Then
                MessageUtils.ShowInformation("请先选择测试回路！") : Exit Sub
            ElseIf specLowerLimit = "" AndAlso specUpperLimit = "" Then
                MessageUtils.ShowInformation("规格下限和规格上限不能同时为空！") : Exit Sub
            ElseIf ((specLowerLimit <> "" AndAlso Not IsNumeric(specLowerLimit)) OrElse (specUpperLimit <> "" AndAlso Not IsNumeric(specUpperLimit))) Then
                MessageUtils.ShowInformation("规格下/上限只需填写数值，不需填写单位！") : Exit Sub
            ElseIf unit = "" OrElse unit.Split(".").Length <> 2 Then
                MessageUtils.ShowInformation("请先选择单位！") : Exit Sub
            ElseIf unit.StartsWith("0") Then
                If unitDesEn = "" OrElse Not unitDesEnValid Then MessageUtils.ShowInformation("单位(英文符号)不能为空！") : Exit Sub
                If unitDesCn = "" OrElse Not unitDesCnValid Then MessageUtils.ShowInformation("单位(中文描述)不能为空！") : Exit Sub
            ElseIf testCondition = "" Then
                MessageUtils.ShowInformation("测试条件不能为空！") : Exit Sub
            End If

SavePartTestRules:
            Dim strSql As String = "SELECT 1"
            If SysMessageClass.UseName = "" Then GetUserName()
            Select Case toolStatus
                Case EnumTools.Add
                    strSql = "SELECT TOP 1 1 FROM m_PartContrast_t WHERE TAvcPart='" & partNumber & "';"
                    strSql += "SELECT 1 FROM m_PartTestRules_t WHERE (PartNumber='" & partNumber & "' AND CusPartNumber!='" & cusPartNumber _
                        & "') OR (PartNumber!='" & partNumber & "' AND CusPartNumber='" & cusPartNumber & "');"
                    strSql += "SELECT 1 FROM m_PartTestRules_t WHERE PartNumber='" & partNumber & "' AND TestItem=" & testItem.Split(".")(0) _
                        & " AND TestLoop=" & testLoop & ";"
                    ds = New DataSet
                    ds = DbOperateUtils.GetDataSet(strSql)
                    If ds.Tables(0).Rows.Count = 0 Then MessageUtils.ShowInformation("请先在料件基础资料中维护料号" & partNumber & "！") : Exit Sub
                    If ds.Tables(1).Rows.Count > 0 Then MessageUtils.ShowInformation("立讯料号" & partNumber & "已对应其他客户料号 或 客户料号" & cusPartNumber _
                        & "已对应其他立讯料号！请确认后再维护！") : Exit Sub
                    If ds.Tables(2).Rows.Count > 0 Then MessageUtils.ShowInformation("料号" & partNumber & "的测试项目" & testItem & IIf(testItem.Split(".")(0) = 0, "测试回路" + testLoop, "") & "的规格已维护！") : Exit Sub

                    strSql = "INSERT INTO m_PartTestRules_t(PartNumber,CusPartNumber,TestItem,TestItemDes,TestLoop,TestLoopDes,TestCondition" _
                        & ",SpecLowerLimit,SpecUpperLimit,Unit,UnitDesEn,UnitDesCn,Usey,ModifyBy,ModifyByName,ModifyTime)" _
                        & " VALUES('" & partNumber & "','" & cusPartNumber & "','" & testItem.Split(".")(0) & "',N'" & testItem.Split(".")(1) _
                        & "'," & testLoop & ",N'" & testLoopDes & "',N'" & testCondition & "',N'" & specLowerLimit & "',N'" & specUpperLimit _
                        & "','" & unit.Split(".")(0) & "',N'" & unitDesEn & "',N'" & unitDesCn & "','1','" & SysMessageClass.UseId _
                        & "',N'" & SysMessageClass.UseName & "',GETDATE())"

                Case EnumTools.Edit
                    strSql = "UPDATE m_PartTestRules_t SET  TestLoopDes=N'" & testLoopDes & "',TestCondition=N'" & testCondition & "',SpecLowerLimit=N'" _
                        & specLowerLimit & "',SpecUpperLimit=N'" & specUpperLimit & "',Unit='" & unit.Split(".")(0) & "',UnitDesEn=N'" & unitDesEn _
                        & "',UnitDesCn=N'" & unitDesCn & "',ModifyBy='" & SysMessageClass.UseId & "',ModifyByName=N'" & SysMessageClass.UseName _
                        & "',ModifyTime=GETDATE() WHERE PartNumber='" & partNumber & "' AND TestItem=" & testItem.Split(".")(0) & " AND TestLoop=" & testLoop
                Case EnumTools.Customer
                    strSql = "SELECT TOP 1 1 FROM m_PartTestRules_t WHERE PartNumber='" & partNumber & "'"
                    ds = New DataSet
                    ds = DbOperateUtils.GetDataSet(strSql)
                    If ds.Tables(0).Rows.Count = 0 Then MessageUtils.ShowInformation("未维护有立讯料号" & partNumber & "的规格上下限数据，无需修改！") : Exit Sub
                    If MessageUtils.ShowConfirm("该操作会修改立讯料号" & partNumber & "对应所有测试项目规格数据的客户料号，你确定要继续吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                    strSql = "UPDATE m_PartTestRules_t SET  CusPartNumber=N'" & cusPartNumber & "',ModifyBy='" & SysMessageClass.UseId _
                        & "',ModifyByName=N'" & SysMessageClass.UseName & "',ModifyTime=GETDATE()" & " WHERE PartNumber='" & partNumber & "'"
            End Select
            DbOperateUtils.ExecSQL(strSql)
            MessageUtils.ShowInformation("保存成功！")
            toolStatus = EnumTools.Initial
            Initialization()
            EnableControls()
            LoadDataToDatagridview("", 100)
        Catch ex As Exception
            MessageUtils.ShowInformation("保存失败！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartTestRules", "Save_Click", "sys")
        Finally
            If Not ds Is Nothing Then ds.Clear() : ds.Dispose()
        End Try
    End Sub

    '返回
    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        toolStatus = EnumTools.Initial
        Initialization()
        EnableControls()
    End Sub

    '作废
    Private Sub toolInvalid_Click(sender As Object, e As EventArgs) Handles toolInvalid.Click
        Try
            If dgvPartTestRules.RowCount < 1 OrElse dgvPartTestRules.CurrentRow.Index < 0 Then Exit Sub
            Dim strSql As String = ""
            Dim selectedRowIndexs As List(Of Integer) = New List(Of Integer)
            For Each cell As DataGridViewCell In dgvPartTestRules.SelectedCells
                If Not selectedRowIndexs.Contains(cell.RowIndex) Then selectedRowIndexs.Add(cell.RowIndex)
            Next

            If SysMessageClass.UseName = "" Then GetUserName()
            For Each rowIndex As Integer In selectedRowIndexs
                Dim row As DataGridViewRow = dgvPartTestRules.Rows(rowIndex)
                strSql += "UPDATE m_PartTestRules_t SET Usey=0,ModifyBy='" & SysMessageClass.UseId & "',ModifyByName=N'" & SysMessageClass.UseName _
                    & "',ModifyTime=GETDATE() WHERE PartNumber='" & row.Cells(EnumPartTestRules.PartNumber).Value.ToString _
                    & "' AND TestItem=" & row.Cells(EnumPartTestRules.TestItem).Value.ToString.Split(".")(0) _
                    & " AND TestLoop=" & row.Cells(EnumPartTestRules.TestLoop).Value.ToString.Split(".")(0) & ";"
            Next
            DbOperateUtils.ExecSQL(strSql)
            MessageUtils.ShowInformation("作废成功！")
            LoadDataToDatagridview(GetSqlWhere, 100)
        Catch ex As Exception
            MessageUtils.ShowInformation("作废失败！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartTestRules", "Invalid_Click", "sys")
        End Try
    End Sub

    '恢复
    Private Sub toolRecover_Click(sender As Object, e As EventArgs) Handles toolRecover.Click
        Try
            If dgvPartTestRules.RowCount < 1 OrElse dgvPartTestRules.CurrentRow.Index < 0 Then Exit Sub
            Dim strSql As String = ""
            Dim selectedRowIndexs As List(Of Integer) = New List(Of Integer)
            For Each cell As DataGridViewCell In dgvPartTestRules.SelectedCells
                If Not selectedRowIndexs.Contains(cell.RowIndex) Then selectedRowIndexs.Add(cell.RowIndex)
            Next

            If SysMessageClass.UseName = "" Then GetUserName()
            For Each rowIndex As Integer In selectedRowIndexs
                Dim row As DataGridViewRow = dgvPartTestRules.Rows(rowIndex)
                strSql += "UPDATE m_PartTestRules_t SET Usey=1,ModifyBy='" & SysMessageClass.UseId & "',ModifyByName=N'" & SysMessageClass.UseName _
                    & "',ModifyTime=GETDATE() WHERE PartNumber='" & row.Cells(EnumPartTestRules.PartNumber).Value.ToString _
                    & "' AND TestItem=" & row.Cells(EnumPartTestRules.TestItem).Value.ToString.Split(".")(0) _
                    & " AND TestLoop=" & row.Cells(EnumPartTestRules.TestLoop).Value.ToString.Split(".")(0) & ";"
            Next
            DbOperateUtils.ExecSQL(strSql)
            MessageUtils.ShowInformation("恢复成功！")
            LoadDataToDatagridview(GetSqlWhere, 100)
        Catch ex As Exception
            MessageUtils.ShowInformation("恢复失败！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartTestRules", "Recover_Click", "sys")
        End Try
    End Sub

#Region "单位.提示信息"
    Private Sub txtUnitDesEn_Click(sender As Object, e As EventArgs) Handles txtUnitDesEn.Click
        If Not unitDesEnValid Then
            txtUnitDesEn.Text = "" : txtUnitDesEn.ForeColor = Color.Black : unitDesEnValid = True
        End If
    End Sub

    Private Sub txtUnitDesEn_LostFocus(sender As Object, e As EventArgs) Handles txtUnitDesEn.LostFocus
        If txtUnitDesEn.Text = "" OrElse Not unitDesEnValid Then
            txtUnitDesEn.Text = "英文符号" : txtUnitDesEn.ForeColor = Color.LightGray : unitDesEnValid = False
        End If
    End Sub

    Private Sub txtUnitDesCn_Click(sender As Object, e As EventArgs) Handles txtUnitDesCn.Click
        If Not unitDesCnValid Then
            txtUnitDesCn.Text = "" : txtUnitDesCn.ForeColor = Color.Black : unitDesCnValid = True
        End If
    End Sub

    Private Sub txtUnitDesCn_LostFocus(sender As Object, e As EventArgs) Handles txtUnitDesCn.LostFocus
        If txtUnitDesCn.Text = "" OrElse Not unitDesCnValid Then
            txtUnitDesCn.Text = "中文描述" : txtUnitDesCn.ForeColor = Color.LightGray : unitDesCnValid = False
        End If
    End Sub
#End Region

#End Region

#Region "函数、方法"
    '控件值初始化
    Private Sub Initialization()
        txtPartNumber.Enabled = True
        txtPartNumber.Text = ""
        txtCusPartNumber.Enabled = True
        txtCusPartNumber.Text = ""
        cboTestItem.Enabled = True
        cboTestItem.Text = ""
        cboTestLoop.Enabled = True
        cboTestLoop.Text = ""
        txtTestLoopDes.Text = ""
        txtTestCondition.Text = ""
        txtSpecLowerLimit.Text = ""
        txtSpecUpperLimit.Text = ""
        cboUnit.Text = ""
        txtUnitDesEn.Enabled = True '只读时无法设置颜色
        txtUnitDesEn.ForeColor = Color.LightGray
        txtUnitDesEn.Enabled = False
        txtUnitDesEn.Text = "英文符号"
        txtUnitDesCn.Enabled = True '只读时无法设置颜色
        txtUnitDesCn.ForeColor = Color.LightGray
        txtUnitDesCn.Enabled = False
        txtUnitDesCn.Text = "中文描述"
        unitDesEnValid = False
        unitDesCnValid = False
    End Sub

    '控件可编辑性初始化
    Private Sub EnableControls()
        Select Case toolStatus
            Case EnumTools.Initial
                toolAdd.Enabled = True
                toolEdit.Enabled = True
                toolCustomer.Enabled = True
                toolSave.Enabled = False
                toolBack.Enabled = False
                toolInvalid.Enabled = True
                toolRecover.Enabled = True
                toolQuery.Enabled = True
                dgvPartTestRules.Enabled = True
                txtTestLoopDes.Enabled = False
                txtTestCondition.Enabled = False
                txtSpecLowerLimit.Enabled = False
                txtSpecUpperLimit.Enabled = False
                cboUnit.Enabled = False
            Case EnumTools.Add, EnumTools.Edit
                toolAdd.Enabled = False
                toolEdit.Enabled = False
                toolCustomer.Enabled = False
                toolSave.Enabled = True
                toolBack.Enabled = True
                toolInvalid.Enabled = False
                toolRecover.Enabled = False
                toolQuery.Enabled = False
                dgvPartTestRules.Enabled = False
                txtTestLoopDes.Enabled = True
                txtTestCondition.Enabled = True
                txtSpecLowerLimit.Enabled = True
                txtSpecUpperLimit.Enabled = True
                cboUnit.Enabled = True
            Case EnumTools.Customer
                toolAdd.Enabled = False
                toolEdit.Enabled = False
                toolCustomer.Enabled = False
                toolSave.Enabled = True
                toolBack.Enabled = True
                toolInvalid.Enabled = False
                toolRecover.Enabled = False
                toolQuery.Enabled = False
                dgvPartTestRules.Enabled = False
                cboTestItem.Enabled = False
                cboTestLoop.Enabled = False
        End Select
    End Sub

    '查询条件
    Private Function GetSqlWhere() As String
        Dim Sql As String = ""
        If txtPartNumber.Text.Trim <> "" Then
            Sql = Sql & " and PartNumber like '%" & txtPartNumber.Text.Trim & "%' "
        End If
        If txtCusPartNumber.Text.Trim <> "" Then
            Sql = Sql & " and CusPartNumber like '%" & txtCusPartNumber.Text.Trim & "%' "
        End If
        If cboTestItem.Text.Trim <> "" AndAlso cboTestItem.Text.Split(".").Length = 2 Then
            Sql = Sql & " and TestItem = '" & cboTestItem.Text.Split(".")(0) & "' "
        End If
        If cboTestLoop.Text.Trim <> "" Then
            Sql = Sql & " and TestLoop = '" & cboTestLoop.Text & "' "
        End If
        Return Sql
    End Function

    ''' <summary>
    ''' 查询结果绑定
    ''' </summary>
    ''' <param name="SqlWhere">查询条件</param>
    ''' <param name="RowNum">查询笔数</param>
    ''' <remarks></remarks>
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String, ByVal RowNum As Integer)
        Try
            Dim SqlStr As String = "SELECT TOP " + RowNum.ToString + " PartNumber,CusPartNumber,CAST(TestItem AS NVARCHAR(52))+'.'+CAST(TestItemDes AS NVARCHAR(52)) AS TestItem" _
                        & ",CAST(TestLoop AS NVARCHAR(52))+(CASE ISNULL(TestLoopDes,'') WHEN '' THEN '' ELSE ('.'+CAST(TestLoopDes AS NVARCHAR(52))) END) AS TestLoop" _
                        & ",SpecLowerLimit,SpecUpperLimit,CAST(Unit AS NVARCHAR(52)) +'.'+CAST(UnitDesEn AS NVARCHAR(51)) as Unit,UnitDesEn,UnitDesCn,TestCondition" _
                        & ",CASE Usey WHEN '1' THEN N'Y-有效' WHEN '0' THEN N'N-作废' END AS Usey" _
                        & ",CAST(ModifyBy AS NVARCHAR(100))+'/'+CAST(ModifyByName AS NVARCHAR(100)) AS ModifyBy,CONVERT(VARCHAR(16),ModifyTime,21) AS ModifyTime" _
                        & " FROM m_PartTestRules_t WHERE 1=1 " & SqlWhere & " ORDER BY ModifyTime DESC"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)

            dgvPartTestRules.Rows.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim row As DataRow = dt.Rows(i)
                dgvPartTestRules.Rows.Add(row.Item(EnumPartTestRules.PartNumber).ToString, row.Item(EnumPartTestRules.CusPartNumber).ToString, row.Item(EnumPartTestRules.TestItem).ToString, row.Item(EnumPartTestRules.TestLoop).ToString, row.Item(EnumPartTestRules.SpecLowerLimit).ToString, row.Item(EnumPartTestRules.SpecUpperLimit).ToString, row.Item(EnumPartTestRules.Unit).ToString, row.Item(EnumPartTestRules.UnitDesEn.ToString), row.Item(EnumPartTestRules.UnitDesCn).ToString, row.Item(EnumPartTestRules.TestCondition).ToString, row.Item(EnumPartTestRules.Usey).ToString, row.Item(EnumPartTestRules.ModifyBy).ToString, row.Item(EnumPartTestRules.ModifyTime).ToString)
            Next

            toolStripStatusLabel3.Text = Me.dgvPartTestRules.Rows.Count
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '查找当前用户名
    Private Sub GetUserName()
        Try
            Dim dt As DataTable = DbOperateUtils.GetDataTable("SELECT TOP 1 UserName FROM m_Users_t WHERE UserID='" & SysMessageClass.UseId & "'")
            If dt.Rows.Count > 0 Then
                SysMessageClass.UseName = dt.Rows(0)(0).ToString
            Else
                SysMessageClass.UseName = SysMessageClass.UseId
            End If
        Catch ex As Exception
            MessageUtils.ShowInformation("系统异常，请联系值班人员处理！")
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmPartTestRules", "GetUserName", "sys")
        End Try
    End Sub
#End Region

End Class