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
		virtual	float operator > (Shape &s)
		{
			if (dientich() > s.dientich()) 
				return 1;
			return 0;
		};
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
		float operator > (Circle &s)
		{
			if (dientich() > s.dientich()) 
				return 1;
			return 0;
		}

};
//-------------------------------------------------------------------------
class Rectangle:public Shape
{
	private:
      	float a,b;
    public:
    	float dt;
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
		float operator > (Rectangle &s)
		{
			if (dientich() > s.dientich()) 
				return 1;
			return 0;
		}

  };
//-------------------------------------------------------------------------

int main()
{	
	Shape *s[4];
	int i;
   	for(i=0;i<4;i++)
    {
		s[i] = new Circle[1];
		s[i]->nhap();
	}
	for(i=0;i<4;i++)
    {
    	cout <<"\nHinh tron thu " << i<< ":";
		s[i]->display();
	}

	//So sanh
	Shape *max;
	max = s[0];
	for (i = 0; i < 4; i++)
	{
		if(*s[i] > *max)
			max = s[i];
	}
	cout <<"\nHinh tron co dien tich lon nhat: ";
	max->display();
   	
   	//hinh chu nhat
   	Shape *p[4];
   	for(i=0;i<4;i++)
    {
		p[i] = new Rectangle[1];
		p[i]->nhap();
	}
	for(i=0;i<4;i++)
    {
    	cout << "\nHinh chu nhat thu " <<i<< ": ";
		p[i]->display();
	}
	//So sanh
	Shape *max1;
	max1 = p[0];
	for (i = 0; i < 4; i++)
	{
		if(*p[i] > *max1)
			max1 = p[i];
	}
	cout <<"\nHinh chu nhat co dien tich lon nhat: ";
	max1->display();
   	getch();
}
   
