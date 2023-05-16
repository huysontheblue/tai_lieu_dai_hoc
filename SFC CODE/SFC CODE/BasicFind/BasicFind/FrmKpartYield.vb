Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData

Public Class FrmKpartYield

    Dim Conn As New SysDataBaseClass
    Dim Iqty, Oqty, Nqty As Integer
    Dim Oyield As String = ""

    Private Sub FrmKpartYield_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DtStar.Value = Now().ToString("yyyy-MM-dd")
        DtEnd.Value = Now().AddDays(1).ToString("yyyy-MM-dd")

        refleshData()
        DtStar.Focus()


    End Sub


    Private Sub refleshData()

        If DtStar.Value.Date.ToString("yyyyMMdd") <> DtEnd.Value.Date.ToString("yyyyMMdd") Then
            MessageBox.Show("起止时间必须为同一天...", "提示信息", MessageBoxButtons.OK)
            Exit Sub
        End If
        Try
            Dim sqlStr As String = ""
            Dim mRead As SqlDataReader
            mRead = Conn.GetDataReader("select COUNT(*) Iqty from m_KeyPartTranc_t where [type] in('C','G','P') and intime between '" & DtStar.Value & "' and  '" & DtEnd.Value & "'")
            If mRead.HasRows Then
                While mRead.Read
                    Iqty = mRead!Iqty.ToString
                End While
            End If
            mRead.Close()
            Conn.PubConnection.Close()

            mRead = Conn.GetDataReader("select COUNT(*) Iqty from m_KeyPartTranc_t where [type]='L' and intime between '" & DtStar.Value & "' and  '" & DtEnd.Value & "'")
            If mRead.HasRows Then
                While mRead.Read
                    Oqty = mRead!Iqty.ToString
                End While
            End If
            mRead.Close()
            Conn.PubConnection.Close()

            mRead = Conn.GetDataReader("select COUNT(*) Iqty from m_KeyPartTranc_t where [type]='T' and intime between '" & DtStar.Value & "' and  '" & DtEnd.Value & "'")
            If mRead.HasRows Then
                While mRead.Read
                    Nqty = mRead!Iqty.ToString
                End While
            End If
            mRead.Close()
            Conn.PubConnection.Close()
            DgOK.Rows.Clear()
            DgMoData.Rows.Clear()
            mRead = Conn.GetDataReader("select  Iqty,Oqty,Nqty,yield from m_KpartYield_t where  MadeDate='" & DtStar.Value.Date.ToString("yyyyMMdd") & "'")
            If mRead.HasRows Then
                While mRead.Read
                    Me.DgOK.Rows.Add(mRead!Iqty, mRead!Oqty, mRead!Nqty, mRead!yield)
                End While
            End If
            mRead.Close()
            Conn.PubConnection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Conn.PubConnection.Close()
        End Try


        'DgOK.Rows.Add()
        If Oqty = 0 Then
            Oyield = "0%"
        Else
            Oyield = ((Oqty / (Iqty - Nqty - Oqty)) * 100) & "%"
        End If
        Me.DgMoData.Rows.Add(Iqty, Oqty, Nqty, Oyield)
        TxtIqty.Text = Iqty
        TxtNqty.Text = Nqty
        TxtOqty.Text = Oqty
        TxtYield.Text = Oyield

    End Sub

#Region "重繪datagridview單元格,選中時去除焦點"

    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgMoData.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

#End Region

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click

        Me.Close()

    End Sub

    Private Sub ToolReflsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReflsh.Click

        refleshData()

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Me.TxtIqty.Enabled = True
        Me.TxtNqty.Enabled = True
        Me.TxtOqty.Enabled = True
        Me.TxtYield.Enabled = True
        TxtIqty.Text = Iqty
        TxtNqty.Text = Oqty
        TxtOqty.Text = Oqty
        TxtYield.Text = Nqty
        ToolStripButton1.Enabled = False
        ToolStripButton2.Enabled = True
        ToolStripButton3.Enabled = True


    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Me.TxtIqty.Enabled = False
        Me.TxtNqty.Enabled = False
        Me.TxtOqty.Enabled = False
        Me.TxtYield.Enabled = False
        TxtIqty.Text = Iqty
        TxtNqty.Text = Oqty
        TxtOqty.Text = Oqty
        TxtYield.Text = Nqty
        ToolStripButton1.Enabled = True
        ToolStripButton2.Enabled = False
        ToolStripButton3.Enabled = False

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        Dim mSqlstr As String
        Dim IsFlag As String = ""
        Dim mRead As SqlDataReader = Conn.GetDataReader("select IsSend from m_KpartYield_t where MadeDate='" & DtStar.Value.Date.ToString("yyyyMMdd") & "' ")
        If mRead.HasRows Then
            While mRead.Read
                IsFlag = mRead!IsSend
            End While
        End If
        mRead.Close()
        If IsFlag = "Y" Then
            MessageBox.Show("当前的生产状况记录，已经发送给客户，不允许再维护...", "提示信息", MessageBoxButtons.OK)
            Exit Sub
        End If
        Try
            mSqlstr = "delete from m_KpartYield_t where MadeDate='" & DtStar.Value.Date.ToString("yyyyMMdd") & "' " & vbNewLine
            mSqlstr = " insert into m_KpartYield_t(Iqty,Oqty,Nqty,Yield,MadeDate,IsSend,Userid,Intime)values('" & TxtIqty.Text & "','" & TxtOqty.Text & "','" & TxtNqty.Text & "','" & TxtYield.Text & "','" & DtStar.Value.Date.ToString("yyyyMMdd") & "' ,'N','" & SysMessageClass.UseId & "',getdate())"
            Conn.ExecSql(mSqlstr)
            ToolStripButton1.Enabled = True
            ToolStripButton2.Enabled = False
            ToolStripButton3.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Conn.PubConnection.Close()
        End Try


    End Sub
End Class