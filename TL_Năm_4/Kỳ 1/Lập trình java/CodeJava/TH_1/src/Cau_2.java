import java.util.Scanner;
 
public class Cau_2 {
    public static void main(String[] args) {
    	Scanner sc = new Scanner(System.in);
    	float a,b,c;
        System.out.print("Nhập a = ");a = sc.nextFloat();
        System.out.print("Nhập b = ");b = sc.nextFloat();
        System.out.print("Nhập c = ");c = sc.nextFloat();
        // tính delta
        float delta = b*b - 4*a*c;
        float x1;
        float x2;
        // tính nghiệm
        if (delta > 0) {
            x1 = (float) ((-b + Math.sqrt(delta)) / (2*a));
            x2 = (float) ((-b - Math.sqrt(delta)) / (2*a));
            System.out.println("Phương trình có 2 nghiệm là: "
                    + "x1 = " + x1 + " và x2 = " + x2);
        } else if (delta == 0) {
            x1 = (-b / (2 * a));
            System.out.println("Phương trình có nghiệm kép: "
                    + "x1 = x2 = " + x1);
        } else {
            System.out.println("Phương trình vô nghiệm!");
        }
    }
}