#include<stdio.h>
#include<conio.h>
float Tong(float n)
{
    if (n==0)
    return 0.5;
    else
    return Tong(n-1)+(2*n+1)/(2*n+2);
}
int main(){
	float n;
	printf("nhap n = ");
	scanf("%f",&n);
	printf("Tong(%f)=%f",n,Tong(n));
	return 1;
	getch();
}
// tuyen tinh
