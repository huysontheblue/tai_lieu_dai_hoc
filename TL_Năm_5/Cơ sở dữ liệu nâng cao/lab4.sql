
-- khai báo tap thuc the nguoi

CREATE OR REPLACE TYPE kieu_nguoi AS OBJECT
(
    maso NUMBER,
    hoten VARCHAR2(30),
    dienthoai VARCHAR2(20),
    namsinh NUMBER,
    MEMBER FUNCTION tuoi RETURN NUMBER -- khai báo ph??ng th?c
) NOT FINAL;

DROP TYPE kieu_nguoi FORCE;


CREATE OR REPLACE TYPE BODY kieu_nguoi IS
MEMBER FUNCTION tuoi RETURN NUMBER IS
BEGIN
    RETURN EXTRACT(YEAR FROM SYSDATE)-namsinh;
END tuoi;
END;

-- Khai báo t?p th?c th? sinh viên k? th?a t?p th?c th? NGU?I và có thêm thu?c tính ngành h?c
CREATE OR REPLACE TYPE sinh_vien UNDER kieu_nguoi
(
    nganhhoc VARCHAR2(30)
);

-- T?p th?c th? nhân viên k? th?a t?p th?c th? NGU?I và có thêm thu?c tính luong
CREATE OR REPLACE TYPE nhan_vien UNDER kieu_nguoi
(
    luong NUMBER
) NOT FINAL;

-- T?p th?c th? nhân viên tính gi? k? th?a t?p th?c th? NHAN_VIÊN và có thêm thu?c tính s? gi? làm

CREATE OR REPLACE TYPE nhan_vien_tinh_gio UNDER nhan_vien
(
    so_gio_lam NUMBER
);

-- T?o b?ng ngu?i
CREATE TABLE tblNguoi OF kieu_nguoi;
drop table tblNguoi;

--1 Nh?p d? li?u
INSERT INTO tblNguoi VALUES (kieu_nguoi(1,'SON', 0388580624, 2000));

INSERT INTO tblNguoi VALUES (sinh_vien(2,'GIAP', 023455689, 2000, 'CNTT'));

INSERT INTO tblNguoi VALUES (nhan_vien(3,'KIEN', 012345678, 1999, 5000000));

INSERT INTO tblNguoi VALUES (nhan_vien_tinh_gio(4,'DINH', 098765432, 2001, 4500000, 100));

-- 2. Cho bi?t mã s?, h? tên và ngành h?c c?a các sinh viên
SELECT TREAT(VALUE(N) AS sinh_vien).hoten, TREAT(VALUE(N) AS sinh_vien).nganhhoc
FROM tblNguoi N
WHERE VALUE(N) IS OF (sinh_vien);

-- 3. Cho bi?t h? tên và luong c?a t?t c? nhân viên
SELECT TREAT(VALUE(N) AS nhan_vien).hoten, TREAT(VALUE(N) AS nhan_vien).luong
FROM tblNguoi N
WHERE VALUE(N) IS OF (nhan_vien);

--4. Ðua ra h? tên d?a ch? các cá nhân không ph?i là sinh viên cung không ph?i là nhân viên
SELECT n.maso, n.hoten,
FROM tblNguoi N
WHERE VALUE(N) IS NOT OF (sinh_vien) and VALUE(N) IS NOT OF (nhan_vien);

--5. Xóa sinh viên có mã s? 2022
DELETE FROM tblNguoi N
WHERE VALUE(N) IS OF (sinh_vien)
AND TREAT(VALUE(N) AS sinh_vien).maso=2022;


--6. Thay d?i d?a ch? c?a sinh viên có mã s? 15 thành 'Ngh? An'

--7. Ðua ra h? tên, tu?i và luong c?a các nhân viên



























































 