package arraylist;

public class Student { 
	private int maSV; 
	private String hoTen; 
 
	public Student(int maSV, String hoTen) { 
		super(); 
		this.maSV = maSV; 
		this.hoTen = hoTen; 
	} 
	public int getMaSV() { 
		return maSV; 
	} 
	public String getHoTen() { 
		return hoTen; 
	} 
	@Override
	public String toString() { 
		return maSV + " " + hoTen; 
	} 
}
