import java.util.Scanner;

public class Cau_12 {
	static int n,m,mt[][];
    public static void nhapmt(){
        Scanner input = new Scanner(System.in);
        System.out.print("Nhập số hàng: ");
        n=input.nextInt();
        System.out.print("Nhập số cột: ");
        m=input.nextInt();
        mt=new int[n][m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                System.out.print("  a["+i+","+j+"]=");
                mt[i][j]=input.nextInt();
            }
            System.out.println();
        }
    }
    public static void xuatmt(){
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
            System.out.print(mt[i][j] +"  ");
        }
        System.out.println("");
        }
    }
    public static int minmt(){
        int min=mt[0][0];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (mt[i][j]<min) {
                    min=mt[i][j];
                }
            }
        }
        return min;
    }
    public static int tongdong(int row){
        int tong=0;
        for (int i = 0; i < m; i++) {
            tong+=mt[row][i];
        }
        return tong;
    }  
    public static void main(String[] args) {
        int max = tongdong(0),chiso=0;
        nhapmt();
        xuatmt();
        System.out.println("phan tu nho nhat "+minmt());
        for (int i = 0; i < n; i++) {
            if (max<tongdong(i)) {
            max=tongdong(i);
            chiso=i;
            }
        }
        System.out.println("dong co tong lon nhat la dong "+chiso+" co gia tri:"+max);
    }
}


