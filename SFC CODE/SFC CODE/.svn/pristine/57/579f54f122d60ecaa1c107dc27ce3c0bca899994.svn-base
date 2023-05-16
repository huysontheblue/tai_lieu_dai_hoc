Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Text


Public Class FrmEditEMCPEPT
    Private MoId As String = ""
    Private ProductDate As String = ""
    Private m_RowIndex As Integer = 0

    Private LinerConfirm As String = ""
    Private IPQCConfirm As String = ""

#Region "构造函数"
    ''' <summary>
    ''' 构造函数
    ''' </summary>
    ''' <param name="Moid">工单编号</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Moid As String, ByVal ProductDate As String)
        InitializeComponent()
        Me.MoId = Moid
        Me.ProductDate = ProductDate
        Dim sql As String = "select * from dbo.m_EMCPEPT_t where moid='" & Me.MoId & "' and  ProductDate='" & ProductDate & "'"
        Dim dt = DbOperateUtils.GetDataTable(sql)
        If dt.Rows.Count > 0 Then
            txtMOID.Text = dt.Rows(0)("moid").ToString()
            txtProductDate.Text = Convert.ToDateTime(dt.Rows(0)("ProductDate").ToString()).ToString("yyyy-MM-dd")
            txtLineID.Text = dt.Rows(0)("LineID").ToString()
            txtPartID.Text = dt.Rows(0)("PartID").ToString()
            txtLineleaderName.Text = dt.Rows(0)("LineleaderCode").ToString() + "-" + dt.Rows(0)("LineleaderName").ToString()
            txtBiotechName.Text = dt.Rows(0)("BiotechCode").ToString() + "-" + dt.Rows(0)("BiotechName").ToString()
            txtIPQCName.Text = dt.Rows(0)("IPQCCode").ToString() + "-" + dt.Rows(0)("IPQCName").ToString()
            txtLinerConfirm.Text = dt.Rows(0)("LinerConfirm").ToString()
            txtIPQCConfirm.Text = dt.Rows(0)("IPQCConfirm").ToString()
        End If
    End Sub
#End Region

    Private Sub FrmEditEMCPEPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataLoad()
    End Sub

#Region "数据加载"
    ''' <summary>
    ''' 数据加载
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataLoad()
        Dim sql As String = "select * from dbo.m_EMCPEPTD_t " & vbCrLf &
        "where moid='" + Me.MoId + "' and ProductDate='" & ProductDate & "'"
        dgvData.AutoGenerateColumns = False
        dgvData.DataSource = DbOperateUtils.GetDataTable(sql)
    End Sub
#End Region

#Region "提交之前检验数据的有效性"
    ''' <summary>
    ''' 提交之前检验数据的有效性
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckDataIsOk() As Boolean
        Try
            For Each dgvr As DataGridViewRow In dgvData.Rows
                Dim StationNumber = dgvr.Cells("ColStationNumber").Value.ToString()
                Dim MachineNumber = dgvr.Cells("ColMachineNumber").Value.ToString().Trim()
                Dim ProductCode = dgvr.Cells("ColProductCode").Value.ToString().Trim()
                If String.IsNullOrEmpty(MachineNumber) Or String.IsNullOrEmpty(ProductCode) Then
                    MessageUtils.ShowError("工站编号:" + StationNumber + ",机台编号或者生产人员有空值,不可提交!")
                    Return False
                End If
            Next
            Dim Liner = txtLineleaderName.Text.Trim().Split("-")(0)
            Dim IPQC = txtIPQCName.Text.Trim().Split("-")(0)
            If String.IsNullOrEmpty(txtLinerConfirm.Text.Trim()) Then
                MessageUtils.ShowError("请扫描线长确认!")
                txtLinerConfirm.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(txtIPQCConfirm.Text.Trim()) Then
                MessageUtils.ShowError("请扫描IPQC确认!")
                txtIPQCConfirm.Focus()
                Return False
            End If
            If Liner <> txtLinerConfirm.Text.Trim() Then
                MessageUtils.ShowError("线长:" + txtLinerConfirm.Text.Trim() + ",与工单线长:" & Liner & "不相符!")
                Return False
            End If
            If IPQC <> txtIPQCConfirm.Text.Trim() Then
                MessageUtils.ShowError("IPQC:" & txtIPQCConfirm.Text.Trim() & ",与工单IPQC:" & IPQC & "不相符")
                Return False
            End If
        Catch ex As Exception
            MessageUtils.ShowError("发生异常:" & vbCrLf & "" + ex.Message)
            Return False
        End Try
        Return True
    End Function
#End Region

#Region "提交"
    ''' <summary>
    ''' 提交
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        Dim sql As New StringBuilder
        Try
            If IsNothing(dgvData.CurrentRow) Then
                MessageUtils.ShowError("请至少选中一条记录！")
                Exit Sub
            ElseIf CheckDataIsOk() = False Then
                Exit Sub
            End If
            Dim EquimentStr = ""
            For Each dgvr As DataGridViewRow In dgvData.Rows
                sql.Append(" UPDATE m_EMCPEPTD_t ")
                sql.Append(" SET MachineNumber='" & dgvr.Cells("ColMachineNumber").Value & "'")
                sql.Append(", ProductCode='" & dgvr.Cells("ColProductCode").Value & "'")
                sql.Append(" , Remark=N'" & dgvr.Cells("ColRemark").Value & "'")
                sql.Append("where moid='" & Me.MoId & "' and ProductDate='" & ProductDate & "' and StationNumber=" & dgvr.Cells("ColStationNumber").Value & "")
                '  DbOperateUtils.ExecSQL(sql)
                EquimentStr += dgvr.Cells("ColMachineNumber").Value + ","
            Next
            sql.AppendLine(" exec Exec_EquipmentMoSet '" & txtMOID.Text.Trim & "','" & txtLineID.Text.Trim & "','" & EquimentStr.Substring(0, EquimentStr.Length - 1) & "'")
            sql.AppendLine("update m_EMCPEPT_t set LinerConfirm='" & txtLinerConfirm.Text.Trim() & "',IPQCConfirm='" & txtIPQCConfirm.Text.Trim() & "' where moid='" & Me.MoId & "' and  ProductDate='" & ProductDate & "'")
            DbOperateUtils.ExecSQL(sql.ToString)
            MessageUtils.ShowInformation("提交成功")
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageUtils.ShowError("提交失败:\n" + ex.Message)
        End Try
    End Sub
#End Region

#Region "设置扫描颜色"
    ''' <summary>
    ''' 设置扫描颜色
    ''' </summary>
    ''' <param name="v"></param>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Private Sub SetMessage(ByVal v As Boolean, ByVal message As String)
        Me.txtScaneMessage.ForeColor = IIf(v, System.Drawing.Color.Green, System.Drawing.Color.Red)
        Me.txtScaneMessage.Text = message
    End Sub
#End Region

#Region "扫描机台"
    ''' <summary>
    ''' 扫描机台
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtEquNoList_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEquNoList.KeyPress
       
        If e.KeyChar = Chr(13) Then
            If String.IsNullOrEmpty(txtEquNoList.Text.Trim()) Then
                SetMessage(False, "请扫描机台编号!")
                Exit Sub
            End If

            For Each dgvr As DataGridViewRow In dgvData.Rows
                Dim StationNumber = dgvr.Cells("ColStationNumber").Value.ToString()
                Dim MachineNumber = dgvr.Cells("ColMachineNumber").Value.ToString().Trim()
                If MachineNumber.Contains(txtEquNoList.Text.Trim()) And txtEquNoList.Text.Trim() <> "NO" Then
                    Dim msg = ("工站编号:" + StationNumber + ",机台编号:" + txtEquNoList.Text.Trim() + ",已经录入过,不可重复录入!")
                    SetMessage(False, msg)
                    txtEquNoList.Text = String.Empty
                    Exit Sub
                End If
            Next
            If txtEquNoList.Text.Trim.ToUpper.EndsWith("END") Then
                txtEquNoList.Text = String.Empty
                Me.txtUserIDList.Focus()
                SetMessage(True, "机台END扫描通过!")
                Exit Sub
            End If

            Dim EquimentNO = ""
            Dim sql = "select EquimentNO from m_EMCEquipmentconfig_t where NO='" & (m_RowIndex + 1) & "' and PartID='" & txtPartID.Text.Trim & "'"
            Dim dt = DbOperateUtils.GetDataTable(sql)
            Dim StationNumberOne = dgvData.Rows(m_RowIndex).Cells("ColStationNumber").Value.ToString()
            If dt.Rows.Count > 0 Then
                EquimentNO = dt.Rows(0)(0).ToString().Trim()
            End If

            If EquimentNO <> txtEquNoList.Text.Trim() Then
                SetMessage(False, "工站编号:" + StationNumberOne + ",机台编号:" + txtEquNoList.Text.Trim() + ",与设备配置的机台编号不相符,请核实!")
                txtEquNoList.Text = String.Empty
                Exit Sub
            End If

            Dim MachineNumberCurrent = dgvData.Rows(m_RowIndex).Cells("ColMachineNumber").Value.ToString().Trim()
            If String.IsNullOrEmpty(MachineNumberCurrent) Then
                MachineNumberCurrent = txtEquNoList.Text.Trim().ToUpper()
            Else
                MachineNumberCurrent &= "," + txtEquNoList.Text.Trim().ToUpper()
            End If
            dgvData.Rows(m_RowIndex).Cells("ColMachineNumber").Value = MachineNumberCurrent
            SetMessage(True, "机台编号:" & txtEquNoList.Text.Trim().ToUpper() & "扫描通过!")
            txtEquNoList.Text = String.Empty
        End If
    End Sub
#End Region

#Region "扫描工号"
    ''' <summary>
    ''' 扫描工号
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtUserIDList_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUserIDList.KeyPress
        If e.KeyChar = Chr(13) Then
           
            If String.IsNullOrEmpty(txtUserIDList.Text.Trim) Then
                SetMessage(False, "请扫描工号!")
                Exit Sub
            End If
            If txtUserIDList.Text.Trim.ToUpper.EndsWith("END") Then
                Me.txtRemark.Focus()
                txtUserIDList.Text = String.Empty
                SetMessage(True, "工号END扫描通过!")
                Exit Sub
            End If

            'If CheckUserIsExist(txtUserIDList.Text.Trim()) = False Then
            '    SetMessage(False, "工号:" + txtUserIDList.Text.Trim().ToUpper() + ",没有MES系统权限,扫描失败!")
            '    txtUserIDList.Text = String.Empty
            '    Exit Sub
            'End If

            Dim sql = "select EmpCode from m_EMCEquipmentconfig_t where NO='" & (m_RowIndex + 1) & "' and PartID='" & txtPartID.Text.Trim & "'"
            Dim StationNumberOne = dgvData.Rows(m_RowIndex).Cells("ColStationNumber").Value.ToString()
            Dim EmpCode = ""
            Dim dt = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                EmpCode = dt.Rows(0)(0).ToString().Trim()
            End If

            If EmpCode <> txtUserIDList.Text.Trim Then
                SetMessage(False, "工站编号:" + StationNumberOne + ",员工工号:" + txtUserIDList.Text.Trim + ",与设备配置的员工工号不相符,请核实!")
                txtUserIDList.Text = String.Empty
                Exit Sub
            End If

            Dim ProductCode = dgvData.Rows(m_RowIndex).Cells("ColProductCode").Value.ToString().Trim()
            If String.IsNullOrEmpty(ProductCode) Then
                ProductCode = txtUserIDList.Text.Trim().ToUpper()
            Else
                ProductCode &= "," + txtUserIDList.Text.Trim().ToUpper()
            End If
            dgvData.Rows(m_RowIndex).Cells("ColProductCode").Value = ProductCode
            SetMessage(True, "工号:" & txtUserIDList.Text.Trim().ToUpper() & "扫描通过!")
            txtUserIDList.Text = String.Empty
            Dim sqlJobName = "select JobName from m_EMCEquipmentconfig_t where NO='" & (m_RowIndex + 1) & "' and PartID='" & txtPartID.Text.Trim & "'"
            Dim dtJobName = DbOperateUtils.GetDataTable(sqlJobName)
            If dtJobName.Rows.Count > 0 Then
                dgvData.Rows(m_RowIndex).Cells("ColRemark").Value = dtJobName.Rows(0)(0).ToString
            End If
        End If
    End Sub
#End Region

#Region "扫描备注"
    ''' <summary>
    ''' 扫描备注
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtRemark_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRemark.KeyPress
        If e.KeyChar = Chr(13) Then
            If String.IsNullOrEmpty(txtRemark.Text.Trim) Then
                Exit Sub
            End If

            If txtRemark.Text.Trim.ToUpper.EndsWith("END") Then
                If m_RowIndex <= dgvData.Rows.Count - 2 Then
                    m_RowIndex = m_RowIndex + 1
                    Me.txtEquNoList.Focus()
                    SetMessage(True, "备注END扫描通过!")
                    txtRemark.Text = String.Empty
                Else
                    txtRemark.Text = String.Empty
                End If
                dgvData.ClearSelection()
                dgvData.Rows(m_RowIndex).Selected = True
                Exit Sub
            End If
            If m_RowIndex <= dgvData.Rows.Count - 1 Then
                dgvData.Rows(m_RowIndex).Cells("ColRemark").Value = txtRemark.Text.Trim().ToUpper()
                SetMessage(True, "备注扫描通过!")
                txtRemark.Text = String.Empty
            End If
        End If
    End Sub
#End Region

#Region "清空扫描文本"
    ''' <summary>
    ''' 清空扫描文本
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearScanText()
        Me.txtEquNoList.Text = String.Empty
        Me.txtUserIDList.Text = String.Empty
        Me.txtRemark.Text = String.Empty
    End Sub
#End Region

#Region "单元格单击事件"
    ''' <summary>
    ''' 单元格单击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellClick
        m_RowIndex = dgvData.CurrentRow.Index
        txtEquNoList.Focus()
    End Sub
#End Region

#Region "线长确认"
    ''' <summary>
    ''' 线长确认
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtLinerConfirm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLinerConfirm.KeyPress
        If e.KeyChar = Chr(13) Then
            If String.IsNullOrEmpty(txtLinerConfirm.Text.Trim()) Then
                Exit Sub
            End If
            Me.LinerConfirm = txtLinerConfirm.Text.Trim()
            Dim Liner = txtLineleaderName.Text.Trim().Split("-")(0)
            If CheckUserIsExist(Me.LinerConfirm) = False Then
                SetMessage(False, "线长:" + Me.LinerConfirm + ",没有MES系统权限,扫描失败!")
                Me.LinerConfirm = String.Empty
                txtLinerConfirm.Text = String.Empty
                Exit Sub
            ElseIf Liner <> txtLinerConfirm.Text.Trim() Then
                SetMessage(False, "线长:" + Me.LinerConfirm + ",与工单线长:" & Liner & "不相符!")
                Me.LinerConfirm = String.Empty
                txtLinerConfirm.Text = String.Empty
                Exit Sub
            End If
            SetMessage(True, "线长:" + Me.LinerConfirm + ",扫描通过!")
            Me.txtIPQCConfirm.Focus()
        End If
    End Sub
#End Region

#Region "IPQC确认"
    ''' <summary>
    ''' IPQC确认
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtIPQCConfirm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIPQCConfirm.KeyPress
        If e.KeyChar = Chr(13) Then
            If String.IsNullOrEmpty(txtIPQCConfirm.Text.Trim()) Then
                Exit Sub
            End If
            Me.IPQCConfirm = txtIPQCConfirm.Text.Trim()
            Dim IPQC = txtIPQCName.Text.Trim().Split("-")(0)

            If CheckUserIsExist(Me.IPQCConfirm) = False Then
                SetMessage(True, "IPQC:" + Me.IPQCConfirm + ",没有MES系统权限,扫描失败!")
                Me.IPQCConfirm = String.Empty
                txtIPQCConfirm.Text = String.Empty
                Exit Sub
            ElseIf IPQC <> txtIPQCConfirm.Text.Trim() Then
                SetMessage(False, "IPQC:" & Me.IPQCConfirm & ",与工单IPQC:" & IPQC & "不相符")
                Me.IPQCConfirm = String.Empty
                txtIPQCConfirm.Text = String.Empty
                Exit Sub
            End If
            SetMessage(True, "IPQC:" + Me.IPQCConfirm + ",扫描通过!")
        End If
    End Sub
#End Region

#Region "验证扫描用户时候有MES的权限"
    ''' <summary>
    ''' 验证扫描用户时候有MES的权限
    ''' </summary>
    ''' <param name="UserID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckUserIsExist(ByVal UserID As String) As Boolean
        Dim dt = MainFrame.DbOperateUtils.GetDataTable("select * from m_Users_t where UserID='" & UserID & "'")
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Return True
    End Function
#End Region

End Class