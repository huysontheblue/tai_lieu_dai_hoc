#include<iostream>
using namespace std;
class PS
{
	private:
		int tuso;
		int mauso;
	public:
		// ham thiet lap 
		PS (int tu=0, int mau=0){
			tu=tuso;
			mau=mauso;
		}
		// ham nhap phan so
		void nhap(){
			cout<<"\nNhap tu so : ";cin>>tuso;
			cout<<"Nhap mau so : ";cin>>mauso;
		}
		// ham in phan so
		void hienthi(){
			cout<<tuso<<"/"<<mauso;
		}
		// toan tu cong
		PS operator +(PS &a){
			PS b;
			b.tuso= tuso*a.mauso+a.tuso*mauso;
			b.mauso= mauso*a.mauso;
			return b;
		}
};
int main(){
	PS *ps = new PS[100];
	int n;
	cout<<"\nCac phan so duoc nhap la: ";cin>>n;
	for(int i=0; i<n; i++){
		cout<<"\nNhap vao phan so thu "<<i+1<<": ";
		ps[i].nhap();
		cout<<"Phan so thu "<<i+1<<":   ";
		ps[i].hienthi();
	}
	cout<<"\nMang phan so vua nhap la: \n";
	for(int i=0; i<n; i++){
		ps[i].hienthi();
		cout<<"\t";
	}
	PS tong = ps[0];
	for(int i=1; i<n; i++){
		tong = tong + ps[i];
	}
	cout<<"\nTong cua cac phan so la: ";
	tong.hienthi();
    delete [] ps;
}
