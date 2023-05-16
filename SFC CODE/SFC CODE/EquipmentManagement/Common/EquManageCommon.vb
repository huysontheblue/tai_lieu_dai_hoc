Option Strict On
Option Explicit On
Imports System.Windows.Forms
Imports MainFrame.SysCheckData
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports System.Text.RegularExpressions
Imports MainFrame

Public Class EquManageCommon

#Region "取得下拉框"

    ''' <summary>
    ''' 设置课别
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxClass(ByVal ColComboBox As ComboBox)
        BindCombox("exec Proc_GetUserDeptRights '" & VbCommClass.VbCommClass.UseId & "'", ColComboBox, "dqc", "deptid")
    End Sub

    Public Shared Sub BindComboxClassDCS(ByVal ColComboBox As ComboBox)
        If VbCommClass.VbCommClass.IsConSap = "Y" Then
            BindCombox("exec Proc_GetUserDeptRightsDCS '" & VbCommClass.VbCommClass.UseId & "','" & VbCommClass.VbCommClass.PCompany & "','" & VbCommClass.VbCommClass.profitcenter & "'", ColComboBox, "dqc", "deptid")
        Else
            BindCombox("exec Proc_GetUserDeptRightsDCS '" & VbCommClass.VbCommClass.UseId & "','" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'", ColComboBox, "dqc", "deptid")
        End If
    End Sub

    Public Shared Sub BindComboxClass_Consumable(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "SELECT  dqc, deptid FROM m_Dept_t WHERE usey='Y' and EquMy = 'Y' " &
                                GetFatoryIdProfitcenter()

        strSQL = strSQL + " UNION " + " SELECT DISTINCT deptName as dqc, '' as deptid from m_ConsumableLendLog_t  WHERE ISNULL(DeptName,'') <>'' AND deptName NOT IN ( SELECT dqc  FROM m_Dept_t WHERE usey='Y' and EquMy = 'Y'  AND FactoryId='" & VbCommClass.VbCommClass.Factory & "' AND Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "')"

        BindCombox(strSQL, ColComboBox, "dqc", "deptid")
    End Sub

    ''' <summary>
    ''' 设置线别
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <param name="cboClass"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxLine(ByVal ColComboBox As ComboBox, cboClass As String)
        Dim strSQL As String = String.Format("SELECT lineid FROM [deptline_t] where usey='Y' and deptid = '{0}'", cboClass)
        'GetFatoryOther()

        BindCombox(strSQL, ColComboBox, "lineid", "lineid")

    End Sub

    ''' <summary>
    ''' 设置状态
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxStatus(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select value,text from m_BaseData_t where itemkey = 'EqpAppStatus' and status = 1 order by SORT"

        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    ''' <summary>
    ''' 工治具类别--分类
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxCategory(ByVal ColComboBox As ComboBox, Optional type As String = "")
        Dim strSQL As String = "select CODE,CODE+'(' + NAME + ')'NAME from m_EquipmentCategory_t WHERE Status=1 AND TYPE = '{0}'"
        strSQL = String.Format(strSQL, type)

        BindCombox(strSQL, ColComboBox, "NAME", "CODE")
    End Sub

    ''' <summary>
    ''' 处理方式
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxMR(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select value,text from m_BaseData_t where itemkey = 'EqpMaintenanceStatus' and status = 1 order by SORT "

        BindCombox(strSQL, ColComboBox, "text", "value")
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

    Public Shared Function GetNext(str As String) As String
        Dim m As System.Text.RegularExpressions.Match = Regex.Match(str, "^([A-Z]*)([0-9]*)$")

        If m.Success = False Then
            Throw New ArgumentException("无效格式.")
        End If

        Dim strLetter As String = m.Groups(1).Value
        Dim strDigit As String = m.Groups(2).Value

        If String.IsNullOrEmpty(strDigit) = False AndAlso Regex.IsMatch(strDigit, "^9+$") = False Then
            Dim temp As String = (Integer.Parse(strDigit) + 1).ToString().PadLeft(strDigit.Length, CChar("0"))
            temp = strLetter + temp
            Return temp
        Else

            Dim charArr As Char() = strLetter.ToCharArray()
            Dim len As Integer = charArr.Length
            Dim temp As String = Nothing

            For i As Integer = len - 1 To 0 Step -1
                If charArr(i) <> "Z" Then
                    charArr(i) = CChar(ChrW(AscW(charArr(i)) + 1))
                    temp = New String(charArr)
                    Exit For
                End If
                charArr(i) = CChar("A")
            Next

            If (temp Is Nothing) Then
                temp = "A" + New String(charArr)
            End If

            If (temp.Length < str.Length) Then
                temp += New String(CChar("0"), str.Length - temp.Length - 1) + "1"
            End If
            Return temp
        End If
    End Function

    Public Shared Function GetFatoryIdProfitcenter() As String
        Dim strValue As String = String.Empty
        strValue = " AND FactoryId='" & VbCommClass.VbCommClass.Factory & "'"
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + " AND Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'"
        End If
        Return strValue
    End Function

    Public Shared Function GetFatoryProfitcenter() As String
        Dim strValue As String = String.Empty
        strValue = " AND FactoryName='" & VbCommClass.VbCommClass.Factory & "'"
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + " AND Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'"
        End If
        Return strValue
    End Function

    Public Shared Function GetFatoryOther() As String
        Dim strValue As String = String.Empty
        strValue = " AND FactoryID='" & VbCommClass.VbCommClass.Factory & "'"

        Return strValue
    End Function

    Public Shared Function GetFatoryProfileID(table As String) As String
        Dim strValue As String = String.Empty
        strValue = String.Format(" AND {0}.FactoryID='" & VbCommClass.VbCommClass.Factory & "'", table)
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + String.Format(" AND {0}.ProfileID= '" & VbCommClass.VbCommClass.profitcenter & "'", table)
        End If
        Return strValue
    End Function

    Public Shared Function GetFatoryProfitcenter(table As String) As String
        Dim strValue As String = String.Empty
        strValue = String.Format(" AND {0}.FactoryName='" & VbCommClass.VbCommClass.Factory & "'", table)
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + String.Format(" AND {0}.Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'", table)
        End If
        Return strValue
    End Function

    Public Shared Function GetFatoryAndProfitcenter() As String
        Dim strValue As String = String.Empty
        strValue = " AND FactoryName='" & VbCommClass.VbCommClass.Factory & "'"
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + " AND Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'"
        End If
        Return strValue
    End Function

    Public Shared Function GetUserName(ByVal strUserID As String) As String
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT UserName FROM m_Users_t(nolock) Where UserID ='" & strUserID & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetUserName = CStr(o_dt.Rows(0).Item(0))
            Else
                GetUserName = ""
            End If
        End Using
    End Function
    ''' <summary>
    ''' 涵盖所有的 在职人员
    ''' </summary>
    ''' <param name="strInputUserID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetUserName_All(ByVal strInputUserID As String) As String
        GetUserName_All =""
        Dim lsSQL As String = String.Empty

        If IncludeChinese(strInputUserID) Then
            GetUserName_All = strInputUserID
            Return GetUserName_All
        End If

        'SELECT EmpName AS username  FROM m_employeeonjob_t(nolock) WHERE EmpCode ='A041818'
        'UNION 
        'SELECT username  FROM dbo.m_Users_t WHERE userid ='A041818'

        lsSQL = " SELECT  EmpName AS username  FROM m_employeeonjob_t(nolock) WHERE EmpCode ='" & strInputUserID & "'" & _
               " UNION " & _
               " SELECT username  FROM dbo.m_Users_t WHERE userid ='" & strInputUserID & "'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetUserName_All = CStr(o_dt.Rows(0).Item(0))
            Else
                'keep user key in info 
                GetUserName_All = strInputUserID
            End If
        End Using
    End Function

    ''' <summary>
    ''' 判断输入的是否为含有中文
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IncludeChinese(ByVal str As String) As Boolean
        Dim regex As Regex = New Regex("[\u4e00-\u9fa5]")

        If regex.IsMatch(str) Then
            IncludeChinese = True
        Else
            IncludeChinese = False
        End If
        Return IncludeChinese
    End Function

    ''' <summary>
    ''' 取得当前季度
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetQuarter() As Integer
        Dim yy As Integer = 1
        Dim month = DbOperateUtils.GetDataTable("select datepart(month,getdate())").Rows(0)(0).ToString()
        Select Case month
            Case "1", "2", "3"
                Return 1
            Case "4", "5", "6"
                Return 2
            Case "7", "8", "9"
                Return 3
            Case "10", "11", "12"
                Return 4
        End Select
        Return yy
    End Function

    '同步CNC数据
    Public Shared Sub ExecCNCUpdate(equNo As String)
        Try
            Dim strSQL As String = " exec [m_CNCUpdate_MoudleInfo_P] '{0}','{1}' "
            strSQL = String.Format(strSQL, equNo, VbCommClass.VbCommClass.UseId)

            DbOperateUtils.ExecSQL(strSQL)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "ExecUCNCpdate", "ExecUCNCpdate", "EquipmentManagement")
        End Try
    End Sub

    '同步CNC数据
    Public Shared Sub ExecCNCUpdateList(dt As DataTable)
        Try
            Dim strSQL As String
            Dim strSQLs As String = ""
            Dim equNo As String
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                equNo = dt.Rows(rowIndex)("EquipmentNo").ToString
                strSQL = " exec [m_CNCUpdate_MoudleInfo_P] '{0}','{1}' "
                strSQL = String.Format(strSQL, equNo, VbCommClass.VbCommClass.UseId)
                strSQLs = strSQLs + vbNewLine + strSQL
            Next
            DbOperateUtils.ExecSQL(strSQLs)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "ExecCNCUpdateList", "ExecCNCUpdateList", "EquipmentManagement")
        End Try
    End Sub


End Class
