Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Text

Public Class FrmSetPNGroup

    Private _PackBarCode As String = String.Empty
    Private _strParentMO As String = String.Empty
    Public m_strPVersion As String = String.Empty
    Private currentValue As String = ""
    Private currentRowIndex As Integer = 0
    Private currentColumnIndex As Integer = 0
    Private currentColumnName As String = ""
    Public m_iChildPNCount As Integer
    Public m_strPPartID As String = String.Empty
    Public opflag As Int16 = 0  '

    Sub New(ByVal PackBarCode As String, ByVal strParentMO As String)
        _PackBarCode = PackBarCode
        _strParentMO = strParentMO
        InitializeComponent()
    End Sub

    Private Sub toolAdd_Click(sender As Object, e As EventArgs) Handles toolAdd.Click


    End Sub

    Private Sub FrmSetPNGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lsSQL As String = ""
        Try
            LblMsg.Text = ""

            lsSQL = "  SELECT  PARTID  FROM m_MainMO_t " & _
                    "  WHERE PARENTMO = '" & _strParentMO & "' " & _
                    "  AND  MOID <> PARENTMO  "


            FillGridCombox(Me.CobMPartID, lsSQL)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSetPNGroup", "FrmSetPNGroup_Load", "WIPS")
        End Try
    End Sub

    Private Sub FillGridCombox(ByVal CobName As ComboBox, ByVal SqlStr As String)

        Dim sConn As New SysDataBaseClass
        Dim ScanReader As SqlClient.SqlDataReader
        ScanReader = sConn.GetDataReader(SqlStr)
        CobName.Items.Clear()

        Do While ScanReader.Read()
            CobName.Items.Add(ScanReader(0).ToString)
        Loop
        ScanReader.Close()

    End Sub

    Private Sub CobCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CobMPartID.SelectedIndexChanged

        BindBomGrid()

    End Sub


    Private Sub BindBomGrid()
        Try
            Dim trSQL As String = Nothing

            trSQL = GetSQLGroup()

            ' 
            If dgvGroup.Rows.Count > 0 Then
                dgvGroup.Rows.Clear()
            End If

            Dim dt As DataTable = RCardComBusiness.GetDataTable(trSQL)
            For Each row As DataRow In dt.Rows
                dgvGroup.Rows.Add(row("Flag").ToString(), row("PartID").ToString())
            Next

            dgvGroup.Columns(1).ReadOnly = True
            ' dgvBomPart.Columns(2).ReadOnly = True
        Catch ex As Exception
            ' Throw ex
        End Try

        '"品名"列全屏显示
        'dgvBomPart.Columns("Bom_Description").AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    End Sub


    Private Function GetSQLGroup() As String
        Dim strSQL As String = String.Empty
        Dim strSQLPass As String = String.Empty

        If CStr(Me.CobMPartID.SelectedItem) <> String.Empty Then
            strSQLPass = " AND ISNULL(B.MPartID,'') = '" & Me.CobMPartID.SelectedItem & "'"
        End If


        'cq 20160711, remove  AND  Partid NOT  IN (SELECT  PartID FROM m_SetScanD_t Where packbarcode='" & _PackBarCode & "')" & _
        strSQL = "SELECT  Case WHEN B.CPartID IS NULL then 'N' else 'Y' end  Flag , A.PartID  " &
               "FROM ( SELECT  PARTID  FROM m_MainMO_t WHERE PARENTMO = '" & _strParentMO & "' " & _
                    "  AND  MOID <> PARENTMO  " & _
                     ") A LEFT JOIN  m_SetScanGroupPass_t B   ON A.PartID = B.CPartID  " & strSQLPass & _
                     " WHERE 1=1 "

        strSQL += " ORDER BY  a.PartID asc"

        GetSQLGroup = strSQL
    End Function

    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Dim strDeletesql As String = "", strInsertSql As String = "", strSql As String = ""
        Dim o_strSQL As New StringBuilder

        Try
            Dim strPPartID As String = Me.CobMPartID.SelectedItem.ToString.Substring(0, Me.CobMPartID.SelectedItem.ToString.IndexOf("-"))
            ' 904092189-14

            'strDeletesql = String.Format(" DELETE m_SetScanGroupPass_t where PPartID='{0}' and MPartID = '{1}' ",
            '                             strPPartID, Me.CobMPartID.SelectedItem)

            o_strSQL.Append(" DELETE m_SetScanGroupPass_t WHERE PPartID='" & strPPartID & "' AND MPartID = '" & Me.CobMPartID.SelectedItem & "'")

            ' strInsertSql = " INSERT INTO m_SetScanGroupPass_t(PPartID,MPartID,CPartID) VALUES("

            For Each row As DataGridViewRow In dgvGroup.Rows
                If CBool(row.Cells(0).EditedFormattedValue.ToString) = True OrElse row.Cells(0).Value.ToString = "Y" Then
                    'check whether already exist in the other group 
                    If IsExist(strPPartID, row.Cells(1).Value.ToString) Then
                        Continue For
                    End If

                    'strSql += strInsertSql + String.Format("'{0}','{1}','{2}')", strPPartID, Me.CobMPartID.SelectedItem,
                    '                         row.Cells(1).Value.ToString)

                    o_strSQL.Append(" INSERT INTO m_SetScanGroupPass_t(PPartID,MPartID,CPartID) VALUES( ")
                    o_strSQL.Append(" '" & strPPartID & "', '" & Me.CobMPartID.SelectedItem & "',  '" & row.Cells(1).Value.ToString & "') ")

                    o_strSQL.Append(" IF ISNULL((SELECT TOP 1 1 FROM m_SetScanD_t WHERE PartID ='" & row.Cells(1).Value.ToString & "'AND PackBarCode='" & _PackBarCode & "'),0)<>1 ")
                    o_strSQL.Append("  Begin")
                    o_strSQL.Append(" INSERT m_SetScanD_t (PartID, PPartID, Qty, ScanedQty,Intime, UserID, Packbarcode, sbarcode)")
                    o_strSQL.Append(" SELECT '" & row.Cells(1).Value.ToString & "' PartID, PPartID, Qty, ScanedQty,Intime, UserID, Packbarcode, sbarcode ")
                    o_strSQL.Append(" FROM m_SetScanD_t WHERE partid ='" & Me.CobMPartID.SelectedItem & "'  ")
                    o_strSQL.Append(" AND PackBarcode='" & _PackBarCode & "'")
                    o_strSQL.Append(" End")
                End If
            Next


            RCardComBusiness.ExecSQL(o_strSQL.ToString()) '该方法会执行事务处理

            opflag = 0
            ToolbtnState(0)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmSetPNGroup", "toolSave_Click", "WIP")
            ' Throw ex
        End Try
    End Sub

    Private Function IsExist(ByVal strPPartid As String, ByVal CPartID As String) As Boolean
        Dim lsSQL As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        lsSQL = " SELECT 1 FROM m_SetScanGroupPass_t  WHERE PPartid ='" & strPPartid & "' AND CPartid ='" & CPartID & "' "
        Using o_dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsExist = True
            Else
                IsExist = False
            End If
        End Using
        Return IsExist
    End Function

    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0
                Me.toolAdd.Enabled = IIf(Me.toolAdd.Tag.ToString <> "Yes", False, True)
                Me.toolEdit.Enabled = IIf(Me.toolEdit.Tag.ToString <> "Yes", False, True)
                '  Me.toolDelete.Enabled = True 'IIf(Me.toolDelete.Tag.ToString <> "Yes", False, True)  '借用 
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
            Case 1, 2  'New or Edit
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                ' Me.toolDelete.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
                'GroupBox
                '  Me.txtStationdest.Enabled = True
                '  Me.cboType.Enabled = IIf(opflag = 1, True, False)
                ' Me.BtnSelectSta.Enabled = IIf(opflag = 1, True, False)
            Case 3 '
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                ' Me.toolDelete.Enabled = False
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
                'GroupBox
                ' Me.cboType.Enabled = True
                Me.dgvRstation.Enabled = True
        End Select
    End Sub

    Private Sub FrmSetPNGroup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim iChildPNFinishQty As Integer = 0
        Dim strSQL As New StringBuilder
        Dim o_strExecutSQLResult As String = ""
        Try
            iChildPNFinishQty = SetScan.GetFinishChildPNQty(m_strPPartID, _PackBarCode)

            If iChildPNFinishQty = m_iChildPNCount Then
                'need update to 1.finish
                strSQL.Append(" Begin")
                strSQL.Append(" Update m_SetScanM_t Set Status='1', FinishTime=getdate() ")
                strSQL.Append("  Where PartID='" & m_strPPartID & "' And PackBarcode='" & _PackBarCode & "' ")
                strSQL.Append(" End")
                If Not String.IsNullOrEmpty(strSQL.ToString) Then
                    o_strExecutSQLResult = RCardComBusiness.ExecSQL(strSQL.ToString)
                    If o_strExecutSQLResult <> "" Then
                        MessageUtils.ShowError(o_strExecutSQLResult)
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            strSQL = Nothing
        End Try
    End Sub
End Class