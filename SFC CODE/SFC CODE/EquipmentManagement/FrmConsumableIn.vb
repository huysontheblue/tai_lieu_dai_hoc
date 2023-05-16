Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Windows.Forms

Public Class FrmConsumableIn

    Private m_blnExistConsuleNO As Boolean = False

    Private Sub FrmSelectLine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            initload()
            FillCombox(cboRequestClass)
        End If
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

    Private Sub initload()

        ' EquManageCommon.BindComboxClass(cboRequestClass)
        EquManageCommon.BindComboxClass(cboRequestClass)

        'If cboRequestClass.SelectedValue IsNot Nothing Then
        '    EquManageCommon.BindComboxLine(cboRequestLine, cboRequestClass.SelectedValue.ToString)
        'End If

        lblMsg.Text = ""

        '  Me.txtStorage.Text = GetStorage()

    End Sub

    Private Function GetStorage() As String
        Dim lsSQL As String = String.Empty
        GetStorage = ""
        lsSQL = " SELECT Storage FROM dbo.m_Consumable_t WHERE ID ='" & Me.lblIDList.Text.Trim & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetStorage = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("Storage"))
            Else
                GetStorage = ""
            End If
        End Using
    End Function



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sql As New StringBuilder
        Dim strChecker As String = VbCommClass.VbCommClass.UseId
        Dim strFactoryName As String = VbCommClass.VbCommClass.Factory
        Dim strProficenter As String = VbCommClass.VbCommClass.profitcenter
        Dim strStorage As String = String.Empty
        Try

            'First check this equ, 是否填写正确
            If Not CheckInput() Then
                Exit Sub
            End If

            If Not ExistConsuableNo() Then
                SetMessage("E", "请先维护消耗品信息！")
                Exit Sub
            End If


            '入庫人員	工治具編號	數量	倉庫儲位	入庫時間
            sql.Append(" Update  m_Consumable_t SET Qty =Qty + " & Val(Me.txtQty.Text.Trim) & " ")
            sql.Append(" WHERE ConsumableNo = N'" & Me.txtConsumableNo.Text & "'")

            sql.Append(" INSERT INTO m_ConsumableInlog_t ")
            sql.Append(" (Consumableno, Qty, Storage, Userid, DeptName,Intime)")
            sql.Append(" VALUES( N'" & Me.txtConsumableNo.Text & "','" & Val(Me.txtQty.Text.Trim) & "', ")
            sql.Append(" '" & Me.txtStorage.Text.Trim & "','" & VbCommClass.VbCommClass.UseId & "',N'" & Me.cboRequestClass.Text.Trim & "',getdate()) ")

            DbOperateUtils.ExecSQL(sql.ToString)
            MessageUtils.ShowInformation("入库成功")
            'Me.Close()
            txtConsumableNo.Text = ""
            txtStorage.Text = ""
            txtQty.Text = ""
            txtConsumableNo.Focus()
        Catch ex As Exception
            ' Throw ex
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmConsumbleIn", "btnSave_Click", "WIP")
        End Try
    End Sub

    Private Function CheckInput() As Boolean
        'If String.IsNullOrEmpty(Me.txtStorage.Text.Trim()) Then
        '    SetMessage("E", "请填写归还到栏位！")
        '    Return False
        'End If
        Dim SQL As String
        Dim dt As DataTable
        SQL = "SELECT ConsumableNo FROM m_Consumable_t WHERE ConsumableNo = N'" & Me.txtConsumableNo.Text & "'"
        dt = DbOperateUtils.GetDataTable(SQL)
        If dt.Rows.Count < 1 Then
            SetMessage("E", "设备编号不存在，请重新输入！")
            Me.ActiveControl = Me.txtConsumableNo
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtQty.Text) Then
            SetMessage("E", "请填写[入库数量]栏位！")
            Me.ActiveControl = Me.txtQty
            Return False
        End If

        If Val(Me.txtQty.Text) <= 0 Then
            SetMessage("E", "请检查[入库数量]栏位，必须输入大于0的数字！")
            Me.ActiveControl = Me.txtQty
            Return False
        End If


        Return True
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

    'Private Sub cboRequestClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRequestClass.SelectedIndexChanged
    '    If cboRequestClass.SelectedValue IsNot Nothing Then
    '        EquManageCommon.BindComboxLine(cboRequestLine, cboRequestClass.SelectedValue.ToString)
    '    End If
    'End Sub



    Private Sub txtConsumableNo_Leave(sender As Object, e As EventArgs) Handles txtConsumableNo.Leave
        If Not String.IsNullOrEmpty(Me.txtConsumableNo.Text) Then
            m_blnExistConsuleNO = ExistConsuableNo()
        End If
    End Sub

    Private Function ExistConsuableNo() As Boolean
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT TOP 1 1  FROM m_Consumable_t Where ConsumableNo=N'" & Me.txtConsumableNo.Text & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                ' Me.txtStorage.Text = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item(0))
                ExistConsuableNo = True
            Else
                ExistConsuableNo = False
            End If
        End Using
    End Function

    Private Sub txtConsumableNo_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles txtConsumableNo.KeyDown
        Dim strSQL As String
        Dim dt As DataTable
        If (e.KeyCode = Keys.Enter) Then
            strSQL = "SELECT ConsumableNo,ConsumableName FROM m_Consumable_t WHERE ConsumableNo = N'" & Me.txtConsumableNo.Text & "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count < 1 Then
                SetMessage("E", "设备编号不存在，请重新输入！")
                txtPartID.Text = ""
                txtQty.Text = ""

                Return
            Else
                txtPartID.Text = dt.Rows(0)(1)
                txtQty.Text = "1"
                txtConsumableNo.Focus()
            End If
        End If
    End Sub
End Class
