#include<iostream>
#include<string.h>
using namespace std;

class Printer{
	private:
		string Name;
	public:
		virtual void Add(){
			cout<<"\n\t Nhap Printer \n"<<endl;
			cout<<"\n Nhap ten may in: ";
			cin >> Name;
		}
		
		virtual void Display(){
			cout <<"\n Ten: "<<Name;
		}
		
		virtual bool operator>(Printer &p2){
			if(this->Name > p2.Name){
				return true;
			}
			return false;
		}
};

class Laser: public Printer{
	private:
		int Dpi;
	public:
		void Add(){
			Printer::Add();
			cout<<"\n Nhap do phan giai: ";
			cin >> Dpi;
		}
		
		void Display(){
			Printer::Display();
			cout<<"\n Do phan giai: "<<Dpi;
		}
};

class ColorLaser: public Laser{
	private:
		string Color;
	public:
		void Add(){
			Laser::Add();
			cout<<"\n Nhap mau sac: ";
			cin >>Color;
		}
		
		void Display(){
			Laser::Display();
			cout<<"\n Mau sac: "<< Color;
		}
};

int main(){
	Printer *x[3];
	Printer *y[3];
	
	cout<<"\n Nhap Laser";
	for(int i=0; i<3; i++){
		x[i] = new Laser[1];
		x[i]->Add();
	}
	cout <<"\n Display";
	for(int i=0; i<3; i++){
		x[i]->Display();
	}
	
	Printer *kt1;
	for(int i=0; i<2; i++){
		for(int j=i+1; j<3; j++){
			if (*x[i] > *x[j]){
				kt1 = x[i];
				x[i] = x[j];
				x[j] = kt1;
			}
		}
	}
	
	cout <<"\n\n\t Sap xep\t";
	for(int i=0; i<3; i++){
		x[i]->Display();
	}
	
	
	cout<<"\n Nhap ColorLaser";
	for(int i=0; i<3; i++){
		y[i] = new ColorLaser[1];
		y[i]->Add();
	}
	cout <<"\n Display";
	for(int i=0; i<3; i++){
		y[i]->Display();
	}
	
	Printer *kt2;
	for(int i=0; i<2; i++){
		for(int j=i+1; j<3; j++){
			if (*y[i] > *y[j]){
				kt2 = y[i];
				y[i] = y[j];
				y[j] = kt2;
			}
		}
	}
	
	cout <<"\n\n Sap xep";
	for(int i=0; i<3; i++){
		y[i]->Display();
	}
}
