import java.util.Scanner;

public class Cau_5 {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		System.out.print("Nhập N là :");
		int n = sc.nextInt();
		int gt = 1;
		for(int i = 1; i <= n; i++) {
			gt *=i;
		}
		System.out.print("N giai thừa bằng :" + gt);
	}
}



/* tính bằng đề quy 
 * public class Cau_5 {
		static int giaithua(int n) {
			if(n == 1)
				return 1;
			else
        return (n *giaithua(n - 1));
}
	public static void main(String[] args) {
	Scanner sc = new Scanner(System.in);
	System.out.print("Nhập n :");
	int n = sc.nextInt();
    System.out.println("Giai thừa của n là: " + giaithua(n));
	}
}*/
