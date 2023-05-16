Imports System.Text.RegularExpressions
Imports MainFrame
Imports DevComponents.DotNetBar

Public Class SampleCom
    Public Enum enumLevelID
        Request = 1
        DocumentUpload = 2 '蓝图、裁线卡、流程卡上传
        Equ = 3 '设备清单上传
        BOM = 4
        ZEqu = 5
        Model '模具清单上传 + /预计交期
        EquConfirm = 7 '确认已有设备
        MaterialGive = 8 '物料交期提供
        ZEquGive = 9
        EquGive = 10
        BOMConfirm '生管确认
    End Enum

    Public Enum enumSampleStatus
        Make = 0
        Close
    End Enum

    Public Enum enumdgvSampleD
        LevelID
        Status
        DutyUserID
        PlanDueDate
        StartTime
        EndTime
    End Enum

    Public Enum enumSumType
        PZ
        ZC
        Project
        MadeDoc
        ZJ
    End Enum

    Public Enum EnumSampleDept
        业务
        品质
        PIE
        治具
        生管
        设备
        样品室
        研发
    End Enum

    Public Enum enumDocumentType
        PZ
        ZC
        Project
        MadeDoc
    End Enum

    Public Enum enumRDDocumentType
        蓝图
        裁线卡
        流程卡
        治具开立资料
        客户蓝图
        包规
        BOM
    End Enum

    Public Shared Function GetQueryRDNamelist(ByVal strRDNameList As String) As String
        '  Dim strRDNameList As String = "陈山,陈琦,鲁红兵"
        strRDNameList = strRDNameList.Replace(",", "',N'")
        strRDNameList = "N'" + strRDNameList + "'"
        GetQueryRDNamelist = strRDNameList
    End Function

    Public Shared Function IncludeChinese(ByVal str As String) As Boolean
        Dim regex As Regex = New Regex("[\u4e00-\u9fa5]")

        If regex.IsMatch(str) Then
            IncludeChinese = True
        Else
            IncludeChinese = False
        End If
        Return IncludeChinese
    End Function

    Public Shared Function GetUserID(ByVal userName As String) As String
        Dim strSQL As String = String.Empty, UserID = ""
        strSQL = " SELECT TOP 1 USERID FROM m_Users_t(nolock)  WHERE username=N'" & userName & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                UserID = o_dt.Rows(0).Item(0)
            End If
        End Using
        GetUserID = UserID
        Return GetUserID
    End Function

    Public Shared Function GetUserName(ByVal strUserID As String) As String
        Dim strSQL As String = String.Empty
        GetUserName = ""
        strSQL = " SELECT TOP 1  UserName FROM m_Users_t(nolock)  WHERE UserID=N'" & strUserID & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetUserName = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetUserName
    End Function

    Public Shared Function GetUserDept(ByVal strUserID As String) As String
        Dim strSQL As String = String.Empty
        GetUserDept = ""
        strSQL = " SELECT TOP 1  DutyDeptName FROM m_SamplePic_t(nolock)  WHERE DutyUserID=N'" & strUserID & "' AND usey ='Y'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetUserDept = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetUserDept
    End Function

    Public Shared Function GetUserDeptByName(ByVal strUserName As String) As String
        Dim strSQL As String = String.Empty
        GetUserDeptByName = ""
        strSQL = " SELECT TOP 1  DutyDeptName FROM m_SamplePic_t(nolock)  WHERE DutyUserName=N'" & strUserName & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetUserDeptByName = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetUserDeptByName
    End Function

    Public Shared Function GetCustID(ByVal strSampleNO As String) As String
        Dim strSQL As String = String.Empty
        GetCustID = ""
        strSQL = " SELECT TOP 1 CustID FROM m_Sample_t(nolock)  WHERE SampleNO=N'" & strSampleNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetCustID = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetCustID
    End Function

    Public Shared Function GetYWUserName(ByVal strSampleNO As String) As String
        Dim strSQL As String = String.Empty
        GetYWUserName = ""
        strSQL = " SELECT isnull(a.YWUserName,'')YWUserName FROM m_Sample_t a " & _
                 " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetYWUserName = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetYWUserName
    End Function

    Public Shared Function GetPZUserName(ByVal strSampleNO As String) As String
        Dim strSQL As String = String.Empty
        GetPZUserName = ""
        strSQL = " SELECT ISNULL(a.PZUserName,'')PZUserName  FROM m_Sample_t a " & _
                 " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetPZUserName = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetPZUserName
    End Function

    Public Shared Function GetYPSUserName(ByVal strSampleNO As String) As String
        Dim strSQL As String = String.Empty
        GetYPSUserName = ""
        strSQL = " SELECT ISNULL(a.YPSUserName,'') YPSUserName FROM m_Sample_t a " & _
                 " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetYPSUserName = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetYPSUserName
    End Function

    Public Shared Function GetEquUserName(ByVal strSampleNO As String) As String
        Dim strSQL As String = String.Empty
        GetEquUserName = ""
        strSQL = " SELECT ISNULL(a.EquUserName,'')EquUserName  FROM m_Sample_t a " & _
                 " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetEquUserName = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetEquUserName
    End Function

    Public Shared Function GetSGUserName(ByVal strSampleNO As String) As String
        Dim strSQL As String = String.Empty
        GetSGUserName = ""
        strSQL = " SELECT ISNULL(a.SGUserName,'')SGUserName  FROM m_Sample_t a " & _
                 " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetSGUserName = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetSGUserName
    End Function

    Public Shared Function GetPIEUserName(ByVal strSampleNO As String) As String
        Dim strSQL As String = String.Empty
        GetPIEUserName = ""
        strSQL = " SELECT ISNULL(a.PIEUserName,'')PIEUserName  FROM m_Sample_t a " & _
                 " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetPIEUserName = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetPIEUserName
    End Function

    Public Shared Function GetCCUserName(ByVal strSampleNO As String) As String
        Dim strSQL As String = String.Empty
        GetCCUserName = ""
        strSQL = " SELECT ISNULL(a.CCUserName,'') CCUserName FROM m_Sample_t a " & _
                 " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetCCUserName = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetCCUserName
    End Function

    Public Shared Function GetUploadTimes(ByVal strSampleNO As String, type As String) As String
        Dim strSQL As String = String.Empty
        GetUploadTimes = "0"
        Select Case type
            Case enumRDDocumentType.蓝图.ToString
                strSQL = " SELECT Count(1) FROM m_SampleDocumentHis_t WHERE 1=1" & _
                         " AND SampleNO ='" & strSampleNO & "' AND type =N'" & enumRDDocumentType.蓝图.ToString & "'"
            Case enumRDDocumentType.裁线卡.ToString
                strSQL = " SELECT Count(1) FROM m_SampleDocumentHis_t WHERE 1=1" & _
                         " AND SampleNO ='" & strSampleNO & "' AND type =N'" & enumRDDocumentType.裁线卡.ToString & "'"
            Case enumRDDocumentType.流程卡.ToString
                strSQL = " SELECT Count(1) FROM m_SampleDocumentHis_t WHERE 1=1" & _
                         " AND SampleNO ='" & strSampleNO & "' AND type =N'" & enumRDDocumentType.流程卡.ToString & "'"
            Case enumRDDocumentType.治具开立资料.ToString
                strSQL = " SELECT Count(1) FROM m_SampleDocumentHis_t WHERE 1=1" & _
                         " AND SampleNO ='" & strSampleNO & "' AND type =N'" & enumRDDocumentType.治具开立资料.ToString & "'"
            Case enumRDDocumentType.客户蓝图.ToString
                strSQL = " SELECT Count(1) FROM m_SampleDocumentHis_t WHERE 1=1" & _
                         " AND SampleNO ='" & strSampleNO & "' AND type =N'" & enumRDDocumentType.客户蓝图.ToString & "'"
            Case enumRDDocumentType.包规.ToString
                strSQL = " SELECT Count(1) FROM m_SampleDocumentHis_t WHERE 1=1" & _
                         " AND SampleNO ='" & strSampleNO & "' AND type =N'" & enumRDDocumentType.包规.ToString & "'"
            Case enumRDDocumentType.BOM.ToString
                strSQL = " SELECT Count(1) FROM m_SampleDocumentHis_t WHERE 1=1" & _
                         " AND SampleNO ='" & strSampleNO & "' AND type =N'" & enumRDDocumentType.BOM.ToString & "'"
            Case Else
                Exit Function
        End Select
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetUploadTimes = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetUploadTimes
    End Function

    Public Shared Function GetStdTime(ByVal strPartNO As String) As String
        Dim strSQL As String = String.Empty
        GetStdTime = ""
        strSQL = " SELECT ISNULL(QuoteHour,'') FROM m_RCardQuoteMaintenance WHERE 1=1" & _
                 " AND PartNumber ='" & strPartNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetStdTime = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetStdTime
    End Function

    Public Shared Function GetMOQty(ByVal strMOID As String) As String
        Dim strSQL As String = String.Empty
        GetMOQty = ""
        strSQL = " SELECT ISNULL(a.Moqty,'0')MO FROM m_MainMO_t a " & _
                 " WHERE  a.MOID  = N'" & strMOID & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetMOQty = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetMOQty
    End Function

    'ZJUserName
    Public Shared Function GetZJUserName(ByVal strSampleNO As String) As String
        Dim strSQL As String = String.Empty
        GetZJUserName = ""
        strSQL = " SELECT ISNULL(a.ZJUserName,'')ZJUserName  FROM m_Sample_t a " & _
                 " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetZJUserName = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetZJUserName
    End Function

    Public Shared Function GetPICUserNames(ByVal strSampleNO As String, ByVal strDeptName As String) As String
        Dim strSQL As String = String.Empty
        GetPICUserNames = ""
        Select Case strDeptName
            Case EnumSampleDept.研发.ToString
                strSQL = " SELECT ISNULL(a.RDUserName,'')RDUserName  FROM m_Sample_t a " & _
                " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
            Case EnumSampleDept.PIE.ToString
                strSQL = " SELECT ISNULL(a.PIEUserName,'')PIEUserName  FROM m_Sample_t a " & _
              " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
            Case EnumSampleDept.品质.ToString
                strSQL = " SELECT ISNULL(a.PZUserName,'')PZUserName  FROM m_Sample_t a " & _
                         " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
            Case EnumSampleDept.生管.ToString
                strSQL = " SELECT ISNULL(a.SGUserName,'')SGUserName  FROM m_Sample_t a " & _
                         " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
            Case EnumSampleDept.业务.ToString
                strSQL = " SELECT ISNULL(a.YWUserName,'')YWUserName  FROM m_Sample_t a " & _
                         " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
            Case EnumSampleDept.样品室.ToString
                strSQL = " SELECT ISNULL(a.YPSUserName,'')YPSUserName  FROM m_Sample_t a " & _
                         " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
            Case EnumSampleDept.设备.ToString
                strSQL = " SELECT ISNULL(a.EquUserName,'')EquUserName  FROM m_Sample_t a " & _
                         " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
            Case EnumSampleDept.治具.ToString
                strSQL = " SELECT ISNULL(a.ZJUserName,'')ZJUserName  FROM m_Sample_t a " & _
                         " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
            Case Else
                strSQL = " SELECT a.DutyUserName FROM   m_SamplePicD_t a  " & _
                         " WHERE a.DeptName Like N '%" & strDeptName & "%' AND SAMPLENO='" & strSampleNO & "' "
        End Select
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetPICUserNames = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetPICUserNames
    End Function

    Public Shared Function GetDefaultPICUserNames(ByVal strRDUserID As String, ByVal strDeptName As String) As String
        Dim strSQL As String = String.Empty
        GetDefaultPICUserNames = ""
        Select Case strDeptName
            Case EnumSampleDept.研发.ToString
                strSQL = " SELECT ISNULL(a.DutyUserName,'')RDUserName  FROM m_SampleDefaultPIC_t a " & _
                " WHERE  a.RDUserID  = N'" & strRDUserID & "'AND DeptName LIKE N'%" & strDeptName & "%'"
            Case EnumSampleDept.PIE.ToString
                strSQL = " SELECT ISNULL(a.DutyUserName,'')PIEUserName  FROM m_SampleDefaultPIC_t a " & _
              " WHERE  a.RDUserID  = N'" & strRDUserID & "'AND DeptName LIKE N'%" & strDeptName & "%'"
            Case EnumSampleDept.品质.ToString
                strSQL = " SELECT ISNULL(a.DutyUserName,'')PZUserName  FROM m_SampleDefaultPIC_t a " & _
                         " WHERE  a.RDUserID  = N'" & strRDUserID & "' AND DeptName LIKE N'%" & strDeptName & "%'"
            Case EnumSampleDept.生管.ToString
                strSQL = " SELECT ISNULL(a.DutyUserName,'')SGUserName  FROM m_SampleDefaultPIC_t a " & _
                         " WHERE  a.RDUserID  = N'" & strRDUserID & "'AND DeptName LIKE N'%" & strDeptName & "%'"
            Case EnumSampleDept.业务.ToString
                strSQL = " SELECT ISNULL(a.DutyUserName,'')YWUserName  FROM m_SampleDefaultPIC_t a " & _
                         " WHERE  a.RDUserID  = N'" & strRDUserID & "'AND DeptName LIKE N'%" & strDeptName & "%'"
            Case EnumSampleDept.样品室.ToString
                strSQL = " SELECT ISNULL(a.DutyUserName,'')YPSUserName  FROM m_SampleDefaultPIC_t a " & _
                         " WHERE  a.RDUserID  = N'" & strRDUserID & "' AND DeptName LIKE N'%" & strDeptName & "%'"
            Case EnumSampleDept.设备.ToString
                strSQL = " SELECT ISNULL(a.DutyUserName,'')EquUserName  FROM m_SampleDefaultPIC_t a " & _
                         " WHERE  a.RDUserID  = N'" & strRDUserID & "' AND DeptName LIKE N'%" & strDeptName & "%'"
            Case EnumSampleDept.治具.ToString
                strSQL = " SELECT ISNULL(a.DutyUserName,'')ZJUserName  FROM m_SampleDefaultPIC_t a " & _
                         " WHERE  a.RDUserID  = N'" & strRDUserID & "' AND DeptName LIKE N'%" & strDeptName & "%'"
            Case Else
                strSQL = " SELECT a.DutyUserName FROM   m_SampleDefaultPIC_t a  " & _
                         " WHERE  a.RDUserID  = N'" & strRDUserID & "' AND DeptName LIKE N'%" & strDeptName & "%'"
        End Select
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetDefaultPICUserNames = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetDefaultPICUserNames
    End Function

    Public Shared Function GetRDUserName(ByVal strSampleNO As String) As String
        Dim strSQL As String = String.Empty
        GetRDUserName = ""
        strSQL = " SELECT ISNULL(RDUserName,'') RDUserName FROM m_Sample_t a " & _
                 " WHERE  a.SampleNO  = N'" & strSampleNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetRDUserName = o_dt.Rows(0).Item(0)
            End If
        End Using
        Return GetRDUserName
    End Function


    '取“-”前的字符；有多条数据，用【','】取得数据直接运用
    '用于C#页面取线别数据
    Public Shared Function Getids(ByVal strFullName) As String
        Dim intPos As Integer
        Dim strReturn As String = ""
        If strFullName <> "" Then
            If strFullName.ToString.Contains("ALL") Then
                strReturn = "'%'"
                Return strReturn
                Exit Function
            End If

            Dim ids() As String = strFullName.ToString.Split(",")

            For iIndex As Integer = 0 To ids.Length - 1
                intPos = InStr(ids(iIndex), "-")
                If intPos = 0 Then
                    strReturn = ids(iIndex)
                Else
                    strReturn = strReturn + "','" + Mid(ids(iIndex), 1, intPos - 1)
                End If
            Next
            strReturn = strReturn.Substring(2) + "'"
        Else
            strReturn = "'%'"
        End If
        Return strReturn
    End Function

    Public Shared Function GetPNInfo(ByVal strSampleNO As String,
                                     ByRef strFormatdes As String, ByRef strMadeQty As String) As String
        Dim strSQL As String = String.Empty
        GetPNInfo = ""
        strSQL = " SELECT TOP 1 PartNo, FormatDes,MadeQty  FROM m_Sample_t (nolock)  WHERE SampleNO=N'" & strSampleNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetPNInfo = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item(0))
                strFormatdes = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item(1))
                strMadeQty = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("MadeQty"))
            End If
        End Using
        Return GetPNInfo
    End Function

    Public Shared Function GetPLMFactory(ByVal strFactoryID As String) As String
        Select Case strFactoryID
            Case "LXXT"
                GetPLMFactory = "LX11"
            Case Else
                GetPLMFactory = strFactoryID
        End Select
        Return GetPLMFactory
    End Function

    Public Shared Function GetPLMProfitcenter(ByVal strProfitcenter As String) As String
        'LX11_AA	制造一处	LX11
        'LX11_AC	E-BU	LX11
        Select Case strProfitcenter
            Case "XT-D"
                GetPLMProfitcenter = "LX11_AA"
            Case "SEE-D"
                GetPLMProfitcenter = "LX11_AC"
            Case Else
                GetPLMProfitcenter = strProfitcenter
        End Select
        Return GetPLMProfitcenter
    End Function


    Public Shared Function CheckIsZEquDateFinish(ByVal strSampleNO As String) As Boolean
        Dim lsSQL As String = String.Empty

        '存在, 表明没完成
        lsSQL = "  Select sampleno FROM m_SampleZEqu_t " & _
                "  WHERE  1=1 AND IsShare = N'否' " & _
                "  AND ( ISNULL(PlanDuedate,'') = '' OR isnull(RealDuedate,'') = '') AND sampleno ='" & strSampleNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                CheckIsZEquDateFinish = False
            Else
                CheckIsZEquDateFinish = True
            End If
        End Using
        Return CheckIsZEquDateFinish
    End Function

    Public Shared Function CheckIsEquDateFinish(ByVal strSampleNO As String) As Boolean
        Dim lsSQL As String = String.Empty

        '存在, 表明没完成
        lsSQL = "  Select sampleno FROM m_SampleEqu_t " & _
                "  WHERE  1=1 AND  IsExist ='0' " & _
                "  AND  (ISNULL(PlanDuedate,'') = '' OR ISNULL(RealDuedate,'') = '' ) AND sampleno ='" & strSampleNO & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                CheckIsEquDateFinish = False
            Else
                CheckIsEquDateFinish = True
            End If
        End Using
        Return CheckIsEquDateFinish
    End Function

    Public Shared Function CheckIsBOMDateFinish(ByVal strSampleNO As String) As Boolean
        Dim lsSQL As String = String.Empty
        '存在, 表明没完成
        lsSQL = " SELECT SampleNO FROM m_SampleBOM_t " & _
                " WHERE 1=1 AND ISNULL(IsExist,0) = '0' AND (isnull(PlanDuedate,'') = '' OR isnull(RealDuedate,'') = '')" & _
                " AND SAMPLENO ='" & strSampleNO & "' "
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                CheckIsBOMDateFinish = False
            Else
                CheckIsBOMDateFinish = True
            End If
        End Using
        Return CheckIsBOMDateFinish
    End Function


    Public Shared Sub BindComboxStatus(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = " SELECT StatusValue as value,text FROM m_SampleBaseData_t " & _
                               " WHERE itemkey = 'SampleStatus' and STATUS = 1 ORDER BY SORT"

        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub


    Public Shared Sub BindComboxPIE(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = " SELECT DISTINCT b.UserName  as value,b.UserName as text FROM m_SamplePic_t  a " & _
                               " LEFT JOIN m_users_t  b on  a.Dutyuserid = b.userID " & _
                               " WHERE  DutyDeptName = N'" & EnumSampleDept.PIE.ToString & "'" & _
                               " AND a.UseY='Y'"
        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    Public Shared Sub BindComboxSG(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = " SELECT DISTINCT b.UserName  as value,b.UserName as text FROM m_SamplePic_t  a " & _
                               " LEFT JOIN m_users_t  b on  a.Dutyuserid = b.userID " & _
                               " WHERE  DutyDeptName = N'" & EnumSampleDept.生管.ToString & "'" & _
                               " AND a.UseY='Y'"
        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    Public Shared Sub BindComboxRD(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = " SELECT DISTINCT b.UserName  as value,b.UserName as text FROM m_SamplePic_t  a " & _
                               " LEFT JOIN m_users_t  b on  a.Dutyuserid = b.userID " & _
                               " WHERE  DutyDeptName = N'" & EnumSampleDept.研发.ToString & "'" & _
                               " AND a.UseY='Y'"
        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    Public Shared Sub BindComboxPZ(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = " SELECT DISTINCT b.UserName  as value,b.UserName as text FROM m_SamplePic_t  a " & _
                               " LEFT JOIN m_users_t  b on  a.Dutyuserid = b.userID " & _
                               " WHERE  DutyDeptName = N'" & EnumSampleDept.品质.ToString & "'" & _
                               " AND a.UseY='Y'"
        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    Public Shared Sub BindComboxYPS(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = " SELECT DISTINCT b.UserName  as value,b.UserName as text FROM m_SamplePic_t  a " & _
                               " LEFT JOIN m_users_t  b on  a.Dutyuserid = b.userID " & _
                               " WHERE  DutyDeptName = N'" & EnumSampleDept.样品室.ToString & "'" & _
                               " AND a.UseY='Y'"
        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    Public Shared Sub BindComboxEqu(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = " SELECT DISTINCT b.UserName  as VALUE,b.UserName as TEXT FROM m_SamplePic_t  a " & _
                               " LEFT JOIN m_users_t  b ON  a.Dutyuserid = b.userID " & _
                               " WHERE  DutyDeptName = N'" & EnumSampleDept.设备.ToString & "'" & _
                               " AND a.UseY='Y'"
        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    Public Shared Sub BindComboxZEqu(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = " SELECT DISTINCT b.UserName  as VALUE,b.UserName as TEXT FROM m_SamplePic_t  a " & _
                               " LEFT JOIN m_users_t  b ON a.Dutyuserid = b.userID " & _
                               " WHERE  DutyDeptName = N'" & EnumSampleDept.治具.ToString & "'" & _
                               " AND a.UseY='Y'"
        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    Public Shared Sub BindComboxYW(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = " SELECT DISTINCT b.UserName  as value,b.UserName as text FROM m_SamplePic_t  a " & _
                               " LEFT JOIN m_users_t  b ON  a.Dutyuserid = b.userID " & _
                               " WHERE  DutyDeptName = N'" & EnumSampleDept.业务.ToString & "'" & _
                               " AND a.UseY='Y'"
        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    Public Shared Sub BindComboxLine(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = " SELECT LINEID as value, LINEID as TEXT FROM m_SampleLine_t " & _
                               " WHERE 1=1 and USEY = 'Y' ORDER BY LINEID"

        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    Public Shared Function IsSGUserID(ByVal strUserID As String)
        Dim strSQL As String = " SELECT dutyuserid  FROM m_SamplePic_t " & _
                               " WHERE 1=1 AND USEY = 'Y' and dutyuserid = '" & strUserID & " ' AND dutydeptname LIKE N'%生管%'" & _
                               " UNION " & _
                                "SELECT dutyuserid  FROM m_SamplePic_t " & _
                               " WHERE 1=1 AND USEY = 'Y' and dutyuserid = '" & strUserID & " ' AND dutydeptname LIKE N'%策采%'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsSGUserID = True
            Else
                IsSGUserID = False
            End If
        End Using
        Return IsSGUserID
    End Function

    Public Shared Function IsRDUserID(ByVal strUserID As String) As Boolean
        Dim strSQL As String = " SELECT dutyuserid  FROM m_SamplePic_t " & _
                               " WHERE 1=1 AND USEY = 'Y' AND dutyuserid = '" & strUserID & " ' AND dutydeptname LIKE N'%研发%'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsRDUserID = True
            Else
                IsRDUserID = False
            End If
        End Using
        Return IsRDUserID
    End Function

    Public Shared Function IsAlreadSheetImport(ByVal strSampleNo As String) As Boolean
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT SampleNo FROM m_SampleBOM_t  WHERE SampleNO='" & strSampleNo & "'" & _
                " UNION " & _
                " SELECT SampleNo FROM m_SampleEqu_t Where SampleNO ='" & strSampleNo & "'" & _
                " UNION " & _
                " SELECT sampleno FROM m_SampleZEqu_t Where SampleNO ='" & strSampleNo & "'" & _
                " UNION " & _
                " SELECT sampleno FROM m_SampleModel_t Where SampleNO ='" & strSampleNo & "' "
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                IsAlreadSheetImport = True
            Else
                IsAlreadSheetImport = False
            End If
        End Using
    End Function

    Public Shared Function IsAllDutyNameReady(ByVal strSampleNo As String, ByRef strDeptList As String) As Boolean
        Dim lsSQL As String = String.Empty
        strDeptList = ""
        lsSQL = " SELECT a.DutyDept, b.DeptName, b.SampleNO " & _
                " FROM m_SampleDept_t A " & _
                " LEFT JOIN m_SamplePICD_t B ON a.DutyDept = b.DeptName AND a.usey='Y' AND  b.SampleNO ='" & strSampleNo & "'" & _
                " WHERE 1 = 1" & _
                " AND b.SampleNO IS NULL"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If (Not IsNothing(o_dt)) AndAlso o_dt.Rows.Count > 0 Then
                IsAllDutyNameReady = False
                For Each dr As DataRow In o_dt.Rows
                    strDeptList = strDeptList + IIf(strDeptList = "", "", ",") + dr.Item("DutyDept")
                Next
            Else
                IsAllDutyNameReady = True
            End If
        End Using
    End Function

    Public Shared Sub DeleteEqu(ByVal parSampleNo As String)
        Dim lsSQL As String = String.Empty
        lsSQL = "DELETE FROM m_SampleEqu_t Where SampleNo = '" & parSampleNo & "'"
        DbOperateUtils.ExecSQL(lsSQL)
    End Sub

    Public Shared Sub DeleteModel(ByVal parSampleNo As String)
        Dim lsSQL As String = String.Empty
        lsSQL = "DELETE FROM m_SampleModel_t WHERE SampleNo = '" & parSampleNo & "'"
        DbOperateUtils.ExecSQL(lsSQL)
    End Sub

    Public Shared Sub DeleteBOM(ByVal parSampleNo As String)
        Dim lsSQL As String = String.Empty
        lsSQL = "DELETE FROM m_SampleBOM_t WHERE SampleNo = '" & parSampleNo & "'"
        DbOperateUtils.ExecSQL(lsSQL)
    End Sub

    Public Shared Sub DeleteZEqu(ByVal parSampleNo As String)
        Dim lsSQL As String = String.Empty
        lsSQL = "DELETE FROM m_SampleZEqu_t Where SampleNo = '" & parSampleNo & "'"
        DbOperateUtils.ExecSQL(lsSQL)
    End Sub

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

    Public Shared Function GetMOList(ByVal MoId As String, ByVal strSupportId As String) As DataTable
        Dim dtTemp As DataTable = Nothing
        Dim strSQL As String = ""
        Try

            'SELECT TOP 100 Moid, PARTNO, qty  FROM m_Sample_t 
            'WHERE status='0'  AND cusTid='64'  AND FactoryID = 'LXXT' AND profitcenter = 'SEE-D' 
            'AND MOID <> '' ORDER BY intime DESC
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(MoId)) Then
                strWhere = " AND Moid LIKE '%" & MoId & "%'"
            End If

            If (Not String.IsNullOrEmpty(strSupportId)) Then
                strWhere = strWhere + " AND custid='" & strSupportId & "' "
            End If

            strWhere = strWhere + " AND MOID <> ''"

            strWhere = strWhere + " AND FactoryID = '" & VbCommClass.VbCommClass.Factory & "'"
            If Not String.IsNullOrEmpty(VbCommClass.VbCommClass.profitcenter) Then
                strWhere = strWhere + " AND profitcenter = '" & VbCommClass.VbCommClass.profitcenter & "'"
            End If

            strSQL = "SELECT TOP 100 Moid, PartNO, SampleNO, qty  FROM m_Sample_t WHERE status='0' " & strWhere & " ORDER BY intime DESC"

            dtTemp = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetFatoryProfitcenter() As String
        Dim strValue As String = String.Empty
        strValue = " AND Factoryid='" & VbCommClass.VbCommClass.Factory & "'"
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + " AND Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'"
        End If
        Return strValue
    End Function

    Public Shared Function GetFatoryProfitcenter(table As String) As String
        Dim strValue As String = String.Empty
        strValue = String.Format(" AND {0}.Factoryid='" & VbCommClass.VbCommClass.Factory & "'", table)
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + String.Format(" AND {0}.Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'", table)
        End If
        Return strValue
    End Function

    Public Shared Sub GetIsShareList(ByVal CboName As DataGridViewComboBoxColumn)
        If (Not IsNothing(CboName)) AndAlso CboName.Items.Count > 0 Then
            CboName.DataSource = Nothing  'Add by cq 20161108
            CboName.Items.Clear()
        End If
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Value")
        dt.Columns.Add("Name")
        Dim dr As DataRow
        dr = dt.NewRow()
        dr(0) = "是"
        dr(1) = "是"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr(0) = "否"
        dr(1) = "否"
        dt.Rows.Add(dr)
        CboName.ValueMember = "Value"
        CboName.DisplayMember = "Name"
        CboName.DataSource = dt
    End Sub

#Region "交期维护公用类"
    Public Class SqlClassD

#Region "類內部參數"
        Dim mCurrMaxInt As Int64
        Dim mPFormat As String
        Shared mUpdateTime As String
#End Region

#Region "窗體基本屬性"

        Public Shared Property UpdateTime() As String

            Get
                Return mUpdateTime
            End Get
            Set(ByVal value As String)
                mUpdateTime = value
            End Set

        End Property

        Public Property PFormat() As String

            Get
                Return mPFormat
            End Get
            Set(ByVal value As String)
                mPFormat = value
            End Set

        End Property

        Public Property CurrMaxInt() As Int64
            Get
                Return mCurrMaxInt
            End Get
            Set(ByVal value As Int64)
                mCurrMaxInt = value
            End Set
        End Property

#End Region

#Region "建制"

        Public Sub New()
            mCurrMaxInt = 0
            mPFormat = ""
            mUpdateTime = ""
        End Sub

#End Region

#Region "Dispose"
        Public Sub dispose()
            mCurrMaxInt = 0
            mPFormat = ""
        End Sub

#End Region

    End Class
#End Region

#Region "制样条码打印"
    Public Class LabelPrintHelper
        Public Shared Function PrintLabel(ByVal dics As List(Of KeyValue), ByVal printerName As String, ByRef errorMsg As String, ByVal fileName As String, ByVal prePage As Integer, Optional ByVal copies As Integer = 1)
            Dim btApp As BarTender.Application = Nothing
            Dim btFormat As BarTender.Format = Nothing
            Try
                '创建bartender对象
                btApp = CreateObject("bartender.application")
                btApp.VisibleWindows = BarTender.BtVisibleWindows.btNone
                '创建Format对象
                'Dim strTemp1 As String = Application.StartupPath()
                'Dim strTemp2 As String = Environment.CurrentDirectory

                'btFormat = btApp.Formats.Open(Application.StartupPath() + "\EquipmentTemplate\" + fileName, True)
                btFormat = btApp.Formats.Open(fileName, True)
                btFormat.Printer = printerName
                'If prePage = 1 Then
                '    For Each dic As KeyValue In dics
                '        btFormat.SetNamedSubStringValue(dic.Key, dic.Value)
                '        btFormat.PrintOut(False, False)
                '    Next
                'Else
                For i As Integer = 1 To copies
                    For Each dic As KeyValue In dics
                        If dic.Index = i Then
                            btFormat.SetNamedSubStringValue(dic.Key, dic.Value)
                        End If
                    Next
                    btFormat.PrintOut(False, False)
                Next
                Return True
            Catch ex As Exception
                errorMsg = ex.Message
                Return False
            Finally
                '释放资源
                If Not btFormat Is Nothing Then
                    btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
                    btFormat = Nothing
                End If
                If Not btApp Is Nothing Then
                    btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
                    KillProcessById(btApp.ProcessId)
                End If
            End Try
        End Function
        Private Shared Sub KillProcessById(ByVal id As Integer)
            Dim process As Process = System.Diagnostics.Process.GetProcessById(id)
            process.Kill()
        End Sub
        Public Shared Sub InitPrinter(ByVal cboPrinter As ComboBox)
            cboPrinter.Items.Clear()
            For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                cboPrinter.Items.Add(printer)
            Next
            cboPrinter.Items.Insert(0, "")
        End Sub
    End Class
#End Region

    Public Shared Sub SetMessage(ByVal lblMessage As LabelX, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As Label, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As LabelItem, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub


    Public Class KeyValue
        Private _key As String
        Private _value As String
        Private _index As Integer

        Public Property Key() As String
            Get
                Return _key
            End Get
            Set(ByVal value As String)
                _key = value
            End Set
        End Property
        Public Property Value() As String
            Get
                Return _value
            End Get
            Set(ByVal value As String)
                _value = value
            End Set
        End Property
        Public Property Index() As Integer
            Get
                Return _index
            End Get
            Set(ByVal value As Integer)
                _index = value
            End Set
        End Property
        Public Sub New(ByVal index As Integer, ByVal key As String, ByVal value As String)
            _index = index
            _key = key
            _value = value
        End Sub
    End Class
End Class
