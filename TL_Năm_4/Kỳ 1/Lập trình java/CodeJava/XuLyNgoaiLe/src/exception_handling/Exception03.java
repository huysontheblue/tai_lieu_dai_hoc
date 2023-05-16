// Sử dụng try...catch...finally
// Thay đổi giá trị của b để so sánh kết quả
package exception_handling;

	public class Exception03 {
		public static void main(String[] args) {
			int a = 10, b = 0, x;
			try {
				x = a / b;
				System.out.println("Kết quả x = " + x);
			} catch (ArithmeticException e) { 
				System.out.println("Lỗi: " + e.getMessage());
			} finally {
				System.out.println("Kết thúc chương trình.");
			}
		}
}

