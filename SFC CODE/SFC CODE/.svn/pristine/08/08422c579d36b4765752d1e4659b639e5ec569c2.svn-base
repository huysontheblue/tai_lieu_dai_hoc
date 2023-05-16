Imports MainFrame
Imports MainFrame.SysCheckData

''' <summary>
''' 称重扫描
''' 
''' </summary>
''' <remarks></remarks>
Public Class FrmWorkStantScanPpidWeight

    Public weight As String
    Public message As String
    Public bPGConfirm As String = False
    Public PGConfirmWeight As String = ""

    Public m_iWeightMode As Int16
    Public Enum WeightMode
        PpidWeight
        BarePPidWeight
    End Enum

    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmNewStantPackScanPpidWeight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMessage.Text = WorkStantOption.ErrorStr
        lblWeight.Text = weight
    End Sub

    ''' <summary>
    ''' 关闭
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '条码扫描
    Private Sub txtPPid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPPid.KeyPress
        If e.KeyChar = Chr(13) Then

            If CheckIsScan() = False Then
                lblMessage.Text = "该条码已经扫描完成,请切换新条码"
                txtPPid.Text = ""
                txtPPid.Focus()
                Exit Sub
            End If

            bPGConfirm = CheckIsPGConfirm()

            '没有确认插入到不良称重表中
            If (bPGConfirm = False) Then
                InsertWeight()
            End If
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' 品管数据是否确认
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckIsScan() As Boolean
        Dim strSQL As String = ""

        strSQL = " select 1 from m_AssysnD_t where ppid = '{0}' and stationid = '{1}' "
        strSQL = String.Format(strSQL, txtPPid.Text, WorkStantOption.vStandId)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function


    ''' <summary>
    ''' 品管数据是否确认
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckIsPGConfirm() As Boolean
        Dim strSQL As String = ""
        Dim tablename As String = ""

        Select Case m_iWeightMode
            Case WeightMode.PpidWeight
                tablename = "m_OnlineWeightPpidNg_t"
            Case WeightMode.BarePPidWeight
                tablename = "m_OnlineWeightBarePpidNg_t"
        End Select

        strSQL = " select Weight from {0} where ppid = '{1}' and stationid = '{2}' and state = 'P'"
        strSQL = String.Format(strSQL, tablename, txtPPid.Text, WorkStantOption.vStandId)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            PGConfirmWeight = dt.Rows(0)(0).ToString
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' 空条码不保存
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InsertWeight()

        If txtPPid.Text.Trim = "" Then
            Exit Sub
        End If

        Dim tablename As String = ""

        Select Case m_iWeightMode
            Case WeightMode.PpidWeight
                tablename = "m_OnlineWeightPpidNg_t"
            Case WeightMode.BarePPidWeight
                tablename = "m_OnlineWeightBarePpidNg_t"
        End Select

        Dim strSQL As String =
          " if not exists(select 1 from  {0} where ppid = '{1}' and stationid = '{2}')" &
          " begin  insert into {0}(ppid, stationid, Moid, Weight, State, Userid, Intime)  " &
          " select  '{1}', '{2}', '{3}','{4}', 'D', '{5}', Getdate() end " &
          " else begin update  {0} set Weight = '{4}' where ppid = '{1}' and stationid = '{2}' end "

        strSQL = String.Format(strSQL, tablename, txtPPid.Text.Trim, WorkStantOption.vStandId, WorkStantOption.MoidStr, weight, VbCommClass.VbCommClass.UseId)

        Dim result As String = DbOperateUtils.ExecSQL(strSQL)

        lblMessage.Text = "数据保存成功！"
    End Sub

End Class