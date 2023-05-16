package fpt;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class ConnectJDBC {
final static String URL = "jdbc:sqlserver://localhost:1433; databaseName=k59CNTT;";
final static String USER_NAME = "sa";
final static String PASSWORD = "sa";

	public static Connection getConnection() {
		try {
			return DriverManager.getConnection(URL, USER_NAME, PASSWORD);
		} catch (SQLException e) {
			return null;
		}
	}
}