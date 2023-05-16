Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmSOPReason
    Private _actionType As String
    Public Property actionType() As String
        Get
            Return _actionType
        End Get

        Set(ByVal Value As String)
            _actionType = Value
        End Set
    End Property

    Private _docID As String
    Public Property docID() As String
        Get
            Return _docID
        End Get

        Set(ByVal Value As String)
            _docID = Value
        End Set
    End Property


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If String.IsNullOrEmpty(Me.txtReason.Text) Then
            MessageUtils.ShowError("原因不能为空")
            Exit Sub
        End If

        If UpdateReason() Then
            Me.Close()
        End If
    End Sub

    Private Function UpdateReason() As Boolean
        Dim lsSQL As String = String.Empty
        Dim strRemark As String = ""
        Try
            '驳回 或者 撤回
            strRemark = actionType + ":" + Me.txtReason.Text.Trim

            lsSQL = " UPDATE m_OnlineSop_t SET Remark = N'" & strRemark & "' WHERE DocId='" & docID & "' "

            DbOperateUtils.ExecSQL(lsSQL)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class