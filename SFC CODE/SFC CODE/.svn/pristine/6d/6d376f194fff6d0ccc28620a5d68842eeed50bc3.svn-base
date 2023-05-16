
'--MES数据转移类库
'--Create by :　马锋
'--Create date :　2015/09/18
'--Ver : V01
'--Update date :  
'--

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports MainFrame
Imports SysBasicClass

#End Region

Public Class GetMesData

    Public Shared Function GetLinkServer(ByVal LinkServerId As String) As DataTable
        Dim dtTemp As DataTable = Nothing
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(LinkServerId)) Then
                strWhere = " AND LinkServerId='" & LinkServerId & "'"
            End If
            strSQL = "SELECT LinkServerId, LinkServerName, LoginUserName, LoginPassword, Rework, StatusFlag, CreateUserId, CONVERT(VARCHAR(32), CreateTime, 120) AS CreateTime FROM m_LinkServer_t WHERE DeleteFlag='0' " & strWhere & " ORDER BY CreateTime DESC"

            dtTemp = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetTableName(ByVal strTableName As String) As DataTable
        Dim dtTemp As DataTable = Nothing
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(strTableName)) Then
                strWhere = " AND name LIKE '%" & strTableName & "%'"
            End If
            strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY NAME) AS RowNumId, name FROM dbo.sysobjects WHERE xtype='u' " & strWhere & " ORDER BY name"
            dtTemp = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetLinkServerQuery(ByVal strLinkeServerName As String) As DataTable
        Dim dtTemp As DataTable = Nothing
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(strLinkeServerName)) Then
                strWhere = " AND LinkServerName LIKE '%" & strLinkeServerName & "%'"
            End If
            strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY LinkServerName) AS RowNumId, LinkServerId, LinkServerName, Rework FROM m_LinkServer_t WHERE StatusFlag='1' " & strWhere & " ORDER BY LinkServerName"
            dtTemp = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetTargetDataBase(ByVal strTargetDataBase As String, ByVal strLinkServerName As String) As DataTable
        Dim dtTemp As DataTable = Nothing
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(strTargetDataBase)) Then
                strWhere = " AND name LIKE '%" & strTargetDataBase & "%'"
            End If

            If (String.IsNullOrEmpty(strLinkServerName)) Then
                strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY name) AS RowNumId, name AS TargetDataBaseName FROM master.sys.databases WHERE DATABASE_ID > 4 " & strWhere & " AND [name]<>DB_NAME() ORDER BY [Name] ASC "
            Else
                strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY name) AS RowNumId, name AS TargetDataBaseName FROM [" & strLinkServerName & "].master.sys.databases WHERE DATABASE_ID > 4 " & strWhere & " AND [name]<>DB_NAME() ORDER BY [Name] ASC "
            End If
            dtTemp = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetMOList(ByVal MoId As String, ByVal strSupportId As String) As DataTable
        Dim dtTemp As DataTable = Nothing
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(MoId)) Then
                strWhere = " AND Moid LIKE '%" & MoId & "%'"
            End If

            If (Not String.IsNullOrEmpty(strSupportId)) AndAlso Not factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
                strWhere = strWhere + " AND cusid='" & strSupportId & "' "
            End If

            strWhere = strWhere + " AND Factory = '" & VbCommClass.VbCommClass.Factory & "'"
            If Not String.IsNullOrEmpty(VbCommClass.VbCommClass.profitcenter) Then
                strWhere = strWhere + " AND profitcenter = '" & VbCommClass.VbCommClass.profitcenter & "'"
            End If

            strSQL = "SELECT TOP 100 Moid, PartID, Moqty, Remark FROM m_Mainmo_t WHERE FinalY='N' " & strWhere & " ORDER BY Createtime DESC"

            dtTemp = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
        End Try
        Return dtTemp
    End Function
    Shared factory As String = "LX53,WANXUN,M02600,JIZHOU,XINYU,LX21,COCRXIN"

    Public Shared Function GetMOSKUStyleList(ByVal MoId As String) As DataTable
        Dim dtTemp As DataTable = Nothing
        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            strSQL = "SELECT MOID, SBarCode, qty FROM m_MOPackingLevel WHERE PackId = 'N' AND DisorderTypeId = 'S' AND MOID='" & MoId & "' ORDER BY Createtime DESC"

            dtTemp = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetSettingSQL(ByVal ParameterCode As String) As String
        Return "SELECT PARAMETER_VALUES, PARAMETER_NAME FROM m_SystemSetting_t WHERE PARAMETER_CODE='" & ParameterCode & "' ORDER BY SYSTEMSETTING_ID ASC"
    End Function

    Public Shared Function GetSettingParameterSQL(ByVal ParameterCode As String) As String
        Return "SELECT PARAMETER_VALUE, PARAMETER_NAME + '[' + PARAMETER_VALUE + ']' AS PARAMETER_NAME FROM m_SettingParameter_t WHERE PARAMETER_MODE='" & ParameterCode & "' ORDER BY ORDERID ASC"
    End Function

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

#Region "获取本地打印机列表"

    Public Shared Sub GetPrintersList(ByVal CboName As ComboBox)
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            CboName.Items.Add(iprt)
        Next
    End Sub

    Public Shared Sub GetPrintersList(ByVal CboName As DataGridViewComboBoxColumn)
        CboName.Items.Clear()
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            CboName.Items.Add(iprt)
        Next
    End Sub

    Public Shared Function CheckPrintersList(ByVal PrintName As String) As Boolean
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            If (iprt.Trim = PrintName) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Shared Function GetMoInfo(ByVal moid As String)
        Dim sql As String = Nothing
        Try
            Dim result As DataTable

            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                result = SapCommon.GetTiptopLotSAP(moid)
            Else
                result = SapCommon.GetTiptopLot(moid)
            End If

            If result.Rows.Count > 0 Then

                sql = " INSERT INTO m_Mainmo_t(Moid,PartID,Cusid,Deptid,lineid,Moqty," & _
                " Typeid, EstateID, Plandate, Createuser, Createtime, FinalY, Finalman, Finaltime, factory, profitcenter, ParentMo, " & _
                        "    VERSION, SeriesID,ORDERNO,Orderseq,DeliveryDate,ScheFinishDate,PO) VALUES(" & _
               " '{0}','{1}','{2}','{3}','{4}','{5}',1,5,GETDATE(),'{6}',GETDATE(),'N',NULL,NULL,'{7}','{8}'," & _
               " '{0}','A','{9}','{10}','{11}','{12}','{13}','{14}')"
                sql = String.Format(sql, moid, result.Rows(0)("sfb05").ToString(), "01", result.Rows(0)("tc_imc03").ToString(), result.Rows(0)("sfb82").ToString(), result.Rows(0)("sfb08").ToString(), VbCommClass.VbCommClass.UseId, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, "029", result.Rows(0)("sfb22").ToString(), result.Rows(0)("sfb221").ToString(), result.Rows(0)("oeb15").ToString(), result.Rows(0)("sfb15").ToString(), result.Rows(0)("OEA10").ToString())
                DbOperateUtils.ExecSQL(sql)
                Return "下载成功"
            Else
                Return "ERP中不存在该工单"
            End If
        Catch ex As Exception
            MessageBox.Show(sql)
            Return "工单下载失败" + ex.Message
        End Try
        Return ""
    End Function



   

#End Region

End Class
