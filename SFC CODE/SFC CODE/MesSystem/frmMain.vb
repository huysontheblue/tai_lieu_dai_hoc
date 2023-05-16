Imports System.Collections
Imports System.ComponentModel
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Rendering
Imports System.Data.SqlClient
Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.IO
Imports RouteManagement
Imports System.Runtime.InteropServices
Imports DevComponents.Editors
Imports System.Xml

Public Class frmMain
    Inherits DevComponents.DotNetBar.Office2007RibbonForm
    Private mdiClient1 As MdiClient
    Private tabStrip1 As DevComponents.DotNetBar.TabStrip
    Private components As System.ComponentModel.IContainer
    'Private m_Search As BalloonSearch=Nothing

    Private bar1 As DevComponents.DotNetBar.Bar
    Private labelStatus As DevComponents.DotNetBar.LabelItem
    Private WithEvents labelPosition As DevComponents.DotNetBar.LabelItem
    Private WithEvents ribbonControl1 As DevComponents.DotNetBar.RibbonControl
    Private comboItem1 As DevComponents.Editors.ComboItem
    Private comboItem2 As DevComponents.Editors.ComboItem
    Private comboItem3 As DevComponents.Editors.ComboItem
    Private comboItem4 As DevComponents.Editors.ComboItem
    Private comboItem5 As DevComponents.Editors.ComboItem
    Private comboItem6 As DevComponents.Editors.ComboItem
    Private comboItem7 As DevComponents.Editors.ComboItem
    Private comboItem8 As DevComponents.Editors.ComboItem
    Private comboItem9 As DevComponents.Editors.ComboItem
    Private ribbonTabItemGroup1 As DevComponents.DotNetBar.RibbonTabItemGroup
    Private itemContainer13 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents RibbonPanel2 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonTabItem1 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents RibbonBar1 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButExit As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButTxt As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButCla As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ComboItem10 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem11 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem12 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem13 As DevComponents.Editors.ComboItem
    Private WithEvents ButPassword As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButShow As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButTitle As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LblUser As System.Windows.Forms.Label
    Private WithEvents RibbonPanel3 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonTabItem2 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents RibbonBar2 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ComboItem14 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem15 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem16 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem17 As DevComponents.Editors.ComboItem
    Private WithEvents ButtonItem13 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem15 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonPanel1 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonTabItem3 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents RibbonPanel4 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonBar4 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButtonItem26 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem29 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonBar3 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem8 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem19 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem20 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonTabItem4 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents ButtonItem23 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem24 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonPanel5 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonBar5 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents RibbonTabItem5 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents ButtonItem35 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem36 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem37 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem40 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem42 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LblSname As System.Windows.Forms.Label
    Private WithEvents ButtonItem12 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem46 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem50 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonPanel8 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonBar8 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents RibbonTabItem8 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents ButtonItem25 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem58 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem59 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem61 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem70 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem72 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonTabItem9 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents ButtonItem77 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonTabItem10 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents ButtonItem79 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem80 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonPanel9 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonBar9 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButtonItem73 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem75 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonPanel11 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonBar11 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButtonItem81 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem82 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem83 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem84 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonPanel10 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonBar10 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents RibbonTabItem11 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents ButtonItem85 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem86 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem87 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonPanel12 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonBar12 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents RibbonTabItem12 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents ButtonItem120 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonPanel13 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonTabItem13 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents RibbonBar13 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButtonItem131 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem133 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem134 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem135 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem136 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem139 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem142 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemNgRepair As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemNgSeries As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonPanelEqp As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonBarEqp As DevComponents.DotNetBar.RibbonBar
    Private WithEvents RibbonTabItemEqp As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents RibbonPanel14 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonBar14 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents RibbonTabItem14 As DevComponents.DotNetBar.RibbonTabItem
    'FrmSetScan

    '设备管理


    Private WithEvents ButtonItem143 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem141 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem17 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem123 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem125 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem121 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem124 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem144 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem9 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem137 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemEqp02 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem146 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem147 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemEqp03 As DevComponents.DotNetBar.ButtonItem

    Private WithEvents ButtonItem149 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem151 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem156 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem154 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem164 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ComboItem18 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem19 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem20 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem21 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem22 As DevComponents.Editors.ComboItem
    Private WithEvents ButtonItemPickingManagement As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnItemWarehouseManagment As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem170 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem171 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonPanel15 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents rtabItemDataHistory As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents RibbonBarDataHistoryList As DevComponents.DotNetBar.RibbonBar
    Private WithEvents btnItemLinkServerManagement As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnDataHistoryManagement As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonPanel16 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonBarKB As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents RibbonBar6 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButtonItem47 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonTabItem15 As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents ButtonItem48 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem49 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem71 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem172 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnItemConnectDatabase As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnItemReleasedVersion As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnItemClientManagement As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem92 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem96 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem100 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem110 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem112 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem102 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem94 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem98 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem99 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem140 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem152 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemProductionPlan As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnItemProductionPlanQuery As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem91 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem93 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem14 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem18 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem22 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem30 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem31 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem32 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem33 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem34 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem38 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem122 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem41 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem43 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem45 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem52 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem55 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem53 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem54 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem56 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btFrmComplementApplication As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem63 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem64 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnPackingCheckQuery As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnHWITScan As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemPackingCheckA As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnPrintQCCheck As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnFrmPackingCheckMaster As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonPanel6 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibbonBarS As DevComponents.DotNetBar.RibbonBar
    Private WithEvents RibbonTabItemS As DevComponents.DotNetBar.RibbonTabItem
    ' Friend WithEvents RibbonBar6 As DevComponents.DotNetBar.RibbonBar
    Private WithEvents ButtonItem68 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem69 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem88 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem89 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem90 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem95 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem97 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnBarCodeReceivedRecord As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnOnlineNotice As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem44 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem65 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnFrmEmployeeScan As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnCustomerOrderQuery As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem51 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnFrmSeriesMaster As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem67 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnFrmPlanReport As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem78 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnHWPOImport As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnPartRet As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem21 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem101 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem103 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem66 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnHWASNPack As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnMOPlan As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem104 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem16 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem105 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem106 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem10 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem11 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem27 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemOBA As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemPartOBA As DevComponents.DotNetBar.ButtonItem

    Private WithEvents ButtonItemOQA As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem28 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem39 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem57 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem60 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemOBACheck As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents PanPic As System.Windows.Forms.Panel
    Friend WithEvents PicLoginMain As System.Windows.Forms.PictureBox
    Private WithEvents ButtonItem62 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnFrmListOthePrint As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemMerryShip As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem107 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem108 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem109 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem111 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem113 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem114 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem115 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Private WithEvents ButtonItemBZ As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem116 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem117 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents HelpSOP As System.Windows.Forms.Button
    Private WithEvents ButtonItem118 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem119 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem126 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem127 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem129 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents RibbonPanel7 As DevComponents.DotNetBar.RibbonPanel
    Private WithEvents RibTabItMouldManagement As DevComponents.DotNetBar.RibbonTabItem
    Private WithEvents RibBarMouldManagement As DevComponents.DotNetBar.RibbonBar
    Private WithEvents BtnItemMouldBasicData As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private WithEvents ButtonItem128 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem153 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem150 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem145 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem138 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem132 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem130 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem155 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents BtnItemHighSpeedLine As DevComponents.DotNetBar.ButtonItem
    Private WithEvents btnBOFToolList As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem168 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem163 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem165 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem166 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem167 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem157 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem158 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem159 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem160 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem161 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem162 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemBarcodePrinterManagement As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemMaterialManagement As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemFinishedProductStorage As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemFinishedProduct As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemRework As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem76 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem74 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem169 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItem173 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents labTitle As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Private WithEvents ButtonItem174 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ComboBoxItem1 As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Private WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Private WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents MetroTileItem1 As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem2 As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem3 As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem4 As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem5 As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents MetroTileItem6 As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
    Private WithEvents MetroLink1 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents picSPC As System.Windows.Forms.PictureBox
    Private WithEvents MetroTileItem7 As DevComponents.DotNetBar.Metro.MetroTileItem
    Private WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents ButtonItem148 As DevComponents.DotNetBar.ButtonItem
    Private WithEvents ButtonItemEqp04 As DevComponents.DotNetBar.ButtonItem
    ' Private WithEvents ButtonItem43 As DevComponents.DotNetBar.ButtonItem

    Public Sub New()
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        AddHandler mdiClient1.ControlAdded, AddressOf MdiClientControlAddRemove
        AddHandler mdiClient1.ControlRemoved, AddressOf MdiClientControlAddRemove
    End Sub

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"
    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.tabStrip1 = New DevComponents.DotNetBar.TabStrip()
        Me.bar1 = New DevComponents.DotNetBar.Bar()
        Me.LblUser = New System.Windows.Forms.Label()
        Me.LblSname = New System.Windows.Forms.Label()
        Me.labelStatus = New DevComponents.DotNetBar.LabelItem()
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.itemContainer13 = New DevComponents.DotNetBar.ItemContainer()
        Me.labelPosition = New DevComponents.DotNetBar.LabelItem()
        Me.ComboBoxItem1 = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ribbonControl1 = New DevComponents.DotNetBar.RibbonControl()
        Me.RibbonPanel5 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar5 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem122 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnItemProductionPlanQuery = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem120 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem154 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem59 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem148 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem36 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem58 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem37 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem42 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem86 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem46 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem77 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem35 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem65 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem87 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem142 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem56 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemNgSeries = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemNgRepair = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel2 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar1 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButShow = New DevComponents.DotNetBar.ButtonItem()
        Me.ButTxt = New DevComponents.DotNetBar.ButtonItem()
        Me.ButCla = New DevComponents.DotNetBar.ButtonItem()
        Me.ButPassword = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem13 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem174 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem15 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem156 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem61 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem118 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem117 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem119 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButExit = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel16 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBarKB = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem48 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem55 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem49 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem71 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem47 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem91 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem93 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem30 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem32 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem34 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem44 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel4 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar4 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem26 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem72 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem29 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem12 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem80 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem172 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem22 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem31 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem54 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnHWITScan = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemPackingCheckA = New DevComponents.DotNetBar.ButtonItem()
        Me.btnHWASNPack = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem39 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem62 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem128 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemMerryShip = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel8 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar8 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem25 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem79 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem85 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem141 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem151 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem38 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPackingCheckQuery = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrintQCCheck = New DevComponents.DotNetBar.ButtonItem()
        Me.btnFrmPackingCheckMaster = New DevComponents.DotNetBar.ButtonItem()
        Me.btnFrmEmployeeScan = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem57 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem115 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem60 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem111 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemOBACheck = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel3 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar2 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem40 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem50 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem70 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem18 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBarCodeReceivedRecord = New DevComponents.DotNetBar.ButtonItem()
        Me.btFrmComplementApplication = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem107 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem105 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem28 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem52 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnFrmListOthePrint = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem155 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel11 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar11 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem81 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem82 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem83 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem84 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem169 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem173 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanelEqp = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBarEqp = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem124 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem144 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemEqp02 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemEqp03 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemEqp04 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel12 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar12 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem92 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem96 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem100 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem110 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem112 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem102 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem94 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem98 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem99 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem140 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem152 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem63 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem64 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem67 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem116 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel9 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar9 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem73 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem75 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem157 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem158 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem159 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem160 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem161 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem162 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemBarcodePrinterManagement = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemMaterialManagement = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemPickingManagement = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemFinishedProductStorage = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemFinishedProduct = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemRework = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem76 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem74 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem168 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem163 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem165 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem166 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem167 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCustomerOrderQuery = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem51 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnHWPOImport = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPartRet = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem114 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel13 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar13 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem131 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem133 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem134 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem135 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem136 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem139 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem43 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem45 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem90 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem97 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem103 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem11 = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnItemHighSpeedLine = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBOFToolList = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel1 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar3 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem33 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem170 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem7 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem8 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem14 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem19 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem20 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem53 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem23 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem24 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem121 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnOnlineNotice = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemProductionPlan = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem27 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem113 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem129 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemOBA = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemPartOBA = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemOQA = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel14 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar14 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem149 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem41 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem146 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem147 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem125 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem137 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem143 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem17 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem123 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnFrmSeriesMaster = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem9 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem164 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem171 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnItemWarehouseManagment = New DevComponents.DotNetBar.ButtonItem()
        Me.btnItemConnectDatabase = New DevComponents.DotNetBar.ButtonItem()
        Me.btnItemReleasedVersion = New DevComponents.DotNetBar.ButtonItem()
        Me.btnItemClientManagement = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel10 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar10 = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem16 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem104 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem78 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem101 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem66 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnMOPlan = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem21 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnFrmPlanReport = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem106 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem10 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem108 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem109 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemBZ = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem126 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem127 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel6 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBarS = New DevComponents.DotNetBar.RibbonBar()
        Me.ButtonItem68 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem69 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem88 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem89 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem95 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel15 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBarDataHistoryList = New DevComponents.DotNetBar.RibbonBar()
        Me.btnItemLinkServerManagement = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDataHistoryManagement = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonPanel7 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibBarMouldManagement = New DevComponents.DotNetBar.RibbonBar()
        Me.BtnItemMouldBasicData = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem153 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem150 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem145 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem138 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem132 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem130 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonTabItem1 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem14 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem3 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem4 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem2 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem8 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem9 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem12 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem5 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem10 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem13 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem11 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibTabItMouldManagement = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItemEqp = New DevComponents.DotNetBar.RibbonTabItem()
        Me.rtabItemDataHistory = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItem15 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.RibbonTabItemS = New DevComponents.DotNetBar.RibbonTabItem()
        Me.ButTitle = New DevComponents.DotNetBar.ButtonItem()
        Me.ribbonTabItemGroup1 = New DevComponents.DotNetBar.RibbonTabItemGroup()
        Me.ComboItem10 = New DevComponents.Editors.ComboItem()
        Me.ComboItem11 = New DevComponents.Editors.ComboItem()
        Me.ComboItem12 = New DevComponents.Editors.ComboItem()
        Me.ComboItem13 = New DevComponents.Editors.ComboItem()
        Me.ComboItem18 = New DevComponents.Editors.ComboItem()
        Me.ComboItem19 = New DevComponents.Editors.ComboItem()
        Me.ComboItem20 = New DevComponents.Editors.ComboItem()
        Me.ComboItem21 = New DevComponents.Editors.ComboItem()
        Me.ComboItem22 = New DevComponents.Editors.ComboItem()
        Me.comboItem1 = New DevComponents.Editors.ComboItem()
        Me.comboItem2 = New DevComponents.Editors.ComboItem()
        Me.comboItem3 = New DevComponents.Editors.ComboItem()
        Me.comboItem4 = New DevComponents.Editors.ComboItem()
        Me.comboItem5 = New DevComponents.Editors.ComboItem()
        Me.comboItem6 = New DevComponents.Editors.ComboItem()
        Me.comboItem7 = New DevComponents.Editors.ComboItem()
        Me.comboItem8 = New DevComponents.Editors.ComboItem()
        Me.comboItem9 = New DevComponents.Editors.ComboItem()
        Me.ComboItem14 = New DevComponents.Editors.ComboItem()
        Me.ComboItem15 = New DevComponents.Editors.ComboItem()
        Me.ComboItem16 = New DevComponents.Editors.ComboItem()
        Me.ComboItem17 = New DevComponents.Editors.ComboItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanPic = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.labTitle = New System.Windows.Forms.Label()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.MetroTileItem1 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem2 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem3 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem4 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem5 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem6 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.ItemContainer2 = New DevComponents.DotNetBar.ItemContainer()
        Me.MetroLink1 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem7 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.PicLoginMain = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.HelpSOP = New System.Windows.Forms.Button()
        Me.mdiClient1 = New System.Windows.Forms.MdiClient()
        Me.picSPC = New System.Windows.Forms.PictureBox()
        CType(Me.bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bar1.SuspendLayout()
        Me.ribbonControl1.SuspendLayout()
        Me.RibbonPanel5.SuspendLayout()
        Me.RibbonPanel2.SuspendLayout()
        Me.RibbonPanel16.SuspendLayout()
        Me.RibbonPanel4.SuspendLayout()
        Me.RibbonPanel8.SuspendLayout()
        Me.RibbonPanel3.SuspendLayout()
        Me.RibbonPanel11.SuspendLayout()
        Me.RibbonPanelEqp.SuspendLayout()
        Me.RibbonPanel12.SuspendLayout()
        Me.RibbonPanel9.SuspendLayout()
        Me.RibbonPanel13.SuspendLayout()
        Me.RibbonPanel1.SuspendLayout()
        Me.RibbonPanel14.SuspendLayout()
        Me.RibbonPanel10.SuspendLayout()
        Me.RibbonPanel6.SuspendLayout()
        Me.RibbonPanel15.SuspendLayout()
        Me.RibbonPanel7.SuspendLayout()
        Me.PanPic.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.PicLoginMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSPC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerColorTint = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(26, Byte), Integer)))
        '
        'tabStrip1
        '
        Me.tabStrip1.AutoSelectAttachedControl = True
        Me.tabStrip1.CanReorderTabs = True
        Me.tabStrip1.CloseButtonVisible = True
        Me.tabStrip1.ColorScheme.TabBackground = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tabStrip1.ColorScheme.TabBackground2 = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tabStrip1.ColorScheme.TabItemBackground = System.Drawing.Color.Transparent
        Me.tabStrip1.ColorScheme.TabItemBackground2 = System.Drawing.Color.Transparent
        Me.tabStrip1.ColorScheme.TabItemBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer)), 0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer)), 1.0!)})
        Me.tabStrip1.ColorScheme.TabItemHotBackground = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.tabStrip1.ColorScheme.TabItemHotBackground2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.tabStrip1.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer)), 0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.White, 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.White, 1.0!)})
        Me.tabStrip1.ColorScheme.TabItemHotText = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tabStrip1.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(New DevComponents.DotNetBar.BackgroundColorBlend() {New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(243, Byte), Integer)), 0!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(168, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(136, Byte), Integer)), 0.45!), New DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), 1.0!)})
        Me.tabStrip1.ColorScheme.TabItemSelectedBorderLight = System.Drawing.Color.White
        Me.tabStrip1.ColorScheme.TabItemSelectedText = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tabStrip1.ColorScheme.TabItemText = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tabStrip1.ColorScheme.TabPanelBackground2 = System.Drawing.Color.White
        Me.tabStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabStrip1.ForeColor = System.Drawing.Color.White
        Me.tabStrip1.Location = New System.Drawing.Point(5, 155)
        Me.tabStrip1.MdiForm = Me
        Me.tabStrip1.MdiTabbedDocuments = True
        Me.tabStrip1.Name = "tabStrip1"
        Me.tabStrip1.SelectedTab = Nothing
        Me.tabStrip1.SelectedTabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tabStrip1.ShowMdiChildIcon = False
        Me.tabStrip1.Size = New System.Drawing.Size(1360, 26)
        Me.tabStrip1.Style = DevComponents.DotNetBar.eTabStripStyle.OneNote
        Me.tabStrip1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top
        Me.tabStrip1.TabIndex = 6
        Me.tabStrip1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.tabStrip1.Text = "tabStrip1"
        '
        'bar1
        '
        Me.bar1.AccessibleDescription = "DotNetBar Bar (bar1)"
        Me.bar1.AccessibleName = "DotNetBar Bar"
        Me.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar
        Me.bar1.AntiAlias = True
        Me.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.bar1.Controls.Add(Me.LblUser)
        Me.bar1.Controls.Add(Me.LblSname)
        Me.bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bar1.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle
        Me.bar1.IsMaximized = False
        Me.bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.labelStatus, Me.ControlContainerItem1, Me.itemContainer13, Me.ComboBoxItem1})
        Me.bar1.ItemSpacing = 2
        Me.bar1.Location = New System.Drawing.Point(5, 623)
        Me.bar1.Name = "bar1"
        Me.bar1.Size = New System.Drawing.Size(1360, 28)
        Me.bar1.Stretch = True
        Me.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.bar1.TabIndex = 7
        Me.bar1.TabStop = False
        Me.bar1.Text = "barStatus"
        '
        'LblUser
        '
        Me.LblUser.AutoSize = True
        Me.LblUser.BackColor = System.Drawing.Color.Transparent
        Me.LblUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblUser.Location = New System.Drawing.Point(12, 6)
        Me.LblUser.Name = "LblUser"
        Me.LblUser.Size = New System.Drawing.Size(68, 17)
        Me.LblUser.TabIndex = 9
        Me.LblUser.Text = "用户帐号："
        '
        'LblSname
        '
        Me.LblSname.AutoSize = True
        Me.LblSname.BackColor = System.Drawing.Color.Transparent
        Me.LblSname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblSname.Location = New System.Drawing.Point(1020, 5)
        Me.LblSname.Name = "LblSname"
        Me.LblSname.Size = New System.Drawing.Size(56, 17)
        Me.LblSname.TabIndex = 9
        Me.LblSname.Text = "服务器："
        '
        'labelStatus
        '
        Me.labelStatus.Name = "labelStatus"
        Me.labelStatus.PaddingLeft = 2
        Me.labelStatus.PaddingRight = 2
        Me.labelStatus.SingleLineColor = System.Drawing.Color.White
        Me.labelStatus.Stretch = True
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.Control = Me.LblSname
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'itemContainer13
        '
        '
        '
        '
        Me.itemContainer13.BackgroundStyle.Class = "Office2007StatusBarBackground2"
        Me.itemContainer13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.itemContainer13.Name = "itemContainer13"
        Me.itemContainer13.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.labelPosition})
        '
        '
        '
        Me.itemContainer13.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'labelPosition
        '
        Me.labelPosition.Name = "labelPosition"
        Me.labelPosition.PaddingLeft = 2
        Me.labelPosition.PaddingRight = 2
        Me.labelPosition.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.labelPosition.Width = 100
        '
        'ComboBoxItem1
        '
        Me.ComboBoxItem1.ComboWidth = 150
        Me.ComboBoxItem1.DropDownHeight = 106
        Me.ComboBoxItem1.ItemHeight = 18
        Me.ComboBoxItem1.Name = "ComboBoxItem1"
        '
        'ribbonControl1
        '
        Me.ribbonControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ribbonControl1.CanCustomize = False
        Me.ribbonControl1.CaptionFont = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ribbonControl1.CaptionVisible = True
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel5)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel2)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel16)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel4)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel8)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel3)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel11)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanelEqp)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel12)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel9)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel13)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel1)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel14)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel10)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel6)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel15)
        Me.ribbonControl1.Controls.Add(Me.RibbonPanel7)
        Me.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ribbonControl1.FadeEffect = False
        Me.ribbonControl1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ribbonControl1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ribbonControl1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.RibbonTabItem1, Me.RibbonTabItem14, Me.RibbonTabItem3, Me.RibbonTabItem4, Me.RibbonTabItem2, Me.RibbonTabItem8, Me.RibbonTabItem9, Me.RibbonTabItem12, Me.RibbonTabItem5, Me.RibbonTabItem10, Me.RibbonTabItem13, Me.RibbonTabItem11, Me.RibTabItMouldManagement, Me.RibbonTabItemEqp, Me.rtabItemDataHistory, Me.RibbonTabItem15, Me.RibbonTabItemS})
        Me.ribbonControl1.KeyTipsFont = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ribbonControl1.Location = New System.Drawing.Point(5, 1)
        Me.ribbonControl1.MdiSystemItemVisible = False
        Me.ribbonControl1.Name = "ribbonControl1"
        Me.ribbonControl1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.ribbonControl1.QuickToolbarItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButTitle})
        Me.ribbonControl1.Size = New System.Drawing.Size(1360, 154)
        Me.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
        Me.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
        Me.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
        Me.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
        Me.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
        Me.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>"
        Me.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel"
        Me.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
        Me.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
        Me.ribbonControl1.SystemText.QatDialogOkButton = "OK"
        Me.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
        Me.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove"
        Me.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
        Me.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
        Me.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
        Me.ribbonControl1.TabGroupHeight = 14
        Me.ribbonControl1.TabGroups.AddRange(New DevComponents.DotNetBar.RibbonTabItemGroup() {Me.ribbonTabItemGroup1})
        Me.ribbonControl1.TabIndex = 8
        Me.ribbonControl1.UseCustomizeDialog = False
        '
        'RibbonPanel5
        '
        Me.RibbonPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel5.Controls.Add(Me.RibbonBar5)
        Me.RibbonPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel5.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel5.Name = "RibbonPanel5"
        Me.RibbonPanel5.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel5.Size = New System.Drawing.Size(1360, 98)
        '
        '
        '
        Me.RibbonPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel5.TabIndex = 9
        Me.RibbonPanel5.Visible = True
        '
        'RibbonBar5
        '
        Me.RibbonBar5.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar5.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar5.ContainerControlProcessDialogKey = True
        Me.RibbonBar5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonBar5.DragDropSupport = True
        Me.RibbonBar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem122, Me.btnItemProductionPlanQuery, Me.ButtonItem120, Me.ButtonItem154, Me.ButtonItem59, Me.ButtonItem148, Me.ButtonItem36, Me.ButtonItem58, Me.ButtonItem37, Me.ButtonItem42, Me.ButtonItem86, Me.ButtonItem46, Me.ButtonItem77, Me.ButtonItem35, Me.ButtonItem65, Me.ButtonItem87, Me.ButtonItem142, Me.ButtonItem56, Me.ButtonItemNgSeries, Me.ButtonItemNgRepair})
        Me.RibbonBar5.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar5.Name = "RibbonBar5"
        Me.RibbonBar5.Size = New System.Drawing.Size(1354, 95)
        Me.RibbonBar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar5.TabIndex = 0
        '
        '
        '
        Me.RibbonBar5.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar5.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar5.TitleVisible = False
        Me.RibbonBar5.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem122
        '
        Me.ButtonItem122.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem122.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem122.Image = Global.MesSystem.My.Resources.Resources._41
        Me.ButtonItem122.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem122.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem122.KeyTips = "M011F_"
        Me.ButtonItem122.Name = "ButtonItem122"
        Me.ButtonItem122.Tag = "BasicFindReport.FrmReportMain"
        Me.ButtonItem122.Text = "通用报表"
        '
        'btnItemProductionPlanQuery
        '
        Me.btnItemProductionPlanQuery.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnItemProductionPlanQuery.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnItemProductionPlanQuery.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_39
        Me.btnItemProductionPlanQuery.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnItemProductionPlanQuery.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnItemProductionPlanQuery.KeyTips = "M20002_"
        Me.btnItemProductionPlanQuery.Name = "btnItemProductionPlanQuery"
        Me.btnItemProductionPlanQuery.Tag = "ProductionPlan.FrmProductionPlanQuery"
        Me.btnItemProductionPlanQuery.Text = "排产计划"
        '
        'ButtonItem120
        '
        Me.ButtonItem120.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem120.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem120.Image = Global.MesSystem.My.Resources.Resources.g21
        Me.ButtonItem120.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem120.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem120.KeyTips = "M0970_"
        Me.ButtonItem120.Name = "ButtonItem120"
        Me.ButtonItem120.Tag = "BasicFindReport.FrmQueryProductionInfo"
        Me.ButtonItem120.Text = "生产记录查询"
        '
        'ButtonItem154
        '
        Me.ButtonItem154.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem154.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem154.Image = Global.MesSystem.My.Resources.Resources._15128
        Me.ButtonItem154.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem154.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem154.KeyTips = "M9101"
        Me.ButtonItem154.Name = "ButtonItem154"
        Me.ButtonItem154.Tag = "BasicFindReport.FrmAmazonQuery"
        Me.ButtonItem154.Text = "Amazon出货报表"
        '
        'ButtonItem59
        '
        Me.ButtonItem59.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem59.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem59.Image = Global.MesSystem.My.Resources.Resources._151212
        Me.ButtonItem59.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem59.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem59.KeyTips = "M09Z0_"
        Me.ButtonItem59.Name = "ButtonItem59"
        Me.ButtonItem59.Tag = "BasicFindReport.FrmSnQuery"
        Me.ButtonItem59.Text = "产品追踪查询"
        '
        'ButtonItem148
        '
        Me.ButtonItem148.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem148.Image = CType(resources.GetObject("ButtonItem148.Image"), System.Drawing.Image)
        Me.ButtonItem148.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem148.Name = "ButtonItem148"
        Me.ButtonItem148.SubItemsExpandWidth = 14
        Me.ButtonItem148.Tag = "BasicFindReport.FrmBarcodeBack"
        Me.ButtonItem148.Text = "条码追溯"
        '
        'ButtonItem36
        '
        Me.ButtonItem36.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem36.Image = Global.MesSystem.My.Resources.Resources.g21
        Me.ButtonItem36.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem36.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem36.KeyTips = "M0940_"
        Me.ButtonItem36.Name = "ButtonItem36"
        Me.ButtonItem36.Tag = "BasicFindReport.FrmScanQuery"
        Me.ButtonItem36.Text = "成品扫描记录"
        '
        'ButtonItem58
        '
        Me.ButtonItem58.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem58.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem58.Image = Global.MesSystem.My.Resources.Resources._151212
        Me.ButtonItem58.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem58.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem58.KeyTips = "M0710U_"
        Me.ButtonItem58.Name = "ButtonItem58"
        Me.ButtonItem58.Tag = "BasicFindReport.FrmWhOutQuery"
        Me.ButtonItem58.Text = "成品出货"
        '
        'ButtonItem37
        '
        Me.ButtonItem37.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem37.Image = Global.MesSystem.My.Resources.Resources._15122
        Me.ButtonItem37.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem37.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem37.KeyTips = "M0950_"
        Me.ButtonItem37.Name = "ButtonItem37"
        Me.ButtonItem37.Tag = "BasicFindReport.FrmPrintQuery"
        Me.ButtonItem37.Text = "条码打印记录"
        '
        'ButtonItem42
        '
        Me.ButtonItem42.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem42.Image = Global.MesSystem.My.Resources.Resources._15123
        Me.ButtonItem42.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem42.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem42.KeyTips = "M0960_"
        Me.ButtonItem42.Name = "ButtonItem42"
        Me.ButtonItem42.Tag = "BasicFindReport.FrmPackQuery"
        Me.ButtonItem42.Text = "包装记录查询"
        '
        'ButtonItem86
        '
        Me.ButtonItem86.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem86.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem86.Image = Global.MesSystem.My.Resources.Resources._151212
        Me.ButtonItem86.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem86.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem86.KeyTips = "M09Y0_"
        Me.ButtonItem86.Name = "ButtonItem86"
        Me.ButtonItem86.Tag = "BasicFindReport.FrmQueryLotInfo"
        Me.ButtonItem86.Text = "产品批次查询"
        '
        'ButtonItem46
        '
        Me.ButtonItem46.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem46.Image = Global.MesSystem.My.Resources.Resources._15125
        Me.ButtonItem46.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem46.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem46.KeyTips = "M09Q0_"
        Me.ButtonItem46.Name = "ButtonItem46"
        Me.ButtonItem46.Tag = "BasicFindReport.FrmTestRecordQuery"
        Me.ButtonItem46.Text = "机台测试数据"
        '
        'ButtonItem77
        '
        Me.ButtonItem77.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem77.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem77.Image = Global.MesSystem.My.Resources.Resources._15127
        Me.ButtonItem77.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem77.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem77.KeyTips = "M09X0_"
        Me.ButtonItem77.Name = "ButtonItem77"
        Me.ButtonItem77.Tag = "BarCodePrint.FrmReprintQuery"
        Me.ButtonItem77.Text = "不良条码记录"
        '
        'ButtonItem35
        '
        Me.ButtonItem35.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem35.Image = Global.MesSystem.My.Resources.Resources._15127
        Me.ButtonItem35.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem35.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem35.KeyTips = "M09H0_"
        Me.ButtonItem35.Name = "ButtonItem35"
        Me.ButtonItem35.Tag = "BasicFindReport.FrmNGSearch"
        Me.ButtonItem35.Text = "不良明细查询"
        '
        'ButtonItem65
        '
        Me.ButtonItem65.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem65.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem65.Image = Global.MesSystem.My.Resources.Resources._15127
        Me.ButtonItem65.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem65.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem65.KeyTips = "M9105"
        Me.ButtonItem65.Name = "ButtonItem65"
        Me.ButtonItem65.Tag = "KanBan.FrmParetoReport"
        Me.ButtonItem65.Text = "柏拉图数据查询"
        '
        'ButtonItem87
        '
        Me.ButtonItem87.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem87.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem87.Image = Global.MesSystem.My.Resources.Resources._151212
        Me.ButtonItem87.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem87.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem87.KeyTips = "M09AB17_"
        Me.ButtonItem87.Name = "ButtonItem87"
        Me.ButtonItem87.Tag = "BasicFindReport.FrmQueryPpidLinkData"
        Me.ButtonItem87.Text = "成品Link查询"
        '
        'ButtonItem142
        '
        Me.ButtonItem142.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem142.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem142.Image = Global.MesSystem.My.Resources.Resources._151213
        Me.ButtonItem142.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem142.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem142.Name = "ButtonItem142"
        Me.ButtonItem142.Tag = "BasicFindReport.FrmRugenProductTrace"
        Me.ButtonItem142.Text = "Rugen产品追溯"
        '
        'ButtonItem56
        '
        Me.ButtonItem56.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem56.Image = Global.MesSystem.My.Resources.Resources.search
        Me.ButtonItem56.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem56.Name = "ButtonItem56"
        Me.ButtonItem56.SubItemsExpandWidth = 14
        Me.ButtonItem56.Tag = "BasicFindReport.FrmScanUnlockQuery"
        Me.ButtonItem56.Text = "扫描解锁查询"
        '
        'ButtonItemNgSeries
        '
        Me.ButtonItemNgSeries.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemNgSeries.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemNgSeries.Image = Global.MesSystem.My.Resources.Resources._151213
        Me.ButtonItemNgSeries.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemNgSeries.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemNgSeries.KeyTips = "M9100"
        Me.ButtonItemNgSeries.Name = "ButtonItemNgSeries"
        Me.ButtonItemNgSeries.Tag = "BasicFindReport.FrmSeriesNGQuery"
        Me.ButtonItemNgSeries.Text = "系列不良报表"
        '
        'ButtonItemNgRepair
        '
        Me.ButtonItemNgRepair.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemNgRepair.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemNgRepair.Image = Global.MesSystem.My.Resources.Resources._151213
        Me.ButtonItemNgRepair.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemNgRepair.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemNgRepair.Name = "ButtonItemNgRepair"
        Me.ButtonItemNgRepair.Tag = "BasicFindReport.FrmNGRepairQuery"
        Me.ButtonItemNgRepair.Text = "不良维修报表"
        '
        'RibbonPanel2
        '
        Me.RibbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel2.Controls.Add(Me.RibbonBar1)
        Me.RibbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel2.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel2.Name = "RibbonPanel2"
        Me.RibbonPanel2.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel2.Size = New System.Drawing.Size(1360, 98)
        '
        '
        '
        Me.RibbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel2.TabIndex = 5
        Me.RibbonPanel2.Visible = False
        '
        'RibbonBar1
        '
        Me.RibbonBar1.AutoOverflowEnabled = True
        Me.RibbonBar1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RibbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar1.ContainerControlProcessDialogKey = True
        Me.RibbonBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonBar1.DragDropSupport = True
        Me.RibbonBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButShow, Me.ButTxt, Me.ButCla, Me.ButPassword, Me.ButtonItem13, Me.ButtonItem174, Me.ButtonItem15, Me.ButtonItem156, Me.ButtonItem61, Me.ButtonItem118, Me.ButtonItem117, Me.ButtonItem119, Me.ButExit})
        Me.RibbonBar1.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar1.Name = "RibbonBar1"
        Me.RibbonBar1.Size = New System.Drawing.Size(1354, 95)
        Me.RibbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar1.TabIndex = 0
        '
        '
        '
        Me.RibbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar1.TitleVisible = False
        Me.RibbonBar1.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButShow
        '
        Me.ButShow.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButShow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButShow.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_10
        Me.ButShow.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButShow.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButShow.Name = "ButShow"
        Me.ButShow.Text = "显示功能区"
        '
        'ButTxt
        '
        Me.ButTxt.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButTxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButTxt.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy
        Me.ButTxt.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButTxt.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButTxt.Name = "ButTxt"
        Me.ButTxt.Text = "文本文档"
        '
        'ButCla
        '
        Me.ButCla.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButCla.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButCla.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_2
        Me.ButCla.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButCla.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButCla.Name = "ButCla"
        Me.ButCla.Text = "计算器"
        '
        'ButPassword
        '
        Me.ButPassword.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButPassword.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_3
        Me.ButPassword.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButPassword.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButPassword.KeyTips = "M0111_"
        Me.ButPassword.Name = "ButPassword"
        Me.ButPassword.Tag = "MESUserManage.FrmPasswordch"
        Me.ButPassword.Text = "修改密码"
        '
        'ButtonItem13
        '
        Me.ButtonItem13.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem13.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_5
        Me.ButtonItem13.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem13.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem13.KeyTips = "M0110_"
        Me.ButtonItem13.Name = "ButtonItem13"
        Me.ButtonItem13.Tag = "MESUserManage.FrmUserManage"
        Me.ButtonItem13.Text = "用户权限管理"
        '
        'ButtonItem174
        '
        Me.ButtonItem174.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_86
        Me.ButtonItem174.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem174.Name = "ButtonItem174"
        Me.ButtonItem174.SubItemsExpandWidth = 14
        Me.ButtonItem174.Tag = "MESUserManage.FrmRoleManage"
        Me.ButtonItem174.Text = "角色管理"
        '
        'ButtonItem15
        '
        Me.ButtonItem15.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem15.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_6
        Me.ButtonItem15.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem15.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem15.KeyTips = "M0112_"
        Me.ButtonItem15.Name = "ButtonItem15"
        Me.ButtonItem15.Tag = "MESUserManage.FrmSystemFileManage"
        Me.ButtonItem15.Text = "系统更新文件维护"
        '
        'ButtonItem156
        '
        Me.ButtonItem156.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem156.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem156.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_7
        Me.ButtonItem156.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem156.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem156.KeyTips = "M011D_"
        Me.ButtonItem156.Name = "ButtonItem156"
        Me.ButtonItem156.Tag = "MESUserManage.FrmMsgEdit"
        Me.ButtonItem156.Text = "信息公告"
        '
        'ButtonItem61
        '
        Me.ButtonItem61.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem61.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_8
        Me.ButtonItem61.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem61.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem61.KeyTips = "M011H_"
        Me.ButtonItem61.Name = "ButtonItem61"
        Me.ButtonItem61.Tag = "BasicManagement.FrmContact"
        Me.ButtonItem61.Text = "联系我们"
        '
        'ButtonItem118
        '
        Me.ButtonItem118.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_16
        Me.ButtonItem118.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem118.KeyTips = "M011HS_"
        Me.ButtonItem118.Name = "ButtonItem118"
        Me.ButtonItem118.SubItemsExpandWidth = 14
        Me.ButtonItem118.Tag = "BasicManagement.FrmMaintainSop"
        Me.ButtonItem118.Text = "SOP上传"
        '
        'ButtonItem117
        '
        Me.ButtonItem117.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem117.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_59
        Me.ButtonItem117.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem117.KeyTips = "M011I_"
        Me.ButtonItem117.Name = "ButtonItem117"
        Me.ButtonItem117.SubItemsExpandWidth = 14
        Me.ButtonItem117.Tag = "RouteManagement.FrmDbDictionary"
        Me.ButtonItem117.Text = "数据库字典"
        '
        'ButtonItem119
        '
        Me.ButtonItem119.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem119.Image = Global.MesSystem.My.Resources.Resources.Sets
        Me.ButtonItem119.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem119.KeyTips = "M01_13"
        Me.ButtonItem119.Name = "ButtonItem119"
        Me.ButtonItem119.SubItemsExpandWidth = 14
        Me.ButtonItem119.Tag = "MESUserManage.FrmSysMenu"
        Me.ButtonItem119.Text = "系统菜单管理"
        '
        'ButExit
        '
        Me.ButExit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButExit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButExit.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_9
        Me.ButExit.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButExit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButExit.Name = "ButExit"
        Me.ButExit.Text = "退出系统"
        '
        'RibbonPanel16
        '
        Me.RibbonPanel16.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel16.Controls.Add(Me.RibbonBarKB)
        Me.RibbonPanel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel16.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel16.Name = "RibbonPanel16"
        Me.RibbonPanel16.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel16.Size = New System.Drawing.Size(1360, 98)
        '
        '
        '
        Me.RibbonPanel16.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel16.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel16.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel16.TabIndex = 20
        Me.RibbonPanel16.Visible = False
        '
        'RibbonBarKB
        '
        Me.RibbonBarKB.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBarKB.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarKB.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarKB.ContainerControlProcessDialogKey = True
        Me.RibbonBarKB.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBarKB.DragDropSupport = True
        Me.RibbonBarKB.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem48, Me.ButtonItem55, Me.ButtonItem49, Me.ButtonItem71, Me.ButtonItem47, Me.ButtonItem91, Me.ButtonItem93, Me.ButtonItem30, Me.ButtonItem32, Me.ButtonItem34, Me.ButtonItem44})
        Me.RibbonBarKB.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBarKB.Name = "RibbonBarKB"
        Me.RibbonBarKB.Size = New System.Drawing.Size(1284, 95)
        Me.RibbonBarKB.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarKB.TabIndex = 0
        '
        '
        '
        Me.RibbonBarKB.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarKB.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarKB.TitleVisible = False
        Me.RibbonBarKB.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem48
        '
        Me.ButtonItem48.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem48.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem48.Image = CType(resources.GetObject("ButtonItem48.Image"), System.Drawing.Image)
        Me.ButtonItem48.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem48.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem48.KeyTips = "M1901"
        Me.ButtonItem48.Name = "ButtonItem48"
        Me.ButtonItem48.Tag = "KanBan.FrmSetMO"
        Me.ButtonItem48.Text = "生产工时维护"
        '
        'ButtonItem55
        '
        Me.ButtonItem55.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem55.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem55.Image = Global.MesSystem.My.Resources.Resources.produce_plan
        Me.ButtonItem55.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem55.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem55.KeyTips = "9110"
        Me.ButtonItem55.Name = "ButtonItem55"
        Me.ButtonItem55.Tag = "BasicFindReport.FrmProductPlanQuery"
        Me.ButtonItem55.Text = "生产计划报表"
        '
        'ButtonItem49
        '
        Me.ButtonItem49.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem49.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem49.Image = Global.MesSystem.My.Resources.Resources.productstaus
        Me.ButtonItem49.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem49.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem49.KeyTips = "M1906"
        Me.ButtonItem49.Name = "ButtonItem49"
        Me.ButtonItem49.Tag = "BasicFindReport.FrmProductInfoQuery"
        Me.ButtonItem49.Text = "生产状况报表"
        '
        'ButtonItem71
        '
        Me.ButtonItem71.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem71.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem71.Image = CType(resources.GetObject("ButtonItem71.Image"), System.Drawing.Image)
        Me.ButtonItem71.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem71.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem71.KeyTips = "M1907"
        Me.ButtonItem71.Name = "ButtonItem71"
        Me.ButtonItem71.Tag = "BasicFindReport.FrmProductNGQuery"
        Me.ButtonItem71.Text = "生产不良明细报表"
        '
        'ButtonItem47
        '
        Me.ButtonItem47.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem47.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem47.Image = Global.MesSystem.My.Resources.Resources.dayreport
        Me.ButtonItem47.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem47.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem47.KeyTips = "M1903"
        Me.ButtonItem47.Name = "ButtonItem47"
        Me.ButtonItem47.Tag = "BasicFindReport.FrmProductNGDayQuery"
        Me.ButtonItem47.Text = "生产综合报表"
        '
        'ButtonItem91
        '
        Me.ButtonItem91.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem91.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem91.Image = Global.MesSystem.My.Resources.Resources.moidproduct
        Me.ButtonItem91.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem91.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem91.KeyTips = "M1908"
        Me.ButtonItem91.Name = "ButtonItem91"
        Me.ButtonItem91.Tag = "KanBan.FrmMOSchQuery"
        Me.ButtonItem91.Text = "工单生产进度查询"
        '
        'ButtonItem93
        '
        Me.ButtonItem93.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem93.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem93.Image = Global.MesSystem.My.Resources.Resources.Order
        Me.ButtonItem93.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem93.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem93.KeyTips = "M1909"
        Me.ButtonItem93.Name = "ButtonItem93"
        Me.ButtonItem93.Tag = "KanBan.FrmOrderSchQuery"
        Me.ButtonItem93.Text = "订单生产进度查询"
        '
        'ButtonItem30
        '
        Me.ButtonItem30.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem30.Image = CType(resources.GetObject("ButtonItem30.Image"), System.Drawing.Image)
        Me.ButtonItem30.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem30.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem30.KeyTips = "M1910"
        Me.ButtonItem30.Name = "ButtonItem30"
        Me.ButtonItem30.Tag = "BasicManagement.FrmBomQuery"
        Me.ButtonItem30.Text = " 图纸查询"
        '
        'ButtonItem32
        '
        Me.ButtonItem32.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem32.Image = CType(resources.GetObject("ButtonItem32.Image"), System.Drawing.Image)
        Me.ButtonItem32.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem32.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem32.KeyTips = "M1911"
        Me.ButtonItem32.Name = "ButtonItem32"
        Me.ButtonItem32.Tag = "KanBan.FrmKBHelp"
        Me.ButtonItem32.Text = "看板帮助"
        '
        'ButtonItem34
        '
        Me.ButtonItem34.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem34.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_105
        Me.ButtonItem34.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem34.KeyTips = "M1912"
        Me.ButtonItem34.Name = "ButtonItem34"
        Me.ButtonItem34.Tag = "KanBan.FrmParetoShow"
        Me.ButtonItem34.Text = "柏拉图"
        '
        'ButtonItem44
        '
        Me.ButtonItem44.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem44.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_104
        Me.ButtonItem44.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem44.KeyTips = "M1913"
        Me.ButtonItem44.Name = "ButtonItem44"
        Me.ButtonItem44.Tag = "KanBan.FrmParetoMoidShow"
        Me.ButtonItem44.Text = "柏拉图"
        '
        'RibbonPanel4
        '
        Me.RibbonPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel4.Controls.Add(Me.RibbonBar4)
        Me.RibbonPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel4.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel4.Name = "RibbonPanel4"
        Me.RibbonPanel4.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel4.Size = New System.Drawing.Size(1360, 98)
        '
        '
        '
        Me.RibbonPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel4.TabIndex = 8
        Me.RibbonPanel4.Visible = False
        '
        'RibbonBar4
        '
        Me.RibbonBar4.AutoOverflowEnabled = True
        Me.RibbonBar4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RibbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar4.ContainerControlProcessDialogKey = True
        Me.RibbonBar4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonBar4.DragDropSupport = True
        Me.RibbonBar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem26, Me.ButtonItem72, Me.ButtonItem29, Me.ButtonItem12, Me.ButtonItem80, Me.ButtonItem172, Me.ButtonItem22, Me.ButtonItem31, Me.ButtonItem54, Me.btnHWITScan, Me.ButtonItemPackingCheckA, Me.btnHWASNPack, Me.ButtonItem39, Me.ButtonItem62, Me.ButtonItem128, Me.ButtonItemMerryShip})
        Me.RibbonBar4.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar4.Name = "RibbonBar4"
        Me.RibbonBar4.Size = New System.Drawing.Size(1354, 95)
        Me.RibbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar4.TabIndex = 2
        '
        '
        '
        Me.RibbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar4.TitleVisible = False
        Me.RibbonBar4.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem26
        '
        Me.ButtonItem26.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem26.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_26
        Me.ButtonItem26.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem26.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem26.KeyTips = "M0598_"
        Me.ButtonItem26.Name = "ButtonItem26"
        Me.ButtonItem26.Tag = "BarCodeScan.FrmWorkStantScan"
        Me.ButtonItem26.Text = "工站制程扫描"
        '
        'ButtonItem72
        '
        Me.ButtonItem72.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem72.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem72.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_30
        Me.ButtonItem72.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem72.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem72.KeyTips = "M059F_"
        Me.ButtonItem72.Name = "ButtonItem72"
        Me.ButtonItem72.Tag = "BarCodeScan.FrmProductCheck"
        Me.ButtonItem72.Text = "产品核对扫描作业"
        '
        'ButtonItem29
        '
        Me.ButtonItem29.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem29.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_31
        Me.ButtonItem29.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem29.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem29.KeyTips = "M0113_"
        Me.ButtonItem29.Name = "ButtonItem29"
        Me.ButtonItem29.Tag = "MESUserManage.FrmScanAberrantHandle"
        Me.ButtonItem29.Text = "采集异常处理作业"
        '
        'ButtonItem12
        '
        Me.ButtonItem12.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem12.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_32
        Me.ButtonItem12.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem12.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem12.KeyTips = "M0114_"
        Me.ButtonItem12.Name = "ButtonItem12"
        Me.ButtonItem12.Tag = "MESUserManage.FrmRepeatCheck"
        Me.ButtonItem12.Text = "条码扫描检测作业"
        '
        'ButtonItem80
        '
        Me.ButtonItem80.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem80.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem80.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_33
        Me.ButtonItem80.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem80.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem80.KeyTips = "M059G_"
        Me.ButtonItem80.Name = "ButtonItem80"
        Me.ButtonItem80.Tag = "BarCodeScan.FrmNewStantPackScan"
        Me.ButtonItem80.Text = "包装扫描"
        '
        'ButtonItem172
        '
        Me.ButtonItem172.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem172.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem172.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_34
        Me.ButtonItem172.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem172.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem172.KeyTips = "M05_01"
        Me.ButtonItem172.Name = "ButtonItem172"
        Me.ButtonItem172.Tag = "BarCodeScan.FrmNoBarCodePack"
        Me.ButtonItem172.Text = "无条码产品包装"
        '
        'ButtonItem22
        '
        Me.ButtonItem22.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem22.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_35
        Me.ButtonItem22.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem22.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem22.KeyTips = "M059I_"
        Me.ButtonItem22.Name = "ButtonItem22"
        Me.ButtonItem22.Tag = "BarCodeScan.FrmStantLotScan"
        Me.ButtonItem22.Text = "批次"
        '
        'ButtonItem31
        '
        Me.ButtonItem31.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem31.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_36
        Me.ButtonItem31.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem31.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem31.KeyTips = "M059H_"
        Me.ButtonItem31.Name = "ButtonItem31"
        Me.ButtonItem31.Tag = "BarCodeScan.FrmOnlinePrintBarcode"
        Me.ButtonItem31.Text = "在线条码打印作业"
        '
        'ButtonItem54
        '
        Me.ButtonItem54.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem54.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem54.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_37
        Me.ButtonItem54.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem54.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem54.KeyTips = "M059J_"
        Me.ButtonItem54.Name = "ButtonItem54"
        Me.ButtonItem54.Tag = "BarCodeScan.FrmAutoScanSendData"
        Me.ButtonItem54.Text = "自动扫描"
        '
        'btnHWITScan
        '
        Me.btnHWITScan.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnHWITScan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnHWITScan.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_33
        Me.btnHWITScan.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnHWITScan.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnHWITScan.KeyTips = "M059L_"
        Me.btnHWITScan.Name = "btnHWITScan"
        Me.btnHWITScan.Tag = "BarCodeScan.FrmHWITScan"
        Me.btnHWITScan.Text = "海翼包装扫描"
        '
        'ButtonItemPackingCheckA
        '
        Me.ButtonItemPackingCheckA.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemPackingCheckA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemPackingCheckA.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_32
        Me.ButtonItemPackingCheckA.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemPackingCheckA.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemPackingCheckA.KeyTips = "M059K_"
        Me.ButtonItemPackingCheckA.Name = "ButtonItemPackingCheckA"
        Me.ButtonItemPackingCheckA.Tag = "BarCodeScan.FrmPackingCheckA"
        Me.ButtonItemPackingCheckA.Text = "包装附属检测"
        '
        'btnHWASNPack
        '
        Me.btnHWASNPack.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnHWASNPack.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnHWASNPack.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_40
        Me.btnHWASNPack.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnHWASNPack.KeyTips = "M059O_"
        Me.btnHWASNPack.Name = "btnHWASNPack"
        Me.btnHWASNPack.SubItemsExpandWidth = 14
        Me.btnHWASNPack.Tag = "BarCodeScan.FrmHWPackScan"
        Me.btnHWASNPack.Text = "华为包装扫描"
        '
        'ButtonItem39
        '
        Me.ButtonItem39.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem39.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_38
        Me.ButtonItem39.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem39.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem39.KeyTips = "M0511_"
        Me.ButtonItem39.Name = "ButtonItem39"
        Me.ButtonItem39.Tag = "BarCodeScan.FrmSNCheck"
        Me.ButtonItem39.Text = "条码重码检查"
        '
        'ButtonItem62
        '
        Me.ButtonItem62.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem62.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem62.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_26
        Me.ButtonItem62.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem62.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem62.KeyTips = "M0512_"
        Me.ButtonItem62.Name = "ButtonItem62"
        Me.ButtonItem62.SubItemsExpandWidth = 14
        Me.ButtonItem62.Tag = "BarCodeScan.FrmStandardRework"
        Me.ButtonItem62.Text = "标准重工作业"
        '
        'ButtonItem128
        '
        Me.ButtonItem128.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem128.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_30
        Me.ButtonItem128.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem128.Name = "ButtonItem128"
        Me.ButtonItem128.SubItemsExpandWidth = 14
        Me.ButtonItem128.Tag = "BarCodeScan.FrmInspection"
        Me.ButtonItem128.Text = "送检"
        '
        'ButtonItemMerryShip
        '
        Me.ButtonItemMerryShip.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemMerryShip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemMerryShip.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_32
        Me.ButtonItemMerryShip.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemMerryShip.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemMerryShip.KeyTips = "M059H_"
        Me.ButtonItemMerryShip.Name = "ButtonItemMerryShip"
        Me.ButtonItemMerryShip.SubItemsExpandWidth = 14
        Me.ButtonItemMerryShip.Tag = "BarCodeScan.FrmMerryShipScan"
        Me.ButtonItemMerryShip.Text = "美律出货扫描"
        '
        'RibbonPanel8
        '
        Me.RibbonPanel8.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel8.Controls.Add(Me.RibbonBar8)
        Me.RibbonPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel8.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel8.Name = "RibbonPanel8"
        Me.RibbonPanel8.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel8.Size = New System.Drawing.Size(1360, 98)
        '
        '
        '
        Me.RibbonPanel8.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel8.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel8.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel8.TabIndex = 12
        Me.RibbonPanel8.Visible = False
        '
        'RibbonBar8
        '
        Me.RibbonBar8.AutoOverflowEnabled = True
        Me.RibbonBar8.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RibbonBar8.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar8.ContainerControlProcessDialogKey = True
        Me.RibbonBar8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonBar8.DragDropSupport = True
        Me.RibbonBar8.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem25, Me.ButtonItem79, Me.ButtonItem85, Me.ButtonItem141, Me.ButtonItem151, Me.ButtonItem38, Me.btnPackingCheckQuery, Me.btnPrintQCCheck, Me.btnFrmPackingCheckMaster, Me.btnFrmEmployeeScan, Me.ButtonItem6, Me.ButtonItem57, Me.ButtonItem115, Me.ButtonItem60, Me.ButtonItem111, Me.ButtonItemOBACheck})
        Me.RibbonBar8.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar8.Name = "RibbonBar8"
        Me.RibbonBar8.Size = New System.Drawing.Size(1354, 95)
        Me.RibbonBar8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar8.TabIndex = 0
        Me.RibbonBar8.Text = "RibbonBar8"
        '
        '
        '
        Me.RibbonBar8.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar8.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar8.TitleVisible = False
        Me.RibbonBar8.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem25
        '
        Me.ButtonItem25.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem25.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_48
        Me.ButtonItem25.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem25.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem25.KeyTips = "M031C_"
        Me.ButtonItem25.Name = "ButtonItem25"
        Me.ButtonItem25.Tag = "MainTainModule.FrmMainTainHandleDG"
        Me.ButtonItem25.Text = "不良品维修作业"
        '
        'ButtonItem79
        '
        Me.ButtonItem79.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem79.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem79.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_53
        Me.ButtonItem79.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem79.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem79.KeyTips = "M031G_"
        Me.ButtonItem79.Name = "ButtonItem79"
        Me.ButtonItem79.Tag = "BarCodeScan.FrmPackingExceptionHandle"
        Me.ButtonItem79.Text = "包装异常作业"
        '
        'ButtonItem85
        '
        Me.ButtonItem85.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem85.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem85.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_54
        Me.ButtonItem85.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem85.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem85.KeyTips = "M031H_"
        Me.ButtonItem85.Name = "ButtonItem85"
        Me.ButtonItem85.Tag = "BarCodeScan.FrmScanExceptionHandle"
        Me.ButtonItem85.Text = "成品扫描异常作业"
        '
        'ButtonItem141
        '
        Me.ButtonItem141.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem141.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem141.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_55
        Me.ButtonItem141.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem141.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem141.KeyTips = "M14001"
        Me.ButtonItem141.Name = "ButtonItem141"
        Me.ButtonItem141.Tag = "WmsManagement.FrmShippingQCCheck"
        Me.ButtonItem141.Text = "出货品质确认"
        '
        'ButtonItem151
        '
        Me.ButtonItem151.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem151.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem151.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_56
        Me.ButtonItem151.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem151.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem151.KeyTips = "M14002"
        Me.ButtonItem151.Name = "ButtonItem151"
        Me.ButtonItem151.Tag = "WmsManagement.FrmShippingExport"
        Me.ButtonItem151.Text = "出货导出报表"
        '
        'ButtonItem38
        '
        Me.ButtonItem38.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem38.Image = Global.MesSystem.My.Resources.Resources.search
        Me.ButtonItem38.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem38.KeyTips = "M0911_"
        Me.ButtonItem38.Name = "ButtonItem38"
        Me.ButtonItem38.PopupSide = DevComponents.DotNetBar.ePopupSide.Top
        Me.ButtonItem38.SubItemsExpandWidth = 14
        Me.ButtonItem38.Tag = "BasicFindReport.FrmQueryMaterialInOut"
        Me.ButtonItem38.Text = "原材料入库出库查询"
        '
        'btnPackingCheckQuery
        '
        Me.btnPackingCheckQuery.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPackingCheckQuery.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnPackingCheckQuery.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_58
        Me.btnPackingCheckQuery.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnPackingCheckQuery.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnPackingCheckQuery.KeyTips = "M9104"
        Me.btnPackingCheckQuery.Name = "btnPackingCheckQuery"
        Me.btnPackingCheckQuery.Tag = "BasicFindReport.FrmPackingCheckQuery"
        Me.btnPackingCheckQuery.Text = "包装检查报表"
        '
        'btnPrintQCCheck
        '
        Me.btnPrintQCCheck.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrintQCCheck.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnPrintQCCheck.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_59
        Me.btnPrintQCCheck.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnPrintQCCheck.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnPrintQCCheck.KeyTips = "M0321_"
        Me.btnPrintQCCheck.Name = "btnPrintQCCheck"
        Me.btnPrintQCCheck.Tag = "BarCodePrint.FrmPrintQCCheck"
        Me.btnPrintQCCheck.Text = "标签品质确认"
        '
        'btnFrmPackingCheckMaster
        '
        Me.btnFrmPackingCheckMaster.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnFrmPackingCheckMaster.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnFrmPackingCheckMaster.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_61
        Me.btnFrmPackingCheckMaster.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnFrmPackingCheckMaster.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnFrmPackingCheckMaster.KeyTips = "M059N_"
        Me.btnFrmPackingCheckMaster.Name = "btnFrmPackingCheckMaster"
        Me.btnFrmPackingCheckMaster.Tag = "BarCodeScan.FrmPackingCheckMaster"
        Me.btnFrmPackingCheckMaster.Text = "包装检查设置"
        '
        'btnFrmEmployeeScan
        '
        Me.btnFrmEmployeeScan.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnFrmEmployeeScan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnFrmEmployeeScan.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_25
        Me.btnFrmEmployeeScan.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnFrmEmployeeScan.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnFrmEmployeeScan.KeyTips = "M059X_"
        Me.btnFrmEmployeeScan.Name = "btnFrmEmployeeScan"
        Me.btnFrmEmployeeScan.Tag = "BasicManagement.FrmEmployeeScan"
        Me.btnFrmEmployeeScan.Text = "员工刷卡作业"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem6.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_88
        Me.ButtonItem6.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem6.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem6.KeyTips = "M059Y_"
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.Tag = "BasicManagement.FrmHWPackList"
        Me.ButtonItem6.Text = "华为直发明细维护"
        '
        'ButtonItem57
        '
        Me.ButtonItem57.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem57.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem57.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_88
        Me.ButtonItem57.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem57.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem57.KeyTips = "M059Z_"
        Me.ButtonItem57.Name = "ButtonItem57"
        Me.ButtonItem57.Tag = "BasicManagement.FrmHWPackWeight"
        Me.ButtonItem57.Text = "华为包装称重维护"
        '
        'ButtonItem115
        '
        Me.ButtonItem115.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem115.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem115.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_30
        Me.ButtonItem115.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem115.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem115.KeyTips = "M0513_"
        Me.ButtonItem115.Name = "ButtonItem115"
        Me.ButtonItem115.Tag = "BarCodeScan.FrmOutOfBoxCheck"
        Me.ButtonItem115.Text = "开箱检查"
        '
        'ButtonItem60
        '
        Me.ButtonItem60.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem60.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem60.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_50
        Me.ButtonItem60.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem60.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem60.KeyTips = "M097A_"
        Me.ButtonItem60.Name = "ButtonItem60"
        Me.ButtonItem60.Tag = "WarehouseWeight.FrmWeightCheck"
        Me.ButtonItem60.Text = "华为包装称重校验"
        '
        'ButtonItem111
        '
        Me.ButtonItem111.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem111.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem111.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_30
        Me.ButtonItem111.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem111.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem111.Name = "ButtonItem111"
        Me.ButtonItem111.Tag = "BarCodeScan.FrmTestStationHandle"
        Me.ButtonItem111.Text = "微软测试站跳站作业"
        '
        'ButtonItemOBACheck
        '
        Me.ButtonItemOBACheck.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemOBACheck.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemOBACheck.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_54
        Me.ButtonItemOBACheck.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemOBACheck.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemOBACheck.KeyTips = "M9105_"
        Me.ButtonItemOBACheck.Name = "ButtonItemOBACheck"
        Me.ButtonItemOBACheck.Tag = "BarCodeScan.FrmOBACheck"
        Me.ButtonItemOBACheck.Text = "OQA品质检验"
        '
        'RibbonPanel3
        '
        Me.RibbonPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel3.Controls.Add(Me.RibbonBar2)
        Me.RibbonPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel3.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel3.Name = "RibbonPanel3"
        Me.RibbonPanel3.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel3.Size = New System.Drawing.Size(1360, 98)
        '
        '
        '
        Me.RibbonPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel3.TabIndex = 6
        Me.RibbonPanel3.Visible = False
        '
        'RibbonBar2
        '
        Me.RibbonBar2.AutoOverflowEnabled = True
        Me.RibbonBar2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RibbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar2.ContainerControlProcessDialogKey = True
        Me.RibbonBar2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonBar2.DragDropSupport = True
        Me.RibbonBar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem3, Me.ButtonItem4, Me.ButtonItem5, Me.ButtonItem40, Me.ButtonItem50, Me.ButtonItem70, Me.ButtonItem1, Me.ButtonItem18, Me.btnBarCodeReceivedRecord, Me.btFrmComplementApplication, Me.ButtonItem107, Me.ButtonItem105, Me.ButtonItem28, Me.ButtonItem52, Me.btnFrmListOthePrint, Me.ButtonItem155})
        Me.RibbonBar2.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar2.Name = "RibbonBar2"
        Me.RibbonBar2.Size = New System.Drawing.Size(1354, 95)
        Me.RibbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar2.TabIndex = 1
        '
        '
        '
        Me.RibbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar2.TitleVisible = False
        Me.RibbonBar2.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem3.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_39
        Me.ButtonItem3.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem3.KeyTips = "M0314_"
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Tag = "BarCodePrint.FrmCodeSet"
        Me.ButtonItem3.Text = "条码编码原则设置"
        '
        'ButtonItem4
        '
        Me.ButtonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem4.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_41
        Me.ButtonItem4.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem4.KeyTips = "M0311_"
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.Tag = "BarCodePrint.FrmPrtSet"
        Me.ButtonItem4.Text = "料件打印参数设置"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem5.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_42
        Me.ButtonItem5.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem5.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem5.KeyTips = "M0312_"
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Tag = "BarCodePrint.FrmPrtTask"
        Me.ButtonItem5.Text = "打印申请作业"
        '
        'ButtonItem40
        '
        Me.ButtonItem40.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem40.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_44
        Me.ButtonItem40.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem40.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem40.KeyTips = "M059D_"
        Me.ButtonItem40.Name = "ButtonItem40"
        Me.ButtonItem40.Tag = "BarCodeScan.FrmLaserPrint"
        Me.ButtonItem40.Text = "镭雕打标作业"
        Me.ButtonItem40.Tooltip = "B"
        '
        'ButtonItem50
        '
        Me.ButtonItem50.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem50.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_45
        Me.ButtonItem50.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem50.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem50.KeyTips = "M059E_"
        Me.ButtonItem50.Name = "ButtonItem50"
        Me.ButtonItem50.Tag = "BarCodeScan.FrmAutoLaserPrint"
        Me.ButtonItem50.Text = "自动化打标作业"
        Me.ButtonItem50.Tooltip = "B"
        '
        'ButtonItem70
        '
        Me.ButtonItem70.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem70.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem70.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_47
        Me.ButtonItem70.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem70.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem70.KeyTips = "M0316_"
        Me.ButtonItem70.Name = "ButtonItem70"
        Me.ButtonItem70.Tag = "BarCodePrint.FrmReprint"
        Me.ButtonItem70.Text = "不良条码申请"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem1.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_52
        Me.ButtonItem1.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem1.KeyTips = "M0317_"
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Tag = "BarCodePrint.FrmListPrint"
        Me.ButtonItem1.Text = "条码打印作业"
        '
        'ButtonItem18
        '
        Me.ButtonItem18.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem18.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_50
        Me.ButtonItem18.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem18.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem18.KeyTips = "M0323_"
        Me.ButtonItem18.Name = "ButtonItem18"
        Me.ButtonItem18.Tag = "BarCodePrint.FrmListPrintLine"
        Me.ButtonItem18.Text = "在线条码打印"
        '
        'btnBarCodeReceivedRecord
        '
        Me.btnBarCodeReceivedRecord.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnBarCodeReceivedRecord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBarCodeReceivedRecord.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_49
        Me.btnBarCodeReceivedRecord.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnBarCodeReceivedRecord.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnBarCodeReceivedRecord.KeyTips = "M1022_"
        Me.btnBarCodeReceivedRecord.Name = "btnBarCodeReceivedRecord"
        Me.btnBarCodeReceivedRecord.Tag = "BasicManagement.FrmBarCodeReceivedRecord"
        Me.btnBarCodeReceivedRecord.Text = "标签发放记录"
        '
        'btFrmComplementApplication
        '
        Me.btFrmComplementApplication.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btFrmComplementApplication.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btFrmComplementApplication.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_52
        Me.btFrmComplementApplication.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btFrmComplementApplication.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btFrmComplementApplication.KeyTips = "M0320_"
        Me.btFrmComplementApplication.Name = "btFrmComplementApplication"
        Me.btFrmComplementApplication.Tag = "BarCodePrint.FrmComplementApplication"
        Me.btFrmComplementApplication.Text = "标签补数申请"
        '
        'ButtonItem107
        '
        Me.ButtonItem107.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem107.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem107.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_52
        Me.ButtonItem107.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem107.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem107.KeyTips = "M0318_"
        Me.ButtonItem107.Name = "ButtonItem107"
        Me.ButtonItem107.Tag = "BarCodePrint.FrmLotPrint"
        Me.ButtonItem107.Text = "批次打印作业"
        '
        'ButtonItem105
        '
        Me.ButtonItem105.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem105.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem105.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_52
        Me.ButtonItem105.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem105.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem105.KeyTips = "M0324_"
        Me.ButtonItem105.Name = "ButtonItem105"
        Me.ButtonItem105.Tag = "BarCodePrint.FrmPEPrint"
        Me.ButtonItem105.Text = "特殊PE袋标签打印"
        '
        'ButtonItem28
        '
        Me.ButtonItem28.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem28.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_42
        Me.ButtonItem28.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem28.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem28.KeyTips = "M150402_"
        Me.ButtonItem28.Name = "ButtonItem28"
        Me.ButtonItem28.Tag = "BarCodePrint.FrmPalletPrint"
        Me.ButtonItem28.Text = "在线打印栈板"
        '
        'ButtonItem52
        '
        Me.ButtonItem52.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem52.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_52
        Me.ButtonItem52.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem52.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem52.KeyTips = "M0319_"
        Me.ButtonItem52.Name = "ButtonItem52"
        Me.ButtonItem52.Tag = "BarCodePrint.FrmH3Print"
        Me.ButtonItem52.Text = "华三打印作业"
        '
        'btnFrmListOthePrint
        '
        Me.btnFrmListOthePrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnFrmListOthePrint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnFrmListOthePrint.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_52
        Me.btnFrmListOthePrint.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnFrmListOthePrint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnFrmListOthePrint.KeyTips = "M0322_"
        Me.btnFrmListOthePrint.Name = "btnFrmListOthePrint"
        Me.btnFrmListOthePrint.Tag = "BarCodePrint.FrmListOthePrint"
        Me.btnFrmListOthePrint.Text = "特殊条码打印"
        '
        'ButtonItem155
        '
        Me.ButtonItem155.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem155.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem155.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_44
        Me.ButtonItem155.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem155.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem155.KeyTips = "M0110_"
        Me.ButtonItem155.Name = "ButtonItem155"
        Me.ButtonItem155.Tag = "BarCodePrint.FrmSYPrint"
        Me.ButtonItem155.Text = "条码生成"
        '
        'RibbonPanel11
        '
        Me.RibbonPanel11.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel11.Controls.Add(Me.RibbonBar11)
        Me.RibbonPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel11.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel11.Name = "RibbonPanel11"
        Me.RibbonPanel11.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel11.Size = New System.Drawing.Size(1360, 99)
        '
        '
        '
        Me.RibbonPanel11.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel11.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel11.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel11.TabIndex = 15
        Me.RibbonPanel11.Visible = False
        '
        'RibbonBar11
        '
        Me.RibbonBar11.AutoOverflowEnabled = True
        Me.RibbonBar11.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RibbonBar11.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar11.ContainerControlProcessDialogKey = True
        Me.RibbonBar11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonBar11.DragDropSupport = True
        Me.RibbonBar11.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem81, Me.ButtonItem82, Me.ButtonItem83, Me.ButtonItem84, Me.ButtonItem169, Me.ButtonItem173})
        Me.RibbonBar11.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar11.Name = "RibbonBar11"
        Me.RibbonBar11.Size = New System.Drawing.Size(1354, 96)
        Me.RibbonBar11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar11.TabIndex = 5
        '
        '
        '
        Me.RibbonBar11.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar11.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar11.TitleVisible = False
        Me.RibbonBar11.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem81
        '
        Me.ButtonItem81.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem81.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem81.Image = CType(resources.GetObject("ButtonItem81.Image"), System.Drawing.Image)
        Me.ButtonItem81.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem81.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem81.KeyTips = "M1201_"
        Me.ButtonItem81.Name = "ButtonItem81"
        Me.ButtonItem81.Tag = "HelpCenter.FrmIssueReport"
        Me.ButtonItem81.Text = "问题报表"
        '
        'ButtonItem82
        '
        Me.ButtonItem82.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem82.Image = CType(resources.GetObject("ButtonItem82.Image"), System.Drawing.Image)
        Me.ButtonItem82.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem82.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem82.KeyTips = "M1202_"
        Me.ButtonItem82.Name = "ButtonItem82"
        Me.ButtonItem82.Tag = "HelpCenter.FrmIssueSolve"
        Me.ButtonItem82.Text = "处理问题"
        '
        'ButtonItem83
        '
        Me.ButtonItem83.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem83.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem83.Image = CType(resources.GetObject("ButtonItem83.Image"), System.Drawing.Image)
        Me.ButtonItem83.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem83.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem83.KeyTips = "M1203_"
        Me.ButtonItem83.Name = "ButtonItem83"
        Me.ButtonItem83.Tag = "HelpCenter.FrmIssueTrace"
        Me.ButtonItem83.Text = "问题进度查询"
        '
        'ButtonItem84
        '
        Me.ButtonItem84.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem84.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem84.Image = CType(resources.GetObject("ButtonItem84.Image"), System.Drawing.Image)
        Me.ButtonItem84.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem84.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem84.KeyTips = "M1204_"
        Me.ButtonItem84.Name = "ButtonItem84"
        Me.ButtonItem84.Tag = "HelpCenter.FrmIssueNew"
        Me.ButtonItem84.Text = "新建问题"
        '
        'ButtonItem169
        '
        Me.ButtonItem169.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem169.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem169.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_38
        Me.ButtonItem169.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem169.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem169.KeyTips = "M0511_"
        Me.ButtonItem169.Name = "ButtonItem169"
        Me.ButtonItem169.Tag = "MESUserManage.FrmHWASNCheck"
        Me.ButtonItem169.Text = "华为补打ASN条码校验"
        '
        'ButtonItem173
        '
        Me.ButtonItem173.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem173.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem173.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_32
        Me.ButtonItem173.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem173.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem173.KeyTips = "M0114_"
        Me.ButtonItem173.Name = "ButtonItem173"
        Me.ButtonItem173.Tag = "MESUserManage.FrmHW19ASNCheck"
        Me.ButtonItem173.Text = "华为旧19条码新ASN比对"
        '
        'RibbonPanelEqp
        '
        Me.RibbonPanelEqp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanelEqp.Controls.Add(Me.RibbonBarEqp)
        Me.RibbonPanelEqp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanelEqp.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanelEqp.Name = "RibbonPanelEqp"
        Me.RibbonPanelEqp.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanelEqp.Size = New System.Drawing.Size(1360, 99)
        '
        '
        '
        Me.RibbonPanelEqp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanelEqp.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanelEqp.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanelEqp.TabIndex = 16
        Me.RibbonPanelEqp.Visible = False
        '
        'RibbonBarEqp
        '
        Me.RibbonBarEqp.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBarEqp.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarEqp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarEqp.ContainerControlProcessDialogKey = True
        Me.RibbonBarEqp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonBarEqp.DragDropSupport = True
        Me.RibbonBarEqp.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem124, Me.ButtonItem144, Me.ButtonItemEqp02, Me.ButtonItemEqp03, Me.ButtonItemEqp04})
        Me.RibbonBarEqp.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBarEqp.Name = "RibbonBarEqp"
        Me.RibbonBarEqp.Size = New System.Drawing.Size(1354, 96)
        Me.RibbonBarEqp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarEqp.TabIndex = 0
        '
        '
        '
        Me.RibbonBarEqp.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarEqp.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarEqp.TitleVisible = False
        Me.RibbonBarEqp.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem124
        '
        Me.ButtonItem124.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem124.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem124.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_77
        Me.ButtonItem124.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem124.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem124.KeyTips = "M150403_"
        Me.ButtonItem124.Name = "ButtonItem124"
        Me.ButtonItem124.Tag = "Equipment.BaseInfo"
        Me.ButtonItem124.Text = "设备类型位置"
        '
        'ButtonItem144
        '
        Me.ButtonItem144.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem144.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem144.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_78
        Me.ButtonItem144.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem144.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem144.KeyTips = "M150404_"
        Me.ButtonItem144.Name = "ButtonItem144"
        Me.ButtonItem144.Tag = "Equipment.EquipmentInfo"
        Me.ButtonItem144.Text = "设备基础信息"
        '
        'ButtonItemEqp02
        '
        Me.ButtonItemEqp02.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemEqp02.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemEqp02.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_79
        Me.ButtonItemEqp02.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemEqp02.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemEqp02.KeyTips = "M150525_"
        Me.ButtonItemEqp02.Name = "ButtonItemEqp02"
        Me.ButtonItemEqp02.Tag = "Equipment.EquipReport"
        Me.ButtonItemEqp02.Text = "设备基础信息-报表"
        '
        'ButtonItemEqp03
        '
        Me.ButtonItemEqp03.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemEqp03.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemEqp03.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_80
        Me.ButtonItemEqp03.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemEqp03.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemEqp03.KeyTips = "M150606_"
        Me.ButtonItemEqp03.Name = "ButtonItemEqp03"
        Me.ButtonItemEqp03.Tag = "Equipment.EquipBorrow"
        Me.ButtonItemEqp03.Text = "设备借出归还-报表"
        '
        'ButtonItemEqp04
        '
        Me.ButtonItemEqp04.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemEqp04.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemEqp04.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_82
        Me.ButtonItemEqp04.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemEqp04.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemEqp04.KeyTips = "M150601_"
        Me.ButtonItemEqp04.Name = "ButtonItemEqp04"
        Me.ButtonItemEqp04.Tag = "Equipment.EquipCheck"
        Me.ButtonItemEqp04.Text = "设备校验-报表"
        '
        'RibbonPanel12
        '
        Me.RibbonPanel12.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel12.Controls.Add(Me.RibbonBar12)
        Me.RibbonPanel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel12.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel12.Name = "RibbonPanel12"
        Me.RibbonPanel12.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel12.Size = New System.Drawing.Size(1360, 99)
        '
        '
        '
        Me.RibbonPanel12.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel12.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel12.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel12.TabIndex = 16
        Me.RibbonPanel12.Visible = False
        '
        'RibbonBar12
        '
        Me.RibbonBar12.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar12.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar12.ContainerControlProcessDialogKey = True
        Me.RibbonBar12.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar12.DragDropSupport = True
        Me.RibbonBar12.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem92, Me.ButtonItem96, Me.ButtonItem100, Me.ButtonItem110, Me.ButtonItem112, Me.ButtonItem102, Me.ButtonItem94, Me.ButtonItem98, Me.ButtonItem99, Me.ButtonItem140, Me.ButtonItem152, Me.ButtonItem63, Me.ButtonItem64, Me.ButtonItem67, Me.ButtonItem116})
        Me.RibbonBar12.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar12.Name = "RibbonBar12"
        Me.RibbonBar12.Size = New System.Drawing.Size(1284, 96)
        Me.RibbonBar12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar12.TabIndex = 0
        '
        '
        '
        Me.RibbonBar12.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar12.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar12.TitleVisible = False
        Me.RibbonBar12.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem92
        '
        Me.ButtonItem92.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem92.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem92.Image = CType(resources.GetObject("ButtonItem92.Image"), System.Drawing.Image)
        Me.ButtonItem92.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem92.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem92.KeyTips = "M1311"
        Me.ButtonItem92.Name = "ButtonItem92"
        Me.ButtonItem92.SubItemsExpandWidth = 14
        Me.ButtonItem92.Tag = "EquipmentManagement.FrmEquipmentManualApply"
        Me.ButtonItem92.Text = "工治具申请"
        '
        'ButtonItem96
        '
        Me.ButtonItem96.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem96.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem96.Image = CType(resources.GetObject("ButtonItem96.Image"), System.Drawing.Image)
        Me.ButtonItem96.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem96.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem96.KeyTips = "M1312"
        Me.ButtonItem96.Name = "ButtonItem96"
        Me.ButtonItem96.SubItemsExpandWidth = 14
        Me.ButtonItem96.Tag = "EquipmentManagement.FrmEquipmentBorrow"
        Me.ButtonItem96.Text = "工治具出库"
        '
        'ButtonItem100
        '
        Me.ButtonItem100.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem100.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem100.Image = CType(resources.GetObject("ButtonItem100.Image"), System.Drawing.Image)
        Me.ButtonItem100.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem100.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem100.KeyTips = "M1313"
        Me.ButtonItem100.Name = "ButtonItem100"
        Me.ButtonItem100.SubItemsExpandWidth = 14
        Me.ButtonItem100.Tag = "EquipmentManagement.FrmEquipmentReturn"
        Me.ButtonItem100.Text = "工治具入库"
        '
        'ButtonItem110
        '
        Me.ButtonItem110.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem110.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem110.Image = CType(resources.GetObject("ButtonItem110.Image"), System.Drawing.Image)
        Me.ButtonItem110.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem110.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem110.KeyTips = "M1316"
        Me.ButtonItem110.Name = "ButtonItem110"
        Me.ButtonItem110.SubItemsExpandWidth = 14
        Me.ButtonItem110.Tag = "EquipmentManagement.FrmEquipmentRepair"
        Me.ButtonItem110.Text = "工治具维修保养"
        '
        'ButtonItem112
        '
        Me.ButtonItem112.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem112.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem112.Image = CType(resources.GetObject("ButtonItem112.Image"), System.Drawing.Image)
        Me.ButtonItem112.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem112.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem112.KeyTips = "M1318"
        Me.ButtonItem112.Name = "ButtonItem112"
        Me.ButtonItem112.SubItemsExpandWidth = 14
        Me.ButtonItem112.Tag = "EquipmentManagement.FrmEquipmentStock"
        Me.ButtonItem112.Text = "库存查询"
        '
        'ButtonItem102
        '
        Me.ButtonItem102.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem102.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem102.Image = CType(resources.GetObject("ButtonItem102.Image"), System.Drawing.Image)
        Me.ButtonItem102.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem102.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem102.KeyTips = "M1319"
        Me.ButtonItem102.Name = "ButtonItem102"
        Me.ButtonItem102.SubItemsExpandWidth = 14
        Me.ButtonItem102.Tag = "EquipmentManagement.FrmEqupmentCategory"
        Me.ButtonItem102.Text = "类别参数设置"
        '
        'ButtonItem94
        '
        Me.ButtonItem94.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem94.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem94.Image = CType(resources.GetObject("ButtonItem94.Image"), System.Drawing.Image)
        Me.ButtonItem94.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem94.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem94.KeyTips = "M1314"
        Me.ButtonItem94.Name = "ButtonItem94"
        Me.ButtonItem94.SubItemsExpandWidth = 14
        Me.ButtonItem94.Tag = "EquipmentManagement.FrmBiotechnologyboard"
        Me.ButtonItem94.Text = "生技看板"
        '
        'ButtonItem98
        '
        Me.ButtonItem98.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem98.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem98.Image = CType(resources.GetObject("ButtonItem98.Image"), System.Drawing.Image)
        Me.ButtonItem98.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem98.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem98.KeyTips = "M1315"
        Me.ButtonItem98.Name = "ButtonItem98"
        Me.ButtonItem98.SubItemsExpandWidth = 14
        Me.ButtonItem98.Tag = "EquipmentManagement.FrmProductionLineBoard"
        Me.ButtonItem98.Text = "产线看板"
        '
        'ButtonItem99
        '
        Me.ButtonItem99.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem99.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem99.Image = CType(resources.GetObject("ButtonItem99.Image"), System.Drawing.Image)
        Me.ButtonItem99.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem99.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem99.KeyTips = "M1317"
        Me.ButtonItem99.Name = "ButtonItem99"
        Me.ButtonItem99.SubItemsExpandWidth = 14
        Me.ButtonItem99.Tag = "EquipmentManagement.FrmEquipmentReqD"
        Me.ButtonItem99.Text = "申请明细报表"
        '
        'ButtonItem140
        '
        Me.ButtonItem140.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem140.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem140.Image = CType(resources.GetObject("ButtonItem140.Image"), System.Drawing.Image)
        Me.ButtonItem140.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem140.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem140.KeyTips = "M131A"
        Me.ButtonItem140.Name = "ButtonItem140"
        Me.ButtonItem140.Tag = "EquipmentManagement.FrmEquipment"
        Me.ButtonItem140.Text = "载治具资料维护"
        '
        'ButtonItem152
        '
        Me.ButtonItem152.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem152.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem152.Image = CType(resources.GetObject("ButtonItem152.Image"), System.Drawing.Image)
        Me.ButtonItem152.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem152.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem152.KeyTips = "M131B"
        Me.ButtonItem152.Name = "ButtonItem152"
        Me.ButtonItem152.Tag = "EquipmentManagement.FrmProductEquipment"
        Me.ButtonItem152.Text = "工装治具五金关系"
        '
        'ButtonItem63
        '
        Me.ButtonItem63.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem63.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem63.Image = CType(resources.GetObject("ButtonItem63.Image"), System.Drawing.Image)
        Me.ButtonItem63.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem63.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem63.KeyTips = "M131C"
        Me.ButtonItem63.Name = "ButtonItem63"
        Me.ButtonItem63.Tag = "EquipmentManagement.FrmLineBorrow"
        Me.ButtonItem63.Text = "产线互借"
        '
        'ButtonItem64
        '
        Me.ButtonItem64.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem64.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem64.Image = CType(resources.GetObject("ButtonItem64.Image"), System.Drawing.Image)
        Me.ButtonItem64.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem64.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem64.KeyTips = "M131D"
        Me.ButtonItem64.Name = "ButtonItem64"
        Me.ButtonItem64.Tag = "EquipmentManagement.FrmAsset"
        Me.ButtonItem64.Text = "资产管理"
        '
        'ButtonItem67
        '
        Me.ButtonItem67.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem67.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem67.Image = CType(resources.GetObject("ButtonItem67.Image"), System.Drawing.Image)
        Me.ButtonItem67.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem67.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem67.KeyTips = "M131E"
        Me.ButtonItem67.Name = "ButtonItem67"
        Me.ButtonItem67.Tag = "EquipmentManagement.FrmMaterialReg"
        Me.ButtonItem67.Text = "机加工领用登记"
        '
        'ButtonItem116
        '
        Me.ButtonItem116.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem116.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem116.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_63
        Me.ButtonItem116.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem116.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem116.KeyTips = "M131F"
        Me.ButtonItem116.Name = "ButtonItem116"
        Me.ButtonItem116.Tag = "EquipmentManagement.FrmConsumable"
        Me.ButtonItem116.Text = "消耗品管理"
        '
        'RibbonPanel9
        '
        Me.RibbonPanel9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel9.Controls.Add(Me.RibbonBar9)
        Me.RibbonPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel9.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel9.Name = "RibbonPanel9"
        Me.RibbonPanel9.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel9.Size = New System.Drawing.Size(1360, 99)
        '
        '
        '
        Me.RibbonPanel9.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel9.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel9.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel9.TabIndex = 13
        Me.RibbonPanel9.Visible = False
        '
        'RibbonBar9
        '
        Me.RibbonBar9.AutoOverflowEnabled = True
        Me.RibbonBar9.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RibbonBar9.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar9.ContainerControlProcessDialogKey = True
        Me.RibbonBar9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonBar9.DragDropSupport = True
        Me.RibbonBar9.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem73, Me.ButtonItem75, Me.ButtonItemPickingManagement, Me.ButtonItem168, Me.ButtonItem163, Me.ButtonItem165, Me.ButtonItem166, Me.ButtonItem167, Me.btnCustomerOrderQuery, Me.ButtonItem51, Me.btnHWPOImport, Me.btnPartRet, Me.ButtonItem114})
        Me.RibbonBar9.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar9.Name = "RibbonBar9"
        Me.RibbonBar9.Size = New System.Drawing.Size(1354, 96)
        Me.RibbonBar9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar9.TabIndex = 3
        '
        '
        '
        Me.RibbonBar9.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar9.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar9.TitleVisible = False
        Me.RibbonBar9.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem73
        '
        Me.ButtonItem73.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem73.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem73.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_60
        Me.ButtonItem73.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem73.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem73.KeyTips = "M0717_"
        Me.ButtonItem73.Name = "ButtonItem73"
        Me.ButtonItem73.Tag = "BarCodePrint.FrmPrinterMaster"
        Me.ButtonItem73.Text = "打印机维护"
        Me.ButtonItem73.Visible = False
        '
        'ButtonItem75
        '
        Me.ButtonItem75.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem75.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem75.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_63
        Me.ButtonItem75.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem75.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem75.KeyTips = "M1003_"
        Me.ButtonItem75.Name = "ButtonItem75"
        Me.ButtonItem75.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem157, Me.ButtonItem158, Me.ButtonItem159, Me.ButtonItem160, Me.ButtonItem161, Me.ButtonItem162, Me.ButtonItemBarcodePrinterManagement, Me.ButtonItemMaterialManagement})
        Me.ButtonItem75.Tag = "BarCodePrint.FrmLocationPrint"
        Me.ButtonItem75.Text = "库位打印作业"
        Me.ButtonItem75.Visible = False
        '
        'ButtonItem157
        '
        Me.ButtonItem157.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem157.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem157.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_65
        Me.ButtonItem157.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem157.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem157.KeyTips = "M0702__"
        Me.ButtonItem157.Name = "ButtonItem157"
        Me.ButtonItem157.Tag = "WmsManagement.FrmWarehousingQuery"
        Me.ButtonItem157.Text = "入库"
        Me.ButtonItem157.Visible = False
        '
        'ButtonItem158
        '
        Me.ButtonItem158.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem158.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem158.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_66
        Me.ButtonItem158.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem158.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem158.KeyTips = "M0703__"
        Me.ButtonItem158.Name = "ButtonItem158"
        Me.ButtonItem158.Tag = "WmsManagement.FrmOutStorehouseQuery"
        Me.ButtonItem158.Text = "出库"
        Me.ButtonItem158.Visible = False
        '
        'ButtonItem159
        '
        Me.ButtonItem159.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem159.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem159.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_67
        Me.ButtonItem159.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem159.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem159.KeyTips = "M0708__"
        Me.ButtonItem159.Name = "ButtonItem159"
        Me.ButtonItem159.Tag = "WmsManagement.FrmStoreRequisitionQuery"
        Me.ButtonItem159.Text = "调拨"
        Me.ButtonItem159.Visible = False
        '
        'ButtonItem160
        '
        Me.ButtonItem160.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem160.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem160.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_68
        Me.ButtonItem160.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem160.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem160.KeyTips = "M0707__"
        Me.ButtonItem160.Name = "ButtonItem160"
        Me.ButtonItem160.Tag = "WmsManagement.FrmInventoryCheckingQuery"
        Me.ButtonItem160.Text = "盘点"
        Me.ButtonItem160.Visible = False
        '
        'ButtonItem161
        '
        Me.ButtonItem161.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem161.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem161.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_69
        Me.ButtonItem161.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem161.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem161.KeyTips = "M0706__"
        Me.ButtonItem161.Name = "ButtonItem161"
        Me.ButtonItem161.Tag = "WmsManagement.FrmInvoiceManagement"
        Me.ButtonItem161.Text = "单据管理"
        Me.ButtonItem161.Visible = False
        '
        'ButtonItem162
        '
        Me.ButtonItem162.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem162.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem162.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_70
        Me.ButtonItem162.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem162.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem162.KeyTips = "M0704__"
        Me.ButtonItem162.Name = "ButtonItem162"
        Me.ButtonItem162.Tag = "WmsManagement.FrmOrderManagement"
        Me.ButtonItem162.Text = "订单管理"
        Me.ButtonItem162.Visible = False
        '
        'ButtonItemBarcodePrinterManagement
        '
        Me.ButtonItemBarcodePrinterManagement.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemBarcodePrinterManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemBarcodePrinterManagement.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_71
        Me.ButtonItemBarcodePrinterManagement.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemBarcodePrinterManagement.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemBarcodePrinterManagement.KeyTips = "M0711__"
        Me.ButtonItemBarcodePrinterManagement.Name = "ButtonItemBarcodePrinterManagement"
        Me.ButtonItemBarcodePrinterManagement.Tag = "WmsManagement.FrmBarcodePrinterManagement"
        Me.ButtonItemBarcodePrinterManagement.Text = "物料条码打印"
        Me.ButtonItemBarcodePrinterManagement.Visible = False
        '
        'ButtonItemMaterialManagement
        '
        Me.ButtonItemMaterialManagement.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemMaterialManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemMaterialManagement.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_72
        Me.ButtonItemMaterialManagement.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemMaterialManagement.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemMaterialManagement.KeyTips = "M0709__"
        Me.ButtonItemMaterialManagement.Name = "ButtonItemMaterialManagement"
        Me.ButtonItemMaterialManagement.Tag = "WmsManagement.FrmMaterialManagement"
        Me.ButtonItemMaterialManagement.Text = "物料管理"
        Me.ButtonItemMaterialManagement.Visible = False
        '
        'ButtonItemPickingManagement
        '
        Me.ButtonItemPickingManagement.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemPickingManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemPickingManagement.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_74
        Me.ButtonItemPickingManagement.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemPickingManagement.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemPickingManagement.KeyTips = "M0712__"
        Me.ButtonItemPickingManagement.Name = "ButtonItemPickingManagement"
        Me.ButtonItemPickingManagement.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFinishedProductStorage, Me.ButtonItemFinishedProduct, Me.ButtonItemRework, Me.ButtonItem76, Me.ButtonItem74})
        Me.ButtonItemPickingManagement.Tag = "WmsManagement.FrmPickingManagement"
        Me.ButtonItemPickingManagement.Text = "捡料管理"
        Me.ButtonItemPickingManagement.Visible = False
        '
        'ButtonItemFinishedProductStorage
        '
        Me.ButtonItemFinishedProductStorage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemFinishedProductStorage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemFinishedProductStorage.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_76
        Me.ButtonItemFinishedProductStorage.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemFinishedProductStorage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemFinishedProductStorage.KeyTips = "M0713__"
        Me.ButtonItemFinishedProductStorage.Name = "ButtonItemFinishedProductStorage"
        Me.ButtonItemFinishedProductStorage.Tag = "WmsManagement.FrmFinishedProductStorageManagement"
        Me.ButtonItemFinishedProductStorage.Text = "成品入库"
        Me.ButtonItemFinishedProductStorage.Visible = False
        '
        'ButtonItemFinishedProduct
        '
        Me.ButtonItemFinishedProduct.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemFinishedProduct.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemFinishedProduct.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_73
        Me.ButtonItemFinishedProduct.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemFinishedProduct.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemFinishedProduct.KeyTips = "M0714__"
        Me.ButtonItemFinishedProduct.Name = "ButtonItemFinishedProduct"
        Me.ButtonItemFinishedProduct.Tag = "WmsManagement.FrmFinishedProductManagement"
        Me.ButtonItemFinishedProduct.Text = "成品出库"
        Me.ButtonItemFinishedProduct.Visible = False
        '
        'ButtonItemRework
        '
        Me.ButtonItemRework.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemRework.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemRework.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_75
        Me.ButtonItemRework.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemRework.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemRework.KeyTips = "M0715__"
        Me.ButtonItemRework.Name = "ButtonItemRework"
        Me.ButtonItemRework.Tag = "WmsManagement.FrmReworkManagement"
        Me.ButtonItemRework.Text = "退货重工"
        Me.ButtonItemRework.Visible = False
        '
        'ButtonItem76
        '
        Me.ButtonItem76.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem76.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem76.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_64
        Me.ButtonItem76.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem76.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem76.KeyTips = "M1001_"
        Me.ButtonItem76.Name = "ButtonItem76"
        Me.ButtonItem76.Tag = "BarCodePrint.FrmPrinterMaster"
        Me.ButtonItem76.Text = "物料属性设置"
        Me.ButtonItem76.Visible = False
        '
        'ButtonItem74
        '
        Me.ButtonItem74.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem74.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem74.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_62
        Me.ButtonItem74.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem74.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem74.KeyTips = "M1002_"
        Me.ButtonItem74.Name = "ButtonItem74"
        Me.ButtonItem74.Tag = "BarCodePrint.FrmPOPrint"
        Me.ButtonItem74.Text = "收料打印作业"
        Me.ButtonItem74.Visible = False
        '
        'ButtonItem168
        '
        Me.ButtonItem168.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem168.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem168.Image = CType(resources.GetObject("ButtonItem168.Image"), System.Drawing.Image)
        Me.ButtonItem168.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem168.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem168.KeyTips = "M1319"
        Me.ButtonItem168.Name = "ButtonItem168"
        Me.ButtonItem168.SubItemsExpandWidth = 14
        Me.ButtonItem168.Tag = "SysWms.FrmLocaion"
        Me.ButtonItem168.Text = "仓库维护"
        '
        'ButtonItem163
        '
        Me.ButtonItem163.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem163.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem163.Image = CType(resources.GetObject("ButtonItem163.Image"), System.Drawing.Image)
        Me.ButtonItem163.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem163.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem163.Name = "ButtonItem163"
        Me.ButtonItem163.SubItemsExpandWidth = 14
        Me.ButtonItem163.Tag = "WmsManagement.FrmWarehouseInstruct"
        Me.ButtonItem163.Text = "导入出货指示单"
        '
        'ButtonItem165
        '
        Me.ButtonItem165.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem165.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem165.Image = CType(resources.GetObject("ButtonItem165.Image"), System.Drawing.Image)
        Me.ButtonItem165.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem165.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem165.KeyTips = "M1313"
        Me.ButtonItem165.Name = "ButtonItem165"
        Me.ButtonItem165.SubItemsExpandWidth = 14
        Me.ButtonItem165.Tag = "WmsManagement.FrmWareHouseIn"
        Me.ButtonItem165.Text = "入库"
        '
        'ButtonItem166
        '
        Me.ButtonItem166.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem166.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem166.Image = CType(resources.GetObject("ButtonItem166.Image"), System.Drawing.Image)
        Me.ButtonItem166.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem166.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem166.KeyTips = "M1312"
        Me.ButtonItem166.Name = "ButtonItem166"
        Me.ButtonItem166.SubItemsExpandWidth = 14
        Me.ButtonItem166.Tag = "WmsManagement.FrmWareHouseOut"
        Me.ButtonItem166.Text = "出库"
        '
        'ButtonItem167
        '
        Me.ButtonItem167.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem167.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem167.Image = CType(resources.GetObject("ButtonItem167.Image"), System.Drawing.Image)
        Me.ButtonItem167.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem167.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem167.KeyTips = "M1318"
        Me.ButtonItem167.Name = "ButtonItem167"
        Me.ButtonItem167.SubItemsExpandWidth = 14
        Me.ButtonItem167.Tag = "WmsManagement.FrmWareHouseFind"
        Me.ButtonItem167.Text = "库存查询"
        '
        'btnCustomerOrderQuery
        '
        Me.btnCustomerOrderQuery.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCustomerOrderQuery.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCustomerOrderQuery.Image = CType(resources.GetObject("btnCustomerOrderQuery.Image"), System.Drawing.Image)
        Me.btnCustomerOrderQuery.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnCustomerOrderQuery.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnCustomerOrderQuery.KeyTips = "M1103_"
        Me.btnCustomerOrderQuery.Name = "btnCustomerOrderQuery"
        Me.btnCustomerOrderQuery.Tag = "BasicFindReport.FrmCustomerOrderQuery"
        Me.btnCustomerOrderQuery.Text = "海翼出货报表"
        '
        'ButtonItem51
        '
        Me.ButtonItem51.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem51.Image = CType(resources.GetObject("ButtonItem51.Image"), System.Drawing.Image)
        Me.ButtonItem51.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem51.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem51.KeyTips = "M1102_"
        Me.ButtonItem51.Name = "ButtonItem51"
        Me.ButtonItem51.Tag = "BasicManagement.FrmCustomerOrderMaster"
        Me.ButtonItem51.Text = "合约订单管理"
        '
        'btnHWPOImport
        '
        Me.btnHWPOImport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnHWPOImport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnHWPOImport.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_17
        Me.btnHWPOImport.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnHWPOImport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnHWPOImport.KeyTips = "M1105_"
        Me.btnHWPOImport.Name = "btnHWPOImport"
        Me.btnHWPOImport.Tag = "WmsManagement.FrmHWPONumber"
        Me.btnHWPOImport.Text = "HWPO单导入"
        '
        'btnPartRet
        '
        Me.btnPartRet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPartRet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnPartRet.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_99
        Me.btnPartRet.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnPartRet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnPartRet.Name = "btnPartRet"
        Me.btnPartRet.Tag = "WmsManagement.FrmPartRetrospective"
        Me.btnPartRet.Text = "原材料追溯"
        '
        'ButtonItem114
        '
        Me.ButtonItem114.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_16
        Me.ButtonItem114.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem114.Name = "ButtonItem114"
        Me.ButtonItem114.SubItemsExpandWidth = 14
        Me.ButtonItem114.Tag = "SampleManage.FrmMateriel"
        Me.ButtonItem114.Text = "出货资料维护"
        '
        'RibbonPanel13
        '
        Me.RibbonPanel13.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel13.Controls.Add(Me.RibbonBar13)
        Me.RibbonPanel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel13.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel13.Name = "RibbonPanel13"
        Me.RibbonPanel13.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel13.Size = New System.Drawing.Size(1360, 99)
        '
        '
        '
        Me.RibbonPanel13.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel13.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel13.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel13.TabIndex = 17
        Me.RibbonPanel13.Visible = False
        '
        'RibbonBar13
        '
        Me.RibbonBar13.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar13.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar13.ContainerControlProcessDialogKey = True
        Me.RibbonBar13.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar13.DragDropSupport = True
        Me.RibbonBar13.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem131, Me.ButtonItem133, Me.ButtonItem134, Me.ButtonItem135, Me.ButtonItem136, Me.ButtonItem139, Me.ButtonItem43, Me.ButtonItem45, Me.ButtonItem90, Me.ButtonItem97, Me.ButtonItem103, Me.ButtonItem11, Me.BtnItemHighSpeedLine, Me.btnBOFToolList})
        Me.RibbonBar13.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar13.Name = "RibbonBar13"
        Me.RibbonBar13.Size = New System.Drawing.Size(1287, 96)
        Me.RibbonBar13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar13.TabIndex = 0
        '
        '
        '
        Me.RibbonBar13.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar13.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar13.TitleVisible = False
        Me.RibbonBar13.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem131
        '
        Me.ButtonItem131.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem131.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem131.Image = CType(resources.GetObject("ButtonItem131.Image"), System.Drawing.Image)
        Me.ButtonItem131.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem131.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem131.KeyTips = "RCARD2_"
        Me.ButtonItem131.Name = "ButtonItem131"
        Me.ButtonItem131.Tag = "RCard.FrmRunCard"
        Me.ButtonItem131.Text = "标准工艺流程设计"
        '
        'ButtonItem133
        '
        Me.ButtonItem133.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem133.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem133.Image = CType(resources.GetObject("ButtonItem133.Image"), System.Drawing.Image)
        Me.ButtonItem133.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem133.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem133.KeyTips = "RCARD1_"
        Me.ButtonItem133.Name = "ButtonItem133"
        Me.ButtonItem133.Tag = "RCard.FrmLotScan"
        Me.ButtonItem133.Text = "工站制程扫描"
        '
        'ButtonItem134
        '
        Me.ButtonItem134.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem134.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem134.Image = CType(resources.GetObject("ButtonItem134.Image"), System.Drawing.Image)
        Me.ButtonItem134.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem134.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem134.KeyTips = "RCARD6_"
        Me.ButtonItem134.Name = "ButtonItem134"
        Me.ButtonItem134.Tag = "RCard.FrmShowPictureDetail"
        Me.ButtonItem134.Text = "PLM图纸查询"
        '
        'ButtonItem135
        '
        Me.ButtonItem135.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem135.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem135.Image = CType(resources.GetObject("ButtonItem135.Image"), System.Drawing.Image)
        Me.ButtonItem135.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem135.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem135.KeyTips = "R2009_"
        Me.ButtonItem135.Name = "ButtonItem135"
        Me.ButtonItem135.Tag = "RCard.FrmShowRunCardDetail"
        Me.ButtonItem135.Text = "流程卡查询"
        Me.ButtonItem135.Tooltip = "pass_rate"
        '
        'ButtonItem136
        '
        Me.ButtonItem136.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem136.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem136.Image = CType(resources.GetObject("ButtonItem136.Image"), System.Drawing.Image)
        Me.ButtonItem136.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem136.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem136.KeyTips = "RCARD4_"
        Me.ButtonItem136.Name = "ButtonItem136"
        Me.ButtonItem136.Tag = "RCard.FrmWpartNumber"
        Me.ButtonItem136.Text = "仓库发料"
        '
        'ButtonItem139
        '
        Me.ButtonItem139.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem139.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem139.Image = CType(resources.GetObject("ButtonItem139.Image"), System.Drawing.Image)
        Me.ButtonItem139.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem139.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem139.KeyTips = "RCARD3_"
        Me.ButtonItem139.Name = "ButtonItem139"
        Me.ButtonItem139.Tag = "RCard.FrmProcessParametersMaintain"
        Me.ButtonItem139.Text = "加工工艺参数维护"
        '
        'ButtonItem43
        '
        Me.ButtonItem43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem43.Image = Global.MesSystem.My.Resources.Resources.scanLot_Image
        Me.ButtonItem43.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem43.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem43.KeyTips = "RCARD7_"
        Me.ButtonItem43.Name = "ButtonItem43"
        Me.ButtonItem43.SubItemsExpandWidth = 14
        Me.ButtonItem43.Tag = "RCard.FrmSetScan"
        Me.ButtonItem43.Text = "配套扫描"
        '
        'ButtonItem45
        '
        Me.ButtonItem45.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem45.Image = Global.MesSystem.My.Resources.Resources.search
        Me.ButtonItem45.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem45.KeyTips = "R9062_"
        Me.ButtonItem45.Name = "ButtonItem45"
        Me.ButtonItem45.SubItemsExpandWidth = 14
        Me.ButtonItem45.Tag = "RCard.FrmSetScanQuery"
        Me.ButtonItem45.Text = "配套扫描查询"
        '
        'ButtonItem90
        '
        Me.ButtonItem90.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem90.Image = Global.MesSystem.My.Resources.Resources.basemaintaince
        Me.ButtonItem90.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem90.KeyTips = "R9063_"
        Me.ButtonItem90.Name = "ButtonItem90"
        Me.ButtonItem90.SubItemsExpandWidth = 14
        Me.ButtonItem90.Tag = "RCard.FrmQuoteMaintenance"
        Me.ButtonItem90.Text = "报价工时维护"
        '
        'ButtonItem97
        '
        Me.ButtonItem97.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem97.Image = Global.MesSystem.My.Resources.Resources.sop
        Me.ButtonItem97.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem97.KeyTips = "R9064_"
        Me.ButtonItem97.Name = "ButtonItem97"
        Me.ButtonItem97.SubItemsExpandWidth = 14
        Me.ButtonItem97.Tag = "RCard.FrmOnlineSop"
        Me.ButtonItem97.Text = "在线SOP制作"
        '
        'ButtonItem103
        '
        Me.ButtonItem103.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_82
        Me.ButtonItem103.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem103.KeyTips = "M2106"
        Me.ButtonItem103.Name = "ButtonItem103"
        Me.ButtonItem103.SubItemsExpandWidth = 14
        Me.ButtonItem103.Tag = "SampleManage.FrmSampleProblem"
        Me.ButtonItem103.Text = "制程解析备忘库"
        '
        'ButtonItem11
        '
        Me.ButtonItem11.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem11.Image = CType(resources.GetObject("ButtonItem11.Image"), System.Drawing.Image)
        Me.ButtonItem11.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem11.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem11.KeyTips = "R9065_"
        Me.ButtonItem11.Name = "ButtonItem11"
        Me.ButtonItem11.Tag = "RCard.FrmRunCardCut"
        Me.ButtonItem11.Text = "裁线卡工艺设置"
        '
        'BtnItemHighSpeedLine
        '
        Me.BtnItemHighSpeedLine.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnItemHighSpeedLine.Image = Global.MesSystem.My.Resources.Resources.productstaus
        Me.BtnItemHighSpeedLine.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnItemHighSpeedLine.Name = "BtnItemHighSpeedLine"
        Me.BtnItemHighSpeedLine.SubItemsExpandWidth = 14
        Me.BtnItemHighSpeedLine.Tag = "RCard.FrmRunCardHSL"
        Me.BtnItemHighSpeedLine.Text = "标准工艺流程设计-高速线"
        '
        'btnBOFToolList
        '
        Me.btnBOFToolList.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnBOFToolList.Image = Global.MesSystem.My.Resources.Resources.LineBoard
        Me.btnBOFToolList.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnBOFToolList.Name = "btnBOFToolList"
        Me.btnBOFToolList.SubItemsExpandWidth = 14
        Me.btnBOFToolList.Tag = "RCard.FrmBOFToolList"
        Me.btnBOFToolList.Text = "BOF治具清单"
        '
        'RibbonPanel1
        '
        Me.RibbonPanel1.AutoScroll = True
        Me.RibbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar3)
        Me.RibbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel1.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel1.Name = "RibbonPanel1"
        Me.RibbonPanel1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel1.Size = New System.Drawing.Size(1360, 99)
        '
        '
        '
        Me.RibbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel1.TabIndex = 7
        Me.RibbonPanel1.Visible = False
        '
        'RibbonBar3
        '
        Me.RibbonBar3.AutoOverflowEnabled = True
        Me.RibbonBar3.AutoScroll = True
        Me.RibbonBar3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RibbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar3.ContainerControlProcessDialogKey = True
        Me.RibbonBar3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonBar3.DragDropSupport = True
        Me.RibbonBar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem33, Me.ButtonItem170, Me.ButtonItem7, Me.ButtonItem8, Me.ButtonItem14, Me.ButtonItem19, Me.ButtonItem20, Me.ButtonItem53, Me.ButtonItem23, Me.ButtonItem24, Me.ButtonItem121, Me.btnOnlineNotice, Me.ButtonItemProductionPlan, Me.ButtonItem2, Me.ButtonItem27, Me.ButtonItem113, Me.ButtonItem129, Me.ButtonItemOBA, Me.ButtonItemPartOBA, Me.ButtonItemOQA})
        Me.RibbonBar3.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar3.Name = "RibbonBar3"
        Me.RibbonBar3.Size = New System.Drawing.Size(1354, 96)
        Me.RibbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar3.TabIndex = 2
        '
        '
        '
        Me.RibbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar3.TitleVisible = False
        Me.RibbonBar3.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem33
        '
        Me.ButtonItem33.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem33.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_86
        Me.ButtonItem33.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem33.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem33.Name = "ButtonItem33"
        Me.ButtonItem33.Tag = "MESUserManage.FrmModuleManage"
        Me.ButtonItem33.Text = "前台模块设置"
        Me.ButtonItem33.Visible = False
        '
        'ButtonItem170
        '
        Me.ButtonItem170.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem170.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem170.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_88
        Me.ButtonItem170.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem170.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem170.KeyTips = "M0218_"
        Me.ButtonItem170.Name = "ButtonItem170"
        Me.ButtonItem170.Tag = "BasicManagement.FrmUserMaintaince"
        Me.ButtonItem170.Text = "员工资料维护"
        '
        'ButtonItem7
        '
        Me.ButtonItem7.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem7.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_89
        Me.ButtonItem7.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem7.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem7.KeyTips = "M0610_"
        Me.ButtonItem7.Name = "ButtonItem7"
        Me.ButtonItem7.Tag = "MoManage.FrmWorkSheet"
        Me.ButtonItem7.Text = "工单资料维护"
        '
        'ButtonItem8
        '
        Me.ButtonItem8.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem8.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_90
        Me.ButtonItem8.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem8.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem8.KeyTips = "M0620_"
        Me.ButtonItem8.Name = "ButtonItem8"
        Me.ButtonItem8.Tag = "MoManage.FrmMoMain"
        Me.ButtonItem8.Text = "工单资料查询"
        '
        'ButtonItem14
        '
        Me.ButtonItem14.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem14.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_91
        Me.ButtonItem14.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem14.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem14.KeyTips = "M0220_"
        Me.ButtonItem14.Name = "ButtonItem14"
        Me.ButtonItem14.Tag = "KanBan.FrmPartTime"
        Me.ButtonItem14.Text = "工单班别信息维护"
        '
        'ButtonItem19
        '
        Me.ButtonItem19.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem19.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_97
        Me.ButtonItem19.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem19.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem19.KeyTips = "M0201_"
        Me.ButtonItem19.Name = "ButtonItem19"
        Me.ButtonItem19.Tag = "BasicManagement.FrmPartContrast"
        Me.ButtonItem19.Text = "料件基础资料"
        '
        'ButtonItem20
        '
        Me.ButtonItem20.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem20.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_94
        Me.ButtonItem20.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem20.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem20.KeyTips = "M0207_"
        Me.ButtonItem20.Name = "ButtonItem20"
        Me.ButtonItem20.Tag = "BasicManagement.FrmNgCode"
        Me.ButtonItem20.Text = "不良基础数据"
        '
        'ButtonItem53
        '
        Me.ButtonItem53.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem53.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem53.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_98
        Me.ButtonItem53.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem53.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem53.KeyTips = "M0219_"
        Me.ButtonItem53.Name = "ButtonItem53"
        Me.ButtonItem53.Tag = "BasicManagement.FrmNgTargetSetup"
        Me.ButtonItem53.Text = "不良目标率维护"
        '
        'ButtonItem23
        '
        Me.ButtonItem23.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem23.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_93
        Me.ButtonItem23.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem23.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem23.KeyTips = "M0209_"
        Me.ButtonItem23.Name = "ButtonItem23"
        Me.ButtonItem23.Tag = "BasicManagement.FrmRStationSet"
        Me.ButtonItem23.Text = "工站资料维护"
        '
        'ButtonItem24
        '
        Me.ButtonItem24.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem24.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_96
        Me.ButtonItem24.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem24.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem24.KeyTips = "M0208_"
        Me.ButtonItem24.Name = "ButtonItem24"
        Me.ButtonItem24.Tag = "BasicManagement.FrmRPartStation"
        Me.ButtonItem24.Text = "料件工艺流程设置"
        '
        'ButtonItem121
        '
        Me.ButtonItem121.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem121.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem121.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_99
        Me.ButtonItem121.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem121.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem121.KeyTips = "M0215_"
        Me.ButtonItem121.Name = "ButtonItem121"
        Me.ButtonItem121.Tag = "BarCodeScan.FrmAssemblySetting"
        Me.ButtonItem121.Text = "料件装配设置"
        '
        'btnOnlineNotice
        '
        Me.btnOnlineNotice.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnOnlineNotice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOnlineNotice.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_100
        Me.btnOnlineNotice.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnOnlineNotice.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnOnlineNotice.KeyTips = "M1023_"
        Me.btnOnlineNotice.Name = "btnOnlineNotice"
        Me.btnOnlineNotice.Tag = "BasicManagement.FrmOnlineNotice"
        Me.btnOnlineNotice.Text = "上线通知单"
        '
        'ButtonItemProductionPlan
        '
        Me.ButtonItemProductionPlan.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemProductionPlan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemProductionPlan.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_102
        Me.ButtonItemProductionPlan.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemProductionPlan.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemProductionPlan.KeyTips = "M20001_"
        Me.ButtonItemProductionPlan.Name = "ButtonItemProductionPlan"
        Me.ButtonItemProductionPlan.Tag = "ProductionPlan.FrmProductionPlanManagement"
        Me.ButtonItemProductionPlan.Text = "排程管理"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem2.KeyTips = "M1804"
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Tag = "KanBan.FrmLineLeader"
        Me.ButtonItem2.Text = "线别线长资料维护"
        '
        'ButtonItem27
        '
        Me.ButtonItem27.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem27.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_91
        Me.ButtonItem27.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem27.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem27.KeyTips = "M0224_"
        Me.ButtonItem27.Name = "ButtonItem27"
        Me.ButtonItem27.Tag = "BasicManagement.FrmPartMacAddress"
        Me.ButtonItem27.Text = "料件MAC地址维护"
        '
        'ButtonItem113
        '
        Me.ButtonItem113.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_46
        Me.ButtonItem113.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem113.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem113.Name = "ButtonItem113"
        Me.ButtonItem113.SubItemsExpandWidth = 14
        Me.ButtonItem113.Tag = "SampleManage.FrmCharacter"
        Me.ButtonItem113.Text = "字符卡控"
        '
        'ButtonItem129
        '
        Me.ButtonItem129.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem129.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem129.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_85
        Me.ButtonItem129.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem129.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem129.KeyTips = "M2104"
        Me.ButtonItem129.Name = "ButtonItem129"
        Me.ButtonItem129.SubItemsExpandWidth = 14
        Me.ButtonItem129.Tag = "BasicManagement.FrmMACManage"
        Me.ButtonItem129.Text = "MAC地址范围维护"
        '
        'ButtonItemOBA
        '
        Me.ButtonItemOBA.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemOBA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemOBA.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_91
        Me.ButtonItemOBA.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemOBA.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemOBA.Name = "ButtonItemOBA"
        Me.ButtonItemOBA.Tag = "BasicManagement.FrmBasicOba"
        Me.ButtonItemOBA.Text = "OQA基础资料"
        '
        'ButtonItemPartOBA
        '
        Me.ButtonItemPartOBA.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemPartOBA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemPartOBA.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_91
        Me.ButtonItemPartOBA.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemPartOBA.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemPartOBA.Name = "ButtonItemPartOBA"
        Me.ButtonItemPartOBA.Tag = "BasicManagement.FrmPartSetOBA"
        Me.ButtonItemPartOBA.Text = "料号对应OQA项目"
        '
        'ButtonItemOQA
        '
        Me.ButtonItemOQA.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemOQA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemOQA.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_91
        Me.ButtonItemOQA.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemOQA.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemOQA.Name = "ButtonItemOQA"
        Me.ButtonItemOQA.Tag = "BasicManagement.FrmOQAEdit"
        Me.ButtonItemOQA.Text = "OQA测试检验"
        '
        'RibbonPanel14
        '
        Me.RibbonPanel14.AutoScroll = True
        Me.RibbonPanel14.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel14.Controls.Add(Me.RibbonBar14)
        Me.RibbonPanel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel14.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel14.Name = "RibbonPanel14"
        Me.RibbonPanel14.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel14.Size = New System.Drawing.Size(1360, 99)
        '
        '
        '
        Me.RibbonPanel14.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel14.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel14.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel14.TabIndex = 18
        Me.RibbonPanel14.Visible = False
        '
        'RibbonBar14
        '
        Me.RibbonBar14.AutoOverflowEnabled = True
        Me.RibbonBar14.AutoScroll = True
        '
        '
        '
        Me.RibbonBar14.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar14.ContainerControlProcessDialogKey = True
        Me.RibbonBar14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonBar14.DragDropSupport = True
        Me.RibbonBar14.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem149, Me.ButtonItem41, Me.ButtonItem146, Me.ButtonItem147, Me.ButtonItem125, Me.ButtonItem137, Me.ButtonItem143, Me.ButtonItem17, Me.ButtonItem123, Me.btnFrmSeriesMaster, Me.ButtonItem9, Me.ButtonItem164, Me.ButtonItem171, Me.btnItemWarehouseManagment, Me.btnItemConnectDatabase, Me.btnItemReleasedVersion, Me.btnItemClientManagement})
        Me.RibbonBar14.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar14.Name = "RibbonBar14"
        Me.RibbonBar14.Size = New System.Drawing.Size(1354, 96)
        Me.RibbonBar14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar14.TabIndex = 0
        Me.RibbonBar14.Tag = "BasicManagement.FrmProduceLine"
        '
        '
        '
        Me.RibbonBar14.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar14.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar14.TitleVisible = False
        Me.RibbonBar14.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem149
        '
        Me.ButtonItem149.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem149.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem149.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_10
        Me.ButtonItem149.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem149.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem149.KeyTips = "M15010_"
        Me.ButtonItem149.Name = "ButtonItem149"
        Me.ButtonItem149.Tag = "BasicManagement.FrmSystemSetting"
        Me.ButtonItem149.Text = "系统设置"
        '
        'ButtonItem41
        '
        Me.ButtonItem41.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem41.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_11
        Me.ButtonItem41.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem41.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem41.KeyTips = "M011G_"
        Me.ButtonItem41.Name = "ButtonItem41"
        Me.ButtonItem41.Tag = "BasicFindReport.FrmReportAdm"
        Me.ButtonItem41.Text = "报表设置"
        '
        'ButtonItem146
        '
        Me.ButtonItem146.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem146.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem146.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_12
        Me.ButtonItem146.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem146.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem146.KeyTips = "M15007_"
        Me.ButtonItem146.Name = "ButtonItem146"
        Me.ButtonItem146.Tag = "BasicManagement.FrmLogTree"
        Me.ButtonItem146.Text = "菜单资料维护"
        '
        'ButtonItem147
        '
        Me.ButtonItem147.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem147.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem147.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_13
        Me.ButtonItem147.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem147.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem147.KeyTips = "M15008_"
        Me.ButtonItem147.Name = "ButtonItem147"
        Me.ButtonItem147.Tag = "BasicManagement.FrmWindow"
        Me.ButtonItem147.Text = "窗体资料维护"
        '
        'ButtonItem125
        '
        Me.ButtonItem125.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem125.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem125.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_14
        Me.ButtonItem125.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem125.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem125.KeyTips = "M15004_"
        Me.ButtonItem125.Name = "ButtonItem125"
        Me.ButtonItem125.Tag = "BasicManagement.FrmFactory"
        Me.ButtonItem125.Text = "工厂维护"
        '
        'ButtonItem137
        '
        Me.ButtonItem137.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem137.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem137.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_15
        Me.ButtonItem137.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem137.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem137.KeyTips = "M15006_"
        Me.ButtonItem137.Name = "ButtonItem137"
        Me.ButtonItem137.Tag = "BasicManagement.FrmProfitCenter"
        Me.ButtonItem137.Text = "利润中心资料"
        '
        'ButtonItem143
        '
        Me.ButtonItem143.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem143.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem143.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_16
        Me.ButtonItem143.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem143.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem143.KeyTips = "M15001_"
        Me.ButtonItem143.Name = "ButtonItem143"
        Me.ButtonItem143.Tag = "BasicManagement.FrmSortSet"
        Me.ButtonItem143.Text = "类别资料维护"
        '
        'ButtonItem17
        '
        Me.ButtonItem17.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem17.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_17
        Me.ButtonItem17.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem17.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem17.KeyTips = "M15002_"
        Me.ButtonItem17.Name = "ButtonItem17"
        Me.ButtonItem17.Tag = "BasicManagement.FrmDeptID"
        Me.ButtonItem17.Text = "部门基本资料"
        '
        'ButtonItem123
        '
        Me.ButtonItem123.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem123.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem123.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_18
        Me.ButtonItem123.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem123.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem123.KeyTips = "M15003_"
        Me.ButtonItem123.Name = "ButtonItem123"
        Me.ButtonItem123.Tag = "BasicManagement.FrmDeptLine"
        Me.ButtonItem123.Text = "部门线别资料"
        '
        'btnFrmSeriesMaster
        '
        Me.btnFrmSeriesMaster.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnFrmSeriesMaster.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnFrmSeriesMaster.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_16
        Me.btnFrmSeriesMaster.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnFrmSeriesMaster.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnFrmSeriesMaster.KeyTips = "M02_02"
        Me.btnFrmSeriesMaster.Name = "btnFrmSeriesMaster"
        Me.btnFrmSeriesMaster.Tag = "BasicManagement.FrmSeriesMaster"
        Me.btnFrmSeriesMaster.Text = "系列别资料"
        '
        'ButtonItem9
        '
        Me.ButtonItem9.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem9.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_20
        Me.ButtonItem9.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem9.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem9.KeyTips = "M15005_"
        Me.ButtonItem9.Name = "ButtonItem9"
        Me.ButtonItem9.Tag = "BasicManagement.FrmCustomer"
        Me.ButtonItem9.Text = "客户资料"
        '
        'ButtonItem164
        '
        Me.ButtonItem164.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem164.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem164.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_21
        Me.ButtonItem164.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem164.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem164.KeyTips = "M15011_"
        Me.ButtonItem164.Name = "ButtonItem164"
        Me.ButtonItem164.Tag = "WmsManagement.FrmSupplierManage"
        Me.ButtonItem164.Text = "供应商资料"
        '
        'ButtonItem171
        '
        Me.ButtonItem171.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem171.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem171.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_22
        Me.ButtonItem171.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem171.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem171.KeyTips = "M0701__"
        Me.ButtonItem171.Name = "ButtonItem171"
        Me.ButtonItem171.Tag = "WmsManagement.FrmWarehouseSetting"
        Me.ButtonItem171.Text = "仓库参数设置"
        '
        'btnItemWarehouseManagment
        '
        Me.btnItemWarehouseManagment.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnItemWarehouseManagment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnItemWarehouseManagment.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_23
        Me.btnItemWarehouseManagment.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnItemWarehouseManagment.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnItemWarehouseManagment.KeyTips = "M0710__"
        Me.btnItemWarehouseManagment.Name = "btnItemWarehouseManagment"
        Me.btnItemWarehouseManagment.Tag = "WmsManagement.FrmWarehouseManagment"
        Me.btnItemWarehouseManagment.Text = "仓库管理"
        '
        'btnItemConnectDatabase
        '
        Me.btnItemConnectDatabase.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnItemConnectDatabase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnItemConnectDatabase.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_24
        Me.btnItemConnectDatabase.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnItemConnectDatabase.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnItemConnectDatabase.KeyTips = "M15012_"
        Me.btnItemConnectDatabase.Name = "btnItemConnectDatabase"
        Me.btnItemConnectDatabase.Tag = "ProgramRelease.FrmConnectDatabaseDefinitions"
        Me.btnItemConnectDatabase.Text = "连接库管理"
        '
        'btnItemReleasedVersion
        '
        Me.btnItemReleasedVersion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnItemReleasedVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnItemReleasedVersion.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_25
        Me.btnItemReleasedVersion.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnItemReleasedVersion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnItemReleasedVersion.KeyTips = "M15013_"
        Me.btnItemReleasedVersion.Name = "btnItemReleasedVersion"
        Me.btnItemReleasedVersion.Tag = "ProgramRelease.FrmReleasedVersionManagement"
        Me.btnItemReleasedVersion.Text = "版本管理"
        '
        'btnItemClientManagement
        '
        Me.btnItemClientManagement.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnItemClientManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnItemClientManagement.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_27
        Me.btnItemClientManagement.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnItemClientManagement.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnItemClientManagement.KeyTips = "M15014_"
        Me.btnItemClientManagement.Name = "btnItemClientManagement"
        Me.btnItemClientManagement.Tag = "ProgramRelease.FrmClientManagement"
        Me.btnItemClientManagement.Text = "客户端管理"
        '
        'RibbonPanel10
        '
        Me.RibbonPanel10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel10.Controls.Add(Me.RibbonBar10)
        Me.RibbonPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel10.Location = New System.Drawing.Point(0, 0)
        Me.RibbonPanel10.Name = "RibbonPanel10"
        Me.RibbonPanel10.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel10.Size = New System.Drawing.Size(1360, 152)
        '
        '
        '
        Me.RibbonPanel10.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel10.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel10.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel10.TabIndex = 14
        Me.RibbonPanel10.Visible = False
        '
        'RibbonBar10
        '
        Me.RibbonBar10.AutoOverflowEnabled = True
        Me.RibbonBar10.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RibbonBar10.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar10.ContainerControlProcessDialogKey = True
        Me.RibbonBar10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonBar10.DragDropSupport = True
        Me.RibbonBar10.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem16, Me.ButtonItem104, Me.ButtonItem78, Me.ButtonItem101, Me.ButtonItem66, Me.btnMOPlan, Me.ButtonItem21, Me.btnFrmPlanReport, Me.ButtonItem106, Me.ButtonItem10, Me.ButtonItem108, Me.ButtonItem109, Me.ButtonItemBZ, Me.ButtonItem126, Me.ButtonItem127})
        Me.RibbonBar10.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar10.Name = "RibbonBar10"
        Me.RibbonBar10.Size = New System.Drawing.Size(1354, 149)
        Me.RibbonBar10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar10.TabIndex = 4
        '
        '
        '
        Me.RibbonBar10.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar10.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar10.TitleVisible = False
        Me.RibbonBar10.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem16
        '
        Me.ButtonItem16.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem16.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_19
        Me.ButtonItem16.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem16.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem16.KeyTips = "M0212_"
        Me.ButtonItem16.Name = "ButtonItem16"
        Me.ButtonItem16.Tag = "BasicManagement.FrmProduceLine"
        Me.ButtonItem16.Text = "料号类别资料"
        '
        'ButtonItem104
        '
        Me.ButtonItem104.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem104.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem104.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_6
        Me.ButtonItem104.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem104.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem104.KeyTips = "M1031_"
        Me.ButtonItem104.Name = "ButtonItem104"
        Me.ButtonItem104.Tag = "ProductionPlan.FrmPartCategory"
        Me.ButtonItem104.Text = "料件类别维护"
        '
        'ButtonItem78
        '
        Me.ButtonItem78.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem78.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem78.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_12
        Me.ButtonItem78.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem78.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem78.KeyTips = "M1027_"
        Me.ButtonItem78.Name = "ButtonItem78"
        Me.ButtonItem78.Tag = "ProductionSchedule.FrmProductionSchedule"
        Me.ButtonItem78.Text = "生产维护"
        '
        'ButtonItem101
        '
        Me.ButtonItem101.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem101.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem101.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_16
        Me.ButtonItem101.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem101.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem101.KeyTips = "M1029_"
        Me.ButtonItem101.Name = "ButtonItem101"
        Me.ButtonItem101.Tag = "ProductionPlan.FrmMOOutDate"
        Me.ButtonItem101.Text = "出货日期维护"
        '
        'ButtonItem66
        '
        Me.ButtonItem66.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem66.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem66.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_47
        Me.ButtonItem66.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem66.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem66.KeyTips = "M1030_"
        Me.ButtonItem66.Name = "ButtonItem66"
        Me.ButtonItem66.Tag = "ProductionSchedule.FrmStopDate"
        Me.ButtonItem66.Text = "停线日期维护"
        '
        'btnMOPlan
        '
        Me.btnMOPlan.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnMOPlan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnMOPlan.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_92
        Me.btnMOPlan.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnMOPlan.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnMOPlan.KeyTips = "M0221_"
        Me.btnMOPlan.Name = "btnMOPlan"
        Me.btnMOPlan.Tag = "ProductionPlan.FrmTiptopPlanMaster"
        Me.btnMOPlan.Text = "生产派工计划"
        '
        'ButtonItem21
        '
        Me.ButtonItem21.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem21.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_46
        Me.ButtonItem21.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem21.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem21.KeyTips = "M1028_"
        Me.ButtonItem21.Name = "ButtonItem21"
        Me.ButtonItem21.Tag = "ProductionPlan.FrmEMCPEPT"
        Me.ButtonItem21.Text = "EMC生产设备人员追踪"
        '
        'btnFrmPlanReport
        '
        Me.btnFrmPlanReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnFrmPlanReport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnFrmPlanReport.Image = CType(resources.GetObject("btnFrmPlanReport.Image"), System.Drawing.Image)
        Me.btnFrmPlanReport.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnFrmPlanReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnFrmPlanReport.KeyTips = "M20003_"
        Me.btnFrmPlanReport.Name = "btnFrmPlanReport"
        Me.btnFrmPlanReport.Tag = "ProductionPlan.FrmPlanReport"
        Me.btnFrmPlanReport.Text = "派单查询"
        '
        'ButtonItem106
        '
        Me.ButtonItem106.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem106.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem106.Image = Global.MesSystem.My.Resources.Resources._151214
        Me.ButtonItem106.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem106.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem106.KeyTips = "M1032_"
        Me.ButtonItem106.Name = "ButtonItem106"
        Me.ButtonItem106.Tag = "ProductionPlan.FrmPlanUpload"
        Me.ButtonItem106.Text = "派工上传"
        '
        'ButtonItem10
        '
        Me.ButtonItem10.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem10.Image = CType(resources.GetObject("ButtonItem10.Image"), System.Drawing.Image)
        Me.ButtonItem10.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem10.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem10.KeyTips = "M20005_"
        Me.ButtonItem10.Name = "ButtonItem10"
        Me.ButtonItem10.Tag = "BasicFindReport.FrmTaskTime"
        Me.ButtonItem10.Text = "工时统计报表"
        '
        'ButtonItem108
        '
        Me.ButtonItem108.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem108.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem108.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_92
        Me.ButtonItem108.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem108.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem108.KeyTips = "M1033_"
        Me.ButtonItem108.Name = "ButtonItem108"
        Me.ButtonItem108.Tag = "ProductionPlan.FrmProductionPlanUpdate"
        Me.ButtonItem108.Text = "派工资料更新"
        '
        'ButtonItem109
        '
        Me.ButtonItem109.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem109.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem109.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_102
        Me.ButtonItem109.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem109.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem109.KeyTips = "M20004_"
        Me.ButtonItem109.Name = "ButtonItem109"
        Me.ButtonItem109.Tag = "ProductionPlan.FrmWorkDayPlan"
        Me.ButtonItem109.Text = "生产日计划"
        '
        'ButtonItemBZ
        '
        Me.ButtonItemBZ.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemBZ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItemBZ.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_92
        Me.ButtonItemBZ.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItemBZ.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemBZ.KeyTips = "M0222_"
        Me.ButtonItemBZ.Name = "ButtonItemBZ"
        Me.ButtonItemBZ.Tag = "ProductionPlan.FrmBZAutoSchedule"
        Me.ButtonItemBZ.Text = "亳州FFC生产排程"
        '
        'ButtonItem126
        '
        Me.ButtonItem126.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_19
        Me.ButtonItem126.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem126.Name = "ButtonItem126"
        Me.ButtonItem126.SubItemsExpandWidth = 14
        Me.ButtonItem126.Tag = "ProductionPlan.FrmLeanProCD"
        Me.ButtonItem126.Text = "精益生产柱形图"
        '
        'ButtonItem127
        '
        Me.ButtonItem127.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem127.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem127.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_26
        Me.ButtonItem127.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem127.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem127.KeyTips = "M0598_"
        Me.ButtonItem127.Name = "ButtonItem127"
        Me.ButtonItem127.Tag = "BarCodeScan.FrmPartLotScan"
        Me.ButtonItem127.Text = "前制程上料扫描"
        '
        'RibbonPanel6
        '
        Me.RibbonPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel6.Controls.Add(Me.RibbonBarS)
        Me.RibbonPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel6.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel6.Name = "RibbonPanel6"
        Me.RibbonPanel6.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel6.Size = New System.Drawing.Size(1360, 99)
        '
        '
        '
        Me.RibbonPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel6.TabIndex = 21
        Me.RibbonPanel6.Visible = False
        '
        'RibbonBarS
        '
        Me.RibbonBarS.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBarS.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarS.ContainerControlProcessDialogKey = True
        Me.RibbonBarS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonBarS.DragDropSupport = True
        Me.RibbonBarS.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem68, Me.ButtonItem69, Me.ButtonItem88, Me.ButtonItem89, Me.ButtonItem95})
        Me.RibbonBarS.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBarS.Name = "RibbonBarS"
        Me.RibbonBarS.Size = New System.Drawing.Size(1354, 96)
        Me.RibbonBarS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarS.TabIndex = 0
        '
        '
        '
        Me.RibbonBarS.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarS.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarS.TitleVisible = False
        Me.RibbonBarS.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItem68
        '
        Me.ButtonItem68.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem68.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem68.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_81
        Me.ButtonItem68.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem68.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem68.KeyTips = "M2101"
        Me.ButtonItem68.Name = "ButtonItem68"
        Me.ButtonItem68.Tag = "SampleManage.FrmPIC"
        Me.ButtonItem68.Text = "责任人维护"
        '
        'ButtonItem69
        '
        Me.ButtonItem69.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem69.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem69.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_83
        Me.ButtonItem69.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem69.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem69.KeyTips = "M2102"
        Me.ButtonItem69.Name = "ButtonItem69"
        Me.ButtonItem69.Tag = "SampleManage.FrmSampleReqNo"
        Me.ButtonItem69.Text = "研发资料下载"
        '
        'ButtonItem88
        '
        Me.ButtonItem88.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem88.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem88.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_84
        Me.ButtonItem88.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem88.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem88.KeyTips = "M2103"
        Me.ButtonItem88.Name = "ButtonItem88"
        Me.ButtonItem88.Tag = "SampleManage.FrmSampleUpload"
        Me.ButtonItem88.Text = "样品资料上传"
        '
        'ButtonItem89
        '
        Me.ButtonItem89.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem89.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem89.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_85
        Me.ButtonItem89.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem89.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem89.KeyTips = "M2104"
        Me.ButtonItem89.Name = "ButtonItem89"
        Me.ButtonItem89.SubItemsExpandWidth = 14
        Me.ButtonItem89.Tag = "SampleManage.FrmSample"
        Me.ButtonItem89.Text = "样品资料维护"
        '
        'ButtonItem95
        '
        Me.ButtonItem95.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonItem95.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_87
        Me.ButtonItem95.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.ButtonItem95.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem95.KeyTips = "M2105"
        Me.ButtonItem95.Name = "ButtonItem95"
        Me.ButtonItem95.SubItemsExpandWidth = 14
        Me.ButtonItem95.Tag = "SampleManage.FrmSampleScan"
        Me.ButtonItem95.Text = "样品扫描"
        '
        'RibbonPanel15
        '
        Me.RibbonPanel15.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel15.Controls.Add(Me.RibbonBarDataHistoryList)
        Me.RibbonPanel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel15.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel15.Name = "RibbonPanel15"
        Me.RibbonPanel15.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel15.Size = New System.Drawing.Size(1360, 99)
        '
        '
        '
        Me.RibbonPanel15.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel15.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel15.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel15.TabIndex = 19
        Me.RibbonPanel15.Visible = False
        '
        'RibbonBarDataHistoryList
        '
        Me.RibbonBarDataHistoryList.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBarDataHistoryList.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarDataHistoryList.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarDataHistoryList.ContainerControlProcessDialogKey = True
        Me.RibbonBarDataHistoryList.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBarDataHistoryList.DragDropSupport = True
        Me.RibbonBarDataHistoryList.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnItemLinkServerManagement, Me.btnDataHistoryManagement})
        Me.RibbonBarDataHistoryList.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBarDataHistoryList.Name = "RibbonBarDataHistoryList"
        Me.RibbonBarDataHistoryList.Size = New System.Drawing.Size(1284, 96)
        Me.RibbonBarDataHistoryList.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarDataHistoryList.TabIndex = 1
        '
        '
        '
        Me.RibbonBarDataHistoryList.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarDataHistoryList.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarDataHistoryList.TitleVisible = False
        Me.RibbonBarDataHistoryList.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'btnItemLinkServerManagement
        '
        Me.btnItemLinkServerManagement.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnItemLinkServerManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnItemLinkServerManagement.Image = CType(resources.GetObject("btnItemLinkServerManagement.Image"), System.Drawing.Image)
        Me.btnItemLinkServerManagement.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnItemLinkServerManagement.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnItemLinkServerManagement.KeyTips = "M16001_"
        Me.btnItemLinkServerManagement.Name = "btnItemLinkServerManagement"
        Me.btnItemLinkServerManagement.Tag = "DataHistoryManagement.FrmLinkServerManagement"
        Me.btnItemLinkServerManagement.Text = "链接服务器管理"
        '
        'btnDataHistoryManagement
        '
        Me.btnDataHistoryManagement.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDataHistoryManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnDataHistoryManagement.Image = CType(resources.GetObject("btnDataHistoryManagement.Image"), System.Drawing.Image)
        Me.btnDataHistoryManagement.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.[Default]
        Me.btnDataHistoryManagement.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnDataHistoryManagement.KeyTips = "M16002_"
        Me.btnDataHistoryManagement.Name = "btnDataHistoryManagement"
        Me.btnDataHistoryManagement.Tag = "DataHistoryManagement.FrmDataHistoryManagement"
        Me.btnDataHistoryManagement.Text = "数据迁移管理"
        '
        'RibbonPanel7
        '
        Me.RibbonPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel7.Controls.Add(Me.RibBarMouldManagement)
        Me.RibbonPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel7.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel7.Name = "RibbonPanel7"
        Me.RibbonPanel7.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel7.Size = New System.Drawing.Size(1360, 99)
        '
        '
        '
        Me.RibbonPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel7.TabIndex = 22
        Me.RibbonPanel7.Visible = False
        '
        'RibBarMouldManagement
        '
        Me.RibBarMouldManagement.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibBarMouldManagement.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibBarMouldManagement.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibBarMouldManagement.ContainerControlProcessDialogKey = True
        Me.RibBarMouldManagement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibBarMouldManagement.DragDropSupport = True
        Me.RibBarMouldManagement.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnItemMouldBasicData, Me.ButtonItem153, Me.ButtonItem150, Me.ButtonItem145, Me.ButtonItem138, Me.ButtonItem132, Me.ButtonItem130})
        Me.RibBarMouldManagement.Location = New System.Drawing.Point(3, 0)
        Me.RibBarMouldManagement.Name = "RibBarMouldManagement"
        Me.RibBarMouldManagement.Size = New System.Drawing.Size(1354, 96)
        Me.RibBarMouldManagement.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibBarMouldManagement.TabIndex = 0
        Me.RibBarMouldManagement.Text = "RibbonBar7"
        '
        '
        '
        Me.RibBarMouldManagement.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibBarMouldManagement.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibBarMouldManagement.TitleVisible = False
        Me.RibBarMouldManagement.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'BtnItemMouldBasicData
        '
        Me.BtnItemMouldBasicData.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnItemMouldBasicData.Image = Global.MesSystem.My.Resources.Resources.configset
        Me.BtnItemMouldBasicData.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.BtnItemMouldBasicData.Name = "BtnItemMouldBasicData"
        Me.BtnItemMouldBasicData.SubItemsExpandWidth = 14
        Me.BtnItemMouldBasicData.Tag = "MouldManagement.FrmMouldBasicData"
        Me.BtnItemMouldBasicData.Text = "模具基础资料"
        '
        'ButtonItem153
        '
        Me.ButtonItem153.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_46
        Me.ButtonItem153.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem153.Name = "ButtonItem153"
        Me.ButtonItem153.SubItemsExpandWidth = 14
        Me.ButtonItem153.Tag = "BarCodeScan.FrmTreasury"
        Me.ButtonItem153.Text = "出货信息比对"
        '
        'ButtonItem150
        '
        Me.ButtonItem150.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_30
        Me.ButtonItem150.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem150.Name = "ButtonItem150"
        Me.ButtonItem150.SubItemsExpandWidth = 14
        Me.ButtonItem150.Tag = "BarCodeScan.FrmShipments"
        Me.ButtonItem150.Text = "出货信息录入"
        '
        'ButtonItem145
        '
        Me.ButtonItem145.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_22
        Me.ButtonItem145.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem145.Name = "ButtonItem145"
        Me.ButtonItem145.SubItemsExpandWidth = 14
        Me.ButtonItem145.Tag = "BarCodeScan.FrmWarehousing"
        Me.ButtonItem145.Text = "入库"
        '
        'ButtonItem138
        '
        Me.ButtonItem138.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_19
        Me.ButtonItem138.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem138.Name = "ButtonItem138"
        Me.ButtonItem138.SubItemsExpandWidth = 14
        Me.ButtonItem138.Tag = "BarCodeScan.Frmcheck"
        Me.ButtonItem138.Text = "校验"
        '
        'ButtonItem132
        '
        Me.ButtonItem132.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_15
        Me.ButtonItem132.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem132.Name = "ButtonItem132"
        Me.ButtonItem132.SubItemsExpandWidth = 14
        Me.ButtonItem132.Tag = "BarCodeScan.Frmcollection"
        Me.ButtonItem132.Text = "抽测"
        '
        'ButtonItem130
        '
        Me.ButtonItem130.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem130.Image = Global.MesSystem.My.Resources.Resources.Artboard_Copy_12
        Me.ButtonItem130.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Large
        Me.ButtonItem130.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem130.Name = "ButtonItem130"
        Me.ButtonItem130.PopupSide = DevComponents.DotNetBar.ePopupSide.Top
        Me.ButtonItem130.SubItemsExpandWidth = 14
        Me.ButtonItem130.Tag = "BarCodeScan.Frmprocess"
        Me.ButtonItem130.Text = "抽测流程设置"
        '
        'RibbonTabItem1
        '
        Me.RibbonTabItem1.ColorTable = DevComponents.DotNetBar.eRibbonTabColor.Green
        Me.RibbonTabItem1.KeyTips = "M01_"
        Me.RibbonTabItem1.Name = "RibbonTabItem1"
        Me.RibbonTabItem1.Panel = Me.RibbonPanel2
        Me.RibbonTabItem1.Text = "常用功能"
        '
        'RibbonTabItem14
        '
        Me.RibbonTabItem14.KeyTips = "M15_"
        Me.RibbonTabItem14.Name = "RibbonTabItem14"
        Me.RibbonTabItem14.Panel = Me.RibbonPanel14
        Me.RibbonTabItem14.Text = "系统设置"
        '
        'RibbonTabItem3
        '
        Me.RibbonTabItem3.KeyTips = "M02_"
        Me.RibbonTabItem3.Name = "RibbonTabItem3"
        Me.RibbonTabItem3.Panel = Me.RibbonPanel1
        Me.RibbonTabItem3.Text = "基础资料维护"
        '
        'RibbonTabItem4
        '
        Me.RibbonTabItem4.KeyTips = "M05_"
        Me.RibbonTabItem4.Name = "RibbonTabItem4"
        Me.RibbonTabItem4.Panel = Me.RibbonPanel4
        Me.RibbonTabItem4.Text = "制程控制采集"
        '
        'RibbonTabItem2
        '
        Me.RibbonTabItem2.KeyTips = "M03_"
        Me.RibbonTabItem2.Name = "RibbonTabItem2"
        Me.RibbonTabItem2.Panel = Me.RibbonPanel3
        Me.RibbonTabItem2.Text = "条码设计打印"
        '
        'RibbonTabItem8
        '
        Me.RibbonTabItem8.KeyTips = "M04_"
        Me.RibbonTabItem8.Name = "RibbonTabItem8"
        Me.RibbonTabItem8.Panel = Me.RibbonPanel8
        Me.RibbonTabItem8.Text = "品质管理"
        '
        'RibbonTabItem9
        '
        Me.RibbonTabItem9.KeyTips = "M07_"
        Me.RibbonTabItem9.Name = "RibbonTabItem9"
        Me.RibbonTabItem9.Panel = Me.RibbonPanel9
        Me.RibbonTabItem9.Text = "仓储管理系统"
        '
        'RibbonTabItem12
        '
        Me.RibbonTabItem12.KeyTips = "M13_"
        Me.RibbonTabItem12.Name = "RibbonTabItem12"
        Me.RibbonTabItem12.Panel = Me.RibbonPanel12
        Me.RibbonTabItem12.Text = "设备及工治具管理"
        '
        'RibbonTabItem5
        '
        Me.RibbonTabItem5.Checked = True
        Me.RibbonTabItem5.KeyTips = "M09_"
        Me.RibbonTabItem5.Name = "RibbonTabItem5"
        Me.RibbonTabItem5.Panel = Me.RibbonPanel5
        Me.RibbonTabItem5.SplitButton = True
        Me.RibbonTabItem5.Text = "报表查询"
        '
        'RibbonTabItem10
        '
        Me.RibbonTabItem10.KeyTips = "M20_"
        Me.RibbonTabItem10.Name = "RibbonTabItem10"
        Me.RibbonTabItem10.Panel = Me.RibbonPanel10
        Me.RibbonTabItem10.Text = "计划排程"
        '
        'RibbonTabItem13
        '
        Me.RibbonTabItem13.KeyTips = "M17_"
        Me.RibbonTabItem13.Name = "RibbonTabItem13"
        Me.RibbonTabItem13.Panel = Me.RibbonPanel13
        Me.RibbonTabItem13.Text = "工艺制程"
        '
        'RibbonTabItem11
        '
        Me.RibbonTabItem11.KeyTips = "M12_"
        Me.RibbonTabItem11.Name = "RibbonTabItem11"
        Me.RibbonTabItem11.Panel = Me.RibbonPanel11
        Me.RibbonTabItem11.Text = "帮助中心"
        '
        'RibTabItMouldManagement
        '
        Me.RibTabItMouldManagement.Name = "RibTabItMouldManagement"
        Me.RibTabItMouldManagement.Panel = Me.RibbonPanel7
        Me.RibTabItMouldManagement.Text = "模具管理"
        '
        'RibbonTabItemEqp
        '
        Me.RibbonTabItemEqp.KeyTips = "M0403_"
        Me.RibbonTabItemEqp.Name = "RibbonTabItemEqp"
        Me.RibbonTabItemEqp.Panel = Me.RibbonPanelEqp
        Me.RibbonTabItemEqp.Text = "设备管理"
        '
        'rtabItemDataHistory
        '
        Me.rtabItemDataHistory.KeyTips = "M16_"
        Me.rtabItemDataHistory.Name = "rtabItemDataHistory"
        Me.rtabItemDataHistory.Panel = Me.RibbonPanel15
        Me.rtabItemDataHistory.Text = "数据迁移"
        '
        'RibbonTabItem15
        '
        Me.RibbonTabItem15.KeyTips = "M19_"
        Me.RibbonTabItem15.Name = "RibbonTabItem15"
        Me.RibbonTabItem15.Panel = Me.RibbonPanel16
        Me.RibbonTabItem15.Text = "看板"
        '
        'RibbonTabItemS
        '
        Me.RibbonTabItemS.KeyTips = "M21_"
        Me.RibbonTabItemS.Name = "RibbonTabItemS"
        Me.RibbonTabItemS.Panel = Me.RibbonPanel6
        Me.RibbonTabItemS.Text = "样品管理"
        '
        'ButTitle
        '
        Me.ButTitle.ForeColor = System.Drawing.Color.Black
        Me.ButTitle.HotForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButTitle.Name = "ButTitle"
        Me.ButTitle.PopupType = DevComponents.DotNetBar.ePopupType.ToolBar
        Me.ButTitle.ShowSubItems = False
        Me.ButTitle.StopPulseOnMouseOver = False
        Me.ButTitle.Text = "立讯精密MES现场执行管理系统"
        '
        'ribbonTabItemGroup1
        '
        Me.ribbonTabItemGroup1.Color = DevComponents.DotNetBar.eRibbonTabGroupColor.Orange
        Me.ribbonTabItemGroup1.GroupTitle = "Tab Group"
        Me.ribbonTabItemGroup1.Name = "ribbonTabItemGroup1"
        '
        '
        '
        Me.ribbonTabItemGroup1.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.ribbonTabItemGroup1.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ribbonTabItemGroup1.Style.BackColorGradientAngle = 90
        Me.ribbonTabItemGroup1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ribbonTabItemGroup1.Style.BorderBottomWidth = 1
        Me.ribbonTabItemGroup1.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ribbonTabItemGroup1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ribbonTabItemGroup1.Style.BorderLeftWidth = 1
        Me.ribbonTabItemGroup1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ribbonTabItemGroup1.Style.BorderRightWidth = 1
        Me.ribbonTabItemGroup1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ribbonTabItemGroup1.Style.BorderTopWidth = 1
        Me.ribbonTabItemGroup1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ribbonTabItemGroup1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ribbonTabItemGroup1.Style.TextColor = System.Drawing.Color.Black
        Me.ribbonTabItemGroup1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        'ComboItem10
        '
        Me.ComboItem10.Text = "LPT1"
        '
        'ComboItem11
        '
        Me.ComboItem11.Text = "LPT2"
        '
        'ComboItem12
        '
        Me.ComboItem12.Text = "COM1"
        '
        'ComboItem13
        '
        Me.ComboItem13.Text = "COM2"
        '
        'ComboItem18
        '
        Me.ComboItem18.Text = "智能手机/条码采集器"
        '
        'ComboItem19
        '
        Me.ComboItem19.Text = "与移动端（手机/采集器）同步"
        '
        'ComboItem20
        '
        Me.ComboItem20.Text = "导出到手机/采集器"
        '
        'ComboItem21
        '
        Me.ComboItem21.Text = "导入手机端/采集器结果"
        '
        'ComboItem22
        '
        Me.ComboItem22.Text = "按采集结果执行出入库盘点"
        '
        'comboItem1
        '
        Me.comboItem1.Text = "6"
        '
        'comboItem2
        '
        Me.comboItem2.Text = "7"
        '
        'comboItem3
        '
        Me.comboItem3.Text = "8"
        '
        'comboItem4
        '
        Me.comboItem4.Text = "9"
        '
        'comboItem5
        '
        Me.comboItem5.Text = "10"
        '
        'comboItem6
        '
        Me.comboItem6.Text = "11"
        '
        'comboItem7
        '
        Me.comboItem7.Text = "12"
        '
        'comboItem8
        '
        Me.comboItem8.Text = "13"
        '
        'comboItem9
        '
        Me.comboItem9.Text = "14"
        '
        'ComboItem14
        '
        Me.ComboItem14.Text = "LPT1"
        '
        'ComboItem15
        '
        Me.ComboItem15.Text = "LPT2"
        '
        'ComboItem16
        '
        Me.ComboItem16.Text = "COM1"
        '
        'ComboItem17
        '
        Me.ComboItem17.Text = "COM2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(84, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Label1"
        '
        'PanPic
        '
        Me.PanPic.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.PanPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PanPic.Controls.Add(Me.Panel1)
        Me.PanPic.Controls.Add(Me.PicLoginMain)
        Me.PanPic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanPic.Location = New System.Drawing.Point(5, 181)
        Me.PanPic.Name = "PanPic"
        Me.PanPic.Size = New System.Drawing.Size(1360, 442)
        Me.PanPic.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.GroupPanel1)
        Me.Panel1.Controls.Add(Me.MetroTilePanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 300, 3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1360, 442)
        Me.Panel1.TabIndex = 55
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.RichTextBox1)
        Me.GroupPanel1.Controls.Add(Me.labTitle)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(305, 339)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(752, 100)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 75
        Me.GroupPanel1.Text = "系统公告"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.White
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Font = New System.Drawing.Font("微软雅黑", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 10)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(100, 3, 100, 3)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(723, 58)
        Me.RichTextBox1.TabIndex = 55
        Me.RichTextBox1.Text = "暂无公共"
        '
        'labTitle
        '
        Me.labTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.labTitle.AutoSize = True
        Me.labTitle.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.labTitle.ForeColor = System.Drawing.Color.Red
        Me.labTitle.Location = New System.Drawing.Point(41, 10)
        Me.labTitle.Name = "labTitle"
        Me.labTitle.Size = New System.Drawing.Size(0, 20)
        Me.labTitle.TabIndex = 56
        '
        'MetroTilePanel1
        '
        Me.MetroTilePanel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        '
        '
        '
        Me.MetroTilePanel1.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.MetroTilePanel1.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Transparent
        Me.MetroTilePanel1.BackgroundStyle.Class = "MetroTilePanel"
        Me.MetroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTilePanel1.ContainerControlProcessDialogKey = True
        Me.MetroTilePanel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MetroTilePanel1.DragDropSupport = True
        Me.MetroTilePanel1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1, Me.ItemContainer2})
        Me.MetroTilePanel1.Location = New System.Drawing.Point(290, 11)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(786, 329)
        Me.MetroTilePanel1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MetroTilePanel1.TabIndex = 74
        Me.MetroTilePanel1.Text = "MetroTilePanel1"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
        Me.ItemContainer1.ItemSpacing = 0
        Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MetroTileItem1, Me.MetroTileItem2, Me.MetroTileItem3, Me.MetroTileItem4, Me.MetroTileItem5, Me.MetroTileItem6})
        '
        '
        '
        Me.ItemContainer1.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.TitleStyle.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ItemContainer1.TitleText = "最近打开功能菜单"
        '
        'MetroTileItem1
        '
        Me.MetroTileItem1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MetroTileItem1.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTileItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.MetroTileItem1.Name = "MetroTileItem1"
        Me.MetroTileItem1.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue
        '
        '
        '
        Me.MetroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem1.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.MetroTileItem1.TitleTextFont = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        '
        'MetroTileItem2
        '
        Me.MetroTileItem2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MetroTileItem2.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTileItem2.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.MetroTileItem2.Name = "MetroTileItem2"
        Me.MetroTileItem2.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta
        '
        '
        '
        Me.MetroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem2.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroTileItem2.TitleTextFont = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        '
        'MetroTileItem3
        '
        Me.MetroTileItem3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MetroTileItem3.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTileItem3.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.MetroTileItem3.Name = "MetroTileItem3"
        Me.MetroTileItem3.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellowish
        '
        '
        '
        Me.MetroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem3.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroTileItem3.TitleTextFont = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        '
        'MetroTileItem4
        '
        Me.MetroTileItem4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MetroTileItem4.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTileItem4.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.MetroTileItem4.Name = "MetroTileItem4"
        Me.MetroTileItem4.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem4.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        '
        '
        '
        Me.MetroTileItem4.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem4.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTileItem4.TitleTextFont = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        '
        'MetroTileItem5
        '
        Me.MetroTileItem5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MetroTileItem5.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTileItem5.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.MetroTileItem5.Name = "MetroTileItem5"
        Me.MetroTileItem5.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem5.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Plum
        '
        '
        '
        Me.MetroTileItem5.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem5.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroTileItem5.TitleTextFont = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        '
        'MetroTileItem6
        '
        Me.MetroTileItem6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MetroTileItem6.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTileItem6.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.MetroTileItem6.Name = "MetroTileItem6"
        Me.MetroTileItem6.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem6.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
        '
        '
        '
        Me.MetroTileItem6.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem6.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroTileItem6.TitleTextFont = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        '
        'ItemContainer2
        '
        '
        '
        '
        Me.ItemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer2.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
        Me.ItemContainer2.ItemSpacing = 0
        Me.ItemContainer2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer2.MultiLine = True
        Me.ItemContainer2.Name = "ItemContainer2"
        Me.ItemContainer2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MetroLink1, Me.MetroTileItem7})
        '
        '
        '
        Me.ItemContainer2.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ItemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer2.TitleStyle.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ItemContainer2.TitleText = "系统链接"
        '
        'MetroLink1
        '
        Me.MetroLink1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MetroLink1.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroLink1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.MetroLink1.Name = "MetroLink1"
        Me.MetroLink1.SymbolColor = System.Drawing.Color.Empty
        Me.MetroLink1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Plum
        Me.MetroLink1.TileSize = New System.Drawing.Size(360, 135)
        '
        '
        '
        Me.MetroLink1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroLink1.TitleText = "SPC系统"
        Me.MetroLink1.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MetroTileItem7
        '
        Me.MetroTileItem7.AccessKeyEnabled = False
        Me.MetroTileItem7.Cursor = System.Windows.Forms.Cursors.Default
        Me.MetroTileItem7.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.MetroTileItem7.KeyTips = "建设中......"
        Me.MetroTileItem7.Name = "MetroTileItem7"
        Me.MetroTileItem7.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem7.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue
        Me.MetroTileItem7.TileSize = New System.Drawing.Size(360, 135)
        '
        '
        '
        Me.MetroTileItem7.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem7.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.MetroTileItem7.TitleText = "WebSFC系统"
        Me.MetroTileItem7.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTileItem7.Tooltip = "建设中......"
        '
        'PicLoginMain
        '
        Me.PicLoginMain.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.PicLoginMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicLoginMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicLoginMain.Image = CType(resources.GetObject("PicLoginMain.Image"), System.Drawing.Image)
        Me.PicLoginMain.Location = New System.Drawing.Point(0, 0)
        Me.PicLoginMain.Name = "PicLoginMain"
        Me.PicLoginMain.Size = New System.Drawing.Size(1360, 442)
        Me.PicLoginMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PicLoginMain.TabIndex = 0
        Me.PicLoginMain.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 300000
        '
        'HelpSOP
        '
        Me.HelpSOP.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.HelpSOP.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.HelpSOP.BackgroundImage = CType(resources.GetObject("HelpSOP.BackgroundImage"), System.Drawing.Image)
        Me.HelpSOP.Location = New System.Drawing.Point(1365, 346)
        Me.HelpSOP.Name = "HelpSOP"
        Me.HelpSOP.Size = New System.Drawing.Size(36, 84)
        Me.HelpSOP.TabIndex = 61
        Me.HelpSOP.Text = "操" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "作" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "S" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "O" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "P"
        Me.HelpSOP.UseVisualStyleBackColor = False
        '
        'mdiClient1
        '
        Me.mdiClient1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mdiClient1.BackgroundImage = CType(resources.GetObject("mdiClient1.BackgroundImage"), System.Drawing.Image)
        Me.mdiClient1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mdiClient1.Location = New System.Drawing.Point(5, 181)
        Me.mdiClient1.Name = "mdiClient1"
        Me.mdiClient1.Size = New System.Drawing.Size(1360, 442)
        Me.mdiClient1.TabIndex = 5
        '
        'picSPC
        '
        Me.picSPC.BackgroundImage = CType(resources.GetObject("picSPC.BackgroundImage"), System.Drawing.Image)
        Me.picSPC.Location = New System.Drawing.Point(592, 41)
        Me.picSPC.Name = "picSPC"
        Me.picSPC.Size = New System.Drawing.Size(356, 114)
        Me.picSPC.TabIndex = 72
        Me.picSPC.TabStop = False
        '
        'frmMain
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1370, 653)
        Me.Controls.Add(Me.HelpSOP)
        Me.Controls.Add(Me.PanPic)
        Me.Controls.Add(Me.tabStrip1)
        Me.Controls.Add(Me.ribbonControl1)
        Me.Controls.Add(Me.bar1)
        Me.Controls.Add(Me.mdiClient1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bar1.ResumeLayout(False)
        Me.bar1.PerformLayout()
        Me.ribbonControl1.ResumeLayout(False)
        Me.ribbonControl1.PerformLayout()
        Me.RibbonPanel5.ResumeLayout(False)
        Me.RibbonPanel2.ResumeLayout(False)
        Me.RibbonPanel16.ResumeLayout(False)
        Me.RibbonPanel4.ResumeLayout(False)
        Me.RibbonPanel8.ResumeLayout(False)
        Me.RibbonPanel3.ResumeLayout(False)
        Me.RibbonPanel11.ResumeLayout(False)
        Me.RibbonPanelEqp.ResumeLayout(False)
        Me.RibbonPanel12.ResumeLayout(False)
        Me.RibbonPanel9.ResumeLayout(False)
        Me.RibbonPanel13.ResumeLayout(False)
        Me.RibbonPanel1.ResumeLayout(False)
        Me.RibbonPanel14.ResumeLayout(False)
        Me.RibbonPanel10.ResumeLayout(False)
        Me.RibbonPanel6.ResumeLayout(False)
        Me.RibbonPanel15.ResumeLayout(False)
        Me.RibbonPanel7.ResumeLayout(False)
        Me.PanPic.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.PicLoginMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSPC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

#Region "AppCreation"
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <STAThread()>
    Shared Sub Main()
        Application.Run(New frmMain())
    End Sub
#End Region

    Private Sub EnableFileItems()
        '' Accessing items through the Items collection and setting the properties on them
        ' will propagate certain properties to all items with the same name...
        'If Me.ActiveMdiChild Is Nothing Then
        '    'AppCommandSave.Enabled = False
        '    'AppCommandSaveAs.Enabled = False
        'Else
        '    AppCommandSave.Enabled = True
        '    AppCommandSaveAs.Enabled = True
        '    If TypeOf Me.ActiveMdiChild Is frmDocument Then
        '        CType(Me.ActiveMdiChild, frmDocument).FormActivated()
        '    End If
        'End If
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub MdiChildActivated(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.MdiChildActivate
        Me.PanPic.Visible = False
        EnableFileItems()
        'UpdateTitle()
    End Sub

    Private Sub UnloadPopup(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As ButtonItem = TryCast(sender, ButtonItem)
        If item.Name = "bTabColor" Then
            Dim container As DevComponents.DotNetBar.PopupContainerControl = TryCast(item.PopupContainerControl, PopupContainerControl)
            'Dim clr As ColorPicker = TryCast(container.Controls(0), ColorPicker)
            'If clr.SelectedColor <> Color.Empty Then
            '    tabStrip1.ColorScheme.TabBackground = ControlPaint.LightLight(clr.SelectedColor)
            '    tabStrip1.ColorScheme.TabBackground2 = clr.SelectedColor
            '    tabStrip1.Refresh()
            'End If
            ' Close popup menu, since it is not closed when Popup Container is closed...
            item.Parent.Expanded = False
        End If
    End Sub

    Private Sub TaskPaneShowAtStartup(ByVal sender As Object, ByVal e As EventArgs)
        MessageBoxEx.Show("This item is here for demonstration purposes only and code should be added to save the state of it.")
    End Sub

    Private Sub dotNetBarManager1_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        ' Sync Status-bar with the item tooltip...
        Dim item As BaseItem = TryCast(sender, BaseItem)
        If item Is Nothing Then
            Return
        End If
        labelStatus.Text = item.Tooltip
    End Sub

    Private Sub dotNetBarManager1_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        labelStatus.Text = ""
    End Sub

    '是否加载图片 Add By KyLinQiu 20171012
    Private IsLoadPicInfo As Boolean = False

    '加载图片信息 Add By KyLinQiu
    Private Sub LoadPicData()
        Dim showbg As String = "N"
        Dim showInfo As String = "N"
        Dim sql As String = "select PARAMETER_CODE,PARAMETER_VALUES from m_SystemSetting_t where MODE_NAME='MES' and PARAMETER_CODE in ('mainbg','maininfo') "
        Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i)("PARAMETER_CODE") = "mainbg" Then
                showbg = dt.Rows(i)("PARAMETER_VALUES")
            End If
            If dt.Rows(i)("PARAMETER_CODE") = "maininfo" Then
                showInfo = dt.Rows(i)("PARAMETER_VALUES")
            End If
        Next

        Dim strAssemblyFilePath As String = Reflection.Assembly.GetExecutingAssembly().Location
        Dim strAssemblyDirPath As String = Path.GetDirectoryName(strAssemblyFilePath)
        Dim filePath As String = Path.Combine(strAssemblyDirPath, "ShowInfoPic.png")
        Dim backgroundFilePath As String = Path.Combine(strAssemblyDirPath, "BackgroundPic.png")

        Try
            '是否显示背景图,最近操作不显示
            If showbg = "Y" Then
                If Not File.Exists(backgroundFilePath) Then
                    Exit Sub
                End If
                Panel1.Visible = False
                Dim fileStream2 As New FileStream(backgroundFilePath, FileMode.Open, FileAccess.Read, FileShare.Delete)
                Me.PicLoginMain.BackgroundImage = Image.FromStream(fileStream2)
                fileStream2.Close()
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    '加载公告信息 Add By KyLinQiu 20171012
    Private Sub LoadAdvData()
        If Me.IsLoadPicInfo Then
            Exit Sub
        End If
        Me.PicLoginMain.Visible = True
        Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("select Fileno,Filename,Remark,Intime from M_Systemfile_t where Intime>DATEADD(DAY,-7,getdate()) and Usey='Y' order by Intime desc")
        'DataGridView1.DataSource = dtTemp
        'DataGridView1.Refresh()
        'Dim strAssemblyFilePath As String = Reflection.Assembly.GetExecutingAssembly().Location
        'Dim strAssemblyDirPath As String = Path.GetDirectoryName(strAssemblyFilePath)
        'Dim NormalFilePath As String = Path.Combine(strAssemblyDirPath, "NormalBg.png")

        'If Not File.Exists(NormalFilePath) Then
        '    Exit Sub
        'End If

        'Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("SELECT TOP 1 title,contents,CONVERT(NVARCHAR(16),intime,121) AS intime FROM dbo.m_Advert_t WHERE usey='Y' ORDER BY intime DESC")
        'If (dtTemp Is Nothing) OrElse dtTemp.Rows.Count <= 0 Then
        '    Me.LabFoot.Visible = False
        '    Me.LabContent.Visible = False
        '    Me.LabTitle.Visible = False
        '    Me.PanPic.Visible = False
        '    Exit Sub
        'End If
        'Me.PanPic.Visible = True
        'Me.LabTitle.Visible = True
        'Me.LabContent.Visible = True
        'Me.LabFoot.Visible = True
        'Dim NormalWidth As Integer = 700

        'Dim ContentPoint As Point = Me.LabContent.Location
        'Dim FootPoint As Point = Me.LabFoot.Location
        'If (Me.PanPic.Width) - NormalWidth > 0 Then
        '    Me.LabContent.Location = New Point((Me.PanPic.Width - NormalWidth) / 2, ContentPoint.Y)
        '    Me.LabContent.Width = NormalWidth
        '    Me.LabFoot.Location = New Point((Me.PanPic.Width - NormalWidth) / 2, FootPoint.Y)
        '    Me.LabFoot.Width = NormalWidth
        'End If

        'Me.LabTitle.Text = dtTemp.Rows(0)("title").ToString.Trim
        'Me.LabContent.Text = vbNewLine & dtTemp.Rows(0)("contents").ToString.Trim
        'Me.LabFoot.Text = "发布人员：MES系统管理员         " & vbNewLine & "发布时间：" & dtTemp.Rows(0)("intime").ToString.Trim & "      "

        'Dim fileStream As New FileStream(NormalFilePath, FileMode.Open, FileAccess.Read, FileShare.Delete)
        'Me.PanPic.BackgroundImage = Image.FromStream(fileStream)
        'fileStream.Close()
    End Sub

    '区分江西厂区和东莞厂区,方便BUG调试 Add ByKyLinQiu20180316
    '博硕电子;永新博硕;江西吉州;江西协讯;江西博硕;江西泰和;万安协讯;新余协讯;
    Private MyFactory As String = "BSDZ;COCRXIN;JIZHOU;LX21;LX53;M02600;WANXUN;XINYU;"

    Private Sub LoadFunctionClick()
        If MyFactory.Contains(VbCommClass.VbCommClass.Factory.ToUpper.Trim & ";") Then
            Me.ButtonItem1.Tag = "BarCodePrint.FrmListPrintJX"
            Me.ButtonItem80.Tag = "BarCodeScan.FrmStantPackScanBS"
        End If
    End Sub
    '王南刚 登录时加载常用前六项
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim item As eStyle
        For Each item In [Enum].GetValues(GetType(eStyle))
            If item = eStyle.VisualStudio2012Dark Then
                Continue For
            End If
            If item = eStyle.Metro Then
                Continue For
            End If
            Dim obj As ComboItem = New ComboItem
            obj.Value = Integer.Parse(item)
            obj.Text = item.ToString
            ComboBoxItem1.Items.Add(obj)
        Next
        If VbCommClass.VbCommClass.StyleID = "99" Then
            ComboBoxItem1.SelectedItem = ComboBoxItem1.Items(4)
        Else
            If Integer.Parse(VbCommClass.VbCommClass.StyleID) < 11 Then
                ComboBoxItem1.SelectedItem = ComboBoxItem1.Items(Integer.Parse(VbCommClass.VbCommClass.StyleID))
            Else
                ComboBoxItem1.SelectedItem = ComboBoxItem1.Items(11)
            End If


        End If

        MetroTilePanel1.Anchor = System.Windows.Forms.AnchorStyles.None
        GroupPanel1.Anchor = System.Windows.Forms.AnchorStyles.None
        ' SetMetroTileBgColor()
        ShowUse()  '登录时加载界面常用的前六项  2018/07/23
        'Dim jishu As Integer = 0
        'Try
        '    Dim sql = "select top 6 apid,APNAME  from M_APPSERVICECONDITION_T where USERID ='" & VbCommClass.VbCommClass.UseId & "' group by apid,APNAME order by Max(usetime) desc "
        '    Dim h As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql)
        '    For Each btton As Control In GroupBox1.Controls
        '        If TypeName(btton) = "Button" Then
        '            CType(btton, Button).Text = "            " + h.Rows(Convert.ToInt16(CType(btton, Button).Tag))(1).ToString()
        '            Trans(h.Rows(Convert.ToInt16(CType(btton, Button).Tag))(0).ToString(), Convert.ToInt16(CType(btton, Button).Tag) + 1)
        '            jishu = jishu + 1
        '        End If
        '    Next
        'Catch
        '    For index = jishu To 6
        '        Select Case jishu
        '            Case 0 : used1.Text = "联系我们"
        '                Trans("BasicManagement.FrmContact", 1)
        '                jishu = jishu + 1
        '            Case 1 : used2.Text = "包装记录查询"
        '                Trans("BasicFindReport.FrmPackQuery", 2)
        '                jishu = jishu + 1
        '            Case 2 : used3.Text = "条码打印记录"
        '                Trans("BasicFindReport.FrmPrintQuery", 3)
        '                jishu = jishu + 1
        '            Case 3 : used5.Text = "成品扫描记录"
        '                Trans("BasicFindReport.FrmScanQuery", 4)
        '                jishu = jishu + 1
        '            Case 4 : used4.Text = "不良条码记录"
        '                Trans("BarCodePrint.FrmReprintQuery", 5)
        '                jishu = jishu + 1
        '            Case 5 : used6.Text = "修改密码"
        '                Trans("MESUserManage.FrmPasswordch", 6)
        '                jishu = jishu + 1
        '        End Select
        '    Next
        'End Try
        '加载图片信息 Add By KyLinQiu
        LoadPicData()
        '加载公告信息
        LoadAdvData()

        '区分江西厂区和东莞厂区,方便BUG调试 Add ByKyLinQiu20180316
        LoadFunctionClick()

        '***********************************************************************************************
        SetMainFormInfo()
        '***********************************************************************************************

        ' Load Quick Access Toolbar layout if one is saved from last session...
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DevComponents\Ribbon")
        If key IsNot Nothing Then
            Try
                Dim layout As String = key.GetValue("RibbonPadCSLayout", "").ToString()
                If layout <> "" AndAlso layout IsNot Nothing Then
                    ribbonControl1.QatLayout = layout
                End If
            Finally
                key.Close()
            End Try
        End If
        'UpdateTitle()
        AddHandler Timer_OpenAdv.Tick, AddressOf Timer_OpenAdv_Tick
        Timer_OpenAdv.Interval = 30000
        'Timer_OpenAdv.Start()
        loadmodule()
    End Sub

    Private Sub SetMainFormInfo()
        SetTitleInfo()

        Dim serverName As String = MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName.ToString
        If serverName.Contains("DG-MESDB.luxshare.com.cn") Then
            LblSname.Text = LblSname.Text & String.Format("正式区（{0}）", serverName.Split("=")(1).Split(";")(0))
        ElseIf serverName.Contains("172.18.20.170") Then
            LblSname.Text = LblSname.Text & String.Format("正式区（{0}）", serverName.Split("=")(1).Split(";")(0))
        Else
            LblSname.Text = LblSname.Text & String.Format("（{0}）", serverName.Split("=")(1).Split(";")(0))
        End If

        SetCurDutyUser()
    End Sub

    Private Sub SetTitleInfo()
        Dim xmldoc As New Xml.XmlDocument
        Try
            Dim LoadFactory As String = ""
            Dim LoadProfitCenter As String = ""
            Dim LoadIP As String = ""
            xmldoc.Load(Application.StartupPath & "\Loginlog.xml") '讀取XML中的上次登錄用戶名
            Dim nodeList As Xml.XmlNodeList = xmldoc.SelectSingleNode("filelist").ChildNodes
            For Each xn As Xml.XmlNode In nodeList
                If LCase(xn.Name) = "servername" Then
                    LoadFactory = xn.InnerText
                    Continue For
                End If

                If LCase(xn.Name) = "profitcenter" Then
                    LoadProfitCenter = xn.InnerText
                    Continue For
                End If
            Next

            LoadIP = GetIPAddress()
            ButTitle.Text += String.Format("(营运中心:{0} 利润中心:{1} 当前用户:{2} IP：{3}) ", LoadFactory, LoadProfitCenter, SysMessageClass.UseId, LoadIP)
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "不存在XML文件", "提示信息", MessageBoxButtons.OK)
            Exit Sub
        End Try
    End Sub
    '查找电脑IP
    Private Function GetIPAddress() As String
        Dim ips As String = ""
        Try
            Dim ipHost As Net.IPHostEntry = Net.Dns.GetHostEntry(Net.Dns.GetHostName())
            Dim ipaddress As Net.IPAddress = Nothing
            Dim list As ArrayList = New ArrayList

            For i As Integer = 0 To ipHost.AddressList.Length - 1
                ipaddress = ipHost.AddressList(i)
                If (ipaddress.AddressFamily.ToString() = "InterNetwork") Then
                    If ipaddress.ToString.Length <> 19 Then
                        ips = ipaddress.ToString
                    End If
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
        Return ips
    End Function
    Private Sub SetCurDutyUser()
        Dim strSQL As String = " exec [usp_Duty_WeekPlan] '{0}','2' "
        strSQL = String.Format(strSQL, "")

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            LblUser.Text = dt.Rows(0)(0).ToString
        End If
    End Sub

    Private Timer_OpenAdv As Timer = New Timer()

    Private Sub Timer_OpenAdv_Tick(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            Dim idadv As Boolean = False
            Dim sql As String = "select ShowAdv,Advid,Advtime from m_users_t  where userid='" & MainFrame.SysCheckData.SysMessageClass.UseId & "' and ShowAdv='1' and isnull(advid,0) <> (select id from m_Advert_t where usey='Y' and getdate() between dtstart and dtend) or (isnull(advid,0) = (select id from m_Advert_t where usey='Y' and getdate() between dtstart and dtend  ) and isnull(Advtime,1900-1-1)<cast(Convert(varchar(10),getdate(),121) as datetime))"

            If DbOperateUtils.GetRowsCount(sql) > 0 Then
                idadv = True
            End If
            If idadv Then
                OpenWin()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub OpenWin()
        Dim frmShowWarning As SysBasicClass.FormMessageBox = New SysBasicClass.FormMessageBox("-1")
        Dim p As Point = New Point(Screen.PrimaryScreen.WorkingArea.Width - frmShowWarning.Width, Screen.PrimaryScreen.WorkingArea.Height)
        frmShowWarning.PointToScreen(p)
        frmShowWarning.Location = p
        frmShowWarning.Show()
        Dim i As Integer = 0
        For i = 0 To frmShowWarning.Height - 1
            frmShowWarning.Location = New Point(p.X, p.Y - i)
            Threading.Thread.Sleep(10)
        Next
    End Sub

    Private Sub frmMain_Move(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Move
        Me.CloseSearch()
    End Sub

    Private Sub CloseSearch()
        'If m_Search IsNot Nothing Then
        '    m_Search.Close()
        '    m_Search.Dispose()
        '    m_Search = Nothing
        'End If
    End Sub

    Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ' Save Quick Access Toolbar layout if it has changed...
        If ribbonControl1.QatLayoutChanged Then
            Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\DevComponents\Ribbon")
            Try
                key.SetValue("RibbonPadCSLayout", ribbonControl1.QatLayout)
            Finally
                key.Close()
            End Try
        End If
    End Sub

    Private Sub MdiClientControlAddRemove(ByVal sender As Object, ByVal e As ControlEventArgs)
        'If Me.MdiChildren.Length > 0 Then
        '    If Not ribbonTabContext.Visible Then
        '        ribbonTabContext.Visible = True
        '        ribbonControl1.RecalcLayout()
        '    End If
        'Else
        '    If ribbonTabContext.Visible Then
        '        If ribbonTabContext.Checked Then
        '            ribbonTabItem1.Checked = True
        '        End If
        '        ribbonTabContext.Visible = False
        '        ribbonControl1.RecalcLayout()
        '    End If
        'End If
    End Sub

#Region "顯示子窗體"

    Private Sub ShowForm(ByVal sender As Object)

        Dim spaceNameStr As String = Convert.ToString(sender.Tag)
        Dim formText As String = Convert.ToString(sender.Text)
        spaceNameStr = spaceNameStr.Trim
        If spaceNameStr.Trim = "" Then Exit Sub
        'If Me.TabMain.Visible = False Then
        '    Me.TabMain.Visible = True
        'End If
        Dim ShowChildForm, newMDIChild As Form        ''Dim FormInstr As Integer
        Dim FormString, FormSpaceString As String, FormInstr As Integer ''Dim FormSpaceString As String '' Dim newMDIChild As Form
        newMDIChild = Nothing
        FormInstr = InStr(spaceNameStr, ".") : FormString = spaceNameStr.Substring(FormInstr) : FormSpaceString = spaceNameStr.Substring(0, FormInstr - 1)

        For Each ShowChildForm In Me.MdiChildren ''如果該子窗體已打開則獲得焦點,成為當前活動窗體
            If ShowChildForm.GetType.Name = FormString Then
                ShowChildForm.Focus()
                Exit Sub
            End If
        Next
        'System.Windows.Forms.Application.EnableVisualStyles()
        Try
            newMDIChild = CType(Activator.CreateInstance(Type.GetType(spaceNameStr & "," & FormSpaceString)), Form) ''客戶端呼叫實例
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        newMDIChild.MdiParent = Me

        'add by song
        '传送主窗口句柄到子窗口标题暂存
        If newMDIChild.Text = "用戶信息管理" Or newMDIChild.Text = "前台模块设置" Then
            newMDIChild.Text = newMDIChild.Text & ":" & Me.Handle.ToString()
        End If

        newMDIChild.Show()
        newMDIChild.WindowState = FormWindowState.Maximized
        newMDIChild.Text = formText
        SaveAppUseInfo(spaceNameStr, formText)
        'newMDIChild.Update()
        'newMDIChild.Activate()

    End Sub

#End Region

    Private Sub ButExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButExit.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub ButCla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButCla.Click

        Process.Start("calc.exe")

    End Sub

    Private Sub ButTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButTxt.Click

        Process.Start("notepad.exe")

    End Sub

    Private Function CheckUseRight(ByVal RightId As String) As Boolean

        Dim UseBool As Boolean = False
        If RightId = "" Then Return False
        Dim strSQL As String = "select userid from dbo.m_UserRight_t a join m_logtree_t b on a.tkey=b.tkey where b.TreeTag='" & RightId & "' and userid= '" & SysMessageClass.UseId & "' and b.usey='Y'"
        If DbOperateUtils.GetRowsCount(strSQL) > 0 Then
            UseBool = True
        Else
            UseBool = False
        End If
        Return UseBool
    End Function

    Private Sub ButtonItem131_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem131.Click
        Try
            If CheckUseRight(sender.Tag.ToString) = False Then Exit Sub
            Dim frmRunCard As Form = CType(Activator.CreateInstance(Type.GetType("RCard.FrmRunCard,RCard")), Form) ''客戶端呼叫實例
            frmRunCard.Show()
            SaveAppUseInfo("RCard.FrmRunCard", sender.Text)
            frmRunCard.WindowState = FormWindowState.Maximized
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub ButtonItem133_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem133.Click
        Try
            If CheckUseRight(sender.Tag.ToString) = False Then Exit Sub
            Dim frmLotScan As Form = CType(Activator.CreateInstance(Type.GetType("RCard.FrmLotScan,RCard")), Form) ''客戶端呼叫實例
            frmLotScan.Show()
            SaveAppUseInfo("RCard.FrmLotScan", sender.Text)
            frmLotScan.WindowState = FormWindowState.Maximized
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub RibbonBarItemClick_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibBarMouldManagement.ItemClick
        If Not sender.Tag Is Nothing Then
            If (Not GetCheckReleasedVersion(sender.Tag.ToString)) Then
                Exit Sub
            End If
        Else
            Exit Sub
        End If


        'If CheckUseRight(sender.Tag.ToString) = False Then Exit Sub

        '隐藏图片显示 Add By KyLinQiu20170926
        If sender.ToString = "显示功能区" Then
            Me.PanPic.Visible = True
        Else
            Me.PanPic.Visible = False
        End If
        If sender.Tag.ToString <> "RCard.FrmRunCard" AndAlso sender.Tag.ToString <> "RCard.FrmLotScan" AndAlso sender.Tag.ToString <> "RCard.FrmRunCardHSL" Then
            'ShowForm(sender.Tag.ToString)
            ShowForm(sender)
        End If
    End Sub

    Private Shared workStation As String = System.Net.Dns.GetHostName()
    Public Shared Sub SaveAppUseInfo(ByVal fmId As String, ByVal fmName As String)
        Dim sql As String = Nothing
        'Dim sConn As MainFrame.SysDataHandle.SysDataBaseClass = Nothing
        Try
            sql = " IF(SELECT TOP 1 1 FROM M_SYSAPPS_T WHERE APID='" & fmId & "')=1 " & vbNewLine
            sql &= " BEGIN " & vbNewLine
            sql &= " UPDATE M_SYSAPPS_T SET APNAME=N'" & fmName & "',STATUS='Y' WHERE APID='" & fmId & "' " & vbNewLine
            sql &= " END " & vbNewLine
            sql &= " ELSE " & vbNewLine
            sql &= " BEGIN " & vbNewLine
            sql &= " INSERT INTO M_SYSAPPS_T(APID,APNAME,CREATETIME,STATUS) VALUES('" & fmId & "',N'" & fmName & "',GETDATE(),'Y') " & vbNewLine
            sql &= "  END " & vbNewLine
            sql &= "INSERT INTO M_APPSERVICECONDITION_T(APID,APNAME,USETIME,USERID,WORKSTATION)" & vbNewLine
            sql &= " VALUES(N'" & fmId & "',N'" & fmName & "',GETDATE(),'" & IIf(String.IsNullOrEmpty(VbCommClass.VbCommClass.UseId), workStation, VbCommClass.VbCommClass.UseId) & "',N'" & workStation & "')"
            'sConn = New MainFrame.SysDataHandle.SysDataBaseClass
            DbOperateUtils.ExecSQL(sql)
        Catch ex As Exception
        Finally
            'If Not sConn Is Nothing Then
            '    sConn = Nothing
            'End If
        End Try
    End Sub

    Private Function GetCheckReleasedVersion(ByVal strProgramFileName As String) As Boolean
        Dim rtValue As Boolean = False

        If (VbCommClass.VbCommClass.CheckProgramFileVersion = "N" Or String.IsNullOrEmpty(strProgramFileName)) Then
            rtValue = True
            Return rtValue
            Exit Function
        End If

        Dim strPath As String = Application.StartupPath() + "\" + strProgramFileName.Split(".")(0) + ".dll"
        Dim strFileVersion As String
        'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        'Dim Dreader As SqlDataReader
        Dim strSQL As String
        Try
            strFileVersion = FileVersionInfo.GetVersionInfo(strPath).ProductVersion.ToString()
            strSQL = "SELECT Fileno FROM M_Systemfile_t WHERE ReleasedVersionId='" & VbCommClass.VbCommClass.ClientVersionId & "' AND [Filename]='" & strProgramFileName & "' AND ProgramVersion='" & strFileVersion & "' AND Usey='Y' "
            'Dreader = Conn.GetDataReader(strSQL)

            If DbOperateUtils.GetRowsCount(strSQL) > 0 Then
                rtValue = True
            Else
                MessageBox.Show("版本与服务器版本不符,请关闭系统升级!")
                rtValue = False
            End If

            'Dreader.Close()
            'Conn.PubConnection.Close()
        Catch ex As Exception
            'If (Not Dreader Is Nothing And Not Dreader.IsClosed) Then
            '    Dreader.Close()
            'End If

            'If (Conn.PubConnection.State = ConnectionState.Open) Then
            '    Conn.PubConnection.Close()
            'End If
            MessageBox.Show("检查程序版本信息异常!")
            rtValue = False
        End Try
        Return rtValue
    End Function

    'add by song
    '2015-01-28
    '重载消息处理
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    'Dim Str As String
    '    If m.Msg = &HF Then
    '        If m.WParam = 100 Then
    '            loadmodule()
    '            Exit Sub
    '        End If
    '    End If
    '    MyBase.WndProc(m)
    'End Sub


    'add by song
    '2016-01-19
    '装载模块
    Public Sub loadmodule()
        Dim i As Integer = 0
        Dim dt1(RibbonBar1.Items.Count - 1) As ButtonItem
        Dim dt2(RibbonBar2.Items.Count - 1) As ButtonItem
        Dim dt3(RibbonBar3.Items.Count - 1) As ButtonItem
        Dim dt4(RibbonBar4.Items.Count - 1) As ButtonItem
        Dim dt5(RibbonBar5.Items.Count - 1) As ButtonItem
        Dim dt8(RibbonBar8.Items.Count - 1) As ButtonItem
        Dim dt9(RibbonBar9.Items.Count - 1) As ButtonItem
        Dim dt10(RibbonBar10.Items.Count - 1) As ButtonItem
        Dim dt11(RibbonBar11.Items.Count - 1) As ButtonItem
        Dim dt12(RibbonBar12.Items.Count - 1) As ButtonItem
        Dim dt13(RibbonBar13.Items.Count - 1) As ButtonItem
        Dim dt14(RibbonBar14.Items.Count - 1) As ButtonItem

        Dim dtDataHistoryList(Me.RibbonBarDataHistoryList.Items.Count - 1) As ButtonItem
        Dim dt15(RibbonBarS.Items.Count - 1) As ButtonItem

        Dim dt As DataTable
        Dim dt_right As DataTable

        dt = DbOperateUtils.GetDataTable("select MName,Img from m_Logtree_img_t where MName is not null and Img is not null")
        dt_right = DbOperateUtils.GetDataTable("select distinct b.TreeTag as MName from dbo.m_UserRight_t a join m_logtree_t b on a.tkey=b.tkey  where b.usey='Y' and userid= '" & SysMessageClass.UseId & "'")


        'For i = 0 To RibbonBar1.Items.Count - 1
        '    If Not Me.RibbonBar1.Items(i).Name = "TPort" Then
        '        dt1(i) = Me.RibbonBar1.Items(i)
        '        Me.RibbonBar1.Items(i).Visible = True
        '        If SetUserRight(dt_right, Me.RibbonBar1.Items(i).Tag) = False Then
        '            Me.RibbonBar1.Items(i).Visible = False
        '        End If
        '        If Not Load_Img_Data(dt, Me.RibbonBar1.Items(i).Tag) Is Nothing Then
        '            dt1(i).Image = Load_Img_Data(dt, Me.RibbonBar1.Items(i).Tag)
        '        End If
        '    End If
        'Next

        'For i = 0 To RibbonBar2.Items.Count - 1
        '    dt2(i) = Me.RibbonBar2.Items(i)
        '    Me.RibbonBar2.Items(i).Visible = True
        '    If SetUserRight(dt_right, Me.RibbonBar2.Items(i).Tag) = False Then
        '        Me.RibbonBar2.Items(i).Visible = False
        '    End If
        '    If Not Load_Img_Data(dt, Me.RibbonBar2.Items(i).Tag) Is Nothing Then
        '        dt2(i).Image = Load_Img_Data(dt, Me.RibbonBar2.Items(i).Tag)
        '    End If
        'Next

        'For i = 0 To RibbonBar3.Items.Count - 1
        '    dt3(i) = Me.RibbonBar3.Items(i)
        '    Me.RibbonBar3.Items(i).Visible = True
        '    If SetUserRight(dt_right, Me.RibbonBar3.Items(i).Tag) = False Then
        '        Me.RibbonBar3.Items(i).Visible = False
        '    End If
        '    If Not Load_Img_Data(dt, Me.RibbonBar3.Items(i).Tag) Is Nothing Then
        '        dt3(i).Image = Load_Img_Data(dt, Me.RibbonBar3.Items(i).Tag)
        '    End If
        'Next

        'For i = 0 To RibbonBar4.Items.Count - 1
        '    dt4(i) = Me.RibbonBar4.Items(i)
        '    Me.RibbonBar4.Items(i).Visible = True
        '    If SetUserRight(dt_right, Me.RibbonBar4.Items(i).Tag) = False Then
        '        Me.RibbonBar4.Items(i).Visible = False
        '    End If
        '    If Not Load_Img_Data(dt, Me.RibbonBar4.Items(i).Tag) Is Nothing Then
        '        dt4(i).Image = Load_Img_Data(dt, Me.RibbonBar4.Items(i).Tag)
        '    End If
        'Next

        'For i = 0 To RibbonBar5.Items.Count - 1
        '    dt5(i) = Me.RibbonBar5.Items(i)
        '    Me.RibbonBar5.Items(i).Visible = True
        '    If SetUserRight(dt_right, Me.RibbonBar5.Items(i).Tag) = False Then
        '        Me.RibbonBar5.Items(i).Visible = False
        '    End If
        '    If Not Load_Img_Data(dt, Me.RibbonBar5.Items(i).Tag) Is Nothing Then
        '        dt5(i).Image = Load_Img_Data(dt, Me.RibbonBar5.Items(i).Tag)
        '    End If
        'Next

        'For i = 0 To RibbonBar8.Items.Count - 1
        '    dt8(i) = Me.RibbonBar8.Items(i)
        '    Me.RibbonBar8.Items(i).Visible = True
        '    If SetUserRight(dt_right, Me.RibbonBar8.Items(i).Tag) = False Then
        '        Me.RibbonBar8.Items(i).Visible = False
        '    End If
        '    If Not Load_Img_Data(dt, Me.RibbonBar8.Items(i).Tag) Is Nothing Then
        '        dt8(i).Image = Load_Img_Data(dt, Me.RibbonBar8.Items(i).Tag)
        '    End If
        'Next

        'For i = 0 To RibbonBar9.Items.Count - 1
        '    If Not Me.RibbonBar9.Items(i).Name = "ComboBoxItem1" Then
        '        dt9(i) = Me.RibbonBar9.Items(i)
        '        Me.RibbonBar9.Items(i).Visible = True
        '        If SetUserRight(dt_right, Me.RibbonBar9.Items(i).Tag) = False Then
        '            Me.RibbonBar9.Items(i).Visible = False
        '        End If
        '        If Not Load_Img_Data(dt, Me.RibbonBar9.Items(i).Tag) Is Nothing Then
        '            dt9(i).Image = Load_Img_Data(dt, Me.RibbonBar9.Items(i).Tag)
        '        End If
        '    End If
        'Next

        'For i = 0 To RibbonBar10.Items.Count - 1
        '    dt10(i) = Me.RibbonBar10.Items(i)
        '    Me.RibbonBar10.Items(i).Visible = True
        '    If SetUserRight(dt_right, Me.RibbonBar10.Items(i).Tag) = False Then
        '        Me.RibbonBar10.Items(i).Visible = False
        '    End If
        '    If Not Load_Img_Data(dt, Me.RibbonBar10.Items(i).Tag) Is Nothing Then
        '        dt10(i).Image = Load_Img_Data(dt, Me.RibbonBar10.Items(i).Tag)
        '    End If
        'Next

        'For i = 0 To RibbonBar11.Items.Count - 1
        '    dt11(i) = Me.RibbonBar11.Items(i)
        '    Me.RibbonBar11.Items(i).Visible = True
        '    If SetUserRight(dt_right, Me.RibbonBar11.Items(i).Tag) = False Then
        '        Me.RibbonBar11.Items(i).Visible = False
        '    End If
        '    If Not Load_Img_Data(dt, Me.RibbonBar11.Items(i).Tag) Is Nothing Then
        '        dt11(i).Image = Load_Img_Data(dt, Me.RibbonBar11.Items(i).Tag)
        '    End If
        'Next

        'For i = 0 To RibbonBar12.Items.Count - 1
        '    dt12(i) = Me.RibbonBar12.Items(i)
        '    Me.RibbonBar12.Items(i).Visible = True
        '    If SetUserRight(dt_right, Me.RibbonBar12.Items(i).Tag) = False Then
        '        Me.RibbonBar12.Items(i).Visible = False
        '    End If
        '    If Not Load_Img_Data(dt, Me.RibbonBar12.Items(i).Tag) Is Nothing Then
        '        dt12(i).Image = Load_Img_Data(dt, Me.RibbonBar12.Items(i).Tag)
        '    End If
        'Next

        'For i = 0 To RibbonBar13.Items.Count - 1
        '    dt13(i) = Me.RibbonBar13.Items(i)
        '    Me.RibbonBar13.Items(i).Visible = True
        '    If SetUserRight(dt_right, Me.RibbonBar13.Items(i).Tag) = False Then
        '        Me.RibbonBar13.Items(i).Visible = False
        '    End If
        '    If Not Load_Img_Data(dt, Me.RibbonBar13.Items(i).Tag) Is Nothing Then
        '        dt13(i).Image = Load_Img_Data(dt, Me.RibbonBar13.Items(i).Tag)
        '    End If
        'Next

        'For i = 0 To RibbonBar14.Items.Count - 1
        '    dt14(i) = Me.RibbonBar14.Items(i)
        '    Me.RibbonBar14.Items(i).Visible = True
        '    If SetUserRight(dt_right, Me.RibbonBar14.Items(i).Tag) = False Then
        '        Me.RibbonBar14.Items(i).Visible = False
        '    End If
        '    If Not Load_Img_Data(dt, Me.RibbonBar14.Items(i).Tag) Is Nothing Then
        '        dt14(i).Image = Load_Img_Data(dt, Me.RibbonBar14.Items(i).Tag)
        '    End If
        'Next

        'For i = 0 To Me.RibbonBarDataHistoryList.Items.Count - 1
        '    dtDataHistoryList(i) = Me.RibbonBarDataHistoryList.Items(i)
        '    Me.RibbonBarDataHistoryList.Items(i).Visible = True
        '    If SetUserRight(dt_right, Me.RibbonBarDataHistoryList.Items(i).Tag) = False Then
        '        Me.RibbonBarDataHistoryList.Items(i).Visible = False
        '    End If
        '    If Not Load_Img_Data(dt, Me.RibbonBarDataHistoryList.Items(i).Tag) Is Nothing Then
        '        dtDataHistoryList(i).Image = Load_Img_Data(dt, Me.RibbonBarDataHistoryList.Items(i).Tag)
        '    End If
        'Next

        'For i = 0 To Me.RibbonBarS.Items.Count - 1
        '    dt15(i) = Me.RibbonBarS.Items(i)
        '    Me.RibbonBarS.Items(i).Visible = True
        '    If SetUserRight(dt_right, Me.RibbonBarS.Items(i).Tag) = False Then
        '        Me.RibbonBarS.Items(i).Visible = False
        '    End If
        '    If Not Load_Img_Data(dt, Me.RibbonBarS.Items(i).Tag) Is Nothing Then
        '        dt15(i).Image = Load_Img_Data(dt, Me.RibbonBarS.Items(i).Tag)
        '    End If
        'Next

        'add by 马跃平 2017-12-21 权限逻辑处理
        ribbonControl1.SuspendLayout()
        Dim UserID As String = VbCommClass.VbCommClass.UseId
        'Dim sql As String = "SELECT * FROM m_UserRight_t WHERE UserID='" + UserID + "' "
        'Dim dtRight As DataTable = DbOperateUtils.GetDataTable(sql)
        For Each ItemObj In ribbonControl1.Items '循环一级菜单
            Dim BIObj As RibbonTabItem = ItemObj
            Dim IsVisible As Boolean = False
            Dim BarObj As RibbonBar = BIObj.Panel.Controls(0)   '获一级菜单里的RibbonBar控件
            For Each subItemObj In BarObj.Items '循环二级菜单
                Dim ButtonItemObj As ButtonItem = subItemObj  '获取每个二级菜单
                If SetUserRight(dt_right, ButtonItemObj.Tag) = False Then
                    ButtonItemObj.Visible = False
                Else '如果有一个子菜单的权限就显示父菜单,否则影藏父菜单
                    IsVisible = True
                End If
            Next
            BIObj.Visible = IsVisible
        Next
        ribbonControl1.ResumeLayout(False)
    End Sub

#Region "自定义用户权限 add by 马跃平2017-12-21"
    ''' <summary>
    ''' 自定义用户权限
    ''' add by 马跃平2017-12-21
    ''' </summary>
    ''' <param name="dtRight">权限数据源</param>
    ''' <param name="Tkey">权限编号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsVisibleByUser(ByVal dtRight As DataTable, ByVal Tkey As String)
        Dim yy As Boolean = True
        Try
            Dim count As Integer = dtRight.Select("Tkey='" + Tkey + "'").Length
            If count = 0 Then
                yy = False
            End If
        Catch ex As Exception
        End Try
        Return yy
    End Function
#End Region

    'add by song
    '2015-01-19
    '读取图片信息
    Public Function Load_Img_Data(ByVal dt As DataTable, ByVal MName As String) As Image
        Try
            Dim dr() As DataRow

            dr = dt.Select("MName='" & MName & "'")
            If dr.Length > 0 Then
                Dim ms As New IO.MemoryStream(dr(0)(1), True)
                Dim img1 = Image.FromStream(ms, True)
                Return img1
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
            Throw ex
        End Try
    End Function

    'add by song
    '2015-01-19
    '设置菜单是否可用
    Public Function SetUserRight(ByVal dt_right As DataTable, ByVal MName As String) As Boolean
        Try
            Dim dr() As DataRow

            dr = dt_right.Select("MName='" & MName & "'")
            If dr.Length > 0 Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Return False
            Throw ex
        End Try
    End Function

    Private Sub ShowForm1(a As String, b As String)

        Dim spaceNameStr As String = Convert.ToString(a)
        Dim formText As String = Convert.ToString(b)
        spaceNameStr = spaceNameStr.Trim
        If spaceNameStr.Trim = "" Then Exit Sub
        'If Me.TabMain.Visible = False Then
        '    Me.TabMain.Visible = True
        'End If
        Dim ShowChildForm, newMDIChild As Form        ''Dim FormInstr As Integer
        Dim FormString, FormSpaceString As String, FormInstr As Integer ''Dim FormSpaceString As String '' Dim newMDIChild As Form
        newMDIChild = Nothing
        FormInstr = InStr(spaceNameStr, ".") : FormString = spaceNameStr.Substring(FormInstr) : FormSpaceString = spaceNameStr.Substring(0, FormInstr - 1)

        For Each ShowChildForm In Me.MdiChildren ''如果該子窗體已打開則獲得焦點,成為當前活動窗體
            If ShowChildForm.GetType.Name = FormString Then
                ShowChildForm.Focus()
                Exit Sub
            End If
        Next
        'System.Windows.Forms.Application.EnableVisualStyles()
        Try
            newMDIChild = CType(Activator.CreateInstance(Type.GetType(spaceNameStr & "," & FormSpaceString)), Form) ''客戶端呼叫實例
        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        newMDIChild.MdiParent = Me

        'add by song
        '传送主窗口句柄到子窗口标题暂存
        If newMDIChild.Text = "用戶信息管理" Or newMDIChild.Text = "前台模块设置" Then
            newMDIChild.Text = newMDIChild.Text & ":" & Me.Handle.ToString()
        End If

        newMDIChild.Show()
        newMDIChild.WindowState = FormWindowState.Maximized
        newMDIChild.Text = formText
        SaveAppUseInfo(spaceNameStr, formText)
        'newMDIChild.Update()
        'newMDIChild.Activate()

    End Sub
    '打开指定窗口
    Private Sub Dakai(a As String, b As String)
        If (Not GetCheckReleasedVersion(a)) Then
            Exit Sub
        End If

        If CheckUseRight(b) = False Then Exit Sub

        '隐藏图片显示 Add By KyLinQiu20170926
        Me.PanPic.Visible = False

        If b <> "RCard.FrmRunCard" AndAlso b <> "RCard.FrmLotScan" Then
            'ShowForm(sender.Tag.ToString)

            ShowForm1(b, a)
        End If
    End Sub
    Dim avv As Integer = 0
    Dim b As Point
    Dim c As Point
    Dim d As Point
    Dim f As Point
    Dim g As Point

    Private Sub HelpSOP_Click(sender As Object, e As EventArgs) Handles HelpSOP.Click
        Try
            Dim Help As New HelpSOP(Me.tabStrip1.SelectedTab.Text.ToString)
            Help.ShowDialog()
        Catch ex As Exception
            Dim Help As New HelpSOP("Maximization")
            Help.ShowDialog()
        End Try
    End Sub

    Private Sub HelpSOP_MouseEnter(sender As Object, e As EventArgs) Handles HelpSOP.MouseEnter
        Dim X As Integer = HelpSOP.Location.X
        Dim Y As Integer = HelpSOP.Location.Y
        Me.HelpSOP.Location = New System.Drawing.Point(X - 24, Y)
    End Sub

    Private Sub HelpSOP_MouseLeave(sender As Object, e As EventArgs) Handles HelpSOP.MouseLeave
        Dim X As Integer = HelpSOP.Location.X
        Dim Y As Integer = HelpSOP.Location.Y
        Me.HelpSOP.Location = New System.Drawing.Point(X + 24, Y)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SetCurDutyUser()
    End Sub

#Region "流程卡-高速线"
    ''' <summary>
    ''' 流程卡-高速线
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnItemHighSpeedLine_Click(sender As Object, e As EventArgs) Handles BtnItemHighSpeedLine.Click
        Try
            Dim FrmRunCardHSL As Form = CType(Activator.CreateInstance(Type.GetType("RCard.FrmRunCardHSL,RCard")), Form)
            FrmRunCardHSL.Show()
        Catch ex As Exception
            MessageUtils.ShowError("打开异常:" & vbCrLf & "" + ex.Message)
        End Try

    End Sub
#End Region



#Region "显示功能区 界面显示"
    '王南刚 点击按钮打开对应窗体
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Try
            Dim sql = "select top 6 apid,APNAME  from M_APPSERVICECONDITION_T where USERID ='" & VbCommClass.VbCommClass.UseId & "' group by apid,APNAME order by Max(usetime) desc "
            Dim h As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql)
            Dim a As PictureBox = CType(sender, PictureBox)
            For index = 1 To 6
                If a.Name = "PictureBox" + index.ToString Or a.Name = "PictureBoxA" + index.ToString Then
                    Dakai(h.Rows(index - 1)(1), h.Rows(index - 1)(0))
                    Return
                End If
            Next
        Catch ex As Exception
            Dim a As PictureBox = CType(sender, PictureBox)
            If a.Name = "PictureBox1" Or a.Name = "PictureBoxA1" Then
                Dakai("联系我们", "BasicManagement.FrmContact")
            ElseIf a.Name = "PictureBox2" Or a.Name = "PictureBoxA2" Then
                Dakai("包装记录查询", "BasicFindReport.FrmPackQuery")
            ElseIf a.Name = "PictureBox3" Or a.Name = "PictureBoxA3" Then
                Dakai("条码打印记录", "BasicFindReport.FrmPrintQuery")
            ElseIf a.Name = "PictureBox4" Or a.Name = "PictureBoxA4" Then
                Dakai("成品扫描记录", "BasicFindReport.FrmScanQuery")
            ElseIf a.Name = "PictureBox5" Or a.Name = "PictureBoxA5" Then
                Dakai("不良条码记录", "BarCodePrint.FrmReprintQuery")
            ElseIf a.Name = "PictureBox6" Or a.Name = "PictureBoxA6" Then
                Dakai("修改密码", "MESUserManage.FrmPasswordch")
            End If
        End Try
    End Sub
    '王南刚 获取程序图标显示在界面
    Public Sub Trans(a As String, z As String)
        For Each item As BaseItem In ribbonControl1.Items
            Dim ribbonTab As RibbonTabItem = TryCast(item, RibbonTabItem)
            If ribbonTab IsNot Nothing Then
                Dim panel As RibbonPanel = ribbonTab.Panel
                For Each PanelControl As Control In panel.Controls
                    Dim ribbonBar As RibbonBar = TryCast(PanelControl, RibbonBar)
                    If ribbonBar IsNot Nothing Then
                        For Each ribbonBarItem As ButtonItem In ribbonBar.Items
                            If Not ribbonBarItem.Tag Is Nothing Then
                                If ribbonBarItem.Tag.ToString = a Then
                                    'For Each pict As Control In GroupBox1.Controls
                                    '    If TypeName(pict) = "PictureBox" Then
                                    '        If CType(pict, PictureBox).Tag = z Then
                                    '            CType(pict, PictureBox).BackgroundImage = ribbonBarItem.Image
                                    '        End If
                                    '    End If
                                    'Next
                                End If
                            End If

                        Next
                    End If
                Next
            End If
        Next
    End Sub
    '王南刚 显示图片信息
    Private Sub ButShow_Click(sender As Object, e As EventArgs) Handles ButShow.Click
        'Dim jishu As Integer = 0
        'Try
        '    Dim sql = " select top 6 apid,APNAME  from M_APPSERVICECONDITION_T where USERID ='" & VbCommClass.VbCommClass.UseId & "' group by apid,APNAME order by Max(usetime) desc "
        '    Dim h As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql)
        '    For Each btton As Control In GroupBox1.Controls
        '        If TypeName(btton) = "Button" Then
        '            CType(btton, Button).Text = "            " + h.Rows(Convert.ToInt16(CType(btton, Button).Tag))(1).ToString()
        '            Trans(h.Rows(Convert.ToInt16(CType(btton, Button).Tag))(0).ToString(), Convert.ToInt16(CType(btton, Button).Tag) + 1)
        '            jishu = jishu + 1
        '        End If
        '    Next
        'Catch
        '    Select Case jishu
        '        Case 0 : used1.Text = "联系我们"
        '        Case 1 : used2.Text = "包装记录查询"
        '        Case 2 : used3.Text = "条码打印记录"
        '        Case 3 : used5.Text = "成品扫描记录"
        '        Case 4 : used4.Text = "不良条码记录"
        '        Case 5 : used6.Text = "修改密码"
        '    End Select
        'End Try
        ShowUse()
        Me.PanPic.Visible = True
    End Sub
    ''' <summary>
    ''' 功能区界面显示 
    ''' </summary>
    ''' <remarks>关晓艳 2018/7/22</remarks>
    Private Sub ShowUse()
        Dim jishu As Integer = 0
        Try
            Dim sql As String = "select a.APID,a.APNAME,isnull(b.ImageName,'')ImageName from M_APPSERVICECONDITION_T a left join m_Logtree_t b on b.TreeTag=a.APID and  isnull(a.Tkey,b.Tkey)=b.Tkey where a.USERID ='" & VbCommClass.VbCommClass.UseId & "' and b.Usey='Y'  group by apid,APNAME,b.ImageName order by Max(usetime) desc "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
            'MetroTileItem1.Text = dt.Rows(0)(1).ToString
            'MetroTileItem2.Text = dt.Rows(1)(1).ToString
            'MetroTileItem3.Text = dt.Rows(2)(1).ToString
            'MetroTileItem4.Text = dt.Rows(3)(1).ToString
            'MetroTileItem5.Text = dt.Rows(4)(1).ToString
            'MetroTileItem6.Text = dt.Rows(5)(1).ToString
            If dt.Rows.Count > 0 Then
                MetroTileItem1.Text = dt.Rows(0)(1).ToString
                Dim ImageName = dt.Rows(0)("ImageName").ToString().Trim()
                Dim ImageObj = ""
                If String.IsNullOrEmpty(ImageName) = False Then
                    If ImageName.IndexOf(".") > 0 Then
                        ImageObj = ImageName.Substring(0, ImageName.IndexOf("."))
                    End If
                End If
                Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageObj)
                If Not obj Is Nothing Then
                    MetroTileItem1.Image = CType(obj, Image)
                Else
                    MetroTileItem1.Image = Nothing
                End If
            End If
            If dt.Rows.Count > 1 Then
                MetroTileItem2.Text = dt.Rows(1)(1).ToString
                Dim ImageName = dt.Rows(1)("ImageName").ToString().Trim()
                Dim ImageObj = ""
                If String.IsNullOrEmpty(ImageName) = False Then
                    If ImageName.IndexOf(".") > 0 Then
                        ImageObj = ImageName.Substring(0, ImageName.IndexOf("."))
                    End If
                End If
                Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageObj)
                If Not obj Is Nothing Then
                    MetroTileItem2.Image = CType(obj, Image)
                Else
                    MetroTileItem2.Image = Nothing
                End If
            End If
            If dt.Rows.Count > 2 Then
                MetroTileItem3.Text = dt.Rows(2)(1).ToString
                Dim ImageName = dt.Rows(2)("ImageName").ToString().Trim()
                Dim ImageObj = ""
                If String.IsNullOrEmpty(ImageName) = False Then
                    If ImageName.IndexOf(".") > 0 Then
                        ImageObj = ImageName.Substring(0, ImageName.IndexOf("."))
                    End If
                End If
                Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageObj)
                If Not obj Is Nothing Then
                    MetroTileItem3.Image = CType(obj, Image)
                Else
                    MetroTileItem3.Image = Nothing
                End If
            End If
            If dt.Rows.Count > 3 Then
                MetroTileItem4.Text = dt.Rows(3)(1).ToString
                Dim ImageName = dt.Rows(3)("ImageName").ToString().Trim()
                Dim ImageObj = ""
                If String.IsNullOrEmpty(ImageName) = False Then
                    If ImageName.IndexOf(".") > 0 Then
                        ImageObj = ImageName.Substring(0, ImageName.IndexOf("."))
                    End If
                End If
                Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageObj)
                If Not obj Is Nothing Then
                    MetroTileItem4.Image = CType(obj, Image)
                Else
                    MetroTileItem4.Image = Nothing
                End If
            End If
            If dt.Rows.Count > 4 Then
                MetroTileItem5.Text = dt.Rows(4)(1).ToString
                Dim ImageName = dt.Rows(4)("ImageName").ToString().Trim()
                Dim ImageObj = ""
                If String.IsNullOrEmpty(ImageName) = False Then
                    If ImageName.IndexOf(".") > 0 Then
                        ImageObj = ImageName.Substring(0, ImageName.IndexOf("."))
                    End If
                End If
                Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageObj)
                If Not obj Is Nothing Then
                    MetroTileItem5.Image = CType(obj, Image)
                Else
                    MetroTileItem5.Image = Nothing
                End If
            End If
            If dt.Rows.Count > 5 Then
                MetroTileItem6.Text = dt.Rows(5)(1).ToString
                Dim ImageName = dt.Rows(5)("ImageName").ToString().Trim()
                Dim ImageObj = ""
                If String.IsNullOrEmpty(ImageName) = False Then
                    If ImageName.IndexOf(".") > 0 Then
                        ImageObj = ImageName.Substring(0, ImageName.IndexOf("."))
                    End If
                End If
                Dim obj = Global.MesSystem.My.Resources.ResourceManager.GetObject(ImageObj)
                If Not obj Is Nothing Then
                    MetroTileItem6.Image = CType(obj, Image)
                Else
                    MetroTileItem6.Image = Nothing
                End If
            End If
        Catch ex As Exception

        End Try

        Try
            Dim strSql As String = "select top 1 title,contents from m_Advert_t where usey='Y' order by intime desc"
            Dim dt1 As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt1.Rows.Count > 0 Then
                RichTextBox1.Text = dt1.Rows(0)("contents").ToString
                GroupPanel1.Text = dt1.Rows(0)("title").ToString
                'GroupPanel1.Visible = True
            Else
                RichTextBox1.Text = ""
                GroupPanel1.Text = "系统公告"
                'GroupPanel1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    'SPC系统一站式登录 关晓艳 2018/07/23
    Private Sub picSPC_Click(sender As Object, e As EventArgs) Handles MetroLink1.Click
        Dim spcURL As String = "http://spc.luxshare-ict.com/Account/Login?loginkey=" & SysBasicClass.DESEncrypt.GetLoginKey(SysMessageClass.UseId)
        System.Diagnostics.Process.Start(spcURL)
    End Sub

    Private Declare Function HideCaret Lib "User32.dll" (ByVal hwnd As Long) As Boolean
    Private Sub RichTextBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles RichTextBox1.MouseDown
        HideCaret(RichTextBox1.Handle)
    End Sub
#End Region

    Private Sub ComboBoxItem1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItem1.SelectedIndexChanged
        Try
            If ComboBoxItem1.SelectedIndex >= 0 Then
                Dim StyleIndex As Integer = ComboBoxItem1.SelectedIndex
                Me.StyleManager1.ManagerStyle = [Enum].Parse((GetType(eStyle)), CType(ComboBoxItem1.SelectedItem, ComboItem).Text)
                Dim sql As String = "update m_Users_t set StyleID='" & StyleIndex.ToString & "' where UserID='" & VbCommClass.VbCommClass.UseId & "' "
                DbOperateUtils.ExecSQL(sql)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroTileItem_Click(sender As Object, e As EventArgs) Handles MetroTileItem1.Click

        Try
            Dim sql = "select top 6 apid,APNAME  from M_APPSERVICECONDITION_T where USERID ='" & VbCommClass.VbCommClass.UseId & "' group by apid,APNAME order by Max(usetime) desc "
            Dim h As DataTable = MainFrame.DbOperateUtils.GetDataTable(sql)
            Dim obj As DevComponents.DotNetBar.Metro.MetroTileItem = CType(sender, DevComponents.DotNetBar.Metro.MetroTileItem)

            For index = 1 To 6
                If obj.Name = "MetroTileItem" + index.ToString Then
                    Dakai(h.Rows(index - 1)(1), h.Rows(index - 1)(0))
                    Return
                End If

            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetMetroTileBgColor()
        Dim i As Integer
        For i = 0 To 8
            Dim r As Random = New Random(Integer.Parse(DateTime.Now.ToString("HHmmssfff")) + i)
            Dim num As Integer = r.Next(1, 23) '随机生成一个5位整数

            Dim tempStr As String = String.Empty
            Dim j As Integer
            For j = 0 To 4
                r = New Random(Integer.Parse(DateTime.Now.ToString("HHmmssfff")) + i + j)
                Dim x As Integer = r.Next(65, 90) '65-90代表A-Z的ASCII值 
                tempStr += x.ToString()
            Next
            ' Str = Str() + "," + num.ToString
            ' num = 0

            Select Case i
                Case 0
                    MetroTileItem1.TileColor = num
                Case 1
                    MetroTileItem2.TileColor = num
                Case 2
                    MetroTileItem3.TileColor = num
                Case 3
                    MetroTileItem4.TileColor = num
                Case 4
                    MetroTileItem5.TileColor = num
                Case 5
                    MetroTileItem6.TileColor = num
            End Select

        Next
    End Sub

    Private Sub ribbonControl1_Click(sender As Object, e As EventArgs) Handles ribbonControl1.Click

    End Sub
End Class


