#include<iostream>
using namespace std;

class Shape{
	public:
		virtual float dienTich(){
			return 0;
		}
		
		virtual float chuVi(){
			return 0;
		}
		
		virtual void Add(){
			
		}
		
		virtual void Display(){
			cout <<"\n Dien tich = "<<dienTich();
			cout <<"\n Chu vi = "<<chuVi();
		}
		
};

class Circle: public Shape{
	private:
		float r;
	public:
		Circle(float r =1){
			this->r = r;
		}
		
		void Add(){
			cout <<"\n Nhap ban kinh duong tron: ";
			cin >> r;
		}
		
		float dienTich(){
			return 3.14*r*r;
		}
		
		float chuVi(){
			return 2*3.14*r;
		}
};

class Rectangle: public Shape{
	private:
		float dai, rong;
	public:
		Rectangle(float dai = 1, float rong =1){
			this->dai = dai;
			this->rong = rong;
		}
		
		void Add(){
			cout <<"\n Nhap chieu dai: "; cin >> dai;
			cout <<"\n Nhap chieu rong: "; cin >> rong;
		}
		
		float dienTich(){
			return dai*rong;
		}
		
		float chuVi(){
			return 2*(dai+rong);
		}
};

int main(){
	Shape *x[3];
	Shape *y[3];
	
	for(int i=0; i<3; i++){
		cout <<"\n Nhap Duong tron";
		x[i] = new Circle[1];
		x[i]->Add();
	}
	
	for(int i=0; i<3; i++){
		cout<<"\nDuong tron";
		x[i]->Display();
	}
}
