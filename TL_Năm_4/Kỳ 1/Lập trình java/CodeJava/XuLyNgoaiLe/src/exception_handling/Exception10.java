// Nhập 1 mảng số int có xử lý ngoại lệ
package exception_handling;

import java.util.Scanner;

	public class Exception10 {
		public static void main(String[] args) {
			final int n = 5;
			int[] a = new int[n];
			Scanner input = new Scanner(System.in);
			int i = 0;
			while (i < n) {
				System.out.print("Nhập a[" + i + "] = ");
				try {
					a[i] = input.nextInt(); i++;
				} catch (Exception e) { 
					System.out.println("Lỗi! nhập lại."); 
					input.nextLine();
				}
			}
			for (i = 0; i < n; i++) { 
				System.out.print(a[i] + " ");
			}
			System.out.println("\nKết thúc!");
			input.close();
		}
	}

