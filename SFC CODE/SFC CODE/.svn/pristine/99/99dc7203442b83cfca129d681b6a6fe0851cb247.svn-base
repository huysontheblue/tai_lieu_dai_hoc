Imports System.Data.SqlClient
Imports System.Text
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Collections
Imports System.Xml
Imports System.IO
Imports MainFrame

Public Class FrmNoBarCodeSet

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
    End Sub

    Private Sub FrmNoBarCodeSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMsg.Text = ""
        Dim lsSQL As String = ""
        lsSQL = _
                "SELECT A.Cusid, B.CusName" + vbCrLf + _
                "  FROM (  SELECT DISTINCT Cusid" + vbCrLf + _
                "          FROM m_Mainmo_t" + vbCrLf + _
                "         WHERE ISNULL (Cusid, '') <> ''" + vbCrLf + _
                "        UNION" + vbCrLf + _
                "        SELECT DISTINCT Cusid" + vbCrLf + _
                "          FROM m_PartContrast_t" + vbCrLf + _
                "         WHERE ISNULL (Cusid, '') <> ''  ) A" + vbCrLf + _
                "       INNER JOIN m_Customer_t B ON A.Cusid = B.CusID" + vbCrLf + _
                "ORDER BY A.Cusid"

        LoadDataToCob(lsSQL, CboSupport) ''填充客戶

        InitailUI()
    End Sub

    Private Sub InitailUI()
        If String.IsNullOrEmpty(Data.MoidStr) Then
            Me.lblMOType.Text = "" : Me.lblMOQty.Text = "" : Me.lblPartID.Text = ""
        Else
            Me.CboSupport.SelectedIndex = Me.CboSupport.FindString(Data.CustID)
            Me.mtxtMOid.Text = Data.MoidStr
        End If
    End Sub

    Private Sub LoadDataToCob(ByVal SqlStr As String, ByVal CobName As ComboBox)

        Dim PubClass As New SysDataBaseClass
        Dim PubDataReader As SqlDataReader
        PubDataReader = PubClass.GetDataReader(SqlStr)
        CobName.Items.Clear()
        If PubDataReader.HasRows Then
            While PubDataReader.Read
                CobName.Items.Add(PubDataReader.GetString(0) & "(" & PubDataReader.GetString(1) & ")")
            End While
        End If
        PubDataReader.Close()
        PubClass.PubConnection.Close()
        PubClass = Nothing
    End Sub

    Private Sub ButConfirm_Click(sender As Object, e As EventArgs) Handles ButConfirm.Click
        If ContorlCheck() = True Then
            getPartStyle()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub getPartStyle()  ''WorkStantOption
        Data.MoidStr = Me.mtxtMOid.Text
        Data.MoidqtyStr = lblMOQty.Text
        If CboSupport.Text <> "" Then
            Data.CustStr = CboSupport.Text.Substring(InStr(CboSupport.Text, "("), Len(CboSupport.Text) - InStr(CboSupport.Text, "(") - 1)
            Data.CustID = CboSupport.Text.Split("(")(0)
        End If

        Data.PartidStr = lblPartID.Text
        Data.CustPartID = Me.lblCustPartID.Text
        Data.LineStr = CobLine.Text
        Data.CartonShouldQty = Val(Me.txtPerCartonPackQty.Text)
        Data.IsExitFlag = False
    End Sub

    Private Function ContorlCheck() As Boolean

        If CobLine.Text = "" Then
            MessageUtils.ShowError("线别不能為空！")
            Return False
        End If

        Dim dt As DataTable = DbOperateUtils.GetDataTable(
                        " select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey " & _
                        " where b.tparent in('z09_','z0s_','z0t_','z0Y_') and userid='" & SysMessageClass.UseId & "' and ButtonID='" & CobLine.Text & "'")
        If dt.Rows.Count = 0 Then
            MessageUtils.ShowInformation("当前登陆用户，没有线别编号【" & CobLine.Text & "】的扫描权限...")
            Exit Function
        End If

        '非SAP连接要判断
        If VbCommClass.VbCommClass.IsConSap = "N" Then
            If Me.CboSupport.Text = "" Then
                MessageUtils.ShowError("客戶名稱不能為空！")
                CboSupport.Focus()
                CboSupport.SelectAll()
                Return False
            End If
        End If

        If Me.mtxtMOid.Text = "" Then
            MessageUtils.ShowError("工單編號不能為空！")
            mtxtMOid.Focus()
            Me.mtxtMOid.Select()
            Return False
        End If

        If lblPartID.Text = "" Then
            MessageUtils.ShowError("请到料件基础资料维护中下载工单对应的料件资料！")
            mtxtMOid.Focus()
            Me.mtxtMOid.Select()
            Return False
        End If

        If Me.lblMOQty.Text = "" Then
            MessageUtils.ShowError("可包装工單数量不能為0,请重新新择工单！")
            mtxtMOid.Focus()
            Me.mtxtMOid.Select()
            Return False
        End If

        If GetPackingQty() = lblMOQty.Text Then
            MessageUtils.ShowError("已装箱完成！")
            Return False
        End If

        '20181224 田玉琳 检查柏拉图月报是否回复
        If CheckIsMonthAnswer() = False Then
            CobLine.Focus()
            Me.CobLine.Select()
            Return False
        End If

        If Val(Me.txtPerCartonPackQty.Text) <= 0 Then
            MessageUtils.ShowError("每箱包装数必须>0！")
            txtPerCartonPackQty.Focus()
            Me.txtPerCartonPackQty.Select()
            Return False
        End If

        If IsRightCartonQty() = False Then
            MessageUtils.ShowError("在已包装箱中，输入的包装数量>=已装箱数量！")
            txtPerCartonPackQty.Focus()
            Me.txtPerCartonPackQty.Select()
            Return False
        End If

        If IsRightQty() = False Then
            MessageUtils.ShowError("输入的包装数量+已装箱数量>工单数量！")
            txtPerCartonPackQty.Focus()
            Me.txtPerCartonPackQty.Select()
            Return False
        End If


        Return True
    End Function

    Private Function CheckIsMonthAnswer() As Boolean
        Dim strSQL As String =
            " declare @RTVALUE varchar(1), @RTMSG nvarchar(150) " &
            " EXEC [m_NewCheckPackScanCheck_P] '{0}','{1}',@RTVALUE output,@RTMSG output " &
            " select  @RTVALUE, @RTMSG"
        strSQL = String.Format(strSQL, mtxtMOid.Text, CobLine.Text)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)(0).ToString = "1" Then
                MessageUtils.ShowError(dt.Rows(0)(1).ToString)
                Return False
            End If
        End If
        Return True
    End Function

    Private NoFullPackingQuantity As Integer

    ''' <summary>
    ''' 在已包装箱中，输入的包装数量大于已装箱数量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsRightCartonQty() As Boolean
        Dim strSQL As String = "select isnull(Cartonqty,0)  from  m_Carton_t where MOID='{0}' and teamid = '{1}' and CartonStatus = 'N' "
        strSQL = String.Format(strSQL, mtxtMOid.Text, CobLine.Text)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            NoFullPackingQuantity = Convert.ToInt32(dt.Rows(0)(0).ToString)
            If (Val(txtPerCartonPackQty.Text) <= NoFullPackingQuantity) Then
                Return False
            End If
        End If
        Return True
    End Function

    ''' <summary>
    ''' 已包装数量和工单比较
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>输入的包装数量+已装箱数量>工单数量</remarks>
    Private Function IsRightQty() As Boolean
        Dim PackingQuantity As Integer = Convert.ToInt32(GetPackingQty)
        If (Val(lblMOQty.Text) < PackingQuantity - NoFullPackingQuantity + Val(txtPerCartonPackQty.Text)) Then
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' 取得包装数量
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPackingQty() As String
        Dim PackingQuantity As String = "0"
        Dim strSQL As String = " select isnull(sum(Cartonqty),0)  from  m_Carton_t where MOID='{0}' and CartonStatus = 'Y' "
        strSQL = String.Format(strSQL, mtxtMOid.Text)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            PackingQuantity = dt.Rows(0)(0).ToString
        End If
        Return PackingQuantity
    End Function

    Private Sub CboSupport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSupport.SelectedIndexChanged
        'Me.mtxtMOid.Text = String.Empty

        'Me.lblMOType.Text = ""
        'Me.lblCustPartID.Text = ""
        'Me.lblPartID.Text = ""
    End Sub

    Private Sub LoadDataToCboMoid(ByVal SqlStr As String, ByVal CobName As ComboBox)
        Dim PubClass As New SysDataBaseClass
        Dim PubDataReader As SqlDataReader
        PubDataReader = PubClass.GetDataReader(SqlStr)
        CobName.Items.Clear()
        If PubDataReader.HasRows Then
            While PubDataReader.Read
                CobName.Items.Add(PubDataReader.GetString(0))
            End While
        End If
        PubDataReader.Close()
        PubClass.PubConnection.Close()
        PubClass = Nothing
    End Sub

    Private Sub mtxtMOid_TextChanged(sender As Object, e As EventArgs) Handles mtxtMOid.TextChanged
        Dim factoryidstr As String = ""
        Dim DeptStr As String = ""
        Dim LineStr As String = ""
        Dim strCosid As String = ""
        Dim SqlStr As String = ""
        lblMOQty.Text = ""
        lblMOType.Text = ""
        lblPartID.Text = ""
        lblCustPartID.Text = ""
        CobLine.Text = ""

        If Me.mtxtMOid.Text <> "" Then
            Try
                SqlStr = " SELECT a.Factory,a.deptid,a.moqty,c.motype,a.partid,d.custpart,a.lineid ,a.Cusid+'('+g.CusName+')' as Cusid" &
                         " FROM m_Mainmo_t a " &
                         " JOIN motype_t c on a.typeid=c.typeid " &
                         " join m_PartContrast_t d on a.partid=d.tavcpart " &
                         " left join  m_Customer_t g on g.CusID=a.Cusid " &
                         " WHERE a.moid='" & Trim(Me.mtxtMOid.Text) & "'"

                Dim dt As DataTable = DbOperateUtils.GetDataTable(SqlStr)

                If dt.Rows.Count = 0 Then
                    lblMsg.Text = "料号在基础资料表中没有数据！"
                    MessageUtils.ShowError("料号在基础资料表中没有数据！")
                    Exit Sub
                End If

                DeptStr = dt.Rows(0)("deptid").ToString
                'Data.DpetId = dt.Rows(0)("deptid").ToString
                lblMOQty.Text = dt.Rows(0)("MOQTY").ToString
                lblMOType.Text = dt.Rows(0)("motype").ToString
                lblPartID.Text = dt.Rows(0)("partid").ToString
                lblCustPartID.Text = dt.Rows(0)("custpart").ToString
                LineStr = dt.Rows(0)("lineid").ToString
                factoryidstr = dt.Rows(0)("Factory").ToString
                strCosid = dt.Rows(0)("Cusid").ToString

                '"' and factoryid='" & factoryidstr
                SqlStr = " select lineid from Deptline_t where deptid='" & DeptStr & "'  and usey='Y' order by lineid"

                Dim dt2 As DataTable = DbOperateUtils.GetDataTable(SqlStr)

                Me.CobLine.Items.Clear()
                For cnt As Integer = 0 To dt2.Rows.Count - 1
                    CobLine.Items.Add(dt2.Rows(cnt)(0).ToString)
                Next
                CobLine.Text = LineStr

                If String.IsNullOrEmpty(strCosid) Then
                    CboSupport.SelectedIndex = -1
                Else
                    CboSupport.Text = strCosid
                End If

                If GetPackingQty() = lblMOQty.Text Then
                    lblMsg.Text = "已装箱完成！"
                    Exit Sub
                Else
                    lblMsg.Text = ""
                End If
            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, Me.Name, "mtxtMOid_TextChanged", "sys")
            End Try
        End If
    End Sub

    Private Sub mtxtMOid_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtMOid.ButtonCustomClick
        Try
            Dim frmMOQuery As New FrmMOQuery(Me.mtxtMOid, Me.CboSupport.Text.Split("(")(0))
            frmMOQuery.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("加载异常")
        End Try
    End Sub

    Private Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        Me.Close()
    End Sub

End Class
