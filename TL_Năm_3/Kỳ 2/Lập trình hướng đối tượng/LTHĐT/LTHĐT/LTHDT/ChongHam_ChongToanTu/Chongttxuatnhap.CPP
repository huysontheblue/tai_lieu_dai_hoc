#include <conio.h>
#include <iostream>
using namespace std;
typedef struct
 {int ts,ms;}ps;

ostream &operator <<(ostream &out,ps &a){
	out<<a.ts<<"/"<<a.ms;
	return out;
	}
//------
istream &operator >>(istream &in,ps &a){
	cout<<"\nnhap tu so: ";
	in>>a.ts;
	do{
	  cout<<"\nnhap mau so :";in>>a.ms;
	  }while(a.ms==0);
	if(a.ms<0){a.ts=-a.ts;a.ms=-a.ms;}
	return in;
	}

int main()
{
	ps x;
	cout<<"Moi nhap x = ";cin>>x;
	cout<<"\nPhan so vua nhap la: "<<x;	
	getch();
	return 0;
}

