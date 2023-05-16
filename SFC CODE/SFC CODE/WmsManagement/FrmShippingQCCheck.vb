
'--品质出货确认
'--Create by :　马锋
'--Create date :　2015/04/28
'--Update date :  
'--Ver : V01

#Region "类库导入"
Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports SysBasicClass
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports MainFrame

#End Region

Public Class FrmShippingQCCheck

#Region "加载事件"

    Private Sub FrmShippingQCCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpEndDate.Value = Now.AddDays(-1)
        Me.dtpStartDate.Value = Now.AddDays(1)
    End Sub

#End Region

#Region "菜单事件"

    '重置
    Private Sub ToolInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolInit.Click
        SetMessage("", False)
        Dim CheckRead As DataTable
        Try
            Dim strSQL As New StringBuilder
            If Me.dgvShipping.Rows.Count = 0 OrElse Me.dgvShipping.CurrentRow Is Nothing Then
                SetMessage("请选择需要重置出货单", False)
                Me.dgvShippingDetail.Rows.Clear()
                Exit Sub
            End If
            If (MessageBox.Show("你确定执行重置数据删除动作！", "提示", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then

                '检查状态
                strSQL.AppendLine("SELECT Outwhid FROM m_WhOutM_t WHERE Outwhid='" &
                                  Me.dgvShipping.Item("Outwhid", Me.dgvShipping.CurrentRow.Index).Value.ToString.Trim.Replace("'", "''") & "' AND CheckStatus='2' ")

                CheckRead = DbOperateUtils.GetDataTable(strSQL.ToString)

                If CheckRead.Rows.Count = 0 Then
                    SetMessage("执行重置失败，单据状态非驳回，不能执行重置!", True)
                    Exit Sub
                End If

                Dim outwhid As String = Me.dgvShipping.Item("Outwhid", Me.dgvShipping.CurrentRow.Index).Value.ToString.Trim.Replace("'", "''")

                strSQL.Remove(0, strSQL.Length)

                strSQL.AppendFormat("INSERT INTO m_H01uploadDelete SELECT *, '{0}', GETDATE() FROM m_H01upload " &
                                 "WHERE Cartonid in(select cartonid from m_WhOutD_t where  Outwhid = '{1}') ", VbCommClass.VbCommClass.UseId, outwhid)
                strSQL.AppendLine()

                strSQL.AppendLine("INSERT INTO m_WhOutMDelete_t([Outwhid] ,[Avcoutid] ,[FactotyId] ,[Profitcenter]  ,[Partid] ,[MESShippingOrder] ,[CustMaterialNO] ,[CustShippingOrder] ,[CustPKNO] ,[Rwmoid] ,[Cusid] ,[CustName] ")
                strSQL.AppendLine(",[Orderseq]  ,[Saddress]  ,[Shipqty]  ,[ShipCheckQty]  ,[CartonCount]")
                strSQL.AppendLine(",[States] ,[CustDeliveryNO] ,[CheckStatus] ,[CheckNote] ,[CheckUserId]")
                strSQL.AppendLine(",[CheckTime] ,[WarehouseCheckStatus]  ,[WarehouseCheckNote] ,[WarehouseCheckUserId]")
                strSQL.AppendLine(",[WarehouseCheckTime] ,[Outtype] ,[Remark] ,[Userid] ,[Intime]")
                strSQL.AppendLine(",[ReworkUserId] ,[ReworkTime] ,[ShipDate] ,[DeleteUserId] ,[DeleteTime]) SELECT *, '" &
                                  VbCommClass.VbCommClass.UseId & "', GETDATE() FROM m_WhOutM_t WHERE Outwhid = '" & outwhid & "' ")

                strSQL.AppendFormat("INSERT INTO m_WhOutDDelete_t SELECT *, '{0}', GETDATE() FROM m_WhOutD_t WHERE Outwhid = '{1}' ", VbCommClass.VbCommClass.UseId, outwhid)
                strSQL.AppendLine()

                strSQL.AppendFormat("DELETE m_H01upload WHERE Cartonid in(select cartonid from m_WhOutD_t where  Outwhid = '{0}') ", outwhid)
                strSQL.AppendLine()
                strSQL.AppendLine("DELETE m_WhOutM_t WHERE Outwhid = '" & outwhid & "' ")
                strSQL.AppendLine("DELETE m_WhOutD_t WHERE Outwhid = '" & outwhid & "' ")



                DbOperateUtils.ExecSQL(strSQL.ToString)
                SetMessage("执行重置成功!", True)
                GetShipping()
            End If
        Catch ex As Exception
            SetMessage("重置异常", False)
        End Try
    End Sub

    '驳回
    Private Sub ToolTurn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolTurn.Click
        SetMessage("", False)
        Try
            Dim strSQL As String
            If Me.dgvShipping.Rows.Count = 0 OrElse Me.dgvShipping.CurrentRow Is Nothing Then
                SetMessage("请选择需要驳回出货单", False)
                Me.dgvShippingDetail.Rows.Clear()
                Exit Sub
            End If

            If (MessageBox.Show("你确定执行当前行的驳回动作？", "提示", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                strSQL = "UPDATE m_WhOutM_t SET CheckStatus='2', CheckNote=N'" & Me.txtNote.Text.Trim.Replace("'", "''") & "', CheckUserId='" & VbCommClass.VbCommClass.UseId & "', CheckTime=GETDATE()  WHERE Outwhid = '" & Me.dgvShipping.Item("Outwhid", Me.dgvShipping.CurrentRow.Index).Value.ToString.Trim.Replace("'", "''") & "'"
                DbOperateUtils.ExecSQL(strSQL)

                SetMessage("执行驳回成功!", True)

                GetShipping()
            End If
        Catch ex As Exception
       
            SetMessage("驳回异常", False)
        End Try
    End Sub

    '删除
    Private Sub ToolDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDelete.Click
        SetMessage("", False)
        Try
            Dim strSQL As New StringBuilder

            If Me.dgvShippingDetail.Rows.Count = 0 OrElse Me.dgvShippingDetail.CurrentRow Is Nothing Then
                SetMessage("请选择需要删除出货项", False)
                Me.dgvShippingDetail.Rows.Clear()
                Exit Sub
            End If

            If (MessageBox.Show("你确定执行删除动作！", "提示", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then

                strSQL.Remove(0, strSQL.Length) '" & VbCommClass.VbCommClass.UseId & "', GETDATE()

                Dim OutWhid As String = Me.dgvShipping.Item("Outwhid", Me.dgvShipping.CurrentRow.Index).Value.ToString.Trim.Replace("'", "''")
                Dim cartonid As String = Me.dgvShippingDetail.Item("CartonID", Me.dgvShippingDetail.CurrentRow.Index).Value.ToString.Trim.Replace("'", "''")
                Dim CartonOutqty As String = Me.dgvShippingDetail.Item("CartonOutqty", Me.dgvShippingDetail.CurrentRow.Index).Value.ToString.Trim.Replace("'", "''")

                strSQL.AppendFormat("INSERT INTO m_H01uploadDelete SELECT *, '{0}', GETDATE() FROM m_H01upload " &
                                    "WHERE Cartonid = '{1}' ", VbCommClass.VbCommClass.UseId, cartonid)
                strSQL.AppendLine()

                strSQL.AppendLine("   INSERT INTO m_WhOutDDelete_t( [Outwhid],[CartonID],[HWCartonId],[HWPartId]")
                strSQL.AppendLine("  ,[HWQty],[OrderNO],[HWShippingNO],[PallteID] ")
                strSQL.AppendLine(" ,[CartonOutqty],[DateCode],[MOID],[CheckCartonId]")
                strSQL.AppendLine(" ,[CheckOrder],[StatusFlag],[UserID],[Intime]")
                strSQL.AppendLine(" ,[ReworkUserId],[ReworkTime],[OBACheckStatus],[OBAUserID]")
                strSQL.AppendLine(" ,OBAIntime,DeleteUserId,DeleteTime)")
                strSQL.AppendLine(" SELECT [Outwhid] ,[CartonID],[HWCartonId],[HWPartId] ")
                strSQL.AppendLine(" ,[HWQty],[OrderNO],[HWShippingNO],[PallteID] ")
                strSQL.AppendLine(" ,[CartonOutqty],[DateCode],[MOID],[CheckCartonId]")
                strSQL.AppendLine(" ,[CheckOrder],[StatusFlag],[UserID],[Intime]")
                strSQL.AppendLine(" ,[ReworkUserId],[ReworkTime],[OBACheckStatus],[OBAUserID]")
                strSQL.AppendLine(" ,[OBAIntime], '" & VbCommClass.VbCommClass.UseId & "', GETDATE() ")
                strSQL.AppendLine(" FROM m_WhOutD_t WHERE OutWhid = '" & OutWhid & "' ")
                strSQL.AppendLine(" AND CartonID='" & cartonid & "'")

                strSQL.AppendFormat("DELETE m_H01upload WHERE Cartonid = '{0}' ", cartonid)
                strSQL.AppendLine()

                'Modify by cq 20171023, Me.dgvShipping ==>Me.dgvShippingDetail.Item("CartonID", Me.dgvShippingDetail
                strSQL.AppendFormat(" DELETE m_WhOutD_t WHERE OutWhid = '{0}' AND CartonID='{1}'", OutWhid, cartonid)

                strSQL.AppendFormat("UPDATE m_WhOutM_t SET Shipqty = Shipqty - {0} WHERE OutWhid = '{1}' ", CartonOutqty, OutWhid)

                DbOperateUtils.ExecSQL(strSQL.ToString)
              
                SetMessage("执行删除成功!", True)
                dgvShipping_CellEnter(Nothing, Nothing)
            End If
        Catch ex As Exception
          
            SetMessage("删除异常", False)
        End Try
    End Sub

    '确定
    Private Sub ToolConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolConfirm.Click
        SetMessage("", False)

        Try
            Dim strSQL As String = ""
            If Me.dgvShipping.Rows.Count = 0 OrElse Me.dgvShipping.CurrentRow Is Nothing Then
                SetMessage("请选择需要确定出货单", False)
                Me.dgvShippingDetail.Rows.Clear()
                Exit Sub
            End If
            If (MessageBox.Show("你确定执行确认动作！", "提示", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then

                'gw 2017-10-12 增加全选功能，遍历
                For index = 0 To dgvShipping.Rows.Count - 1
                    If dgvShipping.Rows(index).Cells(0).Value Then
                        strSQL = strSQL + " UPDATE m_WhOutM_t SET CheckStatus='1', CheckNote=N'" &
                            Me.txtNote.Text.Trim.Replace("'", "''") & "', CheckUserId='" & VbCommClass.VbCommClass.UseId &
                            "', CheckTime=GETDATE()  WHERE Outwhid = '" & Me.dgvShipping.Item("Outwhid", index).Value.ToString.Trim.Replace("'", "''") & "'"
                    End If
                Next

                If Not String.IsNullOrEmpty(strSQL) Then
                    DbOperateUtils.ExecSQL(strSQL)
                End If

                MessageUtils.ShowInformation("执行确认成功!")

                GetShipping()
            End If
        Catch ex As Exception
            SetMessage("确定异常", False)
        Finally
        End Try
    End Sub

    '仓库确认
    Private Sub ToolWarehouseConfirm_Click(sender As Object, e As EventArgs) Handles ToolWarehouseConfirm.Click
        If Me.dgvShipping.Rows.Count = 0 OrElse Me.dgvShipping.CurrentRow Is Nothing Then
            SetMessage("请选择需要确认出货单", False)
            Me.dgvShippingDetail.Rows.Clear()
            Exit Sub
        End If

        Try
            If (Me.dgvShipping.Rows(Me.dgvShipping.CurrentRow.Index).Cells("WarehouseCheckStatus").Value <> "待确认") Then
                GetMesData.SetMessage(Me.lblMessage, "确认失败，出货单已经确定或驳回", False)
                Exit Sub
            End If

            Dim shippingWarehouseCheck As New FrmShippingWarehouseCheck(Me.dgvShipping.Rows(Me.dgvShipping.CurrentRow.Index).Cells("Outwhid").Value.ToString)
            shippingWarehouseCheck.ShowDialog()
            GetShipping()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "确认出货单加载异常", False)
        End Try
    End Sub

    '出货数量调整
    Private Sub ToolEditCheckQty_Click(sender As Object, e As EventArgs) Handles ToolEditCheckQty.Click
        If Me.dgvShipping.Rows.Count = 0 OrElse Me.dgvShipping.CurrentRow Is Nothing Then
            SetMessage("请选择需要调整出货单", False)
            Me.dgvShippingDetail.Rows.Clear()
            Exit Sub
        End If

        Try
            If (Me.dgvShipping.Rows(Me.dgvShipping.CurrentRow.Index).Cells("WarehouseCheckStatus").Value <> "待确认") Then
                GetMesData.SetMessage(Me.lblMessage, "调整失败，出货单已经确定或驳回", False)
                Exit Sub
            End If

            Dim shippingEditCheckQuantity As New FrmShippingEditCheckQuantity(Me.dgvShipping.Rows(Me.dgvShipping.CurrentRow.Index).Cells("Outwhid").Value.ToString)
            shippingEditCheckQuantity.ShowDialog()
            GetShipping()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "调整出货单加载异常", False)
        End Try
    End Sub

    '查询
    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        SetMessage("", False)
        Try
            If CheckQueryParameter(True) Then
                Return
            End If

            GetShipping() '出错
        Catch ex As Exception
            SetMessage("查询异常", False)
        End Try
    End Sub

    '导出
    Private Sub ToolExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExport.Click
        SetMessage("", False)
        Try
            If Me.dgvShippingDetail.RowCount < 1 Then Exit Sub
            'LoadDataToExcel(Me.dgvShippingDetail, Me.Text)
            ExcelUtils.LoadDataToExcel(Me.dgvShippingDetail, Me.Text)
        Catch ex As Exception
            SetMessage("导出异常", False)
        End Try
    End Sub

    Private Sub ToolRework_Click(sender As Object, e As EventArgs) Handles ToolRework.Click
        SetMessage("", False)
        Try
            Dim strSQL As New StringBuilder

            If Me.dgvShippingDetail.Rows.Count = 0 OrElse Me.dgvShippingDetail.CurrentRow Is Nothing Then
                SetMessage("请选择需要整批退货项", False)
                Me.dgvShippingDetail.Rows.Clear()
                Exit Sub
            End If

            If (MessageBox.Show("你确定执行整批退货动作！", "提示", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then

                strSQL.Remove(0, strSQL.Length)
                strSQL.AppendLine("UPDATE m_WhOutD_t SET StatusFlag = '2', ReworkUserId='" & VbCommClass.VbCommClass.UseId & "', ReworkTime=GETDATE() WHERE OutWhid = '" & Me.dgvShipping.Item("Outwhid", Me.dgvShipping.CurrentRow.Index).Value.ToString.Trim.Replace("'", "''") & "' ")

                DbOperateUtils.ExecSQL(strSQL.ToString)
             
                SetMessage("执行整批退货成功!", True)
                dgvShipping_CellEnter(Nothing, Nothing)
            End If
        Catch ex As Exception
            SetMessage("整批退货异常", False)
        End Try
    End Sub

    '退出
    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            SetMessage("退出异常", False)
        End Try
    End Sub

#End Region

#Region "控件事件"

    Private Sub dgvShipping_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipping.CellEnter
        SetMessage("", False)
        Try

            If Me.dgvShipping.Rows.Count = 0 OrElse Me.dgvShipping.CurrentRow Is Nothing Then
                Me.dgvShippingDetail.Rows.Clear()
                Exit Sub
            End If

            GetShippingDetail(Me.dgvShipping.Item("Outwhid", Me.dgvShipping.CurrentRow.Index).Value.ToString.Trim.Replace("'", "''"))
        Catch ex As Exception
            SetMessage("获取出货单扫描明细异常", False)
        End Try
    End Sub

    Private Sub txtShippingNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShippingNO.TextChanged

    End Sub


#End Region

#Region "方法"

    Private Sub SetMessage(ByVal Message As String, ByVal bType As Boolean)
        If (bType) Then
            Me.lblMessage.ForeColor = Color.Green
        Else
            Me.lblMessage.ForeColor = Color.Red
        End If
        Me.lblMessage.Text = Message
    End Sub

    Private Function CheckQueryParameter(ByVal MessageFlag As Boolean) As Boolean
        If (dtpStartDate.Value < dtpEndDate.Value) Then
            If (MessageFlag) Then
                MsgBox("查询结束时间不能大于开始时间！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
            End If
            Return True
        End If

        Return False
    End Function

    '获取出货清单
    Private Sub GetShipping()
        Dim strSQL As String
        Dim strWhere As String = ""

        strWhere = " AND Intime between cast('" & Me.dtpEndDate.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime) and cast('" & Me.dtpStartDate.Value.ToString("yyyy/MM/dd") + " 23:59:59" & "' as datetime)"

        If (Not String.IsNullOrEmpty(Me.txtShippingNO.Text.Trim())) Then
            strWhere = strWhere & " AND Avcoutid='" & Me.txtShippingNO.Text.Trim.Replace("'", "''") & "'"
        End If

        If (Not String.IsNullOrEmpty(Me.txtCustDeliveryNO.Text.Trim)) Then
            strWhere = strWhere & " AND CustDeliveryNO='" & Me.txtCustDeliveryNO.Text.Trim.Replace("'", "''") & "' "
        End If

        If (Not String.IsNullOrEmpty(Me.txtPartNO.Text.Trim())) Then
            strWhere = strWhere & " AND Partid='" & Me.txtPartNO.Text.Trim() & "' "
        End If

        strSQL = "SELECT   Outwhid, Avcoutid, Partid, Cusid, CustDeliveryNO, Shipqty, ShipCheckQty, CartonCount, Saddress,  CASE WHEN CheckStatus='0' THEN N'待确认' WHEN CheckStatus='2' THEN N'驳回'  ELSE N'已经确认' END AS CheckStatus, " & _
                "CheckNote, CheckUserId, CONVERT(VARCHAR(32), CheckTime, 120) AS CheckTime, UserID, CONVERT(VARCHAR(32), Intime, 120) AS Intime, " & _
                " CASE WHEN WarehouseCheckStatus='0' THEN N'待确认' WHEN WarehouseCheckStatus='2' THEN N'驳回'  ELSE N'已经确认' END AS WarehouseCheckStatus, WarehouseCheckNote, WarehouseCheckUserId, CONVERT(VARCHAR(32), WarehouseCheckTime, 120) AS WarehouseCheckTime " & _
                "FROM  m_WhOutM_t WHERE 1=1 " & strWhere
        LoadData(strSQL, Me.dgvShipping)
    End Sub

    '获取出货扫描明细
    Private Sub GetShippingDetail(ByVal strShippingNO As String)
        Dim strSQL As String
        strSQL = "SELECT  CartonID, HWCartonId, HWPartId, HWQty, HWShippingNO, CartonOutqty, m_WhOutD_t.UserID, CONVERT(VARCHAR(32), Intime, 120) AS Intime, m_SettingParameter_t.PARAMETER_NAME AS StatusFlagText  " & _
                "FROM    m_WhOutD_t INNER JOIN m_SettingParameter_t ON m_SettingParameter_t.PARAMETER_VALUE=m_WhOutD_t.StatusFlag AND PARAMETER_CODE = 'StatusFlagText' WHERE Outwhid='" & strShippingNO & "' ORDER BY HWShippingNO "
        LoadData(strSQL, Me.dgvShippingDetail)
    End Sub

    '填充数据
    Private Sub LoadData(ByVal Sqlstr As String, ByVal dgvName As DataGridView)
        Dim DReader As DataTable
        Try
            dgvName.Rows.Clear()
            DReader = DbOperateUtils.GetDataTable(Sqlstr)

            For index As Integer = 0 To DReader.Rows.Count - 1
                If dgvName Is Me.dgvShipping Then
                    dgvName.Rows.Add(False, DReader.Rows(index)("Outwhid").ToString, DReader.Rows(index)("Avcoutid").ToString, DReader.Rows(index)("Partid").ToString, DReader.Rows(index)("Cusid").ToString, DReader.Rows(index)("CustDeliveryNO").ToString, DReader.Rows(index)("Shipqty").ToString, DReader.Rows(index)("ShipCheckQty").ToString, DReader.Rows(index)("CartonCount").ToString, _
                       DReader.Rows(index)("Saddress").ToString, DReader.Rows(index)("CheckStatus").ToString, DReader.Rows(index)("CheckNote").ToString, DReader.Rows(index)("CheckUserId").ToString, DReader.Rows(index)("CheckTime").ToString, DReader.Rows(index)("WarehouseCheckStatus").ToString, DReader.Rows(index)("WarehouseCheckNote").ToString, DReader.Rows(index)("WarehouseCheckUserId").ToString, DReader.Rows(index)("WarehouseCheckTime").ToString)
                Else
                    dgvName.Rows.Add(DReader.Rows(index)("CartonID").ToString, DReader.Rows(index)("HWCartonId").ToString, DReader.Rows(index)("HWPartId").ToString, DReader.Rows(index)("HWQty").ToString, DReader.Rows(index)("HWShippingNO").ToString, DReader.Rows(index)("HWPartId").ToString, DReader.Rows(index)("CartonOutqty").ToString, _
                       DReader.Rows(index)("UserID").ToString, DReader.Rows(index)("Intime").ToString, DReader.Rows(index)("StatusFlagText").ToString)
                End If
            Next

            Me.ToolLblCount.Text = Me.dgvShipping.Rows.Count
 
        Catch ex As Exception
            SetMessage("获取数据异常", False)
        End Try
    End Sub

    Public Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String)
        Try

            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            '导出CSV文件格式，以便用户查询，以,号区分

            'If Not Directory.Exists("c:\MES") Then
            '    Directory.CreateDirectory("c:\MES")
            'End If

            'Dim Swriter As New IO.StreamWriter("c:\MES\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            'Dim wValue As String = ""                   '保存每行的徝
            'Dim nColqty As Integer = 0
            'Dim bColName As Boolean = False             '是否写了标题行
            'Dim wColName As String = ""                 '标题行的内容

            'Dim r As Integer
            'Dim c As Integer
            'For r = 0 To DgMoData.Rows.Count - 1
            '    wValue = ""
            '    nColqty = 0
            '    For c = 0 To DgMoData.Columns.Count - 1
            '        '写入标题行
            '        If bColName = False Then
            '            If wColName = "" Then
            '                wColName = DgMoData.Columns(c).HeaderText.Replace(",", "，")
            '            Else
            '                wColName = wColName + "," + DgMoData.Columns(c).HeaderText.Replace(",", "，")
            '            End If
            '        End If

            '        '写入每行的值
            '        'If DgMoData(c, r).Value Is System.DBNull.Value Then
            '        If nColqty = 0 Then
            '            If (ckbCartonSame.Checked And c = 0) Then
            '                wValue = DgMoData(c, r).Value.ToString.Replace(",", "，").Substring(0, DgMoData(c, r).Value.ToString.Length - 8)
            '            Else
            '                wValue = DgMoData(c, r).Value.ToString.Replace(",", "，")
            '            End If
            '        Else
            '            If (ckbCartonSame.Checked And c = 0) Then
            '                wValue = wValue + "," + DgMoData(c, r).Value.ToString.Replace(",", "，").Substring(0, DgMoData(c, r).Value.ToString.Length - 8)
            '            Else
            '                wValue = wValue + "," + DgMoData(c, r).Value.ToString.Replace(",", "，")
            '            End If
            '        End If

            '        nColqty = nColqty + 1
            '    Next

            '    If wColName <> "" And bColName = False Then
            '        Swriter.WriteLine(wColName)
            '        bColName = True
            '    End If

            '    Swriter.WriteLine(wValue)
            'Next
            'Swriter.Close()

            'MessageBox.Show("文件导出成功,导出位置：c:\MES\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
#End Region

    'gw 2017-10-11 当前行是否选中
    Private Sub dgvShipping_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvShipping.CellClick
        If Me.dgvShipping.Rows.Count <= 0 Then Exit Sub
        Dim i As Integer
        i = dgvShipping.CurrentCell.RowIndex
        If dgvShipping.Rows(i).Cells(0).Value = False Then
            dgvShipping.Rows(i).Cells(0).Value = True
        Else
            dgvShipping.Rows(i).Cells(0).Value = False
        End If
    End Sub
    'gw 2017-10-12 是否全选
    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        If CheckBox1.Checked Then
            For index = 0 To dgvShipping.Rows.Count - 1
                dgvShipping.Rows(index).Cells(0).Value = True
            Next
        Else
            For index = 0 To dgvShipping.Rows.Count - 1
                dgvShipping.Rows(index).Cells(0).Value = False
            Next
        End If

    End Sub


#Region "Grid行数"
    Private Sub dg_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvShipping.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
    Private Sub dg2_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvShippingDetail.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region


End Class