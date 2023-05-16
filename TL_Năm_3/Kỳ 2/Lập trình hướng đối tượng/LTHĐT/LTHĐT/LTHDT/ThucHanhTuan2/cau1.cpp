#include <conio.h>
#include <iostream>
using namespace std;
typedef struct
 {int ts,ms;}ps;
// nhap toan tu
ostream &operator <<(ostream &out,ps &a){
	out<<a.ts<<"/"<<a.ms;
	return out;
	}
//-----------------------------------
// xuat toan tu
istream &operator >>(istream &in,ps &a){
	cout<<"\nNhap tu so: ";
	in>>a.ts;
	do{
	  cout<<"\nNhap mau so :";in>>a.ms;
	  }while(a.ms==0);
	if(a.ms<0){a.ts=-a.ts;a.ms=-a.ms;}
	return in;
	}
//--------------------------------------
ps taophanso(int t, int m)   //thay bang dinh nghia chong tt >>
 {ps c;
  c.ts=t;
  c.ms=m;
  return c;
 }
//cong phan so
ps operator +(ps a, ps b) 
 {ps c;
  c.ts  =  a.ts*b.ms + a.ms*b.ts;
  c.ms =  a.ms*b.ms;
  return c;
 }

//--tru phan so
ps operator - (ps a, ps b) 
 {ps c;
  c.ts  =  a.ts*b.ms - a.ms*b.ts;
  c.ms =  a.ms*b.ms;
  return c;
 }
//--dao dau phan so
 ps operator - (ps a)
 {a.ts=-a.ts;
  return a;
 }
//--nhan phan so
ps operator * (ps a, ps b)
{ps c;
    c.ts = a.ts*b.ts;
    c.ms = a.ms*b.ms;
    return c;
}
//--chia phan so
ps operator / (ps a, ps b)
{ps c;
    c.ts = a.ts*b.ms;
    c.ms = a.ms*b.ts;
    return c;
}
// ++ cho 2 phân so
ps operator ++ (ps a)
{
    a.ts += a.ms;
    return a;
}
// -- cho 2 phân so
ps operator -- (ps a)
{
    a.ts -= a.ms;
    return a;
}
//dau ==
bool operator == (ps a, ps b)  //a
{
    return (float) a.ts/a.ms == (float) b.ts/b.ms;
}
//dau !=
bool operator != (ps a, ps b)  //b
{
    return (float) a.ts/a.ms != (float) b.ts/b.ms;
}
//------dau >
bool operator > (ps a, ps b)   //c
{
    return (float) a.ts/a.ms > (float) b.ts/b.ms;
}
//dau >=
bool operator >= ( ps a, ps b)  //d
{
    return (float) a.ts/a.ms >= (float) b.ts/b.ms;
}
//dau <
bool operator < (ps a, ps b)   //e
{
    return (float) a.ts/a.ms < (float) b.ts/b.ms;
}
//dau <=
bool operator <= (ps a, ps b)   //f
{
    return (float) a.ts/a.ms <= (float) b.ts/b.ms;
}
int sosanh (ps a,ps b)
{
    return a.ts*b.ts-a.ms*b.ts;
}
//-----------------------------------  
void inphanso(ps a)    //thay bang dinh nghia chong tt <<
 {if ((a.ts==0)||(a.ms==1)) cout<<a.ts;
   else cout<<a.ts<<"/"<<a.ms;
 }
//------------------------------------
int  main()
 {
  ps a,b,z,t,k,h,l,c,d;
  cout<<"Moi nhap phan so a"; cin>>a;
  cout<<"Moi nhap phan so b"; cin>>b;
  z=a+b;  // z= operator+(x,y);
  t=a-b;  //t=operator-(x,y);
  l=-a;   // doi dau ps
  k=a*b;  //k=operator*(x,y)
  h=a/b;  // chia phan so 
  c=++a;  // ++
  d=--a;  //--
  cout<<"Cong phan so: ";
  inphanso(a);cout<<"   +   ";inphanso(b);cout<<"  =  ";inphanso(z);
  cout<<"\n\n";
  cout<<"Tru phan so: ";
  inphanso(a);cout<<"   -   ";inphanso(b);cout<<"  =  ";inphanso(t);
  cout<<"\n\n";
  cout<<"Dao dau phan so: ";
  inphanso(a);cout<<"  =  ";inphanso(l);
  cout<<"\n\n";
  cout<<"Nhan phan so: ";
  inphanso(a);cout<<"   *  ";inphanso(b);cout<<"  =  ";inphanso(k);
  cout<<"\n\n";
  cout<<"Chia phan so: ";
  inphanso(a);cout<<"   /   ";inphanso(b);cout<<"  =  ";inphanso(h);
  cout<<"\n\n";
  cout<<"Cong cong cho phan so: ";
  inphanso(a);cout<<"   ++  ";cout<<"  =  ";inphanso(c);
  cout<<"\n\n";
  cout<<"Tru tru cho phan so: ";
  inphanso(a);cout<<"   --   ";cout<<"  =  ";inphanso(d);
  cout<<"\n\n";
  sosanh(a,b);
  if(a>b)
        {
        cout<<"Phan so lon hon la: ";
    	inphanso(a);
    	cout<<"\n\n";
    	}
  else
  if(a<b)
		{
		cout<<"Phan so nho hon la:";inphanso(a);cout<<"   <  ";
		inphanso(b);
		cout<<"\n\n";
		} 
  if(a==b)
    {
    	cout<<"2 Phan so bang nhau: ";
    	inphanso(a);cout<<"   ==  ";inphanso(b);
    	cout<<"\n\n";
		}
	else 
	if(a!=b)
	{
	  cout<<"2 Phan so khac nhau: ";
	  inphanso(a);cout<<"   !=  ";inphanso(b);
	  cout<<"\n\n";
	  }
	if(a>=b)
	{
	 cout<<"Phan so a >= b: ";
	 inphanso(a);cout<<"  >=  ";inphanso(b);
	 cout<<"\n\n";
	 }
	else
	if(a<=b)
	{     
	    cout<<"Phan so a <= b: ";
		inphanso(a);cout<<"  <=  ";inphanso(b);
		cout<<"\n\n";
	}
  system("pause");
 }
