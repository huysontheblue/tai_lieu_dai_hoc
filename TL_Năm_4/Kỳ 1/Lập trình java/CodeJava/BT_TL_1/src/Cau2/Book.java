package Cau2;
import java.util.Scanner;

	public class Book {
		Scanner sc = new Scanner(System.in);
		private int ISBN, copyNum; 
		private String title, authors; 
			
		public void readData() { 
			System.out.print("Nhập mã ISBN :"); 
			ISBN = sc.nextInt(); 
			sc.nextLine(); 
			System.out.print("Nhập Title :"); 
			this.title = sc.nextLine(); 
			System.out.print("Nhập Authors :"); 
			this.authors = sc.nextLine(); 
			System.out.print("Nhập CopyNum :"); 
			this.copyNum = sc.nextInt(); 
		} 
		
		@Override
		public String toString() { 
			return "Thông tin book: " + ISBN + " , " +  title + " , " +  authors + " , " + copyNum;
		}
		
		public int getISBN() {
			return ISBN;
		}

		public void setISBN(int iSBN) {
			ISBN = iSBN;
		}

		public int getCopyNum() {
			return copyNum;
		}

		public void setCopyNum(int copyNum) {
			this.copyNum = copyNum;
		}

		public String getTitle() {
			return title;
		}

		public void setTitle(String title) {
			this.title = title;
		}

		public String getAuthors() {
			return authors;
		}

		public void setAuthors(String authors) {
			this.authors = authors;
		} 
	}
