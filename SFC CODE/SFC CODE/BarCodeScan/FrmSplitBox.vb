Imports MainFrame.SysCheckData
Imports MainFrame

''' <summary>
''' 创建者：田玉琳
''' 创建日期：2019/01/03
''' 说明：
''' 箱拆分
''' 目的是把旧箱数据重新放在新箱中
''' 可以把旧箱数量全部拆分，拆成空箱会删除箱表和条码记录表
''' 可以把旧箱数据拆多个箱，装满一箱，要换新箱再拆。
''' 拆分记录日志表：m_CartonSplit_t（拆分 类型1，替换类型为2）
''' </summary>
''' <remarks></remarks>
Public Class FrmSplitBox

    Dim oldcartonMoid As String
    Dim newcartonMoid As String
    Dim PackingQuantity As String
    '工单信息数据集 
    Private dtGenerationInfo As DataTable = Nothing

    '初期化
    Private Sub FrmSplitBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtOldCarton.Focus()
    End Sub

    '旧箱扫描
    Private Sub txtOldCarton_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOldCarton.KeyPress
        If e.KeyChar = Chr(13) Then
            OldCartonIDScanHandle() ''掃入旧箱條碼
        End If
    End Sub

    '新箱扫描
    Private Sub txtNewCarton_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNewCarton.KeyPress
        If e.KeyChar = Chr(13) Then
            NewCartonIDScanHandle() ''掃入新箱條碼
        End If
    End Sub

    '条码扫描
    Private Sub txtPpid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPpid.KeyPress
        If e.KeyChar = Chr(13) Then
            ppidScanHandle() ''掃入产品條碼
        End If
    End Sub

    '旧箱扫描处理
    Private Sub OldCartonIDScanHandle()
        Try
            SetMessage("PASS", txtOldCarton.Text)
            gridView1.Rows.Clear()

            If CheckOldCartonScan() = False Then
                Exit Sub
            End If

            SetGridViewData(txtOldCarton.Text.Trim, gridView1)
            txtNewCarton.Focus()

        Catch ex As Exception
            Dim errMsg As Exception = New Exception(String.Format("OldCartonId:{0}#{1}", txtOldCarton.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "SysPrint.FrmSplitBox", "OldCartonIDScanHandle", "sys")
            MessageUtils.ShowInformation("有异常发生，请联系管理员!" + errMsg.ToString)
            Exit Sub
        End Try
    End Sub

    '新箱扫描处理
    Private Sub NewCartonIDScanHandle()
        Try
            SetMessage("PASS", txtNewCarton.Text)
            gridView2.Rows.Clear()

            If CheckNewCartonScan() = False Then
                Exit Sub
            End If

            SetGridViewData(txtNewCarton.Text.Trim, gridView2)

            txtPpid.Focus()
        Catch ex As Exception
            Dim errMsg As Exception = New Exception(String.Format("NewCartonId:{0}#{1}", txtOldCarton.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "SysPrint.FrmSplitBox", "NewCartonIDScanHandle", "sys")
            MessageUtils.ShowInformation("有异常发生，请联系管理员!" + errMsg.ToString)
            Exit Sub
        End Try
    End Sub

    '产品扫描处理
    Private Sub ppidScanHandle()
        Try
            SetMessage("PASS", txtPpid.Text)
            If CheckPPidScan() = False Then
                Exit Sub
            End If

            '数据库数据保存
            SaveScanPpid()

         
            If lblNewQtyShould.Text = lblNewQtyFact.Text Then
                txtNewCarton.Focus()
                txtPpid.Text = ""
                txtNewCarton.Text = ""
                If (MessageUtils.ShowConfirm("是否再进行分箱扫描？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                    txtNewCarton.Focus()
                    Exit Sub
                Else
                    SetMessage("PASS", String.Format("请在旧箱上写入剩余数量{0}!", lblOldQty.Text))
                End If
            End If
            txtPpid.Text = ""
            txtPpid.Focus()

        Catch ex As Exception
            Dim errMsg As Exception = New Exception(String.Format("ppid:{0}#{1}", txtOldCarton.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "SysPrint.FrmSplitBox", "ppidScanHandle", "sys")
            MessageUtils.ShowInformation("有异常发生，请联系管理员!" + errMsg.ToString)
            Exit Sub
        End Try
    End Sub

    '保存扫描记录
    Private Sub SaveScanPpid()
        Dim strSQL As String = "declare @RTVALUE varchar(1),@RTMSG varchar(150) EXEC [m_NV_SplitCartonScan_P] " &
               "'{0}','{1}','{2}','{3}','{4}',{5} ,@RTVALUE output,@RTMSG output; select @RTVALUE ,isnull(@RTMSG,'') "
        strSQL = String.Format(strSQL, txtOldCarton.Text.Trim, txtNewCarton.Text.Trim, txtPpid.Text.Trim, Environment.MachineName, VbCommClass.VbCommClass.UseId, Convert.ToInt32(IIf(lblNewQtyShould.Text.Trim = "", "0", lblNewQtyShould.Text.Trim)))

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Select Case dt.Rows(0)(0).ToString()
                Case "0" Or "1"
                    Dim ErrorStr As String = dt.Rows(0)(1).ToString()
                    SetMessage("FAIL", ErrorStr)
                    Me.txtPpid.Clear()
                    Exit Sub
                Case Else
                    SetMessage("PASS", "产品条码" + Trim(txtPpid.Text) + "扫描成功！")
                    '界面移动
                    SetGridViewDataRemove()
            End Select
        End If
    End Sub

    '旧箱扫描检查 
    Private Function CheckOldCartonScan()

        If (txtOldCarton.Text.Trim = "") Then
            txtOldCarton.Focus()
            SetMessage("FAIL", "旧箱扫描不允许为空!")
            Return False
        End If

        Dim strSQL As String = "SELECT DISTINCT moid,ppid,PackingQuantity FROM m_Cartonsn_t LEFT JOIN m_carton_t ON m_Carton_t.Cartonid = m_Cartonsn_t.Cartonid  WHERE m_Cartonsn_t.Cartonid = '{0}'"
        strSQL = String.Format(strSQL, txtOldCarton.Text.Trim)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count = 0) Then
            txtOldCarton.Focus()
            txtOldCarton.Text = ""
            SetMessage("FAIL", "旧箱扫描没有产品数据!")
            Return False
        Else
            lblOldQty.Text = dt.Rows.Count
            oldcartonMoid = dt.Rows(0)(0).ToString
            PackingQuantity = dt.Rows(0)(2).ToString
        End If

        strSQL = "SELECT 1 FROM m_WhsOutD_t WHERE Cartonid= '{0}'"
        strSQL = String.Format(strSQL, txtOldCarton.Text.Trim)
        dt = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count > 0) Then
            txtOldCarton.Focus()
            txtOldCarton.Text = ""
            SetMessage("FAIL", "旧外箱條碼已出库,請重新扫描!")
            Return False
        End If

        Return True
    End Function

    '新箱扫描检查 
    Private Function CheckNewCartonScan()
        Dim newCartonID As String = txtNewCarton.Text.Trim

        If (newCartonID = "") Then
            txtNewCarton.Focus()
            SetMessage("FAIL", "新箱扫描不允许为空!")
            Return False
        End If

        If (newCartonID = txtOldCarton.Text) Then
            txtNewCarton.Text = ""
            txtNewCarton.Focus()
            SetMessage("FAIL", "扫描新箱不能和旧箱相同!")
            Return False
        End If

        Dim strSQL As String = "    SELECT moid,Cartonid,Cartonqty,PackingQuantity,CartonStatus  " &
                              "     FROM dbo.m_Carton_t " &
                              "     WHERE Cartonid='{0}' "
        strSQL = String.Format(strSQL, newCartonID)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        '只对系统打印的外箱操作
        If (dt.Rows.Count = 0) Then
            '增加生成样式规则判断
            dt = GetNewCarton(newCartonID)
            If dt.Rows.Count <= 0 Then
                SetMessage("FAIL", "新箱不是系统打印外箱,请检查!")
                Return False
            End If

            newcartonMoid = dt.Rows(0)("moid").ToString
            lblNewQtyShould.Text = dt.Rows(0)("qty").ToString
            lblNewQtyFact.Text = "0"
        Else
            newcartonMoid = dt.Rows(0)("moid").ToString
            lblNewQtyShould.Text = dt.Rows(0)("PackingQuantity").ToString
            lblNewQtyFact.Text = dt.Rows(0)("Cartonqty").ToString
        End If

        If lblNewQtyShould.Text = lblNewQtyFact.Text Then
            txtNewCarton.Focus()
            txtNewCarton.Text = ""
            SetMessage("FAIL", "新箱扫描已经装满了，请重新输入新箱!")
            Return False
        End If

        If PackingQuantity = lblNewQtyShould.Text Then
            txtNewCarton.Focus()
            txtNewCarton.Text = ""
            SetMessage("FAIL", "新箱应装数量和旧箱相同，请重新输入新箱!")
            Return False
        End If

        If Convert.ToInt16(lblOldQty.Text) < Convert.ToInt16(lblNewQtyShould.Text) Then
            txtNewCarton.Focus()
            txtNewCarton.Text = ""
            SetMessage("FAIL", "新箱应装数量大于旧箱应装数量，请重新输入新箱!")
            Return False
        End If

        '已扫过的外箱就要判断其工单是否一致
        If (newcartonMoid <> "") AndAlso (oldcartonMoid <> newcartonMoid) Then
            SetMessage("FAIL", "新箱工单不等于旧箱工单，请重新输入新箱条码!")
            Return False
        End If

        Return True
    End Function

    Private Function GetProNo(strProNo As String)
        Dim retvals As String = ""
        Dim strProNoList As String() = strProNo.Split("-")
        If strProNoList.Length > 2 Then
            retvals = strProNo.Substring(0, strProNo.Length - strProNoList(strProNoList.Length - 1).Length - strProNoList(strProNoList.Length - 2).Length - 2)
        Else
            retvals = strProNoList(0)
        End If
        Return retvals
    End Function

    Private Function GetNewCarton(ByVal newCartonID As String) As DataTable
        Dim strSQL As String = "SELECT TOP 1 qty = ISNULL(m_MOPackingLevel.qty,0),moid FROM m_MOPackingLevel WHERE SBarCode = '{0}' "
        strSQL = String.Format(strSQL, newCartonID)
        Return DbOperateUtils.GetDataTable(strSQL)
    End Function

    '检查扫描产品条码
    Private Function CheckPPidScan()
        If (txtPpid.Text.Trim = "") Then
            txtPpid.Focus()
            SetMessage("FAIL", "产品条码不允许为空!")
            Return False
        End If
        Dim bFlag As Boolean = False
        For rowIndex As Integer = 0 To gridView1.Rows.Count - 1
            If gridView1.Rows(rowIndex).Cells(0).Value = txtPpid.Text.Trim Then
                bFlag = True
                Continue For
            End If
        Next
        If bFlag = False Then
            SetMessage("FAIL", "产品条码没有在旧箱产品明细中!")
            txtPpid.Focus()
            txtPpid.Text = ""
            Return False
        End If

        If lblNewQtyShould.Text = lblNewQtyFact.Text Then
            txtPpid.Focus()
            txtPpid.Text = ""
            SetMessage("FAIL", "扫描新箱已经装满了，请换新箱再装!")
            Return False
        End If

        Return True
    End Function

    '设置移动数据
    Private Sub SetGridViewDataRemove()
        lblOldQty.Text = (Convert.ToInt16(lblOldQty.Text) - 1).ToString
        lblNewQtyFact.Text = (Convert.ToInt16(lblNewQtyFact.Text) + 1).ToString
        gridView2.Rows.Add(txtPpid.Text)
        For rowIndex As Integer = 0 To gridView1.Rows.Count - 1
            If gridView1.Rows(rowIndex).Cells(0).Value = txtPpid.Text.Trim Then
                gridView1.Rows.RemoveAt(rowIndex)
                Exit Sub
            End If
        Next
    End Sub

    '设置信息
    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            lblResult.Text = message
            lblMessage.Text = "FAIL"
            lblResult.ForeColor = Color.Crimson
            lblMessage.ForeColor = Color.Crimson
        Else
            lblResult.Text = message
            lblMessage.Text = "PASS"
            lblResult.ForeColor = Color.FromArgb(0, 192, 0)
            lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub

    '设置扫描箱的产品条码 数据
    Private Sub SetGridViewData(cartonid As String, gridview As DataGridView)
        Dim strSQL As String = "SELECT ppid FROM dbo.m_Cartonsn_t  WHERE Cartonid = '{0}'"
        strSQL = String.Format(strSQL, cartonid)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        gridview.Rows.Clear()
        For rowIndex As Integer = 0 To dt.Rows.Count - 1
            gridview.Rows.Add(dt.Rows(rowIndex)("ppid").ToString)
        Next

    End Sub

#Region "Grid行数"
    Private Sub gridView_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles gridView1.RowPostPaint, gridView2.RowPostPaint
        Using b As SolidBrush = New SolidBrush(TryCast(sender, DataGridView).RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4)
        End Using
    End Sub
#End Region

End Class