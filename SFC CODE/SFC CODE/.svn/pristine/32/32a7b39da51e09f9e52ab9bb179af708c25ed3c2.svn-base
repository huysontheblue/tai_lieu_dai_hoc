''蠢传ゴ    稼稻瞝   2007/05/16

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text
Imports MainFrame

#End Region

Public Class FrmReCheckData

    Dim QtyStr As String = ""
    Dim BarRuleStr As String = ""

#Region "怠砰秙ㄆン"

    Private Sub BnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnCancel.Click

        Me.Close()
        ScanPrint.ReplacePrintCheck = False

    End Sub

#End Region

    Private Sub TxtPassWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassWord.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.ActiveControl = BnOpenlock
            BnOpenlock_Click(sender, e)
        End If

    End Sub

    Private Sub BnOpenlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnOpenlock.Click

        If TxtPassWord.Text = "" Then
            MessageBox.Show("解锁密码不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Me.TxtPassWord.Focus()
            Me.TxtPassWord.SelectAll()
            Exit Sub
        End If
        If TxtPackNo.Text = "" Then
            MessageBox.Show("外箱条码不能为空...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TxtPackNo.Focus()
            Me.TxtPackNo.SelectAll()
            Exit Sub
        End If
        Dim LoginClass As New TextHandle
        Dim CheckRead As SqlClient.SqlDataReader
        Dim PubClass As New SysDataBaseClass

        CheckRead = PubClass.GetDataReader("select distinct a.userid from m_Users_t a left join m_userright_t b on a.userid=b.userid where a.UserId='" & SysMessageClass.UseId & "' and a.autoid='" & Me.TxtPassWord.Text & "' and b.tkey='m0510a_'")

        If Not CheckRead.Read Then
            MessageBox.Show("你没有解锁权限...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '  ScanPrint.ReplacePrintCheck = False
            CheckRead.Close()
            Me.TxtPassWord.Focus()
            Me.TxtPassWord.SelectAll()
            Exit Sub
        End If
        CheckRead.Close()

        CheckRead = PubClass.GetDataReader("select * from m_PackingCheckCarton_t where CheckType='1' and CartonId='" & TxtPackNo.Text.Trim & "'")

        If Not CheckRead.Read Then
            MessageBox.Show("该外箱校验记录不存在...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CheckRead.Close()
            Me.TxtPackNo.Focus()
            Me.TxtPackNo.SelectAll()
            Exit Sub
        End If
        CheckRead.Close()

        'mark by cq 20180301
        'Try
        '    Dim sql_Clear As System.Text.StringBuilder = New System.Text.StringBuilder
        '    sql_Clear.Append("delete b from m_PackingCheckCarton_t a join  m_PackingCheckBarcode_t b on a.PackingCheckCartonId=b.PackingCheckCartonId where a.CheckType='1'  and a.CartonId='" & TxtPackNo.Text.Trim & "'")
        '    sql_Clear.Append("delete a from m_PackingCheckCarton_t a where a.CheckType='1'  and a.CartonId='" & TxtPackNo.Text.Trim & "'")
        '    PubClass.ExecSql(sql_Clear.ToString)
        '    MessageBox.Show("清除成功，该外箱可以重新校验", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.Close()
        'Catch ex As Exception
        '    MessageBox.Show("清除失败..." + ex.ToString, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try




    End Sub

    Private Sub FrmReplaceLock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Me.ActiveControl.Name <> "BnOpenlock" Then ScanPrint.ReplacePrintCheck = False

    End Sub

    Private Sub FrmReplaceLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim SqlStr As String
        'Dim PubClass As New SysDataBaseClass
        'Dim Dr As SqlClient.SqlDataReader
        'SqlStr = "select * from m_PartPack_t where packid='C' and partid='" & ScanPrint.PartidStr & " '  and usey='Y' "
        'Dr = PubClass.GetDataReader(SqlStr)
        'If Dr.Read Then
        '    QtyStr = Dr("Qty").ToString
        '    BarRuleStr = Dr("coderuleid").ToString
        'End If
        'Dr.Close()

    End Sub

    Private Sub TxtPackNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPackNo.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.TxtPassWord.Focus()
        End If

    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim lsSQL As String = String.Empty
        Try

            lsSQL = " SELECT * from m_PackingCheckCarton_t where  CartonId='" & TxtPackNo.Text.Trim & "'"

            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)

                dgvPackCheck.DataSource = o_dt

            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub toolRemove_Click(sender As Object, e As EventArgs) Handles toolRemove.Click

        Try
            Dim sql_Clear As System.Text.StringBuilder = New System.Text.StringBuilder
            If Me.dgvPackCheck.RowCount <= 0 Then
                Exit Sub
            End If

            If IsNothing(Me.dgvPackCheck.CurrentRow) Then
                Exit Sub
            End If
            Dim strPackingCheckCartonId As String = Me.dgvPackCheck.CurrentRow.Cells(0).Value.ToString

            'first backup delete data
            '  m_PackingCheckBarcode_t
            sql_Clear.Append(" INSERT INTO  m_PackingCheckBarcode_tDelete SELECT * FROM m_PackingCheckBarcode_t  ")
            sql_Clear.Append(" WHERE PackingCheckCartonId='" & strPackingCheckCartonId & "'")
            sql_Clear.Append(" DELETE  FROM m_PackingCheckBarcode_t  WHERE PackingCheckCartonId='" & strPackingCheckCartonId & "'")


            sql_Clear.Append(" INSERT INTO  m_PackingCheckCarton_tDelete SELECT * FROM m_PackingCheckCarton_t  ")
            sql_Clear.Append(" WHERE PackingCheckCartonId='" & strPackingCheckCartonId & "'")

            'sql_Clear.Append(" DELETE b from m_PackingCheckCarton_t a join  m_PackingCheckBarcode_t b on a.PackingCheckCartonId=b.PackingCheckCartonId ")
            'sql_Clear.Append(" WHERE a.CheckType='1'  and a.CartonId='" & TxtPackNo.Text.Trim & "'")
            sql_Clear.Append(" DELETE  FROM m_PackingCheckCarton_t  WHERE PackingCheckCartonId='" & strPackingCheckCartonId & "'")

            '(MessageUtils.ShowConfirm("确定要审核确认？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK)
            If MessageUtils.ShowConfirm("你确定删除该箱的检查记录吗？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                DbOperateUtils.ExecSQL(sql_Clear.ToString)
            End If

            MessageBox.Show("清除成功，该外箱可以重新校验", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("清除失败..." + ex.ToString, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
End Class