
'客户资料维护
'Create by: 马锋
'Create time: 2015/05/27
'Update by: cq
'Update time: 2015/12/09
'更新者：田玉琳
'更新日期：20190614
'更新内容：为SAP开发准备

#Region "Imports"
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports MainFrame
Imports MainFrame.SysCheckData

#End Region

Public Class FrmCustomer

#Region "公共变量"

    Public opflag As Int16 = 0
    Private Enum m_enumdgvCustomer As Integer
        CusID = 0
        CusName
        Address
        Tel
        Fax
        Linkman
        Usey
        CusCode
    End Enum

#End Region

#Region "按键处理"

    Private Sub FrmRstationSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Erightbutton() '
        LoadDataToDatagridview(" ")
        ToolbtnState(opflag)
        dgvCustomer.Enabled = True
    End Sub

    Private Sub Erightbutton()
        Dim Reader As DataTable = DbOperateUtils.GetDataTable("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02003' and b.listy='N' where a.userid='" & VbCommClass.VbCommClass.UseId.ToLower.Trim & "'")
        Dim Obj As Object = Nothing
        Dim strSQL As String = String.Empty
        Try

            strSQL = " SELECT distinct b.Buttonid from m_UserRight_t  a JOIN m_Logtree_t  b on a.Tkey=b.Tkey and b.Formid='apm02003' and b.listy='N' " & _
                     " WHERE a.userid='" & VbCommClass.VbCommClass.UseId.ToLower.Trim & "'"

            For rowIndex As Integer = 0 To Reader.Rows.Count - 1
                Obj = CType(Me.GetType().GetField("_" & Reader.Rows(rowIndex)("Buttonid").ToString.Trim,
                                                  BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
                Obj.Tag = "Yes"
            Next
               
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '
                Me.toolAdd.Enabled = IIf(Me.toolAdd.Tag.ToString <> "Yes", False, True)
                Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                Me.toolAbandon.Enabled = IIf(Me.toolAbandon.Tag.ToString <> "Yes", False, True)
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'GroupBox
                Me.txtAddress.Enabled = False
                Me.txtTel.Enabled = False
                Me.txtCustomerID.Enabled = True
                Me.txtCustomerName.Enabled = True
                TxtFAX.Enabled = False
                TxtLinkman.Enabled = False
                Me.dgvCustomer.Enabled = False
                Me.dgvCustomer.Enabled = True
                Me.ActiveControl = Me.txtCustomerID
            Case 1, 2  'New,Edit
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'GroupBox
                Me.txtTel.Enabled = True
                Me.txtCustomerID.Enabled = False
                Me.txtCustomerName.Enabled = True
                TxtFAX.Enabled = True
                TxtLinkman.Enabled = True
                Me.txtAddress.Enabled = True  'IIf(opflag = 1, True, False)
                Me.dgvCustomer.Enabled = False
                Me.ActiveControl = IIf(opflag = 1, Me.txtCustomerID, Me.txtCustomerName)
            Case 3 '
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'GroupBox
                Me.txtAddress.Enabled = True
                Me.txtTel.Enabled = False
                Me.txtCustomerName.Enabled = True
                TxtFAX.Enabled = True
                TxtLinkman.Enabled = True
                Me.dgvCustomer.Enabled = True
                Me.ActiveControl = Me.txtCustomerName
        End Select
    End Sub

#End Region

    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Dreader As DataTable
        Dim SqlStr As String = ""

        dgvCustomer.Rows.Clear()
        'pk: CusID
        SqlStr = "SELECT CusID,CusName,Address,Tel,Fax,Linkman,usey,CusCode from m_Customer_t WHERE usey='" & IIf(Me.chkUsey.Checked, "Y", "N") & "'"
        Dreader = DbOperateUtils.GetDataTable(SqlStr & SqlWhere)
        For rowIndex As Integer = 0 To Dreader.Rows.Count - 1
            dgvCustomer.Rows.Add(
                Dreader.Rows(rowIndex).Item(0).ToString, Dreader.Rows(rowIndex).Item(1).ToString, Dreader.Rows(rowIndex).Item(2).ToString, _
                Dreader.Rows(rowIndex).Item(3).ToString, Dreader.Rows(rowIndex).Item(4).ToString, Dreader.Rows(rowIndex).Item(5).ToString, _
                Dreader.Rows(rowIndex).Item(6).ToString, Dreader.Rows(rowIndex).Item(7).ToString
                )
        Next
        lblRecord.Text = Me.dgvCustomer.Rows.Count
    End Sub

#Region "检查"
    '
    Private Function Checkdata() As Boolean
        If Me.txtCustomerID.Text.Trim = "" Then
            LblMsg.Text = "客户编号资料不能为空..."
            Me.ActiveControl = Me.txtCustomerID
            Return False
        End If
        If Me.txtCustomerName.Text.Trim = "" Then
            LblMsg.Text = "客户名称不能为空..."
            Me.ActiveControl = Me.txtCustomerName
            Return False
        End If
        Return True
    End Function

#End Region

#Region "事件"

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click

        txtCustomerID.Text = ""
        txtTel.Text = ""
        txtCustomerName.Text = ""
        'CobShift.SelectedIndex = -1
        opflag = 1
        ToolbtnState(1)
        Me.txtCustomerID.Enabled = True

    End Sub

    Private Sub toolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click
        If Me.dgvCustomer.Rows.Count = 0 OrElse Me.dgvCustomer.CurrentRow Is Nothing Then Exit Sub

        txtCustomerID.Text = dgvCustomer.CurrentRow.Cells(m_enumdgvCustomer.CusID).Value
        txtCustomerName.Text = dgvCustomer.CurrentRow.Cells(m_enumdgvCustomer.CusName).Value
        txtAddress.Text = dgvCustomer.CurrentRow.Cells(m_enumdgvCustomer.Address).Value
        txtTel.Text = dgvCustomer.CurrentRow.Cells(m_enumdgvCustomer.Tel).Value
        TxtFAX.Text = dgvCustomer.CurrentRow.Cells(m_enumdgvCustomer.Fax).Value
        TxtLinkman.Text = dgvCustomer.CurrentRow.Cells(m_enumdgvCustomer.Linkman).Value
        opflag = 2
        ToolbtnState(2)
    End Sub

    '作废模块
    Private Sub toolAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click
        Dim lsSQL As New StringBuilder
        If Me.dgvCustomer.Rows.Count = 0 OrElse Me.dgvCustomer.CurrentRow Is Nothing Then Exit Sub

        Try
            lsSQL.Append(" UPDATE m_Customer_t SET usey='N' " & _
                    " WHERE CusID = '" & dgvCustomer.CurrentRow.Cells(m_enumdgvCustomer.CusID).Value & "'")
            lsSQL.Append(" delete from m_Logtree_t where Ttext=N'" & dgvCustomer.CurrentRow.Cells(m_enumdgvCustomer.CusName).Value & "'")
            DbOperateUtils.ExecSQL(lsSQL.ToString)
            LoadDataToDatagridview(" ")
            Me.LblMsg.Text = "作废成功"
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmCustomer", "toolAbandon_Click", "sys")
        End Try

    End Sub

    Private Sub toolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        Me.LblMsg.Text = ""
        Dim SqlStr As New StringBuilder
        Dim TreeCount As String = "", TreeId As String = "", Tkey As String = "", strCusID As String = "", strTtext As String = ""
        Dim o_strIntime As String = String.Empty
        Dim mCheckCodeRead As DataTable = Nothing, mRead As DataTable = Nothing
        Try
            If Checkdata() = False Then
                Exit Sub
            End If

            If opflag = 1 Then  '新增保存
                mCheckCodeRead = DbOperateUtils.GetDataTable("SELECT CusID FROM m_Customer_t WHERE CusID='" & Me.txtCustomerID.Text.Trim() & "'")
                If mCheckCodeRead.Rows.Count > 0 Then
                    MessageUtils.ShowInformation("客户代码已经存在！")
                    Exit Sub
                End If
                mRead = DbOperateUtils.GetDataTable("SELECT count(Treeid) as countTreeid FROM m_Logtree_t WHERE Tparent='c0_'")

                If mRead.Rows.Count > 0 Then
                    TreeCount = Convert.ToInt16(mRead.Rows(0)(0).ToString) + 1
                Else
                    TreeCount = "1"
                End If

                TreeId = "C01" + TreeCount.PadLeft(2, "0")
                Tkey = "C01" + TreeCount.PadLeft(2, "0") + "_"

                SqlStr.Append(ControlChars.CrLf & "INSERT INTO m_Customer_t(CusID, CusCode, CusName, Address,Tel,Fax,Linkman,usey) " _
                         & " VALUES('" & txtCustomerID.Text.Trim & "','" & txtCustomerID.Text.Trim & "',N'" & txtCustomerName.Text.Trim & "','" & txtAddress.Text.Trim & "'," _
                         & " N'" & txtTel.Text.Trim & "','" & TxtFAX.Text.Trim & "','" & TxtLinkman.Text.Trim & "','Y')")

                '增加客户权限数据, remove 
                SqlStr.Append("INSERT INTO m_Logtree_t(Treeid, Tkey, Tparent, Ttext, Enname, TreeTag, Rightid, Formid, ButtonID, Timage, Tsimage, TADimage, ")
                SqlStr.Append(" TADsimage, TADUsey, TADid, listy)")
                SqlStr.Append("VALUES('" & TreeId & "','" & Tkey & "','c0_',N'" & Me.txtCustomerName.Text.Trim() & "',")
                SqlStr.Append("N'" & Me.txtCustomerID.Text.Trim() & "',null,'mes00','FrmCustomer','" & TreeId & "','3','3','3','3','N',null,'N')")

            ElseIf opflag = 2 Then  '修改保存   'ButtonID = CusID
                strCusID = dgvCustomer.CurrentRow.Cells(m_enumdgvCustomer.CusID).Value.ToString.Trim
                SqlStr.Append(" UPDATE m_Customer_t SET CusID='" & txtCustomerID.Text.Trim & "', CusName =N'" & txtCustomerName.Text.Trim & "',")
                SqlStr.Append(" Address = N'" & txtAddress.Text & "',Tel =N'" & txtTel.Text.Trim & "',Fax='" & TxtFAX.Text & "',Linkman='" & TxtLinkman.Text & "'")
                SqlStr.Append(" WHERE CusID = '" & strCusID & "'")
                '更新客户权限数据
                SqlStr.Append(" UPDATE m_Logtree_t set Ttext=N'" & Me.txtCustomerName.Text.Trim() & "', Enname=N'" & Me.txtCustomerID.Text.Trim() & "'")
                SqlStr.Append(" WHERE Tparent='c0_' and ButtonID=N'" & strCusID & "' ")
            End If
            Try
                DbOperateUtils.ExecSQL(SqlStr.ToString)
                LoadDataToDatagridview(" and CusID='" & txtCustomerID.Text.Trim() & "'")
                txtCustomerName.Text = ""
                txtCustomerName.Text = ""
                txtTel.Text = ""
                TxtFAX.Text = ""
                txtAddress.Text = ""
                TxtLinkman.Text = ""
                opflag = 0
                ToolbtnState(0)
                Me.LblMsg.Text = "保存成功"
            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmCustomer", "toolSave_Click", "BasicM")
                Exit Sub
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub toolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click
        txtCustomerName.Text = ""
        txtCustomerName.Text = ""
        txtTel.Text = ""
        TxtFAX.Text = ""
        txtAddress.Text = ""
        TxtLinkman.Text = ""
        opflag = 0
        ToolbtnState(0)
    End Sub


    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click
        Dim strSQL As New StringBuilder
        If Me.txtCustomerID.Text <> "" Then
            strSQL.AppendLine(" and CusID like N'%" & Me.txtCustomerID.Text.Trim() & "%'")
        End If
        If Me.txtCustomerName.Text <> "" Then
            strSQL.AppendLine(" and CusName like N'%" & Me.txtCustomerName.Text.Trim() & "%'")
        End If
        LoadDataToDatagridview(strSQL.ToString)
        Me.LblMsg.Text = "数据加载成功"
    End Sub


    Private Sub toolCheckItem_Click(sender As Object, e As EventArgs) Handles toolCheckItem.Click
        Dim isAdd As Boolean
        Dim isDelete As Boolean
        Try
            If toolAdd.Tag Is Nothing Then toolAdd.Tag = "NO"
            isAdd = (toolAdd.Tag.ToString.ToUpper() = "YES")
            isDelete = (toolAbandon.Tag.ToString.ToUpper() = "YES")
            'Cusid/
            Using frm As New FrmCusSerMaintaince(Me.dgvCustomer.CurrentRow.Cells(0).Value.ToString(),
                                                           Me.dgvCustomer.CurrentRow.Cells(1).Value.ToString,
                                                           isAdd, isDelete)
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region


#Region "Grid行数"

    Private Sub dgvEquipment_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvCustomer.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub


#End Region

End Class