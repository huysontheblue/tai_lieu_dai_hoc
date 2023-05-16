package HSHP2;

import java.util.Scanner;

public class GiangVien {
	private int magv, luong;
	private String hoten;
	
	private final static Scanner sc = new Scanner(System.in);

	GiangVien() {

	}

	GiangVien(int magv, String hoten, int luong) {
		this.magv = magv;
		this.hoten = hoten;
		this.luong = luong;
	}
	public void nhapGV() {
		System.out.print("Nhap magv: ");
		this.magv = sc.nextInt();
		sc.nextLine();
		System.out.print("Nhap ho ten GV: ");
		this.hoten = sc.nextLine();
		System.out.print("Nhap luong: ");
		this.luong = sc.nextInt();
	}

	public int getMagv() {
		return magv;
	}

	public void setMagv(int magv) {
		this.magv = magv;
	}

	public int getLuong() {
		return luong;
	}

	public void setLuong(int luong) {
		this.luong = luong;
	}

	public String getHoten() {
		return hoten;
	}

	public void setHoten(String hoten) {
		this.hoten = hoten;
	}

	@Override
	public String toString() {
		return "Giang Vien : " + magv + " " + hoten + " " + luong ;
	}
	
}
