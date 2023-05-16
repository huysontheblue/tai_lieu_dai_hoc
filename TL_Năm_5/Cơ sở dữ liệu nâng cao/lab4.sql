
-- khai b�o tap thuc the nguoi

CREATE OR REPLACE TYPE kieu_nguoi AS OBJECT
(
    maso NUMBER,
    hoten VARCHAR2(30),
    dienthoai VARCHAR2(20),
    namsinh NUMBER,
    MEMBER FUNCTION tuoi RETURN NUMBER -- khai b�o ph??ng th?c
) NOT FINAL;

DROP TYPE kieu_nguoi FORCE;


CREATE OR REPLACE TYPE BODY kieu_nguoi IS
MEMBER FUNCTION tuoi RETURN NUMBER IS
BEGIN
    RETURN EXTRACT(YEAR FROM SYSDATE)-namsinh;
END tuoi;
END;

-- Khai b�o t?p th?c th? sinh vi�n k? th?a t?p th?c th? NGU?I v� c� th�m thu?c t�nh ng�nh h?c
CREATE OR REPLACE TYPE sinh_vien UNDER kieu_nguoi
(
    nganhhoc VARCHAR2(30)
);

-- T?p th?c th? nh�n vi�n k? th?a t?p th?c th? NGU?I v� c� th�m thu?c t�nh luong
CREATE OR REPLACE TYPE nhan_vien UNDER kieu_nguoi
(
    luong NUMBER
) NOT FINAL;

-- T?p th?c th? nh�n vi�n t�nh gi? k? th?a t?p th?c th? NHAN_VI�N v� c� th�m thu?c t�nh s? gi? l�m

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

-- 2. Cho bi?t m� s?, h? t�n v� ng�nh h?c c?a c�c sinh vi�n
SELECT TREAT(VALUE(N) AS sinh_vien).hoten, TREAT(VALUE(N) AS sinh_vien).nganhhoc
FROM tblNguoi N
WHERE VALUE(N) IS OF (sinh_vien);

-- 3. Cho bi?t h? t�n v� luong c?a t?t c? nh�n vi�n
SELECT TREAT(VALUE(N) AS nhan_vien).hoten, TREAT(VALUE(N) AS nhan_vien).luong
FROM tblNguoi N
WHERE VALUE(N) IS OF (nhan_vien);

--4. �ua ra h? t�n d?a ch? c�c c� nh�n kh�ng ph?i l� sinh vi�n cung kh�ng ph?i l� nh�n vi�n
SELECT n.maso, n.hoten,
FROM tblNguoi N
WHERE VALUE(N) IS NOT OF (sinh_vien) and VALUE(N) IS NOT OF (nhan_vien);

--5. X�a sinh vi�n c� m� s? 2022
DELETE FROM tblNguoi N
WHERE VALUE(N) IS OF (sinh_vien)
AND TREAT(VALUE(N) AS sinh_vien).maso=2022;


--6. Thay d?i d?a ch? c?a sinh vi�n c� m� s? 15 th�nh 'Ngh? An'

--7. �ua ra h? t�n, tu?i v� luong c?a c�c nh�n vi�n



























































 