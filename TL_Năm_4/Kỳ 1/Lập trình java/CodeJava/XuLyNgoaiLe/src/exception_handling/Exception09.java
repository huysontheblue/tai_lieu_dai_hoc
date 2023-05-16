// Nhập 1 số int có xử lý ngoại lệ
package exception_handling;

import java.util.Scanner;

	public class Exception09 {
		public static void main(String[] args) {
			int number;
			Scanner input = new Scanner(System.in);
			boolean ok = false;
			do {
				System.out.print("Nhập số: ");
				try {
					number = input.nextInt(); ok = true;
					System.out.println("Số được nhập là: " + number);
				} catch (Exception e) { 
					System.out.println("Nhập sai!"); 
					input.nextLine();
				}
			} while (ok == false);
			System.out.println("Kết thúc chương trình."); 
			input.close();
		}
}

