Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Text
Imports SysBasicClass
Imports DBUtility

Public Class FrmMouldIn

    Public MouldID As String
    Private UserId As String = VbCommClass.VbCommClass.UseId

#Region "初始化"
    Private Sub FrmMouldIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMouldID.Text = MouldID
        txtMouldID_TextChanged(Nothing, Nothing)
        LoadData()
    End Sub
#End Region

#Region "事件"
    '模号文本框改变事件
    Private Sub txtMouldID_TextChanged(sender As Object, e As EventArgs) Handles txtMouldID.TextChanged
        If String.IsNullOrEmpty(txtMouldID.Text.Trim) Then Exit Sub
        SetControlValue()
    End Sub

    '归还
    Private Sub toolMouldIn_Click(sender As Object, e As EventArgs) Handles toolMouldIn.Click

        '  If String.IsNullOrEmpty(txtBackUserId.Text.Trim) Then Exit Sub  'Mark by cq 20190409, 允许外厂人员借用。
        Dim strBSQL As New StringBuilder
        Dim strSQL As String
        Dim state As String
        Try
            If CheckInput() = False Then

                Return
            End If
            If CheckBox1.Checked = True Then
                state = "Y"
            Else
                state = "N"
            End If
            strSQL = "UPDATE m_MouldInOutRecord_t set BackDate=getdate(),BackUserId='{1}',Acceptor='{2}',InRemark=N'{3}', Status=1,OutLineID=N'模具室', UserID='{4}' ," &
                    " Intime=getdate(),BackUserName=N'{0}' where MouldID='{5}' and Status=0 "
            strBSQL.AppendFormat(strSQL, txtBackUserName.Text.Trim, txtBackUserId.Text.Trim, UserId, txtRemark.Text.Trim, UserId, txtMouldID.Text.Trim)
            strBSQL.AppendFormat(" UPDATE  m_Mould_t set UseStatus=0, Location=N'模具室',state = '" + state + "' where MouldID ='{0}'", txtMouldID.Text.Trim)
            DbOperateUtils.ExecSQL(strBSQL.ToString)
            MessageUtils.ShowInformation("模号[" & txtMouldID.Text.Trim & "]已归还!")
            LoadData()

            txtUseStatus.Text = "0-闲置中"
            txtBackUserName.Clear()
            txtBackUserId.Clear()
            txtRemark.Clear()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldIn", "toolMouldIn_Click", "sys")
        End Try
    End Sub

    '文本框改变事件
    Private Sub txtBackUserId_TextChanged(sender As Object, e As EventArgs) Handles txtBackUserId.TextChanged
        If String.IsNullOrEmpty(txtBackUserId.Text.Trim) Then
            txtBackUserName.Clear()
            Return
        End If

        Try
            Dim strSQL As String = "SELECT e.Code,e.Name Name,d.Name DeptName FROM V_EMPLOYEEONJOB e " &
                                " inner join S2_Department d on e.DeptCode=d.Code where e.Code='" & txtBackUserId.Text.Trim & "'"
            Dim ds As DataSet = New DataSet
            ds = DbOracleForSpcHelperSQL.Query(strSQL)
            If ds.Tables(0).Rows.Count > 0 Then
                txtBackUserName.Text = ds.Tables(0).Rows(0)("Name").ToString
            Else
                txtBackUserName.Text = ""
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldIn", "txtBackUserId_TextChanged", "sys")
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
            Dim strSQL As String = "SELECT ID,MouldID,OutDate,OutDeptUnit,OutToUserId+'/'+OutToUserName OutToUserId,OutFromUserId  +'/'+u2.UserName OutFromUserId," &
                              " BackDate,BackUserId  +'/'+BackUserName BackUserId,Acceptor +'/'+u4.UserName Acceptor, " &
                              " case Status when 0 then N'0-已调出' when 1 then N'1-已归还' end Status,OutRemark,InRemark FROM m_MouldInOutRecord_t m " &
                              " left join m_Users_t u2 on m.OutFromUserId=u2.UserID " &
                              " left join m_Users_t u4 on m.Acceptor=u4.UserID where  MouldID ='{0}' order by ID desc "

            strSQL = String.Format(strSQL, txtMouldID.Text.Trim)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            dgvMouldInOut.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    '入库前检查
    Private Function CheckInput() As Boolean
        Dim strSQL As String = String.Format("select UseStatus from m_Mould_t where MouldID ='{0}'", txtMouldID.Text.Trim)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count = 0 Then
            MessageUtils.ShowInformation("模具不存在!")
        ElseIf dt.Rows(0)(0).ToString <> "1" Then
            MessageUtils.ShowInformation("借出的模具才可以归还!")
            Return False
        End If

        If String.IsNullOrEmpty(txtBackUserName.Text.Trim) Then
            MessageUtils.ShowInformation("归还人工号不存在或已离职!")
            Return False
        End If
        Return True
    End Function

    '设置面板控件值
    Private Sub SetControlValue()
        Try
            Dim strSQL As String = "SELECT [MouldID],[ParaDesc],[MapID],[NewMouldID] ,[Type] ,[Cavitys] ,[Strips] ,[Tails] ,[Slots] ,[Parts] ,[Location] ,[state]," &
                            " [AssetsID] ,[Storage], [LimitTimes], [AlertTimes], [UsedTimes], case UseStatus when 0 then N'0-闲置中' when 1 then N'1-使用中' " &
                            " when 2 then N'2-维修中' end[UseStatus] FROM [dbo].[m_Mould_t] where MouldID='" & txtMouldID.Text & "'"
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
                If dt.Rows(0)("state").ToString = "Y" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If
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
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
End Class