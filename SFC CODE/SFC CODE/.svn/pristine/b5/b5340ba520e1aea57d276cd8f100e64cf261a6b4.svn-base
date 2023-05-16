Imports MainFrame

Public Class FrmQueryMaterialInOut

    'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Private Sub FrmQueryMaterialInOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")
        DgMoData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click
        DgMoData.DataSource = ""
        ShowDate()
    End Sub
    Private Sub ShowDate()
        Dim strSql As String
        Dim dt As DataTable
        Dim StartDT, EndDT As String
        If cbIn.Checked = True Then
            StartDT = DtStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
            EndDT = DtEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
            If cbOut.Checked = True Then
                Dim starDTP, endDTP As String
                starDTP = dtpStar.Value.ToString("yyyy/MM/dd HH:mm:ss")
                endDTP = dtpEnd.Value.ToString("yyyy/MM/dd HH:mm:ss")
                strSql = "select Lotid 批次号,DeliveryNo 送货单号,Ppartid 料件编号,InQty 入库数量,InUserID 入库人,Intime 入库时间,OutQty 出库数量,OutUserID 出库人,Outtime 出库时间  from m_MaterialLotInOut_t where Intime between  '" + StartDT + "' and '" + EndDT + "' and Outtime between '" + starDTP + "' and '" + endDTP + "'"
            Else
                strSql = "select Lotid 批次号,DeliveryNo 送货单号,Ppartid 料件编号,InQty 入库数量,InUserID 入库人,Intime 入库时间,OutQty 出库数量,OutUserID 出库人,Outtime 出库时间  from m_MaterialLotInOut_t where Intime between  '" + StartDT + "' and '" + EndDT + "'"
            End If
        End If
        If CobCarton.Text <> "" Then
            strSql = strSql + " and DeliveryNo= '" + CobCarton.Text.Trim().ToString() + "'"
        End If
        If CobMaterial.Text <> "" Then
            strSql = strSql + "and Ppartid='" + CobMaterial.Text.Trim().ToString() + "'"
        End If
        If CobLotid.Text <> "" Then
            strSql = strSql + "and Lotid='" + CobLotid.Text.Trim().ToString() + "'"
        End If
        If CobUser.Text <> "" Then
            strSql = strSql + "and (InUserID='" + CobUser.Text.Trim().ToString() + "' or OutUserID='" + CobUser.Text.Trim().ToString() + "')"
        End If
        Try
            dt = DbOperateReportUtils.GetDataTable(strSql)
            DgMoData.DataSource = dt
            If DgMoData.Rows.Count > 0 Then
                'While dr.Read
                '    DgMoData.Rows.Add(dr!Cartonid, dr!ppid, dr!Userid, dr!Intime)
                'End While
                ToolCount.Text = DgMoData.Rows.Count
            Else
                MsgBox("查无记录，请重设查询条件！", MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton1, "提示信息")
                CobCarton.Text = ""
                CobUser.Text = ""
                ToolCount.Text = "0"
                DgMoData.Rows.Clear()
            End If
            'dr.Close()
            dt.Dispose()
        Catch ex As Exception
        End Try

    End Sub


    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(DgMoData, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Sub cbIn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIn.CheckedChanged
        If cbIn.Checked = False Then
            DtStar.Enabled = False
            DtEnd.Enabled = False
        Else
            DtStar.Enabled = True
            DtEnd.Enabled = True
        End If
    End Sub

    Private Sub cbOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOut.CheckedChanged
        If cbOut.Checked = False Then
            dtpStar.Enabled = False
            dtpEnd.Enabled = False
        Else
            dtpEnd.Enabled = True
            dtpStar.Enabled = True

        End If
    End Sub
End Class