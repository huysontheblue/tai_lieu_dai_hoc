Imports Aspose.Cells
Imports MainFrame
Imports System.Text
Imports MainFrame.SysCheckData

Public Class CutCardBusiness

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
        DrawingFilePath
        FinishSize
        Status
        ZStatus
        UserId
        InTime
        ModifyTime
        Remark
        OldVersion
        '选择 /料件编号/描述/[总工时]/规格/版本/形态/图纸文件/制作状态/创建人
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
        RealTimeEffic
        DrawingFilePath
        FinishSize
        Status
        ZStatus
        UserId
        InTime
        ModifyTime
        Remark
        OldVersion
        '选择 /料件编号/描述/[总工时]/规格/版本/形态/图纸文件/制作状态/创建人
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
        LCLValue
        Status
        UserId
        InTime
        Shape
    End Enum

    Public Enum OldBodyGrid
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
        LCLValue
        LeftTVPN
        RightTVPN
        WirePN
        Status
        UserId
        InTime
        Shape
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

    Public Shared Function CheckIsPartLoss(ByVal strPartID As String, ByRef strLossPartStationName As String) As Boolean
        Dim lsSQL As String = String.Empty
        strLossPartStationName = ""
        lsSQL = " SELECT a.partid,b.Stationname " & _
                " FROM m_RCardCutD_t a" & _
                " LEFT JOIN m_Rstation_t b  ON a.StationID = b.Stationid" & _
                " LEFT JOIN  m_CutCardDPart_t c  ON a.partid = c.PartID AND a.StationID = c.Stationid" & _
                " WHERE CHARINDEX(N'裁线', b.Stationname) >0 AND c.PartID is null AND isnull(a.Remark,'')  =''" & _
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
                strSql = String.Format(strSql, "m_RCardCutM_t")
            Else
                strSql = String.Format(strSql, "m_CutCardMOldVer_t")
            End If

            dt = DbOperateUtils.GetDataTable(strSql)

        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Shared Function GetOldAutiStatus(partID As String, OldCutCardVer As String) As DataTable
        Dim dt As DataTable
        Dim strSql As String = String.Empty

        Try
            strSql = "SELECT STATUS FROM {0} WHERE PartID='" & partID & "' and DrawingVer='" & OldCutCardVer & "' " &
                     RCardComBusiness.GetFatoryProfitcenter


            strSql = String.Format(strSql, "m_CutCardMOldVer_t")


            dt = DbOperateUtils.GetDataTable(strSql)

        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Shared Function GetCutCardPart(ByVal isQueryOldVersion As Boolean, cutCardPartId As String,
                                    stationID As String, Optional ByVal strVersion As String = "") As DataTable
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
            If strVersion <> "" AndAlso isQueryOldVersion = True Then
                strSql = " select  RDP.EWPartNumber PartId ,TypeDest,DESCRIPTION " &
                     "from {0} RDP RIGHT join {3}  PC " &
                     "on rdp.EWPartNumber = pc.TAvcPart AND RDP.PartID = PC.PAvcPart AND ISNULL(PC.TYPE,'R') = 'R' " &
                     " WHERE 1=1 and pc.VERSION='" & strVersion & "' and RDP.PartID='{1}' and RDP.StationID='{2}'   " &
                        RCardComBusiness.GetFatoryProfitcenter("RDP") &
                     " UNION " &
                     " SELECT  RDP.EWPartNumber PartId ,TypeDest,DESCRIPTION " &
                     " FROM {0} RDP RIGHT join {3}  PC " &
                     " ON rdp.EWPartNumber = pc.TAvcPart AND PC.TYPE = 'E' " &
                      " where RDP.PartID='{1}' and RDP.StationID='{2}' and isnull(rdp.EWPNType,'E') = 'E'" &
                        RCardComBusiness.GetFatoryProfitcenter("RDP")
            Else
                strSql = " select  RDP.EWPartNumber PartId ,TypeDest,DESCRIPTION " &
                      "from {0} RDP RIGHT join {3}  PC " &
                     "on rdp.EWPartNumber = pc.TAvcPart AND RDP.PartID = PC.PAvcPart AND ISNULL(PC.TYPE,'R') = 'R' " &
                     " where 1=1 and RDP.PartID='{1}' and RDP.StationID='{2}'   " &
                        RCardComBusiness.GetFatoryProfitcenter("RDP") &
                     " UNION " &
                     " SELECT  RDP.EWPartNumber PartId ,TypeDest,DESCRIPTION " &
                     " FROM {0} RDP RIGHT join {3}  PC " &
                     " ON rdp.EWPartNumber = pc.TAvcPart AND PC.TYPE = 'E' " &
                      " where RDP.PartID='{1}' and RDP.StationID='{2}' and isnull(rdp.EWPNType,'E') = 'E'" &
                RCardComBusiness.GetFatoryProfitcenter("RDP")
            End If

            If isQueryOldVersion = False Then
                '??m_RCardCutDPart_t
                strSql = String.Format(strSql, "m_CutCardDPart_t", cutCardPartId, stationID, "V_m_PartContrast_t")
            Else
                strSql = String.Format(strSql, "m_CutCardDPartOldVer_t", cutCardPartId, stationID, "m_PartContrastOldVer_t")
            End If

            dt = DbOperateUtils.GetDataTable(strSql)

        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Shared Function GetCutCardHeader(ByVal isQueryOldVersion As Boolean, sqlWhere As String) As DataTable
        Dim dt As DataTable
        Dim strSql As String = String.Empty
        Try
            'cq, {0}(nolock) RC,  m_RCardD_t D == > LEFT JOIN 20160406
            strSql =
        " SELECT   '2013-10-10 10:10:10:001' ClickTime,RC.PartID ," &
        "PC.TypeDest," & _
        " ROUND(SUM(d.WorkingHours),1) as TotalHours,  " & _
        " PC.DESCRIPTION , " &
        "RC.DrawingVer ,RC.Shape ," & _
         " StdLabors, iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1)) StdUPPH,  round((iif(sum(d.WorkingHours)=0,0,round((3600/sum(d.WorkingHours)),1))*StdLabors),1) StdUPH,RC.RealTimeEffic," & _
        "IIF(rc.status<>1, isnull(nullif(RC.DrawingFilePath,''), N'双击查看'),DrawingFilePath) DrawingFilePath ," & _
        "RC.FinishSize, RC.Status, " & _
        "CASE RC.Status WHEN 1 THEN N'已完成' WHEN 2 THEN N'待审核' ELSE N'制作中' END ZStatus, " &
        "(SELECT USERNAME FROM m_Users_t where USERID =  RC.UserID) UserID,RC.InTime ,ModifyTime ,RC.Remark , 'false' OldVersion " &
        "FROM {0}(nolock) RC LEFT JOIN {1} D ON  RC.partid = d.PartID  " &
        " LEFT JOIN V_m_PartContrast_t PC ON  RC.PartID=PC.TAvcPart AND PC.TAvcPart = PC.PAvcPart  " &
        " WHERE 1=1  " & sqlWhere &
        RCardComBusiness.GetFatoryProfitcenter("RC") & _
        " GROUP BY RC.PartID,RC.DrawingVer ,RC.Shape ,RC.DrawingFilePath ,RC.FinishSize ,RC.Status," & _
               " RC.userid,RC.InTime ,ModifyTime ,RC.Remark,pc.DESCRIPTION,pc.TypeDest,RC.StdLabors,RC.RealTimeEffic" & _
        " ORDER BY RC.MODIFYTIME DESC,RC.INTIME DESC "
            If isQueryOldVersion = False Then
                strSql = String.Format(strSql, "m_RCardCutM_t", "m_RCardCutD_t")
            Else
                strSql = String.Format(strSql, "m_CutCardMOldVer_t", "m_CutCardDOldVer_t")
            End If
            dt = DbOperateUtils.GetDataTable(strSql)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RunCardCutBusiness", "GetRunCardCutHeader", "RCard")
            Throw ex
        End Try
        Return dt
    End Function

    Public Shared Function GetRunCardCutSide(ByVal isQueryOldVersion As Boolean, sqlWhere As String) As DataTable
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
                strSql = String.Format(strSql, "m_RCardCutM_t")
            Else
                strSql = String.Format(strSql, "m_CutCardMOldVer_t")
            End If

            dt = DbOperateUtils.GetDataTable(strSql)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "RunCardCutBusiness", "GetRunCardCutSide", "RCard")
            ' Throw ex
        End Try

        Return dt
    End Function


    Public Shared Function GetCutCardBody(ByVal isQueryOldVersion As Boolean, cutCardPartId As String, Optional ByVal strCutCardVersion As String = "") As DataSet
        Dim ds As DataSet
        Dim strSql As String = String.Empty
        Dim sqlTail As String = String.Empty

        Try
            If isQueryOldVersion = True Then
                'cq 20161018, Is really query Old version? 
                isQueryOldVersion = RCardComBusiness.IsQueryOldCutCardVersion(cutCardPartId, strCutCardVersion)
            End If

            'A.ProcessStandardPrint is null,A.ProcessStandard  ,A.ProcessStandardPrint, modify by cq20170726
            If strCutCardVersion = "" Or (isQueryOldVersion = False) Then
                strSql = "SELECT A.PartID ,A.StationID,A.StationSQ ,B.StationName ," &
               "CAST(B.SectionID AS VARCHAR) SectionID,cast(A.WorkingHours as varchar) WorkingHours, " &
               "A.Equipment ,IIF(isnull(A.ProcessStandardPrint,'')='',A.ProcessStandard  ,A.ProcessStandardPrint) ProcessStandard , a.LeftProcessStandard,a.RightProcessStandard,A.NewProcessStandard ," &
               "A.Remark ,a.LCLValue ,A.Status ,(SELECT USERNAME FROM m_Users_t where USERID =  A.UserID) UserId ,A.InTime  " &
               "from {0}(nolock) A left join m_Rstation_t(nolock) B on A.StationID=B.Stationid " &
               "where A.PartID='{1}' " &
               RCardComBusiness.GetFatoryProfitcenter("A") &
               "ORDER BY A.StationSQ  "
            Else
                'ProcessStandard ==> IIF(isnull(A.ProcessStandardPrint,'')='',A.ProcessStandard  ,A.ProcessStandardPrint,modify by cq20170726
                strSql = "SELECT A.PartID ,A.StationID,A.StationSQ ,B.StationName ," &
                      "CAST(B.SectionID AS VARCHAR) SectionID,cast(A.WorkingHours as varchar) WorkingHours, " &
                      "A.Equipment   , IIF(isnull(A.ProcessStandardPrint,'')='',A.ProcessStandard  ,A.ProcessStandardPrint) ProcessStandard , a.LeftProcessStandard,a.RightProcessStandard,A.NewProcessStandard ," &
                      "A.Remark ,a.LCLValue ,A.Status ,(select USERNAME from m_Users_t where USERID =  A.UserID) UserId ,A.InTime  " &
                      "FROM {0}(nolock) A left join m_Rstation_t(nolock) B on A.StationID=B.Stationid " &
                      "where A.PartID='{1}'  AND  A.DrawingVer ='" & strCutCardVersion & "'  " &
                      RCardComBusiness.GetFatoryProfitcenter("A") &
                      "order by A.StationSQ  "
            End If

            If strCutCardVersion = "" Or (isQueryOldVersion = False) Then
                sqlTail = "SELECT SUM(ISNULL(RCD.WorkingHours,0)) WorkingHours,st.SectionID " &
                        "FROM {0}(nolock) RCD inner join m_Rstation_t(nolock) ST on RCD.StationID=ST.Stationid " &
                        "WHERE RCD.PartID='{1}' " &
                        RCardComBusiness.GetFatoryProfitcenter("RCD") & "GROUP BY ST.SectionID ; "
            Else
                sqlTail = "SELECT SUM(ISNULL(RCD.WorkingHours,0)) WorkingHours,st.SectionID " &
                     "FROM {0}(nolock) RCD inner join m_Rstation_t(nolock) ST on RCD.StationID=ST.Stationid " &
                     "WHERE RCD.PartID='{1}' AND  RCD.DrawingVer ='" & strCutCardVersion & "' " &
                     RCardComBusiness.GetFatoryProfitcenter("RCD") & "GROUP BY ST.SectionID ; "
            End If

            If isQueryOldVersion = False Then
                strSql = String.Format(strSql, "m_RCardCutD_t", cutCardPartId)
                sqlTail = String.Format(sqlTail, "m_RCardCutD_t", cutCardPartId)
            Else
                strSql = String.Format(strSql, "m_CutCardDOldVer_t", cutCardPartId)
                sqlTail = String.Format(sqlTail, "m_CutCardDOldVer_t", cutCardPartId)
            End If

            ds = DbOperateUtils.GetDataSet(strSql & vbNewLine & sqlTail)

        Catch ex As Exception
            Throw
        End Try

        Return ds
    End Function

    Public Shared Function GetOldCutCardBody(ByVal isQueryOldVersion As Boolean, cutCardPartId As String, Optional ByVal strCutCardVersion As String = "") As DataSet
        Dim ds As DataSet
        Dim strSql As String = String.Empty
        Dim sqlTail As String = String.Empty

        Try
            strSql = "SELECT A.PartID ,A.StationID,A.StationSQ ,B.StationName ," &
                  "CAST(B.SectionID AS VARCHAR) SectionID,cast(A.WorkingHours as varchar) WorkingHours, " &
                  "A.Equipment   , IIF(isnull(A.ProcessStandardPrint,'')='',A.ProcessStandard  ,A.ProcessStandardPrint) ProcessStandard , a.LeftProcessStandard,a.RightProcessStandard,A.NewProcessStandard ," &
                  "A.Remark ,a.LCLValue ,A.Status ,(select USERNAME from m_Users_t where USERID =  A.UserID) UserId ,A.InTime,  isnull(a.LeftTVPN,isnull(item.LeftTVPNShow,item.LeftTVPN))LeftTVPN, isnull(a.rightTVPN,isnull(item.rightTVPNShow,item.rightTVPN))rightTVPN " &
                  " ,ISNULL( a.wirepn, ISNULL( DPart.EWPartNumber,item.LeftWirePN1)) wirepn" & _
                  " FROM {0}(nolock) A left join m_Rstation_t(nolock) B on A.StationID=B.Stationid " &
                  " Left join m_CutCardDCheckItemLog_t item  on a.PartID = item.partid and a.stationid = item.stationid and a.drawingver = item.Version AND  item.CheckItemID='LCL' " & _
                  " LEFT JOIN " & _
                  " ( SELECT * FROM  m_CutCardDPartOldVer_t WHERE EWPartNumber LIKE '00%' OR EWPartNumber LIKE '01%' " & _
                  "      OR  EWPartNumber LIKE '1_____-%' OR  EWPartNumber LIKE '16_-%'" & _
                  "   )  DPart ON  a.PartID =DPart.PartID AND a.StationID= DPart.Stationid AND a.DrawingVer =DPart.DrawingVer " & _
                  " WHERE A.PartID='{1}'   AND  A.DrawingVer ='" & strCutCardVersion & "'  " &
                  RCardComBusiness.GetFatoryProfitcenter("A") &
                  "order by A.StationSQ  "


            sqlTail = "SELECT SUM(ISNULL(RCD.WorkingHours,0)) WorkingHours,st.SectionID " &
                 "FROM {0}(nolock) RCD inner join m_Rstation_t(nolock) ST on RCD.StationID=ST.Stationid " &
                 "WHERE RCD.PartID='{1}' AND  RCD.DrawingVer ='" & strCutCardVersion & "' " &
                 RCardComBusiness.GetFatoryProfitcenter("RCD") & "GROUP BY ST.SectionID ; "



            strSql = String.Format(strSql, "m_CutCardDOldVer_t", cutCardPartId)
            sqlTail = String.Format(sqlTail, "m_CutCardDOldVer_t", cutCardPartId)


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

    Public Shared Sub DeleteCutBody(isQueryOldVersion As Boolean, partID As String, sationID As String, Optional ByVal strVer As String = "")
        Try
            Dim strSQL As String = String.Empty

            If isQueryOldVersion = False Then
                strSQL = "DELETE m_RCardCutD_t WHERE PartID='" & partID & "' AND StationID = '" & sationID & "'" &
                         RCardComBusiness.GetFatoryProfitcenter()
                strSQL += " UPDATE  m_RCardCutD_t  SET STATIONSQ=B.ID FROM m_RCardCutD_t A," &
                                    "(SELECT ROW_NUMBER() OVER(ORDER BY STATIONSQ) ID,STATIONSQ FROM m_RCardCutD_t WHERE PartID='" & partID & "') B" &
                                    " WHERE A.PartID= '" & partID & "'  AND A.STATIONSQ=B.STATIONSQ AND B.ID<>B.STATIONSQ" &
                                    RCardComBusiness.GetFatoryProfitcenter("A")
                strSQL += " DELETE FROM m_CutCardDPart_t WHERE PartID='" & partID & "' AND Stationid = '" & sationID & "' " &
                            RCardComBusiness.GetFatoryProfitcenter()

                'Modify by cq20170823
                strSQL += " DELETE FROM m_CutCardDCheckItem_t WHERE PartID='" & partID & "' AND Stationid='" & sationID & "'" &
                            RCardComBusiness.GetFatoryProfitcenter()

                strSQL += " UPDATE m_RCardCutM_t SET Status=0 where PartID= '" & partID & "'" &
                            RCardComBusiness.GetFatoryProfitcenter
            Else
                strSQL = "DELETE m_CutCardDOldVer_t where PartID='" & partID & "' and DrawingVer ='" & strVer & "' AND StationID = '" & sationID & "'" &
                         RCardComBusiness.GetFatoryProfitcenter
                strSQL += " UPDATE  m_CutCardDOldVer_t  SET STATIONSQ=B.ID FROM m_CutCardDOldVer_t A," &
                                    "(SELECT ROW_NUMBER() OVER(ORDER BY STATIONSQ) ID,STATIONSQ FROM m_CutCardDOldVer_t WHERE PartID='" & partID & "' AND DrawingVer ='" & strVer & "') B" &
                                    " WHERE A.PartID= '" & partID & "' AND DrawingVer ='" & strVer & "'  AND A.STATIONSQ=B.STATIONSQ AND B.ID<>B.STATIONSQ" &
                                    RCardComBusiness.GetFatoryProfitcenter("A")
                strSQL += " DELETE FROM m_CutCardDPartOldVer_t WHERE PartID='" & partID & "' AND DrawingVer ='" & strVer & "' AND Stationid = '" & sationID & "'" &
                            RCardComBusiness.GetFatoryProfitcenter()
                strSQL += " UPDATE m_CutCardMOldVer_t SET Status=0 WHERE PartID= '" & partID & "' AND DrawingVer ='" & strVer & "'" &
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
            strSQL = "  DELETE FROM m_CutCardDPart_t  "
            strSQL += " WHERE PartID='" & RCardPartID & "' "
            strSQL += " And EWPartNumber='" & PartID & "' AND Stationid='" & partStationID & "' " &
                        RCardComBusiness.GetFatoryProfitcenter()
        Else
            strSQL = "  DELETE FROM m_CutCardDPartOldVer_t  "
            strSQL += " WHERE PartID = '" & PartID & "'"
            strSQL += " And EWPartNumber='" & PartID & "' AND  Stationid='" & partStationID & "'" &
                        RCardComBusiness.GetFatoryProfitcenter()
        End If
        DeleteDPartID = strSQL
    End Function

    Public Shared Function DeleteCutHeader(isOldVersion As Boolean, partID As String) As String
        Dim strSQL As String = String.Empty
        If isOldVersion = False Then

            strSQL = "  DELETE A FROM m_CutCardDCheckItem_t A,m_RCardCutD_t B "
            strSQL += " WHERE B.PartID='" & partID & "' "
            strSQL += " AND B.PartID=A.PartID AND B.Stationid=B.Stationid " &
                        RCardComBusiness.GetFatoryProfitcenter("B")

            strSQL += " DELETE A FROM m_CutCardDPart_t A,m_RCardCutD_t B "
            strSQL += " WHERE B.PartID='" & partID & "' "
            strSQL += " AND B.PartID=A.PartID " &
                        RCardComBusiness.GetFatoryProfitcenter("B")

            'Add by cq20161230
            strSQL += "INSERT into m_RCardCutDBak_t( [PartID] ,[StationID] ,[DrawingVer]  ,[StationSQ],[WorkingHours] ,[Equipment] ,[ProcessStandard] ,[Remark]"
            strSQL += ",[Status] ,[Shape],[NewProcessStandard],[VariableName1],[VariableValue1] ,[VariableName2]"
            strSQL += ",[VariableValue2],[Factoryid] ,[Profitcenter]"
            strSQL += ",[UserID] ,[InTime]  ,[FinishSize]) "
            strSQL += " SELECT  PartID ,StationID ,DrawingVer  ,StationSQ,[WorkingHours] ,[Equipment] ,[ProcessStandard] ,[Remark],[Status]"
            strSQL += ",[Shape],[NewProcessStandard],[VariableName1],[VariableValue1],[VariableName2] ,[VariableValue2],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime]  ,[FinishSize]"
            strSQL += " FROM m_RCardCutD_t WHERE  PartID='" & partID & "' " &
            RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " INSERT  INTO m_RCardCutMBak_t([PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime],[ModifyTime]) "
            strSQL += "SELECT [PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime],[ModifyTime] FROM m_RCardCutM_t WHERE  PartID='" & partID & "' " &
            RCardComBusiness.GetFatoryProfitcenter()


            strSQL += " DELETE FROM m_RCardCutD_t WHERE  PartID='" & partID & "' " &
                        RCardComBusiness.GetFatoryProfitcenter()
            strSQL += " DELETE FROM m_RCardCutM_t WHERE  PartID='" & partID & "' " &
                        RCardComBusiness.GetFatoryProfitcenter()
        Else
            strSQL = "  DELETE A FROM m_CutCardDPartOldVer_t A,m_RCardDOldVer_t B "
            strSQL += " WHERE B.PartID = '" & partID & "'"
            strSQL += " AND B.PartID=A.PartID AND B.Stationid=A.Stationid" &
                        RCardComBusiness.GetFatoryProfitcenter()

            'strSQL += " SELECT * INTO m_RCardDOldVerBak_t FROM m_RCardDOldVer_t WHERE  PartID='" & partID & "' " &
            '     RCardComBusiness.GetFatoryProfitcenter()
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

            strSQL += " INSERT  INTO m_CutCardMOldVerBak_t([PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime],[ModifyTime]) "
            strSQL += "SELECT [PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime],[ModifyTime] "
            strSQL += "FROM m_CutCardMOldVer_t WHERE  PartID='" & partID & "' " &
            RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " DELETE FROM m_CutCardDOldVer_t WHERE PartID='" & partID & "'" &
                        RCardComBusiness.GetFatoryProfitcenter()
            strSQL += " DELETE FROM m_CutCardMOldVer_t WHERE PartID='" & partID & "' " &
                        RCardComBusiness.GetFatoryProfitcenter()
        End If
        DeleteCutHeader = strSQL
    End Function


    Public Shared Function HideCutHeader(isOldVersion As Boolean, partID As String, version As String) As String
        Dim strSQL As String = String.Empty
        If isOldVersion = False Then

            strSQL = "  DELETE A FROM m_CutCardDCheckItem_t A,m_RCardCutD_t B "
            strSQL += " WHERE B.PartID='" & partID & "' "
            strSQL += " AND B.PartID=A.PartID AND B.Stationid=B.Stationid " &
                        RCardComBusiness.GetFatoryProfitcenter("B")

            strSQL += " DELETE A FROM m_CutCardDPart_t A,m_RCardCutD_t B "
            strSQL += " WHERE B.PartID='" & partID & "' "
            strSQL += " AND B.PartID=A.PartID " &
                        RCardComBusiness.GetFatoryProfitcenter("B")

            'Add by cq20161230,insert into select from
            strSQL += "INSERT into m_RCardCutDBak_t( [PartID] ,[StationID] ,[DrawingVer]  ,[StationSQ],[WorkingHours] ,[Equipment] ,[ProcessStandard] ,[Remark]"
            strSQL += ",[Status] ,[Shape],[NewProcessStandard],[VariableName1],[VariableValue1] ,[VariableName2]"
            strSQL += ",[VariableValue2],[Factoryid] ,[Profitcenter]"
            strSQL += ",[UserID] ,[InTime]  ,[FinishSize]) "
            strSQL += " SELECT  PartID ,StationID ,DrawingVer  ,StationSQ,[WorkingHours] ,[Equipment] ,[ProcessStandard] ,[Remark],[Status]"
            strSQL += ",[Shape],[NewProcessStandard],[VariableName1],[VariableValue1],[VariableName2] ,[VariableValue2],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime]  ,[FinishSize]"
            strSQL += " FROM m_RCardCutD_t WHERE  PartID='" & partID & "' " &
            RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " INSERT  INTO m_RCardCutMBak_t([PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime],[ModifyTime]) "
            strSQL += "SELECT [PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime],[ModifyTime] FROM m_RCardCutM_t WHERE  PartID='" & partID & "' " &
            RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " DELETE FROM m_RCardCutD_t WHERE  PartID='" & partID & "' " &
                        RCardComBusiness.GetFatoryProfitcenter()
            strSQL += " DELETE FROM m_RCardCutM_t WHERE  PartID='" & partID & "' " &
                        RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " Insert into m_RCardLog_t(PartID, DrawingVer, intime, userid, action ) " & _
                      " values( '" & partID & "', '" & version & "', getdate(), '" & VbCommClass.VbCommClass.UseId & "', 'HideCutHeader')"
        Else
            strSQL = "  DELETE A FROM m_CutCardDPartOldVer_t A,m_RCardDOldVer_t B "
            strSQL += " WHERE B.PartID = '" & partID & "'"
            strSQL += " AND B.PartID=A.PartID AND B.Stationid=A.Stationid" &
                        RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " INSERT  INTO m_CutCardDOldVerBak_t( [partID] ,[StationID]"
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
            strSQL += " FROM m_CutCardDOldVer_t WHERE  PartID='" & partID & "' " &
            RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " INSERT  INTO m_CutCarDMOldVerBak_t([PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime],[ModifyTime]) "
            strSQL += "SELECT [PartID] ,[DrawingVer],[Shape],[DrawingFilePath],[Remark],[FinishSize],[Status],[Factoryid]"
            strSQL += ",[Profitcenter],[UserID],[InTime],[ModifyTime] "
            strSQL += "FROM m_CutCardMOldVer_t WHERE  PartID='" & partID & "' " &
            RCardComBusiness.GetFatoryProfitcenter()

            strSQL += " DELETE FROM m_CutCardDOldVer_t WHERE PartID='" & partID & "'" &
                        RCardComBusiness.GetFatoryProfitcenter()
            strSQL += " DELETE FROM m_CutCardMOldVer_t WHERE PartID='" & partID & "' " &
                        RCardComBusiness.GetFatoryProfitcenter()
            strSQL += " INSERT into m_CutCardLog_t(PartID, DrawingVer, intime, userid, action ) " & _
                      " VALUES( '" & partID & "', '" & version & "', getdate(), '" & VbCommClass.VbCommClass.UseId & "', 'HideCutHeader')"
        End If
        HideCutHeader = strSQL
    End Function

    Public Shared Function DeleteOldCutCard(ByVal partID As String, ByVal strVersion As String) As String
        Dim strSQL As String = String.Empty

        strSQL = "  DELETE A FROM m_CutCardDPartOldVer_t A,m_CutCardDOldVer_t B "
        strSQL += " WHERE B.PartID = '" & partID & "'"
        strSQL += " AND B.PartID=A.PartID AND B.Stationid=A.Stationid and a.DrawingVer = b.DrawingVer " &
                    RCardComBusiness.GetFatoryProfitcenter("A")

        strSQL += " DELETE FROM m_CutCardDOldVer_t WHERE  PartID='" & partID & "' AND DrawingVer='" & strVersion & "' " &
                RCardComBusiness.GetFatoryProfitcenter()

        strSQL += " DELETE FROM m_CutCardMOldVer_t WHERE  PartID='" & partID & "' AND DrawingVer='" & strVersion & "' " &
                    RCardComBusiness.GetFatoryProfitcenter()

        DeleteOldCutCard = strSQL
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
        strSQL = " SELECT TOP 1 USERID, InTime FROM m_RCardCutD_t  WHERE partid=N'" & PartID & "' ORDER BY intime DESC"
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
        strSQL = " SELECT b.sectionid,isnull(sum(a.WorkingHours),0) sectionHours  FROM m_RcardCutD_t a, m_Rstation_t b  " & _
                 " WHERE a.partid ='" & PartID & "' " & _
                 " AND a.stationid = b.Stationid" & _
                 " GROUP BY sectionid"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetdtSectionHours = o_dt
            Else
                GetdtSectionHours = Nothing
            End If
        End Using
        Return GetdtSectionHours
    End Function

    Public Shared Function GetUpateRCardMasterSQL(isOldVer As Boolean, partID As String) As String
        Dim strSQL As String = String.Empty
        If isOldVer = False Then
            'add clear remark by cq 20161119,ModifyTime=getdate()
            strSQL = " UPDATE m_RCardCutM_t SET Status=1,remark='' WHERE PartID='" & partID & "' " &
                        RCardComBusiness.GetFatoryProfitcenter &
                     " INSERT into m_RCardCutMAuditLog_t select '" & partID & "','" & userID & "',getdate()  " & ",'" & factoryID & "','" & profitCenter & "'"
        Else
            strSQL = " UPDATE m_CutCardMOldVer_t SET Status=1 WHERE partID='" & partID & "'" &
                        RCardComBusiness.GetFatoryProfitcenter
        End If

        GetUpateRCardMasterSQL = strSQL
    End Function

    Public Shared Function GetUpateCutCardMAndSaveBOMSQL(isOldVer As Boolean, partID As String, Version As String) As String
        Dim strSQL As New StringBuilder
        If isOldVer = False Then
            strSQL.Append(" UPDATE m_RCardCutM_t SET Status=1,remark='' WHERE PartID='" & partID & "' " & RCardComBusiness.GetFatoryProfitcenter)
            strSQL.Append("  INSERT INTO m_RCardCutMAuditLog_t select '" & partID & "','" & userID & "',getdate()  " & ",'" & factoryID & "','" & profitCenter & "'")

            strSQL.Append("  IF NOT EXISTS(SELECT TOP 1 1 FROM m_PartContrastOldVer_t WHERE PAvcPart= '" & partID & "' AND VERSION='" & Version & "')")
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
            strSQL.Append("  VERSION ,TYPE , MARK ,EcnChange , SeriesID , EquipmentType ,  PartSeriesType , PlanType")
            strSQL.Append(" FROM m_PartContrast_t WHERE PAvcPart='" & partID & "'  end")

            'add by cq20170813,多次审核的话就需要保存最新的,20190618
            strSQL.Append(" DELETE FROM m_CutCardDCheckItemLog_t WHERE PartID='" & partID & "' AND Version='" & Version & "' " & RCardComBusiness.GetFatoryProfitcenter)
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
            strSQL.Append("Profitcenter,LeftTVPNShow,RightTVPNShow, '" & Version & "' as Version,CardType ")
            strSQL.Append(" FROM m_CutCardDCheckItem_t WHERE PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter)

            'add by cq20190619
            strSQL.Append(" DELETE FROM m_CutCardDOldVer_t WHERE PartID='" & partID & "' AND DrawingVer='" & Version & "' " & RCardComBusiness.GetFatoryProfitcenter)
            strSQL.Append(" INSERT INTO m_CutCardDOldVer_t(PartID,StationID,DrawingVer,StationSQ")
            strSQL.Append(" ,WorkingHours,Equipment,ProcessStandard")
            strSQL.Append(" ,Remark,Status ,Shape ,NewProcessStandard ,VariableName1 ,VariableValue1")
            strSQL.Append(" ,VariableName2 ,VariableValue2 ,Factoryid ,[Profitcenter] ,UserID ,InTime")
            strSQL.Append(" ,FinishSize,ProcessStandardPrint,LeftProcessStandard,RightProcessStandard,LCLValue)")
            strSQL.Append(" SELECT PartID,StationID,DrawingVer,StationSQ,WorkingHours,Equipment,ProcessStandard,")
            strSQL.Append(" Remark,Status ,Shape ,NewProcessStandard ,VariableName1 ,VariableValue1")
            strSQL.Append(" ,VariableName2 ,VariableValue2 ,Factoryid ,Profitcenter ,UserID ,InTime")
            strSQL.Append(" ,FinishSize,ProcessStandardPrint,LeftProcessStandard,RightProcessStandard,LCLValue")
            strSQL.Append(" FROM m_RCardCutD_t where PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter)


            strSQL.Append(" INSERT INTO m_RCardCutDLog_t(PartID,StationID,DrawingVer,StationSQ")
            strSQL.Append(" ,WorkingHours,Equipment,ProcessStandard")
            strSQL.Append(" ,Remark,Status ,Shape ,NewProcessStandard ,VariableName1 ,VariableValue1")
            strSQL.Append(" ,VariableName2 ,VariableValue2 ,Factoryid ,Profitcenter,UserID ,InTime")
            strSQL.Append(" ,FinishSize,ProcessStandardPrint,LeftProcessStandard,RightProcessStandard,BackupTime,LCLValue)")
            strSQL.Append(" SELECT PartID,StationID,DrawingVer,StationSQ,WorkingHours,Equipment,ProcessStandard,")
            strSQL.Append(" Remark,Status ,Shape ,NewProcessStandard ,VariableName1 ,VariableValue1")
            strSQL.Append(" ,VariableName2 ,VariableValue2 ,Factoryid ,Profitcenter ,UserID ,InTime")
            strSQL.Append(" ,FinishSize,ProcessStandardPrint,LeftProcessStandard,RightProcessStandard,getdate(),LCLValue")
            strSQL.Append(" FROM m_RCardCutD_t where PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter)

            'add by cq20170930 
            strSQL.Append(" INSERT INTO m_CutCardDPartLog_t(PartID,StationID,EWPartNumber,DrawingVer,")
            strSQL.Append("  UserID,InTime,Factoryid,")
            strSQL.Append("  Profitcenter,EWPNType,EWPNLRDirection,CardType,BackupTime)")
            strSQL.Append(" SELECT PartID,StationID,EWPartNumber,DrawingVer,")
            strSQL.Append(" UserID,InTime,Factoryid,")
            strSQL.Append(" Profitcenter,EWPNType,EWPNLRDirection,CardType,getdate()")
            strSQL.Append(" FROM m_CutCardDPart_t WHERE PartID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter)
        Else
            strSQL.Append(" UPDATE m_CutCardMOldVer_t SET Status=1 WHERE partID='" & partID & "'" & RCardComBusiness.GetFatoryProfitcenter())
        End If

        GetUpateCutCardMAndSaveBOMSQL = strSQL.ToString
    End Function

    Public Shared Function GetHeaderUpdateSQL(isOldVersion As Boolean, currentColumnName As String, editValue As String, runCardId As String) As String
        Dim strSQL As String = String.Empty

        Dim strWhere As String = "WHERE PartID='" & runCardId & "'" & RCardComBusiness.GetFatoryProfitcenter

        Select Case currentColumnName.ToUpper
            Case "SHAPE"
                If isOldVersion = False Then
                    If Not String.IsNullOrEmpty(editValue) Then
                        strSQL = "UPDATE m_RCardCutM_t SET SHAPE=N'" & editValue & "',ModifyTime=GETDATE() " & strWhere
                    End If
                Else
                    strSQL = "UPDATE m_CutCardMOldVer_t SET SHAPE=N'" & editValue & "',ModifyTime=GETDATE() " & strWhere
                End If
            Case "STDLABORS"
                If isOldVersion = False Then
                    strSQL = "UPDATE m_RCardCutM_t SET StdLabors=N'" & editValue & "',ModifyTime=GETDATE() " & strWhere
                Else
                    strSQL = "UPDATE m_CutCardMOldVer_t SET StdLabors=N'" & editValue & "',ModifyTime=GETDATE()" & strWhere
                End If
            Case Else

        End Select
        GetHeaderUpdateSQL = strSQL
    End Function

    Public Shared Function GetBodyUpdateSQL(isOldVersion As Boolean, currentColumnName As String, editValue As String, runCardId As String, stationId As String, oldValue As String) As String
        Dim strSQL As String = String.Empty

        Dim strWhere As String = "WHERE PartID='" & runCardId & "' AND StationID = '" & stationId & "'" &
                                 RCardComBusiness.GetFatoryProfitcenter
        'Add update Header ModifyTime 20151028, not update userid(创建人)cq20151117
        If currentColumnName = RunCardBusiness.BodyGrid.WorkingHours.ToString Then
            If isOldVersion = False Then
                strSQL = "UPDATE m_RCardCutD_t SET WorkingHours=" & editValue & "" & _
                 ",USERID='" & VbCommClass.VbCommClass.UseId & "',Intime=GETDATE() " & strWhere
                strSQL &= Chr(13) + Chr(10) + " UPDATE m_RCardCutM_t SET ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"
            Else
                strSQL = "UPDATE m_CutCardDOldVer_t SET WorkingHours=" & editValue & "" & _
              ",USERID='" & VbCommClass.VbCommClass.UseId & "',Intime=GETDATE() " & strWhere

                strSQL &= Chr(13) + Chr(10) + " UPDATE m_CutCardMOldVer_t SET USERID='" & VbCommClass.VbCommClass.UseId & "',ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"
            End If
        ElseIf currentColumnName = RunCardBusiness.BodyGrid.Equipment.ToString Then
            If isOldVersion = False Then

                strSQL = strSQL + " declare @OldUserID varchar(20), @OldModifyTime datetime" & _
                  " SELECT  @OldUserID=USERID ,@OldModifyTime=InTime FROM m_RCardCutD_t WHERE PARTID='" & runCardId & "' AND STATIONID ='" & stationId & "'" & _
                   " Insert into m_CutCardChangeLog_t(PartID,StationID, Type, OldUserID, OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & _
                  " Values('" & runCardId & "','" & stationId & "',N'设备治具', @OldUserID, @OldModifyTime,N'" & oldValue & "'," & _
                  " '" & VbCommClass.VbCommClass.UseId & "',getdate(), N'" & editValue & "')"

                strSQL &= "UPDATE m_RCardCutD_t SET EQUIPMENT=N'" & editValue & "'" & _
                 ",USERID='" & VbCommClass.VbCommClass.UseId & "',Intime=GETDATE() " & strWhere

                strSQL &= Chr(13) + Chr(10) + " UPDATE m_RCardCutM_t SET ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"

            Else
                strSQL = "UPDATE m_CutCardDOldVer_t SET EQUIPMENT=N'" & editValue & "'" & _
                ",USERID='" & VbCommClass.VbCommClass.UseId & "',Intime=GETDATE() " & strWhere

                strSQL &= Chr(13) + Chr(10) + " UPDATE m_CutCardMOldVer_t SET USERID='" & VbCommClass.VbCommClass.UseId & "',ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"
            End If
        ElseIf currentColumnName = RunCardBusiness.BodyGrid.ProcessStandard.ToString Then

            If isOldVersion = False Then
                'add by cq 20190705
                strSQL = strSQL + " declare @OldUserID varchar(20), @OldModifyTime datetime" & _
                    " SELECT  @OldUserID=USERID ,@OldModifyTime=InTime FROM m_RCardCutD_t WHERE PARTID='" & runCardId & "' AND STATIONID ='" & stationId & "'" & _
                     " Insert into m_CutCardChangeLog_t(PartID,StationID, Type, OldUserID, OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & _
                    " Values('" & runCardId & "','" & stationId & "',N'工艺标准', @OldUserID, @OldModifyTime,N'" & oldValue & "'," & _
                    " '" & VbCommClass.VbCommClass.UseId & "',getdate(), N'" & editValue & "')"

                'Modify by cq20170519
                strSQL &= "UPDATE m_RCardCutD_t SET PROCESSSTANDARD= N'" & editValue & "', ProcessStandardPrint=N'" & editValue & "',LCLValue=N'" & editValue & "' " & _
                 ",USERID='" & VbCommClass.VbCommClass.UseId & "',Intime=GETDATE() " & strWhere

                strSQL &= Chr(13) + Chr(10) + " UPDATE m_RCardCutM_t SET ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"

                strSQL &= Chr(13) + Chr(10) + " Insert m_RcardDProcessLog_t(PartID, OldProcess, NewProcess,StationID, userid, intime) values( '" & runCardId & "', N'" & oldValue & "', N'" & editValue & "', '" & stationId & "','" & VbCommClass.VbCommClass.UseId & "',getdate()) "
            Else
                strSQL = " UPDATE m_RCardCutDOldVer_t SET PROCESSSTANDARD= N'" & editValue & "', ProcessStandardPrint=N'" & editValue & "',LCLValue=N'" & editValue & "'" & _
                     ",USERID='" & VbCommClass.VbCommClass.UseId & "',Intime=GETDATE() " & strWhere
                strSQL &= Chr(13) + Chr(10) + " UPDATE m_CutCardMOldVer_t SET USERID='" & VbCommClass.VbCommClass.UseId & "',ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"

            End If
        ElseIf currentColumnName = RunCardBusiness.BodyGrid.Remark.ToString Then
            If isOldVersion = False Then

                strSQL = strSQL + " declare @OldUserID varchar(20), @OldModifyTime datetime" & _
                   " SELECT  @OldUserID=USERID ,@OldModifyTime=InTime FROM m_RCardCutD_t WHERE PARTID='" & runCardId & "' AND STATIONID ='" & stationId & "'" & _
                    " Insert into m_CutCardChangeLog_t(PartID,StationID, Type, OldUserID, OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & _
                   " Values('" & runCardId & "','" & stationId & "',N'备注', @OldUserID, @OldModifyTime,N'" & oldValue & "'," & _
                   " '" & VbCommClass.VbCommClass.UseId & "',getdate(), N'" & editValue & "')"

                strSQL &= "UPDATE m_RCardCutD_t SET REMARK=N'" & editValue & "'" & _
                 ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE() " & strWhere
                strSQL &= Chr(13) + Chr(10) + " UPDATE m_RCardCutM_t SET ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"

            Else
                strSQL = "UPDATE m_RCardCutDOldVer_t SET REMARK=N'" & editValue & "'" & _
                ",USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=GETDATE()  " & strWhere

                strSQL &= Chr(13) + Chr(10) + " UPDATE m_CutCardMOldVer_t SET USERID='" & VbCommClass.VbCommClass.UseId & "',ModifyTime=GETDATE() WHERE PartID='" & runCardId & "'"
            End If
        End If
        GetBodyUpdateSQL = strSQL
    End Function

    Public Shared Function GetSaveRejectStatusSQL(isOldVer As Boolean, partID As String) As String
        Dim strSQL As String = "UPDATE {0} SET STATUS=0 WHERE PartID='" & partID & "'" &
                                RCardComBusiness.GetFatoryProfitcenter

        If isOldVer = False Then
            strSQL = String.Format(strSQL, "m_RCardCutM_t")
        Else
            strSQL = String.Format(strSQL, "m_CutCardMOldVer_t")
        End If
        GetSaveRejectStatusSQL = strSQL
    End Function

    ''' <summary>
    ''' 需要支持多版本的
    ''' </summary>
    ''' <param name="partID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetSaveOldRejectStatusSQL(partID As String, strVerson As String) As String
        Dim strSQL As String = "UPDATE {0} SET STATUS=0 WHERE PartID='" & partID & "' and DrawingVer='" & strVerson & "'" &
                                RCardComBusiness.GetFatoryProfitcenter

        strSQL = String.Format(strSQL, "m_CutCardMOldVer_t")

        GetSaveOldRejectStatusSQL = strSQL
    End Function

    Public Shared Function GetRejectStatusDeleteLogSQL(partID As String, ByVal strVersion As String) As String
        'Mark by cq 20190523
        'Dim strSQL As String = " DELETE  FROM m_CutCardDCheckItemLog_t  " & _
        '                       " WHERE PartID='" & partID & "' AND version ='" & strVersion & "'" & _
        'RCardComBusiness.GetFatoryProfitcenter()

        'GetRejectStatusDeleteLogSQL = strSQL
        Return String.Empty
    End Function

    Public Shared Function GetBodyConfirmSQL(isOldVer As Boolean, partID As String) As String
        Dim strBodyVersion As String = String.Empty
        'cq 20160418, not update userid, modifytime=getdate() 20161124
        Dim strSQL As String = " UPDATE {0} set Status=2,remark=null WHERE PartID='" & partID & "'" &
                                RCardComBusiness.GetFatoryProfitcenter

        If isOldVer = False Then
            strSQL = String.Format(strSQL, "m_RCardCutM_t")
        Else
            strSQL = String.Format(strSQL, "m_CutCardMOldVer_t")
        End If

        If isOldVer = False AndAlso (IsSameVersion(partID, strBodyVersion) = False) Then
            strSQL = strSQL + " UPDATE m_RCardCutD_t SET DrawingVer = '" & strBodyVersion & "' WHERE PARTID = '" & partID & "'" & _
                               RCardComBusiness.GetFatoryProfitcenter()
        End If

        GetBodyConfirmSQL = strSQL
    End Function

    ''' <summary>
    ''' 直接对旧裁线卡确认并更新为已完成
    ''' </summary>
    ''' <param name="partID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetOldCutBodyConfirmSQL(partID As String, strVersion As String) As String
        Dim strBodyVersion As String = String.Empty
        'cq 20160418, not update userid, modifytime=getdate() 20161124
        Dim strSQL As String = " UPDATE {0} set Status=1,remark=null WHERE PartID='" & partID & "' and DrawingVer='" & strVersion & "'" &
                                RCardComBusiness.GetFatoryProfitcenter


        strSQL = String.Format(strSQL, "m_CutCardMOldVer_t")


        GetOldCutBodyConfirmSQL = strSQL
    End Function


    Private Shared Function IsSameVersion(ByVal partid As String, ByRef strBodyVersion As String) As Boolean
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT  m.DrawingVer,d.DrawingVer  FROM m_RCardCutM_t m " & _
                " LEFT JOIN m_RCardCutD_t d ON  m.PartID = d.PartID" & _
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

    Public Shared Function IsOldCutCardVersion(ByVal PN As String, ByVal strCutCardVersion As String) As Boolean
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT TOP 1 1  FROM m_RCardCutM_t WHERE PARTID ='" & PN & "' AND DrawingVer='" & strCutCardVersion & "'"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsOldCutCardVersion = False
            Else
                IsOldCutCardVersion = True
            End If
        End Using
        Return IsOldCutCardVersion
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
        lsSQL = " SELECT ISNULL(Detail.FinishSize, header.FinishSize) as FinishSize from m_RCardD_t Detail " & _
                " LEFT JOIN m_RCardM_t Header ON  detail.partid = header.partid " & _
                " WHERE  detail.partid ='" & parPartID & "' and detail.StationID='" & parStationID & "'"
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

    ''保存ERP下载数据
    'Public Shared Function SaveErpData(dt As DataTable) As Boolean
    '    Dim tavcPart As String = String.Empty
    '    Dim pavcPart As String = String.Empty
    '    Dim Version As String = String.Empty
    '    Dim ParentFormat As String = String.Empty
    '    Dim ChildFormat As String = String.Empty
    '    Dim ParentDes As String = String.Empty
    '    Dim ChildDes As String = String.Empty
    '    Dim EffectiveDate As String = String.Empty
    '    Dim ExpirationDate As Object = String.Empty
    '    Dim EXTENSIABLE As String = String.Empty
    '    Dim Qty As String = String.Empty
    '    Dim strCustID As String = "", strSeriesID As String = ""
    '    Dim pavcPartList As ArrayList = New ArrayList
    '    Dim insertSql As New System.Text.StringBuilder
    '    Dim o_strExecuteSQLResult As String = ""
    '    Dim strInsertSQL As String = ""

    '    'Add by cq 20160606
    '    insertSql.Append("DELETE FROM m_PartContrast_t WHERE PAVCPART = '" & dt.Rows(0)(BomInfo.ParentPartId.ToString) & "' AND isnull([TYPE],'R')='R' ")

    '    'Dim strInsertSQL As String =
    '    '    "INSERT INTO dbo.m_PartContrast_t " &
    '    '        "(TAvcPart ,PAvcPart ,UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
    '    '         "Extensible ,EffectiveDate ,ExpirationDate ,VERSION ,TYPE,CusID, SeriesID)"
    '    Dim strUpdateSQL As String = " UPDATE dbo.m_PartContrast_t "
    '    '子料号
    '    For iCnt As Integer = 0 To dt.Rows.Count - 1

    '        tavcPart = dt.Rows(iCnt)(BomInfo.ChildPartId.ToString).ToString
    '        pavcPart = dt.Rows(iCnt)(BomInfo.ParentPartId.ToString).ToString
    '        Version = dt.Rows(iCnt)(BomInfo.Version.ToString).ToString
    '        ParentFormat = dt.Rows(iCnt)(BomInfo.ParentFormat.ToString).ToString
    '        ChildFormat = dt.Rows(iCnt)(BomInfo.ChildFormat.ToString).ToString
    '        ParentDes = dt.Rows(iCnt)(BomInfo.ParentDescription.ToString).ToString
    '        ChildDes = dt.Rows(iCnt)(BomInfo.ChildDescription.ToString).ToString
    '        EffectiveDate = dt.Rows(iCnt)(BomInfo.EffectiveDate.ToString).ToString

    '        If IsDBNull(dt.Rows(iCnt)(BomInfo.ExpirationDate.ToString)) Then 'Modify by CQ 20151208
    '            ExpirationDate = DBNull.Value
    '            strInsertSQL =
    '                "INSERT INTO dbo.m_PartContrast_t " &
    '                    "(TAvcPart ,PAvcPart ,UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
    '                     "Extensible ,EffectiveDate ,VERSION ,TYPE,CusID, SeriesID, Factory)"
    '        Else
    '            ExpirationDate = dt.Rows(iCnt)(BomInfo.ExpirationDate.ToString)
    '            strInsertSQL =
    '                "INSERT INTO dbo.m_PartContrast_t " &
    '                    "(TAvcPart ,PAvcPart ,UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
    '                     "Extensible ,EffectiveDate ,ExpirationDate ,VERSION ,TYPE,CusID, SeriesID,Factory)"
    '        End If

    '        EXTENSIABLE = dt.Rows(iCnt)(BomInfo.Extensible.ToString).ToString
    '        Qty = dt.Rows(iCnt)(BomInfo.Qty.ToString).ToString
    '        strCustID = dt.Rows(iCnt)(BomInfo.CustID.ToString).ToString
    '        strSeriesID = dt.Rows(iCnt)(BomInfo.SeriesID.ToString).ToString

    '        '料件修改 20151108 Daniel
    '        If (pavcPartList.Contains(pavcPart)) = False Then
    '            pavcPartList.Add(pavcPart)
    '            '父料号
    '            insertSql.AppendFormat("IF EXISTS (SELECT 1 FROM m_PartContrast_t WHERE TAvcPart = '{0}' and PAvcPart = '{1}' and Factory='{2}')", pavcPart, pavcPart, VbCommClass.VbCommClass.Factory)
    '            insertSql.Append(strUpdateSQL)
    '            insertSql.AppendFormat(" SET PAvcPart = N'{0}',", pavcPart)
    '            insertSql.AppendFormat(" Userid = N'{0}',", userID)
    '            insertSql.AppendFormat(" Intime = getdate(),")
    '            insertSql.AppendFormat(" TypeDest = N'{0}',", TransferDBSpecChar(ParentDes))
    '            insertSql.AppendFormat(" DESCRIPTION = N'{0}',", TransferDBSpecChar(ParentFormat))
    '            insertSql.AppendFormat(" CusID = N'{0}', ", strCustID)
    '            insertSql.AppendFormat(" SeriesID = N'{0}'", strSeriesID)
    '            insertSql.AppendFormat(" WHERE TAvcPart ='{0}'", pavcPart)
    '            insertSql.AppendFormat(" AND PAvcPart = '{0}'", pavcPart)
    '            insertSql.AppendFormat(" AND Factory = '{0}'", pavcPart)
    '            insertSql.Append(" ELSE ")
    '            insertSql.Append(strInsertSQL)
    '            insertSql.Append(" VALUES(")
    '            insertSql.AppendFormat("N'{0}',", pavcPart)
    '            insertSql.AppendFormat("N'{0}',", pavcPart)
    '            insertSql.AppendFormat("N'Y',")
    '            insertSql.AppendFormat("N'{0}',", userID)
    '            insertSql.AppendFormat("getdate(),")
    '            insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ParentDes))
    '            insertSql.AppendFormat("N'{0}',", Qty)
    '            insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ParentFormat))
    '            insertSql.AppendFormat("'{0}',", "Y")
    '            insertSql.AppendFormat("{0},", "NULL")
    '            If Not IsDBNull(ExpirationDate) Then
    '                insertSql.AppendFormat("{0},", "NULL")
    '            End If
    '            insertSql.AppendFormat("N'{0}',", "")
    '            insertSql.AppendFormat("N'{0}',", "R")
    '            insertSql.AppendFormat("N'{0}',", strCustID)
    '            insertSql.AppendFormat("N'{0}',", strSeriesID) 'EffectiveDate ,ExpirationDate ,VERSION ,TYPE,CusID, SeriesID
    '            insertSql.AppendFormat("N'{0}'", strSeriesID)
    '            insertSql.Append(");")
    '        End If
    '        insertSql.AppendFormat("IF EXISTS (SELECT 1 from m_PartContrast_t WHERE TAvcPart = '{0}' and PAvcPart = '{1}' and Factory='{2}')", tavcPart, pavcPart, VbCommClass.VbCommClass.Factory)
    '        insertSql.Append(strUpdateSQL)
    '        insertSql.AppendFormat(" SET PAvcPart = N'{0}',", pavcPart)
    '        insertSql.AppendFormat("UseY = 'Y',")
    '        insertSql.AppendFormat("Userid = N'{0}',", userID)
    '        insertSql.AppendFormat("Intime = getdate(),")
    '        insertSql.AppendFormat("TypeDest = N'{0}',", TransferDBSpecChar(ChildDes))
    '        insertSql.AppendFormat("AmountQty = '{0}',", Qty)
    '        insertSql.AppendFormat("DESCRIPTION = N'{0}',", TransferDBSpecChar(ChildFormat))
    '        insertSql.AppendFormat("Extensible = N'{0}',", EXTENSIABLE)
    '        insertSql.AppendFormat("EffectiveDate = N'{0}',", EffectiveDate)
    '        If IsDBNull(ExpirationDate) Then  'Modify by CQ 20151208
    '            insertSql.AppendFormat("ExpirationDate = NULL,")
    '        Else
    '            insertSql.AppendFormat("ExpirationDate = '{0}',", ExpirationDate)
    '        End If
    '        ' insertSql.AppendFormat("ExpirationDate = N'{0}',", ExpirationDate)
    '        insertSql.AppendFormat("VERSION = N'{0}',", Version)
    '        insertSql.AppendFormat(" CusID = N'{0}', ", strCustID)
    '        insertSql.AppendFormat(" SeriesID = N'{0}',", strSeriesID)
    '        insertSql.AppendFormat("TYPE = N'{0}'", "R")
    '        insertSql.AppendFormat("WHERE TAvcPart ='{0}'", tavcPart)
    '        insertSql.AppendFormat("AND PAvcPart = '{0}'", pavcPart)
    '        insertSql.AppendFormat("AND Factory = '{0}'", VbCommClass.VbCommClass.Factory)
    '        insertSql.Append(" ELSE ")
    '        insertSql.Append(strInsertSQL)
    '        insertSql.Append(" VALUES(")
    '        insertSql.AppendFormat("N'{0}',", tavcPart)
    '        insertSql.AppendFormat("N'{0}',", pavcPart)
    '        insertSql.AppendFormat("N'Y',")
    '        insertSql.AppendFormat("N'{0}',", userID)
    '        insertSql.AppendFormat("getdate(),")
    '        insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildDes))
    '        insertSql.AppendFormat("N'{0}',", Qty)
    '        insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildFormat))
    '        insertSql.AppendFormat("N'{0}',", EXTENSIABLE)  'cq20160618  N ==> EXTENSIABLE
    '        insertSql.AppendFormat("N'{0}',", EffectiveDate)
    '        If Not IsDBNull(ExpirationDate) Then  'cq 20160614
    '            insertSql.AppendFormat("'{0}',", ExpirationDate)
    '        End If
    '        insertSql.AppendFormat("N'{0}',", Version)
    '        insertSql.AppendFormat("N'{0}',", "R")
    '        insertSql.AppendFormat("N'{0}',", strCustID)
    '        insertSql.AppendFormat("N'{0}',", strSeriesID)
    '        insertSql.AppendFormat("N'{0}'", VbCommClass.VbCommClass.Factory)
    '        insertSql.Append(");")
    '    Next
    '    '保存数据，有事务处理
    '    o_strExecuteSQLResult = DbOperateUtils.ExecSQL(insertSql.ToString)
    '    If Not String.IsNullOrEmpty(o_strExecuteSQLResult) Then
    '        Return False
    '    End If
    '    Return True
    'End Function


    'Public Shared Function SaveErpSetPNData(dt As DataTable) As Boolean
    '    Dim tavcPart As String = String.Empty
    '    Dim pavcPart As String = String.Empty
    '    Dim Version As String = String.Empty
    '    Dim ParentFormat As String = String.Empty
    '    Dim ChildFormat As String = String.Empty
    '    Dim ParentDes As String = String.Empty
    '    Dim ChildDes As String = String.Empty
    '    Dim EffectiveDate As String = String.Empty
    '    Dim ExpirationDate As Object = String.Empty
    '    Dim EXTENSIABLE As String = String.Empty
    '    Dim Qty As String = String.Empty
    '    Dim strCustID As String = "", strSeriesID As String = ""
    '    Dim pavcPartList As ArrayList = New ArrayList
    '    Dim insertSql As New System.Text.StringBuilder
    '    Dim o_strExecuteSQLResult As String = ""
    '    Dim strInsertSQL As String = ""

    '    'mark cq 20160824, AND (Amountqty is null or Amountqty<=0)
    '    insertSql.Append("DELETE FROM m_PartContrast_t WHERE ")
    '    insertSql.Append(" PAVCPART  = '" & dt.Rows(0)(BomInfo.ParentPartId.ToString).ToString & "' AND Tavcpart LIKE '9%'")
    '    insertSql.Append(" AND TAvcPart <> PAvcPart ")

    '    '子料号
    '    For iCnt As Integer = 0 To dt.Rows.Count - 1
    '        tavcPart = dt.Rows(iCnt)(BomInfo.ChildPartId.ToString).ToString
    '        pavcPart = dt.Rows(iCnt)(BomInfo.ParentPartId.ToString).ToString
    '        Version = dt.Rows(iCnt)(BomInfo.Version.ToString).ToString
    '        ParentFormat = dt.Rows(iCnt)(BomInfo.ParentFormat.ToString).ToString
    '        ChildFormat = dt.Rows(iCnt)(BomInfo.ChildFormat.ToString).ToString
    '        ParentDes = dt.Rows(iCnt)(BomInfo.ParentDescription.ToString).ToString
    '        ChildDes = dt.Rows(iCnt)(BomInfo.ChildDescription.ToString).ToString
    '        EffectiveDate = dt.Rows(iCnt)(BomInfo.EffectiveDate.ToString).ToString

    '        If IsDBNull(dt.Rows(iCnt)(BomInfo.ExpirationDate.ToString)) Then 'Modify by CQ 20151208
    '            ExpirationDate = DBNull.Value
    '            strInsertSQL =
    '                "INSERT INTO dbo.m_PartContrast_t " &
    '                    "(TAvcPart ,PAvcPart ,UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
    '                     "Extensible ,EffectiveDate ,VERSION ,TYPE,CusID, SeriesID,Factory)"
    '        Else
    '            ExpirationDate = dt.Rows(iCnt)(BomInfo.ExpirationDate.ToString)
    '            strInsertSQL =
    '                "INSERT INTO dbo.m_PartContrast_t " &
    '                    "(TAvcPart ,PAvcPart ,UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
    '                     "Extensible ,EffectiveDate ,ExpirationDate ,VERSION ,TYPE,CusID, SeriesID,Factory)"
    '        End If

    '        EXTENSIABLE = dt.Rows(iCnt)(BomInfo.Extensible.ToString).ToString
    '        Qty = dt.Rows(iCnt)(BomInfo.Qty.ToString).ToString
    '        strCustID = dt.Rows(iCnt)(BomInfo.CustID.ToString).ToString
    '        strSeriesID = dt.Rows(iCnt)(BomInfo.SeriesID.ToString).ToString

    '        insertSql.AppendFormat("IF NOT EXISTS (SELECT 1 from m_PartContrast_t where TAvcPart = '{0}' and PAvcPart = '{1}' and Factory='{2}')", tavcPart, pavcPart,VbCommClass.VbCommClass.Factory)
    '        insertSql.Append(strInsertSQL)
    '        insertSql.Append(" VALUES(")
    '        insertSql.AppendFormat("N'{0}',", tavcPart)
    '        insertSql.AppendFormat("N'{0}',", pavcPart)
    '        insertSql.AppendFormat("N'Y',")
    '        insertSql.AppendFormat("N'{0}',", userID)
    '        insertSql.AppendFormat("getdate(),")
    '        insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildDes))
    '        insertSql.AppendFormat("N'{0}',", Qty)
    '        insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildFormat))
    '        insertSql.AppendFormat("N'{0}',", EXTENSIABLE)  'cq20160618  N ==> EXTENSIABLE
    '        insertSql.AppendFormat("N'{0}',", EffectiveDate)
    '        If Not IsDBNull(ExpirationDate) Then  'cq 20160614
    '            insertSql.AppendFormat("'{0}',", ExpirationDate)
    '        End If
    '        insertSql.AppendFormat("N'{0}',", Version)
    '        insertSql.AppendFormat("N'{0}',", "R")
    '        insertSql.AppendFormat("N'{0}',", strCustID)
    '        insertSql.AppendFormat("N'{0}',", strSeriesID)
    '        insertSql.AppendFormat("N'{0}'", VbCommClass.VbCommClass.Factory)
    '        insertSql.Append(");")
    '    Next
    '    '保存数据，有事务处理
    '    o_strExecuteSQLResult = DbOperateUtils.ExecSQL(insertSql.ToString)
    '    If Not String.IsNullOrEmpty(o_strExecuteSQLResult) Then
    '        Return False
    '    End If
    '    Return True
    'End Function

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

#Region "检查TIPTOP或者SAP的版本"

    Public Shared Function GetVerFromTiptop(partNumber As String) As String
        Dim returnValue As String
        Dim o_ds As New DataSet
        Try
            Dim StrSql As String = "SELECT NVL(IMA021,IMA02)  FROM " & VbCommClass.VbCommClass.Factory & ".IMA_FILE WHERE IMA01='" & partNumber & "'"

            o_ds = DBUtility.DbOracleHelperSQL.Query(StrSql)

            If Not IsNothing(o_ds) AndAlso o_ds.Tables.Count > 0 Then
                returnValue = o_ds.Tables(0).Rows(0).Item(0).ToString()
            Else
                returnValue = ""
            End If

            'Modify by cq20170930
            ' returnValue = RCardComBusiness.ExecuteScalarOracle(StrSql).ToString()

            If returnValue <> "" Then
                Dim index As Integer = returnValue.LastIndexOf("-")
                If index >= 0 Then
                    returnValue = returnValue.Substring(index + 1, returnValue.Length - index - 1)
                Else
                    returnValue = ""
                End If
            End If
            Return returnValue
        Catch ex As Exception
            Throw ex
        Finally
            o_ds = Nothing
        End Try
    End Function

    Public Shared Function GetVerFromErp(partNumber As String) As String
        Dim o_strErpVer As String
        If VbCommClass.VbCommClass.IsConSap = "Y" Then
            o_strErpVer = SapCommon.GetVerFromTiptopSap(partNumber).ToUpper
        Else
            o_strErpVer = SapCommon.GetVerFromTiptop(partNumber).ToUpper
        End If
        Return o_strErpVer
    End Function

    Public Shared Function CutCardExistInOldData(ByVal partNumber As String, ByVal strVersion As String) As Boolean
        Dim StrSql As String = "SELECT TOP 1 1  FROM  m_RCardCutMOldver_t WHERE PARTID='" & partNumber & "' AND DrawingVer='" & strVersion & "' "
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(StrSql)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                CutCardExistInOldData = True
            Else
                CutCardExistInOldData = False
            End If

        End Using
        Return CutCardExistInOldData
    End Function
#End Region

#Region "裁线卡拷贝"

    Public Shared Sub udpCopyCutCard(paramsList As ArrayList)
        Dim strSQL As String
        '"--declare @NewPN nvarchar(20) " &
        '"--declare @OldPN nvarchar(20) " &
        '"--declare @NewPNVersion nvarchar(20) " &
        '"--declare @UserID nvarchar(20) " &
        '"--set @NewPN ='test' " &
        '"--set @OldPN = '904091719' " &
        '"--set @NewPNVersion = 'VD' " &
        '"--set @UserID = 'L0421481' " &
        strSQL =
            "INSERT INTO m_RCardCutM_t(PartID,DrawingVer,Shape,DrawingFilePath,FinishSize,UserID,Status,InTime,Factoryid,Profitcenter,StdLabors)    " &
            "SELECT @NewPN,@NewPNVersion,Shape,DrawingFilePath,FinishSize,@UserID,0,GETDATE() ,Factoryid,Profitcenter,StdLabors " &
            "FROM  m_RCardCutM_t(NOLOCK) WHERE PartID=@OldPN   " &
            "INSERT INTO m_RCardCutD_t(PartID,StationID,DrawingVer,StationSQ,WorkingHours,Equipment,ProcessStandard,Remark, " &
            "        UserID,Status,InTime,Shape,NewProcessStandard,Factoryid,Profitcenter)  " &
            "SELECT @NewPN,StationID,@NewPNVersion,StationSQ ,WorkingHours,Equipment,ProcessStandard,Remark, " &
            "       @UserID,Status,GETDATE(),Shape, NewProcessStandard,Factoryid,Profitcenter " &
            "FROM m_RCardCutD_t(NOLOCK) WHERE PartID =@OldPN   "

        DbOperateUtils.ExecSQL(strSQL, paramsList)
    End Sub

#End Region

#Region "裁线卡编辑"


    Public Shared Function GetCutCardEditSQLOfValue(ByVal PartNumber As String, ByVal strVersion As String, ByVal strFactoryid As String, ByVal strProfitcenter As String) As String
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
        ' " insert m_CutCardMOldVer_t " &
        '" select * from m_RCardM_t  " &
        '    insert m_CutCardMOldVer_t (PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize,  status ,Factoryid,Profitcenter,userid,intime,modifytime)
        ' select PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize, '1' as status ,Factoryid,Profitcenter,userid,intime,modifytime from m_RCardM_t  

        strSQL =
        " IF EXISTS(SELECT TOP 1 1 FROM m_CutCardMOldVer_t  " &
        "          WHERE PARTID= '" & PartNumber & "' AND DRAWINGVER='" & strVersion & "'  " &
        "          and Factoryid = '" & strFactoryid & "' and Profitcenter = '" & strProfitcenter & "' ) " &
        " begin " &
        "    DELETE m_CutCardDPartOldVer_t " &
        "    from m_CutCardDPartOldVer_t RCDP INNER JOIN m_CutCardMOldVer_t RCM " &
        "    on RCDP.PartID = RCM.PartID and RCDP.DrawingVer = RCM.DrawingVer " &
        "    where RCM.PARTID= @PartID AND RCM.DRAWINGVER=@Version  " &
        "    and RCM.Factoryid = @Factoryid and RCM.Profitcenter = @Profitcenter " &
        "    DELETE m_CutCardDOldVer_t " &
        "    FROM m_CutCardDOldVer_t RCD INNER JOIN m_CutCardMOldVer_t RCM " &
        "    on RCD.PartID = RCM.PartID and RCD.DrawingVer = RCM.DrawingVer" &
        "    where RCM.PARTID= @PartID AND RCM.DRAWINGVER=@Version  " &
        "    and RCM.Factoryid = @Factoryid and RCM.Profitcenter = @Profitcenter " &
        "    DELETE m_CutCardMOldVer_t where PARTID = @PartID AND DRAWINGVER=@Version  " &
        "    and Factoryid = @Factoryid and Profitcenter = @Profitcenter " &
        " end " & _
        " INSERT m_CutCardDOldVer_t (PartID,StationID,DrawingVer,StationSQ,WorkingHours,Equipment,ProcessStandard,Remark,Status," & _
        " Shape, NewProcessStandard, VariableName1, VariableValue1, VariableName2, VariableValue2, factoryID, profitCenter " & _
        " ,UserID,InTime,FinishSize,ProcessStandardPrint,LeftProcessStandard,RightProcessStandard,LCLValue,LeftTVPN,RightTVPN,WirePN) " &
        " select RCD.* from m_RCardCutD_t RCD  " &
        " inner join m_RCardCutM_t RCM " &
        " on RCD.PartID = RCM.PartID   " &
        " where RCM.PARTID= '" & PartNumber & "' AND RCM.DRAWINGVER='" & strVersion & "'  " &
        " and RCM.Factoryid = '" & strFactoryid & "' and RCM.Profitcenter = '" & strProfitcenter & "' " &
        " insert m_CutCardDPartOldVer_t " &
        "  select RCDP.* from m_RCardCutM_t RCM " &
        " INNER JOIN m_CutCardDPart_t RCDP " &
        "  on RCDP.PartID = RCM.PartID   " &
        "  where RCM.PARTID='" & PartNumber & "'  AND RCM.DRAWINGVER='" & strVersion & "'  " &
        "  and RCM.Factoryid = '" & strFactoryid & "'  and RCM.Profitcenter ='" & strProfitcenter & "'  " & _
        " INSERT m_CutCardMOldVer_t (PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize,  status ,Factoryid,Profitcenter,userid,intime,modifytime,StdLabors)" & _
        " SELECT PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize, '1' as status ,Factoryid,Profitcenter,userid,intime,modifytime,StdLabors FROM m_RCardCutM_t  " & _
        " WHERE PARTID= '" & PartNumber & "' AND DRAWINGVER='" & strVersion & "'  " &
        " and Factoryid =  '" & strFactoryid & "' and Profitcenter = '" & strProfitcenter & "'  "

        Return strSQL
    End Function

    Public Shared Function GetCutCardEditSQL() As String
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
        ' " insert m_CutCardMOldVer_t " &
        '" select * from m_RCardM_t  " &
        '    insert m_CutCardMOldVer_t (PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize,  status ,Factoryid,Profitcenter,userid,intime,modifytime)
        ' select PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize, '1' as status ,Factoryid,Profitcenter,userid,intime,modifytime from m_RCardM_t  

        strSQL =
        " IF EXISTS(SELECT TOP 1 1 FROM m_CutCardMOldVer_t  " &
        "          WHERE PARTID= @PartID AND DRAWINGVER=@Version  " &
        "          and Factoryid = @Factoryid and Profitcenter = @Profitcenter ) " &
        " begin " &
        "    DELETE m_CutCardDPartOldVer_t " &
        "    from m_CutCardDPartOldVer_t RCDP INNER JOIN m_CutCardMOldVer_t RCM " &
        "    on RCDP.PartID = RCM.PartID and RCDP.DrawingVer = RCM.DrawingVer " &
        "    where RCM.PARTID= @PartID AND RCM.DRAWINGVER=@Version  " &
        "    and RCM.Factoryid = @Factoryid and RCM.Profitcenter = @Profitcenter " &
        "    DELETE m_CutCardDOldVer_t " &
        "    FROM m_CutCardDOldVer_t RCD INNER JOIN m_CutCardMOldVer_t RCM " &
        "    on RCD.PartID = RCM.PartID and RCD.DrawingVer = RCM.DrawingVer" &
        "    where RCM.PARTID= @PartID AND RCM.DRAWINGVER=@Version  " &
        "    and RCM.Factoryid = @Factoryid and RCM.Profitcenter = @Profitcenter " &
        "    DELETE m_CutCardMOldVer_t where PARTID = @PartID AND DRAWINGVER=@Version  " &
        "    and Factoryid = @Factoryid and Profitcenter = @Profitcenter " &
        " end " & _
        " INSERT m_CutCardMOldVer_t (PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize,  status ,Factoryid,Profitcenter,userid,intime,modifytime,StdLabors)" & _
        " SELECT PartID, drawingver, shape,DrawingFilePath, Remark ,finishsize, '1' as status ,Factoryid,Profitcenter,userid,intime,modifytime,StdLabors FROM m_RCardCutM_t  " & _
        " WHERE PARTID= @PartID AND DRAWINGVER=@Version  " &
        " and Factoryid = @Factoryid and Profitcenter = @Profitcenter  " &
        " INSERT m_CutCardDOldVer_t " &
        " select RCD.* from m_RCardCutD_t RCD  " &
        " inner join m_RCardCutM_t RCM " &
        " on RCD.PartID = RCM.PartID   " &
        " where RCM.PARTID= @PartID AND RCM.DRAWINGVER=@Version  " &
        " and RCM.Factoryid = @Factoryid and RCM.Profitcenter = @Profitcenter " &
        " insert m_CutCardDPartOldVer_t " &
        " select RCDP.* from m_RCardCutM_t RCM " &
        " INNER JOIN m_CutCardDPart_t RCDP " &
        " on RCDP.PartID = RCM.PartID   " &
        " where RCM.PARTID= @PartID AND RCM.DRAWINGVER=@Version  " &
        " and RCM.Factoryid = @Factoryid and RCM.Profitcenter = @Profitcenter; "

        Return strSQL
    End Function

    Public Shared Function GetSaveOldBOMSQL(ByVal PartID As String, ByVal Version As String,
                                            ByVal Factoryid As String, ByVal Profitcenter As String) As String
        Dim strSQL As New StringBuilder
        ' strSQL =
        '" IF NOT EXISTS(SELECT TOP 1 1 FROM m_PartContrastOldVer_t   WHERE PAvcPart= '" & PartID & "' AND VERSION='" & Version & "') " & _


        strSQL.Append(" IF NOT EXISTS(SELECT TOP 1 1 FROM m_PartContrastOldVer_t   WHERE PAvcPart= '" & PartID & "' AND VERSION='" & Version & "') ")
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
        Return strSQL.ToString

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="parParentPartID"></param>
    ''' <param name="parChildPN"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAmountQtyFromTT(ByVal parParentPartID As String, ByVal parChildPN As String) As Integer
        Dim lsSQL As String = ""
        GetAmountQtyFromTT = 1
        Try
            lsSQL = " SELECT BMB06 FROM  " & VbCommClass.VbCommClass.Factory & ".BMB_FILE " & _
                    " WHERE BMB01='" & parParentPartID & "' AND BMB03 ='" & parChildPN & "'  ORDER BY BMB02 DESC "
            ' Dim dt As DataTable = MoComDB.GetErpData(lsSQL)
            Dim o_ds As DataSet = DBUtility.DbOracleHelperSQL.Query(lsSQL)
            If Not IsNothing(o_ds.Tables(0)) AndAlso o_ds.Tables(0).Rows.Count > 0 Then
                GetAmountQtyFromTT = o_ds.Tables(0).Rows(0).Item(0)
            Else
                GetAmountQtyFromTT = 1
            End If
            Return GetAmountQtyFromTT
        Catch ex As Exception
        End Try
    End Function

    Public Shared Function GetAmountQtyFromMES(ByVal parChildPartID As String, ByVal parChildMO As String) As Integer
        Dim lsSQL As String = ""
        GetAmountQtyFromMES = 1
        Try
            lsSQL = " SELECT part.AmountQty" & _
                    " FROM m_PartContrast_t  part " & _
                   " left join m_Mainmo_t PMO on part.PAvcPart = PMO.PartID " & _
                   " Left join m_Mainmo_t CMO on part.TAvcPart = cmo.PartID" & _
                   " where TAvcPart ='" & parChildPartID & "' " & _
                   " and pmo.ParentMo= cmo.ParentMo" & _
                   " and part.TAvcPart <> part.PAvcPart" & _
                  " and cmo.Moid = '" & parChildMO & " '"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetAmountQtyFromMES = dt.Rows(0).Item(0)
            Else
                GetAmountQtyFromMES = 1
            End If
            Return GetAmountQtyFromMES
        Catch ex As Exception
        End Try
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

End Class
