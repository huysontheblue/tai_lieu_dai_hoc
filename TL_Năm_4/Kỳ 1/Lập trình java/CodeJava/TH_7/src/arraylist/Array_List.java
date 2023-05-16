package arraylist;
import java.util.ArrayList;
public class Array_List {

	public static void main(String[] args) {
		
		ArrayList<Student> listStudent = new ArrayList<Student>(); 
		 listStudent.add(new Student(1, "Trần Trung Kiên")); 
		 listStudent.add(new Student(2, "Trương Huy Mạnh")); 
		 listStudent.add(new Student(3, "Nguyễn Văn Thìn")); 
		 listStudent.add(new Student(4, "Phạm Văn Lương")); 
		 listStudent.add(new Student(5, "Moong Văn Mưu")); 
		 listStudent.add(new Student(6, "Trần Thùy Xuân")); 
		 
		 System.out.println("Danh sách ban đầu"); 
		 for (Student student : listStudent) { 
			 System.out.println(student); 
		 } 
		 
		 System.out.println("Kích thước là: " + listStudent.size()); 
		 
		 // Tìm sinh viên
		 Student sv = null; 
		 	for (Student student : listStudent) { 
		 		if (student.getHoTen().trim().equals("Trần Thùy Xuân")) { 
		 			sv = student; 
		 			break; 
		 		} 
		 } 
		 if (sv != null) 
			 listStudent.remove(sv); 
		 
		 System.out.println("Danh sách sau khi xóa"); 
		 	for (Student student : listStudent) { 
		 		System.out.println(student); 
		 } 
	}
}
