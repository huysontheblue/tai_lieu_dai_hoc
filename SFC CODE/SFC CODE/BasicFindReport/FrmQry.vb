Imports System.Net.Sockets
Imports System.Net
Imports System.Text


Public Class FrmQry

    Private m_SerachSetM As New DataSet         '主表数据源
    Private m_SerachSetC As New DataSet         '子表数据源

    Private Sub FrmQry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Call get_dataSource(" 1 = 0")
        ' Call m_SerachSetM_f_Bind()
    End Sub

#Region "设置数据源"
    Private Sub get_dataSource(ByVal sWhere As String)
        '主数据库绑定，采用绑定的方式操作数据，实现添加字段，无需修改保存等语法
        Dim l_linkData As New MainFrame.SysDataHandle.SysDataBaseClass
        MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = "192.168.20.136"
        m_SerachSetM.Tables.Clear()
        Try
            m_SerachSetM = l_linkData.GetDataSet("select * from m_SerachSetM_f where " + sWhere)
            If m_SerachSetM.Tables(0).Rows.Count = 0 Then
                m_SerachSetM.Tables(0).Rows.Add(m_SerachSetM.Tables(0).NewRow())
            End If
            m_SerachSetM.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            l_linkData.PubConnection.Close()
        End Try

    End Sub
#End Region

    Private Sub m_SerachSetM_f_Bind()

        '其中解释字符如何显示，保存可不用处理？

        '注册绑定控件关联
        BindingSource1.DataSource = m_SerachSetM.Tables(0)
        'BindingSource1.DataMember = "m_SerachSetM_f"

        Dim m_bind_txtProName As Binding = Me.txtProName.DataBindings.Add("Text", BindingSource1, "proName", True)
        Dim m_bind_txtWinTitle As Binding = Me.txtWinTitle.DataBindings.Add("Text", BindingSource1, "TableName", True)
        Dim m_bind_chkIsMulti As Binding = Me.chkIsMulti.DataBindings.Add("Checked", BindingSource1, "IsMulti", True)
        Dim m_bind_TableName As Binding = Me.txtTableName.DataBindings.Add("Text", BindingSource1, "TableName", True)
        Dim m_bind_Condition As Binding = Me.txtCondition.DataBindings.Add("Text", BindingSource1, "Condition", True)

    End Sub

    'Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

    '    Dim f As New FrmSearch
    '    f.proName = "m_AssyTs_t" ' "pass_rate"
    '    f.dataServer = "172.17.30.200" '"192.168.20.136"
    '    f.ShowDialog()

    '    ' BindingSource1.EndEdit()
    'End Sub

    Private Sub ToolNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNew.Click
        Try
            Dim bytes(1024) As Byte
            Dim s = New Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Dim localEndPoint As New IPEndPoint(IPAddress.Parse("127.0.0.1"), 10000)
            s.Connect(localEndPoint)
            s.Send(Encoding.Unicode.GetBytes(txtProName.Text))
            s.Close()
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub ToolRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRefresh.Click
    '    Dim f As New FrmSearch
    '    f.proName = "pass_rate" ' "pass_rate"
    '    f.dataServer = "172.17.30.200" '"192.168.20.136"
    '    f.ShowDialog()
    'End Sub
End Class
