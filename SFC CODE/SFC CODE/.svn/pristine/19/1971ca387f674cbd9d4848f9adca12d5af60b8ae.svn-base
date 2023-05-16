Imports System.Text
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports MainFrame
Imports SysBasicClass

Public Class FrmCutCardPartDetail


    Sub New(ByVal cutCardPartId As String, ByVal cutCardStationId As String, ByVal drawingVer As String, ByVal isQueryOldVersion As Boolean)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._cutCardPartId = cutCardPartId
        Me._cutCardStationId = cutCardStationId
        Me._isQueryOldVersion = isQueryOldVersion
        Me._drawingVer = drawingVer
    End Sub

#Region "属性"
    Private _cutCardPartId As String
    Private _drawingVer As String
    Private _isQueryOldVersion As Boolean
    Private _cutCardStationId As String
#End Region

#Region "事件"
    Private Sub FrmCutCardPartDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'Add get the latest BOM info, cq20161013
            If Not PnDownLoadBom() Then
                'do nothing
            End If
            BindBomGrid()
            BindEquipmentGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCutCardPartDetail", "FrmCutCardPartDetail_Load", "sys")
        End Try
    End Sub


    Private Function PnDownLoadBom() As Boolean
        Dim strCustID As String = "", strSeriesID As String = ""
        Dim strSQL As String = ""
        Dim o_dt As DataTable
        'A. First Download PN from ERP,Add by CQ 20151116
        If VbCommClass.VbCommClass.IsConSap = "Y" Then
            strSQL = SapCommon.GetErpFilterSqlSap(Me._cutCardPartId)
            o_dt = OracleOperateUtils.GetDataTableSap(strSQL)
        Else
            strSQL = SapCommon.GetErpFilterSql(Me._cutCardPartId)
            o_dt = RCardComBusiness.GetDataTableOracle(strSQL)
        End If
        Try
            'Get CustID from MES first, if not get, then get from UI
            strCustID = RunCardBusiness.GetCustIDFromTT(Me._cutCardPartId)
            If String.IsNullOrEmpty(strCustID) Then
                strCustID = "99"
            End If

            'Get Serial from TT first, if not get, then get from UI
            strSeriesID = RunCardBusiness.GetSerialIDFromTT(Me._cutCardPartId)
            If String.IsNullOrEmpty(strSeriesID) Then
                strSeriesID = "018"
            End If

            o_dt.Columns.Add("CustID", GetType(String))
            For Each dr As DataRow In o_dt.Rows
                dr.Item("CustID") = strCustID
            Next

            o_dt.Columns.Add("SeriesID", GetType(String))
            For Each dr As DataRow In o_dt.Rows()
                dr.Item("SeriesID") = strSeriesID
            Next

            If Not RunCardBusiness.SaveErpData(o_dt) Then
                ' ShowMessage(file & "-->执行sql 错误，请联系IT！！")
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        Finally
            o_dt = Nothing
        End Try
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        '
        If dgvBomPart.Rows.Count <= 0 Then
            MessageBox.Show("请下载BOM")
            Exit Sub
        End If
        '
        'If dgvEquipmentPart.Rows.Count <= 0 Then
        '    MessageBox.Show("治具料件")
        '    Exit Sub
        'End If
        '保存所选
        'Dim sbSql As New StringBuilder
        Dim strDeleteSql As String
        Dim strInsertSql As String
        Dim strSql As String = String.Empty
        Dim partNumber As String = GetPn()
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        Dim Factoryid As String = VbCommClass.VbCommClass.Factory
        Dim Profitcenter As String = VbCommClass.VbCommClass.profitcenter

        Try
            'Save 
            If _isQueryOldVersion = False Then
                strDeleteSql = String.Format("DELETE m_CutCardDPart_t where PartID='{0}' and isnull(EWPNType,'R')='R' and Stationid = '{1}' " & RCardComBusiness.GetFatoryProfitcenter(),
                                             Me._cutCardPartId, Me._cutCardStationId)
                strInsertSql = "insert into m_CutCardDPart_t(PartID,Stationid,EWPartNumber,DrawingVer,UserID,InTime,Factoryid,Profitcenter,EWPNType) values("
            Else
                strDeleteSql = String.Format("DELETE m_CutCardDPartOldVer_t where PartID='{0}' and Stationid = '{1}'" & RCardComBusiness.GetFatoryProfitcenter(),
                                             Me._cutCardPartId, Me._cutCardStationId)
                strInsertSql = "INSERT into m_CutCardDPartOldVer_t(PartID,Stationid,EWPartNumber,DrawingVer,UserID,InTime,Factoryid,Profitcenter,EWPNType) values("
            End If
            For Each row As DataGridViewRow In dgvBomPart.Rows
                If row.Cells("Bom_Select").Value.ToString = "Y" Then
                    strSql += strInsertSql + String.Format("'{0}','{1}','{2}','{3}','{4}',getdate(),'{5}','{6}','R')", Me._cutCardPartId, Me._cutCardStationId,
                                            row.Cells("Bom_PartNumber").Value.ToString, _drawingVer, UserID, Factoryid, Profitcenter)
                End If
            Next
            '
            For Each row As DataGridViewRow In dgvEquipmentPart.Rows
                If row.Cells("EQ_Select").Value.ToString = "Y" Then
                    strSql = strSql + " if isnull((SELECT TOP 1 1 FROM m_CutCardDPart_t where PartID='" & Me._cutCardPartId & "'  and Stationid = '" & Me._cutCardStationId & "' and EWPartNumber='" & row.Cells("EQ_PartNumber").Value.ToString & "'),0)=0  begin "
                    strSql += strInsertSql + String.Format("'{0}','{1}','{2}','{3}','{4}',getdate(),'{5}','{6}','E')", Me._cutCardPartId, Me._cutCardStationId,
                                            row.Cells("EQ_PartNumber").Value.ToString, _drawingVer, UserID, Factoryid, Profitcenter)
                    strSql = strSql + " end"
                End If
            Next

            DbOperateUtils.ExecSQL(strDeleteSql + strSql.ToString()) '该方法会执行事务处理
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCutCardPartDetail", "btnOK_Click", "RCard")
        End Try
    End Sub

    Private Sub txtFind_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFindPn.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtFindPn.Text.Trim <> "" Then
                BindEquipmentGrid(" AND TAvcPart LIKE N'%" & txtFindPn.Text.Trim & "%'")
            Else
                BindEquipmentGrid()
            End If
        End If
    End Sub

    Private Sub txtFindRule_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFindRule.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtFindRule.Text.Trim <> "" Then
                BindEquipmentGrid(" AND DESCRIPTION LIKE N'%" & txtFindRule.Text.Trim & "%' ")
            Else
                BindEquipmentGrid()
            End If
        End If
    End Sub

    Private Sub txtFindBand_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFindBand.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtFindBand.Text.Trim <> "" Then
                BindEquipmentGrid(" AND TypeDest LIKE N'%" & txtFindBand.Text.Trim & "%' ")
            Else
                BindEquipmentGrid()
            End If
        End If
    End Sub

#End Region

#Region "方法"
    Private Sub BindBomGrid()
        Try
            Dim trSQL As String = Nothing

            trSQL = GetSQLBom(PartType.Bom)

            dgvBomPart.Rows.Clear()
            Dim dt As DataTable = DbOperateUtils.GetDataTable(trSQL)
            For Each row As DataRow In dt.Rows
                dgvBomPart.Rows.Add(row("Flag").ToString(), row("PartNumber").ToString(), row("TypeDest").ToString(), row("DESCRIPTION").ToString())
            Next

            dgvBomPart.Columns(1).ReadOnly = True
            dgvBomPart.Columns(2).ReadOnly = True
        Catch ex As Exception
            Throw ex
        End Try

        '"品名"列全屏显示
        'dgvBomPart.Columns("Bom_Description").AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub BindEquipmentGrid(Optional ByVal where As String = "")

        Dim strSQL As String = ""
        Try
            '加载Data
            strSQL = GetSQLEqu(PartType.Equ)

            If where <> "" Then
                strSQL += where
            End If
            strSQL += " ORDER BY Flag desc, PartNumber asc"
            dgvEquipmentPart.Rows.Clear()
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            For Each row As DataRow In dt.Rows
                dgvEquipmentPart.Rows.Add(row("Flag").ToString(), row("PartNumber").ToString(), row("TypeDest").ToString(), row("DESCRIPTION").ToString())
            Next
            dgvEquipmentPart.Columns(1).ReadOnly = True
            dgvEquipmentPart.Columns(2).ReadOnly = True
            '"品名"列全屏显示
            'dgvEquipmentPart.Columns("EQ_Description").AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmCutCardPartDetail", "BindEquipmentGrid", "RCard")
            Throw ex
        End Try
    End Sub

    Private Enum PartType
        Bom = 0
        Equ
    End Enum

    Private Function GetSQLBom(type As String) As String
        Dim strSQL As String = String.Empty

        strSQL = "SELECT TOP 200 Case WHEN B.EWPartNumber IS NULL then 'N' else 'Y' end  Flag , TAvcPart PartNumber,TypeDest,DESCRIPTION  " &
               "FROM m_PartContrast_t A LEFT JOIN  {0} B  " &
               "ON A.TAvcPart = B.EWPartNumber AND A.PAvcPart = B.PartID  " &
               "AND B.Stationid = '{1}' " &
                RCardComBusiness.GetFatoryProfitcenter("B") &
               "where 1 = 1 and  isnull(TYPE,'R') = 'R' AND A.TAvcPart <> A.PAvcPart  AND  A.PAvcPart = '{2}'"

        If _isQueryOldVersion = False Then
            strSQL = String.Format(strSQL, "m_CutCardDPart_t", Me._cutCardStationId, Me._cutCardPartId)
        Else
            strSQL = String.Format(strSQL, "m_CutCardDPartOldVer_t", Me._cutCardStationId, Me._cutCardPartId)
        End If
        strSQL += " ORDER BY Flag desc, PartNumber asc"

        GetSQLBom = strSQL
    End Function

    Private Function GetSQLEqu(type As String) As String
        Dim strSQL As String = String.Empty

        strSQL = "SELECT TOP 200 Case when B.EWPartNumber IS null then 'N' else 'Y' end  Flag , TAvcPart PartNumber,TypeDest,DESCRIPTION  " &
               "from m_PartContrast_t A left join  {0} B  " &
               "ON A.TAvcPart = B.EWPartNumber  AND B.PartID = '{1}' AND B.Stationid = '{2}'" &
                RCardComBusiness.GetFatoryProfitcenter("B") &
               "WHERE 1 = 1  and  isnull(TYPE,'R') = 'E' AND  ISNULL(B.EWPNType,'E') ='E' "

        If _isQueryOldVersion = False Then
            strSQL = String.Format(strSQL, "m_CutCardDPart_t", Me._cutCardPartId, Me._cutCardStationId)
        Else
            strSQL = String.Format(strSQL, "m_CutCardDPartOldVer_t", Me._cutCardPartId, Me._cutCardStationId)
        End If

        GetSQLEqu = strSQL
    End Function

    Private Function GetPn() As String
        Dim sql As String = "SELECT PartID FROM m_RCardCutM_t WHERE PartID='" & _cutCardPartId & "'" & RCardComBusiness.GetFatoryProfitcenter()
        Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
        If dt.Rows.Count > 0 Then Return dt.Rows(0)(0).ToString

        Return ""
    End Function

#End Region

End Class