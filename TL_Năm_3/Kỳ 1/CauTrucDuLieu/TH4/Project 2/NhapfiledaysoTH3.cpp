#include<conio.h>
#include<stdio.h>

int main()
{
	int n;
	printf("\nNhap so luon phan tu = ");
	scanf("%d",&n);
	int a[n];
	for(int i=0; i<n; i++)
	{
		printf("\n\tGia tri phan tu thu %d = ",i+1);
		scanf("%d",&a[i]);
	}
	printf("\n\n\tBan da nhap : ");
	for(int i=0; i<n; i++)
		printf("%d  ",a[i]);
	FILE *fsort;
	fsort = fopen("intput.txt","w");
	fprintf(fsort,"%d\n",n);
	for(int i=0; i<n; i++)
		fprintf(fsort,"%d\n",a[i]);
	fclose(fsort);
	printf("\n\n\tLuu FILE thanh cong ! :> ");
	return 0;
}
