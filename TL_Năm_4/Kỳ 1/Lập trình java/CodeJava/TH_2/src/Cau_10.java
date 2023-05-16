import java.util.Scanner;
import java.util.StringTokenizer;
public class Cau_10 {

	public static void main(String[] args) {
		try {
			   Scanner s = new Scanner(System.in);
			   System.out.print("\nNhap so dien thoai theo dang (091) 022-6758080 : ");
			   String phone = s.nextLine();
			   StringTokenizer st = new StringTokenizer(phone,"() -", false);
			   while (st.hasMoreElements()) {
			    System.out.println("----------------------");
			    System.out.println("Ma quoc gia: " + st.nextToken());
			    System.out.println("Ma vung: " + st.nextToken());
			    System.out.println("So dien thoai: " + st.nextToken());
			    System.out.println("----------------------");
			   }
			  } catch (Exception e) {
			   System.out.println(e.getMessage());
		}
	}

}
