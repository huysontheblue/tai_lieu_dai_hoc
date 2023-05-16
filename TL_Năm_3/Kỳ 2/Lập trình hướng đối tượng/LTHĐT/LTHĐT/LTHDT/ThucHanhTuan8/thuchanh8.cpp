
#include<iostream>
#include<string.h>
using namespace std;
class printer{
	private:
		string name;
	public:
		printer(){
		}
		printer(string ten){
			name=ten;
		}
		virtual void nhap(){
			cout<<"Nhap ten may in : ";
			cin.ignore();
			getline(cin,name);
		}
		virtual void xuat(){
			cout << "Ho ten : "<<name<<endl;
		}
		string getten(){
		 	return name;
		}
		virtual int operator >(printer &r){
			if (name > r.name)
				return 1;
			else
				return 0;
		}
};
class laser : public printer{
	private:
		int dpi;
	public:
		laser() : printer(){
			dpi=0;
		}
		laser(string ten,int d) : printer(ten){
			dpi=d;
		}
		virtual void nhap(){
			printer :: nhap();
			cout<<"nNhap gia tri DPI : ";
			cin>>dpi;
		}
		virtual void xuat(){
			printer ::xuat();
			cout<<"dpi : "<<dpi<<endl;
		}		
};
class colorl : public laser{
	private:
		int color;
	public:
		colorl() : laser(){
			color=0;
		}
		colorl(string ten,int d,int c):laser(ten,d){
			color=c;
		}
		void nhap(){
			laser::nhap();
			cout<<"Nhap gia tri color : ";
			cin>>color;
			cout<<endl;
		}
		void xuat(){
			laser::xuat();
			cout<<"Mau sac : "<<color<<endl<<endl;
		}
};


int main(){
	printer *a[10],*b[10],*tg;
/*	for (int i=0;i<3;i++){
		a[i]=new laser[1];
		a[i]->nhap();	
	}
	for (int i=0;i<3;i++)
		a[i]->xuat();
==============================
	for (int i=0;i<3;i++){
		b[i] = new colorl[1];
		b[i]->nhap();	
	}
	for (int i=0;i<3;i++)
		b[i]->xuat();
*/	
	string ten,ten1;
	int d,c;
	freopen("in.txt","r",stdin);
	int n;
	while (true){
		ten="";
		cin>>ten;
		if (ten.size()==0) break;
		getline(cin, ten1);
		ten += ten1;
		cin>>d>>c;
		a[n++]= new colorl(ten,d,c);
		cout<<"Inport file : "<<n<<endl;	
	}
	freopen("out.txt","w",stdout);
	cout<<"---------------------DANH SACH BAN DAU---------------------\n\n";
	for (int i=0;i<n;i++)
		a[i]->xuat();
	cout<<"-------------------DANH SACH SAU SAP XEP--------------------\n\n";
	for(int i=0;i<n-1;i++)
		for(int j=i+1;j<n;j++)
			if (*a[i]>*a[j]){
				tg=a[i];
				a[i]=a[j];
				a[j]=tg;	
			}
	cout<<"\n\n";
	for (int i=0;i<n;i++)
		a[i]->xuat();
	cerr<<"\nHoan Thanh ";
	
return 0;
}


