Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports MainFrame
Public Class FrmReg
    Public m_strItem As String = ""
    Public m_strInQty As String = ""
    Public m_strSheetNo As String = ""
    Public m_strRemainQty As String = ""

    Private Sub FrmReg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DesignMode = False Then


        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim Sql As New StringBuilder
        Try
            'First check 
            If Not CheckInput() Then
                Exit Sub
            End If


            Sql.Append(" Insert into m_MaterialRegLog_t(PartID,RegUserID,Intime,RegQty,Remark,Status,PName)")
            Sql.Append(" Values( '" & Me.txtPartID.Text.Trim & "' ,")
            Sql.Append(" '" & VbCommClass.VbCommClass.UseId & "',getdate(), '" & Me.txtQty.Text.Trim & "', N'" & Me.txtRemark.Text.Trim & "','0' ")
            Sql.Append(" ,N'" & Me.txtPName.Text.Trim & "')")


            DbOperateUtils.ExecSQL(Sql.ToString)

            MessageUtils.ShowInformation("领用登记成功!")

            Me.Close()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "EquipmentManagement.FrmReg", "btnConfirm_Click", "Equ")
        End Try
    End Sub

    Private Function CheckInput() As Boolean

        If String.IsNullOrEmpty(Me.txtQty.Text) Then
            MessageUtils.ShowError("领用数量不能为空！")
            Return False
        Else
            If Val(Me.txtQty.Text.Trim) <= 0 Then
                MessageUtils.ShowError("领用数量必须大于0！")
                Return False
            End If

            If Val(Me.txtQty.Text.Trim) > Val(m_strRemainQty) Then
                MessageUtils.ShowError("领用数量不能超过剩余数量！")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class