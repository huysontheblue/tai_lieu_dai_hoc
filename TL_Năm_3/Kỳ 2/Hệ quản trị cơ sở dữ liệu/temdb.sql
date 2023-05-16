CREATE DATABASE temdb;
use tempdb
go
if exists (select * from dbo.sysobjects where id = object_id(N'[emp]')
and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [emp]
GO
create table Emp (id int, [First name] varchar(50),
[Last name] varchar(50), gender char(1))
go
insert into Emp (id,[First name],[Last name], gender )
values (1,'John','Smith','m')
insert into Emp (id,[First name],[Last name], gender )
values (2,'James','Bond','m')
insert into Emp (id,[First name],[Last name], gender )
values (3,'Alexa','Mantena','f')
insert into Emp (id,[First name],[Last name], gender )
values (4,'Shui','Qui','f')
insert into Emp (id,[First name],[Last name], gender )
values (5,'William','Hsu','m')
insert into Emp (id,[First name],[Last name], gender )
values (6,'Danielle','Stewart','F')
insert into Emp (id,[First name],[Last name], gender )
values (7,'Martha','Mcgrath','F')
insert into Emp (id,[First name],[Last name], gender )
values (8,'Henry','Fayol','m')
insert into Emp (id,[First name],[Last name], gender )
values (9,'Dick','Watson','m')
insert into Emp (id,[First name],[Last name], gender )
values (10,'Helen','Foster','F')
go
Select [id],[Full Name] = case Gender
when 'm' then 'Mr. '+[First name]+ ' '+[Last name]
when 'f' then 'Ms. '+[First name]+ ' '+[Last name]
end
from Emp
Select [id],[Full Name] = case Gender
when 'm' then 'Mr. '+[First name]+ ' '+[Last name]
when 'f' then 'Mz. '+[First name]+ ' '+[Last name]
else [First name]+ ' '+[Last name]
end
from Emp