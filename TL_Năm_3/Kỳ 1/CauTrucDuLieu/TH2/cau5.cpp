#include<stdio.h>
#include<conio.h>

float tong(int n) {
    if (n==1)
    return 1;
    else
    return tong(n-1)+1/(tong(n-1)+n*n);
}
int main(){
	float n;
	printf("nhap n = ");
	scanf("%f",&n);
	printf("tong(%f)=%f",n,tong(n));
	return 0;
	getch();
}
