Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports MainFrame.SysCheckData
Imports MainFrame

Public Class FrmMouldPic
    Public MouldID As String  '模号
    Private DrawingPath As String = "\\192.168.20.123\SFCShare\MoudlePicture"  '上传图片、报告文件路径

#Region "属性"
    Private _moldDrawingName As String  '模具图名
    Public Property MoidDrawingName() As String
        Get
            Return _moldDrawingName
        End Get
        Set(ByVal value As String)
            _moldDrawingName = value
        End Set
    End Property

    Private _ProductDrawingName As String  '产品图名
    Public Property ProductDrawingName() As String
        Get
            Return _ProductDrawingName
        End Get
        Set(ByVal value As String)
            _ProductDrawingName = value
        End Set
    End Property

    Private _FilePathName As String  '报告文件名
    Public Property FilePathName() As String
        Get
            Return _FilePathName
        End Get
        Set(ByVal value As String)
            _FilePathName = value
        End Set
    End Property
#End Region

#Region "初始化"
    Private Sub FrmMouldPic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMouldID.Text = MouldID
        txtMouldID_TextChanged(Nothing, Nothing)
        LoadData()
    End Sub
#End Region

#Region "事件"
    '上传模具图
    Private Sub btnMold_Click(sender As Object, e As EventArgs) Handles btnMold.Click
        btnMold.Enabled = False

        Dim ofd As OpenFileDialog = New OpenFileDialog()
        ofd.Title = "请选择要上传的模具图"
        ofd.Filter = "Files(*.png,*.jpg,*.dwg)|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.dwg"
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtMoldPath.Text = ofd.FileName
            MoidDrawingName = ofd.SafeFileName
            Cursor.Current = Cursors.Default
        End If

        btnMold.Enabled = True
    End Sub

    '上传产品图
    Private Sub btnProduct_Click(sender As Object, e As EventArgs) Handles btnProduct.Click
        btnProduct.Enabled = False

        Dim ofd As OpenFileDialog = New OpenFileDialog()
        ofd.Title = "请选择要上传的产品图"
        ofd.Filter = "Files(*.png,*.jpg)|*.png;*.jpg;*.jpeg;*.bmp;*.gif"
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtProductPath.Text = ofd.FileName
            Me.ProductDrawingName = ofd.SafeFileName
            Cursor.Current = Cursors.Default
        End If

        btnProduct.Enabled = True
    End Sub

    '上传报告文件
    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        btnFile.Enabled = False

        Dim result As DialogResult = OpenFileDialog3.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            txtFIlePath.Text = OpenFileDialog3.FileName
            FilePathName = OpenFileDialog3.SafeFileName
            Cursor.Current = Cursors.Default
        End If

        btnFile.Enabled = True
    End Sub

    'DatagridView双击 打开文件
    Private Sub dgvPic_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPic.CellDoubleClick
        Dim strURL As String
        Try
            If dgvPic.Columns(e.ColumnIndex).Name = "MoldDrawingp" Then
                strURL = dgvPic.CurrentRow.Cells("MoldDrawing2").Value.ToString
            ElseIf dgvPic.Columns(e.ColumnIndex).Name = "ProductDrawingp" Then
                strURL = dgvPic.CurrentRow.Cells("ProductDrawing2").Value.ToString
            ElseIf dgvPic.Columns(e.ColumnIndex).Name = "FIlePathp" Then
                strURL = dgvPic.CurrentRow.Cells("FIlePath2").Value.ToString
            End If

            If Not String.IsNullOrEmpty(strURL) Then
                System.Diagnostics.Process.Start(strURL)
            End If
        Catch ex As Exception

        End Try
    End Sub

    '模号文本框改变事件
    Private Sub txtMouldID_TextChanged(sender As Object, e As EventArgs) Handles txtMouldID.TextChanged
        Try
            Dim mould As String = txtMouldID.Text.Trim
            If String.IsNullOrEmpty(mould) Then Exit Sub

            Dim strSQL As String = "SELECT [MouldID],[ParaDesc],[MapID],[NewMouldID] ,[Type] ,[Cavitys] ,[Strips] ,[Tails] ,[Slots] ,[Parts] ,[Location] ,[AssetsID] ," &
                                   " [Storage], [LimitTimes], [AlertTimes], [UsedTimes]," &
                                   " case UseStatus when 0 then N'0-闲置中' when 1 then N'1-使用中' when 2 then N'2-维修中' end UseStatus FROM m_Mould_t where MouldID='" & mould & "'"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                txtParaDesc.Text = dt.Rows(0)("ParaDesc").ToString
                txtApplyPart.Text = dt.Rows(0)("Parts").ToString
                txtAssetsID.Text = dt.Rows(0)("AssetsID").ToString
                txtCavitys.Text = dt.Rows(0)("Cavitys").ToString
                txtLocation.Text = dt.Rows(0)("Location").ToString
                txtMapID.Text = dt.Rows(0)("MapID").ToString
                txtNewMouldID.Text = dt.Rows(0)("NewMouldID").ToString
                txtSlots.Text = dt.Rows(0)("Slots").ToString
                txtStrips.Text = dt.Rows(0)("Strips").ToString
                txtTails.Text = dt.Rows(0)("Tails").ToString
                txtType.Text = dt.Rows(0)("Type").ToString
                txtStorage.Text = dt.Rows(0)("Storage").ToString
                txtUseStatus.Text = dt.Rows(0)("UseStatus").ToString
                LoadData()
            Else
                txtParaDesc.Text = ""
                txtApplyPart.Text = ""
                txtAssetsID.Text = ""
                txtCavitys.Text = ""
                txtLocation.Text = ""
                txtMapID.Text = ""
                txtNewMouldID.Text = ""
                txtSlots.Text = ""
                txtStrips.Text = ""
                txtTails.Text = ""
                txtType.Text = ""
                txtStorage.Text = ""
                txtUseStatus.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            If DataCheck() = False Then Exit Sub
            If MessageUtils.ShowConfirm("你确定要保存模具图信息吗?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then Exit Sub

            If SaveData() = False Then
                Return
            End If

            MessageUtils.ShowInformation("保存成功")
            LoadData()

            txtMoldPath.Clear()
            txtProductPath.Clear()
            txtFIlePath.Clear()
            Me.MoidDrawingName = ""
            Me.ProductDrawingName = ""
            Me.FilePathName = ""
        Catch ex As Exception

        End Try
    End Sub


    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub
#End Region

#Region "方法"
    '数据加载
    Private Sub LoadData()
        Dim strSQL As String = "SELECT MouldID,MoldDrawing,case when  MoldDrawing<>'' and MoldDrawing is not null then N'双击查看' else ''  end  MoldDrawingp," &
                              " ProductDrawing,case when  ProductDrawing <>'' and ProductDrawing is not null then N'双击查看' else ''  end  ProductDrawingp," &
                              " FIlePath,case when  FIlePath<>'' and FIlePath is not null then N'双击查看' else ''  end  FIlePathp,ReMark," &
                              " m.UserID+'/'+u .UserName UserID,m.Intime FROM m_MouldPic_t m inner join m_Users_t u on m.UserID=u.UserID " &
                              " where MouldID='" & txtMouldID.Text.Trim & "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        dgvPic.DataSource = dt
    End Sub

    '判断路径下文件是否存在
    Private Function DataCheck() As Boolean
        If (Not File.Exists(txtMoldPath.Text.Trim)) AndAlso txtMoldPath.Text.Trim <> "" Then
            MessageUtils.ShowWarning("路径下模具图不存在!")
            Return False
        End If
        If (Not File.Exists(txtProductPath.Text.Trim)) AndAlso txtProductPath.Text.Trim <> "" Then
            MessageUtils.ShowWarning("路径下产品图不存在!")
            Return False
        End If
        If (Not File.Exists(txtFIlePath.Text.Trim)) AndAlso txtFIlePath.Text.Trim <> "" Then
            MessageUtils.ShowWarning("路径下报告文件不存在!")
            Return False
        End If
        If txtMoldPath.Text.Trim = "" AndAlso txtProductPath.Text.Trim = "" AndAlso txtFIlePath.Text.Trim = "" AndAlso txtReMark.Text.Trim = "" Then
            Return False
        End If

        Return True
    End Function

    '保存数据
    Private Function SaveData() As Boolean
        Try
            Dim strSQL As String
            Dim userId As String = VbCommClass.VbCommClass.UseId
            Dim serverMoldFile As String = ""
            Dim ServerProductFile As String = ""
            Dim ServerFilePath As String = ""

            Dim IsExist As Boolean  '模号是否存在图档库
            Dim dt As DataTable = DbOperateUtils.GetDataTable(" select MoldDrawing,ProductDrawing,FIlePath  from m_MouldPic_t where MouldId='" & txtMouldID.Text.Trim & "'")
            If dt.Rows.Count > 0 Then
                serverMoldFile = dt.Rows(0)(0).ToString
                ServerProductFile = dt.Rows(0)(1).ToString
                ServerFilePath = dt.Rows(0)(2).ToString
                IsExist = True
            Else
                IsExist = False
            End If

            Dim destFilePath As String = Path.Combine(DrawingPath, MouldID)
            If Directory.Exists(destFilePath) = False Then
                Directory.CreateDirectory(destFilePath)
            End If

            If Not String.IsNullOrEmpty(Me.MoidDrawingName) Then
                'If IsExist AndAlso File.Exists(serverMoldFile) Then  '如果原来存在 则删除  重新上传新的
                '    File.Delete(serverMoldFile)
                'End If
                serverMoldFile = Path.Combine(destFilePath, Me.MoidDrawingName)
                File.Copy(txtMoldPath.Text.Trim, serverMoldFile, True)   '覆盖
            End If
            If Not String.IsNullOrEmpty(Me.ProductDrawingName) Then
                ServerProductFile = Path.Combine(destFilePath, Me.ProductDrawingName)
                File.Copy(txtProductPath.Text.Trim, ServerProductFile, True)
            End If
            If Not String.IsNullOrEmpty(FilePathName) Then
                ServerFilePath = Path.Combine(destFilePath, FilePathName)
                File.Copy(txtFIlePath.Text.Trim, ServerFilePath, True)
            End If

            If Not IsExist Then
                strSQL = "INSERT INTO m_MouldPic_t (MouldID,MoldDrawing,ProductDrawing,ReMark,UserID,Intime,FIlePath)  VALUES " &
                         " ( '{0}',N'{1}',N'{2}',N'{3}','{4}',getdate() ,N'{5}') "
                strSQL = String.Format(strSQL, txtMouldID.Text.Trim, serverMoldFile, ServerProductFile, txtReMark.Text.Trim, userId, ServerFilePath)
            Else
                strSQL = "UPDATE m_MouldPic_t SET MoldDrawing=N'{0}',ProductDrawing=N'{1}',ReMark=N'{2}',UserID='{3}',FIlePath=N'{5}',Intime=getdate() WHERE MouldID='{4}'"
                strSQL = String.Format(strSQL, serverMoldFile, ServerProductFile, txtReMark.Text.Trim, userId, txtMouldID.Text.Trim, ServerFilePath)
            End If

            DbOperateUtils.ExecSQL(strSQL)
            Return True
        Catch ex As Exception

        End Try
    End Function
#End Region

End Class