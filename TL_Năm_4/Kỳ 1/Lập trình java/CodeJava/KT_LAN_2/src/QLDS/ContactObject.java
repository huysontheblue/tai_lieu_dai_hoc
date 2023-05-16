package QLDS;

import java.util.Scanner;

public class ContactObject {
	private int id;
	private String name, phone, address, email;

	private final static Scanner input = new Scanner(System.in);

	ContactObject() {

	}

	ContactObject(int id, String name, String phone, String address, String email) {
		this.id = id;
		this.name = name;
		this.phone = phone;
		this.address = address;
		this.email = email;
	}

	public void readData() {
		System.out.print("+ ID: ");
		this.id = input.nextInt();
		input.nextLine();
		System.out.print("+ Name: ");
		this.name = input.nextLine();
		System.out.print("+ Phone: ");
		this.phone = input.nextLine();
		System.out.print("+ Address: ");
		this.address = input.nextLine();
		System.out.print("+ Email: ");
		this.email = input.nextLine();
	}

	@Override
	public String toString() {
		return "ContactObject [id=" + id + ", name=" + name + ", phone=" + phone + ", address=" + address + ", email="+ email + "]";
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

	public static Scanner getInput() {
		return input;
	}
}