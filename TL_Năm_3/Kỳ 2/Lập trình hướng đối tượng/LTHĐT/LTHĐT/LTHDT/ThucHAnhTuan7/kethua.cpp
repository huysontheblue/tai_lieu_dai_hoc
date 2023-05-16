// ha huy son
#include<iostream>
#include<string.h>
#include<conio.h>
using namespace std;
class Mydate
{
	private:
		int dd;
		int mm;
		int yy;
	public:
		// ham thiet lap
		Mydate(int ngay=1, int thang=1, int nam=1){
			ngay=dd;
			thang=mm;
			nam=yy;
		}
		// ham nhap ngay thang nam
		void nhap(){
			cout<<"Nhap ngay : ";cin>>dd;
			cout<<"Nhap thang: ";cin>>mm;
			cout<<"Nhap nam  : ";cin>>yy;
		}
		// ham hien thi ngay thang nam
		void hienthi(){
			cout << dd << " - " << mm <<" - "<< yy;
		}
		// ham ban khai bao toan tu
	    friend bool operator >=(Mydate &a, Mydate &b);
};
    bool operator >=(Mydate &a, Mydate &b){
		if(a.yy>b.yy){
			return true;}
			if(a.yy==b.yy and a.mm>b.mm){
				return true;}
				if(a.mm==b.mm and a.dd>= b.dd){
					return true;}
		else
			return false;
}
class person : public Mydate{
    private:
    	char * name;
    	char * address;
    	int phone;
    public:
    	// ham thiet lap
    	person() : Mydate(){
    		name=new char[30];
    		address=new char[30];
    		phone=0;
		} 
		// ham hien thi thong tin ve mot nguoi
		hien(){
			Mydate::hien();
			cout<<"ho ten: "<<name<<"dia chi :"<<address<<"dien thoai :"<<phone;
		}
		// ham huy bo
		~person(){
			delete name;
			delete address;
			delete phone;
		}
};
class officer : public person{
    private:
	    salary int;
	public:
	// ham thiet lap
	    officer() : person(){
	    	salary=0
		} 
	// ham hien thi thong tin ve mot can bo vien chuc
	    xuat(){
	    	person::xuat();
	    	cout<<"luong :"<<salary;
		}
	};
void nhaps(officer a[],int n){
	for (int i=0;i<n;i++){
		cout<<"\nNhap thong tin ngay thang : "<<i+1;
		a[i].nhap();
	}
}
void xuats(officer a[],int n){
	for (int i=0;i<n;i++)
		a[i].xuat();
}
int main(){
	int n;
	cout<<"nhap so luong ngay thang nam :";cin>>n;
	officer  a[n];
	nhaps(a,n);
	xuats(a,n);
	return 0;
}	
