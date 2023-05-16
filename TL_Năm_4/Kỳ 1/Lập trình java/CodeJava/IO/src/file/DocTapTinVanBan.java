package file;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

public class DocTapTinVanBan {
	public static void main(String[] args) { 
		 
		 File fileName = new File("D:\\TL_Nam_4\\Ky_1\\Lập trình java\\danhsach.txt"); 
		 
		 try { 
			 FileReader fIn = new FileReader(fileName); 
			 BufferedReader reader = new BufferedReader(fIn); 
		 
			 String st; 
			 String[] chuoi_chia; 
			 while ((st = reader.readLine()) != null) { 
				 chuoi_chia = st.split(", "); 
				 System.out.println("Họ và tên: " + chuoi_chia[0]); 
				 System.out.println("Địa chỉ: " + chuoi_chia[1]); 
				 System.out.println("Năm sinh: " + chuoi_chia[2]); 
			 } 
			 reader.close(); 
		 } catch (IOException e) { 
			 System.out.println("Tập tin không tồn tại."); 
		 	} 
		 } 
	}
