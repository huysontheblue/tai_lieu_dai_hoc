Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports System.IO
Imports MainFrame.SysCheckData

Public Class KBCom

    '取-前的字符
    Public Shared Function Getid(ByVal strFullName) As String
        Dim intPos As Integer
        Dim strReturn As String
        If strFullName <> "" Then
            If strFullName = "ALL" Then
                strReturn = "%"
                Return strReturn
                Exit Function
            End If
            intPos = InStr(strFullName, "-")
            If intPos = 0 Then
                strReturn = strFullName
            Else
                strReturn = Mid(strFullName, 1, intPos - 1)
            End If
        Else
            strReturn = "%"
        End If
        Return strReturn
    End Function

    ''' <summary>
    ''' 设置柏拉图查询条件
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxDateIf(ByVal ColComboBox As ComboBox)
        Dim strSQL As String =
                " select value,text from m_BaseData_t where itemkey = 'PLTDATEIF' and status = 1 order by SORT"

        BindComboxNoBlank(strSQL, ColComboBox, "text", "value")
    End Sub

    ''' <summary>
    ''' 设置柏拉图查询条件(只显示日周)
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxDateIfHaveBlank(ByVal ColComboBox As ComboBox)
        Dim strSQL As String =
                " select value,text from m_BaseData_t where itemkey = 'PLTDATEIF' and status = 1 and value in ('D','W') order by SORT"

        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    ''' <summary>
    ''' 设置部门
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxClass(ByVal ColComboBox As ComboBox)
        Dim strSQL As String =
                " SELECT DISTINCT deptid,(deptid+'-'+dqc)dqc FROM m_dept_t a, m_logtree_t b, m_userright_t c " _
                & " WHERE a.deptid=b.buttonid and b.tkey=c.tkey and a.dtype='R' " _
                & " and c.userid='" & SysMessageClass.UseId & "' "

        BindCombox(strSQL, ColComboBox, "dqc", "deptid")
    End Sub

    '设置线别
    Public Shared Sub LoadLineIDToCombo(ByRef ComBox As ComboBox, ByVal strDept As String)
        Dim strSql As String =
               " SELECT distinct a.lineid FROM deptline_t a, m_dept_t b  " &
               " WHERE a.deptid=b.deptid AND b.deptid like'" & strDept & "' "

        BindCombox(strSQL, ComBox, "lineid", "lineid")
    End Sub

    ''' <summary>
    ''' 设置线别
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxLineAll(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = String.Format("SELECT lineid FROM [deptline_t] where usey='Y' ") &
                               GetFatoryOther()

        BindCombox(strSQL, ColComboBox, "lineid", "lineid")
    End Sub

    '数据检查
    Public Shared Function CheckDate(ByVal starDT As DateTimePicker, ByVal endDT As DateTimePicker, _
                                     Optional ByVal checkt As Boolean = True, Optional ByVal months As Integer = 2)
        If starDT.Value > endDT.Value Then
            MsgBox("起始時間不能大於結束時間!", 48, "提示")
            starDT.Value = DateAdd(DateInterval.Day, -1, Now())
            endDT.Value = Now()
            Return False
        End If

        If starDT.Value < "2007-01-01" Then
            MsgBox("起始時間不能小於2007-01-01!", 48, "提示")
            starDT.Value = DateAdd(DateInterval.Day, -1, Now())
            Return False
        End If

        If checkt Then
            Dim startDate As DateTime = DateTime.Parse(starDT.Text)
            Dim endDate As DateTime = DateTime.Parse(endDT.Text)
            If startDate.AddMonths(months) < endDate Then
                MsgBox("查询时间相隔最多请不要超过" & months.ToString & "个月", 48, "提示")
                starDT.Value = DateAdd(DateInterval.Month, -1, endDate)
                Return False
            End If
        Else
            Return True
        End If
        Return True
    End Function

    '把DBNUll值变为空
    Public Shared Function DBNullToStr(ByVal obj As Object) As String
        If IsDBNull(obj) Then
            Return ""
        Else
            If obj Is Nothing Then
                Return ""
            Else
                Return obj.ToString().Trim()
            End If
        End If
    End Function

    ''' <summary>
    ''' 模块名称
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxMoKuai(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select SortID VALUE ,SortName TEXT from m_Sortset_t where sortType = 'MES' order by Orderid asc "

        BindCombox(strSQL, ColComboBox, "TEXT", "VALUE")
    End Sub

    ''' <summary>
    ''' 机能名称
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <param name="items"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxItems(ByVal ColComboBox As ComboBox, items As String)
        Dim strSQL As String = "select SortID VALUE ,SortName TEXT from m_Sortset_t where sortType = '{0}' order by Orderid asc "
        strSQL = String.Format(strSQL, items)

        BindCombox(strSQL, ColComboBox, "TEXT", "VALUE")
    End Sub

#Region "BindComBox"
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
    Public Shared Sub BindComboxNoBlank(ByVal SQL As String, ByVal ColComboBox As ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)

        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value
    End Sub
#End Region

#Region "按一天日期"

    '取得工单数量
    Public Shared Function GetProQty(partId As String, lineId As String, ngDate As String) As String
        Dim result As String = ""
        Using o_dt As DataTable = QueryGetParetoNgData(partId, lineId, ngDate, 1)
            If o_dt.Rows.Count > 0 Then
                result = o_dt.Rows(0)(0)
            End If
        End Using
        Return result
    End Function

    '取得确认用户名
    Public Shared Function GetConfirmName(partId As String, lineId As String, ngDate As String) As String
        Dim result As String = ""
        Using o_dt As DataTable = QueryGetParetoNgData(partId, lineId, ngDate, 2)
            If o_dt.Rows.Count > 0 Then
                result = o_dt.Rows(0)(0).ToString
            End If
        End Using
        Return result
    End Function

    '设置料件list
    Public Shared Sub GetPartIdList(ByRef ComBox As ComboBox, ngdate As String, lineid As String)
        Dim dt As DataTable = QueryGetParetoNgData("", lineid, ngdate, 3)

        ComBox.Items.Clear()
        If dt.Rows.Count > 0 Then
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                ComBox.Items.Add(dt.Rows(rowIndex)(0).ToString)
            Next
        End If
    End Sub

    '取得不良处理数据
    Public Shared Function GetNGProcessData(partId As String, lineId As String, ngDate As String) As DataTable
        'NO, 不良项目, 不良现象，处理方案，责任人，完成时间，结果追踪
        GetNGProcessData = QueryGetParetoNgData(partId, lineId, ngDate, 8)
    End Function

    '取得不良数据
    Public Shared Function GetNGData(partId As String, lineId As String, ngDate As String) As DataTable
        ' 项次/ 不良内容/不良数 / 不良率 / 影响度 / 累计影响度
        '如果报表数据停用要修改，有分情况，1制程扫描，2有条码扫描，3无条码扫描
        GetNGData = QueryGetParetoNgData(partId, lineId, ngDate, 9)
    End Function

    '检查数据是否维修完成
    '只对当天的不良数据去检查是否完成不维修
    Public Shared Function IsCheckRepairFinish(partId As String, ngDate As String, lineId As String) As Boolean
        Dim dt As DataTable = QueryGetParetoNgData(partId, lineId, ngDate, 91)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    '检查数据是否被确认过
    Public Shared Function IsCheckConfirm(partId As String, ngDate As String, lineId As String) As Boolean
        Dim dt As DataTable = QueryGetParetoNgData(partId, lineId, ngDate, 92)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    '检查数据是否被确认过
    Public Shared Function IsCheckConfirmLine(partId As String, ngDate As String, lineId As String) As Boolean
        Dim dt As DataTable = QueryGetParetoNgData(partId, lineId, ngDate, 95)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' 共通取得数据
    ''' </summary>
    ''' <param name="partId"></param>
    ''' <param name="lineId"></param>
    ''' <param name="ngDate"></param>
    ''' <param name="type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QueryGetParetoNgData(partId As String, lineId As String, ngDate As String, type As String) As DataTable
        Dim strSQL As String = "EXEC m_QueryGetParetoNgData_p '{0}', '{1}', '{2}','{3}','{4}','{5}'"
        strSQL = String.Format(strSQL, partId, lineId, ngDate, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, type)

        Return DbOperateUtils.GetDataTable(strSQL)
    End Function
#End Region

#Region "按日期期间"

    '取得工单数量
    Public Shared Function GetProQty(partId As String, lineId As String, ngDateFrom As String, ngDateTo As String) As String
        Dim result As String = ""
        Using o_dt As DataTable = QueryGetParetoNgData(partId, lineId, ngDateFrom, ngDateTo, 1)
            If o_dt.Rows.Count > 0 Then
                result = o_dt.Rows(0)(0)
            End If
        End Using
        Return result
    End Function

    '取得确认用户名
    Public Shared Function GetConfirmName(partId As String, lineId As String, ngDateFrom As String, ngDateTo As String) As String
        Dim result As String = ""
        Using o_dt As DataTable = QueryGetParetoNgData(partId, lineId, ngDateFrom, ngDateTo, 2)
            If o_dt.Rows.Count > 0 Then
                result = o_dt.Rows(0)(0).ToString
            End If
        End Using
        Return result
    End Function

    '设置料件list
    Public Shared Sub GetPartIdList(ByRef ComBox As ComboBox, ngDateFrom As String, ngDateTo As String, lineid As String)
        Dim dt As DataTable = QueryGetParetoNgData("", lineid, ngDateFrom, ngDateTo, 3)

        ComBox.Items.Clear()
        If dt.Rows.Count > 0 Then
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                ComBox.Items.Add(dt.Rows(rowIndex)(0).ToString)
            Next
        End If
    End Sub

    '取得不良处理数据
    Public Shared Function GetNGProcessData(partId As String, lineId As String, ngDateFrom As String, ngDateTo As String) As DataTable
        'NO, 不良项目, 不良现象，处理方案，责任人，完成时间，结果追踪
        GetNGProcessData = QueryGetParetoNgData(partId, lineId, ngDateFrom, ngDateTo, 8)
    End Function

    '取得不良数据
    Public Shared Function GetNGData(partId As String, lineId As String, ngDateFrom As String, ngDateTo As String) As DataTable
        ' 项次/ 不良内容/不良数 / 不良率 / 影响度 / 累计影响度
        '如果报表数据停用要修改，有分情况，1制程扫描，2有条码扫描，3无条码扫描
        GetNGData = QueryGetParetoNgData(partId, lineId, ngDateFrom, ngDateTo, 9)
    End Function

    '检查数据是否维修完成
    '只对当天的不良数据去检查是否完成不维修
    Public Shared Function IsCheckRepairFinish(partId As String, ngDateFrom As String, ngDateTo As String, lineId As String) As Boolean
        Dim dt As DataTable = QueryGetParetoNgData(partId, lineId, ngDateFrom, ngDateTo, 91)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    '检查数据是否被确认过
    Public Shared Function IsCheckConfirm(partId As String, ngDateFrom As String, ngDateTo As String, lineId As String) As Boolean
        Dim dt As DataTable = QueryGetParetoNgData(partId, lineId, ngDateFrom, ngDateTo, 92)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    '检查数据是否被线长确认过
    Public Shared Function IsCheckConfirmLine(partId As String, ngDateFrom As String, ngDateTo As String, lineId As String) As Boolean
        Dim dt As DataTable = QueryGetParetoNgData(partId, lineId, ngDateFrom, ngDateTo, 95)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' 共通取得数据
    ''' </summary>
    ''' <param name="partId"></param>
    ''' <param name="lineId"></param>
    ''' <param name="ngDateFrom"></param>
    ''' <param name="ngDateTo"></param>
    ''' <param name="type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QueryGetParetoNgData(partId As String, lineId As String, ngDateFrom As String, ngDateTo As String, type As String) As DataTable
        Dim strSQL As String = "EXEC m_QueryGetParetoNgDataPeriod_p '{0}', '{1}', '{2}','{3}','{4}','{5}','{6}'"
        strSQL = String.Format(strSQL, partId, lineId, ngDateFrom, ngDateTo, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, type)

        Return DbOperateUtils.GetDataTable(strSQL)
    End Function

#Region "取得应该维护的料号"

    '取得不良数据
    Public Shared Function GetCheckPartIdData(partId As String, ngDateFrom As String, ngDateTo As String) As DataTable
        ' 项次/ 不良内容/不良数 / 不良率 / 影响度 / 累计影响度
        '
        GetCheckPartIdData = QueryGetParetoNgData(partId, "", ngDateFrom, ngDateTo, 94)
    End Function

#End Region

#End Region

#Region "根据工单处理"

    '取得工单数量
    Public Shared Function GetProQty(Moid As String, lineId As String) As String
        Dim result As String = ""
        Using o_dt As DataTable = QueryGetParetoNgData(Moid, lineId, 1)
            If o_dt.Rows.Count > 0 Then
                result = o_dt.Rows(0)(0)
            End If
        End Using
        Return result
    End Function

    '取得确认用户名
    Public Shared Function GetConfirmName(partId As String, lineId As String) As String
        Dim result As String = ""
        Using o_dt As DataTable = QueryGetParetoNgData(partId, lineId, 2)
            If o_dt.Rows.Count > 0 Then
                result = o_dt.Rows(0)(0).ToString
            End If
        End Using
        Return result
    End Function

    '取得工单对应料号
    Public Shared Function GetPartIdByMoid(Moid As String, lineId As String) As String
        Dim result As String = ""
        Using o_dt As DataTable = QueryGetParetoNgData(Moid, lineId, 4)
            If o_dt.Rows.Count > 0 Then
                result = o_dt.Rows(0)(0)
            End If
        End Using
        Return result
    End Function

    '设置工单list
    Public Shared Sub GetPartIdList(ByRef ComBox As ComboBox, lineid As String)
        Dim dt As DataTable = QueryGetParetoNgData("", lineid, 3)

        ComBox.Items.Clear()
        If dt.Rows.Count > 0 Then
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                ComBox.Items.Add(dt.Rows(rowIndex)(0).ToString)
            Next
        End If
    End Sub

    '取得不良处理数据
    Public Shared Function GetNGProcessData(partId As String, lineId As String) As DataTable
        'NO, 不良项目, 不良现象，处理方案，责任人，完成时间，结果追踪
        GetNGProcessData = QueryGetParetoNgData(partId, lineId, 8)
    End Function

    '取得不良数据
    Public Shared Function GetNGData(partId As String, lineId As String) As DataTable
        ' 项次/ 不良内容/不良数 / 不良率 / 影响度 / 累计影响度
        '如果报表数据停用要修改，有分情况，1制程扫描，2有条码扫描，3无条码扫描
        GetNGData = QueryGetParetoNgData(partId, lineId, 9)
    End Function

    '检查数据是否维修完成
    Public Shared Function IsCheckRepairFinish(partId As String, lineId As String) As Boolean
        Dim dt As DataTable = QueryGetParetoNgData(partId, lineId, 91)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    '检查数据是否被确认过
    Public Shared Function IsCheckConfirm(partId As String, lineId As String) As Boolean
        Dim dt As DataTable = QueryGetParetoNgData(partId, lineId, 92)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' 共通取得数据
    ''' </summary>
    ''' <param name="moid"></param>
    ''' <param name="lineId"></param>
    ''' <param name="type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function QueryGetParetoNgData(moid As String, lineId As String, type As String) As DataTable
        Dim strSQL As String = "EXEC m_QueryGetParetoMoidNgData_p '{0}', '{1}', '{2}','{3}','{4}'"
        strSQL = String.Format(strSQL, moid, lineId, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, type)

        Return DbOperateUtils.GetDataTable(strSQL)
    End Function
#End Region

    '设置不良率
    Public Shared Function GetTable(ByVal dt As DataTable) As DataTable
        Dim table As New Data.DataTable
        Dim o_iTotalNG As Integer = 0
        Dim o_tempImpactPer As String = String.Empty
        Dim o_sumImpactPer As String = String.Empty
        Dim o_ngrate As String = String.Empty
        Dim o_isumNGqty As Integer = 0
        Try
            table.Columns.Add("不良内容", GetType(String))
            table.Columns.Add("不良数", GetType(String))
            table.Columns.Add("不良率", GetType(String))
            table.Columns.Add("影响度", GetType(String))
            table.Columns.Add("累计影响度", GetType(String))

            o_iTotalNG = dt.Compute("sum(NGqty)", "")
            For Each dr As DataRow In dt.Rows
                o_tempImpactPer = CStr(Math.Round((dr.Item("NGqty") / o_iTotalNG) * 100, 1)) + "%"
                o_isumNGqty = o_isumNGqty + dr.Item("NGqty")
                o_sumImpactPer = CStr(Math.Round((o_isumNGqty / o_iTotalNG) * 100, 1)) + "%"
                table.Rows.Add(dr.Item("CCName"), dr.Item("NGqty"), dr.Item("ngrate").ToString + "%", o_tempImpactPer, o_sumImpactPer)
            Next
            table.Rows.Add("合计", dt.Compute("sum(NGqty)", ""), (dt.Compute("sum(ngrate)", "")).ToString + "%", "100%", "100%")

            Return table
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '显示等待窗体
    Public Shared Sub ShowWaitWindow()
        Dim frmwait As New FrmWait()
        frmwait.ShowDialog()
        Application.DoEvents()
    End Sub

    '设置厂区
    Public Shared Function GetFatoryOther() As String
        Dim strValue As String = String.Empty
        strValue = " AND FactoryID='" & VbCommClass.VbCommClass.Factory & "'"

        Return strValue
    End Function

#Region "得到一周第一天最后一天"

    '得到本周第一天(以星期天为第一天)    
    Public Shared Function GetWeekFirstDaySun(datetime As DateTime) As DateTime
        '星期天为第一天
        Dim weeknow As Integer = Convert.ToInt32(datetime.DayOfWeek)
        Dim daydiff As Integer = (-1) * weeknow
        '本周第一天  
        Dim FirstDay As String = datetime.AddDays(daydiff).ToString("yyyy/MM/dd")
        Return Convert.ToDateTime(FirstDay)
    End Function

    ''得到本周第一天(以星期一为第一天)    
    'Public Shared Function GetWeekFirstDayMon(datetime As DateTime) As DateTime
    '    '星期天为第一天
    '    Dim weeknow As Integer = Convert.ToInt32(datetime.DayOfWeek)
    '    '因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。  
    '    weeknow = IIf(weeknow = 0, (7 - 1), (weeknow - 1))
    '    Dim daydiff As Integer = (-1) * weeknow
    '    '本周第一天  
    '    Dim FirstDay As String = datetime.AddDays(daydiff).ToString("yyyy/MM/dd")
    '    Return Convert.ToDateTime(FirstDay)
    'End Function

    '得到本周最后一天(以星期六为最后一天)  
    Public Shared Function GetWeekLastDaySat(datetime As DateTime) As DateTime
        Dim weeknow As Integer = Convert.ToInt32(datetime.DayOfWeek)
        Dim daydiff As Integer = (7 - weeknow) - 1

        '本周最后一天  
        Dim LastDay As String = datetime.AddDays(daydiff).ToString("yyyy/MM/dd")
        Return Convert.ToDateTime(LastDay)
    End Function

    ''得到本周最后一天(以星期天为最后一天)  
    'Public Shared Function GetWeekLastDaySun(datetime As DateTime) As DateTime
    '    Dim weeknow As Integer = Convert.ToInt32(datetime.DayOfWeek)
    '    weeknow = IIf(weeknow = 0, 7, weeknow)
    '    Dim daydiff As Integer = (7 - weeknow)

    '    '本周最后一天  
    '    Dim LastDay As String = datetime.AddDays(daydiff).ToString("yyyy/MM/dd")
    '    Return Convert.ToDateTime(LastDay)
    'End Function

    Public Shared Function GetRejectText(SelectType As String, partId As String, lineid As String, ngDate As String) As String
        GetRejectText = ""

        Dim strSQL As String = ""
        Dim TableName As String = ""
        If SelectType = "日" Then
            TableName = "m_AssyTsProcss_t"
        ElseIf SelectType = "周" Then
            TableName = "m_AssyTsProcssWeek_t"
        ElseIf SelectType = "月" Then
            TableName = "m_AssyTsProcssMonth_t"
        End If

        strSQL = " SELECT TOP 10  ISNULL(RejectReason,'') FROM {0} WHERE partid = '{1}'  AND LineId = '{2}' " &
                 " AND CONVERT(VARCHAR(10),CAST(NgDate AS DATETIME),111) =  " &
                 " CONVERT(VARCHAR(10),CAST(REPLACE(REPLACE(REPLACE('{3}','年','-'), '月','-'),'日','') AS DATETIME),111)"

        strSQL = String.Format(strSQL, TableName, partId, lineid, ngDate)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            GetRejectText = dt.Rows(0)(0).ToString
        End If
    End Function



#End Region

#Region "取得第几周"

    '正常是中文环境
    Public Shared Function WeekOfYear(dt As DateTime) As Integer
        Return WeekOfYear(dt, New System.Globalization.CultureInfo("zh-CN"))
    End Function

    Public Shared Function WeekOfYear(dt As DateTime, ci As System.Globalization.CultureInfo) As Integer
        Return ci.Calendar.GetWeekOfYear(dt, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek)
    End Function

#End Region

End Class
