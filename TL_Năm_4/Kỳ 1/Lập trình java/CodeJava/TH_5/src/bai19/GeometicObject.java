package bai19;

import java.util.Scanner;

abstract public class GeometicObject {
	String color;
	protected GeometicObject() {
		super();
	}
	public String getColor() {
		return color;
	}
	public void setColor(String color) {
		this.color=color;
	}
	@Override
	public String toString() {
		return "Màu là : "+ color;
	}
	abstract double getArea();
	abstract double getPerimeter();
} 
