import java.util.Scanner;
public class Cau_9 {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		System.out.print("Nhập xâu chưa loại bỏ khoảng trắng thừa : ");
		String s = sc.nextLine();
		s.trim();
		s = s.replaceAll("\\s+"," "); // thay thế nhiều khoảng cách bằng 1 dấu cách
		System.out.print("Nhập xâu đã loại bỏ khoảng trắng thừa : "+s);
	}
}

//trim()  xóa các khoảng trắng trước và sau toàn bộ chuỗi
//s.replaceAll("\\s+","") xóa tất cả các khoảng trắng và các ký tự không nhìn thấy được (ví dụ: tab, \n).
//s.replaceAll("\\s+","") và st.replaceAll("\\s","") tạo ra kết quả tương tự.
//s.replaceAll("\\s+","-") thay thê dấu cách bằng dấu -
