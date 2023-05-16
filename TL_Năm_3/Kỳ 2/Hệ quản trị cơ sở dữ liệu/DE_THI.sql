create database QLDT_CB
use QLDT_CB
select * from tblkhoa
select * from tbldetai
select * from tblcanbo
--cau2 
-- sử dụng thủ tục cập nhật cho bảng đề tài tbldetai với yêu cầu kiểm tra khóa chính mã đề tài
--(madt), và khóa ngọa mã cán bộ (macb) phải có trong tblcanbo
alter proc capnhat
@madt char(4),
@macb char(4) ,
@tendt nvarchar(50),
@kp int
as  
begin
	 if not exists (select * from tbldetai where madt=@madt)
	    print N'Mã đề tài k có trong bảng đề tài'
     if not exists (select * from tbldetai where macb=@macb)
	    print N'Mã cán bộ k có trong bảng cán bộ'
	 else 
	    update tbldetai set madt=@madt,macb=@macb,tendt=@tendt,kinhphi=@kp
end
exec capnhat 'dt10','cb1',N'sử địa',200
-- viết hàm đầu vào là tên khoa(tenkhoa), đầu ra là tổng số đề tài tên khoa này thực hiện
alter function dbo.cau2
(@tenkhoa nvarchar(35))
returns int 
as
begin
	declare @tdt int = 0
	select @tdt = count(tendt) from tblcanbo cb join tbldetai dt on cb.macb=dt.macb join tblkhoa k on k.makh=cb.makh
	where @tenkhoa=tenkhoa
	return @tdt
end
select dbo.cau2(N'kinh tế')
select * from tblkhoa
select * from tbldetai
select * from tblcanbo
--viết 1 thủ tục cho xem tên khoa(tenkhoa) có tổng số đề tài khoa này thực hiện là lớn nhất
create proc xemdetai
as
begin
     select tenkhoa from tblcanbo cb join tbldetai dt on cb.macb=dt.macb join tblkhoa k on k.makh=cb.makh
	 where kinhphi= select max(kinhphi from tbldetai)
end

--câu 3 viết trigger để khi thêm 1 bản ghi mới vào bảng tbldetai thì thỏa các yêu cầu sau:
--macb phải tồn tại trong bảng cán bộ tblcanbo
--A<=kinhphi<=B
create trigger thembanghi on tbldetai
instead of insert
as
	begin
	  declare @madt char(4) ,@macb char(4),@tendt nvarchar(50), @kp int
	    select @madt=madt,@macb=macb,@tendt=tendt,@kp=kinhphi from inserted
	    if not exists(select * from tblcanbo where @macb=macb)
	      print N'Mã cán bộ tồn tại trong bảng cán bộ'
	    if (@kp<=100) or (@kp>=500)
	      print N'Sai kinh phí' 
	    else 
	      insert into tbldetai values(@madt,@macb ,@tendt , @kp)
end

insert into tbldetai values ('dt8','cb1',N'đậu nành',350)