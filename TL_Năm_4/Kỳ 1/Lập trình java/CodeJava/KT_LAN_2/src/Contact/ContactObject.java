package Contact;

import java.util.Scanner;

public class ContactObject {
	private int id;
	private String name;
	private int phone;
	private String address;
	private String email;
	
	public void readData() {
		Scanner sc = new Scanner(System.in);
		System.out.print("Nhap Id: ");
		this.id = sc.nextInt();
		sc.nextLine();
		System.out.print("Nhap Tên: ");
		this.name = sc.nextLine();
		System.out.print("Nhap Phone: ");
		this.phone = sc.nextInt();
		System.out.print("Nhap dia chi: ");
		this.address = sc.nextLine();
		sc.nextLine();
		System.out.print("Nhap mail:");
		this.email = sc.nextLine();
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getPhone() {
		return phone;
	}

	public void setPhone(int phone) {
		this.phone = phone;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	@Override
	public String toString() {
		return "Thông tin liên lạc: " + id + " " + name + "" + phone +" "+ address + " "+ email;
	} 
}
