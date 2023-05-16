Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Text

Public Class FrmMouldRepair

    Public RepairMouldID As String   '送修模号
    Private UserId As String = VbCommClass.VbCommClass.UseId '当前用户工号

#Region "初始化"
    Private Sub FrmMouldRepair_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMouldID.Text = RepairMouldID
        txtMouldID_TextChanged(Nothing, Nothing)
        LoadData()
    End Sub
#End Region

#Region "事件"
    '开始维修
    Private Sub toolBeginRepair_Click(sender As Object, e As EventArgs) Handles toolBeginRepair.Click
        Dim strBSQL As New StringBuilder
        Dim strSQL As String

        Try
            If Not InputCheck(0) Then Exit Sub

            strSQL = "INSERT INTO m_MouldRepair_t (MouldID,RepartInfo,RepairDeptUnit,RepairDate,RepairUserId ,RepairResult, " &
                     " Remark ,UserID,Intime) VALUES('{0}',N'{1}',N'{2}','{3}','{4}','{5}',N'{6}','{7}',getdate()) "
            strBSQL.AppendFormat(strSQL, txtMouldID.Text.Trim, txtRepartInfo.Text.Trim, txtRepairDeptUnit.Text.Trim, dtRepairDate.Value.ToString("yyyy/MM/dd HH:mm:ss"),
                                 txtRepairUserId.Text.Trim, "", txtRemark.Text.Trim, UserId)
            strBSQL.AppendFormat(" update  m_Mould_t set UseStatus=2  where MouldID ='{0}'", txtMouldID.Text.Trim)

            DbOperateUtils.ExecSQL(strBSQL.ToString)
            MessageUtils.ShowInformation("模号[" & txtMouldID.Text.Trim & "]已开始维修!")
            LoadData()

            txtUseStatus.Text = "2-维修中"
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldRepair", "toolBeginRepair_Click", "sys")
        End Try
    End Sub

    '维修结束
    Private Sub toolEndRepair_Click(sender As Object, e As EventArgs) Handles toolEndRepair.Click
        If dgvMouldRepair.Rows.Count <= 0 OrElse dgvMouldRepair.CurrentRow Is Nothing Then Exit Sub

        Dim strBSQL As New StringBuilder
        Dim strSQL As String

        Try
            If Not InputCheck(1) Then Exit Sub

            strSQL = "UPDATE m_MouldRepair_t SET RepairResult='{0}',Remark=N'{1}',UserID ='{2}',Intime =getdate() WHERE MouldID = '{3}' and RepairResult=''"
            strBSQL.AppendFormat(strSQL, cboRepairResult.SelectedItem.ToString, txtRemark.Text.Trim, UserId, txtMouldID.Text.Trim)

            'mark by cq 20190507
            ' strBSQL.AppendFormat("update  m_Mould_t set UseStatus=0 where MouldID ='{0}'", txtMouldID.Text.Trim)  'UseStatus=0 
            '维修OK
            If cboRepairResult.SelectedItem.ToString.ToUpper = "OK" Then
                strBSQL.AppendLine(" DECLARE @ProcessedStatus VARCHAR(10),@CurrStatus VARCHAR(10)")
                strBSQL.AppendLine(" SELECT TOP 1  @CurrStatus = Status  FROM m_MouldInOutRecord_t WHERE MouldID='" & txtMouldID.Text.Trim & "' ORDER BY ID DESC")
                strBSQL.AppendLine("IF @CurrStatus =0 ")
                strBSQL.AppendLine(" BEGIN ")
                strBSQL.AppendLine("  SET @ProcessedStatus= 1")
                strBSQL.AppendLine(" End")
                strBSQL.AppendLine(" ELSE IF @CurrStatus =1 ")
                strBSQL.AppendLine("BEGIN ")
                strBSQL.AppendLine(" SET @ProcessedStatus= 0")
                strBSQL.AppendLine(" End")
                strBSQL.AppendLine(" update  m_Mould_t set UseStatus=@ProcessedStatus where MouldID ='" & txtMouldID.Text.Trim & "'")
            End If

            DbOperateUtils.ExecSQL(strBSQL.ToString)
            MessageUtils.ShowInformation("模号[" & txtMouldID.Text.Trim & "]已维修完毕!")
            LoadData()

            ' txtUseStatus.Text = "0-闲置中"
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldRepair", "toolEndRepair_Click", "sys")
        End Try
    End Sub

    '模号文本框改变事件
    Private Sub txtMouldID_TextChanged(sender As Object, e As EventArgs) Handles txtMouldID.TextChanged
        Dim mould As String = txtMouldID.Text.Trim
        If String.IsNullOrEmpty(mould) Then Exit Sub

        Try
            Dim strSQL As String = "SELECT [MouldID],[ParaDesc],[MapID],[NewMouldID] ,[Type] ,[Cavitys] ,[Strips] ,[Tails] ,[Slots] ,[Parts] ,[Location] ,[AssetsID] ," &
                              " [Storage], [LimitTimes], [AlertTimes], [UsedTimes]," &
                              " case UseStatus when 0 then N'0-闲置中' when 1 then N'1-使用中' when 2 then N'2-维修中' end [UseStatus] FROM [dbo].[m_Mould_t] where MouldID='" & mould & "'"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                txtParaDesc.Text = dt.Rows(0)("ParaDesc").ToString
                txtApplyPart.Text = dt.Rows(0)("Parts").ToString
                txtAssetsID.Text = dt.Rows(0)("AssetsID").ToString
                txtCavitys.Text = dt.Rows(0)("Cavitys").ToString
                txtLocation.Text = dt.Rows(0)("Location").ToString
                txtMapID.Text = dt.Rows(0)("MapID").ToString
                txtNewMouldID.Text = dt.Rows(0)("NewMouldID").ToString
                txtSlots.Text = dt.Rows(0)("Slots").ToString
                txtStrips.Text = dt.Rows(0)("Strips").ToString
                txtTails.Text = dt.Rows(0)("Tails").ToString
                txtType.Text = dt.Rows(0)("Type").ToString
                txtStorage.Text = dt.Rows(0)("Storage").ToString
                txtUseStatus.Text = dt.Rows(0)("UseStatus").ToString
                LoadData()
            Else
                txtParaDesc.Text = ""
                txtApplyPart.Text = ""
                txtAssetsID.Text = ""
                txtCavitys.Text = ""
                txtLocation.Text = ""
                txtMapID.Text = ""
                txtNewMouldID.Text = ""
                txtSlots.Text = ""
                txtStrips.Text = ""
                txtTails.Text = ""
                txtType.Text = ""
                txtStorage.Text = ""
                txtUseStatus.Text = ""

                txtRepartInfo.Text = ""
                txtRepairDeptUnit.Text = ""
                txtRepairUserId.Text = ""
                txtRepartInfo.ReadOnly = False
                txtRepairDeptUnit.ReadOnly = False
                txtRepairUserId.ReadOnly = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
#End Region

#Region "方法"
    '加载数据
    Private Sub LoadData()
        Try
            Dim strSQL As String = "SELECT ID,MouldID,RepartInfo,RepairDeptUnit,RepairDate,RepairUserId+'/'+u.UserName RepairUserId,RepairResult,Remark " &
                              " FROM m_MouldRepair_t m left join m_Users_t u on m.RepairUserId=u.UserID where MouldID='{0}' "
            strSQL = String.Format(strSQL, txtMouldID.Text.Trim)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL & " order by ID desc")
            dgvMouldRepair.DataSource = dt

            Dim dt2 As DataTable = DbOperateUtils.GetDataTable(strSQL & " and RepairResult ='' ")  '显示处于维修中的数据
            If dt2.Rows.Count > 0 Then
                'txtID.Text = dt.Rows(0)(0).ToString
                txtRepartInfo.Text = dt.Rows(0)(2).ToString
                txtRepairDeptUnit.Text = dt.Rows(0)(3).ToString
                dtRepairDate.Value = dt.Rows(0)(4).ToString
                txtRepairUserId.Text = dt.Rows(0)(5).ToString.Split("/")(0)
                txtRepartInfo.ReadOnly = True
                txtRepairDeptUnit.ReadOnly = True
                txtRepairUserId.ReadOnly = True
            Else
                txtRepartInfo.Text = ""
                txtRepairDeptUnit.Text = ""
                txtRepairUserId.Text = ""
                cboRepairResult.SelectedIndex = 0
                txtRepartInfo.ReadOnly = False
                txtRepairDeptUnit.ReadOnly = False
                txtRepairUserId.ReadOnly = False
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldRepair", "LoadData", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 维修时 判断
    ''' </summary>
    ''' <param name="type">0 开始维修 1维修结束</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InputCheck(ByVal type As Integer) As Boolean
        Dim strSQL As String
        Dim dt As DataTable
        strSQL = String.Format("select UseStatus from m_Mould_t where MouldID ='{0}'", txtMouldID.Text.Trim)
        dt = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count = 0 Then
            MessageUtils.ShowInformation("模号不存在!")
            Return False
        End If

        If type = 0 Then
            'mark by cq20190424
            'If dt.Rows(0)(0).ToString <> "0" Then
            '    MessageUtils.ShowInformation("闲置中的模具才可以维修!")
            '    Return False
            'End If

            If String.IsNullOrEmpty(txtRepairDeptUnit.Text.Trim) Then
                MessageUtils.ShowInformation("送修单位不能为空!")
                txtRepairDeptUnit.Focus()
                Return False
            End If

            If String.IsNullOrEmpty(txtRepairUserId.Text.Trim) Then
                MessageUtils.ShowInformation("送修人不能为空!")
                txtRepairUserId.Focus()
                Return False
            Else
                '由于外厂人员没有工号，不需要检查。 20190410
                'dt = DbOperateUtils.GetDataTable(String.Format("select * from m_Users_t where UserID ='{0}'", txtRepairUserId.Text.Trim))
                'If dt.Rows.Count <= 0 Then
                '    MessageUtils.ShowInformation("送修人工号不存在")
                '    Return False
                'End If
            End If

            If String.IsNullOrEmpty(txtRepartInfo.Text.Trim) Then
                MessageUtils.ShowInformation("送修不良状况不能为空!")
                txtRepartInfo.Focus()
                Return False
            End If

        ElseIf type = 1 Then
            If dt.Rows(0)(0).ToString <> "2" Then
                MessageUtils.ShowInformation("维修中的模具才可以结束维修!")
                Return False
            End If

            If String.IsNullOrEmpty(cboRepairResult.Text.Trim) Then
                MessageUtils.ShowInformation("维修结果不能为空!")
                Return False
            End If
        End If

        Return True
    End Function
#End Region
End Class