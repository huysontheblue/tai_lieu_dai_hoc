package batch_jdbc;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;


public class ConnectJDBC {
	final static String URL = "jdbc:sqlserver://localhost:1433\\SQLEXPRESS; databaseName=k59CNTT;";
	final static String USER = "sa";
	final static String PASS = "sa";

	public static Connection getConnect() {
		try {
			return DriverManager.getConnection(URL, USER, PASS);
		} 
		catch (SQLException e) {
			return null;
		}
	 } 

} 