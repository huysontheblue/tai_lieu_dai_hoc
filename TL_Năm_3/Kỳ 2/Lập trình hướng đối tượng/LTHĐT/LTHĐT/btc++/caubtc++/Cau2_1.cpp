#include<iostream>
using namespace std;

class MyAttr{
	private:
		int Attr;
	public:
		
		MyAttr(int Attr = 1){
			this->Attr = Attr;
		}
		
		void AddAttr(){
			cout <<"\n Nhap so hieu thuoc tinh tep: ";
			cin >> Attr;
		}
		
		void DisplayAttr(){
			cout <<"\n So hieu tep = "<< Attr;
		}
};

class Mydate{
	private:
		int ngay, thang, nam;
	public:
		
		Mydate(int ngay = 1, int thang = 1, int nam = 1){
			this->ngay = ngay;
			this->thang = thang;
			this->nam = nam;
		}
		
		void AddDate(){
			cout <<"\n Nhap ngay: "; cin >> ngay;
			cout <<"\n Nhap thang: "; cin >> thang;
			cout <<"\n Nhap nam: "; cin >> nam;
		}
		
		void DisplayDate(){
			cout <<"\n Ngay - Thang - Nam: "<<ngay <<" - "<<thang <<" - "<<nam;
		}
		
		bool operator >(Mydate &d2){
			if (this->nam > d2.nam){
				return true;
			} else if (this->nam == d2.nam){
				if(this->thang > d2.thang){
					return true;
				} else if (this->thang == d2.thang){
					if(this->ngay > d2.ngay){
						return true;
					}
				}
			}
			return false;
		}
};

class MyFile : public MyAttr, public Mydate{
	private:
		char *filename;
		int filesize;
	public:
		
		MyFile(int Attr = 1, int ngay = 1, int thang = 1, int nam = 1 ,char *n = new char[255], int filesize = 0): MyAttr(Attr),Mydate(ngay, thang, nam){
			this->filename = n;
			this->filesize = filesize;
		}
		
		void AddFile(){
			cout <<endl;
			MyAttr::AddAttr();
			Mydate::AddDate();
			cout << "\n Nhap ten file: "; cin >> filename;
			cout <<"\n Nhap kich thuoc file: "; cin >> filesize;
		}
		
		void DisplayFile(){
			cout<<endl;
			MyAttr::DisplayAttr();
			Mydate::DisplayDate();
			cout <<"\n Ten file: "<< filename;
			cout <<"\n kich thuoc: "<< filesize;
		}
};

int main(){
	MyFile k[4];
	for (int i=0; i<4; i++){
		k[i].AddFile();
	}
	
	for (int i=0; i<4; i++){
		k[i].DisplayFile();
	}
	
	MyFile kt;
	for(int i=0; i< 3; i++){
		for(int j=i+1; j<4; j++){
			if(k[i] > k[j])
			{
				kt = k[i];
				k[i] = k[j];
				k[j] = kt;
			}
		}
	}
	cout <<"\n Sap xep"<<endl;
	for (int i=0; i<4; i++){
		k[i].DisplayFile();
	}
	
	return 0;
}
