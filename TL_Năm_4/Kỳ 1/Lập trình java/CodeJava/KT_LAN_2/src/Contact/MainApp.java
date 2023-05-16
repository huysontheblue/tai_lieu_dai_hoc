package Contact;

import java.util.ArrayList;
import java.util.Scanner;

public class MainApp {
	final static int N = 2;
	static ArrayList<ContactObject> ContactObjectList = new ArrayList<>();
	static void createContacts(int n) {
		ContactObject co;
		for (var i = 1; i <= 2; i++) { 
			System.out.println("Nhap danh sach liên lac thu " + i);
			co = new ContactObject();
			co.readData();
			ContactObjectList.add(co);
		}
	}
	static void addContacts() {
		ContactObject co;
		System.out.println("Nhap bo sung");
		co = new ContactObject();
		co.readData();
		ContactObjectList.add(co);
	}

	static void display(ArrayList<ContactObject> arrList) {
		System.out.println("Danh sach lien lac duoc nhap la:");
		if (ContactObjectList.size() == 0)
			System.out.println("Danh sach rong!");
		else
			for (ContactObject contactobject : arrList) {
				System.out.println(contactobject);
			}
	}
	public static void main(String[] args) throws Exception {
		int cvSo;
		Scanner sc = new Scanner(System.in);
		while (true) {
			System.out.println("QUAN LY DANH SACH LIEN LAC");
			System.out.println("1. Tao ArrayList");
			System.out.println("2. Bo sung lien"); 
			System.out.println("3. In danh sach lien lac");
			System.out.println("4. Thoat");
			System.out.print("Ban chon cong viec so: ");
			cvSo = sc.nextInt();
			switch (cvSo) {
			case 1:
				createContacts(N);
				break;
			case 2:
				addContacts();
				break;		
			case 3:
				display(ContactObjectList);
				break;
			default:
				System.out.println("Done!");
				return;
			}
		}
	}
}
