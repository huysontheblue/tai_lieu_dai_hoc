#include <iostream>
#include <string.h>
using namespace std;
class Sinhvien{
		private:
			char *hoten;
			char *lop;
			int tuoi;
public:
		Sinhvien(){
			hoten=new char[30];
			lop=new char[10];
		
		}
		Sinhvien(char *h, char *l, int t){
			hoten=new char[strlen(h)+1]; 
			strcpy(hoten,h);
			lop=new char[strlen(l)+1]; 
			strcpy(lop,l);
			tuoi=t;
		}
		void add()
		{
			cout<<"Nhap ho va ten: "; 
			fflush(stdin);gets(hoten);
			cout<<"Nhap lop: ";
			fflush(stdin);gets(lop);
			cout<<"Nhap tuoi: "; cin>>tuoi;
		}
		void display(){
			cout<<"\n"<<hoten<<"   "<<lop<<"   "<<tuoi;
		}
		~Sinhvien()
		{
			delete hoten;
			delete lop;
			cout<<"\nDa huy bo doi tuong";
		}
	
};
int main()
{
	Sinhvien s;
	s.add();
	s.display();
	Sinhvien t("Nguyen Van An","59CNTT",21);
	t.display();
	Sinhvien r("Tran Van Binh","59CNTT",21);
	r.display();
	return 0;
}
