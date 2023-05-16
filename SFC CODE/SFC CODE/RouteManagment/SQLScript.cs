using System;
using System.Collections.Generic;
using System.Text;

namespace RouteManagement
{
    public static class SQLScript
    {

        public static string GetSortSetQuery(string SortType)
        {
            string strSQL = string.Empty;
            string strWhere = string.Empty;

            if (!string.IsNullOrEmpty(SortType))
            {
                strWhere = " AND SortType = '" + SortType.Replace("'", "''") + "'";
            }

            strSQL = "SELECT SortID,SORTID+'-'+SortName AS SORTNAME FROM M_SORTSET_T WHERE 1=1 " + strWhere;

            return strSQL;
        }

        public static string GetStationQuery(string StationName, string StationType)
        {
            string strSQL = string.Empty;
            string strWhere = string.Empty;

            if (!string.IsNullOrEmpty(StationName))
            {
                strWhere = " AND STATIONNAME LIKE '%" + StationName.Replace("'", "''") + "'";
            }

            if (!string.IsNullOrEmpty(StationType))
            {
                strWhere = " AND STATIONTYPE = '" + StationType.Replace("'", "''") + "'";
            }

            strSQL = "SELECT C.SORTID + '-' + C.SORTNAME AS STATIONTYPE,STATIONID,STATIONNAME,STATIONDEST, B.USERNAME " +
                    "FROM M_RSTATION_T A  " +
                    "LEFT JOIN DBO.M_SORTSET_T C ON A.STATIONTYPE=C.SORTID AND C.SORTTYPE='STATIONTYPE'  " +
                    "LEFT JOIN M_USERS_T B ON A.USERID=B.USERID  " +
                    "WHERE A.usey='Y' " + strWhere;

            return strSQL;
        }

        public static string GetRouteQuery(string RouteID, string RouteName)
        {
            string strSQL = string.Empty;
            string strWhere = string.Empty;

            if (!string.IsNullOrEmpty(RouteName))
            {
                strWhere = " AND RouteName LIKE '%" + RouteName.Replace("'", "''") + "'";
            }

            if (!string.IsNullOrEmpty(RouteID))
            {
                strWhere = " AND RouteID = '" + RouteID.Replace("'", "''") + "'";
            }

            strSQL = "SELECT   RouteID, RouteName, RouteTypeID, Descr, m_Users_t.UserName, CONVERT(VARCHAR(20), UpdateTime,120) AS UpdateTime, SortTagText.SORTID + '-' + SortTagText.SORTNAME AS ActiveFlag, " +
                    "SortFlagText.SORTID + '-' + SortFlagText.SORTNAME AS ActiveTag " +
                    "FROM  m_Route_t " +
                    "LEFT JOIN M_SORTSET_T SortTagText ON m_Route_t.ActiveTag=SortTagText.SORTID AND SortTagText.SORTTYPE='ActiveTag' " +
                    "LEFT JOIN M_SORTSET_T SortFlagText ON m_Route_t.ActiveFlag=SortFlagText.SORTID AND SortFlagText.SORTTYPE='ActiveFlag' " +
                    "LEFT JOIN M_USERS_T ON m_Route_t.USERID=M_USERS_T.USERID " +
                    "WHERE 1=1" + strWhere;

            return strSQL;
        }

    }
}
