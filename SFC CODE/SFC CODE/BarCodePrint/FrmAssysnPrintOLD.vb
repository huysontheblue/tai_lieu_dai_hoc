

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports LXWarehouseManage
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD
Imports MainFrame

#End Region


Public Class FrmAssysnPrintOLD

#Region "窗體變量"

    Private ObjDB As New MainFrame.SysDataHandle.SysDataBaseClass()
    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim Bt_ASAPPN As String
    Dim Bt_Po As String
    Dim Bt_Qty As String
    Dim Bt_Net As String
    Dim Bt_Data As String
    Dim Bt_Machine As String
    Dim Bt_VC As String
    Dim Bt_ICTPN As String
    Dim Bt_Rohs As String
    Dim Bt_HF As String
    Dim Bt_Shift As String
    Dim Bt_Style As String
    Dim Bt_Flaming As String
    Dim Bt_InsulationMateral As String
    Dim Bt_InsulationThick As String
    Dim Bt_JacketMaterial As String
    Dim Bt_JacketThick As String
    Dim Bt_Spec As String
    Dim Bt_Path As String
    Dim Bt_Color As String
    Dim Bt_Custom As String
    Dim Bt_RatedTemp As String
    Dim Bt_RatedVolt As String
    Dim Bt_SizeAwg As String
    Dim Bt_Id As String
    Dim Bt_LotNo As String
    Dim Bt_Barcode As String
    Dim Bt_Operator As String
    Dim Bt_Qc As String
    Dim Bt_CustomPn As String
    Dim Bt_Unit As String
    Dim BTUpdate As Boolean = False
    Dim BTAdd As Boolean = False


#End Region

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub FrmAssysnPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPartNo(ComPN)
        SetStatus(2)
        Me.chbPrintListSelect.Checked = True
    End Sub



    Private Function GetDataTable(ByVal Sqlstr As String) As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim dtable As New DataTable
        Try
            dtable = Conn.GetDataTable(Sqlstr)
            Return dtable
        Catch ex As Exception
            Throw ex '出错
        Finally
            dtable.Dispose()
            Conn.PubConnection.Close()
        End Try
    End Function


    Private Sub ToolTestPrinte_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub ComPN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComPN.KeyPress

        ComPN.DroppedDown = True
        If e.KeyChar = Chr(13) Then
            ComPN_SelectedIndexChanged(sender, e)
        End If

    End Sub

    Private Sub ComPN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComPN.SelectedIndexChanged
        Dim content As SqlDataReader = Nothing
        Dim Sdbc As New SysDataBaseClass
        Dim partid As String = ComPN.Text.ToString
        'Dim strsql As String = "SELECT CustomName,Custom_Pn,SPEC,VendCode,ROHS,STYLE,Flaming,RATED_TEMP,RATED_VOLT,SIZE_AWG,COLOR,JACKET_THICK,INSULATION_THICK,MATERIAL,INSULATION,Template_Path FROM m_QrCode_Config_t WHERE ASAP_Pn='" & partid & "'"
        content = Sdbc.GetDataReader("SELECT * FROM m_QrCode_Config_t WHERE ASAP_Pn='" & partid & "'")
        If content.Read Then
            Me.txtColor.Text = content("COLOR").ToString
            Me.TxtCustomPn.Text = content("CustomName").ToString
            Me.TxtCustomPn.Text = content("Custom_Pn").ToString
            Me.TxtSpec.Text = content("SPEC").ToString
            Me.TxtRohs.Text = content("ROHS").ToString
            Me.TxtSizeAwg.Text = content("SIZE_AWG").ToString
            Me.TxtStyle.Text = content("STYLE").ToString
            Me.TxtFlaming.Text = content("Flaming").ToString
            Me.TxtInsulationMateral.Text = content("INSULATION").ToString
            Me.txtInsulationThick.Text = content("INSULATION_THICK").ToString
            Me.txtJacketThict.Text = content("JACKET_THICK").ToString
            Me.TxtJacketMaterial.Text = content("MATERIAL").ToString
            Me.TxtPath.Text = content("Template_Path").ToString
            Me.TxtRatedTemp.Text = content("RATED_TEMP").ToString
            Me.TxtRatedVolt.Text = content("RATED_VOLT").ToString
            If String.IsNullOrEmpty(content("VendCode").ToString) Then
                Me.TxtVC.Enabled = True
            Else
                Me.TxtVC.Text = content("VendCode").ToString
                Me.TxtVC.Enabled = False
            End If
            Me.TxtCustom.Text = content("CustomName").ToString
            Me.TxtUnit.Text = content("Unit").ToString
        End If
    End Sub
    Public Sub GetPartNo(ByRef ComBox As ComboBox)
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim strSql As String
        Dim str As String
        Dim rs As SqlDataReader
        ComBox.Items.Clear()
        strSql = " SELECT  DISTINCT ASAP_Pn FROM m_QrCode_Config_t "
        rs = Conn.GetDataReader(strSql)
        While rs.Read
            ComBox.Items.Add(rs(0).ToString)
            str = rs(0).ToString
        End While
        rs.Close()
        ComBox.SelectedIndex = 0
    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        SetStatus(0)
    End Sub

    '狀態顯示
    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '查询
                Me.ComPN.Text = ""
                Me.TxtPo.Text = ""
                Me.txtQty.Text = ""
                Me.TxtNet.Text = ""
                Me.TxtMachine.Text = ""
                Me.TxtVC.Text = ""
                Me.TxtCustomPn.Text = ""
                Me.TxtRohs.Text = ""
                Me.TxtStyle.Text = ""
                Me.TxtFlaming.Text = ""
                Me.TxtInsulationMateral.Text = ""
                Me.txtInsulationThick.Text = ""
                Me.TxtJacketMaterial.Text = ""
                Me.txtInsulationThick.Text = ""
                Me.TxtSpec.Text = ""
                Me.TxtPath.Text = ""
                Me.txtColor.Text = ""
                Me.TxtCustom.Text = ""
                Me.TxtRatedTemp.Text = ""
                Me.TxtRatedVolt.Text = ""
                Me.TxtSizeAwg.Text = ""
                Me.TxtUnit.Text = ""

                Me.TxtPo.Enabled = False
                Me.txtQty.Enabled = False
                Me.TxtNet.Enabled = False
                Me.TxtMachine.Enabled = False
                Me.TxtVC.Enabled = False
                Me.TxtCustomPn.Enabled = False
                Me.TxtRohs.Enabled = False
                Me.TxtStyle.Enabled = False
                Me.TxtFlaming.Enabled = False
                Me.txtJacketThict.Enabled = False
                Me.TxtInsulationMateral.Enabled = False
                Me.txtInsulationThick.Enabled = False
                Me.TxtJacketMaterial.Enabled = False
                Me.txtInsulationThick.Enabled = False
                Me.TxtSpec.Enabled = False
                Me.TxtPath.Enabled = False
                Me.txtColor.Enabled = False
                Me.TxtCustom.Enabled = False
                Me.TxtRatedTemp.Enabled = False
                Me.TxtRatedVolt.Enabled = False
                Me.TxtSizeAwg.Enabled = False
                Me.TxtUnit.Enabled = False
                Me.TxtCarton.Enabled = True

            Case 1    '新增
                Me.ComPN.Text = ""
                Me.TxtPo.Text = ""
                Me.txtQty.Text = ""
                Me.TxtNet.Text = ""
                Me.TxtMachine.Text = ""
                Me.TxtVC.Text = ""
                Me.TxtCustomPn.Text = ""
                Me.TxtRohs.Text = ""
                Me.TxtStyle.Text = ""
                Me.TxtFlaming.Text = ""
                Me.TxtInsulationMateral.Text = ""
                Me.txtInsulationThick.Text = ""
                Me.TxtJacketMaterial.Text = ""
                Me.txtInsulationThick.Text = ""
                Me.TxtSpec.Text = ""
                Me.TxtPath.Text = ""
                Me.txtColor.Text = ""
                Me.TxtCustom.Text = ""
                Me.TxtRatedTemp.Text = ""
                Me.TxtRatedVolt.Text = ""
                Me.TxtSizeAwg.Text = ""
                Me.TxtUnit.Text = ""

                Me.TxtPo.Enabled = False
                Me.txtQty.Enabled = False
                Me.TxtNet.Enabled = False
                Me.TxtMachine.Enabled = False
                Me.TxtVC.Enabled = True
                Me.TxtCustomPn.Enabled = True
                Me.TxtRohs.Enabled = True
                Me.TxtStyle.Enabled = True
                Me.TxtFlaming.Enabled = True
                Me.txtJacketThict.Enabled = True
                Me.TxtInsulationMateral.Enabled = True
                Me.txtInsulationThick.Enabled = True
                Me.TxtJacketMaterial.Enabled = True
                Me.txtInsulationThick.Enabled = True
                Me.TxtSpec.Enabled = True
                Me.TxtPath.Enabled = True
                Me.txtColor.Enabled = True
                Me.TxtCustom.Enabled = True
                Me.TxtRatedTemp.Enabled = True
                Me.TxtRatedVolt.Enabled = True
                Me.TxtSizeAwg.Enabled = True
                Me.TxtUnit.Enabled = True
                Me.TxtCarton.Enabled = False
            Case 2    '返回
                Me.ComPN.Text = ""
                Me.TxtPo.Text = ""
                Me.txtQty.Text = ""
                Me.TxtNet.Text = ""
                Me.TxtMachine.Text = ""
                Me.TxtVC.Text = ""
                Me.TxtCustomPn.Text = ""
                Me.TxtRohs.Text = ""
                Me.TxtStyle.Text = ""
                Me.TxtFlaming.Text = ""
                Me.TxtInsulationMateral.Text = ""
                Me.txtInsulationThick.Text = ""
                Me.TxtJacketMaterial.Text = ""
                Me.txtInsulationThick.Text = ""
                Me.TxtSpec.Text = ""
                Me.TxtPath.Text = ""
                Me.txtColor.Text = ""
                Me.TxtCustom.Text = ""
                Me.TxtRatedTemp.Text = ""
                Me.TxtRatedVolt.Text = ""
                Me.TxtSizeAwg.Text = ""
                Me.TxtUnit.Text = ""

                Me.TxtPo.Enabled = True
                Me.txtQty.Enabled = True
                Me.TxtNet.Enabled = True
                Me.TxtMachine.Enabled = True
                Me.TxtVC.Enabled = False
                Me.TxtCustomPn.Enabled = False
                Me.TxtRohs.Enabled = False
                Me.TxtStyle.Enabled = False
                Me.TxtFlaming.Enabled = False
                Me.txtJacketThict.Enabled = False
                Me.TxtInsulationMateral.Enabled = False
                Me.txtInsulationThick.Enabled = False
                Me.TxtJacketMaterial.Enabled = False
                Me.txtInsulationThick.Enabled = False
                Me.TxtSpec.Enabled = False
                Me.TxtPath.Enabled = False
                Me.txtColor.Enabled = False
                Me.TxtCustom.Enabled = False
                Me.TxtRatedTemp.Enabled = False
                Me.TxtRatedVolt.Enabled = False
                Me.TxtSizeAwg.Enabled = False
                Me.TxtUnit.Enabled = False
                Me.TxtCarton.Enabled = True
            Case 3    '修改 
                Me.TxtPo.Enabled = False
                Me.txtQty.Enabled = False
                Me.TxtNet.Enabled = False
                Me.TxtMachine.Enabled = False
                Me.TxtVC.Enabled = True
                Me.TxtCustomPn.Enabled = True
                Me.TxtRohs.Enabled = True
                Me.TxtStyle.Enabled = True
                Me.TxtFlaming.Enabled = True
                Me.txtJacketThict.Enabled = True
                Me.TxtInsulationMateral.Enabled = True
                Me.txtInsulationThick.Enabled = True
                Me.TxtJacketMaterial.Enabled = True
                Me.txtInsulationThick.Enabled = True
                Me.TxtSpec.Enabled = True
                Me.TxtPath.Enabled = True
                Me.txtColor.Enabled = True
                Me.TxtCustom.Enabled = True
                Me.TxtRatedTemp.Enabled = True
                Me.TxtRatedVolt.Enabled = True
                Me.TxtSizeAwg.Enabled = True
                Me.TxtUnit.Enabled = True
                Me.TxtCarton.Enabled = False
        End Select
    End Sub

    Private Sub ToolPrt_Click(sender As Object, e As EventArgs) Handles ToolPrt.Click
        Dim empId As String = SysMessageClass.UseId
        Bt_ASAPPN = ComPN.Text.ToString
        Bt_Po = TxtPo.Text.ToString
        Bt_Qty = txtQty.Text.ToString
        Bt_Machine = TxtMachine.Text.ToString
        Bt_VC = TxtVC.Text.ToString
        Bt_Rohs = TxtRohs.Text.ToString
        If Bt_Rohs.Contains("HF") = True Then
            Bt_Rohs = "RoHS 2.0"
            Bt_HF = "HF"
        Else
            Bt_HF = ""
        End If

        Bt_ICTPN = TxtCustomPn.Text.ToString
        Bt_Custom = TxtCustom.Text.ToString
        Bt_Spec = TxtSpec.Text.ToString
        Bt_Shift = CboShift.Text.ToString
        Bt_Path = TxtPath.Text.ToString
        Bt_Style = TxtStyle.Text.ToString
        Bt_Flaming = TxtFlaming.Text.ToString
        Bt_RatedTemp = TxtRatedTemp.Text.ToString
        Bt_SizeAwg = TxtSizeAwg.Text.ToString
        Bt_RatedVolt = TxtRatedVolt.Text.ToString
        Bt_Color = txtColor.Text.ToString
        Bt_InsulationMateral = TxtInsulationMateral.Text.ToString
        Bt_InsulationThick = txtInsulationThick.Text.ToString
        Bt_JacketMaterial = TxtJacketMaterial.Text.ToString
        Bt_JacketThick = txtJacketThict.Text.ToString
        Bt_Net = TxtNet.Text.ToString
        Bt_Operator = TxtOperator.Text.ToString
        Bt_Qc = TxtQC.Text.ToString
        Bt_CustomPn = TxtCustomPn.Text.ToString
        Bt_Unit = TxtUnit.Text.ToString
        If Bt_Shift = "白班" Then
            Bt_Shift = "1"
        Else
            Bt_Shift = "2"
        End If
        Bt_Data = DtMoNeedTime.Value.ToString("yyMMdd")
        If Bt_ASAPPN = "" Then
            MessageUtils.ShowError("料号为空不能打印！")
            Return
        ElseIf Bt_Po = "" Then
            MessageUtils.ShowError("Po为空不能打印！")
            Return
        ElseIf Bt_Qty = "" Then
            MessageUtils.ShowError("数量为空不能打印！")
            Return
        ElseIf Bt_Machine = "" Then
            MessageUtils.ShowError("机台号为空不能打印！")
            Return
        ElseIf Bt_VC = "" Then
            MessageUtils.ShowError("供应商代码为空不能打印！")
            Return
        ElseIf Bt_Rohs = "" Then
            MessageUtils.ShowError("环保码为空不能打印！")
            Return
        ElseIf Bt_ICTPN = "" Then
            MessageUtils.ShowError("客户料号料号为空不能打印！")
            Return
        ElseIf Bt_Custom = "" Then
            MessageUtils.ShowError("客户为空不能打印！")
            Return
        ElseIf Bt_Spec = "" Then
            MessageUtils.ShowError("规格为空不能打印！")
            Return
        ElseIf Bt_Shift = "" Then
            MessageUtils.ShowError("班别为空不能打印！")
            Return
        ElseIf Bt_Path = "" Then
            MessageUtils.ShowError("模板路径为空不能打印！")
            Return
        End If
        For i As Int16 = 1 To Convert.ToUInt16(txtPrintCount.Text.ToString)
            Bt_Id = GetId(Bt_CustomPn, Bt_Data)
            Bt_LotNo = GetLotNo(Bt_Machine, Bt_Shift)
            'Bt_Barcode = Bt_ICTPN + "|" + DtMoNeedTime.Value.ToString("yyyyMMdd") + "|" + Bt_Qty + "|" + Bt_VC + "|" + Bt_Po + "|" + Bt_LotNo + "|" + Bt_Id + "|J1R4|BIN1|X2|2|MSD1"
            'Bt_Barcode = Bt_ICTPN + "|" + DtMoNeedTime.Value.ToString("yyyyMMdd") + "|" + Bt_Qty + "|" + Bt_VC + "|" + Bt_Po + "|" + Bt_LotNo + "|" + Bt_Id
            Bt_Barcode = Bt_ICTPN + "|" + DtMoNeedTime.Value.ToString("yyyyMMdd") + "|" + Bt_Qty + "|" + Bt_VC + "|" + Bt_Po + "|" + Bt_LotNo + "|" + Bt_Id + "|||||"
            If BartendPrint() = True Then
                Dim sql As String = "INSERT INTO m_QrCodeSn_t (ASAP_Pn,Data,Po,Lot_No,ID,Qty,Net,CartnoId,Operator,UserId,Intime,Qc)VALUES('" & Bt_ASAPPN & "','" & Bt_Data & "','" & Bt_Po & "','" & Bt_LotNo & "','" & Bt_Id & "','" & Bt_Qty & "','" & Bt_Net & "','" & Bt_Barcode & "','" & Bt_Operator & "','" & empId & "',GETDATE(),'" & Bt_Qc & "')"
                GetDataTable(sql)
            End If
        Next

    End Sub
    Private Function GetLotNo(ByVal Machine As String, ByVal Shift As String) As String
        Dim Lno As String = Machine + Shift + "%"
        Dim LotNo As String = ""
        Dim strsql As String = "select top 1 LOT_NO FROM m_QrCodeSn_t WHERE LOT_NO like'" & Lno & "' ORDER BY LOT_NO desc"
        Dim dt As DataTable = GetDataTable(strsql)
        If dt.Rows.Count > 0 Then
            LotNo = Convert.ToString(dt.Rows(0)(0))
            LotNo = Machine + Shift + (Convert.ToInt32(Mid(LotNo, LotNo.Length - 4, LotNo.Length)) + 1).ToString("00000")
        Else
            LotNo = Machine + Shift + "00001"
        End If
        Return LotNo
    End Function
    Private Function GetId(ByVal PartId As String, ByVal Data As String) As String
        Dim Ids As String = PartId + Data + "%"
        Dim ID As String
        Dim strsql As String = "select top 1 ID FROM m_QrCodeSn_t WHERE ID like'" & Ids & "' ORDER BY ID desc"
        Dim dt As DataTable = GetDataTable(strsql)
        If dt.Rows.Count > 0 Then
            ID = Convert.ToString(dt.Rows(0)(0))
            ID = PartId + Data + (Convert.ToInt32(Mid(ID, ID.Length - 5, ID.Length)) + 1).ToString("000000")
        Else
            ID = PartId + Data + "000001"
        End If
        Return ID
    End Function

    Public Function BartendPrint() As Boolean
        Dim btApp As BarTender.Application
        Dim btFormat As New BarTender.Format
        Try
            btApp = New BarTender.Application()
            btFormat = btApp.Formats.Open(VbCommClass.VbCommClass.PrintDataModle & Bt_Path, False, "")
        Catch ex As Exception
            MessageUtils.ShowError("加载BarTender实例失败！" + ex.Message)
            BartendPrint = False
        End Try

        Try
            If TxtPath.Text.ToString = "QrCode\00F-260201-002R.btw" Then
                btFormat.SetNamedSubStringValue("Rohs", Bt_Rohs)
                btFormat.SetNamedSubStringValue("CustomNo", Bt_Custom)
                btFormat.SetNamedSubStringValue("ICTPN", Bt_ICTPN)
                btFormat.SetNamedSubStringValue("ASAPPN", Bt_ASAPPN)
                btFormat.SetNamedSubStringValue("Spec", Bt_Spec)
                btFormat.SetNamedSubStringValue("OPERATOR", Bt_Operator)
                btFormat.SetNamedSubStringValue("QC", Bt_Qc)
                btFormat.SetNamedSubStringValue("Date", Bt_Data)
                btFormat.SetNamedSubStringValue("VC", Bt_VC)
                btFormat.SetNamedSubStringValue("PO", Bt_Po)
                btFormat.SetNamedSubStringValue("LOTNO", Bt_LotNo)
                btFormat.SetNamedSubStringValue("ID", Bt_Id)
                btFormat.SetNamedSubStringValue("QTY", Bt_Qty)
                btFormat.SetNamedSubStringValue("NET", Bt_Net)
                btFormat.SetNamedSubStringValue("BarCode", Bt_Barcode)
                btFormat.SetNamedSubStringValue("Style", Bt_Style)
                btFormat.SetNamedSubStringValue("Flaming", Bt_Flaming)
                btFormat.SetNamedSubStringValue("Rated_temp", Bt_RatedTemp)
                btFormat.SetNamedSubStringValue("Rater_volt", Bt_RatedVolt)
                btFormat.SetNamedSubStringValue("Size_awg", Bt_SizeAwg)
                btFormat.SetNamedSubStringValue("Color", Bt_Color)
                btFormat.SetNamedSubStringValue("Jacket_thick", Bt_JacketThick)
                btFormat.SetNamedSubStringValue("Insulation_thick", Bt_InsulationThick)
                btFormat.SetNamedSubStringValue("Jacket_material", Bt_JacketMaterial)
                btFormat.SetNamedSubStringValue("Insulation_material", Bt_InsulationMateral)
                btFormat.SetNamedSubStringValue("Unit", Bt_Unit)
            ElseIf TxtPath.Text.ToString = "QrCode\00D-243401-001H.btw" Then
                btFormat.SetNamedSubStringValue("Rohs", Bt_Rohs)
                btFormat.SetNamedSubStringValue("HF", Bt_HF)
                btFormat.SetNamedSubStringValue("CustomNo", Bt_Custom)
                btFormat.SetNamedSubStringValue("ICTPN", Bt_ICTPN)
                btFormat.SetNamedSubStringValue("ASAPPN", Bt_ASAPPN)
                btFormat.SetNamedSubStringValue("Spec", Bt_Spec)
                btFormat.SetNamedSubStringValue("OPERATOR", Bt_Operator)
                btFormat.SetNamedSubStringValue("QC", Bt_Qc)
                btFormat.SetNamedSubStringValue("Date", Bt_Data)
                btFormat.SetNamedSubStringValue("VC", Bt_VC)
                btFormat.SetNamedSubStringValue("PO", Bt_Po)
                btFormat.SetNamedSubStringValue("LOTNO", Bt_LotNo)
                btFormat.SetNamedSubStringValue("ID", Bt_Id)
                btFormat.SetNamedSubStringValue("QTY", Bt_Qty)
                btFormat.SetNamedSubStringValue("NET", Bt_Net)
                btFormat.SetNamedSubStringValue("BarCode", Bt_Barcode)
                btFormat.SetNamedSubStringValue("Unit", Bt_Unit)
            End If


            btFormat.PrintOut(True, False)
            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            BartendPrint = True
        Catch ex As Exception
            MessageUtils.ShowError("打印异常," + ex.Message)
            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            BartendPrint = False
        End Try
    End Function
    Private Sub ToolSave_Click(sender As Object, e As EventArgs) Handles ToolSave.Click
        Dim empId As String = SysMessageClass.UseId
        Bt_ASAPPN = ComPN.Text.ToString
        Bt_Po = TxtPo.Text.ToString
        Bt_VC = TxtVC.Text.ToString
        Bt_Rohs = TxtRohs.Text.ToString
        Bt_ICTPN = TxtCustomPn.Text.ToString
        Bt_Custom = TxtCustom.Text.ToString
        Bt_Spec = TxtSpec.Text.ToString
        Bt_Path = TxtPath.Text.ToString
        Bt_Style = TxtStyle.Text.ToString
        Bt_Flaming = TxtFlaming.Text.ToString
        Bt_RatedTemp = TxtRatedTemp.Text.ToString
        Bt_SizeAwg = TxtSizeAwg.Text.ToString
        Bt_RatedVolt = TxtRatedVolt.Text.ToString
        Bt_Color = txtColor.Text.ToString

        Bt_InsulationMateral = TxtInsulationMateral.Text.ToString
        Bt_InsulationThick = txtInsulationThick.Text.ToString
        Bt_JacketMaterial = TxtJacketMaterial.Text.ToString
        Bt_JacketThick = txtJacketThict.Text.ToString
        Bt_Unit = TxtUnit.Text.ToString

        If Bt_ASAPPN = "" Then
            MessageUtils.ShowError("料号为空不能新增！")
            Return
        ElseIf Bt_VC = "" Then
            MessageUtils.ShowError("供应商代码为空不能新增！")
            Return
        ElseIf Bt_Rohs = "" Then
            MessageUtils.ShowError("环保码为空不能打新增！")
            Return
        ElseIf Bt_ICTPN = "" Then
            MessageUtils.ShowError("客户料号料号为空不能新增！")
            Return
        ElseIf Bt_Custom = "" Then
            MessageUtils.ShowError("客户为空不能新增！")
            Return
        ElseIf Bt_Spec = "" Then
            MessageUtils.ShowError("规格为空不能新增！")
            Return
        ElseIf Bt_Path = "" Then
            MessageUtils.ShowError("模板路径为空不能新增！")
            Return
        End If
        Try
            If BTAdd = True Then
                Dim sql As String = " INSERT INTO m_QrCode_Config_t (CustomName,ASAP_Pn,Custom_Pn,SPEC,VendCode,ROHS,STYLE,Flaming,RATED_TEMP,RATED_VOLT,SIZE_AWG,COLOR,JACKET_THICK,INSULATION_THICK,MATERIAL,INSULATION,Template_Path,Userid,Intime,Unit)VALUES ('" & Bt_Custom & "','" & Bt_ASAPPN & "','" & Bt_ICTPN & "','" & Bt_Spec & "','" & Bt_VC & "','" & Bt_Rohs & "','" & Bt_Style & "','" & Bt_Flaming & "','" & Bt_RatedTemp & "','" & Bt_RatedVolt & "','" & Bt_SizeAwg & "','" & Bt_Color & "','" & Bt_JacketThick & "','" & Bt_InsulationThick & "','" & Bt_JacketMaterial & "','" & Bt_InsulationMateral & "','" & Bt_Path & "','" & empId & "',GETDATE(),'" & Bt_Unit & "')"
                GetDataTable(sql)
                MessageUtils.ShowInformation("新增成功!")
                BTAdd = False
            End If
            If BTUpdate = True Then
                Dim sql As String = "UPDATE m_QrCode_Config_t SET CustomName='" & Bt_Custom & "',Custom_Pn='" & Bt_ICTPN & "',SPEC='" & Bt_Spec & "',VendCode='" & Bt_VC & "',ROHS='" & Bt_Rohs & "',STYLE='" & Bt_Style & "',Flaming='" & Bt_Flaming & "',RATED_TEMP='" & Bt_RatedTemp & "',RATED_VOLT='" & Bt_RatedVolt & "',SIZE_AWG='" & Bt_SizeAwg & "',COLOR='" & Bt_Color & "',JACKET_THICK='" & Bt_JacketThick & "',INSULATION_THICK='" & Bt_InsulationThick & "',MATERIAL='" & Bt_JacketMaterial & "',INSULATION='" & Bt_InsulationMateral & "',Template_Path='" & Bt_Path & "',Userid='" & empId & "',Intime=GETDATE(),Unit='" & Bt_Unit & "' WHERE ASAP_Pn='" & Bt_ASAPPN & "'"
                GetDataTable(sql)
                MessageUtils.ShowInformation("修改成功!")
                BTUpdate = False
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try

    End Sub
    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        SetStatus(1)
        BTAdd = True
    End Sub
    Private Sub ToolUpdate_Click(sender As Object, e As EventArgs) Handles ToolUpdate.Click
        SetStatus(3)
        BTUpdate = True
    End Sub
    Private Sub ToolExitFrom_Click_1(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    Private Sub chbPrintListSelect_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrintListSelect.CheckedChanged
        Try
            If (Me.dgvLotList.RowCount > 0) Then
                For i As Int16 = 0 To Me.dgvLotList.RowCount - 1
                    dgvLotList.Rows(i).Cells("ChkSelect").Value = Me.chbPrintListSelect.Checked
                Next
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        SetStatus(2)
    End Sub

    Private Sub ToolPrintSelect_Click(sender As Object, e As EventArgs) Handles ToolPrintSelect.Click
        Dim partid As String = ComPN.Text.ToString
        Try
            'Dim sql As String = "SELECT A.ASAP_Pn,A.Data,A.Po,A.Lot_No,A.ID,A.Qty,A.Net,CartnoId,A.Operator,CustomName,Custom_Pn,SPEC,QC,VendCode,ROHS,STYLE,Flaming,RATED_TEMP,RATED_VOLT,SIZE_AWG,COLOR,JACKET_THICK,INSULATION_THICK,Material,INSULATION,Template_Path  FROM m_QrCodeSn_t A,m_QrCode_Config_t b WHERE a.ASAP_Pn=b.ASAP_Pn and	a.ASAP_Pn='" & partid & "'"
            Dim sql As String = "SELECT CustomName as Custom,A.ASAP_Pn as ASAPPN,Custom_Pn as CustomPN,SPEC as Spec,VendCode,ROHS as Rohs,CartnoId as CartonId,Template_Path as TemplatePath,a.intime as time FROM m_QrCodeSn_t A,m_QrCode_Config_t b WHERE a.ASAP_Pn=b.ASAP_Pn and	a.ASAP_Pn='" & partid & "'"
            If TxtCarton.Text <> "" Then
                sql = sql + " And CartnoId='" & TxtCarton.Text.ToString & "'"
            End If

            Dim dts As DataTable = ObjDB.GetDataTable(sql)
            dgvLotList.DataSource = dts
            dgvLotList.Refresh()
            ToolLblCount.Text = dgvLotList.RowCount
            dts.Dispose()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        Finally
            ObjDB.PubConnection.Close()
        End Try



    End Sub

    Private Sub ToolTestPrinte_Click_1(sender As Object, e As EventArgs) Handles ToolTestPrinte.Click
        Dim CartonId As String
        Dim content As SqlDataReader = Nothing
        Dim Sdbc As New SysDataBaseClass
        Dim empId As String = SysMessageClass.UseId

        Try
            If (Me.dgvLotList.RowCount > 0) Then
                For i As Int16 = 0 To Me.dgvLotList.RowCount - 1
                    If (dgvLotList.Rows(i).Cells("ChkSelect").Selected = True) Then


                        Bt_ASAPPN = dgvLotList.Rows(i).Cells("ASAPPN").Value.ToString
                        CartonId = dgvLotList.Rows(i).Cells("CartonId").Value.ToString
                        Dim sql As String = "SELECT A.ASAP_Pn,A.Data,A.Po,A.Lot_No,A.ID,A.Qty,A.Net,CartnoId,A.Operator,CustomName,Custom_Pn,SPEC,A.QC,VendCode,ROHS,STYLE,Flaming,RATED_TEMP,RATED_VOLT,SIZE_AWG,COLOR,JACKET_THICK,INSULATION_THICK,Material,INSULATION,Template_Path,Unit  FROM m_QrCodeSn_t A,m_QrCode_Config_t b WHERE a.ASAP_Pn=b.ASAP_Pn and	a.ASAP_Pn='" & Bt_ASAPPN & "' and CartnoId='" & CartonId & "'"
                        content = Sdbc.GetDataReader(sql)
                        If content.Read Then
                            Bt_Data = content("Data").ToString
                            Bt_Po = content("Po").ToString
                            Bt_LotNo = content("Lot_No").ToString
                            Bt_Id = content("ID").ToString
                            Bt_Id = content("ID").ToString
                            Bt_Qty = content("Qty").ToString
                            Bt_Net = content("Net").ToString
                            Bt_Barcode = content("CartnoId").ToString
                            Bt_Operator = content("Operator").ToString
                            Bt_Custom = content("CustomName").ToString
                            Bt_ICTPN = content("Custom_Pn").ToString
                            Bt_Spec = content("SPEC").ToString
                            Bt_Qc = content("QC").ToString
                            Bt_VC = content("VendCode").ToString
                            Bt_Rohs = content("ROHS").ToString
                            Bt_Style = content("STYLE").ToString
                            Bt_Flaming = content("Flaming").ToString
                            Bt_RatedTemp = content("RATED_TEMP").ToString
                            Bt_RatedVolt = content("RATED_VOLT").ToString
                            Bt_SizeAwg = content("SIZE_AWG").ToString
                            Bt_Color = content("COLOR").ToString
                            Bt_JacketThick = content("JACKET_THICK").ToString
                            Bt_InsulationThick = content("INSULATION_THICK").ToString
                            Bt_JacketMaterial = content("Material").ToString
                            Bt_InsulationMateral = content("INSULATION").ToString
                            Bt_Path = content("Template_Path").ToString
                            Bt_Unit = content("Unit").ToString
                        Else
                            MessageUtils.ShowError("未查询到打印记录，无法补印")
                        End If
                        If BartendPrint() = True Then
                            Dim ssql As String = "INSERT INTO m_QrCodeSn_Repair_t (ASAP_Pn,Data,Po,Lot_No,ID,Qty,Net,CartnoId,Operator,UserId,Intime)VALUES('" & Bt_ASAPPN & "','" & Bt_Data & "','" & Bt_Po & "','" & Bt_LotNo & "','" & Bt_Id & "','" & Bt_Qty & "','" & Bt_Net & "','" & Bt_Barcode & "','','" & empId & "',GETDATE())"
                            GetDataTable(ssql)
                        Else
                            MessageUtils.ShowError("补印失败。。。")
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click
        Try

            Dim sdfimport As New OpenFileDialog
            Dim o_strSQL As New StringBuilder
            sdfimport.Filter = "Excel文件|*.xls;*.xlsx"
            If (sdfimport.ShowDialog() <> DialogResult.OK) Then
                Return
            End If
            Dim filename As String = ""
            Dim errorMsg As String = ""
            Dim o_strProjectName As String = "", o_strProjectName2 As String = "", o_strVer As String = ""
            filename = sdfimport.FileName
            Dim table2 As DataTable = Nothing, table3 As DataTable = Nothing

            '取得用户上传表数据
            Dim dtUploadData As DataTable = ExcelUtils.ExportFromExcelByAs(filename, 0, 0, 26, errorMsg)

            dtUploadData.Rows.RemoveAt(0)
            ChangeCDDataTableColumnName(dtUploadData)

            Dim DrrR As DataRow() = dtUploadData.Select("ASAP_PN IS NOT NULL AND Custom_Pn IS NOT NULL") '防止追加

            If CheckUploadData(DrrR) = False Then
                Exit Sub
            End If

            If DrrR.Length = 0 Then
                MessageUtils.ShowInformation("没有可以导入的数据,请确认！")
                Exit Sub
            End If

            '批量插入到DB中
            Dim strSQL As String = GetInsertSQL(DrrR)

            If DbOperateUtils.ExecSQL(strSQL) = "" Then
                MessageUtils.ShowInformation("成功导入！")
            End If
            LoadDataToDatagridview()
            Threading.Thread.Sleep(300)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAssysnPrint", "toolImport_Click", "BarCodePrint")
            MessageUtils.ShowError(ex.Message.ToString)
        End Try

    End Sub
    '改变TABLE列名
    Private Sub ChangeCDDataTableColumnName(ByVal dt As DataTable)
        For Each i As CDImportGrid In [Enum].GetValues(GetType(CDImportGrid))
            dt.Columns(i).ColumnName = [Enum].Parse(GetType(CDImportGrid), i).ToString
        Next
    End Sub
    Private Enum CDImportGrid
        CustomName
        ASAP_Pn
        Custom_Pn
        SPEC
        Operato
        QC
        DateCode
        VendCode
        PO
        LOT_NO
        ID
        Qty
        Net
        Rohs
        STYLE
        Flaming
        RATED_TEMP
        RATED_VOLT
        SIZE_AWG
        COLOR
        JACKET_THICK
        INSULATION_THICK
        MATERIAL
        INSULATION
        Template_Path
        UNIT
    End Enum
    'TABLE 增加列
    Private Sub TableAddColumns(colName As String, colType As String, ByRef dt As DataTable)
        Dim column As DataColumn
        column = New DataColumn
        column.DataType = System.Type.GetType(colType)
        column.ColumnName = colName
        dt.Columns.Add(column)
    End Sub
    '检查上传数据
    Private Function CheckUploadData(DrrR As DataRow()) As Boolean
        Dim hastable As Hashtable = New Hashtable
        Dim firstNo As String = ""

        For index As Integer = 0 To DrrR.Length - 1

            '华为料号
            Dim PartID As String = DrrR(index)("ASAP_Pn").ToString.Trim
            If PartID = "" Then
                MessageUtils.ShowError("[华为料号]有空值,请检查后重新上传。")
                Return False
            End If

            '华为料号
            Dim strSQL As String = " SELECT ASAP_Pn FROM m_QrCode_Config_t WHERE ASAP_Pn = '{0}' "
            strSQL = String.Format(strSQL, PartID)
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            If dt.Rows.Count > 0 Then
                MessageUtils.ShowError(String.Format("系统中已存在料号:{0},请确认！", dt.Rows(0)(0).ToString))
                Return False
            End If

        Next

        Return True
    End Function
    '插入SQL文取得
    Private Function GetInsertSQL(DRS As DataRow()) As String

        Dim strInsertSQL As New StringBuilder

        Dim strSQL As String = "INSERT INTO m_QrCode_Config_t([CustomName], [ASAP_Pn], [Custom_Pn], [SPEC], [OPERATOR], [QC], [Date], [VendCode], [PO], [LOT_NO], [ID], [Qty], [NET], [ROHS], [STYLE],[Flaming], [RATED_TEMP], [RATED_VOLT], [SIZE_AWG], [COLOR], [JACKET_THICK], [INSULATION_THICK], [MATERIAL], [INSULATION],[Template_Path],[Unit], [Userid], [Intime]) VALUES" &
                             "( N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}',N'{18}',N'{19}',N'{20}',N'{21}',N'{22}',N'{23}',N'{24}',N'{25}',N'{26}',getdate())"

        For Each row As DataRow In DRS
            strInsertSQL.AppendFormat(strSQL, row("CustomName").ToString(), row("ASAP_Pn").ToString(), row("Custom_Pn").ToString(), row("SPEC").ToString(), row("OPERATO").ToString(), row("QC").ToString(), row("DateCode").ToString(), row("VendCode").ToString(),
                                      row("PO").ToString(), row("LOT_NO").ToString(), row("ID").ToString(), row("Qty").ToString(), row("NET").ToString(), row("ROHS").ToString(), row("STYLE").ToString(), row("Flaming").ToString(), row("RATED_TEMP").ToString(),
                                      row("RATED_VOLT").ToString(), row("SIZE_AWG").ToString(), row("COLOR").ToString(), row("JACKET_THICK").ToString(), row("INSULATION_THICK").ToString(), row("MATERIAL").ToString(), row("INSULATION").ToString(), row("Template_Path").ToString(),
                                      row("Unit").ToString(), VbCommClass.VbCommClass.UseId)
            strInsertSQL.AppendLine()
        Next


        Return strInsertSQL.ToString
    End Function

    '初期化GRIDVIEW
    Private Sub LoadDataToDatagridview()
        Dim SqlStr As String = ""

        SqlStr = "SELECT TOP 1000 CustomName as Custom,ASAP_Pn as ASAPPN,Custom_Pn as CustomPN,SPEC as Spec,VendCode,ROHS as Rohs,'' as CartonId,Template_Path as TemplatePath,intime as time FROM m_QrCode_Config_t  ORDER BY intime desc"
        If TxtCarton.Text <> "" Then
            SqlStr = SqlStr + " And CartnoId='" & TxtCarton.Text.ToString & "'"
        End If

        Dim dts As DataTable = ObjDB.GetDataTable(SqlStr)
        dgvLotList.DataSource = dts
        dgvLotList.Refresh()
        ToolLblCount.Text = dgvLotList.RowCount
        dts.Dispose()
    End Sub


End Class