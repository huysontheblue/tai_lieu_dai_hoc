Imports MainFrame

Public Class PlanCommon

    ''' <summary>
    ''' 处理方式
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxClass(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "SELECT DISTINCT APS_COL1 value ,APS_COL1  text FROM [APS_Shift] "

        BindCombox(strSQL, ColComboBox, "value", "text")
    End Sub

#Region "BindComBox"
    Public Shared Sub BindCombox(ByVal SQL As String, ByVal ColComboBox As ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)

        Dim dr As DataRow = dt.NewRow

        dr(Text) = ""
        dr(value) = ""
        dt.Rows.InsertAt(dr, 0)

        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value
    End Sub
    Public Shared Sub BindComboxNoBlank(ByVal SQL As String, ByVal ColComboBox As ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)

        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value
    End Sub
#End Region


End Class
