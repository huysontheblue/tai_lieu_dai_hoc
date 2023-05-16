

SELECT * FROM M_Customer_t


SELECT * FROM M_Mainmo_t WHERE MOID='MAFENG-TEST' PartID='MAFENG-TEST'


SELECT TOP 10 * FROM M_SnSBarCode_t ORDER BY Intime DESC




--DELETE M_SnSBarCode_t WHERE MOID='MAFENG-TEST'
--DELETE M_BARRECORDVALUE_T WHERE barcodeSNID IN ('201','6','5','4','3','2')




SELECT TOP 10 * FROM M_BARRECORDVALUE_T ORDER BY intime DESC

SELECT COUNT(barcodeSNID) FROM M_BARRECORDVALUE_T



SELECT TOP 10 * FROM m_PartPack_t WHERE PARTID='520-MAFENG-TEST'




select distinct a.CodeRuleID,a.Partid as TAvcPart,b.f_codeid,d.F_codename,b.DValues,h.SortName as Usey,
       e.Username,convert(varchar(20),a.Intime,20) as intime,
	   f.Username as ConfirmName,
	   convert(varchar(20),a.Comfrmtime,20) as confirmtime 
from m_PartPack_t as a 
join m_Sortset_t as h on a.Usey=h.SortID --and h.SortType='paramstatus' 
join m_PartContrast_t as c on a.Partid=c.TAvcPart --and c.usey='Y' 
join m_SnPartSet_t as b on a.Partid=b.Partid and a.Packid=b.Packid and a.Packitem=b.Packitem 
join m_snRuleD_t as d on a.CodeRuleID=d.CodeRuleID and b.F_codeid=d.F_codeid 
left join m_Users_t as e on a.Userid=e.Userid 
left join m_Users_t as f on a.Comfrmid=f.Userid 
where a.Partid='520-MAFENG-TEST' and a.coderuleid='B143' and a.usey='Y'




