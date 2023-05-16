use QLDiem
--2 tạo thủ tục với đầu vào là tên giáo viên chủ nhiệm(gvcn), 
--ra là tổng số học sinh của lớp mà giáo viên đó chủ nhiệm.
--Nếu tên giáo viên chủ nhiệm không tồn tại or null thì hiện các thông báo tương ứng.
create proc tongsohs
  @tengv varchar(50)=null, 
  @tonghs int out
as 
begin
    if not exists (select * from tbllop l where @tengv=l.gvcn)
	   print N'Tên giáo viên không tồn tại'
	else if @tengv is null 
	   print N'NULL'
    else
	   select @tonghs = count(*) from tblhocsinh hs join tbllop l on hs.malop=l.malop 
	   where @tengv=gvcn
end
-- gọi lại thủ tục
declare @tong int
exec tongsohs 'phan anh phong', @tong out;
select @tong

--3 Tạo hàm với đầu vào là tên lớp học, đầu ra là tên giáo viên chủ nhiệm, tên các học sinh
-- giới tính và tổng điểm 3 môn của mỗi học sinh lớp đó
create function dbo.cau2
(@tl char(4))
returns table
as
return(select gvcn, tenhs, gioitinh, diemtoan+diemly+diemhoa as N'Tổng điểm' from tbllop l 
      join tblhocsinh hs on l.malop=hs.malop
      join tbldiem d on hs.mahs=d.mahs)
select * from dbo.cau2('lop1')

--4 Tạo thủ tục cho xem tên lớp có số học sinh ít nhất
alter proc xemtenlop
as
begin
  select tenlop, count(*) from tbllop l join tblhocsinh hs on l.malop=hs.malop
  group by tenlop
end
exec xemtenlop
------------------------------------------------
create proc cau4
as 
begin
   declare @min int
   set @min=0
   select count(tenlop)=@min from tbllop group by malop
end
--5 Sử dụng biến kiểu dữ liệu CURSOR in danh sách gồm họ tên học sinh và tổng điểm của 3 môn của những
-- học sinh ở lớp có tên 12A1
declare @hths varchar(35),@tongdiem real
declare @indanhsach cursor
set @indanhsach = cursor for
select tenhs, diemtoan+diemly+diemhoa as N'Tổng điểm' from  tbllop l join tblhocsinh hs on l.malop=hs.malop
       join tbldiem d on d.mahs=hs.mahs
	   where tenlop='lop2' 
open @indanhsach
fetch next from @indanhsach into @hths,@tongdiem
while @@FETCH_STATUS=0
begin 
   print N'Họ tên học sinh : ' +@hths
   print N'Tổng điểm       : ' +cast(@tongdiem as nvarchar)
   fetch next from @indanhsach into @hths,@tongdiem
end
close @indanhsach
deallocate @indanhsach

--6 Tạo trigger để khi thêm một bản ghi mới vào bảng điểm thì thỏa mãn các yêu cầu sau:
-- mahs phải tồn tại trong bảng học sinh
--0<= diemtoan<=10
create trigger thembanghi on tbldiem
instead of insert
as
  begin
   declare @mahs char(4),@dt real,@dl real,@dh real
   select @mahs=mahs,@dt=diemtoan,@dl=diemly,@dh=diemhoa from inserted
     if not exists(select * from tblhocsinh where @mahs=mahs)
	  begin
	       print N'Lỗi mã học sinh'
	       return
	  end
	if ((@dt<0) or (@dt>10))
	  begin
	       print N'Nhập sai điểm toán'
		   return
      end
	 insert into tbldiem values (@mahs,@dt,@dl,@dh)
  end
insert into tbldiem values('hs7',9,8,9) --sai mahs
insert into tbldiem values('hs2',11,8,9) -- sai điểm toán
insert into tbldiem values('hs2',7,8,9)  -- hoàn thành


select * from tbldiem
select * from tblhocsinh
select * from tbllop

