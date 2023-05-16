#include <stdio.h>
#include<iostream>
#define max 100
// nhap mang
void nhapmang(int a[], int n){
	for(int i=0; i<n; i++){
	cout<<"nhap phan tu thu a =";
	cin>>a[i];
	}
}
//xuat mang
void xuatmang(int a[], int n){
	cout<<endl;
	for(int i=0; i<n; i++)
	cout<<a[i]<<"\t"
}
void swap(int &a, int &b){
	int tg = a;
	a = b;
	b = tg;
}
// hàm heap sort
void heapify(int a[], int n, int i){
	int left = 2*(i+1)-1;
	int right = 2*(i+1);
	int largest;
	if(left<n && a[left]>a[i])
	largest = left;
	else
	largest = i;
	if(right<n && a[right]>a[largest])
	largest = right;
	if(!i=largest){
		swap(a[i],a[largest]);
		heapify(a, n, largest);
		
	}
}
void buildheap(int a[], int n){
	for (int= n/2-1 ; i>=0; i--);
	heapify(a, n, i);
}
void heapsort(int a[], int n){
	buildheap(a,n);
	for(int i = n-1; i>0; i--){
		swap(a[0],a[i]);
		heapify(a, i, o);
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
	int a[max], n;
	cout<<"nhap so phan tu:"; cin>>n;
	nhapmang(a,n);
	cout<<"\nmang vua nhap la:";
	xuatmang(a,n);
	cout<<"\sap xep mang theo heapsort:";
	heapsort(a,n);
	xuatmang(a,n);
	getch();
	return 0;
}
