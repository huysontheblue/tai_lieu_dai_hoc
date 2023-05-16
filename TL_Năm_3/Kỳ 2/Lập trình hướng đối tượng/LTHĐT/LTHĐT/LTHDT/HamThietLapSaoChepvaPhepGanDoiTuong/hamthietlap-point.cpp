#include <iostream>
#include <conio.h>
using namespace std;
class point
{	private:
     	float x,y;
	public:
       	point ()		
       	{
       		cout<<"Moi nhap toa do x = "; cin>>x;
       		cout<<"Moi nhap toa do y = "; cin>>y;	
		}
		 // ham thiet lap 
		point(float ox, float oy)
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
    point p(10,20);    //Goi ham thiet lap khong tham so
    p.display();
    
	point q=p;// q tu dong goi ham thiet lap sao chep ngam dinh
	q.display(); 
  
	cout<<endl;
	system("pause");
  }
