package HSHP2;


import java.util.LinkedList;
import java.util.Scanner;

public class MainOfGiangVien {
	//private static int contactNum = 0;
	final static int N = 2;
	private static LinkedList<GiangVien> giangvientList = new LinkedList<>();
	public static void createGiangVien(int n) {
		GiangVien gv;
		for (int i = 1; i <= n; i++) {
			gv= new GiangVien();
			System.out.println("Nhap thong tin giang vien thu " + i);
			gv.nhapGV();
			giangvientList.add(gv);
			//contactNum++;
		}
	}
	public static void addGiangVien() {
		GiangVien gv = new GiangVien();
		System.out.println("Nhap thong tin giang vien");
		gv.nhapGV();
		giangvientList.add(gv);
		//contactNum++;
	}
	public static void display(LinkedList<GiangVien> LinkedList) {
		System.out.println("Thong tin giang vien: ");
		for (GiangVien gv : giangvientList) {
			System.out.println(gv);
		}
	}
	public static void main(String[] args) throws Exception {
		int cvSo;
		Scanner sc = new Scanner(System.in);
		while (true) {
			System.out.println("QUAN LY SINH VIEN");
			System.out.println("1. Tao ArrayList");
			System.out.println("2. Bo sung 1 giang vien"); 
			System.out.println("3. In danh sach giang vien");
			System.out.println("4. Luu danh sach giang vien vao CSDL");
			System.out.println("5. Doc du lieu tu CSDL");
			System.out.println("6. Thoat");
			System.out.print("Ban chon cong viec so: ");
			cvSo = sc.nextInt();
			switch (cvSo) {
			case 1:
				createGiangVien(N);
				break;
			case 2:
				addGiangVien();
				break;
			case 3:
				display(giangvientList);
				break;
			case 4:
				ConnecttionGiangVien.exportToDBGV(giangvientList);
				break;
			case 5:
				ConnecttionGiangVien.exportToDBGV(giangvientList);
				break;
			default:
				System.out.println("Done!");
				return;
			}
		}
	}
}
