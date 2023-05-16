import java.util.Scanner;
public class KiemTraTonTai {

	public static void main(String[] args) {
		int counter, num, item, array[];
        Scanner input = new Scanner(System.in);
        System.out.println("Nhập vào số lương phần tử của mảng:");
        num = input.nextInt();
        array = new int[num];
        System.out.println("Nhập giá trị cho các phần tử trong mảng:");
        for (counter = 0; counter < num; counter++)
            array[counter] = input.nextInt();
        System.out.println("Nhập vào giá trị cần kiểm tra trong mảng");
        item = input.nextInt();
        for (counter = 0; counter < num; counter++)
        {
            if (array[counter] == item)
            {
                System.out.println(item+" Đang tồn tại ở vị trí "+(counter+1));
                break;
            }
        }
        if (counter == num)
            System.out.println(item + " Không tồn tại trong mảng.");
    }
}
