Imports MainFrame
Imports System.Windows.Forms

Public Class EquMachineCommon

    ''' <summary>
    ''' 设备状态
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxStatus(ByVal ColComboBox As ComboBox, Optional type As String = "")
        Dim strSQL As String = "select value,(value + ':' + text)text from m_BaseData_t where itemkey = 'EquMachineStatus' and status = 1 order by SORT"
        strSQL = String.Format(strSQL, type)

        BindCombox(strSQL, ColComboBox, "text", "value")
    End Sub

    ''' <summary>
    ''' 机器类型
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxMachineType(ByVal ColComboBox As ComboBox, Optional type As String = "")
        Dim strSQL As String = " select distinct machine_Type from m_Equ_MachineM_t "
        strSQL = String.Format(strSQL, type)

        BindCombox(strSQL, ColComboBox, "machine_Type", "machine_Type")
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


    Public Shared Function getUserName(ByVal text As TextBox) As String
        Dim dtUserName As DataTable
        dtUserName = DbOperateUtils.GetDataTable(" select *  from m_Users_t where UserID =N'" + text.Text.Trim + "' ")
        If (dtUserName.Rows.Count > 0) Then
            Return dtUserName.Rows(0).Item("username").ToString
        Else
            Return ""
        End If
    End Function


End Class
