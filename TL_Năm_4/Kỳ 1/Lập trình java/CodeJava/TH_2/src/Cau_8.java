import java.util.Scanner;

public class Cau_8 {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		System.out.print("Nhập chuỗi ban đầu : ");
		String s = sc.nextLine();
		String daongc = " ";
		for(int i = s.length()-1; i >= 0; i--) {
			daongc +=s.charAt(i); 
		}
		System.out.print("Chuỗi đảo ngược : "+daongc);
	}

}
