package HSHP2;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.LinkedList;

public class ConnecttionGiangVien {
	final static String URL ="jdbc:sqlserver://localhost;databaseName=Lecturer Manager;";
	final static String USER_NAME = "sa";
	final static String PASSWORD = "sa";
	public static Connection getConnection() {
		Connection conn = null;
		try {
			conn = DriverManager.getConnection(URL,USER_NAME, PASSWORD);
			System.out.println("Ket noi thanh cong!");
		} catch (SQLException e) {
			System.out.println("Ket noi khong thanh cong!");
		}
		return conn;
	}
	public static void exportToDBGV(LinkedList<GiangVien>lecturerList) throws Exception {
		Connection con = getConnection();
		String sql = "INSERT INTO giangvien (magv,hoten,luong) values (?,?,?)";
		PreparedStatement stmt =con.prepareStatement(sql);
		for (GiangVien lecturer : lecturerList) {
			stmt.setInt(1, lecturer.getMagv());
			stmt.setString(2, lecturer.getHoten());
			stmt.setInt(3, lecturer.getLuong());
			stmt.executeUpdate();
		}
	}
	public static void importFromDBGV(LinkedList<GiangVien>lecturerList) throws Exception {
		Connection con = getConnection();
		String sql = "SELECT * FROM	giangvien";
		Statement stmt = con.createStatement();
		ResultSet rs = stmt.executeQuery(sql);
		GiangVien lecturer;
		while (rs.next()) {
			lecturer = new GiangVien();
			lecturer.setMagv(rs.getInt(1));
			lecturer.setHoten(rs.getString(2));
			lecturer.setLuong(rs.getInt(3));;
		}
	}
}
