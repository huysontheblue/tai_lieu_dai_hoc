
import java.util.Scanner;

public class Cau_4 {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		System.out.print("Nhập n = ");
		int n = sc.nextInt();
		int sum =0;
		for (int i = 0; i <= n ;i++) {
			sum +=i;
		}
		System.out.println(sum);
	}
}
