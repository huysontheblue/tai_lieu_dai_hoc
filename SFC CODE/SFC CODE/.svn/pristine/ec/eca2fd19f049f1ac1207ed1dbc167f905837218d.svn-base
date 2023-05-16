Public Class FrmWorkOrder

    ''' <summary>
    ''' 工单
    ''' </summary>
    ''' <remarks></remarks>
    Public _MoNO As String
    
    ''' <summary>
    ''' 立讯料号
    ''' </summary>
    ''' <remarks></remarks>
    Public _PartNO As String

    ''' <summary>
    ''' 客户料号
    ''' </summary>
    ''' <remarks></remarks>
    Public _CustPartID As String

    Private Sub FrmWorkOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindData()
    End Sub

    ''' <summary>
    ''' 绑定数据源
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BindData()
        Dim Factory = VbCommClass.VbCommClass.Factory
        Dim Profitcenter = VbCommClass.VbCommClass.profitcenter
        Dim where = " and Factory='" & Factory & "' and Profitcenter='" & Profitcenter & "'"
        If String.IsNullOrEmpty(txtMOID.Text.Trim()) = False Then
            where += " and Moid like '%" & txtMOID.Text.Trim() & "%'"
        End If
        Dim sql = "SELECT TOP 100 Moid, PartID, Moqty, Remark FROM m_Mainmo_t WHERE FinalY='N' " & where & " ORDER BY Createtime DESC"
        dgvData.AutoGenerateColumns = False
        dgvData.DataSource = MainFrame.DbOperateUtils.GetDataTable(sql)
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        BindData()
    End Sub

    ''' <summary>
    ''' 取消
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub GetCheckedData()
        Me._MoNO = dgvData.CurrentRow.Cells("Moid").Value
        Me._PartNO = dgvData.CurrentRow.Cells("PartId").Value
        Dim sql = "select custpart from m_PartContrast_t " & vbCrLf &
        "where PAvcPart='" & Me._PartNO & "' and TAvcPart=PAvcPart"
        Me._CustPartID = MainFrame.DbOperateUtils.GetDataTable("exec Proc_GetCustPartByMoID '" & Me._MoNO & "'").Rows(0)(0).ToString()
    End Sub

    ''' <summary>
    ''' 单元格双击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick
        GetCheckedData()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        GetCheckedData()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class