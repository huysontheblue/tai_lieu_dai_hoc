




-- =========================================
-- RCard , 2016/07/01
-- =========================================
insert into [m_logtree_t]
([Treeid],[Tkey],[Tparent],[Ttext],
[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],[Timage],
[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey],
[ReportUsey]) values ('R9062','R9062_','m17_', N'配套扫描查询','FrmSetScanQuery',
null,'RCard.FrmSetScanQuery','mes00','apmr9062',
null,1,1,1,1,'N',null,'Y','Y',null)

GO
-- =========================================
-- RCard , 2016/06/08
-- =========================================

insert into [m_logtree_t]
([Treeid],[Tkey],[Tparent],[Ttext],
[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],[Timage],
[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey],
[ReportUsey]) values ('R9061','R9061_','m17_', N'配套扫描','FrmSetScan',
null,'RCard.FrmSetScan','mes00','apmr9061',
null,1,1,1,1,'N',null,'Y','Y',null)

GO


-- =========================================
-- RCard V1.0.0.3 , 2016/03/24
-- =========================================

-- step1:
-- alter table m_RCardProParam_t add ID int identity(1,1);  

-- step2, 需要考虑多个厂区,利润中心
delete 
from m_RCardProParam_t
where (tvpn+wirepn+ isnull(wirepn2,'')+ isnull(wirepn3,'')+ isnull(wirepn4,'')) in (select (tvpn+wirepn+ isnull(wirepn2,'')+ isnull(wirepn3,'')+ isnull(wirepn4,'')) from 
m_RCardProParam_t group by (tvpn+wirepn+ isnull(wirepn2,'')+ isnull(wirepn3,'')+ isnull(wirepn4,''))  having 
count((tvpn+wirepn+ isnull(wirepn2,'')+ isnull(wirepn3,'')+ isnull(wirepn4,''))) > 1)
and id not in (select min(id) from 
m_RCardProParam_t group by (tvpn+wirepn+ isnull(wirepn2,'')+ isnull(wirepn3,'')+ isnull(wirepn4,'')) 
having count((tvpn+wirepn+ isnull(wirepn2,'')+ isnull(wirepn3,'')+ isnull(wirepn4,'')) )>1)

-- alter table m_RCardProParam_t drop column ID  

UPDATE m_Rstation_t
SET SECTIONID = '0'+SECTIONID
WHERE STATIONTYPE ='R'
AND LEN(SECTIONID) =1


-- =========================================
-- RCard V1.0.0.3 , 2015/12/00
-- =========================================


-- MESDB
Alter table m_RStation_t
 alter column SectionID varchar(8);

 -- 1. 删除主键：
Declare @Pk varChar(100);
Select @Pk=Name from sysobjects where Parent_Obj=OBJECT_ID('m_RstationSection_t') and xtype='PK';
if @Pk is not null
begin
     exec('Alter table m_RstationSection_t Drop '+ @Pk)  --删除原主键
 end
 
--2.把所有主键设为不能为空
alter table m_RstationSection_t alter column ID varchar(8) not null
  
--3.重建主键：
ALTER Table m_RstationSection_t ADD CONSTRAINT pk_m_RstationSection_t  PRIMARY KEY (ID )


-- =========================================
-- RCard V1.0.0.2 , 2015/11/18
-- =========================================
-- MESDB 
ALTER TABLE m_RCardD_t
ADD FinishSize real

ALTER TABLE m_RCardDOldVer_t
ADD FinishSize real

-- 审核权限
select * from m_UserRight_t
where Tkey  ='m0214k_'