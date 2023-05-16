'Public Class FrmConsumableLend

'End Class
Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Windows.Forms

Public Class FrmConsumableLend
    Dim dt As DataTable
    Dim strSQL As String
    Dim strFactoryName As String = VbCommClass.VbCommClass.Factory
    Private Sub FrmSelectLine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            initload()
            FillCombox(cboRequestClass)
        End If
    End Sub

    Private Sub initload()

        'EquManageCommon.BindComboxClass_Consumable(cboRequestClass)
        EquManageCommon.BindComboxClass(cboRequestClass)


        If cboRequestClass.SelectedValue IsNot Nothing Then
            EquManageCommon.BindComboxLine(cboRequestLine, cboRequestClass.SelectedValue.ToString)
        End If

        lblMsg.Text = ""
        ' SetUIValue()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sql As New StringBuilder
        Dim strChecker As String = VbCommClass.VbCommClass.UseId

        Dim strProficenter As String = VbCommClass.VbCommClass.profitcenter
        Dim strStorage As String = String.Empty
        Me.lblMsg.Text = ""
        Try

            'First check this equ, 是否可以借出
            If Not CheckInput() Then
                Exit Sub
            End If

            If Not IsNothing(Me.cboRequestLine.Text.ToString) AndAlso Me.cboRequestLine.Text.ToString <> String.Empty Then
                strStorage = Me.cboRequestLine.Text.ToString
            Else
                strStorage = Me.txtRemark.Text.Trim
            End If

            For Each strID As String In Me.TextBox1.Text.Trim.Split(",")
                sql.Append(" Update  m_Consumable_t SET ")
                sql.Append("  QTY = QTY - " & Val(Me.txtQty.Text.Trim) & "")
                sql.Append(" WHERE ConsumableNo = N'" & strID & " '")

                sql.Append(" DECLARE @ConsumableNo nvarchar(200)")
                sql.Append(" SELECT @ConsumableNo= ConsumableNo FROM m_Consumable_t WHERE ConsumableNo = N'" & strID & " '")
                sql.Append(" INSERT INTO m_ConsumableLendLog_t ")
                sql.Append(" (ConsumableNo,LineID,Qty,Partid, Userid,INTIME,remark,DeptName) ")
                sql.Append(" VALUES(@ConsumableNo,N'" & Me.cboRequestLine.Text.Trim & "',")
                sql.Append("  N'" & Me.txtQty.Text.Trim & "',N'" & Me.txtPartID.Text.Trim & "',")
                sql.Append(" '" & Me.txtKeeperID.Text.Trim & "',getdate(),N'" & Me.txtRemark.Text.Trim & "',N'" & Me.cboRequestClass.Text.Trim & "')")
            Next

            DbOperateUtils.ExecSQL(sql.ToString)
            MessageUtils.ShowInformation("领用成功")
            TextBox1.Text = ""
            txtKeeperID.Text = ""
            txtPartID.Text = ""
            txtRemark.Text = ""
            txtQty.Text = ""
            TextBox1.Focus()
        Catch ex As Exception
            ' Throw ex
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmConsuableLend", "btnSave_Click", "WIP")
        End Try
    End Sub

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)

        Dim UserDg As DataTable

        If ColComboBox.Name = "cboRequestClass" Then
            UserDg = DbOperateUtils.GetDataTable("select dqc from m_Dept_t where usey='Y' and factoryid in (select Factoryid from m_dcompany_t where usey='Y' and SapState='" & VbCommClass.VbCommClass.IsConSap & "')")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "dqc"
            ColComboBox.ValueMember = "dqc"
        ElseIf ColComboBox.Name = "cboRequestLine" Then
            UserDg = DbOperateUtils.GetDataTable("Select  lineid,lineid from Deptline_t where usey='Y' and factoryid in (select Factoryid from m_dcompany_t where usey='Y' and SapState='" & VbCommClass.VbCommClass.IsConSap & "')")
            ColComboBox.DataSource = UserDg
            ColComboBox.DisplayMember = "lineid"
            ColComboBox.ValueMember = "lineid"
        End If
        UserDg = Nothing
    End Sub

    Private Function CheckInput() As Boolean

        'If IsNothing(Me.cboRequestLine.SelectedValue) OrElse String.IsNullOrEmpty(Me.cboRequestLine.SelectedValue.ToString) Then
        '    If String.IsNullOrEmpty(Me.txtRemark.Text) Then
        '        SetMessage("E", "线别或者保管位置必须填写一项！")
        '        Return False
        '    End If
        'End If
        strSQL = "SELECT ConsumableNo FROM m_Consumable_t WHERE ConsumableNo = N'" & Me.TextBox1.Text & "'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count < 1 Then
            SetMessage("E", "设备编号不存在，请重新输入！")
            Return False
        End If
        If String.IsNullOrEmpty(Me.txtKeeperID.Text.Trim()) Then
            SetMessage("E", "请填写领用人人的工号！")
            Return False
        End If
        'strSQL = " SELECT * FROM m_power_t where UserID = '" + txtKeeperID.Text.Trim + "' AND Usey = 'Y' AND FactoryID = '" + strFactoryName + "'"
        strSQL = "SELECT A.USERID,A.FactoryID,A.Creater,A.Intime FROM m_power_t A  Left JOIN m_users_t B  ON A.UserID = B.USERID " &
                 " WHERE   A.UserID= '" + txtKeeperID.Text.Trim + "'  AND A.Usey = 'Y' AND A.FactoryID = '" + strFactoryName + "' AND B.Usey = '1'"
        dt = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count < 1 Then
            MessageUtils.ShowInformation("该人员没有权限领用")
            Return False
        End If
        'If String.IsNullOrEmpty(Me.txtQty.Text.Trim()) Then
        '    SetMessage("E", "请填写领用数量！")
        '    Return False
        'End If

        If String.IsNullOrEmpty(Me.txtQty.Text.Trim()) Then
            SetMessage("E", "请填写领用数量！")
            Return False
        End If

        ' check partid keyin is right or error 
        If String.IsNullOrEmpty(Me.txtPartID.Text.Trim) Then
            'If Not IsPartID() Then
            SetMessage("E", "消耗品名称不能为空！")
            Return False
            'End If
        End If

        If Val(Me.txtQty.Text.Trim) <= 0 Then
            SetMessage("E", "领用数量栏位,请输入大于0的数字！")
            Return False
        End If

        If Not CheckQty() Then
            SetMessage("E", "领用数量不能超过库存数量！")
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 检查 是否有足够的数量 可以领用
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckQty() As Boolean
        '领用数量 > 库存数量
        If Val(Me.txtQty.Text) > Val(GetQty()) Then
            CheckQty = False
        Else
            CheckQty = True
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetQty() As String
        Dim lssql As String = String.Empty
        lssql = " SELECT QTY FROM m_Consumable_t WHERE ConsumableNo =N'" & Me.TextBox1.Text & "' "
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetQty = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item(0))
            Else
                GetQty = "0"
            End If
        End Using
    End Function


    Private Function IsPartID() As Boolean
        Dim lssql As String = String.Empty
        lssql = " SELECT TOP 1 1  FROM dbo.m_PartContrast_t WHERE TAvcPart='" & Me.txtPartID.Text.Trim & "'"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsPartID = True
            Else
                IsPartID = False
            End If
        End Using
    End Function

    Private Sub SetMessage(ByVal type As String, ByVal msg As String)
        Select Case type
            Case "E"
                Me.lblMsg.Text = msg
                Me.lblMsg.BackColor = Drawing.Color.Red
            Case Else
                'do nothing
        End Select
    End Sub


    Private Sub btnCancal_Click(sender As Object, e As EventArgs) Handles btnCancal.Click
        Me.Close()
    End Sub

    Private Sub cboRequestLine_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboRequestClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRequestClass.SelectedIndexChanged
        If cboRequestClass.SelectedValue IsNot Nothing Then
            EquManageCommon.BindComboxLine(cboRequestLine, cboRequestClass.SelectedValue.ToString)
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            strSQL = "SELECT ConsumableNo,ConsumableName FROM m_Consumable_t WHERE ConsumableNo = N'" & Me.TextBox1.Text & "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count < 1 Then
                SetMessage("E", "设备编号不存在，请重新输入！")
                TextBox1.Text = ""
                txtPartID.Text = ""
                txtRemark.Text = ""
                txtQty.Text = ""
                TextBox1.Focus()
                Return
            Else
                txtPartID.Text = dt.Rows(0)(1)
                txtQty.Text = "1"
                txtKeeperID.Focus()
            End If
        End If
    End Sub
End Class
