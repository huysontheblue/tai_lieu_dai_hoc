#include <stdio.h>
void out_put(int a[], int n);  // ham put in ra day so
void swap(int &a, int &b);    // ham swap hoan doi gia tri a va b
void selection_sort(int a[], int n); //sap xep chon
void swap(int &a, int &b){
	int tg = a;
	a = b;
	b = tg;
}
// hàm selseciton sort
void selection_sort(int a[], int n)
{
	for(int i = 1; i< n-1; i++)
	{
		int jmin = i - 1;
		for(int j = i - 1; j<n; j++)
		    if (a[j] < a[jmin]) 	jmin = j;
		if (jmin != i - 1) 	swap(a[i - 1], a[jmin]);
		printf("\ni = %3d: ", i); out_put(a,n);
	}
}
// hàm xuât mang
void out_put(int a[], int n)
{
     for(int i = 0; i < n; i++)
	 printf("%5d", a[i]);
	 printf("\n");
}

//in ra day so
int main (){
	int a[10] = {2,9,7,10,33,36,3,66,18,25};
	int n = sizeof(a)/sizeof(int);
	printf("n = %d", n);
	printf("\nINPUT: "); 
	out_put(a, n); 
	printf("\n");
	selection_sort(a,n);
	printf("\n\nOUTPUT: "); 
	out_put(a, n); 
	printf("\n");
}






