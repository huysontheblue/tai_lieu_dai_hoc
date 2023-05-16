import java.util.Scanner;

public class Cau_7 {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		System.out.print("Nhập họ tên của bạn :");
		String ht = sc.nextLine();
		ht.trim(); // xóa các khoảng cách trắng
		// kiểm tra xem họ tên có chứa họ trần hay k
		if(ht.startsWith("Tran")) {
			System.out.print("Họ của bạn là họ : Tran");
		}
		else {
			System.out.print("Họ của bạn không phải họ : Tran");
		}

	}

}
