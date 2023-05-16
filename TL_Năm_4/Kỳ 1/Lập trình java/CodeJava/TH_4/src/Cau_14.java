import java.util.Scanner;

class Hinhtron {
	float banKinh;
	double chuvi() {
		return 2 * Math.PI * banKinh;
	}
	double dientich() {
		return Math.PI * banKinh * banKinh;
	}
}
public class Cau_14 {
	public static void main(String[] args) {
		Hinhtron ht = new Hinhtron();
		Scanner sc = new Scanner(System.in);
		System.out.print("Nhập bán kính :");
		ht.banKinh = sc.nextFloat();
		System.out.println("Chu vi hình tròn: " + ht.chuvi());
		System.out.println("Diện tích hình tròn: " +ht.dientich());
	}
}
