Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports System.Text
Imports System.Reflection

Public Class FrmMACManage

    Private buttonStatus As EnumStatus
    Public opflag As Int16 = 0  '

    Private Enum EnumStatus
        UnDo = -1
        NewAdd = 0
        Edit = 1
        Delete = 2
        DownLoad = 3
        Search = 4
    End Enum

    Private Enum EnumAssignState
        NoNeed = -1
        Wait = 0
        AssignOK = 1
    End Enum

    Private Enum MacGrid
        iSelect
        ID
        PartID
        CustName
        MacStartNo
        MacEndNo
        Usey
        maxUsedMac
        reqQty
        ReqUser
        ReqTime
        AssignUser
        AssignTime
        AssignState
        ' iSelect , ID, PartID, MacStartNo, MacEndNo,Usey,
        ' maxUsedMac, reqQty, ReqUser, ReqTime, AssignUser, AssignTime
    End Enum

    Private Sub NewFile_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Me.txtPartID.Text = ""
        Me.txtQty.Text = ""
        Me.txtRemark.Text = ""


        Me.txtPartID.Enabled = True
        Me.txtQty.Enabled = True
        Me.txtRemark.Enabled = True

        Me.toolSave.Enabled = True
        Me.toolBack.Enabled = True
        Me.chkUse.Checked = True
        Me.cboAssignState.Enabled = False

        buttonStatus = EnumStatus.NewAdd
        ToolbtnState(1)
    End Sub

    Private m_strAlreadyAssignIDList As String = ""

    Private Sub FrmMACManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Erightbutton() '

        FillComboLine(CboConsumer)
        Me.CboConsumer.SelectedIndex = -1
        ' Me.TxtTavcPart.Enabled = True
        SearchRecord("")
        Me.lblID.Text = ""
        ToolbtnState(opflag)
    End Sub

    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02025' and b.listy='N' " & _
                " WHERE a.userid='" & SysMessageClass.UseId.ToLower.Trim & "' AND ISNULL(b.ButtonID,'') <>''"
        Dim Reader As SqlDataReader = Conn.GetDataReader(lsSQL)
        Dim Obj As Object
        While Reader.Read
            '
            Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
            Obj.Tag = "Yes"
        End While
        Reader.Close()
        Conn.PubConnection.Close()
        Conn = Nothing
    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0
                If IsNothing(Me.toolAdd.Tag) Then
                    Me.toolAdd.Enabled=False
                Else
                    Me.toolAdd.Enabled = IIf(Me.toolAdd.Tag.ToString <> "Yes", False, True)
                End If

                If IsNothing(Me.toolEdit.Tag) Then
                    Me.toolEdit.Enabled = False
                Else
                    Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                End If

                If IsNothing(Me.ToolAssign.Tag) Then
                    Me.ToolAssign.Enabled = False
                Else
                    Me.ToolAssign.Enabled = IIf(Me.ToolAssign.Tag.ToString <> "Yes", False, True)
                End If

                If IsNothing(Me.ToolQueryMACTotal.Tag) Then
                    Me.ToolQueryMACTotal.Enabled =False
                Else
                    Me.ToolQueryMACTotal.Enabled = IIf(Me.ToolQueryMACTotal.Tag.ToString <> "Yes", False, True)
                End If
                '  Me.toolAbandon.Enabled = IIf(Me.toolAbandon.Tag.ToString <> "Yes", False, True)
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                '  Me.toolCheck.Enabled = False
                'GroupBox
                'Me.cboType.Enabled = True
                'Me.txtStationdest.Enabled = False
                'Me.txtStationid.Enabled = True
                'Me.txtStationName.Enabled = True
                'Me.dgvRstation.Enabled = True
                Me.ActiveControl = Me.txtPartID
            Case 1, 2
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                ' Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                '  Me.toolCheck.Enabled = False
                'GroupBox

            Case 3 '
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                ' Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                ' Me.toolCheck.Enabled = True
                'GroupBox

        End Select
    End Sub

    Private Sub txtPartID_MouseLeave(sender As Object, e As EventArgs) Handles txtPartID.MouseLeave

        If String.IsNullOrEmpty(Me.txtPartID.Text.Trim) Then
            Exit Sub
        Else
            'check whether is real partID
        End If

        If String.IsNullOrEmpty(Me.CboConsumer.Text) Then
            Dim strCusID As String = GetCustID()

            Me.CboConsumer.SelectedIndex = Me.CboConsumer.FindString(strCusID)
        End If

    End Sub

    Private Function GetCustID() As String
        Dim lsSQL As String = String.Empty
        GetCustID = ""

        lsSQL = " SELECT a.CusID  FROM  m_PartContrast_t a " & _
                " WHERE TAvcPart='" & Me.txtPartID.Text.Trim & "'  AND isnull(cusid,'') <> ''"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetCustID = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item(0))
            Else
                GetCustID = ""
            End If
        End Using

    End Function

    Private Function GetCustName() As String
        Dim lsSQL As String = String.Empty
        GetCustName = ""

        lsSQL = " SELECT b.CusName  FROM  m_PartContrast_t a LEFT JOIN dbo.m_Customer_t  b ON a.cusid = b.CusID" & _
                " WHERE TAvcPart='" & Me.txtPartID.Text.Trim & "' "

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetCustName = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item(0))
            Else
                GetCustName = ""
            End If
        End Using

    End Function

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        If checkData() Then
            If SaveData() Then
                Me.SearchRecord("")
                MessageUtils.ShowInformation("保存成功")
            End If
        End If
    End Sub

    ''' <summary>
    ''' 申请记录保存
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveData() As Boolean
        Dim sql As String = ""
        Dim start As String = String.Empty, endno As String = String.Empty
        Dim id As String = lblID.Text
        Dim result As Boolean = True
        Dim usey As String = ""
        Dim strCusID As String = "", strAssignState As String = ""
        Try

            Dim strPartID As String = Me.txtPartID.Text.Trim
            Dim o_MacMin As Object = DBNull.Value, o_MacMax As Object = DBNull.Value
            Dim strUsedMaxMac As String = String.Empty
            Dim ApplyUserID As String = SysMessageClass.UseId
            Dim strRemark As String = Me.txtRemark.Text.Trim
            Dim strStatus As String = "0"
            Dim iApplyQty As Integer = Val(Me.txtQty.Text.Trim)

            usey = IIf(chkUse.Checked = True, "Y", "N")
            If Me.CboConsumer.Text.Contains("---") Then
                strCusID = Me.CboConsumer.Text.Split("---")(0)
            Else
                strCusID = ""
            End If

            If buttonStatus = EnumStatus.NewAdd Then
                sql = " INSERT INTO dbo.m_PartMacaddress_t(PartID,MacStartNo,MacEndNo" & _
                      " ,ApplyUserID,Remark,Status,ApplyQty,CusID,UseY,AssignState,Intime)" & _
                      " VALUES('{0}','{1}','{2}','{3}',N'{4}',N'{5}', N'{6}',N'{7}','Y','" & EnumAssignState.Wait & "',getdate())"
                sql = String.Format(sql, strPartID, o_MacMin, o_MacMax, ApplyUserID, strRemark, strStatus, iApplyQty, strCusID)
                DbOperateUtils.ExecSQL(sql.ToString)
            End If

            If buttonStatus = EnumStatus.Edit Then
                'check whether allow edit 
                'If Me.dgvMac.CurrentRow.Cells(MacGrid.Usey).Value = "N" Then
                '    MessageUtils.ShowError("该条记录已作废 ")
                '    Exit Function
                'End If

                If usey = "Y" Then
                    strAssignState = EnumAssignState.Wait
                Else
                    strAssignState = EnumAssignState.NoNeed
                End If

                sql = "UPDATE dbo.m_PartMacaddress_t SET ApplyQty={0},UpdateTime=getdate(),UpdateUserID='{2}',USEY='{3}',AssignState='{4}' WHERE ID='{1}'"
                sql = String.Format(sql, iApplyQty, id, SysMessageClass.UseId, usey, strAssignState)
                DbOperateUtils.ExecSQL(sql.ToString)
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmMACManage", "Save", "BasicM")
            result = False
        End Try
        Return result
    End Function

    ' ''' <summary>
    ' ''' 获取MAC的总区间段和返回分配的SQL
    ' ''' </summary>
    ' ''' <param name="reqQty"></param>
    ' ''' <param name="strPartID"></param>
    ' ''' <param name="strReqID"></param>
    ' ''' <param name="strAssignSQL"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function GetMACRange(ByVal reqQty As Integer, ByVal strPartID As String, ByVal strReqID As String, _
    '                             ByRef strAssignSQL As StringBuilder
    '                             ) As Boolean

    '    'frist get the max use range 
    '    Dim lsSQL As String = String.Empty
    '    Dim iRemainMacCount As Integer
    '    Dim strUsedMaxMac As String = ""
    '    Dim strAssignIDList As String = ""
    '    Dim strFirstAssignID As String = ""
    '    Dim iNextReqQty As Integer
    '    Dim strCurrIDAssignMin As String = "", strCurrIDAssignMax As String = "", strCurrIDAssignSQL As New StringBuilder
    '    Dim strAssignMin As String = String.Empty, strAssignMax As String = ""
    '    Dim blnTmpAssignResult As Boolean = False
    '    Try

    '        lsSQL = " SELECT TOP 1  ID, usedMaxMac, macmin, MacMax,RemainMacCount " & _
    '                " FROM m_MacaddressM_t " & _
    '                " WHERE 1=1 AND remainMacCount>0" & _
    '                " ORDER BY  MacMin "

    '        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
    '            If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
    '                iRemainMacCount = o_dt.Rows(0).Item("RemainMacCount")
    '                ' 足够分配
    '                If iRemainMacCount >= reqQty Then
    '                    strUsedMaxMac = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("usedMaxMac"))
    '                    ' 第一次分配
    '                    If String.IsNullOrEmpty(strUsedMaxMac) Then
    '                        strAssignMin = o_dt.Rows(0).Item("macmin")
    '                        'Modify by cq20180225, need -1
    '                        strAssignMax = DEC_to_HEX(SixteenToTen(strAssignMin) + (reqQty - 1))
    '                    Else
    '                        '非第一次分配
    '                        strAssignMin = DEC_to_HEX(SixteenToTen(o_dt.Rows(0).Item("usedMaxMac")) + 1)
    '                        'eg: 0-9
    '                        strAssignMax = DEC_to_HEX(SixteenToTen(strAssignMin) + (reqQty - 1))
    '                    End If

    '                    strAssignSQL.AppendLine(" Update m_PartMacaddress_t ")
    '                    strAssignSQL.AppendLine(" SET MacStartNo='" & strAssignMin & "',MacEndNo='" & strAssignMax & "' ")
    '                    strAssignSQL.AppendLine(" ,AssignUserID='" & VbCommClass.VbCommClass.UseId & "',AssignTime=getdate() ")
    '                    strAssignSQL.AppendLine(" ,AssignState='" & EnumAssignState.AssignOK & "' ")
    '                    strAssignSQL.AppendLine(" WHERE ID='" & strReqID & "'")

    '                    For i As Integer = 1 To reqQty
    '                        Dim strTmpMac = DEC_to_HEX(SixteenToTen(strAssignMin) + (i - 1))
    '                        strAssignSQL.AppendLine(" Insert into m_PartMacaddressD_t ")
    '                        strAssignSQL.AppendLine(" (RequestID,Partid,Mac,CreateTime,Status,UserID) ")
    '                        strAssignSQL.AppendLine(" Values('" & strReqID & "','" & strPartID & "','" & strTmpMac & "',getdate(),0,'" & VbCommClass.VbCommClass.UseId & "')")
    '                    Next

    '                    strAssignSQL.AppendLine(" Update m_MacaddressM_t Set RemainMacCount=RemainMacCount-" & reqQty & "")
    '                    strAssignSQL.AppendLine(" ,UsedMaxMac='" & strAssignMax & "' Where ID='" & o_dt.Rows(0).Item("ID") & "'")
    '                    blnTmpAssignResult = True
    '                Else
    '                    '一个区间不够分配，要求两个或者多个区间段的，暂时只考虑分配至多两个区间的
    '                    '首先把前面的 区间用完, eg: iRemainMacCount 552，Req=1000
    '                    strUsedMaxMac = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("usedMaxMac"))
    '                    ' 第一次分配
    '                    If String.IsNullOrEmpty(strUsedMaxMac) Then
    '                        strAssignMin = o_dt.Rows(0).Item("macmin")
    '                        'Modify by cq20180225, need  -1
    '                        strAssignMax = DEC_to_HEX(SixteenToTen(strAssignMin) + (iRemainMacCount - 1))
    '                    Else
    '                        '非第一次分配
    '                        strAssignMin = DEC_to_HEX(SixteenToTen(o_dt.Rows(0).Item("usedMaxMac")) + 1)
    '                        'eg: 0-9
    '                        strAssignMax = o_dt.Rows(0).Item("macmax")
    '                        'DEC_to_HEX(SixteenToTen(strAssignMin) + (iRemainMacCount - 1)) CQ20180225
    '                    End If

    '                    '
    '                    strAssignSQL.AppendLine(" Update m_PartMacaddress_t ")
    '                    strAssignSQL.AppendLine(" SET MacStartNo='" & strAssignMin & "',MacEndNo='" & strAssignMax & "' ")
    '                    strAssignSQL.AppendLine(" ,AssignUserID='" & VbCommClass.VbCommClass.UseId & "',AssignTime=getdate() ")
    '                    strAssignSQL.AppendLine(" ,AssignState='" & EnumAssignState.AssignOK & "' ")
    '                    strAssignSQL.AppendLine(" WHERE ID='" & strReqID & "'")


    '                    For i As Integer = 1 To iRemainMacCount
    '                        Dim strTmpMac = DEC_to_HEX(SixteenToTen(strAssignMin) + (i - 1))
    '                        strAssignSQL.AppendLine(" Insert into m_PartMacaddressD_t ")
    '                        strAssignSQL.AppendLine(" (RequestID,Partid,Mac,CreateTime,Status,UserID) ")
    '                        strAssignSQL.AppendLine(" Values('" & strReqID & "','" & strPartID & "','" & strTmpMac & "',getdate(),0,'" & VbCommClass.VbCommClass.UseId & "')")
    '                    Next

    '                    strAssignSQL.AppendLine(" Update m_MacaddressM_t Set RemainMacCount=RemainMacCount-" & iRemainMacCount & "")
    '                    strAssignSQL.AppendLine(" ,UsedMaxMac='" & strAssignMax & "' Where ID='" & o_dt.Rows(0).Item("ID") & "'")

    '                    '获取下一个RangeID 
    '                    m_strAlreadyAssignIDList &= IIf(String.IsNullOrEmpty(m_strAlreadyAssignIDList), "", ",") + o_dt.Rows(0).Item("ID").ToString

    '                    ' 首先把前面的 区间用完, eg: iRemainMacCount 552，Req=1000,还需要 1000-552
    '                    iNextReqQty = reqQty - iRemainMacCount

    '                    If Not NextRangeAssign(strReqID, strPartID, m_strAlreadyAssignIDList, iNextReqQty, strCurrIDAssignMin, strCurrIDAssignMax, strCurrIDAssignSQL) Then
    '                        Return False
    '                    Else
    '                        strAssignSQL.Append(strCurrIDAssignSQL)
    '                        blnTmpAssignResult = True
    '                    End If
    '                End If
    '            Else
    '                MessageUtils.ShowError("请检查是否维护mac的区间范围")
    '                Return False
    '            End If
    '        End Using
    '        Return blnTmpAssignResult
    '    Catch ex As Exception
    '        MessageUtils.ShowError(ex.Message)
    '        SysMessageClass.WriteErrLog(ex, "FrmMACManage", "GetMACRange", "BasicM")
    '    End Try
    'End Function

    ' ''' <summary>
    ' ''' 当一个区间分配不够，需要启用另一个区间来分配。
    ' ''' </summary>
    ' ''' <param name="strReqID"></param>
    ' ''' <param name="strReqPartID"></param>
    ' ''' <param name="strAlreadyAssignID"></param>
    ' ''' <param name="iNextReqQty"></param>
    ' ''' <param name="strCurrIDAssignMin"></param>
    ' ''' <param name="strCurrIDAssignMax"></param>
    ' ''' <param name="strCurrIDAssignSQL"></param>
    ' ''' <remarks></remarks>
    'Private Function NextRangeAssign(ByVal strReqID As String, ByVal strReqPartID As String, _
    '                             ByVal strAlreadyAssignID As String, ByVal iNextReqQty As Integer, _
    '                            ByRef strCurrIDAssignMin As String, _
    '                             ByRef strCurrIDAssignMax As String, ByRef strCurrIDAssignSQL As StringBuilder
    '                            ) As Boolean
    '    Dim lsSQL As String = String.Empty
    '    Dim strNextRangeID = ""
    '    Dim iRemainMacCount As Integer
    '    Dim strUsedMaxMac As String = ""
    '    Dim blnTmpAssignResult As Boolean = False
    '    Try
    '        lsSQL = " SELECT TOP 1  ID, usedMaxMac, macmin, RemainMacCount " & _
    '                   " FROM m_MacaddressM_t  t1 " & _
    '                   " WHERE 1=1 and remainMacCount>0 " & _
    '                   " AND NOT EXISTS (SELECT id from m_MacaddressM_t t2 where t2.id = t1.id  and t2.id In ('" & strAlreadyAssignID.Replace(",", "','") & "'))  " & _
    '                   " ORDER BY  MacMin "

    '        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
    '            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
    '                iRemainMacCount = o_dt.Rows(0).Item("RemainMacCount")
    '                ' 足够分配
    '                If iRemainMacCount >= iNextReqQty Then
    '                    strUsedMaxMac = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("usedMaxMac"))
    '                    ' 第一次分配
    '                    If String.IsNullOrEmpty(strUsedMaxMac) Then
    '                        strCurrIDAssignMin = o_dt.Rows(0).Item("macmin")
    '                        strCurrIDAssignMax = DEC_to_HEX(SixteenToTen(strCurrIDAssignMin) + (iNextReqQty - 1))
    '                        ' strAssignMax = DEC_to_HEX(SixteenToTen(strAssignMin) + (reqQty - 1))
    '                    Else
    '                        '非第一次分配
    '                        strCurrIDAssignMin = DEC_to_HEX(SixteenToTen(o_dt.Rows(0).Item("usedMaxMac")) + 1)
    '                        strCurrIDAssignMax = DEC_to_HEX(SixteenToTen(strCurrIDAssignMin) + (iNextReqQty - 1))
    '                    End If

    '                    strCurrIDAssignSQL.AppendLine(" Update m_PartMacaddress_t ")
    '                    strCurrIDAssignSQL.AppendLine(" SET MacStartNo='" & strCurrIDAssignMin & "',MacEndNo='" & strCurrIDAssignMax & "' ")
    '                    strCurrIDAssignSQL.AppendLine(" ,AssignUserID='" & VbCommClass.VbCommClass.UseId & "',AssignTime=getdate() ")
    '                    strCurrIDAssignSQL.AppendLine(" ,AssignState='" & EnumAssignState.AssignOK & "' ")
    '                    strCurrIDAssignSQL.AppendLine(" WHERE ID='" & strReqID & "'")


    '                    For i As Integer = 1 To iNextReqQty
    '                        Dim strTmpMac = DEC_to_HEX(SixteenToTen(strCurrIDAssignMin) + (i - 1))
    '                        strCurrIDAssignSQL.AppendLine(" Insert into m_PartMacaddressD_t ")
    '                        strCurrIDAssignSQL.AppendLine(" (RequestID,Partid,Mac,CreateTime,Status,UserID) ")
    '                        strCurrIDAssignSQL.AppendLine(" Values('" & strReqID & "','" & strReqPartID & "','" & strTmpMac & "',getdate(),0,'" & VbCommClass.VbCommClass.UseId & "')")
    '                    Next

    '                    strCurrIDAssignSQL.AppendLine(" Update m_MacaddressM_t Set RemainMacCount=RemainMacCount-" & iNextReqQty & "")
    '                    strCurrIDAssignSQL.AppendLine(" ,UsedMaxMac='" & strCurrIDAssignMax & "' Where ID='" & o_dt.Rows(0).Item("ID") & "'")

    '                    blnTmpAssignResult = True
    '                Else
    '                    '一个区间不够分配，要求两个或者多个区间段的，循环调用
    '                    '获取下一个RangeID  和已经分配的ID
    '                    m_strAlreadyAssignIDList = m_strAlreadyAssignIDList + "," + o_dt.Rows(0).Item("ID")

    '                    iNextReqQty = iNextReqQty - iRemainMacCount

    '                    If iNextReqQty > 0 Then
    '                        blnTmpAssignResult = NextRangeAssign(strReqID, strReqPartID, m_strAlreadyAssignIDList, iNextReqQty, strCurrIDAssignMin, strCurrIDAssignMax, strCurrIDAssignSQL)
    '                    Else
    '                        MessageUtils.ShowError("没有足够的MAC地址分配,请检查！")
    '                        _NeedAssignList.Clear()
    '                        Return False
    '                    End If
    '                End If
    '            Else
    '                MessageUtils.ShowError("没有足够的MAC地址分配,请检查！")
    '                _NeedAssignList.Clear()
    '                Return False
    '            End If
    '        End Using

    '        Return blnTmpAssignResult
    '    Catch ex As Exception
    '        SysMessageClass.WriteErrLog(ex, "FrmMACManage", "NextRangeAssign", "BasicM")
    '    Finally

    '    End Try
    'End Function
    ''' <summary>
    ''' 获取MAC的总区间段和返回分配的SQL
    ''' </summary>
    ''' <param name="reqQty"></param>
    ''' <param name="strPartID"></param>
    ''' <param name="strReqID"></param>
    ''' <param name="strAssignSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMACRange(ByVal reqQty As Integer, ByVal strPartID As String, ByVal strReqID As String, _
                                 ByRef strAssignSQL As StringBuilder, Optional IsCustMac As Boolean = False
                                 ) As Boolean

        'frist get the max use range 
        Dim lsSQL As String = String.Empty
        Dim iRemainMacCount As Integer
        Dim strUsedMaxMac As String = ""
        Dim strAssignIDList As String = ""
        Dim strFirstAssignID As String = ""
        Dim iNextReqQty As Integer
        Dim strCurrIDAssignMin As String = "", strCurrIDAssignMax As String = "", strCurrIDAssignSQL As New StringBuilder
        Dim strAssignMin As String = String.Empty, strAssignMax As String = ""
        Dim blnTmpAssignResult As Boolean = False
        Try
            lsSQL = " SELECT TOP 1  ID, usedMaxMac, macmin, MacMax,RemainMacCount " & _
                   " FROM m_MacaddressM_t " & _
                   " WHERE 1=1 AND remainMacCount>0" & _
                   " ORDER BY  MacMin "
            If IsCustMac Then
                lsSQL = " SELECT TOP 1  ID, usedMaxMac, macmin, MacMax,RemainMacCount " & _
                  " FROM m_Macaddress_Part_t " & _
                  " WHERE 1=1 AND remainMacCount>0 and usey='Y' and PartID='" & strPartID & "'" & _
                  " ORDER BY  MacMin "
            End If


            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                    iRemainMacCount = o_dt.Rows(0).Item("RemainMacCount")
                    ' 足够分配
                    If iRemainMacCount >= reqQty Then
                        strUsedMaxMac = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("usedMaxMac"))
                        ' 第一次分配
                        If String.IsNullOrEmpty(strUsedMaxMac) Then
                            strAssignMin = o_dt.Rows(0).Item("macmin")
                            'Modify by cq20180225, need -1
                            strAssignMax = DEC_to_HEX(SixteenToTen(strAssignMin) + (reqQty - 1))
                        Else
                            '非第一次分配
                            strAssignMin = DEC_to_HEX(SixteenToTen(o_dt.Rows(0).Item("usedMaxMac")) + 1)
                            'eg: 0-9
                            strAssignMax = DEC_to_HEX(SixteenToTen(strAssignMin) + (reqQty - 1))
                        End If

                        strAssignSQL.AppendLine(" Update m_PartMacaddress_t ")
                        strAssignSQL.AppendLine(" SET MacStartNo='" & strAssignMin & "',MacEndNo='" & strAssignMax & "' ")
                        strAssignSQL.AppendLine(" ,AssignUserID='" & VbCommClass.VbCommClass.UseId & "',AssignTime=getdate() ")
                        strAssignSQL.AppendLine(" ,AssignState='" & EnumAssignState.AssignOK & "' ")
                        strAssignSQL.AppendLine(" WHERE ID='" & strReqID & "'")

                        For i As Integer = 1 To reqQty
                            Dim strTmpMac = DEC_to_HEX(SixteenToTen(strAssignMin) + (i - 1))
                            strAssignSQL.AppendLine(" Insert into m_PartMacaddressD_t ")
                            strAssignSQL.AppendLine(" (RequestID,Partid,Mac,CreateTime,Status,UserID) ")
                            strAssignSQL.AppendLine(" Values('" & strReqID & "','" & strPartID & "','" & strTmpMac & "',getdate(),0,'" & VbCommClass.VbCommClass.UseId & "')")
                        Next
                        If IsCustMac Then
                            strAssignSQL.AppendLine(" Update m_Macaddress_Part_t Set RemainMacCount=RemainMacCount-" & reqQty & "")
                        Else
                            strAssignSQL.AppendLine(" Update m_MacaddressM_t Set RemainMacCount=RemainMacCount-" & reqQty & "")
                        End If
                        'strAssignSQL.AppendLine(" Update m_MacaddressM_t Set RemainMacCount=RemainMacCount-" & reqQty & "")
                        strAssignSQL.AppendLine(" ,UsedMaxMac='" & strAssignMax & "' Where ID='" & o_dt.Rows(0).Item("ID") & "'")
                        blnTmpAssignResult = True
                    Else
                        '一个区间不够分配，要求两个或者多个区间段的，暂时只考虑分配至多两个区间的
                        '首先把前面的 区间用完, eg: iRemainMacCount 552，Req=1000
                        strUsedMaxMac = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("usedMaxMac"))
                        ' 第一次分配
                        If String.IsNullOrEmpty(strUsedMaxMac) Then
                            strAssignMin = o_dt.Rows(0).Item("macmin")
                            'Modify by cq20180225, need  -1
                            strAssignMax = DEC_to_HEX(SixteenToTen(strAssignMin) + (iRemainMacCount - 1))
                        Else
                            '非第一次分配
                            strAssignMin = DEC_to_HEX(SixteenToTen(o_dt.Rows(0).Item("usedMaxMac")) + 1)
                            'eg: 0-9
                            strAssignMax = o_dt.Rows(0).Item("macmax")
                            'DEC_to_HEX(SixteenToTen(strAssignMin) + (iRemainMacCount - 1)) CQ20180225
                        End If

                        '
                        strAssignSQL.AppendLine(" Update m_PartMacaddress_t ")
                        strAssignSQL.AppendLine(" SET MacStartNo='" & strAssignMin & "',MacEndNo='" & strAssignMax & "' ")
                        strAssignSQL.AppendLine(" ,AssignUserID='" & VbCommClass.VbCommClass.UseId & "',AssignTime=getdate() ")
                        strAssignSQL.AppendLine(" ,AssignState='" & EnumAssignState.AssignOK & "' ")
                        strAssignSQL.AppendLine(" WHERE ID='" & strReqID & "'")


                        For i As Integer = 1 To iRemainMacCount
                            Dim strTmpMac = DEC_to_HEX(SixteenToTen(strAssignMin) + (i - 1))
                            strAssignSQL.AppendLine(" Insert into m_PartMacaddressD_t ")
                            strAssignSQL.AppendLine(" (RequestID,Partid,Mac,CreateTime,Status,UserID) ")
                            strAssignSQL.AppendLine(" Values('" & strReqID & "','" & strPartID & "','" & strTmpMac & "',getdate(),0,'" & VbCommClass.VbCommClass.UseId & "')")
                        Next
                        If IsCustMac Then
                            strAssignSQL.AppendLine(" Update m_Macaddress_Part_t Set RemainMacCount=RemainMacCount-" & iRemainMacCount & "")
                        Else
                            strAssignSQL.AppendLine(" Update m_MacaddressM_t Set RemainMacCount=RemainMacCount-" & iRemainMacCount & "")
                        End If
                        'strAssignSQL.AppendLine(" Update m_MacaddressM_t Set RemainMacCount=RemainMacCount-" & iRemainMacCount & "")
                        strAssignSQL.AppendLine(" ,UsedMaxMac='" & strAssignMax & "' Where ID='" & o_dt.Rows(0).Item("ID") & "'")

                        '获取下一个RangeID 
                        m_strAlreadyAssignIDList &= IIf(String.IsNullOrEmpty(m_strAlreadyAssignIDList), "", ",") + o_dt.Rows(0).Item("ID").ToString

                        ' 首先把前面的 区间用完, eg: iRemainMacCount 552，Req=1000,还需要 1000-552
                        iNextReqQty = reqQty - iRemainMacCount

                        If Not NextRangeAssign(strReqID, strPartID, m_strAlreadyAssignIDList, iNextReqQty, strCurrIDAssignMin, strCurrIDAssignMax, strCurrIDAssignSQL, IsCustMac) Then
                            Return False
                        Else
                            strAssignSQL.Append(strCurrIDAssignSQL)
                            blnTmpAssignResult = True
                        End If
                    End If
                Else
                    MessageUtils.ShowError("请检查是否维护mac的区间范围")
                    Return False
                End If
            End Using
            Return blnTmpAssignResult
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmMACManage", "GetMACRange", "BasicM")
        End Try
    End Function

    ''' <summary>
    ''' 当一个区间分配不够，需要启用另一个区间来分配。
    ''' </summary>
    ''' <param name="strReqID"></param>
    ''' <param name="strReqPartID"></param>
    ''' <param name="strAlreadyAssignID"></param>
    ''' <param name="iNextReqQty"></param>
    ''' <param name="strCurrIDAssignMin"></param>
    ''' <param name="strCurrIDAssignMax"></param>
    ''' <param name="strCurrIDAssignSQL"></param>
    ''' <remarks></remarks>
    Private Function NextRangeAssign(ByVal strReqID As String, ByVal strReqPartID As String, _
                                 ByVal strAlreadyAssignID As String, ByVal iNextReqQty As Integer, _
                                ByRef strCurrIDAssignMin As String, _
                                 ByRef strCurrIDAssignMax As String, ByRef strCurrIDAssignSQL As StringBuilder, Optional IsCustMac As Boolean = False
                                ) As Boolean
        Dim lsSQL As String = String.Empty
        Dim strNextRangeID = ""
        Dim iRemainMacCount As Integer
        Dim strUsedMaxMac As String = ""
        Dim blnTmpAssignResult As Boolean = False
        Try
            If IsCustMac Then
                lsSQL = " SELECT TOP 1  ID, usedMaxMac, macmin, RemainMacCount " & _
                      " FROM m_Macaddress_Part_t  t1 " & _
                      " WHERE 1=1 and remainMacCount>0 and usey='Y' and PartID='" & strReqPartID & "'" & _
                      " AND NOT EXISTS (SELECT id from m_Macaddress_Part_t t2 where t2.id = t1.id  and t2.id In ('" & strAlreadyAssignID.Replace(",", "','") & "'))  " & _
                      " ORDER BY  MacMin "
            Else
                lsSQL = " SELECT TOP 1  ID, usedMaxMac, macmin, RemainMacCount " & _
                      " FROM m_MacaddressM_t  t1 " & _
                      " WHERE 1=1 and remainMacCount>0 " & _
                      " AND NOT EXISTS (SELECT id from m_MacaddressM_t t2 where t2.id = t1.id  and t2.id In ('" & strAlreadyAssignID.Replace(",", "','") & "'))  " & _
                      " ORDER BY  MacMin "
            End If
            'lsSQL = " SELECT TOP 1  ID, usedMaxMac, macmin, RemainMacCount " & _
            '           " FROM m_MacaddressM_t  t1 " & _
            '           " WHERE 1=1 and remainMacCount>0 " & _
            '           " AND NOT EXISTS (SELECT id from m_MacaddressM_t t2 where t2.id = t1.id  and t2.id In ('" & strAlreadyAssignID.Replace(",", "','") & "'))  " & _
            '           " ORDER BY  MacMin "

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    iRemainMacCount = o_dt.Rows(0).Item("RemainMacCount")
                    ' 足够分配
                    If iRemainMacCount >= iNextReqQty Then
                        strUsedMaxMac = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("usedMaxMac"))
                        ' 第一次分配
                        If String.IsNullOrEmpty(strUsedMaxMac) Then
                            strCurrIDAssignMin = o_dt.Rows(0).Item("macmin")
                            strCurrIDAssignMax = DEC_to_HEX(SixteenToTen(strCurrIDAssignMin) + (iNextReqQty - 1))
                            ' strAssignMax = DEC_to_HEX(SixteenToTen(strAssignMin) + (reqQty - 1))
                        Else
                            '非第一次分配
                            strCurrIDAssignMin = DEC_to_HEX(SixteenToTen(o_dt.Rows(0).Item("usedMaxMac")) + 1)
                            strCurrIDAssignMax = DEC_to_HEX(SixteenToTen(strCurrIDAssignMin) + (iNextReqQty - 1))
                        End If

                        strCurrIDAssignSQL.AppendLine(" Update m_PartMacaddress_t ")
                        strCurrIDAssignSQL.AppendLine(" SET MacStartNo='" & strCurrIDAssignMin & "',MacEndNo='" & strCurrIDAssignMax & "' ")
                        strCurrIDAssignSQL.AppendLine(" ,AssignUserID='" & VbCommClass.VbCommClass.UseId & "',AssignTime=getdate() ")
                        strCurrIDAssignSQL.AppendLine(" ,AssignState='" & EnumAssignState.AssignOK & "' ")
                        strCurrIDAssignSQL.AppendLine(" WHERE ID='" & strReqID & "'")


                        For i As Integer = 1 To iNextReqQty
                            Dim strTmpMac = DEC_to_HEX(SixteenToTen(strCurrIDAssignMin) + (i - 1))
                            strCurrIDAssignSQL.AppendLine(" Insert into m_PartMacaddressD_t ")
                            strCurrIDAssignSQL.AppendLine(" (RequestID,Partid,Mac,CreateTime,Status,UserID) ")
                            strCurrIDAssignSQL.AppendLine(" Values('" & strReqID & "','" & strReqPartID & "','" & strTmpMac & "',getdate(),0,'" & VbCommClass.VbCommClass.UseId & "')")
                        Next
                        If IsCustMac Then
                            strCurrIDAssignSQL.AppendLine(" Update m_Macaddress_Part_t Set RemainMacCount=RemainMacCount-" & iNextReqQty & "")
                        Else
                            strCurrIDAssignSQL.AppendLine(" Update m_MacaddressM_t Set RemainMacCount=RemainMacCount-" & iNextReqQty & "")
                        End If
                        'strCurrIDAssignSQL.AppendLine(" Update m_MacaddressM_t Set RemainMacCount=RemainMacCount-" & iNextReqQty & "")
                        strCurrIDAssignSQL.AppendLine(" ,UsedMaxMac='" & strCurrIDAssignMax & "' Where ID='" & o_dt.Rows(0).Item("ID") & "'")

                        blnTmpAssignResult = True
                    Else
                        '一个区间不够分配，要求两个或者多个区间段的，循环调用
                        '获取下一个RangeID  和已经分配的ID
                        m_strAlreadyAssignIDList = m_strAlreadyAssignIDList + "," + o_dt.Rows(0).Item("ID")

                        iNextReqQty = iNextReqQty - iRemainMacCount

                        If iNextReqQty > 0 Then
                            blnTmpAssignResult = NextRangeAssign(strReqID, strReqPartID, m_strAlreadyAssignIDList, iNextReqQty, strCurrIDAssignMin, strCurrIDAssignMax, strCurrIDAssignSQL, IsCustMac)
                        Else
                            MessageUtils.ShowError("没有足够的MAC地址分配,请检查！")
                            _NeedAssignList.Clear()
                            Return False
                        End If
                    End If
                Else
                    MessageUtils.ShowError("没有足够的MAC地址分配,请检查！")
                    _NeedAssignList.Clear()
                    Return False
                End If
            End Using

            Return blnTmpAssignResult
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMACManage", "NextRangeAssign", "BasicM")
            Return False
        Finally

        End Try
    End Function
    Private Function CheckIsCustMac(ByVal _PARTID As String) As Boolean
        Dim sql As String = "select * from m_Macaddress_Part_t where usey='Y' and partid='" & _PARTID & "' "
        If DbOperateUtils.GetRowsCount(sql) > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function GetNextRangeID(ByVal strFirstAssignID As String)
        Dim lsSQL As String = String.Empty
        GetNextRangeID = ""
        lsSQL = " SELECT TOP 1  ID, usedMaxMac, macmin, RemainMacCount " & _
                   " FROM m_MacaddressM_t  t1 " & _
                   " WHERE 1=1 and remainMacCount>0 AND NOT EXISTS (select id from m_MacaddressM_t t2 where t2.id = t1.id)  " & _
                   " ORDER BY  remainMacCount "

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)


        End Using

    End Function


    '十六进制转换为十进制
    Private Function SixteenToTen(ByVal strSixteen As String) As String
        SixteenToTen = ""

        SixteenToTen = CLng("&H" & strSixteen)
    End Function


    '' 用途：将十进制转化为十六进制
    '' 输入：Dec(十进制数)
    '' 输入数据类型：Long
    '' 输出：DEC_to_HEX(十六进制数)
    '' 输出数据类型：String
    '' 输入的最大数为2147483647,输出最大数为7FFFFFFF
    Public Function DEC_to_HEX(Dec As Long) As String
        Dim a As String
        DEC_to_HEX = ""
        Do While Dec > 0
            a = CStr(Dec Mod 16)
            Select Case a
                Case "10" : a = "A"
                Case "11" : a = "B"
                Case "12" : a = "C"
                Case "13" : a = "D"
                Case "14" : a = "E"
                Case "15" : a = "F"
            End Select
            DEC_to_HEX = a & DEC_to_HEX
            Dec = Dec \ 16
        Loop
    End Function

    Private Function checkData() As Boolean
        checkData = True

        If String.IsNullOrEmpty(Me.txtQty.Text.Trim) Then
            checkData = False
            lblMsg.Text = "申请数量不能为空..."
            Return checkData
        End If

        If Val(Me.txtQty.Text.Trim) <= 0 Then
            checkData = False
            lblMsg.Text = "申请数量必须为数字..."
            Return checkData
        End If

        If String.IsNullOrEmpty(Me.txtPartID.Text) Then
            checkData = False
            lblMsg.Text = "申请料号不能为空..."
            Return checkData
        End If

        If String.IsNullOrEmpty(Me.CboConsumer.Text) Then
            If buttonStatus = EnumStatus.NewAdd Then
                checkData = False
                lblMsg.Text = "客户不能为空..."
                Return checkData
            End If
        End If

        Return True
    End Function

    Public Structure stcReq
        Public ID As String
        Public PartID As String
        Public ApplyQty As String
    End Structure

    Public _NeedAssignList As List(Of stcReq) = New List(Of stcReq)

    Private Sub ToolAssign_Click(sender As Object, e As EventArgs) Handles ToolAssign.Click

        If Me.dgvMac.RowCount <= 0 Then Exit Sub
        Dim strNeedAssignList As String = String.Empty
        Dim o_stcReq As stcReq = New stcReq
        Dim strAssignSQL As New StringBuilder
        Try

            For Each row As DataGridViewRow In dgvMac.Rows
                If CBool(row.Cells(0).EditedFormattedValue) = True Then 'row.Cells(MacGrid.iSelect).FormattedValue Then
                    If IsDBNull(row.Cells(MacGrid.reqQty).Value) Then
                        MessageUtils.ShowError(" 申请数量错误！")
                        Exit Sub
                    End If

                    If row.Cells(MacGrid.Usey).Value = "N" Then
                        MessageUtils.ShowError(" 已经作废, 不允许分配")
                        Exit Sub
                    End If

                    'If (Not String.IsNullOrEmpty(row.Cells(MacGrid.MacStartNo).Value)) Then
                    '    MessageUtils.ShowError(" 已经分配, 不允许再分配")
                    '    Exit Sub
                    'End If

                    If row.Cells(MacGrid.AssignState).Value = "1.OK" Then
                        MessageUtils.ShowError(" 已经分配, 不允许再分配")
                        Exit Sub
                    End If

                    '  Public ID As String
                    'Public PartID As String
                    'Public ApplyQty As String
                    'row.Cells(3).Value:PartID
                    o_stcReq.ID = row.Cells(MacGrid.ID).Value
                    o_stcReq.ApplyQty = row.Cells(MacGrid.reqQty).Value
                    o_stcReq.PartID = row.Cells(MacGrid.PartID).Value

                    If Not _NeedAssignList.Contains(o_stcReq) Then
                        _NeedAssignList.Add(o_stcReq)
                    End If

                End If
            Next

            '分配
            If _NeedAssignList.Count > 0 Then

                If _NeedAssignList.Count > 1 Then
                    MessageUtils.ShowError("一次只允许分配一笔记录！")
                    Exit Sub
                End If

                For Each o_stcTempReq As stcReq In _NeedAssignList
                    Dim custmac As Boolean = CheckIsCustMac(o_stcTempReq.PartID)
                    If Not GetMACRange(o_stcTempReq.ApplyQty, o_stcTempReq.PartID, o_stcTempReq.ID, strAssignSQL, custmac) Then
                        Exit Sub
                    End If
                    'If Not GetMACRange(o_stcTempReq.ApplyQty, o_stcTempReq.PartID, o_stcTempReq.ID, strAssignSQL) Then
                    '    Exit Sub
                    'End If
                Next

                If MessageUtils.ShowConfirm("是否确认分配", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                    If Not String.IsNullOrEmpty(strAssignSQL.ToString) Then
                        DbOperateUtils.ExecSQL(strAssignSQL.ToString)
                        MessageUtils.ShowInformation("分配成功")
                        'refersh 
                        SearchRecord("")
                    End If
                End If

            Else
                '请先勾选记录进行分配
                MessageUtils.ShowError("请先勾选记录进行分配！")
                Exit Sub
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMACManage", "ToolAssign_Click", "BasicM")
        Finally
            _NeedAssignList.Clear()
        End Try
    End Sub

    Private Sub ToolQueryMACTotal_Click(sender As Object, e As EventArgs) Handles ToolQueryMACTotal.Click

        Dim frmMacRange As New FrmMacRange()
        frmMacRange.Owner = Me
        frmMacRange.ShowDialog()

    End Sub

    Private Sub EditFile_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        Me.toolSave.Enabled = True
        Me.toolBack.Enabled = True

        Me.chkUse.Enabled = True
        If dgvMac.CurrentRow.Cells(MacGrid.PartID).Value = Nothing Then
            MessageUtils.ShowError("请选择要修改的料号!")
            Return
        End If

        If dgvMac.CurrentRow.Cells(MacGrid.PartID).Value = Nothing Then
            MessageUtils.ShowError("请选择要修改的料号!")
            Return
        End If

        If dgvMac.CurrentRow.Cells(MacGrid.AssignState).Value = "1.OK" Then
            MessageUtils.ShowError("不允许修改!")
            Return
        End If

        Me.lblID.Text = dgvMac.CurrentRow.Cells(MacGrid.ID).Value
        ' Me.TxtTavcPart.Text = dgvMac.CurrentRow.Cells(1).Value
        Me.txtQty.Text = dgvMac.CurrentRow.Cells(MacGrid.reqQty).Value
        Me.chkUse.Checked = IIf(dgvMac.CurrentRow.Cells(MacGrid.Usey).Value = "Y", True, False)
        Me.txtQty.Enabled = True
        Me.txtPartID.Text = dgvMac.CurrentRow.Cells(MacGrid.PartID).Value

        buttonStatus = EnumStatus.Edit
    End Sub


    Private Sub FillComboLine(ByVal FillComBox As ComboBox)
        Try
            Dim ScanClass As New SysDataBaseClass
            Dim ScanReader As SqlDataReader
            ScanReader = Nothing

            Select Case FillComBox.Name
                Case "CboConsumer"
                    ScanReader = ScanClass.GetDataReader("SELECT  * from M_CUSTOMER_T")
                Case Else

                    'do nothing 
            End Select

            FillComBox.Items.Add(" ")
            Do While ScanReader.Read()
                If FillComBox.Name = "CboDept" Then
                    FillComBox.Items.Add(ScanReader("deptid").ToString & "---" & ScanReader("djc").ToString)
                ElseIf FillComBox.Name = "cobLineQuery" Then
                    FillComBox.Items.Add(ScanReader.GetString(0).ToString)
                Else
                    FillComBox.Items.Add(ScanReader.GetString(0).ToString & "---" & ScanReader.GetString(1).ToString)
                End If
            Loop
            ScanReader.Close()
            FillComBox.Text = CStr(FillComBox.Items.Item(0))
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMACManage", "SearchRecord", "BasicM")
        End Try
    End Sub


    Private Sub SearchRecord(ByVal Sqlstring As String)
        Dim dt As DataTable = Nothing
        Dim sql As String = String.Empty

        ' iSelect , ID, PartID, MacStartNo, MacEndNo,Usey,
        ' maxUsedMac, reqQty, ReqUser, ReqTime, AssignUser, AssignTime


        sql = " SELECT  [ID],a.[PartId] ,b.CusName, [MacStartNo] ,[MacEndNo],a.USEY,'' as MACADDRESS " & _
              " ,ApplyQty,c.UserName as ApplyUserID, a.Intime,d.UserName as AssignUserID,AssignTime," & _
              " (CASE  AssignState WHEN 1 THEN '1.OK' WHEN 0 THEN '0.Wait' When -1 then '-1.No Need' ELSE '' END)AssignState,remark " & _
              " FROM m_PartMacaddress_t a LEFT JOIN m_Customer_t b ON a.CusID= b.CusID  " & _
              " Left Join m_Users_t c on a.ApplyUserID= c.UserID " & _
              " Left Join m_Users_t D on a.AssignUserID= d.UserID " & _
              " WHERE 1=1   "
        Try
            If Sqlstring = "" Then
                dt = DbOperateUtils.GetDataTable(sql + " ORDER BY  ID DESC")
                dgvMac.DataSource = dt
            Else
                sql = sql + Sqlstring
                dt = DbOperateUtils.GetDataTable(sql + " ORDER BY  ID DESC")
                dgvMac.DataSource = dt
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMACManage", "SearchRecord", "BasicM")
        End Try
    End Sub

    Private Sub ExitFrom_Click(sender As Object, e As EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    Private Sub FileRefresh_Click(sender As Object, e As EventArgs) Handles FileRefresh.Click

        Dim sql As String = ""

        If Me.txtPartID.Text.Trim <> "" Then
            sql = sql + " AND a.partid like '%" + Me.txtPartID.Text.Trim.ToUpper + "%'"
        End If

        If Me.CboConsumer.Text.Trim <> "" Then
            sql = sql + " AND a.cusid like '%" + Me.CboConsumer.Text.Trim.Split("---")(0) + "%'"
        End If

        If Me.cboAssignState.Text.Trim <> "" Then
            sql = sql + " AND a.AssignState like '%" + Me.cboAssignState.Text.Trim.Split(".")(0) + "%'"
        End If

        If Not String.IsNullOrEmpty(Me.txtRemark.Text.Trim) Then
            sql = sql + " AND a.Remark like N'%" + Me.txtRemark.Text.Trim + "%'"
        End If

        SearchRecord(sql)

    End Sub

    Private Sub Search_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Me.txtPartID.Enabled = True
        Me.txtRemark.Enabled = True
        Me.cboAssignState.Enabled = True

        Me.txtPartID.Text = String.Empty
        Me.txtQty.Text = String.Empty


    End Sub

    Private Sub dgvMac_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMac.CellDoubleClick

        If IsNothing(dgvMac.CurrentRow) Then Exit Sub
        Dim o_strReqID As String = String.Empty

        o_strReqID = Me.dgvMac.CurrentRow.Cells(MacGrid.ID).Value


        Using o_FrmMacList As FrmMacList = New FrmMacList(o_strReqID)
            o_FrmMacList.ShowDialog()
        End Using


    End Sub

    Private Sub UnDo_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        Me.lblID.Text = ""
        Me.txtPartID.Text = ""
        Me.toolBack.Enabled = False
        Me.toolSave.Enabled = False
        Me.txtPartID.Enabled = True
        opflag = 0
        ToolbtnState(opflag)
    End Sub

    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        ExcelUtils.LoadDataToExcel(Me.dgvMac, Me.Text)
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Dim lsSQL As String = ""
        If dgvMac.Rows.Count < 1 Then Exit Sub
        If dgvMac.CurrentRow.Cells(MacGrid.ID).Value.ToString = "" Then Exit Sub
        If dgvMac.CurrentRow.Cells(MacGrid.AssignState).Value.ToString <> "0.Wait" Then
            MessageUtils.ShowError("不允许作废该记录")
            Exit Sub
        End If
        Dim MoHandle As New SysDataBaseClass
        If MessageBox.Show("你是否对该申请进行作废？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            lsSQL = " UPDATE m_PartMacaddress_t Set UseY='N',AssignState='" & EnumAssignState.NoNeed & "'" & _
                    " WHERE id='" & dgvMac.CurrentRow.Cells(MacGrid.ID).Value.ToString & "'"
            MoHandle.ExecSql(lsSQL)
            MessageBox.Show("申请作废成功...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SearchRecord("")
        End If
        MoHandle = Nothing
    End Sub


    Private Sub ToolCustMAC_Click(sender As Object, e As EventArgs) Handles ToolCustMAC.Click
        Dim frmMacRange As New FrmPartMacAddress()
        frmMacRange.Owner = Me
        frmMacRange.ShowDialog()
    End Sub
End Class