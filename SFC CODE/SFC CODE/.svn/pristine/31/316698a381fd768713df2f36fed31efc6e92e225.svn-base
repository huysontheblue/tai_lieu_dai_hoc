Imports MainFrame.SysDataHandle
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData

Public Class FrmMainTainIPQCConfirmDG

#Region "初期化"

    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmMainTainIPQCConfirmDG_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Me.DesignMode = True Then Exit Sub

        dgMainTain.AutoGenerateColumns = False
        '取得用户权限数据
        Dim dt As DataTable = MainTainCommon.GetUserRight()

        '没有权限时不可以编辑
        If dt.Rows.Count = 0 Then
            Me.toolcomfirm.Enabled = False
        Else
            Me.toolcomfirm.Enabled = True
        End If

        '加载不良现象大类
        MainTainCommon.BindComboxCodeTypeBig(CobcodeType)
        SetControl()

        GroupHandle.Enabled = False
        Me.Txtppid.Focus()
    End Sub

#End Region

#Region "事件"
    '确认
    Private Sub toolcomfirm_Click(sender As Object, e As EventArgs) Handles toolcomfirm.Click
        Dim lsSQL As String = ""
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        If Me.TxtBarcode.Text = "" Then
            Me.LblMSg.Text = "请输入要IPQC确认的产品条码序号"
            TxtBarcode.Focus()
            Exit Sub
        End If
        Try
            'P表示是否IPQC，替代现在的ISOK栏位
            lsSQL = " SELECT TOP 1 resultid from m_AssyTs_t " & _
                    " WHERE ppid='" & TxtBarcode.Text & "' AND  ISNULL(ISok,'N')='N'  ORDER BY intime DESC"

            Dim dt As DataTable = MainTainCommon.GetDbDataTable(lsSQL)

            Dim result As String = ""
            If (dt.Rows.Count = 0) Then
                Me.LblMSg.Text = "该产品条码序号未经过维修..."
                Exit Sub
            Else
                result = dt.Rows(0)("resultid").ToString
            End If
         
            If result = "E" Then
                Me.LblMSg.Text = "该产品已报废，不允许再进行IPQC确认..."
                Exit Sub
            End If

            MainTainCommon.ExecSQL(
                    " update m_AssyTs_t set ISok='Y', Stateid='P', resultid = 'P' where ppid='" & TxtBarcode.Text & "' " &
                    " update m_AssyRejects_t set ISok='Y',state='3' where ppid='" & TxtBarcode.Text & "' and ISok='N'  " &
                    " update m_SnSBarCode_t set UseY ='Y',Mark1=null,Mark2=null where SBarCode='" & TxtBarcode.Text & "'")

            Me.LblMSg.Text = "IPQC确认完成，请将维修OK的产品，回流至对应站点"
            For i As Integer = 0 To dgMainTain.Rows.Count - 1
                If dgMainTain.Rows(i).Cells("colPpid").Value = TxtBarcode.Text.Trim Then
                    dgMainTain.Rows(i).Cells("colStatus").Value = "P-IPQC已确认"
                End If
            Next

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "toolcomfirm_Click", "MES")
        End Try
    End Sub

    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '取消
    Private Sub ToolCancel_Click(sender As Object, e As EventArgs) Handles ToolCancel.Click
        '工具条

        TxtMainTainNo.Text = String.Empty
        status.Text = "A-在制良品"
        CobNGRout.Enabled = True
        CobcodeType.Enabled = True
        TxtNGdes.Enabled = True
        CobcodeType.SelectedIndex = -1
        TxtNGdes.SelectedIndex = -1
        CobNGRout.SelectedIndex = -1

        '判定不良区域
        GrpNG.Enabled = True
        LblMSg.Text = String.Empty
        SetControl()
        ClearData()

        GroupHandle.Enabled = False
        SetMainOperateClear()
    End Sub

    '条码序号
    Private Sub Txtppid_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Txtppid.KeyPress
        Try
            '通过PPID
            Dim dt As DataTable = MainTainCommon.GetMainListByPpid(Txtppid.Text.Trim)
            BindGrid(dt)
            SetDataByGrid(dt, 1)
            '设置不良工站
            MainTainCommon.BindComboxStation(CobNGRout, TxtPartid.Text)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "Txtppid_KeyPress", "MES")
        End Try
    End Sub
#End Region
 
#Region "不良现象大分类事件"
    '不良现象大分类事件
    Private Sub CobcodeType_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobcodeType.SelectedIndexChanged
        If CobcodeType.Text = "" Then Exit Sub
        '不良现象
        MainTainCommon.BindComboxNG(TxtNGdes, CobcodeType.Text.Split("-")(0).Trim)
    End Sub
#End Region

    'Grid绑定
    Private Sub BindGrid(dt As DataTable)
        Me.dgMainTain.DataSource = dt
        '有报废设置
        SetScarpGridData()
    End Sub

    '设置基本信息
    Private Sub SetDataByGrid(dt As DataTable, Type As String)
        If dgMainTain.RowCount = 0 Then Exit Sub

        Dim Stateid As String = String.Empty
        If dt.Rows.Count > 0 Then
            Stateid = dt.Rows(0)("StateStr").ToString

            '扫工单时要时可以再新加
            If Type = 1 Then
                If Stateid = "D" Or Stateid = "P" Or Stateid = "G" Or Stateid = "E" Then
                    GrpNG.Enabled = False
                End If
            Else
                GrpNG.Enabled = True
            End If
            '扫工单时要时可以再新加
            If Type = 1 Then
                status.Text = Stateid & "-" & dt.Rows(0)("Stateid").ToString
            Else
                status.Text = "A-在制良品"
            End If

            CobNGRout.Text = dt.Rows(0)("stationid").ToString
            TxtMainTainNo.Text = dt.Rows(0)("MaintainID").ToString
            TxtLineid.Text = dt.Rows(0)("Lineid").ToString
            TxtNGdes.Text = dt.Rows(0)("Codeid").ToString
            TxtNGmoid.Text = dt.Rows(0)("moid").ToString
            TxtPartid.Text = dt.Rows(0)("partid").ToString
            CobcodeType.Text = dt.Rows(0)("Codeitem").ToString & "-" & dt.Rows(0)("CsortName").ToString
            TxtNGdes.Text = dt.Rows(0)("CCName").ToString

            'If dt.Rows(0)("MaintainID").ToString <> dt.Rows(0)("Pppid").ToString Then
            '    Me.Gbarcode = dt.Rows(0)("Pppid").ToString
            'End If
        End If
    End Sub

    '设置报废信息
    Private Sub SetScarpGridData()
        Dim Ppid As String = String.Empty

        If dgMainTain.SelectedCells.Count = 0 Then
            Exit Sub
        End If

        '选择PPID
        Ppid = dgMainTain.Rows(dgMainTain.SelectedCells(0).RowIndex).Cells("colPpid").Value.ToString

        Dim dt As DataTable = MainTainCommon.GetScrapTable(Ppid)

        Me.dgvScrap.DataSource = dt
    End Sub

    '设置控件编辑性
    Private Sub SetControl()
        If ChkNoppid.Checked = True Then
            Txtppid.Enabled = False
            TxtNGmoid.Enabled = True
            chkseries.Enabled = True
            txtQtys.Enabled = True
            chkseries.Checked = True
        Else
            Txtppid.Enabled = True
            TxtNGmoid.Enabled = False
            chkseries.Enabled = False
            txtQtys.Enabled = False
        End If
    End Sub

    '清空数据
    Private Sub ClearData()
        Txtppid.Text = String.Empty
        txtQtys.Text = String.Empty
        TxtNGmoid.Text = String.Empty
        TxtPartid.Text = String.Empty
        TxtLineid.Text = String.Empty
        chkseries.Checked = False
    End Sub

    '清空维修数据
    Private Sub SetMainOperateClear()
        Me.CoblargeCode.SelectedIndex = -1
        Me.ComMidCode.SelectedIndex = -1
        Me.ComSmallCode.SelectedIndex = -1
        Me.CobRuturn.SelectedIndex = -1
        Me.Cobsmallsit.SelectedIndex = -1
        Me.CobHandle.SelectedIndex = -1
        Me.CobResult.SelectedIndex = -1
        Me.CmbTpartT.SelectedIndex = -1
        Me.cboDept.SelectedIndex = -1

        TxtIdea.Text = String.Empty
        ChkSplit.Checked = False
        chk_Clear.Checked = False
        ChkRetest.Checked = False
        Me.dgMainTain.DataSource = Nothing
        Me.dgvScrap.DataSource = Nothing
        Me.dgvScrap.Rows.Clear()
    End Sub

End Class