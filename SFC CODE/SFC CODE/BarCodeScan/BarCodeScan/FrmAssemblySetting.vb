
'--料件装配设置
'--Create by :　马锋
'--Update by :  田玉琳
'--Create date :　2015/03/26
'--Update date :  2015/09/10  
'--更新原因：流程改版修改影响
'--Ver : V01

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO

#End Region

Public Class FrmAssemblySetting

    Dim opFlag As Int16 = 0

#Region "窗体事件"
    Private Sub FrmAssemblySetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetStatus(opFlag)
    End Sub

#End Region

#Region "菜单事件"
   
    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        Try
            Dim strSQL As String

            chbListSelect.Checked = False
            SetMessage("", False)
            If (String.IsNullOrEmpty(Me.txtPartId.Text.Trim())) Then
                SetMessage("请输入查询产品料件号!", False)
                Exit Sub
            End If

            strSQL = "SELECT   TAvcPart, PAvcPart, TypeDest, UseY, IsUpload, Isasseble, IsLotScan, IsAlter, MaterialAlter, IsChkTransData, Extensible, DESCRIPTION " & _
                     "FROM m_PartContrast_t WHERE PAvcPart = '" & Me.txtPartId.Text.Trim.Replace("'", "''") & "'"
            'GetFatoryProfitcenter()
            LoadData(strSQL, Me.dgvBomList)

        Catch ex As Exception
            SetMessage("执行查询异常!", False)
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmAssemblySetting", "ToolQuery_Click", "sys")
        End Try
    End Sub

    Private Sub ToolCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCommit.Click
        SetMessage("", False)

        If (Not CheckSave(Me.dgvBomList)) Then
            Exit Sub
        End If

        Dim connSQL As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            Dim strSQL As New StringBuilder
            Dim strPartID As String
            Dim strPPartID As String
            Dim IsupLoad As String
            Dim IsAssemble As String
            Dim IsLotScan As String
            Dim IsAlter As String
            Dim MaterialAlter As String
            Dim IsTranData As String
            Dim Extensible As String

            Dim ChkTemp As DataGridViewCheckBoxCell
            Dim ChkisUpload As DataGridViewCheckBoxCell
            Dim ChkAssemble As DataGridViewCheckBoxCell
            Dim ChkIsLot As DataGridViewCheckBoxCell
            Dim ChkAlter As DataGridViewCheckBoxCell
            Dim ChkMaterialCheck As DataGridViewCheckBoxCell
            Dim ChkTransData As DataGridViewCheckBoxCell
            Dim ChkExtensible As DataGridViewCheckBoxCell

            Me.dgvBomList.EndEdit()

            strSQL.Append(" BEGIN TRANSACTION ")

            For i As Int16 = 0 To Me.dgvBomList.RowCount - 1

                chkTemp = dgvBomList.Rows(i).Cells("ChkSelect")
                If (Not ChkTemp Is Nothing AndAlso ChkTemp.FormattedValue = True) Then

                    strPartID = (Me.dgvBomList.Rows(i).Cells("PartId").Value.ToString)
                    strPPartID = (Me.dgvBomList.Rows(i).Cells("ParentPartId").Value.ToString)

                    ChkisUpload = dgvBomList.Rows(i).Cells("ChkisUpload")
                    ChkAssemble = dgvBomList.Rows(i).Cells("ChkAssemble")
                    ChkIsLot = dgvBomList.Rows(i).Cells("ChkIsLot")
                    ChkAlter = dgvBomList.Rows(i).Cells("ChkAlter")
                    ChkTransData = dgvBomList.Rows(i).Cells("ChkTransData")
                    ChkMaterialCheck = dgvBomList.Rows(i).Cells("ChkMaterialCheck")
                    ChkExtensible = dgvBomList.Rows(i).Cells("ChkExtensible")

                    IsupLoad = IIf(ChkisUpload.FormattedValue = True, "Y", "N")
                    IsAssemble = IIf(ChkAssemble.FormattedValue = True, "Y", "N")
                    IsLotScan = IIf(ChkIsLot.FormattedValue = True, "Y", "N")
                    IsAlter = IIf(ChkAlter.FormattedValue = True, "Y", "N")
                    MaterialAlter = IIf(ChkMaterialCheck.FormattedValue = True, "Y", "N")
                    IsTranData = IIf(ChkTransData.FormattedValue = True, "Y", "N")
                    Extensible = IIf(ChkExtensible.FormattedValue = True, "Y", "N")

                    strSQL.AppendLine("update m_PartContrast_t set Isasseble='" & IsAssemble & "' ,IsUpload='" & IsupLoad & _
                                      "',IsLotScan='" & IsLotScan & "',IsAlter='" & IsAlter & "',MaterialAlter='" & MaterialAlter & "' " & _
                                      " ,IsChkTransData='" & IsTranData & "' ,Extensible='" & Extensible & _
                                      "' where tavcpart='" & strPartID & "' and PAvcPart='" & strPPartID & "'"
                                     )
                End If
            Next

            strSQL.Append(" COMMIT TRANSACTION " _
                          & " if @@error>0  " _
                          & " BEGIN " _
                          & "     ROLLBACK TRANSACTION  " _
                          & " End")
            connSQL.ExecSql(strSQL.ToString)
            connSQL.PubConnection.Close()
            SetMessage("执行保存成功！", True)
        Catch ex As Exception
            connSQL.PubConnection.Close()
            SetMessage("执行保存异常！", False)
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmAssemblySetting", "ToolCommit_Click", "sys")
        End Try

    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click

        Me.Close()

    End Sub

#End Region

#Region "控件事件"

    Private Sub txt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPartId.KeyDown, txtMOId.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Dim strSQL As String
                SetMessage("", False)
                If (String.IsNullOrEmpty(Me.txtPartId.Text.Trim())) Then
                    SetMessage("请输入查询产品料件号!", False)
                    Exit Sub
                End If

                strSQL = "SELECT TAvcPart, PAvcPart, TypeDest, UseY, IsUpload, Isasseble, IsLotScan, IsAlter, MaterialAlter, IsChkTransData,Extensible, DESCRIPTION  " & _
                         "FROM m_PartContrast_t WHERE PAvcPart= '" & Me.txtPartId.Text.Trim.Replace("'", "''")
                'GetFatoryProfitcenter()
                LoadData(strSQL, Me.dgvBomList)
            End If
        Catch ex As Exception
            SetMessage("执行查询异常!", False)
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmAssemblySetting", "txt_KeyDown", "sys")
        End Try
    End Sub

    Private Sub chbListSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbListSelect.CheckedChanged
        Try
            If (Me.dgvBomList.RowCount > 0) Then
                For i As Int16 = 0 To Me.dgvBomList.RowCount - 1
                    dgvBomList.Rows(i).Cells("ChkSelect").Value = Me.chbListSelect.Checked
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "方法"

    '填充数据
    Private Sub LoadData(ByVal Sqlstr As String, ByVal dgvName As DataGridView)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader = Nothing
        Try
            dgvName.Rows.Clear()
            DReader = Conn.GetDataReader(Sqlstr)

            If (Not DReader.HasRows) Then
                SetMessage("查询没有任何资料, 请确认料号是否正确!", False)
            Else
                SetMessage("", False)
            End If

            Do While DReader.Read()
                dgvName.Rows.Add(False, DReader.Item("TAvcPart").ToString, DReader.Item("PAvcPart").ToString,
                                 DReader.Item("TypeDest").ToString, DReader.Item("DESCRIPTION").ToString, DReader.Item("UseY").ToString,
                                 IIf(DReader.Item("IsUpload").ToString = "Y", True, False), IIf(DReader.Item("Isasseble").ToString = "Y", True, False),
                                 IIf(DReader.Item("IsLotScan").ToString = "Y", True, False), IIf(DReader.Item("IsChkTransData").ToString = "Y", True, False),
                                 IIf(DReader.Item("MaterialAlter").ToString = "Y", True, False), IIf(DReader.Item("IsAlter").ToString = "Y", True, False),
                                 IIf(DReader.Item("Extensible").ToString = "Y", True, False))
            Loop
            DReader.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Not DReader.IsClosed) Then
                DReader.Close()
            End If
            Conn.PubConnection.Close()
            Throw ex '出错
        End Try
    End Sub

    '狀態顯示
    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始
                Me.ToolNew.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolQuery.Enabled = True
                Me.ToolBack.Enabled = False
                Me.txtMOId.Text = ""
                Me.txtPartId.Text = ""
                Me.txtMOId.Enabled = True
                Me.txtPartId.Enabled = True

            Case 1    '新增
                Me.ToolNew.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolBack.Enabled = True

                Me.txtMOId.Enabled = True
                Me.txtPartId.Enabled = False
            Case 2  '修改
                Me.ToolNew.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolBack.Enabled = True

                Me.txtMOId.Enabled = True
                Me.txtPartId.Enabled = False
        End Select
    End Sub

    Private Sub SetMessage(ByVal Message As String, ByVal Type As Boolean)
        If (Type) Then
            Me.lblMessage.ForeColor = Color.Green
        Else
            Me.lblMessage.ForeColor = Color.Red
        End If
        Me.lblMessage.Text = Message
    End Sub

#End Region

#Region "Function"

    Private Function GetFatoryProfitcenter() As String
        Dim strValue As String = String.Empty
        strValue = " AND Factoryid='" & VbCommClass.VbCommClass.Factory & "'"
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + " AND Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'"
        End If
        Return strValue
    End Function

    Private Function CheckSave(ByVal dgvPartList As DataGridView) As Boolean
        Dim iSelect As Boolean = False
        Dim chkTemp As DataGridViewCheckBoxCell

        For I As Int16 = 0 To dgvPartList.RowCount - 1
            chkTemp = dgvPartList.Rows(I).Cells("ChkSelect")

            If (Not chkTemp Is Nothing AndAlso chkTemp.FormattedValue = True) Then
                iSelect = True
                Exit For
            End If
        Next

        If (iSelect = False) Then
            SetMessage("请选择保存项目!", False)
        End If
        Return iSelect
    End Function
#End Region


End Class