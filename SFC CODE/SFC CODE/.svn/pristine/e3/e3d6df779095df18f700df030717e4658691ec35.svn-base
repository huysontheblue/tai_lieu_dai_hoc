Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame
Imports System.IO
Imports UIHandler
Imports MainFrame.SysCheckData

Public Class FrmMOSchQuery
    Private m_strMultiMO As String = String.Empty

    Private Enum enumMO
        Moid = 0
        PartID
        dqc
        Lineid
        leadername
        telphone
        Station
        InQty
        OutQty
        Moqty
        NGQty
        NgRate
        ScheFinishDate
        leaderid 'hide
    End Enum


    Private Sub FrmMOSch_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (Me.DesignMode = False) Then
            Me.DgMoData.AutoGenerateColumns = False
            DtStar.Value = Now().AddDays(-10).ToString("yyyy-MM-dd")
            DtEnd.Value = Now().ToString("yyyy-MM-dd")
            KBCom.BindComboxClass(cbbDept)
            Me.lblInfo.Text = String.Empty
        End If
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        Dim strSQL As String = String.Empty
        Dim o_strErrMOList As String = String.Empty
        Me.lblInfo.Text = String.Empty
        Try
            If Not KBCom.CheckDate(DtStar, DtEnd) Then Exit Sub

            m_strMultiMO = ""
            If Me.txtMultiMO.Text.Trim <> "" Then
                If Me.txtMultiMO.Lines.Length > 0 Then
                    For i = 0 To Me.txtMultiMO.Lines.Length - 1
                        If Not Me.txtMultiMO.Lines(i).ToString.Trim = "" Then
                            If Not CheckIsMO(Me.txtMultiMO.Lines(i).ToString.Trim) Then
                                o_strErrMOList &= IIf(o_strErrMOList.Equals(String.Empty), "", ",") + Me.txtMultiMO.Lines(i).ToString.Trim
                                lblInfo.Text = "工单: " & o_strErrMOList & " 不存在"
                                Continue For
                            End If
                            m_strMultiMO = m_strMultiMO + Me.txtMultiMO.Lines(i).ToString.Trim + ","
                        End If
                    Next
                End If
                If m_strMultiMO.Length > 0 Then m_strMultiMO = m_strMultiMO.Substring(0, m_strMultiMO.Length - 1)
            End If
            'begindate,enddate
            strSQL = "EXEC m_KanBanQueryMOSch_p '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'"
            strSQL = String.Format(strSQL, Me.DtStar.Text, Me.DtEnd.Text, KBCom.Getid(cbbDept.Text), Me.cbbLine.Text, m_strMultiMO, _
                                   Me.txtPartNo.Text.Trim, _
                                   VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)
            Dim dts As DataTable = DbOperateUtils.GetDataTable(strSQL)
            DgMoData.DataSource = dts
            ToolCount.Text = DgMoData.RowCount.ToString()
        Catch ex As Exception
            UIFunction.SetMessage("数据加载失败，请重试！", lblMsg, True, False)
        End Try
    End Sub

    Private Function CheckIsMO(ByVal parMO As String) As Boolean
        Dim ObjDB As New MainFrame.SysDataHandle.SysDataBaseClass()
        Dim lsSQL As String = String.Empty
        Try
            lsSQL = " SELECT MOID FROM m_MainMO_t WHERE  MOID='" & parMO & "'"
            If ObjDB.GetRowsCount(lsSQL) > 0 Then
                CheckIsMO = True
            Else
                CheckIsMO = False
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMOSchQuery", "CheckIsMO", "MES")
        Finally
            ObjDB = Nothing
        End Try
        Return CheckIsMO
    End Function

    Private Sub cbbDept_DropDownClosed(sender As Object, e As EventArgs) Handles cbbDept.DropDownClosed
        KBCom.LoadLineIDToCombo(cbbLine, KBCom.Getid(cbbDept.Text))
    End Sub

    Private Sub DgMoData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgMoData.CellClick
        If Me.DgMoData.Rows.Count = 0 Then Exit Sub
        Dim o_strMOID As String = "", strSQL As String = "", o_strStationID As String = ""
        Dim ObjDB As New MainFrame.SysDataHandle.SysDataBaseClass()
        ' SELECT 1 FROM m_Rstation_t WHERE ScanY='Y' AND Stationid='A00001'

        o_strMOID = DgMoData.Rows(DgMoData.SelectedCells(0).RowIndex).Cells("Moid").Value.ToString
        o_strStationID = DgMoData.Rows(DgMoData.SelectedCells(0).RowIndex).Cells("Station").Value.ToString

        strSQL = "EXEC m_QueryMOSchDetail_p '{0}', '{1}'"
        strSQL = String.Format(strSQL, o_strMOID, o_strStationID)
        Dim dt As DataTable = ObjDB.GetDataTable(strSQL)

        dgMOSchDetail.DataSource = dt
        dgMOSchDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Dim i As Integer = 0
        Dim o_MOSchFinishDate As Date = Nothing
        For Each dr As DataGridViewRow In DgMoData.Rows
            DgMoData.Rows(i).Cells(enumMO.leadername).Style.Font = New Font("宋体", 12, FontStyle.Underline) '4,New Font("宋体", 12, FontStyle.Underline)
            If (Not IsNothing(DgMoData.Rows(i).Cells(enumMO.ScheFinishDate).Value)) AndAlso Not IsDBNull(DgMoData.Rows(i).Cells(enumMO.ScheFinishDate).Value) Then
                DateTime.TryParse(DgMoData.Rows(i).Cells(enumMO.ScheFinishDate).Value, o_MOSchFinishDate)
                If Date.Compare(o_MOSchFinishDate, DateTime.Now) < 0 Then '现在已经超过了工单交货日期
                    If Val(DgMoData.Rows(i).Cells(enumMO.OutQty).Value) < Val(DgMoData.Rows(i).Cells(enumMO.Moqty).Value) Then
                        'show red
                        DgMoData.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    End If
                End If
            End If
            i = i + 1
        Next
    End Sub

    Private Sub ToolExcel_Click(sender As Object, e As EventArgs) Handles ToolExcel.Click
        ExcelUtils.LoadDataToExcel(Me.DgMoData, Me.Text)
    End Sub

    Private Sub ToolDetail_Click(sender As Object, e As EventArgs) Handles tsbDetail.Click
        ExcelUtils.LoadDataToExcel(Me.dgMOSchDetail, Me.Text)
    End Sub

    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    Private Sub DgMoData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgMoData.CellDoubleClick
        Dim empPhotoUrl As String = String.Empty
        Dim o_strUserID As String = String.Empty
        Try
            If IsNothing(Me.DgMoData.CurrentRow) Then Exit Sub
            o_strUserID = Me.DgMoData.CurrentRow.Cells(enumMO.leaderid).Value.ToString
            If String.IsNullOrEmpty(o_strUserID) Then Exit Sub
            Using o_FrmPic As FrmPic = New FrmPic(o_strUserID)
                o_FrmPic.ShowDialog()
            End Using
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "KanBan.FrmMOSchQuery", "DgMoData_CellDoubleClick", "MES")
        End Try
    End Sub

End Class