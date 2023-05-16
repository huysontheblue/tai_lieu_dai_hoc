Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.IO
Imports System.Text
Imports Aspose.Cells
Imports System.Net


Public Class FrmStandardJobSchedulingAddMain

    Private FileFolderPath As String = "\\192.168.20.123\SFCShare\File\产品制程标准排配\"

    Public OP As String = ""

    ''' <summary>
    ''' 主键标识ID
    ''' </summary>
    ''' <remarks></remarks>
    Public ID As String = ""

    ''' <summary>
    ''' 取消
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#Region "版本列表"
    ''' <summary>
    ''' 版本列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function VersionArrayList() As List(Of String)
        Dim list = New List(Of String)
        list.Add("X")
        list.Add("A")
        list.Add("B")
        list.Add("C")
        list.Add("D")
        list.Add("E")
        list.Add("F")
        list.Add("G")
        list.Add("H")
        list.Add("I")
        list.Add("J")
        list.Add("K")
        list.Add("L")
        list.Add("M")
        list.Add("N")
        list.Add("O")
        list.Add("P")
        list.Add("Q")
        list.Add("R")
        list.Add("S")
        list.Add("T")
        list.Add("U")
        list.Add("V")
        list.Add("W")
        list.Add("Y")
        list.Add("Z")
        Return list
    End Function
#End Region

    ''' <summary>
    ''' 提交
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Try
            Dim sql = New StringBuilder()
            If IsValid() = False Then
                Exit Sub
            End If
            Dim FactNO = VbCommClass.VbCommClass.Factory
            Dim Profitcenter = VbCommClass.VbCommClass.profitcenter
            Dim PartID = txtPartID.Text.Trim().ToUpper()
            Dim Version = txtVersion.Text.Trim().ToUpper()
            Dim FilePath = ""
            If String.IsNullOrEmpty(lklblFilePath.Text.Trim()) = False Then
                FilePath = FileFolderPath + PartID + "\" + lklblFilePath.Text.Trim().Substring(lklblFilePath.Text.Trim().LastIndexOf("\") + 1)
                Dim by As Byte() = File.ReadAllBytes(lklblFilePath.Text.Trim())
                If Directory.Exists(FileFolderPath + PartID) = False Then
                    Directory.CreateDirectory(FileFolderPath + PartID)
                End If
                Dim bit = New Bitmap(lklblFilePath.Text.Trim())
                bit.SetResolution(96, 96)
                bit.Save(FilePath)
                'File.WriteAllBytes(FilePath, by)
            End If
            Dim ECN_No = txtECN_No.Text.Trim().ToUpper()
            Dim Remark = txtRemark.Text.Trim().Replace("'", "")

            If OP = "Add" Then
                Dim CreateBy = VbCommClass.VbCommClass.UseId
                Dim CreateName = VbCommClass.VbCommClass.UseName
                sql.AppendLine("insert into m_ProductStandardAllocation_t ")
                sql.AppendLine("(PartID,Version,FilePath,ECN_No,Remark,CreateBy,CreateName,CreateTime,FactNO,Profitcenter) ")
                sql.AppendLine(" values ('" & PartID & "','" & Version & "',N'" & FilePath & "','" & ECN_No & "',N'" & Remark & "','" & CreateBy & "',N'" & CreateName & "',getdate(),'" & FactNO & "','" & Profitcenter & "')")

                '机种有建流程卡
                If DbOperateUtils.GetDataTable("select PartID from m_RCardM_t where PartID='" & PartID & "'").Rows.Count > 0 Then
                    sql.AppendLine("insert into m_ProductStandardAllocationD_t " & vbCrLf &
               "select (select @@identity) as MainID,a.StationSQ,'R' as StationType, " & vbCrLf &
               "b.Stationname,a.WorkingHours,null as UndulationTime" & vbCrLf &
               ",iif(isnull(a.WorkingHours,0)=0 ,null,3600/a.WorkingHours) as output,replace(a.Equipment,N'手工','') Equipment" & vbCrLf &
               ",iif(charindex(N'手工',a.Equipment)>0,null,1)  as  Qty, 1 as BalancePerson,iif(isnull(a.WorkingHours,0)=0,null,a.WorkingHours/1) as BalanceHours,iif(isnull(a.WorkingHours,0)=0,null,3600/a.WorkingHours) as BalanceQty" & vbCrLf &
               ",null as Remark,getdate() as InTime,'" & CreateBy & "' as EmpNo,N'" & CreateName & "' as EmpName" & vbCrLf &
               "from dbo.m_RCardD_t a" & vbCrLf &
               "join dbo.m_Rstation_t b  on b.Stationid=a.StationID" & vbCrLf &
               "where a.PartID='" & PartID & "' order by StationSQ")
                Else '抓取PLMWeb服务
                    ExportInDataFromPLM(sql)
                End If
            ElseIf OP = "Edit" Then
                Dim ModifyBy = VbCommClass.VbCommClass.UseId
                Dim ModifyName = VbCommClass.VbCommClass.UseName
                sql.AppendLine("update m_ProductStandardAllocation_t ")
                sql.AppendLine("set PartID='" & PartID & "'")
                sql.AppendLine(" ,Version='" & Version & "'")
                sql.AppendLine(" ,ECN_No='" & ECN_No & "'")
                sql.AppendLine(" ,Remark=N'" & Remark & "'")
                sql.AppendLine(" ,ModifyBy='" & ModifyBy & "'")
                sql.AppendLine(" ,ModifyName=N'" & ModifyName & "'")
                sql.AppendLine(" ,ModifyTime=getdate()")
                If String.IsNullOrEmpty(lklblFilePath.Text.Trim()) = False Then
                    sql.AppendLine(" ,FilePath=N'" & FilePath & "'")
                End If
                sql.AppendLine(" where ID=" + Me.ID)
            End If
            DbOperateUtils.ExecSQL(sql.ToString())
            MessageUtils.ShowInformation("提交成功!")
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageUtils.ShowError("出现异常:" & vbCrLf & "" + ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 验证数据的有效性
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValid() As Boolean
        Dim yy = True

        Dim aa = False
        For Each Str As String In VersionArrayList()
            If txtVersion.Text.Trim().ToUpper().Contains(Str) = True Then
                aa = True
                Exit For
            End If
        Next

        Dim sql = "select TAvcPart,PAvcPart from dbo.m_PartContrast_t" & vbCrLf &
        "where TAvcPart='" & txtPartID.Text.Trim() & "' or PAvcPart='" & txtPartID.Text.Trim() & "'"
        If String.IsNullOrEmpty(txtPartID.Text.Trim()) Then
            MessageUtils.ShowError("请填写机种编号!")
            yy = False
        ElseIf DbOperateUtils.GetDataTable(sql).Rows.Count = 0 Then
            MessageUtils.ShowError("料件基础表中没有这个机种:" + txtPartID.Text.Trim())
            yy = False
        ElseIf String.IsNullOrEmpty(txtVersion.Text.Trim()) Then
            MessageUtils.ShowError("请填写版本号!")
            yy = False
        ElseIf String.IsNullOrEmpty(txtECN_No.Text.Trim()) Then
            MessageUtils.ShowError("请填写ECN编号!")
            yy = False
        ElseIf DbOperateUtils.GetDataTable("select * from m_ProductStandardAllocation_t" & vbCrLf &
        "where PartID='" & txtPartID.Text.Trim() & "' and Version='" & txtVersion.Text.Trim() & "'").Rows.Count > 0 And OP = "Add" Then
            MessageUtils.ShowError("已经存在一笔机种:" + txtPartID.Text.Trim() + ",版本:" + txtVersion.Text.Trim() + "的数据!")
            yy = False
        ElseIf aa = False Then
            MessageUtils.ShowError("非法版本号:" + txtVersion.Text.Trim())
            yy = False
        End If
        
        Return yy
    End Function

    ''' <summary>
    ''' 上传附件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnUploadFile_Click(sender As Object, e As EventArgs) Handles btnUploadFile.Click
        Dim ofd As OpenFileDialog = New OpenFileDialog()
        ofd.Filter = "png|*.png|jpg|*.jpg|bmp|*.bmp|jpeg|*.jpeg|gif|*.gif|tiff|*.tiff"
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            lklblFilePath.Text = ofd.FileName
        End If
    End Sub

    Private Version As String = ""

    Dim wb As WebClient = New WebClient()

    Dim ws As com.luxshare_ict.plmNew.webserviceasmx = New com.luxshare_ict.plmNew.webserviceasmx()

    Private Sub FrmStandardJobSchedulingAddMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If OP = "Edit" Then
            Me.Text = "修改"
            Dim dt = DbOperateUtils.GetDataTable("select * from m_ProductStandardAllocation_t where id=" & Me.ID & "")
            If dt.Rows.Count > 0 Then
                txtPartID.Text = dt.Rows(0)("PartID").ToString()
                txtVersion.Text = dt.Rows(0)("Version").ToString()
                Me.Version = dt.Rows(0)("Version").ToString()
                txtECN_No.Text = dt.Rows(0)("ECN_No").ToString()
                txtRemark.Text = dt.Rows(0)("Remark").ToString()
            End If
        ElseIf OP = "Add" Then
            txtECN_No.Text = "NEW"
        End If
        'Dim sql = New StringBuilder()
        'ExportInDataFromPLM(sql)
    End Sub

    ''' <summary>
    ''' 新增标准排配从PLM同步工站数据
    ''' </summary>
    ''' <param name="sql">sql语句</param>
    ''' <remarks></remarks>
    Private Sub ExportInDataFromPLM(ByRef sql As StringBuilder)
        Dim FileName = Application.StartupPath + "\" + Date.Now.ToString("yyyyMMddHHmmss") + ".xls"
        Dim aa As Integer = 0
        Dim EmpNo = VbCommClass.VbCommClass.UseId
        Dim EmpName = VbCommClass.VbCommClass.UseName
        Try
            Dim dtPLM = ws.lx_getDocument(txtPartID.Text.Trim(), "C065836", "D:\")
            If dtPLM.Rows.Count > 0 Then
                Dim url = dtPLM.Rows(0)("url").ToString()
                wb.DownloadFile(url, FileName)
                Dim book = New Workbook(FileName)
                Dim sheet = book.Worksheets(0)
                sql.AppendLine("declare @MainID int; select @MainID=@@identity")
                For i As Integer = 4 To sheet.Cells.Rows.Count - 1
                    Dim OrderBy = sheet.Cells(i, 0).Value
                    If OrderBy Is Nothing Then
                        Continue For
                    End If
                    If Integer.TryParse(OrderBy.ToString().Replace("0-", ""), aa) = False Then '只记录有效的工站数据
                        Continue For
                    End If
                    Dim StationType = IIf(OrderBy.ToString().Contains("0-"), "U", "R")
                    Dim StationName = sheet.Cells(i, 1).Value
                    Dim StationID = ""
                    Dim Equiment = sheet.Cells(i, 3).Value
                    If Not Equiment Is Nothing Then
                        If Equiment.ToString() = "/" Then
                            Equiment = ""
                        End If
                    End If
                    'Dim sqll = "select top 1 Stationid from m_Rstation_t where StationName = N'" & StationName & "'"
                    'Dim dt = DbOperateUtils.GetDataTable(sqll)
                    'If dt.Rows.Count > 0 Then
                    '    StationID = dt.Rows(0)(0).ToString()
                    'End If
                    Dim Qty = IIf(String.IsNullOrEmpty(Equiment), "NULL", "1")
                    sql.AppendLine("insert into m_ProductStandardAllocationD_t")
                    sql.AppendLine("(MainID,OrderBy,StationType,StationName,Equiment,Qty,InTime,EmpNo,EmpName)")
                    sql.AppendLine("values (@MainID,'" & OrderBy & "','" & StationType & "',N'" & StationName & "',N'" & Equiment & "'," & Qty & ",getdate(),'" & EmpNo & "',N'" & EmpName & "')")
                Next
            End If
        Catch ex As Exception
            MessageUtils.ShowError("PLM导入工站数据出现异常:" & vbCrLf & "" + ex.Message)
        Finally
            If File.Exists(FileName) Then
                File.Delete(FileName)
            End If
        End Try
    End Sub

   
    ''' <summary>
    ''' 验证版本号
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtVersion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVersion.KeyPress
        If e.KeyChar = Chr(13) Then
            If String.IsNullOrEmpty(txtVersion.Text.Trim()) = False Then
                Dim yy = False
                For Each Str As String In VersionArrayList()
                    If txtVersion.Text.Trim().ToUpper().Contains(Str) = True Then
                        yy = True
                        If txtVersion.Text.Trim().ToUpper().Contains("X") = True Then
                            txtECN_No.Text = "NEW"
                        Else
                            Dim sql = "select 'ECN'+substring(cast(datepart(year,getdate())as varchar),3,2)+ substring('0000000000',1,len('0000000000')-len(cast(isnull(max(cast(replace(ECN_No,'ECN'+substring(cast(datepart(year,getdate())as varchar),3,2),'')as int)),0)+1 as varchar)))" & vbCrLf &
                                "+cast(isnull(max(cast(replace(ECN_No,'ECN'+substring(cast(datepart(year,getdate())as varchar),3,2),'')as int)),0)+1 as varchar)" & vbCrLf &
                                "from dbo.m_ProductStandardAllocation_t where ECN_No<>'NEW'"
                            Dim dt = DbOperateUtils.GetDataTable(sql)
                            If OP = "Add" Then
                                txtECN_No.Text = dt.Rows(0)(0).ToString()
                            ElseIf OP = "Edit" Then
                                If Me.Version <> txtVersion.Text.Trim().ToUpper() And txtVersion.Text.Trim().ToUpper().Contains("X") = False Then
                                    txtECN_No.Text = dt.Rows(0)(0).ToString()
                                End If
                            End If
                        End If
                        Exit For
                    End If
                Next
                If yy = False Then
                    MessageUtils.ShowError("非法版本" + txtVersion.Text)
                End If
            Else
                txtECN_No.Text = "NEW"
            End If
        End If
    End Sub

    Private Sub txtPartID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPartID.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim sql = "select TypeDest from m_PartContrast_t where TAvcPart='" & txtPartID.Text.Trim() & "'"
            Dim dt = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                txtRemark.Text = dt.Rows(0)(0).ToString()
            End If
        End If
    End Sub
End Class