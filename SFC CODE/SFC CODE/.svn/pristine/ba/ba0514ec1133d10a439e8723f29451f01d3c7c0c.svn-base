Imports Dundas.Charting.WinControl

Public Class ChartCommon

    Public Shared Sub CreateChart(panel As SplitContainer, dt As DataTable, ByVal X As Integer, ByVal Y As Integer)
        Dim chart As Chart = New Chart()

        Dim chartArea As ChartArea = New ChartArea()
        Dim legend As Legend = New Legend() '图例
        Dim series As Series = New Series()
        Dim IntervalY As String = GetInterval_Y(dt)

        chartArea.AxisX.LabelsAutoFit = False
        chartArea.AxisX.LabelStyle.FontAngle = -90
        chartArea.AxisX.LabelStyle.Interval = 1D
        chartArea.AxisX.LabelStyle.IntervalOffset = 1D
        chartArea.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Number
        chartArea.AxisX.MajorGrid.Enabled = False
        chartArea.AxisX.MajorTickMark.Enabled = False

        chartArea.AxisY.MajorGrid.Enabled = False
        chartArea.AxisY.Interval = IntervalY
        chartArea.AxisY2.LabelStyle.Format = "0.0%"
        chartArea.AxisY2.MajorGrid.Enabled = False
        chartArea.AxisY2.Maximum = 100D
        chartArea.AxisY2.Minimum = 0D
        chartArea.AxisY2.Interval = 10
        chartArea.AxisY2.LabelsAutoFit = True

        chartArea.Name = "chartArea1"
        chart.ChartAreas.Add(chartArea)

        chart.Name = "chart1"
        legend.Name = "Legend1"
        series.Name = "series1"
        series.Legend = "Legend1"
        series.ChartArea = "chartArea1"
        series.ShowInLegend = False

        chart.Legends.Add(legend)
        chart.Series.Add(series)

        chart.Location = New System.Drawing.Point(37, 40)
        chart.Size = New System.Drawing.Size(474, 326) '
        chart.TabIndex = 0
        chart.Text = "chart1"
        chart.Titles.Add("制程不良柏拉图")
        chart.Titles(0).Font = New System.Drawing.Font("Arial", 12, FontStyle.Bold)
        chart.ChartAreas("chartArea1").AxisX.LabelStyle.FontAngle = -0 'x轴倾斜的角度

        Call RandomData(dt, series, 100)

        Call MakeParetoChart(chart, "series1", "Pareto")

        'set the markers for each point of the Pareto Line
        chart.Series("Pareto").ShowLabelAsValue = True
        chart.Series("Pareto").ShowInLegend = False   '获取或设置一个标志,该标志指示是否在图例中显示项
        chart.Series("Pareto").MarkerColor = Color.Blue
        chart.Series("Pareto").MarkerStyle = MarkerStyle.Circle
        chart.Series("Pareto").MarkerBorderColor = Color.BlueViolet   'MidnightBlue
        chart.Series("Pareto").MarkerSize = 8 '圆点的大小
        chart.Series("Pareto").LabelFormat = "00.0%"

        '保存图片
        Dim C_Path As String = System.Environment.CurrentDirectory + "\PCBA_Chart.JPEG"
        chart.SaveAsImage(C_Path, System.Drawing.Imaging.ImageFormat.Bmp)

        chart.Location = New System.Drawing.Point(X, Y)
        chart.Size = New System.Drawing.Size(1200, 300)  '宽度，高度

        '设置Chart
        chart.Dock = DockStyle.Fill
        chart.BackColor = Color.LightGray
        panel.Panel1.Controls.Clear()
        panel.Panel1.Controls.Add(chart)
    End Sub

    Private Shared Function GetInterval_Y(dt As DataTable) As String
        Dim IntervalY As String = "1"
        Dim maxY As String = "0"
        If dt.Rows.Count > 0 Then
            maxY = dt.Rows(0)(1).ToString
        End If
        If maxY > 0 And maxY <= 5 Then
            IntervalY = 1
        ElseIf maxY > 5 And maxY <= 10 Then
            IntervalY = 2
        ElseIf maxY > 10 And maxY <= 50 Then
            IntervalY = 10
        ElseIf maxY > 50 And maxY <= 100 Then
            IntervalY = 20
        ElseIf maxY > 100 And maxY <= 500 Then
            IntervalY = 100
        ElseIf maxY > 500 And maxY <= 1000 Then
            IntervalY = 200
        ElseIf maxY > 1000 And maxY <= 5000 Then
            IntervalY = 1000
        ElseIf maxY > 5000 And maxY <= 10000 Then
            IntervalY = 2000
        End If
        Return IntervalY
    End Function

    Private Shared Sub RandomData(dt As DataTable, ByVal series As Series, Optional ByVal numOfPoint As Integer = 0)
        For Each dr As DataRow In dt.Rows
            series.Points.AddXY(dr(0), Convert.ToInt32(CStr(dr(1))))
        Next
    End Sub

    Private Shared Sub MakeParetoChart(ByVal chart As Chart, ByVal srcSeriesName As String, ByVal destSeriesName As String)
        Dim total As Double = 0.0, percentage As Double
        ' Get the name of the ChartArea of the source series
        Dim strChartArea As String = chart.Series(srcSeriesName).ChartArea

        ' Ensure that the source series is a column chart type
        chart.Series(srcSeriesName).Type = SeriesChartType.Column '柱形图类型
        chart.Series(srcSeriesName).Color = Color.Pink
        'chart.DataManipulator.Sort(PointsSortOrder.Ascending, srcSeriesName) '从大到小

        For Each pt As DataPoint In chart.Series(srcSeriesName).Points
            total += pt.YValues(0)
            pt.Label = pt.YValues(0).ToString   ' + "(" + pt.XValue.ToString + ")"
        Next

        ' Set the max. value on the primary axis to the total
        chart.ChartAreas(strChartArea).AxisY.Maximum = total  ' NG QTY1 + QTY2 + QTY3

        ' Create the destination series and add it to the chart
        Dim destSeries As Series = New Series(destSeriesName)
        chart.Series.Add(destSeries)

        ' Ensure the destination series is a Line or Spline chart type
        destSeries.Type = SeriesChartType.Line
        'destSeries.ChartType = SeriesChartType.Point;
        'destSeries.BorderWidth = 3;

        ' Assign the series to the same chart area as the column chart
        destSeries.ChartArea = chart.Series(srcSeriesName).ChartArea
        'destChartareas = chart.Series[srcSeriesName].ChartArea;
        'Assign this series to use the secondary axis and set its maximum to be 100%
        'destSeries.YAxisType = AxisType.Secondary
        destSeries.YAxisType = AxisType.Secondary
        chart.ChartAreas(strChartArea).AxisY2.Maximum = 100
        chart.ChartAreas(strChartArea).AxisY2.Minimum = 0
        chart.ChartAreas(strChartArea).AxisY2.LabelStyle.Format = "0%"
        chart.ChartAreas(strChartArea).AxisY2.LabelStyle.Interval = 10
        chart.ChartAreas(strChartArea).AxisY2.Title = "累计影响度(%)"
        ' Turn off the end point values of the primary X axis
        ' chart.ChartAreas(strChartArea).AxisX.LabelStyle.IsEndLabelVisible = False '最后一个标签是否显示
        chart.ChartAreas(strChartArea).AxisX.LabelStyle.ShowEndLabels = False
        ' chart.ChartAreas(strChartArea).AxisY2.Enabled = Charting.AxisEnabled.True
        chart.ChartAreas(strChartArea).AxisY2.Enabled = AxisEnabled.True
        ' For each point in the source series find % of total and assign it to destination series
        percentage = 0.0
        For Each pt As DataPoint In chart.Series(srcSeriesName).Points
            percentage = percentage + (pt.YValues(0) / total) * 100
            destSeries.Points.Add(Math.Round(percentage, 4))
        Next
    End Sub


End Class
