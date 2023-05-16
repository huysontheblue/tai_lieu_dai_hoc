#include <iostream>
using namespace std;
class hcn {
private:
	double cd;
    double cr;
public:
    void nhap() {
        cout<<"Nhap chieu dai : " <<endl; cin >> cd;
        cout<<"Nhap chieu rong : " <<endl; cin >> cr;
    }
    double dientich() {
        return cd * cr;
    }
    double chuvi() {
        return (cd + cr) * 2;
    }
    void display() {
        cout << "Dien tich: " << dientich() << endl;
        cout << "Chu vi: " << chuvi() << endl;
    }
};
int main() 
{
	hcn cn1;
    cn1.nhap();
    cn1.display();
    return 0;
}
