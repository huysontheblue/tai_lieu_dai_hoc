





-- =========================================
-- KanBan V1.0.0.0 , 2015/12/25
-- =========================================
-- MESDB 

-- 工单进度查询
m_KanBanQueryMOSch_p
m_QueryMOSchDetail_p

-- 区分是否维修过
CREATE TABLE [dbo].[m_BarCodeRepaired_t](
	[SBarCode] [varchar](150) NOT NULL,
	[Moid] [varchar](64) NULL,
	[UserID] [varchar](20) NULL,
	[Intime] [datetime] NULL,
 CONSTRAINT [PK_m_BarCodeRepaired_t] PRIMARY KEY CLUSTERED 
(
	[SBarCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- =========================================
-- KanBan V1.0.0.0 , 2015/07/13
-- =========================================
-- MESDB 

CREATE TABLE [dbo].[m_Series_t](
 [SeriesID] [varchar](10) NOT NULL,
 [SeriesName] [nvarchar](50) NULL,
 [Usey] [char](1) NULL,
 CONSTRAINT [PK_m_Series_t] PRIMARY KEY CLUSTERED 
(
 [SeriesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

ALTER TABLE m_Mainmo_t ADD [SeriesID] [varchar](10)  NULL,
 DeliveryDate datetime  null,
 ScheFinishDate datetime null;                     

ALTER TABLE m_PartContrast_t ADD [SeriesID] [varchar](10)  NULL;

alter table M_MainMO_t
add Status varchar(1) not null default 0

Create table m_MOProductTime_t
( MOid varchar(64) not null,
  Lineid  varchar(10) not null,
  StartTime datetime not null,
  StartReason  nvarchar(30) not null,
  StartUser varchar(8) not null,
  EndTime  datetime,
  EndReason nvarchar(30),
  EndUser varchar(8)
  )

Create table m_MoProductDetail
(
  Moid varchar(64) not null,
  Lineid  varchar(10) not null,
  WorkShift int not null,
  Type  numeric(1) not null,
  OutQty int ,
  NGQty int ,
  ProductTime datetime,
  ChangedHours numeric(4,2) ,
  ChangedReason nvarchar(600),
  Status  varchar(1),
  RelatedDeptid  varchar(10),
  UserID  varchar(8),
  CreateTime datetime not null,
  UpdatedTime datetime ,
  AuditUserID varchar(8),
  AuditTime datetime
)

Create table deptlineD_t
(
deptid varchar(10) not null,
lineid varchar(10) not null,
leaderid varchar(8) not null,
lineman numeric(4,0),
usey varchar(1),
userid varchar(8),
Intime datetime
)


-- 
insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],[Enname],
[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],[Timage],[Tsimage],[TADimage],
[TADsimage],[TADUsey],[TADid],[listy],[Usey]) 
values ('190','m19_','m0_',N'看板','KanBan',null,null,'mes00','m01','1',1,1,1,1,'N',null,'Y','Y')
GO

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],[Timage],[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey]) 
values ('m19001','m1901','m19_',N'生产工时维护','FrmSetMO',null,'KanBan.FrmSetMO','mes00','apm19001',null,1,1,1,1,'N',null,'Y','Y')

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],[Timage],
[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey]) 
values ('m19002','m1902','m19_',N'工单生产班别资料维护','FrmPartTime',null,'KanBan.FrmPartTime','mes00','apm19002',null,1,1,1,1,'N',null,'Y','Y')

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],[Timage],
[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey]) 
values ('m19003','m1903','m19_',N'生產看板','FrmKanBan',null,'KanBan.FrmKanBan','mes00','apm19003',null,1,1,1,1,'N',null,'Y','Y')

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],[Timage],
[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey]) 
values ('m19004','m1904','m19_',N'线别线长资料维护','FrmLineLeader',null,'KanBan.FrmLineLeader','mes00','apm19004',null,1,1,1,1,'N',null,'Y','Y')

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],[Timage],
[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey]) 
values ('m19005','m1905','m19_',N'无条码产品包装','FrmNoBarCodePack',null,'BarCodeScan.FrmNoBarCodePack','mes00','apm19005',null,1,1,1,1,'N',null,'Y','Y')

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],[Timage],
[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey]) 
values ('m19006','m1906','m19_',N'生产状况报表','FrmProductInfoQuery',null,
'BasicFind.FrmProductInfoQuery','mes00','apm19006',null,1,1,1,1,'N',null,'Y','Y')

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],[Timage],
[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey]) 
values ('m19008','m1908','m19_',N'工单生产进度查询','FrmMOSchQuery',null,
'KanBan.FrmMOSchQuery','mes00','apm19008',null,1,1,1,1,'N',null,'Y','Y');

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],
[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],[Timage],
[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey]) 
values ('m19009','m1909','m19_',N'订单生产进度查询','FrmOrderSchQuery',null,'KanBan.FrmOrderSchQuery',
'mes00','apm19009',null,1,1,1,1,'N',null,'Y','Y')

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],
[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],[Timage],
[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey]) 
values ('m19011','m1911','m19_',N'看板帮助','FrmKBHelp',null,'KanBan.FrmKBHelp',
'mes00','apm19011',null,1,1,1,1,'N',null,'Y','Y')

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],
[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],[Timage],
[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey]) 
values ('m19012','m1912','m19_',N'不良分析柏拉图','FrmParetoSet',null,'KanBan.FrmParetoSet',
'mes00','apm19012',null,1,1,1,1,'N',null,'Y','Y')

GO


