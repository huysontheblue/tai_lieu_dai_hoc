// sap xep chen
#include<conio.h>
#include<stdio.h>

 void InsertionSort(int a[], int n)
 {
    for (int i = 1; i < n; i++)
  {
    int x = a[i];
    int j = i-1;
       while (j >=0 && a[j ] > x) 
       {
          a[j+1] = a[j];
          j--;
       }
    a[j+1] = x;
    printf("\nDay sau buoc thu %d la: ", i); 
       for(int i = 0; i < n; i++) 
        printf("%d ", a[i]); 
  }
}
int main()
{
	int n; int a[10];
	FILE *fsort;
	fsort = fopen("intput.txt","r");
	fscanf(fsort,"%d",&n);
	a[n];
	for(int i=0; i<n; i++)
		fscanf(fsort,"%d",&a[i]);
	printf("\nGia tri lay tu FILE : ");
	for(int i=0; i<n; i++)
		printf("%d  ",a[i]);
	fclose(fsort);
    InsertionSort(a, n);
	return 0;
}
