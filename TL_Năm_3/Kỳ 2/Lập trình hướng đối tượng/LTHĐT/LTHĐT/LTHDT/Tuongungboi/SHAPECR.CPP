#include <conio.h>
#include <iostream>
#include <math.h>
using namespace std;
class Shape
{
	public:
    	virtual float dientich()
	  	{
		  	return 0;
		}
		virtual float chuvi()
	  	{
		  	return 0;
		}
       virtual void nhap() 
	   	{
	   	}
       void display()
	  	{
		  	cout<<"\n Dien tich = "<<dientich()<<"   "<<"Chu vi = "<<chuvi();
		}
  };
//------------------------------------------------------------------------
class Circle:public Shape
{	private:
       	float r;
   	public:
    	Circle(float ar=1) 
		{
			r=ar;
		}
    	void nhap()
	 	{
		 	cout<<"\n Nhap ban kinh hinh tron r = ";cin>>r;
		}
    	float dientich()
	 	{
		 	return M_PI*r*r;
		}
		float chuvi()
	 	{
		 	return 2*M_PI*r;
		}
};
//-------------------------------------------------------------------------
class Rectangle:public Shape
{
	private:
      	float a,b;
    public:
      	Rectangle(float oa=0, float ob=0) 
		{
		  	a=oa; 
			b=ob;
		}
      	void nhap()
	 	{
		 	cout<<"\n Nhap canh a = ";cin>>a;
	  		cout<<"\n Nhap canh b = ";cin>>b;
	 	}
     	float dientich()
	 	{
		 	return a*b;
		}
		float chuvi()
	 	{
		 	return 2*(a+b);
		}
  };
//-------------------------------------------------------------------------
int main()
{	
	Shape *s[5];
	int i;
   	for(i=0;i<5;i++)
    {
		s[i]= new Circle[1];
		s[i]->nhap();
	}
   	for(i=0;i<5;i++)
       s[i]->display();

	//SV tu bo sung

   	getch();
}
   
