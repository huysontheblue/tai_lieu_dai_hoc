package de_1;

import java.util.Scanner;

public class Customer {
	private String id, name;
	private double chiSoCu, chiSoMoi;
	private double mucTieuThu, thanhTien;
	// hằng
	private final static Scanner sc = new Scanner(System.in);

	// hàm khởi tạo 0 tham số
	Customer() {

	}
	// hàm khởi tạo 6 tham số
	Customer(String id, String name, double chiSoCu, double chiSoMoi, double mucTieuthu, double thanhTien) {
		this.id = id;
		this.name = name;
		this.chiSoCu = chiSoCu;
		this.chiSoMoi = chiSoMoi;
		this.mucTieuThu = mucTieuthu;
		this.thanhTien = thanhTien;
	}
	// hàm nhập dữ liệu
	public void readData() {
		System.out.print("+  Nhap id : ");
		setId(sc.nextLine());
		System.out.print("+  Nhap ten: ");
		setName(sc.nextLine());
		System.out.print("+ Chi so cu: ");
		setChiSoCu(sc.nextDouble());
		System.out.print("+ Chi so moi: ");
		setChiSoMoi(sc.nextDouble());
		doCalculation();
	}
	
	public String getId() {
		return id;
	}

	public String getName() {
		return name;
	}

	public double getChiSoCu() {
		return chiSoCu;
	}

	public double getChiSoMoi() {
		return chiSoMoi;
	}

	public double getMucTieuThu() {
		return mucTieuThu;
	}

	public void setId(String id) {
		this.id = id;
	}

	public void setName(String name) {
		this.name = name;
	}

	public void setChiSoCu(double chiSoCu) {
		this.chiSoCu = chiSoCu;
	}

	public void setChiSoMoi(double chiSoMoi) {
		this.chiSoMoi = chiSoMoi;
	}

	public void setMucTieuThu(double mucTieuThu) {
		this.mucTieuThu = mucTieuThu;
	}

	public double getThanhTien() {
		return thanhTien;
	}

	public void setThanhTien(double thanhTien) {
		this.thanhTien = thanhTien;
	}

	public void doCalculation() {
		// trong trường hợp nêu mà chỉ số mới- chỉ số cũ do lỗi người dùng
		// nhập nhỏ hơn thì lấy giá trj tuyệt đối
		setMucTieuThu(Math.abs(this.chiSoMoi - this.chiSoCu));
		setThanhTien(getMucTieuThu() * 1500);
	}
	// hàm in ra màn hình
	public void display() {
		System.out.println("_________________________________");
		System.out.println("ID			: " + this.id);
		System.out.println("Tên         : " + this.name);
		System.out.println("Chi số cũ  : " + this.chiSoCu);
		System.out.println("Chỉ số mới : " + this.chiSoMoi);
		System.out.println("Mức tiêu thụ: " + this.mucTieuThu);
		System.out.println("Thành tiền  : " + this.thanhTien);
		System.out.println("_________________________________");
	}

	@Override
	public String toString() {
		return "Customer [id=" + id + ", name=" + name + ", chiSoCu=" + chiSoCu + ", chiSoMoi=" + chiSoMoi
				+ ", mucTieuThu=" + mucTieuThu + ", thanhTien=" + thanhTien + "]";
	}
}
