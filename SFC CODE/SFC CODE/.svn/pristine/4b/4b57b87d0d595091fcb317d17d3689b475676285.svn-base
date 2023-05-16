Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports MainFrame

Public Class FrmPIC

#Region "变量定义"
    Public opflag As Int16 = 0  '
    Private Enum enumdgvPIC
        DutyDeptName
        DutyUserID
        DutyEmail
        UserID
        Intime
        UseY
        ID
    End Enum
#End Region

    Private Sub FrmPIC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lsSQL As String = String.Empty

        'lsSQL = " SELECT DISTINCT cusid,cusname FROM m_Customer_t WHERE usey='Y' "
        ' FillGridCombox(Me.CobCust, lsSQL)
        FillCombox(Me.CobDept, " SELECT DISTINCT DutyDept FROM m_SampleDept_t WHERE 1=1 ")

        LoadDataToDatagridview()
        ToolbtnState(opflag)
        dgvPIC.Enabled = True
        CobDept.SelectedIndex = -1

    End Sub

    Private Sub FillGridCombox(ByVal CobName As ComboBox, ByVal SqlStr As String)
        Dim ScanClass As New SysDataBaseClass
        Dim ScanReader As SqlClient.SqlDataReader
        ScanReader = ScanClass.GetDataReader(SqlStr)
        CobName.Items.Clear()

        Do While ScanReader.Read()
            CobName.Items.Add(ScanReader(0).ToString & "--" & ScanReader(1).ToString)
        Loop
        ScanReader.Close()
        CobName.SelectedIndex = -1
    End Sub

    Private Sub FillCombox(ByVal CobName As ComboBox, ByVal SqlStr As String)
        Dim ScanClass As New SysDataBaseClass
        Dim ScanReader As SqlClient.SqlDataReader
        ScanReader = ScanClass.GetDataReader(SqlStr)
        CobName.Items.Clear()

        Do While ScanReader.Read()
            CobName.Items.Add(ScanReader(0).ToString)
        Loop
        ScanReader.Close()
        CobName.SelectedIndex = -1
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim SqlStr As New StringBuilder
        Dim o_strDept As String = "", o_strSQL As String = "", o_strCustID As String = "", o_strEmail As String = ""
        Dim o_strDutyUserID As String = "", o_strDutyUserName As String = ""

        Me.LblMsg.Text = ""

        If Checkdata() = False Then Exit Sub

        If IsNothing(CobDept.SelectedValue) Then
            o_strDept = Me.CobDept.Text.Trim()
        Else
            o_strDept = CobDept.SelectedValue.ToString.Trim()
        End If

        If Me.txtEmail.Text.Trim.Contains("@") Then
            o_strEmail = Me.txtEmail.Text.Trim
        Else
            o_strEmail = Me.txtEmail.Text.Trim + Me.lblMailSuffix.Text.Trim
        End If

        If SampleCom.IncludeChinese(Me.txtDutyUserID.Text.Trim) Then
            o_strDutyUserID = SampleCom.GetUserID(Me.txtDutyUserID.Text.Trim)
            If String.IsNullOrEmpty(o_strDutyUserID) Then
                Me.LblMsg.Text = "MES中不存在该用户的工号!"
                Exit Sub
            Else
                o_strDutyUserName = Me.txtDutyUserID.Text.Trim
            End If
        Else
            o_strDutyUserID = Me.txtDutyUserID.Text.Trim()
        End If

        If opflag = 1 Then
            o_strSQL = " SELECT DutyUserID FROM m_SamplePic_t " & _
                       " WHERE 1=1 " & _
                       " AND DutyDeptName=N'" & Me.CobDept.Text.Trim() & "' and DutyUserID ='" & o_strDutyUserID & "' And usey='Y' "
            Dim rowCnt As Integer = DbOperateUtils.GetRowsCount(o_strSQL)
            If rowCnt > 0 Then
                Me.LblMsg.Text = "该该责任单位该用户已经存在!"
                Exit Sub
            End If
            SqlStr.Append("INSERT INTO m_SamplePic_t( DutyDeptName,DutyUserID, DutyEmail, UserID, Intime,useY) ")
            SqlStr.Append(" VALUES ( N'" & o_strDept & "',N'" & o_strDutyUserID & "', N'" & o_strEmail & "',")
            SqlStr.Append(" '" & SysCheckData.SysMessageClass.UseId & "',GETDATE(), 'Y')")
        ElseIf opflag = 2 Then
            SqlStr.Append(" UPDATE m_SamplePic_t SET DutyUserID= N'" & o_strDutyUserID & "',")
            SqlStr.Append(" DutyEmail='" & o_strEmail & "',intime=getdate(),userid='" & SysCheckData.SysMessageClass.UseId & "' ")
            SqlStr.Append(" WHERE  DutyDeptName =N'" & o_strDept & "' AND DutyUserID ='" & o_strDutyUserID & "' ")
        End If
        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadDataToDatagridview()
            opflag = 0
            ToolbtnState(0)
            ClearUIValue(opflag)
            dgvPIC.Enabled = True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPIC", "toolSave_Click", "Sample")
            Exit Sub
        End Try
    End Sub

    Private Function Checkdata() As Boolean
        If 1 = 1 Then
            Checkdata = True
        Else
            Checkdata = False
        End If

        If String.IsNullOrEmpty(Me.txtEmail.Text) Then
            LblMsg.Text = "责任人邮箱地址不能为空..."
            Return False
        End If

        Return Checkdata
    End Function


    Private Sub LoadDataToDatagridview(Optional ByVal SqlWhere As String = "")
        Dim SqlStr As String =
            " SELECT DutyDeptName ,(DutyUserID+'/'+ b.UserName) DutyUserID," & _
            " DutyEmail , (a.UserID+'/' + d.UserName) UserID,a.Intime , " & _
            " (CASE a.[UseY] when 'Y' then 'Y-有效' else 'N-作廢' end)UseY, ID" & _
            " FROM  m_SamplePic_t a" & _
            " LEFT JOIN m_Users_t b ON a.DutyUserID = b.UserID" & _
            " LEFT JOIN m_Users_t d ON a.UserID = d.UserID" & _
            " WHERE 1=1 AND a.usey ='Y'"

        Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr & SqlWhere)

        dgvPIC.DataSource = dt
        Me.lblRecordCount.Text = dt.Rows.Count
        dgvPIC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        '" Left join m_ProductType_t  c ON c.typeid = a.typeid and c.useY='Y' " & _
    End Sub

    Private Sub ClearUIValue(ByVal flag As Integer)
        Select Case flag
            Case 0 'default
                ' Me.CobDept.Text = ""
                Me.LblMsg.Text = ""
            Case Else
        End Select
    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0  ''初始查詢狀態
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'GroupBox
                ' Me.ChkUsey.Checked = True
                Me.CobDept.Enabled = True
                Me.ActiveControl = Me.CobDept
            Case 1, 2
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'GroupBox
                CobDept.Enabled = IIf(opflag = 1, True, False)
            Case 3
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'GroupBox
                Me.CobDept.Enabled = True
                Me.ActiveControl = Me.CobDept
        End Select
    End Sub

    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Me.CobDept.SelectedIndex = -1
        ' txtLineLeaderID.Text = ""
        ' Me.txtLineManQty.Text = ""
        opflag = 1
        ToolbtnState(1)
        ' Me.ChkUsey.Checked = True 'Default
        Me.LblMsg.Text = ""
        Me.ToolReUse.Enabled = False 'Add by cq 20151222
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click

        If Me.dgvPIC.Rows.Count = 0 OrElse Me.dgvPIC.CurrentRow Is Nothing Then Exit Sub

        '  Me.CobCust.SelectedIndex = Me.CobCust.FindString(DbOperateUtils.DBNullToStr(dgvPIC.CurrentRow.Cells(enumdgvPIC.CustID).Value).Split("-")(0))

        CobDept.SelectedIndex = Me.CobDept.FindString(DbOperateUtils.DBNullToStr(dgvPIC.CurrentRow.Cells(enumdgvPIC.DutyDeptName).Value))

        If dgvPIC.CurrentRow.Cells(enumdgvPIC.DutyUserID).Value.ToString.Split("/").Length > 1 AndAlso (Not String.IsNullOrEmpty(dgvPIC.CurrentRow.Cells(enumdgvPIC.DutyUserID).Value.ToString.Split("/")(1))) Then
            Me.txtDutyUserID.Text = DbOperateUtils.DBNullToStr(dgvPIC.CurrentRow.Cells(enumdgvPIC.DutyUserID).Value).Split("/")(0)
        Else
            Me.txtDutyUserID.Text = DbOperateUtils.DBNullToStr(dgvPIC.CurrentRow.Cells(enumdgvPIC.DutyUserID).Value)
        End If
        If dgvPIC.CurrentRow.Cells(enumdgvPIC.DutyEmail).Value.ToString.Contains("@") Then
            Me.txtEmail.Text = DbOperateUtils.DBNullToStr(dgvPIC.CurrentRow.Cells(enumdgvPIC.DutyEmail).Value).Split("@")(0)
        Else
            Me.txtEmail.Text = DbOperateUtils.DBNullToStr(dgvPIC.CurrentRow.Cells(enumdgvPIC.DutyEmail).Value)
        End If
        ' txtLineManQty.Text = DbOperateUtils.DBNullToStr(dgvLineLeader.CurrentRow.Cells(enumdgvLineLeader.lineman).Value)

        opflag = 2
        ToolbtnState(2)

    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        opflag = 0
        ToolbtnState(0)
        ClearUIValue(opflag)
        Me.ToolReUse.Enabled = True
    End Sub

    '作废
    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        Dim lsSQL As New StringBuilder
        If Me.dgvPIC.Rows.Count = 0 OrElse Me.dgvPIC.CurrentRow Is Nothing Then Exit Sub
        Dim strDutyUserID As String = String.Empty
        Try
  
            lsSQL.Append("UPDATE m_SamplePic_t")
            lsSQL.Append("   SET usey = 'N'")
            lsSQL.Append("   WHERE 1=1 ")
            lsSQL.Append(" AND ID ='" & dgvPIC.CurrentRow.Cells(enumdgvPIC.ID).Value & "' ")

            DbOperateUtils.ExecSQL(lsSQL.ToString)
            LoadDataToDatagridview()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPIC", "toolAbandon_Click", "Sample")
        End Try
    End Sub

    Private Sub ToolReUse_Click(sender As Object, e As EventArgs) Handles ToolReUse.Click
        Dim o_sbSQL As New StringBuilder
        If Me.dgvPIC.Rows.Count = 0 OrElse Me.dgvPIC.CurrentRow Is Nothing Then Exit Sub
        Dim strDutyUserID As String = String.Empty
        Try
            strDutyUserID = dgvPIC.CurrentRow.Cells(enumdgvPIC.DutyUserID).Value.ToString.Split("/")(0)

            With Me.dgvPIC.CurrentRow
                If .Cells(enumdgvPIC.UseY).Value = "Y" Then
                    MessageBox.Show("该条记录已经生效,无需再生效！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                o_sbSQL.Append(" UPDATE m_SamplePic_t")
                o_sbSQL.Append(" SET USEY = 'Y'")
                o_sbSQL.Append(" WHERE 1=1 ")
                o_sbSQL.Append(" AND DutyDeptName =N'" & .Cells(enumdgvPIC.DutyDeptName).Value & "'")
                o_sbSQL.Append(" AND DutyUserID ='" & strDutyUserID & "'")
            End With
            DbOperateUtils.ExecSQL(o_sbSQL.ToString)
            LoadDataToDatagridview()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPIC", "ToolReUse_Click", "Sample")
        End Try
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click

    End Sub

    Private Sub ToolRefresh_Click(sender As Object, e As EventArgs) Handles ToolRefresh.Click
        Dim SqlStr As String = ""

        If Me.CobDept.Text <> "" Then
            SqlStr = " AND a.DutyDeptName = N'" & Me.CobDept.Text.Trim() & "'"
        End If

        SearchRecord(SqlStr)
    End Sub

    Private Sub SearchRecord(ByVal Sqlstring As String)
        Dim dt As DataTable = Nothing
        If Sqlstring = "" Then
            dt = GetPICList("")
            dgvPIC.DataSource = dt
        Else
            dt = GetPICList(Sqlstring)
            dgvPIC.DataSource = dt
        End If
        'SampleNo, CustID,DeliveryDate,DevNo,PartNo,Qty,Intime,UserID, Status
        'Dim ChColsText As String = "样品单号|客户代码|需求日期|开发案号|料件编号|数量|维护时间|维护人|状态"
        Me.dgvPIC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Public Shared Function GetPICList(Sqlstring As String) As DataTable
        Dim dt As DataTable
        'SELECT (CustID +'--'+ c.CusName) 客户,DutyDeptName 责任单位,DutyUserID+'/'+ b.UserName 责任人," & _
        '  DutyUserID+'/'+ b.UserName 责任人,''DutyUserID 责任人
        Dim StrSql As String = "SELECT TOP 1000  DutyDeptName," & _
            " (DutyUserID+'/'+ C.UserName) DutyUserID," & _
            " DutyEmail,a.Intime, (a.UserID +'/'+  d.UserName) UserID, " & _
            " (Case a.UseY when 'Y' then 'Y-有效' else 'N-作廢' end) UseY,a.ID" & _
            " FROM m_SamplePic_t a " & _
            " LEFT JOIN m_Users_t(nolock) c ON c.userid = a.dutyUserID   " & _
            " LEFT JOIN m_Users_t(nolock) d ON d.userid = a.userid   " & _
            " WHERE 1=1 " & Sqlstring
        StrSql = StrSql & " ORDER BY a.intime DESC"
        dt = DbOperateUtils.GetDataTable(StrSql)
        Return dt
    End Function

    Private Sub txtDutyUserID_MouseLeave(sender As Object, e As EventArgs) Handles txtDutyUserID.MouseLeave
        Dim strDBUserMail As String = ""
        If Not String.IsNullOrEmpty(Me.txtDutyUserID.Text) Then
            If SampleCom.IncludeChinese(Me.txtDutyUserID.Text) Then
                strDBUserMail = SampleBusiness.GetUserMail(SampleCom.GetUserID(Me.txtDutyUserID.Text.Trim))
                If (Not String.IsNullOrEmpty(strDBUserMail)) Then
                    Me.txtEmail.Text = SampleBusiness.GetUserMail(SampleCom.GetUserID(Me.txtDutyUserID.Text.Trim))
                Else
                    'do nothing 
                End If
            Else
                strDBUserMail = SampleBusiness.GetUserMail(Me.txtDutyUserID.Text)
                If (Not String.IsNullOrEmpty(strDBUserMail)) Then
                    Me.txtEmail.Text = SampleBusiness.GetUserMail(Me.txtDutyUserID.Text)
                End If
            End If
        End If
    End Sub

    Private Sub ToolAddDutyName_Click(sender As Object, e As EventArgs) Handles ToolAddDutyName.Click
        'RDUserName,YWUserName,PZUserName,YPSUserName,EquUserName,SGUserName,PIEUserName,ZJUserName
        Dim strRDUserID As String = String.Empty, strCurrentDeptName As String = String.Empty
        Dim frm As FrmSampleDefaultName = New FrmSampleDefaultName

        strRDUserID = DbOperateUtils.DBNullToStr(dgvPIC.CurrentRow.Cells(enumdgvPIC.DutyUserID).Value)

        strCurrentDeptName = DbOperateUtils.DBNullToStr(dgvPIC.CurrentRow.Cells(enumdgvPIC.DutyDeptName).Value)

        frm.m_strRDUserID = strRDUserID.Split("/")(0)

        If strCurrentDeptName <> SampleCom.EnumSampleDept.研发.ToString Then
            MessageUtils.ShowError("非研发部门不允许维护！")
            Exit Sub
        End If

        'check if have permission 
        If frm.m_strRDUserID <> VbCommClass.VbCommClass.UseId Then
            MessageUtils.ShowError("只允许维护自己的默认责任人群组！")
            Exit Sub
        End If


        frm.m_strYWDutyName = SampleCom.GetDefaultPICUserNames(frm.m_strRDUserID, SampleCom.EnumSampleDept.业务.ToString)
        frm.m_strPZDutyName = SampleCom.GetDefaultPICUserNames(frm.m_strRDUserID, SampleCom.EnumSampleDept.品质.ToString)
        frm.m_strYPSDutyName = SampleCom.GetDefaultPICUserNames(frm.m_strRDUserID, SampleCom.EnumSampleDept.样品室.ToString)
        frm.m_strEquDutyName = SampleCom.GetDefaultPICUserNames(frm.m_strRDUserID, SampleCom.EnumSampleDept.设备.ToString)
        frm.m_strSGDutyName = SampleCom.GetDefaultPICUserNames(frm.m_strRDUserID, SampleCom.EnumSampleDept.生管.ToString)
        frm.m_strPIEDutyName = SampleCom.GetDefaultPICUserNames(frm.m_strRDUserID, SampleCom.EnumSampleDept.PIE.ToString)
        frm.m_strZEquDutyName = SampleCom.GetDefaultPICUserNames(frm.m_strRDUserID, SampleCom.EnumSampleDept.治具.ToString)
        frm.m_strRDDutyName = SampleCom.GetDefaultPICUserNames(frm.m_strRDUserID, SampleCom.EnumSampleDept.研发.ToString)
        Dim result As DialogResult = frm.ShowDialog()

        'If result = Windows.Forms.DialogResult.OK Then
        '    SearchRecord(" AND a.sampleno = '" & frm.m_strSampleNO & "'")
        'End If
    End Sub

    Private Sub dgvPIC_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPIC.CellClick
        Try
            If e.RowIndex = -1 Then Exit Sub


            LoadSampleRDDetail(e.RowIndex)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadSampleRDDetail(curRowIndex As Integer)
        Dim strSQL As String = ""
        Dim strRDUserID As String = ""
        Dim strWhere As String = String.Empty
        Try
            If dgvPIC.Rows.Count = 0 Then
                Exit Sub
            End If
            '     LevelID Status DutyUserID,StartTime EndTime
            strSQL =
                " SELECT DISTINCT a.DeptName,a.DutyUserName" & _
                " FROM m_SampleDefaultPIC_t a " & _
                " LEFT JOIN m_SamplePIC_t b ON a.RDUserID = b.DutyUserID  " & _
                " WHERE 1=1 "

            '0.编号, 1.
            If IsNothing(dgvPIC.Rows(curRowIndex).Cells(enumdgvPIC.DutyUserID).Value) OrElse IsDBNull(dgvPIC.Rows(curRowIndex).Cells(enumdgvPIC.DutyUserID).Value) Then
                Exit Sub
            Else
                strRDUserID = dgvPIC.Rows(curRowIndex).Cells(enumdgvPIC.DutyUserID).Value.ToString.Split("/")(0)
            End If

            strWhere = String.Format(" AND a.RDUserID = '{0}'", strRDUserID)
            Dim strOrder As String = "" ' ORDER BY a.intime
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrder)

            dgvRDPIC.DataSource = dt

            dgvRDPIC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPIC", "LoadSampleDetail", "Sample")
        End Try
    End Sub
End Class