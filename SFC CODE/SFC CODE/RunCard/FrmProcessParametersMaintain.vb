Imports MainFrame.SysDataHandle
Imports System.Windows.Forms
Imports MainFrame.SysCheckData

Public Class FrmProcessParametersMaintain
    Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。test
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private Sub FrmProcessParametersMaintain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.PagerPaging.PagerGrid.DataGrid = Me.dgvProcessParameter
            Me.PagerPaging.PagerGrid.Sort = "创建时间 DESC"
            AddHandler Me.dgvProcessParameter.ColumnHeaderMouseClick, AddressOf Me.PagerPaging.OnSortCommand
            Me.PagerPaging.PagerGrid.PageSize = 100
            '设定用戶权限
            Dim ERigth As New SysDataBaseClass
            ERigth.GetControlright(Me)
            SetControlStatus(ActionGrid.Load)
            PagerPaging.LoadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SetControlStatus(ByVal _actionType As ActionGrid)
        If btnNew.Tag Is Nothing Then btnNew.Tag = "NO"
        If btnModify.Tag Is Nothing Then btnModify.Tag = "NO"
        If btnImport.Tag Is Nothing Then btnImport.Tag = "NO"

        Select Case _actionType
            Case ActionGrid.Load
                btnNew.Enabled = IIf(btnNew.Tag.ToString = "YES", True, False)
                btnModify.Enabled = IIf(btnModify.Tag.ToString = "YES", True, False)
                btnSearch.Enabled = True
                btnRefresh.Enabled = False
                btnExport.Enabled = True
                btnImport.Enabled = IIf(btnImport.Tag.ToString = "YES", True, False)
                btnSave.Enabled = False
                btnUndo.Enabled = True
                SetTextBoxStatus(ActionGrid.Load)
            Case ActionGrid.Undo
                btnNew.Enabled = IIf(btnNew.Tag.ToString = "YES", True, False)
                btnModify.Enabled = IIf(btnModify.Tag.ToString = "YES", True, False)
                btnSearch.Enabled = True
                btnRefresh.Enabled = False
                btnExport.Enabled = True
                btnImport.Enabled = IIf(btnImport.Tag.ToString = "YES", True, False)
                btnSave.Enabled = False
                SetTextBoxStatus(ActionGrid.Undo)
            Case ActionGrid.Add
                btnModify.Enabled = False
                btnSave.Enabled = True
                btnSearch.Enabled = False
                btnRefresh.Enabled = False
                btnImport.Enabled = IIf(btnImport.Tag.ToString = "YES", True, False)
                btnExport.Enabled = True
                SetTextBoxStatus(ActionGrid.Add)
            Case ActionGrid.Modify
                btnNew.Enabled = False
                btnSave.Enabled = True
                btnSearch.Enabled = False
                btnRefresh.Enabled = False
                btnExport.Enabled = True
                btnImport.Enabled = IIf(btnImport.Tag.ToString = "YES", True, False)
                SetTextBoxStatus(ActionGrid.Modify)
            Case ActionGrid.Search
                btnNew.Enabled = False
                btnModify.Enabled = False
                btnSave.Enabled = False
                btnRefresh.Enabled = True
                btnExport.Enabled = True
                btnImport.Enabled = IIf(btnImport.Tag.ToString = "YES", True, False)
                SetTextBoxStatus(ActionGrid.Search)
        End Select
    End Sub

    Private Sub SetTextBoxStatus(ByVal _actionType As ActionGrid)
        If TabControl1.SelectedIndex = 0 Then
            Select Case _actionType
                Case ActionGrid.Load, ActionGrid.Undo
                    txtPnOfTV.Enabled = False
                    txtTvName.Enabled = False
                    txtPnOfLine.Enabled = False
                    txtLineDesc.Enabled = False

                    Me.txtPnOfLineTwo.Enabled = False
                    Me.txtLineDesc2.Enabled = False
                    Me.txtPnOfLineThree.Enabled = False
                    Me.txtLineDesc3.Enabled = False
                    Me.txtPnOfLineFour.Enabled = False
                    Me.txtLineDesc4.Enabled = False

                    txtDrawForce.Enabled = False
                    txtSizeOfCut.Enabled = False
                    txtWireHeight.Enabled = False
                    txtWireWidth.Enabled = False
                    txtCutSize.Enabled = False
                    txtFrontSize.Enabled = False
                    Me.txtPnOfCut.Enabled = False

                    txtPnOfTV.Text = ""
                    txtTvName.Text = ""
                    txtPnOfLine.Text = ""
                    txtLineDesc.Text = ""
                    txtDrawForce.Text = ""
                    txtSizeOfCut.Text = ""
                    txtWireHeight.Text = ""
                    txtWireWidth.Text = ""
                    txtCutSize.Text = ""
                    txtFrontSize.Text = ""
                    txtPnOfCut.Text = ""
                    txtPnOfLineTwo.Text = ""
                    txtPnOfLineThree.Text = ""
                    txtPnOfLineFour.Text = ""
                    txtLineDesc2.Text = ""
                    txtLineDesc3.Text = ""
                    txtLineDesc4.Text = ""
                Case ActionGrid.Add, ActionGrid.Search
                    txtPnOfTV.Enabled = True
                    txtTvName.Enabled = True
                    txtPnOfLine.Enabled = True
                    txtLineDesc.Enabled = True

                    Me.txtPnOfLineTwo.Enabled = True
                    Me.txtLineDesc2.Enabled = True
                    Me.txtPnOfLineThree.Enabled = True
                    Me.txtLineDesc3.Enabled = True
                    Me.txtPnOfLineFour.Enabled = True
                    Me.txtLineDesc4.Enabled = True
                    Me.txtPnOfCut.Enabled = True

                    Me.txtCutSize.Enabled = False

                    txtDrawForce.Enabled = True
                    txtSizeOfCut.Enabled = True
                    txtWireHeight.Enabled = True
                    txtWireWidth.Enabled = True
                    'txtCutSize.Enabled = True
                    txtFrontSize.Enabled = True
                    txtPnOfTV.Text = ""
                    txtTvName.Text = ""
                    txtPnOfLine.Text = ""
                    txtLineDesc.Text = ""
                    txtDrawForce.Text = ""
                    txtSizeOfCut.Text = ""
                    txtWireHeight.Text = ""
                    txtWireWidth.Text = ""
                    txtCutSize.Text = ""
                    txtFrontSize.Text = ""
                    txtPnOfCut.Text = ""
                    txtPnOfLineTwo.Text = ""
                    txtPnOfLineThree.Text = ""
                    txtPnOfLineFour.Text = ""
                    txtLineDesc2.Text = ""
                    txtLineDesc3.Text = ""
                    txtLineDesc4.Text = ""
                    cboStatus.SelectedIndex = 0
                Case ActionGrid.Modify
                    txtPnOfTV.Enabled = False
                    txtTvName.Enabled = True

                    txtPnOfLine.Enabled = False
                    txtLineDesc.Enabled = True

                    Me.txtPnOfLineTwo.Enabled = False
                    Me.txtLineDesc2.Enabled = True
                    Me.txtPnOfLineThree.Enabled = False
                    Me.txtLineDesc3.Enabled = True
                    Me.txtPnOfLineFour.Enabled = False
                    Me.txtLineDesc4.Enabled = True

                    txtDrawForce.Enabled = True
                    txtSizeOfCut.Enabled = True
                    txtWireHeight.Enabled = True
                    txtWireWidth.Enabled = True
                    txtCutSize.Enabled = True
                    txtFrontSize.Enabled = True

                    Me.txtPnOfCut.Enabled = True
            End Select
        ElseIf TabControl1.SelectedIndex = 0 Then
            Select Case _actionType
                Case ActionGrid.Load, ActionGrid.Undo
                    txtCDCutSize.Enabled = False
                    txtCDEmFinishStandard.Enabled = False
                    txtCDFinishSizeMax.Enabled = False
                    txtCDFinishSizeMin.Enabled = False
                    txtCDHWFinishStandard.Enabled = False
                    txtCDOtherFinishStandard.Enabled = False
                    txtCDCutSize.Text = ""
                    txtCDEmFinishStandard.Text = ""
                    txtCDFinishSizeMax.Text = ""
                    txtCDFinishSizeMin.Text = ""
                    txtCDHWFinishStandard.Text = ""
                    txtCDOtherFinishStandard.Text = ""
                Case ActionGrid.Add, ActionGrid.Search
                    txtCDCutSize.Enabled = True
                    txtCDEmFinishStandard.Enabled = True
                    txtCDFinishSizeMax.Enabled = True
                    txtCDFinishSizeMin.Enabled = True
                    txtCDHWFinishStandard.Enabled = True
                    txtCDOtherFinishStandard.Enabled = True
                    txtCDCutSize.Text = ""
                    txtCDEmFinishStandard.Text = ""
                    txtCDFinishSizeMax.Text = ""
                    txtCDFinishSizeMin.Text = ""
                    txtCDHWFinishStandard.Text = ""
                    txtCDOtherFinishStandard.Text = ""
                Case ActionGrid.Modify
                    txtCDCutSize.Enabled = True
                    txtCDEmFinishStandard.Enabled = True
                    txtCDFinishSizeMax.Enabled = True
                    txtCDFinishSizeMin.Enabled = True
                    txtCDHWFinishStandard.Enabled = True
                    txtCDOtherFinishStandard.Enabled = True
            End Select
        End If
    End Sub

    Private ActionMode As ActionGrid
    Private sConn As New SysDataBaseClass

    Private Enum ActionGrid
        Load = 0
        Add
        Modify
        Save
        Undo
        Search
        Query
        Import
        Export
    End Enum

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Try
            ActionMode = ActionGrid.Add
            SetControlStatus(ActionGrid.Add)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Try
            ActionMode = ActionGrid.Modify
            SetControlStatus(ActionGrid.Modify)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not BasicCheck() Then Exit Sub
            If TabControl1.SelectedIndex = 0 Then
                SaveProcessParameter()
            ElseIf TabControl1.SelectedIndex = 1 Then
                SaveCommonDifferenceParameter()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SaveProcessParameter()
        Dim sql As String = Nothing
        Dim errMsg As String = Nothing
        Dim strWirePNColumn As String = ""
        Dim strWirePNValue As String = ""
        Select Case ActionMode
            Case ActionGrid.Modify
                sql = "UPDATE M_RUNCARDPROCESSPARAMTERSTANDARD_T SET TVDESCRIPTION=N'" & txtTvName.Text & "',WIREDESCRIPTION=N'" & txtLineDesc.Text & "'" & vbNewLine & _
                ", WIREDESCRIPTIONTWO=N'" & Me.txtLineDesc2.Text & "', WIREDESCRIPTIONTHREE=N'" & Me.txtLineDesc3.Text & "',WIREDESCRIPTIONFOUR=N'" & Me.txtLineDesc4.Text & "' " & _
                " ,BRASSHEIGHT=N'" & txtWireHeight.Text & "',BRASSWIDTH=N'" & txtWireWidth.Text & "',DRAWFORCE=N'" & txtDrawForce.Text & "',CUTPARTNUMBER=N'" & txtPnOfCut.Text & "'," & vbNewLine & _
                " PEELSIZE=N'" & txtSizeOfCut.Text & "',FRONTSIZE=N'" & txtFrontSize.Text & "', CUTSIZE=N'" & txtCutSize.Text & "', INTIME=GETDATE()," & vbNewLine & _
                " CREATEBY='" & VbCommClass.VbCommClass.UseId & "',STATUS='" & cboStatus.SelectedItem.ToString.Substring(0, 1) & "' WHERE TVPARTNUMBER='" & txtPnOfTV.Text & "' " & vbNewLine
                If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                    sql &= " AND WIREPARTNUMBER='" & txtPnOfLine.Text & "'"
                Else
                    sql &= "  AND WIREPARTNUMBER IS NULL"
                End If
                If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                    sql &= " AND WIREPARTNUMBERTWO='" & txtPnOfLineTwo.Text & "'"
                Else
                    sql &= "  AND WIREPARTNUMBERTWO IS NULL"
                End If

                If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                    sql &= " AND WIREPARTNUMBERTHREE='" & txtPnOfLineThree.Text & "'"
                Else
                    sql &= "  AND WIREPARTNUMBERTHREE IS NULL"
                End If

                If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
                    sql &= " AND WIREPARTNUMBERFOUR='" & txtPnOfLineFour.Text & "'"
                Else
                    sql &= "  AND WIREPARTNUMBERFOUR IS NULL"
                End If


                sql &= GetReleateSql(txtPnOfTV.Text, txtPnOfLine.Text)
                If MessageBox.Show("艺参数都将改变并且流程卡回到制作中状态,请确认？？", "提示信息", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
                If cboStatus.SelectedIndex = 1 Then
                    If MessageBox.Show("将工艺参数改成无效状态将会删除与之对应的流程卡的所有工艺参数？？", "提示信息", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If
            Case ActionGrid.Add

                If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                    strWirePNColumn = ",WIREPARTNUMBERTWO,WIREDESCRIPTIONTWO"
                    strWirePNValue = ",'" & txtPnOfLineTwo.Text & "'," & IIf(Me.txtLineDesc2.Text.Equals(String.Empty), "'NA'", "N'" & Me.txtLineDesc2.Text & "'") & ","
                Else
                    strWirePNColumn &= ""
                    strWirePNValue &= ""
                End If

                If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then

                    strWirePNColumn &= " ,WIREPARTNUMBERTHREE,WIREDESCRIPTIONTHREE"
                    strWirePNValue &= "'" & Me.txtPnOfLineThree.Text & "'," & IIf(Me.txtLineDesc3.Text.Equals(String.Empty), "'NA'", "N'" & Me.txtLineDesc3.Text & "'") & ","
                Else
                    strWirePNColumn &= ""
                    strWirePNValue &= ""
                End If

                If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
                    strWirePNColumn &= ",WIREPARTNUMBERFOUR,WIREDESCRIPTIONFOUR"
                    strWirePNValue &= "'" & txtPnOfLineFour.Text & "'," & IIf(Me.txtLineDesc4.Text.Equals(String.Empty), "'NA'", "N'" & Me.txtLineDesc4.Text & "'") & ","
                Else
                    strWirePNColumn &= ""
                    strWirePNValue &= ""
                End If

                If strWirePNValue <> String.Empty Then
                    strWirePNValue = strWirePNValue.Substring(0, strWirePNValue.Length - 1)
                End If

                sql = " INSERT INTO M_RUNCARDPROCESSPARAMTERSTANDARD_T(TVPARTNUMBER,TVDESCRIPTION,WIREPARTNUMBER,WIREDESCRIPTION," & _
                      " brassHeight, " & vbNewLine & _
                      " BRASSWIDTH,DRAWFORCE,PEELSIZE,FRONTSIZE,CUTSIZE,CUTPARTNUMBER,INTIME,CREATEBY,STATUS " & strWirePNColumn & " ) VALUES(" & vbNewLine & _
                      "N'" & txtPnOfTV.Text & "',N'" & txtTvName.Text & "',N'" & txtPnOfLine.Text & "',N'" & txtLineDesc.Text & "'" & vbNewLine & _
                      ",N'" & txtWireHeight.Text & "',N'" & txtWireWidth.Text & "',N'" & txtDrawForce.Text & "',N'" & txtSizeOfCut.Text & "' " & vbNewLine & _
                      ",N'" & txtFrontSize.Text & "',N'" & txtCutSize.Text & "',N'" & txtPnOfCut.Text & "',GETDATE(),'" & VbCommClass.VbCommClass.UseId & "' " & vbNewLine & _
                      ",'" & cboStatus.SelectedItem.ToString.Substring(0, 1) & "' " & strWirePNValue & ") "
        End Select
        If Not String.IsNullOrEmpty(sql) Then
            errMsg = sConn.ExecuteNonQuery(sql)
            If String.IsNullOrEmpty(errMsg) Then
                MessageBox.Show("保存成功")
                PagerPaging.LoadData()
                SetControlStatus(ActionGrid.Undo)
            Else
                MessageBox.Show(errMsg)
            End If
        End If
    End Sub

    Private Sub SaveCommonDifferenceParameter()
        Dim sql As String = Nothing
        Dim errMsg As String = Nothing
        Select Case ActionMode
            Case ActionGrid.Modify
                sql = "UPDATE M_RUNCARDALLOWANCEPARAMETER_T SET FINISHSIZERANGEMIN=N'" & txtCDFinishSizeMin.Text & "',FINISHSIZERANGEMAX=N'" & txtCDFinishSizeMax.Text & "'" & vbNewLine & _
                " ,HWSTANDARDSIZE=N'" & txtCDHWFinishStandard.Text & "',EMERSONSTANDARDSIZE=N'" & txtCDEmFinishStandard.Text & "',OTHERSTANDARDSIZE=N'" & txtCDOtherFinishStandard.Text & "'," & vbNewLine & _
                " INTIME=GETDATE(),CUTSIZEMIN='" & txtCDCutSize.Text & "', TOLERANCERANGE =N'" & Me.txtToleranceRange.Text.Trim & "'" & vbNewLine & _
                " ,CREATER='" & VbCommClass.VbCommClass.UseId & "',STATUS='" & cdCobStatus.SelectedItem.ToString.Substring(0, 1) & "' WHERE ID=" & Me.lblID.Text & ""
            Case ActionGrid.Add
                sql = " INSERT INTO M_RUNCARDALLOWANCEPARAMETER_T(FINISHSIZERANGEMIN,FINISHSIZERANGEMAX" & vbNewLine & _
                 " ,HWSTANDARDSIZE,EMERSONSTANDARDSIZE,OTHERSTANDARDSIZE,CUTSIZEMIN,TOLERANCERANGE,INTIME,CREATER,STATUS) VALUES(" & vbNewLine & _
                      "N'" & txtCDFinishSizeMin.Text & "',N'" & txtCDFinishSizeMax.Text & "',N'" & txtCDHWFinishStandard.Text & "',N'" & txtCDEmFinishStandard.Text & "'" & vbNewLine & _
                      ",N'" & txtCDOtherFinishStandard.Text & "','" & txtCDCutSize.Text & "', N'" & Me.txtToleranceRange.Text.Trim & " ',GETDATE(),'" & VbCommClass.VbCommClass.UseId & "' " & vbNewLine & _
                      ",'" & cdCobStatus.SelectedItem.ToString.Substring(0, 1) & "') "
        End Select
        If Not String.IsNullOrEmpty(sql) Then
            errMsg = sConn.ExecuteNonQuery(sql)
            If String.IsNullOrEmpty(errMsg) Then
                MessageBox.Show("保存成功")
                PagerPaging.LoadData()
                SetControlStatus(ActionGrid.Undo)
            Else
                MessageBox.Show(errMsg)
            End If
        End If
    End Sub

    Private Function BasicCheck() As Boolean
        If TabControl1.SelectedIndex = 0 Then
            Select Case ActionMode
                Case ActionGrid.Add
                    If String.IsNullOrEmpty(txtPnOfTV.Text) Then
                        MessageBox.Show("端子料号不能为空")
                        txtPnOfTV.SelectAll()
                        Return False
                    End If
                    If String.IsNullOrEmpty(txtPnOfLine.Text) Then
                        MessageBox.Show("线材料号不能为空")
                        txtPnOfLine.SelectAll()
                        Return False
                    End If

                    If Not String.IsNullOrEmpty(Me.txtPnOfLineTwo.Text) Then
                        If String.IsNullOrEmpty(Me.txtPnOfLine.Text) Then
                            MessageBox.Show("线材料号1不能为空")
                            txtPnOfLine.SelectAll()
                            Return False
                        End If
                    End If

                    If Not String.IsNullOrEmpty(Me.txtPnOfLineThree.Text) Then
                        If String.IsNullOrEmpty(Me.txtPnOfLineTwo.Text) Then
                            MessageBox.Show("线材料号2不能为空")
                            txtPnOfLineTwo.SelectAll()
                            Return False
                        End If
                    End If

                    If Not String.IsNullOrEmpty(Me.txtPnOfLineFour.Text) Then
                        If String.IsNullOrEmpty(Me.txtPnOfLineThree.Text) Then
                            MessageBox.Show("线材料号3不能为空")
                            txtPnOfLineThree.SelectAll()
                            Return False
                        End If
                    End If

                    If TVAlreadyExists() Then
                        MessageBox.Show(String.Format("端子料号:{0},线材料号1:{1},线材料号2:{2},线材料号3:{3},线材料号4:{4}已经存在", txtPnOfTV.Text, txtPnOfLine.Text, txtPnOfLineTwo.Text, txtPnOfLineThree.Text, txtPnOfLineFour.Text))
                        Return False
                    End If
                    If cboStatus.SelectedIndex = 1 Then
                        MessageBox.Show("新增时状态只能选择有效")
                        Return False
                    End If
            End Select
            Return True
        ElseIf TabControl1.SelectedIndex = 1 Then
            If String.IsNullOrEmpty(txtCDFinishSizeMin.Text) Then
                MessageBox.Show("请输入成品尺寸最小值")
                txtCDFinishSizeMin.SelectAll()
                Return False
            End If
            If String.IsNullOrEmpty(txtCDFinishSizeMin.Text) AndAlso String.IsNullOrEmpty(txtCDFinishSizeMax.Text) Then
                MessageBox.Show("请输入成品尺寸最大值")
                txtCDFinishSizeMax.SelectAll()
                Return False
            End If
            If String.IsNullOrEmpty(txtCDCutSize.Text) Then
                MessageBox.Show("请输入裁线下公差")
                txtCDCutSize.SelectAll()
                Return False
            End If
            If cdCobStatus.SelectedIndex = -1 Then
                MessageBox.Show("请选择状态")
                Return False
            End If
            Return True
        End If
    End Function

    Private Function TVAlreadyExists() As Boolean
        Dim sql As String = ""
        Dim strWirePNList As String = "", sqlWirePNList As String = ""
        If Me.txtPnOfLineTwo.Text <> String.Empty Then
            sqlWirePNList = " AND WIREPARTNUMBERTWO = '" & Me.txtPnOfLineTwo.Text.Trim() & "'"
        Else
            sqlWirePNList = " AND WIREPARTNUMBERTWO IS NULL"
        End If
        If Me.txtPnOfLineThree.Text <> String.Empty Then
            sqlWirePNList &= " AND WIREPARTNUMBERTHREE = '" & Me.txtPnOfLineThree.Text.Trim() & "'"
        Else
            sqlWirePNList &= " AND WIREPARTNUMBERTHREE IS NULL"
        End If
        If Me.txtPnOfLineFour.Text <> String.Empty Then
            sqlWirePNList &= " AND WIREPARTNUMBERFOUR = '" & Me.txtPnOfLineFour.Text.Trim() & "'"
        Else
            sqlWirePNList &= " AND WIREPARTNUMBERFOUR IS NULL"
        End If

        sql = "SELECT TVPARTNUMBER FROM M_RUNCARDPROCESSPARAMTERSTANDARD_T WHERE TVPARTNUMBER='" & txtPnOfTV.Text & "' AND WIREPARTNUMBER='" & txtPnOfLine.Text & "'" & sqlWirePNList
        If sConn.GetRowsCount(sql) > 0 Then Return True
        Return False
    End Function

    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        Try
            ActionMode = ActionGrid.Undo
            SetControlStatus(ActionGrid.Undo)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            ActionMode = ActionGrid.Search
            SetControlStatus(ActionGrid.Search)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try
            ActionMode = ActionGrid.Query
            PagerPaging.LoadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
            ActionMode = ActionGrid.Import
            Using frm As FrmProcessParametersImport = New FrmProcessParametersImport
                If TabControl1.SelectedIndex = 0 Then
                    frm._importType = FrmProcessParametersImport.ImportTypeGrid.ProcessParameters
                ElseIf TabControl1.SelectedIndex = 1 Then
                    frm._importType = FrmProcessParametersImport.ImportTypeGrid.CommonDiff
                End If
                frm.ShowDialog()
            End Using
            PagerPaging.LoadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadProcessParameters() Handles PagerPaging.Paging
        Dim sql As String = Nothing
        sql = GetSql()
        If ActionMode = ActionGrid.Query Then
            sql += GetWhereSql()
        End If
        LoadData(sql)
    End Sub

    Private Function GetSql()
        If TabControl1.SelectedIndex = 0 Then
            Select Case ActionMode
                Case ActionGrid.Load, ActionGrid.Undo
                    Return "SELECT TOP 200 TVPARTNUMBER '端子料号',TVDESCRIPTION '通用名称'," & vbNewLine & _
        " WIREPARTNUMBER '线材料号1',WIREDESCRIPTION '适用线规', " & vbNewLine & _
        " WIREPARTNUMBERTWO '线材料号2',WIREDESCRIPTIONTWO '适用线规2', " & vbNewLine & _
        " WIREPARTNUMBERTHREE '线材料号3',WIREDESCRIPTIONTHREE '适用线规3', " & vbNewLine & _
        " WIREPARTNUMBERFOUR '线材料号4',WIREDESCRIPTIONFOUR '适用线规4' " & vbNewLine & _
        " ,BRASSHEIGHT '铜丝压着高度CH值',BRASSWIDTH '铜丝压着宽度CW值'," & vbNewLine & _
        " DRAWFORCE '拉拔力',PEELSIZE '脱皮尺寸',CUTSIZE '裁线尺寸',FRONTSIZE '前端尺寸'," & vbNewLine & _
        " CUTPARTNUMBER '刀模',INTIME '创建时间',CREATEBY '创建人'," & vbNewLine & _
        " STATUS,CASE STATUS WHEN 'Y' THEN N'有效' ELSE N'无效' END '状态'" & vbNewLine & _
        " FROM M_RUNCARDPROCESSPARAMTERSTANDARD_T WHERE 1=1 ORDER BY INTIME DESC "
                Case Else
                    Return "SELECT TVPARTNUMBER '端子料号',TVDESCRIPTION '通用名称'," & vbNewLine & _
" WIREPARTNUMBER '线材料号1',WIREDESCRIPTION '适用线规', " & vbNewLine & _
" WIREPARTNUMBERTWO '线材料号2',WIREDESCRIPTIONTWO '适用线规2', " & vbNewLine & _
" WIREPARTNUMBERTHREE '线材料号3',WIREDESCRIPTIONTHREE '适用线规3', " & vbNewLine & _
" WIREPARTNUMBERFOUR '线材料号4',WIREDESCRIPTIONFOUR '适用线规4' " & vbNewLine & _
" ,BRASSHEIGHT '铜丝压着高度CH值',BRASSWIDTH '铜丝压着宽度CW值'," & vbNewLine & _
" DRAWFORCE '拉拔力',PEELSIZE '脱皮尺寸',CUTSIZE '裁线尺寸',FRONTSIZE '前端尺寸'," & vbNewLine & _
" CUTPARTNUMBER '刀模',INTIME '创建时间',CREATEBY '创建人'," & vbNewLine & _
" STATUS,CASE STATUS WHEN 'Y' THEN N'有效' ELSE N'无效' END '状态'" & vbNewLine & _
" FROM M_RUNCARDPROCESSPARAMTERSTANDARD_T WHERE 1=1 "
            End Select
        ElseIf TabControl1.SelectedIndex = 1 Then
            Return "SELECT ID,  FINISHSIZERANGEMIN '成品尺寸最小值',FINISHSIZERANGEMAX '成品尺寸最大值'," & vbNewLine & _
" HWSTANDARDSIZE '华为成品公差标准',EMERSONSTANDARDSIZE '爱默生成品公差标准' " & vbNewLine & _
" ,OTHERSTANDARDSIZE '其他公差标准',CUTSIZEMIN '裁线下公差',TOLERANCERANGE '公差范围'," & vbNewLine & _
" INTIME '创建时间',CREATER '创建人'," & vbNewLine & _
" STATUS,CASE STATUS WHEN 'Y' THEN N'有效' ELSE N'无效' END '状态'" & vbNewLine & _
" FROM M_RUNCARDALLOWANCEPARAMETER_T WHERE 1=1 "
        End If
        Return Nothing
    End Function

    Private Function GetWhereSql() As String
        Dim sql As New System.Text.StringBuilder()
        If TabControl1.SelectedIndex = 0 Then
            If Not String.IsNullOrEmpty(txtPnOfTV.Text) Then
                sql.Append("AND  TVPARTNUMBER LIKE N'%" & txtPnOfTV.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtTvName.Text) Then
                sql.Append("AND  TVDESCRIPTION LIKE N'%" & txtTvName.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql.Append("AND  WIREPARTNUMBER LIKE N'%" & txtPnOfLine.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtLineDesc.Text) Then
                sql.Append("AND  WIREDESCRIPTION LIKE N'%" & txtLineDesc.Text.Trim & "%'").Append(vbNewLine)
            End If
            'Add by CQ 20150603
            If Not String.IsNullOrEmpty(Me.txtPnOfLineTwo.Text) Then
                sql.Append("AND  WIREPARTNUMBERTWO LIKE N'%" & txtPnOfLineTwo.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(Me.txtPnOfLineThree.Text) Then
                sql.Append("AND  WIREPARTNUMBERTHREE LIKE N'%" & txtPnOfLineThree.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(Me.txtPnOfLineFour.Text) Then
                sql.Append("AND WIREPARTNUMBERFOUR LIKE N'%" & txtPnOfLineFour.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(Me.txtLineDesc2.Text) Then
                sql.Append("AND WIREDESCRIPTIONTWO LIKE N'%" & txtLineDesc2.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(Me.txtLineDesc3.Text) Then
                sql.Append("AND WIREDESCRIPTIONTHREE LIKE N'%" & txtLineDesc3.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(Me.txtLineDesc4.Text) Then
                sql.Append("AND WIREDESCRIPTIONFOUR LIKE N'%" & txtLineDesc4.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(txtWireHeight.Text) Then
                sql.Append("AND  BRASSHEIGHT LIKE N'%" & txtWireHeight.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtWireWidth.Text) Then
                sql.Append("AND  BRASSWIDTH LIKE N'%" & txtWireWidth.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtDrawForce.Text) Then
                sql.Append("AND  DRAWFORCE LIKE N'%" & txtDrawForce.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtSizeOfCut.Text) Then
                sql.Append("AND  PEELSIZE LIKE N'%" & txtSizeOfCut.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtCutSize.Text) Then
                sql.Append("AND  CUTSIZE LIKE N'%" & txtCutSize.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtFrontSize.Text) Then
                sql.Append("AND  FRONTSIZE LIKE N'%" & txtFrontSize.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtPnOfCut.Text) Then
                sql.Append("AND  CUTPARTNUMBER LIKE N'%" & txtPnOfCut.Text.Trim & "%'").Append(vbNewLine)
            End If
            If cboStatus.SelectedIndex <> -1 Then
                sql.Append(" AND STATUS='" & cboStatus.SelectedItem.ToString.Substring(0, 1) & "'")
            End If
            ' sql.Append(" ORDER BY INTIME DESC")
            If sql.Length > 0 Then Return sql.ToString
        ElseIf TabControl1.SelectedIndex = 1 Then
            If Not String.IsNullOrEmpty(txtCDFinishSizeMin.Text) Then
                sql.Append("AND FINISHSIZERANGEMIN LIKE N'%" & txtCDFinishSizeMin.Text & "%'")
            End If
            If Not String.IsNullOrEmpty(txtCDFinishSizeMax.Text) Then
                sql.Append("AND FINISHSIZERANGEMAX LIKE N'%" & txtCDFinishSizeMax.Text & "%'")
            End If
            If Not String.IsNullOrEmpty(txtCDHWFinishStandard.Text) Then
                sql.Append("AND HWSTANDARDSIZE LIKE N'%" & txtCDHWFinishStandard.Text & "%'")
            End If
            If Not String.IsNullOrEmpty(txtCDEmFinishStandard.Text) Then
                sql.Append("AND EMERSONSTANDARDSIZE LIKE N'%" & txtCDEmFinishStandard.Text & "%'")
            End If
            If Not String.IsNullOrEmpty(txtCDOtherFinishStandard.Text) Then
                sql.Append("AND OTHERSTANDARDSIZE LIKE N'%" & txtCDOtherFinishStandard.Text & "%'")
            End If
            If Not String.IsNullOrEmpty(txtCDCutSize.Text) Then
                sql.Append("AND CUTSIZEMIN LIKE N'%" & txtCDCutSize.Text & "%'")
            End If

            If Not String.IsNullOrEmpty(txtToleranceRange.Text) Then
                sql.Append("AND TOLERANCERANGE LIKE N'%" & txtToleranceRange.Text & "%'")
            End If

            If cdCobStatus.SelectedIndex <> -1 Then
                sql.Append("AND STATUS='" & cdCobStatus.SelectedItem.ToString.Substring(0, 1) & "'")
            End If
            If sql.Length > 0 Then Return sql.ToString
        End If
        Return Nothing
    End Function

    Private Sub LoadData(ByVal sql As String)
        Dim sConn As New SysDataBaseClass
        Dim dt As DataTable = PagerPaging.GetPagingDataTable(sql, sConn.GetConnectionString(), True)
        If TabControl1.SelectedIndex = 0 Then
            dgvProcessParameter.DataSource = dt
            dgvProcessParameter.Columns(ProcessGrid.STATUS1).Visible = False
            dgvProcessParameter.Columns(ProcessGrid.Seq).HeaderText = "序号"
            For Each col As DataGridViewColumn In dgvProcessParameter.Columns
                col.SortMode = DataGridViewColumnSortMode.Programmatic
            Next
            dgvProcessParameter.Columns(ProcessGrid.Seq).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvProcessParameter.Columns(ProcessGrid.Seq).Width = 40
            dgvProcessParameter.Columns(ProcessGrid.INTIME).Width = 60
            dgvProcessParameter.Columns(ProcessGrid.STATUS2).Width = 60
            dgvProcessParameter.Columns(ProcessGrid.CREATEBY).Width = 80
            dgvProcessParameter.Columns(ProcessGrid.PEELSIZE).Width = 80
            dgvProcessParameter.Columns(ProcessGrid.DRAWFORCE).Width = 80
        ElseIf TabControl1.SelectedIndex = 1 Then
            dgvCD.DataSource = dt
            dgvCD.Columns(CDGrid.Status1).Visible = False
            dgvCD.Columns(CDGrid.ID).Visible = False
            dgvCD.Columns(CDGrid.Seq).HeaderText = "序号"
            For Each col As DataGridViewColumn In dgvCD.Columns
                col.SortMode = DataGridViewColumnSortMode.Programmatic
            Next
            dgvCD.Columns(CDGrid.Seq).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvCD.Columns(CDGrid.Seq).Width = 40
        End If
    End Sub

    Private Enum ProcessGrid
        Seq = 0
        TVPARTNUMBER
        TVDESCRIPTION
        WIREPARTNUMBER
        WIREDESCRIPTION
        WIREPARTNUMBERTWO
        WIREDESCRIPTIONTWO
        WIREPARTNUMBERTHREE
        WIREDESCRIPTIONTHREE
        WIREPARTNUMBERFOUR
        WIREDESCRIPTIONFOUR
        BRASSHEIGHT
        BRASSWIDTH
        DRAWFORCE
        PEELSIZE
        CUTSIZE
        FRONTSIZE
        CUTPARTNUMBER  'Cut part Number
        INTIME
        CREATEBY
        STATUS1
        STATUS2
    End Enum

    Private Sub dgvProcessParameter_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProcessParameter.CellClick
        Try
            SetControlData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private drawForce As String = Nothing
    Private cutSize As String = Nothing
    Private peelSize As String = Nothing
    Private brassHeight As String = Nothing
    Private brassWidth As String = Nothing
    Private frontSize As String = Nothing

    Private Sub SetControlData()
        If Me.dgvProcessParameter.RowCount < 1 Then Exit Sub
        Me.txtPnOfTV.Text = Me.dgvProcessParameter.Item(ProcessGrid.TVPARTNUMBER, dgvProcessParameter.CurrentRow.Index).Value.ToString()
        Me.txtTvName.Text = Me.dgvProcessParameter.Item(ProcessGrid.TVDESCRIPTION, dgvProcessParameter.CurrentRow.Index).Value.ToString()
        Me.txtPnOfLine.Text = Me.dgvProcessParameter.Item(ProcessGrid.WIREPARTNUMBER, dgvProcessParameter.CurrentRow.Index).Value.ToString()
        Me.txtLineDesc.Text = Me.dgvProcessParameter.Item(ProcessGrid.WIREDESCRIPTION, dgvProcessParameter.CurrentRow.Index).Value.ToString()

        Me.txtPnOfLineTwo.Text = Me.dgvProcessParameter.Item(ProcessGrid.WIREPARTNUMBERTWO, dgvProcessParameter.CurrentRow.Index).Value.ToString()
        Me.txtLineDesc2.Text = Me.dgvProcessParameter.Item(ProcessGrid.WIREDESCRIPTIONTWO, dgvProcessParameter.CurrentRow.Index).Value.ToString()
        Me.txtPnOfLineThree.Text = Me.dgvProcessParameter.Item(ProcessGrid.WIREPARTNUMBERTHREE, dgvProcessParameter.CurrentRow.Index).Value.ToString()
        Me.txtLineDesc3.Text = Me.dgvProcessParameter.Item(ProcessGrid.WIREDESCRIPTIONTHREE, dgvProcessParameter.CurrentRow.Index).Value.ToString()
        Me.txtPnOfLineFour.Text = Me.dgvProcessParameter.Item(ProcessGrid.WIREPARTNUMBERFOUR, dgvProcessParameter.CurrentRow.Index).Value.ToString()
        Me.txtLineDesc4.Text = Me.dgvProcessParameter.Item(ProcessGrid.WIREDESCRIPTIONFOUR, dgvProcessParameter.CurrentRow.Index).Value.ToString()

        Me.txtDrawForce.Text = Me.dgvProcessParameter.Item(ProcessGrid.DRAWFORCE, dgvProcessParameter.CurrentRow.Index).Value.ToString()
        Me.txtCutSize.Text = Me.dgvProcessParameter.Item(ProcessGrid.CUTSIZE, dgvProcessParameter.CurrentRow.Index).Value.ToString
        Me.txtSizeOfCut.Text = Me.dgvProcessParameter.Item(ProcessGrid.PEELSIZE, dgvProcessParameter.CurrentRow.Index).Value.ToString()
        Me.cboStatus.SelectedIndex = Me.cboStatus.FindString(Me.dgvProcessParameter.Item(ProcessGrid.STATUS1, dgvProcessParameter.CurrentRow.Index).Value.ToString())
        Me.txtWireHeight.Text = Me.dgvProcessParameter.Item(ProcessGrid.BRASSHEIGHT, dgvProcessParameter.CurrentRow.Index).Value.ToString
        Me.txtWireWidth.Text = Me.dgvProcessParameter.Item(ProcessGrid.BRASSWIDTH, dgvProcessParameter.CurrentRow.Index).Value.ToString
        Me.txtFrontSize.Text = Me.dgvProcessParameter.Item(ProcessGrid.FRONTSIZE, dgvProcessParameter.CurrentRow.Index).Value.ToString()
        txtPnOfCut.Text = Me.dgvProcessParameter.Item(ProcessGrid.CUTPARTNUMBER, dgvProcessParameter.CurrentRow.Index).Value.ToString()
        drawForce = txtDrawForce.Text
        cutSize = txtCutSize.Text
        peelSize = txtSizeOfCut.Text
        brassHeight = txtWireHeight.Text
        brassWidth = txtWireWidth.Text
        frontSize = txtFrontSize.Text
    End Sub


    Private filePath As String = VbCommClass.VbCommClass.SopFilePath & "\Templates" & "\ProcessParametersTemplate.xlsx"
    'Private filePath As String = Environment.CurrentDirectory & "\Templates" & "\ProcessParametersTemplate.xlsx"
    Private selectedPath As String = Nothing
    Public Sub DoExport()
        Dim errorMsg As String = Nothing
        Dim outputFile As String = selectedPath & "\" & "加工工艺参数" & Date.Now.ToString("yyyyMMddhh24missfff") & ".xlsx"
        Try
            ActionMode = ActionGrid.Export
            Using dt As DataTable = sConn.GetDataTable(GetExportSql)
                If dt.Rows.Count > 0 Then
                    dt.TableName = "Process"
                    If SysDataBaseClass.Import2ExcelByAs(filePath, outputFile, dt, GetVariables(dt), errorMsg) Then
                        MessageBox.Show("导出成功,请查看！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show(errorMsg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("无资料供导出", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        FolderBrowserDialog1.Description = "请选择保存文件路径"
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
        FolderBrowserDialog1.ShowNewFolderButton = True
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            selectedPath = FolderBrowserDialog1.SelectedPath
            Cursor.Current = Cursors.Default
            DoExport()
        End If
    End Sub

    Private Function GetExportSql()
        Dim sql As String = "SELECT  TVPARTNUMBER ,TVDESCRIPTION ," & vbNewLine & _
" WIREPARTNUMBER ,WIREDESCRIPTION  " & vbNewLine & _
" ,BRASSHEIGHT ,BRASSWIDTH ," & vbNewLine & _
" DRAWFORCE,PEELSIZE ,CUTSIZE ,FRONTSIZE ," & vbNewLine & _
" CUTPARTNUMBER " & vbNewLine & _
" FROM M_RUNCARDPROCESSPARAMTERSTANDARD_T WHERE 1=1 "
        If ActionMode = ActionGrid.Query Then
            sql += GetWhereSql()
        End If
        Return sql
    End Function

    Private Function GetVariables(ByVal dt As DataTable) As System.Collections.Generic.Dictionary(Of String, String)
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        If dt.Rows.Count > 0 Then
            dics.Add(ProcessExportGrid.TVPARTNUMBER.ToString, dt.Rows(0)(ProcessExportGrid.TVPARTNUMBER).ToString)
            dics.Add(ProcessExportGrid.TVDESCRIPTION.ToString, dt.Rows(0)(ProcessExportGrid.TVDESCRIPTION).ToString)
            dics.Add(ProcessExportGrid.WIREPARTNUMBER.ToString, dt.Rows(0)(ProcessExportGrid.WIREPARTNUMBER).ToString)
            dics.Add(ProcessExportGrid.WIREDESCRIPTION.ToString, dt.Rows(0)(ProcessExportGrid.WIREDESCRIPTION).ToString)
            dics.Add(ProcessExportGrid.BRASSHEIGHT.ToString, dt.Rows(0)(ProcessExportGrid.BRASSHEIGHT).ToString)
            dics.Add(ProcessExportGrid.BRASSWIDTH.ToString, dt.Rows(0)(ProcessExportGrid.BRASSWIDTH).ToString)
            dics.Add(ProcessExportGrid.DRAWFORCE.ToString, dt.Rows(0)(ProcessExportGrid.DRAWFORCE).ToString)
            dics.Add(ProcessExportGrid.PEELSIZE.ToString, dt.Rows(0)(ProcessExportGrid.PEELSIZE).ToString)
            dics.Add(ProcessExportGrid.FRONTSIZE.ToString, dt.Rows(0)(ProcessExportGrid.FRONTSIZE).ToString)
            dics.Add(ProcessExportGrid.CUTSIZE.ToString, dt.Rows(0)(ProcessExportGrid.CUTSIZE).ToString)
            dics.Add(ProcessExportGrid.CUTPARTNUMBER.ToString, dt.Rows(0)(ProcessExportGrid.CUTPARTNUMBER).ToString)
        End If
        Return dics
    End Function

    Private Enum ProcessExportGrid
        TVPARTNUMBER
        TVDESCRIPTION
        WIREPARTNUMBER
        WIREDESCRIPTION
        BRASSHEIGHT
        BRASSWIDTH
        DRAWFORCE
        PEELSIZE
        CUTSIZE
        FRONTSIZE
        CUTPARTNUMBER
    End Enum

    Private Function GetReleateSql(ByVal pnOfTv As String, ByVal pnOfLine As String)
        Dim sql As String = Nothing
        If txtDrawForce.Text <> drawForce Then '拉拔力
            sql &= " UPDATE M_RUNCARDDETAILCHECKITEM_T SET RESULTVALUE='" & txtDrawForce.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & "' ,INTIME=GETDATE() WHERE CHECKITEMCODE='LDF' AND LEFTTVPARTNUMBER='" & pnOfTv & "' " & GetLeftSqlWhere()
            sql &= " UPDATE M_RUNCARDDETAILCHECKITEM_T SET RESULTVALUE='" & txtDrawForce.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & "' ,INTIME=GETDATE() WHERE CHECKITEMCODE='RDF' AND RIGHTTVPARTNUMBER='" & pnOfTv & "'" & GetRightSqlWhere()
        End If

        If peelSize <> txtSizeOfCut.Text Then '脱皮尺寸
            sql &= " UPDATE M_RUNCARDDETAILCHECKITEM_T SET RESULTVALUE='" & txtSizeOfCut.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & "' ,INTIME=GETDATE() WHERE CHECKITEMCODE='LPL' AND LEFTTVPARTNUMBER='" & pnOfTv & "' " & GetLeftSqlWhere()
            sql &= " UPDATE M_RUNCARDDETAILCHECKITEM_T SET RESULTVALUE='" & txtSizeOfCut.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & "' ,INTIME=GETDATE() WHERE CHECKITEMCODE='RPL' AND RIGHTTVPARTNUMBER='" & pnOfTv & "' " & GetRightSqlWhere()
        End If

        If brassHeight <> txtWireHeight.Text Then '高度
            sql &= " UPDATE M_RUNCARDDETAILCHECKITEM_T SET RESULTVALUE='" & txtWireHeight.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & "' ,INTIME=GETDATE() WHERE CHECKITEMCODE='LCH' AND LEFTTVPARTNUMBER='" & pnOfTv & "' " & GetLeftSqlWhere()
            sql &= " UPDATE M_RUNCARDDETAILCHECKITEM_T SET RESULTVALUE='" & txtWireHeight.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & "' ,INTIME=GETDATE() WHERE CHECKITEMCODE='RCH' AND RIGHTTVPARTNUMBER='" & pnOfTv & "' " & GetRightSqlWhere()
        End If

        If brassWidth <> txtWireWidth.Text Then '宽度
            sql &= " UPDATE M_RUNCARDDETAILCHECKITEM_T SET RESULTVALUE='" & txtWireWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & "' ,INTIME=GETDATE() WHERE CHECKITEMCODE='LCW' AND LEFTTVPARTNUMBER='" & pnOfTv & "' " & GetLeftSqlWhere()
            sql &= " UPDATE M_RUNCARDDETAILCHECKITEM_T SET RESULTVALUE='" & txtWireWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & "' ,INTIME=GETDATE() WHERE CHECKITEMCODE='RCW' AND RIGHTTVPARTNUMBER='" & pnOfTv & "' " & GetRightSqlWhere()
        End If

        If frontSize <> txtFrontSize.Text Then '前端尺寸
            sql &= " UPDATE M_RUNCARDDETAILCHECKITEM_T SET RESULTVALUE= " & vbNewLine & _
                   " CAST((A.FINISHSIZE-ISNULL(B.FRONTSIZE,A.LEFTCUTSIZE) - ISNULL(C.FRONTSIZE,A.RIGHTCUTSIZE)-ISNULL(SUBSTRING(TOLERANCERANGE,2,LEN(TOLERANCERANGE)-1),0)) AS VARCHAR)+ A.TOLERANCERANGE " & vbNewLine & _
                   " ,LEFTCUTSIZE=(CASE WHEN B.FRONTSIZE IS NULL THEN A.LEFTCUTSIZE ELSE B.FRONTSIZE END) " & vbNewLine & _
                   " ,RIGHTCUTSIZE=(CASE WHEN C.FRONTSIZE IS NULL THEN A.RIGHTCUTSIZE ELSE C.FRONTSIZE END) " & vbNewLine & _
                   " FROM  M_RUNCARDDETAILCHECKITEM_T A LEFT JOIN M_RUNCARDPROCESSPARAMTERSTANDARD_T B " & vbNewLine & _
                   " ON A.LEFTTVPARTNUMBER=B.TVPARTNUMBER " & GetLeftSqlWhereByWirePartNumber() & " " & vbNewLine & _
                   " LEFT JOIN M_RUNCARDPROCESSPARAMTERSTANDARD_T C " & vbNewLine & _
                   " ON A.RIGHTTVPARTNUMBER=C.TVPARTNUMBER " & GetRightSqlWhereByWirePartNumber() & " " & vbNewLine & _
                   " WHERE ((A.LEFTTVPARTNUMBER='" & pnOfTv & "' " & GetLeftCutSqlWhere() & ")" & vbNewLine & _
                   " OR(A.RIGHTTVPARTNUMBER='" & pnOfTv & "' " & GetRightCutSqlWhere() & ")) AND CHECKITEMCODE='LCL'"
        End If

        If Not String.IsNullOrEmpty(sql) Then
            sql &= " UPDATE M_RUNCARD_T SET STATUS=0,REMARK=N'" & String.Format("因工艺资料修改By{0},流程卡退回制作中", VbCommClass.VbCommClass.UseId) & "' " & vbNewLine & _
                    " FROM M_RUNCARD_T A,M_RUNCARDDETAILCHECKITEM_T B" & vbNewLine & _
                    " WHERE ((B.LEFTTVPARTNUMBER='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & vbNewLine & _
                    " OR(B.RIGHTTVPARTNUMBER='" & pnOfTv & "' " & GetRightSqlWhere() & "))" & vbNewLine & _
                    " AND B.PARTNUMBER=A.PARTNUMBER"

            sql &= " UPDATE M_RUNCARDDETAIL_T SET PROCESSSTANDARD=ISNULL(B.RVAL,A.PROCESSSTANDARD)" & vbNewLine & _
 " FROM M_RUNCARDDETAIL_T A JOIN" & vbNewLine & _
 "( SELECT A.PARTNUMBER,A.STATIONID,(  SELECT (B.DESCRIPTION+':'+B.RESULTVALUE)+'; '  " & vbNewLine & _
 " FROM M_RUNCARDDETAILCHECKITEM_T B         " & vbNewLine & _
 " WHERE B.RESULTVALUE<>'' AND B.STATUS='Y'  " & vbNewLine & _
 " AND B.PARTNUMBER=A.PARTNUMBER ORDER BY B.CHECKGROUP FOR XML PATH('') ) RVAL  " & vbNewLine & _
 " FROM M_RUNCARDDETAILCHECKITEM_T A," & vbNewLine & _
 " (SELECT DISTINCT PARTNUMBER FROM M_RUNCARDDETAILCHECKITEM_T" & vbNewLine & _
 " WHERE ((LEFTTVPARTNUMBER='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & vbNewLine & _
 " OR(RIGHTTVPARTNUMBER='" & pnOfTv & "' " & GetRightSqlWhere() & "))) C" & vbNewLine & _
 " WHERE A.PARTNUMBER = C.PARTNUMBER" & vbNewLine & _
 " GROUP BY A.PARTNUMBER,A.STATIONID) B " & vbNewLine & _
 " ON A.PARTNUMBER=B.PARTNUMBER AND A.STATIONID=B.STATIONID;"
        End If

        If cboStatus.SelectedIndex = 1 Then '置为无效
            sql = Nothing
            sql &= " UPDATE M_RUNCARD_T SET STATUS=0 ,REMARK=N'" & String.Format("因工艺资料作废By{0},流程卡退回制作中", VbCommClass.VbCommClass.UseId) & "'" & vbNewLine & _
                   " FROM M_RUNCARD_T A,M_RUNCARDDETAILCHECKITEM_T B" & vbNewLine & _
                   " WHERE ((B.LEFTTVPARTNUMBER='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & vbNewLine & _
                   " OR(B.RIGHTTVPARTNUMBER='" & pnOfTv & "' " & GetRightSqlWhere() & "))" & vbNewLine & _
                   " AND B.PARTNUMBER=A.PARTNUMBER"

            sql &= " UPDATE M_RUNCARDDETAIL_T SET PROCESSSTANDARD=NULL " & vbNewLine & _
                  " FROM M_RUNCARD_T A,M_RUNCARDDETAILCHECKITEM_T B" & vbNewLine & _
                  " WHERE ((B.LEFTTVPARTNUMBER='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & vbNewLine & _
                  " OR(B.RIGHTTVPARTNUMBER='" & pnOfTv & "' " & GetRightSqlWhere() & "))" & vbNewLine & _
                  " AND B.PARTNUMBER=A.PARTNUMBER"

            sql &= " DELETE FROM M_RUNCARDDETAILCHECKITEM_T " & vbNewLine & _
                    " WHERE (LEFTTVPARTNUMBER='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & vbNewLine & _
                    " OR(RIGHTTVPARTNUMBER='" & pnOfTv & "' " & GetRightSqlWhere() & ")"
        End If
        Return sql
    End Function

    Private Function GetPns()
        Dim pns As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            pns &= "'" & txtPnOfLine.Text & "'" & ","
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            pns &= "'" & txtPnOfLineTwo.Text & "'" & ","
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            pns &= "'" & txtPnOfLineThree.Text & "'" & ","
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            pns &= "'" & txtPnOfLineFour.Text & "'" & ","
        End If
        Return pns.Trim(",")
    End Function
    Private Function GetLeftSqlWhere()
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            sql &= " AND ( LEFTLINEPARTNUMBER='" & txtPnOfLine.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTWO='" & txtPnOfLine.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTHREE='" & txtPnOfLine.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERFOUR='" & txtPnOfLine.Text & "')" & vbNewLine
        Else
            sql &= " AND LEFTLINEPARTNUMBER IS NULL "
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            sql &= " AND ( LEFTLINEPARTNUMBER='" & txtPnOfLineTwo.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTWO='" & txtPnOfLineTwo.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTHREE='" & txtPnOfLineTwo.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERFOUR='" & txtPnOfLineTwo.Text & "')" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql &= " AND LEFTLINEPARTNUMBERTWO IN(" & GetPns() & ")" & vbNewLine
            End If
        Else
            sql &= " AND LEFTLINEPARTNUMBERTWO IS NULL "
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            sql &= " AND ( LEFTLINEPARTNUMBER='" & txtPnOfLineThree.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTWO='" & txtPnOfLineThree.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTHREE='" & txtPnOfLineThree.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERFOUR='" & txtPnOfLineThree.Text & "')" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                sql &= " AND LEFTLINEPARTNUMBERTHREE IN(" & GetPns() & ")" & vbNewLine
            End If
        Else
            sql &= " AND LEFTLINEPARTNUMBERTHREE IS NULL "
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            sql &= " AND ( LEFTLINEPARTNUMBER='" & txtPnOfLineFour.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTWO='" & txtPnOfLineFour.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTHREE='" & txtPnOfLineFour.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERFOUR='" & txtPnOfLineFour.Text & "')" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                sql &= " AND LEFTLINEPARTNUMBERFOUR IN(" & GetPns() & ")" & vbNewLine
            End If
        Else
            sql &= " AND LEFTLINEPARTNUMBERFOUR IS NULL "
        End If
        Return sql
    End Function

    Private Function GetRightSqlWhere()
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            sql &= " AND ( RIGHTLINEPARTNUMBER='" & txtPnOfLine.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTWO='" & txtPnOfLine.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTHREE='" & txtPnOfLine.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERFOUR='" & txtPnOfLine.Text & "')" & vbNewLine
        Else
            sql &= " AND RIGHTLINEPARTNUMBER IS NULL "
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            sql &= " AND ( RIGHTLINEPARTNUMBER='" & txtPnOfLineTwo.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTWO='" & txtPnOfLineTwo.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTHREE='" & txtPnOfLineTwo.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERFOUR='" & txtPnOfLineTwo.Text & "')" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql &= " AND RIGHTLINEPARTNUMBERTWO IN(" & GetPns() & ")" & vbNewLine
            End If
        Else
            sql &= " AND RIGHTLINEPARTNUMBERTWO IS NULL "
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            sql &= " AND ( RIGHTLINEPARTNUMBER='" & txtPnOfLineThree.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTWO='" & txtPnOfLineThree.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTHREE='" & txtPnOfLineThree.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERFOUR='" & txtPnOfLineThree.Text & "')" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                sql &= " AND RIGHTLINEPARTNUMBERTHREE IN(" & GetPns() & ")" & vbNewLine
            End If
        Else
            sql &= " AND RIGHTLINEPARTNUMBERTHREE IS NULL "
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            sql &= " AND ( RIGHTLINEPARTNUMBER='" & txtPnOfLineFour.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTWO='" & txtPnOfLineFour.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTHREE='" & txtPnOfLineFour.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERFOUR='" & txtPnOfLineFour.Text & "')" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                sql &= " AND RIGHTLINEPARTNUMBERFOUR IN(" & GetPns() & ")" & vbNewLine
            End If
        Else
            sql &= " AND RIGHTLINEPARTNUMBERFOUR IS NULL "
        End If
        Return sql
    End Function

    Private Function GetLeftSqlWhereByWirePartNumber()
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            sql &= " AND ( A.LEFTLINEPARTNUMBER=B.WIREPARTNUMBER " & vbNewLine
            sql &= " OR A.LEFTLINEPARTNUMBERTWO=B.WIREPARTNUMBER" & vbNewLine
            sql &= " OR A.LEFTLINEPARTNUMBERTHREE=B.WIREPARTNUMBER " & vbNewLine
            sql &= " OR A.LEFTLINEPARTNUMBERFOUR=B.WIREPARTNUMBER )" & vbNewLine
        Else
            sql &= " AND A.LEFTLINEPARTNUMBER IS NULL"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            sql &= " AND ( A.LEFTLINEPARTNUMBER=B.WIREPARTNUMBERTWO" & vbNewLine
            sql &= " OR A.LEFTLINEPARTNUMBERTWO=B.WIREPARTNUMBERTWO" & vbNewLine
            sql &= " OR A.LEFTLINEPARTNUMBERTHREE=B.WIREPARTNUMBERTWO" & vbNewLine
            sql &= " OR A.LEFTLINEPARTNUMBERFOUR=B.WIREPARTNUMBERTWO)" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql &= " AND A.LEFTLINEPARTNUMBERTWO IN(" & GetPns() & ")" & vbNewLine
            End If
        Else
            sql &= " AND A.LEFTLINEPARTNUMBERTWO IS NULL"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            sql &= " AND ( A.LEFTLINEPARTNUMBER=B.WIREPARTNUMBERTHREE" & vbNewLine
            sql &= " OR A.LEFTLINEPARTNUMBERTWO=B.WIREPARTNUMBERTHREE" & vbNewLine
            sql &= " OR A.LEFTLINEPARTNUMBERTHREE=B.WIREPARTNUMBERTHREE" & vbNewLine
            sql &= " OR A.LEFTLINEPARTNUMBERFOUR=B.WIREPARTNUMBERTHREE)" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                sql &= " AND A.LEFTLINEPARTNUMBERTHREE IN(" & GetPns() & ")" & vbNewLine
            End If
        Else
            sql &= " AND A.LEFTLINEPARTNUMBERTHREE IS NULL"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            sql &= " AND ( A.LEFTLINEPARTNUMBER=B.WIREPARTNUMBERFOUR" & vbNewLine
            sql &= " OR A.LEFTLINEPARTNUMBERTWO=B.WIREPARTNUMBERFOUR" & vbNewLine
            sql &= " OR A.LEFTLINEPARTNUMBERTHREE=B.WIREPARTNUMBERFOUR" & vbNewLine
            sql &= " OR A.LEFTLINEPARTNUMBERFOUR=B.WIREPARTNUMBERFOUR)" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                sql &= " AND A.LEFTLINEPARTNUMBERFOUR IN(" & GetPns() & ")" & vbNewLine
            End If
        Else
            sql &= " AND A.LEFTLINEPARTNUMBERFOUR IS NULL"
        End If
        Return sql

    End Function

    Private Function GetRightSqlWhereByWirePartNumber()
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            sql &= " AND ( A.RIGHTLINEPARTNUMBER=C.WIREPARTNUMBER " & vbNewLine
            sql &= " OR A.RIGHTLINEPARTNUMBERTWO=C.WIREPARTNUMBER" & vbNewLine
            sql &= " OR A.RIGHTLINEPARTNUMBERTHREE=C.WIREPARTNUMBER " & vbNewLine
            sql &= " OR A.RIGHTLINEPARTNUMBERFOUR=C.WIREPARTNUMBER )" & vbNewLine
        Else
            sql &= "  AND A.RIGHTLINEPARTNUMBER IS NULL"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            sql &= " AND ( A.RIGHTLINEPARTNUMBER=C.WIREPARTNUMBERTWO" & vbNewLine
            sql &= " OR A.RIGHTLINEPARTNUMBERTWO=C.WIREPARTNUMBERTWO" & vbNewLine
            sql &= " OR A.RIGHTLINEPARTNUMBERTHREE=C.WIREPARTNUMBERTWO" & vbNewLine
            sql &= " OR A.RIGHTLINEPARTNUMBERFOUR=C.WIREPARTNUMBERTWO)" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql &= " AND A.RIGHTLINEPARTNUMBERTWO IN(" & GetPns() & ")" & vbNewLine
            End If
        Else
            sql &= " AND A.RIGHTLINEPARTNUMBERTWO IS NULL"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            sql &= " AND ( A.RIGHTLINEPARTNUMBER=C.WIREPARTNUMBERTHREE" & vbNewLine
            sql &= " OR A.RIGHTLINEPARTNUMBERTWO=C.WIREPARTNUMBERTHREE" & vbNewLine
            sql &= " OR A.RIGHTLINEPARTNUMBERTHREE=C.WIREPARTNUMBERTHREE" & vbNewLine
            sql &= " OR A.RIGHTLINEPARTNUMBERFOUR=C.WIREPARTNUMBERTHREE)" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                sql &= " AND A.RIGHTLINEPARTNUMBERTHREE IN(" & GetPns() & ")" & vbNewLine
            End If
        Else
            sql &= " AND A.RIGHTLINEPARTNUMBERTHREE IS NULL"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            sql &= " AND ( A.RIGHTLINEPARTNUMBER=C.WIREPARTNUMBERFOUR" & vbNewLine
            sql &= " OR A.RIGHTLINEPARTNUMBERTWO=C.WIREPARTNUMBERFOUR" & vbNewLine
            sql &= " OR A.RIGHTLINEPARTNUMBERTHREE=C.WIREPARTNUMBERFOUR" & vbNewLine
            sql &= " OR A.RIGHTLINEPARTNUMBERFOUR=C.WIREPARTNUMBERFOUR)" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                sql &= " AND A.RIGHTLINEPARTNUMBERFOUR IN(" & GetPns() & ")" & vbNewLine
            End If
        Else
            sql &= " AND A.RIGHTLINEPARTNUMBERFOUR IS NULL"
        End If
        Return sql

    End Function

    Private Function GetLeftCutSqlWhere()
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            sql &= " AND ( LEFTLINEPARTNUMBER='" & txtPnOfLine.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTWO='" & txtPnOfLine.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTHREE='" & txtPnOfLine.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERFOUR='" & txtPnOfLine.Text & "')" & vbNewLine
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            sql &= " AND ( LEFTLINEPARTNUMBER='" & txtPnOfLineTwo.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTWO='" & txtPnOfLineTwo.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTHREE='" & txtPnOfLineTwo.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERFOUR='" & txtPnOfLineTwo.Text & "')" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql &= " AND LEFTLINEPARTNUMBERTWO IN(" & GetPns() & ")" & vbNewLine
            End If
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            sql &= " AND ( LEFTLINEPARTNUMBER='" & txtPnOfLineThree.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTWO='" & txtPnOfLineThree.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTHREE='" & txtPnOfLineThree.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERFOUR='" & txtPnOfLineThree.Text & "')" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                sql &= " AND LEFTLINEPARTNUMBERTHREE IN(" & GetPns() & ")" & vbNewLine
            End If
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            sql &= " AND ( LEFTLINEPARTNUMBER='" & txtPnOfLineFour.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTWO='" & txtPnOfLineFour.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERTHREE='" & txtPnOfLineFour.Text & "'" & vbNewLine
            sql &= " OR LEFTLINEPARTNUMBERFOUR='" & txtPnOfLineFour.Text & "')" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                sql &= " AND LEFTLINEPARTNUMBERFOUR IN(" & GetPns() & ")" & vbNewLine
            End If
        End If
        Return sql
    End Function

    Private Function GetRightCutSqlWhere()
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            sql &= " AND ( RIGHTLINEPARTNUMBER='" & txtPnOfLine.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTWO='" & txtPnOfLine.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTHREE='" & txtPnOfLine.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERFOUR='" & txtPnOfLine.Text & "')" & vbNewLine
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            sql &= " AND ( RIGHTLINEPARTNUMBER='" & txtPnOfLineTwo.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTWO='" & txtPnOfLineTwo.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTHREE='" & txtPnOfLineTwo.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERFOUR='" & txtPnOfLineTwo.Text & "')" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql &= " AND RIGHTLINEPARTNUMBERTWO IN(" & GetPns() & ")" & vbNewLine
            End If
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            sql &= " AND ( RIGHTLINEPARTNUMBER='" & txtPnOfLineThree.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTWO='" & txtPnOfLineThree.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTHREE='" & txtPnOfLineThree.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERFOUR='" & txtPnOfLineThree.Text & "')" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                sql &= " AND RIGHTLINEPARTNUMBERTHREE IN(" & GetPns() & ")" & vbNewLine
            End If
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            sql &= " AND ( RIGHTLINEPARTNUMBER='" & txtPnOfLineFour.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTWO='" & txtPnOfLineFour.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERTHREE='" & txtPnOfLineFour.Text & "'" & vbNewLine
            sql &= " OR RIGHTLINEPARTNUMBERFOUR='" & txtPnOfLineFour.Text & "')" & vbNewLine
            If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                sql &= " AND RIGHTLINEPARTNUMBERFOUR IN(" & GetPns() & ")" & vbNewLine
            End If
        End If
        Return sql
    End Function

    Private Sub dgvCD_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCD.CellClick
        Try
            If dgvCD.Rows.Count <= 0 Then Exit Sub
            Me.lblID.Text = Me.dgvCD.Item(CDGrid.ID, dgvCD.CurrentRow.Index).Value.ToString()
            Me.txtCDFinishSizeMin.Text = Me.dgvCD.Item(CDGrid.FinishMin, dgvCD.CurrentRow.Index).Value.ToString()
            Me.txtCDFinishSizeMax.Text = Me.dgvCD.Item(CDGrid.FinishMax, dgvCD.CurrentRow.Index).Value.ToString()
            Me.txtCDHWFinishStandard.Text = Me.dgvCD.Item(CDGrid.HWSize, dgvCD.CurrentRow.Index).Value.ToString()
            Me.txtCDEmFinishStandard.Text = Me.dgvCD.Item(CDGrid.EmSize, dgvCD.CurrentRow.Index).Value.ToString()
            Me.txtCDOtherFinishStandard.Text = Me.dgvCD.Item(CDGrid.OtherSize, dgvCD.CurrentRow.Index).Value.ToString()
            Me.txtCDCutSize.Text = Me.dgvCD.Item(CDGrid.CutSizeMin, dgvCD.CurrentRow.Index).Value.ToString
            Me.txtToleranceRange.Text = Me.dgvCD.Item(CDGrid.Tolerance, dgvCD.CurrentRow.Index).Value.ToString
            Me.cdCobStatus.SelectedIndex = Me.cdCobStatus.FindString(Me.dgvCD.Item(CDGrid.Status1, dgvCD.CurrentRow.Index).Value.ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Enum CDGrid
        Seq = 0
        ID
        FinishMin
        FinishMax
        HWSize
        EmSize
        OtherSize
        CutSizeMin
        Tolerance
        CreateTime
        CreateUser
        Status1
        Status
    End Enum

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            If TabControl1.SelectedIndex = 0 Then
                PagerPaging.ResetPagerParameters("创建时间 desc", Me.dgvProcessParameter)
                AddHandler Me.dgvProcessParameter.ColumnHeaderMouseClick, AddressOf Me.PagerPaging.OnSortCommand
                RemoveHandler Me.dgvCD.ColumnHeaderMouseClick, AddressOf Me.PagerPaging.OnSortCommand
            ElseIf TabControl1.SelectedIndex = 1 Then
                PagerPaging.ResetPagerParameters("创建时间 desc", Me.dgvCD)
                RemoveHandler Me.dgvProcessParameter.ColumnHeaderMouseClick, AddressOf Me.PagerPaging.OnSortCommand
                AddHandler Me.dgvCD.ColumnHeaderMouseClick, AddressOf Me.PagerPaging.OnSortCommand
            End If
            PagerPaging.LoadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class