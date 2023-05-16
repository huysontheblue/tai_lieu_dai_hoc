
//public class Cau_3 {
	//public static void main(String[] args) {
		//int tongchan = 0;
        //for (int i = 0; i < 10; i++) {
            //tongchan +=i*2;
        //}
        //System.out.print("Tổng 10 số chẵn đầu tiên là:" + tongchan);
	//}
//}

import java.util.Scanner;
public class Cau_3 {
public static void main(String[] args) {
	Scanner sc = new Scanner(System.in);
	System.out.print("Nhập n = ");
	int n = sc.nextInt();
	int tong=0;
	for(int i = 0; i < n; i++) {
		if(i%2==0 && i<20) {
			tong +=i;
		}
	}
	System.out.print("Tổng 10 số chẵn đầu tiên là:"+ tong);
	}
}
