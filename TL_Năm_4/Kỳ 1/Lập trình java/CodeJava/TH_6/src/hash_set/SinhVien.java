package hash_set;

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
 
		// Source -> Generate toString
		@Override
		public String toString() { 
			return masv + " " + hoten + " " + diem; 
		} 
		// Source -> Generate hashCode() and equals() -> chọn masv
		@Override
		public int hashCode() { 
			final int prime = 31; 
			int result = 1; 
			result = prime * result + masv; 
			return result; 
		} 
		@Override
		public boolean equals(Object obj) { 
			if (this == obj) 
				return true; 
			if (obj == null) 
				return false; 
			if (getClass() != obj.getClass()) 
				return false; 
			SinhVien other = (SinhVien) obj; 
			if (masv != other.masv) 
				return false; 
			return true; 
		} 
}
