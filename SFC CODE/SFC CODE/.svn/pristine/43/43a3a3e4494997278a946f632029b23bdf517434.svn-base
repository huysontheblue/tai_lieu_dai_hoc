Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Windows.Forms

Public Class FrmMaterialBaseQty

    '变量定义
    Dim OperateFlag As EditMode '操作模式
    Public Enum EditMode
        ADD
        EDIT
        UNDO
        SEARCH
    End Enum

    Public Enum enumdgvBaseQty
        PartID
        PName
        Spec
        Qty
        SafeQty
        Location
        Remark
        UserID
        Intime
        ID
    End Enum

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            Dim strSQL As String = String.Empty
            Dim insertSql As New System.Text.StringBuilder
            Dim o_PartID As String = txtPartID.Text.Trim

            'If String.IsNullOrEmpty(cboCategory.SelectedValue.ToString) = True Then
            '    MessageUtils.ShowError("请选择工治具分类!")
            '    Exit Sub
            'End If

            If OperateFlag = EditMode.ADD Then
                'strSQL = "SELECT 1 FROM m_EquBuyList_t WHERE ApplyUserID = N'{0}' and usey='1' "
                'strSQL = String.Format(strSQL, o_ApplyUserID)

                'Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

                'If dt.Rows.Count > 0 Then
                '    MessageUtils.ShowError("工号" + o_ApplyUserID + "已存在!")
                '    Exit Sub
                'End If

                'PartID 'PName'Spec'Qty 'SafeQty'Location'Remark

                strSQL = "INSERT INTO [m_MaterialBaseQty_t] " &
                        "([PartID], PName,Spec,Qty,SafeQty, Remark, location, userid, intime, UseY) "
                insertSql.Append(strSQL)
                insertSql.Append(" VALUES(")
                insertSql.AppendFormat("N'{0}',", o_PartID)
                insertSql.AppendFormat("N'{0}',", Me.txtPName.Text.Trim)
                insertSql.AppendFormat("N'{0}',", Me.txtSpec.Text.Trim)
                insertSql.AppendFormat("N'{0}',", Me.txtBaseQty.Text.Trim)
                insertSql.AppendFormat("N'{0}',", Me.txtSafeQty.Text.Trim)
                insertSql.AppendFormat("N'{0}',", Me.txtRemark.Text.Trim)
                insertSql.AppendFormat("N'{0}',", Me.txtLocation.Text.Trim)
                insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.UseId)
                insertSql.AppendFormat("getdate(),")
                insertSql.AppendFormat("N'{0}'", "1")
                insertSql.Append(");")

                DbOperateUtils.ExecSQL(insertSql.ToString)
            ElseIf OperateFlag = EditMode.EDIT Then
                'strSQL = "UPDATE [m_EquBuyList_t] "
                'insertSql.Append(strSQL)
                'insertSql.AppendFormat("SET NAME = N'{0}' ", categoryName)
                'insertSql.AppendFormat(",Description = N'{0}'", txtDescription.Text.Trim)
                'insertSql.AppendFormat(",UserID = N'{0}'", VbCommClass.VbCommClass.UseId)
                'insertSql.AppendFormat(",InTime = getdate()")
                'insertSql.AppendFormat(",ServiceCount = '{0}'", txtUserID.Text.Trim)
                'insertSql.AppendFormat(",RemainCount = '{0}'", txtUserID.Text.Trim)
                'insertSql.AppendFormat(",FactoryName = '{0}'", VbCommClass.VbCommClass.Factory)
                'insertSql.AppendFormat(",Profitcenter = '{0}'", VbCommClass.VbCommClass.profitcenter)
                'insertSql.AppendFormat(" WHERE ApplyUserID = '{0}'", lblId.Text)

                'DbOperateUtils.ExecSQL(insertSql.ToString)
            End If

            '设置操作模式
            OperateFlag = EditMode.UNDO
            '工具栏控件状态
            SetControlStatus(EditMode.UNDO)

            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMaterialBaseQty", "toolRefresh_Click", "Equ")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub SetControlStatus(ByVal flag As EditMode)

        SetButtonEnable(False)

        Select Case UCase(flag)
            Case EditMode.ADD '新增   
                toolSave.Enabled = True
                toolUndo.Enabled = True
                SetControlEnable(True)
            Case EditMode.EDIT '修改
                toolSave.Enabled = True
                toolUndo.Enabled = True
                SetControlEnable(True)
            Case EditMode.UNDO '初始化
                toolNew.Enabled = True
                ' toolEdit.Enabled = True
                toolSearch.Enabled = True
                SetControlEnable(False)
                ClearText()
            Case EditMode.SEARCH '搜索
                toolUndo.Enabled = True
                toolRefresh.Enabled = True
                ' cboCategory.Enabled = True
                'GridList.Enabled = True
                SetControlEnable(True)
        End Select
    End Sub

    Private Sub ClearText()
        'cboCategory.SelectedValue = ""
        'txtType.Text = ""
        'txtCategoryName.Text = ""
        'txtDescription.Text = ""
        'txtServiceCount.Text = ""
        'txtAlertCount.Text = ""
    End Sub


    Private Sub SetControlEnable(bFlag As Boolean)
        'Me.txtPartNumber.Enabled = bFlag
        'Me.txtHardWareFormat.Enabled = bFlag
        'Me.txtHardWarePartNumber.Enabled = bFlag
    End Sub

    Private Sub SetButtonEnable(bFlag As Boolean)
        toolNew.Enabled = bFlag
        ' toolEdit.Enabled = bFlag
        toolSave.Enabled = bFlag
        toolUndo.Enabled = bFlag
        toolSearch.Enabled = bFlag
        toolRefresh.Enabled = bFlag
    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        Dim lsSQL As String = "", o_strID As String = ""
        If Me.dgvBaseQty.Rows.Count = 0 OrElse Me.dgvBaseQty.CurrentRow Is Nothing Then Exit Sub

        o_strID = dgvBaseQty.CurrentRow.Cells(enumdgvBaseQty.ID).Value
        Try
            lsSQL = " UPDATE m_MaterialBaseQty_t SET usey='0' " & _
                    " WHERE  ID = '" & o_strID & "'"

            DbOperateUtils.ExecSQL(lsSQL)
            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMaterialBaseQty", "toolAbandon_Click", "Equ")
        End Try
    End Sub

    Private Sub BindData()
        Dim strSql As String =
            " SELECT PartID, PName,Spec,Qty,SafeQty,Location,a.Intime, (a.UserID+'/'+b.UserName)UserID, Remark ,ID" & _
            " FROM m_MaterialBaseQty_t a " & _
            " LEFT JOIN m_Users_t b ON a.UserID = b.UserID " & _
            " WHERE 1=1 "

        Dim strWhere As New System.Text.StringBuilder

        If Not String.IsNullOrEmpty(txtPartID.Text) Then
            strWhere.AppendFormat(" AND A.PartID LIKE N'%{0}%' ", Me.txtPartID.Text.Trim)
        End If

        'If String.IsNullOrEmpty(txtDescription.Text) = False Then
        '    strWhere.AppendFormat(" and A.Description like '%{0}%' ", txtDescription.Text.Trim)
        'End If

        strWhere.Append(" AND a.usey='1'")

        strSql = strSql + strWhere.ToString

        strSql += " ORDER BY a.intime "

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

        dgvBaseQty.DataSource = dt
        Me.dgvBaseQty.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub FrmMaterialBaseQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            '设置操作模式
            OperateFlag = EditMode.UNDO
            '工具栏控件状态
            SetControlStatus(EditMode.UNDO)
            '
            BindData()
        End If
    End Sub

    Private Sub toolNew_Click(sender As Object, e As EventArgs) Handles toolNew.Click
        '设置操作模式
        OperateFlag = EditMode.ADD
        '工具栏控件状态
        SetControlStatus(EditMode.ADD)
    End Sub

    Private Sub txtSafeQty_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtSafeQty.KeyPress
        e.Handled = True
        '输入0－9和回连键时有效  
        If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = "" Then
            e.Handled = False
        End If
        '输入小数点情况  
        If e.KeyChar = "." Then
            '小数点不能在第一位  
            If txtSafeQty.Text.Length <= 0 Then
                e.Handled = True
            Else
                '小数点不在第一位  
                Dim f As Double
                If Double.TryParse(txtSafeQty.Text + e.KeyChar, f) Then
                    e.Handled = False
                End If
            End If
        End If
    End Sub

    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        ImportData()
    End Sub

    '导入
    Private Sub ImportData()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim sdfimport As New OpenFileDialog
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""

            filename = sdfimport.FileName

            '取得用户上传表数据
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 14, errorMsg)

            ChangeTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select(" PartID IS NOT NULL  ") '防止追加

            '现在开始把数据保存到DB中,先要转
            '   TableAddColumns("Creater", "System.String", dtUploadData)
            '批量插入到DB中
            '设备类型及料号要将string 转int

            Dim dics2 As New System.Collections.Generic.Dictionary(Of String, String)
            dics2.Add("PartID", "PartID")
            dics2.Add("PName", "PName")
            dics2.Add("Spec", "Spec")
            dics2.Add("Qty", "Qty")
            dics2.Add("SafeQty", "SafeQty")
            dics2.Add("Location", "Location")
            dics2.Add("Remark", "Remark")
            dics2.Add("UserID", "UserID")
            dics2.Add("Intime", "Intime")
            dics2.Add("UseY", "UseY")

            Dim usercopy As New DataTable
            usercopy = dtUploadData.Clone() '克隆表结构，copy克隆4表结构及值
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim o_Time As String = DateTime.Now.ToString
            'For Each col As DataColumn In usercopy.Columns
            '    If col.ColumnName = "StandardQuoteHour" OrElse col.ColumnName = "MatchingHour" Then
            '        col.DataType = System.Type.GetType("System.Int32")
            '    End If
            'Next
            Dim err As String = String.Empty
            Dim line As Integer = 1
            For Each row As DataRow In DrrR
                If row(0).ToString <> "" Then
                    '成品料号\品名\
                    'If row(5).ToString() <> "" AndAlso Not IsDBNull(row(5)) Then
                    '    StandardQuoteHour = CInt(row(5).ToString())
                    'End If
                    
                    If (Not IsNumeric(row(3))) Or (Not IsNumeric(row(4))) Then
                        err = "料号" + row(0).ToString() + "，对应数量栏位数据格式不正确"
                        Exit For
                    Else
                        'If CInt(row(3).ToString()) < 0 Or CInt(row(4).ToString()) Then
                        '    err = "料号" + row(0).ToString() + "，对应数量栏位不能小于0"
                        '    Exit For
                        'End If
                    End If
                    usercopy.Rows.Add(row(0).ToString(), row(1).ToString(), row(2).ToString(), _
                                      row(3).ToString(), row(4).ToString(), _
                                      row(5).ToString, row(6).ToString, _
                                      UserID, o_Time, "1")
                End If
                line = line + 1
            Next

            If err <> String.Empty Then
                MessageUtils.ShowInformation("导入失败：" + err)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Dim errMsg As String = String.Empty
            If DbOperateUtils.BulkCopy(usercopy, "m_MaterialBaseQty_t", dics2, errMsg) = True Then
                If errMsg <> String.Empty Then
                    MessageUtils.ShowInformation(errMsg)
                Else
                    MessageUtils.ShowInformation("成功导入！")
                    'LoadAsset()
                    BindData()
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "Equ.FrmMaterialBaseQty", "toolImport_Click", "Equ")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Enum ImportGrid
        PartID
        PName
        Spec
        Qty
        SafeQty
        Location
        Remark
        UserID
        Intime
        UseY
        '成品料号\品名\规格\数量\
    End Enum

    '改变TABLE列名
    Private Sub ChangeTableColumnName(ByVal dt As DataTable)
        dt.Rows.RemoveAt(0)
        For Each i As ImportGrid In [Enum].GetValues(GetType(ImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(ImportGrid), i).ToString
        Next
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolSearch_Click(sender As Object, e As EventArgs) Handles toolSearch.Click
        '设置操作模式
        OperateFlag = EditMode.SEARCH
        '工具栏控件状态
        SetControlStatus(EditMode.SEARCH)
    End Sub

    Private Sub toolRefresh_Click(sender As Object, e As EventArgs) Handles toolRefresh.Click
        Try
            BindData()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMaterialBaseQty", "toolRefresh_Click", "Equ")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub toolUndo_Click(sender As Object, e As EventArgs) Handles toolUndo.Click
        '设置操作模式
        OperateFlag = EditMode.UNDO
        '工具栏控件状态
        SetControlStatus(EditMode.UNDO)
    End Sub
End Class