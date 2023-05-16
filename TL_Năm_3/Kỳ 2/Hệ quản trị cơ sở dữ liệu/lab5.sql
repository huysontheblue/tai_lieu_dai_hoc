use QLSV
--b, sử dụng cursor in danh sách gồm mã sinh viên, tên sinh viên, giới tính, tên ngành
-- của những sinh viên có tên khoa là'Kỹ Thuật công nghệ' theo 2 kỹ thuật 
-- b1, dùng cursor theo cách thông thường
 declare @msv char(4), @tsv nvarchar(50), @gt nchar(3), @tn nvarchar(50)
 declare caub1 cursor 
 keyset
       for select Masv, Tensv, Gioitinh, Tennganh from tblsinhvien sv join tblnganhdaotao ndt
       on sv.Manganh=ndt.Manganh join tblkhoa k on sv.MaKH=k.MaKH
       where TenKH=N'kỹ thuật'
 open caub1
 fetch next from caub1 into @msv, @tsv, @gt, @tn
   while @@FETCH_STATUS = 0
    begin
     print N'Mã sinh viên: '+ @msv
	 print N'Tên sinh viên: '+ @tsv
	 print N'Giới tính: ' +@gt
	 print N'Tên ngành: ' +@tn
	 print '-----------------'
	 fetch next from caub1 into @msv, @tsv, @gt, @tn
  end
	close caub1
DEALLOCATE caub1
--b2, dùng  cursor như 1 biến
declare @MaSV char(4), @TenSV nvarchar(50), @GioiTinh nchar(3), @Tennganh nvarchar(50)
declare @cu_DSSV1 cursor
set @cu_DSSV1 = cursor for
   select Masv, Tensv, Gioitinh, Tennganh from tblsinhvien sv join tblnganhdaotao ndt
   on sv.Manganh=ndt.Manganh join tblkhoa k on sv.MaKH=k.MaKH
   where TenKH=N'kỹ thuật'
open @cu_DSSV1
fetch next from @cu_DSSV1 into @MaSV, @TenSV, @GioiTinh, @Tennganh
while @@FETCH_STATUS =0
 begin
	print N'Mã sinh viên: ' + @MaSV
	print N'Tên sinh viên:' + @TenSV
	print N'Giới tính: ' + @GioiTinh
	print N'Tên Ngành: ' + @Tennganh
	print '-----------------------------'
	fetch next from @cu_DSSV1 into @MaSV, @TenSV, @GioiTinh, @Tennganh
 end
close @cu_DSSV1
deallocate @cu_DSSV1
--c, taọ một hàm với đầu vào là tên khoa, đầu ra là tên sinh viên, giới tính, tên ngành
create function dbo.cauc
(@tk nvarchar(30))
returns table
as 
  return(select Tensv, Gioitinh, Tennganh 
  from tblnganhdaotao ndt join tblsinhvien sv on ndt.Manganh=sv.Manganh join tblkhoa k on sv.MaKH=k.MaKH
  where @tk=TenKH)
select * from dbo.cauc(N'kỹ thuật') 
-- 
select * from tblkhoa
select * from tblnganhdaotao
select * from tblsinhvien
-- d, tạo một thủ tục cho xem tên ngành có số sinh viên theo học ít nhất
create proc xemtennganh
as 
begin
   select tennganh, count(*) as 'số sinh viên 'from tblnganhdaotao ndt join tblsinhvien sv on ndt.Manganh=sv.Manganh
   group by Tennganh
 end
exec xemtennganh
-- e, tạo một trigger thêm một sinh viên mới vào CSDL và thỏa mãn các yêu cầu sau:
-- MaNganh phải tồn tại trong tblnganhdaotao
-- giới tính chỉ nhận 'Nam' or 'Nữ'
create trigger themsinhvien on tblsinhvien
for insert 
as 
declare @msv char(4), @tensv nvarchar(50), @gt nchar(3), @Makh char(4), @manganh char(3)
   if (exists(select * from tblnganhdaotao where @manganh=Manganh))
   if (exists(select * from tblsinhvien where @gt=Gioitinh))
 insert into tblsinhvien values 
   (@msv,@tensv,@gt,@Makh,@manganh)
-- xóa trigger
drop trigger themsinhvien
-- chèn thêm giá trị vào trigger
insert into tblsinhvien values
('s9',N'đậu xuân phi long','1','k6','n6')
select * from tblsinhvien
-- xóa 1 sinh viên trong bảng sinh viên
delete from tblsinhvien
where Masv='s10'
--f,Sử dụng bảng tạm đưa ra mã số, họ tên, tên ngành và tên khoa của các nam sinh viên. Gợi ý dùng lệnh insert into ten bảng select 
-- để nhập dữ liệu từ 1 câu truy vấn vào bảng tạm
create table #cauf
(
 Masv char(4) PRIMARY KEY,
 Tensv nvarchar(50) not null,
 Tennganh nvarchar(50) not null,
 TenKH nvarchar(30))
-- thêm dữ liệu và bảng tạm
insert into #cauf (Masv, Tensv, Tennganh, TenKH) select sv.Masv, Tensv, Tennganh, TenKH from tblsinhvien sv join tblkhoa k 
on sv.MaKH=k.MaKH join tblnganhdaotao ndt on sv.Manganh=ndt.Manganh
where Gioitinh='1'
-- kiểm tra dữ liệu
select * from #cauf
-- xóa bảng tạm
drop table #cauf
--g,--Tạo một Stored Procedure để thêm thông tin của một sinh viên mới vào cơ sở dữ liệu, yêu cầu:
--Nếu trùng mã số sinh viên thì phải thông báo là mã số sinh viên này đã tồn tại và không thực hiện thêm thông tin về sinh viên đó vào CSDL
--Nếu dữ liệu về mã khoa của sinh viên mới mà không hợp lệ thì thông báo mã khoa này chưa có và không thực hiện thêm thông tin về sinhviên đó vào CSDL
--Nếu dữ liệu về mã ngành của sinh viên mới mà không hợp lệ thì thông báo mã ngành này chưa có và không thực hiện thêm thông tin về sinh viên đó vào CSDL
--Nếu không vị phạm vào 3 trường hợp trên thì bổ sung thông tin về sinh viên mới vào CSDL
create proc themthongtinsv
@msv char(4), @ht nvarchar(50), @gt nchar(3), @mk char(4), @mn char(3)
as 
begin
  if exists(select * from tblsinhvien where @msv=Masv)
     print N'mã số sinh viên này đã tồn tại và không thực hiện thêm thông tin về sinh viên đó vào CSDL'
  else if not exists(select * from tblkhoa where @mk=MaKH)
     print N'mã khoa này chưa có và không thực hiện thêm thông tin về sinhviên đó vào CSDL'
  else if not exists(select * from tblnganhdaotao where @mn=Manganh)
     print N'mã ngành này chưa có và không thực hiện thêm thông tin về sinh viên đó vào CSDL'
  else 
     insert into tblsinhvien values(@msv, @ht, @gt ,@mk, @mn)
end

exec themthongtinsv 's10',N'hà văn lợi','1','k3','n3'
select * from tblsinhvien

--h, Viết trigger để xóa một sinh viên sao cho CSDL vẫn đảm bảo tính nhất quán
create trigger xoasinhvien on tblsinhvien
after delete
as
begin
 set nocount on;
 delete 