




-- =========================================
-- SampleManage , 2016/10/12
-- =========================================
insert into [m_Users_t]([UserID],[UserName],[PassWord],[Descript],
[Dept],[Team],[Jobs],[GroupID],[UserGrade],[FactoryID],[Usey],[AutoID],[OMd],[Creater],
[Intime],[lineid],[FingerMask],[Verifytype],[ShowAdv],[AdvId],[advtime]) 
values ('L031745',N'鲁红兵','111','','A31161','','研發人員',
'IPQC',null,'LX21','1','',null,'C045428','2014-07-08 10:15:01',null,null,null,0,null,null)
GO

create table m_SampleDept_t
(
DutyDept  nvarchar(50)
)

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],
[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],
[Timage],[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey],[ReportUsey]) 
values ('m21001','m2101','m21_',N'责任人维护','FrmPIC',null,'SampleManage.FrmPIC',
'mes00','apm21001',null,1,1,1,1,'N',null,'Y','Y',null)

GO


insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],
[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],
[Timage],[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey],[ReportUsey]) 
values ('m21002','m2102','m21_',N'样品申请单资料','FrmSampleReqNo',null,'SampleManage.FrmSampleReqNo',
'mes00','apm21002',null,1,1,1,1,'N',null,'Y','Y',null)

GO

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],
[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],
[Timage],[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey],[ReportUsey]) 
values ('m21003','m2103','m21_',N'样品资料上传','FrmSampleUpload',null,'SampleManage.FrmSampleUpload',
'mes00','apm21003',null,1,1,1,1,'N',null,'Y','Y',null)

GO

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],
[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],
[Timage],[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey],[ReportUsey]) 
values ('m21004','m2104','m21_',N'样品单明细','FrmSample',null,'SampleManage.FrmSample',
'mes00','apm21004',null,1,1,1,1,'N',null,'Y','Y',null)

GO

insert into [m_logtree_t]([Treeid],[Tkey],[Tparent],[Ttext],
[Enname],[Remark],[TreeTag],[Rightid],[Formid],[ButtonID],
[Timage],[Tsimage],[TADimage],[TADsimage],[TADUsey],[TADid],[listy],[Usey],[ReportUsey]) 
values ('m21005','m2105','m21_',N'样品扫描','FrmSampleScan',null,'SampleManage.FrmSampleScan',
'mes00','apm21005',null,1,1,1,1,'N',null,'Y','Y',null)

GO






