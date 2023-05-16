
'--SN号段查询
'--Create by :　马锋
'--Create date :　2016/12/19
'--Ver : V01
'--Update date :  
'--
'--------------修改记录---------------------------
'hgd    2017-04-20      分段区间不限制厂区     
'hgd    2017-05-08      处理修改时BUG   
#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
#End Region

Public Class FrmSNDistributionQuery

#Region "变量声明"
    Dim LoadM As New BarCodePrint.SqlClassM
    Dim _strPartId As String
    Dim _strCodeRuleId As String
    Dim ExecValue As String
    Dim S_SnEdit As String
    Dim E_SnEdit As String
    Dim SnDistributionDT As DataTable
    Dim M_SnDistributionID As String


#End Region

#Region "构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal strPartId As String, ByVal strCodeRuleId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _strPartId = strPartId
        _strCodeRuleId = strCodeRuleId
    End Sub
#End Region

#Region "加载事件"

    Private Sub FrmSNDistributionQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.txtPartId.Text = _strPartId
            Me.txtCodeRuleId.Text = _strCodeRuleId
            SetStatus(0)
            LoadContralData()
        Catch ex As Exception
            MessageBox.Show("加载号段失败！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        Me.M_SnDistributionID = String.Empty
        ExecValue = "0"
        SetStatus(1)
    End Sub

    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        Try
            Dim FactoryID As String

            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then Exit Sub
            FactoryID = Me.dgvQuery.Item("FactoryID", Me.dgvQuery.CurrentRow.Index).Value
            If FactoryID <> VbCommClass.VbCommClass.Factory Then
                MsgBox("无法对其它厂区的号段进行修改操作！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")

                Exit Sub
            End If

            ExecValue = "1"
            SetStatus(1)
            Me.txtStartSN.Text = IIf(IsDBNull(Me.dgvQuery.Item("MinSN", Me.dgvQuery.CurrentRow.Index).Value), "", Me.dgvQuery.Item("MinSN", Me.dgvQuery.CurrentRow.Index).Value)
            Me.txtEndSN.Text = IIf(IsDBNull(Me.dgvQuery.Item("MaxSN", Me.dgvQuery.CurrentRow.Index).Value), "", Me.dgvQuery.Item("MaxSN", Me.dgvQuery.CurrentRow.Index).Value)
            Me.txtRemark.Text = IIf(IsDBNull(Me.dgvQuery.Item("Remark", Me.dgvQuery.CurrentRow.Index).Value), "", Me.dgvQuery.Item("Remark", Me.dgvQuery.CurrentRow.Index).Value)
            Me.M_SnDistributionID = Me.dgvQuery.Item("SNDistributionID", Me.dgvQuery.CurrentRow.Index).Value

  
        Catch ex As Exception
            MessageBox.Show("编辑异常!")
        End Try
    End Sub

    Private Sub ToolSave_Click(sender As Object, e As EventArgs) Handles ToolSave.Click
        Try
            '开始流失号
            Dim StartInt As Int64 = 0
            '结束流水号
            Dim EndInt As Int64 = 0

            If Me.txtStartSN.Text.Trim <> "" AndAlso Me.txtEndSN.Text.Trim <> "" Then
                StartInt = LoadM.CodeToInt(Me.txtStartSN.Text.Trim, Me.txtCodeRuleId.Text.Trim)
                EndInt = LoadM.CodeToInt(Me.txtEndSN.Text.Trim, Me.txtCodeRuleId.Text.Trim)
                If StartInt = -1 OrElse EndInt = -1 Then
                    MsgBox("起始流水號或終止流水號設置錯誤，請核對！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                    Me.ActiveControl = Me.txtStartSN
                    Exit Sub
                End If

                If StartInt > EndInt Then
                    MsgBox("起始流水號不能打印終止流水號設置，請核對！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
                    Me.ActiveControl = Me.txtStartSN
                    Exit Sub
                End If
                'add by hgd 2017-04-20 检验当前区间是否已存在
                If CheckSnExists(StartInt, EndInt) = False Then
                    Exit Sub
                End If


            End If
            Dim strSQL As New StringBuilder
            'strSQL.Append(ControlChars.CrLf & " IF EXISTS(SELECT 1 FROM m_SNDistribution_t WHERE FACTORYID='" & VbCommClass.VbCommClass.Factory & "' AND PARTID='" & Me.txtPartId.Text.Trim & "' AND CODERULEID='" & Me.txtCodeRuleId.Text.Trim & "' ) " _
            '       & " BEGIN UPDATE m_SNDistribution_t SET MinInt='" & StartInt & "', MinSN='" & Me.txtStartSN.Text.Trim & "', MaxInt='" & EndInt & "', MaxSN='" & Me.txtEndSN.Text.Trim & "', PrintInt = '" & StartInt & "', PrintSN = '" & Me.txtStartSN.Text.Trim & "' " _
            '       & " WHERE FACTORYID='" & VbCommClass.VbCommClass.Factory & "' AND PARTID='" & Me.txtPartId.Text.Trim & "' AND CODERULEID='" & Me.txtCodeRuleId.Text.Trim & "'  " _
            '       & " End Else BEGIN " _
            '       & " INSERT INTO m_SNDistribution_t(FactoryID, PartId, CodeRuleId, MinInt, MinSN, MaxInt, MaxSN, PrintInt, PrintSN, CreateUserId, CreateTime)VALUES(  " _
            '       & " '" & VbCommClass.VbCommClass.Factory & "', '" & Me.txtPartId.Text.Trim & "', '" & Me.txtCodeRuleId.Text.Trim & "', '" & StartInt & "', '" & Me.txtStartSN.Text.Trim & "', '" & EndInt & "', '" & Me.txtEndSN.Text.Trim & "', '" & StartInt & "', '" & Me.txtStartSN.Text.Trim & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE()) END ")


            If Me.ExecValue = "0" Then
                strSQL.Append(ControlChars.CrLf & " INSERT INTO m_SNDistribution_t(FactoryID, PartId, CodeRuleId, MinInt, MinSN, MaxInt, MaxSN, PrintInt, PrintSN, CreateUserId, CreateTime)VALUES(  " _
             & " '" & VbCommClass.VbCommClass.Factory & "', '" & Me.txtPartId.Text.Trim & "', '" & Me.txtCodeRuleId.Text.Trim & "', '" & StartInt & "', '" & Me.txtStartSN.Text.Trim & "', '" & EndInt & "', '" & Me.txtEndSN.Text.Trim & "', '" & StartInt & "', '" & Me.txtStartSN.Text.Trim & "', '" & VbCommClass.VbCommClass.UseId & "', GETDATE()) ")
            Else

                strSQL.Append(ControlChars.CrLf & " UPDATE m_SNDistribution_t SET MinInt='" & StartInt & "', MinSN='" & Me.txtStartSN.Text.Trim & "', MaxInt='" & EndInt & "', MaxSN='" & Me.txtEndSN.Text.Trim & "', PrintInt = '" & StartInt & "', PrintSN = '" & Me.txtStartSN.Text.Trim & "' " _
             & " WHERE FACTORYID='" & VbCommClass.VbCommClass.Factory & "' AND PARTID='" & Me.txtPartId.Text.Trim & "' AND CODERULEID='" & Me.txtCodeRuleId.Text.Trim & "' AND SNDistributionID='" & Me.M_SnDistributionID & "' ")
            End If
        
            DbOperateUtils.ExecSQL(strSQL.ToString)
            LoadContralData()
            SetStatus(0)


        Catch ex As Exception
            MessageBox.Show("保存异常!")
        End Try
    End Sub

    Private Sub ToolUnDo_Click(sender As Object, e As EventArgs) Handles ToolUnDo.Click
        SetStatus(0)
    End Sub

    Private Sub ToolFind_Click(sender As Object, e As EventArgs) Handles ToolFind.Click
        LoadContralData()
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    Private Sub ToolCancel_Click(sender As Object, e As EventArgs) Handles ToolCancel.Click
        Dim o_strSql As New StringBuilder
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then Exit Sub

            'If Me.dgvQuery.Rows.Count = 1 Then
            '    MessageBox.Show("必须要保留一笔号段记录,此笔无法作废!")
            '    Exit Sub
            'End If
            Me.M_SnDistributionID = Me.dgvQuery.Item("SNDistributionID", Me.dgvQuery.CurrentRow.Index).Value

            If (MessageUtils.ShowConfirm("确定要作废吗?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                o_strSql.Append("delete m_SNDistribution_t where SNDistributionID='" & Me.M_SnDistributionID & "';")
                o_strSql.Append("delete m_SnDistributionStyle_t where SNDistributionID='" & Me.M_SnDistributionID & "';")
                DbOperateUtils.ExecSQL(o_strSql.ToString)
                LoadContralData()
                MessageBox.Show("作废成功!", "提示信息")
            End If

            'Exit Sub
            'DbOperateUtils.ExecSQL(" DELETE m_SNDistribution_t WHERE FACTORYID='" & VbCommClass.VbCommClass.Factory & "' AND PARTID='" & Me.txtPartId.Text.Trim & "' AND CODERULEID='" & Me.txtCodeRuleId.Text.Trim & "' ")

        Catch ex As Exception
            MessageBox.Show("作废异常!")
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始
                ToolNew.Enabled = True
                ToolEdit.Enabled = True
                ToolCancel.Enabled = True
                ToolSave.Enabled = False
                ToolUnDo.Enabled = False
                ToolFind.Enabled = True
                ToolExitFrom.Enabled = True
                Me.dgvQuery.Enabled = True
                Me.txtStartSN.Text = ""
                Me.txtEndSN.Text = ""
                Me.txtRemark.Text = ""
            Case 1
                ToolNew.Enabled = False
                ToolEdit.Enabled = False
                ToolCancel.Enabled = True
                ToolSave.Enabled = True
                ToolUnDo.Enabled = True
                ToolFind.Enabled = False
                ToolExitFrom.Enabled = True
                Me.dgvQuery.Enabled = False

        End Select
    End Sub

    Private Sub LoadContralData()
        Try
            Dim strSQL As String = " SELECT   SNDistributionID, FactoryID, PartId, CodeRuleId, MinInt, MinSN, MaxInt, MaxSN, PrintInt, PrintSN, Remark, CreateUserId, " & _
                                " CreateTime FROM m_SNDistribution_t WHERE PartId='" & _strPartId & "' AND CodeRuleId = '" & _strCodeRuleId & "' "

            Me.SnDistributionDT = DbOperateUtils.GetDataTable(strSQL)
            Me.dgvQuery.DataSource = SnDistributionDT

        Catch ex As Exception
            Me.ActiveControl = Me.txtStartSN
            MessageBox.Show("加载号段失败！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    ''' <summary>
    ''' 检查号段是否重复
    ''' </summary>
    ''' <param name="SInt">开始流水号</param>
    ''' <param name="EInt">结束流水号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckSnExists(ByVal SInt As Int64, ByVal EInt As Int64) As Boolean
        Try
            Dim tempSInt As Int64 = 0
            Dim tempEInt As Int64 = 0
      
            Dim _ID As String
            If Not Me.SnDistributionDT Is Nothing AndAlso Me.SnDistributionDT.Rows.Count > 0 Then
                For Each dr As DataRow In Me.SnDistributionDT.Rows
                    tempSInt = Convert.ToInt64(dr!MinInt.ToString())
                    tempEInt = Convert.ToInt64(dr!MaxInt.ToString())
   
                    _ID = dr!SNDistributionID.ToString()
                    If Me.ExecValue = "1" AndAlso _ID = Me.M_SnDistributionID AndAlso Not String.IsNullOrEmpty(Me.M_SnDistributionID) Then
                        Continue For
                    End If
                    If SInt > tempSInt AndAlso SInt <= tempEInt Then
                        Me.ActiveControl = Me.txtStartSN
                        MessageBox.Show("号段开始流水码存在冲突,请检查！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                    If EInt >= tempSInt AndAlso EInt <= tempEInt Then
                        Me.ActiveControl = Me.txtEndSN
                        MessageBox.Show("号段结束流水码存在冲突,请检查！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                Next
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show("号段设置异常！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Function



#End Region


End Class