Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.IO
Imports MainFrame

''' <summary>
''' 修改者： 黄广都
''' 修改日： 2018/01/09
''' 修改内容：
''' -------------------修改记录---------------------
''' 
''' </summary>
''' <remarks>按系列不良报表</remarks>
Public Class FrmSeriesNGQuery


#Region "事件"
    Private Sub FrmSeriesNGQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtStar.Value = Now().ToString("yyyy/MM/dd")
        DtEnd.Value = Now().ToString("yyyy/MM/dd")
        '加载系列
        LoadDataToSeriesCombo(Me.cbbSeries)
        LoadDataToNgStationidCombo(Me.cbbStationId)
        '加载不良现象大类
        BindComboxCodeTypeBig(Me.cbbNgType)

    End Sub
    Private Sub cbbNgType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbNgType.SelectedIndexChanged
        If cbbNgType.Text = "" Then
            cbbNgCode.Items.Clear()
            Exit Sub
        End If
    
        LoadDataToNgCodeCombo(Me.cbbNgCode, cbbNgType.SelectedValue.ToString)
    End Sub

    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        Dim strSql As String
        Dim strSeries As String = ""
        Dim strStationID As String = ""
        Dim strCode As String = ""
        Dim strTemp As String = ""
        Try
            If CheckData() = True Then
                Me.lbMsg.Text = ""
                strTemp = Me.cbbSeries.Text
                For Each item As String In strTemp.Split(",")

                    strSeries = strSeries & ";" & item.Split("-")(0)
                Next
                strSeries = strSeries.Substring(1, strSeries.Length - 1)

                strTemp = Me.cbbStationId.Text
                For Each item As String In strTemp.Split(",")
                    strStationID = strStationID & ";" & item.Split("-")(0)
                Next
                strStationID = strStationID.Substring(1, strStationID.Length - 1)
                strTemp = Me.cbbNgCode.Text
                For Each item As String In strTemp.Split(",")
                    strCode = strCode & ";" & item.Split("-")(0)
                Next
                strCode = strCode.Substring(1, strCode.Length - 1)

                strSql = "exec m_QuerySeriesNGQuery_p '" & DtStar.Value & "','" & DtEnd.Value & "','" & strStationID & "','" & strSeries & "','" & strCode & "','" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'"
                Dim dt As DataTable = DbOperateReportUtils.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    Me.grvSeriesNg.DataSource = dt
                    lbAcount.Text = dt.Rows.Count
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicFind.FrmSeriesNGQuery", "ToolReflsh_Click", "sys")
        End Try

    End Sub


    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            If Not Me.grvSeriesNg Is Nothing AndAlso Me.grvSeriesNg.RowCount > 0 Then

                SysBasicClass.Export.OutToExcelFromDataGridView("系列不良报表", Me.grvSeriesNg, False)
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicFind.FrmSeriesNGQuery", "ToolExcel_Click", "sys")

        End Try
    End Sub

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub
#End Region




#Region "方法"
    ''' <summary>
    ''' 不良现象大类
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Sub BindComboxCodeTypeBig(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "select DISTINCT EsortName,CVer,(EsortName + '-' +CsortName) TEXT  from m_Code_t  where Usey='Y' ORDER BY CVer "

        BindCombox(strSQL, ColComboBox, "Text", "EsortName")
    End Sub
    '下拉
    Public Sub BindCombox(ByVal SQL As String, ByVal ColComboBox As ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateReportUtils.GetDataTable(SQL)

        Dim dr As DataRow = dt.NewRow

        dr(Text) = ""
        dr(value) = ""
        dt.Rows.InsertAt(dr, 0)

        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value


    End Sub

    Private Function CheckData() As Boolean
        Dim r As Boolean = False
        If Me.cbbSeries.Text = "" Then
            Me.lbMsg.Text = "请选择系列别!"
            Return False
        End If
        If Me.cbbStationId.Text = "" Then
            Me.lbMsg.Text = "请选择别不良站点!"
            Return False
        End If
        If Me.cbbNgType.Text = "" Then
            Me.lbMsg.Text = "请选择不良大类!"
            Return False
        End If
        If Me.cbbNgCode.Text = "" Then
            Me.lbMsg.Text = "请选择不良现象!"
            Return False
        End If
        Return True
    End Function
#End Region
   
  


End Class


