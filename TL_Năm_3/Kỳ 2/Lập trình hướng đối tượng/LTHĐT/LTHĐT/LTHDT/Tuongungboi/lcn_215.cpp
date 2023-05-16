#include<iostream>

using namespace std;
template <class T>
	T sum(T a[], int n){
		T s = a[0];
		for(int i=1; i<n; i++){
			s+=a[i];
			}
		return s;
}
class Frac{
	  protected:
	  	int a,b;
	  public:
	  	Frac(int tu=0, int mau=1){
	  		a=tu;
	  		b=mau;
		  }
		void add(){
			cout<<"\nNhap vao tu so : ";cin>>a;
			cout<<"\nNhap vao mau so: ";cin>>b;
		}
		void display(){
			cout<<a<<"/"<<b;
		}
		Frac operator+(Frac &x){
			Frac y;
			y.a =a*x.b+x.a*b;
			y.b = b*x.b;
			return y;
		}
		
		Frac operator=(Frac &x){
			a =x.a;
			b =x.b;
			return x;
		}
		Frac operator+=(Frac &x){
			a =a*x.b+x.a*b;
			b = b*x.b;
			return x;
		}
};

int main(){
	
	int arr1[] = {3,9,100,14,7,99};
	
	//xuat mang
	cout<<"\nMang so nguyen nhap vao la: \n";
	for(int i=0; i<6; i++){
		cout<<arr1[i];
		cout<<"\t";
	}
	int s = sum(arr1,6);
	cout<<"\ntong: "<<s;
	cout<<"\n-----------------------------\n";
	//mang so thuc
	float arr2[] = {2.4,1.3,55,14.3,7.34};
	
	//xuat mang
	cout<<"\nMang so thuc nhap vao la: \n";
	for(int i=0; i<5; i++){
		cout<<arr2[i];
		cout<<"\t";
	}
	
	float s1 = sum(arr2,5);
	cout<<"\nTong mang so thuc la: "<<s1;
	cout<<"\n-----------------------------\n";
	//mang phan so;
	int n;
	cout<<"Nhap vao gia tri n: ";cin>>n;
	cout<<"\nMang phan so\n";
	Frac *ps= new Frac[100];
	//nhap
	for(int i=0; i<n; i++){
		cout<<"ps "<<i+1<<": ";
		ps[i].add();
	}
	//xuat
	cout<<"\nMang nhap vao la: ";
	for(int i=0; i<n; i++){
		ps[i].display();
		cout<<"\t";
	}
	Frac x = sum(ps,n);
	cout<<"\nTong cua mang phan so la: ";
	x.display();
	
	
}
	

