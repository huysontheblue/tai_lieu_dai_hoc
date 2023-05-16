package de_1;

import java.sql.Connection;
import java.sql.DriverManager;

public class ConnectDB {
	private Connection conn = null;
	private String URL = "jdbc:sqlserver://localhost:1433;Database=customerdb";
	private String user_name;
	private String password;
	private String dbName;

	public ConnectDB(String user_name, String password, String dbName) {
		this.user_name = user_name;
		this.password = password;
		this.dbName = dbName;
	}

	public Connection getConnection() {
		// Nạp trình điều khiển
		try {
			Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");

		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
		
		try {
			this.URL = this.URL + this.dbName;
			// thiết lập kết nối
			conn = DriverManager.getConnection(this.URL, this.user_name, this.password);
			if (conn != null) {
				System.out.println("Kết nối thành công");
			}
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		return this.conn;
	}

}
