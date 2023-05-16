import java.util.Scanner;
public class Cau_11 {
		static void inMang(int[] a,int n)  {
			for(int i = 0; i < n; i++) {
				System.out.print(a[i] + " ");
			}
		}
		public static void main(String[] args) {
		int n;
		Scanner sc = new Scanner(System.in);
		// nhập mảng
		System.out.print("Nhập số phần tử mảng n : ");
		n = sc.nextInt();
		int[] a = new int[n];
		for(int i = 0; i < n; i++) {
			System.out.print("a[" + i + "] : ");
			a[i] = sc.nextInt();
		}
		// hiển thị mảng đã nhập 
		System.out.print("Mảng ban đầu :");
		inMang(a, n);
		// đếm số phần tử chẵn
		System.out.println();
		int demchan = 0;
		for(int i = 0; i < n;i++) {
			if(a[i]%2==0) {
				demchan++;
			}
		}
		System.out.println("Số phần tử là số chẵn là :"+ demchan);
		// sắp xếp mảng tăng dần 
		int temp = a[0];
		for (int i = 0; i < a.length - 1; i++) {
	        for (int j = i + 1; j < a.length ; j++) {
	            if (a[i] > a[j]) {
	                temp = a[i];
	                a[i] = a[j];
	                a[j] = temp;
	            }
	        }
	    }
	    System.out.print("Mảng sau khi sắp xếp tăng là: ");
	    inMang(a, n);
	    System.out.println();
	    
	   /*tìm phần tử có giá trị X*/
	    int k,d,c,l;
	    System.out.print("Nhập số cần tìm: ");
	    k = sc.nextInt();     
	    d = 0;
	    c = n - 1;
	    while (d <= c) {
	        l = (d + c) / 2;
	        if (a[l] == k) {
	            System.out.println("Tìm thấy phần tử " + k + " tại vị trí " + l);
	            return;
	        } else if (a[l] < k) {
	            d = l + 1;
	        } else {
	            c = l - 1;
	        }
	    }
	    System.out.println("Không tồn tại trong mảng.");

	}

}
