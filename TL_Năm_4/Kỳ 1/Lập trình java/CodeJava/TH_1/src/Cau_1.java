
import java.util.Scanner;
public class Cau_1 {
	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		float a, b;
		System.out.print("Nhập a = ");
		a = sc.nextFloat();
		System.out.print("Nhập b = ");
		b = sc.nextFloat();
		if(a != 0) {
			System.out.print("Phuong trinh có nghiem x = " + (-b/a));
			
		} else {
			if(b==0)
				System.out.print("Phuong trinh vo so nghiem");
			else 
				System.out.print("Phuong trinh so nghiem");
		}
	}
}
