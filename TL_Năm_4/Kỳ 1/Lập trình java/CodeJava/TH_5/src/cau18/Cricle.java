package cau18;

public class Cricle {
	double radius;
	int x, y;
	
	public Cricle(int x, int y, double radius) {
		this.x= x;
		this.y = y;
		this.radius = radius;
	}
	public void setRadius(double radius) {
		this.radius = radius;
	}
	public void getRadius(double radius) {

	}
	public double getDiameter() {
		return radius+ radius;
	}
	public double getCircumference() {
		return 2*3.14*radius;
	}
	public double getArea() {
		return radius * radius * 3.14;
	}
}
