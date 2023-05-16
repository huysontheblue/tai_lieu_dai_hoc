use HuySon
go
CREATE table tblKhoa
(
makhoa CHAR(5) primary key,
tenkhoa nvarchar(20) not null,
dienthoai  int not null
);
go 
CREATE TABLE tblSinhVien
(
mssv INT primary key,
hoten NVARCHAR(30) not null,
makhoa CHAR(5) not null,
ns INT,
que CHAR(30)
);
INSERT INTO TBLKhoa VALUES
('Lý','DIA LY VA TAI NGUYEN',3855413),
('Toán','Su pham toan',3855411),
('Sinh','Cong nghe Sinh hoc',3855412);
--chen nam sinh que quan
INSERT INTO tblSinhVien VALUES
(1,'Le Van Son','Sinh',1994,'Nghe An'),
(2,'Nguyen Thi Mai','Lý',1990,'Thanh Hoa'),
(3,'Bui Xuan Duc','Toan',1992,'Ha Tinh'),
(4,'Nguyen Van Tung','Sinh',null,'Ha Tinh'),
(5,'Le Khanh Linh','Toán',1994,'Thanh Hoa'),
(6,'Tran Khac Trong','Lý',1992,'Thanh Hoa'),
(7,'Le Thi Van','Toán',1990,'Ha Tinh'),
(8,'Hoang Van Duc','Sinh',1992,'Nghe An');
-- cho xem tat ca cac cot cac dong
SELECT * FROM tblSinhVien
SELECT * FROM tblKhoa
-- A cho biet ho ten, que quan cac sinh vien nam 1994, 1992
SELECT hoten, que, ns
FROM tblSinhvien
WHERE ns in(1992, 1994)
-- B cho biet thong tin cac sinh vien khong co que o nghe an
SELECT que, ns, hoten, mssv, makhoa
from tblSinhvien 
where not (que='Nghe An')
-- C đưa ra số điện thoại của khoa Dia Ly Tai Nguyen
SELECT dienthoai, tenkhoa
FROM tblKhoa
WHERE tenkhoa in('DIA LY VA TAI NGUYEN')
-- D cho biet thong tin cac sinh vien ở Nghệ An và Thanh hóa
SELECT mssv, hoten, makhoa, ns, que
FROM tblSinhvien
WHERE que=('Nghe An') or que=('Thanh Hoa')
-- E cho biết thông tin các sinh viên năm 1990 có quê Hà Tính hoặc Nghệ An
SELECT mssv, hoten, makhoa, ns, que
FROM tblSinhVien
WHERE ns=(1990) and (que=('Ha Tinh') or que=('Nghe An')) 
-- giảm dần theo cột, giảm dần= desc
SELECT hoten as 'họ tên', ns as Namsinh 
from tblSinhVien
 order by ns asc;