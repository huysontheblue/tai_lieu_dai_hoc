Imports System.Text

Public Class FrmBZAutoSchedule
    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
    Dim DReader As SqlClient.SqlDataReader
    Dim sql As String
    Private Sub Query_Click(sender As Object, e As EventArgs) Handles Query.Click

        Select Case Me.TabControl1.SelectedIndex
            Case 0
                '查询前5个最优机台
                QueryMachine()
            Case 1
                QueryPartInfo()
            Case 2
                QueryMachineInfo()
            Case 3
                QueryParamsInfo()
            Case 4
                QueryFFC()
            Case 5
                QueryBind()
        End Select

    End Sub
    ''' <summary>
    ''' 查询料号机台绑定信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub QueryBind()

        DataGridView3.Rows.Clear()
        sql = "SELECT * FROM m_BZ_AutoSchedule WHERE Visible=1 "
        If ComboBox1.Text.Trim = "" And ComboBox2.Text.Trim = "" Then
            sql += " AND bind 	IS NOT NULL"
        ElseIf ComboBox1.Text.Trim = "" Then
            sql += " AND bind =N'" + ComboBox2.Text.Trim + "' "
        Else
            sql += " AND CODING =N'" + ComboBox1.Text.Trim + "' "
        End If

        sql += " ORDER BY ModifyTime desc"

        DReader = Conn.GetDataReader(sql)

        If DReader.HasRows Then
            While DReader.Read()
                DataGridView3.Rows.Add(DReader.Item("CODING").ToString, DReader.Item("Conductor").ToString, DReader.Item("Attribute").ToString, DReader.Item("PinNum").ToString, DReader.Item("Punching").ToString, DReader.Item("bind").ToString, DReader.Item("ModifyTime").ToString)
            End While
        End If
        DReader.Close()
        Conn.PubConnection.Close()
        Conn.PubConnection.Dispose()
    End Sub

    ''' <summary>
    ''' FFC产能查询
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub QueryFFC()
        DataGridView2.Rows.Clear()
        DataGridView2.Columns.Clear()
        Dim sqlwhere As String
        Dim sql As String
        '日期
        Dim day As DateTime = DateTimePicker1.Value
        day = day.ToString("yyyy-MM-dd")

        '类型  FFC  贴合
        If TypeBox.Text = "FFC" Then

            DataGridView2.Columns.Add("1", "类型")
            DataGridView2.Columns.Add("1", "总产量")
            DataGridView2.Columns.Add("1", "总不良数")
            DataGridView2.Columns.Add("1", "日期")
            DataGridView2.Columns.Add("1", "不良率")
            'DataGridView2.Columns.Add("1", "裁切")
            'DataGridView2.Columns.Add("1", "CCD")
            'DataGridView2.Columns.Add("1", "冲型")
            'DataGridView2.Columns.Add("1", "伸线")
            'DataGridView2.Columns.Add("1", "贴合")
            'DataGridView2.Columns.Add("1", "全检一")
            'DataGridView2.Columns.Add("1", "全检二")

            DataGridView2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView2.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView2.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView2.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'DataGridView2.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'DataGridView2.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'DataGridView2.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'DataGridView2.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'DataGridView2.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'DataGridView2.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            '查询方式  日 月 年
            If TimeBox.Text = "日" Then
                '查询一整天 白班+ 夜班
                sqlwhere = " Intime BETWEEN  '" + day + " 8:30:00'  AND  CONVERT (VARCHAR (100),dateadd(dd,1, '" + day + " 8:30:00'),20) "
                'If ClassBox.Text = "夜班" Then
                '    sqlwhere = "Intime BETWEEN '" + day + " 20:30:00' AND  CONVERT (VARCHAR (100),dateadd(dd,1, '" + day + " 8:30:00'),20)  "
                'End If
            ElseIf TimeBox.Text = "月" Then
                sqlwhere = " DateDiff(mm,Intime,'" + day + "')=0 "
            Else
                sqlwhere = " DateDiff(yy,Intime,'" + day + "')=0 "
            End If

            sql = "SELECT * FROM ( SELECT 'All' station,GETDATE() Intime,isnull(SUM(IncloudNum), 0) nums,'All' ttypes FROM m_FFCProdCount_t  WHERE " + sqlwhere + " 	AND ErrorCode = 'All'	UNION SELECT 'All' station,	GETDATE() Intime,isnull(SUM(IncloudNum), 0) nums,'Error' ttypes	FROM	m_FFCProdCount_t	WHERE " + sqlwhere + " 	AND ErrorCode != 'All' 	UNION SELECT station,CONVERT (nvarchar(10), Intime, 120) 'Intime',isnull(SUM(IncloudNum), 0) nums,'All' ttypes FROM	m_FFCProdCount_t	WHERE " + sqlwhere + " 	AND ErrorCode = 'All'	GROUP BY Station,	CONVERT (nvarchar(10), Intime, 120)	UNION	SELECT station,	CONVERT (nvarchar(10), Intime, 120) 'Intime',	isnull(SUM(IncloudNum), 0) nums,'Error' ttypes	FROM	m_FFCProdCount_t	WHERE " + sqlwhere + " 	AND ErrorCode != 'All'	GROUP BY Station,CONVERT (nvarchar(10), Intime, 120)) a ORDER BY	Intime,	station,nums DESC"
            Try
                '查询总量
                Dim dt As DataTable = Conn.GetDataTable(sql)
                '遍历 编辑数据
                If dt.Rows.Count > 0 Then
                    For index = 0 To dt.Rows.Count - 1
                        DataGridView2.Rows().Add(dt.Rows(index)("station"), dt.Rows(index)("nums"), dt.Rows(index)("ttypes"), dt.Rows(index)("Intime"))
                        If dt.Rows(index)("station") = "All" And dt.Rows(index)("ttypes") = "All" Then
                            'DataGridView2.Rows(0).Cells(0).Value = "全部"
                            'DataGridView2.Rows(0).Cells(1).Value = dt.Rows(index)("nums")
                            'DataGridView2.Rows(0).Cells(2).Value = dt.Rows(index + 1)("nums")
                            DataGridView2.Rows(index).Cells(4).Value = (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                        End If
                        If dt.Rows(index)("station") = "CaiQie" And dt.Rows(index)("ttypes") = "All" Then
                            DataGridView2.Rows(index).Cells(4).Value = (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                            'DataGridView2.Rows(index).Cells(4).Value = dt.Rows(index)("nums").ToString + "|" + dt.Rows(index + 1)("nums").ToString + "|" + (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                        End If
                        If dt.Rows(index)("station") = "CCD" And dt.Rows(index)("ttypes") = "All" Then
                            DataGridView2.Rows(index).Cells(4).Value = (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                            'DataGridView2.Rows(index).Cells(4).Value = dt.Rows(index)("nums").ToString + "|" + dt.Rows(index + 1)("nums").ToString + "|" + (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                        End If
                        If dt.Rows(index)("station") = "ChongXing" And dt.Rows(index)("ttypes") = "All" Then
                            DataGridView2.Rows(index).Cells(4).Value = (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                            'DataGridView2.Rows(index).Cells(4).Value = dt.Rows(index)("nums").ToString + "|" + dt.Rows(index + 1)("nums").ToString + "|" + (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                        End If
                        If dt.Rows(index)("station") = "ShenXian" And dt.Rows(index)("ttypes") = "All" Then
                            DataGridView2.Rows(index).Cells(4).Value = (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                            'DataGridView2.Rows(index).Cells(4).Value = dt.Rows(index)("nums").ToString + "|" + dt.Rows(index + 1)("nums").ToString + "|" + (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                        End If
                        If dt.Rows(index)("station") = "TieHe" And dt.Rows(index)("ttypes") = "All" Then
                            DataGridView2.Rows(index).Cells(4).Value = (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                            'DataGridView2.Rows(index).Cells(4).Value = dt.Rows(index)("nums").ToString + "|" + dt.Rows(index + 1)("nums").ToString + "|" + (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                        End If
                        If dt.Rows(index)("station") = "QuanJianOne" And dt.Rows(index)("ttypes") = "All" Then
                            DataGridView2.Rows(index).Cells(4).Value = (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                            'DataGridView2.Rows(index).Cells(4).Value = dt.Rows(index)("nums").ToString + "|" + dt.Rows(index + 1)("nums").ToString + "|" + (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                        End If
                        If dt.Rows(index)("station") = "QuanJianTwo" And dt.Rows(index)("ttypes") = "All" Then
                            DataGridView2.Rows(index).Cells(4).Value = (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                            'DataGridView2.Rows(index).Cells(4).Value = dt.Rows(index)("nums").ToString + "|" + dt.Rows(index + 1)("nums").ToString + "|" + (Math.Round(Convert.ToDecimal(dt.Rows(index + 1)("nums")) / Convert.ToDecimal(dt.Rows(index)("nums")), 4) * 100).ToString + "%"
                        End If

                    Next
                End If
            Catch ex As Exception
                MessageBox.Show("系统异常,请联系管理员!" + ex.Message)
            End Try
        Else
            '贴合
            DataGridView2.Columns.Add("1", "机台")
            DataGridView2.Columns.Add("1", "操作员")
            DataGridView2.Columns.Add("1", "料号")
            DataGridView2.Columns.Add("1", "产能pcs")
            DataGridView2.Columns.Add("1", "不良数pcs")
            DataGridView2.Columns.Add("1", "不良率%")
            DataGridView2.Columns.Add("1", "计划产能")
            DataGridView2.Columns.Add("1", "达成率%")
            DataGridView2.Columns.Add("1", "日期")
            DataGridView2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView2.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView2.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView2.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView2.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView2.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView2.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView2.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            If TimeBox.Text = "日" Then
                '查询1整天  白班 + 夜班
                sqlwhere = " Intime BETWEEN  '" + day + " 7:30:00'  AND  CONVERT (VARCHAR (100),dateadd(dd,1, '" + day + " 7:30:00'),20) "
                'If ClassBox.Text = "夜班" Then
                '    sqlwhere = " Intime BETWEEN '" + day + " 19:30:00' AND  CONVERT (VARCHAR (100),dateadd(dd,1, '" + day + " 7:30:00'),20)  "
                'End If
            ElseIf TimeBox.Text = "月" Then
                sqlwhere = " DateDiff(mm,Intime,'" + day + "')=0 "
            Else
                sqlwhere = " DateDiff(yy,Intime,'" + day + "')=0 "
            End If
            Dim sqlsb As New StringBuilder
            sqlsb.Append("select a.Extend1,a.Opra,a.PartID,a.Intime,isnull(SUM(a.IncloudNum),0) 'All',isnull(SUM(b.IncloudNum),0) 'Errcode',")
            sqlsb.Append("(ROUND((cast(isnull(SUM(b.IncloudNum),0) as float)/cast(isnull(SUM(a.IncloudNum),1) as float)),4)*100) 'pec',")
            sqlsb.Append("isnull(sum(cast(a.Extend2 as int)),0) 'PlanProd',(ROUND((cast(isnull(SUM(a.IncloudNum),0) as float)/cast(")
            sqlsb.Append("(case when isnull(SUM(cast(a.Extend2 as int)),1)=0 then 1 else isnull(SUM(cast(a.Extend2 as int)),1) end) as float)),4)*100)")
            sqlsb.Append(" 'PlanProdPec' from (select * from m_FFCProdCount_t where Station='TieHe'  and ErrorCode='All' AND " + sqlwhere + ") a left join (")
            sqlsb.Append("select Extend1,Opra,PartID,isnull(SUM(IncloudNum),0) IncloudNum from m_FFCProdCount_t where Station='TieHe'  and ErrorCode!='All'  ")
            sqlsb.Append("and " + sqlwhere + " group by Extend1,Opra,PartID) b  on a.Extend1=b.Extend1 and a.Opra=b.Opra and a.PartID=b.PartID ")
            sqlsb.Append(" group by a.Extend1,a.Opra,a.PartID,a.Intime order by a.Extend1")
            Try
                '查询贴合信息
                Dim thData As DataTable = Conn.GetDataTable(sqlsb.ToString)
                If thData.Rows.Count > 0 Then
                    For index = 1 To thData.Rows.Count - 1
                        DataGridView2.Rows.Add(thData.Rows(index)("Extend1"), thData.Rows(index)("Opra"), thData.Rows(index)("PartID"), thData.Rows(index)("All"), thData.Rows(index)("Errcode"), thData.Rows(index)("pec"), thData.Rows(index)("PlanProd"), thData.Rows(index)("PlanProdPec"), thData.Rows(index)("Intime"))
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show("系统异常,请联系管理员!" + ex.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' 导出到Excle
    ''' </summary>
    ''' <param name="dataGridViewOne">DataGridView</param>
    ''' <remarks></remarks>
    Private Sub Excle(dataGridViewOne As DataGridView)
        Dim MyExcel As New Microsoft.Office.Interop.Excel.Application()
        MyExcel.Application.Workbooks.Add()
        MyExcel.Visible = True

        '获取标题  
        Dim Cols As Integer
        For Cols = 1 To dataGridViewOne.Columns.Count
            MyExcel.Cells(1, Cols) = dataGridViewOne.Columns(Cols - 1).HeaderText
        Next

        '往excel表里添加数据()  
        Dim i As Integer
        For i = 0 To dataGridViewOne.RowCount - 1
            Dim j As Integer
            For j = 0 To dataGridViewOne.ColumnCount - 1
                If dataGridViewOne(j, i).Value Is System.DBNull.Value Then
                    MyExcel.Cells(i + 2, j + 1) = ""
                Else
                    If dataGridViewOne(j, i).Value = Nothing Then
                        MyExcel.Cells(i + 2, j + 1) = "-"
                    Else
                        MyExcel.Cells(i + 2, j + 1) = dataGridViewOne(j, i).Value.ToString
                    End If

                End If
            Next j
        Next i
    End Sub

    ''' <summary>
    ''' 查询料号详情
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub QueryPartInfo()
        If ParTestBox.Text.Trim = "" Then
            MessageBox.Show("请输入料号")
            Return
        End If
        sql = "SELECT DESCRI,Attribute,Visible,Conductor,PinNum,Punching FROM m_BZ_AutoSchedule where CODING='" + ParTestBox.Text.Trim + "' AND IDENTIFIER = '1'"
        Dim parTables As DataTable = Conn.GetDataTable(sql)
        Dim sb As String = parTables.Rows(0)("Attribute").ToString()

        If parTables.Rows.Count = 0 Then
            MessageBox.Show("没有此料号相关信息")
            Return
        End If

        TextBox2.Text = parTables.Rows(0)("DESCRI").ToString()
        TextBox9.Text = parTables.Rows(0)("PinNum").ToString()
        TextBox10.Text = parTables.Rows(0)("Conductor").ToString()
        TextBox11.Text = parTables.Rows(0)("Punching").ToString()
        For index = 0 To CheckedListBoxPar.Items.Count - 1
            If sb.Contains(CheckedListBoxPar.Items(index)) Then
                CheckedListBoxPar.SetItemChecked(index, True)
            Else
                CheckedListBoxPar.SetItemChecked(index, False)
            End If
        Next

        If parTables.Rows(0)("Visible").ToString() = "1" Then
            TextBox1.Text = "使用中"
        Else
            TextBox1.Text = "已停用"
        End If
        Conn.PubConnection.Close()
        Conn.PubConnection.Dispose()

    End Sub

    ''' <summary>
    ''' 查询机台详情
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub QueryMachineInfo()
        If TextBox4.Text.Trim = "" Then
            MessageBox.Show("请输入生产设备编号")
            Return
        End If
        sql = "SELECT DESCRI,Attribute,Visible,Conductor,Punching,PinNum FROM m_BZ_AutoSchedule where CODING='" + TextBox4.Text.Trim + "' AND IDENTIFIER = '2'"
        Dim parTables As DataTable = Conn.GetDataTable(sql)
        If parTables.Rows.Count = 0 Then
            MessageBox.Show("没有此生产设备相关信息")
            Return
        End If

        TextBox3.Text = parTables.Rows(0)("DESCRI").ToString()
        Dim sb As String = parTables.Rows(0)("Attribute").ToString()

        For index = 0 To CheckedListBoxMach.Items.Count - 1
            If sb.Contains(CheckedListBoxMach.Items(index)) Then
                CheckedListBoxMach.SetItemChecked(index, True)
            Else
                CheckedListBoxPar.SetItemChecked(index, False)
            End If
        Next

        If parTables.Rows(0)("Visible").ToString() = "1" Then
            TextBox6.Text = "使用中"
        Else
            TextBox6.Text = "已停用"
        End If
        Conn.PubConnection.Close()
        Conn.PubConnection.Dispose()
    End Sub

    ''' <summary>
    ''' 查询产品形态码详情
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub QueryParamsInfo()
        If ShapeTextBox.Text.Trim = "" Then
            MessageBox.Show("请输入产品形态编码")
            Return
        End If
        sql = "SELECT DESCRI,Attribute,Visible FROM m_BZ_AutoSchedule where CODING='" + ShapeTextBox.Text.Trim + "' AND IDENTIFIER = '3'"
        Dim parTables As DataTable = Conn.GetDataTable(sql)
        If parTables.Rows.Count = 0 Then
            MessageBox.Show("没有此产品形态相关信息")
            Return
        End If
        TextBox5.Text = parTables.Rows(0)("DESCRI").ToString()

        If parTables.Rows(0)("Visible").ToString() = "1" Then
            TextBox7.Text = "使用中"
        Else
            TextBox7.Text = "已停用"
        End If
        Conn.PubConnection.Close()
        Conn.PubConnection.Dispose()
    End Sub

    ''' <summary>
    ''' 匹配适合生产当前料号的5个机台
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub QueryMachine()
        Dim attributes As String
        If PartNo.Text.Trim = "" Then
            MessageBox.Show("请输入料号")
            Return
        Else

            DataGridView1.Rows.Clear()
            '查询条码对应的产品形态
            sql = "SELECT DESCRI, Attribute,Conductor,PinNum,Punching FROM m_BZ_AutoSchedule WHERE  CODING ='" + PartNo.Text.Trim() + "'"
            Dim partTable As DataTable
            partTable = Conn.GetDataTable(sql)

            If partTable.Rows.Count = 0 Then
                MessageBox.Show("此料号没有维护相关信息")
                Return
            Else
                attributes = partTable.Rows(0)("Attribute").ToString.Trim()
                TextBox8.Text = partTable.Rows(0)("DESCRI").ToString.Trim()
                Dim conducts As String = partTable.Rows(0)("Conductor").ToString.Trim()
                condu.Text = conducts
                punch.Text = partTable.Rows(0)("Punching").ToString.Trim()
                pinN.Text = partTable.Rows(0)("PinNum").ToString.Trim()
                TextBox15.Text = partTable.Rows(0)("Attribute").ToString.Trim()

                sql = "SELECT bind,b.attribute ,a.CODING Column1 ,Conductor,PinNum,Punching,DESCRI FROM m_BZ_AutoSchedule a,(SELECT attribute,CODING from m_BZ_AutoSchedule WHERE IDENTIFIER = 2) b WHERE Visible =1 AND a.bind = b.CODING AND bind is not null ORDER BY ModifyTime desc "
                Dim dt As DataTable = Conn.GetDataTable(sql)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("请先进行机台与料号绑定!")
                    Return
                End If

                Dim bindList As New ArrayList
                Dim conList As New ArrayList
                Dim numList As New ArrayList
                For index = 0 To dt.Rows.Count - 1
                    If bindList.Contains(dt.Rows(index)("bind")) Then
                        numList.Add(index.ToString)
                    Else
                        bindList.Add(dt.Rows(index)("bind"))
                        conList.Add(dt.Rows(index)("Conductor"))
                    End If
                Next
                numList.Reverse()
                If numList.Count > 0 Then
                    For index = 0 To numList.Count - 1
                        dt.Rows.RemoveAt(Convert.ToInt32(numList(index)))
                    Next
                End If

                If conList.Contains(conducts) Then
                    For index = 0 To dt.Rows.Count - 1
                        If conducts.Equals(dt.Rows(index)("Conductor")) Then
                            DataGridView1.Rows.Add(dt.Rows(index)("bind").ToString, dt.Rows(index)("Conductor").ToString, dt.Rows(index)("Attribute").ToString, dt.Rows(index)("PinNum").ToString, dt.Rows(index)("Punching").ToString, dt.Rows(index)("DESCRI").ToString, dt.Rows(index)("Column1").ToString)
                        End If
                    Next
                Else
                    For index = 0 To dt.Rows.Count - 1
                        DataGridView1.Rows.Add(dt.Rows(index)("bind").ToString, dt.Rows(index)("Conductor").ToString, dt.Rows(index)("Attribute").ToString, dt.Rows(index)("PinNum").ToString, dt.Rows(index)("Punching").ToString, dt.Rows(index)("DESCRI").ToString, dt.Rows(index)("Column1").ToString)
                    Next
                End If



                '旧方法
                '查询 前5个匹配的机台
                'sql = "SELECT CODING,Conductor,Attribute,PinNum,Punching,DESCRI,bind FROM m_BZ_AutoSchedule WHERE CODING in( (SELECT CODING FROM m_BZ_AutoSchedule WHERE bind is not null)) AND Visible ='1' AND Attribute = '" + attributes + "' ORDER BY CASE  WHEN Conductor ='" + conducts + "'  THEN 0 ELSE 1 END , Attribute"
                'DReader = Conn.GetDataReader(sql)

                'If DReader.HasRows Then
                '    While DReader.Read()
                '        DataGridView1.Rows.Add(DReader.Item("bind").ToString, DReader.Item("Conductor").ToString, DReader.Item("Attribute").ToString, DReader.Item("PinNum").ToString, DReader.Item("Punching").ToString, DReader.Item("DESCRI").ToString)
                '    End While
                'Else
                '    DReader.Close()
                '    sql = "SELECT CODING,Conductor,Attribute,PinNum,Punching,DESCRI,bind FROM m_BZ_AutoSchedule WHERE CODING in( (SELECT CODING FROM m_BZ_AutoSchedule WHERE bind is not null)) AND Visible ='1'  ORDER BY CASE  WHEN Conductor ='" + conducts + "'  THEN 0 ELSE 1 END , Attribute"
                '    DReader = Conn.GetDataReader(sql)

                '    If DReader.HasRows Then
                '        While DReader.Read()
                '            DataGridView1.Rows.Add(DReader.Item("bind").ToString, DReader.Item("Conductor").ToString, DReader.Item("Attribute").ToString, DReader.Item("PinNum").ToString, DReader.Item("Punching").ToString, DReader.Item("DESCRI").ToString)
                '        End While
                '    Else
                '        DReader.Close()
                '        sql = "SELECT CODING,Conductor,Attribute,PinNum,Punching,DESCRI,bind FROM m_BZ_AutoSchedule WHERE CODING in( (SELECT CODING FROM m_BZ_AutoSchedule WHERE bind is not null)) AND Visible ='1'  ORDER BY Attribute"
                '        DReader = Conn.GetDataReader(sql)
                '        If DReader.HasRows Then
                '            While DReader.Read()
                '                DataGridView1.Rows.Add(DReader.Item("bind").ToString, DReader.Item("Conductor").ToString, DReader.Item("Attribute").ToString, DReader.Item("PinNum").ToString, DReader.Item("Punching").ToString, DReader.Item("DESCRI").ToString)
                '            End While
                '        Else
                '            DReader.Close()
                '            sql = "SELECT DISTINCT bind,CODING,Conductor,Attribute,PinNum,Punching,DESCRI from m_BZ_AutoSchedule WHERE bind is not NULL ORDER BY bind"
                '            DReader = Conn.GetDataReader(sql)
                '            While DReader.Read()
                '                DataGridView1.Rows.Add(DReader.Item("bind").ToString, DReader.Item("Conductor").ToString, DReader.Item("Attribute").ToString, DReader.Item("PinNum").ToString, DReader.Item("Punching").ToString, DReader.Item("DESCRI").ToString)
                '            End While
                '        End If


                '    End If

                '    'MessageBox.Show("没有相关机台,请确认是否维护机台或产品形态码信息")
                '    'Return
                'End If

            End If

            If DataGridView1.Rows.Count > 0 Then
                DataGridView1.CurrentCell = DataGridView1.Item(0, 0)
            End If
            'DReader.Close()
            'Conn.PubConnection.Close()
            'Conn.PubConnection.Dispose()
        End If

    End Sub

    Private Sub FrmBZAutoSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '按钮初始化
        ToolEdit.Enabled = False
        ToolCancel.Enabled = False
        ToolSave.Enabled = False
        PartNo.Enabled = True
        '查询所有 产品形态编码

        QueryAllProductCode()
    End Sub
    ''' <summary>
    ''' 查询所有 产品形态编码
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub QueryAllProductCode()
        Dim sql As String = "SELECT CODING FROM m_BZ_AutoSchedule WHERE IDENTIFIER = '3' AND Visible ='1' ORDER BY CODING ASC"
        Dim shapeTable As DataTable = Conn.GetDataTable(sql)
        For index = 0 To shapeTable.Rows.Count - 1
            CheckedListBoxPar.Items.Add(shapeTable.Rows(index)("CODING").ToString)
            CheckedListBoxMach.Items.Add(shapeTable.Rows(index)("CODING").ToString)
        Next
    End Sub

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        If e.TabPage Is TabPage1 Or e.TabPage Is TabPage5 Then
            ToolEdit.Enabled = False
            ToolCancel.Enabled = False
            ToolSave.Enabled = False
        Else
            ToolEdit.Enabled = True
            ToolCancel.Enabled = True
            ToolSave.Enabled = True

        End If
        If e.TabPage Is TabPage4 Then
            ToolEdit.Enabled = False
        End If
        If e.TabPage Is TabPage6 Then
            ToolEdit.Enabled = False
            ToolCancel.Enabled = True
            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            Dim sql As String = "SELECT DISTINCT CODING FROM m_BZ_AutoSchedule WHERE IDENTIFIER = 1;SELECT DISTINCT CODING FROM m_BZ_AutoSchedule WHERE IDENTIFIER = 2;"
            Dim ds As DataSet = Conn.GetDataSet(sql)

            For index = 0 To ds.Tables(0).Rows.Count - 1
                ComboBox1.Items.Add(ds.Tables(0).Rows(index).Item("CODING").ToString())
            Next

            For index = 0 To ds.Tables(1).Rows.Count - 1
                ComboBox2.Items.Add(ds.Tables(1).Rows(index).Item("CODING").ToString())
            Next
        End If


    End Sub

    Private Sub ToolSave_Click(sender As Object, e As EventArgs) Handles ToolSave.Click
        Dim num As Integer
        Dim code As String
        Dim descri As String
        Dim checkedList As CheckedListBox
        Select Case Me.TabControl1.SelectedIndex
            Case 1
                num = 1
                code = ParTestBox.Text
                descri = TextBox2.Text
                checkedList = CheckedListBoxPar
            Case 2
                num = 2
                code = TextBox4.Text
                descri = TextBox3.Text
                checkedList = CheckedListBoxMach
            Case 3
                num = 3
                code = ShapeTextBox.Text
                descri = TextBox5.Text
            Case 5
                num = 5
                code = ComboBox1.Text
                descri = ComboBox2.Text
        End Select

        SavePar(num, code, descri, checkedList)

    End Sub
    ''' <summary>
    ''' 保存信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SavePar(num As Integer, code As String, descri As String, checkedList As CheckedListBox)


        If code.Trim = "" Then
            MessageBox.Show("料号不能为空")
            Return
        End If

        '机台生产计划
        If num = 5 Then
            If descri.Trim = "" Then
                MessageBox.Show("料号,机台不能为空")
                Return
            End If
            sql = "UPDATE m_BZ_AutoSchedule SET [bind]='" + descri.Trim + "',ModifyTime = GETDATE() WHERE CODING=N'" + code.Trim + "'"
            Conn.ExecSql(sql)
            MessageBox.Show("保存成功")
            Return
        End If

        If Not num = 3 Then
            If checkedList.CheckedItems.Count = 0 Then
                MessageBox.Show("请勾选产品形态编码,或添加产品形态编码")
                Return
            End If
        End If

        '获取勾选的值
        Dim sb As String = ""
        If Not num = 3 Then
            For index = 0 To checkedList.Items.Count - 1
                If checkedList.GetItemChecked(index) Then
                    If sb = "" Then
                        sb = checkedList.Items(index)
                    Else
                        sb = sb + "," + checkedList.Items(index)
                    End If
                End If
            Next
        End If
        '保存
        Try
            sql = "INSERT INTO [m_BZ_AutoSchedule] ([CODING], [IDENTIFIER], [DESCRI], [Attribute], [CreateTime], [Visible]) VALUES ( N'" + code + "', '" + num.ToString + "', N'" + descri + "', N'" + sb + "', GETDATE(), '1')"

            If num = 1 Then
                If TextBox10.Text.Trim = "" Or TextBox11.Text.Trim = "" Or TextBox9.Text.Trim = "" Then
                    MessageBox.Show("请输入 导体规格,PIN数,冲孔大小")
                    Return
                End If
                sql = "INSERT INTO [m_BZ_AutoSchedule] ([CODING], [IDENTIFIER], [DESCRI], [Attribute], [CreateTime], [Visible],Conductor,PinNum,Punching) VALUES ( N'" + code + "', '" + num.ToString + "', N'" + descri + "', N'" + sb + "', GETDATE(), '1',N'" + TextBox10.Text + "',N'" + TextBox9.Text + "',N'" + TextBox11.Text + "')"
            End If

            Conn.ExecSql(sql)
            MessageBox.Show("保存成功")
            If num = 3 Then
                CheckedListBoxPar.Items.Add(code)
                CheckedListBoxMach.Items.Add(code)
            End If

        Catch ex As Exception
            MessageBox.Show("该料号已存在,或联系资讯维护人员:" + ex.Message)
        Finally
            Conn.PubConnection.Close()
            Conn.PubConnection.Dispose()
        End Try

    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub ToolCancel_Click(sender As Object, e As EventArgs) Handles ToolCancel.Click
        Dim num As Int32 = 0
        Dim code As String = ""
        Select Case Me.TabControl1.SelectedIndex
            Case 1
                num = 1
                code = ParTestBox.Text
            Case 2
                num = 2
                code = TextBox4.Text
            Case 3
                num = 3
                code = ShapeTextBox.Text
            Case 5
                num = 5
                code = ComboBox1.Text.Trim
        End Select
        '停用/启用状态
        UpdateStatusById(num, code)
    End Sub
    ''' <summary>
    ''' 修改状态(作废/使用)
    ''' </summary>
    ''' <param name="num"></param>
    ''' <remarks></remarks>
    Private Sub UpdateStatusById(num As Int32, code As String)

        If code = "" Then
            MessageBox.Show("请输入编码进行修改")
            Return
        End If
        If num = 5 Then
            sql = "UPDATE m_BZ_AutoSchedule SET bind = null WHERE CODING ='" + code + "'"
            Conn.ExecSql(sql)
            MessageBox.Show("状态修改成功")
            Conn.PubConnection.Close()
            Conn.PubConnection.Dispose()
            Return
        End If

        sql = "SELECT Visible FROM m_BZ_AutoSchedule  where CODING ='" + code + "'"
        Dim codeTables As DataTable = Conn.GetDataTable(sql)
        If codeTables.Rows.Count = 0 Then
            MessageBox.Show("没有相关编码的数据信息,请确认输入的编码是否正确")
            Return
        End If
        Dim visible As String = codeTables.Rows(0)("Visible")
        If visible = 1 Then
            sql = "UPDATE m_BZ_AutoSchedule SET Visible = '0' WHERE CODING ='" + code + "'  AND IDENTIFIER = '" + num.ToString + "'"
        Else
            sql = "UPDATE m_BZ_AutoSchedule SET Visible = '1' WHERE CODING ='" + code + "'  AND IDENTIFIER = '" + num.ToString + "'"
        End If

        Try
            Conn.ExecSql(sql)
            MessageBox.Show("状态修改成功")
            Conn.PubConnection.Close()
            Conn.PubConnection.Dispose()
        Catch ex As Exception
            Conn.PubConnection.Close()
            Conn.PubConnection.Dispose()
            MessageBox.Show("请确认需要修改的编码是否存在,或联系资讯维护人员:" + ex.Message)
            Return
        End Try

    End Sub

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        Dim code As String
        Dim descri As String
        Dim checkedList As CheckedListBox
        Select Case Me.TabControl1.SelectedIndex
            Case 0
                MessageBox.Show("首页不提供修改功能")
                Return
            Case 1
                code = ParTestBox.Text
                descri = TextBox2.Text
                checkedList = CheckedListBoxPar
            Case 2
                code = TextBox4.Text
                descri = TextBox3.Text
                checkedList = CheckedListBoxMach
            Case 3
                MessageBox.Show("产品形态编码不对外提供修改功能,请点击 停用/启用")
                Return
        End Select
        '去修改
        UpdataAll(code, descri, checkedList)
    End Sub
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <param name="code">编号</param>
    ''' <param name="descri">描述</param>
    ''' <param name="checkedList">产品形态编码</param>
    ''' <remarks></remarks>
    Private Sub UpdataAll(code As String, descri As String, checkedList As CheckedListBox)
        If code.Trim = "" Or checkedList.Items.Count = 0 Then
            MessageBox.Show("请输入编号和选择形态编码")
            Return
        End If
        Dim sb As String = ""
        For index = 0 To checkedList.Items.Count - 1
            If checkedList.GetItemChecked(index) Then
                If sb = "" Then
                    sb = checkedList.Items(index)
                Else
                    sb = sb + "," + checkedList.Items(index)
                End If
            End If
        Next

        sql = "UPDATE m_BZ_AutoSchedule SET DESCRI = N'" + descri + "',Attribute = N'" + sb + "', ModifyTime = GETDATE() WHERE CODING = N'" + code + "'"

        Select Case Me.TabControl1.SelectedIndex
            Case 1
                If TextBox10.Text.Trim = "" Or TextBox11.Text.Trim = "" Or TextBox9.Text.Trim = "" Then
                    MessageBox.Show("请输入 导体规格,PIN数,冲孔大小")
                    Return
                End If
                sql = "UPDATE m_BZ_AutoSchedule SET DESCRI = N'" + descri + "',Attribute = N'" + sb + "', ModifyTime = GETDATE() ,Conductor = N'" + TextBox10.Text.Trim + "',PinNum=N'" + TextBox9.Text.Trim + "',Punching=N'" + TextBox11.Text.Trim + "'  WHERE CODING = N'" + code + "'"
        End Select

        Try
            Conn.ExecSql(sql)
            MessageBox.Show("修改成功")
        Catch ex As Exception
            MessageBox.Show("异常情况,请联系资讯维护人员")
            Return
        Finally
            Conn.PubConnection.Close()
            Conn.PubConnection.Dispose()
        End Try
    End Sub

    'Private Sub TimeBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TimeBox.SelectedIndexChanged
    '    If TimeBox.Text = "日" Then
    '        Label17.Visible = True
    '        ClassBox.Visible = True
    '    Else
    '        Label17.Visible = False
    '        ClassBox.Visible = False
    '    End If

    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Excle(DataGridView2)
    End Sub
End Class