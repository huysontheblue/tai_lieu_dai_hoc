''替換打印    歐翔烽   2007/05/16

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text

#End Region

Public Class FrmReplaceLock

    Dim QtyStr As String = ""
    Dim BarRuleStr As String = ""

#Region "窗體按鈕事件"

    Private Sub BnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnCancel.Click

        Me.Close()
        ScanPrint.ReplacePrintCheck = False

    End Sub

#End Region

    Private Sub TxtPassWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassWord.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.ActiveControl = BnOpenlock
            BnOpenlock_Click(sender, e)
        End If

    End Sub

    Private Sub BnOpenlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BnOpenlock.Click

        Dim LoginClass As New TextHandle
        Dim CheckRead As SqlClient.SqlDataReader
        Dim PubClass As New SysDataBaseClass

        ''ScanPrint.vReplaceMo = Nothing
        CheckRead = PubClass.GetDataReader("select distinct a.* from m_Users_t a left join m_userright_t b on a.userid=b.userid where  a.autoid='" & Me.TxtPassWord.Text & "' and b.tkey='m0510c_'")
        If Not CheckRead.Read Then
            MessageBox.Show("密碼不正確或無權限！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ScanPrint.ReplacePrintCheck = False
            CheckRead.Close()
            Me.TxtPassWord.Focus()
            Me.TxtPassWord.SelectAll()
            Exit Sub
        End If
        CheckRead.Close()

        CheckRead = PubClass.GetDataReader("select * from m_carton_t where cartonid='" & TxtPackNo.Text.Trim & "' and CartonStatus='Y'")
        If Not CheckRead.Read Then
            MessageBox.Show("不存在該箱號或箱號狀態不符！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ScanPrint.ReplacePrintCheck = False
            CheckRead.Close()
            Me.TxtPackNo.Focus()
            Me.TxtPackNo.SelectAll()
            Exit Sub
        ElseIf ScanPrint.vReplaceMo <> Trim(CheckRead("moid").ToString) Then
            MessageBox.Show("設置資料的工單與需要替換的箱號對應的工單不一致。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ScanPrint.ReplacePrintCheck = False
            CheckRead.Close()
            Me.TxtPackNo.Focus()
            Me.TxtPackNo.SelectAll()
            Exit Sub
        Else
            If LCase(BarRuleStr) = "c001" Then
                ScanPrint.vReplaceQty = Microsoft.VisualBasic.Right(StrDup(3, "0") & CheckRead("Cartonqty").ToString, 3)
            Else
                ScanPrint.vReplaceQty = CheckRead("Cartonqty").ToString
            End If
            ScanPrint.vReplaceMo = Trim(CheckRead("moid"))
        End If
        CheckRead.Close()
        ScanPrint.ReplacePrintCheck = True
        Me.Close()

    End Sub

    Private Sub FrmReplaceLock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Me.ActiveControl.Name <> "BnOpenlock" Then ScanPrint.ReplacePrintCheck = False

    End Sub

    Private Sub FrmReplaceLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim SqlStr As String
        Dim PubClass As New SysDataBaseClass
        Dim Dr As SqlClient.SqlDataReader
        SqlStr = "select * from m_PartPack_t where packid='C' and partid='" & ScanPrint.PartidStr & " '  and usey='Y' "
        Dr = PubClass.GetDataReader(SqlStr)
        If Dr.Read Then
            QtyStr = Dr("Qty").ToString
            BarRuleStr = Dr("coderuleid").ToString
        End If
        Dr.Close()

    End Sub

    Private Sub TxtPackNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPackNo.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.TxtPassWord.Focus()
        End If

    End Sub

End Class