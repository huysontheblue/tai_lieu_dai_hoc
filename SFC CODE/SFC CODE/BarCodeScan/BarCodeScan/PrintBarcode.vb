
'--EBU在线打印包装条码
'--Create by :　马锋
'--Create date :　2014/07/17
'--Ver : V01
'--Update date :  
'-

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
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD
Imports MainFrame

#End Region

Public Class PrintBarcode

#Region "窗體變量"

    Public btApp As BarTender.Application
    Public btFormat As BarTender.Format

    Public strMOID As String
    Public strPartid As String 'ADD 20200603 美超
    Public strScanBarcode As String
    Public PrintName As String
    Public LineId As String
    Public Packid As String = ""
    Public PackItems As String = ""         '条码类型
    Public strPrintBarcode As String

    Dim PrintDate As String
    Dim LoadM As New BarCodePrint.SqlClassM
    Public LoadD As New SqlClassD      '定義子資源對象
    Dim Sqlstr As New StringBuilder
    'Dim CustPart As String          '客戶料號
    Dim opFlag As Int16 = 0
    'Dim dvTiptopLot As New DataView
    'Dim TemplateStatus As Boolean = False    '模板状态
    Dim BarCodePartTable As New DataTable
    Dim CurrCodeUnitTable As New DataTable   '定義馬元資源表
    Dim PrtStrTable As New DataTable      '打印命令字符串
    Dim PrtArray As New MainFrame.SysCheckData.SysMessageClass.PrtStructure

    Dim pFilePath As String = ""
    Dim PrintPart(,) As String    '建立打印字符串來源信息數組
    Dim SBCodeUnit(,) As String       '建立條碼流水號所用到的碼制信息數組
    Dim SBCodeLEN As Int16        '流水號的長度，也是數組的變量
    Dim PrintStr As New StringBuilder     '建立條碼打印字符串

    Dim BarValueStr As New StringBuilder()
    Dim BarFile As New StringBuilder()

    Dim MoidPrinted As Int64 = 0      '工單已打印數量
    Dim AxTempCode As New StringBuilder
    Dim LblTempCode As New StringBuilder
    'Dim PrintCodeValue As StringBuilder '标签各元素的值
    'Dim CurrSeriNo As String

    ''***********************多流水码修改
    'Dim IsmullitStyle As String = "N"
    'Dim PubAtrributeStype As String = "" '附属条码的样式
    'Dim CurrAtrrCodeUnitTable As New DataTable   '定義馬元資源表
    'Dim AtrrSBCodeUnit(,) As String       '建立條碼流水號所用到的碼制信息數組
    'Dim AtrrSBCodeLEN As Int16        '流水號的長度，也是數組的變量
    'Dim AtrrCode As String = ""
    'Dim AtrrCodeLen As Int16 ''附属条码
    'Dim AtrrAxTempCode As New StringBuilder
    'Dim AtrrCurrSeriNo As String
    ''***********************多流水码修改
    'Private m_strOrderNO As String = String.Empty
    'Private m_strOrderSeq As String = String.Empty
    'Private m_DeliveryDate As String = String.Empty
    'Private m_ScheFinishDate As String = String.Empty

    '初始对象
    Private scanStartSeq As Int32
    Private scanEndSeq As Int32

    Private mStaionId As String
    Private mStaionName As String
    Public BoxQty As String = ""   '應裝箱數量
    Dim YMDCode As New StringBuilder

    Dim PackMethod As Int16 = 0             '裝箱數量
    Private mCartonSame As String      'PE袋条码箱是否相同
    Private mCodeRuleID As String = ""
    Private mCartonId As String
    Private curCartonQty As String = "0"
    Private mIsOnlineGenCartonID2 As Boolean '箱处理
    'Public m_CartonID As String = String.Empty
    Public mCartonDate As String
    Dim mIsTrunk As String = "N"
    Public errMessage = "" '错误信息
    Public IsRework As Boolean = False '是否重工 20190418


#End Region

#Region "窗體基本屬性"

    Public WriteOnly Property StaionId() As String
        Set(value As String)
            mStaionId = value
        End Set
    End Property

    Public WriteOnly Property StaionName() As String
        Set(value As String)
            mStaionName = value
        End Set
    End Property

    Public WriteOnly Property CartonSame() As String
        Set(value As String)
            mCartonSame = value
        End Set
    End Property

    Public WriteOnly Property CodeRuleID() As String
        Set(value As String)
            mCodeRuleID = value
        End Set
    End Property

    Public Property CartonID() As String
        Set(value As String)
            mCartonId = value
        End Set
        Get
            Return mCartonId
        End Get
    End Property

    Public WriteOnly Property IsOnlineGenCartonID2() As Boolean
        Set(value As Boolean)
            mIsOnlineGenCartonID2 = value
        End Set
    End Property

    ''' <summary>
    ''' 是否是尾箱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsTrunk() As String
        Get
            Return mIsTrunk
        End Get
    End Property

    Public ReadOnly Property JLabelStr() As String
        Get
            Return AxTempCode.ToString
        End Get
    End Property
#End Region

    Private Function MarkBarTable(ByVal PackId As String, ByVal PackItem As String) As Boolean
        Dim Sqlstr As String = ""
        Dim RecTable As New DataTable
        Try
            If (PackId = "A") Then
                Sqlstr = "select distinct a.F_codeID,isnull(cast(b.ShortName as Nvarchar(128)),left(c.DValues,F_codelen)) as ShortName,a.F_orderid, a.UnitID, a.BarArea, a.SplitChar,a.DResource, a.IsStyle,a.IsPrintStyle,a.F_codelen,a.IsBoxQty  " _
               & " from m_SnRuleD_t as a join m_SnRuleM_t as d on a.CodeRuleID=d.CodeRuleID left join (select b.F_codeid,c.ShortName from m_SnSet_t as b " _
               & " join m_SnSet_t as c on b.CodeRuleID=c.CodeRuleID and b.F_codeid=c.F_codeid where b.CodeRuleID='" & LoadM.CodeRule.ToString & "' group by b.F_codeid,c.ShortName " _
               & " having count(b.f_codeid)=1) as b on a.F_codeid=b.F_codeid left join m_SnPartSet_t as c on a.F_codeid=c.F_codeid and d.LabelType=c.packid " _
               & " and c.partid='" & LoadD.CurrAVCPartID.ToString & "' and c.usey='Y' where a.CodeRuleID='" & LoadM.CodeRule.ToString & "' and c.Packid='" & PackId & "' and c.Packitem='" & PackItem & "'"

            Else
                Sqlstr = "select distinct a.F_codeID,isnull(cast(b.ShortName as Nvarchar(128)),left(c.DValues,F_codelen)) as ShortName,a.F_orderid, a.UnitID, a.BarArea, a.SplitChar,a.DResource, a.IsStyle,a.IsPrintStyle,a.F_codelen,a.IsBoxQty  " _
               & " from m_SnRuleD_t as a join m_SnRuleM_t as d on a.CodeRuleID=d.CodeRuleID left join (select b.F_codeid,c.ShortName from m_SnSet_t as b " _
               & " join m_SnSet_t as c on b.CodeRuleID=c.CodeRuleID and b.F_codeid=c.F_codeid where b.CodeRuleID='" & LoadM.CodeRule.ToString & "' group by b.F_codeid,c.ShortName " _
               & " having count(b.f_codeid)=1) as b on a.F_codeid=b.F_codeid left join m_SnPartSet_t as c on a.F_codeid=c.F_codeid and d.LabelType=c.packid " _
               & " and c.partid='" & LoadD.CurrAVCPartID.ToString & "' and c.usey='Y'  and c.Packid='" & PackId & "' and c.Packitem='" & PackItem & "' where a.CodeRuleID='" & LoadM.CodeRule.ToString & "'"
            End If
            RecTable = DbOperateUtils.GetDataTable(Trim(Sqlstr))
            If RecTable.Rows.Count > 0 Then
                BarCodePartTable = RecTable
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '數組傳遞參數
    Private Sub SetArrayLbl(ByVal Array() As String)
        'Dim I As Int16
        'Dim IsCheckCode As String = "N"
        'Dim ArrayCheck As Integer = 0
        'Try
        '    For I = 0 To BarCodePartTable.Rows.Count - 1
        '        If BarCodePartTable.Rows(I).Item("DResource").ToString <> "" AndAlso Microsoft.VisualBasic.Left(BarCodePartTable.Rows(I).Item("DResource").ToString, 5) = "Array" Then
        '            BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(Replace(BarCodePartTable.Rows(I).Item("DResource").ToString, "Array", ""))).Trim


        '        End If
        '        If (BarCodePartTable.Rows(I).Item("F_codeID").ToString = "Y" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "M" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "D" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "W" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "DW" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "DY") AndAlso BarCodePartTable.Rows(I).Item("UnitID").ToString <> "" Then
        '            BarCodePartTable.Rows(I).Item("ShortName") = LoadM.ShowShortTime(CDate(Array(7)), BarCodePartTable.Rows(I).Item("F_codeID").ToString, BarCodePartTable.Rows(I).Item("UnitID").ToString)
        '        End If
        '    Next
        'Catch ex As Exception
        '    Throw ex
        'End Try

        Dim I As Int16
        Try
            For I = 0 To BarCodePartTable.Rows.Count - 1
                If BarCodePartTable.Rows(I).Item("DResource").ToString <> "" AndAlso Microsoft.VisualBasic.Left(BarCodePartTable.Rows(I).Item("DResource").ToString, 5) = "Array" Then
                    If (BarCodePartTable.Rows(I).Item("F_codeID").ToString() = "Q") Then
                        If ((BarCodePartTable.Rows(I).Item("IsBoxQty").ToString() = "Y")) Then
                            BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(BarCodePartTable.Rows(I).Item("DResource").ToString.Substring(5))).Trim
                        Else
                            BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(BarCodePartTable.Rows(I).Item("DResource").ToString.Substring(5))).Trim.PadLeft(CInt(BarCodePartTable.Rows(I).Item("F_codelen").ToString), "0")
                        End If
                    Else
                        BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(BarCodePartTable.Rows(I).Item("DResource").ToString.Substring(5))).Trim
                    End If

                End If
                If (BarCodePartTable.Rows(I).Item("F_codeID").ToString = "Y" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "M" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "D" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "W" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "DW" OrElse BarCodePartTable.Rows(I).Item("F_codeID").ToString = "DY") AndAlso BarCodePartTable.Rows(I).Item("UnitID").ToString <> "" Then
                    BarCodePartTable.Rows(I).Item("ShortName") = LoadM.ShowShortTime(CDate(Array(7)), BarCodePartTable.Rows(I).Item("F_codeID").ToString, BarCodePartTable.Rows(I).Item("UnitID").ToString)
                End If

                '增加校验位类别XC判断 Add By KyLin Qiu 20170609--Begin
                If (BarCodePartTable.Rows(I).Item("F_codeID").ToString.Trim.ToUpper = "XC") AndAlso (BarCodePartTable.Rows(I).Item("UnitID").ToString.Trim.ToUpper = "XC2" Or BarCodePartTable.Rows(I).Item("UnitID").ToString.Trim.ToUpper = "XC3") Then
                    '目前写死一位已以C表示,后续如果有新需求可以拓展
                    BarCodePartTable.Rows(I).Item("ShortName") = "C"
                    'BarCodePartTable.Rows(I).Item("ShortName") = BarCodePartTable.Rows(I).Item("F_codelen").ToString.Trim
                End If
                '增加校验位类别XC判断 Add By KyLin Qiu 20170609--End

            Next
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmListPrint", "SetArrayLbl", "sys")
            Throw ex
        End Try
    End Sub

    'Private Sub SetArrayLbl(ByVal Array() As String)
    '    Dim I As Int16
    '    Try
    '        For I = 0 To BarCodePartTable.Rows.Count - 1
    '            If BarCodePartTable.Rows(I).Item("DResource").ToString <> "" AndAlso Microsoft.VisualBasic.Left(BarCodePartTable.Rows(I).Item("DResource").ToString, 5) = "Array" Then
    '                If (BarCodePartTable.Rows(I).Item("F_codeID").ToString() = "Q") Then
    '                    If ((BarCodePartTable.Rows(I).Item("IsBoxQty").ToString() = "Y")) Then
    '                        BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(Microsoft.VisualBasic.Right(BarCodePartTable.Rows(I).Item("DResource").ToString, 1))).Trim
    '                    Else
    '                        BarCodePartTable.Rows(I).Item("ShortName") =
    '                            Array(Int(Microsoft.VisualBasic.Right(BarCodePartTable.Rows(I).Item("DResource").ToString, 1))).Trim.PadLeft(CInt(BarCodePartTable.Rows(I).Item("F_codelen").ToString), "0")
    '                    End If
    '                Else
    '                    BarCodePartTable.Rows(I).Item("ShortName") = Array(Int(Microsoft.VisualBasic.Right(BarCodePartTable.Rows(I).Item("DResource").ToString, 1))).Trim
    '                End If

    '            End If
    '            If (BarCodePartTable.Rows(I).Item("F_codeID").ToString = "Y" OrElse
    '                BarCodePartTable.Rows(I).Item("F_codeID").ToString = "M" OrElse
    '                BarCodePartTable.Rows(I).Item("F_codeID").ToString = "D" OrElse
    '                BarCodePartTable.Rows(I).Item("F_codeID").ToString = "DY" OrElse
    '                BarCodePartTable.Rows(I).Item("F_codeID").ToString = "W") AndAlso
    '                BarCodePartTable.Rows(I).Item("UnitID").ToString <> "" Then
    '                BarCodePartTable.Rows(I).Item("ShortName") = LoadM.ShowShortTime(CDate(Array(7)), BarCodePartTable.Rows(I).Item("F_codeID").ToString, BarCodePartTable.Rows(I).Item("UnitID").ToString)
    '            End If
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Function Checking(Optional ByVal o_blnCheck As Boolean = True) As Boolean
        If o_blnCheck Then
            If LoadD.CurrAVCPartID = "" OrElse LoadD.CurrAVCPartID = "##########" Then
                MsgBox("條碼中各部分不能為空!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Return False
            End If
        End If
        LoadD.CurrPrintNum = 1
        LoadD.MantissaFlag = False
        Return True
    End Function

    '增加箱处理/扫描条码
    Private Function CheckStyle() As Boolean
        Dim dtScanSeq As DataTable
        Try
            LoadD.StyleID = MakeStyle() '產生樣式

            If mIsOnlineGenCartonID2 = True Then
                Dim Sqlstr As String
                Dim Obj As New Object
                Dim RecTable As New DataTable
                If LoadD.StyleID.ToString <> "" Then
                    '核查樣式表
                    Sqlstr = "select StyleID,MaxSN,MaxInt,IsUsed from m_SnStyle_t where StyleID='" & LoadD.StyleID.ToString & "'"
                    RecTable = DbOperateUtils.GetDataTable(Sqlstr)
                    If RecTable.Rows.Count > 0 Then
                        If RecTable.Rows(0).Item("IsUsed").ToString = "N" Then
                            Sqlstr = "update m_SnStyle_t set IsUsed='Y',Userid='" & SysMessageClass.UseId.ToLower & "',Intime=getdate() where StyleID='" & LoadD.StyleID & "'"
                            DbOperateUtils.ExecSQL(Sqlstr)

                            LoadD.BarCodeStyleMax = RecTable.Rows(0).Item("MaxSN").ToString
                            LoadD.CurrMaxInt = Int(RecTable.Rows(0).Item("MaxInt").ToString)
                        Else
                            Return False
                        End If
                    Else
                        Sqlstr = " INSERT INTO m_SnStyle_t(StyleID,Partid,CodeRuleID,StyleDescripe,MaxInt,MaxSN,IsUsed,Userid,Intime) " & _
                                 " values('" & LoadD.StyleID & "','" & LoadD.CurrAVCPartID & "','" & LoadM.CodeRule & "','" & LoadD.StyleID.ToString & "'," & _
                                 "" & LoadD.StartInt & ",'" & LoadD.StartSn & "','Y','" & SysMessageClass.UseId.ToLower & "',getdate())"
                        DbOperateUtils.ExecSQL(Sqlstr)
                        LoadD.BarCodeStyleMax = LoadD.StartSn.ToString
                        LoadD.CurrMaxInt = LoadD.StartInt
                    End If
                    Return True
                Else
                    Return False
                End If
            Else
                dtScanSeq = DbOperateUtils.GetDataTable(
                      "SELECT MIN(F_codestart) AS MinCodestart, MAX(F_codestart) AS MaxCodestart FROM m_SnSBarCode_t " _
                    & "      INNER JOIN m_Mainmo_t ON m_Mainmo_t.Moid=m_SnSBarCode_t.Moid " _
                    & "      INNER JOIN m_PartPack_t ON m_PartPack_t.PartID=m_Mainmo_t.PartID " _
                    & "      INNER JOIN M_SNRULED_T ON M_SNRULED_T.CodeRuleID=m_PartPack_t.CodeRuleID " _
                    & " WHERE SBarCode='" & strScanBarcode & "' AND m_PartPack_t.Packid='S' AND M_SNRULED_T.F_CODEID='S' AND m_PartPack_t.Usey='Y'")

                If (dtScanSeq Is Nothing Or dtScanSeq.Rows.Count = 0) Then
                    Return False
                End If

                scanStartSeq = IIf(IsDBNull(dtScanSeq.Rows(0).Item("MinCodestart")), "0", dtScanSeq.Rows(0).Item("MinCodestart").ToString)
                scanEndSeq = IIf(IsDBNull(dtScanSeq.Rows(0).Item("MaxCodestart")), "0", dtScanSeq.Rows(0).Item("MaxCodestart").ToString) ' dtScanSeq.Rows(0).Item("MaxCodestart").ToString

                LoadD.BarCodeStyleMax = LoadD.StartSn.ToString
                LoadD.CurrMaxInt = LoadD.StartInt
            End If
            Return True
        Catch ex As Exception
            LoadM.OpenLock(LoadD.StyleID)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 產生樣式
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function MakeStyle() As String
        Dim I As Integer
        Dim Flag As Boolean = False
        Dim TempView As DataView

        Dim BarCodeStyle As New StringBuilder
        AxTempCode.Remove(0, AxTempCode.Length)
        LblTempCode.Remove(0, LblTempCode.Length)
        YMDCode.Remove(0, YMDCode.Length)  'ADD 田玉琳 2016/03/21
        Try
            TempView = New DataView(BarCodePartTable)
            TempView.RowFilter = "bararea='BarCode1'"
            TempView.Sort = "f_orderid asc"
            '產生樣式
            For I = 0 To TempView.Count - 1
                '******************ADD 田玉琳 2016/03/21**********************************Start
                If (TempView.Item(I).Item("F_codeID").ToString = "Y" OrElse
                 TempView.Item(I).Item("F_codeID").ToString = "M" OrElse
                 TempView.Item(I).Item("F_codeID").ToString = "D" OrElse
                 TempView.Item(I).Item("F_codeID").ToString = "DY" OrElse
                 TempView.Item(I).Item("F_codeID").ToString = "W") AndAlso
                 TempView.Item(I).Item("UnitID").ToString <> "" Then
                    YMDCode.Append(TempView.Item(I).Item("ShortName").ToString)
                End If
                '******************ADD 田玉琳 2016/03/21**********************************end
                If TempView.Item(I).Item("IsPrintStyle").ToString = "Y" Then
                    BarCodeStyle.Append(TempView.Item(I).Item("ShortName").ToString)
                    AxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                Else
                    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" AndAlso Flag = False Then
                        LoadD.AxSPos = AxTempCode.Length
                        Flag = True
                    End If
                    If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "Q" Then
                        AxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                    Else
                        If TempView.Item(I).Item("ShortName").ToString.Trim <> "" Then
                            AxTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                        Else
                            AxTempCode.Append(TempView.Item(I).Item("F_codeID").ToString)
                        End If
                    End If
                    BarCodeStyle.Append(TempView.Item(I).Item("F_codeID").ToString)
                End If
                'BarCodeStyle.Append(TempView.Item(I).Item("SplitChar").ToString)
            Next

            Flag = False
            TempView = New DataView(BarCodePartTable)
            TempView.RowFilter = "bararea='BarLabel1'"
            TempView.Sort = "f_orderid asc"
            '產生樣式Label1
            For I = 0 To TempView.Count - 1
                If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" AndAlso Flag = False Then
                    LoadD.LblSPos = LblTempCode.Length
                    Flag = True
                End If
                If TempView.Item(I).Item("F_codeID").ToString.ToUpper <> "S" Then
                    LblTempCode.Append(TempView.Item(I).Item("ShortName").ToString)
                End If
                If TempView.Item(I).Item("F_codeID").ToString.ToUpper = "S" Then
                    LblTempCode.Append(TempView.Item(I).Item("F_codeID").ToString)
                End If
                LblTempCode.Append(TempView.Item(I).Item("SplitChar").ToString)
            Next

            Return BarCodeStyle.ToString
        Catch ex As Exception
            Throw ex
            Return ""
        End Try
    End Function

    '设置打印数据内容
    Private Function GetPrintData(BarTend As String, packId As String, Optional iPrintCount As Integer = 1) As StringBuilder
        Dim BarFile As New StringBuilder()
        Dim barFiles As New StringBuilder()
        Try

            Dim strSQL As String =
            "select label10,label11,label12,label13,label14,label15,label16,label17,label18,labe19,label20,label21,label22,label23,label24 " &
            "from m_BarRecordValue_t " &
            "where barcodesnid = '{0}' and packId = '{1}' "
            strSQL = String.Format(strSQL, BarTend, packId)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            If (dt.Rows.Count = 0) Then
                Throw New Exception("MES打印表中没有要打印数据，请联系标签室!")
            End If

            For Each dr As DataRow In dt.Rows
                BarFile.Append("""" & BarTend & """")
                For Each dc As DataColumn In dt.Columns
                    BarFile.Append(",""" & dr(dc.ColumnName).ToString().Trim & """")
                Next
            Next

            For iRowCnt As Integer = 0 To iPrintCount - 1
                barFiles.Append(BarFile.ToString)
                barFiles.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            Next

            barFiles.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)

        Catch ex As Exception
            Throw ex
        End Try
        Return barFiles
    End Function

    '已经打印过数据，扫描过
    Private Function GetAssysnDCnt() As Integer
        Dim strSQL As String = String.Format("  select Ppid from m_AssysnD_t where Ppid = '{0}' and Stationid='{1}' ", strScanBarcode, Me.mStaionId)
        'Dim strSQL As String = String.Format(" select SBarCode from m_MOPackingLevel where SBarCode = '{0}' and PackId = '{1}' ", AxTempCode, Packid)

        Dim iCnt As Integer = DbOperateUtils.GetRowsCount(strSQL)

        Return iCnt
    End Function

    '取得打印日期 第几天
    Private Function GetPrintDate(DW As String, ByRef printDate As String) As Boolean
        Dim result As String = False
        Dim systemDate As String = ""
        Dim dt As DataTable
        Try
            '不是周别 无需比较 DJ 20181217
            If IsNumeric(DW) Then
                '如果周别大于40周,且现在又跨年算上一年
                If DW > 40 Then
                    systemDate = "GETDATE() - 60"
                Else
                    systemDate = "GETDATE()"
                End If
                Dim strSql As String = String.Format(
                     " select convert(varchar,cast(codesort as datetime),112) codesort from m_SnUnitD_t where UnitID='W4' and CodeUnit = '{0}'" &
                     " and CodeSort like (CONVERT(VARCHAR(4),{1},112) + '%')", DW, systemDate)

                dt = DbOperateUtils.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then '取得打印日期第1天
                    printDate = dt.Rows(1)("codesort").ToString
                    result = True
                End If
            Else
                result = True
            End If

            '外箱重新打印改为取当天 邓炯 20180809
            'Dim strSql As String = " select convert(varchar, GETDATE() ,112) codesort"
            'dt = DbOperateUtils.GetDataTable(strSql)
            'If dt.Rows.Count > 0 Then '取当天日期
            '    printDate = dt.Rows(0)("codesort").ToString
            '    result = True
            'End If
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '取得打印模板
    '只取得打印模板箱数量
    Private Function GetPrintTemplatePathbyWeight(partId As String, ByRef TemplatePath As String, ByRef CartonQty As String,
                                                  ByRef printCO As String, ByRef printEA As String, ByRef printHW As String) As Boolean
        Dim result As String = False
        Dim dt As DataTable

        Try
            'ADD AND ISNULL(CodeRuleID,'') <> '' 20170922
            Dim strSql As String = String.Format(
                  " declare @CodeRuleID varchar(20)" &
                    " select @CodeRuleID = CodeRuleID from m_RPartStationD_t where PPartid = '{0}' and State = 1  AND ISNULL(CodeRuleID,'') <> '' " &
                    " set @CodeRuleID = substring( @CodeRuleID,charindex('/',@CodeRuleID,3)+1,4 ) " &
                    " if @CodeRuleID = '' set @CodeRuleID = null" &
                    " select TemplatePath,PrinterName,pp.Qty,PARTSET.F_codeID ,PARTSET.DValues  from m_PartPack_t PP " &
                    " inner join m_SnMFormat_t SMF" &
                    " on pp.PFormatID = smf.PFormatID" &
                    " left join m_SnPartSet_T PARTSET " &
                    " ON PP.Partid = PARTSET.Partid AND PARTSET.Usey = 'Y'  AND PARTSET.Packid = 'C'" &
                    " where PP.PACKID IN ('C', 'N')  AND  PP.Usey = 'Y' and  PP.Partid = '{0}'" &
                    " and CodeRuleID = ISNULL(@CodeRuleID,CodeRuleID)", partId)

            dt = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                TemplatePath = dt.Rows(0)("TemplatePath").ToString
                CartonQty = dt.Rows(0)("Qty").ToString
                '查找功能号
                For index As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(index)("F_codeID") = "CO" Then
                        printCO = dt.Rows(index)("DValues")
                    End If
                    If dt.Rows(index)("F_codeID") = "EA" Then
                        printEA = dt.Rows(index)("DValues")
                    End If
                    If dt.Rows(index)("F_codeID") = "HW" Then
                        printHW = dt.Rows(index)("DValues")
                    End If
                Next
                result = True
            End If
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '取得打印模板
    Private Function GetPrintTemplatePathbyWeightList(partId As String, CodeRuleID As String, ByRef TemplatePath As String, ByRef CartonQty As String,
                                              ByRef printCO As String, ByRef printEA As String, ByRef printHW As String) As Boolean
        Dim result As String = False
        Dim dt As DataTable

        Try
            Dim strSql As String = String.Format(
                    " select TemplatePath,PrinterName,pp.Qty,PARTSET.F_codeID ,PARTSET.DValues  from m_PartPack_t PP " &
                    " inner join m_SnMFormat_t SMF" &
                    " on pp.PFormatID = smf.PFormatID" &
                    " left join m_SnPartSet_T PARTSET " &
                    " ON PP.Partid = PARTSET.Partid AND PARTSET.Usey = 'Y'  AND PARTSET.Packid = 'C'" &
                    " where PP.PACKID IN ('C', 'N')  AND  PP.Usey = 'Y' and  PP.Partid = '{0}'" &
                    " and CodeRuleID = '{1}'", partId, CodeRuleID)

            dt = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                TemplatePath = dt.Rows(0)("TemplatePath").ToString
                CartonQty = dt.Rows(0)("Qty").ToString
                '查找功能号
                For index As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(index)("F_codeID") = "CO" Then
                        printCO = dt.Rows(index)("DValues")
                    End If
                    If dt.Rows(index)("F_codeID") = "EA" Then
                        printEA = dt.Rows(index)("DValues")
                    End If
                    If dt.Rows(index)("F_codeID") = "HW" Then
                        printHW = dt.Rows(index)("DValues")
                    End If
                Next
                result = True
            End If
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '取得製程外箱打印模板
    Private Function GetPrintTemplatePathbyWork(partId As String, _
                                                ByRef TemplatePath As String,
                                                ByRef CartonQty As String,
                                                ByVal StationId As String
                                                ) As Boolean
        Dim result As String = False
        Dim dt As DataTable

        Try
            Dim strSql As String = String.Format(
                  " declare @CodeRuleID varchar(20)" &
                    " select @CodeRuleID = WorkCodeRuleID from m_RPartStationD_t where PPartid = '{0}' and State = 1 and  Stationid='{1}' AND ISNULL(WorkCodeRuleID,'') <> '' AND IsOnlineWorkPrint='Y' " &
                    " set @CodeRuleID = substring( @CodeRuleID,charindex('/',@CodeRuleID,3)+1,4 ) " &
                    " if @CodeRuleID = '' set @CodeRuleID = null" &
                    " select TemplatePath,PrinterName,pp.Qty,PARTSET.F_codeID ,PARTSET.DValues,pp.CodeRuleID  FROM m_PartPack_t PP " &
                    " inner join m_SnMFormat_t SMF" &
                    " on pp.PFormatID = smf.PFormatID" &
                    " left join m_SnPartSet_T PARTSET " &
                    " ON PP.Partid = PARTSET.Partid AND PARTSET.Usey = 'Y'  AND PARTSET.Packid = 'C'" &
                    " where PP.PACKID IN ('C', 'N')  AND  PP.Usey = 'Y' and  PP.Partid = '{0}'" &
                    " and CodeRuleID = ISNULL(@CodeRuleID,CodeRuleID)", partId, StationId)

            dt = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                TemplatePath = dt.Rows(0)("TemplatePath").ToString
                CartonQty = dt.Rows(0)("Qty").ToString
                result = True
            End If
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 抓取S类型的标签模板路径
    ''' </summary>
    ''' <param name="partId"></param>
    ''' <param name="TemplatePath"></param>
    ''' <param name="CartonQty"></param>
    ''' <param name="StationId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPrintTemplatePathOfS(partId As String, _
                                            ByRef TemplatePath As String,
                                            ByRef CartonQty As String,
                                            ByVal StationId As String
                                            ) As Boolean
        Dim result As String = False
        Dim dt As DataTable

        Try
            Dim strSql As String = String.Format(
                    " declare @CodeRuleID varchar(20)" &
                    " select @CodeRuleID = CodeRuleID from m_PartPack_t WHERE Partid = '{0}' and PackID = 'S' " &
                    " select TemplatePath,PrinterName,pp.Qty,PARTSET.F_codeID ,PARTSET.DValues,pp.CodeRuleID  FROM m_PartPack_t PP " &
                    " inner join m_SnMFormat_t SMF" &
                    " on pp.PFormatID = smf.PFormatID" &
                    " left join m_SnPartSet_T PARTSET " &
                    " ON PP.Partid = PARTSET.Partid AND PARTSET.Usey = 'Y'" &
                    " where PP.PACKID IN ('S')  AND  PP.Usey = 'Y' and  PP.Partid = '{0}'" &
                    " and CodeRuleID = ISNULL(@CodeRuleID,CodeRuleID)", partId, StationId)

            dt = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                TemplatePath = dt.Rows(0)("TemplatePath").ToString
                CartonQty = dt.Rows(0)("Qty").ToString
                result = True
            End If
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' 取得打印模板
    ''' 还要取得设置的料号
    ''' 增加取模板的条件，多工站时取不到在线打印数据
    ''' </summary>
    ''' <param name="partId"></param>
    ''' <param name="TemplatePath"></param>
    ''' <param name="PN"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPrintTemplatePath(partId As String, ByRef TemplatePath As String, ByRef PN As String, ByRef PO As String) As Boolean
        Dim result As String = False
        Dim dt As DataTable

        Try
            Dim strSql As String = String.Format(
                    " declare @CodeRuleID varchar(20)" &
                    " select @CodeRuleID = CodeRuleID from m_RPartStationD_t where PPartid = '{0}' and State = 1  AND isnull(CodeRuleID,'')  <> '' " &
                    " set @CodeRuleID = substring( @CodeRuleID,charindex('/',@CodeRuleID,3)+1,4 ) " &
                    " if @CodeRuleID = '' set @CodeRuleID = null" &
                    " select DISTINCT TemplatePath,PrinterName,PARTSET.F_codeID ,DValues from m_PartPack_t PP " &
                    " inner join m_SnMFormat_t SMF" &
                    " on pp.PFormatID = smf.PFormatID" &
                    " left join m_SnPartSet_T PARTSET " &
                    " ON PP.Partid = PARTSET.Partid" &
                    " where PP.PACKID IN ('C', 'N')  AND  PP.Usey = 'Y' and  PP.Partid = '{0}'  " &
                    " AND PP.Packid = PARTSET.Packid AND  PP.Packitem = PARTSET.Packitem " &
                    " and CodeRuleID = ISNULL(@CodeRuleID,CodeRuleID)", partId)

            dt = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                '查找功能号
                For index As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(index)("F_codeID") = "PN" Then
                        PN = dt.Rows(index)("DValues").ToString
                    End If
                    If dt.Rows(index)("F_codeID") = "PO" Then
                        PO = dt.Rows(index)("DValues").ToString
                    End If
                    If dt.Rows(index)("F_codeID") = "HP" Then
                        'HP = dt.Rows(index)("DValues")
                    End If
                Next
                TemplatePath = dt.Rows(0)("TemplatePath").ToString

                result = True
            End If
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region "外部调用"

    '初期化
    Public Function InitializePrintParameter() As Boolean
        Dim Dtable As DataTable
        Try
            If Not String.IsNullOrEmpty(strScanBarcode) Then
                If IsRework = False Then
                    'Moid1table = DbOperateUtils.GetDataTable("SELECT A.Moid,B.PartID FROM m_SnSBarCode_t A INNER JOIN dbo.m_Mainmo_t B " _
                    '                                        & " ON A.Moid=B.Moid WHERE SBarCode='" & strScanBarcode & "' AND  A.PackId='S'")
                    'Dim Moid1 As String = Moid1table.Rows(0)(0).ToString()
                    'Dim Partid1 As String = Moid1table.Rows(0)(1).ToString()
                    'Moid2table = DbOperateUtils.GetDataTable("SELECT PARTID FROM m_Mainmo_t WHERE MOID ='" & strMOID & "'")
                    'Dim Partid2 As String = Moid2table.Rows(0)(0).ToString()
                    'If Partid1 <> Partid2 Then
                    '    Dtable = DbOperateUtils.GetDataTable("SELECT Makedate FROM m_SnSBarCode_t WHERE SBarCode='" & strScanBarcode & "' AND MOID='" & strMOID & "' AND PackId='S' ")
                    '    If (Dtable.Rows.Count = 0) Then
                    '        errMessage = "扫描的条码和工单信息不符！"
                    '        Return False
                    '    End If
                    'Else
                    '    Dtable = DbOperateUtils.GetDataTable("SELECT Makedate FROM m_SnSBarCode_t WHERE SBarCode='" & strScanBarcode & "' AND MOID='" & Moid1 & "' AND PackId='S'")
                    'End If
                    Dim strSQLs As String = "SELECT Makedate FROM m_SnSBarCode_t A INNER JOIN dbo.m_Mainmo_t B " &
                                           " ON A.Moid=B.Moid WHERE SBarCode= '{0}' AND b.PartID ='{1}' AND a.Packid = 'S'"

                    strSQLs = String.Format(strSQLs, strScanBarcode, strPartid)
                    Dtable = DbOperateUtils.GetDataTable(strSQLs)
                    If (Dtable.Rows.Count = 0) Then
                        errMessage = String.Format("扫描的条码{0}和料号'{1}'信息不符！", strScanBarcode, strPartid)
                        Return False
                    End If


                Else
                    Dtable = DbOperateUtils.GetDataTable("SELECT Makedate FROM m_SnSBarCode_t WHERE SBarCode='" + strScanBarcode + "' AND PackId='S' ")
                    If (Dtable.Rows.Count = 0) Then
                        errMessage = "扫描的条码不存在！"
                        Return False
                    End If
                End If

                SqlClassD.UpdateTime = ""
                If Dtable.Rows.Count > 0 Then
                    PrtArray.NowDate = CDate(Dtable.Rows(0)("Makedate").ToString).ToString("yyyy-MM-dd").ToString
                    PrtArray.NowMonth = CDate(Dtable.Rows(0)("Makedate").ToString).ToString("MM").ToString
                    PrintDate = Dtable.Rows(0)("Makedate").ToString
                Else
                    PrtArray.NowDate = CDate(DateTime.Now.ToString).ToString("yyyy-MM-dd").ToString
                    PrtArray.NowMonth = CDate(DateTime.Now.ToString).ToString("MM").ToString
                    PrintDate = DateTime.Now.ToString      'Dtable.Rows(0)("Makedate").ToString
                End If
                SetArrayLbl(PrtArray.ToArray)
            Else
                Dtable = DbOperateUtils.GetDataTable("select getdate() as datet")
                mCartonDate = CDate(Dtable.Rows(0)("datet").ToString).ToString("yyyy-MM-dd")
                PrtArray.NowDate = mCartonDate
                PrtArray.NowMonth = CDate(mCartonDate).Month
            End If

            Dtable = DbOperateUtils.GetDataTable("select a.Moid, a.Lineid, a.Cusid, c.CodeRuleID ,c.Qty,  c.Packid, " _
                                        & "  PackItem, c.DisorderTypeId DisorderType, PackingLevel, djmdc, 'D' [shift], LineJm, Demandtime,'' FileVerNo, '' DriFlag, '' BuildAttribute " _
                                        & " from m_Mainmo_t as a " _
                                        & "   join m_PartPack_t as c on a.PartID=c.Partid and c.Usey='Y' " _
                                        & "   LEFT JOIN m_Dept_t on a.Deptid=m_Dept_t.Deptid " _
                                        & "   LEFT JOIN Deptline_t on m_Dept_t.deptid=Deptline_t.deptid and a.lineid=Deptline_t.lineid " _
                                        & " where a.moid='" & strMOID & "' and c.Packid='" & Packid & "' and c.Packitem='" & PackItems & "' ")

            If (Dtable.Rows.Count = 0) Then
                Return False
            End If

            LoadM.CodeRule = Dtable.Rows(0)!CodeRuleID.ToString
            LoadM.Packitem = Dtable.Rows(0)!PackItem.ToString
            LoadM.DisorderType = Dtable.Rows(0)!DisorderType.ToString
            LoadM.PackingLevel = Dtable.Rows(0)!PackingLevel.ToString
            LoadM.Taskid = ""  'Dtable!Ptaskid.ToString
            LoadM.DefaultMoid = Dtable.Rows(0)!Moid.ToString
            LoadM.DefaultLine = Dtable.Rows(0)!Lineid.ToString
            LoadM.CustID = Dtable.Rows(0)!Cusid.ToString
            LoadM.Factory = VbCommClass.VbCommClass.Factory
            LoadM.DeptJm = Dtable.Rows(0)!djmdc.ToString
            LoadM.vShift = Dtable.Rows(0)!shift.ToString
            LoadM.vLineJm = Dtable.Rows(0)!LineJm.ToString
            LoadM.vRequestDate = Dtable.Rows(0)!Demandtime.ToString
            LoadM.vIsprint = "Y"
            LoadM.vCodeType = Dtable.Rows(0)!Packid.ToString
            LoadM.vVerNo = Dtable.Rows(0)!FileVerNo.ToString
            LoadM.vDriFlag = Dtable.Rows(0)!DriFlag.ToString
            LoadM.vBuildAttribute = Dtable.Rows(0)!BuildAttribute.ToString

            Dtable = DbOperateUtils.GetDataTable("select distinct a.TAvcPart,a.CustPart,c.CusName,b.Deptid,f.djc,b.Lineid,b.Moqty,b.Ppidprtqty,b.PkgPrtqty,d.Packid, d.PackItem, j.TemplatePath,e.PFormatID,e.PaperSize,e.ColNum,e.RowNum,d.Packlink,d.Multiy,d.MultiQty,d.Qty,d.StartInt,d.StartSn,d.EndInt,d.EndSn " _
                        & "from m_PartContrast_t as a join m_Mainmo_t as b on a.TAvcPart=b.PartID and b.Moid='" & LoadM.DefaultMoid & "' and b.FinalY='N' " _
                        & "left join m_Dept_t as f on b.Deptid=f.Deptid left join m_Customer_t as c on a.CusID=c.CusID join m_PartPack_t as d on a.TAvcPart=d.Partid and d.CodeRuleID='" & LoadM.CodeRule & "' and d.usey='Y'  and d.PackItem='" & PackItems & "' " _
                        & "left join m_SnPFormat_t as e on d.PFormatID=e.PFormatID left join m_SnMFormat_t as j on d.PFormatID=j.PFormatID ")
            If Dtable.Rows.Count = 0 Then
                Return False
            End If

            LoadD.CurrAVCPartID = Dtable.Rows(0)("TAvcPart").ToString.ToUpper.Trim
            LoadD.CurrMoid = LoadM.DefaultMoid
            LoadD.PFormat = Dtable.Rows(0)("PFormatID").ToString
            LoadD.PrintColNum = Int(IIf(Dtable.Rows(0)("ColNum").ToString <> "", Dtable.Rows(0)("ColNum").ToString, 0)) * CInt(Dtable.Rows(0)("RowNum").ToString)
            LoadD.StartSn = Dtable.Rows(0)("StartSn").ToString
            LoadD.EndSn = Dtable.Rows(0)("EndSn").ToString
            LoadD.EndInt = Int(IIf(Dtable.Rows(0)("EndInt").ToString <> "", Dtable.Rows(0)("EndInt").ToString, "0"))
            LoadD.StartInt = Int(IIf(Dtable.Rows(0)("StartInt").ToString <> "", Dtable.Rows(0)("StartInt").ToString, "0"))

            Packid = Dtable.Rows(0)("Packid").ToString
            PackItems = Dtable.Rows(0)("Packitem").ToString
            ''Packlink = Dtable.Rows(0)("Packlink").ToString
            'MoidAllNum = Int(IIf(Dtable.Rows(0)("Moqty").ToString <> "", Dtable.Rows(0)("Moqty").ToString, 0))
            'MoidPrinted = Int(IIf(Dtable.Rows(0)("PkgPrtqty").ToString <> "", Dtable.Rows(0)("PkgPrtqty").ToString, 0))

            'CtPrtingNum = Int(MoidAllNum / PackMethod) - MoidPrinted  '可打印箱數
            'MoidLastNum = MoidAllNum Mod PackMethod  '尾數
            PrtArray.AvcPartid = Dtable.Rows(0)("TAvcPart").ToString.ToUpper.Trim
            PrtArray.CusName = Dtable.Rows(0)("CusName").ToString.Trim
            PrtArray.Deptid = Dtable.Rows(0)("Deptid").ToString.ToUpper.Trim
            PrtArray.Lineid = LoadM.vLineJm
            PrtArray.Moid = LoadD.CurrMoid.ToUpper.Trim
            PrtArray.ConfigFlag = LoadM.vVerNo
            PrtArray.DriFlag = LoadM.vDriFlag
            PrtArray.BuildAttribute = LoadM.vBuildAttribute
            PrtArray.DateCode = ""
            PrtArray.WorkType = LoadM.vShift
            pFilePath = Dtable.Rows(0)("TemplatePath").ToString

            Dim dt As DataTable
            Dim strSQL As String = "SELECT PARAMETER_NAME,PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='MES' " &
                                   "AND PARAMETER_NAME IN ('MfgID','LocID', 'Madein','MadeinSX') AND PARAMETER_CODE = '{0}' "
            strSQL = String.Format(strSQL, VbCommClass.VbCommClass.Factory)
            dt = DbOperateUtils.GetDataTable(strSQL)

            PrtArray.MfgID = ""
            PrtArray.LocID = ""
            PrtArray.Madein = ""
            PrtArray.MadeinSX = ""
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                Select Case dt.Rows(rowIndex).Item(0).ToString.ToUpper()
                    Case "MfgID".ToUpper()
                        PrtArray.MfgID = dt.Rows(rowIndex).Item(1).ToString
                    Case "LocID".ToUpper()
                        PrtArray.LocID = dt.Rows(rowIndex).Item(1).ToString
                    Case "Madein".ToUpper
                        PrtArray.Madein = dt.Rows(rowIndex).Item(1).ToString
                    Case "MadeinSX".ToUpper
                        PrtArray.MadeinSX = dt.Rows(rowIndex).Item(1).ToString
                End Select
            Next


            '生成箱号时进入
            If mIsOnlineGenCartonID2 Then
                PrtArray.Qty = IIf(Dtable.Rows(0)("Qty").ToString <> "", Dtable.Rows(0)("Qty").ToString, "1")
                BoxQty = PrtArray.Qty
                '**************田玉琳 修改 20160908***********************Start 
                Dim Sqlstr As String = " SELECT ISNULL((SELECT MOQTY FROM M_MAINMO_T WHERE MOID = '{0}')-ISNULL(SUM(PACKINGQUANTITY),0),0)  " &
                                        "  FROM M_CARTON_T  " &
                                        "  WHERE MOID = '{0}'"
                Sqlstr = String.Format(Sqlstr, strMOID)
                Dim RecTable As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
                If (RecTable.Rows.Count > 0) Then
                    If Val(RecTable.Rows(0)(0)) = 0 Then '全部装箱完成
                        mCartonId = "00000000"
                        Return False
                    Else
                        If Val(RecTable.Rows(0)(0)) <= BoxQty Then
                            BoxQty = Val(RecTable.Rows(0)(0))
                            mIsTrunk = "Y"  '是否是尾箱
                        End If
                    End If
                End If
                '**************田玉琳 修改 20160908***********************End 
            Else
                PrtArray.Qty = IIf(Dtable.Rows(0)("Qty").ToString <> "", Dtable.Rows(0)("Qty").ToString, "1")
                PackMethod = PrtArray.Qty
                'PrtArray.Qty = BoxQty
                'PackMethod = BoxQty
            End If

            If MarkBarTable(Packid, PackItems) = False Then
                Exit Try
            End If

            SetArrayLbl(PrtArray.ToArray)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    '检查生成条码数据
    Public Function BuildCBarCode(Optional ByVal o_blnCheck As Boolean = True) As Boolean
        Try
            Dim WorkStr As String = ""
            Dim Icount As Int16 = 0
            For I As Integer = 0 To BarCodePartTable.Rows.Count - 1
                If Icount = 2 Then Exit For
                If BarCodePartTable.Rows(I)("DResource").ToString = "Array9" Then
                    WorkStr = "D"
                    BarCodePartTable.Rows(I)("shortname") = WorkStr
                    Icount = Icount + 1
                End If
            Next

            If Checking(o_blnCheck) = False OrElse CheckStyle() = False Then
                Return False
            End If
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodePrint.FrmBarPrt", "BuildBarCode", "sys")
        End Try
    End Function

    '整箱称重
    Public Function PrintFullCartonWeight(CartonBarcode As String, LabelNum As String, al As ArrayList) As Boolean
        Dim moid As String
        Dim partId As String
        Dim scanQty As String = ""
        Dim cartonQty As String = ""
        Dim pageQty As String
        Dim printCO As String = ""
        Dim printEAN As String = ""
        Dim printHW As String = ""
        Dim printDate As String = Date.Now.ToString("yyyyMMdd")
        Dim Weight As String = ""

        Try
            Dim sqlstr As String =
                " select distinct a.ppid  from m_Cartonsn_t a left join m_BarRecordValue_t b on a.ppid =b.barcodeSNID " &
                " where  Cartonid='" & CartonBarcode & "' "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr)
            'add by hgd 20171108 先去正式库扫描记录，如果取不到再取历史库
            If dt.Rows.Count = 0 Then
                sqlstr = " select distinct a.ppid from MESDBHistory.dbo.m_Cartonsn_t a left join MESDBHistory.dbo.m_BarRecordValue_t b on a.ppid =b.barcodeSNID " &
                                " where  Cartonid='" & CartonBarcode & "' "
                dt = DbOperateUtils.GetDataTable(sqlstr)
            End If

            Dim TxtFileStr As New StringBuilder
            Dim titlestr As New StringBuilder
            Dim TxtFileStrCommon As New StringBuilder
            Dim TxtFileStrCommonOther As New StringBuilder
            'Dim titlestrCommon As New StringBuilder
            TxtFileStrCommon.Append("""" & CartonBarcode & """" & ",")
            titlestr.Append("""barcodeSN"",")

            partId = al(0).ToString
            scanQty = dt.Rows.Count
            Weight = al(2).ToString
            moid = al(3).ToString
            '取得打印模板
            GetPrintTemplatePathbyWeight(partId, pFilePath, cartonQty, printCO, printEAN, printHW)

            '检查错误
            'If printCO = "" Then Return False
            'If printEAN = "" Then Return False

            'Mark by cq 20170628
            ' If LabelNum = "0" Then Return False

            If LabelNum = "0" Then
                MessageUtils.ShowError("请检查【是否在线打印整箱条码(标签数)】是否维护正确!")
                Return False
            End If

            pageQty = CInt(cartonQty / LabelNum)
        
            TxtFileStrCommon.Append("""" & Weight & """" & ",")
            titlestr.Append("""lable10"",")
            TxtFileStrCommon.Append("""" & scanQty & """" & ",")
            titlestr.Append("""lable11"",")
            TxtFileStrCommon.Append("""" & printCO & """" & ",")
            titlestr.Append("""lable12"",")
            TxtFileStrCommon.Append("""" & printEAN & """" & ",")
            titlestr.Append("""lable13"",")
            TxtFileStrCommon.Append("""" & printHW & """" & ",")
            titlestr.Append("""lable14"",")
            TxtFileStr.Append(TxtFileStrCommon)

            'If VbCommClass.VbCommClass.Factory = "BZLANTO" Then
            '    If (dt.Rows.Count > 0) Then

            '        '获取当前机种的其他参数值
            '        Dim parmStr As String = "select s.F_codeID,DValues from m_SnPartSet_t s  left join m_PartPack_t a on a.Partid=s.Partid and s.Packitem=a.Packitem left join m_Mainmo_t b on a.Partid=b.PartID left join m_Carton_t c on b.Moid=c.Moid left join m_SnRuleD_t d on d.CodeRuleID=a.CodeRuleID  and s.F_codeID=d.F_codeID where c.Cartonid='" & CartonBarcode & "' and a.Packid='C' and s.Packid='C' and a.Usey='Y' and d.BarArea like 'Label%'"
            '        Dim parmdt As DataTable = DbOperateUtils.GetDataTable(parmStr)
            '        If parmdt.Rows.Count > 0 Then
            '            For i As Integer = 0 To parmdt.Rows.Count - 1
            '                TxtFileStr.Append("""" & parmdt.Rows(i)("DValues").ToString & """" & ",")
            '                titlestr.Append("""" & parmdt.Rows(i)("F_codeID").ToString & """" & ",")
            '            Next
            '        End If

            '        TxtFileStr.Append("""" & dt.Rows.Count & """" & ",")
            '        titlestr.Append("""CartonQty"",")

            '        Dim countI As Integer = 0
            '        Dim countSum As Integer = 0
            '        Dim barcode1 As String = ""
            '        Dim barcode2 As String = ""
            '        Dim barcode3 As String = ""
            '        Dim barcode4 As String = ""

            '        For i As Integer = 0 To dt.Rows.Count - 1
            '            If i < 20 Then
            '                barcode1 = barcode1 + dt.Rows(i)("ppid").ToString + " "
            '            ElseIf i < 40 Then
            '                barcode2 = barcode2 + dt.Rows(i)("ppid").ToString + " "
            '            ElseIf i < 60 Then
            '                barcode3 = barcode3 + dt.Rows(i)("ppid").ToString + " "
            '            Else
            '                barcode4 = barcode4 + dt.Rows(i)("ppid").ToString + " "
            '            End If
            '        Next

            '        If barcode1.Length > 0 Then
            '            TxtFileStr.Append("""" & barcode1.Remove(barcode1.Length - 1, 1) & """" & ",")
            '        Else
            '            TxtFileStr.Append("""" & "" & """" & ",")
            '        End If
            '        titlestr.Append("""ABarcode1"",")

            '        If barcode2.Length > 0 Then
            '            TxtFileStr.Append("""" & barcode2.Remove(barcode2.Length - 1, 1) & """" & ",")
            '        Else
            '            TxtFileStr.Append("""" & "" & """" & ",")
            '        End If
            '        titlestr.Append("""ABarcode2"",")

            '        If barcode3.Length > 0 Then
            '            TxtFileStr.Append("""" & barcode3.Remove(barcode3.Length - 1, 1) & """" & ",")
            '        Else
            '            TxtFileStr.Append("""" & "" & """" & ",")
            '        End If 
            '        titlestr.Append("""ABarcode3"",")

            '        If barcode4.Length > 0 Then
            '            TxtFileStr.Append("""" & barcode4.Remove(barcode4.Length - 1, 1) & """" & ",")
            '        Else
            '            TxtFileStr.Append("""" & "" & """" & ",")
            '        End If
            '        titlestr.Append("""ABarcode4"",")
            '    End If
            'End If

            Dim col As Integer = 15
            For iCnt As Integer = 0 To pageQty
                titlestr.Append("""lable" & col.ToString & """,")
                col = col + 1
            Next


            '******************************黄广都 20200306 开始*************************************
            '增加其他数据 展示所有数据
            Dim o_dtLabel As DataTable = GetLableArray(partId)
            If Not IsNothing(o_dtLabel) AndAlso o_dtLabel.Rows.Count > 0 Then
                Dim item As Integer = 1
                For iCnt As Integer = 0 To o_dtLabel.Rows.Count - 1
                    '工单
                    If o_dtLabel.Rows(iCnt)(1).ToString = "Array1" Then
                        TxtFileStrCommonOther.Append("""" & moid & """" & ",")
                        titlestr.Append("""lableOther" & item.ToString & """,")
                        item = item + 1
                    End If
                    '料号
                    If o_dtLabel.Rows(iCnt)(1).ToString = "Array3" Then
                        TxtFileStrCommonOther.Append("""" & partId & """" & ",")
                        titlestr.Append("""lableOther" & item.ToString & """,")
                        item = item + 1
                    End If
                    '箱内总盒重
                    If o_dtLabel.Rows(iCnt)(1).ToString = "Array27" Then
                        Dim NW As String
                        NW = GetCartonPpidWeight(CartonBarcode, moid)
                        TxtFileStrCommonOther.Append("""" & NW & """" & ",")
                        titlestr.Append("""lableOther" & item.ToString & """,")
                        item = item + 1
                    End If

                Next
            End If
            '******************************黄广都 20200306 结束*************************************

            Dim pageCnt As Integer = 0
            For Each dr As DataRow In dt.Rows
                If pageCnt = pageQty Then
                    pageCnt = 0

                    TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
                    TxtFileStr.Append(vbNewLine)
                    TxtFileStr.Append(TxtFileStrCommon)
                End If
                TxtFileStr.Append("""" & dr!ppid.ToString & """" & ",")
                pageCnt = pageCnt + 1
            Next

            'add by hgd 20200313 如果是尾数箱，则填补剩余空格
            If CInt(scanQty) < pageQty Then
                Dim itemQty As Integer
                itemQty = pageQty - CInt(scanQty)
                For iCnt As Integer = 0 To itemQty - 1
                    TxtFileStr.Append("""" & "" & """" & ",")
                Next
            End If
            'ADD by  hgd  20200306
            If Not String.IsNullOrEmpty(TxtFileStrCommonOther.ToString) Then
                TxtFileStr.Append("""" & "" & """" & ",")
                TxtFileStr.Append(TxtFileStrCommonOther)   'ADD by 20200306 hgd
            End If


            TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            titlestr.Remove(titlestr.Length - 1, 1)
            TxtFileStr.Append(vbNewLine)

            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCarton", "sys")
                Exit Function
            End If

            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)

            FileToBarCodePrint(pFilePath, PrintName)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '整箱称重(内箱合并)
    Public Function PrintFullCartonWeightList(CartonBarcode As String, CartonList As ArrayList, LabelNum As String, al As ArrayList, CodeRuleId As String) As Boolean
        'add by hgd 2017-12-28 多个内箱合并打印一个最外箱
        Dim partId As String
        Dim scanQty As String = ""
        Dim cartonQty As String = ""
        Dim pageQty As String
        Dim printCO As String = ""
        Dim printEAN As String = ""
        Dim printHW As String = ""
        Dim printDate As String = Date.Now.ToString("yyyyMMdd")
        Dim Weight As String = ""
        Dim o_strSql As New StringBuilder
        Dim o_strSqlHis As New StringBuilder
        Try
            'Dim i As Integer = 0
            For i As Integer = 0 To CartonList.Count - 1
                If Not String.IsNullOrEmpty(CartonList(i).ToString) Then
                    If i > 0 Then
                        o_strSql.Append(" union all ")
                    End If

                    o_strSql.Append(" select distinct a.ppid from m_Cartonsn_t a left join m_BarRecordValue_t b on a.ppid =b.barcodeSNID  ")
                    o_strSql.Append("  where  Cartonid='" & CartonList(i).ToString & "'  ")
                End If

            Next i
            'o_strSql.Append(" order by a.Intime  ")
            Dim dt As DataTable = DbOperateUtils.GetDataTable(o_strSql.ToString)
            'add by hgd 20171108 先去正式库扫描记录，如果取不到再取历史库
            If dt.Rows.Count = 0 Then
                For i As Integer = 0 To CartonList.Count - 1
                    If Not String.IsNullOrEmpty(CartonList(i).ToString) Then
                        If i > 0 Then
                            o_strSqlHis.Append(" union all ")
                        End If
                        o_strSqlHis.Append(" select distinct a.ppid from MESDBHistory.dbo.m_Cartonsn_t a left join MESDBHistory.dbo.m_BarRecordValue_t b on a.ppid =b.barcodeSNID  ")
                        o_strSqlHis.Append("  where  Cartonid='" & CartonList(i).ToString & "'  ")
                    End If

                Next i
                'o_strSqlHis.Append(" order by a.Intime  ")
                dt = DbOperateUtils.GetDataTable(o_strSqlHis.ToString)
            End If


            Dim TxtFileStr As New StringBuilder
            Dim titlestr As New StringBuilder
            Dim TxtFileStrCommon As New StringBuilder
            'Dim titlestrCommon As New StringBuilder
            '不要打印外箱
            'TxtFileStrCommon.Append("""" & CartonBarcode & """" & ",")

            TxtFileStrCommon.Append("""""" & ",")
            titlestr.Append("""barcodeSN"",")

            partId = al(0).ToString
            scanQty = dt.Rows.Count
            Weight = al(2).ToString

            '取得打印模板
            GetPrintTemplatePathbyWeightList(partId, CodeRuleId, pFilePath, cartonQty, printCO, printEAN, printHW)

            '检查错误
            'If printCO = "" Then Return False
            'If printEAN = "" Then Return False

            'Mark by cq 20170628
            ' If LabelNum = "0" Then Return False

            If LabelNum = "0" Then
                MessageUtils.ShowError("请检查【是否在线打印整箱条码(标签数)】是否维护正确!")
                Return False
            End If

            pageQty = CInt(cartonQty / LabelNum)

            TxtFileStrCommon.Append("""" & Weight & """" & ",")
            titlestr.Append("""lable10"",")
            TxtFileStrCommon.Append("""" & scanQty & """" & ",")
            titlestr.Append("""lable11"",")
            TxtFileStrCommon.Append("""" & printCO & """" & ",")
            titlestr.Append("""lable12"",")
            TxtFileStrCommon.Append("""" & printEAN & """" & ",")
            titlestr.Append("""lable13"",")
            TxtFileStrCommon.Append("""" & printHW & """" & ",")
            titlestr.Append("""lable14"",")
            TxtFileStr.Append(TxtFileStrCommon)

            Dim col As Integer = 15
            For iCnt As Integer = 0 To pageQty
                titlestr.Append("""lable" & col.ToString & """,")
                col = col + 1
            Next

            Dim pageCnt As Integer = 0
            For Each dr As DataRow In dt.Rows
                If pageCnt = pageQty Then
                    pageCnt = 0
                    TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
                    TxtFileStr.Append(vbNewLine)
                    TxtFileStr.Append(TxtFileStrCommon)
                End If
                TxtFileStr.Append("""" & dr!ppid.ToString & """" & ",")
                pageCnt = pageCnt + 1
            Next
            TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            titlestr.Remove(titlestr.Length - 1, 1)
            TxtFileStr.Append(vbNewLine)

            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCarton", "sys")
                Exit Function
            End If

            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)

            FileToBarCodePrint(pFilePath, PrintName)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '在线打印制程外箱(华为零售)
    Public Function PrintOnlineWorkList(CartonBarcode As String, partId As String, ByVal StationId As String) As Boolean

        Dim scanQty As String = ""
        Dim cartonQty As String = ""
        Dim pageQty As String
        Dim printCO As String = ""
        Dim printEAN As String = ""
        Dim printHW As String = ""
        Dim printDate As String = Date.Now.ToString("yyyyMMdd")
        Dim tempCode As String = String.Empty, strCodeRuleID As String = ""

        Try
            Dim sqlstr As String = "select ppid from m_WorkStationScanBatchD_t where BatchNo='" & CartonBarcode & "' "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr)


            Dim TxtFileStr As New StringBuilder
            Dim titlestr As New StringBuilder
            Dim TxtFileStrCommon As New StringBuilder
            Dim TxtFileStrLabelValue As New StringBuilder
            'Dim titlestrCommon As New StringBuilder
            TxtFileStrCommon.Append("""" & CartonBarcode & """" & ",")
            titlestr.Append("""barcodeSN"",")
            scanQty = dt.Rows.Count

            'Weight = al(2).ToString

            '取得打印模板
            GetPrintTemplatePathbyWork(partId, pFilePath, cartonQty, StationId)

            tempCode = pFilePath.Substring(0, pFilePath.LastIndexOf("\"))

            strCodeRuleID = tempCode.Substring(0, tempCode.IndexOf("-"))

            cartonQty = IIf(cartonQty = "", 1, cartonQty)
            '检查错误
            pageQty = CInt(cartonQty / 1)


            Dim o_dtLabel As DataTable = GetLabelValue(strCodeRuleID, partId)
            If Not IsNothing(o_dtLabel) AndAlso o_dtLabel.Rows.Count > 0 Then

                For Each dr As DataRow In o_dtLabel.Rows
                    Select Case dr.Item(0).ToString.ToUpper
                        Case "Label1".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable10"",")
                        Case "Label2".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable11"",")
                        Case "Label3".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable12"",")
                        Case "Label4".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable13"",")
                        Case "Label5".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable14"",")
                        Case "Label6".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable15"",")
                        Case "Label7".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable16"",")
                        Case "Label8".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable17"",")
                    End Select
                Next
            End If

            'TxtFileStrCommon.Append("""" & partId & """" & ",")
            'titlestr.Append("""lable10"",")
            'TxtFileStrCommon.Append("""" & scanQty & """" & ",")
            'titlestr.Append("""lable11"",")
            'TxtFileStrCommon.Append("""" & printCO & """" & ",")
            'titlestr.Append("""lable12"",")
            'TxtFileStrCommon.Append("""" & printEAN & """" & ",")
            'titlestr.Append("""lable13"",")
            'TxtFileStrCommon.Append("""" & printHW & """" & ",")
            'titlestr.Append("""lable14"",")
            'TxtFileStr.Append(TxtFileStrCommon)

            'Dim col As Integer = 10
            'For iCnt As Integer = 0 To pageQty
            '    titlestr.Append("""lable" & col.ToString & """,")
            '    col = col + 1
            'Next

            Dim pageCnt As Integer = 0
            For Each dr As DataRow In dt.Rows
                If pageCnt = pageQty Then
                    pageCnt = 0
                    TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
                    TxtFileStr.Append(vbNewLine)
                    TxtFileStr.Append(TxtFileStrCommon)
                End If
                TxtFileStr.Append("""" & dr!ppid.ToString & """" & ",")
                pageCnt = pageCnt + 1
            Next

            'add by cq 20180508
            If TxtFileStrLabelValue.ToString <> String.Empty Then
                TxtFileStr.Append(TxtFileStrLabelValue.ToString)
            End If

            TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            titlestr.Remove(titlestr.Length - 1, 1)
            TxtFileStr.Append(vbNewLine)

            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCarton", "sys")
                Exit Function
            End If

            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString, System.Text.Encoding.UTF8)

            FileToBarCodePrint(pFilePath, PrintName)
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

    '在线打印制彩盒(L01联想)
    Public Function PrintL01WorkList(Semippid As String, partId As String, ByVal StationId As String) As Boolean
        Dim scanQty As String = "", cartonQty As String = "", pageQty As String
        Dim printCO As String = "", printEAN As String = "", printHW As String = ""
        Dim printDate As String = Date.Now.ToString("yyyyMMdd")
        Dim tempCode As String = String.Empty, strCodeRuleID As String = ""
        Dim o_strMonID As String = "", o_iMonLen As Integer = 1
        Try
            Dim sqlstr As String = "select TOP 1 ppid,groupid from V_M_L01BarcodeLink_t(nolock) a join m_Mainmo_t(nolock) b on a.MOID =b.Moid join m_L01PrintGroup_t c on b.PartID =c.partid where semippid='" & Semippid & "' order by a.Intime desc "
            '8S4XD0T04868HLH00001 A11
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr)
            Dim year As String = "", month As String = "", day As String = ""
            Dim fulltime As String = ""
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("groupid") = "1" Then
                    If partId = "L01EP009-CS-H" Then
                        year = GetL01FullTime("Y4", Mid(Semippid, 22, 1))
                        month = GetL01FullTime("M2", Mid(Semippid, 23, 1))
                        day = ""
                        fulltime = year + "." + month
                    Else
                        If partId = "L01EP003-CS-H" Then  'b796 eg:8SSH30X88525ALSSSSSS 006
                            year = GetL01FullTime("Y4", Mid(Semippid, 22, 1))
                            month = GetL01FullTime("M1", Mid(Semippid, 23, 2))
                            day = ""
                            fulltime = year + "." + month
                        Else
                            year = GetL01FullTime("Y3", Mid(Semippid, 15, 1))
                            month = GetL01FullTime("M2", Mid(Semippid, 22, 1))
                            day = Mid(Semippid, 23, 2)
                            fulltime = year + "." + month + "." + day
                        End If
                    End If
                Else
                    fulltime = Date.Now.ToString("yyyy-MM-dd")
                End If
            End If

            Dim TxtFileStr As New StringBuilder, titlestr As New StringBuilder
            Dim TxtFileStrCommon As New StringBuilder, TxtFileStrLabelValue As New StringBuilder
            Dim barcodesn As String = dt.Rows(0)("ppid").ToString() & fulltime
            'Dim titlestrCommon As New StringBuilder 1S4XD0T04868HLH0000D2018.11.05
            TxtFileStrCommon.Append("""" & barcodesn & """" & ",")
            titlestr.Append("""barcodeSN"",")
            scanQty = dt.Rows.Count

            '取得打印模板
            GetPrintTemplatePathbyWork(partId, pFilePath, cartonQty, StationId)

            tempCode = pFilePath.Substring(0, pFilePath.LastIndexOf("\"))

            strCodeRuleID = tempCode.Substring(0, tempCode.IndexOf("-"))

            cartonQty = IIf(cartonQty = "", 1, cartonQty)
            '检查错误
            pageQty = CInt(cartonQty / 1)

            Dim o_dtLabel As DataTable = GetLabelValue(strCodeRuleID, partId)
            If Not IsNothing(o_dtLabel) AndAlso o_dtLabel.Rows.Count > 0 Then

                For Each dr As DataRow In o_dtLabel.Rows
                    Select Case dr.Item(0).ToString.ToUpper
                        'Case "Label1".ToUpper
                        '    TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                        '    titlestr.Append("""lable10"",")
                        Case "Label2".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable11"",")
                        Case "Label3".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable12"",")
                        Case "Label4".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable13"",")
                        Case "Label5".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable14"",")
                        Case "Label6".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable15"",")
                        Case "Label7".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable16"",")
                        Case "Label8".ToUpper
                            TxtFileStrLabelValue.Append("""" & dr.Item(1) & """" & ",")
                            titlestr.Append("""lable17"",")
                    End Select
                Next
            End If

            'TxtFileStrCommon.Append("""" & scanQty & """" & ",")
            'titlestr.Append("""lable11"",")
            'TxtFileStrCommon.Append("""" & printCO & """" & ",")
            'titlestr.Append("""lable12"",")
            'TxtFileStrCommon.Append("""" & printEAN & """" & ",")
            'titlestr.Append("""lable13"",")
            'TxtFileStrCommon.Append("""" & printHW & """" & ",")
            'titlestr.Append("""lable14"",")
            'TxtFileStr.Append(TxtFileStrCommon)

            Dim pageCnt As Integer = 0
            For Each dr As DataRow In dt.Rows
                If pageCnt = pageQty Then
                    pageCnt = 0
                    TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
                    TxtFileStr.Append(vbNewLine)
                    TxtFileStr.Append(TxtFileStrCommon)
                End If
                TxtFileStr.Append("""" & barcodesn & """" & ",")
                pageCnt = pageCnt + 1
            Next

            dt = New DataTable
            '6合一打印MAC地址
            sqlstr = "select MAC from m_Lnv6PpidLink_t where sn='" & Semippid & "'"
            dt = DbOperateUtils.GetDataTable(sqlstr)
            If dt.Rows.Count > 0 Then
                TxtFileStr.Append("""" & dt.Rows(0)("MAC") & """" & ",")
                titlestr.Append("""lable10"",")
            End If
            'add by cq 20180508
            If TxtFileStrLabelValue.ToString <> String.Empty Then
                TxtFileStr.Append(TxtFileStrLabelValue.ToString)
            End If

            TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            titlestr.Remove(titlestr.Length - 1, 1)
            TxtFileStr.Append(vbNewLine)

            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCarton", "sys")
                Exit Function
            End If
            '#If DEBUG Then
            '            pFilePath = "Pk2.btw"
            '#End If
            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString, System.Text.Encoding.UTF8)

            FileToBarCodePrint(pFilePath, PrintName)
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

    '在线打印mac 地址,cq20190902
    Public Function PrintL01MAC(Semippid As String, partId As String, ByVal StationId As String) As Boolean

        Dim scanQty As String = ""
        Dim cartonQty As String = ""
        Dim pageQty As String
        Dim printCO As String = ""
        Dim printEAN As String = ""
        Dim printHW As String = ""
        Dim printDate As String = Date.Now.ToString("yyyyMMdd")
        Dim tempCode As String = String.Empty, strCodeRuleID As String = ""

        Try
            Dim sqlstr As String = "select TOP 1 ppid,groupid from V_M_L01BarcodeLink_t(nolock) a join m_Mainmo_t(nolock) b on a.MOID =b.Moid join m_L01PrintGroup_t c on b.PartID =c.partid where semippid='" & Semippid & "' order by a.Intime desc "
            '8S4XD0T04868HLH00001 A11
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr)
            Dim year As String = ""
            Dim month As String = ""
            Dim day As String = ""
            Dim TxtFileStr As New StringBuilder
            Dim titlestr As New StringBuilder
            Dim TxtFileStrCommon As New StringBuilder
            Dim TxtFileStrLabelValue As New StringBuilder
            Dim barcodesn As String = Semippid
            'Dim titlestrCommon As New StringBuilder 1S4XD0T04868HLH0000D2018.11.05
            '  TxtFileStrCommon.Append("""" & barcodesn & """")
            '  titlestr.Append("""barcodeSN""")
            ' scanQty = dt.Rows.Count

            'Weight = al(2).ToString

            '取得打印模板
            '  GetPrintTemplatePathbyWork(partId, pFilePath, cartonQty, StationId)
            pFilePath = VbCommClass.VbCommClass.PrintDataModle & "8P1Mac.btw"

            TxtFileStr.Append("""" & barcodesn & """" & ",")
            titlestr.Append("""barcodeSN"",")

            TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            titlestr.Remove(titlestr.Length - 1, 1)
            TxtFileStr.Append(vbNewLine)

            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCarton", "sys")
                Exit Function
            End If
            '#If DEBUG Then
            '            pFilePath = "Pk2.btw"
            '#End If
            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString, System.Text.Encoding.UTF8)

            Dim o_pFilePath As String = "8P1Mac.btw"
            FileToBarCodePrint(o_pFilePath, PrintName)
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

    Public Function PrintScanBar(Semippid As String, partId As String, ByVal StationId As String) As Boolean

        Dim scanQty As String = ""
        Dim cartonQty As String = ""
        Dim pageQty As String
        Dim printCO As String = ""
        Dim printEAN As String = ""
        Dim printHW As String = ""
        Dim printDate As String = Date.Now.ToString("yyyyMMdd")
        Dim tempCode As String = String.Empty, strCodeRuleID As String = ""

        Try
            Dim sqlstr As String = "select TOP 1 ppid,groupid from V_M_L01BarcodeLink_t(nolock) a join m_Mainmo_t(nolock) b on a.MOID =b.Moid join m_L01PrintGroup_t c on b.PartID =c.partid where semippid='" & Semippid & "' order by a.Intime desc "
            '8S4XD0T04868HLH00001 A11
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr)
            Dim year As String = ""
            Dim month As String = ""
            Dim day As String = ""
            Dim TxtFileStr As New StringBuilder
            Dim titlestr As New StringBuilder
            Dim TxtFileStrCommon As New StringBuilder
            Dim TxtFileStrLabelValue As New StringBuilder
            Dim barcodesn As String = Semippid
            'Dim titlestrCommon As New StringBuilder 1S4XD0T04868HLH0000D2018.11.05
            '  TxtFileStrCommon.Append("""" & barcodesn & """")
            '  titlestr.Append("""barcodeSN""")
            ' scanQty = dt.Rows.Count

            'Weight = al(2).ToString

            '取得打印模板
            '  GetPrintTemplatePathbyWork(partId, pFilePath, cartonQty, StationId)
            pFilePath = VbCommClass.VbCommClass.PrintDataModle & "L5QUD008-CS-H.btw"

            TxtFileStr.Append("""" & barcodesn & """" & ",")
            titlestr.Append("""barcodeSN"",")

            TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            titlestr.Remove(titlestr.Length - 1, 1)
            TxtFileStr.Append(vbNewLine)

            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCarton", "sys")
                Exit Function
            End If
            '#If DEBUG Then
            '            pFilePath = "Pk2.btw"
            '#End If
            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString, System.Text.Encoding.UTF8)

            Dim o_pFilePath As String = "L5QUD008-CS-H.btw"
            FileToBarCodePrint(o_pFilePath, PrintName)
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

    ''' <summary>
    ''' 在线打印PE袋条码,初次标签打印没有使用MES
    ''' </summary>
    ''' <param name="ppid"></param>
    ''' <param name="partId"></param>
    ''' <param name="StationId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PrintL01PES(ppid As String, partId As String, ByVal StationId As String) As Boolean
        Dim scanQty As String = ""
        Dim cartonQty As String = ""
        Dim pageQty As String
        Dim printCO As String = ""
        Dim printEAN As String = ""
        Dim printHW As String = ""
        Dim printDate As String = Date.Now.ToString("yyyyMMdd")
        Dim tempCode As String = String.Empty, strCodeRuleID As String = ""
        Dim o_strLable10Value As String = ""
        Dim o_strLable11Value As String = ""
        Dim o_strLable12Value As String = ""
        Dim o_strLable13Value As String = ""
        Dim o_strLable14Value As String = ""
        Dim o_strLable15Value As String = ""
        Dim o_strLable16Value As String = ""
        Dim o_strLable17Value As String = ""
        Dim o_strLable18Value As String = ""
        Try
            Dim sqlstr As String = " SELECT A.*,B.BarArea  FROM m_SnPartSet_t A" & _
                                   " LEFT JOIN dbo.m_SnRuleD_t B ON A.F_codeID= B.F_codeID " & _
                                   " WHERE Partid ='" & partId & "'" & _
                                   " AND B.CodeRuleID =(SELECT CodeRuleID FROM  m_PartPack_t WHERE Partid ='" & partId & "' AND Packid='S') "
            '8S4XD0T04868HLH00001 A11
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr)

            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Select Case dr.Item("BarArea").ToString
                        Case "Label1"
                            o_strLable10Value = dr.Item("DValues")
                        Case "Label2"
                            o_strLable11Value = dr.Item("DValues")
                        Case "Label3"
                            o_strLable12Value = dr.Item("DValues")  'lable10
                        Case "Label4"
                            o_strLable13Value = dr.Item("DValues")
                        Case "Label5"
                            o_strLable14Value = dr.Item("DValues")
                        Case "Label6"
                            o_strLable15Value = dr.Item("DValues")
                        Case "Label7"
                            o_strLable16Value = dr.Item("DValues")
                        Case "Label8"
                            o_strLable17Value = dr.Item("DValues")
                        Case "Label9"
                            o_strLable18Value = dr.Item("DValues")
                    End Select
                Next
            End If

            Dim year As String = ""
            Dim month As String = ""
            Dim day As String = ""
            Dim TxtFileStr As New StringBuilder
            Dim titlestr As New StringBuilder
            Dim TxtFileStrCommon As New StringBuilder
            Dim TxtFileStrLabelValue As New StringBuilder
            Dim barcodesn As String = ppid
            'Dim titlestrCommon As New StringBuilder 1S4XD0T04868HLH0000D2018.11.05
            '  TxtFileStrCommon.Append("""" & barcodesn & """")
            '  titlestr.Append("""barcodeSN""")
            ' scanQty = dt.Rows.Count

            'Weight = al(2).ToString

            '取得打印模板
            GetPrintTemplatePathOfS(partId, pFilePath, cartonQty, StationId)
            ' pFilePath = VbCommClass.VbCommClass.PrintDataModle & "8P1Mac.btw"

            TxtFileStrCommon.Append("""" & barcodesn & """" & ",")
            titlestr.Append("""barcodeSN"",")


            TxtFileStrCommon.Append("""" & o_strLable10Value & """" & ",")
            titlestr.Append("""lable10"",")
            TxtFileStrCommon.Append("""" & o_strLable11Value & """" & ",")
            titlestr.Append("""lable11"",")
            TxtFileStrCommon.Append("""" & o_strLable12Value & """" & ",")
            titlestr.Append("""lable12"",")
            TxtFileStrCommon.Append("""" & o_strLable13Value & """" & ",")
            titlestr.Append("""lable13"",")
            TxtFileStrCommon.Append("""" & o_strLable14Value & """" & ",")
            titlestr.Append("""lable14"",")
            TxtFileStrCommon.Append("""" & o_strLable15Value & """" & ",")
            titlestr.Append("""lable15"",")
            TxtFileStrCommon.Append("""" & o_strLable16Value & """" & ",")
            titlestr.Append("""lable16"",")
            TxtFileStrCommon.Append("""" & o_strLable17Value & """" & ",")
            titlestr.Append("""lable17"",")
            TxtFileStrCommon.Append("""" & o_strLable18Value & """" & ",")
            titlestr.Append("""lable18"",")

            '  TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            titlestr.Remove(titlestr.Length - 1, 1)
            'TxtFileStr.Append(vbNewLine)
            TxtFileStr.Append(TxtFileStrCommon)

            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCarton", "sys")
                Exit Function
            End If
            '#If DEBUG Then
            '            pFilePath = "Pk2.btw"
            '#End If
            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString, System.Text.Encoding.UTF8)

            FileToBarCodePrint(pFilePath, PrintName)
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function


    Private Function GetL01FullTime(ByVal Unitid As String, ByVal shortdate As String)
        Try
            Dim Sqlstr As String = ""
            Dim fulltime As String = ""
            Dim RecTable As New DataTable
            Sqlstr = "SELECT TOP 1 CODESORT FROM m_SnUnitD_t WHERE UnitID='" & Unitid & "' AND CodeUnit='" & shortdate & "' ORDER BY codesort DESC "

            'Case "Y"
            '    Sqlstr = "SELECT CODESORT FROM m_SnUnitD_t WHERE UnitID='Y3' AND CodeUnit='" & shortdate & "'"

            RecTable = DbOperateUtils.GetDataTable(Sqlstr)
            fulltime = RecTable.Rows(0)("CODESORT").ToString
            RecTable.Dispose()
            Return fulltime
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function GetLabelValue(ByVal strCodeID As String, ByVal strPartID As String) As DataTable
        Dim lssql As String = String.Empty
        GetLabelValue = Nothing
        lssql = " SELECT  a.BarArea,DValues " & _
                " FROM dbo.m_SnRuleD_t A " & _
                " INNER JOIN dbo.m_SnPartSet_t B ON A.F_codeID = B.F_codeID" & _
                " WHERE A.CodeRuleID ='" & strCodeID & "'" & _
                " AND B.Partid='" & strPartID & "'" & _
                " AND BarArea LIKE 'LABEL%'" & _
                " AND  B.Usey='Y'" & _
                " AND Packid <>'S'" & _
                " AND ISNULL(DValues,'') <> ''" & _
                " ORDER BY F_orderid"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetLabelValue = o_dt
            Else
                GetLabelValue = Nothing
            End If
        End Using

    End Function

    Private Function GetLableArray(ByVal partid As String) As DataTable
        Dim lssql As String = String.Empty
        GetLableArray = Nothing
        lssql = " declare @CodeRuleID varchar(20) select @CodeRuleID = CodeRuleID from m_RPartStationD_t where PPartid = '" & partid & "' and State = 1  AND ISNULL(CodeRuleID,'') <> '' " & _
                " set @CodeRuleID = substring( @CodeRuleID,charindex('/',@CodeRuleID,3)+1,4 )  " & _
                " SELECT  BarArea,DResource FROM m_SnRuleD_t WHERE CodeRuleID =@CodeRuleID  " & _
                " and BarArea LIKE 'LABEL%' and DResource like'%Array%'"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetLableArray = o_dt
            Else
                GetLableArray = Nothing
            End If
        End Using
    End Function

    Private Function GetCartonPpidWeight(ByVal cartonId As String, ByVal moid As String) As String
        '获取箱内总产品重量
        Dim sWeight As String = ""
        Dim sb As New StringBuilder
        sb.Append(" SELECT CAST(round( SUM(CAST(W AS decimal(10,2)))/1000,2) AS decimal(10,2)) Nweight FROM( ")
        sb.Append(" select weight AS W from m_OnlineWeightPpid_t ")
        sb.Append(" where  exists(select  1 from m_Cartonsn_t b (nolock)where b.Cartonid='" & cartonId & "' ")
        sb.Append("  and b.ppid=m_OnlineWeightPpid_t.ppid)) AS T  ")
        Dim dt As DataTable = DbOperateUtils.GetDataTable(sb.ToString)
        If dt.Rows.Count > 0 Then
            sWeight = dt.Rows(0)!Nweight.ToString
        End If
        Return sWeight
    End Function


    '打印整箱
    Public Function PrintFullBatchCarton(CartonBarcode As String, LabelNum As String, al As ArrayList) As Boolean
        Dim TxtFileStr As New StringBuilder
        Dim TxtFileStrCommon As New StringBuilder
        Dim partId As String
        Dim cartonQty As String
        Dim pageQty As String
        Dim printDate As String = Date.Now.ToString("yyyyMMdd")
        Dim PN As String = ""
        Dim DW As String = ""
        Try
            Dim sqlstr As String =
                " select a.ppid from m_Cartonsn_t a left join m_BarRecordValue_t b on a.ppid =b.barcodeSNID " &
                " where  Cartonid='" & CartonBarcode & "' order by a.intime  "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr)

            Dim titlestr As New StringBuilder
            TxtFileStrCommon.Append("""" & CartonBarcode & """" & ",")
            titlestr.Append("""barcodeSN"",")

            partId = al(0).ToString
            cartonQty = dt.Rows.Count
            DW = al(2).ToString

            '为0时，设置默认为1
            LabelNum = IIf(LabelNum = 0, 1, LabelNum)
            pageQty = Math.Ceiling(CDbl(cartonQty / LabelNum))

            '取得打印模板
            GetPrintTemplatePath(partId, pFilePath, PN, "")
            GetPrintDate(DW, printDate)

            'If cartonQty <> al(1) Then
            '    'SysMessageClass.WriteErrLog(New Exception("包装箱数量实际打印不一致"), "PrintFullCarton", "StandScan", "sys")
            'End If

            TxtFileStrCommon.Append("""" & cartonQty & """" & ",")
            titlestr.Append("""lable10"",")
            TxtFileStrCommon.Append("""" & PN & """" & ",")
            titlestr.Append("""lable11"",")
            TxtFileStrCommon.Append("""" & printDate & """" & ",")
            titlestr.Append("""lable12"",")
            TxtFileStr.Append(TxtFileStrCommon)
            titlestr.Append("""lable13"",")
            TxtFileStr.Append(TxtFileStrCommon)
            titlestr.Append("""lable14"",")
            TxtFileStr.Append(TxtFileStrCommon)

            ''约定从lable15开始
            Dim col As Integer = 15
            For iCnt As Integer = 0 To pageQty - 1
                titlestr.Append("""lable" & col.ToString & """,")
                col = col + 1
            Next

            Dim pageCnt As Integer = 0
            For Each dr As DataRow In dt.Rows
                If pageCnt = pageQty Then
                    pageCnt = 0
                    TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
                    TxtFileStr.Append(vbNewLine)
                    TxtFileStr.Append(TxtFileStrCommon)
                End If
                TxtFileStr.Append("""" & dr!ppid.ToString & """" & ",")
                pageCnt = pageCnt + 1
            Next
            TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            titlestr.Remove(titlestr.Length - 1, 1)
            TxtFileStr.Append(vbNewLine)

            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCarton", "sys")
                Exit Function
            End If

            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)

            FileToBarCodePrint(pFilePath, PrintName)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    '打印整箱
    '更新日期:20191204 /田玉琳
    '更新内容:
    '1、程序开发背景： 
    '          腾讯客户要求增加外箱标签，外箱标签上需打印有箱内实际装箱产品的所有SN； 
    '2、现有MES情况： 
    '       目前MES系统可以打印外箱标签，可包含装箱内所有SN码，但是打印出来标签格式不统一； 
    '3、申请MES中开发程序，以实现标签格式统一； 
    '              1）打印外箱标签每一张中SN限定不超过20个SN码，若实际箱内产品数量大于20PCS，则增加标签数量，直至容纳所有流水码； 
    '即外箱打印标签数量=实际装箱数量除以20取整数值+X（这张标签为实际装箱数量除以20取余数，将余数SN流水码打印至这一张中。若余数=0，则X=0；若余数＞0，则X=1） 
    '              2）打印SN码要有固定排版格式（具体流水码排版方式程序开发部门可以自定），使打印出的标签标准化
    Public Function PrintFullCarton(CartonBarcode As String, LabelNum As String, al As ArrayList) As Boolean
        Dim TxtFileStr As New StringBuilder
        Dim TxtFileStrCommon As New StringBuilder
        Dim TxtFileStrCommonOther As New StringBuilder
        Dim partId As String
        Dim cartonQty As String
        Dim boxQty As Int16 = al(1)
        Dim DataQty As Integer
        Dim pageQty As String
        Dim printDate As String = Date.Now.ToString("yyyyMMdd")
        Dim PN As String = ""
        Dim DW As String = ""
        Try
            Dim sqlstr As String =
                " select a.ppid from m_Cartonsn_t a left join m_BarRecordValue_t b on a.ppid =b.barcodeSNID " &
                " where  Cartonid='" & CartonBarcode & "' order by a.intime"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr)

            Dim titlestr As New StringBuilder
            TxtFileStrCommon.Append("""" & CartonBarcode & """" & ",")
            titlestr.Append("""barcodeSN"",")

            partId = al(0).ToString
            cartonQty = dt.Rows.Count
            DW = al(2).ToString

            If al(1) = 0 Then
                Return False
            End If

            '为0时，设置默认为1
            LabelNum = IIf(LabelNum = 0, 1, LabelNum)
            pageQty = Math.Ceiling(CDbl(boxQty / LabelNum))

            '取得打印模板
            GetPrintTemplatePath(partId, pFilePath, PN, "")
            GetPrintDate(DW, printDate)

            'If cartonQty <> al(1) Then
            '    'SysMessageClass.WriteErrLog(New Exception("包装箱数量实际打印不一致"), "PrintFullCarton", "StandScan", "sys")
            'End If

            TxtFileStrCommon.Append("""" & cartonQty & """" & ",")
            titlestr.Append("""lable10"",")
            TxtFileStrCommon.Append("""" & PN & """" & ",")
            titlestr.Append("""lable11"",")
            TxtFileStrCommon.Append("""" & printDate & """" & ",")
            titlestr.Append("""lable12"",")
            TxtFileStr.Append(TxtFileStrCommon)

            Dim col As Integer = 13
            For iCnt As Integer = 0 To pageQty - 1
                titlestr.Append("""lable" & col.ToString & """,")
                col = col + 1
            Next

            '******************************田玉琳 20191129 开始*************************************
            '增加其他数据 展示所有数据
            Dim o_dtLabel As DataTable = GetLabelValue(mCodeRuleID.Split("-")(0).ToString(), partId)
            If Not IsNothing(o_dtLabel) AndAlso o_dtLabel.Rows.Count > 0 Then
                For iCnt As Integer = 0 To o_dtLabel.Rows.Count - 1
                    TxtFileStrCommonOther.Append("""" & o_dtLabel.Rows(iCnt)(1) & """" & ",")
                    titlestr.Append("""lableOther" & iCnt.ToString & """,")
                Next
            End If
            '******************************田玉琳 20191129 结束*************************************

            Dim ppid As String = ""
            Dim pageInt As Int16

            pageInt = (dt.Rows.Count \ pageQty)
            If dt.Rows.Count Mod pageQty <> 0 Then
                pageInt = pageInt + 1
            End If
            DataQty = pageInt * pageQty

            Dim pageCnt As Integer = 0
            For iCnt As Integer = 0 To DataQty - 1
                If pageCnt = pageQty Then
                    pageCnt = 0
                    TxtFileStr.Append(TxtFileStrCommonOther)    'ADD
                    TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
                    TxtFileStr.Append(vbNewLine)
                    TxtFileStr.Append(TxtFileStrCommon)
                End If
                ppid = ""
                If iCnt < dt.Rows.Count Then
                    ppid = dt.Rows(iCnt)(0).ToString
                End If

                TxtFileStr.Append("""" & ppid & """" & ",")
                pageCnt = pageCnt + 1
            Next


            'For Each dr As DataRow In dt.Rows
            '    If pageCnt = pageQty Then
            '        pageCnt = 0
            '        TxtFileStr.Append(TxtFileStrCommonOther)    'ADD
            '        TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            '        TxtFileStr.Append(vbNewLine)
            '        TxtFileStr.Append(TxtFileStrCommon)
            '    End If
            '    TxtFileStr.Append("""" & dr!ppid.ToString & """" & ",")
            '    pageCnt = pageCnt + 1
            'Next

            TxtFileStr.Append(TxtFileStrCommonOther)  'ADD
            TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            titlestr.Remove(titlestr.Length - 1, 1)
            TxtFileStr.Append(vbNewLine)

            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCarton", "sys")
                Exit Function
            End If

            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)

            FileToBarCodePrint(pFilePath, PrintName)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '打印整箱
    '更新日期:20200227 /田玉琳
    '更新内容:
    '1、程序开发背景： 
    '          腾讯客户要求增加外箱标签，外箱标签上需打印有箱内实际装箱产品的所有SN； 
    '2、现有MES情况： 
    '       目前MES系统可以打印外箱标签，可包含装箱内所有SN码，但是打印出来标签格式不统一； 
    '3、申请MES中开发程序，以实现标签格式统一； 
    '              1）打印外箱标签每一张中SN限定不超过20个SN码，若实际箱内产品数量大于20PCS，则增加标签数量，直至容纳所有流水码； 
    '即外箱打印标签数量=实际装箱数量除以20取整数值+X（这张标签为实际装箱数量除以20取余数，将余数SN流水码打印至这一张中。若余数=0，则X=0；若余数＞0，则X=1） 
    '              2）打印SN码要有固定排版格式（具体流水码排版方式程序开发部门可以自定），使打印出的标签标准化
    '更新日期:20200227 /田玉琳
    '1.取得根据关联条码取得过站条码，同时打印关联数据打印
    Public Function PrintFullCartonHWHL(CartonBarcode As String, LabelNum As String, al As ArrayList) As Boolean
        Dim TxtFileStr As New StringBuilder
        Dim TxtFileStrCommon As New StringBuilder
        Dim TxtFileStrCommonOther As New StringBuilder
        Dim partId As String
        Dim cartonQty As String
        Dim boxQty As Int16 = al(1)
        Dim DataQty As Integer
        Dim pageQty As String
        Dim printDate As String = Date.Now.ToString("yyyyMMdd")
        Dim PN As String = ""
        Dim DW As String = ""
        Try
            Dim sqlstr As String =
                " SELECT distinct link.PPID2 ppid from m_Cartonsn_t a INNER JOIN m_HWHLPPIDLink_t link ON a.ppid = link.PPID AND Itemid = 1" &
                " where  Cartonid='" & CartonBarcode & "' order by link.PPID2"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr)

            Dim titlestr As New StringBuilder
            TxtFileStrCommon.Append("""" & CartonBarcode & """" & ",")
            titlestr.Append("""barcodeSN"",")

            partId = al(0).ToString
            cartonQty = dt.Rows.Count
            DW = al(2).ToString

            'If al(1) = 0 Then
            '    Return False
            'End If

            '为0时，设置默认为1
            LabelNum = IIf(LabelNum = 0, 1, LabelNum)
            pageQty = Math.Ceiling(CDbl(boxQty / LabelNum))

            '取得打印模板
            GetPrintTemplatePath(partId, pFilePath, PN, "")
            GetPrintDate(DW, printDate)

            'If cartonQty <> al(1) Then
            '    'SysMessageClass.WriteErrLog(New Exception("包装箱数量实际打印不一致"), "PrintFullCarton", "StandScan", "sys")
            'End If

            TxtFileStrCommon.Append("""" & cartonQty & """" & ",")
            titlestr.Append("""lable10"",")
            TxtFileStrCommon.Append("""" & PN & """" & ",")
            titlestr.Append("""lable11"",")
            TxtFileStrCommon.Append("""" & printDate & """" & ",")
            titlestr.Append("""lable12"",")
            TxtFileStr.Append(TxtFileStrCommon)

            Dim col As Integer = 13
            For iCnt As Integer = 0 To pageQty - 1
                titlestr.Append("""lable" & col.ToString & """,")
                col = col + 1
            Next

            '******************************田玉琳 20191129 开始*************************************
            '增加其他数据 展示所有数据
            Dim o_dtLabel As DataTable = GetLabelValue(mCodeRuleID.Split("-")(0).ToString(), partId)
            If Not IsNothing(o_dtLabel) AndAlso o_dtLabel.Rows.Count > 0 Then
                For iCnt As Integer = 0 To o_dtLabel.Rows.Count - 1
                    TxtFileStrCommonOther.Append("""" & o_dtLabel.Rows(iCnt)(1) & """" & ",")
                    titlestr.Append("""lableOther" & iCnt.ToString & """,")
                Next
            End If
            '******************************田玉琳 20191129 结束*************************************

            Dim ppid As String = ""
            Dim pageInt As Int16

            pageInt = (dt.Rows.Count \ pageQty)
            If dt.Rows.Count Mod pageQty <> 0 Then
                pageInt = pageInt + 1
            End If
            DataQty = pageInt * pageQty

            Dim pageCnt As Integer = 0
            For iCnt As Integer = 0 To DataQty - 1
                If pageCnt = pageQty Then
                    pageCnt = 0
                    TxtFileStr.Append(TxtFileStrCommonOther)    'ADD
                    TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
                    TxtFileStr.Append(vbNewLine)
                    TxtFileStr.Append(TxtFileStrCommon)
                End If
                ppid = ""
                If iCnt < dt.Rows.Count Then
                    ppid = dt.Rows(iCnt)(0).ToString
                End If

                TxtFileStr.Append("""" & ppid & """" & ",")
                pageCnt = pageCnt + 1
            Next

            TxtFileStr.Append(TxtFileStrCommonOther)  'ADD
            TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            titlestr.Remove(titlestr.Length - 1, 1)
            TxtFileStr.Append(vbNewLine)

            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCartonHWHL", "sys")
                Exit Function
            End If

            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)

            FileToBarCodePrint(pFilePath, PrintName)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    '打印L01整箱
    Public Function PrintL01FullCarton(CartonBarcode As String, LabelNum As String, al As ArrayList) As Boolean
        Dim TxtFileStr As New StringBuilder
        Dim TxtFileStrCommon As New StringBuilder
        Dim partId As String
        Dim cartonQty As String
        Dim pageQty As String
        Dim printDate As String = Date.Now.ToString("yyyy.MM.dd")
        Dim PN As String = ""
        Dim DW As String = ""
        Try
            Dim sqlstr As String =
                " select distinct a.ppid from m_Cartonsn_t a left join m_BarRecordValue_t b on a.ppid =b.barcodeSNID " &
                " where  Cartonid='" & CartonBarcode & "' "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr)

            Dim titlestr As New StringBuilder
            TxtFileStrCommon.Append("""" & CartonBarcode & """" & ",")
            titlestr.Append("""barcodeSN"",")

            partId = al(0).ToString
            cartonQty = dt.Rows.Count
            DW = al(2).ToString

            '为0时，设置默认为1
            LabelNum = IIf(LabelNum = 0, 1, LabelNum)
            pageQty = Math.Ceiling(CDbl(cartonQty / LabelNum))

            '取得打印模板
            GetPrintTemplatePath(partId, pFilePath, PN, "")
            ' GetPrintDate(DW, printDate)

            'If cartonQty <> al(1) Then
            '    'SysMessageClass.WriteErrLog(New Exception("包装箱数量实际打印不一致"), "PrintFullCarton", "StandScan", "sys")
            'End If

            TxtFileStrCommon.Append("""" & cartonQty & """" & ",")
            titlestr.Append("""lable10"",")
            TxtFileStrCommon.Append("""" & PN & """" & ",")
            titlestr.Append("""lable11"",")
            TxtFileStrCommon.Append("""" & printDate & """" & ",")
            titlestr.Append("""lable12"",")
            TxtFileStr.Append(TxtFileStrCommon)


            Dim col As Integer = 13

            'If IsL01PartStartZero(partId) Then
            '    For iCnt As Integer = 0 To pageQty - 1
            '        titlestr.Append("""lable" & col.ToString & """,")
            '        col = col + 1
            '    Next
            'Else
            '    For iCnt As Integer = 0 To pageQty
            '        titlestr.Append("""lable" & col.ToString & """,")
            '        col = col + 1
            '    Next
            'End If

            For iCnt As Integer = 0 To pageQty
                titlestr.Append("""lable" & col.ToString & """,")
                col = col + 1
            Next
         

            Dim pageCnt As Integer = 0
            For Each dr As DataRow In dt.Rows
                If pageCnt = pageQty Then
                    pageCnt = 0
                    TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
                    TxtFileStr.Append(vbNewLine)
                    TxtFileStr.Append(TxtFileStrCommon)
                End If
                TxtFileStr.Append("""" & dr!ppid.ToString & """" & ",")
                pageCnt = pageCnt + 1
            Next
            TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            titlestr.Remove(titlestr.Length - 1, 1)
            TxtFileStr.Append(vbNewLine)
            '#If DEBUG Then
            '            pFilePath = "PK3.btw"
            '#End If
            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCarton", "sys")
                Exit Function
            End If

            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)

            FileToBarCodePrint(pFilePath, PrintName)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function IsL01PartStartZero(strPartID)
        Dim lssql As String = String.Empty
        lssql = "select top 1 1 from m_L01PartStartZero_t where partid ='" & strPartID & "' "
        Try
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lssql)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    IsL01PartStartZero = True
                Else
                    IsL01PartStartZero = False
                End If
            End Using
            Return IsL01PartStartZero
        Catch ex As Exception
             Return False
        End Try

    End Function

    '在线打印整个外箱 QR
    Public Function PrintOnlineFullCartonQR(CartonBarcode As String, LabelNum As String, pFilePath As String, al As ArrayList) As Boolean
        Dim TxtFileStr As New StringBuilder
        Dim TxtFileStrCommon As New StringBuilder
        Dim partId As String
        Dim cartonQty As String
        Dim pageQty As String
        Dim printDate As String = "LUX" & Date.Now.ToString("MMddyyhhmm")
        Dim PN As String = ""
        Dim PO As String = ""
        'Dim DW As String = ""
        Try
            Dim sqlstr As String =
                " select distinct a.ppid from m_Cartonsn_t a left join m_BarRecordValue_t b on a.ppid =b.barcodeSNID " &
                " where  Cartonid='" & CartonBarcode & "' "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr)

            Dim titlestr As New StringBuilder
            TxtFileStrCommon.Append("""" & CartonBarcode & """" & ",")
            titlestr.Append("""barcodeSN"",")

            partId = al(0).ToString
            cartonQty = dt.Rows.Count

            '为0时，设置默认为1
            LabelNum = IIf(LabelNum = 0, 1, LabelNum)
            pageQty = Math.Ceiling(CDbl(cartonQty / LabelNum))

            Dim files As String = ""
            '取得打印模板
            GetPrintTemplatePath(partId, files, PN, PO)

            '******************************田玉琳 20190419 开始*************************************
            '增加其他数据 展示所有数据
            Dim o_dtLabel As DataTable = GetLabelValue(mCodeRuleID.Split("-")(0).ToString(), partId)
            If Not IsNothing(o_dtLabel) AndAlso o_dtLabel.Rows.Count > 0 Then
                For iCnt As Integer = 0 To o_dtLabel.Rows.Count - 1
                    TxtFileStrCommon.Append("""" & o_dtLabel.Rows(iCnt)(1) & """" & ",")
                    titlestr.Append("""lableOther" & iCnt.ToString & """,")
                Next
            End If
            '******************************田玉琳 20190419 结束*************************************

            TxtFileStrCommon.Append("""" & cartonQty & """" & ",")
            titlestr.Append("""lable10"",")
            TxtFileStrCommon.Append("""" & PN & """" & ",")
            titlestr.Append("""lable11"",")
            TxtFileStrCommon.Append("""" & printDate & """" & ",")
            titlestr.Append("""lable12"",")
            TxtFileStrCommon.Append("""" & PO & """" & ",")
            titlestr.Append("""lable13"",")
            TxtFileStrCommon.Append("""")
            TxtFileStr.Append(TxtFileStrCommon)

            titlestr.Append("""lable14"",")

            Dim pageCnt As Integer = 0
            For Each dr As DataRow In dt.Rows
                TxtFileStr.Append(dr!ppid.ToString & vbTab)
                pageCnt = pageCnt + 1
            Next
            'TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            TxtFileStr.Append(""",")
            'TxtFileStr.Append(vbNewLine)
            '*********************************************
            Dim col As Integer = 15
            For iCnt As Integer = 0 To pageQty
                titlestr.Append("""lable" & col.ToString & """,")
                col = col + 1
            Next

            pageCnt = 0
            For Each dr As DataRow In dt.Rows
                If pageCnt = pageQty Then
                    pageCnt = 0
                    TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
                    TxtFileStr.Append(vbNewLine)
                    TxtFileStr.Append(TxtFileStrCommon)
                End If
                TxtFileStr.Append("""" & dr!ppid.ToString & """" & ",")
                pageCnt = pageCnt + 1
            Next
            TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            titlestr.Remove(titlestr.Length - 1, 1)
            TxtFileStr.Append(vbNewLine)
            '*********************************************

            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCarton", "sys")
                Exit Function
            End If

            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)

            FileToBarCodePrint(pFilePath, PrintName)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '在线打印整个外箱 QR
    Public Function PrintOnlineFullCartonA4(CartonBarcode As String, LabelNum As String, al As ArrayList) As Boolean
        Dim TxtFileStr As New StringBuilder
        Dim TxtFileStrCommon As New StringBuilder
        Dim partId As String
        Dim cartonQty As String
        Dim pageQty As String
        Dim printDate As String = "LUX" & Date.Now.ToString("MMddyyhhmm")
        Dim PN As String = ""
        Dim PO As String = ""
        'Dim DW As String = ""
        Try
            Dim sqlstr As String =
                " select distinct a.ppid from m_Cartonsn_t a left join m_BarRecordValue_t b on a.ppid =b.barcodeSNID " &
                " where  Cartonid='" & CartonBarcode & "' "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sqlstr)

            Dim titlestr As New StringBuilder
            TxtFileStrCommon.Append("""" & CartonBarcode & """" & ",")
            titlestr.Append("""barcodeSN"",")

            partId = al(0).ToString
            cartonQty = dt.Rows.Count

            '为0时，设置默认为1
            LabelNum = IIf(LabelNum = 0, 1, LabelNum)
            'DW = al(2).ToString
            pageQty = Math.Ceiling(CDbl(cartonQty / LabelNum))

            '取得打印模板
            GetPrintTemplatePath(partId, pFilePath, PN, PO)
            'GetPrintDate(DW, printDate)

            'If cartonQty <> al(1) Then
            '    'SysMessageClass.WriteErrLog(New Exception("包装箱数量实际打印不一致"), "PrintFullCarton", "StandScan", "sys")
            'End If

            TxtFileStrCommon.Append("""" & cartonQty & """" & ",")
            titlestr.Append("""lable10"",")
            TxtFileStrCommon.Append("""" & PN & """" & ",")
            titlestr.Append("""lable11"",")
            TxtFileStrCommon.Append("""" & printDate & """" & ",")
            titlestr.Append("""lable12"",")
            TxtFileStrCommon.Append("""" & PO & """" & ",")
            titlestr.Append("""lable13"",")
            TxtFileStrCommon.Append("""")
            TxtFileStr.Append(TxtFileStrCommon)


            'Dim col As Integer = 14
            'For iCnt As Integer = 0 To pageQty
            '    titlestr.Append("""lable" & col.ToString & """,")
            '    col = col + 1
            'Next
            titlestr.Append("""lable14""")

            Dim pageCnt As Integer = 0
            For Each dr As DataRow In dt.Rows
                'If pageCnt = pageQty Then
                '    pageCnt = 0
                '    TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
                '    TxtFileStr.Append(vbNewLine)
                '    TxtFileStr.Append(TxtFileStrCommon)
                'End If
                TxtFileStr.Append(dr!ppid.ToString & vbTab)
                pageCnt = pageCnt + 1
            Next
            TxtFileStr.Remove(TxtFileStr.Length - 1, 1)
            'titlestr.Remove(titlestr.Length - 1, 1)
            TxtFileStr.Append("""")
            TxtFileStr.Append(vbNewLine)

            If pFilePath = "" Then
                SysMessageClass.WriteErrLog(New Exception("打印模板文件没有取到"), "PrintBarcode", "PrintFullCarton", "sys")
                Exit Function
            End If

            TxtFileStr.Insert(0, titlestr.ToString & vbNewLine)
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)

            FileToBarCodePrint(pFilePath, PrintName)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '重新打印PE袋
    Public Sub RepeatPEPocketPrint(partId As String, code As String)
        Dim textFile As New StringBuilder()
        textFile = GetPrintData(code, "C")
        File.WriteAllText(Application.StartupPath & "\Bartender.txt", textFile.ToString)
        If pFilePath = "" Then
            GetPrintTemplatePath(partId, pFilePath, 1, "")
        End If
        FileToBarCodePrint(pFilePath, PrintName)
    End Sub

#End Region

#Region "生成对应条码"

    ''' <summary>
    ''' 生成对应PE袋条码
    ''' 以后不用就删除
    ''' </summary>
    ''' <param name="o_blnPrint"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CMainMarkSCode(Optional ByVal o_blnPrint As Boolean = True) As Boolean
        Dim I, N As Int16
        Dim SqlStr As New System.Text.StringBuilder
        Dim CurrNum As Int16 = 0
        Dim CurrSBCode As New StringBuilder
        Dim StartCode As String = ""
        Try

            Dim strScanSeq As String
            LoadM.SetSBCode(CurrSBCode, SBCodeLEN, SBCodeUnit, LoadD.BarCodeStyleMax)
            CurrCodeUnitTable = LoadM.SetCurrCodeUnitTable(SBCodeLEN, SBCodeUnit)
            PrintStr.Remove(0, PrintStr.Length)
            ReDim PrintPart(2, 0)
            strScanSeq = strScanBarcode.Substring(CInt(scanStartSeq) - 1, CInt(scanEndSeq) - CInt(scanStartSeq) + 1)

            For I = 1 To LoadD.CurrPrintNum
                Dim dtTemp As DataTable
                CurrSBCode = LoadM.MarkSBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable)
                If CurrSBCode.ToString = "" Then
                    Exit For
                End If

                If I = 1 Then
                    StartCode = CurrSBCode.ToString
                End If

                AxTempCode.Remove(LoadD.AxSPos, SBCodeLEN)
                AxTempCode.Insert(LoadD.AxSPos, strScanSeq.ToString)

                If LblTempCode.ToString <> "" Then
                    LblTempCode.Remove(LoadD.LblSPos, SBCodeLEN)
                    LblTempCode.Insert(LoadD.LblSPos, CurrSBCode.ToString)
                End If

                CurrNum += 1
                N += 1

                ReDim Preserve PrintPart(2, N)
                PrintPart(1, N) = AxTempCode.ToString
                PrintPart(2, N) = LblTempCode.ToString

                If N = LoadD.PrintColNum Then
                    CModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0
                ElseIf N < LoadD.PrintColNum AndAlso I = LoadD.CurrPrintNum Then
                    CModlePrintGenRecord()
                    ReDim PrintPart(2, 0)
                    N = 0S
                End If

                dtTemp = DbOperateUtils.GetDataTable("SELECT SBarCode FROM m_SnSBarCode_t WHERE SBarCode='" & AxTempCode.ToString & "' ")
                If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then
                    Return False
                End If

                SqlStr.Append(vbNewLine & "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" & AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LoadM.DefaultLine & "','" & Packid & "'," & PrtArray.Qty & ",'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(PrintDate).ToString("yyyy-MM-dd").ToString & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')")
                SqlStr.Append(vbNewLine & "INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty) VALUES('" & LoadD.CurrAVCPartID & "','" & LoadD.CurrMoid & "','" & Packid & "','" & PackItems & "','" & LoadM.PackingLevel & "','" & AxTempCode.ToString & "','" & PrtArray.Qty & "')")
            Next
            LoadD.BarCodeStyleMax = CurrSBCode.ToString
            LoadD.CurrMaxInt = LoadD.CurrMaxInt + CurrNum
            MoidPrinted += LoadD.CurrPrintNum

            SqlStr.Append(vbNewLine & "insert into m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " & _
                                      " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LineId & "','C','" & LoadD.StyleID & "'," & PackMethod & "," & LoadD.CurrPrintNum & ",'" & CurrSBCode.ToString & "','" & CDate(PrintDate).ToString("yyyy-MM-dd").ToString & "','" & SysMessageClass.UseId.ToLower & "',getdate())")
            SqlStr.Append(vbNewLine & BarValueStr.ToString())
            If o_blnPrint Then
                BarFile.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
                File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            End If
            If SqlStr.ToString() <> "" Then
                DbOperateUtils.ExecSQL(SqlStr.ToString)
                If o_blnPrint Then
                    FileToBarCodePrint(pFilePath, PrintName)
                End If
            End If
            strPrintBarcode = AxTempCode.ToString
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '生成序號入口函數
    Public Function MainMarkSCode(ByVal UseY As String) As Boolean
        Dim SqlStr As String = ""
        Dim CurrSBCode As New StringBuilder
        Dim StartCode As String = ""
        Dim blnNoSeq As Boolean = False
        Try
            '打印前準備工作
            LoadM.SetSBCode(CurrSBCode, SBCodeLEN, SBCodeUnit, LoadD.BarCodeStyleMax)
            If Val(SBCodeLEN) > 0 Then
                CurrCodeUnitTable = LoadM.SetCurrCodeUnitTable(SBCodeLEN, SBCodeUnit)
            Else
                blnNoSeq = True
            End If
            PrtStrTable = LoadM.SetPrtStrTable(LoadD.PFormat)
            PrintStr.Remove(0, PrintStr.Length)

            If UseY = "N" Then   '測試打印條碼
                SqlStr = "update m_SnStyle_t set IsUsed='N' where StyleID='" & LoadD.StyleID & "'"
            Else '正式打印條碼
                '如果取不到数据，返回不正确
                'If GetPackItem(strPackItem, strPackId) = False Then Return False
                If (Not blnNoSeq) Then
                    If CurrSBCode.ToString = LoadD.EndSn.ToString Then Return False
                    CurrSBCode = LoadM.MarkSBCode(CurrSBCode, 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable)
                    If CurrSBCode.ToString = "" Then Return False

                    AxTempCode.Remove(LoadD.AxSPos, SBCodeLEN)
                    AxTempCode.Insert(LoadD.AxSPos, CurrSBCode.ToString)

                    LoadD.BarCodeStyleMax = CurrSBCode.ToString
                    LoadD.CurrMaxInt = LoadD.CurrMaxInt + 1
                Else
                    mCartonId = GenOuterCartonID(LoadD.CurrMoid)
                End If
            End If

            Dim sBarCode As String = ""
            If (Not blnNoSeq) Then
                sBarCode = AxTempCode.ToString()
            Else
                sBarCode = mCartonId
                SqlStr = "DELETE FROM m_SnSBarCode_t WHERE SBarCode='" & sBarCode & "'"
            End If

            SqlStr &= " IF NOT EXISTS(SELECT 1 FROM m_Carton_t WHERE Cartonid='" & sBarCode & "')  " &
                    " BEGIN " &
                    " INSERT INTO m_Carton_t(Cartonid,Moid,StationId,StationName,Cartonqty,PackingQuantity,CartonStatus, " &
                    " Teamid,Userid,Intime,Packlink,CartonLevel,PACKID,PACKITEM,Spoint) " &
                    " SELECT '" & sBarCode & "',   " &
                    " '" & LoadD.CurrMoid & "','" & mStaionId & "', N'" & mStaionName & "',0," & Int(BoxQty) & ",'N','" & LineId & "', " &
                    " '" & SysMessageClass.UseId & "',getdate(),'P',1, '" & Packid & "','" & PackItems & "','" & My.Computer.Name & "' " &
                    " END "
            SqlStr &= " INSERT INTO m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate) values('" & sBarCode & "','" &
                     LoadD.CurrMoid & "','" & LineId & "','" & Packid & "'," & Int(BoxQty) & ",'" & UseY & "','" & SysMessageClass.UseId.ToLower & "',getdate(),'" &
                     CDate(mCartonDate.ToString).ToString("yyyy-MM-dd").ToString & "')"
            SqlStr &= "update m_SnStyle_t set MaxInt=" & LoadD.CurrMaxInt & ",MaxSN='" & LoadD.BarCodeStyleMax & "',IsUsed='N' where StyleID='" & LoadD.StyleID & "'"
            SqlStr &= "update m_Mainmo_t set PkgPrtQty=isnull(PkgPrtQty,0) + 1 where Moid='" & LoadD.CurrMoid & "'"
            '打印記錄信息
            SqlStr &= "insert into m_PrtRecord_t(Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " &
                      " values('" & LoadD.CurrMoid & "','" & LineId & "','" & Packid & "','" & LoadD.StyleID & "'," & Int(BoxQty) & ",1,'" &
                      CurrSBCode.ToString & "~" & CurrSBCode.ToString & "','" & CDate(mCartonDate.ToString).ToString("yyyy-MM-dd").ToString &
                      "','" & SysMessageClass.UseId.ToLower & "',getdate())"

            SqlStr &= vbNewLine & "INSERT  INTO m_MOPackingLevel(PartId, MOId, PackId, PackItem, PackingLevel,SBarCode,qty) " & _
           "VALUES('" & LoadD.CurrAVCPartID & "','" & LoadD.CurrMoid & "','" & Packid & "','" & PackItems & "','" & LoadM.PackingLevel & "','" & sBarCode & "','" & Int(BoxQty) & "')"

            If SqlStr <> "" Then
                DbOperateUtils.ExecSQL(SqlStr)
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 生成PE袋条码号
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MainMarkCCode(ByRef OutMsg As String) As Boolean
        Dim SqlStr As New System.Text.StringBuilder
        Dim CurrNum As Int16 = 0
        Dim CurrSBCode As New StringBuilder
        Dim strScanSeq As String
        Try
            '扫描过数据，退出 
            If GetAssysnDCnt() > 0 Then
                OutMsg = String.Format("扫描条码{0}已经打印对应箱/PE袋标签...", strScanBarcode)
                Return False
            End If

            If mCartonSame.ToUpper = "N" Then

                'Mark by cq 20170927
                'If CInt(scanStartSeq) + CInt(scanEndSeq) - CInt(scanStartSeq) > strScanBarcode.Length Then
                '    OutMsg = "条码的料件打印参数值的长度必须和设定的长度值相同，请联系标签室重新设置！"
                '    Return False
                'End If

                'If LoadD.CurrAVCPartID = "L99HM075-SD-R" Then
                '    strScanSeq = strScanBarcode.Substring(strScanBarcode.LastIndexOf("S") + 1, CInt(scanEndSeq) - CInt(scanStartSeq) + 1)
                'Else
                '    strScanSeq = strScanBarcode.Substring(CInt(scanStartSeq) - 1, CInt(scanEndSeq) - CInt(scanStartSeq) + 1)
                'End If
                '************************************** 田玉琳 修改 20170928 开始 **************************************
                '取得编码原则中长度设置差异数
                Dim diff As Integer = 0
                GetRuleCodeIdDiff(diff)
                If CInt(scanStartSeq) - diff < 1 Then
                    strScanSeq = strScanBarcode.Substring(0, CInt(scanEndSeq) - CInt(scanStartSeq) + 1)
                Else
                    strScanSeq = strScanBarcode.Substring(CInt(scanStartSeq) - diff - 1, CInt(scanEndSeq) - CInt(scanStartSeq) + 1)
                End If
                '************************************** 田玉琳 修改 20170928 结束 **************************************

                AxTempCode.Remove(LoadD.AxSPos, strScanSeq.Length)
                AxTempCode.Insert(LoadD.AxSPos, strScanSeq.ToString)

                If LblTempCode.ToString <> "" Then
                    LblTempCode.Remove(LoadD.LblSPos, strScanSeq.Length)
                    LblTempCode.Insert(LoadD.LblSPos, strScanSeq.ToString)
                End If
                strPrintBarcode = AxTempCode.ToString.Trim

                If (IsRework = False) Then
                    '做存打印记录
                    ModlePrintGenRecord("C", "N")

                    SqlStr.Append(vbNewLine & " INSERT INTO m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " &
                                " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LineId & "','" & Packid & "','" & LoadD.StyleID & "'," & PackMethod & "," &
                                "1,'" & strScanSeq.ToString & "','" & CDate(PrintDate).ToString("yyyy-MM-dd").ToString & "','" &
                                SysMessageClass.UseId.ToLower & "',getdate())")

                End If
            Else
                strScanSeq = ""
                strPrintBarcode = AxTempCode.ToString.Trim

                If (IsRework = False) Then
                    '做存打印记录  /无流水
                    NBarCodePrint("C", "N")

                    SqlStr.Append(vbNewLine & " INSERT INTO m_PrtRecord_t(Ptaskid,Moid, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) " &
                                " values('" & LoadM.Taskid & "','" & LoadD.CurrMoid & "','" & LineId & "','C','" & LoadD.StyleID & "'," & PackMethod & "," &
                                "1,'" & strScanSeq.ToString & "','" & CDate(PrintDate).ToString("yyyy-MM-dd").ToString & "','" &
                                SysMessageClass.UseId.ToLower & "',getdate())")
                End If
            End If

            '增加没有生成箱号时，要提示找标签室重新设置编码原则
            If String.IsNullOrEmpty(mCartonId) = True Then
                OutMsg = "没有生成对应箱号，请联系标签室确认设置的编码原则！"
                Return False
            End If

            '扫描条码：  strScanBarcode  PE袋条码：  AxTempCode  箱条码：mCartonId
            SqlStr.Append(" if NOT exists(select SbarCode from m_SnSBarCode_t where SBarCode=N'" & AxTempCode.ToString & "')    begin " &
              "insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel) values('" &
               AxTempCode.ToString & "','" & LoadD.CurrMoid & "','" & LineId & "','C'," & BoxQty & ",'Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" &
               CDate(PrintDate).ToString("yyyy-MM-dd").ToString & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "') end ")
            SqlStr.Append(" UPDATE m_SnSBarCode_t SET UseY = 'S' WHERE SBarCode = '" & strScanBarcode & "'") '更新扫描状态
            '加入箱数据 （更新箱内数量）
            SqlStr.Append(vbNewLine & " DECLARE @Cartonqty VARCHAR(10),@PackingQuantity VARCHAR(10) ")
            SqlStr.Append(String.Format("  SELECT @Cartonqty = Cartonqty ,@PackingQuantity = PackingQuantity  from m_Carton_t where Cartonid  ='{0}'", mCartonId))
            SqlStr.Append(String.Format("  IF  {0} <>  @PackingQuantity ", BoxQty))
            SqlStr.Append(String.Format("  BEGIN SET @PackingQuantity = {0}  END", BoxQty))
            SqlStr.Append("  IF  @Cartonqty + 1 =  @PackingQuantity ")
            SqlStr.Append("  BEGIN ")
            SqlStr.Append("  UPDATE m_Carton_t SET Cartonqty = Cartonqty +1,CartonStatus = 'Y',PackingQuantity= @PackingQuantity,INTIME=GETDATE() where Cartonid = '" & mCartonId & "' ")
            SqlStr.Append("  END ELSE BEGIN")
            SqlStr.Append("  UPDATE m_Carton_t SET Cartonqty = Cartonqty +1,INTIME=GETDATE() where Cartonid = '" & mCartonId & "' ")
            SqlStr.Append("  END ")
            SqlStr.Append(vbNewLine & " INSERT INTO M_CARTONSN_T (PPID,CARTONID,USERID,INTIME) VALUES('" & strScanBarcode & "','" & mCartonId & "','" & SysMessageClass.UseId & "',getdate())")
            SqlStr.Append(vbNewLine & " DECLARE @Revid VARCHAR(10),@StaOrderid VARCHAR(10), @ScanOrderid VARCHAR(10)")
            SqlStr.Append(vbNewLine & String.Format(" SELECT @Revid = Revid ,@StaOrderid = StaOrderid ,@ScanOrderid = ScanOrderid FROM m_RPartStationD_t where PPartid = '{0}' AND State = 1", LoadD.CurrAVCPartID))
            SqlStr.Append(vbNewLine & " INSERT INTO m_Ppidlink_t (Exppid,StaOrderid,ScanOrderid,Itemid,Ppid,Usey,Userid,Intime,Tpartid,StationId,Partid,Revid,Mark1) VALUES('" &
                strScanBarcode & " ',@StaOrderid,@ScanOrderid,1,'" & AxTempCode.ToString & "','Y','" & SysMessageClass.UseId & "',getdate(),'" & LoadD.CurrAVCPartID & "','" & mStaionId & "',' " &
                LoadD.CurrAVCPartID & "',@Revid,'" & LoadD.CurrMoid & "')")
            SqlStr.Append(vbNewLine & " IF NOT EXISTS(SELECT Exppid  FROM m_Ppidlink_t WHERE Exppid='" & AxTempCode.ToString & "' and StaOrderid = @StaOrderid and ScanOrderid = @ScanOrderid and Itemid = 1) ")
            SqlStr.Append(vbNewLine & " BEGIN INSERT INTO m_Ppidlink_t (Exppid,StaOrderid,ScanOrderid,Itemid,Ppid,Usey,Userid,Intime,Tpartid,StationId,Partid,Revid,Mark1) VALUES('" &
                AxTempCode.ToString & " ',@StaOrderid,@ScanOrderid,1,'" & AxTempCode.ToString & "','Y','" & SysMessageClass.UseId & "',getdate(),'" & LoadD.CurrAVCPartID & "','" & mStaionId & "',' " &
                LoadD.CurrAVCPartID & "',@Revid,'" & LoadD.CurrMoid & "')END")

            SqlStr.Append(vbNewLine & " IF NOT EXISTS( SELECT 1 FROM  m_Assysn_t where Ppid = '" & strScanBarcode & "' ) " &
                          "BEGIN INSERT M_ASSYSN_T (ppid,moid,stationid,Estateid,teamid,spoint,userid,intime) VALUES('" & strScanBarcode &
                            " ','" & LoadD.CurrMoid & "','" & mStaionId & "','Y','" & LineId & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "',getdate()) END")
            SqlStr.AppendFormat(vbNewLine & " ELSE BEGIN UPDATE m_Assysn_t SET STATIONID = '{0}' ,INTIME =GETDATE() WHERE PPID = '{1}' END", mStaionId, strScanBarcode)
            SqlStr.Append(vbNewLine & " IF NOT EXISTS( SELECT 1 FROM  M_ASSYSND_T where Ppid = '" & strScanBarcode & "' and STATIONID = '" & mStaionId & "' )" &
                          " BEGIN INSERT M_ASSYSND_T(MOID,PPID,STATIONID,SITEM,ESTATEID,TEAMID,SPOINT,USERID,INTIME)VALUES('" & LoadD.CurrMoid &
                   " ','" & strScanBarcode & "','" & mStaionId & "','1','Y','" & LineId & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "',getdate()) END")

            SqlStr.Append(vbNewLine & " IF EXISTS( SELECT 1 FROM  M_PARTINPUT_T where PARTID = '" & LoadD.CurrAVCPartID & "' and usey='Y')")
            SqlStr.Append(vbNewLine & " IF NOT EXISTS( SELECT 1 FROM  M_ASSYSNDINPUT_T where Ppid = '" & strScanBarcode & "' and STATIONID = '" & mStaionId & "' )" &
              " BEGIN INSERT M_ASSYSNDINPUT_T(PARTID,MOID,PPID,STATIONID,SITEM,LINEID,USERID,INTIME,ESTATEID)VALUES('" & LoadD.CurrAVCPartID & "','" & LoadD.CurrMoid &
       " ','" & strScanBarcode & "','" & mStaionId & "','1','" & LineId & "','" & SysMessageClass.UseId & "',getdate(),'Y') END")

            SqlStr.Append(vbNewLine & BarValueStr.ToString())

            If SqlStr.ToString <> "" Then
                DbOperateUtils.ExecSQL(SqlStr.ToString)
                If IsRework = False Then '重不打印PE袋条码
                    RepeatPEPocketPrint("", AxTempCode.ToString.Trim)
                End If
            Else
                Return False
            End If

            Return True
        Catch ex As Exception
            OutMsg = ex.Message
            SysMessageClass.WriteErrLog(ex, "FrmOnlinePrintBarcode", "MainMarkCCode", "sys")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 生成流水号
    ''' </summary>
    ''' <param name="TempSBCode"></param>
    ''' <param name="CurrCodePos"></param>
    ''' <param name="SBCodeLEN"></param>
    ''' <param name="SBCodeUnit"></param>
    ''' <param name="CurrCodeUnitTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function MarkSBCode(ByVal TempSBCode As StringBuilder, ByVal CurrCodePos As Int16, ByVal SBCodeLEN As Int16, ByVal SBCodeUnit(,) As String, ByVal CurrCodeUnitTable As DataTable) As StringBuilder
        Dim CurrCodeUnitView As New DataView
        Dim CurrRowView As DataRowView
        Dim CurrLow As String
        Dim CurrUnitPos As Int16

        CurrLow = TempSBCode.ToString.Substring(SBCodeLEN - CurrCodePos, 1)
        CurrCodeUnitView = New DataView(CurrCodeUnitTable)
        CurrCodeUnitView.RowFilter = "UnitID='" & SBCodeUnit(SBCodeLEN - CurrCodePos, 1) & "'"
        CurrCodeUnitView.Sort = "CodeSort asc"

        For Each CurrRowView In CurrCodeUnitView
            If CurrRowView.Item("CodeUnit").ToString = CurrLow Then
                CurrUnitPos = CInt(CurrRowView.Item("CodeSort").ToString.Trim)
                Exit For
            End If
        Next

        If CurrUnitPos < (CInt(SBCodeUnit(SBCodeLEN - CurrCodePos, 2)) - 1) Then
            CurrUnitPos = CurrUnitPos + 1
            For Each CurrRowView In CurrCodeUnitView
                If CurrUnitPos = CInt(CurrRowView.Item("CodeSort").ToString.Trim) Then
                    CurrLow = CurrRowView.Item("CodeUnit").ToString
                    Exit For
                End If
            Next
            TempSBCode.Remove(SBCodeLEN - CurrCodePos, 1)
            TempSBCode.Insert(SBCodeLEN - CurrCodePos, CurrLow, 1)
            Return TempSBCode

            Exit Function
        Else
            CurrUnitPos = 0
            For Each CurrRowView In CurrCodeUnitView
                If CurrUnitPos = CInt(CurrRowView.Item("CodeSort").ToString.Trim) Then
                    CurrLow = CurrRowView.Item("CodeUnit").ToString
                    Exit For
                End If
            Next
            TempSBCode.Remove(SBCodeLEN - CurrCodePos, 1)
            TempSBCode.Insert(SBCodeLEN - CurrCodePos, CurrLow, 1)

            If CurrCodePos = SBCodeLEN Then
                MsgBox("編碼原則允許的數量已達上限！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
                Return Nothing
            Else
                TempSBCode = MarkSBCode(TempSBCode, CurrCodePos + 1, SBCodeLEN, SBCodeUnit, CurrCodeUnitTable)
                Return TempSBCode
            End If
        End If
        CurrCodeUnitView.Dispose()
    End Function

    Private Sub CModlePrintGenRecord()
        Dim I As Int16
        Dim Areaid As String
        Dim Mreader As DataTable
        Dim Dtable As DataTable

        Dim FixStr As String = " IF NOT EXISTS(SELECT barcodeSNID  FROM m_BarRecordValue_t WHERE barcodeSNID='" & LoadD.StyleID & "' and PackId = '" & Packid & "' ) " & _
              " begin INSERT INTO m_BarRecordValue_t" &
                "([PackId],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                ",[label23],[label24]) " & _
                 "VALUES('" & Packid & "','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',getdate(),"
        Dim nPrintStr = New StringBuilder()
        Try
            Mreader = DbOperateUtils.GetDataTable("select  BarArea  from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule & "' order by F_orderid asc")
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString
                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"

                        For I = 0 To TempView.Count - 1

                            If I = 0 Then
                                If (I > 0) Then
                                    nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                Else
                                    nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                End If
                            Else
                                nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                            End If
                        Next
                        Continue For
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 7).ToLower = "barcode" Then

                        If Areaid.ToLower = "barcode1" Then
                            If PrintStr.ToString = "" Then
                                nPrintStr.Append(PrintPart(1, 1))
                            Else
                                nPrintStr.Append(vbNewLine & "~#" & PrintPart(1, 1))
                            End If
                            Continue For
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"

                        '序号替换

                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString)
                        Next
                        Continue For
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
                        If Areaid.ToLower = "barlabel1" Then
                            nPrintStr.Append(vbNewLine & PrintPart(2, 1))
                            Continue For
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                        Next
                        Continue For
                    End If
                End Using

            Next

            Dim sArray As String() = System.Text.RegularExpressions.Regex.Split(nPrintStr.ToString(), Microsoft.VisualBasic.Constants.vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim StrLen As Integer = sArray.Length
            BarValueStr.Append(FixStr)
            If BarFile.ToString() <> "" Then
                BarFile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            End If
            Dim Index As Integer = 0
            For Each ifalg As String In sArray

                If Index = 0 Then
                    BarFile.Append("""" & ifalg.ToString() & """")
                    BarValueStr.Append("'" & ifalg.ToString() & "'")
                Else
                    BarFile.Append(",""" & ifalg.ToString() & """")
                    BarValueStr.Append("," & "'" & ifalg.ToString() & "'")
                End If

                Index = Index + 1
            Next
            Dim SpaceStr As String = ","
            For j As Int16 = 1 To 16 - StrLen - 1
                SpaceStr = SpaceStr & "'',"
            Next
            SpaceStr = SpaceStr & "'') end"
            BarValueStr.Append(SpaceStr)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ModlePrintGenRecord(packId As String, ByVal UseY As String)
        Dim I As Int16
        Dim Areaid As String
        Dim Mreader As DataTable
        Dim Dtable As DataTable

        Dim FixStr As String = " IF NOT EXISTS(SELECT barcodeSNID  FROM m_BarRecordValue_t WHERE barcodeSNID='" & AxTempCode.ToString & "' and PackId = '" & packId & "' ) " & _
           " begin INSERT INTO m_BarRecordValue_t" &
             "([PackId],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
             ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
             ",[label23],[label24]) " & _
              "VALUES('" & packId & "','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',getdate(),"
        Dim nPrintStr = New StringBuilder()
        Try
            Mreader = DbOperateUtils.GetDataTable("select  BarArea  from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule & "' order by F_orderid asc")
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString
                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            If I = 0 Then
                                If (I > 0) Then
                                    nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                Else
                                    nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                End If
                            Else
                                nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                            End If
                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 7).ToLower = "barcode" Then
                        If Areaid.ToLower = "barcode1" Then
                            If PrintStr.ToString = "" Then
                                nPrintStr.Append(AxTempCode.ToString)
                            Else
                                nPrintStr.Append(vbNewLine & "~#" & AxTempCode.ToString)
                            End If
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        nPrintStr.Append(vbNewLine)
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString)
                        Next
                        Continue For
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
                        If Areaid.ToLower = "barlabel1" Then
                            If UseY = "N" Then
                                nPrintStr.Append(vbNewLine & "This is test")
                            Else
                                nPrintStr.Append(vbNewLine & LblTempCode.ToString)
                            End If
                            Continue For
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                        Next
                        Continue For
                    End If
                End Using
            Next

            ''''''''''''''''''组成标签元素值SQL语句及TXT数据源
            Dim sArray As String() = System.Text.RegularExpressions.Regex.Split(nPrintStr.ToString(), Microsoft.VisualBasic.Constants.vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim StrLen As Integer = sArray.Length
            BarValueStr.Append(FixStr)
            If BarFile.ToString() <> "" Then
                BarFile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            End If
            Dim Index As Integer = 0
            For Each ifalg As String In sArray

                If Index = 0 Then
                    BarFile.Append("""" & ifalg.ToString() & """")
                    BarValueStr.Append("'" & ifalg.ToString() & "'")
                Else
                    BarFile.Append(",""" & ifalg.ToString() & """")
                    BarValueStr.Append("," & "'" & ifalg.ToString() & "'")
                End If

                Index = Index + 1
            Next
            Dim SpaceStr As String = ","
            For j As Int16 = 1 To 16 - StrLen - 1
                SpaceStr = SpaceStr & "'',"
            Next
            SpaceStr = SpaceStr & "'') end"
            BarValueStr.Append(SpaceStr)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NBarCodePrint(packId As String, ByVal UseY As String)
        Dim I As Int16
        Dim Areaid As String
        Dim Mreader As DataTable
        Dim Dtable As DataTable
        Dim FixStr As String = ""

        FixStr = " IF NOT EXISTS(SELECT barcodeSNID  FROM m_BarRecordValue_t WHERE barcodeSNID='" & AxTempCode.ToString & "' and PackId = '" & packId & "' ) " & _
                 " begin INSERT INTO m_BarRecordValue_t" &
                   "([PackId],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                   ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                   ",[label23],[label24]) " & _
                    "VALUES('" & packId & "','" & My.Computer.Name & "','" & LoadD.CurrMoid & "','" & LoadD.CurrAVCPartID & "',getdate(),"

        Dim nPrintStr = New StringBuilder()
        Try
            Mreader = DbOperateUtils.GetDataTable("select  BarArea  from m_SnRuleD_t where CodeRuleID='" & LoadM.CodeRule & "' order by F_orderid asc")
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString
                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            If I = 0 Then
                                If (I > 0) Then
                                    nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                Else
                                    nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                                End If
                            Else
                                nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                            End If
                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 7).ToLower = "barcode" Then
                        If Areaid.ToLower = "barcode1" Then
                            If PrintStr.ToString = "" Then
                                nPrintStr.Append(AxTempCode.ToString)
                            Else
                                nPrintStr.Append(vbNewLine & "~#" & AxTempCode.ToString)
                            End If
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        nPrintStr.Append(vbNewLine)
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(TempView.Item(I).Item("ShortName").ToString)
                        Next
                        Continue For
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
                        If Areaid.ToLower = "barlabel1" Then
                            If UseY = "N" Then
                                nPrintStr.Append(vbNewLine & "This is test")
                            Else
                                nPrintStr.Append(vbNewLine & LblTempCode.ToString)
                            End If
                            Continue For
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                        Next
                        Continue For
                    End If
                End Using
            Next

            ''''''''''''''''''组成标签元素值SQL语句及TXT数据源
            Dim sArray As String() = System.Text.RegularExpressions.Regex.Split(nPrintStr.ToString(), Microsoft.VisualBasic.Constants.vbNewLine, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim StrLen As Integer = sArray.Length
            BarValueStr.Append(FixStr)
            If BarFile.ToString() <> "" Then
                BarFile.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            End If
            Dim Index As Integer = 0
            For Each ifalg As String In sArray

                If Index = 0 Then
                    BarFile.Append("""" & ifalg.ToString() & """")
                    BarValueStr.Append("'" & ifalg.ToString() & "'")
                Else
                    BarFile.Append(",""" & ifalg.ToString() & """")
                    BarValueStr.Append("," & "'" & ifalg.ToString() & "'")
                End If

                Index = Index + 1
            Next
            Dim SpaceStr As String = ","
            For j As Int16 = 1 To 16 - StrLen - 1
                SpaceStr = SpaceStr & "'',"
            Next
            SpaceStr = SpaceStr & "'') end"
            BarValueStr.Append(SpaceStr)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 条码打印
    ''' </summary>
    ''' <param name="pFilePath"></param>
    ''' <param name="printName"></param>
    ''' <remarks></remarks>
    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)
        btFormat = btApp.Formats.Open(VbCommClass.VbCommClass.PrintDataModle & pFilePath, False, String.Empty)
        btFormat.Printer = printName
        btFormat.Print("", False, -1, Nothing)
        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

    '取得编码原则中长度设置差异数
    Private Sub GetRuleCodeIdDiff(ByRef diff As Integer)
        'update by hgd 20171113 加入PARTSET.Usey='Y'排除作废了的
        Dim strSQL As String =
            "   SELECT DISTINCT PARTSET.F_codeID ,DValues,LEN(DValues),SR.F_codelen,SR.F_codestart,(SR.F_codelen - LEN(DValues))DIFF  from m_PartPack_t PP  " &
            "   inner join m_SnRuled_t SR " &
            "   on SR.CodeRuleID =PP.CodeRuleID " &
            "   INNER join m_SnPartSet_T PARTSET  " &
            "       ON PP.Partid = PARTSET.Partid AND SR.F_codeID = PARTSET.F_codeID AND pp.Packid = PARTSET.Packid " &
            "   where PP.PACKID ='S' AND  PP.Usey = 'Y' and  PP.Partid = '{0}'  " &
            "	    AND SR.BarArea = 'BarCode1' and		PARTSET.Usey='Y' " &
            "	    AND SR.F_codestart < ( SELECT TOP 1 F_codestart FROM m_SnRuleD_t SRD INNER JOIN m_PartPack_t PP ON SRD.CodeRuleID =PP.CodeRuleID" &
            "	                         WHERE    BarArea = 'BarCode1' AND F_codeID = 'S' AND  PP.PACKID ='S' AND PP.Partid = '{0}'  )"

        strSQL = String.Format(strSQL, LoadD.CurrAVCPartID)
        Dim dataTable As DataTable = DbOperateUtils.GetDataTable(strSQL)

        diff = 0
        For rowIndex As Integer = 0 To dataTable.Rows.Count - 1
            diff = diff + Convert.ToInt16(dataTable.Rows(rowIndex)("DIFF").ToString)
        Next
    End Sub

#End Region

    ''' <summary>
    ''' 自动生成箱号
    ''' </summary>
    ''' <param name="AxTempCode"></param>
    ''' <returns>string</returns>
    ''' <remarks></remarks>
    Private Function GenOuterCartonID(AxTempCode As String) As String
        Dim lsSQL As String = ""
        GenOuterCartonID = ""
        Try
            lsSQL = String.Format("declare @CurrentCartonID varchar(50) exec m_GetNCartonId_p '{0}',@CurrentCartonID output select @CurrentCartonID ", AxTempCode)
            Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
                If o_dt.Rows.Count > 0 Then
                    GenOuterCartonID = CStr(o_dt.Rows(0).Item(0))
                End If
            End Using
            Return GenOuterCartonID
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
