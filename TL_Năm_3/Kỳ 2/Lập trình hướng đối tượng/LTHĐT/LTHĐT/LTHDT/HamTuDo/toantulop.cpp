#include <iostream>
#include <conio.h>
using namespace std;
class complex
{
	private:
		float a,b;
	public:
		complex(float oa=0, float ob=0)
		{
			a=oa; b=ob;
		}
		void add()
		{
			cout<<"\nNhap Phan thuc va Phan ao: ";
			cin>>a>>b;
		}
		void display()
		{
			if (b<0) cout<<a<<" - i*"<<-b;
			else cout<<a<<" + i*"<<b;
			cout<<endl;
		}
		complex operator+(complex &c)  //Toan tu cua lop
		{
			complex d;  
			d.a=a+c.a;
			d.b=b+c.b;	
			return d;
		}		
};

//===========================================
int main()
{
	complex u;
	u.add();
	u.display();
	
	complex v;
	v.add();
	v.display();
	
	complex t;
	t=u+v;  //tuong duong t=u.operator+(v);
	cout<<"\nTong hai so phuc = ";
	t.display();
	
	getch();
	return 0;
}
		
