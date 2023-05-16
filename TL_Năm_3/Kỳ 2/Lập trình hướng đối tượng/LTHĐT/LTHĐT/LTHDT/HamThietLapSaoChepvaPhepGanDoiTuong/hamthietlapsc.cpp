#include <iostream>
#include <conio.h>
#include <string.h>
using namespace std;
class sinhvien
{
	private:
		char *hoten;
		char *lop;
		int tuoi;
	public:
		sinhvien()
		{
			hoten=new char[30];
			lop=new char[10];
			
		}
		sinhvien(char h[], char l[], int t)
		{
			hoten=new char[30];
			strcpy(hoten,h);
			lop=new char[10];
			strcpy(lop,l);
			tuoi=t;
		}
		sinhvien(sinhvien &s) //Ham thiet lap sao chep
		{
			hoten=new char[strlen(s.hoten)+1];
			strcpy(hoten,s.hoten);
			lop=new char[strlen(s.lop)+1];
			strcpy(lop,s.lop);
			tuoi=s.tuoi;
		}
			
		void add()
		{
			cout<<"Nhap ho va ten: "; gets(hoten);fflush(stdin);
			cout<<"Nhap lop: ";gets(lop);
			cout<<"Nhap tuoi: "; cin>>tuoi;
		}
		void display()
		{
			cout<<hoten<<"   "<<lop<<"   "<<tuoi;
		}
		~sinhvien()
		{
			delete hoten;
			delete lop;
		}
};
//===============================
int main()
{
	sinhvien a;  //Goi ham thiet lap khong tham so
	a.add();
	a.display();
	
	cout<<endl;
	sinhvien b("Nguyen Van An","59CNTT",20); //Goi ham thiet lap 3 tham so
	b.display();
	
	cout<<endl;
	sinhvien c=b; //c tu dong goi ham thiet lap sao chep
	c.display();
	
	system("pause");
}
	

			
			
			
