-------------------------------- LAB3-------------------------------------------

--Tao Kieu doi tuoNG KHOA d�O Tao
CREATE OR REPLACE TYPE type_KhoaDaoTao AS OBJECT 
    (   
        MaKhoa NUMBER, 
        TenKhoa VARCHAR2(100), 
        DienThoai NUMBER
    );
    
--Tao Kieu doi tuoNG SINH VI�N
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

-- Th�m du lieu v�o bang tbl_KhoaDaoTao

INSERT INTO tbl_KhoaDaoTao VALUES (1, 'C�ng ngh? th�ng tin', 0238888);
INSERT INTO tbl_KhoaDaoTao VALUES (2, 'Khoa h?c m�y t�nh', 0238666);


-- Th�m du lieu v�o bang tbl_SinhVien

INSERT INTO tbl_SinhVien VALUES (2022, 'Nguyen', 2000, NULL);

INSERT INTO tbl_SinhVien VALUES (2023, 'Le', 2001, null);
UPDATE tbl_SinhVien sv SET NganhHoc = (select ref(k) from tbl_KhoaDaoTao k where k.MaKhoa=1) where sv.Maso = 2023;

INSERT INTO tbl_SinhVien VALUES (2024, 'Tran', 2000, null);
UPDATE tbl_SinhVien sv SET NganhHoc = (select ref(k) from tbl_KhoaDaoTao k where k.MaKhoa=2) where sv.Maso = 2024;

INSERT INTO tbl_SinhVien VALUES (2025, 'Hoang', 1999, null);
UPDATE tbl_SinhVien sv SET NganhHoc = (select ref(k) from tbl_KhoaDaoTao k where k.MaKhoa=1) where sv.Maso = 2025;

-- S? dung DEREF(ten_cot_kieu_REF).Ten_thuoc_tinh ?? hi?n th? th�ng tin ki?u REF
select sv.Maso, sv.HoTen, sv.Namsinh, DEREF(sv.NganhHoc).TenKhoa as Thuoc_Khoa from tbl_SinhVien sv;

-- Thay ??i m� khoa cho sinh vi�n c� m� 2022 th�nh 2
UPDATE tbl_SinhVien sv SET NganhHoc = (select ref(k) from tbl_KhoaDaoTao k where k.MaKhoa=2) where sv.Maso = 2022;





















