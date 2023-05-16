package de_1;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;
import java.util.Vector;

public class MainApp {
	private int cNum;
	private int maxNum = 100; // sô lượng khách hàng có thể quản lý
	private Vector<Customer> cList = new Vector<Customer>();
	private Connection conn;

	public MainApp(String user_name, String password, String dbName) {
		// tạo đối tượng của Database connection để getConnection'
		super();
		ConnectDB newConnection = new ConnectDB(user_name, password, dbName);
		conn = newConnection.getConnection();
	}

	public void closeConnection() {
		try {
			conn.close();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public void setList(Vector<Customer> list) {
		this.cList = list;
	}

	public void initCustomer(int n) {
		for (int i = 0; i < n; i++) {
			System.out.print("Nhập khách hàng thứ " + (i + 1) + ":\n ");
			Customer newCustomer = new Customer();
			newCustomer.readData();
			cList.add(newCustomer);
		}
		this.cNum = n;
		// nếu N lơn hơn maxNUm;
		if (n > this.maxNum) {
			this.maxNum = n;
		}
		System.out.println("Đã thêm " + n + " khách hàng!");
	}

	public void addCustomer() {
		Customer newCus = new Customer();
		newCus.readData();
		cList.add(newCus);
		// cộng thêm một giá trị vào cNum;
		this.cNum++;
		// Nếu CNum hiện tại lơn hơn maxNum;
		if (this.cNum > this.maxNum) {
			this.maxNum = this.cNum;
		}
		System.out.println("Đã thêm vào cuối danh sách");
	}

	public void display() {
		for (int i = 0; i < cList.size(); i++) {
			Customer cus = cList.get(i);
			System.out.print(cus.toString());
		}
		System.out.println("Xong");
	}
	
	public static void main(String[] args) {
		// khởi tạo đối tượng main app bởi vì các hàm không khai báo là static
		String userName = "sa";
		String passWord = "sa";
		String dbName = "customerdb";
		MainApp newApp = new MainApp(userName, passWord, dbName);

		System.out.print("Nhập số lượng khách hàng: ");

		Scanner input = new Scanner(System.in);
		int n = input.nextInt();

		// khởi tạo với n giá tị ban đầu
		newApp.initCustomer(n);

		// thêm vào cuối
		newApp.addCustomer();

		// hiển thị

		newApp.display();

		// nhập vào DB
		newApp.ExportToDB();
		newApp.closeConnection();

		// Nhập từ DB

		System.out.println("Hiện thị danh sách nhập từ DB");
		MainApp newApp2 = new MainApp(userName, passWord, dbName);

		newApp2.ImportFromDB();
		newApp2.display();
		newApp2.closeConnection();
		input.close();

	}
	
	public void ImportFromDB() {
		Vector<Customer> newClist = new Vector<>();
		try {
			Statement s = conn.createStatement();
			String sql = "Select * from tabscustomers";
			ResultSet rs = s.executeQuery(sql);
			while (rs.next()) {
				String id = rs.getString(1);
				String name = rs.getString(2);
				double chiSoCu = rs.getDouble(3);
				double chiSoMoi = rs.getDouble(4);
				double mucTieuThu = rs.getDouble(5);
				double thanhTien = rs.getDouble(6);
				Customer newCus = new Customer(id, name, chiSoCu, chiSoMoi, mucTieuThu, thanhTien);
				newClist.add(newCus);
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
		setList(newClist);
		System.out.println("Đã nhập từ DB xong");
	}

	public void ExportToDB() {
		try {
			Statement stm = this.conn.createStatement();
			for (int i = 0; i < cList.size(); i++) {
				Customer newCus = cList.get(i);
				String sql = "Insert into tabscustomers values" + "('" + newCus.getId() + "','" + newCus.getName()
						+ "','" + newCus.getChiSoCu() + "','" + newCus.getChiSoMoi() + "','" + newCus.getMucTieuThu()
						+ "','" + newCus.getThanhTien() + "')";
				stm.executeUpdate(sql);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		System.out.println("Đã xuất vào DB");
	}
	
}
