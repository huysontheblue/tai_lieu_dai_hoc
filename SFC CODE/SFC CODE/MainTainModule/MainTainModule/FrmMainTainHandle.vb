#Region "Imports"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms.DataFormats

#End Region



Public Class FrmMainTainHandle

    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim staorder As Integer = 0

#Region "退出系統"
    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click

        Me.Close()

    End Sub
#End Region

#Region "保存"
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolConfig.Click

        If Me.DGMainTain.Rows.Count < 1 Then
            LblMsg.Text = "該產品沒有發生不良的記錄..."
            Exit Sub
        End If
        If CheckDataIsRight() = True Then Exit Sub
        Dim MaxInt As Integer = 1
        Dim IsSplit As Char = "0"
        Dim Result As Char = ""
        Result = IIf(Me.CobResult.SelectedIndex = 0, "E", "G")
        IsSplit = IIf(Me.ChkSplit.Checked, "Y", "N")
        Dim StrSql As String = "select isnull(max(itemid),0) itemid from m_AssyTs_t where ppid='" & Txtppid.Text.Trim & "' "
        Dim mReader As SqlDataReader = Conn.GetDataReader(StrSql)
        While mReader.Read
            MaxInt = CInt(mReader!itemid.ToString) + 1
        End While
        mReader.Close()

        'If IsSplit = "N" Then
        '    Me.CobRuturn.SelectedIndex = 2
        'Else
        '    Me.CobRuturn.SelectedIndex = 1
        'End If
        StrSql = " insert into m_AssyTs_t(ppid,pppid,itemid,stationid,partid,codeitem,codeid,rcodeitem,rcodeid,resultid,issplit,solution,suggestion,userid,intime,Rstationid,Mtype,ISok,SmallSit)" & _
         " values('" & Txtppid.Text.Trim & "','" & DGMainTain.Rows(0).Cells("Col4").Value & "','" & MaxInt & "','" & DGMainTain.Rows(0).Cells("Col5").Value & "', " & _
         " '" & DGMainTain.Rows(0).Cells("Col8").Value & "','1','" & DGMainTain.Rows(0).Cells("Col9").Value & "','1','" & ComSmallCode.SelectedValue & "'" & _
         ",'" & CobResult.SelectedIndex & "','" & IsSplit & "','" & CobHandle.SelectedValue & "','" & TxtIdea.Text.Trim & "','" & SysMessageClass.UseId & "',getdate(),'" & CobRuturn.Text.Split("-")(0).ToString & "','1','N','" & CobRuturn.Text.Split("-")(0).ToString & "'" & ")" & vbNewLine
        StrSql = StrSql & " update m_AssysnD_t set Rstationid='" & CobRuturn.Text.Split("-")(0).ToString & "',Estateid='" & Result & "' where ppid='" & DGMainTain.Rows(0).Cells("Col4").Value & "' and stationid= '" & DGMainTain.Rows(0).Cells("Col5").Value & "'  and estateid='D' and sitem='" & DGMainTain.Rows(0).Cells("Col10").Value & "'  " & vbNewLine
        StrSql = StrSql & " update m_Assysn_t set Estateid='" & Result & "' where ppid='" & DGMainTain.Rows(0).Cells("Col4").Value & "' " & vbNewLine
        'StrSql = StrSql & " update m_AssysnD_t set Rstationid='" & CobRuturn.SelectedValue & "' where ppid='" & DGMainTain.Rows(0).Cells("Col4").Value & "' " & vbNewLine
        'StrSql = StrSql & " update m_ppidlink_t set  usey='" & Result & "' where ppid='" & DGMainTain.Rows(0).Cells("Col4").Value & "' and stationid= '" & DGMainTain.Rows(0).Cells("Col5").Value & "'  and usey='D'" & vbNewLine

        ''StrSql = StrSql & " update m_AssysnD_t set Rstateid='" & Result & "' where exppid='" & DGMainTain.Rows(0).Cells("Col4").Value & "'  " & vbNewLine
        'StrSql = StrSql & " update m_AssysnD_t set Rstateid='" & Result & "' where exppid='" & DGMainTain.Rows(0).Cells("Col4").Value & "'  " & vbNewLine
        If Result = "G" Then
            StrSql = StrSql & " update m_assysnd_t set rstateid='1' where  ppid='" & DGMainTain.Rows(0).Cells("Col4").Value & "' and intime>=(select min(intime) from m_assysnd_t where stationid='" & CobRuturn.Text.Split("-")(0).ToString & "' and ppid='" & DGMainTain.Rows(0).Cells("Col4").Value & "') " & vbNewLine
        End If
        StrSql = StrSql & " update m_ppidlink_t set Rstateid='" & Result & "' where exppid='" & DGMainTain.Rows(0).Cells("Col4").Value & "'  " & vbNewLine
        ''staorder当前站的序号。
        If IsSplit = "Y" Then
            StrSql = StrSql & " update m_ppidlink_t set usey='N' where exppid='" & DGMainTain.Rows(0).Cells("Col4").Value & "' " & vbNewLine
            StrSql = StrSql & " update m_snsbarcode_t set usey='S' where sbarcode='" & DGMainTain.Rows(0).Cells("Col4").Value & "' " & vbNewLine
            'StrSql = StrSql & " delete from m_AssysnD_t where ppid='" & DGMainTain.Rows(0).Cells("Col4").Value & "' " & vbNewLine
            'StrSql = StrSql & " delete from m_Assysn_t where ppid='" & DGMainTain.Rows(0).Cells("Col4").Value & "'"staorderid
        End If
        Try
            Conn.ExecSql(StrSql)
            LblMsg.Text = "維修完成..."
            ToolConfig.Enabled = False
            Me.ToolCancel.Enabled = False
            Me.ToolStar.Enabled = True
            Me.Txtppid.Clear()
            Me.TxtNGdes.Clear()
            TxtIdea.Clear()
            CobHandle.SelectedIndex = -1
            CobResult.SelectedIndex = -1
            CobRuturn.Clear()
            ComSmallCode.SelectedIndex = -1
            ComMidCode.SelectedIndex = -1
            CoblargeCode.SelectedIndex = -1
            Me.Txtppid.Enabled = True
        Catch ex As Exception
            LblMsg.Text = ex.Message & "維修失敗..."
        End Try


    End Sub
#End Region


#Region "檢驗保存數據是否正確"
    Private Function CheckDataIsRight() As Boolean

        If Me.CoblargeCode.SelectedIndex = -1 Then
            Me.CoblargeCode.Focus()
            Me.LblMsg.Text = "不良原因大分類不能為空..."
            CheckDataIsRight = True
            Exit Function
        End If
        If Me.ComMidCode.SelectedIndex = -1 Then
            Me.ComMidCode.Focus()
            Me.LblMsg.Text = "不良原因中分類不能為空..."
            CheckDataIsRight = True
            Exit Function
        End If
        If Me.ComSmallCode.SelectedIndex = -1 Then
            Me.ComSmallCode.Focus()
            Me.LblMsg.Text = "不良原因代碼不能為空..."
            CheckDataIsRight = True
            Exit Function
        End If
        If Me.CobHandle.SelectedIndex = -1 Then
            Me.ComSmallCode.Focus()
            Me.LblMsg.Text = "維修處理方式不能為空..."
            CheckDataIsRight = True
            Exit Function
        End If
        If Me.CobHandle.SelectedValue.ToString.Trim = "" Then
            Me.ComSmallCode.Focus()
            Me.LblMsg.Text = "維修處理方式不能為空..."
            CheckDataIsRight = True
            Exit Function
        End If
        If Me.CobResult.SelectedIndex = -1 Then
            Me.CobResult.Focus()
            Me.LblMsg.Text = "維修結果不能為空..."
            CheckDataIsRight = True
            Exit Function
        End If
        If Me.CobResult.SelectedIndex = 0 Then
            '    CobRuturn.SelectedIndex = -1
            '    CobRuturn.Enabled = False
            'Else
            '    CobRuturn.Enabled = True
            If CobRuturn.Text = "" Then
                Me.CobResult.Focus()
                Me.LblMsg.Text = "維修OK時，请选择回流站点..."
                CobResult.Enabled = True
                Exit Function
            End If
        End If

    End Function
#End Region

#Region "加載維修方式"
    Public Sub InitMaintainStyle()


        Dim StrSql As String = "select distinct mstyleid,mstyleid+'---'+mstylename mstylename from m_MainTainStyle_t where usey='Y' "
        Dim dt As DataTable = Conn.GetDataTable(StrSql)
        Dim dr As DataRow = dt.NewRow
        dr("mstyleid") = ""
        dr("mstylename") = ""
        dt.Rows.InsertAt(dr, 0)

        CobHandle.DataSource = dt.DefaultView
        CobHandle.ValueMember = "mstyleid"
        CobHandle.DisplayMember = "mstylename"


    End Sub
#End Region

#Region "加載大分類類型"
    Public Sub InformId()
        Dim StrSql As String = "select distinct rduty from m_coder_t where usey='Y' "
        Dim dt As DataTable = Conn.GetDataTable(StrSql)
        Dim dr As DataRow = dt.NewRow
        dr("rduty") = ""
        dr("rduty") = ""
        dt.Rows.InsertAt(dr, 0)

        CoblargeCode.DataSource = dt.DefaultView
        CoblargeCode.ValueMember = "rduty"
        CoblargeCode.DisplayMember = "rduty"

    End Sub
#End Region

#Region "加載數據"
    Private Sub FrmMainTainHandle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim PubClass As New SysDataBaseClass
        Dim CheckRead As SqlDataReader = PubClass.GetDataReader("select distinct a.userid from m_Users_t a  join m_userright_t b on a.userid=b.userid where  b.tkey='m031d_' and a.userid='" & SysMessageClass.UseId & "'")
        If Not CheckRead.Read Then
            Me.Toolcomfire.Enabled = False
            ToolRset.Enabled = False
        Else
            Me.Toolcomfire.Enabled = True
            ToolRset.Enabled = True
        End If
        CheckRead.Close()
        PubClass = Nothing
        InformId()
        InitMaintainStyle()
        GroupHandle.Enabled = False
        Me.Txtppid.Focus()

    End Sub
#End Region

#Region "掃描條碼load不良信息"
    Private Sub Txtppid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtppid.KeyPress

        If e.KeyChar <> Chr(13) Then Exit Sub
        Dim Ppartid As String = ""
        Dim mReader As SqlDataReader
        DGMainTain.Rows.Clear()
        Me.TxtNGdes.Clear() ''moid,ppid,stationid,sitem
        mReader = Conn.GetDataReader("select b.moid,a.partid,b.teamid,a.exppid,b.stationid,e.stationname,a.codeid,tpartid,b.userid,ccname,staorderid,sitem " & _
        " from m_ppidlink_t a join m_AssysnD_t b on a.ppid=b.ppid and a.stationid=b.stationid join m_Code_t c on a.codeid=c.codeid join m_Rstation_t e on a.stationid=e.stationid" & _
        " where a.ppid='" & Me.Txtppid.Text.Trim & "' and a.usey='D' and a.rstateid='' and b.estateid='D' and isnull(a.codeid,'')<>''")
        If mReader.HasRows Then
            While mReader.Read
                Me.DGMainTain.Rows.Add(mReader!moid.ToString, mReader!partid.ToString, mReader!teamid.ToString, mReader!exppid.ToString, mReader!stationid.ToString, mReader!codeid.ToString, mReader!tpartid.ToString, mReader!userid.ToString, mReader!sitem.ToString)
                TxtNGdes.Text = Trim(mReader!codeid.ToString) & "---" & Trim(mReader!ccname.ToString)
                Ppartid = mReader!tpartid.ToString()
                staorder = CInt(mReader!staorderid.ToString())
                Me.CobRuturn.Text = mReader!stationid & "-" & mReader!stationname
            End While
        Else
            MessageBox.Show("该产品未扫描或未扫入不良代码或已作废...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.Txtppid.Text = ""
            mReader.Close()
            Exit Sub
        End If
        mReader.Close()
        If Ppartid <> "" Then
            'Instationid(Ppartid)
        End If
        ToolStar_Click(sender, e)

    End Sub
#End Region

    '#Region "加載站点数据"
    '    Public Sub Instationid(ByVal Ppartid As String)

    '        'Dim StrSql As String = "select distinct a.stationid,a.stationid+'---'+stationname stationname from m_RPartStationD_t a join m_Rstation_t b on a.stationid=b.stationid and b.usey='Y' where ppartid='" & Ppartid & "' and state=1"
    '        'Dim dt As DataTable = Conn.GetDataTable(StrSql)
    '        'Dim dr As DataRow = dt.NewRow
    '        'dr("stationid") = ""
    '        'dr("stationname") = ""
    '        'dt.Rows.InsertAt(dr, 0)

    '        'CobRuturn.DataSource = dt.DefaultView
    '        'CobRuturn.ValueMember = "stationid"
    '        'CobRuturn.DisplayMember = "stationname"

    '    End Sub
    '#End Region

#Region "加載中分類"
    Private Sub CoblargeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CoblargeCode.Leave

        If CoblargeCode.SelectedValue = "" Then Exit Sub
        ComMidCode.DataSource = Nothing
        Dim StrSql As String = "select distinct rcsortname from m_coder_t where usey='Y' and rduty='" & Me.CoblargeCode.SelectedValue & "'"
        Dim dt As DataTable = Conn.GetDataTable(StrSql)
        Dim dr As DataRow = dt.NewRow
        dr("rcsortname") = ""
        dr("rcsortname") = ""
        dt.Rows.InsertAt(dr, 0)

        ComMidCode.DataSource = dt.DefaultView
        ComMidCode.ValueMember = "rcsortname"
        ComMidCode.DisplayMember = "rcsortname"
    End Sub
#End Region

#Region "加載中分類"
    Private Sub ComMidCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComMidCode.Leave

        If ComMidCode.SelectedValue = "" Then Exit Sub
        ComSmallCode.DataSource = Nothing
        Dim StrSql As String = "select distinct rCodeid,rCodeid+'---'+rCcname rCcname from m_coder_t where usey='Y' and rcsortname='" & Me.ComMidCode.SelectedValue & "'"
        Dim dt As DataTable = Conn.GetDataTable(StrSql)
        Dim dr As DataRow = dt.NewRow
        dr("rCodeid") = ""
        dr("rCcname") = ""
        dt.Rows.InsertAt(dr, 0)

        ComSmallCode.DataSource = dt.DefaultView
        ComSmallCode.ValueMember = "rCodeid"
        ComSmallCode.DisplayMember = "rCcname"

    End Sub
#End Region

    Private Sub CoblargeCode_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CoblargeCode.SelectedIndexChanged

        ComMidCode.SelectedValue = -1

        'ComMidCode.DataSource = Nothing
    End Sub

    Private Sub ComMidCode_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComMidCode.SelectedIndexChanged

        ComSmallCode.SelectedIndex = -1
        ComSmallCode.DataSource = Nothing

    End Sub

    Private Sub ToolStar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStar.Click

        If Txtppid.Text.Trim = "" Then Exit Sub
        ToolStar.Enabled = False
        ToolConfig.Enabled = True
        ToolCancel.Enabled = True
        GroupHandle.Enabled = True
        Me.Txtppid.Enabled = False
        'Me.CobRuturn.SelectedIndex = 2

    End Sub

    Private Sub ToolCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancel.Click

        Me.Txtppid.Enabled = True
        ToolStar.Enabled = True
        ToolConfig.Enabled = False
        ToolCancel.Enabled = False
        GroupHandle.Enabled = False
        TxtIdea.Clear()
        Me.DGMainTain.Rows.Clear()
        Me.CobHandle.SelectedIndex = -1
        Me.CoblargeCode.SelectedIndex = -1
        Me.CobResult.SelectedIndex = -1
        Me.ComSmallCode.SelectedIndex = -1
        Me.ComMidCode.SelectedIndex = -1
        'Me.CobRuturn.SelectedIndex = -1
        TxtNGdes.Clear()
        Txtppid.Clear()

    End Sub

    'Private Sub ChkSplit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSplit.CheckedChanged
    '    If ChkSplit.Checked = True Then
    '        Me.CobRuturn.SelectedIndex = 1
    '    Else
    '        Me.CobRuturn.SelectedIndex = 2
    '    End If
    'End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toolcomfire.Click

        If Me.TxtBarcode.Text = "" Then
            Me.LblMsg.Text = "请输入要确认维修完成的产品条码序号"
            TxtBarcode.Focus()
            Exit Sub
        End If
        Try
            Dim mRead As SqlDataReader = Conn.GetDataReader("select top 1 resultid from m_AssyTs_t where ppid='" & TxtBarcode.Text & "' order by intime desc")
            Dim result As String = ""
            If mRead.HasRows Then
                While mRead.Read
                    result = mRead!resultid.ToString
                End While
            End If
            mRead.Close()
            If result = "0" Then
                Me.LblMsg.Text = "该产品已报废，不允许再进行IPOC确认..."
                Exit Sub
            End If
            Conn.ExecSql("update m_AssyTs_t set ISok='Y' where ppid='" & TxtBarcode.Text & "'")
            Me.LblMsg.Text = "IPOC确认完成，请将维修OK的产品，回流至对应站点"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolRset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRset.Click

        If Me.TxtBarcode.Text = "" Then
            Me.LblMsg.Text = "请输入要确认维修完成的产品条码序号"
            TxtBarcode.Focus()
            Exit Sub
        End If
        Try
            Dim mRead As SqlDataReader = Conn.GetDataReader("select Estateid  from m_Assysn_t where ppid='" & TxtBarcode.Text & "' order by intime desc")
            Dim result As String = ""
            If mRead.HasRows Then
                While mRead.Read
                    result = mRead!Estateid.ToString
                End While
            Else
                mRead.Close()
                Me.LblMsg.Text = "该产品条码未扫描，不允许恢复作业..."
                Exit Sub
            End If
            mRead.Close()
            If result <> "D" Then
                Me.LblMsg.Text = "该产品不是不良品，不允许恢复作业..."
                Exit Sub
            End If
            Dim sqlstr As String = "update m_AssysnD_t set Estateid='Y' where ppid='" & TxtBarcode.Text & "' and Estateid='D'"
            sqlstr = sqlstr & vbNewLine & "update m_Assysn_t set Estateid='Y' where ppid='" & TxtBarcode.Text & "'  "
            sqlstr = sqlstr & vbNewLine & "update m_Ppidlink_t set Usey='Y' where ppid='" & TxtBarcode.Text & "' and usey='D' "
            Conn.ExecSql(sqlstr)
            Me.LblMsg.Text = "误判的不良品，已更新为良品..."
        Catch ex As Exception
            Me.LblMsg.Text = "误判的不良品，更新时发生错误..."
        End Try

    End Sub
End Class