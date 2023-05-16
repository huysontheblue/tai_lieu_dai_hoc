package Sinh_vien;

import java.util.ArrayList;
import java.util.Scanner;

public class MainApp {
	final static int N = 3;
	static ArrayList<Student> studentList = new ArrayList<>();
	static void createStudent(int n) {
		Student sv;
		for (var i = 1; i <= 3; i++) { 
			System.out.println("Nhap sinh vien thu " + i);
			sv = new Student();
			sv.inputStudent();
			studentList.add(sv);
		}
	}
	static void addStudent() {
		Student sv;
		System.out.println("Nhap sinh vien bo sung");
		sv = new Student();
		sv.inputStudent();
		studentList.add(sv);
	}
	static boolean searchStudent(String hoten) {
		for (Student student : studentList) {
			if (student.getHoten().equals(hoten))
				return true;
		}
		return false;
	}
	static void display(ArrayList<Student> arrList) {
		System.out.println("Danh sach sinh vien duoc nhap la:");
		if (studentList.size() == 0)
			System.out.println("Danh sach rong!");
		else
			for (Student student : arrList) {
				System.out.println(student);
			}
	}
	public static void main(String[] args) throws Exception {
		int cvSo;
		Scanner input = new Scanner(System.in);
		while (true) {
			System.out.println("QUAN LY SINH VIEN");
			System.out.println("1. Tao ArrayList");
			System.out.println("2. Bo sung 1 sinh vien"); 
			System.out.println("3. Tim sinh vien theo hoten");
			System.out.println("4. In danh sach sinh vien");
			System.out.println("5. Luu danh sach sinh vien vao CSDL");
			System.out.println("6. Doc du lieu tu CSDL");
			System.out.println("7. Thoat");
			System.out.print("Ban chon cong viec so: ");
			cvSo = input.nextInt();
			switch (cvSo) {
			case 1:
				createStudent(N);
				break;
			case 2:
				addStudent();
				break;
			case 3:
				if (searchStudent("2"))
					System.out.println("Tim thay");
				else
					System.out.println("Khong tim thay");
				break;
			case 4:
				display(studentList);
				break;
			case 5:
				ConnectionSinhVien.importToDB(studentList);
				break;
			case 6:
				ConnectionSinhVien.exportFromDB(studentList);
				break;
			default:
				System.out.println("Done!");
				return;
			}
		}
	}
}
