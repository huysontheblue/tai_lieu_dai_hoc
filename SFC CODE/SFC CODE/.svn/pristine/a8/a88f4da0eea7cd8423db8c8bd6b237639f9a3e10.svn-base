Imports SysBasicClass
Imports MainFrame

Public Class BMComDB

    ''' <summary>
    ''' 不良大分类
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxNGCategory(ByVal ColComboBox As ComboBox)
        'Dim strSQL As String = "select DISTINCT EsortName,CVer,(EsortName + '-' +CsortName) TEXT  from m_Code_t  where Usey='Y' ORDER BY CVer "
        'add by 马跃平 2017-12-20 王倩提出需求
        Dim UseId As String = VbCommClass.VbCommClass.UseId
        Dim strSQL As String = "select SUBSTRING(Ttext,0,CHARINDEX('-',Ttext)) EsortName,Ttext AS TEXT from m_Logtree_t where Tkey in(" &
        "SELECT Tkey FROM m_UserRight_t WHERE UserID='" + UseId + "' and Tkey like 'm20007_%' and Tkey <>'m20007_')"
        BindCombox(strSQL, ColComboBox, "TEXT", "EsortName")
    End Sub

    ''' <summary>
    ''' 不良站点
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxNGStation(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select Stationid, (Stationid + '-' +Stationname) TEXT  from m_Rstation_t where  NGY = 'Y' "

        BindCombox(strSQL, ColComboBox, "TEXT", "Stationid")
    End Sub

    ''' <summary>
    ''' 不良原因类别
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxNGRType(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select distinct rCsortName,(rCsortName + '-' + CsortName)CsortName from m_Coder_t a inner join m_Code_t b on a.rEsortName=b.CodeID  where b.Usey='Y'  order by CsortName,rCsortName "

        BindCombox(strSQL, ColComboBox, "CsortName", "rCsortName")
    End Sub

    ''' <summary>
    ''' 不良现象代码
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxNGCode(ByVal ColComboBox As ComboBox, Optional ByVal code As String = "")
        Dim strSQL As String = "select CodeID,(CsortName+ '-' + CodeID + '-' + CCName)TEXT  from m_Code_t where Usey='Y' order by CsortName "
        If String.IsNullOrEmpty(code) = False Then
            strSQL = "select CodeID,(CsortName+ '-' + CodeID + '-' + CCName)TEXT  from m_Code_t where Usey='Y' and esortname = '{0}' order by CsortName "
            strSQL = String.Format(strSQL, code)
        End If

        BindCombox(strSQL, ColComboBox, "TEXT", "CodeID")
    End Sub

    ''' <summary>
    ''' 值班用户
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    ''' 
    Public Shared Sub BindComboxDutyUser(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select * from DCSDB.dbo.ZSHR_YGJBXX WHERE (CPF29='31C263'OR CPF29='31C123') AND CPF35 IS NULL  "
        BindCombox(strSQL, ColComboBox, "CPF02", "CPF01")
    End Sub

    ''' <summary>
    ''' 值班用户
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxDutyType(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select TEXT ,VALUE  from m_BaseData_t where ITEMKEY = 'DuteType' and Status = 1 order by SORT  "

        BindCombox(strSQL, ColComboBox, "TEXT", "VALUE")
    End Sub

    ''' <summary>
    ''' 扫描特殊类别
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxScanCodeSpec(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select TEXT ,VALUE  from m_BaseData_t where ITEMKEY = 'ScanCodeSpec' and Status = 1  order by SORT  "

        BindCombox(strSQL, ColComboBox, "TEXT", "VALUE")
    End Sub

    ''' <summary>
    ''' 线别对应班别数据
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxClass(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "SELECT DISTINCT (classtype + '-'+SUBSTRING(ClassName,1,2))ClassName,classtype FROM m_KanbanClass_t WHERE classtype like 'D%' order by classtype  "

        BindCombox(strSQL, ColComboBox, "ClassName", "classtype")
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

    '取得数据库中最大CODE数
    Public Shared Function GetMAXCodeid(code As String) As String
        Dim strSQL As String = "select ISNULL(MAX(CAST(substring(codeid,3,len(codeid)) AS INT)) + 1,1) from m_code_t where esortname = '{0}'"
        strSQL = String.Format(strSQL, code)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count = 0) Then
            GetMAXCodeid = code + "01"
        Else
            GetMAXCodeid = code + dt.Rows(0)(0).ToString.PadLeft(2, "0")
        End If
    End Function

    '取得数据库中最大RCODE数
    Public Shared Function GetMAXRCodeid(code As String) As String
        Dim strSQL As String = "select ISNULL(MAX(CAST(substring(rcodeid,5,len(rcodeid)) AS INT)) + 1,1) from m_coder_t where resortname = '{0}'"
        strSQL = String.Format(strSQL, code)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count = 0) Then
            GetMAXRCodeid = code + "01"
        Else
            GetMAXRCodeid = code + dt.Rows(0)(0).ToString.PadLeft(2, "0")
        End If
    End Function


    '取得数据库中最大维修方法最大ID
    Public Shared Function GetMAXMainTainStyleId(code As String) As String
        Dim strSQL As String = "select ISNULL(MAX(CAST(substring(MstyleId ,{0},len(MstyleId)) AS INT)) + 1,1) from m_MainTainStyle_t where StyleSort = '{1}'"
        strSQL = String.Format(strSQL, code.Length + 2, code)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count = 0) Then
            GetMAXMainTainStyleId = code + "R01"
        Else
            GetMAXMainTainStyleId = code + "R" + dt.Rows(0)(0).ToString.PadLeft(2, "0")
        End If
    End Function

    '取得ORACLE连接数据
    Public Shared Function GetErpData(strSQL As String) As DataTable
        Dim dt As DataTable
        Dim oracleConn As New OracleDb("")

        Try

            dt = oracleConn.ExecuteQuery(strSQL).Tables(0)

        Catch ex As Exception
            Throw ex
        Finally
            If Not oracleConn Is Nothing Then
                oracleConn = Nothing
            End If
        End Try

        Return dt
    End Function

    Public Shared Function GetNewDataTable(ByVal o_dt As DataTable, ByVal strCondition As String, ByVal strSort As String) As DataTable
        Dim newdt As DataTable
        Dim o_arrDr As DataRow()
        newdt = o_dt.Clone
        o_arrDr = o_dt.Select(strCondition, strSort)
        For Each o_dr As DataRow In o_arrDr
            newdt.ImportRow(o_dr)
        Next
        Return newdt
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
