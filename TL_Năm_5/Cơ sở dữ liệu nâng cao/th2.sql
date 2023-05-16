-- Mô hình quan he

CREATE TABLE NhanVien (MaSoNV CHAR(10) NOT NULL, HoTen VARCHAR2(20), NamSinh NUMBER, PRIMARY KEY (MaSoNV));

CREATE TABLE NgoaiNgu (MaSoNN CHAR(10) NOT NULL, TenNN VARCHAR2(20), TrinhDoNN VARCHAR(20), PRIMARY KEY (MaSoNN));

CREATE TABLE NhanVien_NgoaiNgu (MaSoNV CHAR(10) NOT NULL, MaSoNN CHAR(10) NOT NULL, PRIMARY KEY (MaSoNV, MaSoNN), 
FOREIGN KEY (MaSoNV) REFERENCES NhanVien (MaSoNV), FOREIGN KEY (MaSoNN) REFERENCES NgoaiNgu (MaSoNN));

INSERT INTO NhanVien VALUES ('NV1','Tran Van A',1999);

INSERT INTO NgoaiNgu VALUES ('NN01','Tieng Anh','B1');

INSERT INTO NhanVien_NgoaiNgu VALUES ('NV1','NN01');

SELECT NV.* FROM NhanVien NV;

SELECT NN.* FROM NgoaiNgu NN;

SELECT NVNN.* FROM NhanVien_NgoaiNgu NVNN;

SELECT NV.MaSoNV, HoTen, NamSinh, NN.MaSoNN, TenNN, TrinhDoNN FROM NhanVien NV JOIN NhanVien_NgoaiNgu NVNN 
ON NV.MaSoNV = NVNN.MaSoNV
JOIN NgoaiNgu NN 
ON NN.MaSoNN = NVNN.MaSoNN


--------------------------------------------------------------------------------------------------------------
-- Mô hình quan he - doii tuonng dùng Varray

CREATE OR REPLACE TYPE TrinhDoNN AS OBJECT(TenNgoaiNgu VARCHAR(20), TrinhDo CHAR(20));

CREATE OR REPLACE TYPE Kieu_bang_ngoai_ngu AS VARRAY(5) OF TrinhDoNN;

CREATE TABLE Tbl_nhan_vien(MaNV NUMBER(10), Ho_ten_NV  VARCHAR(20), Namsinh NUMBER(10), Ngoai_ngu Kieu_bang_ngoai_ngu );

INSERT INTO Tbl_nhan_vien VALUES ( 1, 'Cao Thanh Son', 1997, ( Kieu_bang_ngoai_ngu(TrinhDoNN ('Anh','A1'), TrinhDoNN ('??c','A2'), TrinhDoNN ('Pháp','B1') ) ) )

SELECT nv.Ho_ten_NV, nn.TenNgoaiNgu, nn.TrinhDo  
FROM Tbl_nhan_vien nv, table(nv.Ngoai_ngu) nn

------------------------------------------------------------------------------------------------------------------

-- Mô hình quan he - doii tuong dùng Nested Table

CREATE OR REPLACE TYPE TrinhDoNN AS OBJECT(TenNgoaiNgu VARCHAR(20), TrinhDo CHAR(20));

CREATE OR REPLACE TYPE Kieu_Nested_Table_ngoai_ngu IS TABLE OF TrinhDoNN ;

CREATE TABLE Tbl_NhanVien (MaNV NUMBER(10), Ho_ten_NV  VARCHAR(20), Namsinh NUMBER(10), Ngoai_ngu Kieu_Nested_Table_ngoai_ngu )
NESTED TABLE Ngoai_ngu STORE AS nested_tab_nv;

INSERT INTO Tbl_NhanVien VALUES ( 1, 'Tran Van B', 1999, ( Kieu_Nested_Table_ngoai_ngu (TrinhDoNN ('??c','A1'), TrinhDoNN ('Pháp','A2')) ) )

SELECT nv.MaNV,  nv.Ho_ten_NV,  nn.*  FROM Tbl_NhanVien nv, table(nv.Ngoai_ngu) nn
