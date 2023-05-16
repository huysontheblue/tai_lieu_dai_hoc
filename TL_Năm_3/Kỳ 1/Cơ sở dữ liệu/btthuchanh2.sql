CREATE DATABASE HDThucTap;
USE HDThucTap;
go
CREATE TABLE tblGiangVien(
Magv int primary key,
Hotengv char(30),
Bomon char(50));
go
CREATE TABLE TBLSinhVien(
Masv int primary key,
Hotensv char(30),
Namsinh int,
Quequan char(30));
go
CREATE TABLE TBLDeTai(
Madt char(10)primary key,
Tendt char(30),
Kinhphi decimal(10,2));
go
CREATE TABLE TBLHuongDan(
Masv int primary key,
Madt char(10)foreign key references TBLDeTai,
Magv int foreign key references TBLGiangVien,
KetQua decimal(5,2));

-- chèn thêm bảng giảng viên 
INSERT INTO TBLGiangVien VALUES
(1001,'Lê Giáp','Hệ Thống Máy Tính'),
(1002,'Trần Ất','Khoa Học Máy Tính'),
(1003,'Bùi Bình','Mạng và Truyền thông'),
(1004,'Phan Định','Kỹ thuật phần mềm'),
(1005,'Nguyễn Mậu','Hệ thống thông tin');

-- chèn bảng sinh viên 
INSERT INTO TBLSinhVien VALUES
(1,'Le Van Xuan',1990,'Nghe An'),
(2,'Tran Nguyen Ha',1990,'Thanh Hóa'),
(3,'Bui Xuân Thu',1992,'Nghe An'),
(4,'Phan Tuan Đong',null,'Ha Tinh'),
(5,'Le Thanh Xuan',1989,'Ha Noi'),
(6,'Nguyen Thu Ha',1991,'Thanh Hoa'),
(7,'Tran Xuân Tay',null,'Ha Tinh'),
(8,'Hoang Long Nam',1992,'Nam Đinh');

-- chèn bảng đề tài 
INSERT INTO TBLDeTai VALUES
('DT01','Semantic web',100),
('DT02','Cloud computing',500),
('DT03','Macgine learning',100),
('DT04','Data mining',300);

-- chèn bảng hướng dẫn
INSERT INTO TBLHuongDan VALUES
(1,'Dt01',1001,8),
(2,'Dt03',1002,0),
(3,'Dt03',1003,10),
(5,'Dt04',1004,7),
(6,'Dt01',1005,Null),
(7,'Dt04',1001,10),
(8,'Dt03',1005,6);
 
-- --1 đưa ra thông tin cá nhân của tất cả các sinh viên
SELECT * FROM TBLSinhVien

--2 cho biết mã số, họ tên và quê quán của các sinh viên ở 'nghệ an'
SELECT Masv, Hotensv, Quequan
FROM TBLSinhVien
Where Quequan='Nghe An'
--3 cho biết mã số, họ tên và tuổi của tất cả các sinh viên
SELECT Masv, Hotensv, Namsinh
FROM TBLSinhVien
 
--4 cho biết họ tên, năm sinh của các sinh viễn có mã số là 5 và 7
SELECT Hotensv, Namsinh, Masv
FROM TBLSinhVien
WHERE Masv IN(5, 7)
 --5 cho biết họ tên và các sinh viên không ở Nghệ An và Hà Nội
SELECT Hotensv, Quequan
FROM TBLSinhVien
WHERE not (Quequan='Nghe An' and Quequan='Ha Noi')

 -- 6 đưa ra họ tên, năm sinh và quê quán của các sinh viên ở thanh hóa và sinh năm 1990
SELECT Hotensv, Namsinh, Quequan
FROM TBLSinhVien
WHERE Namsinh=1990 and Quequan=('Thanh Hóa')
 
-- 7 cho biết thông tin cá nhân của các sinh viên sinh năm 1990 và có quê ở nghệ an hoặc thanh hóa
SELECT * FROM TBLSinhVien
WHERE Namsinh=1990 and (Quequan=('Nghe An') or Quequan=('Thanh Hóa'))

--8 cho biết thông cá nhân của sinh viên có mã số 1,3,5 và 7
SELECT * FROM TBLSinhvien
WHERE Masv in(1, 3, 5, 7)

--9 đưa ra thông tin gồm tên và kinh phí của các đề tài có kinh phí từ 200 triệu đến 500 triệu đồng và sắp xếp theo thứ tự giảm dần của của kinh phí
SELECT Tendt, Kinhphi
FROM TBLDeTai
WHERE kinhphi between (200) and (500)
order by kinhphi desc; 

--10 cho biết thông tin cá nhân về các sinh viên có họ 'Trần'
SELECT * FROM TBLSinhVien
WHERE Hotensv like 'tran%'

--11 Đưa ra họ tên, năm sinh và quê quán của các sinh viên có tên 'Xuân'
SELECT Hotensv, Namsinh, Quequan
FROM TBLSinhVien
WHERE Hotensv like '%Xuan'

--12 Đưa ra họ tên, năm sinh và quê quán của các sinh viên mà họ và tên
chứa từ 'Xuân'
SELECT Hotensv, Namsinh, Quequan
FROM TBLSinhVien
WHERE Hotensv like '%Xuan%'

--13 Cho biết họ tên, quê quán và mã số của các sinh viên chưa có thông tin năm sinh.
SELECT * FROM TBLSinhVien
WHERE Namsinh IS NULL;

-- 14 Cho biết tổng số sinh viên có trong cơ sở dữ liệu
SELECT COUNT(*) AS TONG  FROM TBLSinhVien
-- 15 Cho biết tổng số sinh viên có quê là ‘Hà Tĩnh’
SELECT COUNT(*) as "co que Ha Tinh"
FROM TBLSinhvien
WHERE quequan='Ha Tinh'

--16 Cho biết số sinh viên của mỗi tỉnh/thành phố có trong cơ sở dữ liệu
SELECT Quequan, COUNT(hotensv) as "so luong sinh vien" 
FROM TBLSinhVien
GROUP BY Quequan;

--17 Cho biết tên tỉnh (tên thành phố) có số sinh viên theo học là 1
SELECT Quequan, COUNT(hotensv) as "so luong sinh vien theo học"
FROM TBLSinhVien
GROUP BY Quequan Having COUNT(Masv)=1;

--18. Cho biết mã số của giảng viên hướng dẫn thực tập nhiều hơn một sinh viên
SELECT GV.Magv
FROM TBLGiangVien GV
WHERE GV.Magv IN (
SELECT HD.Magv
FROM TBLHuongDan HD
GROUP BY HD.Magv HAVING COUNT(HD.Magv)>1);
--19.Cho biết mã số của các đề tài có nhiều hơn 3 sinh viên thực tập
SELECT DT.Madt,DT.Tendt
FROM TBLDeTai DT
WHERE DT.Madt in (  SELECT HD.Madt
                    FROM TBLHuongDan HD
                    GROUP BY HD.Madt
                    HAVING COUNT(HD.Madt) > 3)

--20.Cho biết mã số của các sinh viên chưa có điểm thực tập.
SELECT * FROM TBLSinhVien SV JOIN TBLHuongDan HD
ON HD.Masv = SV.Masv
WHERE HD.KetQua is Null
--21. Cho biết mã số, họ tên của các sinh viên có điểm thực tập cao nhất
SELECT DT.Madt,DT.Tendt
FROM TBLDeTai DT 
WHERE DT.Kinhphi = (
SELECT MAX(DT.Kinhphi)
FROM TBLDeTai DT)
--22.Cho biết tên các đề tài không có sinh viên nào thực tập
SELECT DT.Madt,DT.Tendt
FROM TBLDeTai DT
WHERE NOT EXISTS(
SELECT HD.Madt
FROM TBLHuongDan HD
WHERE HD.Madt = DT.Madt)