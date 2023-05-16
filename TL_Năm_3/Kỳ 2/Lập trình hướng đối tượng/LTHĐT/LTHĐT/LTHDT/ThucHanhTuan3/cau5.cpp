#include <iostream>
using namespace std;
class sinhvien{
	private:
		char hoten[50];
		int masv;
		float DTB;
	public:
	void nhap(){
	 	cout<<"Nhap Ho ten: "<< endl; cin>>hoten;
	 	cout<<"Nhap MaSV: "<< endl; cin>>masv;
	 	cout<<"Nhap DTB: "<< endl; cin>>DTB;
	 	}
	void hienthi(){
	 	cout <<"Ho Ten: " << hoten << endl;
        cout <<"Masv : " << masv << endl;
        cout <<"DTB : " << DTB<< endl;
    }
};
int main(){
	sinhvien sv;
	sv.nhap();
	sv.hienthi();
	return 0;
}		
