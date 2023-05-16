#include<iostream>
#include<stdio.h>
#include<iomanip>
#include<string.h>
#include<conio.h>
using namespace std;
  class SV {
    private:
        char *name,*lop;
    public:
    // ham thiet lap	
      SV (char *ten=NULL,char *tlop=NULL){
        name=strdup(ten);
        lop=strdup(tlop);
}
    // ham huy bo
   ~SV(){
     delete name;
     delete lop;
}
    void dsp (){
       cout<<setw(20)<<name<<setw(10)<<lop;
}
};
class SVSP: public SV {
    private:
        float dtb, hb;
    public:
      SVSP (char *ten=NULL,char *tlop=NULL,float ddtb=0,float thb=0):SV (ten,tlop){
         dtb=ddtb;
         hb=thb;
   }
      void dsp() {
        SV::dsp();
        cout<<setw(5)<<dtb<<setw(10)<<hb;
   }
};
class SVCN : public SVSP {
    private:
        float hp;
    public:
     SVCN (char *ten=NULL,char *tlop=NULL,float ddtb=0,float thb=0,float thp=0):SVSP(ten,tlop,ddtb,thb){
             hp=thp;
}
     void dsp() { 
       cout<<setiosflags(ios::left);
       SVSP::dsp();
       cout<<setw(10)<<hp;
}
};
int main()
{
    SVCN *a[3];
    int i;
    char name[30],lop[10];
    float dtb,hb,hp;
 for (i=0;i<3;i++){
    cout<<"Thong tin sinh vien thu "<<i+1<<"\n";
    cout<<"Nhap ten: ";fflush(stdin);gets(name);
    cout<<"Nhap lop: ";fflush(stdin);gets(lop);
    cout<<"Nhap DTB: ";cin>>dtb;
    cout<<"Nhap hoc bong: ";cin>>hb;
    cout<<"Nhap hoc phi: ";cin>>hp;
    a[i]=new SVCN(name,lop,dtb,hb,hp);
}
    cout<<"\n=====THONG TIN SINH VIEN =======\n";
 for (i=0;i<3;i++) {
    cout<<"\n";
    a[i]->dsp();}
getch();
}
