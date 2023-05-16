package bai19;

public class Rectangle extends GeometicObject {
	double width, height;
	
	public Rectangle(){
		super();
	}
	public Rectangle(double width, double height) {
		super();
		this.width=width;
		this.height=height;	
	}
	public double getWidth() {
		return width;
	}
	public void setWidth(double width) {
		this.width=width;
	}
	public double getHeight() {
		return height;
	}
	public void setHeight(double height) {
		this.height=height;
	}
	@Override
	double getArea() {
		return width*height;
	}
	@Override
	double getPerimeter() {
		return (width+height)*2;
	}
}
