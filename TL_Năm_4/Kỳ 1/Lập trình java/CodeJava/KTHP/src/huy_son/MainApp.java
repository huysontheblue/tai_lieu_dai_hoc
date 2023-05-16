package huy_son;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;
import java.util.Vector;

public class MainApp {
	private int maxNum;
	private int contactNum;
	private static Connection con;
	private static Vector<ContactObject> contactlist;

	private final static Scanner sc = new Scanner(System.in);

	public MainApp() {
		contactlist = new Vector<>();
	}

	public static Vector<ContactObject> getContactlist() {
		return contactlist;
	}

	public static void setContactlist(Vector<ContactObject> contactlist) {
		MainApp.contactlist = contactlist;
	}

	public int getMaxNum() {
		return maxNum;
	}

	public void setMaxNum(int maxNum) {
		this.maxNum = maxNum;
	}

	public int getContactNum() {
		return contactNum;
	}

	public void setContactNum(int contactNum) {
		this.contactNum = contactNum;
	}
	
	// tạo danh sách contactlist có n bản ghi
	public static void createContacts(int n) {
		for (int i = 0; i < n; i++) {
			System.out.println("NHAP THONG TIN LIEN LAC THU: " + i);
			ContactObject cm = new ContactObject();
			cm.readData();
			contactlist.add(cm);
		}
	}
	
	// cho phép tạo một đối tượng của lớp ContactObject và bổ sung vào contactList 
	public void addContact() {
		ContactObject st = new ContactObject();
		st.readData();
		contactlist.add(st);
	}
	
	//cho phép hiển thị danh sách trong contactList, mỗi bản ghi trên một hàng
	public void display() {
		for (int i = 0; i < contactlist.size(); i++) {
			System.out.println(contactlist.get(i).toString());
		}
	}

	public static void getConnection() {
		try {
			con = DriverManager.getConnection("jdbc:sqlserver://localhost:1433\\SQLEXPRESS;" + "Databasename=contactdb", "sa", "sa");
		} catch (SQLException e) {
			e.printStackTrace();
		}

		if (con != null) {
			System.out.println("Ket noi thanh cong");
		} else {
			System.out.println("ket noi that bai");
		}
	}

	public static void exportToDB(Vector<ContactObject> contactlist) {
		try {
			Statement s = con.createStatement();
			for (int i = 0; i < contactlist.size(); i++) {
				String sqlInset = "insert into tabcontacts values ('" + contactlist.get(i).getId() + "','"
						+ contactlist.get(i).getName() + "','" + contactlist.get(i).getPhone() + "','"
						+ contactlist.get(i).getAddress() + "','" + contactlist.get(i).getEmail() + "')";
				s.executeUpdate(sqlInset);
			}
			System.out.println("Danh sach da duoc them vao DB");

		} catch (SQLException e) {
			e.printStackTrace();
			System.out.println("Them vao that bai");
		}
	}

	public static Vector<ContactObject> importFromDB() {
		Vector<ContactObject> contactlist = new Vector<>();
		String slqSeclect = "select * from tabcontacts";
		try {
			Statement s = con.createStatement();
			ResultSet rs = s.executeQuery(slqSeclect);
			while (rs.next()) {
				String id = rs.getString(1);
				String name = rs.getString(2);
				String phone = rs.getString(3);
				String address = rs.getString(4);
				String email = rs.getString(5);
				ContactObject cm = new ContactObject(id, name, phone, address, email);
				contactlist.add(cm);
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		System.out.println(" Da lay duoc du lieu tu DB thanh cong");

		for (int i = 0; i < contactlist.size(); i++) {
			System.out.println(contactlist.get(i).toString());
		}

		return contactlist;
	}

	public static void main(String[] args) {
		MainApp m = new MainApp();

		System.out.println("========TAO DANH SACH LIEN LAC============");
		int n;
		System.out.println("Nhap n: ");
		n = sc.nextInt();
		m.createContacts(n);
		System.out.println("=======THEM DANH SACH LIEN LAC=========");
		m.addContact();

		System.out.println("=======HIEN THI DANH SACH LIEN LAC======-");
		m.display();

		getConnection();
		exportToDB(MainApp.getContactlist());
		System.out.println("=== LAY DANH SACH TU DB =====");
		importFromDB();
		MainApp.setContactlist(importFromDB());

		System.out.println("==== HIEN THI DANH SACH LIEN LAC ====");
		m.display();
	}

}
