#include <iostream>
#include <conio.h>
using namespace std;
class date{
  private: 	
	int dd;
	int mm;
	int yy;
  public:
    date(int ngay=1,int thang=1,int nam=1){
    	ngay=dd;
		thang=mm;
		nam=yy;
	};	
    date(){
    };
    // ham nhap thong tin ngay thang nam
    void nhap() 
   {
       cout<<"\nnhap ngay:";cin>>dd;
       cout<<"\nnhap thang:";cin>>mm;
       cout<<"\nnhap nam:";cin>>yy;
	}
	//ham hien thi
    void display() 
   {
    cout<< dd <<"-"<< mm <<"-"<< yy;
   }
   //void laynam()
   //{
   //return yy;
   //}
};
int main(){
  date::d = new date[100];
  int i, n;
  cout<<"\nNhap so luong Date can nhap vao: "; cin>>n;
   for(i=0;i<n;i++){
    cout<<"\n\n Nhap doi tuong thu "<<i+1<<":";
     d[i].nhap(); 
   }
   cout<<"\n\n Mang vua nhap: ";
    for(i=0;i<n;i++){
     d[i].display(); 
   cout<<"\n";}
system("pause");
}
