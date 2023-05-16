
'--生产时段维护
'--Create by :　马锋
'--Create date :　2017/01/12
'--Update date :  
'--Ver : V01

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports LXWarehouseManage
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports MainFrame

#End Region

Public Class FrmProductionSchedule

#Region "窗体事件"

    Private Sub FrmProductionTimeMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False
            SetStatus(0)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        Try
            Clear()
            SetStatus(1)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub ToolAgain_Click(sender As Object, e As EventArgs)
        Try
            'If (String.IsNullOrEmpty(Me.mtxtLine.Text.Trim())) Then
            '    GetMesData.SetMessage(Me.lblMessage, "重新下载工单不能为空", False)
            '    Me.ActiveControl = Me.mtxtLine
            '    Return
            'End If

            'Dim strSQL As StringBuilder = New StringBuilder

            'strSQL.AppendLine(" DECLARE @RTVALUE VARCHAR(8), @RTMSG NVARCHAR(128) ")
            'strSQL.AppendLine(" EXEC GetAgainTiptopMOPlan @RTVALUE OUTPUT, @RTMSG OUTPUT, '', '', '" & VbCommClass.VbCommClass.UseId & "', '" & Me.txtMOId.Text.Trim & "' ")
            'strSQL.AppendLine(" SELECT @RTVALUE, @RTMSG  ")

            'Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)

            'If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then

            '    If (dtTemp.Rows(0).Item(0).ToString = "1") Then
            '        GetMesData.SetMessage(Me.lblMessage, "重新下载工单成功", True)
            '    Else
            '        GetMesData.SetMessage(Me.lblMessage, dtTemp.Rows(0).Item(1).ToString, False)
            '    End If
            'End If
            GetProductionTime()
            If Me.dgvQuery.Rows.Count = 0 Then
                GetMesData.SetMessage(lblMessage, "没有数据", False)
                Exit Sub
            End If
            LoadDataToExcel(dgvQuery, "Plan")

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "下载异常", False)
        End Try
    End Sub

    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                GetMesData.SetMessage(lblMessage, "请选择要修改数据", False)
                Exit Sub
            End If

            Me.mtxtLine.Text = Me.dgvQuery.CurrentRow.Cells("LineId").Value
            Me.txtProductionTimeName.Text = Me.dgvQuery.CurrentRow.Cells("ProductionTimeName").Value
            Me.dtpStart.Text = Me.dgvQuery.CurrentRow.Cells("StartTime").Value
            Me.dtpEnd.Text = Me.dgvQuery.CurrentRow.Cells("EndTime").Value
            Me.txtProductionTimeValue.Text = IIf(IsDBNull(Me.dgvQuery.CurrentRow.Cells("ProductionTimeValue").Value), "", Me.dgvQuery.CurrentRow.Cells("ProductionTimeValue").Value)
            Me.txtManPower.Text = Me.dgvQuery.CurrentRow.Cells("ManpowerValue").Value
            Me.txtProductive.Text = Me.dgvQuery.CurrentRow.Cells("ProductiveValue").Value
            Me.DateTimeInput1.Text = IIf(IsDBNull(Me.dgvQuery.CurrentRow.Cells("PlanEndTime").Value), "", Me.dgvQuery.CurrentRow.Cells("PlanEndTime").Value)
            Me.txtDept.Text = Me.dgvQuery.CurrentRow.Cells("DEPTID").Value
            Me.mtxtLine.Enabled = False
            Dim ss As String = Me.dgvQuery.CurrentRow.Cells("ProductionSchID").Value
            SetStatus(1)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "修改异常", False)
        End Try
    End Sub

    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                GetMesData.SetMessage(lblMessage, "请选择要删除的数据", False)
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            Dim id As String = Me.dgvQuery.CurrentRow.Cells("ProductionSchID").Value
            strSQL.AppendLine(" DELETE FROM m_ProductionSchedule_t  WHERE  ProductionSchID='" & id & "'")
            DbOperateUtils.ExecSQL(strSQL.ToString)
            SetStatus(0)
            GetProductionTime()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub ToolCommit_Click(sender As Object, e As EventArgs) Handles ToolCommit.Click
        Try
            If (Not CheckSave()) Then
                Exit Sub
            End If
            If String.IsNullOrEmpty(Me.txtDept.Text.Trim) Then
                GetMesData.SetMessage(Me.lblMessage, "请选择部门", False)
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            strSQL.AppendLine(" IF EXISTS(SELECT LineId FROM m_ProductionSchedule_t WHERE LineId = '" & Me.mtxtLine.Text.Trim & "') BEGIN UPDATE m_ProductionSchedule_t " +
                             " SET  StartTime = '" & Me.dtpStart.Text.Trim & "', EndTime = '" & Me.dtpEnd.Text.Trim & "', ProductionTimeValue = " & IIf(txtProductionTimeValue.Text.Trim = String.Empty, "NULL", txtProductionTimeValue.Text.Trim) & ",ProductionTimeName = '" & Me.txtProductionTimeName.Text.Trim & "',MANPOWERVALUE='" & Me.txtManPower.Text.Trim & "',ProductiveValue='" & Me.txtProductive.Text.Trim & "' WHERE LineId = '" & Me.mtxtLine.Text.Trim & "' End Else BEGIN ")
            strSQL.AppendLine(" INSERT INTO m_ProductionSchedule_t( LineID, ProductionTimeName, StartTime, EndTime, ProductionTimeValue, ProductionType, ProductiveValue, ManpowerValue, CreateUserId,DEPTID)" +
                              " VALUES( '" & Me.mtxtLine.Text.Trim & "', '" & Me.txtProductionTimeName.Text.Trim & "', '" & Me.dtpStart.Text.Trim & "', '" & Me.dtpEnd.Text.Trim & "', '" & IIf(txtProductionTimeValue.Text.Trim = String.Empty, DBNull.Value, txtProductionTimeValue.Text.Trim) & "', '1',  '" & Me.txtProductive.Text.Trim & "', '" & Me.txtManPower.Text.Trim & "','" & VbCommClass.VbCommClass.UseId & "' ,'" & Me.txtDept.Text.Trim & "' ) End ")

            DbOperateUtils.ExecSQL(strSQL.ToString)
            If Not String.IsNullOrEmpty(Me.DateTimeInput1.Text) Then
                strSQL = New StringBuilder
                strSQL.Append("Begin Update m_TiptopPlanItem_t   set planendtime='" & Me.DateTimeInput1.Text.Trim & "' where  planendtime=(select max(planendtime) from m_TiptopPlanItem_t B where   LineId='" & Me.mtxtLine.Text.Trim & "' and DeptId='" & Me.txtDept.Text.Trim & "') and LineId='" & Me.mtxtLine.Text.Trim & "' and DeptId='" & Me.txtDept.Text.Trim & "' ;")
                strSQL.Append(" Update m_TiptopPlan_t   set planendtime='" & Me.DateTimeInput1.Text.Trim & "' where  planendtime=(select max(planendtime) from m_TiptopPlanItem_t B where   LineId='" & Me.mtxtLine.Text.Trim & "' and DeptId='" & Me.txtDept.Text.Trim & "') and LineId='" & Me.mtxtLine.Text.Trim & "' and DeptId='" & Me.txtDept.Text.Trim & "' ;END;")
                DbOperateUtils.ExecSQL(strSQL.ToString)
            End If

            SetStatus(0)
            Clear()
            GetProductionTime()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存异常", False)
        End Try
    End Sub

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        Try
            SetStatus(0)
            GetProductionTime()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "返回异常", False)
        End Try
    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Try
            GetProductionTime()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Try
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "退出异常", False)
        End Try
    End Sub

    Private Sub mtxtLine_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtLine.ButtonCustomClick
        Try

            Dim deptid As String = String.Empty

            Dim frmLineQuery As New FrmLineQuery(Me.mtxtLine, Me.txtDept)
            'frmLineQuery.ShowDialog()
            'update by hgd 2017-03-31  返回部门代码
            If frmLineQuery.ShowDialog() = Windows.Forms.DialogResult.Yes Then
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

#End Region

#Region "方法"

    Private Sub SetStatus(ByVal statusFlag As Int16)
        GetMesData.SetMessage(Me.lblMessage, "", True)
        Select Case (statusFlag)
            Case 0
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.ToolCommit.Enabled = False
                Me.ToolBack.Enabled = False
                Me.ToolQuery.Enabled = True
                Me.ToolDelete.Enabled = True
                Me.ToolExitFrom.Enabled = True
                Me.mtxtLine.Enabled = True

            Case 1
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolBack.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolDelete.Enabled = False
                Me.ToolExitFrom.Enabled = False
        End Select
    End Sub

    Private Sub Clear()
        Me.mtxtLine.Text = ""
        Me.txtProductionTimeName.Text = ""
        Me.txtProductionTimeValue.Text = ""
        Me.txtProductive.Text = ""
        Me.txtManPower.Text = ""
        Me.dtpStart.Text = ""
        Me.dtpEnd.Text = ""
        Me.txtDept.Text = ""
        Me.DateTimeInput1.Text = ""
    End Sub
    Private Sub GetProductionTime()
        Try
            Dim strSQL As StringBuilder = New StringBuilder
            dgvQuery.DataSource = Nothing
            strSQL.AppendLine("SELECT ProductionSchID, LineID,DEPTID, ProductionTimeName, (select convert(char(20),max(e.PlanEndTime),120) from m_TiptopPlanItem_t e where e.lineid=c.LineID ) LastLineDate, StartTime, EndTime, ProductionTimeValue, ProductionType, ProductiveValue, ManpowerValue, CreateUserId, CreateTime, " &
               "  (SELECT  LEFT(PartSeriesTypeNameList,LEN(PartSeriesTypeNameList)-1) as  PartSeriesTypeNameList  FROM ( " &
                "  SELECT LINEID, ( SELECT PartSeriesTypeName + ',' FROM m_LineSericesType_t WHERE LINEID = A.LINEID FOR XML PATH('')) AS PartSeriesTypeNameList " &
                "  FROM m_LineSericesType_t A WHERE lineid = c.lineid and a.deptid =c.deptid GROUP BY LINEID) AS B " &
                " ) PartSeriesTypeName  FROM  m_ProductionSchedule_t c WHERE 1=1 ")

            If Not String.IsNullOrEmpty(Me.mtxtLine.Text.Trim()) Then
                strSQL.AppendLine(" AND LineId LIKE '%" & Me.mtxtLine.Text.Trim & "%' ")
            End If
            If Not String.IsNullOrEmpty(Me.txtDept.Text.Trim()) Then
                strSQL.AppendLine(" AND deptid = '" & Me.txtDept.Text.Trim & "' ")
            End If
            Me.dgvQuery.DataSource = DbOperateUtils.GetDataTable(strSQL.ToString)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Function CheckSave() As Boolean
        Try
            If (String.IsNullOrEmpty(Me.mtxtLine.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "产线不能为空", False)
                Return False
            End If

            'If (String.IsNullOrEmpty(Me.txtProductionTimeName.Text.Trim)) Then
            '    GetMesData.SetMessage(Me.lblMessage, "时段名称不能为空", False)
            '    Return False
            'End If

            'If (String.IsNullOrEmpty(Me.dtpStart.Text.Trim)) Then
            '    GetMesData.SetMessage(Me.lblMessage, "开始时间不能为空", False)
            '    Return False
            'End If

            'If (String.IsNullOrEmpty(Me.dtpEnd.Text.Trim)) Then
            '    GetMesData.SetMessage(Me.lblMessage, "结束时间不能为空", False)
            '    Return False
            'End If

            If (String.IsNullOrEmpty(Me.txtProductionTimeValue.Text.Trim)) Then
                'GetMesData.SetMessage(Me.lblMessage, "时间值不能为空", False)
                'Return False
            Else
                If Not IsNumeric(Me.txtProductionTimeValue.Text.Trim) Then
                    GetMesData.SetMessage(Me.lblMessage, "时间值必须为数字", False)
                    Return False
                Else
                    If (CDbl(Me.txtProductionTimeValue.Text.Trim) <= 0) Then
                        GetMesData.SetMessage(Me.lblMessage, "时间值必须大于0", False)
                        Return False
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常", False)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' DataGridView数据导出excel 公共方法
    ''' </summary>
    ''' <param name="DgMoData">DataGridView控件ID</param>
    ''' <param name="tbname">导出文件名称</param>
    ''' <remarks></remarks>
    Public Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String)
        Try


            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim getTable As New DataTable
            getTable.TableName = tbname

            getTable = DgMoData.DataSource

            '导出CSV文件格式，以便用户查询，以,号区分

            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If

            Dim Swriter As New IO.StreamWriter("c:\MesExport\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            For Each r As DataRow In getTable.Rows

                nColqty = 0

                For Each c As DataColumn In getTable.Columns
                    '写入标题行
                    If bColName = False Then
                        If wColName = "" Then
                            wColName = c.ColumnName.Replace(",", "，")
                        Else
                            wColName = wColName + "," + c.ColumnName.Replace(",", "，")
                        End If
                    End If

                    '写入每行的值
                    If nColqty = 0 Then
                        wValue = r.Item(c.ColumnName).ToString.Replace(",", "，")
                    Else
                        wValue = wValue + "," + r.Item(c.ColumnName).ToString.Replace(",", "，")
                    End If
                    nColqty = nColqty + 1

                Next

                If wColName <> "" And bColName = False Then
                    Swriter.WriteLine(wColName)
                    bColName = True
                End If

                Swriter.WriteLine(wValue)

            Next
            Swriter.Close()

            MessageBox.Show("文件导出成功,导出位置：c:\MesExport\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
#End Region


    Private Sub LabelX1_Click(sender As Object, e As EventArgs) Handles LabelX1.Click, LabelX8.Click

    End Sub

    Private Sub toolType_Click(sender As Object, e As EventArgs) Handles toolType.Click
        Dim isAdd As Boolean
        Dim isDelete As Boolean
        Try
            isAdd = False
            isDelete = False
            'If toolAdd.Tag Is Nothing Then toolAdd.Tag = "NO"
            'isAdd = (toolAdd.Tag.ToString.ToUpper() = "YES")
            'isDelete = (toolAbandon.Tag.ToString.ToUpper() = "YES")

            ''If dgvRstation.Item(enumdgvRstation.Stationtype, dgvRstation.CurrentRow.Index).Value.ToString().Trim().Split("-")(0).ToUpper <> "R" Then
            ''    MessageBox.Show("非流程卡工站，不需要维护校验项次!")
            ''    Exit Sub
            ''End If

            ''Id/StationNo/StationName
            If Not (dgvQuery.CurrentRow Is Nothing) Then
                Using frm As New FrmLineSeriesType(dgvQuery.Item(1, dgvQuery.CurrentRow.Index).Value.ToString(), dgvQuery.Item(2, dgvQuery.CurrentRow.Index).Value.ToString(), _
                                            isAdd, isDelete)
                    frm.ShowDialog()
                End Using
                LoadDataToDatagridview(" ")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader
        Dim SqlStr As String = ""

        'dgvQuery.Rows.Clear()
        GetProductionTime()
    End Sub

    
End Class