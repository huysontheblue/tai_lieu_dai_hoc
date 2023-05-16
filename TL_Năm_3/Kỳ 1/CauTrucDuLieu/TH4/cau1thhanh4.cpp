// tim kiem tuan tu (tuyen tinh)

#include<conio.h>
#include<stdio.h>
#include<stdlib.h>
#include<time.h>
const int n=10;
int A[n];
void nhap()
{
	time_t t;
    srand((int)time(&t));
    for(int i = 0; i < n; ++i){
        A[i] = rand() % 10;
	}
}
int in(int A[], int n)
{
	for(int i=0; i<n; i++)
	{
		printf("%5d",A[i]);
	}
}
int TimKiemTheoTuanTu(int A[], int n, int x)
{
	for(int i=0; i<n; i++)
	{
		if(A[i]==x)
			return i;
	}
	return (-1);
}
int main()
{
	int x;
	nhap();
	printf("ds la.");
	in(A,n);
	printf("\nnhap so can tim:"); scanf("%d", &x);
	int k= TimKiemTheoTuanTu(A, n, x);
	if(k>=0)
		printf("\n %d o vi tri thu %d", x, k);
	else
		printf("\n %d ko co trong mang!!",x);
}
