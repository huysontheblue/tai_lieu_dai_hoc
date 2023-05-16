Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Text
Imports System.Data.SqlClient
Imports Microsoft.Win32
Imports NPOI.SS.UserModel
Imports NPOI.XSSF.UserModel
Imports NPOI.HSSF.UserModel
Imports MainFrame

Public Class FrmPlanUpload

    Dim lblMessage As DevComponents.DotNetBar.LabelX

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub FileSystemWatcher1_Changed(sender As Object, e As IO.FileSystemEventArgs)

    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(sender As Object, e As EventArgs)

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub btnMO_Click(sender As Object, e As EventArgs) Handles btnMO.Click
        Dim openfile As New OpenFileDialog
        openfile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        openfile.Filter = "Execl文件|*.xlsx"
        openfile.Multiselect = False
        'openfile.ShowDialog()
        If openfile.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim fileName As String = openfile.FileName          '获得选择的文件路径
            txtMOFile.Text = fileName
            Dim extendedName As String = Path.GetExtension(fileName)      '获得文件扩展名
            Dim fileName1 As String = Path.GetFileName(fileName)         '获得文件名
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            'Dim i, j As Integer
            Try

                'Dim dataTable As DataTable = ExcelToDataTable("", fileName, True)
                Dim errorMsg As String = ""
                Dim dataTable As DataTable = ExcelUtils.ExportFromExcelByAs(fileName, 0, 0, 11, errorMsg)
                '获取sheet名，其中(0)(1)...(N): 按名称排列的表单元素 

                Try
                    If Not (CheckMOSave(DataTable)) Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    GetMesData.SetMessage(Me.lblMessage, "保存失败,请确认导入格式是否正确", False)
                    Exit Sub
                End Try
                Dim strSQL As New StringBuilder
                '定義數據庫聯接對象
                For i As Int16 = 1 To DataTable.Rows.Count() - 1 Step 1
                    Dim strAssignDate As String
                    Dim strQuestDate As String
                    Dim strLineName As String
                    Dim strMaterialNO As String
                    Dim strMOId As String
                    Dim MOQty As String
                    Dim ShipDate As String
                    Dim Remark As String
                    Dim Version As String
                    Dim Specification As String
                    strAssignDate = IIf(IsDBNull(DataTable.Rows(i)(1)), "", DataTable.Rows(i)(1).ToString.Trim.ToUpper)
                    strQuestDate = IIf(IsDBNull(DataTable.Rows(i)(2)), "", DataTable.Rows(i)(2).ToString.Trim.ToUpper)
                    strLineName = IIf(IsDBNull(DataTable.Rows(i)(3)), "", DataTable.Rows(i)(3).ToString.Trim.ToUpper)
                    strMaterialNO = IIf(IsDBNull(DataTable.Rows(i)(4)), "", DataTable.Rows(i)(4).ToString.Trim.ToUpper) 'PARTID
                    strMOId = IIf(IsDBNull(DataTable.Rows(i)(5)), "", DataTable.Rows(i)(5).ToString.Trim.ToUpper) 'MO
                    MOQty = IIf(IsDBNull(DataTable.Rows(i)(6)), "", DataTable.Rows(i)(6).ToString.Trim.ToUpper)
                    ShipDate = IIf(IsDBNull(DataTable.Rows(i)(7)), "", DataTable.Rows(i)(7).ToString.Trim.ToUpper)
                    Remark = IIf(IsDBNull(DataTable.Rows(i)(8)), "", DataTable.Rows(i)(8).ToString.Trim.ToUpper)
                    Version = IIf(IsDBNull(DataTable.Rows(i)(9)), "", DataTable.Rows(i)(9).ToString.Trim.ToUpper)
                    'Specification = IIf(IsDBNull(dataTable.Rows(i)(10)), "", dataTable.Rows(i)(10).ToString)
                    strSQL.AppendLine(" Begin IF NOT EXISTS ( SELECT a.moid FROM m_tiptopplanUp_t a WHERE a.moid ='" & strMOId & "' AND STATUS in('1','2'))")
                    strSQL.AppendLine(" INSERT INTO [dbo].[m_TiptopPlanUp_t] ")
                    strSQL.AppendLine(" ([Factoryid] ,[Profitcenter] ,[MOid]  ,[PartId] ,[Description] ,[Specification] ,[Quantity] ,[SQuantity],")
                    strSQL.AppendLine("[CustId] ,[CustName] ,[Remark] ,[DeptId] ,[LineId] ,[LeaderId] ,[ActualStartDate] ,[EstimatedDate] ,[ReleaseDay],")
                    strSQL.AppendLine("[InNumberDays] ,[BelongsDeptId] ,[StorageQuantity] ,[LocationId] ,[StandardWorkingHours] ,[UpdateUserId],")
                    strSQL.AppendLine("[UpdateTime] ,[CreateUserId] ,[CreateTime] ,[PunchCardTime] ,[CardEnd] ,[CardEndTime],")
                    strSQL.AppendLine("[PlanStartTime] ,[PlanEndTime] ,[PlanRework] ,[WorkingHours] ,[StatusFlag] ,[InWorkingHours] ,[PickWindow] ,[DeliveryTime],[Status]  )VALUES(")
                    strSQL.AppendLine("'" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "','" & strMOId & "','" & strMaterialNO & "','', '', '" & MOQty & "', '" & MOQty & "', ")
                    strSQL.AppendLine("'','','" & Remark & "','','" & strLineName & "','', NULL,NULL,NULL,")
                    strSQL.AppendLine("NULL,NULL,NULL,'',NULL,'',")
                    strSQL.AppendLine("NULL,'" & VbCommClass.VbCommClass.UseId & "','" & strAssignDate & "',NULL,'0',NULL,")
                    strSQL.AppendLine("NULL, NULL,'','0','0','0',NULL,NULL,'1'); End")
                Next
                If Not (String.IsNullOrEmpty(strSQL.ToString)) Then
                    Conn.ExecSql(strSQL.ToString())

                    GetMesData.SetMessage(Me.lblMessage, "上传工单成功!", True)
                End If

            Catch ex As Exception
                Throw ex

            Finally
                Conn.PubConnection.Close()
            End Try
        End If
    End Sub

    Private Function CheckMOSave(ByVal dt As DataTable) As Boolean
        Dim rtValue As Boolean = False
        Try

            If (dt.Rows.Count <= 0) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
            Else
                Dim Qty As String
                Dim strMaterialNO As String
                Dim strMOid As String
                Dim strLineName As String
                Dim strQTY As String
                Dim strDate As String
                For i = dt.Rows.Count() - 1 To 1 Step -1
                    'For i As Int16 = 0 (ds.Tables(0).Rows.Count() - 1)To 
                    strMaterialNO = IIf(IsDBNull(dt.Rows(i)(4)), "", dt.Rows(i)(4).ToString) 'PARTID
                    strMOid = IIf(IsDBNull(dt.Rows(i)(5)), "", dt.Rows(i)(5).ToString) 'MO
                    strLineName = IIf(IsDBNull(dt.Rows(i)(3)), "", dt.Rows(i)(3).ToString)
                    strDate = IIf(IsDBNull(dt.Rows(i)(1)), "", dt.Rows(i)(1).ToString)
                    strQTY = IIf(IsDBNull(dt.Rows(i)(6)), "", dt.Rows(i)(6).ToString)
                    If strMOid = "" And strMaterialNO = "" Then
                        dt.Rows.RemoveAt(i)
                        Continue For
                    End If
                    If (Not IsDate(strDate)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 2 & "行日期不正确", False)
                        Exit For
                    End If
                    If (String.IsNullOrEmpty(strMaterialNO)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 2 & "行料号不能为空", False)
                        Exit For
                    End If

                    If (String.IsNullOrEmpty(strMOid)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 2 & "行工单不能为空", False)
                        Exit For
                    End If

                    If (String.IsNullOrEmpty(strLineName)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 2 & "行产线不能为空", False)
                        Exit For
                    End If

                    If (String.IsNullOrEmpty(strQTY)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 2 & "行线别不能为空", False)
                        Exit For
                    End If
                    rtValue = True
                Next

            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查异常", False)
            rtValue = False
        Finally

        End Try

        Return rtValue
    End Function
    Private Function CheckChildSave(ByVal dt As DataTable) As Boolean
        Dim rtValue As Boolean = False
        Try

            If (dt.Rows.Count <= 0) Then
                rtValue = False
                GetMesData.SetMessage(Me.lblMessage, "没有任何保存数据", False)
            Else
                Dim Qty As String
                Dim strMaterialNO As String
                Dim strChildPart As String
                Dim strRate As String
                Dim strLine As String
                Dim strAssignDate As String
                For i = dt.Rows.Count() - 1 To 1 Step -1
                    'For i As Int16 = 0 To (dt.Rows.Count() - 1)
                    strAssignDate = IIf(IsDBNull(dt.Rows(i)(0)), "", dt.Rows(i)(0).ToString.Trim.ToUpper) '派工日期
                    strMaterialNO = IIf(IsDBNull(dt.Rows(i)(2)), "", dt.Rows(i)(2).ToString.Trim.ToUpper) 'PARTID
                    strChildPart = IIf(IsDBNull(dt.Rows(i)(3)), "", dt.Rows(i)(3).ToString.Trim.ToUpper) '子键
                    strRate = IIf(IsDBNull(dt.Rows(i)(5)), "", dt.Rows(i)(5).ToString.Trim.ToUpper)
                    strLine = IIf(IsDBNull(dt.Rows(i)(7)), "", dt.Rows(i)(7).ToString.Trim.ToUpper)
                    If strAssignDate = "" Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行派工日期不能为空", False)
                        Exit For
                    Else
                        If strAssignDate.Length < 6 Then
                            dt.Rows(i)(0) = DateTime.Now.Year.ToString + "/" + dt.Rows(i)(0)
                            If Not IsDate(dt.Rows(i)(0)) Then
                                rtValue = False
                                GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行派工日期不是日期格式", False)
                                Exit For
                            End If
                        End If

                    End If
                    If strMaterialNO = "" And strLine = "" Then
                        dt.Rows.RemoveAt(i)
                        Exit For
                    End If
                    If (String.IsNullOrEmpty(strMaterialNO)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行料号不能为空", False)
                        Exit For
                    End If

                    If (String.IsNullOrEmpty(strChildPart)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行子键不能为空", False)
                        Exit For
                    End If
                    If (String.IsNullOrEmpty(strLine)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行生产线体不能为空", False)
                        Exit For
                    End If
                    If (String.IsNullOrEmpty(strRate)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行配置不能为空", False)
                        Exit For
                    End If
                    If Not IsNumeric(strRate) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行配置不是数字", False)
                        Exit For
                    End If
                    If (String.IsNullOrEmpty(strLine)) Then
                        rtValue = False
                        GetMesData.SetMessage(Me.lblMessage, "第" & i + 1 & "行线别不能为空", False)
                        Exit For
                    End If
                    rtValue = True
                Next

            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查异常", False)
            rtValue = False
        End Try

        Return rtValue
    End Function
    Private Sub btnChildPart_Click(sender As Object, e As EventArgs) Handles btnChild.Click
        Dim openfile As New OpenFileDialog
        openfile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        openfile.Filter = "Execl文件|*.xlsx"
        openfile.Multiselect = False
        'openfile.ShowDialog()
        If openfile.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim fileName As String = openfile.FileName          '获得选择的文件路径
            txtFileName.Text = fileName
            Dim extendedName As String = Path.GetExtension(fileName)      '获得文件扩展名
            Dim fileName1 As String = Path.GetFileName(fileName)         '获得文件名
            'Dim i, j As Integer
            Dim strSQL As New StringBuilder
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            dgvProductionPlanItem.DataSource = Nothing
            Try
                ''Dim sConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fileName & "; Extended Properties=""Excel 12.0 Xml;HDR=YES;"""
                'Dim sConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fileName & "; Extended Properties=""Excel 12.0 Xml;HDR=NO;IMEX=1;"""
                'Dim oleDbConnection As OleDbConnection = New OleDbConnection(sConnectionString)
                'oleDbConnection.Open()
                ''获取excel表 
                'Dim dataTable As DataTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

                ''获取sheet名，其中(0)(1)...(N): 按名称排列的表单元素 
                'Dim tableName As String = dataTable.Rows(0)(2).ToString().Trim()
                'tableName = "[" & tableName.Replace(" ' ", " ") & "]"

                ''利用SQL语句从Excel文件里获取数据 
                'Dim query As String = "SELECT* FROM " & tableName
                'Dim dataset As DataSet = New DataSet()
                'Dim oleAdapter As OleDbDataAdapter = New OleDbDataAdapter(query, sConnectionString)
                'oleAdapter.Fill(dataset, "Rwb")
                Dim errorMsg As String = ""
                Dim dataTable As DataTable = ExcelUtils.ExportFromExcelByAs(fileName, 0, 0, 20, errorMsg)
                Try
                    If Not (CheckChildSave(dataTable)) Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    GetMesData.SetMessage(Me.lblMessage, "保存失败,请确认导入格式是否正确", False)
                    Exit Sub
                End Try
                '定義數據庫聯接對象
                Dim queryparts(dataTable.Rows.Count()) As String
                For i As Int16 = 1 To dataTable.Rows.Count() - 1
                    Dim strAssignDate As String
                    Dim strAssignLine As String
                    Dim strPartID As String
                    Dim strChildPart As String
                    Dim strRate As String
                    Dim strProductLine As String
                    Dim ShipDate As String
                    Dim ActualDate As String
                    Dim PlanEndDate As String
                    Dim Remark As String
                    Dim stdhour As String
                    Dim manpower As String
                    Dim productivity As String
                    Dim workhour As String
                    Dim tpqty As String
                    strAssignDate = IIf(IsDBNull(dataTable.Rows(i)(0)), "", dataTable.Rows(i)(0).ToString.Trim.ToUpper)
                    strAssignLine = IIf(IsDBNull(dataTable.Rows(i)(1)), "", dataTable.Rows(i)(1).ToString.Trim.ToUpper)
                    strPartID = IIf(IsDBNull(dataTable.Rows(i)(2)), "", dataTable.Rows(i)(2).ToString.Trim.ToUpper)
                    strChildPart = IIf(IsDBNull(dataTable.Rows(i)(3)), "", dataTable.Rows(i)(3).ToString.Trim.ToUpper.Trim.ToUpper)
                    If Array.IndexOf(queryparts, strPartID) < 0 Then
                        queryparts(i) = strPartID
                    End If

                    strRate = IIf(IsDBNull(dataTable.Rows(i)(5)), "", dataTable.Rows(i)(5).ToString.Trim.ToUpper)
                    strProductLine = IIf(IsDBNull(dataTable.Rows(i)(7)), "", dataTable.Rows(i)(7).ToString.Trim.ToUpper)
                    ShipDate = IIf(IsDBNull(dataTable.Rows(i)(11)), "", dataTable.Rows(i)(11).ToString.Trim.ToUpper)
                    ActualDate = IIf(IsDBNull(dataTable.Rows(i)(12)), "", dataTable.Rows(i)(12).ToString.Trim.ToUpper)
                    PlanEndDate = IIf(IsDBNull(dataTable.Rows(i)(13)), "", dataTable.Rows(i)(13).ToString.Trim.ToUpper)

                    stdhour = IIf(IsDBNull(dataTable.Rows(i)(6)), "", dataTable.Rows(i)(6).ToString.Trim.ToUpper)
                    manpower = IIf(IsDBNull(dataTable.Rows(i)(8)), "", dataTable.Rows(i)(8).ToString.Trim.ToUpper)
                    productivity = IIf(IsDBNull(dataTable.Rows(i)(9)), "", dataTable.Rows(i)(9).ToString.Trim.ToUpper)
                    workhour = IIf(IsDBNull(dataTable.Rows(i)(10)), "", dataTable.Rows(i)(10).ToString)
                    If workhour <> "" Then
                        Dim le As Int32 = workhour.Length
                        If le >= 10 Then
                            workhour = workhour.Substring(0, 9)
                        End If
                    End If
                    If stdhour <> "" Then
                        Dim le As Int32 = stdhour.Length
                        If le >= 10 Then
                            stdhour = stdhour.Substring(0, 9)
                        End If
                    End If
                    If ActualDate <> "" Then
                        Dim le As Int32 = ActualDate.Length
                        If le >= 10 Then
                            ActualDate = ActualDate.Substring(0, 9)
                        End If
                    End If

                    If ShipDate <> "" Then
                        Dim le As Int32 = ShipDate.Length
                        If le >= 10 Then
                            ShipDate = ShipDate.Substring(0, 9)
                        End If
                    End If

                    If PlanEndDate <> "" Then
                        Dim le As Int32 = PlanEndDate.Length
                        If le >= 10 Then
                            PlanEndDate = PlanEndDate.Substring(0, 9)
                        End If
                    End If
                    tpqty = IIf(IsDBNull(dataTable.Rows(i)(17)), "", dataTable.Rows(i)(17).ToString)

                    strSQL.AppendLine(" Begin IF  EXISTS ( SELECT a.componentid FROM m_tiptopplantempup_t a WHERE a.componentid ='" & strChildPart & "'and PartId = '" & strPartID & "' AND  AssignDate='" & strAssignDate & "')")
                    strSQL.AppendLine(" BEGIN   delete FROM  m_tiptopplantempup_t where componentid = '" & strChildPart & "' and PartId = '" & strPartID & "' AND AssignDate='" & strAssignDate & "'  END  ")
                    'strSQL.AppendLine(" delete FROM  m_tiptopplanitemup_t where PartId = '" & strChildPart & "'   END ")
                    strSQL.AppendLine(" INSERT INTO m_tiptopplantempup_t VALUES ('" & strAssignDate & "','" & strAssignLine & "','" & strPartID & "','" & strChildPart & "','" & strRate & "', N'" & strProductLine & "','" & PlanEndDate & "','1', '" & Remark & "','" & ShipDate & "', '" & ActualDate & "', ")
                    strSQL.AppendLine(" GETDATE(),'" & stdhour & "','" & manpower & "','" & productivity & "','" & workhour & "','" & tpqty & "') END;")
                Next
                If Not (String.IsNullOrEmpty(strSQL.ToString)) Then
                    Conn.ExecSql(strSQL.ToString())


                    Dim Sqlstr As String = "DECLARE @RTMSG VARCHAR(50) EXECUTE  [dbo].[GetTiptopPlanByUp]   @RTMSG OUTPUT  select @RTMSG "

                    Dim RecDr As SqlDataReader
                    RecDr = Conn.GetDataReader(Sqlstr)
                    Dim ReturnFlag As String = ""
                    If RecDr.HasRows Then
                        RecDr.Read()
                        ReturnFlag = RecDr.GetString(0)
                        If ReturnFlag <> "OK" Then
                            GetMesData.SetMessage(Me.lblMessage, ReturnFlag, False)
                        Else
                            GetMesData.SetMessage(Me.lblMessage, "上传子键成功!", True)
                        End If
                    End If
                    RecDr.Close()
                    'Dim strparts As String = "'" + String.Join("','", queryparts) + "'"
                    '    Dim sqlquery As String = "SELECT  row_number()OVER(ORDER BY b.PARENTMOID ) ROWNUM,b.CREATETIME AS  AssignDate   ,b.LINEID AS AssignLine   ,b.PARENTMOID AS MOID  ,b.MOID AS  ChildMOID  , b.PartID AS ComponentID  ,b.Quantity as ChildQTY  "
                    '    sqlquery += " FROM [dbo].[m_TiptopPlanItemUp_t] b ,m_TiptopPlanUp_t a WHERE a.MOID =b.PARENTMOID AND a.PartID IN(" + strparts + ")"
                    '    dataset = New DataSet
                    '    dataset = Conn.GetDataSet(sqlquery)
                    '    If dataset.Tables(0).Rows.Count > 0 Then
                    '        dgvProductionPlanItem.DataSource = dataset.Tables(0)
                    '    End If
                End If

            Catch ex As Exception
                GetMesData.SetMessage(Me.lblMessage, ex.Message, False)
            Finally
                Conn.PubConnection.Close()
            End Try
        End If

    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

End Class