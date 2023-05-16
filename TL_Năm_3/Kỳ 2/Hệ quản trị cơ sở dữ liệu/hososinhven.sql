create database HoSoSV
use HoSoSV

create table Nganh_Hoc
(MaNganh int primary key,
TenNganh nvarchar(50),
MaKhoa char(30) foreign key references KHOA_CHUYEN_NGANH )

create table KHOA_CHUYEN_NGANH
(Makhoa char(30)primary key,
 Tenkhoa char(30))

create table Lop
(MaLop char(10)primary key,
TenLop char(30),
MaNganh int foreign key references Nganh_Hoc,
KhoaHoc datetime)

create table Sinh_vien 
(MaSinhVien int primary key,
HoTen nvarchar(50),
NgaySinh datetime,
QueQuan nvarchar(100),
GioiTinh char(4),
Malop char(10) foreign key references Lop)