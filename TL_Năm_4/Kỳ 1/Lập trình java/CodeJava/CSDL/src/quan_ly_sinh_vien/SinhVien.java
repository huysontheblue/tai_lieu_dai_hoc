package quan_ly_sinh_vien;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class SinhVien {
	private static String DB_URL = "jdbc:sqlserver://localhost:1433;databaseName=QuanLySinhVien;";
	private static String USER_NAME = "sa";
	private static String PASSWORD = "sa";
	 // connnect to database 'CreateDatabase'
	public static Connection getConnection(String dbURL, String userName, String password) { 
		Connection conn = null; 
		try { 
			conn = DriverManager.getConnection(dbURL, userName, password); 
			System.out.println("Kết nối thành công!"); 
		} catch (SQLException e) { 
				System.out.println("Kết nối không thành công!");
				}
		return conn; 
		} 
	public static void main(String args[]) { 
		try { 
			Connection conn = getConnection(DB_URL, USER_NAME, PASSWORD); 
			Statement stmt = conn.createStatement(); 
			
			// Lấy dữ liệu từ bảng sinhvien và lưu vào ResultSet
			ResultSet rs = stmt.executeQuery("select * from SinhVien"); 
			// Hiển thị dữ liệu lên màn hình
			System.out.println("+--------+----------------------+-------+");
			System.out.println("|  Mã SV |       Họ và tên      |  Điểm |");
			System.out.println("+--------+----------------------+-------+"); 
			while (rs.next()) { 
				System.out.printf("| %6d | %20s | %5.2f |\n", rs.getInt(1),  
						rs.getString(2), rs.getFloat(3)); 
				}			
			System.out.println("+--------+----------------------+-------+"); 			
			// Đóng kết nối
			conn.close(); 
			} catch (Exception ex) { 
				ex.getMessage(); 
			} 
		}
}

