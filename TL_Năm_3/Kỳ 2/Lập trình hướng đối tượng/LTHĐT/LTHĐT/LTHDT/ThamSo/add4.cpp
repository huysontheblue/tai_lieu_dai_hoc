#include <conio.h>
#include <stdio.h>
#include <iostream>
using namespace std;
void add4(float &x, float &y) 
{
	x++; y++;
}
int main()
{
	float a=10,b=20;
	cout<<a<<"   "<<b;// 10 20
	add4(a,b);  // Truyen tham bien
	cout<<endl;
	cout<<a<<"   "<<b; // ?    ?
	getch();
	return 0;
}

