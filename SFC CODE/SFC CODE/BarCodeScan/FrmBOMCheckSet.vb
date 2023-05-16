Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmBOMCheckSet
    Public Enum enumBOMType
        BoMAll = 1
        BoMCheckSelect = 2
    End Enum


    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        If txtPPartID.Text.Trim <> "" Then
            'If Select_Xianbie.Text.Trim <> "" Then
            '    BindBOMGridSearch_Select(" AND ( PPartID LIKE N''%" & txtPPartID.Text.Trim & "%''') AND ( lineid LIKE N''%" & Select_Xianbie.Text.Trim & "%'') ")
            'Else
            BindBOMGridSearch_Select()
            BindBOMGridAll()
        Else
            MessageUtils.ShowError("请输入产品料号！")
            Exit Sub
        End If
        ' Else
        'If Select_Xianbie.Text.Trim <> "" Then
        '    BindBOMGridSearch(" AND ( lineid LIKE N''%" & Select_Xianbie.Text.Trim & "%'') ")
        'Else
        '    BindBOMGridSearch()
        'End If

        ' End If
    End Sub

    ''' <summary>
    ''' 查询 该父料号的 下面的BOM组成明细清单
    ''' </summary>
    ''' <param name="where"></param>
    ''' <remarks></remarks>
    Private Sub BindBOMGridSearch_Select(Optional ByVal where As String = "")

        Dim strSQL As String = ""
        Try

            '根据配置文件标记是否选中
            Dim PPartID As String = txtPPartID.Text ' ScanCommon.GetBOMList("")
            strSQL = "execute GetBOMCheckListSelected '" & PPartID & "','2','" & where & "'"
            dgvNeedCheckSelected.Rows.Clear()
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            For Each row As DataRow In dt.Rows
                dgvNeedCheckSelected.Rows.Add(row("Flag").ToString(), row("PartID").ToString(), _
                                               row("typedest").ToString(), row("AmountQty").ToString())
            Next
            dgvNeedCheckSelected.Columns(1).ReadOnly = True
            dgvNeedCheckSelected.Columns(2).ReadOnly = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="where"></param>
    ''' <remarks></remarks>
    Private Sub BindBOMGridAll(Optional ByVal where As String = "")
        Dim strSQL As String = ""
        Try
            '根据配置文件标记是否选中
            Dim PPartID As String = txtPPartID.Text ' ScanCommon.GetBOMList("")
            strSQL = "execute GetBOMCheckListSelected '" & PPartID & "','1','" & where & "'"
            dgvAllBOMPart.Rows.Clear()
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            For Each row As DataRow In dt.Rows
                dgvAllBOMPart.Rows.Add(row("Flag").ToString(), row("PartID").ToString(), _
                                       row("typedest").ToString(), row("AmountQty").ToString())
            Next
            dgvAllBOMPart.Columns(1).ReadOnly = True
            dgvAllBOMPart.Columns(2).ReadOnly = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim PartIDList As String = ""
        dim o_strPPartID As String =""
        Try
            '将当前用户选择保存到配置文件
            For Each row As DataGridViewRow In dgvNeedCheckSelected.Rows
                PartIDList = PartIDList & row.Cells("PartID2").Value & ","
            Next

            PartIDList = PartIDList.TrimEnd(",")

            'If String.IsNullOrEmpty(PartIDList) Then
            '    MessageUtils.ShowError("请至少选择一个料号")
            '    Exit Sub
            'End If

            If Not String.IsNullOrEmpty(Me.txtPPartID_Hide.Text) Then
                o_strPPartID = Me.txtPPartID_Hide.Text
            Else
                o_strPPartID = Me.txtPPartID.Text
            End If

            ScanCommon.SaveCheckBOMList(o_strPPartID, PartIDList, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter, VbCommClass.VbCommClass.UseId)
            ' Me.SaveEquip = "Y"
            Me.Close()

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmBOMCheckSet", "btnOK_Click", "BarScan")
        End Try
    End Sub

    Private Sub FrmBOMCheckSet_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(Me.txtPPartID_Hide.Text) Then
           me.txtPPartID.Text = Me.txtPPartID_Hide.Text 
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        For i As Integer = dgvAllBOMPart.Rows.Count - 1 To 0 Step -1
            If dgvAllBOMPart.Rows(i).Cells("BOM_Select").Value.ToString() = "Y" Then
                dgvNeedCheckSelected.Rows.Add("N", dgvAllBOMPart.Rows(i).Cells("PartID").Value.ToString(),
                                              dgvAllBOMPart.Rows(i).Cells("typedest").Value.ToString(),
                                              dgvAllBOMPart.Rows(i).Cells("AmountQty").Value.ToString()
                                              )
                dgvAllBOMPart.Rows.RemoveAt(i)
            End If
        Next
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
           Me.Close()
    End Sub

    Private Sub ChkAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAll.CheckedChanged
        Dim yy As String = ""
        Dim chk As CheckBox = CType(sender, CheckBox)
        yy = IIf(chk.Checked, "Y", "N")
        For Each dgvr As DataGridViewRow In dgvAllBOMPart.Rows
            dgvr.Cells("BOM_Select").Value = yy
        Next
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        For i As Integer = dgvNeedCheckSelected.Rows.Count - 1 To 0 Step -1
            If dgvNeedCheckSelected.Rows(i).Cells("BOM_Selected").Value.ToString() = "Y" Then
                dgvAllBOMPart.Rows.Add("N", dgvNeedCheckSelected.Rows(i).Cells("PartID2").Value.ToString(),
                                          dgvNeedCheckSelected.Rows(i).Cells("typedest2").Value.ToString(),
                                          dgvNeedCheckSelected.Rows(i).Cells("AmountQty2").Value.ToString()
                                          )
                dgvNeedCheckSelected.Rows.RemoveAt(i)
            End If
        Next
    End Sub

    Private Sub CheckAll2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAll2.CheckedChanged
        Dim yy As String = ""
        Dim chk As CheckBox = CType(sender, CheckBox)
        yy = IIf(chk.Checked, "Y", "N")
        For Each dgvr1 As DataGridViewRow In dgvNeedCheckSelected.Rows
            dgvr1.Cells("BOM_Selected").Value = yy
        Next
    End Sub
End Class