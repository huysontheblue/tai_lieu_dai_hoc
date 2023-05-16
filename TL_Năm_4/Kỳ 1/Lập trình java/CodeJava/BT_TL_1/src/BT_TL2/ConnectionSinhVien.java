package BT_TL2;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class ConnectionSinhVien {
	final static String URL = "jdbc:sqlserver://localhost:1433; " + "databaseName = studentdb;";
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
		String sql = "INSERT INTO tabstudents (id, name, diem1, diem2, diem3, dtong, xeploai) VALUES (?,?,?,?,?,?,?)";
		PreparedStatement stmt = con.prepareStatement(sql);
 
		for (Student student : dssv) {
			stmt.setString(1, student.getId());
			stmt.setString(2, student.getName());
			stmt.setFloat(3, student.getDiem1());
			stmt.setFloat(4, student.getDiem1());
			stmt.setFloat(5, student.getDiem1());
			stmt.setFloat(5, student.getDtong());
			stmt.setFloat(6, student.getDtong());
			stmt.setString(7, student.getXeploai());
			stmt.executeUpdate();
		}
		con.close();
	}
	public static void exportFromDB(ArrayList<Student> dssv) throws SQLException {
		Connection con = getConnection();
		String sql = "SELECT * FROM tabstudents";
		Statement stmt = con.createStatement();
		ResultSet rs = stmt.executeQuery(sql);
		Student sv;
		while(rs.next()) {
			sv = new Student();
			sv.setId(rs.getString(1));
			sv.setName(rs.getString(2));
			sv.setDiem1(rs.getFloat(3));
			sv.setDiem2(rs.getFloat(4));
			sv.setDiem3(rs.getFloat(5));
			sv.setDtong(rs.getFloat(6));
			sv.setXeploai(rs.getString(7));
			dssv.add(sv);
		}
	}
} 
