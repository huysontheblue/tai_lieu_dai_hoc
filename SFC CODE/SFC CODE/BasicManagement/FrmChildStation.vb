
'维修子站点维护
'Create by: 马锋
'Create time: 2015/06/09
'Update by: 
'Update time: 

#Region "Imports"

Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle

#End Region

Public Class FrmChildStation

#Region "变量声明"

    Public opflag As Int16 = 0
#End Region

#Region "加载"

    Private Sub FrmRstationSet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case 37
                'オよ龄 
                SendKeys.Send("{+Tab}")  'Shift + Tab 舱龄 
            Case 13
                SendKeys.Send("{Tab}")
            Case 38 'よ龄 
            Case 39 'よ龄 
                'SendKeys.Send("{+Tab}")
            Case 40  'よ龄 
                'SendKeys.Send("{+Tab}")
            Case 27 'Esc龄 
                Me.Close()
        End Select
    End Sub

    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadDataToDatagridview(" ")
        ToolbtnState(0)
        dgvRstation.Enabled = True
    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True

                Me.txtPartId.Enabled = True
                Me.txtChildStationCode.Enabled = True
                Me.txtChildStationName.Enabled = False
                Me.txtParentStationCode.Enabled = False
                Me.txtBackStationCode.Enabled = False
                Me.txtStationType.Enabled = False
                Me.txtRemark.Enabled = False
                Me.ChkUsey.Enabled = False

                Me.txtPartId.Text = ""
                Me.txtChildStationCode.Text = ""
                Me.txtChildStationName.Text = ""
                Me.txtParentStationCode.Text = ""
                Me.txtBackStationCode.Text = ""
                Me.txtStationType.Text = ""
                Me.txtRemark.Text = ""
                Me.ChkUsey.Checked = False
                Me.ActiveControl = Me.txtPartId
            Case 1
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False

                Me.txtPartId.Enabled = True
                Me.txtChildStationCode.Enabled = True
                Me.txtChildStationName.Enabled = True
                Me.txtParentStationCode.Enabled = True
                Me.txtBackStationCode.Enabled = True
                Me.txtStationType.Enabled = True
                Me.txtRemark.Enabled = True
                Me.ChkUsey.Enabled = True

                Me.txtPartId.Text = ""
                Me.txtChildStationCode.Text = ""
                Me.txtChildStationName.Text = ""
                Me.txtParentStationCode.Text = ""
                Me.txtBackStationCode.Text = ""
                Me.txtStationType.Text = ""
                Me.txtRemark.Text = ""
                Me.ChkUsey.Checked = True
                Me.ActiveControl = Me.txtPartId
            Case 2
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False

                Me.txtPartId.Enabled = False
                Me.txtChildStationCode.Enabled = False
                Me.txtChildStationName.Enabled = True
                Me.txtParentStationCode.Enabled = True
                Me.txtBackStationCode.Enabled = True
                Me.txtStationType.Enabled = True
                Me.txtRemark.Enabled = True
                Me.ChkUsey.Enabled = True

                Me.ActiveControl = Me.txtPartId
        End Select
    End Sub

#End Region

    '#Region ""
    '    Private Sub LoadDataToCombox()

    '        Dim SqlStr As String = "select SortID,SortName from m_Sortset_t where SortType = 'StationType' and Usey='Y' order by Orderid"
    '        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    '        Dim Dreader As SqlDataReader = Conn.GetDataReader(SqlStr)
    '        cboType.Items.Clear()
    '        cboType.Items.Add("")
    '        Do While Dreader.Read()
    '            cboType.Items.Add(Dreader.Item(0) & "-" & Dreader.Item(1))
    '        Loop

    '        Dreader.Close()
    '        Conn = Nothing

    '    End Sub

    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader
        Dim SqlStr As String = ""

        dgvRstation.Rows.Clear()
        SqlStr = "SELECT  Stationid, StationName, Partid, Remark, parentStation, BackStationid, StationType, usey, userid, intime FROM m_ChildStation_t WHERE 1=1 "
        Dreader = Conn.GetDataReader(SqlStr & SqlWhere)
        Do While Dreader.Read()
            dgvRstation.Rows.Add(Dreader.Item(0).ToString, Dreader.Item(1).ToString, Dreader.Item(2).ToString, _
            Dreader.Item(3).ToString, Dreader.Item(4).ToString, Dreader.Item(5).ToString, Dreader.Item(6).ToString, Dreader.Item(7).ToString, Dreader.Item(8).ToString, Dreader.Item(9).ToString)
        Loop
        Dreader.Close()
        toolStripStatusLabel3.Text = Me.dgvRstation.Rows.Count
        If (Conn.PubConnection.State = ConnectionState.Open) Then
            Conn.PubConnection.Close()
        End If
    End Sub

#Region "CBO/DG"

    Private Sub dgvRstation_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvRstation.RowPrePaint
        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts
    End Sub

    Private Function Checkdata() As Boolean
        If Me.txtPartId.Text.Trim = "" Then
            lblMessage.Text = "料号不能为空..."
            Me.ActiveControl = Me.txtChildStationCode
            Return False
        End If
        If Me.txtChildStationCode.Text.Trim = "" Then
            lblMessage.Text = "工站代码不能为空..."
            Me.ActiveControl = Me.txtChildStationCode
            Return False
        End If
        If Me.txtChildStationName.Text.Trim = "" Then
            lblMessage.Text = "工站名称不能为空..."
            Me.ActiveControl = Me.txtChildStationName
            Return False
        End If
        Return True
    End Function

#End Region

#Region "菜单事件"

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click
        SetMessage("", True)
        opflag = 1
        ToolbtnState(1)
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        SetMessage("", True)
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub

        Me.txtPartId.Text = dgvRstation.CurrentRow.Cells("PartId").Value
        Me.txtChildStationCode.Text = dgvRstation.CurrentRow.Cells("ChildStationCode").Value
        Me.txtChildStationName.Text = dgvRstation.CurrentRow.Cells("ChildStationName").Value
        Me.txtParentStationCode.Text = dgvRstation.CurrentRow.Cells("ParentStationCode").Value
        Me.txtBackStationCode.Text = dgvRstation.CurrentRow.Cells("BackStationCode").Value
        Me.txtStationType.Text = dgvRstation.CurrentRow.Cells("StationType").Value
        Me.txtRemark.Text = dgvRstation.CurrentRow.Cells("Remark").Value
        Me.ChkUsey.Checked = IIf(dgvRstation.CurrentRow.Cells("ColUsey").Value = "Y", True, False)

        opflag = 2
        ToolbtnState(2)

    End Sub

    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        SetMessage("", True)
        If Me.dgvRstation.Rows.Count = 0 OrElse Me.dgvRstation.CurrentRow Is Nothing Then Exit Sub
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

        Try
            Conn.ExecSql("update m_Dept_t set usey='N' where deptid = '" & dgvRstation.CurrentRow.Cells("ColLineid").Value & "'")
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            SetMessage("作废成功!", True)
            LoadDataToDatagridview(" where deptid='" & dgvRstation.CurrentRow.Cells("ColLineid").Value & "'")
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            SetMessage("作废异常!", False)
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbAbandon_Click", "sys")
        End Try

    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        SetMessage("", True)
        If Checkdata() = False Then Exit Sub

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

        Try
            Dim SqlStr As New StringBuilder
            Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")

            If opflag = 1 Then

                Dim mCheckCodeRead As SqlDataReader = Conn.GetDataReader("SELECT Partid FROM m_ChildStation_t WHERE Partid='" & Me.txtPartId.Text.Trim() & "' AND Stationid='" & Me.txtChildStationCode.Text.Trim() & "'")
                If mCheckCodeRead.HasRows Then
                    mCheckCodeRead.Close()
                    SetMessage("料号子工站已经存在！", False)
                    If (Conn.PubConnection.State = ConnectionState.Open) Then
                        Conn.PubConnection.Close()
                    End If
                    Exit Sub
                End If
                mCheckCodeRead.Close()

                SqlStr.Append(ControlChars.CrLf & "INSERT INTO m_ChildStation_t(Partid, Stationid, StationName, parentStation, BackStationid, StationType, Remark, usey, userid, intime)" _
                         & "  VALUES('" & Me.txtPartId.Text.Trim & "',N'" & Me.txtChildStationCode.Text.Trim & "',N'" & Me.txtChildStationName.Text.Trim & "',N'" & Me.txtParentStationCode.Text.Trim & "',N'" & Me.txtBackStationCode.Text.Trim & "',N'" & Me.txtStationType.Text.Trim & "'," _
                         & " N'" & txtRemark.Text.Trim & "','" & cheUsy & "',N'" & Me.txtChildStationName.Text.Trim & "',Getdate())")

            ElseIf opflag = 2 Then
                SqlStr.Append("update m_ChildStation_t set StationName =N'" & txtChildStationName.Text.Trim & "',parentStation =N'" & Me.txtParentStationCode.Text.Trim & "',BackStationid =N'" & Me.txtBackStationCode.Text.Trim & "',StationType =N'" & Me.txtStationType.Text.Trim & "',Remark =N'" & Me.txtRemark.Text.Trim & "',usey =N'" & cheUsy & "' where Partid = '" & Me.txtPartId.Text.Trim & "' and Stationid=N'" & Me.txtChildStationCode.Text.Trim & "'")
            End If

            Conn.ExecSql(SqlStr.ToString)

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            SetMessage("保存成功!", True)
            LoadDataToDatagridview(" ")

            opflag = 0
            ToolbtnState(0)
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            SetMessage("保存异常!", False)
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmRStationSet", "tsbSave_Click", "sys")
            Exit Sub
        End Try

    End Sub

    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        SetMessage("", True)
        opflag = 0
        ToolbtnState(0)
    End Sub

    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        SetMessage("", True)
        Try
            Dim strWhere As String = " "

            If Not (String.IsNullOrEmpty(Me.txtPartId.Text.Trim)) Then
                strWhere = strWhere & " AND Partid='" & Me.txtPartId.Text.Trim & "'"
            End If

            If Not (String.IsNullOrEmpty(Me.txtChildStationCode.Text.Trim)) Then
                strWhere = strWhere & " AND Stationid='" & Me.txtChildStationCode.Text.Trim & "'"
            End If

            LoadDataToDatagridview(strWhere)
        Catch ex As Exception
            SetMessage("查询异常！", False)
        End Try
    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#End Region

    Private Sub SetMessage(ByVal Message As String, ByVal Status As Boolean)
        If (Status) Then
            Me.lblMessage.ForeColor = Color.Green
        Else
            Me.lblMessage.ForeColor = Color.Red
        End If
        Me.lblMessage.Text = Message
    End Sub
End Class