package bai19;


public class Main {

	public static void main(String[] args) {
		Cricle ht = new Cricle();
		ht.setColor("red");
		ht.setRadius(5);
		System.out.println(ht.toString());
		System.out.println("Đường kính hình tròn: " + ht.getDiameter()+ " cm");
		System.out.println("Chu vi hình tròn là: " + ht.getPerimeter()+ " cm");
		System.out.println("Diện tích hình tròn là: " + ht.getArea()+ " cm2");
		
		System.out.println("-------------------------------------------");
		
		Rectangle cn = new Rectangle();
		cn.setColor("blue");
		cn.setHeight(10.5);
		cn.setWidth(5.4);
		System.out.println(cn.toString());
		System.out.println("Chu vi HCN là: " + cn.getPerimeter() + " cm");
		System.out.println("Diện tích HCN là: " + cn.getArea() + " cm2");
	}
}