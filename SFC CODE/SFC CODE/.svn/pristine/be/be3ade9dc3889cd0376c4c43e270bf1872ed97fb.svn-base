Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmAssetReturn

    Private Sub FrmSelectLine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            initload()
        End If
    End Sub

    Private Sub initload()

        ' EquManageCommon.BindComboxClass(cboRequestClass)

        'If cboRequestClass.SelectedValue IsNot Nothing Then
        '    EquManageCommon.BindComboxLine(cboRequestLine, cboRequestClass.SelectedValue.ToString)
        'End If

        lblMsg.Text = ""

        Me.txtStorage.Text = GetStorage()

    End Sub

    Private Function GetStorage() As String
        Dim lsSQL As String = String.Empty
        GetStorage=""
        lsSQL = " SELECT Storage FROM dbo.m_Asset_t WHERE ID in(" & Me.lblIDList.Text.Trim & ")"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetStorage = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item("Storage"))
            Else
                GetStorage=""
            End If
        End Using
    End Function



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sql As New StringBuilder
        Dim strChecker As String = VbCommClass.VbCommClass.UseId
        Dim strFactoryName As String = VbCommClass.VbCommClass.Factory
        Dim strProficenter As String = VbCommClass.VbCommClass.profitcenter
        Dim strStorage As String = String.Empty
        Try

            'First check this equ, 是否可以借出
            If Not CheckInput() Then
                Exit Sub
            End If

            'If Not IsNothing(Me.cboRequestLine.SelectedValue.ToString) AndAlso Me.cboRequestLine.SelectedValue.ToString <> String.Empty Then
            '    strStorage = Me.cboRequestLine.SelectedValue.ToString
            'Else
            '    strStorage = Me.txtStorage.Text.Trim
            'End If

            'o_strSQL.Append(" Update m_Asset_t Set CStatus =N'闲置中', Status='0' , ModifyUserID ='" & VbCommClass.VbCommClass.UseId & "', ModifyTime = getdate(), ")
            'o_strSQL.Append(" KeeperID = null, keeperName = null, storage = null ")
            'o_strSQL.Append(" Where ID = '" & row.Cells(AssetGrid.ID).Value.ToString & "' ")


            For Each strID As String In Me.lblIDList.Text.Trim.Split(",")
                sql.Append(" Update  m_Asset_t SET CStatus = N'闲置中', Status = '0', ")
                sql.Append(" ModifyUserID ='" & VbCommClass.VbCommClass.UseId & "', ModifyTime = getdate(),")
                sql.Append(" KeeperID =null, KeeperName = null, TempLocation=null,")
                sql.Append(" Storage =N'" & Me.txtStorage.Text.Trim.Replace("'", "''") & "' ")
                sql.Append(" Where ID = '" & strID.Trim() & " '")
            Next

            DbOperateUtils.ExecSQL(sql.ToString)
            MessageUtils.ShowInformation("归还成功")
            Me.Close()

        Catch ex As Exception
            ' Throw ex
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmAssetReturn", "btnSave_Click", "WIP")
        End Try

    End Sub




    Private Function CheckInput() As Boolean


        If String.IsNullOrEmpty(Me.txtStorage.Text.Trim()) Then
            SetMessage("E", "请填写归还到栏位！")
            Return False
        End If

        'If Me.cboRequestLine.SelectedValue.ToString = Me.txtLineID.Text.Trim Then
        '    SetMessage("E", "不能借给相同的线别，请重新选择！")
        '    Return False
        'End If

        Return True
    End Function

    Private Sub SetMessage(ByVal type As String, ByVal msg As String)
        Select Case type
            Case "E"
                Me.lblMsg.Text = msg
                Me.lblMsg.BackColor = Drawing.Color.Red
            Case Else
                'do nothing
        End Select
    End Sub


    Private Sub btnCancal_Click(sender As Object, e As EventArgs) Handles btnCancal.Click
        Me.Close()
    End Sub

    Private Sub cboRequestLine_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    'Private Sub cboRequestClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRequestClass.SelectedIndexChanged
    '    If cboRequestClass.SelectedValue IsNot Nothing Then
    '        EquManageCommon.BindComboxLine(cboRequestLine, cboRequestClass.SelectedValue.ToString)
    '    End If
    'End Sub
End Class
