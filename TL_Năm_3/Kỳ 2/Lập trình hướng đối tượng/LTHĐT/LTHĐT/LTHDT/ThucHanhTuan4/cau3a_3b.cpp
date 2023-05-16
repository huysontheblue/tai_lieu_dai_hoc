#include<iostream>
#include<stdlib.h>
#include<conio.h>
using namespace std;
class vector{
   private:
    int n;
    float *v;
  public:
     vector(int size);
     vector(vector &a);
     ~vector();
     void add();
     void display();
     int ktra(vector &a);
};
   vector::vector(int size){
    int i;
    n=size;
    v=new float [n];
}
   void vector::add(){
    int i;
    for (i=0;i<n;i++) {
    cout<<"v["<<i<<"]:"; cin>>v[i];}
}
   vector::vector(vector &a) {
    int i;
    n=a.n;
    v=new float [n];
    for (i=0;i<n;i++)
    v[i]=a.v[i];
}
  vector::~vector(){
    delete v;
}
   void vector::display() {
    int i;
    for (i=0;i<n;i++)
    cout<<v[i]<<"      ";
}
   int vector::ktra(vector &b){
    if (n==b.n) return 1;
   return 0;
}
int main(){
    int n;
    cout<<"Nhap so phan tu cua vector a: ";cin>>n;
    vector a(n);
    cout<<"Nhap vector a: \n"; a.add();
    cout<<"\nNhap so phan tu cua vector b: ";cin>>n;
    vector b(n);
    cout<<"Nhap vector b: \n";b.add();
    cout<<"vector a: ";a.display();
    cout<<"\nvector b: ";b.display();
    getch();
}
