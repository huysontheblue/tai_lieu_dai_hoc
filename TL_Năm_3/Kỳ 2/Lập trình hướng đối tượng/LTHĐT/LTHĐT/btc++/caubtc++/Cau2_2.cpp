#include<iostream>
using namespace std;

class MyDate{
	private:
		int ngay, thang, nam;
	public:
		MyDate(int ngay=1, int thang=1, int nam =1){
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
			cout <<"\n Ngay - thang - nam: "<<ngay <<" - "<<thang<<" - "<<nam;
		}
		
		bool operator >(MyDate &d2){
			if(this->nam > d2.nam){
				return true;
			} else if (this->nam == d2.nam){
				if(this->thang > d2.thang){
					return true;
				} else if(this->thang == d2.thang){
					if(this->ngay > d2.ngay){
						return true;
					}
				}
			}
			return false;
		}
};

class Person: public MyDate{
	private:
		string Name, Address, Phone;
	public:
		Person(int ngay=1, int thang=1, int nam =1, string name = "", string address = "", string phone = ""): MyDate(ngay, thang, nam){
			this->Name = name;
			this->Address = address;
			this->Phone = phone;
		}
		
		void AddPerson(){
			MyDate::AddDate();
			cout <<"\n Nhap ten: "; cin >> Name;
			cout <<"\n Nhap dia chi: "; cin >>Address;
			cout <<"\n Nhap so dien thoai: "; cin >>Phone;
		}
		
		void DisplayPerson(){
			MyDate::DisplayDate();
			cout <<"\n Ten: "<<Name;
			cout <<"\n Dia chi: "<<Address;
			cout <<"\n So dien thoai: "<<Phone;
		}
};

class Officer : public Person{
	private:
		float Salary;
	public:
		Officer(int ngay=1, int thang=1, int nam =1, string name = "", string address = "", string phone = "", float salary = 0): Person(ngay, thang, nam, name, address, phone){
			this->Salary = salary;
		}
		
		void AddOfficer(){
			cout<<"\n Nhap Officer"<<endl;
			Person::AddPerson();
			cout <<"\n Nhap so luong: "; cin >> Salary;
		}
		
		void DisplayOfficer(){
			cout<<"\n Nhap Officer"<<endl;
			Person::DisplayPerson();
			cout <<"\n So luong: "<<Salary;
		}
};

int main(){
	Officer k[4];
	for(int i=0; i<4; i++){
		k[i].AddOfficer();
	}
	
	for(int i=0; i<4; i++){
		k[i].DisplayOfficer();
	}
	
	Officer kt;
	for(int i=0; i<3; i++){
		for(int j =i+1; j<4; j++){
			if(k[i] > k[j]){
				kt = k[i];
				k[i] = k[j];
				k[j] = kt;
			}
		}
	}
	cout<<"\nSap xep"<<endl;
	for(int i=0; i<4; i++){
		k[i].DisplayOfficer();
	}
}
