#include <conio.h>
#include <stdio.h>
#include <iostream>
using namespace std;
void add2(float *x, float *y) 
{
	*x=*x+1; *y=*y+1;
}
int main()
{
	float a=10,b=20;
	cout<<a<<"   "<<b;// 10 20
	add2(&a,&b);
	cout<<endl;
	cout<<a<<"   "<<b; // Hop 11 21
	getch();
	return 0;
}

