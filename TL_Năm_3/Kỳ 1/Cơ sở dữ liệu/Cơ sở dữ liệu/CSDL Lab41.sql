Create database Lab41;
use Lab41;
Create table nhacungcap3(manhacc char(10) primary key, tennhacc char(50), diachi char(20), sodt float, masothue char(30));
Create table loaidichvu3(maloaidv char(5) primary key, tenloaidv char(50));
Create table dongxe3(dongxe char(10) primary key, hangxe char(10), sochongoi int);
Create table mucphi3(mamp char(5) primary key, dongia decimal(10, 2), mota char(30));
Create table dangkycungcap3(madkcc char(10) primary key, manhacc char(10), maloaidv char(5), dongxe char(10), mamp char(5),
ngaybatdaucungcap char(10), ngayketthuccungcap char(10), soluongxedangky int );

insert into nhacungcap3 values 
('NCC001', 'Cong ty tnhh Toan Phap',        'Hai Chau', 05113999888, 568941),
('NCC002', 'Cong ty co phan Dong Du',       'Lien Chieu', 05113999889, 456789),
('NCC003', 'Ong Nguyen Van A',              'Hoa Thuan', 05113999890, 321456),
('NCC004', 'Cong ty co phan Toan Cau Xanh', 'Hai Chau', 05113658945, 513364),
('NCC005', 'Cong ty tnhh AMA',              'Thanh Khe', 05113875466, 546546),
('NCC006', 'Ba Tran Thi Bich Van',          'Lien Chieu', 05113587469, 524545),
('NCC007', 'Cong ty tnhh Phan Thanh',       'Thanh Khe', 05113987456, 113021),
('NCC008', 'Ong Phan Dinh Nam',             'Hoa Thuan', 05113532456, 121230),
('NCC009', 'Tap doan Dong Nam A',           'Lien Chieu', 05113987121, 533654),
('NCC010', 'Cong ty co phan Rang Dong',     'Lien Chieu', 05113569654, 187864);

insert into loaidichvu3 values 
('DV01', 'Dich vu xe taxi'),
('DV02', 'Dich vu xe buyt cong cong theo tuyen co dinh'),
('DV03', 'Dich vu xe cho thue theo hop dong');

insert into mucphi3 values
('MP01', 10.000, 'Ap dung tu 1/2015'),
('MP02', 15.000, 'Ap dung tu 2/2015'),
('MP03', 20.000, 'Ap dung tu 1/2010'),
('MP04', 25.000, 'Ap dung tu 2/2011');

insert into dongxe3 values 
('Hiace', 'Toyota', 16),
('Vios', 'Toyota', 5),
('Escape', 'Ford', 5),
('Cerato', 'KIA', 7),
('Forte', 'KIA', 5),
('Starex', 'Huyndai', 7),
('Grand-i10', 'Huyndai', 7);

insert into dangkycungcap3 values 
('DK001', 'NCC001', 'DV01', 'Hiace',     'MP01', '20/11/2015', '20/11/2016', 4), 
('DK002', 'NCC002', 'DV02', 'Vios',      'MP02', '20/11/2015', '20/11/2017', 3),
('DK003', 'NCC003', 'DV03', 'Escape',    'MP03', '20/11/2017', '20/11/2018', 5),
('DK004', 'NCC005', 'DV01', 'Cerato',    'MP04', '20/11/2015', '20/11/2019', 7),
('DK005', 'NCC002', 'DV02', 'Forte',     'MP03', '20/11/2019', '20/11/2020', 1),
('DK006', 'NCC004', 'DV03', 'Starex',    'MP04', '10/11/2016', '20/11/2021', 2),
('DK007', 'NCC005', 'DV01', 'Cerato',    'MP03', '30/11/2015', '25/01/2016', 8),
('DK008', 'NCC006', 'DV01', 'Vios',      'MP02', '28/02/2016', '15/08/2016', 9),
('DK009', 'NCC005', 'DV03', 'Grand-i10', 'MP02', '27/04/2016', '30/04/2017', 10),
('DK010', 'NCC006', 'DV01', 'Fort',      'MP02', '21/11/2015', '22/02/2016', 4),
('DK011', 'NCC007', 'DV01', 'Fort',      'MP01', '25/12/2016', '20/02/2017', 5),
('DK012', 'NCC007', 'DV03', 'Cerato',    'MP01', '14/04/2016', '20/12/2017', 6),
('DK013', 'NCC003', 'DV02', 'Cerato',    'MP01', '21/12/2015', '21/12/2016', 8),
('DK014', 'NCC008', 'DV02', 'Cerato',    'MP01', '20/05/2016', '30/12/2016', 1),
('DK015', 'NCC003', 'DV01', 'Hiace',     'MP02', '24/04/2018', '20/11/2019', 6),
('DK016', 'NCC001', 'DV03', 'Grand-i10', 'MP02', '23/06/2016', '21/12/2016', 8),
('DK017', 'NCC002', 'DV03', 'Cerato',    'MP03', '30/09/2016', '30/09/2019', 4),
('DK018', 'NCC008', 'DV03', 'Escape',    'MP04', '13/12/2017', '30/09/2018', 2),
('DK019', 'NCC003', 'DV03', 'Escape',    'MP03', '24/01/2016', '30/12/2016', 8),
('DK020', 'NCC002', 'DV03', 'Cerato',    'MP04', '03/05/2016', '21/10/2017', 7),
('DK021', 'NCC006', 'DV01', 'Forte',     'MP02', '30/01/2015', '30/12/2016', 9),
('DK022', 'NCC002', 'DV02', 'Cerato',    'MP04', '25/07/2016', '30/12/2017', 6),
('DK023', 'NCC002', 'DV01', 'Forte',     'MP03', '30/11/2017', '20/05/2018', 5),
('DK024', 'NCC003', 'DV03', 'Forte',     'MP04', '23/12/2017', '30/11/2019', 8),
('DK025', 'NCC003', 'DV03', 'Hiace',     'MP02', '24/08/2016', '25/10/2017', 1);
