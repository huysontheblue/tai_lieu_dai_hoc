
#Region "Imports"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports Microsoft.Office.Interop
Imports MainFrame
Imports System.IO
Imports System.Drawing.Imaging

#End Region
Public Class FrmNGRepairQuery
    ''' <summary>
    ''' 工站类别
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <param name="partid"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxStationId(ByVal ColComboBox As ComboBox, ByVal partid As String)
        Dim strSQL As New StringBuilder
        strSQL.Append("  select a.Stationid,a.Stationid+'-'+b.StationName as StationName from m_RPartStationD_t a  ")
        strSQL.Append("  inner join m_Rstation_t b on b.Stationid=a.Stationid ")
        strSQL.Append(" where PPartid='" & partid & "' and State='1' order by StaOrderid ")
        BindCombox(strSQL.ToString, ColComboBox, "StationName", "Stationid")
    End Sub

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



    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        GetData()
    End Sub


    Private Sub GetData()
        Try
            Dim o_strSql As New StringBuilder

            o_strSql.Append("select distinct a.Ppid,a.partid,isnull(a.moid,'') moid, a.Lineid,")
            o_strSql.Append(" a.NGStationid,  a.ReStationId ,b.CsortName,(a.NGStationid + '-'+ isnull(d.Stationname,''))stationname,")
            o_strSql.Append(" (a.Rcodeid + '-'+ isnull(c.rccname,''))rccname,")
            o_strSql.Append(" (a.Solution + '-'+ e.MstyleName) Solution , convert(nvarchar(10),cast(a.NgDate as date),111) NgDate, a.NgQty,a.Suggestion,")
            o_strSql.Append(" case when Stateid='B' then Stateid + N'-驳回'  when Stateid='D' then Stateid + N'-不良品待维修'  when Stateid='G' then Stateid + N'-维修OK待确认' ")
            o_strSql.Append(" when  Stateid='E' then Stateid + N'-产品已报废' when Stateid='P' then Stateid +N'-IPQC已确认' else N'A-在制良品' end Stateid,  ")
            o_strSql.Append("  (select users.UserName  from m_Users_t users where users.UserID = a.Userid) Userid ,a.Remark ")

            o_strSql.Append("  FROM m_AssyTs_t(NOLOCK) a INNER JOIN m_Mainmo_t (NOLOCK) mm ON a.Moid = mm.Moid ")
            o_strSql.Append(" LEFT JOIN m_Code_t b ON a.codeid=b.codeid AND a.Codeitem=b.EsortName  LEFT JOIN m_CodeR_t c ON a.Rcodeid=c.rCodeID")
            o_strSql.Append(" LEFT JOIN m_Rstation_t d ON a.NGStationid = d.Stationid ")
            o_strSql.Append(" LEFT JOIN m_MainTainStyle_t e on a.Solution = e.mstyleid LEFT JOIN deptline_t f on f.lineid = a.Lineid ")
            o_strSql.Append(" WHERE isnew='Y'  and a.NgDate  between '" & DtStar.Text & "' and  '" & DtEnd.Text & "' ")

            If Not String.IsNullOrEmpty(txtMoid.Text) Then
                o_strSql.Append(" and A.moid='" & txtMoid.Text & "' ")
            End If
            If Not String.IsNullOrEmpty(txtPartId.Text) Then
                o_strSql.Append(" AND  A.partid='" & txtPartId.Text & "' ")
            End If
            If Not String.IsNullOrEmpty(cbbStation.Text) Then
                o_strSql.Append(" and A.NGStationid='" & cbbStation.SelectedValue.ToString & "'")
            End If
            If Not String.IsNullOrEmpty(txtLineId.Text) Then
                o_strSql.Append(" and a.Lineid='" & txtLineId.Text & "' ")
            End If
            Dim dt As DataTable = DbOperateUtils.GetDataTable(o_strSql.ToString)
            drvNgRepair.DataSource = dt

            ToolCount.Text = dt.Rows.Count
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmNGRepairQuery", "GetData()", "sys")
        End Try
    End Sub

    Private Sub txtPartId_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtPartId.PreviewKeyDown
        If Not String.IsNullOrEmpty(txtPartId.Text) Then
            BindComboxStationId(cbbStation, txtPartId.Text)
        End If
    End Sub

    Private Sub txtPartId_MouseLeave(sender As Object, e As EventArgs) Handles txtPartId.MouseLeave
        If Not String.IsNullOrEmpty(txtPartId.Text) Then
            BindComboxStationId(cbbStation, txtPartId.Text)
        End If
    End Sub

    Private Sub toolExcel_Click(sender As Object, e As EventArgs) Handles toolExcel.Click
        Dim colName As String = Nothing
        For index = 1 To Me.drvNgRepair.Columns.Count - 1
            colName &= "," & Me.drvNgRepair.Columns(index).HeaderText
        Next
        colName = colName.Substring(1, colName.Length - 1)
        '导出
        LoadDataToExcel(Me.drvNgRepair, "不良维修报表", colName)
    End Sub

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

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
End Class