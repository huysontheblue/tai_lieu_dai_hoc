Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.IO
Imports System.Xml
Imports System.Text.RegularExpressions

Public Class ScanCommon

    Private Shared ReadOnly HalfWidthFloatPattern As Regex = New Regex("^[0-9]+(.[0-9]{1,3})?$")

    Public Shared Function HalfWidthFloatChecker(target As String) As Boolean
        Dim result As Boolean = False

        If target <> "" Then
            result = HalfWidthFloatPattern.IsMatch(target)
        End If

        HalfWidthFloatChecker = result
    End Function

    Public Shared Function IsComBoxBlank(cmbBox As ComboBox, message As String) As Boolean
        If cmbBox.Text.Trim = "" Then
            MessageUtils.ShowError(message)
            cmbBox.Focus()
            Return False
        End If
        Return True
    End Function

    Public Shared Function IsTextBoxBlank(txtBox As TextBox, message As String) As Boolean
        If txtBox.Text.Trim = "" Then
            MessageUtils.ShowError(message)
            txtBox.Focus()
            txtBox.SelectAll()
            Return False
        End If
        Return True
    End Function

    Public Shared Function IsOpenLock(txtBox As TextBox, message As String) As Boolean
        If GetOpenRePrintLock(txtBox.Text.Trim) = False Then 'GetOpenLock(txtBox.Text.Trim) = False Then
            MessageUtils.ShowError(message)
            txtBox.Focus()
            txtBox.SelectAll()
            Return False
        End If
        Return True
    End Function

    Public Shared Function IsWeight(txtBox As TextBox, message As String) As Boolean
        Dim weight As String = txtBox.Text.Trim.Replace(".", "")
        If CheckUtils.HalfWidthNumChecker(weight) = False Then
            MessageUtils.ShowError("请输入正确的箱重量格式为(XX.XXX)!")
            txtBox.Focus()
            txtBox.SelectAll()
            Return False
        End If
        If ScanCommon.HalfWidthFloatChecker(txtBox.Text) = False Then
            MessageUtils.ShowError("请输入正确的箱重量格式为(XX.XXX)!")
            txtBox.Focus()
            txtBox.SelectAll()
            Return False
        End If
        Return True
    End Function

    Public Shared Function IsNotEqual(txtBox1 As TextBox, txtBox2 As TextBox, message As String) As Boolean
        If txtBox1.Text.Trim = txtBox2.Text.Trim Then
            MessageUtils.ShowError(message)
            txtBox1.Focus()
            txtBox1.SelectAll()
            Return False
        End If
        Return True
    End Function

    Public Shared Function IsExsitCarton(txtBox As TextBox, moid As String, message As String) As Boolean
        Dim dt As DataTable = ScanCommon.GetDataTable(txtBox.Text.Trim, moid)
        If dt.Rows.Count > 0 Then
            MessageUtils.ShowError(message)
            txtBox.Focus()
            txtBox.SelectAll()
            Return False
        End If
        Return True
    End Function

    Public Shared Function IsNotExsitCarton(txtBox As TextBox, moid As String, ByRef cartonId As String, message As String) As Boolean
        Dim dt As DataTable = ScanCommon.GetDataTable(txtBox.Text.Trim, moid)
        If dt.Rows.Count = 0 Then
            MessageUtils.ShowError(message)
            txtBox.Focus()
            txtBox.SelectAll()
            Return False
        End If
        cartonId = dt.Rows(0)(0).ToString.Trim
        Return True
    End Function

    '根据密码取得解锁权限
    Public Shared Function GetOpenLock(pwd As String) As Boolean
        Dim strSQL As String =
            " select distinct a.* from m_Users_t a left join m_userright_t b on a.userid=b.userid" &
            " where a.userid='{0}' and a.autoid='{1}' and b.tkey='m0510d_'"
        strSQL = String.Format(strSQL, VbCommClass.VbCommClass.UseId, pwd)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Return True
    End Function
    Public Shared Function GetOpenRePrintLock(pwd As String) As Boolean
        Dim strSQL As String =
            " select distinct a.* from m_Users_t a left join m_userright_t b on a.userid=b.userid" &
            " where a.userid='{0}' and a.PWDOfRePrint='{1}' and b.tkey='m0510d_'"
        strSQL = String.Format(strSQL, VbCommClass.VbCommClass.UseId, pwd)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count = 0 Then
            Return False
        End If
        Return True
    End Function


    '更新者：田玉琳
    '更新日期：2020/02/27
    '更新内容：根据关联表找到相关联数据
    '更新日期：2020/03/12
    '优化打印卡顿
    '根据条码取到数据
    Public Shared Function GetDataTable(code As String, moid As String) As DataTable
        Dim strSQL As String =
            "   DECLARE @ppid VARCHAR(150) " &
            "   SELECT TOP 1 @ppid = PPID FROM m_HWHLPPIDLink_t(nolock) WHERE PPID1 ='{1}'  OR PPID2 ='{1}'" &
            "   SELECT DISTINCT CARTON.Cartonid FROM M_CARTON_T CARTON" &
            "   INNER JOIN M_CARTONSN_T  CARTONSN" &
            "   ON CARTON.CARTONID = CARTONSN.CARTONID" &
            "   WHERE MOID = '{0}' AND (PPID = '{1}' OR CARTON.Cartonid='{1}'  " &
            "   OR PPID = @ppid ) "

        strSQL = String.Format(strSQL, moid, code)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        'add by hgd 20171108 先去正式库扫描记录，如果取不到再取历史库
        If dt.Rows.Count = 0 Then
            strSQL = "   SELECT TOP 1 CARTON.Cartonid FROM MESDBHistory.dbo.M_CARTON_T CARTON" &
            "   INNER JOIN MESDBHistory.dbo.M_CARTONSN_T  CARTONSN" &
            "   ON CARTON.CARTONID = CARTONSN.CARTONID" &
            "   WHERE MOID = '{0}' AND (PPID = '{1}' OR CARTON.Cartonid='{1}')"
            strSQL = String.Format(strSQL, moid, code)
            dt = DbOperateUtils.GetDataTable(strSQL)
        End If

        Return dt
    End Function

    '条码替换
    Public Shared Sub UpdateCartonsn(newBarCode As String, oldBarCode As String)
        '找到对应条码替换
        Dim strSQL As String =
            "UPDATE M_ASSYSN_T SET Ppid='{0}' WHERE Ppid = '{1}' " &
            "UPDATE M_ASSYSND_T SET Ppid='{0}' WHERE Ppid = '{1}' " &
            "UPDATE M_PPIDLINK_T SET Ppid='{0}' WHERE Ppid = '{1}' " &
            "UPDATE M_CARTONSN_T SET Ppid='{0}' WHERE Ppid = '{1}' "

        strSQL = String.Format(strSQL, newBarCode, oldBarCode)
        DbOperateUtils.ExecSQL(strSQL)
    End Sub

    '取得扫描条码后生成的关联条码
    Public Shared Function GetPEcode(scanCode As String, ByRef peCode As String) As Boolean
        Dim strSQL As String = "select ppid from [m_Ppidlink_t] where exppid = '{0}' order by StaOrderid desc "
        strSQL = String.Format(strSQL, scanCode)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            MessageUtils.ShowError("没有找到对应的关联条码请确认!")
            Return False
        Else
            peCode = dt.Rows(0)(0).ToString
            Return True
        End If
    End Function

    '打印记录 田玉琳 20190322 打印提示信息变更 
    '打印没有记录到表BARCODE中，重打，会提示错误 
    Public Shared Function RePrintRecord(moid As String, barcode As String) As Boolean
        Dim strSQL As String =
            " DECLARE @MSGID VARCHAR(1),@MSG NVARCHAR(200) " &
            " EXEC GetBarCodeReprint '{0}','1','{1}','1','1','{2}',@MSG OUTPUT,@MSGID OUTPUT" &
            " SELECT @MSGID, @MSG"

        strSQL = String.Format(strSQL, moid, barcode, VbCommClass.VbCommClass.UseId)
        'DbOperateUtils.ExecSQL(strSQL)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Select Case dt.Rows(0)(0)
                Case "0"
                    'MessageUtils.ShowInformation(dt.Rows(0)(1))
                    Return False
            End Select
        End If
        Return True
    End Function

    ''' <summary>
    ''' 中测等非包装扫描寿命管控
    ''' </summary>
    ''' <param name="Moid"></param>
    ''' <param name="Lineid"></param>
    ''' <param name="EquipmentList"></param>
    ''' <remarks></remarks>
    Public Shared Sub SaveEquipmentNoOfZCTest(ByVal Moid As String, ByVal Lineid As String, ByVal EquipmentList As String)
        Dim strSQL As String = "exec Exec_EquipmentMoSetOfZCTest '{0}','{1}','{2}'"
        strSQL = String.Format(strSQL, Moid, Lineid, EquipmentList)
        DbOperateUtils.ExecSQL(strSQL)
    End Sub


    '保存工单，线别对应的工冶具
    Public Shared Sub SaveEquipmentNo(ByVal Moid As String, ByVal Lineid As String, ByVal EquipmentList As String)
        Dim strSQL As String = "exec Exec_EquipmentMoSet '{0}','{1}','{2}'"
        strSQL = String.Format(strSQL, Moid, Lineid, EquipmentList)
        DbOperateUtils.ExecSQL(strSQL)
    End Sub

    ''' <summary>
    ''' 保存 该父料号需要检查哪些物料号
    ''' </summary>
    Public Shared Sub SaveCheckBOMList(ByVal PPartID As String, ByVal PartIDList As String, _
                                       ByVal Factory As String, ByVal profitcenter As String, _
                                       ByVal UserID As String
                                       )

        Dim strSQL As String = "exec Exec_BOMCheckByPPartSet '{0}','{1}','{2}','{3}','{4}'"
        strSQL = String.Format(strSQL, PPartID, PartIDList, Factory, profitcenter, UserID)
        DbOperateUtils.ExecSQL(strSQL)
    End Sub

    '保存工单，线别对应的工冶具
    Public Shared Function GetEquipmentNo(ByVal Moid As String, ByVal Lineid As String) As String
        Dim strSQL As String = "exec GetEquipmentMoSet '{0}','{1}' "
        strSQL = String.Format(strSQL, Moid, Lineid)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0).ToString()
        Else
            Return ""
        End If

    End Function


    Public Shared Function GetBOMList(ByVal Moid As String) As String
        Dim strSQL As String = "exec GetBOMSet '{0}' "
        strSQL = String.Format(strSQL, Moid)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0).ToString()
        Else
            Return ""
        End If

    End Function
    '獲取當天設定的治具
    Public Shared Function GetEquipmentNoByDay(ByVal Moid As String, ByVal Lineid As String) As DataTable
        Dim strSQL As String = "exec CheckEquipmentMoSetByDay '{0}','{1}' "
        strSQL = String.Format(strSQL, Moid, Lineid)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Return dt
    End Function


    Public Shared Function GetEquipmentNoOfZCTest(ByVal Moid As String, ByVal Lineid As String) As String
        Dim strSQL As String = "exec GetEquipmentMoSetOfZCTest '{0}','{1}' "
        strSQL = String.Format(strSQL, Moid, Lineid)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0).ToString()
        Else
            Return ""
        End If

    End Function

End Class
