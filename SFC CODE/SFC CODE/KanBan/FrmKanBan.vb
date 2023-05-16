Imports System.Data.SqlClient
Imports KanBan.FrmKanBanShow
Imports MainFrame.SysCheckData

Public Class FrmKanBan
    Private Enum enumMOStatus
        iNew = 0
        Wip = 1
        Finish = 2
        Lock = 3
    End Enum

    Private frm As FrmKanBanShow

    Private Sub FrmSetLine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            KBCom.LoadDataToListBox(listDept)
            Me.listDept.Focus()
            If listDept.Items.Count > 0 Then
                Me.listDept.SelectedIndex = 0
            End If
            If listLine.Items.Count > 0 Then
                Me.listLine.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Try
            If IsNothing(Me.listMO.Text) OrElse listMO.Text.ToString() = "" Then
                MessageUtils.ShowError("没有可选工单，请维护基础数据!")
                Me.listMO.Focus()
                Me.DialogResult = Windows.Forms.DialogResult.No
                Exit Sub
            End If

            frm = New FrmKanBanShow()
            frm.MaximizeBox = True
            frm.txtMO.Text = Me.listMO.Text.ToString
            frm.txtLine.Text = Me.listMO.SelectedValue.ToString
            frm.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub listDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listDept.SelectedIndexChanged
        KBCom.LoadLineIDToListBox(listLine, KBCom.Getid(listDept.Text))
        If listLine.Items.Count > 0 Then
            Me.listLine.SelectedIndex = 0
        End If
        KBCom.BindMO(listMO, KBCom.Getid(listDept.Text), Me.listLine.Text.ToString(), enumMOStatus.Wip)
    End Sub

    Private Sub listLine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listLine.SelectedIndexChanged
        KBCom.BindMO(listMO, KBCom.Getid(listDept.Text), Me.listLine.Text.ToString(), enumMOStatus.Wip)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


End Class