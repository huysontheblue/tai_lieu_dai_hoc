

use LUONG
create table khoa
(makhoa char(4) primary key,
tenkhoa nvarchar(35))

create table canbo
(macanbo char(4) primary key,
makhoa char(4)foreign key references khoa,
tencanbo nvarchar(35),
ngaysinh char(10))

create table luong 
(macanbo char(4) primary key,
hesoluong float,
luong money)

insert into khoa values
('kh1',N'Kỹ thuật'),
('kh2',N'Kinh tế'),
('kh3',N'Sư phạm'),
('kh4',N'Giáo dục thể chất'),
('kh5',N'Xây dựng')

insert into canbo values
('cb1','kh2',N'Hà Huy Sơn','24-10-2000'),
('cb2','kh1',N'Trần trung kiên','20-10-2000'),
('cb3','kh3',N'Trương huy mạnh','20-11-2000'),
('cb4','kh2',N'Trần thị oanh','04-05-2000'),
('cb5','kh3',N'Nguyễn thị uyên','09-01-2000')

insert into luong values 
('cb1',4.4,5940000),
('cb3',4.6,6210000),
('cb2',5.1,6885000),
('cb4',5.7,7695000),
('cb5',6.5,8775000)

select * from khoa
select * from canbo
select * from luong

--2. Tạo thủ tục đưa ra họ tên cán bộ, hệ số lương với tham số vào là Tên khoa. 
--Trong trường hợp nếu gọi thủ tục mà không truyền tham số thì đưa ra thông tin trên của tất cả cán bộ có trong cơ sở dữ liệu
create proc xemten_hesoluong
(@tk nvarchar(35) = null)
as
	if(@tk is null)
		select tencanbo, hesoluong from luong l join canbo cb on l.macanbo= cb.macanbo
	else
		select tencanbo, hesoluong from luong l join canbo cb on l.macanbo= cb.macanbo join khoa k on cb.makhoa= k.makhoa
		where tenkhoa = @tk

exec xemten_hesoluong N'Kỹ thuật'
exec xemten_hesoluong
drop proc xemten_hesoluong

--3. Viết hàm tạo bảng gồm họ tên cán bộ, hệ số lương, lương, tên khoa của những cán bộ có hệ số lương >= A, với A là một hệ số lương nào đó.
create function dbo.cau3
(@hsl float)
returns table
as
   return(select tencanbo,hesoluong,luong,tenkhoa from canbo cb join khoa k on cb.makhoa=k.makhoa join luong l on cb.macanbo=l.macanbo
   where hesoluong >= @hsl)
-- sử dụng hàm  
 select * from dbo.cau3(5.7)

--4. Viết trigger để khi thêm một bản ghi mới vào bảng Luong thì thỏa các yêu cầu sau:
--MaCB phải tồn tại trong tblCanbo.
--1.00 < Hesoluong <5
create trigger thembanghi ON Luong
instead of insert
as
	begin
		declare @macb char(4), @hsl float, @l money
		select @macb = macanbo , @hsl = hesoLuong, @l = luong from inserted
		if @macb not in ( select macanbo from Canbo)
			begin
				print N'Nhập sai mã cán bộ!'
				return 
			end
		if ((@hsl < 1) or ( @hsl > 5))
			begin
				print N'Nhập sai hệ số lương!'
				return 
			end
	insert into luong values
	(@macb, @hsl, @l)
	end
drop trigger thembanghi
insert into Luong values ('cb7', 4.6,8775000 ) -- sai ma cb
insert into Luong values ('cb5', 7,6210000) -- sai hsluong
insert into Luong values ('cb4', 4.7,8634022) -- hoan thanh
select * from luong