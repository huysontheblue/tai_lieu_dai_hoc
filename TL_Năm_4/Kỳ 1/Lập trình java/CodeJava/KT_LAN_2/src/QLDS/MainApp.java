package QLDS;

import java.util.ArrayList;
import java.util.Scanner;
	public class MainApp {
		private static int contactNum = 0;
		private static ArrayList<ContactObject> contactList = new ArrayList<>();
		public static void createContact(int n) {
			ContactObject contact;
			for (int i = 1; i <= n; i++) {
				contact = new ContactObject();
				System.out.println("Nhap thong tin lien he thu " + i);
				contact.readData();
				contactList.add(contact);
				contactNum++;
			}
		}
		public static void addContact() {
			ContactObject contact = new ContactObject();
			System.out.println("Nhap thong lien he bo sung");
			contact.readData();
			contactList.add(contact);
			contactNum++;
		}
		public static void display() {
			System.out.println("Thong tin lien he: ");
			for (ContactObject contact : contactList) {
				System.out.println(contact);
			}
		}
		public static void main(String[] args) {
			int n;
			Scanner input = new Scanner(System.in);
			System.out.println("Nhap so luong lien he: ");
			n = input.nextInt();
			createContact(n);
			addContact();
			display();
			input.close();
		}
	}