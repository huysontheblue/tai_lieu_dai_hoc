Imports System.Text
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports MainFrame
Imports SysBasicClass

Public Class FrmRunCardPartDetail


    Sub New(ByVal runCardPartId As String, ByVal runCardStationId As String, ByVal drawingVer As String, ByVal isQueryOldVersion As Boolean, ByVal StationName As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me._runCardPartId = runCardPartId
        Me._runCardStationId = runCardStationId
        Me._isQueryOldVersion = isQueryOldVersion
        Me._drawingVer = drawingVer
        Me.Text = Me.Text + "~工站名称:" + StationName
    End Sub

#Region "属性"
    Private _runCardPartId As String
    Private _drawingVer As String
    Private _isQueryOldVersion As Boolean
    Private _runCardStationId As String
#End Region

#Region "事件"
    Private Sub FrmRunCardPartDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'Add get the latest BOM info, cq20161013
            If Not PnDownLoadBom() Then
                'do nothing
            End If
            BindBomGrid()
            BindEquipmentGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardPartDetail", "FrmRunCardPartDetail_Load", "sys")
        End Try
    End Sub


    Private Function PnDownLoadBom() As Boolean
        Dim strCustID As String = "", strSeriesID As String = ""
        Dim strSQL As String
        Dim o_dt As DataTable

        If VbCommClass.VbCommClass.IsConSap = "Y" Then
            strSQL = SapCommon.GetErpFilterSqlSap(_runCardPartId)
            o_dt = OracleOperateUtils.GetDataTableSap(strSQL)
        Else
            'A. First Download PN from ERP,Add by CQ 20151116
            strSQL = SapCommon.GetErpFilterSql(_runCardPartId)
            o_dt = OracleOperateUtils.GetDataTable(strSQL)
        End If

        Try
            'Get CustID from MES first, if not get, then get from UI
            strCustID = RunCardBusiness.GetCustIDFromTT(Me._runCardPartId)
            If String.IsNullOrEmpty(strCustID) Then
                strCustID = "99"
            End If

            'Get Serial from TT first, if not get, then get from UI
            strSeriesID = RunCardBusiness.GetSerialIDFromTT(Me._runCardPartId)
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
        Dim strLogSql As String = ""
        Dim strDeleteSql As String
        Dim strInsertSql As String
        Dim strSql As String = String.Empty
        Dim partNumber As String = GetPn()
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        Dim Factoryid As String = VbCommClass.VbCommClass.Factory
        Dim Profitcenter As String = VbCommClass.VbCommClass.profitcenter
        Dim strOldPartIDList As String = String.Empty
        Dim strNewPartIDList As String = String.Empty
        Dim blnChangePart As Boolean = False
        Try
            'Save 
            If _isQueryOldVersion = False Then

                strOldPartIDList = getPartNumList()

                strDeleteSql = String.Format("DELETE m_RCardDPart_t where PartID='{0}' and isnull(EWPNType,'R')='R' and Stationid = '{1}' " & RCardComBusiness.GetFatoryProfitcenter(),
                                             Me._runCardPartId, Me._runCardStationId)
                strInsertSql = "insert into m_RCardDPart_t(PartID,Stationid,EWPartNumber,DrawingVer,UserID,InTime,Factoryid,Profitcenter,EWPNType) values("
            Else
                strDeleteSql = String.Format("delete m_RCardDPartOldVer_t where PartID='{0}' and Stationid = '{1}'" & RCardComBusiness.GetFatoryProfitcenter(),
                                             Me._runCardPartId, Me._runCardStationId)
                strInsertSql = "insert into m_RCardDPartOldVer_t(PartID,Stationid,EWPartNumber,DrawingVer,UserID,InTime,Factoryid,Profitcenter,EWPNType) values("
            End If
            For Each row As DataGridViewRow In dgvBomPart.Rows
                If row.Cells("Bom_Select").Value.ToString = "Y" Then
                    strSql += strInsertSql + String.Format("'{0}','{1}','{2}','{3}','{4}',getdate(),'{5}','{6}','R')", Me._runCardPartId, Me._runCardStationId,
                                            row.Cells("Bom_PartNumber").Value.ToString, _drawingVer, UserID, Factoryid, Profitcenter)

                    If Not String.IsNullOrEmpty(strOldPartIDList) Then
                        If ("," & strOldPartIDList & ",").IndexOf("," & row.Cells("Bom_PartNumber").Value.ToString & ",") > 0 Then
                            'do nothing
                        Else
                            blnChangePart = True
                        End If
                    End If
                    strNewPartIDList &= IIf(String.IsNullOrEmpty(strNewPartIDList), "", ",") + row.Cells("Bom_PartNumber").Value.ToString
                End If
            Next
            '
            For Each row As DataGridViewRow In dgvEquipmentPart.Rows
                If row.Cells("EQ_Select").Value.ToString = "Y" Then
                    strSql = strSql + " if isnull((select top 1 1 from m_RCardDPart_t where PartID='" & Me._runCardPartId & "'  and Stationid = '" & Me._runCardStationId & "' and EWPartNumber='" & row.Cells("EQ_PartNumber").Value.ToString & "'),0)=0  begin "
                    strSql += strInsertSql + String.Format("'{0}','{1}','{2}','{3}','{4}',getdate(),'{5}','{6}','E')", Me._runCardPartId, Me._runCardStationId,
                                            row.Cells("EQ_PartNumber").Value.ToString, _drawingVer, UserID, Factoryid, Profitcenter)
                    strSql = strSql + " end"

                    If Not String.IsNullOrEmpty(strOldPartIDList) Then
                        If ("," & strOldPartIDList & ",").IndexOf("," & row.Cells("EQ_PartNumber").Value.ToString & ",") > 0 Then
                            'do nothing
                        Else
                            blnChangePart = True
                        End If
                    End If

                    Dim PN = row.Cells("EQ_PartNumber").Value.ToString.Trim() '料号

                    strNewPartIDList &= IIf(String.IsNullOrEmpty(strNewPartIDList), "", ",") + PN

                    'add by 马跃平 2018-07-06
                    Dim TypeDest = row.Cells("EQ_Description").Value
                    Dim DESCRIPTION = row.Cells("EQ_Description1").Value


                    Dim sql = "select * from m_PartContrast_t where TAvcPart='" & PN & "'"
                    If DbOperateUtils.GetDataTable(sql).Rows.Count > 0 Then
                        sql = "select * from m_PartContrast_t " & vbCrLf &
                        "where TAvcPart='" & PN & "' and PAvcPart='" & Me._runCardPartId & "' "
                        If DbOperateUtils.GetDataTable(sql).Rows.Count = 0 Then
                            Dim UseId = VbCommClass.VbCommClass.UseId
                            sql = String.Format(" INSERT into m_PartContrast_t (TAvcPart,PAvcPart,UseY,Userid,Intime,SubstituteNumber,TYPE,TypeDest,DESCRIPTION,Factory) VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}',N'{7}',N'{8}','{9}')", PN, Me._runCardPartId, "Y", UseId, "getdate()", "0", "E", TypeDest, DESCRIPTION, VbCommClass.VbCommClass.Factory)
                        End If
                    Else

                    End If
                    DbOperateUtils.ExecSQL(sql)
                End If
            Next

            If blnChangePart Then
                strSql = strSql + " declare @OldUserID varchar(20), @OldModifyTime datetime" & _
                    " SELECT TOP 1  @OldUserID=USERID ,@OldModifyTime=InTime FROM m_RCardDPart_t WHERE PARTID='" & partNumber & "' AND Stationid = '" & Me._runCardStationId & "'" & _
                     " Insert into m_RCardChangeLog_t(PartID,StationID, Type, OldUserID, OldModifyTime,OldValue,NewUserID,NewModifyTime,NewValue)" & _
                    " Values('" & partNumber & "','" & Me._runCardStationId & "',N'物料', @OldUserID, @OldModifyTime,N'" & strOldPartIDList & "'," & _
                    " '" & VbCommClass.VbCommClass.UseId & "',getdate(), N'" & strNewPartIDList & "')"

            End If

            DbOperateUtils.ExecSQL(strDeleteSql + strSql.ToString()) '该方法会执行事务处理
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmRunCardPartDetail", "btnOK_Click", "RCard")
        End Try
    End Sub

    Private Function getPartNumList() As String
        Dim lsSQL As String = String.Empty
        getPartNumList = ""
        lsSQL = " DECLARE @EWPartNumbers NVARCHAR(max)='' " & _
                " SELECT  @EWPartNumbers=@EWPartNumbers+ISNULL(A.EWPartNumber,'')+','" & _
                " FROM m_RCardDPart_t  AS A   WHERE  PARTID ='" & Me._runCardPartId & "'" & _
                " AND Stationid='" & Me._runCardStationId & "'" & _
               " SELECT @EWPartNumbers AS 'EWPartNumbers'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                getPartNumList = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item(0))
                If getPartNumList.Length > 0 Then
                    getPartNumList = getPartNumList.Substring(0, Len(getPartNumList) - 1)
                End If
            End If
        End Using
    End Function

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
            SysMessageClass.WriteErrLog(ex, "FrmRunCardPartDetail", "BindEquipmentGrid", "RCard")
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
            strSQL = String.Format(strSQL, "m_RCardDPart_t", Me._runCardStationId, Me._runCardPartId)
        Else
            strSQL = String.Format(strSQL, "m_RCardDPartOldVer_t", Me._runCardStationId, Me._runCardPartId)
        End If
        strSQL += " ORDER BY Flag desc, PartNumber asc"

        GetSQLBom = strSQL
    End Function

    Private Function GetSQLEqu(type As String) As String
        Dim strSQL As String = String.Empty

        strSQL = "SELECT distinct TOP 200 Case when B.EWPartNumber IS null then 'N' else 'Y' end  Flag , TAvcPart PartNumber,TypeDest,case when description is null or description='' or description='' then '/' else description end description " &
               "from m_PartContrast_t A left join  {0} B  " &
               "ON A.TAvcPart = B.EWPartNumber  AND B.PartID = '{1}' and a.PAvcPart='{1}' AND B.Stationid = '{2}'" &
                RCardComBusiness.GetFatoryProfitcenter("B") &
               "WHERE 1 = 1  and  isnull(TYPE,'R') = 'E' AND  ISNULL(B.EWPNType,'E') ='E'  "

        If _isQueryOldVersion = False Then
            strSQL = String.Format(strSQL, "m_RCardDPart_t", Me._runCardPartId, Me._runCardStationId)
        Else
            strSQL = String.Format(strSQL, "m_RCardDPartOldVer_t", Me._runCardPartId, Me._runCardStationId)
        End If

        GetSQLEqu = strSQL
    End Function

    Private Function GetPn() As String
        Dim sql As String = "SELECT PartID FROM m_RCardM_t WHERE PartID='" & _runCardPartId & "'" & RCardComBusiness.GetFatoryProfitcenter()
        Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
        If dt.Rows.Count > 0 Then Return dt.Rows(0)(0).ToString

        Return ""
    End Function

#End Region

End Class