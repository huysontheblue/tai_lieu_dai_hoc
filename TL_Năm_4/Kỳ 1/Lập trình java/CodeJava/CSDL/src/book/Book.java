package book;

import java.util.Scanner;

public class Book {
	private String ISBN, title, authors;
	private int copyNum;

	Scanner input = new Scanner(System.in);

	public void readData() {
		System.out.println("Nhap thong tin Tai lieu: ");
		System.out.print("+ ISBN: ");
		this.ISBN = input.nextLine();
		System.out.print("+ Title: ");
		this.title = input.nextLine();
		System.out.print("+ Authors: ");
		this.authors = input.nextLine();
		System.out.print("+ copyNum: ");
		this.copyNum = input.nextInt();
		input.nextLine();
	}
 
 // Các phương thức setters & getters
	
	@Override
	public String toString() {
		return "Book [ISBN=" + ISBN + ", title=" + title + ", authors=" + authors + ", copyNum=" + copyNum + ", input="
				+ input + "]";
	}
	
	public String getISBN() {
		return ISBN;
	}

	public void setISBN(String iSBN) {
		ISBN = iSBN;
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

	public Scanner getInput() {
		return input;
	}

	public void setInput(Scanner input) {
		this.input = input;
	}
	
} 
