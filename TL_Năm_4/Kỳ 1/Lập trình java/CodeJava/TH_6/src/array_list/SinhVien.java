package array_list;
import java.util.Scanner; 
	public class SinhVien { 
		private Scanner input = new Scanner(System.in); 
		private int masv; 
		private String hoten; 
		private float diem;
		
		public void nhapSV() { 
			System.out.print("+ Ma sinh vien: "); 
			this.masv = input.nextInt(); 
			input.nextLine(); 
			System.out.print("+ Ho va ten: "); 
			this.hoten = input.nextLine(); 
			System.out.print("+ Diem: "); 
			this.diem = input.nextFloat(); 
		} 
		@Override
		public String toString() { 
			return masv + " " + hoten + " " + diem; 
	} 
} 