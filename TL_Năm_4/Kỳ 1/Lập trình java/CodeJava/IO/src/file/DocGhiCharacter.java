package file;

import java.io.BufferedReader; 
import java.io.File; 
import java.io.FileInputStream; 
import java.io.IOException; 
import java.io.InputStreamReader; 
import java.util.ArrayList; 
import java.util.Arrays; 
	public class DocGhiCharacter { 
		public static void main(String[] args) throws IOException { 
			String fileName = "D:\\TL_Nam_4\\Ky_1\\Lập trình java\\songuyen.txt"; 
			File file = new File(fileName); 
			FileInputStream fin = new FileInputStream(file); 
			InputStreamReader sRead = new InputStreamReader(fin); 
			BufferedReader bRead = new BufferedReader(sRead); 
			ArrayList<String> arrayList = new ArrayList<>(); 
			String line; 
			do { 
				// Đọc từng dòng văn bản từ tệp vào biến line
				line = bRead.readLine(); 
 
				if (line != null) { 
					// Đưa về xâu chuẩn
					// Các ký tự trong xâu cách nhau bởi 1 dấu cách
					line = line.trim().replaceAll("\\s+", " "); 
 
					// Tách xâu thành mảng
					// Bổ sung vào arrayList
					arrayList.addAll(Arrays.asList(line.split(" "))); 
				} 
			} while (line != null); 
 
			System.out.println(arrayList); 
			fin.close(); 
			sRead.close(); 
			bRead.close(); 
		} 
	}
