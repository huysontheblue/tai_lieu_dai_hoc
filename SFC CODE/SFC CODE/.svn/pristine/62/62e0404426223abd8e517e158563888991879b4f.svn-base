#Region "Imports"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports Microsoft.Office.Interop
Imports MainFrame
Imports Aspose.Cells
Imports Aspose.Cells.Rendering
Imports System.Drawing.Imaging
Imports System.IO

#End Region

Public Class FrmMainTainHandleDGNew

#Region "定义"

    '初始化绑定默认关键词（此数据源可以从数据库取）
    'List<string> listOnit = new List<string>();
    Dim listOnit As List(Of String) = New List(Of String)
    '输入key之后，返回的关键词
    Dim listNew As List(Of String) = New List(Of String)

    Private sStaionId As String '不良工站
    '状态
    Private Enum Status
        Revover  '恢复
        Abandon  '驳回
        IPQC     'IPQC确认
        DELETE   '删除
    End Enum
    '不良维修报表导出
    Private Enum ProcessExportGrid
        Lineid
        partid
        NgDate
    End Enum
#End Region

#Region "初期化事件"
    '初期化
    Private Sub FrmMainTainHandle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me.DesignMode = True Then Exit Sub

        '设定用戶權限
        Dim sysDB As New SysDataBaseClass
        '权限 
        sysDB.GetControlright(Me)
        dgResult.AutoGenerateColumns = False
        dgQueryMain.AutoGenerateColumns = False
        '绑定下拉列表 
        BindCombox()
        '设置控件编辑性
        SetControl()
        '初始化
        tabControl_SelectedIndexChanged(Nothing, Nothing)
        SetNgJie(False)
    End Sub

    '绑定下拉列表 
    Private Sub BindCombox()
        '加载不良现象大类
        MainTainCommon.BindComboxCodeTypeBig(CobcodeType)
        MainTainCommon.BindComboxCodeTypeBig(CobcodeType2)
        MainTainCommon.BindComboxDateJie(cmbDateJie)
        SetDefaultJie()

        '查询功能
        '部门
        MainTainCommon.BindComboxClass(cboQueryClass)
        '状态
        MainTainCommon.BindComboxStatus(cboQueryStatus)
        'MainTainCommon.BindComboxStationType(cbbStationType)
    End Sub

#End Region

#Region "判定不良品作业"

    '查找工单
    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim frmMOQuery As New FrmMOQuery(Me.TxtNGmoid)
        Dim dialogResult As DialogResult = frmMOQuery.ShowDialog()
        If dialogResult = Windows.Forms.DialogResult.OK Then
            '工单选择后
            TxtNGmoidInput()
        End If
    End Sub

    '判定不良品作业
    Private Sub ToolStar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStar.Click
        If Txtppid.Text.Trim = "" Then
            If ChkIsSelfPrint.Checked = True Then
                LblMSg.Text = "条码序号不能为空..."
                Txtppid.Focus()
                Exit Sub
            Else
                LblMSg.Text = "工单编号不能为空..."
                TxtNGmoid.Focus()
                Exit Sub
            End If
        End If
        '如果有工站内容，必须选择对应的工站
        If Me.txtNgStation.Items.Count > 0 Then
            If String.IsNullOrEmpty(Me.txtNgStation.Text.Split("-")(0).ToString.Trim) Then
                LblMSg.Text = "工站编码不能为空..."
                Txtppid.Focus()
                Exit Sub
            End If
            If txtNgStation.FindString(txtNgStation.Text.Split("-")(0).ToString.Trim) = -1 Then
                LblMSg.Text = "请选择正确的工站..."
                Txtppid.Focus()
                Exit Sub
            End If
        End If

        If Me.listNgData.Items.Count = 0 Then
            LblMSg.Text = "不良现象不能为空,请增加不良现象..."
            cobNGdes.Focus()
            Exit Sub
        End If

        If IsRepairPPid() Then
            LblMSg.Text = "已报废或待确认的产品，不允许再进行不良判定..."
            Exit Sub
        End If

        '无条码序号 勾选时
        If ChkNoppid.Checked = True Then
            If CheckUtils.HalfWidthNumChecker(Me.txtQtys.Text) = False Then
                Me.LblMSg.Text = "批次不良数必须为数字..."
                Exit Sub
            End If
        End If

        '如果没有权限需要检查不良日期
        If ToolStarLast.Enabled = False Then
            '检查不良日期时间
            If CheckPPidDateIsRight() = False Then
                Exit Sub
            End If
        End If
        Dim sql = " select  * from  m_Cartonsn_t where ppid='" & Txtppid.Text & "'"
        Dim dt As DataTable
        dt = DbOperateUtils.GetDataTable(sql)
        If dt.Rows.Count > 0 Then
            Me.LblMSg.Text = "产品已经包装，请拆箱之后操作..."
            Exit Sub
        End If
      

        '生产若已回复了当日的柏拉图，生产的相关数据将无法录入系统，以免数据产生变异
        If IsLineConfirm() = False Then
            Me.LblMSg.Text = "不能再录入系统,已回复了当日的柏拉图,请确认..."
            Exit Sub
        End If

        Try

            DoSureNG()

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "ToolStar_Click", "WIP")
        End Try
    End Sub

    Private Function CheckPPidDateIsRight() As Boolean
        Dim strSQL As String = " EXEC m_CheckNgPPidDateIsRight_p '{0}','{1}','{2}' "

        strSQL = String.Format(strSQL, Txtppid.Text.Trim, Me.txtNgStation.Text.Split("-")(0).ToString.Trim, TxtNGdate.Value.ToShortDateString)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count > 0) Then
            If dt.Rows(0)(0).ToString <> "OK" Then
                Me.LblMSg.Text = dt.Rows(0)(0).ToString
                Return False
            End If
        End If
        Return True
    End Function


    ''' <summary>
    ''' 生产若已回复了当日的柏拉图，不能再录入系统,以免数据产生变异
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsLineConfirm() As Boolean
        Dim strSQL As String = "select distinct 1 from [m_AssyTsProcss_t] where PartID = '{0}' and CONVERT(VARCHAR(10),CAST(NgDate AS datetime),111) = CONVERT(VARCHAR(10),CAST('{1}' AS datetime),111) AND LINEID='{2}' "
        strSQL = String.Format(strSQL, TxtPartid.Text.Trim, TxtNGdate.Text, TxtLineid.Text)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    '设置上一节
    Private Sub btnBefore_Click(sender As Object, e As EventArgs)
        If cmbDateJie.SelectedIndex > 0 Then
            cmbDateJie.SelectedIndex = cmbDateJie.SelectedIndex - 1
        End If
    End Sub

    '当前节
    Private Sub btnCurrrentJie_Click(sender As Object, e As EventArgs)
        SetDefaultJie()
    End Sub

#Region "CheckBox 事件"

    '系统打印条码
    Private Sub ChkIsSelfPrint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkIsSelfPrint.CheckedChanged
        Txtppid.Clear()
        Txtppid.Multiline = False
        Txtppid.WordWrap = False
        SetControl()
        ClearData()
    End Sub

    '无条码作业 
    Private Sub ChkNoppid_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNoppid.CheckedChanged
        SetControl()
        ClearData()
        Txtppid.Text = String.Empty
        chkseries.Checked = True
        ToolStar.Enabled = True
        txtQtys.Text = 1
    End Sub

    '设置控件编辑性
    Private Sub SetControl()
        If ChkNoppid.Checked = True Then
            Txtppid.Enabled = False
            ' TxtNGmoid.Enabled = True
            '  btnFind.Enabled = True
            chkseries.Enabled = True
            txtQtys.Enabled = True
            chkseries.Checked = True
            TxtNGmoid.Focus()
        Else
            Txtppid.Enabled = True
            '     TxtNGmoid.Enabled = False
            'btnFind.Enabled = False
            chkseries.Enabled = False
            txtQtys.Enabled = False
            Txtppid.Focus()
        End If
    End Sub

    '清空数据
    Private Sub ClearData()
        LblMSg.Text = "提示信息"
        'Txtppid.Text = String.Empty
        txtQtys.Text = String.Empty
        TxtNGmoid.Text = String.Empty
        TxtPartid.Text = String.Empty
        TxtLineid.Text = String.Empty
        chkseries.Checked = False

        TxtMainTainNo.Text = String.Empty
        lblStatus.Text = "A-在制品"
        'CobNGRout.Enabled = True
        CobcodeType.Enabled = True
        cobNGdes.Enabled = True
        CobcodeType.SelectedIndex = -1
        cobNGdes.Text = ""
        txtNgStation.Items.Clear()
        txtNgStation.Text = String.Empty

        '勾选不良条码复选框 不良现象大分类不可用  add 关晓艳 2018/11/16
        If Me.chkScanCode.Checked Then
            Me.CobcodeType.Enabled = False
        Else
            Me.CobcodeType.Enabled = True
        End If


        '判定不良区域
        For rowIndex As Integer = 0 To dgResult.Rows.Count - 1
            dgResult.Rows.RemoveAt(0)
        Next
        For rowIndex As Integer = 0 To dgDetail.Rows.Count - 1
            dgDetail.Rows.RemoveAt(0)
        Next
    End Sub

    '设置数据初始化操作
    Private Sub SetMainOperateClear()
        'Me.CobCodeR.SelectedIndex = -1
        'Me.CobHandle.SelectedIndex = -1
        Me.CobResult.SelectedIndex = -1
        Me.cboTpartT.SelectedIndex = -1
        Me.cboDept.SelectedIndex = -1

        'TxtIdea.Text = String.Empty
        Me.dgMainTain.DataSource = Nothing
        Me.dgScrap.DataSource = Nothing
    End Sub

    Private Sub chkNgJie_CheckedChanged(sender As Object, e As EventArgs) Handles chkNgJie.CheckedChanged
        If chkNgJie.Checked = True Then
            SetNgJie(True)
        Else
            SetNgJie(False)
        End If
    End Sub

    Private Sub SetNgJie(bFlag As Boolean)
        TxtNGdate.Enabled = bFlag
        cmbDateJie.Enabled = bFlag
        btnBefore.Enabled = bFlag
        btnCurrrentJie.Enabled = bFlag
    End Sub

#End Region

    '增加不良
    Private Sub btnAddNg_Click(sender As Object, e As EventArgs) Handles btnAddNg.Click
        LblMSg.Text = "提示信息"

        If Me.cobNGdes.Text = String.Empty Then
            Me.LblMSg.Text = "不良现象必须输入..."
            Exit Sub
        End If

        For i As Integer = 0 To Me.listNgData.Items.Count - 1
            If Me.listNgData.Items(i).ID = cobNGdes.Text.Split("-")(0).ToString.Trim Then
                MessageUtils.ShowError("该不良已经在列表中！")
                Me.cobNGdes.Text = ""
                Exit Sub
            End If
        Next

        ScanNgCode()
    End Sub

    '删除不良
    Private Sub btnClearNg_Click(sender As Object, e As EventArgs) Handles btnClearNg.Click
        If Me.listNgData.SelectedIndex = -1 Then Exit Sub
        Me.listNgData.Items.RemoveAt(Me.listNgData.SelectedIndex)
    End Sub


#Region "TEXTBOX KeyPress"

    '掃描條碼load不良信息
    Private Sub Txtppid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtppid.KeyPress
        If e.KeyChar <> Chr(13) Then Exit Sub

        Try

            '如果是不良品临时条码，不带出 打印记录表的工单信息，提示让User 选择
            If chkIsNGBar.Checked = True Then
                TxtNGmoid.Focus()
                Me.LblMSg.Text = "请手动选择维修工单..."
                Exit Sub
            End If
            '扫描PPID检查
            Dim isexists As Boolean = IsCheckPPid()

            ''增加焦点 add 关晓艳 2018/11/16
            If GetNgStationId(Me.TxtNGmoid.Text, Me.Txtppid.Text) = False Then
                cobNGdes.Focus()
                'Exit Sub
            End If

            '通过PPID
            Dim dt As DataTable = MainTainCommon.GetMainListByPpid(Txtppid.Text.Trim)

            If dt.Rows.Count > 0 Then
                Me.lblStatus.Text = dt.Rows(0)("Stateid").ToString
                Me.dgResult.DataSource = dt
                If Me.lblStatus.Text <> "P-IPQC已确认" Then
                    Me.LblMSg.Text = "已经判定过不良."

                    Me.TxtMainTainNo.Text = dt.Rows(0)("MaintainID").ToString
                    sStaionId = dt.Rows(0)("stationid").ToString
                    ' Me.txtNgStation.Text = dt.Rows(0)("stationid").ToString
                    Me.CobcodeType.SelectedValue = dt.Rows(0)("Codeitem").ToString
                    Me.cobNGdes.SelectedValue = dt.Rows(0)("Codeid").ToString
                    Me.txtNgStation.Text = dt.Rows(0)("StationName").ToString
                    ToolStar.Enabled = False
                Else
                    GenMainNuber()
                End If
            Else

                '生成维修单号
                GenMainNuber()

                Me.LblMSg.Text = ""
                Me.lblStatus.Text = "A-在制品"
                Me.dgResult.DataSource = Nothing
                Me.dgDetail.DataSource = Nothing
                'Me.CobNGRout.SelectedIndex = -1
                Me.CobcodeType.SelectedIndex = -1
                Me.cobNGdes.SelectedIndex = -1

                ToolStar.Enabled = True
            End If
            If isexists Then
                cobNGdes.Focus()
            Else
                TxtNGmoid.Focus()
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "Txtppid_KeyPress", "WIP")
        End Try
    End Sub

    ''' <summary>
    ''' 判断存在条码打印表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExistsSnBarcode() As Boolean
        ExistsSnBarcode = False

        Dim o_strSql As String = String.Empty

        o_strSql = "SELECT Moid FROM dbo.m_SnSBarCode_t WHERE SBarCode='" & Txtppid.Text.Trim() & "'"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(o_strSql)

            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                ExistsSnBarcode = True
                Me.TxtNGmoid.Text = o_dt.Rows(0).Item(0)
            End If

        End Using


    End Function

    '工单编号
    Private Sub TxtNGmoid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNGmoid.KeyPress
        If e.KeyChar <> Chr(13) Then Exit Sub

        Try
            TxtNGmoidInput()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "TxtNGmoid_KeyPress", "WIP")
        End Try
    End Sub

#End Region

    '工单输入
    Private Sub TxtNGmoidInput()
        GetDataByMoid()

        '增加
        If GetNgStationId(Me.TxtNGmoid.Text, Me.Txtppid.Text) = False Then
            cobNGdes.Focus()
            'Exit Sub
        End If

        '如果该产品已经不良
        Dim dt As DataTable = MainTainCommon.GetMainListByMoidNew(TxtNGmoid.Text.Trim)
        Me.dgResult.DataSource = dt

        InitNgDetail(dgResult, dgDetail)
        '为按工单维修时
        GenMainNuber()
    End Sub

    '设置默认节次
    Private Sub SetDefaultJie()
        cmbDateJie.SelectedValue = MainTainCommon.GetCurrentSysteJie()
    End Sub

#Region "将产品判定为不良作业"

    '根据条码带出相关的信息
    Private Function IsCheckPPid() As Boolean
        Try
            Me.LblMSg.Text = "提示信息"

            Dim strSQL As String = " EXEC m_SearchNgPPidData_p '{0}','{1}','{2}'"

            strSQL = String.Format(strSQL, Me.Txtppid.Text.Trim, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            If (dt.Rows.Count = 0) Then
                ClearData()
                Me.LblMSg.Text = "该条码未经过系统作业，请手动选择工单信息"
                Me.TxtNGmoid.Focus()
                'Me.LblMSg.Text = "该条码不是由系统打印，打印记录表中不存在..."
                Return False
            End If

            MainTainCommon.BindComboxLine(TxtLineid, dt.Rows(0)("Deptid").ToString)
            TxtLineid.Text = dt.Rows(0)("lineid").ToString
            TxtNGmoid.Text = dt.Rows(0)("moid").ToString
            TxtPartid.Text = dt.Rows(0)("partid").ToString
            TxtNGmoidInput()

            Return True
        Catch ex As Exception
            LblMSg.Text = ex.Message
        End Try
        '根据条码带出相关的信息
    End Function

    Private Function IsRepairPPid() As Boolean
        Try
            Me.LblMSg.Text = "提示信息"

            Dim strSQL As String
            strSQL = " select top 1 Stateid  from m_AssyTs_t a  join m_mainmo_t b  on a.moid =b.moid " &
                     " where ppid='" & Me.Txtppid.Text & "'" & MainTainCommon.GetFatoryProfitcenter("b") & " order by Intime desc"

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                'P 维修完成
                If dt.Rows(0)("Stateid") = "P" Or dt.Rows(0)("Stateid") = "" Then
                    Return False
                Else
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            LblMSg.Text = ex.Message
        End Try
    End Function

    '根据工单和条码带出当前异常站点
    Private Function GetNgStationId(ByVal moid As String, ByVal ppid As String) As Boolean
        Dim bResult As Boolean = False
        Try
            Dim strSql As String = String.Format(" EXEC m_SearchNgStationNew_p '{0}' ,'{1}', '{2}','{3}','{4}' ",
                                                TxtPartid.Text, ppid, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, 1)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                txtNgStation.Text = ""
                Me.txtNgStation.Items.Clear()
                For cnt As Integer = 0 To dt.Rows.Count - 1
                    Me.txtNgStation.Items.Add(dt.Rows(cnt)("MesStaionid").ToString)
                Next
                If txtNgStation.Items.Count = 1 Then
                    Me.txtNgStation.SelectedIndex = 0
                Else
                    txtNgStation.SelectedIndex = -1
                End If
            End If

            strSql = String.Format(" EXEC m_SearchNgStationNew_p '{0}' ,'{1}', '{2}','{3}','{4}' ",
                                    TxtPartid.Text, ppid, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, 3)
            dt = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                Me.txtNgStation.Text = dt.Rows(0)!MesStaionid.ToString
                Me.TxtNGmoid.Text = dt.Rows(0)!moid.ToString
            End If

        Catch ex As Exception
            LblMSg.Text = ex.Message
        End Try
    End Function

    '根据工单带出相关的信息
    Private Function GetDataByMoid() As Boolean
        Try
            Me.LblMSg.Text = "提示信息"
            Dim strSQL As String = ""
            If ChkNoppid.Checked Then
                strSQL = " select  moid, PartID ,Lineid,Deptid,''stationid from m_Mainmo_t where moid='" & Me.TxtNGmoid.Text & "'" &
                                MainTainCommon.GetFatoryProfitcenter()
            Else
                strSQL = "select  a.*,c.stationid,c.stationname from (select  moid, PartID ,Lineid,Deptid from m_Mainmo_t where moid='" & Me.TxtNGmoid.Text & "'" &
                            MainTainCommon.GetFatoryProfitcenter() & " ) a left join V_m_RPartStationD_t b on a.PartID=b.PPartid  " &
                            "join m_Rstation_t c on b.stationid=c.stationid  where b.State=1 order by C.STATIONID,b.StaOrderid"
            End If

            Dim ds As DataSet = DbOperateUtils.GetDataSet(strSQL)
            Dim dt As DataTable = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                Me.LblMSg.Text = "该工单不存在，请重新输入..."
                Return False
            Else
                MainTainCommon.BindComboxLine(TxtLineid, dt.Rows(0)("Deptid").ToString)
                TxtLineid.Text = dt.Rows(0)("lineid").ToString
                TxtPartid.Text = dt.Rows(0)("partid").ToString

                If ChkNoppid.Checked = True Then
                    Txtppid.Text = MainTainCommon.GetPPID(TxtNGmoid.Text)
                End If
            End If

            Return True
        Catch ex As Exception
            LblMSg.Text = ex.Message
        End Try
    End Function

    '自动生成单据编号
    Private Sub GenMainNuber()
        Dim Sqlstr As String = "select dbo.GetMainTainID('MAI',getdate()) as Outwhid"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
        If dt.Rows.Count = 0 Then
            LblMSg.Text = "系统在自动生成维修单号时,发生错误..."
        Else
            TxtMainTainNo.Text = dt.Rows(0)(0).ToString
        End If
    End Sub

    '判定不良
    Private Sub DoSureNG()

        If ChkIsSelfPrint.Checked Then
            lblPPid.Text = String.Format("产品【{0}】，已判为不良品，请进行维修...", Txtppid.Text)
        Else
            lblPPid.Text = String.Format("工单【{0}】，已判{1}个为不良品，请进行维修...", TxtNGmoid.Text, txtQtys.Text)
        End If

        Try
            Dim sqlstr As StringBuilder = New StringBuilder
            Dim ItemID As Integer = MainTainCommon.GetAssyTsItemId(Me.Txtppid.Text.Trim)
            Dim NgDate As String = ""
            '*************************************************
            If chkNgJie.Checked = True Then
                Dim ngAlertTime As String = MainTainCommon.GetNgAlertTime(cmbDateJie.SelectedValue.ToString)

                NgDate = "'" + TxtNGdate.Value.Date + " " + ngAlertTime + "'"
            Else
                Dim ngAlertTime As String = MainTainCommon.GetNgAlertTime(cmbDateJie.SelectedValue.ToString)

                NgDate = "GETDATE()"
            End If

            '*************************************************

            Dim qtys As Integer = 1
            If ChkNoppid.Checked Then
                qtys = txtQtys.Text
            End If

            sqlstr.Append(" update m_SnSBarCode_t set usey='D' where SBarCode='" & Me.Txtppid.Text & "'")

            '生成新的维修ID,防止重复
            sqlstr.Append(vbNewLine & " declare @MaintainID varchar(50) ")
            sqlstr.Append(vbNewLine & " select  @MaintainID = dbo.GetMainTainID('MAI',getdate()) ")
            'add by hgd 2018-03-07 加入实际扫描工站
            sqlstr.Append(" insert into m_AssyTs_t(MaintainID,moid,Lineid,NgDate,ppid,Pppid,Itemid,Stationid,SmallSit,partid,Codeitem,Codeid,Stateid,IsNew,NgQty,Userid,Intime,NgStationId)values" & _
            " (@MaintainID,'" & TxtNGmoid.Text & "','" & TxtLineid.Text & "', " & NgDate & " ,'" & Txtppid.Text & "','" & Txtppid.Text & "'" & _
            "," & ItemID & ",'" & sStaionId.ToUpper & "','" & sStaionId.ToUpper & "','" & TxtPartid.Text & "','" &
            CobcodeType.Text.Split("-")(0).ToString.ToUpper & "','" & Me.cobNGdes.Text.Split("-")(0).ToString.ToUpper & "','D','Y'," &
            qtys & ",'" & SysMessageClass.UseId & "',GETDATE(),'" & Me.txtNgStation.Text.Split("-")(0).ToString.Trim & "' ) ")

            'Dim dtStationList As DataTable = MainTainCommon.GetNgStationByBigCategory(cobNGdes.Text.Split("-")(0).ToUpper)

            Dim strCodeItem As String = ""
            Dim strNgCode As String = ""
            Dim staionid As String = ""
            For i As Integer = 0 To Me.listNgData.Items.Count - 1
                strNgCode = listNgData.Items(i).Name.ToString().Split("-")(0).ToString.Trim
                strCodeItem = listNgData.Items(i).Tag.ToString().Split("-")(0).ToString.Trim
                staionid = listNgData.Items(i).StationId.Trim

                sqlstr.Append(" insert into m_AssyTsDetail_t(Ppid ,Itemid ,MaintainID ,Codeitem ,Codeid ,Stateid ,Stationid,Userid ,Intime)values" &
                "('" & Txtppid.Text & "'," & ItemID & ",@MaintainID,'" & strCodeItem &
                "','" & strNgCode & "','D','" & staionid.ToUpper & "','" & SysMessageClass.UseId & "',GETDATE())")
            Next

            '不良品修改INPUT表状态
            sqlstr.AppendFormat(SetDinputSQL(Txtppid.Text, "D", txtNgStation.Text.Split("-")(0).ToString.Trim))

            DbOperateUtils.ExecSQL(sqlstr.ToString)

            '**************************维修完成后处理**********************************************
            'If chkSaveMoid.Checked = False Then
            '    ClearData()
            'End If
            MessageUtils.ShowInformation(lblPPid.Text + System.Environment.NewLine + "请确认工单或者不良站点是否更换！")

            LblMSg.Text = lblPPid.Text
            txtQtys.Text = "1" ' 设置默认值为1
            cobNGdes.Text = ""
            cobNGdes.Focus()
            cobNGdes.SelectAll()
            '更新GRID
            TxtNGmoidInput()
            '**************************维修完成后处理**********************************************

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

    '扫描不良代码回车事件 add 关晓艳 2018/11/16
    Private Sub cobNGdes_KeyDown(sender As Object, e As KeyEventArgs) Handles cobNGdes.KeyDown
        Me.LblMSg.Text = "提示信息"
        If e.KeyValue = 13 Then
            ScanNgCode()
        End If
    End Sub

    '扫描不良代码复选框 add 关晓艳 2018/11/16
    Private Sub chkScanCode_CheckedChanged(sender As Object, e As EventArgs)
        If Me.chkScanCode.Checked Then
            Me.CobcodeType.Enabled = False
        Else
            Me.CobcodeType.Enabled = True
        End If
    End Sub

    ' 扫描不良现象代码后 自动带出不良大类 add 关晓艳 2018/11/16
    Private Sub ScanNgCode()
        Try
            'If Me.lblStatus.Text.Split("-")(0).ToString <> "" And Me.lblStatus.Text.Split("-")(0).ToString <> "A" Then
            '    Return
            'End If

            If cobNGdes.Text = "" Then Exit Sub
            Dim code As String = cobNGdes.Text.Trim
            If InStr(1, code, "-") > 0 Then
                code = code.Split("-")(0).Trim
            End If
            If TxtNGmoid.Text = "" Then
                Me.LblMSg.Text = "请选择工单"
                TxtNGmoid.Focus()
                Return
            End If
            If txtNgStation.Text.Split("-").Length = 0 And txtNgStation.Text.Split("-")(0).Trim = "" Then
                Me.LblMSg.Text = "请选择NG工站"
                txtNgStation.Focus()
                Return
            End If
            Dim strSQL As String = String.Format("select (CodeID+ '-' +CCName) Text from m_Code_t where CodeID ='{0}' and usey='Y' ", code)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            If dt.Rows.Count = 0 Then
                Me.CobcodeType.Text = ""
                Me.cobNGdes.Text = ""
                Me.LblMSg.Text = "扫描不良现象代码不存在"
                Return
            End If
            Me.cobNGdes.Text = dt.Rows(0)(0).ToString

            Dim strSQL2 As String = String.Format("select Ttext from m_Logtree_t where Ttext= " &
                " (select (EsortName+'-'+CsortName) Ttest from m_Code_t  where CodeID ='{0}' and usey='Y') " &
                " and tkey in (SELECT Tkey FROM m_UserRight_t WHERE UserID='{1}' and Tkey like 'm20007_%' and " &
                " Tkey <>'m20007_') ", code, SysMessageClass.UseId)
            Dim dt2 As DataTable = DbOperateUtils.GetDataTable(strSQL2)
            'If dt2.Rows.Count = 0 Then
            '    Me.CobcodeType.Text = ""
            '    Me.cobNGdes.Text = ""
            '    Me.LblMSg.Text = "没有此不良现象大分类的权限"
            '    Return
            'End If
            Me.CobcodeType.Text = cobNGdes.Text
            Me.cobNGdes.Text = dt.Rows(0)(0).ToString

            sStaionId = MainTainCommon.GetNgStationByBigCategory(cobNGdes.Text.Split("-")(0).ToUpper)
            If sStaionId = "" Then
                Me.LblMSg.Text = "不良现象大分类对应的不良工站没有设置，请确认..."
                Exit Sub
            End If

            Me.listNgData.Items.Add(New ListItem(Me.cobNGdes.Text.Split("-")(0).ToString.Trim,
                                                cobNGdes.Text.Trim,
                                                CobcodeType.Text.Split("-")(0).ToString.Trim,
                                                sStaionId))

            Me.cobNGdes.Text = ""
            Me.ActiveControl = Me.cobNGdes

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "ScanNgCode", "WIP")
        End Try
    End Sub

#End Region

#Region "不良品维修作业"

    '工单查找
    Private Sub btnFind2_Click(sender As Object, e As EventArgs) Handles btnFind2.Click
        Dim frmMOQuery As New FrmMOQuery(Me.TxtNGmoid2)
        Dim dialogResult As DialogResult = frmMOQuery.ShowDialog()
        If dialogResult = Windows.Forms.DialogResult.OK Then
            '取得不良品数据
            GetNgProductData()
        End If

    End Sub
    Private Sub cbReStationId_CheckedChanged(sender As Object, e As EventArgs) Handles cbReStationId.CheckedChanged
        If cbReStationId.Checked Then
            cbbReStationId.Enabled = True
        Else
            cbbReStationId.Enabled = False
        End If
    End Sub


#Region "TEXTBOX KeyPress"

    '掃描條碼load不良信息
    Private Sub Txtppid2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtppid2.KeyPress
        If e.KeyChar <> Chr(13) Then Exit Sub
        '取得不良品数据
        GetNgProductData()
    End Sub

    '工单编号
    Private Sub TxtNGmoid2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNGmoid2.KeyPress
        If e.KeyChar <> Chr(13) Then Exit Sub
        '取得不良品数据
        GetNgProductData()
    End Sub

    '取得不良品数据
    Private Sub GetNgProductData()
        Dim strMsg As String = String.Empty
        LblMSg2.Text = "提示信息"

        Dim dt As DataTable
        If ChkIsSelfPrint2.Checked = True Then
            '通过PPID
            If Txtppid2.Text = "" Then
                Exit Sub
            End If

            dt = MainTainCommon.GetMainListByPpidNew(Txtppid2.Text.Trim, "repair")
            strMsg = String.Format("条码序号【{0}】,", Txtppid2.Text.Trim)
        Else
            dt = MainTainCommon.GetMainListByMoidNew(TxtNGmoid2.Text.Trim, "repair")
            strMsg = String.Format("工单【{0}】", TxtNGmoid2.Text.Trim)
        End If

        If dt.Rows.Count = 0 Then
            InitNGOperate()
            LblMSg2.Text = strMsg + "没有判过不良品数据，请确认！"
        Else
            BindGrid2(dt)
            If dt.Rows.Count > 0 Then
                SetDataByGrid(0, 0)
            End If
        End If

    End Sub

    '设置数据
    Private Sub SetDataByGrid(rowIndex As Integer, rowIndexDetail As Integer)
        If dgMainTain.RowCount = 0 Then Exit Sub

        Dim dgRow As DataGridViewRow
        dgRow = dgMainTain.Rows(rowIndex)
        Dim Stateid As String = String.Empty
        If dgRow IsNot Nothing Then
            '扫工单时要时可以再新加
            lblStatus2.Text = dgRow.Cells("colStateid").Value.ToString
            Txtppid2.Text = dgRow.Cells("colPpid").Value.ToString
            CobNGRout2.Text = dgRow.Cells("colstationname").Value.ToString
            TxtMainTainNo2.Text = dgRow.Cells("colMaintainID").Value.ToString
            TxtLineid2.Text = dgRow.Cells("colLineid").Value.ToString
            TxtNGmoid2.Text = dgRow.Cells("colmoid").Value.ToString
            TxtPartid2.Text = dgRow.Cells("colpartid").Value.ToString

            TxtNGdate2.Value = dgRow.Cells("colNgDate").Value.ToString

            Me.TxtNgStation2.Text = dgRow.Cells("colstationname").Value.ToString
            If dgRow.Cells("colStateid").Value.ToString.Contains("D") Or dgRow.Cells("colStateid").Value.ToString.Contains("B") Then
                '不良数量 
                txtQtys2.Text = dgRow.Cells("colMainNgQtys").Value.ToString
                txtRepairQtys.Text = txtQtys2.Text
            Else
                txtQtys2.Text = ""
                '维修数量
                txtRepairQtys.Text = dgRow.Cells("colMainNgQtys").Value.ToString
            End If

            If txtQtys2.Text <> "" Then
                If (CInt(txtQtys2.Text) > 1) Then
                    chkseries2.Checked = True
                End If
            End If

            If dgRow.Cells("colStateid").Value.ToString.Contains("E") Then
                '维修结果
                CobResult.SelectedIndex = 0
            Else
                CobResult.SelectedIndex = 1
            End If

            Dim dgRowDetail As DataGridViewRow = dgDetail2.Rows(rowIndexDetail)

            CobcodeType2.Text = dgRowDetail.Cells("colCodeitem2").Value.ToString
            cobNGdes2.Text = dgRowDetail.Cells("colCCName2").Value.ToString

        End If
    End Sub

#End Region

    '开始维修改作业
    Private Sub ToolRepair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRepair.Click
        If Txtppid2.Text.Trim = "" Then
            If ChkIsSelfPrint2.Checked Then
                LblMSg2.Text = "请输入产品条码"
                Exit Sub
            Else
                LblMSg2.Text = "请输入工单编号"
                Exit Sub
            End If
        End If

        If dgMainTain.Rows.Count = 0 Then
            LblMSg2.Text = "请先查出不良品数据！"
            Exit Sub
        End If

        If IsCheckReairData("colStateid") = False Then
            LblMSg2.Text = "请选择状态为[D-不良品待维修]数据！"
            Exit Sub
        End If

        ToolFinish.Enabled = True
        ToolCancel.Enabled = True

        '系统打印条码 维修数量不可以修改
        If ChkIsSelfPrint2.Checked = True Then
            txtRepairQtys.Enabled = False
        Else
            txtRepairQtys.Enabled = True
        End If

        Me.lblItemId.Text = dgMainTain.Rows(dgMainTain.SelectedCells(0).RowIndex).Cells("colItemId").Value.ToString
        '维修数量默认为1
        txtRepairQtys.Text = "1"
     
        CobResult.DropDownStyle = ComboBoxStyle.DropDownList


        groupBoxRepair.Enabled = True
        ToolRepair.Enabled = False
        dgMainTain.Enabled = False
        InformId()
    End Sub

    '维修数据判断
    Private Function IsCheckReairData(colName As String) As Boolean
        Dim rowIndex As Integer = dgMainTain.SelectedCells(0).RowIndex

        Dim state As String = dgMainTain.Rows(rowIndex).Cells(colName).Value.ToString.Split("-")(0)

        If (state = "D" Or state = "B") Then
            Return True
        Else
            Return False
        End If
    End Function

    '维修完成
    Private Sub ToolFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolFinish.Click
        Dim moid As String = TxtNGmoid2.Text.Trim
        If CheckDataIsRight() = False Then Exit Sub

        Dim IsSplit As Char = "0"
        Dim Result As String = IIf(Me.CobResult.SelectedIndex = 0, "E", "G")
        '增加部分维修回流 DJ
        If Me.CobResult.SelectedIndex = 2 Then
            Result = "R"
        End If

        Dim strResult As String = ""

        Try

            DbOperateUtils.ExecSQL(GenScanMainSql(Result, IsSplit))

            If CInt(Me.txtRepairQtys.Text) < CInt(Me.txtQtys2.Text) Then
                ToolCancel_Click(Nothing, Nothing)
                If MessageUtils.ShowConfirm("你确定继续该工单维修吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
                InitMoidMsg(moid)
            Else
                '初始化操作
                InitNGOperate()

                If IsFinishMoid(moid) = True Then
                    LblMSg2.Text = "維修完成..."
                Else
                    InitMoidMsg(moid)
                End If

            End If
        Catch ex As Exception
            LblMSg2.Text = ex.Message & "维修时发生错误..."
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "ToolFinish_Click", "WIP")
        End Try
    End Sub

    Private Sub InitMoidMsg(moid As String)
        Dim rowSelectIndex As Integer
        Dim strPpid As String = Txtppid2.Text
        Dim strItemId As String = lblItemId.Text

        '继续维修该工单
        TxtNGmoid2.Text = moid
        '取得不良品数据
        GetNgProductData()
        '选择对应不良数据
        For rowIndex As Integer = 0 To dgMainTain.RowCount - 1
            dgMainTain.Rows(rowIndex).Cells(0).Selected = False
            If dgMainTain.Rows(rowIndex).Cells("colPpid").Value.ToString = strPpid AndAlso
                dgMainTain.Rows(rowIndex).Cells("colItemId").Value.ToString = strItemId Then
                dgMainTain.Rows(rowIndex).Cells(0).Selected = True
                rowSelectIndex = rowIndex
                Exit For
            End If
        Next
        '设置第一行第一列选择
        If Me.dgMainTain.RowCount > 0 Then
            dgMainTain.Rows(0).Cells(0).Selected = True
        End If

        SetDataByGrid(rowSelectIndex, 0)
        SetScarpGridData(strPpid, strItemId)
    End Sub

    Private Function IsFinishByPpid()
        Dim strSQL As String = "select 1 from m_AssyTsDetail_t where (Stateid = 'D' or Stateid = 'B') and Ppid='{0}' and Itemid = '{1}' "
        strSQL = String.Format(strSQL, Txtppid2.Text, lblItemId.Text)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count = 0) Then
            Return True
        End If
        Return False
    End Function

    Private Function IsFinishMoid(moid As String)
        Dim strSQL As String = "select 1 from m_AssyTs_t where moid = '{0}' and (Stateid = 'D' or Stateid = 'B') "
        strSQL = String.Format(strSQL, moid)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count = 0) Then
            Return True
        End If
        Return False
    End Function

    '取消
    Private Sub ToolCancel_Click(sender As Object, e As EventArgs) Handles ToolCancel.Click
        InitNGOperate()
    End Sub

    '初始化NG操作
    Private Sub InitNGOperate()
        ToolCancel.Enabled = False
        ToolFinish.Enabled = False

        CobResult.DropDownStyle = ComboBoxStyle.DropDown
        groupBoxRepair.Enabled = False
        groupBoxScarp.Enabled = False
        groupBoxNg.Enabled = True
        ToolRepair.Enabled = True
        'cobNGdes.Enabled = False
        dgMainTain.Enabled = True
        SetControl2()
        ClearData2()
    End Sub

    Private Sub ChkIsSelfPrint2_CheckedChanged(sender As Object, e As EventArgs) Handles ChkIsSelfPrint2.CheckedChanged
        InitNGOperate()
    End Sub

    Private Sub ChkNoppid2_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNoppid2.CheckedChanged
        InitNGOperate()
    End Sub


    '设置控件编辑性
    Private Sub SetControl2()
        If ChkNoppid2.Checked = True Then
            Txtppid2.Enabled = False
            TxtNGmoid2.Enabled = True
            TxtNGmoid2.Focus()
        Else
            Txtppid2.Enabled = True
            TxtNGmoid2.Enabled = False
            Txtppid2.Focus()
        End If
    End Sub

    Private Sub ClearData2()
        LblMSg2.Text = "提示信息"

        Txtppid2.Text = String.Empty
        txtQtys2.Text = String.Empty
        TxtNGmoid2.Text = String.Empty
        TxtPartid2.Text = String.Empty
        TxtLineid2.Text = String.Empty
        TxtNgStation2.Text = String.Empty
        chkseries2.Checked = False
        cbReStationId.Checked = False
        TxtMainTainNo2.Text = String.Empty
        lblStatus2.Text = String.Empty
        CobNGRout2.Text = String.Empty
        CobcodeType2.Text = String.Empty
        cobNGdes2.Text = String.Empty
  
        CobResult.SelectedIndex = -1
        txtRepairQtys.Text = 1

        cboTpartT.SelectedIndex = -1
        cboDept.SelectedIndex = -1

        cbbReStationId.SelectedIndex = -1
        cbbReStationId.Enabled = True
        cbReStationId.Enabled = True
        txtQty.Text = 1
        For rowIndex As Integer = 0 To ListScrap.Items.Count - 1
            ListScrap.Items.RemoveAt(0)
        Next
        For rowIndex As Integer = 0 To dgMainTain.Rows.Count - 1
            dgMainTain.Rows.RemoveAt(0)
        Next
        For rowIndex As Integer = 0 To dgDetail2.Rows.Count - 1
            dgDetail2.Rows.RemoveAt(0)
        Next
        For rowIndex As Integer = 0 To dgScrap.Rows.Count - 1
            dgScrap.Rows.RemoveAt(0)
        Next
    End Sub


#Region "不良品维修作业中按钮事件"
    '新增
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        LblMSg2.Text = "提示信息"

        If Me.cboTpartT.Text = String.Empty Then
            Me.LblMSg2.Text = "报废部件必须输入..."
            Exit Sub
        End If

        If CheckUtils.HalfWidthNumChecker(Me.txtQty.Text) = False Then
            Me.LblMSg2.Text = "报废数量必须为数字..."
            Exit Sub
        End If
        For i As Integer = 0 To Me.ListScrap.Items.Count - 1
            If Me.ListScrap.Items(i).ID = Me.cboTpartT.SelectedValue.ToString Then
                MessageUtils.ShowError("该料件已经在列表中或已經選為部件料號！")
                Me.cboTpartT.Text = ""
                Exit Sub
            End If
        Next

        Me.ListScrap.Items.Add(New ListItem(Me.cboTpartT.SelectedValue, Me.cboTpartT.Text.Trim + String.Format("(:数量{0})", txtQty.Text)))
        Me.cboTpartT.Text = ""
        Me.ActiveControl = Me.cboTpartT
    End Sub
    '删除
    Private Sub btnClearpart_Click(sender As Object, e As EventArgs) Handles btnClearpart.Click
        If Me.ListScrap.SelectedIndex = -1 Then Exit Sub
        Me.ListScrap.Items.RemoveAt(Me.ListScrap.SelectedIndex)
    End Sub
#End Region

    '加載大分類類型
    Public Sub InformId()
        'Dim Rcode As String = ""
        'If InStr(cobNGdes2.Text, "-") > 0 Then
        '    Rcode = cobNGdes2.Text.Split("-")(0).Trim
        'Else
        '    Rcode = cobNGdes2.Text
        'End If
    
        '部门
        MainTainCommon.BindComboxClass(cboDept)
        '报废部件
        MainTainCommon.BindComboxTavcPart(cboTpartT, TxtPartid2.Text.Trim)
        '加载返回工站
        MainTainCommon.BindComboxStationId(cbbReStationId, Txtppid2.Text)

        'add by hgd 20180510 检查料件工艺流程中是否设定了返回工站，如果设定则默认设置的工站，且不可编辑此项
        Dim ngBackStation As String
        ngBackStation = GetNgBackStationId()
        If Not String.IsNullOrEmpty(ngBackStation) Then
            cbbReStationId.SelectedValue = ngBackStation
            cbbReStationId.Text = ngBackStation
            cbbReStationId.Enabled = False

            cbReStationId.Checked = True
            cbReStationId.Enabled = False
        End If

    End Sub

    '檢驗保存數據是否正確
    Private Function CheckDataIsRight() As Boolean
        'If InStr(CobHandle.Text, "报废") > 0 And CobResult.SelectedIndex <> 0 Then
        '    Me.CobResult.Focus()
        '    Me.LblMSg2.Text = "当前产品不允许选择维修OK，只允许作废处理..."
        '    Return False
        'End If
        Dim Ppid As String = dgMainTain.Rows(dgMainTain.SelectedCells(0).RowIndex).Cells("colPpid").Value.ToString
        Dim itemId As String = dgMainTain.Rows(dgMainTain.SelectedCells(0).RowIndex).Cells("colItemId").Value.ToString

        Dim strSQL As String = " SELECT ppid FROM m_AssyTsDetail_t WHERE ppid = '{0}' AND itemid = '{1}' AND isnull(Rcodeid,'')= ''" &
                               " SELECT Stateid FROM m_AssyTsDetail_t WHERE ppid = '{0}' AND itemid = '{1}' AND isnull(Stateid,'')= 'E'"
        strSQL = String.Format(strSQL, Ppid, itemId)
        Dim ds As DataSet = DbOperateUtils.GetDataSet(strSQL)

        If ds.Tables(0).Rows.Count > 0 Then
            Me.btnOpenWindow.Focus()
            Me.LblMSg2.Text = "请选择还未维修完成的数据,继续维修..."
            Return False
        End If

        '产品子件中有作报废处理的
        If ds.Tables(1).Rows.Count > 0 And CobResult.SelectedIndex <> 0 Then
            Me.CobResult.Focus()
            Me.LblMSg2.Text = "当前产品不允许选择维修OK，只允许作废处理..."
            Return False
        End If

        If Me.CobResult.Text = "" Then
            Me.CobResult.Focus()
            Me.LblMSg2.Text = "維修結果不能為空..."
            Return False
        End If

        If cbReStationId.Checked = True AndAlso cbbReStationId.Text = "" Then
            Me.cbbReStationId.Focus()
            Me.LblMSg2.Text = "请选择返回工站..."
            Return False
        End If

        If CheckUtils.HalfWidthNumChecker(Me.txtRepairQtys.Text) = False Then
            Me.txtRepairQtys.Focus()
            Me.LblMSg2.Text = "维修数量必须为数字..."
            Return False
        End If

        If CInt(Me.txtRepairQtys.Text) > CInt(Me.txtQtys2.Text) Then
            Me.txtRepairQtys.Focus()
            Me.LblMSg2.Enabled = True
            Me.LblMSg2.Text = "[维修数量]必须小于[不良品数量]..."
            Return False
        End If

        Return True
    End Function

    '获取返回工站
    Private Function GetNgBackStationId() As String
        Try
            Dim ngBackStationid As String = String.Empty
            Dim strSql As String
            strSql = "select NgBackStationId from m_RPartStationD_t where PPartid='" & Me.TxtPartid2.Text &
                "' and Stationid='" & TxtNgStation2.Text & "' and State='1' AND isnull(NgBackStationId,'') <>'' "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                ngBackStationid = dt.Rows(0)!NgBackStationId.ToString
            End If

            Return ngBackStationid
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '已扫描的产品的维修
    Private Function GenScanMainSql(ByVal Result As String, ByVal IsSplit As String) As String
        Try
            '连接串
            Dim SqlStr As New StringBuilder
            Dim ReStationId As String = ""
            Dim qtys As Integer = 1
            If ChkNoppid2.Checked Then
                qtys = txtRepairQtys.Text
            End If
            If cbbReStationId.Text <> "" Then
                If Not IsNothing(cbbReStationId.SelectedValue) Then
                    ReStationId = cbbReStationId.SelectedValue.ToString
                Else
                    ReStationId = cbbReStationId.Text.Trim
                End If
            End If

            '为报废,当前站记录不清除
            '为空时，设置默认当前站
            If ReStationId = "" And Result <> "E" Then
                ReStationId = TxtNgStation2.Text.Split("-")(0).ToString
            End If

            '发生不良站点
            Dim ItemID As Integer = MainTainCommon.GetAssyTsItemId(Me.Txtppid2.Text)

            Dim strSQL As String = ""
            Dim strSQLD As String = ""
            Dim sState As String = Result
            'Dim oldStates As String = lblStatus2.Text.Split("-")(0).Trim

            '部分回流 Stateid=G IPQC确认
            If Result = "R" Then
                sState = "G"
            End If

            If Result = "E" Then
                strSQL = String.Format(" update m_AssyTs_t set Resultid = 'E', Stateid = 'E' ," &
                                       " RepairUserId='{0}', RepairIntime = GETDATE(),ReStationId='{1}' " &
                                       " where Ppid='{2}' and Itemid = '{3}'",
                                       SysMessageClass.UseId, "", Txtppid2.Text, lblItemId.Text)
                '不良品修改INPUT表状态
                strSQL = strSQL + SetDinputSQL(Txtppid2.Text, "E")

            Else
                strSQL = String.Format(" declare @cnt int  SELECT  @cnt = COUNT(1) FROM m_AssyTsDetail_t where ppid = '{0}' and Itemid = '{1}' and Stateid = 'D'",
                                        Txtppid2.Text, lblItemId.Text)

                strSQL = strSQL + String.Format(" update m_AssyTs_t set Resultid = case @cnt when 0 then '{0}' else '{1}' end, " &
                                       " Stateid = case @cnt when 0 then '{0}' else '{1}' end ," &
                                       " RepairUserId='{2}', RepairIntime = GETDATE(),ReStationId='{3}' " &
                                       " where Ppid='{4}' and Itemid = '{5}'", sState, sState,
                                       SysMessageClass.UseId, ReStationId, Txtppid2.Text, lblItemId.Text)

                '不良品修改INPUT表状态
                strSQL = strSQL + SetDinputSQL(Txtppid2.Text, "G")
                '自已打印条码ChkIsSelfPrint2
            End If
        
            Dim baofeiItemId As String = lblItemId.Text
            If ChkIsSelfPrint2.Checked = True Then
                SqlStr.Append(" update m_SnSBarCode_t set Usey='" & Result & "' where SBarCode in(select ppid from m_AssyTs_t where MaintainID='" & TxtMainTainNo2.Text & "')")
                SqlStr.Append(strSQLD)
                SqlStr.Append(strSQL)
            Else
                If txtQtys2.Text = txtRepairQtys.Text Then
                    SqlStr.Append(strSQL)
                Else
                    SqlStr.Append(GetMainAddSQL(Result, ItemID, qtys))
                    SqlStr.AppendFormat(" update m_AssyTs_t set NgQty={0} where Ppid='{1}' and Itemid = '{2}' ",
                                (CInt(txtQtys2.Text) - CInt(txtRepairQtys.Text)), Txtppid2.Text, ItemID)
                    SqlStr.AppendFormat(" update m_AssyTs_t set NgQty={0}, RepairUserId = '{1}', RepairIntime=GETDATE(),Resultid = '{2}',Stateid='{3}' " &
                                        "where Ppid='{4}' and Itemid = '{5}' ",
                              CInt(txtRepairQtys.Text), SysMessageClass.UseId, sState, sState, Txtppid2.Text, lblItemId.Text)
                    '有改变
                    'baofeiItemId = ItemID
                End If
            End If

            If CobResult.SelectedIndex = 0 Then
                '记录报废部件内容（m_AssyTsScrap_t）
                SqlStr.Append(GetBaoFeiAddSQL(lblItemId.Text))

                Dim barcode As String = Txtppid2.Text
                Dim moid As String = TxtNGmoid2.Text
                Dim partId As String = TxtPartid2.Text
                'Dim R_StationId As String

                '20200529 田玉琳
                '增加报废自动清除数据相当于跳站处理
                '执行维修返工流程
                If Not String.IsNullOrEmpty(ReStationId) Then
                    SqlStr.Append(" DECLARE @Falg int;DECLARE @Msg nvarchar(150);  ")
                    SqlStr.Append(" EXEC Eexc_ReScanJumpStationHandleNew '" & barcode & "','" & moid & "','" & partId & "','" & ReStationId &
                                  "','" & VbCommClass.VbCommClass.UseId & "', @Falg OUTPUT,@Msg OUTPUT ")
                End If

            End If

            Return SqlStr.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function SetDinputSQL(ppid As String, state As String, Optional stationid As String = "") As String
        Dim strSQL As StringBuilder = New StringBuilder

        If stationid = "" Then
            strSQL.AppendFormat(" DECLARE @ngstationid VARCHAR(10) ")
            strSQL.AppendFormat(" SELECT @ngstationid = ngstationid FROM m_assyts_t WHERE PPID = '{0}' AND (stateid <> '' or stateid <> 'P') ", ppid)
            strSQL.AppendFormat(" UPDATE m_AssysnDInput_t set estateid = '{0}' where ppid = '{1}' and stationid = @ngstationid ", state, ppid)
            'strSQL.AppendFormat(" DECLARE @lastStationid VARCHAR(10) ")
            'strSQL.AppendFormat(" SELECT TOP 1 @lastStationid = stationid FROM m_AssysnDInput_t WHERE PPID = '{0}' ORDER BY intime DESC", ppid)
            'strSQL.AppendFormat(" UPDATE m_AssysnDInput_t set estateid = '{0}' where ppid = '{1}' and stationid = @lastStationid ", state, ppid)
        Else
            strSQL.AppendFormat(" IF NOT EXISTS( SELECT 1 FROM m_AssysnDInput_t WHERE PPID = '{0}' AND stationid = '{1}') ", ppid, stationid)
            strSQL.AppendFormat(" BEGIN insert into m_AssysnDInput_t(PartId,moid,ppid,stationid,sitem,LineId,estateid,userid,intime)   ")
            strSQL.AppendFormat(" values ('{0}','{1}','{2}','{3}','1','{4}','D','{5}',getdate()) END ", TxtPartid.Text, TxtNGmoid.Text, ppid,
                                stationid, TxtLineid.Text, SysMessageClass.UseId)
            strSQL.AppendFormat(" ELSE BEGIN UPDATE m_AssysnDInput_t set estateid = '{0}' where ppid = '{1}' and stationid = '{2}' END", state, ppid, stationid)
        End If

        Return strSQL.ToString
    End Function

    Private Function GetMainAddSQL(result As String, ItemID As String, qtys As String) As String

        Dim oldStates As String = lblStatus2.Text.Split("-")(0).Trim

        Dim strSQL As String = " insert into m_AssyTs_t(MaintainID,moid,Lineid,NgDate,ppid,Pppid,Itemid,Stationid,partid," &
                               "Resultid,Stateid,IsNew,NgQty,Userid,Intime)"
        Dim strInsert As New StringBuilder
        'Txtppid2.Text, lblItemId.Text
        strInsert.Append(strSQL)
        strInsert.AppendFormat("VALUES(")
        strInsert.AppendFormat("'{0}',", TxtMainTainNo2.Text)
        strInsert.AppendFormat("'{0}',", TxtNGmoid2.Text)
        strInsert.AppendFormat("'{0}',", TxtLineid2.Text)
        strInsert.AppendFormat("'{0}',", TxtNGdate2.Value.Date)
        strInsert.AppendFormat("'{0}',", Txtppid2.Text)
        strInsert.AppendFormat("'{0}',", Txtppid2.Text)
        strInsert.AppendFormat("'{0}',", ItemID)
        strInsert.AppendFormat("'{0}',", CobNGRout2.Text.Split("-")(0))
        strInsert.AppendFormat("'{0}',", TxtPartid2.Text)
        'strInsert.AppendFormat("'{0}',", CobcodeType2.Text.Split("-")(0))
        'strInsert.AppendFormat("'{0}',", cobNGdes2.Text.Split("-")(0))
        'strInsert.AppendFormat("'{0}',", CobCodeR.Text.Split("-")(0))
        strInsert.AppendFormat("'{0}',", "D")
        'strInsert.AppendFormat("'{0}',", CobHandle.Text.Split("-")(0))
        'strInsert.AppendFormat("N'{0}',", TxtIdea.Text.Trim)
        strInsert.AppendFormat("'{0}',", "D")
        strInsert.AppendFormat("'{0}',", "Y")
        strInsert.AppendFormat("'{0}',", qtys)
        strInsert.AppendFormat("'{0}',", VbCommClass.VbCommClass.UseId)
        strInsert.AppendFormat("getdate());")

        '插入明细
        Dim strSQLD As String =
            "  insert into m_AssyTsDetail_t(Ppid ,Itemid ,MaintainID , Codeitem ,Codeid ,Stateid ,Stationid,Userid ,Intime)" &
            "  SELECT  '{0}','{1}', MaintainID ,Codeitem ,Codeid ,'D' ,Stationid,Userid ,Intime FROM m_AssyTsDetail_t WHERE ppid = '{2}' and Itemid = '{3}'"

        strSQLD = String.Format(strSQLD, Txtppid2.Text, ItemID, Txtppid2.Text, lblItemId.Text)
        strInsert.Append(strSQLD)

        'If result = "E" Then
        '    'strSQLD = String.Format(" update m_AssyTsDetail_t set Rcodeid='{0}', Stateid='{1}' ,solution = '{2}' ,Suggestion = N'{3}'  " &
        '    '                        " where Ppid='{4}' and Itemid = '{5}' ", CobCodeR.Text.Split("-")(0), result, CobHandle.Text.Split("-")(0),
        '    '                        TxtIdea.Text.Trim, Txtppid2.Text, ItemID)

        '    strSQL = String.Format(" update m_AssyTs_t set Resultid = 'E', Stateid = 'E' ," &
        '                           " RepairUserId='{0}', RepairIntime = GETDATE(),ReStationId='{1}' " &
        '                           " where Ppid='{2}' and Itemid = '{3}'",
        '                           SysMessageClass.UseId, "", Txtppid2.Text, ItemID)
        'Else
        '    '更新明细 
        '    'Dim strSQLDU As String =
        '    '    String.Format(" update m_AssyTsDetail_t set Rcodeid='{0}', Stateid='{1}' ,solution = '{2}' ,Suggestion = N'{3}'  " &
        '    '    " where Ppid='{4}' and Itemid = '{5}' and codeid = '{6}'", CobCodeR.Text.Split("-")(0), result, CobHandle.Text.Split("-")(0),
        '    '    TxtIdea.Text.Trim, Txtppid2.Text, ItemID, cobNGdes2.Text.Split("-")(0))

        '    'strInsert.Append(strSQLDU)

        '    strSQL = String.Format(" declare @cnt int  SELECT  @cnt = COUNT(1) FROM m_AssyTsDetail_t where ppid = '{0}' and Itemid = '{1}' and Stateid = 'D'",
        '                            Txtppid2.Text, ItemID)

        '    strSQL = strSQL + String.Format(" update m_AssyTs_t set Resultid = case @cnt when 0 then '{0}' else '{1}' end, " &
        '                           " Stateid = case @cnt when 0 then '{0}' else '{1}' end ," &
        '                           " RepairUserId='{2}', RepairIntime = GETDATE() " &
        '                           " where Ppid='{3}' and Itemid = '{4}'", result, oldStates,
        '                           SysMessageClass.UseId, Txtppid2.Text, ItemID)
        'End If
     
        'strInsert.Append(strSQL)

        Return strInsert.ToString
    End Function

    '插入报废SQL
    Private Function GetBaoFeiAddSQL(parItemId As String) As String
        Dim strSQL As String = "INSERT INTO m_AssyTsScrap_t(Ppid,paritemId,Itemid,MaintainID,IsNew,Moid,Ppartid,Tpartid,ScrapQty,DeptID,userid,intime)"
        Dim strInsert As StringBuilder
        Dim result As String = String.Empty

        For i As Integer = 0 To Me.ListScrap.Items.Count - 1
            strInsert = New StringBuilder
            strInsert.Append(strSQL)
            strInsert.AppendFormat("VALUES(")
            strInsert.AppendFormat("'{0}',", Txtppid2.Text)
            strInsert.AppendFormat("'{0}',", parItemId)
            strInsert.AppendFormat("'{0}',", (i + 1).ToString)
            strInsert.AppendFormat("'{0}',", TxtMainTainNo2.Text)
            strInsert.AppendFormat("'Y',")
            strInsert.AppendFormat("'{0}',", TxtNGmoid2.Text)
            strInsert.AppendFormat("'{0}',", TxtPartid2.Text)
            strInsert.AppendFormat("'{0}',", ListScrap.Items(i).Id)
            strInsert.AppendFormat("'{0}',", ListScrap.Items(i).Name.ToString.Substring(ListScrap.Items(i).Name.ToString.IndexOf("数量") + 2, 1))
            strInsert.AppendFormat("'{0}',", cboDept.SelectedValue.ToString)
            strInsert.AppendFormat("'{0}',", VbCommClass.VbCommClass.UseId)
            strInsert.AppendFormat("getdate());")
            strInsert.AppendLine()
            result = result + strInsert.ToString
        Next

        Return result
    End Function

    'Grid绑定
    Private Sub BindGrid2(dt As DataTable)
        If dt.Rows.Count = 0 Then Exit Sub

        Me.dgMainTain.DataSource = dt

        '有报废设置
        Dim Ppid As String = dgMainTain.Rows(dgMainTain.SelectedCells(0).RowIndex).Cells("colPpid").Value.ToString
        Dim itemId As String = dgMainTain.Rows(dgMainTain.SelectedCells(0).RowIndex).Cells("colItemId").Value.ToString

        '明细数据绑定
        SetNgDetail(Ppid, itemId, dgDetail2)

        SetScarpGridData(Ppid, itemId)
        '设置Grid颜色
        SetGridColor(dgMainTain, "colStateid")
        '设置Grid颜色--明细 
        SetGridColor(dgDetail2, "colStateid2")
    End Sub

    Private Sub SetScarpGridData(Ppid As String, itemId As String)
        Me.dgScrap.DataSource = MainTainCommon.GetScrapTable(Ppid, itemId)
    End Sub


#Region "Grid点击事件"
    'Grid点击事件
    Private Sub dgMainTain_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMainTain.CellClick
        'SetScarpGridData()
        If e.RowIndex = -1 Then Exit Sub
        Dim Ppid As String = dgMainTain.Rows(dgMainTain.SelectedCells(0).RowIndex).Cells("colPpid").Value.ToString
        Dim itemId As String = dgMainTain.Rows(dgMainTain.SelectedCells(0).RowIndex).Cells("colItemId").Value.ToString
        Me.lblItemId.Text = itemId
        SetScarpGridData(Ppid, itemId)
        SetNgDetail(Ppid, itemId, dgDetail2)

        SetDataByGrid(e.RowIndex, 0)
        '设置Grid颜色--明细 
        SetGridColor(dgDetail2, "colStateid2")
    End Sub

#End Region

#End Region

#Region "记 录 查 询"

    '查询事件
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Try
            Search()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "toolQuery_Click", "WIP")
        End Try
    End Sub

    '取得料号
    Private Sub btnGetPartId_Click(sender As Object, e As EventArgs) Handles btnGetPartId.Click
        MainTainCommon.SetPartIdList(cboQueryLine.Text, txtTimeStart.Value, txtTimeEnd.Value, txtQueryPn)
        'txtQueryPn.SelectedIndex = 0
    End Sub

    '查询
    Private Sub Search()
        Me.LblMSg3.Text = ""
        Dim ngdateStart As String = ""
        Dim ngdateEnd As String = ""
        Dim ngRepairStart As String = ""
        Dim ngRepairEnd As String = ""

        If rdoNgdate.Checked = True Then
            ngdateStart = txtTimeStart.Value
            ngdateEnd = txtTimeEnd.Value
        End If

        If rdoRepairDate.Checked = True Then
            ngRepairStart = txtRepairTimeStart.Value
            ngRepairEnd = txtRepairTimeEnd.Value
        End If


        Dim strSQL As String = " EXEC m_SearchNgDataReportNew_p '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'"
        strSQL = String.Format(strSQL, txtQueryMo.Text.Trim, txtQueryPn.Text.Trim, txtQueryPPid.Text.Trim, cboQueryClass.SelectedValue.ToString,
                               cboQueryLine.Text.Trim, "", ngdateStart, ngdateEnd, ngRepairStart, ngRepairEnd,
                               VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "1")

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        BindGrid3(dt)

        '设置Grid颜色
        SetGridColor(dgQueryMain, "colQueryStateid")
    End Sub

    '设置Grid颜色
    Private Sub SetGridColor(gridView As DataGridView, colName As String)
        For rowIndex As Integer = 0 To gridView.Rows.Count - 1
            If gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("D") Then
                gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.White
            ElseIf gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("B") Then
                gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.Yellow
            ElseIf gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("G") Then
                gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.Pink
            ElseIf gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("E") Then
                gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.Red
            ElseIf gridView.Rows(rowIndex).Cells(colName).Value.ToString.Contains("P") Then
                gridView.Rows(rowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.Green
            End If
        Next
    End Sub

    'Grid绑定
    Private Sub BindGrid3(dt As DataTable)
        Me.dgQueryMain.DataSource = dt

        dgQueryMain.MergeColumnNames.Add("colQueryPpid")
        'dgQueryMain.MergeColumnNames.Add("mesStationid3")

        dgQueryMain.AutoResizeColumns()

        If dt.Rows.Count = 0 Then Exit Sub
        '有报废设置
        'Dim Ppid As String = dgQueryMain.Rows(dgQueryMain.SelectedCells(0).RowIndex).Cells("colQueryPpid").Value.ToString
        'Dim itemId As String = dgQueryMain.Rows(dgQueryMain.SelectedCells(0).RowIndex).Cells("colQueryItemId").Value.ToString

        'SetNgDetail(Ppid, itemId, dgQueryDetail)

        '设置Grid颜色--明细 
        'SetGridColor(dgQueryDetail, "colStateidQuery")

        'SetScarpGridData2(Ppid, itemId)
    End Sub

    '设置报废项目
    Private Sub SetScarpGridData2(Ppid As String, itemId As String)
        Me.dgvQueryScrap.DataSource = MainTainCommon.GetScrapTable(Ppid, itemId)
    End Sub

    '取得查询条件
    Private Function GetDTbyWhere(strSQL As String) As DataTable
        Dim strWhere As New System.Text.StringBuilder

        If String.IsNullOrEmpty(txtQueryUser.Text) = False Then
            strWhere.AppendFormat(" and A.Userid LIKE '%{0}%' ", txtQueryUser.Text.Trim)
        End If

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboQueryClass.SelectedValue)) = False Then
            strWhere.AppendFormat(" and f.DeptID = '{0}' ", cboQueryClass.SelectedValue.ToString)
        End If

        If String.IsNullOrEmpty(DbOperateUtils.DBNullToStr(cboQueryLine.Text)) = False Then
            strWhere.AppendFormat(" and a.Lineid = '{0}' ", cboQueryLine.Text.Trim)
        End If

        If String.IsNullOrEmpty(txtQueryMo.Text.Trim) = False Then
            strWhere.AppendFormat(" and A.MOID LIKE '%{0}%' ", txtQueryMo.Text.Trim)
        End If

        If String.IsNullOrEmpty(txtQueryPPid.Text.Trim) = False Then
            strWhere.AppendFormat(" and A.Ppid LIKE '%{0}%' ", txtQueryPPid.Text.Trim)
        End If

        If String.IsNullOrEmpty(txtQueryPn.Text.Trim) = False Then
            strWhere.AppendFormat(" and A.partid LIKE '%{0}%' ", txtQueryPn.Text.Trim)
        End If

        If String.IsNullOrEmpty(cboQueryStatus.SelectedValue.ToString) = False Then
            strWhere.AppendFormat(" and A.Stateid = '{0}' ", cboQueryStatus.SelectedValue.ToString)
        End If

        strWhere.AppendFormat(" and CONVERT(NVARCHAR(10), cast(A.NgDate as datetime) ,111) >= CONVERT(NVARCHAR(10),CAST(replace(replace('{0}','下午',''),'上午','')AS datetime),111)  ", txtTimeStart.Value)
        strWhere.AppendFormat(" and CONVERT(NVARCHAR(10), cast(A.NgDate as datetime) ,111) <= CONVERT(NVARCHAR(10),CAST(replace(replace('{0}','下午',''),'上午','')AS datetime),111)  ", txtTimeEnd.Value)

        Dim strOrderby As String = " order by Stateid asc , A.intime desc"

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL + strWhere.ToString + strOrderby)
        Return dt
    End Function

    '查询界面点击 
    Private Sub dgQueryMain_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If dgQueryMain.Rows.Count = 0 Then Exit Sub
        Try
            Dim Ppid As String = dgQueryMain.Rows(dgQueryMain.SelectedCells(0).RowIndex).Cells("colQueryPpid").Value.ToString
            Dim itemId As String = dgQueryMain.Rows(dgQueryMain.SelectedCells(0).RowIndex).Cells("colQueryItemId").Value.ToString

            'SetNgDetail(Ppid, itemId, dgQueryDetail)

            ''设置Grid颜色--明细 
            'SetGridColor(dgQueryDetail, "colStateidQuery")

            SetScarpGridData2(Ppid, itemId)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "dgQueryMain_CellClick", "WIP")
        End Try

    End Sub

    '全选
    Private Sub chbSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chbSelectAll.CheckedChanged
        If (Me.dgQueryMain.RowCount > 0) Then
            For i As Int16 = 0 To Me.dgQueryMain.RowCount - 1
                dgQueryMain.Rows(i).Cells("QueryCheckBox").Value = Me.chbSelectAll.Checked
            Next
        End If
    End Sub

    'EXCEL
    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        Try

            Dim ngdateStart As String = ""
            Dim ngdateEnd As String = ""
            Dim ngRepairStart As String = ""
            Dim ngRepairEnd As String = ""

            If rdoNgdate.Checked = True Then
                ngdateStart = txtTimeStart.Value
                ngdateEnd = txtTimeEnd.Value
            End If

            If rdoRepairDate.Checked = True Then
                ngRepairStart = txtRepairTimeStart.Value
                ngRepairEnd = txtRepairTimeEnd.Value
            End If


            Dim strSQL As String = " EXEC m_SearchNgDataReportNew_p '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'"
            strSQL = String.Format(strSQL, txtQueryMo.Text.Trim, txtQueryPn.Text.Trim, txtQueryPPid.Text.Trim, cboQueryClass.SelectedValue.ToString,
                                   cboQueryLine.Text.Trim, "", ngdateStart, ngdateEnd, ngRepairStart, ngRepairEnd,
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "2")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            Dim directoryPath As String = "c:\MesExport\"
            Dim o_TempoutputFile As String = ""
            Dim reportFileName As String = "产品不良分析_" + Now.ToString("yyyyMMddHHmm")

            Dim errorMsg As String = Nothing


            o_TempoutputFile = String.Format(directoryPath & "{0}.xlsx", reportFileName)
            Dim bFlag As Boolean = ExportExcel(o_TempoutputFile, dt, errorMsg)

            If bFlag = False Then
                MessageUtils.ShowError(errorMsg)
            Else
                MessageUtils.ShowInformation("成功导出!")
                '增加打开EXCEL文件
                System.Diagnostics.Process.Start(o_TempoutputFile)
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "ToolExcel_Click", "WIP")
        End Try
    End Sub

    Private Function ExportExcel(ByVal outPutFile As String, ByVal dt As DataTable, ByRef errorMsg As String) As Boolean
        Dim titleName As String = "产品不良品分析MIL"
        'Dim partNo As String = String.Format("料号：{0}", cbbPartId.Text.Trim)
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Try

            workBookDesigner = New WorkbookDesigner
            wk = New Workbook()
            workBookDesigner.Workbook = wk      '工作簿

            '为标题设置样式
            Dim styleTitle As Style = wk.Styles(wk.Styles.Add) '新增样式
            styleTitle.HorizontalAlignment = TextAlignmentType.Left  '文字居中 
            styleTitle.VerticalAlignment = TextAlignmentType.Center
            styleTitle.Font.Size = 20
            styleTitle.Font.IsBold = True
            styleTitle.IsTextWrapped = True

            Dim style1 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style1.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style1.VerticalAlignment = TextAlignmentType.Center
            style1.Font.Size = 12
            style1.IsTextWrapped = True

            Dim style2 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style2.HorizontalAlignment = TextAlignmentType.Center '文字居中 
            style2.VerticalAlignment = TextAlignmentType.Center
            style2.IsTextWrapped = True

            Dim style3 As Style = wk.Styles(wk.Styles.Add) '新增样式
            style3.HorizontalAlignment = TextAlignmentType.Left  '文字居中 
            style3.VerticalAlignment = TextAlignmentType.Left
            style3.IsTextWrapped = True

            Dim sheet As Worksheet = wk.Worksheets(0) '工作表
            Dim cells As Cells = sheet.Cells

            Dim colnum As Integer = dt.Columns.Count
            Dim rownum As Integer = dt.Rows.Count
            Dim TotalHeJi As Integer = 2

            '生成行1 标题行   
            cells.Merge(0, 0, 1, colnum) '合并单元格
            cells(0, 0).PutValue(titleName) '填写内容
            cells(0, 0).SetStyle(styleTitle)    '
            cells.SetRowHeight(0, 30) ' 设置行高度
   
            '设置显示开始位置
            cells.SetColumnWidth(0, 6)                     ' 设置列宽度
            cells.SetColumnWidth(1, 10)                     ' 设置列宽度
            cells.SetColumnWidth(2, 8)                     ' 第二列列宽度
            cells.SetColumnWidth(3, 19)                     ' 第二列列宽度
            cells.SetColumnWidth(4, 18)                     ' 第二列列宽度
            cells.SetColumnWidth(5, 30)                     ' 第二列列宽度
            cells.SetColumnWidth(6, 20)                     ' 第二列列宽度
            cells.SetColumnWidth(7, 20)                     ' 第二列列宽度
            cells.SetColumnWidth(8, 20)                     ' 第二列列宽度
            cells.SetColumnWidth(9, 18)                     ' 第二列列宽度
            cells.SetColumnWidth(10, 18)                     ' 第二列列宽度
            cells.SetColumnWidth(11, 18)                     ' 第二列列宽度

            '设置显示开始位置
            Dim startPos As Integer = 1

            cells(startPos, 0).PutValue("序号")
            cells(startPos, 0).SetStyle(style1) ' 设置列头样式

            '从第二行开始 列显示 
            For i As Integer = 0 To colnum - 1
                cells(startPos, i + 1).PutValue(dt.Columns(i).ColumnName)
                cells(startPos, i + 1).SetStyle(style1) ' 设置列头样式
            Next

            cells.SetRowHeight(startPos, 40) ' 设置行高度

            Dim files As String = String.Empty

            For i As Integer = 0 To rownum - 1 '行
                For k As Integer = 0 To colnum - 1 '列
                    '最后一列
                    If k = colnum - 1 Then
                        files = dt.Rows(i)(k)
                        If String.IsNullOrEmpty(files) = False Then
                            cells.SetRowHeight(startPos + 1 + i, 80) ' 设置行高度
                            ExcelAddPicture(sheet, startPos + 1 + i, k + 1, dt.Rows(i)(k))
                        End If
                    Else
                        cells(startPos + 1 + i, k + 1).PutValue(dt.Rows(i)(k))
                        cells(startPos + 1 + i, k + 1).SetStyle(style3)
                        cells.SetRowHeight(startPos + 1 + i, 20) ' 设置行高度
                    End If
                    cells(startPos + 1 + i, 0).PutValue((i + 1).ToString)
                    cells(startPos + 1 + i, k + 1).SetStyle(style2)
                Next
            Next

            '第三列数据合并
            Dim hashTable As Hashtable = GetHashTable(dt, 2)

            startPos = 2
            For Each de As DictionaryEntry In hashTable
                cells.Merge(de.Value.ToString.Split("|")(1) + startPos, 3, de.Value.ToString.Split("|")(2), 1) '合并单元格
                cells(de.Value.ToString.Split("|")(1) + startPos, 3).PutValue(de.Value.ToString.Split("|")(0))
                cells(de.Value.ToString.Split("|")(1) + startPos, 3).SetStyle(style2)
            Next

            '第一列数据合并
            'hashTable = GetHashTable(dt, 0)

            'startPos = 2
            'For Each de As DictionaryEntry In hashTable
            '    cells.Merge(de.Value.ToString.Split("|")(1) + startPos, 1, de.Value.ToString.Split("|")(2), 1) '合并单元格
            '    cells(de.Value.ToString.Split("|")(1) + startPos, 1).PutValue(de.Value.ToString.Split("|")(0))
            '    cells(de.Value.ToString.Split("|")(1) + startPos, 1).SetStyle(style2)
            'Next

            ''第二列数据合并
            'hashTable = GetHashTable(dt, 1)

            'startPos = 2
            'For Each de As DictionaryEntry In hashTable
            '    cells.Merge(de.Value.ToString.Split("|")(1) + startPos, 2, de.Value.ToString.Split("|")(2), 1) '合并单元格
            '    cells(de.Value.ToString.Split("|")(1) + startPos, 2).PutValue(de.Value.ToString.Split("|")(0))
            '    cells(de.Value.ToString.Split("|")(1) + startPos, 2).SetStyle(style2)
            'Next

            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(outPutFile, SaveFormat.Xlsx)
            Return True
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        Finally
            If Not workBookDesigner Is Nothing Then
                workBookDesigner = Nothing
            End If
            If Not wk Is Nothing Then
                wk = Nothing
            End If
        End Try
    End Function

    Private Sub ExcelAddPicture(sheet As Worksheet, leftRow As Integer, rightCol As Integer, path As String)

        If String.IsNullOrEmpty(path) = True Then
            Exit Sub
        End If

        Dim files() As String = path.Split(",")
        Dim filePath As String
        Dim iIndex As Integer

        For rowIndex As Integer = 0 To files.Length - 1

            filePath = files(rowIndex)

            iIndex = sheet.Pictures.Add(leftRow, rightCol, filePath)

            Dim pic As Aspose.Cells.Drawing.Picture = sheet.Pictures(iIndex)
            pic.Width = 100
            pic.Height = 100
            pic.Placement = Aspose.Cells.Drawing.PlacementType.FreeFloating

            rightCol = rightCol + 1
        Next
    End Sub

    '行单格合并
    Private Function GetHashTable(dt As DataTable, column As Integer) As Hashtable
        Dim alTemp As Hashtable = New Hashtable
        Dim tempObj As String = ""
        Dim posI As String = "0"
        Dim changeI As Integer = 0
        '合并单元格
        For i As Integer = 0 To dt.Rows.Count - 1 '行
            If dt.Rows(i)(column).ToString = "" Then
                Continue For
            End If
            If tempObj <> dt.Rows(i)(column).ToString Then
                tempObj = dt.Rows(i)(column).ToString
                posI = i
                changeI = 1
                If alTemp.ContainsKey(tempObj) Then
                    alTemp.Remove(tempObj)
                End If
                alTemp.Add(tempObj, tempObj + "|" + posI.ToString + "|" + changeI.ToString)
            Else
                changeI = changeI + 1
                If alTemp.ContainsKey(tempObj) Then
                    alTemp.Remove(tempObj)
                    alTemp.Add(tempObj, tempObj + "|" + posI.ToString + "|" + changeI.ToString)
                End If
            End If
        Next
        Return alTemp
    End Function


    '维修报表生成
    Private Sub tsbRepair_Click(sender As Object, e As EventArgs) Handles toolQueryRepair.Click
        Try
            Me.LblMSg3.Text = String.Empty
            If IsCheckInput() = False Then Exit Sub

            Dim dt As DataTable = MainTainCommon.GetSearchSQLRepairEXCEL(cboQueryLine.Text.Trim.ToUpper, txtQueryPn.Text.Trim, txtTimeStart.Value.Date)
            If dt.Rows.Count = 0 Then
                MessageUtils.ShowInformation("无资料供导出！")
                Exit Sub
            End If

            Dim frm As FrmMainTainRepairReport = New FrmMainTainRepairReport
            frm.DTable = dt
            frm.Lineid = cboQueryLine.Text.Trim.ToUpper
            frm.PartId = txtQueryPn.Text.Trim
            frm.NgDate = txtTimeStart.Value.Date

            frm.ShowDialog()

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "tsbQueryRepair", "WIP")
        End Try
    End Sub

    '检查输入的内容
    Private Function IsCheckInput() As Boolean
        If String.IsNullOrEmpty(cboQueryLine.Text.Trim) Then
            Me.LblMSg3.Text = "导出维修报表,请输入线别..."
            Return False
        End If
        If txtTimeStart.Value.Date <> txtTimeEnd.Value.Date Then
            Me.LblMSg3.Text = "导出维修报表,不良日期只能选择同一天..."
            Return False
        End If
        If String.IsNullOrEmpty(txtQueryPn.Text.Trim) Then
            Me.LblMSg3.Text = "导出维修报表,产品料号必须选择..."
            Return False
        End If
        Return True
    End Function

    '删除
    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        Try
            '检查数据 
            If CheckStatus(Status.DELETE) = False Then Exit Sub
            If MessageUtils.ShowConfirm("你确定删除吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            Dim Stateid As String
            Dim barCode As String
            Dim itemId As String
            Dim bSelect As Boolean = False
            For rowIndex As Integer = 0 To dgQueryMain.Rows.Count - 1
                If Me.dgQueryMain.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    Stateid = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryStateid").EditedFormattedValue.ToString
                    barCode = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryPpid").EditedFormattedValue.ToString
                    itemId = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryItemId").EditedFormattedValue.ToString

                    '只能删除驳回状态
                    If Stateid.Contains("B") = True Then
                        strSQL.AppendFormat(" update m_SnSBarCode_t set UseY='Y',Mark1=null,Mark2=null where SBarCode='{0}' ", barCode)
                        strSQL.AppendFormat(" insert into m_AssyTsDelete_t select *,'','{0}',getdate() from m_AssyTs_t where ppid='{1}' and itemid = '{2}'  ",
                                            VbCommClass.VbCommClass.UseId, barCode, itemId)
                        strSQL.AppendFormat(" DELETE m_AssyTs_t where ppid='{0}' and itemid = '{1}' ", barCode, itemId)
                        strSQL.AppendFormat(" DELETE m_AssyTsDetail_t where ppid='{0}' and itemid = '{1}' ", barCode, itemId)
                    End If
                End If
            Next
            DbOperateUtils.ExecSQL(strSQL.ToString)
            '重新更新查询
            Search()
            Me.LblMSg3.Text = "产品条码删除成功！"

        Catch ex As Exception
            Me.LblMSg3.Text = "产品条码删除成功！"
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "ToolRecover_Click", "WIP")
        End Try
    End Sub

#Region "误判恢复"

    '误判恢复
    Private Sub ToolRecover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRecover.Click
        Try
            '检查数据 
            If CheckStatus(Status.Revover) = False Then Exit Sub
            If MessageUtils.ShowConfirm("你确定误判恢复吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            Dim strSQL As New StringBuilder
            Dim Stateid As String
            Dim barCode As String
            Dim itemId As String
            Dim NgDate As String
            Dim bSelect As Boolean = False
            Dim ppidList As New ArrayList

            For rowIndex As Integer = 0 To dgQueryMain.Rows.Count - 1
                If Me.dgQueryMain.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    Stateid = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryStateid").EditedFormattedValue.ToString
                    barCode = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryPpid").EditedFormattedValue.ToString
                    itemId = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryItemId").EditedFormattedValue.ToString
                    NgDate = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryNgDate").EditedFormattedValue.ToString

                    '没有误判恢复权限
                    If ToolRecoverLast.Enabled = False Then
                        Dim bFlag As Boolean = CheckPpidNgDate(barCode, itemId)
                        If bFlag = False Then
                            Me.LblMSg3.Text = String.Format("只能恢复当天的不良判定日期，条码不良日期{0},请确认！", NgDate)
                            Exit Sub
                        End If
                    End If
                  
                    If Stateid.Contains("D") = True And ppidList.Contains(barCode + ":" + itemId) = False Then
                        strSQL.AppendFormat(" update m_SnSBarCode_t set UseY='Y',Mark1=null,Mark2=null where SBarCode='{0}' ", barCode)
                        strSQL.AppendFormat(" update m_AssyTs_t set isnew='N' ,Stateid = '', resultid = '',RecoverUserId = '{0}',RecoverTime = getdate() where ppid='{1}' and itemid = '{2}' ",
                                            VbCommClass.VbCommClass.UseId, barCode, itemId)
                        strSQL.AppendFormat(" update m_AssyTsDetail_t set Stateid = '' where ppid='{0}' and itemid = '{1}' ", barCode, itemId)
                        '不良品修改INPUT表状态
                        strSQL.AppendFormat(SetDinputSQL(barCode, "Y"))
                    End If

                    ppidList.Add(barCode + ":" + itemId)
                End If
            Next
            DbOperateUtils.ExecSQL(strSQL.ToString)
            '重新更新查询
            Search()
            Me.LblMSg3.Text = "产品条码误判恢复成功！"

        Catch ex As Exception
            Me.LblMSg3.Text = "条码误判恢复未成功！"
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "ToolRecover_Click", "WIP")
        End Try
    End Sub

    '确认条码恢复日期是不是当天日期，如果不是能误判恢复
    '20200409 田玉琳
    Private Function CheckPpidNgDate(ppid As String, itemid As String)
        Dim strSQL As String = "SELECT 1 FROM  m_AssyTs_t WHERE ppid = '{0}' and itemid = '{1}'" &
                               " AND CONVERT(VARCHAR(10), cast(NgDate AS DATE),112 ) <> CONVERT(VARCHAR(10),Getdate() ,112 ) "

        strSQL = String.Format(strSQL, ppid, itemid)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    '检查选择数据状态
    Private Function CheckStatus(CurStatus As Status) As Boolean
        Dim alList As ArrayList = New ArrayList

        GetStatus(alList)
        If alList.Count = 0 Then
            Me.LblMSg3.Text = "请选择数据！"
            Return False
        End If

        Select Case CurStatus
            Case Status.Revover
                '1.恢复
                For index As Integer = 0 To alList.Count - 1
                    If alList(index).Contains("G") Then
                        Me.LblMSg3.Text = "该产品维修OK待确认，不能恢复，请确认！！"
                        Return False
                    ElseIf alList(index).Contains("B") Then
                        Me.LblMSg3.Text = "该产品驳回状态，不能恢复，请确认！！"
                        Return False
                    ElseIf alList(index).Contains("E") Then
                        Me.LblMSg3.Text = "该产品已报废，不能恢复，请确认！！"
                        Return False
                    ElseIf alList(index).Contains("P") Then
                        Me.LblMSg3.Text = "该产品IPQC已确认，不能恢复，请确认！！"
                        Return False
                    End If
                Next
            Case Status.Abandon
                '2.驳回
                For index As Integer = 0 To alList.Count - 1
                    If alList(index).Contains("D") Then
                        Me.LblMSg3.Text = "该产品未经过维修，请确认！！"
                        Return False
                    ElseIf alList(index).Contains("B") Then
                        Me.LblMSg3.Text = "该产品已驳回，不能驳回，请确认！！"
                        Return False
                    ElseIf alList(index).Contains("E") Then
                        Me.LblMSg3.Text = "该产品已报废，不能驳回，请确认！！"
                        Return False
                    ElseIf alList(index).Contains("P") Then
                        Me.LblMSg3.Text = "该产品IPQC已确认，不能驳回，请确认！！"
                        Return False
                    End If
                Next
            Case Status.IPQC
                '3.IPQC
                For index As Integer = 0 To alList.Count - 1
                    If alList(index).Contains("D") Then
                        Me.LblMSg3.Text = "该产品未经过维修，请确认！！"
                        Return False
                    ElseIf alList(index).Contains("B") Then
                        Me.LblMSg3.Text = "该产品已驳回，不允许再进行IPQC确认..."
                        Return False
                    ElseIf alList(index).Contains("E") Then
                        Me.LblMSg3.Text = "该产品已报废，不允许再进行IPQC确认..."
                        Return False
                    ElseIf alList(index).Contains("P") Then
                        Me.LblMSg3.Text = "该产品IPQC已确认，请确认！！"
                        Return False
                    End If
                Next
            Case Status.DELETE
                '3.IPQC
                For index As Integer = 0 To alList.Count - 1
                    If alList(index).Contains("D") Then
                        Me.LblMSg3.Text = "该产品未经过维修，不能删除！！"
                        Return False
                        'ElseIf alList(index).Contains("B") Then
                        '    Me.LblMSg3.Text = "该产品已驳回，不允许再进行IPQC确认..."
                        '    Return False
                    ElseIf alList(index).Contains("E") Then
                        Me.LblMSg3.Text = "该产品已报废，不能删除..."
                        Return False
                    ElseIf alList(index).Contains("P") Then
                        Me.LblMSg3.Text = "该产品IPQC已确认，不能删除！！"
                        Return False
                    End If
                Next
            Case Else
        End Select
        Return True
    End Function

    '取得选择数据
    Private Sub GetStatus(ByRef alList As ArrayList)
        For rowIndex As Integer = 0 To dgQueryMain.Rows.Count - 1
            If Not dgQueryMain.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue Is Nothing AndAlso
                   dgQueryMain.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue.ToString = "True" Then
                alList.Add(dgQueryMain.Rows(rowIndex).Cells("colQueryStateid").EditedFormattedValue.ToString)
            End If
        Next
    End Sub

#End Region

#Region "驳回"
    '驳回
    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        Try
            If CheckStatus(Status.Abandon) = False Then Exit Sub
            If MessageUtils.ShowConfirm("你确定驳回吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            Dim strSQL As New StringBuilder
            Dim Stateid As String
            Dim barCode As String
            Dim itemId As String
            Dim remark As String
            Dim ppidList As New ArrayList

            For rowIndex As Integer = 0 To dgQueryMain.Rows.Count - 1
                If Me.dgQueryMain.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    Stateid = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryStateid").EditedFormattedValue.ToString
                    barCode = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryPpid").EditedFormattedValue.ToString
                    itemId = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryItemId").EditedFormattedValue.ToString
                    remark = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryRemark").EditedFormattedValue.ToString

                    If Stateid.Contains("G") = True And ppidList.Contains(barCode + ":" + itemId) = False Then
                        strSQL.AppendFormat(" update m_SnSBarCode_t set UseY='B',Mark1=null,Mark2=null where SBarCode='{0}' ", barCode)
                        strSQL.AppendFormat(" update m_AssyTs_t set Stateid = 'B', resultid = 'B',Remark=N'{0}' , ConfirmUserId='{1}',ConfirmTime =getdate() where ppid='{2}' and itemid = '{3}' ",
                                            remark, VbCommClass.VbCommClass.UseId, barCode, itemId)
                        strSQL.AppendFormat(" update m_AssyTsDetail_t set Stateid = 'D' where ppid='{0}' and itemid = '{1}' ",
                                             barCode, itemId)
                        '不良品修改INPUT表状态
                        strSQL.AppendFormat(SetDinputSQL(barCode, "B"))

                    End If
                    ppidList.Add(barCode + ":" + itemId)
                End If
            Next
            DbOperateUtils.ExecSQL(strSQL.ToString)
            '重新更新查询
            Search()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "toolAbandon_Click", "WIP")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
#End Region

#Region "IPQC确认"
    'IPQC确认
    Private Sub toolIPQC_Click(sender As Object, e As EventArgs) Handles toolIPQC.Click
        Try
            '检查数据 
            If CheckStatus(Status.IPQC) = False Then Exit Sub
            If MessageUtils.ShowConfirm("你确定IPQC确认吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            Dim strSQL As New StringBuilder
            Dim Stateid As String
            Dim barCode As String
            Dim itemId As String
            Dim moid As String
            Dim stationId As String
            Dim partId As String
            Dim ReStationId As String
            Dim R_StationId As String
            Dim ppidList As New ArrayList
            dgQueryMain.EndEdit()
            strSQL.Append(" DECLARE @Falg int;DECLARE @Msg nvarchar(150);  ")
            For rowIndex As Integer = 0 To dgQueryMain.Rows.Count - 1
                If Me.dgQueryMain.Rows(rowIndex).Cells("QueryCheckBox").EditedFormattedValue.ToString.ToUpper = "TRUE" Then
                    Stateid = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryStateid").EditedFormattedValue.ToString
                    partId = Me.dgQueryMain.Rows(rowIndex).Cells("colNgPartId").EditedFormattedValue.ToString
                    barCode = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryPpid").EditedFormattedValue.ToString
                    itemId = Me.dgQueryMain.Rows(rowIndex).Cells("colQueryItemId").EditedFormattedValue.ToString
                    moid = Me.dgQueryMain.Rows(rowIndex).Cells("colNgMoid").EditedFormattedValue.ToString
                    stationId = Me.dgQueryMain.Rows(rowIndex).Cells("colNgStationid").EditedFormattedValue.ToString
                    ReStationId = Me.dgQueryMain.Rows(rowIndex).Cells("colReStationId").EditedFormattedValue.ToString
                    R_StationId = Me.dgQueryMain.Rows(rowIndex).Cells("R_StationId").EditedFormattedValue.ToString


                    'colReStationId
                    If Stateid.Contains("G") = True And ppidList.Contains(barCode + ":" + itemId) = False Then
                        strSQL.AppendFormat(" update m_SnSBarCode_t set UseY='Y',Mark1=null,Mark2=null where SBarCode='{0}' ;", barCode)
                        'strSQL.AppendFormat(" update m_AssyTs_t set ISok='Y' ,Stateid = 'P', resultid = 'P', ConfirmUserId='{0}',ConfirmTime =getdate() where ppid='{1}' and itemid = '{2}'; ",
                        '                    VbCommClass.VbCommClass.UseId, barCode, itemId)
                        'R 部分回流 result保留 DJ 20180517
                        strSQL.AppendFormat(" update m_AssyTs_t set ISok='Y' ,Stateid = 'P', resultid = case Resultid  when 'G'  THEN 'P' WHEN'R' THEN 'R' END, ConfirmUserId='{0}',ConfirmTime =getdate() where ppid='{1}' and itemid = '{2}'; ",
                                          VbCommClass.VbCommClass.UseId, barCode, itemId)

                        strSQL.AppendFormat(" update m_AssyTsDetail_t set Stateid = 'P' where ppid='{0}' and itemid = '{1}'; ",
                                            barCode, itemId)

                        '不良品修改INPUT表状态
                        strSQL.AppendFormat(SetDinputSQL(barCode, "P"))
                        'add by hgd 2017-11-22 维修完成后，减去不良数，用于制程扫描控制不良率
                        'strSQL.AppendFormat(" UPDATE m_ProduceRecordDay_t SET NGqty=case when NGqty-1<0 then 0 else  NGqty-1 end,NGRate=case when NGqty-1<0 then  0 else (case when ScanQty+(NGqty-1)>0 then   ROUND((NGqty-1)/((ScanQty+(NGqty-1))*1.00),4)*100  else 0 end)  end  where moid='" & moid & "' and StationID='" & stationId & "' ")

                        '执行维修返工流程
                        If Not String.IsNullOrEmpty(ReStationId) Then
                            strSQL.Append(" EXEC Eexc_ReScanJumpStationHandleNew '" & barCode & "','" & moid & "','" & partId & "','" & R_StationId & "','" & VbCommClass.VbCommClass.UseId & "', @Falg OUTPUT,@Msg OUTPUT ")
                        End If

                    End If

                    ppidList.Add(barCode + ":" + itemId)
                End If
            Next
            DbOperateUtils.ExecSQL(strSQL.ToString)
            '重新更新查询
            Search()
            Me.LblMSg3.Text = "产品IPQC确认成功！"
        Catch ex As Exception
            Me.LblMSg3.Text = "产品IPQC确认失败！"
            SysMessageClass.WriteErrLog(ex, "MainTainModule", "toolIPQC_Click", "WIP")
        End Try
    End Sub
#End Region
#End Region

#Region "Common"

    '退出当前页面
    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Tab 选择事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl.SelectedIndexChanged
        SetToolButton(False)
        If TabControl.SelectedIndex = 0 Then
            ToolStar.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(ToolStar.Tag) = "YES", True, False))
            ToolStarLast.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(ToolStarLast.Tag) = "YES", True, False))
            TxtNGmoid.Focus()
        ElseIf TabControl.SelectedIndex = 1 Then
            ToolRepair.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(ToolRepair.Tag) = "YES", True, False))
            ChkIsSelfPrint2.Checked = True
            Txtppid2.Focus()
        ElseIf TabControl.SelectedIndex = 2 Then
            toolQuery.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolQuery.Tag) = "YES", True, False))
            toolExcel.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolExcel.Tag) = "YES", True, False))
            ToolRecover.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(ToolRecover.Tag) = "YES", True, False))
            ToolRecoverLast.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(ToolRecoverLast.Tag) = "YES", True, False))
            toolAbandon.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolAbandon.Tag) = "YES", True, False))
            toolIPQC.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolIPQC.Tag) = "YES", True, False))
            toolQueryRepair.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolQueryRepair.Tag) = "YES", True, False))
            toolDelete.Enabled = CBool(IIf(DbOperateUtils.DBNullToStr(toolDelete.Tag) = "YES", True, False))
            '有查询权限直接显示初始数据
            If toolQuery.Enabled = True Then
                Search()
            End If
        End If
    End Sub
    '设置按钮编辑性
    Private Sub SetToolButton(bFlag As Boolean)
        ToolStar.Enabled = bFlag
        ToolRepair.Enabled = bFlag
        ToolFinish.Enabled = bFlag
        ToolRecover.Enabled = bFlag
        toolAbandon.Enabled = bFlag
        toolIPQC.Enabled = bFlag
        toolQuery.Enabled = bFlag
        toolExcel.Enabled = bFlag
        ToolCancel.Enabled = bFlag
        toolQueryRepair.Enabled = bFlag
        toolDelete.Enabled = bFlag
    End Sub


#End Region

#Region "ComBox SelectIndex"

    '不良现象大分类事件
    Private Sub CobcodeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CobcodeType.SelectedIndexChanged
        LblMSg.Text = "提示信息"
        If CobcodeType.Text = "" Then Exit Sub
        '不良现象
        MainTainCommon.BindComboxNG2(cobNGdes, CobcodeType.Text.Split("-")(0).Trim, listOnit)
        'listOnit
    End Sub

    '不良现象大分类事件
    Private Sub CobcodeType2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CobcodeType2.SelectedIndexChanged
        If CobcodeType2.Text = "" Then Exit Sub
        '不良现象
        MainTainCommon.BindComboxNG(cobNGdes2, CobcodeType2.Text.Split("-")(0).Trim)
    End Sub

    '线别
    Private Sub cboQueryClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboQueryClass.SelectedIndexChanged
        If cboQueryClass.SelectedValue Is Nothing Then Exit Sub
        '线别
        MainTainCommon.BindComboxLine(cboQueryLine, cboQueryClass.SelectedValue.ToString)
    End Sub

    '维修结果
    Private Sub CobResult_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CobResult.SelectedIndexChanged
        If CobResult.SelectedIndex = 0 Then ' 报废 
            If CobResult.Enabled = True Then
                groupBoxScarp.Enabled = True
            End If
        Else
            groupBoxScarp.Enabled = False
        End If
    End Sub


#End Region

#Region "Grid行数"
    Private Sub dgResult_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgResult.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
    Private Sub dgMainTain_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgMainTain.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
    Private Sub dgQueryMain_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgQueryMain.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

    Private Sub chkReadSN_Click(sender As Object, e As EventArgs) Handles chkReadSN.Click
        If Me.chkReadSN.Checked = True Then
            ' Txtppid.Text = ReadSN()
        End If
    End Sub

    Private Function ReadSFPSN() As String
        Dim o_strINIBar As String = ""
        Dim path As String = "", o_strSFPPath As String = ""
        Dim o_tempTxtppid As String

        If Strings.Right(Application.StartupPath, 1) = "\" Then
            o_strSFPPath = Application.StartupPath & "SFP读取产品序列号\SystemConfig.ini"
        Else
            o_strSFPPath = Application.StartupPath & "\" & "SFP读取产品序列号\SystemConfig.ini"
        End If
        ' SFP读取产品序列号
        Try

            If File.Exists(o_strSFPPath) = True Then
                o_strINIBar = ""
                '方法一
                Dim sr As StreamReader = New StreamReader(o_strSFPPath, System.Text.Encoding.Default)
                Dim line As String
                Do
                    line = sr.ReadLine
                    If line = "" Then
                        sr.Close()
                        Exit Do
                    End If
                    o_strINIBar = o_strINIBar & line & Chr(13) & Chr(10)
                Loop
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
            o_tempTxtppid = o_strINIBar.Replace("Lot Num=", "").Replace(";", "").Trim()
            Return o_tempTxtppid
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ReadQSFPSN() As String
        Dim o_strINIBar As String = ""
        Dim path As String = "", o_strQSFPPath As String = ""
        Dim o_tempTxtppid As String

        If Strings.Right(Application.StartupPath, 1) = "\" Then
            o_strQSFPPath = Application.StartupPath & "QSFP读取序列号\SystemConfig.ini"
        Else
            o_strQSFPPath = Application.StartupPath & "\" & "QSFP读取序列号\SystemConfig.ini"
        End If
        ' QSFP读取产品序列号

        Try

            If File.Exists(o_strQSFPPath) = True Then
                o_strINIBar = ""
                '方法一
                Dim sr As StreamReader = New StreamReader(o_strQSFPPath, System.Text.Encoding.Default)
                Dim line As String
                Do
                    line = sr.ReadLine
                    If line = "" Then
                        sr.Close()
                        Exit Do
                    End If
                    o_strINIBar = o_strINIBar & line & Chr(13) & Chr(10)
                Loop
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
            o_tempTxtppid = o_strINIBar.Replace("Lot Num=", "").Replace(";", "").Trim()
            Return o_tempTxtppid
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub chkReadSN_CheckedChanged(sender As Object, e As EventArgs) Handles chkReadSN.CheckedChanged
        If Me.chkReadSN.Checked = True Then
            ' Txtppid.Text = ReadSN()
        End If
    End Sub

    Private Sub CobType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CobType.SelectedIndexChanged

        Select Case CobType.Text
            Case "QSFP"
                Me.Txtppid.Text = ReadQSFPSN()
            Case "SFP"
                Me.Txtppid.Text = ReadSFPSN()
        End Select


    End Sub


    Private Sub cobNGdes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cobNGdes.SelectedIndexChanged, cobNGdes2.SelectedIndexChanged
        If CobcodeType.Enabled = False Then
            ScanNgCode()
        End If
    End Sub

    Private Sub cobNGdes_TextUpdate(sender As Object, e As EventArgs) Handles cobNGdes.TextUpdate
        '清空combobox
        cobNGdes.Items.Clear()
        '清空listNew
        listNew.Clear()

        '遍历全部备查数据
        For Each item As Object In listOnit
            If item.ToString.Contains(cobNGdes.Text.ToUpper()) Then
                '符合，插入ListNew
                listNew.Add(item)
            End If
        Next
        'combobox添加已经查到的关键词
        cobNGdes.Items.AddRange(listNew.ToArray())

        '设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
        cobNGdes.SelectionStart = cobNGdes.Text.Length
        '保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
        Cursor = Cursors.Default
        '自动弹出下拉框
        cobNGdes.DroppedDown = True
    End Sub


    Private Sub dgResult_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgResult.CellClick
        If e.RowIndex = -1 Then Return
        If Me.dgResult.RowCount < 1 Then Return
        Dim ppid As String = Me.dgResult.Rows(e.RowIndex).Cells("Ppid").Value.ToString()
        Dim Itemid As String = Me.dgResult.Rows(e.RowIndex).Cells("Itemid").Value.ToString()

        SetNgDetail(ppid, Itemid, dgDetail)
    End Sub

    Private Sub InitNgDetail(gridview As DataGridView, dgDetail As DataGridView)
        If gridview.Rows.Count > 0 Then
            Dim ppid As String = gridview.Rows(0).Cells("Ppid").Value.ToString()
            Dim Itemid As String = gridview.Rows(0).Cells("Itemid").Value.ToString()

            SetNgDetail(ppid, Itemid, dgDetail)
        End If
    End Sub

    Private Sub SetNgDetail(ppid As String, itemid As String, dgDetail As DataGridView)
        Dim strSQL As String = " exec m_SearchNgData_p '{0}','{1}','{2}','{3}','{4}','{5}','{6}'"

        strSQL = String.Format(strSQL, "", ppid, itemid, "", "", "3", "")

        Try
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            dgDetail.DataSource = dt
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub dgDetail2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDetail2.CellClick
        If e.RowIndex = -1 Then Exit Sub

        SetDataByGrid(dgMainTain.SelectedCells(0).RowIndex, e.RowIndex)

    End Sub


    Private Sub btnOpenWindow_Click(sender As Object, e As EventArgs) Handles btnOpenWindow.Click
        Dim rowIndexD As Integer = dgDetail2.SelectedCells(0).RowIndex
        Dim stateD As String = dgDetail2.Rows(rowIndexD).Cells("colStateid2").Value.ToString

        If stateD <> "D" Then
            LblMSg2.Text = "请选择未维修的数据！"
            'Exit Sub
        End If

        Dim Rcode As String = ""
        If InStr(cobNGdes2.Text, "-") > 0 Then
            Rcode = cobNGdes2.Text.Split("-")(0).Trim
        Else
            Rcode = cobNGdes2.Text
        End If
        Dim Ppid As String = dgMainTain.Rows(dgMainTain.SelectedCells(0).RowIndex).Cells("colPpid").Value.ToString
        Dim itemId As String = dgMainTain.Rows(dgMainTain.SelectedCells(0).RowIndex).Cells("colItemId").Value.ToString
        Dim state As String = dgMainTain.Rows(dgMainTain.SelectedCells(0).RowIndex).Cells("StateStr").Value.ToString

        Dim frm As FrmMainTainHandleDGNewD = New FrmMainTainHandleDGNewD()

        frm.Rcode = Rcode
        frm.ppid = Ppid
        frm.itemid = itemId
        frm.FrmStatus = True
        If state <> "D" And state <> "B" Then
            frm.FrmStatus = False
            'LblMSg2.Text = "请选择未维修的数据！"
            'Exit Sub
        End If

        frm.ShowDialog()

        SetNgDetail(Ppid, itemId, dgDetail2)
        '设置Grid颜色--明细 
        SetGridColor(dgDetail2, "colStateid2")
        Dim dgRowDetail As DataGridViewRow = dgDetail2.Rows(dgMainTain.SelectedCells(0).RowIndex)

        CobcodeType2.Text = dgRowDetail.Cells("colCodeitem2").Value.ToString
        cobNGdes2.Text = dgRowDetail.Cells("colCCName2").Value.ToString
    End Sub

End Class