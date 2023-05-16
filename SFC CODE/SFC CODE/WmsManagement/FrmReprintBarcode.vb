Imports System.Windows.Forms
Imports System.Text
Imports System.IO

Public Class FrmReprintBarcode

    Dim btFormat As New BarTender.Format
    Dim btApp As BarTender.Application
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try

            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            If checkData() = False Then
                MessageBox.Show("至少输入一个查询条件料", "提示信息")
            End If

            Dim whereSql As String = String.Empty

            If txtReMaterial.Text.Trim() <> "" Then
                whereSql = " where a.ppartid='" + txtReMaterial.Text.Trim() + "'"
            End If

            If txtReMo.Text.Trim() <> "" Then

                If whereSql = String.Empty Then
                    whereSql = " where a.moid='" + txtReMo.Text.Trim() + "'"
                Else
                    whereSql = whereSql + "  and  a.moid='" + txtReMo.Text.Trim() + "'"
                End If
            End If

            Dim tem As String = ""
            If txtReBarCode.Text.Trim() <> "" Then

                Dim bars As String() = txtReBarCode.Lines()
                For i As Integer = 0 To bars.Length - 1
                    tem = tem + "'" + bars(i) + "',"
                Next

                If whereSql = String.Empty Then
                    whereSql = " where b.vppid in(" + tem.Trim(",") + ")"
                Else
                    whereSql = whereSql + "  and  b.vppid in(" + tem.Trim(",") + ")"
                End If
            End If

            Dim sql As String = "select distinct b.vppid,b.lotid,b.userid,b.intime,a.moid ,a.ppartid from m_MaterialLotInOut_t a inner join M_AssemblyLotSnMultip_t  b " & _
                                " on (a.lotid=b.lotid and a.ppartid=b.mark1) " + whereSql

            DataGridViewX1.DataSource = Nothing
            Dim dt As DataTable = Conn.GetDataTable(sql)

            If dt.Rows.Count > 0 Then
                btnRePrint.Enabled = True
            End If

            DataGridViewX1.AutoGenerateColumns = False

            DataGridViewX1.DataSource = dt.DefaultView


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Function checkData() As Boolean

        If txtReBarCode.Text.Trim() = "" And txtReMaterial.Text.Trim() = "" And txtReMo.Text = "" Then
            Return False
        End If

        Return True
    End Function

    Private Sub btnRePrint_Click(sender As Object, e As EventArgs) Handles btnRePrint.Click
        Try

            If DataGridViewX1.RowCount > 0 Then

                Dim dv As DataView = CType(DataGridViewX1.DataSource(), DataView)

                Dim dt As DataTable = dv.ToTable(True, "vppid")

                Dim BarFile As New StringBuilder()

                
                For i As Integer = 0 To dt.Rows.Count - 1
                    If i = dt.Rows.Count - 1 Then
                        BarFile.Append("""" & dt.Rows(i)(0).ToString() & """")
                    Else
                        BarFile.Append("""" & dt.Rows(i)(0).ToString() & """" & vbNewLine)
                    End If
                Next
              
                BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
                File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
                FileToBarCodePrint("")

                btnRePrint.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FileToBarCodePrint(ByVal pFilePath As String)


        btFormat.Print("", False, -1, Nothing)

    End Sub

    Private Sub FrmReprintBarcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            btApp = New BarTender.ApplicationClass
            btFormat = btApp.Formats.Open(Application.StartupPath & "\PrintFile\yanan.btw", False, String.Empty)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmReprintBarcode_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
    End Sub
End Class