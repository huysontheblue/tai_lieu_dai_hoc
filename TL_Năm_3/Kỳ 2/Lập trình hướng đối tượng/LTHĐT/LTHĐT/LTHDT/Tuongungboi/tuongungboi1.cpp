//Vi du ve don ke thua
#include <iostream>
#include <conio.h>
using namespace std;
class point
{
	private:
		float x, y;
	public:
 		point()
		{
			x=0; y=0;
		}
		point(float ox, float oy)
		{
			x=ox; y=oy;
		}
		point(point &p)
		{
			x=p.x; y=p.y;
		}
		void virtual display()
		{
			cout<<"\n x = "<<x<<" y = "<<y;
		}
		void move(float dx, float dy)
		{
			x+=dx; y+=dy;
		}
};
//======================================================
class color_point: public point
{
	private:
		int m;
	public:
 		color_point() : point() //dinh nghia
		{
			m=0;
		}
		color_point(float ox, float oy, int c) : point(ox,oy) //dinh nghia
		{
			m=c;
		}

		color_point(color_point &a) : point((point &)a)  //dinh nghia
		{
			m=a.m;
		}
		void display()   //dinh nghia lai
		{
 	  		point::display();	       
   			cout<<" color = "<<m;
		}
};
//===========================================================
int main()
{
	point *ptr;
	point p(4,5);
	color_point m(1,2,3); 	//goi ham thiet lap 3 tham so cua color_point
	
	ptr=&p;
	ptr->display();		//Goi ham display cua lop cha
	
	ptr=&m;
	ptr->display();		//Goi ham display cua lop con
	
		
	cout<<endl<<endl;
	system("pause");
}		


