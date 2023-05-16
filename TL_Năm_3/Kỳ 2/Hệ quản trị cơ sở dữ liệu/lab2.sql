use HTTXe
--2. cho biết các thông tin của các nhà cung cấp có địa chỉ là hai chau
select * from NHACUNGCAP
where DiaChi='Hai Chau'
select * from DONGXE
select * from DANGKYCUNGCAP
select * from LOAIDICHVU
select * from MUCPHI
select * from NHACUNGCAP
--3 tạo khung nhìn có tên là V_NCC để lấy thông tin của các nhà cung cấp có địa chỉ là 'Lien Chieu' 
CREATE VIEW V_NCC AS
select DiaChi, MaNhaCC, TenNhaCC, SoDT, MaSoThue
from NHACUNGCAP 
where DiaChi='Lien Chieu'

select * from V_NCC

drop view V_NCC

--4 sử dụng khung nhìn vncc cho biết thông tin về tên nhà cung cấp và tên những 
--dòng xe được đăng ký cung cấp bởi các nhà cung cấp ở 'lien chieu'
select * from V_NCC

select TenNhaCC, DX.DongXe
from V_NCC join DANGKYCUNGCAP DKCC on V_NCC.MaNhaCC=DKCC.MaNhaCC
join DONGXE DX on DKCC.DongXe=DX.DongXe
where DiaChi='Lien Chieu'

--5 sử dụng khung nhìn V_NCC để cập nhật thành 'Vinh CiTy' 
--đối với tất cả các nhà cung cấp được nhìn thấy bời khung nhìn này
update V_NCC 
set V_NCC.DiaChi='Vinh CiTy'

select * from V_NCC
-- 6 lập dữ liệu cho nhà cung cấp mới, nếu trùng khóa chính thì thông 
--báo ra màn hình 'Dữ liệu bị trung khóa chính' nguơc lại thì thêm nhà cung cấp mới vào hệ thống
declare @NCC char(10)
set @NCC='NCC11'
if @NCC in
 (select MaNhaCC from NHACUNGCAP)
  print N'Dữ liệu bị trùng khóa chính'
else 
insert into NHACUNGCAP values 
('NCC11','Công ty lộc phát','Vinh CiTy','09124587xxx',123456)
select * from LOAIDICHVU
--7 sử dụng cursor hiển thị tên các loại dịch vụ 
declare @tdv nvarchar(100)
declare tdv_cursor cursor
keyset
for select TenLoaiDV from LOAIDICHVU 
open tdv_cursor
fetch next from tdv_cursor 
into @tdv
while @@FETCH_STATUS = 0
   begin
      print @tdv
      fetch next from tdv_cursor into @tdv
   end
close tdv_cursor
DEALLOCATE tdv_cursor
-- cau 8 sử dụng kiểu dữ liệu cursor để hiển thị dòng xe, 
--hãng xe có số chỗ ngồi ít nhất
declare @dx char(10), @hx char(10),@sochongoi int
declare DX_cursor cursor
for select DongXe, HangXe, SoChoNgoi from DONGXE
declare @min int =(select MIN(sochongoi) from DONGXE)
open DX_cursor
fetch next from DX_cursor into @dx, @hx, @sochongoi
while @@FETCH_STATUS = 0
begin
   if @sochongoi=@min
     begin
        Print N'xe có số chỗ ngồi ít nhất là :'+ @dx 
		print N'hãng xe : '+ @hx
		print N'----------------------------'
		fetch next from DX_cursor into @dx, @hx, @sochongoi
	 end 
	 else fetch next from DX_cursor into @dx, @hx, @sochongoi
end
close DX_cursor
DEALLOCATE DX_cursor
-- cau 9 sử dụng kiểu dữ liệu cursor hiển thị tên các nha cung cấp tên 
--loại dịch vụ đã đăng ký cung cấp trong tháng 11 năm 2015
declare @TenNhaCC nvarchar(50) ,
        @TenLoaiDV nvarchar(100)
declare cau9_cursor cursor
keyset 
for select TenNhaCC, TenLoaiDV 
from NHACUNGCAP NCC join DANGKYCUNGCAP DKCC on NCC.MaNhaCC=DKCC.MaNhaCC join LOAIDICHVU LDV on LDV.MaLoaiDV=DKCC.MaLoaiDV
where NgayBatDauCungCap like '2015-11-20'
open cau9_cursor
fetch next from cau9_cursor
 into @TenNhaCC, @TenLoaiDV
  while @@FETCH_STATUS = 0
   begin
    print N'Tên nhà cung cấp :'+ @TenNhaCC
    print N'Tên loại dịch vu :'+@TenLoaiDV
	print N'-----------------'
   end
close cau9_cursor
deallocate cau9_cursor

select * from DONGXE
select * from DANGKYCUNGCAP
select * from NHACUNGCAP
select * from LOAIDICHVU
select * from MUCPHI

-- câu 10 tạo mối liên kết giữa các bảng(databasse diagram) cho cơ sở dữ liệu. 
--CHỉ rõ các mối liên kết và phân tích ý nghĩa của mỗi liên kết











