package BT_TL2;

import java.util.Scanner;

public class Student {
	private String id, name, xeploai;
	private float diem1, diem2, diem3, dtong;
	private final static Scanner sc = new Scanner(System.in);
	
	public void inputStudent() {
		System.out.print("Mã sinh viên: ");
		this.id = sc.nextLine();
		System.out.print("Ho va ten: ");
		this.name = sc.nextLine();
		System.out.print("Diem 1: ");
		this.diem1 = sc.nextFloat();
		System.out.print("Diem 2: ");
		this.diem2 = sc.nextFloat();
		System.out.print("Diem 3: ");
		this.diem3 = sc.nextFloat();
		System.out.print("Diem tong: ");
		this.dtong = sc.nextFloat();
		System.out.print("Xep loai: ");
		this.xeploai = sc.nextLine();
 	}
	
	public void display() {
		System.out.println("_________________________________");
		System.out.println("ID : " + this.id);
		System.out.println("Ho va ten : " + this.name);
		System.out.println("Diem 1 : " + this.diem1);
		System.out.println("Diem 2 : " + this.diem2);
		System.out.println("Diem 3 : " + this.diem3);
		System.out.println("Diem tong : " + this.dtong);
		System.out.println("Xep loai : " + this.xeploai);
		System.out.println("_________________________________");
	}
	
	@Override
	public String toString() {
		return "Student [id=" + id + ", name=" + name + ", xeploai=" + xeploai + ", diem1=" + diem1 + ", diem2=" + diem2
				+ ", diem3=" + diem3 + ", dtong=" + dtong + "]";
	}

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getXeploai() {
		return xeploai;
	}

	public void setXeploai(String xeploai) {
		this.xeploai = xeploai;
	}

	public float getDiem1() {
		return diem1;
	}

	public void setDiem1(float diem1) {
		this.diem1 = diem1;
	}

	public float getDiem2() {
		return diem2;
	}

	public void setDiem2(float diem2) {
		this.diem2 = diem2;
	}

	public float getDiem3() {
		return diem3;
	}

	public void setDiem3(float diem3) {
		this.diem3 = diem3;
	}

	public float getDtong() {
		return dtong;
	}

	public void setDtong(float dtong) {
		this.dtong = dtong;
	}

	public void doGrade() {
		this.dtong = getDiem1() + getDiem2() + getDiem3();
		if(this.dtong >= 15) {
			this.xeploai = "Đạt";
			}
		else {
			this.xeploai = "Không đạt";
		}
	}
}
