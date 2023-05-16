Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Collections.Generic
Imports System.Web
Imports System.Collections
Imports System.Text.RegularExpressions

Public Class EquipmentApply
#Region "检查输入"
    Private Function CheckInput() As Boolean

        Try


            If txtApplyID.Text = "" Then
                MessageBox.Show("借申请人工号不能为空", "提示")
                Return False
            End If

            If txtMOID.Text = "" Then
                MessageBox.Show("产品料号不能为空", "提示")
                Return False
            End If

            If cboDept.Text = "" Then
                MessageBox.Show("课别不能为空", "提示")
                Return False
            End If



        Catch ex As Exception
            Throw ex
        Finally
            DAL = Nothing
        End Try
        Return True

    End Function
#End Region
    Dim DAL As New MainFrame.SysDataHandle.SysDataBaseClass

    Private Sub dgvApply_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvApply.CellClick
        Dim S As Integer = e.ColumnIndex
        Dim ss As Integer = e.RowIndex
        '选中打印的项
        cboSelect_CheckedChanged(sender, e)


    End Sub

    Private Sub cboSelect_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Me.dgvApply.Rows.Count > 0 Then
                For i As Integer = 0 To Me.dgvApply.Rows.Count - 1
                    If CBool(Me.dgvApply.Rows(i).Cells(0).EditedFormattedValue) Then
                        Me.dgvApply.Rows(i).Cells(0).Value = True
                    Else
                        Me.dgvApply.Rows(i).Cells(0).Value = False
                    End If
                Next
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If CheckInput() = False Then
            Exit Sub
        End If
        '开始取值
        Dim sql As String = String.Empty
        Dim qty1 As String = String.Empty
        Dim pn As String = String.Empty
        For index As Integer = 0 To dgvApply.Rows.Count - 1
            Dim s As String = dgvApply.Rows(index).Cells(0).Value.ToString
            Dim ss As String = dgvApply.Rows(index).Cells(1).Value.ToString
            If (Not dgvApply.Rows(index).Cells(0).Value Is Nothing) AndAlso dgvApply.Rows(index).Cells(0).Value.ToString = "True" Then
                qty1 = dgvApply.Rows(index).Cells(1).Value.ToString   '数量
                pn = dgvApply.Rows(index).Cells(3).Value.ToString   '料号

                'qty1 += dgvApply.Rows(index).Cells(1).Value.ToString + "," '数量
                'pn += dgvApply.Rows(index).Cells(3).Value.ToString + "," '料号

                SaveData(qty1, pn)

            Else

            End If
        Next
        ClearControls()
        '  SaveData(qty1, pn)
        txtMOID.Focus()

    End Sub
    Private Sub DgvLoad()
        'Dim DAL1 As New MainFrame.SysDataHandle.SysDataBaseClass
        'Dim sql As String = "select AppUserName 申请人,MOID 工单号,PNumber 产品料号,Dept 部门 ,Line 线别, AStatus 状态, InTime 时间,QTY  数量 from m_Equipment_App_t  where AStatus1 =1 order by InTime desc"
        ''dgvApply.Rows.Clear()
        'Using dt As DataTable = DAL1.GetDataTable(sql)
        '    For Each row As DataRow In dt.Rows
        '        dgvApply.Rows.Add(row("申请人").ToString(), row("工单号").ToString(), row("产品料号").ToString(), row("部门").ToString(), row("线别").ToString(), row("时间").ToString(), row("数量").ToString())
        '    Next
        'End Using

        'Dim sql = txtMOID.Text.Trim

    End Sub


    Private Sub SaveData(ByVal qty1 As String, ByVal pn As String)
        Try

            Dim ApplyID As String = txtApplyID.Text.Trim
            Moid = txtMOID.Text.Trim
            Dim pNumber As String = txtPNumber.Text.Trim
            Dim Factory As String = (cboFactory.SelectedItem.ToString.Trim)
            dept1 = (cboDept.Text.ToString.Trim)
            lineid = (cboLine.Text.ToString.Trim)
            Dim QTY As String = qty1.Trim + " Set"
            Dim StrSql As String = String.Empty
            Dim ApplyUserName As String
            Dim DAL2 As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim sqlu As String = "select UserName  from m_Users_t where UserID ='" + ApplyID + "'"
            Dim du As DataTable = DAL2.GetDataTable(sqlu)
            If du.Rows.Count > 0 Then
                ApplyUserName = du.Rows(0).Item(0).ToString()
            Else
                ApplyUserName = ApplyID
            End If

            'Dim s() As String = qty1.Split(",")

            'For index As Integer = 0 To s.Length - 1
            '    Dim ss As String = s(index).ToString()
            '    StrSql += "insert into m_Equipment_App_t(APPID,MOID,PNumber,Dept,Line ,QTY,AppUserName,AStatus1,EquipmentPNumber) values('" + ApplyID + "','" + Moid + "','" + pNumber + "',N'" + Dept + "','" + Line + "','" + QTY + "',N'" + ApplyUserName + "','1','" + pn + "');"

            'Next



            StrSql += "insert into m_Equipment_App_t(APPID,MOID,PNumber,Dept,Line ,QTY,AppUserName,AStatus1,EquipmentPNumber) values('" + ApplyID + "','" + Moid + "','" + pNumber + "',N'" + dept1 + "','" + lineid + "','" + QTY + "',N'" + ApplyUserName + "','1','" + pn + "')"
            '执行SQL
            '  StrSql = StrSql.Substring(0, StrSql.Length - 1)
            Dim DAL1 As New MainFrame.SysDataHandle.SysDataBaseClass
            Dim res As String = DAL1.ExecuteNonQuery(StrSql)


        Catch ex As Exception
            Throw ex
        Finally
            DAL = Nothing
        End Try
        '清空文本框
        ' ClearControls()


    End Sub

    Private Sub ClearControls()
        ' txtApplyID.Text = ""
        txtMOID.Text = ""
        cboLine.Text = ""

        txtPNumber.Text = ""
        '  cboDept.Text = ""

    End Sub
    Shared lineid As String = String.Empty
    Shared dept1 As String = String.Empty
    Shared Moid As String = String.Empty

    Private Sub txtMOID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOID.Leave
        Dim MoId As String = txtMOID.Text.Trim
        Dim SQL As String = " SELECT PartID,deptid,lineid  FROM m_Mainmo_t where Moid ='" + MoId + "'"
        Dim PartId As String = String.Empty

        Dim dt As DataTable = DAL.GetDataTable(SQL)
        If dt.Rows.Count = 0 Then
            MessageBox.Show("工单号有误，请重新输入", "提示")
            Exit Sub
        End If

        PartId = dt.Rows(0).Item(0).ToString
        txtPNumber.Text = PartId '产品料号

        dept1 = dt.Rows(0).Item(1).ToString '课别
        Dim sqldept As String = " select dqc  from m_Dept_t where deptid ='" + dept1 + "'"
        Dim dept As String = DAL.GetDataTable(sqldept).Rows(0).Item(0).ToString
        lineid = dt.Rows(0).Item(2).ToString '线别

        LoadClass(dept)

        '带到dgvapply当中来
        Dim sqlpart As String = "select ID,PartNumber as 料号, Description 类型 ,Description1 描述   from m_PartNumber_t " & _
"where  ID in(select PartID  from m_RunCardPartDetail_t where RunCardDetailID in" & _
"(select id From m_RunCardDetail_t where RunCardID =(SELECT ID  FROM m_RunCard_t where  PartID =   " & _
"(select ID from m_PartNumber_t where PartNumber  =" & _
"(select PartID  from m_Mainmo_t where Moid ='" + MoId + "'))))) and TYPE ='E' "
        dgvApply.DataSource = DAL.GetDataTable(sqlpart)

        'dgvApply.Rows.Clear()
        'Using dtdetail As DataTable = DAL.GetDataTable(sqlpart)
        '    For Each errow As DataRow In dtdetail.Rows
        '        dgvApply.Rows.Add(errow("ID").ToString(), errow("料号").ToString(), errow("类型").ToString(), errow("描述").ToString())
        '    Next
        'End Using

        For index As Integer = 0 To dgvApply.Rows.Count - 1
            dgvApply.Rows(index).Cells(1).Value = "1"
            dgvApply.Columns(2).Visible = False
        Next

        dgvApply.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub

    Private Sub LoadClass(ByVal dept As System.String)
        Dim sql As String = "SELECT DISTINCT DEPTID,DQC FROM M_DEPT_T WHERE FACTORYID='" & VbCommClass.VbCommClass.Factory & "'"
        Dim dt As DataTable = DAL.GetDataTable(sql)
        dt.Rows.InsertAt(dt.NewRow, 0)

        cboDept.DisplayMember = "DQC"
        cboDept.ValueMember = "DEPTID"
        cboDept.DataSource = dt
        cboDept.Text = dept

    End Sub


    Private Sub InitFactory()
        cboFactory.Items.Add("")
        cboFactory.Items.Add("产品二部")
        cboFactory.Items.Add("立德")
        cboFactory.SelectedIndex = 2
    End Sub

    Private Sub EquipmentApply_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitFactory()
        DgvLoad()
        txtApplyID.Text = VbCommClass.VbCommClass.UseId
    End Sub

    Private Sub cboDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDept.SelectedIndexChanged
        Dim dept As String = cboDept.Text.ToString
        Dim sql As String = "select t.lineid as text ,t.deptid   as value from deptline_t  t inner join m_Dept_t d on d.deptid = t.deptid  and dqc =N'" + dept + "'"
        Dim dt As DataTable = DAL.GetDataTable(sql)

        cboLine.DataSource = dt
        cboLine.DisplayMember = "TEXT"
        cboLine.ValueMember = "VALUE"

        'Dim sqlline As String = " select lineid  from  deptline_t where deptid ='" + dept1 + "'"
        'Dim line As String = DAL.GetDataTable(sqlline).Rows(0).Item(0).ToString()
        cboLine.Text = lineid

    End Sub



    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim line As String = txtLine.Text.ToString().ToUpper.Trim
        Dim sql As String = "select et.EquipmentNo 工治具编号,mt.PartNumber 工治具料号 ,mt.Description 类型,mt.Description1 规格 from m_Equipment_t et inner join m_PartNumber_t mt  " & _
 "  on et.PartID = mt.ID and et.Lineid  ='" + line + "'"
        dgvEquipment.DataSource = (DAL.GetDataTable(sql))
        dgvEquipment.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

    End Sub

 

End Class