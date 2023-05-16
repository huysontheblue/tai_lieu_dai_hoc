package batch_jdbc;

import java.sql.Connection;
import java.sql.Statement;


public class UseConnect {
	public static void main(String[] args) throws Exception {
		Connection con = (Connection) ConnectJDBC.getConnect();
		Statement stmt = con.createStatement();
		
		String sql = "DELETE FROM sinhvien WHERE masv is null";
		stmt.addBatch(sql);
		
		sql = "INSERT INTO sinhvien VALUES('16','Trần Trung Kiên')";
		stmt.addBatch(sql);

		con.setAutoCommit(false);

		stmt.executeBatch();
		con.commit();

		System.out.println("Done!");
		con.close();
	}
} 