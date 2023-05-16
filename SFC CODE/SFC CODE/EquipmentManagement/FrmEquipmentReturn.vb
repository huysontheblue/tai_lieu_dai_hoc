Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports System.Drawing
Imports MainFrame

''' <summary>
''' 修改者： 田玉琳
''' 修改日： 2015/11/11
''' 修改内容：表和设计变更
''' </summary>
''' <remarks>重新改版</remarks>
Public Class FrmEquipmentReturn

    Private topNum As Integer = 100

    Private Sub FrmEquipmentReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            InitLoad()
        End If
    End Sub

    Private Sub InitLoad()
        dgvReturn.DataSource = GetListData("")
        txtEquipment.Focus()

        Select Case VbCommClass.VbCommClass.profitcenter
            Case "XT-D"
                Me.chkNeedKeyInResult.Checked = True
            Case Else
                'do nothing 
        End Select

        EquManageCommon.BindComboxClassDCS(cboRequestClass)
    End Sub

    Private Function GetListData(equPn As String) As DataTable
        Dim strSQL As String =
          "select top {0} RequestID, " &
          "(select UserName from m_Users_t where UserID = Receiver) Receiver," &
          " (select UserName from m_Users_t where UserID = Checker) Checker," &
          "A.EquipmentNo,B.ProcessParameters,A.Line ,B.Storage, " &
          "CONVERT(NVARCHAR(10),A.OutTime  ,111) OutTime,C.HardWarePartNumber   " &
          "from [dbo].[m_Equipment_BorrRetu_t]  A  " &
          "inner join [dbo].[m_Equipment_t] B ON A.EquipmentNo = B.EquipmentNo  " &
          "LEFT JOIN dbo.m_Equipment_App_t app ON  app.id = a.RequestID " &
          "inner join [dbo].[m_EquipmentHardWare_t] C ON B.PartNumber = C.PartNumber AND app.HardWarePartNumber =  c.HardWarePartNumber " &
          "where ISNULL(B.InOut,0)= 0 AND EEnable = 0 AND RequestID IS NOT NULL " &
          "AND A.FactoryName=B.FactoryName AND A.Profitcenter=B.Profitcenter " &
        EquManageCommon.GetFatoryProfitcenter("A")

        strSQL = String.Format(strSQL, topNum.ToString)

        Dim strWhere As String = ""
        If String.IsNullOrEmpty(equPn) = False Then
            strWhere = String.Format(" and A.EquipmentNo = '{0}' ", equPn)
        End If
        If String.IsNullOrEmpty(txtHardWarePartNumber.Text.Trim()) = False Then
            strWhere += " and C.HardWarePartNumber='" & txtHardWarePartNumber.Text.Trim() & "'"
        End If
        strWhere += " order by a.OutTime desc"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere)

        Return dt
    End Function

    '对旧数据
    Private Function GetOutData(equPn As String) As DataTable
        Dim strSQL As String =
          "select 1 from m_Equipment_t where EquipmentNo = '{0}' AND ISNULL(InOut,0)= 0 " &
        EquManageCommon.GetFatoryProfitcenter()
        strSQL = String.Format(strSQL, equPn)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Return dt
    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub toolRefresh_Click(sender As Object, e As EventArgs) Handles toolRefresh.Click
        Try
            InitLoad()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipmentReturn", "toolRefresh_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    ''按设备编号入库
    Private Sub txtEquipment_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEquipment.KeyPress
        Dim o_strIsOK As String = String.Empty
        Try
            If Asc(e.KeyChar) = 13 Then
                If chkNeedKeyInResult.Checked = False Then
                    MessageUtils.ShowError("请勾选录入归还是否完好?")
                    txtEquipment.Text = Nothing
                    Exit Sub
                End If

                Dim dt As DataTable = GetOutData(txtEquipment.Text.Trim)
                If dt.Rows.Count = 0 Then
                    'MessageUtils.ShowError("工治具编号不在列表中，请重新确认！")
                    MessageUtils.ShowError("工治具编号没用借出，请重新确认！")
                    txtEquipment.Focus()
                    txtEquipment.SelectAll()
                    Exit Sub
                End If

                '入库检查冶具寿命,给出提醒
                If CheckEquipmentLife() = False Then
                    MessageUtils.ShowError("所刷入的工治具使用寿命到期，请维护保养!")
                End If


                If Me.chkNeedKeyInResult.Checked = True Then
                    If Me.rdoRight.Checked = False AndAlso Me.rdoError.Checked = False Then
                        MessageUtils.ShowError("所刷入的工治具必须勾选是否[正常]或者[报废]!")
                        Exit Sub
                    Else
                        If Me.rdoRight.Checked = True Then
                            o_strIsOK = "1"
                        Else
                            o_strIsOK = "0"
                        End If
                    End If
                End If

                If rdoError.Checked = True Then
                    If String.IsNullOrEmpty(txtRemark.Text.Trim()) = True Then
                        MessageUtils.ShowError("损坏的治具入库要填写入库备注!")
                        Exit Sub
                    End If
                End If

                '********************************田玉琳 20191009 开始********************************
                '修改到存储过程中处理
                Dim EmpNO = VbCommClass.VbCommClass.UseId
                Dim EmpName = VbCommClass.VbCommClass.UseName
                Dim strSQL As String = " exec Exec_EquipmentReturn '{0}','{1}',N'{2}',N'{3}',N'{4}','{5}','{6}','{7}'"
                strSQL = String.Format(strSQL, txtEquipment.Text.Trim, EmpNO, EmpName, cboRequestClass.Text, txtRemark.Text.Trim,
                                       VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, o_strIsOK)

                DbOperateUtils.ExecSQL(strSQL)
                '********************************田玉琳 20191009 结束********************************
                'Dim LendTime = ""
                'Dim dtLendTime = DbOperateUtils.GetDataTable("select OutTime from m_Equipment_t where EquipmentNo='" + txtEquipment.Text.Trim() + "'")
                'If String.IsNullOrEmpty(dtLendTime.Rows(0)(0).ToString()) = False Then
                '    LendTime = Convert.ToDateTime(dtLendTime.Rows(0)(0).ToString()).ToString("yyyy-MM-dd")
                'End If

                'dt.Reset()
                'dt = GetListData(txtEquipment.Text.Trim)

                '新借出的，有申请单号
                'If dt.Rows.Count > 0 Then
                '    If o_strIsOK = "1" OrElse o_strIsOK = "" Then
                '        strSQL =
                '           "declare @RequestID varchar(50) " &
                '           "declare @ID varchar(50) " &
                '           "declare @QTY int " &
                '           "declare @ReturnQty int " &
                '           "begin try " &
                '           "Select @RequestID = RequestID,@ID = ID from m_Equipment_BorrRetu_t  " &
                '           "where RequestID IS NOT NULL AND EquipmentNo =@EquipmentNo AND EEnable=0  " &
                '           "  AND FactoryName=@FactoryName AND Profitcenter=@Profitcenter  " &
                '           "select @QTY = Replace(QTY,'Set',''),@ReturnQty = ReturnQty  from m_Equipment_App_t where ID = @RequestID " &
                '           " begin tran " &
                '           " UPDATE m_Equipment_t SET Lineid = '' ,InOut = 1, OutUserID = '' ,OutTime = NULL " &
                '           " WHERE EquipmentNo=@EquipmentNo AND FactoryName=@FactoryName AND Profitcenter=@Profitcenter " &
                '           " if @QTY = @ReturnQty + 1 " &
                '           " begin  " &
                '           "Update m_Equipment_App_t set ReturnQty= ReturnQty +1,AStatus1=6   where ID = @RequestID " &
                '           " end " &
                '           " else " &
                '           " begin  " &
                '           "Update m_Equipment_App_t set ReturnQty= ReturnQty +1 where ID = @RequestID " &
                '           " end " &
                '           "Update m_Equipment_BorrRetu_t SET EEnable=1,EStatus=N'入库',InTime=GETDATE(),ReturnIsOK='" & o_strIsOK & "' WHERE ID=@ID; " &
                '           " commit tran " &
                '           "end try " &
                '           "begin catch " &
                '           " rollback tran " &
                '           "end catch "
                '    Else
                '        strSQL =
                '        "declare @RequestID varchar(50) " &
                '        "declare @ID varchar(50) " &
                '        "declare @QTY int " &
                '        "declare @ReturnQty int " &
                '        "begin try " &
                '        "Select @RequestID = RequestID,@ID = ID from m_Equipment_BorrRetu_t  " &
                '        "where RequestID IS NOT NULL AND EquipmentNo =@EquipmentNo AND EEnable=0  " &
                '        "  AND FactoryName=@FactoryName AND Profitcenter=@Profitcenter  " &
                '        "select @QTY = Replace(QTY,'Set',''),@ReturnQty = ReturnQty  from m_Equipment_App_t where ID = @RequestID " &
                '        " begin tran " &
                '        " UPDATE m_Equipment_t SET Lineid = '' ,InOut = 1, OutUserID = '' ,OutTime = NULL, Status='0'" &
                '        " WHERE EquipmentNo=@EquipmentNo AND FactoryName=@FactoryName AND Profitcenter=@Profitcenter " &
                '        " if @QTY = @ReturnQty + 1 " &
                '        " begin  " &
                '        "Update m_Equipment_App_t set ReturnQty= ReturnQty +1,AStatus1=6   where ID = @RequestID " &
                '        " end " &
                '        " else " &
                '        " begin  " &
                '        "Update m_Equipment_App_t set ReturnQty= ReturnQty +1 where ID = @RequestID " &
                '        " end " &
                '        "Update m_Equipment_BorrRetu_t SET EEnable=1,EStatus=N'入库',InTime=GETDATE(),ReturnIsOK='" & o_strIsOK & "' WHERE ID=@ID; " & vbCrLf &
                '        " insert into m_Equipment_damage_t(EquipmentNO,EmpNO,EmpName,Remark,FactoryName,Profitcenter,LendTime,DutyDept)" & vbCrLf &
                '        " values ('" & txtEquipment.Text.Trim().ToUpper() & "','" & EmpNO & "',N'" & EmpName & "',N'" & txtRemark.Text.Trim() & "','" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','" & LendTime & "',N'" & Me.cboRequestClass.Text.Trim & "') " & vbCrLf &
                '        " commit tran " &
                '        "end try " &
                '        "begin catch " &
                '        " rollback tran " &
                '        "end catch "
                '    End If
                'Else '旧数据入库，没有申请单号
                '    strSQL =
                '        "declare @RequestID varchar(50)  " &
                '        "declare @ID varchar(50)  " &
                '        "declare @ReturnQty int  " &
                '        "begin try  " &
                '        "Select @RequestID = RequestID,@ID = ID from m_Equipment_BorrRetu_t   " &
                '        "where EquipmentNo =@EquipmentNo AND EEnable=0   " &
                '        "    AND FactoryName=@FactoryName AND Profitcenter=@Profitcenter   " &
                '        "    begin tran " &
                '        "       UPDATE m_Equipment_t SET Lineid = '' ,InOut = 1, OutUserID = '' ,OutTime = NULL  " &
                '        "		    WHERE EquipmentNo=@EquipmentNo AND FactoryName=@FactoryName AND Profitcenter=@Profitcenter  " &
                '        "       UPDATE m_Equipment_App_t set ReturnQty= ReturnQty +1,AStatus1=6   where ID = @RequestID  " &
                '        "	    UPDATE m_Equipment_BorrRetu_t SET EEnable=1,EStatus=N'入库',InTime=GETDATE() WHERE ID=@ID;  " &
                '        "    commit tran " &
                '        "end try  " &
                '        "begin catch  " &
                '         "  rollback tran " &
                '        "end catch "
                'End If

                '--declare @EquipmentNo varchar(50)
                '--declare @FactoryName varchar(16)
                '--declare @Profitcenter varchar(16)
                '--set @EquipmentNo = 'DM-057'
                'Dim alList As ArrayList = New ArrayList

                'alList.Add("EquipmentNo|" & txtEquipment.Text.Trim)
                'alList.Add("FactoryName|" & VbCommClass.VbCommClass.Factory)
                'alList.Add("Profitcenter|" & VbCommClass.VbCommClass.profitcenter)

                'DbOperateUtils.ExecSQL(strSQL, alList)

                '刷新Grid
                InitLoad()
                MessageUtils.ShowInformation(String.Format("工治具【{0}】入库成功！", txtEquipment.Text))
                'lblInfo.Text = String.Format("工治具【{0}】入库成功！", txtEquipment.Text)
                txtEquipment.Text = String.Empty
                txtEquipment.Focus()
                txtRemark.Text = Nothing
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipmentReturn", "txtEquipment_KeyPress", "WIP")
        End Try
    End Sub

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

    '按线别入库
    Private Sub txtLine_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLine.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                Dim strSQL As String =
                    "select EquipmentNo ,EStatus, EEnable,Receiver,Checker, RequestID  from m_Equipment_BorrRetu_t " &
                    "where EEnable =0 and line='{0}' " &
                    EquManageCommon.GetFatoryProfitcenter

                strSQL = String.Format(strSQL, txtLine.Text)
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

                If dt.Rows.Count = 0 Then
                    MessageUtils.ShowError(String.Format("线别{0}未借出任何工治具，请重新确认！", txtLine.Text))
                    txtLine.Focus()
                    txtLine.SelectAll()
                    Exit Sub
                End If

                strSQL =
                "declare @EquipmentNo varchar(50) " &
                "declare @RequestID varchar(50) " &
                "declare @ID varchar(50) " &
                "declare @QTY int " &
                "declare @ReturnQty int " &
                "begin try " &
                "begin tran " &
                "declare cursor1 cursor for " &
                "select RequestID,A.ID,A.EquipmentNo " &
                "from [m_Equipment_BorrRetu_t]  A  " &
                "inner join [dbo].[m_Equipment_t] B ON A.EquipmentNo = B.EquipmentNo  " &
                "where ISNULL(B.InOut,0)= 0 AND EEnable = 0 AND RequestID IS NOT NULL " &
                "  AND A.FactoryName = B.FactoryName AND A.Profitcenter = B.Profitcenter " &
                "  AND line=@line AND A.FactoryName=@FactoryName AND A.Profitcenter=@Profitcenter " &
                " open cursor1 " &
                " fetch next from cursor1 into @RequestID,@ID,@EquipmentNo " &
                " while @@fetch_status=0        " &
                " begin " &
                "  print @EquipmentNo + @RequestID " &
                "  select @QTY = Replace(QTY,'Set',''),@ReturnQty = ReturnQty  from m_Equipment_App_t where ID = @RequestID " &
                "  UPDATE m_Equipment_BorrRetu_t SET EEnable=1,EStatus=N'入库',InTime=GETDATE() WHERE ID=@ID " &
                "  UPDATE m_Equipment_t SET Lineid = '' ,InOut = 1, OutUserID = '' ,OutTime = NULL " &
                "        WHERE EquipmentNo=@EquipmentNo AND FactoryName=@FactoryName AND Profitcenter=@Profitcenter " &
                "  if @QTY = @ReturnQty + 1 " &
                "  begin  " &
                "   Update m_Equipment_App_t set ReturnQty= ReturnQty +1,AStatus1=6   where ID = @RequestID " &
                "  end " &
                "  else " &
                "  begin  " &
                "   Update m_Equipment_App_t set ReturnQty= ReturnQty +1 where ID = @RequestID " &
                "  end  " &
                " fetch next from cursor1 into @RequestID,@ID,@EquipmentNo  " &
                " end " &
                " close cursor1                   " &
                " deallocate cursor1  " &
                " commit tran " &
                "end try " &
                "begin catch " &
                " rollback tran " &
                "end catch "

                '--declare @line varchar(10)
                '--declare @FactoryName varchar(16)
                '--declare @Profitcenter varchar(16)
                '--set @line = 'XT017'
                '--set @FactoryName = 'LXXT'
                '--set @Profitcenter = 'SEE-D'
                Dim alList As ArrayList = New ArrayList

                alList.Add("line|" & txtLine.Text.Trim)
                alList.Add("FactoryName|" & VbCommClass.VbCommClass.Factory)
                alList.Add("Profitcenter|" & VbCommClass.VbCommClass.profitcenter)

                DbOperateUtils.ExecSQL(strSQL, alList)
                '刷新Grid
                InitLoad()
                'MessageUtils.ShowInformation(String.Format("按线别【{0}】批量入库成功！", txtLine.Text))
                lblInfo.Text = String.Format("按线别【{0}】批量入库成功！", txtLine.Text)
                txtLine.Text = String.Empty
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmEquipmentReturn", "txtEquipment_KeyPress", "WIP")
        End Try
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        InitLoad()
    End Sub

    Private Sub dgvReturn_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReturn.CellClick
        If dgvReturn.Columns(e.ColumnIndex).Name = "ChkItem" Then
            Dim sV = CType(dgvReturn.Rows(e.RowIndex).Cells("ChkItem").FormattedValue, Boolean)
            dgvReturn.Rows(e.RowIndex).Cells("ChkItem").Value = IIf(sV, False, True)
        End If
    End Sub

    Private Function GetSelected() As List(Of String)
        Dim list = New List(Of String)
        For Each dgvr As DataGridViewRow In dgvReturn.Rows
            If CType(dgvr.Cells("ChkItem").EditedFormattedValue, Boolean) = True Then
                list.Add(dgvr.Cells("EquipmentNo").Value.ToString())
            End If
        Next
        Return list
    End Function


    ''' <summary>
    ''' 批量入库
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmiBatchIn_Click(sender As Object, e As EventArgs) Handles tsmiBatchIn.Click
        Dim o_strIsOK As String = String.Empty

        Dim list = GetSelected()
        If list.Count = 0 Then
            MessageUtils.ShowError("请勾选要批量入库的治具编号!")
            Exit Sub
        End If

        If chkNeedKeyInResult.Checked = False Then
            MessageUtils.ShowError("请勾选录入归还是否完好?")
            Exit Sub
        End If
        If Me.chkNeedKeyInResult.Checked = True Then
            If Me.rdoRight.Checked = False AndAlso Me.rdoError.Checked = False Then
                MessageUtils.ShowError("所刷入的工治具必须勾选是否[正常]或者[报废]!")
                Exit Sub
            Else
                If Me.rdoRight.Checked = True Then
                    o_strIsOK = "1"
                Else
                    o_strIsOK = "0"
                End If
            End If
        End If

        If rdoError.Checked = True Then
            If String.IsNullOrEmpty(txtRemark.Text.Trim()) = True Then
                MessageUtils.ShowError("损坏的治具入库要填写入库备注!")
                Exit Sub
            End If
        End If

        Try
            Dim EmpNO = VbCommClass.VbCommClass.UseId
            Dim EmpName = VbCommClass.VbCommClass.UseName
            Dim strSQL As String

            For Each item In list
                '********************************田玉琳 20191009 开始********************************
                '修改到存储过程中处理
                strSQL = " exec Exec_EquipmentReturn '{0}',N'{1}',N'{2}',N'{3}',N'{4}','{5}','{6}','{7}'"
                strSQL = String.Format(strSQL, item.ToUpper(), EmpNO, EmpName, cboRequestClass.Text, txtRemark.Text.Trim,
                                       VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, o_strIsOK)

                DbOperateUtils.ExecSQL(strSQL)
                '********************************田玉琳 20191009 结束********************************
                'Dim LendTime = ""
                'Dim dtLendTime = DbOperateUtils.GetDataTable("select OutTime from m_Equipment_t where EquipmentNo='" + item + "'")
                'If String.IsNullOrEmpty(dtLendTime.Rows(0)(0).ToString()) = False Then
                '    LendTime = Convert.ToDateTime(dtLendTime.Rows(0)(0).ToString()).ToString("yyyy-MM-dd")
                'End If

                'Dim dt = GetListData(item)
                ''新借出的，有申请单号
                'If dt.Rows.Count > 0 Then
                '    If o_strIsOK = "1" OrElse o_strIsOK = "" Then
                '        strSQL =
                '           "declare @RequestID varchar(50) " &
                '           "declare @ID varchar(50) " &
                '           "declare @QTY int " &
                '           "declare @ReturnQty int " &
                '           "begin try " &
                '           "Select @RequestID = RequestID,@ID = ID from m_Equipment_BorrRetu_t  " &
                '           "where RequestID IS NOT NULL AND EquipmentNo ='" & item & "' AND EEnable=0  " &
                '           "  AND FactoryName='" & Factory & "' AND Profitcenter='" & profitcenter & "'  " &
                '           "select @QTY = Replace(QTY,'Set',''),@ReturnQty = ReturnQty  from m_Equipment_App_t where ID = @RequestID " &
                '           " begin tran " &
                '           " UPDATE m_Equipment_t SET Lineid = '' ,InOut = 1, OutUserID = '' ,OutTime = NULL " &
                '           " WHERE EquipmentNo='" & item & "' AND FactoryName='" & Factory & "' AND Profitcenter='" & profitcenter & "' " &
                '           " if @QTY = @ReturnQty + 1 " &
                '           " begin  " &
                '           "Update m_Equipment_App_t set ReturnQty= ReturnQty +1,AStatus1=6   where ID = @RequestID " &
                '           " end " &
                '           " else " &
                '           " begin  " &
                '           "Update m_Equipment_App_t set ReturnQty= ReturnQty +1 where ID = @RequestID " &
                '           " end " &
                '           "Update m_Equipment_BorrRetu_t SET EEnable=1,EStatus=N'入库',InTime=GETDATE(),ReturnIsOK='" & o_strIsOK & "' WHERE ID=@ID; " &
                '           " commit tran " &
                '           "end try " &
                '           "begin catch " &
                '           " rollback tran " &
                '           "end catch "
                '    Else
                '        strSQL =
                '        "declare @RequestID varchar(50) " &
                '        "declare @ID varchar(50) " &
                '        "declare @QTY int " &
                '        "declare @ReturnQty int " &
                '        "begin try " &
                '        "Select @RequestID = RequestID,@ID = ID from m_Equipment_BorrRetu_t  " &
                '        "where RequestID IS NOT NULL AND EquipmentNo ='" & item & "' AND EEnable=0  " &
                '        "  AND FactoryName='" & Factory & "' AND Profitcenter='" & profitcenter & "'  " &
                '        "select @QTY = Replace(QTY,'Set',''),@ReturnQty = ReturnQty  from m_Equipment_App_t where ID = @RequestID " &
                '        " begin tran " &
                '        " UPDATE m_Equipment_t SET Lineid = '' ,InOut = 1, OutUserID = '' ,OutTime = NULL, Status='0'" &
                '        " WHERE EquipmentNo='" & item & "' AND FactoryName='" & Factory & "' AND Profitcenter='" & profitcenter & "' " &
                '        " if @QTY = @ReturnQty + 1 " &
                '        " begin  " &
                '        "Update m_Equipment_App_t set ReturnQty= ReturnQty +1,AStatus1=6   where ID = @RequestID " &
                '        " end " &
                '        " else " &
                '        " begin  " &
                '        "Update m_Equipment_App_t set ReturnQty= ReturnQty +1 where ID = @RequestID " &
                '        " end " &
                '        "Update m_Equipment_BorrRetu_t SET EEnable=1,EStatus=N'入库',InTime=GETDATE(),ReturnIsOK='" & o_strIsOK & "' WHERE ID=@ID; " & vbCrLf &
                '        " insert into m_Equipment_damage_t(EquipmentNO,EmpNO,EmpName,Remark,FactoryName,Profitcenter,LendTime,DutyDept)" & vbCrLf &
                '        " values ('" & item.ToUpper() & "','" & EmpNO & "',N'" & EmpName & "',N'" & txtRemark.Text.Trim() & "','" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','" & LendTime & "',N'" & cboRequestClass.Text.Trim() & "') " & vbCrLf &
                '        " commit tran " &
                '        "end try " &
                '        "begin catch " &
                '        " rollback tran " &
                '        "end catch "
                '    End If
                'Else '旧数据入库，没有申请单号
                '    strSQL =
                '        "declare @RequestID varchar(50)  " &
                '        "declare @ID varchar(50)  " &
                '        "declare @ReturnQty int  " &
                '        "begin try  " &
                '        "Select @RequestID = RequestID,@ID = ID from m_Equipment_BorrRetu_t   " &
                '        "where EquipmentNo ='" & item & "' AND EEnable=0   " &
                '        "    AND FactoryName='" & Factory & "' AND Profitcenter='" & profitcenter & "'   " &
                '        "    begin tran " &
                '        "       UPDATE m_Equipment_t SET Lineid = '' ,InOut = 1, OutUserID = '' ,OutTime = NULL  " &
                '        "		    WHERE EquipmentNo='" & item & "' AND FactoryName='" & Factory & "' AND Profitcenter='" & profitcenter & "'  " &
                '        "       UPDATE m_Equipment_App_t set ReturnQty= ReturnQty +1,AStatus1=6   where ID = @RequestID  " &
                '        "	    UPDATE m_Equipment_BorrRetu_t SET EEnable=1,EStatus=N'入库',InTime=GETDATE() WHERE ID=@ID;  " &
                '        "    commit tran " &
                '        "end try  " &
                '        "begin catch  " &
                '         "  rollback tran " &
                '        "end catch "
                'End If

                ''Dim alList As ArrayList = New ArrayList

                ''alList.Add("EquipmentNo|" & item)
                ''alList.Add("FactoryName|" & VbCommClass.VbCommClass.Factory)
                ''alList.Add("Profitcenter|" & VbCommClass.VbCommClass.profitcenter)
                'DbOperateUtils.ExecSQL(strSQL)
                'DbOperateUtils.ExecSQL(strSQL, alList)
            Next

            '刷新Grid
            InitLoad()
            MessageUtils.ShowInformation("工治具批量入库成功！")
            txtEquipment.Text = String.Empty
            txtRemark.Text = Nothing
        Catch ex As Exception
            MessageUtils.ShowError("批量入库出现异常:" & vbCrLf & "" + ex.Message)
        End Try

    End Sub

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        For Each dgvr As DataGridViewRow In dgvReturn.Rows
            dgvr.Cells("ChkItem").Value = chkAll.Checked
        Next
    End Sub


#Region "Grid行数"
    Private Sub dgvReturn_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvReturn.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

End Class