use QLBH1
select * from tblCTDonDH
select * from tblDonDH
select * from tblCTPNhap
select * from tblCTPXuat
select * from tblkk
select * from tblnhac
select * from tblPNhap
select * from tblPNhap
select * from tblPXuat
select * from tblTonKho
select * from tblVATTU
-- 2.1 cho biết tên vật tư có giá cao nhất
select TenVtu from tblVATTU
where Dongia = (select max (Dongia) from tblVATTU)
--2.2 Hiển thị tên vật tư, mã và đơn giá theo tăng dần (giảm dần)
select TenVtu, MaVtu, DonGia from tblVATTU
order by DonGia desc
-- tăng dần
select TenVtu, MaVtu, DonGia from tblVATTU
order by DonGia 
--2.3 Hiển thi tên địa chỉ các nhà cung cấp
select HoTen, DiaChi from tblnhac
--2.4. Cho biết tên các nhà cung cấp đã đặt hàng vào tháng 3 năm 2012
select HoTen from tblnhac NHACC join tblDonDH DH
on NHACC.Manhacc=DH.Manhacc
where NgayDH = '201203'
--2.5. Cho biết thông tin về các mặt hàng có mã bắt đầu bằng các ký tự ‘DD’ hoặc ‘L’
select * from tblVATTU 
where MaVTu like 'DD%' or MaVTu like 'L%'

--1. Hiện thông tin SoDH, MaVTu, SLDat, NgayDH, Manhacc của 2 bảng tblCTDonDH và tblDonDH. 
select DonDH.SoDh, MaVtu, SLDat, NgayDH, Manhacc
from tblDonDH DonDh join tblCTDonDH CTDonDh on DonDh.SoDH=CTDonDh.SoDH
 
 Declare @Sodh Int       --, @MaVtu char, @SLDat int,@NGayDH datetime, @Manhacc char
 SELECT @SoDH = SoDH from tblDonDH
 Print @SoDH
 select * from tblDonDH

--2. Hiện thông tin trong bảng DONDH và 2 cột địa chỉ, Tên nhà cung cấp trong bảng NHACC
select HoTen, DiaChi from tblDonDH,
tblnhac NHACC join tblDonDH DonDh on NHACC.Manhacc=DonDH.Manhacc
select * from tblnhac
--3 Hiện thông tin các đơn đặt hàng trong bảng DONDH và Họ tên nhà cung cấp trong bảng NHACC với yêu cầu sắp xếp theo mã nhà cung cấp tăng dần.
select 










