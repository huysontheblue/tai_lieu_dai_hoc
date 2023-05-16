package Sinh_vien;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class ConnectionSinhVien {
	final static String URL = "jdbc:sqlserver://localhost:1433; " + "databaseName = LecturerManager;";
	final static String USER_NAME = "sa";
	final static String PASSWORD = "sa";
	public static Connection getConnection() {
		try {
			return DriverManager.getConnection(URL, USER_NAME, PASSWORD);
		} catch (SQLException e) {
			return null;
		}
	}
	public static void importToDB(ArrayList<Student> dssv) throws Exception {
		Connection con = getConnection();
		String sql = "INSERT INTO sinhvien (masv, hoten, diem) VALUES (?,?,?)";
		PreparedStatement stmt = con.prepareStatement(sql);
 
		for (Student student : dssv) {
			stmt.setInt(1, student.getMasv());
			stmt.setString(2, student.getHoten());
			stmt.setFloat(3, student.getDiem());
			stmt.executeUpdate();
		}
		con.close();
	}
	public static void exportFromDB(ArrayList<Student> dssv) throws SQLException {
		Connection con = getConnection();
		String sql = "SELECT * FROM sinhvien";
		Statement stmt = con.createStatement();
		ResultSet rs = stmt.executeQuery(sql);
		Student sv;
		while(rs.next()) {
			sv = new Student();
			sv.setMasv(rs.getInt(1));
			sv.setHoten(rs.getString(2));
			sv.setDiem(rs.getFloat(3));
			dssv.add(sv);
		}
	}
} 