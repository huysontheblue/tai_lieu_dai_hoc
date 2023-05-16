package bai19;

public class Cricle extends GeometicObject{
	double radius;
	
	public Cricle() {
		super();
	}
	public Cricle(double radius) {
		super();
		this.radius=radius;
	}
	public double getRadius() {
		return radius;
	}
	public void setRadius(double radius) {
		this.radius =  radius;
	}
	public double getDiameter() {
		return radius*2;
	}
	@Override
	double getArea() {
		return Math.PI*radius*radius;
	}
	@Override
	double getPerimeter() {
		return 2* Math.PI*radius;
	}
}