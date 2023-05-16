Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmRCardLogQuery

    Private _sqlWhere As String
    Public Property sqlWhere() As String
        Get
            Return _sqlWhere
        End Get

        Set(ByVal Value As String)
            _sqlWhere = Value
        End Set
    End Property
    Private _ismultiline As Boolean = False
    Public Property IsMultiLine() As Boolean
        Get
            Return _ismultiline
        End Get

        Set(ByVal Value As Boolean)
            _ismultiline = Value
        End Set
    End Property
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim sql As String = ""
        Dim strUserID As String = ""
        If Me.txtPartNumber.Text.Trim <> "" Then
            If (Me.txtPartNumber.Text.Trim.Split(";").Length > 1) Then
                IsMultiLine = True
                Dim str As String = "and a.PartID in ("
                Dim strloop As String = ""
                For i = 0 To Me.txtPartNumber.Text.Trim.Split(";").Length - 1
                    strloop = strloop + ",'" + Me.txtPartNumber.Text.Trim.Split(";")(i) + "'"
                Next
                sql = str + strloop.Substring(1) + ")"
                'sql = sql + " AND a.PartNumber LIKE N'%" & Me.txtPartNumber.Text.Trim & "%' "
            Else
                sql = sql + " AND a.PartID LIKE N'%" & Me.txtPartNumber.Text.Trim & "%' "
            End If

        End If

        '工站名称
        If Me.txtStationName.Text.Trim <> "" Then
            sql = sql + " AND b.StationName LIKE N'%" & Me.txtStationName.Text.Trim & "%'"
        End If


        If Me.cobType.Text.Trim <> "" Then
            sql = sql + " AND type like N'%" & Me.cobType.Text.Trim & "%'"
        End If


        'If Me.txtUserID.Text.Trim <> "" Then
        '    If IsExistChinese(Me.txtUserID.Text.Trim) Then
        '        'get userid
        '        strUserID = RunCardBusiness.GetUserID(Me.txtUserID.Text.Trim)
        '        If Not String.IsNullOrEmpty(strUserID) Then
        '            sql = sql + " AND Creater LIKE N'%" & strUserID & "%'"
        '        End If
        '    Else
        '        sql = sql + " AND Creater LIKE N'%" & Me.txtUserID.Text.Trim & "%'"
        '    End If
        'End If

        '更改人
        If Not String.IsNullOrEmpty(Me.txtModifyUserName.Text.Trim) Then
            sql = sql + " AND d.UserName LIKE N'%" & Me.txtModifyUserName.Text.Trim & "%'"
        End If

        '描述
        'If Not String.IsNullOrEmpty(Me.cobType.Text.Trim) Then
        '    sql = sql + " AND a.Remark LIKE N'%" & Me.cobType.Text.Trim & "%'"
        'End If

        If Me.ckDateBegin.Checked Then
            sql = sql + " AND a.NewModifyTime >=CONVERT(datetime,'" & Me.dateTimeFrom.Text & "',120 )"
        End If
        If Me.ckDateEnd.Checked Then
            sql = sql + " AND a.NewModifyTime <=CONVERT(datetime,'" & Me.dateTimeTo.Text & "',120 )"
        End If

        Me.sqlWhere = sql
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub txtPartNumber_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtPartNumber.ButtonCustomClick
        Dim obj As New SysBasicClass.InputText(txtPartNumber)
        obj.ShowDialog()
    End Sub



    Private Sub FrmRCardLogQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        FillCombox(Me.cobType)

        Me.cobType.SelectedIndex = -1
    End Sub

    Private Sub FillCombox(ByVal ColComboBox As ComboBox)
        Dim UserDg As DataTable
        Dim lsSQL As String = ""
        Try
            If ColComboBox.Name = "cobType" Then
                ColComboBox.Items.Clear()

                lsSQL = " SELECT distinct TYPE  , type  FROM m_RCardChangeLog_t" & _
                                " WHERE 1=1"
                UserDg = DbOperateUtils.GetDataTable(lsSQL)
                cobType.DataSource = UserDg.DefaultView
                cobType.DisplayMember = "TYPE"
                cobType.ValueMember = "TYPE"

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRCardLogQuery", "FillCombox", "RCard")
            Throw ex
        End Try
    End Sub

End Class