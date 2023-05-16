Imports System.Windows.Forms
Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Drawing
Imports System.Text
Imports System.IO


Public Class FrmMainTainHandleDGNewD

    Public FrmStatus As Boolean = True
    Public Rcode As String
    Public ppid As String
    Public itemid As String
    Private _PicDirector As String = "\\" & VbCommClass.VbCommClass.SopFilePath.Split(CChar("\"))(2) & "\AssyTsPicture" & "\" & VbCommClass.VbCommClass.Factory
    '宽度
    Private _PicWidth As Integer = CInt(271)
    '高度
    Private _PicHeight As Integer = CInt(250)


    '初期化
    Private Sub FrmMainTainHandleDGNewD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CobCodeR.DropDownStyle = ComboBoxStyle.DropDownList
        CobHandle.DropDownStyle = ComboBoxStyle.DropDownList

        '不良原因
        MainTainCommon.BindComboxNGBig(CobCodeR, Rcode)
        '加載維修方式
        MainTainCommon.BindComboxNGOperate(CobHandle, CobCodeR.Text.Split("-")(0).Trim)

        CobCodeR.SelectedIndex = -1
        CobHandle.SelectedIndex = -1
        TxtIdea.Text = String.Empty

        SetFormValue()

        If FrmStatus = False Then
            btnConfirm.Enabled = False
            LblMSg2.Text = "已维修完成的数据，当前界面只读！"
            For Each btn As Control In Me.Controls
                If TypeOf btn Is System.Windows.Forms.Button Then
                    btn.Enabled = False
                End If
            Next
        End If
        btnClose.Enabled = True
    End Sub

    '关闭
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '确认
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Try
            If CheckDataIsRight() = False Then Exit Sub

            Dim result As String = "G"
            If InStr(CobHandle.Text, "报废") > 0 Then
                result = "E"
            End If
            '图片地址
            Dim picPath As String = String.Empty
            Dim picFileName As String = String.Empty
            Dim OrdIndex As String = String.Empty

            '图片目录
            Dim picDirector As String = String.Empty
            picDirector = _PicDirector & "\" & String.Format("{0}_{1}_{2}", ppid, itemid, Rcode)

            If System.IO.Directory.Exists(picDirector) = False Then
                Directory.CreateDirectory(picDirector)
            End If

            Dim sb As New StringBuilder()

            Dim strSQL As String
            strSQL = String.Format(" update m_AssyTsDetail_t set Rcodeid='{0}', Stateid='{1}' ,solution = '{2}' ,Suggestion = N'{3}'  " &
                      " where Ppid='{4}' and Itemid = '{5}' and codeid = '{6}'", CobCodeR.Text.Split("-")(0), result, CobHandle.Text.Split("-")(0),
                      TxtIdea.Text.Trim, ppid, itemid, Rcode)

            sb.Append(strSQL)

            strSQL = String.Format(" delete m_AssyTsPicture_t where Ppid='{0}' and Itemid = '{1}' and codeid = '{1}'", ppid, itemid, Rcode)
            '先删除数据
            sb.Append(strSQL)
            '示意图
            If Not Me.btnUpdateOne.Tag.ToString = "NoIamge" Then
                picFileName = Now.ToString("yyyyMMddHHmmssffff") & ".jpg"
                picPath = picDirector & "\" & picFileName
                OrdIndex = "1"
                Dim picOne As New System.Drawing.Bitmap(PictureBoxOne.Image, _PicWidth, _PicHeight)
                picOne.SetResolution(96, 96)
                picOne.Save(picPath)

                strSQL = String.Format("INSERT INTO m_AssyTsPicture_t (Ppid ,Itemid ,Codeid ,OrdIndex ,PicPath ,PicDesc ,Userid ,Intime) VALUES " &
                                 "('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate())", ppid, itemid, Rcode, OrdIndex, picPath, "", VbCommClass.VbCommClass.UseId)

                sb.Append(strSQL)
            End If

            If Not Me.btnUpdateTwo.Tag.ToString = "NoIamge" Then
                picFileName = Now.ToString("yyyyMMddHHmmssffff") & ".jpg"
                picPath = picDirector & "\" & picFileName
                OrdIndex = "2"

                Dim picTwo As New System.Drawing.Bitmap(PictureBoxTwo.Image, _PicWidth, _PicHeight)
                picTwo.SetResolution(96, 96)
                picTwo.Save(picPath)

                strSQL = String.Format("INSERT INTO m_AssyTsPicture_t (Ppid ,Itemid ,Codeid ,OrdIndex ,PicPath ,PicDesc ,Userid ,Intime) VALUES " &
                                 "('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate())", ppid, itemid, Rcode, OrdIndex, picPath, "", VbCommClass.VbCommClass.UseId)

                sb.Append(strSQL)
            End If

            If Not Me.btnUpdateThree.Tag.ToString = "NoIamge" Then
                picFileName = Now.ToString("yyyyMMddHHmmssffff") & ".jpg"
                picPath = picDirector & "\" & picFileName
                OrdIndex = "3"

                Dim picThree As New System.Drawing.Bitmap(PictureBoxThree.Image, _PicWidth, _PicHeight)
                picThree.SetResolution(96, 96)
                picThree.Save(picPath)

                strSQL = String.Format("INSERT INTO m_AssyTsPicture_t (Ppid ,Itemid ,Codeid ,OrdIndex ,PicPath ,PicDesc ,Userid ,Intime) VALUES " &
                       "('{0}','{1}','{2}','{3}','{4}','{5}','{6}',getdate())", ppid, itemid, Rcode, OrdIndex, picPath, "", VbCommClass.VbCommClass.UseId)

                sb.Append(strSQL)
            End If

            DbOperateUtils.ExecSQL(sb.ToString)

            LblMSg2.Text = "维修成功！"
            Me.Close()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "btnConfirm", "btnConfirm_Click", "WIP")
        End Try
    End Sub

    '檢驗保存數據是否正確
    Private Function CheckDataIsRight() As Boolean

        If Me.CobCodeR.Text = "" Then
            Me.CobHandle.Focus()
            Me.LblMSg2.Text = "不良原因不能為空..."
            Return False
        End If
        If CobHandle.Text = "" Then
            Me.CobHandle.Focus()
            Me.LblMSg2.Text = "不良品维修的处理方法不能为空..."
            Return False
        End If
        'If Me.CobResult.Text = "" Then
        '    Me.CobResult.Focus()
        '    Me.LblMSg2.Text = "維修結果不能為空..."
        '    Return False
        'End If
        'If InStr(CobHandle.Text, "报废") > 0 And CobResult.SelectedIndex <> 0 Then
        '    Me.CobResult.Focus()
        '    Me.LblMSg2.Text = "当前产品不允许选择维修OK，只允许作废处理..."
        '    Return False
        'End If

        If String.IsNullOrEmpty(TxtIdea.Text.Trim()) = True Then
            Me.TxtIdea.Focus()
            Me.LblMSg2.Text = "改善对策描述不能为空..."
            Return False
        End If
        Return True
    End Function

    '不良现象
    Private Sub CobCodeR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CobCodeR.SelectedIndexChanged
        'LblMSg.Text = "提示信息"
        'If CobcodeType.Text = "" Then Exit Sub
        '不良现象
        MainTainCommon.BindComboxNGOperate(CobHandle, CobCodeR.Text.Split("-")(0).Trim)
    End Sub

    '更新One
    Private Sub btnUpdateOne_Click(sender As Object, e As EventArgs) Handles btnUpdateOne.Click
        UpdatePicture(PictureBoxOne, btnUpdateOne)
    End Sub

    '更新Two
    Private Sub btnUpdateTwo_Click(sender As Object, e As EventArgs) Handles btnUpdateTwo.Click
        UpdatePicture(PictureBoxTwo, btnUpdateTwo)
    End Sub

    '更新Three
    Private Sub btnUpdateThree_Click(sender As Object, e As EventArgs) Handles btnUpdateThree.Click
        UpdatePicture(PictureBoxThree, btnUpdateThree)
    End Sub

    '清除
    Private Sub btnClearOne_Click(sender As Object, e As EventArgs) Handles btnClearOne.Click
        ClearPicture(Me.PictureBoxOne, Me.btnUpdateOne)
    End Sub

    Private Sub btnClearTwo_Click(sender As Object, e As EventArgs) Handles btnClearTwo.Click
        ClearPicture(Me.PictureBoxTwo, Me.btnClearTwo)
    End Sub

    Private Sub btnClearThree_Click(sender As Object, e As EventArgs) Handles btnClearThree.Click
        ClearPicture(Me.PictureBoxThree, Me.btnClearThree)
    End Sub

    '更新图片
    Private Function UpdatePicture(pic As System.Windows.Forms.PictureBox, but As System.Windows.Forms.Button) As Boolean
        Dim frmPicCut As New FrmPictureCut()

        If frmPicCut.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not frmPicCut.picArea.Image Is Nothing Then
                Dim map As Bitmap = New Bitmap(frmPicCut.picArea.Image)
                '通过比例换算裁剪图片保证裁剪结果的正确
                map = frmPicCut.KiCut(map, CInt(frmPicCut.m_Rect.X * map.Width / frmPicCut.picArea.Width), CInt(frmPicCut.m_Rect.Y * map.Height / frmPicCut.picArea.Height), CInt(map.Width * frmPicCut.m_Rect.Width / frmPicCut.picArea.Width), CInt(map.Height * frmPicCut.m_Rect.Height / frmPicCut.picArea.Height))
                If Not map Is Nothing Then
                    pic.Image = Image.FromHbitmap(map.GetHbitmap())
                    but.Tag = "HaveImage"
                End If
                map.Dispose()
            End If
        End If
    End Function

    ''' <summary>
    ''' 清除图片
    ''' </summary>
    ''' <param name="pic"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ClearPicture(pic As System.Windows.Forms.PictureBox, but As System.Windows.Forms.Button) As Boolean
        CType(pic, PictureBox).Image = Global.MainTainModule.My.Resources.Resources.noimage
        CType(but, System.Windows.Forms.Button).Tag = "NoIamge"
        Return True
    End Function

    Private Sub SetFormValue()
        Dim strSQL As String =
             " SELECT ATSD.Rcodeid+ '-' + isnull(coder.rccname,'''') Rcodeid , " &
             " ATSD.Solution + '-' + isnull(mts.MstyleName,'''') Solution, " &
             " ATSD.Suggestion, isnull(PICPATH,'') as PICPATH FROM m_AssyTsDetail_t ATSD " &
             " LEFT JOIN m_AssyTsPicture_t ATSP " &
             " ON ATSD.Ppid = ATSP.Ppid " &
             " AND ATSD.Itemid = ATSP.Itemid " &
             " AND ATSD.CODEID = ATSP.CODEID" &
             " LEFT JOIN m_CodeR_t coder" &
             " ON ATSD.Rcodeid=coder.rCodeID " &
             " LEFT JOIN  m_MainTainStyle_t mts on atsd.Solution = mts.mstyleid  " &
             " WHERE ATSD.PPID = '{0}' AND ATSD.Itemid  = '{1}' AND ATSD.Codeid = '{2}'"
        strSQL = String.Format(strSQL, ppid, itemid, Rcode)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count > 0) Then
            CobCodeR.Text = dt.Rows(0)(0).ToString
            CobHandle.Text = dt.Rows(0)(1).ToString
            TxtIdea.Text = dt.Rows(0)(2).ToString
            If dt.Rows.Count = 1 Then
                SetPicture(PictureBoxOne, dt.Rows(0)(3).ToString)
            ElseIf dt.Rows.Count = 2 Then
                SetPicture(PictureBoxOne, dt.Rows(0)(3).ToString)
                SetPicture(PictureBoxTwo, dt.Rows(1)(3).ToString)
            ElseIf dt.Rows.Count = 3 Then
                SetPicture(PictureBoxOne, dt.Rows(0)(3).ToString)
                SetPicture(PictureBoxTwo, dt.Rows(1)(3).ToString)
                SetPicture(PictureBoxThree, dt.Rows(2)(3).ToString)
            End If
        End If
    End Sub
    Private Sub SetPicture(pic As System.Windows.Forms.PictureBox, path As String)
        If path <> "" Then
            pic.Image = Image.FromFile(path.ToString)
            pic.ImageLocation = path
            pic.Tag = "HaveImage"
        End If
    End Sub


End Class