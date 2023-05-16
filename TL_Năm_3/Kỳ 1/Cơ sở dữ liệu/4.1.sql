CREATE DATABASE Nha_xe

use Nha_xe


CREATE TABLE NHACUNGCAP
(
	MaNhaCC char(6) PRIMARY KEY,
	TenNhaCC nvarchar(50),
	DiaChi nvarchar(15),
	SoDT varchar(15),
	MaSoThue varchar(10)
)

CREATE TABLE LOAIDICHVU
(
	MaLoaiDV char(4) PRIMARY KEY,
	TenLoaiDV nvarchar(50)
)

CREATE TABLE MUCPHI
(
	MaMP char(4) PRIMARY KEY,
	DonGia numeric(18,0),
	MoTa nvarchar(30)
)

CREATE TABLE DONGXE
(
	DongXe varchar(15) PRIMARY KEY,
	HangXe varchar(15),
	SoChoNgoi int
)

CREATE TABLE DANGKYCUNGCAP
(
	MaDKCC char(5) PRIMARY KEY,
	MaNhaCC char(6),
	MaLoaiDV char(4),
	DongXe varchar(15),
	MaMP char(4),
	NgayBatDauCungCap date,
	NgayKetThucCungCap date,
	SoLuongXeDangKy int,
	CONSTRAINT FK_DANGKYCUNGCAP_NHACUNGCAP FOREIGN KEY (MaNhaCC) REFERENCES NHACUNGCAP(MaNhaCC),
	CONSTRAINT FK_DANGKYCUNGCAP_LOAIDICHVU FOREIGN KEY (MaLoaiDV) REFERENCES LOAIDICHVU(MaLoaiDV),
	CONSTRAINT FK_DANGKYCUNGCAP_DONGXE FOREIGN KEY (DongXe) REFERENCES DONGXE(DongXe),
	CONSTRAINT FK_DANGKYCUNGCAP_MUCPHI FOREIGN KEY (MaMP) REFERENCES MUCPHI(MaMP)
)

INSERT INTO NHACUNGCAP VALUES 
('NCC001',N'Cty TNHH Toàn Pháp',N'Hải Châu','05113999888','568941'),
('NCC002',N'Cty cổ phần Đông Du',N'Liên Chiểu','05113999889','456789'),
('NCC003',N'Ông Nguyễn Văn A',N'Hòa Thuận','05113999890','321456'),
('NCC004',N'Cty cổ phần Toàn Cầu Xanh',N'Hải Châu','05113658945','513364'),
('NCC005',N'Cty TNHH AMA',N'Thanh Khê','05113875466','546546'),
('NCC006',N'Bà Trần Thị Bích Vân',N'Liên Chiểu','05113587469','524545'),
('NCC007',N'Cty TNHH Phan Thành',N'Thanh Khê','05113987456','113021'),
('NCC008',N'Ông Phan Đình Nam',N'Hòa Thuận','05113532446','234562'),
('NCC009',N'Tập đoàn Đông Nam Á',N'Liên Chiểu','05113987121','534235'),
('NCC010',N'Cty Cổ phần Rạng Đông',N'Liên Chiểu','05113569654','432465')

INSERT INTO LOAIDICHVU VALUES 
('DV01',N'Dịch vụ xe taxi'),
('DV02',N'Dịch vụ xe buýt công cộng theo tuyến cố định'),
('DV03',N'Dịch vụ xe cho thuê theo hợp đồng')

INSERT INTO MUCPHI VALUES 
('MP01',10000, N'Áp dụng từ 1/2015'),
('MP02',15000, N'Áp dụng từ 2/2015'),
('MP03',20000, N'Áp dụng từ 1/2010'),
('MP04',25000, N'Áp dụng từ 2/2011')


INSERT INTO DONGXE VALUES 
('Hiace','Toyota', 16),
('Vios','Toyota', 5),
('Escape','Ford', 5),
('Cerato','KIA', 7),
('Forte','KIA', 5),
('Starex','Huyndai', 7),
('Grand-i10','Huyndai', 7)


INSERT INTO DANGKYCUNGCAP VALUES 
('DK001','NCC001','DV01','Hiace','MP01','2015-11-20','2016-11-20',4),
('DK002','NCC002','DV02','Vios','MP02','2015-11-20','2017-11-20',3),
('DK003','NCC003','DV03','Escape','MP03','2017-11-20','2018-11-20',5),
('DK004','NCC005','DV01','Cerato','MP04','2015-11-20','2019-11-20',7),
('DK005','NCC002','DV02','Forte','MP03','2019-11-20','2020-11-20',1),
('DK006','NCC004','DV03','Starex','MP04','2016-11-10','2021-11-20',2),
('DK007','NCC005','DV01','Cerato','MP03','2015-11-30','2016-01-25',8),
('DK008','NCC006','DV01','Vios','MP02','2016-02-28','2016-08-15',9),
('DK009','NCC005','DV03','Grand-i10','MP02','2016-04-27','2017-04-30',10),
('DK010','NCC006','DV01','Forte','MP02','2015-11-21','2016-02-22',4),
('DK011','NCC007','DV01','Forte','MP01','2016-12-25','2017-02-20',5),
('DK012','NCC007','DV03','Cerato','MP01','2016-04-14','2017-12-20',6),
('DK013','NCC003','DV02','Cerato','MP01','2015-12-21','2016-12-21',8),
('DK014','NCC008','DV02','Cerato','MP01','2016-05-20','2016-12-30',1),
('DK015','NCC003','DV01','Hiace','MP02','2018-04-24','2019-11-20',6),
('DK016','NCC001','DV03','Grand-i10','MP02','2016-06-22','2016-12-21',8),
('DK017','NCC002','DV03','Cerato','MP03','2016-09-30','2019-09-30',4),
('DK018','NCC008','DV03','Escape','MP04','2017-12-13','2018-09-30',2),
('DK019','NCC003','DV03','Escape','MP03','2016-01-24','2016-12-30',8),
('DK020','NCC002','DV03','Cerato','MP04','2016-05-03','2017-10-21',7),
('DK021','NCC006','DV01','Forte','MP02','2015-01-30','2016-12-30',9),
('DK022','NCC002','DV02','Cerato','MP04','2016-07-25','2017-12-30',6),
('DK023','NCC002','DV01','Forte','MP03','2017-11-30','2018-05-20',5),
('DK024','NCC003','DV03','Forte','MP04','2017-12-23','2019-11-30',8),
('DK025','NCC003','DV03','Hiace','MP02','2016-08-24','2017-10-25',1)


SELECT * FROM NHACUNGCAP
SELECT * FROM LOAIDICHVU
SELECT * FROM MUCPHI
SELECT * FROM DONGXE
SELECT * FROM DANGKYCUNGCAP

--Câu 1: Hãy tự định nghĩa kiểu dữ liệu cho các cột, sau đó tạo đầy đủ lược đồ cơ sở dữ liệu quan hệ như mô tả ở trên. 

--Câu 2: Nhập toàn bộ dữ liệu mẫu đã được minh họa ở trên vào cơ sở dữ liệu

--Câu 3: Liệt kê những dòng xe có số chỗ ngồi trên 5 chỗ

SELECT * FROM DONGXE WHERE SoChoNgoi > 5


/*Câu 4: Liệt kê thông tin của các nhà cung cấp đã từng đăng ký cung cấp những dòng xe
thuộc hãng xe "Toyota" với mức phí có đơn giá là 15.000 VNĐ/km hoặc những dòng xe
thuộc hãng xe "KIA" với mức phí có đơn giá là 20.000 VNĐ/km  */

SELECT DISTINCT N.* 
FROM DONGXE D INNER JOIN DANGKYCUNGCAP DC ON D.DongXe = DC.DongXe
INNER JOIN NHACUNGCAP N ON N.MaNhaCC = DC.MaNhaCC
INNER JOIN MUCPHI M ON M.MaMP = DC.MaMP
WHERE (D.HangXe = 'Toyota' AND M.DonGia = 15000)
OR (D.HangXe = 'Kia' AND M.DonGia = 20000)


/* Câu 5: Liệt kê thông tin toàn bộ nhà cung cấp được sắp xếp tăng dần theo tên nhà cung
cấp và giảm dần theo mã số thuế */

SELECT * FROM NHACUNGCAP
ORDER BY TenNhaCC ASC, MaSoThue DESC



/* Câu 6: Đếm số lần đăng ký cung cấp phương tiện tương ứng cho từng nhà cung cấp với
yêu cầu chỉ đếm cho những nhà cung cấp thực hiện đăng ký cung cấp có ngày bắt đầu
cung cấp là "20/11/2015" */

SELECT MaNhaCC, COUNT(MaDKCC) AS SoLanDangKy
FROM DANGKYCUNGCAP
WHERE NgayBatDauCungCap = '20151120'
GROUP BY MaNhaCC


--Câu 7: Liệt kê tên của toàn bộ các hãng xe có trong cơ sở dữ liệu với yêu cầu mỗi hãng xe chỉ được liệt kê một lần

SELECT DISTINCT HangXe
FROM DONGXE


/*Câu 8: Liệt kê MaDKCC, MaNhaCC, TenNhaCC, DiaChi, MaSoThue, TenLoaiDV, DonGia,
HangXe, NgayBatDauCC, NgayKetThucCC của tất cả các lần đăng ký cung cấp phương
tiện với yêu cầu những nhà cung cấp nào chưa từng thực hiện đăng ký cung cấp phương
tiện thì cũng liệt kê thông tin những nhà cung cấp đó ra*/

SELECT DK.MaDKCC, NCC.MaNhaCC, NCC.TenNhaCC, NCC.DiaChi, NCC.MaSoThue, DV.TenLoaiDV
FROM NHACUNGCAP NCC LEFT JOIN DANGKYCUNGCAP DK ON DK.MaNhaCC = NCC.MaNhaCC
LEFT JOIN LOAIDICHVU DV ON DK.MaLoaiDV = DV.MaLoaiDV



/*Câu 9: Liệt kê thông tin của các nhà cung cấp đã từng đăng ký cung cấp phương tiện 
thuộc dòng xe "Hiace" hoặc từng đăng ký cung cấp phương tiện thuộc dòng xe "Cerato"*/

SELECT DISTINCT NCC.*
FROM DANGKYCUNGCAP DK INNER JOIN DONGXE DX ON DK.DongXe = DX.DongXe
INNER JOIN NHACUNGCAP NCC ON DK.MaNhaCC = NCC.MaNhaCC
WHERE DX.DongXe = 'Hiace' 
AND DK.MaDKCC NOT IN (SELECT MaDKCC FROM DANGKYCUNGCAP WHERE DongXe = 'Cerato')


--Câu 10: Liệt kê thông tin của các nhà cung cấp chưa từng thực hiện đăng ký cung cấp phương tiện lần nào cả

--Cách 1:
SELECT * FROM NHACUNGCAP
WHERE MaNhaCC NOT IN (SELECT MaNhaCC FROM DANGKYCUNGCAP)

--Cách 2:
SELECT * FROM NHACUNGCAP NCC
WHERE NOT EXISTS (SELECT MaNhaCC FROM DANGKYCUNGCAP WHERE MaNhaCC = NCC.MaNhaCC)
