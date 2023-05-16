create database de_on1
use de_on1

create table tblvattu
(mavattu char(4) primary key,
tenvattu nvarchar(30),
dvtinh nvarchar(10),
donggia int)
create table tbldondh
(sodh int primary key,
ngaydh char(12),
tenhacc nvarchar(40))
create table tblctdondh
(sodh int foreign key references tbldondh,
mavattu char(4) foreign key references tblvattu,
sldat int)

insert into tblvattu values
('vt01',N'sắt',N'tấn',500000),
('vt02',N'thép',N'tấn',600000),
('vt03',N'nhôm',N'tấn',700000),
('vt04',N'đồng',N'tấn',800000)

insert into  tbldondh values
(100,'20/10/2021',N'bỉm sơn'),
(200,'05/09/2021',N'hòa bình'),
(300,'15/11/2021',N'nghi xuân'),
(400,'09/07/2021',N'phi thành')

insert into tblctdondh values
(100,'vt04',200),
(200,'vt01',200),
(300,'vt02',200),
(400,'vt03',200),
(100,'vt04',200),
(400,'vt01',200)

select * from tblctdondh
select * from tbldondh
select * from tblvattu
--1.Viết hàm (hoặc thủ tục) cho mã vật tư tự động theo quy tắc:
-- Mã vật tư có dạng: VT01, ‘VT’ : quy định (luôn có), 01 : là số (VD: Hiện tại Vật tư có mã cao nhất là  VT04, thì sinh mã mới là VT05)
create proc tt1 @mavt char(4) output
as 
begin
declare @max int
Select @max=max(cast(substring(mavattu,3,2) as int))+1 from tblvattu
set @mavt = '0000'+ LTRIM(cast(@max as char(10)))
set @mavt = 'VT' + SUBSTRING(@mavt,LEN(@mavt)-1,2)
end
----loi goi
declare @s_mavt char(4)
exec tt1 @s_mavt output

--2.Sử dụng biến CURSOR cho xem SoDH, TenVtu, Tennhacc, SLdat  của những SoDH có SLDat >=A.
declare @sodh int, @tenvattu nvarchar(30),@tennhacc nvarchar(40), @sldat int
declare cau2 cursor for
  select ctdh.sodh,tenvattu,tenhacc,sldat from tblctdondh ctdh join tbldondh dh on ctdh.sodh=dh.sodh join tblvattu vt on vt.mavattu=ctdh.mavattu
  where sldat>100
open cau2
fetch next from cau2 into @sodh , @tenvattu ,@tennhacc , @sldat
while @@FETCH_STATUS=0
begin
    print N'Số đơn hàng      :'+cast(@sodh as nvarchar(12))
	print N'Tên vật tư       :'+@tenvattu
    print N'Tên nhà cung cấp :'+@tennhacc
	print N'Số lượng đặt     :'+cast(@sldat as nvarchar(12))
	print '-------------------'
	fetch next from cau2 into @sodh , @tenvattu ,@tennhacc , @sldat
end
close cau2
dEALLOCATE cau2
-- 3.Sử dụng thủ tục CURSOR cho xem SoDH, TenVtu, , Tennhacc, SLdat  của những SoDH có SLDat >=A, với A là tham số đầu vào 
create proc cau3
	@sld int, @s_cur cursor varying output
as
set @s_cur=cursor
keyset
for	
	select ctdh.sodh,tenvattu,tenhacc,sldat from tblctdondh ctdh join tbldondh dh on ctdh.sodh=dh.sodh join tblvattu vt on vt.mavattu=ctdh.mavattu
	where sldat>=@sld
    open @s_cur

drop proc tt_cur1
--------loi goi
declare @s_sodh  int,@s_tenvt nvarchar(30)
declare @s_tenncc nvarchar(40),@s_sld int
declare @ss_cur cursor

--4.Sử dụng thủ tục cho xem tổng tiền của một sodh là  A, nếu A không tồn tại có dòng thông báo (thủ tục return)
Create proc cau4 
@sodh int,@tt int output
as
	select @tt = sum(SlDat*donggia) 
	from tblVATTU vt join tblCTdonDH ctdh on ctdh.mavattu=vt.mavattu
	where SoDH=@sodh

----loi goi
declare @ss_tt int
exec cau4 100,@ss_tt output
print @ss_tt

select * from tblctdondh
select * from tbldondh
select * from tblvattu
--5.Viết thủ tục cập nhật trên 1 bảng nào đó: tblCTDonDH với yêu cầu : 
--1. MaVtu không trùng khóa chính, 
--2. SoDH có trong bảng tblDonDH, 
--3. MaVTu có trong bảng tblVatTu, 
--4. A <= SLDat <= B.
alter proc cau5 @SoDH Int, @MaVTu char(4), @SLDat int
as
----kiem tra khoa chính
if exists (select * from tblvattu where mavattu=@MaVTu)
	print N'trung khoa chinh'
-----kiem tra khoa ngoai 1 SoDH
if not exists (select * from tblDonDH where sodh=@SoDH)
	print N'không có khoa ngoại SoDH'
-----kiem tra khoa ngoai 2 Mavtu
if NOT exists (select * from tblVATTU where mavattu=@MaVTu)
	print N'không có khoa ngoại MaVtu'
-----kiem tra mien gia trị
if	NOT ((@SLDat>=100) and (@SLDat<=200))
	print N'loi 100 <= sldat <=200 '
INSERT INTO tblCTdonDH values(@SoDH,@MaVTu,@SLDat)
----lời gọi 1
Exec cau5 51,'vt01',56
----lời gọi 2
Exec cau5 50,'vt01',56
----lời gọi 3
Exec cau5 56,'vt04',56
----lời gọi 4
Exec cau5 55,'vt02',56
----lời gọi 5
Exec cau5 59,'vt02',256
----lời gọi 6
Exec cau5 150,'vt06',156

--6.Thủ tục hiện thị : cho xem SoDH, TenVtu, , Tennhacc, Sldat,  với sodh là  A ; nếu không truyền tham số thì hiện thị toàn bộ
create proc cau6
(@sodh int = null)
as 
begin
    if @sodh is null
	   select ctdh.sodh,tenvattu,tennhacc,sldat from tblctdondh ctdh join tbldondh dh on ctdh.sodh=dh.sodh join tblvattu vt on vt.mavattu=ctdh.mavattu
    else
	   select ctdh.sodh,tenvattu,tenhacc,sldat from tblctdondh ctdh join tbldondh dh on ctdh.sodh=dh.sodh join tblvattu vt on vt.mavattu=ctdh.mavattu
	   where ctdh.sodh=@sodh
end

exec cau6
exec cau6 200

select * from tblctdondh
select * from tbldondh
select * from tblvattu
--7.Hàm: vào SoDH, ra là tổng tiền của SoDH đó
alter function dbo.cau7
(@sodh int)
returns int
as 
begin
   declare @tongtien int = 0
   select @tongtien=sum(sldat*dongia) from tblctdondh ctdh join tblvattu vt on ctdh.mavattu=vt.mavattu
   where sodh=@sodh
   return @tongtien
end

print N'Tổng tiền = ' + str(dbo.cau7(400))

--8.Hàm tạo bảng: cho ra  TenVtu, Tennhacc, Sldat,  của 1 sodh
create function dbo.cau8
(@sodh int)
returns table
as
    return(select ctdh.sodh,tenvattu,tennhacc,sldat 
	from tblctdondh ctdh join tbldondh dh on ctdh.sodh=dh.sodh join tblvattu vt on vt.mavattu=ctdh.mavattu
	where ctdh.sodh=@sodh) 

select * from dbo.cau8 100
-- 9.Hàm tạo bảng: cho ra  TenVtu, Tennhacc, Sldat, dongia, tongtien của 1 sodh
create function dbo.cau9
(@sodh int)
returns table
as
    return(select vt.tenvattu, tennhacc, sldat, dongia, sum(sldat*dongia) from
	tblctdondh ctdh join tbldondh dh on ctdh.sodh=dh.sodh join tblvattu vt on ctdh.mavattu=vt.mavattu
	where @sodh=dh.sodh
	group by tenvattu)

--10.Viết thủ tục cho ra SoDH có tổng tiền thấp nhất (hoặc cao nhất)
create proc tongtien
as
begin
     declare @tongtien int = 0
     select @tongtien=sum(sldat*dongia) from tblctdondh ctdh join tblvattu vt on ctdh.mavattu=vt.mavattu
	 where  
	 select sodh, sum(sldat*dongia) from tblctdondh ctdh join tblvattu vt on ctdh.mavattu=vt.mavattu
end
--11. Hàm tạo bảng: vào là Tên nhà cung cấp, cho ra TenVtu, tổng số lượng đặt, tổng tiền của nhà cung cấp đó. 

select * from tblctdondh
select * from tbldondh
select * from tblvattu

create function dbo.cau11 
(@tennhacc nvarchar(40))
Returns Table
as
       Return (Select tenvattu, sum(SlDat) as tsld,sum(Dongia*SlDat) as tt 
       From tblVATTU vt join tblCTDONDH  ctdh on  ctdh.mavattu = vt.mavattu
       join tblDONDH dh on dh.SoDH= ctdh.SoDH
       Where TenNhaCC=@tennhacc
       group by tenvattu )

Select * from dbo.cau11 (N'bỉm sơn')

