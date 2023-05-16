#include <iostream>
#include <math.h>
using namespace std;
class Ptb1
{
private:
    float b, c;
public:
    Ptb1(float m=0, float n=0);
    void Nhap(float x, float y);
    void Xuat();
    void Giai_B1();
};
//======== Ham khoi tao phuong trinh bac 1 ========//
Ptb1::Ptb1(float m, float n)
{
    b = m;
    c = n;
}
//============= Ham nhap b, c ==============//
void Ptb1::Nhap(float x, float y)
{
    b = x;
    c = y;
}
//============= Ham xuat b, c ==============//
void Ptb1::Xuat()
{
    cout << "(" << b << ")x + (" << c << ") = 0" << endl;
}
//============= Ham Giai phuong trinh bac 1 ============//
void Ptb1::Giai_B1()
{
    if (b !=0)
        cout << "\n\nPhuong trinh co nhiem: x= " << (-c) / b << endl;
    else if (c == 0)
        cout << "\n\nPhuong trinh vo nghiem" << endl;
    else
        cout << "\n\nPhuong trinh co vo so nghiem" << endl;
}
int main()
{
    Ptb1 x;
    float b, c;
    cout << "Nhap gia tri b: ";cin >> b;
    cout << "\nNhap gia tri c: ";cin >> c;
    x.Nhap(b, c);
    cout << "Phuong trinh co dang: ";
    x.Xuat();
    x.Giai_B1();
    return 0;
}
