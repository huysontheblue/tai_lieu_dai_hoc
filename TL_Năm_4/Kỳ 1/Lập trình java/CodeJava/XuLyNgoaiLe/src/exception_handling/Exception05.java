// Sử dụng throw để ném ra 1 ngoại lệ
// Thay đổi giá trị của age để so sánh kết quả
package exception_handling;

	public class Exception05 {
		static int age = 17;

		static void checkAge(int age) {
			if (age < 18) {
				throw new ArithmeticException("Tuổi không hợp lệ!");
			} else {
				System.out.println("Tuổi hợp lệ!");
			}
		}

		public static void main(String args[]) {
			try {
				checkAge(age);
			} catch (ArithmeticException e) { 
				System.out.println(e.getMessage());
			}
			System.out.println("Kết thúc chương trình.");
		}
}

