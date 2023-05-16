#include <iostream>
#include <iomanip>
#include <string.h>
#include <conio.h>
using namespace std;
class SV
{
	protected:
		string hoten;
		string lop;
	public:
		SV()
		{
			
		}
		SV(string h, string l)
		{
			hoten=h;
			lop=l;
		}
		void add()
		{
			cout<<"\nNhap hoten: "; cin.ignore();getline(cin,hoten);
			cout<<"Nhap lop: "; cin.ignore();getline(cin,lop);
		}
		~SV()
		{
			
		}
		SV (SV &a)
		{
			hoten=a.hoten;
			lop=a.lop;
		}
		void display()
		{
			cout<<setw(22)<<hoten<<setw(10)<<lop;
			
		}
		string getht()
		{
			return hoten;
		}
		string getl()
		{
			return lop;
		}
};
//=================================================
class SVSP:public SV
{
	private:
		float dtb,hocbong;
	public:
		SVSP():SV()
		{
		}
		SVSP(string h, string l, float d, float hb):SV(h,l)
		{
			dtb=d;
			hocbong=hb;
		}
		SVSP (SVSP &a):SV ((SV&)a)
		{
			dtb=a.dtb;
			hocbong=a.hocbong;
		}
		void display()
		{
			SV::display();
			cout<<"     "<<dtb<<"     "<<hocbong;
		}	
		void add()
		{
			SV::add();
			cout<<"Nhap diem trung binh: "; cin>>dtb;
			cout<<"Nhap hoc bong: "; cin>>hocbong;
		}
};
//=================================================
class SVCN:public SVSP
{
	private:
		float hocphi;
	public:
		SVCN():SVSP()
		{
		}
		SVCN(string h, string l, float d, float hb, float hp):SVSP(h,l,d,hb)
		{
			hocphi=hp;
		}
		SVCN (SVCN &a):SVSP ((SVSP&)a)
		{
			hocphi=a.hocphi;
		}
		void display()
		{
			SVSP::display();
			cout<<"     "<<hocphi;
			cout<<endl;
		}	
		void add()
		{
			SVSP::add();
			cout<<"Nhap hoc phi: "; cin>>hocphi;
		}
		float gethp()
		{
			return hocphi;
		}
		int operator>(SVCN &a)
		{
			if (hocphi>a.hocphi) return 1;
			return 0;
		}
};
//=================================================
int main()
{

	SVCN *s[20],*tg;
	string ht,l;
	float d,hb,hp;
	freopen("danhsach1.txt","r",stdin);
	freopen("ketqua.txt","w",stdout);
	int n=0;
	while (true)
	{
		ht = "";
		cin>>ht;
		if (ht.size()==0) break;
		string ht1;
		getline(cin, ht1);
		ht += ht1;
		cin>>l;
		string l1;
		getline(cin, l1);
		l += l1;
		cin>>d>>hb>>hp;
		s[n++]=new SVCN(ht,l,d,hb,hp);
		
	}
	cout<<"---------------------DANH SACH BAN DAU---------------------\n\n";
	for(int i=0;i<n;i++)
	{
		cout<<setw(2)<<i+1<<". ";s[i]->display();
	}
	
	for(int i=0;i<n-1;i++)
		for(int j=i+1;j<n;j++)
			if (*s[i]>*s[j])
			{
				tg=s[i];
				s[i]=s[j];
				s[j]=tg;
				
			}
	cout<<"\n\n";
	cout<<"-----------------DANH SACH SAU KHI SAP XEP-----------------\n\n";
	for(int i=0;i<n;i++)
	{
		cout<<setw(2)<<i+1<<". ";s[i]->display();
	}
	
	
	cout<<"-----DANH SACH SINH VIEN CO HOC PHI >500:-----\n";
	int dem=0;
	for(int i=0;i<n;i++)
		if (s[i]->gethp()>500)
		{
			dem++;
			cout<<setw(2)<<i+1<<". "<<setw(22)<<s[i]->getht()<<setw(10)<<s[i]->getl()<<setw(8)<<s[i]->gethp()<<endl;
		}
	cout<<"TONG SO SINH VIEN CO HOC PHI >500 LA: "<<dem;
	cerr<<"-----CHUONG TRINH DA HOAN THANH-----";
	cout<<endl;
	getch();
}
