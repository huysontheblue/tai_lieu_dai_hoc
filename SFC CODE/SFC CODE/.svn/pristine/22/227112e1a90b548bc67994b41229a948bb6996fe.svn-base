Imports Aspose.Cells
Imports MainFrame
Imports System.Text
Imports MainFrame.SysCheckData

Public Class RunCardBusiness

    Private Shared factoryID As String = VbCommClass.VbCommClass.Factory
    Private Shared profitCenter As String = VbCommClass.VbCommClass.profitcenter
    Private Shared userID As String = VbCommClass.VbCommClass.UseId

    Public Enum HeaderGrid
        CheckBox = 0
        ClickTime
        PartId
        TypeDest
        DESCRIPTION
        DrawingVer
        Shape
        FileNO  '文件编号
        DrawingFilePath
        FinishSize
        Status
        ZStatus
        UserId
        InTime
        ModifyTime
        Remark
        OldVersion
        RCardType '工站类型
        '选择 /料件编号/描述/[总工时]/规格/版本/形态/图纸文件/制作状态/创建人
    End Enum
    Public Enum RCardLogGrid
        ID
        PartId
        StationName
        type
        UserName
        OldModifyTime
        OldValue
        NewUserID
        NewModifyTime
        NewValue
        '选择 /料件编号/描述/[总工时]/规格/版本/形态/图纸文件/制作状态/创建人
        'a.ID,a.PartID," & _
        '        " b.StationName, type, c.UserName,  OldModifyTime,OldValue," & _
        '        " d.UserName as NewUserID,a.NewModifyTime,a.NewValue " & _
    End Enum

    Public Enum NewHeaderGrid
        CheckBox = 0
        ClickTime
        PartId
        TypeDest
        TotalHours
        DESCRIPTION
        DrawingVer
        Shape
        StdLabors
        StdUPPH
        StdUPH
        SeriesName
        DrawingFilePath
        FinishSize
        Status
        ZStatus
        UserId
        InTime
        ModifyTime
        Remark
        OldVersion
        '选择 /料号/描述/[总工时]/规格/版本/形态/图纸文件/制作状态/创建人
    End Enum

    Public Enum BodyGrid
        PartId = 0
        StationID
        StationSQ
        StationName
        SectionID
        WorkingHours
        Equipment
        ProcessStandard
        NewProcessStandard
        Remark
        SOP
        Status
        UserId
        InTime
        Shape
        Uid
    End Enum

    Public Enum CutBodyGrid
        PartId = 0
        StationID
        StationSQ
        StationName
        SectionID
        WorkingHours
        Equipment
        ProcessStandard
        LeftProcessStandard
        RightProcessStandard
        NewProcessStandard
        Remark
        SOP
        Status
        UserId
        InTime
        Shape
        Uid
    End Enum
    Public Enum OldCutBodyGrid
        PartId = 0
        StationID
        StationSQ
        StationName
        SectionID
        WorkingHours
        Equipment
        ProcessStandard
        LeftProcessStandard
        RightProcessStandard
        NewProcessStandard
        Remark
        SOP
        LCLValue
        LeftTVPN
        RightTVPN
        WirePN
        Status
        UserId
        InTime
        Shape
        Uid
    End Enum

    Public Enum BomInfo
        ID = 0
        ParentPartId
        ChildPartId
        Version
        ParentFormat
        ChildFormat
        ParentDescription
        ChildDescription
        EffectiveDate
        ExpirationDate
        Extensible
        ExtensibleF
        Qty
        CustID
        SeriesID
    End Enum

    Public Shared Function GetBomInfo(ByVal runCardPartId As String) As DataTable
        Dim dt As DataTable
        Try
            Dim StrSql As String = "SELECT 1 FROM m_PartContrast_t(nolock) WHERE PAvcPart='" & runCardPartId & _
                                   "' AND ExpirationDate<>'' and CONVERT(datetime,ExpirationDate,120 )< getdate()"

            dt = DbOperateUtils.GetDataTable(StrSql)

        Catch ex As Exception
            Throw ex
        End Try

        Return dt
    End Function

    Public Shared Function IsSetPN(PartId) As Boolean
        Dim dtResult As DataTable = Nothing
        Try
            'AND IMA31='SET'
            Dim StrSql As String = " SELECT IMA31,IMA02, IMA021 FROM  " & factoryID & ".IMA_FILE " & _
                                   " WHERE IMA01='" & PartId & "'  "

            dtResult = RCardComBusiness.GetDataTableOracle(StrSql)
            If Not IsNothing(dtResult) AndAlso dtResult.Rows.Count > 0 Then
                If CStr(dtResult.Rows(0).Item("IMA31")).ToUpper = "SET" Then
                    IsSetPN = True
                Else
                    If CStr(dtResult.Rows(0).Item("IMA02")).IndexOf("成套") >= 0 Then
                        IsSetPN = True
                    Else
                        If CStr(dtResult.Rows(0).Item("IMA021")).IndexOf("成套") >= 0 Then
                            IsSetPN = True
                        Else
                            IsSetPN = False
                        End If
                    End If
                End If
            Else
                IsSetPN = False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dtResult = Nothing
        End Try
        Return IsSetPN
    End Function

    Public Shared Function CheckIsPartLoss(ByVal strPartID As String, ByRef strLossPartStationName As String) As Boolean
        Dim lsSQL As String = String.Empty
        strLossPartStationName = ""
        lsSQL = " SELECT a.partid,b.Stationname " & _
                " FROM m_RCardD_t a" & _
                " LEFT JOIN m_Rstation_t b  ON a.StationID = b.Stationid" & _
                " LEFT JOIN  m_RCardDPart_t c  ON a.partid = c.PartID AND a.StationID = c.Stationid" & _
                " WHERE CHARINDEX(N'裁线', b.Stationname) >0 and c.PartID is null and isnull(a.Remark,'')  =''" & _
                " AND a.partid ='" & strPartID & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                For Each dr As DataRow In o_dt.Rows
                    strLossPartStationName &= IIf(String.IsNullOrEmpty(strLossPartStationName), "", ",") + dr.Item("Stationname")
                Next
                CheckIsPartLoss = True
            Else
                CheckIsPartLoss = False
            End If
        End Using

    End Function

    Public Shared Function GetAutiStatus(ByVal isQueryOldVersion As Boolean, partID As String) As DataTable
        Dim dt As DataTable
        Dim strSql As String = String.Empty

        Try
            strSql = "SELECT STATUS FROM {0} WHERE PartID='" & partID & "'" &
                     RCardComBusiness.GetFatoryProfitcenter

            If isQueryOldVersion = False Then
                strSql = String.Format(strSql, "m_RCardM_t")
            Else
                strSql = String.Format(strSql, "m_RCardMOldVer_t")
            End If

            dt = DbOperateUtils.GetDataTable(strSql)

        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Shared Function GetRunCardPart(ByVal isQueryOldVersion As Boolean, runCardPartId As String, stationID As String,
                                           Optional ByVal strVersion As String = ""
                                          ) As DataTable
        Dim dt As DataTable
        Dim strSql As String = String.Empty

        Try
            '20151031 Daniel 修改, remove all 20170228
            'strSql = " select  RDP.EWPartNumber PartId ,TypeDest,DESCRIPTION " &
            '      "from {0} RDP RIGHT join m_PartContrast_t  PC " &
            '      "on rdp.EWPartNumber = pc.TAvcPart AND RDP.PartID = PC.PAvcPart AND ISNULL(PC.TYPE,'R') = 'R' " &
            '      " where RDP.PartID='{1}' and RDP.StationID='{2}'   " &
            '         RCardComBusiness.GetFatoryProfitcenter("RDP") &
            '      " UNION " &
            '      " SELECT  RDP.EWPartNumber PartId ,TypeDest,DESCRIPTION " &
            '      " FROM {0} RDP RIGHT join m_PartContrast_t  PC " &
            '      " ON rdp.EWPartNumber = pc.TAvcPart AND PC.TYPE = 'E' " &
            '       " where RDP.PartID='{1}' and RDP.StationID='{2}' and isnull(rdp.EWPNType,'E') = 'E'  " &
            '         RCardComBusiness.GetFatoryProfitcenter("RDP")
            If isQueryOldVersion = True AndAlso strVersion <> "" Then
                strSql = " select  RDP.EWPartNumber PartId ,TypeDest,DESCRIPTION " &
                     "from {0} RDP RIGHT join {3}  PC " &
                     "on rdp.EWPartNumber = pc.TAvcPart AND RDP.PartID = PC.PAvcPart AND ISNULL(PC.TYPE,'R') = 'R' " &
                     " where RDP.PartID='{1}' and RDP.StationID='{2}'  and (PC.Factory='" & VbCommClass.VbCommClass.Factory & "' or PC.Factory='') and RDP.DrawingVer='" & strVersion & "'" &
                        RCardComBusiness.GetFatoryProfitcenter("RDP") &
                     " UNION " &
                     " SELECT  RDP.EWPartNumber PartId ,TypeDest,DESCRIPTION " &
                     " FROM {0} RDP RIGHT join {3}  PC " &
                     " ON rdp.EWPartNumber = pc.TAvcPart AND PC.TYPE = 'E' " &
                      " where RDP.PartID='{1}' and pc.PAvcPart=RDP.PartID and RDP.StationID='{2}' and isnull(rdp.EWPNType,'E') = 'E'  and (PC.Factory='" & VbCommClass.VbCommClass.Factory & "' or PC.Factory='') and RDP.DrawingVer='" & strVersion & "'" &
                        RCardComBusiness.GetFatoryProfitcenter("RDP")
            Else
                strSql = " select  RDP.EWPartNumber PartId ,TypeDest,DESCRIPTION " &
                   "from {0} RDP RIGHT join {3}  PC " &
                   "on rdp.EWPartNumber = pc.TAvcPart AND RDP.PartID = PC.PAvcPart AND ISNULL(PC.TYPE,'R') = 'R' " &
                   " where RDP.PartID='{1}' and RDP.StationID='{2}' " &
                      RCardComBusiness.GetFatoryProfitcenter("RDP") &
                   " UNION " &
                   " SELECT  RDP.EWPartNumber PartId ,TypeDest,DESCRIPTION " &
                   " FROM {0} RDP RIGHT join {3}  PC " &
                   " ON rdp.EWPartNumber = pc.TAvcPart AND PC.TYPE = 'E' " &
                    " where RDP.PartID='{1}' and pc.PAvcPart=RDP.PartID and RDP.StationID='{2}' and isnull(rdp.EWPNType,'E') = 'E'" &
                      RCardComBusiness.GetFatoryProfitcenter("RDP")
            End If

            'If isQueryOldVersion = False Then
            '    strSql = String.Format(strSql, "m_RCardDPart_t", runCardPartId, stationID)
            'Else
            '    strSql = String.Format(strSql, "m_RCardDPartOldVer_t", runCardPartId, stationID)
            'End If

            If isQueryOldVersion = False Then
                strSql = String.Format(strSql, "m_RCardDPart_t", runCardPartId, stationID, "V_m_PartContrast_t")
            Else
                strSql = String.Format(strSql, "m_RCardDPartOldVer_t", runCardPartId, stationID, "m_PartContrastOldVer_t")
            End If

            dt = DbOperateUtils.GetDataTable(strSql)

        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    ''' <summary>
    ''' 标准流程卡单头数据源
    ''' </summary>
    ''' <param name="isQueryOldVersion">是否旧版本</param>
    ''' <param name="sqlWhere">查询条件</param>
    ''' <param name="RCardType">流程卡类型</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRunCardHeader(ByVal isQueryOldVersion As Boolean, sqlWhere As String, RCardType As String) As DataTable
        Dim dt As DataTable
        Dim strSql As String = String.Empty

        Try
            'cq, {0}(nolock) RC,  m_RCardD_t D == > LEFT JOIN 20160406, round((iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1))*StdLabors),1) StdUPH
            'cq 20181227, add AND ISNULL(rc.drawingver,d.DrawingVer) = d.DrawingVer,防止多个版本的时候，显示工时把多个的加总的单个的头部。
            '    strSql =
            '" SELECT  top 100 '2013-10-10 10:10:10:001' ClickTime,RC.PartID ," &
            '"PC.TypeDest," & _
            '" ROUND(SUM(d.WorkingHours),1) as TotalHours,  " & _
            '" PC.DESCRIPTION , " &
            '"RC.DrawingVer ,RC.Shape ," & _
            ' " StdLabors, iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1)) StdUPPH,  " & _
            ' " round((iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1))*StdLabors),1) StdUPH,rc.SeriesID+'('+a.SeriesName+')' as SeriesName,RC.FileNO," & _
            '"IIF(rc.status<>1, isnull(nullif(RC.DrawingFilePath,''), N'双击查看'),DrawingFilePath) DrawingFilePath ," & _
            '"RC.FinishSize, RC.Status, " & _
            '"CASE RC.Status WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END ZStatus, " &
            '"(SELECT USERNAME FROM m_Users_t where USERID =  RC.UserID) UserID,RC.InTime ,ModifyTime ,RC.Remark , 'false' OldVersion ,RC.RCardType " &
            '"FROM {0}(nolock) RC LEFT JOIN {1} D ON  RC.partid = d.PartID  AND ISNULL(rc.drawingver,d.DrawingVer) = d.DrawingVer " &
            '" LEFT JOIN m_PartContrast_t PC ON  RC.PartID=PC.TAvcPart AND PC.TAvcPart = PC.PAvcPart  " &
            '" left join m_Series_t a on a.SeriesID=rc.SeriesID " &
            '" WHERE 1=1  " & sqlWhere &
            'RCardComBusiness.GetFatoryProfitcenter("RC") & _
            '" GROUP BY RC.PartID,RC.DrawingVer ,RC.Shape ,RC.RCardType,RC.FileNO,RC.DrawingFilePath ,RC.FinishSize ,RC.Status," & _
            '       " RC.userid,RC.InTime ,ModifyTime ,RC.Remark,pc.DESCRIPTION,pc.TypeDest,RC.StdLabors,rc.SeriesID+'('+a.SeriesName+')' " & _
            '" ORDER BY isnull(RC.modifyTime,RC.INTIME) DESC "
            If isQueryOldVersion = False Then

                strSql = " SELECT  top 100 '2013-10-10 10:10:10:001' ClickTime,RC.PartID ," &
                    " PC.TypeDest," & _
                    " ROUND(SUM(d.WorkingHours),1) as TotalHours,  " & _
                    " PC.DESCRIPTION , " &
                    " RC.DrawingVer ,RC.Shape ," & _
                " StdLabors, iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1)) StdUPPH,  " & _
            " round((iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1))*StdLabors),1) StdUPH,rc.SeriesID+'('+a.SeriesName+')' as SeriesName,RC.FileNO," & _
     " IIF(rc.status<>1, isnull(nullif(RC.DrawingFilePath,''), N'双击查看'),DrawingFilePath) DrawingFilePath ," & _
    " RC.FinishSize, RC.Status, " & _
   " CASE RC.Status WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END ZStatus, " &
  "(SELECT USERNAME FROM m_Users_t where USERID =  RC.UserID) UserID,RC.InTime ,ModifyTime ,RC.Remark , 'false' OldVersion ,RC.RCardType " &
 " FROM {0}(nolock) RC LEFT JOIN {1} D ON  RC.partid = d.PartID  " &
" LEFT JOIN (select * from v_m_PartContrast_t where TAvcPart = PAvcPart) PC ON  RC.PartID=PC.TAvcPart  " &
" LEFT JOIN m_Series_t a ON a.SeriesID=rc.SeriesID " &
" WHERE 1=1  " & sqlWhere &
RCardComBusiness.GetFatoryProfitcenter("RC") & _
" GROUP BY RC.PartID,RC.DrawingVer ,RC.Shape ,RC.RCardType,RC.FileNO,RC.DrawingFilePath ,RC.FinishSize ,RC.Status," & _
       " RC.userid,RC.InTime ,ModifyTime ,RC.Remark,pc.DESCRIPTION,pc.TypeDest,RC.StdLabors,rc.SeriesID+'('+a.SeriesName+')' " & _
" ORDER BY isnull(RC.modifyTime,RC.INTIME) DESC "


                strSql = String.Format(strSql, "m_RCardM_t", "m_RCardD_t")
            Else

                strSql =
                " SELECT  top 100 '2013-10-10 10:10:10:001' ClickTime,RC.PartID ," &
                "PC.TypeDest," & _
                " ROUND(SUM(d.WorkingHours),1) as TotalHours,  " & _
                " PC.DESCRIPTION , " &
                "RC.DrawingVer ,RC.Shape ," & _
                 " StdLabors, iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1)) StdUPPH,  " & _
                 " round((iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1))*StdLabors),1) StdUPH,rc.SeriesID+'('+a.SeriesName+')' as SeriesName,RC.FileNO," & _
                "IIF(rc.status<>1, isnull(nullif(RC.DrawingFilePath,''), N'双击查看'),DrawingFilePath) DrawingFilePath ," & _
                "RC.FinishSize, RC.Status, " & _
                "CASE RC.Status WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END ZStatus, " &
                "(SELECT USERNAME FROM m_Users_t where USERID =  RC.UserID) UserID,RC.InTime ,ModifyTime ,RC.Remark , 'false' OldVersion ,RC.RCardType " &
                "FROM {0}(nolock) RC LEFT JOIN {1} D ON  RC.partid = d.PartID  AND ISNULL(rc.drawingver,d.DrawingVer) = d.DrawingVer " &
                " LEFT JOIN (select * from v_m_PartContrast_t where TAvcPart = PAvcPart) PC ON  RC.PartID=PC.TAvcPart" &
                " left join m_Series_t a on a.SeriesID=rc.SeriesID " &
                " WHERE 1=1  " & sqlWhere &
                RCardComBusiness.GetFatoryProfitcenter("RC") & _
                " GROUP BY RC.PartID,RC.DrawingVer ,RC.Shape ,RC.RCardType,RC.FileNO,RC.DrawingFilePath ,RC.FinishSize ,RC.Status," & _
                       " RC.userid,RC.InTime ,ModifyTime ,RC.Remark,pc.DESCRIPTION,pc.TypeDest,RC.StdLabors,rc.SeriesID+'('+a.SeriesName+')' " & _
                " ORDER BY isnull(RC.modifyTime,RC.INTIME) DESC "


                strSql = String.Format(strSql, "m_RCardMOldVer_t", "m_RCardDOldVer_t")
            End If
            dt = DbOperateUtils.GetDataTable(strSql)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RunCardBusiness", "GetRunCardHeader", "RCard")
            Throw ex
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' 导出单头数据源
    ''' add by 马跃平 2018-07-09
    ''' </summary>
    ''' <param name="isQueryOldVersion"></param>
    ''' <param name="sqlWhere"></param>
    ''' <param name="RCardType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRunCardHeaderExport(ByVal isQueryOldVersion As Boolean, sqlWhere As String, RCardType As String) As DataTable
        Dim dt As DataTable
        Dim strSql As String = String.Empty

        Try
            'cq, {0}(nolock) RC,  m_RCardD_t D == > LEFT JOIN 20160406, round((iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1))*StdLabors),1) StdUPH
            strSql =
        " SELECT   '2013-10-10 10:10:10:001' ClickTime,RC.PartID ," &
        "PC.TypeDest," & _
        " ROUND(SUM(d.WorkingHours),1) as TotalHours,  " & _
        " PC.DESCRIPTION , " &
        "RC.DrawingVer ,RC.Shape ," & _
         " StdLabors, iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1)) StdUPPH,  " & _
         " round((iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1))*StdLabors),1) StdUPH,rc.SeriesID+'('+a.SeriesName+')' as SeriesName,RC.FileNO," & _
        "IIF(rc.status<>1, isnull(nullif(RC.DrawingFilePath,''), N'双击查看'),DrawingFilePath) DrawingFilePath ," & _
        "RC.FinishSize, RC.Status, " & _
        "CASE RC.Status WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END ZStatus, " &
        "(SELECT USERNAME FROM m_Users_t where USERID =  RC.UserID) UserID,RC.InTime ,ModifyTime ,RC.Remark , 'false' OldVersion ,RC.RCardType " &
        "FROM {0}(nolock) RC LEFT JOIN {1} D ON  RC.partid = d.PartID AND ISNULL(d.DrawingVer,rc.drawingver) = rc.DrawingVer " &
        " LEFT JOIN V_m_PartContrast_t PC ON  RC.PartID=PC.TAvcPart AND PC.TAvcPart = PC.PAvcPart  " &
        " left join m_Series_t a on a.SeriesID=rc.SeriesID " &
        " WHERE 1=1  " & sqlWhere &
        RCardComBusiness.GetFatoryProfitcenter("RC") & _
        " GROUP BY RC.PartID,RC.DrawingVer ,RC.Shape ,RC.RCardType,RC.FileNO,RC.DrawingFilePath ,RC.FinishSize ,RC.Status," & _
               " RC.userid,RC.InTime ,ModifyTime ,RC.Remark,pc.DESCRIPTION,pc.TypeDest,RC.StdLabors,rc.SeriesID+'('+a.SeriesName+')' " & _
        " ORDER BY isnull(RC.modifyTime,RC.INTIME) DESC "
            If isQueryOldVersion = False Then
                strSql = String.Format(strSql, "m_RCardM_t", "m_RCardD_t")
            Else
                strSql = String.Format(strSql, "m_RCardMOldVer_t", "m_RCardDOldVer_t")
            End If
            dt = DbOperateUtils.GetDataTable(strSql)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RunCardBusiness", "GetRunCardHeader", "RCard")
            Throw ex
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' 计算总数
    ''' add by 马跃平 2018-07-09
    ''' </summary>
    ''' <param name="isQueryOldVersion"></param>
    ''' <param name="sqlWhere"></param>
    ''' <param name="RCardType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRunCardHeaderTotal(ByVal isQueryOldVersion As Boolean, sqlWhere As String, RCardType As String) As Integer
        Dim Total As Integer = 0
        Dim dt As DataTable
        Dim strSql As String = String.Empty

        Try
            'cq, {0}(nolock) RC,  m_RCardD_t D == > LEFT JOIN 20160406, round((iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1))*StdLabors),1) StdUPH
            strSql =
        " SELECT   count(1) " &
        "FROM {0}(nolock) RC  " &
        " LEFT JOIN V_m_PartContrast_t PC ON  RC.PartID=PC.TAvcPart AND PC.TAvcPart = PC.PAvcPart  " &
        " WHERE 1=1  " & sqlWhere &
        RCardComBusiness.GetFatoryProfitcenter("RC")
            If isQueryOldVersion = False Then
                strSql = String.Format(strSql, "m_RCardM_t")
            Else
                strSql = String.Format(strSql, "m_RCardMOldVer_t")
            End If
            dt = DbOperateUtils.GetDataTable(strSql)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RunCardBusiness", "GetRunCardHeader", "RCard")
            Throw ex
        End Try
        Total = Convert.ToInt32(dt.Rows(0)(0))
        Return Total
    End Function

    ''' <summary>
    ''' 分类汇总,已完成,待审核,制作中的总数
    ''' add by 马跃平 2018-07-09
    ''' </summary>
    ''' <param name="Factoryid">工厂编号</param>
    ''' <param name="Profitcenter">利润中心</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTypeToal(ByVal Factoryid As String, ByVal Profitcenter As String) As DataTable
        Dim sql = "select sum(case when status=1 then 1 end) Finish," & vbCrLf &
        " isnull(sum(case when status=2 then 1 end),0) Audit," & vbCrLf &
        "sum(case when status=0 then 1 end) Unfinish from m_RCardM_t " & vbCrLf &
        " where Factoryid='" & Factoryid & "' and Profitcenter='" & Profitcenter & "'"
        Return DbOperateUtils.GetDataTable(sql)
    End Function

    ''' <summary>
    ''' 点击SideBarItem更新流程卡单头数据源
    ''' </summary>
    ''' <param name="partID">料号</param>
    ''' <param name="dt">旧数据源</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getNewRunCardData(ByVal partID As String, ByVal dt As DataTable) As DataTable
        Dim sql = "SELECT  '2013-10-10 10:10:10:001' ClickTime,RC.PartID ,PC.TypeDest," & vbCrLf &
        "ROUND(SUM(d.WorkingHours),1) AS TotalHours,PC.DESCRIPTION ,RC.DrawingVer ,RC.Shape ," & vbCrLf &
        "StdLabors,iif(SUM(d.WorkingHours)       =0,0,ROUND((3600/SUM(d.WorkingHours)),1)) StdUPPH," & vbCrLf &
        "ROUND((iif(SUM(d.WorkingHours)=0,0,ROUND((3600/SUM(d.WorkingHours)),1))*StdLabors),1) StdUPH," & vbCrLf &
        "rc.SeriesID+'('+a.SeriesName+')' AS SeriesName,RC.FileNO," & vbCrLf &
        "IIF(rc.status<>1, isnull(NULLIF(RC.DrawingFilePath,''), N'双击查看'),DrawingFilePath) DrawingFilePath ," & vbCrLf &
        "RC.FinishSize,RC.Status,CASE RC.Status WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END ZStatus," & vbCrLf &
        "(SELECT USERNAME FROM m_Users_t WHERE USERID = RC.UserID) UserID,RC.InTime ,ModifyTime ,RC.Remark , 'false' OldVersion ," & vbCrLf &
        "RC.RCardType FROM m_RCardM_t(nolock) RC LEFT JOIN m_RCardD_t D ON RC.partid = d.PartID LEFT JOIN m_PartContrast_t PC" & vbCrLf &
         "ON RC.PartID    =PC.TAvcPart AND PC.TAvcPart = PC.PAvcPart LEFT JOIN m_Series_t a ON a.SeriesID      =rc.SeriesID WHERE 1 = 1" & vbCrLf &
        "AND RC.Factoryid   ='{0}' AND RC.Profitcenter= '{1}' and RC.PartID='" & partID & "' GROUP BY RC.PartID,RC.DrawingVer ," & vbCrLf &
        "RC.Shape ,RC.RCardType,RC.FileNO,RC.DrawingFilePath ,RC.FinishSize ,RC.Status,RC.userid,RC.InTime ,ModifyTime ,RC.Remark," & vbCrLf &
        "pc.DESCRIPTION,pc.TypeDest,RC.StdLabors,rc.SeriesID+'('+a.SeriesName+')' ORDER BY isnull(RC.modifyTime,RC.INTIME) DESC "


        sql = String.Format(sql, factoryID, profitCenter)

        Dim tt = DbOperateUtils.GetDataTable(sql)
        Dim dr = dt.NewRow()
        dr("ClickTime") = tt.Rows(0)("ClickTime")
        dr("PartID") = tt.Rows(0)("PartID")
        dr("TypeDest") = tt.Rows(0)("TypeDest")
        dr("TotalHours") = tt.Rows(0)("TotalHours")
        dr("DESCRIPTION") = tt.Rows(0)("DESCRIPTION")
        dr("DrawingVer") = tt.Rows(0)("DrawingVer")
        dr("Shape") = tt.Rows(0)("Shape")
        dr("StdLabors") = tt.Rows(0)("StdLabors")
        dr("StdUPPH") = tt.Rows(0)("StdUPPH")
        dr("StdUPH") = tt.Rows(0)("StdUPH")
        dr("SeriesName") = tt.Rows(0)("SeriesName")
        dr("FileNO") = tt.Rows(0)("FileNO")
        dr("DrawingFilePath") = tt.Rows(0)("DrawingFilePath")
        dr("FinishSize") = tt.Rows(0)("FinishSize")
        dr("Status") = tt.Rows(0)("Status")
        dr("ZStatus") = tt.Rows(0)("ZStatus")
        dr("UserID") = tt.Rows(0)("UserID")
        dr("InTime") = tt.Rows(0)("InTime")
        dr("ModifyTime") = tt.Rows(0)("ModifyTime")
        dr("Remark") = tt.Rows(0)("Remark")
        dr("OldVersion") = tt.Rows(0)("OldVersion")
        dr("RCardType") = tt.Rows(0)("RCardType")
        If dt.Select("PartID='" & partID & "'").Length = 0 Then
            dt.Rows.Add(dr)
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 获取状态中的数据详细资料
    ''' add by 马跃平 2018-07-09
    ''' </summary>
    ''' <param name="status">流程卡状态</param>
    ''' <param name="Factoryid">工厂编号</param>
    ''' <param name="Profitcenter">利润中心</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetStatusTotal(ByVal status As String, ByVal Factoryid As String, ByVal Profitcenter As String) As DataTable
        Dim sql = "SELECT  '2013-10-10 10:10:10:001' ClickTime," & vbCrLf &
        "RC.PartID, PC.TypeDest, PC.DESCRIPTION, RC.Status,RC.InTime " & vbCrLf &
        "FROM m_RCardM_t(nolock) RC" & vbCrLf &
        "LEFT JOIN V_m_PartContrast_t PC" & vbCrLf &
        "ON RC.PartID    =PC.TAvcPart" & vbCrLf &
        "AND PC.TAvcPart = PC.PAvcPart" & vbCrLf &
        "WHERE 1=1 AND RC.Factoryid   ='" & Factoryid & "'" & vbCrLf &
        "AND RC.Profitcenter= '" & Profitcenter & "' and rc.[Status]=" & status
        Return DbOperateUtils.GetDataTable(sql)
    End Function

    Public Shared Function GetRunCardSide(ByVal isQueryOldVersion As Boolean, sqlWhere As String) As DataTable
        Dim dt As DataTable
        Dim strSql As String = String.Empty
        Try
            strSql =
        " SELECT  RC.PartID ," &
        " RC.Status, " & _
        "CASE RC.Status WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END ZStatus, " &
        "RC.InTime ,ModifyTime , 'false' OldVersion " &
        "FROM {0}(nolock) RC LEFT JOIN m_RCardD_t D ON  rc.partid = d.PartID  " &
        " LEFT JOIN m_PartContrast_t PC ON  RC.PartID=PC.TAvcPart AND PC.TAvcPart = PC.PAvcPart  " &
        " WHERE 1=1  " & sqlWhere &
        RCardComBusiness.GetFatoryProfitcenter("RC") & _
        " GROUP BY rc.PartID,RC.DrawingVer ,RC.Shape ,RC.DrawingFilePath ,RC.FinishSize ,RC.Status,rc.userid,RC.InTime ,ModifyTime ,rc.Remark,pc.DESCRIPTION,pc.TypeDest" & _
        " ORDER BY RC.MODIFYTIME DESC,RC.INTIME DESC "
            If isQueryOldVersion = False Then
                strSql = String.Format(strSql, "m_RCardM_t")
            Else
                strSql = String.Format(strSql, "m_RCardMOldVer_t")
            End If

            dt = DbOperateUtils.GetDataTable(strSql)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RunCardBusiness", "GetRunCardSide", "RCard")
            ' Throw ex
        End Try

        Return dt
    End Function

    Public Shared Function GetRunCardBody(ByVal isQueryOldVersion As Boolean, runCardPartId As String, Optional ByVal strRCardVersion As String = "") As DataSet
        Dim ds As DataSet
        Dim strSql As String = String.Empty
        Dim sqlTail As String = String.Empty

        Try
            If isQueryOldVersion = True Then
                'cq 20161018, Is really query Old version? 
                isQueryOldVersion = RCardComBusiness.IsQueryOldRCardVersion(runCardPartId, strRCardVersion)
            End If

            'A.ProcessStandardPrint is null,A.ProcessStandard  ,A.ProcessStandardPrint, modify by cq20170726
            If strRCardVersion = "" Or (isQueryOldVersion = False) Then
                ' strSql = "SELECT A.PartID ,A.StationID,A.StationSQ ,B.StationName ," &
                '"CAST(B.SectionID AS VARCHAR) SectionID,cast(A.WorkingHours as varchar) WorkingHours, " &
                '"A.Equipment ,IIF(isnull(A.ProcessStandardPrint,'')='',A.ProcessStandard  ,A.ProcessStandardPrint) ProcessStandard ,A.NewProcessStandard ," &
                '"A.Remark ,B.SopFilePath SOP,A.Status ,(SELECT USERNAME FROM m_Users_t where USERID =  A.UserID) UserId ,A.InTime  " &
                '"from {0}(nolock) A left join m_Rstation_t(nolock) B on A.StationID=B.Stationid " &
                '"where A.PartID='{1}' " &
                'RCardComBusiness.GetFatoryProfitcenter("A") &
                '"ORDER BY A.StationSQ  "
                'update by 马跃平 2018-03-30
                strSql = "SELECT A.PartID ,A.StationID,cast(A.StationSQ as varchar) StationSQ,B.StationName ," &
               "CAST(B.SectionID AS VARCHAR) SectionID,cast(A.WorkingHours as varchar) WorkingHours, " &
               "A.Equipment ,IIF(isnull(A.ProcessStandard,'')='',A.ProcessStandardPrint,A.ProcessStandard) ProcessStandard ,A.NewProcessStandard ," &
               "A.Remark ,B.SopFilePath SOP, A.Status ,(SELECT USERNAME FROM m_Users_t where USERID =  A.UserID) UserId ,(convert(varchar(10),A.InTime,111)+' '+convert(varchar(5),A.InTime,8)) InTime,A.UserID as UId  " &
               "from {0}(nolock) A left join m_Rstation_t(nolock) B on A.StationID=B.Stationid " &
               "where A.PartID='{1}' " &
               RCardComBusiness.GetFatoryProfitcenter("A") &
               "ORDER BY A.StationSQ  "
            Else
                'ProcessStandard ==> IIF(isnull(A.ProcessStandardPrint,'')='',A.ProcessStandard  ,A.ProcessStandardPrint,modify by cq20170726
                strSql = "SELECT A.PartID ,A.StationID,cast(A.StationSQ as varchar) StationSQ ,B.StationName ," &
                      "CAST(B.SectionID AS VARCHAR) SectionID,cast(A.WorkingHours as varchar) WorkingHours, " &
                      "A.Equipment   , IIF(isnull(A.ProcessStandardPrint,'')='',A.ProcessStandard  ,A.ProcessStandardPrint) ProcessStandard ,A.NewProcessStandard ," &
                      "A.Remark ,B.SopFilePath SOP,A.Status ,(select USERNAME from m_Users_t where USERID =  A.UserID) UserId ,(convert(varchar(10),A.InTime,111)+' '+convert(varchar(5),A.InTime,8)) InTime  " &
                      "FROM {0}(nolock) A left join m_Rstation_t(nolock) B on A.StationID=B.Stationid " &
                      "where A.PartID='{1}'  AND  A.DrawingVer ='" & strRCardVersion & "'  " &
                      RCardComBusiness.GetFatoryProfitcenter("A") &
                      "order by A.StationSQ  "
            End If

            If strRCardVersion = "" Or (isQueryOldVersion = False) Then
                sqlTail = "SELECT SUM(ISNULL(RCD.WorkingHours,0)) WorkingHours,st.SectionID " &
                        "FROM {0}(nolock) RCD inner join m_Rstation_t(nolock) ST on RCD.StationID=ST.Stationid " &
                        "WHERE RCD.PartID='{1}' " &
                        RCardComBusiness.GetFatoryProfitcenter("RCD") & "GROUP BY ST.SectionID ; "
            Else
                sqlTail = "SELECT SUM(ISNULL(RCD.WorkingHours,0)) WorkingHours,st.SectionID " &
                     "FROM {0}(nolock) RCD inner join m_Rstation_t(nolock) ST on RCD.StationID=ST.Stationid " &
                     "WHERE RCD.PartID='{1}' AND  RCD.DrawingVer ='" & strRCardVersion & "' " &
                     RCardComBusiness.GetFatoryProfitcenter("RCD") & "GROUP BY ST.SectionID ; "
            End If

            If isQueryOldVersion = False Then
                strSql = String.Format(strSql, "m_RCardD_t", runCardPartId)
                sqlTail = String.Format(sqlTail, "m_RCardD_t", runCardPartId)
            Else
                strSql = String.Format(strSql, "m_RCardDOldVer_t", runCardPartId)
                sqlTail = String.Format(sqlTail, "m_RCardDOldVer_t", runCardPartId)
            End If

            ds = DbOperateUtils.GetDataSet(strSql & vbNewLine & sqlTail)

        Catch ex As Exception
            Throw
        End Try

        Return ds
    End Function

    Public Shared Function CheckStationMaintainCheckItem(stationID As String) As Boolean
        Dim strSQL As String = "SELECT CheckItemID FROM m_RstationCheckItem_t WHERE STATIONID='" & stationID & "' AND UseY=1"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Shared Sub DeleteBody(isQueryOldVersion As Boolean, partID As String, sationID As String, ByVal StationSQ As String)
        Try
            Dim strSQL As String = String.Empty

            If isQueryOldVersion = False Then
                strSQL = "DELETE m_RCardD_t where PartID='" & partID & "' AND StationID = '" & sationID & "' and StationSQ ='" & StationSQ & "'" &
                         RCardComBusiness.GetFatoryProfitcenter()
                strSQL += " UPDATE  m_RCardD_t  SET STATIONSQ=B.ID FROM m_RCardD_t A," &
                                    "(SELECT ROW_NUMBER() OVER(ORDER BY STATIONSQ) ID,STATIONSQ FROM m_RCardD_t WHERE PartID='" & partID & "') B" &
                                    " WHERE A.PartID= '" & partID & "'  AND A.STATIONSQ=B.STATIONSQ AND B.ID<>B.STATIONSQ" &
                                    RCardComBusiness.GetFatoryProfitcenter("A")
                strSQL += " DELETE FROM m_RCardDPart_t WHERE    PartID='" & partID & "' AND Stationid = '" & sationID & "' " &
                            RCardComBusiness.GetFatoryProfitcenter()

                'Modify by cq20170823,Stationid='' ==> 
                strSQL += " DELETE FROM m_RCardDCheckItem_t WHERE  PartID='" & partID & "' AND Stationid='" & sationID & "'" &
                            RCardComBusiness.GetFatoryProfitcenter()

                strSQL += " UPDATE m_RCardM_t set Status=0 where PartID= '" & partID & "'" &
                            RCardComBusiness.GetFatoryProfitcenter
            Else
                strSQL = "DELETE m_RCardDOldVer_t WHERE PartID='" & partID & "' AND StationID = '" & sationID & "'" &
                         RCardComBusiness.GetFatoryProfitcenter
                strSQL += " UPDATE  m_RCardDOldVer_t  SET STATIONSQ=B.ID FROM m_RCardD_t A," &
                                    "(SELECT ROW_NUMBER() OVER(ORDER BY STATIONSQ) ID,STATIONSQ FROM m_RCardD_t WHERE PartID='" & partID & "') B" &
                                    " WHERE A.PartID= '" & partID & "'  AND A.STATIONSQ=B.STATIONSQ AND B.ID<>B.STATIONSQ" &
                                    RCardComBusiness.GetFatoryProfitcenter("A")
                strSQL += " DELETE FROM m_RCardDPartOldVer_t WHERE PartID='" & partID & "' AND Stationid = '" & sationID & "'" &
                            RCardComBusiness.GetFatoryProfitcenter()
                strSQL += " UPDATE m_RCardMOldVer_t set Status=0 where PartID= '" & partID & "'" &
                            RCardComBusiness.GetFatoryProfitcenter()
            End If

            DbOperateUtils.ExecSQL(strSQL)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared Function DeleteDPartID(isOldVersion As Boolean, RCardPartID As String, ByVal PartID As String, ByVal partStationID As String) As String
        Dim strSQL As String = String.Empty
        If isOldVersion = False Then
            strSQL = "  DELETE FROM m_RCardDPart_t  "
            strSQL += " WHERE PartID='" & RCardPartID & "' "
            strSQL += " And EWPartNumber='" & PartID & "' AND Stationid='" & partStationID & "' " &
                        RCardComBusiness.GetFatoryProfitcenter()
        Else
            strSQL = "  DELETE FROM m_RCardDPartOldVer_t  "
            strSQL += " WHERE PartID = '" & PartID & "'"
            strSQL += " And EWPartNumber='" & PartID & "' AND  Stationid='" & partStationID & "'" &
                        RCardComBusiness.GetFatoryProfitcenter()
        End If
        DeleteDPartID = strSQL
    End Function

    Public Shared Function DeleteHeader(isOldVersion As Boolean, partID As String) As String
        Dim sb As New StringBuilder
        If isOldVersion = False Then

            sb.Append(" Insert into m_RCardDPartBak_t([PartID],[Stationid],[EWPartNumber]")
            sb.Append(",[DrawingVer],[UserID],[InTime],[Factoryid],[Profitcenter]")
            sb.Append(" ,[EWPNType],[EWPNLRDirection],CardType)")
            sb.Append(" SELECT [PartID],[Stationid],[EWPartNumber]")
            sb.Append(" ,[DrawingVer],[UserID],[InTime]")
            sb.Append(",[Factoryid],[Profitcenter],[EWPNType]")
            sb.Append(",[EWPNLRDirection],[CardType] from m_RCardDPart_t a where PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter("A"))

            sb.Append(" Insert into m_RCardDCheckItemBak_t([PartID],[Stationid]")
            sb.Append(",[CheckItemID],[Description]")
            sb.Append(" ,[ResultValue],[Status],[CheckGroup],[UserID],[InTime]")
            sb.Append(",[LeftTVPN],[LeftWirePN1],[LeftWirePN2],[LeftWirePN3],[LeftWirePN4]")
            sb.Append(",[RightTVPN],[RightWirePN1],[RightWirePN2],[RightWirePN3],[RightWirePN4]")
            sb.Append(",[FinishSize],[LeftCutSize]")
            sb.Append(" ,[RightCutSize],[Tolerance]")
            sb.Append(" ,[ToleranceRange],[Factoryid],[Profitcenter]")
            sb.Append(",[LeftTVPNShow],[RightTVPNShow],[CardType])")
            sb.Append(" select [PartID],[Stationid]")
            sb.Append(",[CheckItemID],[Description]")
            sb.Append(" ,[ResultValue],[Status],[CheckGroup],[UserID],[InTime]")
            sb.Append(",[LeftTVPN],[LeftWirePN1],[LeftWirePN2],[LeftWirePN3],[LeftWirePN4]")
            sb.Append(" ,[RightTVPN],[RightWirePN1],[RightWirePN2],[RightWirePN3],[RightWirePN4]")
            sb.Append(",[FinishSize],[LeftCutSize]")
            sb.Append(" ,[RightCutSize],[Tolerance]")
            sb.Append(" ,[ToleranceRange],[Factoryid],[Profitcenter]")
            sb.Append(" ,[LeftTVPNShow],[RightTVPNShow],[CardType]")
            sb.Append(" FROM m_RCardDCheckItem_t a  WHERE  PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter("A"))

            sb.Append("  DELETE A FROM m_RCardDCheckItem_t A,m_RCardD_t B ")
            sb.Append(" WHERE B.PartID='" & partID & "' ")
            sb.Append(" AND B.PartID=A.PartID AND B.Stationid=B.Stationid " & RCardComBusiness.GetFatoryProfitcenter("B"))

            sb.Append(" DELETE A FROM m_RCardDPart_t A,m_RCardD_t B ")
            sb.Append(" WHERE B.PartID='" & partID & "'  AND B.PartID=A.PartID " & RCardComBusiness.GetFatoryProfitcenter("B"))

            'Add by cq20161230
            sb.Append("INSERT into m_RCardDBak_t( [PartID] ,[StationID] ,[DrawingVer]  ,[StationSQ],[WorkingHours] ,[Equipment] ,[ProcessStandard] ,[Remark]")
            sb.Append(",[Status] ,[Shape],[NewProcessStandard],[VariableName1],[VariableValue1] ,[VariableName2]")
            sb.Append(",[VariableValue2],[Factoryid] ,[Profitcenter]")
            sb.Append(",[UserID] ,[InTime]  ,[FinishSize]) ")
            sb.Append(" SELECT  PartID ,StationID ,DrawingVer  ,StationSQ,[WorkingHours] ,[Equipment] ,[ProcessStandard] ,[Remark],[Status]")
            sb.Append(",[Shape],[NewProcessStandard],[VariableName1],[VariableValue1],[VariableName2] ,[VariableValue2],[Factoryid]")
            sb.Append(",[Profitcenter],[UserID],[InTime]  ,[FinishSize]")
            sb.Append(" FROM m_RCardD_t WHERE  PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter())

            sb.Append(" INSERT  INTO m_RCardMBak_t([PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]")
            sb.Append(",[Profitcenter],[UserID],[InTime],ModifyTime,bakTime) ")
            sb.Append(" SELECT [PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]")
            sb.Append(",[Profitcenter],[UserID],[InTime],[ModifyTime],getdate() FROM m_RCardM_t WHERE  PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter())


            sb.Append(" DELETE FROM m_RCardD_t WHERE  PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter())
            sb.Append(" DELETE FROM m_RCardM_t WHERE  PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter())
        Else
            sb.Append("  DELETE A FROM m_RCardDPartOldVer_t A,m_RCardDOldVer_t B ")
            sb.Append(" WHERE B.PartID = '" & partID & "'")
            sb.Append(" AND B.PartID=A.PartID AND B.Stationid=A.Stationid" & RCardComBusiness.GetFatoryProfitcenter())

            sb.Append(" INSERT  INTO m_RCardDOldVerBak_t( [partID] ,[StationID]")
            sb.Append(",[DrawingVer],[StationSQ],[WorkingHours],[Equipment]")
            sb.Append(",[ProcessStandard],[Remark],[Status]")
            sb.Append(" ,[Shape],[NewProcessStandard]")
            sb.Append(" ,[VariableName1],[VariableValue1],[VariableName2]")
            sb.Append(",[VariableValue2],[Factoryid],[Profitcenter],[UserID],[InTime] ,FinishSize)")
            sb.Append(" SELECT [partID] ,[StationID] ")
            sb.Append(",[DrawingVer],[StationSQ],[WorkingHours],[Equipment]")
            sb.Append(",[ProcessStandard],[Remark],[Status]")
            sb.Append(" ,[Shape],[NewProcessStandard]")
            sb.Append(" ,[VariableName1],[VariableValue1],[VariableName2]")
            sb.Append(",[VariableValue2],[Factoryid],[Profitcenter],[UserID],[InTime] ,[FinishSize]")
            sb.Append(" FROM m_RCardDOldVer_t WHERE  PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter())

            sb.Append(" INSERT  INTO m_RCardMOldVerBak_t([PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]")
            sb.Append(",[Profitcenter],[UserID],[InTime],ModifyTime) ")
            sb.Append("SELECT [PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]")
            sb.Append(",[Profitcenter],[UserID],[InTime],[ModifyTime] ")
            sb.Append(" FROM m_RCardMOldVer_t WHERE  PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter())

            sb.Append(" DELETE FROM m_RCardDOldVer_t WHERE PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter())
            sb.Append(" DELETE FROM m_RCardMOldVer_t WHERE PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter())
        End If
        DeleteHeader = sb.ToString
    End Function

    Public Shared Function HideHeader(isOldVersion As Boolean, partID As String, version As String) As String
        Dim strSQL As String = String.Empty
        If isOldVersion = False Then

            strSQL = "  DELETE A FROM m_RCardDCheckItem_t A,m_RCardD_t B "
            strSQL += " WHERE B.PartID='" & partID & "' "
            strSQL += " AND B.PartID=A.PartID AND B.Stationid=B.Stationid " &
                        RCardComBusiness.GetFatoryProfitcenter("B")

            strSQL += " DELETE A FROM m_RCardDPart_t A,m_RCardD_t B "
            strSQL += " WHERE B.PartID='" & partID & "' "
            strSQL += " AND B.PartID=A.PartID " &
                        RCardComBusiness.GetFatoryProfitcenter("B")

            'Add by cq20161230,insert into select from
            strSQL += "INSERT into m_RCardDBak_t( [PartID] ,[StationID] ,[DrawingVer]  ,[StationSQ],[WorkingHours] ,[Equipment] ,[ProcessStandard] ,[Remark]"
            strSQL += ",[Status] ,[Shape],[NewProcessStandard],[VariableName1],[VariableValue1] ,[VariableName2]"
            strSQL += ",[VariableValue2],[Factoryid] ,[Profitcenter]"
            strSQL += ",[UserID] ,[InTime]  ,[FinishSize]) "
            strSQL += " SELECT  PartID ,StationID ,DrawingVer  ,StationSQ,[WorkingHours] ,[Equipment] ,[ProcessStandard] ,[Remark],[Status]"
            strSQL += ",[Shape],[NewProcessStandard],[VariableName1],[VariableValue1],[VariableName2] ,[VariableValue2],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime]  ,[FinishSize]"
            strSQL += " FROM m_RCardD_t WHERE  PartID='" & partID & "' " &
            RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " INSERT  INTO m_RCardMBak_t([PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime],[ModifyTime]) "
            strSQL += "SELECT [PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime],[ModifyTime] FROM m_RCardM_t WHERE  PartID='" & partID & "' " &
            RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " DELETE FROM m_RCardD_t WHERE  PartID='" & partID & "' " &
                        RCardComBusiness.GetFatoryProfitcenter()
            strSQL += " DELETE FROM m_RCardM_t WHERE  PartID='" & partID & "' " &
                        RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " Insert into m_RCardLog_t(PartID, DrawingVer, intime, userid, action ) " & _
                      " values( '" & partID & "', '" & version & "', getdate(), '" & userID & "', 'HideHeader')"
        Else
            strSQL = "  DELETE A FROM m_RCardDPartOldVer_t A,m_RCardDOldVer_t B "
            strSQL += " WHERE B.PartID = '" & partID & "'"
            strSQL += " AND B.PartID=A.PartID AND B.Stationid=A.Stationid" &
                        RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " INSERT  INTO m_RCardDOldVerBak_t( [partID] ,[StationID]"
            strSQL += ",[DrawingVer],[StationSQ],[WorkingHours],[Equipment]"
            strSQL += ",[ProcessStandard],[Remark],[Status]"
            strSQL += " ,[Shape],[NewProcessStandard]"
            strSQL += " ,[VariableName1],[VariableValue1],[VariableName2]"
            strSQL += ",[VariableValue2],[Factoryid],[Profitcenter],[UserID],[InTime] ,[FinishSize]) "
            strSQL += " SELECT [partID] ,[StationID] "
            strSQL += ",[DrawingVer],[StationSQ],[WorkingHours],[Equipment]"
            strSQL += ",[ProcessStandard],[Remark],[Status]"
            strSQL += " ,[Shape],[NewProcessStandard]"
            strSQL += " ,[VariableName1],[VariableValue1],[VariableName2]"
            strSQL += ",[VariableValue2],[Factoryid],[Profitcenter],[UserID],[InTime] ,[FinishSize]"
            strSQL += " FROM m_RCardDOldVer_t WHERE  PartID='" & partID & "' " &
            RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " INSERT  INTO m_RCarDMOldVerBak_t([PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime],[ModifyTime]) "
            strSQL += "SELECT [PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime],[ModifyTime] "
            strSQL += "FROM m_RCardMOldVer_t WHERE  PartID='" & partID & "' " &
            RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " DELETE FROM m_RCardDOldVer_t WHERE PartID='" & partID & "'" &
                        RCardComBusiness.GetFatoryProfitcenter()
            strSQL += " DELETE FROM m_RCardMOldVer_t WHERE PartID='" & partID & "' " &
                        RCardComBusiness.GetFatoryProfitcenter()
            strSQL += " INSERT into m_RCardLog_t(PartID, DrawingVer, intime, userid, action ) " & _
                   " values( '" & partID & "', '" & version & "', getdate(), '" & userID & "', 'HideHeader')"
        End If
        HideHeader = strSQL
    End Function

    Public Shared Function DeleteOldRCard(ByVal partID As String, ByVal strVersion As String) As String
        Dim strSQL As String = String.Empty

        strSQL = "  DELETE A FROM m_RCardDPartOldVer_t A,m_RCardDOldVer_t B "
        strSQL += " WHERE B.PartID = '" & partID & "'"
        strSQL += " AND B.PartID=A.PartID AND B.Stationid=A.Stationid and a.DrawingVer = b.DrawingVer " &
                    RCardComBusiness.GetFatoryProfitcenter("A")

        strSQL += " DELETE FROM m_RCardDOldVer_t WHERE  PartID='" & partID & "' AND DrawingVer='" & strVersion & "' " &
                RCardComBusiness.GetFatoryProfitcenter()

        strSQL += " DELETE FROM m_RCardMOldVer_t WHERE  PartID='" & partID & "' AND DrawingVer='" & strVersion & "' " &
                    RCardComBusiness.GetFatoryProfitcenter()


        DeleteOldRCard = strSQL
    End Function

    Public Shared Function GetUserID(ByVal userName As String) As String
        Dim strSQL As String = String.Empty, UserID = ""
        strSQL = " SELECT TOP 1 USERID FROM m_Users_t  where username=N'" & userName & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                UserID = o_dt.Rows(0).Item(0)
            End If
        End Using
        GetUserID = UserID
        Return GetUserID
    End Function

    Public Shared Function GetModifyUserID(ByVal PartID As String, ByRef ModifyTime As Date) As String
        Dim strSQL As String = String.Empty, ModifyUserID = ""
        strSQL = " SELECT TOP 1 USERID, InTime FROM m_RCardD_t  WHERE partid=N'" & PartID & "' " & RCardComBusiness.GetFatoryProfitcenter() & " ORDER BY intime DESC"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                ModifyUserID = o_dt.Rows(0).Item(0)
                ModifyTime = o_dt.Rows(0).Item(1)
            End If
        End Using
        GetModifyUserID = ModifyUserID
        Return GetModifyUserID
    End Function

    Public Shared Function GetdtSectionHours(ByVal PartID As String) As DataTable
        Dim strSQL As String = String.Empty, ModifyUserID = ""
        strSQL = " SELECT b.sectionid,isnull(sum(a.WorkingHours),0) sectionHours  FROM m_RcardD_t a, m_Rstation_t b  " & _
                 " WHERE a.partid ='" & PartID & "' " & _
                 " AND a.stationid = b.Stationid" & _
                 RCardComBusiness.GetFatoryProfitcenter("A") &
                 " GROUP BY sectionid"
        Dim o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Return o_dt
    End Function

    Public Shared Function GetUpateRCardMasterSQL(isOldVer As Boolean, partID As String) As String
        Dim strSQL As String = String.Empty
        If isOldVer = False Then
            'add clear remark by cq 20161119,ModifyTime=getdate()
            strSQL = " UPDATE m_RCardM_t SET Status=1,remark='' WHERE PartID='" & partID & "' " &
                        RCardComBusiness.GetFatoryProfitcenter &
                     " INSERT INTO m_RCardMAuditLog_t select '" & partID & "','" & userID & "',getdate()  " & ",'" & factoryID & "','" & profitCenter & "'"
        Else
            strSQL = " UPDATE m_RCardMOldVer_t set Status=1 WHERE partID='" & partID & "'" &
                        RCardComBusiness.GetFatoryProfitcenter
        End If

        GetUpateRCardMasterSQL = strSQL
    End Function

    Public Shared Function GetUpateRCardMAndSaveBOMSQL(isOldVer As Boolean, partID As String, Version As String) As String
        Dim strSQL As New StringBuilder
        If isOldVer = False Then
            'add clear remark by cq 20161119,ModifyTime=getdate()
            strSQL.Append(" UPDATE m_RCardM_t SET Status=1,remark='' WHERE PartID='" & partID & "' " & RCardComBusiness.GetFatoryProfitcenter)
            strSQL.Append("  INSERT INTO m_RCardMAuditLog_t select '" & partID & "','" & userID & "',getdate()  " & ",'" & factoryID & "','" & profitCenter & "'")

            strSQL.Append("  IF NOT EXISTS(SELECT TOP 1 1 FROM m_PartContrastOldVer_t WHERE PAvcPart= '" & partID & "' AND VERSION='" & Version & "')")
            'strSQL.Append(" BEGIN  INSERT INTO m_PartContrastOldVer_t ")
            'strSQL.Append("  SELECT * FROM m_PartContrast_t WHERE PAvcPart='" & partID & "'  end ")

            strSQL.Append("  BEGIN INSERT INTO dbo.m_PartContrastOldVer_t( TAvcPart ,")
            strSQL.Append("  PartName,PAvcPart, CusID,CustPart,MethodID, UseY,LmtY,WarnDate,")
            strSQL.Append(" userID, Intime,TypeDest, PartCode, Supplierid,IsUpload,Isasseble,")
            strSQL.Append(" IsLotScan,IsAlter,MaterialAlter,IsPrintFile,IsTransOracle,")
            strSQL.Append(" IsChkTransData,AmountQty,DESCRIPTION,SubstituteFlag,IngredientsPart, SubstituteNumber,")
            strSQL.Append(" IsReplace, Extensible,EffectiveDate, ExpirationDate,Version,")
            strSQL.Append(" Type,MARK, EcnChange,SeriesID, EquipmentType,PartSeriesType, PlanType )")
            strSQL.Append(" SELECT  TAvcPart , PartName , PAvcPart ,  CusID , CustPart , MethodID ,")
            strSQL.Append("  UseY ,LmtY ,WarnDate , Userid , Intime ,TypeDest , PartCode ,Supplierid ,")
            strSQL.Append(" IsUpload ,Isasseble ,IsLotScan ,IsAlter ,MaterialAlter ,")
            strSQL.Append(" IsPrintFile , IsTransOracle , IsChkTransData ,AmountQty ,DESCRIPTION ,SubstituteFlag ,")
            strSQL.Append("  IngredientsPart , SubstituteNumber ,IsReplace , Extensible , EffectiveDate , ExpirationDate ,")
            strSQL.Append("   '" & Version & "' as Version,TYPE , MARK ,EcnChange , SeriesID , EquipmentType ,  PartSeriesType , PlanType")
            strSQL.Append(" FROM m_PartContrast_t WHERE PAvcPart='" & partID & "'  end")

            'add by cq20170813
            strSQL.Append(" INSERT INTO  m_RCardDCheckItemLog_t(partid, ")
            strSQL.Append(" Stationid, CheckItemID, DESCRIPTION, ResultValue, STATUS, checkgroup, Userid,intime,")
            strSQL.Append(" LeftTVPN, leftwirepn1, LeftWirePN2, leftwirepn3, leftwirepn4,")
            strSQL.Append(" RightTVPN, RightWirePN2, RightWirePN3, RightWirePN4, FinishSize,")
            strSQL.Append(" LeftCutSize, RightCutSize, Tolerance, ToleranceRange, factoryID,")
            strSQL.Append(" profitCenter, LeftTVPNShow, RightTVPNShow, Version )")
            strSQL.Append(" SELECT partid,")
            strSQL.Append("Stationid, CheckItemID, DESCRIPTION, ResultValue, STATUS, checkgroup, Userid,intime,")
            strSQL.Append("LeftTVPN, leftwirepn1, LeftWirePN2, leftwirepn3,leftwirepn4,")
            strSQL.Append("RightTVPN, RightWirePN2, RightWirePN3, RightWirePN4,FinishSize,")
            strSQL.Append("LeftCutSize, RightCutSize, Tolerance, ToleranceRange,Factoryid,")
            strSQL.Append("Profitcenter,LeftTVPNShow,RightTVPNShow, '" & Version & "' as Version ")
            strSQL.Append(" FROM m_RCardDCheckItem_t WHERE PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter)

            strSQL.Append(" INSERT INTO m_RCardDLog_t(PartID,StationID,DrawingVer,StationSQ")
            strSQL.Append(" ,WorkingHours,Equipment,ProcessStandard")
            strSQL.Append(" ,Remark,Status ,Shape ,NewProcessStandard ,VariableName1 ,VariableValue1")
            strSQL.Append(" ,VariableName2 ,VariableValue2 ,Factoryid ,Profitcenter ,UserID ,InTime")
            strSQL.Append("  ,FinishSize ,ProcessStandardPrint,BackupTime)")
            strSQL.Append(" SELECT PartID,StationID,DrawingVer,StationSQ,WorkingHours,Equipment,ProcessStandard,  ")
            strSQL.Append(" Remark,Status ,Shape ,NewProcessStandard ,VariableName1 ,VariableValue1")
            strSQL.Append(" ,VariableName2 ,VariableValue2 ,Factoryid ,[Profitcenter] ,UserID ,InTime,FinishSize ,ProcessStandardPrint,getdate()")
            strSQL.Append(" FROM m_RCardD_t where PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter)

        Else
            strSQL.Append(" UPDATE m_RCardMOldVer_t set Status=1 WHERE partID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter())
        End If

        GetUpateRCardMAndSaveBOMSQL = strSQL.ToString
    End Function

    Public Shared Function GetHeaderUpdateSQL(isOldVersion As Boolean, currentColumnName As String, editValue As String, runCardId As String) As String
        Dim strSQL As String = String.Empty

        Dim strWhere As String = "WHERE PartID='" & runCardId & "'" & RCardComBusiness.GetFatoryProfitcenter
        'Remove 创建人 20160629
        'If currentColumnName.ToUpper = "SHAPE" Then
        '    If isOldVersion = False Then
        '        If Not String.IsNullOrEmpty(editValue) Then
        '            strSQL = "UPDATE m_RCardM_t SET shape=N'" & editValue & "',ModifyTime=GETDATE() " & strWhere
        '        End If
        '    Else
        '        strSQL = "UPDATE m_RCardMOldVer_t SET shape=N'" & editValue & "',ModifyTime=GETDATE() ) " & strWhere
        '    End If
        'End If
        Select Case currentColumnName.ToUpper
            Case "SHAPE"
                If isOldVersion = False Then
                    If Not String.IsNullOrEmpty(editValue) Then
                        strSQL = "UPDATE m_RCardM_t SET shape=N'" & editValue & "',ModifyTime=GETDATE() " & strWhere
                    End If
                Else
                    strSQL = "UPDATE m_RCardMOldVer_t SET shape=N'" & editValue & "',ModifyTime=GETDATE() " & strWhere
                End If
            Case "STDLABORS"
                If isOldVersion = False Then
                    ' If Not String.IsNullOrEmpty(editValue) Then
                    strSQL = "UPDATE m_RCardM_t SET StdLabors=N'" & editValue & "',ModifyTime=GETDATE() " & strWhere
                    'End If
                Else
                    strSQL = "UPDATE m_RCardMOldVer_t SET StdLabors=N'" & editValue & "',ModifyTime=GETDATE()" & strWhere
                End If
            Case Else

        End Select
        GetHeaderUpdateSQL = strSQL
    End Function

    Public Shared Function GetBodyUpdateSQL(isOldVersion As Boolean, currentColumnName As String, editValue As String, runCardId As String, stationId As String, oldValue As String, StationSeq As Integer) As String
        Dim strSQL As String = String.Empty

        Dim strWhere As String = "WHERE PartID='" & runCardId & "' AND StationID = '" & stationId & "' and StationSQ='" & StationSeq & "' " &
                                 RCardComBusiness.GetFatoryProfitcenter
        'Add update Header ModifyTime 20151028, not update userid(创建人)cq20151117
        If currentColumnName = RunCardBusiness.BodyGrid.WorkingHours.ToString Then
            If isOldVersion = False Then
                'add by cq20180125
                strSQL = strSQL + " declare @OldUserID varchar(20), @OldModifyTime datetime" & _
                         " SELECT  @OldUserID=USERID ,@OldModifyTime=InTime FROM m_RCardD_t WHERE PARTID='" & runCardId & "' AND STATIONID ='" & stationId & "'" & _
                          " Insert into m_RCardChangeLog_t(PartID,StationID, Type, OldUserID, OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & _
                         " Values('" & runCardId & "','" & stationId & "',N'工时', @OldUserID, @OldModifyTime,N'" & oldValue & "'," & _
                         " '" & userID & "',getdate(), N'" & editValue & "')"

                strSQL &= "UPDATE m_RCardD_t SET WorkingHours=" & editValue & "" & _
                 ",USERID='" & userID & "',Intime=GETDATE() " & strWhere
                strSQL &= Chr(13) + Chr(10) + " UPDATE m_RCardM_t SET ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"

            Else
                strSQL = "UPDATE m_RCardDOldVer_t SET WorkingHours=" & editValue & "" & _
              ",USERID='" & userID & "',Intime=GETDATE() " & strWhere

                strSQL &= Chr(13) + Chr(10) + " UPDATE m_RCardMOldVer_t SET USERID='" & userID & "',ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"
            End If
        ElseIf currentColumnName = RunCardBusiness.BodyGrid.Equipment.ToString Then
            If isOldVersion = False Then
                'add by cq20180125
                strSQL = strSQL + " declare @OldUserID varchar(20), @OldModifyTime datetime" & _
                         " SELECT  @OldUserID=USERID ,@OldModifyTime=InTime FROM m_RCardD_t WHERE PARTID='" & runCardId & "' AND STATIONID ='" & stationId & "'" & _
                          " Insert into m_RCardChangeLog_t(PartID,StationID, Type, OldUserID, OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & _
                         " Values('" & runCardId & "','" & stationId & "',N'设备治具', @OldUserID, @OldModifyTime,N'" & oldValue & "'," & _
                         " '" & userID & "',getdate(), N'" & editValue & "')"
                strSQL = strSQL + "UPDATE m_RCardD_t SET EQUIPMENT=N'" & editValue & "'" & _
                 ",USERID='" & userID & "',Intime=GETDATE() " & strWhere

                strSQL &= Chr(13) + Chr(10) + " UPDATE m_RCardM_t SET ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"

            Else
                strSQL = "UPDATE m_RCardDOldVer_t SET EQUIPMENT=N'" & editValue & "'" & _
                ",USERID='" & userID & "',Intime=GETDATE() " & strWhere

                strSQL &= Chr(13) + Chr(10) + " UPDATE m_RCardMOldVer_t SET USERID='" & userID & "',ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"
            End If
        ElseIf currentColumnName = RunCardBusiness.BodyGrid.ProcessStandard.ToString Then

            If isOldVersion = False Then
                'add by cq20180125
                strSQL = strSQL + " declare @OldUserID varchar(20), @OldModifyTime datetime" & _
                         " SELECT  @OldUserID=USERID ,@OldModifyTime=InTime FROM m_RCardD_t WHERE PARTID='" & runCardId & "' AND STATIONID ='" & stationId & "'" & _
                          " Insert into m_RCardChangeLog_t(PartID,StationID, Type, OldUserID, OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & _
                         " Values('" & runCardId & "','" & stationId & "',N'工艺标准', @OldUserID, @OldModifyTime,N'" & oldValue & "'," & _
                         " '" & userID & "',getdate(), N'" & editValue & "')"
                'Modify by cq20170519
                strSQL &= "UPDATE m_RCardD_t SET PROCESSSTANDARD= N'" & editValue & "', ProcessStandardPrint=N'" & editValue & "' " & _
                 ",USERID='" & userID & "',Intime=GETDATE() " & strWhere

                strSQL &= Chr(13) + Chr(10) + " UPDATE m_RCardM_t SET ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"

                ' strSQL &= Chr(13) + Chr(10) + " Insert m_RcardDProcessLog_t(PartID, OldProcess, NewProcess,StationID, userid, intime) values( '" & runCardId & "', N'" & oldValue & "', N'" & editValue & "', '" & stationId & "','" & userID & "',getdate()) "
            Else
                strSQL = " UPDATE m_RCardDOldVer_t SET PROCESSSTANDARD= N'" & editValue & "', ProcessStandardPrint=N'" & editValue & "'" & _
                     ",USERID='" & userID & "',Intime=GETDATE() " & strWhere
                strSQL &= Chr(13) + Chr(10) + " UPDATE m_RCardMOldVer_t SET USERID='" & userID & "',ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"

            End If
        ElseIf currentColumnName = RunCardBusiness.BodyGrid.Remark.ToString Then
            If isOldVersion = False Then
                'add by cq20180125
                strSQL = strSQL + " declare @OldUserID varchar(20), @OldModifyTime datetime" & _
                         " SELECT  @OldUserID=USERID ,@OldModifyTime=InTime FROM m_RCardD_t WHERE PARTID='" & runCardId & "' AND STATIONID ='" & stationId & "'" & _
                          " Insert into m_RCardChangeLog_t(PartID,StationID, Type, OldUserID, OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & _
                         " Values('" & runCardId & "','" & stationId & "',N'备注', @OldUserID, @OldModifyTime,N'" & oldValue & "'," & _
                         " '" & userID & "',getdate(), N'" & editValue & "')"

                strSQL &= "UPDATE m_RCardD_t SET REMARK=N'" & editValue & "'" & _
                 ",USERID='" & userID & "',INTIME=GETDATE() " & strWhere
                strSQL &= Chr(13) + Chr(10) + " UPDATE m_RCardM_t SET ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"

            Else
                strSQL = "UPDATE m_RCardDOldVer_t SET REMARK=N'" & editValue & "'" & _
                ",USERID='" & userID & "',INTIME=GETDATE()  " & strWhere

                strSQL &= Chr(13) + Chr(10) + " UPDATE m_RCardMOldVer_t SET USERID='" & userID & "',ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"
            End If
        End If
        GetBodyUpdateSQL = strSQL
    End Function

    'cq 20160414, As is: ,USERID='" & userID & "', now: remove
    'cq 20160707, As is: ,INTIME=GETDATE(), now remove
    Public Shared Function GetSaveRejectStatusSQL(isOldVer As Boolean, partID As String) As String
        Dim strSQL As String = "UPDATE {0} SET STATUS=0 WHERE PartID='" & partID & "'" &
                                RCardComBusiness.GetFatoryProfitcenter

        If isOldVer = False Then
            strSQL = String.Format(strSQL, "m_RCardM_t")
        Else
            strSQL = String.Format(strSQL, "m_RCardMOldVer_t")
        End If

        GetSaveRejectStatusSQL = strSQL
    End Function

    Public Shared Function GetRejectStatusDeleteLogSQL(partID As String, ByVal strVersion As String) As String
        Dim strSQL As String = String.Empty
        strSQL = " DELETE  FROM m_RCardDCheckItemLog_t  " & _
                 " WHERE PartID='" & partID & "' AND version ='" & strVersion & "'" & _
        RCardComBusiness.GetFatoryProfitcenter()

        strSQL &= " DELETE  FROM m_RCardDLog_t  " & _
                  " WHERE PartID='" & partID & "' AND DrawingVer ='" & strVersion & "'" & _
      RCardComBusiness.GetFatoryProfitcenter()

        GetRejectStatusDeleteLogSQL = strSQL
    End Function

    Public Shared Function GetBodyConfirmSQL(isOldVer As Boolean, partID As String) As String
        Dim strBodyVersion As String = String.Empty
        'cq 20160418, not update userid, modifytime=getdate() 20161124
        Dim strSQL As String = " UPDATE {0} set Status=2,remark=null WHERE PartID='" & partID & "'" &
                                RCardComBusiness.GetFatoryProfitcenter

        If isOldVer = False Then
            strSQL = String.Format(strSQL, "m_RCardM_t")
        Else
            strSQL = String.Format(strSQL, "m_RCardMOldVer_t")
        End If

        'CQ 20161101
        If isOldVer = False AndAlso (IsSameVersion(partID, strBodyVersion) = False) Then
            strSQL = strSQL + " UPDATE m_RCardD_t SET DrawingVer = '" & strBodyVersion & "' WHERE PARTID = '" & partID & "'  "
        End If

        GetBodyConfirmSQL = strSQL
    End Function

    Private Shared Function IsSameVersion(ByVal partid As String, ByRef strBodyVersion As String) As Boolean
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT  m.DrawingVer,d.DrawingVer  FROM M_RCARDM_T m " & _
                " LEFT JOIN m_RCardD_t d ON  m.PartID = d.PartID" & _
                " WHERE m.PARTID ='" & partid & "' AND m.DrawingVer <> d.DrawingVer "
        Using dt As DataTable = RCardComBusiness.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                If dt.Rows(0).Item(0) = RCardComBusiness.DBNullToStr(dt.Rows(0).Item(1)) Then
                    IsSameVersion = True
                Else
                    strBodyVersion = RCardComBusiness.DBNullToStr(dt.Rows(0).Item(0))
                    IsSameVersion = False
                End If
            Else
                'bypass 
                IsSameVersion = True
            End If
        End Using
        Return IsSameVersion
    End Function

    Public Shared Function IsOldRCardVersion(ByVal PN As String, ByVal strRCardVersion As String) As Boolean
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT TOP 1 1  FROM m_RCardM_t WHERE partid ='" & PN & "' AND DrawingVer='" & strRCardVersion & "'"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsOldRCardVersion = False
            Else
                IsOldRCardVersion = True
            End If
        End Using
        Return IsOldRCardVersion
    End Function

    Public Shared Function Import2ExcelByAs(ByVal file As String, ByVal outPutFile As String, ByVal dt As DataTable, _
                                              ByVal dics As System.Collections.Generic.Dictionary(Of String, String), ByVal strPartID As String, ByRef errorMsg As String) As Boolean
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Dim o_strPicturePath As String = String.Empty
        Try
            workBookDesigner = New WorkbookDesigner
            wk = New Workbook(file)
            workBookDesigner.Workbook = wk

            workBookDesigner.SetDataSource(dt)

            For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
                workBookDesigner.SetDataSource(dic.Key, dic.Value)
            Next

            Dim bc1 As DotNetBarcode = New DotNetBarcode(DotNetBarcode.Types.QRCode)
            bc1.SaveFileType = DotNetBarcode.SaveFileTypes.Gif

            o_strPicturePath = Environment.CurrentDirectory + "\" & "barcode.bmp"
            bc1.QRSave(strPartID, o_strPicturePath, 3)

            'E3
            'For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
            '    workBookDesigner.SetDataSource(dic.Key, dic.Value)
            'Next

            Dim pictures As Aspose.Cells.Drawing.PictureCollection = workBookDesigner.Workbook.Worksheets(0).Pictures
            'C1
            pictures.Add(0, 2, o_strPicturePath)

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

    Public Shared Function Import2ExcelRCardList(ByVal file As String, ByVal outPutFile As String, ByVal dt As DataTable, _
                                             ByVal dics As System.Collections.Generic.Dictionary(Of String, String), ByVal strPartID As String, ByRef errorMsg As String) As Boolean
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Dim o_strPicturePath As String = String.Empty
        Try
            workBookDesigner = New WorkbookDesigner
            wk = New Workbook(file)
            workBookDesigner.Workbook = wk

            workBookDesigner.SetDataSource(dt)

            For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
                workBookDesigner.SetDataSource(dic.Key, dic.Value)
            Next

            Dim bc1 As DotNetBarcode = New DotNetBarcode(DotNetBarcode.Types.QRCode)
            bc1.SaveFileType = DotNetBarcode.SaveFileTypes.Gif

            o_strPicturePath = Environment.CurrentDirectory + "\" & "barcode.bmp"
            bc1.QRSave(strPartID, o_strPicturePath, 3)

            'E3
            'For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
            '    workBookDesigner.SetDataSource(dic.Key, dic.Value)
            'Next

            Dim pictures As Aspose.Cells.Drawing.PictureCollection = workBookDesigner.Workbook.Worksheets(0).Pictures
            'C1
            pictures.Add(0, 2, o_strPicturePath)

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


#Region "计算工时"
    Public Shared Function GetFinishSizeByPartID(ByVal parPartID As String, ByVal parStationID As String) As String
        Dim lsSQL As String = ""
        GetFinishSizeByPartID = "0"
        'lsSQL = " SELECT ISNULL(Detail.FinishSize, header.FinishSize) as FinishSize from m_RCardD_t Detail " & _
        '        " LEFT JOIN m_RCardM_t Header ON  detail.partid = header.partid " & _
        '        " WHERE  detail.partid ='" & parPartID & "' and detail.StationID='" & parStationID & "'"

        lsSQL = " SELECT  FinishSize from m_RCardM_t  " & _
                " WHERE  partid ='" & parPartID & "'"

        Using dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetFinishSizeByPartID = RCardComBusiness.DBNullToStr(dt.Rows(0).Item("FinishSize"))
                If String.IsNullOrEmpty(GetFinishSizeByPartID) Then
                    GetFinishSizeByPartID = "0"
                End If
            Else
                GetFinishSizeByPartID = "0"
            End If
        End Using
        Return GetFinishSizeByPartID
    End Function
#End Region

#Region "下载TIP数据保存"



    '保存ERP下载数据
    Public Shared Function SaveErpData(dt As DataTable) As Boolean
        Dim tavcPart As String = String.Empty
        Dim pavcPart As String = String.Empty
        Dim Version As String = String.Empty
        Dim ParentFormat As String = String.Empty
        Dim ChildFormat As String = String.Empty
        Dim ParentDes As String = String.Empty
        Dim ChildDes As String = String.Empty
        Dim EffectiveDate As String = String.Empty
        Dim ExpirationDate As Object = String.Empty
        Dim EXTENSIABLE As String = String.Empty
        Dim Qty As String = String.Empty
        Dim strCustID As String = "", strSeriesID As String = ""
        Dim pavcPartList As ArrayList = New ArrayList
        Dim insertSql As New System.Text.StringBuilder
        Dim o_strExecuteSQLResult As String = ""
        Dim strInsertSQL As String = ""

        'Add by cq 20160606
        insertSql.Append("DELETE FROM m_PartContrast_t WHERE PAVCPART = '" & dt.Rows(0)(BomInfo.ParentPartId.ToString) & "' and isnull([TYPE],'R')='R'")

        'Dim strInsertSQL As String =
        '    "INSERT INTO dbo.m_PartContrast_t " &
        '        "(TAvcPart ,PAvcPart ,UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
        '         "Extensible ,EffectiveDate ,ExpirationDate ,VERSION ,TYPE,CusID, SeriesID)"
        Dim strUpdateSQL As String = " UPDATE dbo.m_PartContrast_t "
        '子料号
        For iCnt As Integer = 0 To dt.Rows.Count - 1

            tavcPart = dt.Rows(iCnt)(BomInfo.ChildPartId.ToString).ToString
            pavcPart = dt.Rows(iCnt)(BomInfo.ParentPartId.ToString).ToString
            Version = dt.Rows(iCnt)(BomInfo.Version.ToString).ToString
            ParentFormat = dt.Rows(iCnt)(BomInfo.ParentFormat.ToString).ToString
            ChildFormat = dt.Rows(iCnt)(BomInfo.ChildFormat.ToString).ToString
            ParentDes = dt.Rows(iCnt)(BomInfo.ParentDescription.ToString).ToString
            ChildDes = dt.Rows(iCnt)(BomInfo.ChildDescription.ToString).ToString
            EffectiveDate = dt.Rows(iCnt)(BomInfo.EffectiveDate.ToString).ToString

            If IsDBNull(dt.Rows(iCnt)(BomInfo.ExpirationDate.ToString)) Then 'Modify by CQ 20151208
                ExpirationDate = DBNull.Value
                strInsertSQL =
                    "INSERT INTO dbo.m_PartContrast_t " &
                        "(TAvcPart ,PAvcPart ,UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
                         "Extensible ,EffectiveDate ,VERSION ,TYPE,CusID, SeriesID,Factory)"
            Else
                ExpirationDate = dt.Rows(iCnt)(BomInfo.ExpirationDate.ToString)
                strInsertSQL =
                    "INSERT INTO dbo.m_PartContrast_t " &
                        "(TAvcPart ,PAvcPart ,UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
                         "Extensible ,EffectiveDate ,ExpirationDate ,VERSION ,TYPE,CusID, SeriesID,Factory)"
            End If

            EXTENSIABLE = dt.Rows(iCnt)(BomInfo.Extensible.ToString).ToString
            Qty = dt.Rows(iCnt)(BomInfo.Qty.ToString).ToString
            'add by 马跃平 2018-08-27 因为 AmountQty在料件表中是numberic类型
            If String.IsNullOrEmpty(Qty.Trim()) Then
                Qty = "0"
            End If
            strCustID = dt.Rows(iCnt)(BomInfo.CustID.ToString).ToString
            strSeriesID = dt.Rows(iCnt)(BomInfo.SeriesID.ToString).ToString

            '料件修改 20151108 Daniel
            If (pavcPartList.Contains(pavcPart)) = False Then
                pavcPartList.Add(pavcPart)
                '父料号
                insertSql.AppendFormat("IF EXISTS (SELECT 1 FROM m_PartContrast_t where TAvcPart = '{0}' AND PAvcPart = '{1}'AND Factory='{2}')", pavcPart, pavcPart, factoryID)
                insertSql.Append(strUpdateSQL)
                insertSql.AppendFormat(" SET PAvcPart = N'{0}',", pavcPart)
                insertSql.AppendFormat(" Userid = N'{0}',", userID)
                insertSql.AppendFormat(" Intime = getdate(),")
                insertSql.AppendFormat(" TypeDest = N'{0}',", TransferDBSpecChar(ParentDes))
                insertSql.AppendFormat(" DESCRIPTION = N'{0}',", TransferDBSpecChar(ParentFormat))
                insertSql.AppendFormat(" CusID = N'{0}', ", strCustID)
                insertSql.AppendFormat(" SeriesID = N'{0}'", strSeriesID)
                insertSql.AppendFormat(" WHERE TAvcPart ='{0}'", pavcPart)
                insertSql.AppendFormat(" AND PAvcPart = '{0}'", pavcPart)
                insertSql.AppendFormat(" AND Factory = '{0}'", factoryID)
                insertSql.Append(" ELSE ")
                insertSql.Append(strInsertSQL)
                insertSql.Append(" VALUES(")
                insertSql.AppendFormat("N'{0}',", pavcPart)
                insertSql.AppendFormat("N'{0}',", pavcPart)
                insertSql.AppendFormat("N'Y',")
                insertSql.AppendFormat("N'{0}',", userID)
                insertSql.AppendFormat("getdate(),")
                insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ParentDes))
                insertSql.AppendFormat("N'{0}',", Qty)
                insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ParentFormat))
                insertSql.AppendFormat("'{0}',", "Y")
                insertSql.AppendFormat("{0},", "NULL")
                If Not IsDBNull(ExpirationDate) Then
                    insertSql.AppendFormat("{0},", "NULL")
                End If
                insertSql.AppendFormat("N'{0}',", "")
                insertSql.AppendFormat("N'{0}',", "R")
                insertSql.AppendFormat("N'{0}',", strCustID)
                insertSql.AppendFormat("N'{0}',", strSeriesID) 'EffectiveDate ,ExpirationDate ,VERSION ,TYPE,CusID, SeriesID
                insertSql.AppendFormat("N'{0}'", factoryID)
                insertSql.Append(");")
            End If
            insertSql.AppendFormat("IF EXISTS (SELECT 1 from m_PartContrast_t where TAvcPart = '{0}' and PAvcPart = '{1}' AND Factory='{2}')", tavcPart, pavcPart, factoryID)
            insertSql.Append(strUpdateSQL)
            insertSql.AppendFormat(" SET PAvcPart = N'{0}',", pavcPart)
            insertSql.AppendFormat("UseY = 'Y',")
            insertSql.AppendFormat("Userid = N'{0}',", userID)
            insertSql.AppendFormat("Intime = getdate(),")
            insertSql.AppendFormat("TypeDest = N'{0}',", TransferDBSpecChar(ChildDes))
            insertSql.AppendFormat("AmountQty = '{0}',", Qty)
            insertSql.AppendFormat("DESCRIPTION = N'{0}',", TransferDBSpecChar(ChildFormat))
            insertSql.AppendFormat("Extensible = N'{0}',", EXTENSIABLE)
            insertSql.AppendFormat("EffectiveDate = N'{0}',", EffectiveDate)
            If IsDBNull(ExpirationDate) Then  'Modify by CQ 20151208
                insertSql.AppendFormat("ExpirationDate = NULL,")
            Else
                insertSql.AppendFormat("ExpirationDate = '{0}',", ExpirationDate)
            End If
            ' insertSql.AppendFormat("ExpirationDate = N'{0}',", ExpirationDate)
            insertSql.AppendFormat("VERSION = N'{0}',", Version)
            insertSql.AppendFormat(" CusID = N'{0}', ", strCustID)
            insertSql.AppendFormat(" SeriesID = N'{0}',", strSeriesID)
            insertSql.AppendFormat("TYPE = N'{0}'", "R")
            insertSql.AppendFormat("WHERE TAvcPart ='{0}'", tavcPart)
            insertSql.AppendFormat("AND PAvcPart = '{0}'", pavcPart)
            insertSql.AppendFormat(" AND Factory = '{0}'", factoryID)
            insertSql.Append(" ELSE ")
            insertSql.Append(strInsertSQL)
            insertSql.Append(" VALUES(")
            insertSql.AppendFormat("N'{0}',", tavcPart)
            insertSql.AppendFormat("N'{0}',", pavcPart)
            insertSql.AppendFormat("N'Y',")
            insertSql.AppendFormat("N'{0}',", userID)
            insertSql.AppendFormat("getdate(),")
            insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildDes))
            insertSql.AppendFormat("N'{0}',", Qty)
            insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildFormat))
            insertSql.AppendFormat("N'{0}',", EXTENSIABLE)  'cq20160618  N ==> EXTENSIABLE
            insertSql.AppendFormat("N'{0}',", EffectiveDate)
            If Not IsDBNull(ExpirationDate) Then  'cq 20160614
                insertSql.AppendFormat("'{0}',", ExpirationDate)
            End If
            insertSql.AppendFormat("N'{0}',", Version)
            insertSql.AppendFormat("N'{0}',", "R")
            insertSql.AppendFormat("N'{0}',", strCustID)
            insertSql.AppendFormat("N'{0}',", strSeriesID)
            insertSql.AppendFormat("N'{0}'", factoryID)
            insertSql.Append(");")
        Next
        '保存数据，有事务处理
        o_strExecuteSQLResult = DbOperateUtils.ExecSQL(insertSql.ToString)
        If Not String.IsNullOrEmpty(o_strExecuteSQLResult) Then
            Return False
        End If
        Return True
    End Function


    Public Shared Function SaveErpSetPNData(dt As DataTable) As Boolean
        Dim tavcPart As String = String.Empty
        Dim pavcPart As String = String.Empty
        Dim Version As String = String.Empty
        Dim ParentFormat As String = String.Empty
        Dim ChildFormat As String = String.Empty
        Dim ParentDes As String = String.Empty
        Dim ChildDes As String = String.Empty
        Dim EffectiveDate As String = String.Empty
        Dim ExpirationDate As Object = String.Empty
        Dim EXTENSIABLE As String = String.Empty
        Dim Qty As String = String.Empty
        Dim strCustID As String = "", strSeriesID As String = ""
        Dim pavcPartList As ArrayList = New ArrayList
        Dim insertSql As New System.Text.StringBuilder
        Dim o_strExecuteSQLResult As String = ""
        Dim strInsertSQL As String = ""

        'CQ modify remove AND Tavcpart like '9%' , cq 20180806
        'insertSql.Append("DELETE FROM m_PartContrast_t WHERE ")
        'insertSql.Append(" PAVCPART  = '" & dt.Rows(0)(BomInfo.ParentPartId.ToString).ToString & "' ")
        'insertSql.Append(" AND TAvcPart <> PAvcPart  AND isnull([TYPE],'R')='R'")
        '田玉琳 20190813 
        pavcPart = dt.Rows(0)(BomInfo.ParentPartId.ToString).ToString
        insertSql.Append("DELETE FROM m_PartContrast_t WHERE ")
        insertSql.AppendFormat(" PAVCPART  = '{0}' AND TAvcPart <> PAvcPart  AND isnull([TYPE],'R')='R' " & GetPartFatoryNoBlank(), pavcPart)

        '子料号
        For iCnt As Integer = 0 To dt.Rows.Count - 1
            tavcPart = dt.Rows(iCnt)(BomInfo.ChildPartId.ToString).ToString
            pavcPart = dt.Rows(iCnt)(BomInfo.ParentPartId.ToString).ToString
            Version = dt.Rows(iCnt)(BomInfo.Version.ToString).ToString
            ParentFormat = dt.Rows(iCnt)(BomInfo.ParentFormat.ToString).ToString
            ChildFormat = dt.Rows(iCnt)(BomInfo.ChildFormat.ToString).ToString
            ParentDes = dt.Rows(iCnt)(BomInfo.ParentDescription.ToString).ToString
            ChildDes = dt.Rows(iCnt)(BomInfo.ChildDescription.ToString).ToString
            EffectiveDate = dt.Rows(iCnt)(BomInfo.EffectiveDate.ToString).ToString

            If IsDBNull(dt.Rows(iCnt)(BomInfo.ExpirationDate.ToString)) Then 'Modify by CQ 20151208
                ExpirationDate = DBNull.Value
                strInsertSQL =
                    "INSERT INTO dbo.m_PartContrast_t " &
                        "(TAvcPart ,PAvcPart ,UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
                         "Extensible ,EffectiveDate ,VERSION ,TYPE,CusID, SeriesID,Factory)"
            Else
                ExpirationDate = dt.Rows(iCnt)(BomInfo.ExpirationDate.ToString)
                strInsertSQL =
                    "INSERT INTO dbo.m_PartContrast_t " &
                        "(TAvcPart ,PAvcPart ,UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
                         "Extensible ,EffectiveDate ,ExpirationDate ,VERSION ,TYPE,CusID, SeriesID,Factory)"
            End If

            EXTENSIABLE = dt.Rows(iCnt)(BomInfo.Extensible.ToString).ToString
            Qty = dt.Rows(iCnt)(BomInfo.Qty.ToString).ToString
            strCustID = dt.Rows(iCnt)(BomInfo.CustID.ToString).ToString
            strSeriesID = dt.Rows(iCnt)(BomInfo.SeriesID.ToString).ToString

            insertSql.AppendFormat("IF NOT EXISTS (SELECT 1 from m_PartContrast_t where TAvcPart = '{0}' and PAvcPart = '{1}' " & GetPartFatoryNoBlank() & ")",
                                   tavcPart, pavcPart, factoryID)
            insertSql.Append(strInsertSQL)
            insertSql.Append(" VALUES(")
            insertSql.AppendFormat("N'{0}',", tavcPart)
            insertSql.AppendFormat("N'{0}',", pavcPart)
            insertSql.AppendFormat("N'Y',")
            insertSql.AppendFormat("N'{0}',", userID)
            insertSql.AppendFormat("getdate(),")
            insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildDes))
            insertSql.AppendFormat("N'{0}',", Qty)
            insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildFormat))
            insertSql.AppendFormat("N'{0}',", EXTENSIABLE)  'cq20160618  N ==> EXTENSIABLE
            insertSql.AppendFormat("N'{0}',", EffectiveDate)
            If Not IsDBNull(ExpirationDate) Then  'cq 20160614
                insertSql.AppendFormat("'{0}',", ExpirationDate)
            End If
            insertSql.AppendFormat("N'{0}',", Version)
            insertSql.AppendFormat("N'{0}',", "R")
            insertSql.AppendFormat("N'{0}',", strCustID)
            insertSql.AppendFormat("N'{0}',", strSeriesID)
            insertSql.AppendFormat("N'{0}'", factoryID)
            insertSql.Append(");")
        Next
        '保存数据，有事务处理
        o_strExecuteSQLResult = DbOperateUtils.ExecSQL(insertSql.ToString)
        If Not String.IsNullOrEmpty(o_strExecuteSQLResult) Then
            Return False
        End If
        Return True
    End Function

    Public Shared Function TransferDBSpecChar(target As String) As String
        TransferDBSpecChar = target.Replace("'", "''")
    End Function

    Public Shared Function GetCustIDFromMES(ByVal parPartID As String) As String
        Dim lsSQL As String = ""
        GetCustIDFromMES = ""
        Try
            lsSQL = " SELECT CUSID From m_PartContrast_t " & _
                    " WHERE TAvcPart ='" & parPartID & "'"

            Dim dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetCustIDFromMES = dt.Rows(0).Item("CUSID")
            Else
                GetCustIDFromMES = ""
            End If
            Return GetCustIDFromMES
        Catch ex As Exception
        End Try
    End Function

    Public Shared Function GetSerialIDFromMES(ByVal parPartID As String) As String
        Dim lsSQL As String = ""
        GetSerialIDFromMES = ""
        Try
            lsSQL = " SELECT ISNULL(SeriesID,'') FROM m_PartContrast_t " & _
                    " WHERE TAvcPart='" & parPartID & "'"

            Dim dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetSerialIDFromMES = dt.Rows(0).Item(0)
            Else
                GetSerialIDFromMES = ""
            End If
            Return GetSerialIDFromMES
        Catch ex As Exception
        End Try
    End Function
#End Region

#Region "检查erp的版本"

    Public Shared Function RCardExistInOldData(ByVal partNumber As String, ByVal strVersion As String) As Boolean
        Dim StrSql As String = "SELECT TOP 1 1  FROM  m_RCardMOldver_t WHERE PARTID='" & partNumber & "' AND DrawingVer='" & strVersion & "' "
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(StrSql)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                RCardExistInOldData = True
            Else
                RCardExistInOldData = False
            End If

        End Using
        Return RCardExistInOldData
    End Function
#End Region

#Region "流程卡拷贝"

    Public Shared Sub udpCopyRunCard(paramsList As ArrayList)
        Dim strSQL As String
        '"--declare @NewPN nvarchar(20) " &
        '"--declare @OldPN nvarchar(20) " &
        '"--declare @NewPNVersion nvarchar(20) " &
        '"--declare @UserID nvarchar(20) " &
        '"--set @NewPN ='test' " &
        '"--set @OldPN = '904091719' " &
        '"--set @NewPNVersion = 'VD' " &
        '"--set @UserID = 'L0421481' " &

        Dim FileNO = FrmRunCardHeaderEdit.getFileNO()
        strSQL =
            "INSERT INTO m_RCardM_t(PartID,DrawingVer,Shape,DrawingFilePath,FinishSize,UserID,Status,InTime,Factoryid,Profitcenter,StdLabors,RCardType,FileNO)    " &
            "SELECT @NewPN,@NewPNVersion,Shape,DrawingFilePath,FinishSize,@UserID,0,GETDATE() ,Factoryid,Profitcenter,StdLabors,RCardType,'" & FileNO & "'" &
            "FROM  m_RCardM_t(NOLOCK) WHERE PartID=@OldPN   " &
            "INSERT INTO m_RCardD_t(PartID,StationID,DrawingVer,StationSQ,WorkingHours,Equipment,ProcessStandard,Remark, " &
            "        UserID,Status,InTime,Shape,NewProcessStandard,Factoryid,Profitcenter)  " &
            "SELECT @NewPN,StationID,@NewPNVersion,StationSQ ,WorkingHours,Equipment,ProcessStandard,Remark, " &
            "       @UserID,Status,GETDATE(),Shape, NewProcessStandard,Factoryid,Profitcenter " &
            "FROM m_RCardD_t(NOLOCK) WHERE PartID =@OldPN   "

        DbOperateUtils.ExecSQL(strSQL, paramsList)
    End Sub

#End Region

#Region "流程卡编辑"

    Public Shared Function GetRCardEditSQLOfValue(ByVal strPartID As String, ByVal strVersion As String, ByVal strFactory As String, ByVal strProfitcenter As String) As String
        Dim strSQL As String = String.Empty

        strSQL =
        " IF EXISTS(SELECT TOP 1 1 FROM m_RCardMOldVer_t  " &
        "          WHERE PARTID= @PartID AND DRAWINGVER=@Version  " &
        "          and Factoryid = @Factoryid and Profitcenter = @Profitcenter ) " &
        " begin " &
        "    DELETE m_RCardDPartOldVer_t " &
        "    from m_RCardDPartOldVer_t RCDP INNER JOIN m_RCardMOldVer_t RCM " &
        "    on RCDP.PartID = RCM.PartID and RCDP.DrawingVer = RCM.DrawingVer " &
        "    where RCM.PARTID= @PartID AND RCM.DRAWINGVER=@Version  " &
        "    and RCM.Factoryid = @Factoryid and RCM.Profitcenter = @Profitcenter " &
        "    delete m_RCardDOldVer_t " &
        "    from m_RCardDOldVer_t RCD inner join m_RCardMOldVer_t RCM " &
        "    on RCD.PartID = RCM.PartID and RCD.DrawingVer = RCM.DrawingVer" &
        "    where RCM.PARTID= @PartID AND RCM.DRAWINGVER='" & strVersion & "'  " &
        "    and RCM.Factoryid = @Factoryid and RCM.Profitcenter = @Profitcenter " &
        "    delete m_RCardMOldVer_t where PARTID = @PartID AND DRAWINGVER=@Version  " &
        "    and Factoryid = @Factoryid and Profitcenter = @Profitcenter " &
        " end " & _
        " INSERT m_RCardMOldVer_t (PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize,  status ,Factoryid,Profitcenter,userid,intime,modifytime,StdLabors)" & _
        " SELECT PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize, '1' as status ,Factoryid,Profitcenter,userid,intime,modifytime,StdLabors FROM m_RCardM_t  " & _
        " WHERE PARTID= '" & strPartID & "' AND DRAWINGVER='" & strVersion & "'  " &
        " and Factoryid = '" & strFactory & "' and Profitcenter = '" & strProfitcenter & "'" &
        " insert m_RCardDOldVer_t " & _
         " (PartID, StationID, DrawingVer,StationSQ,WorkingHours," & _
        " Equipment, ProcessStandard, Remark, Status, Shape,NewProcessStandard," & _
        " VariableName1, VariableValue1, VariableName2, VariableValue2, Factoryid, Profitcenter,UserID," & _
        " Intime,FinishSize,ProcessStandardPrint)" & _
        " select RCD.PartID,StationID, @Version, StationSQ, WorkingHours," & _
         " Equipment, ProcessStandard,RCD.Remark, RCD.Status,RCD.Shape, " & _
        " rcd.NewProcessStandard, " & _
        " rcd.VariableName1, rcd.VariableValue1,rcd.VariableName2,rcd.VariableValue2," & _
        " RCD.Factoryid,rcd.Profitcenter,rcd.UserID,rcd.InTime, " & _
        " rcd.FinishSize,rcd.ProcessStandardPrint from m_RCardD_t RCD  " &
        " inner join m_RCardM_t RCM " &
        " on RCD.PartID = RCM.PartID   " &
        " where RCM.PARTID= '" & strPartID & "' AND RCM.DRAWINGVER='" & strVersion & "'  " &
        " and RCM.Factoryid = '" & strFactory & "' and RCM.Profitcenter = '" & strProfitcenter & "' " &
        " insert m_RCardDPartOldVer_t " &
        " select RCDP.* from m_RCardM_t RCM " &
        " inner join m_RCardDPart_t RCDP " &
        " on RCDP.PartID = RCM.PartID   " &
        " where RCM.PARTID= @PartID AND RCM.DRAWINGVER=@Version  " &
        " and RCM.Factoryid = @Factoryid and RCM.Profitcenter = @Profitcenter; "

        Return strSQL

    End Function


    Public Shared Function GetRCardEditSQL() As String
        Dim strSQL As String = String.Empty
        '"--DECLARE @PartID varchar(100); " &
        ' "--DECLARE @Version varchar(100); " &
        ' "--DECLARE @Factoryid varchar(16); " &
        ' "--DECLARE @Profitcenter varchar(16); " &
        ' "--set @PartID = '901013008' " &
        ' "--set @Version = 'VA' " &
        ' "--set @Factoryid = 'LXXT' " &
        ' "--set @Profitcenter = 'SEE-D' " &
        ' as is: cq 20160708
        ' " insert m_RCardMOldVer_t " &
        '" select * from m_RCardM_t  " &
        '    insert m_RCardMOldVer_t (PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize,  status ,Factoryid,Profitcenter,userid,intime,modifytime)
        ' select PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize, '1' as status ,Factoryid,Profitcenter,userid,intime,modifytime from m_RCardM_t  

        strSQL =
        " IF EXISTS(SELECT TOP 1 1 FROM m_RCardMOldVer_t  " &
        "          WHERE PARTID= @PartID AND DRAWINGVER=@Version  " &
        "          and Factoryid = @Factoryid and Profitcenter = @Profitcenter ) " &
        " begin " &
        "    DELETE m_RCardDPartOldVer_t " &
        "    from m_RCardDPartOldVer_t RCDP INNER JOIN m_RCardMOldVer_t RCM " &
        "    on RCDP.PartID = RCM.PartID and RCDP.DrawingVer = RCM.DrawingVer " &
        "    where RCM.PARTID= @PartID AND RCM.DRAWINGVER=@Version  " &
        "    and RCM.Factoryid = @Factoryid and RCM.Profitcenter = @Profitcenter " &
        "    delete m_RCardDOldVer_t " &
        "    from m_RCardDOldVer_t RCD inner join m_RCardMOldVer_t RCM " &
        "    on RCD.PartID = RCM.PartID and RCD.DrawingVer = RCM.DrawingVer" &
        "    where RCM.PARTID= @PartID AND RCM.DRAWINGVER=@Version  " &
        "    and RCM.Factoryid = @Factoryid and RCM.Profitcenter = @Profitcenter " &
        "    delete m_RCardMOldVer_t where PARTID = @PartID AND DRAWINGVER=@Version  " &
        "    and Factoryid = @Factoryid and Profitcenter = @Profitcenter " &
        " end " & _
        " INSERT m_RCardMOldVer_t (PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize,  status ,Factoryid,Profitcenter,userid,intime,modifytime,StdLabors)" & _
        " SELECT PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize, '1' as status ,Factoryid,Profitcenter,userid,intime,modifytime,StdLabors FROM m_RCardM_t  " & _
        " WHERE PARTID= @PartID AND DRAWINGVER=@Version  " &
        " and Factoryid = @Factoryid and Profitcenter = @Profitcenter  " &
        " insert m_RCardDOldVer_t " & _
         " (PartID, StationID, DrawingVer,StationSQ,WorkingHours," & _
        " Equipment, ProcessStandard, Remark, Status, Shape,NewProcessStandard," & _
        " VariableName1, VariableValue1, VariableName2, VariableValue2, Factoryid, Profitcenter,UserID," & _
        " Intime,FinishSize,ProcessStandardPrint)" & _
        " select RCD.PartID,StationID, @Version, StationSQ, WorkingHours," & _
         " Equipment, ProcessStandard,RCD.Remark, RCD.Status,RCD.Shape, " & _
        " rcd.NewProcessStandard, " & _
        " rcd.VariableName1, rcd.VariableValue1,rcd.VariableName2,rcd.VariableValue2," & _
        " RCD.Factoryid,rcd.Profitcenter,rcd.UserID,rcd.InTime, " & _
        " rcd.FinishSize,rcd.ProcessStandardPrint from m_RCardD_t RCD  " &
        " inner join m_RCardM_t RCM " &
        " on RCD.PartID = RCM.PartID   " &
        " where RCM.PARTID= @PartID AND RCM.DRAWINGVER=@Version  " &
        " and RCM.Factoryid = @Factoryid and RCM.Profitcenter = @Profitcenter " &
        " insert m_RCardDPartOldVer_t " &
        " select RCDP.* from m_RCardM_t RCM " &
        " inner join m_RCardDPart_t RCDP " &
        " on RCDP.PartID = RCM.PartID   " &
        " where RCM.PARTID= @PartID AND RCM.DRAWINGVER=@Version  " &
        " and RCM.Factoryid = @Factoryid and RCM.Profitcenter = @Profitcenter; "

        Return strSQL

    End Function

    Public Shared Function GetSaveOldBOMSQL(ByVal PartID As String, ByVal o_strOldVersion As String,
                                            ByVal Factoryid As String, ByVal Profitcenter As String) As String
        Dim strSQL As New StringBuilder

        ' TAvcPart,PartName,PAvcPart,CusID,CustPart
        ',MethodID,UseY,LmtY,WarnDate,Userid ,Intime,TypeDest,PartCode
        ',Supplierid ,IsUpload,Isasseble,IsLotScan
        ',IsAlter ,MaterialAlter,IsPrintFile
        ',IsTransOracle,IsChkTransData,AmountQty ,DESCRIPTION
        ',SubstituteFlag ,IngredientsPart,SubstituteNumber
        ',IsReplace ,Extensible ,EffectiveDate ,ExpirationDate
        ' ,VERSION,TYPE,MARK ,EcnChange ,SeriesID,EquipmentType,PartSeriesType ,PlanType ,MSCustType



        strSQL.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM m_PartContrastOldVer_t   WHERE PAvcPart= '" & PartID & "' AND VERSION='" & o_strOldVersion & "') ")
        strSQL.Append(" Begin ")
        strSQL.Append(" Insert into m_PartContrastOldVer_t( TAvcPart,PartName,PAvcPart,CusID,CustPart,")
        strSQL.Append(" MethodID,UseY,LmtY,WarnDate,Userid ,Intime,TypeDest,PartCode, ")
        strSQL.Append(" Supplierid ,IsUpload,Isasseble,IsLotScan,")
        strSQL.Append(" IsAlter ,MaterialAlter,IsPrintFile,")
        strSQL.Append(" IsTransOracle,IsChkTransData,AmountQty ,DESCRIPTION,")
        strSQL.Append(" SubstituteFlag ,IngredientsPart,SubstituteNumber,")
        strSQL.Append(" IsReplace ,Extensible ,EffectiveDate ,ExpirationDate,")
        strSQL.Append(" VERSION,TYPE,MARK ,EcnChange ,SeriesID,EquipmentType,PartSeriesType ,PlanType)")
        strSQL.Append(" SELECT TAvcPart,PartName,PAvcPart,CusID,CustPart, ")
        strSQL.Append(" MethodID,UseY,LmtY,WarnDate,Userid ,Intime,TypeDest,PartCode,")
        strSQL.Append(" Supplierid ,IsUpload,Isasseble,IsLotScan,")
        strSQL.Append(" IsAlter ,MaterialAlter,IsPrintFile,")
        strSQL.Append(" IsTransOracle,IsChkTransData,AmountQty ,DESCRIPTION,")
        strSQL.Append(" SubstituteFlag ,IngredientsPart,SubstituteNumber,")
        strSQL.Append(" IsReplace ,Extensible ,EffectiveDate ,ExpirationDate,")
        strSQL.Append(" VERSION,TYPE,MARK ,EcnChange ,SeriesID,EquipmentType,PartSeriesType ,PlanType ")
        strSQL.Append(" FROM m_PartContrast_t WHERE PAvcPart='" & PartID & "' ")
        strSQL.Append(" end ")

        'add by cq20170813,多次审核的话就需要保存最新的,20190618
        strSQL.Append(" DELETE FROM m_CutCardDCheckItemLog_t WHERE PartID='" & PartID & "' AND Version='" & o_strOldVersion & "' " & RCardComBusiness.GetFatoryProfitcenter)
        strSQL.Append(" INSERT INTO  m_CutCardDCheckItemLog_t(partid, ")
        strSQL.Append(" Stationid, CheckItemID, DESCRIPTION, ResultValue, STATUS, checkgroup, Userid,intime,")
        strSQL.Append(" LeftTVPN, leftwirepn1, LeftWirePN2, leftwirepn3, leftwirepn4,")
        strSQL.Append(" RightTVPN, RightWirePN2, RightWirePN3, RightWirePN4, FinishSize,")
        strSQL.Append(" LeftCutSize, RightCutSize, Tolerance, ToleranceRange, factoryID,")
        strSQL.Append(" profitCenter, LeftTVPNShow, RightTVPNShow, Version ,CardType)")
        strSQL.Append(" SELECT partid,")
        strSQL.Append("Stationid, CheckItemID, DESCRIPTION, ResultValue, STATUS, checkgroup, Userid,intime,")
        strSQL.Append("LeftTVPN, leftwirepn1, LeftWirePN2, leftwirepn3,leftwirepn4,")
        strSQL.Append("RightTVPN, RightWirePN2, RightWirePN3, RightWirePN4,FinishSize,")
        strSQL.Append("LeftCutSize, RightCutSize, Tolerance, ToleranceRange,Factoryid,")
        strSQL.Append("Profitcenter,LeftTVPNShow,RightTVPNShow, '" & o_strOldVersion & "' as Version,CardType ")
        strSQL.Append(" FROM m_CutCardDCheckItem_t WHERE PartID='" & PartID & "'" & RCardComBusiness.GetFatoryProfitcenter)

        '因为前面的存储过程里面有写入m_CutCardDOldVer_t
        'strSQL.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM m_CutCardDOldVer_t   WHERE PartID= '" & PartID & "' AND DrawingVer='" & o_strOldVersion & "') ")
        'strSQL.Append(" Begin ")
        'strSQL.Append(" INSERT INTO m_CutCardDOldVer_t(PartID,StationID,DrawingVer,StationSQ")
        'strSQL.Append(" ,WorkingHours,Equipment,ProcessStandard")
        'strSQL.Append(" ,Remark,Status ,Shape ,NewProcessStandard ,VariableName1 ,VariableValue1")
        'strSQL.Append(" ,VariableName2 ,VariableValue2 ,Factoryid ,Profitcenter,UserID ,InTime")
        'strSQL.Append(" ,FinishSize,ProcessStandardPrint,LeftProcessStandard,RightProcessStandard,LCLValue)")
        'strSQL.Append(" SELECT PartID,StationID,DrawingVer,StationSQ,WorkingHours,Equipment,ProcessStandard,")
        'strSQL.Append(" Remark,Status ,Shape ,NewProcessStandard ,VariableName1 ,VariableValue1")
        'strSQL.Append(" ,VariableName2 ,VariableValue2 ,Factoryid ,Profitcenter ,UserID ,InTime")
        'strSQL.Append(" ,FinishSize,ProcessStandardPrint,LeftProcessStandard,RightProcessStandard,LCLValue")
        'strSQL.Append(" FROM m_RCardCutD_t where PartID='" & PartID & "'" & RCardComBusiness.GetFatoryProfitcenter)
        'strSQL.Append(" end ")

        Return strSQL.ToString
    End Function

#End Region

#Region "BOM是否存在"
    Public Shared Function BomExists(ByVal pn As String) As Boolean
        'Dim sql As String = "select 1 from m_PartContrast_t(nolock) where TAvcPart in(select TAvcPart from m_PartContrast_t(nolock) where  PAvcPart=N'" & pn & "' and UseY='Y' )"
        Dim sql As String = "SELECT 1 from m_PartContrast_t(nolock) where TAvcPart = PAvcPart AND PAvcPart=N'" & pn & "' and UseY='Y' "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
        If dt.Rows.Count > 0 Then Return True
        Return False
    End Function
#End Region

    ''' <summary>
    ''' 获取版本
    ''' </summary>
    ''' <param name="partNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetVerFromErp(partNumber As String) As String
        Dim o_strErpVer As String
        If VbCommClass.VbCommClass.IsConSap = "Y" Then
            o_strErpVer = SapCommon.GetVerFromTiptopSap(partNumber).ToUpper
        Else
            o_strErpVer = SapCommon.GetVerFromTiptop(partNumber).ToUpper
        End If
        Return o_strErpVer
    End Function

    ''' <summary>
    ''' 获取配套工时的倍数
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAssortMultiple() As Int32
        Dim lsSQL As String = ""
        GetAssortMultiple = 1
        lsSQL = " SELECT PARAMETER_VALUES from m_SystemSetting_t" & _
                " WHERE  PARAMETER_CODE ='AssortMultiple'"
        Using dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetAssortMultiple = Val(RCardComBusiness.DBNullToStr(dt.Rows(0).Item(0)))
            Else
                GetAssortMultiple = 1
            End If
        End Using
        Return GetAssortMultiple
    End Function

    Public Shared Function GetSerialIDFromTT(partNumber As String) As String
        GetSerialIDFromTT = ""
        If VbCommClass.VbCommClass.IsConSap = "N" Then
            GetSerialIDFromTT = SapCommon.GetSerialIDFromTT(partNumber)
        End If
        Return GetSerialIDFromTT
    End Function

    Public Shared Function GetCustIDFromTT(partNumber As String) As String
        GetCustIDFromTT = ""
        If VbCommClass.VbCommClass.IsConSap = "N" Then
            GetCustIDFromTT = SapCommon.GetSerialIDFromTT(partNumber)
        End If
        Return GetCustIDFromTT
    End Function

    Public Shared Function GetPartFatoryNoBlank() As String
        Dim strValue As String = " AND (factory='" & VbCommClass.VbCommClass.Factory & "') "

        Return strValue
    End Function

    Public Shared Function GetPartFatory() As String
        Dim strValue As String = " AND (factory='" & VbCommClass.VbCommClass.Factory & "' or factory = '') "

        Return strValue
    End Function

End Class
