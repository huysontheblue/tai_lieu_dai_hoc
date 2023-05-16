create database btCREATE TABLE TaiKhoanA(sotaikhoan char(5), sodu INT)CREATE TABLE TaiKhoanB(sotaikhoan char(5), sodu INT, constraint ck1 check (sodu<100) )-- check (sodu<100) được đưa ra để tạo lỗi trong giao dich--khởi tạo giá trị cho các tài khoảnINSERT INTO TaiKhoanA VALUES('A', 200)INSERT INTO TaiKhoanB VALUES('B', 0)--chuyển số tiền 150 từ AB	UPDATE TaiKhoanA SET sodu = sodu - 150	UPDATE TaiKhoanB SET sodu = sodu + 150--Nếu không lỗi thì OK, ngược lại  SAI

BEGIN TRANSET XACT_ABORT ON BEGIN TRY	UPDATE TaiKhoanA SET sodu = sodu - 90	UPDATE TaiKhoanB SET sodu = sodu + 90 -- Vi pham rang buoc CHECK -> Giao dich này sẽ bị loiCOMMITEND TRYBEGIN CATCHROLLBACK	PRINT 'LOI XAY RA TRONG GIAO DICH'END CATCH--kiểm tra lại các tài khoản bằng SELECT * FROM TaiKhoanA; 
SELECT * FROM TaiKhoanB

