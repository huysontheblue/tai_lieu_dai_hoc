Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame

Public Class FrmPrintQuery

    Private g_Factory As String


#Region "退出"
    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub
#End Region

#Region "初期化"
    Private Sub FrmPrintQuery_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")

        FillComboLine(CobMo)
        FillComboLine(CobDept)
        FillComboLine(CobPart)
        FillComboLine(CobPPID)
        LoadDataToCombo(CobCus, 1)
        LoadDataToCombo(CobDept, 2)
        BindLableType()
        CobType.SelectedIndex = 0
        FillFactory(CobFactory, MainFrame.SysCheckData.SysMessageClass.UseId)
    End Sub
#End Region

    Private Sub FillComboLine(ByVal FillComBox As ComboBox)
        FillComBox.Items.Add("ALL")
        FillComBox.Text = FillComBox.Items.Item(0)
    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        DgMoData.Focus()
        If Not CheckDate(DtStar, DtEnd, Me.CobPPID.Text.Trim) Then Exit Sub
        If Not CheckCondition() Then
            MsgBox("因数据过大,请输入更多查询条件..", 48, "提示信息")
            Exit Sub
        End If
        Dim myThread As New Threading.Thread(AddressOf ShowWaitWindow)

        If CobFactory.Text <> "" Then
            g_Factory = GetFactoryCode(CobFactory.Text)
        Else
            g_Factory = "%"
        End If

        Try
            myThread.Start()
            ShowData()
            Threading.Thread.Sleep(300)
        Finally
            myThread.Abort()
        End Try
    End Sub

    Private Sub ShowData()
        Dim StartDT, EndDT As String
        Dim intQty As Integer
        'Dim strDt As String
        'Dim strLine As String
        'Dim dt As Date

        'DgMoData.Rows.Clear()
        StartDT = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
        EndDT = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")

        Dim params(9) As SqlParameter
        '开始时间
        params(0) = New SqlParameter("@begintime", SqlDbType.Char)
        params(0).Value = StartDT
        '结束时间
        params(1) = New SqlParameter("@endtime", SqlDbType.NVarChar)
        params(1).Value = EndDT

        params(2) = New SqlParameter("@sbarcode", SqlDbType.Char)
        If CobPPID.Text <> "ALL" Then
            params(2).Value = Me.CobPPID.Text
        Else
            params(2).Value = "%"
        End If

        params(3) = New SqlParameter("@factoryid", SqlDbType.Char)
        params(3).Value = g_Factory

        params(4) = New SqlParameter("@moid", SqlDbType.NChar)
        If CobMo.Text <> "ALL" Then
            params(4).Value = Me.CobMo.Text
        Else
            params(4).Value = "%"
        End If

        params(5) = New SqlParameter("@partid", SqlDbType.NChar)
        If CobPart.Text <> "ALL" Then
            params(5).Value = CobPart.Text
        Else
            params(5).Value = "%"
        End If

        params(6) = New SqlParameter("@deptid", SqlDbType.NChar)
        If CobDept.Text <> "ALL" Then
            params(6).Value = Getid(CobDept.Text)
        Else
            params(6).Value = "%"
        End If

        params(7) = New SqlParameter("@cusid", SqlDbType.NVarChar)
        If CobCus.Text <> "ALL" Then
            params(7).Value = Getid(CobCus.Text)
        Else
            params(7).Value = "%"
        End If

        params(8) = New SqlParameter("@packid", SqlDbType.NChar)
        'marked by curise 2015027
        'If CobType.Text <> "ALL" Then
        '    If CobType.Text = "产品条码" Then
        '        params(8).Value = "S"
        '    Else
        '        params(8).Value = "C"
        '    End If
        'Else
        '    params(8).Value = "%"
        'End If
        'end mark
        'add by curise 2015027 
        If Not CobType.SelectedValue Is Nothing AndAlso Not String.IsNullOrEmpty(CobType.SelectedValue.ToString) Then
            params(8).Value = CobType.SelectedValue.ToString
        Else
            params(8).Value = "%"
        End If
        params(9) = New SqlParameter("@config", SqlDbType.Char)
        If Cobconfig.Text <> "ALL" Then
            params(9).Value = Cobconfig.Text
        Else
            params(9).Value = "%"
        End If
        intQty = 0

        ''--注释change by hs ke 修改成直接绑定datatable
        Dim dts As DataTable
        Try
            '修改查询方法
            Dim strSQL As String = " m_QueryPrintRecords_p '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}'"
            strSQL = String.Format(strSQL, params(0).Value, params(1).Value, params(2).Value, params(3).Value, params(4).Value,
                                           params(5).Value, params(6).Value, params(7).Value, params(8).Value, params(9).Value)
            dts = DbOperateReportUtils.GetDataTable(strSQL)
            DgMoData.DataSource = dts
            DgMoData.Refresh()
            ToolCount.Text = DgMoData.RowCount
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        If Me.DgMoData.RowCount < 1 Then Exit Sub
        LoadDataToExcel(Me.DgMoData, Me.Text)
    End Sub

    Private Function CheckCondition() As Boolean
        If CobPPID.Text = "ALL" And CobMo.Text = "ALL" And CobPart.Text = "ALL" _
           And CobDept.Text = "ALL" And CobCus.Text = "ALL" Then 'And CobLine.Text = "ALL" 
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub CobPPID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobPart.TextChanged, CobMo.TextChanged, CobPPID.TextChanged, CobDept.TextChanged, CobCus.TextChanged
        'Me.DgMoData.Rows.Clear()
        Me.ToolCount.Text = "0"
    End Sub

    '2009-08-30 by tangxiang ----
#Region "Enter-->Tab"

    Private Sub CobCus_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobCus.KeyPress
        If e.KeyChar = Chr(13) Then
            ToolReflsh_Click(sender, e)
        End If
    End Sub

    Private Sub DtStar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtStar.KeyPress, DtEnd.KeyPress, CobPart.KeyPress, CobMo.KeyPress, CobType.KeyPress, CobPPID.KeyPress, CobFactory.KeyPress, CobDept.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

#End Region

    'add by curise for get lable type 20150323
    Private Sub BindLableType()
        CobType.Items.Clear()
        Dim sql As String = "SELECT SORTID,(SortID+'-'+SortName)SORTNAME FROM M_SORTSET_T WHERE SORTTYPE='LABELTYPE' AND USEY='Y'  UNION ALL " &
                            "SELECT SORTID,(SortID+'-'+SortName)SORTNAME FROM M_SORTSET_T WHERE SORTTYPE='LABELTYPE2' AND USEY='Y' "
        Dim sConn As SysDataBaseClass = Nothing
        Dim dt As DataTable = Nothing
        Try
            sConn = New SysDataBaseClass
            dt = sConn.GetDataTable(sql)
            dt.Rows.InsertAt(dt.NewRow, 0)
            CobType.DisplayMember = "SORTNAME"
            CobType.ValueMember = "SORTID"
            CobType.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
    End Sub

End Class