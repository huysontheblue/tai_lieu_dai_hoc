Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports LXWarehouseManage
Imports KanBan.FrmKanBan
Imports System.Text.RegularExpressions
Imports MainFrame

''' 修改者： 田玉琳
''' 修改日： 2016/04/01
''' 修改内容：看板显示 
Public Class FrmKanBanShow

    Private iSecond As Integer
    Public Structure stcMO
        Public strMO As String
        Public strLot As String
        Public strLine As String
        Public strPartID As String
    End Structure

    Private Enum enumMOStatus
        iNew = 0
        Wip = 1
        Finish = 2
        Lock = 3
    End Enum

    Private Enum enumProductType
        Productivity = 0
        LossTime = 1
        SupportTime = 2
    End Enum

    Private Enum enumProductDetailStatus
        WaitAudit = 0
        Audited = 1
    End Enum

    '初期化
    Private Sub FrmKanBan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = True Then Exit Sub

        Dim o_stcMO As New stcMO
        Dim o_blnShowSetKanBan As Boolean = False
        Try
            Me.WindowState = FormWindowState.Maximized
            '捕捉按键 
            InitalUI()
            'B, Get the MO
            Call GetMOInfo(o_stcMO)

            If String.IsNullOrEmpty(Me.txtMO.Text) Then
                MessageUtils.ShowError("请先设置工单！")
                Exit Sub
            End If

            If Not GetLeaderName() Then
                ' MessageBox.Show("抓取线长失败！")
            End If

            Call GetQty()

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmKanBanShow", "FrmKanBan_Load", "MES")
        End Try
    End Sub

    Private Function GetLeaderName() As Boolean
        Dim lsSQL As String = String.Empty
        Dim o_dt As New DataTable
        GetLeaderName = False
        Try
            lsSQL = _
                    "SELECT lineid," + vbCrLf + _
                    "       leader =" + vbCrLf + _
                    "          (STUFF ( (SELECT ',' + leadername" + vbCrLf + _
                    "                      FROM deptlineD_t" + vbCrLf + _
                    "                     WHERE lineid = A.lineid AND usey = N'Y'" + vbCrLf + _
                    "                    FOR XML PATH ( '' ))," + vbCrLf + _
                    "                  1," + vbCrLf + _
                    "                  1," + vbCrLf + _
                    "                  ''))" + vbCrLf + _
                    "  FROM deptlineD_t A" + vbCrLf + _
                    "  WHERE  lineid = '" & Me.txtLine.Text.Trim() & "'" + vbCrLf + _
                    "GROUP BY lineid"
            o_dt = DbOperateUtils.GetDataTable(lsSQL)

            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetLeaderName = True
                Me.txtLineLeader.Text = o_dt.Rows(0).Item("leader").ToString
            Else
                Me.txtLineLeader.Text = String.Empty
            End If
            Return GetLeaderName
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GetMOInfo(ByRef o_stcMO As stcMO)
        Dim lsSQL As String = ""
        Dim o_dt As New DataTable
        Try
            lsSQL = " SELECT TOP 1 MOID,LINEID,Moqty,PARTID FROM m_MainMO_t " & _
                    " WHERE Factory = '" & VbCommClass.VbCommClass.Factory & "' AND MOID='" & Me.txtMO.Text.Trim() & "' "

            o_dt = DbOperateUtils.GetDataTable(lsSQL)

            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                o_stcMO.strLine = o_dt.Rows(0).Item("LINEID")
                Me.txtLot.Text = o_dt.Rows(0).Item("Moqty")
                o_stcMO.strPartID = o_dt.Rows(0).Item("PARTID")
            End If

            Me.txtPartID.Text = o_stcMO.strPartID

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InitalUI()
        Me.tr_Date.Enabled = True
        Me.tr_Refresh.Enabled = True
        iSecond = 60 * 5
        '工单生产情况
        Me.txtLot.Text = "0"
        Me.txtCurHOutPutQty.Text = "0"
        Me.txtRemainQty.Text = "0"
        Me.txtMOTotalLostHours.Text = "0"
        Me.txtMONGQty.Text = "0"

        Me.txtCurHDefectRate.Text = "0"
        Me.txtLastMOInfo.Text = String.Empty
        Me.txtMsg.Text = String.Empty
    End Sub

    Private Sub GetQty()
        Try

            'Get 班别
            If Not GetShiftID() Then
                Me.txtMsg.Text = " 抓取班别失败！"
                Exit Sub
            End If

            'Get 人数
            If Not GetPersonQty() Then
                Me.txtMsg.Text = " 抓取应到/实到人数失败！"
                Exit Sub
            End If

            'A , Std Time
            If Not GetStdTime() Then
                Me.txtMsg.Text = " 抓取标准工时失败！"
                Exit Sub
            End If

            'B, Total Time
            If Not GetTotalTime() Then
                Me.txtMsg.Text = " 抓取总投入工时失败！"
                Exit Sub
            End If

            If Not GetStdOut() Then
                Me.txtMsg.Text = " 抓取标准产能失败！"
                Exit Sub
            End If

            '2016/03/02  田玉琳 update  分母有为0
            ' 每小时标准产能,3600/标准工时(s)
            If Me.txtStdTime.Text = 0 Then
                Me.txtPerHOutPut.Text = 0
            Else
                Me.txtPerHOutPut.Text = Math.Round(3600 / Val(Me.txtStdTime.Text), 0)
            End If

            'D, 工单已产数量
            If Not GetMOAlreadyOutPutQty() Then
                Me.txtMsg.Text = " 抓取工单已产数量失败！"
                Exit Sub
            End If

            '(Today)累计产能
            If Not GetSumOutPutQty() Then
                Me.txtMsg.Text = " 抓取累计产能失败！"
                Exit Sub
            End If

            '此小时累计产能
            If Not GetCurHOutPutQty() Then
                Me.txtMsg.Text = " 抓取此小时累计产能失败！"
                Exit Sub
            End If

            Me.txtRemainQty.Text = Val(Me.txtLot.Text) - Val(Me.txtMOOutPut.Text)

            '差异,[标准产能-累计产能]
            Me.txtGapQty.Text = Val(Me.txtStdOut.Text) - Val(Me.txtTodaySumOutPut.Text)

            ' 此小时差异= 每小时标准产能 - 此小时累计产能
            Me.txtCurHGapQty.Text = Val(Me.txtPerHOutPut.Text) - Val(Me.txtCurHOutPutQty.Text)

            '工单总损失工时
            If Not GetMOTotalLossTime() Then
                Me.txtMsg.Text = " 抓取工单总损失工时失败！"
                Exit Sub
            End If

            '今日损失工时的总和
            If Not GetTodayTotalLossTime() Then
                Me.txtMsg.Text = " 抓取损失工时失败！"
                Exit Sub
            End If

            '此小时损失工时
            If Not GetCurHLossTime() Then
                Me.txtMsg.Text = "抓取此小时损失工时失败！"
                Exit Sub
            End If

            '工单支援工时
            If Not GetMOSupportTime() Then
                Me.txtMsg.Text = "抓取工单支援工时失败！"
                Exit Sub
            End If

            '今日支援工时的总和
            If Not GetTodayTotalSupportTime() Then
                Me.txtMsg.Text = "抓取今日支援工时失败！"
                Exit Sub
            End If

            '工单不良数量
            If Not GetMONGQty() Then
                Me.txtMsg.Text = "抓取工单不良数量失败！"
                Exit Sub
            End If

            '此小时不良数量
            If Not GetCurHNGQty() Then
                Me.txtMsg.Text = "抓取此小时不良数量失败！"
                Exit Sub
            End If

            '(Today) 不良数量
            If Not GetTodayNGQty() Then
                Me.txtMsg.Text = "抓取今日不良数量失败！"
                Exit Sub
            End If

            '(Today) 功能不良數量
            If Not GetTodayFunNGQty() Then
                Me.txtMsg.Text = "抓取今日功能不良数量失败！"
                Exit Sub
            End If

            '(Today) 外观不良數量
            If Not GetTodayFacNGQty() Then
                Me.txtMsg.Text = "抓取今日外观不良数量失败！"
                Exit Sub
            End If

            '工单不良率: 工单不良数量/ 工单数量  
            If Me.txtMONGQty.Text = "0" Then
                Me.txtMODefectRate.Text = "0"
            Else
                Me.txtMODefectRate.Text = Math.Round(100 * Val(Me.txtMONGQty.Text) / Val(Me.txtLot.Text), 2)
            End If

            '不良率： 不良数量/（累计产能+不良数量）
            If Val(Me.txtTodayNGQty.Text) = 0 Then
                Me.txtTodayDefectRate.Text = "0"
            Else
                Me.txtTodayDefectRate.Text = Math.Round(100 * Val(Me.txtTodayNGQty.Text) / (Val(Me.txtTodaySumOutPut.Text) + Val(Me.txtTodayNGQty.Text)), 2)
            End If

            '此小时不良率=此小时不良数量/（此小时累计产能+此小时不良数量）
            If Val(Me.txtCurHourNGQty.Text) = 0 Then
                Me.txtCurHDefectRate.Text = "0"
            Else
                Me.txtCurHDefectRate.Text = Math.Round(100 * Val(Me.txtCurHourNGQty.Text) / (Val(Me.txtCurHOutPutQty.Text) + Val(Me.txtCurHourNGQty.Text)), 2)
            End If

            '上笔工单生产状况 已产数量/需求数量： 0/0 
            Me.txtLastMOInfo.Text = String.Format("上笔工单：{0} ", GetLastMO())

            Me.txtMsg.Text = String.Format("当前工单生产状况-- 客户:{0}, 已产数量/需求数量：{1}/{2} ", KBCom.GetMOCustName(Me.txtMO.Text.Trim()), Me.txtMOOutPut.Text.Trim(), Me.txtLot.Text.Trim())

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmKanBanShow", "GetQty", "sys")
            Throw ex
        Finally

        End Try
    End Sub

    Private Function GetLastMO() As String
        Dim lsSQL As String = String.Empty
        Dim o_Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        GetLastMO = ""
        lsSQL = " SELECT  TOP 1 moid, max(intime) as maxtime  FROM m_Assysn_t" & _
                " WHERE teamid ='" & Me.txtLine.Text.Trim() & "' AND moid <> '" & Me.txtMO.Text.Trim() & "' " & _
                " GROUP BY moid" & _
                " ORDER BY maxtime DESC"
        Using o_dt As DataTable = o_Conn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetLastMO = o_dt.Rows(0).Item(0)
            Else
                GetLastMO = ""
            End If
        End Using
        Return GetLastMO
    End Function

    Private Function GetPersonQty() As Boolean
        Dim lsSQL As String = ""
        GetPersonQty = False

        Try
            lsSQL = " SELECT Quorum, RealNum  FROM m_MoWorkShift_t " & _
                    " WHERE moid ='" & Me.txtMO.Text.Trim() & "'" & _
                    " AND lineid ='" & Me.txtLine.Text.Trim() & "'" & _
                    " AND WorkShift='" & getNumFormString(Me.txtShiftID.Text.Trim.Split("(")(0)) & "'"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) And o_dt.Rows.Count > 0 Then
                    Me.txtQuorum.Text = o_dt.Rows(0).Item("Quorum")
                    Me.txtRealNum.Text = o_dt.Rows(0).Item("RealNum")
                    GetPersonQty = True
                End If
            End Using
            Return GetPersonQty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getNumFormString(ByVal parText) As String
        Return System.Text.RegularExpressions.Regex.Replace(parText, "[^\d{2}-]*", "")
    End Function

    Private Function GetShiftID() As Boolean
        Dim lsSQL As String = ""
        Try
            lsSQL = _
                  "SELECT WorkShift, StartTime, EndTime" + vbCrLf + _
                  "  FROM m_MoWorkShift_t" + vbCrLf + _
                  " WHERE MOID = '" & Me.txtMO.Text.Trim() & "' AND GETDATE () BETWEEN StartTime AND EndTime"
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtShiftID.Text = " 第" & o_dt.Rows(0).Item("WorkShift").ToString & "节(" & o_dt.Rows(0).Item("StartTime").ToString & "-- " & o_dt.Rows(0).Item("EndTime").ToString & ")"
                    GetShiftID = True
                End If
            End Using
            Return GetShiftID
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetStdTime() As Boolean
        Dim lsSQL As String = ""
        'Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        GetStdTime = False
        Try
            lsSQL = "SELECT count(1)  from dbo.SysObjects WHERE id = OBJECT_ID('ERPDB.dbo.ECB_FILE')"
            Using dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item(0) = 0 Then
                        If Not GetStdTimeFromTT() Then
                            Return False
                        Else
                            Return True
                        End If
                    End If
                End If
            End Using

            'get from our mes db
            lsSQL = " SELECT ecb01 料号,ecb19 标准工时 FROM ERPDB.dbo.ecb_file " & _
                        " WHERE ecb01 ='" & Me.txtPartID.Text.Trim() & "' AND ecb17='产线' "
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtStdTime.Text = o_dt.Rows(0).Item(0)("标准工时")
                    GetStdTime = True
                Else
                    Me.txtStdTime.Text = "0"
                    GetStdTime = True
                End If
            End Using

            Return GetStdTime
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmKanBanShow", "GetStdTime", "sys")
        End Try
    End Function

    Private Function GetTotalTime() As Boolean
        Dim lsSQL As String = ""
        Try
            lsSQL = "SELECT count(1)  FROM dbo.SysObjects WHERE id = OBJECT_ID('ERPDB.dbo.ccj_file')"
            Using dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item(0) = 0 Then
                        If Not GetTotalTimeFromTT() Then
                            Return False
                        Else
                            Return True
                        End If
                    End If
                End If
            End Using

            lsSQL = " SELECT ccj04 工单编号,ccj02 线别,SUM(ccj05) 总投入工时" & _
                    " FROM ERPDB.dbo.ccj_file, ERPDB.dbo.cci_file" & _
                    " WHERE ccj01 = cci01 AND ccifirm ='Y'" & _
                    " AND ccj04='" & Me.txtMO.Text.Trim & "'" & _
                    " AND ccj02 ='" & Me.txtLine.Text.Trim & "'" & _
                    " GROUP BY ccj04,ccj02"
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtTotalWorkHours.Text = Math.Round(o_dt.Rows(0).Item(0)("总投入工时") / 3600, 2)  's ==> h
                    GetTotalTime = True
                Else
                    Me.txtTotalWorkHours.Text = "0"
                    GetTotalTime = True
                End If
            End Using
            Return GetTotalTime
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '标准产能
    Private Function GetStdOut() As Boolean
        Dim lsSQL As String = ""
        Dim o_InputTime As Integer = 0
        '今日总投入工时(h)*60*60/标准工时(s)。
        Try
            lsSQL = _
             "SELECT MOID," + vbCrLf + _
             "       Input =" + vbCrLf + _
             "          SUM (" + vbCrLf + _
             "             CASE" + vbCrLf + _
             "                WHEN datediff (day, STARTTIME, getdate ()) = 0" + vbCrLf + _
             "                THEN" + vbCrLf + _
             "                   DATEDIFF (s, STARTTIME, ISNULL (ENDTIME, GETDATE ()))" + vbCrLf + _
             "                ELSE" + vbCrLf + _
             "                   DATEDIFF (s," + vbCrLf + _
             "                             CONVERT (DATETIME, CONVERT (DATE, GETDATE ()))," + vbCrLf + _
             "                             ISNULL (ENDTIME, GETDATE ()))" + vbCrLf + _
             "             END)" + vbCrLf + _
             "  FROM [dbo].[m_MoProductTime_t]" + vbCrLf + _
             " WHERE     MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
             "       AND datediff (day, ISNULL (ENDTIME, GETDATE ()), getdate ()) = 0" + vbCrLf + _
             "GROUP BY MOID"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    o_InputTime = o_dt.Rows(0).Item("Input")

                    '标准工时为0时,报错， Add 除数为0的处理
                    If Val(Me.txtStdTime.Text) > 0 Then
                        Me.txtStdOut.Text = CInt(Val(o_InputTime) / Val(Me.txtStdTime.Text))
                    Else
                        Me.txtStdOut.Text = "0"
                    End If
                    GetStdOut = True
                End If
            End Using
            Return GetStdOut
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmKanBanShow", "GetStdOut", "sys")
            Throw ex
        End Try
    End Function

    '工单已产数量
    Private Function GetMOAlreadyOutPutQty() As Boolean
        Dim lsSQL As String = ""
        Try
            lsSQL = " SELECT MOID, ISNULL(SUM (Cartonqty),0) as MOOutPut" + vbCrLf + _
                    "  FROM m_Carton_t" + vbCrLf + _
                    " WHERE MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
                    " GROUP BY MOID"
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtMOOutPut.Text = o_dt.Rows(0).Item("MOOutPut")
                    GetMOAlreadyOutPutQty = True
                Else
                    Me.txtMOOutPut.Text = "0"
                    GetMOAlreadyOutPutQty = True
                End If
            End Using
            Return GetMOAlreadyOutPutQty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetManualMOOutPut() As String
        Dim lsSQL As String = ""
        GetManualMOOutPut = ""
        lsSQL = _
            "SELECT MOID, Isnull(SUM (OutQty),0) as MOOutPut" + vbCrLf + _
            "  FROM [dbo].[m_MoProductDetail_t]" + vbCrLf + _
            " WHERE Type = '" & enumProductType.Productivity & "' AND MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
            "GROUP BY MOID"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetManualMOOutPut = o_dt.Rows(0).Item("MOOutPut")
            Else
                GetManualMOOutPut = "0"
            End If
        End Using
        Return GetManualMOOutPut
    End Function

    'Today累计产能
    Private Function GetSumOutPutQty() As Boolean
        Dim lsSQL As String = ""
        GetSumOutPutQty = False
        Try
            lsSQL = _
               " SELECT MOID, ISNULL(SUM (Cartonqty),0) as SumOutPutQty" + vbCrLf + _
               " FROM m_Carton_t" + vbCrLf + _
               " WHERE MOID = '" & Me.txtMO.Text.Trim() & "' AND datediff (day, INTIME, getdate ()) = 0" + vbCrLf + _
               " GROUP BY MOID"
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtTodaySumOutPut.Text = o_dt.Rows(0).Item("SumOutPutQty")
                    GetSumOutPutQty = True
                Else
                    Me.txtTodaySumOutPut.Text = "0"  'If today no productive, then give 0
                    GetSumOutPutQty = True
                End If
            End Using
            Return GetSumOutPutQty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '此小时累计产能
    Private Function GetCurHOutPutQty() As Boolean
        Dim lsSQL As String = ""
        GetCurHOutPutQty = False
        Try
            lsSQL = _
            "SELECT MOID, ISNULL(SUM(Cartonqty),0) as CurHOutPutQty " + vbCrLf + _
            "  FROM m_Carton_t" + vbCrLf + _
            " WHERE     MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
            "       AND CONVERT (VARCHAR (13), INTIME, 120) =" + vbCrLf + _
            "              CONVERT (VARCHAR (13), getdate (), 120)" + vbCrLf + _
            "GROUP BY MOID"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtCurHOutPutQty.Text = o_dt.Rows(0).Item("CurHOutPutQty")
                    GetCurHOutPutQty = True
                Else
                    Me.txtCurHOutPutQty.Text = "0"
                    GetCurHOutPutQty = True
                End If
            End Using
            Return GetCurHOutPutQty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetManualCurHOutPutQty() As String
        Dim lsSQL As String = ""
        GetManualCurHOutPutQty = ""
        Try
            lsSQL = _
                   "SELECT MOID, SUM (OutQty) as ManualCurHOutPutQty " + vbCrLf + _
                   "  FROM m_MoProductDetail_t" + vbCrLf + _
                   " WHERE     Type = 0" + vbCrLf + _
                   "       AND MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
                   "       AND CONVERT (VARCHAR (13), ProductTime, 120) =" + vbCrLf + _
                   "              CONVERT (VARCHAR (13), getdate (), 120)" + vbCrLf + _
                   "GROUP BY MOID"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    GetManualCurHOutPutQty = o_dt.Rows(0).Item("ManualCurHOutPutQty")
                Else
                    GetManualCurHOutPutQty = "0"
                End If
            End Using
            Return GetManualCurHOutPutQty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetMOTotalLossTime() As Boolean
        Dim lsSQL As String = ""
        GetMOTotalLossTime = False
        Try
            lsSQL = _
            "SELECT MOID, isnull(SUM (ChangedHours),0) as MOTotalLossTime " + vbCrLf + _
            "  FROM  m_MoProductDetail_t" + vbCrLf + _
            " WHERE Type = '" & enumProductType.LossTime & "' AND Status = '" & enumProductDetailStatus.Audited & "' " & _
            " AND MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
            "GROUP BY MOID"

            Using dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    Me.txtMOTotalLostHours.Text = dt.Rows(0).Item("MOTotalLossTime")
                    GetMOTotalLossTime = True
                Else
                    Me.txtMOTotalLostHours.Text = "0"  'hour
                    GetMOTotalLossTime = True
                End If
            End Using
            Return GetMOTotalLossTime
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '今日损失工时的总和
    Private Function GetTodayTotalLossTime() As Boolean
        Dim lsSQL As String = ""
        GetTodayTotalLossTime = False
        Try
            lsSQL = _
              "SELECT MOID, ISNULL(SUM (ChangedHours),0) as TodayTotalLossTime" + vbCrLf + _
              "  FROM m_MoProductDetail_t" + vbCrLf + _
              " WHERE     Type = '" & enumProductType.LossTime & "'" + vbCrLf + _
              "       AND Status = '" & enumProductDetailStatus.Audited & "'" + vbCrLf + _
              "       AND MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
              "       AND datediff (day, CreateTime, getdate ()) = 0" + vbCrLf + _
              "GROUP BY MOID"

            Using dv As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(dv) AndAlso dv.Rows.Count > 0 Then
                    Me.txtTodayTotalLossHour.Text = dv.Rows(0).Item("TodayTotalLossTime")
                    GetTodayTotalLossTime = True
                Else
                    Me.txtTodayTotalLossHour.Text = "0"
                    GetTodayTotalLossTime = True
                End If
            End Using
            Return GetTodayTotalLossTime
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetCurHLossTime() As Boolean
        Dim lsSQL As String = ""
        GetCurHLossTime = False
        Try
            lsSQL = _
                "SELECT MOID, ISNULL(SUM(ChangedHours),0) as CurHLossTime" + vbCrLf + _
                "  FROM  m_MoProductDetail_t" + vbCrLf + _
                " WHERE     Type = '" & enumProductType.LossTime & "'" + vbCrLf + _
                "       AND Status = '" & enumProductDetailStatus.Audited & "'" + vbCrLf + _
                "       AND MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
                "       AND CONVERT (VARCHAR (13), CreateTime, 120) =" + vbCrLf + _
                "              CONVERT (VARCHAR (13), getdate (), 120)" + vbCrLf + _
                "GROUP BY MOID"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtCurHLossHour.Text = o_dt.Rows(0).Item("CurHLossTime")
                    GetCurHLossTime = True
                Else
                    Me.txtCurHLossHour.Text = "0"
                    GetCurHLossTime = True
                End If
            End Using
            Return GetCurHLossTime
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetMOSupportTime() As Boolean
        Dim lsSQL As String = ""
        GetMOSupportTime = False
        Try
            lsSQL = _
               "SELECT MOID, Isnull(SUM(ChangedHours),0) as MOSupportTime" + vbCrLf + _
               "  FROM m_MoProductDetail_t" + vbCrLf + _
               " WHERE Type = '" & enumProductType.SupportTime & "' AND Status = '" & enumProductDetailStatus.Audited & "'" + vbCrLf + _
               " AND MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
               "GROUP BY MOID"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtMOSupportHour.Text = o_dt.Rows(0).Item("MOSupportTime")
                    GetMOSupportTime = True
                Else
                    Me.txtMOSupportHour.Text = "0"
                    GetMOSupportTime = True
                End If
            End Using
            Return GetMOSupportTime
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetTodayTotalSupportTime() As Boolean
        Dim lsSQL As String = ""
        GetTodayTotalSupportTime = False
        Try
            lsSQL = _
               "SELECT MOID, ISNULL(SUM (ChangedHours),0) as TodayTotalSupportTime" + vbCrLf + _
               "  FROM m_MoProductDetail_t" + vbCrLf + _
               " WHERE     Type = '" & enumProductType.SupportTime & "'" + vbCrLf + _
               "       AND Status = '" & enumProductDetailStatus.Audited & "'" + vbCrLf + _
               "       AND MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
               "       AND datediff (day, CreateTime, getdate ()) = 0" + vbCrLf + _
               "GROUP BY MOID"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtTodayTotalLossHour.Text = o_dt.Rows(0).Item("TodayTotalSupportTime")
                    GetTodayTotalSupportTime = True
                Else
                    Me.txtTodayTotalLossHour.Text = "0"
                    GetTodayTotalSupportTime = True
                End If
            End Using
            Return GetTodayTotalSupportTime
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetMONGQty() As Boolean
        Dim lsSQL As String = ""
        GetMONGQty = False

        Try
            lsSQL = "SELECT ISNULL (SUM (NgQty), 0) NgQty" + vbCrLf + _
                    "  FROM (SELECT PPID, MAX (NgQty) NgQty" + vbCrLf + _
                    "          FROM m_AssyTs_t" + vbCrLf + _
                    "         WHERE MOID = '" & Me.txtMO.Text.Trim() & "' AND Stateid <> 'P'" + vbCrLf + _
                    "        GROUP BY PPID) A"
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtMONGQty.Text = o_dt.Rows(0).Item("NgQty")
                    GetMONGQty = True
                Else
                    Me.txtMONGQty.Text = "0"
                    GetMONGQty = True
                End If
            End Using
            Return GetMONGQty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetTodayNGQty() As Boolean
        Dim lsSQL As String = ""
        GetTodayNGQty = False

        Try
            lsSQL = "SELECT ISNULL (SUM (NgQty), 0) NgQty" + vbCrLf + _
                    "  FROM (SELECT PPID, MAX (NgQty) NgQty" + vbCrLf + _
                    "          FROM m_AssyTs_t" + vbCrLf + _
                    "         WHERE     MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
                    "               AND Stateid <> 'P'" + vbCrLf + _
                    "               AND datediff (day, INTIME, getdate ()) = 0" + vbCrLf + _
                    "        GROUP BY PPID) A"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtTodayNGQty.Text = o_dt.Rows(0).Item("NgQty")
                    GetTodayNGQty = True
                Else
                    Me.txtTodayNGQty.Text = " 0"
                    GetTodayNGQty = True
                End If
            End Using
            Return GetTodayNGQty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '获取功能不良數量
    Private Function GetTodayFunNGQty() As Boolean
        Dim lsSQL As String = ""
        GetTodayFunNGQty = False
        Try
            lsSQL =  "SELECT ISNULL (SUM (NgQty), 0) NgQty" + vbCrLf + _
                    "  FROM (SELECT PPID, MAX (NgQty) NgQty" + vbCrLf + _
                    "          FROM m_AssyTs_t" + vbCrLf + _
                    "         WHERE     MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
                    "               AND Stateid <> 'P'" + vbCrLf + _
                    "               AND datediff (day, INTIME, getdate ()) = 0" + vbCrLf + _
                    "                and codeitem = 'GN'" + vbCrLf + _
                    "        GROUP BY PPID) A"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtTodayFunNGQty.Text = o_dt.Rows(0).Item("NgQty")
                    GetTodayFunNGQty = True
                Else
                    Me.txtTodayFunNGQty.Text = " 0"
                    GetTodayFunNGQty = True
                End If
            End Using
            Return GetTodayFunNGQty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '获取功能不良數量
    Private Function GetTodayFacNGQty() As Boolean
        Dim lsSQL As String = ""
        GetTodayFacNGQty = False

        Try
            lsSQL = _
                    "SELECT ISNULL (SUM (NgQty), 0) NgQty" + vbCrLf + _
                    "  FROM (SELECT PPID, MAX (NgQty) NgQty" + vbCrLf + _
                    "          FROM m_AssyTs_t" + vbCrLf + _
                    "         WHERE     MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
                    "               AND Stateid <> 'P'" + vbCrLf + _
                    "               AND datediff (day, INTIME, getdate ()) = 0" + vbCrLf + _
                    "                and codeitem = 'WG'" + vbCrLf + _
                    "        GROUP BY PPID) A"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtTodayFacNGQty.Text = o_dt.Rows(0).Item("NgQty")
                    GetTodayFacNGQty = True
                Else
                    Me.txtTodayFacNGQty.Text = " 0"
                    GetTodayFacNGQty = True
                End If
            End Using
            Return GetTodayFacNGQty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetManualTodayNGQty() As String
        Dim lsSQL As String = ""
        GetManualTodayNGQty = ""
        Try
            lsSQL = _
                    "SELECT MOID, isnull(SUM(NGQty),0) as ManualTodayNGQty" + vbCrLf + _
                    "  FROM m_MoProductDetail_t" + vbCrLf + _
                    " WHERE     Type = '" & enumProductDetailStatus.Audited & "'" + vbCrLf + _
                    "   AND MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
                    "   AND datediff (day, ProductTime, getdate ()) = 0" + vbCrLf + _
                    "GROUP BY MOID"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    GetManualTodayNGQty = o_dt.Rows(0).Item("ManualTodayNGQty")
                Else
                    GetManualTodayNGQty = "0"
                End If
            End Using
            Return GetManualTodayNGQty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetCurHNGQty() As Boolean
        Dim lsSQL As String = ""
        GetCurHNGQty = False
        Try
            lsSQL = _
                    "SELECT ISNULL (SUM (NgQty), 0) NgQty" + vbCrLf + _
                    "  FROM (SELECT PPID, MAX (NgQty) NgQty" + vbCrLf + _
                    "          FROM m_AssyTs_t" + vbCrLf + _
                    "         WHERE     MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
                    "               AND Stateid <> 'P'" + vbCrLf + _
                    "               AND CONVERT (VARCHAR (13), INTIME, 120) =" + vbCrLf + _
                    "                      CONVERT (VARCHAR (13), getdate (), 120)" + vbCrLf + _
                    "        GROUP BY PPID) A"
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.txtCurHourNGQty.Text = o_dt.Rows(0).Item("NgQty")
                    GetCurHNGQty = True
                End If
            End Using
            Return GetCurHNGQty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetManualCurHNGQty() As String
        Dim lsSQL As String = ""
        GetManualCurHNGQty = ""
        Try
            lsSQL = _
                "SELECT MOID, isnull(SUM (NGQty),0) as ManualCurHNGQty" + vbCrLf + _
                "  FROM m_MoProductDetail_t" + vbCrLf + _
                " WHERE     Type = '" & enumProductType.Productivity & "'" + vbCrLf + _
                "       AND MOID = '" & Me.txtMO.Text.Trim() & "'" + vbCrLf + _
                "       AND CONVERT (VARCHAR (13), ProductTime, 120) =" + vbCrLf + _
                "              CONVERT (VARCHAR (13), getdate (), 120)" + vbCrLf + _
                "GROUP BY MOID"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    GetManualCurHNGQty = o_dt.Rows(0).Item("ManualCurHNGQty")
                Else
                    GetManualCurHNGQty = "0"
                End If
            End Using
            Return GetManualCurHNGQty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub tr_Date_Tick(sender As Object, e As EventArgs) Handles tr_Date.Tick
        Me.lblDate.Text = Date.Now.ToString("yyyy 年 MM 月 dd 日 HH 小时 mm 分 ss秒  dddd")
    End Sub

    Private Function GetStdTimeFromTT() As Boolean
        Dim oConn As New OracleDb("")
        Dim lsSQL As String = ""
        GetStdTimeFromTT = False
        Try
            'lsSQL = " SELECT ecb01 料号,ecb19 标准工时 FROM " & VbCommClass.VbCommClass.Factory & ".ecb_file " & _
            '       " WHERE ecb01 ='" & Me.txtPartID.Text.Trim() & "' AND ecb17='产线' "
            lsSQL = " SELECT ecb01 PartId,ecb19 StandTime FROM " & VbCommClass.VbCommClass.Factory & ".ecb_file " & _
                    " WHERE ecb01 ='" & Me.txtPartID.Text.Trim() & "' AND ecb17=N'产线' "
            Using dv As DataView = oConn.getDataView(lsSQL)
                If Not IsNothing(dv) AndAlso dv.Count > 0 Then
                    Me.txtStdTime.Text = dv.Item(0)("StandTime")
                    GetStdTimeFromTT = True
                Else
                    Me.txtStdTime.Text = "0"
                    GetStdTimeFromTT = True
                End If
            End Using

            Return GetStdTimeFromTT
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmKanBanShow", "GetStdTime", "sys")
            Throw ex
        End Try
    End Function

    Private Function GetTotalTimeFromTT() As Boolean
        Dim oConn As New OracleDb("")
        Dim lsSQL As String = ""
        Try
            'lsSQL = " SELECT ccj04 工单编号,ccj02 线别,SUM(ccj05) 总投入工时" & _
            '    " FROM " & VbCommClass.VbCommClass.Factory & ".ccj_file, " & VbCommClass.VbCommClass.Factory & ".cci_file" & _
            '    " WHERE ccj01 = cci01 AND ccifirm ='Y'" & _
            '    " AND ccj04='" & Me.txtMO.Text.Trim() & "'" & _
            '    " AND ccj02 ='" & Me.txtLine.Text.Trim() & "'" & _
            '    " GROUP BY ccj04,ccj02"
            lsSQL = " SELECT ccj04 Moid,ccj02 Line,SUM(ccj05) TotalTime" & _
                    " FROM " & VbCommClass.VbCommClass.Factory & ".ccj_file, " & VbCommClass.VbCommClass.Factory & ".cci_file" & _
                    " WHERE ccj01 = cci01 AND ccifirm ='Y'" & _
                    " AND ccj04='" & Me.txtMO.Text.Trim() & "'" & _
                    " AND ccj02 ='" & Me.txtLine.Text.Trim() & "'" & _
                    " GROUP BY ccj04,ccj02"
            Using dv As DataView = oConn.getDataView(lsSQL)
                If Not IsNothing(dv) AndAlso dv.Count > 0 Then
                    Me.txtTotalWorkHours.Text = Math.Round(dv.Item(0)("TotalTime") / 3600, 2)  's ==> h
                    GetTotalTimeFromTT = True
                Else
                    Me.txtTotalWorkHours.Text = "0"
                    GetTotalTimeFromTT = True
                End If
            End Using
            Return GetTotalTimeFromTT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Dim frmHelp As FrmKBHelp = New FrmKBHelp()
        frmHelp.StartPosition = FormStartPosition.CenterScreen
        frmHelp.Show()
    End Sub

    Private Sub tr_Refesh_Tick(sender As Object, e As EventArgs) Handles tr_Refresh.Tick
        iSecond = iSecond - 1
        If iSecond < 0 Then
            Call GetQty()
            iSecond = 60 * 5
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class