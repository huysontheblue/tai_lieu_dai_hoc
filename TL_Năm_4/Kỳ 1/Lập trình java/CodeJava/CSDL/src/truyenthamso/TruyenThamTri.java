package truyenthamso;

public class TruyenThamTri {
	public static void doiCho(int a, int b) {
		int c = a;
		a = b;
		b = c;
		System.out.println("Sau khi doi cho gia tri thi a = " + a + ", b = " + b);
	}
	public static void main(String[] args) {
		int a = 5, b = 10;
		System.out.println("Truoc khi truyen tham so, a = " + a + ", b = " + b);
		doiCho(a, b);
		System.out.println("Sau khi truyen tham so, a = " + a + ", b = " + b);
	}
} 
