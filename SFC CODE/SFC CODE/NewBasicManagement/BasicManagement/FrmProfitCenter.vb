
'工厂利润中心维护
'Create by: 马锋
'Create time: 2015/05/27
'Update by: 
'Update time: 

#Region "Imports引用"

Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle

#End Region

Public Class FrmProfitCenter

#Region "窗體公共變量"

    Public opflag As Int16 = 0  '判斷是新增還是修改

#End Region

#Region "窗體加載"

    'Private Sub FrmRstationSet_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    '    Select Case e.KeyValue
    '        Case 37
    '            '左方向鍵 
    '            SendKeys.Send("{+Tab}")  '按Shift + Tab 組合鍵 
    '        Case 13
    '            SendKeys.Send("{Tab}")
    '        Case 38 '上方向鍵 
    '        Case 39 '右方向鍵 
    '            'SendKeys.Send("{+Tab}")
    '        Case 40  '下方向鍵 
    '            'SendKeys.Send("{+Tab}")
    '        Case 27 'Esc鍵 
    '            Me.Close()
    '    End Select
    'End Sub
    '窗體載入
    Private Sub FrmProfitCenter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Erightbutton() '讀取按鈕權限
        LoadDataToCombox()
        LoadDataToDatagridview(" ")
        ToolbtnState(opflag)
    End Sub
    '控制菜單欄按鈕權限方法
    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm15006' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        Dim Obj As Object
        While Reader.Read
            '通過控件名稱得到控件實例
            Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
            Obj.Tag = "Yes"

        End While
        Reader.Close()
    End Sub
    '設置按鈕按鈕及TextBox狀態
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '初始查詢狀態
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                ''王南刚改新加BU
                Me.ComBU.Enabled = False

                Me.txtProfitCenterCode.Enabled = False
                Me.txtProfitCenterName.Enabled = False
                Me.txtRemark.Enabled = False
                Me.ChkUsey.Enabled = False
                Me.dgvProfitCenter1.Enabled = True
                Me.cbbFactory.SelectedIndex = -1
                Me.ActiveControl = Me.txtProfitCenterCode
            Case 1, 2 '新增,修改
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                ''王南刚改新加BU
                Me.ComBU.Enabled = True

                'GroupBox
                Me.txtProfitCenterCode.Enabled = True
                Me.txtProfitCenterName.Enabled = True
                Me.txtRemark.Enabled = True
                Me.ChkUsey.Enabled = True
                Me.dgvProfitCenter1.Enabled = False
                If (flag = 1) Then
                    Me.cbbFactory.SelectedIndex = -1
                End If
                Me.ActiveControl = Me.txtProfitCenterCode

            Case 3 '從FrmRPartStation窗體中開啟此窗體時的狀態
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True

                'GroupBox
                Me.txtProfitCenterCode.Enabled = True
                Me.txtProfitCenterName.Enabled = True
                Me.txtRemark.Enabled = True
                Me.ChkUsey.Enabled = True
                Me.dgvProfitCenter1.Enabled = True
                Me.ActiveControl = Me.txtProfitCenterCode
        End Select
    End Sub

#End Region

#Region "給數據控件Cbo、Dg加載數據"
    '裝載CboType工站類別
    Private Sub LoadDataToCombox()

        Dim SqlStr As String = "SELECT Factoryid, Shortname FROM m_Dcompany_t WHERE Usey='Y' ORDER BY FACTORYID"
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As SqlDataReader = Conn.GetDataReader(SqlStr)
        'cbbFactory.Items.Clear()
        'cbbFactory.Items.Add("")

        If (Dreader.HasRows) Then
            Do While Dreader.Read()
                cbbFactory.Items.Add(Dreader.Item(0) & "-" & Dreader.Item(1))
            Loop
        Else
            cbbFactory.Items.Clear()
        End If
        Dreader.Close()
        If (Conn.PubConnection.State = ConnectionState.Open) Then
            Conn.PubConnection.Close()
        End If

    End Sub
    '裝載Dg表格
    Private Sub LoadDataToDatagridview(ByVal SqlWhere As String)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim Dreader As DataTable
        Dim SqlStr As String = ""
        SqlStr = "SELECT    a.PROFITCENTER_CODE 利润代码, a.PROFITCENTER_NAME 利润名称, a.FACTORY_ID  工厂,b.Shortname 工厂名称 , a.BU 所属BU,a.REMARK 描述 , a.UPDATEUSERID 用户 , a.UPDATETIME 时间 , a.ACTIVEFLGE 是否有效 FROM m_ProfitCenter_t as a JOIN m_Dcompany_t as b on  b.Factoryid=a.FACTORY_ID "
        dgvProfitCenter1.DataSource = Conn.GetDataTable(SqlStr & SqlWhere & "order by PROFITCENTER_CODE")
        toolStripStatusLabel3.Text = Me.dgvProfitCenter1.Rows.Count
        Conn.PubConnection.Close()
    End Sub

#End Region

#Region "CBO/DG等數據控件相關事件"
    '取消加載datagridview單元格有焦點
    Private Sub dgvRstation_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub
    '雙擊行事件
    'Private Sub dgvRstation_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRstation.CellDoubleClick
    '    'tsbCheck_Click(sender, e)
    'End Sub

    Private Function Checkdata() As Boolean
        If Me.txtProfitCenterCode.Text.Trim = "" Then
            MessageBox.Show("請輸入利润代码！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.txtProfitCenterCode
            Return False
        End If
        If Me.txtProfitCenterName.Text.Trim = "" Then
            MessageBox.Show("請輸入利润名称！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.txtProfitCenterName
            Return False
        End If
        '关晓艳 2017/11/17 新增 工厂名称不能为空
        If cbbFactory.Text.Trim = "" Then
            MessageBox.Show("請選擇工厂名称!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.cbbFactory
            Return False
        End If
        '王南刚 2017/11/17 新增 BU名称不能为空
        If ComBU.Text.Trim = "" Then
            MessageBox.Show("請選擇BU名称!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActiveControl = Me.ComBU
            Return False
        End If

        Return True
    End Function

#End Region

#Region "菜單欄按鈕事件"
    '新增
    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAdd.Click

        Me.txtProfitCenterCode.Text = ""
        Me.txtProfitCenterName.Text = ""
        Me.txtRemark.Text = ""
        Me.ChkUsey.Checked = True
        opflag = 1
        ToolbtnState(1)

    End Sub
    '修改
    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEdit.Click

        '判斷記錄是否可以被修改
        If Me.dgvProfitCenter1.Rows.Count = 0 OrElse Me.dgvProfitCenter1.CurrentRow Is Nothing Then Exit Sub
        '关xy 2017/11/17  作废的允许修改
        'If Me.dgvProfitCenter.Item("Usey", Me.dgvProfitCenter.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "Y" Then
        '    MessageBox.Show("該类别編號已經作廢，不允許進行修改！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If

        '控件賦值
        Me.txtProfitCenterCode.Text = dgvProfitCenter1.Item(0, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim
        Me.txtProfitCenterName.Text = dgvProfitCenter1.Item(1, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim
        ''王南刚增加2018/06/11
        Me.ComBU.Text = dgvProfitCenter1.Item(3, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim
        Me.txtRemark.Text = dgvProfitCenter1.Item(4, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim
        Me.ChkUsey.Checked = IIf(dgvProfitCenter1.Item(6, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim = "Y", True, False)
        Me.cbbFactory.SelectedIndex = Me.cbbFactory.FindString(Me.dgvProfitCenter1.Item(2, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim)


        '改變窗體狀態
        opflag = 2
        ToolbtnState(2)

        Me.txtProfitCenterName.Enabled = False
    End Sub
    '作廢
    Private Sub tsbAbandon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbandon.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        '判斷記錄是否可以被作廢
        If Me.dgvProfitCenter1.Rows.Count = 0 OrElse Me.dgvProfitCenter1.CurrentRow Is Nothing Then Exit Sub
        If Me.dgvProfitCenter1.Item(6, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim.Split("-")(0) <> "Y" Then
            MessageBox.Show("該利润編號已經作廢，不允許再作廢！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim Fullname As String = Me.dgvProfitCenter1.Item(0, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim
        Dim Factoryid As String = Me.dgvProfitCenter1.Item(2, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim
        If MessageBox.Show("確定要利润中心: [" + Me.dgvProfitCenter1.Item(0, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim + "]-[" + Me.dgvProfitCenter1.Item(1, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim + "] 嗎?", "系統提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            'Conn.ExecSql("UPDATE PROFITCENTER_CODE SET usey='N',userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate() where PROFITCENTER_CODE = '" & Me.dgvProfitCenter.Item(0, Me.dgvProfitCenter.CurrentRow.Index).Value.ToString.Trim & "' ")
            Conn.ExecSql("UPDATE m_ProfitCenter_t SET ACTIVEFLGE='N',UPDATEUSERID='" & SysMessageClass.UseId.ToLower.Trim & "',UPDATETIME=getdate() where PROFITCENTER_CODE = '" & Me.dgvProfitCenter1.Item(0, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim & "' ")
            MessageBox.Show("成功作廢利润中心: [" + Me.dgvProfitCenter1.Item(0, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim + "]-[" + Me.dgvProfitCenter1.Item(1, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim + "]", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataToDatagridview(" where PROFITCENTER_CODE='" & Fullname & "'")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmProfitCenter", "tsbAbandon_Click", "sys")
        End Try

    End Sub

    '保存
    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click

        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim SqlStr As New StringBuilder
        Dim ActiveFlag As String
        'gxy add 利润中心权限
        Dim TreeCount As String = ""
        Dim TreeId As String
        Dim Tkey As String
        Dim treeidg As String
        Dim tkeyg As String


        If Checkdata() = False Then Exit Sub

        ActiveFlag = IIf(Me.ChkUsey.Checked, "Y", "N")

        If opflag = 1 Then  '新增后保存執行插入操作

            Dim mCheckCodeRead As SqlDataReader = Conn.GetDataReader("SELECT PROFITCENTER_CODE FROM m_ProfitCenter_t WHERE PROFITCENTER_CODE='" & Me.txtProfitCenterCode.Text.Trim() & "'")
            If mCheckCodeRead.HasRows Then

                mCheckCodeRead.Close()
                MessageBox.Show("利润中心已经存在！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            mCheckCodeRead.Close()

            'gxy add 利润中心权限
            Dim mRead As SqlDataReader = Conn.GetDataReader("SELECT count(Treeid) as countTreeid FROM m_Logtree_t WHERE Tparent=(select　Tkey from m_Logtree_t where Ttext =N'" & Me.cbbFactory.Text.Trim.Split("-")(1) & "')")

            If mRead.HasRows Then
                While mRead.Read
                    TreeCount = Convert.ToInt16(mRead!countTreeid) + 1
                End While
            Else
                TreeCount = "1"
            End If
            mRead.Close()

            Dim Dreader As SqlDataReader
            Dreader = Conn.GetDataReader("select　Treeid,Tkey  from m_Logtree_t  where Ttext =N'" & Me.cbbFactory.Text.Trim.Split("-")(1) & "'")
            Do While Dreader.Read()
                treeidg = Dreader.Item(0).ToString
                tkeyg = Dreader.Item(1).ToString
            Loop
            Dreader.Close()
            TreeId = treeidg + TreeCount.PadLeft(2, "0")
            Tkey = treeidg + TreeCount.PadLeft(2, "0") + "_"



            '增加利润中心
            SqlStr.Append(ControlChars.CrLf & "insert m_ProfitCenter_t(FACTORY_ID, PROFITCENTER_CODE, PROFITCENTER_NAME, REMARK, UPDATEUSERID, UPDATETIME, ACTIVEFLGE,BU) " _
                     & " values(N'" & Me.cbbFactory.Text.Trim.Split("-")(0) & "'," _
                     & "N'" & Me.txtProfitCenterCode.Text.Trim & "',N'" & Me.txtProfitCenterName.Text.Trim & "',N'" & Me.txtRemark.Text.Trim() & "','" & SysMessageClass.UseId.ToLower.Trim & "',getdate(),'" & ActiveFlag & "','" & ComBU.Text & "')")

            'gxy add增加工厂权限数据
            SqlStr.Append(ControlChars.CrLf & "INSERT INTO m_Logtree_t(Treeid, Tkey, Tparent, Ttext, Enname, TreeTag, Rightid, Formid, ButtonID, Timage, Tsimage, TADimage, " _
                & " TADsimage, TADUsey, TADid, listy) VALUES('" & TreeId & "','" & Tkey & "','" & tkeyg & "',N'" & Me.txtProfitCenterName.Text.Trim & "(" & Me.txtProfitCenterCode.Text.Trim & ")" & "',null" & ",null,'mes00', N'" & Me.cbbFactory.Text.Trim.Split("-")(0) & "' ,'" & Me.txtProfitCenterCode.Text.Trim & "','4','4','2','3','Y',null,'N')")


        ElseIf opflag = 2 Then     '修改后保存執行更新操作

            'Dim cheUsy As String = IIf(Me.ChkUsey.Checked, "Y", "N")
            '修改利润中心
            'SqlStr.Append("update m_ProfitCenter_t set  PROFITCENTER_CODE=N'" & Me.txtProfitCenterCode.Text & "', PROFITCENTER_NAME=N'" & Me.txtProfitCenterName.Text.Trim & "', REMARK=N'" & Me.txtRemark.Text.Trim & "',userid='" & SysMessageClass.UseId.ToLower.Trim & "',intime=getdate(), ACTIVEFLGE='" & ActiveFlag & "'  where PROFITCENTER_CODE = '" & txtProfitCenterCode.Text.Trim & "' ")
            '关晓艳 2017/11/17 修改更新sql语句
            SqlStr.Append("update m_ProfitCenter_t set BU='" & ComBU.Text & "',PROFITCENTER_CODE=N'" & Me.txtProfitCenterCode.Text & "', FACTORY_ID=N'" & Me.cbbFactory.Text.Trim.Split("-")(0) & "', PROFITCENTER_NAME=N'" & Me.txtProfitCenterName.Text.Trim & "', REMARK=N'" & Me.txtRemark.Text.Trim & "',UPDATEUSERID='" & SysMessageClass.UseId.ToLower.Trim & "',UPDATETIME=getdate(), ACTIVEFLGE='" & ActiveFlag & "'  where PROFITCENTER_NAME = '" & txtProfitCenterName.Text.Trim & "' ")
            SqlStr.Append(ControlChars.CrLf & " update m_Logtree_t set Ttext=N'" & Me.txtProfitCenterName.Text.Trim & "(" & Me.txtProfitCenterCode.Text.Trim & ")" & "' where  Ttext=N'" & Me.dgvProfitCenter1.Item(1, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim & "(" & Me.dgvProfitCenter1.Item(0, Me.dgvProfitCenter1.CurrentRow.Index).Value.ToString.Trim & ")" & "' ")
        End If

        Try
            Conn.ExecSql(SqlStr.ToString)
            LoadDataToDatagridview(" where PROFITCENTER_CODE='" & Me.txtProfitCenterCode.Text.Trim() & "'")
            MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtProfitCenterCode.Text = ""
            txtProfitCenterName.Text = ""
            txtRemark.Text = ""
            ChkUsey.Checked = False

            opflag = 0
            ToolbtnState(0)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicManagement.FrmProfitCenter", "tsbSave_Click", "sys")
            Exit Sub
        End Try

    End Sub
    '返回
    Private Sub tsbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBack.Click

        txtProfitCenterCode.Text = ""
        txtProfitCenterName.Text = ""
        txtRemark.Text = ""
        ChkUsey.Checked = False
        opflag = 0
        ToolbtnState(0)

    End Sub
    '查詢
    Private Sub tsbQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolQuery.Click

        Dim flag As Boolean = False
        Dim Sql As String = "where 1=1 "

        If Me.txtProfitCenterCode.Text.Trim <> "" Then
            Sql = Sql & " and PROFITCENTER_CODE='" & Me.txtProfitCenterCode.Text.Trim & "' "
        End If
        If Me.txtProfitCenterName.Text.Trim <> "" Then
            Sql = Sql & " and PROFITCENTER_NAME = 'N" & Me.txtProfitCenterName.Text.Trim & "' "
        End If

        '关xy 2017/11/17新增 查询添加条件 工厂名字
        If Me.cbbFactory.Text.Trim <> "" Then
            Sql = Sql & " and FACTORY_ID=N'" & Me.cbbFactory.Text.Trim.Split("-")(0) & "' "
        End If


        LoadDataToDatagridview(Sql)

    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#End Region
    '王南刚 2018-06-19 导出表格
    Public Shared Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String, Optional ByVal strDirectory As String = "", Optional ByVal cbbFactoryt As String = "")
        Try

            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim getTable As New DataTable
            getTable.TableName = tbname
            If cbbFactoryt = "" Then
                getTable = DgMoData.DataSource
                getTable.Rows.Add("", "", "LXFS", "丰顺立讯", "", "", "C060130", "2018/06/19", "Y")
      
            Else
                getTable = DgMoData.DataSource
            End If
            '导出CSV文件格式，以便用户查询，以,号区分

            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If

            Dim Swriter As New IO.StreamWriter("c:\MesExport\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            '写入标题行
            For comIndex As Integer = 0 To DgMoData.ColumnCount - 1
                If bColName = False Then
                    If wColName = "" Then
                        wColName = DgMoData.Columns(comIndex).HeaderText
                    Else
                        wColName = wColName + "," + DgMoData.Columns(comIndex).HeaderText
                    End If
                End If
            Next

            For Each r As DataRow In getTable.Rows

                nColqty = 0

                For Each c As DataColumn In getTable.Columns
                    '写入每行的值
                    If nColqty = 0 Then
                        wValue = r.Item(c.ColumnName).ToString.Replace(",", "，")
                    Else
                        wValue = wValue + "," + r.Item(c.ColumnName).ToString.Replace(",", "，")
                    End If
                    nColqty = nColqty + 1
                Next

                If wColName <> "" And bColName = False Then
                    Swriter.WriteLine(wColName)
                    bColName = True
                End If

                Swriter.WriteLine(wValue)

            Next
            Swriter.Close()

            MessageBox.Show("文件导出成功,导出位置：c:\MesExport\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    'Public Function GetDgvToTable(dgv As DataGridView) As DataTable
    '    Dim dt As New DataTable()

    '    ' 列强制转换
    '    For count As Integer = 0 To dgvProfitCenter1.Columns.Count - 1
    '        Dim dc As New DataColumn(dgvProfitCenter1.Columns(count).Name.ToString())
    '        dt.Columns.Add(dc)
    '    Next

    '    ' 循环行
    '    For count As Integer = 0 To dgvProfitCenter1.Rows.Count - 1
    '        Dim dr As DataRow = dt.NewRow()
    '        For countsub As Integer = 0 To dgvProfitCenter1.Columns.Count - 1
    '            dr(countsub) = Convert.ToString(dgvProfitCenter1.Rows(count).Cells(countsub).Value)
    '        Next
    '        dt.Rows.Add(dr)
    '    Next
    '    Return dt
    'End Function
    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        LoadDataToExcel(dgvProfitCenter1, "利润中心资料.xls", "", cbbFactory.Text)
    End Sub
End Class