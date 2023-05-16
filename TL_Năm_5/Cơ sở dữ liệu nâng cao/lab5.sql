
-- tao doi tuong
CREATE OR REPLACE TYPE sinh_vien_type AS OBJECT
(
    maso NUMBER,
    hoten VARCHAR2(30),
    gioitinh VARCHAR2(5),
    sdt NUMBER,
    email VARCHAR2(100),
    MAP MEMBER FUNCTION get_maso RETURN NUMBER,
    MEMBER PROCEDURE display_address ( SELF IN OUT NOCOPY sinh_vien_type )
);

DROP TYPE sinh_vien_type FORCE;

-- phan than phuong thuc
CREATE TYPE BODY sinh_vien_type AS
    MAP MEMBER FUNCTION get_maso RETURN NUMBER IS
BEGIN
    RETURN maso;
END;
    MEMBER PROCEDURE display_address ( SELF IN OUT NOCOPY sinh_vien_type ) IS
BEGIN
    DBMS_OUTPUT.PUT_LINE(hoten);
    DBMS_OUTPUT.PUT_LINE(gioitinh);
    DBMS_OUTPUT.PUT_LINE(sdt);
    DBMS_OUTPUT.PUT_LINE(email);
END;
END;

--2 tao bang doi tuong 
CREATE TABLE tblsinhvien OF sinh_vien_type;

-- 3. L?p trình PL/SQL ?? nh?p ??y ?? thông tin cho ít nh?t 3 sinh viên
DECLARE
    emp sinh_vien_type;
BEGIN
    INSERT INTO tblsinhvien VALUES (sinh_vien_type(1, 'PHAN', 'nam', 0123456, 'phan@gmail.com'));
    INSERT INTO tblsinhvien VALUES (sinh_vien_type(2, 'XUÂN', 'n?', 0123456, 'xuan@gmail.com'));
    INSERT INTO tblsinhvien VALUES (sinh_vien_type(3, 'KIÊN', 'nam', 0123456, 'kien@gmail.com'));
END;

-- 4. L?p trình PL/SQL ??a ra mã s?, h? tên, gi?i tính, s? ?i?n tho?i và email c?a sinh viên có mã 2022
DECLARE
    emp sinh_vien_type;
BEGIN
    SELECT VALUE(e) INTO emp FROM tblsinhvien e 
    WHERE e.maso = 1;
    emp.display_address();
END;

--5. L?p trình PL/SQL thay ??i s? ?i?n tho?i c?a sinh viên có mã 2021
DECLARE
    emp employee_typ;
BEGIN
    INSERT INTO tblsinhvien VALUES (sinh_vien_type(1, 'Nguyen', 'New', address_typ('xa new', 'Huyen New', 'tinh New')) );
    UPDATE employee_tab e SET e.address.street = '182 Le Duan'
    WHERE e.employee_id = 2020;
END;/
