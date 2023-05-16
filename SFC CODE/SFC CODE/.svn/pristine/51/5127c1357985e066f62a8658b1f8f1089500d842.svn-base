#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient

#End Region

Public Class FrmCartonReplace

    Dim QtyStr As String = ""
    Dim BarRuleStr As String = ""

#Region "窗體按鈕事件"

    Private Sub BnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP2.Click

        Me.Close()
        CartonScanOption.ReplacePrintCheck = False

    End Sub

#End Region



    Public Sub New(ByVal Partid As String)

        InitializeComponent()
        Me.TxtPartid.Text = Partid

    End Sub
    Private Sub TxtPassWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassWord.KeyPress

        If e.KeyChar = Chr(13) Then
            Me.ActiveControl = ButtonXP1
            BnOpenlock_Click(sender, e)
        End If

    End Sub

    Private Sub BnOpenlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP1.Click

        Dim LoginClass As New TextHandle
        Dim CheckRead As SqlClient.SqlDataReader
        Dim PubClass As New SysDataBaseClass

        ''CartonScanOption.vReplaceMo = Nothing
        CheckRead = PubClass.GetDataReader("select distinct a.autoid from m_Users_t a left join m_userright_t b on a.userid=b.userid where  a.autoid='" & Me.TxtPassWord.Text & "' and b.tkey='m0510c_'")
        If Not CheckRead.Read Then
            MessageBox.Show("絞ヶ怀�踼僉踼閨倢皛輕藣﹍使�...", "枑尨陓洘", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CartonScanOption.ReplacePrintCheck = False
            CheckRead.Close()
            Me.TxtPassWord.Focus()
            Me.TxtPassWord.SelectAll()
            Exit Sub
        End If
        CheckRead.Close()
        '蛁庋by hs ke 2014-5-8 
        'CheckRead = PubClass.GetDataReader("select cartonid from m_carton_t where cartonid='" & TxtPackNo.Text.Trim & "' and cartonstatus<>'E' and  cartonstatus<>'N'")
        'If Not CheckRead.Read Then
        '    MessageBox.Show("不存在該箱號或箱號狀態不符！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    CartonScanOption.ReplacePrintCheck = False
        '    CheckRead.Close()
        '    Me.TxtPackNo.Focus()
        '    Me.TxtPackNo.SelectAll()
        '    Exit Sub
        'ElseIf CartonScanOption.vReplaceMo <> Trim(CheckRead("moid").ToString) Then
        '    MessageBox.Show("設置資料的工單與需要替換的箱號對應的工單不一致。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    CartonScanOption.ReplacePrintCheck = False
        '    CheckRead.Close()
        '    Me.TxtPackNo.Focus()
        '    Me.TxtPackNo.SelectAll()
        '    Exit Sub
        'Else
        '    If LCase(BarRuleStr) = "c001" Then
        '        CartonScanOption.vReplaceQty = Microsoft.VisualBasic.Right(StrDup(3, "0") & CheckRead("Cartonqty").ToString, 3)
        '    Else
        '        CartonScanOption.vReplaceQty = CheckRead("Cartonqty").ToString
        '    End If
        '    CartonScanOption.vReplaceMo = Trim(CheckRead("moid"))
        'End If
        'CheckRead.Close()
        '蛁庋by hs ke 2014-5-8 ゐ蚚俋眊杸遙湖荂
        ' ReplacePrintCartonBarcode(TxtPackNo.Text.Trim, "", TxtPartid.Text.Trim, WorkStantOption.vStandId)
        If type.Text = "E5" Then
            ReplacePrintCartonBarcode(TxtPackNo.Text.Trim, "", TxtPartid.Text.Trim, WorkStantOption.vStandId)
        Else
            If replacetype.Text = "pallet" Then
                PrintPalletInfo(TxtPackNo.Text.Trim, "", TxtPartid.Text.Trim, WorkStantOption.vStandId)
            Else

                PrintCartonInfo(TxtPackNo.Text.Trim, "", TxtPartid.Text.Trim, WorkStantOption.vStandId)

            End If
        End If
        


        CartonScanOption.ReplacePrintCheck = True
        Me.Close()

    End Sub
    Private Sub PrintPalletInfo(ByVal BarCodeStr As String, ByVal moid As String, ByVal partid As String, ByVal Stationid As String)
        Dim BarRprintHandle As New VbCommClass.VbCommClass
        Try
            BarRprintHandle.PrintPalletPpidToFile(BarCodeStr, partid, Stationid)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Private Sub PrintCartonInfo(ByVal BarCodeStr As String, ByVal moid As String, ByVal partid As String, ByVal Stationid As String)
        Dim BarRprintHandle As New VbCommClass.VbCommClass
        Try
            BarRprintHandle.PrintCartonPpidToFile(BarCodeStr, partid, Stationid)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Private Sub ReplacePrintCartonBarcode(ByVal CartonBarCodeStr As String, ByVal moid As String, ByVal partid As String, ByVal Stationid As String)
        Dim datastr As String = ""
        Dim i As Integer = 0
        Dim pn As String = ""
        Dim cartonId As String = ""
        Dim PubClass As New SysDataBaseClass
        Dim sql_GPN As String = "select top 1 a.Cartonid,PN,Moid,Teamid from m_Carton_t a left join m_Cartonsn_t b on a.Cartonid =b.Cartonid left join m_A20Box_t c on b.ppid =c.SN where a.Cartonid='" & CartonBarCodeStr & "'"
        Dim Reads As SqlDataReader = PubClass.GetDataReader(sql_GPN)
        While (Reads.Read)
            cartonId = Reads("PN").ToString
            pn = Reads("PN").ToString
            moid = Reads("Moid").ToString
        End While
        Reads.Close()
        If cartonId = "" Then
            MessageBox.Show("俋眊祥湔婓ㄛ③恁寁湔婓腔俋眊晤鎢")
            Exit Sub
        End If

        Dim insertsql As String = "delete from m_BarRecordValue_t where barcodeSNID='" & CartonBarCodeStr & "' insert m_BarRecordValue_t(barcodeSNID,label10,PrintFlag,Printpc,moid,intime,partid"
        Dim valuesql As String = "select  barcodeSNID='" & CartonBarCodeStr & "',PN='" & pn & "',PrintFlag='1',Printpc='system',moid='" & moid & "',intime=getdate(),partid='" & partid & "'  "
        Dim sql As String = String.Format("declare @datastr varchar(1000)='' select @datastr=@datastr+ppid+''',''' from m_Cartonsn_t where Cartonid='{0}' select ''''+SUBSTRING(@datastr,0,LEN(@datastr)-1) colstr", CartonBarCodeStr)
        Dim RecTable As SqlDataReader = PubClass.GetDataReader(sql)
        While (RecTable.Read)
            datastr = RecTable("colstr").ToString
        End While
        RecTable.Close()
        RecTable.Dispose()
        If datastr.Length > 0 Then
            ' datastr = datastr.Substring(0, datastr.Length - 1)
            If datastr.Split(",").Length > 0 Then
                Dim index As Integer = 11
                For i = 0 To datastr.Split(",").Length - 1
                    insertsql = insertsql + ",label" + index.ToString
                    valuesql = valuesql + "," + datastr.Split(",")(i).ToString
                    index = index + 1
                Next

            End If
        End If
        insertsql = insertsql + ")" + valuesql
        Try
            insertsql = insertsql
            ' MessageBox.Show(insertsql)
            PubClass.ExecSql(insertsql)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

            ' Me.lblMessage.Text = ex.Message
        End Try
        Dim BarRprintHandle As New VbCommClass.VbCommClass
        Try
            BarRprintHandle.BarCodeToFile(CartonBarCodeStr, partid, Stationid)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ' Me.lblMessage.Text = ex.Message
        End Try


    End Sub

    Private Sub FrmReplaceLock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Me.ActiveControl.Name <> "ButtonXP1" Then CartonScanOption.ReplacePrintCheck = False

    End Sub

    Private Sub FrmReplaceLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim SqlStr As String
        Dim PubClass As New SysDataBaseClass
        Dim Dr As SqlClient.SqlDataReader
        SqlStr = "select * from m_PartPack_t where packid='C' and partid='" & CartonScanOption.PartidStr & " '  and usey='Y' "
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