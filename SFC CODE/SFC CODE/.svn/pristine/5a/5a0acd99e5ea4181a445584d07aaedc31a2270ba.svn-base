Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports LXWarehouseManage
Imports System.Windows.Forms

#Region "Old"
'Public Class FrmRunCardHeaderEdit
'    Sub New(ByVal action As String, ByVal dataGridViewRow As DataGridViewRow)

'        ' 此调用是 Windows 窗体设计器所必需的。
'        InitializeComponent()

'        ' 在 InitializeComponent() 调用之后添加任何初始化。
'        Me._action = action
'        Me._gridViewRow = dataGridViewRow

'    End Sub

'#Region "属性"

'#Region "Version"
'    Private _version As String
'    Public Property Version() As String
'        Get
'            Return _version
'        End Get
'        Set(ByVal value As String)
'            _version = value
'        End Set
'    End Property
'#End Region

'#Region "GridViewRow"
'    Private _gridViewRow As DataGridViewRow
'    Public ReadOnly Property GridViewRow() As DataGridViewRow
'        Get
'            Return _gridViewRow
'        End Get
'    End Property
'#End Region

'#Region "Action"
'    Private _action As String
'    Public ReadOnly Property Action() As String
'        Get
'            Return _action
'        End Get
'    End Property
'#End Region

'#Region "DrawingFileName"
'    Private _DrawingFileName As String
'    Public Property DrawingFileName() As String
'        Get
'            Return _DrawingFileName
'        End Get

'        Set(ByVal Value As String)
'            _DrawingFileName = Value
'        End Set
'    End Property
'#End Region

'#End Region

'#Region "退出"
'    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
'        Me.Close()
'    End Sub
'#End Region

'#Region "btnOK_Click"
'    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
'        Try
'            If CheckInput() = True Then
'                '保存
'                SaveData()
'                '提示
'                MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                '退出
'                Me.DialogResult = Windows.Forms.DialogResult.OK
'                Me.Close()
'            End If
'        Catch ex As Exception
'            SysMessageClass.WriteErrLog(ex, "FrmRunCardHeaderEdit", "btnOK_Click", "sys")
'        End Try
'    End Sub
'#End Region

'#Region "保存数据"
'    Private Sub SaveData()
'        Dim ServerFile As String = ""
'        Dim ID As Integer = CInt(IIf(Me.lblId.Text.Trim = "", 0, Me.lblId.Text.Trim))
'        Dim PartNumber As String = Me.txtPartNumber.Text.Trim
'        Dim PartID As Integer = CInt(IIf(Me.lblPartId.Text.Trim = "", 0, Me.lblPartId.Text.Trim))
'        Dim DrawingVer As String = Me.txtDrawingVer.Text.Trim
'        Dim DrawingFilePath As String = Me.txtDrawingPath.Text.Trim
'        Dim Shape As String = Me.txtShape.Text.Trim
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        '有选择上传
'        If Not String.IsNullOrEmpty(Me.DrawingFileName) Then
'            If Not String.IsNullOrEmpty(DrawingFilePath) Then
'                Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.DrawingFilePath, PartNumber)
'                If System.IO.Directory.Exists(destFilePath) = False Then
'                    Directory.CreateDirectory(destFilePath)
'                End If
'                ServerFile = Path.Combine(destFilePath, Me.DrawingFileName)
'                File.Copy(DrawingFilePath, ServerFile, True)
'            End If
'        Else '未选择上传
'            ServerFile = DrawingFilePath
'        End If
'        '新增
'        Dim StrSql As String = Nothing
'        If Action = "add" Then
'            '写入DB
'            StrSql = "INSERT INTO m_RunCard_t(PartID,DrawingVer,DrawingFilePath,Shape,Status,UserID,InTime) VALUES(" & _
'                     "" & PartID & ",N'" & DrawingVer & "',N'" & ServerFile & "',N'" & Shape & "',0,'" & SysMessageClass.UseId & "',getdate() )"
'        Else
'            '"UserID='" & SysMessageClass.UseId & "',InTime=getdate() WHERE ID=" & ID
'            If Not String.IsNullOrEmpty(Me.Version) AndAlso Me.Version.ToUpper <> txtDrawingVer.Text.Trim.ToUpper Then
'                StrSql = "DECLARE @NEWRUNCARDID INT;" & vbNewLine & _
'                " IF EXISTS(SELECT TOP 1 1 FROM M_RUNCARDOLDVERSION_T WHERE PARTID=" & PartID & " AND DRAWINGVER='" & Me.Version & "')" & vbNewLine & _
'                " BEGIN" & vbNewLine & _
'               " SELECT @NEWRUNCARDID=ID FROM M_RUNCARDOLDVERSION_T WHERE PARTID=" & PartID & " AND DRAWINGVER='" & Me.Version & "'" & vbNewLine & _
'               " DELETE A FROM M_RUNCARDPARTDETAILOLDVERSION_T A,M_RUNCARDDETAILOLDVERSION_T B " & vbNewLine & _
'               " WHERE B.RUNCARDID = @NEWRUNCARDID AND B.ID=A.RUNCARDDETAILID" & vbNewLine & _
'               " DELETE FROM M_RUNCARDDETAILOLDVERSION_T WHERE RUNCARDID=@NEWRUNCARDID " & vbNewLine & _
'               " DELETE FROM M_RUNCARDOLDVERSION_T WHERE ID=@NEWRUNCARDID " & vbNewLine & _
'               " END" & vbNewLine & _
'               " INSERT INTO M_RUNCARDOLDVERSION_T(PARTID,DRAWINGVER,SHAPE,DRAWINGFILEPATH,REMARK,USERID,STATUS,INTIME,MODIFYTIME) SELECT" & vbNewLine & _
'               " PARTID,DRAWINGVER,SHAPE,DRAWINGFILEPATH,REMARK,USERID,STATUS,INTIME,GETDATE() FROM M_RUNCARD_T WHERE ID=" & ID & ";" & vbNewLine & _
'               " SELECT @NEWRUNCARDID =ID FROM M_RUNCARDOLDVERSION_T WHERE PARTID=" & PartID & " AND DRAWINGVER='" & Me.Version & "'" & vbNewLine & _
'               " INSERT INTO M_RUNCARDDETAILOLDVERSION_T(RUNCARDID,STATIONSQ,STATIONID,WORKINGHOURS,EQUIPMENT,PROCESSSTANDARD," & vbNewLine & _
'               " SOPFILEPATH,REMARK,USERID,STATUS,INTIME) SELECT @NEWRUNCARDID,B.STATIONSQ,B.STATIONID,B.WORKINGHOURS,B.EQUIPMENT," & vbNewLine & _
'               " B.PROCESSSTANDARD,B.SOPFILEPATH,B.REMARK,B.USERID,B.STATUS,B.INTIME FROM M_RUNCARDDETAIL_T B " & vbNewLine & _
'               " WHERE B.RUNCARDID =" & ID & ";" & vbNewLine & _
'               " INSERT INTO M_RUNCARDPARTDETAILOLDVERSION_T(RUNCARDDETAILID,PARTID,USERID,INTIME) SELECT C.ID,A.PARTID, A.USERID,A.INTIME FROM " & vbNewLine & _
'               " M_RUNCARDPARTDETAIL_T A,M_RUNCARDDETAIL_T B,M_RUNCARDDETAILOLDVERSION_T C WHERE A.RUNCARDDETAILID=B.ID AND B.RUNCARDID=" & ID & "" & vbNewLine & _
'               " AND B.STATIONID=C.STATIONID AND C.RUNCARDID=@NEWRUNCARDID" & vbNewLine
'            End If
'            If Not String.IsNullOrEmpty(StrSql) Then
'                StrSql += " UPDATE m_RunCard_t SET MODIFYTIME=GETDATE() ,DrawingVer=N'" & DrawingVer & "',STATUS=0,DrawingFilePath=N'" & ServerFile & "',Shape=N'" & Shape & "',UserID='" & SysMessageClass.UseId & "',InTime=getdate()  WHERE ID=" & ID & vbNewLine
'            Else
'                StrSql = " UPDATE m_RunCard_t SET MODIFYTIME=GETDATE() ,DrawingVer=N'" & DrawingVer & "',STATUS=0,DrawingFilePath=N'" & ServerFile & "',Shape=N'" & Shape & "',UserID='" & SysMessageClass.UseId & "',InTime=getdate()  WHERE ID=" & ID & vbNewLine
'            End If
'        End If
'        If Not String.IsNullOrEmpty(StrSql) Then DAL.ExecSql(StrSql)
'    End Sub

'#End Region

'#Region "GetVerFromTiptop"
'    Private Function GetVerFromTiptop(ByVal partNumber As String) As String
'        Dim oracleConn As New OracleDb("")
'        Dim returnValue As String
'        Dim StrSql As String = "SELECT IMA021  FROM " & VbCommClass.VbCommClass.Factory & ".IMA_FILE WHERE IMA01='" & partNumber & "'"
'        returnValue = oracleConn.ExecuteScalar(StrSql).ToString()
'        If returnValue <> "" Then
'            Dim index As Integer = returnValue.LastIndexOf("-")
'            If index >= 0 Then
'                returnValue = returnValue.Substring(index + 1, returnValue.Length - index - 1)
'            Else
'                returnValue = ""
'            End If
'        End If
'        oracleConn = Nothing
'        Return returnValue
'    End Function
'#End Region

'#Region "输入检查"
'    Private Function CheckInput() As Boolean
'        Dim partNumber As String = Me.txtPartNumber.Text.Trim
'        If String.IsNullOrEmpty(partNumber) Then
'            Me.lblMsg.Text = "料件编号不能为空!"
'            Me.txtPartNumber.Focus()
'            Return False
'        End If
'        If String.IsNullOrEmpty(Me.txtDrawingVer.Text.Trim) Then
'            Me.lblMsg.Text = "版本号不能为空!"
'            Me.txtDrawingVer.Focus()
'            Return False
'        Else '跟TT中的版本进行校验
'            Dim verTiptop As String = GetVerFromTiptop(partNumber).ToUpper()
'            If verTiptop <> Me.txtDrawingVer.Text.Trim Then
'                Me.lblMsg.Text = "版本号与Tiptop（" & verTiptop & ")不匹配，请检查!"
'                Me.txtDrawingVer.Focus()
'                Return False
'            End If
'        End If
'        If Action = "add" Then
'            '料件是否已建档
'            If RunCardExists(partNumber) = True Then
'                Me.lblMsg.Text = "料件：" & partNumber & " 工艺流程已存在,请勿重复!"
'                Me.txtPartNumber.Focus()
'                Return False
'            End If
'            'Else
'            '    If Version.ToUpper <> txtDrawingVer.Text.Trim.ToUpper Then
'            '        If RunCardExists(partNumber) = True Then
'            '            Me.lblMsg.Text = "料件：" & partNumber & " 的旧版本工艺流程已存在,请查询后修改!"
'            '            Me.txtPartNumber.Focus()
'            '            Return False
'            '        End If
'            '    End If
'        End If
'        Return True
'    End Function
'#End Region

'#Region "初始化控件"
'    Private Sub IniteControls(ByVal flag As String)

'        Select Case flag
'            Case "add"
'                Me.txtDrawingVer.Enabled = False
'                Me.txtShape.Enabled = False
'                Me.txtDrawingPath.Enabled = False
'                Me.btnOK.Enabled = False
'                Me.btnUpload.Enabled = False

'            Case "modify"
'                If Not Me.GridViewRow Is Nothing Then
'                    Me.lblId.Text = GridViewRow.Cells("ID").Value.ToString
'                    Me.lblPartId.Text = GridViewRow.Cells("PartID").Value.ToString
'                    Me.txtPartNumber.Text = GridViewRow.Cells("料件编号").Value.ToString
'                    'Me.txtDrawingNo.Text = GridViewRow.Cells("图号").Value.ToString
'                    Me.txtDrawingVer.Text = GridViewRow.Cells("版本").Value.ToString
'                    Me.txtShape.Text = GridViewRow.Cells("形态").Value.ToString
'                    'Me.txtPipe.Text = SelectedDataGridRow.Cells("RC_StationID").Value.ToString
'                    Me.txtDrawingPath.Text = GridViewRow.Cells("图纸文件").Value.ToString
'                    '
'                    Me.Version = GridViewRow.Cells("版本").Value.ToString
'                    Me.txtPartNumber.Enabled = False
'                    Me.btnCheckBom.Enabled = False
'                End If
'            Case "checked"
'                Me.txtPartNumber.Enabled = False

'                'Me.txtDrawingNo.Enabled = True
'                Me.txtDrawingVer.Enabled = True
'                Me.txtShape.Enabled = True
'                'Me.txtRemark.Enabled = True
'                Me.txtDrawingPath.Enabled = True
'                Me.btnUpload.Enabled = True
'                Me.btnOK.Enabled = True
'        End Select
'    End Sub
'#End Region

'#Region "检查料件是否已经建档"
'    Private Function RunCardExists(ByVal pn As String) As Boolean
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim StrSql As String = Nothing
'        If Action = "add" Then
'            StrSql = "select 1 from m_RunCard_t(nolock) where PartID in(select ID from m_PartNumber_t(nolock) where PartNumber=N'" & pn & "' and Status=1 )"
'        Else
'            If Me.Version.ToUpper <> txtDrawingVer.Text.Trim.ToUpper Then
'                StrSql = "select 1 from m_RunCardOldVersion_t(nolock) where PartID in(select ID from m_PartNumber_t(nolock) where PartNumber=N'" & pn & "' and Status=1 )"
'            End If
'        End If
'        Using dt As DataTable = DAL.GetDataTable(StrSql)
'            If dt.Rows.Count > 0 Then
'                Return True
'            End If
'        End Using
'        'Dim reader As SqlDataReader = DAL.GetDataReader(StrSql)
'        'If Not reader.HasRows Then
'        '    reader.Close()
'        '    Return False
'        'End If
'        'reader.Close()
'        Return False
'    End Function
'#End Region

'#Region "BOM是否存在"
'    Private Function BomExists(ByVal pn As String) As Boolean
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim StrSql As String = "select 1 from m_Bom_t(nolock) where ParentPartID in(select ID from m_PartNumber_t(nolock) where PartNumber=N'" & pn & "' and Status=1 )"
'        Dim reader As SqlDataReader = DAL.GetDataReader(StrSql)
'        If Not reader.HasRows Then
'            reader.Close()
'            Return False
'        End If
'        reader.Close()
'        Return True
'    End Function
'#End Region

'#Region "获取料件ID"
'    Private Function GetPartID(ByVal pn As String) As Integer
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Dim StrSql As String = "select ID from m_PartNumber_t(nolock) where PartNumber=N'" & pn & "' and Status=1 "
'        Dim dt As DataTable = DAL.GetDataTable(StrSql)
'        If dt.Rows.Count > 0 Then
'            Return CInt(dt.Rows(0)(0).ToString)
'        Else
'            Return 0
'        End If
'    End Function
'#End Region

'#Region "btnCheckBom_Click"
'    Private Sub btnCheckBom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckBom.Click
'        Try
'            Dim partNumber As String = Me.txtPartNumber.Text.Trim
'            If String.IsNullOrEmpty(partNumber) Then
'                lblMsg.Text = "料件编号不能为空!"
'                Me.txtPartNumber.Focus()
'                Exit Sub
'            End If
'            '下载BOM
'            If BomExists(partNumber) = False Then
'                Dim msg As String = ""
'                If DownloadBom(partNumber, msg) = False Then
'                    Me.lblMsg.Text = msg
'                    Exit Sub
'                End If
'            End If
'            '料件ID
'            lblPartId.Text = GetPartID(partNumber)
'            '设置可编辑状态
'            IniteControls("checked")
'        Catch ex As Exception
'            SysMessageClass.WriteErrLog(ex, "FrmRunCardHeaderEdit", " btnCheckBom_Click", "sys")
'        End Try
'    End Sub
'#End Region

'#Region "下载BOM"
'    Private Function DownloadBom(ByVal pn As String, ByRef msg As String) As Boolean
'        Dim oracleConn As New OracleDb("")
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            Dim dt As New DataTable
'            Dim sqlWrite As String = ""
'            Dim StrSql As String = "SELECT A.BMB01 ParentPN,B.IMA02 ParentDesc,B.IMA021 ParentDesc1,B.IMA021 ParentDesc1, A.BMB03 ChildPN,C.IMA02 ChildDesc,C.IMA021 ChildDesc1,A.BMB06 Qty,A.BMB19 Extensible,A.BMB04 EffectiveDate,A.BMB05 as ExpirationDate  " & _
'                                   "FROM " & VbCommClass.VbCommClass.Factory & ".BMB_FILE A," & VbCommClass.VbCommClass.Factory & ".IMA_FILE B," & VbCommClass.VbCommClass.Factory & ".IMA_FILE C " & _
'                                   "WHERE A.BMB01='" & pn & "' AND A.BMB01=B.IMA01 AND A.BMB03=C.IMA01 AND  SYSDATE BETWEEN A.BMB04 AND to_date(to_char(nvl(A.BMB05,SYSDATE),'yyyy-mm-dd hh24:mi:ss'),'yyyy-mm-dd hh24:mi:ss')  "
'            dt = oracleConn.ExecuteQuery(StrSql).Tables(0)
'            If dt.Rows.Count <= 0 Then
'                msg = "ERP 中找不到料件""" & pn & """ 信息"
'                Return False
'            End If
'            '
'            Dim ParentPN As String = dt.Rows(0)("ParentPN").ToString().Replace("'", "''")
'            Dim ParentDesc As String = dt.Rows(0)("ParentDesc").ToString().Replace("'", "''")
'            Dim ParentDesc1 As String = dt.Rows(0)("ParentDesc1").ToString().Replace("'", "''")

'            Dim UserID As String = VbCommClass.VbCommClass.UseId
'            sqlWrite = "DECLARE @ParentID INT;SELECT @ParentID=ID FROM m_PartNumber_t(nolock) WHERE PartNumber='" & ParentPN & "'; " & _
'                       "IF @ParentID IS NULL BEGIN " & _
'                       "INSERT INTO m_PartNumber_t(PartNumber,Description,Description1,Status,UserID,InTime) VALUES(N'" & ParentPN & "',N'" & ParentDesc & "',N'" & ParentDesc1 & "',1,'" & UserID & "',getdate() ); " & _
'                       "SET @ParentID=SCOPE_IDENTITY(); END "
'            '
'            sqlWrite = sqlWrite & vbNewLine & " DELETE m_Bom_t WHERE PARENTPARTID=@ParentID "
'            For Each row As DataRow In dt.Rows
'                Dim pos As Integer = row("ParentDesc1").ToString.LastIndexOf("-")
'                Dim version As String = IIf(pos = -1, "", row("ParentDesc1").ToString.Substring(pos + 1, Len(row("ParentDesc1").ToString) - pos - 1))
'                sqlWrite = sqlWrite & vbNewLine & "IF NOT EXISTS(SELECT 1 FROM m_PartNumber_t(nolock) WHERE PartNumber=N'" & row("ChildPN").ToString.Replace("'", "''") & "' )" & _
'                           "    BEGIN " & _
'                           "        INSERT INTO m_PartNumber_t(PartNumber,Description,Description1,Status,UserID,InTime) VALUES(N'" & row("ChildPN").ToString.Replace("'", "''") & "',N'" & row("ChildDesc").ToString.Replace("'", "''") & "',N'" & row("ChildDesc1").ToString.Replace("'", "''") & "',1,'" & UserID & "',getdate() ) " & _
'                           "        INSERT INTO m_Bom_t(ParentPartID,PartID,Qty,Extensible,EffectiveDate,ExpirationDate,Status,UserID,InTime,Version,Format) VALUES(@ParentID,SCOPE_IDENTITY()," & CDbl(row("Qty").ToString) & ",'" & IIf(row("Extensible").ToString = "3", "Y", "N") & "','" & row("EffectiveDate").ToString & "','" & row("ExpirationDate").ToString & "',1,'" & UserID & "',getdate(),N'" & version & "',N'" & row("ParentDesc1").ToString.Replace("'", "''") & "' )" & _
'                           "    END ELSE BEGIN " & _
'                           "        INSERT INTO m_Bom_t(ParentPartID,PartID,Qty,Extensible,EffectiveDate,ExpirationDate,Status,UserID,InTime,Version,Format) SELECT @ParentID,ID," & CDbl(row("Qty").ToString) & ",'" & IIf(row("Extensible").ToString = "3", "Y", "N") & "','" & row("EffectiveDate").ToString & "','" & row("ExpirationDate").ToString & "',1,'" & UserID & "',getdate(), '" & version & "',N'" & row("ParentDesc1").ToString.Replace("'", "''") & "'  FROM m_PartNumber_t(nolock) WHERE PartNumber=N'" & row("ChildPN").ToString.Replace("'", "''") & "' " & _
'                           "    END "
'            Next
'            'sqlWrite = sqlWrite & vbNewLine & "COMMIT TRANSACTION END TRY " & _
'            '               "BEGIN CATCH " & _
'            '               "    IF @@TRANCOUNT>0  ROLLBACK TRANSACTION ;RAISERROR (N'BOM 下载异常',16, 1) WITH NOWAIT ;" & _
'            '               "END CATCH "
'            DAL.ExecSql(sqlWrite)
'            Return True
'        Catch ex As Exception
'            Throw ex
'        Finally
'            oracleConn = Nothing
'            DAL = Nothing
'        End Try
'    End Function
'#End Region

'#Region "文件上传"
'    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
'        btnUpload.Enabled = False
'        Me.DrawingFileName = ""
'        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"
'        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
'        If result = System.Windows.Forms.DialogResult.OK Then
'            Cursor.Current = Cursors.WaitCursor
'            Me.txtDrawingPath.Text = OpenFileDialog1.FileName
'            Me.DrawingFileName = OpenFileDialog1.SafeFileName
'            Cursor.Current = Cursors.Default
'        End If
'        btnUpload.Enabled = True
'    End Sub
'#End Region

'#Region "TAB 处理"
'    Private Sub FrmRunCardHeaderEdit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
'        If Asc(e.KeyChar) = 13 Then
'            SendKeys.Send("{TAB}")
'        End If
'    End Sub
'#End Region

'#Region "FrmRunCardHeaderEdit_Load"
'    Private Sub FrmRunCardHeaderEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Try
'            lblMsg.Text = ""
'            lblId.Text = ""
'            lblPartId.Text = ""

'            IniteControls(Me.Action)
'            'If Me.Action = "modify" Then
'            '    IniteControls(Action)
'            'Else
'            '    IniteControls("add")
'            'End If
'        Catch ex As Exception
'            SysMessageClass.WriteErrLog(ex, "FrmRunCardHeaderEdit", "FrmRunCardHeaderEdit_Load", "WIPS")
'        End Try
'    End Sub
'#End Region


'End Class
#End Region

Public Class FrmRunCardHeaderEdit
    Sub New(ByVal action As String, ByVal dataGridViewRow As DataGridViewRow)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._action = action
        Me._gridViewRow = dataGridViewRow

    End Sub

#Region "属性"

#Region "Version"
    Private _version As String
    Public Property Version() As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property
#End Region

#Region "GridViewRow"
    Private _gridViewRow As DataGridViewRow
    Public ReadOnly Property GridViewRow() As DataGridViewRow
        Get
            Return _gridViewRow
        End Get
    End Property
#End Region

#Region "Action"
    Private _action As String
    Public ReadOnly Property Action() As String
        Get
            Return _action
        End Get
    End Property
#End Region

#Region "DrawingFileName"
    Private _DrawingFileName As String
    Public Property DrawingFileName() As String
        Get
            Return _DrawingFileName
        End Get

        Set(ByVal Value As String)
            _DrawingFileName = Value
        End Set
    End Property
#End Region

#End Region

#Region "退出"
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region

#Region "btnOK_Click"
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If CheckInput() = True Then
                '保存
                SaveData()
                '提示
                MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '退出
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardHeaderEdit", "btnOK_Click", "sys")
        End Try
    End Sub
#End Region

#Region "保存数据"
    Private Sub SaveData()
        Dim ServerFile As String = ""
        Dim ID As Integer = CInt(IIf(Me.lblId.Text.Trim = "", 0, Me.lblId.Text.Trim))
        Dim PartNumber As String = Me.txtPartNumber.Text.Trim
        Dim PartID As Integer = CInt(IIf(Me.lblPartId.Text.Trim = "", 0, Me.lblPartId.Text.Trim))
        Dim DrawingVer As String = Me.txtDrawingVer.Text.Trim
        Dim DrawingFilePath As String = Me.txtDrawingPath.Text.Trim
        Dim Shape As String = Me.txtShape.Text.Trim
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        '有选择上传
        If Not String.IsNullOrEmpty(Me.DrawingFileName) Then
            If Not String.IsNullOrEmpty(DrawingFilePath) Then
                Dim destFilePath As String = Path.Combine(VbCommClass.VbCommClass.DrawingFilePath, PartNumber)
                If System.IO.Directory.Exists(destFilePath) = False Then
                    Directory.CreateDirectory(destFilePath)
                End If
                ServerFile = Path.Combine(destFilePath, Me.DrawingFileName)
                File.Copy(DrawingFilePath, ServerFile, True)
            End If
        Else '未选择上传
            ServerFile = DrawingFilePath
        End If
        '新增
        Dim StrSql As String = Nothing
        If Action = "add" Then
            '写入DB
            StrSql = "INSERT INTO m_RunCard_t(PartID,DrawingVer,DrawingFilePath,Shape,Status,UserID,InTime,PARTNUMBER) VALUES(" & _
                     "" & PartID & ",N'" & DrawingVer & "',N'" & ServerFile & "',N'" & Shape & "',0,'" & SysMessageClass.UseId & "',getdate(),'" & PartNumber & "' )"
        Else
            '"UserID='" & SysMessageClass.UseId & "',InTime=getdate() WHERE ID=" & ID
            If Not String.IsNullOrEmpty(Me.Version) AndAlso Me.Version.ToUpper <> txtDrawingVer.Text.Trim.ToUpper Then
                StrSql = "DECLARE @NEWRUNCARDID INT;" & vbNewLine & _
                " IF EXISTS(SELECT TOP 1 1 FROM M_RUNCARDOLDVERSION_T WHERE PARTID=" & PartID & " AND DRAWINGVER='" & Me.Version & "')" & vbNewLine & _
                " BEGIN" & vbNewLine & _
               " SELECT @NEWRUNCARDID=ID FROM M_RUNCARDOLDVERSION_T WHERE PARTID=" & PartID & " AND DRAWINGVER='" & Me.Version & "'" & vbNewLine & _
               " DELETE A FROM M_RUNCARDPARTDETAILOLDVERSION_T A,M_RUNCARDDETAILOLDVERSION_T B " & vbNewLine & _
               " WHERE B.RUNCARDID = @NEWRUNCARDID AND B.ID=A.RUNCARDDETAILID" & vbNewLine & _
               " DELETE FROM M_RUNCARDDETAILOLDVERSION_T WHERE RUNCARDID=@NEWRUNCARDID " & vbNewLine & _
               " DELETE FROM M_RUNCARDOLDVERSION_T WHERE ID=@NEWRUNCARDID " & vbNewLine & _
               " END" & vbNewLine & _
               " INSERT INTO M_RUNCARDOLDVERSION_T(PARTID,DRAWINGVER,SHAPE,DRAWINGFILEPATH,REMARK,USERID,STATUS,INTIME,MODIFYTIME,PARTNUMBER) SELECT" & vbNewLine & _
               " PARTID,DRAWINGVER,SHAPE,DRAWINGFILEPATH,REMARK,USERID,STATUS,INTIME,GETDATE(),'" & PartNumber & "' FROM M_RUNCARD_T WHERE ID=" & ID & ";" & vbNewLine & _
               " SELECT @NEWRUNCARDID =ID FROM M_RUNCARDOLDVERSION_T WHERE PARTID=" & PartID & " AND DRAWINGVER='" & Me.Version & "'" & vbNewLine & _
               " INSERT INTO M_RUNCARDDETAILOLDVERSION_T(RUNCARDID,STATIONSQ,STATIONID,WORKINGHOURS,EQUIPMENT,PROCESSSTANDARD," & vbNewLine & _
               " SOPFILEPATH,REMARK,USERID,STATUS,INTIME,PARTNUMBER,NEWPROCESSSTANDARD) SELECT @NEWRUNCARDID,B.STATIONSQ,B.STATIONID,B.WORKINGHOURS,B.EQUIPMENT," & vbNewLine & _
               " B.PROCESSSTANDARD,B.SOPFILEPATH,B.REMARK,B.USERID,B.STATUS,B.INTIME,'" & PartNumber & "',B.NEWPROCESSSTANDARD FROM M_RUNCARDDETAIL_T B " & vbNewLine & _
               " WHERE B.RUNCARDID =" & ID & ";" & vbNewLine & _
               " INSERT INTO M_RUNCARDPARTDETAILOLDVERSION_T(RUNCARDDETAILID,PARTID,USERID,INTIME,PARTNUMBER) SELECT C.ID,A.PARTID, A.USERID,A.INTIME,'" & PartNumber & "' FROM " & vbNewLine & _
               " M_RUNCARDPARTDETAIL_T A,M_RUNCARDDETAIL_T B,M_RUNCARDDETAILOLDVERSION_T C WHERE A.RUNCARDDETAILID=B.ID AND B.RUNCARDID=" & ID & "" & vbNewLine & _
               " AND B.STATIONID=C.STATIONID AND C.RUNCARDID=@NEWRUNCARDID" & vbNewLine
            End If
            If Not String.IsNullOrEmpty(StrSql) Then
                StrSql += " UPDATE m_RunCard_t SET MODIFYTIME=GETDATE() ,DrawingVer=N'" & DrawingVer & "',STATUS=0,DrawingFilePath=N'" & ServerFile & "',Shape=N'" & Shape & "',UserID='" & SysMessageClass.UseId & "',InTime=getdate()  WHERE ID=" & ID & vbNewLine
            Else
                StrSql = " UPDATE m_RunCard_t SET MODIFYTIME=GETDATE() ,DrawingVer=N'" & DrawingVer & "',STATUS=0,DrawingFilePath=N'" & ServerFile & "',Shape=N'" & Shape & "',UserID='" & SysMessageClass.UseId & "',InTime=getdate()  WHERE ID=" & ID & vbNewLine
            End If
        End If
        If Not String.IsNullOrEmpty(StrSql) Then DAL.ExecSql(StrSql)
    End Sub

#End Region

#Region "GetVerFromTiptop"
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
#End Region

#Region "输入检查"
    Private Function CheckInput() As Boolean
        Dim partNumber As String = Me.txtPartNumber.Text.Trim
        If String.IsNullOrEmpty(partNumber) Then
            Me.lblMsg.Text = "料件编号不能为空!"
            Me.txtPartNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(Me.txtDrawingVer.Text.Trim) Then
            Me.lblMsg.Text = "版本号不能为空!"
            Me.txtDrawingVer.Focus()
            Return False
        Else '跟TT中的版本进行校验
            Dim verTiptop As String = GetVerFromTiptop(partNumber).ToUpper()
            If verTiptop <> Me.txtDrawingVer.Text.Trim Then
                Me.lblMsg.Text = "版本号与Tiptop（" & verTiptop & ")不匹配，请检查!"
                Me.txtDrawingVer.Focus()
                Return False
            End If
        End If
        If Action = "add" Then
            '料件是否已建档
            If RunCardExists(partNumber) = True Then
                Me.lblMsg.Text = "料件：" & partNumber & " 工艺流程已存在,请勿重复!"
                Me.txtPartNumber.Focus()
                Return False
            End If
            'Else
            '    If Version.ToUpper <> txtDrawingVer.Text.Trim.ToUpper Then
            '        If RunCardExists(partNumber) = True Then
            '            Me.lblMsg.Text = "料件：" & partNumber & " 的旧版本工艺流程已存在,请查询后修改!"
            '            Me.txtPartNumber.Focus()
            '            Return False
            '        End If
            '    End If
        End If
        Return True
    End Function
#End Region

#Region "初始化控件"
    Private Sub IniteControls(ByVal flag As String)

        Select Case flag
            Case "add"
                Me.txtDrawingVer.Enabled = False
                Me.txtShape.Enabled = False
                Me.txtDrawingPath.Enabled = False
                Me.btnOK.Enabled = False
                Me.btnUpload.Enabled = False

            Case "modify"
                If Not Me.GridViewRow Is Nothing Then
                    Me.lblId.Text = GridViewRow.Cells("ID").Value.ToString
                    Me.lblPartId.Text = GridViewRow.Cells("PartID").Value.ToString
                    Me.txtPartNumber.Text = GridViewRow.Cells("料件编号").Value.ToString
                    'Me.txtDrawingNo.Text = GridViewRow.Cells("图号").Value.ToString
                    Me.txtDrawingVer.Text = GridViewRow.Cells("版本").Value.ToString
                    Me.txtShape.Text = GridViewRow.Cells("形态").Value.ToString
                    'Me.txtPipe.Text = SelectedDataGridRow.Cells("RC_StationID").Value.ToString
                    Me.txtDrawingPath.Text = GridViewRow.Cells("图纸文件").Value.ToString
                    '
                    Me.Version = GridViewRow.Cells("版本").Value.ToString
                    Me.txtPartNumber.Enabled = False
                    Me.btnCheckBom.Enabled = False
                End If
            Case "checked"
                Me.txtPartNumber.Enabled = False

                'Me.txtDrawingNo.Enabled = True
                Me.txtDrawingVer.Enabled = True
                Me.txtShape.Enabled = True
                'Me.txtRemark.Enabled = True
                Me.txtDrawingPath.Enabled = True
                Me.btnUpload.Enabled = True
                Me.btnOK.Enabled = True
        End Select
    End Sub
#End Region

#Region "检查料件是否已经建档"
    Private Function RunCardExists(ByVal pn As String) As Boolean
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = Nothing
        If Action = "add" Then
            StrSql = "select 1 from m_RunCard_t(nolock) where PartID in(select ID from M_RUNCARDPARTNUMBER_T(nolock) where PartNumber=N'" & pn & "' and Status=1 )"
        Else
            If Me.Version.ToUpper <> txtDrawingVer.Text.Trim.ToUpper Then
                StrSql = "select 1 from m_RunCardOldVersion_t(nolock) where PartID in(select ID from M_RUNCARDPARTNUMBER_T(nolock) where PartNumber=N'" & pn & "' and Status=1 )"
            End If
        End If
        Using dt As DataTable = DAL.GetDataTable(StrSql)
            If dt.Rows.Count > 0 Then
                Return True
            End If
        End Using
        'Dim reader As SqlDataReader = DAL.GetDataReader(StrSql)
        'If Not reader.HasRows Then
        '    reader.Close()
        '    Return False
        'End If
        'reader.Close()
        Return False
    End Function
#End Region

#Region "BOM是否存在"
    Private Function BomExists(ByVal pn As String) As Boolean
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = "select 1 from M_RUNCARDBOMINFO_T(nolock) where ParentPartID in(select ID from M_RUNCARDPARTNUMBER_T(nolock) where PartNumber=N'" & pn & "' and Status=1 )"
        Dim reader As SqlDataReader = DAL.GetDataReader(StrSql)
        If Not reader.HasRows Then
            reader.Close()
            Return False
        End If
        reader.Close()
        Return True
    End Function
#End Region

#Region "获取料件ID"
    Private Function GetPartID(ByVal pn As String) As Integer
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim StrSql As String = "select ID from M_RUNCARDPARTNUMBER_T(nolock) where PartNumber=N'" & pn & "' and Status=1 "
        Dim dt As DataTable = DAL.GetDataTable(StrSql)
        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows(0)(0).ToString)
        Else
            Return 0
        End If
    End Function
#End Region

#Region "btnCheckBom_Click"
    Private Sub btnCheckBom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckBom.Click
        Try
            Dim partNumber As String = Me.txtPartNumber.Text.Trim
            If String.IsNullOrEmpty(partNumber) Then
                lblMsg.Text = "料件编号不能为空!"
                Me.txtPartNumber.Focus()
                Exit Sub
            End If
            '下载BOM
            If BomExists(partNumber) = False Then
                Dim msg As String = ""
                If DownloadBom(partNumber, msg) = False Then
                    Me.lblMsg.Text = msg
                    Exit Sub
                End If
            End If
            '料件ID
            lblPartId.Text = GetPartID(partNumber)
            '设置可编辑状态
            IniteControls("checked")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardHeaderEdit", " btnCheckBom_Click", "sys")
        End Try
    End Sub
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

#Region "文件上传"
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        btnUpload.Enabled = False
        Me.DrawingFileName = ""
        'OpenFileDialog1.Filter = "所有文件(*.*)|*.*"
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            Me.txtDrawingPath.Text = OpenFileDialog1.FileName
            Me.DrawingFileName = OpenFileDialog1.SafeFileName
            Cursor.Current = Cursors.Default
        End If
        btnUpload.Enabled = True
    End Sub
#End Region

#Region "TAB 处理"
    Private Sub FrmRunCardHeaderEdit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region

#Region "FrmRunCardHeaderEdit_Load"
    Private Sub FrmRunCardHeaderEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lblMsg.Text = ""
            lblId.Text = ""
            lblPartId.Text = ""

            IniteControls(Me.Action)
            'If Me.Action = "modify" Then
            '    IniteControls(Action)
            'Else
            '    IniteControls("add")
            'End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardHeaderEdit", "FrmRunCardHeaderEdit_Load", "WIPS")
        End Try
    End Sub
#End Region


End Class