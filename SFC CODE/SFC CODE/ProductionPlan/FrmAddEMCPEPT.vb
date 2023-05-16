Imports MainFrame
Imports MainFrame.SysCheckData
Imports DBUtility
Imports System.Windows

Public Class FrmAddEMCPEPT

#Region "属性"
    Private _LineleaderName As String

    ''' <summary>
    ''' 线长姓名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LineleaderName() As String
        Get
            Return _LineleaderName
        End Get
        Set(ByVal value As String)
            _LineleaderName = value
        End Set
    End Property

    Private _BiotechName As String
    ''' <summary>
    ''' 生技姓名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BiotechName() As String
        Get
            Return _BiotechName
        End Get
        Set(ByVal value As String)
            _BiotechName = value
        End Set
    End Property

    Private _IPQCName As String
    ''' <summary>
    ''' IPQC姓名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IPQCName() As String
        Get
            Return _IPQCName
        End Get
        Set(ByVal value As String)
            _IPQCName = value
        End Set
    End Property
#End Region


#Region "扫描工单事件"
    ''' <summary>
    ''' 扫描工单事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtMoid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMoid.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim sql As String = "select * from dbo.m_Mainmo_t where moid='" & TxtMoid.Text.Trim & "'"
            Dim dt = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                TxtLineID.Text = dt.Rows(0)("lineid").ToString()
                TxtPartID.Text = dt.Rows(0)("partid").ToString()
                dt = DbOperateUtils.GetDataTable("select * from deptlineD_t where lineid='" & TxtLineID.Text & "' and usey='Y'")
                If dt.Rows.Count > 0 Then
                    TxtLineleaderCode.Text = dt.Rows(0)("leaderid").ToString().Trim()
                    TxtBiotechCode.Text = dt.Rows(0)("SjCode").ToString().Trim()
                    TxtIPQCCode.Text = dt.Rows(0)("PqeCode").ToString().Trim()
                    TxtStationTotal.Focus()
                Else
                    TxtLineleaderCode.Focus()
                End If
                dt = DbOperateUtils.GetDataTable("select StationTotal from dbo.m_EMCPEPT_t where MOID='" & TxtMoid.Text.Trim & "'")
                If dt.Rows.Count > 0 Then
                    TxtStationTotal.Text = dt.Rows(0)(0).ToString()
                End If
            Else
                MessageUtils.ShowWarning("工单:" + TxtMoid.Text.Trim + ",在MES系统不存在!")
                Return
            End If
        End If
    End Sub
#End Region



#Region "提交事件"
    ''' <summary>
    ''' 提交事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Try
            If CheckIsValiate() = False Then
                Return
            End If
            Me.LineleaderName = getNameByCode(TxtLineleaderCode.Text.Trim)
            Me.BiotechName = getNameByCode(TxtBiotechCode.Text.Trim())
            Me.IPQCName = getNameByCode(TxtIPQCCode.Text)
            Dim sql As String = String.Format(" exec exec_Addm_EMCPEPT_t '{0}','{1}','{2}','{3}','{4}',N'{5}','{6}',N'{7}','{8}',N'{9}',{10},{11}",
            TxtMoid.Text.Trim, dtProductDate.Text, TxtLineID.Text, TxtPartID.Text, TxtLineleaderCode.Text, Me.LineleaderName, TxtBiotechCode.Text, Me.BiotechName, TxtIPQCCode.Text, Me.IPQCName, TxtStationTotal.Text, txtWorkersNum.Text.Trim())
            DbOperateUtils.ExecSQL(sql)
            MessageUtils.ShowInformation("提交成功!")
            Dim frmMain = CType(Me.Owner, FrmEMCPEPT)
            frmMain.DataLoad()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageUtils.ShowError("提交出错:\n" + ex.Message)
        End Try
    End Sub
#End Region

#Region "根据工号获取姓名"
    ''' <summary>
    ''' 根据工号获取姓名
    ''' </summary>
    ''' <param name="code">工号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getNameByCode(ByVal code As String) As String
        Dim name As String = ""
        Dim sql As String = "SELECT name FROM V_EMPLOYEEONJOB where code='" & code.trim.ToUpper & "'"
        Dim obj = DbOracleForSpcHelperSQL.GetSingle(sql)
        If Not obj Is Nothing Then
            name = obj.ToString()
        End If
        Return name
    End Function
#End Region

#Region "验证数据有效性"
    ''' <summary>
    ''' 验证数据有效性
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CheckIsValiate() As Boolean
        Dim number As Integer = 0
        Dim yy As Boolean = True
        If String.IsNullOrEmpty(TxtMoid.Text.Trim) Then
            MessageUtils.ShowWarning("请刷入工单编号")
            Return yy = False
        ElseIf String.IsNullOrEmpty(TxtLineleaderCode.Text.Trim) Then
            MessageUtils.ShowWarning("请刷入线长工号")
            Return yy = False
        ElseIf String.IsNullOrEmpty(TxtBiotechCode.Text.Trim) Then
            MessageUtils.ShowWarning("请刷入生技工号")
            Return yy = False
        ElseIf String.IsNullOrEmpty(TxtIPQCCode.Text.Trim) Then
            MessageUtils.ShowWarning("请刷入IPQC工号")
            Return yy = False
        ElseIf Integer.TryParse(TxtStationTotal.Text.Trim, number) = False Then
            MessageUtils.ShowWarning("工站总数必须是数字类型")
            Return yy = False
        ElseIf Integer.Parse(TxtStationTotal.Text.Trim) <= 0 Then
            MessageUtils.ShowWarning("工站总数必须大于0")
            Return yy = False
        ElseIf DbOperateUtils.GetDataTable("select * from dbo.m_EMCPEPT_t where MOID='" & TxtMoid.Text.Trim() & "' and ProductDate='" & dtProductDate.Text & "' and usey='Y' ").Rows.Count > 0 Then
            MessageUtils.ShowError("已经存在一笔工单:" & TxtMoid.Text.Trim() & ",生产日期:" & dtProductDate.Text & "的数据,提交失败")
            Return yy = False
        ElseIf String.IsNullOrEmpty(txtWorkersNum.Text.Trim()) Then
            MessageUtils.ShowError("请输入作业人数")
            Return yy = False
        ElseIf Integer.TryParse(txtWorkersNum.Text.Trim(), number) = False Then
            MessageUtils.ShowError("作业人数必须是整数")
            Return yy = False
        ElseIf Integer.Parse(txtWorkersNum.Text.Trim()) < 0 Then
            MessageUtils.ShowError("作业人数必须大于0")
            Return yy = False
        End If
        Return yy
    End Function
#End Region


    Private Sub TxtLineleaderCode_MouseLeave(sender As Object, e As EventArgs)

    End Sub

    Private Sub TxtLineleaderCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtLineleaderCode.KeyPress
        If e.KeyChar = Chr(13) Then
            TxtBiotechCode.Focus()
        End If
    End Sub

    Private Sub TxtBiotechCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBiotechCode.KeyPress
        If e.KeyChar = Chr(13) Then
            TxtIPQCCode.Focus()
        End If
    End Sub

    Private Sub TxtIPQCCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtIPQCCode.KeyPress
        If e.KeyChar = Chr(13) Then
            TxtStationTotal.Focus()
        End If
    End Sub
End Class