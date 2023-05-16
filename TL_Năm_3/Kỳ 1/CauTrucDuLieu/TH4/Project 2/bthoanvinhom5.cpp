#include<conio.h>
#include<stdio.h>

int main()
{
	printf("YEU CAU : TIM HOAN VI CO CAC PHAN TU SAP XEP TU BE DEN LON !");
	printf("\n\nBuoc 1: Nhap du lieu (Nhap mang)");
	int n;
	printf("\n\tNhap n ( voi n la so luon phan tu cua mang ) = "); 
	scanf("%d",&n);
	int a[n];
	for(int i=0; i<n; i++)
	{
		printf("\n\tNhap gia tri cua phan tu thu %d = ", i+1);
		scanf("%d",&a[i]);
	}
	printf("\n\tGia tri ban nhap vao la :");
	for(int i=0; i<n; i++)
		printf("%d  ",a[i]);
	printf("\n\nBuoc 2: Tao cac hoan vi (theo 1 trinh tu nhat dinh)\n");
	int S = 0;
	for(int i=0; i<n; i++)
	{
		S = a[i];
		for(int j=i+1; j<n; j++)
		{
			if (a[j]<=S)
			{
				a[i] = a[j];
				a[j] = S;
				S = a[i];
				printf("\t");
				for (int i=0; i<n; i++)
		             printf("%d  ",a[i]);
		        printf("\n");
		    }
	    }
	}
	printf("\n\nBuoc 3: Ket qua cuoi cung \n\n");
	printf("\t\t");
	for (int i=0; i<n; i++)
		printf("%d  ",a[i]);
	return 0;
}
	
	
