package cau17;
import java.util.Scanner;
public class Address {

	static  Scanner sc =  new Scanner(System.in);
	String streetAddress, city, sate;
	
	public void homeAddress() {
		System.out.println("Home Address");
		System.out.print("Street address: ");
		streetAddress = sc.nextLine();
		System.out.print("City: ");
		city = sc.nextLine();
		System.out.print("Sate: ");
		sate = sc.nextLine();
	}
	public void schoolAddress() {
		System.out.println("School Address");
		System.out.print("Street Address:");
		streetAddress = sc.nextLine();
		System.out.print("City: ");
		city = sc.nextLine();
		System.out.print("sate: ");
		sate = sc.nextLine();
	}
	@Override
	public String toString() {
		return streetAddress + "," + city + ","+ sate;
	}
}
