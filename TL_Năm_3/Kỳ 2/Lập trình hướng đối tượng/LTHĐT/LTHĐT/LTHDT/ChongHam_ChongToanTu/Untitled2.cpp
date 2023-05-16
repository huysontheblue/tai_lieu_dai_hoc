#include <cstdlib>
#include <iostream>
using namespace std;
    float *p;
	p = new float[10];
    int sum=0;
    double r;
    for(int i=0;i<10;i++)
        sum+=*p[i];
    r=(double)sum/p;
    return(r);
}
int main(){
   int n;
   cout<<"Nhap so cac so nguyen:";
   cin>>n;
   int arr[n];
   for(int i=0;i<n;i++){
       cout<<"Gia tri "<<i+1<<": ";
       cin>>*p[i];
   }
   cout<<"Gia tri trung binh="<<avg(*p,n)<<endl; 
return 0;
}
