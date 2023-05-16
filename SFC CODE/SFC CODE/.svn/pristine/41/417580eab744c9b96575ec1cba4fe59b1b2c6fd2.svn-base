Imports MainFrame
Imports MainFrame.SysCheckData

Public Class FrmBarcodeBack

#Region "事件"
    '退出
    Private Sub ToolExit_Click(sender As Object, e As EventArgs) Handles ToolExit.Click
        Me.Close()
    End Sub

    '刷新
    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        If String.IsNullOrEmpty(Me.txtBarcode.Text.Trim) Then
            Exit Sub
        End If

        Try
            FrmBarcodeBack()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicFindReport.FrmBarcodeBack", "ToolReflsh_Click", "sys")
        End Try
    End Sub

    '条码文本框回车事件
    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        If String.IsNullOrEmpty(Me.txtBarcode.Text.Trim) Then
            Exit Sub
        End If
        If e.KeyChar = Chr(13) Then
            FrmBarcodeBack()
        End If
    End Sub

    Private Sub dgvT_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvT.CellClick
        If e.RowIndex = -1 Then Return
        If Me.dgvT.RowCount < 1 Then Return
        Dim testtypeid As String = Me.dgvT.Rows(e.RowIndex).Cells(1).Value.ToString()
        Dim ppid As String = Me.dgvT.Rows(e.RowIndex).Cells(0).Value.ToString()
        Dim strSQL As String = String.Format(" exec Exec_BarcodeBack '{0}','{1}','1' ", ppid, testtypeid)

        Try
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            Me.dgvTDetail.DataSource = dt
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub
#End Region

#Region "方法"
    'tabControl加载条码追溯信息
    Private Sub FrmBarcodeBack()
        Dim i As Integer = -1   '记录有几个tab的datagridview没有值
        Dim tabName() As TabPage = {Me.TabPage1, Me.TabPage2, Me.TabPage3, Me.TabPage4, Me.TabPage5, Me.TabPage6, Me.TabPage7, Me.TabPage8, Me.TabPage8, Me.TabPage9, Me.TabPage10,
                                    Me.TabPage11, Me.TabPage12, Me.TabPage13, Me.TabPage14, Me.TabPage15}

        Try

            AntiFlicker = True   '减少闪烁
            Me.MaximizeBox = True
            Me.tabControl1.TabPages.Clear() '清空所有tabpage
            Me.dgvTDetail.DataSource = Nothing
            AntiFlicker = True
            Me.MaximizeBox = True
            lblNextStation.Text = ""
            lblCStation.Text = ""
            Dim strSQL As String = String.Format(" exec Exec_BarcodeBack'{0}','','0'", txtBarcode.Text.Trim.ToString)
            Using ds As DataSet = DbOperateUtils.GetDataSet(strSQL)
                If ds.Tables(0).Rows.Count > 0 OrElse ds.Tables(1).Rows.Count > 0 Then  '打印记录
                    dgvS.DataSource = ds.Tables(0)
                    dgvSV.DataSource = ds.Tables(1)
                    Me.tabControl1.Controls.Add(Me.TabPage1)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage1
                    dgvS.DataSource = ds.Tables(0)
                    dgvSV.DataSource = ds.Tables(1)
                End If

                If ds.Tables(2).Rows.Count > 0 Then '工单信息
                    dgvM.DataSource = ds.Tables(2)
                    Me.tabControl1.Controls.Add(Me.TabPage2)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage2
                    dgvM.DataSource = ds.Tables(2)
                End If

                If ds.Tables(3).Rows.Count > 0 OrElse ds.Tables(4).Rows.Count > 0 Then     '物料信息
                    dgvP.DataSource = ds.Tables(3)
                    dgvPO.DataSource = ds.Tables(4)
                    Me.tabControl1.Controls.Add(Me.TabPage3)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage3
                    dgvP.DataSource = ds.Tables(3)
                    dgvPO.DataSource = ds.Tables(4)
                End If

                If ds.Tables(5).Rows.Count > 0 OrElse ds.Tables(6).Rows.Count > 0 Then  '包装记录
                    dgvC.DataSource = ds.Tables(5)
                    dgvCsn.DataSource = ds.Tables(6)
                    Me.tabControl1.Controls.Add(Me.TabPage4)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage4
                    dgvC.DataSource = ds.Tables(5)
                    dgvCsn.DataSource = ds.Tables(6)
                End If

                If ds.Tables(7).Rows.Count > 0 OrElse ds.Tables(8).Rows.Count > 0 Then '出货栈板记录
                    dgvWm.DataSource = ds.Tables(7)
                    dgvWd.DataSource = ds.Tables(8)
                    Me.tabControl1.Controls.Add(Me.TabPage5)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage5
                    dgvWm.DataSource = ds.Tables(7)
                    dgvWd.DataSource = ds.Tables(8)
                End If

                If ds.Tables(9).Rows.Count > 0 OrElse ds.Tables(10).Rows.Count > 0 OrElse ds.Tables(11).Rows.Count > 0 Then  '扫描工站记录
                    dgvSn.DataSource = ds.Tables(9)
                    If ds.Tables(9).Rows.Count > 0 Then
                        lblCStation.Text = ds.Tables(9).Rows(ds.Tables(9).Rows.Count - 1)(2).ToString '当前工站
                        If ds.Tables(4).Rows.Count > 0 Then
                            Dim cst As String = lblCStation.Text.Substring(0, 6)

                            If ds.Tables(4).Select("工站ID='" & cst & "'").Length > 0 Then
                                Dim dr As DataRow = ds.Tables(4).Select("工站ID='" & cst & "'")(0)
                                Dim corderid As String = ""
                                corderid = dr(4).ToString()
                                Dim nextid As String = CInt(corderid) + 1
                                If ds.Tables(4).Select("工序序号='" & nextid & "'").Length > 0 Then
                                    dr = ds.Tables(4).Select("工序序号='" & nextid & "'")(0)
                                    lblNextStation.Text = dr(6).ToString() + "/" + dr(7).ToString() '站点/站点名
                                Else
                                    lblNextStation.Text = ""
                                End If
                            End If
                        End If
                    End If
                dgvSnD.DataSource = ds.Tables(10)
                dgvSppid.DataSource = ds.Tables(11)
                Me.tabControl1.Controls.Add(Me.TabPage6)
                Else
                i = i + 1
                tabName(i) = Me.TabPage6
                dgvSn.DataSource = ds.Tables(9)
                dgvSnD.DataSource = ds.Tables(10)
                dgvSppid.DataSource = ds.Tables(11)
                End If

                If ds.Tables(12).Rows.Count > 0 Then '不良品维修记录
                    dgvTs.DataSource = ds.Tables(12)
                    Me.tabControl1.Controls.Add(Me.TabPage7)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage7
                    dgvTs.DataSource = ds.Tables(12)
                End If

                If ds.Tables(13).Rows.Count > 0 OrElse ds.Tables(14).Rows.Count > 0 Then    '扫描异常记录
                    dgvE.DataSource = ds.Tables(13)
                    dgvExch.DataSource = ds.Tables(14)
                    Me.tabControl1.Controls.Add(Me.TabPage8)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage8
                    dgvE.DataSource = ds.Tables(13)
                    dgvExch.DataSource = ds.Tables(14)
                End If

                If ds.Tables(15).Rows.Count > 0 Then    '测试记录
                    dgvT.DataSource = ds.Tables(15)
                    Me.tabControl1.Controls.Add(Me.TabPage9)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage9
                    dgvT.DataSource = ds.Tables(15)
                End If

                If ds.Tables(16).Rows.Count > 0 Then    '上料记录16
                    dgvPCBLot.DataSource = ds.Tables(16)
                    Me.tabControl1.Controls.Add(Me.TabPage10)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage10
                    dgvPCBLot.DataSource = ds.Tables(16)
                End If

                If ds.Tables(17).Rows.Count > 0 Then    '工治具寿命管控17
                    dgvEquLift.DataSource = ds.Tables(17)
                    Me.tabControl1.Controls.Add(Me.TabPage11)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage11
                    dgvEquLift.DataSource = ds.Tables(17)
                End If


                If ds.Tables(18).Rows.Count > 0 Then    '重工18
                    dgvCartonRework.DataSource = ds.Tables(18)
                    Me.tabControl1.Controls.Add(Me.TabPage12)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage12
                    dgvCartonRework.DataSource = ds.Tables(18)
                End If

                If ds.Tables(19).Rows.Count > 0 Then    '钢网
                    dgvStenIL.DataSource = ds.Tables(19)
                    Me.tabControl1.Controls.Add(Me.TabPage13)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage13
                    dgvStenIL.DataSource = ds.Tables(19)
                End If

                If ds.Tables(20).Rows.Count > 0 Then    '刮刀
                    dgvScrapt.DataSource = ds.Tables(20)
                    Me.tabControl1.Controls.Add(Me.TabPage14)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage14
                    dgvScrapt.DataSource = ds.Tables(20)
                End If

                If ds.Tables(21).Rows.Count > 0 Then    '锡膏
                    dgvSolder.DataSource = ds.Tables(21)
                    Me.tabControl1.Controls.Add(Me.TabPage15)
                Else
                    i = i + 1
                    tabName(i) = Me.TabPage15
                    dgvSolder.DataSource = ds.Tables(21)
                End If
                'If ds.Tables(18).Rows.Count > 0 Then
                '    Me.lblBar.Text = ds.Tables(18).Rows(0).Item("SBarCode")
                '    Me.lblMOID.Text = ds.Tables(18).Rows(0).Item("Moid")
                '    Me.lblPartID.Text = ds.Tables(18).Rows(0).Item("PartID")
                '    Me.lblLine.Text = ds.Tables(18).Rows(0).Item("Lineid")
                'End If


            End Using

            For index = 0 To i   '没有查到记录的面板加载到后面
                Me.tabControl1.Controls.Add(tabName(index))
            Next


        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BasicFindReport.FrmBarcodeBack", "FrmBarcodeBack", "sys")
        End Try
    End Sub

    '减少tabControl闪烁
    Dim AntiFlicker As Boolean = False
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            If AntiFlicker Then
                cp.ExStyle = cp.ExStyle Or &H2000000   'Turn on WS_EX_COMPOSITED
            End If
            Return cp
        End Get
    End Property
#End Region

    Private Sub FrmBarcodeBack_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Me.lblBar.Text = string.Empty
        'Me.lblMOID.Text = String.Empty
        'Me.lblLine.Text = String.Empty
        'Me.lblPartID.Text = String.Empty




    End Sub
End Class