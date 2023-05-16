#include <bits/stdc++.h>
using namespace std;
float chuvi(float a=1, float b=2, float c=5 ) {
    return a + b + c;
}
float dientich(float a=1, float b=4, float  c = 4) {
    float p = chuvi(a, b, c) / 2.0;
    return sqrt(p*(p - a)*(p - b)*(p - c));
}
//void add(float a, float b=4, float c)
//void add(float a, float b=4, float c) 	    	
int main() {
	cout<<"\n Chu vi :"<<chuvi();		// a=1	
	cout<<"\n Chu vi :"<<chuvi(3);		// a=3	
	cout<<"\n Chu vi :"<<chuvi(2,3,4);	//a=2 b=3 c=4
	cout<<"\n Dien tich :"<<dientich();	//a=a
	cout<<"\n Dien tich :"<<dientich(3);	//a=3	
	cout<<"\n Dien tich :"<<dientich(2,3,4);	//a=2 b=3 c=4	
			
}
