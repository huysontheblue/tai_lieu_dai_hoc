#include<stdio.h>
#include<conio.h>
void output(int a[], int n);  // ham put in ra day so
void swap(int &a, int &b);    // ham swap hoan doi gia tri a va b
void heapsort(int a[], int n); //sap xep vun dong
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
// hàm heap sort
void heapsort (int a[], int last)
{
for(int i=last/2;i>0;i--);}
void maxheapify(int a[], int parent, int last)
{
int child=2*parent;
While(int child<=int last)
{
if(child+1<=last && a[child+1]>a[child])
Child ++;
if(a[child]>a[parent])
doicho(a[child], a[parent]);
Parent=child;
Child=2*parent;
printf("\ni = %3d: ", i); output(a,n);
int main() {
	int a[10] = {2,9,7,10,33,36,3,66,18,25};
	int n = sizeof(a)/sizeof(int);
	printf("n = %d", n);
	printf("\nINPUT: "); 
	output (a, n); 
	printf("\n");
	heapsort(a,n);
	printf("\n\nOUTPUT: "); 
	output (a, n); 
	printf("\n");
	return 0;
	getch();
}
