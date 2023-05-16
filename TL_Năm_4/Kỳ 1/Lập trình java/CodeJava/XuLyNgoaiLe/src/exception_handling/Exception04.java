/* Sử dụng nhiều catch
 Thay đổi giá trị của b, s để so sánh kết quả */
package exception_handling;

	public class Exception04 {
		public static void main(String[] args) {
			int a = 10, b = 0, x; String s = "123a"; try {
				x = a / b;
				System.out.println("Kết quả x = " + x);

				int number = Integer.parseInt(s); 
				System.out.println("Kết quả number = " + number);
			} catch (ArithmeticException e1) { 
				System.out.println("Lỗi: " + e1.getMessage());
			} catch (NumberFormatException e2) { 
				System.out.println("Lỗi: " + e2.getMessage());
			} finally {
				System.out.println("Kết thúc chương trình.");
			}
		}
}

