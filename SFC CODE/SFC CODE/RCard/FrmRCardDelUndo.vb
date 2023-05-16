Imports MainFrame
Imports System.Text
Imports MainFrame.SysCheckData

Public Class FrmRCardDelUndo

    Private _ismultiline As Boolean = False
    Public Property IsMultiLine() As Boolean
        Get
            Return _ismultiline
        End Get

        Set(ByVal Value As Boolean)
            _ismultiline = Value
        End Set
    End Property


    Private Sub ToolRefresh_Click(sender As Object, e As EventArgs) Handles ToolRefresh.Click

        QueryDataToGrid()

    End Sub

    Private Sub QueryDataToGrid(Optional ByVal blnRCardMode As Boolean = False)

        Dim SqlStr As String = ""
        Dim FiterSqlStr As String = ""
        FiterSqlStr = GetFiterString()
        If FiterSqlStr = "" Then
            TlelCount.Text = "0"
            Exit Sub
        End If
        LoadDataInGrid(FiterSqlStr)

    End Sub

    Private Sub LoadDataInGrid(Optional ByVal FiterSqlStr As String = "")
        Dim K As Integer
        Dim UserDg As DataTable
        Dim Sqlstr As String
        DgRCardData.Rows.Clear()
        DgRCardData.ScrollBars = ScrollBars.None


        Sqlstr = " SELECT   PartID from m_RCardMBak_t a  WHERE partid NOT IN (SELECT partid  FROM dbo.m_RCardM_t)"


        UserDg = DbOperateUtils.GetDataTable(Sqlstr & FiterSqlStr & " Order by baktime desc")


        For K = 0 To UserDg.Rows.Count - 1
            DgRCardData.Rows.Add("False", UserDg.Rows(K)("PartID"))
        Next

        DgRCardData.ScrollBars = ScrollBars.Both
        TlelCount.Text = CStr(UserDg.Rows.Count)
        DgRCardData.AutoResizeColumns()
        DgRCardData.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    End Sub



    Private Function GetFiterString(Optional blnRCardMO As Boolean = False) As String

        Dim SqlStr As String = ""
        Dim MoComBoxStr As String = ""
        Dim mos As String = Nothing

        'For Each sMO As String In TxtParts.Text.Trim.Split(CChar(vbNewLine))
        '    If Not String.IsNullOrEmpty(sMO.Trim) Then
        '        mos &= "'" & sMO.ToUpper.Trim & "'" & ","
        '    End If
        'Next

        'If Not String.IsNullOrEmpty(mos) Then
        '    mos = mos.Trim(CChar(","))
        '    SqlStr = " WHERE A.Moid IN(" & mos & ")"
        'End If

        If Me.txtPartNumber.Text.Trim <> "" Then
            If (Me.txtPartNumber.Text.Trim.Split(";").Length > 1) Then
                IsMultiLine = True
                Dim str As String = "and a.PartID in ("
                Dim strloop As String = ""
                For i = 0 To Me.txtPartNumber.Text.Trim.Split(";").Length - 1
                    strloop = strloop + ",'" + Me.txtPartNumber.Text.Trim.Split(";")(i) + "'"
                Next
                SqlStr = str + strloop.Substring(1) + ")"
                'sql = sql + " AND a.PartNumber LIKE N'%" & Me.txtPartNumber.Text.Trim & "%' "
            Else
                SqlStr = SqlStr + " AND a.PartID LIKE N'%" & Me.txtPartNumber.Text.Trim & "%' "
            End If
        End If


        'If SqlStr = "" Then
        '    SqlStr = " WHERE CONVERT(datetime,CONVERT(varchar(10), Createtime,120)) BETWEEN '" & DtStarDate.Value.ToShortDateString & "' AND '" & DtEndDate.Value.ToShortDateString & "'"
        'Else
        '    SqlStr = SqlStr & " AND CONVERT(datetime,CONVERT(varchar(10), Createtime,120)) BETWEEN '" & DtStarDate.Value.ToShortDateString & "' and '" & DtEndDate.Value.ToShortDateString & "'"
        'End If


        If Me.ckDateBegin.Checked Then
            SqlStr = SqlStr + " AND convert(date,isnull(BakTime,Intime)) >=CONVERT(date,'" & Me.dateTimeFrom.Text & "',120 )"
        End If
        If Me.ckDateEnd.Checked Then
            SqlStr = SqlStr + " AND convert(date,isnull(BakTime,Intime)) <=CONVERT(date,'" & Me.dateTimeTo.Text & "',120 )"
        End If


        'Add by CQ 20151010
        If SqlStr = "" Then
            SqlStr = " AND Factoryid='" & VbCommClass.VbCommClass.Factory & "'"
        Else
            SqlStr = SqlStr + "  AND Factoryid='" & VbCommClass.VbCommClass.Factory & "'"
        End If
        If Not String.IsNullOrEmpty(VbCommClass.VbCommClass.profitcenter) Then
            SqlStr = SqlStr + " AND a.profitcenter='" & VbCommClass.VbCommClass.profitcenter & "'"
        End If
        Return SqlStr
    End Function


    Private Sub FrmRCardDelUndo_Load(sender As Object, e As EventArgs) Handles Me.Load




    End Sub

    Private Sub ToolReEnd_Click(sender As Object, e As EventArgs) Handles ToolReEnd.Click
        Dim sb As New StringBuilder
        'Fisrt check whether is exist
        For Each row As DataGridViewRow In DgRCardData.Rows
            If row.Cells(0).EditedFormattedValue = True Then
                sb.Append(" INSERT into m_RCardD_t( [PartID] ,[StationID] ,[DrawingVer]  ,[StationSQ],[WorkingHours] ,[Equipment] ,[ProcessStandard] ,[Remark]")
                sb.Append(",[Status] ,[Shape],[NewProcessStandard],[VariableName1],[VariableValue1] ,[VariableName2],[VariableValue2],[Factoryid] ,[Profitcenter]")
                sb.Append(" ,[UserID] ,[InTime]  ,[FinishSize]) ")
                sb.Append(" SELECT  PartID ,StationID ,DrawingVer  ,StationSQ,[WorkingHours] ,[Equipment] ,[ProcessStandard] ,[Remark],[Status]")
                sb.Append(",[Shape],[NewProcessStandard],[VariableName1],[VariableValue1],[VariableName2] ,[VariableValue2],[Factoryid]")
                sb.Append(",[Profitcenter],[UserID],[InTime]  ,[FinishSize]")
                sb.Append(" FROM m_RCardDBak_t WHERE  PartID='" & row.Cells(1).Value & "'" & RCardComBusiness.GetFatoryProfitcenter())

                sb.Append(" Insert into m_RCardDCheckItem_t([PartID],[Stationid]")
                sb.Append(",[CheckItemID],[Description]")
                sb.Append(" ,[ResultValue],[Status],[CheckGroup],[UserID],[InTime]")
                sb.Append(",[LeftTVPN],[LeftWirePN1],[LeftWirePN2],[LeftWirePN3],[LeftWirePN4]")
                sb.Append(",[RightTVPN],[RightWirePN1],[RightWirePN2],[RightWirePN3],[RightWirePN4]")
                sb.Append(",[FinishSize],[LeftCutSize]")
                sb.Append(" ,[RightCutSize],[Tolerance]")
                sb.Append(" ,[ToleranceRange],[Factoryid],[Profitcenter]")
                sb.Append(",[LeftTVPNShow],[RightTVPNShow],[CardType])")
                sb.Append(" select [PartID],[Stationid]")
                sb.Append(",[CheckItemID],[Description]")
                sb.Append(" ,[ResultValue],[Status],[CheckGroup],[UserID],[InTime]")
                sb.Append(",[LeftTVPN],[LeftWirePN1],[LeftWirePN2],[LeftWirePN3],[LeftWirePN4]")
                sb.Append(" ,[RightTVPN],[RightWirePN1],[RightWirePN2],[RightWirePN3],[RightWirePN4]")
                sb.Append(",[FinishSize],[LeftCutSize]")
                sb.Append(" ,[RightCutSize],[Tolerance]")
                sb.Append(" ,[ToleranceRange],[Factoryid],[Profitcenter]")
                sb.Append(" ,[LeftTVPNShow],[RightTVPNShow],[CardType]")
                sb.Append(" FROM m_RCardDCheckItemBak_t a  WHERE  PartID='" & row.Cells(1).Value & "'" & RCardComBusiness.GetFatoryProfitcenter("A"))

                '恢复
                sb.Append(" Insert into m_RCardDPart_t([PartID],[Stationid],[EWPartNumber]")
                sb.Append(",[DrawingVer],[UserID],[InTime],[Factoryid],[Profitcenter]")
                sb.Append(" ,[EWPNType],[EWPNLRDirection],CardType)")
                sb.Append(" SELECT [PartID],[Stationid],[EWPartNumber]")
                sb.Append(" ,[DrawingVer],[UserID],[InTime]")
                sb.Append(",[Factoryid],[Profitcenter],[EWPNType]")
                sb.Append(",[EWPNLRDirection],[CardType] from m_RCardDPartBak_t a where PartID='" & row.Cells(1).Value & "'" & RCardComBusiness.GetFatoryProfitcenter("A"))

                sb.Append(" INSERT  INTO m_RCardM_t([PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]")
                sb.Append(",[Profitcenter],[UserID],[InTime],ModifyTime) ")
                sb.Append(" SELECT [PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]")
                sb.Append(",[Profitcenter],[UserID],[InTime],[ModifyTime] FROM m_RCardMBak_t WHERE  PartID='" & row.Cells(1).Value & "'" & RCardComBusiness.GetFatoryProfitcenter())

                sb.Append("  DELETE A FROM m_RCardDCheckItemBak_t A,m_RCardDBak_t B ")
                sb.Append(" WHERE B.PartID='" & row.Cells(1).Value & "' ")
                sb.Append(" AND B.PartID=A.PartID AND B.Stationid=B.Stationid " & RCardComBusiness.GetFatoryProfitcenter("B"))

                sb.Append(" DELETE A FROM m_RCardDPartBak_t A,m_RCardDBak_t B ")
                sb.Append(" WHERE B.PartID='" & row.Cells(1).Value & "'  AND B.PartID=A.PartID " & RCardComBusiness.GetFatoryProfitcenter("B"))

                sb.Append(" DELETE FROM m_RCardDBak_t WHERE  PartID='" & row.Cells(1).Value & "'" & RCardComBusiness.GetFatoryProfitcenter())
                sb.Append(" DELETE FROM m_RCardMBak_t WHERE  PartID='" & row.Cells(1).Value & "'" & RCardComBusiness.GetFatoryProfitcenter())
            End If
        Next

        If sb.ToString <> "" Then
            DbOperateUtils.ExecSQL(sb.ToString)
            MessageUtils.ShowInformation(" 恢复成功！")
        Else
            MessageUtils.ShowWarning("请至少选择一条！")
        End If

        LoadDataInGrid("")


    End Sub






    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click

    End Sub

    Private Sub txtPartNumber_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtPartNumber.ButtonCustomClick
        Dim obj As New SysBasicClass.InputText(txtPartNumber)
        obj.ShowDialog()
    End Sub

    Private Sub ExitFrom_Click(sender As Object, e As EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub
End Class