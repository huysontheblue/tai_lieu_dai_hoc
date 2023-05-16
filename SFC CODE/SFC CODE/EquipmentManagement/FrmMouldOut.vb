Imports MainFrame
Imports SysBasicClass
Imports MainFrame.SysCheckData
Imports System.Text
Imports DBUtility
Imports System.Windows.Forms

Public Class FrmMouldOut

    Public MouldID As String
    Private UserId As String = VbCommClass.VbCommClass.UseId

#Region "初始化"
    Private Sub FrmMouldOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMouldID.Text = MouldID
        txtMouldID_TextChanged(Nothing, Nothing)
        LoadData()
        BindComboxLine(cboRequestLine)
    End Sub
#End Region

#Region "事件"
    '模号文本框改变事件
    Private Sub txtMouldID_TextChanged(sender As Object, e As EventArgs) Handles txtMouldID.TextChanged
        If String.IsNullOrEmpty(txtMouldID.Text.Trim) Then Exit Sub
        SetControlValue()
    End Sub

    '责任人工号改变事件
    Private Sub txtOutToUserId_TextChanged(sender As Object, e As EventArgs) Handles txtOutToUserId.TextChanged
        If String.IsNullOrEmpty(txtOutToUserId.Text.Trim) Then
            txtOutToUserName.Clear()
            txtOutDeptUnit.Clear()
            Return
        End If

        Try
            Dim strSQL As String = "SELECT e.Code,e.Name Name,d.Name DeptName FROM V_EMPLOYEEONJOB e " &
                                  " inner join S2_Department d on e.DeptCode=d.Code where e.Code='" & txtOutToUserId.Text.Trim & "'"
            Dim ds As DataSet = New DataSet
            ds = DbOracleForSpcHelperSQL.Query(strSQL)
            If ds.Tables(0).Rows.Count > 0 Then
                txtOutDeptUnit.Text = ds.Tables(0).Rows(0)("DeptName").ToString
                txtOutToUserName.Text = ds.Tables(0).Rows(0)("Name").ToString
            Else
                txtOutDeptUnit.Text = ""
                txtOutToUserName.Text = ""
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldOut", "txtOutToUserId_TextChanged", "sys")
        End Try
    End Sub


    Public Sub BindComboxLine(ByVal ColComboBox As ComboBox)
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT DISTINCT OutLineID FROM dbo.m_MouldInOutRecord_t a")
        strSQL.Append(" LEFT JOIN dbo.m_Mould_t b ON  a.MouldID = b.MouldID")
        strSQL.Append(" WHERE b.FactoryID ='" & VbCommClass.VbCommClass.Factory & "'")
        strSQL.Append(" AND B.ProfileID='" & VbCommClass.VbCommClass.profitcenter & "'")
        strSQL.Append("AND OutLineID <>''")
        'GetFatoryOther()

        BindCombox(strSQL.ToString, ColComboBox, "OutLineID", "OutLineID")

    End Sub

    Public Shared Sub BindCombox(ByVal SQL As String, ByVal ColComboBox As ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)

        Dim dr As DataRow = dt.NewRow

        dr(Text) = ""
        dr(value) = ""
        dt.Rows.InsertAt(dr, 0)

        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value
    End Sub

    '出库
    Private Sub toolMouldOut_Click(sender As Object, e As EventArgs) Handles toolMouldOut.Click
        Dim strBSQL As New StringBuilder
        Dim strSQL As String
        Dim state As String
        Dim o_ProcessedMouldList As String = String.Empty
        Try
            For Each tempMouldID As String In Me.txtMouldID.Text.Split(",")
                tempMouldID = tempMouldID.Trim()

                If CheckInput(tempMouldID) = False Then Exit Sub

                If Not String.IsNullOrEmpty(o_ProcessedMouldList) Then
                    If ("," & o_ProcessedMouldList.TrimEnd(",") & ",").IndexOf("," & tempMouldID & ",") >= 0 Then
                        Continue For
                    End If
                End If
                If CheckBox1.Checked = True Then
                    state = "Y"
                Else
                    state = "N"
                End If

                strSQL = "INSERT INTO m_MouldInOutRecord_t (MouldID,OutDate,OutDeptUnit,OutToUserId,OutToUserName,OutFromUserId,ApplyPart,OutRemark, Status, UserID ," &
                         " Intime,OutLineID) VALUES ('{0}',getdate(),N'{1}','{2}',N'{3}','{4}','{5}',N'{6}',0,'{7}',getdate(),N'{8}') "

                strBSQL.AppendFormat(strSQL, tempMouldID, txtOutDeptUnit.Text.Trim, txtOutToUserId.Text.Trim, txtOutToUserName.Text.Trim, UserId,
                                    txtApplyPart.Text.Trim, txtRemark.Text.Trim, UserId, cboRequestLine.Text.Trim())
                strBSQL.AppendFormat(" UPDATE  m_Mould_t SET UseStatus=1,UsedTimes=UsedTimes+1, Location= N'" & txtOutDeptUnit.Text.Trim & "',state = '" + state + "' where MouldID ='{0}'", tempMouldID)

                o_ProcessedMouldList &= tempMouldID + ","

            Next

            If Not String.IsNullOrEmpty(strBSQL.ToString) Then
                DbOperateUtils.ExecSQL(strBSQL.ToString)
            End If

            MessageUtils.ShowInformation("模号[" & Me.txtMouldID.Text & "]已调出!")
            txtOutDeptUnit.Clear()
            txtOutToUserId.Clear()
            txtOutToUserName.Clear()
            txtRemark.Clear()
            txtUseStatus.Text = "1-使用中"

            LoadData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldOut", "toolMouldOut_Click", "sys")
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
            Dim strSQL As String = "SELECT ID,MouldID,OutDate,OutDeptUnit,OutLineID,OutToUserId+'/'+OutToUserName OutToUserId,OutFromUserId  +'/'+u2.UserName OutFromUserId," &
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

    '检查数据
    Private Function CheckInput(ByVal strTempMouldID As String) As Boolean
        Dim strSQL As String = String.Format("SELECT UseStatus FROM m_Mould_t WHERE MouldID ='{0}'", strTempMouldID)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            MessageUtils.ShowInformation("模具:['" & strTempMouldID & "']不存在!")
            Return False
        ElseIf dt.Rows(0)(0).ToString <> "0" Then
            MessageUtils.ShowInformation("闲置中的模具才可以借出,模具:['" & strTempMouldID & "']不是闲置状态!")
            Return False
        End If

        If String.IsNullOrEmpty(txtOutToUserName.Text.Trim) Then
            MessageUtils.ShowInformation("责任人工号不存在或已离职!")
            Return False
        End If
        Return True
    End Function

    '设置面板控件值
    Private Sub SetControlValue()
        Try
            Dim strSQL As String = "SELECT [MouldID],[ParaDesc],[MapID],[NewMouldID] ,[Type] ,[Cavitys] ,[Strips] ,[Tails] ,[Slots] ,[Parts] ,[Location] ,[AssetsID] ,[state]," &
                              " [Storage], [LimitTimes], [AlertTimes], [UsedTimes]," &
                              " case UseStatus when 0 then N'0-闲置中' when 1 then N'1-使用中' when 2 then N'2-维修中' end UseStatus FROM m_Mould_t where MouldID='" & txtMouldID.Text.Trim & "'"
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
                txtOutToUserId.Text = ""
                txtRemark.Text = ""
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldOut", "SetControlValue", "sys")
        End Try
    End Sub
#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBatchAdd.Click
        Dim o_iFirstMouldList As String = Me.txtMouldID.Text
        Dim frm As FrmMouldSetForm = New FrmMouldSetForm(o_iFirstMouldList, Me.txtMouldID.Text)
        frm.ShowDialog()

        'if (f2.DialogResult == DialogResult.OK)
        ' {
        '     this.textBox1.Text = f2.str;
        ' }

        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtMouldID.Text = frm.m_SelectedMouldList
        End If
    End Sub
End Class