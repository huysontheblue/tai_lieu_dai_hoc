Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame


Public Class FrmQCReject

    ''' <summary>
    ''' 修改者： 黄广都
    ''' 修改日： 2020/01/13
    ''' 修改内容：
    ''' -------------------修改记录---------------------
    ''' 
    ''' </summary>
    ''' <remarks>品质抽检-拒收区</remarks>
    ''' 
#Region "属性"
    Private m_ChkboxAll As New CheckBox
#End Region

#Region "事件"

    Private Sub FrmQCReject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData("")
        If Not Me.dgvMain.CurrentRow Is Nothing Then
            Dim sCid As String
            sCid = Me.dgvMain.CurrentRow.Cells(0).Value.ToString()
            GetDetail(sCid)
        End If

    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If GetData("") = True Then
            If Not Me.dgvMain.CurrentRow Is Nothing Then
                Dim sCid As String
                sCid = Me.dgvMain.CurrentRow.Cells(0).Value.ToString()
                GetDetail(sCid)
            End If
        End If

    End Sub

    Private Sub toolScrap_Click(sender As Object, e As EventArgs) Handles toolScrap.Click
        '报废
        Me.cbbReStationId.Enabled = False
        Me.btnSelectOk.Enabled = False
        Dim cId As String

        Dim sType As String = String.Empty
        If Me.dgvMain.RowCount < 1 OrElse Me.dgvMain.CurrentRow Is Nothing Then Exit Sub


        sType = IIf(Me.dgvMain.RowCount = 1, "N/A", "")
        Me.dgvMain.EndEdit()
        cId = Me.dgvMain.CurrentRow.Cells(0).Value.ToString()
        If CheckCidIsSelectHandle(cId) = False Then
            MessageUtils.ShowWarning("该批次存在被挑选,无法报废处理!")
            Exit Sub
        End If

        If MessageUtils.ShowConfirm("你确定要将此批进行报废处理吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim frm As Frmimag = New Frmimag()
            frm.cId = cId
            'frm.ShowDialog()
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If SetScrapData() = True Then
                    MessageUtils.ShowInformation("报废成功！")

                    If GetData(sType) = True Then
                        If Not Me.dgvMain.CurrentRow Is Nothing Then
                            Dim sCid As String
                            sCid = Me.dgvMain.CurrentRow.Cells(0).Value.ToString()
                            GetDetail(sCid)
                        Else

                            GetDetail("N/A")
                        End If
                        Exit Sub
                    End If

                End If
            Else
                MessageBox.Show("报废失败没有上传附件")
            End If
            Exit Sub
        End If
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        '挑选
        Me.cbbReStationId.Enabled = True
        Me.btnSelectOk.Enabled = True


    End Sub

    Private Sub btnAccepted_Click(sender As Object, e As EventArgs) Handles btnAccepted.Click
        '特采
        Me.cbbReStationId.Enabled = False
        Me.btnSelectOk.Enabled = False
        Dim sType As String = String.Empty
        Dim cId As String
        If Me.dgvMain.RowCount < 1 OrElse Me.dgvMain.CurrentRow Is Nothing Then Exit Sub


        sType = IIf(Me.dgvMain.RowCount = 1, "N/A", "")
        Me.dgvMain.EndEdit()
        cId = Me.dgvMain.CurrentRow.Cells(0).Value.ToString()
        If CheckCidIsSelectHandle(cId) = False Then
            MessageUtils.ShowWarning("该批次存在被挑选,无法特采处理!")
            Exit Sub
        End If

        If MessageUtils.ShowConfirm("你确定要将此批进行特采处理吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Dim frm As Frmimag = New Frmimag()
            frm.cId = cId
            'frm.ShowDialog()
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If SetAcceptedData() = True Then
                    MessageUtils.ShowInformation("特采成功！")
                    If GetData(sType) = True Then
                        If Not Me.dgvMain.CurrentRow Is Nothing Then
                            Dim sCid As String
                            sCid = Me.dgvMain.CurrentRow.Cells(0).Value.ToString()
                            GetDetail(sCid)
                        Else
                            GetDetail("N/A")
                        End If
                    End If

                End If
                Exit Sub
            Else
                MessageBox.Show("特采失败没有上传附件")
            End If
            Exit Sub
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub dgvMain_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMain.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso Me.dgvMain.RowCount > 0 Then
            Dim sCid As String
            sCid = Me.dgvMain.CurrentRow.Cells(0).Value.ToString()

            '加载单身
            GetDetail(sCid)




        End If
    End Sub
    Private Sub btnSelectOk_Click(sender As Object, e As EventArgs) Handles btnSelectOk.Click
        If Me.dgvDetail.RowCount < 1 OrElse Me.dgvDetail.CurrentRow Is Nothing Then Exit Sub
        Dim sType As String = String.Empty
        Dim isCheck As Boolean = False

        sType = IIf(Me.dgvMain.RowCount = 1, "N/A", "")
        If String.IsNullOrEmpty(cbbReStationId.SelectedValue.ToString) Then
            MessageUtils.ShowWarning("请指定返回工站!")
            Exit Sub
        End If
        Me.dgvDetail.EndEdit()
        For Each Row As DataGridViewRow In Me.dgvDetail.Rows
            If Not Row.Cells(0).Value Is Nothing Then
                If Row.Cells(0).Value.ToString = "True" Then
                    isCheck = True
                End If
            End If
        Next
        If isCheck = False Then
            MessageUtils.ShowWarning("请勾选产品!")
            Exit Sub
        End If
        If MessageUtils.ShowConfirm("你确定要将被选择的SN返回至指定站点吗？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If SetSelectData() = True Then
                MessageUtils.ShowInformation("挑选成功！")
                Dim sCid As String
                sCid = Me.dgvMain.CurrentRow.Cells(0).Value.ToString()
                GetDetail(sCid)
            Else
                MessageUtils.ShowWarning("挑选失败！")
            End If
            Exit Sub
        End If
    End Sub
    Private Sub dgvDetail_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvDetail.CellPainting
        Try
            If e.RowIndex = -1 And e.ColumnIndex = 0 Then
                Dim p As Point = Me.dgvDetail.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Location
                p.Offset(CInt("0"), CInt("0"))
                Me.m_ChkboxAll.Location = p

                Me.m_ChkboxAll.Size = dgvDetail.Columns(0).HeaderCell.Size
                Me.m_ChkboxAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer))

                Me.m_ChkboxAll.Visible = True
                Me.m_ChkboxAll.BringToFront()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmQCReject", "dgvDetail_CellPainting", "sys")
        End Try
    End Sub

    Private Sub dgvDetail_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvDetail.CellBeginEdit
        If e.ColumnIndex > 0 Then
            e.Cancel = True
        End If
    End Sub
    Private Sub dgvDetail_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvDetail.CellFormatting
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 4 AndAlso Me.dgvDetail.RowCount > 0 Then

            '设置状态字体颜色
            Dim _Status As String
            _Status = Me.dgvDetail.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString

            If Not String.IsNullOrEmpty(_Status) Then
                Me.dgvDetail.Rows(e.RowIndex).Cells(0).ReadOnly = True
                Me.dgvDetail.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Silver
                e.CellStyle.ForeColor = Color.Blue
            Else
                e.CellStyle.ForeColor = Color.Black
            End If

        End If


    End Sub



    ''' <summary>
    ''' 全选
    ''' </summary>
    Private Sub m_ChkboxAll_CheckedChanged(ByVal send As Object, ByVal e As System.EventArgs)
        Me.dgvDetail.EndEdit()
        If Me.dgvDetail.Rows.Count <= 0 Then Exit Sub

        For Each Row As DataGridViewRow In Me.dgvDetail.Rows
            If String.IsNullOrEmpty(Row.Cells(3).ToString) Then
                Row.Cells(0).Value = False
            Else
                Row.Cells(0).Value = IIf(m_ChkboxAll.Checked = True, True, False)
            End If

        Next
    End Sub
#End Region


#Region "函数"
    Private Function GetData(ByVal stype As String) As Boolean
        Try
            Dim strSql As New StringBuilder
            strSql.Append("SELECT CId,moid,PartNo,CreateUserId,CreateTime FROM m_QCCheckMain_t where result='NG' ")

            If stype = "N/A" Then
                strSql.Append(" and CId='" & stype & "'")
            Else
                If Not String.IsNullOrEmpty(txtCid.Text) Then
                    strSql.Append(" and CId='" & txtCid.Text & "'")
                End If
                If Not String.IsNullOrEmpty(txtMoid.Text) Then
                    strSql.Append(" and moid='" & txtMoid.Text & "'")
                End If
                If Not String.IsNullOrEmpty(txtPartNo.Text) Then
                    strSql.Append(" and PartNo='" & txtPartNo.Text & "'")
                End If
            End If
            strSql.Append(" order by CreateTime asc")
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql.ToString)
            dgvMain.DataSource = dt
            If dgvMain.Rows.Count < 0 Then
                dgvMain.Rows(0).Selected = True
            End If

            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmQCReject", "GetData", "sys")
        End Try
    End Function

    Private Sub GetDetail(ByVal cId As String)
        Try

            Dim strSql As String

            Dim sPartNo As String

            strSql = " SELECT ppid,Cartonid ,CreateTime,case when Status='T' then N'已挑选' else N'' end SelStatus FROM m_QCCheckRejectRangePpid_t where CID='" & cId & "'"

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

            dgvDetail.DataSource = dt
            Me.lbCount.Text = dt.Rows.Count
            '添加全选
            Me.m_ChkboxAll.Text = "选择"

            Me.dgvDetail.Controls.Add(Me.m_ChkboxAll)


            AddHandler m_ChkboxAll.CheckedChanged, AddressOf m_ChkboxAll_CheckedChanged
            AddHandler dgvDetail.CellPainting, AddressOf dgvDetail_CellPainting
            Me.dgvDetail.ClearSelection()
            If Me.dgvDetail.RowCount > 0 Then
                Me.dgvDetail.Item(0, 0).Selected = True

                If Not Me.dgvMain.CurrentRow Is Nothing Then
                    sPartNo = Me.dgvMain.CurrentRow.Cells(2).Value.ToString()
                    'sPpid = GetReStationidForPpid(cId)
                    If Not String.IsNullOrEmpty(sPartNo) Then
                        BindComboxStationId(cbbReStationId, sPartNo)
                    End If
                    GetCheckMainBatchData(cId)
                End If


            End If


        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmQCReject", "GetDetail", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 检查本批次是否已存在挑选
    ''' </summary>
    ''' <param name="Cid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckCidIsSelectHandle(ByVal Cid As String)
        Try
            Dim strSql = "SELECT * FROM m_QCCheckRejectRangePpid_t where Cid='" & Cid & "' and Status='T'"
            Dim i As Integer = DbOperateUtils.GetRowsCount(strSql)
            If i > 0 Then
                Return False
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmQCReject", "CheckCidIsSelectHandle", "sys")
        End Try
        Return True
    End Function

    ''' <summary>
    ''' 获取检验批次主数量
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetCheckMainBatchData(ByVal Cid As String)
        Try
            Dim strSql = "SELECT CheckQty,OkQty,NgQty,MA_Qty,MI_Qty,CR_Qty FROM m_QCCheckMain_t WHERE CId='" & Cid & "'"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                Me.lbCheckQty.Text = dt.Rows(0)!CheckQty.ToString
                Me.lbOKQty.Text = dt.Rows(0)!OkQty.ToString
                Me.lbNgQty.Text = dt.Rows(0)!NgQty.ToString
                Me.lbDefectQty.Text = dt.Rows(0)!MA_Qty.ToString & "/" & dt.Rows(0)!MI_Qty.ToString & "/" & dt.Rows(0)!CR_Qty.ToString
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmQCReject", "GetCheckMainBatchData", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 报废
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetScrapData() As Boolean

        Try
            Dim cId As String
            Dim CheckType As String
            Me.dgvMain.EndEdit()
            cId = Me.dgvMain.CurrentRow.Cells(0).Value.ToString()
            CheckType = "F"
            If SetQCCheckRejectHandle(cId, CheckType, "", "") = True Then
                Return True
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmQCReject", "SetScrapData", "sys")
        End Try
        Return False
    End Function
    ''' <summary>
    ''' 特采
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetAcceptedData() As Boolean

        Try
            Dim cId As String
            Dim CheckType As String
            Me.dgvMain.EndEdit()
            cId = Me.dgvMain.CurrentRow.Cells(0).Value.ToString()
            CheckType = "T"
            If SetQCCheckRejectHandle(cId, CheckType, "", "") = True Then
                Return True
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmQCReject", "SetAcceptedData", "sys")
        End Try
        Return False
    End Function
    ''' <summary>
    ''' 挑选
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetSelectData() As Boolean

        Try
            Dim cId As String
            Dim CheckType As String
            Dim Ppid As String
            Dim Restaionid As String
            Dim sReturn As Boolean = True
            Me.dgvDetail.EndEdit()
            cId = Me.dgvMain.CurrentRow.Cells(0).Value.ToString()
            CheckType = "S"
            Restaionid = Me.cbbReStationId.SelectedValue.ToString
            For Each Row As DataGridViewRow In Me.dgvDetail.Rows
                If Not Row.Cells(0).Value Is Nothing Then
                    If Row.Cells(0).Value.ToString = "True" Then
                        Ppid = Row.Cells(1).Value.ToString()
                        If SetQCCheckRejectHandle(cId, CheckType, Ppid, Restaionid) = False Then
                            sReturn = False
                            Exit For
                        End If

                    End If
                End If
            Next
            Return sReturn
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmQCReject", "SetSelectData", "sys")
        End Try
        Return True
    End Function

    ''' <summary>
    ''' 拒收区数据处理
    ''' </summary>
    ''' <param name="cId">批次号</param>
    ''' <param name="CheckType">类型（特采 T、挑选 S、报废 F） </param>
    ''' <param name="Ppid">产品条码</param>
    ''' <param name="ReStationid">返回工站</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetQCCheckRejectHandle(ByVal cId As String, ByVal CheckType As String, ByVal Ppid As String, ByVal ReStationid As String) As Boolean

        Try
            Dim para(7) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@Cid", SqlDbType.VarChar, 50),
                New SqlParameter("@CheckType", SqlDbType.VarChar, 50),
                New SqlParameter("@Ppid", SqlDbType.VarChar, 50),
                New SqlParameter("@ReStationid", SqlDbType.VarChar, 50),
                New SqlParameter("@Spoint", SqlDbType.VarChar, 50),
                New SqlParameter("@UserID", SqlDbType.VarChar, 50),
                New SqlParameter("@Falg", SqlDbType.Int, 1)
            }
            parameters(0).Value = cId
            parameters(1).Value = CheckType
            parameters(2).Value = Ppid
            parameters(3).Value = ReStationid
            parameters(4).Value = My.Computer.Name
            parameters(5).Value = VbCommClass.VbCommClass.UseId
            parameters(6).Direction = ParameterDirection.Output
            DbOperateUtils.ExecuteNonQureyByProc("m_QCCheckRejectHandle_P", parameters)
            If parameters(6).Value.ToString = "0" Then
                MessageUtils.ShowWarning("保存数据失败，请检查是否重复执行!")
                Return False
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmQCReject", "SetQCCheckRejectHandle", "sys")
        End Try
        Return True
    End Function


    'Private Function GetReStationidForPpid(ByVal cID As String) As String
    '    Dim Result As String = String.Empty
    '    Try
    '        Dim strSql As New StringBuilder

    '        strSql.Append("select SN from  m_QCCheckSnAllResult_t where cid='" & cID & "' ")

    '        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql.ToString)

    '        If dt.Rows.Count > 0 Then
    '            Result = dt.Rows(0)!SN.ToString
    '        End If


    '    Catch ex As Exception
    '        SysMessageClass.WriteErrLog(ex, "FrmQCReject", "GetReStationidForPpid", "sys")
    '    End Try
    '    Return Result
    'End Function

    Public Shared Sub BindComboxStationId(ByVal ColComboBox As ComboBox, ByVal PartNo As String)
        Dim strSQL As New StringBuilder

        'modify by hgd 20191115 获取pplink后标签不一致的情况
        'strSQL.Append(" DECLARE @linkPpid varchar(150)	select top 1 @linkPpid=ppid from m_Ppidlink_t where Exppid='" & Ppid & "' and Exppid<>ppid order by Intime desc ")
        'strSQL.Append(" select distinct Stationid,Stationname from( select a.Stationid,a.Stationid+ '-' + a.Stationname  as Stationname from m_Rstation_t a inner join  ")
        'strSQL.Append(" V_m_AssysnD_t(nolock) b on b.Stationid=a.Stationid where b.ppid=@linkPpid union all ")
        'strSQL.Append(" select a.Stationid,a.Stationid+ '-' + a.Stationname  as Stationname from m_Rstation_t a inner join ")
        'strSQL.Append("  V_m_AssysnD_t(nolock) b on b.Stationid=a.Stationid where b.ppid='" & Ppid & "') a  ")

        strSQL.Append(" DECLARE @StaOrderid INT ")
        strSQL.Append(" SELECT @StaOrderid=StaOrderid FROM m_RPartStationD_t where PPartid='" & PartNo & "' and State='1' and IsQCCheckOut='Y'  ")
        strSQL.Append(" SELECT a.Stationid,(a.Stationid+ '-' + b.Stationname) as Stationname  FROM  m_RPartStationD_t  a left join ")
        strSQL.Append("   m_Rstation_t b on b.Stationid=a.Stationid ")
        strSQL.Append(" where a.PPartid='" & PartNo & "'and State='1' and StaOrderid<@StaOrderid ")
        BindCombox(strSQL.ToString, ColComboBox, "Stationname", "Stationid")
    End Sub

    Public Shared Sub BindCombox(ByVal SQL As String, ByVal ColComboBox As ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)

        Dim dr As DataRow = dt.NewRow

        dr(Text) = ""
        dr(value) = ""
        dt.Rows.InsertAt(dr, 0)

        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value
    End Sub
#End Region




End Class