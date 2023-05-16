Imports MainFrame.SysCheckData
Imports System.Text.RegularExpressions
Imports System.Text
Imports MainFrame

Public Class FrmDateCodeInput

    Public m_StrDateCodeList As String = String.Empty
    Public m_StrDateCodeQtyList As String = String.Empty
    Public m_strDateCode1 As String=""
     Public m_blnFinish As Boolean =False
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            If Not checkdata() Then
                Exit Sub
            End If

            '循环前再清掉变量
            m_StrDateCodeList = "" : m_StrDateCodeQtyList = ""

            For Each dr As DataGridViewRow In dgvDCList.Rows
                m_StrDateCodeList &= IIf(String.IsNullOrEmpty(m_StrDateCodeList), "", ",") + dr.Cells(0).Value.ToString
                m_StrDateCodeQtyList &= IIf(String.IsNullOrEmpty(m_StrDateCodeQtyList), "", ",") + dr.Cells(1).Value.ToString
            Next

            If Not RecordDateCodeInfo("") Then
                Exit Sub
            End If

            Me.DialogResult = DialogResult.OK
            m_blnFinish=True
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Function RecordDateCodeInfo(ByVal packBarCode As String)  as boolean
        Try
            Dim strSQL As New StringBuilder
            strSQL.Append(" DECLARE @RTVALUE varchar(10), @strmsgText varchar(200) ")
            strSQL.Append(" EXECUTE [m_RecordDateCodeInfo_P] '" & Trim(txtBigCarton_Hide.Text) & "','" & Trim(txtCartonID.Text) & "', '" & m_StrDateCodeList & "', '" & m_StrDateCodeQtyList & "','" & VbCommClass.VbCommClass.UseId & "',")
            strSQL.Append(" @RTVALUE OUTPUT, @strmsgText OUTPUT ")
            strSQL.Append(" SELECT @RTVALUE,@strmsgText")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        'SysMessageClass.WriteErrLog(dt.Rows(0)(1), "FrmDateCodeInput", "RecordDateCodeInfo", "BarCodeScan")
                        MessageUtils.ShowError(dt.Rows(0)(1).ToString)
                        Return False
                    Case "1"
                        'OK
                        Return True
                    Case Else
                        'do nothing
                End Select
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmDateCodeInput", "RecordQRCodeInfo", "BarCodeScan")
        End Try
    End Function

        ''' <summary>
        ''' 检查输入的是否合法
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
    Public Function checkdata() As Boolean

        If dgvDCList.RowCount <= 0 Then
            MessageUtils.ShowError("请维护D/C信息！")
            Return False
        End If

        If dgvDCList.RowCount > 2 Then
            MessageUtils.ShowError("至多只能维护两个D/C信息！")
            Return False
        End If

        Return True

    End Function

    Private Sub txtDCQty_Leave(sender As Object, e As EventArgs) Handles txtDCQty.Leave

        If Not String.IsNullOrEmpty(Me.txtDCQty.Text) Then
            If (Not IsWholeNumber(Me.txtDCQty.Text.Trim())) Then
                MessageUtils.ShowError("输入必须为数字，请检查！")
                Exit Sub
            End If

            If Val(Me.txtDCQty.Text) > Val(Me.txtCartonCapacity.Text) Then
                MessageUtils.ShowError("D/C的数量不允许超过装箱容量，请检查！")
                Exit Sub
            Else
                If Me.dgvDCList.Rows.Count <= 0 Then
                    Me.dgvDCList.Rows.Insert(0, Me.txtDateCode.Text, Me.txtDCQty.Text)
                Else
                    If Me.txtDateCode.Text.ToUpper() <> Me.dgvDCList.Rows(0).Cells(0).Value.ToString.ToUpper Then
                        Me.dgvDCList.Rows.Insert(0, Me.txtDateCode.Text, Me.txtDCQty.Text)
                    End If
                End If
            End If
        End If
    End Sub
    Public Function IsWholeNumber(ByVal strNumber As String) As Boolean
        Dim notWholePattern As Regex = New Regex("^[\-]?[0-9]*$")    '^[\-]?[0-9]*$
        Return notWholePattern.IsMatch(strNumber, 0)
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If String.IsNullOrEmpty(Me.txtDateCode.Text) Then
            MessageUtils.ShowError("必须输入D/C！")
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.txtDCQty.Text) Then
            MessageUtils.ShowError("必须输入D/C数量！")
            Exit Sub
        End If

        If Me.dgvDCList.Rows.Count > 0 Then
            If Me.txtDateCode.Text.ToUpper() = dgvDCList.Rows(0).Cells(0).Value.ToString.ToUpper Then
                ' MessageUtils.ShowError("重复的D/C,不允许添加！")
                Exit Sub
            End If
        End If

        Me.dgvDCList.Rows.Insert(0, Me.txtDateCode.Text, Me.txtDCQty.Text)
        Me.txtDateCode.Text = "" : Me.txtDCQty.Text = ""
    End Sub

    Public Function checkAddData() As Boolean
        If String.IsNullOrEmpty(Me.txtDateCode.Text) Then
            MessageUtils.ShowError("必须输入D/C！")
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtDCQty.Text) Then
            MessageUtils.ShowError("必须输入D/C数量！")
            Return False
        End If
    End Function

    Private Sub FrmDateCodeInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strSQL As String = "exec GetCartonCapacityDC_p '{0}','{1}' "
        strSQL = String.Format(strSQL, txtPartID_hide.Text.Trim, txtCartonID.Text)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Me.txtCartonCapacity.Text = dt.Rows(0)(0).ToString()
        Else
            MessageUtils.ShowError("抓取装箱容量失败！")
            Exit Sub
        End If

        Me.txtDateCode.Focus()

    End Sub



    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

        If Not IsNothing(Me.dgvDCList.CurrentRow) Then
            If MessageUtils.ShowConfirm("确定要移除这行数据吗？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                Me.dgvDCList.Rows.Remove(Me.dgvDCList.CurrentRow)
            End If
        End If
    End Sub

    Private Sub FrmDateCodeInput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If m_blnFinish = False Then
            MessageUtils.ShowWarning("没维护完成D/C,不允许关闭！")
            e.Cancel = True
        End If
    End Sub
End Class