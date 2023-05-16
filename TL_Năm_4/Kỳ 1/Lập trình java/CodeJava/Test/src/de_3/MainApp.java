package de_3;

import java.sql.*;
import java.util.ArrayList;
import java.util.Scanner;


public class MainApp {
    private int maxNum;
    private int bookNum;
    private static Connection con;
    private static ArrayList<Book> booklist;

    // hằng 
   	private final static Scanner sc = new Scanner(System.in);
   	
    public MainApp() {
        booklist = new ArrayList<>();
    }

    public static ArrayList<Book> getBooklist() {
        return booklist;
    }

    public static void setBooklist(ArrayList<Book> booklist) {
        MainApp.booklist = booklist;
    }

    public int getMaxNum() {
        return maxNum;
    }

    public void setMaxNum(int maxNum) {
        this.maxNum = maxNum;
    }

    public int getBookNum() {
        return bookNum;
    }

    public void setBookNum(int bookNum) {
        this.bookNum = bookNum;
    }

    public void initbook(int n){
        for(int i =0; i< n; i++){
            System.out.println("NHAP SACH THU: " + i);
            Book cm = new Book();
            cm.readData();
            booklist.add(cm);
        }
    }
    public void addbook(){
        Book st = new Book();
        st.readData();
        booklist.add(st);
    }
    public void display(){
        for (int i = 0; i < booklist.size(); i++) {
            System.out.println(booklist.get(i).toString());
        }
    }
    public static void getConnection(){
        try {
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }

        try {
            con = DriverManager.getConnection("jdbc:sqlserver://localhost:1433;" +"Databasename=bookdb","sa","sa");
        } catch (SQLException e) {
            e.printStackTrace();
        }

        if(con != null){
            System.out.println("Ket noi thanh cong");
        }else{
            System.out.println("ket noi that bai");
        }
    }

    public static void exportToDB(ArrayList<Book> booklist){
        try {
            Statement s = con.createStatement();
            for (int i = 0; i < booklist.size(); i++) {
                String sqlInset = "insert into tabbooks values ('"+booklist.get(i).getIsbn()+"','"+
                        booklist.get(i).getTitle()+"','"
                        + booklist.get(i).getAuthors() + "','"
                        + booklist.get(i).getCopyNum() + "')";
                s.executeUpdate(sqlInset);
            }
            System.out.println("Danh sach da duoc them vao DB");

        } catch (SQLException e) {
            e.printStackTrace();
            System.out.println("Them vao that bai");
        }
    }
    public static ArrayList<Book> importFromDB(){
        ArrayList<Book> list = new ArrayList<>();
        String slqSeclect = "select * from tabbooks";

        try {
            Statement s = con.createStatement();
            ResultSet rs = s.executeQuery(slqSeclect);
            while (rs.next()){
                String isbn, title, authors;
                int copyNum;
                isbn = rs.getString(1);
                title =rs.getString(2);
                authors = rs.getString(3);
                copyNum = rs.getInt(4);
                Book cm = new Book(isbn,title,authors,copyNum);
                list.add(cm);
            }

        } catch (SQLException e) {
            e.printStackTrace();
        }

        System.out.println(" Da lay duoc du lieu tu DB thanh cong");

        for (int i = 0; i < list.size(); i++) {
            System.out.println(list.get(i).toString());
        }

        return list;
    }
    public static void main(String[] args) {
        MainApp m = new MainApp();

        System.out.println("========TAO DANH SACH============");
        int n;
        System.out.println("Nhap n: ");
        n = sc.nextInt();
        m.initbook(n);
        System.out.println("=======THEM SACH=========");
        m.addbook();

        System.out.println("=======HIEN THI DANH SACH======-");
        m.display();

        getConnection();
        exportToDB(MainApp.getBooklist());
        System.out.println("=== LAY DANH SACH TU DB =====");
        importFromDB();
        MainApp.setBooklist(importFromDB());

        System.out.println("==== HIEN THI DANH SACH ====");
        m.display();
    }
}
