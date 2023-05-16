package book;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;


public class ConnectionBook {
	final static String URL = "jdbc:sqlserver://localhost:1433; " + "databaseName = bookDB;";
	final static String USER_NAME = "sa";
	final static String PASSWORD = "sa";
	public static Connection getConnection() {
		try {
			return DriverManager.getConnection(URL, USER_NAME, PASSWORD);
		} catch (SQLException e) {
			return null;
		}
	}
	public static void exportToDB(ArrayList<Book> bookList) throws Exception {
		Connection con = getConnection();
		String sql = "insert into books (ISBN, title, authors, copyNum) values (?,?,?,?)";
		PreparedStatement stmt = con.prepareStatement(sql);

		for (Book book : bookList) {
			stmt.setString(1, book.getISBN());
			stmt.setString(2, book.getTitle());
			stmt.setString(3, book.getAuthors());
			stmt.setInt(4, book.getCopyNum());
			stmt.executeUpdate();
		}
	} 
	public static void importFromDB(ArrayList<Book> bookList) throws Exception {
		Connection con = getConnection();
		String sql = "select * from books";
		Statement stmt = con.createStatement();
		ResultSet rs = stmt.executeQuery(sql);
		Book book;
		while(rs.next()) {
			book = new Book();
			book.setISBN(rs.getString(1));
			book.setTitle(rs.getString(2));
			book.setAuthors(rs.getString(3));
			book.setCopyNum(rs.getInt(4));
			if(MainApp.bookNum == MainApp.bookMax)
				return;
			bookList.add(book);
			MainApp.bookNum++;
		}
	}
} 

