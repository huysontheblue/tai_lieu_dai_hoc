Imports MainFrame

Public Class FrmQCData

    Public g_sUpdateType, DEFECT_CODE, DEFECT_LEVEL, DEFECT_DESC As String

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If editCode.Text.Trim = "" Then
            MessageBox.Show("不良代码不能为空")
            editCode.Focus()
        End If
        If editDesc.Text.Trim = "" Then
            MessageBox.Show("不良描述不能为空")
        End If
        If g_sUpdateType = "APPEND" Then
            Dim strSQL As String
            Dim sMaxID As String
            Dim dt As DataTable
            strSQL = "SELECT * FROM m_QCDEFECT_t WHERE DEFECT_CODE = '" + editCode.Text.Trim() + "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 1 Then
                MessageBox.Show("不良代码重复，请重新输入！")
                Return
            Else
                strSQL = "SELECT MAX(DEFECT_ID)+1 FROM m_QCDEFECT_t"
                dt = DbOperateUtils.GetDataTable(strSQL)
                sMaxID = dt.Rows(0)(0).ToString()
                strSQL = "Insert into m_QCDEFECT_t(DEFECT_ID,DEFECT_CODE,DEFECT_LEVEL,DEFECT_DESC,UPDATE_USERID,UPDATE_TIME)" &
                    " Values" &
                    "('" + sMaxID + "',N'" + editCode.Text.Trim() + "',N'" + combDefectLevel.Text.ToString.Trim() + "',N'" + editDesc.Text.Trim() + "','" + VbCommClass.VbCommClass.UseId + "',getdate())"
                dt = DbOperateUtils.GetDataTable(strSQL)
                MessageBox.Show("保存成功")
                Me.Close()
            End If
        Else
            Dim strSQL, DEFECT_ID As String
            Dim dt As DataTable
            strSQL = "SELECT DEFECT_ID FROM m_QCDEFECT_t WHERE DEFECT_CODE = '" + editCode.Text.Trim() + "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            DEFECT_ID = dt.Rows(0)(0).ToString()
            strSQL = "UPDATE m_QCDEFECT_t SET DEFECT_CODE =N'" + editCode.Text.Trim() + "',DEFECT_LEVEL =N'" + combDefectLevel.Text.ToString.Trim() + "',DEFECT_DESC=N'" + editDesc.Text.ToString.Trim() + "',UPDATE_USERID='" + VbCommClass.VbCommClass.UseId + "',UPDATE_TIME = getdate() WHERE DEFECT_ID = '" + DEFECT_ID + "'"
            dt = DbOperateUtils.GetDataTable(strSQL)
            MessageBox.Show("修改成功")
            Me.Close()
        End If
    End Sub

    Private Sub FrmQCData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combDefectLevel.SelectedIndex = 0
        Me.Text = "新增"
        If g_sUpdateType = "Update" Then
            Me.Text = "修改"
            editCode.Text = DEFECT_CODE.ToString()
            editCode.ReadOnly = True
            editDesc.Text = DEFECT_DESC.ToString()
            combDefectLevel.SelectedIndex = combDefectLevel.Items.IndexOf(DEFECT_LEVEL.ToString())
        End If
    End Sub
End Class