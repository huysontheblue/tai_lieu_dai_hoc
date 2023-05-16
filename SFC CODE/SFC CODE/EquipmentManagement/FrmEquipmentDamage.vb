Imports MainFrame
Imports MainFrame.SysCheckData


Public Class FrmEquipmentDamage

    Private Sub FrmEquipmentDamage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataLoad()
    End Sub

    Private Sub DataLoad()
        Dim FactoryName = VbCommClass.VbCommClass.Factory
        Dim Profitcenter = VbCommClass.VbCommClass.profitcenter
        Dim where = " where 1=1 "
        If String.IsNullOrEmpty(txtEquimentNO.Text.Trim()) = False Then
            where += " AND a.EquipmentNo='" & txtEquimentNO.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(txtPartNumber.Text.Trim()) = False Then
            where += " and a.EquipmentNo in (select EquipmentNo from m_Equipment_t where PartNumber in ( select PartNumber from m_equipmenthardware_t" & vbCrLf &
            "where HardWarePartNumber='" & txtPartNumber.Text.Trim() & "'))"
        End If
        where += " and a.FactoryName='" & FactoryName & "' and a.Profitcenter='" & Profitcenter & "' order by a.InTime desc"
        Dim sql = "select top 500 a.*,b.ProcessParameters,b.PartNumber,b.RemainCount,(c.Receiver+'/'+d.UserName)Receiver ,c.line " & _
                  " ,dutyDept" & _
                  " from  m_Equipment_damage_t a " & _
                  " left join m_Equipment_t b on b.EquipmentNo=a.EquipmentNo " & _
                  " left join (SELECT Receiver,line,EquipmentNo FROM dbo.m_Equipment_BorrRetu_t WHERE  ReturnIsOK =0 and ReturnIsOK<>'') c on c.EquipmentNo=a.EquipmentNo" & _
                  " left join m_Users_t d on c.Receiver =d.UserID" + where
        Dim dt = DbOperateUtils.GetDataTable(sql)
        dgvData.AutoGenerateColumns = False
        dgvData.DataSource = dt
        sql = "select count(1) from m_Equipment_damage_t where FactoryName='" & FactoryName & "' and Profitcenter='" & Profitcenter & "'"
        tsslblTotalCount.Text = "一共" + DbOperateUtils.GetDataTable(sql).Rows(0)(0).ToString() + "笔数据"
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        DataLoad()
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        txtEquimentNO.Text = Nothing
        txtPartNumber.Text = Nothing
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 汇出Excel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExcelOut_Click(sender As Object, e As EventArgs) Handles BtnExcelOut.Click
        Dim FactoryName = VbCommClass.VbCommClass.Factory
        Dim Profitcenter = VbCommClass.VbCommClass.profitcenter
        Dim where = " where 1=1 "
        If String.IsNullOrEmpty(txtEquimentNO.Text.Trim()) = False Then
            where += " AND a.EquipmentNo='" & txtEquimentNO.Text.Trim() & "'"
        End If
        If String.IsNullOrEmpty(txtPartNumber.Text.Trim()) = False Then
            where += " and a.EquipmentNo in (select EquipmentNo from m_Equipment_t where PartNumber in  ( select PartNumber from m_equipmenthardware_t" & vbCrLf &
            "where HardWarePartNumber='" & txtPartNumber.Text.Trim() & "'))"
        End If
        where += " and a.FactoryName='" & FactoryName & "' and a.Profitcenter='" & Profitcenter & "' order by a.InTime desc"
        Dim sql = " select a.EquipmentNO,b.PartNumber,b.ProcessParameters,b.RemainCount,a.EmpNO,a.EmpName,a.InTime,a.Remark,a.FactoryName,a.Profitcenter,(c.Receiver+'/'+d.UserName)Receiver,c.line,a.dutyDept " & _
                  " from  m_Equipment_damage_t a left join m_Equipment_t b on b.EquipmentNo=a.EquipmentNo " & _
                  " left join (SELECT Receiver,line,EquipmentNo FROM dbo.m_Equipment_BorrRetu_t WHERE  ReturnIsOK =0 and ReturnIsOK<>'') c on c.EquipmentNo=a.EquipmentNo" & _
                  " left join m_Users_t d on c.Receiver =d.UserID" + where
        Dim dt = DbOperateUtils.GetDataTable(sql)
        Dim ay() As String = {"治具编号", "治具料号", "加工参数", "剩余使用次数", "报废人工号", "报废人姓名", "报废时间", "报废原因", "厂区", "利润中心", "借出人", "借出线别", "责任单位"}
        VbCommClass.NPOIExcle.DataTableExportToExcle(dt, ay, "治具报废列表.xls")
    End Sub
End Class