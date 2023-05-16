Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports DevComponents.DotNetBar

Public Class FrmQCCheck


    ''' <summary>
    ''' 修改者： 黄广都
    ''' 修改日： 2020/01/13
    ''' 修改内容：
    ''' -------------------修改记录---------------------
    ''' 
    ''' </summary>
    ''' <remarks>品质抽检</remarks>
    ''' 

#Region "属性"
    Private m_ItemPpid As String
    Public Property ItemPpid() As String
        Get
            Return m_ItemPpid
        End Get

        Set(ByVal Value As String)
            m_ItemPpid = Value
        End Set
    End Property
    Public Enum EnumdgvCheckDetailGrid
        Partid
        SN
        TypeName
        TestitemName
        SmallName
        CheckStatus
        Result
    End Enum
#End Region

#Region "事件"


    Private Sub FrmQCCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim btn As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        btn.Name = "clear"
        btn.HeaderText = "操作"
        btn.DefaultCellStyle.NullValue = "撤销"
        btn.Width = 60
        dgvCheckSN.Columns.Add(btn)
        '设定用戶權限
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        '菜单权限
        SetMenuRight()

        SetFormControl()
    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frmAdd As New FrmQCAddBatch

        If frmAdd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtMoid.Text = frmAdd.Moid
            Me.txtPartNo.Text = frmAdd.PartNo
            Me.txtMoQty.Text = frmAdd.MoQty
            Me.lbCheckLevel.Text = frmAdd.CheckLevel
            Me.lbCid.Text = frmAdd.CId
            Me.lbFuncQCRatio.Text = frmAdd.FunCheckRatio & "%"
            Me.txtQCQty.Text = frmAdd.QcQty
            If frmAdd.CheckLevel = "加严" Then
                lbCheckLevel.ForeColor = Color.Red
            End If
            GetQcData(Me.lbCid.Text)
            SetCheckType()
            SetBigTestItem()
            GetAQLData()
            GetCheckSn()
            GetCheckSnDetail()
            'GetWaitingData()
            SetFormControl()
        End If
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim frmQuery As New FrmQcQuery

        If frmQuery.ShowDialog() = Windows.Forms.DialogResult.OK Then
            GetQcData(frmQuery.CId)
            SetCheckType()
            SetBigTestItem()
            GetAQLData()
            GetCheckSn()
            GetCheckSnDetail()
            'GetWaitingData()
            If lbCheckLevel.Text = "加严" Then
                lbCheckLevel.ForeColor = Color.Red
            End If


            SetFormControl()

            '检查是否已满足综合判定条件
            CheckQCCheckJudgeCondition()
        End If
    End Sub
   
    Private Sub txtBarCode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtBarCode.PreviewKeyDown
        If e.KeyValue = 13 Then

            If Not String.IsNullOrEmpty(txtBarCode.Text) Then
                Me.m_ItemPpid = txtBarCode.Text
                ScanData()

            End If
        End If
    End Sub
    Private Sub cbbCheckType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbCheckType.SelectedIndexChanged

        If Not IsNothing(cbbCheckType.SelectedValue) Then
            SetBigTestItem()
        End If

    End Sub

    Private Sub btnPcsOk_Click(sender As Object, e As EventArgs) Handles btnPcsOk.Click
        If Not String.IsNullOrEmpty(Me.m_ItemPpid) Then
            'If CheckSnIsHandle(m_ItemPpid) = True And CheckSnAllJudgeHandle(m_ItemPpid) = False Then '再次检查是否满足判定条件
            SetCheckSnAllResult(Me.m_ItemPpid, "PASS")

            '检查是否已满足综合判定条件
            CheckQCCheckJudgeCondition()
            btnPcsOk.Enabled = False
            btnPcsNg.Enabled = False
            lbMsg.Text = Me.m_ItemPpid & ",判定完成！"
            txtPcsResult.Text = "OK"
            GetQcData(lbCid.Text)
            GetCheckSn()
            'cbbCheckType.SelectedIndex = 0
            'cbbBigTestItem.SelectedIndex = 0
            'GetWaitingData()
            'Else
            '    btnPcsOk.Enabled = False
            '    btnPcsNg.Enabled = False
            '    lbMsg.Text = Me.m_ItemPpid & "不满足判定条件！"
            'End If

        End If

    End Sub

    Private Sub btnPcsNg_Click(sender As Object, e As EventArgs) Handles btnPcsNg.Click
        If Not String.IsNullOrEmpty(Me.m_ItemPpid) Then
            If CheckSnIsExistsFail(Me.m_ItemPpid) = False Then
                MessageUtils.ShowWarning("该产品并不存在不良,无法进行拒收!")
                Exit Sub
            End If

            SetCheckSnAllResult(Me.m_ItemPpid, "FAIL")
            '检查是否已满足综合判定条件
            CheckQCCheckJudgeCondition()
            btnPcsOk.Enabled = False
            btnPcsNg.Enabled = False
            lbMsg.Text = Me.m_ItemPpid & ",判定完成,并且该产品已进入不良维修,请尽快进行维修！"
            txtPcsResult.Text = "NG"
            GetQcData(lbCid.Text)
            GetCheckSn()
            cbbCheckType.SelectedIndex = 0
            cbbBigTestItem.SelectedIndex = 0
            'GetWaitingData()
        End If
    End Sub
    Private Sub btnAllOk_Click(sender As Object, e As EventArgs) Handles btnAllOk.Click
        Dim sResult As String = "OK"
        If SaveBatchJudgeResult(sResult) = True Then
            btnAllOk.Enabled = False
            btnAllNg.Enabled = False
            lbMsgResult.Text = "允收成功，本次允收批次[" & lbCid.Text & "]!"
            lbMsgResult.ForeColor = Color.Blue

            '重新加载数据和状态
            GetQcData(lbCid.Text)
            SetCheckType()
            SetBigTestItem()
            GetAQLData()
            GetCheckSn()
            GetCheckSnDetail()
            'GetWaitingData()
            If lbCheckLevel.Text = "加严" Then
                lbCheckLevel.ForeColor = Color.Red
            End If


            SetFormControl()

            '检查是否已满足综合判定条件
            CheckQCCheckJudgeCondition()
        End If

    End Sub

    Private Sub btnAllNg_Click(sender As Object, e As EventArgs) Handles btnAllNg.Click
        Dim sResult As String = "NG"
        If SaveBatchJudgeResult(sResult) = True Then
            btnAllOk.Enabled = False
            btnAllNg.Enabled = False
            lbMsgResult.Text = "批退成功，本次批退批次[" & lbCid.Text & "]!"
            lbMsgResult.ForeColor = Color.Blue

            '重新加载数据和状态
            GetQcData(lbCid.Text)
            SetCheckType()
            SetBigTestItem()
            GetAQLData()
            GetCheckSn()
            GetCheckSnDetail()
            'GetWaitingData()
            If lbCheckLevel.Text = "加严" Then
                lbCheckLevel.ForeColor = Color.Red
            End If


            SetFormControl()

            '检查是否已满足综合判定条件
            CheckQCCheckJudgeCondition()

        End If
    End Sub


    Private Sub btnListCheck_Click(sender As Object, e As EventArgs) Handles btnListCheck.Click

        If String.IsNullOrEmpty(Me.cbbCheckType.Text.ToString) Then
            MessageUtils.ShowWarning("请选择检验类型！")
            Exit Sub
        End If
        If Not Me.cbbCheckType.Text.ToString.Contains("外观") Then
            MessageUtils.ShowWarning("批量检验仅支持外观！")
            Exit Sub
        End If
        If Me.cbbBigTestItem.Text = "" Then
            MessageUtils.ShowWarning("请选择测试大项！")
            Exit Sub
        End If
        If IsNothing(Me.cbbBigTestItem.SelectedValue.ToString) Then
            MessageUtils.ShowWarning("请选择测试大项！")
            Exit Sub
        End If
        If IsNothing(cbbCheckType.SelectedItem) Then

            MessageUtils.ShowWarning("请选择检验类型！")

            Exit Sub
        End If

        Dim iCheckQty As Integer
        iCheckQty = IIf(Me.lbCheckCount.Text = "N/A", 0, CInt(Me.lbCheckCount.Text))
        Dim frm As New FrmQCCheckList
        frm.lbCID.Text = Me.lbCid.Text
        frm.lbMoid.Text = Me.txtMoid.Text
        frm.lbPartNo.Text = Me.txtPartNo.Text
        frm.lbBigTestItem.Text = Me.cbbCheckType.Text.ToString & "+" & Me.cbbBigTestItem.Text.ToString
        frm.lbBigTypeId.Text = Me.cbbBigTestItem.SelectedValue.ToString
        frm.lbCheckType.Text = Me.cbbCheckType.Text.ToString
        frm.lbCheckedQty.Text = iCheckQty
        frm.lbQCqty.Text = Me.txtQCQty.Text
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            GetQcData(Me.lbCid.Text)
            SetCheckType()
            SetBigTestItem()
            GetAQLData()
            GetCheckSn()
            GetCheckSnDetail()
            If lbCheckLevel.Text = "加严" Then
                lbCheckLevel.ForeColor = Color.Red
            End If

            SetFormControl()
            '检查是否已满足综合判定条件
            CheckQCCheckJudgeCondition()


        End If
    End Sub
    Private Sub dgvCheckDetail_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCheckDetail.CellFormatting
        If e.RowIndex > -1 AndAlso Me.dgvCheckDetail.RowCount > 0 Then

            Dim _Status As String
            Dim _Result As String
            If e.ColumnIndex = CInt(EnumdgvCheckDetailGrid.CheckStatus) Then
                If dgvCheckDetail.Columns(e.ColumnIndex).Name = "CheckStatus" Then

                    _Status = Me.dgvCheckDetail.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
                    If _Status = "已检验" Then
                        e.CellStyle.ForeColor = Color.White
                        e.CellStyle.BackColor = Color.Green
                    Else
                        e.CellStyle.ForeColor = Color.Black
                    End If

                End If
            End If
            If e.ColumnIndex = CInt(EnumdgvCheckDetailGrid.Result) Then
                If dgvCheckDetail.Columns(e.ColumnIndex).Name = "Result" Then
                    _Result = Me.dgvCheckDetail.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
                    If _Result = "PASS" Then
                        e.CellStyle.ForeColor = Color.Green

                    Else
                        e.CellStyle.ForeColor = Color.Red
                    End If
                End If

            End If


        End If
    End Sub


    Private Sub dgvCheckSN_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCheckSN.SelectionChanged

        'If Me.dgvCheckSN.RowCount > 0 Then
        '    GetCheckSnDetail()
        'End If

    End Sub

    Private Sub dgvCheckSN_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCheckSN.CellFormatting
        If e.RowIndex > -1 AndAlso Me.dgvCheckSN.RowCount > 0 Then
            Dim sItem As String
            If e.ColumnIndex = 1 OrElse e.ColumnIndex = 2 Then
                sItem = Me.dgvCheckSN.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
                If sItem = "是" Then
                    e.CellStyle.BackColor = System.Drawing.Color.LightGreen
                Else
                    e.CellStyle.BackColor = System.Drawing.SystemColors.Menu
                End If
            End If

            If e.ColumnIndex = 3 Then
                Dim _Result As String
                _Result = Me.dgvCheckSN.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
                If _Result = "已判定" Then
                    e.CellStyle.ForeColor = Color.Green

                Else
                    e.CellStyle.ForeColor = Color.Black

                End If
            End If
        End If


    End Sub
    Private Sub btnRejection_Click(sender As Object, e As EventArgs) Handles btnRejection.Click
        Dim frmReject As New FrmQCReject
        frmReject.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

#End Region

#Region "函数"

    ''' <summary>
    ''' 综合判定
    ''' </summary>
    ''' <remarks></remarks>
    Private Function SaveBatchJudgeResult(ByVal result As String) As Boolean
        Try
            Dim rMsg As String = String.Empty
            Dim rFalg As Integer = 0
            Dim para(8) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@Cid", SqlDbType.VarChar, 50),
                New SqlParameter("@Moid", SqlDbType.VarChar, 50),
                New SqlParameter("@PartNo", SqlDbType.VarChar, 50),
                New SqlParameter("@Result", SqlDbType.VarChar, 50),
                New SqlParameter("@Spoint", SqlDbType.VarChar, 50),
                New SqlParameter("@UserID", SqlDbType.VarChar, 50),
                New SqlParameter("@Msg", SqlDbType.VarChar, 150),
                New SqlParameter("@Falg", SqlDbType.Int, 1)
            }
            parameters(0).Value = lbCid.Text
            parameters(1).Value = txtMoid.Text
            parameters(2).Value = txtPartNo.Text
            parameters(3).Value = result
            parameters(4).Value = My.Computer.Name
            parameters(5).Value = VbCommClass.VbCommClass.UseId
            parameters(6).Direction = ParameterDirection.Output
            parameters(6).Value = rMsg
            parameters(7).Direction = ParameterDirection.Output
            'parameters(7).Value = rFalg

            DbOperateUtils.ExecuteNonQureyByProc("m_QCCheckBatchJudgeAll_P", parameters)
            If parameters(7).Value = 0 Then
                lbMsgResult.Text = "保存信息失败,请联系MES人员!"
                lbMsgResult.ForeColor = Color.Red
                Return False
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 单PCS产品判定
    ''' </summary>
    ''' <param name="Ppid">产品</param>
    ''' <param name="Result">结果</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetCheckSnAllResult(ByVal Ppid As String, ByVal Result As String) As Boolean
        Try
            Dim rMsg As String = String.Empty
            Dim rFalg As Integer = 0
            Dim para(6) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@CID", SqlDbType.VarChar, 50),
                New SqlParameter("@Ppid", SqlDbType.VarChar, 50),
                New SqlParameter("@Result", SqlDbType.VarChar, 50),
                New SqlParameter("@UserID", SqlDbType.VarChar, 50),
                New SqlParameter("@Msg", SqlDbType.VarChar, 150),
                New SqlParameter("@Falg", SqlDbType.Int, 1)
            }
            parameters(0).Value = lbCid.Text
            parameters(1).Value = Ppid
            parameters(2).Value = Result
            parameters(3).Value = VbCommClass.VbCommClass.UseId
            parameters(4).Direction = ParameterDirection.Output
            parameters(4).Value = rMsg
            parameters(5).Direction = ParameterDirection.Output
            DbOperateUtils.ExecuteNonQureyByProc("m_QCCheckPcsProJudge_P", parameters)
            If parameters(5).Value.ToString = "0" Then
                lbMsgResult.Text = "保存信息失败,请联系MES人员!"
                lbMsgResult.ForeColor = Color.Red
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return True
    End Function

    ''' <summary>
    ''' 扫描产品
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScanData()
        Try
            If CheckScanData() = True Then
                Dim sPpid As String = txtBarCode.Text
                Dim IsFail As Boolean = False
                'add by hgd 20200518 有FAIL的产品不能单PCS允收
                IsFail = CheckSnIsExistsFail(sPpid)
                '检查当前SN是否可以判定
                If CheckSnIsHandle(sPpid) = True And CheckSnAllJudgeHandle(sPpid) = False Then

                    btnPcsOk.Enabled = Not IsFail
                    btnPcsNg.Enabled = IsFail
                    lbMsg.Text = sPpid & ",该产品满足单PCS判定条件,可以直接进行判定！"
                    If MessageUtils.ShowConfirm(sPpid & ",该产品满足单PCS判定条件,可以直接进行判定,是否需要继续进行检验？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                Else
                    If Me.dgvCheckSN.RowCount > 0 Then

                        Dim i As Integer = 0
                        Dim chksame As Boolean = False
                        Dim chkwg As Boolean = False '外观
                        Dim chkgn As Boolean = False '功能
                        Dim wgqty As Integer = 0
                        Dim gnqty As Integer = 0
                        For i = 0 To Me.dgvCheckSN.Rows.Count - 1
                            Dim tmpppid As String = Me.dgvCheckSN.Rows(i).Cells("ppid").Value.ToString
                            Dim chkwgstatus As String = Me.dgvCheckSN.Rows(i).Cells("wg").Value.ToString
                            If (chkwgstatus = "是") Then
                                wgqty = wgqty + 1
                            End If
                            Dim chkgnstatus As String = Me.dgvCheckSN.Rows(i).Cells("gn").Value.ToString
                            If (chkgnstatus = "是") Then
                                gnqty = gnqty + 1
                            End If
                            If (tmpppid.ToUpper() = sPpid.ToUpper) Then
                                chksame = True
                            End If
                        Next
                        If (gnqty >= Integer.Parse(txtMinFunQty.Text.Trim)) Then
                            btnPcsOk.Enabled = Not IsFail
                            btnPcsNg.Enabled = IsFail
                            lbMsg.Text = sPpid & ",该检验单功能检验数已满足最小检查条件,可以直接判定！"
                            If MessageUtils.ShowConfirm(sPpid & ",该检验单功能检验数已满足最小检查条件,可以直接判定,是否需要继续进行检验？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                                Exit Sub
                            End If
                        End If
                        If (chksame = False) Then
                            Dim QCQty As Integer = Integer.Parse(txtQCQty.Text.ToString.Trim)
                            Dim checkqty As Integer = Me.dgvCheckSN.RowCount

                            If checkqty + 1 > QCQty Then

                                MessageUtils.ShowWarning("检验数不能大于批次数量,请检查！")
                                txtBarCode.SelectAll()
                                Exit Sub
                            End If
                        End If


                    End If
                End If

                txtPcsResult.Text = "N/A"
                Dim frm As New FrmQCTestItem
                frm.lbCid.Text = Me.lbCid.Text
                frm.lbPartNo.Text = Me.txtPartNo.Text
                frm.lbBarCode.Text = Me.txtBarCode.Text
                frm.lbBigTestItem.Text = Me.cbbCheckType.Text.ToString & "+" & Me.cbbBigTestItem.Text.ToString
                frm.lbBigTypeId.Text = Me.cbbBigTestItem.SelectedValue.ToString

                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    lbMsg.Text = sPpid & ",检验项[" & cbbBigTestItem.Text.ToString & "]检验完成！"
                    txtBarCode.Text = ""
                    GetQcData(Me.lbCid.Text)
                    GetCheckSn()
                    GetCheckSnDetail()
                    IsFail = CheckSnIsExistsFail(sPpid)
                    If CheckSnIsHandle(sPpid) = True Then
                        btnPcsOk.Enabled = Not IsFail
                        btnPcsNg.Enabled = IsFail
                        lbMsg.Text = sPpid & ",该产品已满足单PCS判定条件,请进行判定！"
                    Else
                        btnPcsOk.Enabled = False
                        btnPcsNg.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' 扫描验证
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckScanData() As Boolean

        If Me.cbbBigTestItem.Text = "" Then
            MessageUtils.ShowWarning("请选择测试大项！")
            Return False
        End If
        If IsNothing(Me.cbbBigTestItem.SelectedValue.ToString) Then
            MessageUtils.ShowWarning("请选择测试大项！")
            Return False
        End If
        If IsNothing(cbbCheckType.SelectedItem) Then

            MessageUtils.ShowWarning("请选择检验类型！")

            Return False
        End If
        If String.IsNullOrEmpty(txtBarCode.Text) Then
            MessageUtils.ShowWarning("扫描的SN错误,请检查！")
            txtBarCode.SelectAll()
            Return False
        End If
        If SnCheckInput() = False Then
            txtBarCode.SelectAll()
            Return False
        End If



        Return True
    End Function


    ''' <summary>
    ''' 检查产品是否已进入维修
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SnCheckInput() As Boolean
        Try

            Dim rMsg As String = String.Empty
            Dim rFalg As Integer = 0
            Dim para(7) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@CID", SqlDbType.VarChar, 50),
                New SqlParameter("@Ppid", SqlDbType.VarChar, 50),
                 New SqlParameter("@Moid", SqlDbType.VarChar, 50),
                New SqlParameter("@PartNo", SqlDbType.VarChar, 50),
                 New SqlParameter("@TestBigType", SqlDbType.VarChar, 50),
                New SqlParameter("@Msg", SqlDbType.NVarChar, 150),
                New SqlParameter("@RTVALUE", SqlDbType.VarChar, 1)
            }
            parameters(0).Value = lbCid.Text
            parameters(1).Value = txtBarCode.Text
            parameters(2).Value = txtMoid.Text
            parameters(3).Value = txtPartNo.Text
            parameters(4).Value = Me.cbbBigTestItem.SelectedValue.ToString
            parameters(5).Direction = ParameterDirection.Output
            parameters(6).Direction = ParameterDirection.Output
            DbOperateUtils.ExecuteNonQureyByProc("m_QCCheckPcsCheckInput", parameters)
            If parameters(6).Value.ToString = "1" Then

                MessageUtils.ShowWarning(parameters(5).Value.ToString)
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 检查该产品是否已存在FAIL记录
    ''' </summary>
    ''' <param name="Ppid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckSnIsExistsFail(ByVal Ppid As String) As Boolean
        Try
            Dim strSql As String
            strSql = "  select * from m_QCCheckSnDetail_t where CID='" & lbCid.Text & "' AND SN='" & Ppid & "' AND Result='FAIL' "
            Dim i As Integer = DbOperateUtils.GetRowsCount(strSql)
            If i > 0 Then
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function
    ''' <summary>
    ''' 检查单PCS产品是否已全部检验
    ''' </summary>
    ''' <param name="Ppid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckSnIsHandle(ByVal Ppid As String) As Boolean
        Dim sb As New StringBuilder
        Try
            Dim rMsg As String = String.Empty
            Dim rFalg As Integer = 0
            Dim para(4) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@CID", SqlDbType.VarChar, 50),
                New SqlParameter("@Ppid", SqlDbType.VarChar, 50),
                New SqlParameter("@PartNo", SqlDbType.VarChar, 50),
                New SqlParameter("@RTVALUE", SqlDbType.VarChar, 1)
            }
            parameters(0).Value = lbCid.Text
            parameters(1).Value = Ppid
            parameters(2).Value = txtPartNo.Text
            parameters(3).Direction = ParameterDirection.Output
            DbOperateUtils.ExecuteNonQureyByProc("m_QCCheckPcsIsAllowJudge_P", parameters)
            If parameters(3).Value.ToString = "1" Then
                Return False
            End If


            '           	@CID		 VARCHAR(150),			--检验批次
            '@Ppid		 VARCHAR(150),			--检验批次
            '@PartNo		VARCHAR(50),			--料号编码      
            '@RTVALUE    VARCHAR(1) OUTPUT		--錯誤信息編號     
            'sb.Append("select t.SmallName,CID ")
            'sb.Append(" from(select a.TestitemID,a.Partid,a.TypeName,B.TestitemName,C.SmallName,C.SmallID  from m_QCProducttesttype_t a  inner join ")
            'sb.Append(" m_QCProducttestingM_t b on b.TypedataID=a.TestitemID and b.Partid=a.Partid inner join  ")
            'sb.Append(" m_QCProducttestingMson_t c on c.large=b.ID and c.Partid=b.Partid")
            'sb.Append(" where a.Partid='" & txtPartNo.Text & "') t left join ")
            'sb.Append(" m_QCCheckSnDetail_t  h on h.SmallTypeId=t.SmallID and h.CId='" & lbCid.Text & "' and h.SN='" & Ppid & "' WHERE CID IS NULL")
            'Dim i As Integer = DbOperateUtils.GetRowsCount(sb.ToString)
            'If i > 0 Then
            '    Return False
            'End If
        Catch ex As Exception
            Throw ex
        End Try
        Return True
    End Function
    ''' <summary>
    ''' 检查单PCS产品是否已判定
    ''' </summary>
    ''' <param name="Ppid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckSnAllJudgeHandle(ByVal Ppid As String) As Boolean
        Dim sb As New StringBuilder
        Try
            sb.Append("SELECT * FROM m_QCCheckSnAllResult_t where  CID='" & lbCid.Text & "'  AND SN='" & Ppid & "'  ")
            Dim i As Integer = DbOperateUtils.GetRowsCount(sb.ToString)
            If i > 0 Then
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function


    ''' <summary>
    ''' 获取检验批次相关信息
    ''' </summary>
    ''' <param name="cid"></param>
    ''' <remarks></remarks>
    Private Sub GetQcData(ByVal cid As String)
        Try
            Dim sb As New StringBuilder
            sb.Append(" select a.CId,a.Moid,a.PartNo,b.Moqty,a.CheckLevel,a.CheckQty,a.FunCheckRatio,a.OKQty,a.NgQty,a.NgQty,a.MA_Qty,a.MI_Qty,a.CR_Qty  ")
            sb.Append(" ,ceiling(CheckQty*(FunCheckRatio/100.0)) as MinFunQty,a.Status from m_QCCheckMain_t  a left join m_Mainmo_t b on b.Moid=a.Moid  where  a.Cid='" & cid & "' ")
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sb.ToString)
            If dt.Rows.Count > 0 Then
                Me.lbCid.Text = dt.Rows(0)!Cid.ToString
                Me.lbCheckLevel.Text = dt.Rows(0)!CheckLevel.ToString
                Me.lbFuncQCRatio.Text = dt.Rows(0)!FunCheckRatio.ToString & "%"
                Me.txtMinFunQty.Text = dt.Rows(0)!MinFunQty.ToString
                Me.txtMoid.Text = dt.Rows(0)!Moid.ToString
                Me.txtPartNo.Text = dt.Rows(0)!PartNo.ToString
                Me.txtMoQty.Text = dt.Rows(0)!MoQty.ToString
                Me.txtQCQty.Text = dt.Rows(0)!CheckQty.ToString
                Me.lbNgQty.Text = dt.Rows(0)!NgQty.ToString
                Me.lbOKQty.Text = dt.Rows(0)!OKQty.ToString

                Me.lbDefectQty.Text = dt.Rows(0)!MA_Qty.ToString & "/" & dt.Rows(0)!MI_Qty.ToString & "/" & dt.Rows(0)!CR_Qty.ToString
                Me.txtUserName.Text = VbCommClass.VbCommClass.UseName
                lbStatus.Text = dt.Rows(0)!Status.ToString
                lbMsgResult.Text = ""
                lbMsg.Text = ""
                txtPcsResult.Text = "N/A"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' ''' <summary>
    ' ''' 待检区
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub GetWaitingData()
    '    Try
    '        Dim sb As New StringBuilder
    '        sb.Append(" SELECT Ppid,CASE WHEN STATUS='N' THEN N'待检验' ELSE N'检验中' END WaitingState FROM m_QCCheckInSnList_t ")
    '        sb.Append(" WHERE Moid='" & txtMoid.Text & "' AND (Status='N' OR Status='I')")

    '        Dim dt As DataTable = DbOperateUtils.GetDataTable(sb.ToString)
    '         Me.dgvWaiting.DataSource = dt
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    ''' <summary>
    ''' 获取抽验计划
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetAQLData()
        Try
            Dim sb As New StringBuilder
            sb.Append(" select A.Samplingname,c.ConfigQty,'QTY' AS ConfigUnit,a.MA_RejectQty,a.MI_RejectQty,a.CR_RejectQty")
            sb.Append(" from m_QCSamplingPlan_t  a left join m_RPartStationD_t b on b.QCPlanId= a.SamplingId  and b.IsQCPlan='Y' left join  ")
            sb.Append(" (SELECT SamplingId,ConfigQty,'N' AS SamplingType FROM m_QCSamplingPlanDetail_t WHERE  IsDefault='Y' ")
            sb.Append(" UNION ALL SELECT SamplingId,ConfigQty,'C' AS SamplingType FROM m_QCSamplingPlanCapacityDetail_t  WHERE  IsEnable='Y' ")
            sb.Append(" ) c on c.SamplingId=a.SamplingId AND C.SamplingType=A.SamplingType ")
            sb.Append(" where  a.Usey='Y' AND  b.IsQCPlan='Y' AND B.PPartid='" & Me.txtPartNo.Text & "' AND B.STATE='1' ")
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sb.ToString)
            Me.dgvAQL.DataSource = dt

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 获取已检验的SN
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetCheckSn()
        Try
            Dim strSql As New StringBuilder
            strSql.Append(" EXEC GetQCCheckSnJudgeList  '" & lbCid.Text & "','" & txtPartNo.Text & "'")


            'strSql.Append("SELECT a.Ppid, MAX(CASE WHEN a.CheckType=N'外观' then	N'OK' else 'N/A' END) WG,")
            'strSql.Append("MAX(CASE  WHEN a.CheckType=N'功能' then N'OK' else 'N/A' END) GN,")
            'strSql.Append("   case when b.SN is null then N'未判定' else N'已判定' end JudgeStatus ")
            'strSql.Append("  FROM  (select CId,SN AS Ppid,CheckType from m_QCCheckSnResult_t where CId='" & lbCid.Text & "' ")
            'strSql.Append(" group by CId,SN,CheckType)a LEFT JOIN ")
            'strSql.Append(" m_QCCheckSnAllResult_t b on b.CId=a.CId and b.SN=a.Ppid  GROUP BY a.Ppid,b.SN ")

            'strSql.Append("SELECT a.Ppid,case when b.SN is null then N'未判定' else N'已判定' end JudgeStatus  FROM  ")
            'strSql.Append(" (select CId,SN AS Ppid from m_QCCheckSnResult_t where CId='" & lbCid.Text & "'  ")
            'strSql.Append(" group by CId,SN) a LEFT JOIN ")
            'strSql.Append(" m_QCCheckSnAllResult_t b on b.CId=a.CId and b.SN=a.Ppid ")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql.ToString)
            dgvCheckSN.DataSource = dt
            lbCheckCount.Text = dt.Rows.Count
            Dim dvQC As DataView = New DataView(dt.Copy)

            dvQC.RowFilter = "JudgeStatus='未判定'"
            lbNoJudge.Text = dvQC.Count
            dvQC.RowFilter = "GN='是'"
            lbFuncQty.Text = CInt(txtMinFunQty.Text) - dvQC.Count
            If Me.lbStatus.Text = "Y" Then
                dgvCheckSN.Columns("clear").Visible = False
            Else
                dgvCheckSN.Columns("clear").Visible = True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 获取产品检验细项
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetCheckSnDetail()
        Try
            Dim sb As New StringBuilder
            Dim sPpid As String

            If Me.dgvCheckSN.Rows.Count > 0 Then
                sPpid = Me.dgvCheckSN.CurrentRow.Cells("ppid").Value.ToString()
                sb.Append("select t.Partid,'" & sPpid & "' as SN,t.TypeName,t.TestitemName,t.SmallName ,")
                sb.Append(" case when h.Cid is null then N'未检验' else N'已检验' END CheckStatus,h.Result,q.CCName,q.CLevel ")
                sb.Append(" from (select DISTINCT a.TypeID,b.Partid,a.TypeName,B.TestitemName,C.SmallName,C.SmallID  from m_QCTypedata_t a  inner join ")
                sb.Append(" m_QCProducttestingM_t b on b.TypedataID=a.TypeID and b.Effective='Y'  inner join   ")
                sb.Append(" m_QCProducttestingMson_t c on c.large=b.ID and c.Partid=b.Partid and c.Effective='Y' ")
                sb.Append(" where b.Partid='" & txtPartNo.Text & "') t left join ")
                sb.Append(" m_QCCheckSnDetail_t  h on h.SmallTypeId=t.SmallID and h.CId='" & lbCid.Text & "' and  h.SN='" & sPpid & "' ")
                sb.Append(" left join m_Code_t q on q.CodeID=h.NgCodeId ")

                Dim dt As DataTable = DbOperateUtils.GetDataTable(sb.ToString)
                dgvCheckDetail.DataSource = dt
            Else
                sPpid = ""
                sb.Append("select top 0 t.Partid,'" & sPpid & "' as SN,t.TypeName,t.TestitemName,t.SmallName ,")
                sb.Append(" case when h.Cid is null then N'未检验' else N'已检验' END CheckStatus,h.Result,q.CCName,q.CLevel  ")
                sb.Append(" from (select DISTINCT a.TypeID,b.Partid,a.TypeName,B.TestitemName,C.SmallName,C.SmallID  from m_QCTypedata_t a  inner join ")
                sb.Append(" m_QCProducttestingM_t b on b.TypedataID=a.TypeID and b.Effective='Y'  inner join   ")
                sb.Append(" m_QCProducttestingMson_t c on c.large=b.ID and c.Partid=b.Partid and c.Effective='Y' ")
                sb.Append(" where b.Partid='" & txtPartNo.Text & "') t left join ")
                sb.Append(" m_QCCheckSnDetail_t  h on h.SmallTypeId=t.SmallID and h.CId='" & lbCid.Text & "' and  h.SN='" & sPpid & "' ")
                sb.Append(" left join m_Code_t q on q.CodeID=h.NgCodeId ")
                Dim dt As DataTable = DbOperateUtils.GetDataTable(sb.ToString)
                dgvCheckDetail.DataSource = dt
            End If

        Catch 'ex As Exception
            '  Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 检查是否达到综合判定条件
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckQCCheckJudgeCondition()
        Try
            Dim rReturn As String = String.Empty
            Dim para(3) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@Cid", SqlDbType.VarChar, 50),
                New SqlParameter("@PartNo", SqlDbType.VarChar, 50),
                New SqlParameter("@RTVALUE", SqlDbType.VarChar, 1)
            }
            parameters(0).Value = lbCid.Text
            parameters(1).Value = txtPartNo.Text
            parameters(2).Direction = ParameterDirection.Output

            DbOperateUtils.ExecuteNonQureyByProc("m_QCCheckJudgeCondition_P", parameters)



            Select Case parameters(2).Value.ToString
                Case "1"
                    '未满足综合判定条件
                    Me.btnAllOk.Enabled = False
                    Me.btnAllNg.Enabled = False
                Case "3"
                    '满足判退条件
                    Me.btnAllOk.Enabled = False
                    Me.btnAllNg.Enabled = True
                Case "6"
                    '满足综合判定条件
                    Me.btnAllOk.Enabled = True
                    Me.btnAllNg.Enabled = True
                Case Else
                    Me.btnAllOk.Enabled = False
                    Me.btnAllNg.Enabled = False
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 获取检验类型
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetCheckType()
        Try
            Dim strSql As New StringBuilder
            strSql.Append(" select DISTINCT b.TypeID,b.TypeName From m_QCProducttestingM_t a inner join ")
            strSql.Append(" m_QCTypedata_t b on b.TypeID=a.TypedataID  where a.Partid='" & txtPartNo.Text & "' and  a.EFFECTIVE='Y'")
            'strSql = " select DISTINCT TestitemID,TypeName  from m_QCProducttesttype_t where Partid='" & txtPartNo.Text & "' and Effective='Y' "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                Me.cbbCheckType.DataSource = dt
                Me.cbbCheckType.DisplayMember = "TypeName"
                Me.cbbCheckType.ValueMember = "TypeID"

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 获取检验大项
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetBigTestItem()
        Try
            Dim strSql As String
            strSql = " SELECT ID,TestitemName  FROM  m_QCProducttestingM_t where Partid='" & txtPartNo.Text & "' and TypedataID='" & Me.cbbCheckType.SelectedValue.ToString & "' and Effective='Y' "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                Me.cbbBigTestItem.DataSource = dt
                Me.cbbBigTestItem.DisplayMember = "TestitemName"
                Me.cbbBigTestItem.ValueMember = "ID"

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ClearDataRow(ByVal strCid As String, ByVal strPpid As String)
        Try
            Dim sb As New StringBuilder
            Dim strUser As String = VbCommClass.VbCommClass.UseId
            Dim sCheckType As String = String.Empty
           
            '插入数据明细表
            Dim Msg As String = Nothing
            Dim Falg As Integer
            Dim para(6) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@Cid", SqlDbType.VarChar, 50),
                New SqlParameter("@Ppid", SqlDbType.VarChar, 50),
                New SqlParameter("@IsDel", SqlDbType.VarChar, 50),
                New SqlParameter("@UserID", SqlDbType.NVarChar, 10),
                New SqlParameter("@Msg", SqlDbType.NVarChar, 300),
                New SqlParameter("@Falg", SqlDbType.Int, 20)
            }
            parameters(0).Value = strCid
            parameters(1).Value = strPpid
            parameters(2).Value = "Y"
            parameters(3).Value = strUser
            parameters(4).Direction = ParameterDirection.Output
            parameters(4).Value = Msg
            parameters(5).Direction = ParameterDirection.Output
            parameters(5).Value = Falg
            DbOperateUtils.ExecuteNonQureyByProc("m_QCCheckPcsProJudgeCancel_P", parameters)
            If parameters(5).Value.ToString = "0" Then
                MessageUtils.ShowError("清除数据失败，请检查！" + parameters(4).Value.ToString)
                Return
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 设置菜单权限-用户权限设定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMenuRight()
        Me.btnRejection.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.btnRejection.Tag) = "YES", True, False)
    End Sub

    ''' <summary>
    ''' 设置界面
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetFormControl()

        btnPcsNg.Enabled = False
        btnPcsOk.Enabled = False
        btnAllNg.Enabled = False
        btnAllOk.Enabled = False
        txtBarCode.Text = ""
        lbMsg.Text = ""
        lbMsgResult.Text = ""
        txtPcsResult.Text = "N/A"
        txtPcsResult.ForeColor = Color.Blue

    End Sub
#End Region




#Region "Grid行数"
    'Private Sub gridView_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvCheckSN.RowPostPaint
    '    Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
    '        e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
    '    End Using
    'End Sub
#End Region




    'Private Sub dgvCheckSN_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvCheckSN.RowPrePaint

    '    If e.RowIndex < dgvCheckSN.Rows.Count Then
    '        'If Me.btnAllOk.Enabled Then
    '        '    dgvCheckSN("clear", e.RowIndex) = New DataGridViewTextBoxCell()
    '        '    dgvCheckSN("clear", e.RowIndex).Value = ""
    '        'Else
    '        '    dgvCheckSN("clear", e.RowIndex) = New DataGridViewButtonCell()
    '        '    dgvCheckSN("clear", e.RowIndex).Value = "清空"
    '        'End If

    '    End If
    'End Sub

    Private Sub dgvCheckSN_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)


    End Sub

    Private Sub dgvCheckSN_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvCheckSN.RowStateChanged
        e.Row.HeaderCell.Value = String.Format("{0}", e.Row.Index + 1)
    End Sub

    Private Sub dgvCheckSN_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCheckSN.CellClick
        If dgvCheckSN.Columns(e.ColumnIndex).Name = "clear" And e.RowIndex >= 0 Then
            Dim cid As String = lbCid.Text.ToString()
            Dim ppid As String = Me.dgvCheckSN.CurrentRow.Cells("ppid").Value.ToString()
            If (MessageBox.Show("确定撤销并清除" & ppid & "检验数据?", "提示", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                Try
                    ClearDataRow(cid, ppid)
                    GetQcData(lbCid.Text)
                    'SetCheckType()
                    'SetBigTestItem()
                    GetAQLData()
                    GetCheckSn()
                    GetCheckSnDetail()
                    If lbCheckLevel.Text = "加严" Then
                        lbCheckLevel.ForeColor = Color.Red
                    End If


                    SetFormControl()

                    '检查是否已满足综合判定条件
                    CheckQCCheckJudgeCondition()
                Catch ex As Exception

                End Try
            End If



        End If
        If dgvCheckSN.Columns(e.ColumnIndex).Name <> "clear" And e.RowIndex >= 0 Then
            If Me.dgvCheckSN.RowCount > 0 Then
                GetCheckSnDetail()
            End If
        End If
    End Sub

    Private Sub btnNoCheck_Click(sender As Object, e As EventArgs) Handles btnNoCheck.Click
        Dim frm As New FrmQCNoCheck

        frm.ShowDialog()

    End Sub
End Class