Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports LXWarehouseManage

#Region "Old"
'Public Class FrmRunCardCopy

'    Private _RCPartID As Integer
'    Private _RCPartNumber As String

'#Region "PartID"
'    Public Property RCPartID() As Integer
'        Get
'            Return _RCPartID
'        End Get

'        Set(ByVal Value As Integer)
'            _RCPartID = Value
'        End Set
'    End Property
'#End Region

'#Region "PartNumber"
'    Public Property RCPartNumber() As String
'        Get
'            Return _RCPartNumber
'        End Get

'        Set(ByVal Value As String)
'            _RCPartNumber = Value
'        End Set
'    End Property
'#End Region

'    Private Sub FrmRunCardCopy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        '初始化
'        Inite()
'    End Sub

'    Private Sub Inite()
'        Me.txtOldPart.Text = Me.RCPartNumber
'        Me.txtOldPart.ReadOnly = True
'        Me.txtNewPart.Focus()
'        Me.lblMsg.Text = ""
'        Me.lblMsg.Visible = False

'    End Sub

'    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
'        Me.Close()
'    End Sub

'    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
'        'Clear
'        Me.lblMsg.Text = ""
'        Me.lblMsg.Visible = True
'        'Check
'        If Me.txtNewPart.Text.Trim = "" Then
'            Me.lblMsg.Text = "新料号不能为空 O_O"
'            Exit Sub
'        End If
'        If Me.txtOldPart.Text.Trim = Me.txtNewPart.Text.Trim Then
'            Me.lblMsg.Text = "新料号不可与旧料号相 O_O"
'            Exit Sub
'        End If
'        'Copy
'        Dim strMsg As String = ""
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            '参数定义
'            Dim p As New SqlClient.SqlParameter
'            Dim param1 As New SqlParameter("@OldPN", SqlDbType.NVarChar, 50, ParameterDirection.Input)
'            Dim param2 As New SqlParameter("@NewPN", SqlDbType.NVarChar, 50, ParameterDirection.Input)
'            Dim param3 As New SqlParameter("@UserID", SqlDbType.NVarChar, 50, ParameterDirection.Input)
'            Dim param4 As New SqlParameter("@ErrMsg", SqlDbType.NVarChar, 200)
'            '参数赋值
'            param1.Value = Me.RCPartNumber
'            param2.Value = Me.txtNewPart.Text.Trim
'            param3.Value = SysMessageClass.UseId
'            param4.Direction = ParameterDirection.Output '?指定
'            param4.Value = ""
'            Dim Paramters As SqlParameter() = Nothing
'            Paramters = New SqlParameter() {param1, param2, param3, param4}
'            '执行SP
'            DAL.ExecuteNonQureyByProc("udpCopyRunCard", Paramters)
'            If Not String.IsNullOrEmpty(param4.Value.ToString()) Then
'                Me.lblMsg.Text = param4.Value.ToString()
'                Exit Sub
'            End If
'            MessageBox.Show("复制成功^_^ ")
'            Me.DialogResult = Windows.Forms.DialogResult.OK
'            Me.Close()
'        Catch ex As Exception
'            SysMessageClass.WriteErrLog(ex, "FrmRunCardCopy", "btnOK_Click", "sys")
'        Finally
'            DAL = Nothing
'        End Try
'    End Sub
'End Class
#End Region
Public Class FrmRunCardCopy

    Private _RCPartID As Integer
    Private _RCPartNumber As String

#Region "PartID"
    Public Property RCPartID() As Integer
        Get
            Return _RCPartID
        End Get

        Set(ByVal Value As Integer)
            _RCPartID = Value
        End Set
    End Property
#End Region

#Region "PartNumber"
    Public Property RCPartNumber() As String
        Get
            Return _RCPartNumber
        End Get

        Set(ByVal Value As String)
            _RCPartNumber = Value
        End Set
    End Property
#End Region

    Private Sub FrmRunCardCopy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化
        Inite()
    End Sub

    Private Sub Inite()
        Me.txtOldPart.Text = Me.RCPartNumber
        Me.txtOldPart.ReadOnly = True
        Me.txtNewPart.Focus()
        Me.lblMsg.Text = ""
        Me.lblMsg.Visible = False

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub



    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Clear
        Me.lblMsg.Text = ""
        Me.lblMsg.Visible = True
        'Check
        If Me.txtNewPart.Text.Trim = "" Then
            Me.lblMsg.Text = "新料号不能为空 O_O"
            Exit Sub
        End If
        If Me.txtOldPart.Text.Trim = Me.txtNewPart.Text.Trim Then
            Me.lblMsg.Text = "新料号不可与旧料号相 O_O"
            Exit Sub
        End If
        If PnAlreadyExists() Then
            Me.lblMsg.Text = "新料号流程卡已经存在"
            Exit Sub
        End If

        If Not CheckVersion() Then
            Me.lblMsg.Text = Me.lblMsg.Text & ",检查版本失败!"
            Exit Sub
        End If

        'Copy
        Dim strMsg As String = ""
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            '参数定义
            Dim p As New SqlClient.SqlParameter
            Dim param1 As New SqlParameter("@OldPN", SqlDbType.NVarChar, 50, ParameterDirection.Input)
            Dim param2 As New SqlParameter("@NewPN", SqlDbType.NVarChar, 50, ParameterDirection.Input)
            Dim param5 As New SqlParameter("@NewPNVersion", SqlDbType.NVarChar, 50, ParameterDirection.Input)
            Dim param3 As New SqlParameter("@UserID", SqlDbType.NVarChar, 50, ParameterDirection.Input)
            Dim param4 As New SqlParameter("@ErrMsg", SqlDbType.NVarChar, 200)
            '参数赋值
            param1.Value = Me.RCPartNumber
            param2.Value = Me.txtNewPart.Text.Trim
            param3.Value = SysMessageClass.UseId
            param4.Direction = ParameterDirection.Output '?指定
            param4.Value = ""
            param5.Value = Me.txtVersion.Text.Trim
            Dim Paramters As SqlParameter() = Nothing
            Paramters = New SqlParameter() {param1, param2, param5, param3, param4}
            '执行SP
            DAL.ExecuteNonQureyByProc("udpCopyRunCard", Paramters)
            If Not String.IsNullOrEmpty(param4.Value.ToString()) Then
                Me.lblMsg.Text = param4.Value.ToString()
                Exit Sub
            End If
            MessageBox.Show("复制成功^_^ ")
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardCopy", "btnOK_Click", "sys")
        Finally
            DAL = Nothing
        End Try
    End Sub

    Private Function PnAlreadyExists() As Boolean
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim sql As String = "SELECT PARTNUMBER FROM M_RUNCARD_T WHERE PARTNUMBER='" & Me.txtNewPart.Text.Trim & "'"
        Using dt As DataTable = DAL.GetDataTable(sql)
            If dt.Rows.Count > 0 Then Return True
        End Using
        Return False
    End Function

    ' Private Sub txtVersion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVersion.LostFocus
    Private Function CheckVersion() As Boolean
        Dim txtTiptopVersion As String = ""

        Try

            If Me.txtVersion.Text = String.Empty Then
                Me.txtVersion.Focus()
                Me.lblMsg.Text = " 请输入版本号!"
                Return False
            End If

            '防呆，能指出错误的New PN 在tiptop 中不存在.
            If BomExists(Me.txtNewPart.Text.Trim) = False Then
                Dim msg As String = ""
                If DownloadBom(Me.txtNewPart.Text.Trim, msg) = False Then
                    Me.lblMsg.Text = msg
                    Return False
                End If
            End If

            'Check Version
            txtTiptopVersion = GetVerFromTiptop(Me.txtNewPart.Text)

            If Me.txtVersion.Text.Trim <> txtTiptopVersion Then
                Me.lblMsg.Text = "版本不一致,TipTop 版本为: " & txtTiptopVersion & " "
                ' Me.Label4.Text = "版本不一致,TipTop 版本为: " & txtTiptopVersion & " "
                Me.txtVersion.Focus()
                Return False
            End If

            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetVerFromTiptop(ByVal partNumber As String) As String
        Dim oracleConn As New OracleDb("")
        Dim returnValue As String
        Dim StrSql As String = "SELECT IMA021  FROM " & VbCommClass.VbCommClass.Factory & ".IMA_FILE WHERE IMA01='" & partNumber & "'"
        returnValue = oracleConn.ExecuteScalar(StrSql).ToString()
        If returnValue <> "" Then
            Dim index As Integer = returnValue.LastIndexOf("-")
            If index >= 0 Then
                returnValue = returnValue.Substring(index + 1, returnValue.Length - index - 1)
            Else
                returnValue = ""
            End If
        End If
        oracleConn = Nothing
        Return returnValue
    End Function

#Region "BOM是否存在"
    'Private Function BomExists(ByVal pn As String) As Boolean
    '    Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
    '    Dim StrSql As String = "select 1 from M_RUNCARDBOMINFO_T(nolock) where ParentPartID in(select ID from M_RUNCARDPARTNUMBER_T(nolock) where PartNumber=N'" & pn & "' and Status=1 )"
    '    Dim reader As SqlDataReader = DAL.GetDataReader(StrSql)
    '    If Not reader.HasRows Then
    '        reader.Close()
    '        Return False
    '    End If
    '    reader.Close()
    '    Return True
    'End Function

    Private Function BomExists(ByVal pn As String) As Boolean
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim sql As String = "select 1 from M_RUNCARDBOMINFO_T(nolock) where ParentPartID in(select ID from M_RUNCARDPARTNUMBER_T(nolock) where PartNumber=N'" & pn & "' and Status=1 )"
        Using dt As DataTable = DAL.GetDataTable(sql)
            If dt.Rows.Count > 0 Then Return True
        End Using
        Return False

    End Function
#End Region

#Region "下载BOM"
    Private Function DownloadBom(ByVal pn As String, ByRef msg As String) As Boolean
        Dim oracleConn As New OracleDb("")
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            Dim dt As New DataTable
            Dim sqlWrite As String = ""
            Dim StrSql As String = "SELECT A.BMB01 ParentPN,B.IMA02 ParentDesc,B.IMA021 ParentDesc1,B.IMA021 ParentDesc1, A.BMB03 ChildPN,C.IMA02 ChildDesc,C.IMA021 ChildDesc1,A.BMB06 Qty,A.BMB19 Extensible,A.BMB04 EffectiveDate,A.BMB05 as ExpirationDate  " & _
                                   "FROM " & VbCommClass.VbCommClass.Factory & ".BMB_FILE A," & VbCommClass.VbCommClass.Factory & ".IMA_FILE B," & VbCommClass.VbCommClass.Factory & ".IMA_FILE C " & _
                                   "WHERE A.BMB01='" & pn & "' AND A.BMB01=B.IMA01 AND A.BMB03=C.IMA01 AND  SYSDATE BETWEEN A.BMB04 AND to_date(to_char(nvl(A.BMB05,SYSDATE),'yyyy-mm-dd hh24:mi:ss'),'yyyy-mm-dd hh24:mi:ss')  "
            dt = oracleConn.ExecuteQuery(StrSql).Tables(0)
            If dt.Rows.Count <= 0 Then
                msg = "ERP 中找不到料件""" & pn & """ 信息"
                Return False
            End If
            '
            Dim ParentPN As String = dt.Rows(0)("ParentPN").ToString().Replace("'", "''")
            Dim ParentDesc As String = dt.Rows(0)("ParentDesc").ToString().Replace("'", "''")
            Dim ParentDesc1 As String = dt.Rows(0)("ParentDesc1").ToString().Replace("'", "''")

            Dim UserID As String = VbCommClass.VbCommClass.UseId
            sqlWrite = "DECLARE @ParentID INT;SELECT @ParentID=ID FROM M_RUNCARDPARTNUMBER_T(nolock) WHERE PartNumber='" & ParentPN & "'; " & _
                       "IF @ParentID IS NULL BEGIN " & _
                       "INSERT INTO M_RUNCARDPARTNUMBER_T(PartNumber,Description,Description1,Status,UserID,InTime) VALUES(N'" & ParentPN & "',N'" & ParentDesc & "',N'" & ParentDesc1 & "',1,'" & UserID & "',getdate() ); " & _
                       "SET @ParentID=SCOPE_IDENTITY(); END "
            '
            sqlWrite = sqlWrite & vbNewLine & " DELETE M_RUNCARDBOMINFO_T WHERE PARENTPARTID=@ParentID "
            For Each row As DataRow In dt.Rows
                Dim pos As Integer = row("ParentDesc1").ToString.LastIndexOf("-")
                Dim version As String = IIf(pos = -1, "", row("ParentDesc1").ToString.Substring(pos + 1, Len(row("ParentDesc1").ToString) - pos - 1))
                sqlWrite = sqlWrite & vbNewLine & "IF NOT EXISTS(SELECT 1 FROM M_RUNCARDPARTNUMBER_T(nolock) WHERE PartNumber=N'" & row("ChildPN").ToString.Replace("'", "''") & "' )" & _
                           "    BEGIN " & _
                           "        INSERT INTO M_RUNCARDPARTNUMBER_T(PartNumber,Description,Description1,Status,UserID,InTime) VALUES(N'" & row("ChildPN").ToString.Replace("'", "''") & "',N'" & row("ChildDesc").ToString.Replace("'", "''") & "',N'" & row("ChildDesc1").ToString.Replace("'", "''") & "',1,'" & UserID & "',getdate() ) " & _
                           "        INSERT INTO M_RUNCARDBOMINFO_T(ParentPartID,PartID,Qty,Extensible,EffectiveDate,ExpirationDate,Status,UserID,InTime,Version,Format) VALUES(@ParentID,SCOPE_IDENTITY()," & CDbl(row("Qty").ToString) & ",'" & IIf(row("Extensible").ToString = "3", "Y", "N") & "','" & row("EffectiveDate").ToString & "','" & row("ExpirationDate").ToString & "',1,'" & UserID & "',getdate(),N'" & version & "',N'" & row("ParentDesc1").ToString.Replace("'", "''") & "' )" & _
                           "    END ELSE BEGIN " & _
                           "        INSERT INTO M_RUNCARDBOMINFO_T(ParentPartID,PartID,Qty,Extensible,EffectiveDate,ExpirationDate,Status,UserID,InTime,Version,Format) SELECT @ParentID,ID," & CDbl(row("Qty").ToString) & ",'" & IIf(row("Extensible").ToString = "3", "Y", "N") & "','" & row("EffectiveDate").ToString & "','" & row("ExpirationDate").ToString & "',1,'" & UserID & "',getdate(), '" & version & "',N'" & row("ParentDesc1").ToString.Replace("'", "''") & "'  FROM M_RUNCARDPARTNUMBER_T(nolock) WHERE PartNumber=N'" & row("ChildPN").ToString.Replace("'", "''") & "' " & _
                           "    END "
            Next
            'sqlWrite = sqlWrite & vbNewLine & "COMMIT TRANSACTION END TRY " & _
            '               "BEGIN CATCH " & _
            '               "    IF @@TRANCOUNT>0  ROLLBACK TRANSACTION ;RAISERROR (N'BOM 下载异常',16, 1) WITH NOWAIT ;" & _
            '               "END CATCH "
            DAL.ExecSql(sqlWrite)
            Return True
        Catch ex As Exception
            Throw ex
        Finally
            oracleConn = Nothing
            DAL = Nothing
        End Try
    End Function
#End Region
End Class