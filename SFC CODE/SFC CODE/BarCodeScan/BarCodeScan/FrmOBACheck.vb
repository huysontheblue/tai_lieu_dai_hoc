Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmOBACheck

#Region "字段,属性"
    Private actionType As String
    Private Enum FormBtnonType
        Normal
        Add
        Edit
    End Enum



    Private Enum OBACkGridView
        Ppid
        Partid
        Obacode
        Obaname
        Moid
        Lineid
        Result
        Remark
        Userid
        Intime
    End Enum

#End Region
#Region "事件"
    Private Sub FrmOBACheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        BindComboxStatus(Me.cbOba)
        GetData()
    End Sub

    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Me.actionType = FormBtnonType.Add.ToString
        SetControl()
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If Me.dgvObaCheck.RowCount < 1 OrElse Me.dgvObaCheck.CurrentCell Is Nothing Then
            Exit Sub
        End If
        txtMoid.Text = Me.dgvObaCheck.CurrentRow.Cells(OBACkGridView.Moid).Value.ToString
        txtPartId.Text = Me.dgvObaCheck.CurrentRow.Cells(OBACkGridView.Partid).Value.ToString
        cbOba.SelectedValue = Me.dgvObaCheck.CurrentRow.Cells(OBACkGridView.Obacode).Value.ToString
        txtPpid.Text = Me.dgvObaCheck.CurrentRow.Cells(OBACkGridView.Ppid).Value.ToString
        txtRemark.Text = Me.dgvObaCheck.CurrentRow.Cells(OBACkGridView.Remark).Value.ToString

        txtLineId.Text = Me.dgvObaCheck.CurrentRow.Cells(OBACkGridView.Lineid).Value.ToString

        Me.cbResult.Text = Me.dgvObaCheck.CurrentRow.Cells(OBACkGridView.Result).Value.ToString
        Me.actionType = FormBtnonType.Edit.ToString
        SetControl()
    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        If Me.dgvObaCheck.RowCount < 1 OrElse Me.dgvObaCheck.CurrentCell Is Nothing Then
            Exit Sub
        End If
        Dim confirmMsg As String = "确定要作废吗？"
        If (MessageUtils.ShowConfirm(confirmMsg, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            If SetAbandon() = True Then
                MessageBox.Show("作废成功!")
                GetData()
            End If

        End If
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        If String.IsNullOrEmpty(Me.txtMoid.Text) Then
            Me.lbMsg.Text = "请输入工单编号!"
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.txtPartId.Text) Then
            Me.lbMsg.Text = "请输入料件编码!"
            Exit Sub
        End If

        If ckIsExistsPartId(txtPartId.Text) = False Then
            Me.lbMsg.Text = "当前料号不存在!"
            Exit Sub
        End If

        If ckIsExistsMoid(txtMoid.Text) = False Then
            Me.lbMsg.Text = "当前工单编号不存在!"
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.cbOba.Text) Then
            Me.lbMsg.Text = "请选择OQA项目!"
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.txtPpid.Text) Then
            Me.lbMsg.Text = "请输入产品条码!"
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.cbResult.Text) Then
            Me.lbMsg.Text = "请选择检验结果!"
            Exit Sub
        End If
        If Me.cbResult.Text = "Fail" AndAlso String.IsNullOrEmpty(txtRemark.Text) Then
            Me.lbMsg.Text = "请填写备注!"
            Exit Sub
        End If
        SavaData()
        Me.actionType = FormBtnonType.Normal.ToString
        SetControl()
        GetData()
    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        Me.actionType = FormBtnonType.Normal.ToString
        SetControl()
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        GetData()
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#End Region

#Region "函数"
    '保存
    Private Sub SavaData()
        Try
            Dim o_strSql As New StringBuilder
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim partid As String
            Dim obacode As String
            Dim ppid As String
            If Me.actionType = FormBtnonType.Add.ToString Then

                o_strSql.Append("INSERT INTO m_QualityCheckOBA_t ")
                o_strSql.Append(" (ppid,partid,obacode,moid,lineid,result,remark,usey,userid,intime) ")
                o_strSql.Append(" VALUES('" & txtPpid.Text & "','" & txtPartId.Text & "','" & Me.cbOba.SelectedValue.ToString & "',")
                o_strSql.Append(" '" & txtMoid.Text & "','" & txtLineId.Text & "','" & Me.cbResult.Text & "',N'" & Me.txtRemark.Text & "','Y','" & UserID & "',GETDATE())")
         
            Else
                partid = Me.dgvObaCheck.CurrentRow.Cells(OBACkGridView.Partid).Value.ToString
                obacode = Me.dgvObaCheck.CurrentRow.Cells(OBACkGridView.Obacode).Value.ToString
                ppid = Me.dgvObaCheck.CurrentRow.Cells(OBACkGridView.Ppid).Value.ToString
                o_strSql.Append("update m_QualityCheckOBA_t set moid='" & txtMoid.Text & "',obacode='" & Me.cbOba.SelectedValue.ToString & "',result='" & Me.cbResult.Text & "',lineid='" & txtLineId.Text & "',remark=N'" & Me.txtRemark.Text & "',userid='" & UserID & "',intime=getdate()  WHERE ppid='" & ppid & "' and  partid='" & partid & "' and  obacode='" & obacode & "'")

            End If
            DbOperateUtils.ExecSQL(o_strSql.ToString)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOBACheck", "SaveData()", "sys")
        End Try
    End Sub
    '查找
    Private Sub GetData()
        Try
            Dim o_strSql As New StringBuilder
            o_strSql.Append("select top 5000 a.ppid,a.partid,a.obacode,b.obaname,a.moid,a.lineid,a.result,a.remark,a.userid,a.intime  ")
            o_strSql.Append("  from m_QualityCheckOBA_t a left join ")
            o_strSql.Append(" m_BasicOBA_t b on b.obacode=a.obacode where a.usey='Y' ")
            If Not String.IsNullOrEmpty(txtMoid.Text) Then
                o_strSql.Append(" and a.moid='" & Me.txtMoid.Text & "'")
            End If
            If Not String.IsNullOrEmpty(txtPartId.Text) Then
                o_strSql.Append(" and a.partid='" & Me.txtPartId.Text & "'")
            End If
            If Not String.IsNullOrEmpty(Me.cbOba.Text) Then
                o_strSql.Append(" and a.obacode = '" & Me.cbOba.SelectedValue.ToString & "'")
            End If
            If Not String.IsNullOrEmpty(Me.txtPpid.Text) Then
                o_strSql.Append(" and a.ppid like '%" & Me.txtPpid.Text & "%'")
            End If

            If Not String.IsNullOrEmpty(Me.txtLineId.Text) Then
                o_strSql.Append(" and a.lineid like '%" & Me.txtLineId.Text & "%'")
            End If

            If Not String.IsNullOrEmpty(Me.cbResult.Text) Then
                o_strSql.Append(" and a.result like '%" & Me.cbResult.Text & "%'")
            End If

            If Not String.IsNullOrEmpty(Me.txtRemark.Text) Then
                o_strSql.Append(" and a.remark like '%" & Me.txtRemark.Text & "%'")
            End If
            Dim dt As DataTable = DbOperateUtils.GetDataTable(o_strSql.ToString)
            dgvObaCheck.DataSource = dt
            ToolCount.Text = dt.Rows.Count
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOBACheck", "GetData()", "sys")
        End Try
    End Sub
    '作废
    Private Function SetAbandon() As Boolean
        Try
            Dim strSql As String
            Dim partid As String
            Dim obacode As String
            Dim ppid As String
            Dim b As Boolean = False
            partid = Me.dgvObaCheck.CurrentRow.Cells(OBACkGridView.Partid).Value.ToString
            obacode = Me.dgvObaCheck.CurrentRow.Cells(OBACkGridView.Obacode).Value.ToString
            ppid = Me.dgvObaCheck.CurrentRow.Cells(OBACkGridView.Ppid).Value.ToString
            strSql = "update m_QualityCheckOBA_t set usey='N' where partid='" & partid & "' and obacode='" & obacode & "' and ppid='" & ppid & "'"
            DbOperateUtils.ExecSQL(strSql)
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOBACheck", "SaveData()", "sys")
        End Try
    End Function

    '检查料号是否存在
    Private Function ckIsExistsPartId(ByVal partId As String) As Boolean
        Try
            Dim strSql As String
            Dim b As Boolean = True
            strSql = "select TAvcPart from m_PartContrast_t(nolock) where TAvcPart='" & partId & "'"
            Dim i As Integer = DbOperateUtils.GetRowsCount(strSql)
            If i < 1 Then
                b = False
            End If
            Return b
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOBACheck", "checkPartId()", "sys")
        End Try
    End Function
    '检查工单是否存在
    Private Function ckIsExistsMoid(ByVal moid As String) As Boolean
        Try
            Dim strSql As String
            Dim b As Boolean = True
            strSql = "select moid from m_Mainmo_t where moid='" & moid & "'"
            Dim i As Integer = DbOperateUtils.GetRowsCount(strSql)
            If i < 1 Then
                b = False
            End If
            Return b
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOBACheck", "checkPartId()", "sys")
        End Try
    End Function
    '设置控件权限
    Private Sub SetControl()
        If Me.actionType = FormBtnonType.Add.ToString Then

            toolAdd.Enabled = False
            toolEdit.Enabled = False
            toolAbandon.Enabled = False
            toolBack.Enabled = True
            toolSave.Enabled = True
            txtPartId.ReadOnly = False
            txtPpid.ReadOnly = False
        ElseIf actionType = FormBtnonType.Edit.ToString Then

            toolAdd.Enabled = False
            toolAbandon.Enabled = False
            toolEdit.Enabled = False
            toolBack.Enabled = True
            toolSave.Enabled = True
            txtPartId.ReadOnly = True
            txtPpid.ReadOnly = True
        Else

            toolAdd.Enabled = True
            toolEdit.Enabled = True
            toolBack.Enabled = False
            toolSave.Enabled = False
            toolAbandon.Enabled = True
            txtPartId.ReadOnly = False
            txtPpid.ReadOnly = False
            clearText()
        End If
    End Sub

    '清除数据
    Private Sub clearText()
        For Each contr As Control In Me.Panel1.Controls
            If (TypeOf contr Is System.Windows.Forms.TextBox) Then
                contr.Text = ""
            End If
            Me.cbResult.SelectedIndex = -1
            Me.cbOba.SelectedIndex = -1
            Me.lbMsg.Text = ""
        Next
    End Sub

    ''' <summary>
    ''' OBA
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Private Sub BindComboxStatus(ByVal ColComboBox As ComboBox)

        Dim o_strSql As New StringBuilder
        o_strSql.Append(" select a.obacode as value,a.obacode+'-'+b.obaname as text  from m_PartSetOBA_t ")
        o_strSql.Append("  a left join m_BasicOBA_t b on b.obacode=a.obacode ")
        o_strSql.Append("  WHERE  a.partid='" & txtPartId.Text & "' ")

        Dim dt As DataTable = DbOperateUtils.GetDataTable(o_strSql.ToString)
        Dim dr As DataRow = dt.NewRow

        dr("text") = ""
        dr("value") = ""
        dt.Rows.InsertAt(dr, 0)
        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = "text"
        ColComboBox.ValueMember = "value"

    End Sub
#End Region



    Private Sub txtPartId_MouseLeave(sender As Object, e As EventArgs) Handles txtPartId.MouseLeave
        BindComboxStatus(Me.cbOba)
    End Sub
End Class