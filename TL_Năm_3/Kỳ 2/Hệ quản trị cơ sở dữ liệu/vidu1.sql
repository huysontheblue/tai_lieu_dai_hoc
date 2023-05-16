CREATE DATABASE vidu; 
USE vidu; 
CREATE TABLE canbo
(macb int primary key, ten varchar(15), namsinh int )
INSERT INTO canbo VALUES
(1,'May', 1990),
(2,'Hoc', 1991),
(3,'Nam', 1992),
(4,'Ngoc',1995),
(5,'My', 1993),
(6,'Hieu', 1994)
--
USE vidu
DECLARE @soluongcb int
SET @soluongcb=(SELECT COUNT(*) FROM canbo)
PRINT @soluongcb
--
USE vidu
DECLARE @soluongcb int
SELECT @soluongcb=COUNT(*) FROM canbo
PRINT @soluongcb
--
DECLARE @bien1 int, @bien2 varchar(15), @bien3 int
SELECT TOP 6 @bien1 = macb, @bien2 = ten, @bien3 =namsinh
FROM canbo
PRINT @bien1
PRINT @bien2
PRINT @bien3
--khối lệnh 
-- BEGIN
  -- khai báo biến
  -- các lệnh T-SQL
-- END
--Một chương trình viết bằng T-SQL có thể chia thành nhiều lô (batch) để xử lý.
--Mỗi lô là một(một nhóm) các lệnh T-SQL được phân cách nhau
--bằng lệnh GO.
SELECT * FROM canbo
go
--Xử lý lô (Batch)
DECLARE @cb_id int
SET @CB_ID=1
PRINT @CB_id
GO
--Ví dụ cho CSDL có 2 bảng
CREATE TABLE HocPhan
(MaHP char(5), 
TenHP varchar (30), 
SiSo int)
CREATE TABLE DangKyHoc
(MaSV char(10), 
MaHP char(5)) 
-- Ví dụ
Declare @SiSo int
select @SiSo = SiSo from HocPhan where MaHP='HP01'
if @SiSo < 30
Begin
insert into DangKyHoc(MaSV, MaHP)
values('2020',' HP01')
print N'Đăng ký thành công'
End
Else
print N'Học phần đã đủ số lượng'