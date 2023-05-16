package array_list;

import java.util.ArrayList; 
import java.util.Scanner; 
	public class DanhSachSinhVien { 
		public static void main(String[] args) { 
			ArrayList<SinhVien> dssv = new ArrayList<>(); 
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
 
			for (SinhVien sinhVien : dssv) { 
				System.out.println(sinhVien); 
			} 
 
			input.close(); 
		} 
}
