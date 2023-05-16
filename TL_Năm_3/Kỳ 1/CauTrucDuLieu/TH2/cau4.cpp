#include<stdio.h>
#include<conio.h>
float tinhtong(float n) {
	if(n==1)
	return 0.5;
	else
	return 1/(2*n)+tinhtong(n-1);
}
int main(){
	float n;
	printf("nhap n = ");
	scanf("%f",&n);
	printf("tinhtong(%f)=%f",n,tinhtong(n));
	return 0;
	getch();
}
