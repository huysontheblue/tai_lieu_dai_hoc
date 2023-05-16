#include <iostream>
using namespace std;

class Frac{
	protected:
		float a, b;
	public:
		Frac(float a=0, float b=1){
			a= a;
			b = b;
		}
		
		void Add(){
			cout<<"\n NHAP PHAN SO \n";
			cout<<"\n Nhap tu so: "; cin >> a;
			cout<<"\n Nhap mau so: "; cin >>b;
		}
		
		void Display(){
			cout <<"\n "<<a <<" / "<<b;
		}
		
		bool operator >(Frac &p2){
			if(this->a * p2.b > p2.a * this->b){
				return true;
			}
			return false;
		}
		
		Frac operator =(const Frac& p2){
			this->a = p2.a;
			this->b = p2.b;
			return *this;
		}
};

template <class Frac>
Frac max(Frac *a, int n){
	Frac max1 = a[0];
	for (int i=0; i<n; i++){
		if (a[i] > max1){
			max1 = a[i];
		}
	}
	return max1;
}

int main(){
	int n;
	cout <<"\n Nhap so phan tu: "; cin >>n;
	
	Frac *ps = new Frac[n];
	for(int i=0; i<n; i++){
		ps[i].Add();
	}
	
	Frac max1 = max(ps, n);
	cout <<"\n PHAN SO LON NHAT LA: ";
	max1.Display();
	
	
	cout <<"\n NHAP SO THUC";
	float *ListFloat = new float[n];
	for (int i=0; i<n; i++){
		cout <<"\n Nhap so thu "<<i+1<<" la: ";
		cin >> ListFloat[i];
	}
	
	float max_float = max (ListFloat, n);
	cout <<"\n MAX = "<< max_float;
	
	
}
