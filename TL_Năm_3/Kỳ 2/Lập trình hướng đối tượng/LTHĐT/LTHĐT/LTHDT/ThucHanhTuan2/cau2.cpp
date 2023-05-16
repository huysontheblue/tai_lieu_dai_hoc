#include <bits/stdc++.h>
using namespace std;
typedef struct{
    float thuc,ao;
} sophuc;

// nhap toan tu
ostream &operator<<(ostream &out, sophuc &a) {
    if (a.ao == 0)
        out<<a.thuc;
    else
        out << a.thuc << ((a.ao > 0)?"+":"")<<a.ao<<"i";
    return out;
}
// xuat toan tu
istream &operator>>(istream &in,sophuc &a) {
    cout<<"\nPhan thuc = ";
    in>>a.thuc;
    cout<<"\nPhan ao = ";
    in>>a.ao;
    return in;
} ;
//tru
sophuc operator -(sophuc a, sophuc b) {
    sophuc res;
    res.thuc = a.thuc-b.thuc;
    res.ao = a.ao-b.ao;
    return res;
}
//cong
sophuc operator + (sophuc a, sophuc b) {
    sophuc res;
    res.thuc = a.thuc+b.thuc;
    res.ao = a.ao+b.ao;
    return res;
}
//-nhan
//sophuc operator *(sothuc a, sothuc b) {
    //sothuc res;
    //res.thuc = a.thuc*b.thuc - a.ao*b.ao;
    //res.ao = a.thuc*b.ao + a.ao*b.thuc;
    //return res;
//}
//dao dau
//sophuc lienhop(sophuc a){
    //comp res;
    //res.thuc = - a.thuc;
    //res.ao = -a.ao;
    //return res;
//}
//chia
//sophuc operator /(sophuc a, sophuc b) {
    //sophuc res = a*lienhop(b);
    //float module = b.thuc*b.thuc + b.ao*b.ao;
    //res.thuc /= module;
    //res.ao /= module;
    //return res;
//}
///-----------------------------
bool operator ==(sophuc a, sophuc b)
{
    return (a.thuc==b.thuc && a.ao==b.ao);
}
//----------------------------------
bool operator !=(sophuc a, sophuc b)
{
    return !(a.thuc==b.thuc && a.ao==b.ao);
}

//----------------------------------
int main(){
    sophuc a,b,c;
    cout << "Nhap so phuc thu nhat: "; cin >> a;
    cout << "\nNhap so phuc thu hai: "; cin >> b;
    cout << " \nSo thu nhat: "; cout<<a;
    cout << " \nSo thu hai: "; cout<<b;
    cout << " \nKet qua cac phep toan: \n";
    cout << " \nPhep cong: ";
    c = a+b; cout<<c<<endl;
    cout << " \nPhep tru: ";
    c = a-b; cout<<c<<endl;
    //cout << " \nPhep nhan: ";
    //c = a*b;
    //cout<<c<<endl;
    //cout << " \nPhep chia: ";
    //c = a/b;
    //cout<<c<<endl;
    cout<<"\n";
    if(a==b)
		{   
			cout<< "2 so phuc bang nhau:";cout<<a;cout<< " == ";cout<<b;
    		cout<<"\n\n";
    	}
	else if (a!=b)
		{
			cout<< "2 so phuc khac nhau:";cout<<a;cout<< " != "; cout<<b;
			cout<<"\n\n";
		}
	return 0;
}
