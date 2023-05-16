package Cau2;

import java.util.ArrayList;
import java.util.Scanner;

public class MainApp {
		private static final int BOOK_MAX = 10;
		private static int bookNum = 0;
		private static ArrayList<Book> booklist= new ArrayList<>();
		
		public static void intBooks(int n) {
			Book book;
			for(int i = 1; i <= n; i++) {
				book = new Book();
				System.out.println("Nhập thông tin tài liệu thứ " + i);
				book.readData();
				if(booklist.size() < BOOK_MAX) {
					booklist.add(book);
					bookNum++;
				} else {
					return;
				}
			}
		}
		public static void searchBook() {
			
		}
		public static void display() {
			for(Book book : booklist) {
				System.out.println(book);
			}
		}

		public static void main(String[] args) {
			Scanner sc = new Scanner(System.in);
			System.out.print("Nhập số lượng Book: ");
			int n = sc.nextInt();
			intBooks(n);
			display();
			System.out.println("So luong tai lieu la : " +  n + " " + booklist);
		}
	} 
