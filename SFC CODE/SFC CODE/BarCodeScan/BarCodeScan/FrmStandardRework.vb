#Region "Imports"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports BarCodeScan.Data
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports BarCodePrint
Imports System.IO
Imports System.Xml
Imports MainFrame
Imports UIHandler
Imports SysBasicClass
Imports System.Threading

#End Region
Public Class FrmStandardRework

#Region "属性字段"
    '应该数量
    Dim _PackQty As Integer = 0
    Dim _Moid As String = Nothing
    Dim _LineId As String = Nothing
#End Region

#Region "窗体事件"
    Private Sub frmStandardRework_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.txtPPid.Focus()

        'Me.TabControl1.TabPages.Remove(Me.TabControl1.TabPages(0))
        'Me.TabControl1.TabPages.Remove(Me.TabControl1.TabPages(0))
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        'If TabControl1.SelectedIndex = 0 Then
        '    Me.txtPPid.Focus()
        'Else
        '    Me.txtCartonid.Focus()
        'End If
    End Sub
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
#End Region

#Region "重工拆箱装作业"
#Region "事件"
    '拆箱作业
    Private Sub btnUnboxing_Click(sender As Object, e As EventArgs) Handles btnUnboxing.Click
        Dim b As Boolean = False
        Dim o_strSql As New StringBuilder
        If String.IsNullOrEmpty(Me.txtUnboxCartonCode.Text.Trim) Then
            Me.lbMsg.Text = "请扫描外箱标签!"
            Me.txtUnboxCartonCode.Focus()
            Exit Sub
        End If
        If CheckIsUnBox(Me.txtUnboxCartonCode.Text.Trim) = True Then
            Me.lbMsg.Text = Me.txtUnboxCartonCode.Text & ":此箱已拆过，无需重复拆箱!"
            Me.txtUnboxCartonCode.Focus()
            Exit Sub
        End If

        '检查是否移至历史库
        If CheckIsHistoryDB(txtUnboxCartonCode.Text.Trim) = True Then
            b = HistoryUnBoxing()
        Else
            b = UnBoxing()
        End If
        'b = UnBoxing()
        If b = False Then
            lbMsg.Text = Me.txtUnboxCartonCode.Text & "拆箱失败,请确认下此箱是否存在!"
        Else
            lbMsg.Text = Me.txtUnboxCartonCode.Text & "拆箱成功!"
        End If

    End Sub
    '外箱
    Private Sub txtPackingBoxCartonCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPackingBoxCartonCode.KeyPress

        If e.KeyChar = Chr(13) Then

            If String.IsNullOrEmpty(Me.txtPackingBoxCartonCode.Text) Then
                Me.txtPackingBoxCartonCode.Focus()
                Exit Sub
            End If
            If CheckIsUnBox(Me.txtPackingBoxCartonCode.Text.Trim) = False Then
                SetMessage("FAIL", "请先拆箱后再扫描!")
                Me.txtPackingBoxCartonCode.Focus()
                Exit Sub

            End If
            Me.lbPackQty.Text = _PackQty
            Me.lbScanQty.Text = 0
            Me.lbMoid.Text = _Moid
            Me.txtLineId.Text = _LineId

            SetMessage("PASS", "外箱标签扫描成功,请继续扫描产品条码....")
            Me.txtPackingBoxBarcode.Text = ""
            Me.txtPackingBoxBarcode.Focus()

        End If

    End Sub
    '产品
    Private Sub txtPackingBoxBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPackingBoxBarcode.KeyPress
        If e.KeyChar = Chr(13) Then
            If String.IsNullOrEmpty(Me.txtPackingBoxBarcode.Text.Trim) Then
                Exit Sub
            End If
            PackBoxing()

        End If
    End Sub
#End Region
#Region "方法"
    '是否已移至历史库
    Private Function CheckIsHistoryDB(ByVal unBoxCode As String) As Boolean
        Dim b As Boolean = False
        Dim O_strSql As New StringBuilder
        Dim iCount As Int32 = 0
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        O_strSql.Append("select Cartonid from MESDBHistory.dbo.m_Carton_t where Cartonid='" & unBoxCode & "'")
        iCount = DAL.GetRowsCount(O_strSql.ToString)
        If (iCount > 0) Then
            b = True
        End If
        Return b
    End Function

    '检查此箱是否已拆
    Private Function CheckIsUnBox(ByVal unBoxCode As String) As Boolean
        Dim b As Boolean = False
        Dim O_strSql As New StringBuilder
        Dim dt As New DataTable
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass

        O_strSql.Append("select Cartonid,PackingQuantity,Moid,Teamid from m_StandardReworkCarton_t where Cartonid='" & unBoxCode & "'")
        dt = DAL.GetDataTable(O_strSql.ToString)

        If dt.Rows.Count > 0 Then

            _PackQty = dt.Rows(0)!PackingQuantity.ToString
            _Moid = dt.Rows(0)!Moid.ToString
            _LineId = dt.Rows(0)!Teamid.ToString
            b = True
        End If
        Return b
    End Function

    '正式库拆箱
    Private Function UnBoxing() As Boolean
        Dim b As Boolean = False
        Dim o_strSql As New StringBuilder
        Dim cartonid As String = ""

        Dim UserID As String = VbCommClass.VbCommClass.UseId
        Try
            cartonid = Me.txtUnboxCartonCode.Text.Trim
            '备份装箱记录
            'o_strSql.Append("INSERT INTO m_StandardReworkCarton_t(Cartonid,Moid,PackQty,PackId,PackItem,StationId,StationName,Lineid,Userid,Intime) ")
            'o_strSql.Append(" SELECT [Cartonid],[Moid],[PackingQuantity],PackId,PackItem,StationId,StationName,Teamid,'" & UserID & "' as Userid,getdate() FROM M_CARTON_T  WHERE Cartonid='" & cartonid & "' ;")


            o_strSql.Append("if exists(select 1 from m_StandardReworkCarton_t where Cartonid='" & cartonid & "') begin delete m_StandardReworkCarton_t  where Cartonid='" & cartonid & "'  end ; ")
            o_strSql.Append(" INSERT INTO [dbo].[m_StandardReworkCarton_t]([Cartonid],[Moid],[PackId],[PackItem],[StationId],[StationName],[Cartonqty]")
            o_strSql.Append(",[PackingQuantity],[CartonStatus],[Teamid],[Userid],[Intime],[Whid]")
            o_strSql.Append(",[Areaid],[Floorid],[Packlink],[Updateuser],[Updatetime],[Status],[Mark1],[Mark2],[CartonLevel],[Spoint]) ")
            o_strSql.Append(" select [Cartonid],[Moid],[PackId],[PackItem],[StationId],[StationName],[Cartonqty] ")
            o_strSql.Append(" ,[PackingQuantity],[CartonStatus],[Teamid],[Userid],[Intime],[Whid]")
            o_strSql.Append(" ,[Areaid],[Floorid],[Packlink],[Updateuser],[Updatetime],[Status],[Mark1],[Mark2],[CartonLevel],[Spoint] ")
            o_strSql.Append(" FROM M_CARTON_T  WHERE Cartonid='" & cartonid & "' ;")

            o_strSql.Append(" delete m_StandardReworkPPid_t  WHERE Cartonid='" & cartonid & "';")
            o_strSql.Append(" INSERT INTO m_StandardReworkPPid_t(ppid,Moid,Cartonid,ppidQty,StationId,Userid,Intime)")
            o_strSql.Append(" SELECT  a.ppid,b.Moid,a.Cartonid,a.ppidQty,b.StationId,'" & UserID & "' as Userid,GETDATE() FROM m_Cartonsn_t  a  ")
            o_strSql.Append(" inner join m_Carton_t b on b.Cartonid=a.Cartonid WHERE b.Cartonid='" & cartonid & "' ;")

            '临时备份下,防止系统异常无法找到包装记录
            'o_strSql.Append(" if not exists(select 1 from M_Carton_Rework_t where Cartonid='" & cartonid & "') ")
            'o_strSql.Append(" begin insert into  M_Carton_Rework_t (Cartonid ,Moid,PackId,PackItem,StationId,StationName,Cartonqty,PackingQuantity,CartonStatus")
            'o_strSql.Append(" ,Teamid,Userid ,Intime,Whid,Areaid,Floorid,Packlink,Updateuser,Updatetime,Status,Mark1 ,Mark2,CartonLevel,Spoint)")
            'o_strSql.Append("	select Cartonid ,Moid,PackId,PackItem,StationId,StationName,Cartonqty,PackingQuantity,CartonStatus ")
            'o_strSql.Append("  ,Teamid,Userid ,Intime,Whid,Areaid,Floorid,Packlink,Updateuser,Updatetime,Status,Mark1 ,Mark2,CartonLevel,Spoint ")
            'o_strSql.Append(" from M_Carton_t where Cartonid='" & cartonid & "' end; ")
            ''备份包装明细
            'o_strSql.Append(" if not exists(select 1 from m_Cartonsn_Rework_t where Cartonid='" & cartonid & "') ")
            'o_strSql.Append(" begin INSERT INTO m_Cartonsn_Rework_t(ppid,Cartonid,ppidQty,Userid,Status,Intime,Mark1) ")
            'o_strSql.Append(" SELECT ppid,Cartonid,ppidQty,Userid,Status,Intime,Mark1 FROM m_Cartonsn_t WHERE Cartonid='" & cartonid & "' end;")

            '删除装箱记录
            o_strSql.Append(" DELETE m_Cartonsn_t WHERE  Cartonid='" & cartonid & "';")
            o_strSql.Append(" DELETE  m_Carton_t WHERE  Cartonid='" & cartonid & "' ;")

            '删除附属检测记录
            o_strSql.Append(" DELETE m_PackingCheckBarcode_t WHERE  Cartonid='" & cartonid & "';")
            o_strSql.Append(" DELETE  m_PackingCheckCarton_t WHERE  Cartonid='" & cartonid & "' ;")

            DbOperateUtils.ExecSQL(o_strSql.ToString)
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmStandardRework", "UnBoxing()", "sys")
        End Try
        Return b
    End Function
    '历史库拆箱
    Private Function HistoryUnBoxing() As Boolean
        Dim b As Boolean = False
        Dim o_strSql As New StringBuilder
        Dim cartonid As String = ""

        Dim UserID As String = VbCommClass.VbCommClass.UseId
        Try
            cartonid = Me.txtUnboxCartonCode.Text.Trim
            '备份装箱记录
            o_strSql.Append(" INSERT INTO m_StandardReworkCarton_t(Cartonid,Moid,PackQty,PackId,PackItem,StationId,StationName,Lineid,Userid,Intime) ")
            o_strSql.Append(" SELECT [Cartonid],[Moid],[PackingQuantity],PackId,PackItem,StationId,StationName,Teamid,'" & UserID & "' as Userid,getdate() FROM  MESDBHistory.dbo.M_CARTON_T  WHERE Cartonid='" & cartonid & "' ;")

            o_strSql.Append(" INSERT INTO m_StandardReworkPPid_t(ppid,Moid,Cartonid,ppidQty,StationId,Userid,Intime)")
            o_strSql.Append(" SELECT  a.ppid,b.Moid,a.Cartonid,a.ppidQty,b.StationId,'" & UserID & "' as Userid,GETDATE() FROM MESDBHistory.dbo.m_Cartonsn_t  a  ")
            o_strSql.Append(" inner join MESDBHistory.dbo.m_Carton_t b on b.Cartonid=a.Cartonid WHERE b.Cartonid='" & cartonid & "' ;")

            '临时备份下,防止系统异常无法找到包装记录
            o_strSql.Append(" if not exists(select 1 from M_Carton_Rework_t where Cartonid='" & cartonid & "') ")
            o_strSql.Append(" begin insert into  M_Carton_Rework_t (Cartonid ,Moid,PackId,PackItem,StationId,StationName,Cartonqty,PackingQuantity,CartonStatus")
            o_strSql.Append(" ,Teamid,Userid ,Intime,Whid,Areaid,Floorid,Packlink,Updateuser,Updatetime,Status,Mark1 ,Mark2,CartonLevel,Spoint)")
            o_strSql.Append("	select Cartonid ,Moid,PackId,PackItem,StationId,StationName,Cartonqty,PackingQuantity,CartonStatus ")
            o_strSql.Append("  ,Teamid,Userid ,Intime,Whid,Areaid,Floorid,Packlink,Updateuser,Updatetime,Status,Mark1 ,Mark2,CartonLevel,Spoint ")
            o_strSql.Append(" from MESDBHistory.dbo.M_Carton_t where Cartonid='" & cartonid & "' end; ")
            '备份包装明细
            o_strSql.Append(" if not exists(select 1 from m_Cartonsn_Rework_t where Cartonid='" & cartonid & "') ")
            o_strSql.Append(" begin INSERT INTO m_Cartonsn_Rework_t(ppid,Cartonid,ppidQty,Userid,Status,Intime,Mark1) ")
            o_strSql.Append(" SELECT ppid,Cartonid,ppidQty,Userid,Status,Intime,Mark1 FROM MESDBHistory.dbo.m_Cartonsn_t WHERE Cartonid='" & cartonid & "' end;")



            '删除装箱记录
            o_strSql.Append(" DELETE MESDBHistory.dbo.m_Cartonsn_t WHERE  Cartonid='" & cartonid & "';")
            o_strSql.Append(" DELETE  MESDBHistory.dbo.m_Carton_t WHERE  Cartonid='" & cartonid & "'")

            '删除附属检测记录
            o_strSql.Append(" DELETE m_PackingCheckBarcode_t WHERE  Cartonid='" & cartonid & "';")
            o_strSql.Append(" DELETE  m_PackingCheckCarton_t WHERE  Cartonid='" & cartonid & "' ;")
            DbOperateUtils.ExecSQL(o_strSql.ToString)
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmStandardRework", "HistoryUnBoxing()", "sys")
        End Try
        Return b
    End Function

    '重新装箱
    Private Function PackBoxing() As Boolean
        Dim b As Boolean = False
        Dim cartonid As String = ""
        Dim Falg As Integer = 0
        Dim item As Integer = CInt(Me.lbScanQty.Text.ToString)
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        Try
            cartonid = Me.txtPackingBoxCartonCode.Text.Trim
            Dim para(6) As SqlParameter
            Dim parameters() As SqlParameter = {
                New SqlParameter("@CARTON_ID", SqlDbType.VarChar, 150),
                New SqlParameter("@PPID", SqlDbType.VarChar, 150),
                New SqlParameter("@LineId", SqlDbType.NVarChar, 50),
                New SqlParameter("@UserID", SqlDbType.NVarChar, 50),
                New SqlParameter("@Falg", SqlDbType.Int, 20),
                New SqlParameter("@RtMsg", SqlDbType.NVarChar, 150)
            }
            parameters(0).Value = cartonid
            parameters(1).Value = Me.txtPackingBoxBarcode.Text.Trim
            parameters(2).Value = Me.txtLineId.Text
            parameters(3).Value = UserID
            parameters(4).Value = Falg
            parameters(4).Direction = ParameterDirection.Output
            parameters(5).Value = ""
            parameters(5).Direction = ParameterDirection.Output
            DbOperateUtils.ExecuteNonQureyByProc("m_ReworkUnPackBoxScan_P", parameters)
            If parameters(4).Value.ToString = "1" Then
                SetMessage("PASS", Me.txtPackingBoxBarcode.Text.Trim & "扫描成功！")
                item = item + 1
                Me.dgvUnPackBox.Rows.Insert(0, cartonid, Me.txtPackingBoxBarcode.Text.Trim, SysMessageClass.UseId, Now())

                dgvUnPackBox.ClearSelection()
                dgvUnPackBox.Rows(0).Cells(0).Selected = True
                If dgvUnPackBox.Rows.Count > 10 Then
                    dgvUnPackBox.Rows.RemoveAt(dgvUnPackBox.Rows.Count - 1)
                End If
                Me.lbScanQty.Text = item
                Me.txtPackingBoxBarcode.Text = ""
                Me.txtPackingBoxBarcode.Focus()
            ElseIf parameters(4).Value.ToString = "2" Then
                SetMessage("PASS", "此箱已装完,请继续扫描其它箱！")
                Me.txtPackingBoxCartonCode.Text = ""
                Me.txtPackingBoxCartonCode.Focus()
                Me.txtPackingBoxBarcode.Text = ""
                Me.lbScanQty.Text = 0

            Else
                SetMessage("FAIL", parameters(5).Value.ToString)
                Return False
            End If
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmStandardRework", "PackBoxing()", "sys")
        End Try
        Return b
    End Function

#End Region


#End Region

#Region "共用方法"
    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            lbUnPackBoxResult.Text = "FAIL"
            lbUnPackBoxMessage.Text = message
            lbUnPackBoxResult.ForeColor = Color.Crimson
            lbUnPackBoxMessage.ForeColor = Color.Crimson
        Else
            lbUnPackBoxResult.Text = "PASS"
            lbUnPackBoxMessage.Text = message
            lbUnPackBoxResult.ForeColor = Color.FromArgb(0, 192, 0)
            lbUnPackBoxMessage.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub
    Private Sub SetMessage3(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            lblResult3.Text = "FAIL"
            lblMessage3.Text = message
            lblResult3.ForeColor = Color.Crimson
            lblMessage3.ForeColor = Color.Crimson
        Else
            lblResult3.Text = "PASS"
            lblMessage3.Text = message
            lblResult3.ForeColor = Color.FromArgb(0, 192, 0)
            lblMessage3.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub
#End Region

#Region "重工作业"

    '根据LXASN标签取得华为ASN标签信息
    Private Sub txtLXAsn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLXAsn.KeyPress
        If e.KeyChar = Chr(13) Then
            GetLxAsn()
        End If
    End Sub

    '替换
    Private Sub btnTranfer_Click(sender As Object, e As EventArgs) Handles btnTranfer.Click
        Dim Sqlstr As String = String.Empty
        Try
            Sqlstr = " declare @Msg nvarchar(500),@ReturnValue int " & _
                     " exec m_NewCheckHWASNReWork  '{0}','{1}','{2}',@Msg out,@ReturnValue out" &
                     " select @ReturnValue,@Msg"
            Sqlstr = String.Format(Sqlstr, txtOldHWAsn.Text.Trim, txtNewHWAsn.Text.Trim, SysMessageClass.UseId)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "1" '失败
                        txtNewHWAsn.Text = ""
                        MessageUtils.ShowInformation(dt.Rows(0)(1))
                        Exit Select
                    Case "0" ''---替换成功
                        txtLXAsn.Text = ""
                        txtNewHWAsn.Text = ""
                        txtOldHWAsn.Text = ""
                        txtLXAsn.Focus()
                        MessageUtils.ShowInformation(dt.Rows(0)(1))
                        Exit Select
                End Select
            End If
        Catch ex As Exception
            MessageUtils.ShowInformation(ex.Message)
        End Try
    End Sub

    '取得华为ASN标签信息
    Private Sub GetLxAsn()
        Dim strSQL As String = "  SELECT  moid ,LineID,QRCode   FROM m_HWASNQRScanRecord_t  WHERE (LXQRCode = '{0}' OR PackBarCode = '{0}')"

        strSQL = String.Format(strSQL, txtLXAsn.Text.Trim)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count = 0) Then
            MessageUtils.ShowError("没有扫描过此立讯ASN条码,请确认")
            txtLXAsn.Text = ""
            txtLXAsn.Focus()
            txtOldHWAsn.Text = ""
            txtLine.Text = ""
            lblMoid.Text = ""
            Exit Sub
        End If

        '华为旧条码
        txtOldHWAsn.Text = dt.Rows(0)("QRCode").ToString
        '工单
        lblMoid.Text = dt.Rows(0)("moid").ToString
        '工单
        txtLine.Text = dt.Rows(0)("LineID").ToString
        txtNewHWAsn.Focus()
    End Sub


#End Region


#Region "LXASN 和 华为ASN关联"

    Private Sub txtLXASN2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLXASN2.KeyPress
        If e.KeyChar = Chr(13) Then
            'CheckIsRight()
            txtHWASN2.Focus()
        End If
    End Sub


#End Region

    Private Sub txtHWASN2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHWASN2.KeyPress
        If e.KeyChar = Chr(13) Then
            CheckIsRight()
        End If
    End Sub


    Private Sub CheckIsRight()
        Dim strSQL As String = ""
        strSQL = "declare @cartonId varchar(200), @Msg nvarchar(500),@ReturnValue int" & vbCrLf &
                 "exec m_NewCheckHWASNLXASNAdd '{0}','{1}','{2}','{3}',@cartonId out,@Msg out,@ReturnValue out" & vbCrLf &
                 "select @cartonId,@Msg,@ReturnValue"

        strSQL = String.Format(strSQL, txtLXASN2.Text.Trim, txtHWASN2.Text, VbCommClass.VbCommClass.UseId, My.Computer.Name)

        Dim dtHWASN As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Dim CartonIDStr As String = ""
        '条码判断
        If dtHWASN.Rows(0)(2).ToString() = "0" Then '
            CartonIDStr = dtHWASN.Rows(0)(0).ToString '新箱号
            SetMessage3("PASS", dtHWASN.Rows(0)(1).ToString())
            txtLXASN2.Focus()
            txtLXASN2.Text = ""
            txtHWASN2.Text = ""
            Exit Sub
        ElseIf dtHWASN.Rows(0)(2).ToString() = "1" Then '抛错误信息
            SetMessage3("FAIL", dtHWASN.Rows(0)(1).ToString())
            txtLXASN2.Text = ""
            txtHWASN2.Text = ""
            txtLXASN2.Focus()
            Exit Sub
        ElseIf dtHWASN.Rows(0)(2).ToString() = "2" Then '二维码条码
            SetMessage3("FAIL", dtHWASN.Rows(0)(1).ToString())
            txtLXASN2.Text = ""
            txtHWASN2.Text = ""
            txtLXASN2.Focus()
            Exit Sub
        End If
    End Sub

End Class