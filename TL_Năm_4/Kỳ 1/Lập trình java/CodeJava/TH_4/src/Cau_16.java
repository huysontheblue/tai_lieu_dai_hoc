
import java.util.Scanner;

class SinhVien {
	String MaSv, hoten;
	float diemLT, diemTH;
	
	void nhapSV() { 
			Scanner sc = new Scanner(System.in);
			System.out.print("Nhập mã sinh viên: ");
			MaSv = sc.nextLine();
			System.out.print("Nhập họ tên sinh viên: ");
			hoten = sc.nextLine();
			System.out.print("Nhập điểm lý thuyết: ");
			diemLT = sc.nextFloat();
			System.out.print("Nhập điểm thực hành: ");
			diemTH = sc.nextFloat();
			sc.close();
	}
	
	float diemTB() {
		return (diemLT + diemTH) / 2;
	}
	
	String ketquaHT() {
		if(diemTB() >=5)
			return "Đậu";
		else 
			return "Trượt"; 
	}
	
	void xuatSV() {
		System.out.println("Mã SV: " + MaSv);
		System.out.println("Tên SV: " + hoten);
		System.out.println("Điểm lý thuyết: "+ diemLT);
		System.out.println("Điểm thực hành: "+  diemTH);
		System.out.println("Điểm TB:" + diemTB());
		System.out.println("Kết quả học tập: "+ ketquaHT());
	}
}
public class Cau_16 {
    public static void main(String[] args) {
    	SinhVien sv = new SinhVien();
    	sv.nhapSV();
    	sv.xuatSV();
    }
}