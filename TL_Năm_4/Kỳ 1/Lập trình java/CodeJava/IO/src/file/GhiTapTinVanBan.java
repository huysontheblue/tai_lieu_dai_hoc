package file;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class GhiTapTinVanBan {
	public static void main(String[] args) { 
		 File fileName = new File("D:\\TL_Nam_4\\Ky_1\\Lập trình java\\danhsach.txt"); 
		 FileWriter fOut; 
		 try { 
			 if (fileName.exists()) { 
				 // Nếu file đã tồn tại thì cho phép bổ sung
				 fOut = new FileWriter(fileName, true); 
		 } else { 
			 // Nếu file chưa tồn tại thì tạo mới
			 fOut = new FileWriter(fileName); 
		 } 
		 fOut.write("Trần Trung Kiên, Hà Tĩnh, 2000\n"); 
		 fOut.write("Trương Huy Mạnh, Quảng Bình, 2000\n"); 
		 fOut.write("Chu Văn Hưng, Hà Tĩnh, 1993\n"); 
		 fOut.write("Nguyễn Văn Thìn, Nghệ An, 2000\n"); 
		 fOut.write("Trần Thùy Xuân, Hà Tĩnh, 2000\n"); 
		 fOut.write("Phạm Văn Lương, Hà Tĩnh, 2000\n"); 
		 
		 System.out.println("Done!"); 
		 fOut.close(); 
		 
		 } catch (IOException e) { 
			 System.out.println("Có lỗi xẩy ra."); 
		 }
	}
}
