#include<iostream>
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
			cout<<dd<<" - "<<mm<<" - "<<yy;
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
int main(){
	Mydate *date = new Mydate[100];
	int n;
	cout<<"\nSo ngay thang nam duoc nhap la: ";cin>>n;
	for(int i=0; i<n; i++){
		cout<<"\nNhap vao thong tin lan  "<<i+1<<": \n";
		date[i].nhap();
	}
	cout<<"\nMang ngay vua nhap la: \n";
	for(int i=0; i<n; i++){
		date[i].hienthi();
		cout<<"\n";
	}
	Mydate max= date[0];
	for(int i=0; i<n; i++){
		if(date[i]>=max)
		max=date[i];
	}
	cout<<"Ngay lon nhat la: ";
	max.hienthi();
	delete [] date;
}
