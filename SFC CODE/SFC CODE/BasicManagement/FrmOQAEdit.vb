Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports Microsoft.Office.Interop
Imports MainFrame
Imports System.IO

Public Class FrmOQAEdit

#Region "事件"

#Region "字段,属性"
    Private actionType As String
    Private Enum FormBtnonType
        Normal
        Edit
    End Enum
    Private Enum OQAGridView
        Ppid
        Stationid
        Moid
        Partid
        Lineid
        Result
        Intime
    End Enum
#End Region
    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        GetData()
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click

        If Me.dgvOQA.RowCount < 1 OrElse Me.dgvOQA.CurrentCell Is Nothing Then
            Exit Sub
        End If
        txtPpid.Text = Me.dgvOQA.CurrentRow.Cells(OQAGridView.Ppid).Value.ToString
        cbResult.Text = Me.dgvOQA.CurrentRow.Cells(OQAGridView.Result).Value.ToString

        Me.actionType = FormBtnonType.Edit.ToString
        SetControl()
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        If Me.dgvOQA.RowCount < 1 OrElse Me.dgvOQA.CurrentCell Is Nothing Then
            Exit Sub
        End If
        SaveData()

        Me.actionType = FormBtnonType.Normal.ToString
        SetControl()
        GetData()
    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        Me.actionType = FormBtnonType.Normal.ToString
        SetControl()
    End Sub

    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        Dim colName As String = Nothing
        Dim index As Integer
        For index = 0 To Me.dgvOQA.Columns.Count - 1
            colName &= "," & Me.dgvOQA.Columns(index).HeaderText
        Next

        colName = colName.Substring(1, colName.Length - 1)
        '导出
        LoadDataToExcel(Me.dgvOQA, "OQA测试检验", colName)
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
#End Region

#Region "函数"

    Private Sub SaveData()
        Try
            Dim o_strSql As New StringBuilder
            Dim stationId As String
            stationId = Me.dgvOQA.CurrentRow.Cells(OQAGridView.Stationid).Value.ToString
            o_strSql.Append("update m_QualitySamplingOBA_t set result='" & Me.cbResult.Text & "' where ppid='" & txtPpid.Text & "' and stationid='" & stationId & "'; ")
            o_strSql.Append(" update MESDataCenter.dbo.m_TestResult_t set result='" & Me.cbResult.Text & "'  where ppid='" & txtPpid.Text & "' and stationid='" & stationId & "' ")

            DbOperateUtils.ExecSQL(o_strSql.ToString)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOQAEdit", "SaveData()", "sys")
        End Try
    End Sub

    Private Sub GetData()
        Try
            Dim o_strSql As New StringBuilder
            o_strSql.Append("select ppid,stationid,moid,partid,lineid,result,intime from m_QualitySamplingOBA_t where 1=1 ")

            If Not String.IsNullOrEmpty(DtStar.Text) And Not String.IsNullOrEmpty(DtEnd.Text) Then
                o_strSql.Append("  and  intime between '" & DtStar.Text & "' and '" & DtEnd.Text & "' ")
            End If

            If Not String.IsNullOrEmpty(txtPpid.Text) Then
                o_strSql.Append(" and ppid='" & txtPpid.Text & "'")
            End If
            If Not String.IsNullOrEmpty(cbResult.Text) Then
                o_strSql.Append(" and result='" & cbResult.Text & "'")
            End If
            Dim dt As DataTable = DbOperateUtils.GetDataTable(o_strSql.ToString)
            Me.dgvOQA.DataSource = dt
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmOQAEdit", "GetData()", "sys")
        End Try
    End Sub


    '设置控件权限
    Private Sub SetControl()
        If actionType = FormBtnonType.Edit.ToString Then
            DtStar.Enabled = False
            DtEnd.Enabled = False
            txtPpid.ReadOnly = True
            toolEdit.Enabled = False
            toolBack.Enabled = True
            toolSave.Enabled = True
        Else
            DtStar.Enabled = True
            DtEnd.Enabled = True
            txtPpid.ReadOnly = False
            toolEdit.Enabled = True
            toolBack.Enabled = False
            toolSave.Enabled = False
            clearText()
        End If
    End Sub


    Private Sub clearText()
        txtPpid.Text = ""
        cbResult.Text = ""
    End Sub

    ''' <summary>
    ''' DataGridView数据导出excel 公共方法
    ''' </summary>
    ''' <param name="DgMoData">DataGridView控件ID</param>
    ''' <param name="tbname">导出文件名称</param>
    ''' <remarks></remarks>
    Private Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String, Optional ByVal tbColName As String = "")
        Try


            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim getTable As New DataTable
            getTable.TableName = tbname

            getTable = CType(DgMoData.DataSource, DataTable)

            '导出CSV文件格式，以便用户查询，以,号区分

            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If

            Dim Swriter As New IO.StreamWriter("c:\MesExport\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            For Each r As DataRow In getTable.Rows

                nColqty = 0

                For Each c As DataColumn In getTable.Columns
                    '写入标题行
                    If bColName = False Then
                        If wColName = "" Then
                            wColName = c.ColumnName.Replace(",", "，")
                        Else
                            wColName = wColName + "," + c.ColumnName.Replace(",", "，")
                        End If
                    End If

                    '写入每行的值
                    If nColqty = 0 Then
                        wValue = r.Item(c.ColumnName).ToString.Replace(",", "，")
                    Else
                        wValue = wValue + "," + r.Item(c.ColumnName).ToString.Replace(",", "，")
                    End If
                    nColqty = nColqty + 1

                Next
                If Not String.IsNullOrEmpty(tbColName) AndAlso bColName = False Then
                    Swriter.WriteLine(tbColName)
                    bColName = True
                Else
                    If wColName <> "" And bColName = False Then
                        Swriter.WriteLine(wColName)
                        bColName = True

                    End If
                End If


                Swriter.WriteLine(wValue)

            Next
            Swriter.Close()

            MessageBox.Show("文件导出成功,导出位置：c:\MesExport\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region
    
End Class