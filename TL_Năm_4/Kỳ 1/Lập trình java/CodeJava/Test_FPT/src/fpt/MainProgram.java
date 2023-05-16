package fpt;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.sql.Connection;
import java.sql.Statement;
import javax.swing.JFrame;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;

public class MainProgram {
	// Tạo một Model chứa dữ liệu cho bảng (JTable)
	private static DefaultTableModel tableModel = new DefaultTableModel();

	private static Connection conn = ConnectJDBC.getConnection();

	public static void main(String[] args) throws Exception {

	 Statement stmt = conn.createStatement();

	 // Bổ sung tên các cột
	 tableModel.addColumn("Mã sinh viên");
	 tableModel.addColumn("Họ và tên"); 

	 // Đọc tập tin văn bản có tên input.txt
	 File fileName = new File("input.txt");
	 FileReader fin = new FileReader(fileName);
	 BufferedReader reader = new BufferedReader(fin);
	 String line;
	 while ((line = reader.readLine()) != null) {
	 // Chia chuỗi line thành mảng các String, phân cách bởi ", "
	 String[] st = line.split(", ");

	 // Chèn dữ liệu được đọc từ tập tin văn bản vào Database
	 String sql = "INSERT INTO sinhvien VALUES('" + st[0] + "',N'" + st[1] + "')";
	 stmt.executeUpdate(sql);

	 // Bổ sung mảng các String vào Model
	 tableModel.addRow(st);
	 }

	 reader.close();

	 // Tạo 1 bảng với dữ liệu được lưu ở Model trên
	 JTable table = new JTable(tableModel);

	 // Tạo 1 khung cuộn đối với table
	 JScrollPane scrollPane = new JScrollPane(table);

	 // Tạo 1 cửa sổ JFrame
	 JFrame f = new JFrame();
	 f.setTitle("DANH SÁCH CÁC DÒNG LỖI"); // Tiêu đề cửa sổ
	 f.add(scrollPane); // Bổ sung khung cuộn vào
	 f.setSize(400, 200); // Kích thước cửa sổ (cột, dòng)
	 f.setLocationRelativeTo(null); // Đặt cửa sổ chính giữa màn hình
	 f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	 f.setVisible(true); // Hiển thị cửa sổ lên màn hình
	 }
	} 
