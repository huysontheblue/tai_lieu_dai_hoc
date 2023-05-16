// Chưa xử lý ngoại lệ
// Thay đổi giá trị của b để so sánh kết quả
package exception_handling;

import java.util.Scanner;

public class Exception01 {
		public static void main(String[] args) {
			Scanner sc = new Scanner(System.in);
			int a, b, x;
			System.out.print("Nhập a = ");
			a = sc.nextInt();
			System.out.print("Nhập b = ");
			b = sc.nextInt();
			x = a /b;
			System.out.println("Kết quả x = " + x); 
			System.out.println("Kết thúc chương trình.");
	}
}

