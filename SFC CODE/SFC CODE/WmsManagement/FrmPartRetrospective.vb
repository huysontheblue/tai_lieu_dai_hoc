Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports System.Text.RegularExpressions
Imports MainFrame


'--原材料追溯
'--Create by :　黄广都
'--Create date :　2017/08/09
'--Update date :  
'--Ver : V01
Public Class FrmPartRetrospective
    Dim ActiveSatus As PartRetrospective.EnumStatus

#Region "窗体事件"
    Private Sub FrmPartRetrospective_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '设定用戶權限
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
  
        SetControlsEnable(PartRetrospective.EnumStatus.Nomal)
      
        LoadPartRetrospectiveData()
     
    End Sub
    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        SetControlsEnable(PartRetrospective.EnumStatus.Add)
    End Sub

    Private Sub toolModify_Click(sender As Object, e As EventArgs) Handles toolModify.Click
        If Me.dgvPartRetrospective.RowCount < 1 OrElse Me.dgvPartRetrospective.CurrentCell Is Nothing Then
            Me.lblMsg.Text = "没有数据可供修改!"
            Exit Sub
        End If

     
        SetControlsEnable(PartRetrospective.EnumStatus.Edit)
        Me.txtPartId.Text = Me.dgvPartRetrospective.CurrentRow.Cells(PartRetrospective.EnumGridView.PartId).Value.ToString
        Me.txtQty.Text = Me.dgvPartRetrospective.CurrentRow.Cells(PartRetrospective.EnumGridView.Qty).Value.ToString
        Me.txtSupplierName.Text = Me.dgvPartRetrospective.CurrentRow.Cells(PartRetrospective.EnumGridView.SupplierName).Value.ToString
        Me.txtProduceDate.Text = Me.dgvPartRetrospective.CurrentRow.Cells(PartRetrospective.EnumGridView.Producedate).Value.ToString


        Me.txtLotNo.Text = Me.dgvPartRetrospective.CurrentRow.Cells(PartRetrospective.EnumGridView.LotNo).Value.ToString


    End Sub


    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        SetControlsEnable(PartRetrospective.EnumStatus.Query)

    End Sub


    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If CheckInput() = True Then
                '保存
                If SaveData() = True Then
                    '提示
                    MessageUtils.ShowInformation("保存成功！")

                Else
                    lblMsg.Text = "保存失败,请检查数据!"
                    Exit Sub
                End If
                SetControlsEnable(PartRetrospective.EnumStatus.Nomal)
                LoadPartRetrospectiveData()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "WmsManagement.FrmPartRetrospective", "toolSave_Click", "sys")
        End Try
    End Sub
    Private Sub toolUndo_Click(sender As Object, e As EventArgs) Handles toolUndo.Click
        SetControlsEnable(PartRetrospective.EnumStatus.Nomal)
    End Sub

    Private Sub toolRefresh_Click(sender As Object, e As EventArgs) Handles toolRefresh.Click
        LoadPartRetrospectiveData()
    End Sub

    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        If Me.dgvPartRetrospective.RowCount < 1 OrElse Me.dgvPartRetrospective.CurrentCell Is Nothing Then
            Exit Sub
        End If
        If DeleteData() = True Then
            Me.lblMsg.Text = "删除成功!"
            LoadPartRetrospectiveData()
        Else
            Me.lblMsg.Text = "删除失败!"
        End If
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click
        If Me.dgvPartRetrospective.RowCount < 1 Then
            Exit Sub
        End If
        ExcelUtils.LoadDataToExcel(Me.dgvPartRetrospective, "原材料追溯记录")
    End Sub
#End Region
   



#Region "方法"
    '设置控件显示
    Private Function CheckInput() As Boolean
        If String.IsNullOrEmpty(Me.txtPartId.Text.Trim()) Then
            Me.lblMsg.Text = "请输入料件编号!"
            Me.txtPartId.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(Me.txtSupplierName.Text.Trim()) Then
            Me.lblMsg.Text = "请输入供应商!"
            Me.txtSupplierName.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(Me.txtLotNo.Text.Trim()) Then
            Me.lblMsg.Text = "请输入Lot No!"
            Me.txtLotNo.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(Me.txtQty.Text.Trim()) Then
            Me.lblMsg.Text = "请输入数量!"
            Me.txtQty.Focus()
            Return False
        End If
        If RegexNumber(Me.txtQty.Text.Trim) = False Then
            Me.lblMsg.Text = "数量必须是数字类型!"
            Me.txtQty.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(Me.txtProduceDate.Text.Trim()) Then
            Me.lblMsg.Text = "请输入生产日期!"
            Me.txtProduceDate.Focus()
            Return False
        End If
        If checkPartIsExists(Me.txtPartId.Text.Trim) = True Then
            Me.lblMsg.Text = "料件编号不存在，请检查是否输入有误!"
            Me.txtPartId.Focus()
            Return False
        End If
        If checkIsExists() = True Then
            Me.lblMsg.Text = "当前记录已存在，请勿重复录入!"
            Me.txtPartId.Focus()
            Return False
        End If
        Return True
    End Function
    '保存数据
    Private Function SaveData() As Boolean
        Dim result As Boolean = False
        Try
            Dim strSql As New StringBuilder()
            Dim ID As String = Nothing
            If Me.ActiveSatus = PartRetrospective.EnumStatus.Add Then
                strSql.Append("INSERT INTO m_PartRetrospective_t(PartId,FactoryName,Profitcenter,Qty,ProduceDate,LotNo,SupplierName,Usey,CreateTime,CreateUserID) ")
                strSql.Append(String.Format("VALUES(N'{0}',N'{1}',N'{2}',{3},N'{4}',N'{5}',N'{6}','Y',GETDATE(),N'{7}') ", Me.txtPartId.Text.Trim,
                                            VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, Me.txtQty.Text.Trim, Me.txtProduceDate.Text.Trim,
                                            Me.txtLotNo.Text.Trim, Me.txtSupplierName.Text.Trim, VbCommClass.VbCommClass.UseId))
            Else
                ID = Me.dgvPartRetrospective.CurrentRow.Cells(PartRetrospective.EnumGridView.ID).Value.ToString
                strSql.Append(String.Format(" UPDATE m_PartRetrospective_t SET Qty={0},ProduceDate='{1}',SupplierName=N'{2}',LotNo='{3}',ModifyTime=GETDATE(),ModifyUserID=N'{4}'  WHERE ID='{5}'",
                                            Me.txtQty.Text, Me.txtProduceDate.Text.Trim, Me.txtSupplierName.Text.Trim, Me.txtLotNo.Text.Trim, VbCommClass.VbCommClass.UseId, ID))
            End If
            
            DbOperateUtils.ExecSQL(strSql.ToString())
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "WmsManagement.FrmPartRetrospective", "SaveData()", "sys")
        End Try

        Return result
    End Function
    '删除数据
    Private Function DeleteData() As Boolean
        Dim result As Boolean = False
        Try
            Dim strSql As New StringBuilder
            Dim ID As String = Nothing
            ID = Me.dgvPartRetrospective.CurrentRow.Cells(PartRetrospective.EnumGridView.ID).Value.ToString
            strSql.Append(String.Format(" UPDATE m_PartRetrospective_t SET Usey='N',ModifyTime=GETDATE(),ModifyUserID='{0}'  WHERE ID=N'{1}'",
               VbCommClass.VbCommClass.UseId, ID))

            DbOperateUtils.ExecSQL(strSql.ToString())
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "WmsManagement.FrmPartRetrospective", "DeleteData()", "sys")
        End Try

        Return result
    End Function

    '加载数据
    Private Sub LoadPartRetrospectiveData()

        Try
            Dim strSql As New StringBuilder()
            Dim dt As New DataTable
            strSql.Append(" SELECT top 5000 a.ID,a.PartId,a.Qty,a.SupplierName,CONVERT(nvarchar(10), a.ProduceDate,120) ProduceDate ,a.LotNo,b.UserName,a.CreateTime ")
            strSql.Append("  FROM m_PartRetrospective_t a inner join   m_Users_t  b on b.UserID=a.CreateUserID where a.Usey='Y' ")
            If Not String.IsNullOrEmpty(Me.txtPartId.Text.Trim) Then
                strSql.Append(" AND a.PartId like N'%" & Me.txtPartId.Text & "%'")
            End If
            If Not String.IsNullOrEmpty(Me.txtSupplierName.Text.Trim) Then
                strSql.Append(" AND a.SupplierName like N'%" & Me.txtSupplierName.Text & "%'")
            End If

            If Not String.IsNullOrEmpty(Me.txtLotNo.Text.Trim) Then
                strSql.Append(" AND a.LotNo like N'%" & Me.txtLotNo.Text & "%'")
            End If

            If Not String.IsNullOrEmpty(Me.txtProduceDate.Text.Trim) AndAlso Me.cbProduceDate.Checked = True Then
                strSql.Append(" AND a.ProduceDate between '" & Me.txtProduceDate.Text.Trim & " 00:00:000' and '" & Me.txtProduceDate.Text.Trim & " 23:59:000' ")
            End If
            dt = DbOperateUtils.GetDataTable(strSql.ToString)

            Me.dgvPartRetrospective.DataSource = dt
            Me.toolStripStatuslb.Text = String.Format("记录笔数:{0}", dt.Rows.Count.ToString)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "WmsManagement.FrmPartRetrospective", "SaveData()", "sys")
        End Try

    End Sub

 
    '检查料件是否存在
    Private Function checkPartIsExists(ByVal partId As String) As Boolean
        Dim result As Boolean = True
        Try
            Dim strSql As String
            Dim iCount As Int32
            strSql = String.Format(" select TAvcPart From m_PartContrast_t where UseY='Y' and TAvcPart='{0}'", partId)
            iCount = DbOperateUtils.GetRowsCount(strSql)
            If iCount > 0 Then
                Return False
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "WmsManagement.FrmPartRetrospective", "checkPartIsExists()", "sys")
        End Try
        Return result
    End Function

    '检查是否唯一
    Private Function checkIsExists() As Boolean
        Dim result As Boolean = False
        Try
            Dim strSql As New StringBuilder
            Dim iCount As Int32
       
            Dim Id As String = Nothing


            strSql.Append(String.Format("   select PartId from m_PartRetrospective_t where Usey='Y' and PartId='{0}' and Qty='{1}' and ProduceDate='{2}'   and SupplierName='{3}'",
                                   Me.txtPartId.Text.Trim, Me.txtQty.Text.Trim, Me.txtProduceDate.Text.Trim, Me.txtSupplierName.Text.Trim))
            If Me.ActiveSatus = PartRetrospective.EnumStatus.Edit Then
                Id = Me.dgvPartRetrospective.CurrentRow.Cells(PartRetrospective.EnumGridView.ID).Value.ToString
                strSql.Append(" and id<>'" & Id & "'")
            End If
            iCount = DbOperateUtils.GetRowsCount(strSql.ToString)
            If iCount > 0 Then
                Return True
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "WmsManagement.FrmPartRetrospective", "checkExists()", "sys")
        End Try
        Return result
    End Function
    ''' <summary>
    ''' 校验是否是数字
    ''' </summary>
    ''' <param name="strNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RegexNumber(ByVal strNumber As String) As Boolean
        Dim reg_Barcode As Regex = New Regex("^[0-9]*$")
        If reg_Barcode.IsMatch(strNumber) = False Then
            Return False
        Else
            Return True
        End If
    End Function
    '设置控件显示
    Sub SetControlsEnable(ByVal EnumStatus As PartRetrospective.EnumStatus)
        lblMsg.Text = ""
        Select Case EnumStatus
            Case PartRetrospective.EnumStatus.Nomal
                '控制菜单权限
                SetMenuRight()
                'Me.toolNew.Enabled = True
                'Me.toolModify.Enabled = True
                'Me.toolDelete.Enabled = True
                Me.toolSave.Enabled = False
                Me.toolUndo.Enabled = False

                For Each contr As Control In Me.Panel1.Controls
                    If (TypeOf contr Is System.Windows.Forms.TextBox) Then
                        CType(contr, System.Windows.Forms.TextBox).Enabled = False
                        CType(contr, System.Windows.Forms.TextBox).Text = ""
                    End If
                    If (TypeOf contr Is System.Windows.Forms.DateTimePicker) Then
                        CType(contr, System.Windows.Forms.DateTimePicker).Enabled = False
                        CType(contr, System.Windows.Forms.DateTimePicker).Text = ""
                    End If
                    If (TypeOf contr Is System.Windows.Forms.CheckBox) Then
                        CType(contr, System.Windows.Forms.CheckBox).Enabled = False
                        CType(contr, System.Windows.Forms.CheckBox).Checked = False
                    End If
                Next
                Me.ActiveSatus = PartRetrospective.EnumStatus.Nomal
            Case PartRetrospective.EnumStatus.Add
                Me.toolNew.Enabled = False
                Me.toolModify.Enabled = False
                Me.toolDelete.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolUndo.Enabled = True
                For Each contr As Control In Me.Panel1.Controls
                    If (TypeOf contr Is System.Windows.Forms.TextBox) Then
                        CType(contr, System.Windows.Forms.TextBox).Enabled = True
                    End If
                    If (TypeOf contr Is System.Windows.Forms.DateTimePicker) Then
                        CType(contr, System.Windows.Forms.DateTimePicker).Enabled = True
                    End If
                    If (TypeOf contr Is System.Windows.Forms.CheckBox) Then
                        CType(contr, System.Windows.Forms.CheckBox).Enabled = True
                    End If
                Next
                Me.ActiveSatus = PartRetrospective.EnumStatus.Add
            Case PartRetrospective.EnumStatus.Edit
                Me.toolNew.Enabled = False
                Me.toolModify.Enabled = False
                Me.toolDelete.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolUndo.Enabled = True
                For Each contr As Control In Me.Panel1.Controls
                    If (TypeOf contr Is System.Windows.Forms.TextBox) Then
                        CType(contr, System.Windows.Forms.TextBox).Enabled = True
                    End If
                    If (TypeOf contr Is System.Windows.Forms.DateTimePicker) Then
                        CType(contr, System.Windows.Forms.DateTimePicker).Enabled = True
                    End If
                    If (TypeOf contr Is System.Windows.Forms.CheckBox) Then
                        CType(contr, System.Windows.Forms.CheckBox).Enabled = True
                    End If
                Next
                Me.txtPartId.Enabled = False
                Me.ActiveSatus = PartRetrospective.EnumStatus.Edit
            Case PartRetrospective.EnumStatus.Query
                '控制菜单权限
                SetMenuRight()
                Me.toolSave.Enabled = False
                Me.toolUndo.Enabled = False
                For Each contr As Control In Me.Panel1.Controls
                    If (TypeOf contr Is System.Windows.Forms.TextBox) Then
                        CType(contr, System.Windows.Forms.TextBox).Enabled = True
                    End If
                    If (TypeOf contr Is System.Windows.Forms.DateTimePicker) Then
                        CType(contr, System.Windows.Forms.DateTimePicker).Enabled = True
                    End If
                    If (TypeOf contr Is System.Windows.Forms.CheckBox) Then
                        CType(contr, System.Windows.Forms.CheckBox).Enabled = True
                    End If
                Next
                Me.ActiveSatus = PartRetrospective.EnumStatus.Query
        End Select
    End Sub

    ''' <summary>
    ''' 设置菜单权限-用户权限设定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMenuRight()
        Me.toolNew.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolNew.Tag) = "YES", True, False)
        Me.toolModify.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolModify.Tag) = "YES", True, False)
        Me.toolDelete.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolDelete.Tag) = "YES", True, False)
    End Sub
#End Region








End Class