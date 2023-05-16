Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.IO

Public Class ScanOption
    Shared CheckString As Boolean ''扫描解锁状态
    Public Shared Property CheckStr() As Boolean
        Get
            Return CheckString
        End Get
        Set(ByVal Value As Boolean)
            CheckString = Value
        End Set
    End Property
    Shared _Partid As String ''扫描解锁状态
    Public Shared Property Partid() As String
        Get
            Return _Partid
        End Get
        Set(ByVal Value As String)
            _Partid = Value
        End Set
    End Property
    Shared _IsExitFlag As Boolean ''扫描设置是否OK
    Public Shared Property IsExitFlag() As Boolean
        Get
            Return _IsExitFlag
        End Get
        Set(ByVal Value As Boolean)
            _IsExitFlag = Value
        End Set
    End Property
    Shared _InputQty As Integer  ''生产数量
    Public Shared Property InputQty() As Integer
        Get
            Return _InputQty
        End Get
        Set(ByVal Value As Integer)
            _InputQty = Value
        End Set
    End Property
    Shared _SelMachineID As String  ''当前机台
    Public Shared Property SelMachineID() As String
        Get
            Return _SelMachineID
        End Get
        Set(ByVal Value As String)
            _SelMachineID = Value
        End Set
    End Property
    Shared _SelStationID As String  ''当前工站
    Public Shared Property SelStationID() As String
        Get
            Return _SelStationID
        End Get
        Set(ByVal Value As String)
            _SelStationID = Value
        End Set
    End Property
    Shared _SelMOID As String  ''当前工单
    Public Shared Property SelMOID() As String
        Get
            Return _SelMOID
        End Get
        Set(ByVal Value As String)
            _SelMOID = Value
        End Set
    End Property
    Shared _SelLineID As String  ''当前线别
    Public Shared Property SelLineID() As String
        Get
            Return _SelLineID
        End Get
        Set(ByVal Value As String)
            _SelLineID = Value
        End Set
    End Property
    Shared _WorkDt As DateTime   ''当前工作时间
    Public Shared Property WorkDt() As DateTime
        Get
            Return _WorkDt
        End Get
        Set(ByVal Value As DateTime)
            _WorkDt = Value
        End Set
    End Property
    Shared _IsScanCarton As Boolean ''是否扫描外箱
    Public Shared Property IsScanCarton() As Boolean
        Get
            Return _IsScanCarton
        End Get
        Set(ByVal Value As Boolean)
            _IsScanCarton = Value
        End Set
    End Property
    Shared _SelCartonStyle As String  ''外箱条码样式
    Public Shared Property SelCartonStyle() As String
        Get
            Return _SelCartonStyle
        End Get
        Set(ByVal Value As String)
            _SelCartonStyle = Value
        End Set
    End Property
    Shared _CartonQty As Integer  ''最外层外箱装箱数量
    Public Shared Property CartonQty() As Integer
        Get
            Return _CartonQty
        End Get
        Set(ByVal Value As Integer)
            _CartonQty = Value
        End Set
    End Property
    Shared _IsSameCartonStyle As String  '' 条码样式是否相同
    Public Shared Property IsSameCartonStyle() As String
        Get
            Return _IsSameCartonStyle
        End Get
        Set(ByVal Value As String)
            _IsSameCartonStyle = Value
        End Set
    End Property

    Shared _IsScanCartonQrCode As Boolean ''是否扫描外箱QRCode
    Public Shared Property IsScanCartonQrCode() As Boolean
        Get
            Return _IsScanCartonQrCode
        End Get
        Set(ByVal Value As Boolean)
            _IsScanCartonQrCode = Value
        End Set
    End Property
    Shared _SelQrCodeStyle As String  ''QRCode外箱条码样式
    Public Shared Property SelQrCodeStyle() As String
        Get
            Return _SelQrCodeStyle
        End Get
        Set(ByVal Value As String)
            _SelQrCodeStyle = Value
        End Set
    End Property
    Shared _IsScanSecondCode As Boolean ''是否扫描二层外箱PE袋
    Public Shared Property IsScanSecondCode() As Boolean
        Get
            Return _IsScanSecondCode
        End Get
        Set(ByVal Value As Boolean)
            _IsScanSecondCode = Value
        End Set
    End Property

    Shared _SelSecondStyle As String  ''二层外箱PE袋条码样式
    Public Shared Property SelSecondStyle() As String
        Get
            Return _SelSecondStyle
        End Get
        Set(ByVal Value As String)
            _SelSecondStyle = Value
        End Set
    End Property
    Shared _SelSecondQty As Integer  ''二层外箱装箱数量
    Public Shared Property SelSecondQty() As Integer
        Get
            Return _SelSecondQty
        End Get
        Set(ByVal Value As Integer)
            _SelSecondQty = Value
        End Set
    End Property
    Shared _IsSameSecondStyle As String  ''二层外箱装箱数量
    Public Shared Property IsSameSecondStyle() As String
        Get
            Return _IsSameSecondStyle
        End Get
        Set(ByVal Value As String)
            _IsSameSecondStyle = Value
        End Set
    End Property
    Shared _IsScanThirdCode As Boolean ''是否扫描三层外箱
    Public Shared Property IsScanThirdCode() As Boolean
        Get
            Return _IsScanThirdCode
        End Get
        Set(ByVal Value As Boolean)
            _IsScanThirdCode = Value
        End Set
    End Property
    Shared _SelThirdStyle As String  ''三层外箱条码样式
    Public Shared Property SelThirdStyle() As String
        Get
            Return _SelThirdStyle
        End Get
        Set(ByVal Value As String)
            _SelThirdStyle = Value
        End Set
    End Property
    Shared _SelThirdQty As Integer  ''三层外箱装箱数量
    Public Shared Property SelThirdQty() As Integer
        Get
            Return _SelThirdQty
        End Get
        Set(ByVal Value As Integer)
            _SelThirdQty = Value
        End Set
    End Property
    Shared _IsSameThirdStyle As String  ''三层外箱装箱数量
    Public Shared Property IsSameThirdStyle() As String
        Get
            Return _IsSameThirdStyle
        End Get
        Set(ByVal Value As String)
            _IsSameThirdStyle = Value
        End Set
    End Property
    Shared _SelPpidStyle As String  ''产品条码样式
    Public Shared Property SelPpidStyle() As String
        Get
            Return _SelPpidStyle
        End Get
        Set(ByVal Value As String)
            _SelPpidStyle = Value
        End Set
    End Property
    Shared _SelPpidQty As Integer  ''每扫描1次条码的产品数量-
    Public Shared Property SelPpidQty() As Integer
        Get
            Return _SelPpidQty
        End Get
        Set(ByVal Value As Integer)
            _SelPpidQty = Value
        End Set
    End Property
    Shared _vCurrentStandIndex As Integer = 0  ''扫描顺序
    Public Shared Property vCurrentStandIndex() As Integer
        Get
            Return _vCurrentStandIndex
        End Get
        Set(ByVal Value As Integer)
            _vCurrentStandIndex = Value
        End Set
    End Property
    Shared _layerType As Integer = 0  ''包装类别
    Public Shared Property LayerType() As Integer
        Get
            Return _layerType
        End Get
        Set(ByVal Value As Integer)
            _layerType = Value
        End Set
    End Property
    Shared _TotalLevel As Integer = 0  ''包装类别
    Public Shared Property TotalPackLevel As Integer
        Get
            Return _TotalLevel
        End Get
        Set(ByVal Value As Integer)
            _TotalLevel = Value
        End Set
    End Property
    '条码校验
    Shared _vRepeatStyle As String
    Public Shared Property vRepeatStyle As String
        Get
            Return _vRepeatStyle
        End Get
        Set(ByVal Value As String)
            _vRepeatStyle = Value
        End Set
    End Property
    Shared _vRepeatPara As String
    Public Shared Property vRepeatPara As String
        Get
            Return _vRepeatPara
        End Get
        Set(ByVal Value As String)
            _vRepeatPara = Value
        End Set
    End Property
    '箱条码校验
    Shared _vCartonRepeatPara As String
    Public Shared Property vCartonRepeatPara As String
        Get
            Return _vCartonRepeatPara
        End Get
        Set(ByVal Value As String)
            _vCartonRepeatPara = Value
        End Set
    End Property
    Shared _vCartonRepeatStyle As String
    Public Shared Property vCartonRepeatStyle As String
        Get
            Return _vCartonRepeatStyle
        End Get
        Set(ByVal Value As String)
            _vCartonRepeatStyle = Value
        End Set
    End Property
    Shared _virtualqty As Integer
    Public Shared Property VirtualTrayQty As Integer
        Get
            Return _virtualqty
        End Get
        Set(ByVal Value As Integer)
            _virtualqty = Value
        End Set
    End Property

    Shared _CustID As String = ""
    '/ <summary>
    '/ 客户代码
    '/ </summary>
    Public Shared Property CustID() As String
        Get
            Return _CustID
        End Get
        Set(ByVal Value As String)
            _CustID = Value
        End Set
    End Property
    Shared _ProCode As String = ""
    '/ <summary>
    '/ 简码
    '/ </summary>
    Public Shared Property ProCode() As String
        Get
            Return _ProCode
        End Get
        Set(ByVal Value As String)
            _ProCode = Value
        End Set
    End Property
    Shared _CartonQtyI As String = ""
    '/ <summary>
    '/ 整箱数量
    '/ </summary>
    Public Shared Property CartonQtyI() As String
        Get
            Return _CartonQtyI
        End Get
        Set(ByVal Value As String)
            _CartonQtyI = Value
        End Set
    End Property

    '是否跳过线别
    Shared _IsJumpLine As Boolean = False
    Public Shared Property IsJumpLine() As Boolean
        Get
            Return _IsJumpLine
        End Get
        Set(ByVal Value As Boolean)
            _IsJumpLine = Value
        End Set
    End Property
    Shared _IsOnlineGenCartonID As Boolean
    '/ <summary>
    '/ 整箱数量
    '/ </summary>
    Public Shared Property IsOnlineGenCartonID() As Boolean
        Get
            Return _IsOnlineGenCartonID
        End Get
        Set(ByVal Value As Boolean)
            _IsOnlineGenCartonID = Value
        End Set
    End Property

    Shared _Deptid As String = ""
    '/ <summary>
    '/ 整箱数量
    '/ </summary>
    Public Shared Property Deptid() As String
        Get
            Return _Deptid
        End Get
        Set(ByVal Value As String)
            _Deptid = Value
        End Set
    End Property
    Shared _CartonCodeRuleID As String = ""
    '/ <summary>
    '/ 整箱数量
    '/ </summary>
    Public Shared Property CartonCodeRuleID() As String
        Get
            Return _CartonCodeRuleID
        End Get
        Set(ByVal Value As String)
            _CartonCodeRuleID = Value
        End Set
    End Property
    Shared _IsOnelinePrintCarton As Boolean = False
    '/ <summary>
    '/ 整箱数量
    '/ </summary>
    Public Shared Property IsOnelinePrintCarton() As Boolean
        Get
            Return _IsOnelinePrintCarton
        End Get
        Set(ByVal Value As Boolean)
            _IsOnelinePrintCarton = Value
        End Set
    End Property
End Class


Public Class MultiPackOnlinePrint
    Dim PrintStr As New StringBuilder     '建立條碼打印字符串
    Dim PrintPart(,) As String
    Dim BarValueStr As New StringBuilder()
    Dim BarFile As New StringBuilder()
    Public Function PrintOnlineCarton(ByVal moid As String, ByVal partid As String, ByVal coderuleid As String, ByVal lineid As String, ByVal cartonid As String, ByVal userid As String, ByVal printname As String) As String

        Dim PrtArray As New MainFrame.SysCheckData.SysMessageClass.PrtStructure
        Dim pFilePath As String
        Dim Dtable As DataTable
        Dim Mreader As DataTable = New DataTable
        Dim BarCodePartTable As DataTable = New DataTable
        Try
            Dim str As String = "select a.Moid,a.Lineid,a.Cusid,c.CodeRuleID, c.Packid,A.PO, c.DistributionFlag,c.GroupPrintFlag from m_Mainmo_t as a  " _
                                            & "  join m_PartPack_t as c on a.PartID=c.Partid and c.Usey='Y' and c.coderuleid='" & coderuleid & "' and c.packinglevel<5 " _
                                            & " where a.moid='" & moid & "'"
            Dtable = DbOperateUtils.GetDataTable(str)

            If Dtable.Rows.Count = 0 Then
                Return False
            Else
                PrtArray.CusName = Dtable.Rows(0)("Cusid").ToString.ToUpper.Trim
                PrtArray.PO = Dtable.Rows(0)("PO").ToString
                PrtArray.BuildAttribute = Dtable.Rows(0)!DistributionFlag.ToString
            End If

            Dtable = DbOperateUtils.GetDataTable("select distinct a.TAvcPart,a.CustPart,c.CusName,b.Deptid,f.djc,b.Lineid,b.Moqty,b.Ppidprtqty,b.PkgPrtqty,d.Packid,j.TemplatePath,e.PFormatID,e.PaperSize,e.ColNum,e.RowNum,d.Packlink,d.Multiy,d.MultiQty,d.Qty,d.StartInt,d.StartSn,d.EndInt,d.EndSn,SpecFilterStr=isnull(k.SortName,'') " _
                            & "from m_PartContrast_t as a join m_Mainmo_t as b on a.TAvcPart=b.PartID and b.Moid='" & moid & "' and b.FinalY='N' " _
                            & "left join m_Dept_t as f on b.Deptid=f.Deptid left join m_Customer_t as c on a.CusID=c.CusID join m_PartPack_t as d on a.TAvcPart=d.Partid and d.CodeRuleID='" & coderuleid & "' and d.usey='Y'  and d.packinglevel<5 " _
                            & "left join m_Sortset_t as k on c.CusID=k.SortID and k.SortType='SpecCharCustID' and k.Usey='Y' " _
                            & "left join m_SnPFormat_t as e on d.PFormatID=e.PFormatID  left join m_SnMFormat_t as j on d.PFormatID=j.PFormatID")
            PrtArray.AvcPartid = Dtable.Rows(0)("TAvcPart").ToString.ToUpper.Trim
            PrtArray.CusName = Dtable.Rows(0)("CusName").ToString.Trim
            PrtArray.Deptid = Dtable.Rows(0)("Deptid").ToString.ToUpper.Trim
            PrtArray.Lineid = lineid
            PrtArray.Moid = moid
            PrtArray.Qty = IIf(Dtable.Rows(0)("Qty").ToString <> "", Dtable.Rows(0)("Qty").ToString, "1")     'IIf(Dtable("Qty").ToString <> "", Dtable("Qty").ToString, 0)
            PrtArray.DateCode = Date.Now.ToString("yyyyMMdd")
            PrtArray.WorkType = ""
            PrtArray.NowDate = Date.Now.ToString("yyyy-MM-dd")
            PrtArray.ContainerNo = "##/##"
            pFilePath = Dtable.Rows(0)("TemplatePath").ToString

            BarCodePartTable = MarkBarTable(moid, partid, coderuleid)
            If BarCodePartTable.Rows.Count = 0 Then
                Exit Function
            End If
            SetArrayLbl(PrtArray.ToArray, BarCodePartTable)

            '*****************************田玉琳 20170406 开始 *****************************
            Mreader = DbOperateUtils.GetDataTable("select  BarArea  from m_SnRuleD_t where CodeRuleID='" & coderuleid & "' order by F_orderid asc")
            CModlePrintGenRecord(Mreader, BarCodePartTable, moid, partid, cartonid)
            BarValueStr.Append(" insert into m_PrtRecord_t(Ptaskid,Moid,sbarcode, Lineid, Packid, Styleid, PackQty, PrtQty, SerierSection, Makedate, Userid, Intime) VALUES ")
            BarValueStr.Append(" ( '','" & moid & "','" & cartonid & "','" & lineid & "','C','" & coderuleid & "',1,1,'','','" & userid & "',getdate())")
            File.WriteAllText(Application.StartupPath & "\Bartender.txt", BarFile.ToString, Encoding.UTF8)
            DbOperateUtils.ExecSQL(BarValueStr.ToString)
            FileToBarCodePrint(pFilePath, printname)
            Return ""
        Catch ex As Exception

            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmMultiPackScan", "OnlinePrint", "sys")
            Return ex.Message
        Finally
            Dtable.Dispose()
            Mreader.Dispose()
            BarCodePartTable.Dispose()
        End Try
    End Function

    '建立條碼打印數組
    Private Function MarkBarTable(ByVal moid As String, ByVal partid As String, ByVal coderuleid As String) As DataTable
        Dim Sqlstr As String = ""
        Dim RecTable As New DataTable
        '建立條碼組成部分並分別賦初值
        Try
            Sqlstr = "SELECT DISTINCT a.F_codeID,isnull(cast(b.ShortName as Nvarchar(128))," _
   & " LEFT(IIF(a.f_codeid='PO',ISNULL(mo.PO,c.DValues),c.DValues),F_codelen)) as ShortName," _
   & " a.F_orderid, a.UnitID, a.BarArea, a.SplitChar,a.DResource, a.IsStyle,a.IsPrintStyle,a.F_codelen,a.IsBoxQty  " _
   & " from m_SnRuleD_t as a join m_SnRuleM_t as d on a.CodeRuleID=d.CodeRuleID left join (select b.F_codeid,c.ShortName from m_SnSet_t as b " _
   & " join m_SnSet_t as c on b.CodeRuleID=c.CodeRuleID and b.F_codeid=c.F_codeid where b.CodeRuleID='" & coderuleid & "' group by b.F_codeid,c.ShortName " _
   & " having count(b.f_codeid)=1) as b on a.F_codeid=b.F_codeid left join m_SnPartSet_t as c on a.F_codeid=c.F_codeid and d.LabelType=c.packid " _
   & " and c.partid='" & partid & "' and c.usey='Y' " _
   & " LEFT JOIN m_Mainmo_t mo on mo.partid = c.Partid  and mo.moid ='" & moid & "'" _
   & " where a.CodeRuleID='" & coderuleid & "'"
            RecTable = DbOperateUtils.GetDataTable(Trim(Sqlstr))
            Return RecTable
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmMultiPackScan", "MarkBarTable", "sys")
            Throw ex
        Finally
            RecTable.Dispose()
        End Try
    End Function
    '數組傳遞參數
    Private Sub SetArrayLbl(ByVal Array() As String, ByRef BarCodePartTable As DataTable)
        Dim LoadM As New BarCodePrint.SqlClassM
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
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmMultiPackScan", "SetArrayLbl", "sys")
            Throw ex
        End Try
    End Sub
    ''码元值生成至数据库，供exce调用
    Private Sub CModlePrintGenRecord(ByVal Mreader As DataTable, ByVal BarCodePartTable As DataTable, ByVal moid As String, ByVal partid As String, ByVal cartonid As String)
        Dim I As Int16
        Dim Areaid As String
        Dim Dtable As DataTable
        Dim btitle As StringBuilder = New StringBuilder
        ReDim PrintPart(2, 2)
        PrintPart(1, 1) = cartonid
        Dim FixStr As String = "IF NOT EXISTS(SELECT TOP 1 * FROM m_BarRecordValue_t WHERE barcodeSNID='" & cartonid & "') BEGIN INSERT INTO [m_BarRecordValue_t]" & _
                      "([PackId],[Printpc],[Moid],[Partid],[intime],[barcodeSNID],[label10],[label11],[label12],[label13],[label14]" & _
                     ",[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]" & _
                     ",[label23],[label24]) " & _
                      "VALUES('C','" & My.Computer.Name & "','" & moid & "','" & partid & "',getdate(),"
        Dim nPrintStr = New StringBuilder()
        Try
            Dim Dview As New DataView(Mreader)
            Dtable = Dview.ToTable(True, "BarArea")
            For Each dr As DataRow In Dtable.Rows
                Areaid = dr!BarArea.ToString
                Using TempView As DataView = New DataView(BarCodePartTable)
                    If Areaid.Length > 5 AndAlso Microsoft.VisualBasic.Left(Areaid, 5).ToLower = "label" Then
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        'PrintStr.Append(CommandStr)
                        For I = 0 To TempView.Count - 1
                            'nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)

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
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barcode1" Then
                            Dim strcode As String = PrintPart(1, 1)
                            If PrintStr.ToString = "" Then
                                nPrintStr.Append(strcode)
                            Else
                                nPrintStr.Append(vbNewLine & "~#" & strcode)
                            End If
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If
                    If Areaid.Length > 7 AndAlso Microsoft.VisualBasic.Left(Areaid, 8).ToLower = "barlabel" Then
                        'PrintStr.Append(CommandStr)
                        If Areaid.ToLower = "barlabel1" Then
                            Dim strcode As String = PrintPart(2, 1)
                            nPrintStr.Append(vbNewLine & strcode)
                            Continue For
                            'Exit Try
                        End If
                        TempView.RowFilter = "BarArea='" & Areaid & "'"
                        TempView.Sort = "F_orderid asc"
                        For I = 0 To TempView.Count - 1
                            nPrintStr.Append(vbNewLine & TempView.Item(I).Item("ShortName").ToString & TempView.Item(I).Item("SplitChar").ToString)
                        Next
                        Continue For
                        'Exit Try
                    End If
                End Using

            Next
            btitle.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""")
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
            Index = 0
            Dim ilabel = 15 - sArray.Length
            For m As Integer = 0 To ilabel
                BarFile.Append(",""""")
                BarValueStr.Append(",''")
            Next
            Dim arr As ArrayList = GetCartonSN(cartonid)
            For j As Integer = 0 To arr.ToArray.Length - 1
                btitle.Append(",""CartonSN" & j.ToString() & """")
                BarFile.Append(",""" & arr.Item(j).ToString & """")
            Next
            btitle.Append(Microsoft.VisualBasic.Constants.vbNewLine)
            BarFile.Insert(0, btitle)
            'Dim SpaceStr As String = ","
            'For j As Int16 = 1 To 16 - StrLen - 1
            '    SpaceStr = SpaceStr & "'',"
            'Next
            'SpaceStr = SpaceStr & "'')"
            BarValueStr.Append(") END ")
            Dtable = Nothing
        Catch ex As Exception
            Dtable = Nothing
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmMultiPackScan", "CModlePrintGenRecord", "sys")
            Throw ex
        End Try

    End Sub

    Private Function GetCartonSN(ByVal cartonid As String) As ArrayList
        Dim Sqlstr As String = ""
        Dim RecTable As New DataTable
        Dim array As ArrayList = New ArrayList
        Try
            Sqlstr = "select ppid from m_cartonsn_t (nolock) where cartonid ='" & cartonid & "'"
            RecTable = DbOperateUtils.GetDataTable(Trim(Sqlstr))
            For Each dr As DataRow In RecTable.Rows
                array.Add(dr("ppid").ToString())
            Next
            Return array
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmMultiPackScan", "MarkBarTable", "sys")
            Throw ex
        Finally
            RecTable.Dispose()
        End Try
    End Function
    Private Sub FileToBarCodePrint(ByVal pFilePath As String, ByVal printName As String)
        Dim btFormat As New BarTender.Format
        Dim btApp As BarTender.Application = New BarTender.Application
        Try
            'btFormat.PrintOut(False, False)
            btFormat = btApp.Formats.Open(VbCommClass.VbCommClass.PrintDataModle & pFilePath, False, String.Empty)
            btFormat.Printer = printName
            btFormat.Print("", False, -1, Nothing)
            btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)

        Catch ex As Exception
            Throw ex
        Finally
            btFormat.Close()
            btApp.Quit()
        End Try
     
    End Sub
End Class