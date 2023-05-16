Imports MainFrame
Imports System.Text
Imports MainFrame.SysCheckData
Public Class FrmQcQuery


    ''' <summary>
    ''' 修改者： 黄广都
    ''' 修改日： 2020/01/13
    ''' 修改内容：
    ''' -------------------修改记录---------------------
    ''' 
    ''' </summary>
    ''' <remarks>品质抽检-查询</remarks>

    Private m_CId As String
    Public Property CId() As String
        Get
            Return m_CId
        End Get

        Set(ByVal Value As String)
            m_CId = Value
        End Set
    End Property
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click

        If dtpStartTime.Value > dtpEndTime.Value Then

            MessageUtils.ShowWarning("开始时间大于结束时间，请检查!")
            Exit Sub
        End If
        GetData()
    End Sub


    Private Sub GetData()
        Try
            Dim dt As DataTable = GetDataTable("find")

            dgvData.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FrmQcQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dtpStartTime.Value = Date.Now.AddDays(-30).ToString("yyyy/MM/dd")
        'Me.dtpStartTime.Value = Date.Now.AddDays(-7).ToString("yyyy/MM/dd")
        Me.dtpEndTime.Value = Date.Now.AddDays(0).ToString("yyyy/MM/dd")
        Me.cbStatus.SelectedIndex = 1
        GetData()
    End Sub


    Private Sub dgvData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso Me.dgvData.RowCount > 0 Then
            '文件编码
            Dim Cid As String
            Cid = Me.dgvData.CurrentRow.Cells(2).Value.ToString

            If e.ColumnIndex = 0 Then
                DisplayDetail(Cid)
                Exit Sub
            End If

            Dim Result As String
            Result = Me.dgvData.CurrentRow.Cells(13).Value.ToString

            If Result <> "N" AndAlso Result <> "N/A" Then
                MessageUtils.ShowWarning("该检验批已被判定,无法再进行检验!")
            End If

            Me.m_CId = Cid
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Function GetDataTable(type As String) As DataTable
        Dim sb As New StringBuilder

        If type = "find" Then
            sb.Append(" select * from m_QCCheckMain_t where 1=1 ")
        Else
            sb.Append(" SELECT cid '批次号',moid as '工单号', partno as 'PartNo' ,CheckQty '检查数量' , " &
                      " checklevel AS '级别', FunCheckRatio '检查比率' ,OkQty 'ok数量' ,NgQty '不良数量' ,MA_Qty '主缺数量' ,MI_Qty '次缺数量',CR_Qty '重缺数量' ,Status '状态' " &
                      " FROM m_QCCheckMain_t where 1=1 ")
        End If


        If Not String.IsNullOrEmpty(txtCid.Text) Then
            sb.Append(" and CID='" & txtCid.Text & "' ")
        End If
        If Not String.IsNullOrEmpty(txtMoid.Text) Then
            sb.Append(" and Moid='" & txtMoid.Text & "'")
        End If
        If Not String.IsNullOrEmpty(txtPartNo.Text) Then
            sb.Append(" and PartNo='" & txtPartNo.Text & "' ")
        End If
        If Not IsNothing(cbStatus.SelectedItem.ToString) Then
            If cbStatus.SelectedItem.ToString = "进行中" Then
                sb.Append(" and Status='N' ")
            ElseIf cbStatus.SelectedItem.ToString = "已检验" Then
                sb.Append(" and Status='Y' ")
            End If
        End If

        sb.Append(" and CreateTime between '" & dtpStartTime.Value & " 00:00:00.000' and '" & dtpEndTime.Value & " 23:59:59.000'")
        Dim dt As DataTable = DbOperateUtils.GetDataTable(sb.ToString)
        Return dt
    End Function

    Private Sub DisplayDetail(cid)
        Dim frm As FrmQcSnDetail = New FrmQcSnDetail

        frm.cid = cid
        frm.ShowDialog()
    End Sub


    Private Sub dgvData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvData.CellFormatting
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso Me.dgvData.RowCount > 0 Then


            Dim _Result As String
            If e.ColumnIndex = 1 Then

                _Result = Me.dgvData.Rows(e.RowIndex).Cells(13).Value.ToString
                '已被判定
                If _Result <> "N" AndAlso _Result <> "N/A" Then

                    Me.dgvData.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Silver
                End If
            End If

        End If
    End Sub


    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim dt As DataTable = GetDataTable("export")

        ExcelUtils.LoadDataToExcelFromDT(dt, Me.Text)
    End Sub
    Private Sub btnDelCid_Click(sender As Object, e As EventArgs) Handles btnDelCid.Click
        If dgvData.Rows.Count > 0 OrElse Not Me.dgvData.CurrentRow Is Nothing Then
            Dim sCid = Me.dgvData.CurrentRow.Cells("colCID").Value.ToString
            If CheckIsExistsNVL(sCid) = False Then
                MessageUtils.ShowWarning("该检验批正在检验或非本人创建，无法删除!")
                Return
            End If
            If MessageUtils.ShowConfirm("确定要删除该批次[" + sCid + "]？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim sSql As String
                sSql = "delete m_QCCheckMain_t where CID='" + sCid + "' "
                DbOperateUtils.ExecSQL(sSql)
                GetData()
            End If
        End If
    End Sub
    Private Function CheckIsExistsNVL(ByVal strCid As String) As Boolean

        Try
            Dim strSql As String

            strSql = "SELECT * FROM m_QCCheckMain_t a where 1=1 AND a.CreateUserId='" & VbCommClass.VbCommClass.UseId & "' AND a.CID='" & strCid & "' " & vbNewLine & _
             " and not exists( select 1 from m_QCCheckSnDetail_t b where b.CId=a.CId ) "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#Region "Grid行数"
    Private Sub gridView_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvData.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region


End Class