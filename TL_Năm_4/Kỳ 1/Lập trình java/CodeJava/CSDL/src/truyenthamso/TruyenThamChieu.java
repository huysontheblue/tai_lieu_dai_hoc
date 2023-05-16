package truyenthamso;

public class TruyenThamChieu {
	int data = 50;
	void vidu(TruyenThamChieu vd) {
		vd.data = vd.data + 100;
	}
	public static void main(String[] args) {
		TruyenThamChieu vd = new TruyenThamChieu();
		System.out.println("Trước khi truyền " + vd.data);
		vd.vidu(vd);
		System.out.println("Sau khi truyền " + vd.data);
	}
}
