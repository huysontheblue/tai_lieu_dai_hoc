Imports System.Text
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms

#Region "Old"
'Public Class FrmRunCardPartDetail


'    Sub New(ByVal runCardDetailId As Integer, ByVal runCardStationId As Integer, ByVal runCardId As Integer, ByVal runCardPartId As Integer, ByVal isQueryOldVersion As String)

'        ' 此调用是 Windows 窗体设计器所必需的。
'        InitializeComponent()

'        ' 在 InitializeComponent() 调用之后添加任何初始化。
'        Me._runCardId = runCardId
'        Me._runCardPartId = runCardPartId
'        Me._runCardDetailId = runCardDetailId
'        Me._runCardStationId = runCardStationId
'        Me._isQueryOldVersion = isQueryOldVersion

'    End Sub
'#Region "属性"


'#Region "RunCardId"
'    Private _runCardId As String
'    Public ReadOnly Property RunCardId() As Integer
'        Get
'            Return _runCardId
'        End Get
'    End Property
'#End Region

'#Region "RunCardPartId"
'    Private _runCardPartId As Integer
'    Public ReadOnly Property RunCardPartId() As Integer
'        Get
'            Return _runCardPartId
'        End Get
'    End Property
'#End Region

'#Region "RunCardDetailId"
'    Private _runCardDetailId As Integer
'    Private _isQueryOldVersion As String
'    Public ReadOnly Property RunCardDetailId() As Integer
'        Get
'            Return _runCardDetailId
'        End Get
'    End Property
'#End Region

'#Region "RunCardStationID"
'    Private _runCardStationId As Integer
'    Public ReadOnly Property RunCardStationId() As Integer
'        Get
'            Return _runCardStationId
'        End Get

'    End Property
'#End Region

'#End Region



'    Private Sub FrmRunCardPartDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Try
'            BindBomGrid()
'            BindEquipmentGrid()
'        Catch ex As Exception
'            SysMessageClass.WriteErrLog(ex, "FrmRunCardPartDetail", "FrmRunCardPartDetail_Load", "sys")
'        End Try

'    End Sub

'    Private Sub BindBomGrid()
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            Dim StrSql As String = Nothing
'            If _isQueryOldVersion = "false" Then
'                StrSql = "select PN.ID,PN.PartNumber,PN.Description,PN.Description1,Case when T1.PartID IS null then 'N' else 'Y' end  Flag  " & _
'                 "from m_Bom_t(nolock) BM join m_PartNumber_t(nolock) PN on BM.PartID=PN.ID " & _
'                 " left join ( " & _
'                 "select RCP.PartID from  m_RunCard_t(nolock) RC " & _
'                 "join m_RunCardDetail_t(nolock) RCD on RCD.RunCardID=RC.ID " & _
'                 "join m_RunCardPartDetail_t(nolock) RCP on RCP.RunCardDetailID=RCD.ID " & _
'                 "where  RC.ID=" & Me.RunCardId & " and RCD.StationID=" & Me.RunCardStationId & " " & _
'                 ")T1 on T1.PartID=BM.PartID where BM.ParentPartID=" & Me.RunCardPartId
'            Else
'                StrSql = "select PN.ID,PN.PartNumber,PN.Description,PN.Description1,Case when T1.PartID IS null then 'N' else 'Y' end  Flag  " & _
'              "from m_Bom_t(nolock) BM join m_PartNumber_t(nolock) PN on BM.PartID=PN.ID " & _
'              " left join ( " & _
'              "select RCP.PartID from  m_RunCardOldVersion_t(nolock) RC " & _
'              "join m_RunCardDetailOldVersion_t(nolock) RCD on RCD.RunCardID=RC.ID " & _
'              "join m_RunCardPartDetailOldVersion_t(nolock) RCP on RCP.RunCardDetailID=RCD.ID " & _
'              "where  RC.ID=" & Me.RunCardId & " and RCD.StationID=" & Me.RunCardStationId & " " & _
'              ")T1 on T1.PartID=BM.PartID where BM.ParentPartID=" & Me.RunCardPartId
'            End If
'            dgvBomPart.Rows.Clear()
'            Using dt As DataTable = DAL.GetDataTable(StrSql)
'                For Each row As DataRow In dt.Rows
'                    dgvBomPart.Rows.Add(row("Flag").ToString(), row("ID").ToString(), row("PartNumber").ToString(), row("Description").ToString(), row("Description1").ToString())
'                Next
'            End Using
'            dgvBomPart.Columns(1).ReadOnly = True
'            dgvBomPart.Columns(2).ReadOnly = True
'        Catch ex As Exception
'            If Not DAL Is Nothing Then
'                DAL = Nothing
'            End If
'        End Try


'        '"品名"列全屏显示
'        'dgvBomPart.Columns("Bom_Description").AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
'    End Sub

'    Private Sub BindEquipmentGrid(Optional ByVal where As String = "")

'        Dim StrSql As String = ""
'        'Dim reader As SqlClient.SqlDataReader = Nothing
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            '加载Data
'            If _isQueryOldVersion = "false" Then
'                StrSql = "select PN.ID,PN.PartNumber,PN.Description,PN.Description1,Case when T1.PartID IS null then 'N' else 'Y' end  Flag  " & _
'                         "from (select distinct PartID from m_Equipment_t(nolock) ) BM join m_PartNumber_t(nolock) PN on BM.PartID=PN.ID " & _
'                         " left join ( " & _
'                         "select RCP.PartID from  m_RunCard_t(nolock) RC " & _
'                         "join m_RunCardDetail_t(nolock) RCD on RCD.RunCardID=RC.ID " & _
'                         "join m_RunCardPartDetail_t(nolock) RCP on RCP.RunCardDetailID=RCD.ID " & _
'                         "where  RC.PartID=" & Me.RunCardPartId & " and RCD.StationID=" & Me.RunCardStationId & " " & _
'                         ")T1 on T1.PartID=BM.PartID WHERE 1=1 " 'where BM.ParentPartID=" & Me.RCPartID
'            Else
'                StrSql = "select PN.ID,PN.PartNumber,PN.Description,PN.Description1,Case when T1.PartID IS null then 'N' else 'Y' end  Flag  " & _
'                         "from (select distinct PartID from m_Equipment_t(nolock) ) BM join m_PartNumber_t(nolock) PN on BM.PartID=PN.ID " & _
'                         " left join ( " & _
'                         "select RCP.PartID from  m_RunCardOldVersion_t(nolock) RC " & _
'                         "join m_RunCardDetailOldVersion_t(nolock) RCD on RCD.RunCardID=RC.ID " & _
'                         "join m_RunCardPartDetailOldVersion_t(nolock) RCP on RCP.RunCardDetailID=RCD.ID " & _
'                         "where  RC.PartID=" & Me.RunCardPartId & " and RCD.StationID=" & Me.RunCardStationId & " " & _
'                         ")T1 on T1.PartID=BM.PartID WHERE 1=1 " 'where BM.ParentPartID=" & Me.RCPartID
'            End If

'            If where <> "" Then
'                StrSql += where
'            End If
'            StrSql += " ORDER BY T1.PARTID ASC, PN.PARTNUMBER"
'            dgvEquipmentPart.Rows.Clear()
'            Using dt As DataTable = DAL.GetDataTable(StrSql)
'                For Each row As DataRow In dt.Rows
'                    dgvEquipmentPart.Rows.Add(row("Flag").ToString(), row("ID").ToString(), row("PartNumber").ToString(), row("Description").ToString(), row("Description1").ToString())
'                Next
'            End Using
'            dgvEquipmentPart.Columns(1).ReadOnly = True
'            dgvEquipmentPart.Columns(2).ReadOnly = True
'            '"品名"列全屏显示
'            'dgvEquipmentPart.Columns("EQ_Description").AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
'        Catch ex As Exception
'            Throw ex
'        Finally
'            DAL = Nothing
'        End Try
'    End Sub

'    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
'        Me.Close()
'    End Sub

'    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
'        '
'        If dgvBomPart.Rows.Count <= 0 Then
'            MessageBox.Show("请下载BOM")
'            Exit Sub
'        End If
'        '
'        'If dgvEquipmentPart.Rows.Count <= 0 Then
'        '    MessageBox.Show("治具料件")
'        '    Exit Sub
'        'End If
'        '保存所选
'        Dim sbSql As New StringBuilder
'        Dim strSql As String
'        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
'        Try
'            'Save 
'            If _isQueryOldVersion = "false" Then
'                strSql = "insert into m_RunCardPartDetail_t(RunCardDetailID,PartID,UserID,InTime) values("
'                sbSql.Append("delete m_RunCardPartDetail_t where RunCardDetailID=" & Me.RunCardDetailId)
'            Else
'                strSql = "insert into m_RunCardPartDetailOldVersion_t(RunCardDetailID,PartID,UserID,InTime) values("
'                sbSql.Append("delete m_RunCardPartDetailOldVersion_t where RunCardDetailID=" & Me.RunCardDetailId)
'            End If
'            For Each row As DataGridViewRow In dgvBomPart.Rows
'                If row.Cells("Bom_Select").Value.ToString = "Y" Then
'                    sbSql.Append(strSql & Me.RunCardDetailId & "," & row.Cells("Bom_PartID").Value.ToString & ",'" & SysMessageClass.UseId & "',getdate() )")
'                End If
'            Next
'            '
'            For Each row As DataGridViewRow In dgvEquipmentPart.Rows
'                If row.Cells("EQ_Select").Value.ToString = "Y" Then
'                    sbSql.Append(strSql & Me.RunCardDetailId & "," & row.Cells("EQ_PartID").Value.ToString & ",'" & SysMessageClass.UseId & "',getdate() )")
'                End If
'            Next
' DAL.ExecSql(sbSql.ToString()) '该方法会执行事务处理
'            Me.DialogResult = Windows.Forms.DialogResult.OK
'            Me.Close()
'        Catch ex As Exception
'            SysMessageClass.WriteErrLog(ex, "FrmRunCardPartDetail", "btnOK_Click", "sys")
'        Finally
'            DAL = Nothing
'        End Try
'    End Sub

'    Private Sub dgvBomPart_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBomPart.CellClick

'        If dgvBomPart.Rows.Count > 0 Then
'            'Dim selected As String = dgvBomPart.Item(0, dgvBomPart.CurrentRow.Index).Value.ToString()
'            'If selected = "Y" Then
'            '    dgvBomPart.Item(0, dgvBomPart.CurrentRow.Index).Value = "N"
'            'Else
'            '    dgvBomPart.Item(0, dgvBomPart.CurrentRow.Index).Value = "Y"
'            'End If
'        End If

'    End Sub

'    Private Sub dgvEquipmentPart_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEquipmentPart.CellClick

'        If dgvEquipmentPart.Rows.Count > 0 Then
'            'Dim selected As String = dgvEquipmentPart.Item(0, dgvEquipmentPart.CurrentRow.Index).Value.ToString()
'            'If selected = "Y" Then
'            '    dgvEquipmentPart.Item(0, dgvEquipmentPart.CurrentRow.Index).Value = "N"
'            'Else
'            '    dgvEquipmentPart.Item(0, dgvEquipmentPart.CurrentRow.Index).Value = "Y"
'            'End If
'        End If
'    End Sub

'    Private Sub txtFind_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFindPn.KeyPress
'        If e.KeyChar = Chr(13) Then
'            If txtFindPn.Text.Trim <> "" Then
'                BindEquipmentGrid(" AND (PN.PARTNUMBER LIKE N'%" & txtFindPn.Text.Trim & "%' OR T1.PARTID IS NOT NULL)")
'            Else
'                BindEquipmentGrid()
'            End If
'        End If
'    End Sub

'    Private Sub txtFindRule_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFindRule.KeyPress
'        If e.KeyChar = Chr(13) Then
'            If txtFindRule.Text.Trim <> "" Then
'                BindEquipmentGrid(" AND (PN.DESCRIPTION1 LIKE N'%" & txtFindRule.Text.Trim & "%' OR T1.PARTID IS NOT NULL)")
'            Else
'                BindEquipmentGrid()
'            End If
'        End If
'    End Sub

'    Private Sub txtFindBand_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFindBand.KeyPress
'        If e.KeyChar = Chr(13) Then
'            If txtFindBand.Text.Trim <> "" Then
'                BindEquipmentGrid(" AND (PN.DESCRIPTION LIKE N'%" & txtFindBand.Text.Trim & "%' OR T1.PARTID IS NOT NULL)")
'            Else
'                BindEquipmentGrid()
'            End If
'        End If
'    End Sub
'End Class
#End Region


Public Class FrmRunCardPartDetail


    Sub New(ByVal runCardDetailId As Integer, ByVal runCardStationId As Integer, ByVal runCardId As Integer, ByVal runCardPartId As Integer, ByVal isQueryOldVersion As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._runCardId = runCardId
        Me._runCardPartId = runCardPartId
        Me._runCardDetailId = runCardDetailId
        Me._runCardStationId = runCardStationId
        Me._isQueryOldVersion = isQueryOldVersion

    End Sub
#Region "属性"


#Region "RunCardId"
    Private _runCardId As String
    Public ReadOnly Property RunCardId() As Integer
        Get
            Return _runCardId
        End Get
    End Property
#End Region

#Region "RunCardPartId"
    Private _runCardPartId As Integer
    Public ReadOnly Property RunCardPartId() As Integer
        Get
            Return _runCardPartId
        End Get
    End Property
#End Region

#Region "RunCardDetailId"
    Private _runCardDetailId As Integer
    Private _isQueryOldVersion As String
    Public ReadOnly Property RunCardDetailId() As Integer
        Get
            Return _runCardDetailId
        End Get
    End Property
#End Region

#Region "RunCardStationID"
    Private _runCardStationId As Integer
    Public ReadOnly Property RunCardStationId() As Integer
        Get
            Return _runCardStationId
        End Get

    End Property
#End Region

#End Region



    Private Sub FrmRunCardPartDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            BindBomGrid()
            BindEquipmentGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardPartDetail", "FrmRunCardPartDetail_Load", "sys")
        End Try

    End Sub

    Private Sub BindBomGrid()
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            Dim StrSql As String = Nothing
            If _isQueryOldVersion = "false" Then
                StrSql = "select PN.ID,PN.PartNumber,PN.Description,PN.Description1,Case when T1.PartID IS null then 'N' else 'Y' end  Flag  " & _
                 "from m_RunCardBomInfo_t(nolock) BM join m_RunCardPartNumber_t(nolock) PN on BM.PartID=PN.ID " & _
                 " left join ( " & _
                 "select RCP.PartID from  m_RunCard_t(nolock) RC " & _
                 "join m_RunCardDetail_t(nolock) RCD on RCD.RunCardID=RC.ID " & _
                 "join m_RunCardPartDetail_t(nolock) RCP on RCP.RunCardDetailID=RCD.ID " & _
                 "where  RC.ID=" & Me.RunCardId & " and RCD.StationID=" & Me.RunCardStationId & " " & _
                 ")T1 on T1.PartID=BM.PartID where BM.ParentPartID=" & Me.RunCardPartId
            Else
                StrSql = "select PN.ID,PN.PartNumber,PN.Description,PN.Description1,Case when T1.PartID IS null then 'N' else 'Y' end  Flag  " & _
              "from m_RunCardBomInfo_t(nolock) BM join m_RunCardPartNumber_t(nolock) PN on BM.PartID=PN.ID " & _
              " left join ( " & _
              "select RCP.PartID from  m_RunCardOldVersion_t(nolock) RC " & _
              "join m_RunCardDetailOldVersion_t(nolock) RCD on RCD.RunCardID=RC.ID " & _
              "join m_RunCardPartDetailOldVersion_t(nolock) RCP on RCP.RunCardDetailID=RCD.ID " & _
              "where  RC.ID=" & Me.RunCardId & " and RCD.StationID=" & Me.RunCardStationId & " " & _
              ")T1 on T1.PartID=BM.PartID where BM.ParentPartID=" & Me.RunCardPartId
            End If
            dgvBomPart.Rows.Clear()
            Using dt As DataTable = DAL.GetDataTable(StrSql)
                For Each row As DataRow In dt.Rows
                    dgvBomPart.Rows.Add(row("Flag").ToString(), row("ID").ToString(), row("PartNumber").ToString(), row("Description").ToString(), row("Description1").ToString())
                Next
            End Using
            dgvBomPart.Columns(1).ReadOnly = True
            dgvBomPart.Columns(2).ReadOnly = True
        Catch ex As Exception
            If Not DAL Is Nothing Then
                DAL = Nothing
            End If
        End Try


        '"品名"列全屏显示
        'dgvBomPart.Columns("Bom_Description").AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub BindEquipmentGrid(Optional ByVal where As String = "")

        Dim StrSql As String = ""
        'Dim reader As SqlClient.SqlDataReader = Nothing
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            '加载Data
            If _isQueryOldVersion = "false" Then
                StrSql = "select PN.ID,PN.PartNumber,PN.Description,PN.Description1,Case when T1.PartID IS null then 'N' else 'Y' end  Flag  " & _
                         "from (select distinct PartID from m_Equipment_t(nolock) ) BM join m_RunCardPartNumber_t(nolock) PN on BM.PartID=PN.ID " & _
                         " left join ( " & _
                         "select RCP.PartID from  m_RunCard_t(nolock) RC " & _
                         "join m_RunCardDetail_t(nolock) RCD on RCD.RunCardID=RC.ID " & _
                         "join m_RunCardPartDetail_t(nolock) RCP on RCP.RunCardDetailID=RCD.ID " & _
                         "where  RC.PartID=" & Me.RunCardPartId & " and RCD.StationID=" & Me.RunCardStationId & " " & _
                         ")T1 on T1.PartID=BM.PartID WHERE 1=1 " 'where BM.ParentPartID=" & Me.RCPartID
            Else
                StrSql = "select PN.ID,PN.PartNumber,PN.Description,PN.Description1,Case when T1.PartID IS null then 'N' else 'Y' end  Flag  " & _
                         "from (select distinct PartID from m_Equipment_t(nolock) ) BM join m_RunCardPartNumber_t(nolock) PN on BM.PartID=PN.ID " & _
                         " left join ( " & _
                         "select RCP.PartID from  m_RunCardOldVersion_t(nolock) RC " & _
                         "join m_RunCardDetailOldVersion_t(nolock) RCD on RCD.RunCardID=RC.ID " & _
                         "join m_RunCardPartDetailOldVersion_t(nolock) RCP on RCP.RunCardDetailID=RCD.ID " & _
                         "where  RC.PartID=" & Me.RunCardPartId & " and RCD.StationID=" & Me.RunCardStationId & " " & _
                         ")T1 on T1.PartID=BM.PartID WHERE 1=1 " 'where BM.ParentPartID=" & Me.RCPartID
            End If

            If where <> "" Then
                StrSql += where
            End If
            StrSql += " ORDER BY T1.PARTID ASC, PN.PARTNUMBER"
            dgvEquipmentPart.Rows.Clear()
            Using dt As DataTable = DAL.GetDataTable(StrSql)
                For Each row As DataRow In dt.Rows
                    dgvEquipmentPart.Rows.Add(row("Flag").ToString(), row("ID").ToString(), row("PartNumber").ToString(), row("Description").ToString(), row("Description1").ToString())
                Next
            End Using
            dgvEquipmentPart.Columns(1).ReadOnly = True
            dgvEquipmentPart.Columns(2).ReadOnly = True
            '"品名"列全屏显示
            'dgvEquipmentPart.Columns("EQ_Description").AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            Throw ex
        Finally
            DAL = Nothing
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        '
        If dgvBomPart.Rows.Count <= 0 Then
            MessageBox.Show("请下载BOM")
            Exit Sub
        End If
        '
        'If dgvEquipmentPart.Rows.Count <= 0 Then
        '    MessageBox.Show("治具料件")
        '    Exit Sub
        'End If
        '保存所选
        Dim sbSql As New StringBuilder
        Dim strSql As String
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim partNumber As String = GetPn()
        Try
            'Save 
            If _isQueryOldVersion = "false" Then
                strSql = "insert into m_RunCardPartDetail_t(RunCardDetailID,PartID,UserID,InTime,partnumber,ewpartnumber,STATIONID) values("
                sbSql.Append("delete m_RunCardPartDetail_t where RunCardDetailID=" & Me.RunCardDetailId)
            Else
                strSql = "insert into m_RunCardPartDetailOldVersion_t(RunCardDetailID,PartID,UserID,InTime,partnumber,ewpartnumber,STATIONID) values("
                sbSql.Append("delete m_RunCardPartDetailOldVersion_t where RunCardDetailID=" & Me.RunCardDetailId)
            End If
            For Each row As DataGridViewRow In dgvBomPart.Rows
                If row.Cells("Bom_Select").Value.ToString = "Y" Then
                    sbSql.Append(strSql & Me.RunCardDetailId & "," & row.Cells("Bom_PartID").Value.ToString & ",'" & SysMessageClass.UseId & "',getdate(),'" & partNumber & "','" & row.Cells("Bom_PartNumber").Value.ToString & "'," & RunCardStationId & " )")
                End If
            Next
            '
            For Each row As DataGridViewRow In dgvEquipmentPart.Rows
                If row.Cells("EQ_Select").Value.ToString = "Y" Then
                    sbSql.Append(strSql & Me.RunCardDetailId & "," & row.Cells("EQ_PartID").Value.ToString & ",'" & SysMessageClass.UseId & "',getdate(),'" & partNumber & "','" & row.Cells("EQ_PartNumber").Value.ToString & "'," & RunCardStationId & " )")
                End If
            Next
            DAL.ExecSql(sbSql.ToString()) '该方法会执行事务处理
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardPartDetail", "btnOK_Click", "sys")
        Finally
            DAL = Nothing
        End Try
    End Sub

    Private Sub dgvBomPart_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBomPart.CellClick

        If dgvBomPart.Rows.Count > 0 Then
            'Dim selected As String = dgvBomPart.Item(0, dgvBomPart.CurrentRow.Index).Value.ToString()
            'If selected = "Y" Then
            '    dgvBomPart.Item(0, dgvBomPart.CurrentRow.Index).Value = "N"
            'Else
            '    dgvBomPart.Item(0, dgvBomPart.CurrentRow.Index).Value = "Y"
            'End If
        End If

    End Sub

    Private Sub dgvEquipmentPart_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEquipmentPart.CellClick

        If dgvEquipmentPart.Rows.Count > 0 Then
            'Dim selected As String = dgvEquipmentPart.Item(0, dgvEquipmentPart.CurrentRow.Index).Value.ToString()
            'If selected = "Y" Then
            '    dgvEquipmentPart.Item(0, dgvEquipmentPart.CurrentRow.Index).Value = "N"
            'Else
            '    dgvEquipmentPart.Item(0, dgvEquipmentPart.CurrentRow.Index).Value = "Y"
            'End If
        End If
    End Sub

    Private Sub txtFind_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFindPn.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtFindPn.Text.Trim <> "" Then
                BindEquipmentGrid(" AND (PN.PARTNUMBER LIKE N'%" & txtFindPn.Text.Trim & "%' OR T1.PARTID IS NOT NULL)")
            Else
                BindEquipmentGrid()
            End If
        End If
    End Sub

    Private Sub txtFindRule_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFindRule.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtFindRule.Text.Trim <> "" Then
                BindEquipmentGrid(" AND (PN.DESCRIPTION1 LIKE N'%" & txtFindRule.Text.Trim & "%' OR T1.PARTID IS NOT NULL)")
            Else
                BindEquipmentGrid()
            End If
        End If
    End Sub

    Private Sub txtFindBand_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFindBand.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtFindBand.Text.Trim <> "" Then
                BindEquipmentGrid(" AND (PN.DESCRIPTION LIKE N'%" & txtFindBand.Text.Trim & "%' OR T1.PARTID IS NOT NULL)")
            Else
                BindEquipmentGrid()
            End If
        End If
    End Sub

    Private Function GetPn() As String
        Dim sql As String = "SELECT PARTNUMBER FROM M_RUNCARD_T WHERE ID=" & _runCardId & ""
        Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass
        Using dt As DataTable = DAL.GetDataTable(sql)
            If dt.Rows.Count > 0 Then Return dt.Rows(0)(0).ToString
        End Using
        Return ""
    End Function
End Class