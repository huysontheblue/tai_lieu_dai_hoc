Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmRTestStationPartCopy

    Public oldPartId As String  '旧料号
    Public newPartId As String  '新料号

#Region "初始化"
    Private Sub FrmRPartStationCopy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lblPartId.Text = oldPartId
    End Sub
#End Region

#Region "事件"
    '复制
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Dim newPartId As String = Me.txtPartId.Text.Trim
        If newPartId = "" Then Exit Sub

        Dim strSQL As String
        Dim dt As New DataTable
        Dim isAllowRe As String = "N"
        Try

            Dim str As String = String.Format("你确定要复制旧料号{0}测试工站到新料号{1}吗?", oldPartId, newPartId)
            If MessageBox.Show(str, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub

            If IsBarcodeHaveSS() = True Then
                isAllowRe = "Y"
            End If

            strSQL = " declare @strmsgid varchar(1),@strmsgText nvarchar(500) " &
                     " exec [Exec_CopyTestStationPart] '{0}','{1}',@strmsgid output,@strmsgText output" &
                     " select @strmsgid,@strmsgText "
            strSQL = String.Format(strSQL, Me.txtPartId.Text.Trim, oldPartId, isAllowRe, SysMessageClass.UseId.Trim.ToLower)

            dt = DbOperateUtils.GetDataTable(strSQL)
            Dim fr As FrmTestSFCStaion = New FrmTestSFCStaion
            MessageUtils.ShowInformation("复制测试工站成功")
            Me.Close()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRTestStationPartCopy", "btnCopy_Click", "sys")
            Exit Sub
        End Try
    End Sub
    '回车键查询料号
    Private Sub txtPartId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPartId.KeyPress
        If String.IsNullOrEmpty(Me.txtPartId.Text.Trim) Then
            Exit Sub
        End If
        If e.KeyChar = Chr(13) Then
            LoadPartId()
        End If
    End Sub
    '查询
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        If String.IsNullOrEmpty(Me.txtPartId.Text.Trim) Then
            Exit Sub
        End If

        LoadPartId()
    End Sub

    Private Sub dgvPartId_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPartId.CellClick
        Try
            If Me.dgvPartId.RowCount = 0 OrElse Me.dgvPartId.CurrentRow Is Nothing Then Exit Sub

            txtPartId.Text = Me.dgvPartId.Rows(Me.dgvPartId.CurrentRow.Index).Cells("Partid").Value.ToString()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRTestStationPartCopy", "dgvPartId_CellClick", "sys")
            Exit Sub
        End Try
    End Sub
#End Region

#Region "方法"
    '判断是否产品条码
    Private Function IsBarcodeHaveSS() As Boolean
        Dim strSQL As String =
            " select PARTID,Packid ,CodeRuleID from " &
            " (SELECT PARTID,STUFF((SELECT ',' + Packid FROM m_PartPack_t WHERE PARTID=A.PARTID AND StatusFlag = '2' AND Packid LIKE '%S%' FOR XML PATH('')),1, 1, '') AS Packid, " &
            " STUFF((SELECT ',' + CodeRuleID FROM m_PartPack_t WHERE PARTID=A.PARTID AND StatusFlag = '2' AND Packid LIKE '%S%' FOR XML PATH('')),1, 1, '') AS CodeRuleID" &
            " FROM m_PartPack_t A where Usey = 'Y' and StatusFlag = '2'" &
            " GROUP BY PARTID) AA WHERE Packid LIKE '%S%' and Partid = '{0}'"

        If txtPartId.Text <> "" Then
            strSQL = String.Format(strSQL, txtPartId.Text)
        Else
            strSQL = String.Format(strSQL, txtPartId.Text)
        End If

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 1 Then
            Return True
        End If
        Return False
    End Function
    '加载料号信息
    Private Sub LoadPartId()
        Dim strSQL As String
        Try
            strSQL = "select DISTINCT PARTID,TestTypeId,MesStationId,PassCount FROM dbo.m_TestStationPart_t WHERE  usey='Y'"

            If Me.txtPartId.Text.Trim <> "" Then
                strSQL = strSQL & " and PARTID like '" & Me.txtPartId.Text.Trim & "%' "
            End If

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            Me.dgvPartId.DataSource = dt
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRPartStationPartCopy", " LoadPartId", "sys")
            Exit Sub
        End Try
    End Sub
#End Region
End Class