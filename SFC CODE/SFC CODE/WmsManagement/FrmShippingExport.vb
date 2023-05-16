
'--品质出货导出
'--Create by :　马锋
'--Create date :　2015/06/10
'--Update date :  
'--Ver : V01

#Region "类库导入"
Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports SysBasicClass
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
#End Region

Public Class FrmShippingExport

#Region "加载事件"

    Private Sub FrmShippingQCCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpStartDate.Value = Now.AddDays(-1)
        Me.dtpEndDate.Value = Now.AddDays(1)
    End Sub

#End Region

#Region "菜单事件"

    '查询
    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        SetMessage("", False)
        Try
            If Not CheckQueryParameter() Then
                Return
            End If

            GetShippingDetail()
        Catch ex As Exception
            SetMessage("查询异常", False)
        End Try
    End Sub

    '导出
    Private Sub ToolExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExport.Click
        SetMessage("", False)
        Try
            If Me.dgvShippingDetail.RowCount < 1 Then Exit Sub
            LoadDataToExcel(Me.dgvShippingDetail, Me.Text)

        Catch ex As Exception
            SetMessage("导出异常", False)
        End Try
    End Sub

    '退出
    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            SetMessage("退出异常", False)
        End Try
    End Sub

#End Region

#Region "方法"

    Private Sub SetMessage(ByVal Message As String, ByVal bType As Boolean)
        If (bType) Then
            Me.lblMessage.ForeColor = Color.Green
        Else
            Me.lblMessage.ForeColor = Color.Red
        End If
        Me.lblMessage.Text = Message
    End Sub

    Private Function CheckQueryParameter() As Boolean
        If (dtpEndDate.Value < dtpStartDate.Value) Then
            SetMessage("查询结束时间不能大于开始时间！", False)
            Return False
        End If

        Dim startDate As DateTime = DateTime.Parse(Me.dtpStartDate.Text)
        Dim endDate As DateTime = DateTime.Parse(Me.dtpEndDate.Text)
        If startDate.AddDays(31) < endDate Then
            SetMessage("查询时间相隔最多请不要超过一个月！", False)
            Return False
        End If

        Return True
    End Function

    '获取出货扫描明细
    Private Sub GetShippingDetail()
        Dim strSQL As String
        Dim strWhere As String = ""
        strWhere = " AND Intime between cast('" & Me.dtpStartDate.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime) and cast('" & Me.dtpEndDate.Value.ToString("yyyy/MM/dd") + " 23:59:59" & "' as datetime)"

        If (Not String.IsNullOrEmpty(Me.txtCustDeliveryNO.Text.Trim)) Then
            strWhere = strWhere & " AND HWShippingNO='" & Me.txtCustDeliveryNO.Text.Trim.Replace("'", "''") & "' "
        End If

        If (Not String.IsNullOrEmpty(Me.txtPartNO.Text.Trim())) Then
            strWhere = strWhere & " AND HWPartId='" & Me.txtPartNO.Text.Trim() & "' "
        End If

        strSQL = "SELECT  CartonID, HWCartonId, HWPartId, HWQty, HWShippingNO, CartonOutqty, UserID, CONVERT(VARCHAR(32), Intime, 120) AS Intime " & _
                "FROM    m_WhOutD_t WHERE 1=1 " & strWhere & " ORDER BY HWShippingNO "
        LoadData(strSQL, Me.dgvShippingDetail)
    End Sub

    '填充数据
    Private Sub LoadData(ByVal Sqlstr As String, ByVal dgvName As DataGridView)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            dgvName.Rows.Clear()
            DReader = Conn.GetDataReader(Sqlstr)
            Do While DReader.Read()
                dgvName.Rows.Add(DReader.Item("CartonID").ToString, DReader.Item("HWCartonId").ToString, DReader.Item("HWPartId").ToString, DReader.Item("HWQty").ToString, DReader.Item("HWShippingNO").ToString, DReader.Item("CartonOutqty").ToString, _
                   DReader.Item("UserID").ToString, DReader.Item("Intime").ToString)
            Loop

            Me.ToolLblCount.Text = Me.dgvShippingDetail.Rows.Count
            DReader.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception

            If (Not DReader.IsClosed) Then
                DReader.Close()
            End If

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            SetMessage("获取数据异常", False)
        End Try
    End Sub

    Public Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String)
        Try

            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            '导出CSV文件格式，以便用户查询，以,号区分

            If Not Directory.Exists("c:\MES") Then
                Directory.CreateDirectory("c:\MES")
            End If

            Dim Swriter As New IO.StreamWriter("c:\MES\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            Dim r As Integer
            Dim c As Integer
            For r = 0 To DgMoData.Rows.Count - 1
                wValue = ""
                nColqty = 0
                For c = 0 To DgMoData.Columns.Count - 1
                    '写入标题行
                    If bColName = False Then
                        If wColName = "" Then
                            wColName = DgMoData.Columns(c).HeaderText.Replace(",", "，")
                        Else
                            wColName = wColName + "," + DgMoData.Columns(c).HeaderText.Replace(",", "，")
                        End If
                    End If

                    '写入每行的值
                    'If DgMoData(c, r).Value Is System.DBNull.Value Then
                    If nColqty = 0 Then
                        If (ckbCartonSame.Checked And c = 0) Then
                            wValue = DgMoData(c, r).Value.ToString.Replace(",", "，").Substring(0, DgMoData(c, r).Value.ToString.Length - 8)
                        Else
                            wValue = DgMoData(c, r).Value.ToString.Replace(",", "，")
                        End If
                    Else
                        If (ckbCartonSame.Checked And c = 0) Then
                            wValue = wValue + "," + DgMoData(c, r).Value.ToString.Replace(",", "，").Substring(0, DgMoData(c, r).Value.ToString.Length - 8)
                        Else
                            wValue = wValue + "," + DgMoData(c, r).Value.ToString.Replace(",", "，")
                        End If
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

            MessageBox.Show("文件导出成功,导出位置：c:\MES\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
#End Region

End Class