#include<iostream>
#include<stdio.h>
#include<string.h>
#include<conio.h>
using namespace std;
class sinhvien{
	private:
		char *lop,*ten;
	public:
		sinhvien(){
			ten=new char[30];
			lop=new char[10];
		}
		sinhvien(char *h, char *l){
			ten=new char[30];strcpy(ten,h);
			lop=new char[10];strcpy(lop,l);
		}
		nhap(){
			cout<<"\nNhap Ho ten : ";
			fflush(stdin);gets(ten);
			cout<<"Nhap lop : ";fflush(stdin);gets(lop);
		}
		sinhvien(sinhvien &a){
			ten=new char[strlen(a.ten)+1];
			lop=new char[strlen(a.lop)+1];
		}
		void xuat(){
			cout<<"\nHo Ten : "<<ten<<"	lop : "<<lop;
		}
		~sinhvien(){
			delete ten;
			delete lop;
		}
};
class svsp : public sinhvien{
	private:
		float dtb;
		char *hocb;
	public:
		svsp() : sinhvien(){
			dtb=0;
			hocb=new char[30];
		}
		svsp(char *h, char *l,float d,char *hb) : sinhvien(h,l){
			dtb=d;
			hocb= new char[30];strcpy(hocb,hb);
		}
		svsp(svsp &a){
			dtb=a.dtb;
			hocb=new char[strlen(a.hocb)+1];
		}
		nhap(){
			sinhvien::nhap();
			cout<<"Nhap diem trung binh : ";cin>>dtb;
			cout<<"Nhap loai hoc bong : ";fflush(stdin);gets(hocb);
		}
		xuat(){
			sinhvien::xuat();
			cout<<"\ndiem trung binh : "<<dtb<<"\nhoc bong: "<<hocb;
		}
};
class svcn : public svsp{
	private :
		int hocphi;
	public :
		svcn() : svsp(){
			hocphi=0;
		}
		svcn(int a,char *h, char *l,float d,char *hb):svsp(h,l,d,hb){
			hocphi=a;
		}
		svcn(svcn &a){
			hocphi=a.hocphi;
		}
		nhap(){
			svsp::nhap();
			cout<<"Nhap Hoc phi : ";cin>>hocphi;
		}
		xuat(){
			svsp::xuat();
			cout<<" Hoc phi : "<<hocphi;
		}
		friend void sosanh(svcn a[],int n);
		
};
void nhaps(svcn a[],int n){
	for (int i=0;i<n;i++){
		cout<<"\nNhap thong tin sinh vien : "<<i+1;
		a[i].nhap();
	}
}
void xuats(svcn a[],int n){
	for (int i=0;i<n;i++)
		a[i].xuat();
}
void sosanh(svcn a[],int n){
	for (int i=0;i<n;i++)
		if (a[i].hocphi>a[i+1].hocphi){
			cout<<"\nHoc phi lon nhat : ";
			a[i].xuat();
		}
}
int main(){
	int n;
	cout<<"Nhap so sinh vien can quan ly : ";cin>>n;
	svcn a[n];
	nhaps(a,n);
	xuats(a,n);
	sosanh(a,n);

return 0;
}

