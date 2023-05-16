// Custom exceptiom
package exception_handling;

	class MyException extends Exception {

		public MyException(String s) {
			super(s);
		}
}

	public class Exception07 {
		static void validate(int age) throws MyException{
			if (age < 18)
				throw new MyException("Tuổi không hợp lệ!");
			else
				System.out.println("Bạn đủ tuổi để tham gia");
		}
		public static void main(String[] args) {
			try {
				validate(13);
			} catch (Exception e){
				System.out.println("Lỗi: " + e.getMessage());
			}
		}
}
