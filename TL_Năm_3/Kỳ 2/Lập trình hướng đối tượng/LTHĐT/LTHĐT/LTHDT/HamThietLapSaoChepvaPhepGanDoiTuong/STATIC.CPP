#include <conio.h>
#include <iostream>
#include <string.h>
using namespace std;
class student
 {private:
    char *name;
    float fee;
    static float total;
  public:
    student(char *n = NULL, float f=0)
     {name = new char[strlen(n)+1];
	  strcpy(name,n);
      fee=f;
      total = total + fee;
     }
    void Display() 
     {cout<<"\nName:"<<name<<"   Fee:"<<fee;
      cout<<"  Total:"<<total;
     }
    ~student()
    {
    	
    	delete name;
    }
    
 }; // Het lop

float student::total=0; // Khoi tao cac thanh phan tinh

int main() 
 {
  student s1("an",10),s2("binh",20),s3("cuong",30);
  cout<<endl;s1.Display(); //an     10     60
  cout<<endl;s2.Display(); // binh  20    60
  cout<<endl;s3.Display(); // cuong  30    60
  student s4("lan",40);
  s4.Display(); //lan 40  100
  s1.Display(); //an 10 100
  cout<<endl;
  system("pause");
 }
