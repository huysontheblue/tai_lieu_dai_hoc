-------------------------------- LAB3-------------------------------------------

--Tao Kieu doi tuoNG KHOA dÀO Tao
CREATE OR REPLACE TYPE type_KhoaDaoTao AS OBJECT 
    (   
        MaKhoa NUMBER, 
        TenKhoa VARCHAR2(100), 
        DienThoai NUMBER
    );
    
--Tao Kieu doi tuoNG SINH VIÊN
CREATE OR REPLACE TYPE type_SinhVien AS OBJECT 
    (
        Maso NUMBER, 
        Hoten VARCHAR2(30), 
        Namsinh NUMBER,
        NganhHoc REF type_KhoaDaoTao
    );

--Tao bang doi tuoNG tbl_KhoaDaoTao
CREATE TABLE tbl_KhoaDaoTao OF type_KhoaDaoTao;

--Tao bang doi tuoNG tbl_SinhVien
CREATE TABLE tbl_SinhVien OF type_SinhVien;

-- Thêm du lieu vào bang tbl_KhoaDaoTao

INSERT INTO tbl_KhoaDaoTao VALUES (1, 'Công ngh? thông tin', 0238888);
INSERT INTO tbl_KhoaDaoTao VALUES (2, 'Khoa h?c máy tính', 0238666);


-- Thêm du lieu vào bang tbl_SinhVien

INSERT INTO tbl_SinhVien VALUES (2022, 'Nguyen', 2000, NULL);

INSERT INTO tbl_SinhVien VALUES (2023, 'Le', 2001, null);
UPDATE tbl_SinhVien sv SET NganhHoc = (select ref(k) from tbl_KhoaDaoTao k where k.MaKhoa=1) where sv.Maso = 2023;

INSERT INTO tbl_SinhVien VALUES (2024, 'Tran', 2000, null);
UPDATE tbl_SinhVien sv SET NganhHoc = (select ref(k) from tbl_KhoaDaoTao k where k.MaKhoa=2) where sv.Maso = 2024;

INSERT INTO tbl_SinhVien VALUES (2025, 'Hoang', 1999, null);
UPDATE tbl_SinhVien sv SET NganhHoc = (select ref(k) from tbl_KhoaDaoTao k where k.MaKhoa=1) where sv.Maso = 2025;

-- S? dung DEREF(ten_cot_kieu_REF).Ten_thuoc_tinh ?? hi?n th? thông tin ki?u REF
select sv.Maso, sv.HoTen, sv.Namsinh, DEREF(sv.NganhHoc).TenKhoa as Thuoc_Khoa from tbl_SinhVien sv;

-- Thay ??i mã khoa cho sinh viên có mã 2022 thành 2
UPDATE tbl_SinhVien sv SET NganhHoc = (select ref(k) from tbl_KhoaDaoTao k where k.MaKhoa=2) where sv.Maso = 2022;





















