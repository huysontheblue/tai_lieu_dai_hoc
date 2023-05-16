#include<iostream>
using namespace std;

class MatHang{
	private:
		string Ten;
	public:
		virtual void Add(){
			
			cout <<"\n Nhap ten: "; cin >> Ten;
		}
		
		virtual void Display(){
			
			cout<<"\n Ten: "<<Ten;
		}
};

class MayTinh: public MatHang{
	private:
		int Speed;
	public:
		void Add(){
			MatHang::Add();
			cout<<"\n Nhap toc do: "; cin >> Speed;
		}
		
		void Display(){
			MatHang::Display();
			cout<<"\n Toc do: "<<Speed;
		}
};

class MayIn: public MatHang{
	private:
		int Dpi;
	public:
		void Add(){
			MatHang::Add();
			cout <<"\n Nhap do phan giai: ";
			cin >> Dpi;
		}
		
		void Display(){
			MatHang::Display();
			cout<<"\n Do phan giai: "<< Dpi;
		}
};

int main(){
	MatHang *x[3];
	MatHang *y[3];
	
	cout <<"\n\t Nhap Mat Hang \n";
	for(int i=0; i<3; i++){
		x[i] = new MayTinh[1];
		x[i]->Add();
	}
	
	cout<<"\n\t Hien thi Mat Hang \n";
	for(int i=0; i<3; i++){
		x[i]->Display();
	}
	
	cout <<"\n\t Nhap Mat Hang \n";
	for(int i=0; i<3; i++){
		y[i] = new MayIn[1];
		y[i]->Add();
	}
	
	cout<<"\n\t Hien thi Mat Hang \n";
	for(int i=0; i<3; i++){
		y[i]->Display();
	}
}
