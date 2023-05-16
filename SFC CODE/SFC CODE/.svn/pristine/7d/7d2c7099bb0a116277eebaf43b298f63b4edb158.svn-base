Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Text

Public Class FrmTestSFCStaion
    Public opflag As Int16 = 0  '
    Public sPartId As String
    Dim SqlSearch As String = "", m_strSqlWhere As String = ""
    Public newPartIdm As String  '复制料号的新料号
    Private Sub FrmTestSFCStaion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPartID.Text = sPartId
        m_strSqlWhere = GetSqlWhere()
        LoadTestSFCStation()
        ToolbtnState(opflag)
    End Sub
    Private Function GetSqlWhere() As String
        Dim sbSqlWhere As New StringBuilder
        'If Not String.IsNullOrEmpty(sPartId) Then
        '    GetSqlWhere = GetSqlWhere & " and a.PARTID like N'%" & sPartId & "%' "
        'End If

        If String.IsNullOrEmpty(txtPartID.Text.Trim) = False Then
            sbSqlWhere.Append(" and a.PARTID like N'%" & Me.txtPartID.Text.Trim & "%' ")
        End If

        If String.IsNullOrEmpty(txtTestTypeID.Text.Trim) = False Then
            sbSqlWhere.Append(" and a.TestTypeID like N'%" & Me.txtTestTypeID.Text.Trim & "%' ")
        End If

        If String.IsNullOrEmpty(txtTestTypeName.Text.Trim) = False Then
            sbSqlWhere.Append(" and c.TestTypeName like N'%" & Me.txtTestTypeName.Text.Trim & "%' ")
        End If

        If String.IsNullOrEmpty(txtMESStationid.Text.Trim) = False Then
            sbSqlWhere.Append(" and a.MesStationId like N'%" & Me.txtMESStationid.Text.Trim & "%' ")
        End If

        If String.IsNullOrEmpty(txtStationName.Text.Trim) = False Then
            sbSqlWhere.Append(" and b.Stationname like N'%" & Me.txtStationName.Text.Trim & "%' ")
        End If
        Return sbSqlWhere.ToString
    End Function

    Private Sub LoadTestSFCStation()
        Dim Where = " "
        Dim StrSql As String = "select a.PARTID,a.TestTypeId,c.TestTypeName,a.MesStationId,b.Stationname,a.PassCount,a.Usey,a.userid,a.intime " &
                                                 " from m_TestStationPart_t a left join m_Rstation_t b on a.MesStationId=b.Stationid " &
                                                 " left join mesdb.dbo.m_TestType_v c on a.TestTypeId=c.TestTypeId " &
                                                 "where 1=1 " & GetSqlWhere()
        Dim DtContrast As DataTable = DbOperateUtils.GetDataTable(StrSql)
        dgvQuery.DataSource = DtContrast
        'If DtContrast.Rows.Count > 0 Then
        '    For i As Byte = 0 To DtContrast.Rows.Count - 1
        '        Me.dgvQuery.Rows.Add(DtContrast.Rows.Item(i)("PARTID").ToString, DtContrast.Rows.Item(i)("TestTypeName").ToString, _
        '                                 DtContrast.Rows.Item(i)("MesStationId").ToString, DtContrast.Rows.Item(i)("PassCount").ToString, _
        '                                 DtContrast.Rows.Item(i)("Usey").ToString, DtContrast.Rows.Item(i)("userid").ToString, _
        '                                 DtContrast.Rows.Item(i)("intime").ToString)
        '    Next
        'End If

        '[172.20.23.107].[MESDataCenter].dbo.m_TestType_t
    End Sub

    Private Sub btnTestStaion_Click(sender As Object, e As EventArgs) Handles btnTestStaion.Click
        Dim frm As New FrmTestDataRules
        frm.ShowDialog()
        Me.txtTestTypeID.Text = frm.frmRTestTypeid
        Me.txtTestTypeName.Text = frm.frmRTestTypenName
    End Sub
    '
    Private Sub BnSelectSta_Click(sender As Object, e As EventArgs) Handles BnSelectSta.Click
        Dim frm1 As New FrmRStationSet
        frm1.opflag = 3
        frm1.ShowDialog()
        Me.txtMESStationid.Text = frm1.frmRstationid
        Me.txtStationName.Text = frm1.frmRstationname
    End Sub

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        opflag = 0
        ToolbtnState(0)
    End Sub
   
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.ToolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.ToolQuery.Enabled = True
                'GroupBox
                Me.txtPartID.Enabled = True
                Me.txtTestTypeID.Enabled = True
                Me.txtMESStationid.Enabled = True
                Me.txtStationName.Enabled = True
                'Me.ActiveControl = Me.txtPartID
            Case 1 'New
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.ToolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.ToolQuery.Enabled = False
                'GroupBox
                Me.txtPartID.Enabled = True
                Me.txtTestTypeID.Enabled = True
                Me.txtMESStationid.Enabled = True
                Me.txtStationName.Enabled = True
                'Me.ActiveControl = IIf(opflag = 1, Me.txtPartID, Me.txtTestTypeID)
            Case 2 'Edit
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.ToolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.ToolQuery.Enabled = False
                'GroupBox
                Me.txtPartID.Enabled = True
                Me.txtTestTypeID.Enabled = True
                Me.txtMESStationid.Enabled = True
                Me.txtStationName.Enabled = True
            Case 3 '
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.ToolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.ToolQuery.Enabled = True
                'GroupBox
                Me.txtPartID.Enabled = True
                Me.txtTestTypeID.Enabled = True
                Me.txtMESStationid.Enabled = True
                Me.txtStationName.Enabled = True
                'Me.ActiveControl = Me.txtPartID
        End Select
    End Sub
    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        LoadTestSFCStation()
    End Sub

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        SysMessageClass.EditFlag = True
        'ChgRecord(0)
        txtTestTypeID.Text = ""
        txtMESStationid.Text = ""
        txtStationName.Text = ""
        Me.txtPartID.Enabled = True
        opflag = 1
        ToolbtnState(1)
        'ClearControl()
        txtPartID.Focus()
        If sPartId <> "" Then
            txtPartID.Text = sPartId
        End If
    End Sub
    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim SqlStr As New StringBuilder
        Dim mCheckCodeRead As DataTable = Nothing
        '新增保存
        If opflag = 1 Then
            mCheckCodeRead = DbOperateUtils.GetDataTable("SELECT TestTypeId FROM m_TestStationPart_t WHERE PARTID='" & Me.txtPartID.Text.Trim() & "' AND TestTypeId='" & Me.txtTestTypeID.Text.Trim() & "'")
            If mCheckCodeRead.Rows.Count > 0 Then
                MessageUtils.ShowInformation("该笔资料已存在，请修改！")
                Exit Sub
            End If
            If txtPassCount.Text = "" Then
                Me.txtPassCount.Text = "1"
            End If
            SqlStr.AppendFormat(" IF NOT EXISTS(SELECT 1 FROM m_TestStationPart_t WHERE PARTID = '{0}' AND TestTypeId = '{1}') ",
                                txtPartID.Text.Trim, txtTestTypeID.Text.Trim)
            SqlStr.Append(" BEGIN")
            SqlStr.Append("     INSERT INTO m_TestStationPart_t(PARTID, TestTypeId, PassCount, MesStationId, Usey,Userid,Intime)")
            SqlStr.AppendFormat(" VALUES ( N'{0}','{1}','{2}'", txtPartID.Text.Trim, txtTestTypeID.Text.Trim, txtPassCount.Text.Trim)
            SqlStr.AppendFormat(" ,N'{0}','Y','{1}',getdate())", txtMESStationid.Text.Trim, VbCommClass.VbCommClass.UseId)
            SqlStr.Append(" END")

            '修改保存
        ElseIf opflag = 2 Then
            sPartId = dgvQuery.CurrentRow.Cells(0).Value.ToString.Trim
            SqlStr.Append(" UPDATE m_TestStationPart_t ")
            SqlStr.AppendFormat(" SET TestTypeId = N'{0}',PassCount='{1}',", txtTestTypeID.Text.Trim, txtPassCount.Text.Trim)
            SqlStr.AppendFormat("Usey ='{0}',", IIf(chkUsey.Checked = True, "Y", "N"))
            SqlStr.AppendFormat("Userid ='{0}',Intime=getdate()", VbCommClass.VbCommClass.UseId)
            SqlStr.Append(" WHERE PARTID = '" & sPartId & "' AND MesStationId='" & Me.txtMESStationid.Text & "'")
        End If
        Try
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadTestSFCStation()
            txtTestTypeID.Text = ""
            txtTestTypeName.Text = ""
            txtMESStationid.Text = ""
            txtStationName.Text = ""
            txtPartID.Text = ""
            txtPassCount.Text = ""
            opflag = 0
            ToolbtnState(0)
            MessageUtils.ShowInformation("保存成功！")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmTestSFCStaion", "toolSave_Click", "BasicM")
            Exit Sub
        End Try

    End Sub
    '修改，改变按钮状态
    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then Exit Sub
        Dim Usey As String = ""
        txtPartID.Text = DbOperateUtils.DBNullToStr(dgvQuery.CurrentRow.Cells("colPartID").Value)
        txtTestTypeID.Text = DbOperateUtils.DBNullToStr(dgvQuery.CurrentRow.Cells("TestSationID").Value)
        txtTestTypeName.Text = DbOperateUtils.DBNullToStr(dgvQuery.CurrentRow.Cells("TestStationName").Value)
        txtMESStationid.Text = DbOperateUtils.DBNullToStr(dgvQuery.CurrentRow.Cells("MesStationId").Value)
        txtStationName.Text = DbOperateUtils.DBNullToStr(dgvQuery.CurrentRow.Cells("Stationname").Value)
        txtPassCount.Text = DbOperateUtils.DBNullToStr(dgvQuery.CurrentRow.Cells("PassCount").Value)
        Usey = DbOperateUtils.DBNullToStr(dgvQuery.CurrentRow.Cells("Usey").Value)
        chkUsey.Checked = IIf(Usey = "Y", True, False)
        opflag = 2
        ToolbtnState(2)
    End Sub


#Region "Grid行数"

    Private Sub dgvEquipment_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvQuery.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

#End Region

    '作废
    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        Dim SqlStr As New StringBuilder
        If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then Exit Sub
        Try
            SqlStr.Append(" UPDATE m_TestStationPart_t ")
            SqlStr.Append(" SET Usey = 'N' WHERE PARTID = '" & Me.dgvQuery.CurrentRow.Cells("colPartID").Value & "' AND TestTypeId='" & Me.dgvQuery.CurrentRow.Cells("TestSationID").Value & "'")
            DbOperateUtils.ExecSQL(SqlStr.ToString)
            LoadTestSFCStation()
            MessageUtils.ShowInformation("作废成功！")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmTestSFCStaion", "toolAbandon_Click", "sys")
        End Try
    End Sub

    Private Sub ToolCopy_Click(sender As Object, e As EventArgs) Handles ToolCopy.Click
        Try
            Dim strSQL As String = String.Format("select 1 from dbo.m_TestStationPart_t where Partid='{0}'", Me.txtPartID.Text.Trim)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count < 1 Then
                MessageUtils.ShowInformation("料号没有设置测试工站，不可复制!")
                Return
            End If

            Dim fr As FrmRTestStationPartCopy = New FrmRTestStationPartCopy
            fr.Owner = Me
            fr.oldPartId = Me.txtPartID.Text.Trim
            fr.ShowDialog()
            'Me.Label7.Text = "1222222222"
            FrmTestSFCStaion_Load(sender, e)
            Me.txtPartID.Text = newPartIdm
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmTestSFCStaion", "btnCopy_Click", "sys")
            Exit Sub
        End Try
    End Sub

End Class