import java.util.Scanner;
import javax.swing.JOptionPane;
public class Cau_15 {
    private int ma,mb,mc;
    //Constructor
    public Cau_15(){
        ma=mb=mc=0;
    }
    public Cau_15(int a,int b,int c){
        if(a<0){
            JOptionPane.showMessageDialog(null,"cạnh phải >0",
                    "Thông báo",JOptionPane.WARNING_MESSAGE);
            ma=0;
            return;
        }
        if(b<0){
            JOptionPane.showMessageDialog(null,"cạnh phải >0",
                    "Thông báo",JOptionPane.WARNING_MESSAGE);
            mb=0;
            return;
        }
        if(c<0){
            JOptionPane.showMessageDialog(null,"cạnh phải >0",
                    "Thông báo",JOptionPane.ERROR_MESSAGE);
            mc=0;
            return;
        }
        if(a+b<=c||a+c<=b||b+c<=a) {
            JOptionPane.showMessageDialog(null,"Không phải là tam giác",
                    "Thông báo",JOptionPane.ERROR_MESSAGE);
            ma=mb=mc=0;
            return;
        }
        ma=a;
        mb=b;
        mc=c;
    }
    //Get methods
    public int getCanhA(){
        return ma;
    }
    public int getCanhB(){
        return mb;
    }
    public int getCanhC(){
        return mc;
    }
    //set methods
    public void setCanhA(int a){
        ma=a;
    }
    public void setCanhB(int b){
        mb=b;
    }
    public void setCanhC(int c){
        mc=c;
    }
    public boolean laTamGiac(){
        return(ma+mb>mc&&ma+mc>mb&&mb+mc>ma);
    }
    public boolean laTamGiac(int a,int b,int c){
        return(a+b>c&&a+c>b&&b+c>a);
    }
    public int getChuvi(){
        return ma+mb+mc;
    }
    public double getDienTich(){
            double p=(double)(ma+mb+mc)/2;
            return Math.sqrt(p*(p-ma)*(p-mb)*(p-mc));                   
    }
    public static void main(String[] args) {
        System.out.println("nhap ba canh hinh tam giac");
        Scanner sc = new Scanner(System.in);
        System.out.print("Cạnh a : ");int ma = sc.nextInt();
        System.out.print("Cạnh b : ");int mb = sc.nextInt();
        System.out.print("Cạnh c : ");int mc = sc.nextInt();
        Cau_15 tamgiac=new Cau_15(ma,mb,mc);
        if(tamgiac.laTamGiac()){
            System.out.println("Chu vi: "+tamgiac.getChuvi());
            System.out.println("Dien tich: "+tamgiac.getDienTich());
        }         
    }   
}