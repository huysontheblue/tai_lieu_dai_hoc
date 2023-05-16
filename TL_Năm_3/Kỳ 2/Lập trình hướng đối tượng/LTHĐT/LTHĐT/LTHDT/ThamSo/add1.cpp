#include <conio.h>
#include <stdio.h>
#include <iostream>
using namespace std;
void add1(float x, float y) 
{
	x++; y++;
}
int main()
{
	float a=10,b=20;
	cout<<a<<"   "<<b;// 10 20
	add1(a,b);
	cout<<endl;
	cout<<a<<"   "<<b; // 10 20
	getch();
	return 0;
}

