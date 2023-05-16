'--工单状态设置
'--Create by :　马锋
'--Create date :　2017/01/13
'--Update date :  
'--Ver : V01

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports MainFrame

#End Region

Public Class FrmMOStatusSetting

#Region "变量声明"

    Dim _strLineId As String
    Dim _strMOId As String
#End Region

#Region "构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Public Sub New(ByVal strMOId As String, ByVal strLineId As String)
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        _strLineId = strLineId
        _strMOId = strMOId
    End Sub
#End Region

#Region "窗体事件"

    Private Sub FrmMOStatusSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False
            Me.dgvInspectionQuery.AutoGenerateColumns = False
            Me.txtMOId.Text = _strMOId
            Me.txtLineId.Text = _strLineId

            GetMO()
            GetMOInspection()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolStart_Click(sender As Object, e As EventArgs) Handles ToolStart.Click
        Try

            If (Not CheckStart()) Then
                Exit Sub
            End If

            DbOperateUtils.ExecSQL("UPDATE m_Mainmo_t SET StartUserId= '" & VbCommClass.VbCommClass.UseId & "', StartTime=GETDATE() WHERE Moid='" & Me.txtMOId.Text.Trim & "' ")

            GetMO()
            GetMesData.SetMessage(Me.lblMessage, "生产开始完成", True)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "生产开始异常", False)
        End Try
    End Sub

    Private Sub ToolEnd_Click(sender As Object, e As EventArgs) Handles ToolEnd.Click
        Try
            If (Not CheckEnd()) Then
                Exit Sub
            End If

            DbOperateUtils.ExecSQL("UPDATE m_Mainmo_t SET EndUserId= '" & VbCommClass.VbCommClass.UseId & "', EndTime=GETDATE() WHERE Moid='" & Me.txtMOId.Text.Trim & "' ")

            GetMO()
            GetMesData.SetMessage(Me.lblMessage, "生产结束完成", True)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "生产结束异常", False)
        End Try
    End Sub

    Private Sub ToolSuspend_Click(sender As Object, e As EventArgs) Handles ToolSuspend.Click
        Try
            If (Not CheckSuspend()) Then
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            strSQL.AppendLine(" INSERT INTO m_MoTracking_t(MoId, ExecType, TrackStartUserId, TrackStartTime, TrackEndUserId, TrackEndTime, StatusFlag) VALUES( ")
            strSQL.AppendLine(" '" & Me.txtMOId.Text.Trim & "', '0', '" & VbCommClass.VbCommClass.UseId & "', getDate(), NULL, NULL, 0) ")
            DbOperateUtils.ExecSQL(strSQL.ToString)

            GetMO()
            GetMesData.SetMessage(Me.lblMessage, "生产暂停完成", True)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "生产暂停异常", False)
        End Try
    End Sub

    Private Sub ToolRestore_Click(sender As Object, e As EventArgs) Handles ToolRestore.Click
        Try
            If (Not CheckRestore()) Then
                Exit Sub
            End If

            DbOperateUtils.ExecSQL("UPDATE m_MoTracking_t SET TrackEndUserId= '" & VbCommClass.VbCommClass.UseId & "', TrackEndTime=GETDATE(), StatusFlag='1' WHERE Moid='" & Me.txtMOId.Text.Trim & "' AND StatusFlag = '0' ")

            GetMO()
            GetMesData.SetMessage(Me.lblMessage, "生产恢复完成", True)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "恢复异常", False)
        End Try
    End Sub

    Private Sub ToolCommodityinspection_Click(sender As Object, e As EventArgs) Handles ToolCommodityinspection.Click
        Try
            If (Not CheckCommodityinspection()) Then
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            strSQL.AppendLine(" INSERT INTO m_MOInspection_t(MOID, LineId, InspectionQuantity, InspectionStatusFlag, InspectionUserId, InspectionTime) VALUES( ")
            strSQL.AppendLine(" '" & Me.txtMOId.Text.Trim & "', '" & Me.txtLineId.Text.Trim & "', '" & Me.txtInspectionQuantity.Text.Trim & "', '0', '" & VbCommClass.VbCommClass.UseId & "', GETDATE()) ")
            strSQL.AppendLine(" UPDATE m_Mainmo_t SET InspectionQuantity = InspectionQuantity + '" & Me.txtInspectionQuantity.Text.Trim & "' WHERE MOID = '" & Me.txtMOId.Text.Trim & "' ")

            DbOperateUtils.ExecSQL(strSQL.ToString)

            Me.txtInspectionQuantity.Text = ""
            GetMOInspection()
            GetMesData.SetMessage(Me.lblMessage, "送检完成", True)

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "送检异常", False)
        End Try
    End Sub

    Private Sub toolCard_Click(sender As Object, e As EventArgs) Handles toolCard.Click
        Try
            Dim frmEmployeeCard As New FrmEmployeeCard(Me.txtMOId.Text.Trim, Me.txtLineId.Text.Trim)
            frmEmployeeCard.ShowDialog()

            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(" SELECT MOID FROM m_Mainmo_t WHERE MOID='" & Me.txtMOId.Text.Trim & "' AND StartUserId IS NOT NULL ")

            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                Me.Close()
            End If

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "打卡异常", False)
        End Try
    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Try
            GetMO()
            GetMOInspection()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Try
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "关闭异常", False)
        End Try
    End Sub

#End Region

#Region "方法"

    Private Sub GetMO()
        Try
            Dim strQuerySQL As New StringBuilder
            strQuerySQL.AppendLine(" SELECT   m_Mainmo_t.Moid, m_Mainmo_t.PartID, m_Mainmo_t.MOQty, m_Mainmo_t.StartUserId, m_Mainmo_t.StartTime, m_Mainmo_t.EndUserId, m_Mainmo_t.EndTime, m_Mainmo_t.InspectionQuantity, ")
            strQuerySQL.AppendLine(" m_MoTracking_t.TrackStartUserId, m_MoTracking_t.TrackStartTime, m_MoTracking_t.TrackEndUserId, m_MoTracking_t.TrackEndTime, m_MoTracking_t.StatusFlag ")
            strQuerySQL.AppendLine(" FROM m_Mainmo_t LEFT JOIN m_MoTracking_t ON m_Mainmo_t.Moid = m_MoTracking_t.MoId WHERE m_Mainmo_t.Moid='" & Me.txtMOId.Text.Trim & "' ")

            Me.dgvQuery.DataSource = DbOperateUtils.GetDataTable(strQuerySQL.ToString)

            If (Me.dgvQuery.RowCount > 0) Then
                Me.txtMOQuantity.Text = Me.dgvQuery.Rows(0).Cells("MOQty").Value

                Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("DECLARE @RTVALUE VARCHAR(1), @RTMSG NVARCHAR(256), @OUTSCANQUANTITY VARCHAR(32) EXEC Exec_MOProduceItem @RTVALUE OUTPUT, @RTMSG OUTPUT, @OUTSCANQUANTITY OUTPUT, '" & VbCommClass.VbCommClass.Factory & "', '" & VbCommClass.VbCommClass.profitcenter & "', 'TEST', '" & Me.txtMOId.Text.Trim & "' SELECT @RTVALUE, @RTMSG, ISNULL(@OUTSCANQUANTITY, 0) ")

                If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then

                    If (dtTemp.Rows(0).Item(0) = "1") Then
                        Me.txtMOAlreadyQty.Text = dtTemp.Rows(0).Item(2)
                        Me.txtNotAlreadyQty.Text = CDbl(Me.txtMOQuantity.Text) - CDbl(dtTemp.Rows(0).Item(2))
                    Else
                        Me.txtMOAlreadyQty.Text = ""
                        Me.txtNotAlreadyQty.Text = ""
                    End If
                Else
                    Me.txtMOAlreadyQty.Text = ""
                    Me.txtNotAlreadyQty.Text = ""
                End If
            End If

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "获取工单状态记录异常", False)
        End Try
    End Sub

    Private Sub GetMOInspection()
        Try
            Dim strQuerySQL As New StringBuilder
            strQuerySQL.AppendLine(" SELECT   m_Mainmo_t.Moid, m_Mainmo_t.PartID, m_Mainmo_t.InspectionQuantity AS MOInspectionQuantity, (m_Mainmo_t.Moqty - m_Mainmo_t.InspectionQuantity) AS MONotInspectionQuantity, ")
            strQuerySQL.AppendLine(" m_MOInspection_t.LineId, m_MOInspection_t.InspectionQuantity, m_MOInspection_t.InspectionStatusFlag, m_MOInspection_t.InspectionUserId, m_MOInspection_t.InspectionTime ")
            strQuerySQL.AppendLine(" FROM m_Mainmo_t INNER JOIN  m_MOInspection_t ON m_Mainmo_t.Moid = m_MOInspection_t.MOID WHERE m_Mainmo_t.Moid = '" & Me.txtMOId.Text.Trim & "' ")

            Me.dgvInspectionQuery.DataSource = DbOperateUtils.GetDataTable(strQuerySQL.ToString)

            If (Me.dgvInspectionQuery.RowCount > 0) Then
                Me.txtAlreadyInspectionQty.Text = Me.dgvInspectionQuery.Rows(0).Cells("MOInspectionQuantity").Value
                Me.txtNotInspectionQty.Text = Me.dgvInspectionQuery.Rows(0).Cells("MONotInspectionQuantity").Value
            Else
                Me.txtAlreadyInspectionQty.Text = 0
                Me.txtNotInspectionQty.Text = Me.txtMOQuantity.Text
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "获取工单送检记录异常", False)
        End Try
    End Sub

    Private Function CheckStart() As Boolean
        Try
            If String.IsNullOrEmpty(Me.txtMOId.Text.Trim) Then
                GetMesData.SetMessage(Me.lblMessage, "工单不能为空", False)
                Return False
            End If

            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT MOID FROM m_Mainmo_t WHERE MOID='" & Me.txtMOId.Text.Trim & "' AND ISNULL(StartUserId, '') = ''")

            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then

                '增加打卡检查
                Dim dtCardTemp As DataTable = DbOperateUtils.GetDataTable("SELECT TOP 1 EmployeeCode FROM m_LineCard_t WHERE CardFlag = '1' AND LineId='" & Me.txtLineId.Text.Trim & "' AND Moid='" & Me.txtMOId.Text.Trim & "' AND CardDay = CONVERT(VARCHAR(10), GETDATE(), 120)")

                If (Not dtCardTemp Is Nothing And dtCardTemp.Rows.Count > 0) Then
                    Return True
                Else
                    GetMesData.SetMessage(Me.lblMessage, "生产开始失败，当前产线未打卡", True)
                    Return False
                End If
            Else
                GetMesData.SetMessage(Me.lblMessage, "工单已经生产开始", False)
                Return False
            End If

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查工单状态异常", False)
            Return False
        End Try
    End Function

    Private Function CheckEnd() As Boolean
        Try
            If String.IsNullOrEmpty(Me.txtMOId.Text.Trim) Then
                GetMesData.SetMessage(Me.lblMessage, "工单不能为空", False)
                Return False
            End If

            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT ISNULL(StartUserId, ''), ISNULL(EndUserId, '') FROM m_Mainmo_t WHERE MOID='" & Me.txtMOId.Text.Trim & "' ")

            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                If (String.IsNullOrEmpty(dtTemp.Rows(0)(0).ToString.Trim())) Then
                    GetMesData.SetMessage(Me.lblMessage, "工单完成失败，工单未开始", False)
                    Return False
                End If

                If (Not String.IsNullOrEmpty(dtTemp.Rows(0)(1).ToString.Trim())) Then
                    GetMesData.SetMessage(Me.lblMessage, "工单完成失败，工单已经完成", False)
                    Return False
                End If

                '增加暂停判断
                Dim dtTrackingTemp As DataTable = DbOperateUtils.GetDataTable("SELECT StatusFlag FROM m_MoTracking_t WHERE Moid = '" & Me.txtMOId.Text.Trim & "' AND StatusFlag = '0' ")

                If (Not dtTrackingTemp Is Nothing And dtTrackingTemp.Rows.Count > 0) Then
                    GetMesData.SetMessage(Me.lblMessage, "工单完成失败，工单被暂停", False)
                    Return False
                Else
                    Return True
                End If
            Else
                GetMesData.SetMessage(Me.lblMessage, "工单已经生产结束或未开始", False)
                Return False
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "工单完成检查异常", False)
            Return False
        End Try
    End Function

    Private Function CheckSuspend() As Boolean
        Try
            If String.IsNullOrEmpty(Me.txtMOId.Text.Trim) Then
                GetMesData.SetMessage(Me.lblMessage, "工单不能为空", False)
                Return False
            End If

            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT ISNULL(StartUserId, ''), ISNULL(EndUserId, '') FROM m_Mainmo_t WHERE MOID='" & Me.txtMOId.Text.Trim & "' ")

            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                If (String.IsNullOrEmpty(dtTemp.Rows(0)(0).ToString.Trim())) Then
                    GetMesData.SetMessage(Me.lblMessage, "工单暂停失败，工单未开始", False)
                    Return False
                End If

                If (Not String.IsNullOrEmpty(dtTemp.Rows(0)(1).ToString.Trim())) Then
                    GetMesData.SetMessage(Me.lblMessage, "工单暂停失败，工单已经完成", False)
                    Return False
                End If

                Return True
            Else
                GetMesData.SetMessage(Me.lblMessage, "暂停失败，工单不存在", False)
                Return False
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "工单暂停异常", False)
            Return False
        End Try
    End Function

    Private Function CheckRestore() As Boolean
        Try
            If String.IsNullOrEmpty(Me.txtMOId.Text.Trim) Then
                GetMesData.SetMessage(Me.lblMessage, "工单不能为空", False)
                Return False
            End If

            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT StatusFlag FROM m_MoTracking_t WHERE Moid = '" & Me.txtMOId.Text.Trim & "' AND StatusFlag = '0' ")

            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                Return True
            Else
                GetMesData.SetMessage(Me.lblMessage, "恢复失败，工单未暂停", False)
                Return False
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "工单恢复检查异常", False)
            Return False
        End Try
    End Function

    Private Function CheckCommodityinspection() As Boolean
        Try
            If String.IsNullOrEmpty(Me.txtMOId.Text.Trim) Then
                GetMesData.SetMessage(Me.lblMessage, "工单不能为空", False)
                Return False
            End If

            If Not IsNumeric(Me.txtInspectionQuantity.Text.Trim) Then
                GetMesData.SetMessage(Me.lblMessage, "输入送检数量非数字", False)
                Return False
            Else
                If (CDbl(Me.txtInspectionQuantity.Text.Trim) <= 0) Then
                    GetMesData.SetMessage(Me.lblMessage, "输入送检数量不能小于0", False)
                    Return False
                End If
            End If

            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT Moid FROM m_Mainmo_t WHERE Moid = '" & Me.txtMOId.Text.Trim & "' AND Moqty - InspectionQuantity - " & Me.txtInspectionQuantity.Text.Trim & " >= 0 ")

            If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then

                '完工数量检查
                If (CDbl(Me.txtMOAlreadyQty.Text.Trim) < CDbl(Me.txtInspectionQuantity.Text.Trim) + CDbl(Me.txtAlreadyInspectionQty.Text.Trim)) Then
                    GetMesData.SetMessage(Me.lblMessage, "送检失败，送检数量不能大于工单完工数量", False)
                    Return False
                Else
                    Return True
                End If
            Else
                GetMesData.SetMessage(Me.lblMessage, "送检失败，送检数量不能大于工单数量", False)
                Return False
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "工单送检检查异常", False)
            Return False
        End Try
    End Function

#End Region

End Class