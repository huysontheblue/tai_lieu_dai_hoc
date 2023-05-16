import java.util.Scanner;
public class timGT_X {

	public static void main(String[] args) {
	    int n, temp, max = 100, k, c, d, l;
	    Scanner scanner = new Scanner(System.in);    
	    // khai báo và cấp phát bộ nhớ cho mảng A
	    int array[] = new int[max];    
	    // nhập số phần tử của mảng
	    // kiểm tra nếu n <= 0 hoặc n > max - 1
	    // thì phải nhập lại
	    do {
	        System.out.println("Nhập số phần tử của mảng: ");
	        n = scanner.nextInt();
	    } while (n <= 0 || n > max-1);
	         
	    System.out.println("Nhập giá trị cho các phần tử của mảng: ");
	    for (int i = 0; i < n; i++) {
	        System.out.print("array[" + i + "] = ");
	        array[i] = scanner.nextInt();
	    }    
	    // sắp xếp tăng dần các phần tử bằng phương pháp Exchange sort
	    // vòng lặp for sẽ duyệt i và j
	    // i chạy từ 0 đến n - 1, j chay từ i + 1 đến n - 1
	    // nếu phần tử tại chỉ số j nhỏ hơn phần tử tại i
	    // thì sẽ hoán đổi vị trí 2 phần tử này cho nhau
	    for (int i = 0; i < n - 1; i++) {
	        for (int j = i+1; j <= n - 1; j++) {
	            if (array[j] < array[i]) {
	                temp = array[i];
	                array[i] = array[j];
	                array[j] = temp;
	            }
	        }
	    }     
	    // tìm kiếm phần tử trong mảng
	    System.out.println("Nhập số nguyên cần tìm: ");
	    k = scanner.nextInt();
	         
	    d = 0;
	    c = n - 1;
	     
	    // duyệt vòng lặp while
	    // nếu d còn nhỏ hơn hoặc bằng c thì còn tiếp tục thực hiện thân vòng lặp
	    while (d <= c) {
	        l = (d + c) / 2;
	             
	        // nếu phần tử tại vị trí j bằng số nguyên k cần tìm
	        // thì thông báo tìm thấy số k tại vị trí j
	        // và kết thúc vòng lặp
	        if (array[l] == k) {
	            System.out.println("Tìm thấy phần tử " + k + " tại vị trí " + l);
	            return; // kết thúc vòng lặp while và bỏ qua các lệnh bên dưới
	        } else if (array[l] < k) {
	            // nếu phần tử tại l nhỏ hơn số nguyên k
	            // thì tăng d = l + 1
	            // và quay lại thực hiện vòng lặp while
	            d = l + 1;
	        } else {
	            // nếu phần tử tại l lớn hơn số nguyên k
	            // thì giảm c = l - 1
	            // và quay lại thực hiện vòng lặp while
	            c = l - 1;
	        }
	    }
	         
	    // nếu sau khi thực hiện vòng lặp while
	    // mà không tìm thấy số cần tìm
	    // thì hiển thị thông báo không tìm thấy
	    System.out.println("Không tồn tại trong mảng.");
	}
}