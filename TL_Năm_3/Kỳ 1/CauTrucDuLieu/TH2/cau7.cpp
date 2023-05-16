#include<stdio.h>
#include<conio.h>
long Giaithua(int n) {
	if(n==0)
	return 1;
	else
	return n*Giaithua(n-1);
}
long Tong(int n) {
	if(n==1)
	return 1;
	else
	return Tong(n-1)+Giaithua(n-1)*n;
}
int main(){
	int n;
	printf("nhap n = ");
	scanf("%d",&n);
	printf("Tong(%d)=%d",n,Tong(n));
	return 0;
	getch();
}
//	
