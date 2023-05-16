Imports SysBasicClass
Imports MainFrame.SysDataHandle
Imports System
Imports System.Configuration
Imports System.Windows.Forms.Control

Public Class FrmMaintainBom

    Public Enum ChooseAction
        Query = 0
        Download
        Save
        Cancel
    End Enum

    Public Enum BomInfo
        ID = 0
        ParentPartId
        ChildPartId
        Version
        PFormat
        CFormat
        ParentDescription
        ChildDescription
        EffectiveDate
        ExpirationDate
        Extensible
        ExtensibleF
        Qty
    End Enum


    Private Sub FrmMaintainBom_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetControlsStatus(ChooseAction.Download)
        LoadBomIntoDataGridView()
        btnSave.Enabled = False
    End Sub

    Private Sub SetControlsStatus(ByVal actionFlag As ChooseAction)
        Select Case actionFlag
            Case ChooseAction.Query
                txtErpPartID.Enabled = False
                txtPPID.Enabled = True
                txtCPID.Enabled = True
                cboStatus.Enabled = True
                btnDownloadFromERP.Enabled = False
                btnCancel.Enabled = True
                btnSave.Enabled = False
            Case ChooseAction.Download, ChooseAction.Save
                txtErpPartID.Enabled = True
                txtPPID.Enabled = False
                txtCPID.Enabled = False
                cboStatus.Enabled = False
                btnCancel.Enabled = True
                btnQuery.Enabled = False
            Case ChooseAction.Cancel
                txtErpPartID.Enabled = Not txtErpPartID.Enabled
                txtPPID.Enabled = Not txtPPID.Enabled
                txtCPID.Enabled = Not txtCPID.Enabled
                cboStatus.Enabled = Not cboStatus.Enabled
                btnQuery.Enabled = Not btnQuery.Enabled
                btnDownloadFromERP.Enabled = Not btnDownloadFromERP.Enabled
                btnSave.Enabled = False
        End Select
    End Sub
    Private Sub SetDataStyle()
        dgvBomInfo.Columns(BomInfo.ParentPartId).SortMode = DataGridViewColumnSortMode.Automatic
        dgvBomInfo.Columns(BomInfo.ChildPartId).SortMode = DataGridViewColumnSortMode.Automatic
        dgvBomInfo.Columns(BomInfo.Extensible).SortMode = DataGridViewColumnSortMode.Automatic
    End Sub

    Private Sub LoadBomIntoDataGridView(Optional ByVal sqlWhere As String = "")
        Try
            Dim sqlConn As New SysDataBaseClass
            Using dt As DataTable = sqlConn.GetDataTable(GetSqlString(sqlWhere))
                dgvBomInfo.DataSource = dt
                ToolStripStatusLabel1.Text = "总共笔数:" & dt.Rows.Count.ToString & "笔"
            End Using
            'SetDataStyle()
        Catch ex As Exception
            lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Function GetSqlString(ByVal sqlWhere As String) As String
        Dim sql As String = ""
        sql = "SELECT TOP 180 ROW_NUMBER() OVER(ORDER BY B.PARTNUMBER,C.PARTNUMBER) 序号,B.PARTNUMBER 父料件编号,C.PARTNUMBER 子料件编号,FORMAT 规格," & _
              "CASE A.STATUS WHEN 1 THEN '1.有效' ELSE '0.无效' END 状态," & _
              "CASE A.EXTENSIBLE WHEN 'Y' THEN N'Y.可展开' ELSE N'N.不展开' END 可展开否,QTY 数量," & _
              "EFFECTIVEDATE 有效开始日期, EXPIRATIONDATE 失效日期," & _
              "A.USERID 维护人员,A.INTIME 维护日期 FROM M_BOM_T A,M_PARTNUMBER_T B,M_PARTNUMBER_T  C" & _
              " WHERE A.PARENTPARTID =B.ID " & _
              " AND A.PARTID=C.ID "
        If sqlWhere <> "" Then
            sql += sqlWhere
        End If
        'sql += " ORDER BY 父料件编号,子料件编号,可展开否"
        Return sql
    End Function

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Try
            SetControlsStatus(ChooseAction.Query)
            Dim sqlWhere As String = ""
            If txtPPID.Text.Trim <> "" Then
                sqlWhere += " AND B.PARTNUMBER LIKE'" & txtPPID.Text.Trim & "%'"
            End If
            If txtCPID.Text.Trim <> "" Then
                sqlWhere += " AND C.PARTNUMBER LIKE'" & txtCPID.Text.Trim & "%'"
            End If
            If cboStatus.SelectedItem <> Nothing AndAlso cboStatus.SelectedItem.ToString <> "" Then
                sqlWhere += " AND A.EXTENSIBLE='" & cboStatus.SelectedItem.ToString.Substring(0, 1) & "'"
            End If
            LoadBomIntoDataGridView(sqlWhere)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnDownloadFromERP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownloadFromERP.Click
        Try
            SetControlsStatus(ChooseAction.Download)
            If isBasicCheck() Then
                LoadBomIntoDataGridViewFromErp()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function isBasicCheck() As Boolean
        If txtErpPartID.Text = "" Then
            lblMsg.Text = "料件编号不能为空"
            MessageBox.Show("料件编号不能为空", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtErpPartID.Focus()
            Return False
        End If
        'If txtGroupCode.Text.Trim = "" Then
        '    lblMsg.Text = "请维护需要下载的分群码"
        '    txtGroupCode.Focus()
        '    Return False
        'End If
        Return True
    End Function

    Private Sub LoadBomIntoDataGridViewFromErp()
        Try
            Dim oracleConn As New OracleDb("")
            Using dt As DataTable = oracleConn.ExecuteQuery(GetErpFilterSql()).Tables(0)
                dgvBomInfo.DataSource = dt
                ToolStripStatusLabel1.Text = "总共笔数:" & dt.Rows.Count.ToString & "笔"
                SetDataGridViewStyle()
            End Using
            If dgvBomInfo.Rows.Count = 0 Then
                lblMsg.Text = "ERP中找不到该料件的信息..."
                MessageBox.Show("ERP中找不到该料件的信息...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnSave.Enabled = False
                Exit Sub
            End If
            lblMsg.Text = "该料件在ERP中的数据如下表所示..."
            btnSave.Enabled = True
        Catch ex As Exception
            lblMsg.Text = ex.Message
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetErpFilterSql() As String
        txtGroupCode.Text = ""
        Dim querySql As String = "SELECT ROW_NUMBER() OVER(ORDER BY A.BMB01) ID,A.BMB01,A.BMB03,B.IMA05,B.IMA021,C.IMA021,B.IMA02,C.IMA02," & _
        "A.BMB04,A.BMB05,DECODE(A.BMB19,3,'Y','N'),DECODE(A.BMB19,3,'Y.可展開','N.不展開') EXTENSIABLE,A.BMB06 " & _
        " FROM(" & _
        "SELECT A.BMB01,A.BMB03,A.BMB19,A.BMB06,TO_CHAR(A.BMB04,'YYYY/MM/DD') BMB04,TO_CHAR(A.BMB05,'YYYY/MM/DD') BMB05 " & _
        "FROM BMB_FILE A " & _
        "CONNECT BY prior A.BMB03=A.BMB01 AND LEVEL<3" & _
        "START WITH A.BMB01='" & txtErpPartID.Text.Trim & "') A,IMA_FILE B,IMA_FILE C " & _
        "WHERE A.BMB01=B.IMA01 " & _
        "AND A.BMB03=C.IMA01 " & _
        "AND A.BMB04<=TO_CHAR(SYSDATE,'YYYY/MM/DD') AND (A.BMB05 IS NULL OR A.BMB05>TO_CHAR(SYSDATE,'YYYY/MM/DD'))"
        Dim codes As String = ""
        Dim xd As New Xml.XmlDocument()
        If System.IO.File.Exists("BasicManagementSetting.xml") Then
            xd.Load("BasicManagementSetting.xml")
            Dim xns As Xml.XmlNodeList = xd.SelectSingleNode("fileList").ChildNodes
            For Each xn As Xml.XmlNode In xns
                If xn.Name = "GroupCode" Then
                    txtGroupCode.Text = xn.InnerText
                    Exit For
                End If
            Next
            If txtGroupCode.Text.Trim <> "" Then
                For Each code As String In txtGroupCode.Text.Split(",")
                    If code <> "" Then
                        codes += "'" + code + "',"
                    End If
                Next
                querySql += " AND C.IMA06 IN(" & codes.Trim(",") & ")"
            End If
        End If

        querySql += " ORDER BY A.BMB01"
        Return querySql
    End Function

    Private Sub SetDataGridViewStyle()
        dgvBomInfo.Columns(BomInfo.ID).HeaderText = "序号"
        dgvBomInfo.Columns(BomInfo.ParentPartId).HeaderText = "父料件编号"
        dgvBomInfo.Columns(BomInfo.ChildPartId).HeaderText = "子料件编号"
        dgvBomInfo.Columns(BomInfo.ParentDescription).Visible = False
        dgvBomInfo.Columns(BomInfo.ChildDescription).Visible = False
        dgvBomInfo.Columns(BomInfo.EffectiveDate).HeaderText = "有效开始日期"
        dgvBomInfo.Columns(BomInfo.ExpirationDate).HeaderText = "失效日期"
        dgvBomInfo.Columns(BomInfo.Extensible).Visible = False
        dgvBomInfo.Columns(BomInfo.ExtensibleF).HeaderText = "可展开否"
        dgvBomInfo.Columns(BomInfo.Qty).HeaderText = "数量"
        dgvBomInfo.Columns(BomInfo.PFormat).HeaderText = "规格"
        dgvBomInfo.Columns(BomInfo.Version).Visible = False
        dgvBomInfo.Columns(BomInfo.PFormat).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvBomInfo.Columns(BomInfo.CFormat).HeaderText = "规格"
        dgvBomInfo.Columns(BomInfo.CFormat).Visible = False
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        SetControlsStatus(ChooseAction.Cancel)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If dgvBomInfo.Rows.Count = 0 Then
                lblMsg.Text = "请先从ERP中下载料件信息"
            Else
                If PnExistsInBom() Then
                    If MessageBox.Show("已经存在该料件信息，确认是否需要重新下载;如需要,请检查该料号下面子件的版本信息！！！", "警告", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                        SaveBomInfoToDb(True)
                    End If
                Else
                    SaveBomInfoToDb(False)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function PnExistsInBom() As Boolean
        Dim sqlConn As New SysDataBaseClass
        Dim sql = "SELECT A.PARTNUMBER FROM M_PARTNUMBER_T A,M_BOM_T B" & _
                  " WHERE A.PARTNUMBER='" & txtErpPartID.Text.Trim & "' AND " & _
                  " EXISTS (SELECT 1 FROM M_BOM_T WHERE PARENTPARTID=A.ID)"
        Return sqlConn.GetRowsCount(sql) > 0
    End Function

    Private Sub SaveBomInfoToDb(ByVal isPnExists As Boolean)
        Dim sqlConn As New SysDataBaseClass
        Dim sql As New System.Text.StringBuilder(1024)

        Try
            If dgvBomInfo.Rows.Count = 0 Then
                MessageBox.Show("请先下载料件信息", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblMsg.Text = "请先下载料件信息"
                Exit Sub
            End If
            sql.Append(" DELETE FROM M_BOM_T WHERE PARENTPARTID IN(SELECT A.PARTID FROM M_BOM_T A,M_BOM_T B,M_PARTNUMBER_T C WHERE A.PARTID=B.PARENTPARTID AND A.PARENTPARTID=C.ID AND C.PARTNUMBER='" & txtErpPartID.Text.Trim & "')").Append(vbNewLine)
            sql.Append(" DELETE FROM M_BOM_T WHERE PARENTPARTID IN (SELECT ID FROM M_PARTNUMBER_T WHERE PARTNUMBER='" & txtErpPartID.Text.Trim & "')").Append(vbNewLine)
            For Each Row As DataGridViewRow In dgvBomInfo.Rows
                If Row.Index = dgvBomInfo.Rows.Count Then Exit For
                sql.Append(" IF NOT EXISTS(SELECT 1 FROM M_PARTNUMBER_T WHERE PARTNUMBER='" & Row.Cells(BomInfo.ParentPartId).Value & "') begin").Append(vbNewLine)
                sql.Append(" INSERT INTO M_PARTNUMBER_T(PARTNUMBER,DESCRIPTION,STATUS,USERID,INTIME,DESCRIPTION1,TYPE) VALUES('" & Row.Cells(BomInfo.ParentPartId).Value & "',").Append(vbNewLine)
                sql.Append(" N'" & Row.Cells(BomInfo.ParentDescription).Value.ToString.Replace("'", "''") & "','1','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & Row.Cells(BomInfo.PFormat).Value.ToString.Replace("'", "''") & "','R') end ").Append(vbNewLine)
                sql.Append(" ELSE BEGIN UPDATE M_PARTNUMBER_T SET DESCRIPTION=N'" & Row.Cells(BomInfo.ParentDescription).Value.ToString.Replace("'", "''") & "',DESCRIPTION1=N'" & Row.Cells(BomInfo.PFormat).Value.ToString.Replace("'", "''") & "' WHERE PARTNUMBER='" & Row.Cells(BomInfo.ParentPartId).Value & "' END").Append(vbNewLine)
                sql.Append(" IF NOT EXISTS(SELECT 1 FROM M_PARTNUMBER_T WHERE PARTNUMBER='" & Row.Cells(BomInfo.ChildPartId).Value & "') begin").Append(vbNewLine)
                sql.Append(" INSERT INTO M_PARTNUMBER_T(PARTNUMBER,DESCRIPTION,STATUS,USERID,INTIME,DESCRIPTION1,TYPE) VALUES('" & Row.Cells(BomInfo.ChildPartId).Value & "',").Append(vbNewLine)
                sql.Append(" N'" & Row.Cells(BomInfo.ChildDescription).Value.ToString.Replace("'", "''") & "','1','" & VbCommClass.VbCommClass.UseId & "',getdate(),N'" & Row.Cells(BomInfo.CFormat).Value.ToString.Replace("'", "''") & "','R') end").Append(vbNewLine)
                sql.Append(" ELSE BEGIN UPDATE M_PARTNUMBER_T SET DESCRIPTION=N'" & Row.Cells(BomInfo.ChildDescription).Value.ToString.Replace("'", "''") & "',DESCRIPTION1=N'" & Row.Cells(BomInfo.CFormat).Value.ToString.Replace("'", "''") & "' WHERE PARTNUMBER='" & Row.Cells(BomInfo.ChildPartId).Value & "' END").Append(vbNewLine)
                sql.Append(" IF NOT EXISTS(SELECT 1 FROM M_BOM_T WHERE PARENTPARTID=(SELECT TOP 1 ID FROM M_PARTNUMBER_T WHERE PARTNUMBER='" & Row.Cells(BomInfo.ParentPartId).Value & "') AND PARTID=(SELECT TOP 1 ID FROM M_PARTNUMBER_T WHERE PARTNUMBER='" & Row.Cells(BomInfo.ChildPartId).Value & "')) begin").Append(vbNewLine)
                sql.Append(" INSERT INTO M_BOM_T(PARENTPARTID,PARTID,STATUS,USERID,INTIME,EXTENSIBLE,QTY,EFFECTIVEDATE,EXPIRATIONDATE,VERSION,FORMAT) ").Append(vbNewLine)
                sql.Append(" VALUES((SELECT TOP 1 ID FROM M_PARTNUMBER_T WHERE PARTNUMBER='" & Row.Cells(BomInfo.ParentPartId).Value & "'),").Append(vbNewLine)
                sql.Append("(SELECT TOP 1 ID FROM M_PARTNUMBER_T WHERE PARTNUMBER='" & Row.Cells(BomInfo.ChildPartId).Value & "'),'1','" & VbCommClass.VbCommClass.UseId & "',getdate(),'" & Row.Cells(BomInfo.Extensible).Value & "','" & Row.Cells(BomInfo.Qty).Value & "'").Append(vbNewLine)
                sql.Append(",'" & Row.Cells(BomInfo.EffectiveDate).Value & "','" & Row.Cells(BomInfo.ExpirationDate).Value & "','" & Row.Cells(BomInfo.Version).Value & "',N'" & Row.Cells(BomInfo.PFormat).Value & "') end").Append(vbNewLine)
                sql.Append(" ELSE BEGIN UPDATE M_BOM_T SET QTY='" & Row.Cells(BomInfo.Qty).Value & "',EXTENSIBLE='" & Row.Cells(BomInfo.Extensible).Value & "'").Append(vbNewLine)
                sql.Append(",EFFECTIVEDATE='" & Row.Cells(BomInfo.EffectiveDate).Value & "',EXPIRATIONDATE='" & Row.Cells(BomInfo.ExpirationDate).Value & "'").Append(vbNewLine)
                sql.Append(",VERSION='" & Row.Cells(BomInfo.Version).Value & "',USERID='" & VbCommClass.VbCommClass.UseId & "',INTIME=getdate(),FORMAT=N'" & Row.Cells(BomInfo.PFormat).Value & "'").Append(vbNewLine)
                sql.Append(" WHERE PARENTPARTID=(SELECT TOP 1 ID FROM M_PARTNUMBER_T WHERE PARTNUMBER='" & Row.Cells(BomInfo.ParentPartId).Value & "') ").Append(vbNewLine)
                sql.Append(" AND PARTID=(SELECT TOP 1 ID FROM M_PARTNUMBER_T WHERE PARTNUMBER='" & Row.Cells(BomInfo.ChildPartId).Value & "') end").Append(vbNewLine)
            Next
            sqlConn.ExecSql(sql.ToString)
            MessageBox.Show("资料保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblMsg.Text = "资料保存成功"
            txtErpPartID.Focus()
            txtErpPartID.SelectAll()
            LoadBomIntoDataGridView()
            btnSave.Enabled = False
        Catch ex As Exception
            lblMsg.Text = ex.Message
        End Try

    End Sub


    Private Sub txtErpPartID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtErpPartID.KeyPress
        If e.KeyChar = Chr(13) Then
            btnDownloadFromERP_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtGroupCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGroupCode.KeyPress
        If e.KeyChar = Chr(13) Then
            btnDownloadFromERP_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtPPID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPPID.KeyPress
        If e.KeyChar = Chr(13) Then
            txtCPID.Focus()
        End If
    End Sub
End Class