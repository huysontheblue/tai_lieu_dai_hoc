package huy_son;

import java.util.Scanner;

public class ContactObject {

	private String id, name, phone, address, email;

	private final static Scanner sc = new Scanner(System.in);

	public ContactObject() {
		
	}

	public ContactObject(String id, String name, String phone, String address, String email) {
		this.id = id;
		this.name = name;
		this.phone = phone;
		this.address = address;
		this.email = email;
	}

	public void readData() {
		System.out.println("id : ");
		id = sc.nextLine();
		System.out.println("name : ");
		name = sc.nextLine();
		System.out.println("phone : ");
		phone = sc.nextLine();
		System.out.println("address : ");
		address = sc.nextLine();
		System.out.println("email : ");
		email = sc.nextLine();
	}

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
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
		return id + "    " + name + "    " + phone + "   " + address + "   " + email;
	}

	public void display() {
		System.out.println(id + "    " + name + "    " + phone + "   " + address + "   " + email);
	}
}
