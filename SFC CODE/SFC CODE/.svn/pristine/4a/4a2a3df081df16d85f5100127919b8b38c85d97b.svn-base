

Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports System.Drawing

''' <summary>
''' 修改者： 黄广都
''' 修改日： 2020/03/31
''' 修改内容：
''' -------------------修改记录---------------------
''' 
''' </summary>
''' <remarks>品质抽检</remarks>
''' 
Public Class frmOnProcessRework

#Region "属性"

    Private m_PartId As String
    Public Property PartId() As String
        Get
            Return m_PartId
        End Get

        Set(ByVal Value As String)
            m_PartId = Value
        End Set
    End Property

#End Region


    Private Sub frmOnProcessRework_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPPid.Focus()
    End Sub

#Region "事件"
    Private Sub btnAddNo_Click(sender As Object, e As EventArgs) Handles btnAddNo.Click

    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            Getdata()
        Catch ex As Exception
            SetMessage(Me.lblMessage, "返回异常", False)
        End Try
    End Sub


    Private Sub dgvListData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListData.CellClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            Dim ppid As String = dgvListData.CurrentRow.Cells(0).Value.ToString

            GetListDetailData(ppid)
        Catch ex As Exception
            SetMessage(Me.lblMessage, "返回异常", False)
        End Try
    End Sub

    Private Sub txtPPid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPPid.KeyPress
        If e.KeyChar <> Chr(13) Then Exit Sub
        Getdata()
    End Sub

    Private Sub btnRecovery_Click(sender As Object, e As EventArgs) Handles btnRecovery.Click

    End Sub

    Private Sub btnExc_Click(sender As Object, e As EventArgs) Handles btnExc.Click
        Try

            If CheckData() = False Then Exit Sub

            '连接串
            Dim SqlStr As New StringBuilder
            '20200529 田玉琳
            '增加报废自动清除数据相当于跳站处理
            '执行维修返工流程
            If Not String.IsNullOrEmpty(cbbReStationId.Text) Then
                Dim ppid As String = txtPPid.Text

                Dim ReStationId As String = cbbReStationId.Text.ToString.Split("-")(0)
                Dim stype As String = "1"
                If rdoCartonId.Checked = True Then
                    stype = "2"
                    DeleteCartonByCartonid()
                Else
                    DeleteCartonByPpid()
                End If

                '执行跳站处理
                SqlStr.Append(" DECLARE @Falg int;DECLARE @Msg nvarchar(150);  ")
                SqlStr.AppendFormat(" EXEC Eexc_ReScanJumpStationHandleNewList '{0}','{1}','{2}','{3}','{4}','{5}', @Falg OUTPUT,@Msg OUTPUT ",
                                    ppid, ReStationId, VbCommClass.VbCommClass.UseId, stype, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)

                DbOperateUtils.ExecSQL(SqlStr.ToString)

                SetMessage(Me.lblMessage, "执行完成！", True)
                '重新获取数据
                Getdata()
            End If

        Catch ex As Exception
            SetMessage(Me.lblMessage, "返回异常", False)
        End Try
    End Sub

    Private Function DeleteCartonByCartonid() As Boolean

        Dim strSQL As String
        Dim strMOId As String
        Dim strCartonId As String
        Dim strPalletId As String
        Dim strHandleType As String
        'Exec_PackingExceptionHandle
        '关晓艳修改 增加删除原因
        Dim deleteReason As String

        strMOId = Me.dgvListData.CurrentRow.Cells(2).Value.ToString().ToUpper().Replace("'", "''")
        strCartonId = txtPPid.Text.Trim
        strPalletId = ""
        strHandleType = "0"
        deleteReason = "重工删除"

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
                    SetMessage(Me.lblMessage, drGetSQLRecor.Rows(0)(1).ToString(), False)
                    Return False
                Case "1"
                    SetMessage(Me.lblMessage, "删除成功!", True)
                    Return True
            End Select
        End If
        Return True
    End Function


    Private Function DeleteCartonByPpid() As Boolean
        Try
            Dim strSQL As String
            Dim strCartonId As String
            Dim strPPId As String
            Dim strHandleType As String
            Dim deleteReason As String

            strCartonId = Me.dgvListData.CurrentRow.Cells(1).Value.ToString().ToUpper().Replace("'", "''")
            strPPId = txtPPid.Text.Trim
            strHandleType = "0"
            deleteReason = "重工删除"

            '关晓艳修改 增加删除原因
            strSQL = "DECLARE @OUTVALUE VARCHAR(1), @OUTMSG NVARCHAR(128)" & _
                     " EXECUTE Exec_PackingPPIDExceptionHandle @OUTVALUE OUTPUT, @OUTMSG OUTPUT,'" & VbCommClass.VbCommClass.Factory & "','" &
                     VbCommClass.VbCommClass.profitcenter & "'," &
                     "'" & VbCommClass.VbCommClass.UseId & "','" & strCartonId & "','" & strPPId & "','" & strHandleType.Replace("'", "''") & "',N'" &
                     deleteReason & "'" &
                     " SELECT  @OUTVALUE ,ISNULL(@OUTMSG,'') "

            Dim drGetSQLRecor As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If drGetSQLRecor.Rows.Count > 0 Then
                Select Case drGetSQLRecor.Rows(0)(0).ToString()
                    Case "0"
                        SetMessage(Me.lblMessage, drGetSQLRecor.Rows(0)(1).ToString(), False)
                        Return False
                    Case "1"
                        SetMessage(Me.lblMessage, "删除成功！", True)
                        Return True
                End Select
            End If
            Return True
        Catch ex As Exception
        End Try
    End Function
#End Region

    ''' <summary>
    ''' 资料填写检查
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckData() As Boolean
        Try
            If (String.IsNullOrEmpty(Me.cbbReStationId.Text.Trim)) Then
                SetMessage(Me.lblMessage, "重工流程--投入制程站不能为空", False)
                Return False
            End If
            If Me.dgvListData.Rows.Count = 0 Then
                SetMessage(Me.lblMessage, "没有重工条码", False)
                Return False
            End If
            Return True
        Catch ex As Exception
            SetMessage(Me.lblMessage, ex.ToString, False)
            Return False
        End Try
    End Function


    Private Sub Getdata()

        '取得不良品数据
        GetListData()

        Dim ppid As String = txtPPid.Text
        If rdoCartonId.Checked = True Then
            If dgvListData.Rows.Count > 0 Then
                ppid = dgvListData.CurrentRow.Cells(0).Value.ToString
            End If
        End If
        GetListDetailData(ppid)
        GetPartStationID(ppid)
    End Sub


    Private Sub GetListData()
        Try
            Dim strSQL As StringBuilder = New StringBuilder

            If rdoCartonId.Checked = True Then
                strSQL.AppendFormat("SELECT ppid,ct.Cartonid,ct.Moid FROM m_Cartonsn_t cts INNER JOIN m_Carton_t ct ON cts.cartonid = ct.cartonid WHERE cts.cartonid = '{0}' ",
                                    txtPPid.Text.Trim)
            Else
                'strSQL.AppendFormat("SELECT DISTINCT ppid FROM m_AssysnD_t WHERE ppid = '{0}' ", txtPPid.Text.Trim)
                strSQL.AppendFormat(" IF EXISTS(SELECT 1 FROM m_Cartonsn_t WHERE ppid = '{0}') " &
                                    " BEGIN SELECT ppid,ct.Cartonid,ct.Moid FROM m_Cartonsn_t cts INNER JOIN m_Carton_t ct ON cts.cartonid = ct.cartonid WHERE cts.ppid = '{0}' END " &
                                    " ELSE BEGIN  SELECT distinct ppid ,'', '' FROM m_AssysnD_t WHERE ppid = '{0}' END",
                                      txtPPid.Text.Trim)
            End If
           
            Dim dataTable As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)

            dgvListDetail.Rows.Clear()
            dgvListData.Rows.Clear()
            For rowIndex As Integer = 0 To dataTable.Rows.Count - 1
                dgvListData.Rows.Add(dataTable.Rows(rowIndex).Item(0).ToString, dataTable.Rows(rowIndex).Item(1).ToString, dataTable.Rows(rowIndex).Item(2).ToString)
            Next

            SetMessage(Me.lblMessage, "数据加载完成", True)
        Catch ex As Exception
            'GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
            SetMessage(Me.lblMessage, ex.ToString, False)
        End Try
    End Sub

    Private Sub GetListDetailData(ppid As String)
        Try
            Dim strSQL As StringBuilder = New StringBuilder

            strSQL.AppendFormat("SELECT Moid, Ppid, Stationid, Teamid, Userid, Intime FROM m_AssysnD_t WHERE ppid = '{0}' ", ppid)

            Dim dataTable As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)

            dgvListDetail.Rows.Clear()
            For rowIndex As Integer = 0 To dataTable.Rows.Count - 1
                dgvListDetail.Rows.Add(
                      dataTable.Rows(rowIndex).Item(0).ToString, dataTable.Rows(rowIndex).Item(1).ToString, dataTable.Rows(rowIndex).Item(2).ToString, _
                      dataTable.Rows(rowIndex).Item(3).ToString, dataTable.Rows(rowIndex).Item(4).ToString, dataTable.Rows(rowIndex).Item(5).ToString
                  )
            Next

            SetMessage(Me.lblMessage, "数据加载完成", True)
        Catch ex As Exception
            'GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
            SetMessage(Me.lblMessage, ex.ToString, False)
        End Try
    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As Label, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

    '根据工单和条码带出当前异常站点
    Private Function GetPartStationID(ByVal ppid As String) As Boolean
        Dim bResult As Boolean = False
        Try
            Dim strSql As String = String.Format(" EXEC m_SearchNgStationNew_p '{0}' ,'{1}', '{2}','{3}','{4}' ",
                                                 "", ppid, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, 4)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)

            Me.cbbReStationId.Items.Clear()
            If dt.Rows.Count > 0 Then
                cbbReStationId.Text = ""
                For cnt As Integer = 0 To dt.Rows.Count - 1
                    Me.cbbReStationId.Items.Add(dt.Rows(cnt)("Stationname").ToString)
                Next
                If cbbReStationId.Items.Count = 1 Then
                    Me.cbbReStationId.SelectedIndex = 0
                Else
                    cbbReStationId.SelectedIndex = -1
                End If
            End If

            strSql = String.Format(" EXEC m_SearchNgStationNew_p '{0}' ,'{1}', '{2}','{3}','{4}' ",
                                    "", ppid, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, 3)
            dt = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                Me.cbbReStationId.SelectedValue = dt.Rows(0)!MesStaionid.ToString
            End If

        Catch ex As Exception
            SetMessage(Me.lblMessage, ex.Message, False)
        End Try
    End Function


#Region "Grid行数"
    Private Sub dgvListData_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvListData.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
    Private Sub dgvListDetail_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvListDetail.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

End Class