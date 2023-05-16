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
    //khia bao ban
    friend Complex operator +(Complex a,Complex b);
    friend Complex operator -(Complex a,Complex b);
};
   Complex operator +(Complex a,Complex b){ 
   Complex c;
   c.pt=a.pt+b.pt;
   c.pa=a.pa+b.pa;
   return c;
}
   Complex operator -(Complex a,Complex b){ 
    Complex c;
    c.pt=a.pt-b.pt;
    c.pa=a.pa-b.pa;
    return c;
}
int main()
{
    Complex x,y;
    x.add();
    y.add();
	x.display();
	cout<<" + ";
	y.display();
	cout<<" = ";
	(x+y).display();
    cout<<"\n";
    x.display();
	cout<<" - ";
	y.display();
	cout<<" = ";
	(x-y).display();
    getch();
}
