use DTSV
select * from tblDT
select * from tblGiangVien
select * from tblSinhVien

--4 viết chương trình nhập dữ liệu cho bảng đề tài với yêu cầu :mã đề tài tự động tăng(ví dụ trong bảng mã đt lớn nhất hiện là 5 thì mã mới là 6)
-- tên đt tùy ý nhưng phải phù hợp với kiểu dữ liệu

--5 lập trình cursor để đưa ra danh sách gồm mã số, họ tên sinh viên , tên đt 
-- của những sinh viên do giảng viên 'XYZ' hướng dãn
 declare 
-- 6 tạo một thủ tục in ra họ tên giảng viên k hướng dẫn sinh viên làm đề tài
create proc cau6
as 
begin
   select HoTenGV from tblGiangVien gv
   where not exists(select MaGV from tblSinhVien sv where sv.MaGV=gv.MaGV)
end


--7 tạo 1 thủ tục in ra họ tên giảng viên , họ tên sinh viên, 
--điểm đề tài mà giảng viên đó hướng dẫn với tham só đầu vào là mã giảng viên 
--nếu không có mã giảng viên thì thông báo' không tìm thấy giảng viên có mã số như vậy'
 create proc cau7
 @Mgv char(4)
 as 
 begin
   if (not exists(select * from tblGiangVien where @Mgv=MaGV))
       print N'Không tìm thấy giảng viên có mã số như vậy'
   else
     select HoTenGV, HoTenSV, Diem from tblGiangVien gv join tblSinhVien sv on gv.MaGV=sv.MaGV
end 
 select * from tblGiangVien

 exec cau7 'GV1'
 exec cau7 'GV11'

-- 8 tạo 1 thủ tục cập nhật ssdt mới của giảng viên với tham số đầu vào 
-- là mã giảng viên, nếu không có mã giảng viên này thì thông báo ra màn hình không tìm thấy giảng viên có mã số như vậy
-- cách 1 not exists
create proc cau8
(@MaGV char(4), @sdt nvarchar(12))
as 
begin
   if (not exists (select * from tblGiangVien where @MaGV=MaGV))
     print N'Không tìm thấy giảng viên có mã số như vậy!'
   else
     update tblGiangVien set DienThoai=@sdt
     where @MaGV=MaGV
 end

 exec cau8 'GV9','0964322523'
 exec cau8 'GV1', '0935463562'
 select * from tblGiangVien

-- cách 2 not in
create proc cau8
(@MaGV char(4), @sdt nvarchar(12))
as 
begin
   if (not in (select MaGV from tblGiangVien ))
     print N'Không tìm thấy giảng viên có mã số như vậy!'
   else
     update tblGiangVien set DienThoai=@sdt
     where @MaGV=MaGV
 end
 
 -- 9 tạo 1 thủ tục đưa ra mã số, họ tên sinh viên và tên đề tài mà
 -- sinh viên đã thực hiện với đầu vào là mã giảng viên
 create proc cau9
 @MaGV char(4)
 as 
 begin
       select MaSV, HoTenSV, TenDT from tblSinhVien sv join tblDT dt 
       on sv.MaDT=dt.MaDT
 end

exec cau9 'GV1'

--10 tạo một thủ tục đưa ra mã số, họ tên sinh viên và tên đề tài mà sinh viên đã thực hiện với đầu vào là họ tên giảng viên
 create proc cau10
 @HoTenGV  nvarchar(35)
 as
 begin
     select MaSV, HoTenSV, TenDT from tblSinhVien sv join tblDT dt 
     on sv.MaDT=dt.MaDT
end
exec cau10 'Hoang Van Hoanh'

--11 tạo 1 thủ tục đưa ra mã số, họ tên giảng viên hướng dẫn sinh viên làm đề tài nhiều nhất
 create proc cau11
 as
 begin
  select MaGV, HoTenGV from tblGiangVien

 --12 tạo 1 thủ tục in ra điểm thực tập, số lượng sinh viên  đạt điểm tương ứng và sắp xếp giảm dần
 create proc cau12
 as 
 begin
     select Diem, count(*) as 'số lượng sinh viên' from tblSinhVien
     group by Diem
     order by Diem desc
 end
 exec cau12

 -- 13 tạo 1 thủ tục để bổ sung sinh viên mới (mã số, họ tên , giới tính của sinh viên và các thông tin về mã đề tài, mã giảng viên hướng dẫn, điểm thực tập). 
 -- Yêu cầu bắt các lỗi vi phạm PK và FK trước khi bổ sung các thông tin
create proc cau13
@masv char(4),
@ten nvarchar(35),
@gt char(10),
@madt int, @magv char(4), @diem float
as
begin
     if( exists (select * from tblSinhVien where @masv=MaSV))
	    print N'Lỗi mã sinh viên'
	else if ( not exists(select * from tblDT where @madt=MaDT))
	    print N'Lỗi mã đề tài'
	else if (not exists(select * from tblGiangVien where @magv=MaGV))
	    print N'Lỗi mã giảng viên'
	else 
	    insert into tblSinhVien values
		(@masv, @ten, @gt,@madt,@magv,@diem)
end
exec cau13 'SV10',N'Nguyễn Thu Tra','nu',1,'GV1',8

select * from tblSinhVien