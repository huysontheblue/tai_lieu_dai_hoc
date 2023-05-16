// Custom exception
package exception_handling;

	class InvalidAgeException extends Exception {
		private int age;

		InvalidAgeException(int a) { age = a;
		}

		public String toString() {
			return "Tuổi " + age + " là không hợp lệ.";
		}	
	}

	public class Exception08 {

		static void checkAge(int age) throws InvalidAgeException {
			if (age < 0 || age > 100)
				throw new InvalidAgeException(age); 
			System.out.println("Tuổi " + age + " là hợp lệ.");
		}

		public static void main(String[] args) {
			try {
				checkAge(25); checkAge(-5);
			} catch (InvalidAgeException e) { 
				System.out.println(e.toString());
			} finally {
				System.out.println("Kết thúc chương trình.");
			}
		}
}
