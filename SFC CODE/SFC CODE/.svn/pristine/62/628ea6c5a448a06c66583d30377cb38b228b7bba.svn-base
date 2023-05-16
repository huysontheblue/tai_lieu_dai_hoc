Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports MainFrame
Public Class FrmPackingExceptionHandle

    Private g_Factory As String
    Dim FrmShowDetail As New FrmShowDetail
    '退出
    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

    '初期化
    Private Sub FrmPackQuery_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.DesignMode = True Then Exit Sub
        '设定用戶權限
        Dim sysDB As New SysDataBaseClass
        '权限 
        sysDB.GetControlright(Me)
        DgPackingData.AutoGenerateColumns = False
        toolDeleteCarton.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolDeleteCarton.Tag) = "YES", True, False))
        toolUnDelete.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolUnDelete.Tag) = "YES", True, False))
        If toolDeleteCarton.Enabled = True Then
            FrmShowDetail.ToolDeleteBarcode.Enabled = True
        Else
            FrmShowDetail.ToolDeleteBarcode.Enabled = False
        End If
        toolDeletePallet.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolDeletePallet.Tag) = "YES", True, False))
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
        FillFactory(CobFactory, MainFrame.SysCheckData.SysMessageClass.UseId)
        Me.DgPackingData.AutoGenerateColumns = False
        Me.cboQueryType.SelectedIndex = 0
        Me.txtMOID.Focus()
    End Sub
    '初期化线辊
    Private Sub FillComboLine(ByVal FillComBox As ComboBox)
        FillComBox.Items.Add("ALL")
        FillComBox.Text = FillComBox.Items.Item(0)
    End Sub

    '刷新
    Private Sub ToolReflesh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflesh.Click

        If (String.IsNullOrEmpty(Me.txtMOID.Text.Trim) And String.IsNullOrEmpty(Me.txtCartonID.Text.Trim()) And String.IsNullOrEmpty(Me.txtPPID.Text.Trim())) Then
            MessageUtils.ShowInformation("请输入查询条件")
            Me.txtMOID.Focus()
            Return
        End If

        Dim myThread As New Threading.Thread(AddressOf ShowWaitWindow)

        Try
            If CobFactory.Text <> "" Then
                g_Factory = GetFactoryCode(CobFactory.Text)
            Else
                g_Factory = ""
            End If

            DgPackingData.Focus()
            If Not CheckDate(DtStar, DtEnd) Then Return

            myThread.Start()
            ShowPackMaster()
            Threading.Thread.Sleep(300)
        Finally
            myThread.Abort()
        End Try
    End Sub

    '显示包装信息
    Private Sub ShowPackMaster()

        Dim StartDT, EndDT As String

        StartDT = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        EndDT = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")

        Dim strMoid As String = "%"
        If Not String.IsNullOrEmpty(Me.txtMOID.Text.Trim()) Then
            strMoid = Me.txtMOID.Text.Trim()
        End If

        Dim strCartonId As String = "%"
        If Not String.IsNullOrEmpty(Me.txtCartonID.Text.Trim()) Then
            strCartonId = txtCartonID.Text.Trim
        End If

        Dim ppid As String = "%"
        If Not String.IsNullOrEmpty(Me.txtPPID.Text.Trim()) Then
            ppid = txtPPID.Text.Trim
        End If

        Dim sql As String = "exec Exec_PackingExceptionQuery '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'"
        sql = String.Format(sql, StartDT, EndDT, "%", g_Factory, strMoid, "%", "%", strCartonId, ppid, "%", "%", "T", Me.cboQueryType.Text.Split("-")(0))
        Dim dts As DataTable = DbOperateUtils.GetDataTable(sql)

        DgPackingData.DataSource = dts
        DgPackingData.Refresh()

        ToolCount.Text = DgPackingData.RowCount.ToString()

    End Sub

    '显示明细资料 
    Private Sub DgMoData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPackingData.CellDoubleClick
        Dim strCarton, strLink As String
        If e.RowIndex = -1 Then Exit Sub
        strCarton = DgPackingData.Rows(e.RowIndex).Cells(6).Value.ToString()
        strLink = DgPackingData.Rows(e.RowIndex).Cells(2).Value.ToString()
        If (String.IsNullOrEmpty(strCarton)) Then
            MessageBox.Show("栈板未扫描任何中箱和产品")
            Return
        End If

        If strLink = "不連PPID和Date Code" Then
            MessageUtils.ShowInformation("没有明细资料!")
            Exit Sub
        End If


        FrmShowDetail.cartonId = strCarton
        FrmShowDetail.strLink = strLink
        FrmShowDetail.ShowDialog()
    End Sub

    '导出
    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        ExcelUtils.LoadDataToExcel(Me.DgPackingData, Me.Text)
    End Sub


    Private Sub CobFactory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobFactory.TextChanged
        'Me.DgMoData.Rows.Clear()
        Me.ToolCount.Text = "0"
    End Sub

    Public Sub ShowWaitWindow()
        Dim frmwait As New FrmWait()
        frmwait.ShowDialog()
        'Application.DoEvents()
    End Sub

    '删除箱
    Private Sub toolDeleteCarton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolDeleteCarton.Click
        SetMessage("")

        If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
            SetMessage("请选择要删除数据")
            Me.txtMOID.Focus()
            Return
        End If

        If (Me.DgPackingData.CurrentRow.Cells(6).Value Is Nothing) Then
            SetMessage("删除箱不能为空")
            Me.txtMOID.Focus()
            Return
        Else
            If (String.IsNullOrEmpty(Me.DgPackingData.CurrentRow.Cells(6).Value.ToString.Trim)) Then
                SetMessage("请选择要删除数据")
                Me.txtMOID.Focus()
                Return
            End If
        End If

        '关晓艳修改 增加删除原因
        If (String.IsNullOrEmpty(Me.txtDeReason.Text.Trim())) Then
            MessageBox.Show("请填写删除原因")
            Me.txtDeReason.Focus()
            Return
        End If

        If (MessageUtils.ShowConfirm("你确定删除该包装记录?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
            Exit Sub
        End If

        Try
            Dim strSQL As String
            Dim strMOId As String
            Dim strCartonId As String
            Dim strPalletId As String
            Dim strHandleType As String
            'Exec_PackingExceptionHandle
            '关晓艳修改 增加删除原因
            Dim deleteReason As String
            deleteReason = Me.txtDeReason.Text.ToString.Replace("'", "''")

            strMOId = Me.DgPackingData.CurrentRow.Cells(3).Value.ToString().ToUpper().Replace("'", "''")
            strCartonId = Me.DgPackingData.CurrentRow.Cells(6).Value.ToString().ToUpper().Replace("'", "''")
            If (Not Me.DgPackingData.CurrentRow.Cells(5).Value Is Nothing) Then
                strPalletId = Me.DgPackingData.CurrentRow.Cells(5).Value.ToString().ToUpper().Replace("'", "''")
            Else
                strPalletId = ""
            End If
            strHandleType = "0"

            '关晓艳修改 增加删除原因
            strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                   " EXECUTE Exec_PackingExceptionHandle @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" &
                   VbCommClass.VbCommClass.profitcenter & "'," &
                   "'" & SysMessageClass.UseId & "','" & strMOId & "','" & strCartonId & "','" & strPalletId & "','" & strHandleType.Replace("'", "''") & "',N'" &
                   deleteReason & "'" &
                   " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "

            Dim drGetSQLRecor As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If drGetSQLRecor.Rows.Count > 0 Then
                Select Case drGetSQLRecor.Rows(0)(0).ToString()
                    Case "0"
                        SetMessage(drGetSQLRecor.Rows(0)(1).ToString())
                    Case "1"
                        SetMessage("删除成功!")
                        '关晓艳修改 增加删除原因
                        txtDeReason.Text = ""
                End Select
            End If

            ToolReflesh_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub

    '删除栈板
    Private Sub toolDeletePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolDeletePallet.Click
        If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
            SetMessage("请选择要删除数据")
            Me.txtMOID.Focus()
            Return
        End If

        '关晓艳修改 增加删除原因
        If (String.IsNullOrEmpty(Me.txtDeReason.Text.Trim)) Then
            MessageBox.Show("请填写删除原因")
            Me.txtDeReason.Focus()
            Return
        End If

        If (Me.DgPackingData.CurrentRow.Cells(5).Value Is Nothing) Then
            MessageBox.Show("箱包装，无法执行栈板删除！")
            Me.txtMOID.Focus()
            Return
        End If

        If (String.IsNullOrEmpty(Me.DgPackingData.CurrentRow.Cells(5).Value.ToString)) Then
            MessageBox.Show("箱包装，无法执行栈板删除！")
            Me.txtMOID.Focus()
            Return
        End If

        If (MessageUtils.ShowConfirm("你确定删除该包装记录?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
            Exit Sub
        End If

        Try
            Dim strSQL As String
            Dim strMOId As String
            Dim strCartonId As String
            Dim strPalletId As String
            Dim strHandleType As String

            '关晓艳修改 增加删除原因
            Dim deleteReason As String
            deleteReason = txtDeReason.Text.Trim.ToString.Replace("'", "''")


            strMOId = Me.DgPackingData.CurrentRow.Cells(3).Value.ToUpper().Replace("'", "''")
            If (IsDBNull(Me.DgPackingData.CurrentRow.Cells(6).Value)) Then
                strCartonId = ""
            Else
                strCartonId = Me.DgPackingData.CurrentRow.Cells(6).Value.ToUpper().Replace("'", "''")
            End If

            strPalletId = Me.DgPackingData.CurrentRow.Cells(5).Value.ToUpper().Replace("'", "''")
            strHandleType = "1"

            '关晓艳修改 增加删除原因
            strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                    " EXECUTE Exec_PackingExceptionHandle @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" &
                    VbCommClass.VbCommClass.profitcenter & "'," &
                    "'" & SysMessageClass.UseId & "','" & strMOId & "','" & strCartonId & "','" & strPalletId & "','" & strHandleType.Replace("'", "''") & "',N'" &
                    deleteReason & "'" &
                    " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "

            Dim drGetSQLRecor As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If drGetSQLRecor.Rows.Count > 0 Then
                Select Case drGetSQLRecor.Rows(0)(0).ToString()
                    Case "0"
                        SetMessage(drGetSQLRecor.Rows(0)(1).ToString())
                    Case "1"
                        SetMessage("删除成功!")
                        '关晓艳修改 增加删除原因
                        Me.txtDeReason.Text = ""
                End Select
            End If

            ToolReflesh_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub

    '设置错误信息
    Private Sub SetMessage(ByVal Message As String)
        Me.lblMessage.Text = Message
    End Sub

    '设置栈板数量
    Private Sub toolUpdatePallet_Click(sender As Object, e As EventArgs) Handles toolUpdatePallet.Click
        SetMessage("")
        Try
            If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
                SetMessage("请选择需要调整栈板")
                Exit Sub
            End If

            Dim strPalletValue As String
            Dim strMoId As String

            strPalletValue = IIf(IsDBNull(Me.DgPackingData.CurrentRow.Cells(5).Value), "", Me.DgPackingData.CurrentRow.Cells(5).Value)
            strMoId = IIf(IsDBNull(Me.DgPackingData.CurrentRow.Cells(3).Value), "", Me.DgPackingData.CurrentRow.Cells(3).Value)

            If (String.IsNullOrEmpty(strPalletValue)) Then
                SetMessage("选择调整栈板不能为空")
                Me.txtMOID.Focus()
                Exit Sub
            End If

            If (String.IsNullOrEmpty(strMoId)) Then
                SetMessage("选择工单不能为空")
                Me.txtMOID.Focus()
                Exit Sub
            End If

            Dim updatePackingQuantity As New FrmUpdatePackingQuantity(strMoId, strPalletValue, "1")
            updatePackingQuantity.ShowDialog()

        Catch ex As Exception
            SetMessage("执行更新栈板数量异常")
        End Try
    End Sub

    '设置更新箱数量
    Private Sub toolUpdateCarton_Click(sender As Object, e As EventArgs) Handles toolUpdateCarton.Click
        SetMessage("")
        Try
            If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
                SetMessage("请选择需要调整箱")
                Exit Sub
            End If

            Dim strCartonValue As String
            Dim strMoId As String

            strCartonValue = IIf(IsDBNull(Me.DgPackingData.CurrentRow.Cells(6).Value), "", Me.DgPackingData.CurrentRow.Cells(6).Value)
            strMoId = IIf(IsDBNull(Me.DgPackingData.CurrentRow.Cells(3).Value), "", Me.DgPackingData.CurrentRow.Cells(3).Value)

            If (String.IsNullOrEmpty(strCartonValue)) Then
                SetMessage("选择调整箱不能为空")
                Me.txtMOID.Focus()
                Exit Sub
            End If

            If (String.IsNullOrEmpty(strMoId)) Then
                SetMessage("选择工单不能为空")
                Me.txtMOID.Focus()
                Exit Sub
            End If

            Dim updatePackingQuantity As New FrmUpdatePackingQuantity(strMoId, strCartonValue, "2")
            updatePackingQuantity.ShowDialog()

        Catch ex As Exception
            SetMessage("执行更新箱数量异常")
        End Try
    End Sub

    '删除
    Private Sub tooldeleteHighFrequencyTest_Click(sender As Object, e As EventArgs) Handles tooldeleteHighFrequencyTest.Click
        SetMessage("")

        If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
            SetMessage("请选择要删除数据")
            Me.txtMOID.Focus()
            Return
        End If

        If (Me.DgPackingData.CurrentRow.Cells(6).Value Is Nothing) Then
            MessageBox.Show("在线打印箱号不能为空！")
            Me.txtMOID.Focus()
            Return
        End If

        If (String.IsNullOrEmpty(Me.DgPackingData.CurrentRow.Cells(6).Value.ToString)) Then
            MessageBox.Show("在线打印箱号不能为空！")
            Me.txtMOID.Focus()
            Return
        End If

        If (MessageUtils.ShowConfirm("你确定删除该高频在线打印记录?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
            Exit Sub
        End If

        Try
            Dim strSQL As String
            Dim strMOId As String
            Dim strCartonId As String
            Dim strPalletId As String

            strMOId = Me.DgPackingData.CurrentRow.Cells(3).Value.ToUpper().Replace("'", "''")
            strCartonId = Me.DgPackingData.CurrentRow.Cells(6).Value.ToUpper().Replace("'", "''")
            strPalletId = ""

            strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                     " EXECUTE Exec_PackingHighFrequencyTestHandle @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'," & _
                     "'" & SysMessageClass.UseId & "','" & strMOId & "','" & strCartonId & "','" & strPalletId & "' " & _
                     " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "

            Dim drGetSQLRecor As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If drGetSQLRecor.Rows.Count > 0 Then
                Select Case drGetSQLRecor.Rows(0)(0).ToString()
                    Case "0"
                        SetMessage(drGetSQLRecor.Rows(0)(1).ToString())
                    Case "1"
                        SetMessage("异常处理成功!")
                End Select
            End If

            ToolReflesh_Click(Nothing, Nothing)
        Catch ex As Exception
            SetMessage("执行高频在线打印PE带异常处理异常，请确认网络连接!")
        End Try
    End Sub

    '删除检测(外箱)
    Private Sub toolDeleteCheckCarton_Click(sender As Object, e As EventArgs) Handles toolDeleteCheckCarton.Click
        If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
            SetMessage("请选择要删除数据")
            Me.txtMOID.Focus()
            Exit Sub
        End If

        If (MessageUtils.ShowConfirm("你确定删除该箱的包装附属检测记录?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
            Exit Sub
        End If


        Dim o_strSql As New StringBuilder
        Dim strMOId As String
        Dim strCartonId As String
        Dim dt As New DataTable
        Try
            strMOId = Me.DgPackingData.CurrentRow.Cells(3).Value.ToString().ToUpper().Replace("'", "''")
            strCartonId = Me.DgPackingData.CurrentRow.Cells(6).Value.ToString().ToUpper().Replace("'", "''")

            o_strSql.Append(" DECLARE @Falg INT ")
            o_strSql.Append(" EXEC m_PackingCheckExceptionHandle_P '" & strMOId & "','" & strCartonId & "',N'','0',N'','" & SysMessageClass.UseId & "',@Falg OUT ")
            o_strSql.Append(" SELECT @Falg ")
            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)(0).ToString = "1" Then
                    MessageBox.Show("删除检测箱成功,请重新检测!", "提示信息")

                Else
                    MessageBox.Show("删除检测栈板失败!", "提示信息")
                End If
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPackingExceptionHandle", "toolDeleteCheckCarton_Click", "sys")
        End Try
    End Sub

    '删除检测栈板(外箱)
    Private Sub toolDeleteCheckPallet_Click(sender As Object, e As EventArgs) Handles toolDeleteCheckPallet.Click
        If (String.IsNullOrEmpty(Me.txtDeReason.Text.Trim)) Then
            MessageBox.Show("请填写删除原因")
            Me.txtDeReason.Focus()
            Exit Sub
        End If

        If (MessageUtils.ShowConfirm("你确定删除该栈板包装附属检测记录?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
            Exit Sub
        End If
        Try
            Dim deleteReason As String
            Dim strMOId As String
            Dim strPalletId As String
            Dim o_strSql As New StringBuilder
            Dim dt As New DataTable
            deleteReason = txtDeReason.Text.Trim.ToString.Replace("'", "''")
            strMOId = Me.DgPackingData.CurrentRow.Cells(3).Value.ToUpper().Replace("'", "''")
            strPalletId = Me.DgPackingData.CurrentRow.Cells(5).Value.ToUpper().Replace("'", "''")
            o_strSql.Append(" DECLARE @Falg INT ")
            o_strSql.Append(" EXEC m_PackingCheckExceptionHandle_P '" & strMOId & "',N'','" & strPalletId & "','1',N'" & deleteReason & "','" & SysMessageClass.UseId & "',@Falg OUT ")
            o_strSql.Append(" SELECT @Falg ")
            dt = DbOperateUtils.GetDataTable(o_strSql.ToString)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)(0).ToString = "1" Then
                    MessageBox.Show("删除检测栈板成功,请重新检测!", "提示信息")
                Else
                    MessageBox.Show("删除检测栈板失败!", "提示信息")
                End If
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPackingExceptionHandle", "toolDeleteCheckPallet_Click", "sys")
        End Try

    End Sub

    Private Sub toolSplitCartonid_Click(sender As Object, e As EventArgs) Handles toolSplitCartonid.Click
        Dim obj As FrmSplitBox = New FrmSplitBox
        'obj.FrmTitleStr = "装箱数量"
        obj.ShowDialog()
    End Sub

    Private Sub toolUnDelete_Click(sender As Object, e As EventArgs) Handles toolUnDelete.Click
        If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
            SetMessage("请选择要恢复的数据")
            Me.txtMOID.Focus()
            Return
        End If

        ''关晓艳修改 增加删除原因
        'If (String.IsNullOrEmpty(Me.txtDeReason.Text.Trim)) Then
        '    MessageBox.Show("请填写删除原因")
        '    Me.txtDeReason.Focus()
        '    Return
        'End If

        'If (Me.DgPackingData.CurrentRow.Cells(5).Value Is Nothing) Then
        '    MessageBox.Show("箱包装，无法执行栈板删除！")
        '    Me.txtMOID.Focus()
        '    Return
        'End If

        'If (String.IsNullOrEmpty(Me.DgPackingData.CurrentRow.Cells(5).Value.ToString)) Then
        '    MessageBox.Show("箱包装，无法执行栈板删除！")
        '    Me.txtMOID.Focus()
        '    Return
        'End If

        If (MessageUtils.ShowConfirm("你确定恢复该包装记录?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
            Exit Sub
        End If

        Try
            Dim strSQL As String
            Dim strMOId As String
            Dim strCartonId As String
            Dim strPalletId As String
            Dim strHandleType As String

            '关晓艳修改 增加删除原因
            Dim deleteReason As String =string.Empty
            'deleteReason = txtDeReason.Text.Trim.ToString.Replace("'", "''")


            strMOId = Me.DgPackingData.CurrentRow.Cells(3).Value.ToUpper().Replace("'", "''")
            If (IsDBNull(Me.DgPackingData.CurrentRow.Cells(6).Value)) Then
                strCartonId = ""
            Else
                strCartonId = Me.DgPackingData.CurrentRow.Cells(6).Value.ToUpper().Replace("'", "''")
            End If

            If Not IsDBNull(Me.DgPackingData.CurrentRow.Cells(5).Value) Then
                strPalletId = Me.DgPackingData.CurrentRow.Cells(5).Value.ToUpper().Replace("'", "''")
                strHandleType = "1"
            Else
                strPalletId = ""
                strHandleType = "0"  '- -0.箱刪除,1.栈板删除
            End If


            '关晓艳修改 增加删除原因
            strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                    " EXECUTE Exec_PackingExceptionHandle_UnDelete @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" &
                    VbCommClass.VbCommClass.profitcenter & "'," &
                    "'" & SysMessageClass.UseId & "','" & strMOId & "','" & strCartonId & "','" & strPalletId & "','" & strHandleType.Replace("'", "''") & "',N'" &
                    deleteReason & "'" &
                    " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "

            Dim drGetSQLRecor As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If drGetSQLRecor.Rows.Count > 0 Then
                Select Case drGetSQLRecor.Rows(0)(0).ToString()
                    Case "0"
                        SetMessage(drGetSQLRecor.Rows(0)(1).ToString())
                    Case "1"
                        SetMessage("恢复成功!")
                        ' Me.txtDeReason.Text = ""
                End Select
            End If

            ToolReflesh_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
End Class