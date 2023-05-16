CREATE DATABASE Mat_hang
USE Mat_hang

CREATE TABLE LoaiMatHang(MaloaiMatHang CHAR(5) PRIMARY KEY,TenLoaiMatHang NVARCHAR(50));
CREATE TABLE KhuVuc (MaKhuVuc CHAR (5) PRIMARY KEY, TenKhuVuc NVARCHAR(50));
CREATE TABLE KhoangThoiGian (MaKTG CHAR(5) PRIMARY KEY, MoTa NVARCHAR(50));
CREATE TABLE DichVu (MaDichVu CHAR(5) PRIMARY KEY, TenDichVu NVARCHAR(50));
CREATE TABLE ThanhVienGiaoHang (MaThanhVienGiaoHang CHAR (5) PRIMARY KEY, TenThanhVienGiaoHang NVARCHAR(30),NgaySinh CHAR(10),GioiTinh NVARCHAR(3), SoDTThanhVien CHAR (11), DiaChiThanhVien NVARCHAR(50));
CREATE TABLE DangKiGiaoHang ( MaThanhVienGiaoHang CHAR (5), MaKhoangTGDKGiaoHang  CHAR (5));
CREATE TABLE KhachHang (MaKH CHAR (5) PRIMARY KEY, MaKhuVuc CHAR (5),TenKhachHang NVARCHAR(30),TenCuaHang NVARCHAR(10), SoDTKhachHang CHAR (11), Mail CHAR (20), DiaChiNhanHang NVARCHAR(30));
CREATE TABLE ChiTiet_DoHang (MaDonHangGiaoHang CHAR (5) , TenSanPhamDuocGiao NVARCHAR(20) , SoLuong INT , trongLuong FLOAT, 
MaLoaiMatHang CHAR (5), TienThuHo DECIMAL (10,3) CONSTRAINT IDChiTietDonHang PRIMARY KEY (MaDonHangGiaoHang, TenSanPhamDuocGiao));
CREATE TABLE DonHang_GiaoHang (MaDon CHAR (5) PRIMARY KEY, MaKhachHang CHAR (5), MathanhVienGiaoHang CHAR (5),MaDV CHAR (5),
MaKhuVuc CHAR (5), TenNGuoiNhan NVARCHAR(30), DiaChiGiaoHang NVARCHAR(20), SoDTNguoiNhan CHAR(11), MaKhoangTGGH CHAR (5), 
NgayGiaoHang CHAR(10), PhuongThucThanhToan NVARCHAR(15), TrangThaiPheDuyet NVARCHAR(15), TrangThaiGiaoHang NVARCHAR(15));

ALTER TABLE dbo.KhachHang ADD FOREIGN KEY (MaKhuVuc) REFERENCES dbo.KhuVuc (MaKhuVuc);
ALTER TABLE dbo.DangKiGiaoHang ADD FOREIGN KEY (MaKhoangTGDKGiaoHang) REFERENCES dbo.KhoangThoiGian (MaKTG);
ALTER TABLE dbo.ChiTiet_DoHang ADD FOREIGN KEY (MaDonHangGiaoHang) REFERENCES dbo.DonHang_GiaoHang (MaDon);
ALTER TABLE dbo.ChiTiet_DoHang ADD FOREIGN KEY (MaLoaiMatHang ) REFERENCES dbo.LoaiMatHang (MaloaiMatHang);
ALTER TABLE dbo.DonHang_GiaoHang ADD FOREIGN KEY (MaKhachHang) REFERENCES dbo.KhachHang (MaKH);
ALTER TABLE dbo.DonHang_GiaoHang ADD FOREIGN KEY (MaDV) REFERENCES dbo.DichVu (MaDichVu);
ALTER TABLE dbo.DonHang_GiaoHang ADD FOREIGN KEY (MaKhoangTGGH) REFERENCES dbo.KhoangThoiGian (MaKTG);
ALTER TABLE dbo.DonHang_GiaoHang ADD FOREIGN KEY (MaKhuVuc) REFERENCES dbo.KhuVuc (MaKhuVuc);
ALTER TABLE dbo.DonHang_GiaoHang ADD FOREIGN KEY (MathanhVienGiaoHang) REFERENCES dbo.ThanhVienGiaoHang (MaThanhVienGiaoHang);



INSERT INTO dbo.LoaiMatHang VALUES
(   'MH001',   N'Quần Áo'   ),
(   'MH002',   N'Mỹ Phẩm'   ),
(   'MH003',   N'Đồ GIa Dụng'   ),
(   'MH004',   N'Đồ điện tử'   );

INSERT INTO dbo.KhuVuc VALUES
(   'KV001',    N'Sơn Trà'    ),
(   'KV002',    N'Liêu Chiêu'    ),
(   'KV003',    N'Ngũ Hành Sơn'    ),
(   'KV004',    N'Hải Châu'    );

INSERT INTO dbo.KhoangThoiGian
(
    MaKTG,
    MoTa
)
VALUES
(   'TG001',   N'7h - 9h AM'   ),
(   'TG002',   N'9h - 11h AM'   ),
(   'TG003',   N'1h - 3h PM'   ),
(   'TG004',   N'3h - 5h PM'   ),
(   'TG005',   N'7h - 9h30 PM'   );

INSERT INTO dbo.DichVu
(
    MaDichVu,
    TenDichVu
)
VALUES
(   'DV001',     N'Giao hàng người nhận trả tiền phí'    ),
(   'DV002',     N'Giao hàng người gửi trả tiền phí'    ),
(   'DV003',     N'Giao hàng công ích (không tính phí)'    );

INSERT INTO dbo.ThanhVienGiaoHang
(
    MaThanhVienGiaoHang,
    TenThanhVienGiaoHang,
    NgaySinh,
    GioiTinh,
    SoDTThanhVien,
    DiaChiThanhVien
)
VALUES
( 'TV001',   N'Nguyễn Văn A',  '1995-11-20', N'Nam',   '0905111111',  N'23 Ông Ích KHiêm' ),
( 'TV002',   N'Nguyễn Văn B',  '1992-11-26', N'Nữ',   '0905111112',  N'234 Tông Đức Thắng' ),
( 'TV003',   N'Nguyễn Văn C',  '1990-11-30', N'Nữ',   '0905111113',  N'45 Hoàng Diệu' ),
( 'TV004',   N'Nguyễn Văn D',  '1995-08-07', N'Nam',   '0905111114',  N'23/33 Ngũ Hành Sơn' ),
( 'TV005',   N'Nguyễn Văn E',  '1991-4-2', N'Nam',   '0905111115',  N'56 Đinh Thị Diệu' );

SELECT * FROM dbo.ThanhVienGiaoHang
INSERT INTO dbo.DangKiGiaoHang
(
    MaThanhVienGiaoHang,
    MaKhoangTGDKGiaoHang
)
VALUES
(   'TV001',   'TG004'    ),
(   'TV002',   'TG005'    ),
(   'TV003',   'TG001'    ),
(   'TV003',   'TG002'    ),
(   'TV003',   'TG003'    );
SELECT * FROM dbo.DangKiGiaoHang;

INSERT INTO dbo.KhachHang
(
    MaKH,
    MaKhuVuc,
    TenKhachHang,
    TenCuaHang,
    SoDTKhachHang,
    Mail,
    DiaChiNhanHang
)
VALUES
(   'KH001','KV001', N'Lê Thị A', N'Cửa Hàng 1','0987456852', 'alethi@gmail.com',   N'80 Phan PHú Thái'  ),
(   'KH002','KV001', N'Nguyễn Văn B', N'Cửa Hàng 2','0987456853', 'bvannguyen@gmail.com',   N'100 Phan Tứ'  ),
(   'KH003','KV002', N'Lê Thị C', N'Cửa Hàng 3','0987456854', 'choangthi@gmail.com',   N'23 An Thương'  ),
(   'KH004','KV002', N'Nguyễn Văn D', N'Cửa Hàng 4','0987456855', 'dtranba@gmail.com',   N'67 Ngô Thế Thái'  ),
(   'KH005','KV001', N'Lê Thị E', N'Cửa Hàng 5','0987456856', 'ecaothi@gmail.com',   N'100 Châu Thị Vinh'  );
SELECT * FROM  dbo.KhachHang;


INSERT INTO dbo.DonHang_GiaoHang
(
    MaDon,
    MaKhachHang,
    MathanhVienGiaoHang,
    MaDV,
    MaKhuVuc,
    TenNGuoiNhan,
    DiaChiGiaoHang,
    SoDTNguoiNhan,
    MaKhoangTGGH,
    NgayGiaoHang,
    PhuongThucThanhToan,
    TrangThaiPheDuyet,
    TrangThaiGiaoHang
)
VALUES
(  'DH001', 'KH001', 'TV001', 'DV001','KV001', N'Phan Văn A', N'30 Hoàng Văn Thư', '0972414521', 'TG004','2016/10/10', N'Tiền mặt',  N'Đã Phê Duyệt', N'Đã giao hàng' ),
(  'DH002', 'KH001', 'TV002', 'DV001','KV004', N'Phan Văn B', N'15 Lê Đình Ly', '0972414522', 'TG005','2016/12/23', N'Tiền mặt',  N'Đã Phê Duyệt', N'Chưa giao hàng' ),
(  'DH003', 'KH002', 'TV003', 'DV001','KV004', N'Phan Văn C', N'23 Lê Bình Dương', '0972414523', 'TG001','2017/8/4', N'Tiền mặt',  N'Đã Phê Duyệt', N'Đã giao hàng' ),
(  'DH004', 'KH002', 'TV004', 'DV003','KV002', N'Phan Văn D', N'45 Phan Phú Thái', '0972414524', 'TG002','2015/11/10', N'Chuyển khoản',  N'Đã Phê Duyệt', N'Đã giao hàng' ),
(  'DH005', 'KH003', 'TV005', 'DV003','KV003', N'Phan Văn E', N'78 Hoàng Diệu', '0972414525', 'TG003','2017/4/4', N'Chuyển khoản',  N'Chưa Phê Duyệt', null );
SELECT * FROM dbo.DonHang_GiaoHang

INSERT INTO dbo.ChiTiet_DoHang
(
    MaDonHangGiaoHang,
    TenSanPhamDuocGiao,
    SoLuong,
    trongLuong,
    MaLoaiMatHang,
    TienThuHo
)
VALUES
(   'DH001', N'Áo Len', 2, 0.5, 'MH001',  200.000  ),
(   'DH001', N'Quần Ấu', 1, 0.25, 'MH001',  350.000  ),
(   'DH002', N'Áo Thun', 1, 0.25, 'MH001',  1000.000  ),
(   'DH002', N'Áo Khoác', 3, 0.25, 'MH001',  2000.000  ),
(   'DH003', N'Sữa đường thế', 2, 0.25, 'MH002',  780.000  ),
(   'DH003', N'Ken tẩy da chết', 3, 0.5, 'MH002',  150.000  ),
(   'DH003', N'Kem dưỡng ban đêm', 4, 0.25, 'MH003',  900.000  );
	SELECT * FROM dbo.ChiTiet_DoHang

--Câu 1: Xóa những khách hàng có tên là "Le Thi A".
SELECT * FROM dbo.KhachHang;
SELECT * FROM dbo.DonHang_GiaoHang
DELETE FROM dbo.DonHang_GiaoHang WHERE MaKhachHang = 'KH001'
DELETE FROM dbo.KhachHang WHERE KhachHang.TenKhachHang = N'Lê Thị A'
-- VÌ CÓ KHÓA NGOẠI NÊN PHẢI XÓA BẢNG CÓ KHÓA NGOẠI TRƯỚC.

--Câu 2: Cập nhật những khách hàng đang thường trú ở khu vực "Son Tra" thành khu vực "Ngu Hanh Son".
SELECT * FROM dbo.KhuVuc;
UPDATE dbo.KhuVuc SET TenKhuVuc = N'Ngũ Hành Sơn' WHERE TenKhuVuc = N'Sơn Trà'

--Câu 3: Liệt kê những thành viên (shipper) có họ tên bắt đầu là ký tự 'Tr' và có độ dài ít nhất là 25 ký tự (kể cả ký tự trắng).
SELECT TenThanhVienGiaoHang FROM dbo.ThanhVienGiaoHang WHERE TenThanhVienGiaoHang LIKE 'Tr%' AND DATALENGTH(TenThanhVienGiaoHang) > 15;

--Câu 4: Liệt kê những đơn hàng có NgayGiaoHang nằm trong năm 2017 và có khu vực giao hàng là "Hai Chau".
SELECT * FROM dbo.DonHang_GiaoHang AS DG JOIN dbo.KhuVuc AS KV ON DG.MaKhuVuc = KV.MaKhuVuc  
WHERE DG.NgayGiaoHang = 2017 AND KV.TenKhuVuc = N'Hải Châu'

--Câu 5: Liệt kê MaDonHangGiaoHang, MaThanhVienGiaoHang, TenThanhVienGiaoHang, NgayGiaoHang, PhuongThucThanhToan 
--của tất cả những đơn hàng có trạng thái là "Da giao hang". Kết quả hiển thị được sắp xếp tăng dần theo NgayGiaoHang và giảm dần theo
--PhuongThucThanhToan
SELECT DG.MaDon, DG.MathanhVienGiaoHang,TenThanhVienGiaoHang,NgayGiaoHang,PhuongThucThanhToan FROM  dbo.DonHang_GiaoHang AS DG JOIN dbo.ThanhVienGiaoHang  AS TV ON DG.MathanhVienGiaoHang = TV.MaThanhVienGiaoHang 
WHERE DG.TrangThaiGiaoHang = N'Đã Giao Hàng'
ORDER BY DG.NgayGiaoHang ASC,DG.PhuongThucThanhToan DESC ;

--Câu 6: Liệt kê những thành viên có giới tính là "Nam" và chưa từng được giao hàng lần nào.
SELECT * FROM dbo.ThanhVienGiaoHang WHERE GioiTinh = N'Nam' AND NOT EXISTS (SELECT * FROM dbo.DonHang_GiaoHang 
WHERE ThanhVienGiaoHang.MaThanhVienGiaoHang = DonHang_GiaoHang.MathanhVienGiaoHang )

--Câu 7: Liệt kê họ tên của những khách hàng đang có trong hệ thống. Nếu họ tên trùng nhau
--thì chỉ hiển thị 1 lần. Học viên cần thực hiện yêu cầu này bằng 2 cách khác nhau (mỗi cách
--được tính 0.5 điểm)
SELECT TenKhachHang FROM dbo.KhachHang GROUP BY dbo.KhachHang.TenKhachHang
SELECT  DISTINCT TenKhachHang FROM dbo.KhachHang

--Câu 8: Liệt kê MaKhachHang, TenKhachHang, DiaChiNhanHang, MaDonHangGiaoHang, PhuongThucThanhToan, TrangThaiGiaoHang của tất cả các khách hàng đang có trong hệ thống
SELECT KH.MaKH,TenKhachHang,DiaChiNhanHang,MaDon,DG.PhuongThucThanhToan,TrangThaiGiaoHang
FROM dbo.KhachHang AS KH JOIN dbo.DonHang_GiaoHang AS DG ON kh.MaKH = DG . MaKhachHang

--Câu 9: Liệt kê những thành viên giao hàng có giới tính là "Nu" và từng giao hàng cho 10 khách hàng khác nhau ở khu vực giao hàng là "Hai Chau"
SELECT  TV.MathanhVienGiaoHang,tv.TenThanhVienGiaoHang FROM dbo.ThanhVienGiaoHang AS TV JOIN DonHang_GiaoHang AS DG ON  tv.MaThanhVienGiaoHang = DG.MathanhVienGiaoHang
 JOIN dbo.KhuVuc AS KV ON KV.MaKhuVuc= DG.MaKhuVuc WHERE TV.GioiTinh = N'Nữ' AND KV.TenKhuVuc = N'Hải Châu'
 GROUP BY TV.MathanhVienGiaoHang,tv.TenThanhVienGiaoHang HAVING count(tv.MathanhVienGiaoHang)> 10

--Câu 10: Liệt kê những khách hàng đã từng yêu cầu giao hàng tại khu vực "Lien Chieu" và chưa từng được một thành viên giao hàng nào có giới tính là "Nam" nhận giao hàng
SELECT * FROM dbo.ThanhVienGiaoHang TVGH JOIN dbo.DonHang_GiaoHang DG ON TVGH.MaThanhVienGiaoHang = DG.MathanhVienGiaoHang
JOIN KhuVuc KV ON KV.MaKhuVuc = DG.MaKhuVuc WHERE KV.TenKhuVuc = N'Liêu Chiêu' AND NOT TVGH.GioiTinh = N'Nam' 