Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Text

Public Class FrmMouldBasisLife
    Public MouldId As String

#Region "初始化"
    Private Sub FrmMouldBasisLife_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMouidID.Text = MouldId
    End Sub
#End Region
 
#Region "事件"
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            If String.IsNullOrEmpty(txtMouidID.Text.Trim) Then
                MessageUtils.ShowInformation("模具编号不能为空!")
                Return
            End If

            If Not IsNumeric(txtUsedTimes.Text.Trim) Then
                MessageUtils.ShowInformation("使用次数必须为数字!")
                Return
            ElseIf CInt(txtUsedTimes.Text.Trim) <= 0 Then
                MessageUtils.ShowInformation("使用次数必须大于0!")
                Return
            End If

            Dim limitTimesBefore As Integer
            Dim alertTimesBefore As Integer
            Dim usedTimesBefore As Integer
            Dim strSQL As String = String.Format("select LimitTimes,AlertTimes,UsedTimes from m_Mould_t where MouldID='{0}'", txtMouidID.Text.Trim)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            If dt.Rows.Count = 0 Then
                MessageUtils.ShowInformation("不存在模具编号[" & MouldId & "]!")
                Return
            End If

            limitTimesBefore = dt.Rows(0)(0).ToString
            alertTimesBefore = dt.Rows(0)(1).ToString
            usedTimesBefore = dt.Rows(0)(2).ToString
            Dim usedTimesAdd As Integer = txtUsedTimes.Text.Trim

            If usedTimesAdd + usedTimesBefore > alertTimesBefore Then
                MessageUtils.ShowWarning("模号超出预警数,请重新填写!")
                Return
            End If

            Dim strBSQL As New StringBuilder
            strBSQL.AppendFormat("update m_Mould_t set UsedTimes=UsedTimes+{0} where MouldID='{1}' ", usedTimesAdd, txtMouidID.Text.Trim)
            strBSQL.Append(" INSERT INTO m_MouldLog_t(MouldID,LimitTimesBefore,AlertTimesBefore,UsedTimesBefore,UsedTimesAdd,UserID,Intime) ")
            strBSQL.Append(" VALUES(")
            strBSQL.AppendFormat("'{0}',", txtMouidID.Text.Trim)
            strBSQL.AppendFormat("'{0}',", limitTimesBefore)
            strBSQL.AppendFormat("'{0}',", alertTimesBefore)
            strBSQL.AppendFormat("'{0}',", usedTimesBefore)
            strBSQL.AppendFormat("'{0}',", usedTimesAdd)
            strBSQL.AppendFormat("'{0}',", VbCommClass.VbCommClass.UseId)
            strBSQL.AppendFormat("getdate()")
            strBSQL.Append(")")

            DbOperateUtils.ExecSQL(strBSQL.ToString)
            MessageUtils.ShowInformation("模号[" & txtMouidID.Text.Trim & "]使用寿命维护成功!")
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
#End Region

End Class