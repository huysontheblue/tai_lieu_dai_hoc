Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports Microsoft.Office.Interop
Imports MainFrame
Public Class FrmPartSetOBA
#Region "字段,属性"
    Private actionType As String
    Private Enum FormBtnonType
        Normal
        Add
        Edit
    End Enum
    Private Enum PartOBAGridView
        Partid
        Obacode
        Obaname
        Uesy
        UserName
        InTime
    End Enum

#End Region
#Region "事件"
    Private Sub FrmPartSetOBA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
        BindComboxStatus(Me.cbOba)
        SetControl()
    End Sub
    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Me.actionType = FormBtnonType.Add.ToString
        SetControl()
    End Sub

    Private Sub toolEdit_Click(sender As Object, e As EventArgs) Handles toolEdit.Click
        If Me.dgvPartOba.RowCount < 1 OrElse Me.dgvPartOba.CurrentCell Is Nothing Then
            Exit Sub
        End If
        txtPartId.Text = Me.dgvPartOba.CurrentRow.Cells(PartOBAGridView.Partid).Value.ToString
        cbOba.SelectedValue = Me.dgvPartOba.CurrentRow.Cells(PartOBAGridView.Obacode).Value.ToString
        Me.actionType = FormBtnonType.Edit.ToString
        SetControl()
    End Sub

    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        If Me.dgvPartOba.RowCount < 1 OrElse Me.dgvPartOba.CurrentCell Is Nothing Then
            Exit Sub
        End If

        Dim confirmMsg As String = "确定要作废吗？"
        If (MessageUtils.ShowConfirm(confirmMsg, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            If SetAbandon() = True Then
                MessageBox.Show("作废成功!")
                GetData()
            End If

        End If
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        If String.IsNullOrEmpty(Me.txtPartId.Text) Then
            Me.lbMsg.Text = "请输入料号!"
            Exit Sub
        End If

        If ckIsExistsPartId(txtPartId.Text) = False Then
            Me.lbMsg.Text = "当前料号不存在!"
            Exit Sub
        End If
        If CheckData() = False Then
            Me.lbMsg.Text = "当前料号对应的OBA项已存在,请勿重复!"
            Exit Sub
        End If
        SavaData()
        Me.actionType = FormBtnonType.Normal.ToString
        SetControl()
        GetData()
    End Sub

    Private Sub toolBack_Click(sender As Object, e As EventArgs) Handles toolBack.Click
        Me.actionType = FormBtnonType.Normal.ToString
        SetControl()
    End Sub

    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click
        GetData()
    End Sub

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub dgvPartOba_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvPartOba.CellPainting
        If e.ColumnIndex = 0 AndAlso e.RowIndex <> -1 Then
            '合并单元格
            DrawCell(e)
        End If
    End Sub
#End Region

#Region "函数"
    '保存
    Private Sub SavaData()
        Try
            Dim o_strSql As New StringBuilder
            Dim UserID As String = VbCommClass.VbCommClass.UseId
            Dim partid As String
            Dim obacode As String
            If Me.actionType = FormBtnonType.Add.ToString Then

                o_strSql.Append(" insert into m_PartSetOBA_t(partid,obacode,usey,userid,intime)")
                o_strSql.Append(" values('" & txtPartId.Text & "','" & cbOba.SelectedValue.ToString & "','Y','" & UserID & "',getdate())")

            Else
                partid = Me.dgvPartOba.CurrentRow.Cells(PartOBAGridView.Partid).Value.ToString
                obacode = Me.dgvPartOba.CurrentRow.Cells(PartOBAGridView.Obacode).Value.ToString
                o_strSql.Append(" UPDATE m_PartSetOBA_t SET partid='" & txtPartId.Text & "',obacode='" & cbOba.SelectedValue.ToString & "',userid='" & UserID & "',intime=GETDATE() WHERE  partid='" & partid & "' and  obacode='" & obacode & "'")

            End If
            DbOperateUtils.ExecSQL(o_strSql.ToString)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPartSetOBA", "SaveData()", "sys")
        End Try
    End Sub
    '查找
    Private Sub GetData()
        Try
            Dim o_strSql As New StringBuilder
            o_strSql.Append("select a.partid,a.obacode,b.obaname,a.usey,a.userid,a.intime from m_PartSetOBA_t a  ")
            o_strSql.Append(" left join m_BasicOBA_t b on b.obacode=a.obacode ")
            If Not String.IsNullOrEmpty(txtPartId.Text) Then
                o_strSql.Append(" and a.partid='" & Me.txtPartId.Text & "'")
            End If
            If Not String.IsNullOrEmpty(Me.cbOba.Text) Then
                o_strSql.Append(" and a.obacode = '" & Me.cbOba.SelectedValue.ToString & "'")
            End If
            Dim dt As DataTable = DbOperateUtils.GetDataTable(o_strSql.ToString)
            dgvPartOba.DataSource = dt
            ToolCount.Text = dt.Rows.Count
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmPartSetOBA", "GetData()", "sys")
        End Try
    End Sub
    '作废
    Private Function SetAbandon() As Boolean
        Try
            Dim strSql As String
            Dim partid As String
            Dim obacode As String
            Dim b As Boolean = False
            partid = Me.dgvPartOba.CurrentRow.Cells(PartOBAGridView.Partid).Value.ToString
            obacode = Me.dgvPartOba.CurrentRow.Cells(PartOBAGridView.Obacode).Value.ToString
            strSql = "update m_PartSetOBA_t set usey='N' where partid='" & partid & "' and obacode='" & obacode & "'"
            DbOperateUtils.ExecSQL(strSql)
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmBasicOba", "SaveData()", "sys")
        End Try
    End Function

    '检查料号是否存在
    Private Function ckIsExistsPartId(ByVal partId As String) As Boolean
        Try
            Dim strSql As String
            Dim b As Boolean = True

            strSql = "select TAvcPart from m_PartContrast_t(nolock) where TAvcPart='" & partId & "'"
            Dim i As Integer = DbOperateUtils.GetRowsCount(strSql)
            If i < 1 Then
                b = False
            End If
            Return b
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmBasicOba", "checkPartId()", "sys")
        End Try
    End Function
    '验证数据
    Private Function CheckData() As Boolean
        Try
            Dim strSql As String
            Dim b As Boolean = True
            Dim partid As String
            Dim obacode As String
            strSql = "select obacode from m_PartSetOBA_t where 1=1 "
            If Me.actionType = "Edit" Then
                partid = Me.dgvPartOba.CurrentRow.Cells(PartOBAGridView.Partid).Value.ToString
                obacode = Me.dgvPartOba.CurrentRow.Cells(PartOBAGridView.Obacode).Value.ToString
                strSql = strSql & "  and partid<>'" & partid & "' and  obacode<>'" & obacode & "'"
            Else
                strSql = strSql & "and partid='" & txtPartId.Text & "'  and obacode='" & cbOba.SelectedValue.ToString & "'"
            End If
            Dim i As Integer = DbOperateUtils.GetRowsCount(strSql)
            If i > 0 Then
                b = False
            End If
            Return b
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmBasicOba", "CheckData()", "sys")
        End Try
    End Function
    '设置控件权限
    Private Sub SetControl()
        If Me.actionType = FormBtnonType.Add.ToString Then
            txtPartId.ReadOnly = False
            toolAdd.Enabled = False
            toolEdit.Enabled = False
            toolAbandon.Enabled = False
            toolBack.Enabled = True
            toolSave.Enabled = True
        ElseIf actionType = FormBtnonType.Edit.ToString Then
            txtPartId.ReadOnly = True
            toolAdd.Enabled = False
            toolAbandon.Enabled = False
            toolEdit.Enabled = False
            toolBack.Enabled = True
            toolSave.Enabled = True
        Else
            txtPartId.ReadOnly = False
            toolAdd.Enabled = True
            toolEdit.Enabled = True
            toolBack.Enabled = False
            toolSave.Enabled = False
            toolAbandon.Enabled = True
            clearText()
        End If
    End Sub

    '清除数据
    Private Sub clearText()
        txtPartId.Text = ""
        cbOba.SelectedIndex = -1
        lbMsg.Text = ""
    End Sub

    ''' <summary>
    ''' OBA
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Private Shared Sub BindComboxStatus(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = "SELECT obacode as value,obacode+'-'+obaname as  text FROM m_BasicOBA_t WHERE usey='Y' order by obacode asc "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Dim dr As DataRow = dt.NewRow

        dr("text") = ""
        dr("value") = ""
        dt.Rows.InsertAt(dr, 0)
        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = "text"
        ColComboBox.ValueMember = "value"

    End Sub


    ''' <summary>
    ''' 画单元格
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DrawCell(ByVal e As DataGridViewCellPaintingEventArgs)
        If e.CellStyle.Alignment = DataGridViewContentAlignment.NotSet Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        Dim gridBrush As Brush = New SolidBrush(Me.dgvPartOba.GridColor)
        Dim backBrush As SolidBrush = New SolidBrush(e.CellStyle.BackColor)
        Dim fontBrush As SolidBrush = New SolidBrush(e.CellStyle.ForeColor)
        Dim cellwidth As Integer = 0
        '上面相同的行数
        Dim UpRows As Integer = 0
        '下面相同的行数
        Dim DownRows As Integer = 0
        '总行数
        Dim count As Integer = 0
        Dim i As Integer = 0
        If e.RowIndex <> -1 Then
            cellwidth = e.CellBounds.Width
            Dim gridLinePen As Pen = New Pen(gridBrush)
            Dim curValue As String = IIf(e.Value Is Nothing, "", e.Value.ToString.Trim)

            Dim curSelected = IIf(Me.dgvPartOba.CurrentRow.Cells(e.ColumnIndex).Value Is Nothing, "", Me.dgvPartOba.CurrentRow.Cells(e.ColumnIndex).Value.ToString.Trim())
            If Not String.IsNullOrEmpty(curValue) Then
                '获取下面的行数
                For i = e.RowIndex To Me.dgvPartOba.Rows.Count - 1
                    If Me.dgvPartOba.Rows(i).Cells(e.ColumnIndex).Value.Equals(curValue) Then
                        DownRows = DownRows + 1
                        If e.RowIndex <> i Then
                            cellwidth = IIf(cellwidth < Me.dgvPartOba.Rows(i).Cells(e.ColumnIndex).Size.Width, cellwidth, Me.dgvPartOba.Rows(i).Cells(e.ColumnIndex).Size.Width)
                        End If
                    Else
                        Exit For
                    End If
                Next
                '获取上面的行数
                Dim ir As Integer = e.RowIndex
                While ir >= 0
                    If Me.dgvPartOba.Rows(ir).Cells(e.ColumnIndex).Value.Equals(curValue) Then
                        UpRows = UpRows + 1
                        If e.RowIndex <> ir Then
                            cellwidth = IIf(cellwidth < Me.dgvPartOba.Rows(ir).Cells(e.ColumnIndex).Size.Width, cellwidth, Me.dgvPartOba.Rows(ir).Cells(e.ColumnIndex).Size.Width)
                        End If
                    Else
                        Exit While
                    End If
                    ir = ir - 1
                End While

                count = DownRows + UpRows - 1
                If count < 2 Then
                    Return
                End If
            End If

            If Me.dgvPartOba.Rows(e.RowIndex).Selected = True Then
                backBrush.Color = e.CellStyle.SelectionBackColor
                fontBrush.Color = e.CellStyle.SelectionForeColor
            End If
            '以背景色填充
            e.Graphics.FillRectangle(backBrush, e.CellBounds)

            '画字符串
            PaintingFont(e, cellwidth, UpRows, DownRows, count)
            If DownRows = 1 Then
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                count = 0
            End If
            ''画右边线
            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' 画字符串
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="cellwidth"></param>
    ''' <param name="UpRows">上面的行数</param>
    ''' <param name="DownRows">下面的行数</param>
    ''' <param name="count">总行数</param>
    ''' <remarks></remarks>
    Private Sub PaintingFont(ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs, ByVal cellwidth As Integer, ByVal UpRows As Integer, ByVal DownRows As Integer, ByVal count As Integer)

        Dim fontBrush As SolidBrush = New SolidBrush(e.CellStyle.ForeColor)
        Dim fontheight As Integer = CInt(e.Graphics.MeasureString(e.Value.ToString, e.CellStyle.Font).Height)
        Dim fontwidth As Integer = CInt(e.Graphics.MeasureString(e.Value.ToString, e.CellStyle.Font).Width)
        Dim cellheight As Integer = e.CellBounds.Height

        If e.CellStyle.Alignment = DataGridViewContentAlignment.BottomCenter Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y + cellheight * DownRows - fontheight)
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.BottomLeft Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y + cellheight * DownRows - fontheight)
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2)
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2)
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2)
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.TopCenter Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1))
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.TopLeft Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1))
        ElseIf e.CellStyle.Alignment = DataGridViewContentAlignment.TopRight Then
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1))
        Else
            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2)
        End If
    End Sub

#End Region
 
    
  
End Class