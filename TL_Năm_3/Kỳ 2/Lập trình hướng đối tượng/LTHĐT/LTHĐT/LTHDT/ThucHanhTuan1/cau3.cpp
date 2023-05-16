#include <bits/stdc++.h>
using namespace std;
int dientich(float a=1, float b=2) {
return a*b;
}
int chuvi(float a=1, float b=1) {
return (a+b)*2;
}
//int f(float a, float b=1)   	// OK
//int f(float a, float b=1) 
int main() {
	cout<<"\n Dien tich :"<<dientich();	
	cout<<"\n Dien tich :"<<dientich(3);		
	cout<<"\n Dien tich :"<<dientich(2,3);		
	cout<<"\n Chu vi :"<<chuvi();			
	cout<<"\n Chu vi :"<<chuvi(3);			
	cout<<"\n Chu vi :"<<chuvi(2,3);			
}
