CREATE DATABASE ThucTap;
Use ThucTap;
go
CREATE TABLE TBLKhoa
(makhoa char(10) primary key,
tenkhoa char(30),
dienThoai char(10));

CREATE TABLE TBLGiangVien
(magv int primary key,
hotengv char(30),
luong decimal(5,2),
makhoa char(10) references TBLKhoa);

CREATE TABLE TBLSinhVien(
masv int primary key,
hotensv char(40),
makhoa char(10)foreign key references TBLKhoa,
namsinh int,
quequan char(30)); 

CREATE TABLE TBLDeTai(
madt char(10)primary key,
tendt char(30),
kinhphi int,
noithuctap char(30));

CREATE TABLE TBLHuongDan(
masv int primary key,
madt char(10)foreign key references TBLDeTai,
magv int foreign key references TBLGiangVien,
ketqua decimal(5,2));
-- chen bang khoa
INSERT INTO TBLKhoa VALUES
('Geo','Dia ly va QLTN',3855413),
('Math','Toan',3855411),
('Bio','Cong nghe Sinh hoc',3855412)
-- chen bang giangvien
INSERT INTO TBLGiangVien VALUES
(11,'Thanh Binh',700,'Geo'),
 (12,'Thu Huong',500,'Math'),
(13,'Chu Vinh',650,'Geo'),
(14,'Le Thi Ly',500,'Bio'),
(15,'Tran Son',900,'Math');
-- chen bang sinhvien
INSERT INTO TBLSinhVien VALUES
(1,'Le Van Son','Bio',1990,'Nghe An'),
(2,'Nguyen Thi Mai','Geo',1990,'Thanh Hoa'),
(3,'Bui Xuan Duc','Math',1992,'Ha Noi'),
(4,'Nguyen Van Tung','Bio',null,'Ha Tinh'),
(5,'Le Khanh Linh','Bio',1989,'Ha Nam'),
(6,'Tran Khac Trong','Geo',1991,'Thanh Hoa'),
(7,'Le Thi Van','Math',null,'null'),
(8,'Hoang Van Duc','Bio',1992,'Nghe An');
-- chen bang detai
INSERT INTO TBLDeTai VALUES
('Dt01','GIS',100,'Nghe An'),
('Dt02','ARC GIS',500,'Nam Dinh'),
('Dt03','Spatial DB',100, 'Ha Tinh'),
('Dt04','MAP',300,'Quang Binh' ); 
-- chen bang huongdan
INSERT INTO TBLHuongDan VALUES
(1,'Dt01',13,8),
(2,'Dt03',14,0),
(3,'Dt03',12,10),
(5,'Dt04',14,7),
(6,'Dt01',13,Null),
(7,'Dt04',11,10),
(8,'Dt03',15,6);
-- 1. Đưa ra thông tin gồm mã số, họ tên và tên khoa của tất cả các giảng viên
SELECT magv, hotengv, TBLKhoa.makhoa, tenkhoa 
FROM TBLKhoa join TBLGiangVien on TBLKhoa.makhoa = TBLGiangVien.makhoa
-- 2. Đưa ra thông tin gồm mã số, họ tên và tên khoa của các giảng viên của khoa ‘DIA LY & QLTN’ 
 SELECT magv, hotengv, tenkhoa
 FROM TBLKhoa join TBLGiangVien on TBLKhoa.makhoa = TBLGiangVien.makhoa
 WHERE tenkhoa='Dia ly va QLTN'
-- 3. Cho biết số sinh viên của khoa ‘CONG NGHE SINH HOC'
SELECT COUNT(*) 
FROM TBLKhoa join TBLSinhVien on TBLKhoa.makhoa = TBLSinhVien.makhoa
WHERE tenkhoa='Cong nghe Sinh hoc'
-- cach 2 truy van long
SELECT COUNT(*)
FROM TBLSinhVien
WHERE makhoa = ( SELECT makhoa FROM TBLKhoa WHERE tenkhoa='Cong nghe Sinh hoc');
-- 4. Đưa ra danh sách gồm mã số, họ tên và tuổi của các sinh viên khoa ‘TOAN’
SELECT  masv, hotensv, namsinh
FROM TBLKhoa join TBLSinhVien on TBLKhoa.makhoa = TBLSinhVien.makhoa
WHERE tenkhoa='Toan'
-- cach 2 truy van long
SELECT  masv, hotensv, namsinh
FROM TBLSinhVien 
WHERE makhoa = (SELECT makhoa FROM TBLKhoa WHERE tenkhoa='Toan');
--5 Cho biết số giảng viên của khoa ‘CONG NGHE SINH HOC’
SELECT COUNT(*) 
FROM TBLKhoa join TBLGiangVien on TBLKhoa.makhoa = TBLGiangVien.makhoa
WHERE tenkhoa='Cong nghe Sinh hoc'
-- 6 Cho biết thông tin về sinh viên không tham gia thực tập
 SELECT * FROM TBLSinhVien
WHERE NOT EXISTS ( SELECT * FROM
WHERE 
-- 7. Đưa ra mã khoa, tên khoa và số giảng viên của mỗi khoa
SELECT makhoa, tenkhoa, dienthoai
FROM TBLKhoa
-- 8. Cho biết số điện thoại của khoa mà sinh viên có tên ‘Le van son’ đang theo học 
SELECT dienThoai
 FROM TBLKhoa join TBLSinhVien on TBLKhoa.makhoa = TBLSinhVien.makhoa
 WHERE hotensv='Le van son'
-- 9. Cho biết mã số và tên của các đề tài do giảng viên ‘Tran son’ hướng dẫn 
SELECT TBLDeTai.madt, tendt
FROM TBLDeTai join TBLHuongDan on TBLDeTai.madt = TBLHuongDan.madt
WHERE 
-- 10. Cho biết tên đề tài không có sinh viên nào thực tập 
SELECT madt, tendt
FROM TBLDeTai
WHERE NOT EXISTS( SELECT madt
FROM TBLHuongDan
WHERE TBLHuongDan.madt = TBLDeTai.madt);
-- 11. Cho biết mã số, họ tên, tên khoa của các giảng viên hướng dẫn từ 3 sinh viên trở lên.
SELECT magv, hotengv
FROM TBLGiangVien
WHERE magv in (  SELECT TBLHuongDan.madt
                    FROM TBLHuongDan
                    GROUP BY TBLHuongDan.madt
                    HAVING COUNT(TBLHuongDan.madt) >= 3);
-- 12. Cho biết mã số, tên đề tài của đề tài có kinh phí cao nhất 
SELECT madt, tendt
FROM TBLDeTai
WHERE kinhphi = ( select max(kinhphi) from TBLDeTai);
--13. Cho biết mã số và tên các đề tài có nhiều hơn 2 sinh viên tham gia thực tập
SELECT madt, tendt
FROM TBLDeTai
WHERE TBLDeTai.madt in (  SELECT TBLHuongDan.madt
                    FROM TBLHuongDan
                    GROUP BY TBLHuongDan.madt
                    HAVING COUNT(TBLHuongDan.madt) > 2)
-- 14. Đưa ra mã số, họ tên và điểm của các sinh viên khoa ‘DIALY và QLTN’ 
SELECT 