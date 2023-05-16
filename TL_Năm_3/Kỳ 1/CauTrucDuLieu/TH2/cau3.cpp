#include<stdio.h>
#include<conio.h>
int tinhtong(int n)
{
	if(n==1)
	return 1;
	else
	return 2*n-1+tinhtong(n-1);
}
int main(){
    int n, s;
    s = 0;
	printf("nhap n = ");
	scanf("%d",&n);
	printf("tinhtong(%d)=%d",n,tinhtong(n));
	for(int i=1;i<=n;i++)
	s=s+tinhtong(i);
	printf("s = %d", s);
	return 0;
	getch();
}
