package file;

import java.io.EOFException; 
import java.io.FileInputStream; 
import java.io.FileOutputStream; 
import java.io.ObjectInputStream; 
import java.io.ObjectOutputStream; 
import java.io.Serializable; 
	class Student implements Serializable { 
		private static final long serialVersionUID = 1L; 
		String name; 
		int age; 
		@Override
		public String toString() { 
			return "SinhVien [hoTen=" + name + ", tuoi=" + age + "]"; 
		} 
	} 
	public class DocGhiObject { 
		public static void main(String[] args) throws Exception { 
			final int N = 5; 
			Student student; 
			FileOutputStream fout = new FileOutputStream("D:\\TL_Nam_4\\Ky_1\\Lập trình java\\sinhvien.dat"); 
			ObjectOutputStream obj = new ObjectOutputStream(fout); 
			for (int i = 0; i < N; i++) { 
				student = new Student(); 
				student.name = "Nguyen Van " + (i + 1); 
				student.age = 20; 
				obj.writeObject(student); 
			} 
			fout.close(); 
			obj.close(); 
			FileInputStream fin = new FileInputStream("D:\\\\TL_Nam_4\\\\Ky_1\\\\Lập trình java\\\\sinhvien.dat"); 
			ObjectInputStream oin = new ObjectInputStream(fin); 
			try { 
				while ((student = (Student) oin.readObject()) != null) { 
					System.out.println(student); 
				} 
			} catch (EOFException e) { 
				System.out.println("End of file."); 
				} 
			fin.close(); 
			oin.close(); 
		} 
	}
