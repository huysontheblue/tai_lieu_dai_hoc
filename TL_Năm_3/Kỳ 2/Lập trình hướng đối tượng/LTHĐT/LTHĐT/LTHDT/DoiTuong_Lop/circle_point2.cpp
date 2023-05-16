#include <iostream>
#include <conio.h>

using namespace std;
class point{
	private:
     	float x, y;
   	public:
     
      	void init(float ox, float oy)
        	{x=ox; y=oy;}
     	void move(float dx, float dy)
     		{x+= dx; y+= dy;}
     	void display()		
	 		{cout<<"\n Toa do x= "<<x<<"   Toa do y  = "<<y;}	
};  
//--------------------
class circle{
	private:
		point O;
		float r;
	public:
		void init(point A, float k){
		O=A; r=k;}
		void display(){
			cout<<"\n r ="<< r;
			O.display();          		//OK
		}  
		void move(float dx, float dy)
      		{O.move(dx,dy);}
};
int main()
{
	point A;
	A.init(10,20);
	circle c;
	c.init(A,5);
	c.display();
	c.move(100,200);
	c.display();  //5 110   220
	cout<<endl;
	system("pause");
}
		
	   
	   


