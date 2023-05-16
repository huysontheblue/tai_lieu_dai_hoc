#include <bits/stdc++.h>
using namespace std;
typedef struct
{
    int ts,ms;
    /* Tam UCLN */
    int gcd(int a, int b)
    {
        // Neu a = 0 => ucln(a,b) = b
        // Neu b = 0 => ucln(a,b) = a
        if (a == 0 || b == 0)
        {
            return a + b;
        }
        while (a != b)
        {
            if (a > b)
            {
                a -= b; // a = a - b
            }
            else
            {
                b -= a; // 
            }
        }
        return a;
    }
    void chuanhoa()
    {
        int d = gcd(ts,ms);
        ts /= d;
        ms /= d;
    }
} ps;
// nhap toan tu
ostream &operator <<(ostream &out,ps &a)
{
    out<<a.ts<<"/"<<a.ms;
    return out;
}
//-----------------------------------
// xuat toan tu
istream &operator >>(istream &in,ps &a)
{
    cout<<"\nnhap tu so: ";
    in>>a.ts;
    do
    {
        cout<<"\nnhap mau so :";
        in>>a.ms;
    }
    while(a.ms==0);
    if(a.ms<0)
    {
        a.ts=-a.ts;
        a.ms=-a.ms;
    }
    return in;
}
//--------------------------------------
ps taophanso(int t, int m)   //thay bang dinh nghia chong tt >>
{
    ps c;
    c.ts=t;
    c.ms=m;
    c.chuanhoa();
    return c;
}
//----------------------------------
ps operator +(ps a, ps b)
{
    ps c;
    c.ts  =  a.ts*b.ms + a.ms*b.ts;
    c.ms =  a.ms*b.ms;
    c.chuanhoa();
    return c;
}

//----------------------------------
ps operator - (ps a, ps b)
{
    ps c;
    c.ts  =  a.ts*b.ms - a.ms*b.ts;
    c.ms =  a.ms*b.ms;
    c.chuanhoa();
    return c;
}
//---------------------
ps operator - (ps a)
{
    a.ts=-a.ts;
    return a;
}
//------------------------
ps operator * (ps a, ps b)
{
    ps c;
    c.ts = a.ts*b.ts;
    c.ms = a.ms*b.ms;
    c.chuanhoa();
    return c;
}
//-------------------------
ps operator / (ps a, ps b)
{
    ps c;
    c.ts = a.ts*b.ms;
    c.ms = a.ms*b.ts;
    c.chuanhoa();
    return c;
}
//-----------------------------------
ps operator ++ (ps &a)
{
    a.ts += a.ms;
    a.chuanhoa();
    return a;
}
//----------------------------------
ps operator -- (ps &a)
{
    a.ts -= a.ms;
    a.chuanhoa();
    return a;
}
//-------------------------------------
bool operator == (ps a, ps b)  //a
{
    return (float) a.ts/a.ms == (float) b.ts/b.ms;
}
//-------------------------------------
bool operator != (ps a, ps b)  //b
{
    return (float) a.ts/a.ms != (float) b.ts/b.ms;
}
//-------------------------------------
bool operator > (ps a, ps b)   //c
{
    return (float) a.ts/a.ms > (float) b.ts/b.ms;
}
//-------------------------------------
bool operator >= ( ps a, ps b)  //d
{
    return (float) a.ts/a.ms >= (float) b.ts/b.ms;
}
//-------------------------------------
bool operator < (ps a, ps b)   //e
{
    return (float) a.ts/a.ms < (float) b.ts/b.ms;
}
//-------------------------------------
bool operator <= (ps a, ps b)   //f
{
    return (float) a.ts/a.ms <= (float) b.ts/b.ms;
}
//-------------------------------------
void inphanso(ps a)    //thay bang dinh nghia chong tt <<
{
    if ((a.ts==0)||(a.ms==1)) cout<<a.ts;
    else cout<<a.ts<<"/"<<a.ms;
}
//------------------------------------
int  main()
{

    ps x,y,z,t,k,h,l,m,n,a,b;
    cout<<"Moi nhap x";
    cin>>x;
    cout<<"Moi nhap y";
    cin>>y;
    
    z=x+y;  // z= operator+(x,y);
    t=x-y;  //t=operator-(x,y);
    l=-x;
    k=x*y;  //k=operator*(x,y)
    h=x/y;
    m=++x;
    n=--x;

    inphanso(x); cout<<"   +   ";inphanso(y); cout<<"  =  ";inphanso(z); cout<<"\n\n";
    inphanso(x); cout<<"   -   ";inphanso(y); cout<<"  =  ";inphanso(t); cout<<"\n\n";
    inphanso(x); cout<<"   =   ";inphanso(l); cout<<"\n\n";
    inphanso(x); cout<<"   *   ";inphanso(y); cout<<"  =  ";inphanso(k); cout<<"\n\n";
	inphanso(x); cout<<"   /   ";inphanso(y); cout<<"  =  ";inphanso(h); cout<<"\n\n";
    inphanso(x); cout<<"   ++  ";cout<<"  =  ";inphanso(m); cout<<"\n\n";
    inphanso(x); cout<<"   --  ";cout<<"  =  ";inphanso(n); cout<<"\n\n";
    cout<<"\n\n";
    system("pause");
}
