Imports System.Data.SqlClient

Public Class ScanBusiness


    ''' <summary>
    ''' 取得工单信息
    ''' </summary>
    ''' <param name="mo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMoInfo(ByVal mo As String) As DataTable
        Dim dt As DataTable

        Try
            Dim sql As String = "SELECT Moid,Moqty,PartID FROM m_Mainmo_t WHERE Moid='" & mo & "'"

            dt = RCardComBusiness.GetDataTable(sql)
        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    ''' <summary>
    ''' 取得扫描任务
    ''' </summary>
    ''' <param name="functionCodeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ShowScanTask(ByVal functionCodeId As Integer) As DataTable

        Dim dt As DataTable
        Try
            Dim StrSql As String = "select Item,Title from m_RCARDScanTask_t(nolock) where FunctionCodeID=" & functionCodeId & " and IsPrompt=0 "

            dt = RCardComBusiness.GetDataTable(StrSql)

        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Shared Function GetStationNameById(partId As String, ByVal stationId As String) As DataTable
        Dim dt As DataTable

        Try
            Dim StrSql As String = "SELECT STATIONSQ ,B.Stationid,C.STATIONNAME,C.SkillCode,C.ReportTypeCode " &
                                   "FROM m_RCardM_t A,m_RCardD_t B,m_Rstation_t C WHERE A.PARTID=B.PARTID AND B.Stationid=C.Stationid" &
                                    RCardComBusiness.GetWhereAnd("A.PARTID", partId) &
                                    RCardComBusiness.GetWhereAnd("B.Stationid", stationId) &
                                    RCardComBusiness.GetFatoryProfitcenter("A")

            dt = RCardComBusiness.GetDataTable(StrSql)
        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Shared Function GetUserNameById(userId As String) As DataTable
        Dim dt As DataTable
        Try
            Dim StrSql As String = "select top 1 UserName from m_Users_t(nolock) where UserID='" & userId & "'"

            dt = RCardComBusiness.GetDataTable(StrSql)
        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Shared Function GetUser(ByVal inputString As String) As DataTable
        Dim dt As DataTable
        Try
            Dim sql As String = "SELECT USERNAME FROM M_USERS_T WHERE USERID='" & inputString & "' AND ISNULL(GroupID,'NA')<>'IPQC'"
            dt = RCardComBusiness.GetDataTable(sql)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="inputString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetIPQC(ByVal inputString As String) As DataTable
        Dim dt As DataTable = Nothing
        Try
            dt = RCardComBusiness.GetDataTable("SELECT USERNAME FROM M_USERS_T WHERE USERID='" & inputString & "' AND ISNULL(GroupID,'NA')='IPQC'")
        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Shared Function GetWorkOrder(wo As String) As DataTable
        Dim dt As DataTable

        Try
            Dim StrSql As String = "select top 1 PartID,Moqty from m_Mainmo_t(nolock) where Moid='" & wo & "'"

            dt = RCardComBusiness.GetDataTable(StrSql)
        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Shared Function GetFirst(serialNumber As String, partId As String, stationId As String) As DataTable
        Dim dt As DataTable

        Try
            Dim StrSql As String = "select top 1 1 from m_RCardLotFAI_t(nolock) where 1=1 " &
                                    RCardComBusiness.GetWhereAnd("SerialNumber", serialNumber) &
                                    RCardComBusiness.GetWhereAnd("PartID", partId) &
                                    RCardComBusiness.GetWhereAnd("Stationid", stationId) &
                                    RCardComBusiness.GetFatoryProfitcenter()
            dt = RCardComBusiness.GetDataTable(StrSql)
        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Shared Function GetScanData(ByVal userId As String) As DataSet

        Dim ds As DataSet
        Dim strSql As String
        Dim sqlSummary As String
        Try

            strSql = "select ROW_NUMBER() OVER(ORDER BY UN.INTIME DESC) 序号, UN.WorkOrder 工单,PN.TAvcPart 料件编号," &
                    "ST.StationName 工站,ISNULL(SP.QTY,UN.Qty) 生产数量,ISNULL(SP.USERID,UN.UserID) 工号,US.UserName 姓名 ,UN.InTime 扫描时间,'' 备注 " &
                    "from m_RCardLotUnit_t(nolock) UN " &
                    "left join m_RCardLotSplit_t SP ON UN.ID=SP.LotUnitID " &
                    "join m_PartContrast_t(nolock) PN on UN.PartID=PN.TAvcPart " &
                    "join m_Rstation_t(nolock) ST on UN.StationID=ST.StationID " &
                    "join m_Users_t(nolock) US on ISNULL(SP.USERID,UN.UserID)=US.UserID " &
                    "where  convert(nvarchar(50),UN.InTime,12)=convert(nvarchar(50),getdate(),12) " &
                     RCardComBusiness.GetWhereAnd("ISNULL(SP.USERID,UN.UserID)", userId) &
                     RCardComBusiness.GetFatoryProfitcenter("UN")
            sqlSummary = "select SUM(ISNULL(B.QTY,A.QTY)) TotalQty from m_RCardLotUnit_t(nolock) A left join m_RCardLotSplit_t B ON A.ID=B.LotUnitID  " &
                        "where convert(nvarchar(50),A.InTime,12)=convert(nvarchar(50),getdate(),12) " &
                        RCardComBusiness.GetWhereAnd("ISNULL(B.USERID,A.UserID)", userId) &
                        RCardComBusiness.GetFatoryProfitcenter("A")
            ds = RCardComBusiness.GetDataSet(strSql & vbNewLine & sqlSummary)

        Catch ex As Exception
            Throw
        End Try

        Return ds
    End Function

    Public Shared Function GetRunCard(ByVal wo As String) As DataSet
        Dim ds As DataSet
        Dim sqlHeader As String
        Dim sqlTail As String
        Try

            sqlHeader = "               SELECT A.DRAWINGNO," &
                        "                      A.DRAWINGVER," &
                        "                      A.SHAPE," &
                        "                      A.MOID," &
                        "                      A.MOQTY," &
                        "                      A.LINEID," &
                        "                      A.STATIONSQ," &
                        "                      A.STATIONNAME," &
                        "                      A.WORKINGHOURS," &
                        "                      A.EQUIPMENT," &
                        "                      LEFT(RAWINFO,LEN(RAWINFO)-3) RAWI," &
                        "                      A.PROCESSSTANDARD," &
                        "                      A.REMARK," &
                        "                      A.SHAPE," &
                        "                      A.OPERATORUSERNAME," &
                        "                      A.CONFIRMUSERNAME" &
                        "               FROM" &
                        "                 (SELECT A.*," &
                        "                    (SELECT distinct PARTD.DESCRIPTION+' || '" &
                        "                     FROM m_RCardDPart_t PARTDETAIL," &
                        "                          m_PartContrast_t PARTD " &
                        "                     WHERE A.Stationid=PARTDETAIL.Stationid" &
                        "                     AND PARTDETAIL.EWPartNumber=PARTD.TAvcPart" &
                        "                     AND PARTDETAIL.PartID = A.DrawingNo" &
                        "                     AND ISNULL(PARTD.TYPE,'R')='R'" &
                        "                     FOR XML PATH('')) AS RAWINFO" &
                        "                  FROM  (" &
                        "  SELECT PN.TAvcPart DrawingNo," &
                        "                            RC.DrawingVer," &
                        "                            RC.Shape," &
                        "                            wo.Moid," &
                        "                            wo.Moqty," &
                        "                            wo.Lineid," &
                        "                            RCD.STATIONSQ," &
                        "                            ST.STATIONNAME," &
                        "                            RCD.WORKINGHOURS," &
                        "                            RCD.EQUIPMENT," &
                        "                            RCD.PROCESSSTANDARD," &
                        "                            RCD.REMARK," &
                        "                            FAI.OPERATORUSERNAME," &
                        "                            FAI.CONFIRMUSERNAME," &
                        "                            RCD.STATIONID" &
                        "                     FROM m_Mainmo_t(NOLOCK) WO" &
                        "                     JOIN m_PartContrast_t(NOLOCK) PN ON WO.PARTID=PN.TAvcPart" &
                        "                     JOIN m_RCardM_t(NOLOCK) RC ON PN.TAvcPart=RC.PARTID" &
                        "                     JOIN m_RCardD_t(NOLOCK) RCD ON RC.PARTID=RCD.PARTID" &
                        "                     JOIN m_Rstation_t(NOLOCK) ST ON ST.STATIONID=RCD.STATIONID" &
                        "                     LEFT JOIN" &
                        "                       (SELECT DISTINCT A.STATIONID," &
                        "                                        C.USERNAME AS OPERATORUSERNAME ," &
                        "                                        A.CONFIRMUSERNAME" &
                        "                        FROM m_RCardLotFAI_t A" &
                        "                        LEFT JOIN m_RCardLotUnit_t B ON A.SERIALNUMBER=B.SERIALNUMBER" &
                        "                        AND A.WORKORDER=B.WORKORDER" &
                        "                        LEFT JOIN M_USERS_T C ON B.UserID=C.USERID" &
                        "                        WHERE A.WORKORDER='" & wo & "')FAI ON RCD.STATIONID=FAI.STATIONID" &
                        "                     WHERE WO.MOID='" & wo & "'" &
                        RCardComBusiness.GetFatoryProfitcenter("RC") &
                        " )A" &
                        " )A ORDER BY A.STATIONSQ;"

            sqlTail =
                "SELECT ST.SectionID," &
                "        CASE" &
                "            WHEN ST.SectionID='01' THEN sum(RCD.WorkingHours)" &
                "            WHEN ST.SectionID='02' THEN sum(RCD.WorkingHours)" &
                "            WHEN ST.SectionID='03' THEN sum(RCD.WorkingHours)" &
                "            WHEN ST.SectionID='04' THEN sum(RCD.WorkingHours)" &
                "            WHEN ST.SectionID='05' THEN sum(RCD.WorkingHours)" &
                "            WHEN ST.SectionID='A05' THEN sum(RCD.WorkingHours)" &
                "        END WorkingHours " &
                "FROM m_Mainmo_t(nolock) WO " &
                "JOIN m_PartContrast_t(nolock) PN ON WO.PARTID=PN.TAvcPart " &
                "JOIN m_RCardM_t(nolock) RC ON PN.TAvcPart=RC.PARTID " &
                "JOIN m_RCardD_t(nolock) RCD ON RC.PARTID=RCD.PARTID " &
                "JOIN m_Rstation_t(nolock) ST ON ST.STATIONID=RCD.STATIONID " &
                "WHERE Wo.Moid='" & wo & "' " &
                RCardComBusiness.GetFatoryProfitcenter("RC") &
                "GROUP BY ST.SectionID"

            ds = RCardComBusiness.GetDataSet(sqlHeader & sqlTail)

        Catch ex As Exception
            Throw
        End Try

        Return ds
    End Function

    Public Shared Function GetVersion(partId As String, wo As String) As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim sql As String =
                "SELECT 1 FROM m_RCardM_t A,m_Mainmo_t B WHERE  A.DRAWINGVER=B.VERSION " &
                RCardComBusiness.GetWhereAnd("A.PARTID", partId) &
                RCardComBusiness.GetWhereAnd("B.MOID", wo) &
                RCardComBusiness.GetFatoryProfitcenter("A")
            dt = RCardComBusiness.GetDataTable(sql)

        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Shared Function GetRouting(ByVal input As String) As DataTable
        Dim dt As DataTable = Nothing

        Try
            Dim strSQL = "SELECT TOP 1 SerialNumber FROM m_RCardLotUnit_t WHERE SerialNumber='" & input & "'" &
                         RCardComBusiness.GetFatoryProfitcenter()

            dt = RCardComBusiness.GetDataTable(strSQL)
        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Shared Function GetFaiIPQC(ByVal input As String) As DataTable
        Dim dt As DataTable = Nothing
        Try

            Dim sql As String = "SELECT TOP 1 A.IPQC,B.USERID FROM m_RCardLotFAI_t A LEFT JOIN m_RCardLotUnit_t B ON  A.SerialNumber=B.SerialNumber WHERE 1=1 " &
                                 RCardComBusiness.GetWhereAnd("A.SerialNumber", input) &
                                 RCardComBusiness.GetFatoryProfitcenter("A")

            dt = RCardComBusiness.GetDataTable(sql)

        Catch ex As Exception
            Throw
        End Try

        Return dt
    End Function

    Public Shared Function GetRunCardStatus(partId As String) As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim strSQL As String = "SELECT Status FROM m_RCardM_t WHERE PartID='" & partId & "' AND STATUS=1" &
                                    RCardComBusiness.GetFatoryProfitcenter()
            dt = RCardComBusiness.GetDataTable(strSQL)
        Catch ex As Exception
            Throw
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' 取得标准顺序
    ''' </summary>
    ''' <param name="partId"></param>
    ''' <param name="stationId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetStandard(partId As String, stationId As String) As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim sql As String =
                " SELECT REPLACE(REPLACE(B.PROCESSSTANDARD,CHAR(32),''),CHAR(13)+CHAR(10),'') PROCESSSTANDARD," &
                "        REPLACE(REPLACE(A.REMARK,CHAR(32),''),CHAR(13)+CHAR(10),'') REMARK," &
                "        B.STATIONSQ,REPLACE(REPLACE(D.DESCRIPTION,CHAR(32),''),CHAR(13)+CHAR(10),'') DESCRIPTION1 " &
                "FROM m_RCardM_t A " &
                "JOIN m_RCardD_t B ON A.PartID=B.PartID " &
                "LEFT JOIN m_RCardDPart_t C ON B.PartID = C.PartID and B.StationID = C.StationID " &
                "LEFT JOIN m_PartContrast_t D ON C.PARTID=D.TAvcPart " &
                "AND ISNULL(D.TYPE,'R')='R' " &
                "WHERE 1=1 " &
                RCardComBusiness.GetWhereAnd("A.PARTID", partId) &
                RCardComBusiness.GetWhereAnd("B.STATIONID", stationId) &
                RCardComBusiness.GetFatoryProfitcenter("A")

            dt = RCardComBusiness.GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Shared Function GetVerifyTask(partId As String, ByVal stationId As String) As DataTable
        Dim dt As DataTable = Nothing
        Try

            Dim sql As String =
                    "SELECT DISTINCT D.TAvcPart, " &
                    "       E.RemainCount,         " &
                    "       CASE  " &
                    "           WHEN E.RemainCount IS NULL THEN N'物料' " &
                    "           ELSE N'工装' " &
                    "       END TYPE  " &
                    "    FROM m_RCardM_t A " &
                    "    INNER JOIN m_RCardD_t B  " &
                    "          ON A.PartID = B.PartID  " &
                    "    INNER JOIN m_RCardDPart_t C " &
                    "         ON C.PartID = B.PartID AND C.Stationid = B.Stationid  " &
                    "    INNER JOIN m_PartContrast_t D " &
                    "          ON C.EWPartNumber=D.TAvcPart   " &
                    "      LEFT JOIN " &
                    "        (SELECT A.* " &
                    "         FROM  ( " &
                    "                  SELECT B.PARTID, " &
                    "                          B.RemainCount, " &
                    "                          ROW_NUMBER() OVER(PARTITION BY B.PARTID " &
                    "                          ORDER BY B.PARTID) ID  " &
                    "                  FROM M_EQUIPMENT_T B) A " &
                    "         WHERE ID=1)E  " &
                    "         ON C.PARTID=E.PARTID  " &
                    " WHERE 1=1 " &
                    RCardComBusiness.GetWhereAnd("A.PARTID", partId) &
                    RCardComBusiness.GetWhereAnd("B.STATIONID", stationId) &
                    RCardComBusiness.GetFatoryProfitcenter("A") &
                    "      ORDER BY TYPE"

            dt = RCardComBusiness.GetDataTable(sql)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function GetPartNumberByEquipmentNo(equiNo As String) As DataTable
        Dim dt As DataTable = Nothing
        Try

            Dim sql As String =
            " select TAvcPart from m_PartContrast_t(nolock) where TAvcPart in(select PartID from m_Equipment_t(nolock) where EquipmentNo='" & equiNo & "')"

            dt = RCardComBusiness.GetDataTable(sql)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 功能条码
    ''' </summary>
    ''' <param name="serialNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFunctionCodeID(ByVal serialNumber As String) As DataTable
        Dim dt As DataTable
        Try
            Dim sql As String =
                "SELECT TOP 1 1 ID FROM M_USERS_T WHERE USERID='" & serialNumber & "' UNION " &
                "SELECT TOP 1 3 ID FROM m_Mainmo_t WHERE MOID='" & serialNumber & "' UNION " &
                "SELECT TOP 1 2 ID WHERE '" & serialNumber & "' LIKE  ( select top 1 replace(CodeFormat,'*','%')   from m_FunctionCode_t where id =2 ) "

            dt = RCardComBusiness.GetDataTable(sql)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    'Public Shared Function GetSopFile(partId As String, sationId As String) As DataTable
    '    Dim dt As DataTable
    '    Try
    '        Dim sql As String = "select SopFilePath from m_Rstation_t where 1=1  " &
    '            RCardComBusiness.GetWhereAnd("Stationid", sationId) &
    '            RCardComBusiness.GetFatoryProfitcenter()

    '        dt = RCardComBusiness.GetDataTable(sql)

    '        Return dt
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Function

    Public Shared Function GetSopFile(partId As String, sationId As String) As DataTable
        Dim dt As DataTable
        Try
            Dim sql As String = "select SopFilePath from m_Rstation_t where 1=1  " &
                RCardComBusiness.GetWhereAnd("Stationid", sationId)

            dt = RCardComBusiness.GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function GetAllStaion(partId As String, workOrder As String) As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim sql As String =
                "SELECT  " &
                "    MAX(CASE WHEN ID % 10 = 1 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS1," &
                "    MAX(CASE WHEN ID % 10 = 2 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS2," &
                "    MAX(CASE WHEN ID % 10 = 3 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS3," &
                "    MAX(CASE WHEN ID % 10 = 4 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS4," &
                "    MAX(CASE WHEN ID % 10 = 5 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS5," &
                "    MAX(CASE WHEN ID % 10 = 6 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS6," &
                "    MAX(CASE WHEN ID % 10 = 7 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS7," &
                "    MAX(CASE WHEN ID % 10 = 8 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS8," &
                "    MAX(CASE WHEN ID % 10 = 9 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS9," &
                "    MAX(CASE WHEN ID % 10 = 0 THEN CAST(ID AS VARCHAR)+'.'+STATUS END) STATUS10 " &
                "FROM(   SELECT ROW_NUMBER() OVER( ORDER BY A.STATIONSQ) ID , " &
                "                CEILING((ROW_NUMBER() OVER( ORDER BY A.STATIONSQ)+0.0)/10) RID , " &
                "        CASE WHEN A.IPQC IS NULL THEN N'未检' " &
                "                WHEN A.IPQC IS NOT NULL AND A.USERID IS NULL THEN N'已检' " &
                "                ELSE N'已录' END STATUS " &
                "FROM ( " &
                "        SELECT DISTINCT B.STATIONSQ,C.IPQC,D.USERID " &
                "        FROM m_RCardM_t A,m_RCardD_t B " &
                "        LEFT JOIN m_RCardLotFAI_t  C " &
                "        ON   B.PARTID = C.PARTID AND B.Stationid=C.Stationid " &
                "        LEFT JOIN m_RCardLotUnit_t D " &
                "        ON C.SerialNumber=D.SerialNumber " &
                "        WHERE A.PARTID = B.PARTID " &
                RCardComBusiness.GetWhereAnd("C.PartID", partId) &
                RCardComBusiness.GetWhereAnd("C.WorkOrder", workOrder) &
                RCardComBusiness.GetFatoryProfitcenter("A") &
                ") A )A GROUP BY RID"

            dt = RCardComBusiness.GetDataTable(Sql)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function GetUserWork(serialNumber As String, partId As String, stationId As String) As DataTable
        Dim dt As DataTable
        Try

            Dim sql As String =
                "SELECT top 1 1 FROM m_RCARDLotUnit_t(nolock) where 1=1 " &
                RCardComBusiness.GetWhereAnd("SerialNumber", serialNumber) &
                RCardComBusiness.GetWhereAnd("PartID", partId) &
                RCardComBusiness.GetWhereAnd("StationID", stationId) &
                RCardComBusiness.GetFatoryProfitcenter()

            dt = RCardComBusiness.GetDataTable(sql)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function GetMoConfigQty(workOrder As String, partId As String) As String
        Try
            Dim sql As String = "SELECT TOP 1 C.TAvcPart FROM m_Mainmo_t A ,m_Mainmo_t B,m_PartContrast_t C " & _
                                 "WHERE A.Tmoid=B.MOID AND B.PartID=C.TAvcPart AND A.MOID='" & workOrder & "'"
            Using dt As DataTable = RCardComBusiness.GetDataTable(sql)
                If dt.Rows.Count > 0 Then
                    sql = "SELECT ISNULL(A.AmountQty,1) FROM m_PartContrast_t A WHERE A.PAvcPart='" & dt.Rows(0)(0) & "' AND TAvcPart='" & partId & "'"
                    Using dt1 As DataTable = RCardComBusiness.GetDataTable(sql)
                        If dt1.Rows.Count > 0 Then
                            Return dt1.Rows(0)(0).ToString
                        Else
                            Return 1
                        End If
                    End Using
                Else
                    Return 1
                End If
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function GetRCardPart(partId As String, stationId As String) As DataTable
        Dim dt As DataTable
        Try

            Dim sql As String =
                "SELECT top 1 1 FROM m_RCardDPart_t(nolock) where 1=1 " &
                RCardComBusiness.GetWhereAnd("PartID", partId) &
                RCardComBusiness.GetWhereAnd("StationID", stationId) &
                RCardComBusiness.GetFatoryProfitcenter()

            dt = RCardComBusiness.GetDataTable(sql)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

#Region "取得下一站数据"

    Public Shared Function GetNextStation(partId As String, stationId As String) As DataTable
        Dim dt As DataTable
        Dim result As String = String.Empty
        Try
            Dim strSQL =
                "SELECT TOP 1 B.StationID," &
                "(SELECT TOP 1 Stationname FROM m_Rstation_t WHERE Stationid=B.StationID and usey = 'Y') as StationName " &
                "FROM m_RCardM_t A " &
                "INNER JOIN m_RCardD_t B " &
                "ON A.PartID = B.PartID " &
                "WHERE B.StationSQ >(SELECT StationSQ FROM m_RCardD_t WHERE PartID = @PartID AND StationID = @StationID) " &
                "AND B.PartID = @PartID " &
                RCardComBusiness.GetFatoryProfitcenter("A") &
                "ORDER BY B.StationSQ "
            Dim arrayList As New ArrayList

            arrayList.Add("PartID|" & partId)
            arrayList.Add("StationID|" & stationId)
            dt = RCardComBusiness.GetDataTable(strSQL, arrayList)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "校验条码数据"
    Public Shared Function VerifySnData(ByVal sn As String, ByVal snType As Integer) As String
        '参数定义
        Dim param1 As New SqlParameter("@SerialNumber", SqlDbType.NVarChar, 200, ParameterDirection.Input)
        Dim param2 As New SqlParameter("@SnType", SqlDbType.Int, ParameterDirection.Input)
        Dim param3 As New SqlParameter("@Factoryid", SqlDbType.NVarChar, 16, ParameterDirection.Input)
        Dim param4 As New SqlParameter("@Profitcenter", SqlDbType.NVarChar, 16, ParameterDirection.Input)
        Dim param5 As New SqlParameter("@msg", SqlDbType.NVarChar, 200)
        '参数赋值
        param1.Value = sn
        param2.Value = snType
        param3.Value = VbCommClass.VbCommClass.Factory
        param4.Value = VbCommClass.VbCommClass.profitcenter
        param5.Direction = ParameterDirection.Output '?指定
        param5.Value = Nothing
        Dim Paramters As SqlParameter() = Nothing
        Paramters = New SqlParameter() {param1, param2, param3, param4, param5}

        '#If DEBUG Then
        '执行SP
        Dim err As String = RCardComBusiness.ExecuteNonQureyByProc("udpVerifySn2", Paramters)
'#Else
'          '执行SP
'        Dim err As String = RCardComBusiness.ExecuteNonQureyByProc("udpVerifySn", Paramters)
'#End If

        If err <> "" Then
            Return err
        Else
            If TypeOf param5.Value Is DBNull Then
                Return ""
            Else
                Return param5.Value.ToString()
            End If
        End If

    End Function
#End Region

#Region "校验条码格式"
    Public Shared Function CheckSNFormat(ByVal sn As String, ByVal functionCodeId As Integer) As String
        '参数定义
        Dim param1 As New SqlParameter("@Serialnumber", SqlDbType.NVarChar, 50, ParameterDirection.Input)
        Dim param2 As New SqlParameter("@FunctionID", SqlDbType.Int, ParameterDirection.Input)
        Dim param3 As New SqlParameter("@SNFormat", SqlDbType.NVarChar, 200)
        '参数赋值
        param1.Value = sn
        param2.Value = functionCodeId
        param3.Direction = ParameterDirection.Output '?指定
        param3.Value = Nothing
        Dim Paramters As SqlParameter() = Nothing
        Paramters = New SqlParameter() {param1, param2, param3}

        '#If DEBUG Then
        '执行SP
        Dim err As String = RCardComBusiness.ExecuteNonQureyByProc("udpCheckSNFormat2", Paramters)
        '#Else
        '          '执行SP
        '        Dim err As String = RCardComBusiness.ExecuteNonQureyByProc("udpCheckSNFormat", Paramters)
        '#End If
     
        If err <> "" Then
            Return err
        Else
            If TypeOf param3.Value Is DBNull Then
                Return ""
            Else
                Return param3.Value.ToString()
            End If
        End If
    End Function
#End Region

#Region "保存扫描数据"
    Public Shared Function SaveScanData(ByVal sn As String, scanerUserId As String) As String
        '参数定义
        Dim param1 As New SqlParameter("@SerialNumber ", SqlDbType.NVarChar, 200, ParameterDirection.Input)
        Dim param2 As New SqlParameter("@UserID", SqlDbType.NVarChar, 200, ParameterDirection.Input)
        Dim param3 As New SqlParameter("@Factoryid", SqlDbType.NVarChar, 16, ParameterDirection.Input)
        Dim param4 As New SqlParameter("@Profitcenter", SqlDbType.NVarChar, 16, ParameterDirection.Input)
        Dim param5 As New SqlParameter("@msg", SqlDbType.NVarChar, 200)
        '参数赋值
        param1.Value = sn
        param2.Value = scanerUserId
        param3.Value = VbCommClass.VbCommClass.Factory
        param4.Value = VbCommClass.VbCommClass.profitcenter
        param5.Direction = ParameterDirection.Output '?指定
        param5.Value = Nothing
        Dim Paramters As SqlParameter() = Nothing
        Paramters = New SqlParameter() {param1, param2, param3, param4, param5}

        '#If DEBUG Then
        '执行SP
        Dim err As String = RCardComBusiness.ExecuteNonQureyByProc("udpSaveScanData2", Paramters)
        '#Else
        '          '执行SP
        '        Dim err As String = RCardComBusiness.ExecuteNonQureyByProc("udpSaveScanData", Paramters)
        '#End If
        If err <> "" Then
            Return err
        Else
            If TypeOf param5.Value Is DBNull Then
                Return ""
            Else
                Return param5.Value.ToString()
            End If
        End If
    End Function

#Region "校验料号/治具编号"
    Public Shared Function VerifyPn(ByVal input As String, ByVal partId As String, ByVal stationId As String, ByVal woQty As Integer) As String
        '参数定义
        'Dim param1 As New SqlParameter("@sn", SqlDbType.NVarChar, 50, ParameterDirection.Input)
        'Dim param2 As New SqlParameter("@PartID", SqlDbType.Int, ParameterDirection.Input)
        'Dim param3 As New SqlParameter("@StationID", SqlDbType.Int, ParameterDirection.Input)
        'Dim param4 As New SqlParameter("@WoQty ", SqlDbType.Int, ParameterDirection.Input)
        'Dim param5 As New SqlParameter("@msg ", SqlDbType.NVarChar, 1000)
        ''参数赋值
        'param1.Value = input
        'param2.Value = partId
        'param3.Value = stationId
        'param4.Value = woQty
        'param5.Direction = ParameterDirection.Output '?指定
        'param5.Value = Nothing
        'Dim Paramters As SqlParameter() = Nothing
        'Paramters = New SqlParameter() {param1, param2, param3, param4, param5}
        ''执行SP
        'Dim err As String = RCardComBusiness.ExecuteNonQureyByProc("udpVerifyPn", Paramters)
        'If err <> "" Then
        '    Return err
        'Else
        '    If TypeOf param5.Value Is DBNull Then
        '        Return ""
        '    Else
        '        Return param5.Value.ToString()
        '    End If
        'End If
        Dim dt As DataTable
        Dim result As String = String.Empty
        Try
            Dim strSQL =
                "--declare @sn nvarchar(200)" &
                "--declare @PartID nvarchar(200)" &
                "--declare @StationID nvarchar(200)" &
                "--declare @WoQty int" &
                "--declare @msg nvarchar(1000)" &
                "--set @sn = '1234'" &
                "--set @PartID = '1000'" &
                "--set @StationID = '1000'" &
                "--set @WoQty = 2" &
                "declare @RemainCount int" &
                "declare @List table(ID int identity(1,1),PartNumber nvarchar(50),EquipmentNo nvarchar(50))" &
                "insert into @List" &
                "select PN.TAvcPart,EQ.EquipmentNo from m_RCardM_t(nolock) RC " &
                "join m_RCardD_t(nolock) RCD on RC.PartID=RCD.PartID" &
                "join m_RCardDPart_t(nolock) PD on RCD.StationID=PD.Stationid" &
                "join m_PartContrast_t(nolock) PN on PD.PartID=PN.TAvcPart" &
                "left join m_Equipment_t(nolock) EQ on PN.TAvcPart=EQ.PartID" &
                "where RC.PartID=@PartID and RCD.StationID=@StationID" &
                "--where RC.PartID=368 and RCD.StationID=4" &
                "if exists(select 1 from @List where EquipmentNo=@sn)--治具编号" &
                "begin" &
                "  select @RemainCount=RemainCount from m_Equipment_t(nolock) where EquipmentNo=@sn" &
                "  if(@RemainCount<@WoQty)" &
                "  begin" &
                "    select N'治具'''+@sn+N'''可用寿命('+Convert(varchar(50),@RemainCount)+N')小于工单数量('+Convert(varchar(50),@WoQty)+N'),请更换(udpVerifyPn)'" &
                "  end" &
                "end " &
                "else begin --料号" &
                "   if not exists(select 1 from @List where PartNumber=@sn and EquipmentNo is null)" &
                "   begin" &
                "      select N'料号或治具编号输入错误(udpVerifyPn)'" &
                "   end" &
                "end"

            Dim arrayList As New ArrayList

            arrayList.Add("sn|" & input)
            arrayList.Add("PartID|" & partId)
            arrayList.Add("StationID|" & stationId)
            arrayList.Add("WoQty|" & woQty)

            dt = RCardComBusiness.GetDataTable(strSQL, arrayList)
            If (dt.Rows.Count > 0) Then
                result = dt.Rows(0)(0).ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return result

    End Function
#End Region
#End Region

#Region "保存首检数据"
    'cq 20151106
    'Public Shared Sub SaveFAIData(serialNumber As String, workOrder As String, partId As String, stationId As String,
    '                        scanerUserName As String, ipqcUserName As String, IpqcUserId As String, al As ArrayList)
    Public Shared Sub SaveFAIData(serialNumber As String, workOrder As String, partId As String, stationId As String,
                                  scanerUserID As String, ipqcUserName As String, IpqcUserId As String, al As ArrayList)
        Try
            Dim FactoryId As String = VbCommClass.VbCommClass.Factory
            Dim profitcenter As String = VbCommClass.VbCommClass.profitcenter

            Dim StrSql As String = ""
            StrSql = "DELETE FROM m_RCardLotFAI_t WHERE 1=1" &
                    RCardComBusiness.GetWhereAnd("SerialNumber", serialNumber) &
                    RCardComBusiness.GetWhereAnd("PartID", partId) &
                    RCardComBusiness.GetWhereAnd("Stationid", stationId) &
                    RCardComBusiness.GetFatoryProfitcenter()

            If al.Count = 0 Then
                StrSql = StrSql & "INSERT INTO m_RCardLotFAI_t" & _
                    "(SerialNumber,WorkOrder,PartID,StationID,ConfirmPartNumber,OperatorUserName,ConfirmUserName,ConfirmTime,IPQC,Factoryid,Profitcenter) " & _
                    "values('" & serialNumber & "','" & workOrder & "','" & partId & "','" & stationId & "','',N'" & scanerUserID & _
                    "',N'" & ipqcUserName & "',getdate(),'" & IpqcUserId & "','" & FactoryId & "','" & profitcenter & "'); "
            Else
                For i = 0 To al.Count - 1
                    StrSql = StrSql & "insert into m_RCardLotFAI_t" & _
                        "(SerialNumber,WorkOrder,PartID,StationID,ConfirmPartNumber,OperatorUserName,ConfirmUserName,ConfirmTime,IPQC,Factoryid,Profitcenter) " & _
                        " values('" & serialNumber & "','" & workOrder & "','" & partId & "','" & stationId & "','" & al(i).ToString & _
                        "',N'" & scanerUserID & "',N'" & ipqcUserName & "',getdate() ,'" & IpqcUserId & "','" & FactoryId & "','" & profitcenter & "'); "
                Next
            End If

            RCardComBusiness.ExecSQL(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "更新首检数据"
    Public Shared Sub UpdateFAI(scanerUserId As String, serialNumber As String, partId As String, stationId As String)
        Try
            Dim strSQL As String =
                "UPDATE m_RCardLotFAI_t SET OperatorUserName='" & scanerUserId & "'" &
                RCardComBusiness.GetWhereAnd("SerialNumber", serialNumber) &
                RCardComBusiness.GetWhereAnd("PartID", partId) &
                RCardComBusiness.GetWhereAnd("Stationid", stationId) &
                RCardComBusiness.GetFatoryProfitcenter()

            RCardComBusiness.ExecSQL(strSQL)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

End Class
