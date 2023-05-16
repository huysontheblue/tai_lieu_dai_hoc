#include <iostream>
using namespace std;

class SV{
	protected:
		string hoten;
		string lop;
	public:
		SV(string ht = "", string lop = ""){
			this->hoten = ht;
			this->lop = lop;
		}
		
		~SV(){
			
		}
		
		void Add(){
			cout <<"\n Nhap ho ten: "; cin >> hoten; //fflush(stdin); getline(cin, hoten);
			cout <<"\n Nhap lop: "; cin >> lop; //fflush(stdin); getline(cin, lop);
		}
		
		void Display(){
			cout <<"\n Ho ten: "<<hoten;
			cout <<"\n Lop: "<< lop;
		}
};

class SVSP: public SV{
	protected:
		float Dtb;
		int hocbong;
	public:
		SVSP(string ht = "", string lop = "", float dtb = 0, int hb = 0): SV(ht, lop){
			this->Dtb = dtb;
			this->hocbong = hb;
		}
		
		void Add(){
			SV::Add();
			cout <<"\n Nhap DTB = "; cin >> Dtb;
			cout <<"\n Nhap hoc bong = "; cin >>hocbong;
		}
		
		void Display(){
			SV::Display();
			cout <<"\n DTB = "<<Dtb;
			cout <<"\n Hoc bong = "<<hocbong;
		}
		
};

class SVCN :public SVSP{
	private:
		int hocphi;
	public:
		SVCN(string ht = "", string lop = "", float dtb = 0, int hb = 0, int hp =0): SVSP(ht, lop, dtb, hb){
			this->hocphi = hp;
		}
		
		void Add(){
			SVSP::Add();
			cout <<"\n Nhap hoc phi = "; cin >> hocphi;
		}
		
		void Display(){
			SVSP::Display();
			cout <<"\n Hoc phi = "<< hocphi;
		}
		
		bool operator>(SVCN &s2){
			if(this->hocphi > s2.hocphi){
				return true;
			}
			return false;
		}
};

int main(){
	SVCN *sv= new SVCN[3];
	for (int i=0; i< 3; i++){
		sv[i].Add();
	}
	
	for (int i=0; i<3; i++){
		sv[i].Display();
	}
	SVCN max;
	for (int i=0; i<3; i++){
		if(sv[i] > max){
			max = sv[i];
		}
	}
	cout <<"\n\t MAX la: ";
	max.Display();
}
