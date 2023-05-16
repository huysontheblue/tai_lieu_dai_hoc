#include<stdio.h>
#include<conio.h>
void output(int a[], int n);  // ham put in ra day so
void swap(int &a, int &b);    // ham swap hoan doi gia tri a va b
void bubblesort(int a[], int n); //sap xep noi bot
//in ra day so
void output(int a[], int n)
{
     for(int i = 0; i < n; i++)
	 printf("%5d", a[i]);
	 printf("\n");
}
// ham swap hoan doi gia tri a va b
void swap(int &a, int &b){
	int tg = a;
	a = b;
	b = tg;
}
// hàm bubble sort
void bubblesort(int a[], int n) {
	for (int i = 0; i<n; i++) {
		for (int j = n - 1; j>i; j--)
		if (a[j - 1] > a[j]) {
			int temp = a[j - 1];
			a[j - 1] = a[j];
			a[j] = temp;
			printf("\ni = %3d: ", i); output(a,n);
		}
	}
}
int main() {
	int a[10] = {2,9,7,10,33,36,3,66,18,25};
	int n = sizeof(a)/sizeof(int);
	printf("n = %d", n);
	printf("\nINPUT: "); 
	output (a, n); 
	printf("\n");
	bubblesort(a,n);
	printf("\n\nOUTPUT: "); 
	output (a, n); 
	printf("\n");
	return 0;
	getch();
}
