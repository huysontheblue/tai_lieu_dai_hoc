#include<iostream>
using namespace std;

class SV{
	private:
		string Name;
		string Lop;
	public:
		SV(string name = "", string lop = ""){
			this->Name = name;
			this->Lop = lop;
		}
		
		virtual void Add(){
			cout <<"\n Nhap SV";
			cout <<"\n Nhap ho ten: "; cin >>Name;
			cout <<"\n Nhap lop: "; cin >>Lop;
		}
		
		virtual void Display(){
			cout <<"\n SV";
			cout <<"\n Ho ten: "<<Name;
			cout <<"\n Lop: "<<Lop;
		}
};

class SVSP: public SV{
	private:
		int hocbong;
	public:
		SVSP(string name = "", string lop = "", int hocbong = 0): SV(name, lop){
			this->hocbong = hocbong;
		}
		
		void Add(){
			SV::Add();
			cout <<"\n Nhap hoc bong: ";
			cin >> hocbong;
		}
		
		void Display(){
			SV::Display();
			cout<<"\n Hoc bong: "<<hocbong;
		}
};

class SVTC: public SV{
	private:
		int hocphi;
	public:
		SVTC(string name = "", string lop = "", int hocphi = 0) : SV(name, lop){
			this->hocphi = hocphi;
		}
		
		void Add(){
			SV::Add();
			cout<<"\n Nhap hoc phi: ";
			cin >>hocphi;
		}
		
		void Display(){
			SV::Display();
			cout <<"\n Hoc phi: "<<hocphi;
		}
};

int main(){
	SV *x[3];
	SV *y[3];
	
	for(int i=0; i<3; i++){
		x[i] = new SVSP[1];
		x[i]->Add();
	}
	
	for(int i=0; i<3; i++){
		x[i]->Display();
	}
}
