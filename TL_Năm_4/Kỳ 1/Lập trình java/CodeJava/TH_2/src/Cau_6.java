import java.util.Scanner;
public class Cau_6 {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		System.out.print("Nhập chuỗi : ");
		String chuoi = sc.nextLine();
		System.out.print("Nhập ký tự : ");
		char c = sc.next().charAt(0);
		int answer = 0;
		for (int i = 0; i < chuoi.length(); i++) {
			if(chuoi.charAt(i) == c) {
				answer ++;
			}
		}
		System.out.print(answer);
	}
}
