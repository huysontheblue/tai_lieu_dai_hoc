CREATE DATABASE ThucTap11; 
USE ThucTap11; 
CREATE TABLE TBLKhoa
(Makhoa char(10)primary key,
 Tenkhoa char(30),
 Dienthoai char(10)); 
 CREATE TABLE TBLGiangVien(
Magv int primary key,
Hotengv char(30),
Luong decimal(5,2),
Makhoa char(10) references TBLKhoa); 
CREATE TABLE TBLSinhVien(
Masv int primary key,
Hotensv char(40),
Makhoa char(10)foreign key references TBLKhoa,
Namsinh int,
Quequan char(30)); 
CREATE TABLE TBLDeTai(
Madt char(10)primary key,
Tendt char(30),
Kinhphi int,
Noithuctap char(30));
CREATE TABLE TBLHuongDan(
Masv int primary key,
Madt char(10)foreign key references TBLDeTai,
Magv int foreign key references TBLGiangVien,
KetQua decimal(5,2));  
INSERT INTO TBLKhoa VALUES
('Geo','Dia ly va QLTN',3855413),
('Math','Toan',3855411),
('Bio','Cong nghe Sinh hoc',3855412);
INSERT INTO TBLGiangVien VALUES
(11,'Thanh Binh',700,'Geo'), 
(12,'Thu Huong',500,'Math'),
(13,'Chu Vinh',650,'Geo'),
(14,'Le Thi Ly',500,'Bio'),
(15,'Tran Son',900,'Math'); 
INSERT INTO TBLSinhVien VALUES
(1,'Le Van Son','Bio',1990,'Nghe An'),
(2,'Nguyen Thi Mai','Geo',1990,'Thanh Hoa'),
(3,'Bui Xuan Duc','Math',1992,'Ha Noi'),
(4,'Nguyen Van Tung','Bio',null,'Ha Tinh'),
(5,'Le Khanh Linh','Bio',1989,'Ha Nam'),
(6,'Tran Khac Trong','Geo',1991,'Thanh Hoa'),
(7,'Le Thi Van','Math',null,'null'),
(8,'Hoang Van Duc','Bio',1992,'Nghe An'); 
INSERT INTO TBLDeTai VALUES
('Dt01','GIS',100,'Nghe An'),
('Dt02','ARC GIS',500,'Nam Dinh'),
('Dt03','Spatial DB',100, 'Ha Tinh'),
('Dt04','MAP',300,'Quang Binh' ); 
INSERT INTO TBLHuongDan VALUES
(1,'Dt01',13,8),
(2,'Dt03',14,0),
(3,'Dt03',12,10),
(5,'Dt04',14,7),
(6,'Dt01',13,Null),
(7,'Dt04',11,10),
(8,'Dt03',15,6);

-- cho biết hotengv hướng dẫn sv có ddiểm thực tập cao nhất
select Hotengv 
from TBLGiangVien GV Join TBLHuongDan HD on GV.Magv=HD.Magv
where KetQua = (select max(ketqua) from TBLHuongDan)

-- cho biết kết quả thực tập và tần suất xuất hiện của chúng
select KetQua, count(*) as 'Tanxuat'
from TBLHuongDan 
group by Ketqua

select * from TBLHuongDan
-- 1. Đưa ra thông tin gồm mã số, họ tênvà tên khoa của tất cả các giảng viên 
select Magv, Hotengv, Tenkhoa
from TBLGiangVien GV join TBLKhoa K on GV.Makhoa=K.Makhoa

-- 2. Đưa ra thông tin gồm mã số, họ tênvà tên khoa của các giảng viên của khoa ‘DIA LY & QLTN’ 
select Magv, Hotengv, Tenkhoa
from TBLGiangVien GV join TBLKhoa K on GV.Makhoa=K.Makhoa
where Tenkhoa='Dia ly va QLTN'

-- 3. Cho biết số sinh viên của khoa ‘CONG NGHE SINH HOC’
select count(*) as 'tong sv'
from TBLSinhVien Sv join TBLkhoa K on Sv.makhoa=k.makhoa
where tenkhoa='cong nghe sinh hoc'

-- 4. Đưa ra danh sách gồm mã số, họ tên và tuổi của các sinh viên khoa ‘TOAN’
SELECT  masv, hotensv, namsinh
FROM TBLKhoa join TBLSinhVien on TBLKhoa.makhoa = TBLSinhVien.makhoa
WHERE tenkhoa='Toan'
-- cach 2 truy van long
SELECT  masv, hotensv, namsinh
FROM TBLSinhVien 
WHERE makhoa = (SELECT makhoa FROM TBLKhoa WHERE tenkhoa='Toan');

-- 5. Cho biết số giảng viên của khoa ‘CONG NGHE SINH HOC’ 
select count(*)as 'so giang vien'
from TBLGiangVien GV join TBLKhoa K on GV.Makhoa=K.Makhoa
group by Tenkhoa, K. Makhoa having Tenkhoa = 'Cong nghe Sinh hoc'
-- cach 2
select count(*) from TBLGiangVien GV join TBLKhoa K on GV.Makhoa=K.Makhoa
where Tenkhoa='Cong nghe Sinh hoc'

--6  Cho biết thông tin về sinh viên không tham gia thực tập 
select Masv, Hotensv
from TBLSinhVien SV
where not exists( select HD.Masv from TBLHuongDan HD where SV.Masv = HD.Masv)

-- 7. Đưa ra mã khoa, tên khoa và số giảng viên của mỗi khoa 
select k.Makhoa, Tenkhoa, count(*) as 'so giang vien'
from TBLKhoa K join TBLGiangVien GV on K.Makhoa = GV.Makhoa
group by k.Makhoa, Tenkhoa 

-- 8. Cho biết số điện thoại của khoa mà sinh viên có tên ‘Le van son’ đang theo học 
select Dienthoai,Hotensv
from TBLSinhVien SV join TBLKhoa K on SV.Makhoa = K.Makhoa
where Hotensv='Le Van Son'

--9. Cho biết mã số và tên của các đề tài do giảng viên ‘Tran son’ hướng dẫn 
select DT.Madt, Tendt, GV.Hotengv
from TBLGiangVien GV join TBLHuongdan HD
on GV.Magv=HD.Magv
join TBLDetai DT on DT.Madt=HD.Madt
where GV.Hotengv='Tran Son'
-- cho biet ten  khoa co it nhat 1 giao vien
select tenkhoa from TBLKhoa K
where not exists ( select Makhoa from TBLGiangVien GV where K.Makhoa=GV.Makhoa)

-- 10. Cho biết tên đề tài không có sinh viên nào thực tập 
select Madt, Tendt
from TBLDetai DT
where not exists(select Madt from TBLHuongdan HD
where HD.Madt=DT.Madt)
-- cach 2
select Madt, Tendt
from TBLDetai DT
where not exists(select HD.Madt from TBLHuongdan HD
where HD.Madt=DT.Madt)

-- 11. Cho biết mã số, họ tên, tên khoa của các giảng viên hướng dẫn từ 3 sinh viên trở lên. 
select HD.Magv, Hotengv, Tenkhoa
from TBLGiangVien GV join TBLKhoa K on GV.Makhoa=K.Makhoa
join TBLHuongDan HD on HD.Magv=GV.Magv
group by HD.Magv, Hotengv, Tenkhoa having count(HD.Magv)>3;

-- 12. Cho biết mã số, tên đề tài của đề tài có kinh phí cao nhất 
select Madt, Tendt
from TBLDetai
where kinhphi = (select max(kinhphi) from TBLDeTai); 

 -- 13. Cho biết mã số và tên các đề tài có nhiều hơn 2 sinh viên tham gia thực tập 
select DT.Madt, Tendt
from TBLDeTai DT join TBLHuongDan HD on DT.Madt=HD.Madt
group by DT.Madt, Tendt having count(DT.Madt)>2;
-- cách 2 truy vấn lồng
SELECT madt, tendt
FROM TBLDeTai
WHERE TBLDeTai.madt in (  SELECT TBLHuongDan.madt
                    FROM TBLHuongDan
                    GROUP BY TBLHuongDan.madt
                    HAVING COUNT(TBLHuongDan.madt) > 2)

-- 14. Đưa ra mã số, họ tên và điểm của các sinh viên khoa ‘DIALY và QLTN’ 
select SV.Masv, Hotensv, KetQua
from TBLSinhVien SV join TBLKhoa K on SV.Makhoa=K.Makhoa
join TBLHuongDan HD on SV.Masv=HD.Masv
where Tenkhoa='Dia ly va QLTN'

select * from TBLDeTai
select * from TBLSinhVien
select * from TBLKhoa
select * from TBLGiangVien
select * from TBLHuongDan
select * from TBLHocTap

-- 15. Đưa ra tên khoa, số lượng sinh viên của mỗi khoa 
select Tenkhoa, count(*) as 'So sinh vien'
from TBLSinhVien SV join TBLKhoa K on SV.Makhoa=K.Makhoa
group by Tenkhoa

-- 16. Cho biết thông tin về các sinh viên thực tập tại quê nhà 
select SV.Masv, Hotensv, Quequan
from TBLSinhVien SV join TBLHuongDan HD on SV.Masv = HD.Masv
join TBLDeTai DT on DT.Madt = HD.Madt
where Quequan = Noithuctap

-- 17. Hãy cho biết thông tin về những sinh viên chưa có điểm thực tập 
select SV.Masv, Hotensv, Ketqua
from TBLSinhVien SV join TBLHuongDan HD on Sv.Masv = HD.Masv
where Ketqua is null

-- 18. Đưa ra danh sách gồm mã số, họ tên các sinh viên có điểm thực tập bằng 0 
select SV.Masv, Hotensv, Ketqua
from TBLSinhVien SV join TBLHuongDan HD on Sv.Masv = HD.Masv
where Ketqua = 0

-- cho biet họ tên gv huong dan sv có điểm thấp nhất
select Hotengv 
from TBLGiangVien GV join TBLHuongDan HD on GV.Magv=HD.Magv
where KetQua = (select MIN(ketqua) from TBLHuongDan)

-- cho biết hotengv hướng dẫn sv có ddiểm thực tập cao nhất
select Hotengv 
from TBLGiangVien GV Join TBLHuongDan HD on GV.Magv=HD.Magv
where KetQua = (select max(ketqua) from TBLHuongDan)

-- 19. Nhận xét về hai câu truy vấn sau: 
SELECT * FROM TBLHuongDan; -- truy van ra tat ca cac du lieu trong bang huong dan
SELECT * FROM TBLHuongDan WHERE ketqua>5 or ketqua<=5; -- truy van ra tat ca cac du lieu trong bang voi dk ket qua lon hon 5 or be hon hoac 5

-- cach lay het du lieu cua 1 bang dua vao 1 bang moi 
select * into tblnhachoc
from tblgiangvien
select * from TBLHocTap

-- 20. Tạo một bảng mới có tên HocTap với cấu trúc tương tự bảng GiangVien.
create table TBLHocTap
( Maht int primary key,
Hotengv char(40),
Magv int foreign key references TBLGiangVien)

-- tao ra 1 bảng y chang nhung k co du lieu
select * into bangtao
from TBLGiangVien
where 6>9

-- 21. Nhập dữ liệu cho bảng HocTap. Yêu cầu dữ liệu được lấy từ bảng GiangVien, chỉ lấy các giảng viên có mã số từ 11 đến 14, và sử dụng lệnh INSERT INTO <tên_bảng> SELECT <tên_cột> FROM <tên_bảng> WHERE <điều_kiện>
insert into TBLHocTap values
(20,'Thanh Binh',11),
(21,'Thu Huong',12),
(22,'Chu Vinh',13),
(23,'Le Thi Ly',14),
(24,'Thu Huong',12);

-- 22 Thêm cột TienHoc với kiểu dữ liệu decimal(10,2) vào bảng HocTap. Cột TienHoc này được dùng để nhập tiền học, và có giá trị từ 0 đến 100. Nếu có giá trị 0, nghĩa là giảng viên đó không phải nạp tiền học. 
alter table TBLHocTap
add Tienhoc decimal(10,2);

insert into TBLHocTap values
(20,'Thanh Binh',11, 0),
(21,'Thu Huong',12,10),
(22,'Chu Vinh',13,0),
(23,'Le Thi Ly',14,20),
(24,'Thu Huong',12,100);
-- cho biet ten sv đã đk đề tai và có kinh phi lớn hơn 300
select Hotensv from TBLSinhVien
where 
intersect
select Hotensv from TBLDeTai
where Kinhphi > 300

--23  Đưa ra mã số, họ tên các giảng viên hoặc phải đóng tiền học hoặc có lương nhỏ hơn 600.
select Magv, Hotengv from TBLGiangVien
where luong <600
union
select Magv, Hotengv from TBLHocTap
where Tienhoc >0

-- 24. Đưa ra mã số, họ tên các giảng viên vừa phải đóng tiền học vừa có lương nhỏ hơn 600. 
select magv, hotengv from TBLGiangVien
where luong<600
intersect
select magv, hotengv from TBLHocTap
where tienhoc>0

-- 25. Đưa ra mã số, họ tên các giảng viên không tham gia khóa học có lương nhỏ hơn 1 000 000.
select magv, hotengv
from TBLGiangVien
where luong < 1000000
except
select magv, hotengv
from TBLHocTap
where tienhoc=0
-- tạo view bang create 
alter view tenview as 
select * from TBLKhoa
-- xoa view
drop view tenview
-- sửa view bang alter
alter view tenview as
select tenkhoa from TBLKhoa

select * from tenview
-- xoa bang
drop table TBLHocTap
select * from TBLDeTai
select * from TBLHuongDan
select * from TBLGiangVien
select * from TBLKhoa
select * from TBLSinhVien
select * from TBLHocTap
-- cho biết tỷ lệ giữa số lượng đề tài đk thực tập với sl đề tài đã có
select count(madt) from TBLDeTai
select count(*) from TBLSinhVien
-- tao ra bien1
select tendt, madt into bien1
from TBLDetai
select * from bien1
select tendt  into bien2
from TBLDeTai DT join
-- cho biết tên các đề tài đã đc đăng ký thực tập
select  distinct tendt
from TBLDeTai
-- cho biết ket qua va tan suất xuất hiện của nó
select ketqua, COUNT(*) as 'tan xuat'
from TBLHuongDan
group by KetQua
-- cho biet ten de tai k sinh vien nao tham gia thuc tap
select Tendt, Madt
from TBLDeTai
where not exists (select 