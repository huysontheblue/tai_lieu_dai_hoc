Imports MainFrame
Imports System.IO

Public Class FrmShipments
    Dim tt As DataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        VbCommClass.VbCommClass.PPartid = ""
        Dim pprtaid As New FrmPpartid()
        pprtaid.ShowDialog()
        If VbCommClass.VbCommClass.PPartid <> "" Then
            TxtPartid.Text = VbCommClass.VbCommClass.PPartid
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextRemarks.Text.Trim = "" Then
            TextRemarks.Text = " "
        End If
        If Not IsNumeric(TextQty.Text) Then
            MessageBox.Show("数量必须为整型数值")
            Return
        End If

        For Each text As Control In GroupBox1.Controls
            If TypeName(text) = "TextBox" Then
                If CType(text, TextBox).Text = "" Then
                    MessageBox.Show(CType(text, TextBox).Tag + "不能为空")
                    Return
                End If
            End If
        Next
        If DbOperateUtils.GetDataTable("SELECT*FROM m_Shipments where Mark='" & TextMark.Text.Trim & "'").Rows.Count <> 0 Then
            MessageBox.Show("唛头号已存在请核实后在录入")
            Return
        End If
        DbOperateUtils.ExecSQL("INSERT INTO m_Shipments(Numbers,Ppartid,PO,BoxName,PackingList,Mark,Qty,Remarks,type,Userid)" & _
                                 "VALUES('" & TextNumbers.Text.Trim & "','" & TxtPartid.Text.Trim & "','" & TextPO.Text.Trim & "','" & TextBoxName.Text.Trim & "','" & TextPacking.Text.Trim & "'" & _
                                 ",'" & TextMark.Text.Trim & "','" & TextQty.Text.Trim & "','" & TextRemarks.Text.Trim & "',N'" & IIf(RadioButton1.Checked = True, "直发直体", "非直发直体") & "','" & VbCommClass.VbCommClass.UseId & "')")
        Exec()
        For Each text As Control In GroupBox1.Controls
            If TypeName(text) = "TextBox" Then
                If CType(text, TextBox).Text <> "" Then
                    CType(text, TextBox).Text = ""
                End If
            End If
        Next
    End Sub

    Private Sub Exec()
        tt = DbOperateUtils.GetDataTable("select Numbers,Ppartid,PO,BoxName,PackingList,Mark,Qty,Remarks,type,Userid,time from m_Shipments WHERE state='N'")
        DataGridViewX1.DataSource = tt
    End Sub

    Private Sub FrmShipments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Exec()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoadDataToExcel(DataGridViewX1, "出货信息")
    End Sub
    Public Shared Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String, Optional ByVal strDirectory As String = "")
        Try

            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim getTable As New DataTable
            getTable.TableName = tbname

            getTable = DgMoData.DataSource

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


    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextQty.Enabled = False
        TextQty.Text = "1"
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextQty.Enabled = True
        TextQty.Text = ""
    End Sub
End Class