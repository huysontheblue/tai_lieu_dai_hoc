package hash_set;

import java.util.HashSet; 
import java.util.Scanner; 
	public class DanhSachSinhVien { 
		static void inDSSV(HashSet<SinhVien> dssv) { 
			for (SinhVien sinhVien : dssv) { 
				System.out.println(sinhVien); 
			} 
		} 
		public static void main(String[] args) { 
			HashSet<SinhVien> dssv = new HashSet<>(); 
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
			input.close(); 
		}
	}
