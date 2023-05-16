// Khai báo throws để ném ra ngoại lệ
// Các ngoại lệ checked đều phải được khai báo bởi throws
// Bỏ ArithmeticException hoặc FileNotFoundException để kiểm chứng
package exception_handling;

	import java.io.FileNotFoundException;

	class ThrowsExample {
		void myMethod(int num) throws ArithmeticException,
		FileNotFoundException {
			if (num == 1)
				throw new ArithmeticException("Lỗi tính toán số học.");
			else
				throw new FileNotFoundException("Lỗi không tìm thấy tệp.");
		}
	}
	public class Exception06 {

		public static void main(String[] args) {
			try {
				ThrowsExample obj = new ThrowsExample(); obj.myMethod(1);
			} catch (Exception ex) { 
				System.out.println(ex.getMessage());
			}
		}
}


