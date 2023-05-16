Imports System.Windows.Forms
Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Drawing
Imports System.Text



Public Class MainTainCommon

#Region "取得下拉框"

    ''' <summary>
    ''' 不良现象大类
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxCodeTypeBig(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select DISTINCT EsortName,CVer,(EsortName + '-' +CsortName) TEXT  from m_Code_t  where Usey='Y' ORDER BY CVer "
        'add by 马跃平 2017-12-20 王倩提出需求
        Dim UseId As String = VbCommClass.VbCommClass.UseId
        'Dim strSQL As String = "select SUBSTRING(Ttext,0,CHARINDEX('-',Ttext)) EsortName,Ttext AS TEXT from m_Logtree_t where Tkey in(" &
        '"SELECT Tkey FROM m_UserRight_t WHERE UserID='" + UseId + "' and Tkey like 'm20007_%' and Tkey <>'m20007_')"
        BindCombox(strSQL, ColComboBox, "Text", "EsortName")
    End Sub

    ''' <summary>
    ''' 不良现象
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxNG(ByVal ColComboBox As ComboBox, code As String)
        'Dim strSQL As String = String.Format("select CodeID,(CCName+ '-' +CodeID) Text from m_Code_t where EsortName='{0}' and usey='Y' ", code)


        Dim strSQL As String = String.Format("select CodeID,(CodeID+ '-' +CCName) Text from m_Code_t where EsortName='{0}' and usey='Y' ", code)

        BindCombox(strSQL, ColComboBox, "Text", "CodeID")
    End Sub

    ''' <summary>
    ''' 不良现象
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxNG2(ByVal ColComboBox As ComboBox, code As String, ByRef listOnit As List(Of String))
        Dim strSQL As String = String.Format("select CodeID,(CodeID+ '-' +CCName) Text from m_Code_t where EsortName='{0}' and usey='Y' ", code)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        ColComboBox.Text = ""
        ColComboBox.Items.Clear()
        listOnit = New List(Of String)
        listOnit.Add("")
        For index As Integer = 0 To dt.Rows.Count - 1
            listOnit.Add(dt.Rows(index)(1).ToString)
        Next
        '1.注意用Item.Add(obj)或者Item.AddRange(obj)方式添加
        '2.如果用DataSource绑定，后面再进行绑定是不行的，即便是Add或者Clear也不行
        ColComboBox.Items.AddRange(listOnit.ToArray())
    End Sub

    ''' <summary>
    ''' 工站类别
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <param name="Ppid"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxStationId(ByVal ColComboBox As ComboBox, ByVal Ppid As String)
        Dim strSQL As New StringBuilder
        'strSQL.Append("  select a.Stationid,a.Stationid+ '-' + a.Stationname  as Stationname from m_Rstation_t a inner join ")
        'strSQL.Append("  m_AssysnD_t(nolock) b on b.Stationid=a.Stationid ")
        'strSQL.Append(" where b.ppid='" & Ppid & "' AND NOT EXISTS(SELECT 1 FROM m_Assysn_t WHERE PPID='" & Ppid & "' AND m_Assysn_t.Stationid=a.Stationid) ")
        'm_AssysnD_t==>V_m_AssysnD_t, add TE 测试的工站

        'moidfy by hgd 20191115 注释
        'strSQL.Append("  select a.Stationid,a.Stationid+ '-' + a.Stationname  as Stationname from m_Rstation_t a inner join ")
        'strSQL.Append("  V_m_AssysnD_t(nolock) b on b.Stationid=a.Stationid ")
        'strSQL.Append(" where b.ppid='" & Ppid & "'")

        'modify by hgd 20191115 获取pplink后标签不一致的情况
        'strSQL.Append(" DECLARE @linkPpid varchar(150)	select top 1 @linkPpid=ppid from m_Ppidlink_t where Exppid='" & Ppid & "' and Exppid<>ppid order by Intime desc ")
        'strSQL.Append(" select distinct Stationid,Stationname from( select a.Stationid,a.Stationid+ '-' + a.Stationname  as Stationname from m_Rstation_t a inner join  ")
        'strSQL.Append(" V_m_AssysnD_t(nolock) b on b.Stationid=a.Stationid where b.ppid=@linkPpid union all ")
        'strSQL.Append(" select a.Stationid,a.Stationid+ '-' + a.Stationname  as Stationname from m_Rstation_t a inner join ")
        'strSQL.Append("  V_m_AssysnD_t(nolock) b on b.Stationid=a.Stationid where b.ppid='" & Ppid & "') a  ")
        strSQL.AppendFormat(" EXEC m_SearchNgStationNew_p '{0}' ,'{1}', '{2}','{3}','{4}' ",
                    "", Ppid, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, 2)

        BindCombox(strSQL.ToString, ColComboBox, "Stationname", "Stationid")
    End Sub


    ''' <summary>
    ''' 工站名称
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxStationType(ByVal ColComboBox As ComboBox)
        Dim strSQL As String
        strSQL = "SELECT SortID+ '-' + SortName as  SortName,SortID from m_Sortset_t where SortType = 'StationType' and Usey='Y' order by Orderid"
        BindCombox(strSQL, ColComboBox, "SortName", "SortID")
    End Sub

    ''' <summary>
    ''' 时间节次,只显示
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxDateJie(ByVal ColComboBox As ComboBox)
        '+'('+ StartDt + '～' + EndDt  +')'ClassName
        Dim strSQL As String = " select ClassName ,OrderIndex  from m_KanbanClass_t " &
                               " where ClassType = 'C004'  order by OrderIndex"

        BindComboxNoBlank(strSQL, ColComboBox, "ClassName", "OrderIndex")
    End Sub

    Public Shared Function GetNgStationByBigCategory(target As String) As String

        Dim strSQL As String = "select station from m_Code_t where CodeID = '{0}' and usey='Y' "
        strSQL = String.Format(strSQL, target)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0).ToString
        End If
        Return ""
    End Function

    ''' <summary>
    ''' 不良品维修作业
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxNGOperate(ByVal ColComboBox As ComboBox, code As String)
        Dim strSQL As String = String.Format(
        " exec m_QueryNgMainTainStyle_p  '{0}' ", code)

        BindCombox(strSQL, ColComboBox, "Text", "mstyleid")
    End Sub

    Public Shared Sub BindComboxNGOperateModel(ByVal ColComboBox As ComboBox, code As String, Model As String)
        Dim strSQL As String = String.Format(
        " exec m_QueryNgMainTainStyleModel_p  '{0}','{1}' ", code, Model)

        BindCombox(strSQL, ColComboBox, "Text", "mstyleid")
    End Sub

    Public Shared Sub BindComboxNGIdea(ByVal ColComboBox As ComboBox, barcode As String)
        Dim strSQL As String = String.Format(" exec m_QueryNgIdea_p  '{0}' ", barcode)

        BindCombox(strSQL, ColComboBox, "SortName", "sortid")
    End Sub

    Public Shared Function GetPPIDModel(barcode As String)  as String
        Dim strSQL As String = String.Format(" exec m_QueryPPIDModel_p  '{0}' ", barcode)

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetPPIDModel = o_dt.Rows(0).Item(0)
            Else
                GetPPIDModel = ""
            End If
        End Using
    End Function

        ''' <summary>
        ''' 设置课别
        ''' </summary>
        ''' <param name="ColComboBox"></param>
        ''' <remarks></remarks>
    Public Shared Sub BindComboxClass(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "SELECT deptid ,dqc  FROM m_Dept_t WHERE usey='Y' " &
                                GetFatoryOther()
        Dim strOrderby As String = " ORDER BY dsort asc "

        BindCombox(strSQL + strOrderby, ColComboBox, "dqc", "deptid")

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

    ''' <summary>
    ''' 设置线别
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <param name="cboClass"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxLine(ByVal ColComboBox As ComboBox, cboClass As String)
        Dim strSQL As String = String.Format("SELECT lineid FROM [deptline_t] where usey='Y' and deptid = '{0}'", cboClass) &
                               GetFatoryOther()

        BindCombox(strSQL, ColComboBox, "lineid", "lineid")
    End Sub

    ''' <summary>
    ''' 设置状态
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxStatus(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select SortID value,(SortID + '-' + SortName) text from m_Sortset_t  where SortType = 'NGPRODUCTSTATUS' and Usey  = 'Y' order by Orderid "

        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    ''' <summary>
    ''' 不良现象
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxNGBig(ByVal ColComboBox As ComboBox, code As String)
        Dim strSQL As String = "select distinct rCodeID,(rCodeID + '-' + ISNULL(rCCName,'')) Text  from m_coder_t where rEsortName='" & code & "' and   usey='Y' "

        BindCombox(strSQL, ColComboBox, "Text", "rCodeID")
    End Sub

    ''' <summary>
    ''' 改善对策方法
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <param name="code"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxFASort(ByVal ColComboBox As ComboBox, code As String)
        Dim strSQL As String = "select distinct rCodeID,(rCodeID + '-' + ISNULL(rCCName,'')) Text  from m_coder_t where rEsortName='" & code & "' and   usey='Y' "

        BindCombox(strSQL, ColComboBox, "Text", "rCodeID")
    End Sub

    ''' <summary>
    ''' 报废部件
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxTavcPart(ByVal ColComboBox As ComboBox, code As String)
        Dim strSQL As String = "SELECT TAvcPart, (ISNULL(TypeDest,''))Text FROM m_PartContrast_t WHERE PAvcPart='{0}' "
        If VbCommClass.VbCommClass.Factory = "LX53" Then '江西报废添加成品报废
            strSQL += " AND usey='Y' "
        Else
            strSQL += " AND TAvcPart<>PAvcPart and   usey='Y' "
        End If
        strSQL = String.Format(strSQL, code)

        BindCombox(strSQL, ColComboBox, "Text", "TAvcPart")
    End Sub

    ''' <summary>
    ''' 客户资料
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxCustomer(ByVal ColComboBox As ComboBox)
        Dim strSQL As String =
            "SELECT A.Cusid,(A.Cusid + '-' +B.CusName)Text  FROM" & _
            " (SELECT DISTINCT Cusid FROM m_Mainmo_t WHERE ISNULL(Cusid,'')<>''" & _
            " UNION " & _
            " SELECT DISTINCT Cusid FROM m_PartContrast_t WHERE ISNULL(Cusid,'')<>'') A" & _
            " INNER JOIN m_Customer_t B ON A.Cusid=B.CusID" & _
            " ORDER BY A.Cusid"
        BindCombox(strSQL, ColComboBox, "Text", "Cusid") ''填充客戶
    End Sub

    '设置料号数据
    Public Shared Sub SetPartIdList(lineId As String, startTime As Date, endTime As Date, ByVal ColComboBox As ComboBox)
        Dim strSQL As String =
            " select distinct partid from m_mainmo_t MM" &
            " inner join m_Carton_t CT " &
            " on MM .Moid = CT.Moid " &
            " where MM.lineid = '{0}' " &
            " and Convert(varchar(10), CT.Intime,111) BETWEEN '{1}' AND '{2}'"
        strSQL = String.Format(strSQL, lineId, startTime.ToString("yyyy/MM/dd"), endTime.ToString("yyyy/MM/dd"))

        BindComboxNoBlank(strSQL, ColComboBox, "partid", "partid")
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

#End Region

#Region "记录数量"

    ''' <summary>
    ''' 取得数据不良数据表Itemid
    ''' </summary>
    ''' <param name="ppid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAssyTsItemId(ppid As String) As Integer
        Dim strSQL As String = "select isnull(MAX(Itemid),0) +1  from m_AssyTs_t where Ppid='" & ppid & "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Return Convert.ToInt16(dt.Rows(0)(0).ToString)
    End Function

    '无条码序号时，生成条码
    Public Shared Function GetPPID(moid As String) As String
        Dim strSQL As String =
            " SELECT '{0}'+'-NG'+RIGHT('000'+CAST(ISNULL(MAX(RIGHT(PPID,3)),0)+1 AS VARCHAR),3) PPID FROM m_AssyTs_t " &
            " WHERE MOID ='{0}' AND PPID LIKE '{0}'+'-NG%' "
        strSQL = String.Format(strSQL, moid)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Return dt.Rows(0)(0).ToString
    End Function

    '工单SN历史NG个数(ProTotNGQty)
    Public Shared Function GetNGQtyByPPID(ppid As String) As Integer
        Dim strSQL As String = "select 1 from m_AssyTs_t where ppid = '{0}'"
        strSQL = String.Format(strSQL, ppid)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Return dt.Rows.Count
    End Function

    ''' <summary>
    ''' SN当前NG个数(ProNGQty) <>'P'
    ''' </summary>
    ''' <param name="ppid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetProNGQtyByPPID(ppid As String) As Integer
        Dim strSQL As String = "select 1  from m_AssyTs_t where ppid = '{0}' and Stateid <>'P'"
        strSQL = String.Format(strSQL, ppid)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Return dt.Rows.Count
    End Function

    ''' <summary>
    ''' 工站SN历史NG个数(TotNGQty) 带P
    ''' </summary>
    ''' <param name="ppid"></param>
    ''' <param name="stationId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetNGQtyByPPIDStaionID(ppid As String, stationId As String) As Integer
        Dim strSQL As String = "select 1 from m_AssyTs_t where ppid = '{0}' and  Stationid = '{1}'"
        strSQL = String.Format(strSQL, ppid, stationId)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Return dt.Rows.Count
    End Function

    ''' <summary>
    ''' 工站SN当前NG个数(NGQty)  <>'P'
    ''' </summary>
    ''' <param name="ppid"></param>
    ''' <param name="stationId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetProNGQtyByPPIDStaionID(ppid As String, stationId As String) As Integer
        Dim strSQL As String = "select 1 from m_AssyTs_t where ppid = '{0}' and  Stationid = '{1}' and Stateid <>'P'"
        strSQL = String.Format(strSQL, ppid, stationId)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Return dt.Rows.Count
    End Function

#End Region

#Region "取得维修清单通过PPID"

    '取得维修清单通过PPID
    Public Shared Function GetMainListByPpid(ppid As String, Optional ByVal type As String = "") As DataTable
        Dim strWhere As String = String.Format(" and a.ppid='{0}' ", ppid)
        Return GetMainList(strWhere, type)
    End Function

    '取得维修清单通过PPID
    Public Shared Function GetMainListByPpidNew(ppid As String, Optional ByVal type As String = "") As DataTable
        'Dim strWhere As String = String.Format(" and a.ppid='{0}' ", ppid)
        'Return GetMainListNew(strWhere, type)
        Dim strSQL As String = " exec m_SearchNgData_p '{0}','{1}','{2}','{3}','{4}','{5}','{6}'"
        strSQL = String.Format(strSQL, "", ppid, "", VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, 1, type)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Return dt
    End Function

#End Region

#Region "取得维修清单通过工单"
    '取得维修清单通过工单
    Public Shared Function GetMainListByMoid(moid As String, Optional ByVal type As String = "") As DataTable
        Dim strWhere As String = String.Format(" and a.moid='{0}' ", moid)
        Return GetMainList(strWhere, type)
    End Function

    '取得维修清单通过工单
    Public Shared Function GetMainListByMoidNew(moid As String, Optional ByVal type As String = "") As DataTable
        Dim strSQL As String = " exec m_SearchNgData_p '{0}','{1}','{2}','{3}','{4}','{5}','{6}'"
        strSQL = String.Format(strSQL, moid, "", "", VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, 2, type)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Return dt
    End Function

    Public Shared Function GetMainList(strWhere As String, Optional ByVal type As String = "") As DataTable
        Dim strSQL As String = String.Empty
        strSQL = GetSearchSQL()

        Dim strOrder As String = " order by Intime desc "
        If type = "repair" Then
            strOrder = " order by Stateid asc,Intime desc " 'a.Ppid,a.Itemid,
        End If

        strSQL = strSQL + strWhere + strOrder

        Return DbOperateUtils.GetDataTable(strSQL)
    End Function


    'Public Shared Function GetMainListNew(strWhere As String, Optional ByVal type As String = "") As DataTable
    '    Dim strSQL As String = String.Empty
    '    strSQL = GetSearchSQLNew()

    '    Dim strOrder As String = " order by Intime desc "
    '    If type = "repair" Then
    '        strOrder = " order by Stateid asc,Intime desc " 'a.Ppid,a.Itemid,
    '    End If

    '    strSQL = strSQL + strWhere + strOrder

    '    Return DbOperateUtils.GetDataTable(strSQL)
    'End Function

    Public Shared Function GetSearchSQL()
        Dim strSQL As String =
         " select distinct top 9999 a.partid,a.Lineid,isnull(a.moid,'') moid, " &
         "    a.Ppid,a.Pppid,a.stationid,a.Codeitem,b.CsortName,a.Itemid,a.NgStationId, " &
         "   (a.stationid + '-'+ isnull(d.Stationname,''))stationname," &
         "   (a.Codeid + '-'+ isnull(b.ccname,''))ccname," &
         "   (a.Rcodeid + '-'+ isnull(c.rccname,''))rccname," &
         "   (a.Solution + '-'+ e.MstyleName) Solution ," &
         "   a.Codeid, a.Rcodeid, convert(nvarchar(10),cast(a.NgDate as date),111) NgDate, a.NgQty,a.Suggestion," &
         "   case when Stateid='B' then Stateid + N'-驳回'  when Stateid='D' then Stateid + N'-不良品待维修'  when Stateid='G' then Stateid + N'-维修OK待确认'" &
         "   when  Stateid='E' then Stateid + N'-产品已报废' when Stateid='P' then Stateid +N'-IPQC已确认' else N'A-在制良品' end Stateid, " &
         "   (select users.UserName  from m_Users_t users where users.UserID = a.Userid) Userid ,a.Ngdate,a.Intime,a.Remark, " &
         "   MaintainID, isnull(SmallSit,'') SmallSit,Stateid as StateStr,a.stationid,  " &
         "   CASE WHEN  isnull(a.ReStationId, '') <> '' THEN a.ReStationId + (CASE when isnull(d2.stationName,'') <> '' THEN  '-' ELSE '' END) + isnull(d2.stationName,'') else '' end ReStationId,a.ReStationId as R_StationId," &
         "   CASE WHEN  isnull(a.NgStationId, '') <> '' THEN a.NgStationId + (CASE when isnull(d3.stationName,'') <> '' THEN  '-' ELSE '' END) + isnull(d3.stationName,'') else '' end MESStationId,a.NgStationId as MesStationId " &
         " FROM m_AssyTs_t a" &
         " INNER JOIN m_Mainmo_t mm ON a.Moid = mm.Moid " &
         " LEFT JOIN m_Code_t b ON a.codeid=b.codeid AND a.Codeitem=b.EsortName" &
         " LEFT JOIN m_CodeR_t c ON a.Rcodeid=c.rCodeID" &
         " LEFT JOIN m_Rstation_t d ON a.Stationid = d.Stationid" &
         " LEFT JOIN m_Rstation_t d2 ON a.ReStationId = d2.Stationid " &
         " LEFT JOIN m_Rstation_t d3 ON a.NgStationId = d3.Stationid  " &
         " LEFT JOIN m_MainTainStyle_t e on a.Solution = e.mstyleid" &
         " LEFT JOIN deptline_t f on f.lineid = a.Lineid " &
         " WHERE isnew='Y' " & GetFatoryProfitcenter("mm")

        GetSearchSQL = strSQL
    End Function

    Public Shared Function GetSearchSQLNew()
        Dim strSQL As String =
           " select distinct top 9999 a.partid,a.Lineid,isnull(a.moid,'') moid, " &
           "    a.Ppid,a.Pppid,a.stationid,a.Codeitem,b.CsortName,a.Itemid,a.NgStationId, " &
           "   (a.stationid + '-'+ isnull(d.Stationname,''))stationname," &
           "   (a.Codeid + '-'+ isnull(b.ccname,''))ccname," &
           "   (a.Rcodeid + '-'+ isnull(c.rccname,''))rccname," &
           "   (a.Solution + '-'+ e.MstyleName) Solution ," &
           "   a.Codeid, a.Rcodeid, convert(nvarchar(10),cast(a.NgDate as date),111) NgDate, a.NgQty,a.Suggestion," &
           "   case when Stateid='B' then Stateid + N'-驳回'  when Stateid='D' then Stateid + N'-不良品待维修'  when Stateid='G' then Stateid + N'-维修OK待确认'" &
           "   when  Stateid='E' then Stateid + N'-产品已报废' when Stateid='P' then Stateid +N'-IPQC已确认' else N'A-在制良品' end Stateid, " &
           "   (select users.UserName  from m_Users_t users where users.UserID = a.Userid) Userid ,a.Ngdate,a.Intime,a.Remark, " &
           "   MaintainID, isnull(SmallSit,'') SmallSit,Stateid as StateStr,a.stationid,  " &
           "   CASE WHEN  isnull(a.ReStationId, '') <> '' THEN a.ReStationId + (CASE when isnull(d2.stationName,'') <> '' THEN  '-' ELSE '' END) + isnull(d2.stationName,'') else '' end ReStationId,a.ReStationId as R_StationId," &
           "   CASE WHEN  isnull(a.NgStationId, '') <> '' THEN a.NgStationId + (CASE when isnull(d3.stationName,'') <> '' THEN  '-' ELSE '' END) + isnull(d3.stationName,'') else '' end MESStationId,a.NgStationId as MesStationId " &
           " FROM m_AssyTs_t a" &
           " INNER JOIN m_Mainmo_t mm ON a.Moid = mm.Moid " &
           " LEFT JOIN m_Code_t b ON a.codeid=b.codeid AND a.Codeitem=b.EsortName" &
           " LEFT JOIN m_CodeR_t c ON a.Rcodeid=c.rCodeID" &
           " LEFT JOIN m_Rstation_t d ON a.Stationid = d.Stationid" &
           " LEFT JOIN m_Rstation_t d2 ON a.ReStationId = d2.Stationid " &
           " LEFT JOIN m_Rstation_t d3 ON a.NgStationId = d3.Stationid  " &
           " LEFT JOIN m_MainTainStyle_t e on a.Solution = e.mstyleid" &
           " LEFT JOIN deptline_t f on f.lineid = a.Lineid " &
           " WHERE isnew='Y' " & GetFatoryProfitcenter("mm")

        GetSearchSQLNew = strSQL
    End Function


    Public Shared Function GetSearchSQLEXCEL()
        Dim strSQL As String =
         " select distinct a.partid 成品料号,isnull(a.moid,'') 工单, a.Lineid 线别, " &
         "    a.Ppid 成品条码序号,a.Itemid 不良明细ID,  " &
         "   (a.stationid + '-'+ isnull(d.Stationname,''))不良发生站点," &
         "    CASE WHEN  isnull(a.NgStationId, '') <> '' THEN a.NgStationId + (CASE when isnull(d3.stationName,'') <> '' THEN  '-' ELSE '' END) + isnull(d3.stationName,'') else '' end	MES不良发生站点," &
         "   (a.Codeid + '-'+ isnull(b.ccname,''))不良现象," &
         "   (a.Rcodeid + '-'+ isnull(c.rccname,''))不良原因," &
         "    CASE WHEN  isnull(a.ReStationId,'') <> '' THEN a.ReStationId + (CASE when isnull(d2.stationName,'') <> '' THEN  '-' ELSE '' END) + isnull(d2.stationName,'') else '' end N'维修返回工站'," &
         "   (a.Solution + '-'+ e.MstyleName) 维修方法 ," &
         "   convert(nvarchar(10),cast(a.NgDate as date),111) 不良日期,a.NgQty 不良数量,a.Suggestion 改善对策," &
         "   case when Stateid='B' then Stateid + N'-驳回'  when Stateid='D' then Stateid + N'-不良品待维修'  when Stateid='G' then Stateid + N'-维修OK待确认'" &
         "   when  Stateid='E' then Stateid + N'-产品已报废' when Stateid='P' then Stateid +N'-IPQC已确认' else N'A-在制良品' end 状态, " &
         "   (select users.UserName  from m_Users_t users where users.UserID = a.Userid) 用记名 ,a.Intime 操作时间,Stateid, " &
         "   MaintainID 维修ID" &
         " FROM m_AssyTs_t a" &
         " INNER JOIN m_Mainmo_t mm ON a.Moid = mm.Moid " &
         " LEFT JOIN m_Code_t b ON a.codeid=b.codeid AND a.Codeitem=b.EsortName" &
         " LEFT JOIN m_CodeR_t c ON a.Rcodeid=c.rCodeID" &
         " LEFT JOIN m_Rstation_t d ON a.Stationid = d.Stationid" &
         " LEFT JOIN m_Rstation_t d2 ON a.ReStationId = d2.Stationid " &
         " LEFT JOIN m_Rstation_t d3 ON a.NgStationId = d3.Stationid   " &
         " LEFT JOIN m_MainTainStyle_t e on a.Solution = e.mstyleid" &
         " LEFT JOIN deptline_t f on f.lineid = a.Lineid " &
         " WHERE isnew='Y' " & GetFatoryProfitcenter("mm")

        GetSearchSQLEXCEL = strSQL
    End Function

    Public Shared Function GetSearchSQLEXCELNew()
        Dim strSQL As String =
         " select distinct a.partid 成品料号,isnull(a.moid,'') 工单, a.Lineid 线别, " &
         "    a.Ppid 成品条码序号,a.Itemid 不良明细ID,  " &
         "   (a.stationid + '-'+ isnull(d.Stationname,''))不良发生站点," &
         "    CASE WHEN  isnull(a.NgStationId, '') <> '' THEN a.NgStationId + (CASE when isnull(d3.stationName,'') <> '' THEN  '-' ELSE '' END) + isnull(d3.stationName,'') else '' end	MES不良发生站点," &
         "   (a.Codeid + '-'+ isnull(b.ccname,''))不良现象," &
         "   (a.Rcodeid + '-'+ isnull(c.rccname,''))不良原因," &
         "    CASE WHEN  isnull(a.ReStationId,'') <> '' THEN a.ReStationId + (CASE when isnull(d2.stationName,'') <> '' THEN  '-' ELSE '' END) + isnull(d2.stationName,'') else '' end N'维修返回工站'," &
         "   (a.Solution + '-'+ e.MstyleName) 维修方法 ," &
         "   convert(nvarchar(10),cast(a.NgDate as date),111) 不良日期,a.NgQty 不良数量,a.Suggestion 改善对策," &
         "   case when Stateid='B' then Stateid + N'-驳回'  when Stateid='D' then Stateid + N'-不良品待维修'  when Stateid='G' then Stateid + N'-维修OK待确认'" &
         "   when  Stateid='E' then Stateid + N'-产品已报废' when Stateid='P' then Stateid +N'-IPQC已确认' else N'A-在制良品' end 状态, " &
         "   (select users.UserName  from m_Users_t users where users.UserID = a.Userid) 用记名 ,a.Intime 操作时间,Stateid, " &
         "   MaintainID 维修ID" &
         " FROM m_AssyTs_t a" &
         " INNER JOIN m_Mainmo_t mm ON a.Moid = mm.Moid " &
         " LEFT JOIN m_Code_t b ON a.codeid=b.codeid AND a.Codeitem=b.EsortName" &
         " LEFT JOIN m_CodeR_t c ON a.Rcodeid=c.rCodeID" &
         " LEFT JOIN m_Rstation_t d ON a.Stationid = d.Stationid" &
         " LEFT JOIN m_Rstation_t d2 ON a.ReStationId = d2.Stationid " &
         " LEFT JOIN m_Rstation_t d3 ON a.NgStationId = d3.Stationid   " &
         " LEFT JOIN m_MainTainStyle_t e on a.Solution = e.mstyleid" &
         " LEFT JOIN deptline_t f on f.lineid = a.Lineid " &
         " WHERE isnew='Y' " & GetFatoryProfitcenter("mm")

        GetSearchSQLEXCELNew = strSQL
    End Function

    Public Shared Function GetSearchSQLRepairEXCEL(lineId As String, partId As String, ngDate As String) As DataTable
        Dim strSQL As String =
        "  SELECT CASE station.Stationid WHEN 'T00017' THEN N'功能不良' WHEN 'T00018' THEN N'功能不良' " &
        "       WHEN 'T00019' THEN N'功能不良' WHEN 'T00020' THEN N'功能不良' ELSE station.Stationname END AS N'不良现象' ," &
        "       station.Stationname N'发现工站', Code.CCName N'不良现象2' ,NGqty N'不良数'," &
        "       CodeR.rCCName AS N'不良原因' ,Style.MstyleName AS N'处理方式' " &
        "   FROM (" &
        "   SELECT Stationid, Codeid ,Rcodeid ,Solution ,SUM(NGqty) NGqty FROM M_ASSYTS_T A" &
        "   INNER JOIN m_Mainmo_t mm ON a.Moid = mm.Moid " &
        "   WHERE A.LINEID = '{0}' AND A.PARTID = '{1}'  " &
        "   AND CONVERT(VARCHAR(10),CAST(NGDATE AS DATETIME),111) = CONVERT(VARCHAR(10),CAST('{2}' AS DATETIME),111)" &
        "   AND IsNew = 'Y' AND Stateid <> '' AND ISNULL(Rcodeid,'')<> '' " & GetFatoryProfitcenter("mm") &
        "   GROUP BY Stationid, Codeid ,Rcodeid ,Solution)AT" &
        "   LEFT JOIN m_Rstation_t station ON station.Stationid = AT.Stationid" &
        "   LEFT JOIN m_Code_t Code ON AT.Codeid = Code.CodeID " &
        "   LEFT JOIN m_CodeR_t CodeR ON AT.RCODEID = CodeR .rCodeID " &
        "   LEFT JOIN m_MainTainStyle_t Style ON AT.Solution = Style .MstyleId" &
        "   ORDER BY AT.Stationid"
        strSQL = String.Format(strSQL, lineId, partId, ngDate)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Return dt
    End Function

#End Region

#Region "取得报废清单"
    '取得报废明细
    Public Shared Function GetScrapTable(ppid As String, itemId As String) As DataTable
        Dim dt As DataTable

        Dim strSQL As String =
             " select DISTINCT Tpartid, ScrapQty," &
             " (SELECT TOP 1 TypeDest FROM m_PartContrast_t PC WHERE ATS.[Tpartid] = PC.TAvcPart AND PC.TAvcPart <> PC. PAvcPart) TypeDest, " &
             " (SELECT TOP 1 dqc FROM m_Dept_t DP WHERE ATS.DeptID = DP.DeptID) DeptName  from m_AssyTsScrap_t ATS" &
             " where Ppid = '{0}' and paritemId = '{1}'"
        strSQL = String.Format(strSQL, ppid, itemId)

        dt = DbOperateUtils.GetDataTable(strSQL)
        Return dt
    End Function
#End Region

#Region "取得系统时间"

    Public Shared Function GetCurrentSysteJie() As String
        GetCurrentSysteJie = ""
        Dim strSQL As String = " select OrderIndex, StartDt,EndDt  from m_KanbanClass_t " &
                               " where ClassType = 'C004' and CONVERT(varchar(12),getdate(),108) between  StartDt and EndDt"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            GetCurrentSysteJie = dt.Rows(0)(0).ToString
        End If
    End Function

    Public Shared Function GetNgAlertTime(selectIndex As String) As String
        GetNgAlertTime = ""

        Dim strSQL As String =
            " declare @currentIndex varchar(2) " &
            " select @currentIndex = OrderIndex  from m_KanbanClass_t " &
            " where ClassType = 'C004' and CONVERT(varchar(12),getdate(),108) between  StartDt and EndDt" &
            " if (@currentIndex = '{0}')" &
            " begin select CONVERT(varchar(12),getdate(),108) end " &
            " else begin select NgAlertTime from m_KanbanClass_t " &
            " where ClassType = 'C004' and OrderIndex = '{0}' end"

        strSQL = String.Format(strSQL, selectIndex)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            GetNgAlertTime = dt.Rows(0)(0).ToString
        End If
    End Function
#End Region

    '得到工单LIST
    Public Shared Function GetMOList(ByVal MoId As String, ByVal strSupportId As String, Lineid As String) As DataTable
        Dim strWhere As String = ""
        If (Not String.IsNullOrEmpty(MoId)) Then
            strWhere = " AND Moid LIKE '%" & MoId & "%'"
        End If

        If (Not String.IsNullOrEmpty(strSupportId)) Then
            strWhere = strWhere + " AND cusid LIKE '%" & strSupportId & "%'"
        End If

        If (Not String.IsNullOrEmpty(Lineid)) Then
            strWhere = strWhere + " AND Lineid LIKE '" & Lineid & "'"
        End If

        strWhere = strWhere + " AND Factory = '" & VbCommClass.VbCommClass.Factory & "'"
        strWhere = strWhere + " AND profitcenter = '" & VbCommClass.VbCommClass.profitcenter & "'"

        Dim strSQL As String = "SELECT TOP 100 Moid, PartID, Moqty, Remark FROM m_Mainmo_t WHERE FinalY='N'" & strWhere & " ORDER BY Createtime DESC"
        Return DbOperateUtils.GetDataTable(strSQL)
    End Function

    '设置错误信息
    Public Shared Sub SetMessage(ByVal lblMessage As Label, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

    '设置厂区
    Public Shared Function GetFatoryOther() As String
        Dim strValue As String = String.Empty
        strValue = " AND FactoryID='" & VbCommClass.VbCommClass.Factory & "'"

        Return strValue
    End Function

    Public Shared Function GetFatoryProfitcenter() As String
        Dim strValue As String = String.Empty
        strValue = " AND Factory='" & VbCommClass.VbCommClass.Factory & "'"
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + " AND Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'"
        End If
        Return strValue
    End Function

    Public Shared Function GetFatoryProfitcenter(table As String) As String
        Dim strValue As String = String.Empty
        strValue = String.Format(" AND {0}.Factory='" & VbCommClass.VbCommClass.Factory & "'", table)
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + String.Format(" AND {0}.Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'", table)
        End If
        Return strValue
    End Function


End Class
