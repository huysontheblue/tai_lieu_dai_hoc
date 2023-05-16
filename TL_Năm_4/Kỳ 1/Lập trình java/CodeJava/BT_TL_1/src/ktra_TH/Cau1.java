package ktra_TH;

import java.util.Scanner;

public class Cau1 {

	String ISBN;
    String Author;
    String title;
    int copyNum;

    public Cau1(String Book, String Author, int year) {
        this.ISBN = ISBN;
        this.Author = Author;
        this.title = title;
        this.copyNum = copyNum;
    }

    public String getISBN() {
        return ISBN;
    }

    public void setISBN(String ISBN) {
        this.ISBN = ISBN;
    }
//
    public String gettitle() {
        return title;
    }

    public void settitle(String title) {
        this.title = title;
    }
    
    public String getAuthor() {
        return Author;
    }

    public void setAuthor(String Author) {
        this.Author = Author;
    }

    public String getcopyNum() {
        return Author;
    }

    public void setcopyNumr(int copyNum) {
        this.copyNum = copyNum;
    }
    
    public void input(){
        Scanner input = new Scanner(System.in);
        System.out.print("ISBN : ");
        ISBN = input.nextLine();
        System.out.print("Title: ");
        title = input.nextLine();
        System.out.print("Author: ");
        Author = input.nextLine();
        System.out.print("copyNum: ");
        copyNum = Integer.parseInt(input.nextLine());
    }
    
    public void output(){
        System.out.println("\nBook is "+ISBN);
        System.out.println("Title is "+title);
        System.out.println("Author is "+Author);
        System.out.println("CopyNum is "+copyNum);
    }
	

}