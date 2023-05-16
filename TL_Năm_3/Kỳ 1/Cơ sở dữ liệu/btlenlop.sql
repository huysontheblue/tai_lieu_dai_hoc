CREATE DATABASE baitaplenlop;

USE baitaplenlop

CREATE TABLE NCC
(
   SHNCC char (20) primary key,
   TENNCC char(50),
   DIACHI char(20),
   DIENTHOAI float,
);

CREATE TABLE MH
(
   SHMH INT PRIMARY KEY,
   DVT NVARCHAR(5) ,
   TENMH CHAR(50),
   DONGGIA INT,
);

CREATE TABLE CUNG_UNG
(
   SHNCC CHAR (20) ,
   SHMH INT,
   SOLUONG INT not null,
  CONSTRAINT dho_cung_ung PRIMARY KEY (SHNCC, SHMH) 
); 


INSERT INTO NCC VALUES
('NCC009','Tap doan Dong Nam A','Thanh Hoa', 05113987121),
('NCC010','Cong ty co phan Rang Dong','Nghe An',05113569654);

INSERT INTO MH VALUES
(002,'bo','My Pham' ,2),
(003,'chiec','Do Gia Dung',3),
(004,'chiec','Do dien tu',4);

INSERT INTO CUNG_UNG VALUES
('NCC006',004,69),
('NCC007',001,56),
('NCC008',002,56),
('NCC009',002,21),
('NCC010',004,54);

SELECT * FROM NCC
SELECT * FROM MH
SELECT * FROM CUNG_UNG

--1. Cho biết số hiệu các nhà cung cấp đã cung ứng ít nhất một mặt hàng
SELECT DISTINCT SHNCC
FROM CUNG_UNG

-- 2.Cho biết số hiệu và tên các nhà cung cấp không cung ứng một mặt hàng nào
-- cach 1
SELECT TENNCC, SHNCC
FROM NCC
where SHNCC NOT IN( SELECT SHNCC 
FROM CUNG_UNG)
-- cach 2
SELECT TENNCC, SHNCC
FROM NCC
WHERE NOT EXISTS ( SELECT * FROM CUNG_UNG
WHERE NCC.SHNCC=CUNG_UNG.SHNCC)

--3.Cho xem số hiệu,tên,điện thoại của các nhà cung cấp đã cung ứng mặt hàng có số hiệu 20
SELECT SHNCC, TENNCC, DIENTHOAI
FROM NCC
WHERE SHNCC IN ( SELECT SHNCC
FROM CUNG_UNG
WHERE SHMH = 20); 
-- 4.Cho biết số lượng các nhà cung cấp có địa chỉ ở 'Nghệ An'
SELECT COUNT(*) AS SOLUONG
FROM NCC
WHERE DIACHI='Nghe An'
--5.Cho biết số lượng các nhà cung cấp đã cung ứng các mặt hàng
SELECT COUNT(*) AS "MH"
FROM NCC 
WHERE SHNCC IN (SELECT SHNCC


//6.Đưa ra tên các mặt hàng và số lượng đã cung ứng
SELECT TENMH, SOLUONG
FROM CUNG_UNG JOIN MH
WHERE 

//7.Cho biết tên đơn giá và số lượng của các mặt hàng do nhà cung cấp có mã 'S1' cung ứng, yêu cầu sắp xếp giảm dần theo số lượng



//8.Cho biết tên, đơn giá và số lượng của các mặt hàng do nhà cung cấp có tên 'ABC' cung ứng, yêu cầu sắp xếp giảm dần theo số lượng