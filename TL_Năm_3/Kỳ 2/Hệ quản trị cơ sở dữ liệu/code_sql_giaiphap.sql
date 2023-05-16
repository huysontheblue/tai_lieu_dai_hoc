create database hoso
use hoso
CREATE TABLE Hocphan
(
	mhp char(4)primary key,
	tenhp char(30),
	sotc int
 );
CREATE TABLE Hoso
(
	msv char(4) primary key,
	hoten nvarchar(50),
	quequan nvarchar(35) 
);
CREATE TABLE Ketqua
(
	msv char(4) primary key,
	mhp char(4)foreign key references Hocphan,
	diem float,
);
INSERT INTO Hocphan VALUES
('hp01','Toan',3),
('hp02','Hoa',4),
('hp03','Sinh hoc',2);
iNSERT INTO Hoso VALUES
('sv1','Thanh Binh','Ha Tinh'),
('sv2','Thu Huong','Nghe An'),
('sv3','Chu Vinh','Thanh Hoa'),
('sv4','Huy Manh','Ha Tinh'),
('sv5','Trung Kien','Nghe An');
INSERT INTO Ketqua VALUES
('sv1','hp01',9),
('sv2','hp02',8),
('sv5','hp03',10),
('sv4','hp01',7.5);

create login dangnhap001 with password ='abc123'

create user huyson for login dangnhap001

grant select on Hoso to huyson

-- Lập trình để User vừa tạo ở Bước 5 chỉ được XEM họ tên, điểm học phần của các sinh viên

 grant select(hoten) on Hoso to huyson

 grant select(diem) on Ketqua to huyson

 -- giải pháp tạo login: có thể tạo login bằng 2 cách là bằng security hoặc là bằng lệnh create login tên login with password =mật khẩu
 -- giải pháp tạo user: có 2 cách tạo  vào data đã tạo vào security rồi vào user cách 2 là bằng lệnh create user tên user for login tên login
 -- giải pháp phân quyền cho 1 cho một sinh viên chỉ được XEM họ tên, điểm học phần của chính mình:theo em thì  
 -- cách 1  dùng lệnh  
 --grant select(hoten) on Hoso to huyson
 --grant select(diem) on Ketqua to huyson
 -- cách 2 là 
 -- grant select(hoten,diem) on Hoso hs join Ketqua kq on hs.msv=kq.msv to huyson




