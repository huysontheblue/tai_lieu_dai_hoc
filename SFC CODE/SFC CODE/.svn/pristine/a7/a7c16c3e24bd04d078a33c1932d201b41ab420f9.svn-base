Imports System.Data
Imports MainFrame
Imports System.Text

''' <summary>
''' 公共方法函数--基础数据
''' </summary>
''' <remarks></remarks>
Public Class CommClass
    ''' <summary>
    ''' 根据公司、营运中心数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDcompanyDs() As DataSet
        Dim sql As StringBuilder = New StringBuilder()
        If VbCommClass.IsConSap = "Y" Then
            sql.Append("select Factoryid,Factoryid+'-'+Shortname name from m_Dcompany_t where usey='Y' and SapState='Y' ")
        Else
            sql.Append("select Factoryid,Factoryid+'-'+Shortname name from m_Dcompany_t where usey='Y' and SapState='N' ")
        End If
        Return DbOperateUtils.GetDataSet(sql.ToString())

    End Function
    ''' <summary>
    ''' 根据用户权限获取工厂权限
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetUserFactoryDt() As DataTable
        Dim dt As DataTable = New DataTable
        Dim sql As String = "select code=a.Factoryid,a.Factoryid+'-'+a.Shortname name,PCompany='' from m_Dcompany_t a where a.usey='Y' and a.SapState='N' and a.Factoryid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='F0_' and userid='" & VbCommClass.UseId & "')"
        If VbCommClass.IsConSap = "Y" Then
            sql = "select code=b.Factoryid,b.Factoryid+'-'+b.Shortname name,PCompany from m_Dcompany_t a join m_Factory_t b on a.Factoryid=b.PCompany where a.usey='Y' and a.SapState='Y' and b.Factoryid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='F0_' and userid='" & VbCommClass.UseId & "')"
        End If
        dt = DbOperateUtils.GetDataTable(sql)
        Return dt
    End Function
    ''' <summary>
    ''' 根据用户权限获取权限部门
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetUserDeptDt() As DataTable
        Dim dt As DataTable = New DataTable
        If VbCommClass.IsConSap = "Y" Then
            dt = DbOperateUtils.GetDataTable("select deptid+'_'+dqc as djc,deptid,dqc from   m_Dept_t where factoryid='" & VbCommClass.PCompany & "' and deptid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='10109_' and userid='" & VbCommClass.UseId & "')")

        Else
            dt = DbOperateUtils.GetDataTable("select deptid+'_'+dqc  as djc,deptid,dqc from   m_Dept_t where factoryid='" & VbCommClass.Factory & "' and deptid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='10109_' and userid='" & VbCommClass.UseId & "')")
        End If
        Return dt
    End Function
    ''' <summary>
    ''' 根据登录用户获取权限线别
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetUserLineDt() As DataTable
        Dim dt As DataTable = New DataTable

        dt = DbOperateUtils.GetDataTable("select lineid from   deptline_t where  lineid in (select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent='z09_' and userid='" & VbCommClass.UseId & "')")

        Return dt
    End Function
    ''' <summary>
    ''' 根据部门获取线别
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDeptLineDt(Optional ByVal deptid As String = "") As DataTable
        If (deptid = "") Then
            Return DbOperateUtils.GetDataTable("Select  lineid,lineid from Deptline_t where usey='Y'")
        Else
            Return DbOperateUtils.GetDataTable("Select  lineid,lineid from Deptline_t where usey='Y' and deptid='" & deptid & "'")
        End If
    End Function
    ''' <summary>
    ''' 根据工单类别
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMotypeDt() As DataTable
        Return DbOperateUtils.GetDataTable("Select  motype,typeid from motype_t")
    End Function
    ''' <summary>
    ''' 根据客户代码
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCustomerDt() As DataTable
        Return DbOperateUtils.GetDataTable("Select (CusID+'---'+CusName) CusName ,CusID from m_Customer_t")
    End Function

    ''' <summary>
    ''' 取得项目别
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetItemCodeDt() As DataTable
        Return DbOperateUtils.GetDataTable("SELECT ProjectName FROM m_Project_t WHERE Usey = 'Y' ORDER BY ProjectName ASC ")
    End Function

    ''' <summary>
    ''' 根据系列别
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetSeriesDt() As DataTable
        Return DbOperateUtils.GetDataTable(" SELECT ([SeriesID]+'---'+[SeriesName])SeriesName ,[SeriesID] FROM [m_Series_t] WHERE Usey='Y'")
    End Function

    ''' <summary>
    ''' 获取料件的客户和系列别
    ''' </summary>
    ''' <param name="partid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPartCusIdSeriIDDt(partid As String ) As DataTable
        Dim strSQL As String = " SELECT top 1 CusId,SeriesID,ItemCode FROM m_PartContrastExtend_t WHERE tavcpart = pavcpart AND pavcpart = '{0}' " &
                               " and factory = '' ORDER BY seriesid desc"
        strSQL = String.Format(strSQL, partid)

        Return DbOperateUtils.GetDataTable(strSQL)
    End Function

    Public Shared Function GetFactoryByUserDt(strUser As String) As DataTable
        Dim strSql As String = ""
        If VbCommClass.IsConSap = "Y" Then
            strSql =
                "   select BB.Shortname, buttonid from m_logtree_t AA " &
                "   INNER JOIN M_FACTORY_T BB ON AA.ButtonID = BB.Factoryid " &
                "   where tkey in " &
                "   (select tkey from m_userright_t where tkey in " &
                "   ( SELECT Tkey FROM m_logtree_t WHERE tparent IN(" &
                "   select tkey from m_logtree_t a INNER JOIN m_Dcompany_t b" &
                "   ON a.buttonid = b.Factoryid AND b.SapState = 'Y'   where tparent='F0_')) " &
                "   and userid='" & strUser & "')" &
                "   ORDER BY ButtonID "
        Else
            strSql = " select BB.Shortname, buttonid from m_logtree_t AA " _
                & " INNER JOIN m_Dcompany_t BB ON AA.ButtonID = BB.Factoryid " _
                & " where tkey in " _
                & " (select tkey from m_userright_t where tkey in " _
                & " (select tkey from m_logtree_t a INNER JOIN m_Dcompany_t b " _
                & " ON a.buttonid = b.Factoryid AND b.SapState = 'N' where tparent='F0_') " _
                & " and userid='" & strUser & "') "
        End If
        Return DbOperateUtils.GetDataTable(strSql)
    End Function

    '获取SAP料件信息
    Public Shared Function GetErpFilterSqlSap(partNo As String, stype As String) As String
        Dim strSQL As String = "declare @sql varchar(max)  exec GetSapBOMSql '{0}', '{1}','{2}','{3}','{4}',@sql output select @sql"
        strSQL = String.Format(strSQL, VbCommClass.SapServer, VbCommClass.Factory, partNo, "01", stype)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Dim querySql As String = ""
        If (dt.Rows.Count > 0) Then
            querySql = dt.Rows(0)(0).ToString
        End If

        Return querySql
    End Function

    '查厂区
    Public Shared Function GetPartFatory() As String
        Dim strValue As String = " AND (factory='" & VbCommClass.Factory & "' or factory = '') "

        Return strValue
    End Function
End Class
