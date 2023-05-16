use QuanLySach
select * from tblLoaiSach
select * from tblKho
select * from tblSach
--3 tạo một thủ tục cho xem tên sách tên kho của những cuốn sách có giá bán cao nhất
create proc cau3
as 
begin
     select Tensach, TenKho from tblSach s join tblKho k on s.MaKho=k.MaKho
     where Gia=(select max(gia) from tblSach) 
end
exec cau3
--4 tạo 1 hàm với đầu vào là tên nhà xuất bản và trả về số lượng các cuốn sách của nhà xuất bản đó
create function dbo.thongke
 (@tnxb nvarchar(35))
returns nvarchar(35)
as 
begin
    declare @soluong int =0
    select @soluong=count(*) from tblsach
    where NhaXB=@tnxb
    return @soluong
end
select dbo.thongke(N'hoa hồng')
--5 Tạo một hàm với đầu vào là tên kho và trả về số cuốn sách có trong kho đó
create function dbo.cau5
(@TK nvarchar(50))
returns int
as
begin
	declare @sls int
	set @sls=0
	select @sls=count (*) from tblSach s join tblKho k ON s.Makho = s.Makho
	where Tenkho = @TK
   return @sls
end
select dbo.cau5 (N'kho 1')
--6.Tạo một thủ tục in các thông tin gồm: mã sách, tên sách, tên kho, tên nhà xuất bản,
 --Giá bán của những quyển sách được lưu trữ ở kho có tên được truyền theo tham số đầu vào. 
 --Nếu tên kho là Null thì đưa ra thông tin về các cuốn sách ở tất cả các kho. 
 --Nếu tên kho không có trong cơ sở dữ liệu thì thông báo ra màn hình.
create proc cau6
@tk nvarchar(50)=null
as
begin
	if(@tk is null)
	   select MaSach, TenSach, TenKho, NhaXB, Gia from tblKho K join tblSach S 
	   on S.Makho=K.Makho
    if(exists(select * from tblkho K where K.tenkho=@tk))
	   select MaSach, TenSach, TenKho, NhaXB, Gia 
	   from tblKho K join tblSach S on S.Makho=K.Makho
	   where K.TenKho=@tk
    else
	   print N'Kho không có trong CSDL'	 
end
exec cau6
exec cau6 N'kho 1'
exec cau6 N'kho 7'
--7.Viết chương trình nhập dữ liệu cho bảng kho với yêu cầu:
--	Mã kho tự động tăng (ví dụ: trong bảng có mã kho lớn nhất hiện tại là KH3 thì mã mới là KH4).
--	Tên kho tùy ý nhưng phải phù hợp với kiểu dữ liệu


--8 Lập trình sử dụng CURSOR để in danh sách gồm tên sách, giá bán, tên loại sách ở những kho có tên chứa từ ‘KH’
declare  @ts nvarchar(50), @g int, @tl nvarchar(35)
declare cau8 cursor for 
  select TenSach, Gia, Tenloai from   tblSach s join tblLoaiSach ls on ls.Maloai=s.Maloai join tblKho k on s.MaKho=k.MaKho
  where TenKho like 'kho 1'
open cau8
fetch next from cau8 into @ts, @g, @tl
  while @@FETCH_STATUS = 0
begin
    print N'Tên sách      :'+@ts
	print N'Giá bán       :'+cast(@g as nvarchar(35))
	print N'tên loại sách :'+@tl
	print N'--------------'
	fetch next from cau8 into @ts, @g, @tl
end
close cau8
DEALLOCATE cau8 

select * from tblLoaiSach
select * from tblKho
select * from tblSach
--9 Viết một hàm với đầu vào là tên loại sách, ra là tổng số sách của loại đó
create function dbo.tongsach
(@tl nvarchar(35))
returns int 
as 
begin
     declare @tsls int = 0
	 select @tsls=count(*) from tblLoaiSach ls join tblSach s on ls.Maloai=s.Maloai
	 where @tl=Tenloai
	 return @tsls
end
select dbo.tongsach(N'y tế')as 'tong so sach'
--10 Viết một hàm với đầu ra là tên loại sách và tổng số sách của loại đó
create function dbo.tongsosach
(@tloai nvarchar(35))
returns int
as 
begin
     declare @tssld int =0
	 select tenloai , @tssld=count(*) from tblLoaiSach ls join tblSach s on ls.Maloai=s.Maloai
	 where @tloai=Tenloai
	 return @tssld
end
select dbo.tongsosach(N'y tế')
--11.	Lập trình trigger để nhập môṭ cuốn sách mới vào cơ sở dữ liệu và thỏa mãn các yêu cầu sau:
--	Bắt lỗi PK;
--	Bắt lỗi FK;
--	Giá bán sách là số nguyên nằm trong khoảng (0, 100)
create trigger nhapsach on tblsach
instead of insert
as
  begin
     declare @ms int,@ts nvarchar(50), @ml int, @mk char(4),@nxb nvarchar(35), @g int
	 select @ms=MaSach, @ts=tensach, @ml=maloai,@mk=makho, @nxb=NhaXB, @g=gia from inserted
       if (exists (select * from tblSach where MaSach=@ms))
         print N'Loi PK'
       else if (not exists(select * from tblKho where MaKho=@mk))
         print N'loi FK'
       else if (not exists(select * from tblLoaiSach where @ml=MaLoai))
         print N'Loi FK'
       else if (@g > 0 AND @g < 100)
	     print N'Giá bán k thuộc phạm vi'
       else  
	   insert into tblSach values 
      (@ms,@ts,@ml,@mk,@nxb,@g)
end

insert into tblSach values (118,N'Anh',3,'k1',N'hoa hồng',7500)
  
insert into tblSach values (119,'Anh',3,'k1','hoa hồng',-10) 
 
select * from tblSach

drop trigger nhapsach