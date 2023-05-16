Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Windows.Forms

Public Class FrmLenovoEDIMO
    Dim opFlag As Int16 = 0    '新增,修改,初始狀態的標誌 



    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        opFlag = "1"
        SetStatus(opFlag)
        DgMoData.Rows.Clear()
        'TlelCount.Text = "0"
        Me.TxtMoNumber.Clear()
        Me.TxtMoNumber.Focus()

     
    End Sub

    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始狀態
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.ToolCancel.Enabled = False
                Me.ToolSave.Enabled = False
                Me.ToolQueryMO.Enabled = True
            Case 1      '新增
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolCancel.Enabled = True
                Me.ToolSave.Enabled = True
                Me.ToolQueryMO.Enabled = False
            Case 2      '修改
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolCancel.Enabled = True
                Me.ToolSave.Enabled = True
                Me.ToolQueryMO.Enabled = False
            Case 3
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolCancel.Enabled = True
                Me.ToolSave.Enabled = True
                Me.ToolQueryMO.Enabled = False
        End Select
    End Sub

    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        If Me.DgMoData.Rows.Count = 0 OrElse Me.DgMoData.CurrentRow Is Nothing Then
            MessageBox.Show("请选择需要修改工单!")
            Exit Sub
        End If
        opFlag = "3"
        SetStatus(opFlag)
    End Sub

    Private Sub ToolSave_Click(sender As Object, e As EventArgs) Handles ToolSave.Click
        Dim strItemNum As String = "0", strChildMoid As String = "", o_strSerial As String = ""
        Dim strSQL As String = "", mos As String = Nothing
        Dim SqlItemStr As New System.Text.StringBuilder
        Dim ItemSeq As String = String.Empty
        Me.LblMsg.Text = String.Empty

        Try
            If (opFlag = 1) Then  'New Save
                DgMoData.EndEdit()

                If Me.ToolCancel.Enabled = True Then
                    If Not BaseDataCheck() Then
                        Exit Sub
                    End If

                    SqlItemStr.Append(" If NOT EXISTS ( SELECT TOP 1 1 FROM m_NGMOSendToEDI_t  WHERE moid ='" & Trim(TxtMoNumber.Text) & "' AND SENDDATE='" & dtSendDate.Value.ToString("yyyy-MM-dd") & "')")
                    SqlItemStr.Append(" Begin ")
                    SqlItemStr.Append(" INSERT INTO m_NGMOSendToEDI_t(Moid,SendDate,IsSend)")
                    SqlItemStr.Append(" VALUES('" & Trim(TxtMoNumber.Text) & "','" & dtSendDate.Value.ToString("yyyy-MM-dd") & "','N')")
                    SqlItemStr.Append(" End ")

                    DbOperateUtils.ExecSQL(SqlItemStr.ToString)
                    SetStatus(0) 'Add by cq 20160106
                    MessageUtils.ShowInformation("工单资料保存成功")
                    Exit Sub
                End If

                If SqlItemStr.ToString = "" Then Exit Sub
                Try
                    DbOperateUtils.ExecSQL(SqlItemStr.ToString)
                    MessageBox.Show("工单资料保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SetStatus(0)
                    Dim FiterSqlStr As String = ""   ' GetFiterString()

                    'If FiterSqlStr = "" Then
                    '    ' TlelCount.Text = "0"
                    '    Exit Sub
                    'End If
                    LoadDataInGrid(FiterSqlStr)
                    Exit Sub
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End Try
            Else
                Try

                    Dim FiterSqlStr As String = ""  'GetFiterString()

                    If FiterSqlStr = "" Then
                        'TlelCount.Text = "0"
                        Exit Sub
                    End If
                    LoadDataInGrid(FiterSqlStr)
                    SetStatus(0)
                    '  SetControl()
                Catch ex As Exception
                    MessageUtils.ShowError("编辑工单异常，请联系开发人员！")
                End Try
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub LoadDataInGrid(ByVal FiterSqlStr)
        Dim K As Integer
        Dim UserDg As DataTable
        Dim Sqlstr As String
        Try
            If DgMoData.Rows.Count > 0 Then
                DgMoData.Rows.Clear()
            End If

            DgMoData.ScrollBars = ScrollBars.None
            Sqlstr = "SELECT TOP 100 a.moid, CONVERT(VARCHAR(10),SendDate,120) as SendDate  FROM m_NGMOSendToEDI_t a "

            UserDg = DbOperateUtils.GetDataTable(Sqlstr & FiterSqlStr)

            For K = 0 To UserDg.Rows.Count - 1
                Try
                    'iSelect, 工单编号,sendate
                    DgMoData.Rows.Add(False, UserDg.Rows(K)("Moid"), UserDg.Rows(K)("SendDate"))

                Catch ex As Exception
                    Continue For
                End Try
            Next

            DgMoData.ScrollBars = ScrollBars.Both
            ' TlelCount.Text = UserDg.Rows.Count
            UserDg.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Function BaseDataCheck() As Boolean
        If Me.TxtMoNumber.Text = "" Then
            MessageUtils.ShowError("必须输入工单编号")
            TxtMoNumber.Focus()
            Return False
        End If
        If Me.dtSendDate.Text.Trim = "" Then
            MessageUtils.ShowError("必须维护日期")
            dtSendDate.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub ToolQueryMO_Click(sender As Object, e As EventArgs) Handles ToolQueryMO.Click
        Try

            Me.LblMsg.Text = ""
            Dim FiterSqlStr As String = ""
            FiterSqlStr = GetFiterString()

            If FiterSqlStr = "" Then
                'TlelCount.Text = "0"
                Exit Sub
            End If
            LoadDataInGrid(FiterSqlStr)
        Catch ex As Exception
        End Try
    End Sub

    Private Function GetFiterString() As String

        Dim SqlStr As String = ""
        Dim MoComBoxStr As String = ""
        Dim o_strMultiMOSQL As String = ""

        If TxtMoNumber.Text.Trim <> "" Then
            For Each sMO As String In TxtMoNumber.Text.Trim.Split(vbNewLine)
                If Not String.IsNullOrEmpty(sMO) Then
                    o_strMultiMOSQL &= " A.MOID LIKE '%" & sMO.Trim() & "%'" + " OR"
                End If
            Next

            o_strMultiMOSQL = o_strMultiMOSQL.Substring(0, o_strMultiMOSQL.Length - 3)

            SqlStr = " WHERE " & o_strMultiMOSQL
        End If



        If SqlStr = "" Then
            ' SqlStr = " WHERE a.Factory='" & VbCommClass.VbCommClass.Factory & "'"
            SqlStr = SqlStr & " where CONVERT(datetime,CONVERT(varchar(10), senddate,120)) between '" & DtStar.Value.ToShortDateString & "' and '" & DtEnd.Value.ToShortDateString & "'"

        Else
            SqlStr = SqlStr & " AND CONVERT(datetime,CONVERT(varchar(10), senddate,120)) between '" & DtStar.Value.ToShortDateString & "' and '" & DtEnd.Value.ToShortDateString & "'"

        End If


        Return SqlStr + "  ORDER BY senddate DESC "

    End Function

    Private Sub FrmLenovoEDIMO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DtStar.Value = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")
        Me.DtEnd.Value = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd")
    End Sub

    Private Sub ToolCancel_Click(sender As Object, e As EventArgs) Handles ToolCancel.Click
        opFlag = 0
        SetStatus(opFlag)
        Me.Panel1.Enabled = False
        Me.TxtMoNumber.Focus()
    End Sub

    Private Sub ExitFrom_Click(sender As Object, e As EventArgs) Handles ExitFrom.Click
        Me.Close()
    End Sub

    Private Sub toolDelete_Click(sender As Object, e As EventArgs) Handles toolDelete.Click
        Dim lsSQL As String = String.Empty
        Dim o_strMOID As String = String.Empty
        Dim o_strSendDate As String = String.Empty

        If IsNothing(Me.DgMoData.CurrentRow) Then Exit Sub

        o_strMOID = Me.DgMoData.CurrentRow.Cells("moid").Value
        o_strSendDate = Me.DgMoData.CurrentRow.Cells("SendDate").Value

        lsSQL = " Delete from m_NGMOSendToEDI_t WHERE moid ='" & o_strMOID & "' AND SENDDATE='" & o_strSendDate & "' "

        If (MessageUtils.ShowConfirm("确定要删除？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            DbOperateUtils.ExecSQL(lsSQL)
        End If
        Me.LblMsg.Text = "删除成功！"
    End Sub
End Class