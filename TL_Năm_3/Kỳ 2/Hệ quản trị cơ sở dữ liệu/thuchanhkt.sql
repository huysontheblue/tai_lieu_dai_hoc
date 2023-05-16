use hokhau
select *from tblPhuong
select *from tblSoHoKhau
select *from tblNhanKhau
--- cau 1 Tạo hàm đầu vào là mã sổ hộ khẩu (MaSo), 
-- đầu ra là họ tên từng người trong hộ này, 
-- quan hệ với chủ hộ của những nhân khẩu có trong mã sổ hộ khẩu này.
create function cau1
(@ms char(4))
Returns table
as
	return select HoTen
			from tblNhanKhau 
			where MaSo = @ms
select * from dbo.cau1('ms1')
drop function cau1
--cau 2 Tạo trigger để khi thêm một bản ghi mới vào bảng tblSoHoKhau thì thỏa các yêu cầu sau:
-- Không vi phạm PK và FK
-- NgayCap  Ngày nào đó

create trigger thembanghi on tblSoHoKhau instead of insert
as
begin
	declare @ms char(4),@tch nvarchar(40),@Noic nvarchar(35),@NgayCap datetime, @mp char(4)
    select @ms = MaSo, @tch = TenCH, @NoiC = NoiCap, @NgayCap = Ngaycap, @mp = MaPh from inserted
	if (exists (select * from tblSoHoKhau where @ms=MaSo))
	  print N'Mã số đã tồn tại'
	else if (exists (select * from tblSoHoKhau where @mp=MaPh))
	  print N'MaPh đã tồn tại'
	else
	insert into tblSoHoKhau values(@ms, @tch, @Noic, @NgayCap, @mp)
end
insert into tblSoHoKhau values
('ms9',N'Ch 1',N'nghe an',01/07/2001,'mp1')
drop trigger thembanghi