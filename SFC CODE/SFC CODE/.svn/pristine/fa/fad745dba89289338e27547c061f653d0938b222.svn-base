Option Explicit On
Option Strict On
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Collections.Generic
Imports System.Web
Imports System.Collections
Imports System.Text.RegularExpressions
Imports System.Drawing
Imports MainFrame

''' <summary>
''' 修改者： 田玉琳
''' 修改日： 2015/11/11
''' 修改内容：表和设计变更
''' 修改日： 2015/12/30
''' 修改内容：隐藏查询条件
''' </summary>
''' <remarks>重新改版</remarks>
Public Class FrmEquipmentBorrow

    Private Sub FrmEquipmentBorrow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            'txtQueryUserId.Text = VbCommClass.VbCommClass.UseId
            'EquManageCommon.BindComboxClass(cboQueryClass)
            'EquManageCommon.BindComboxLine(cboQueryLine, EquManageCommon.GetObjectValue(cboQueryClass.SelectedValue))
            Search()
            LoadEquipmentDetail(0)
            txtEquipment.Focus()
        End If
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            Search()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipmentBorrow", "toolQuery_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub Search()
        Try
            Dim strSQL As String =
                "select ID,AppUserName,MOID,PNumber,EquipmentPNumber, Replace(QTY,'Set','')-ISNULL(ALREADYBORROWQTY,0) Qty,Line,InTime,Remark, " &
                "DATEDIFF(minute,InTime,GETDATE()) RequestTime " &
                "from m_Equipment_App_t where astatus1 in(1,2,3) and Replace(QTY,'Set','')>isnull(ALREADYBORROWQTY,0)" &
                EquManageCommon.GetFatoryProfitcenter()

            Dim strWhere As New System.Text.StringBuilder

            If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtQueryUserId.Text)) = False Then
                strWhere.AppendFormat(" and AppID = '{0}' ", txtQueryUserId.Text)
            End If

            If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboQueryClass.SelectedValue)) = False Then
                strWhere.AppendFormat(" and DeptID = '{0}' ", cboQueryClass.SelectedValue)
            End If

            If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboQueryLine.SelectedValue)) = False Then
                strWhere.AppendFormat(" and line = '{0}' ", cboQueryLine.SelectedValue)
            End If

            If String.IsNullOrEmpty(txtQueryMo.Text.Trim) = False Then
                strWhere.AppendFormat(" and MOID LIKE N'{0}%' ", txtQueryMo.Text.Trim)
            End If

            If String.IsNullOrEmpty(txtQueryPn.Text.Trim) = False Then
                strWhere.AppendFormat(" and  PNumber LIKE N'{0}%' ", txtQueryPn.Text.Trim)
            End If

            If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(txtQueryEquPN.Text)) = False Then
                strWhere.AppendFormat(" and EquipmentPNumber LIKE N'{0}%' ", txtQueryEquPN.Text)
            End If

            Dim strOrder As String = " ORDER BY InTime DESC "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder)

            lblMessage.Text = String.Empty
            If dt.Rows.Count = 0 Then
                lblMessage.Text = "Không có dữ liệu điều kiện tìm kiếm 没有查询条件数据"
                dgvMOID.Rows.Clear()
                Exit Sub
            End If

            dgvMOID.Rows.Clear()
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                dgvMOID.Rows.Add(dt.Rows(rowIndex)("ID").ToString, dt.Rows(rowIndex)("AppUserName").ToString,
                                 dt.Rows(rowIndex)("MOID").ToString, dt.Rows(rowIndex)("PNumber").ToString,
                                 dt.Rows(rowIndex)("EquipmentPNumber").ToString, dt.Rows(rowIndex)("Qty").ToString,
                                 dt.Rows(rowIndex)("Line").ToString, dt.Rows(rowIndex)("InTime"),
                                 dt.Rows(rowIndex)("Remark").ToString,
                                 dt.Rows(rowIndex)("RequestTime").ToString)
            Next

            For rowIndex As Integer = 0 To dgvMOID.Rows.Count - 1
                If CInt(dgvMOID.Rows(rowIndex).Cells("RequestTime").Value.ToString) > CInt(txtRequestTime.Text) Then
                    dgvMOID.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.LightPink
                Else
                    dgvMOID.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.White
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtEquipment_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEquipment.KeyPress
        Dim o_strEquipmentNo As String="", o_strEquPartNumber As String =""
        Try
            If Asc(e.KeyChar) = 13 Then
                If CheckScan() = False Then
                    Exit Sub
                End If
                Dim Receiver As String = String.Empty

                While (1 = 1)
                    Receiver = InputBox("请输入接收人工号", "提示")

                    If CheckScanUser(Receiver) = True Then
                        Exit While
                    End If
                End While

                o_strEquipmentNo = Me.txtEquipment.Text.Trim
                '出库检查冶具寿命
                If CheckEquipmentLife() = False Then
                    MessageUtils.ShowError("所刷入的工治具使用寿命到期，请维护保养!")
                    Exit Sub
                End If

                Dim curRowIndex = dgvMOID.SelectedCells.Item(0).RowIndex
                Dim requestID As String = dgvMOID.Rows(curRowIndex).Cells("ID").Value.ToString
                UpdateData(Receiver, requestID)

                'List刷新
                Search()

                Dim newCurRowIndex As Integer = 0
                If dgvMOID.Rows.Count > 0 Then
                    dgvMOID.CurrentCell.Selected = False
                    '显示滚动位置
                    If dgvMOID.RowCount = curRowIndex Then
                        newCurRowIndex = curRowIndex - 1
                        Me.dgvMOID.FirstDisplayedScrollingRowIndex = newCurRowIndex
                    Else
                        newCurRowIndex = curRowIndex
                        Me.dgvMOID.FirstDisplayedScrollingRowIndex = curRowIndex
                    End If
                End If

                If dgvMOID.Rows.Count > newCurRowIndex Then
                    dgvMOID.Rows(newCurRowIndex).Selected = True
                End If


                '扫描过的东西要变颜色灰色
                '刷新界面, 线别不会空的变红色
                LoadEquipmentDetail(newCurRowIndex)

                txtEquipment.Text = String.Empty
                txtEquipment.Focus()
                lblMessage.Text = "工治具成功借出!"

                If NeedSafeQtyWar(o_strEquipmentNo, o_strEquPartNumber) Then
                    SeedEmailToDuty(o_strEquPartNumber)
                End If

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipmentBorrow", "txtEquipment_KeyPress", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub


    Private Sub SeedEmailToDuty(ByVal o_strEquPartNumber As String)
        'Dim Email As String = "Byron.Huang@luxshare-ict.com;" & Me.DutyEmail
        Dim Email As String = ""

        Dim Title As String = "工治具料号：" & o_strEquPartNumber & ",安全库存消息提醒!"
        Dim EmailBody As New StringBuilder

        Dim sql As String = "select Email from m_Users_t  where userid = '" & VbCommClass.VbCommClass.UseId & "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
        If dt.Rows.Count > 0 Then
            Email = CStr(dt.Rows(0)("Email"))
            EmailBody.AppendLine("问题描述: 已经达到或者低于安全库存，请及时补充！<br/><br/>")
            ' EmailBody.AppendLine("临时对策:" + dt.Rows(0)("TempCountermeasure") + "<br/><br/>")
            '  EmailBody.AppendLine("长期对策:" + dt.Rows(0)("LongCountermeasure") + "<br/><br/>")
            ' Dim FilePath = Replace(dt.Rows(0)("FilePath").ToString(), " ", "")
            ' EmailBody.AppendLine("附件:<a href='\\192.168.20.123\Sample\SampleProblem\" & FilePath & "'>" & FilePath & "</a>")
        End If

        SeedMail(Email, Title, EmailBody.ToString)
    End Sub

    ''' <summary>
    ''' 发送邮件通知给相关人员
    ''' </summary>
    ''' <param name="MailTo">邮件人</param>
    ''' <param name="EmailTitle">邮件标题</param>
    ''' <param name="EmailBody">邮件内容</param>
    ''' <remarks></remarks>
    Public Shared Sub SeedMail(ByVal MailTo As String, ByVal EmailTitle As String, ByVal EmailBody As String)
        Try
            Dim o_StrBody As New StringBuilder
            Dim o_Subject As New StringBuilder
            Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
            o_Subject.Append("MES待办消息:" & EmailTitle & "")
            o_StrBody.Append("<p>尊敬的MES用户:<p>")
            o_StrBody.Append("<p>" & EmailBody & "</p>")
            Dim para(3) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@SUBJECT", SqlDbType.NVarChar, 200),
                New SqlParameter("@Body", SqlDbType.NVarChar, 4000),
                New SqlParameter("@R_EMAIL", SqlDbType.NVarChar, 1000)
            }
            parameters(0).Value = o_Subject.ToString
            parameters(1).Value = o_StrBody.ToString
            parameters(2).Value = MailTo
            sConn.ExecuteNonQureyByProc("m_MailSend_p", parameters)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function NeedSafeQtyWar(ByVal o_strEquipmentNo As String, ByRef o_strEquPartNumber As String) As Boolean
        Dim lsSQL As New StringBuilder
        Try
            NeedSafeQtyWar = False

            lsSQL.Append("  SELECT COUNT(1) AS Qty ,SafeQty,PartNumber  ")
            lsSQL.Append("  FROM dbo.m_Equipment_t WHERE PartNumber IN ( SELECT PartNumber FROM m_Equipment_t WHERE EquipmentNo= '" & o_strEquipmentNo & "'")
            lsSQL.Append(" AND ISNULL(SafeQty,0)>0 ")
            lsSQL.Append(" AND Status =1)")
            lsSQL.Append("  AND dbo.m_Equipment_t.InOut =1")
            lsSQL.Append("  AND dbo.m_Equipment_t.Status =1")
            lsSQL.Append(" GROUP BY SafeQty,PartNumber ")
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL.ToString)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    If Val(o_dt.Rows(0).Item(0)) - Val(o_dt.Rows(0).Item(1)) <= 0 AndAlso Val(o_dt.Rows(0).Item(1)) > 0 Then
                        NeedSafeQtyWar = True
                        o_strEquPartNumber = CStr(o_dt.Rows(0).Item(2))
                    Else
                        NeedSafeQtyWar = False
                    End If
                End If
            End Using
        Catch ex As Exception
        End Try
    End Function


    Private Function CheckScan() As Boolean

        If ScanEquPn(txtEquipment.Text.Trim) = False Then
            MessageUtils.ShowError("所刷入的工治具【不存在】,请重新再刷!")
            Return False
        End If

        Dim strSQL As String =
            "SELECT 1 FROM m_Equipment_t WHERE EquipmentNo = N'{0}' AND InOut=1 AND Status in (1,2) " &
            EquManageCommon.GetFatoryProfitcenter

        strSQL = String.Format(strSQL, txtEquipment.Text.Trim)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            MessageUtils.ShowError("所刷入的工治具【已借出或已作废】不能再借出,请重新再刷!")
            Return False
        End If

        Return True
    End Function

    Private Function CheckEquipmentLife() As Boolean
        Dim strSQL As String = "exec Exec_CheckEquipmentLifeByInOut '{0}','{1}' "
        strSQL = String.Format(strSQL, txtEquipment.Text.Trim, "2")
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)(0).ToString() = "Y" Then
                Return False
                Exit Function
            End If

        End If
        Return True
    End Function

    Private Function CheckScanUser(receiver As String) As Boolean
        Dim strSQL As String = "SELECT * FROM v_employeeonjob where code='" & receiver.ToUpper & "'"
        'strSQL = String.Format(strSQL, receiver)
        Dim ds As DataSet = DBUtility.DbOracleForSpcHelperSQL.Query(strSQL)
        'Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If ds.Tables(0).Rows.Count = 0 Then
            MessageUtils.ShowError("所刷入的用户ID不存在,请重新再刷!")
            Return False
        End If
        Return True
    End Function

    Private Function ScanEquPn(equPn As String) As Boolean
        Dim bFlag As Boolean = False
        For rowIndex As Integer = 0 To dgvEquipment.Rows.Count - 1
            If dgvEquipment.Rows(rowIndex).Cells("EquipmentNo").Value.ToString.ToUpper = equPn.ToUpper Then
                bFlag = True
                Exit For
            End If
        Next
        Return bFlag
    End Function

    Private Sub UpdateData(receiver As String, requestID As String)
        Dim strSQL As String = " exec Exec_EquipmentBorrow '{0}','{1}','{2}','{3}','{4}','{5}'"
        strSQL = String.Format(strSQL, txtEquipment.Text.Trim, receiver, VbCommClass.VbCommClass.UseId,
                               VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, requestID)

        DbOperateUtils.ExecSQL(strSQL)

    End Sub

    Private Sub dgvMOID_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMOID.CellClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            LoadEquipmentDetail(e.RowIndex)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipmentBorrow", "dgvMOID_CellClick", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub LoadEquipmentDetail(curRowIndex As Integer)
        '取消注释,cq 20190111
        If dgvMOID.Rows.Count = 0 Then
            dgvEquipment.Rows.Clear()
            Exit Sub
        End If

        Dim strSQL As String =
            "select EquipmentNo,ProcessParameters,Storage,lineid,isnull(InOut,1) InOut,FactoryName,Profitcenter from m_Equipment_t  " &
            "where 1=1 and status=1 AND isnull(InOut,1)=1 " & EquManageCommon.GetFatoryProfitcenter()

        Dim partNumber As String = dgvMOID.Rows(curRowIndex).Cells("EquipmentPNumber").Value.ToString

        Dim strWhere As String = String.Format(" and PartNumber = N'{0}'", partNumber)
        Dim strOrder As String = " order by InOut desc"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder)
        dgvEquipment.AutoGenerateColumns = False
        dgvEquipment.DataSource = dt
        'dgvEquipment.Rows.Clear()
        'For rowIndex As Integer = 0 To dt.Rows.Count - 1
        '    dgvEquipment.Rows.Add(
        '        dt.Rows(rowIndex)("EquipmentNo").ToString, dt.Rows(rowIndex)("ProcessParameters").ToString,
        '        dt.Rows(rowIndex)("Storage").ToString, dt.Rows(rowIndex)("lineid").ToString,
        '        dt.Rows(rowIndex)("FactoryName").ToString, dt.Rows(rowIndex)("Profitcenter").ToString,
        '        dt.Rows(rowIndex)("InOut").ToString)
        'Next

        For rowIndex As Integer = 0 To dgvEquipment.Rows.Count - 1
            If String.IsNullOrEmpty(dgvEquipment.Rows(rowIndex).Cells("colLine").Value.ToString) Then
                dgvEquipment.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.LightPink
            Else
                dgvEquipment.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.White
            End If
            If dgvEquipment.Rows(rowIndex).Cells("InOut").Value.ToString = "0" Then
                dgvEquipment.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.LightGray
            Else
                dgvEquipment.Rows(rowIndex).DefaultCellStyle.BackColor = Drawing.Color.White
            End If
        Next
    End Sub

    Private Sub cboQueryClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboQueryClass.SelectedIndexChanged
        If cboQueryClass.SelectedValue IsNot Nothing Then
            EquManageCommon.BindComboxLine(cboQueryLine, cboQueryClass.SelectedValue.ToString)
        End If
    End Sub

#Region "Grid行数"
    Private Sub dgvMOID_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvMOID.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

    Private Sub Toolmaintain_Click(sender As Object, e As EventArgs) Handles Toolmaintain.Click

        For rowIndex As Integer = 0 To dgvEquipment.Rows.Count - 1

            If dgvEquipment.Rows(rowIndex).Cells(0).Selected = True Then

                Dim EquipmentNo As String = dgvEquipment.Rows(rowIndex).Cells(0).Value.ToString()

                '改治具次数为原始次数
                Dim strSQL As String = " update [m_Equipment_t] set RemainCount=ServiceCount where EquipmentNo='" + EquipmentNo + "'  "
                DbOperateUtils.ExecSQL(strSQL)
                MessageUtils.ShowInformation("冶具：" & EquipmentNo & "保养完成")
                Exit Sub
            End If

        Next

        MessageUtils.ShowError("没有选中保养完成的工冶具！")

    End Sub

    Private Sub dgvEquipment_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvEquipment.DataError

    End Sub

    Private Sub dgvEquipment_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEquipment.CellClick
        If dgvEquipment.Columns(e.ColumnIndex).Name = "chkItem" Then
            Dim sV = CType(dgvEquipment.Rows(e.RowIndex).Cells(e.ColumnIndex).FormattedValue, Boolean)
            dgvEquipment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = IIf(sV, False, True)
        End If
    End Sub


    Private Function getSelected() As List(Of String)
        Dim list = New List(Of String)
        For Each dgvr As DataGridViewRow In dgvEquipment.Rows
            If CType(dgvr.Cells("chkItem").Value, Boolean) Then
                list.Add(dgvr.Cells("EquipmentNo").Value.ToString())
            End If
        Next
        Return list
    End Function


    ''' <summary>
    ''' 批量出库
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiBatchOut_Click(sender As Object, e As EventArgs) Handles tsmiBatchOut.Click
        Dim list = getSelected()
        If list.Count = 0 Then
            MessageUtils.ShowError("请勾选要批量出库的治具编号!")
            Exit Sub
        End If

        Dim Receiver = InputBox("请输入接收人工号", "提示")

        If CheckScanUser(Receiver) = False Then
            Exit Sub
        End If

        Dim curRowIndex = dgvMOID.SelectedCells.Item(0).RowIndex
        Dim requestID As String = dgvMOID.Rows(curRowIndex).Cells("ID").Value.ToString
        Dim Factory = VbCommClass.VbCommClass.Factory
        Dim profitcenter = VbCommClass.VbCommClass.profitcenter
        Dim UseId = VbCommClass.VbCommClass.UseId
        Try

            Dim strSQL As String = ""
            For Each item In list
                strSQL = "declare @Line varchar(50) " &
                            "declare @Storage nvarchar(50) " &
                            "declare @AlreadyBorrowQty int = 0 " &
                            "declare @QTY int = 0 " &
                            "declare @UpdateStatus int  " &
                            "begin try " &
                            "select @AlreadyBorrowQty=isnull(Replace(AlreadyBorrowQty,' Set',''),0), " &
                            "   @QTY=isnull(Replace(QTY,' Set',''),0),@Line = A.Line, @Storage = B.Storage " &
                            "from m_Equipment_App_t  A " &
                            "inner join  m_Equipment_t  B " &
                            "on  A.EquipmentPNumber = B.PartNumber " &
                            "where  A.ID =" & requestID & " and B.InOut = 1  AND B.EquipmentNo ='" & item & "'   " &
                            "AND A.FactoryName='" & Factory & "' AND A.Profitcenter='" & profitcenter & "'  " &
                            "AND B.FactoryName=A.FactoryName AND B.Profitcenter=A.Profitcenter " &
                            "if @AlreadyBorrowQty +1 = @QTY " &
                            "begin  " &
                            "set @UpdateStatus = 4 " &
                            "end " &
                            "else " &
                            "begin  " &
                            "set @UpdateStatus = 2 " &
                            "end " &
                            "if @QTY = 0 OR @QTY = @AlreadyBorrowQty " &
                            "begin  " &
                            "return " &
                            "end " &
                            "print @UpdateStatus " &
                            " begin tran " &
                            "update m_Equipment_App_t " &
                            "set AlreadyBorrowQty = @AlreadyBorrowQty + 1 , " &
                            "AStatus1 = @UpdateStatus " &
                            "where ID =" & requestID & " " &
                            "insert m_Equipment_BorrRetu_t " &
                            "(EquipmentNo, EStatus, EEnable, Receiver, Checker, OutTime, Line, Storage, FactoryName, Profitcenter, RequestID) " &
                            "values('" & item & "',N'出库',0,'" & Receiver & "','" & UseId & "',GETDATE(),@Line,@Storage,'" & Factory & "','" & profitcenter & "', " & requestID & ") " &
                            "update m_Equipment_t " &
                            "set InOut =0, " &
                            "OutUserID = '" & Receiver & "', " &
                            "OutTime=getdate(),Lineid=@Line " &
                            "where EquipmentNo ='" & item & "' AND FactoryName='" & Factory & "' AND Profitcenter='" & profitcenter & "' " &
                            " commit tran " &
                            "end try " &
                            "begin catch " &
                            "rollback tran " &
                            "end catch "

                'Dim alList As ArrayList = New ArrayList
                'alList.Add("EquipmentNo|" & item)
                'alList.Add("Receiver|" & Receiver)
                'alList.Add("Checker|" & VbCommClass.VbCommClass.UseId)
                'alList.Add("FactoryName|" & VbCommClass.VbCommClass.Factory)
                'alList.Add("Profitcenter|" & VbCommClass.VbCommClass.profitcenter)
                'alList.Add("RequestID|" & requestID)
                'DbOperateUtils.ExecSQL(strSQL, alList)
                DbOperateUtils.ExecSQL(strSQL)
            Next
            MessageUtils.ShowInformation("批量出库成功!")
            Search()
            LoadEquipmentDetail(curRowIndex)
        Catch ex As Exception
            MessageUtils.ShowError("批量出库出现异常:" & vbCrLf & "" + ex.Message)
        End Try

    End Sub
End Class