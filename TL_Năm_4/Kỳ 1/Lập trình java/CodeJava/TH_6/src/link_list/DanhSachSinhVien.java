package link_list;

import java.util.LinkedList; 
import java.util.Scanner; 
	public class DanhSachSinhVien { 
		static void inDSSV(LinkedList<SinhVien> dssv) { 
			for (SinhVien sinhVien : dssv) { 
				System.out.println(sinhVien); 
			} 
		} 
		public static void main(String[] args) { 
			LinkedList<SinhVien> dssv = new LinkedList<>(); 
			Scanner input = new Scanner(System.in); 
			System.out.print("Nhap so luong sinh vien n = "); 
			int n = input.nextInt(); 
			SinhVien sv; 
			for(int i = 1; i <= n; i++) { 
				sv = new SinhVien(); 
				System.out.println("Nhap thong tin sinh vien thu " + i); 
				sv.nhapSV(); 
				dssv.add(sv); 
			} 
			System.out.println("Danh sách sinh viên được nhập:"); 
			inDSSV(dssv); 
 
			System.out.println("Nhap thong tin sinh vien bo sung:"); 
			sv = new SinhVien(); 
			sv.nhapSV(); 
			dssv.addLast(sv); // dssv.addFirst(sv);
 
			System.out.println("Danh sách sinh viên sau khi bổ sung:"); 
			inDSSV(dssv); 
 
			input.close(); 
		} 
	}
