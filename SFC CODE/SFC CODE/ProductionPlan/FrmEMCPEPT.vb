Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle

Public Class FrmEMCPEPT

    Private Sub FrmEMCPEPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserRight()
        DataLoad()
    End Sub

    Dim UserID = VbCommClass.VbCommClass.UseId

    Private Sub UserRight()
        For Each tsmi As ToolStripItem In ToolStrip1.Items
            If String.IsNullOrEmpty(tsmi.Tag) = False Then
                Dim count = MainFrame.DbOperateUtils.GetDataTable("select Tkey from m_UserRight_t where UserID='" & UserID & "' and Tkey='" & tsmi.Tag & "'").Rows.Count
                tsmi.Enabled = IIf(count > 0, True, False)
            End If
        Next
    End Sub

#Region "数据加载"
    ''' <summary>
    ''' 数据加载
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DataLoad()
        Dim sql As String = "select top 500 * from dbo.m_EMCPEPT_t where usey='Y'"
        If String.IsNullOrEmpty(TxtMoid.Text.Trim) = False Then
            sql += " and moid='" & TxtMoid.Text.Trim & "'"
        End If
        If String.IsNullOrEmpty(txtLine.Text.Trim()) = False Then
            sql += " and lineid='" & txtLine.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(txtPartID.Text.Trim()) = False Then
            sql += " and partid='" & txtPartID.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(dtStart.Text.Trim) = False And String.IsNullOrEmpty(dtEnd.Text.Trim) = False Then
            sql += " and ProductDate>=convert(date,'" & dtStart.Text.Trim & "') and ProductDate<=convert(date,'" & dtEnd.Text.Trim & "')"
        End If
        sql += " order by intime desc"
        dgvData.AutoGenerateColumns = False
        dgvData.DataSource = DbOperateReportUtils.GetDataTable(sql)
    End Sub
#End Region

#Region "新增事件"
    ''' <summary>
    ''' 新增事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NewFile_Click(sender As Object, e As EventArgs) Handles NewFile.Click
        Dim frmAdd = New FrmAddEMCPEPT()
        frmAdd.Owner = Me
        Dim dr As DialogResult = frmAdd.ShowDialog()
        'If dr = DialogResult.OK Then
        '    DataLoad()
        'End If
    End Sub
#End Region

#Region "编辑事件"
    ''' <summary>
    ''' 编辑事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EditFile_Click(sender As Object, e As EventArgs) Handles EditFile.Click
        Dim dgvr = dgvData.CurrentRow
        If dgvr Is Nothing Then
            MessageUtils.ShowWarning("请选择一行数据")
            Return
        End If
        Dim frmEdit = New FrmEditEMCPEPT(dgvr.Cells("ColMOID").Value.ToString(), dgvr.Cells("ColProductDate").Value.ToString())
        Dim dr = frmEdit.ShowDialog()
        If dr = DialogResult.OK Then
            DataLoad()
        End If
    End Sub
#End Region

#Region "作废事件"
    ''' <summary>
    ''' 作废事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Dim dgvr = dgvData.CurrentRow
        If dgvr Is Nothing Then
            MessageUtils.ShowError("请选择一行要作废的数据!")
            Exit Sub
        End If
        If DialogResult.OK = MessageUtils.ShowConfirm("确定要作废该行的数据嘛?", MessageBoxButtons.OKCancel) Then
            If Not dgvr Is Nothing Then
                Dim moid = dgvr.Cells("ColMOID").Value
                Dim ProductDate = dgvr.Cells("ColProductDate").Value
                Dim sql = "delete m_EMCPEPT_t  where moid='" & moid & "' and ProductDate='" & ProductDate & "'"
                sql += " delete m_EMCPEPTD_t  where moid='" & moid & "' and ProductDate='" & ProductDate & "'"
                DbOperateUtils.ExecSQL(sql)
                MessageUtils.ShowInformation("作废成功")
                DataLoad()
            End If
        End If
    End Sub
#End Region

#Region "退出事件"
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
#End Region

#Region "查询事件"
    ''' <summary>
    ''' 查询事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        DataLoad()
    End Sub
#End Region

#Region "dgvData_SelectionChanged事件"
    Private Sub dgvData_SelectionChanged(sender As Object, e As EventArgs) Handles dgvData.SelectionChanged
        Dim dgvr = dgvData.CurrentRow
        Dim MOID As String = dgvr.Cells("ColMOID").Value.ToString()
        Dim ProductDate = dgvr.Cells("ColProductDate").Value.ToString()
        Dim sql = "select * from dbo.m_EMCPEPTD_t where moid='" & MOID & "' and ProductDate='" & ProductDate & "'"
        dgvDataDetail.AutoGenerateColumns = False
        dgvDataDetail.DataSource = DbOperateUtils.GetDataTable(sql)

        Dim count = MainFrame.DbOperateUtils.GetDataTable("select Tkey from m_UserRight_t where UserID='" & UserID & "' and Tkey='" & EditFile.Tag & "'").Rows.Count
        EditFile.Enabled = IIf(count > 0, True, False)
        If EditFile.Enabled = False Then
            Dim yy = DbOperateUtils.GetDataTable("select MachineNumber from m_EMCPEPTd_t where MOId='" & MOID & "' and ProductDate='" & ProductDate & "' and MachineNumber is null").Rows.Count
            If yy > 0 Then
                EditFile.Enabled = True
            End If
        End If
    End Sub
#End Region

#Region "清空查询条件"
    ''' <summary>
    ''' 清空查询条件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        dtStart.CustomFormat = " "
        dtEnd.CustomFormat = " "
        TxtMoid.Text = ""
        txtLine.Text = ""
        txtPartID.Text = ""
    End Sub
#End Region

#Region "dtStart_ValueChanged事件"
    Private Sub dtStart_ValueChanged(sender As Object, e As EventArgs) Handles dtStart.ValueChanged
        dtStart.CustomFormat = "yyyy-MM-dd"
    End Sub
#End Region

#Region "dtEnd_ValueChanged事件"
    Private Sub dtEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtEnd.ValueChanged
        dtEnd.CustomFormat = "yyyy-MM-dd"
    End Sub
#End Region

#Region "EMC设备配置信息"
    ''' <summary>
    ''' EMC设备配置信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsBtnItemPeiZhi_Click(sender As Object, e As EventArgs) Handles tsBtnItemPeiZhi.Click
        If dgvData.CurrentRow Is Nothing Then
            MessageUtils.ShowError("请选择一行数据!")
            Exit Sub
        End If
        Dim frm = New FrmEMCEquipmentconfig()
        frm.PartID = dgvData.CurrentRow.Cells("ColPartID").Value.ToString()
        frm.Show()
    End Sub
#End Region

#Region "复制设备配置"
    ''' <summary>
    ''' 复制设备配置
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsBtnItemCopyPeiZhi_Click(sender As Object, e As EventArgs) Handles tsBtnItemCopyPeiZhi.Click
        Dim frm As FrmCopyPeiZhi = New FrmCopyPeiZhi()
        frm.txtOldPartID.Text = dgvData.CurrentRow.Cells("ColPartID").Value
        Dim dia = frm.ShowDialog()
    End Sub
#End Region

End Class