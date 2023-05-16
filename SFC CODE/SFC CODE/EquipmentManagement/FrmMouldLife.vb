Imports MainFrame
Imports System.Text
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmMouldLife

    Public LifeMouldID As String    '模号
    Private UserId As String = VbCommClass.VbCommClass.UseId    '工号

#Region "初始化"
    Private Sub FrmMouldLife_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMouldID.Text = LifeMouldID
        BindComboxLine(cboRequestLine)
        txtMouldID_TextChanged(Nothing, Nothing)
        LoadData()
        dtCheckDate.Value = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
    End Sub
#End Region

#Region "事件"
    '校验
    Private Sub toolCheck_Click(sender As Object, e As EventArgs) Handles toolCheck.Click
        Dim strBSQL As New StringBuilder
        Dim strSQL As String = String.Empty
        Dim o_strProcessResult As String = String.Empty, o_strUseY As String = "Y", o_strIsRepeatCheck As String = "0"

        Try
            If Not InputCheck() Then Exit Sub

            o_strProcessResult = IIf(rdoError.Checked = True, "N", "Y")

            If o_strProcessResult = "N" Then
                o_strUseY = "N"
            End If

            If String.IsNullOrEmpty(cboResult.Text) Then
                'do nothing
            Else
                o_strIsRepeatCheck = Me.cboResult.Text.Trim.Substring(0, 1)
            End If


            strSQL = "INSERT INTO m_MouldLife_t (MouldID,CheckInfo,CheckDate,CheckUserId,UsedTimes,CheckedTimes,Result " &
                     " ,Remark,UserID,Intime,ProcessResult,IsRepeatCheck,TheDayUseTimes,Parts,OutLineID,FACTORYID) VALUES ('{0}',N'{1}','{2}','{3}',{4},{5},'{6}',N'{7}','{8}',getdate(),N'{9}','{10}','{11}','{12}','{13}','{14}') "
            strBSQL.AppendFormat(strSQL, txtMouldID.Text.Trim, txtCheckInfo.Text.Trim, dtCheckDate.Value, txtCheckUserId.Text.Trim,
                                    txtUsedTimes.Text.Trim, (CInt(txtCheckedTimes.Text.Trim) + CInt(txtTodayUseTimes.Text.Trim)), cboResult.SelectedItem.ToString, txtRemark.Text.Trim, UserId, o_strProcessResult, o_strIsRepeatCheck, Val(Me.txtTodayUseTimes.Text.Trim), txtApplyPart.Text.Trim, cboRequestLine.Text, VbCommClass.VbCommClass.Factory)


            strBSQL.AppendFormat("UPDATE  m_Mould_t SET UseY='{0}',UsedTimes='{1}' WHERE MouldID ='{2}'", o_strUseY, (CInt(txtCheckedTimes.Text.Trim) + CInt(txtTodayUseTimes.Text.Trim)), txtMouldID.Text.Trim)

            'strBSQL.AppendFormat("UPDATE  m_Mould_t SET LimitTimes={0},UsedTimes=0 WHERE MouldID ='{1}'", txtCheckedTimes.Text.Trim, txtMouldID.Text.Trim)



            DbOperateUtils.ExecSQL(strBSQL.ToString)
            MessageUtils.ShowInformation("模号[" & LifeMouldID & "]已保存!")
            LoadData()
            txtTodayUseTimes.Text = ""
            txtCheckUserId.Text = ""
            txtCheckInfo.Text = ""
            txtRemark.Text = ""
            strSQL = "SELECT TOP 1 CheckedTimes FROM m_MouldLife_t WHERE MouldID='" & txtMouldID.Text.Trim & "' ORDER BY ID DESC"
            Dim ds As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If ds.Rows.Count > 0 Then
                txtCheckedTimes.Text = ds.Rows(0)("CheckedTimes").ToString
            Else
                txtCheckedTimes.Text = 0
            End If
            cboResult.SelectedIndex = 0
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldLife", "toolCheck_Click", "sys")
        End Try
    End Sub

    '模号文本框改变事件
    Private Sub txtMouldID_TextChanged(sender As Object, e As EventArgs) Handles txtMouldID.TextChanged
        If String.IsNullOrEmpty(txtMouldID.Text.Trim) Then Exit Sub
        SetControlValue()
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
            Dim strSQL As String = " SELECT MouldID,TheDayUseTimes,CheckedTimes,(Case IsRepeatCheck when '0' then N'否' when '1' then N'是' end) IsRepeatCheck," & _
                                   " (case ProcessResult when 'Y' then N'Y.正常' when 'N' then N'N.报废' end) ProcessResult," & _
                                   " CheckUserId+'/'+isnull(u.UserName,'') CheckUserId," & _
                                   " CheckDate, " & _
                                   " Remark,CheckInfo " &
                           " FROM m_MouldLife_t m LEFT JOIN m_Users_t u ON m.CheckUserId=u.UserID where MouldID='{0}' ORDER BY ID desc"
            strSQL = String.Format(strSQL, txtMouldID.Text.Trim)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            dgvMouldLife.DataSource = dt
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMouldLife", "LoadData", "sys")
        End Try
    End Sub

    '校验时  输入检查
    Private Function InputCheck() As Boolean
        'Dim strSQL As String
        'strSQL = String.Format("select UseStatus,AlertTimes from m_Mould_t where MouldID ='{0}'", txtMouldID.Text.Trim)
        'Dim dtm As DataTable = DbOperateUtils.GetDataTable(strSQL)
        'If dtm.Rows(0)(0).ToString <> "0" Then
        '    MessageUtils.ShowInformation("闲置中的模具才可以校验!")
        '    Return False
        'End If

        If String.IsNullOrEmpty(cboResult.Text.Trim) Then
            'MessageUtils.ShowInformation("试模结果不能为空!")
            'Return False
        End If

        If String.IsNullOrEmpty(txtCheckUserId.Text.Trim) Then
            MessageUtils.ShowInformation("维护人不能为空!")
            txtCheckUserId.Focus()
            Return False
        Else
            Dim dt As DataTable = DbOperateUtils.GetDataTable(String.Format("select * from m_Users_t where UserID ='{0}'", txtCheckUserId.Text.Trim))
            If dt.Rows.Count <= 0 Then
                MessageUtils.ShowInformation("维护人工号不存在")
                txtCheckUserId.Clear()
                Return False
            End If
        End If

        If Not IsNumeric(txtCheckedTimes.Text.Trim) Then
            MessageUtils.ShowInformation("校验后使用次数应为数字!")
            txtCheckedTimes.Focus()
            Return False
        End If


        'If CInt(dtm.Rows(0)(1).ToString) > CInt(txtCheckedTimes.Text.Trim) Then
        '    MessageUtils.ShowInformation("校验后使用次数不能小于预警次数[" & dtm.Rows(0)(1).ToString & "]")
        '    txtCheckedTimes.Focus()
        '    Return False
        'End If

        Return True
    End Function

    '设置面板控件值
    Private Sub SetControlValue()
        Try
            Dim strSQL As String = "SELECT [MouldID],[ParaDesc],[MapID],[NewMouldID] ,[Type] ,[Cavitys] ,[Strips] ,[Tails] ,[Slots] ,[Parts] ,[Location] ,[AssetsID] ," &
                              " [Storage], [LimitTimes], [AlertTimes], [UsedTimes]," &
                              " case UseStatus when 0 then N'0-闲置中' when 1 then N'1-使用中' when 2 then N'2-维修中' end [UseStatus] FROM [dbo].[m_Mould_t] where MouldID='" & txtMouldID.Text.Trim & "'"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                txtUsedTimes.Text = dt.Rows(0)("UsedTimes").ToString
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
                strSQL = "SELECT TOP 1 CheckedTimes FROM m_MouldLife_t WHERE MouldID='" & txtMouldID.Text.Trim & "' ORDER BY ID DESC"
                Dim ds As DataTable = DbOperateUtils.GetDataTable(strSQL)
                If ds.Rows.Count > 0 Then
                    txtCheckedTimes.Text = ds.Rows(0)("CheckedTimes").ToString
                Else
                    txtCheckedTimes.Text = 0
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
                txtUsedTimes.Text = ""
            End If
            txtCheckUserId.Text = ""
            txtCheckInfo.Text = ""
            txtRemark.Text = ""
            'txtCheckedTimes.Text = ""
            cboResult.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Grid行数"
    Private Sub dgvMouldLife_RowPostPaint(sender As Object, e As Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvMouldLife.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

   
    Private Sub txtTodayUseTimes_TextChanged(sender As Object, e As EventArgs)

        If String.IsNullOrEmpty(txtTodayUseTimes.Text.Trim) Then
            txtTodayUseTimes.Clear()
            Return
        End If

        Me.txtCheckedTimes.Text = Val(Me.txtTodayUseTimes.Text) + Val(Me.txtUsedTimes.Text)

    End Sub
    Public Sub BindComboxLine(ByVal ColComboBox As ComboBox)
        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT DISTINCT OutLineID FROM dbo.m_MouldInOutRecord_t a")
        strSQL.Append(" LEFT JOIN dbo.m_Mould_t b ON  a.MouldID = b.MouldID")
        strSQL.Append(" WHERE b.FactoryID ='" & VbCommClass.VbCommClass.Factory & "'")
        strSQL.Append(" AND B.ProfileID='" & VbCommClass.VbCommClass.profitcenter & "'")
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
End Class