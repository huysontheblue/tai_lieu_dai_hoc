#include<stdlib.h>
#include<iostream>
#include<conio.h>
using namespace std;
class Complex{
    private:
     float pt,pa;
    public:
    	// ham thiet lap
    Complex(){
     pt=0; pa=0;
}
    // ham nhap
    void add(){
     cout<<"\nMoi nhap phan thuc: ";cin>>pt;
     cout<<"Moi nhap phan ao: ";cin>>pa;
}
    // ham in
    void display(){
     if (pa<0) cout<<pt<<pa<<"*i";
     else cout<<pt<<"+"<<pa<<"*i";
}
    // toan tu cong
    Complex operator +(Complex a,Complex b){ 
      Complex c;
      c.pt=a.pt+b.pt;
      c.pa=a.pa+b.pa;
      return c;
}
// gan 2 so phuc
     //Complex operator =(Complex a,Complex b)
	//{
	//	a.pt=b.pt;
	//	a.pa=b.pa;
//	}
};
int main(){
	Complex *cp = newComplex[100];
	int n;
	cout<<"Cac so phuc duoc nhap la: ";cin>>n;
	for(int i=0; i<n; i++){
		cout<<"\nNhap vao so phuc thu "<<i+1<<": ";
		cp[i].add();
		cout<<"So phuc thu "<<i+1<<":   ";
		cp[i].display();
	}
	cout<<"\nMang so phuc vua nhap la: \n";
	for(int i=0; i<n; i++){
		cp[i].display();
		cout<<"\t";
	}
	Complex tong = cp[0];
	for(int i=1; i<n; i++){
		tong = tong + cp[i];
	}
	cout<<"\nTong cua cac so phuc la: ";
	tong.display();
    delete [] cp;
}	
