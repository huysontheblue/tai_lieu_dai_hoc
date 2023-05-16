Imports System.Text
Imports MainFrame
Imports MainFrame.SysCheckData
Public Class FrmAssetLendBorrow


    Private Sub FrmAssetLendBorrow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then
            initload()
        End If
    End Sub
    Private Sub initload()

        EquManageCommon.BindComboxClass(cboRequestClass)

        If cboRequestClass.SelectedValue IsNot Nothing Then
            EquManageCommon.BindComboxLine(cboRequestLine, cboRequestClass.SelectedValue.ToString)
        End If

        lblMsg.Text = ""

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cboRequestClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRequestClass.SelectedIndexChanged
        If cboRequestClass.SelectedValue IsNot Nothing Then
            EquManageCommon.BindComboxLine(cboRequestLine, cboRequestClass.SelectedValue.ToString)
        End If
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sql As New StringBuilder

        Try


            'First check this equ, 是否可以借出
            If Not CheckInput() Then
                Exit Sub
            End If
           


            sql.Append(" INSERT m_AssetLendLog_t ")
            sql.Append(" (EquipmentNo,FromLineID,FromUserID,ToLineID,ToUserID,Intime) ")
            sql.Append(" values('N" & Me.txtEquipmentNo.Text.Trim & "',N'" & Me.txtFromLineID.Text.Trim & "',N'" & Me.txtFromUserID.Text.Trim & "',N'" & Me.cboRequestLine.SelectedValue.ToString & "',")
            sql.Append(" N'" & Me.txtToUserID.Text.Trim & "',GETDATE()) ")

            sql.Append("update  m_Asset_t set KeeperID=N'" & Me.txtToUserID.Text.Trim & "',KeeperName=N'" & Me.txtToUserID.Text.Trim & "',Storage=N'" & Me.cboRequestLine.SelectedValue.ToString & "' where ID='" & Me.lbId.Text & "'")
            DbOperateUtils.ExecSQL(sql.ToString)

            MessageUtils.ShowInformation("转借成功")
            Me.Close()

        Catch ex As Exception
            ' Throw ex
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmSelectLine", "btnSave_Click", "WIP")
        End Try
    End Sub



    Private Function CheckInput() As Boolean
        'xt001 --> xt 003,
        If IsNothing(Me.cboRequestLine.SelectedValue) OrElse String.IsNullOrEmpty(Me.cboRequestLine.SelectedValue.ToString) Then
            SetMessage("E", "请选择线别！")
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtToUserID.Text.Trim()) Then
            SetMessage("E", "请填写借出给的人的工号或姓名！")
            Return False
        End If

        If Me.txtFromLineID.Text.Trim.Contains(Me.cboRequestLine.SelectedValue.ToString) Then
            SetMessage("E", "不能借给相同的线别，请重新选择！")
            Return False
        End If

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
End Class
