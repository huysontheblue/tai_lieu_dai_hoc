Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmCopy
    Public ID As String = ""
    Dim Ssql As String
    Dim dg As DataTable
    Dim dr As DataTable
    Dim UseId = VbCommClass.VbCommClass.UseId
    Dim UseName = VbCommClass.VbCommClass.UseName
    Dim FactNO = VbCommClass.VbCommClass.Factory
    Dim Profitcenter = VbCommClass.VbCommClass.profitcenter

    Private Sub FrmCopy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Ssql = "SELECT PartID,Version,ECN_No,Remark FROM m_ProductStandardAllocation_t WHERE ID = '" + ID + "'"
        dg = DbOperateUtils.GetDataTable(Ssql)
        txtOldPart.Text = dg.Rows(0)(0).ToString
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Ssql = "DECLARE @pid VARCHAR(100)" &
            "Insert INTO m_ProductStandardAllocation_t (PartID,Version,ECN_No,Remark,Status,Usey ,CreateBy,CreateName,CreateTime,FactNO,Profitcenter)" &
            "VALUES ('" + txtNewPart.Text.Trim + "','" + dg.Rows(0)(1) + "','" + dg.Rows(0)(2) + "','" + dg.Rows(0)(3) + "','0','Y','" + UseId + "',N'" + UseName + "',getdate(),'" + FactNO + "','" + Profitcenter + "')" &
            "SELECT @pid= @@IDENTITY " &
            "INSERT INTO m_ProductStandardAllocationD_t " &
            "SELECT @pid AS MainID,OrderBy,StationType,StationName,SWorkingHours,UndulationTime" &
            ",OutPut,Equiment,Qty,BalancePerson,BalanceHours,BalanceQty " &
            ",Remark,GETDATE() AS INTIME ,'" + UseId + "' AS EMPNO,N'" + UseName + "' AS EMPNAME" &
            " FROM m_ProductStandardAllocationD_t WHERE MainID = N'" + ID + "'"
        dr = DbOperateUtils.GetDataTable(Ssql)
        MessageUtils.ShowInformation("复制成功!")
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class