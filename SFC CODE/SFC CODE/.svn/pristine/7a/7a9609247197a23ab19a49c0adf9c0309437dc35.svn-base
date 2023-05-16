'--打印机设置
'--Create by :　马锋
'--Create date :　2014/09/22
'--Update date :  
'--Ver : V01

#Region "Imports"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Reflection
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports BarCodePrint

#End Region

Public Class FrmPrinterMaster

    Dim opFlag As Int16 = 0

    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click
        opFlag = 1
        SetState(opFlag)
        ClearObject()
    End Sub

    Private Sub ToolEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEdit.Click
        opFlag = 2
        SetState(opFlag)

        Me.txtPrintName.Text = Me.dgvPrintList.Item(1, Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim()
        Me.txtPrintIP.Text = Me.dgvPrintList.Item(2, Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim()
        Me.cboPrintType.Text = Me.dgvPrintList.Item(3, Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim()
        Me.cbxStatus.Checked = IIf(Me.dgvPrintList.Item(4, Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim() = "1", True, False)
        'Me.dgvPrintList.Item(4, Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim()=1 ? true :false

    End Sub

    '作废
    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancel.Click
        
    End Sub

    Private Sub ToolCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCommit.Click
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            If Checkdata() = False Then
                Conn = Nothing
                Exit Sub
            End If

            Dim dvTemp As DataTable

            If (opFlag = 1) Then
                dvTemp = Conn.GetDataTable("SELECT IDE FROM W_PRINTER_T WHERE PRINT_NAME=N'" & Me.txtPrintName.Text.Trim & "' OR PRINT_IP='" & Me.txtPrintIP.Text.Trim & "'")
            Else
                dvTemp = Conn.GetDataTable("SELECT IDE FROM W_PRINTER_T WHERE  IDE <> '" & Me.dgvPrintList.Item(0, Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim() & "'")
            End If

            'If (dvTemp.Rows.Count > 0) Then
            '    SetMessage("保存失败，打印名称或IP已经存在!")
            '    Exit Sub
            'End If

            If (opFlag = 1) Then
                Conn.ExecSql("INSERT INTO W_PRINTER_T(PRINT_NAME, PRINT_IP, PRINT_TYPE, STATUS, CREATE_USER, CREATE_TIME) VALUES(N'" & Me.txtPrintName.Text.Trim & "','" & Me.txtPrintIP.Text.Trim & "',N'" & Me.cboPrintType.SelectedItem.ToString.Trim & "','" & IIf(Me.cbxStatus.Checked, "1", "0") & "','" & SysMessageClass.UseId.ToLower.Trim & "',getdate())")
            Else
                Conn.ExecSql("UPDATE W_PRINTER_T SET PRINT_NAME=N'" & Me.txtPrintName.Text.Trim & "', PRINT_IP=N'" & Me.txtPrintIP.Text.Trim & "', PRINT_TYPE=N'" & Me.cboPrintType.SelectedItem.ToString.Trim & "', STATUS='" & IIf(Me.cbxStatus.Checked, "1", "0") & "' WHERE IDE='" & Me.dgvPrintList.Item(0, Me.dgvPrintList.CurrentRow.Index).Value.ToString.Trim() & "'")
            End If

            dvTemp = Nothing
            Conn = Nothing
            ClearObject()
            opFlag = 0
            SetState(0)
            GetPrinter()
        Catch ex As Exception
            Conn = Nothing
            SetMessage("保存失败，请联系开发人员!")
        End Try
    End Sub

    Private Sub ToolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBack.Click
        opFlag = 0
        SetState(opFlag)
        ClearObject()
    End Sub

    Private Sub ToolQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolQuery.Click
        GetPrinter()
    End Sub

    '按鈕狀態設置
    Private Sub SetState(ByVal flag As Integer)
        Select Case flag
            Case 0 '初始查詢狀態
                'IIf(Me.toolNew.Tag.ToString <> "Yes", False, True)
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.ToolCancel.Enabled = True
                Me.ToolCommit.Enabled = False
                Me.ToolBack.Enabled = False
                Me.ToolQuery.Enabled = True
                Me.dgvPrintList.Enabled = True
                Me.txtPrintName.Enabled = False
                Me.txtPrintIP.Enabled = False
                Me.cboPrintType.Enabled = False
                Me.cbxStatus.Enabled = False
            Case 1, 2 '新增/修改狀態
                Me.toolNew.Enabled = False
                Me.toolEdit.Enabled = False
                Me.ToolCancel.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolBack.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.dgvPrintList.Enabled = False
                Me.txtPrintName.Enabled = True
                Me.txtPrintIP.Enabled = True
                Me.cboPrintType.Enabled = True
                Me.cbxStatus.Enabled = True
        End Select
        SetMessage("")
    End Sub

    Private Sub FrmPrinterMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Erightbutton() '讀取按鈕權限
        opFlag = 0
        SetState(opFlag)
    End Sub

    '按鈕權限判斷
    Private Sub Erightbutton()
        Dim Conn As New SysDataBaseClass
        Dim Reader As SqlDataReader = Conn.GetDataReader("select b.Buttonid from m_UserRight_t as a join m_Logtree_t as b on a.Tkey=b.Tkey and b.Formid='apm02002' and b.listy='N' where a.userid='" & SysMessageClass.UseId.ToLower.Trim & "'")
        Dim Obj As Object
        While Reader.Read
            '通過控件名稱得到控件實例
            Obj = CType(Me.GetType().GetField("_" & Reader("Buttonid").ToString.Trim, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.IgnoreCase).GetValue(Me), Object)
            Obj.Tag = "Yes"
        End While
        Reader.Close()
    End Sub

    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    Private Sub ClearObject()

        Me.txtPrintName.Text = ""
        Me.txtPrintIP.Text = ""
        Me.cboPrintType.SelectedIndex = -1
        Me.cbxStatus.Checked = False
        Me.dgvPrintList.Rows.Clear()
        Me.txtPrintName.Focus()
    End Sub

    Private Sub GetPrinter()
        Dim strSQL As String
        strSQL = "SELECT   IDE, PRINT_NAME, PRINT_IP, PRINT_TYPE, STATUS, CREATE_USER, CREATE_TIME FROM W_PRINTER_T"
        LoadData(strSQL, Me.dgvPrintList)
    End Sub

    Private Sub LoadData(ByVal Sqlstr As String, ByVal dgvName As DataGridView)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim DReader As SqlClient.SqlDataReader
        Try
            dgvName.Rows.Clear()
            DReader = Conn.GetDataReader(Sqlstr)
            Do While DReader.Read()
                If dgvName Is Me.dgvPrintList Then
                    dgvName.Rows.Add(DReader.Item("IDE").ToString, DReader.Item("PRINT_NAME").ToString, DReader.Item("PRINT_IP").ToString, DReader.Item("PRINT_TYPE").ToString, DReader.Item("STATUS").ToString)
                End If
            Loop
            Me.ToolLblCount.Text = Me.dgvPrintList.Rows.Count
            DReader.Close()
            Conn = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function Checkdata() As Boolean
        If (String.IsNullOrEmpty(Me.txtPrintName.Text.Trim)) Then
            SetMessage("请输入打印机名称!")
            Return False
        End If

        If (String.IsNullOrEmpty(Me.txtPrintIP.Text.Trim)) Then
            SetMessage("请输入打印机IP地址!")
            Return False
        End If

        If (String.IsNullOrEmpty(Me.cboPrintType.SelectedItem.ToString.Trim)) Then
            SetMessage("请选择打印类型!")
            Return False
        End If

        Return True
    End Function

    Private Sub SetMessage(ByVal Message As String)
        Me.lblMessage.Text = Message
    End Sub

End Class