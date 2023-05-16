package BT1;

import java.util.Scanner;
	class Person{
		protected String name;
		protected String sex;
		protected String adrress;
		protected String ngaysinh;
		public String getName() {
			return name;
		}
		public void setName(String name) {
			this.name = name;
		}
		public String getSex() {
			return sex;
		}
		public void setSex(String sex) {
			this.sex = sex;
		}
		public String getAdrress() {
			return adrress;
		}
		public void setAdrress(String adrress) {
			this.adrress = adrress;
		}
		public String getNgaysinh() {
			return ngaysinh;
		}
		public void setNgaysinh(String ngaysinh) {
			this.ngaysinh = ngaysinh;
		}
		public Person(){
		}
		public Person(String name,String sex,String adrress,String ngaysinh){
			this.name = name;
			this.sex = sex;
			this.adrress = adrress;
			this.ngaysinh = ngaysinh;
		}
		public void intputPerson(){
			Scanner sc = new Scanner(System.in);
			System.out.print("Nhập tên :"); this.name = sc.nextLine();
			System.out.print("Nhập giới tính :");this.sex = sc.nextLine();
			System.out.print("Nhập địa chỉ :");this.adrress = sc.nextLine();
			System.out.print("Nhập ngày sinh :");this.ngaysinh = sc.nextLine();
		}
		public void showPerson(){
			System.out.println("Họ tên : " + this.name + "\nGiới tính : " + this.sex + "\nĐịa chỉ : " +this.adrress +"\nNgày sinh : " +this.ngaysinh);
		}
	}
	public class BT1 {
		public static void main(String []args){
			Person person = new Person();
			person.intputPerson();
			person.showPerson();
		}
}
