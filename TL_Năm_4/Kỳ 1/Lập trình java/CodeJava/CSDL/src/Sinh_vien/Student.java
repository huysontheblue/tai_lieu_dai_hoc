package Sinh_vien;

import java.util.Scanner;

public class Student {
	private int masv;
	private String hoten;
	private float diem;

	public void inputStudent() {
		Scanner input = new Scanner(System.in);
		System.out.print("Mã sinh viên: ");
		this.masv = input.nextInt();
		input.nextLine();
		System.out.print("Họ và tên: ");
		this.hoten = input.nextLine();
		System.out.print("Điểm: ");
		this.diem = input.nextFloat();
 	}
	public void setMasv(int masv) {
		this.masv = masv;
	}
	public void setHoten(String hoten) {
		this.hoten = hoten;
	}
	public void setDiem(float diem) {
		this.diem = diem;
	} 
	public int getMasv() {
		return masv;
	}
	public String getHoten() {
		return hoten;
	}
	public float getDiem() {
		return diem;
	}
	@Override
	public String toString() {
		return masv + " " + hoten + " " + diem;
	}
}
