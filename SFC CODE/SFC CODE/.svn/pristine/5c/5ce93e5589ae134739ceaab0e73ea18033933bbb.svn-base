Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmMoudleStorage

#Region "定义枚举"
    Private Enum FormBtnonType
        Normal
        Add
        Modify
        Abandon
        Save
        Undo
        Search
    End Enum
#End Region

#Region "属性"
    '当前状态
    Public _ActivateStatus As String
    Public Property ActivateStatus() As String
        Get
            Return _ActivateStatus
        End Get
        Set(ByVal value As String)
            _ActivateStatus = value
        End Set
    End Property
#End Region

#Region "初始化"
    Private Sub FrmMoudleStorage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetControlEnable(FormBtnonType.Normal)  '设置初始面板状态

        Search()
    End Sub
#End Region

#Region "事件"
    '新增
    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        Me._ActivateStatus = FormBtnonType.Add.ToString
        SetControlEnable(FormBtnonType.Add)
        ClearControlValue()
    End Sub

    '修改
    Private Sub toolModify_Click(sender As Object, e As EventArgs) Handles toolModify.Click
        If Me.dgvStorage.RowCount < 1 OrElse Me.dgvStorage.CurrentRow Is Nothing Then Exit Sub

        Me._ActivateStatus = FormBtnonType.Modify.ToString
        SetControlEnable(FormBtnonType.Modify)

        txtStorageID.Text = dgvStorage.CurrentRow.Cells("StorageID").Value.ToString
        txtWarehouse.Text = dgvStorage.CurrentRow.Cells("Warehouse").Value.ToString
        txtRemark.Text = dgvStorage.CurrentRow.Cells("Remark").Value.ToString
    End Sub

    '作废
    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        If Me.dgvStorage.Rows.Count < 1 OrElse Me.dgvStorage.CurrentRow Is Nothing Then Exit Sub
        Try
            Dim storageID As String = Me.dgvStorage.CurrentRow.Cells("StorageID").Value.ToString
            Dim warehouse As String = Me.dgvStorage.CurrentRow.Cells("Warehouse").Value.ToString
            Dim dt As DataTable = DbOperateUtils.GetDataTable(String.Format("select 1 from m_Mould_t where Storage='{0}' AND FactoryID='{1}' ", storageID, VbCommClass.VbCommClass.Factory))
            If dt.Rows.Count > 0 Then
                MessageUtils.ShowWarning("储位在使用中，不允许被作废!")
                Return
            End If

            Dim confirmMsg As String = "确定要作废[" & storageID & "-" & warehouse & "]吗?"
            If (MessageUtils.ShowConfirm(confirmMsg, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                AbandonData()
                Search()
            End If

            SetControlEnable(FormBtnonType.Abandon)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMoudleStorage", "toolAbandon_Click", "sys")
        End Try
    End Sub

    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            If InputCheck() = True Then
                If SaveData() = True Then
                    MessageUtils.ShowInformation("保存成功!")
                    SetControlEnable(FormBtnonType.Save)
                    Me._ActivateStatus = FormBtnonType.Normal.ToString
                    Search()
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmMoudleStorage", "toolSave_Click", "sys")
        End Try
    End Sub

    '返回
    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        SetControlEnable(FormBtnonType.Undo)
        Me._ActivateStatus = FormBtnonType.Undo.ToString
    End Sub

    '查询
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        SetControlEnable(FormBtnonType.Search)
        Search()
    End Sub

    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
#End Region

#Region "方法"
    '初始面板状态
    Private Sub SetControlEnable(ByVal fbt As FormBtnonType)
        Select Case fbt
            Case FormBtnonType.Add
                toolNew.Enabled = False
                toolModify.Enabled = False
                toolAbandon.Enabled = False
                toolQuery.Enabled = False
                toolSave.Enabled = True
                toolBack.Enabled = True
                dgvStorage.Enabled = False

                txtStorageID.Enabled = True
                txtWarehouse.Enabled = True
                txtRemark.Enabled = True
                chkUseY.Checked = True
            Case FormBtnonType.Modify
                toolNew.Enabled = False
                toolModify.Enabled = False
                toolAbandon.Enabled = False
                toolQuery.Enabled = False
                toolSave.Enabled = True
                toolBack.Enabled = True
                dgvStorage.Enabled = False

                txtStorageID.Enabled = False
                txtWarehouse.Enabled = True
                txtRemark.Enabled = True
            Case FormBtnonType.Save, FormBtnonType.Normal, FormBtnonType.Undo
                toolNew.Enabled = True
                toolModify.Enabled = True
                toolAbandon.Enabled = True
                toolQuery.Enabled = True
                toolSave.Enabled = False
                toolBack.Enabled = False
                dgvStorage.Enabled = True

                txtStorageID.Enabled = True
                txtWarehouse.Enabled = True
                txtRemark.Enabled = True
                chkUseY.Enabled = True
                chkUseY.Checked = True
                txtStorageID.Text = ""
                txtWarehouse.Text = ""
                txtRemark.Text = ""
                lbMsg.Text = ""
            Case FormBtnonType.Search

        End Select
    End Sub

    '查询方法
    Private Sub Search()
        Try
            Dim strSQL As String = "SELECT StorageID,Warehouse,Remark,FactoryID,Usey FROM m_Storage_t where 1=1 "
            Dim strWhere As New System.Text.StringBuilder

            If Not String.IsNullOrEmpty(txtStorageID.Text.Trim) Then
                strWhere.AppendFormat(" and StorageID like '%{0}%' ", txtStorageID.Text.Trim)
            End If

            If Not String.IsNullOrEmpty(txtWarehouse.Text.Trim) Then
                strWhere.AppendFormat(" and Warehouse like '%{0}%' ", txtWarehouse.Text.Trim)
            End If

            If chkUseY.Checked Then
                strWhere.Append(" and Usey='Y' ")
            Else
                strWhere.Append(" and Usey='N' ")
            End If

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + " AND FactoryID='" + VbCommClass.VbCommClass.Factory + "' order by UseY desc,StorageID ")
            dgvStorage.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    '清空面板控件
    Private Sub ClearControlValue()
        txtStorageID.Text = ""
        txtWarehouse.Text = ""
        txtRemark.Text = ""
    End Sub

    '作废库位信息
    Private Sub AbandonData()
        Try
            Dim storageID As String = Me.dgvStorage.Rows(dgvStorage.CurrentRow.Index).Cells("StorageID").Value.ToString

            Dim strSQL As String = String.Format(" update m_Storage_t set Usey='N' where StorageID=N'{0}'AND FactoryID='{1}' ", storageID, VbCommClass.VbCommClass.Factory)
            DbOperateUtils.ExecSQL(strSQL)
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    '保存时检查输入信息
    Private Function InputCheck() As Boolean
        If String.IsNullOrEmpty(Me.txtStorageID.Text.Trim) Then
            Me.lbMsg.Text = "请输入储位!"
            Me.txtStorageID.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtWarehouse.Text.Trim) Then
            Me.lbMsg.Text = "请输入仓库!"
            Me.txtWarehouse.Focus()
            Return False
        End If

        '储位是否重复
        Dim strSQL As String = String.Format("select 1 from m_Storage_t where StorageID='{0} ' AND FactoryID='{1}'", Me.txtStorageID.Text.Trim, VbCommClass.VbCommClass.Factory)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 AndAlso Me._ActivateStatus = FormBtnonType.Add.ToString Then
            Me.lbMsg.Text = "储位已存在，请勿重复!"
            Me.txtStorageID.Focus()
            Return False
        End If

        Return True
    End Function

    '保存数据
    Private Function SaveData() As Boolean
        Dim result As Boolean = False

        Try
            Dim o_strSql As New StringBuilder
            Dim userid As String = VbCommClass.VbCommClass.UseId
            Dim factoryID As String = VbCommClass.VbCommClass.Factory
            Dim check As String = "N"
            If Me.chkUseY.Checked = True Then
                check = "Y"
            End If

            '新增
            If Me._ActivateStatus = FormBtnonType.Add.ToString Then
                o_strSql.Append("INSERT INTO m_Storage_t (StorageID,Warehouse,Remark,FactoryID,Usey ,UserID,Intime)")
                o_strSql.Append(String.Format(" VALUES(N'{0}',N'{1}',N'{2}','{3}','Y','{4}',GETDATE())", Me.txtStorageID.Text.Trim,
                                              Me.txtWarehouse.Text.Trim, Me.txtRemark.Text.Trim, factoryID, userid))
            Else '修改
                o_strSql.Append(String.Format("UPDATE m_Storage_t SET Warehouse=N'{0}',Remark=N'{1}',Usey='{2}',UserId=N'{3}',Intime=GETDATE() WHERE StorageID='{4}'",
                                             Me.txtWarehouse.Text.ToString, Me.txtRemark.Text.Trim, check, userid, Me.txtStorageID.Text.Trim))
            End If
            DbOperateUtils.ExecSQL(o_strSql.ToString)
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMoudleStorage", "SaveData()", "sys")
        End Try

    End Function

#End Region

#Region "Grid行数"
    Private Sub dgvStorage_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvStorage.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

End Class