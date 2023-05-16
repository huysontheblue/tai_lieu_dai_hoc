Imports System.Text
Imports MainFrame.SysCheckData
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame

Public Class FrmModelOutLineStationSet

#Region "公共变量定义"
    Public opflag As Int16 = 0

    Private Enum gridStationSet
        ModeID
        PartID
        StationID
        StationName
        UseY
        UserID
        Intime
    End Enum
#End Region

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim SqlStr As New StringBuilder
        Dim TreeCount As String = ""
        Dim lsSQL As String = ""
        Dim o_strStationName As String = ""
        Dim o_useY As String = ""

        If Checkdata() = False Then Exit Sub
        o_useY = IIf(chkIsUseY.Checked = True, "Y", "N")

        lsSQL = "SELECT PartID FROM m_RPartStationModel_t WHERE ModeID='" & Me.txtModeID.Text.Trim() &
                "' and partid ='" & txtPartID.Text.Trim & "' and stationid ='" & txtStaionID.Text.Trim & "'"

        Dim o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
        If o_dt.Rows.Count > 0 Then
            MessageUtils.ShowInformation("此料号中已存在线外工站！")
            Exit Sub
        End If

        If Not IsRightPN(txtPartID.Text.Trim) Then
            Me.LblMsg.Text = "输入的料号[" & txtPartID.Text & "]在料件表中不存在，请检查！"
            Me.txtPartID.Focus()
            Exit Sub
        End If

        If opflag = 1 Then
            SqlStr.Append(ControlChars.CrLf & "INSERT into m_RPartStationModel_t([ModeID],[PartID] ,[Stationid] ,[Stationname],[usey],[UserID],[Intime],Factoryid,Profitcenter)")
            SqlStr.Append(" VALUES('" & txtModeID.Text & "',N'" & txtPartID.Text.Trim & "','" & Me.txtStaionID.Text.Trim & "',N'" & txtStaionName.Text.Trim &
                            "','" & o_useY & "','" & VbCommClass.VbCommClass.UseId & "',getdate(),  ")
            SqlStr.Append(" '" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "' )")

        ElseIf opflag = 2 Then
            Dim modeid As String = dgvModelOutLineStation.Rows(dgvModelOutLineStation.SelectedCells(0).RowIndex).Cells("ModeID").Value
            Dim partid As String = dgvModelOutLineStation.Rows(dgvModelOutLineStation.SelectedCells(0).RowIndex).Cells("PartID").Value
            Dim stationid As String = dgvModelOutLineStation.Rows(dgvModelOutLineStation.SelectedCells(0).RowIndex).Cells("Stationid").Value

            SqlStr.Append(" UPDATE m_RPartStationModel_t SET PartID =N'" & txtPartID.Text.Trim & "',UseY =N'" & o_useY &
                                "' ,Stationid = '" & txtStaionID.Text.Trim & "', Stationname = N'" & txtStaionName.Text.Trim & "'")
            SqlStr.Append(" WHERE ModeID = '" & modeid & "' AND partid ='" & partid & "' and Stationid ='" & stationid & "'")
        End If
        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadDataToDatagridview(" ")

            txtPartID.Text = ""
            txtPartID.Text = ""
            opflag = 0
            ToolbtnState(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmModelOutLineStationSet", "tsbSave_Click", "BasicM")
            Exit Sub
        End Try
    End Sub
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim SqlStr As String = ""
        Try


            SqlStr = " SELECT ModeID ,[PartID],StationID,StationName,a.UseY," & _
                     " (a.UserID+'/'+b.UserName)UserID,a.Intime  " & _
                     " FROM m_RPartStationModel_t a LEFT JOIN m_users_t  b ON a.userid = b.userid  " & _
                     " WHERE 1=1 "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr & SqlWhere)

            dgvModelOutLineStation.Rows.Clear()
            For iIndex As Integer = 0 To dt.Rows.Count - 1
                dgvModelOutLineStation.Rows.Add(
                    dt.Rows(iIndex)!ModeID, dt.Rows(iIndex)!PartID,
                    dt.Rows(iIndex)!StationID.ToString, dt.Rows(iIndex)!StationName, dt.Rows(iIndex)!UseY,
                    dt.Rows(iIndex)!UserID, dt.Rows(iIndex)!Intime)
            Next

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmModelOutLineStationSet", "LoadDataToDatagridview", "BasicM")
        End Try
    End Sub


    Private Function Checkdata() As Boolean
        If Me.txtModeID.Text.Trim = "" Then
            LblMsg.Text = "机种代码不能为空..."
            Me.ActiveControl = Me.txtModeID
            Return False
        End If
        If Me.txtPartID.Text.Trim = "" Then
            LblMsg.Text = "料号不能为空..."
            Me.ActiveControl = Me.txtPartID
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtStaionID.Text.Trim) Then
            LblMsg.Text = "线外工站不能为空..."
            Me.ActiveControl = Me.txtStaionID
            Return False
        End If
        Return True
    End Function

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 'default
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'Me.toolCheck.Enabled = False

                'GroupBox
                'Me.txtModeID.Enabled = False
                'Me.txtPartID.Enabled = False
                'Me.txtPartID.Enabled = False
                ' Me.dgvPackList.Enabled = False

                Me.ActiveControl = Me.txtModeID
            Case 1, 2  '1, 2.Edit
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                Me.txtPartID.Enabled = True
                Me.BnSelectSta.Enabled = True

                'GroupBox
                ' Me.txtRequestQty.Enabled = True
                If opflag = 2 Then  'edit
                    Me.txtModeID.Enabled = False
                End If
            Case 3
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'GroupBox
                'Me.txtRequestQty.Enabled = False
                Me.txtPartID.Enabled = True
                Me.txtPartID.Enabled = True
                Me.dgvModelOutLineStation.Enabled = True

                Me.ActiveControl = Me.txtPartID
        End Select
    End Sub

    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        txtModeID.Text = ""
        txtStaionID.Text = ""
        txtPartID.Text = ""
        opflag = 1
        ToolbtnState(1)
        txtModeID.Enabled = True
    End Sub

    Private Sub FrmModelOutLineStationSet_Load(sender As Object, e As EventArgs) Handles Me.Load
        'LoadDataToCombox()
        LoadDataToDatagridview(" ")
        ToolbtnState(opflag)
        dgvModelOutLineStation.Enabled = True
    End Sub

    Private Sub BnSelectSta_Click(sender As Object, e As EventArgs) Handles BnSelectSta.Click
        Try
            Dim frmQuery As New FrmQuery("select Stationid,Stationname from m_Rstation_v ", 0, "Stationid,Stationname")
            frmQuery.ShowDialog()
            If frmQuery.ReturnValue.Split(",").Length > 1 Then
                txtStaionID.Text = frmQuery.ReturnValue.Split(",")(0)
                txtStaionName.Text = frmQuery.ReturnValue.Split(",")(1)
            End If

        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try

    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim SqlStr As String = ""
        If Me.txtModeID.Text <> "" Then
            SqlStr = " AND ModeID LIKE '%" & Trim(txtModeID.Text) & "%'"
        End If
        If Me.txtPartID.Text <> "" Then
            SqlStr = " AND  PartID like '%" & Trim(txtPartID.Text) & "%'"
        End If

        LoadDataToDatagridview(SqlStr)
    End Sub

    Private Sub FileRefresh_Click(sender As Object, e As EventArgs)
        Dim SqlStr As String = ""
        If Me.txtModeID.Text <> "" Then
            SqlStr = " AND ModeID LIKE '%" & Trim(txtModeID.Text) & "%'"
        End If
        If Me.txtPartID.Text <> "" Then
            SqlStr = " AND  PartID like '%" & Trim(txtPartID.Text) & "%'"
        End If

        LoadDataToDatagridview(SqlStr)
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If Me.dgvModelOutLineStation.Rows.Count = 0 OrElse Me.dgvModelOutLineStation.CurrentRow Is Nothing Then Exit Sub
        txtModeID.Text = dgvModelOutLineStation.CurrentRow.Cells(gridStationSet.ModeID).Value
        txtPartID.Text = dgvModelOutLineStation.CurrentRow.Cells(gridStationSet.PartID).Value
        txtStaionID.Text = dgvModelOutLineStation.CurrentRow.Cells(gridStationSet.StationID).Value
        txtStaionName.Text = dgvModelOutLineStation.CurrentRow.Cells(gridStationSet.StationName).Value

        If dgvModelOutLineStation.CurrentRow.Cells(gridStationSet.UseY).Value = "Y" Then
            Me.chkIsUseY.Checked = True
        Else
            Me.chkIsUseY.Checked = False
        End If

        opflag = 2
        ToolbtnState(2)
    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        If Me.dgvModelOutLineStation.Rows.Count = 0 OrElse Me.dgvModelOutLineStation.CurrentRow Is Nothing Then Exit Sub
        Dim lsSQL As String = ""
        Try
            lsSQL = "  UPDATE m_RPartStationModel_t SET USEY = 'N' " & _
                    "  WHERE ModeID = '" & dgvModelOutLineStation.CurrentRow.Cells(gridStationSet.ModeID).Value &
                    "' and PartID = '" & dgvModelOutLineStation.CurrentRow.Cells(gridStationSet.PartID).Value &
                    "' and stationid = '" & dgvModelOutLineStation.CurrentRow.Cells(gridStationSet.StationID).Value & "'"
            DbOperateUtils.ExecSQL(lsSQL)

            LoadDataToDatagridview(" ")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmModelOutLineStationSet", "tsbAbandon_Click", "BasicM")
        End Try
    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        txtModeID.Text = ""
        txtPartID.Text = ""
        txtStaionID.Text = ""
        txtStaionName.Text = ""
        Me.BnSelectSta.Enabled = True
        opflag = 0
        ToolbtnState(0)
    End Sub

    Private Function IsRightPN(ByVal strPN As String) As Boolean
        Dim lssql As String = String.Empty
        lssql = " select top 1 1 from m_PartContrast_t where tavcpart ='" & strPN & "' "
        Try
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    IsRightPN = True
                Else
                    IsRightPN = False
                End If
            End Using
            Return IsRightPN
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
End Class