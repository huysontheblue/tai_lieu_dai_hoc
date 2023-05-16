#include <iostream>
#include <conio.h>
using namespace std;
class point
{	private:
     	float x,y;
	public:
//       	point ()		
//       	{
//       		cout<<"Moi nhap toa do x = "; cin>>x;
//       		cout<<"Moi nhap toa do y = "; cin>>y;	
//		}
        // ham thiet lap	   
		point(float ox=10, float oy=20)
    	{  x=ox; y=oy;}
  		
     	void move(float dx, float dy);
     	void display();			
};  
    void point::move(float dx, float dy) 
       {x+= dx; y+= dy;}
    void point::display() 
       {cout<<"\n Toa do x= "<<x<<"   Toa do y  = "<<y;}
int main() 
   {
    point p;   
    p.display();
    point q(100,200);
    q.display(); 
    point r(500); 
	cout<<endl;
	system("pause");
  }
