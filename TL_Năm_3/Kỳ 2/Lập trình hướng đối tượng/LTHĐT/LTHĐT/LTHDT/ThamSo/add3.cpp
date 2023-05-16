#include <conio.h>
#include <stdio.h>
#include <iostream>
using namespace std;
void add3(float *x, float y) 
{
	*x=*x+1; y++;
}
int main()
{
	float a=10,b=20;
	cout<<a<<"   "<<b;// 10 20
	add3(&a,b);
	cout<<endl;
	cout<<a<<"   "<<b; // 11 20
	getch();
	return 0;
}

