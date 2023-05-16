Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports MainFrame
Public Class FrmPackingExceptionHandle

    Private g_Factory As String
    Dim FrmShowDetail As New FrmShowDetail
    '�˳�
    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

    '���ڻ�
    Private Sub FrmPackQuery_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.DesignMode = True Then Exit Sub
        '�趨�Ñ�����
        Dim sysDB As New SysDataBaseClass
        'Ȩ�� 
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
    '���ڻ��߹�
    Private Sub FillComboLine(ByVal FillComBox As ComboBox)
        FillComBox.Items.Add("ALL")
        FillComBox.Text = FillComBox.Items.Item(0)
    End Sub

    'ˢ��
    Private Sub ToolReflesh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflesh.Click

        If (String.IsNullOrEmpty(Me.txtMOID.Text.Trim) And String.IsNullOrEmpty(Me.txtCartonID.Text.Trim()) And String.IsNullOrEmpty(Me.txtPPID.Text.Trim())) Then
            MessageUtils.ShowInformation("�������ѯ����")
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

    '��ʾ��װ��Ϣ
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

    '��ʾ��ϸ���� 
    Private Sub DgMoData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgPackingData.CellDoubleClick
        Dim strCarton, strLink As String
        If e.RowIndex = -1 Then Exit Sub
        strCarton = DgPackingData.Rows(e.RowIndex).Cells(6).Value.ToString()
        strLink = DgPackingData.Rows(e.RowIndex).Cells(2).Value.ToString()
        If (String.IsNullOrEmpty(strCarton)) Then
            MessageBox.Show("ջ��δɨ���κ�����Ͳ�Ʒ")
            Return
        End If

        If strLink = "���BPPID��Date Code" Then
            MessageUtils.ShowInformation("û����ϸ����!")
            Exit Sub
        End If


        FrmShowDetail.cartonId = strCarton
        FrmShowDetail.strLink = strLink
        FrmShowDetail.ShowDialog()
    End Sub

    '����
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

    'ɾ����
    Private Sub toolDeleteCarton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolDeleteCarton.Click
        SetMessage("")

        If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
            SetMessage("��ѡ��Ҫɾ������")
            Me.txtMOID.Focus()
            Return
        End If

        If (Me.DgPackingData.CurrentRow.Cells(6).Value Is Nothing) Then
            SetMessage("ɾ���䲻��Ϊ��")
            Me.txtMOID.Focus()
            Return
        Else
            If (String.IsNullOrEmpty(Me.DgPackingData.CurrentRow.Cells(6).Value.ToString.Trim)) Then
                SetMessage("��ѡ��Ҫɾ������")
                Me.txtMOID.Focus()
                Return
            End If
        End If

        '�������޸� ����ɾ��ԭ��
        If (String.IsNullOrEmpty(Me.txtDeReason.Text.Trim())) Then
            MessageBox.Show("����дɾ��ԭ��")
            Me.txtDeReason.Focus()
            Return
        End If

        If (MessageUtils.ShowConfirm("��ȷ��ɾ���ð�װ��¼?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
            Exit Sub
        End If

        Try
            Dim strSQL As String
            Dim strMOId As String
            Dim strCartonId As String
            Dim strPalletId As String
            Dim strHandleType As String
            'Exec_PackingExceptionHandle
            '�������޸� ����ɾ��ԭ��
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

            '�������޸� ����ɾ��ԭ��
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
                        SetMessage("ɾ���ɹ�!")
                        '�������޸� ����ɾ��ԭ��
                        txtDeReason.Text = ""
                End Select
            End If

            ToolReflesh_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub

    'ɾ��ջ��
    Private Sub toolDeletePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolDeletePallet.Click
        If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
            SetMessage("��ѡ��Ҫɾ������")
            Me.txtMOID.Focus()
            Return
        End If

        '�������޸� ����ɾ��ԭ��
        If (String.IsNullOrEmpty(Me.txtDeReason.Text.Trim)) Then
            MessageBox.Show("����дɾ��ԭ��")
            Me.txtDeReason.Focus()
            Return
        End If

        If (Me.DgPackingData.CurrentRow.Cells(5).Value Is Nothing) Then
            MessageBox.Show("���װ���޷�ִ��ջ��ɾ����")
            Me.txtMOID.Focus()
            Return
        End If

        If (String.IsNullOrEmpty(Me.DgPackingData.CurrentRow.Cells(5).Value.ToString)) Then
            MessageBox.Show("���װ���޷�ִ��ջ��ɾ����")
            Me.txtMOID.Focus()
            Return
        End If

        If (MessageUtils.ShowConfirm("��ȷ��ɾ���ð�װ��¼?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
            Exit Sub
        End If

        Try
            Dim strSQL As String
            Dim strMOId As String
            Dim strCartonId As String
            Dim strPalletId As String
            Dim strHandleType As String

            '�������޸� ����ɾ��ԭ��
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

            '�������޸� ����ɾ��ԭ��
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
                        SetMessage("ɾ���ɹ�!")
                        '�������޸� ����ɾ��ԭ��
                        Me.txtDeReason.Text = ""
                End Select
            End If

            ToolReflesh_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub

    '���ô�����Ϣ
    Private Sub SetMessage(ByVal Message As String)
        Me.lblMessage.Text = Message
    End Sub

    '����ջ������
    Private Sub toolUpdatePallet_Click(sender As Object, e As EventArgs) Handles toolUpdatePallet.Click
        SetMessage("")
        Try
            If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
                SetMessage("��ѡ����Ҫ����ջ��")
                Exit Sub
            End If

            Dim strPalletValue As String
            Dim strMoId As String

            strPalletValue = IIf(IsDBNull(Me.DgPackingData.CurrentRow.Cells(5).Value), "", Me.DgPackingData.CurrentRow.Cells(5).Value)
            strMoId = IIf(IsDBNull(Me.DgPackingData.CurrentRow.Cells(3).Value), "", Me.DgPackingData.CurrentRow.Cells(3).Value)

            If (String.IsNullOrEmpty(strPalletValue)) Then
                SetMessage("ѡ�����ջ�岻��Ϊ��")
                Me.txtMOID.Focus()
                Exit Sub
            End If

            If (String.IsNullOrEmpty(strMoId)) Then
                SetMessage("ѡ�񹤵�����Ϊ��")
                Me.txtMOID.Focus()
                Exit Sub
            End If

            Dim updatePackingQuantity As New FrmUpdatePackingQuantity(strMoId, strPalletValue, "1")
            updatePackingQuantity.ShowDialog()

        Catch ex As Exception
            SetMessage("ִ�и���ջ�������쳣")
        End Try
    End Sub

    '���ø���������
    Private Sub toolUpdateCarton_Click(sender As Object, e As EventArgs) Handles toolUpdateCarton.Click
        SetMessage("")
        Try
            If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
                SetMessage("��ѡ����Ҫ������")
                Exit Sub
            End If

            Dim strCartonValue As String
            Dim strMoId As String

            strCartonValue = IIf(IsDBNull(Me.DgPackingData.CurrentRow.Cells(6).Value), "", Me.DgPackingData.CurrentRow.Cells(6).Value)
            strMoId = IIf(IsDBNull(Me.DgPackingData.CurrentRow.Cells(3).Value), "", Me.DgPackingData.CurrentRow.Cells(3).Value)

            If (String.IsNullOrEmpty(strCartonValue)) Then
                SetMessage("ѡ������䲻��Ϊ��")
                Me.txtMOID.Focus()
                Exit Sub
            End If

            If (String.IsNullOrEmpty(strMoId)) Then
                SetMessage("ѡ�񹤵�����Ϊ��")
                Me.txtMOID.Focus()
                Exit Sub
            End If

            Dim updatePackingQuantity As New FrmUpdatePackingQuantity(strMoId, strCartonValue, "2")
            updatePackingQuantity.ShowDialog()

        Catch ex As Exception
            SetMessage("ִ�и����������쳣")
        End Try
    End Sub

    'ɾ��
    Private Sub tooldeleteHighFrequencyTest_Click(sender As Object, e As EventArgs) Handles tooldeleteHighFrequencyTest.Click
        SetMessage("")

        If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
            SetMessage("��ѡ��Ҫɾ������")
            Me.txtMOID.Focus()
            Return
        End If

        If (Me.DgPackingData.CurrentRow.Cells(6).Value Is Nothing) Then
            MessageBox.Show("���ߴ�ӡ��Ų���Ϊ�գ�")
            Me.txtMOID.Focus()
            Return
        End If

        If (String.IsNullOrEmpty(Me.DgPackingData.CurrentRow.Cells(6).Value.ToString)) Then
            MessageBox.Show("���ߴ�ӡ��Ų���Ϊ�գ�")
            Me.txtMOID.Focus()
            Return
        End If

        If (MessageUtils.ShowConfirm("��ȷ��ɾ���ø�Ƶ���ߴ�ӡ��¼?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
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
                        SetMessage("�쳣����ɹ�!")
                End Select
            End If

            ToolReflesh_Click(Nothing, Nothing)
        Catch ex As Exception
            SetMessage("ִ�и�Ƶ���ߴ�ӡPE���쳣�����쳣����ȷ����������!")
        End Try
    End Sub

    'ɾ�����(����)
    Private Sub toolDeleteCheckCarton_Click(sender As Object, e As EventArgs) Handles toolDeleteCheckCarton.Click
        If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
            SetMessage("��ѡ��Ҫɾ������")
            Me.txtMOID.Focus()
            Exit Sub
        End If

        If (MessageUtils.ShowConfirm("��ȷ��ɾ������İ�װ��������¼?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
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
                    MessageBox.Show("ɾ�������ɹ�,�����¼��!", "��ʾ��Ϣ")

                Else
                    MessageBox.Show("ɾ�����ջ��ʧ��!", "��ʾ��Ϣ")
                End If
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPackingExceptionHandle", "toolDeleteCheckCarton_Click", "sys")
        End Try
    End Sub

    'ɾ�����ջ��(����)
    Private Sub toolDeleteCheckPallet_Click(sender As Object, e As EventArgs) Handles toolDeleteCheckPallet.Click
        If (String.IsNullOrEmpty(Me.txtDeReason.Text.Trim)) Then
            MessageBox.Show("����дɾ��ԭ��")
            Me.txtDeReason.Focus()
            Exit Sub
        End If

        If (MessageUtils.ShowConfirm("��ȷ��ɾ����ջ���װ��������¼?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
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
                    MessageBox.Show("ɾ�����ջ��ɹ�,�����¼��!", "��ʾ��Ϣ")
                Else
                    MessageBox.Show("ɾ�����ջ��ʧ��!", "��ʾ��Ϣ")
                End If
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPackingExceptionHandle", "toolDeleteCheckPallet_Click", "sys")
        End Try

    End Sub

    Private Sub toolSplitCartonid_Click(sender As Object, e As EventArgs) Handles toolSplitCartonid.Click
        Dim obj As FrmSplitBox = New FrmSplitBox
        'obj.FrmTitleStr = "װ������"
        obj.ShowDialog()
    End Sub

    Private Sub toolUnDelete_Click(sender As Object, e As EventArgs) Handles toolUnDelete.Click
        If Me.DgPackingData.Rows.Count = 0 OrElse Me.DgPackingData.CurrentRow Is Nothing Then
            SetMessage("��ѡ��Ҫ�ָ�������")
            Me.txtMOID.Focus()
            Return
        End If

        ''�������޸� ����ɾ��ԭ��
        'If (String.IsNullOrEmpty(Me.txtDeReason.Text.Trim)) Then
        '    MessageBox.Show("����дɾ��ԭ��")
        '    Me.txtDeReason.Focus()
        '    Return
        'End If

        'If (Me.DgPackingData.CurrentRow.Cells(5).Value Is Nothing) Then
        '    MessageBox.Show("���װ���޷�ִ��ջ��ɾ����")
        '    Me.txtMOID.Focus()
        '    Return
        'End If

        'If (String.IsNullOrEmpty(Me.DgPackingData.CurrentRow.Cells(5).Value.ToString)) Then
        '    MessageBox.Show("���װ���޷�ִ��ջ��ɾ����")
        '    Me.txtMOID.Focus()
        '    Return
        'End If

        If (MessageUtils.ShowConfirm("��ȷ���ָ��ð�װ��¼?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
            Exit Sub
        End If

        Try
            Dim strSQL As String
            Dim strMOId As String
            Dim strCartonId As String
            Dim strPalletId As String
            Dim strHandleType As String

            '�������޸� ����ɾ��ԭ��
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
                strHandleType = "0"  '- -0.��h��,1.ջ��ɾ��
            End If


            '�������޸� ����ɾ��ԭ��
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
                        SetMessage("�ָ��ɹ�!")
                        ' Me.txtDeReason.Text = ""
                End Select
            End If

            ToolReflesh_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
End Class