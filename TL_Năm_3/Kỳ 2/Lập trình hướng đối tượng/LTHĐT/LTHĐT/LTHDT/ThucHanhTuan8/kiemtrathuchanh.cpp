#include <iostream>
#include <string>
#include <iomanip>
using namespace std;
class Printer
{
    private:
        int sohieu;
        int soluong;
    public:
    	// ham thiet lap
        Printer(int sohieu = 0, int soluong = 0)
        {
            this->sohieu = sohieu;
            this->soluong = soluong; 
        }
        // ham nhap kho
        void Nhapkho(int q)
        {
            soluong+=q;
        }
        // ham xuat kho
        void Xuatkho(int q)
        {
            soluong -= q;
        }
        // ham hien thi
        void disp()
        {
            cout << "So hieu: " << sohieu <<endl;
			cout << "So Luong: " << soluong << endl;
        }
};
class Laser:public Printer
{
    private:
        int dpi;
    public:
    	// ham thiet lap
        Laser(int sohieu = 0,int soluong = 0,int dophangiai =0 ):Printer(sohieu,soluong)
        {
            dpi = dophangiai;
        }
        // ham hien thi du lieu
        void disp()
        {
            Printer::disp();
            cout <<"Do Phan Giai: " << dpi;
        }
};
class ColorLaser:public Laser
{
    private:
        int color;
    public:
    	// ham thiet lap
        ColorLaser(int sohieu = 0,int soluong = 0, int dophangiai = 0,int c = 0):Laser(sohieu,soluong,dophangiai)
        {
            color = c;
        }
        // ham hien thi
        void disp()
        {
            Laser::disp();
            cout <<"\nMau: " << color << endl;
        }
};
int main()
{
    ColorLaser *list[3];
    for (int i =0 ; i < 3; i++)
    {
        //nhap du lieu
        cout << "Doi tuong thu: " << i + 1 << endl;
        int sohieu,soluong,dophangiai,color;
        cout <<"\nNhap so hieu :"; cin >> sohieu;
		cout <<"\nSo luong :";cin>>soluong;
		cout <<"\nDo phan giai :";cin>>dophangiai;
		cout <<"\nMau: ";cin>>color;
        list[i] = new ColorLaser(sohieu,soluong,dophangiai,color);
    }
    // xem du lieu 
    system("CLS");
    for (int i =0 ; i < 3; i++)
    {
        list[i]->disp();
    }
    //goi ham nhap kho va xuat kho cho tung doi tuong
    for (int i =0 ; i < 3; i++)
    {
        cout <<"\nDoi tuong thu:" << i + 1 << endl;
        int Nhapkho,Xuatkho;
        cout <<"\nNhap so luong nhap kho: "; cin >> Nhapkho;
        cout <<"Nhap so luong xuat kho: "; cin >> Xuatkho;
        list[i]->Nhapkho(Nhapkho);
        list[i]->Xuatkho(Xuatkho);
    }
    for (int i = 0; i < 3; i++)
    {
        cout << "Doi tuong thu: " << i + 1 << endl;
        int sohieu,soluong,dophangiai,color;
        list[i]->disp();
    }
    system("pause");
}
