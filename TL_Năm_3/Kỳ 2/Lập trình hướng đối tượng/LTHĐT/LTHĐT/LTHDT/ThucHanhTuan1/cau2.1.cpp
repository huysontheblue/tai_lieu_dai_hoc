#include <bits/stdc++.h>
using namespace std;
void swap(int &giatri1, int &giatri2)
{
	int temp = giatri1;
	giatri1  = giatri2;
	giatri2  = temp;
}
int main()
{
	int a,b;
	cout<<"nhap gia tri cho a = "; cin>>a;
	cout<<"nhap gia tri cho b = "; cin>>b;
	swap(a, b);
    cout << "Sau khi goi ham swap :" << endl;
	cout << "gia tri cua a la = " << a << endl;
	cout << "gia tri cua b la = " << b << endl;
	system("pause");
	return 0;
}
