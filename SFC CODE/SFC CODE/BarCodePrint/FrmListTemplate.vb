Imports MainFrame
Imports System.Windows.Forms
Imports System.Text
Imports System.IO

Public Class FrmListTemplate
    Private IsUpload As Boolean = False ''是否有上传
    Private FileNameStr As String = "" ''上传的文件名
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal partid As String, ByVal packitem As String, ByVal packid As String)
        Dim dtTemp As DataTable
        InitializeComponent()
        Try
            Dim factory As String = VbCommClass.VbCommClass.Factory
            Dim profit As String = VbCommClass.VbCommClass.profitcenter
            Dim strSQL As String = "SELECT PFormatID  FROM m_PartPack_t where Partid ='" + partid + "' AND Usey ='Y' AND Packitem ='" + packitem + "' and Packid ='" + packid + "' "
            dtTemp = DbOperateUtils.GetDataTable(strSQL)
            Me.lblPart.Text = partid
            Me.lblPForm.Text = dtTemp.Rows(0)(0).ToString
            dtTemp = Nothing
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
            Dim SqlStr As New StringBuilder
            '第一次默认模板
            SqlStr.Append("IF not exists(SELECT 1 from m_PartTemplatePath_t where PFormatID ='" + Me.lblPForm.Text + "')" & _
 "INSERT INTO m_PartTemplatePath_t(Factory ,Profitcenter ,PFormatID ,TemplatePath ,Usey ,Version ,CreateUserID ,CreatTime ,remark) " & _
 "SELECT '" + factory + "','" + profit + "',PFormatID,TemplatePath ,'Y','1',userid ,intime ,Descript  from M_SnMFormat_t where PFormatID ='" + Me.lblPForm.Text + "' ")
            Conn.ExecSql(SqlStr.ToString)
            BindData()
        Catch ex As Exception
            dtTemp = Nothing
        End Try
    End Sub
    Private Sub FrmListTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        OpenFileDialog.Filter = "(*.btw)|*.btw"
        btnUpload.Enabled = False
        Dim result As DialogResult = OpenFileDialog.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtFilename1.Text = OpenFileDialog.FileName
            ' Open the format.
            IsUpload = True
            Try
                FileNameStr = OpenFileDialog.SafeFileNames(0).ToString

            Catch comException As System.Runtime.InteropServices.COMException
                MessageUtils.ShowError(String.Format("Unable to open format: {0}" & Constants.vbLf & "Reason: {1}", OpenFileDialog.FileName, comException.Message))
            End Try
            btnOpen.Enabled = True
        End If
        btnUpload.Enabled = True
    End Sub

    Private Sub ToolSave_Click(sender As Object, e As EventArgs) Handles ToolSave.Click


        If FileNameStr = "" Then
            MessageUtils.ShowError("请先上传文件！")
            Exit Sub
        End If

        Dim value As String
        Dim NewFile As String
        Dim bakname As String = ""
        Dim destPath As String = ""
        Dim factory As String = VbCommClass.VbCommClass.Factory
        Dim profit As String = VbCommClass.VbCommClass.profitcenter
        Dim dtTemp As DataTable = New DataTable
        Dim strSQL As String = " SELECT TemplatePath  FROM m_PartTemplatePath_t where Usey ='Y' AND PFormatID ='" + lblPForm.Text + "'"
        Try
            dtTemp = DbOperateUtils.GetDataTable(strSQL)
            If dtTemp.Rows.Count > 0 Then
                Dim useypath As String = dtTemp.Rows(0)("TemplatePath").ToString
                '备份原文件
                Dim oldfilename As String = Path.GetFileName(VbCommClass.VbCommClass.PrintDataModle & "\\" & useypath)
                bakname = oldfilename.Split(".")(0) & "_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".btw"
                destPath = Path.Combine(VbCommClass.VbCommClass.PrintDataModle & "\\" & lblPForm.Text, bakname)
                If File.Exists(VbCommClass.VbCommClass.PrintDataModle & "\\" & useypath) Then
                    Dim fileInfo As FileInfo = New FileInfo(VbCommClass.VbCommClass.PrintDataModle & "\\" & useypath)
                    fileInfo.MoveTo(destPath)
                End If
            End If
            '上传新文件
            value = lblPForm.Text & "\" & FileNameStr
            NewFile = VbCommClass.VbCommClass.PrintDataModle & value
            If Me.txtFilename1.Text <> "" Then
                If System.IO.Directory.Exists(VbCommClass.VbCommClass.PrintDataModle & "\" & lblPForm.Text) = False Then
                    Directory.CreateDirectory(VbCommClass.VbCommClass.PrintDataModle & "\" & lblPForm.Text)
                End If
                File.Copy(Me.txtFilename1.Text, NewFile, True)
            End If
            strSQL = " SELECT  ISNULL(MAX(Version ),'0')+1 Ver FROM m_PartTemplatePath_t WHERE PFormatID  ='" + lblPForm.Text + "'"
            dtTemp = Nothing
            dtTemp = DbOperateUtils.GetDataTable(strSQL)
            Dim version As String = dtTemp.Rows(0)("Ver").ToString
            Dim temppath As String = "\" & value
            Dim bakpath As String = "\" & lblPForm.Text & "\" & bakname
            Dim SqlStr As StringBuilder = New StringBuilder
            Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
            SqlStr.Append(" UPDATE m_PartTemplatePath_t SET USEY='N',TemplatePath=N'" & bakpath & "',UpdateUserid='" & VbCommClass.VbCommClass.UseId & "',UpdateTime=GETDATE()  where PFormatID='" & lblPForm.Text & "' and USEY='Y'")
            SqlStr.Append(" INSERT INTO m_PartTemplatePath_t(Factory ,Profitcenter  ,PFormatID ,TemplatePath ,Usey  ,Version ,CreateUserID,remark) VALUES (" & _
              " '" & factory & "','" & profit & "','" & lblPForm.Text & "',N'" & temppath & "','Y'," & version & ",'" & VbCommClass.VbCommClass.UseId & "',N'" & txtRemark.Text.Trim & "')")
            SqlStr.Append("  UPDATE M_SnMFormat_t SET TemplatePath=N'" & value & "',OLDPATH=N'" & destPath & "'WHERE PFormatID='" & lblPForm.Text & "'")
            Conn.ExecSql(SqlStr.ToString)
            ToolSave.Enabled = False
            BindData()
            Clear()
            MessageUtils.ShowInformation("上传成功！")
        Catch exception As Exception
            MessageUtils.ShowError("上传文件异常!")
        End Try
    End Sub

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        Clear()
        ToolSave.Enabled = True
    End Sub
    Private Sub Clear()
        Me.txtFilename1.Text = ""
        Me.txtRemark.Text = ""
        Me.FileNameStr = ""
        IsUpload = False
    End Sub

    Private Sub ToolUnDo_Click(sender As Object, e As EventArgs) Handles ToolUnDo.Click
        Clear()
    End Sub

    Private Sub ToolRefresh_Click(sender As Object, e As EventArgs) Handles ToolRefresh.Click
        Clear()
        BindData()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub
    Private Sub BindData()
        Dim strSQL As String = "SELECT  Version , TemplatePath ,CreateUserID ,CreatTime ,Usey,remark  FROM m_PartTemplatePath_t where  PFormatID ='" + lblPForm.Text + "'  ORDER BY Usey DESC "
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            dgvListTemp.Rows.Clear()
            DReader = Conn.GetDataReader(strSQL)
            While DReader.Read()
                dgvListTemp.Rows.Add(DReader.Item("Version").ToString, DReader.Item("TemplatePath").ToString, _
                              DReader.Item("CreateUserID").ToString, DReader.Item("CreatTime").ToString, _
            DReader.Item("Usey").ToString, DReader.Item("remark").ToString)
            End While
            If dgvListTemp.Rows.Count > 0 Then
                dgvListTemp.CurrentCell = dgvListTemp.Item(0, 0)
            End If
            DReader.Close()
            Conn = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgvListTemp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListTemp.CellContentClick
        If e.ColumnIndex = 1 Then
            Dim FilePath As String = ""
            Dim filename As String = dgvListTemp.CurrentRow.Cells(1).Value.ToString
            FilePath = VbCommClass.VbCommClass.PrintDataModle & "\\" & filename
            Dim strlocal As String = "C:\MesExport"
            If System.IO.Directory.Exists(strlocal) = False Then
                Directory.CreateDirectory(strlocal)
            End If
            '下载为本地文件
            Dim destPath As String = Path.Combine(strlocal, Path.GetFileName(FilePath))
            Try
                If File.Exists(FilePath) = False Then
                    MessageUtils.ShowError("找不到模板（" & FilePath & "）")
                    Exit Sub
                End If
                File.Copy(FilePath, destPath, True)

                Dim Process As New System.Diagnostics.Process
                Process.StartInfo.FileName = destPath
                Process.StartInfo.Verb = "Open"
                Process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                Process.Start()
            Catch ex As Exception
                MessageUtils.ShowError("名为【" + destPath + "】的文件打开出错！")
            End Try
        End If
    End Sub

    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        If Not dgvListTemp.CurrentRow Is Nothing Then
            Dim dtTemp As DataTable

            Dim version As String = dgvListTemp.CurrentRow.Cells(0).Value.ToString
            Dim template As String = dgvListTemp.CurrentRow.Cells(1).Value.ToString
            Dim usey As String = dgvListTemp.CurrentRow.Cells(4).Value.ToString
            If usey = "Y" Then
                MessageUtils.ShowError("此模板已经生效,无需恢复！")
                Exit Sub
            End If
            Try
                Dim SqlStr As StringBuilder = New StringBuilder
                Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

                Dim strSQL As String = " SELECT TemplatePath,Version  FROM m_PartTemplatePath_t where Usey ='Y' AND PFormatID ='" + lblPForm.Text + "'"

                dtTemp = DbOperateUtils.GetDataTable(strSQL)
                Dim oldtemplate As String = ""
                If dtTemp.Rows.Count > 0 Then
                    Dim oldver As String = dtTemp.Rows(0)("Version").ToString
                    oldtemplate = VbCommClass.VbCommClass.PrintDataModle & "\\" & dtTemp.Rows(0)("TemplatePath").ToString
                    SqlStr.Append(" UPDATE m_PartTemplatePath_t SET USEY='N' ,UpdateUserid='" & VbCommClass.VbCommClass.UseId & "',UpdateTime=GETDATE()  where PFormatID='" & lblPForm.Text & "' and version='" & oldver & "'")
                End If

                SqlStr.Append(" UPDATE m_PartTemplatePath_t SET USEY='Y' ,UpdateUserid='" & VbCommClass.VbCommClass.UseId & "',UpdateTime=GETDATE()  where PFormatID='" & lblPForm.Text & "' and version='" & version & "'")
                SqlStr.Append(" UPDATE M_SnMFormat_t SET TemplatePath=N'" & template & "',OLDPATH=N'" & oldtemplate & "'WHERE PFormatID='" & lblPForm.Text & "'")
                Conn.ExecSql(SqlStr.ToString)
                BindData()
                MessageUtils.ShowInformation("恢复版本" & version & "成功!")
            Catch exception As Exception
                MessageUtils.ShowError("恢复版本" & version & "异常!")
            End Try
        Else
            MessageUtils.ShowError("请选中行！")
        End If
    End Sub
End Class