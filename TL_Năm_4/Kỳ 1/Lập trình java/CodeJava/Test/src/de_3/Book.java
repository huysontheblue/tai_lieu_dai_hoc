package de_3;

import java.util.Scanner;

public class Book {
	private String isbn, title, authors;
	private int copyNum;

	// hằng
	private final static Scanner sc = new Scanner(System.in);

	// hàm khỏi tạo 0 tham số
	public Book() {
	}

	// hàm khởi tạo 4 tham số
	public Book(String isbn, String title, String authors, int copyNum) {
		this.isbn = isbn;
		this.title = title;
		this.authors = authors;
		this.copyNum = copyNum;
	}

	// hàm nhập dữ liệu
	public void readData() {
		System.out.println("isbn: ");
		isbn = sc.nextLine();
		System.out.println("title: ");
		title = sc.nextLine();
		System.out.println("authors: ");
		authors = sc.nextLine();
		System.out.println("copyNum: ");
		copyNum = sc.nextInt();
	}

	public String getIsbn() {
		return isbn;
	}

	public void setIsbn(String isbn) {
		this.isbn = isbn;
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

	public int getCopyNum() {
		return copyNum;
	}

	public void setCopyNum(int copyNum) {
		this.copyNum = copyNum;
	}

	@Override
	public String toString() {
		return isbn + "    " + title + "    " + authors + "   " + copyNum;
	}

	// hàm in ra màn hình
	public void display() {
		System.out.println(isbn + "    " + title + "    " + authors + "   " + copyNum);
	}
}
