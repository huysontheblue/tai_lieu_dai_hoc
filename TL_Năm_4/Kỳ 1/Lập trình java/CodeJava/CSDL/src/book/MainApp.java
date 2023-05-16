package book;

import java.util.ArrayList;
import java.util.Scanner;

public class MainApp {
	final static int bookMax = 10;
	static int bookNum = 0;
	static Scanner input = new Scanner(System.in);
	static ArrayList<Book> bookList = new ArrayList<>();
	public static void initBooks(int N) {
		for (var i = 1; i <= N; i++) {
			addBook();
		}
	} 
	public static void addBook() {
		if (bookNum == bookMax) {
			System.out.println("Danh sách đã đầy!");
			return;
		}
		Book book = new Book();
		book.readData();
		bookList.add(book);
		bookNum++;
	}
	public static void searchBook() {
		String title;
		input.nextLine();
		System.out.print("Nhap title can tim: ");
		title = input.nextLine();
		for (Book book : bookList) {
			if (book.getTitle().equals(title)) {
				System.out.println("Tim thay");
				System.out.println(book);
				return;
			}
		}
		System.out.println("Khong tim thay");
	}
	public static void display() {
		for (Book book : bookList) {
			System.out.println(book);
		}
	}
	public static void main(String[] args) throws Exception {
		int chon;
		while (true) {
			System.out.println("1. initBooks");
			System.out.println("2. addBook");
			System.out.println("3. searchBook"); 
			System.out.println("4. display");
			System.out.println("5. importFromDB");
			System.out.println("6. exportToDB");
			System.out.println("7. Exit");
			System.out.print("Chon cong viec so: ");
			chon = input.nextInt();
			switch (chon) {
			case 1:
				System.out.print("Nhap so luong: ");
				int N = input.nextInt();
				initBooks(N);
				break;
			case 2:
				addBook();
				break;
			case 3:
				searchBook();
				break;
			case 4:
				display();
				break;
			case 5:
				ConnectionBook.importFromDB(bookList);
				break;
			case 6:
				ConnectionBook.exportToDB(bookList);
				break;
			default:
				System.out.println("Bye bye!");
				return;
			}
		}
	}
}
