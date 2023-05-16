#include <conio.h>
#include <iostream>
using namespace std;
int main(){
	float *p;
	p = new float[10];
	for(int i = 0;i < 10; ++i){
        cout<<"\nNhap = "<<i;
        cin>>*p;
    }
	int sum = 0;
    int count = 0;
    for(int i = 1; i < n; i+=2){
            ++count;
            sum += *p;
        }
    }	
	delete p;
	return 0;
}

