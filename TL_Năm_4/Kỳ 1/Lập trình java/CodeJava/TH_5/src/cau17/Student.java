package cau17;
import java.util.Scanner;

public class Student {
	String firstName, lastName;
	Address homeAddress, schoolAddress;
	
	public Student() {
		Scanner sc = new Scanner(System.in);
		System.out.print("First Name: ");
		firstName = sc.nextLine();
		System.out.print("lastName: ");
		lastName = sc.nextLine();
		
		homeAddress = new Address();
		homeAddress.homeAddress();
		
		schoolAddress = new Address();
		schoolAddress.schoolAddress();
	}
	
	@Override
	public String toString() {
		return "Họ và tên: "+ firstName + "" + lastName
				+"\nĐịa chỉ nhà riêng: "+ homeAddress
				+"\nĐịa chỉ cơ quan: "+ schoolAddress;
	}
}
